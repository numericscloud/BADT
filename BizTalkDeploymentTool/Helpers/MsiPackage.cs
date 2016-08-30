using System;
using System.Linq;
using Microsoft.BizTalk.ApplicationDeployment;
using System.Collections.Generic;
using Microsoft.Deployment.WindowsInstaller;
using System.IO;

namespace BizTalkDeploymentTool
{
    /// <summary>
    /// MSI helper class.
    /// Contains list of methods that uses Microsoft.BizTalk.ApplicationDeployment.Engine to execute methods.
    /// </summary>
    public class MsiPackage
    {
        public string MsiPath { get; private set; }
        private IInstallPackage _scannedPackage = null;
        private List<string> _environments = null;
        private string _displayName = null;
        private int _resourcesCount = 0;
        private string _author = null;
        private string _CreateTime = null;
        private string _RevisionNumber = null;
        public MsiPackage(string msiPath)
        {
            this.MsiPath = msiPath;
            try
            {

                _scannedPackage = DeploymentUnit.ScanPackage(msiPath);
            }
            catch (Exception)
            {
                _scannedPackage = null;
            }
        }

        public IInstallPackage ScannedPackage
        {
            get
            {
                return _scannedPackage;
            }
        }

        public string Author
        {
            get
            {
                if (_author == null)
                {
                    _author = _scannedPackage.Author;
                }
                return _author;
            }
        }

        public string RevisionNumber
        {
            get
            {
                if (_RevisionNumber == null)
                {
                    _RevisionNumber = _scannedPackage.RevisionNumber;
                }
                return _RevisionNumber;
            }
        }

        public string CreateTime
        {
            get
            {
                if (_CreateTime == null)
                {
                    _CreateTime = _scannedPackage.CreateTime.ToString();
                }
                return _CreateTime;
            }
        }

        public string DisplayName
        {
            get
            {
                if (_displayName == null)
                {
                    try
                    {
                        _displayName = GetPropertyValue("DisplayName");
                    }
                    catch (Exception)
                    {
                    }
                }
                return _displayName;
            }
        }
        public int ResourcesCount
        {
            get
            {
                if (_resourcesCount == 0)
                {
                    _resourcesCount = _scannedPackage.Resources.Count();
                }
                return _resourcesCount;
            }
        }

        public List<string> Resources
        {
            get
            {
                List<string> _resources = new List<string>();
                foreach (var item in _scannedPackage.Resources)
                {
                    _resources.Add(item.Luid);
                }
                return _resources;
            }
        }


        /// <summary>
        /// Gets a list of all the target environments bundled in the specified BizTalk msi file.
        /// </summary>
        /// <param name="msiPath">The path of the BizTalk msi.</param>
        /// <returns>Returns List, with a list of all target environments.</returns>  
        public List<string> TargetEnvironments
        {
            get
            {
                if (_environments == null)
                {
                    try
                    {
                        List<string> values = GetResourcePropertyValues("System.BizTalk:BizTalkBinding", "TargetEnvironment").OrderBy(n => n).Distinct().ToList();

                        _environments = new List<string>();
                        _environments.Add("<Default>");
                        _environments.AddRange(values);
                    }
                    catch (Exception)
                    {
                        _environments = new List<string>();
                        _environments.Add("<Default>");
                    }

                }
                return _environments;
            }
        }

        public bool WebDirectoryExists
        {
            get
            {
                foreach (var resource in this._scannedPackage.Resources)
                {
                    if (resource.ResourceType.Equals("System.BizTalk:WebDirectory"))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public List<string> WebDirectories()
        {
            List<string> webDirectories = new List<string>();
            try
            {
                foreach (var resource in this._scannedPackage.Resources)
                {
                    if (resource.ResourceType.Equals("System.BizTalk:WebDirectory"))
                    {
                        webDirectories.Add(resource.Luid);
                    }
                }
            }
            catch (Exception)
            {
            }

            return webDirectories.Distinct().ToList();
        }

        private List<string> GetResourcePropertyValues(string resourceType, string propertyName)
        {
            var query = from resource in this._scannedPackage.Resources
                        from property in resource.Properties
                        where resource.ResourceType == resourceType
                                && property.Key == propertyName
                                && ((string)property.Value != string.Empty)
                        select (string)property.Value;

            return query.ToList();
        }

        private string GetPropertyValue(string propertyName)
        {
            return _scannedPackage.Properties[propertyName];
        }

        public Dictionary<string, string> GetResourceProperties(string luid)
        {
            Dictionary<string, string> propertyValue = new Dictionary<string, string>();
            foreach (var resource in _scannedPackage.Resources)
            {
                foreach (var item in resource.Properties)
                {
                    if (resource.Luid == luid)
                    {
                        propertyValue.Add(item.Key, (string)item.Value);
                    }
                }

            }
            return propertyValue;
        }

        public Dictionary<string, string> GetProperties()
        {
            Dictionary<string, string> propertyValue = new Dictionary<string, string>();
            foreach (var item in _scannedPackage.Properties)
            {
                propertyValue.Add(item.Key, (string)item.Value);
            }
            return propertyValue;
        }

        public string GetMsiProperty(string property)
        {
            try
            {
                using (var db = new Database(MsiPath, DatabaseOpenMode.ReadOnly))
                {
                    using (var view = db.OpenView(db.Tables["Property"].SqlSelectString))
                    {
                        view.Execute();
                        var q = from rec in view
                                where rec.GetString("Property") == property
                                select rec.GetString("Value");
                        return q.ToList().FirstOrDefault();

                    }
                }
            }
            catch (Exception exe)
            {
                return "Cant fetch Guid value. " + exe.Message;
            }

        }

    }
}

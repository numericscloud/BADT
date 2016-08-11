using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizTalkDeploymentTool.Helpers;
using System.IO;

namespace BizTalkDeploymentTool.Actions
{
    public class CreateIISAppAction : BaseAction
    {
        public string ServerName { get; set; }      
        public string AppPoolName { get; set; }
        public string PhysicalPath { get; set; }
        public string AppName { get; set; }
        public string SiteName { get; set; }
        public override string DisplayName
        {
            get
            {
                return this.ServerName;
            }
        }
        public override bool IsAdminOnly
        {
            get
            {
                return false;
            }
        }

        public CreateIISAppAction(string serverName)
            : base()
        {
            this.ServerName = serverName;
            this.AppPoolName = null;
            this.PhysicalPath = null;
            this.AppName = null;
            this.SiteName = null;
        }

        public override bool Execute(out string message)
        {
            bool result = false;
            string exceptionMessage;
            CreatePhysicalPathIfNotExisting(this.ServerName, this.PhysicalPath);
            result = IISHelper.CreateApplication(this.ServerName, this.AppName, this.PhysicalPath, this.AppPoolName,this.SiteName, out exceptionMessage);
            message = result ? "App created successfully." : exceptionMessage;
            return result;
        }

        private void CreatePhysicalPathIfNotExisting(string serverName, string p)
        {
            string windowsDirectory = p.Replace(":", "$");
            string physicalLocation = string.Format(@"\\{0}\{1}\", serverName, windowsDirectory);
            DirectoryInfo dInfo = new DirectoryInfo(physicalLocation);
            if (!dInfo.Exists)
            {
                Directory.CreateDirectory(physicalLocation);
            }
        }
    }
}

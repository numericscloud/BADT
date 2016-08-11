using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizTalkDeploymentTool.Helpers;
using System.IO;

namespace BizTalkDeploymentTool.Actions
{
    public class DeleteIISAppAction : BaseAction
    {
        public string ServerName { get; set; }  
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

        public DeleteIISAppAction(string serverName, string appName, string siteName)
            : base()
        {
            this.ServerName = serverName;
            this.AppName = appName;
            this.SiteName = siteName;
        }

        public override bool Execute(out string message)
        {
            bool result = false;
            string exceptionMessage;
            result = IISHelper.DeleteApplication(this.ServerName, this.AppName, this.SiteName, out exceptionMessage);
            message = exceptionMessage;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizTalkDeploymentTool.Helpers;
using System.IO;

namespace BizTalkDeploymentTool.Actions
{
    public class ChangeWebAppPool : BaseAction
    {
        public string ServerName { get; set; }  
        public string AppName { get; set; }
        public string SiteName { get; set; }
        public string ApplicationPool { get; set; }
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

        public ChangeWebAppPool(string serverName, string appName, string applicationPool, string siteName)
            : base()
        {
            this.ServerName = serverName;
            this.AppName = appName;
            this.SiteName = siteName;
            this.ApplicationPool = applicationPool;
        }

        public override bool Execute(out string message)
        {
            bool result = false;
            string exceptionMessage;
            result = IISHelper.ChangeApplicationPool(this.ServerName, this.AppName, this.ApplicationPool, this.SiteName, out exceptionMessage);
            message = exceptionMessage;
            return result;
        }
    }
}

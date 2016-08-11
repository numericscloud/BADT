using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizTalkDeploymentTool.Helpers;

namespace BizTalkDeploymentTool.Actions
{
    public class UnInstallApplicationAction : AppBaseAction
    {
        public string ServerName { get; private set; }

        public override string DisplayName
        {
            get
            {
                return string.Format(Constants._UNISTALL_APPLICATION, this.ApplicationInfo.ApplicationName, this.ServerName);
            }
        }
        public override bool IsAdminOnly
        {
            get
            {
                return true;
            }
        }

        public UnInstallApplicationAction(ApplicationInfo applicationInfo, string serverName)
            : base(applicationInfo)
        {
            this.ServerName = serverName;
        }

        public override bool Execute(out string message)
        {
            bool result = false;
            try
            {
                string UninstallGuid = RegistryHelper.GetUninstallGuid(this.ApplicationInfo.ApplicationName, this.ServerName);
                string resultMessage = ApplicationExtensions.Uninstall(this.ServerName, this.ApplicationInfo.ApplicationName, UninstallGuid, RegistryHelper.GetVersion(UninstallGuid, this.ServerName));
                message = resultMessage;
                result = !resultMessage.Contains("error");
            }
            catch (Exception exe)
            {
                message = exe.Message;
            }
            return result;
        }
    }
}

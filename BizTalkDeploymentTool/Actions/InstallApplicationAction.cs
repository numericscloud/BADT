using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizTalkDeploymentTool.Actions
{
    public class InstallApplicationAction : BaseAction
    {
        public string ServerName { get; private set; }
        public string PackageLocation { get; private set; }
        public string TargetDir { get; set; }

        public override string DisplayName
        {
            get
            {
                return string.Format(Constants._INSTALL_APPLICATION, this.ServerName);
            }
        }
        public override bool IsAdminOnly
        {
            get
            {
                return false;
            }
        }

        public InstallApplicationAction(string serverName, string packageLocation, string targetDir)
            : base()
        {
            this.ServerName = serverName;
            this.PackageLocation = packageLocation;
            this.TargetDir = targetDir;
        }

        public override bool Execute(out string message)
        {
            bool result = false;
            try
            {
                string resultMessage = ApplicationExtensions.Install(this.ServerName, this.PackageLocation,this.TargetDir);
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

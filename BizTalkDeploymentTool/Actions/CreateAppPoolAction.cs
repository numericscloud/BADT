using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizTalkDeploymentTool.Helpers;

namespace BizTalkDeploymentTool.Actions
{
    public class CreateAppPoolAction : BaseAction
    {
        public string ServerName { get; set; }
        public string AppPoolName { get; set; }
        public string AppPoolCLRVersion { get; set; }
        public string AppPoolPipelineMode { get; set; }
        public string AppPoolUserName { get; set; }
        public string AppPoolPassword { get; set; }
        public string Enable32Bit { get; set; }
        public string IdentityType { get; set; }

        public override string DisplayName
        {
            get
            {
                return string.Concat(this.ServerName);
            }
        }
        public override bool IsAdminOnly
        {
            get
            {
                return false;
            }
        }

        public CreateAppPoolAction(string serverName)
            : base()
        {
            this.ServerName = serverName;
            this.AppPoolName = null;
            this.AppPoolCLRVersion = null;
            this.AppPoolPipelineMode = null;
            this.AppPoolUserName = null;
            this.AppPoolPassword = null;
            this.Enable32Bit = null;
            this.IdentityType = null;
        }

        public override bool Execute(out string message)
        {
            bool result = false;
            string exceptionMessage;

            result = IISHelper.CreateAppPool(this.ServerName, this.AppPoolName, this.AppPoolCLRVersion, this.AppPoolPipelineMode, this.Enable32Bit,
                                    this.IdentityType, this.AppPoolUserName, this.AppPoolPassword, out exceptionMessage);
            message = result ? "App pool created successfully." : exceptionMessage;
            return result;
        }
    }
}

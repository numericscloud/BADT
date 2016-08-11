using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizTalkDeploymentTool.Helpers;

namespace BizTalkDeploymentTool.Actions
{
    public class RestartIISAction : BaseAction
    {
        public string ServerName { get; private set; }

        public override string DisplayName
        {
            get
            {
                return string.Format(Constants._RESTART_IIS, this.ServerName);
            }
        }

        public override bool IsAdminOnly
        {
            get
            {
                return false;
            }
        }

        public RestartIISAction(string serverName)
            : base()
        {
            this.ServerName = serverName;
        }

        public override bool Execute(out string message)
        {
            bool result = false;
            result = IISHelper.RestartIIS(this.ServerName, out message);          
            return result;
        }
    }
}

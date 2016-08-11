using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizTalkDeploymentTool.Helpers;

namespace BizTalkDeploymentTool.Actions
{
    public class DeleteApplicationPool : BaseAction
    {
        public string ServerName { get; private set; }
        public string ApplicationPool { get; private set; }
        public override string DisplayName
        {
            get
            {
                return string.Format(Constants._DELETE_APPPOOL, this.ApplicationPool, this.ServerName);
            }
        }

        public override bool IsAdminOnly
        {
            get
            {
                return true;
            }
        }

        public DeleteApplicationPool(string serverName, string applicationPool)
            : base()
        {
            this.ServerName = serverName;
            this.ApplicationPool = applicationPool;
        }

        public override bool Execute(out string message)
        {
            bool result = false;
            string resultMessage = "";
            try
            {
                result = IISHelper.DeleteAppPool(this.ServerName, this.ApplicationPool, out resultMessage);
            }
            catch (Exception exe)
            {
                resultMessage = exe.Message;
            }
            message = resultMessage;
            return result;
        }
    }
}

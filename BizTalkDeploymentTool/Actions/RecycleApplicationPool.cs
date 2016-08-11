using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizTalkDeploymentTool.Helpers;

namespace BizTalkDeploymentTool.Actions
{
    public class RecycleApplicationPool : BaseAction
    {
        public string ServerName { get; private set; }
        public string ApplicationPool { get; private set; }
        public bool IsApplicationPoolExisting { get; private set; }
        public override string DisplayName
        {
            get
            {
                return (!this.IsApplicationPoolExisting ? "**" : "") + string.Format(Constants._RECYCLE_APPPOOL, this.ApplicationPool, this.ServerName);
            }
        }

        public override bool IsAdminOnly
        {
            get
            {
                return true;
            }
        }

        public RecycleApplicationPool(string serverName, string applicationPool)
            : base()
        {
            this.ServerName = serverName;
            this.ApplicationPool = applicationPool;
            this.IsApplicationPoolExisting = IISHelper.DoesApplicationPoolExists(this.ServerName, this.ApplicationPool);
        }

        public override bool Execute(out string message)
        {
            bool result = false;
            string resultMessage = "";
            try
            {
                result = IISHelper.RecycleApplicationPool(this.ServerName, this.ApplicationPool, out resultMessage);                
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

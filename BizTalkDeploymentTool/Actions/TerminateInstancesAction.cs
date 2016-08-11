using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizTalkDeploymentTool.Helpers;
using System.ServiceProcess;
using BizTalkDeploymentTool.Wmi;

namespace BizTalkDeploymentTool.Actions
{
    public class TerminateInstancesAction : BaseAction
    {
        public string InstanceID { get; private set; }
        public override string DisplayName
        {
            get
            {
                return string.Format(this.InstanceID);
            }
        }

        public override bool IsAdminOnly
        {
            get
            {
                return true;
            }
        }

        public TerminateInstancesAction(string instanceID)
            : base()
        {
            this.InstanceID = instanceID;
        }

        public override bool Execute(out string message)
        {
            bool result = false;
            try
            {
                Microsoft.BizTalk.Operations.CompletionStatus status= BizTalkOperationsHelper.Terminate(this.InstanceID);
                if (status == Microsoft.BizTalk.Operations.CompletionStatus.Succeeded)
                {
                    result = true;
                }
                message = status.ToString();
            }
            catch (Exception exe)
            {
                message = exe.Message;
                result = false;
            }
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.BizTalk.Operations;
using BizTalkDeploymentTool.Global;

namespace BizTalkDeploymentTool.Helpers
{
    public static class BizTalkOperationsHelper
    {
        public static CompletionStatus Terminate(string instanceID)
        {
            BizTalkOperations bizOps = new BizTalkOperations(GlobalProperties.MgmtDBServer, GlobalProperties.MgmtDBName);
            return bizOps.TerminateInstance(new Guid(instanceID));
        }

        public static MessageFlow  GetMessageFlow(string instanceID)
        {
             BizTalkOperations bizOps = new BizTalkOperations(GlobalProperties.MgmtDBServer, GlobalProperties.MgmtDBName);
             return bizOps.GetMessageFlow(new Guid(instanceID));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BizTalkDeploymentTool.Helpers;

namespace BizTalkDeploymentTool.Actions
{
    public class DeployPolicyAction : BreBaseAction
    {
        public override string DisplayName
        {
            get 
            {
                return "";
            }
        }
        public override bool IsAdminOnly
        {
            get
            {
                return false;
            }
        }
        public DeployPolicyAction(BreInfo breInfo)
            : base(breInfo)
        {           
        }

        public override bool Execute(out string message)
        {
            bool result = false;
            string exceptionMessage;

            int iresult = BreHelper.DeployPolicy(this.BreInfo.Name, Convert.ToInt32(this.BreInfo.MajorVersion), Convert.ToInt32(this.BreInfo.MinorVersion), out exceptionMessage);
            result = iresult == 0 ? true : false;
            message = result ? "Policy successfully deployed." : exceptionMessage;           
            return result;
        }
    }
}

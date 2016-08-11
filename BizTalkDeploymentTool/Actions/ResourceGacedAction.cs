using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BizTalkDeploymentTool.Helpers;

namespace BizTalkDeploymentTool.Actions
{
    public class ResourceGacedAction : ResourceBaseAction
    {
        public override string DisplayName
        {
            get 
            {
                return string.Concat(resourceInfo.ResourceName,"-",resourceInfo.ServerName);
            }
        }

        public override bool IsAdminOnly
        {
            get
            {
                return false;
            }
        }

        public ResourceGacedAction(ResourceInfo resourceInfo)
            : base(resourceInfo)
        {           
        }

        public override bool Execute(out string message)
        {
            bool result = false;
            string exceptionMessage="";
            try
            {
                result = GenericHelper.IsRegisteredInGac(this.resourceInfo.ResourceName, this.resourceInfo.ServerName);           
            }
            catch (Exception exe)
            {
                exceptionMessage = exe.Message;
            }
           
            message = result ? "True" : exceptionMessage;           
            return result;
        }
    }
}

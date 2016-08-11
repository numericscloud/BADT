using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizTalkDeploymentTool.Actions
{
    public abstract class ResourceBaseAction : BaseAction
    {
        public ResourceInfo resourceInfo { get; private set; }

        protected ResourceBaseAction(ResourceInfo resourceInfo)
            : base()
        {
            if (resourceInfo == null)
            {
                throw new NullReferenceException("resourceInfo");
            }

            this.resourceInfo = resourceInfo;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizTalkDeploymentTool.Actions
{

    public abstract class AppBaseAction : BaseAction
    {
        public ApplicationInfo ApplicationInfo { get; private set; }

        protected AppBaseAction(ApplicationInfo applicationInfo)
            : base()
        {
            if (applicationInfo == null)
            {
                throw new NullReferenceException("applicationInfo");
            }

            this.ApplicationInfo = applicationInfo;
        }
    }
}

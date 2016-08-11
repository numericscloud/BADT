using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizTalkDeploymentTool.Actions
{
    public abstract class BizAppBaseAction : AppBaseAction
    {
        public BizTalkInfo BizTalkInfo { get; private set; }

        protected BizAppBaseAction(ApplicationInfo applicationInfo, BizTalkInfo bizTalkInfo)
            : base(applicationInfo)
        {
            if (bizTalkInfo == null)
            {
                throw new NullReferenceException("bizTalkInfo");
            }
            this.BizTalkInfo = bizTalkInfo;

        }
    }
}

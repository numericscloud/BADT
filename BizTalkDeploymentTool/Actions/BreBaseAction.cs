using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizTalkDeploymentTool.Actions
{
    public abstract class BreBaseAction : BaseAction
    {
        public BreInfo BreInfo { get; private set; }

        protected BreBaseAction(BreInfo breInfo)
            : base()
        {
            if (breInfo == null)
            {
                throw new NullReferenceException("breInfo");
            }

            this.BreInfo = breInfo;
        }
    }
}

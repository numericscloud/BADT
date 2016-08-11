using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizTalkDeploymentTool.Actions
{

    public abstract class BaseAction
    {
        public abstract string DisplayName { get; }
        public abstract bool IsAdminOnly { get; }
        protected BaseAction()
        {
        }

        public abstract bool Execute(out string message);
    }

}

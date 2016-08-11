using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizTalkDeploymentTool.Helpers;

namespace BizTalkDeploymentTool.Actions
{
    public class CheckForInProgressInstancesAction : AppBaseAction
    {
        public override string DisplayName
        {
            get
            {
                return Constants._CHECK_INPROGRESS_INSTANCE;
            }
        }

        public override bool IsAdminOnly
        {
            get
            {
                return false;
            }
        }

        public CheckForInProgressInstancesAction(ApplicationInfo applicationInfo)
            : base(applicationInfo)
        {
        }

        public override bool Execute(out string message)
        {
            int numberOfInstances = 0;
            bool instanceExists = SQLHelper.HasInProgressInstance(this.ApplicationInfo.ApplicationName, out numberOfInstances);

            if (!instanceExists)
            {
                message = "Success, No Inprogress instance for the application exists.";
            }
            else
            {
                message = numberOfInstances.ToString() + " instance{s) exists.Please terminate the existing instances before executing further actions.";
            }
            return !instanceExists;
        }

      
    }
}

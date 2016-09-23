using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.BizTalk.ExplorerOM;
using System.Threading;

namespace BizTalkDeploymentTool.Actions
{


    public class ValidateStartApplicationAction : BizAppBaseAction
    {
        public override string DisplayName
        {
            get
            {
                return Constants._VALIDATE_START_APPLICATION;
            }
        }

        public override bool IsAdminOnly
        {
            get
            {
                return false;
            }
        }

        public ValidateStartApplicationAction(ApplicationInfo applicationInfo, BizTalkInfo bizTalkInfo)
            : base(applicationInfo, bizTalkInfo)
        {
        }

        public override bool Execute(out string message)
        {
            bool result = false;
            try
            {
                this.BizTalkInfo.CatalogExplorer.Refresh();
                Application app = this.BizTalkInfo.CatalogExplorer.Applications[this.ApplicationInfo.ApplicationName];
                if (app == null)
                {
                    message = string.Format("Application :{0} does not exists", this.ApplicationInfo.ApplicationName);
                    result = false;
                }
                else
                {
                    message = string.Format("Application current status is: {0}", app.Status.ToString());
                    result = app.Status == Status.Started ? true : false;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return result;
        }
    }

}

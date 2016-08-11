using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.BizTalk.ExplorerOM;

namespace BizTalkDeploymentTool.Actions
{

    public class StopApplicationAction : BizAppBaseAction
    {
        public override string DisplayName
        {
            get
            {
                return string.Format("{0} : {1}", Constants._STOP_APPLICATION, this.ApplicationInfo.ApplicationName);
            }
        }

        public override bool IsAdminOnly
        {
            get
            {
                return false;
            }
        }

        public StopApplicationAction(ApplicationInfo applicationInfo, BizTalkInfo bizTalkInfo)
            : base(applicationInfo, bizTalkInfo)
        {
        }

        public override bool Execute(out string message)
        {
            try
            {
                StopApplication(this.ApplicationInfo.ApplicationName);
                message = string.Format("Application:{0} stopped successfully.", this.ApplicationInfo.ApplicationName);
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        public void StopApplication(string applicationName)
        {
            this.BizTalkInfo.CatalogExplorer.Refresh();

            Application app = this.BizTalkInfo.CatalogExplorer.Applications[applicationName];
            app.Stop(Microsoft.BizTalk.ExplorerOM.ApplicationStopOption.StopAll);
            this.BizTalkInfo.CatalogExplorer.SaveChanges();

            // this.BizTalkInfo.CatalogExplorer.Refresh();
        }

    }
}

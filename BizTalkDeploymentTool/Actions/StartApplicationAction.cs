using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.BizTalk.ExplorerOM;
using System.Threading;

namespace BizTalkDeploymentTool.Actions
{


    public class StartApplicationAction : BizAppBaseAction
    {
        public override string DisplayName
        {
            get
            {
                return string.Format("{0} : {1}", Constants._START_APPLICATION, this.ApplicationInfo.ApplicationName);                
            }
        }

        public override bool IsAdminOnly
        {
            get
            {
                return false;
            }
        }

        public StartApplicationAction(ApplicationInfo applicationInfo, BizTalkInfo bizTalkInfo)
            : base(applicationInfo, bizTalkInfo)
        {
        }

        public override bool Execute(out string message)
        {
            bool result = false;
            try
            {
                StartApplication(this.ApplicationInfo.ApplicationName);
                message = string.Format("Application:{0} started successfully.", this.ApplicationInfo.ApplicationName);
                result = true;

            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return result;
        }

        public void StartApplication(string applicationName)
        {
            this.BizTalkInfo.CatalogExplorer.Refresh();

            Application app = this.BizTalkInfo.CatalogExplorer.Applications[applicationName];
            app.Start(Microsoft.BizTalk.ExplorerOM.ApplicationStartOption.StartAll);

            this.BizTalkInfo.CatalogExplorer.SaveChanges();

            // return app.Status;
            //CatalogExplorer.Refresh();
        }
        private Status CurrentStatus(string applicationName)
        {
            this.BizTalkInfo.CatalogExplorer.Refresh();
            Application app = this.BizTalkInfo.CatalogExplorer.Applications[applicationName];
            return app.Status;
        }
    }

}

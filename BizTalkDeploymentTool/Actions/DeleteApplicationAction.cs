using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizTalkDeploymentTool.Helpers;
using Microsoft.BizTalk.ExplorerOM;

namespace BizTalkDeploymentTool.Actions
{
    public class DeleteApplicationAction : BizAppBaseAction
    {       
        public override string DisplayName
        {
            get
            {
                return string.Format("{0} : {1}", Constants._DELETE_APPLICATION, this.ApplicationInfo.ApplicationName);
            }
        }

        public override bool IsAdminOnly
        {
            get
            {
                return false;
            }
        }

        public DeleteApplicationAction(ApplicationInfo applicationInfo, BizTalkInfo bizTalkInfo)
            : base(applicationInfo, bizTalkInfo)
        {
        }
        public override bool Execute(out string message)
        {
            string resultMessage;
            bool result = false;
            Application app = this.BizTalkInfo.CatalogExplorer.Applications[this.ApplicationInfo.ApplicationName];
            
            //try
            //{
            //    Application app = this.BizTalkInfo.CatalogExplorer.Applications[this.ApplicationInfo.ApplicationName];
                 
            //    this.BizTalkInfo.CatalogExplorer.re
            //    this.BizTalkInfo.CatalogExplorer.RemoveApplication(this.BizTalkInfo.CatalogExplorer.Applications[this.ApplicationInfo.ApplicationName]);
            //    message = string.Format("Application deleted successfully. \r\n{0}");
            //    result = true;
            //}
            //catch (Exception exe)
            //{
            //    result = false; 
            //    message = string.Format("Application can not be deleted. \r\n{0}", exe.Message);
            //}
             result = BTSTaskHelper.DeleteApp(this.ApplicationInfo.ApplicationName, out resultMessage);
            if (result)
            {
                message = string.Format("Application:{0} deleted successfully. \r\n{1}",this.ApplicationInfo.ApplicationName, resultMessage);
            }
            else
            {
                message = string.Format("Application:{0} can not be deleted. \r\n{1}",this.ApplicationInfo.ApplicationName, resultMessage);
            }
            return result;
        }
    }
}

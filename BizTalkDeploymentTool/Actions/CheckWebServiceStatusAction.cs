using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizTalkDeploymentTool.Helpers;
using System.IO;

namespace BizTalkDeploymentTool.Actions
{
    public class CheckWebServiceStatusAction : BaseAction
    {
        public string Uri { get; set; }

        public override string DisplayName
        {
            get
            {
                return this.Uri;
            }
        }

        public override bool IsAdminOnly
        {
            get
            {
                return false;
            }
        }

        public CheckWebServiceStatusAction(string uri)
            : base()
        {
            this.Uri = uri;
        }

        public override bool Execute(out string message)
        {
            bool result = false;
            string exceptionMessage;
            result = IISHelper.CheckWebServiceStatus(this.Uri, out exceptionMessage);
            message = exceptionMessage;
            return result;
        }
    }
}

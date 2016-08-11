using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizTalkDeploymentTool.Helpers;

namespace BizTalkDeploymentTool.Actions
{
    public class DeploySsoAction : BaseAction
    {
        public string SsoConfigLocation { get; set; }
        public string SsoConfigApplicationName { get; set; }
        public string SsoKey { get; set; }
        public string SSOCompanyName { get; set; }

        public override string DisplayName
        {
            get 
            {
                return Constants._DEPLOY_SSO;
            }
        }
        public override bool IsAdminOnly
        {
            get
            {
                return false;
            }
        }
        public DeploySsoAction()
            : base()
        {
            this.SsoConfigLocation = null;
            this.SsoConfigApplicationName = null;
            this.SsoKey = null;
            this.SSOCompanyName = null;
        }

        public override bool Execute(out string message)
        {
            bool result = false;
            Validate();           
            string exceptionMessage;
            if (String.IsNullOrEmpty(this.SsoConfigLocation) || String.IsNullOrEmpty(this.SsoConfigApplicationName))
            {
                message = String.IsNullOrEmpty(this.SsoConfigLocation) ? "SSO config file is not selected." : "SSO config application name is empty.";
            }
            else
            {
                result = SSOHelper.ImportSSOconfig(this.SsoKey, this.SsoConfigLocation, this.SsoConfigApplicationName, String.Format("BizTalkAdmin@{0}.com", this.SSOCompanyName), true, out exceptionMessage);
                message = result ? "SSO config successfully imported." : exceptionMessage;
            }
            return result;
        }

        private void Validate()
        {
            if (this.SsoConfigLocation == null)
            {
                throw new ArgumentNullException("SsoConfigLocation");
            }
            if (this.SsoConfigApplicationName == null)
            {
                throw new ArgumentNullException("SsoConfigApplicationName");
            }
            if (this.SsoKey == null)
            {
                throw new ArgumentNullException("SsoKey");
            }
            if (this.SSOCompanyName == null)
            {
                throw new ArgumentNullException("SSOCompanyName");
            }
        }        
    }
}

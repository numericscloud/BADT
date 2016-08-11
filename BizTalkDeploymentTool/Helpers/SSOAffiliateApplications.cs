using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace BizTalkDeploymentTool.Helpers
{
    public class SSOAffiliateApplication
    {
        public string Application { get; set; }
        public string Description { get; set; }
        public string ContactInfo { get; set; }
        public string UserAccount { get; set; }
        public string AdminAccount { get; set; }
        public int Flag { get; set; }
        public Dictionary<string, string> UserMappings{get; set;}
        public SSOAffiliateApplication()
        {

        }
    }

    public class SSOAffiliateApplications
    {
        private string[] _applications;
        private string[] _descriptions;
        private string[] _contactInfos;
        private string[] _userAccount;
        private string[] _adminAccount;
        private int[] _flags;
        public string[] Applications { get; set; }
        public string[] Descriptions { get; set; }
        public string[] ContactInfos { get; set; }
        public string[] UserAccounts { get; set; }
        public string[] AdminAccounts { get; set; }
        public int[] Flags { get; set; }

        public SSOAffiliateApplications()
        {
            PopulateSSOApplicationList();
        }
        public void PopulateSSOApplicationList()
        {
            Microsoft.EnterpriseSingleSignOn.Interop.ISSOMapper2 ssoMapper = (Microsoft.EnterpriseSingleSignOn.Interop.ISSOMapper2)new Microsoft.EnterpriseSingleSignOn.Interop.SSOMapper();
            ssoMapper.GetApplications2(out _applications, out _descriptions, out _contactInfos, out _userAccount, out _adminAccount, out _flags);
            this.Applications = _applications;
            this.Descriptions = _descriptions;
            this.ContactInfos = _contactInfos;
            this.UserAccounts = _userAccount;
            this.AdminAccounts = _adminAccount;
            this.Flags = _flags;
        }


        public Dictionary<string, string> GetCredentials(string applicationName, string domain, string user, string pwd)
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            if (applicationName != Constants._SSO_AFFILIATE_ROOT_NODE)
            {
                if (string.IsNullOrEmpty(domain) || string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pwd))
                {
                    Cred(ref fields, applicationName);
                }
                else
                {
                    using (Impersonation.LogonUser(domain, user, pwd, Impersonation.LogonType.Interactive))
                    {
                        Cred(ref fields, applicationName);
                    }
                }
            }
            return fields;
        }

        private void Cred(ref Dictionary<string, string> fields, string applicationName)
        {
            string userName;
            string[] labels;
            int[] flags;
            try
            {
                Microsoft.BizTalk.SSOClient.Interop.ISSOMapper ssoMapper = (Microsoft.BizTalk.SSOClient.Interop.ISSOMapper)new Microsoft.BizTalk.SSOClient.Interop.SSOMapper();
                ssoMapper.GetFieldInfo(applicationName, out labels, out flags);

                Microsoft.BizTalk.SSOClient.Interop.ISSOLookup1 ssoLookup = (Microsoft.BizTalk.SSOClient.Interop.ISSOLookup1)new Microsoft.BizTalk.SSOClient.Interop.SSOLookup();
                string[] creds = ssoLookup.GetCredentials(applicationName, 0, out userName);
                fields.Add(labels[0], userName);
                for (int i = 0; i < creds.Length; i++)
                {
                    fields.Add(labels[i + 1], creds[i]);
                }
            }
            catch (Exception exe)
            {
                userName = "";
                fields.Add("Error", exe.Message);
                // return new string[] { exe.Message };
            }
        }
    }
}

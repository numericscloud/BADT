using System;
using Microsoft.EnterpriseSingleSignOn.Interop;
using Microsoft.BizTalk.ExplorerOM;
namespace BizTalkDeploymentTool.Helpers
{
    /// <summary>
    /// SSO config helper class.
    /// Contains list of methods that uses SSOConfigurationImportTask for SSO deploy execution.
    /// </summary>
    public static class SSOHelper
    {
        /// <summary>
        /// Deletes SSO configuration from BizTalk DB for specified SSO Config application
        /// </summary>
        /// <param name="ssoConfigApplicaionName">SSO Config application name.</param>
        public static void DeteleSSOconfig(string ssoConfigApplicaionName)
        {
            ISSOAdmin ad = new ISSOAdmin();
            ad.DeleteApplication(ssoConfigApplicaionName);
        }

        public static string[] GetAllSSOconfig()
        {
            string[] applicationList;
            string[] desc;
            string[] cInfo;

            Microsoft.BizTalk.SSOClient.Interop.ISSOMapper mapper = new Microsoft.BizTalk.SSOClient.Interop.ISSOMapper();
            mapper.GetApplications(out applicationList, out desc, out cInfo);
            return applicationList;

        }

        /// <summary>
        /// Imports the specified SSO config file to BizTalk SSODB.
        /// </summary>
        /// <param name="ssoKey">Key to import SSO file.</param>
        /// <param name="ssoEncryptedFile">Full path of the SSO config file, from where to import.</param>
        /// <param name="ssoConfigappName">Application name under which the SSO will be imported.</param>
        /// <param name="SSOConfigContactInfo">SSOConfigContactInfo , which will make the config visible in SSO Admin mmc. The name has to be the one which was specified while installing Microsoft SSO MMC snapIn tool.</param>
        /// <param name="redeploy">Boolean, Redeploy flag (True: Deletes existing SSO and imports the new, False : Imports the new SSO without deleting previous one).</param>
        /// <returns>Returns true/fasle.</returns>  
        public static bool ImportSSOconfig(string ssoKey, string ssoEncryptedFile, string ssoConfigappName, string SSOConfigContactInfo, bool redeploy,
                                            out string exceptionMessage)
        {
            bool result = false;
            try
            {
                exceptionMessage = string.Empty;
                ISSOAdmin ssoAdmin = new ISSOAdmin();
                if (redeploy)
                    ssoAdmin.DeleteApplication(ssoConfigappName);
                MSBuildTasks.ImportSSOConfigurationApplicationTask import = new MSBuildTasks.ImportSSOConfigurationApplicationTask();
                import.EncryptionKey = ssoKey;
                import.EncryptedFile = ssoEncryptedFile;
                result = import.Execute();
                if (result)
                {
                    ssoAdmin.UpdateSSOCompanyName(ssoConfigappName, SSOConfigContactInfo);
                }
            }
            catch (Exception exe)
            {
                exceptionMessage = exe.Message;
                result = false;
            }
            return result;
        }

        public static object[] GetWindowsUserMapping(string userAccount, string applicationName)
        {
            Microsoft.BizTalk.SSOClient.Interop.ISSOMapper mapper = new Microsoft.BizTalk.SSOClient.Interop.ISSOMapper();
            string[] tt = userAccount.Split('\\');
            return mapper.GetMappingsForWindowsUser(tt[0], tt[1], applicationName);
        }
        public static string[] GetCredentials(string applicationName, int flags)
        {
            string externalUser = "";
            Microsoft.BizTalk.SSOClient.Interop.ISSOLookup2 lookup = new Microsoft.BizTalk.SSOClient.Interop.ISSOLookup2();
            return lookup.GetCredentials(applicationName, flags, out externalUser);
        }
    }
}

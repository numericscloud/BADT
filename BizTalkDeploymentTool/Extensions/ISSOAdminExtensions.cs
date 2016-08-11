using System;
using Microsoft.EnterpriseSingleSignOn.Interop;

namespace BizTalkDeploymentTool
{
    public static class ISSOAdminExtensions
    {
        public static void UpdateSSOCompanyName(this Microsoft.EnterpriseSingleSignOn.Interop.ISSOAdmin ssoAdmin,string ssoConfigappName, string ssoCompanyName)
        {
            string description = string.Empty;
            string contactInfo = string.Empty;
            string userGrpName = string.Empty;
            string adminGrpName = string.Empty;
            int numFields = 0;
            int flags = 0;
            ssoAdmin.GetApplicationInfo(ssoConfigappName, out description, out contactInfo, out userGrpName, out adminGrpName, out flags, out numFields);
            ssoAdmin.UpdateApplication(ssoConfigappName, description, ssoCompanyName, userGrpName, adminGrpName, flags, numFields);
            ssoAdmin.PurgeCacheForApplication(ssoConfigappName);
        }
    }
}

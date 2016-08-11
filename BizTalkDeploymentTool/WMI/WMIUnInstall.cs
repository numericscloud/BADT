using System;
using System.Management;

namespace BizTalkDeploymentTool.Wmi
{
    public static class WMIUnInstall
    {

        /// <summary>
        /// Uninstall application on specified machine.
        /// </summary>
        /// <param name="computerName">Server on which to Uninstall application.</param>
        /// <param name="applicationName">Application to uninstall.</param>
        /// <param name="identifyingNumber">Identifying number (GUID that uniquely identifies the application).</param>
        /// <param name="versionNumber">Application version number to uninstall.</param>
        /// <returns>Returns the result of execution as string.</returns>
        public static string Uninstall(string computerName, string applicationName, string identifyingNumber, string versionNumber)
        {
            ManagementBaseObject retVal = Invoke("Uninstall", computerName, applicationName, identifyingNumber, versionNumber);
            return retVal["ReturnValue"].ToString();
        }


        private static ManagementBaseObject Invoke(string methodName, string computerName, string applicationName, string identifyingNumber, string versionNumber)
        {
            string strWQL = string.Format("Win32_Product.IdentifyingNumber='{0}',Name='{1}',Version='{2}'", identifyingNumber, applicationName, versionNumber);
            return WMICommon.CreateUninstall_InstallManagementObject(strWQL, computerName).InvokeMethod(methodName, null, null);
        }

    }
}

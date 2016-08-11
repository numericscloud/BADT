using System;
using System.Management;

namespace BizTalkDeploymentTool.Wmi
{
    public static class WMIInstall
    {
        /// <summary>
        /// Installs application on specified machine.
        /// </summary>
        /// <param name="computerName">Server on which to Uninstall application.</param>
        /// <param name="packageToInstall">Full path of the package to install.</param>
        /// <returns>Returns the result of execution as string.</returns>
        public static string Install(string computerName, string packageToInstall, string targetDir)
        {
            ManagementBaseObject retVal = Invoke("Install", computerName, packageToInstall, targetDir);
            return retVal["ReturnValue"].ToString();
        }


        /// <summary>
        /// Installs application on specified machine.
        /// </summary>
        /// <param name="methodName">WMI method name to execute (Install).</param>
        /// <param name="computerName">Server on which to Uninstall application.</param>
        /// <param name="packageToInstall">Full path of the package to install.</param>
        private static ManagementBaseObject Invoke(string methodName, string computerName, string packageToInstall, string targetDir)
        {
            string strWql = "Win32_Product";
            ManagementClass managementClass = WMICommon.CreateUninstall_InstallManagementClass(strWql, computerName);
            ManagementBaseObject inParams = managementClass.GetMethodParameters(methodName);
            inParams["AllUsers"] = true;
            inParams["PackageLocation"] = packageToInstall;
            if (!String.IsNullOrEmpty(targetDir))
            {
                inParams["Options"] = string.Format("TARGETDIR=\"{0}\"", targetDir);
            }
            return managementClass.InvokeMethod(methodName, inParams, null);
        }

    }
}

using System;
using System.Management;

namespace BizTalkDeploymentTool.Wmi
{
    /// <summary>
    /// WMI helper class.
    /// Contains list of methods that uses WMI for execution.
    /// </summary>    
    public static class WMICommon
    {        

        /// <summary>
        /// Gets the ManagementObjectSearcher object from specified WMI root and WMI query.
        /// </summary>
        /// <param name="WMIRoot">WMI root for which searcher is expected.</param>
        /// <param name="strWQL">WMI query string</param>
        /// <returns>ManagementObjectSearcher</returns>
        public static ManagementObjectSearcher CreateSearcher(string WMIRoot, string strWQL)
        {
            return new ManagementObjectSearcher(new ManagementScope(WMIRoot), new WqlObjectQuery(strWQL), null);
        }
       
        public static ManagementObject CreateUninstall_InstallManagementObject(string strWQL, string computerName)
        {
            return new ManagementObject("\\\\" + computerName + Constants._UN_INSTALL_WMI_ROOT, strWQL, null);
        }
        
       
        public static ManagementClass CreateUninstall_InstallManagementClass(string strWQL, string computerName)
        {
            return new ManagementClass("\\\\" + computerName + Constants._UN_INSTALL_WMI_ROOT, strWQL, new ObjectGetOptions());
        }

    }
}

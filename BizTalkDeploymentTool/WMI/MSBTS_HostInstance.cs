using System;
using System.Management;
using System.Collections.Generic;

namespace BizTalkDeploymentTool.Wmi
{
    public static class MSBTS_HostInstance
    {
        
        /// <summary>
        /// Checks the ServiceState of the specified hostInstance if its running or not.
        /// </summary>
        /// <param name="hostInstanceName">HostInstance name for which the running state needs to be checked.</param>
        /// <returns>Returns true/false.</returns>
        private static bool CheckServiceStateIsRunning(string hostInstanceName)
        {
            foreach (ManagementObject hostInstance in GetCollectionByHostName(hostInstanceName))
            {
                if (Convert.ToInt32(hostInstance["ServiceState"]) != (int)Property.HostInstanceState.Running)
                {
                    return false;
                }
            }
            return true;
        }

        public static string GetHostInstanceStatus(string hostInstanceName)
        {
            string serviceState="";
            foreach (ManagementObject hostInstance in GetCollectionByHostInstanceName(hostInstanceName))
            {
                uint status = (uint)hostInstance["ServiceState"];
                serviceState = ((Property.HostInstanceState)status).ToString();
            }
            return serviceState;
        }



        /// <summary>
        /// Restart specific Host on specified machine.
        /// </summary>
        /// <param name="hostInstanceName">HostName which needs to be restarted.</param>
        /// <returns>Returns true/false.</returns>
        public static bool Restart(string hostInstanceName)
        {
            ManagementBaseObject outParamsStop = CreateBizTalkHostInstanceManagementObject(hostInstanceName).InvokeMethod("Stop", null, null);
            ManagementBaseObject outParamsStart = CreateBizTalkHostInstanceManagementObject(hostInstanceName).InvokeMethod("Start", null, null);
            return CheckServiceStateIsRunning(hostInstanceName);
        }


        ///// <summary>
        ///// Checks if the specified host Instance is disabled in the biztalk group .
        ///// </summary>
        ///// <param name="hostInstanceName">Name of the host instance.</param>
        ///// <returns>Returns true/false<string>.</returns>  
        //public static bool IsDisabled(string hostInstanceName)
        //{
        //    bool IsDisabled = false;
        //    foreach (ManagementObject queryObj in GetCollectionByHostInstanceName(hostInstanceName))
        //    {
        //        IsDisabled = Convert.ToBoolean(queryObj["IsDisabled"].ToString());
        //    }
        //    return IsDisabled;
        //}


        // <summary>
        /// Gets the ManagementObject of \\root\\MicrosoftBizTalkServer WMI for specified Host Instance.
        /// </summary>
        /// <param name="hostInstanceName">Host Instance name for which ManagementObject is expected.</param>
        private static ManagementObject CreateBizTalkHostInstanceManagementObject(string hostInstanceName)
        {
            string strWQL = string.Format("MSBTS_HostInstance.MgmtDbNameOverride='',MgmtDbServerOverride='',Name='{0}'", hostInstanceName);
            return new ManagementObject(Constants._BIZTALK_WMI_ROOT, strWQL, null);
        }




        ///// <summary>
        ///// Gets Name and RunningServer array list for specified host in BizTalk group.
        ///// </summary>
        ///// <param name="hostName">Name of biztalk host.</param>
        ///// <returns>Returns List of string[].</returns>
        //public static List<string> GetEnabledHostInstanceName(string hostName)
        //{
        //    List<string> hostInstances = new List<string>();
        //    foreach (ManagementObject hostInstance in GetCollectionByHostName(hostName))
        //    {
        //       // hostInstances.Add(new string[2] { hostInstance["Name"].ToString(), hostInstance["RunningServer"].ToString() });
        //        if (!MSBTS_HostInstance.IsDisabled(hostInstance["Name"].ToString()))
        //        {
        //            hostInstances.Add(hostInstance["Name"].ToString());
        //        }
        //    }
        //    return hostInstances;
        //}


        /// <summary>
        /// Gets the ManagementObjectCollection of HostInstance by HostName in BizTalk group.
        /// </summary>
        /// <param name="hostName">Host Name in the BizTalk group</param>
        /// <returns>Returns ManagementObjectCollection.</returns> 
        private static ManagementObjectCollection GetCollectionByHostName(string hostName)
        {
            string strWQL = string.Format("SELECT * FROM MSBTS_HostInstance WHERE HostName ='{0}'", hostName);
            ManagementObjectSearcher searcher = WMICommon.CreateSearcher(Constants._BIZTALK_WMI_ROOT, strWQL);
            return searcher.Get();
        }

        /// <summary>
        /// Gets the ManagementObjectCollection of HostInstance by HostInstanceName in BizTalk group.
        /// </summary>
        /// <param name="hostInstanceName">HostInstance name</param>
        /// <returns>Returns ManagementObjectCollection.</returns> 
        private static ManagementObjectCollection GetCollectionByHostInstanceName(string hostInstanceName)
        {
            string strWql = string.Format("SELECT * FROM MSBTS_HostInstance WHERE Name = '{0}'", hostInstanceName);
            ManagementObjectSearcher searcher = WMICommon.CreateSearcher(Constants._BIZTALK_WMI_ROOT, strWql);
            return searcher.Get();
        }

    }
}

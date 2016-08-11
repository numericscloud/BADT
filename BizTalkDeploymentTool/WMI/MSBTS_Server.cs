using System;
using System.Management;
using System.Collections.Generic;

namespace BizTalkDeploymentTool.Wmi
{
    public static class MSBTS_Server
    {
        /// <summary>
        /// Get list of messaging servers in BizTalk group.
        /// </summary>
        /// <returns>Returns List, a list of all servers.</returns>  
        public static List<string> GetMessagingServers()
        {
            List<string> btServerlist = new List<string>();
            foreach (ManagementObject queryObj in GetServerList())
            {
                btServerlist.Add(queryObj["Name"].ToString().ToUpper());
            }
            return btServerlist;
        }

        /// <summary>
        /// Gets the ManagementObjectCollection of messaging servers in BizTalk group.
        /// </summary>
        /// <returns>Returns ManagementObjectCollection.</returns> 
        private static ManagementObjectCollection GetServerList()
        {
            string strWql = string.Format("SELECT * FROM MSBTS_Server");
            ManagementObjectSearcher searcher = WMICommon.CreateSearcher(Constants._BIZTALK_WMI_ROOT, strWql);
            return searcher.Get();
        }

    }
}

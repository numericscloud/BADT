using System;
using System.Management;
using System.Collections.Generic;

namespace BizTalkDeploymentTool.Wmi
{
    public static class MSBTS_Host
    {
        /// <summary>
        /// Gets the ManagementObjectCollection of all the Hosts in BizTalk group.
        /// </summary>
        /// <returns>Returns ManagementObjectCollection.</returns> 
        private static ManagementObjectCollection GetHostCollection()
        {
            string strWql = "SELECT * FROM MSBTS_Host";
            ManagementObjectSearcher searcher = WMICommon.CreateSearcher(Constants._BIZTALK_WMI_ROOT, strWql);
            return searcher.Get();
        }



        /// <summary>
        /// Gets list of all InProcess hosts in BizTalk group.
        /// </summary>
        /// <returns>Returns List.</returns>  
        public static List<string> GetAllInProcessHosts()
        {
            List<string> hostNames = new List<string>();

            foreach (ManagementObject queryObj in GetHostCollection())
            {
                if (Convert.ToInt32(queryObj["HostType"]) == (int)Property.HostInstanceType.InProcess)
                {
                    hostNames.Add(queryObj["Name"].ToString());
                }
            }
            return hostNames;
        }

    }
}

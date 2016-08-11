using System;
using System.Management;

namespace BizTalkDeploymentTool.Wmi
{
    public static class MSBTS_MsgBoxSetting
    {
        /// <summary>
        /// Gets the ManagementObjectCollection of MsgBoxSetting in BizTalk group.
        /// </summary>
        private static ManagementObjectCollection GetDatabaseCollection()
        {
            string strWql = "SELECT * FROM MSBTS_MsgBoxSetting";
            ManagementObjectSearcher searcher = WMICommon.CreateSearcher(Constants._BIZTALK_WMI_ROOT, strWql);
            return searcher.Get();
        }

        /// <summary>
        /// Gets BizTalk MessageBox Database Name in BizTalk group.
        /// </summary>
        /// <returns>Returns MsgBoxDBName.</returns> 
        public static string GetDatabaseName()
        {
            string messageBoxDBName = "BizTalkMsgBoxDb";
            foreach (ManagementObject queryObj in GetDatabaseCollection())
            {
                messageBoxDBName = queryObj["MsgBoxDBName"].ToString();
            }
            return messageBoxDBName;
        }


        /// <summary>
        /// Gets BizTalk MessageBox Database Server Name in BizTalk group.
        /// </summary>
        /// <returns>Returns MsgBoxDBServerName.</returns>  
        public static string GetDatabaseServerName()
        {
            string messageBoxDBServerName = string.Empty;
            foreach (ManagementObject queryObj in GetDatabaseCollection())
            {
                messageBoxDBServerName = queryObj["MsgBoxDBServerName"].ToString();
            }
            return messageBoxDBServerName;
        }

    }
}

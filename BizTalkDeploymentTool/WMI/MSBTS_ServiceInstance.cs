using System;
using System.Management;

namespace BizTalkDeploymentTool.Wmi
{
    public static class MSBTS_ServiceInstance
    {
        public static void Terminate(string instanceID)
        {
            try
            {
                ManagementBaseObject outParams = GetTerminateInstanceManagementObject(instanceID).InvokeMethod("Terminate", null, null);
            }
            catch (ManagementException err)
            {
                System.Diagnostics.EventLog.WriteEntry("Terminate Instance Error", "Process error for Instance ID:" + instanceID + "Error message: " + err.Message);
            }
        }
        private static ManagementObject GetTerminateInstanceManagementObject(string instanceID)
        {
            string query = string.Format("MSBTS_ServiceInstance.InstanceID='{0}{1}{2}',MgmtDbNameOverride='',MgmtDbServerOverride=''", "{", instanceID, "}");
            ManagementObject classInstance =
                new ManagementObject("root\\MicrosoftBizTalkServer", query, null);
            return classInstance;
        }
    }
}

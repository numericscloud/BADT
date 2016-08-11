using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizTalkDeploymentTool.Wmi;
using System.Management;

namespace BizTalkDeploymentTool.Helpers
{
    public static class WmiHelper
    {
        public static IEnumerable<string> GetSendHandlerHosts()
        {
            var query = (from SendHandler2 sh in SendHandler2.GetInstances()
                         select sh.HostName).Distinct().OrderBy(n=>n);
            return query.ToList();
        }

        public static string GetWindowsDirectory(string serverName)
        {
            string name="";
            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("\\\\" + serverName + Constants._UN_INSTALL_WMI_ROOT, "SELECT * FROM Win32_OperatingSystem ");
			using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectSearcher.Get().GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ManagementObject managementObject = (ManagementObject)enumerator.Current;
					name = managementObject["WindowsDirectory"].ToString();
				}
			}
            return name;
        }
    }
}

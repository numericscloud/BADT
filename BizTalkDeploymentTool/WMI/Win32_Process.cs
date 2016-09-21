using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using BizTalkDeploymentTool;
using System.Diagnostics;
using System.Threading;
namespace BizTalkDeploymentTool.WMI
{
    public class Win32_Process
    {
        public static bool Create(string serverName, string commandLine, out string message)
        {

            ConnectionOptions connOptions = new ConnectionOptions();
            connOptions.EnablePrivileges = true;
            connOptions.Impersonation = ImpersonationLevel.Impersonate;
            connOptions.Authentication = AuthenticationLevel.PacketPrivacy;

            ManagementScope manScope = new ManagementScope(String.Format(@"\\{0}\ROOT\CIMV2", serverName), connOptions);
            manScope.Connect();

            ObjectGetOptions objectGetOptions = new ObjectGetOptions();
            ManagementPath managementPath = new ManagementPath("Win32_Process");
            ManagementClass processClass = new ManagementClass
            (manScope, managementPath, objectGetOptions);
            // Settings the parameters for the Create method in the process class
            ManagementBaseObject inParams = processClass.GetMethodParameters("Create");

            try
            {
                ManagementPath processStartupClassPath = new ManagementPath("Win32_ProcessStartup");
                ManagementClass processStartupClass = new ManagementClass(manScope, processStartupClassPath, objectGetOptions);
                ManagementObject processStartupInstance = processStartupClass.CreateInstance();
                processStartupInstance["ShowWindow"] = 0; // A const value for showing the window normally
                inParams["ProcessStartupInformation"] = processStartupInstance;
            }
            catch
            {
                // Launch with Pop-Up window
            }
            // Add the input parameters.
            inParams["CommandLine"] = commandLine;

            // Execute the method and obtain the return values.
            ManagementBaseObject outParams =
                processClass.InvokeMethod("Create", inParams, null);
            string processId = outParams["ProcessId"].ToString();

            while (!ProcessCompleted(manScope,processId))
            {
                Thread.Sleep(10);
            }
            if (outParams["ReturnValue"].ToString() == "0")
            {
                message = string.Format("Process with Id: {0} returned success result. \r\n", processId);
            }
            else
            {
                message = string.Format("Process with Id: {0} returned failure result. \r\n", processId);
            }
            return outParams["ReturnValue"].ToString() == "0" ? true : false;

        }

        private static bool ProcessCompleted(ManagementScope manScope, string ProcessId)
        {
            SelectQuery CheckProcess = new SelectQuery("Select * from Win32_Process Where ProcessId = " + ProcessId);
            using (ManagementObjectSearcher ProcessSearcher = new ManagementObjectSearcher(manScope, CheckProcess))
            {
                using (ManagementObjectCollection MoC = ProcessSearcher.Get())
                {
                    if (MoC.Count == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}

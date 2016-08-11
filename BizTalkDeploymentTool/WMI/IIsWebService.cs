using System;
using System.Diagnostics;
using System.Management;
using System.Text;

namespace BizTalkDeploymentTool
{
    public static class IIsWebService
    {

        private static ConnectionOptions GetConnection()
        {
            ConnectionOptions connection = new ConnectionOptions();
            connection.EnablePrivileges = true;
            connection.Impersonation = ImpersonationLevel.Impersonate;
            connection.Authentication = AuthenticationLevel.PacketPrivacy;
            return connection;
        }       

        // <summary>
        /// Gets the ManagementScope of \\root\\MicrosoftIISv2 WMI for specified server.
        /// </summary>
        /// <param name="computerName">Server for which the ManagementScope is expected</param>
        private static ManagementScope CreateIISManagementScope(string computerName)
        {
            return new ManagementScope("\\\\" + computerName + Constants._IIS_WMI_ROOT, GetConnection());
        }


        /// <summary>
        /// Restart IIS on specified machine.
        /// </summary>
        /// <param name="computerName">Server on which to restart IIS.</param>
        /// <returns>Returns the result of execution as string.</returns>
        public static int Restart(string computerName)
        {
            ManagementObject obj = CreateIISManagementObject(computerName);
            if (obj["State"].ToString() == "Running")
            {
                ManagementBaseObject ValStop = obj.InvokeMethod("StopService", null, null);
                ManagementBaseObject ValStart = obj.InvokeMethod("StartService", null, null);
                return Convert.ToInt32(ValStop["ReturnValue"].ToString()) + Convert.ToInt32(ValStart["ReturnValue"].ToString());
            }
            else
            {
                ManagementBaseObject ValStart = obj.InvokeMethod("StartService", null, null);
                return Convert.ToInt32(ValStart["ReturnValue"].ToString());
            }
            
        }

        public static bool Restart2(string computerName, out string message)
        {
            return ExecuteIISResetTask(computerName, out message);
        }

        private static bool ExecuteIISResetTask(string arguments, out string result)
        {
            ProcessStartInfo StartInfo = new ProcessStartInfo("iisreset.exe");
            StartInfo.CreateNoWindow = true;
            StartInfo.Arguments = arguments;
            StartInfo.RedirectStandardOutput = true;
            StartInfo.UseShellExecute = false;

            StringBuilder sb = new StringBuilder();
            var process = new System.Diagnostics.Process();
            process.StartInfo = StartInfo;
            process.Start();
            while (process.StandardOutput.Peek() > -1)
                sb.Append(process.StandardOutput.ReadToEnd());
            process.WaitForExit();
            result = sb.ToString();
            return process.ExitCode == 0;
        }

        // <summary>
        /// Gets the ManagementObject of \\root\\MicrosoftIISv2 WMI for specified server.
        /// </summary>
        /// <param name="computerName">Server for which the ManagementScope is expected</param>
        private static ManagementObject CreateIISManagementObject(string computerName)
        {
            ManagementScope scope = CreateIISManagementScope(computerName);
            scope.Connect();
            return new ManagementObject(scope, new ManagementPath("IIsWebService.Name='W3SVC'"), null);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizTalkDeploymentTool.Helpers
{
    public static class BTDFDeployHelper
    {
        public static bool ExecuteMsiExecTask(string arguments, out string result)
        {
            ProcessStartInfo StartInfo = new ProcessStartInfo("msiexec.exe");
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

        public static bool ExecuteEnvironmentSettingsExporter(string exePath, string arguments, out string result)
        {
            ProcessStartInfo StartInfo = new ProcessStartInfo(exePath);
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
    }
}

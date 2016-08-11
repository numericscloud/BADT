using System;
using System.Text;
using System.Diagnostics;

namespace BizTalkDeploymentTool.Helpers
{
    /// <summary>
    /// BTSTask exe helper class.
    /// Contains list of methods that uses BizTalk's BTSTask.exe.
    /// </summary>
    public static class BTSTaskHelper
    {
        /// <summary>
        /// Imports biztalk msi from the specified location and imports the specified bindings for the application.
        /// </summary>
        /// <param name="applicationName">The application name to which the msi will be imported.</param>        /// 
        /// <param name="msiLocation">The location from which the msi will be imported.</param>
        /// <param name="environment">The target environment for bindings.</param>
        /// <returns>Returns the import execution result as string</returns>     
        public static bool ImportApp(string applicationName, string msiLocation, string environment, out string result)
        {
            string arguments = string.Format("ImportApp /Package:{0} /Environment:{1} /ApplicationName:{2} /Overwrite", msiLocation.Encode(), environment.Encode(), applicationName.Encode());
            return ExecuteBtsTask(arguments, out result);            
        }

        /// <summary>
        /// Deletes the specified application from BizTalk server.
        /// </summary>
        /// <param name="applicationName">The application name which will be deleted.</param>
        /// <returns>Returns the delete execution result as string</returns>     
        public static bool DeleteApp(string applicationName, out string result)
        {
            return ExecuteBtsTask("RemoveApp /ApplicationName:" + applicationName.Encode(), out result);            
        }

        public static bool ImportBinding(string applicationName, string bindingfilelocation, out string result)
        {          
            string arguments = string.Format("ImportBindings /ApplicationName:{0} /Source:{1}" , applicationName.Encode(),bindingfilelocation.Encode());
            return ExecuteBtsTask(arguments, out result);
        }

        /// <summary>
        /// Runs BTSTask.exe with specified argument.
        /// </summary>
        /// <param name="arguments">Argument that will be passed to BTSTask.exe.</param>
        /// <returns>Returns the exe execution result as string</returns>  
        private static bool ExecuteBtsTask(string arguments, out string result)
        {
            ProcessStartInfo StartInfo = new ProcessStartInfo("BTSTask.exe");
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

        private static string Encode(this string parameter)
        {
            return string.Format("\"{0}\"",parameter.Replace("\"", "\"\""));
        }
    }
}

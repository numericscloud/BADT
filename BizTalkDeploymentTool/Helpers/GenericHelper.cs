using System;
using System.IO;
using Microsoft.Win32;
using System.Configuration;
using System.Xml;
using System.Reflection;
using System.Xml.Xsl;
using System.Net.NetworkInformation;
using System.Collections.Generic;
using System.Text;

namespace BizTalkDeploymentTool.Helpers
{
    public static class GenericHelper
    {
        public static bool PingServer(string serverName)
        {
            PingReply pingReply;
            using (var ping = new Ping())
            {
                pingReply = ping.Send(serverName);
            }
            return pingReply.Status == IPStatus.Success;
        }

        public static string WriteLog(string strLog)
        {
            StreamWriter log;
            FileStream fileStream = null;
            DirectoryInfo logDirInfo = null;
            FileInfo logFileInfo;

            string logFilePath = "C:\\Temp\\";// GetTempFolder(Environment.MachineName);
            logFilePath = logFilePath + "Log-" + System.DateTime.Today.ToString("MM-dd-yyyy") + "." + "txt";
            logFileInfo = new FileInfo(logFilePath);
            logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
            if (!logDirInfo.Exists) logDirInfo.Create();
            if (!logFileInfo.Exists)
            {
                fileStream = logFileInfo.Create();
            }
            else
            {
                fileStream = new FileStream(logFilePath, FileMode.Append);
            }
            log = new StreamWriter(fileStream);
            log.WriteLine(strLog);
            log.Close();
            return logFilePath;
        }

        /// <summary>
        /// Get a temporary folder on the specified machine.
        /// Gets the system Tempory folder location from Temp Internet files location if available else Gets the temporary folder location from Environment
        /// </summary>
        /// <param name="computerName">Computer name ofr which a temporary folder location is required.</param>
        /// <returns>Returns full path of temporary folder.</returns>  
        public static string GetTempFolder(string computerName)
        {
            string tempFolder;
            // tempFolder = RegistryHelper.GetSystemTempFolder(computerName, Constants._TEMP_INTERNET_FOLDER_REGISTRY, RegistryHive.CurrentUser, "Cache");
            tempFolder = RegistryHelper.GetSystemTempFolder(computerName, Constants._ENVIRONMENT_TEMP_REGISTRY, RegistryHive.LocalMachine, "TEMP");
            return tempFolder;
        }

        /// <summary>
        /// Copies a specified file to temporary location on the specified server and return the path.
        /// </summary>
        /// <param name="server">Server on which the file needs to be copied.</param>
        /// <param name="msiLocation">Location from which the file will be copied to temporary folder.</param>
        /// <returns>Returns full path of temporary copied file.</returns>  
        public static string CopyToTempFolder(string server, string msiLocation)
        {
            string tempfile = Path.Combine(GetTempFolder(server), Path.GetFileName(msiLocation));
            File.Copy(msiLocation, tempfile, true);
            return tempfile;
        }

        public static string FormatPath(string serverName, string path)
        {
            path = path.Replace(":", "$");
            return string.Format(@"\\{0}\{1}", serverName, path);

        }

        public static bool IsRegisteredInGac(string assemblyName, string machineName)
        {
            string windowsDirectory = WmiHelper.GetWindowsDirectory(machineName);
            windowsDirectory = windowsDirectory.Replace(":", "$");
            string GacLocation64 = string.Format(@"\\{0}\{1}\Microsoft.Net\Assembly\GAC_MSIL", machineName, windowsDirectory);
            string GacLocation32 = string.Format(@"\\{0}\{1}\Microsoft.Net\Assembly\GAC_32", machineName, windowsDirectory);
            string GacLocationx86 = string.Format(@"\\{0}\{1}\Assembly\GAC_MSIL", machineName, windowsDirectory);

            string[] splitName = assemblyName.Split(',');
            string searchName = splitName[0];

            if (Directory.Exists(System.IO.Path.Combine(GacLocation64, searchName)) || Directory.Exists(System.IO.Path.Combine(GacLocation32, searchName))
                                || Directory.Exists(System.IO.Path.Combine(GacLocationx86, searchName)))
            {
                //DirectoryInfo dirInfo = new DirectoryInfo(System.IO.Path.Combine(GacLocation64, searchName));

                return true;
            }
            else
            {
                return false;
            }
            // DirectoryInfo[] dInfoArray = dInfo.GetDirectories(searchName);
            // return dInfo.GetDirectories(searchName,SearchOption.AllDirectories)[0].Exists;          

        }


        public static string TransformData(string xsltResource, string inputData)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(inputData);
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            XmlTextReader xmlTextReader = new XmlTextReader(executingAssembly.GetManifestResourceStream(xsltResource));
            XslCompiledTransform orchCodeTransform = new XslCompiledTransform();
            orchCodeTransform.Load(xmlTextReader);
            using (var writer = new StringWriter())
            {
                orchCodeTransform.Transform(xDoc.CreateNavigator(), null, writer);
                return writer.ToString();
            }
        }

        public static string BuildParametersFromConfigurations(Dictionary<string, string> configurations)
        {
            StringBuilder configString = new StringBuilder(); ;
            foreach (KeyValuePair<string, string> configuration in configurations)
            {
                configString.Append(string.Format(" /p:{0}={1}", configuration.Key, configuration.Value.Encode()));
            }
            return configString.ToString();
        }

    }
}
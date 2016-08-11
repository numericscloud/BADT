using System;
using System.Collections.Generic;
using Microsoft.BizTalk.ExplorerOM;
using System.IO;
using BizTalkDeploymentTool.Wmi;
using BizTalkDeploymentTool.Helpers;

namespace BizTalkDeploymentTool
{
    public static class ApplicationExtensions
    {
        // Gets the Dictionary of HostNames associated with the application <"HostName", "Whether the host is assocated with dynamic send port (true/false)">
        public static Dictionary<string, bool> GetHostNamesWithAsAResultOfDynamicPort(this Application application)
        {
            //Dictionary<'Host Name', 'Is Dynamic port host'>
            Dictionary<string, bool> hostNames = new Dictionary<string, bool>();

            string hostName = "";

            //OurStopWatch.Enter("List host associated with all receive locations");

            //List host associated with all receive locations
            foreach (ReceivePort item in application.ReceivePorts)
            {
                foreach (Microsoft.BizTalk.ExplorerOM.ReceiveLocation itemLoc in item.ReceiveLocations)
                {
                    if (itemLoc.ReceiveHandler.Host.Type.ToString() == Property.HostInstanceType.InProcess.ToString())
                        hostName = itemLoc.ReceiveHandler.Host.Name;

                    if (!hostNames.ContainsKey(hostName))
                    {
                        hostNames.Add(hostName, false);
                    }
                }
            }
            //OurStopWatch.Exit();
            //OurStopWatch.Enter("List host associated with all orchestrations");

            //List host associated with all orchestrations
            foreach (BtsOrchestration item in application.Orchestrations)
            {
                if (item.Host != null)
                {
                    if (item.Host.Type.ToString() == Property.HostInstanceType.InProcess.ToString())
                        hostName = item.Host.Name;
                }
                if (!hostNames.ContainsKey(hostName))
                {
                    hostNames.Add(hostName, false);
                }
            }

            //OurStopWatch.Exit();
            //OurStopWatch.Enter("List host associated with all send ports (Non dynamic)");
            //List host associated with all send ports (Non dynamic)
            foreach (Microsoft.BizTalk.ExplorerOM.SendPort item in application.SendPorts)
            {
                if (!item.IsDynamic)
                {
                    if (item.PrimaryTransport.SendHandler.Host.Type.ToString() == Property.HostInstanceType.InProcess.ToString())
                        hostName = item.PrimaryTransport.SendHandler.Name;
                }                
                if (!hostNames.ContainsKey(hostName))
                {
                    hostNames.Add(hostName, false);
                }
            }

            //OurStopWatch.Exit();

            //OurStopWatch.Enter("List all host if dynamic send port present");
            //List all host if dynamic send port present
            foreach (Microsoft.BizTalk.ExplorerOM.SendPort item in application.SendPorts)
            {
                if (item.IsDynamic)
                {
                    //foreach (string hostNameDynamic in MSBTS_Host.GetAllInProcessHosts())
                    //{
                    //    if (!hostNames.ContainsKey(hostNameDynamic))
                    //    {
                    //        hostNames.Add(hostNameDynamic, item.IsDynamic);
                    //    }
                    //}
                    foreach (string hostNameDynamic in WmiHelper.GetSendHandlerHosts())
                    {
                        if (!hostNames.ContainsKey(hostNameDynamic))
                        {
                            hostNames.Add(hostNameDynamic, true);
                        }
                    }
                    break;
                }
            }
            //OurStopWatch.Exit();
            return hostNames;
        }
       
        #region Using WMI       
        /// <summary>
        /// Installs application on specified machine.
        /// </summary>
        /// <param name="computerName">Server on which to Uninstall application.</param>
        /// <param name="packageToInstall">Full path of the package to install.</param>
        /// ///<returns>Returns the result of execution as string.</returns>
        public static string Install(string computerName, string msiLocation, string targetDir)
        {
            string result = string.Empty;
            try
            {                
                string path = GenericHelper.CopyToTempFolder(computerName, msiLocation);
                result = WMIInstall.Install(computerName, path, targetDir);
                File.Delete(path);
                if (result == "0")
                {
                    result = String.Format("Installation done successfully with code {0} for computer {1}", result, computerName);
                }
                else
                {
                    result = String.Format("Installation done with error, with error message '{0}' and error code {1} for computer {2}", WMIInstallErrorCodeResolver.GetInstallErrorMessage(result), result, computerName);
                }
            }
            catch (Exception exe)
            {
                result = String.Format("WMI method error for computer {0}: {1}", computerName, exe.Message);
            }

            return result;
        }

        /// <summary>
        /// Uninstall application on specified machine.
        /// </summary>
        /// <param name="computerName">Server on which to Uninstall application.</param>
        /// <param name="applicationName">Application to uninstall.</param>
        /// <param name="identifyingNumber">Identifying number (GUID that uniquely identifies the application).</param>
        /// <param name="versionNumber">Application version number to uninstall.</param>
        /// <returns>Returns the result of execution as string.</returns>
        public static string Uninstall(string computerName, string applicationName, string identifyingNumber, string versionNumber)
        {
            string result = string.Empty;
            try
            {
                result = WMIUnInstall.Uninstall(computerName, applicationName, identifyingNumber, versionNumber);
                if (result == "0")
                {
                    result = String.Format("Application:{0} UnInstallation done successfully with code {1} for computer {2}",applicationName, result, computerName);
                }
                else
                {
                    result = String.Format("Application:{0} UnInstallation done with error with code {1} for computer {2}",applicationName, result, computerName);
                }
            }
            catch (Exception exe)
            {
                result = String.Format("Application:{0} WMI method error for computer {1}: {2}",applicationName, computerName, exe.Message);
            }

            return result;
        }

        #endregion
    }
}

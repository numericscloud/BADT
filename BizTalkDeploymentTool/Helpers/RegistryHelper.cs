using System;
using Microsoft.Win32;
using System.IO;
using System.Linq;

namespace BizTalkDeploymentTool.Helpers
{
    public static class RegistryHelper
    {
        /// <summary>
        /// Gets the GUID associated with any application on the specified machine.
        /// </summary>
        /// <param name="applicationName">The application for which the GUID is expected.</param>
        /// <param name="machineName">Server on which the GUID needs to be extracted from.</param>
        /// <returns>Returns the application GUID value (Unique to each application on a server).</returns> 
        public static string GetUninstallGuid(string applicationName, string computerName)
        {
            return GetUninstallGuidOfRemoteComputer(applicationName, computerName);
        }

        public static string GetInstallDate(string applicationGuid, string computerName)
        {
            return GetInstallDateRemoteComputer(applicationGuid, computerName);
        }

        public static string GetInstallDateRemoteComputer(string applicationGuid, string machineName)
        {
            string strdate = "";
            string val = GetKeyValue(applicationGuid, machineName, "InstallDate");
            return String.IsNullOrEmpty(val) ? strdate : DateTime.ParseExact(val, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture).ToString("D");
        }

        public static bool IsMsiInstalled(string applicationGuid, string machineName)
        {
            using (RegistryKey remoteBaseKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, machineName))
            using (RegistryKey key = remoteBaseKey.OpenSubKey(Constants._UNINSTALL_REGISTRY + applicationGuid, false))
            {
                return key != null ? true : false;
            }
        }

        public static string GetVersion(string applicationGuid, string machineName)
        {
            string defaultversion = "1.0.0.0";
            string val = GetKeyValue(applicationGuid, machineName, "DisplayVersion");
            return String.IsNullOrEmpty(val) ? defaultversion : val;

        }

        private static string GetKeyValue(string applicationGuid, string machineName, string subkey)
        {
            string value = "";
            using (RegistryKey remoteBaseKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, machineName))
            using (RegistryKey key = remoteBaseKey.OpenSubKey(Constants._UNINSTALL_REGISTRY + applicationGuid, false))
            {
                if (key != null)
                {
                    object version = key.GetValue(subkey);
                    if (version != null)
                    {
                        return version.ToString();
                    }
                }
                return value;
            }
        }

        public static bool IsDelayedAutostart(string serviceName, string machineName, string subkey)
        {
            bool value = false;
            using (RegistryKey remoteBaseKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, machineName))
            using (RegistryKey key = remoteBaseKey.OpenSubKey(Constants._SERVICES_REGISTRY + serviceName, false))
            {
                if (key != null)
                {
                    object version = key.GetValue(subkey);
                    if (version != null)
                    {
                        return version.ToString() == "1" ? true : false; ;
                    }
                }
                return value;
            }
        }

        public static bool IsGacInfoRegistered(string assemblyName, string machineName)
        {
            bool result = false;
            string[] splitName = assemblyName.Split(',');
            string searchName = splitName[0];

            using (RegistryKey remoteBaseKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, machineName, RegistryView.Registry64))
            using (RegistryKey key = remoteBaseKey.OpenSubKey(Constants._GACINFO_REGISTRY, false))
            {
                if (key != null)
                {
                    return key.GetValueNames().Any(s => s.Contains(searchName));
                }

            }
            return result;
        }

        /// <summary>
        /// Reads registry values.
        /// </summary>
        /// <param name="keyName">Registry Key.</param>
        /// <param name="valueName">Value which needs to be read from the Key.</param>
        /// <returns>Returns Value which needs to be read from the Key..</returns>  
        public static string GetRegistryEntry(string keyName, string valueName)
        {
            RegistryKey regKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            regKey = regKey.OpenSubKey(keyName);
            Object val = regKey.GetValue(valueName);
            return val.ToString();
        }

        /// <summary>
        /// Gets the GUID associated with any application on the specified machine.
        /// </summary>
        /// <param name="applicationName">The application for which the GUID is expected.</param>
        /// <param name="machineName">Server on which the GUID needs to be extracted from.</param>
        /// <returns>Returns the application GUID value (Unique to each application on a server).</returns>  
        public static string GetUninstallGuidOfRemoteComputer(string applicationName, string machineName)
        {
            string identifyingNumber = "";
            using (RegistryKey remoteBaseKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, machineName))
            using (RegistryKey uninstallFolders = remoteBaseKey.OpenSubKey(Constants._UNINSTALL_REGISTRY + applicationName, false))
            {
                if (uninstallFolders != null)
                {
                    string[] subkeys = uninstallFolders.GetSubKeyNames();
                    if (subkeys.Length > 0)
                    {
                        Guid guid;
                        if (Guid.TryParseExact(subkeys[0], "B", out guid))
                        {
                            identifyingNumber = subkeys[0];
                        }
                    }
                }
                return identifyingNumber;
            }
        }

        public static string GetRegistryKeyValue(string computerName, string registryKeyPath, RegistryHive registryHive, string name)
        {
            string value = null;

            using (RegistryKey remoteBaseKey = RegistryKey.OpenRemoteBaseKey(registryHive, computerName))
            {
                using (RegistryKey remoteKey = remoteBaseKey.OpenSubKey(registryKeyPath))
                {
                    value = remoteKey.GetValue(name).ToString();
                }
            }

            return value;
        }

        public static string GetSystemTempFolder(string computerName, string registryKeyPath, RegistryHive registryHive, string name)
        {
            string strpath = GetRegistryKeyValue(computerName, registryKeyPath, registryHive, name).Replace(":", "$");
            strpath = Path.Combine(string.Format("\\\\{0}\\{1}", computerName, strpath));
            return strpath;
        }

        public static string GetUninstallCommandFor(string productCode, string machineName)
        {
            productCode = string.Format("{0}{1}{2}", "{", productCode, "}");
            using (RegistryKey remoteBaseKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, machineName))
            using (RegistryKey uninstallFolders = remoteBaseKey.OpenSubKey(Constants._UNINSTALL_REGISTRY + productCode, false))
            {
                if (uninstallFolders != null)
                {
                    string displayName = (string)uninstallFolders.GetValue("DisplayName");
                    string displayVersion = (string)uninstallFolders.GetValue("DisplayVersion");
                    string uninstallCommand = (string)uninstallFolders.GetValue("UninstallString");
                    return uninstallCommand;
                }
            }
            return "";

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace BizTalkDeploymentTool.Helpers
{
    public class ServicesHelper
    {
        public enum ServiceStartModeExt
        {
            Automatic,
            DelayedAutomatic,
            Disabled,
            Manual,
            UNKNOWN
        }
        public ServiceController Properties { get; set; }
        public ServiceStartModeExt StartupType { get; set; }
        public ServicesHelper()
        {
        }
        public ServicesHelper(ServiceController serviceController)
        {
            Properties = serviceController;
            StartupType = this.GetServiceStartUpType(serviceController.ServiceName);
        }

        public ServiceStartModeExt GetServiceStartUpType(string serviceName)
        {
            string startupType = "";
            string wmiQuery = string.Format("SELECT StartMode FROM Win32_Service WHERE Name='{0}'", serviceName);
            var searcher = new ManagementObjectSearcher(wmiQuery);
            var results = searcher.Get();

            foreach (ManagementObject service in results)
            {
                startupType = service["StartMode"].ToString();
            }
            switch (startupType)
            {
                case "Auto":
                    bool startupTypeDelayed = RegistryHelper.IsDelayedAutostart(this.Properties.ServiceName, this.Properties.MachineName, "DelayedAutostart");

                    return startupTypeDelayed ? ServiceStartModeExt.DelayedAutomatic : ServiceStartModeExt.Automatic;
                default:
                    try
                    {
                        return (ServiceStartModeExt)Enum.Parse(typeof(ServiceStartModeExt), startupType);
                    }
                    catch (Exception)
                    {
                        return ServiceStartModeExt.UNKNOWN;
                    }

            }
            // return startupType;
        }


    }
}

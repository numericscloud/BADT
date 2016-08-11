using BizTalkDeploymentTool.Wmi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BizTalkDeploymentTool.Extensions
{
    public static class HostInstanceExtensions
    {
        public static HostInstance.ServiceStateValues RefreshedServiceState(this HostInstance hostInstance)
        {
            HostInstance.HostInstanceCollection hostInstances = HostInstance.GetInstances();
            var query = from HostInstance hi in hostInstances
                        where !hi.IsDisabled && hi.HostType != HostInstance.HostTypeValues.Isolated && hi.Name == hostInstance.Name                        
                        select hi;

            //foreach (string hostInstance in MSBTS_HostInstance.GetEnabledHostInstanceName(host.Key))

            return query.FirstOrDefault().ServiceState;
        }

    }
}

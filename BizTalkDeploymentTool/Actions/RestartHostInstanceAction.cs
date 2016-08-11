using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizTalkDeploymentTool.Wmi;
using System.Threading;
using BizTalkDeploymentTool.Extensions;

namespace BizTalkDeploymentTool.Actions
{
    public class RestartHostInstanceAction : BaseAction
    {
        public HostInstance HostInstance { get; private set; }
        public bool IsForDynamicPortOnly { get; private set; }
        private bool Start = false;
        private bool Stop = false;
        public override string DisplayName
        {
            get
            {
                return (this.IsForDynamicPortOnly ? "**" : "") + string.Format(Constants._RESTART_HOST, this.HostInstance.Name);
            }
        }

        public override bool IsAdminOnly
        {
            get
            {
                return false;
            }
        }

        public RestartHostInstanceAction(bool isForDynamicPortOnly, HostInstance hostInstance)
            : base()
        {
            this.HostInstance = hostInstance;
            this.IsForDynamicPortOnly = isForDynamicPortOnly;
        }

        public RestartHostInstanceAction(bool isForDynamicPortOnly, HostInstance hostInstance, bool start, bool stop)
            : base()
        {
            this.HostInstance = hostInstance;
            this.IsForDynamicPortOnly = isForDynamicPortOnly;
            this.Start = start;
            this.Stop = stop;
        }

        public override bool Execute(out string message)
        {
            bool result = false;
            if (this.Start)
            {
                return ExecuteStart(out message);
            }
            if (this.Stop)
            {
                return ExecuteStop(out message);
            }
            try
            {
                if (this.HostInstance.RefreshedServiceState() != Wmi.HostInstance.ServiceStateValues.Stopped)
                {
                    uint stop = this.HostInstance.Stop();
                    uint start = this.HostInstance.Start();

                    if (this.HostInstance.RefreshedServiceState() == Wmi.HostInstance.ServiceStateValues.Running)
                    {
                        message = string.Format("Restarted {0}", this.HostInstance.Name);
                        result = true;
                    }
                    else
                    {
                        message = string.Format("Restart failed for {0}. Current host instance status is - {1}", this.HostInstance.Name, this.HostInstance.ServiceState);
                        result = false;
                    }
                }
                else
                {
                    message = string.Format("Can not restart {0} because the current status of host instance is not 'Running'. Status is {1}", this.HostInstance.Name, this.HostInstance.ServiceState.ToString());
                    result = false;
                }
            }
            catch (Exception exe)
            {
                message = string.Format("Failure restarting host instance: {0}. Current status is: {1}, Error:{2}", this.HostInstance.Name, this.HostInstance.ServiceState, exe.Message);
            }
            return result;
        }

        private bool ExecuteStart(out string message)
        {
            bool result = false;
            try
            {
                if (this.HostInstance.RefreshedServiceState() == Wmi.HostInstance.ServiceStateValues.Stopped)
                {
                    uint start = this.HostInstance.Start();
                    message = string.Format("Started {0}", this.HostInstance.Name);
                    result = true;
                }
                else
                {
                    message = string.Format("Can not start {0} because the current status of host instance is already 'Running'. Status is {1}", this.HostInstance.Name, this.HostInstance.ServiceState.ToString());
                    result = false;
                }
            }
            catch (Exception exe)
            {
                message = string.Format("Failure starting host instance: {0}. Current status is: {1}, Error:{2}", this.HostInstance.Name, this.HostInstance.ServiceState, exe.Message);
            }
            return result;
        }
        private bool ExecuteStop(out string message)
        {
            bool result = false;
            try
            {
                if (this.HostInstance.RefreshedServiceState() == Wmi.HostInstance.ServiceStateValues.Running)
                {
                    uint start = this.HostInstance.Stop();
                    message = string.Format("Stopped {0}", this.HostInstance.Name);
                    result = true;
                }
                else
                {
                    message = string.Format("Can not stop {0} because the current status of host instance is already 'Stopped'. Status is {1}", this.HostInstance.Name, this.HostInstance.ServiceState.ToString());
                    result = false;
                }
            }
            catch (Exception exe)
            {
                message = string.Format("Failure stopping host instance: {0}. Current status is: {1}, Error:{2}", this.HostInstance.Name, this.HostInstance.ServiceState, exe.Message);
            }
            return result;
        }
    }
}

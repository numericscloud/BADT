using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizTalkDeploymentTool.Helpers;
using System.ServiceProcess;

namespace BizTalkDeploymentTool.Actions
{
    public class RestartServiceAction : BaseAction
    {
        public ServiceController ServiceController { get; private set; }
        private TimeSpan wait = new TimeSpan(0, 0, 30);

        public override string DisplayName
        {
            get
            {
                return string.Format(this.ServiceController.ServiceName);
            }
        }

        public override bool IsAdminOnly
        {
            get
            {
                return true;
            }
        }

        public RestartServiceAction(ServiceController serviceController)
            : base()
        {
            this.ServiceController = serviceController;
        }

        public override bool Execute(out string message)
        {
            bool result = false;
            try
            {
                foreach (ServiceController item in this.ServiceController.DependentServices)
                {
                    item.Refresh();
                    if (item.Status == ServiceControllerStatus.Running)
                    {
                        item.Stop();
                        item.WaitForStatus(ServiceControllerStatus.Stopped, wait);
                    }
                }
                this.ServiceController.Stop();
                this.ServiceController.WaitForStatus(ServiceControllerStatus.Stopped, wait);

                this.ServiceController.Start();
                this.ServiceController.WaitForStatus(ServiceControllerStatus.Running, wait);

                foreach (ServiceController item in this.ServiceController.DependentServices)
                {
                    item.Refresh();
                    if (item.Status == ServiceControllerStatus.Stopped)
                    {
                        item.Start();
                        item.WaitForStatus(ServiceControllerStatus.Running, wait);
                    }
                }
                result = true;
                message = "Service re-started successfully";
            }
            catch (Exception exe)
            {
                message = exe.Message;
                result = false;
            }
            finally
            {
                this.ServiceController.Close();
            }
            return result;
        }
    }
}

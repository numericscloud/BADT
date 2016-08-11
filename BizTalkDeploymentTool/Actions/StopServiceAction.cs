using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizTalkDeploymentTool.Helpers;
using System.ServiceProcess;

namespace BizTalkDeploymentTool.Actions
{
    public class StopServiceAction : BaseAction
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

        public StopServiceAction(ServiceController serviceController)
            : base()
        {
            this.ServiceController = serviceController;
        }

        public override bool Execute(out string message)
        {
            bool result = false;
            try
            {
                this.ServiceController.Stop();
                this.ServiceController.WaitForStatus(ServiceControllerStatus.Stopped, wait);
                result = true;
                message = "Service stopped successfully";
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

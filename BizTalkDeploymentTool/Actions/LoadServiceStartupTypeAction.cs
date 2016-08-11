using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizTalkDeploymentTool.Helpers;
using System.ServiceProcess;

namespace BizTalkDeploymentTool.Actions
{
    public class LoadServiceStartupTypeAction : BaseAction
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

        public LoadServiceStartupTypeAction(ServiceController serviceController)
            : base()
        {
            this.ServiceController = serviceController;
        }

        public override bool Execute(out string message)
        {
            bool result = false;
            try
            {
                ServicesHelper servicesHelper = new ServicesHelper(this.ServiceController);
                result = true;
                message = servicesHelper.StartupType.ToString();
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

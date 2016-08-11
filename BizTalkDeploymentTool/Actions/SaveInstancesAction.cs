using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizTalkDeploymentTool.Helpers;
using System.ServiceProcess;
using BizTalkDeploymentTool.Wmi;

namespace BizTalkDeploymentTool.Actions
{
    public class SaveInstancesAction : BaseAction
    {
        public string InstanceID { get; private set; }
        public string Path { get; private set; }
        public override string DisplayName
        {
            get
            {
                return string.Format(this.InstanceID);
            }
        }

        public override bool IsAdminOnly
        {
            get
            {
                return true;
            }
        }

        public SaveInstancesAction(string instanceID, string path)
            : base()
        {
            this.InstanceID = instanceID;
            this.Path = path;
        }

        public override bool Execute(out string message)
        {
            bool result = false;
            try
            {
                message = MSBTS_MessageInstance.SaveToFile(this.InstanceID, this.Path);
                result = true;
            }
            catch (Exception exe)
            {
                message = exe.Message;
                result = false;
            }
            return result;
        }
    }
}

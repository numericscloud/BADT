using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizTalkDeploymentTool.Helpers;

namespace BizTalkDeploymentTool.Actions
{

    public class ImportApplicationBindingAction : BaseAction
    {
        public string BindingLocation { get; private set; }
        public string ApplicationName { get; private set; }

        public override string DisplayName
        {
            get
            {
                return Constants._IMPORT_BINDING;
            }
        }

        public override bool IsAdminOnly
        {
            get
            {
                return true;
            }
        }

        public ImportApplicationBindingAction(string applicationName, string bindingLocation)
            : base()
        {
            this.BindingLocation  = bindingLocation;
            this.ApplicationName = applicationName;
        }

        public override bool Execute(out string message)
        {
            bool result = false;
            string resultMessage;
            if (string.IsNullOrEmpty(this.BindingLocation))
            {
                throw new ArgumentNullException("BindingLocation");
            }
            result = BTSTaskHelper.ImportBinding(this.ApplicationName, this.BindingLocation, out resultMessage); //_action.BizTalkEnvironmentName);
            if (result)
            {
                message = string.Format("Binding successfully imported from '{0}' binding. \r\n{1}", this.BindingLocation, resultMessage);               
            }
            else
            {
                message = "Binding can not be imported. \r\n" + resultMessage;
            }

            return result;
        }
    }
}

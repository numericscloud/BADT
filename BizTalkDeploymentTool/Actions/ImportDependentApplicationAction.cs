using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizTalkDeploymentTool.Helpers;

namespace BizTalkDeploymentTool.Actions
{

    public class ImportDependentApplicationAction : AppBaseAction
    {
        public string PackageLocation { get; private set; }
        public string TargetEnvironment { get; set; }

        public override string DisplayName
        {
            get
            {
                return Constants._IMPORT_APPLICATION;
            }
        }

        public override bool IsAdminOnly
        {
            get
            {
                return true;
            }
        }

        public ImportDependentApplicationAction(ApplicationInfo applicationInfo, string packageLocation, string targetEnv)
            : base(applicationInfo)
        {
            this.PackageLocation = packageLocation;
            this.TargetEnvironment = targetEnv;
        }

        public override bool Execute(out string message)
        {
            bool result = false;
            string resultMessage;
            if (this.TargetEnvironment == null)
            {
                throw new ArgumentNullException("TargetEnvironment");
            }
            result = BTSTaskHelper.ImportApp(this.ApplicationInfo.ApplicationName, this.PackageLocation, this.TargetEnvironment, out resultMessage); //_action.BizTalkEnvironmentName);
            if (result)
            {
                message = string.Format("Application successfully imported with '{0}' binding. \r\n{1}", this.TargetEnvironment, resultMessage);               
            }
            else
            {
                message = "Application can not be imported. \r\n" + resultMessage;
            }

            return result;
        }
    }
}

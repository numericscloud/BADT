using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BizTalkDeploymentTool.Helpers;
using BizTalkDeploymentTool.WMI;
using System.IO;
using System.Configuration;
using BizTalkDeploymentTool;
using System.Management;
using System.Threading;

namespace BizTalkDeploymentTool.Actions
{
    public class DeployBTDFMsiAction : BaseAction
    {

        string msbuildLoc = ConfigurationManager.AppSettings["MsBuild"];
        public string TargetEnvironment { get; set; }
        public string ServerName { get; set; }
        public string BTDFProjFileDirectory { get; set; }
        public Dictionary<string, string> Configurations { get; set; }
        public override bool IsAdminOnly
        {
            get
            {
                return true;
            }
        }
        public override string DisplayName
        {
            get
            {
                return string.Format(Constants._DEPLOYBTDF_APPLICATION, this.ServerName);
            }
        }

        public DeployBTDFMsiAction(string serverName)
            : base()
        {
            this.TargetEnvironment = null;
            this.Configurations = null;
            this.ServerName = serverName;
            this.BTDFProjFileDirectory = null;
        }

        public override bool Execute(out string message)
        {
            string batchFile = string.Empty;
            string batchFileLog = string.Empty;
            bool result = false;
            message = string.Empty;
            try
            {
                string uniqueName = Guid.NewGuid().ToString();
                batchFile = Path.Combine(GenericHelper.GetTempFolder(this.ServerName), uniqueName) + ".bat";
                batchFileLog = Path.Combine(GenericHelper.FormatPath(this.ServerName, this.BTDFProjFileDirectory), "DeployResults", "DeployResults.txt");
                string[] btdfProjfiles = Directory.GetFiles(this.BTDFProjFileDirectory, "*.btdfproj", SearchOption.AllDirectories);
                string[] targetEnvironmentfiles = Directory.GetFiles(this.BTDFProjFileDirectory, this.TargetEnvironment == null ? string.Empty : "*" + this.TargetEnvironment + "*", SearchOption.AllDirectories);                               
                this.TargetEnvironment = targetEnvironmentfiles.Count() > 0 ? GenericHelper.FormatPath(this.ServerName, targetEnvironmentfiles[0]) : string.Empty;
                CreateAndSaveBatchFile(GenericHelper.FormatPath(this.ServerName, btdfProjfiles[0]), batchFile, batchFileLog);
                result = Win32_Process.Create(this.ServerName, batchFile, out message);
                if (File.Exists(batchFileLog))
                {
                    message = message + File.ReadAllText(batchFileLog);
                }
            }
            catch (Exception exe)
            {
                message = exe.Message + "-- FAILED";
            }
            finally
            {
                if (File.Exists(batchFile))
                {
                    File.Delete(batchFile);
                }
            }
            result = (message.Contains("-- FAILED") || message.Contains("Build FAILED.")) ? false : true;
            return result;
        }

        private void CreateAndSaveBatchFile(string btdfPrjFile, string batchFile, string batchFileLog)
        {
            StringBuilder sb = new StringBuilder();
            string customConfig = GenericHelper.BuildParametersFromConfigurations(this.Configurations);
            sb.AppendLine(string.Format("{0} /p:DeployBizTalkMgmtDB={1};Configuration=Server;SkipUndeploy={2} /target:Deploy /l:FileLogger,Microsoft.Build.Engine;logfile={3} {4} /p:ENV_SETTINGS={5} {6}", msbuildLoc.Encode(), false.ToString(), true, batchFileLog.Encode(), btdfPrjFile.Encode(), this.TargetEnvironment == null ? string.Empty : this.TargetEnvironment.Encode(), customConfig));
            File.WriteAllText(batchFile, sb.ToString());
        }

    }
}

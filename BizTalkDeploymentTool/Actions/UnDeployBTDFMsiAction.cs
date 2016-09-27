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
    public class UnDeployBTDFMsiAction : BaseAction
    {

        string msbuildLoc = ConfigurationManager.AppSettings["MsBuild"];
        public string TargetEnvironment { get; set; }
        public string DeployBizTalkMgmtDb { get; set; }
        public string SkipUndeploy { get; set; }
        public string ServerName { get; set; }
        public string BTDFProjFileDirectory { get; set; }
        public override bool IsAdminOnly
        {
            get
            {
                return false;
            }
        }
        public override string DisplayName
        {
            get
            {
                return string.Format(Constants._UN_DEPLOYBTDF_APPLICATION, this.ServerName);
            }
        }

        public UnDeployBTDFMsiAction(string serverName, string deployBizTalkMgmtDb)
            : base()
        {
            this.TargetEnvironment = null;
            this.SkipUndeploy = null;
            this.DeployBizTalkMgmtDb = deployBizTalkMgmtDb;
            this.ServerName = serverName;
            this.BTDFProjFileDirectory = null;
        }

        public override bool Execute(out string message)
        {
            string tempMsiPath = string.Empty;
            string batchFile = string.Empty;
            string batchFileLog = string.Empty;
            bool result = false;
            string exceptionMessage = string.Empty;
            message = string.Empty;
            try
            {
                //tempMsiPath = GenericHelper.FormatPath(this.resourceInfo.ServerName, this.resourceInfo.ResourceName);
                string uniqueName = Guid.NewGuid().ToString();
                batchFile = Path.Combine(GenericHelper.GetTempFolder(this.ServerName), uniqueName) + ".bat";
                batchFileLog = Path.ChangeExtension(batchFile, "txt");
                string[] files = Directory.GetFiles(this.BTDFProjFileDirectory, "*.btdfproj", SearchOption.AllDirectories);

                string[] files1 = Directory.GetFiles(this.BTDFProjFileDirectory, this.TargetEnvironment == null ? string.Empty : "*" + this.TargetEnvironment + "*", SearchOption.AllDirectories);

                this.TargetEnvironment = files1.Count() > 0 ? GenericHelper.FormatPath(this.ServerName, files1[0]) : string.Empty;

                this.CreateAndSaveBatchFile(GenericHelper.FormatPath(this.ServerName, files[0]), batchFile, batchFileLog);
                result = Win32_Process.Create(this.ServerName, batchFile, out message);
                if (File.Exists(batchFileLog))
                {
                    message = message + File.ReadAllText(batchFileLog);
                }
            }
            catch (Exception exe)
            {
                exceptionMessage = exe.Message + "-- FAILED";
            }
            finally
            {
                if (File.Exists(tempMsiPath))
                {
                    File.Delete(tempMsiPath);
                }
                if (File.Exists(batchFile))
                {
                    //File.Delete(batchFile);
                }
                if (File.Exists(batchFileLog))
                {
                    // File.Delete(batchFileLog);
                }
            }
            message = result ? message : exceptionMessage;
            result = (message.Contains("-- FAILED") || message.Contains("Build FAILED.")) ? false : true;
            return result;
        }

        private void CreateAndSaveBatchFile(string btdfPrjFile, string batchFile, string batchFileLog)
        {
            //  /p:DeployBizTalkMgmtDB=true;Configuration=Server;SkipUndeploy=true /target:Deploy /l:FileLogger,Microsoft.Build.Engine;logfile="C:\Program Files\MyBizTalkApp\1.0\DeployResults\DeployResults.txt" "C:\Program Files\MyBizTalkApp\1.0\Deployment\MyBizTalkApp.btdfproj" /p:ENV_SETTINGS="C:\Program Files\MyBizTalkApp\1.0\Deployment\EnvironmentSettings\Exported_ProdSettings.xml"
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("{0} {1} /p:DeployBizTalkMgmtDB={2};Configuration=Server;/nologo /t:Undeploy /l:FileLogger,Microsoft.Build.Engine;logfile={3}", msbuildLoc.Encode(), btdfPrjFile.Encode(), this.DeployBizTalkMgmtDb, batchFileLog.Encode()));
            File.WriteAllText(batchFile, sb.ToString());
        }
    }
}

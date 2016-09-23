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
    public class InstallBTDFMsiAction : ResourceBaseAction
    {
        public string TargetDir { get; set; }
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
                return string.Format(Constants._INSTALL_APPLICATION, this.resourceInfo.ServerName);
            }
        }

        public InstallBTDFMsiAction(ResourceInfo resourceInfo)
            : base(resourceInfo)
        {
            this.TargetDir = null;
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
                tempMsiPath = GenericHelper.CopyToTempFolder(this.resourceInfo.ServerName, this.resourceInfo.ResourceName);
                string uniqueName = Guid.NewGuid().ToString();
                batchFile = Path.Combine(GenericHelper.GetTempFolder(this.resourceInfo.ServerName), uniqueName) + ".bat";
                batchFileLog = Path.ChangeExtension(batchFile, "txt");
                CreateAndSaveBatchFile(tempMsiPath, batchFile, batchFileLog);
                result = Win32_Process.Create(this.resourceInfo.ServerName, batchFile, out message);
                if (File.Exists(batchFileLog))
                {
                   message = message + File.ReadAllText(batchFileLog);
                }
                ExtractSettings(GenericHelper.FormatPath(this.resourceInfo.ServerName, this.TargetDir));               
            }
            catch (Exception exe)
            {
                exceptionMessage = exe.Message;
            }
            finally
            {
                if (File.Exists(tempMsiPath))
                {
                    File.Delete(tempMsiPath);
                }
                if (File.Exists(batchFile))
                {
                    File.Delete(batchFile);
                }
                if (File.Exists(batchFileLog))
                {
                    File.Delete(batchFileLog);
                }
            }
            message = result ? message : exceptionMessage;
            result = (message.Contains("Installation completed successfully")) ? true : false;
            return result;
        }

        private void ExtractSettings(string extractPath)
        {
            string[] files = Directory.GetFiles(extractPath, Constants._BTDF_SETTINGSFILENAMEFILTER, SearchOption.AllDirectories);
            string[] fileESE = Directory.GetFiles(extractPath, "EnvironmentSettingsExporter.exe", SearchOption.AllDirectories);

            if (fileESE.Count() > 0 && files.Count() > 0)
            {
                string settingFileDirectory = Path.GetDirectoryName(files[0]);
                string result = "";
                BTDFDeployHelper.ExecuteEnvironmentSettingsExporter(fileESE[0].Encode(), files[0].Encode() + " " + settingFileDirectory.Encode(), out result);
            }
            else
            {

            }
        }

        private void CreateAndSaveBatchFile(string msiToInstall, string batchFile, string batchFileLog)
        {            
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("{0} /i {1} /log {2} /qn INSTALLDIR={3}", "msiexec.exe", msiToInstall, batchFileLog, this.TargetDir.Encode()));
            File.WriteAllText(batchFile, sb.ToString());
        }
    }
}

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
    public class UnInstallBTDFMsiAction : BaseAction
    {
        public string UninstallString { get; set; }
        public string ProductName { get; set; }
        public string ServerName { get; set; }
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
                return string.Format(Constants._UNISTALL_APPLICATION,this.ProductName, this.ServerName);
            }
        }

        public UnInstallBTDFMsiAction(string uninstallString, string serverName, string productName)
            : base()
        {
            this.UninstallString = uninstallString;
            this.ServerName = serverName;
            this.ProductName = productName;
        }

        public override bool Execute(out string message)
        {
            string batchFile = string.Empty;
            string batchFileLog = string.Empty;
            bool result = false;
            string exceptionMessage = string.Empty;
            message = string.Empty;
            try
            {
                string uniqueName = Guid.NewGuid().ToString();
                batchFile = Path.Combine(GenericHelper.GetTempFolder(this.ServerName), uniqueName) + ".bat";
                batchFileLog = Path.ChangeExtension(batchFile, "txt");
                CreateAndSaveBatchFile(this.UninstallString, batchFile, batchFileLog);
                result = Win32_Process.Create(this.ServerName, batchFile, out message);
                if (File.Exists(batchFileLog))
                {
                    message = message + File.ReadAllText(batchFileLog);
                }
            }
            catch (Exception exe)
            {
                exceptionMessage = exe.Message;
            }
            finally
            {
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
            result = message.Contains("Removal completed successfully") ? true : false;
            return result;
        }

        private void CreateAndSaveBatchFile(string uninstallString, string batchFile, string batchFileLog)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("{0} /log {1} /qn", uninstallString, batchFileLog.Encode()));
            File.WriteAllText(batchFile, sb.ToString());
        }
    }
}

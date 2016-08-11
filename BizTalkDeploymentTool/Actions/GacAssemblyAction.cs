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
    public class GacAssemblyAction : ResourceBaseAction
    {
        
        string gacUtilLoc = ConfigurationManager.AppSettings["GacUtil"];
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
                return string.Concat(this.DisplayName);
            }
        }

        public GacAssemblyAction(ResourceInfo resourceInfo)
            : base(resourceInfo)
        {
          
        }

        public override bool Execute(out string message)
        {
            string tempAssemblyPath = string.Empty;
            string batchFile = string.Empty;
            string batchFileLog = string.Empty;
            bool result = false;
            string exceptionMessage = string.Empty;
            message = string.Empty;
            try
            {
                tempAssemblyPath = GenericHelper.CopyToTempFolder(this.resourceInfo.ServerName, this.resourceInfo.ResourceName);
                string uniqueName = Guid.NewGuid().ToString();
                batchFile = Path.Combine(GenericHelper.GetTempFolder(this.resourceInfo.ServerName), uniqueName) + ".bat";
                batchFileLog = Path.ChangeExtension(batchFile, "txt");
                CreateAndSaveBatchFile(gacUtilLoc.Encode(), tempAssemblyPath, batchFile, batchFileLog);
                result = Win32_Process.Create(this.resourceInfo.ServerName, batchFile, out message);
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
                if (File.Exists(tempAssemblyPath))
                {
                    File.Delete(tempAssemblyPath);
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
            return result;
        }

        private void CreateAndSaveBatchFile(string gacUtilLocation, string assembly, string batchFile, string batchFileLog)
        {            
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("{0} /if {1} > {2}", gacUtilLocation, assembly, batchFileLog));
            File.WriteAllText(batchFile, sb.ToString());
        }
    }
}

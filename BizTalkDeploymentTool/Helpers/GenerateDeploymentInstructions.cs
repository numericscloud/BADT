using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Word;
using System.Reflection;
using System.Diagnostics;
using System.IO;

using BizTalkDeploymentTool.Actions;
using BizTalkDeploymentTool.Helpers;

namespace BizTalkDeploymentTool
{
    public class GenerateDeploymentInstructions
    {
        private string InstructionsLocation = "";

        public GenerateDeploymentInstructions(string path)
        {
            this.InstructionsLocation = path;
        }

        public bool Generate(List<BaseAction> actionsForInstruction, string applicationName)
        {
            try
            {
                List<string> instructions = new List<string>();
               
                string bizTalkEnv = RegistryHelper.GetRegistryEntry(Constants._BIZTALK_INSTALLPATH_REGISTRY, "ProductName");

                StringBuilder deploymentInstructions = new StringBuilder();


                instructions.Add(string.Format("Actions needed to be performed in ''{0}'' environment", bizTalkEnv));
                instructions.Add("Stop BizSpy application");
                instructions.Add(string.Format("Actions to be performed for application: {0}", applicationName));
                instructions.Add("Use PRD binding while importing application");
                if (bizTalkEnv.Contains("2010"))
                {
                    instructions.Add(string.Format(@"Copy msi file from: \\intranet\dfsbu\790\IAM Shared Services\Development & Integration\Middleware\BizTalk\Deployment\2010\2_Latest_ACP {0} to: \\intranet\dfsbu\790\IAM Shared Services\Development & Integration\Middleware\BizTalk\Deployment\2010\1_Latest_PRD", Environment.NewLine));
                }
                else
                {
                    instructions.Add(string.Format(@"Copy msi file from: \\intranet\dfsbu\790\IAM Shared Services\Development & Integration\Middleware\BizTalk\Deployment\2013R2\1_Latest_ACP {0} to: \\intranet\dfsbu\790\IAM Shared Services\Development & Integration\Middleware\BizTalk\Deployment\2013R2\1_Latest_PRD", Environment.NewLine));
                }

                foreach (BaseAction actionForInstruction in actionsForInstruction)
                {
                    instructions.Add(actionForInstruction.DisplayName);
                }               
                instructions.Add("Create BizSpy template");
                instructions.Add("Start BizSpy application");

                for (int i = 0; i < instructions.Count; i++)
                {
                    deploymentInstructions.AppendLine(string.Format("{0}. {1}",i+1,instructions[i]));
                }

                System.IO.File.WriteAllText(this.InstructionsLocation, deploymentInstructions.ToString());

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

    }

    public static class DocumentExtension
    {
        public static void View(this Document doc, string path)
        {
            Process applicationStatus = new Process();
            applicationStatus.StartInfo.FileName = "winword.exe";
            applicationStatus.StartInfo.Arguments = path;//Path.Combine(doc.Path, doc.Name);
            applicationStatus.Start();
        }
    }
}


using Microsoft.BizTalk.ExplorerOM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using BizTalkDeploymentTool.Global;
using System.Windows.Forms;
using System.Xml;
using Microsoft.BizTalk.Deployment;
using Microsoft.BizTalk.MetaDataOM;

namespace BizTalkDeploymentTool.Helpers
{
    public class BtsOrchestrationHelper
    {
        public string AssemblyQualifiedName { get; set; }
        public bool AutoResumeSuspendedInstances { get; set; }
        public bool AutoSuspendRunningInstances { get; set; }
        public bool AutoTerminateInstances { get; set; }
        public string Description { get; set; }
        public string FullName { get; set; }
        public string Status { get; set; }
        public string OdxXmlView { get; set; }
        public string HostName { get; set; }
        public string Hostype { get; set; }
        public BtsOrchestrationHelper(BtsOrchestration orchestration)
        {
            AssemblyQualifiedName = orchestration.AssemblyQualifiedName;
            AutoResumeSuspendedInstances = orchestration.AutoResumeSuspendedInstances;
            AutoSuspendRunningInstances = orchestration.AutoSuspendRunningInstances;
            AutoTerminateInstances = orchestration.AutoTerminateInstances;
            Description = orchestration.Description;
            FullName = orchestration.FullName;
            Status = orchestration.Status.ToString();
            HostName = orchestration.Host!=null ? orchestration.Host.Name : "";
            Hostype = orchestration.Host!=null ? orchestration.Host.Type.ToString() : "";            
            OdxXmlView = this.GetXmlContent(orchestration);
        }

        private string GetXmlContent(BtsOrchestration orchestration)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                string xmlContent = string.Empty;
                string path = Microsoft.BizTalk.Gac.Gac.GetAssemblyPath(orchestration.BtsAssembly.Name);
                BizTalkAssembly assembly1 = new BizTalkAssembly();
                Microsoft.BizTalk.Deployment.Assembly.BtsAssemblyManager manager = new Microsoft.BizTalk.Deployment.Assembly.BtsAssemblyManager(path, assembly1);
                IBizTalkAssembly ass = (IBizTalkAssembly)manager.AssemblyBase;
                IEnumerator orList = ass.Orchestrations;
                while (orList.MoveNext())
                {
                    IBizTalkOrchestration or = (IBizTalkOrchestration)orList.Current;
                    xmlContent = or.XmlContent;
                    xmlContent = xmlContent.Replace("'", "\"");

                    sb.AppendLine("#if __DESIGNER_DATA");
                    sb.AppendLine("#error Do not define __DESIGNER_DATA.");
                    sb.AppendLine(xmlContent);
                    sb.AppendLine("#endif // __DESIGNER_DATA");
                }
            }
            catch (Exception exe)
            {
                sb.Append("Can not load Odx content: " + exe.Message);
            }
            return sb.ToString();
        }

       /* public Orchestration GetOrchestration()
        {
            BizTalkInstallation ins = new BizTalkInstallation();
            ins.Server = GlobalProperties.MgmtDBServer;
            ins.MgmtDatabaseName = GlobalProperties.MgmtDBName;
            Orchestration orch = ins.GetOrchestration(this.btsOrchestration.BtsAssembly.DisplayName , this.btsOrchestration.FullName);
            //XmlDocument xdoc = orch.GetShapeMetricsAsDom();
            return orch;
            
           // Bitmap orchImage = orc.GetImage();
           // return orchImage;
        }*/
    }
}


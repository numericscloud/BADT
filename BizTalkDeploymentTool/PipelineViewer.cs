using BizTalkDeploymentTool.Global;
using BizTalkDeploymentTool.Helpers;
using Microsoft.BizTalk.ExplorerOM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Xsl;

namespace BizTalkDeploymentTool
{
    public partial class PipelineViewer : Form
    {
        private string PipelineData = null;
        private string PipelineXml = null;
        private Pipeline BtsPipeline = null;
        public PipelineViewer()
        {
            InitializeComponent();
        }
        public PipelineViewer(Pipeline pipeline)
        {
            InitializeComponent();
            this.BtsPipeline = pipeline;
            this.PipelineData = this.GetPipelineData();
            this.PipelineXml = this.GetPipelineXml();
        }

        public void LoadView()
        {
            webBrowser1.DocumentText = GenericHelper.TransformData("BizTalkDeploymentTool.EmbeddedResources.Pipeline.xslt", this.PipelineXml).Replace("${PROCESS_FLOW}", GenericHelper.TransformData("BizTalkDeploymentTool.EmbeddedResources.PipelineDisplay.xslt", this.PipelineData));
        }

        private string GetPipelineData()
        {
            Microsoft.Services.Tools.BizTalkOM.BizTalkInstallation ins = new Microsoft.Services.Tools.BizTalkOM.BizTalkInstallation();
            ins.Server = GlobalProperties.MgmtDBServer;
            ins.MgmtDatabaseName = GlobalProperties.MgmtDBName;
            Microsoft.Services.Tools.BizTalkOM.Pipeline pipeLine = new Microsoft.Services.Tools.BizTalkOM.Pipeline(this.BtsPipeline.FullName);
            pipeLine.Load(this.BtsPipeline.Application.BtsCatalogExplorer, this.BtsPipeline);
            return pipeLine.ViewData;
        }
        public Microsoft.Services.Tools.BizTalkOM.Pipeline GetPipeline()
        {
            Microsoft.Services.Tools.BizTalkOM.BizTalkInstallation ins = new Microsoft.Services.Tools.BizTalkOM.BizTalkInstallation();
            ins.Server = GlobalProperties.MgmtDBServer;
            ins.MgmtDatabaseName = GlobalProperties.MgmtDBName;
            Microsoft.Services.Tools.BizTalkOM.Pipeline pipeLine = new Microsoft.Services.Tools.BizTalkOM.Pipeline(this.BtsPipeline.FullName);
            pipeLine.Load(this.BtsPipeline.Application.BtsCatalogExplorer, this.BtsPipeline);
            return pipeLine;
          
        }
        private string GetPipelineXml()
        {
            Microsoft.Services.Tools.BizTalkOM.BizTalkInstallation ins = new Microsoft.Services.Tools.BizTalkOM.BizTalkInstallation();
            ins.Server = GlobalProperties.MgmtDBServer;
            ins.MgmtDatabaseName = GlobalProperties.MgmtDBName;
            Microsoft.Services.Tools.BizTalkOM.Pipeline pipeLine = new Microsoft.Services.Tools.BizTalkOM.Pipeline(this.BtsPipeline.FullName);
            pipeLine.Load(this.BtsPipeline.Application.BtsCatalogExplorer, this.BtsPipeline);
            return pipeLine.GetXml();
        }

    }
}

using BizTalkDeploymentTool.Global;
using BizTalkDeploymentTool.Helpers;
using Microsoft.BizTalk.ExplorerOM;
using Microsoft.RuleEngine;
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
    public partial class PolicyViewer : Form
    {
        private RuleSetInfo BtsRuleSetInfo = null;
        public PolicyViewer()
        {
            InitializeComponent();
        }
        public PolicyViewer(RuleSetInfo ruleSet)
        {
            InitializeComponent();
            this.BtsRuleSetInfo = ruleSet;
        }

        public void LoadView()
        {
            webBrowser1.DocumentText = this.TransformData("BizTalkDeploymentTool.EmbeddedResources.Policy.xslt", BreHelper.GetRules(this.BtsRuleSetInfo)).Replace("${PROCESS_FLOW}", this.TransformData("BizTalkDeploymentTool.EmbeddedResources.PipelineDisplay.xslt", this.PipelineData));
        }


        private string TransformData(string xsltResource, string inputData)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(inputData);
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            XmlTextReader xmlTextReader = new XmlTextReader(executingAssembly.GetManifestResourceStream(xsltResource));
            XslCompiledTransform orchCodeTransform = new XslCompiledTransform();
            orchCodeTransform.Load(xmlTextReader);
            using (var writer = new StringWriter())
            {
                orchCodeTransform.Transform(xDoc.CreateNavigator(), null, writer);
                return writer.ToString();
            }
        }
    }
}

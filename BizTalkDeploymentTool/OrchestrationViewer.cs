using BizTalkDeploymentTool.Global;
using BizTalkDeploymentTool.Helpers;
using Microsoft.BizTalk.ExplorerOM;
using Microsoft.Services.Tools.BizTalkOM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.Linq;
using System.Reflection;
using System.IO;

namespace BizTalkDeploymentTool
{
    public partial class OrchestrationViewer : Form
    {
       // private Orchestration OrchToView = null;
        private BtsOrchestration BtsOrchestration = null;
        public OrchestrationViewer()
        {
            InitializeComponent();
        }
        public OrchestrationViewer(BtsOrchestration orchestration)
        {
            InitializeComponent();
            this.BtsOrchestration = orchestration;
            this.OrchToView = this.GetOrchestration();
        }

       /* public Orchestration GetOrchestration()
        {
            BizTalkInstallation ins = new BizTalkInstallation();
            ins.Server = GlobalProperties.MgmtDBServer;
            ins.MgmtDatabaseName = GlobalProperties.MgmtDBName;
            Orchestration orch = ins.GetOrchestration(this.BtsOrchestration.BtsAssembly.DisplayName, this.BtsOrchestration.FullName);
            return orch;
        }*/
        public void LoadView()
        {
            pictureBox1.Image = this.OrchToView.GetImage();
            propertyGrid1.SelectedObject = this.OrchToView;
        }

        private void OrchestrationViewer_Load(object sender, EventArgs e)
        {
            this.Height = this.panel1.Height = this.pictureBox1.Height = pictureBox1.Image.Height;
            this.Width = this.panel1.Width = this.pictureBox1.Width = pictureBox1.Image.Width;
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            panel1.Focus();
        }

        private void propertyGrid1_SelectedGridItemChanged(object sender, SelectedGridItemChangedEventArgs e)
        {
            string text = this.BtsOrchestration.FullName;
            if (e.OldSelection != null)
            {
                GridItem selectedItem = propertyGrid1.SelectedGridItem;
                if (selectedItem != null && selectedItem.GridItemType == GridItemType.Property && selectedItem.Value!= null)
                {
                    text = selectedItem.Value.ToString();
                }
            }
           /* if (text.IsXml())
            {
                XDocument xDoc = XDocument.Parse(text);
                text = xDoc.ToString();
            }*/
             richTextBox1.Text = text;
           /* if (text.IsXml())
            {
                webBrowser1.DocumentStream = text.DocumentXml();
            }
            else
            {
                webBrowser1.DocumentText = text;
            }*/

            HighlightColors.HighlightRTF(richTextBox1);
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            webBrowser2.DocumentText = GetOrchCode();
        }

        private string GetOrchCode()
        {
            XmlDocument xDoc= new XmlDocument();
            xDoc.LoadXml(this.OrchToView.ArtifactData);
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            XmlTextReader xmlTextReader = new XmlTextReader(executingAssembly.GetManifestResourceStream("BizTalkDeploymentTool.EmbeddedResources.OrchCode.xslt"));
            XslCompiledTransform orchCodeTransform = new XslCompiledTransform();
            orchCodeTransform.Load(xmlTextReader);
            XsltArgumentList args = new XsltArgumentList();
            args.AddParam("OrchName", "", this.OrchToView.Name);
           using(var writer = new StringWriter())
           {
               orchCodeTransform.Transform(xDoc.CreateNavigator(), args, writer);
               return writer.ToString();
           }
            
        }
    }
}

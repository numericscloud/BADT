using BizTalkDeploymentTool.Actions;
using BizTalkDeploymentTool.Helpers;
using BizTalkDeploymentTool.Wmi;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BizTalkDeploymentTool.Extensions;
using BizTalkDeploymentTool.Report;
using System.IO;
using System.Diagnostics;
using System.Configuration;
using System.Web;
using System.Threading;
using Microsoft.BizTalk.MetaDataOM;
using BizTalkDeploymentTool.Global;
using System.Collections;
using Microsoft.BizTalk.Deployment.Assembly;
using Microsoft.BizTalk.Deployment;
using Microsoft.RuleEngine;
using Microsoft.BizTalk.ExplorerOM;
using BizTalkDeploymentTool.ArtifactView;

namespace BizTalkDeploymentTool
{
    public partial class ApplicationArtifactsView : Form
    {
        string formText;
        ThreadProcessor threadProcessor = null;
        ExplorerOMHelper explorerHelper = new ExplorerOMHelper(GlobalProperties.MgmtDBServer, GlobalProperties.MgmtDBName);
        List<string> serverList = GlobalProperties.MessagingServers;
        ApplicationCollection appCollection = new ApplicationCollection();
        List<BreRuleSetInfo> listPolicy = new List<BreRuleSetInfo>();
        public enum FormStateEnum
        {
            Initial,
            NotProcessing,
            Processing
        }

        private FormStateEnum _formState = FormStateEnum.Initial;
        private FormStateEnum FormState
        {
            get
            {
                return _formState;
            }

            set
            {
                if (_formState != value)
                {
                    UpdateFormState(value);
                }
                _formState = value;
            }
        }

        private void UpdateFormState(FormStateEnum formState)
        {
            switch (formState)
            {
                case FormStateEnum.Initial:
                    UpdateCursor(Cursors.Default);
                    comboBoxAppList.Enabled = true;
                    break;

                case FormStateEnum.NotProcessing:
                    UpdateCursor(Cursors.Default);
                    break;

                case FormStateEnum.Processing:
                    UpdateCursor(Cursors.WaitCursor);
                    comboBoxAppList.Enabled = false;
                    break;

            }
        }

        private void UpdateCursor(Cursor cursor)
        {
            this.Cursor = cursor;
        }

        public ApplicationArtifactsView()
        {
            InitializeComponent();
        }


        private void ApplicationAssemblies_Load(object sender, EventArgs e)
        {
            LoadApplications();
            formText = this.Text;
            HighlightColors.HighlightRTF(richTextBox1);
        }

        private void ClearView()
        {
            treeView1.Nodes.Clear();
            richTextBox1.Text = "";
            propertyGrid2.SelectedObject = null;
        }
        private void LoadAppTreeView()
        {
            string applicationName = comboBoxAppList.Text;
            Microsoft.BizTalk.ExplorerOM.Application application = appCollection[applicationName];
            ClearView();
            if (application != null)
            {
                TreeNode parentNode = treeView1.Nodes.Add("Application");
                parentNode.Tag = application;
                parentNode.ImageIndex = 0;
                parentNode.SelectedImageIndex = 0;
                if (application.Assemblies.Count > 0)
                {
                    TreeNode assembliesNode = parentNode.Nodes.Add("Assemblies");
                    assembliesNode.ImageIndex = 1;
                    assembliesNode.SelectedImageIndex = 1;

                    var qassembly = from assembly in application.Assemblies.Cast<Microsoft.BizTalk.ExplorerOM.BtsAssembly>()
                                    orderby assembly.DisplayName
                                    select assembly;

                    foreach (Microsoft.BizTalk.ExplorerOM.BtsAssembly assembly in qassembly.ToList())
                    {
                        TreeNode assemblyNode = assembliesNode.Nodes.Add(assembly.DisplayName);
                        assemblyNode.Tag = assembly;
                        assemblyNode.ImageIndex = 1;
                        assemblyNode.SelectedImageIndex = 1;
                        // Load Orchestrations
                        if (assembly.Orchestrations.Count > 0)
                        {
                            TreeNode orchestrationsNode = assemblyNode.Nodes.Add("Orchestrations");
                            orchestrationsNode.ImageIndex = 2;
                            orchestrationsNode.SelectedImageIndex = 2;
                            var q = from orchestration in assembly.Orchestrations.Cast<Microsoft.BizTalk.ExplorerOM.BtsOrchestration>()
                                    orderby orchestration.FullName
                                    select orchestration;


                            foreach (Microsoft.BizTalk.ExplorerOM.BtsOrchestration orchestration in q.ToList())
                            {
                                TreeNode node = orchestrationsNode.Nodes.Add(orchestration.FullName);
                               
                                node.ImageIndex = 2;
                                node.SelectedImageIndex = 2;
                               //BtsOrchestrationHelper orch = new BtsOrchestrationHelper(orchestration);
                               node.Tag = orchestration;

                   
                            }
                        }

                        // Load Schemas
                        if (assembly.Schemas.Count > 0)
                        {
                            TreeNode schemasNode = assemblyNode.Nodes.Add("Schemas");
                            schemasNode.ImageIndex = 6;
                            schemasNode.SelectedImageIndex = 6;
                            var q = from schema in assembly.Schemas.Cast<Microsoft.BizTalk.ExplorerOM.Schema>()
                                    orderby schema.FullName
                                    select schema;

                            foreach (Microsoft.BizTalk.ExplorerOM.Schema schema in q.ToList())
                            {
                                string nodeName = string.IsNullOrEmpty(schema.RootName) ? schema.FullName : string.Format("{0}+{1}", schema.FullName, schema.RootName);
                                TreeNode node = schemasNode.Nodes.Add(nodeName);
                                node.Tag = schema;
                                node.ImageIndex = 6;
                                node.SelectedImageIndex = 6;
                            }
                        }

                        // Load Pipelines
                        if (assembly.Pipelines.Count > 0)
                        {
                            TreeNode pipelinesNode = assemblyNode.Nodes.Add("Pipelines");
                            pipelinesNode.ImageIndex = 5;
                            pipelinesNode.SelectedImageIndex = 5;
                            var q = from pipeline in assembly.Pipelines.Cast<Microsoft.BizTalk.ExplorerOM.Pipeline>()
                                    orderby pipeline.FullName
                                    select pipeline;

                            foreach (Microsoft.BizTalk.ExplorerOM.Pipeline pipeline in q.ToList())
                            {
                                TreeNode node = pipelinesNode.Nodes.Add(pipeline.FullName);
                                PipelineInfo pipelineTag = new PipelineInfo(pipeline);
                                node.Tag = pipelineTag;
                                node.ImageIndex = 5;
                                node.SelectedImageIndex = 5;
                            }
                        }


                        // Load transforms
                        if (assembly.Transforms.Count > 0)
                        {
                            TreeNode transformsNode = assemblyNode.Nodes.Add("Maps");
                            transformsNode.ImageIndex = 3;
                            transformsNode.SelectedImageIndex = 3;
                            var q = from transform in assembly.Transforms.Cast<Microsoft.BizTalk.ExplorerOM.Transform>()
                                    orderby transform.FullName
                                    select transform;

                            foreach (Microsoft.BizTalk.ExplorerOM.Transform transform in q.ToList())
                            {
                                TreeNode node = transformsNode.Nodes.Add(transform.FullName);
                                node.Tag = transform;
                                node.ImageIndex = 3;
                                node.SelectedImageIndex = 3;

                            }
                        }
                    }
                }
                if (listPolicy.Count > 0)
                {
                    TreeNode policyNode = parentNode.Nodes.Add("Policies");
                    policyNode.Tag = listPolicy;
                    policyNode.ImageIndex = 4;
                    policyNode.SelectedImageIndex = 4;
                    foreach (BreRuleSetInfo item in listPolicy)
                    {
                        TreeNode ruleNode = policyNode.Nodes.Add(string.Format("{0} - Version {1}.{2}", item.Name, item.MajorRevision.ToString(), item.MinorRevision.ToString()));

                        ruleNode.Tag = item;
                        ruleNode.ImageIndex = 4;
                        ruleNode.SelectedImageIndex = 4;
                    }
                }
            }
            ExpandToLevel(this.treeView1.Nodes, 2);
        }

        void ExpandToLevel(TreeNodeCollection nodes, int level)
        {
            if (level > 0)
            {
                foreach (TreeNode node in nodes)
                {
                    node.Expand();
                    ExpandToLevel(node.Nodes, level - 1);
                }
            }
        }

        private void DisplayError(string message)
        {
            MessageBox.Show(message, "BTDT", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void comboBxAppList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FormState = FormStateEnum.Processing;
            this.LoadAppTreeView();
            this.FormState = FormStateEnum.Initial;

        }

        private void LoadApplications()
        {
            appCollection = explorerHelper.GetApplicationCollection();
            List<string> appList = explorerHelper.GetApplicationList(appCollection);
            comboBoxAppList.Items.AddRange(RemoveSystemApplication(appList).ToArray());
        }

        private List<string> RemoveSystemApplication(List<string> applicationNameList)
        {
            applicationNameList.Remove("BizTalk.System");
            applicationNameList.Remove("BizTalk Application 1");
            applicationNameList.Remove("BizTalk EDI Application");
            return applicationNameList;
        }

        private void DeploymentHealthCheck_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (threadProcessor != null && threadProcessor.IsRunning)
            {
                DialogResult result = DisplayQuestion("Actions are still executing. Do you want to close ?");
                e.Cancel = (result == DialogResult.Cancel);
            }
        }
        private DialogResult DisplayQuestion(string message)
        {
            return MessageBox.Show(message, "BTDT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }

        private void DisplayMessage(string message)
        {
            MessageBox.Show(message, "BTDT", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                PopulatePropertyGrid(e.Node.Tag);
            }
            catch (Exception exe)
            {
                DisplayError(exe);
            }
        }
        private void PopulatePropertyGrid(object obj)
        {
            if (obj != null)
            {
                TypeDescriptor.AddAttributes(obj, new Attribute[] { new ReadOnlyAttribute(true) });
            }
            propertyGrid2.SelectedObject = obj;
        }
        private void DisplayError(Exception ex)
        {
            DisplayError(ex.Message);
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeView1.SelectedNode = e.Node;
        }

        private void propertyGrid2_SelectedGridItemChanged(object sender, SelectedGridItemChangedEventArgs e)
        {
            string text = "";//treeView1.SelectedNode.Text;
            if (e.OldSelection != null)
            {
                GridItem selectedItem = propertyGrid2.SelectedGridItem;
                if (selectedItem != null && selectedItem.GridItemType == GridItemType.Property && selectedItem.Value != null)
                {
                    text = selectedItem.Value.ToString();
                }
            }

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

        private void propertyGrid2_Click(object sender, EventArgs e)
        {
        }

    

       

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                RuleSetInfo ruleSetInfo = this.treeView1.SelectedNode.Tag as RuleSetInfo;
                //Viewer viewer = new Viewer(GenericHelper.TransformData("BizTalkDeploymentTool.EmbeddedResources.Policy.xslt", BreHelper.GetRules(ruleSetInfo)));
                Viewer viewer = new Viewer(BreHelper.GetRules(ruleSetInfo));
                viewer.ShowDialog();
            }
            catch (Exception exe)
            {
                DisplayError(exe);
            }
        }

        //private void treeView1_DrawNode(object sender, DrawTreeNodeEventArgs e)
        //{
        //    if (e.Node == null) return;

        //    // if treeview's HideSelection property is "True", 
        //    // this will always returns "False" on unfocused treeview
        //    var selected = (e.State & TreeNodeStates.Selected) == TreeNodeStates.Selected;
        //    var unfocused = !e.Node.TreeView.Focused;

        //    // we need to do owner drawing only on a selected node
        //    // and when the treeview is unfocused, else let the OS do it for us
        //    if (selected && unfocused)
        //    {
        //        var font = e.Node.NodeFont ?? e.Node.TreeView.Font;
        //        e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
        //        TextRenderer.DrawText(e.Graphics, e.Node.Text, font, e.Bounds, SystemColors.HighlightText, TextFormatFlags.GlyphOverhangPadding);
        //    }
        //    else
        //    {
        //        e.DrawDefault = true;
        //    }
        //}



    }
}

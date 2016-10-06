using BizTalkDeploymentTool.ArtifactView;
using BizTalkDeploymentTool.Global;
using BizTalkDeploymentTool.Helpers;
using BizTalkDeploymentTool.Extensions;
using BizTalkDeploymentTool.Actions;
using BizTalkDeploymentTool.Wmi;
using BizTalkDeploymentTool.Report;
using Microsoft.RuleEngine;
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
using System.Security.Principal;
using System.IO;

namespace BizTalkDeploymentTool
{
    public partial class BizTalkApplicationDeployment : Form
    {
        bool IsapplicationNodeExpanded = false;
        bool IsartifactsNodeExpanded = false;
        bool IsIISNodeExpanded = false;
        bool IsMsiDeployInAction = false;
        bool IsBTDFMsiDeployInAction = false;
        bool IsHostInstanceRestartInAction = false;
        ExplorerOMHelper explorerHelper = new ExplorerOMHelper(GlobalProperties.MgmtDBServer, GlobalProperties.MgmtDBName);
        List<BreRuleSetInfo> listPolicy = new List<BreRuleSetInfo>();
        Microsoft.BizTalk.ExplorerOM.ApplicationCollection appCollection = new Microsoft.BizTalk.ExplorerOM.ApplicationCollection();

        BizTalkHostInstances btHostInstances = new BizTalkHostInstances();
        MsiDeploy msiDeploy = new MsiDeploy();
        BTDFMsiDeploy btdfmsiDeploy = new BTDFMsiDeploy();

        RetstartHostInstances hInstance = new RetstartHostInstances();
        SSOAdminInspector ssoAdminInspector = new SSOAdminInspector();
        public BizTalkApplicationDeployment()
        {
            InitializeComponent();
            treeViewBizTalkApplications.DoubleBuffered(true);
            appCollection = explorerHelper.GetApplicationCollection();
            msiDeploy.ExecutionStarted += new EventHandler(MsiDeployStarted_Eventhandler);
            msiDeploy.ExecutionComplete += new EventHandler(MsiDeployComplete_Eventhandler);
            btHostInstances.ExecutionStarted += new EventHandler(HostInstancesStarted_Eventhandler);
            btHostInstances.ExecutionComplete += new EventHandler(HostInstancesComplete_Eventhandler);

            btdfmsiDeploy.ExecutionStarted += new EventHandler(BtdfMsiDeployStarted_Eventhandler);
            btdfmsiDeploy.ExecutionComplete += new EventHandler(BtdfMsiDeployComplete_Eventhandler);
        }

        private Microsoft.BizTalk.ExplorerOM.ApplicationCollection RefreshAppCollection()
        {
            appCollection = explorerHelper.GetApplicationCollection();
            return appCollection;
        }

        public void MsiDeployStarted_Eventhandler(object sender, EventArgs e)
        {
            IsMsiDeployInAction = true;
            var treeNode = treeViewBizTalkApplications.FlattenTree()
                     .Where(n => n.Text == Constants._MSI_DEPLOY_TREENODE_TEXT)
                     .ToList()[0];
            treeNode.ImageIndex = 20;
            treeNode.SelectedImageIndex = 20;
        }
        public void MsiDeployComplete_Eventhandler(object sender, EventArgs e)
        {
            IsMsiDeployInAction = false;
            var treeNode = treeViewBizTalkApplications.FlattenTree()
                   .Where(n => n.Text == Constants._MSI_DEPLOY_TREENODE_TEXT)
                   .ToList()[0];
            treeNode.ImageIndex = 19;
            treeNode.SelectedImageIndex = 19;
        }

        public void BtdfMsiDeployStarted_Eventhandler(object sender, EventArgs e)
        {
            IsBTDFMsiDeployInAction = true;
            var treeNode = treeViewBizTalkApplications.FlattenTree()
                     .Where(n => n.Text == Constants._BTDF_MSI_DEPLOY_TREENODE_TEXT)
                     .ToList()[0];
            treeNode.ImageIndex = 20;
            treeNode.SelectedImageIndex = 20;
        }
        public void BtdfMsiDeployComplete_Eventhandler(object sender, EventArgs e)
        {
            IsBTDFMsiDeployInAction = false;
            var treeNode = treeViewBizTalkApplications.FlattenTree()
                   .Where(n => n.Text == Constants._BTDF_MSI_DEPLOY_TREENODE_TEXT)
                   .ToList()[0];
            treeNode.ImageIndex = 19;
            treeNode.SelectedImageIndex = 19;
        }

        public void HostInstancesStarted_Eventhandler(object sender, EventArgs e)
        {
            IsHostInstanceRestartInAction = true;
            var treeNode = treeViewBizTalkApplications.FlattenTree()
                     .Where(n => n.Text == Constants._HOST_INSTANCE_TREENODE_TEXT)
                     .ToList()[0];
            treeNode.ImageIndex = 20;
            treeNode.SelectedImageIndex = 20;
        }
        public void HostInstancesComplete_Eventhandler(object sender, EventArgs e)
        {
            IsHostInstanceRestartInAction = false;
            var treeNode = treeViewBizTalkApplications.FlattenTree()
                   .Where(n => n.Text == Constants._HOST_INSTANCE_TREENODE_TEXT)
                   .ToList()[0];
            treeNode.ImageIndex = 7;
            treeNode.SelectedImageIndex = 7;
        }

        public static bool IsAdministrator()
        {
            return (new WindowsPrincipal(WindowsIdentity.GetCurrent()))
                    .IsInRole(WindowsBuiltInRole.Administrator);
        }

        private void BizTalkApplicationAdministration_Load(object sender, EventArgs e)
        {
            string IsAdminText = IsAdministrator() ? " (Administrator)" : " (Non-Administrator)";
            this.Text = this.Text + IsAdminText;
            LoadAdministration();
        }

        private void LoadAdministration()
        {
            this.FormState = FormStateEnum.Processing;
            appCollection = explorerHelper.GetApplicationCollection();
            LoadTreeViewApplications();
            ExpandToLevel(treeViewBizTalkApplications.Nodes, 2);
            this.FormState = FormStateEnum.NotProcessing;
        }


        #region Handling the Form View State
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
                    IsapplicationNodeExpanded = false;
                    IsIISNodeExpanded = false;
                    IsartifactsNodeExpanded = false;
                    UpdateCursor(Cursors.Default);
                    break;

                case FormStateEnum.NotProcessing:
                    UpdateCursor(Cursors.Default);
                    break;

                case FormStateEnum.Processing:

                    UpdateCursor(Cursors.WaitCursor);
                    break;

            }
        }

        private void UpdateCursor(Cursor cursor)
        {
            if (this.InvokeRequired)
            {
                // We're on a thread other than the GUI thread
                this.Invoke(new MethodInvoker(() => UpdateCursor(cursor)));
                return;
            }

            this.Cursor = cursor;
        }
        #endregion

        private void LoadTreeViewApplications()
        {
            treeViewBizTalkApplications.Nodes.Clear();
            TreeNode parentNode = treeViewBizTalkApplications.Nodes.Add("BizTalk Application Administration");
            parentNode.ContextMenuStrip = contextMenuStrip3;
            parentNode.ImageIndex = 14;
            parentNode.SelectedImageIndex = 14;
            TreeNode biztalkGroupNode = parentNode.Nodes.Add(string.Format("BizTalk Group [{0}:{1}]", GlobalProperties.MgmtDBServer, GlobalProperties.MgmtDBName));
            biztalkGroupNode.ImageIndex = 21;//8;
            biztalkGroupNode.SelectedImageIndex = 21;// 8;
            
           //TreeNode ArtifactsNode = biztalkGroupNode.Nodes.Add("All Artifacts");
            //ArtifactsNode.Nodes.Add("");

            TreeNode biztalkApplicationsNode = biztalkGroupNode.Nodes.Add("Applications");
            biztalkApplicationsNode.Nodes.Add("");
            TreeNode msiDeploy = biztalkGroupNode.Nodes.Add(Constants._MSI_DEPLOY_TREENODE_TEXT);
            msiDeploy.ImageIndex = 19;
            msiDeploy.SelectedImageIndex = 19;

            TreeNode btdfmsiDeploy = biztalkGroupNode.Nodes.Add(Constants._BTDF_MSI_DEPLOY_TREENODE_TEXT);
            btdfmsiDeploy.ImageIndex = 19;
            btdfmsiDeploy.SelectedImageIndex = 19;

            /*  TreeNode resourceDeploy = parentNode.Nodes.Add(Constants._RESOURCE_DEPLOY_TREENODE_TEXT);
              resourceDeploy.ImageIndex = 25;
              resourceDeploy.SelectedImageIndex = 25;*/

            TreeNode hostInstancesNode = biztalkGroupNode.Nodes.Add(Constants._HOST_INSTANCE_TREENODE_TEXT);
            hostInstancesNode.ImageIndex = 7;
            hostInstancesNode.SelectedImageIndex = 7;

            TreeNode iisNodes = biztalkGroupNode.Nodes.Add("IIS");
            iisNodes.ImageIndex = 22;
            iisNodes.SelectedImageIndex = 22;
            iisNodes.Nodes.Add("");
        }

        private void LoadApplicationsOnExpand(TreeNode biztalkApplicationsNode)
        {
            biztalkApplicationsNode.Nodes.Clear();
            foreach (Microsoft.BizTalk.ExplorerOM.Application application in RefreshAppCollection())
            {
                TreeNode applicationNode = biztalkApplicationsNode.Nodes.Add(application.Name);
                applicationNode.Nodes.Add("");
                ApplicationLoad appLoad = new ApplicationLoad();
                appLoad.Application = application;
                appLoad.IsArtifactsLoaded = false;
                applicationNode.Tag = appLoad;
                applicationNode.ContextMenuStrip = contextMenuStripApplication;
            }
            IsapplicationNodeExpanded = true;
        }


        private void LoadIISTreeViewOnExpand(TreeNode parentNode)
        {
            parentNode.Nodes.Clear();
            parentNode.ImageIndex = 22;//8;
            parentNode.SelectedImageIndex = 22;//8;
            foreach (var server in GlobalProperties.MessagingServers)
            {
                Microsoft.Web.Administration.ApplicationPoolCollection applicationPools = null;
                Microsoft.Web.Administration.SiteCollection sites = null;
                TreeNode node = parentNode.Nodes.Add(server);
                node.ImageIndex = 9;
                node.SelectedImageIndex = 9;
                node.ContextMenuStrip = contextMenuStrip2;
                node.Tag = IISHelper.GetServerManager(server, out applicationPools, out sites);
                TreeNode appPool = node.Nodes.Add("Application Pools");
                appPool.ImageIndex = 10;
                appPool.SelectedImageIndex = 10;
                appPool.ContextMenuStrip = contextMenuStripServer;
                foreach (Microsoft.Web.Administration.ApplicationPool applicationPool in applicationPools.OrderBy(x=>x.Name))
                {
                    TreeNode pool = appPool.Nodes.Add(applicationPool.Name);
                    pool.ImageIndex = 10;
                    pool.SelectedImageIndex = 10;
                    pool.Tag = applicationPool;
                    pool.ContextMenuStrip = contextMenuStrip1;
                }
                TreeNode nodeWebSite = node.Nodes.Add("Sites");
                nodeWebSite.ImageIndex = 18;
                nodeWebSite.SelectedImageIndex = 18;
                foreach (Microsoft.Web.Administration.Site site in sites.OrderBy(x => x.Name))
                {
                    TreeNode nodeSites = nodeWebSite.Nodes.Add(site.Name);
                    nodeSites.ImageIndex = 11;
                    nodeSites.SelectedImageIndex = 11;
                    nodeSites.ContextMenuStrip = contextMenuStripWebSite;
                    nodeSites.Tag = site;
                    foreach (Microsoft.Web.Administration.Application application in site.Applications.OrderBy(x=>x.Path))
                    {
                        if (application.Path != @"/")
                        {
                            TreeNode applicationNode = nodeSites.Nodes.Add(application.Path);
                            applicationNode.ImageIndex = 12;
                            applicationNode.SelectedImageIndex = 12;
                            applicationNode.ContextMenuStrip = contextMenuStripDeletApp;
                            applicationNode.Tag = application;
                        }
                    }
                }
            }
            IsIISNodeExpanded = true;
        }


        private void LoadApplicationArtifactsProperties(Microsoft.BizTalk.ExplorerOM.Application application, TreeNode parentNode)
        {
            listPolicy.Clear();
            parentNode.Nodes.Clear();
            treeViewBizTalkApplications.BeginUpdate();
            this.FormState = FormStateEnum.Processing;
            if (application != null)
            {
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
                            orchestrationsNode.ImageIndex = 23;// 2;
                            orchestrationsNode.SelectedImageIndex = 23;//2;
                            var q = from orchestration in assembly.Orchestrations.Cast<Microsoft.BizTalk.ExplorerOM.BtsOrchestration>()
                                    orderby orchestration.FullName
                                    select orchestration;


                            foreach (Microsoft.BizTalk.ExplorerOM.BtsOrchestration orchestration in q.ToList())
                            {
                                try
                                {
                                    TreeNode node = orchestrationsNode.Nodes.Add(orchestration.FullName);
                                    node.ImageIndex = 2;
                                    node.SelectedImageIndex = 2;
                                    // BtsOrchestrationHelper orch = new BtsOrchestrationHelper(orchestration);
                                    node.Tag = orchestration;
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }

                            }
                        }

                        // Load Schemas
                        if (assembly.Schemas.Count > 0)
                        {
                            TreeNode schemasNode = assemblyNode.Nodes.Add("Schemas");
                            schemasNode.ImageIndex = 23;// 6;
                            schemasNode.SelectedImageIndex = 23;// 6;
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
                            pipelinesNode.ImageIndex = 23;//5;
                            pipelinesNode.SelectedImageIndex = 23;// 5;
                            var q = from pipeline in assembly.Pipelines.Cast<Microsoft.BizTalk.ExplorerOM.Pipeline>()
                                    orderby pipeline.FullName
                                    select pipeline;

                            foreach (Microsoft.BizTalk.ExplorerOM.Pipeline pipeline in q.ToList())
                            {
                                TreeNode node = pipelinesNode.Nodes.Add(pipeline.FullName);
                                PipelineInfo pipelineTag = new PipelineInfo(pipeline);
                                node.Tag = pipelineTag;
                                //node.ContextMenuStrip = contextMenuStrip2;
                                node.ImageIndex = 5;
                                node.SelectedImageIndex = 5;
                            }
                        }


                        // Load transforms
                        if (assembly.Transforms.Count > 0)
                        {
                            TreeNode transformsNode = assemblyNode.Nodes.Add("Maps");
                            transformsNode.ImageIndex = 23;// 3;
                            transformsNode.SelectedImageIndex = 23;// 3;
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
            this.FormState = FormStateEnum.NotProcessing;
            treeViewBizTalkApplications.EndUpdate();
        }



        private void treeViewBizTalkApplications_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                // Expand only Applications -- Valid only for this node
                if (e.Node != null && e.Node.Parent != null && e.Node.Parent.Text == "Applications")
                {
                    ApplicationLoad appLoad = e.Node.Tag as ApplicationLoad;
                    if (appLoad != null && !appLoad.IsArtifactsLoaded)
                    {
                        LoadApplicationArtifactsProperties(appLoad.Application, e.Node);
                        appLoad.IsArtifactsLoaded = true;
                        e.Node.Tag = appLoad;
                    }
                }
                if (e.Node != null && e.Node.Parent != null && e.Node.Text == "Applications")
                {
                    if (!IsapplicationNodeExpanded)
                        LoadApplicationsOnExpand(e.Node);
                }

                if (e.Node != null && e.Node.Parent != null && e.Node.Parent.Text == "All Artifacts")
                {
                    if (e.Node.Text == "Send Ports")
                    {
                        LoadAllSendPorts(e.Node);
                    }
                    if (e.Node.Text == "Receive Locations")
                    {
                        LoadAllReceiveLocations(e.Node);
                    }
                }

                if (e.Node != null && e.Node.Parent != null && e.Node.Text == "All Artifacts")
                {
                    if (!IsartifactsNodeExpanded)
                        LoadArtifactsOnExpand(e.Node);
                }

                if (e.Node != null && e.Node.Parent != null && e.Node.Text == "IIS")
                {
                    if (!IsIISNodeExpanded)
                        LoadIISTreeViewOnExpand(e.Node);
                }

            }
            catch (Exception exe)
            {
                DisplayError(exe);
            }

        }

        private void LoadAllSendPorts(TreeNode treeNode)
        {
            treeNode.Nodes.Clear();
            SendPort.SendPortCollection sendPorts = SendPort.GetInstances();

            foreach (SendPort sendPort in sendPorts)
            {
                TreeNode sendPortNode = treeNode.Nodes.Add(sendPort.Name);
                sendPortNode.Tag = sendPort;
            }
        }

        private void LoadAllReceiveLocations(TreeNode treeNode)
        {
            treeNode.Nodes.Clear();
            ReceiveLocation.ReceiveLocationCollection receiveLocations = ReceiveLocation.GetInstances();

            foreach (ReceiveLocation receiveLocation in receiveLocations)
            {
                TreeNode receiveLocationsNode = treeNode.Nodes.Add(receiveLocation.Name);
                receiveLocationsNode.Tag = receiveLocation;
            }
        }

        private void LoadArtifactsOnExpand(TreeNode treeNode)
        {
            treeNode.Nodes.Clear();

            TreeNode receiveLocationsNode = treeNode.Nodes.Add("Receive Locations");
            receiveLocationsNode.Nodes.Add("");            
            TreeNode sendPortsNode = treeNode.Nodes.Add("Send Ports");
            sendPortsNode.Nodes.Add("");
            IsartifactsNodeExpanded = true;
        }

        private void treeViewBizTalkApplications_AfterExpand(object sender, TreeViewEventArgs e)
        {

        }

        private void treeViewBizTalkApplications_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            if (e.Node != null && e.Node.Parent != null && e.Node.Text == Constants._MSI_DEPLOY_TREENODE_TEXT)
            {
                this.splitContainer1.Panel2.Controls.Add(msiDeploy);
            }

            if (e.Node != null && e.Node.Parent != null && e.Node.Text == Constants._BTDF_MSI_DEPLOY_TREENODE_TEXT)
            {
                this.splitContainer1.Panel2.Controls.Add(btdfmsiDeploy);
            }

            if (e.Node != null && e.Node.Parent != null && e.Node.Text == "Applications")
            {
                this.splitContainer1.Panel2.Controls.Add(new UserControlListView(RefreshAppCollection()));
            }
            if (e.Node != null && e.Node.Parent != null && e.Node.Text == Constants._HOST_INSTANCE_TREENODE_TEXT)
            {
                this.splitContainer1.Panel2.Controls.Add(btHostInstances);
            }
            else if (e.Node != null && e.Node.Tag != null)
            {
                this.splitContainer1.Panel2.Controls.Add(new UserControl1(e.Node));
            }
        }
        private void DisplayError(Exception ex)
        {
            DisplayError(ex.Message);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool bHandled = false;
            try
            {
                switch (keyData)
                {
                    case Keys.F5:
                        this.FormState = FormStateEnum.Initial;
                        LoadAdministration();
                        bHandled = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                DisplayError(ex);
            }
            return bHandled;
        }

        private void DisplayError(string message)
        {
            MessageBox.Show(message, "BTDT", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void treeViewBizTalkApplications_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeViewBizTalkApplications.SelectedNode = e.Node;
        }

        private void healthCheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeploymentHealthCheck deploymentHealthCheckForm = new DeploymentHealthCheck(treeViewBizTalkApplications.SelectedNode.Text);
            deploymentHealthCheckForm.Show();
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
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (hInstance.WindowState == FormWindowState.Minimized)
                hInstance.WindowState = FormWindowState.Normal;
            hInstance.Activate();
            hInstance.Show();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Services services = new Services();
            services.Show();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            BusinessRulesDeploymentWizard businessRulesDeploymentWizardForm = new BusinessRulesDeploymentWizard();
            businessRulesDeploymentWizardForm.Show();
            /*BRE bre = new BRE();
            bre.Show();*/
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            IIS iis = new IIS();
            iis.Show();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            GACAssembly gacAssembly = new GACAssembly();
            gacAssembly.Show();
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            DeploymentHealthCheck deploymentHealthCheckForm = new DeploymentHealthCheck();
            deploymentHealthCheckForm.Show();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            ApplicationArtifactsView appAssemblies = new ApplicationArtifactsView();
            appAssemblies.Show();
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            MsiInspector msiInspector = new MsiInspector();
            msiInspector.Show();
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            if (ssoAdminInspector.WindowState == FormWindowState.Minimized)
                ssoAdminInspector.WindowState = FormWindowState.Normal;
            ssoAdminInspector.Activate();
            ssoAdminInspector.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void addApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.FormState = FormStateEnum.Processing;
            IISDeploymentTool iisActionTool = new IISDeploymentTool(1);
            iisActionTool.websiteName = treeViewBizTalkApplications.SelectedNode.Text;
            iisActionTool.ShowDialog();
            this.FormState = FormStateEnum.NotProcessing;
        }

        private void addApplicationPoolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.FormState = FormStateEnum.Processing;
            IISDeploymentTool iisActionTool = new IISDeploymentTool(0);
            iisActionTool.ShowDialog();
            this.FormState = FormStateEnum.NotProcessing;
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.FormState = FormStateEnum.Processing;
            IISDeploymentTool iisActionTool = new IISDeploymentTool(2);
            iisActionTool.websiteName = treeViewBizTalkApplications.SelectedNode.Parent.Text;
            iisActionTool.applicationName = treeViewBizTalkApplications.SelectedNode.Text;
            iisActionTool.ShowDialog();
            this.FormState = FormStateEnum.NotProcessing;
        }

        private void checkStausToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.FormState = FormStateEnum.Processing;
            IISDeploymentTool iisActionTool = new IISDeploymentTool(4);
            iisActionTool.applicationName = treeViewBizTalkApplications.SelectedNode.Text;
            iisActionTool.ShowDialog();
            this.FormState = FormStateEnum.NotProcessing;
        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            this.FormState = FormStateEnum.Processing;
            IISDeploymentTool iisActionTool = new IISDeploymentTool(3);
            iisActionTool.applicationPoolName = treeViewBizTalkApplications.SelectedNode.Text;
            iisActionTool.ShowDialog();
            this.FormState = FormStateEnum.NotProcessing;
        }

        private void treeViewBizTalkApplications_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {

            /* Rectangle nodeRect = e.Node.Bounds;
             Point ptExpand = new Point(nodeRect.Location.X - 20, nodeRect.Location.Y + 2);
             Image expandImg = null;
             if (e.Node.IsExpanded || e.Node.Nodes.Count < 1)
                 expandImg = Image.FromFile(minusPath);
             else
                 expandImg = Image.FromFile(plusPath);
             Graphics g = Graphics.FromImage(expandImg);
             IntPtr imgPtr = g.GetHdc();
             g.ReleaseHdc();
             e.Graphics.DrawImage(expandImg, ptExpand);

         
             Font nodeFont = e.Node.NodeFont;
             if (nodeFont == null)
                 nodeFont = ((TreeView)sender).Font;
             Brush textBrush = SystemBrushes.WindowText;
             //to highlight the text when selected
             if ((e.State & TreeNodeStates.Focused) != 0)
                 textBrush = SystemBrushes.HotTrack;
             //Inflate to not be cut
             Rectangle textRect = nodeRect;
             //need to extend node rect
             textRect.Width += 40;
             e.Graphics.DrawString(e.Node.Text, nodeFont, textBrush, Rectangle.Inflate(textRect, -12, 0));*/

        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplicationLoad appLoad = treeViewBizTalkApplications.SelectedNode.Tag as ApplicationLoad;
            if (appLoad != null)
            {
                Microsoft.BizTalk.ExplorerOM.Application refreshedApp = explorerHelper.GetApplication(appLoad.Application.Name);
                appLoad.Application = refreshedApp;
                LoadApplicationArtifactsProperties(appLoad.Application, treeViewBizTalkApplications.SelectedNode);
            }
        }

        private void locatePackageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(treeViewBizTalkApplications.SelectedNode.Text))
            {
                return;
            }
            string appGuid = RegistryHelper.GetUninstallGuid(treeViewBizTalkApplications.SelectedNode.Text, Environment.MachineName);
            if (string.IsNullOrEmpty(appGuid))
            {
                DisplayError("The application is not installed on current machine. Msi locate not applicable.");
                return;
            }
            LocateMsi locateMsi = new LocateMsi(appGuid);
            locateMsi.Show();
        }

        private void BizTalkApplicationAdministration_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsMsiDeployInAction || IsHostInstanceRestartInAction || IsBTDFMsiDeployInAction)
            {
                DialogResult result = DisplayQuestion("Actions are still executing. Do you want to close ? Closing can lead to inconsistent state in the environment.");
                if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                else
                {
                    DeleteBTDFTemExtractedFolder();
                }
            }
            else
            {
                DeleteBTDFTemExtractedFolder();
            }
        }

        private void DeleteBTDFTemExtractedFolder()
        { 
            if (Directory.Exists(btdfmsiDeploy.extractPath))
                Directory.Delete(btdfmsiDeploy.extractPath, true);
        }
        private DialogResult DisplayQuestion(string message)
        {
            return MessageBox.Show(message, "BTDT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.FormState = FormStateEnum.Processing;
            IISDeploymentTool iisActionTool = new IISDeploymentTool(5);
            iisActionTool.ShowDialog();
            this.FormState = FormStateEnum.NotProcessing;
        }

        private void setHandlersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetHandlers setHandlers = new SetHandlers();
            setHandlers.ShowDialog();
        }

        private void changeApplicationPoolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.FormState = FormStateEnum.Processing;
            IISDeploymentTool iisActionTool = new IISDeploymentTool(6);
            iisActionTool.websiteName = treeViewBizTalkApplications.SelectedNode.Parent.Text;
            iisActionTool.applicationName = treeViewBizTalkApplications.SelectedNode.Text;
            iisActionTool.ShowDialog();
            this.FormState = FormStateEnum.NotProcessing;
        }

        private void deleteApplicationPoolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.FormState = FormStateEnum.Processing;
            IISDeploymentTool iisActionTool = new IISDeploymentTool(7);
            iisActionTool.applicationPoolName = treeViewBizTalkApplications.SelectedNode.Text;
            iisActionTool.ShowDialog();
            this.FormState = FormStateEnum.NotProcessing;
        }

        private void importBindingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportBinding importBinding = new ImportBinding(treeViewBizTalkApplications.SelectedNode.Text);
            importBinding.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBADT about = new AboutBADT();
            about.ShowDialog();
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            this.FormState = FormStateEnum.Initial;
            LoadAdministration();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.FormState = FormStateEnum.Processing;
            IISDeploymentTool iisActionTool = new IISDeploymentTool(3);
            Microsoft.Web.Administration.Application app = treeViewBizTalkApplications.SelectedNode.Tag as Microsoft.Web.Administration.Application;
            if (app != null)
            {
                iisActionTool.applicationPoolName = app.ApplicationPoolName;
                iisActionTool.ShowDialog();
            }
            this.FormState = FormStateEnum.NotProcessing;
        }
    }
}

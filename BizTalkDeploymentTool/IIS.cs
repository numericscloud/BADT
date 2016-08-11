using BizTalkDeploymentTool.Wmi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BizTalkDeploymentTool.Helpers;
using BizTalkDeploymentTool.Global;

namespace BizTalkDeploymentTool
{
    public partial class IIS : Form
    {
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
            this.Cursor = cursor;
        }

        public IIS()
        {
            InitializeComponent();
        }

        private void IIS_Load(object sender, EventArgs e)
        {
            try
            {
                this.FormState = FormStateEnum.Processing;
                LoadTreeView();
                ExpandToLevel(treeView1.Nodes, 2);
                this.FormState = FormStateEnum.Initial;
                //treeView1.ExpandAll();
            }
            catch (Exception exe)
            {
                DisplayError(exe);
            }

        }

        private void LoadTreeView()
        {
            treeView1.Nodes.Clear();
            TreeNode parentNode = treeView1.Nodes.Add("IIS");
            parentNode.ImageIndex = 0;
            parentNode.SelectedImageIndex = 0;
            foreach (var server in GlobalProperties.MessagingServers)
            {
                Microsoft.Web.Administration.ApplicationPoolCollection applicationPools = null;
                Microsoft.Web.Administration.SiteCollection sites = null;
                TreeNode node = treeView1.Nodes[0].Nodes.Add(server);
                node.ImageIndex = 4;
                node.SelectedImageIndex = 4;
                node.Tag = IISHelper.GetServerManager(server, out applicationPools, out sites);
                TreeNode appPool = node.Nodes.Add("Application Pools");
                appPool.ImageIndex = 1;
                appPool.SelectedImageIndex = 1;
                appPool.ContextMenuStrip = contextMenuStripServer;
                foreach (Microsoft.Web.Administration.ApplicationPool applicationPool in applicationPools)
                {
                    TreeNode pool = appPool.Nodes.Add(applicationPool.Name);
                    pool.ImageIndex = 1;
                    pool.SelectedImageIndex = 1;
                    pool.Tag = applicationPool;
                    pool.ContextMenuStrip = contextMenuStrip1;
                }
                TreeNode nodeWebSite = node.Nodes.Add("Sites");
                nodeWebSite.ImageIndex = 5;
                nodeWebSite.SelectedImageIndex = 5;
                foreach (Microsoft.Web.Administration.Site site in sites)
                {
                    TreeNode nodeSites = nodeWebSite.Nodes.Add(site.Name);
                    nodeSites.ImageIndex = 2;
                    nodeSites.SelectedImageIndex = 2;
                    nodeSites.ContextMenuStrip = contextMenuStripWebSite;
                    nodeSites.Tag = site;
                    foreach (Microsoft.Web.Administration.Application application in site.Applications)
                    {
                        if (application.Path != @"/")
                        {
                            TreeNode applicationNode = nodeSites.Nodes.Add(application.Path);
                            applicationNode.ImageIndex = 3;
                            applicationNode.SelectedImageIndex = 3;
                            applicationNode.ContextMenuStrip = contextMenuStripDeletApp;
                            applicationNode.Tag = application;
                        }
                    }
                }
            }
        }

        private void DisplayError(Exception ex)
        {
            DisplayError(ex.Message);
        }

        private void DisplayError(string message)
        {
            MessageBox.Show(message, "BTDT", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            propertyGrid1.SelectedObject = obj;
        }

        private void addApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.FormState = FormStateEnum.Processing;
            IISDeploymentTool iisActionTool = new IISDeploymentTool(1);
            iisActionTool.websiteName = treeView1.SelectedNode.Text;
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
            iisActionTool.websiteName = treeView1.SelectedNode.Parent.Text;
            iisActionTool.applicationName = treeView1.SelectedNode.Text;
            iisActionTool.ShowDialog();
            this.FormState = FormStateEnum.NotProcessing;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool bHandled = false;
            try
            {
                switch (keyData)
                {
                    case Keys.F5:
                        LoadTreeView();
                        ExpandToLevel(treeView1.Nodes, 2);
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

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeView1.SelectedNode = e.Node;
        }

        private void checkStausToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            IISDeploymentTool iisActionTool = new IISDeploymentTool(4);
            iisActionTool.applicationName = treeView1.SelectedNode.Text;
            iisActionTool.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.FormState = FormStateEnum.Processing;
            IISDeploymentTool iisActionTool = new IISDeploymentTool(3);
            iisActionTool.applicationPoolName = treeView1.SelectedNode.Text;
            iisActionTool.ShowDialog();
            this.FormState = FormStateEnum.NotProcessing;
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

    }
}

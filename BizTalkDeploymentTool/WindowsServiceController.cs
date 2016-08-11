using BizTalkDeploymentTool.Wmi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceProcess;

using BizTalkDeploymentTool.Extensions;
using BizTalkDeploymentTool.Helpers;
using BizTalkDeploymentTool.Actions;
using System.Threading;
using BizTalkDeploymentTool.Global;

namespace BizTalkDeploymentTool
{
    public partial class WindowsServiceController : Form
    {
        public class TreeViewItem
        {
            public string DependentServiceName { get; set; }
            public string ParentServiceName { get; set; }
            public ServiceController ServiceController { get; set; }
        }

        static List<string> serverList = GlobalProperties.MessagingServers;
        static string DBserver = GlobalProperties.DatabaseServer;

        ListView[] serverListViewArray = null;
        List<TreeViewItem> treeViewList;
        ThreadProcessor threadProcessor = null;
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
                    contextMenuStrip1.Enabled = true;
                    break;

                case FormStateEnum.NotProcessing:
                    UpdateCursor(Cursors.Default);
                    foreach (TabPage item in tabControl1.TabPages)
                    {
                        ((Control)item).Enabled = true;
                    }
                    contextMenuStrip1.Enabled = true;
                    break;

                case FormStateEnum.Processing:
                    UpdateCursor(Cursors.WaitCursor);
                    foreach (TabPage item in tabControl1.TabPages)
                    {
                        if (!(item == tabControl1.SelectedTab))
                        {
                            ((Control)item).Enabled = false;
                        }
                    }
                    contextMenuStrip1.Enabled = false;
                    break;

            }
        }
        private void UpdateCursor(Cursor cursor)
        {
            this.Cursor = cursor;
        }
        public WindowsServiceController()
        {
            InitializeComponent();
            serverList.Add(DBserver);
            serverList = serverList.Distinct().ToList();
            serverListViewArray = new ListView[serverList.Count];
        }

        private void WindowsServiceController_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();
            for (int i = 0; i < serverList.Count; i++)
            {
                TabPage serverTab = new TabPage();
                serverTab.Enter += serverTab_Enter;
                serverTab.Text = serverList[i];
                serverTab.Name = serverList[i];
                serverListViewArray[i] = serverServiceList(serverList[i]);
                serverListViewArray[i].Name = serverList[i];
                serverListViewArray[i].MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewControl_MouseClick);
                serverTab.Controls.Add(serverListViewArray[i]);
                tabControl1.TabPages.Add(serverTab);
            }

        }

        void serverTab_Enter(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            propertyGrid1.SelectedObject = null;
        }

        private ListView serverServiceList(string serveName)
        {
            ListView serviceListView = new ListView();
            serviceListView.Columns.Add("Service Name", 230);
            serviceListView.Columns.Add("Display Name", 230);
            serviceListView.Columns.Add("Current Status", 90, HorizontalAlignment.Center);
            serviceListView.Columns.Add("Message", 450);
            ServiceController[] serviceList = ServiceController.GetServices(serveName);
            foreach (ServiceController item in serviceList)
            {
                ListViewItem listViewItem = new ListViewItem(new string[] { item.ServiceName, item.DisplayName, item.Status.ToString(), "" });
                listViewItem.Text = item.ServiceName;
                listViewItem.SubItems[2].ForeColor = item.Status == ServiceControllerStatus.Running ? Color.Green : Color.Red;
                listViewItem.SubItems[2].Font = new Font("Tahoma", Convert.ToSingle(8.25), FontStyle.Bold);
                listViewItem.UseItemStyleForSubItems = false;
                listViewItem.Tag = item;
                serviceListView.Items.Add(listViewItem);
            }
            serviceListView.Dock = DockStyle.Fill;
            serviceListView.View = View.Details;
            serviceListView.GridLines = true;
            serviceListView.FullRowSelect = true;
            serviceListView.MultiSelect = false;
            serviceListView.SelectedIndexChanged += serviceListView_SelectedIndexChanged;
            serviceListView.ContextMenuStrip = contextMenuStrip1;
            return serviceListView;
        }

        void serviceListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (threadProcessor == null || !threadProcessor.IsRunning)
            {
                for (int i = 0; i < serverList.Count; i++)
                {
                    if (tabControl1.SelectedTab.Name == serverListViewArray[i].Name)
                    {
                        foreach (ListViewItem item in serverListViewArray[i].SelectedItems)
                        {
                            ServiceController serviceController = item.Tag as ServiceController;
                            LoadProperties(serviceController);
                        }
                    }
                }
            }
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BeginServiceStopAction();
        }

        private List<BaseAction> GetStopServiceActions()
        {
            List<BaseAction> actions = new List<BaseAction>();
            for (int i = 0; i < serverList.Count; i++)
            {
                if (tabControl1.SelectedTab.Name == serverListViewArray[i].Name)
                {
                    foreach (ListViewItem item in serverListViewArray[i].SelectedItems)
                    {
                        actions.Add((BaseAction)new StopServiceAction((ServiceController)item.Tag));
                    }
                }
            }
            return actions;
        }

        private List<BaseAction> GetStartServiceActions()
        {
            List<BaseAction> actions = new List<BaseAction>();
            for (int i = 0; i < serverList.Count; i++)
            {
                if (tabControl1.SelectedTab.Name == serverListViewArray[i].Name)
                {
                    foreach (ListViewItem item in serverListViewArray[i].SelectedItems)
                    {
                        actions.Add((BaseAction)new StartServiceAction((ServiceController)item.Tag));
                    }
                }
            }
            return actions;
        }

        private void BeginServiceStopAction()
        {
            BeginActionOnService(GetStopServiceActions());
        }

        private void BeginActionOnService(List<BaseAction> actions)
        {

            this.FormState = FormStateEnum.Processing;

            // Initialize thread
            if (threadProcessor == null)
            {
                threadProcessor = new ThreadProcessor();
                threadProcessor.Completed += new EventHandler<CompletedEventArgs>(threadProcessor_Completed);
                threadProcessor.ActionExecuting += new EventHandler<ActionExecutingEventArgs>(threadProcessor_Executing);
                threadProcessor.ActionExecuted += new EventHandler<ActionExecutedEventArgs>(threadProcessor_Executed);
            }
            threadProcessor.AsyncRun(actions);
        }

        void threadProcessor_Executing(object sender, ActionExecutingEventArgs e)
        {
            if (this.InvokeRequired)
            {
                // We're on a thread other than the GUI thread
                this.Invoke(new MethodInvoker(() => threadProcessor_Executing(sender, e)));

                return;
            }
            UpdateLog(e.ActionStatus, e.Message, GetListViewItem(e.Action));
        }

        void UpdateLog(object sender, ActionExecutedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                // We're on a thread other than the GUI thread
                this.Invoke(new MethodInvoker(() => UpdateLog(sender, e)));
                return;
            }

            UpdateLog(e.ActionStatus, e.Message, GetListViewItem(e.Action));
        }
        void threadProcessor_Completed(object sender, CompletedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                // We're on a thread other than the GUI thread
                this.Invoke(new MethodInvoker(() => threadProcessor_Completed(sender, e)));

                return;
            }
            this.FormState = FormStateEnum.Initial;
            EndExecuteActions();
        }

        private void EndExecuteActions()
        {
            this.FormState = FormStateEnum.NotProcessing;
        }

        void threadProcessor_Executed(object sender, ActionExecutedEventArgs e)
        {
            // Execute in same thread as ThreadProcessor

            if (this.InvokeRequired)
            {
                // We're on a thread other than the GUI thread
                this.Invoke(new MethodInvoker(() => threadProcessor_Executed(sender, e)));
                return;
            }
            UpdateLog(sender, e);
        }

        private ListViewItem GetListViewItem(BaseAction action)
        {
            for (int i = 0; i < serverList.Count; i++)
            {
                if (tabControl1.SelectedTab.Name == serverListViewArray[i].Name)
                {
                    foreach (ListViewItem item in serverListViewArray[i].Items)
                    {
                        if (((ServiceController)item.Tag).ServiceName == action.DisplayName)
                        {
                            return item;
                        }
                    }
                }
            }
            return null;
        }

        private void UpdateLog(ActionStatusEnum actionStatus, string resultMessage, ListViewItem item)
        {
            Color color;
            string text;

            switch (actionStatus)
            {
                case ActionStatusEnum.Executing:
                    text = "Executing";
                    color = Color.Blue;
                    break;

                case ActionStatusEnum.Succeeded:
                    text = ((ServiceController)item.Tag).Status.ToString();
                    color = ((ServiceController)item.Tag).Status == ServiceControllerStatus.Running ? Color.Green : Color.Red;
                    item.Checked = false;
                    break;

                default:
                    text = ((ServiceController)item.Tag).Status.ToString();
                    color = Color.Red;
                    break;
            }

            item.SubItems[2].Text = text;
            item.SubItems[2].ForeColor = color;
            item.SubItems[3].Text = resultMessage;
            item.UseItemStyleForSubItems = false;
            item.ToolTipText = resultMessage;
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BeginServiceStartAction();
        }

        private void BeginServiceStartAction()
        {
            BeginActionOnService(GetStartServiceActions());
        }

        private void listViewControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (threadProcessor == null || !threadProcessor.IsRunning)
            {
                for (int i = 0; i < serverList.Count; i++)
                {
                    if (tabControl1.SelectedTab.Name == serverListViewArray[i].Name)
                    {
                        foreach (ListViewItem item in serverListViewArray[i].SelectedItems)
                        {
                            ServiceController serviceController = item.Tag as ServiceController;
                            if (e.Button == MouseButtons.Right)
                            {
                                contextMenuStrip1.Items[0].Enabled = serviceController.Status == ServiceControllerStatus.Running ? false : true;
                                contextMenuStrip1.Items[1].Enabled = serviceController.Status == ServiceControllerStatus.Stopped ? false : true;
                                contextMenuStrip1.Items[2].Enabled = serviceController.Status == ServiceControllerStatus.Stopped ? false : true;
                            }
                            else if (e.Button == MouseButtons.Left)
                            {
                                LoadDependentServicesTreeView(serviceController);
                                LoadProperties(serviceController);
                            }
                        }
                    }
                }
            }
        }

        private void LoadProperties(ServiceController serviceController)
        {
            propertyGrid1.SelectedObject = serviceController;
        }

        private void LoadDependentServicesTreeView(ServiceController serviceController)
        {
            this.treeView1.Nodes.Clear();
            treeViewList = new List<TreeViewItem>();
            LoadList(serviceController);
            PopulateTreeView(serviceController.ServiceName, null);
        }

        private void LoadList(ServiceController serviceController)
        {
            foreach (ServiceController item in serviceController.DependentServices)
            {
                treeViewList.Add(new TreeViewItem()
             {
                 ParentServiceName = serviceController.ServiceName,
                 DependentServiceName = item.ServiceName,
                 ServiceController = item
             });
                LoadList(item);
            }

        }
        private void PopulateTreeView(string parentID, TreeNode parentNode)
        {
            var filteredItems = treeViewList.Where(item =>
                                        item.ParentServiceName == parentID);

            TreeNode childNode;
            foreach (var i in filteredItems.ToList())
            {
                if (parentNode == null)
                {
                    childNode = treeView1.Nodes.Add(i.DependentServiceName);
                }
                else
                {
                    childNode = parentNode.Nodes.Add(i.DependentServiceName);
                }

                PopulateTreeView(i.DependentServiceName, childNode);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                var filteredItems = treeViewList.Where(item =>
                                       treeView1.SelectedNode.Text == item.DependentServiceName);
                LoadProperties(filteredItems.ToList()[0].ServiceController);

            }
        }

        private void treeView1_MouseClick(object sender, MouseEventArgs e)
        {
            /* if (treeView1.SelectedNode != null)
             {
                 for (int i = 0; i < serverList.Count; i++)
                 {
                     if (tabControl1.SelectedTab.Name == serverListViewArray[i].Name)
                     {

                         ServiceController serviceController = new ServiceController(treeView1.SelectedNode.Text, tabControl1.SelectedTab.Name);
                         if (e.Button == MouseButtons.Right)
                         {
                             contextMenuStrip1.Items[0].Enabled = serviceController.Status == ServiceControllerStatus.Running ? false : true;
                             contextMenuStrip1.Items[1].Enabled = serviceController.Status == ServiceControllerStatus.Stopped ? false : true;
                         }
                         else if (e.Button == MouseButtons.Left)
                         {

                         }
                     }
                 }
             }*/

        }

        private void restartToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.BeginServiceRestartAction();
        }

        private void BeginServiceRestartAction()
        {
            BeginActionOnService(GetReStartServiceActions());
        }


        private List<BaseAction> GetReStartServiceActions()
        {
            List<BaseAction> actions = new List<BaseAction>();
            for (int i = 0; i < serverList.Count; i++)
            {
                if (tabControl1.SelectedTab.Name == serverListViewArray[i].Name)
                {
                    foreach (ListViewItem item in serverListViewArray[i].SelectedItems)
                    {
                        actions.Add((BaseAction)new RestartServiceAction((ServiceController)item.Tag));
                    }
                }
            }
            return actions;
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage != null)
            {
                if (!((Control)e.TabPage).Enabled)
                {
                    e.Cancel = true;
                }
            }
        }

        private void WindowsServiceController_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (threadProcessor != null && threadProcessor.IsRunning)
            {
                DialogResult result = DisplayQuestion("Thread still executing. Do you want to close ?");
                e.Cancel = (result == DialogResult.Cancel);
            }
        }
        private DialogResult DisplayQuestion(string message)
        {
            return MessageBox.Show(message, "BTDT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool bHandled = false;
            if (threadProcessor == null || !threadProcessor.IsRunning)
            {
                switch (keyData)
                {
                    case Keys.F5:
                        RefreshSelectedTabServiceList();
                        bHandled = true;
                        break;
                }
            }
            return bHandled;
        }

        private void RefreshSelectedTabServiceList()
        {
            for (int i = 0; i < serverList.Count; i++)
            {
                if (tabControl1.SelectedTab.Name == serverListViewArray[i].Name)
                {
                    foreach (ListViewItem item in serverListViewArray[i].Items)
                    {
                        ServiceController serviceController =  (ServiceController)item.Tag;
                        serviceController.Refresh();
                        UpdateListView(serviceController, item);
                    }
                }
            }
        }

        private void UpdateListView(ServiceController serviceController, ListViewItem item)
        {
            item.SubItems[2].Text = serviceController.Status.ToString();
            item.SubItems[2].ForeColor = serviceController.Status == ServiceControllerStatus.Running ? Color.Green : Color.Red;
        }

    }
}

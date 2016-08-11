using BizTalkDeploymentTool.Actions;
using BizTalkDeploymentTool.Global;
using BizTalkDeploymentTool.Helpers;
using BizTalkDeploymentTool.Wmi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Windows.Forms;
using BizTalkDeploymentTool.Extensions;
using System.Threading.Tasks;

namespace BizTalkDeploymentTool
{
    public partial class Services : Form
    {

        List<string> allServers = new List<string>();
        ThreadProcessor threadProcessor = null;
        Dictionary<string, List<ListViewItem>> servicesDictionary = new Dictionary<string, List<ListViewItem>>();
        public Services()
        {
            InitializeComponent();
            listView1.DoubleBuffered(true);
        }

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
                    treeView1.Enabled = true;
                    break;

                case FormStateEnum.NotProcessing:
                    UpdateCursor(Cursors.Default);
                    treeView1.Enabled = true;
                    contextMenuStrip1.Enabled = true;
                    threadProcessor = null;
                    break;

                case FormStateEnum.Processing:
                    UpdateCursor(Cursors.WaitCursor);
                    contextMenuStrip1.Enabled = false;
                    treeView1.Enabled = false;
                    break;

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

        private void UpdateCursor(Cursor cursor)
        {
            this.Cursor = cursor;
        }

        private void Services_Load(object sender, EventArgs e)
        {
            allServers.AddRange(MSBTS_Server.GetMessagingServers());
            allServers.Add(MSBTS_MsgBoxSetting.GetDatabaseServerName());
            allServers = allServers.Distinct().ToList();

            foreach (var server in allServers)
            {
                TreeNode serverNode = treeView1.Nodes[0].Nodes.Add(server);
                serverNode.ContextMenuStrip = contextMenuStrip2;
            }
            treeView1.ExpandAll();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            listView1.Items.Clear();
            if (treeView1.SelectedNode != null && allServers.Contains(treeView1.SelectedNode.Text))
            {
                if (servicesDictionary.ContainsKey(treeView1.SelectedNode.Text))
                {
                    listView1.Items.AddRange(servicesDictionary[treeView1.SelectedNode.Text].ToArray());
                }
                else
                {
                    PopulateServicesListView(treeView1.SelectedNode.Text);
                }
            }
        }

        private void PopulateServicesListView(string serverName)
        {
            try
            {
                listView1.Items.Clear();
                ServiceController[] serviceList = ServiceController.GetServices(serverName);
                foreach (ServiceController item in serviceList)
                {
                    int imageIndex = 0;
                    if (item.Status == ServiceControllerStatus.Running)
                    {
                        imageIndex = 1;
                    }
                    else if (item.Status == ServiceControllerStatus.Stopped)
                    {
                        imageIndex = 2;
                    }
                    // ServicesHelper servicesHelper = new ServicesHelper(item);                     
                    ListViewItem listViewItem = new ListViewItem(new string[] { item.DisplayName, item.ServiceName, item.Status.ToString(), "", "" }, imageIndex);
                    listViewItem.SubItems[4].Font = new Font("Tahoma", Convert.ToSingle(8.25), FontStyle.Bold);
                    listViewItem.UseItemStyleForSubItems = false;
                    listViewItem.Tag = item;
                 
                    listView1.Items.Add(listViewItem);
                }              
            }
            catch (Exception ex)
            {
                DisplayError(ex);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView listView = sender as ListView;
            foreach (ListViewItem item in listView.SelectedItems)
            {
                ServiceController serviceController = item.Tag as ServiceController;
                LoadProperties(serviceController);
            }

        }

        private void LoadProperties(ServiceController serviceController)
        {
            ServicesHelper services = new ServicesHelper(serviceController);
            propertyGrid1.SelectedObject = services;
            propertyGrid1.ExpandGroup("Properties");
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            ListView listView = sender as ListView;
            foreach (ListViewItem item in listView.SelectedItems)
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
                    LoadProperties(serviceController);
                }
            }
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BeginServiceStopAction();
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

        private void BeginActionOnServiceStartupType(List<BaseAction> actions)
        {

            this.FormState = FormStateEnum.Processing;

            // Initialize thread
            if (threadProcessor == null)
            {
                threadProcessor = new ThreadProcessor();
                threadProcessor.Completed += new EventHandler<CompletedEventArgs>(threadProcessor_Completed);
                threadProcessor.ActionExecuting += new EventHandler<ActionExecutingEventArgs>(threadProcessor_ExecutingStartupType);
                threadProcessor.ActionExecuted += new EventHandler<ActionExecutedEventArgs>(threadProcessor_ExecutedStartupType);
            }
            threadProcessor.AsyncRunAllWorkUnits(actions);
        }

        void threadProcessor_ExecutingStartupType(object sender, ActionExecutingEventArgs e)
        {
            if (this.InvokeRequired)
            {
                // We're on a thread other than the GUI thread
                this.Invoke(new MethodInvoker(() => threadProcessor_ExecutingStartupType(sender, e)));

                return;
            }
            UpdateStartupType(e.ActionStatus, e.Message, GetListViewItem(e.Action));
        }

        void threadProcessor_ExecutedStartupType(object sender, ActionExecutedEventArgs e)
        {
            // Execute in same thread as ThreadProcessor

            if (this.InvokeRequired)
            {
                // We're on a thread other than the GUI thread
                this.Invoke(new MethodInvoker(() => threadProcessor_ExecutedStartupType(sender, e)));
                return;
            }
            UpdateStartupType(e.ActionStatus, e.Message, GetListViewItem(e.Action));
        }

        private void UpdateStartupType(ActionStatusEnum actionStatus, string resultMessage, ListViewItem item)
        {
            Color color = Color.Black;
            string text;

            switch (actionStatus)
            {
                case ActionStatusEnum.Executing:
                    text = "Loading...";
                    resultMessage = "Loading...";
                    break;

                case ActionStatusEnum.Succeeded:
                    text = ((ServiceController)item.Tag).Status.ToString();

                    ServicesHelper.ServiceStartModeExt startupType = (ServicesHelper.ServiceStartModeExt)Enum.Parse(typeof(ServicesHelper.ServiceStartModeExt), resultMessage, true);
                    if ((((ServiceController)item.Tag).Status != ServiceControllerStatus.Running) &&
                        (startupType == ServicesHelper.ServiceStartModeExt.Automatic ||
                        startupType == ServicesHelper.ServiceStartModeExt.DelayedAutomatic ||
                         startupType == ServicesHelper.ServiceStartModeExt.UNKNOWN
                        ))
                    {
                        color = Color.Red;
                    }
                    item.Checked = false;
                    break;

                default:
                    text = ((ServiceController)item.Tag).Status.ToString();
                    color = Color.Red;
                    break;
            }

            item.SubItems[2].ForeColor = color;
           // item.SubItems[3].ForeColor = color;
            item.SubItems[3].Text = resultMessage;
            item.UseItemStyleForSubItems = false;
            item.ToolTipText = resultMessage;
        }

        private List<BaseAction> GetServiceStartupTypeActions(ServiceController[] serviceList)
        {
            List<BaseAction> actions = new List<BaseAction>();

            foreach (ServiceController serviceController in serviceList)
            {
                actions.Add((BaseAction)new LoadServiceStartupTypeAction(serviceController));
            }
            return actions;
        }

        private List<BaseAction> GetStopServiceActions()
        {
            List<BaseAction> actions = new List<BaseAction>();
            //ListView listView = sender as ListView;
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                actions.Add((BaseAction)new StopServiceAction((ServiceController)item.Tag));
            }
            return actions;
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
            foreach (ListViewItem item in listView1.Items)
            {
                if (((ServiceController)item.Tag).ServiceName == action.DisplayName)
                {
                    return item;
                }
            }
            return null;
        }

        private void UpdateLog(ActionStatusEnum actionStatus, string resultMessage, ListViewItem item)
        {
            Color color;
            Color colorStartupHignlight = Color.Black;
            string text;

            switch (actionStatus)
            {
                case ActionStatusEnum.Executing:
                    text = "Executing";
                    color = Color.Blue;
                    item.ImageIndex = 0;
                    break;

                case ActionStatusEnum.Succeeded:
                    text = ((ServiceController)item.Tag).Status.ToString();
                    ServicesHelper.ServiceStartModeExt startupType = (ServicesHelper.ServiceStartModeExt)Enum.Parse(typeof(ServicesHelper.ServiceStartModeExt), item.SubItems[3].Text, true);
                    if ((((ServiceController)item.Tag).Status != ServiceControllerStatus.Running) &&
                        (startupType == ServicesHelper.ServiceStartModeExt.Automatic ||
                        startupType == ServicesHelper.ServiceStartModeExt.DelayedAutomatic ||
                         startupType == ServicesHelper.ServiceStartModeExt.UNKNOWN
                        ))
                    {
                        colorStartupHignlight = Color.Red;
                    }
                    color = Color.Green;
                    item.Checked = false;
                    break;

                default:
                    text = ((ServiceController)item.Tag).Status.ToString();
                    color = Color.Red;
                    break;
            }
            if (((ServiceController)item.Tag).Status == ServiceControllerStatus.Running)
            {
                item.ImageIndex = 1;
            }
            else if (((ServiceController)item.Tag).Status == ServiceControllerStatus.Stopped)
            {
                item.ImageIndex = 2;
            }

            item.SubItems[2].Text = text;
            item.SubItems[2].ForeColor = colorStartupHignlight;
            //item.SubItems[3].ForeColor = colorStartupHignlight;
            item.SubItems[4].ForeColor = color;
            item.SubItems[4].Text = resultMessage;
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
        private List<BaseAction> GetStartServiceActions()
        {
            List<BaseAction> actions = new List<BaseAction>();

            foreach (ListViewItem item in listView1.SelectedItems)
            {
                actions.Add((BaseAction)new StartServiceAction((ServiceController)item.Tag));
            }
            return actions;
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
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
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                actions.Add((BaseAction)new RestartServiceAction((ServiceController)item.Tag));
            }
            return actions;
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
            if (treeView1.SelectedNode != null && allServers.Contains(treeView1.SelectedNode.Text))
            {
                PopulateServicesListView(treeView1.SelectedNode.Text);
            }
        }

        private void treeView1_Click(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = null;
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            try
            {
                switch (e.ChangedItem.Label)
                {
                    case "StartupType":
                        foreach (ListViewItem item in listView1.SelectedItems)
                        {
                            ServiceController service = item.Tag as ServiceController;
                            service.SetStartMode((ServiceManager.ServiceStartModeEx)Enum.Parse(typeof(ServiceManager.ServiceStartModeEx), e.ChangedItem.Value.ToString()));
                            service.Close();
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                DisplayError(ex);
            }

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            List<ListViewItem> listViewItemList = new List<ListViewItem>();
            foreach (ListViewItem listViewItem in listView1.Items)
            {
                listViewItemList.Add(listViewItem);
            }
            if (treeView1.SelectedNode != null && allServers.Contains(treeView1.SelectedNode.Text))
            {
                if (!servicesDictionary.ContainsKey(treeView1.SelectedNode.Text))
                {
                    servicesDictionary.Add(treeView1.SelectedNode.Text, listViewItemList);
                }
                BeginActionOnServiceStartupType(GetServiceStartupTypeActions(ServiceController.GetServices(treeView1.SelectedNode.Text)));
            }

          
        }


    }
}

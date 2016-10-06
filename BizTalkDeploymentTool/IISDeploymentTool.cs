using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BizTalkDeploymentTool.Helpers;
using BizTalkDeploymentTool.Wmi;
using BizTalkDeploymentTool.Actions;
using BizTalkDeploymentTool.Report;
using BizTalkDeploymentTool.Global;

namespace BizTalkDeploymentTool
{
    public partial class IISDeploymentTool : Form
    {
        ThreadProcessor threadProcessor = null;
        private string path = "";
        List<BaseAction> webApplicationStatusactionsList = null;
        Credentials credentialsForm = new Credentials();
        List<string> serverList = GlobalProperties.MessagingServers;

        public string websiteName { get; set; }
        public string applicationName { get; set; }
        public string applicationPoolName { get; set; }

        private ListView actionableListView { get; set; }
        private RichTextBox actionableRichTextBox { get; set; }

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
        public IISDeploymentTool()
        {
            InitializeComponent();
            path = textBoxPhysicalPath.Text;
        }

        public IISDeploymentTool(int tabPageToFocus)
        {
            InitializeComponent();
            path = textBoxPhysicalPath.Text;
            TabPage pageinAction = tabControl1.TabPages[tabPageToFocus];
            foreach (TabPage item in tabControl1.TabPages)
            {
                if (item != pageinAction)
                {
                    tabControl1.TabPages.Remove(item);
                }
            }
        }

        private List<BaseAction> GetCheckedServersForAction()
        {
            List<BaseAction> actions = new List<BaseAction>();

            foreach (ListViewItem item in this.actionableListView.Items)
            {
                if (item.Checked)
                {
                    actions.Add((BaseAction)item.Tag);
                }
            }
            return actions;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.FormState = FormStateEnum.Processing;
            this.BeginCreateAppPoolOnCheckedServer();
            this.FormState = FormStateEnum.Initial;
        }
        private void LoadDefaultValues()
        {
            comboBoxCLRVersion.Text = "v4.0";
            comboBoxPipelineMode.Text = "Classic";
            comboBox32BitEnable.Text = "True";
            comboBoxIdentityType.Text = "ApplicationPoolIdentity";
        }

        private void LoadListViewAppPools()
        {
            listViewAppPoolsCreate.Items.Clear();
            foreach (string server in serverList)
            {
                ListViewItem listViewItem = new ListViewItem(new string[] { server, "Not Executed", "Never", "" });
                listViewItem.SubItems[1].ForeColor = Color.SteelBlue;
                listViewItem.SubItems[1].Font = new Font(label1.Font.Name, label1.Font.Size, FontStyle.Bold);
                listViewItem.UseItemStyleForSubItems = false;
                listViewItem.Tag = new CreateAppPoolAction(server);
                listViewAppPoolsCreate.Items.Add(listViewItem);
            }
        }


        private void BeginCreateAppPoolOnCheckedServer()
        {
            if (listViewAppPoolsCreate.CheckedItems.Count == 0)
            {
                DisplayMessage("Please check the server(s)."); 
                return;
            }
            this.actionableListView = listViewAppPoolsCreate;
            this.actionableRichTextBox = richTextBoxCreateAppPoolMessage;
            BeginCreatingAppPoolOnCheckedServer(GetCheckedServersForAction());
        }
        private void BeginCreatingAppPoolOnCheckedServer(List<BaseAction> actions)
        {
            // Initialize thread
            if (threadProcessor == null)
            {
                threadProcessor = new ThreadProcessor();
                threadProcessor.Completed += new EventHandler<CompletedEventArgs>(threadProcessor_Completed);
                threadProcessor.ActionExecuting += new EventHandler<ActionExecutingEventArgs>(threadProcessor_Executing);
                threadProcessor.ActionExecuted += new EventHandler<ActionExecutedEventArgs>(threadProcessor_Executed);
            }
            ActionFactory.UpdateActions(actions, GetCreateAppPoolActionParameters());
            threadProcessor.AsyncRunAllWorkUnits(actions);
        }

        void threadProcessor_Executing(object sender, ActionExecutingEventArgs e)
        {
            if (this.InvokeRequired)
            {
                // We're on a thread other than the GUI thread
                try
                {
                    this.Invoke(new MethodInvoker(() => threadProcessor_Executing(sender, e)));
                }
                catch (Exception)
                {
                    return;
                }

                return;
            }
            UpdateLog(sender, e); 
        }

        void threadProcessor_Executed(object sender, ActionExecutedEventArgs e)
        {
            // Execute in same thread as ThreadProcessor

            if (this.InvokeRequired)
            {
                // We're on a thread other than the GUI thread
                try
                {
                    this.Invoke(new MethodInvoker(() => threadProcessor_Executed(sender, e)));
                }
                catch (Exception)
                {
                    return;
                }

                return;
            }
            UpdateLog(sender, e);           
        }

        void threadProcessor_Completed(object sender, CompletedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                // We're on a thread other than the GUI thread
                try
                {
                    this.Invoke(new MethodInvoker(() => threadProcessor_Completed(sender, e)));
                }
                catch (Exception)
                {
                    return;
                }

                return;
            }

            EndExecuteActions();

            if (e.Canceled)
            {
                DisplayMessage("Execution was interrupted by user");
            }
        }

        void UpdateLog(object sender, ActionExecutedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                // We're on a thread other than the GUI thread
                this.Invoke(new MethodInvoker(() => UpdateLog(sender, e)));
                return;
            }

            UpdateLog(e.ActionStatus, e.RunTime, e.Message, GetListViewItemForLogUpdate(this.actionableListView, e.Action));
        }

        void UpdateLog(object sender, ActionExecutingEventArgs e)
        {
            if (this.InvokeRequired)
            {
                // We're on a thread other than the GUI thread
                this.Invoke(new MethodInvoker(() => UpdateLog(sender, e)));
                return;
            }

            UpdateLog(e.ActionStatus, e.RunTime, e.Message, GetListViewItemForLogUpdate(this.actionableListView, e.Action));
        }

        private void UpdateLog(ActionStatusEnum actionStatus, DateTime runTime, string resultMessage, ListViewItem item)
        {
            Color color;
            string text;
            string lastRun;
            switch (actionStatus)
            {
                case ActionStatusEnum.Executing:
                    text = "Executing";
                    color = Color.Blue;
                    lastRun = "";
                    break;

                case ActionStatusEnum.Succeeded:
                    text = "Success";
                    color = Color.Green;
                    lastRun = runTime.ToString();
                    item.Checked = false;
                    break;

                default:
                    text = "Failure";
                    item.Checked = false;
                    lastRun = runTime.ToString();                    
                    color = Color.Red;
                    break;
            }

            item.SubItems[1].Text = text;
            item.SubItems[1].ForeColor = color;
            item.SubItems[2].Text = lastRun;
            item.SubItems[3].Text = resultMessage;
            item.UseItemStyleForSubItems = false;
            item.ToolTipText = resultMessage;
        }
        
        private void UpdateLog2(ActionStatusEnum actionStatus, string resultMessage, TreeNode node)
        {
            switch (actionStatus)
            {
                case ActionStatusEnum.Executing:
                    node.ImageIndex = 0;
                    node.SelectedImageIndex = 0;
                    break;

                case ActionStatusEnum.Succeeded:
                    node.ImageIndex = 1;
                    node.SelectedImageIndex = 1;
                    break;

                default:
                    node.ImageIndex = 2;
                    node.SelectedImageIndex = 2;
                    break;
            }
            node.ToolTipText = resultMessage;
        }

        private ListViewItem GetListViewItemForLogUpdate(object sender, BaseAction action)
        {
            ListView listView = sender as ListView;
            foreach (ListViewItem item in listView.Items)
            {
                if (item.Tag == action)
                {
                    return item;
                }
            }
            return null;
        }

        private void DisplayMessage(string message)
        {
            MessageBox.Show(message, "IISDeployment", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void EndExecuteActions()
        {
            this.FormState = FormStateEnum.NotProcessing;
            threadProcessor = null;
        }

        private void comboBoxIdentityType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxIdentityType.SelectedItem.ToString() == "SpecificUser")
            {
                credentialsForm.ShowDialog();
            }
        }

        private void listViewAppPoolsCreate_MouseClick(object sender, MouseEventArgs e)
        {
            MouseClickRichTextBoxText(sender, e); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.FormState = FormStateEnum.Processing;
            this.BeginCreateAppOnCheckedServer();
            this.FormState = FormStateEnum.Initial;
        }

        private void BeginCreateAppOnCheckedServer()
        {
            if (listViewCreateApp.CheckedItems.Count == 0)
            {
                DisplayMessage("Please check the server(s)."); 
                return;
            }
            if (string.IsNullOrEmpty(textBoxAppName.Text) || string.IsNullOrWhiteSpace(textBoxAppName.Text))
            {
                DisplayMessage("Please provide a valid application name to create.");
                return;
            }
            this.actionableListView = listViewCreateApp;
            this.actionableRichTextBox = richTextBoxCreateAppMessage;
            BeginCreatingAppOnCheckedServer(GetCheckedServersForAction());
        }

        private void BeginCreatingAppOnCheckedServer(List<BaseAction> actions)
        {
            if (threadProcessor == null)
            {
                threadProcessor = new ThreadProcessor();
                threadProcessor.Completed += new EventHandler<CompletedEventArgs>(threadProcessor_Completed);
                threadProcessor.ActionExecuting += new EventHandler<ActionExecutingEventArgs>(threadProcessor_Executing);
                threadProcessor.ActionExecuted += new EventHandler<ActionExecutedEventArgs>(threadProcessor_Executed);
            }
            ActionFactory.UpdateActions(actions, GetCreateAppActionParameters());
            threadProcessor.AsyncRunAllWorkUnits(actions);
        }


        private ActionFactory.ActionParameters GetCreateAppActionParameters()
        {
            ActionFactory.ActionParameters obj = new ActionFactory.ActionParameters();

            obj.AppName = textBoxAppName.Text;
            obj.SiteName = comboBoxWebSites.SelectedItem.ToString();
            obj.PhysicalPath = textBoxPhysicalPath.Text;
            obj.AppPoolName = comboBoxAppPools.SelectedItem.ToString();
            return obj;
        }

        private ActionFactory.ActionParameters GetCreateAppPoolActionParameters()
        {
            ActionFactory.ActionParameters obj = new ActionFactory.ActionParameters();
            obj.AppPoolName = textBoxAppPoolName.Text;
            obj.AppPoolCLRVersion = comboBoxCLRVersion.SelectedItem.ToString();
            obj.AppPoolPipelineMode = comboBoxPipelineMode.SelectedItem.ToString();
            obj.Enable32Bit = comboBox32BitEnable.SelectedItem.ToString();
            obj.IdentityType = comboBoxIdentityType.SelectedItem.ToString();
            obj.AppPoolUserName = BTDTFormProperties.UserName;
            obj.AppPoolPassword = BTDTFormProperties.Password;
            return obj;
        }

        private ActionFactory.ActionParameters GetCreateChangeAppPoolParameters()
        {
            ActionFactory.ActionParameters obj = new ActionFactory.ActionParameters();
            obj.AppPoolName = comboBox3.SelectedItem.ToString();           
            return obj;
        }

        private void LoadTabPage2()
        {
            comboBoxWebSites.Items.Clear();
            comboBoxAppPools.Items.Clear();
            comboBoxWebSites.Items.Add(this.websiteName);
            comboBoxAppPools.Items.AddRange(IISHelper.GetAppPools().ToArray());
            comboBoxWebSites.Text = comboBoxWebSites.Items[0].ToString();
            comboBoxAppPools.Text = comboBoxAppPools.Items[0].ToString();
            LoadListViewCreateApp();
        }


        private void LoadListViewCreateApp()
        {
            listViewCreateApp.Items.Clear();
            foreach (string server in serverList)
            {
                ListViewItem listViewItem = new ListViewItem(new string[] { server, "Not Executed", "Never", "" });
                listViewItem.SubItems[1].ForeColor = Color.SteelBlue;
                listViewItem.SubItems[1].Font = new Font(label1.Font.Name, label1.Font.Size, FontStyle.Bold);
                listViewItem.UseItemStyleForSubItems = false;
                listViewItem.Tag = new CreateIISAppAction(server);
                listViewCreateApp.Items.Add(listViewItem);
            }
        }

        private void listViewCreateApp_MouseClick(object sender, MouseEventArgs e)
        {
            MouseClickRichTextBoxText(sender, e);  
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            LoadTabPage2();
        }

        private void btnToggle_Click(object sender, EventArgs e)
        {
            Toggle(listViewAppPoolsCreate);
        }
        private void Toggle(ListView listView)
        {
            foreach (ListViewItem item in listView.Items)
            {
                if (item.StateImageIndex != -1)
                    item.Checked = !item.Checked;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Toggle(listViewCreateApp);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.ShowDialog();
            textBoxPhysicalPath.Text = string.IsNullOrEmpty(fd.SelectedPath) ? textBoxPhysicalPath.Text : fd.SelectedPath;
        }

        private void tabPageWebAppStatus_Enter(object sender, EventArgs e)
        {
            this.FormState = FormStateEnum.Processing;
            comboBoxAppPoolNames.Items.Add(applicationPoolName);
            comboBoxAppPoolNames.Text = comboBoxAppPoolNames.Items[0].ToString();
            LoadListViewRecycleAppPool(applicationPoolName);
            this.FormState = FormStateEnum.Initial;
        }

        private void LoadListViewRecycleAppPool(string appPoolName)
        {
            listViewRecycleAppPools.Items.Clear();
            foreach (string server in serverList)
            {
                ListViewItem listViewItem = new ListViewItem(new string[] { server, "Not Executed", "Never", "" });
                listViewItem.SubItems[1].ForeColor = Color.SteelBlue;
                listViewItem.SubItems[1].Font = new Font(label1.Font.Name, label1.Font.Size, FontStyle.Bold);
                listViewItem.UseItemStyleForSubItems = false;
                listViewItem.Tag = new RecycleApplicationPool(server, appPoolName);
                listViewRecycleAppPools.Items.Add(listViewItem);
            }
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            Toggle(listViewRecycleAppPools);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.FormState = FormStateEnum.Processing;
            this.BeginRecycleAppPool();
            this.FormState = FormStateEnum.Initial;
        }

        private void BeginRecycleAppPool()
        {
            if (listViewRecycleAppPools.CheckedItems.Count == 0)
            {
                DisplayMessage("Please check the server(s).");
                return;
            }
            this.actionableListView = listViewRecycleAppPools;
            this.actionableRichTextBox = richTextBoxRecycleAppPool;
            BeginRecyclingAppPools(GetCheckedServersForAction());
        }

        private void BeginRecyclingAppPools(List<BaseAction> actions)
        {
            // Initialize thread
            if (threadProcessor == null)
            {
                threadProcessor = new ThreadProcessor();
                threadProcessor.Completed += new EventHandler<CompletedEventArgs>(threadProcessor_Completed);
                threadProcessor.ActionExecuting += new EventHandler<ActionExecutingEventArgs>(threadProcessor_Executing);
                threadProcessor.ActionExecuted += new EventHandler<ActionExecutedEventArgs>(threadProcessor_Executed);
            }
            threadProcessor.AsyncRunAllWorkUnits(actions);
        }

        private void BeginCheckingWebServiceStatus(List<BaseAction> actions)
        {

            this.FormState = FormStateEnum.Processing;
            if (threadProcessor == null)
            {
                threadProcessor = new ThreadProcessor();
                threadProcessor.Completed += new EventHandler<CompletedEventArgs>(threadProcessor_Completed);
                threadProcessor.ActionExecuting += new EventHandler<ActionExecutingEventArgs>(threadProcessor_CheckWebServiceExecuting);
                threadProcessor.ActionExecuted += new EventHandler<ActionExecutedEventArgs>(threadProcessor_CheckWebServiceExecuted);
            }
            threadProcessor.AsyncRunAllWorkUnits(actions);
        }

        void threadProcessor_CheckWebServiceExecuting(object sender, ActionExecutingEventArgs e)
        {
            if (this.InvokeRequired)
            {
                // We're on a thread other than the GUI thread
                try
                {
                    this.Invoke(new MethodInvoker(() => threadProcessor_CheckWebServiceExecuting(sender, e)));
                }
                catch (Exception)
                {
                    return;
                }

                return;
            }
            UpdateLog2(e.ActionStatus, "", GetTreeNodeForUpdate(e.Action));
            // UpdateLog2(e.ActionStatus, "", GetListViewItemForLogUpdate(listViewWebApps, e.Action));
        }

        private TreeNode GetTreeNodeForUpdate(BaseAction baseAction)
        {
            foreach (TreeNode item in Collect(treeView1.Nodes))
            {
                if (item.Tag == baseAction)
                {
                    return item;
                }
            }
            return null;
        }

        private IEnumerable<TreeNode> Collect(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                yield return node;

                foreach (var child in Collect(node.Nodes))
                    yield return child;
            }
        }

        void threadProcessor_CheckWebServiceExecuted(object sender, ActionExecutedEventArgs e)
        {
            // Execute in same thread as ThreadProcessor

            if (this.InvokeRequired)
            {
                // We're on a thread other than the GUI thread
                try
                {
                    this.Invoke(new MethodInvoker(() => threadProcessor_CheckWebServiceExecuted(sender, e)));
                }
                catch (Exception)
                {
                    return;
                }

                return;
            }
            UpdateLog2(e.ActionStatus, e.Message, GetTreeNodeForUpdate(e.Action));
            // UpdateLog2(e.ActionStatus, e.Message, GetListViewItemForLogUpdate(listViewWebApps, e.Action));
        }


        private ListViewItem.ListViewSubItem uriSubItemSelected;
        private void listViewWebApps_MouseClick(object sender, MouseEventArgs e)
        {
            ListView lstViewContextStrip = sender as ListView;
            if (e.Button == MouseButtons.Right)
            {

            }
            else if (e.Button == MouseButtons.Left)
            {
                if (uriSubItemSelected != null)
                {
                    webBrowser1.Navigate(uriSubItemSelected.Text);
                    //System.Diagnostics.Process.Start(uriSubItemSelected.Text);
                }
                richTextBoxRecycleAppPool.Text = listViewRecycleAppPools.FocusedItem.ToolTipText;
            }
        }

       
        private void tabPageDeleteApplication_Enter(object sender, EventArgs e)
        {
            this.FormState = FormStateEnum.Processing;
            comboBoxSiteName.Items.Clear();
            comboBoxWebAppNames.Items.Clear();
            comboBoxSiteName.Items.Add(this.websiteName);
            comboBoxWebAppNames.Items.Add(this.applicationName);
            comboBoxSiteName.Text = this.websiteName;
            comboBoxWebAppNames.Text = this.applicationName;
            LoadListViewDeleteApp();
            this.FormState = FormStateEnum.Initial;
        }

        private void LoadWebSites()
        {
            // comboBoxSiteName.Items.AddRange(IISHelper.GetSites().ToArray());
        }

        private void LoadWebApplications(string siteName)
        {
            comboBoxWebAppNames.Items.AddRange(IISHelper.GetSiteAppList(siteName).ToArray());
        }

        private void LoadListViewDeleteApp()
        {
            listViewDeleteWebApp.Items.Clear();
            foreach (string server in serverList)
            {
                ListViewItem listViewItem = new ListViewItem(new string[] { server, "Not Executed", "Never", "" });
                listViewItem.SubItems[1].ForeColor = Color.SteelBlue;
                listViewItem.SubItems[1].Font = new Font(label1.Font.Name, label1.Font.Size, FontStyle.Bold);
                listViewItem.UseItemStyleForSubItems = false;
                listViewItem.Tag = new DeleteIISAppAction(server, this.applicationName, this.websiteName);
                listViewDeleteWebApp.Items.Add(listViewItem);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Toggle(listViewDeleteWebApp);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.FormState = FormStateEnum.Processing;
            this.BeginDeleteWebApplication();
            this.FormState = FormStateEnum.Initial;
        }

        private void BeginDeleteWebApplication()
        {
            if (listViewDeleteWebApp.CheckedItems.Count == 0)
            {
                DisplayMessage("Please check the server(s).");
                return;
            }
            this.actionableListView = listViewDeleteWebApp;
            this.actionableRichTextBox = richTextBoxDeleteAppMessage;
            BeginDeletingWebApplication(GetCheckedServersForAction());
        }

        private void BeginDeletingWebApplication(List<BaseAction> actions)
        {
            if (threadProcessor == null)
            {
                threadProcessor = new ThreadProcessor();
                threadProcessor.Completed += new EventHandler<CompletedEventArgs>(threadProcessor_Completed);
                threadProcessor.ActionExecuting += new EventHandler<ActionExecutingEventArgs>(threadProcessor_Executing);
                threadProcessor.ActionExecuted += new EventHandler<ActionExecutedEventArgs>(threadProcessor_Executed);
            }
            threadProcessor.AsyncRunAllWorkUnits(actions);
        }
        
        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            MouseClickRichTextBoxText(sender, e);  
        }
        
        private void IISDeploymentTool_FormClosing(object sender, FormClosingEventArgs e)
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

        private void tabPageCreateAppPool_Enter(object sender, EventArgs e)
        {
            LoadDefaultValues();
            LoadListViewAppPools();
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            webApplicationStatusactionsList = new List<BaseAction>();
            TreeNode applicationNode = treeView1.Nodes.Add(this.applicationName);
            applicationNode.ImageIndex = 0;
            applicationNode.SelectedImageIndex = 0;
            applicationNode.ContextMenuStrip = contextMenuStripRefreshWebApplicationStatus;
            foreach (var server in serverList)
            {
                string appPoolName = "";
                foreach (var item in IISHelper.GetSvcOrAsmxName(server, this.applicationName, out appPoolName))
                {
                    UriBuilder uriBuilder = new UriBuilder();
                    uriBuilder.Host = server;
                    uriBuilder.Path = string.Format(@"{0}\{1}", this.applicationName, item);
                    TreeNode webApp = applicationNode.Nodes.Add(uriBuilder.ToString());
                    webApp.ContextMenuStrip = contextMenuStripWebApp;
                    CheckWebServiceStatusAction chk = new CheckWebServiceStatusAction(uriBuilder.ToString());
                    webApp.Tag = chk;
                    webApplicationStatusactionsList.Add((BaseAction)chk);
                }
            }
            BeginCheckingWebServiceStatus(webApplicationStatusactionsList);
            treeView1.ExpandAll();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null)
            {
                if (e.Node.Text == this.applicationName)
                {
                    if (webBrowser1.Document != null)
                        webBrowser1.Document.Write(e.Node.Text);
                }
                else
                {
                    webBrowser1.Navigate(e.Node.Text);
                }
                webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(OnWebBrowserDocumentCompleted);
                richTextBoxWebAppStatus.Text = e.Node.ToolTipText;
            }
        }

        private void OnWebBrowserDocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            webBrowser1.Refresh(WebBrowserRefreshOption.Completely);
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeView1.SelectedNode = e.Node;
        }

        private void recheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var chk = treeView1.SelectedNode.Tag as CheckWebServiceStatusAction;
            List<BaseAction> actionsList = new List<BaseAction>();
            actionsList.Add((BaseAction)chk);
            BeginCheckingWebServiceStatus(actionsList);
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginCheckingWebServiceStatus(webApplicationStatusactionsList);
        }

        private void openInIEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(treeView1.SelectedNode.Text);
        }

        private void treeView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (sender != treeView1) return;
            if (e.KeyChar == (char)3)
            {
                copyToClipBoard();
            }
        }

        private void copyToClipBoard()
        {
            if (treeView1!=null && treeView1.SelectedNode != null)
            Clipboard.SetText(treeView1.SelectedNode.Text);
        }

        private void tabPage1_Enter_1(object sender, EventArgs e)
        {
            this.FormState = FormStateEnum.Processing;
            LoadListViewRestartIIS();
            this.FormState = FormStateEnum.Initial;
        }

        private void LoadListViewRestartIIS()
        {
            listViewRestartIIS.Items.Clear();
            foreach (string server in serverList)
            {
                ListViewItem listViewItem = new ListViewItem(new string[] { server, "Not Executed","Never", "" });
                listViewItem.SubItems[1].ForeColor = Color.SteelBlue;
                listViewItem.SubItems[1].Font = new Font(label1.Font.Name, label1.Font.Size, FontStyle.Bold);
                listViewItem.UseItemStyleForSubItems = false;
                listViewItem.Tag = new RestartIISAction(server);
                listViewRestartIIS.Items.Add(listViewItem);
            }
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            Toggle(listViewRestartIIS);
        }

        private void button4_Click_2(object sender, EventArgs e)
        {
            this.FormState = FormStateEnum.Processing;
            this.BeginRestartIIS();
            this.FormState = FormStateEnum.Initial;
        }

        private void BeginRestartIIS()
        {
            if (listViewRestartIIS.CheckedItems.Count == 0)
            {
                DisplayMessage("Please check the server(s).");
                return;
            }
            this.actionableListView = listViewRestartIIS;
            this.actionableRichTextBox = richTextBoxRestartIIS;
            BeginRestartingIIS(GetCheckedServersForAction());
        }

        private void BeginRestartingIIS(List<BaseAction> actions)
        {
            if (threadProcessor == null)
            {
                threadProcessor = new ThreadProcessor();
                threadProcessor.Completed += new EventHandler<CompletedEventArgs>(threadProcessor_Completed);
                threadProcessor.ActionExecuting += new EventHandler<ActionExecutingEventArgs>(threadProcessor_Executing);
                threadProcessor.ActionExecuted += new EventHandler<ActionExecutedEventArgs>(threadProcessor_Executed);
            }
            threadProcessor.AsyncRunAllWorkUnits(actions);
        }

        private void listView1_MouseClick_1(object sender, MouseEventArgs e)
        {
            MouseClickRichTextBoxText(sender, e);              
        }

        private void tabPage3_Enter(object sender, EventArgs e)
        {
            this.FormState = FormStateEnum.Processing;
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox1.Items.Add(this.websiteName);
            comboBox2.Items.Add(this.applicationName);
            comboBox1.Text = this.websiteName;
            comboBox2.Text = this.applicationName;

            comboBox3.Items.AddRange(IISHelper.GetAppPools().ToArray());
            comboBox1.Text = comboBox1.Items[0].ToString();
            comboBox2.Text = comboBox2.Items[0].ToString();

            LoadListViewChangeAppPool();
            this.FormState = FormStateEnum.Initial;
        }

        private void LoadListViewChangeAppPool()
        {
            listViewChangeApplicationPool.Items.Clear();
            foreach (string server in serverList)
            {
                ListViewItem listViewItem = new ListViewItem(new string[] { server, "Not Executed", "Never", "" });
                listViewItem.SubItems[1].ForeColor = Color.SteelBlue;
                listViewItem.SubItems[1].Font = new Font(label1.Font.Name, label1.Font.Size, FontStyle.Bold);
                listViewItem.UseItemStyleForSubItems = false;
                listViewItem.Tag = new ChangeWebAppPool(server, this.applicationName,comboBox3.Items[0].ToString() ,this.websiteName);
                listViewChangeApplicationPool.Items.Add(listViewItem);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.FormState = FormStateEnum.Processing;
            this.BeginChangeAppPool();
            this.FormState = FormStateEnum.Initial;
        }

        private void BeginChangeAppPool()
        {
            if (listViewChangeApplicationPool.CheckedItems.Count == 0)
            {
                DisplayMessage("Please check the server(s).");
                return;
            }
            if (comboBox3.SelectedItem==null)
            {
                DisplayMessage("Select the application pool to which it should be changed");
                return;
            }
            this.actionableListView = listViewChangeApplicationPool;
            this.actionableRichTextBox = richTextBoxChangeApplicationPool;
            BeginChangingApplicationPool(GetCheckedServersForAction());
        }

        private void BeginChangingApplicationPool(List<BaseAction> actions)
        {
            //this.actionableRichTextBox = richTextBoxCreateAppPoolMessage;
            // Initialize thread
            if (threadProcessor == null)
            {
                threadProcessor = new ThreadProcessor();
                threadProcessor.Completed += new EventHandler<CompletedEventArgs>(threadProcessor_Completed);
                threadProcessor.ActionExecuting += new EventHandler<ActionExecutingEventArgs>(threadProcessor_Executing);
                threadProcessor.ActionExecuted += new EventHandler<ActionExecutedEventArgs>(threadProcessor_Executed);
            }
            ActionFactory.UpdateActions(actions, GetCreateChangeAppPoolParameters());
            threadProcessor.AsyncRunAllWorkUnits(actions);
        }

        private void listViewRecycleAppPools_MouseClick(object sender, MouseEventArgs e)
        {
            MouseClickRichTextBoxText(sender, e);              
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Toggle(listViewChangeApplicationPool);
        }

        private void listView2_MouseClick(object sender, MouseEventArgs e)
        {
            MouseClickRichTextBoxText(sender, e);           
        }

        private void MouseClickRichTextBoxText(object sender, MouseEventArgs e)
        {
            ListView lstViewContextStrip = sender as ListView;
            if (e.Button == MouseButtons.Right)
            {

            }
            else if (e.Button == MouseButtons.Left && this.actionableListView!=null)
            {
                this.actionableRichTextBox.Text = this.actionableListView.FocusedItem.ToolTipText;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Toggle(listViewDeleteAppPool);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.FormState = FormStateEnum.Processing;
            this.BeginDeleteAppPool();
            this.FormState = FormStateEnum.Initial;
        }

        private void BeginDeleteAppPool()
        {
            if (listViewDeleteAppPool.CheckedItems.Count == 0)
            {
                DisplayMessage("Please check the server(s).");
                return;
            }
            this.actionableListView = listViewDeleteAppPool;
            this.actionableRichTextBox = richTextBoxDeleteAppPool;
            BeginDeletingAppPools(GetCheckedServersForAction());
        }

        private void BeginDeletingAppPools(List<BaseAction> actions)
        {
            // Initialize thread
            if (threadProcessor == null)
            {
                threadProcessor = new ThreadProcessor();
                threadProcessor.Completed += new EventHandler<CompletedEventArgs>(threadProcessor_Completed);
                threadProcessor.ActionExecuting += new EventHandler<ActionExecutingEventArgs>(threadProcessor_Executing);
                threadProcessor.ActionExecuted += new EventHandler<ActionExecutedEventArgs>(threadProcessor_Executed);
            }
            threadProcessor.AsyncRunAllWorkUnits(actions);
        }

        private void tabPage4_Enter(object sender, EventArgs e)
        {
            this.FormState = FormStateEnum.Processing;
            comboBox4.Items.Add(applicationPoolName);
            comboBox4.Text = comboBox4.Items[0].ToString();
            LoadListViewDeleteAppPool(applicationPoolName);
            this.FormState = FormStateEnum.Initial;
        }

        private void LoadListViewDeleteAppPool(string appPoolName)
        {
            listViewDeleteAppPool.Items.Clear();
            foreach (string server in serverList)
            {
                ListViewItem listViewItem = new ListViewItem(new string[] { server, "Not Executed", "Never", "" });
                listViewItem.SubItems[1].ForeColor = Color.SteelBlue;
                listViewItem.SubItems[1].Font = new Font(label1.Font.Name, label1.Font.Size, FontStyle.Bold);
                listViewItem.UseItemStyleForSubItems = false;
                listViewItem.Tag = new DeleteApplicationPool(server, appPoolName);
                listViewDeleteAppPool.Items.Add(listViewItem);
            }
        }

        private void listViewDeleteAppPool_MouseClick(object sender, MouseEventArgs e)
        {
            MouseClickRichTextBoxText(sender, e);    
        }

    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using System.Data;
using System.Threading;
using System.Security.Principal;
using System.Text;
using System.Linq;
using System.Diagnostics;
using BizTalkDeploymentTool.Extensions;
using BizTalkDeploymentTool.Actions;
using BizTalkDeploymentTool.Helpers;
using BizTalkDeploymentTool.Wmi;
using BizTalkDeploymentTool.Report;
using BizTalkDeploymentTool.Global;
using System.Threading.Tasks;
using Microsoft.BizTalk.ExplorerOM;
using System.Globalization;
using System.Collections;
using System.ComponentModel;

namespace BizTalkDeploymentTool
{


    public partial class MsiDeploy : UserControl
    {
        public enum FormStateEnum
        {
            Initial,
            NotProcessing,
            Processing
        }

        #region Private Properties
        ThreadProcessor threadProcessor = null;
        string executingServer;
        bool allDependentActionsLoaded = false;
        Stopwatch swinstancesAction = new Stopwatch();
        List<DataGridViewCell> Instances = null;
        private static int terminateWorkerIndex = 0;
        ListView lstViewContextStrip = new ListView();
        BTDTReportOptions reportOptionsForm = new BTDTReportOptions();
        StringBuilder saveInstancesResult = new StringBuilder();
        string formText;
        bool ssoactionAdded = false;
        private bool isInterrupted;
        ItemFlags<ListViewItem, bool> _itemFlags = new ItemFlags<ListViewItem, bool>();

        RetstartHostInstances hInstance = new RetstartHostInstances();

        ExplorerOMHelper explorerHelper = new ExplorerOMHelper(GlobalProperties.MgmtDBServer, GlobalProperties.MgmtDBName);
        SSOAdminInspector ssoAdminInspector = new SSOAdminInspector();
        #endregion

        #region Constructors
        public MsiDeploy()
        {
            this.Dock = DockStyle.Fill;
            InitializeComponent();
            BTDTReportOptions ff = new BTDTReportOptions();
            SetFormSize();
            listViewControl.DoubleBuffered(true);
        }
        #endregion

        #region Handling the Form View State
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

                    btnExecute.Visible = false;
                    btnClear.Visible = false;
                    btnStop.Visible = false;
                    btnToggle.Visible = false;
                    btnBrowseConfig.Enabled = true;
                    txtMSILocation.Text = string.Empty;
                    txtAppName.Text = string.Empty;
                    txtSSOConfigLoc.Text = string.Empty;
                    txtConfigAppName.Text = string.Empty;
                    chkBxSSOKey.Visible = false;
                    txtBxSSOKey.Visible = false;
                    instancesGridView.DataSource = new DataTable();
                    cbTargetEnvironment.Items.Clear();
                    threadProcessor = null;
                    terminateToolStripMenuItem.Enabled = false;
                    saveToFileToolStripMenuItem.Enabled = false;
                    rTxtBxMessage.Text = string.Empty;
                    allDependentActionsLoaded = false;
                    checkToolStripMenuItem.Enabled = false;
                    uncheckToolStripMenuItem.Enabled = false;
                    runXSelectedActionsToolStripMenuItem.Enabled = false;
                    runAllCheckedActionsToolStripMenuItem.Enabled = false;
                   // generateInstructionsToolStripMenuItem.Enabled = false;
                    selectMsiToolStripMenuItem.Enabled = true;
                    pictureBox1.Enabled = false;
                    tabControl1.Enabled = true;
                    ssoactionAdded = false;
                    treeViewDependency.Nodes.Clear();
                    listViewControl.Groups.Clear();
                    listViewControl.Items.Clear();
                    propertyGridDepApps.SelectedObject = null;
                    tabControl.TabPages[2].ImageIndex = 1;
                    UpdateCursor(Cursors.Default);
                    break;

                case FormStateEnum.NotProcessing:
                    btnToggle.Visible = true;
                    btnStop.Visible = true;
                    btnExecute.Visible = true;
                    btnClear.Visible = true;
                    btnClear.Enabled = true;
                    btnExecute.Enabled = true;
                    checkToolStripMenuItem.Enabled = true;
                    uncheckToolStripMenuItem.Enabled = true;
                    runXSelectedActionsToolStripMenuItem.Enabled = true;
                    runAllCheckedActionsToolStripMenuItem.Enabled = true;
                   // generateInstructionsToolStripMenuItem.Enabled = true;
                    rTxtBxMessage.Text = string.Empty;
                    pictureBox1.Enabled = true;
                    threadProcessor = null;
                    swinstancesAction.Stop();
                    tabControl1.Enabled = true;
                    UpdateCursor(Cursors.Default);
                    break;

                case FormStateEnum.Processing:
                    btnExecute.Enabled = false;
                    btnClear.Enabled = false;
                    tabControl1.Enabled = false;
                    UpdateCursor(Cursors.WaitCursor);
                    break;

            }
        }

        private void SetFormSize()
        {
            this.Width = (Screen.PrimaryScreen.WorkingArea.Width / 100) * 90;
            this.Height = (Screen.PrimaryScreen.WorkingArea.Height / 100) * 90;
        }

        #endregion

        private void BTDT_Load(object sender, EventArgs e)
        {
            FormLoad();
        }

        public static bool IsAdministrator()
        {
            return (new WindowsPrincipal(WindowsIdentity.GetCurrent()))
                    .IsInRole(WindowsBuiltInRole.Administrator);
        }

        private void btnBrowseMSI_Click(object sender, EventArgs e)
        {

            LoadMsiPackage();
        }

        private void btnBrowseConfig_Click(object sender, EventArgs e)
        {
            LoadSSOConfig();
            UpdateSSOActionsList();
            //foreach (ListViewItem item in listViewControl.Items)
            //{
            //    if (item.StateImageIndex == -1)
            //        item.StateImageIndex = 0;
            //}
        }

        private void UpdateSSOActionsList()
        {

            BaseAction ssoAction = new DeploySsoAction();

            foreach (ListViewItem item in listViewControl.Items)
            {
                if (((BaseAction)item.Tag).DisplayName == ssoAction.DisplayName)
                {
                    item.Remove();
                }
            }
            if (!ssoactionAdded)
            {
                ListViewItem listViewItem = new ListViewItem(new string[] { ssoAction.DisplayName, "Not Executed", "Never", string.Empty, string.Empty }, listViewControl.Groups["1"]);
                listViewItem.SubItems[1].ForeColor = Color.SteelBlue;
                listViewItem.SubItems[1].Font = new Font(lblMsiLoc.Font.Name, lblMsiLoc.Font.Size, FontStyle.Bold);
                listViewItem.UseItemStyleForSubItems = false;
                listViewItem.Tag = ssoAction;
                listViewControl.Items.Add(listViewItem);
                /*if(listViewControl.Items.Count > 1)
                {
                    listViewControl.Items.Insert(listViewControl.Items.Count - 3, listViewItem);
                }else
                {
                    listViewControl.Items.Add( listViewItem);
                }*/
                if (listViewControl.Items.Count > 1)
                {
                    // Start
                    ListViewItem startAction = listViewControl.Groups["1"].Items[listViewControl.Items.Count - 3];
                    //SSO
                    ListViewItem deploySSOAction = listViewControl.Groups["1"].Items[listViewControl.Items.Count - 1];
                    //Validate
                    ListViewItem validateDepAction = listViewControl.Groups["1"].Items[listViewControl.Items.Count - 2];

                    listViewControl.Items[listViewControl.Items.Count - 3] = (ListViewItem)deploySSOAction.Clone();
                    listViewControl.Items[listViewControl.Items.Count - 3].Group = listViewControl.Groups["1"];
                    listViewControl.Items[listViewControl.Items.Count - 2] = (ListViewItem)startAction.Clone();
                    listViewControl.Items[listViewControl.Items.Count - 2].Group = listViewControl.Groups["1"];
                    listViewControl.Items[listViewControl.Items.Count - 1] = (ListViewItem)validateDepAction.Clone();
                    listViewControl.Items[listViewControl.Items.Count - 1].Group = listViewControl.Groups["1"];
                }

            }


        }


        private void FormLoad()
        {
            // Loading menus
            Property.BizTalkEnvironmentEnum executingServerEnum = Property.BizTalkEnvironment;
            executingServer = executingServerEnum.ToString();
            DBServerNameToolStripMenuItems();
            messagingServersToolStripMenuItems(GlobalProperties.MessagingServers);
            string IsAdminText = IsAdministrator() ? " (Administrator)" : " (Non-Administrator)";
            this.Text = this.Text + IsAdminText;
            formText = this.Text;
        }

        private void LoadMsiPackage()
        {
            try
            {
                string fileToOpen = string.Empty;
                if (openMsiFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.FormState = FormStateEnum.Initial;
                    try
                    {
                        this.FormState = FormStateEnum.Processing;
                        fileToOpen = openMsiFileDialog.FileName;

                        /* Microsoft.Deployment.WindowsInstaller.Database msiDb = new Microsoft.Deployment.WindowsInstaller.Database(fileToOpen);

                         msiDb.ExportAll(@"C:\Temp\MsiExport");
                         Microsoft.Deployment.WindowsInstaller.TableCollection tblColl = msiDb.Tables;
                         StringBuilder name = new StringBuilder();
                         foreach (Microsoft.Deployment.WindowsInstaller.ColumnInfo item in tblColl["CustomAction"].Columns)
                         {
                             name.AppendLine(item.Name);
                         }
                          
                        
                         string text="";
                         //msiDb.ExportAll(@"C:\Temp\MsiExport");`Name`
                         using (Microsoft.Deployment.WindowsInstaller.View view = msiDb.OpenView("SELECT `Target` FROM `CustomAction`", new object[0]))
                         {
                             view.Execute();
                             foreach (Microsoft.Deployment.WindowsInstaller.Record current in view)
                             {
                                 text = current.GetString(1);                             
                             }
                         }*/
                        // string cmd = string.Format("cmd.exe /C "Deployment\\Framework\\DeployTools\\UacElevate.exe "[MSBUILDPATH]" "/p:Configuration=Server /t:LaunchServerDeployWizard Deployment\HelloWorld.Deployment.btdfproj [MSBUILDTOOLSVER]""");
                        //  Microsoft.Deployment.WindowsInstaller.Installer.InstallProduct(fileToOpen, null);

                        MsiPackage misPackage = new MsiPackage(fileToOpen);
                        txtMSILocation.Text = fileToOpen;
                        txtAppName.Text = misPackage.DisplayName;
                        LoadTargetEnvironments(misPackage.TargetEnvironments.ToArray());

                        LoadDependentApplications(txtAppName.Text);

                        LoadActions(txtAppName.Text, txtMSILocation.Text, misPackage.WebDirectories());

                        LoadInProgressServiceInstances(txtAppName.Text);
                       

                        // listViewControl.Groups.Add(new ListViewGroup("Text", HorizontalAlignment.Left));
                    }

                    finally
                    {
                        this.Text = string.Concat(txtAppName.Text, " : ", formText);
                        this.FormState = FormStateEnum.NotProcessing;
                        tabControl.TabPages[0].Text = Constants._DEPLOY_ACTION_PAGE_TEXT;
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayError(ex);
            }
        }

        private void LoadDependentApplications(string p)
        {
            treeViewDependency.Nodes.Clear();
            TreeNode baseNode = treeViewDependency.Nodes.Add(p);
            baseNode.ContextMenuStrip = contextMenuStripLoadActionsForDepApps;
            // Load Depency TreeView
            LoadDependencies(p, baseNode);

            // Resolving the treeview to ommit same application if it exists as a dependency at a higher level node.
            ResolveDependencyTreeNode();

            treeViewDependency.ExpandAll();
            if (baseNode.Nodes.Count == 0)
            {
                treeViewDependency.Nodes.Clear();
                tabControl.TabPages[2].ImageIndex = 1;
            }
            else
            {
                tabControl.TabPages[2].ImageIndex = 0;
            }

        }

        private void ResolveDependencyTreeNode()
        {
            List<TreeNode> nodesToRemove = new List<TreeNode>();
            foreach (TreeNode i in treeViewDependency.Nodes.FlattenTree())
            {
                foreach (TreeNode j in treeViewDependency.Nodes.FlattenTree())
                {
                    if(i.Text == j.Text && j.Level > i.Level)
                    {
                        nodesToRemove.Add(i);
                    }
                }   
            }
            foreach (TreeNode item in nodesToRemove)
            {
                treeViewDependency.Nodes.Remove(item);              
            }
        }

        private void LoadDependencies(string p, TreeNode baseNode)
        {
            DependencyDeployment.DependencyResolver cl = new DependencyDeployment.DependencyResolver();
            Dictionary<string, string> dependentApps = cl.ResolveDependency(p);
            Dictionary<string, List<string>> dependentApps2 = new Dictionary<string, List<string>>();
            if (dependentApps != null)
            {
                dependentApps2 = dependentApps.GroupBy(r => r.Value)
                      .ToDictionary(t => t.Key, t => t.Select(r => r.Key).ToList());
            }
            foreach (KeyValuePair<string, string> item in dependentApps)
            {
                TreeNode dependentAppNode = baseNode.Nodes[item.Value];
                if (dependentAppNode == null)
                {
                    DependencyDeployment.DependentApplicationProperties dProps = new DependencyDeployment.DependentApplicationProperties();
                    dependentAppNode = baseNode.Nodes.Add(item.Value, item.Value);
                    dependentAppNode.ImageIndex = 1;
                    dependentAppNode.SelectedImageIndex = 1;
                    dependentAppNode.ContextMenuStrip = contextMenuStripSelectDependentApp;
                    dProps.Assemblies = dependentApps2[item.Value];
                   // dProps.ActionsLoaded = false;
                    dProps.MsiSelected = false;
                    dProps.GuidInstalledApplication = RegistryHelper.GetUninstallGuid(item.Value, Environment.MachineName);
                    dependentAppNode.Tag = dProps;
                }
                //dependentAppNode.Nodes.Add(item.Key);
                LoadDependencies(item.Value, dependentAppNode);
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

        private void DisplayMessage(string message)
        {
            MessageBox.Show(message, "BTDT", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private DialogResult DisplayQuestion(string message)
        {
            return MessageBox.Show(message, "BTDT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }

        private DialogResult DisplayWarning(string message)
        {
            return MessageBox.Show(message, "BTDT", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        }

        private void LoadTargetEnvironments(string[] environments)
        {
            cbTargetEnvironment.Items.Clear();
            cbTargetEnvironment.Items.AddRange(environments);
            cbTargetEnvironment.SelectedItem = cbTargetEnvironment.Items.Contains(executingServer) ? executingServer : cbTargetEnvironment.Items[0];
        }


        private void LoadActions(string applicationName, string msiLocation, List<string> webDirectories)
        {
            listViewControl.Items.Clear();
            ListViewGroup mainapplicationGroup = new ListViewGroup("1", string.Format("{0}-----{1}", applicationName , "Un/deploy Actions"));
            listViewControl.Groups.Add(mainapplicationGroup);            
            foreach (BaseAction action in ActionFactory.CreateActions(applicationName, msiLocation, webDirectories))
            {
                Color statusColor = Color.SteelBlue;
                string initialMessage = string.Empty;
                if (!IsAdministrator() && action.IsAdminOnly)
                {
                    initialMessage = "This action will fail. Action needs Administrator privileges to run. Please run the tool as Administrator.";
                    statusColor = Color.Salmon;
                }
                InstallApplicationAction installAction = action as InstallApplicationAction;
                UnInstallApplicationAction UninstallAction = action as UnInstallApplicationAction;
                if (installAction != null && !GenericHelper.PingServer(installAction.ServerName))
                {
                    initialMessage = "This action will fail. The server is not reachable.";
                    statusColor = Color.Salmon;
                }

                if (UninstallAction != null && !GenericHelper.PingServer(UninstallAction.ServerName))
                {
                    initialMessage = "This action will fail. The server is not reachable.";
                    statusColor = Color.Salmon;
                }

                ListViewItem listViewItem = new ListViewItem(new string[] { action.DisplayName, "Not Executed", "Never", string.Empty, initialMessage }, mainapplicationGroup);
                listViewItem.SubItems[1].ForeColor = statusColor;
                listViewItem.SubItems[1].Font = new Font(lblMsiLoc.Font.Name, lblMsiLoc.Font.Size, FontStyle.Bold);
                listViewItem.UseItemStyleForSubItems = false;
                listViewItem.Tag = action;
                listViewControl.Items.Add(listViewItem);
            }
        }



        private void LoadInProgressServiceInstances(string applicationName)
        {
            terminateToolStripMenuItem.Enabled = false;
            saveToFileToolStripMenuItem.Enabled = false;
            DataTable dt = SQLHelper.GetAllInProgressServiceInstances(applicationName);
            instancesGridView.DataSource = dt;
            if (instancesGridView.Rows.Count > 0)
            {
                terminateToolStripMenuItem.Enabled = true;
                saveToFileToolStripMenuItem.Enabled = true;
            }
        }


        private void LoadSSOConfig()
        {
            try
            {
                string fileToOpen = string.Empty;
                if (openSsoFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        this.FormState = FormStateEnum.Processing;
                        fileToOpen = openSsoFileDialog.FileName;
                        txtSSOConfigLoc.Text = fileToOpen;
                        txtConfigAppName.Text = System.IO.Path.GetFileNameWithoutExtension(fileToOpen);
                        chkBxSSOKey.Visible = true;
                        txtBxSSOKey.Visible = true;
                        txtBxSSOKey.Text = ConfigurationManager.AppSettings["SSOKey"];
                    }
                    finally
                    {
                        this.FormState = FormStateEnum.NotProcessing;
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayError(ex);
            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            this.BeginExecuteCheckedActions();
        }

        #region Thread processing


        private void BeginExecuteSelectedActions()
        {
            if (this.ExecutionStarted != null)
                this.ExecutionStarted(new object(), new EventArgs());

            if (listViewControl.SelectedItems.Count == 0)
            {
                DisplayMessage("Please select action(s) to run.");
                return;
            }
            BeginExecuteActions(GetSelectedActions());
        }

        private void BeginExecuteCheckedActions()
        {
            if (this.ExecutionStarted != null)
                this.ExecutionStarted(new object(), new EventArgs());

            if (listViewControl.CheckedItems.Count == 0)
            {
                DisplayMessage("Please check action(s) to run.");
                return;
            }
            BeginExecuteActions(GetCheckedActions());
        }

        private void BeginExecuteActions(List<BaseAction> actions)
        {

            isInterrupted = false;
            // Change form state
            this.FormState = FormStateEnum.Processing;

            // Initialize thread
            if (threadProcessor == null)
            {
                threadProcessor = new ThreadProcessor();
                threadProcessor.Completed += new EventHandler<CompletedEventArgs>(threadProcessor_Completed);
                threadProcessor.ActionExecuting += new EventHandler<ActionExecutingEventArgs>(threadProcessor_ActionExecuting);
                threadProcessor.ActionExecuted += new EventHandler<ActionExecutedEventArgs>(threadProcessor_ActionExecuted);
            }

            //List<BaseAction> actions = GetCheckedActions();
            ActionFactory.UpdateActions(actions, GetActionParameters());

            //threadProcessor.AsyncRun(actions);
            threadProcessor.AsyncRunWorkUnits(actions);
        }


        private List<BaseAction> GetCheckedActions()
        {
            List<BaseAction> actions = new List<BaseAction>();

            foreach (ListViewItem item in listViewControl.Items)
            {
                if (item.Checked)
                {
                    actions.Add((BaseAction)item.Tag);
                }
            }
            return actions;
        }

        private List<BaseAction> GetSelectedActions()
        {
            List<BaseAction> actions = new List<BaseAction>();

            foreach (ListViewItem item in listViewControl.SelectedItems)
            {
                actions.Add((BaseAction)item.Tag);
            }
            return actions;
        }

        private ActionFactory.ActionParameters GetActionParameters()
        {
            ActionFactory.ActionParameters obj = new ActionFactory.ActionParameters();

            obj.SSOAppname = txtConfigAppName.Text;
            obj.SSOConfigLocation = txtSSOConfigLoc.Text;
            obj.SSOKey = txtBxSSOKey.Text;
            obj.TargetEnvironment = (string)cbTargetEnvironment.SelectedItem;
            obj.SSOCompanyName = ConfigurationManager.AppSettings["SSOCompanyName"];
            string msiTargetDir = ConfigurationManager.AppSettings["MsiTargetDirectory"];
            if (!string.IsNullOrEmpty(msiTargetDir))
            {
                obj.TargetDir = Path.Combine(msiTargetDir, txtAppName.Text);
            }
            return obj;
        }

        private ListViewItem GetListViewItem(BaseAction action)
        {
            foreach (ListViewItem item in listViewControl.Items)
            {
                if (item.Tag == action)
                {
                    return item;
                }
            }
            return null;
        }

        void threadProcessor_ActionExecuting(object sender, ActionExecutingEventArgs e)
        {
            if (this.InvokeRequired)
            {
                // We're on a thread other than the GUI thread
                this.Invoke(new MethodInvoker(() => threadProcessor_ActionExecuting(sender, e)));
                return;
            }

            UpdateLog(e.ActionStatus, e.RunTime, new TimeSpan(0, 0, 0), e.Message, GetListViewItem(e.Action));
        }

        void threadProcessor_ActionExecuted(object sender, ActionExecutedEventArgs e)
        {
            // Execute in same thread as ThreadProcessor
            if (isInterrupted)
            {
                e.Cancel = true;
            }

            UpdateLog(sender, e);
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

            UpdateLog(e.ActionStatus, e.RunTime, e.Elapsed, e.Message, GetListViewItem(e.Action));
        }

        void UpdateLog(object sender, ActionExecutingEventArgs e)
        {
            if (this.InvokeRequired)
            {
                // We're on a thread other than the GUI thread
                this.Invoke(new MethodInvoker(() => UpdateLog(sender, e)));
                return;
            }

            UpdateLog(e.ActionStatus, e.RunTime, new TimeSpan(0, 0, 0), e.Message, GetListViewItem(e.Action));
        }

        private void UpdateLog(ActionStatusEnum actionStatus, DateTime runTime, TimeSpan elapsed, string message, ListViewItem item)
        {
            Color color;
            string text;
            string lastRun;
            listViewControl.EnsureVisible(item.Index);
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
                    break;

                default:
                    text = "Failure";
                    color = Color.Red;
                    lastRun = runTime.ToString();
                    break;
            }

            item.SubItems[1].Text = text;
            item.SubItems[1].ForeColor = color;
            item.UseItemStyleForSubItems = false;
            item.SubItems[2].Text = lastRun;
            if (elapsed.TotalMilliseconds == 0)
            {
                item.SubItems[3].Text = "";
            }
            else
            {
                item.SubItems[3].Text = elapsed.ToString(@"hh\:mm\:ss\:fff");
            }
            item.SubItems[4].Text = message;
            item.ToolTipText = message;

            if (actionStatus == ActionStatusEnum.Succeeded)
            {
                try
                {
                    bool desiredValue = false;
                    _itemFlags.Create(item, desiredValue);
                    item.Checked = desiredValue;
                }
                finally
                {
                    _itemFlags.Remove(item);
                }
                item.Selected = false;
            }
        }

        public event EventHandler ExecutionStarted;
        public event EventHandler ExecutionComplete;

        public void EndExecuteActions()
        {
            this.FormState = FormStateEnum.NotProcessing;
            if (this.ExecutionComplete != null)
                this.ExecutionComplete(new object(), new EventArgs());
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportsHelper.CleanReport();
            this.Dispose();
            //this.Close();
        }

        private void btnToggle_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewControl.Items)
            {
                if (item.StateImageIndex != -1)
                    item.Checked = !item.Checked;
            }
        }

        private void executeActionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BeginExecuteSelectedActions();
        }

        private void listViewControl_MouseClick(object sender, MouseEventArgs e)
        {
            lstViewContextStrip = sender as ListView;
            if (e.Button == MouseButtons.Right)
            {
                if (listViewControl.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    listViewControl.ContextMenuStrip = contextMenuStripAction;
                }
            }
            else if (e.Button == MouseButtons.Left)
            {
                if (listViewControl.FocusedItem != null) rTxtBxMessage.Text = listViewControl.FocusedItem.ToolTipText;
            }
        }


        private void RestartToolStripMenuItemClickHandler(object sender, EventArgs e)
        {
            string message;
            this.Cursor = Cursors.WaitCursor;
            DialogResult res = System.Windows.Forms.DialogResult.Retry;
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            while (res == System.Windows.Forms.DialogResult.Retry)
            {
                RestartIISAction restartIISAction = new RestartIISAction(clickedItem.Text);
                restartIISAction.Execute(out message);
                res = AbortRetryIgnoreAction(message, clickedItem.Text);
            }
            this.Cursor = Cursors.Default;
        }

        private DialogResult AbortRetryIgnoreAction(string result, string param)
        {
            DialogResult res = new DialogResult();
            if (result.Contains("error"))
            {
                MessageBoxButtons buttonsRes = MessageBoxButtons.AbortRetryIgnore;
                res = MessageBox.Show("Failure restarting IIS server on :" + param, "Error", buttonsRes, MessageBoxIcon.Error);
            }
            else
            {
                MessageBoxButtons buttonsRes = MessageBoxButtons.OK;
                res = MessageBox.Show("IIS server successfully restarted on :" + param, "Success", buttonsRes, MessageBoxIcon.Information);
            }
            return res;
        }

        private void restartAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DialogResult res = System.Windows.Forms.DialogResult.Retry;
            while (res == System.Windows.Forms.DialogResult.Retry)
            {
                string result = IISHelper.RestartIIS();
                res = AbortRetryIgnoreAction(result, "All servers collectively.");
            }
            this.Cursor = Cursors.Default;
        }
        private void DBServerNameToolStripMenuItems()
        {
            // ToolStripMenuItem item = new ToolStripMenuItem(GlobalProperties.DatabaseServer);
            //databaseServerToolStripMenuItem.DropDownItems.Add(item);
        }
        private void messagingServersToolStripMenuItems(List<string> _serverList)
        {
        }

        private void listViewControl_DoubleClick(object sender, EventArgs e)
        {
            ListView doubledClickedItem = sender as ListView;
            if (doubledClickedItem != null && doubledClickedItem.Tag is CheckForInProgressInstancesAction)
            {
                InstancesPage.Show();
                tabControl.SelectTab(1);
                LoadInProgressServiceInstances(txtAppName.Text);
            }
        }

        private void terminateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result;
                result = DisplayQuestion("Are you sure you want to terminate selected service instance(s)?");
                if (result == DialogResult.OK)
                {
                    Instances = new List<DataGridViewCell>();
                    DataGridViewSelectedCellCollection instances = instancesGridView.SelectedCells;
                    var q = from instance in instances.Cast<DataGridViewCell>()
                            where !String.IsNullOrEmpty(instance.FormattedValue.ToString()) && instance.OwningColumn.DataPropertyName == Constants._SERVICE_INSTANCE_ID
                            select instance;
                    Instances = q.ToList();
                    progressBar1.Value = 0;
                    terminateWorkerIndex = 0;
                    swinstancesAction = new Stopwatch();
                    swinstancesAction.Start();
                    progressBar1.Maximum = this.Instances.Count;
                    List<BaseAction> actions = new List<BaseAction>();
                    foreach (DataGridViewCell val in Instances)
                    {
                        actions.Add(new TerminateInstancesAction(val.FormattedValue.ToString()));
                    }
                    BeginTerminating(actions);
                }
            }
            catch (Exception ex)
            {
                DisplayError(ex);
            }
        }

        private void BeginTerminating(List<BaseAction> actions)
        {
            isInterrupted = false;
            this.FormState = FormStateEnum.Processing;
            if (threadProcessor == null)
            {
                threadProcessor = new ThreadProcessor();
                threadProcessor.Completed += new EventHandler<CompletedEventArgs>(threadProcessor_TerminateCompleted);
                threadProcessor.ActionExecuting += new EventHandler<ActionExecutingEventArgs>(threadProcessor_TerminateActionExecuting);
                threadProcessor.ActionExecuted += new EventHandler<ActionExecutedEventArgs>(threadProcessor_TerminateActionExecuted);
            }
            //threadProcessor.AsyncRunControlledWorkUnits(actions, Environment.ProcessorCount);
            threadProcessor.AsyncRunAllWorkUnits(actions);
        }

        void threadProcessor_TerminateActionExecuting(object sender, ActionExecutingEventArgs e)
        {
            if (this.InvokeRequired)
            {
                // We're on a thread other than the GUI thread
                this.Invoke(new MethodInvoker(() => threadProcessor_TerminateActionExecuting(sender, e)));
                return;
            }
        }

        void threadProcessor_TerminateActionExecuted(object sender, ActionExecutedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                // We're on a thread other than the GUI thread
                this.Invoke(new MethodInvoker(() => threadProcessor_TerminateActionExecuted(sender, e)));
                return;
            }
            if (isInterrupted)
            {
                e.Cancel = true;
            }
            ProgressBar("Terminated");
            /*terminateWorkerIndex++;
            UpdateProgressBar(terminateWorkerIndex);*/

        }
        private void UpdateProgressBar(int progress)
        {
            progressBar1.Value = progress;
        }

        void threadProcessor_TerminateCompleted(object sender, CompletedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                // We're on a thread other than the GUI thread
                this.Invoke(new MethodInvoker(() => threadProcessor_TerminateCompleted(sender, e)));
                return;
            }
            EndExecuteTerminateActions();
            //LoadInProgressServiceInstances(txtAppName.Text);
            /*if (this.InvokeRequired)
            {
                // We're on a thread other than the GUI thread
                this.Invoke(new MethodInvoker(() => threadProcessor_Completed(sender, e)));
                return;
            }*/
        }

        public void EndExecuteTerminateActions()
        {
            LoadInProgressServiceInstances(txtAppName.Text);
            this.FormState = FormStateEnum.NotProcessing;
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == InstancesPage && !String.IsNullOrEmpty(txtAppName.Text))
            {
                LoadInProgressServiceInstances(txtAppName.Text);
            }
        }

        private void saveToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult resultMsg;
            resultMsg = DisplayWarning("Data contained in messages may be confidential.  Make sure the destination you choose is secure.");
            try
            {
                if (resultMsg == DialogResult.OK)
                {
                    if (folderSaveMessagesBrowserDialog.ShowDialog() == DialogResult.OK)
                    {
                        saveInstancesResult = new StringBuilder();
                        Instances = new List<DataGridViewCell>();
                        DataGridViewSelectedCellCollection instances = instancesGridView.SelectedCells;
                        var q = from instance in instances.Cast<DataGridViewCell>()
                                where !String.IsNullOrEmpty(instance.FormattedValue.ToString()) && instance.OwningColumn.DataPropertyName == Constants._SERVICE_INSTANCE_ID
                                select instance;
                        Instances = q.ToList();
                        progressBar1.Value = 0;
                        terminateWorkerIndex = 0;
                        swinstancesAction = new Stopwatch();
                        swinstancesAction.Start();
                        progressBar1.Maximum = this.Instances.Count;
                        List<BaseAction> actions = new List<BaseAction>();
                        foreach (DataGridViewCell val in Instances)
                        {
                            actions.Add(new SaveInstancesAction(val.FormattedValue.ToString(), folderSaveMessagesBrowserDialog.SelectedPath));
                        }
                        BeginSavingInstances(actions);
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayError(ex);
            }
        }

        private void BeginSavingInstances(List<BaseAction> actions)
        {
            isInterrupted = false;
            this.FormState = FormStateEnum.Processing;
            if (threadProcessor == null)
            {
                threadProcessor = new ThreadProcessor();
                threadProcessor.Completed += new EventHandler<CompletedEventArgs>(threadProcessor_SavingCompleted);
                threadProcessor.ActionExecuting += new EventHandler<ActionExecutingEventArgs>(threadProcessor_SavingActionExecuting);
                threadProcessor.ActionExecuted += new EventHandler<ActionExecutedEventArgs>(threadProcessor_SavingActionExecuted);
            }
            threadProcessor.AsyncRunControlledWorkUnits(actions, Environment.ProcessorCount);
        }

        void threadProcessor_SavingActionExecuting(object sender, ActionExecutingEventArgs e)
        {
            if (this.InvokeRequired)
            {
                // We're on a thread other than the GUI thread
                this.Invoke(new MethodInvoker(() => threadProcessor_SavingActionExecuting(sender, e)));
                return;
            }
        }

        void threadProcessor_SavingActionExecuted(object sender, ActionExecutedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                // We're on a thread other than the GUI thread
                this.Invoke(new MethodInvoker(() => threadProcessor_SavingActionExecuted(sender, e)));
                return;
            }
            if (isInterrupted)
            {
                e.Cancel = true;
            }
            if (!string.IsNullOrEmpty(e.Message))
            {
                saveInstancesResult.AppendLine(e.Message);
            }
            ProgressBar("Saved");
            /*terminateWorkerIndex++;
            UpdateProgressBar(terminateWorkerIndex);*/
        }

        void threadProcessor_SavingCompleted(object sender, CompletedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                // We're on a thread other than the GUI thread
                this.Invoke(new MethodInvoker(() => threadProcessor_SavingCompleted(sender, e)));
                return;
            }
            EndExecuteSaveActions();
            //LoadInProgressServiceInstances(txtAppName.Text);
            /*if (this.InvokeRequired)
            {
                // We're on a thread other than the GUI thread
                this.Invoke(new MethodInvoker(() => threadProcessor_Completed(sender, e)));
                return;
            }*/
        }

        private void EndExecuteSaveActions()
        {
            this.FormState = FormStateEnum.NotProcessing;
            if (saveInstancesResult.Length == 0)
            {
                DisplayMessage("Messages have been saved successfully.");
            }
            else
            {
                DisplayLog displayLog = new DisplayLog();
                displayLog.Log(saveInstancesResult.ToString());
                displayLog.ShowDialog();
            }
        }

        private void ProgressBar(string s)
        {
            lock (progressBar1)
            {
                terminateWorkerIndex++;
                label1.Text = string.Format("{0} {1} of {2} instance(s).Time elapsed {3}", s, terminateWorkerIndex, progressBar1.Maximum, swinstancesAction.Elapsed.ToString("c"));
                UpdateProgressBar(terminateWorkerIndex);
            }
        }


        private void applicationStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportsHelper.GenerateReport(Path.Combine(Path.GetTempPath(), Constants._INITIAL_STATUS_SUFFIX));
        }






        private void chkBxSSOKey_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBxSSOKey.Checked)
            {
                txtBxSSOKey.PasswordChar = '\0';
            }
            else
            {
                txtBxSSOKey.PasswordChar = '*';
            }
        }

        private void allServersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.FormState = FormStateEnum.Processing;
                DialogResult res = System.Windows.Forms.DialogResult.Retry;
                while (res == System.Windows.Forms.DialogResult.Retry)
                {
                    string result = IISHelper.RestartIIS();
                    res = AbortRetryIgnoreAction(result, "All servers collectively.");
                }
            }
            catch (Exception ex)
            {
                DisplayError(ex);
            }
            finally
            {
                this.FormState = FormStateEnum.Initial;
            }
        }

        private void StopThread()
        {
            isInterrupted = true;
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            StopThread();
        }

        private void clearBTDTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.FormState = FormStateEnum.Initial;
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reportOptionsForm.ShowDialog();
        }

        private void listViewControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            rTxtBxMessage.Text = listViewControl.FocusedItem != null ? listViewControl.FocusedItem.ToolTipText : string.Empty;
        }

        private void checkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewControl.SelectedItems)
            {
                item.Checked = true;
            }
        }

        private void uncheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewControl.SelectedItems)
            {
                item.Checked = false;
            }
        }

        private void runAllCheckedActionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.BeginExecuteCheckedActions();
        }

        private void contextMenuStripAction_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            runXSelectedActionsToolStripMenuItem.Text = string.Format("Run {0} selected action(s)", listViewControl.SelectedItems.Count);
            runAllCheckedActionsToolStripMenuItem.Text = string.Format("Run {0} checked action(s)", listViewControl.CheckedItems.Count);
        }

        private void generateInstructionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = @"C:\Temp\deploymentInstructions.txt";
            try
            {
                this.FormState = FormStateEnum.Processing;
                if (listViewControl.SelectedItems.Count == 0)
                {
                    DisplayMessage("Select actions for which instructions are required");
                    return;
                }
                GenerateDeploymentInstructions generateDeploymentInstructions = new GenerateDeploymentInstructions(path);
                if (!generateDeploymentInstructions.Generate(GetCheckedActions(), txtAppName.Text))
                {
                    DisplayError("Not generated");
                }
                ProcessStartInfo StartInfo = new ProcessStartInfo(path);
                var process = new System.Diagnostics.Process();
                process.StartInfo = StartInfo;
                process.Start();

            }
            catch (Exception ex)
            {
                DisplayError(ex);
            }
            finally
            {
                this.FormState = FormStateEnum.NotProcessing;
            }

        }

        private void msiInspectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MsiInspector msiInspector = new MsiInspector();
            msiInspector.Tag = txtMSILocation.Text;
            msiInspector.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MsiPackage misPackage = new MsiPackage(txtMSILocation.Text);
            string installationGuid = misPackage.GetMsiProperty("ProductCode");
            LoadInstallationTip(installationGuid);
        }

        private void LoadInstallationTip(string installationGuid)
        {
            StringBuilder sb = new StringBuilder();
            bool result = RegistryHelper.IsMsiInstalled(installationGuid, Environment.MachineName);
            string message = result ? "This msi is already installed on current machine." : "This msi is not installed on current machine.";
            sb.AppendLine(message);
            sb.AppendLine();
            sb.AppendLine("Please use 'Deployment Health Check' tool for more details.");
            if (result)
            {
                DisplayWarning(sb.ToString());
            }
            else
            {
                DisplayMessage(sb.ToString());
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMSILocation.Text))
            {
                return;
            }
            MsiPackage misPackage = new MsiPackage(txtMSILocation.Text);
            string installationGuid = misPackage.GetMsiProperty("ProductCode");
            LoadInstallationTip(installationGuid);
        }

        private void listViewControl_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            switch (_formState)
            {
                case FormStateEnum.Initial:
                case FormStateEnum.NotProcessing:
                    break;
                case FormStateEnum.Processing:
                    ListViewItem item = listViewControl.Items[e.Index];
                    if (_itemFlags.Exists(item))
                    {
                        e.NewValue = _itemFlags[item] ? CheckState.Checked : CheckState.Unchecked;
                    }
                    else
                    {
                        e.NewValue = e.CurrentValue;
                    }

                    break;
                default:
                    break;
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            this.FormState = FormStateEnum.Initial;
        }

        /* private void tabPage2_Enter(object sender, EventArgs e)
         {
             if (tabControl.TabPages[0].Text != Constants._UNDEPLOY_ACTION_PAGE_TEXT)
             {
                 LoadApplications();
             }
         }*/

        private void LoadSSOApplications()
        {

            //comboBoxSSOAppList.Items.AddRange(SSOHelper.GetAllSSOconfig());
        }
        /*private void LoadApplications()
        {
            comboBxAppList.Items.Clear();
            ApplicationCollection appCollection = new ApplicationCollection();
            appCollection = explorerHelper.GetApplicationCollection();
            List<string> appList = explorerHelper.GetApplicationList(appCollection);
            comboBxAppList.Items.AddRange(RemoveSystemApplication(appList).ToArray());

        }*/
        private List<string> RemoveSystemApplication(List<string> applicationNameList)
        {
            applicationNameList.Remove("BizTalk.System");
            applicationNameList.Remove("BizTalk Application 1");
            applicationNameList.Remove("BizTalk EDI Application");
            return applicationNameList;
        }

        /*private void comboBxAppList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FormState = FormStateEnum.Processing;
            LoadUnDeployActions(comboBxAppList.Text);
            tabControl.TabPages[0].Text = Constants._UNDEPLOY_ACTION_PAGE_TEXT;
            UpdateFarmDeployTab();
            this.FormState = FormStateEnum.NotProcessing;
        }*/

        private void UpdateFarmDeployTab()
        {
            txtSSOConfigLoc.Text = string.Empty;
            txtBxSSOKey.Text = string.Empty;
            txtConfigAppName.Text = string.Empty;
            txtAppName.Text = string.Empty;
            txtMSILocation.Text = string.Empty;
            cbTargetEnvironment.Items.Clear();
        }

        private void LoadUnDeployActions(string applicationName)
        {
            listViewControl.Items.Clear();
            foreach (BaseAction action in ActionFactory.CreateUnDeployActions(applicationName))
            {
                Color statusColor = Color.SteelBlue;
                string initialMessage = string.Empty;
                if (!IsAdministrator() && action.IsAdminOnly)
                {
                    initialMessage = "This action will fail. Action needs Administrator privileges to run. Please run the tool as Administrator.";
                    statusColor = Color.Salmon;
                }
                ListViewItem listViewItem = new ListViewItem(new string[] { action.DisplayName, "Not Executed", "Never", string.Empty, initialMessage });
                listViewItem.SubItems[1].ForeColor = statusColor;
                listViewItem.SubItems[1].Font = new Font(lblMsiLoc.Font.Name, lblMsiLoc.Font.Size, FontStyle.Bold);
                listViewItem.UseItemStyleForSubItems = false;
                listViewItem.Tag = action;
                listViewControl.Items.Add(listViewItem);
            }
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(txtSSOConfigLoc.Text) && tabControl.TabPages[0].Text == Constants._DEPLOY_ACTION_PAGE_TEXT)
            {
                UpdateSSOActionsList();
            }
        }

        private void selectMsiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DependencyDeployment.SelectMsi selectMsi = new DependencyDeployment.SelectMsi(treeViewDependency.SelectedNode.Text);
            DialogResult dr = selectMsi.ShowDialog();
            if (dr == DialogResult.OK)
            {
                DependencyDeployment.DependentApplicationProperties dProps = treeViewDependency.SelectedNode.Tag as DependencyDeployment.DependentApplicationProperties;
                dProps.MsiLocation = selectMsi.MsiLocation;
                dProps.Environment = selectMsi.TargetEnv;
                dProps.MsiSelected = true;
                dProps.GuidApplicationMsi = selectMsi.ApplicationMsiGuid;
                treeViewDependency.SelectedNode.Tag = dProps;
                PopulatePropertyGrid(dProps);
                treeViewDependency.SelectedNode.ImageIndex = 2;
                treeViewDependency.SelectedNode.SelectedImageIndex = 2;
            }
        }

        private void loadActionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReverseTravers(treeViewDependency.Nodes, 1);
            SortListViewGroup();
            tabControl.SelectedTab = tabControl.TabPages[0];
            allDependentActionsLoaded = true;
            StabilizeFormForDependency();

        }

        private void StabilizeFormForDependency()
        {
            loadActionsToolStripMenuItem.Enabled = false;
            selectMsiToolStripMenuItem.Enabled = false;
            btnBrowseConfig.Enabled = false;
            tabControl.TabPages[2].ImageIndex = 1;
            treeViewDependency.TopNode.SelectedImageIndex = 2;
            treeViewDependency.TopNode.ImageIndex = 2;
        }

        private void SortListViewGroup()
        {
            ListViewGroup[] groups = new ListViewGroup[listViewControl.Groups.Count];
            listViewControl.Groups.CopyTo(groups, 0);
            for (int i = 0; i < listViewControl.Groups.Count; i++)
            {
                groups[i] = listViewControl.Groups[i];
            }
            Array.Sort(groups, new GroupComparer());
            listViewControl.BeginUpdate();
            listViewControl.Groups.Clear();

            listViewControl.Groups.AddRange(groups);
            listViewControl.EndUpdate();

            //listViewControl.Items.Clear();
            Dictionary<ListViewItem, ListViewGroup> listLVI = new Dictionary<ListViewItem, ListViewGroup>();
            foreach (ListViewGroup lvg in listViewControl.Groups)
            {
                foreach (ListViewItem item in lvg.Items)
                {
                    listLVI.Add(item, lvg);
                }
            }
            listViewControl.Items.Clear();
            foreach (KeyValuePair<ListViewItem, ListViewGroup> item in listLVI)
            {
                item.Key.Group = item.Value;
                listViewControl.Items.Add(item.Key);
            }

        }

        class GroupComparer : IComparer
        {
            public int Compare(object objA, object objB)
            {
                return -Convert.ToInt32(((ListViewGroup)objA).Name).CompareTo(Convert.ToInt32(((ListViewGroup)objB).Name));
            }
        }


        void ReverseTravers(TreeNodeCollection nodes, int depth)
        {
            if (nodes == null) return;
            foreach (TreeNode child in nodes)
            {
                ReverseTravers(child.Nodes, depth + 1);
                if (child.Text != txtAppName.Text)
                    LoadActionsForDependentApps(child, depth);
            }
        }

        private void LoadActionsForDependentApps(TreeNode child, int depth)
        {
            DependencyDeployment.DependentApplicationProperties appProps = child.Tag as DependencyDeployment.DependentApplicationProperties;
            if (appProps != null)
            {
                ListViewGroup mainapplicationGroup = new ListViewGroup(depth.ToString(), string.Format("{0}----{1}",child.Text ,"Undeploy Actions"));
                listViewControl.Groups.Add(mainapplicationGroup);
                foreach (BaseAction action in ActionFactory.CreateUnDeployDependentAppsActions(child.Text, appProps.MsiLocation))
                {
                    Color statusColor = Color.SteelBlue;
                    string initialMessage = string.Empty;
                    if (!IsAdministrator() && action.IsAdminOnly)
                    {
                        initialMessage = "This action will fail. Action needs Administrator privileges to run. Please run the tool as Administrator.";
                        statusColor = Color.Salmon;
                    }
                    UnInstallApplicationAction UninstallAction = action as UnInstallApplicationAction;

                    if (UninstallAction != null && !GenericHelper.PingServer(UninstallAction.ServerName))
                    {
                        initialMessage = "This action will fail. The server is not reachable.";
                        statusColor = Color.Salmon;
                    }
                    ListViewItem listViewItem = new ListViewItem(new string[] { action.DisplayName, "Not Executed", "Never", string.Empty, initialMessage }, mainapplicationGroup);
                    listViewItem.SubItems[1].ForeColor = statusColor;
                    listViewItem.SubItems[1].Font = new Font(lblMsiLoc.Font.Name, lblMsiLoc.Font.Size, FontStyle.Bold);
                    listViewItem.UseItemStyleForSubItems = false;
                    listViewItem.Tag = action;
                    listViewControl.Items.Add(listViewItem);
                }


                mainapplicationGroup = new ListViewGroup((-depth).ToString(), string.Format("{0}-----{1}", child.Text , "Deploy Actions"));
                listViewControl.Groups.Add(mainapplicationGroup);
                foreach (BaseAction action in ActionFactory.CreateDeployDependentAppsActions(child.Text, appProps.MsiLocation, appProps.Environment))
                {
                    Color statusColor = Color.SteelBlue;
                    string initialMessage = string.Empty;
                    if (!IsAdministrator() && action.IsAdminOnly)
                    {
                        initialMessage = "This action will fail. Action needs Administrator privileges to run. Please run the tool as Administrator.";
                        statusColor = Color.Salmon;
                    }
                    InstallApplicationAction installAction = action as InstallApplicationAction;

                    if (installAction != null && !GenericHelper.PingServer(installAction.ServerName))
                    {
                        initialMessage = "This action will fail. The server is not reachable.";
                        statusColor = Color.Salmon;
                    }
                    ListViewItem listViewItem = new ListViewItem(new string[] { action.DisplayName, "Not Executed", "Never", string.Empty, initialMessage }, mainapplicationGroup);
                    listViewItem.SubItems[1].ForeColor = statusColor;
                    listViewItem.SubItems[1].Font = new Font(lblMsiLoc.Font.Name, lblMsiLoc.Font.Size, FontStyle.Bold);
                    listViewItem.UseItemStyleForSubItems = false;
                    listViewItem.Tag = action;
                    listViewControl.Items.Add(listViewItem);
                }
            }
        }
        private void treeViewDependency_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeViewDependency.SelectedNode = e.Node;
            if (e.Button == MouseButtons.Right)
            {
                loadActionsToolStripMenuItem.Enabled = false;
                bool allResolved = true;
                foreach (TreeNode item in treeViewDependency.Nodes.FlattenTree())
                {
                    DependencyDeployment.DependentApplicationProperties props = item.Tag as DependencyDeployment.DependentApplicationProperties;
                    if (props != null)
                        allResolved = allResolved && props.MsiSelected;
                }
                if (allResolved)
                {
                    loadActionsToolStripMenuItem.Enabled = true;
                }
                if (allResolved && allDependentActionsLoaded)
                {
                    loadActionsToolStripMenuItem.Enabled = false;
                }
            }
        }

        

        private void PopulatePropertyGrid(object obj)
        {
            if (obj != null)
            {
                //TypeDescriptor.AddAttributes(obj, new Attribute[] { new ReadOnlyAttribute(true) });
            }
            propertyGridDepApps.SelectedObject = obj;
        }

        private void treeViewDependency_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null)
            {
                PopulatePropertyGrid(e.Node.Tag);
            }
        }
    }
}

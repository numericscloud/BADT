using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BizTalkDeploymentTool.Helpers;
using System.IO;
using Microsoft.Deployment.WindowsInstaller;
using BizTalkDeploymentTool.Actions;
using System.Security.Principal;
using System.Xml;
using System.Configuration;
using System.Diagnostics;
using System.Collections;
using BizTalkDeploymentTool.Extensions;

namespace BizTalkDeploymentTool
{
    public partial class BTDFMsiDeploy : UserControl
    {

        private bool isInterrupted;
        List<DataGridViewCell> Instances = null;
        Stopwatch swinstancesAction = new Stopwatch();
        StringBuilder saveInstancesResult = new StringBuilder();
        private static int terminateWorkerIndex = 0;
        public string extractPath { get; set; }
        ListView lstViewContextStrip = new ListView();
        ThreadProcessor threadProcessor = null;
        ItemFlags<ListViewItem, bool> _itemFlags = new ItemFlags<ListViewItem, bool>();

        public BTDFMsiDeploy()
        {
            this.Dock = DockStyle.Fill;
            InitializeComponent();
            SetFormSize();
            listViewControl.DoubleBuffered(true);
        }
        private void SetFormSize()
        {
            this.Width = (Screen.PrimaryScreen.WorkingArea.Width / 100) * 90;
            this.Height = (Screen.PrimaryScreen.WorkingArea.Height / 100) * 90;
        }

        public enum FormStateEnum
        {
            Initial,
            NotProcessing,
            Processing,
            End
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

                    btnExecute.Visible = false;
                    btnClear.Visible = false;
                    btnStop.Visible = false;
                    btnToggle.Visible = false;
                    chkBoxUnDeploy.Checked = true;
                    cbTargetEnvironment.DataSource = null;
                    txtAppName.Text = string.Empty;
                    txtMSILocation.Text = string.Empty;
                    textBoxInstallLocation.Text = string.Empty;
                    rTxtBxMessage.Text = string.Empty;
                    textBoxBTDFProjName.Text = string.Empty;
                    listViewControl.Groups.Clear();
                    listViewControl.Items.Clear();
                    grpBxMSI.Enabled = true;
                    terminateToolStripMenuItem.Enabled = false;
                    saveToFileToolStripMenuItem.Enabled = false;
                    DeleteTempBTDFMsiExtractedFolder();
                    UpdateCursor(Cursors.Default);
                    break;

                case FormStateEnum.End:

                    UpdateCursor(Cursors.Default);
                    chkBoxUnDeploy.Enabled = false;
                    cbTargetEnvironment.Enabled = false;
                    btnExecute.Enabled = true;
                    btnClear.Enabled = true;
                    threadProcessor = null;
                    grpBxMSI.Enabled = true;
                    CleanTempExtraction();
                    break;

                case FormStateEnum.NotProcessing:
                    btnToggle.Visible = true;
                    btnStop.Visible = true;
                    btnExecute.Visible = true;
                    btnClear.Visible = true;
                    btnClear.Enabled = true;
                    btnExecute.Enabled = true;
                    chkBoxUnDeploy.Enabled = true;
                    cbTargetEnvironment.Enabled = true;
                    threadProcessor = null;
                    grpBxMSI.Enabled = true;
                    UpdateCursor(Cursors.Default);
                    break;

                case FormStateEnum.Processing:
                    btnExecute.Enabled = false;
                    btnClear.Enabled = false;
                    chkBoxUnDeploy.Enabled = false;
                    cbTargetEnvironment.Enabled = false;
                    grpBxMSI.Enabled = false;
                    UpdateCursor(Cursors.WaitCursor);
                    break;

            }
        }

        private void CleanTempExtraction()
        {
            bool allActionExecuted = true;
            foreach (ListViewItem item in listViewControl.Items)
            {
                if(item.SubItems[1].Text == "Not Executed")
                {
                    allActionExecuted = false;
                    break;
                }
            }
            if(allActionExecuted)
            {
                DeleteTempBTDFMsiExtractedFolder();
            }
        }

        private void DeleteTempBTDFMsiExtractedFolder()
        {
            if (Directory.Exists(extractPath))
                    Directory.Delete(extractPath, true);
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


        public event EventHandler ExecutionStarted;
        public event EventHandler ExecutionComplete;

        private void btnBrowseMSI_Click(object sender, EventArgs e)
        {
            string fileToOpen = string.Empty;
            listViewControl.Items.Clear();
            DeleteTempBTDFMsiExtractedFolder();
            try
            {
                if (openMsiFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileToOpen = openMsiFileDialog.FileName;
                    txtMSILocation.Text = fileToOpen;
                    extractPath = ExtractBTDFMsi(fileToOpen);
                    if (Directory.Exists(extractPath))
                    {
                        string productName; string productCode;
                        string btdfProjFile = PopulateBTDFProjectName(extractPath);
                        string applicationName = ReadAppNameFromBTDFProjectFile(btdfProjFile, out productName, out productCode);
                        PopulateEnvironment(extractPath);
                        LoadActions(applicationName, productName, productCode, fileToOpen);
                        LoadInProgressServiceInstances(txtAppName.Text);
                    }
                    else
                    {
                        DisplayError(string.Format("Can not extract BTDF msi to {0} for futher actions.", extractPath));
                    }
                }
            }
            catch (Exception exe)
            {
                DisplayError(exe);
            }
            finally
            {
                this.FormState = FormStateEnum.NotProcessing;
            }

        }

        private void LoadActions(string applicationName, string productName, string productCode, string fileToOpen)
        {
            foreach (BaseAction action in ActionFactory.CreateBTDFActions(applicationName, fileToOpen, textBoxInstallLocation.Text, productName, productCode))
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
                ListViewItem listViewItem = new ListViewItem(new string[] { action.DisplayName, "Not Executed", "Never", string.Empty, initialMessage });

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

        private string ReadAppNameFromBTDFProjectFile(string btdfProjFile, out string productName, out string productVersion)
        {
            productName = "";
            productVersion = "";
            string data = File.ReadAllText(btdfProjFile);
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(btdfProjFile);
            XmlNode xNode = xDoc.SelectSingleNode("//*[local-name()='ProjectName']");
            if (xNode != null)
            {
                txtAppName.Text = xNode.InnerText;
                productName = xDoc.SelectSingleNode("//*[local-name()='ProductName']").InnerText;
                productVersion = xDoc.SelectSingleNode("//*[local-name()='ProductId']").InnerText;
                string projectVersion = xDoc.SelectSingleNode("//*[local-name()='ProjectVersion']").InnerText;
                textBoxInstallLocation.Text = Path.Combine(ConfigurationManager.AppSettings["MsiTargetDirectory"], productName, projectVersion);
                return xNode.InnerText;
            }
            else
            {
                txtAppName.Text = "No ProjectName element defined in BTDFProj";
                return txtAppName.Text;
            }
        }

        public static bool IsAdministrator()
        {
            return (new WindowsPrincipal(WindowsIdentity.GetCurrent()))
                    .IsInRole(WindowsBuiltInRole.Administrator);
        }

        private Dictionary<string, string> PopulateEnvironment(string extractPath)
        {
            Dictionary<string, string> bindings = new Dictionary<string, string>();

            string[] files = Directory.GetFiles(extractPath, Constants._BTDF_SETTINGSFILENAMEFILTER, SearchOption.AllDirectories);
            string[] fileESE = Directory.GetFiles(extractPath, "EnvironmentSettingsExporter.exe", SearchOption.AllDirectories);

            if (fileESE.Count() == 1 && files.Count() == 1)
            {
                string settingFileDirectory = Path.GetDirectoryName(files[0]);
                string result = "";
                BTDFDeployHelper.ExecuteEnvironmentSettingsExporter(fileESE[0].Encode(), files[0].Encode() + " " + settingFileDirectory.Encode(), out result);
                string[] envFiles = Directory.GetFiles(settingFileDirectory);
                ArrayList myArr = new ArrayList();
                foreach (string envFile in envFiles)
                {
                    myArr.Add(envFile);
                }
                myArr.Remove(files[0]);
                foreach (string envFile in myArr)
                {
                    bindings.Add(Path.GetFileNameWithoutExtension(envFile), envFile);
                }
                cbTargetEnvironment.DataSource = new BindingSource(bindings, null);
                cbTargetEnvironment.DisplayMember = "Key";
                cbTargetEnvironment.ValueMember = "Value";
            }
            else
            {
                cbTargetEnvironment.DataSource = null;
                DisplayMessage(string.Format("Can not find a valid SettingsFileGenerator. There are {0} SettingsFileGenerator files present ", files.Count()));

            }
            return bindings;
        }

        private string PopulateBTDFProjectName(string extractPath)
        {
            string[] files = Directory.GetFiles(extractPath, "*.btdfproj", SearchOption.AllDirectories);
            if (files.Count() == 1)
            {
                textBoxBTDFProjName.Text = Path.GetFileName(files[0]);
                return files[0];
            }
            else
            {
                DisplayError(string.Format("Can not find a valid .btdfproj. There are {0} .btdfproj files present ", files.Count()));
                return "";
            }

        }

        private string ExtractBTDFMsi(string fileToOpen)
        {
            string appNamefromMsi = Path.GetFileNameWithoutExtension(fileToOpen);
            string extractPath = Path.Combine(GenericHelper.GetTempFolder(Environment.MachineName), System.Guid.NewGuid().ToString());
            string result = "";
            string args = string.Format(@"/a ""{0}"" /qn TARGETDIR=""{1}"" REINSTALLMODE=amus", fileToOpen, extractPath);
            BTDFDeployHelper.ExecuteMsiExecTask(args, out result);
            return extractPath;
        }

        private void btnToggle_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewControl.Items)
            {
                if (item.StateImageIndex != -1)
                    item.Checked = !item.Checked;
            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            this.BeginExecuteCheckedActions();
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

        private ActionFactory.ActionParameters GetActionParameters()
        {
            ActionFactory.ActionParameters obj = new ActionFactory.ActionParameters();
            if (cbTargetEnvironment.SelectedItem != null)
            {
                KeyValuePair<string, string> env = (KeyValuePair<string, string>)cbTargetEnvironment.SelectedItem;
                obj.TargetEnvironment = env.Key;
            }
            obj.TargetDir = textBoxInstallLocation.Text;
            obj.UnDeployExistingApplication = chkBoxUnDeploy.Checked.ToString();

            return obj;
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

        public void EndExecuteActions()
        {
            this.FormState = FormStateEnum.End;
            if (this.ExecutionComplete != null)
                this.ExecutionComplete(new object(), new EventArgs());
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

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopThread();
        }
        private void StopThread()
        {
            isInterrupted = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.FormState = FormStateEnum.Initial;
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
        private void ProgressBar(string s)
        {
            lock (progressBar1)
            {
                terminateWorkerIndex++;
                label3.Text = string.Format("{0} {1} of {2} instance(s).Time elapsed {3}", s, terminateWorkerIndex, progressBar1.Maximum, swinstancesAction.Elapsed.ToString("c"));
                UpdateProgressBar(terminateWorkerIndex);
            }
        }

        private void UpdateProgressBar(int progress)
        {
            progressBar1.Value = progress;
        }

        private DialogResult DisplayQuestion(string message)
        {
            return MessageBox.Show(message, "BTDT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
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
        private DialogResult DisplayWarning(string message)
        {
            return MessageBox.Show(message, "BTDT", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        }

        private void listViewControl_MouseClick(object sender, MouseEventArgs e)
        {
            lstViewContextStrip = sender as ListView;
            if (e.Button == MouseButtons.Right)
            {

            }
            else if (e.Button == MouseButtons.Left)
            {
                if (listViewControl.FocusedItem != null) rTxtBxMessage.Text = listViewControl.FocusedItem.ToolTipText;
            }
        }

        private void listViewControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            rTxtBxMessage.Text = listViewControl.FocusedItem != null ? listViewControl.FocusedItem.ToolTipText : string.Empty;
        }
    }
}

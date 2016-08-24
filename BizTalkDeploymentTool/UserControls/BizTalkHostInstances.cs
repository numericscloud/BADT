using BizTalkDeploymentTool.Actions;
using BizTalkDeploymentTool.Helpers;
using BizTalkDeploymentTool.Wmi;
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
using BizTalkDeploymentTool.Global;
using Microsoft.BizTalk.ExplorerOM;
using System.Globalization;

namespace BizTalkDeploymentTool
{
    public partial class BizTalkHostInstances : UserControl
    {
        ThreadProcessor threadProcessor = null;
        bool isInterrupted = false;
        ItemFlags<ListViewItem, bool> _itemFlags = new ItemFlags<ListViewItem, bool>();
        ExplorerOMHelper explorerHelper = new ExplorerOMHelper(GlobalProperties.MgmtDBServer, GlobalProperties.MgmtDBName);
        ApplicationCollection appCollection = new ApplicationCollection();
        public event EventHandler ExecutionStarted;
        public event EventHandler ExecutionComplete;

        public BizTalkHostInstances()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
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
                    comboBxAppList.Enabled = true;
                    btnStart.Enabled = true;
                    button1.Enabled = true;
                    btnStop.Enabled = true;
                    UpdateCursor(Cursors.Default);
                    break;

                case FormStateEnum.NotProcessing:
                    comboBxAppList.Enabled = true;
                    btnStart.Enabled = true;
                    button1.Enabled = true;
                    btnStop.Enabled = true;
                    UpdateCursor(Cursors.Default);
                    break;

                case FormStateEnum.Processing:
                    comboBxAppList.Enabled = false;
                    btnStart.Enabled = false;
                    button1.Enabled = false;
                    btnStop.Enabled = false;
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
        private void BeginExecuteCheckedActions()
        {
            if (listViewControl.CheckedItems.Count == 0)
            {
                DisplayMessage("Please check action(s) to run.");
                return;
            }
            BeginExecuteActions(GetCheckedActions());
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

        private void DisplayMessage(string message)
        {
            MessageBox.Show(message, "BTDT", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BeginExecuteActions(List<BaseAction> actions)
        {
            // Change form state
            this.FormState = FormStateEnum.Processing;
            if (this.ExecutionStarted != null)
                this.ExecutionStarted(new object(), new EventArgs());

            // Initialize thread
            if (threadProcessor == null)
            {
                threadProcessor = new ThreadProcessor();
                threadProcessor.Completed += new EventHandler<CompletedEventArgs>(threadProcessor_Completed);
                threadProcessor.ActionExecuting += new EventHandler<ActionExecutingEventArgs>(threadProcessor_ActionExecuting);
                threadProcessor.ActionExecuted += new EventHandler<ActionExecutedEventArgs>(threadProcessor_ActionExecuted);
            }
            //threadProcessor.AsyncRun(actions);
            threadProcessor.AsyncRunAllWorkUnits(actions);
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
            this.FormState = FormStateEnum.NotProcessing;
            if (this.ExecutionComplete != null)
                this.ExecutionComplete(new object(), new EventArgs());
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
            HostInstance hi = ((RestartHostInstanceAction)item.Tag).HostInstance;
            item.SubItems[1].Text = hi.RefreshedServiceState().ToString();
            item.SubItems[3].Text = text;
            item.SubItems[3].ForeColor = color;
            item.UseItemStyleForSubItems = false;
            item.SubItems[4].Text = lastRun;
            if (elapsed.TotalMilliseconds == 0)
            {
                item.SubItems[5].Text = "";
            }
            else
            {
                item.SubItems[5].Text = elapsed.ToString(@"hh\:mm\:ss\:fff");
            }
            item.SubItems[6].Text = message;
            item.ToolTipText = message;
            item.Checked = true;
            /* if (actionStatus == ActionStatusEnum.Succeeded)
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
             }*/
        }

        private void listViewControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && listViewControl.FocusedItem != null)
            {
                richTextBox1.Text = listViewControl.FocusedItem.ToolTipText;
            }
        }



        private void RetstartHostInstances_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
            /* else if (threadProcessor != null && threadProcessor.IsRunning)
             {
                 DialogResult result = DisplayQuestion("Actions are still executing. Do you want to close ?");
                 e.Cancel = (result == DialogResult.Cancel);
             }*/

        }
        private DialogResult DisplayQuestion(string message)
        {
            return MessageBox.Show(message, "BTDT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }

        private void RetstartHostInstances_Load(object sender, EventArgs e)
        {
            listViewControl.DoubleBuffered(true);
            LoadApplications();
           /* foreach (BaseAction action in ActionFactory.CreateRestartHostInstancesActions())
            {
                Color statusColor = Color.SteelBlue;
                string initialMessage = string.Empty;
                RestartHostInstanceAction hostInstanceAction = action as RestartHostInstanceAction;
                ListViewItem listViewItem = new ListViewItem(new string[] { hostInstanceAction.HostInstance.HostName, hostInstanceAction.HostInstance.RunningServer.ToUpper(), "Not Executed", "Never", string.Empty, initialMessage });
                listViewItem.SubItems[2].ForeColor = statusColor;
                listViewItem.SubItems[2].Font = new Font(button1.Font.Name, button1.Font.Size, FontStyle.Bold);
                listViewItem.UseItemStyleForSubItems = false;
                listViewItem.Tag = action;
                listViewItem.Checked = true;
                listViewControl.Items.Add(listViewItem);
            }*/
            comboBxAppList.Text = "All Host Instances";
        }

        private void LoadApplications()
        {
            appCollection = explorerHelper.GetApplicationCollection();
            List<string> appList = explorerHelper.GetApplicationList(appCollection);
            comboBxAppList.Items.Add("All Host Instances");
            comboBxAppList.Items.AddRange(RemoveSystemApplication(appList).ToArray());
        }
        private List<string> RemoveSystemApplication(List<string> applicationNameList)
        {
            applicationNameList.Remove("BizTalk.System");
            applicationNameList.Remove("BizTalk Application 1");
            applicationNameList.Remove("BizTalk EDI Application");
            return applicationNameList;
        }

        private void comboBxAppList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string appName = comboBxAppList.Text;
            listViewControl.Items.Clear();
            if (appName != "All Host Instances")
            {
                foreach (BaseAction action in ActionFactory.CreateRestartHostInstancesActions(appName))
                {
                    LoadListView(action);
                }
            }
            else
            {
                foreach (BaseAction action in ActionFactory.CreateRestartHostInstancesActions())
                {
                    LoadListView(action);
                }
            }
        }

        private void LoadListView(BaseAction action)
        {
            Color statusColor = Color.SteelBlue;
            string initialMessage = string.Empty;
            RestartHostInstanceAction hostInstanceAction = action as RestartHostInstanceAction;          
            ListViewItem listViewItem = new ListViewItem(new string[] { hostInstanceAction.HostInstance.HostName,hostInstanceAction.HostInstance.ServiceState.ToString(), hostInstanceAction.HostInstance.RunningServer.ToUpper(), "Not Executed", "Never", string.Empty, initialMessage });
            listViewItem.SubItems[3].ForeColor = statusColor;
            listViewItem.SubItems[3].Font = new Font(button1.Font.Name, button1.Font.Size, FontStyle.Bold);
            listViewItem.UseItemStyleForSubItems = false;
            listViewItem.Tag = action;
            listViewItem.Checked = true;
            listViewControl.Items.Add(listViewItem);
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

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewControl.Items)
            {
                item.Tag = new RestartHostInstanceAction(false, ((RestartHostInstanceAction)item.Tag).HostInstance, false, false);
            }
            Run();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewControl.Items)
            {
                item.Tag = new RestartHostInstanceAction(false, ((RestartHostInstanceAction)item.Tag).HostInstance, true, false);
            }
            Run();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewControl.Items)
            {
                item.Tag = new RestartHostInstanceAction(false, ((RestartHostInstanceAction)item.Tag).HostInstance, false, true);
            }
            Run();
        }

        private void Run()
        {
            this.BeginExecuteCheckedActions();
        }

    }
}

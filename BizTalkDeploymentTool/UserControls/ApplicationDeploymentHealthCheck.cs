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
using Microsoft.BizTalk.ExplorerOM;

namespace BizTalkDeploymentTool
{
    public partial class ApplicationDeploymentHealthCheck : UserControl
    {
        string formText;
        ThreadProcessor threadProcessor = null;
        ExplorerOMHelper explorerHelper = new ExplorerOMHelper(GlobalProperties.MgmtDBServer, GlobalProperties.MgmtDBName);
        List<string> serverList = GlobalProperties.MessagingServers;
        ApplicationCollection appCollection = new ApplicationCollection();
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
                    comboBxAppList.Enabled = true;
                    btnCheck.Enabled = true;
                    break;

                case FormStateEnum.NotProcessing:
                    UpdateCursor(Cursors.Default);
                    break;

                case FormStateEnum.Processing:
                    UpdateCursor(Cursors.WaitCursor);
                    comboBxAppList.Enabled = false;
                    btnCheck.Enabled = false;
                    break;

            }
        }

        private void UpdateCursor(Cursor cursor)
        {
            this.Cursor = cursor;
        }

        public ApplicationDeploymentHealthCheck()
        {
            InitializeComponent();
            listViewResources.DoubleBuffered(true);
        }


        private void DeploymentHealthCheck_Load(object sender, EventArgs e)
        {
            LoadApplications();
            formText = this.Text;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            this.FormState = FormStateEnum.Processing;
            this.CheckInstallHealth();
            this.BeginGacCheckAction();
        }

       

        private void LoadViews()
        {
            if (String.IsNullOrEmpty(comboBxAppList.Text))
            {
                DisplayError("No Application selected or typed in for health check. Please provide one.");
            }
            else
            {
                this.LoadListViewWithServers();
                this.LoadGacCheckListView();
                this.LoadResources(comboBxAppList.Text);
            }
        }

        private void CheckInstallHealth()
        {
            foreach (ListViewItem item in listViewHelathCheck.Items)
            {
                try
                {
                    string UninstallGuid = RegistryHelper.GetUninstallGuid(comboBxAppList.Text, item.SubItems[0].Text);
                    string installDate = RegistryHelper.GetInstallDate(UninstallGuid, item.SubItems[0].Text);
                    UpdateLog(UninstallGuid, installDate, item);
                }
                catch (Exception exe)
                {
                    UpdateLog("Exception during evaluation.", exe.Message, item);
                }
            }
        }
        private void LoadListViewWithServers()
        {
            listViewHelathCheck.Items.Clear();
            foreach (string server in serverList)
            {
                ListViewItem listViewItem = new ListViewItem(new string[] { server.ToUpper(), "Not Checked", string.Empty, string.Empty });
                listViewItem.SubItems[1].ForeColor = Color.SteelBlue;
                listViewItem.SubItems[1].Font = new Font(label1.Font.Name, label1.Font.Size, FontStyle.Bold);
                listViewItem.UseItemStyleForSubItems = false;
                listViewHelathCheck.Items.Add(listViewItem);
            }
        }

        private void UpdateLog(string guid, string installDate, ListViewItem item)
        {
            Color color;
            string text;
            color = String.IsNullOrEmpty(guid) ? Color.Red : Color.Green;
            text = String.IsNullOrEmpty(guid) ? "Not Installed" : "Installed";
            item.SubItems[1].Text = text;
            item.SubItems[1].ForeColor = color;
            item.UseItemStyleForSubItems = false;
            item.SubItems[2].Text = guid;
            item.SubItems[3].Text = installDate;
            this.Text = string.Concat(comboBxAppList.Text, " : ", formText);

        }

        private void BeginGacCheckAction()
        {
            LoadResourceGacedActions();
            BeginResourceGacCheck(GetActions());

        }

        private List<BaseAction> GetActions()
        {
            List<BaseAction> actions = new List<BaseAction>();
            foreach (ListViewItem item in listViewResources.Items)
            {
                ListViewItem.ListViewSubItemCollection subItemsCollection = item.SubItems;
                for (int i = 1; i < subItemsCollection.Count; i++)
                {
                    actions.Add((BaseAction)subItemsCollection[i].Tag);
                }
            }
            return actions;
        }

        private void BeginResourceGacCheck(List<BaseAction> actions)
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
            UpdateLog(e.ActionStatus, "", GetListViewItemForLogUpdate(listViewResources, e.Action));
        }

        private ListViewItem.ListViewSubItem GetListViewItemForLogUpdate(object sender, BaseAction action)
        {
            ListView listView = sender as ListView;

            foreach (ListViewItem item in listView.Items)
            {
                ListViewItem.ListViewSubItemCollection subItemsCollection = item.SubItems;
                for (int i = 1; i < subItemsCollection.Count; i++)
                {
                    // BaseAction ac = (BaseAction)subItemsCollection[i].Tag;
                    if (subItemsCollection[i].Tag == action)
                    {
                        return subItemsCollection[i];
                    }
                }

            }
            return null;
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
            // UpdateLogImportPublish(e.ActionStatus, e.Message, GetListViewItemForLogUpdate(listViewVocabularies, e.Action));
        }

        void UpdateLog(object sender, ActionExecutedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                // We're on a thread other than the GUI thread
                this.Invoke(new MethodInvoker(() => UpdateLog(sender, e)));
                return;
            }

            UpdateLog(e.ActionStatus, "", GetListViewItemForLogUpdate(listViewResources, e.Action));
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
            this.FormState = FormStateEnum.Initial;
            //EndExecuteActions();


        }

        private void UpdateLog(ActionStatusEnum actionStatus, string resultMessage, ListViewItem.ListViewSubItem item)
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
                    text = "In GAC";
                    color = Color.Green;
                    //item.Checked = false;
                    break;

                default:
                    text = "Not in GAC";
                    color = Color.Red;
                    break;
            }
            item.Text = text;
            item.Font = new Font(label1.Font.Name, label1.Font.Size, FontStyle.Bold);
            item.ForeColor = color;
        }
        private void DisplayError(string message)
        {
            MessageBox.Show(message, "DeploymentHealthCheck", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void comboBxAppList_TextUpdate(object sender, EventArgs e)
        {
            listViewHelathCheck.Items.Clear();
        }

        private void comboBxAppList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FormState = FormStateEnum.Processing;
            LoadViews();
            //CheckInstallHealth();
            this.FormState = FormStateEnum.Initial;

        }

        private void LoadApplications()
        {
            appCollection = explorerHelper.GetApplicationCollection();
            List<string> appList = explorerHelper.GetApplicationList(appCollection);
            comboBxAppList.Items.AddRange(RemoveSystemApplication(appList).ToArray());
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
        private void LoadResources(string applicationName)
        {
            string[] viewItems = new string[serverList.Count + 1];
            foreach (string resourceName in ApplicationDeploymentHelper.GetResources(applicationName, GlobalProperties.MgmtDBName, GlobalProperties.MgmtDBServer))
            {
                viewItems[0] = resourceName;
                for (int i = 1; i < listViewResources.Columns.Count; i++)
                {
                    viewItems[i] = "";// listView1.Columns[i].Text;                         
                }
                ListViewItem listViewItem = new ListViewItem(viewItems);
                listViewItem.UseItemStyleForSubItems = false;
                listViewResources.Items.Add(listViewItem);
            }
        }

        private void LoadResourceGacedActions()
        {
            foreach (ListViewItem item in listViewResources.Items)
            {
                ListViewItem.ListViewSubItemCollection subItemsCollection = item.SubItems;
                for (int i = 1; i < subItemsCollection.Count; i++)
                {
                    subItemsCollection[i].Tag = ActionFactory.CreateResourceGacedAction(serverList[i - 1], item.SubItems[0].Text);
                }
            }
        }

        private void LoadGacCheckListView()
        {
            listViewResources.Columns.Clear();
            listViewResources.Items.Clear();
            listViewResources.Columns.Add("Resource Name", 125, HorizontalAlignment.Left);
            foreach (string server in serverList)
            {
                listViewResources.Columns.Add(server.ToUpper(), 120, HorizontalAlignment.Center);
            }
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            //LoadApplications();
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            // LoadApplications();
        }

        private void locateMSIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBxAppList.Text))
            {
                DisplayMessage("No application selected to locate.");
                return;
            }
            string appGuid = RegistryHelper.GetUninstallGuid(comboBxAppList.Text, Environment.MachineName);
            if (string.IsNullOrEmpty(appGuid))
            {
                DisplayError("The application is not installed on current machine. Msi locate not applicable.");
                return;
            }

            BTDTFormProperties.ApplicationInstallGuid = appGuid;
            LocateMsi locateMsi = new LocateMsi();
            locateMsi.Show();
        }

        private void DisplayMessage(string message)
        {
            MessageBox.Show(message, "BTDT", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

     
        private void DisplayError(Exception ex)
        {
            DisplayError(ex.Message);
        }

       
        private void propertyGrid2_Click(object sender, EventArgs e)
        {
        }
    }
}

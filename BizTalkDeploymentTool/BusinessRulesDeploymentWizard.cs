using Microsoft.RuleEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;
using System.Windows.Forms;
using BizTalkDeploymentTool.Actions;
using BizTalkDeploymentTool.Helpers;
using System.Xml;
using BizTalkDeploymentTool.Extensions;
using System.Reflection;
using System.Xml.Xsl;
using System.IO;
namespace BizTalkDeploymentTool
{
    public partial class BusinessRulesDeploymentWizard : Form
    {
        #region Init
        ListView lstViewContextStrip = new ListView();
        ThreadProcessor threadProcessor = null;
        private ListView actionableListView { get; set; }
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
                    this.actionableListView = null;
                    threadProcessor = null;
                    foreach (TabPage page in tabControlBRE.TabPages)
                    {
                        page.Enabled = true;
                    }
                    break;

                case FormStateEnum.NotProcessing:
                    UpdateCursor(Cursors.Default);
                    this.actionableListView = null;
                    threadProcessor = null;
                    foreach (TabPage page in tabControlBRE.TabPages)
                    {
                        page.Enabled = true;
                    }
                    break;

                case FormStateEnum.Processing:
                    UpdateCursor(Cursors.WaitCursor);
                    foreach (TabPage page in tabControlBRE.TabPages)
                    {
                        if (page != tabControlBRE.SelectedTab)
                        {
                            page.Enabled = false;
                        }
                        else
                        {
                            this.actionableListView = page.Tag as ListView;
                        }
                    }
                    break;

            }
        }

        private void UpdateCursor(Cursor cursor)
        {
            this.Cursor = cursor;
        }

        public BusinessRulesDeploymentWizard()
        {
            InitializeComponent();

            listViewDeletePolicy.DoubleBuffered(true);
            listViewDeleteVocabulary.DoubleBuffered(true);

            listViewDeployPolicy.DoubleBuffered(true);
            listViewUnDeployPolicy.DoubleBuffered(true);

            listViewImportAndPublish.DoubleBuffered(true);

        }
        #endregion

        #region Import&Publish



        private void btnVocabularies_MouseHover(object sender, EventArgs e)
        {
            ArtifactsBtnToolTip.Show("Select the vocabulary and(or) policy files for operation.", this.btnVocabularies);
        }

        private void btnVocabularies_Click(object sender, EventArgs e)
        {
            DialogResult dr = this.openVocabularyDialog.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                this.FormState = FormStateEnum.Initial;
                LoadFiles();
            }
        }
        private void LoadFiles()
        {
            foreach (string item in this.openVocabularyDialog.FileNames)
            {
                ListViewItem listViewItem = new ListViewItem(new string[] { item, "Not Executed", string.Empty });
                listViewItem.SubItems[1].ForeColor = Color.SteelBlue;
                listViewItem.SubItems[1].Font = new Font(btnVocabularies.Font.Name, btnVocabularies.Font.Size, FontStyle.Bold);
                listViewItem.Tag = BreActionFactory.CreateImportPublishActions(item);
                listViewItem.UseItemStyleForSubItems = false;
                listViewImportAndPublish.Items.Add(listViewItem);
            }
        }

        private void btnToggle_Click(object sender, EventArgs e)
        {
            Toggle(listViewImportAndPublish);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            this.BeginImportPublishBrl();
        }

        private void BeginImportPublishBrl()
        {
            this.FormState = FormStateEnum.Processing;
            if (listViewImportAndPublish.CheckedItems.Count == 0)
            {
                DisplayMessage("Please check brl(s) to import and publish.");
                this.FormState = FormStateEnum.Initial;
                return;
            }
            BeginImportingPublishingBrl(GetCheckedBrlsInOrder());
        }

        private void BeginImportingPublishingBrl(List<BaseAction> actions)
        {
            // Initialize thread
            if (threadProcessor == null)
            {
                threadProcessor = new ThreadProcessor();
                threadProcessor.Completed += new EventHandler<CompletedEventArgs>(threadProcessor_Completed);
                threadProcessor.ActionExecuting += new EventHandler<ActionExecutingEventArgs>(threadProcessor_IPExecuting);
                threadProcessor.ActionExecuted += new EventHandler<ActionExecutedEventArgs>(threadProcessor_IPExecuted);
            }
            threadProcessor.AsyncRun(actions);
        }
        void threadProcessor_IPExecuting(object sender, ActionExecutingEventArgs e)
        {
            if (this.InvokeRequired)
            {
                // We're on a thread other than the GUI thread
                this.Invoke(new MethodInvoker(() => threadProcessor_IPExecuting(sender, e)));
                return;
            }
            UpdateLogImportPublish(e.ActionStatus, "", GetListViewItemForLogUpdate(this.actionableListView, e.Action));
        }

        void threadProcessor_IPExecuted(object sender, ActionExecutedEventArgs e)
        {
            // Execute in same thread as ThreadProcessor

            if (this.InvokeRequired)
            {
                // We're on a thread other than the GUI thread

                this.Invoke(new MethodInvoker(() => threadProcessor_IPExecuted(sender, e)));

                return;
            }
            UpdateLogImportPublish(e.ActionStatus, e.Message, GetListViewItemForLogUpdate(this.actionableListView, e.Action));
        }

        private List<BaseAction> GetCheckedBrlsInOrder()
        {
            List<BaseAction> actions = new List<BaseAction>();

            List<BaseAction> actionsVocab = new List<BaseAction>();
            List<BaseAction> actionsPolicy = new List<BaseAction>();

            foreach (ListViewItem item in listViewImportAndPublish.Items)
            {
                if (item.Checked)
                {
                    string type = GetBrlType(item.Text);
                    if (type == "vocabulary")
                    {
                        actionsVocab.Add((BaseAction)item.Tag);
                    }
                    else if (type == "policy")
                    {
                        actionsPolicy.Add((BaseAction)item.Tag);
                    }
                    else
                    {
                        UpdateLogImportPublish(ActionStatusEnum.Failed, "Not a valid Brl file.", GetListViewItemForLogUpdate(listViewImportAndPublish, (BaseAction)item.Tag));
                    }
                    //actions.Add((BaseAction)item.Tag);
                }
            }

            foreach (BaseAction item in actionsVocab)
            {
                actions.Add(item);
            }
            foreach (BaseAction item in actionsPolicy)
            {
                actions.Add(item);
            }
            return actions;
        }

        private string GetBrlType(string fileName)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(fileName);
            int vocab = xDoc.GetElementsByTagName("vocabulary").Count;
            int policy = xDoc.GetElementsByTagName("ruleset").Count;
            if (vocab > 0)
            {
                return "vocabulary";
            }
            else if (policy > 0)
            {
                return "policy";
            }
            else
            {
                return string.Empty;
            }
        }

        private void UpdateLogImportPublish(ActionStatusEnum actionStatus, string resultMessage, ListViewItem item)
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
                    text = "Success";
                    color = Color.Green;
                    item.Checked = false;
                    break;

                default:
                    text = "Failure";
                    color = Color.Red;
                    break;
            }
            item.SubItems[1].Text = text;
            item.SubItems[1].ForeColor = color;
            item.SubItems[2].Text = resultMessage;
            item.UseItemStyleForSubItems = false;
            item.ToolTipText = resultMessage;
        }

        private void listViewVocabularies_MouseClick(object sender, MouseEventArgs e)
        {
            PopulateMessage(sender, e, richTextBoxMessage);
        }
        #endregion

        #region DeployPolicy

        private void btnDeploy_Click(object sender, EventArgs e)
        {
            this.BeginActions();
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            listViewDeployPolicy.Items.Clear();
            tabPage2.Tag = listViewDeployPolicy;
            richTextBoxDeployMessage.Text = string.Empty;
            RuleSetInfoCollection ruleSetCollection = BizTalkDeploymentTool.Helpers.BreHelper.GetPublishedUndeployedRuleSets();
            LoadUnDeployedPolicies(ruleSetCollection);
        }

        private void LoadUnDeployedPolicies(RuleSetInfoCollection ruleSetCollection)
        {
            foreach (RuleSetInfo item in ruleSetCollection)
            {
                ListViewItem listViewItem = new ListViewItem(new string[] { item.Name, item.MajorRevision.ToString(), item.MinorRevision.ToString(), "Published", string.Empty });
                listViewItem.SubItems[3].ForeColor = Color.SteelBlue;
                listViewItem.SubItems[3].Font = new Font(btnVocabularies.Font.Name, btnVocabularies.Font.Size, FontStyle.Bold);
                listViewItem.UseItemStyleForSubItems = false;
                listViewItem.Tag = BreActionFactory.CreateDeployActions(item.Name, item.MajorRevision.ToString(), item.MinorRevision.ToString());
                listViewDeployPolicy.Items.Add(listViewItem);
            }
        }
       
        private void listViewDeployPolicy_MouseClick(object sender, MouseEventArgs e)
        {
            PopulateMessage(sender, e, richTextBoxDeployMessage);
        }

        #endregion

        #region UnDeployPolicy


        private void tabPage3_Enter(object sender, EventArgs e)
        {
            listViewUnDeployPolicy.Items.Clear();
            tabPage3.Tag = listViewUnDeployPolicy;
            richTextBoxUnDeploy.Text = string.Empty;
            RuleSetInfoCollection ruleSetCollection = BizTalkDeploymentTool.Helpers.BreHelper.GetDeployedRuleSets();
            LoadDeployedPolicies(ruleSetCollection);
        }

        private void buttonUnDeploy_Click(object sender, EventArgs e)
        {
            this.BeginActions();
        }

        private void buttonUnDeploy_MouseClick(object sender, MouseEventArgs e)
        {
            PopulateMessage(sender, e, richTextBoxUnDeploy);
        }

        private void buttonToggleUnDeploy_Click(object sender, EventArgs e)
        {
            Toggle(listViewUnDeployPolicy);
        }


        private void LoadDeployedPolicies(RuleSetInfoCollection ruleSetCollection)
        {
            foreach (RuleSetInfo item in ruleSetCollection)
            {
                ListViewItem listViewItem = new ListViewItem(new string[] { item.Name, item.MajorRevision.ToString(), item.MinorRevision.ToString(), "Deployed", string.Empty });
                listViewItem.SubItems[3].ForeColor = Color.SteelBlue;
                listViewItem.SubItems[3].Font = new Font(btnVocabularies.Font.Name, btnVocabularies.Font.Size, FontStyle.Bold);
                listViewItem.UseItemStyleForSubItems = false;
                listViewItem.Tag = BreActionFactory.CreateUnDeployActions(item.Name, item.MajorRevision.ToString(), item.MinorRevision.ToString());
                listViewUnDeployPolicy.Items.Add(listViewItem);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Toggle(listViewDeployPolicy);
        }

        #endregion

        #region DeleteVocabulary
        private void tabPageDeleteVocabulary_Enter(object sender, EventArgs e)
        {
            listViewDeleteVocabulary.Items.Clear();
            tabPageDeleteVocabulary.Tag = listViewDeleteVocabulary;
            //this.actionableListView = listViewDeleteVocabulary;
            richTextBox2.Text = string.Empty;
            VocabularyInfoCollection vocabularies = BreHelper.GetPublishedVocabularies();
            LoadVocabularies(vocabularies);
        }

        private void LoadVocabularies(VocabularyInfoCollection vocabularies)
        {
            foreach (VocabularyInfo item in vocabularies)
            {
                ListViewItem listViewItem = new ListViewItem(new string[] { item.Name, item.MajorRevision.ToString(), item.MinorRevision.ToString(), "Published", string.Empty });
                listViewItem.SubItems[3].ForeColor = Color.SteelBlue;
                listViewItem.SubItems[3].Font = new Font(btnVocabularies.Font.Name, btnVocabularies.Font.Size, FontStyle.Bold);
                listViewItem.UseItemStyleForSubItems = false;
                listViewItem.Tag = BreActionFactory.CreateDeleteVocabularyActions(item.Name, item.MajorRevision.ToString(), item.MinorRevision.ToString());
                listViewDeleteVocabulary.Items.Add(listViewItem);
            }
        }

        private void buttonDeleteVocabulary_Click(object sender, EventArgs e)
        {
            this.BeginActions();
        }

        private void buttonToggleDeleteVocabulary_Click(object sender, EventArgs e)
        {
            Toggle(listViewDeleteVocabulary);
        }

        private void listViewDeleteVocabulary_MouseClick(object sender, MouseEventArgs e)
        {
            PopulateMessage(sender, e, richTextBox1);
        }
        #endregion

        #region DeletePolicy

        private void tabPageDeletePolicy_Enter(object sender, EventArgs e)
        {
            listViewDeletePolicy.Items.Clear();
            tabPageDeletePolicy.Tag = listViewDeletePolicy;
            //this.actionableListView = listViewDeletePolicy;
            richTextBox1.Text = string.Empty;
            RuleSetInfoCollection ruleSetCollection = BizTalkDeploymentTool.Helpers.BreHelper.GetPublishedUndeployedRuleSets();
            LoadDeletePolicies(ruleSetCollection);
        }
        private void LoadDeletePolicies(RuleSetInfoCollection ruleSetCollection)
        {
            foreach (RuleSetInfo item in ruleSetCollection)
            {
                ListViewItem listViewItem = new ListViewItem(new string[] { item.Name, item.MajorRevision.ToString(), item.MinorRevision.ToString(), "Published", string.Empty });
                listViewItem.SubItems[3].ForeColor = Color.SteelBlue;
                listViewItem.SubItems[3].Font = new Font(btnVocabularies.Font.Name, btnVocabularies.Font.Size, FontStyle.Bold);
                listViewItem.UseItemStyleForSubItems = false;
                listViewItem.Tag = BreActionFactory.CreateDeletePolicyActions(item.Name, item.MajorRevision.ToString(), item.MinorRevision.ToString());
                listViewDeletePolicy.Items.Add(listViewItem);
            }
        }

        private void buttonDeletePolicy_Click(object sender, EventArgs e)
        {
            this.BeginActions();
        }       

        private void buttonToggleDeletePolicy_Click(object sender, EventArgs e)
        {
            Toggle(listViewDeletePolicy);
        }

        private void listViewDeletePolicy_MouseClick(object sender, MouseEventArgs e)
        {
            PopulateMessage(sender, e, richTextBox2);
        }
        #endregion

        #region Common
        private void PopulateMessage(object sender, MouseEventArgs e, RichTextBox rchTxtBx)
        {
            lstViewContextStrip = sender as ListView;
            if (e.Button == MouseButtons.Right)
            {
               // DisplayMessage("No context menu available");
            }
            else if (e.Button == MouseButtons.Left && lstViewContextStrip != null && lstViewContextStrip.FocusedItem != null)
            {
                rchTxtBx.Text = lstViewContextStrip.FocusedItem.ToolTipText;
            }
        }


        public void EndExecuteActions()
        {
            this.FormState = FormStateEnum.NotProcessing;
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
                    text = "Success";
                    color = Color.Green;
                    item.Checked = false;
                    break;

                default:
                    text = "Failure";
                    color = Color.Red;
                    break;
            }

            item.SubItems[3].Text = text;
            item.SubItems[3].ForeColor = color;
            item.SubItems[4].Text = resultMessage;
            item.UseItemStyleForSubItems = false;
            item.ToolTipText = resultMessage;
        }

        private void DisplayMessage(string message)
        {
            MessageBox.Show(message, "BusinessRulesDeploymentWizard", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Toggle(ListView listView)
        {
            foreach (ListViewItem item in listView.Items)
            {
                if (item.StateImageIndex != -1)
                    item.Checked = !item.Checked;
            }
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
        #endregion

        private void BusinessRulesDeploymentWizard_FormClosing(object sender, FormClosingEventArgs e)
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

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            tabPage1.Tag = listViewImportAndPublish;
        }

        #region ThreadProcessor



        private void BeginActions()
        {
            this.FormState = FormStateEnum.Processing;
            if (this.actionableListView.CheckedItems.Count == 0)
            {
                DisplayMessage("Please check item(s) for action.");
                this.FormState = FormStateEnum.Initial;
                return;
            }
            BeginActions(GetCheckedItems());
        }

        private List<BaseAction> GetCheckedItems()
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

        private void BeginActions(List<BaseAction> actions)
        {
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
            UpdateLog(e.ActionStatus, "", GetListViewItemForLogUpdate(this.actionableListView, e.Action));
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
            UpdateLog(e.ActionStatus, e.Message, GetListViewItemForLogUpdate(this.actionableListView, e.Action));
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

        #endregion

        private void tabControlBRE_Selecting(object sender, TabControlCancelEventArgs e)
        {
            e.Cancel = !e.TabPage.Enabled;
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.FormState = FormStateEnum.Processing;
            ListViewItem item = actionableListView.SelectedItems[0];
            string ruleName = item.SubItems[0].Text;
            string majorV = item.SubItems[1].Text;
            string minorV = item.SubItems[2].Text;
            string rule = GenericHelper.TransformData("BizTalkDeploymentTool.EmbeddedResources.Policy.xslt", (BreHelper.GetRules(new RuleSetInfo(ruleName, Convert.ToInt32(majorV), Convert.ToInt32(minorV)))));
            this.FormState = FormStateEnum.Initial;
            Viewer viewer = new Viewer(rule);
            viewer.Show();
        }

    }
}

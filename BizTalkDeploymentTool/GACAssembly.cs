using BizTalkDeploymentTool.Wmi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BizTalkDeploymentTool.Extensions;
using BizTalkDeploymentTool.Actions;
using System.Security.Principal;
using BizTalkDeploymentTool.Global;

namespace BizTalkDeploymentTool
{
    public partial class GACAssembly : Form
    {
        List<string> serverList = GlobalProperties.MessagingServers;
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


        public GACAssembly()
        {
            InitializeComponent();
            listViewResources.DoubleBuffered(true);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult dr = this.assembliesDialog.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                this.FormState = FormStateEnum.Initial;
                LoadFiles();
            }
        }
        private void LoadFiles()
        {
            string[] viewItems = new string[serverList.Count + 1];
            foreach (string item in this.assembliesDialog.FileNames)
            {
                viewItems[0] = item;
                for (int i = 1; i < listViewResources.Columns.Count; i++)
                {
                    viewItems[i] = "";// listView1.Columns[i].Text;                         
                }
                ListViewItem listViewItem = new ListViewItem(viewItems);
                listViewItem.SubItems[1].ForeColor = Color.SteelBlue;
                listViewItem.SubItems[1].Font = new Font(btnAdd.Font.Name, btnAdd.Font.Size, FontStyle.Bold);
                // listViewItem.Tag = BreActionFactory.CreateImportPublishActions(item);
                listViewItem.UseItemStyleForSubItems = false;
                listViewResources.Items.Add(listViewItem);
            }
        }

        private void LoadResourcesListView()
        {
            listViewResources.Columns.Clear();
            listViewResources.Items.Clear();
            listViewResources.Columns.Add("Resource Name", 125, HorizontalAlignment.Left);
            foreach (string server in serverList)
            {
                listViewResources.Columns.Add(server.ToUpper(), 120, HorizontalAlignment.Center);
            }
        }

        private void LoadGacAssemblyActions()
        {
            foreach (ListViewItem item in listViewResources.Items)
            {
                ListViewItem.ListViewSubItemCollection subItemsCollection = item.SubItems;
                for (int i = 1; i < subItemsCollection.Count; i++)
                {
                    subItemsCollection[i].Tag = ActionFactory.CreateGacAssemblyAction(serverList[i - 1], item.SubItems[0].Text);
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            this.BeginGacAction();
        }

        private void GACAssembly_Load(object sender, EventArgs e)
        {            
            LoadResourcesListView();
        }


        private void BeginGacAction()
        {
            LoadGacAssemblyActions();
            BeginGacing(GetActions());
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
        private void BeginGacing(List<BaseAction> actions)
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
            threadProcessor.Run(actions);
        }

        void threadProcessor_Executing(object sender, ActionExecutingEventArgs e)
        {
            if (this.InvokeRequired)
            {
                // We're on a thread other than the GUI thread
                this.Invoke(new MethodInvoker(() => threadProcessor_Executing(sender, e)));

                return;
            }
            UpdateLog(e.ActionStatus, e.Message, GetListViewItemForLogUpdate(listViewResources, e.Action));
        }

        void UpdateLog(object sender, ActionExecutedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                // We're on a thread other than the GUI thread
                this.Invoke(new MethodInvoker(() => UpdateLog(sender, e)));
                return;
            }

            UpdateLog(e.ActionStatus, e.Message, GetListViewItemForLogUpdate(listViewResources, e.Action));
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
            //EndExecuteActions();


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
            // UpdateLogImportPublish(e.ActionStatus, e.Message, GetListViewItemForLogUpdate(listViewVocabularies, e.Action));
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
                    text = "True";
                    color = Color.Green;
                    //item.Checked = false;
                    break;

                default:
                    text = "False";
                    color = Color.Red;
                    break;
            }
            item.Text = text;
            item.Font = new Font(btnAdd.Font.Name, btnAdd.Font.Size, FontStyle.Bold);
            item.ForeColor = color;
            item.Name = resultMessage;
        }
        private ListViewItem.ListViewSubItem GetListViewItemForLogUpdate(object sender, BaseAction action)
        {
            ListView listView = sender as ListView;

            foreach (ListViewItem item in listView.Items)
            {
                ListViewItem.ListViewSubItemCollection subItemsCollection = item.SubItems;
                for (int i = 0; i < subItemsCollection.Count; i++)
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

        private void listViewResources_MouseClick(object sender, MouseEventArgs e)
        {
            //PopulateMessage(sender, e, richTextBoxMessage);
        }
        private void PopulateMessage(string value)
        {
           // rchTxtBx.Text = lstViewContextStrip.Name;
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewResources.SelectedItems)
            {
                listViewResources.Items.Remove(item);
            }
        }

        private void listViewResources_MouseDown(object sender, MouseEventArgs e)
        {
            var info = listViewResources.HitTest(e.X, e.Y);
            if (info.Item != null)
            {
                var row = info.Item.Index;
                var col = info.Item.SubItems.IndexOf(info.SubItem);
                var value = info.Item.SubItems[col].Name;
                richTextBoxMessage.Text = value;
            }
            //rchTxtBx.Text = value;           
            //MessageBox.Show(string.Format("R{0}:C{1} val '{2}'", row, col, value));

        }

        private void GACAssembly_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}

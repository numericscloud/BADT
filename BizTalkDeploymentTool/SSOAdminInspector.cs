using BizTalkDeploymentTool.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.AccountManagement;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BizTalkDeploymentTool
{
    public partial class SSOAdminInspector : Form
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
            if (this.InvokeRequired)
            {
                // We're on a thread other than the GUI thread
                this.Invoke(new MethodInvoker(() => UpdateCursor(cursor)));
                return;
            }

            this.Cursor = cursor;
        }

        public SSOAdminInspector()
        {
            InitializeComponent();
        }

        private void SSOAdminInspector_Load(object sender, EventArgs e)
        {
            this.FormState = FormStateEnum.Processing;
            LoadSSOAppsTreeView();
            //treeViewSSOApps.ExpandAll();;
            ExpandToLevel(treeViewSSOApps.Nodes, 1);
            this.FormState = FormStateEnum.Initial;
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

        private void LoadSSOAppsTreeView()
        {
            SSOAffiliateApplications ssoAffiliateApps = new SSOAffiliateApplications();
            TreeNode parentNode = treeViewSSOApps.Nodes.Add(Constants._SSO_AFFILIATE_ROOT_NODE, Constants._SSO_AFFILIATE_ROOT_NODE);
            parentNode.ImageIndex = 0;
            parentNode.SelectedImageIndex = 0;
            for (int i = 0; i < ssoAffiliateApps.Applications.Count(); i++)
            {
                TreeNode affiliateAppNode = parentNode.Nodes.Add(ssoAffiliateApps.Applications[i]);
                affiliateAppNode.ImageIndex = 1;
                affiliateAppNode.SelectedImageIndex = 1;
                SSOAffiliateApplication ssoApp = new SSOAffiliateApplication();
                ssoApp.Application = ssoAffiliateApps.Applications[i];
                ssoApp.Description = ssoAffiliateApps.Descriptions[i];
                ssoApp.ContactInfo = ssoAffiliateApps.ContactInfos[i];
                ssoApp.UserAccount = ssoAffiliateApps.UserAccounts[i];
                ssoApp.AdminAccount = ssoAffiliateApps.AdminAccounts[i];
                ssoApp.Flag = ssoAffiliateApps.Flags[i];

                string[] userAccounts = ssoAffiliateApps.UserAccounts[i].Split(';');

                for (int j = 0; j < userAccounts.Count(); j++)
                {
                    object[] test = SSOHelper.GetWindowsUserMapping(userAccounts[j].Trim(), ssoAffiliateApps.Applications[i]);
                    foreach (var obj in test)
                    {
                        dynamic item = obj;
                        TreeNode userNode = affiliateAppNode.Nodes.Add(userAccounts[j]);
                        userNode.ImageIndex =3;
                        userNode.SelectedImageIndex = 3;
                        userNode.Tag = item;
                        userNode.ContextMenuStrip = contextMenuStrip1;
                    }
                }
                affiliateAppNode.Tag = ssoApp;
            }
        }




        private void treeViewSSOApps_AfterSelect(object sender, TreeViewEventArgs e)
        {
            PopulatePropertyGrid(e.Node.Tag, propertyGridSSOProps);
           /* SSOAffiliateApplication ssoApp = e.Node.Tag as SSOAffiliateApplication;
            if (ssoApp != null)
            {
                Dictionary<string, string> creds = ssoApp.UserMappings;
                if (creds != null)
                {
                    try
                    {
                        PropertyClass myProp = new PropertyClass();
                        foreach (var item in creds)
                        {
                            CustomProperty myproperty = new CustomProperty(item.Key, item.Value, true, true);
                            myProp.Add(myproperty);
                            PopulatePropertyGrid(myProp, propertyGrid1);
                        }
                    }
                    catch (Exception exe)
                    {
                        DisplayError(exe);
                    }
                }
            }*/
        }

        private void PopulatePropertyGrid(object obj, PropertyGrid grid)
        {
            if (obj != null)
            {
                TypeDescriptor.AddAttributes(obj, new Attribute[] { new ReadOnlyAttribute(true) });
            }
            grid.SelectedObject = obj;
        }
        private void DisplayError(Exception ex)
        {
            DisplayError(ex.Message);
        }
        private void DisplayError(string message)
        {
            MessageBox.Show(message, "BTDT", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /*private void button1_Click(object sender, EventArgs e)
        {
            this.FormState = FormStateEnum.Processing;
            bool credentialsValid = false;
            try
            {
                credentialsValid = CredentialsValid(comboBox1.Text, comboBox2.Text, textBox1.Text);
            }
            catch (Exception exe)
            {
                DisplayError(exe.Message);
            }
            if (!credentialsValid)
            {
                DisplayError("The credentials supplied are incorrect.");
            }
            else
            {
                TreeNode parentNode = treeViewSSOApps.Nodes[Constants._SSO_AFFILIATE_ROOT_NODE];
                foreach (TreeNode affiliateAppNode in parentNode.Nodes)
                {
                    SSOAffiliateApplication ssoApp = affiliateAppNode.Tag as SSOAffiliateApplication;
                    if (ssoApp.UserAccount.ToUpper().Contains((string.Format(@"{0}\{1}", comboBox1.Text, comboBox2.Text)).ToUpper()))
                    {
                        SSOAffiliateApplications ssoAffiliateApps = new SSOAffiliateApplications();
                        Dictionary<string, string> credentials = ssoAffiliateApps.GetCredentials(affiliateAppNode.Text, comboBox1.Text, comboBox2.Text, textBox1.Text);
                        ssoApp.UserMappings = credentials;
                        affiliateAppNode.Tag = ssoApp;
                        affiliateAppNode.ImageIndex = 2;
                        affiliateAppNode.SelectedImageIndex = 2;
                    }
                }
            }
            this.FormState = FormStateEnum.Initial;
        }*/

        private bool CredentialsValid(string domain, string user, string password)
        {
            using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, domain))
            {
                // validate the credentials
                return pc.ValidateCredentials(user, password);
            }
        }

        private void SSOAdminInspector_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void DisplayMessage(string message)
        {
            MessageBox.Show(message, "BTDT", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void getCredentialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeViewSSOApps.SelectedNode;
            dynamic item = selectedNode.Tag;
            SSOAffiliateUserCredentials userCreds = new SSOAffiliateUserCredentials(item.WindowsDomainName, item.WindowsUserName, item.ApplicationName, item.ExternalUserName);
            userCreds.ShowDialog();
            
        }

        private void treeViewSSOApps_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeViewSSOApps.SelectedNode = e.Node;
        }

    }
}

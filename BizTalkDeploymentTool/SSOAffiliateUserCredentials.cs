using BizTalkDeploymentTool.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.AccountManagement;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BizTalkDeploymentTool
{
    public partial class SSOAffiliateUserCredentials : Form
    {
        public SSOAffiliateUserCredentials()
        {
            InitializeComponent();
        }

        public SSOAffiliateUserCredentials(string domain, string user, string applicationName, string externalUser)
        {
            InitializeComponent();
            textBoxDomain.Text = domain;
            textBoxUser.Text = user;
            textBoxAppName.Text = applicationName;
            textBoxExternalUser.Text = externalUser;

        }

        private void SSOAffiliateUserCredentials_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool credentialsValid = false;
            try
            {
                credentialsValid = CredentialsValid(textBoxDomain.Text, textBoxUser.Text, textBox1.Text);
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
                SSOAffiliateApplications ssoAffiliateApps = new SSOAffiliateApplications();
                Dictionary<string, string> credentials = ssoAffiliateApps.GetCredentials(textBoxAppName.Text, textBoxDomain.Text, textBoxUser.Text, textBox1.Text);
                foreach (KeyValuePair<string, string> item in credentials)
                {
                     ListViewItem listViewItem = new ListViewItem(new string[] { item.Key, item.Value });
                     sortableListView1.Items.Add(listViewItem);
                }

            }
        }
        private bool CredentialsValid(string domain, string user, string password)
        {
            using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, domain))
            {
                // validate the credentials
                return pc.ValidateCredentials(user, password);
            }
        }

        private void DisplayError(string message)
        {
            MessageBox.Show(message, "BTDT", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


    }
}

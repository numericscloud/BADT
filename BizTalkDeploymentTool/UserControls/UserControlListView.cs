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

namespace BizTalkDeploymentTool
{
    public partial class UserControlListView : UserControl
    {
        private Microsoft.BizTalk.ExplorerOM.ApplicationCollection _appCollection = null;
        public UserControlListView()
        {
            InitializeComponent();
        }

        public UserControlListView(Microsoft.BizTalk.ExplorerOM.ApplicationCollection appCollection)
        {
            _appCollection = appCollection;
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }
        private void UserControlListView_Load(object sender, EventArgs e)
        {
            foreach (Microsoft.BizTalk.ExplorerOM.Application application in _appCollection)
            {
                int imageIndex = 0;
                if(application.Status == Microsoft.BizTalk.ExplorerOM.Status.Started)
                {
                    imageIndex = 1;
                }
                if (application.Status == Microsoft.BizTalk.ExplorerOM.Status.Stopped)
                {
                    imageIndex = 3;
                }
                if (application.Status == Microsoft.BizTalk.ExplorerOM.Status.PartiallyStarted)
                {
                    imageIndex = 2;
                }
                string UninstallGuid = RegistryHelper.GetUninstallGuid(application.Name, Environment.MachineName);
                string installDate = RegistryHelper.GetInstallDate(UninstallGuid, Environment.MachineName);
                if(!String.IsNullOrEmpty(installDate))
                {
                installDate = Convert.ToDateTime(installDate).ToString("yyyy-MM-dd");
                }
                ListViewItem listViewItem = new ListViewItem(new string[] { application.Name, installDate }, imageIndex);
                sortableListView1.Items.Add(listViewItem);
            }
        }
    }
}

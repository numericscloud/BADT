using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BizTalkDeploymentTool.DependencyDeployment
{
    public partial class SelectMsi : Form
    {
        private string _ApplicationName { get; set; }
        public string MsiLocation { get; set; }
        public string TargetEnv { get; set; }
        public string ApplicationMsiGuid { get; set; }
        MsiPackage misPackage;
        public SelectMsi()
        {
            InitializeComponent();
        }

        public SelectMsi(string applicationName)
        {
            InitializeComponent();
            this._ApplicationName = applicationName;
        }

        private void btnBrowseMSI_Click(object sender, EventArgs e)
        {
            LoadMsiPackage();
        }

        private void LoadMsiPackage()
        {
            try
            {
                string fileToOpen = string.Empty;
                if (openMsiFileDialog.ShowDialog() == DialogResult.OK)
                {


                    fileToOpen = openMsiFileDialog.FileName;

                    misPackage = new MsiPackage(fileToOpen);
                    txtMSILocation.Text = fileToOpen;
                    txtAppName.Text = misPackage.DisplayName;
                    LoadTargetEnvironments(misPackage.TargetEnvironments.ToArray());
                }

                
            }
            catch (Exception ex)
            {
                DisplayError(ex);
            }
        }
        private void LoadTargetEnvironments(string[] environments)
        {
            cbTargetEnvironment.Items.Clear();
            cbTargetEnvironment.Items.AddRange(environments);
            cbTargetEnvironment.SelectedItem = cbTargetEnvironment.Items.Contains(Property.BizTalkEnvironment.ToString()) ? Property.BizTalkEnvironment.ToString() : cbTargetEnvironment.Items[0];
        }


        private void DisplayError(Exception ex)
        {
            DisplayError(ex.Message);
        }

        private void DisplayError(string message)
        {
            MessageBox.Show(message, "BTDT", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(this._ApplicationName == txtAppName.Text)
            {
                this.MsiLocation = txtMSILocation.Text;
                this.TargetEnv = (string)cbTargetEnvironment.SelectedItem;
                this.ApplicationMsiGuid = misPackage.GetMsiProperty("ProductCode");
                this.DialogResult = DialogResult.OK;
                //this.Close();
            }
            else
            {
                DisplayError("Not a valid Msi. Please select Msi for the selected application");
            }
        }
    }
}

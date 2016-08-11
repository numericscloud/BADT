using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Management;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Configuration;
using Microsoft.BizTalk.ExplorerOM;
using System.Threading;
using Microsoft.EnterpriseSingleSignOn.Interop;
using System.Reflection;
using System.Text.RegularExpressions;

namespace BizTalkDeploymentTool
{
    public partial class BizTalkDeploymentTool : Form
    {
        string Env;
        string IdentifyingNumber;
        string TempLocation = string.Empty;
        string BTServerInstallLoc = GenericHelper.GetRegistryEntry("SOFTWARE\\Microsoft\\BizTalk Server\\3.0", "InstallPath");
        string DBServerName = GenericHelper.GetRegistryEntry("SOFTWARE\\Microsoft\\BizTalk Server\\3.0\\Administration", "MgmtDBServer");
        string SSOKey = "";
        string SSOCompanyName;
        public BizTalkDeploymentTool()
        {            
            InitializeComponent();
        }

        private void BizTalkDeploymentTool_Load(object sender, EventArgs e)
        {
            LoadValues();
        }

        private void LoadValues()
        {
            TempLocation = ConfigurationManager.AppSettings["TempLocation"];
            SSOKey = ConfigurationManager.AppSettings["SSOKey"];
            SSOCompanyName = ConfigurationManager.AppSettings["SSOCompanyName"];
            richTextBox1.Text = string.Empty;
            DeploymentToolProperty prop = new DeploymentToolProperty();
            DeploymentToolProperty.BizTalkEnvironmentEnum enu = prop.BizTalkEnvironment;
            Env = enu.Equals(DeploymentToolProperty.BizTalkEnvironmentEnum.DEV) ? DeploymentToolProperty.BizTalkEnvironmentEnum.TST.ToString() : enu.ToString();
            //SSOConfigContactInfo = prop.SSOConfigContactInfo;
            rdBtnACP.Checked = (prop.BizTalkEnvironment == DeploymentToolProperty.BizTalkEnvironmentEnum.ACP);
            rdBtnACP.Enabled = (prop.BizTalkEnvironment == DeploymentToolProperty.BizTalkEnvironmentEnum.ACP);
            rdBtnPRD.Checked = (prop.BizTalkEnvironment == DeploymentToolProperty.BizTalkEnvironmentEnum.PRD);
            rdBtnPRD.Enabled = (prop.BizTalkEnvironment == DeploymentToolProperty.BizTalkEnvironmentEnum.PRD);
            rdBtnTST.Checked = (prop.BizTalkEnvironment == DeploymentToolProperty.BizTalkEnvironmentEnum.TST);
            rdBtnTST.Enabled = (prop.BizTalkEnvironment == DeploymentToolProperty.BizTalkEnvironmentEnum.TST);
            rdBtnDev.Checked = (prop.BizTalkEnvironment == DeploymentToolProperty.BizTalkEnvironmentEnum.DEV);
            rdBtnDev.Enabled = (prop.BizTalkEnvironment == DeploymentToolProperty.BizTalkEnvironmentEnum.DEV);
        }

        private void btnBrowseMSI_Click(object sender, EventArgs e)
        {
            string fileToOpen = string.Empty;
            var FD = new System.Windows.Forms.OpenFileDialog();
            if (FD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fileToOpen = FD.FileName;
                txtMSILocation.Text = fileToOpen;
                txtAppName.Text = System.IO.Path.GetFileNameWithoutExtension(fileToOpen);
                grpPreProcess.Visible = true;
                grpPostProcess.Visible = true;
                btnfullDeploy.Visible = true;
                chkBxApp.Visible = true;
                chkBxSSO.Visible = true;
                chkBxIIS.Visible = true;
            }
        }

        private void btnUnInstall_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                MessageBox.Show(GenericHelper.UninstallApplication(txtAppName.Text, IdentifyingNumber, "1.0.0.0"));
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
            this.Cursor = Cursors.Default;
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                MessageBox.Show(GenericHelper.InstallApplication(TempLocation, txtMSILocation.Text));
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
            this.Cursor = Cursors.Default;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                richTextBox1.Text = string.Empty;
                richTextBox1.Visible = true;
                BTSTaskHelper btstaskHelper = new BTSTaskHelper(this.BTServerInstallLoc);
                string result = btstaskHelper.DeleteApp(txtAppName.Text);
                richTextBox1.AppendText(result);
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
            this.Cursor = Cursors.Default;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            BTSTaskHelper btsTaskHelper = new BTSTaskHelper(this.BTServerInstallLoc);
            try
            {
                richTextBox1.Text = string.Empty;
                richTextBox1.Visible = true;
                string result = btsTaskHelper.ImportApp(txtAppName.Text, txtMSILocation.Text, Env);
                richTextBox1.AppendText(result);
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
            this.Cursor = Cursors.Default;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {                
                ExplorerOMHelper explorerOMhelper = new ExplorerOMHelper(this.DBServerName);
                explorerOMhelper.StopApp(txtAppName.Text);
                MessageBox.Show("Application stopped successfully");
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
            this.Cursor = Cursors.Default;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                ExplorerOMHelper explorerOMhelper = new ExplorerOMHelper(this.DBServerName);
                explorerOMhelper.StartApp(txtAppName.Text);
                MessageBox.Show("Application started successfully");
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
            this.Cursor = Cursors.Default;
        }

        private void btnRestartHost_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                ExplorerOMHelper explorerHelper = new ExplorerOMHelper(this.DBServerName);
                bool retVal = explorerHelper.RestartHostInstance(txtAppName.Text);
                MessageBox.Show("Restarted associated hosts: "+retVal.ToString());
            }
            catch (Exception exe)
            {
                MessageBox.Show("An error occurred while trying to execute the WMI method: " + exe.Message);
            }
            this.Cursor = Cursors.Default;
        }


        private void btnChkInstances_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                ExplorerOMHelper explorerHelper = new ExplorerOMHelper(this.DBServerName);
                bool isExists = explorerHelper.HasInProgressInstance(txtAppName.Text);
                if (isExists == false)
                {
                    MessageBox.Show("No Suspended instance for the given application: " + txtAppName.Text);
                }
                if (isExists == true)
                {
                    MessageBox.Show("Suspended instance exists for the given application: " + txtAppName.Text);
                }
            }
            catch (Exception exe)
            {
                MessageBox.Show("An error occurred while querying for WMI data: " + exe.Message);
            }
            this.Cursor = Cursors.Default;

        }

        private void btnfullDeploy_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string result;
            richTextBox1.Text = string.Empty;
            richTextBox1.Visible = true;            
            try
            {
                ExplorerOMHelper explorerHelper = new ExplorerOMHelper(this.DBServerName);
                BTSTaskHelper btsTaskHelper = new BTSTaskHelper(this.BTServerInstallLoc);
                DateTime tStart = DateTime.Now;
                writeLog("Checking for suspended Instances.....");
                bool IsInstance = explorerHelper.HasInProgressInstance(txtAppName.Text);
                if (IsInstance == true)
                {
                    MessageBox.Show("Process aborted, Instance exists");
                    //stop process
                }
                else
                {
                    writeLog("No suspended Instances.....Restarting associated hosts.....");
                    bool HostsRestarted = explorerHelper.RestartHostInstance(txtAppName.Text);
                    writeLog("Restarted associated hosts: " + HostsRestarted.ToString());
                    if (explorerHelper.HasDynamicSendPorts(txtAppName.Text))
                    {
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                        writeLog("..Dynamic send ports exists for the application. Manual intervention required to restart associated send handlers' hosts....");
                    }
                    richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                    writeLog("Stopping application.....");
                    explorerHelper.StopApp(txtAppName.Text);
                    writeLog("Stopped application.....Deleting application.....");
                    result = btsTaskHelper.DeleteApp(txtAppName.Text);
                    writeLog(result);
                    writeLog("Deleted application.....UnInstalling application.....");
                    string UnInstallmessage = GenericHelper.UninstallApplication(txtAppName.Text, IdentifyingNumber, "1.0.0.0");
                    writeLog("Uninstalling application done:" + UnInstallmessage);
                    if (!UnInstallmessage.Contains("error"))
                    {
                        writeLog("Installing application.....");                        
                        string Installmessage = GenericHelper.InstallApplication(TempLocation, txtMSILocation.Text);
                        writeLog("Installing application done:" + Installmessage);
                        if (!Installmessage.Contains("error"))
                        {
                            writeLog("Importing application.....");
                            result = btsTaskHelper.ImportApp(txtAppName.Text, txtMSILocation.Text, Env);
                            writeLog(result);
                            writeLog("Imported application.....Starting application.....");
                            explorerHelper.StartApp(txtAppName.Text);

                            writeLog("Started application.....");
                            if (chkBxSSO.Checked == true)
                            {
                                if (!String.IsNullOrEmpty(txtSSOConfigLoc.Text))
                                {
                                    string exceptionMessage;
                                    bool boolresult = SSOHelper.ImportSSOconfig(SSOKey, txtSSOConfigLoc.Text, txtConfigAppName.Text, String.Format("BizTalkAdmin@{0}.com", SSOCompanyName), true, out exceptionMessage);
                                    if (boolresult)
                                    {
                                        writeLog("Successfully redeployed SSOconfig and refreshed cache.");
                                    }
                                    else
                                    {
                                        writeLog("Error is importing SSOconfig. Manual intervension required");
                                    }
                                }
                                else
                                {
                                    richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                                    writeLog("No SSO Config file selected....Select file and Deploy SSO separately now..");
                                    richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                                }
                            }
                            if (chkBxIIS.Checked == true)
                            {
                                string RestartIISMes =GenericHelper.RestartIIS();
                                if (!RestartIISMes.Contains("error"))
                                {
                                    writeLog(RestartIISMes);
                                }
                                else
                                {
                                    richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                                    writeLog(RestartIISMes + "Manual Intervention required..");
                                    richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                                }

                            }
                            DateTime tStop = DateTime.Now;
                            TimeSpan tPass = tStop - tStart;
                            this.Cursor = Cursors.Default;
                            MessageBox.Show("Done in time: " + tPass.ToString());
                        }
                        else
                        {
                            MessageBox.Show("Process aborted, Installing application failed");
                            //stop process
                        }
                    }
                    else
                    {
                        MessageBox.Show("Process aborted, UnInstalling application failed");
                        //stop process
                    }
                }
            }
            catch (Exception exe)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(exe.Message);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
        }
        private void writeLog(string msglog)
        {
            richTextBox1.AppendText(Environment.NewLine + msglog);
        }

        private void btnBrowseConfig_Click(object sender, EventArgs e)
        {
            string fileToOpen = string.Empty;
            var FD = new System.Windows.Forms.OpenFileDialog();
            if (FD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fileToOpen = FD.FileName;
                txtSSOConfigLoc.Text = fileToOpen;
                txtConfigAppName.Text = System.IO.Path.GetFileNameWithoutExtension(fileToOpen);
            }

        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void deleteSSOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSSOConfigLoc.Text))
            {
                SSOHelper.DeteleSSOconfig(txtConfigAppName.Text);
                MessageBox.Show("Successfully deleted SSOconfig");
            }
            else
            {
                MessageBox.Show("Select valid SSO Config file");
            }
        }

        private void importSSOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSSOConfigLoc.Text))
            {
                string exceptionMessage;
                bool result = SSOHelper.ImportSSOconfig(SSOKey, txtSSOConfigLoc.Text, txtConfigAppName.Text, String.Format("BizTalkAdmin@{0}.com", SSOCompanyName), false,out exceptionMessage);
                if (result)
                {
                    MessageBox.Show("Successfully imported SSOconfig and refreshed cache.");
                }
                else
                {
                    MessageBox.Show("Error is importing SSOconfig. Manual intervension required");
                }
            }
            else
            {
                MessageBox.Show("Select valid SSO Config file");
            }
        }

        private void redeploySSOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSSOConfigLoc.Text))
            {
                string exceptionMessage;
                bool result = SSOHelper.ImportSSOconfig(SSOKey, txtSSOConfigLoc.Text, txtConfigAppName.Text, String.Format("BizTalkAdmin@{0}.com", SSOCompanyName), true,out exceptionMessage); ;
                if (result)
                {
                    MessageBox.Show("Successfully redeployed SSOconfig and refreshed cache.");
                }
                else
                {
                    MessageBox.Show("Error is importing SSOconfig. Manual intervension required");
                }
            }
            else
            {
                MessageBox.Show("Select valid SSO Config file");
            }
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            MessageBox.Show(GenericHelper.RestartIIS());
            this.Cursor = Cursors.Default;
        }       
        
    }
}

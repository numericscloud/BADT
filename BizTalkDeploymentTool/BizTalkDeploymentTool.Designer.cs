namespace BizTalkDeploymentTool
{
    partial class BizTalkDeploymentTool
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BizTalkDeploymentTool));
            this.btnBrowseMSI = new System.Windows.Forms.Button();
            this.txtMSILocation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAppName = new System.Windows.Forms.TextBox();
            this.btnUnInstall = new System.Windows.Forms.Button();
            this.btnInstall = new System.Windows.Forms.Button();
            this.grpBxMSI = new System.Windows.Forms.GroupBox();
            this.txtConfigAppName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnBrowseConfig = new System.Windows.Forms.Button();
            this.txtSSOConfigLoc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rdBtnDev = new System.Windows.Forms.RadioButton();
            this.rdBtnTST = new System.Windows.Forms.RadioButton();
            this.rdBtnPRD = new System.Windows.Forms.RadioButton();
            this.rdBtnACP = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnChkInstances = new System.Windows.Forms.Button();
            this.grpPreProcess = new System.Windows.Forms.GroupBox();
            this.btnRestartHost = new System.Windows.Forms.Button();
            this.grpPostProcess = new System.Windows.Forms.GroupBox();
            this.btnfullDeploy = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sSOConfigToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSSOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importSSOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redeploySSOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iISToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chkBxApp = new System.Windows.Forms.CheckBox();
            this.chkBxSSO = new System.Windows.Forms.CheckBox();
            this.chkBxIIS = new System.Windows.Forms.CheckBox();
            this.rdBtnlocalhost = new System.Windows.Forms.RadioButton();
            this.grpBxMSI.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpPreProcess.SuspendLayout();
            this.grpPostProcess.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBrowseMSI
            // 
            resources.ApplyResources(this.btnBrowseMSI, "btnBrowseMSI");
            this.btnBrowseMSI.Name = "btnBrowseMSI";
            this.btnBrowseMSI.UseVisualStyleBackColor = true;
            this.btnBrowseMSI.Click += new System.EventHandler(this.btnBrowseMSI_Click);
            // 
            // txtMSILocation
            // 
            resources.ApplyResources(this.txtMSILocation, "txtMSILocation");
            this.txtMSILocation.Name = "txtMSILocation";
            this.txtMSILocation.ReadOnly = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // txtAppName
            // 
            resources.ApplyResources(this.txtAppName, "txtAppName");
            this.txtAppName.Name = "txtAppName";
            // 
            // btnUnInstall
            // 
            resources.ApplyResources(this.btnUnInstall, "btnUnInstall");
            this.btnUnInstall.Name = "btnUnInstall";
            this.btnUnInstall.UseVisualStyleBackColor = true;
            this.btnUnInstall.Click += new System.EventHandler(this.btnUnInstall_Click);
            // 
            // btnInstall
            // 
            resources.ApplyResources(this.btnInstall, "btnInstall");
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // grpBxMSI
            // 
            this.grpBxMSI.Controls.Add(this.txtConfigAppName);
            this.grpBxMSI.Controls.Add(this.label5);
            this.grpBxMSI.Controls.Add(this.btnBrowseConfig);
            this.grpBxMSI.Controls.Add(this.txtSSOConfigLoc);
            this.grpBxMSI.Controls.Add(this.label4);
            this.grpBxMSI.Controls.Add(this.rdBtnDev);
            this.grpBxMSI.Controls.Add(this.rdBtnTST);
            this.grpBxMSI.Controls.Add(this.rdBtnPRD);
            this.grpBxMSI.Controls.Add(this.rdBtnACP);
            this.grpBxMSI.Controls.Add(this.label3);
            this.grpBxMSI.Controls.Add(this.label1);
            this.grpBxMSI.Controls.Add(this.txtMSILocation);
            this.grpBxMSI.Controls.Add(this.btnBrowseMSI);
            this.grpBxMSI.Controls.Add(this.txtAppName);
            this.grpBxMSI.Controls.Add(this.label2);
            resources.ApplyResources(this.grpBxMSI, "grpBxMSI");
            this.grpBxMSI.Name = "grpBxMSI";
            this.grpBxMSI.TabStop = false;
            // 
            // txtConfigAppName
            // 
            resources.ApplyResources(this.txtConfigAppName, "txtConfigAppName");
            this.txtConfigAppName.Name = "txtConfigAppName";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // btnBrowseConfig
            // 
            resources.ApplyResources(this.btnBrowseConfig, "btnBrowseConfig");
            this.btnBrowseConfig.Name = "btnBrowseConfig";
            this.btnBrowseConfig.UseVisualStyleBackColor = true;
            this.btnBrowseConfig.Click += new System.EventHandler(this.btnBrowseConfig_Click);
            // 
            // txtSSOConfigLoc
            // 
            resources.ApplyResources(this.txtSSOConfigLoc, "txtSSOConfigLoc");
            this.txtSSOConfigLoc.Name = "txtSSOConfigLoc";
            this.txtSSOConfigLoc.ReadOnly = true;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // rdBtnDev
            // 
            resources.ApplyResources(this.rdBtnDev, "rdBtnDev");
            this.rdBtnDev.Checked = true;
            this.rdBtnDev.Name = "rdBtnDev";
            this.rdBtnDev.TabStop = true;
            this.rdBtnDev.UseVisualStyleBackColor = true;
            // 
            // rdBtnTST
            // 
            resources.ApplyResources(this.rdBtnTST, "rdBtnTST");
            this.rdBtnTST.Name = "rdBtnTST";
            this.rdBtnTST.UseVisualStyleBackColor = true;
            // 
            // rdBtnPRD
            // 
            resources.ApplyResources(this.rdBtnPRD, "rdBtnPRD");
            this.rdBtnPRD.Name = "rdBtnPRD";
            this.rdBtnPRD.UseVisualStyleBackColor = true;
            // 
            // rdBtnACP
            // 
            resources.ApplyResources(this.rdBtnACP, "rdBtnACP");
            this.rdBtnACP.Name = "rdBtnACP";
            this.rdBtnACP.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // btnDelete
            // 
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnImport
            // 
            resources.ApplyResources(this.btnImport, "btnImport");
            this.btnImport.Name = "btnImport";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnStop);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnUnInstall);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // btnStop
            // 
            resources.ApplyResources(this.btnStop, "btnStop");
            this.btnStop.Name = "btnStop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            resources.ApplyResources(this.btnStart, "btnStart");
            this.btnStart.Name = "btnStart";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnStart);
            this.groupBox2.Controls.Add(this.btnInstall);
            this.groupBox2.Controls.Add(this.btnImport);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // btnChkInstances
            // 
            resources.ApplyResources(this.btnChkInstances, "btnChkInstances");
            this.btnChkInstances.Name = "btnChkInstances";
            this.btnChkInstances.UseVisualStyleBackColor = true;
            this.btnChkInstances.Click += new System.EventHandler(this.btnChkInstances_Click);
            // 
            // grpPreProcess
            // 
            this.grpPreProcess.Controls.Add(this.btnRestartHost);
            this.grpPreProcess.Controls.Add(this.btnChkInstances);
            resources.ApplyResources(this.grpPreProcess, "grpPreProcess");
            this.grpPreProcess.Name = "grpPreProcess";
            this.grpPreProcess.TabStop = false;
            // 
            // btnRestartHost
            // 
            resources.ApplyResources(this.btnRestartHost, "btnRestartHost");
            this.btnRestartHost.Name = "btnRestartHost";
            this.btnRestartHost.UseVisualStyleBackColor = true;
            this.btnRestartHost.Click += new System.EventHandler(this.btnRestartHost_Click);
            // 
            // grpPostProcess
            // 
            this.grpPostProcess.Controls.Add(this.groupBox1);
            this.grpPostProcess.Controls.Add(this.groupBox2);
            resources.ApplyResources(this.grpPostProcess, "grpPostProcess");
            this.grpPostProcess.Name = "grpPostProcess";
            this.grpPostProcess.TabStop = false;
            // 
            // btnfullDeploy
            // 
            resources.ApplyResources(this.btnfullDeploy, "btnfullDeploy");
            this.btnfullDeploy.Name = "btnfullDeploy";
            this.btnfullDeploy.UseVisualStyleBackColor = true;
            this.btnfullDeploy.Click += new System.EventHandler(this.btnfullDeploy_Click);
            // 
            // richTextBox1
            // 
            resources.ApplyResources(this.richTextBox1, "richTextBox1");
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.sSOConfigToolStripMenuItem1,
            this.iISToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // sSOConfigToolStripMenuItem1
            // 
            this.sSOConfigToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteSSOToolStripMenuItem,
            this.importSSOToolStripMenuItem,
            this.redeploySSOToolStripMenuItem});
            this.sSOConfigToolStripMenuItem1.Name = "sSOConfigToolStripMenuItem1";
            resources.ApplyResources(this.sSOConfigToolStripMenuItem1, "sSOConfigToolStripMenuItem1");
            // 
            // deleteSSOToolStripMenuItem
            // 
            this.deleteSSOToolStripMenuItem.Name = "deleteSSOToolStripMenuItem";
            resources.ApplyResources(this.deleteSSOToolStripMenuItem, "deleteSSOToolStripMenuItem");
            this.deleteSSOToolStripMenuItem.Click += new System.EventHandler(this.deleteSSOToolStripMenuItem_Click);
            // 
            // importSSOToolStripMenuItem
            // 
            this.importSSOToolStripMenuItem.Name = "importSSOToolStripMenuItem";
            resources.ApplyResources(this.importSSOToolStripMenuItem, "importSSOToolStripMenuItem");
            this.importSSOToolStripMenuItem.Click += new System.EventHandler(this.importSSOToolStripMenuItem_Click);
            // 
            // redeploySSOToolStripMenuItem
            // 
            this.redeploySSOToolStripMenuItem.Name = "redeploySSOToolStripMenuItem";
            resources.ApplyResources(this.redeploySSOToolStripMenuItem, "redeploySSOToolStripMenuItem");
            this.redeploySSOToolStripMenuItem.Click += new System.EventHandler(this.redeploySSOToolStripMenuItem_Click);
            // 
            // iISToolStripMenuItem
            // 
            this.iISToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restartToolStripMenuItem});
            this.iISToolStripMenuItem.Name = "iISToolStripMenuItem";
            resources.ApplyResources(this.iISToolStripMenuItem, "iISToolStripMenuItem");
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            resources.ApplyResources(this.restartToolStripMenuItem, "restartToolStripMenuItem");
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // chkBxApp
            // 
            this.chkBxApp.AutoCheck = false;
            resources.ApplyResources(this.chkBxApp, "chkBxApp");
            this.chkBxApp.Checked = true;
            this.chkBxApp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBxApp.Name = "chkBxApp";
            this.chkBxApp.UseVisualStyleBackColor = true;
            // 
            // chkBxSSO
            // 
            resources.ApplyResources(this.chkBxSSO, "chkBxSSO");
            this.chkBxSSO.Name = "chkBxSSO";
            this.chkBxSSO.UseVisualStyleBackColor = true;
            // 
            // chkBxIIS
            // 
            resources.ApplyResources(this.chkBxIIS, "chkBxIIS");
            this.chkBxIIS.Name = "chkBxIIS";
            this.chkBxIIS.UseVisualStyleBackColor = true;
            // 
            // rdBtnlocalhost
            // 
            resources.ApplyResources(this.rdBtnlocalhost, "rdBtnlocalhost");
            this.rdBtnlocalhost.Checked = true;
            this.rdBtnlocalhost.Name = "rdBtnlocalhost";
            this.rdBtnlocalhost.TabStop = true;
            this.rdBtnlocalhost.UseVisualStyleBackColor = true;
            // 
            // BizTalkDeploymentTool
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.chkBxSSO);
            this.Controls.Add(this.chkBxApp);
            this.Controls.Add(this.chkBxIIS);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnfullDeploy);
            this.Controls.Add(this.grpPostProcess);
            this.Controls.Add(this.grpPreProcess);
            this.Controls.Add(this.grpBxMSI);
            this.Controls.Add(this.menuStrip1);
            this.Name = "BizTalkDeploymentTool";
            this.Load += new System.EventHandler(this.BizTalkDeploymentTool_Load);
            this.grpBxMSI.ResumeLayout(false);
            this.grpBxMSI.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.grpPreProcess.ResumeLayout(false);
            this.grpPostProcess.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowseMSI;
        private System.Windows.Forms.TextBox txtMSILocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAppName;
        private System.Windows.Forms.Button btnUnInstall;
        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.GroupBox grpBxMSI;
        private System.Windows.Forms.RadioButton rdBtnTST;
        private System.Windows.Forms.RadioButton rdBtnPRD;
        private System.Windows.Forms.RadioButton rdBtnACP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.RadioButton rdBtnDev;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnChkInstances;
        private System.Windows.Forms.GroupBox grpPreProcess;
        private System.Windows.Forms.GroupBox grpPostProcess;
        private System.Windows.Forms.Button btnRestartHost;
        private System.Windows.Forms.Button btnfullDeploy;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TextBox txtSSOConfigLoc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBrowseConfig;
        private System.Windows.Forms.TextBox txtConfigAppName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkBxApp;
        private System.Windows.Forms.CheckBox chkBxSSO;
        private System.Windows.Forms.CheckBox chkBxIIS;
        private System.Windows.Forms.RadioButton rdBtnlocalhost;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sSOConfigToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteSSOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importSSOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redeploySSOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iISToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
    }
}


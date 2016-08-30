namespace BizTalkDeploymentTool
{
    partial class MsiDeploy
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MsiDeploy));
            this.contextMenuStripAction = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.checkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uncheckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.runXSelectedActionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.runAllCheckedActionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.generateInstructionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.messageSubItemTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.lblssoAppname = new System.Windows.Forms.Label();
            this.lblssoLoc = new System.Windows.Forms.Label();
            this.lblEnvName = new System.Windows.Forms.Label();
            this.lblMsiLoc = new System.Windows.Forms.Label();
            this.lblAppName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnToggle = new System.Windows.Forms.Button();
            this.btnExecute = new System.Windows.Forms.Button();
            this.grpBxMSI = new System.Windows.Forms.GroupBox();
            this.chkBxSSOKey = new System.Windows.Forms.CheckBox();
            this.txtBxSSOKey = new System.Windows.Forms.TextBox();
            this.cbTargetEnvironment = new System.Windows.Forms.ComboBox();
            this.txtConfigAppName = new System.Windows.Forms.TextBox();
            this.btnBrowseConfig = new System.Windows.Forms.Button();
            this.txtSSOConfigLoc = new System.Windows.Forms.TextBox();
            this.txtMSILocation = new System.Windows.Forms.TextBox();
            this.btnBrowseMSI = new System.Windows.Forms.Button();
            this.txtAppName = new System.Windows.Forms.TextBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.ActionsPage = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listViewControl = new System.Windows.Forms.ListView();
            this.Actions = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LastRun = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Elapsed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Message = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rTxtBxMessage = new System.Windows.Forms.RichTextBox();
            this.InstancesPage = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.instancesGridView = new System.Windows.Forms.DataGridView();
            this.contextMenuStripInstances = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.terminateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainerDependency = new System.Windows.Forms.SplitContainer();
            this.treeViewDependency = new System.Windows.Forms.TreeView();
            this.imageListTreeViewDepen = new System.Windows.Forms.ImageList(this.components);
            this.propertyGridDepApps = new System.Windows.Forms.PropertyGrid();
            this.listView1 = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.openMsiFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.openSsoFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.folderSaveMessagesBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.contextMenuStripSelectDependentApp = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectMsiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.contextMenuStripLoadActionsForDepApps = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.loadActionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grpBxMSI.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.ActionsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.InstancesPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.instancesGridView)).BeginInit();
            this.contextMenuStripInstances.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDependency)).BeginInit();
            this.splitContainerDependency.Panel1.SuspendLayout();
            this.splitContainerDependency.Panel2.SuspendLayout();
            this.splitContainerDependency.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.contextMenuStripSelectDependentApp.SuspendLayout();
            this.contextMenuStripLoadActionsForDepApps.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStripAction
            // 
            this.contextMenuStripAction.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkToolStripMenuItem,
            this.uncheckToolStripMenuItem,
            this.toolStripSeparator1,
            this.runXSelectedActionsToolStripMenuItem,
            this.toolStripSeparator2,
            this.runAllCheckedActionsToolStripMenuItem,
            this.toolStripSeparator3,
            this.generateInstructionsToolStripMenuItem});
            this.contextMenuStripAction.Name = "contextMenuStripAction";
            this.contextMenuStripAction.Size = new System.Drawing.Size(233, 132);
            this.contextMenuStripAction.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripAction_Opening);
            // 
            // checkToolStripMenuItem
            // 
            this.checkToolStripMenuItem.Enabled = false;
            this.checkToolStripMenuItem.Image = global::BizTalkDeploymentTool.Properties.Resources.base_checkboxes;
            this.checkToolStripMenuItem.Name = "checkToolStripMenuItem";
            this.checkToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.checkToolStripMenuItem.Text = "Check";
            this.checkToolStripMenuItem.Click += new System.EventHandler(this.checkToolStripMenuItem_Click);
            // 
            // uncheckToolStripMenuItem
            // 
            this.uncheckToolStripMenuItem.Enabled = false;
            this.uncheckToolStripMenuItem.Image = global::BizTalkDeploymentTool.Properties.Resources.error;
            this.uncheckToolStripMenuItem.Name = "uncheckToolStripMenuItem";
            this.uncheckToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.uncheckToolStripMenuItem.Text = "Uncheck";
            this.uncheckToolStripMenuItem.Click += new System.EventHandler(this.uncheckToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(229, 6);
            // 
            // runXSelectedActionsToolStripMenuItem
            // 
            this.runXSelectedActionsToolStripMenuItem.Enabled = false;
            this.runXSelectedActionsToolStripMenuItem.Image = global::BizTalkDeploymentTool.Properties.Resources.Annotate_Complete;
            this.runXSelectedActionsToolStripMenuItem.Name = "runXSelectedActionsToolStripMenuItem";
            this.runXSelectedActionsToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.runXSelectedActionsToolStripMenuItem.Text = "Run x selected action(s)";
            this.runXSelectedActionsToolStripMenuItem.Click += new System.EventHandler(this.executeActionToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(229, 6);
            // 
            // runAllCheckedActionsToolStripMenuItem
            // 
            this.runAllCheckedActionsToolStripMenuItem.Enabled = false;
            this.runAllCheckedActionsToolStripMenuItem.Image = global::BizTalkDeploymentTool.Properties.Resources.Annotate_Default1;
            this.runAllCheckedActionsToolStripMenuItem.Name = "runAllCheckedActionsToolStripMenuItem";
            this.runAllCheckedActionsToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.runAllCheckedActionsToolStripMenuItem.Text = "Run x checked actions";
            this.runAllCheckedActionsToolStripMenuItem.Click += new System.EventHandler(this.runAllCheckedActionsToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(229, 6);
            // 
            // generateInstructionsToolStripMenuItem
            // 
            this.generateInstructionsToolStripMenuItem.Enabled = false;
            this.generateInstructionsToolStripMenuItem.Name = "generateInstructionsToolStripMenuItem";
            this.generateInstructionsToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.generateInstructionsToolStripMenuItem.Text = "Generate selected instructions";
            this.generateInstructionsToolStripMenuItem.Click += new System.EventHandler(this.generateInstructionsToolStripMenuItem_Click);
            // 
            // lblssoAppname
            // 
            this.lblssoAppname.AutoSize = true;
            this.lblssoAppname.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblssoAppname.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblssoAppname.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblssoAppname.Location = new System.Drawing.Point(18, 133);
            this.lblssoAppname.Name = "lblssoAppname";
            this.lblssoAppname.Size = new System.Drawing.Size(79, 13);
            this.lblssoAppname.TabIndex = 9;
            this.lblssoAppname.Text = "SSO App Name";
            this.messageSubItemTooltip.SetToolTip(this.lblssoAppname, "SSO Application name under which the\r\nconfig will be imported.");
            // 
            // lblssoLoc
            // 
            this.lblssoLoc.AutoSize = true;
            this.lblssoLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblssoLoc.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblssoLoc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblssoLoc.Location = new System.Drawing.Point(26, 105);
            this.lblssoLoc.Name = "lblssoLoc";
            this.lblssoLoc.Size = new System.Drawing.Size(70, 13);
            this.lblssoLoc.TabIndex = 6;
            this.lblssoLoc.Text = "SSO Location";
            this.messageSubItemTooltip.SetToolTip(this.lblssoLoc, "SSO Config location.");
            // 
            // lblEnvName
            // 
            this.lblEnvName.AutoSize = true;
            this.lblEnvName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblEnvName.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblEnvName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblEnvName.Location = new System.Drawing.Point(33, 78);
            this.lblEnvName.Name = "lblEnvName";
            this.lblEnvName.Size = new System.Drawing.Size(67, 13);
            this.lblEnvName.TabIndex = 0;
            this.lblEnvName.Text = "Environment";
            this.messageSubItemTooltip.SetToolTip(this.lblEnvName, "List of Target Environments in BizTalk MSI. \r\nPopulated after the msi is selected" +
        ".");
            // 
            // lblMsiLoc
            // 
            this.lblMsiLoc.AutoSize = true;
            this.lblMsiLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblMsiLoc.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblMsiLoc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblMsiLoc.Location = new System.Drawing.Point(33, 23);
            this.lblMsiLoc.Name = "lblMsiLoc";
            this.lblMsiLoc.Size = new System.Drawing.Size(68, 13);
            this.lblMsiLoc.TabIndex = 0;
            this.lblMsiLoc.Text = "MSI Location";
            this.messageSubItemTooltip.SetToolTip(this.lblMsiLoc, "BizTalk MSI location.\r\n");
            // 
            // lblAppName
            // 
            this.lblAppName.AutoSize = true;
            this.lblAppName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblAppName.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblAppName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAppName.Location = new System.Drawing.Point(11, 50);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(89, 13);
            this.lblAppName.TabIndex = 0;
            this.lblAppName.Text = "Application Name";
            this.messageSubItemTooltip.SetToolTip(this.lblAppName, "BizTalk Application name under which the\r\nmsi will be imported.");
            // 
            // pictureBox1
            // 
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(420, 48);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(21, 21);
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            this.messageSubItemTooltip.SetToolTip(this.pictureBox1, "Is the msi installed on current machine ?");
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnToggle
            // 
            this.btnToggle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggle.Image = global::BizTalkDeploymentTool.Properties.Resources._112_RefreshArrow_Green_16x16_72;
            this.btnToggle.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnToggle.Location = new System.Drawing.Point(4, 1167);
            this.btnToggle.Name = "btnToggle";
            this.btnToggle.Size = new System.Drawing.Size(130, 25);
            this.btnToggle.TabIndex = 14;
            this.btnToggle.Text = "Toggle Selection";
            this.messageSubItemTooltip.SetToolTip(this.btnToggle, "Select/ UnSelect all actions.");
            this.btnToggle.UseVisualStyleBackColor = true;
            this.btnToggle.Visible = false;
            this.btnToggle.Click += new System.EventHandler(this.btnToggle_Click);
            // 
            // btnExecute
            // 
            this.btnExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExecute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExecute.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExecute.Image = ((System.Drawing.Image)(resources.GetObject("btnExecute.Image")));
            this.btnExecute.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnExecute.Location = new System.Drawing.Point(164, 1167);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(75, 25);
            this.btnExecute.TabIndex = 10;
            this.btnExecute.Text = "Run";
            this.messageSubItemTooltip.SetToolTip(this.btnExecute, "Run selected actions.");
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Visible = false;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // grpBxMSI
            // 
            this.grpBxMSI.BackColor = System.Drawing.SystemColors.Window;
            this.grpBxMSI.Controls.Add(this.pictureBox1);
            this.grpBxMSI.Controls.Add(this.chkBxSSOKey);
            this.grpBxMSI.Controls.Add(this.txtBxSSOKey);
            this.grpBxMSI.Controls.Add(this.cbTargetEnvironment);
            this.grpBxMSI.Controls.Add(this.txtConfigAppName);
            this.grpBxMSI.Controls.Add(this.lblssoAppname);
            this.grpBxMSI.Controls.Add(this.btnBrowseConfig);
            this.grpBxMSI.Controls.Add(this.txtSSOConfigLoc);
            this.grpBxMSI.Controls.Add(this.lblssoLoc);
            this.grpBxMSI.Controls.Add(this.lblEnvName);
            this.grpBxMSI.Controls.Add(this.lblMsiLoc);
            this.grpBxMSI.Controls.Add(this.txtMSILocation);
            this.grpBxMSI.Controls.Add(this.btnBrowseMSI);
            this.grpBxMSI.Controls.Add(this.txtAppName);
            this.grpBxMSI.Controls.Add(this.lblAppName);
            this.grpBxMSI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBxMSI.Location = new System.Drawing.Point(3, 3);
            this.grpBxMSI.Name = "grpBxMSI";
            this.grpBxMSI.Size = new System.Drawing.Size(1586, 159);
            this.grpBxMSI.TabIndex = 8;
            this.grpBxMSI.TabStop = false;
            this.grpBxMSI.Text = "Deployment Configurations";
            // 
            // chkBxSSOKey
            // 
            this.chkBxSSOKey.AutoSize = true;
            this.chkBxSSOKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkBxSSOKey.Image = ((System.Drawing.Image)(resources.GetObject("chkBxSSOKey.Image")));
            this.chkBxSSOKey.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkBxSSOKey.Location = new System.Drawing.Point(424, 135);
            this.chkBxSSOKey.Name = "chkBxSSOKey";
            this.chkBxSSOKey.Size = new System.Drawing.Size(76, 17);
            this.chkBxSSOKey.TabIndex = 18;
            this.chkBxSSOKey.Text = "SSO Key    ";
            this.chkBxSSOKey.UseVisualStyleBackColor = true;
            this.chkBxSSOKey.Visible = false;
            this.chkBxSSOKey.CheckedChanged += new System.EventHandler(this.chkBxSSOKey_CheckedChanged);
            // 
            // txtBxSSOKey
            // 
            this.txtBxSSOKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBxSSOKey.Location = new System.Drawing.Point(502, 133);
            this.txtBxSSOKey.Name = "txtBxSSOKey";
            this.txtBxSSOKey.PasswordChar = '*';
            this.txtBxSSOKey.Size = new System.Drawing.Size(117, 21);
            this.txtBxSSOKey.TabIndex = 8;
            this.txtBxSSOKey.Visible = false;
            // 
            // cbTargetEnvironment
            // 
            this.cbTargetEnvironment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTargetEnvironment.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbTargetEnvironment.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.cbTargetEnvironment.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cbTargetEnvironment.FormattingEnabled = true;
            this.cbTargetEnvironment.Location = new System.Drawing.Point(118, 75);
            this.cbTargetEnvironment.MaxDropDownItems = 15;
            this.cbTargetEnvironment.Name = "cbTargetEnvironment";
            this.cbTargetEnvironment.Size = new System.Drawing.Size(294, 21);
            this.cbTargetEnvironment.TabIndex = 4;
            // 
            // txtConfigAppName
            // 
            this.txtConfigAppName.BackColor = System.Drawing.SystemColors.Window;
            this.txtConfigAppName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConfigAppName.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtConfigAppName.Location = new System.Drawing.Point(118, 131);
            this.txtConfigAppName.Name = "txtConfigAppName";
            this.txtConfigAppName.ReadOnly = true;
            this.txtConfigAppName.Size = new System.Drawing.Size(294, 21);
            this.txtConfigAppName.TabIndex = 7;
            // 
            // btnBrowseConfig
            // 
            this.btnBrowseConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseConfig.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnBrowseConfig.Image = ((System.Drawing.Image)(resources.GetObject("btnBrowseConfig.Image")));
            this.btnBrowseConfig.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBrowseConfig.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBrowseConfig.Location = new System.Drawing.Point(1492, 101);
            this.btnBrowseConfig.Name = "btnBrowseConfig";
            this.btnBrowseConfig.Size = new System.Drawing.Size(82, 23);
            this.btnBrowseConfig.TabIndex = 6;
            this.btnBrowseConfig.Text = "         Browse";
            this.btnBrowseConfig.UseVisualStyleBackColor = true;
            this.btnBrowseConfig.Click += new System.EventHandler(this.btnBrowseConfig_Click);
            // 
            // txtSSOConfigLoc
            // 
            this.txtSSOConfigLoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSSOConfigLoc.BackColor = System.Drawing.SystemColors.Window;
            this.txtSSOConfigLoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSSOConfigLoc.Location = new System.Drawing.Point(118, 102);
            this.txtSSOConfigLoc.Name = "txtSSOConfigLoc";
            this.txtSSOConfigLoc.ReadOnly = true;
            this.txtSSOConfigLoc.Size = new System.Drawing.Size(1357, 21);
            this.txtSSOConfigLoc.TabIndex = 5;
            // 
            // txtMSILocation
            // 
            this.txtMSILocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMSILocation.BackColor = System.Drawing.SystemColors.Window;
            this.txtMSILocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMSILocation.Location = new System.Drawing.Point(118, 20);
            this.txtMSILocation.Name = "txtMSILocation";
            this.txtMSILocation.ReadOnly = true;
            this.txtMSILocation.Size = new System.Drawing.Size(1357, 21);
            this.txtMSILocation.TabIndex = 1;
            // 
            // btnBrowseMSI
            // 
            this.btnBrowseMSI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseMSI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseMSI.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnBrowseMSI.Image = ((System.Drawing.Image)(resources.GetObject("btnBrowseMSI.Image")));
            this.btnBrowseMSI.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBrowseMSI.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBrowseMSI.Location = new System.Drawing.Point(1492, 20);
            this.btnBrowseMSI.Name = "btnBrowseMSI";
            this.btnBrowseMSI.Size = new System.Drawing.Size(82, 23);
            this.btnBrowseMSI.TabIndex = 2;
            this.btnBrowseMSI.Text = "         Browse";
            this.btnBrowseMSI.UseVisualStyleBackColor = true;
            this.btnBrowseMSI.Click += new System.EventHandler(this.btnBrowseMSI_Click);
            // 
            // txtAppName
            // 
            this.txtAppName.BackColor = System.Drawing.SystemColors.Window;
            this.txtAppName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAppName.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtAppName.Location = new System.Drawing.Point(118, 47);
            this.txtAppName.Name = "txtAppName";
            this.txtAppName.ReadOnly = true;
            this.txtAppName.Size = new System.Drawing.Size(294, 21);
            this.txtAppName.TabIndex = 3;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.ActionsPage);
            this.tabControl.Controls.Add(this.InstancesPage);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tabControl.ImageList = this.imageList1;
            this.tabControl.Location = new System.Drawing.Point(7, 201);
            this.tabControl.Name = "tabControl";
            this.tabControl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1600, 956);
            this.tabControl.TabIndex = 17;
            this.tabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // ActionsPage
            // 
            this.ActionsPage.Controls.Add(this.splitContainer1);
            this.ActionsPage.Location = new System.Drawing.Point(4, 23);
            this.ActionsPage.Name = "ActionsPage";
            this.ActionsPage.Padding = new System.Windows.Forms.Padding(3);
            this.ActionsPage.Size = new System.Drawing.Size(1592, 929);
            this.ActionsPage.TabIndex = 0;
            this.ActionsPage.Text = "Deploy Actions";
            this.ActionsPage.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listViewControl);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rTxtBxMessage);
            this.splitContainer1.Size = new System.Drawing.Size(1586, 923);
            this.splitContainer1.SplitterDistance = 854;
            this.splitContainer1.TabIndex = 14;
            // 
            // listViewControl
            // 
            this.listViewControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewControl.CheckBoxes = true;
            this.listViewControl.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Actions,
            this.Status,
            this.LastRun,
            this.Elapsed,
            this.Message});
            this.listViewControl.ContextMenuStrip = this.contextMenuStripAction;
            this.listViewControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewControl.FullRowSelect = true;
            this.listViewControl.GridLines = true;
            this.listViewControl.Location = new System.Drawing.Point(0, 0);
            this.listViewControl.Name = "listViewControl";
            this.listViewControl.Size = new System.Drawing.Size(1586, 854);
            this.listViewControl.TabIndex = 13;
            this.listViewControl.UseCompatibleStateImageBehavior = false;
            this.listViewControl.View = System.Windows.Forms.View.Details;
            this.listViewControl.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listViewControl_ItemCheck);
            this.listViewControl.SelectedIndexChanged += new System.EventHandler(this.listViewControl_SelectedIndexChanged);
            this.listViewControl.DoubleClick += new System.EventHandler(this.listViewControl_DoubleClick);
            this.listViewControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewControl_MouseClick);
            // 
            // Actions
            // 
            this.Actions.Text = "Action";
            this.Actions.Width = 450;
            // 
            // Status
            // 
            this.Status.Text = "Last Run Result";
            this.Status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Status.Width = 90;
            // 
            // LastRun
            // 
            this.LastRun.Text = "Last Run";
            this.LastRun.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.LastRun.Width = 130;
            // 
            // Elapsed
            // 
            this.Elapsed.Text = "Elapsed";
            this.Elapsed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Elapsed.Width = 85;
            // 
            // Message
            // 
            this.Message.Text = "Message";
            this.Message.Width = 1500;
            // 
            // rTxtBxMessage
            // 
            this.rTxtBxMessage.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.rTxtBxMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rTxtBxMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rTxtBxMessage.Location = new System.Drawing.Point(0, 0);
            this.rTxtBxMessage.Name = "rTxtBxMessage";
            this.rTxtBxMessage.ReadOnly = true;
            this.rTxtBxMessage.Size = new System.Drawing.Size(1586, 65);
            this.rTxtBxMessage.TabIndex = 0;
            this.rTxtBxMessage.Text = "";
            // 
            // InstancesPage
            // 
            this.InstancesPage.Controls.Add(this.splitContainer2);
            this.InstancesPage.Location = new System.Drawing.Point(4, 23);
            this.InstancesPage.Name = "InstancesPage";
            this.InstancesPage.Padding = new System.Windows.Forms.Padding(3);
            this.InstancesPage.Size = new System.Drawing.Size(1592, 929);
            this.InstancesPage.TabIndex = 1;
            this.InstancesPage.Text = "All In-Progress Service Instances";
            this.InstancesPage.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.instancesGridView);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(1586, 923);
            this.splitContainer2.SplitterDistance = 769;
            this.splitContainer2.TabIndex = 16;
            // 
            // instancesGridView
            // 
            this.instancesGridView.AllowUserToAddRows = false;
            this.instancesGridView.AllowUserToDeleteRows = false;
            this.instancesGridView.AllowUserToOrderColumns = true;
            this.instancesGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.instancesGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.instancesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.instancesGridView.ContextMenuStrip = this.contextMenuStripInstances;
            this.instancesGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.instancesGridView.Location = new System.Drawing.Point(0, 0);
            this.instancesGridView.Name = "instancesGridView";
            this.instancesGridView.ReadOnly = true;
            this.instancesGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.instancesGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.instancesGridView.Size = new System.Drawing.Size(1586, 769);
            this.instancesGridView.TabIndex = 15;
            // 
            // contextMenuStripInstances
            // 
            this.contextMenuStripInstances.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.terminateToolStripMenuItem,
            this.saveToFileToolStripMenuItem});
            this.contextMenuStripInstances.Name = "contextMenuStripInstances";
            this.contextMenuStripInstances.Size = new System.Drawing.Size(189, 48);
            // 
            // terminateToolStripMenuItem
            // 
            this.terminateToolStripMenuItem.Enabled = false;
            this.terminateToolStripMenuItem.Image = global::BizTalkDeploymentTool.Properties.Resources.Delete_tableHS;
            this.terminateToolStripMenuItem.Name = "terminateToolStripMenuItem";
            this.terminateToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.terminateToolStripMenuItem.Text = "Terminate Instance(s)";
            this.terminateToolStripMenuItem.Click += new System.EventHandler(this.terminateToolStripMenuItem_Click);
            // 
            // saveToFileToolStripMenuItem
            // 
            this.saveToFileToolStripMenuItem.Enabled = false;
            this.saveToFileToolStripMenuItem.Image = global::BizTalkDeploymentTool.Properties.Resources.SaveHL;
            this.saveToFileToolStripMenuItem.Name = "saveToFileToolStripMenuItem";
            this.saveToFileToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.saveToFileToolStripMenuItem.Text = "SaveToFile";
            this.saveToFileToolStripMenuItem.Click += new System.EventHandler(this.saveToFileToolStripMenuItem_Click);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.progressBar1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.label1);
            this.splitContainer3.Size = new System.Drawing.Size(1586, 150);
            this.splitContainer3.SplitterDistance = 103;
            this.splitContainer3.TabIndex = 0;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar1.Location = new System.Drawing.Point(0, 0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1586, 103);
            this.progressBar1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.ImageIndex = 1;
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1592, 929);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "Dependent Applications";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.splitContainerDependency);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1586, 923);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // splitContainerDependency
            // 
            this.splitContainerDependency.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerDependency.Location = new System.Drawing.Point(3, 17);
            this.splitContainerDependency.Name = "splitContainerDependency";
            // 
            // splitContainerDependency.Panel1
            // 
            this.splitContainerDependency.Panel1.Controls.Add(this.treeViewDependency);
            // 
            // splitContainerDependency.Panel2
            // 
            this.splitContainerDependency.Panel2.Controls.Add(this.propertyGridDepApps);
            this.splitContainerDependency.Panel2.Controls.Add(this.listView1);
            this.splitContainerDependency.Size = new System.Drawing.Size(1580, 903);
            this.splitContainerDependency.SplitterDistance = 333;
            this.splitContainerDependency.TabIndex = 1;
            // 
            // treeViewDependency
            // 
            this.treeViewDependency.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeViewDependency.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewDependency.HideSelection = false;
            this.treeViewDependency.ImageIndex = 0;
            this.treeViewDependency.ImageList = this.imageListTreeViewDepen;
            this.treeViewDependency.Location = new System.Drawing.Point(0, 0);
            this.treeViewDependency.Name = "treeViewDependency";
            this.treeViewDependency.SelectedImageIndex = 0;
            this.treeViewDependency.Size = new System.Drawing.Size(333, 903);
            this.treeViewDependency.TabIndex = 0;
            this.treeViewDependency.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewDependency_AfterSelect);
            this.treeViewDependency.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewDependency_NodeMouseClick);
            // 
            // imageListTreeViewDepen
            // 
            this.imageListTreeViewDepen.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListTreeViewDepen.ImageStream")));
            this.imageListTreeViewDepen.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListTreeViewDepen.Images.SetKeyName(0, "warning_exclamation.png");
            this.imageListTreeViewDepen.Images.SetKeyName(1, "stop.jpg");
            this.imageListTreeViewDepen.Images.SetKeyName(2, "true.jpg");
            // 
            // propertyGridDepApps
            // 
            this.propertyGridDepApps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridDepApps.Location = new System.Drawing.Point(0, 0);
            this.propertyGridDepApps.Name = "propertyGridDepApps";
            this.propertyGridDepApps.Size = new System.Drawing.Size(1243, 903);
            this.propertyGridDepApps.TabIndex = 1;
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1243, 903);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "warning_exclamation.png");
            this.imageList1.Images.SetKeyName(1, "info.png");
            // 
            // openMsiFileDialog
            // 
            this.openMsiFileDialog.Filter = "MSI file (*.msi)|*.msi|All files (*.*)|*.*";
            // 
            // openSsoFileDialog
            // 
            this.openSsoFileDialog.Filter = "SSO file (*.sso*)|*.sso*|All files (*.*)|*.*";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(0, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1600, 191);
            this.tabControl1.TabIndex = 21;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grpBxMSI);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1592, 165);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Farm Deploy";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Enter += new System.EventHandler(this.tabPage1_Enter);
            // 
            // contextMenuStripSelectDependentApp
            // 
            this.contextMenuStripSelectDependentApp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectMsiToolStripMenuItem});
            this.contextMenuStripSelectDependentApp.Name = "contextMenuStrip1";
            this.contextMenuStripSelectDependentApp.Size = new System.Drawing.Size(128, 26);
            // 
            // selectMsiToolStripMenuItem
            // 
            this.selectMsiToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("selectMsiToolStripMenuItem.Image")));
            this.selectMsiToolStripMenuItem.Name = "selectMsiToolStripMenuItem";
            this.selectMsiToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.selectMsiToolStripMenuItem.Text = "Select Msi";
            this.selectMsiToolStripMenuItem.Click += new System.EventHandler(this.selectMsiToolStripMenuItem_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(375, 1167);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 25);
            this.btnClear.TabIndex = 20;
            this.btnClear.Text = "    Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Visible = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Image = global::BizTalkDeploymentTool.Properties.Resources.Stop1;
            this.btnStop.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnStop.Location = new System.Drawing.Point(269, 1167);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 25);
            this.btnStop.TabIndex = 19;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Visible = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // contextMenuStripLoadActionsForDepApps
            // 
            this.contextMenuStripLoadActionsForDepApps.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadActionsToolStripMenuItem});
            this.contextMenuStripLoadActionsForDepApps.Name = "contextMenuStripLoadActionsForDepApps";
            this.contextMenuStripLoadActionsForDepApps.Size = new System.Drawing.Size(144, 26);
            // 
            // loadActionsToolStripMenuItem
            // 
            this.loadActionsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("loadActionsToolStripMenuItem.Image")));
            this.loadActionsToolStripMenuItem.Name = "loadActionsToolStripMenuItem";
            this.loadActionsToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.loadActionsToolStripMenuItem.Text = "Load Actions";
            this.loadActionsToolStripMenuItem.Click += new System.EventHandler(this.loadActionsToolStripMenuItem_Click);
            // 
            // MsiDeploy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btnToggle);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnExecute);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Name = "MsiDeploy";
            this.Size = new System.Drawing.Size(1600, 1200);
            this.Load += new System.EventHandler(this.BTDT_Load);
            this.contextMenuStripAction.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grpBxMSI.ResumeLayout(false);
            this.grpBxMSI.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.ActionsPage.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.InstancesPage.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.instancesGridView)).EndInit();
            this.contextMenuStripInstances.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.splitContainerDependency.Panel1.ResumeLayout(false);
            this.splitContainerDependency.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDependency)).EndInit();
            this.splitContainerDependency.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.contextMenuStripSelectDependentApp.ResumeLayout(false);
            this.contextMenuStripLoadActionsForDepApps.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStripAction;
        private System.Windows.Forms.ToolStripMenuItem runXSelectedActionsToolStripMenuItem;
        private System.Windows.Forms.ToolTip messageSubItemTooltip;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.GroupBox grpBxMSI;
        private System.Windows.Forms.ComboBox cbTargetEnvironment;
        private System.Windows.Forms.TextBox txtConfigAppName;
        private System.Windows.Forms.Label lblssoAppname;
        private System.Windows.Forms.Button btnBrowseConfig;
        private System.Windows.Forms.TextBox txtSSOConfigLoc;
        private System.Windows.Forms.Label lblssoLoc;
        private System.Windows.Forms.Label lblEnvName;
        private System.Windows.Forms.Label lblMsiLoc;
        private System.Windows.Forms.TextBox txtMSILocation;
        private System.Windows.Forms.Button btnBrowseMSI;
        private System.Windows.Forms.TextBox txtAppName;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Button btnToggle;
        private System.Windows.Forms.TextBox txtBxSSOKey;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage ActionsPage;
        private System.Windows.Forms.ListView listViewControl;
        private System.Windows.Forms.ColumnHeader Actions;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.ColumnHeader LastRun;
        private System.Windows.Forms.ColumnHeader Message;
        private System.Windows.Forms.TabPage InstancesPage;
        private System.Windows.Forms.DataGridView instancesGridView;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripInstances;
        private System.Windows.Forms.ToolStripMenuItem terminateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToFileToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkBxSSOKey;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox rTxtBxMessage;
        private System.Windows.Forms.OpenFileDialog openMsiFileDialog;
        private System.Windows.Forms.OpenFileDialog openSsoFileDialog;
        private System.Windows.Forms.FolderBrowserDialog folderSaveMessagesBrowserDialog;
        private System.Windows.Forms.ToolStripMenuItem checkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uncheckToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem runAllCheckedActionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem generateInstructionsToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader Elapsed;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TreeView treeViewDependency;
        private System.Windows.Forms.SplitContainer splitContainerDependency;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripSelectDependentApp;
        private System.Windows.Forms.ToolStripMenuItem selectMsiToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripLoadActionsForDepApps;
        private System.Windows.Forms.ToolStripMenuItem loadActionsToolStripMenuItem;
        private System.Windows.Forms.PropertyGrid propertyGridDepApps;
        private System.Windows.Forms.ImageList imageListTreeViewDepen;
    }
}
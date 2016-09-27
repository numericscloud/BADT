namespace BizTalkDeploymentTool
{
    partial class BTDFMsiDeploy
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BTDFMsiDeploy));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.openMsiFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnExecute = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnToggle = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.grpBxMSI = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxInstallLocation = new System.Windows.Forms.TextBox();
            this.textBoxBTDFProjName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbTargetEnvironment = new System.Windows.Forms.ComboBox();
            this.lblEnvName = new System.Windows.Forms.Label();
            this.lblMsiLoc = new System.Windows.Forms.Label();
            this.txtMSILocation = new System.Windows.Forms.TextBox();
            this.btnBrowseMSI = new System.Windows.Forms.Button();
            this.txtAppName = new System.Windows.Forms.TextBox();
            this.lblAppName = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.listViewControl = new System.Windows.Forms.ListView();
            this.Actions = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LastRun = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Elapsed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Message = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStripAction = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.checkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uncheckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.runXSelectedActionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.runAllCheckedActionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.rTxtBxMessage = new System.Windows.Forms.RichTextBox();
            this.InstancesPage = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.instancesGridView = new System.Windows.Forms.DataGridView();
            this.contextMenuStripInstances = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.terminateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EnvironmentVariableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.folderSaveMessagesBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.grpBxMSI.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.contextMenuStripAction.SuspendLayout();
            this.InstancesPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.instancesGridView)).BeginInit();
            this.contextMenuStripInstances.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openMsiFileDialog
            // 
            this.openMsiFileDialog.Filter = "MSI file (*.msi)|*.msi|All files (*.*)|*.*";
            // 
            // btnExecute
            // 
            this.btnExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExecute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExecute.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExecute.Image = ((System.Drawing.Image)(resources.GetObject("btnExecute.Image")));
            this.btnExecute.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnExecute.Location = new System.Drawing.Point(168, 558);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(75, 25);
            this.btnExecute.TabIndex = 21;
            this.btnExecute.Text = "Run";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Visible = false;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Image = global::BizTalkDeploymentTool.Properties.Resources.Stop1;
            this.btnStop.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnStop.Location = new System.Drawing.Point(273, 558);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 25);
            this.btnStop.TabIndex = 23;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Visible = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnToggle
            // 
            this.btnToggle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggle.Image = global::BizTalkDeploymentTool.Properties.Resources._112_RefreshArrow_Green_16x16_72;
            this.btnToggle.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnToggle.Location = new System.Drawing.Point(8, 558);
            this.btnToggle.Name = "btnToggle";
            this.btnToggle.Size = new System.Drawing.Size(130, 25);
            this.btnToggle.TabIndex = 22;
            this.btnToggle.Text = "Toggle Selection";
            this.btnToggle.UseVisualStyleBackColor = true;
            this.btnToggle.Visible = false;
            this.btnToggle.Click += new System.EventHandler(this.btnToggle_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(379, 558);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 25);
            this.btnClear.TabIndex = 24;
            this.btnClear.Text = "    Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Visible = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // grpBxMSI
            // 
            this.grpBxMSI.BackColor = System.Drawing.SystemColors.Window;
            this.grpBxMSI.Controls.Add(this.button1);
            this.grpBxMSI.Controls.Add(this.label2);
            this.grpBxMSI.Controls.Add(this.textBoxInstallLocation);
            this.grpBxMSI.Controls.Add(this.textBoxBTDFProjName);
            this.grpBxMSI.Controls.Add(this.label1);
            this.grpBxMSI.Controls.Add(this.cbTargetEnvironment);
            this.grpBxMSI.Controls.Add(this.lblEnvName);
            this.grpBxMSI.Controls.Add(this.lblMsiLoc);
            this.grpBxMSI.Controls.Add(this.txtMSILocation);
            this.grpBxMSI.Controls.Add(this.btnBrowseMSI);
            this.grpBxMSI.Controls.Add(this.txtAppName);
            this.grpBxMSI.Controls.Add(this.lblAppName);
            this.grpBxMSI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBxMSI.Location = new System.Drawing.Point(0, 0);
            this.grpBxMSI.Name = "grpBxMSI";
            this.grpBxMSI.Size = new System.Drawing.Size(891, 178);
            this.grpBxMSI.TabIndex = 9;
            this.grpBxMSI.TabStop = false;
            this.grpBxMSI.Text = "Deployment Configurations";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(797, 131);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "         Browse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(21, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Install Location";
            // 
            // textBoxInstallLocation
            // 
            this.textBoxInstallLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxInstallLocation.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxInstallLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxInstallLocation.Location = new System.Drawing.Point(118, 133);
            this.textBoxInstallLocation.Name = "textBoxInstallLocation";
            this.textBoxInstallLocation.ReadOnly = true;
            this.textBoxInstallLocation.Size = new System.Drawing.Size(662, 20);
            this.textBoxInstallLocation.TabIndex = 8;
            // 
            // textBoxBTDFProjName
            // 
            this.textBoxBTDFProjName.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxBTDFProjName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxBTDFProjName.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.textBoxBTDFProjName.Location = new System.Drawing.Point(118, 76);
            this.textBoxBTDFProjName.Name = "textBoxBTDFProjName";
            this.textBoxBTDFProjName.ReadOnly = true;
            this.textBoxBTDFProjName.Size = new System.Drawing.Size(294, 21);
            this.textBoxBTDFProjName.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(2, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "BTDF Project Name";
            // 
            // cbTargetEnvironment
            // 
            this.cbTargetEnvironment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTargetEnvironment.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbTargetEnvironment.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.cbTargetEnvironment.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cbTargetEnvironment.FormattingEnabled = true;
            this.cbTargetEnvironment.Location = new System.Drawing.Point(118, 105);
            this.cbTargetEnvironment.MaxDropDownItems = 15;
            this.cbTargetEnvironment.Name = "cbTargetEnvironment";
            this.cbTargetEnvironment.Size = new System.Drawing.Size(294, 21);
            this.cbTargetEnvironment.TabIndex = 4;
            // 
            // lblEnvName
            // 
            this.lblEnvName.AutoSize = true;
            this.lblEnvName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblEnvName.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblEnvName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblEnvName.Location = new System.Drawing.Point(33, 108);
            this.lblEnvName.Name = "lblEnvName";
            this.lblEnvName.Size = new System.Drawing.Size(67, 13);
            this.lblEnvName.TabIndex = 0;
            this.lblEnvName.Text = "Environment";
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
            this.txtMSILocation.Size = new System.Drawing.Size(662, 20);
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
            this.btnBrowseMSI.Location = new System.Drawing.Point(797, 20);
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
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.InstancesPage);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(4, 8);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(884, 544);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(876, 518);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Deploy Actions";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            this.splitContainer2.Panel1.Controls.Add(this.listViewControl);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.rTxtBxMessage);
            this.splitContainer2.Size = new System.Drawing.Size(870, 512);
            this.splitContainer2.SplitterDistance = 453;
            this.splitContainer2.TabIndex = 0;
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
            this.listViewControl.Size = new System.Drawing.Size(870, 453);
            this.listViewControl.TabIndex = 14;
            this.listViewControl.UseCompatibleStateImageBehavior = false;
            this.listViewControl.View = System.Windows.Forms.View.Details;
            this.listViewControl.SelectedIndexChanged += new System.EventHandler(this.listViewControl_SelectedIndexChanged);
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
            // contextMenuStripAction
            // 
            this.contextMenuStripAction.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkToolStripMenuItem,
            this.uncheckToolStripMenuItem,
            this.toolStripSeparator1,
            this.runXSelectedActionsToolStripMenuItem,
            this.toolStripSeparator2,
            this.runAllCheckedActionsToolStripMenuItem,
            this.toolStripSeparator3});
            this.contextMenuStripAction.Name = "contextMenuStripAction";
            this.contextMenuStripAction.Size = new System.Drawing.Size(199, 110);
            this.contextMenuStripAction.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripAction_Opening);
            // 
            // checkToolStripMenuItem
            // 
            this.checkToolStripMenuItem.Enabled = false;
            this.checkToolStripMenuItem.Image = global::BizTalkDeploymentTool.Properties.Resources.base_checkboxes;
            this.checkToolStripMenuItem.Name = "checkToolStripMenuItem";
            this.checkToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.checkToolStripMenuItem.Text = "Check";
            this.checkToolStripMenuItem.Click += new System.EventHandler(this.checkToolStripMenuItem_Click);
            // 
            // uncheckToolStripMenuItem
            // 
            this.uncheckToolStripMenuItem.Enabled = false;
            this.uncheckToolStripMenuItem.Image = global::BizTalkDeploymentTool.Properties.Resources.error;
            this.uncheckToolStripMenuItem.Name = "uncheckToolStripMenuItem";
            this.uncheckToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.uncheckToolStripMenuItem.Text = "Uncheck";
            this.uncheckToolStripMenuItem.Click += new System.EventHandler(this.uncheckToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(195, 6);
            // 
            // runXSelectedActionsToolStripMenuItem
            // 
            this.runXSelectedActionsToolStripMenuItem.Enabled = false;
            this.runXSelectedActionsToolStripMenuItem.Image = global::BizTalkDeploymentTool.Properties.Resources.Annotate_Complete;
            this.runXSelectedActionsToolStripMenuItem.Name = "runXSelectedActionsToolStripMenuItem";
            this.runXSelectedActionsToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.runXSelectedActionsToolStripMenuItem.Text = "Run x selected action(s)";
            this.runXSelectedActionsToolStripMenuItem.Click += new System.EventHandler(this.runXSelectedActionsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(195, 6);
            // 
            // runAllCheckedActionsToolStripMenuItem
            // 
            this.runAllCheckedActionsToolStripMenuItem.Enabled = false;
            this.runAllCheckedActionsToolStripMenuItem.Image = global::BizTalkDeploymentTool.Properties.Resources.Annotate_Default1;
            this.runAllCheckedActionsToolStripMenuItem.Name = "runAllCheckedActionsToolStripMenuItem";
            this.runAllCheckedActionsToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.runAllCheckedActionsToolStripMenuItem.Text = "Run x checked actions";
            this.runAllCheckedActionsToolStripMenuItem.Click += new System.EventHandler(this.runAllCheckedActionsToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(195, 6);
            // 
            // rTxtBxMessage
            // 
            this.rTxtBxMessage.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.rTxtBxMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rTxtBxMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rTxtBxMessage.Location = new System.Drawing.Point(0, 0);
            this.rTxtBxMessage.Name = "rTxtBxMessage";
            this.rTxtBxMessage.ReadOnly = true;
            this.rTxtBxMessage.Size = new System.Drawing.Size(870, 55);
            this.rTxtBxMessage.TabIndex = 1;
            this.rTxtBxMessage.Text = "";
            // 
            // InstancesPage
            // 
            this.InstancesPage.Controls.Add(this.splitContainer3);
            this.InstancesPage.Location = new System.Drawing.Point(4, 22);
            this.InstancesPage.Name = "InstancesPage";
            this.InstancesPage.Padding = new System.Windows.Forms.Padding(3);
            this.InstancesPage.Size = new System.Drawing.Size(876, 518);
            this.InstancesPage.TabIndex = 1;
            this.InstancesPage.Text = "All In-Progress Service Instances";
            this.InstancesPage.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(3, 3);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.label3);
            this.splitContainer3.Size = new System.Drawing.Size(870, 512);
            this.splitContainer3.SplitterDistance = 482;
            this.splitContainer3.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.instancesGridView);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.progressBar1);
            this.splitContainer4.Size = new System.Drawing.Size(870, 482);
            this.splitContainer4.SplitterDistance = 414;
            this.splitContainer4.TabIndex = 0;
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
            this.instancesGridView.Size = new System.Drawing.Size(870, 414);
            this.instancesGridView.TabIndex = 16;
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
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar1.Location = new System.Drawing.Point(0, 0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(870, 64);
            this.progressBar1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(876, 518);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "Configuration";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Description,
            this.EnvironmentVariableName,
            this.Value});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Size = new System.Drawing.Size(870, 512);
            this.dataGridView1.TabIndex = 0;
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Width = 500;
            // 
            // EnvironmentVariableName
            // 
            this.EnvironmentVariableName.HeaderText = "Environment Variable Name";
            this.EnvironmentVariableName.Name = "EnvironmentVariableName";
            this.EnvironmentVariableName.ReadOnly = true;
            this.EnvironmentVariableName.Width = 200;
            // 
            // Value
            // 
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            this.Value.Width = 300;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grpBxMSI);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel2.Controls.Add(this.btnClear);
            this.splitContainer1.Panel2.Controls.Add(this.btnToggle);
            this.splitContainer1.Panel2.Controls.Add(this.btnStop);
            this.splitContainer1.Panel2.Controls.Add(this.btnExecute);
            this.splitContainer1.Size = new System.Drawing.Size(891, 777);
            this.splitContainer1.SplitterDistance = 178;
            this.splitContainer1.TabIndex = 0;
            // 
            // BTDFMsiDeploy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "BTDFMsiDeploy";
            this.Size = new System.Drawing.Size(891, 777);
            this.grpBxMSI.ResumeLayout(false);
            this.grpBxMSI.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.contextMenuStripAction.ResumeLayout(false);
            this.InstancesPage.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.instancesGridView)).EndInit();
            this.contextMenuStripInstances.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openMsiFileDialog;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnToggle;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox grpBxMSI;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxInstallLocation;
        private System.Windows.Forms.TextBox textBoxBTDFProjName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbTargetEnvironment;
        private System.Windows.Forms.Label lblEnvName;
        private System.Windows.Forms.Label lblMsiLoc;
        private System.Windows.Forms.TextBox txtMSILocation;
        private System.Windows.Forms.Button btnBrowseMSI;
        private System.Windows.Forms.TextBox txtAppName;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage InstancesPage;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListView listViewControl;
        private System.Windows.Forms.ColumnHeader Actions;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.ColumnHeader LastRun;
        private System.Windows.Forms.ColumnHeader Elapsed;
        private System.Windows.Forms.ColumnHeader Message;
        private System.Windows.Forms.RichTextBox rTxtBxMessage;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.DataGridView instancesGridView;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripInstances;
        private System.Windows.Forms.ToolStripMenuItem terminateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToFileToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderSaveMessagesBrowserDialog;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn EnvironmentVariableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripAction;
        private System.Windows.Forms.ToolStripMenuItem checkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uncheckToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem runXSelectedActionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem runAllCheckedActionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;


    }
}

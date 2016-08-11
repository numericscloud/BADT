namespace BizTalkDeploymentTool
{
    partial class BusinessRulesDeploymentWizard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BusinessRulesDeploymentWizard));
            this.tabControlBRE = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.richTextBoxMessage = new System.Windows.Forms.RichTextBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnToggle = new System.Windows.Forms.Button();
            this.listViewImportAndPublish = new System.Windows.Forms.ListView();
            this.FilePath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Message = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnVocabularies = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnDeploy = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBoxDeployMessage = new System.Windows.Forms.RichTextBox();
            this.listViewDeployPolicy = new System.Windows.Forms.ListView();
            this.PolicyName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MajorVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MinorVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.State = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Result = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.buttonUnDeploy = new System.Windows.Forms.Button();
            this.buttonToggleUnDeploy = new System.Windows.Forms.Button();
            this.richTextBoxUnDeploy = new System.Windows.Forms.RichTextBox();
            this.listViewUnDeployPolicy = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageDeletePolicy = new System.Windows.Forms.TabPage();
            this.buttonDeletePolicy = new System.Windows.Forms.Button();
            this.buttonToggleDeletePolicy = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.listViewDeletePolicy = new System.Windows.Forms.ListView();
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageDeleteVocabulary = new System.Windows.Forms.TabPage();
            this.buttonDeleteVocabulary = new System.Windows.Forms.Button();
            this.buttonToggleDeleteVocabulary = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.listViewDeleteVocabulary = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.openVocabularyDialog = new System.Windows.Forms.OpenFileDialog();
            this.ArtifactsBtnToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControlBRE.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPageDeletePolicy.SuspendLayout();
            this.tabPageDeleteVocabulary.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlBRE
            // 
            this.tabControlBRE.Controls.Add(this.tabPage1);
            this.tabControlBRE.Controls.Add(this.tabPage2);
            this.tabControlBRE.Controls.Add(this.tabPage3);
            this.tabControlBRE.Controls.Add(this.tabPageDeletePolicy);
            this.tabControlBRE.Controls.Add(this.tabPageDeleteVocabulary);
            this.tabControlBRE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlBRE.Location = new System.Drawing.Point(3, 17);
            this.tabControlBRE.Name = "tabControlBRE";
            this.tabControlBRE.SelectedIndex = 0;
            this.tabControlBRE.Size = new System.Drawing.Size(1010, 633);
            this.tabControlBRE.TabIndex = 0;
            this.tabControlBRE.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControlBRE_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.richTextBoxMessage);
            this.tabPage1.Controls.Add(this.btnImport);
            this.tabPage1.Controls.Add(this.btnToggle);
            this.tabPage1.Controls.Add(this.listViewImportAndPublish);
            this.tabPage1.Controls.Add(this.btnVocabularies);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1002, 607);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Import-Publish Brl";
            this.tabPage1.Enter += new System.EventHandler(this.tabPage1_Enter);
            // 
            // richTextBoxMessage
            // 
            this.richTextBoxMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxMessage.Location = new System.Drawing.Point(12, 464);
            this.richTextBoxMessage.Name = "richTextBoxMessage";
            this.richTextBoxMessage.Size = new System.Drawing.Size(979, 68);
            this.richTextBoxMessage.TabIndex = 17;
            this.richTextBoxMessage.Text = "";
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Image = ((System.Drawing.Image)(resources.GetObject("btnImport.Image")));
            this.btnImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImport.Location = new System.Drawing.Point(176, 554);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(116, 25);
            this.btnImport.TabIndex = 16;
            this.btnImport.Text = "Import-Publish";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnToggle
            // 
            this.btnToggle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggle.Image = global::BizTalkDeploymentTool.Properties.Resources._112_RefreshArrow_Green_16x16_72;
            this.btnToggle.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnToggle.Location = new System.Drawing.Point(12, 554);
            this.btnToggle.Name = "btnToggle";
            this.btnToggle.Size = new System.Drawing.Size(132, 25);
            this.btnToggle.TabIndex = 15;
            this.btnToggle.Text = "Toggle Selection";
            this.btnToggle.UseVisualStyleBackColor = true;
            this.btnToggle.Click += new System.EventHandler(this.btnToggle_Click);
            // 
            // listViewImportAndPublish
            // 
            this.listViewImportAndPublish.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewImportAndPublish.CheckBoxes = true;
            this.listViewImportAndPublish.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FilePath,
            this.Status,
            this.Message});
            this.listViewImportAndPublish.FullRowSelect = true;
            this.listViewImportAndPublish.GridLines = true;
            this.listViewImportAndPublish.Location = new System.Drawing.Point(12, 35);
            this.listViewImportAndPublish.Name = "listViewImportAndPublish";
            this.listViewImportAndPublish.Size = new System.Drawing.Size(979, 410);
            this.listViewImportAndPublish.TabIndex = 1;
            this.listViewImportAndPublish.UseCompatibleStateImageBehavior = false;
            this.listViewImportAndPublish.View = System.Windows.Forms.View.Details;
            this.listViewImportAndPublish.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewVocabularies_MouseClick);
            // 
            // FilePath
            // 
            this.FilePath.Text = "FilePath";
            this.FilePath.Width = 397;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            this.Status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Status.Width = 110;
            // 
            // Message
            // 
            this.Message.Text = "Message";
            this.Message.Width = 500;
            // 
            // btnVocabularies
            // 
            this.btnVocabularies.Image = ((System.Drawing.Image)(resources.GetObject("btnVocabularies.Image")));
            this.btnVocabularies.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVocabularies.Location = new System.Drawing.Point(12, 6);
            this.btnVocabularies.Name = "btnVocabularies";
            this.btnVocabularies.Size = new System.Drawing.Size(94, 23);
            this.btnVocabularies.TabIndex = 0;
            this.btnVocabularies.Text = "Add";
            this.btnVocabularies.UseVisualStyleBackColor = true;
            this.btnVocabularies.Click += new System.EventHandler(this.btnVocabularies_Click);
            this.btnVocabularies.MouseHover += new System.EventHandler(this.btnVocabularies_MouseHover);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.btnDeploy);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.richTextBoxDeployMessage);
            this.tabPage2.Controls.Add(this.listViewDeployPolicy);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1002, 608);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Deploy Policy";
            this.tabPage2.Enter += new System.EventHandler(this.tabPage2_Enter);
            // 
            // btnDeploy
            // 
            this.btnDeploy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeploy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeploy.Image = ((System.Drawing.Image)(resources.GetObject("btnDeploy.Image")));
            this.btnDeploy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeploy.Location = new System.Drawing.Point(176, 538);
            this.btnDeploy.Name = "btnDeploy";
            this.btnDeploy.Size = new System.Drawing.Size(90, 25);
            this.btnDeploy.TabIndex = 17;
            this.btnDeploy.Text = "Deploy";
            this.btnDeploy.UseVisualStyleBackColor = true;
            this.btnDeploy.Click += new System.EventHandler(this.btnDeploy_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::BizTalkDeploymentTool.Properties.Resources._112_RefreshArrow_Green_16x16_72;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button1.Location = new System.Drawing.Point(12, 538);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 25);
            this.button1.TabIndex = 16;
            this.button1.Text = "Toggle Selection";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBoxDeployMessage
            // 
            this.richTextBoxDeployMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxDeployMessage.Location = new System.Drawing.Point(12, 448);
            this.richTextBoxDeployMessage.Name = "richTextBoxDeployMessage";
            this.richTextBoxDeployMessage.Size = new System.Drawing.Size(983, 68);
            this.richTextBoxDeployMessage.TabIndex = 1;
            this.richTextBoxDeployMessage.Text = "";
            // 
            // listViewDeployPolicy
            // 
            this.listViewDeployPolicy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewDeployPolicy.CheckBoxes = true;
            this.listViewDeployPolicy.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PolicyName,
            this.MajorVersion,
            this.MinorVersion,
            this.State,
            this.Result});
            this.listViewDeployPolicy.FullRowSelect = true;
            this.listViewDeployPolicy.GridLines = true;
            this.listViewDeployPolicy.Location = new System.Drawing.Point(12, 35);
            this.listViewDeployPolicy.Name = "listViewDeployPolicy";
            this.listViewDeployPolicy.Size = new System.Drawing.Size(983, 394);
            this.listViewDeployPolicy.TabIndex = 0;
            this.listViewDeployPolicy.UseCompatibleStateImageBehavior = false;
            this.listViewDeployPolicy.View = System.Windows.Forms.View.Details;
            this.listViewDeployPolicy.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewDeployPolicy_MouseClick);
            // 
            // PolicyName
            // 
            this.PolicyName.Text = "PolicyName";
            this.PolicyName.Width = 400;
            // 
            // MajorVersion
            // 
            this.MajorVersion.Text = "MajorVersion";
            this.MajorVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MajorVersion.Width = 85;
            // 
            // MinorVersion
            // 
            this.MinorVersion.Text = "MinorVersion";
            this.MinorVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MinorVersion.Width = 85;
            // 
            // State
            // 
            this.State.Text = "State";
            this.State.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.State.Width = 100;
            // 
            // Result
            // 
            this.Result.Text = "Result";
            this.Result.Width = 350;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.buttonUnDeploy);
            this.tabPage3.Controls.Add(this.buttonToggleUnDeploy);
            this.tabPage3.Controls.Add(this.richTextBoxUnDeploy);
            this.tabPage3.Controls.Add(this.listViewUnDeployPolicy);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1002, 608);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Un-Deploy Policy";
            this.tabPage3.Enter += new System.EventHandler(this.tabPage3_Enter);
            // 
            // buttonUnDeploy
            // 
            this.buttonUnDeploy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonUnDeploy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUnDeploy.Image = ((System.Drawing.Image)(resources.GetObject("buttonUnDeploy.Image")));
            this.buttonUnDeploy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonUnDeploy.Location = new System.Drawing.Point(176, 538);
            this.buttonUnDeploy.Name = "buttonUnDeploy";
            this.buttonUnDeploy.Size = new System.Drawing.Size(90, 25);
            this.buttonUnDeploy.TabIndex = 21;
            this.buttonUnDeploy.Text = "  UnDeploy";
            this.buttonUnDeploy.UseVisualStyleBackColor = true;
            this.buttonUnDeploy.Click += new System.EventHandler(this.buttonUnDeploy_Click);
            this.buttonUnDeploy.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonUnDeploy_MouseClick);
            // 
            // buttonToggleUnDeploy
            // 
            this.buttonToggleUnDeploy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonToggleUnDeploy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonToggleUnDeploy.Image = global::BizTalkDeploymentTool.Properties.Resources._112_RefreshArrow_Green_16x16_72;
            this.buttonToggleUnDeploy.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.buttonToggleUnDeploy.Location = new System.Drawing.Point(12, 538);
            this.buttonToggleUnDeploy.Name = "buttonToggleUnDeploy";
            this.buttonToggleUnDeploy.Size = new System.Drawing.Size(132, 25);
            this.buttonToggleUnDeploy.TabIndex = 20;
            this.buttonToggleUnDeploy.Text = "Toggle Selection";
            this.buttonToggleUnDeploy.UseVisualStyleBackColor = true;
            this.buttonToggleUnDeploy.Click += new System.EventHandler(this.buttonToggleUnDeploy_Click);
            // 
            // richTextBoxUnDeploy
            // 
            this.richTextBoxUnDeploy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxUnDeploy.Location = new System.Drawing.Point(12, 448);
            this.richTextBoxUnDeploy.Name = "richTextBoxUnDeploy";
            this.richTextBoxUnDeploy.Size = new System.Drawing.Size(983, 68);
            this.richTextBoxUnDeploy.TabIndex = 19;
            this.richTextBoxUnDeploy.Text = "";
            // 
            // listViewUnDeployPolicy
            // 
            this.listViewUnDeployPolicy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewUnDeployPolicy.CheckBoxes = true;
            this.listViewUnDeployPolicy.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listViewUnDeployPolicy.FullRowSelect = true;
            this.listViewUnDeployPolicy.GridLines = true;
            this.listViewUnDeployPolicy.Location = new System.Drawing.Point(12, 35);
            this.listViewUnDeployPolicy.MultiSelect = false;
            this.listViewUnDeployPolicy.Name = "listViewUnDeployPolicy";
            this.listViewUnDeployPolicy.Size = new System.Drawing.Size(983, 394);
            this.listViewUnDeployPolicy.TabIndex = 18;
            this.listViewUnDeployPolicy.UseCompatibleStateImageBehavior = false;
            this.listViewUnDeployPolicy.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "PolicyName";
            this.columnHeader1.Width = 400;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "MajorVersion";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 85;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "MinorVersion";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 85;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "State";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Result";
            this.columnHeader5.Width = 350;
            // 
            // tabPageDeletePolicy
            // 
            this.tabPageDeletePolicy.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageDeletePolicy.Controls.Add(this.buttonDeletePolicy);
            this.tabPageDeletePolicy.Controls.Add(this.buttonToggleDeletePolicy);
            this.tabPageDeletePolicy.Controls.Add(this.richTextBox2);
            this.tabPageDeletePolicy.Controls.Add(this.listViewDeletePolicy);
            this.tabPageDeletePolicy.Location = new System.Drawing.Point(4, 22);
            this.tabPageDeletePolicy.Name = "tabPageDeletePolicy";
            this.tabPageDeletePolicy.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDeletePolicy.Size = new System.Drawing.Size(1002, 608);
            this.tabPageDeletePolicy.TabIndex = 4;
            this.tabPageDeletePolicy.Text = "Delete Policy";
            this.tabPageDeletePolicy.Enter += new System.EventHandler(this.tabPageDeletePolicy_Enter);
            // 
            // buttonDeletePolicy
            // 
            this.buttonDeletePolicy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDeletePolicy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeletePolicy.Image = global::BizTalkDeploymentTool.Properties.Resources.Annotate_Disabled1;
            this.buttonDeletePolicy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDeletePolicy.Location = new System.Drawing.Point(176, 538);
            this.buttonDeletePolicy.Name = "buttonDeletePolicy";
            this.buttonDeletePolicy.Size = new System.Drawing.Size(90, 25);
            this.buttonDeletePolicy.TabIndex = 25;
            this.buttonDeletePolicy.Text = "  Delete";
            this.buttonDeletePolicy.UseVisualStyleBackColor = true;
            this.buttonDeletePolicy.Click += new System.EventHandler(this.buttonDeletePolicy_Click);
            // 
            // buttonToggleDeletePolicy
            // 
            this.buttonToggleDeletePolicy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonToggleDeletePolicy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonToggleDeletePolicy.Image = global::BizTalkDeploymentTool.Properties.Resources._112_RefreshArrow_Green_16x16_72;
            this.buttonToggleDeletePolicy.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.buttonToggleDeletePolicy.Location = new System.Drawing.Point(12, 538);
            this.buttonToggleDeletePolicy.Name = "buttonToggleDeletePolicy";
            this.buttonToggleDeletePolicy.Size = new System.Drawing.Size(132, 25);
            this.buttonToggleDeletePolicy.TabIndex = 24;
            this.buttonToggleDeletePolicy.Text = "Toggle Selection";
            this.buttonToggleDeletePolicy.UseVisualStyleBackColor = true;
            this.buttonToggleDeletePolicy.Click += new System.EventHandler(this.buttonToggleDeletePolicy_Click);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox2.Location = new System.Drawing.Point(12, 448);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(983, 68);
            this.richTextBox2.TabIndex = 23;
            this.richTextBox2.Text = "";
            // 
            // listViewDeletePolicy
            // 
            this.listViewDeletePolicy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewDeletePolicy.CheckBoxes = true;
            this.listViewDeletePolicy.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15});
            this.listViewDeletePolicy.FullRowSelect = true;
            this.listViewDeletePolicy.GridLines = true;
            this.listViewDeletePolicy.Location = new System.Drawing.Point(12, 35);
            this.listViewDeletePolicy.Name = "listViewDeletePolicy";
            this.listViewDeletePolicy.Size = new System.Drawing.Size(983, 394);
            this.listViewDeletePolicy.TabIndex = 22;
            this.listViewDeletePolicy.UseCompatibleStateImageBehavior = false;
            this.listViewDeletePolicy.View = System.Windows.Forms.View.Details;
            this.listViewDeletePolicy.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewDeletePolicy_MouseClick);
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "PolicyName";
            this.columnHeader11.Width = 400;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "MajorVersion";
            this.columnHeader12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader12.Width = 85;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "MinorVersion";
            this.columnHeader13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader13.Width = 85;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "State";
            this.columnHeader14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader14.Width = 100;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Result";
            this.columnHeader15.Width = 350;
            // 
            // tabPageDeleteVocabulary
            // 
            this.tabPageDeleteVocabulary.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageDeleteVocabulary.Controls.Add(this.buttonDeleteVocabulary);
            this.tabPageDeleteVocabulary.Controls.Add(this.buttonToggleDeleteVocabulary);
            this.tabPageDeleteVocabulary.Controls.Add(this.richTextBox1);
            this.tabPageDeleteVocabulary.Controls.Add(this.listViewDeleteVocabulary);
            this.tabPageDeleteVocabulary.Location = new System.Drawing.Point(4, 22);
            this.tabPageDeleteVocabulary.Name = "tabPageDeleteVocabulary";
            this.tabPageDeleteVocabulary.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDeleteVocabulary.Size = new System.Drawing.Size(1002, 608);
            this.tabPageDeleteVocabulary.TabIndex = 3;
            this.tabPageDeleteVocabulary.Text = "Delete Vocabulary";
            this.tabPageDeleteVocabulary.Enter += new System.EventHandler(this.tabPageDeleteVocabulary_Enter);
            // 
            // buttonDeleteVocabulary
            // 
            this.buttonDeleteVocabulary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDeleteVocabulary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteVocabulary.Image = global::BizTalkDeploymentTool.Properties.Resources.Annotate_Disabled1;
            this.buttonDeleteVocabulary.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDeleteVocabulary.Location = new System.Drawing.Point(176, 538);
            this.buttonDeleteVocabulary.Name = "buttonDeleteVocabulary";
            this.buttonDeleteVocabulary.Size = new System.Drawing.Size(90, 25);
            this.buttonDeleteVocabulary.TabIndex = 25;
            this.buttonDeleteVocabulary.Text = "  Delete";
            this.buttonDeleteVocabulary.UseVisualStyleBackColor = true;
            this.buttonDeleteVocabulary.Click += new System.EventHandler(this.buttonDeleteVocabulary_Click);
            // 
            // buttonToggleDeleteVocabulary
            // 
            this.buttonToggleDeleteVocabulary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonToggleDeleteVocabulary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonToggleDeleteVocabulary.Image = global::BizTalkDeploymentTool.Properties.Resources._112_RefreshArrow_Green_16x16_72;
            this.buttonToggleDeleteVocabulary.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.buttonToggleDeleteVocabulary.Location = new System.Drawing.Point(12, 538);
            this.buttonToggleDeleteVocabulary.Name = "buttonToggleDeleteVocabulary";
            this.buttonToggleDeleteVocabulary.Size = new System.Drawing.Size(132, 25);
            this.buttonToggleDeleteVocabulary.TabIndex = 24;
            this.buttonToggleDeleteVocabulary.Text = "Toggle Selection";
            this.buttonToggleDeleteVocabulary.UseVisualStyleBackColor = true;
            this.buttonToggleDeleteVocabulary.Click += new System.EventHandler(this.buttonToggleDeleteVocabulary_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(12, 448);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(983, 68);
            this.richTextBox1.TabIndex = 23;
            this.richTextBox1.Text = "";
            // 
            // listViewDeleteVocabulary
            // 
            this.listViewDeleteVocabulary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewDeleteVocabulary.CheckBoxes = true;
            this.listViewDeleteVocabulary.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.listViewDeleteVocabulary.FullRowSelect = true;
            this.listViewDeleteVocabulary.GridLines = true;
            this.listViewDeleteVocabulary.Location = new System.Drawing.Point(12, 35);
            this.listViewDeleteVocabulary.Name = "listViewDeleteVocabulary";
            this.listViewDeleteVocabulary.Size = new System.Drawing.Size(983, 394);
            this.listViewDeleteVocabulary.TabIndex = 22;
            this.listViewDeleteVocabulary.UseCompatibleStateImageBehavior = false;
            this.listViewDeleteVocabulary.View = System.Windows.Forms.View.Details;
            this.listViewDeleteVocabulary.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewDeleteVocabulary_MouseClick);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "VocabularyName";
            this.columnHeader6.Width = 400;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "MajorVersion";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader7.Width = 85;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "MinorVersion";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader8.Width = 85;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "State";
            this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader9.Width = 100;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Result";
            this.columnHeader10.Width = 350;
            // 
            // openVocabularyDialog
            // 
            this.openVocabularyDialog.FileName = "openVocabularyDialog";
            this.openVocabularyDialog.Filter = "XML file (*.xml)|*.xml|All files (*.*)|*.*";
            this.openVocabularyDialog.Multiselect = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControlBRE);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1016, 653);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(100, 26);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.viewToolStripMenuItem.Text = "View";
            this.viewToolStripMenuItem.Click += new System.EventHandler(this.viewToolStripMenuItem_Click);
            // 
            // BusinessRulesDeploymentWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 653);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BusinessRulesDeploymentWizard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Business Rules Deployment Wizard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BusinessRulesDeploymentWizard_FormClosing);
            this.tabControlBRE.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPageDeletePolicy.ResumeLayout(false);
            this.tabPageDeleteVocabulary.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlBRE;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.OpenFileDialog openVocabularyDialog;
        private System.Windows.Forms.Button btnVocabularies;
        private System.Windows.Forms.ListView listViewImportAndPublish;
        private System.Windows.Forms.ListView listViewDeployPolicy;
        private System.Windows.Forms.ColumnHeader FilePath;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.Button btnToggle;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.ColumnHeader Message;
        private System.Windows.Forms.RichTextBox richTextBoxMessage;
        private System.Windows.Forms.ColumnHeader PolicyName;
        private System.Windows.Forms.ColumnHeader MajorVersion;
        private System.Windows.Forms.ColumnHeader MinorVersion;
        private System.Windows.Forms.ColumnHeader State;
        private System.Windows.Forms.ColumnHeader Result;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBoxDeployMessage;
        private System.Windows.Forms.Button btnDeploy;
        private System.Windows.Forms.ToolTip ArtifactsBtnToolTip;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button buttonUnDeploy;
        private System.Windows.Forms.Button buttonToggleUnDeploy;
        private System.Windows.Forms.RichTextBox richTextBoxUnDeploy;
        private System.Windows.Forms.ListView listViewUnDeployPolicy;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.TabPage tabPageDeleteVocabulary;
        private System.Windows.Forms.Button buttonDeleteVocabulary;
        private System.Windows.Forms.Button buttonToggleDeleteVocabulary;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ListView listViewDeleteVocabulary;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.TabPage tabPageDeletePolicy;
        private System.Windows.Forms.Button buttonDeletePolicy;
        private System.Windows.Forms.Button buttonToggleDeletePolicy;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.ListView listViewDeletePolicy;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
    }
}
namespace BizTalkDeploymentTool
{
    partial class DeploymentHealthCheck
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeploymentHealthCheck));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBxAppList = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listViewHelathCheck = new System.Windows.Forms.ListView();
            this.ServerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Installed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.InstallationGuid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewResources = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.locateMSIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDesignToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCheck);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBxAppList);
            this.groupBox1.Location = new System.Drawing.Point(4, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(718, 59);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Application";
            // 
            // btnCheck
            // 
            this.btnCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheck.Image = ((System.Drawing.Image)(resources.GetObject("btnCheck.Image")));
            this.btnCheck.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheck.Location = new System.Drawing.Point(609, 18);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(80, 24);
            this.btnCheck.TabIndex = 0;
            this.btnCheck.Text = "Check";
            this.btnCheck.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 1;
            // 
            // comboBxAppList
            // 
            this.comboBxAppList.BackColor = System.Drawing.SystemColors.Info;
            this.comboBxAppList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBxAppList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBxAppList.FormattingEnabled = true;
            this.comboBxAppList.Location = new System.Drawing.Point(7, 20);
            this.comboBxAppList.Name = "comboBxAppList";
            this.comboBxAppList.Size = new System.Drawing.Size(568, 21);
            this.comboBxAppList.TabIndex = 0;
            this.comboBxAppList.SelectedIndexChanged += new System.EventHandler(this.comboBxAppList_SelectedIndexChanged);
            this.comboBxAppList.TextUpdate += new System.EventHandler(this.comboBxAppList_TextUpdate);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(4, 93);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listViewHelathCheck);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listViewResources);
            this.splitContainer1.Size = new System.Drawing.Size(895, 612);
            this.splitContainer1.SplitterDistance = 255;
            this.splitContainer1.TabIndex = 3;
            // 
            // listViewHelathCheck
            // 
            this.listViewHelathCheck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewHelathCheck.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ServerName,
            this.Installed,
            this.InstallationGuid,
            this.columnHeader1});
            this.listViewHelathCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewHelathCheck.FullRowSelect = true;
            this.listViewHelathCheck.GridLines = true;
            this.listViewHelathCheck.Location = new System.Drawing.Point(0, 0);
            this.listViewHelathCheck.Name = "listViewHelathCheck";
            this.listViewHelathCheck.Size = new System.Drawing.Size(895, 255);
            this.listViewHelathCheck.TabIndex = 2;
            this.listViewHelathCheck.UseCompatibleStateImageBehavior = false;
            this.listViewHelathCheck.View = System.Windows.Forms.View.Details;
            // 
            // ServerName
            // 
            this.ServerName.Text = "Server Name";
            this.ServerName.Width = 125;
            // 
            // Installed
            // 
            this.Installed.Text = "Installed";
            this.Installed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Installed.Width = 110;
            // 
            // InstallationGuid
            // 
            this.InstallationGuid.Text = "Installation Guid";
            this.InstallationGuid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.InstallationGuid.Width = 325;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Install Date";
            this.columnHeader1.Width = 225;
            // 
            // listViewResources
            // 
            this.listViewResources.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewResources.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.listViewResources.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewResources.FullRowSelect = true;
            this.listViewResources.GridLines = true;
            this.listViewResources.Location = new System.Drawing.Point(0, 0);
            this.listViewResources.Name = "listViewResources";
            this.listViewResources.Size = new System.Drawing.Size(895, 353);
            this.listViewResources.TabIndex = 4;
            this.listViewResources.UseCompatibleStateImageBehavior = false;
            this.listViewResources.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Resource Name";
            this.columnHeader2.Width = 125;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "StatusimagesKMDM14XD.jpg");
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(904, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.locateMSIToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // locateMSIToolStripMenuItem
            // 
            this.locateMSIToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("locateMSIToolStripMenuItem.Image")));
            this.locateMSIToolStripMenuItem.Name = "locateMSIToolStripMenuItem";
            this.locateMSIToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.locateMSIToolStripMenuItem.Text = "Locate-MSI";
            this.locateMSIToolStripMenuItem.Click += new System.EventHandler(this.locateMSIToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDesignToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(68, 26);
            // 
            // showDesignToolStripMenuItem
            // 
            this.showDesignToolStripMenuItem.Name = "showDesignToolStripMenuItem";
            this.showDesignToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            // 
            // DeploymentHealthCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 708);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DeploymentHealthCheck";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Deployment HealthCheck";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DeploymentHealthCheck_FormClosing);
            this.Load += new System.EventHandler(this.DeploymentHealthCheck_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBxAppList;
        private System.Windows.Forms.ListView listViewHelathCheck;
        private System.Windows.Forms.ColumnHeader ServerName;
        private System.Windows.Forms.ColumnHeader Installed;
        private System.Windows.Forms.ColumnHeader InstallationGuid;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem locateMSIToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView listViewResources;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showDesignToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
    }
}
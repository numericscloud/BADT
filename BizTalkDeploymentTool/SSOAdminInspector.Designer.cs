namespace BizTalkDeploymentTool
{
    partial class SSOAdminInspector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SSOAdminInspector));
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeViewSSOApps = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.propertyGridSSOProps = new System.Windows.Forms.PropertyGrid();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.getCredentialsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1076, 761);
            this.panel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeViewSSOApps);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.propertyGridSSOProps);
            this.splitContainer1.Size = new System.Drawing.Size(1076, 761);
            this.splitContainer1.SplitterDistance = 436;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeViewSSOApps
            // 
            this.treeViewSSOApps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewSSOApps.ImageIndex = 0;
            this.treeViewSSOApps.ImageList = this.imageList1;
            this.treeViewSSOApps.Location = new System.Drawing.Point(0, 0);
            this.treeViewSSOApps.Name = "treeViewSSOApps";
            this.treeViewSSOApps.SelectedImageIndex = 0;
            this.treeViewSSOApps.Size = new System.Drawing.Size(436, 761);
            this.treeViewSSOApps.TabIndex = 0;
            this.treeViewSSOApps.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewSSOApps_AfterSelect);
            this.treeViewSSOApps.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewSSOApps_NodeMouseClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "sso-icon.png");
            this.imageList1.Images.SetKeyName(1, "sso-to-go-9-728.jpg");
            this.imageList1.Images.SetKeyName(2, "sso.png");
            this.imageList1.Images.SetKeyName(3, "user.ico");
            // 
            // propertyGridSSOProps
            // 
            this.propertyGridSSOProps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridSSOProps.HelpVisible = false;
            this.propertyGridSSOProps.Location = new System.Drawing.Point(0, 0);
            this.propertyGridSSOProps.Name = "propertyGridSSOProps";
            this.propertyGridSSOProps.Size = new System.Drawing.Size(636, 761);
            this.propertyGridSSOProps.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.getCredentialsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(166, 48);
            // 
            // getCredentialsToolStripMenuItem
            // 
            this.getCredentialsToolStripMenuItem.Image = global::BizTalkDeploymentTool.Properties.Resources.ShowCreden;
            this.getCredentialsToolStripMenuItem.Name = "getCredentialsToolStripMenuItem";
            this.getCredentialsToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.getCredentialsToolStripMenuItem.Text = "Show Credentials";
            this.getCredentialsToolStripMenuItem.Click += new System.EventHandler(this.getCredentialsToolStripMenuItem_Click);
            // 
            // SSOAdminInspector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 761);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SSOAdminInspector";
            this.Text = "SSO Affiliate Inspector";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SSOAdminInspector_FormClosing);
            this.Load += new System.EventHandler(this.SSOAdminInspector_Load);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeViewSSOApps;
        private System.Windows.Forms.PropertyGrid propertyGridSSOProps;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem getCredentialsToolStripMenuItem;
    }
}
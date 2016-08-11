namespace BizTalkDeploymentTool
{
    partial class IIS
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("IIS");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IIS));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.contextMenuStripWebSite = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripServer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addApplicationPoolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripDeletApp = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkStausToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStripWebSite.SuspendLayout();
            this.contextMenuStripServer.SuspendLayout();
            this.contextMenuStripDeletApp.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 16);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.propertyGrid1);
            this.splitContainer1.Size = new System.Drawing.Size(1032, 720);
            this.splitContainer1.SplitterDistance = 352;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "IIS";
            treeNode1.SelectedImageIndex = 0;
            treeNode1.Text = "IIS";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(352, 720);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "IISserver_earth.png");
            this.imageList1.Images.SetKeyName(1, "swimming_pool.bmp");
            this.imageList1.Images.SetKeyName(2, "staticwebsite-icon.jpg");
            this.imageList1.Images.SetKeyName(3, "WebFormTemplate_11274_16x_color.png");
            this.imageList1.Images.SetKeyName(4, "Network_Internet.ico");
            this.imageList1.Images.SetKeyName(5, "sitesuntitled.png");
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.HelpVisible = false;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(676, 720);
            this.propertyGrid1.TabIndex = 0;
            // 
            // contextMenuStripWebSite
            // 
            this.contextMenuStripWebSite.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addApplicationToolStripMenuItem});
            this.contextMenuStripWebSite.Name = "contextMenuStripWebSite";
            this.contextMenuStripWebSite.Size = new System.Drawing.Size(161, 26);
            // 
            // addApplicationToolStripMenuItem
            // 
            this.addApplicationToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addApplicationToolStripMenuItem.Image")));
            this.addApplicationToolStripMenuItem.Name = "addApplicationToolStripMenuItem";
            this.addApplicationToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.addApplicationToolStripMenuItem.Text = "Add Application";
            this.addApplicationToolStripMenuItem.Click += new System.EventHandler(this.addApplicationToolStripMenuItem_Click);
            // 
            // contextMenuStripServer
            // 
            this.contextMenuStripServer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addApplicationPoolToolStripMenuItem});
            this.contextMenuStripServer.Name = "contextMenuStripServer";
            this.contextMenuStripServer.Size = new System.Drawing.Size(188, 26);
            // 
            // addApplicationPoolToolStripMenuItem
            // 
            this.addApplicationPoolToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addApplicationPoolToolStripMenuItem.Image")));
            this.addApplicationPoolToolStripMenuItem.Name = "addApplicationPoolToolStripMenuItem";
            this.addApplicationPoolToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.addApplicationPoolToolStripMenuItem.Text = "Add Application Pool";
            this.addApplicationPoolToolStripMenuItem.Click += new System.EventHandler(this.addApplicationPoolToolStripMenuItem_Click);
            // 
            // contextMenuStripDeletApp
            // 
            this.contextMenuStripDeletApp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteApplicationToolStripMenuItem,
            this.checkStausToolStripMenuItem});
            this.contextMenuStripDeletApp.Name = "contextMenuStripDeletApp";
            this.contextMenuStripDeletApp.Size = new System.Drawing.Size(172, 48);
            // 
            // deleteApplicationToolStripMenuItem
            // 
            this.deleteApplicationToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteApplicationToolStripMenuItem.Image")));
            this.deleteApplicationToolStripMenuItem.Name = "deleteApplicationToolStripMenuItem";
            this.deleteApplicationToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.deleteApplicationToolStripMenuItem.Text = "Delete Application";
            this.deleteApplicationToolStripMenuItem.Click += new System.EventHandler(this.deleteApplicationToolStripMenuItem_Click);
            // 
            // checkStausToolStripMenuItem
            // 
            this.checkStausToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("checkStausToolStripMenuItem.Image")));
            this.checkStausToolStripMenuItem.Name = "checkStausToolStripMenuItem";
            this.checkStausToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.checkStausToolStripMenuItem.Text = "Check Staus";
            this.checkStausToolStripMenuItem.ToolTipText = "List the web service address for quick check if its a biztalk location";
            this.checkStausToolStripMenuItem.Click += new System.EventHandler(this.checkStausToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.splitContainer1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1038, 739);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStripServer";
            this.contextMenuStrip1.Size = new System.Drawing.Size(206, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(205, 22);
            this.toolStripMenuItem1.Text = "Recycle Application Pool";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // IIS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 739);
            this.Controls.Add(this.groupBox1);
            this.Name = "IIS";
            this.Text = "IIS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.IIS_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStripWebSite.ResumeLayout(false);
            this.contextMenuStripServer.ResumeLayout(false);
            this.contextMenuStripDeletApp.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripWebSite;
        private System.Windows.Forms.ToolStripMenuItem addApplicationToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripServer;
        private System.Windows.Forms.ToolStripMenuItem addApplicationPoolToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDeletApp;
        private System.Windows.Forms.ToolStripMenuItem deleteApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkStausToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}
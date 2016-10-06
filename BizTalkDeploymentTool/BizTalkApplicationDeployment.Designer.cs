namespace BizTalkDeploymentTool
{
    partial class BizTalkApplicationDeployment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BizTalkApplicationDeployment));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeViewBizTalkApplications = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStripApplication = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.healthCheckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.locatePackageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importBindingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem14 = new System.Windows.Forms.ToolStripMenuItem();
            this.setHandlersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripWebSite = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripServer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addApplicationPoolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripDeletApp = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.checkStausToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeApplicationPoolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteApplicationPoolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem15 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStripApplication.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.contextMenuStripWebSite.SuspendLayout();
            this.contextMenuStripServer.SuspendLayout();
            this.contextMenuStripDeletApp.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.contextMenuStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeViewBizTalkApplications);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainer1.Size = new System.Drawing.Size(1154, 715);
            this.splitContainer1.SplitterDistance = 383;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeViewBizTalkApplications
            // 
            this.treeViewBizTalkApplications.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewBizTalkApplications.ImageIndex = 0;
            this.treeViewBizTalkApplications.ImageList = this.imageList1;
            this.treeViewBizTalkApplications.Location = new System.Drawing.Point(0, 0);
            this.treeViewBizTalkApplications.Name = "treeViewBizTalkApplications";
            this.treeViewBizTalkApplications.SelectedImageIndex = 0;
            this.treeViewBizTalkApplications.Size = new System.Drawing.Size(383, 715);
            this.treeViewBizTalkApplications.TabIndex = 0;
            this.treeViewBizTalkApplications.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeViewBizTalkApplications_BeforeExpand);
            this.treeViewBizTalkApplications.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeViewBizTalkApplications_AfterExpand);
            this.treeViewBizTalkApplications.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.treeViewBizTalkApplications_DrawNode);
            this.treeViewBizTalkApplications.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewBizTalkApplications_AfterSelect);
            this.treeViewBizTalkApplications.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewBizTalkApplications_NodeMouseClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Artifact.png");
            this.imageList1.Images.SetKeyName(1, "Process_Wheels.png");
            this.imageList1.Images.SetKeyName(2, "Orchestration.png");
            this.imageList1.Images.SetKeyName(3, "Map.png");
            this.imageList1.Images.SetKeyName(4, "BRE.png");
            this.imageList1.Images.SetKeyName(5, "Pipeline.png");
            this.imageList1.Images.SetKeyName(6, "Schema.png");
            this.imageList1.Images.SetKeyName(7, "Host.png");
            this.imageList1.Images.SetKeyName(8, "group.ico");
            this.imageList1.Images.SetKeyName(9, "Network_Map.ico");
            this.imageList1.Images.SetKeyName(10, "swimming_pool.bmp");
            this.imageList1.Images.SetKeyName(11, "staticwebsite-icon.jpg");
            this.imageList1.Images.SetKeyName(12, "WebFormTemplate_11274_16x_color.png");
            this.imageList1.Images.SetKeyName(13, "Network_Internet.ico");
            this.imageList1.Images.SetKeyName(14, "112_Plus_Green.ico");
            this.imageList1.Images.SetKeyName(15, "startedapp.jpg");
            this.imageList1.Images.SetKeyName(16, "partialstartimages.jpg");
            this.imageList1.Images.SetKeyName(17, "StoppedApp.png");
            this.imageList1.Images.SetKeyName(18, "sitesuntitled.png");
            this.imageList1.Images.SetKeyName(19, "deploy.png");
            this.imageList1.Images.SetKeyName(20, "busy_icon.jpg");
            this.imageList1.Images.SetKeyName(21, "BTDB.png");
            this.imageList1.Images.SetKeyName(22, "IISserver_earth.png");
            this.imageList1.Images.SetKeyName(23, "Folder_Open.png");
            this.imageList1.Images.SetKeyName(24, "Folder_Closed.png");
            this.imageList1.Images.SetKeyName(25, "dll.png");
            // 
            // contextMenuStripApplication
            // 
            this.contextMenuStripApplication.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.healthCheckToolStripMenuItem,
            this.locatePackageToolStripMenuItem,
            this.refreshToolStripMenuItem,
            this.importBindingToolStripMenuItem});
            this.contextMenuStripApplication.Name = "contextMenuStripApplication";
            this.contextMenuStripApplication.Size = new System.Drawing.Size(157, 92);
            // 
            // healthCheckToolStripMenuItem
            // 
            this.healthCheckToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("healthCheckToolStripMenuItem.Image")));
            this.healthCheckToolStripMenuItem.Name = "healthCheckToolStripMenuItem";
            this.healthCheckToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.healthCheckToolStripMenuItem.Text = "Health Check";
            this.healthCheckToolStripMenuItem.Click += new System.EventHandler(this.healthCheckToolStripMenuItem_Click);
            // 
            // locatePackageToolStripMenuItem
            // 
            this.locatePackageToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("locatePackageToolStripMenuItem.Image")));
            this.locatePackageToolStripMenuItem.Name = "locatePackageToolStripMenuItem";
            this.locatePackageToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.locatePackageToolStripMenuItem.Text = "Locate Package";
            this.locatePackageToolStripMenuItem.Click += new System.EventHandler(this.locatePackageToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Image = global::BizTalkDeploymentTool.Properties.Resources._112_RefreshArrow_Green_16x16_72;
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // importBindingToolStripMenuItem
            // 
            this.importBindingToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("importBindingToolStripMenuItem.Image")));
            this.importBindingToolStripMenuItem.Name = "importBindingToolStripMenuItem";
            this.importBindingToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.importBindingToolStripMenuItem.Text = "Import Binding";
            this.importBindingToolStripMenuItem.Click += new System.EventHandler(this.importBindingToolStripMenuItem_Click);
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem5,
            this.helpToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1154, 24);
            this.menuStrip2.TabIndex = 2;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.toolStripMenuItem6,
            this.toolStripMenuItem7,
            this.toolStripSeparator2,
            this.toolStripMenuItem8,
            this.toolStripMenuItem9,
            this.toolStripMenuItem10,
            this.toolStripMenuItem11,
            this.toolStripSeparator3,
            this.toolStripMenuItem12,
            this.toolStripMenuItem13,
            this.toolStripMenuItem14,
            this.setHandlersToolStripMenuItem});
            this.toolStripMenuItem5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem5.Image")));
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(64, 20);
            this.toolStripMenuItem5.Text = "&Tools";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(210, 6);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem6.Image")));
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(213, 22);
            this.toolStripMenuItem6.Text = "&Host Instances";
            this.toolStripMenuItem6.Visible = false;
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Image = global::BizTalkDeploymentTool.Properties.Resources._1382_cogs1;
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(213, 22);
            this.toolStripMenuItem7.Text = "&Services";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.toolStripMenuItem7_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(210, 6);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem8.Image")));
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(213, 22);
            this.toolStripMenuItem8.Text = "&BRE";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.toolStripMenuItem8_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem9.Image")));
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(213, 22);
            this.toolStripMenuItem9.Text = "&IIS";
            this.toolStripMenuItem9.Visible = false;
            this.toolStripMenuItem9.Click += new System.EventHandler(this.toolStripMenuItem9_Click);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Image = global::BizTalkDeploymentTool.Properties.Resources.compareversionsHS;
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(213, 22);
            this.toolStripMenuItem10.Text = "&GAC";
            this.toolStripMenuItem10.Click += new System.EventHandler(this.toolStripMenuItem10_Click);
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem11.Image")));
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(213, 22);
            this.toolStripMenuItem11.Text = "&Deployment Health Check";
            this.toolStripMenuItem11.Click += new System.EventHandler(this.toolStripMenuItem11_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(210, 6);
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem12.Image")));
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(213, 22);
            this.toolStripMenuItem12.Text = "&Application Inspector";
            this.toolStripMenuItem12.Click += new System.EventHandler(this.toolStripMenuItem12_Click);
            // 
            // toolStripMenuItem13
            // 
            this.toolStripMenuItem13.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem13.Image")));
            this.toolStripMenuItem13.Name = "toolStripMenuItem13";
            this.toolStripMenuItem13.Size = new System.Drawing.Size(213, 22);
            this.toolStripMenuItem13.Text = "&Msi Inspector";
            this.toolStripMenuItem13.Click += new System.EventHandler(this.toolStripMenuItem13_Click);
            // 
            // toolStripMenuItem14
            // 
            this.toolStripMenuItem14.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem14.Image")));
            this.toolStripMenuItem14.Name = "toolStripMenuItem14";
            this.toolStripMenuItem14.Size = new System.Drawing.Size(213, 22);
            this.toolStripMenuItem14.Text = "&S&SO Affiliate";
            this.toolStripMenuItem14.Click += new System.EventHandler(this.toolStripMenuItem14_Click);
            // 
            // setHandlersToolStripMenuItem
            // 
            this.setHandlersToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("setHandlersToolStripMenuItem.Image")));
            this.setHandlersToolStripMenuItem.Name = "setHandlersToolStripMenuItem";
            this.setHandlersToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.setHandlersToolStripMenuItem.Text = "&Set Handlers";
            this.setHandlersToolStripMenuItem.Click += new System.EventHandler(this.setHandlersToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.aboutToolStripMenuItem.Text = "&About..";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
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
            this.checkStausToolStripMenuItem,
            this.changeApplicationPoolToolStripMenuItem,
            this.deleteApplicationToolStripMenuItem,
            this.toolStripMenuItem3});
            this.contextMenuStripDeletApp.Name = "contextMenuStripDeletApp";
            this.contextMenuStripDeletApp.Size = new System.Drawing.Size(206, 114);
            // 
            // checkStausToolStripMenuItem
            // 
            this.checkStausToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("checkStausToolStripMenuItem.Image")));
            this.checkStausToolStripMenuItem.Name = "checkStausToolStripMenuItem";
            this.checkStausToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.checkStausToolStripMenuItem.Text = "Check Staus";
            this.checkStausToolStripMenuItem.ToolTipText = "List the web service address for quick check if its a biztalk location";
            this.checkStausToolStripMenuItem.Click += new System.EventHandler(this.checkStausToolStripMenuItem_Click);
            // 
            // changeApplicationPoolToolStripMenuItem
            // 
            this.changeApplicationPoolToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("changeApplicationPoolToolStripMenuItem.Image")));
            this.changeApplicationPoolToolStripMenuItem.Name = "changeApplicationPoolToolStripMenuItem";
            this.changeApplicationPoolToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.changeApplicationPoolToolStripMenuItem.Text = "Change ApplicationPool";
            this.changeApplicationPoolToolStripMenuItem.Click += new System.EventHandler(this.changeApplicationPoolToolStripMenuItem_Click);
            // 
            // deleteApplicationToolStripMenuItem
            // 
            this.deleteApplicationToolStripMenuItem.Image = global::BizTalkDeploymentTool.Properties.Resources.Annotate_Disabled1;
            this.deleteApplicationToolStripMenuItem.Name = "deleteApplicationToolStripMenuItem";
            this.deleteApplicationToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.deleteApplicationToolStripMenuItem.Text = "Delete Application";
            this.deleteApplicationToolStripMenuItem.Click += new System.EventHandler(this.deleteApplicationToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.deleteApplicationPoolToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStripServer";
            this.contextMenuStrip1.Size = new System.Drawing.Size(206, 48);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(205, 22);
            this.toolStripMenuItem1.Text = "Recycle Application Pool";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click_1);
            // 
            // deleteApplicationPoolToolStripMenuItem
            // 
            this.deleteApplicationPoolToolStripMenuItem.Image = global::BizTalkDeploymentTool.Properties.Resources.Annotate_Disabled1;
            this.deleteApplicationPoolToolStripMenuItem.Name = "deleteApplicationPoolToolStripMenuItem";
            this.deleteApplicationPoolToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.deleteApplicationPoolToolStripMenuItem.Text = "Delete Application Pool";
            this.deleteApplicationPoolToolStripMenuItem.Click += new System.EventHandler(this.deleteApplicationPoolToolStripMenuItem_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.contextMenuStrip2.Name = "contextMenuStripServer";
            this.contextMenuStrip2.Size = new System.Drawing.Size(126, 26);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem2.Image")));
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(125, 22);
            this.toolStripMenuItem2.Text = "Restart IIS";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // contextMenuStrip3
            // 
            this.contextMenuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem15});
            this.contextMenuStrip3.Name = "contextMenuStripApplication";
            this.contextMenuStrip3.Size = new System.Drawing.Size(114, 26);
            // 
            // toolStripMenuItem15
            // 
            this.toolStripMenuItem15.Image = global::BizTalkDeploymentTool.Properties.Resources._112_RefreshArrow_Green_16x16_72;
            this.toolStripMenuItem15.Name = "toolStripMenuItem15";
            this.toolStripMenuItem15.Size = new System.Drawing.Size(113, 22);
            this.toolStripMenuItem15.Text = "Refresh";
            this.toolStripMenuItem15.Click += new System.EventHandler(this.toolStripMenuItem15_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem3.Image")));
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(205, 22);
            this.toolStripMenuItem3.Text = "Recycle Application Pool";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // BizTalkApplicationDeployment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 739);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "BizTalkApplicationDeployment";
            this.Text = "BizTalk Application Deployment";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BizTalkApplicationAdministration_FormClosing);
            this.Load += new System.EventHandler(this.BizTalkApplicationAdministration_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStripApplication.ResumeLayout(false);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.contextMenuStripWebSite.ResumeLayout(false);
            this.contextMenuStripServer.ResumeLayout(false);
            this.contextMenuStripDeletApp.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.contextMenuStrip3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeViewBizTalkApplications;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripApplication;
        private System.Windows.Forms.ToolStripMenuItem healthCheckToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem11;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem12;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem13;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem14;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripWebSite;
        private System.Windows.Forms.ToolStripMenuItem addApplicationToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripServer;
        private System.Windows.Forms.ToolStripMenuItem addApplicationPoolToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDeletApp;
        private System.Windows.Forms.ToolStripMenuItem deleteApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkStausToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem locatePackageToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem setHandlersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeApplicationPoolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteApplicationPoolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importBindingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem15;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
    }
}
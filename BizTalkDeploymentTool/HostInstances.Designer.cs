namespace BizTalkDeploymentTool
{
    partial class RetstartHostInstances
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RetstartHostInstances));
            this.listViewControl = new System.Windows.Forms.ListView();
            this.HostInstanceName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.server = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LastRun = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Elapsed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Message = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBxAppList = new System.Windows.Forms.ComboBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.contextMenuStripAction = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.checkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uncheckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.contextMenuStripAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewControl
            // 
            this.listViewControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewControl.CheckBoxes = true;
            this.listViewControl.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.HostInstanceName,
            this.server,
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
            this.listViewControl.Size = new System.Drawing.Size(994, 480);
            this.listViewControl.TabIndex = 14;
            this.listViewControl.UseCompatibleStateImageBehavior = false;
            this.listViewControl.View = System.Windows.Forms.View.Details;
            this.listViewControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewControl_MouseClick);
            // 
            // HostInstanceName
            // 
            this.HostInstanceName.Text = "Host Instance Name";
            this.HostInstanceName.Width = 300;
            // 
            // server
            // 
            this.server.Text = "Running Server";
            this.server.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.server.Width = 150;
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
            // 
            // Message
            // 
            this.Message.Text = "Message";
            this.Message.Width = 1500;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(3, 17);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.richTextBox1);
            this.splitContainer1.Size = new System.Drawing.Size(994, 574);
            this.splitContainer1.SplitterDistance = 517;
            this.splitContainer1.TabIndex = 15;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.IsSplitterFixed = true;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.label1);
            this.splitContainer3.Panel1.Controls.Add(this.comboBxAppList);
            this.splitContainer3.Panel1.Controls.Add(this.splitter1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.listViewControl);
            this.splitContainer3.Size = new System.Drawing.Size(994, 517);
            this.splitContainer3.SplitterDistance = 33;
            this.splitContainer3.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Application Name";
            // 
            // comboBxAppList
            // 
            this.comboBxAppList.BackColor = System.Drawing.SystemColors.Info;
            this.comboBxAppList.DropDownHeight = 350;
            this.comboBxAppList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBxAppList.DropDownWidth = 600;
            this.comboBxAppList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBxAppList.FormattingEnabled = true;
            this.comboBxAppList.IntegralHeight = false;
            this.comboBxAppList.Location = new System.Drawing.Point(237, 6);
            this.comboBxAppList.Margin = new System.Windows.Forms.Padding(4);
            this.comboBxAppList.MaxDropDownItems = 15;
            this.comboBxAppList.Name = "comboBxAppList";
            this.comboBxAppList.Size = new System.Drawing.Size(520, 21);
            this.comboBxAppList.TabIndex = 1;
            this.comboBxAppList.SelectedIndexChanged += new System.EventHandler(this.comboBxAppList_SelectedIndexChanged);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(168, 33);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(994, 53);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.AutoSize = true;
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(6, 612);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "   Restart";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Restart.jpg");
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.splitContainer1);
            this.groupBox1.Location = new System.Drawing.Point(3, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1000, 594);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // contextMenuStripAction
            // 
            this.contextMenuStripAction.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkToolStripMenuItem,
            this.uncheckToolStripMenuItem});
            this.contextMenuStripAction.Name = "contextMenuStripAction";
            this.contextMenuStripAction.Size = new System.Drawing.Size(121, 48);
            // 
            // checkToolStripMenuItem
            // 
            this.checkToolStripMenuItem.Image = global::BizTalkDeploymentTool.Properties.Resources.base_checkboxes;
            this.checkToolStripMenuItem.Name = "checkToolStripMenuItem";
            this.checkToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.checkToolStripMenuItem.Text = "Check";
            this.checkToolStripMenuItem.Click += new System.EventHandler(this.checkToolStripMenuItem_Click);
            // 
            // uncheckToolStripMenuItem
            // 
            this.uncheckToolStripMenuItem.Image = global::BizTalkDeploymentTool.Properties.Resources.error;
            this.uncheckToolStripMenuItem.Name = "uncheckToolStripMenuItem";
            this.uncheckToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.uncheckToolStripMenuItem.Text = "Uncheck";
            this.uncheckToolStripMenuItem.Click += new System.EventHandler(this.uncheckToolStripMenuItem_Click);
            // 
            // RetstartHostInstances
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1005, 649);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Name = "RetstartHostInstances";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Restart Host Instances";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RetstartHostInstances_FormClosing);
            this.Load += new System.EventHandler(this.RetstartHostInstances_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.contextMenuStripAction.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewControl;
        private System.Windows.Forms.ColumnHeader HostInstanceName;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.ColumnHeader LastRun;
        private System.Windows.Forms.ColumnHeader Elapsed;
        private System.Windows.Forms.ColumnHeader Message;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ColumnHeader server;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ComboBox comboBxAppList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripAction;
        private System.Windows.Forms.ToolStripMenuItem checkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uncheckToolStripMenuItem;
    }
}
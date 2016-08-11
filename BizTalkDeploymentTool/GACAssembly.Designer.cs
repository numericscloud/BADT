namespace BizTalkDeploymentTool
{
    partial class GACAssembly
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GACAssembly));
            this.btnImport = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.assembliesDialog = new System.Windows.Forms.OpenFileDialog();
            this.listViewResources = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.richTextBoxMessage = new System.Windows.Forms.RichTextBox();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Image = ((System.Drawing.Image)(resources.GetObject("btnImport.Image")));
            this.btnImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImport.Location = new System.Drawing.Point(12, 620);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(107, 25);
            this.btnImport.TabIndex = 21;
            this.btnImport.Text = "Gac";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(12, 27);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(107, 23);
            this.btnAdd.TabIndex = 18;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // assembliesDialog
            // 
            this.assembliesDialog.FileName = "assemblies";
            this.assembliesDialog.Filter = "DLL file (*.dll)|*.dll|All files (*.*)|*.*";
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
            this.listViewResources.Size = new System.Drawing.Size(867, 481);
            this.listViewResources.TabIndex = 23;
            this.listViewResources.UseCompatibleStateImageBehavior = false;
            this.listViewResources.View = System.Windows.Forms.View.Details;
            this.listViewResources.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewResources_MouseClick);
            this.listViewResources.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listViewResources_MouseDown);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Resource Name";
            this.columnHeader2.Width = 125;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 56);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listViewResources);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.richTextBoxMessage);
            this.splitContainer1.Size = new System.Drawing.Size(867, 548);
            this.splitContainer1.SplitterDistance = 481;
            this.splitContainer1.TabIndex = 24;
            // 
            // richTextBoxMessage
            // 
            this.richTextBoxMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxMessage.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxMessage.Name = "richTextBoxMessage";
            this.richTextBoxMessage.Size = new System.Drawing.Size(867, 63);
            this.richTextBoxMessage.TabIndex = 22;
            this.richTextBoxMessage.Text = "";
            // 
            // buttonRemove
            // 
            this.buttonRemove.Image = ((System.Drawing.Image)(resources.GetObject("buttonRemove.Image")));
            this.buttonRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonRemove.Location = new System.Drawing.Point(134, 27);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(94, 23);
            this.buttonRemove.TabIndex = 25;
            this.buttonRemove.Text = "     Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(13, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(751, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "GacUtil exe needs to be present on all the messaging servers for the tool. The pa" +
    "th of gacutil.exe should be in the config of BTDT.";
            // 
            // GACAssembly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 670);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnAdd);
            this.Name = "GACAssembly";
            this.Text = "GAC Assembly";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GACAssembly_FormClosing);
            this.Load += new System.EventHandler(this.GACAssembly_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.OpenFileDialog assembliesDialog;
        private System.Windows.Forms.ListView listViewResources;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.RichTextBox richTextBoxMessage;
        private System.Windows.Forms.Label label1;
    }
}
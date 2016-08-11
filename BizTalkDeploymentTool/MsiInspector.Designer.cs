namespace BizTalkDeploymentTool
{
    partial class MsiInspector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MsiInspector));
            this.lblMsiLoc = new System.Windows.Forms.Label();
            this.txtMSILocation = new System.Windows.Forms.TextBox();
            this.btnBrowseMSI = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMsiLoc
            // 
            this.lblMsiLoc.AutoSize = true;
            this.lblMsiLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblMsiLoc.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblMsiLoc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblMsiLoc.Location = new System.Drawing.Point(12, 23);
            this.lblMsiLoc.Name = "lblMsiLoc";
            this.lblMsiLoc.Size = new System.Drawing.Size(68, 13);
            this.lblMsiLoc.TabIndex = 14;
            this.lblMsiLoc.Text = "MSI Location";
            // 
            // txtMSILocation
            // 
            this.txtMSILocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMSILocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMSILocation.Location = new System.Drawing.Point(97, 20);
            this.txtMSILocation.Name = "txtMSILocation";
            this.txtMSILocation.ReadOnly = true;
            this.txtMSILocation.Size = new System.Drawing.Size(647, 21);
            this.txtMSILocation.TabIndex = 15;
            // 
            // btnBrowseMSI
            // 
            this.btnBrowseMSI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseMSI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseMSI.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnBrowseMSI.Image = ((System.Drawing.Image)(resources.GetObject("btnBrowseMSI.Image")));
            this.btnBrowseMSI.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBrowseMSI.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBrowseMSI.Location = new System.Drawing.Point(769, 18);
            this.btnBrowseMSI.Name = "btnBrowseMSI";
            this.btnBrowseMSI.Size = new System.Drawing.Size(82, 25);
            this.btnBrowseMSI.TabIndex = 13;
            this.btnBrowseMSI.Text = "         Browse";
            this.btnBrowseMSI.UseVisualStyleBackColor = true;
            this.btnBrowseMSI.Click += new System.EventHandler(this.btnBrowseMSI_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "MSI file (*.msi)|*.msi|All files (*.*)|*.*";
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.FullRowSelect = true;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(311, 640);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Task-Inspector-Suggestion.png");
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 47);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.propertyGrid1);
            this.splitContainer1.Size = new System.Drawing.Size(950, 640);
            this.splitContainer1.SplitterDistance = 311;
            this.splitContainer1.TabIndex = 17;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.HelpVisible = false;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(635, 640);
            this.propertyGrid1.TabIndex = 17;
            // 
            // MsiInspector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 688);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.lblMsiLoc);
            this.Controls.Add(this.txtMSILocation);
            this.Controls.Add(this.btnBrowseMSI);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MsiInspector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Msi Inspector";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MsiInspector_FormClosing);
            this.Load += new System.EventHandler(this.MsiInspector_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMsiLoc;
        private System.Windows.Forms.TextBox txtMSILocation;
        private System.Windows.Forms.Button btnBrowseMSI;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
    }
}
namespace BizTalkDeploymentTool
{
    partial class UserControl1
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.propertyGridArtifacts = new System.Windows.Forms.PropertyGrid();
            this.richTextBoxArtifactProperties = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.propertyGridArtifacts);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.richTextBoxArtifactProperties);
            this.splitContainer1.Size = new System.Drawing.Size(1600, 1200);
            this.splitContainer1.SplitterDistance = 602;
            this.splitContainer1.TabIndex = 0;
            // 
            // propertyGridArtifacts
            // 
            this.propertyGridArtifacts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridArtifacts.HelpVisible = false;
            this.propertyGridArtifacts.Location = new System.Drawing.Point(0, 0);
            this.propertyGridArtifacts.Name = "propertyGridArtifacts";
            this.propertyGridArtifacts.Size = new System.Drawing.Size(1600, 602);
            this.propertyGridArtifacts.TabIndex = 4;
            this.propertyGridArtifacts.SelectedGridItemChanged += new System.Windows.Forms.SelectedGridItemChangedEventHandler(this.propertyGridArtifacts_SelectedGridItemChanged);
            // 
            // richTextBoxArtifactProperties
            // 
            this.richTextBoxArtifactProperties.BackColor = System.Drawing.Color.White;
            this.richTextBoxArtifactProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxArtifactProperties.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxArtifactProperties.Name = "richTextBoxArtifactProperties";
            this.richTextBoxArtifactProperties.ReadOnly = true;
            this.richTextBoxArtifactProperties.Size = new System.Drawing.Size(1600, 594);
            this.richTextBoxArtifactProperties.TabIndex = 2;
            this.richTextBoxArtifactProperties.Text = "";
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.splitContainer1);
            this.DoubleBuffered = true;
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(1600, 1200);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PropertyGrid propertyGridArtifacts;
        private System.Windows.Forms.RichTextBox richTextBoxArtifactProperties;
    }
}

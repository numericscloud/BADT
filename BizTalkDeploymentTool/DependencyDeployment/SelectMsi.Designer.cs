namespace BizTalkDeploymentTool.DependencyDeployment
{
    partial class SelectMsi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectMsi));
            this.grpBxMSI = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cbTargetEnvironment = new System.Windows.Forms.ComboBox();
            this.lblEnvName = new System.Windows.Forms.Label();
            this.lblMsiLoc = new System.Windows.Forms.Label();
            this.txtMSILocation = new System.Windows.Forms.TextBox();
            this.btnBrowseMSI = new System.Windows.Forms.Button();
            this.txtAppName = new System.Windows.Forms.TextBox();
            this.lblAppName = new System.Windows.Forms.Label();
            this.openMsiFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.grpBxMSI.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBxMSI
            // 
            this.grpBxMSI.BackColor = System.Drawing.SystemColors.Window;
            this.grpBxMSI.Controls.Add(this.button1);
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
            this.grpBxMSI.Size = new System.Drawing.Size(728, 115);
            this.grpBxMSI.TabIndex = 9;
            this.grpBxMSI.TabStop = false;
            this.grpBxMSI.Text = "Deployment Configurations";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(634, 68);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbTargetEnvironment
            // 
            this.cbTargetEnvironment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTargetEnvironment.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbTargetEnvironment.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.cbTargetEnvironment.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cbTargetEnvironment.FormattingEnabled = true;
            this.cbTargetEnvironment.Location = new System.Drawing.Point(118, 75);
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
            this.lblEnvName.Location = new System.Drawing.Point(33, 78);
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
            this.txtMSILocation.Size = new System.Drawing.Size(499, 20);
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
            this.btnBrowseMSI.Location = new System.Drawing.Point(634, 20);
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
            // openMsiFileDialog
            // 
            this.openMsiFileDialog.FileName = "openFileDialog1";
            this.openMsiFileDialog.Filter = "MSI file (*.msi)|*.msi|All files (*.*)|*.*";
            // 
            // SelectMsi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 115);
            this.Controls.Add(this.grpBxMSI);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(744, 154);
            this.MinimumSize = new System.Drawing.Size(744, 154);
            this.Name = "SelectMsi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SelectMsi";
            this.grpBxMSI.ResumeLayout(false);
            this.grpBxMSI.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBxMSI;
        private System.Windows.Forms.ComboBox cbTargetEnvironment;
        private System.Windows.Forms.Label lblEnvName;
        private System.Windows.Forms.Label lblMsiLoc;
        private System.Windows.Forms.TextBox txtMSILocation;
        private System.Windows.Forms.Button btnBrowseMSI;
        private System.Windows.Forms.TextBox txtAppName;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.OpenFileDialog openMsiFileDialog;
        private System.Windows.Forms.Button button1;
    }
}
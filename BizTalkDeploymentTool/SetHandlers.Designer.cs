namespace BizTalkDeploymentTool
{
    partial class SetHandlers
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxAdapters = new System.Windows.Forms.ComboBox();
            this.checkBoxRcvPort = new System.Windows.Forms.CheckBox();
            this.checkBoxSendPort = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBoxReceiveHandlers = new System.Windows.Forms.ComboBox();
            this.comboBoxSendHandlers = new System.Windows.Forms.ComboBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "For Adapter";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // comboBoxAdapters
            // 
            this.comboBoxAdapters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAdapters.FormattingEnabled = true;
            this.comboBoxAdapters.Location = new System.Drawing.Point(138, 13);
            this.comboBoxAdapters.Name = "comboBoxAdapters";
            this.comboBoxAdapters.Size = new System.Drawing.Size(213, 21);
            this.comboBoxAdapters.TabIndex = 1;
            this.comboBoxAdapters.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // checkBoxRcvPort
            // 
            this.checkBoxRcvPort.AutoSize = true;
            this.checkBoxRcvPort.Location = new System.Drawing.Point(17, 26);
            this.checkBoxRcvPort.Name = "checkBoxRcvPort";
            this.checkBoxRcvPort.Size = new System.Drawing.Size(115, 17);
            this.checkBoxRcvPort.TabIndex = 2;
            this.checkBoxRcvPort.Text = "Receive Locations";
            this.checkBoxRcvPort.UseVisualStyleBackColor = true;
            // 
            // checkBoxSendPort
            // 
            this.checkBoxSendPort.AutoSize = true;
            this.checkBoxSendPort.Location = new System.Drawing.Point(17, 26);
            this.checkBoxSendPort.Name = "checkBoxSendPort";
            this.checkBoxSendPort.Size = new System.Drawing.Size(78, 17);
            this.checkBoxSendPort.TabIndex = 3;
            this.checkBoxSendPort.Text = "Send Ports";
            this.checkBoxSendPort.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(26, 256);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Change Handler";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBoxReceiveHandlers
            // 
            this.comboBoxReceiveHandlers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxReceiveHandlers.FormattingEnabled = true;
            this.comboBoxReceiveHandlers.Location = new System.Drawing.Point(63, 49);
            this.comboBoxReceiveHandlers.Name = "comboBoxReceiveHandlers";
            this.comboBoxReceiveHandlers.Size = new System.Drawing.Size(262, 21);
            this.comboBoxReceiveHandlers.TabIndex = 5;
            // 
            // comboBoxSendHandlers
            // 
            this.comboBoxSendHandlers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSendHandlers.FormattingEnabled = true;
            this.comboBoxSendHandlers.Location = new System.Drawing.Point(63, 49);
            this.comboBoxSendHandlers.Name = "comboBoxSendHandlers";
            this.comboBoxSendHandlers.Size = new System.Drawing.Size(262, 21);
            this.comboBoxSendHandlers.TabIndex = 6;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(1, 286);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(408, 34);
            this.progressBar1.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxRcvPort);
            this.groupBox1.Controls.Add(this.comboBoxReceiveHandlers);
            this.groupBox1.Location = new System.Drawing.Point(26, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 88);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Change Receive handlers for all receive locations";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxSendPort);
            this.groupBox2.Controls.Add(this.comboBoxSendHandlers);
            this.groupBox2.Location = new System.Drawing.Point(26, 151);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(334, 88);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Change Send handlers for all  send ports";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(5, 323);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(0, 13);
            this.linkLabel1.TabIndex = 10;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // SetHandlers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 339);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxAdapters);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "SetHandlers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change Handlers for Receive and Send Ports";
            this.Load += new System.EventHandler(this.SetHandlers_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxAdapters;
        private System.Windows.Forms.CheckBox checkBoxRcvPort;
        private System.Windows.Forms.CheckBox checkBoxSendPort;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBoxReceiveHandlers;
        private System.Windows.Forms.ComboBox comboBoxSendHandlers;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}
namespace BizTalkDeploymentTool.Report
{
    partial class BTDTReportOptions
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
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem("Ignore Child Order");
            System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem("Ignore Processing Instructions");
            System.Windows.Forms.ListViewItem listViewItem11 = new System.Windows.Forms.ListViewItem("Ignore Comments");
            System.Windows.Forms.ListViewItem listViewItem12 = new System.Windows.Forms.ListViewItem("Ignore Xml Declaration");
            System.Windows.Forms.ListViewItem listViewItem13 = new System.Windows.Forms.ListViewItem("Ignore Whitespaces");
            System.Windows.Forms.ListViewItem listViewItem14 = new System.Windows.Forms.ListViewItem("Ignore Document Type Declaration (DTD)");
            System.Windows.Forms.ListViewItem listViewItem15 = new System.Windows.Forms.ListViewItem("Ignore Namespaces");
            System.Windows.Forms.ListViewItem listViewItem16 = new System.Windows.Forms.ListViewItem("Ignore Prefixes");
            this.lblAlgorithm = new System.Windows.Forms.Label();
            this.rBtnAuto = new System.Windows.Forms.RadioButton();
            this.rBtnFast = new System.Windows.Forms.RadioButton();
            this.rBtnPrecise = new System.Windows.Forms.RadioButton();
            this.listViewOptions = new System.Windows.Forms.ListView();
            this.Options = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAlgorithm
            // 
            this.lblAlgorithm.AutoSize = true;
            this.lblAlgorithm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblAlgorithm.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlgorithm.Location = new System.Drawing.Point(13, 22);
            this.lblAlgorithm.Name = "lblAlgorithm";
            this.lblAlgorithm.Size = new System.Drawing.Size(52, 13);
            this.lblAlgorithm.TabIndex = 0;
            this.lblAlgorithm.Text = "Algorithm";
            // 
            // rBtnAuto
            // 
            this.rBtnAuto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rBtnAuto.AutoSize = true;
            this.rBtnAuto.Checked = true;
            this.rBtnAuto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rBtnAuto.Location = new System.Drawing.Point(84, 22);
            this.rBtnAuto.Name = "rBtnAuto";
            this.rBtnAuto.Size = new System.Drawing.Size(47, 17);
            this.rBtnAuto.TabIndex = 1;
            this.rBtnAuto.TabStop = true;
            this.rBtnAuto.Text = "Auto";
            this.rBtnAuto.UseVisualStyleBackColor = true;
            // 
            // rBtnFast
            // 
            this.rBtnFast.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rBtnFast.AutoSize = true;
            this.rBtnFast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rBtnFast.Location = new System.Drawing.Point(203, 22);
            this.rBtnFast.Name = "rBtnFast";
            this.rBtnFast.Size = new System.Drawing.Size(45, 17);
            this.rBtnFast.TabIndex = 2;
            this.rBtnFast.Text = "Fast";
            this.rBtnFast.UseVisualStyleBackColor = true;
            // 
            // rBtnPrecise
            // 
            this.rBtnPrecise.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rBtnPrecise.AutoSize = true;
            this.rBtnPrecise.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rBtnPrecise.Location = new System.Drawing.Point(137, 22);
            this.rBtnPrecise.Name = "rBtnPrecise";
            this.rBtnPrecise.Size = new System.Drawing.Size(58, 17);
            this.rBtnPrecise.TabIndex = 3;
            this.rBtnPrecise.Text = "Precise";
            this.rBtnPrecise.UseVisualStyleBackColor = true;
            // 
            // listViewOptions
            // 
            this.listViewOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewOptions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewOptions.CheckBoxes = true;
            this.listViewOptions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Options});
            this.listViewOptions.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewOptions.FullRowSelect = true;
            this.listViewOptions.GridLines = true;
            listViewItem9.Checked = true;
            listViewItem9.StateImageIndex = 1;
            listViewItem10.Checked = true;
            listViewItem10.StateImageIndex = 1;
            listViewItem11.Checked = true;
            listViewItem11.StateImageIndex = 1;
            listViewItem12.Checked = true;
            listViewItem12.StateImageIndex = 1;
            listViewItem13.Checked = true;
            listViewItem13.StateImageIndex = 1;
            listViewItem14.Checked = true;
            listViewItem14.StateImageIndex = 1;
            listViewItem15.Checked = true;
            listViewItem15.StateImageIndex = 1;
            listViewItem16.Checked = true;
            listViewItem16.StateImageIndex = 1;
            this.listViewOptions.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem9,
            listViewItem10,
            listViewItem11,
            listViewItem12,
            listViewItem13,
            listViewItem14,
            listViewItem15,
            listViewItem16});
            this.listViewOptions.Location = new System.Drawing.Point(16, 69);
            this.listViewOptions.Name = "listViewOptions";
            this.listViewOptions.Size = new System.Drawing.Size(250, 155);
            this.listViewOptions.TabIndex = 4;
            this.listViewOptions.UseCompatibleStateImageBehavior = false;
            this.listViewOptions.View = System.Windows.Forms.View.Details;
            // 
            // Options
            // 
            this.Options.Text = "Options";
            this.Options.Width = 248;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(227, 242);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(39, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // BTDTReportOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 282);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.listViewOptions);
            this.Controls.Add(this.rBtnPrecise);
            this.Controls.Add(this.rBtnFast);
            this.Controls.Add(this.rBtnAuto);
            this.Controls.Add(this.lblAlgorithm);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "BTDTReportOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BTDTReportOptions";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAlgorithm;
        private System.Windows.Forms.RadioButton rBtnAuto;
        private System.Windows.Forms.RadioButton rBtnFast;
        private System.Windows.Forms.RadioButton rBtnPrecise;
        private System.Windows.Forms.ListView listViewOptions;
        private System.Windows.Forms.ColumnHeader Options;
        private System.Windows.Forms.Button btnOK;

    }
}
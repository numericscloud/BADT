namespace BizTalkDeploymentTool
{
    partial class UserControlListView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlListView));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.sortableListView1 = new BizTalkDeploymentTool.UIComponent.SortableListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Annotate_QuestionBlue.ico");
            this.imageList1.Images.SetKeyName(1, "Start.png");
            this.imageList1.Images.SetKeyName(2, "partialstartimages.jpg");
            this.imageList1.Images.SetKeyName(3, "StoppedApp.png");
            // 
            // sortableListView1
            // 
            this.sortableListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.sortableListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sortableListView1.FullRowSelect = true;
            this.sortableListView1.LargeImageList = this.imageList1;
            this.sortableListView1.Location = new System.Drawing.Point(0, 0);
            this.sortableListView1.Name = "sortableListView1";
            this.sortableListView1.Size = new System.Drawing.Size(1600, 1230);
            this.sortableListView1.SmallImageList = this.imageList1;
            this.sortableListView1.TabIndex = 1;
            this.sortableListView1.UseCompatibleStateImageBehavior = false;
            this.sortableListView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 500;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Installation Date on Current Machine";
            this.columnHeader2.Width = 500;
            // 
            // UserControlListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sortableListView1);
            this.Name = "UserControlListView";
            this.Size = new System.Drawing.Size(1600, 1230);
            this.Load += new System.EventHandler(this.UserControlListView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private UIComponent.SortableListView sortableListView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}

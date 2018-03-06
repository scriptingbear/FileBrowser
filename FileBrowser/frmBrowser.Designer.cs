namespace FileBrowser
{
    partial class frmBrowser
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
            this.FolderList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.FileList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.DriveList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // FolderList
            // 
            this.FolderList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FolderList.FormattingEnabled = true;
            this.FolderList.ItemHeight = 16;
            this.FolderList.Location = new System.Drawing.Point(129, 25);
            this.FolderList.Name = "FolderList";
            this.FolderList.Size = new System.Drawing.Size(388, 100);
            this.FolderList.Sorted = true;
            this.FolderList.TabIndex = 0;
            this.FolderList.SelectedIndexChanged += new System.EventHandler(this.FolderList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(130, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Folders";
            // 
            // FileList
            // 
            this.FileList.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.FileList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.FileList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileList.HideSelection = false;
            this.FileList.HoverSelection = true;
            this.FileList.Location = new System.Drawing.Point(16, 206);
            this.FileList.MultiSelect = false;
            this.FileList.Name = "FileList";
            this.FileList.Size = new System.Drawing.Size(779, 277);
            this.FileList.TabIndex = 2;
            this.FileList.UseCompatibleStateImageBehavior = false;
            this.FileList.View = System.Windows.Forms.View.Details;
            this.FileList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.FileList_ColumnClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Tag = "ASC";
            this.columnHeader1.Text = "Filename";
            this.columnHeader1.Width = 300;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Tag = "ASC";
            this.columnHeader2.Text = "Created";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Tag = "ASC";
            this.columnHeader3.Text = "Modified";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Tag = "ASC";
            this.columnHeader4.Text = "Size";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Tag = "ASC";
            this.columnHeader5.Text = "Type";
            this.columnHeader5.Width = 178;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Drives";
            // 
            // DriveList
            // 
            this.DriveList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DriveList.FormattingEnabled = true;
            this.DriveList.ItemHeight = 16;
            this.DriveList.Location = new System.Drawing.Point(16, 25);
            this.DriveList.Name = "DriveList";
            this.DriveList.Size = new System.Drawing.Size(88, 100);
            this.DriveList.Sorted = true;
            this.DriveList.TabIndex = 3;
            this.DriveList.SelectedIndexChanged += new System.EventHandler(this.DriveList_SelectedIndexChanged);
            // 
            // frmBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 513);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DriveList);
            this.Controls.Add(this.FileList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FolderList);
            this.Name = "frmBrowser";
            this.Text = "File Browser";
            this.Load += new System.EventHandler(this.frmBrowser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox FolderList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView FileList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox DriveList;
        public System.Windows.Forms.ColumnHeader columnHeader1;
        public System.Windows.Forms.ColumnHeader columnHeader2;
        public System.Windows.Forms.ColumnHeader columnHeader3;
        public System.Windows.Forms.ColumnHeader columnHeader4;
        public System.Windows.Forms.ColumnHeader columnHeader5;
    }
}


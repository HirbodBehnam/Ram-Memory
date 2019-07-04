namespace Ram_Memory
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.listViewMainFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewMainFileSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewMain = new System.Windows.Forms.ListView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripOpenFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripDownloadFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripSettings = new System.Windows.Forms.ToolStripButton();
            this.toolStripAbout = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStripFiles = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asPhotoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStripFiles.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewMainFileName
            // 
            this.listViewMainFileName.Text = "Name";
            this.listViewMainFileName.Width = 300;
            // 
            // listViewMainFileSize
            // 
            this.listViewMainFileSize.Text = "Size (bytes)";
            this.listViewMainFileSize.Width = 120;
            // 
            // listViewMain
            // 
            this.listViewMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewMain.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewMainFileName,
            this.listViewMainFileSize});
            this.listViewMain.Location = new System.Drawing.Point(12, 28);
            this.listViewMain.MultiSelect = false;
            this.listViewMain.Name = "listViewMain";
            this.listViewMain.Size = new System.Drawing.Size(776, 423);
            this.listViewMain.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewMain.TabIndex = 0;
            this.listViewMain.UseCompatibleStateImageBehavior = false;
            this.listViewMain.View = System.Windows.Forms.View.Details;
            this.listViewMain.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ListViewMain_KeyUp);
            this.listViewMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListViewMain_MouseClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripOpenFile,
            this.toolStripDownloadFile,
            this.toolStripSettings,
            this.toolStripAbout});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripOpenFile
            // 
            this.toolStripOpenFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripOpenFile.Image = ((System.Drawing.Image)(resources.GetObject("toolStripOpenFile.Image")));
            this.toolStripOpenFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripOpenFile.Name = "toolStripOpenFile";
            this.toolStripOpenFile.Size = new System.Drawing.Size(23, 22);
            this.toolStripOpenFile.Text = "Load File";
            this.toolStripOpenFile.Click += new System.EventHandler(this.ToolStripOpenFile_Click);
            // 
            // toolStripDownloadFile
            // 
            this.toolStripDownloadFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDownloadFile.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDownloadFile.Image")));
            this.toolStripDownloadFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDownloadFile.Name = "toolStripDownloadFile";
            this.toolStripDownloadFile.Size = new System.Drawing.Size(23, 22);
            this.toolStripDownloadFile.Text = "Download From Net";
            this.toolStripDownloadFile.Click += new System.EventHandler(this.ToolStripDownloadFile_Click);
            // 
            // toolStripSettings
            // 
            this.toolStripSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSettings.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSettings.Image")));
            this.toolStripSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSettings.Name = "toolStripSettings";
            this.toolStripSettings.Size = new System.Drawing.Size(23, 22);
            this.toolStripSettings.Text = "Settings";
            this.toolStripSettings.Click += new System.EventHandler(this.ToolStripSettings_Click);
            // 
            // toolStripAbout
            // 
            this.toolStripAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripAbout.Image = ((System.Drawing.Image)(resources.GetObject("toolStripAbout.Image")));
            this.toolStripAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripAbout.Name = "toolStripAbout";
            this.toolStripAbout.Size = new System.Drawing.Size(23, 22);
            this.toolStripAbout.Text = "About";
            this.toolStripAbout.Click += new System.EventHandler(this.ToolStripAbout_Click);
            // 
            // contextMenuStripFiles
            // 
            this.contextMenuStripFiles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStripFiles.Name = "contextMenuStripFiles";
            this.contextMenuStripFiles.Size = new System.Drawing.Size(181, 92);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.asTextToolStripMenuItem,
            this.asPhotoToolStripMenuItem});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // asTextToolStripMenuItem
            // 
            this.asTextToolStripMenuItem.Name = "asTextToolStripMenuItem";
            this.asTextToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.asTextToolStripMenuItem.Text = "As Text";
            this.asTextToolStripMenuItem.Click += new System.EventHandler(this.AsTextToolStripMenuItem_Click);
            // 
            // asPhotoToolStripMenuItem
            // 
            this.asPhotoToolStripMenuItem.Name = "asPhotoToolStripMenuItem";
            this.asPhotoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.asPhotoToolStripMenuItem.Text = "As Photo";
            this.asPhotoToolStripMenuItem.Click += new System.EventHandler(this.AsPhotoToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripMenuItem.Image")));
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 463);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.listViewMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(200, 200);
            this.Name = "Main";
            this.Text = "Ram Memory";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStripFiles.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader listViewMainFileName;
        private System.Windows.Forms.ColumnHeader listViewMainFileSize;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripOpenFile;
        private System.Windows.Forms.ToolStripButton toolStripDownloadFile;
        private System.Windows.Forms.ToolStripButton toolStripSettings;
        private System.Windows.Forms.ToolStripButton toolStripAbout;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripFiles;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asPhotoToolStripMenuItem;
        public System.Windows.Forms.ListView listViewMain;
    }
}


namespace FacebookPicture {
	partial class PictureViewerForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PictureViewerForm));
            this.PictureBoxMain = new System.Windows.Forms.PictureBox();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.StripMenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMenuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMenuClose = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxMain)).BeginInit();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // PictureBoxMain
            // 
            this.PictureBoxMain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureBoxMain.Location = new System.Drawing.Point(0, 0);
            this.PictureBoxMain.Name = "PictureBoxMain";
            this.PictureBoxMain.Size = new System.Drawing.Size(445, 377);
            this.PictureBoxMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBoxMain.TabIndex = 0;
            this.PictureBoxMain.TabStop = false;
            this.PictureBoxMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBoxMain_MouseDown);
            this.PictureBoxMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBoxMain_MouseMove);
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StripMenuFile});
            this.MainMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(443, 24);
            this.MainMenu.TabIndex = 1;
            this.MainMenu.Text = "Menu";
            // 
            // StripMenuFile
            // 
            this.StripMenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StripMenuSave,
            this.StripMenuClose});
            this.StripMenuFile.Name = "StripMenuFile";
            this.StripMenuFile.Size = new System.Drawing.Size(37, 20);
            this.StripMenuFile.Text = "File";
            // 
            // StripMenuSave
            // 
            this.StripMenuSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.StripMenuSave.Name = "StripMenuSave";
            this.StripMenuSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.StripMenuSave.Size = new System.Drawing.Size(174, 22);
            this.StripMenuSave.Text = "Save image";
            this.StripMenuSave.Click += new System.EventHandler(this.StripMenuSave_Click);
            // 
            // StripMenuClose
            // 
            this.StripMenuClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.StripMenuClose.Name = "StripMenuClose";
            this.StripMenuClose.Size = new System.Drawing.Size(174, 22);
            this.StripMenuClose.Text = "Close window";
            this.StripMenuClose.Click += new System.EventHandler(this.StripMenuClose_Click);
            // 
            // PictureViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(443, 376);
            this.Controls.Add(this.MainMenu);
            this.Controls.Add(this.PictureBoxMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.Name = "PictureViewerForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.ResizeEnd += new System.EventHandler(this.PictureViewerForm_ResizeEnd);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.PictureViewerFormMain_MouseWheel);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxMain)).EndInit();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox PictureBoxMain;
		private System.Windows.Forms.MenuStrip MainMenu;
		private System.Windows.Forms.ToolStripMenuItem StripMenuFile;
		private System.Windows.Forms.ToolStripMenuItem StripMenuSave;
		private System.Windows.Forms.ToolStripMenuItem StripMenuClose;
	}
}
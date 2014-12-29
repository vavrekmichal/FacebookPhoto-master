namespace FacebookPicture {
	partial class MainForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ButtonGenerate = new System.Windows.Forms.Button();
            this.GroupBoxMain = new System.Windows.Forms.GroupBox();
            this.CheckBoxAutoSize = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CheckBoxPhotos = new System.Windows.Forms.CheckBox();
            this.CheckBoxFriendInfo = new System.Windows.Forms.CheckBox();
            this.TrackBarPhotoSize = new System.Windows.Forms.TrackBar();
            this.LabelPhotoSize = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TrackBarImageHeight = new System.Windows.Forms.TrackBar();
            this.TrackBarImageWidth = new System.Windows.Forms.TrackBar();
            this.LabelImageHeight = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LabelImageWidth = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ButtonShowLast = new System.Windows.Forms.Button();
            this.GroupBoxMain.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarPhotoSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarImageHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarImageWidth)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonGenerate
            // 
            this.ButtonGenerate.Image = global::FacebookPicture.Properties.Resources.generate;
            this.ButtonGenerate.Location = new System.Drawing.Point(184, 9);
            this.ButtonGenerate.Name = "ButtonGenerate";
            this.ButtonGenerate.Size = new System.Drawing.Size(115, 36);
            this.ButtonGenerate.TabIndex = 0;
            this.ButtonGenerate.UseVisualStyleBackColor = true;
            this.ButtonGenerate.Click += new System.EventHandler(this.ButtonGenerate_Click);
            // 
            // GroupBoxMain
            // 
            this.GroupBoxMain.Controls.Add(this.CheckBoxAutoSize);
            this.GroupBoxMain.Controls.Add(this.groupBox2);
            this.GroupBoxMain.Controls.Add(this.TrackBarPhotoSize);
            this.GroupBoxMain.Controls.Add(this.LabelPhotoSize);
            this.GroupBoxMain.Controls.Add(this.label4);
            this.GroupBoxMain.Controls.Add(this.TrackBarImageHeight);
            this.GroupBoxMain.Controls.Add(this.TrackBarImageWidth);
            this.GroupBoxMain.Controls.Add(this.LabelImageHeight);
            this.GroupBoxMain.Controls.Add(this.label3);
            this.GroupBoxMain.Controls.Add(this.LabelImageWidth);
            this.GroupBoxMain.Controls.Add(this.label1);
            this.GroupBoxMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.GroupBoxMain.Location = new System.Drawing.Point(0, 0);
            this.GroupBoxMain.Name = "GroupBoxMain";
            this.GroupBoxMain.Size = new System.Drawing.Size(327, 408);
            this.GroupBoxMain.TabIndex = 1;
            this.GroupBoxMain.TabStop = false;
            this.GroupBoxMain.Text = "Settings";
            // 
            // CheckBoxAutoSize
            // 
            this.CheckBoxAutoSize.AutoSize = true;
            this.CheckBoxAutoSize.Location = new System.Drawing.Point(16, 220);
            this.CheckBoxAutoSize.Name = "CheckBoxAutoSize";
            this.CheckBoxAutoSize.Size = new System.Drawing.Size(303, 17);
            this.CheckBoxAutoSize.TabIndex = 17;
            this.CheckBoxAutoSize.Text = "Autosize photos - larger photos for people with more friends";
            this.CheckBoxAutoSize.UseVisualStyleBackColor = true;
            this.CheckBoxAutoSize.CheckedChanged += new System.EventHandler(this.CheckBoxAutoSize_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CheckBoxPhotos);
            this.groupBox2.Controls.Add(this.CheckBoxFriendInfo);
            this.groupBox2.Location = new System.Drawing.Point(165, 325);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(148, 68);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Saved data:";
            // 
            // CheckBoxPhotos
            // 
            this.CheckBoxPhotos.AutoSize = true;
            this.CheckBoxPhotos.Location = new System.Drawing.Point(7, 45);
            this.CheckBoxPhotos.Name = "CheckBoxPhotos";
            this.CheckBoxPhotos.Size = new System.Drawing.Size(129, 17);
            this.CheckBoxPhotos.TabIndex = 1;
            this.CheckBoxPhotos.Text = "Refresh profile photos";
            this.CheckBoxPhotos.UseVisualStyleBackColor = true;
            // 
            // CheckBoxFriendInfo
            // 
            this.CheckBoxFriendInfo.AutoSize = true;
            this.CheckBoxFriendInfo.Location = new System.Drawing.Point(7, 20);
            this.CheckBoxFriendInfo.Name = "CheckBoxFriendInfo";
            this.CheckBoxFriendInfo.Size = new System.Drawing.Size(112, 17);
            this.CheckBoxFriendInfo.TabIndex = 0;
            this.CheckBoxFriendInfo.Text = "Refresh friend info";
            this.CheckBoxFriendInfo.UseVisualStyleBackColor = true;
            // 
            // TrackBarPhotoSize
            // 
            this.TrackBarPhotoSize.Location = new System.Drawing.Point(14, 168);
            this.TrackBarPhotoSize.Maximum = 50;
            this.TrackBarPhotoSize.Minimum = 15;
            this.TrackBarPhotoSize.Name = "TrackBarPhotoSize";
            this.TrackBarPhotoSize.Size = new System.Drawing.Size(301, 45);
            this.TrackBarPhotoSize.TabIndex = 8;
            this.TrackBarPhotoSize.TickFrequency = 5;
            this.TrackBarPhotoSize.Value = 15;
            this.TrackBarPhotoSize.ValueChanged += new System.EventHandler(this.TrackBarPhotoSize_ValueChanged);
            // 
            // LabelPhotoSize
            // 
            this.LabelPhotoSize.Location = new System.Drawing.Point(215, 152);
            this.LabelPhotoSize.Name = "LabelPhotoSize";
            this.LabelPhotoSize.Size = new System.Drawing.Size(100, 13);
            this.LabelPhotoSize.TabIndex = 7;
            this.LabelPhotoSize.Text = "50px";
            this.LabelPhotoSize.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Profile photo size:";
            // 
            // TrackBarImageHeight
            // 
            this.TrackBarImageHeight.LargeChange = 256;
            this.TrackBarImageHeight.Location = new System.Drawing.Point(12, 106);
            this.TrackBarImageHeight.Maximum = 4096;
            this.TrackBarImageHeight.Minimum = 512;
            this.TrackBarImageHeight.Name = "TrackBarImageHeight";
            this.TrackBarImageHeight.Size = new System.Drawing.Size(301, 45);
            this.TrackBarImageHeight.SmallChange = 32;
            this.TrackBarImageHeight.TabIndex = 5;
            this.TrackBarImageHeight.TickFrequency = 256;
            this.TrackBarImageHeight.Value = 512;
            this.TrackBarImageHeight.ValueChanged += new System.EventHandler(this.TrackBarImageHeight_ValueChanged);
            // 
            // TrackBarImageWidth
            // 
            this.TrackBarImageWidth.LargeChange = 256;
            this.TrackBarImageWidth.Location = new System.Drawing.Point(12, 42);
            this.TrackBarImageWidth.Maximum = 4096;
            this.TrackBarImageWidth.Minimum = 512;
            this.TrackBarImageWidth.Name = "TrackBarImageWidth";
            this.TrackBarImageWidth.Size = new System.Drawing.Size(301, 45);
            this.TrackBarImageWidth.SmallChange = 32;
            this.TrackBarImageWidth.TabIndex = 4;
            this.TrackBarImageWidth.TickFrequency = 256;
            this.TrackBarImageWidth.Value = 512;
            this.TrackBarImageWidth.ValueChanged += new System.EventHandler(this.TrackBarImageWidth_ValueChanged);
            // 
            // LabelImageHeight
            // 
            this.LabelImageHeight.Location = new System.Drawing.Point(213, 90);
            this.LabelImageHeight.Name = "LabelImageHeight";
            this.LabelImageHeight.Size = new System.Drawing.Size(100, 13);
            this.LabelImageHeight.TabIndex = 3;
            this.LabelImageHeight.Text = "1200px";
            this.LabelImageHeight.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Image height:";
            // 
            // LabelImageWidth
            // 
            this.LabelImageWidth.Location = new System.Drawing.Point(215, 26);
            this.LabelImageWidth.Name = "LabelImageWidth";
            this.LabelImageWidth.Size = new System.Drawing.Size(100, 13);
            this.LabelImageWidth.TabIndex = 1;
            this.LabelImageWidth.Text = "1200px";
            this.LabelImageWidth.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Image width:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ButtonShowLast);
            this.panel1.Controls.Add(this.ButtonGenerate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 414);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(327, 55);
            this.panel1.TabIndex = 2;
            // 
            // ButtonShowLast
            // 
            this.ButtonShowLast.Enabled = false;
            this.ButtonShowLast.Image = global::FacebookPicture.Properties.Resources.last;
            this.ButtonShowLast.Location = new System.Drawing.Point(29, 9);
            this.ButtonShowLast.Name = "ButtonShowLast";
            this.ButtonShowLast.Size = new System.Drawing.Size(115, 36);
            this.ButtonShowLast.TabIndex = 1;
            this.ButtonShowLast.UseVisualStyleBackColor = true;
            this.ButtonShowLast.Click += new System.EventHandler(this.ButtonShowLast_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 469);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.GroupBoxMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "FaceGraph";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.GroupBoxMain.ResumeLayout(false);
            this.GroupBoxMain.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarPhotoSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarImageHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarImageWidth)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button ButtonGenerate;
		private System.Windows.Forms.GroupBox GroupBoxMain;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TrackBar TrackBarPhotoSize;
		private System.Windows.Forms.Label LabelPhotoSize;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TrackBar TrackBarImageHeight;
		private System.Windows.Forms.TrackBar TrackBarImageWidth;
		private System.Windows.Forms.Label LabelImageHeight;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label LabelImageWidth;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox CheckBoxPhotos;
        private System.Windows.Forms.CheckBox CheckBoxFriendInfo;
		private System.Windows.Forms.Button ButtonShowLast;
        private System.Windows.Forms.CheckBox CheckBoxAutoSize;

	}
}


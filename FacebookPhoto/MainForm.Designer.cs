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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CheckBoxPhotos = new System.Windows.Forms.CheckBox();
            this.CheckBoxFriendInfo = new System.Windows.Forms.CheckBox();
            this.TrackBarPhotoSize = new System.Windows.Forms.TrackBar();
            this.LabelPhotoSize = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ButtonShowLast = new System.Windows.Forms.Button();
            this.InputChannel = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.GroupBoxMain.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarPhotoSize)).BeginInit();
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
            this.GroupBoxMain.Controls.Add(this.radioButton1);
            this.GroupBoxMain.Controls.Add(this.InputChannel);
            this.GroupBoxMain.Controls.Add(this.groupBox2);
            this.GroupBoxMain.Controls.Add(this.TrackBarPhotoSize);
            this.GroupBoxMain.Controls.Add(this.LabelPhotoSize);
            this.GroupBoxMain.Controls.Add(this.label4);
            this.GroupBoxMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.GroupBoxMain.Location = new System.Drawing.Point(0, 0);
            this.GroupBoxMain.Name = "GroupBoxMain";
            this.GroupBoxMain.Size = new System.Drawing.Size(327, 408);
            this.GroupBoxMain.TabIndex = 1;
            this.GroupBoxMain.TabStop = false;
            this.GroupBoxMain.Text = "Settings";
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
            this.CheckBoxFriendInfo.CheckedChanged += new System.EventHandler(this.CheckBoxFriendInfo_CheckedChanged);
            // 
            // TrackBarPhotoSize
            // 
            this.TrackBarPhotoSize.Location = new System.Drawing.Point(20, 57);
            this.TrackBarPhotoSize.Maximum = 50;
            this.TrackBarPhotoSize.Minimum = 15;
            this.TrackBarPhotoSize.Name = "TrackBarPhotoSize";
            this.TrackBarPhotoSize.Size = new System.Drawing.Size(301, 45);
            this.TrackBarPhotoSize.TabIndex = 8;
            this.TrackBarPhotoSize.TickFrequency = 5;
            this.TrackBarPhotoSize.Value = 15;
            this.TrackBarPhotoSize.Scroll += new System.EventHandler(this.TrackBarPhotoSize_Scroll);
            this.TrackBarPhotoSize.ValueChanged += new System.EventHandler(this.TrackBarPhotoSize_ValueChanged);
            // 
            // LabelPhotoSize
            // 
            this.LabelPhotoSize.Location = new System.Drawing.Point(221, 41);
            this.LabelPhotoSize.Name = "LabelPhotoSize";
            this.LabelPhotoSize.Size = new System.Drawing.Size(100, 13);
            this.LabelPhotoSize.TabIndex = 7;
            this.LabelPhotoSize.Text = "50px";
            this.LabelPhotoSize.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Profile photo size:";
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
            // InputChannel
            // 
            this.InputChannel.AutoSize = true;
            this.InputChannel.Checked = true;
            this.InputChannel.Location = new System.Drawing.Point(17, 19);
            this.InputChannel.Name = "InputChannel";
            this.InputChannel.Size = new System.Drawing.Size(84, 17);
            this.InputChannel.TabIndex = 14;
            this.InputChannel.Text = "Profile photo";
            this.InputChannel.UseVisualStyleBackColor = true;
            this.InputChannel.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(17, 167);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(67, 17);
            this.radioButton1.TabIndex = 15;
            this.radioButton1.Text = "Local file";
            this.radioButton1.UseVisualStyleBackColor = true;
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
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox CheckBoxPhotos;
        private System.Windows.Forms.CheckBox CheckBoxFriendInfo;
        private System.Windows.Forms.Button ButtonShowLast;
        private System.Windows.Forms.RadioButton InputChannel;
        private System.Windows.Forms.RadioButton radioButton1;

	}
}


namespace FacebookPicture {
    partial class SettingsForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.GroupBoxMain = new System.Windows.Forms.GroupBox();
            this.fileLocation = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.localFile = new System.Windows.Forms.RadioButton();
            this.InputChannel = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CheckBoxPhotos = new System.Windows.Forms.CheckBox();
            this.ButtonGenerate = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ButtonShowLast = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.GroupBoxMain.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBoxMain
            // 
            this.GroupBoxMain.Controls.Add(this.groupBox1);
            this.GroupBoxMain.Controls.Add(this.fileLocation);
            this.GroupBoxMain.Controls.Add(this.button1);
            this.GroupBoxMain.Controls.Add(this.localFile);
            this.GroupBoxMain.Controls.Add(this.InputChannel);
            this.GroupBoxMain.Controls.Add(this.groupBox2);
            this.GroupBoxMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.GroupBoxMain.Location = new System.Drawing.Point(0, 0);
            this.GroupBoxMain.Name = "GroupBoxMain";
            this.GroupBoxMain.Size = new System.Drawing.Size(331, 408);
            this.GroupBoxMain.TabIndex = 3;
            this.GroupBoxMain.TabStop = false;
            this.GroupBoxMain.Text = "Settings";
            // 
            // fileLocation
            // 
            this.fileLocation.Enabled = false;
            this.fileLocation.Location = new System.Drawing.Point(98, 193);
            this.fileLocation.Name = "fileLocation";
            this.fileLocation.Size = new System.Drawing.Size(223, 20);
            this.fileLocation.TabIndex = 17;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(17, 190);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "Choose file";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // localFile
            // 
            this.localFile.AutoSize = true;
            this.localFile.Location = new System.Drawing.Point(17, 167);
            this.localFile.Name = "localFile";
            this.localFile.Size = new System.Drawing.Size(67, 17);
            this.localFile.TabIndex = 15;
            this.localFile.Text = "Local file";
            this.localFile.UseVisualStyleBackColor = true;
            this.localFile.CheckedChanged += new System.EventHandler(this.localFile_CheckedChanged);
            // 
            // InputChannel
            // 
            this.InputChannel.AutoSize = true;
            this.InputChannel.Checked = true;
            this.InputChannel.Location = new System.Drawing.Point(17, 128);
            this.InputChannel.Name = "InputChannel";
            this.InputChannel.Size = new System.Drawing.Size(84, 17);
            this.InputChannel.TabIndex = 14;
            this.InputChannel.TabStop = true;
            this.InputChannel.Text = "Profile photo";
            this.InputChannel.UseVisualStyleBackColor = true;
            this.InputChannel.CheckedChanged += new System.EventHandler(this.InputChannel_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CheckBoxPhotos);
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
            this.CheckBoxPhotos.Checked = true;
            this.CheckBoxPhotos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxPhotos.Location = new System.Drawing.Point(7, 45);
            this.CheckBoxPhotos.Name = "CheckBoxPhotos";
            this.CheckBoxPhotos.Size = new System.Drawing.Size(129, 17);
            this.CheckBoxPhotos.TabIndex = 1;
            this.CheckBoxPhotos.Text = "Refresh profile photos";
            this.CheckBoxPhotos.UseVisualStyleBackColor = true;
            this.CheckBoxPhotos.CheckedChanged += new System.EventHandler(this.CheckBoxPhotos_CheckedChanged);
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
            // panel1
            // 
            this.panel1.Controls.Add(this.ButtonShowLast);
            this.panel1.Controls.Add(this.ButtonGenerate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 418);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(331, 55);
            this.panel1.TabIndex = 4;
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
            this.ButtonShowLast.Click += new System.EventHandler(this.ButtonShowLast_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(17, 285);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(142, 108);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Palette";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(12, 20);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(88, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "+/- Rounding";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(12, 43);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(86, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "no Rounding";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 473);
            this.Controls.Add(this.GroupBoxMain);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.GroupBoxMain.ResumeLayout(false);
            this.GroupBoxMain.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupBoxMain;
        private System.Windows.Forms.RadioButton localFile;
        private System.Windows.Forms.RadioButton InputChannel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox CheckBoxPhotos;
        private System.Windows.Forms.Button ButtonGenerate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ButtonShowLast;
        private System.Windows.Forms.TextBox fileLocation;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}
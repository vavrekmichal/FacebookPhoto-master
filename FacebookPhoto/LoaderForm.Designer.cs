namespace FacebookPicture {
	partial class LoaderForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoaderForm));
            this.backgroundLoader = new System.ComponentModel.BackgroundWorker();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.LabelOverall = new System.Windows.Forms.Label();
            this.ProgressBarOverall = new System.Windows.Forms.ProgressBar();
            this.LabelOverallStage = new System.Windows.Forms.Label();
            this.LabelOperation = new System.Windows.Forms.Label();
            this.ProgressBarOperation = new System.Windows.Forms.ProgressBar();
            this.LabelOperationPercentage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Image = global::FacebookPicture.Properties.Resources.cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(109, 139);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(95, 36);
            this.ButtonCancel.TabIndex = 0;
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // LabelOverall
            // 
            this.LabelOverall.AutoSize = true;
            this.LabelOverall.Location = new System.Drawing.Point(13, 13);
            this.LabelOverall.Name = "LabelOverall";
            this.LabelOverall.Size = new System.Drawing.Size(86, 13);
            this.LabelOverall.TabIndex = 1;
            this.LabelOverall.Text = "Overall progress:";
            // 
            // ProgressBarOverall
            // 
            this.ProgressBarOverall.Location = new System.Drawing.Point(16, 29);
            this.ProgressBarOverall.Name = "ProgressBarOverall";
            this.ProgressBarOverall.Size = new System.Drawing.Size(311, 23);
            this.ProgressBarOverall.TabIndex = 2;
            // 
            // LabelOverallStage
            // 
            this.LabelOverallStage.AutoSize = true;
            this.LabelOverallStage.Location = new System.Drawing.Point(303, 13);
            this.LabelOverallStage.Name = "LabelOverallStage";
            this.LabelOverallStage.Size = new System.Drawing.Size(24, 13);
            this.LabelOverallStage.TabIndex = 3;
            this.LabelOverallStage.Text = "0/5";
            this.LabelOverallStage.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LabelOperation
            // 
            this.LabelOperation.AutoSize = true;
            this.LabelOperation.Location = new System.Drawing.Point(13, 79);
            this.LabelOperation.Name = "LabelOperation";
            this.LabelOperation.Size = new System.Drawing.Size(137, 13);
            this.LabelOperation.TabIndex = 4;
            this.LabelOperation.Text = "Loading friend information...";
            // 
            // ProgressBarOperation
            // 
            this.ProgressBarOperation.Location = new System.Drawing.Point(16, 95);
            this.ProgressBarOperation.Name = "ProgressBarOperation";
            this.ProgressBarOperation.Size = new System.Drawing.Size(308, 23);
            this.ProgressBarOperation.TabIndex = 5;
            // 
            // LabelOperationPercentage
            // 
            this.LabelOperationPercentage.Location = new System.Drawing.Point(259, 79);
            this.LabelOperationPercentage.Name = "LabelOperationPercentage";
            this.LabelOperationPercentage.Size = new System.Drawing.Size(65, 13);
            this.LabelOperationPercentage.TabIndex = 6;
            this.LabelOperationPercentage.Text = "0%";
            this.LabelOperationPercentage.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LoaderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 187);
            this.Controls.Add(this.LabelOperationPercentage);
            this.Controls.Add(this.ProgressBarOperation);
            this.Controls.Add(this.LabelOperation);
            this.Controls.Add(this.LabelOverallStage);
            this.Controls.Add(this.ProgressBarOverall);
            this.Controls.Add(this.LabelOverall);
            this.Controls.Add(this.ButtonCancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoaderForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Generating graph...";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoaderForm_FormClosing);
            this.Load += new System.EventHandler(this.LoaderForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.ComponentModel.BackgroundWorker backgroundLoader;
		private System.Windows.Forms.Button ButtonCancel;
		private System.Windows.Forms.Label LabelOverall;
		private System.Windows.Forms.ProgressBar ProgressBarOverall;
		private System.Windows.Forms.Label LabelOverallStage;
		private System.Windows.Forms.Label LabelOperation;
		private System.Windows.Forms.ProgressBar ProgressBarOperation;
		private System.Windows.Forms.Label LabelOperationPercentage;
	}
}
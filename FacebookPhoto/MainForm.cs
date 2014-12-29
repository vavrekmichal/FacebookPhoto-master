using System;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FacebookPicture {
	public partial class MainForm : Form {
		public MainForm() {
			InitializeComponent();

			if(File.Exists("cache/" + Config.USER_ID + "/graph.jpg")) {
				ButtonShowLast.Enabled = true;
			}

			TrackBarImageWidth.Value = GraphSettings.ImageWidth;
			TrackBarImageHeight.Value = GraphSettings.ImageHeight;
			TrackBarPhotoSize.Value = GraphSettings.PhotoSize;

			UpdateLabels();
		}

		// Generate button -> creating new LoaderForm starts generating
		private void ButtonGenerate_Click(object sender, EventArgs e) {

			// checks if friend info is to be redownloaded == deletes the data file
			if(CheckBoxFriendInfo.Checked) {
				if(File.Exists("cache/" + Config.USER_ID + "/data.json"))
					try {
						File.Delete("cache/" + Config.USER_ID + "/data.json");
					} catch {
						MessageBox.Show("Couldn't delete friend info data. File is opened or inaccessible and generating the graph might now work well.");
					}
			}

			// checks if friend photos are to be redownloaded == deletes the photos/ files
			if(CheckBoxPhotos.Checked) {
				string path = "cache/" + Config.USER_ID + "/photos";

				if(Directory.Exists(path)) {
					foreach(string file in Directory.GetFiles(path)) {
						try {
							File.Delete("cache/" + Config.USER_ID + "/photos/" + file);
						} catch {}						
					}
				}
			}

			LoaderForm lf = new LoaderForm();
			lf.ShowDialog(this);

			if(File.Exists("cache/" + Config.USER_ID + "/graph.jpg")) {
				ButtonShowLast.Enabled = true;
			}
		}

		// Form change handlers:

		private void TrackBarImageWidth_ValueChanged(object sender, EventArgs e) {
			GraphSettings.ImageWidth = TrackBarImageWidth.Value;
			UpdateLabels();
		}

		private void TrackBarImageHeight_ValueChanged(object sender, EventArgs e) {
			GraphSettings.ImageHeight = TrackBarImageHeight.Value;
			UpdateLabels();
		}

		private void TrackBarPhotoSize_ValueChanged(object sender, EventArgs e) {
			GraphSettings.PhotoSize = TrackBarPhotoSize.Value;
			UpdateLabels();
		}


		/// <summary>
		/// Config values -> FormLabels
		/// </summary>
		private void UpdateLabels() {
			LabelImageWidth.Text = GraphSettings.ImageWidth + "px";
			LabelImageHeight.Text = GraphSettings.ImageHeight + "px";
			LabelPhotoSize.Text = GraphSettings.PhotoSize + "px";
		}

		private void ButtonShowLast_Click(object sender, EventArgs e) {
			PictureViewerForm pvf = new PictureViewerForm("cache/" + Config.USER_ID + "/graph.jpg");

			if(!pvf.Disposing && !pvf.IsDisposed) {
				pvf.ShowDialog();
				((IDisposable) pvf).Dispose();
			}
		}

		private void CheckBoxAutoSize_CheckedChanged(object sender, EventArgs e) {
			GraphSettings.AutoSize = CheckBoxAutoSize.Checked;

			if(CheckBoxAutoSize.Checked) {
				TrackBarPhotoSize.Enabled = false;
			} else {
				TrackBarPhotoSize.Enabled = true;
			}
		}

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void TrackBarQuality_Scroll(object sender, EventArgs e) {

        }
	}
}

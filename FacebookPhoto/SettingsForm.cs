using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FacebookPicture {
    public partial class SettingsForm : Form {
        public SettingsForm() {
            InitializeComponent();
            if (File.Exists("cache/" + Config.USER_ID + "/graph.jpg")) {
                ButtonShowLast.Enabled = true;
            }

        }

        private void ButtonGenerate_Click(object sender, EventArgs e) {

            string picture = "";
            if (localFile.Checked) {
                picture = fileLocation.Text;
                if (String.IsNullOrWhiteSpace(picture)){
                    MessageBox.Show("You must fill location of a file which contains the picture.");
                    return;
                }
                Bitmap img = null;
                // test if program can create the picture 
                try {
                    img = new Bitmap(ofd.FileName);
                } catch (ArgumentException) {
                    fileLocation.Text = "";
                    MessageBox.Show("Couldn't load file " + ofd.FileName + ". Sorry");
                    return;
                }
                if (img != null) {
                    try {
                        EngineSettings.ImageWidth = img.Width; // boundery control
                        EngineSettings.ImageHeight = img.Height;
                        var img2 = new Bitmap(img.Width * EngineSettings.PhotoSize, img.Height * EngineSettings.PhotoSize);
                    } catch (ArgumentException) {
                        fileLocation.Text = "";
                        MessageBox.Show("Picture from " + ofd.FileName + " will be too huge. Sorry");
                        return;
                    }
                }
            }
            
            if (InputChannel.Checked) {
                picture = "cache/" + Config.USER_ID + "/photos/" + Config.USER_ID + ".jpg";
            }

            // checks if friend photos are to be redownloaded == deletes the photos/ files
            if (CheckBoxPhotos.Checked) {
                string path = "cache/" + Config.USER_ID + "/photos";

                if (Directory.Exists(path)) {
                    foreach (string file in Directory.GetFiles(path)) {
                        try {
                            File.Delete(path+ "/" + file);

                        } catch { }
                    }
                }
            }


            LoaderForm lf = new LoaderForm(picture);
            lf.ShowDialog(this);

            if (File.Exists("cache/" + Config.USER_ID + "/picture.jpg")) {
                ButtonShowLast.Enabled = true;
            }
        }


        private void ButtonShowLast_Click_1(object sender, EventArgs e) {
            PictureViewerForm pvf = new PictureViewerForm("cache/" + Config.USER_ID + "/picture.jpg");

            if (!pvf.Disposing && !pvf.IsDisposed) {
                pvf.ShowDialog();
                ((IDisposable)pvf).Dispose();
            }
        }

        private void CheckBoxPhotos_CheckedChanged(object sender, EventArgs e) {

        }

        private void InputChannel_CheckedChanged(object sender, EventArgs e) {
            //label4.Enabled = InputChannel.Checked;
            //LabelPhotoSize.Enabled = InputChannel.Checked;
            //TrackBarPhotoSize.Enabled = InputChannel.Checked;
        }

        private void LabelPhotoSize_Click(object sender, EventArgs e) {

        }

        private void TrackBarPhotoSize_Scroll(object sender, EventArgs e) {

        }

        private void TrackBarPhotoSize_ValueChanged(object sender, EventArgs e) {
        }

        OpenFileDialog ofd = new OpenFileDialog();

        private void localFile_CheckedChanged(object sender, EventArgs e) {
            button1.Enabled = localFile.Checked;
            fileLocation.Enabled = localFile.Checked;
        }

        private void button1_Click(object sender, EventArgs e) {
            ofd.Filter = "Image files | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (ofd.ShowDialog() == DialogResult.OK) {
                fileLocation.Text = ofd.FileName;
                
            }
        }
    }
}

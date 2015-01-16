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
            if (File.Exists("cache/" + Config.USER_ID + "/picture.jpg")) {
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
                        if (pixelPrecisionOprtion.Checked) {
                            var img2 = new Bitmap(img.Width * EngineSettings.PhotoSize, img.Height * EngineSettings.PhotoSize);
                        } else {
                            var img2 = new Bitmap(img.Width , img.Height );
                        }
                    } catch (ArgumentException) {
                        fileLocation.Text = "";
                        MessageBox.Show("Picture from " + ofd.FileName + " will be too huge. Sorry");
                        return;
                    }
                }
            }

            if (InputChannel.Checked) {
                string sufixImg = pixelPrecisionOprtion.Checked ? ".jpg" : "Large.jpg";
                picture = "cache/" + Config.USER_ID + "/photos/" + Config.USER_ID + sufixImg;
            }

            // checks if friend photos are to be redownloaded == deletes the photos/ files
            if (CheckBoxPhotos.Checked) {
                string path = "cache/" + Config.USER_ID + "/photos";

                if (Directory.Exists(path)) {
                    foreach (string file in Directory.GetFiles(path)) {
                        try {
                            File.Delete( file);

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

        private void groupBox1_Enter(object sender, EventArgs e) {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e) {
            PaletteManager.PaletteID = 0;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e) {
            PaletteManager.PaletteID = 1;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e) {
            PaletteManager.PaletteID = 2;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e) {
            PaletteManager.PaletteID = 3;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e) {
            PictureManager.PictureID = 0;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e) {
            PictureManager.PictureID = 1;
            trackBar1.Enabled = radioButton6.Checked;
            label1.Enabled = radioButton6.Checked;
        }

        private void trackBar1_Scroll(object sender, EventArgs e) {
            EngineSettings.PixelPrecision = trackBar1.Value *5;
            label1.Text = EngineSettings.PixelPrecision + "px";
        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void radioButton5_CheckedChanged_1(object sender, EventArgs e) {
            PaletteManager.PaletteID = 4;
            label4.Enabled = radioButton5.Checked;
            textBox1.Enabled = radioButton5.Checked;
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e) {
            PaletteManager.PaletteID = 5;
            label5.Enabled = radioButton7.Checked;
            textBox2.Enabled = radioButton7.Checked;
            label6.Enabled = radioButton7.Checked;
            textBox3.Enabled = radioButton7.Checked;
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e) {
            PaletteManager.PaletteID = 6;
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
            int treshold = 11;
            Int32.TryParse( textBox1.Text,out treshold);
            EngineSettings.EHDTreshold = treshold;
            textBox1.Text = EngineSettings.EHDTreshold.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e) {
            int coef = 256;
            Int32.TryParse(textBox2.Text, out coef);
            EngineSettings.SCDCoeficients = coef;
            textBox2.Text = EngineSettings.SCDCoeficients.ToString();
        }

        private void textBox3_TextChanged(object sender, EventArgs e) {
            int bitplan = 0;
            Int32.TryParse(textBox3.Text, out bitplan);
            EngineSettings.SCDBitplan = bitplan;
            textBox3.Text = EngineSettings.SCDBitplan.ToString();
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e) {
            PaletteManager.PaletteID = 7;
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e) {
            PaletteManager.PaletteID = 8;
        }
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace FacebookPicture {
	public partial class PictureViewerForm : Form, IDisposable {
		private Point dragStart;
		private double zoom = 1;
		private string fileName;
		private Image img;

		/// <summary>
		/// Initializes the window and loads inside an image.
		/// </summary>
		/// <param name="fileName">Path for the image to be shown</param>
		public PictureViewerForm(string file) {
			InitializeComponent();
			
			// we set the initial window size
			Width = Math.Min(1100, EngineSettings.ImageWidth);
			Height = Math.Min(700, EngineSettings.ImageHeight);

			ResizeImageToWindow();

			fileName = file;

			try {
				img = Image.FromFile(fileName);
				PictureBoxMain.Image = img;
			} catch {
				MessageBox.Show("Couldn't load file " + fileName + ". Sorry");
				Close();
			}
		}


		/// <summary>
		/// Setting the starting point from which we drag the image (if we drag it).
		/// </summary>
		private void PictureBoxMain_MouseDown(object sender, MouseEventArgs e) {
			dragStart = e.Location;
		}


		/// <summary>
		/// Dragging the image insde the window.
		/// </summary>
		private void PictureBoxMain_MouseMove(object sender, MouseEventArgs e) {
			if(e.Button != MouseButtons.Left) return;

			int x = PictureBoxMain.Location.X;
			int y = PictureBoxMain.Location.Y;

			x -= dragStart.X - e.X;
			y -= dragStart.Y - e.Y;

			// check the edges
			if(x > 0) x = 0;
			if(y > 0) y = 0;

			if(x + PictureBoxMain.Width < this.Width) x = this.Width - PictureBoxMain.Width;
			if(y + PictureBoxMain.Height < this.Height) y = this.Height - PictureBoxMain.Height;

			PictureBoxMain.Left = x;
			PictureBoxMain.Top = y;
		}


		/// <summary>
		/// Zooming out and in via mouse wheel handler
		/// </summary>
		private void PictureViewerFormMain_MouseWheel(object sender, MouseEventArgs e) {
			double modifier = 1.0 + 1.0 / ((double) e.Delta / 30.0);
			zoom *= modifier;

			if(EngineSettings.ImageWidth * zoom <= Width && zoom < 1)
				zoom = (double) PictureBoxMain.Width / (double) EngineSettings.ImageWidth;

			int lastW = PictureBoxMain.Width;
			int lastH = PictureBoxMain.Height;

			PictureBoxMain.SuspendLayout();
			PictureBoxMain.Width = (int) (EngineSettings.ImageWidth * zoom);
			PictureBoxMain.Height = (int) (EngineSettings.ImageHeight * zoom);

			PictureBoxMain.Left = (int) (PictureBoxMain.Location.X + (lastW - EngineSettings.ImageWidth * zoom) / 2);
			PictureBoxMain.Top = (int) (PictureBoxMain.Location.Y + (lastH - EngineSettings.ImageHeight * zoom) / 2);
			PictureBoxMain.ResumeLayout();
		}


		/// <summary>
		/// Resizes window and keeps the dimensions ratio. Then resizes the graph to fir inside the window.
		/// </summary>
		private void ResizeImageToWindow() {
			// and scale it to the ratio of the image (scale the larger side)
			if(EngineSettings.ImageWidth > EngineSettings.ImageHeight) {
				Height = (int) (Width * ((double) EngineSettings.ImageHeight / (double) EngineSettings.ImageWidth));
				PictureBoxMain.Width = Width;
				PictureBoxMain.Height = Height;
			} else {
				Width = (int) (Height * ((double) EngineSettings.ImageWidth / (double) EngineSettings.ImageHeight));
				PictureBoxMain.Width = Width;
				PictureBoxMain.Height = Height;
			}

			// we count the initial zoom, so the image fits right in the window
			zoom = (double) PictureBoxMain.Width / (double) EngineSettings.ImageWidth;
		}


		/// <summary>
		/// Handler called after the windowresize has finished (user let the grip).
		/// </summary>
		private void PictureViewerForm_ResizeEnd(object sender, EventArgs e) {
			ResizeImageToWindow();
		}


		private void StripMenuClose_Click(object sender, EventArgs e) {
			Close();
		}


		/// <summary>
		/// Saves the resulting genereated graph image to a folder chosen by user.
		/// </summary>
		private void StripMenuSave_Click(object sender, EventArgs e) {
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Filter = "JPEG Image|*.jpg";
			dlg.Title = "Save the graph image";
			dlg.ShowDialog();

			if(dlg.FileName.Length != 0) {
				try {
					if(File.Exists(dlg.FileName))
						File.Delete(dlg.FileName);

					File.Copy(fileName, dlg.FileName);
				} catch {
					MessageBox.Show("Couldn't open file " + dlg.FileName + " for writing and save the image.");
				}
			}
		}
		
		/// <summary>
		/// We need to destroy the handle because else we wouldn't be able to generate more times per run.
		/// </summary>
		void IDisposable.Dispose() {
			img.Dispose();
		}
	}
}

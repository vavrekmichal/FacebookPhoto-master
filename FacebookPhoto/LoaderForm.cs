using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FacebookPicture {
	public enum Stage {
		UserInfo,
		FriendsInfo,
		ProfilePictures,
		Calculating,
		Drawing
	}

	public partial class LoaderForm : Form {
		private Stage stage;
        private string filePath;

		public LoaderForm(string file) {
			InitializeComponent();
            filePath = file;
			stage = Stage.UserInfo;

			// setting up the starting loader screen
			LabelOperationPercentage.Text = "0%";
			LabelOverallStage.Text = "0/5";
			LabelOperation.Text = "Contacting Facebook...";

			// setting up the worker thread
			backgroundLoader = new System.ComponentModel.BackgroundWorker();

			backgroundLoader.WorkerReportsProgress = true;
			backgroundLoader.WorkerSupportsCancellation = true;

			backgroundLoader.DoWork += new DoWorkEventHandler(backgroundLoader_DoWork);
            backgroundLoader.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundLoader_RunWorkerCompleted);
            backgroundLoader.ProgressChanged += new ProgressChangedEventHandler(backgroundLoader_ProgressChanged);

			// starting the calculation
			// runs the GenerateGraph() method in Generator.cs
			backgroundLoader.RunWorkerAsync();
		}


		// here goes the heavy lifting
		private void backgroundLoader_DoWork(object sender, DoWorkEventArgs e) {
			e.Result = false;

			try {
				Generator.GenerateGraph(filePath, backgroundLoader);
			} catch(InterruptedException) {
				e.Result = false;
				return;
			} catch(FBAPIException) {
				MessageBox.Show("There was an error while contacting facebook. Please try again.");
				e.Result = false;
				return;
			} catch(System.IO.IOException) {
				MessageBox.Show("Couldn't write into a subdirectory/file. Please make the directory with the program writable.");
				e.Result = false;
				return;
			}

			e.Result = true;
		}


		/// <summary>
		/// Displaying the info through the progress bars depending on current stage.
		/// Progress is reported from the Generate() method (and from methods that Generate() calls).
		/// Everytime we reach 100% we change the stage and start over.
		/// </summary>
		private void backgroundLoader_ProgressChanged(object sender, ProgressChangedEventArgs e) {

			// stages are in order in which they are run
			// every stage adds a certain amount of % to the total progress
			switch(stage) {

				// This stage loads users friendlist, it is a short one.
				case Stage.UserInfo:
                    LabelOperation.Text = "Downloading profile pictures...";

					LabelOverallStage.Text = "1/5";
					LabelOperationPercentage.Text = "0/" + e.UserState;

					ProgressBarOverall.Value = 5; // + 5% to the overall progress

					stage = Stage.FriendsInfo;

					break;


				// Downloading info about friends and mutual friends
				case Stage.FriendsInfo:
					if(e.ProgressPercentage == 100) { // stage completed
						stage = Stage.ProfilePictures;

                        LabelOperation.Text = "Preparing palette from pictures...";

						LabelOverallStage.Text = "2/5";
						LabelOperationPercentage.Text = "0" + LabelOperationPercentage.Text.Substring(LabelOperationPercentage.Text.IndexOf('/'));

					} else {
						LabelOperationPercentage.Text = e.UserState + LabelOperationPercentage.Text.Substring(LabelOperationPercentage.Text.IndexOf('/'));
						ProgressBarOperation.Value = e.ProgressPercentage;
						ProgressBarOverall.Value = 5 + e.ProgressPercentage * 7 / 20; // + up to 35% to the overall progress
					}

					break;


				// This stage is the longest - downloads the profile picture for every friend
				case Stage.ProfilePictures:
					if(e.ProgressPercentage == 100) { // stage completed
						stage = Stage.Calculating;

                        LabelOperation.Text = "Calculating...";
						LabelOverallStage.Text = "3/5";
						LabelOperationPercentage.Text = "0%";
						ProgressBarOperation.Value = 0;

					} else {
						LabelOperationPercentage.Text = e.UserState + LabelOperationPercentage.Text.Substring(LabelOperationPercentage.Text.IndexOf('/'));
						ProgressBarOperation.Value = e.ProgressPercentage;
						ProgressBarOverall.Value = 40 + e.ProgressPercentage / 5 * 2; // + up to 40% to the overall progress
					}

					break;


				// Here we calculate the graph (position of vertices)
				case Stage.Calculating:

					if(e.ProgressPercentage == 100) { // stage completed
						stage = Stage.Drawing;

                        LabelOperation.Text = "Calculating picture...";

						LabelOverallStage.Text = "4/5";
						LabelOperationPercentage.Text = "0%";

					} else {
						LabelOperationPercentage.Text = e.ProgressPercentage + "%";
						ProgressBarOperation.Value = e.ProgressPercentage;
						ProgressBarOverall.Value = 80 + e.ProgressPercentage / 10; // + up to 10% to the overall progress
					}

					break;


				// In this stage we draw the result graph image (might take a sec too, if canvas large)
				case Stage.Drawing:

					if(e.ProgressPercentage == 100) { // stage completed
						stage = Stage.Calculating;
						LabelOperation.Text = "Finished";
						LabelOverallStage.Text = "5/5";
						
						// at the end of the stage, we show the result window
                        if (e.UserState != null) {
						    PictureViewerForm pvf = new PictureViewerForm((string) e.UserState);
						    pvf.ShowDialog();
						    ((IDisposable) pvf).Dispose();
                        }

					} else {
						LabelOperationPercentage.Text = e.ProgressPercentage + "%";
						ProgressBarOperation.Value = e.ProgressPercentage;
						ProgressBarOverall.Value = 90 + e.ProgressPercentage / 10; // + up to 10% to the overall progress
					}

					break;
			}
        }


		/// <summary>
		/// When we are finished with everything
		/// </summary>
		private void backgroundLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
			if((bool) e.Result == false) { // the user canceled the process or there was an error
				//MessageBox.Show("Canceled!");
			} 

			this.Close();
		}


		/// <summary>
		/// Handler for the Cancel button
		/// </summary>
		private void ButtonCancel_Click(object sender, EventArgs e) {
			backgroundLoader.CancelAsync();
			this.Close();
		}


		/// <summary>
		/// Handler for closing the formular by window button
		/// </summary>
		private void LoaderForm_FormClosing(object sender, FormClosingEventArgs e) {
			backgroundLoader.CancelAsync();
		}

        private void LoaderForm_Load(object sender, EventArgs e) {

        }
	}
}

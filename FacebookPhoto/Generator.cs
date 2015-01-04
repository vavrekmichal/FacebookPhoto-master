using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Net;

namespace FacebookPicture {
	using FriendGraph = Dictionary<Friend, List<Friend>>;

	// exception thrown when user cancels the generating process
	public class InterruptedException : ApplicationException { }

	public class Generator {

		/// <summary>
		/// Main generating method which prepares all the data and generates the graph.
		/// </summary>
		/// <param name="worker">For reporting progress outside as this method runs a loong time (due to downloading)</param>
        public static void GenerateGraph(string filePath, BackgroundWorker worker = null) {

            // load friendlist of our user
            FriendList friends = FBPictureAPI.GetData<FriendList>(Config.USER_ID + "/friends");

            // report that loading was fine
            worker.ReportProgress(0, friends.Count);

            // make sure the report made it through and updated GUI
            // this is necessary because the 
            System.Threading.Thread.Yield();

            // create destination directories
            if (!File.Exists("cache")) {
                System.IO.Directory.CreateDirectory("cache");
            }

            string dir = "cache/" + Config.USER_ID;

            if (!File.Exists(dir)) {
                System.IO.Directory.CreateDirectory(dir);
            }

            if (!File.Exists(dir + "/photos")) {
                System.IO.Directory.CreateDirectory(dir + "/photos");
            }

            // download profile pictures of the users
            DownloadPictures(friends, dir + "/photos", worker);

            // load all mutual friends and the whole graph
            //Graph graph = new Graph(); //MVA
            Picture picture = new Picture(PaletteManager.GetPalette(dir, friends, worker)); 
            

            {
                worker.ReportProgress(1); // download more pictures?
                worker.ReportProgress(100);
            }

            picture.CalcutePicture(new Bitmap(filePath), worker);
            // and we draw it to a file
            Bitmap bmp = picture.GetPicture(worker);

            bmp.Save(dir + "/picture.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            bmp.Dispose();
            
            worker.ReportProgress(100, dir + "/picture.jpg");
        }

		/// <summary>
		/// Download profile pictures of the users
		/// </summary>
		/// <param name="friends">Friend list</param>
		/// <param name="dir">Destination directory</param>
		/// <param name="worker">To report progress</param>
		private static void DownloadPictures(FriendList friends, string dir, BackgroundWorker worker = null) {
			int i = 0;
			foreach(Friend f in friends) {
                if (worker != null && worker.CancellationPending) {
                    throw new InterruptedException();
                }

				if(File.Exists(dir + "/" + f.id + ".jpg")) {
					if(worker != null)
						worker.ReportProgress((++i * 100) / friends.Count, i);

					continue;
				}

				string url = FBPictureAPI.GetData(f.id + "?fields=picture").SelectToken("picture")
																	   .SelectToken("data")
																	   .SelectToken("url")
																	   .ToString();
				DownloadFile(url, dir + "/" + f.id + ".jpg");

                if (worker != null) {
                    worker.ReportProgress((++i * 100) / friends.Count, i);
                }
			}

            // my photo

            string myUrl = FBPictureAPI.GetData(Config.USER_ID + "?fields=picture").SelectToken("picture")
                                                                   .SelectToken("data")
                                                                   .SelectToken("url")
                                                                   .ToString();
            DownloadFile(myUrl, dir + "/" + Config.USER_ID + ".jpg");

            if (worker != null) {
                worker.ReportProgress((++i * 100) / friends.Count, i);
            }
		}
        

		/// <summary>
		/// Downloads a file over HTTP and saves into a destination path
		/// </summary>
		/// <param name="url">URL address of the file</param>
		/// <param name="destination">Destination path</param>
		private static void DownloadFile(string url, string destination) {
			HttpWebRequest httpRequest = (HttpWebRequest) WebRequest.Create(url);

			HttpWebResponse httpResponse = (HttpWebResponse) httpRequest.GetResponse();
			Stream httpResponseStream = httpResponse.GetResponseStream();

			int bufferSize = 1024;
			byte[] buffer = new byte[bufferSize];
			int bytesRead = 0;

			using(FileStream fileStream = File.Create(destination)) {
				while((bytesRead = httpResponseStream.Read(buffer, 0, bufferSize)) != 0) {
					fileStream.Write(buffer, 0, bytesRead);
				}
			}
		}
	}
}

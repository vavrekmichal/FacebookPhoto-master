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
		public static void GenerateGraph(BackgroundWorker worker = null) {

			// load friendlist of our user
			FriendList friends = FBPictureAPI.GetData<FriendList>(Config.USER_ID + "/friends");

			// report that loading was fine
			worker.ReportProgress(0, friends.Count);

			// make sure the report made it through and updated GUI
			// this is necessary because the 
			System.Threading.Thread.Yield();
			

			// create destination directories
			if(!File.Exists("cache")) {
				System.IO.Directory.CreateDirectory("cache");
			}

			string dir = "cache/" + Config.USER_ID;

			if(!File.Exists(dir)) {
				System.IO.Directory.CreateDirectory(dir);
			}

			if(!File.Exists(dir + "/photos")) {
				System.IO.Directory.CreateDirectory(dir + "/photos");
			}

			// load all mutual friends and the whole graph
			//Graph graph = new Graph(); //MVA
            Picture picture = new Picture();
            

			// if we had loaded the friend information earlier we dont need to redownload it
			//if(File.Exists(dir + "/data.json")) {
			//	graph.LoadConnections(dir + "/data.json", worker);
                
			//} else {
			//graph.LoadConnections(friends, worker);
            picture.LoadConnections(friends, worker);
				//graph.SaveConnections(dir + "/data.json");
			//}

			// download profile pictures of the users
			DownloadPictures(friends, dir + "/photos", worker);

			// now we generate the graph (vertices positions)
			// gets map of type: Person -> (x,y)
            
            picture.CalcutePicture(dir, friends, worker);
            //picture.save();
			//graph.Calculate(worker);

			// and we draw it to a file
            Bitmap bmp = picture.GetPicture(worker);
             //   DrawGraph(graph.Data, dir, worker);
			bmp.Save(dir + "/picture.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
			bmp.Dispose();

			worker.ReportProgress(100, dir + "/graph.jpg");
		}



		/*/// <summary>
		/// Draws a graph of friends into a Bitmap
		/// </summary>
		/// <param name="graph">Friend connection graf</param>
		/// <param name="srcDir">Where to take user profile picture thumbnails from</param>
		/// <param name="settings">Settings - when left blank, default settings are used</param>
		/// <param name="worker">To report the progress</param>
		/// <returns>Bitmap with the graph</returns>
		private static Bitmap DrawGraph(FriendGraph graph, string imageDir, BackgroundWorker worker = null) {

			Bitmap bmp = new Bitmap(GraphSettings.ImageWidth, GraphSettings.ImageHeight);
			Graphics g = Graphics.FromImage(bmp);

			g.Clear(Color.White);
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

			// if we have the autosize option on, we find the maximum number of friends
			int maxFriends = 0;

			// we draw lines connecting friends
			int i = 0;
			List<Friend> done = new List<Friend>(); // so we dont draw lines both ways
			foreach(KeyValuePair<Friend, List<Friend>> pair in graph) {
				if(worker != null && worker.CancellationPending)
					throw new InterruptedException();

				Pen pen = new Pen(Color.FromArgb(64, 0, 0, 0), 1);

				foreach(Friend f in pair.Value) {
					if(!done.Contains(f))
						g.DrawLine(pen, pair.Key.coordinates, f.coordinates);
				}

				if(pair.Value.Count > maxFriends)
					maxFriends = pair.Value.Count;

				pen.Dispose();

				done.Add(pair.Key);

				if(worker != null)
					worker.ReportProgress(Math.Min(99, ++i * 50 / graph.Count));
			}

			int photoSize = GraphSettings.PhotoSize;

			// if we have the autosize option on, we would like bigger pictures be on top of smaller
			// we sort them by their friend count asc
			if(GraphSettings.AutoSize) {
				done.Sort((x, y) =>
				{
					if(graph[x].Count < graph[y].Count)
						return -1;
					else if(graph[y].Count < graph[x].Count)
						return 1;

					return 0;
				});
			}

			// we draw profile photos inside
			foreach(Friend f in done) {
				if(worker != null && worker.CancellationPending)
					throw new InterruptedException();

				Image photo = Image.FromFile(imageDir + "/photos/" + f.id + ".jpg");

				if(GraphSettings.AutoSize) {
					photoSize = (int) (15 + 35 * ((float) graph[f].Count / (float) maxFriends));
				}

				if(GraphSettings.PhotoShape == Shape.Circle) { // we must crop circle out of the profile picture

					// we create brush
					TextureBrush brush = new TextureBrush(photo, WrapMode.Clamp);

					// resize the brush
					brush.ScaleTransform(((float) photoSize) / 50f,
										 ((float) photoSize) / 50f,
										 MatrixOrder.Append);

					// we reset the brush starting position
					brush.TranslateTransform(f.coordinates.X - photoSize / 2,
											 f.coordinates.Y - photoSize / 2, MatrixOrder.Append);

					// and fill a circle with it
					g.FillEllipse(brush,
								  f.coordinates.X - photoSize / 2,
								  f.coordinates.Y - photoSize / 2,
								  photoSize,
								  photoSize);

					brush.Dispose();

				} else { // square - just draw the image
					g.DrawImage(photo,
								f.coordinates.X - photoSize / 2,
								f.coordinates.Y - photoSize / 2,
								photoSize,
								photoSize);
				}

				photo.Dispose();

				if(worker != null)
					worker.ReportProgress(Math.Min(99, ++i * 50 / graph.Count));
			}

			g.Dispose();

			return bmp;
		}
        */

		/// <summary>
		/// Download profile pictures of the users
		/// </summary>
		/// <param name="friends">Friend list</param>
		/// <param name="dir">Destination directory</param>
		/// <param name="worker">To report progress</param>
		private static void DownloadPictures(FriendList friends, string dir, BackgroundWorker worker = null) {
			int i = 0;
			foreach(Friend f in friends) {
				if(worker != null && worker.CancellationPending)
					throw new InterruptedException();

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

				if(worker != null)
					worker.ReportProgress((++i * 100) / friends.Count, i);
			}

            // my photo

            string myUrl = FBPictureAPI.GetData(Config.USER_ID + "?fields=picture").SelectToken("picture")
                                                                   .SelectToken("data")
                                                                   .SelectToken("url")
                                                                   .ToString();
            DownloadFile(myUrl, dir + "/" + Config.USER_ID + ".jpg");

            if (worker != null)
                worker.ReportProgress((++i * 100) / friends.Count, i);
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

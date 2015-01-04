using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;

namespace FacebookPicture {
    class Picture {

        private Dictionary<Friend, List<Friend>> data;
        private Dictionary<string, Friend> friends;

        private IPalette palette;
        private Bitmap result;

        public Picture(IPalette palette) {
            this.palette = palette;
        }


        /// <summary>
        /// Loads all mutual friends of all friends and saves them into a graph
        /// </summary>
        public void LoadConnections(FriendList fl, BackgroundWorker worker = null) {
            data = new Dictionary<Friend, List<Friend>>();
            friends = new Dictionary<string, Friend>();

            // creates id->friend addresser
            foreach (Friend f in fl) {
                friends.Add(f.id, f);
                data.Add(f, new List<Friend>());
            }

            // downloades mutual friends of every friend in the list
            int i = 0;
            foreach (KeyValuePair<string, Friend> pair in friends) {
                if (worker != null && worker.CancellationPending)
                    throw new InterruptedException();

                FriendList mutualFriends = FBPictureAPI.GetData<FriendList>(pair.Key + "/mutualfriends");

                foreach (Friend f in mutualFriends) {
                    if (!data[pair.Value].Contains(f))
                        data[pair.Value].Add(f);
                }

                // reporting progress
                if (worker != null) {
                    worker.ReportProgress((++i * 100) / friends.Count, i);
                }
            }
        }


        public void CalcutePicture(Bitmap procesingPicture, BackgroundWorker worker = null) {

            if (worker != null) {
                worker.ReportProgress(1);
            }

            result = new Bitmap(procesingPicture.Width * EngineSettings.PhotoSize, procesingPicture.Height * EngineSettings.PhotoSize);
            Graphics g = Graphics.FromImage(result);
            //g.DrawImage(

            int pixelCount = procesingPicture.Width * procesingPicture.Height;
            int counted = 0;

            for (int i = 0; i < procesingPicture.Width; i++) {
                for (int j = 0; j < procesingPicture.Height; j++) {

                    Color pixel = procesingPicture.GetPixel(i, j);

                    Image img = palette.GetPuzzle(pixel);
                    g.DrawImage(img, new Point(i * EngineSettings.PhotoSize, j * EngineSettings.PhotoSize));
                    worker.ReportProgress(++counted * 100/ pixelCount);
                }
            }
            g.Dispose();

            // reporting success
            if (worker != null) {
                worker.ReportProgress(100);
            }
        }

        public Bitmap GetPicture(BackgroundWorker worker = null) {

            return result;
        }
    }
}

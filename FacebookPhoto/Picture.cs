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

        private Pallete pallete;
        private Bitmap result;

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
                if (worker != null)
                    worker.ReportProgress((++i * 100) / friends.Count, i);
            }
        }


        public void CalcutePicture(string dir, FriendList list, BackgroundWorker worker = null) {

            pallete = new Pallete();
            //Bitmap.From
            Bitmap photo = new Bitmap(dir + "/photos/" + Config.USER_ID + ".jpg");
            pallete.LoadPallete(dir, list);

            result = photo;

            // reporting success
            if (worker != null) {
                worker.ReportProgress(100);
            }
        }

        public Bitmap GetPicture(BackgroundWorker worker = null) {
            if (worker != null) {
                worker.ReportProgress(100);
            }
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace FacebookPicture {
    class Pallete {

        private Dictionary<int, Queue<Image>> palleteSet = new Dictionary<int, Queue<Image>>();

        public Image LoadFriendPicture(Bitmap img) {
            int rgb;
            long rgbCount = 0;
            int pixelCount = img.Width * img.Height;

            Bitmap bwImg = new Bitmap(img);
            for (int i = 0; i < img.Width; i++) {
                for (int j = 0; j < img.Height; j++) {
                   
                    Color pixel = img.GetPixel(i, j);

                    rgb = (int)((pixel.R + pixel.G + pixel.B) / 3);
                    rgbCount += rgb;
                    bwImg.SetPixel(i, j, Color.FromArgb(rgb, rgb, rgb));
                }
            }
            int dived = (int)rgbCount / pixelCount;
            if (!palleteSet.ContainsKey(dived)) {
                palleteSet.Add(dived, new Queue<Image>());
            }
            palleteSet[dived].Enqueue(bwImg);
            return bwImg;
            
        }

        public void LoadPallete(string dir, FriendList list) {
            if (!File.Exists(dir + "/photos/blackwhite")) {
                System.IO.Directory.CreateDirectory(dir + "/photos/blackwhite");
            }
            foreach(Friend friend in list){
                Bitmap photo = new Bitmap(dir + "/photos/" + friend.id + ".jpg");
                LoadFriendPicture(photo).Save(dir + "/photos/blackwhite/" + friend.id + ".jpg", ImageFormat.Jpeg);
            }           
        }

        public void GetPuzzle(Color pixelColor) { //neni void
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace FacebookPicture {
    class Palette {

        private Dictionary<int, Queue<string>> palleteSet = new Dictionary<int, Queue<string>>();

        public Palette(string dir, FriendList list, BackgroundWorker worker) {
            int i = 0;
            foreach (Friend friend in list) {
                if (worker != null && worker.CancellationPending) {
                    throw new InterruptedException();
                }
                LoadFriendPicture(dir + "/photos/" + friend.id);
                worker.ReportProgress((++i * 100) / list.Count, i);
            }
            // reporting success
            if (worker != null) {
                worker.ReportProgress(100);
            }
        }

        public Image LoadFriendPicture(string imgName) {
            int rgb;
            long rgbCount = 0;
            var img = new Bitmap(imgName + ".jpg");
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
                palleteSet.Add(dived, new Queue<string>());
            }
            bwImg.Save(imgName + "bw.jpg", ImageFormat.Jpeg);
            palleteSet[dived].Enqueue(imgName + "bw.jpg");
            return bwImg;

        }

        public Image GetPuzzle(int pixelColor) { //neni void
            if (palleteSet.ContainsKey(pixelColor)) {
                string temp = palleteSet[pixelColor].Dequeue();
                palleteSet[pixelColor].Enqueue(temp);
                return new Bitmap(temp);
            } else {
                if (palleteSet.ContainsKey(pixelColor - 1)) {
                    string temp = palleteSet[pixelColor - 1].Dequeue();
                    palleteSet[pixelColor - 1].Enqueue(temp);
                    return new Bitmap(temp);
                }
                if (palleteSet.ContainsKey(pixelColor + 1)) {
                    string temp = palleteSet[pixelColor + 1].Dequeue();
                    palleteSet[pixelColor + 1].Enqueue(temp);
                    return new Bitmap(temp);
                }
                Bitmap img = new Bitmap(EngineSettings.PhotoSize, EngineSettings.PhotoSize);

                for (int i = 0; i < EngineSettings.PhotoSize; i++) {
                    for (int j = 0; j < EngineSettings.PhotoSize; j++) {


                        img.SetPixel(i, j, Color.FromArgb(pixelColor, pixelColor, pixelColor));
                    }
                }
                return img;
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;

namespace FacebookPicture {
    class Palette0Round : IBlackWhitePalette {

        public Palette0Round(string dir, FriendList list, BackgroundWorker worker) {
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


        public override Image GetPuzzle(Bitmap image) { //neni void
            Color color = TransformImageToColor(image);
            int pixelColor = (int)((color.R + color.G + color.B) / 3);
            if (palleteSet.ContainsKey(pixelColor)) {
                string temp = palleteSet[pixelColor].Dequeue();
                palleteSet[pixelColor].Enqueue(temp);
                return new Bitmap(temp);
            } else {
                
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

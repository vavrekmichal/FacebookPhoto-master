using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace FacebookPicture {
    abstract class IBlackWhitePalette : IPalette{
        public abstract Image GetPuzzle(Bitmap image);

        protected Dictionary<int, Queue<string>> palleteSet = new Dictionary<int, Queue<string>>();

        protected Color TransformImageToColor(Bitmap img) {
            long rCount = 0;
            long gCount = 0;
            long bCount = 0;

            int pixelCount = img.Width * img.Height;

            for (int i = 0; i < img.Width; i++) {
                for (int j = 0; j < img.Height; j++) {

                    Color pixel = img.GetPixel(i, j);

                    rCount += pixel.R;
                    gCount += pixel.G;
                    bCount += pixel.B;
                }
            }
            int divedR = (int)rCount / pixelCount;
            int divedG = (int)gCount / pixelCount;
            int divedB = (int)bCount / pixelCount;

            Color c = Color.FromArgb(divedR,divedG, divedB);
            
            return c;
        }

        public void LoadFriendPicture(string imgName) {
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
            try {
                bwImg.Save(imgName + "bw.jpg", ImageFormat.Jpeg);
            } catch { } // could be locked by app
            palleteSet[dived].Enqueue(imgName + "bw.jpg");
        }
    }
}

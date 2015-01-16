using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;

namespace FacebookPicture {
    class PaletteRGB : IPalette {
        protected Dictionary<Tuple<int, int, int>, Queue<string>> palleteSet = new Dictionary<Tuple<int, int, int>, Queue<string>>();


        public PaletteRGB(string dir, FriendList list, BackgroundWorker worker) {
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

        public void LoadFriendPicture(string imgName) {

            long rCount = 0;
            long gCount = 0;
            long bCount = 0;

            var img = new Bitmap(imgName + ".jpg");
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
            if (!palleteSet.ContainsKey(Tuple.Create<int, int, int>(divedR, divedG, divedB))) {
                palleteSet.Add(Tuple.Create<int, int, int>(divedR, divedG, divedB), new Queue<string>());
            }

            palleteSet[Tuple.Create<int, int, int>(divedR, divedG, divedB)].Enqueue(imgName + ".jpg");
        }

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

            Color c = Color.FromArgb(divedR, divedG, divedB);

            return c;
        }

        public Image GetPuzzle(Bitmap image) { //neni void
            Color color = TransformImageToColor(image);
            Tuple<int, int, int> pixelColor = Tuple.Create<int, int, int>(color.R, color.G, color.B);

            Tuple<int, int, int> nearest_color = Tuple.Create<int, int, int>(0, 0, 0);
            double distance = Double.MaxValue;
            foreach (Tuple<int, int, int> o in palleteSet.Keys) {
                // compute the Euclidean distance between the two colors
                // note, that the alpha-component is not used in this example
                double dbl_test_red = Math.Pow(Convert.ToDouble(o.Item1) - color.R, 2.0);
                double dbl_test_green = Math.Pow(Convert.ToDouble(o.Item2) - color.G, 2.0);
                double dbl_test_blue = Math.Pow(Convert.ToDouble(o.Item3) - color.B, 2.0);

                double temp = Math.Sqrt(dbl_test_blue + dbl_test_green + dbl_test_red);
                // explore the result and store the nearest color
                if (temp == 0.0) {
                    nearest_color = o;
                    break;
                } else if (temp < distance) {
                    distance = temp;
                    nearest_color = o;
                }
            }
            string tempName = palleteSet[nearest_color].Dequeue();
            palleteSet[nearest_color].Enqueue(tempName);
            return new Bitmap(tempName);

        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;

namespace FacebookPicture {
    class PixelPicture : IPicture {

        private IPalette palette;
        private Bitmap result;

        public PixelPicture(IPalette palette) {
            this.palette = palette;
        }

        public void CalcutePicture(Bitmap procesingPicture, BackgroundWorker worker = null) {

            if (worker != null) {
                worker.ReportProgress(1);
            }

            result = new Bitmap(procesingPicture.Width * EngineSettings.PhotoSize, procesingPicture.Height * EngineSettings.PhotoSize);
            Graphics g = Graphics.FromImage(result);

            int pixelCount = procesingPicture.Width * procesingPicture.Height;
            int counted = 0;

            for (int i = 0; i < procesingPicture.Width; i++) {
                for (int j = 0; j < procesingPicture.Height; j++) {

                    Color pixel = procesingPicture.GetPixel(i, j);
                    Bitmap bm = new Bitmap(1, 1);
                    bm.SetPixel(0, 0, pixel);
                    Image img = palette.GetPuzzle(bm);
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

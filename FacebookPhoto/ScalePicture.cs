using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace FacebookPicture {
    class ScalePicture : IPicture {

        private IPalette palette;
        private Bitmap result;

        public ScalePicture(IPalette palette) {
            this.palette = palette;
        }

        public void CalcutePicture(Bitmap procesingPicture, BackgroundWorker worker = null) {

            if (worker != null) {
                worker.ReportProgress(1);
            }

            result = new Bitmap(procesingPicture.Width , procesingPicture.Height );
            Graphics gr = Graphics.FromImage(result);

            // rubish
            //int parts = procesingPicture.Width % EngineSettings.PixelPrecision

            bool perfectWidth = procesingPicture.Width % EngineSettings.PixelPrecision == 0;
            bool perfectHeight = procesingPicture.Height % EngineSettings.PixelPrecision == 0;

            int lastWidth = EngineSettings.PixelPrecision;
            if (!perfectWidth) {
                lastWidth = procesingPicture.Width - ((procesingPicture.Width / EngineSettings.PixelPrecision) * EngineSettings.PixelPrecision);
            }

            int lastHeight = EngineSettings.PixelPrecision;
            if (!perfectHeight) {
                lastHeight = procesingPicture.Height - ((procesingPicture.Height / EngineSettings.PixelPrecision) * EngineSettings.PixelPrecision);
            }

            int widthPartsCount = procesingPicture.Width / EngineSettings.PixelPrecision + (perfectWidth ? 0 : 1);
            int heightPartsCount = procesingPicture.Height / EngineSettings.PixelPrecision + (perfectHeight ? 0 : 1);

            int pixelCount = heightPartsCount * widthPartsCount;
            int counted = 0;

            for (int i = 0; i < widthPartsCount; i++) {
                for (int j = 0; j < heightPartsCount; j++) {
                    int tileWidth = i == widthPartsCount - 1 ? lastWidth : EngineSettings.PixelPrecision;
                    int tileHeight = j == heightPartsCount - 1 ? lastHeight : EngineSettings.PixelPrecision;
                    using (Bitmap tile = new Bitmap(tileWidth, tileHeight)) {
                        using (Graphics g = Graphics.FromImage(tile)) {
                            g.DrawImage(procesingPicture, new Rectangle(0, 0, tile.Width, tile.Height),
                                new Rectangle(i * EngineSettings.PixelPrecision, j * EngineSettings.PixelPrecision, tile.Width, tile.Height), GraphicsUnit.Pixel);
                        }

                        // here is picture ready for palette 
                        //tile.Save(string.Format("temp/{0}-{1}.png", i + 1, j + 1), ImageFormat.Png);
                        Image img = new Bitmap( palette.GetPuzzle(tile), EngineSettings.PixelPrecision,EngineSettings.PixelPrecision);
                        gr.DrawImage(img, new Point(i * EngineSettings.PixelPrecision, j * EngineSettings.PixelPrecision));
                        worker.ReportProgress(++counted * 100 / pixelCount);
                    }
                }
            }

            gr.Dispose();
            //rubish
            // do some image oriented read of picture
            /* for (int i = 0; i < procesingPicture.Width; i++) {
                 for (int j = 0; j < procesingPicture.Height; j++) {

                     Color pixel = procesingPicture.GetPixel(i, j);
                     Bitmap bm = new Bitmap(1, 1);
                     bm.SetPixel(0, 0, pixel);
                     Image img = palette.GetPuzzle(bm);
                     g.DrawImage(img, new Point(i * EngineSettings.PhotoSize, j * EngineSettings.PhotoSize));
                     worker.ReportProgress(++counted * 100 / pixelCount);
                 }
             }*/

            //g.Dispose();

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

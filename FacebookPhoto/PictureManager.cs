using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace FacebookPicture {
    class PictureManager {
        private static int pictureID = 0;

        public static int PictureID {
            set {
                pictureID = value;
            }
        }

        public static IPicture GetPicture(string dir, FriendList friends, BackgroundWorker worker) {
            IPalette palette = PaletteManager.GetPalette(dir, friends, worker);
            IPicture p;
            switch (pictureID) {
                case 0:
                    p = new PixelPicture(palette);
                    break;
                default:
                    p = new ScalePicture(palette);
                    break;
            }
            return p;
        }
    }
}

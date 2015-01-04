using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace FacebookPicture {
    public static class PaletteManager {
        private static int paletteID = 0;


        public static int PaletteID {
            set {
                paletteID = value;
            }
        }

        public static Palette GetPalette(string dir, FriendList friends, BackgroundWorker worker) {
            Palette p;
            switch (paletteID) {
                case 0: 
                    p = new Palette(dir, friends, worker);
                    break;
                default:
                    p = new Palette(dir, friends, worker);
                    break;
            }
            return p;
        }
    }
}

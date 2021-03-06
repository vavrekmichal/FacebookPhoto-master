﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace FacebookPicture {
    static class PaletteManager {
        private static int paletteID = 0;


        public static int PaletteID {
            set {
                paletteID = value;
            }
        }

        public static IPalette GetPalette(string dir, FriendList friends, BackgroundWorker worker) {
            IPalette p;
            switch (paletteID) {
                case 0: 
                    p = new Palette(dir, friends, worker);
                    break;
                case 1:
                    p = new Palette0Round(dir, friends, worker);
                    break;
                case 2:
                    p = new Palette2Round(dir, friends, worker);
                    break;
                case 3:
                    p = new PaletteRGB(dir, friends, worker);
                    break;
                case 4:
                    p = new EHDPalette(dir, friends, worker);
                    break;
                case 5:
                    p = new SCDPalette(dir, friends, worker);
                    break;
                case 6:
                    p = new CLDPalette(dir, friends, worker);
                    break;
                case 7:
                    p = new DCDPalette(dir, friends, worker);
                    break;
                case 8:
                    p = new CEDDPalette(dir, friends, worker);
                    break;
                default:
                    p = new Palette(dir, friends, worker);
                    break;
            }
            return p;
        }
    }
}

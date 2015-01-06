﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace FacebookPicture {
    interface IPalette {
        void LoadFriendPicture(string imgName);
        Image GetPuzzle(Color pixelColor);
    }
}

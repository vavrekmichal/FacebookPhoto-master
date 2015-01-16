using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace FacebookPicture {
    interface IPalette {
        Image GetPuzzle(Bitmap image);
    }
}

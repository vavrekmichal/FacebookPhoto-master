using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;

namespace FacebookPicture {
    interface IPicture {
        void CalcutePicture(Bitmap procesingPicture, BackgroundWorker worker = null);
        Bitmap GetPicture(BackgroundWorker worker = null);
    }
}

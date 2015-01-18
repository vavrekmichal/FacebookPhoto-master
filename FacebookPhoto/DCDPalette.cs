using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security;
using System.Text;

namespace FacebookPicture {
    class DCDPalette : IPalette {

        Dictionary<int, Queue<String>> palette = new Dictionary<int, Queue<String>>();

        public DCDPalette(string dir, FriendList list, BackgroundWorker worker) {

            int i = 0;
            foreach (Friend friend in list) {
                if (worker != null && worker.CancellationPending) {
                    throw new InterruptedException();
                }
                DCD_Descriptor dcd = new DCD_Descriptor();
                var img = new Bitmap(dir + "/photos/" + friend.id + EngineSettings.TileSuffix);
                int descriptor = DosecurityCritical(dcd, img);

                if (descriptor != -1) {
                    if (!palette.ContainsKey(descriptor)) {
                        palette.Add(descriptor, new Queue<String>());
                    }
                    palette[descriptor].Enqueue(dir + "/photos/" + friend.id + ".jpg");
                }
                worker.ReportProgress((++i * 100) / list.Count, i);

            }
            // reporting success
            if (worker != null) {
                worker.ReportProgress(100);
            }
        }

        [HandleProcessCorruptedStateExceptions]
        [SecurityCritical]
        private int DosecurityCritical(DCD_Descriptor dcd, Bitmap img) {
            try {
                dcd.extractDescriptor(img);
                int result = dcd.DominantSize;
                return result;
            } catch (Exception) {
                return -1;
            }
        }

        private int GetNearestDescriptor(int descriptor) {
            double distance = Double.MaxValue;

            int nearest = 0;
            foreach (int desc in palette.Keys) {
                double temp = 0.0;

                temp = Math.Abs(desc - descriptor);

                if (temp == 0.0) {
                    nearest = desc;
                    break;
                } else if (temp < distance) {
                    distance = temp;
                    nearest = desc;
                } 
            }
            return nearest;
        }

        public System.Drawing.Image GetPuzzle(System.Drawing.Bitmap image) {
            DCD_Descriptor dcd = new DCD_Descriptor();

            int descriptor = DosecurityCritical(dcd, image);

            //throw new NotImplementedException();
            int nearest = GetNearestDescriptor(descriptor);
            
            string tempName = palette[nearest].Dequeue();
            palette[nearest].Enqueue(tempName);
            return new Bitmap(tempName);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security;
using System.Text;

namespace FacebookPicture {
    class CLDPalette : IPalette {

        Dictionary<int[], Queue<String>> palette = new Dictionary<int[], Queue<String>>();


        public CLDPalette(string dir, FriendList list, BackgroundWorker worker) {

            int i = 0;
            foreach (Friend friend in list) {
                if (worker != null && worker.CancellationPending) {
                    throw new InterruptedException();
                }
                CLD_Descriptor cld = new CLD_Descriptor();

                var img = new Bitmap(dir + "/photos/" + friend.id + EngineSettings.TileSuffix);
                int[] descriptor = null;


                descriptor = DosecurityCritical(cld, img);

                if (descriptor != null) {
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
        private int [] DosecurityCritical(CLD_Descriptor cld, Bitmap img) {
            try {
                cld.Apply(img);
                int[] Y = new int[64];
                Y = cld.YCoeff;

                int[] CB = new int[64];
                CB = cld.CbCoeff;

                int[] CR = new int[64];
                CR = cld.CrCoeff;

                int [] result =  new int[Y.Length + CB.Length + CR.Length];
                Y.CopyTo(result, 0);
                CB.CopyTo(result, Y.Length);
                CR.CopyTo(result, Y.Length + CB.Length);
                return result;
            } catch (Exception) {
                return null;
            }
        }

        public System.Drawing.Image GetPuzzle(System.Drawing.Bitmap image) {
            CLD_Descriptor cld = new CLD_Descriptor();

            int[] descriptor = DosecurityCritical(cld, image);
            // if descrpitor is null?
            double distance = Double.MaxValue;
            //throw new NotImplementedException();
            int[] nearest = new int[0];
            foreach (int[] desc in palette.Keys) {
                double temp = 0.0;
                double dot = 0.0d;
                double mag1 = 0.0d;
                double mag2 = 0.0d;
                // cosine distance
                for (int n = 0; n < desc.Count(); n++) {
                    dot += desc[n] * descriptor[n];
                    mag1 += Math.Pow(desc[n], 2);
                    mag2 += Math.Pow(descriptor[n], 2);
                }

                temp = dot / (Math.Sqrt(mag1) * Math.Sqrt(mag2));

                if (temp == 0.0) {
                    nearest = desc;
                    break;
                } else if (temp < distance) {
                    distance = temp;
                    nearest = desc;
                } else if (Double.NaN.Equals(temp)) {
                    nearest = desc;
                    break;
                }
            }
            string tempName = palette[nearest].Dequeue();
            palette[nearest].Enqueue(tempName);
            return new Bitmap(tempName);
        }
    }
}

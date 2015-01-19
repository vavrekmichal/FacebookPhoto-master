using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security;
using System.Text;

namespace FacebookPicture {
    class CEDDPalette :IPalette{

        Dictionary<double[], Queue<String>> palette = new Dictionary<double[], Queue<String>>();

        public CEDDPalette(string dir, FriendList list, BackgroundWorker worker) {

            int i = 0;
            foreach (Friend friend in list) {
                if (worker != null && worker.CancellationPending) {
                    throw new InterruptedException();
                }
                SimpleRnd.CEDD cedd = new SimpleRnd.CEDD();

                var img = new Bitmap(dir + "/photos/" + friend.id + EngineSettings.TileSuffix);

                double[] descriptor = DosecurityCritical(cedd, img);

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
        private double[] DosecurityCritical(SimpleRnd.CEDD cedd, Bitmap img) {
            try {
               // List<double[]> temp = locate.extract(img,600);
                double [] temp = cedd.Apply(img);
                return temp;
            } catch (Exception) {
                return null;
            }
        }

        private double[] GetNearestDescriptor(double[] descriptor) {
            double distance = Double.MaxValue;

            double[] nearest = null;
            foreach (double[] desc in palette.Keys) {
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

                temp =1.0 - ( dot / (Math.Sqrt(mag1) * Math.Sqrt(mag2)));

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
            return nearest;
        }

        public System.Drawing.Image GetPuzzle(System.Drawing.Bitmap image) {
            SimpleRnd.CEDD cedd = new SimpleRnd.CEDD();

            double[] descriptor = DosecurityCritical(cedd, image);

            double[] nearest = GetNearestDescriptor(descriptor);
            
            string tempName = palette[nearest].Dequeue();
            palette[nearest].Enqueue(tempName);
            return new Bitmap(tempName);
        }
    }
}

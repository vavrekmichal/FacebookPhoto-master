using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security;
using System.Text;

namespace FacebookPicture {
    class SCDPalette : IPalette {

        Dictionary<double[], Queue<String>> palette = new Dictionary<double[], Queue<String>>();

        public SCDPalette(string dir, FriendList list, BackgroundWorker worker) {

            int i = 0;
            foreach (Friend friend in list) {
                if (worker != null && worker.CancellationPending) {
                    throw new InterruptedException();
                }
                SCD_Descriptor scd = new SCD_Descriptor();
                var img = new Bitmap(dir + "/photos/" + friend.id + EngineSettings.TileSuffix);


                double[] descriptor = DosecurityCritical(scd, img);

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
        private double[] DosecurityCritical(SCD_Descriptor scd, Bitmap img) {
            try {
                int ix = EngineSettings.SCDCoeficients;
                int jx = EngineSettings.SCDBitplan;
                scd.Apply(img, ix, jx);
                double[] result = new double[ix];
                result = scd.Norm4BitHistogram;
                return result;
            } catch (Exception) {
                return null;
            }
        }

        public System.Drawing.Image GetPuzzle(System.Drawing.Bitmap image) {
            SCD_Descriptor scd = new SCD_Descriptor();

            int ix = 256;
            int jx = 0;
            scd.Apply(image, ix, jx);
            double[] descriptor = scd.Norm4BitHistogram;

            double distance = Double.MaxValue;
            //throw new NotImplementedException();
            double[] nearest = new double[0];
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

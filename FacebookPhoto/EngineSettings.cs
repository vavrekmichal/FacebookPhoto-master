using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacebookPicture {
	public enum Shape {
		Square,
		Circle
	}

	/// <summary>
	/// Representation of a final graph render configuration.
	/// Contains default settings + watches for limits when setting new values.
	/// </summary>
	public static class EngineSettings {
		// default setting values:
		private static int _imageWidth = 3072;
		private static int _imageHeight = 3072;
		private static int _photoSize = 50;
        private static int _pixelPrecision = 5;

        // tile size
        private static string tileSuffix = "Large.jpg";
        
        // EDH
        private static int ehdTreshold = 11;
        
        // SCD
        private static int scdCoeficients = 256;
        private static int scdBitplan = 0;

        public  static string TileSuffix {
            get { return tileSuffix; }
            set {
                if (value == "Large.jpg" || value == ".jpg") {
                    tileSuffix = value;
                } else {
                    tileSuffix = "Large.jpg";
                }
            }
        }


        public static int SCDCoeficients {
            get { return scdCoeficients; }
            set {
                if (value < 1) {
                    value = 1;
                }
                if (value > 512) {
                    value = 512;
                }
                scdCoeficients = value;
            }
        }

        public static int SCDBitplan {
            get { return scdBitplan; }
            set {
                if (value < 0) {
                    value = 0;
                }
                if (value > 30) {
                    value = 30;
                }
                scdBitplan = value;
            }
        }

        public static int EHDTreshold {
            get { return ehdTreshold; }
            set {
                if (value < 1) {
                    value = 1;
                }
                if (value > 50) {
                    value = 50;
                }
                ehdTreshold = value;
            }
        }

        public static int PixelPrecision {
            get {
                return _pixelPrecision;
            }
            set {
                if(value<5){
                    value = 5;
                }
                if (value > 50) {
                    value = 50;
                }
                _pixelPrecision = value;
            }
        }

		/// <summary>
		/// Final image width in pixels.
		/// </summary>
		public static int ImageWidth {
			get {
				return _imageWidth;
			}

			set {
                if (value < 512) {
                    value = 512;
                }

                if (value > 4096) {
                    value = 4096;
                }
				_imageWidth = value;
			}
		}

		/// <summary>
		/// Final image height in pixels.
		/// </summary>
		public static int ImageHeight {
			get {
				return _imageHeight;
			}

			set {
				if(value < 512)
					value = 512;

				if(value > 4096)
					value = 4096;

				_imageHeight = value;
			}
		}

		/// <summary>
		/// Size of the profile pictures in pixels.
		/// </summary>
		public static int PhotoSize {
			get {
				return _photoSize;
			}
		}

	}
}

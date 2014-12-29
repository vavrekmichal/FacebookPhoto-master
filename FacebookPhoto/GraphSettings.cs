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
	public static class GraphSettings {
		// default setting values:
		private static int _imageWidth = 3072;
		private static int _imageHeight = 3072;
		private static int _photoSize = 30;
		private static int _quality = 12;
		private static bool _autosize = false;


		/// <summary>
		/// Final image width in pixels.
		/// </summary>
		public static int ImageWidth {
			get {
				return _imageWidth;
			}

			set {
				if(value < 512)
					value = 512;

				if(value > 4096)
					value = 4096;

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

			set {
				if(value < 15)
					value = 15;

				if(value > 50)
					value = 50;

				_photoSize = value;
			}
		}

		/// <summary>
		/// Final image height in pixels.
		/// </summary>
		public static int Quality {
			get {
				return _quality;
			}

			set {
				if(value < 4)
					value = 4;

				if(value > 35)
					value = 35;

				_quality = value;
			}
		}

		/// <summary>
		/// Autosize profile pictures accordingly to the number of their friends?
		/// </summary>
		public static bool AutoSize {
			get {
				return _autosize;
			}

			set {
				_autosize = value;
			}
		}
	}
}

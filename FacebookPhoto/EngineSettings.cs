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
		}

	}
}

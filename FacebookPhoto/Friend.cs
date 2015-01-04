using Newtonsoft.Json;
using System.Drawing;
using System;

namespace FacebookPicture {
	/// <summary>
	/// Representation of a friend + a vertex in a graph.
	/// </summary>
	class Friend {
		// Because the object is created through JSON parser
		// we never assing values into these fields.
		// So we suppress the false warning.
		#pragma warning disable 0649
		public string name;
		public string id;
		#pragma warning restore 0649

		public override string ToString() {
			return id;
		}
	}
}

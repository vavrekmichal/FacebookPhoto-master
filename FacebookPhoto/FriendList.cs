using System.Collections.Generic;
using Newtonsoft.Json;

namespace FacebookPicture {
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	/**
	 * Class reprezenting a list of friends and is a destination of JSON deserialization.
	 * Structure must be the same as in the JSON, so it can be automatically parsed via Json.NET
	 **/
	class FriendList : IEnumerable<Friend> {
		// Because the object is created through JSON parser
		// we never assing values into these fields.
		// So we suppress the false warning.
		#pragma warning disable 0649
		[JsonProperty("data")]
		public IEnumerable<Friend> data;
		#pragma warning restore 0649

		public int Count { get { return ((IList<Friend>) data).Count; } }

		public IEnumerator<Friend> GetEnumerator() {
			return data.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
			return data.GetEnumerator();
		}
	}
}
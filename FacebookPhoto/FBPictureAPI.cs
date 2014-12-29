using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Text;

namespace FacebookPicture {
	class FBAPIException : ApplicationException { }

	// Class that communicates with Facebook Graph API
	// Sends requests, adds access tokens and recieves and parses data
	static class FBPictureAPI {
		/// <summary>
		/// Sends request and parses data into the T format.
		/// </summary>
		/// <typeparam name="T">Destionation class for the data</typeparam>
		/// <param name="query">Facebook Graph API command (URL)</param>
		/// <param name="addToken">Should we add the user access_token to the request?</param>
		/// <returns>Parsed recieved data as a T class.</returns>
		static public T GetData<T>(string query, bool addToken = true) where T : class {
			T result = null;

			try {
				// adding token (check whether the query already contains GET variables)
				if(addToken) {
					if(query.IndexOf('?') != -1) {
						query += "&access_token=" + Config.ACCESS_TOKEN;
					} else {
						query += "?access_token=" + Config.ACCESS_TOKEN;
					}
				}

				// creating the http request
				HttpWebResponse response = (HttpWebResponse) HttpWebRequest.Create(Config.FACEBOOK_GRAPH + query).GetResponse();

				// encoding is always a trouble
				string charSet = response.CharacterSet;
				Encoding encoding;
                if (String.IsNullOrEmpty(charSet)) {
                    encoding = Encoding.Default;
                } else {
                    encoding = Encoding.GetEncoding(charSet);
                }

				var resStream = new StreamReader(response.GetResponseStream(), encoding);

				var settings = new JsonSerializerSettings();
				settings.MissingMemberHandling = MissingMemberHandling.Ignore;

				// we deserialize the object (inside T)
				result = JsonConvert.DeserializeObject<T>(resStream.ReadToEnd(), settings);

			} catch {
				throw new FBAPIException();
			}

			return result;
		}


		/// <summary>
		/// Alias for GetData<T> when no need for a parsing into a specific class.
		/// </summary>
		/// <param name="query">Facebook Graph API command (URL)</param>
		/// <param name="addToken">Should we add the user access_token to the request?</param>
		/// <returns>Parsed recieved data as a object. Can be cast to JObject.</returns>
		static public JObject GetData(string query, bool addToken = true) {
			return FBPictureAPI.GetData<JObject>(query, addToken);
		}
	}
}

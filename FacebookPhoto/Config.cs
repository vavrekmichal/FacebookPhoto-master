namespace FacebookPicture {
	/// <summary>
	/// Holds info about user and makes easy access to defined constants in resources
	/// </summary>
	static class Config {
		// @todo smazat muj token
		static public string ACCESS_TOKEN;
		static public string USER_ID, USER_NAME;

		static public string APP_ID {
			get {
				return FacebookPicture.Properties.Resources.APP_ID;
			}
		}

		static public string APP_SECRET {
			get {
				return FacebookPicture.Properties.Resources.APP_SECRET;
			}
		}

		static public string FACEBOOK_GRAPH {
			get {
				return FacebookPicture.Properties.Resources.FACEBOOK_GRAPH;
			}
		}

		static public string FACEBOOK_LOGIN {
			get {
				return FacebookPicture.Properties.Resources.FACEBOOK_LOGIN;
			}
		}

		static public string REDIRECT_URI {
			get {
				return FacebookPicture.Properties.Resources.REDIRECT_SUCCESS;
			}
		}
	}
}

using System;
using System.Windows.Forms;

namespace FacebookPicture {
	static class Program {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			// first, we show the login dialog
			Application.Run(new LoginForm());

			// if we haven't managed to retrieve the access token (user didnt sing in or didnt allow the app)
			// we have nothing to do
			if(Config.ACCESS_TOKEN == null || Config.ACCESS_TOKEN.Length == 0) {
				return;
			}

			// if we have, we find info about the signed user
			Friend user = null;

			try {
				user = FBPictureAPI.GetData<Friend>("me?fields=id,name");
			} catch(FBAPIException) {
				MessageBox.Show("Couldn't authorize app with your account. Either you didn't log in successfully or you haven't confirmed the app request.");
				return;
			}

			Config.USER_ID = user.id;
			Config.USER_NAME = user.name;
			
			// Firing the main window (with settings)
			Application.Run(new MainForm());
		}
	}
}

using System;
using System.Windows.Forms;

namespace FacebookPicture {
	// This line is a part of workaround that enables us to call our own method from within the webbrowser
	// DocumentCompleted wasn't working fine with FB javascript redirect
	// and after closing the form - a new Internet Explorer window was opened to handle the redirection
	[System.Runtime.InteropServices.ComVisible(true)]
	public partial class LoginForm : Form {
		public LoginForm() {
			InitializeComponent();

			// we get user to the login form
			webBrowser.Navigate(Config.FACEBOOK_LOGIN + "?response_type=token&client_id=" + Config.APP_ID + "&redirect_uri=" + Config.REDIRECT_URI); 
			// after every reload we watch whether the login was successful and we got the token
			// also when there is a login error we have to change the window dimensions so the login form fits
			webBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser_Loaded);
		}

		private void webBrowser_Loaded(object sender, EventArgs e) {
			string url = webBrowser.Url.OriginalString;

			if(webBrowser.DocumentTitle.Equals("Navigation Canceled")) {
				MessageBox.Show("Couldn't contact www.facebook.com. Are you connected to the internet?");
				Close();
				return;
			}

			// are we logged in? == are we on success.html?
			if(url.StartsWith(Config.REDIRECT_URI)) {
				// we take the access token out of the destination URL that we got redirected to
				Config.ACCESS_TOKEN = url.Substring(url.IndexOf('#') + 14, url.IndexOf('&') - url.IndexOf('#') - 14);

				// part of the workaround (see top)
				// my own ".DocumentCompleted/Loaded event"
				webBrowser.ObjectForScripting = this;
				webBrowser.DocumentText = "<html><body onLoad='jscript:window.external.Close();'></body></html>";

				return;
			}

			webBrowser.Visible = true;
			webBrowser.Document.Body.Style = "overflow:hidden";

			// we are at the login page:
			HtmlElement content = webBrowser.Document.GetElementById("login_form");

			// we center the login form to the form and size it accordingly
			if(content != null) {
				// we get login_form position and size and make our window fit just right on it
				int xPos = content.OffsetRectangle.Left;
				int yPos = content.OffsetRectangle.Top;
				HtmlElement tempEl = content.OffsetParent;

				while(tempEl != null) {
					xPos += tempEl.OffsetRectangle.Left;
					yPos += tempEl.OffsetRectangle.Top;
					tempEl = tempEl.OffsetParent;
				}

				webBrowser.Left = - xPos + 38;
				webBrowser.Top = - yPos + 76;

				this.Height = content.ScrollRectangle.Height + 160;
				this.Width = content.ScrollRectangle.Width + 86;
			}


			// we are at the application confirmation screen - we need to adjust the size and page position again
			// same stuff as with the login form
			content = webBrowser.Document.GetElementById("platform_dialog_content");
			if(content != null) {
				int xPos = content.OffsetRectangle.Left;
				int yPos = content.OffsetRectangle.Top;
				HtmlElement tempEl = content.OffsetParent;

				while(tempEl != null) {
					xPos += tempEl.OffsetRectangle.Left;
					yPos += tempEl.OffsetRectangle.Top;
					tempEl = tempEl.OffsetParent;
				}

				webBrowser.Left = - xPos + 20;
				webBrowser.Top = - yPos + 20;

				this.Height = content.ScrollRectangle.Height + 70;
				this.Width = content.ScrollRectangle.Width + 50;
			}			
		}

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
	}
}

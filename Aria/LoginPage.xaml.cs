using System;

using Xamarin.Forms;
using Facebook.ViewModels;

namespace Aria
{
    public partial class LoginPage : ContentPage
    {
		//-------------------Properties-------------------
		//Facebook client ID
		private String ClientID = "261030987696749";

        private FacebookViewModel facebookViewModel = new FacebookViewModel();


		//-------------------Methods-------------------
		public LoginPage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);
        }

		protected override bool OnBackButtonPressed()
		{
            if (fbLoginBtn.IsEnabled)
			{
				return base.OnBackButtonPressed();
			}

			return true;
		}

        public void FacebookLoginBtnClicked(object sender, EventArgs e)
        {
			var apiRequest = "https://www.facebook.com/v2.9/dialog/oauth?client_id=" +
							  ClientID +
							  "&display=popup&response_type=token&redirect_uri=" +
							  "https://www.facebook.com/connect/login_success.html";

			var webView = new WebView
			{
				Source = apiRequest,
				HeightRequest = 1
			};

			webView.Navigated += WebView_Navigated;

			Content = webView;
        }

		private async void WebView_Navigated(object sender, WebNavigatedEventArgs e)
		{

            var accessToken = ExtractAccessTokenFromUrl(e.Url);

            if (accessToken != "")
            {
                App.SetAccessToken(accessToken);
                //await facebookViewModel.SetFacebookProfileAsync(accessToken);

                //Inform app of successful login
				await App.SuccessfulLoginEvent();

			}
		}

        //Extract Facebook Profile Access Token
        private string ExtractAccessTokenFromUrl(string url)
        {

            if (url.Contains("access_token") && url.Contains("&expires_in="))
            {
                var at = url.Replace("https://www.facebook.com/connect/login_success.html#access_token=", "");


                if (Xamarin.Forms.Device.RuntimePlatform == Xamarin.Forms.Device.WinPhone || 
                    Xamarin.Forms.Device.RuntimePlatform == Xamarin.Forms.Device.Windows)
                {

                    at = url.Replace("https://www.facebook.com/connect/login_success.html#access_token=", "");
                }

                var accessToken = at.Remove(at.IndexOf("&expires_in="));

                return accessToken;
            }

            return string.Empty;
        }

        public FacebookViewModel GetFacebookViewModel()
        {
            return facebookViewModel;
        }

    }
}

/*
 * Visit https://developers.facebook.com/docs/graph-api/overview for more information on using Facebook Graph API
 * Visit https://developers.facebook.com/docs/graph-api/reference for API reference
 */

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Aria
{
    public partial class LoginPage : ContentPage
    {

        private String ClientID = "261030987696749";

        public LoginPage()
        {
            InitializeComponent();
        }

        public void FacebookLoginBtnClicked(object sender, EventArgs e)
        {
            //DisplayAlert("Facebook Login", "You're logging in through Facebook", "Noted");
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

            if(accessToken != "")
            {
                await GetFacebookProfileAsync(accessToken);
            }
		}

        private string ExtractAccessTokenFromUrl(string url)
        {

            if (url.Contains("access_token") && url.Contains("&expires_in="))
            {
                var at = url.Replace("https://www.facebook.com/connect/login_success.html#access_token=", "");

                if (Device.RuntimePlatform == Device.WinPhone || Device.RuntimePlatform == Device.Windows)
                {
                    at = url.Replace("https://www.facebook.com/connect/login_success.html#access_token=", "");
                }

                var accessToken = at.Remove(at.IndexOf("&expires_in="));
				
                return accessToken;
            }

            return string.Empty;
        }

        public async Task GetFacebookProfileAsync(string accessToken)
        {
            var requestUrl =
                "https://graph.facebook.com/v2.9/me" +
                "?fields=name,picture" +
                "&access_token=" + accessToken;

            var httpClient = new HttpClient();

            var userJson = await httpClient.GetStringAsync(requestUrl);
        }
    }
}

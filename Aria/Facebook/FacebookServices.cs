using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Facebook.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Facebook.Services
{
    public class FacebookServices
    {
		public async Task<FacebookProfile> GetFacebookProfileAsync(string accessToken)
		{
			var requestUrl =
				"https://graph.facebook.com/v2.9/me" +
				"?fields=name,picture" +
				"&access_token=" + accessToken;

			var httpClient = new HttpClient();

			var userJson = await httpClient.GetStringAsync(requestUrl);

			var facebookProfile = JsonConvert.DeserializeObject<FacebookProfile>(userJson);

			return facebookProfile;
		}
    }
}

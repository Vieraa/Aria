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
            //Get friend list from FB API
            //Show friends that uses Flawk
            //Get friends' picture, name and description

            //Include json array in FacebookProfile

			var requestUrl =
				"https://graph.facebook.com/v2.11/me" +
				"?fields=name,picture,friends" +
				"&access_token=" + accessToken;

			var httpClient = new HttpClient();

			var userJson = await httpClient.GetStringAsync(requestUrl);

			var facebookProfile = JsonConvert.DeserializeObject<FacebookProfile>(userJson);

			return facebookProfile;
		}
    }
}

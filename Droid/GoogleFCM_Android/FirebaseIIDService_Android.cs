using System;
using Android.App;
using Android.Util;
using Firebase.Iid;

using Aria.GoogleFCM;

using Aria.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(FirebaseIIDService_Android))]
namespace Aria.Droid
{
	[Service]
	[IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
    public class FirebaseIIDService_Android : FirebaseInstanceIdService, IFirebaseIIDService
	{
		const string TAG = "MyFirebaseIIDService";
		public override void OnTokenRefresh()
		{
            var refreshedToken = FirebaseInstanceId.Instance.Token;
			Log.Debug(TAG, "Refreshed token: " + refreshedToken);
			SendRegistrationToServer(refreshedToken);
		}
		public void SendRegistrationToServer(string token)
		{
			// Add custom implementation, as needed.
		}
	}
}
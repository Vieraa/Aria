using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Aria.Droid.GoogleFCM_Android;

//--------Google Play Services--------
using Android.Gms.Common;

//--------Firebase Messaging--------
using Firebase;
using Firebase.Messaging;
using Firebase.Iid;
using Android.Util; //---Adds logging functionality to transactions

namespace Aria.Droid
{
    [Activity(Label = "Aria.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
		//google play services walkthrough
		//TextView msgText;
        //const string TAG = "MainActivity";

        protected override void OnCreate(Bundle bundle)
        {
            

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            LoadApplication(new App());

            GooglePlayService_Android.IsPlayServicesAvailable(this);
        }

		/*protected override void OnCreate(Bundle bundle)
		{
            Log.Debug(TAG, "google app id: " + Resource.String.google_app_id);

			base.OnCreate(bundle);
            global::Xamarin.Forms.Forms.Init(this, bundle);
			SetContentView(Resource.Layout.Main);



			msgText = FindViewById<TextView>(Resource.Id.msgText);

			if (Intent.Extras != null)
			{
				foreach (var key in Intent.Extras.KeySet())
				{
					var value = Intent.Extras.GetString(key);
					Log.Debug(TAG, "Key: {0} Value: {1}", key, value);
				}
			}

			IsPlayServicesAvailable();

			var logTokenButton = FindViewById<Button>(Resource.Id.logTokenButton);

            logTokenButton.Click += delegate
            {
                Log.Debug(TAG, "InstanceID token: " + FirebaseInstanceId.Instance.Token);
			};
		}

		public bool IsPlayServicesAvailable()
		{
			int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
			if (resultCode != ConnectionResult.Success)
			{
				if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
					msgText.Text = GoogleApiAvailability.Instance.GetErrorString(resultCode);
				else
				{
					msgText.Text = "This device is not supported";
					Finish();
				}
				return false;
			}
			else
			{
				msgText.Text = "Google Play Services is available.";
				return true;
			}
		}*/


    }

}

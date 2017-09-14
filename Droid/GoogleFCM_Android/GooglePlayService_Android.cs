using System;

//-----Google Play Services-----
using Android.Gms.Common;

//-----Adds logging functionality-----
using Android.Util;

namespace Aria.Droid.GoogleFCM_Android
{
    public static class GooglePlayService_Android
    {
        static String msg = "Google Play Services";

        public static bool IsPlayServicesAvailable(MainActivity activity)
        {
			int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(activity);

			if (resultCode != ConnectionResult.Success)
			{
				if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
                    Log.Debug(msg, "Google Play Services error: " + GoogleApiAvailability.Instance.GetErrorString(resultCode));
				else
				{
                    Log.Debug(msg, "Google Play Services is unavailable.");
				}
				return false;
			}
			else
			{
                Log.Debug(msg, "Google Play Services is available");
				return true;
			}
        }

    }
}

using System;
using Android.App;
using Android.Content;
using Android.Media;
using Android.Util;
using Firebase.Messaging;

namespace Aria.Droid
{
	[Service]
    //Intent filter must be declared so that new FCM messages are directed to FirebaseMessaging Service
	[IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
	public class MyFirebaseMessagingService : FirebaseMessagingService
	{
		const string TAG = "MyFirebaseMsgService";

        //Method: Extracts the message content from the passed-in RemoteMessage object by calling the GetNotification method
		public override void OnMessageReceived(RemoteMessage message)
		{
			Log.Debug(TAG, "From: " + message.From);
			Log.Debug(TAG, "Notification Message Body: " + message.GetNotification().Body);
		}
	}
}
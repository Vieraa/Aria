using System;
using Android.App;
using Android.Content;
using Android.Media;
using Android.Util;
using Firebase.Messaging;

using Aria.Droid;

namespace Aria.Droid
{
	[Service]
    //Intent filter must be declared so that new FCM messages are directed to FirebaseMessaging Service
	[IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
	public class FirebaseMessagingService_Android : FirebaseMessagingService
	{
		const string TAG = "MyFirebaseMsgService";

        //Method: Extracts the message content from the passed-in RemoteMessage object by calling the GetNotification method
		public override void OnMessageReceived(RemoteMessage message)
		{
			Log.Debug(TAG, "From: " + message.From);
			Log.Debug(TAG, "Notification Message Body: " + message.GetNotification().Body);
            Log.Debug(TAG, "Notification Message Title: " + message.GetNotification().Title);

            SendNotification(message.GetNotification().Title, message.GetNotification().Body);
		}

        //Display local notification when app is running in the foreground
		void SendNotification(string messageTitle, string messageBody)
		{
			var intent = new Intent(this, typeof(MainActivity));
			intent.AddFlags(ActivityFlags.ClearTop);
			var pendingIntent = PendingIntent.GetActivity(this, 0, intent, PendingIntentFlags.OneShot);

            //Edits the content of the notification
			var notificationBuilder = new Notification.Builder(this)
				.SetSmallIcon(Resource.Drawable.ic_stat_ic_notification)
                .SetContentTitle(messageTitle)
				.SetContentText(messageBody)
				.SetAutoCancel(true)
				.SetContentIntent(pendingIntent);

			var notificationManager = NotificationManager.FromContext(this);
			notificationManager.Notify(0, notificationBuilder.Build());
		}
	}
}
package md5ee2f7869069f28a5ecb08e043fb3111f;


public class FirebaseIIDService_Android
	extends com.google.firebase.iid.FirebaseInstanceIdService
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onTokenRefresh:()V:GetOnTokenRefreshHandler\n" +
			"";
		mono.android.Runtime.register ("Aria.Droid.FirebaseIIDService_Android, Aria.Droid", FirebaseIIDService_Android.class, __md_methods);
	}


	public FirebaseIIDService_Android ()
	{
		super ();
		if (getClass () == FirebaseIIDService_Android.class)
			mono.android.TypeManager.Activate ("Aria.Droid.FirebaseIIDService_Android, Aria.Droid", "", this, new java.lang.Object[] {  });
	}


	public void onTokenRefresh ()
	{
		n_onTokenRefresh ();
	}

	private native void n_onTokenRefresh ();

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}

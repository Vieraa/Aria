package md5efb48d62618781f92fb7397500f52238;


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
		mono.android.Runtime.register ("Aria.Droid.FirebaseIIDService_Android, Aria.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", FirebaseIIDService_Android.class, __md_methods);
	}


	public FirebaseIIDService_Android () throws java.lang.Throwable
	{
		super ();
		if (getClass () == FirebaseIIDService_Android.class)
			mono.android.TypeManager.Activate ("Aria.Droid.FirebaseIIDService_Android, Aria.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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

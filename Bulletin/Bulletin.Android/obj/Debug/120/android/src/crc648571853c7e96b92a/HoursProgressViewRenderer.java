package crc648571853c7e96b92a;


public class HoursProgressViewRenderer
	extends crc643f46942d9dd1fff9.ViewRenderer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onDraw:(Landroid/graphics/Canvas;)V:GetOnDraw_Landroid_graphics_Canvas_Handler\n" +
			"";
		mono.android.Runtime.register ("Bulletin.Droid.Renderers.HoursProgressViewRenderer, Bulletin.Android", HoursProgressViewRenderer.class, __md_methods);
	}


	public HoursProgressViewRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == HoursProgressViewRenderer.class)
			mono.android.TypeManager.Activate ("Bulletin.Droid.Renderers.HoursProgressViewRenderer, Bulletin.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public HoursProgressViewRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == HoursProgressViewRenderer.class)
			mono.android.TypeManager.Activate ("Bulletin.Droid.Renderers.HoursProgressViewRenderer, Bulletin.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public HoursProgressViewRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == HoursProgressViewRenderer.class)
			mono.android.TypeManager.Activate ("Bulletin.Droid.Renderers.HoursProgressViewRenderer, Bulletin.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public void onDraw (android.graphics.Canvas p0)
	{
		n_onDraw (p0);
	}

	private native void n_onDraw (android.graphics.Canvas p0);

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

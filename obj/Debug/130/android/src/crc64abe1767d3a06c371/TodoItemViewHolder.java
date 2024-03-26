package crc64abe1767d3a06c371;


public class TodoItemViewHolder
	extends androidx.recyclerview.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("atelierXamarin.TodoItemViewHolder, atelierXamarin", TodoItemViewHolder.class, __md_methods);
	}


	public TodoItemViewHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == TodoItemViewHolder.class) {
			mono.android.TypeManager.Activate ("atelierXamarin.TodoItemViewHolder, atelierXamarin", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
		}
	}

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

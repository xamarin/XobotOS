using System;

namespace android.widget
{
	public interface IAdapterView
	{
		Adapter getAdapter ();
	}

	partial class AdapterView<T> : IAdapterView
	{
		Adapter IAdapterView.getAdapter ()
		{
			return getAdapter ();
		}
	}
}

using Sharpen;

namespace android.widget
{
	/// <summary>List adapter that wraps another list adapter.</summary>
	/// <remarks>
	/// List adapter that wraps another list adapter. The wrapped adapter can be retrieved
	/// by calling
	/// <see cref="getWrappedAdapter()">getWrappedAdapter()</see>
	/// .
	/// </remarks>
	/// <seealso cref="ListView">ListView</seealso>
	[Sharpen.Sharpened]
	public interface WrapperListAdapter : android.widget.ListAdapter
	{
		/// <summary>Returns the adapter wrapped by this list adapter.</summary>
		/// <remarks>Returns the adapter wrapped by this list adapter.</remarks>
		/// <returns>
		/// The
		/// <see cref="ListAdapter">ListAdapter</see>
		/// wrapped by this adapter.
		/// </returns>
		android.widget.ListAdapter getWrappedAdapter();
	}
}

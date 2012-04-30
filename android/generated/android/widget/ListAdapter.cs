using Sharpen;

namespace android.widget
{
	/// <summary>
	/// Extended
	/// <see cref="Adapter">Adapter</see>
	/// that is the bridge between a
	/// <see cref="ListView">ListView</see>
	/// and the data that backs the list. Frequently that data comes from a Cursor,
	/// but that is not
	/// required. The ListView can display any data provided that it is wrapped in a
	/// ListAdapter.
	/// </summary>
	[Sharpen.Sharpened]
	public interface ListAdapter : android.widget.Adapter
	{
		/// <summary>Indicates whether all the items in this adapter are enabled.</summary>
		/// <remarks>
		/// Indicates whether all the items in this adapter are enabled. If the
		/// value returned by this method changes over time, there is no guarantee
		/// it will take effect.  If true, it means all items are selectable and
		/// clickable (there is no separator.)
		/// </remarks>
		/// <returns>True if all items are enabled, false otherwise.</returns>
		/// <seealso cref="isEnabled(int)"></seealso>
		bool areAllItemsEnabled();

		/// <summary>Returns true if the item at the specified position is not a separator.</summary>
		/// <remarks>
		/// Returns true if the item at the specified position is not a separator.
		/// (A separator is a non-selectable, non-clickable item).
		/// The result is unspecified if position is invalid. An
		/// <see cref="System.IndexOutOfRangeException">System.IndexOutOfRangeException</see>
		/// should be thrown in that case for fast failure.
		/// </remarks>
		/// <param name="position">Index of the item</param>
		/// <returns>True if the item is not a separator</returns>
		/// <seealso cref="areAllItemsEnabled()"></seealso>
		bool isEnabled(int position);
	}
}

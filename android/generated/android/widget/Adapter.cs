using Sharpen;

namespace android.widget
{
	/// <summary>
	/// An Adapter object acts as a bridge between an
	/// <see cref="AdapterView{T}">AdapterView&lt;T&gt;</see>
	/// and the
	/// underlying data for that view. The Adapter provides access to the data items.
	/// The Adapter is also responsible for making a
	/// <see cref="android.view.View">android.view.View</see>
	/// for
	/// each item in the data set.
	/// </summary>
	/// <seealso cref="ArrayAdapter{T}">ArrayAdapter&lt;T&gt;</seealso>
	/// <seealso cref="CursorAdapter">CursorAdapter</seealso>
	/// <seealso cref="SimpleCursorAdapter">SimpleCursorAdapter</seealso>
	[Sharpen.Sharpened]
	public interface Adapter
	{
		/// <summary>Register an observer that is called when changes happen to the data used by this adapter.
		/// 	</summary>
		/// <remarks>Register an observer that is called when changes happen to the data used by this adapter.
		/// 	</remarks>
		/// <param name="observer">the object that gets notified when the data set changes.</param>
		void registerDataSetObserver(android.database.DataSetObserver observer);

		/// <summary>
		/// Unregister an observer that has previously been registered with this
		/// adapter via
		/// <see cref="registerDataSetObserver(android.database.DataSetObserver)">registerDataSetObserver(android.database.DataSetObserver)
		/// 	</see>
		/// .
		/// </summary>
		/// <param name="observer">the object to unregister.</param>
		void unregisterDataSetObserver(android.database.DataSetObserver observer);

		/// <summary>How many items are in the data set represented by this Adapter.</summary>
		/// <remarks>How many items are in the data set represented by this Adapter.</remarks>
		/// <returns>Count of items.</returns>
		int getCount();

		/// <summary>Get the data item associated with the specified position in the data set.
		/// 	</summary>
		/// <remarks>Get the data item associated with the specified position in the data set.
		/// 	</remarks>
		/// <param name="position">
		/// Position of the item whose data we want within the adapter's
		/// data set.
		/// </param>
		/// <returns>The data at the specified position.</returns>
		object getItem(int position);

		/// <summary>Get the row id associated with the specified position in the list.</summary>
		/// <remarks>Get the row id associated with the specified position in the list.</remarks>
		/// <param name="position">The position of the item within the adapter's data set whose row id we want.
		/// 	</param>
		/// <returns>The id of the item at the specified position.</returns>
		long getItemId(int position);

		/// <summary>
		/// Indicates whether the item ids are stable across changes to the
		/// underlying data.
		/// </summary>
		/// <remarks>
		/// Indicates whether the item ids are stable across changes to the
		/// underlying data.
		/// </remarks>
		/// <returns>True if the same id always refers to the same object.</returns>
		bool hasStableIds();

		/// <summary>Get a View that displays the data at the specified position in the data set.
		/// 	</summary>
		/// <remarks>
		/// Get a View that displays the data at the specified position in the data set. You can either
		/// create a View manually or inflate it from an XML layout file. When the View is inflated, the
		/// parent View (GridView, ListView...) will apply default layout parameters unless you use
		/// <see cref="android.view.LayoutInflater.inflate(int, android.view.ViewGroup, bool)
		/// 	">android.view.LayoutInflater.inflate(int, android.view.ViewGroup, bool)</see>
		/// to specify a root view and to prevent attachment to the root.
		/// </remarks>
		/// <param name="position">
		/// The position of the item within the adapter's data set of the item whose view
		/// we want.
		/// </param>
		/// <param name="convertView">
		/// The old view to reuse, if possible. Note: You should check that this view
		/// is non-null and of an appropriate type before using. If it is not possible to convert
		/// this view to display the correct data, this method can create a new view.
		/// Heterogeneous lists can specify their number of view types, so that this View is
		/// always of the right type (see
		/// <see cref="getViewTypeCount()">getViewTypeCount()</see>
		/// and
		/// <see cref="getItemViewType(int)">getItemViewType(int)</see>
		/// ).
		/// </param>
		/// <param name="parent">The parent that this view will eventually be attached to</param>
		/// <returns>A View corresponding to the data at the specified position.</returns>
		android.view.View getView(int position, android.view.View convertView, android.view.ViewGroup
			 parent);

		/// <summary>
		/// Get the type of View that will be created by
		/// <see cref="getView(int, android.view.View, android.view.ViewGroup)">getView(int, android.view.View, android.view.ViewGroup)
		/// 	</see>
		/// for the specified item.
		/// </summary>
		/// <param name="position">
		/// The position of the item within the adapter's data set whose view type we
		/// want.
		/// </param>
		/// <returns>
		/// An integer representing the type of View. Two views should share the same type if one
		/// can be converted to the other in
		/// <see cref="getView(int, android.view.View, android.view.ViewGroup)">getView(int, android.view.View, android.view.ViewGroup)
		/// 	</see>
		/// . Note: Integers must be in the
		/// range 0 to
		/// <see cref="getViewTypeCount()">getViewTypeCount()</see>
		/// - 1.
		/// <see cref="android.widget.AdapterClass.IGNORE_ITEM_VIEW_TYPE">android.widget.AdapterClass.IGNORE_ITEM_VIEW_TYPE
		/// 	</see>
		/// can
		/// also be returned.
		/// </returns>
		/// <seealso cref="android.widget.AdapterClass.IGNORE_ITEM_VIEW_TYPE">android.widget.AdapterClass.IGNORE_ITEM_VIEW_TYPE
		/// 	</seealso>
		int getItemViewType(int position);

		/// <summary>
		/// <p>
		/// Returns the number of types of Views that will be created by
		/// <see cref="getView(int, android.view.View, android.view.ViewGroup)">getView(int, android.view.View, android.view.ViewGroup)
		/// 	</see>
		/// . Each type represents a set of views that can be
		/// converted in
		/// <see cref="getView(int, android.view.View, android.view.ViewGroup)">getView(int, android.view.View, android.view.ViewGroup)
		/// 	</see>
		/// . If the adapter always returns the same
		/// type of View for all items, this method should return 1.
		/// </p>
		/// <p>
		/// This method will only be called when when the adapter is set on the
		/// the
		/// <see cref="AdapterView{T}">AdapterView&lt;T&gt;</see>
		/// .
		/// </p>
		/// </summary>
		/// <returns>The number of types of Views that will be created by this adapter</returns>
		int getViewTypeCount();

		/// <returns>
		/// true if this adapter doesn't contain any data.  This is used to determine
		/// whether the empty view should be displayed.  A typical implementation will return
		/// getCount() == 0 but since getCount() includes the headers and footers, specialized
		/// adapters might want a different behavior.
		/// </returns>
		bool isEmpty();
	}

	/// <summary>
	/// An Adapter object acts as a bridge between an
	/// <see cref="AdapterView{T}">AdapterView&lt;T&gt;</see>
	/// and the
	/// underlying data for that view. The Adapter provides access to the data items.
	/// The Adapter is also responsible for making a
	/// <see cref="android.view.View">android.view.View</see>
	/// for
	/// each item in the data set.
	/// </summary>
	/// <seealso cref="ArrayAdapter{T}">ArrayAdapter&lt;T&gt;</seealso>
	/// <seealso cref="CursorAdapter">CursorAdapter</seealso>
	/// <seealso cref="SimpleCursorAdapter">SimpleCursorAdapter</seealso>
	[Sharpen.Sharpened]
	public static class AdapterClass
	{
		/// <summary>
		/// An item view type that causes the
		/// <see cref="AdapterView{T}">AdapterView&lt;T&gt;</see>
		/// to ignore the item
		/// view. For example, this can be used if the client does not want a
		/// particular view to be given for conversion in
		/// <see cref="getView(int, android.view.View, android.view.ViewGroup)">getView(int, android.view.View, android.view.ViewGroup)
		/// 	</see>
		/// .
		/// </summary>
		/// <seealso cref="getItemViewType(int)">getItemViewType(int)</seealso>
		/// <seealso cref="getViewTypeCount()">getViewTypeCount()</seealso>
		public const int IGNORE_ITEM_VIEW_TYPE = android.widget.AdapterView.ITEM_VIEW_TYPE_IGNORE;

		public const int NO_SELECTION = int.MinValue;
	}
}

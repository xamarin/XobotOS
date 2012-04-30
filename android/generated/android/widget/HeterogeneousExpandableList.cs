using Sharpen;

namespace android.widget
{
	/// <summary>
	/// Additional methods that when implemented make an
	/// <see cref="ExpandableListAdapter">ExpandableListAdapter</see>
	/// take advantage of the
	/// <see cref="Adapter">Adapter</see>
	/// view type
	/// mechanism.
	/// <p>
	/// An
	/// <see cref="ExpandableListAdapter">ExpandableListAdapter</see>
	/// declares it has one view type for its group items
	/// and one view type for its child items. Although adapted for most
	/// <see cref="ExpandableListView">ExpandableListView</see>
	/// s,
	/// these values should be tuned for heterogeneous
	/// <see cref="ExpandableListView">ExpandableListView</see>
	/// s.
	/// </p>
	/// Lists that contain different types of group and/or child item views, should use an adapter that
	/// implements this interface. This way, the recycled views that will be provided to
	/// <see cref="ExpandableListAdapter.getGroupView(int, bool, android.view.View, android.view.ViewGroup)
	/// 	">ExpandableListAdapter.getGroupView(int, bool, android.view.View, android.view.ViewGroup)
	/// 	</see>
	/// and
	/// <see cref="ExpandableListAdapter.getChildView(int, int, bool, android.view.View, android.view.ViewGroup)
	/// 	">ExpandableListAdapter.getChildView(int, int, bool, android.view.View, android.view.ViewGroup)
	/// 	</see>
	/// will be of the appropriate group or child type, resulting in a more efficient reuse of the
	/// previously created views.
	/// </summary>
	[Sharpen.Sharpened]
	public interface HeterogeneousExpandableList
	{
		/// <summary>
		/// Get the type of group View that will be created by
		/// <see cref="ExpandableListAdapter.getGroupView(int, bool, android.view.View, android.view.ViewGroup)
		/// 	">ExpandableListAdapter.getGroupView(int, bool, android.view.View, android.view.ViewGroup)
		/// 	</see>
		/// . for the specified group item.
		/// </summary>
		/// <param name="groupPosition">the position of the group for which the type should be returned.
		/// 	</param>
		/// <returns>
		/// An integer representing the type of group View. Two group views should share the same
		/// type if one can be converted to the other in
		/// <see cref="ExpandableListAdapter.getGroupView(int, bool, android.view.View, android.view.ViewGroup)
		/// 	">ExpandableListAdapter.getGroupView(int, bool, android.view.View, android.view.ViewGroup)
		/// 	</see>
		/// . Note: Integers must be in the range 0 to
		/// <see cref="getGroupTypeCount()">getGroupTypeCount()</see>
		/// - 1.
		/// <see cref="android.widget.AdapterClass.IGNORE_ITEM_VIEW_TYPE">android.widget.AdapterClass.IGNORE_ITEM_VIEW_TYPE
		/// 	</see>
		/// can also be returned.
		/// </returns>
		/// <seealso cref="android.widget.AdapterClass.IGNORE_ITEM_VIEW_TYPE">android.widget.AdapterClass.IGNORE_ITEM_VIEW_TYPE
		/// 	</seealso>
		/// <seealso cref="getGroupTypeCount()">getGroupTypeCount()</seealso>
		int getGroupType(int groupPosition);

		/// <summary>
		/// Get the type of child View that will be created by
		/// <see cref="ExpandableListAdapter.getChildView(int, int, bool, android.view.View, android.view.ViewGroup)
		/// 	">ExpandableListAdapter.getChildView(int, int, bool, android.view.View, android.view.ViewGroup)
		/// 	</see>
		/// for the specified child item.
		/// </summary>
		/// <param name="groupPosition">the position of the group that the child resides in</param>
		/// <param name="childPosition">the position of the child with respect to other children in the group
		/// 	</param>
		/// <returns>
		/// An integer representing the type of child View. Two child views should share the same
		/// type if one can be converted to the other in
		/// <see cref="ExpandableListAdapter.getChildView(int, int, bool, android.view.View, android.view.ViewGroup)
		/// 	">ExpandableListAdapter.getChildView(int, int, bool, android.view.View, android.view.ViewGroup)
		/// 	</see>
		/// Note: Integers must be in the range 0 to
		/// <see cref="getChildTypeCount()">getChildTypeCount()</see>
		/// - 1.
		/// <see cref="android.widget.AdapterClass.IGNORE_ITEM_VIEW_TYPE">android.widget.AdapterClass.IGNORE_ITEM_VIEW_TYPE
		/// 	</see>
		/// can also be returned.
		/// </returns>
		/// <seealso cref="android.widget.AdapterClass.IGNORE_ITEM_VIEW_TYPE">android.widget.AdapterClass.IGNORE_ITEM_VIEW_TYPE
		/// 	</seealso>
		/// <seealso cref="getChildTypeCount()">getChildTypeCount()</seealso>
		int getChildType(int groupPosition, int childPosition);

		/// <summary>
		/// <p>
		/// Returns the number of types of group Views that will be created by
		/// <see cref="ExpandableListAdapter.getGroupView(int, bool, android.view.View, android.view.ViewGroup)
		/// 	">ExpandableListAdapter.getGroupView(int, bool, android.view.View, android.view.ViewGroup)
		/// 	</see>
		/// . Each type represents a set of views that can be converted in
		/// <see cref="ExpandableListAdapter.getGroupView(int, bool, android.view.View, android.view.ViewGroup)
		/// 	">ExpandableListAdapter.getGroupView(int, bool, android.view.View, android.view.ViewGroup)
		/// 	</see>
		/// . If the adapter always returns the same type of View for all group items, this method should
		/// return 1.
		/// </p>
		/// This method will only be called when the adapter is set on the
		/// <see cref="AdapterView{T}">AdapterView&lt;T&gt;</see>
		/// .
		/// </summary>
		/// <returns>The number of types of group Views that will be created by this adapter.
		/// 	</returns>
		/// <seealso cref="getChildTypeCount()">getChildTypeCount()</seealso>
		/// <seealso cref="getGroupType(int)">getGroupType(int)</seealso>
		int getGroupTypeCount();

		/// <summary>
		/// <p>
		/// Returns the number of types of child Views that will be created by
		/// <see cref="ExpandableListAdapter.getChildView(int, int, bool, android.view.View, android.view.ViewGroup)
		/// 	">ExpandableListAdapter.getChildView(int, int, bool, android.view.View, android.view.ViewGroup)
		/// 	</see>
		/// . Each type represents a set of views that can be converted in
		/// <see cref="ExpandableListAdapter.getChildView(int, int, bool, android.view.View, android.view.ViewGroup)
		/// 	">ExpandableListAdapter.getChildView(int, int, bool, android.view.View, android.view.ViewGroup)
		/// 	</see>
		/// , for any group. If the adapter always returns the same type of View for
		/// all child items, this method should return 1.
		/// </p>
		/// This method will only be called when the adapter is set on the
		/// <see cref="AdapterView{T}">AdapterView&lt;T&gt;</see>
		/// .
		/// </summary>
		/// <returns>The total number of types of child Views that will be created by this adapter.
		/// 	</returns>
		/// <seealso cref="getGroupTypeCount()">getGroupTypeCount()</seealso>
		/// <seealso cref="getChildType(int, int)">getChildType(int, int)</seealso>
		int getChildTypeCount();
	}
}

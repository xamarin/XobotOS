using Sharpen;

namespace android.widget
{
	/// <summary>
	/// An adapter that links a
	/// <see cref="ExpandableListView">ExpandableListView</see>
	/// with the underlying
	/// data. The implementation of this interface will provide access
	/// to the data of the children (categorized by groups), and also instantiate
	/// <see cref="android.view.View">android.view.View</see>
	/// s for children and groups.
	/// </summary>
	[Sharpen.Sharpened]
	public interface ExpandableListAdapter
	{
		/// <seealso cref="Adapter.registerDataSetObserver(android.database.DataSetObserver)"
		/// 	>Adapter.registerDataSetObserver(android.database.DataSetObserver)</seealso>
		void registerDataSetObserver(android.database.DataSetObserver observer);

		/// <seealso cref="Adapter.unregisterDataSetObserver(android.database.DataSetObserver)
		/// 	">Adapter.unregisterDataSetObserver(android.database.DataSetObserver)</seealso>
		void unregisterDataSetObserver(android.database.DataSetObserver observer);

		/// <summary>Gets the number of groups.</summary>
		/// <remarks>Gets the number of groups.</remarks>
		/// <returns>the number of groups</returns>
		int getGroupCount();

		/// <summary>Gets the number of children in a specified group.</summary>
		/// <remarks>Gets the number of children in a specified group.</remarks>
		/// <param name="groupPosition">
		/// the position of the group for which the children
		/// count should be returned
		/// </param>
		/// <returns>the children count in the specified group</returns>
		int getChildrenCount(int groupPosition);

		/// <summary>Gets the data associated with the given group.</summary>
		/// <remarks>Gets the data associated with the given group.</remarks>
		/// <param name="groupPosition">the position of the group</param>
		/// <returns>the data child for the specified group</returns>
		object getGroup(int groupPosition);

		/// <summary>Gets the data associated with the given child within the given group.</summary>
		/// <remarks>Gets the data associated with the given child within the given group.</remarks>
		/// <param name="groupPosition">the position of the group that the child resides in</param>
		/// <param name="childPosition">
		/// the position of the child with respect to other
		/// children in the group
		/// </param>
		/// <returns>the data of the child</returns>
		object getChild(int groupPosition, int childPosition);

		/// <summary>Gets the ID for the group at the given position.</summary>
		/// <remarks>
		/// Gets the ID for the group at the given position. This group ID must be
		/// unique across groups. The combined ID (see
		/// <see cref="getCombinedGroupId(long)">getCombinedGroupId(long)</see>
		/// ) must be unique across ALL items
		/// (groups and all children).
		/// </remarks>
		/// <param name="groupPosition">the position of the group for which the ID is wanted</param>
		/// <returns>the ID associated with the group</returns>
		long getGroupId(int groupPosition);

		/// <summary>Gets the ID for the given child within the given group.</summary>
		/// <remarks>
		/// Gets the ID for the given child within the given group. This ID must be
		/// unique across all children within the group. The combined ID (see
		/// <see cref="getCombinedChildId(long, long)">getCombinedChildId(long, long)</see>
		/// ) must be unique across ALL items
		/// (groups and all children).
		/// </remarks>
		/// <param name="groupPosition">the position of the group that contains the child</param>
		/// <param name="childPosition">
		/// the position of the child within the group for which
		/// the ID is wanted
		/// </param>
		/// <returns>the ID associated with the child</returns>
		long getChildId(int groupPosition, int childPosition);

		/// <summary>
		/// Indicates whether the child and group IDs are stable across changes to the
		/// underlying data.
		/// </summary>
		/// <remarks>
		/// Indicates whether the child and group IDs are stable across changes to the
		/// underlying data.
		/// </remarks>
		/// <returns>whether or not the same ID always refers to the same object</returns>
		/// <seealso cref="Adapter.hasStableIds()">Adapter.hasStableIds()</seealso>
		bool hasStableIds();

		/// <summary>Gets a View that displays the given group.</summary>
		/// <remarks>
		/// Gets a View that displays the given group. This View is only for the
		/// group--the Views for the group's children will be fetched using
		/// <see cref="getChildView(int, int, bool, android.view.View, android.view.ViewGroup)
		/// 	">getChildView(int, int, bool, android.view.View, android.view.ViewGroup)</see>
		/// .
		/// </remarks>
		/// <param name="groupPosition">
		/// the position of the group for which the View is
		/// returned
		/// </param>
		/// <param name="isExpanded">whether the group is expanded or collapsed</param>
		/// <param name="convertView">
		/// the old view to reuse, if possible. You should check
		/// that this view is non-null and of an appropriate type before
		/// using. If it is not possible to convert this view to display
		/// the correct data, this method can create a new view. It is not
		/// guaranteed that the convertView will have been previously
		/// created by
		/// <see cref="getGroupView(int, bool, android.view.View, android.view.ViewGroup)">getGroupView(int, bool, android.view.View, android.view.ViewGroup)
		/// 	</see>
		/// .
		/// </param>
		/// <param name="parent">the parent that this view will eventually be attached to</param>
		/// <returns>the View corresponding to the group at the specified position</returns>
		android.view.View getGroupView(int groupPosition, bool isExpanded, android.view.View
			 convertView, android.view.ViewGroup parent);

		/// <summary>
		/// Gets a View that displays the data for the given child within the given
		/// group.
		/// </summary>
		/// <remarks>
		/// Gets a View that displays the data for the given child within the given
		/// group.
		/// </remarks>
		/// <param name="groupPosition">the position of the group that contains the child</param>
		/// <param name="childPosition">
		/// the position of the child (for which the View is
		/// returned) within the group
		/// </param>
		/// <param name="isLastChild">Whether the child is the last child within the group</param>
		/// <param name="convertView">
		/// the old view to reuse, if possible. You should check
		/// that this view is non-null and of an appropriate type before
		/// using. If it is not possible to convert this view to display
		/// the correct data, this method can create a new view. It is not
		/// guaranteed that the convertView will have been previously
		/// created by
		/// <see cref="getChildView(int, int, bool, android.view.View, android.view.ViewGroup)
		/// 	">getChildView(int, int, bool, android.view.View, android.view.ViewGroup)</see>
		/// .
		/// </param>
		/// <param name="parent">the parent that this view will eventually be attached to</param>
		/// <returns>the View corresponding to the child at the specified position</returns>
		android.view.View getChildView(int groupPosition, int childPosition, bool isLastChild
			, android.view.View convertView, android.view.ViewGroup parent);

		/// <summary>Whether the child at the specified position is selectable.</summary>
		/// <remarks>Whether the child at the specified position is selectable.</remarks>
		/// <param name="groupPosition">the position of the group that contains the child</param>
		/// <param name="childPosition">the position of the child within the group</param>
		/// <returns>whether the child is selectable.</returns>
		bool isChildSelectable(int groupPosition, int childPosition);

		/// <seealso cref="ListAdapter.areAllItemsEnabled()">ListAdapter.areAllItemsEnabled()
		/// 	</seealso>
		bool areAllItemsEnabled();

		/// <seealso cref="Adapter.isEmpty()">Adapter.isEmpty()</seealso>
		bool isEmpty();

		/// <summary>Called when a group is expanded.</summary>
		/// <remarks>Called when a group is expanded.</remarks>
		/// <param name="groupPosition">The group being expanded.</param>
		void onGroupExpanded(int groupPosition);

		/// <summary>Called when a group is collapsed.</summary>
		/// <remarks>Called when a group is collapsed.</remarks>
		/// <param name="groupPosition">The group being collapsed.</param>
		void onGroupCollapsed(int groupPosition);

		/// <summary>
		/// Gets an ID for a child that is unique across any item (either group or
		/// child) that is in this list.
		/// </summary>
		/// <remarks>
		/// Gets an ID for a child that is unique across any item (either group or
		/// child) that is in this list. Expandable lists require each item (group or
		/// child) to have a unique ID among all children and groups in the list.
		/// This method is responsible for returning that unique ID given a child's
		/// ID and its group's ID. Furthermore, if
		/// <see cref="hasStableIds()">hasStableIds()</see>
		/// is true, the
		/// returned ID must be stable as well.
		/// </remarks>
		/// <param name="groupId">The ID of the group that contains this child.</param>
		/// <param name="childId">The ID of the child.</param>
		/// <returns>
		/// The unique (and possibly stable) ID of the child across all
		/// groups and children in this list.
		/// </returns>
		long getCombinedChildId(long groupId, long childId);

		/// <summary>
		/// Gets an ID for a group that is unique across any item (either group or
		/// child) that is in this list.
		/// </summary>
		/// <remarks>
		/// Gets an ID for a group that is unique across any item (either group or
		/// child) that is in this list. Expandable lists require each item (group or
		/// child) to have a unique ID among all children and groups in the list.
		/// This method is responsible for returning that unique ID given a group's
		/// ID. Furthermore, if
		/// <see cref="hasStableIds()">hasStableIds()</see>
		/// is true, the returned ID must be
		/// stable as well.
		/// </remarks>
		/// <param name="groupId">The ID of the group</param>
		/// <returns>
		/// The unique (and possibly stable) ID of the group across all
		/// groups and children in this list.
		/// </returns>
		long getCombinedGroupId(long groupId);
	}
}

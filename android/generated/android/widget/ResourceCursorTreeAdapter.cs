using Sharpen;

namespace android.widget
{
	/// <summary>
	/// A fairly simple ExpandableListAdapter that creates views defined in an XML
	/// file.
	/// </summary>
	/// <remarks>
	/// A fairly simple ExpandableListAdapter that creates views defined in an XML
	/// file. You can specify the XML file that defines the appearance of the views.
	/// </remarks>
	[Sharpen.Sharpened]
	public abstract class ResourceCursorTreeAdapter : android.widget.CursorTreeAdapter
	{
		private int mCollapsedGroupLayout;

		private int mExpandedGroupLayout;

		private int mChildLayout;

		private int mLastChildLayout;

		private android.view.LayoutInflater mInflater;

		/// <summary>Constructor.</summary>
		/// <remarks>Constructor.</remarks>
		/// <param name="context">
		/// The context where the ListView associated with this
		/// SimpleListItemFactory is running
		/// </param>
		/// <param name="cursor">The database cursor</param>
		/// <param name="collapsedGroupLayout">
		/// resource identifier of a layout file that
		/// defines the views for collapsed groups.
		/// </param>
		/// <param name="expandedGroupLayout">
		/// resource identifier of a layout file that
		/// defines the views for expanded groups.
		/// </param>
		/// <param name="childLayout">
		/// resource identifier of a layout file that defines the
		/// views for all children but the last..
		/// </param>
		/// <param name="lastChildLayout">
		/// resource identifier of a layout file that defines
		/// the views for the last child of a group.
		/// </param>
		public ResourceCursorTreeAdapter(android.content.Context context, android.database.Cursor
			 cursor, int collapsedGroupLayout, int expandedGroupLayout, int childLayout, int
			 lastChildLayout) : base(cursor, context)
		{
			mCollapsedGroupLayout = collapsedGroupLayout;
			mExpandedGroupLayout = expandedGroupLayout;
			mChildLayout = childLayout;
			mLastChildLayout = lastChildLayout;
			mInflater = (android.view.LayoutInflater)context.getSystemService(android.content.Context
				.LAYOUT_INFLATER_SERVICE);
		}

		/// <summary>Constructor.</summary>
		/// <remarks>Constructor.</remarks>
		/// <param name="context">
		/// The context where the ListView associated with this
		/// SimpleListItemFactory is running
		/// </param>
		/// <param name="cursor">The database cursor</param>
		/// <param name="collapsedGroupLayout">
		/// resource identifier of a layout file that
		/// defines the views for collapsed groups.
		/// </param>
		/// <param name="expandedGroupLayout">
		/// resource identifier of a layout file that
		/// defines the views for expanded groups.
		/// </param>
		/// <param name="childLayout">
		/// resource identifier of a layout file that defines the
		/// views for all children.
		/// </param>
		public ResourceCursorTreeAdapter(android.content.Context context, android.database.Cursor
			 cursor, int collapsedGroupLayout, int expandedGroupLayout, int childLayout) : this
			(context, cursor, collapsedGroupLayout, expandedGroupLayout, childLayout, childLayout
			)
		{
		}

		/// <summary>Constructor.</summary>
		/// <remarks>Constructor.</remarks>
		/// <param name="context">
		/// The context where the ListView associated with this
		/// SimpleListItemFactory is running
		/// </param>
		/// <param name="cursor">The database cursor</param>
		/// <param name="groupLayout">
		/// resource identifier of a layout file that defines the
		/// views for all groups.
		/// </param>
		/// <param name="childLayout">
		/// resource identifier of a layout file that defines the
		/// views for all children.
		/// </param>
		public ResourceCursorTreeAdapter(android.content.Context context, android.database.Cursor
			 cursor, int groupLayout, int childLayout) : this(context, cursor, groupLayout, 
			groupLayout, childLayout, childLayout)
		{
		}

		[Sharpen.OverridesMethod(@"android.widget.CursorTreeAdapter")]
		protected internal override android.view.View newChildView(android.content.Context
			 context, android.database.Cursor cursor, bool isLastChild, android.view.ViewGroup
			 parent)
		{
			return mInflater.inflate((isLastChild) ? mLastChildLayout : mChildLayout, parent, 
				false);
		}

		[Sharpen.OverridesMethod(@"android.widget.CursorTreeAdapter")]
		protected internal override android.view.View newGroupView(android.content.Context
			 context, android.database.Cursor cursor, bool isExpanded, android.view.ViewGroup
			 parent)
		{
			return mInflater.inflate((isExpanded) ? mExpandedGroupLayout : mCollapsedGroupLayout
				, parent, false);
		}
	}
}

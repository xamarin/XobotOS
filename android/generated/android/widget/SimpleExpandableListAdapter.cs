using Sharpen;

namespace android.widget
{
	[Sharpen.Stub]
	public class SimpleExpandableListAdapter : android.widget.BaseExpandableListAdapter
	{
		private java.util.List<java.util.Map<string, object>> mGroupData;

		private int mExpandedGroupLayout;

		private int mCollapsedGroupLayout;

		private string[] mGroupFrom;

		private int[] mGroupTo;

		private java.util.List<java.util.List<java.util.Map<string, object>>> mChildData;

		private int mChildLayout;

		private int mLastChildLayout;

		private string[] mChildFrom;

		private int[] mChildTo;

		private android.view.LayoutInflater mInflater;

		[Sharpen.Stub]
		public SimpleExpandableListAdapter(android.content.Context context, java.util.List
			<java.util.Map<string, object>> groupData, int groupLayout, string[] groupFrom, 
			int[] groupTo, java.util.List<java.util.List<java.util.Map<string, object>>> childData
			, int childLayout, string[] childFrom, int[] childTo) : this(context, groupData, 
			groupLayout, groupLayout, groupFrom, groupTo, childData, childLayout, childLayout
			, childFrom, childTo)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public SimpleExpandableListAdapter(android.content.Context context, java.util.List
			<java.util.Map<string, object>> groupData, int expandedGroupLayout, int collapsedGroupLayout
			, string[] groupFrom, int[] groupTo, java.util.List<java.util.List<java.util.Map
			<string, object>>> childData, int childLayout, string[] childFrom, int[] childTo
			) : this(context, groupData, expandedGroupLayout, collapsedGroupLayout, groupFrom
			, groupTo, childData, childLayout, childLayout, childFrom, childTo)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public SimpleExpandableListAdapter(android.content.Context context, java.util.List
			<java.util.Map<string, object>> groupData, int expandedGroupLayout, int collapsedGroupLayout
			, string[] groupFrom, int[] groupTo, java.util.List<java.util.List<java.util.Map
			<string, object>>> childData, int childLayout, int lastChildLayout, string[] childFrom
			, int[] childTo)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.widget.ExpandableListAdapter")]
		public override object getChild(int groupPosition, int childPosition)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.widget.ExpandableListAdapter")]
		public override long getChildId(int groupPosition, int childPosition)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.widget.ExpandableListAdapter")]
		public override android.view.View getChildView(int groupPosition, int childPosition
			, bool isLastChild, android.view.View convertView, android.view.ViewGroup parent
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.view.View newChildView(bool isLastChild, android.view.ViewGroup
			 parent)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void bindView<_T0>(android.view.View view, java.util.Map<string, _T0> data
			, string[] from, int[] to)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.widget.ExpandableListAdapter")]
		public override int getChildrenCount(int groupPosition)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.widget.ExpandableListAdapter")]
		public override object getGroup(int groupPosition)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.widget.ExpandableListAdapter")]
		public override int getGroupCount()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.widget.ExpandableListAdapter")]
		public override long getGroupId(int groupPosition)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.widget.ExpandableListAdapter")]
		public override android.view.View getGroupView(int groupPosition, bool isExpanded
			, android.view.View convertView, android.view.ViewGroup parent)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.view.View newGroupView(bool isExpanded, android.view.ViewGroup
			 parent)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.widget.ExpandableListAdapter")]
		public override bool isChildSelectable(int groupPosition, int childPosition)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.widget.ExpandableListAdapter")]
		public override bool hasStableIds()
		{
			throw new System.NotImplementedException();
		}
	}
}

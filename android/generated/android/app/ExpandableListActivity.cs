using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	public class ExpandableListActivity : android.app.Activity, android.view.View.OnCreateContextMenuListener
		, android.widget.ExpandableListView.OnChildClickListener, android.widget.ExpandableListView
		.OnGroupCollapseListener, android.widget.ExpandableListView.OnGroupExpandListener
	{
		internal android.widget.ExpandableListAdapter mAdapter;

		internal android.widget.ExpandableListView mList;

		internal bool mFinishedStart = false;

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Activity")]
		public override void onCreateContextMenu(android.view.ContextMenu menu, android.view.View
			 v, android.view.ContextMenuClass.ContextMenuInfo menuInfo)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.widget.ExpandableListView.OnChildClickListener"
			)]
		public virtual bool onChildClick(android.widget.ExpandableListView parent, android.view.View
			 v, int groupPosition, int childPosition, long id)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.widget.ExpandableListView.OnGroupCollapseListener"
			)]
		public virtual void onGroupCollapse(int groupPosition)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.widget.ExpandableListView.OnGroupExpandListener"
			)]
		public virtual void onGroupExpand(int groupPosition)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Activity")]
		protected internal override void onRestoreInstanceState(android.os.Bundle state)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Activity")]
		public override void onContentChanged()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setListAdapter(android.widget.ExpandableListAdapter adapter)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.widget.ExpandableListView getExpandableListView()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.widget.ExpandableListAdapter getExpandableListAdapter()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void ensureList()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual long getSelectedId()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual long getSelectedPosition()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool setSelectedChild(int groupPosition, int childPosition, bool shouldExpandGroup
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setSelectedGroup(int groupPosition)
		{
			throw new System.NotImplementedException();
		}
	}
}

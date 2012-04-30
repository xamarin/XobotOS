using Sharpen;

namespace android.widget
{
	/// <summary>
	/// Base class for a
	/// <see cref="ExpandableListAdapter">ExpandableListAdapter</see>
	/// used to provide data and Views
	/// from some data to an expandable list view.
	/// <p>
	/// Adapters inheriting this class should verify that the base implementations of
	/// <see cref="getCombinedChildId(long, long)">getCombinedChildId(long, long)</see>
	/// and
	/// <see cref="getCombinedGroupId(long)">getCombinedGroupId(long)</see>
	/// are correct in generating unique IDs from the group/children IDs.
	/// <p>
	/// </summary>
	/// <seealso cref="SimpleExpandableListAdapter">SimpleExpandableListAdapter</seealso>
	/// <seealso cref="SimpleCursorTreeAdapter">SimpleCursorTreeAdapter</seealso>
	[Sharpen.Sharpened]
	public abstract class BaseExpandableListAdapter : android.widget.ExpandableListAdapter
		, android.widget.HeterogeneousExpandableList
	{
		private readonly android.database.DataSetObservable mDataSetObservable = new android.database.DataSetObservable
			();

		[Sharpen.ImplementsInterface(@"android.widget.ExpandableListAdapter")]
		public virtual void registerDataSetObserver(android.database.DataSetObserver observer
			)
		{
			mDataSetObservable.registerObserver(observer);
		}

		[Sharpen.ImplementsInterface(@"android.widget.ExpandableListAdapter")]
		public virtual void unregisterDataSetObserver(android.database.DataSetObserver observer
			)
		{
			mDataSetObservable.unregisterObserver(observer);
		}

		/// <seealso cref="android.database.DataSetObservable.notifyInvalidated()">android.database.DataSetObservable.notifyInvalidated()
		/// 	</seealso>
		public virtual void notifyDataSetInvalidated()
		{
			mDataSetObservable.notifyInvalidated();
		}

		/// <seealso cref="android.database.DataSetObservable.notifyChanged()">android.database.DataSetObservable.notifyChanged()
		/// 	</seealso>
		public virtual void notifyDataSetChanged()
		{
			mDataSetObservable.notifyChanged();
		}

		[Sharpen.ImplementsInterface(@"android.widget.ExpandableListAdapter")]
		public virtual bool areAllItemsEnabled()
		{
			return true;
		}

		[Sharpen.ImplementsInterface(@"android.widget.ExpandableListAdapter")]
		public virtual void onGroupCollapsed(int groupPosition)
		{
		}

		[Sharpen.ImplementsInterface(@"android.widget.ExpandableListAdapter")]
		public virtual void onGroupExpanded(int groupPosition)
		{
		}

		/// <summary>
		/// Override this method if you foresee a clash in IDs based on this scheme:
		/// <p>
		/// Base implementation returns a long:
		/// <li> bit 0: Whether this ID points to a child (unset) or group (set), so for this method
		/// this bit will be 1.
		/// </summary>
		/// <remarks>
		/// Override this method if you foresee a clash in IDs based on this scheme:
		/// <p>
		/// Base implementation returns a long:
		/// <li> bit 0: Whether this ID points to a child (unset) or group (set), so for this method
		/// this bit will be 1.
		/// <li> bit 1-31: Lower 31 bits of the groupId
		/// <li> bit 32-63: Lower 32 bits of the childId.
		/// <p>
		/// <inheritDoc></inheritDoc>
		/// </remarks>
		[Sharpen.ImplementsInterface(@"android.widget.ExpandableListAdapter")]
		public virtual long getCombinedChildId(long groupId, long childId)
		{
			return unchecked((long)(0x8000000000000000L)) | ((groupId & unchecked((int)(0x7FFFFFFF
				))) << 32) | (childId & unchecked((int)(0xFFFFFFFF)));
		}

		/// <summary>
		/// Override this method if you foresee a clash in IDs based on this scheme:
		/// <p>
		/// Base implementation returns a long:
		/// <li> bit 0: Whether this ID points to a child (unset) or group (set), so for this method
		/// this bit will be 0.
		/// </summary>
		/// <remarks>
		/// Override this method if you foresee a clash in IDs based on this scheme:
		/// <p>
		/// Base implementation returns a long:
		/// <li> bit 0: Whether this ID points to a child (unset) or group (set), so for this method
		/// this bit will be 0.
		/// <li> bit 1-31: Lower 31 bits of the groupId
		/// <li> bit 32-63: Lower 32 bits of the childId.
		/// <p>
		/// <inheritDoc></inheritDoc>
		/// </remarks>
		[Sharpen.ImplementsInterface(@"android.widget.ExpandableListAdapter")]
		public virtual long getCombinedGroupId(long groupId)
		{
			return (groupId & unchecked((int)(0x7FFFFFFF))) << 32;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.ImplementsInterface(@"android.widget.ExpandableListAdapter")]
		public virtual bool isEmpty()
		{
			return getGroupCount() == 0;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		/// <returns>0 for any group or child position, since only one child type count is declared.
		/// 	</returns>
		[Sharpen.ImplementsInterface(@"android.widget.HeterogeneousExpandableList")]
		public virtual int getChildType(int groupPosition, int childPosition)
		{
			return 0;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		/// <returns>1 as a default value in BaseExpandableListAdapter.</returns>
		[Sharpen.ImplementsInterface(@"android.widget.HeterogeneousExpandableList")]
		public virtual int getChildTypeCount()
		{
			return 1;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		/// <returns>0 for any groupPosition, since only one group type count is declared.</returns>
		[Sharpen.ImplementsInterface(@"android.widget.HeterogeneousExpandableList")]
		public virtual int getGroupType(int groupPosition)
		{
			return 0;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		/// <returns>1 as a default value in BaseExpandableListAdapter.</returns>
		[Sharpen.ImplementsInterface(@"android.widget.HeterogeneousExpandableList")]
		public virtual int getGroupTypeCount()
		{
			return 1;
		}

		public abstract object getChild(int arg1, int arg2);

		public abstract long getChildId(int arg1, int arg2);

		public abstract android.view.View getChildView(int arg1, int arg2, bool arg3, android.view.View
			 arg4, android.view.ViewGroup arg5);

		public abstract int getChildrenCount(int arg1);

		public abstract object getGroup(int arg1);

		public abstract int getGroupCount();

		public abstract long getGroupId(int arg1);

		public abstract android.view.View getGroupView(int arg1, bool arg2, android.view.View
			 arg3, android.view.ViewGroup arg4);

		public abstract bool hasStableIds();

		public abstract bool isChildSelectable(int arg1, int arg2);
	}
}

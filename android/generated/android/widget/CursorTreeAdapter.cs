using Sharpen;

namespace android.widget
{
	/// <summary>
	/// An adapter that exposes data from a series of
	/// <see cref="android.database.Cursor">android.database.Cursor</see>
	/// s to an
	/// <see cref="ExpandableListView">ExpandableListView</see>
	/// widget. The top-level
	/// <see cref="android.database.Cursor">android.database.Cursor</see>
	/// (that is
	/// given in the constructor) exposes the groups, while subsequent
	/// <see cref="android.database.Cursor">android.database.Cursor</see>
	/// s
	/// returned from
	/// <see cref="getChildrenCursor(android.database.Cursor)">getChildrenCursor(android.database.Cursor)
	/// 	</see>
	/// expose children within a
	/// particular group. The Cursors must include a column named "_id" or this class
	/// will not work.
	/// </summary>
	[Sharpen.Sharpened]
	public abstract class CursorTreeAdapter : android.widget.BaseExpandableListAdapter
		, android.widget.Filterable, android.widget.CursorFilter.CursorFilterClient
	{
		private android.content.Context mContext;

		private android.os.Handler mHandler;

		private bool mAutoRequery;

		/// <summary>The cursor helper that is used to get the groups</summary>
		internal android.widget.CursorTreeAdapter.MyCursorHelper mGroupCursorHelper;

		/// <summary>
		/// The map of a group position to the group's children cursor helper (the
		/// cursor helper that is used to get the children for that group)
		/// </summary>
		internal android.util.SparseArray<android.widget.CursorTreeAdapter.MyCursorHelper
			> mChildrenCursorHelpers;

		internal android.widget.CursorFilter mCursorFilter;

		internal android.widget.FilterQueryProvider mFilterQueryProvider;

		/// <summary>Constructor.</summary>
		/// <remarks>
		/// Constructor. The adapter will call
		/// <see cref="android.database.Cursor.requery()">android.database.Cursor.requery()</see>
		/// on the cursor whenever
		/// it changes so that the most recent data is always displayed.
		/// </remarks>
		/// <param name="cursor">The cursor from which to get the data for the groups.</param>
		public CursorTreeAdapter(android.database.Cursor cursor, android.content.Context 
			context)
		{
			// Filter related
			init(cursor, context, true);
		}

		/// <summary>Constructor.</summary>
		/// <remarks>Constructor.</remarks>
		/// <param name="cursor">The cursor from which to get the data for the groups.</param>
		/// <param name="context">The context</param>
		/// <param name="autoRequery">
		/// If true the adapter will call
		/// <see cref="android.database.Cursor.requery()">android.database.Cursor.requery()</see>
		/// on the cursor whenever it changes so the most recent data is
		/// always displayed.
		/// </param>
		public CursorTreeAdapter(android.database.Cursor cursor, android.content.Context 
			context, bool autoRequery)
		{
			init(cursor, context, autoRequery);
		}

		private void init(android.database.Cursor cursor, android.content.Context context
			, bool autoRequery)
		{
			mContext = context;
			mHandler = new android.os.Handler();
			mAutoRequery = autoRequery;
			mGroupCursorHelper = new android.widget.CursorTreeAdapter.MyCursorHelper(this, cursor
				);
			mChildrenCursorHelpers = new android.util.SparseArray<android.widget.CursorTreeAdapter
				.MyCursorHelper>();
		}

		/// <summary>Gets the cursor helper for the children in the given group.</summary>
		/// <remarks>Gets the cursor helper for the children in the given group.</remarks>
		/// <param name="groupPosition">The group whose children will be returned</param>
		/// <param name="requestCursor">
		/// Whether to request a Cursor via
		/// <see cref="getChildrenCursor(android.database.Cursor)">getChildrenCursor(android.database.Cursor)
		/// 	</see>
		/// (true), or to assume a call
		/// to
		/// <see cref="setChildrenCursor(int, android.database.Cursor)">setChildrenCursor(int, android.database.Cursor)
		/// 	</see>
		/// will happen shortly
		/// (false).
		/// </param>
		/// <returns>The cursor helper for the children of the given group</returns>
		internal virtual android.widget.CursorTreeAdapter.MyCursorHelper getChildrenCursorHelper
			(int groupPosition, bool requestCursor)
		{
			lock (this)
			{
				android.widget.CursorTreeAdapter.MyCursorHelper cursorHelper = mChildrenCursorHelpers
					.get(groupPosition);
				if (cursorHelper == null)
				{
					if (mGroupCursorHelper.moveTo(groupPosition) == null)
					{
						return null;
					}
					android.database.Cursor cursor = getChildrenCursor(mGroupCursorHelper.getCursor()
						);
					cursorHelper = new android.widget.CursorTreeAdapter.MyCursorHelper(this, cursor);
					mChildrenCursorHelpers.put(groupPosition, cursorHelper);
				}
				return cursorHelper;
			}
		}

		/// <summary>Gets the Cursor for the children at the given group.</summary>
		/// <remarks>
		/// Gets the Cursor for the children at the given group. Subclasses must
		/// implement this method to return the children data for a particular group.
		/// <p>
		/// If you want to asynchronously query a provider to prevent blocking the
		/// UI, it is possible to return null and at a later time call
		/// <see cref="setChildrenCursor(int, android.database.Cursor)">setChildrenCursor(int, android.database.Cursor)
		/// 	</see>
		/// .
		/// <p>
		/// It is your responsibility to manage this Cursor through the Activity
		/// lifecycle. It is a good idea to use
		/// <see cref="android.app.Activity.managedQuery(System.Uri, string[], string, string)
		/// 	">android.app.Activity.managedQuery(System.Uri, string[], string, string)</see>
		/// which
		/// will handle this for you. In some situations, the adapter will deactivate
		/// the Cursor on its own, but this will not always be the case, so please
		/// ensure the Cursor is properly managed.
		/// </remarks>
		/// <param name="groupCursor">
		/// The cursor pointing to the group whose children cursor
		/// should be returned
		/// </param>
		/// <returns>The cursor for the children of a particular group, or null.</returns>
		protected internal abstract android.database.Cursor getChildrenCursor(android.database.Cursor
			 groupCursor);

		/// <summary>Sets the group Cursor.</summary>
		/// <remarks>Sets the group Cursor.</remarks>
		/// <param name="cursor">
		/// The Cursor to set for the group. If there is an existing cursor
		/// it will be closed.
		/// </param>
		public virtual void setGroupCursor(android.database.Cursor cursor)
		{
			mGroupCursorHelper.changeCursor(cursor, false);
		}

		/// <summary>Sets the children Cursor for a particular group.</summary>
		/// <remarks>
		/// Sets the children Cursor for a particular group. If there is an existing cursor
		/// it will be closed.
		/// <p>
		/// This is useful when asynchronously querying to prevent blocking the UI.
		/// </remarks>
		/// <param name="groupPosition">The group whose children are being set via this Cursor.
		/// 	</param>
		/// <param name="childrenCursor">The Cursor that contains the children of the group.</param>
		public virtual void setChildrenCursor(int groupPosition, android.database.Cursor 
			childrenCursor)
		{
			android.widget.CursorTreeAdapter.MyCursorHelper childrenCursorHelper = getChildrenCursorHelper
				(groupPosition, false);
			childrenCursorHelper.changeCursor(childrenCursor, false);
		}

		[Sharpen.ImplementsInterface(@"android.widget.ExpandableListAdapter")]
		public override object getChild(int groupPosition, int childPosition)
		{
			// Return this group's children Cursor pointing to the particular child
			return getChildrenCursorHelper(groupPosition, true).moveTo(childPosition);
		}

		[Sharpen.ImplementsInterface(@"android.widget.ExpandableListAdapter")]
		public override long getChildId(int groupPosition, int childPosition)
		{
			return getChildrenCursorHelper(groupPosition, true).getId(childPosition);
		}

		[Sharpen.ImplementsInterface(@"android.widget.ExpandableListAdapter")]
		public override int getChildrenCount(int groupPosition)
		{
			android.widget.CursorTreeAdapter.MyCursorHelper helper = getChildrenCursorHelper(
				groupPosition, true);
			return (mGroupCursorHelper.isValid() && helper != null) ? helper.getCount() : 0;
		}

		[Sharpen.ImplementsInterface(@"android.widget.ExpandableListAdapter")]
		public override object getGroup(int groupPosition)
		{
			// Return the group Cursor pointing to the given group
			return mGroupCursorHelper.moveTo(groupPosition);
		}

		[Sharpen.ImplementsInterface(@"android.widget.ExpandableListAdapter")]
		public override int getGroupCount()
		{
			return mGroupCursorHelper.getCount();
		}

		[Sharpen.ImplementsInterface(@"android.widget.ExpandableListAdapter")]
		public override long getGroupId(int groupPosition)
		{
			return mGroupCursorHelper.getId(groupPosition);
		}

		[Sharpen.ImplementsInterface(@"android.widget.ExpandableListAdapter")]
		public override android.view.View getGroupView(int groupPosition, bool isExpanded
			, android.view.View convertView, android.view.ViewGroup parent)
		{
			android.database.Cursor cursor = mGroupCursorHelper.moveTo(groupPosition);
			if (cursor == null)
			{
				throw new System.InvalidOperationException("this should only be called when the cursor is valid"
					);
			}
			android.view.View v;
			if (convertView == null)
			{
				v = newGroupView(mContext, cursor, isExpanded, parent);
			}
			else
			{
				v = convertView;
			}
			bindGroupView(v, mContext, cursor, isExpanded);
			return v;
		}

		/// <summary>Makes a new group view to hold the group data pointed to by cursor.</summary>
		/// <remarks>Makes a new group view to hold the group data pointed to by cursor.</remarks>
		/// <param name="context">Interface to application's global information</param>
		/// <param name="cursor">
		/// The group cursor from which to get the data. The cursor is
		/// already moved to the correct position.
		/// </param>
		/// <param name="isExpanded">Whether the group is expanded.</param>
		/// <param name="parent">The parent to which the new view is attached to</param>
		/// <returns>The newly created view.</returns>
		protected internal abstract android.view.View newGroupView(android.content.Context
			 context, android.database.Cursor cursor, bool isExpanded, android.view.ViewGroup
			 parent);

		/// <summary>Bind an existing view to the group data pointed to by cursor.</summary>
		/// <remarks>Bind an existing view to the group data pointed to by cursor.</remarks>
		/// <param name="view">Existing view, returned earlier by newGroupView.</param>
		/// <param name="context">Interface to application's global information</param>
		/// <param name="cursor">
		/// The cursor from which to get the data. The cursor is
		/// already moved to the correct position.
		/// </param>
		/// <param name="isExpanded">Whether the group is expanded.</param>
		protected internal abstract void bindGroupView(android.view.View view, android.content.Context
			 context, android.database.Cursor cursor, bool isExpanded);

		[Sharpen.ImplementsInterface(@"android.widget.ExpandableListAdapter")]
		public override android.view.View getChildView(int groupPosition, int childPosition
			, bool isLastChild, android.view.View convertView, android.view.ViewGroup parent
			)
		{
			android.widget.CursorTreeAdapter.MyCursorHelper cursorHelper = getChildrenCursorHelper
				(groupPosition, true);
			android.database.Cursor cursor = cursorHelper.moveTo(childPosition);
			if (cursor == null)
			{
				throw new System.InvalidOperationException("this should only be called when the cursor is valid"
					);
			}
			android.view.View v;
			if (convertView == null)
			{
				v = newChildView(mContext, cursor, isLastChild, parent);
			}
			else
			{
				v = convertView;
			}
			bindChildView(v, mContext, cursor, isLastChild);
			return v;
		}

		/// <summary>Makes a new child view to hold the data pointed to by cursor.</summary>
		/// <remarks>Makes a new child view to hold the data pointed to by cursor.</remarks>
		/// <param name="context">Interface to application's global information</param>
		/// <param name="cursor">
		/// The cursor from which to get the data. The cursor is
		/// already moved to the correct position.
		/// </param>
		/// <param name="isLastChild">Whether the child is the last child within its group.</param>
		/// <param name="parent">The parent to which the new view is attached to</param>
		/// <returns>the newly created view.</returns>
		protected internal abstract android.view.View newChildView(android.content.Context
			 context, android.database.Cursor cursor, bool isLastChild, android.view.ViewGroup
			 parent);

		/// <summary>Bind an existing view to the child data pointed to by cursor</summary>
		/// <param name="view">Existing view, returned earlier by newChildView</param>
		/// <param name="context">Interface to application's global information</param>
		/// <param name="cursor">
		/// The cursor from which to get the data. The cursor is
		/// already moved to the correct position.
		/// </param>
		/// <param name="isLastChild">Whether the child is the last child within its group.</param>
		protected internal abstract void bindChildView(android.view.View view, android.content.Context
			 context, android.database.Cursor cursor, bool isLastChild);

		[Sharpen.ImplementsInterface(@"android.widget.ExpandableListAdapter")]
		public override bool isChildSelectable(int groupPosition, int childPosition)
		{
			return true;
		}

		[Sharpen.ImplementsInterface(@"android.widget.ExpandableListAdapter")]
		public override bool hasStableIds()
		{
			return true;
		}

		private void releaseCursorHelpers()
		{
			lock (this)
			{
				{
					for (int pos = mChildrenCursorHelpers.size() - 1; pos >= 0; pos--)
					{
						mChildrenCursorHelpers.valueAt(pos).deactivate();
					}
				}
				mChildrenCursorHelpers.clear();
			}
		}

		[Sharpen.OverridesMethod(@"android.widget.BaseExpandableListAdapter")]
		public override void notifyDataSetChanged()
		{
			notifyDataSetChanged(true);
		}

		/// <summary>
		/// Notifies a data set change, but with the option of not releasing any
		/// cached cursors.
		/// </summary>
		/// <remarks>
		/// Notifies a data set change, but with the option of not releasing any
		/// cached cursors.
		/// </remarks>
		/// <param name="releaseCursors">
		/// Whether to release and deactivate any cached
		/// cursors.
		/// </param>
		public virtual void notifyDataSetChanged(bool releaseCursors)
		{
			if (releaseCursors)
			{
				releaseCursorHelpers();
			}
			base.notifyDataSetChanged();
		}

		[Sharpen.OverridesMethod(@"android.widget.BaseExpandableListAdapter")]
		public override void notifyDataSetInvalidated()
		{
			releaseCursorHelpers();
			base.notifyDataSetInvalidated();
		}

		[Sharpen.OverridesMethod(@"android.widget.BaseExpandableListAdapter")]
		public override void onGroupCollapsed(int groupPosition)
		{
			deactivateChildrenCursorHelper(groupPosition);
		}

		/// <summary>Deactivates the Cursor and removes the helper from cache.</summary>
		/// <remarks>Deactivates the Cursor and removes the helper from cache.</remarks>
		/// <param name="groupPosition">
		/// The group whose children Cursor and helper should be
		/// deactivated.
		/// </param>
		internal virtual void deactivateChildrenCursorHelper(int groupPosition)
		{
			lock (this)
			{
				android.widget.CursorTreeAdapter.MyCursorHelper cursorHelper = getChildrenCursorHelper
					(groupPosition, true);
				mChildrenCursorHelpers.remove(groupPosition);
				cursorHelper.deactivate();
			}
		}

		[Sharpen.Proxy]
		java.lang.CharSequence android.widget.CursorFilter.CursorFilterClient.convertToString
			(android.database.Cursor cursor)
		{
			return java.lang.CharSequenceProxy.Wrap(convertToString(cursor));
		}

		/// <seealso cref="CursorAdapter.convertToString(android.database.Cursor)">CursorAdapter.convertToString(android.database.Cursor)
		/// 	</seealso>
		[Sharpen.ImplementsInterface(@"android.widget.CursorFilter.CursorFilterClient")]
		public virtual string convertToString(android.database.Cursor cursor)
		{
			return cursor == null ? string.Empty : cursor.ToString();
		}

		/// <seealso cref="CursorAdapter.runQueryOnBackgroundThread(java.lang.CharSequence)">CursorAdapter.runQueryOnBackgroundThread(java.lang.CharSequence)
		/// 	</seealso>
		[Sharpen.ImplementsInterface(@"android.widget.CursorFilter.CursorFilterClient")]
		public virtual android.database.Cursor runQueryOnBackgroundThread(java.lang.CharSequence
			 constraint)
		{
			if (mFilterQueryProvider != null)
			{
				return mFilterQueryProvider.runQuery(constraint);
			}
			return mGroupCursorHelper.getCursor();
		}

		[Sharpen.ImplementsInterface(@"android.widget.Filterable")]
		public virtual android.widget.Filter getFilter()
		{
			if (mCursorFilter == null)
			{
				mCursorFilter = new android.widget.CursorFilter(this);
			}
			return mCursorFilter;
		}

		/// <seealso cref="CursorAdapter.getFilterQueryProvider()">CursorAdapter.getFilterQueryProvider()
		/// 	</seealso>
		public virtual android.widget.FilterQueryProvider getFilterQueryProvider()
		{
			return mFilterQueryProvider;
		}

		/// <seealso cref="CursorAdapter.setFilterQueryProvider(FilterQueryProvider)">CursorAdapter.setFilterQueryProvider(FilterQueryProvider)
		/// 	</seealso>
		public virtual void setFilterQueryProvider(android.widget.FilterQueryProvider filterQueryProvider
			)
		{
			mFilterQueryProvider = filterQueryProvider;
		}

		/// <seealso cref="CursorAdapter.changeCursor(android.database.Cursor)">CursorAdapter.changeCursor(android.database.Cursor)
		/// 	</seealso>
		[Sharpen.ImplementsInterface(@"android.widget.CursorFilter.CursorFilterClient")]
		public virtual void changeCursor(android.database.Cursor cursor)
		{
			mGroupCursorHelper.changeCursor(cursor, true);
		}

		/// <seealso cref="CursorAdapter.getCursor()">CursorAdapter.getCursor()</seealso>
		[Sharpen.ImplementsInterface(@"android.widget.CursorFilter.CursorFilterClient")]
		public virtual android.database.Cursor getCursor()
		{
			return mGroupCursorHelper.getCursor();
		}

		/// <summary>
		/// Helper class for Cursor management:
		/// <li> Data validity
		/// <li> Funneling the content and data set observers from a Cursor to a
		/// single data set observer for widgets
		/// <li> ID from the Cursor for use in adapter IDs
		/// <li> Swapping cursors but maintaining other metadata
		/// </summary>
		internal class MyCursorHelper
		{
			private android.database.Cursor mCursor;

			private bool mDataValid;

			private int mRowIDColumn;

			private android.widget.CursorTreeAdapter.MyCursorHelper.MyContentObserver mContentObserver;

			private android.widget.CursorTreeAdapter.MyCursorHelper.MyDataSetObserver mDataSetObserver;

			internal MyCursorHelper(CursorTreeAdapter _enclosing, android.database.Cursor cursor
				)
			{
				this._enclosing = _enclosing;
				bool cursorPresent = cursor != null;
				this.mCursor = cursor;
				this.mDataValid = cursorPresent;
				this.mRowIDColumn = cursorPresent ? cursor.getColumnIndex("_id") : -1;
				this.mContentObserver = new android.widget.CursorTreeAdapter.MyCursorHelper.MyContentObserver
					(this);
				this.mDataSetObserver = new android.widget.CursorTreeAdapter.MyCursorHelper.MyDataSetObserver
					(this);
				if (cursorPresent)
				{
					cursor.registerContentObserver(this.mContentObserver);
					cursor.registerDataSetObserver(this.mDataSetObserver);
				}
			}

			internal virtual android.database.Cursor getCursor()
			{
				return this.mCursor;
			}

			internal virtual int getCount()
			{
				if (this.mDataValid && this.mCursor != null)
				{
					return this.mCursor.getCount();
				}
				else
				{
					return 0;
				}
			}

			internal virtual long getId(int position)
			{
				if (this.mDataValid && this.mCursor != null)
				{
					if (this.mCursor.moveToPosition(position))
					{
						return this.mCursor.getLong(this.mRowIDColumn);
					}
					else
					{
						return 0;
					}
				}
				else
				{
					return 0;
				}
			}

			internal virtual android.database.Cursor moveTo(int position)
			{
				if (this.mDataValid && (this.mCursor != null) && this.mCursor.moveToPosition(position
					))
				{
					return this.mCursor;
				}
				else
				{
					return null;
				}
			}

			internal virtual void changeCursor(android.database.Cursor cursor, bool releaseCursors
				)
			{
				if (cursor == this.mCursor)
				{
					return;
				}
				this.deactivate();
				this.mCursor = cursor;
				if (cursor != null)
				{
					cursor.registerContentObserver(this.mContentObserver);
					cursor.registerDataSetObserver(this.mDataSetObserver);
					this.mRowIDColumn = cursor.getColumnIndex("_id");
					this.mDataValid = true;
					// notify the observers about the new cursor
					this._enclosing.notifyDataSetChanged(releaseCursors);
				}
				else
				{
					this.mRowIDColumn = -1;
					this.mDataValid = false;
					// notify the observers about the lack of a data set
					this._enclosing.notifyDataSetInvalidated();
				}
			}

			internal virtual void deactivate()
			{
				if (this.mCursor == null)
				{
					return;
				}
				this.mCursor.unregisterContentObserver(this.mContentObserver);
				this.mCursor.unregisterDataSetObserver(this.mDataSetObserver);
				this.mCursor.close();
				this.mCursor = null;
			}

			internal virtual bool isValid()
			{
				return this.mDataValid && this.mCursor != null;
			}

			private class MyContentObserver : android.database.ContentObserver
			{
				public MyContentObserver(MyCursorHelper _enclosing) : base(_enclosing._enclosing.
					mHandler)
				{
					this._enclosing = _enclosing;
				}

				[Sharpen.OverridesMethod(@"android.database.ContentObserver")]
				public override bool deliverSelfNotifications()
				{
					return true;
				}

				[Sharpen.OverridesMethod(@"android.database.ContentObserver")]
				public override void onChange(bool selfChange)
				{
					if (this._enclosing._enclosing.mAutoRequery && this._enclosing.mCursor != null)
					{
						if (false)
						{
							android.util.Log.v("Cursor", "Auto requerying " + this._enclosing.mCursor + " due to update"
								);
						}
						this._enclosing.mDataValid = this._enclosing.mCursor.requery();
					}
				}

				private readonly MyCursorHelper _enclosing;
			}

			private class MyDataSetObserver : android.database.DataSetObserver
			{
				[Sharpen.OverridesMethod(@"android.database.DataSetObserver")]
				public override void onChanged()
				{
					this._enclosing.mDataValid = true;
					this._enclosing._enclosing.notifyDataSetChanged();
				}

				[Sharpen.OverridesMethod(@"android.database.DataSetObserver")]
				public override void onInvalidated()
				{
					this._enclosing.mDataValid = false;
					this._enclosing._enclosing.notifyDataSetInvalidated();
				}

				internal MyDataSetObserver(MyCursorHelper _enclosing)
				{
					this._enclosing = _enclosing;
				}

				private readonly MyCursorHelper _enclosing;
			}

			private readonly CursorTreeAdapter _enclosing;
		}
	}
}

using Sharpen;

namespace android.widget
{
	/// <summary>
	/// Adapter that exposes data from a
	/// <see cref="android.database.Cursor">Cursor</see>
	/// to a
	/// <see cref="ListView">ListView</see>
	/// widget. The Cursor must include
	/// a column named "_id" or this class will not work.
	/// </summary>
	[Sharpen.Sharpened]
	public abstract class CursorAdapter : android.widget.BaseAdapter, android.widget.Filterable
		, android.widget.CursorFilter.CursorFilterClient
	{
		/// <summary>This field should be made private, so it is hidden from the SDK.</summary>
		/// <remarks>
		/// This field should be made private, so it is hidden from the SDK.
		/// <hide></hide>
		/// </remarks>
		protected internal bool mDataValid;

		/// <summary>This field should be made private, so it is hidden from the SDK.</summary>
		/// <remarks>
		/// This field should be made private, so it is hidden from the SDK.
		/// <hide></hide>
		/// </remarks>
		protected internal bool mAutoRequery;

		/// <summary>This field should be made private, so it is hidden from the SDK.</summary>
		/// <remarks>
		/// This field should be made private, so it is hidden from the SDK.
		/// <hide></hide>
		/// </remarks>
		protected internal android.database.Cursor mCursor;

		/// <summary>This field should be made private, so it is hidden from the SDK.</summary>
		/// <remarks>
		/// This field should be made private, so it is hidden from the SDK.
		/// <hide></hide>
		/// </remarks>
		protected internal android.content.Context mContext;

		/// <summary>This field should be made private, so it is hidden from the SDK.</summary>
		/// <remarks>
		/// This field should be made private, so it is hidden from the SDK.
		/// <hide></hide>
		/// </remarks>
		protected internal int mRowIDColumn;

		/// <summary>This field should be made private, so it is hidden from the SDK.</summary>
		/// <remarks>
		/// This field should be made private, so it is hidden from the SDK.
		/// <hide></hide>
		/// </remarks>
		private android.widget.CursorAdapter.ChangeObserver mChangeObserver;

		/// <summary>This field should be made private, so it is hidden from the SDK.</summary>
		/// <remarks>
		/// This field should be made private, so it is hidden from the SDK.
		/// <hide></hide>
		/// </remarks>
		protected internal android.database.DataSetObserver mDataSetObserver;

		/// <summary>This field should be made private, so it is hidden from the SDK.</summary>
		/// <remarks>
		/// This field should be made private, so it is hidden from the SDK.
		/// <hide></hide>
		/// </remarks>
		internal android.widget.CursorFilter mCursorFilter;

		/// <summary>This field should be made private, so it is hidden from the SDK.</summary>
		/// <remarks>
		/// This field should be made private, so it is hidden from the SDK.
		/// <hide></hide>
		/// </remarks>
		protected internal android.widget.FilterQueryProvider mFilterQueryProvider;

		/// <summary>
		/// If set the adapter will call requery() on the cursor whenever a content change
		/// notification is delivered.
		/// </summary>
		/// <remarks>
		/// If set the adapter will call requery() on the cursor whenever a content change
		/// notification is delivered. Implies
		/// <see cref="FLAG_REGISTER_CONTENT_OBSERVER">FLAG_REGISTER_CONTENT_OBSERVER</see>
		/// .
		/// </remarks>
		[System.ObsoleteAttribute(@"This option is discouraged, as it results in Cursor queries being performed on the application's UI thread and thus can cause poor responsiveness or even Application Not Responding errors.  As an alternative, use android.app.LoaderManager with a android.content.CursorLoader ."
			)]
		public const int FLAG_AUTO_REQUERY = unchecked((int)(0x01));

		/// <summary>
		/// If set the adapter will register a content observer on the cursor and will call
		/// <see cref="onContentChanged()">onContentChanged()</see>
		/// when a notification comes in.  Be careful when
		/// using this flag: you will need to unset the current Cursor from the adapter
		/// to avoid leaks due to its registered observers.  This flag is not needed
		/// when using a CursorAdapter with a
		/// <see cref="android.content.CursorLoader">android.content.CursorLoader</see>
		/// .
		/// </summary>
		public const int FLAG_REGISTER_CONTENT_OBSERVER = unchecked((int)(0x02));

		/// <summary>Constructor that always enables auto-requery.</summary>
		/// <remarks>Constructor that always enables auto-requery.</remarks>
		/// <param name="c">The cursor from which to get the data.</param>
		/// <param name="context">The context</param>
		[System.ObsoleteAttribute(@"This option is discouraged, as it results in Cursor queries being performed on the application's UI thread and thus can cause poor responsiveness or even Application Not Responding errors.  As an alternative, use android.app.LoaderManager with a android.content.CursorLoader ."
			)]
		public CursorAdapter(android.content.Context context, android.database.Cursor c)
		{
			init(context, c, FLAG_AUTO_REQUERY);
		}

		/// <summary>Constructor that allows control over auto-requery.</summary>
		/// <remarks>
		/// Constructor that allows control over auto-requery.  It is recommended
		/// you not use this, but instead
		/// <see cref="CursorAdapter(android.content.Context, android.database.Cursor, int)">CursorAdapter(android.content.Context, android.database.Cursor, int)
		/// 	</see>
		/// .
		/// When using this constructor,
		/// <see cref="FLAG_REGISTER_CONTENT_OBSERVER">FLAG_REGISTER_CONTENT_OBSERVER</see>
		/// will always be set.
		/// </remarks>
		/// <param name="c">The cursor from which to get the data.</param>
		/// <param name="context">The context</param>
		/// <param name="autoRequery">
		/// If true the adapter will call requery() on the
		/// cursor whenever it changes so the most recent
		/// data is always displayed.  Using true here is discouraged.
		/// </param>
		public CursorAdapter(android.content.Context context, android.database.Cursor c, 
			bool autoRequery)
		{
			init(context, c, autoRequery ? FLAG_AUTO_REQUERY : FLAG_REGISTER_CONTENT_OBSERVER
				);
		}

		/// <summary>Recommended constructor.</summary>
		/// <remarks>Recommended constructor.</remarks>
		/// <param name="c">The cursor from which to get the data.</param>
		/// <param name="context">The context</param>
		/// <param name="flags">
		/// Flags used to determine the behavior of the adapter; may
		/// be any combination of
		/// <see cref="FLAG_AUTO_REQUERY">FLAG_AUTO_REQUERY</see>
		/// and
		/// <see cref="FLAG_REGISTER_CONTENT_OBSERVER">FLAG_REGISTER_CONTENT_OBSERVER</see>
		/// .
		/// </param>
		public CursorAdapter(android.content.Context context, android.database.Cursor c, 
			int flags)
		{
			init(context, c, flags);
		}

		[System.ObsoleteAttribute(@"Don't use this, use the normal constructor.  This will be removed in the future."
			)]
		protected internal virtual void init(android.content.Context context, android.database.Cursor
			 c, bool autoRequery)
		{
			init(context, c, autoRequery ? FLAG_AUTO_REQUERY : FLAG_REGISTER_CONTENT_OBSERVER
				);
		}

		internal virtual void init(android.content.Context context, android.database.Cursor
			 c, int flags)
		{
			if ((flags & FLAG_AUTO_REQUERY) == FLAG_AUTO_REQUERY)
			{
				flags |= FLAG_REGISTER_CONTENT_OBSERVER;
				mAutoRequery = true;
			}
			else
			{
				mAutoRequery = false;
			}
			bool cursorPresent = c != null;
			mCursor = c;
			mDataValid = cursorPresent;
			mContext = context;
			mRowIDColumn = cursorPresent ? c.getColumnIndexOrThrow("_id") : -1;
			if ((flags & FLAG_REGISTER_CONTENT_OBSERVER) == FLAG_REGISTER_CONTENT_OBSERVER)
			{
				mChangeObserver = new android.widget.CursorAdapter.ChangeObserver(this);
				mDataSetObserver = new android.widget.CursorAdapter.MyDataSetObserver(this);
			}
			else
			{
				mChangeObserver = null;
				mDataSetObserver = null;
			}
			if (cursorPresent)
			{
				if (mChangeObserver != null)
				{
					c.registerContentObserver(mChangeObserver);
				}
				if (mDataSetObserver != null)
				{
					c.registerDataSetObserver(mDataSetObserver);
				}
			}
		}

		/// <summary>Returns the cursor.</summary>
		/// <remarks>Returns the cursor.</remarks>
		/// <returns>the cursor.</returns>
		[Sharpen.ImplementsInterface(@"android.widget.CursorFilter.CursorFilterClient")]
		public virtual android.database.Cursor getCursor()
		{
			return mCursor;
		}

		/// <seealso cref="Adapter.getCount()">Adapter.getCount()</seealso>
		[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
		public override int getCount()
		{
			if (mDataValid && mCursor != null)
			{
				return mCursor.getCount();
			}
			else
			{
				return 0;
			}
		}

		/// <seealso cref="Adapter.getItem(int)">Adapter.getItem(int)</seealso>
		[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
		public override object getItem(int position)
		{
			if (mDataValid && mCursor != null)
			{
				mCursor.moveToPosition(position);
				return mCursor;
			}
			else
			{
				return null;
			}
		}

		/// <seealso cref="Adapter.getItemId(int)">Adapter.getItemId(int)</seealso>
		[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
		public override long getItemId(int position)
		{
			if (mDataValid && mCursor != null)
			{
				if (mCursor.moveToPosition(position))
				{
					return mCursor.getLong(mRowIDColumn);
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

		[Sharpen.OverridesMethod(@"android.widget.BaseAdapter")]
		public override bool hasStableIds()
		{
			return true;
		}

		/// <seealso cref="Adapter.getView(int, android.view.View, android.view.ViewGroup)">Adapter.getView(int, android.view.View, android.view.ViewGroup)
		/// 	</seealso>
		[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
		public override android.view.View getView(int position, android.view.View convertView
			, android.view.ViewGroup parent)
		{
			if (!mDataValid)
			{
				throw new System.InvalidOperationException("this should only be called when the cursor is valid"
					);
			}
			if (!mCursor.moveToPosition(position))
			{
				throw new System.InvalidOperationException("couldn't move cursor to position " + 
					position);
			}
			android.view.View v;
			if (convertView == null)
			{
				v = newView(mContext, mCursor, parent);
			}
			else
			{
				v = convertView;
			}
			bindView(v, mContext, mCursor);
			return v;
		}

		[Sharpen.OverridesMethod(@"android.widget.BaseAdapter")]
		public override android.view.View getDropDownView(int position, android.view.View
			 convertView, android.view.ViewGroup parent)
		{
			if (mDataValid)
			{
				mCursor.moveToPosition(position);
				android.view.View v;
				if (convertView == null)
				{
					v = newDropDownView(mContext, mCursor, parent);
				}
				else
				{
					v = convertView;
				}
				bindView(v, mContext, mCursor);
				return v;
			}
			else
			{
				return null;
			}
		}

		/// <summary>Makes a new view to hold the data pointed to by cursor.</summary>
		/// <remarks>Makes a new view to hold the data pointed to by cursor.</remarks>
		/// <param name="context">Interface to application's global information</param>
		/// <param name="cursor">
		/// The cursor from which to get the data. The cursor is already
		/// moved to the correct position.
		/// </param>
		/// <param name="parent">The parent to which the new view is attached to</param>
		/// <returns>the newly created view.</returns>
		public abstract android.view.View newView(android.content.Context context, android.database.Cursor
			 cursor, android.view.ViewGroup parent);

		/// <summary>Makes a new drop down view to hold the data pointed to by cursor.</summary>
		/// <remarks>Makes a new drop down view to hold the data pointed to by cursor.</remarks>
		/// <param name="context">Interface to application's global information</param>
		/// <param name="cursor">
		/// The cursor from which to get the data. The cursor is already
		/// moved to the correct position.
		/// </param>
		/// <param name="parent">The parent to which the new view is attached to</param>
		/// <returns>the newly created view.</returns>
		public virtual android.view.View newDropDownView(android.content.Context context, 
			android.database.Cursor cursor, android.view.ViewGroup parent)
		{
			return newView(context, cursor, parent);
		}

		/// <summary>Bind an existing view to the data pointed to by cursor</summary>
		/// <param name="view">Existing view, returned earlier by newView</param>
		/// <param name="context">Interface to application's global information</param>
		/// <param name="cursor">
		/// The cursor from which to get the data. The cursor is already
		/// moved to the correct position.
		/// </param>
		public abstract void bindView(android.view.View view, android.content.Context context
			, android.database.Cursor cursor);

		/// <summary>Change the underlying cursor to a new cursor.</summary>
		/// <remarks>
		/// Change the underlying cursor to a new cursor. If there is an existing cursor it will be
		/// closed.
		/// </remarks>
		/// <param name="cursor">The new cursor to be used</param>
		[Sharpen.ImplementsInterface(@"android.widget.CursorFilter.CursorFilterClient")]
		public virtual void changeCursor(android.database.Cursor cursor)
		{
			android.database.Cursor old = swapCursor(cursor);
			if (old != null)
			{
				old.close();
			}
		}

		/// <summary>Swap in a new Cursor, returning the old Cursor.</summary>
		/// <remarks>
		/// Swap in a new Cursor, returning the old Cursor.  Unlike
		/// <see cref="changeCursor(android.database.Cursor)">changeCursor(android.database.Cursor)
		/// 	</see>
		/// , the returned old Cursor is <em>not</em>
		/// closed.
		/// </remarks>
		/// <param name="newCursor">The new cursor to be used.</param>
		/// <returns>
		/// Returns the previously set Cursor, or null if there wasa not one.
		/// If the given new Cursor is the same instance is the previously set
		/// Cursor, null is also returned.
		/// </returns>
		public virtual android.database.Cursor swapCursor(android.database.Cursor newCursor
			)
		{
			if (newCursor == mCursor)
			{
				return null;
			}
			android.database.Cursor oldCursor = mCursor;
			if (oldCursor != null)
			{
				if (mChangeObserver != null)
				{
					oldCursor.unregisterContentObserver(mChangeObserver);
				}
				if (mDataSetObserver != null)
				{
					oldCursor.unregisterDataSetObserver(mDataSetObserver);
				}
			}
			mCursor = newCursor;
			if (newCursor != null)
			{
				if (mChangeObserver != null)
				{
					newCursor.registerContentObserver(mChangeObserver);
				}
				if (mDataSetObserver != null)
				{
					newCursor.registerDataSetObserver(mDataSetObserver);
				}
				mRowIDColumn = newCursor.getColumnIndexOrThrow("_id");
				mDataValid = true;
				// notify the observers about the new cursor
				notifyDataSetChanged();
			}
			else
			{
				mRowIDColumn = -1;
				mDataValid = false;
				// notify the observers about the lack of a data set
				notifyDataSetInvalidated();
			}
			return oldCursor;
		}

		/// <summary><p>Converts the cursor into a CharSequence.</summary>
		/// <remarks>
		/// <p>Converts the cursor into a CharSequence. Subclasses should override this
		/// method to convert their results. The default implementation returns an
		/// empty String for null values or the default String representation of
		/// the value.</p>
		/// </remarks>
		/// <param name="cursor">the cursor to convert to a CharSequence</param>
		/// <returns>a CharSequence representing the value</returns>
		[Sharpen.ImplementsInterface(@"android.widget.CursorFilter.CursorFilterClient")]
		public virtual java.lang.CharSequence convertToString(android.database.Cursor cursor
			)
		{
			return java.lang.CharSequenceProxy.Wrap(cursor == null ? string.Empty : cursor.ToString
				());
		}

		/// <summary>Runs a query with the specified constraint.</summary>
		/// <remarks>
		/// Runs a query with the specified constraint. This query is requested
		/// by the filter attached to this adapter.
		/// The query is provided by a
		/// <see cref="FilterQueryProvider">FilterQueryProvider</see>
		/// .
		/// If no provider is specified, the current cursor is not filtered and returned.
		/// After this method returns the resulting cursor is passed to
		/// <see cref="changeCursor(android.database.Cursor)">changeCursor(android.database.Cursor)
		/// 	</see>
		/// and the previous cursor is closed.
		/// This method is always executed on a background thread, not on the
		/// application's main thread (or UI thread.)
		/// Contract: when constraint is null or empty, the original results,
		/// prior to any filtering, must be returned.
		/// </remarks>
		/// <param name="constraint">the constraint with which the query must be filtered</param>
		/// <returns>a Cursor representing the results of the new query</returns>
		/// <seealso cref="getFilter()">getFilter()</seealso>
		/// <seealso cref="getFilterQueryProvider()">getFilterQueryProvider()</seealso>
		/// <seealso cref="setFilterQueryProvider(FilterQueryProvider)">setFilterQueryProvider(FilterQueryProvider)
		/// 	</seealso>
		[Sharpen.ImplementsInterface(@"android.widget.CursorFilter.CursorFilterClient")]
		public virtual android.database.Cursor runQueryOnBackgroundThread(java.lang.CharSequence
			 constraint)
		{
			if (mFilterQueryProvider != null)
			{
				return mFilterQueryProvider.runQuery(constraint);
			}
			return mCursor;
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

		/// <summary>Returns the query filter provider used for filtering.</summary>
		/// <remarks>
		/// Returns the query filter provider used for filtering. When the
		/// provider is null, no filtering occurs.
		/// </remarks>
		/// <returns>the current filter query provider or null if it does not exist</returns>
		/// <seealso cref="setFilterQueryProvider(FilterQueryProvider)">setFilterQueryProvider(FilterQueryProvider)
		/// 	</seealso>
		/// <seealso cref="runQueryOnBackgroundThread(java.lang.CharSequence)">runQueryOnBackgroundThread(java.lang.CharSequence)
		/// 	</seealso>
		public virtual android.widget.FilterQueryProvider getFilterQueryProvider()
		{
			return mFilterQueryProvider;
		}

		/// <summary>Sets the query filter provider used to filter the current Cursor.</summary>
		/// <remarks>
		/// Sets the query filter provider used to filter the current Cursor.
		/// The provider's
		/// <see cref="FilterQueryProvider.runQuery(java.lang.CharSequence)">FilterQueryProvider.runQuery(java.lang.CharSequence)
		/// 	</see>
		/// method is invoked when filtering is requested by a client of
		/// this adapter.
		/// </remarks>
		/// <param name="filterQueryProvider">the filter query provider or null to remove it</param>
		/// <seealso cref="getFilterQueryProvider()">getFilterQueryProvider()</seealso>
		/// <seealso cref="runQueryOnBackgroundThread(java.lang.CharSequence)">runQueryOnBackgroundThread(java.lang.CharSequence)
		/// 	</seealso>
		public virtual void setFilterQueryProvider(android.widget.FilterQueryProvider filterQueryProvider
			)
		{
			mFilterQueryProvider = filterQueryProvider;
		}

		/// <summary>
		/// Called when the
		/// <see cref="android.database.ContentObserver">android.database.ContentObserver</see>
		/// on the cursor receives a change notification.
		/// The default implementation provides the auto-requery logic, but may be overridden by
		/// sub classes.
		/// </summary>
		/// <seealso cref="android.database.ContentObserver.onChange(bool)">android.database.ContentObserver.onChange(bool)
		/// 	</seealso>
		protected internal virtual void onContentChanged()
		{
			if (mAutoRequery && mCursor != null && !mCursor.isClosed())
			{
				if (false)
				{
					android.util.Log.v("Cursor", "Auto requerying " + mCursor + " due to update");
				}
				mDataValid = mCursor.requery();
			}
		}

		private class ChangeObserver : android.database.ContentObserver
		{
			public ChangeObserver(CursorAdapter _enclosing) : base(new android.os.Handler())
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
				this._enclosing.onContentChanged();
			}

			private readonly CursorAdapter _enclosing;
		}

		private class MyDataSetObserver : android.database.DataSetObserver
		{
			[Sharpen.OverridesMethod(@"android.database.DataSetObserver")]
			public override void onChanged()
			{
				this._enclosing.mDataValid = true;
				this._enclosing.notifyDataSetChanged();
			}

			[Sharpen.OverridesMethod(@"android.database.DataSetObserver")]
			public override void onInvalidated()
			{
				this._enclosing.mDataValid = false;
				this._enclosing.notifyDataSetInvalidated();
			}

			internal MyDataSetObserver(CursorAdapter _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly CursorAdapter _enclosing;
		}
	}
}

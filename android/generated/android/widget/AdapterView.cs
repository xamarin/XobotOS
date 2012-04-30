using Sharpen;

namespace android.widget
{
	/// <summary>
	/// An AdapterView is a view whose children are determined by an
	/// <see cref="Adapter">Adapter</see>
	/// .
	/// <p>
	/// See
	/// <see cref="ListView">ListView</see>
	/// ,
	/// <see cref="GridView">GridView</see>
	/// ,
	/// <see cref="Spinner">Spinner</see>
	/// and
	/// <see cref="Gallery">Gallery</see>
	/// for commonly used subclasses of AdapterView.
	/// <div class="special reference">
	/// <h3>Developer Guides</h3>
	/// <p>For more information about using AdapterView, read the
	/// &lt;a href="
	/// <docRoot></docRoot>
	/// guide/topics/ui/binding.html"&gt;Binding to Data with AdapterView</a>
	/// developer guide.</p></div>
	/// </summary>
	[Sharpen.Sharpened]
	public static partial class AdapterView
	{
		/// <summary>
		/// The item view type returned by
		/// <see cref="Adapter.getItemViewType(int)">Adapter.getItemViewType(int)</see>
		/// when
		/// the adapter does not want the item's view recycled.
		/// </summary>
		public const int ITEM_VIEW_TYPE_IGNORE = -1;

		/// <summary>
		/// The item view type returned by
		/// <see cref="Adapter.getItemViewType(int)">Adapter.getItemViewType(int)</see>
		/// when
		/// the item is a header or footer.
		/// </summary>
		public const int ITEM_VIEW_TYPE_HEADER_OR_FOOTER = -2;

		/// <summary>Sync based on the selected child</summary>
		internal const int SYNC_SELECTED_POSITION = 0;

		/// <summary>Sync based on the first child displayed</summary>
		internal const int SYNC_FIRST_POSITION = 1;

		/// <summary>
		/// Maximum amount of time to spend in
		/// <see cref="AdapterView{T}.findSyncPosition()">AdapterView&lt;T&gt;.findSyncPosition()
		/// 	</see>
		/// </summary>
		internal const int SYNC_MAX_DURATION_MILLIS = 100;

		/// <summary>Represents an invalid position.</summary>
		/// <remarks>
		/// Represents an invalid position. All valid positions are in the range 0 to 1 less than the
		/// number of items in the current adapter.
		/// </remarks>
		public const int INVALID_POSITION = -1;

		/// <summary>Represents an empty or invalid row id</summary>
		public const long INVALID_ROW_ID = long.MinValue;

		/// <summary>
		/// Interface definition for a callback to be invoked when an item in this
		/// AdapterView has been clicked.
		/// </summary>
		/// <remarks>
		/// Interface definition for a callback to be invoked when an item in this
		/// AdapterView has been clicked.
		/// </remarks>
		public interface OnItemClickListener
		{
			/// <summary>
			/// Callback method to be invoked when an item in this AdapterView has
			/// been clicked.
			/// </summary>
			/// <remarks>
			/// Callback method to be invoked when an item in this AdapterView has
			/// been clicked.
			/// <p>
			/// Implementers can call getItemAtPosition(position) if they need
			/// to access the data associated with the selected item.
			/// </remarks>
			/// <param name="parent">The AdapterView where the click happened.</param>
			/// <param name="view">
			/// The view within the AdapterView that was clicked (this
			/// will be a view provided by the adapter)
			/// </param>
			/// <param name="position">The position of the view in the adapter.</param>
			/// <param name="id">The row id of the item that was clicked.</param>
			void onItemClick(object parent, android.view.View view, int position, long id);
		}

		/// <summary>
		/// Interface definition for a callback to be invoked when an item in this
		/// view has been clicked and held.
		/// </summary>
		/// <remarks>
		/// Interface definition for a callback to be invoked when an item in this
		/// view has been clicked and held.
		/// </remarks>
		public interface OnItemLongClickListener
		{
			/// <summary>
			/// Callback method to be invoked when an item in this view has been
			/// clicked and held.
			/// </summary>
			/// <remarks>
			/// Callback method to be invoked when an item in this view has been
			/// clicked and held.
			/// Implementers can call getItemAtPosition(position) if they need to access
			/// the data associated with the selected item.
			/// </remarks>
			/// <param name="parent">The AbsListView where the click happened</param>
			/// <param name="view">The view within the AbsListView that was clicked</param>
			/// <param name="position">The position of the view in the list</param>
			/// <param name="id">The row id of the item that was clicked</param>
			/// <returns>true if the callback consumed the long click, false otherwise</returns>
			bool onItemLongClick(object parent, android.view.View view, int position, long id
				);
		}

		/// <summary>
		/// Interface definition for a callback to be invoked when
		/// an item in this view has been selected.
		/// </summary>
		/// <remarks>
		/// Interface definition for a callback to be invoked when
		/// an item in this view has been selected.
		/// </remarks>
		public interface OnItemSelectedListener
		{
			/// <summary>
			/// <p>Callback method to be invoked when an item in this view has been
			/// selected.
			/// </summary>
			/// <remarks>
			/// <p>Callback method to be invoked when an item in this view has been
			/// selected. This callback is invoked only when the newly selected
			/// position is different from the previously selected position or if
			/// there was no selected item.</p>
			/// Impelmenters can call getItemAtPosition(position) if they need to access the
			/// data associated with the selected item.
			/// </remarks>
			/// <param name="parent">The AdapterView where the selection happened</param>
			/// <param name="view">The view within the AdapterView that was clicked</param>
			/// <param name="position">The position of the view in the adapter</param>
			/// <param name="id">The row id of the item that is selected</param>
			void onItemSelected(object parent, android.view.View view, int position, long id);

			/// <summary>
			/// Callback method to be invoked when the selection disappears from this
			/// view.
			/// </summary>
			/// <remarks>
			/// Callback method to be invoked when the selection disappears from this
			/// view. The selection can disappear for instance when touch is activated
			/// or when the adapter becomes empty.
			/// </remarks>
			/// <param name="parent">The AdapterView that now contains no selected item.</param>
			void onNothingSelected(object parent);
		}

		/// <summary>
		/// Extra menu information provided to the
		/// <see cref="android.view.View.OnCreateContextMenuListener.onCreateContextMenu(android.view.ContextMenu, android.view.View, android.view.ContextMenuClass.ContextMenuInfo)
		/// 	"></see>
		/// callback when a context menu is brought up for this AdapterView.
		/// </summary>
		public class AdapterContextMenuInfo : android.view.ContextMenuClass.ContextMenuInfo
		{
			public AdapterContextMenuInfo(android.view.View targetView, int position, long id
				)
			{
				this.targetView = targetView;
				this.position = position;
				this.id = id;
			}

			/// <summary>The child view for which the context menu is being displayed.</summary>
			/// <remarks>
			/// The child view for which the context menu is being displayed. This
			/// will be one of the children of this AdapterView.
			/// </remarks>
			public android.view.View targetView;

			/// <summary>
			/// The position in the adapter for which the context menu is being
			/// displayed.
			/// </summary>
			/// <remarks>
			/// The position in the adapter for which the context menu is being
			/// displayed.
			/// </remarks>
			public int position;

			/// <summary>The row id of the item for which the context menu is being displayed.</summary>
			/// <remarks>The row id of the item for which the context menu is being displayed.</remarks>
			public long id;
		}
	}

	/// <summary>
	/// An AdapterView is a view whose children are determined by an
	/// <see cref="Adapter">Adapter</see>
	/// .
	/// <p>
	/// See
	/// <see cref="ListView">ListView</see>
	/// ,
	/// <see cref="GridView">GridView</see>
	/// ,
	/// <see cref="Spinner">Spinner</see>
	/// and
	/// <see cref="Gallery">Gallery</see>
	/// for commonly used subclasses of AdapterView.
	/// <div class="special reference">
	/// <h3>Developer Guides</h3>
	/// <p>For more information about using AdapterView, read the
	/// &lt;a href="
	/// <docRoot></docRoot>
	/// guide/topics/ui/binding.html"&gt;Binding to Data with AdapterView</a>
	/// developer guide.</p></div>
	/// </summary>
	[Sharpen.Sharpened]
	public abstract partial class AdapterView<T> : android.view.ViewGroup where T:android.widget.Adapter
	{
		/// <summary>The position of the first child displayed</summary>
		internal int mFirstPosition = 0;

		/// <summary>
		/// The offset in pixels from the top of the AdapterView to the top
		/// of the view to select during the next layout.
		/// </summary>
		/// <remarks>
		/// The offset in pixels from the top of the AdapterView to the top
		/// of the view to select during the next layout.
		/// </remarks>
		internal int mSpecificTop;

		/// <summary>Position from which to start looking for mSyncRowId</summary>
		internal int mSyncPosition;

		/// <summary>Row id to look for when data has changed</summary>
		internal long mSyncRowId = android.widget.AdapterView.INVALID_ROW_ID;

		/// <summary>Height of the view when mSyncPosition and mSyncRowId where set</summary>
		internal long mSyncHeight;

		/// <summary>True if we need to sync to mSyncRowId</summary>
		internal bool mNeedSync = false;

		/// <summary>Indicates whether to sync based on the selection or position.</summary>
		/// <remarks>
		/// Indicates whether to sync based on the selection or position. Possible
		/// values are
		/// <see cref="android.widget.AdapterView.SYNC_SELECTED_POSITION">android.widget.AdapterView.SYNC_SELECTED_POSITION
		/// 	</see>
		/// or
		/// <see cref="android.widget.AdapterView.SYNC_FIRST_POSITION">android.widget.AdapterView.SYNC_FIRST_POSITION
		/// 	</see>
		/// .
		/// </remarks>
		internal int mSyncMode;

		/// <summary>Our height after the last layout</summary>
		private int mLayoutHeight;

		/// <summary>Indicates that this view is currently being laid out.</summary>
		/// <remarks>Indicates that this view is currently being laid out.</remarks>
		internal bool mInLayout = false;

		/// <summary>The listener that receives notifications when an item is selected.</summary>
		/// <remarks>The listener that receives notifications when an item is selected.</remarks>
		internal android.widget.AdapterView.OnItemSelectedListener mOnItemSelectedListener;

		/// <summary>The listener that receives notifications when an item is clicked.</summary>
		/// <remarks>The listener that receives notifications when an item is clicked.</remarks>
		internal android.widget.AdapterView.OnItemClickListener mOnItemClickListener;

		/// <summary>The listener that receives notifications when an item is long clicked.</summary>
		/// <remarks>The listener that receives notifications when an item is long clicked.</remarks>
		internal android.widget.AdapterView.OnItemLongClickListener mOnItemLongClickListener;

		/// <summary>True if the data has changed since the last layout</summary>
		internal bool mDataChanged;

		/// <summary>
		/// The position within the adapter's data set of the item to select
		/// during the next layout.
		/// </summary>
		/// <remarks>
		/// The position within the adapter's data set of the item to select
		/// during the next layout.
		/// </remarks>
		internal int mNextSelectedPosition = android.widget.AdapterView.INVALID_POSITION;

		/// <summary>The item id of the item to select during the next layout.</summary>
		/// <remarks>The item id of the item to select during the next layout.</remarks>
		internal long mNextSelectedRowId = android.widget.AdapterView.INVALID_ROW_ID;

		/// <summary>The position within the adapter's data set of the currently selected item.
		/// 	</summary>
		/// <remarks>The position within the adapter's data set of the currently selected item.
		/// 	</remarks>
		internal int mSelectedPosition = android.widget.AdapterView.INVALID_POSITION;

		/// <summary>The item id of the currently selected item.</summary>
		/// <remarks>The item id of the currently selected item.</remarks>
		internal long mSelectedRowId = android.widget.AdapterView.INVALID_ROW_ID;

		/// <summary>View to show if there are no items to show.</summary>
		/// <remarks>View to show if there are no items to show.</remarks>
		private android.view.View mEmptyView;

		/// <summary>The number of items in the current adapter.</summary>
		/// <remarks>The number of items in the current adapter.</remarks>
		internal int mItemCount;

		/// <summary>The number of items in the adapter before a data changed event occurred.
		/// 	</summary>
		/// <remarks>The number of items in the adapter before a data changed event occurred.
		/// 	</remarks>
		internal int mOldItemCount;

		/// <summary>The last selected position we used when notifying</summary>
		internal int mOldSelectedPosition = android.widget.AdapterView.INVALID_POSITION;

		/// <summary>The id of the last selected position we used when notifying</summary>
		internal long mOldSelectedRowId = android.widget.AdapterView.INVALID_ROW_ID;

		/// <summary>Indicates what focusable state is requested when calling setFocusable().
		/// 	</summary>
		/// <remarks>
		/// Indicates what focusable state is requested when calling setFocusable().
		/// In addition to this, this view has other criteria for actually
		/// determining the focusable state (such as whether its empty or the text
		/// filter is shown).
		/// </remarks>
		/// <seealso cref="AdapterView{T}.setFocusable(bool)">AdapterView&lt;T&gt;.setFocusable(bool)
		/// 	</seealso>
		/// <seealso cref="AdapterView{T}.checkFocus()">AdapterView&lt;T&gt;.checkFocus()</seealso>
		private bool mDesiredFocusableState;

		private bool mDesiredFocusableInTouchModeState;

		private android.widget.AdapterView<T>.SelectionNotifier mSelectionNotifier;

		/// <summary>When set to true, calls to requestLayout() will not propagate up the parent hierarchy.
		/// 	</summary>
		/// <remarks>
		/// When set to true, calls to requestLayout() will not propagate up the parent hierarchy.
		/// This is used to layout the children during a layout pass.
		/// </remarks>
		internal bool mBlockLayoutRequests = false;

		public AdapterView(android.content.Context context) : base(context)
		{
		}

		public AdapterView(android.content.Context context, android.util.AttributeSet attrs
			) : base(context, attrs)
		{
		}

		public AdapterView(android.content.Context context, android.util.AttributeSet attrs
			, int defStyle) : base(context, attrs, defStyle)
		{
		}

		/// <summary>
		/// Register a callback to be invoked when an item in this AdapterView has
		/// been clicked.
		/// </summary>
		/// <remarks>
		/// Register a callback to be invoked when an item in this AdapterView has
		/// been clicked.
		/// </remarks>
		/// <param name="listener">The callback that will be invoked.</param>
		public virtual void setOnItemClickListener(android.widget.AdapterView.OnItemClickListener
			 listener)
		{
			mOnItemClickListener = listener;
		}

		/// <returns>
		/// The callback to be invoked with an item in this AdapterView has
		/// been clicked, or null id no callback has been set.
		/// </returns>
		public android.widget.AdapterView.OnItemClickListener getOnItemClickListener()
		{
			return mOnItemClickListener;
		}

		/// <summary>Call the OnItemClickListener, if it is defined.</summary>
		/// <remarks>Call the OnItemClickListener, if it is defined.</remarks>
		/// <param name="view">The view within the AdapterView that was clicked.</param>
		/// <param name="position">The position of the view in the adapter.</param>
		/// <param name="id">The row id of the item that was clicked.</param>
		/// <returns>
		/// True if there was an assigned OnItemClickListener that was
		/// called, false otherwise is returned.
		/// </returns>
		public virtual bool performItemClick(android.view.View view, int position, long id
			)
		{
			if (mOnItemClickListener != null)
			{
				playSoundEffect(android.view.SoundEffectConstants.CLICK);
				if (view != null)
				{
					view.sendAccessibilityEvent(android.view.accessibility.AccessibilityEvent.TYPE_VIEW_CLICKED
						);
				}
				mOnItemClickListener.onItemClick(this, view, position, id);
				return true;
			}
			return false;
		}

		/// <summary>
		/// Register a callback to be invoked when an item in this AdapterView has
		/// been clicked and held
		/// </summary>
		/// <param name="listener">The callback that will run</param>
		public virtual void setOnItemLongClickListener(android.widget.AdapterView.OnItemLongClickListener
			 listener)
		{
			if (!isLongClickable())
			{
				setLongClickable(true);
			}
			mOnItemLongClickListener = listener;
		}

		/// <returns>
		/// The callback to be invoked with an item in this AdapterView has
		/// been clicked and held, or null id no callback as been set.
		/// </returns>
		public android.widget.AdapterView.OnItemLongClickListener getOnItemLongClickListener
			()
		{
			return mOnItemLongClickListener;
		}

		/// <summary>
		/// Register a callback to be invoked when an item in this AdapterView has
		/// been selected.
		/// </summary>
		/// <remarks>
		/// Register a callback to be invoked when an item in this AdapterView has
		/// been selected.
		/// </remarks>
		/// <param name="listener">The callback that will run</param>
		public virtual void setOnItemSelectedListener(android.widget.AdapterView.OnItemSelectedListener
			 listener)
		{
			mOnItemSelectedListener = listener;
		}

		public android.widget.AdapterView.OnItemSelectedListener getOnItemSelectedListener
			()
		{
			return mOnItemSelectedListener;
		}

		/// <summary>Returns the adapter currently associated with this widget.</summary>
		/// <remarks>Returns the adapter currently associated with this widget.</remarks>
		/// <returns>The adapter used to provide this view's content.</returns>
		public abstract T getAdapter();

		/// <summary>
		/// Sets the adapter that provides the data and the views to represent the data
		/// in this widget.
		/// </summary>
		/// <remarks>
		/// Sets the adapter that provides the data and the views to represent the data
		/// in this widget.
		/// </remarks>
		/// <param name="adapter">The adapter to use to create this view's content.</param>
		public abstract void setAdapter(T adapter);

		/// <summary>This method is not supported and throws an UnsupportedOperationException when called.
		/// 	</summary>
		/// <remarks>This method is not supported and throws an UnsupportedOperationException when called.
		/// 	</remarks>
		/// <param name="child">Ignored.</param>
		/// <exception cref="System.NotSupportedException">Every time this method is invoked.
		/// 	</exception>
		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override void addView(android.view.View child)
		{
			throw new System.NotSupportedException("addView(View) is not supported in AdapterView"
				);
		}

		/// <summary>This method is not supported and throws an UnsupportedOperationException when called.
		/// 	</summary>
		/// <remarks>This method is not supported and throws an UnsupportedOperationException when called.
		/// 	</remarks>
		/// <param name="child">Ignored.</param>
		/// <param name="index">Ignored.</param>
		/// <exception cref="System.NotSupportedException">Every time this method is invoked.
		/// 	</exception>
		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override void addView(android.view.View child, int index)
		{
			throw new System.NotSupportedException("addView(View, int) is not supported in AdapterView"
				);
		}

		/// <summary>This method is not supported and throws an UnsupportedOperationException when called.
		/// 	</summary>
		/// <remarks>This method is not supported and throws an UnsupportedOperationException when called.
		/// 	</remarks>
		/// <param name="child">Ignored.</param>
		/// <param name="params">Ignored.</param>
		/// <exception cref="System.NotSupportedException">Every time this method is invoked.
		/// 	</exception>
		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override void addView(android.view.View child, android.view.ViewGroup.LayoutParams
			 @params)
		{
			throw new System.NotSupportedException("addView(View, LayoutParams) " + "is not supported in AdapterView"
				);
		}

		/// <summary>This method is not supported and throws an UnsupportedOperationException when called.
		/// 	</summary>
		/// <remarks>This method is not supported and throws an UnsupportedOperationException when called.
		/// 	</remarks>
		/// <param name="child">Ignored.</param>
		/// <param name="index">Ignored.</param>
		/// <param name="params">Ignored.</param>
		/// <exception cref="System.NotSupportedException">Every time this method is invoked.
		/// 	</exception>
		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override void addView(android.view.View child, int index, android.view.ViewGroup
			.LayoutParams @params)
		{
			throw new System.NotSupportedException("addView(View, int, LayoutParams) " + "is not supported in AdapterView"
				);
		}

		/// <summary>This method is not supported and throws an UnsupportedOperationException when called.
		/// 	</summary>
		/// <remarks>This method is not supported and throws an UnsupportedOperationException when called.
		/// 	</remarks>
		/// <param name="child">Ignored.</param>
		/// <exception cref="System.NotSupportedException">Every time this method is invoked.
		/// 	</exception>
		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override void removeView(android.view.View child)
		{
			throw new System.NotSupportedException("removeView(View) is not supported in AdapterView"
				);
		}

		/// <summary>This method is not supported and throws an UnsupportedOperationException when called.
		/// 	</summary>
		/// <remarks>This method is not supported and throws an UnsupportedOperationException when called.
		/// 	</remarks>
		/// <param name="index">Ignored.</param>
		/// <exception cref="System.NotSupportedException">Every time this method is invoked.
		/// 	</exception>
		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override void removeViewAt(int index)
		{
			throw new System.NotSupportedException("removeViewAt(int) is not supported in AdapterView"
				);
		}

		/// <summary>This method is not supported and throws an UnsupportedOperationException when called.
		/// 	</summary>
		/// <remarks>This method is not supported and throws an UnsupportedOperationException when called.
		/// 	</remarks>
		/// <exception cref="System.NotSupportedException">Every time this method is invoked.
		/// 	</exception>
		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override void removeAllViews()
		{
			throw new System.NotSupportedException("removeAllViews() is not supported in AdapterView"
				);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onLayout(bool changed, int left, int top, int right
			, int bottom)
		{
			mLayoutHeight = getHeight();
		}

		/// <summary>Return the position of the currently selected item within the adapter's data set
		/// 	</summary>
		/// <returns>
		/// int Position (starting at 0), or
		/// <see cref="android.widget.AdapterView.INVALID_POSITION">android.widget.AdapterView.INVALID_POSITION
		/// 	</see>
		/// if there is nothing selected.
		/// </returns>
		[android.view.ViewDebug.CapturedViewProperty]
		public virtual int getSelectedItemPosition()
		{
			return mNextSelectedPosition;
		}

		/// <returns>
		/// The id corresponding to the currently selected item, or
		/// <see cref="android.widget.AdapterView.INVALID_ROW_ID">android.widget.AdapterView.INVALID_ROW_ID
		/// 	</see>
		/// if nothing is selected.
		/// </returns>
		[android.view.ViewDebug.CapturedViewProperty]
		public virtual long getSelectedItemId()
		{
			return mNextSelectedRowId;
		}

		/// <returns>
		/// The view corresponding to the currently selected item, or null
		/// if nothing is selected
		/// </returns>
		public abstract android.view.View getSelectedView();

		/// <returns>
		/// The data corresponding to the currently selected item, or
		/// null if there is nothing selected.
		/// </returns>
		public virtual object getSelectedItem()
		{
			T adapter = getAdapter();
			int selection = getSelectedItemPosition();
			if ((object)adapter != null && adapter.getCount() > 0 && selection >= 0)
			{
				return adapter.getItem(selection);
			}
			else
			{
				return null;
			}
		}

		/// <returns>
		/// The number of items owned by the Adapter associated with this
		/// AdapterView. (This is the number of data items, which may be
		/// larger than the number of visible views.)
		/// </returns>
		[android.view.ViewDebug.CapturedViewProperty]
		public virtual int getCount()
		{
			return mItemCount;
		}

		/// <summary>
		/// Get the position within the adapter's data set for the view, where view is a an adapter item
		/// or a descendant of an adapter item.
		/// </summary>
		/// <remarks>
		/// Get the position within the adapter's data set for the view, where view is a an adapter item
		/// or a descendant of an adapter item.
		/// </remarks>
		/// <param name="view">
		/// an adapter item, or a descendant of an adapter item. This must be visible in this
		/// AdapterView at the time of the call.
		/// </param>
		/// <returns>
		/// the position within the adapter's data set of the view, or
		/// <see cref="android.widget.AdapterView.INVALID_POSITION">android.widget.AdapterView.INVALID_POSITION
		/// 	</see>
		/// if the view does not correspond to a list item (or it is not currently visible).
		/// </returns>
		public virtual int getPositionForView(android.view.View view)
		{
			android.view.View listItem = view;
			try
			{
				android.view.View v;
				while (!(v = (android.view.View)listItem.getParent()).Equals(this))
				{
					listItem = v;
				}
			}
			catch (System.InvalidCastException)
			{
				// We made it up to the window without find this list view
				return android.widget.AdapterView.INVALID_POSITION;
			}
			// Search the children for the list item
			int childCount = getChildCount();
			{
				for (int i = 0; i < childCount; i++)
				{
					if (getChildAt(i).Equals(listItem))
					{
						return mFirstPosition + i;
					}
				}
			}
			// Child not found!
			return android.widget.AdapterView.INVALID_POSITION;
		}

		/// <summary>
		/// Returns the position within the adapter's data set for the first item
		/// displayed on screen.
		/// </summary>
		/// <remarks>
		/// Returns the position within the adapter's data set for the first item
		/// displayed on screen.
		/// </remarks>
		/// <returns>The position within the adapter's data set</returns>
		public virtual int getFirstVisiblePosition()
		{
			return mFirstPosition;
		}

		/// <summary>
		/// Returns the position within the adapter's data set for the last item
		/// displayed on screen.
		/// </summary>
		/// <remarks>
		/// Returns the position within the adapter's data set for the last item
		/// displayed on screen.
		/// </remarks>
		/// <returns>The position within the adapter's data set</returns>
		public virtual int getLastVisiblePosition()
		{
			return mFirstPosition + getChildCount() - 1;
		}

		/// <summary>Sets the currently selected item.</summary>
		/// <remarks>
		/// Sets the currently selected item. To support accessibility subclasses that
		/// override this method must invoke the overriden super method first.
		/// </remarks>
		/// <param name="position">Index (starting at 0) of the data item to be selected.</param>
		public abstract void setSelection(int position);

		/// <summary>Sets the view to show if the adapter is empty</summary>
		[android.view.RemotableViewMethod]
		public virtual void setEmptyView(android.view.View emptyView)
		{
			mEmptyView = emptyView;
			T adapter = getAdapter();
			bool empty = (((object)adapter == null) || adapter.isEmpty());
			updateEmptyStatus(empty);
		}

		/// <summary>
		/// When the current adapter is empty, the AdapterView can display a special view
		/// call the empty view.
		/// </summary>
		/// <remarks>
		/// When the current adapter is empty, the AdapterView can display a special view
		/// call the empty view. The empty view is used to provide feedback to the user
		/// that no data is available in this AdapterView.
		/// </remarks>
		/// <returns>The view to show if the adapter is empty.</returns>
		public virtual android.view.View getEmptyView()
		{
			return mEmptyView;
		}

		/// <summary>Indicates whether this view is in filter mode.</summary>
		/// <remarks>
		/// Indicates whether this view is in filter mode. Filter mode can for instance
		/// be enabled by a user when typing on the keyboard.
		/// </remarks>
		/// <returns>True if the view is in filter mode, false otherwise.</returns>
		internal virtual bool isInFilterMode()
		{
			return false;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void setFocusable(bool focusable)
		{
			T adapter = getAdapter();
			bool empty = (object)adapter == null || adapter.getCount() == 0;
			mDesiredFocusableState = focusable;
			if (!focusable)
			{
				mDesiredFocusableInTouchModeState = false;
			}
			base.setFocusable(focusable && (!empty || isInFilterMode()));
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void setFocusableInTouchMode(bool focusable)
		{
			T adapter = getAdapter();
			bool empty = (object)adapter == null || adapter.getCount() == 0;
			mDesiredFocusableInTouchModeState = focusable;
			if (focusable)
			{
				mDesiredFocusableState = true;
			}
			base.setFocusableInTouchMode(focusable && (!empty || isInFilterMode()));
		}

		internal virtual void checkFocus()
		{
			T adapter = getAdapter();
			bool empty = (object)adapter == null || adapter.getCount() == 0;
			bool focusable = !empty || isInFilterMode();
			// The order in which we set focusable in touch mode/focusable may matter
			// for the client, see View.setFocusableInTouchMode() comments for more
			// details
			base.setFocusableInTouchMode(focusable && mDesiredFocusableInTouchModeState);
			base.setFocusable(focusable && mDesiredFocusableState);
			if (mEmptyView != null)
			{
				updateEmptyStatus(((object)adapter == null) || adapter.isEmpty());
			}
		}

		/// <summary>Update the status of the list based on the empty parameter.</summary>
		/// <remarks>
		/// Update the status of the list based on the empty parameter.  If empty is true and
		/// we have an empty view, display it.  In all the other cases, make sure that the listview
		/// is VISIBLE and that the empty view is GONE (if it's not null).
		/// </remarks>
		private void updateEmptyStatus(bool empty)
		{
			if (isInFilterMode())
			{
				empty = false;
			}
			if (empty)
			{
				if (mEmptyView != null)
				{
					mEmptyView.setVisibility(android.view.View.VISIBLE);
					setVisibility(android.view.View.GONE);
				}
				else
				{
					// If the caller just removed our empty view, make sure the list view is visible
					setVisibility(android.view.View.VISIBLE);
				}
				// We are now GONE, so pending layouts will not be dispatched.
				// Force one here to make sure that the state of the list matches
				// the state of the adapter.
				if (mDataChanged)
				{
					this.onLayout(false, mLeft, mTop, mRight, mBottom);
				}
			}
			else
			{
				if (mEmptyView != null)
				{
					mEmptyView.setVisibility(android.view.View.GONE);
				}
				setVisibility(android.view.View.VISIBLE);
			}
		}

		/// <summary>Gets the data associated with the specified position in the list.</summary>
		/// <remarks>Gets the data associated with the specified position in the list.</remarks>
		/// <param name="position">Which data to get</param>
		/// <returns>The data associated with the specified position in the list</returns>
		public virtual object getItemAtPosition(int position)
		{
			T adapter = getAdapter();
			return ((object)adapter == null || position < 0) ? null : adapter.getItem(position
				);
		}

		public virtual long getItemIdAtPosition(int position)
		{
			T adapter = getAdapter();
			return ((object)adapter == null || position < 0) ? android.widget.AdapterView.INVALID_ROW_ID
				 : adapter.getItemId(position);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void setOnClickListener(android.view.View.OnClickListener l)
		{
			throw new java.lang.RuntimeException("Don't call setOnClickListener for an AdapterView. "
				 + "You probably want setOnItemClickListener instead");
		}

		/// <summary>Override to prevent freezing of any views created by the adapter.</summary>
		/// <remarks>Override to prevent freezing of any views created by the adapter.</remarks>
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void dispatchSaveInstanceState(android.util.SparseArray
			<android.os.Parcelable> container)
		{
			dispatchFreezeSelfOnly(container);
		}

		/// <summary>Override to prevent thawing of any views created by the adapter.</summary>
		/// <remarks>Override to prevent thawing of any views created by the adapter.</remarks>
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void dispatchRestoreInstanceState(android.util.SparseArray
			<android.os.Parcelable> container)
		{
			dispatchThawSelfOnly(container);
		}

		internal class AdapterDataSetObserver : android.database.DataSetObserver
		{
			private android.os.Parcelable mInstanceState;

			[Sharpen.OverridesMethod(@"android.database.DataSetObserver")]
			public override void onChanged()
			{
				this._enclosing.mDataChanged = true;
				this._enclosing.mOldItemCount = this._enclosing.mItemCount;
				this._enclosing.mItemCount = this._enclosing.getAdapter().getCount();
				// Detect the case where a cursor that was previously invalidated has
				// been repopulated with new data.
				if (this._enclosing.getAdapter().hasStableIds() && this.mInstanceState != null &&
					 this._enclosing.mOldItemCount == 0 && this._enclosing.mItemCount > 0)
				{
					this._enclosing.onRestoreInstanceState(this.mInstanceState);
					this.mInstanceState = null;
				}
				else
				{
					this._enclosing.rememberSyncState();
				}
				this._enclosing.checkFocus();
				this._enclosing.requestLayout();
			}

			[Sharpen.OverridesMethod(@"android.database.DataSetObserver")]
			public override void onInvalidated()
			{
				this._enclosing.mDataChanged = true;
				if (this._enclosing.getAdapter().hasStableIds())
				{
					// Remember the current state for the case where our hosting activity is being
					// stopped and later restarted
					this.mInstanceState = this._enclosing.onSaveInstanceState();
				}
				// Data is invalid so we should reset our state
				this._enclosing.mOldItemCount = this._enclosing.mItemCount;
				this._enclosing.mItemCount = 0;
				this._enclosing.mSelectedPosition = android.widget.AdapterView.INVALID_POSITION;
				this._enclosing.mSelectedRowId = android.widget.AdapterView.INVALID_ROW_ID;
				this._enclosing.mNextSelectedPosition = android.widget.AdapterView.INVALID_POSITION;
				this._enclosing.mNextSelectedRowId = android.widget.AdapterView.INVALID_ROW_ID;
				this._enclosing.mNeedSync = false;
				this._enclosing.checkFocus();
				this._enclosing.requestLayout();
			}

			public virtual void clearSavedState()
			{
				this.mInstanceState = null;
			}

			public AdapterDataSetObserver(AdapterView<T> _enclosing)
			{
				this._enclosing = _enclosing;
				mInstanceState = null;
			}

			private readonly AdapterView<T> _enclosing;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onDetachedFromWindow()
		{
			base.onDetachedFromWindow();
			removeCallbacks(mSelectionNotifier);
		}

		private class SelectionNotifier : java.lang.Runnable
		{
			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public virtual void run()
			{
				if (this._enclosing.mDataChanged)
				{
					// Data has changed between when this SelectionNotifier
					// was posted and now. We need to wait until the AdapterView
					// has been synched to the new data.
					if ((object)this._enclosing.getAdapter() != null)
					{
						this._enclosing.post(this);
					}
				}
				else
				{
					this._enclosing.fireOnSelected();
				}
			}

			internal SelectionNotifier(AdapterView<T> _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly AdapterView<T> _enclosing;
		}

		internal virtual void selectionChanged()
		{
			if (mOnItemSelectedListener != null)
			{
				if (mInLayout || mBlockLayoutRequests)
				{
					// If we are in a layout traversal, defer notification
					// by posting. This ensures that the view tree is
					// in a consistent state and is able to accomodate
					// new layout or invalidate requests.
					if (mSelectionNotifier == null)
					{
						mSelectionNotifier = new android.widget.AdapterView<T>.SelectionNotifier(this);
					}
					post(mSelectionNotifier);
				}
				else
				{
					fireOnSelected();
				}
			}
			// we fire selection events here not in View
			if (mSelectedPosition != android.widget.AdapterView.INVALID_POSITION && isShown()
				 && !isInTouchMode())
			{
				sendAccessibilityEvent(android.view.accessibility.AccessibilityEvent.TYPE_VIEW_SELECTED
					);
			}
		}

		private void fireOnSelected()
		{
			if (mOnItemSelectedListener == null)
			{
				return;
			}
			int selection = this.getSelectedItemPosition();
			if (selection >= 0)
			{
				android.view.View v = getSelectedView();
				mOnItemSelectedListener.onItemSelected(this, v, selection, getAdapter().getItemId
					(selection));
			}
			else
			{
				mOnItemSelectedListener.onNothingSelected(this);
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool dispatchPopulateAccessibilityEvent(android.view.accessibility.AccessibilityEvent
			 @event)
		{
			android.view.View selectedView = getSelectedView();
			if (selectedView != null && selectedView.getVisibility() == VISIBLE && selectedView
				.dispatchPopulateAccessibilityEvent(@event))
			{
				return true;
			}
			return false;
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override bool onRequestSendAccessibilityEvent(android.view.View child, android.view.accessibility.AccessibilityEvent
			 @event)
		{
			if (base.onRequestSendAccessibilityEvent(child, @event))
			{
				// Add a record for ourselves as well.
				android.view.accessibility.AccessibilityEvent record = android.view.accessibility.AccessibilityEvent
					.obtain();
				onInitializeAccessibilityEvent(record);
				// Populate with the text of the requesting child.
				child.dispatchPopulateAccessibilityEvent(record);
				@event.appendRecord(record);
				return true;
			}
			return false;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void onInitializeAccessibilityNodeInfo(android.view.accessibility.AccessibilityNodeInfo
			 info)
		{
			base.onInitializeAccessibilityNodeInfo(info);
			info.setScrollable(isScrollableForAccessibility());
			android.view.View selectedView = getSelectedView();
			if (selectedView != null)
			{
				info.setEnabled(selectedView.isEnabled());
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void onInitializeAccessibilityEvent(android.view.accessibility.AccessibilityEvent
			 @event)
		{
			base.onInitializeAccessibilityEvent(@event);
			@event.setScrollable(isScrollableForAccessibility());
			android.view.View selectedView = getSelectedView();
			if (selectedView != null)
			{
				@event.setEnabled(selectedView.isEnabled());
			}
			@event.setCurrentItemIndex(getSelectedItemPosition());
			@event.setFromIndex(getFirstVisiblePosition());
			@event.setToIndex(getLastVisiblePosition());
			@event.setItemCount(getCount());
		}

		private bool isScrollableForAccessibility()
		{
			T adapter = getAdapter();
			if ((object)adapter != null)
			{
				int itemCount = adapter.getCount();
				return itemCount > 0 && (getFirstVisiblePosition() > 0 || getLastVisiblePosition(
					) < itemCount - 1);
			}
			return false;
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		protected internal override bool canAnimate()
		{
			return base.canAnimate() && mItemCount > 0;
		}

		internal virtual void handleDataChanged()
		{
			int count = mItemCount;
			bool found = false;
			if (count > 0)
			{
				int newPos;
				// Find the row we are supposed to sync to
				if (mNeedSync)
				{
					// Update this first, since setNextSelectedPositionInt inspects
					// it
					mNeedSync = false;
					// See if we can find a position in the new data with the same
					// id as the old selection
					newPos = findSyncPosition();
					if (newPos >= 0)
					{
						// Verify that new selection is selectable
						int selectablePos = lookForSelectablePosition(newPos, true);
						if (selectablePos == newPos)
						{
							// Same row id is selected
							setNextSelectedPositionInt(newPos);
							found = true;
						}
					}
				}
				if (!found)
				{
					// Try to use the same position if we can't find matching data
					newPos = getSelectedItemPosition();
					// Pin position to the available range
					if (newPos >= count)
					{
						newPos = count - 1;
					}
					if (newPos < 0)
					{
						newPos = 0;
					}
					// Make sure we select something selectable -- first look down
					int selectablePos = lookForSelectablePosition(newPos, true);
					if (selectablePos < 0)
					{
						// Looking down didn't work -- try looking up
						selectablePos = lookForSelectablePosition(newPos, false);
					}
					if (selectablePos >= 0)
					{
						setNextSelectedPositionInt(selectablePos);
						checkSelectionChanged();
						found = true;
					}
				}
			}
			if (!found)
			{
				// Nothing is selected
				mSelectedPosition = android.widget.AdapterView.INVALID_POSITION;
				mSelectedRowId = android.widget.AdapterView.INVALID_ROW_ID;
				mNextSelectedPosition = android.widget.AdapterView.INVALID_POSITION;
				mNextSelectedRowId = android.widget.AdapterView.INVALID_ROW_ID;
				mNeedSync = false;
				checkSelectionChanged();
			}
		}

		internal virtual void checkSelectionChanged()
		{
			if ((mSelectedPosition != mOldSelectedPosition) || (mSelectedRowId != mOldSelectedRowId
				))
			{
				selectionChanged();
				mOldSelectedPosition = mSelectedPosition;
				mOldSelectedRowId = mSelectedRowId;
			}
		}

		/// <summary>Searches the adapter for a position matching mSyncRowId.</summary>
		/// <remarks>
		/// Searches the adapter for a position matching mSyncRowId. The search starts at mSyncPosition
		/// and then alternates between moving up and moving down until 1) we find the right position, or
		/// 2) we run out of time, or 3) we have looked at every position
		/// </remarks>
		/// <returns>
		/// Position of the row that matches mSyncRowId, or
		/// <see cref="android.widget.AdapterView.INVALID_POSITION">android.widget.AdapterView.INVALID_POSITION
		/// 	</see>
		/// if it can't
		/// be found
		/// </returns>
		internal virtual int findSyncPosition()
		{
			int count = mItemCount;
			if (count == 0)
			{
				return android.widget.AdapterView.INVALID_POSITION;
			}
			long idToMatch = mSyncRowId;
			int seed = mSyncPosition;
			// If there isn't a selection don't hunt for it
			if (idToMatch == android.widget.AdapterView.INVALID_ROW_ID)
			{
				return android.widget.AdapterView.INVALID_POSITION;
			}
			// Pin seed to reasonable values
			seed = System.Math.Max(0, seed);
			seed = System.Math.Min(count - 1, seed);
			long endTime = android.os.SystemClock.uptimeMillis() + android.widget.AdapterView.SYNC_MAX_DURATION_MILLIS;
			long rowId;
			// first position scanned so far
			int first = seed;
			// last position scanned so far
			int last = seed;
			// True if we should move down on the next iteration
			bool next = false;
			// True when we have looked at the first item in the data
			bool hitFirst;
			// True when we have looked at the last item in the data
			bool hitLast;
			// Get the item ID locally (instead of getItemIdAtPosition), so
			// we need the adapter
			T adapter = getAdapter();
			if ((object)adapter == null)
			{
				return android.widget.AdapterView.INVALID_POSITION;
			}
			while (android.os.SystemClock.uptimeMillis() <= endTime)
			{
				rowId = adapter.getItemId(seed);
				if (rowId == idToMatch)
				{
					// Found it!
					return seed;
				}
				hitLast = last == count - 1;
				hitFirst = first == 0;
				if (hitLast && hitFirst)
				{
					// Looked at everything
					break;
				}
				if (hitFirst || (next && !hitLast))
				{
					// Either we hit the top, or we are trying to move down
					last++;
					seed = last;
					// Try going up next time
					next = false;
				}
				else
				{
					if (hitLast || (!next && !hitFirst))
					{
						// Either we hit the bottom, or we are trying to move up
						first--;
						seed = first;
						// Try going down next time
						next = true;
					}
				}
			}
			return android.widget.AdapterView.INVALID_POSITION;
		}

		/// <summary>Find a position that can be selected (i.e., is not a separator).</summary>
		/// <remarks>Find a position that can be selected (i.e., is not a separator).</remarks>
		/// <param name="position">The starting position to look at.</param>
		/// <param name="lookDown">Whether to look down for other positions.</param>
		/// <returns>
		/// The next selectable position starting at position and then searching either up or
		/// down. Returns
		/// <see cref="android.widget.AdapterView.INVALID_POSITION">android.widget.AdapterView.INVALID_POSITION
		/// 	</see>
		/// if nothing can be found.
		/// </returns>
		internal virtual int lookForSelectablePosition(int position, bool lookDown)
		{
			return position;
		}

		/// <summary>Utility to keep mSelectedPosition and mSelectedRowId in sync</summary>
		/// <param name="position">Our current position</param>
		internal virtual void setSelectedPositionInt(int position)
		{
			mSelectedPosition = position;
			mSelectedRowId = getItemIdAtPosition(position);
		}

		/// <summary>Utility to keep mNextSelectedPosition and mNextSelectedRowId in sync</summary>
		/// <param name="position">
		/// Intended value for mSelectedPosition the next time we go
		/// through layout
		/// </param>
		internal virtual void setNextSelectedPositionInt(int position)
		{
			mNextSelectedPosition = position;
			mNextSelectedRowId = getItemIdAtPosition(position);
			// If we are trying to sync to the selection, update that too
			if (mNeedSync && mSyncMode == android.widget.AdapterView.SYNC_SELECTED_POSITION &&
				 position >= 0)
			{
				mSyncPosition = position;
				mSyncRowId = mNextSelectedRowId;
			}
		}

		/// <summary>
		/// Remember enough information to restore the screen state when the data has
		/// changed.
		/// </summary>
		/// <remarks>
		/// Remember enough information to restore the screen state when the data has
		/// changed.
		/// </remarks>
		internal virtual void rememberSyncState()
		{
			if (getChildCount() > 0)
			{
				mNeedSync = true;
				mSyncHeight = mLayoutHeight;
				if (mSelectedPosition >= 0)
				{
					// Sync the selection state
					android.view.View v = getChildAt(mSelectedPosition - mFirstPosition);
					mSyncRowId = mNextSelectedRowId;
					mSyncPosition = mNextSelectedPosition;
					if (v != null)
					{
						mSpecificTop = v.getTop();
					}
					mSyncMode = android.widget.AdapterView.SYNC_SELECTED_POSITION;
				}
				else
				{
					// Sync the based on the offset of the first view
					android.view.View v = getChildAt(0);
					T adapter = getAdapter();
					if (mFirstPosition >= 0 && mFirstPosition < adapter.getCount())
					{
						mSyncRowId = adapter.getItemId(mFirstPosition);
					}
					else
					{
						mSyncRowId = NO_ID;
					}
					mSyncPosition = mFirstPosition;
					if (v != null)
					{
						mSpecificTop = v.getTop();
					}
					mSyncMode = android.widget.AdapterView.SYNC_FIRST_POSITION;
				}
			}
		}
	}
}

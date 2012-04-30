using Sharpen;

namespace android.widget
{
	/// <summary>A view that shows items in a vertically scrolling list.</summary>
	/// <remarks>
	/// A view that shows items in a vertically scrolling list. The items
	/// come from the
	/// <see cref="ListAdapter">ListAdapter</see>
	/// associated with this view.
	/// <p>See the &lt;a href="
	/// <docRoot></docRoot>
	/// resources/tutorials/views/hello-listview.html"&gt;List View
	/// tutorial</a>.</p>
	/// </remarks>
	/// <attr>ref android.R.styleable#ListView_entries</attr>
	/// <attr>ref android.R.styleable#ListView_divider</attr>
	/// <attr>ref android.R.styleable#ListView_dividerHeight</attr>
	/// <attr>ref android.R.styleable#ListView_headerDividersEnabled</attr>
	/// <attr>ref android.R.styleable#ListView_footerDividersEnabled</attr>
	[Sharpen.Sharpened]
	public class ListView : android.widget.AbsListView
	{
		/// <summary>Used to indicate a no preference for a position type.</summary>
		/// <remarks>Used to indicate a no preference for a position type.</remarks>
		internal const int NO_POSITION = -1;

		/// <summary>
		/// When arrow scrolling, ListView will never scroll more than this factor
		/// times the height of the list.
		/// </summary>
		/// <remarks>
		/// When arrow scrolling, ListView will never scroll more than this factor
		/// times the height of the list.
		/// </remarks>
		internal const float MAX_SCROLL_FACTOR = 0.33f;

		/// <summary>
		/// When arrow scrolling, need a certain amount of pixels to preview next
		/// items.
		/// </summary>
		/// <remarks>
		/// When arrow scrolling, need a certain amount of pixels to preview next
		/// items.  This is usually the fading edge, but if that is small enough,
		/// we want to make sure we preview at least this many pixels.
		/// </remarks>
		internal const int MIN_SCROLL_PREVIEW_PIXELS = 2;

		/// <summary>
		/// A class that represents a fixed view in a list, for example a header at the top
		/// or a footer at the bottom.
		/// </summary>
		/// <remarks>
		/// A class that represents a fixed view in a list, for example a header at the top
		/// or a footer at the bottom.
		/// </remarks>
		public class FixedViewInfo
		{
			/// <summary>The view to add to the list</summary>
			public android.view.View view;

			/// <summary>The data backing the view.</summary>
			/// <remarks>
			/// The data backing the view. This is returned from
			/// <see cref="Adapter.getItem(int)">Adapter.getItem(int)</see>
			/// .
			/// </remarks>
			public object data;

			/// <summary><code>true</code> if the fixed view should be selectable in the list</summary>
			public bool isSelectable;

			internal FixedViewInfo(ListView _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly ListView _enclosing;
		}

		private java.util.ArrayList<android.widget.ListView.FixedViewInfo> mHeaderViewInfos
			 = new java.util.ArrayList<FixedViewInfo> ();

		private java.util.ArrayList<android.widget.ListView.FixedViewInfo> mFooterViewInfos
			 = new java.util.ArrayList<FixedViewInfo> ();

		internal android.graphics.drawable.Drawable mDivider;

		internal int mDividerHeight;

		internal android.graphics.drawable.Drawable mOverScrollHeader;

		internal android.graphics.drawable.Drawable mOverScrollFooter;

		private bool mIsCacheColorOpaque;

		private bool mDividerIsOpaque;

		private bool mHeaderDividersEnabled;

		private bool mFooterDividersEnabled;

		private bool mAreAllItemsSelectable = true;

		private bool mItemsCanFocus = false;

		private readonly android.graphics.Rect mTempRect = new android.graphics.Rect();

		private android.graphics.Paint mDividerPaint;

		private readonly android.widget.ListView.ArrowScrollFocusResult mArrowScrollFocusResult
			 = new android.widget.ListView.ArrowScrollFocusResult();

		private android.widget.ListView.FocusSelector mFocusSelector;

		public ListView(android.content.Context context) : this(context, null)
		{
		}

		public ListView(android.content.Context context, android.util.AttributeSet attrs)
			 : this(context, attrs, android.@internal.R.attr.listViewStyle)
		{
		}

		public ListView(android.content.Context context, android.util.AttributeSet attrs, 
			int defStyle) : base(context, attrs, defStyle)
		{
			// used for temporary calculations.
			// the single allocated result per list view; kinda cheesey but avoids
			// allocating these thingies too often.
			// Keeps focused children visible through resizes
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.ListView, defStyle, 0);
			java.lang.CharSequence[] entries = a.getTextArray(android.@internal.R.styleable.ListView_entries
				);
			if (entries != null)
			{
				setAdapter(new android.widget.ArrayAdapter<java.lang.CharSequence>(context, android.@internal.R
					.layout.simple_list_item_1, entries));
			}
			android.graphics.drawable.Drawable d = a.getDrawable(android.@internal.R.styleable
				.ListView_divider);
			if (d != null)
			{
				// If a divider is specified use its intrinsic height for divider height
				setDivider(d);
			}
			android.graphics.drawable.Drawable osHeader = a.getDrawable(android.@internal.R.styleable
				.ListView_overScrollHeader);
			if (osHeader != null)
			{
				setOverscrollHeader(osHeader);
			}
			android.graphics.drawable.Drawable osFooter = a.getDrawable(android.@internal.R.styleable
				.ListView_overScrollFooter);
			if (osFooter != null)
			{
				setOverscrollFooter(osFooter);
			}
			// Use the height specified, zero being the default
			int dividerHeight = a.getDimensionPixelSize(android.@internal.R.styleable.ListView_dividerHeight
				, 0);
			if (dividerHeight != 0)
			{
				setDividerHeight(dividerHeight);
			}
			mHeaderDividersEnabled = a.getBoolean(android.@internal.R.styleable.ListView_headerDividersEnabled
				, true);
			mFooterDividersEnabled = a.getBoolean(android.@internal.R.styleable.ListView_footerDividersEnabled
				, true);
			a.recycle();
		}

		/// <returns>
		/// The maximum amount a list view will scroll in response to
		/// an arrow event.
		/// </returns>
		public virtual int getMaxScrollAmount()
		{
			return (int)(MAX_SCROLL_FACTOR * (mBottom - mTop));
		}

		/// <summary>
		/// Make sure views are touching the top or bottom edge, as appropriate for
		/// our gravity
		/// </summary>
		private void adjustViewsUpOrDown()
		{
			int childCount = getChildCount();
			int delta;
			if (childCount > 0)
			{
				android.view.View child;
				if (!mStackFromBottom)
				{
					// Uh-oh -- we came up short. Slide all views up to make them
					// align with the top
					child = getChildAt(0);
					delta = child.getTop() - mListPadding.top;
					if (mFirstPosition != 0)
					{
						// It's OK to have some space above the first item if it is
						// part of the vertical spacing
						delta -= mDividerHeight;
					}
					if (delta < 0)
					{
						// We only are looking to see if we are too low, not too high
						delta = 0;
					}
				}
				else
				{
					// we are too high, slide all views down to align with bottom
					child = getChildAt(childCount - 1);
					delta = child.getBottom() - (getHeight() - mListPadding.bottom);
					if (mFirstPosition + childCount < mItemCount)
					{
						// It's OK to have some space below the last item if it is
						// part of the vertical spacing
						delta += mDividerHeight;
					}
					if (delta > 0)
					{
						delta = 0;
					}
				}
				if (delta != 0)
				{
					offsetChildrenTopAndBottom(-delta);
				}
			}
		}

		/// <summary>Add a fixed view to appear at the top of the list.</summary>
		/// <remarks>
		/// Add a fixed view to appear at the top of the list. If addHeaderView is
		/// called more than once, the views will appear in the order they were
		/// added. Views added using this call can take focus if they want.
		/// <p>
		/// NOTE: Call this before calling setAdapter. This is so ListView can wrap
		/// the supplied cursor with one that will also account for header and footer
		/// views.
		/// </remarks>
		/// <param name="v">The view to add.</param>
		/// <param name="data">Data to associate with this view</param>
		/// <param name="isSelectable">whether the item is selectable</param>
		public virtual void addHeaderView(android.view.View v, object data, bool isSelectable
			)
		{
			if (mAdapter != null && !(mAdapter is android.widget.HeaderViewListAdapter))
			{
				throw new System.InvalidOperationException("Cannot add header view to list -- setAdapter has already been called."
					);
			}
			android.widget.ListView.FixedViewInfo info = new android.widget.ListView.FixedViewInfo
				(this);
			info.view = v;
			info.data = data;
			info.isSelectable = isSelectable;
			mHeaderViewInfos.add(info);
			// in the case of re-adding a header view, or adding one later on,
			// we need to notify the observer
			if (mAdapter != null && mDataSetObserver != null)
			{
				mDataSetObserver.onChanged();
			}
		}

		/// <summary>Add a fixed view to appear at the top of the list.</summary>
		/// <remarks>
		/// Add a fixed view to appear at the top of the list. If addHeaderView is
		/// called more than once, the views will appear in the order they were
		/// added. Views added using this call can take focus if they want.
		/// <p>
		/// NOTE: Call this before calling setAdapter. This is so ListView can wrap
		/// the supplied cursor with one that will also account for header and footer
		/// views.
		/// </remarks>
		/// <param name="v">The view to add.</param>
		public virtual void addHeaderView(android.view.View v)
		{
			addHeaderView(v, null, true);
		}

		[Sharpen.OverridesMethod(@"android.widget.AbsListView")]
		internal override int getHeaderViewsCount()
		{
			return mHeaderViewInfos.size();
		}

		/// <summary>Removes a previously-added header view.</summary>
		/// <remarks>Removes a previously-added header view.</remarks>
		/// <param name="v">The view to remove</param>
		/// <returns>
		/// true if the view was removed, false if the view was not a header
		/// view
		/// </returns>
		public virtual bool removeHeaderView(android.view.View v)
		{
			if (mHeaderViewInfos.size() > 0)
			{
				bool result = false;
				if (mAdapter != null && ((android.widget.HeaderViewListAdapter)mAdapter).removeHeader
					(v))
				{
					if (mDataSetObserver != null)
					{
						mDataSetObserver.onChanged();
					}
					result = true;
				}
				removeFixedViewInfo(v, mHeaderViewInfos);
				return result;
			}
			return false;
		}

		private void removeFixedViewInfo(android.view.View v, java.util.ArrayList<android.widget.ListView
			.FixedViewInfo> where)
		{
			int len = where.size();
			{
				for (int i = 0; i < len; ++i)
				{
					android.widget.ListView.FixedViewInfo info = where.get(i);
					if (info.view == v)
					{
						where.remove(i);
						break;
					}
				}
			}
		}

		/// <summary>Add a fixed view to appear at the bottom of the list.</summary>
		/// <remarks>
		/// Add a fixed view to appear at the bottom of the list. If addFooterView is
		/// called more than once, the views will appear in the order they were
		/// added. Views added using this call can take focus if they want.
		/// <p>
		/// NOTE: Call this before calling setAdapter. This is so ListView can wrap
		/// the supplied cursor with one that will also account for header and footer
		/// views.
		/// </remarks>
		/// <param name="v">The view to add.</param>
		/// <param name="data">Data to associate with this view</param>
		/// <param name="isSelectable">true if the footer view can be selected</param>
		public virtual void addFooterView(android.view.View v, object data, bool isSelectable
			)
		{
			// NOTE: do not enforce the adapter being null here, since unlike in
			// addHeaderView, it was never enforced here, and so existing apps are
			// relying on being able to add a footer and then calling setAdapter to
			// force creation of the HeaderViewListAdapter wrapper
			android.widget.ListView.FixedViewInfo info = new android.widget.ListView.FixedViewInfo
				(this);
			info.view = v;
			info.data = data;
			info.isSelectable = isSelectable;
			mFooterViewInfos.add(info);
			// in the case of re-adding a footer view, or adding one later on,
			// we need to notify the observer
			if (mAdapter != null && mDataSetObserver != null)
			{
				mDataSetObserver.onChanged();
			}
		}

		/// <summary>Add a fixed view to appear at the bottom of the list.</summary>
		/// <remarks>
		/// Add a fixed view to appear at the bottom of the list. If addFooterView is called more
		/// than once, the views will appear in the order they were added. Views added using
		/// this call can take focus if they want.
		/// <p>NOTE: Call this before calling setAdapter. This is so ListView can wrap the supplied
		/// cursor with one that will also account for header and footer views.
		/// </remarks>
		/// <param name="v">The view to add.</param>
		public virtual void addFooterView(android.view.View v)
		{
			addFooterView(v, null, true);
		}

		[Sharpen.OverridesMethod(@"android.widget.AbsListView")]
		internal override int getFooterViewsCount()
		{
			return mFooterViewInfos.size();
		}

		/// <summary>Removes a previously-added footer view.</summary>
		/// <remarks>Removes a previously-added footer view.</remarks>
		/// <param name="v">The view to remove</param>
		/// <returns>true if the view was removed, false if the view was not a footer view</returns>
		public virtual bool removeFooterView(android.view.View v)
		{
			if (mFooterViewInfos.size() > 0)
			{
				bool result = false;
				if (mAdapter != null && ((android.widget.HeaderViewListAdapter)mAdapter).removeFooter
					(v))
				{
					if (mDataSetObserver != null)
					{
						mDataSetObserver.onChanged();
					}
					result = true;
				}
				removeFixedViewInfo(v, mFooterViewInfos);
				return result;
			}
			return false;
		}

		/// <summary>Returns the adapter currently in use in this ListView.</summary>
		/// <remarks>
		/// Returns the adapter currently in use in this ListView. The returned adapter
		/// might not be the same adapter passed to
		/// <see cref="setAdapter(ListAdapter)">setAdapter(ListAdapter)</see>
		/// but
		/// might be a
		/// <see cref="WrapperListAdapter">WrapperListAdapter</see>
		/// .
		/// </remarks>
		/// <returns>The adapter currently used to display data in this ListView.</returns>
		/// <seealso cref="setAdapter(ListAdapter)">setAdapter(ListAdapter)</seealso>
		[Sharpen.OverridesMethod(@"android.widget.AdapterView")]
		public override android.widget.ListAdapter getAdapter()
		{
			return mAdapter;
		}

		/// <summary>
		/// Sets up this AbsListView to use a remote views adapter which connects to a RemoteViewsService
		/// through the specified intent.
		/// </summary>
		/// <remarks>
		/// Sets up this AbsListView to use a remote views adapter which connects to a RemoteViewsService
		/// through the specified intent.
		/// </remarks>
		/// <param name="intent">the intent used to identify the RemoteViewsService for the adapter to connect to.
		/// 	</param>
		[android.view.RemotableViewMethod]
		[Sharpen.OverridesMethod(@"android.widget.AbsListView")]
		public override void setRemoteViewsAdapter(android.content.Intent intent)
		{
			base.setRemoteViewsAdapter(intent);
		}

		/// <summary>Sets the data behind this ListView.</summary>
		/// <remarks>
		/// Sets the data behind this ListView.
		/// The adapter passed to this method may be wrapped by a
		/// <see cref="WrapperListAdapter">WrapperListAdapter</see>
		/// ,
		/// depending on the ListView features currently in use. For instance, adding
		/// headers and/or footers will cause the adapter to be wrapped.
		/// </remarks>
		/// <param name="adapter">
		/// The ListAdapter which is responsible for maintaining the
		/// data backing this list and for producing a view to represent an
		/// item in that data set.
		/// </param>
		/// <seealso cref="getAdapter()"></seealso>
		[Sharpen.OverridesMethod(@"android.widget.AdapterView")]
		public override void setAdapter(android.widget.ListAdapter adapter)
		{
			if (mAdapter != null && mDataSetObserver != null)
			{
				mAdapter.unregisterDataSetObserver(mDataSetObserver);
			}
			resetList();
			mRecycler.clear();
			if (mHeaderViewInfos.size() > 0 || mFooterViewInfos.size() > 0)
			{
				mAdapter = new android.widget.HeaderViewListAdapter(mHeaderViewInfos, mFooterViewInfos
					, adapter);
			}
			else
			{
				mAdapter = adapter;
			}
			mOldSelectedPosition = android.widget.AdapterView.INVALID_POSITION;
			mOldSelectedRowId = android.widget.AdapterView.INVALID_ROW_ID;
			// AbsListView#setAdapter will update choice mode states.
			base.setAdapter(adapter);
			if (mAdapter != null)
			{
				mAreAllItemsSelectable = mAdapter.areAllItemsEnabled();
				mOldItemCount = mItemCount;
				mItemCount = mAdapter.getCount();
				checkFocus();
				mDataSetObserver = new android.widget.AbsListView.AdapterDataSetObserver(this);
				mAdapter.registerDataSetObserver(mDataSetObserver);
				mRecycler.setViewTypeCount(mAdapter.getViewTypeCount());
				int position;
				if (mStackFromBottom)
				{
					position = lookForSelectablePosition(mItemCount - 1, false);
				}
				else
				{
					position = lookForSelectablePosition(0, true);
				}
				setSelectedPositionInt(position);
				setNextSelectedPositionInt(position);
				if (mItemCount == 0)
				{
					// Nothing selected
					checkSelectionChanged();
				}
			}
			else
			{
				mAreAllItemsSelectable = true;
				checkFocus();
				// Nothing selected
				checkSelectionChanged();
			}
			requestLayout();
		}

		/// <summary>The list is empty.</summary>
		/// <remarks>The list is empty. Clear everything out.</remarks>
		[Sharpen.OverridesMethod(@"android.widget.AbsListView")]
		internal override void resetList()
		{
			// The parent's resetList() will remove all views from the layout so we need to
			// cleanup the state of our footers and headers
			clearRecycledState(mHeaderViewInfos);
			clearRecycledState(mFooterViewInfos);
			base.resetList();
			mLayoutMode = LAYOUT_NORMAL;
		}

		private void clearRecycledState(java.util.ArrayList<android.widget.ListView.FixedViewInfo
			> infos)
		{
			if (infos != null)
			{
				int count = infos.size();
				{
					for (int i = 0; i < count; i++)
					{
						android.view.View child = infos.get(i).view;
						android.widget.AbsListView.LayoutParams p = (android.widget.AbsListView.LayoutParams
							)child.getLayoutParams();
						if (p != null)
						{
							p.recycledHeaderFooter = false;
						}
					}
				}
			}
		}

		/// <returns>Whether the list needs to show the top fading edge</returns>
		private bool showingTopFadingEdge()
		{
			int listTop = mScrollY + mListPadding.top;
			return (mFirstPosition > 0) || (getChildAt(0).getTop() > listTop);
		}

		/// <returns>Whether the list needs to show the bottom fading edge</returns>
		private bool showingBottomFadingEdge()
		{
			int childCount = getChildCount();
			int bottomOfBottomChild = getChildAt(childCount - 1).getBottom();
			int lastVisiblePosition = mFirstPosition + childCount - 1;
			int listBottom = mScrollY + getHeight() - mListPadding.bottom;
			return (lastVisiblePosition < mItemCount - 1) || (bottomOfBottomChild < listBottom
				);
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override bool requestChildRectangleOnScreen(android.view.View child, android.graphics.Rect
			 rect, bool immediate)
		{
			int rectTopWithinChild = rect.top;
			// offset so rect is in coordinates of the this view
			rect.offset(child.getLeft(), child.getTop());
			rect.offset(-child.getScrollX(), -child.getScrollY());
			int height = getHeight();
			int listUnfadedTop = getScrollY();
			int listUnfadedBottom = listUnfadedTop + height;
			int fadingEdge = getVerticalFadingEdgeLength();
			if (showingTopFadingEdge())
			{
				// leave room for top fading edge as long as rect isn't at very top
				if ((mSelectedPosition > 0) || (rectTopWithinChild > fadingEdge))
				{
					listUnfadedTop += fadingEdge;
				}
			}
			int childCount = getChildCount();
			int bottomOfBottomChild = getChildAt(childCount - 1).getBottom();
			if (showingBottomFadingEdge())
			{
				// leave room for bottom fading edge as long as rect isn't at very bottom
				if ((mSelectedPosition < mItemCount - 1) || (rect.bottom < (bottomOfBottomChild -
					 fadingEdge)))
				{
					listUnfadedBottom -= fadingEdge;
				}
			}
			int scrollYDelta = 0;
			if (rect.bottom > listUnfadedBottom && rect.top > listUnfadedTop)
			{
				// need to MOVE DOWN to get it in view: move down just enough so
				// that the entire rectangle is in view (or at least the first
				// screen size chunk).
				if (rect.height() > height)
				{
					// just enough to get screen size chunk on
					scrollYDelta += (rect.top - listUnfadedTop);
				}
				else
				{
					// get entire rect at bottom of screen
					scrollYDelta += (rect.bottom - listUnfadedBottom);
				}
				// make sure we aren't scrolling beyond the end of our children
				int distanceToBottom = bottomOfBottomChild - listUnfadedBottom;
				scrollYDelta = System.Math.Min(scrollYDelta, distanceToBottom);
			}
			else
			{
				if (rect.top < listUnfadedTop && rect.bottom < listUnfadedBottom)
				{
					// need to MOVE UP to get it in view: move up just enough so that
					// entire rectangle is in view (or at least the first screen
					// size chunk of it).
					if (rect.height() > height)
					{
						// screen size chunk
						scrollYDelta -= (listUnfadedBottom - rect.bottom);
					}
					else
					{
						// entire rect at top
						scrollYDelta -= (listUnfadedTop - rect.top);
					}
					// make sure we aren't scrolling any further than the top our children
					int top = getChildAt(0).getTop();
					int deltaToTop = top - listUnfadedTop;
					scrollYDelta = System.Math.Max(scrollYDelta, deltaToTop);
				}
			}
			bool scroll = scrollYDelta != 0;
			if (scroll)
			{
				scrollListItemsBy(-scrollYDelta);
				positionSelector(android.widget.AdapterView.INVALID_POSITION, child);
				mSelectedTop = child.getTop();
				invalidate();
			}
			return scroll;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.widget.AbsListView")]
		internal override void fillGap(bool down)
		{
			int count = getChildCount();
			if (down)
			{
				int paddingTop = 0;
				if ((mGroupFlags & CLIP_TO_PADDING_MASK) == CLIP_TO_PADDING_MASK)
				{
					paddingTop = getListPaddingTop();
				}
				int startOffset = count > 0 ? getChildAt(count - 1).getBottom() + mDividerHeight : 
					paddingTop;
				fillDown(mFirstPosition + count, startOffset);
				correctTooHigh(getChildCount());
			}
			else
			{
				int paddingBottom = 0;
				if ((mGroupFlags & CLIP_TO_PADDING_MASK) == CLIP_TO_PADDING_MASK)
				{
					paddingBottom = getListPaddingBottom();
				}
				int startOffset = count > 0 ? getChildAt(0).getTop() - mDividerHeight : getHeight
					() - paddingBottom;
				fillUp(mFirstPosition - 1, startOffset);
				correctTooLow(getChildCount());
			}
		}

		/// <summary>Fills the list from pos down to the end of the list view.</summary>
		/// <remarks>Fills the list from pos down to the end of the list view.</remarks>
		/// <param name="pos">The first position to put in the list</param>
		/// <param name="nextTop">
		/// The location where the top of the item associated with pos
		/// should be drawn
		/// </param>
		/// <returns>
		/// The view that is currently selected, if it happens to be in the
		/// range that we draw.
		/// </returns>
		private android.view.View fillDown(int pos, int nextTop)
		{
			android.view.View selectedView = null;
			int end = (mBottom - mTop);
			if ((mGroupFlags & CLIP_TO_PADDING_MASK) == CLIP_TO_PADDING_MASK)
			{
				end -= mListPadding.bottom;
			}
			while (nextTop < end && pos < mItemCount)
			{
				// is this the selected item?
				bool selected = pos == mSelectedPosition;
				android.view.View child = makeAndAddView(pos, nextTop, true, mListPadding.left, selected
					);
				nextTop = child.getBottom() + mDividerHeight;
				if (selected)
				{
					selectedView = child;
				}
				pos++;
			}
			return selectedView;
		}

		/// <summary>Fills the list from pos up to the top of the list view.</summary>
		/// <remarks>Fills the list from pos up to the top of the list view.</remarks>
		/// <param name="pos">The first position to put in the list</param>
		/// <param name="nextBottom">
		/// The location where the bottom of the item associated
		/// with pos should be drawn
		/// </param>
		/// <returns>The view that is currently selected</returns>
		private android.view.View fillUp(int pos, int nextBottom)
		{
			android.view.View selectedView = null;
			int end = 0;
			if ((mGroupFlags & CLIP_TO_PADDING_MASK) == CLIP_TO_PADDING_MASK)
			{
				end = mListPadding.top;
			}
			while (nextBottom > end && pos >= 0)
			{
				// is this the selected item?
				bool selected = pos == mSelectedPosition;
				android.view.View child = makeAndAddView(pos, nextBottom, false, mListPadding.left
					, selected);
				nextBottom = child.getTop() - mDividerHeight;
				if (selected)
				{
					selectedView = child;
				}
				pos--;
			}
			mFirstPosition = pos + 1;
			return selectedView;
		}

		/// <summary>Fills the list from top to bottom, starting with mFirstPosition</summary>
		/// <param name="nextTop">
		/// The location where the top of the first item should be
		/// drawn
		/// </param>
		/// <returns>The view that is currently selected</returns>
		private android.view.View fillFromTop(int nextTop)
		{
			mFirstPosition = System.Math.Min(mFirstPosition, mSelectedPosition);
			mFirstPosition = System.Math.Min(mFirstPosition, mItemCount - 1);
			if (mFirstPosition < 0)
			{
				mFirstPosition = 0;
			}
			return fillDown(mFirstPosition, nextTop);
		}

		/// <summary>
		/// Put mSelectedPosition in the middle of the screen and then build up and
		/// down from there.
		/// </summary>
		/// <remarks>
		/// Put mSelectedPosition in the middle of the screen and then build up and
		/// down from there. This method forces mSelectedPosition to the center.
		/// </remarks>
		/// <param name="childrenTop">
		/// Top of the area in which children can be drawn, as
		/// measured in pixels
		/// </param>
		/// <param name="childrenBottom">
		/// Bottom of the area in which children can be drawn,
		/// as measured in pixels
		/// </param>
		/// <returns>Currently selected view</returns>
		private android.view.View fillFromMiddle(int childrenTop, int childrenBottom)
		{
			int height = childrenBottom - childrenTop;
			int position = reconcileSelectedPosition();
			android.view.View sel = makeAndAddView(position, childrenTop, true, mListPadding.
				left, true);
			mFirstPosition = position;
			int selHeight = sel.getMeasuredHeight();
			if (selHeight <= height)
			{
				sel.offsetTopAndBottom((height - selHeight) / 2);
			}
			fillAboveAndBelow(sel, position);
			if (!mStackFromBottom)
			{
				correctTooHigh(getChildCount());
			}
			else
			{
				correctTooLow(getChildCount());
			}
			return sel;
		}

		/// <summary>
		/// Once the selected view as been placed, fill up the visible area above and
		/// below it.
		/// </summary>
		/// <remarks>
		/// Once the selected view as been placed, fill up the visible area above and
		/// below it.
		/// </remarks>
		/// <param name="sel">The selected view</param>
		/// <param name="position">The position corresponding to sel</param>
		private void fillAboveAndBelow(android.view.View sel, int position)
		{
			int dividerHeight = mDividerHeight;
			if (!mStackFromBottom)
			{
				fillUp(position - 1, sel.getTop() - dividerHeight);
				adjustViewsUpOrDown();
				fillDown(position + 1, sel.getBottom() + dividerHeight);
			}
			else
			{
				fillDown(position + 1, sel.getBottom() + dividerHeight);
				adjustViewsUpOrDown();
				fillUp(position - 1, sel.getTop() - dividerHeight);
			}
		}

		/// <summary>
		/// Fills the grid based on positioning the new selection at a specific
		/// location.
		/// </summary>
		/// <remarks>
		/// Fills the grid based on positioning the new selection at a specific
		/// location. The selection may be moved so that it does not intersect the
		/// faded edges. The grid is then filled upwards and downwards from there.
		/// </remarks>
		/// <param name="selectedTop">Where the selected item should be</param>
		/// <param name="childrenTop">Where to start drawing children</param>
		/// <param name="childrenBottom">Last pixel where children can be drawn</param>
		/// <returns>The view that currently has selection</returns>
		private android.view.View fillFromSelection(int selectedTop, int childrenTop, int
			 childrenBottom)
		{
			int fadingEdgeLength = getVerticalFadingEdgeLength();
			int selectedPosition = mSelectedPosition;
			android.view.View sel;
			int topSelectionPixel = getTopSelectionPixel(childrenTop, fadingEdgeLength, selectedPosition
				);
			int bottomSelectionPixel = getBottomSelectionPixel(childrenBottom, fadingEdgeLength
				, selectedPosition);
			sel = makeAndAddView(selectedPosition, selectedTop, true, mListPadding.left, true
				);
			// Some of the newly selected item extends below the bottom of the list
			if (sel.getBottom() > bottomSelectionPixel)
			{
				// Find space available above the selection into which we can scroll
				// upwards
				int spaceAbove = sel.getTop() - topSelectionPixel;
				// Find space required to bring the bottom of the selected item
				// fully into view
				int spaceBelow = sel.getBottom() - bottomSelectionPixel;
				int offset = System.Math.Min(spaceAbove, spaceBelow);
				// Now offset the selected item to get it into view
				sel.offsetTopAndBottom(-offset);
			}
			else
			{
				if (sel.getTop() < topSelectionPixel)
				{
					// Find space required to bring the top of the selected item fully
					// into view
					int spaceAbove = topSelectionPixel - sel.getTop();
					// Find space available below the selection into which we can scroll
					// downwards
					int spaceBelow = bottomSelectionPixel - sel.getBottom();
					int offset = System.Math.Min(spaceAbove, spaceBelow);
					// Offset the selected item to get it into view
					sel.offsetTopAndBottom(offset);
				}
			}
			// Fill in views above and below
			fillAboveAndBelow(sel, selectedPosition);
			if (!mStackFromBottom)
			{
				correctTooHigh(getChildCount());
			}
			else
			{
				correctTooLow(getChildCount());
			}
			return sel;
		}

		/// <summary>Calculate the bottom-most pixel we can draw the selection into</summary>
		/// <param name="childrenBottom">Bottom pixel were children can be drawn</param>
		/// <param name="fadingEdgeLength">Length of the fading edge in pixels, if present</param>
		/// <param name="selectedPosition">The position that will be selected</param>
		/// <returns>The bottom-most pixel we can draw the selection into</returns>
		private int getBottomSelectionPixel(int childrenBottom, int fadingEdgeLength, int
			 selectedPosition)
		{
			int bottomSelectionPixel = childrenBottom;
			if (selectedPosition != mItemCount - 1)
			{
				bottomSelectionPixel -= fadingEdgeLength;
			}
			return bottomSelectionPixel;
		}

		/// <summary>Calculate the top-most pixel we can draw the selection into</summary>
		/// <param name="childrenTop">Top pixel were children can be drawn</param>
		/// <param name="fadingEdgeLength">Length of the fading edge in pixels, if present</param>
		/// <param name="selectedPosition">The position that will be selected</param>
		/// <returns>The top-most pixel we can draw the selection into</returns>
		private int getTopSelectionPixel(int childrenTop, int fadingEdgeLength, int selectedPosition
			)
		{
			// first pixel we can draw the selection into
			int topSelectionPixel = childrenTop;
			if (selectedPosition > 0)
			{
				topSelectionPixel += fadingEdgeLength;
			}
			return topSelectionPixel;
		}

		/// <summary>Smoothly scroll to the specified adapter position.</summary>
		/// <remarks>
		/// Smoothly scroll to the specified adapter position. The view will
		/// scroll such that the indicated position is displayed.
		/// </remarks>
		/// <param name="position">Scroll to this adapter position.</param>
		[android.view.RemotableViewMethod]
		[Sharpen.OverridesMethod(@"android.widget.AbsListView")]
		public override void smoothScrollToPosition(int position)
		{
			base.smoothScrollToPosition(position);
		}

		/// <summary>Smoothly scroll to the specified adapter position offset.</summary>
		/// <remarks>
		/// Smoothly scroll to the specified adapter position offset. The view will
		/// scroll such that the indicated position is displayed.
		/// </remarks>
		/// <param name="offset">The amount to offset from the adapter position to scroll to.
		/// 	</param>
		[android.view.RemotableViewMethod]
		[Sharpen.OverridesMethod(@"android.widget.AbsListView")]
		internal override void smoothScrollByOffset(int offset)
		{
			base.smoothScrollByOffset(offset);
		}

		/// <summary>
		/// Fills the list based on positioning the new selection relative to the old
		/// selection.
		/// </summary>
		/// <remarks>
		/// Fills the list based on positioning the new selection relative to the old
		/// selection. The new selection will be placed at, above, or below the
		/// location of the new selection depending on how the selection is moving.
		/// The selection will then be pinned to the visible part of the screen,
		/// excluding the edges that are faded. The list is then filled upwards and
		/// downwards from there.
		/// </remarks>
		/// <param name="oldSel">
		/// The old selected view. Useful for trying to put the new
		/// selection in the same place
		/// </param>
		/// <param name="newSel">
		/// The view that is to become selected. Useful for trying to
		/// put the new selection in the same place
		/// </param>
		/// <param name="delta">Which way we are moving</param>
		/// <param name="childrenTop">Where to start drawing children</param>
		/// <param name="childrenBottom">Last pixel where children can be drawn</param>
		/// <returns>The view that currently has selection</returns>
		private android.view.View moveSelection(android.view.View oldSel, android.view.View
			 newSel, int delta, int childrenTop, int childrenBottom)
		{
			int fadingEdgeLength = getVerticalFadingEdgeLength();
			int selectedPosition = mSelectedPosition;
			android.view.View sel;
			int topSelectionPixel = getTopSelectionPixel(childrenTop, fadingEdgeLength, selectedPosition
				);
			int bottomSelectionPixel = getBottomSelectionPixel(childrenTop, fadingEdgeLength, 
				selectedPosition);
			if (delta > 0)
			{
				// Put oldSel (A) where it belongs
				oldSel = makeAndAddView(selectedPosition - 1, oldSel.getTop(), true, mListPadding
					.left, false);
				int dividerHeight = mDividerHeight;
				// Now put the new selection (B) below that
				sel = makeAndAddView(selectedPosition, oldSel.getBottom() + dividerHeight, true, 
					mListPadding.left, true);
				// Some of the newly selected item extends below the bottom of the list
				if (sel.getBottom() > bottomSelectionPixel)
				{
					// Find space available above the selection into which we can scroll upwards
					int spaceAbove = sel.getTop() - topSelectionPixel;
					// Find space required to bring the bottom of the selected item fully into view
					int spaceBelow = sel.getBottom() - bottomSelectionPixel;
					// Don't scroll more than half the height of the list
					int halfVerticalSpace = (childrenBottom - childrenTop) / 2;
					int offset = System.Math.Min(spaceAbove, spaceBelow);
					offset = System.Math.Min(offset, halfVerticalSpace);
					// We placed oldSel, so offset that item
					oldSel.offsetTopAndBottom(-offset);
					// Now offset the selected item to get it into view
					sel.offsetTopAndBottom(-offset);
				}
				// Fill in views above and below
				if (!mStackFromBottom)
				{
					fillUp(mSelectedPosition - 2, sel.getTop() - dividerHeight);
					adjustViewsUpOrDown();
					fillDown(mSelectedPosition + 1, sel.getBottom() + dividerHeight);
				}
				else
				{
					fillDown(mSelectedPosition + 1, sel.getBottom() + dividerHeight);
					adjustViewsUpOrDown();
					fillUp(mSelectedPosition - 2, sel.getTop() - dividerHeight);
				}
			}
			else
			{
				if (delta < 0)
				{
					if (newSel != null)
					{
						// Try to position the top of newSel (A) where it was before it was selected
						sel = makeAndAddView(selectedPosition, newSel.getTop(), true, mListPadding.left, 
							true);
					}
					else
					{
						// If (A) was not on screen and so did not have a view, position
						// it above the oldSel (B)
						sel = makeAndAddView(selectedPosition, oldSel.getTop(), false, mListPadding.left, 
							true);
					}
					// Some of the newly selected item extends above the top of the list
					if (sel.getTop() < topSelectionPixel)
					{
						// Find space required to bring the top of the selected item fully into view
						int spaceAbove = topSelectionPixel - sel.getTop();
						// Find space available below the selection into which we can scroll downwards
						int spaceBelow = bottomSelectionPixel - sel.getBottom();
						// Don't scroll more than half the height of the list
						int halfVerticalSpace = (childrenBottom - childrenTop) / 2;
						int offset = System.Math.Min(spaceAbove, spaceBelow);
						offset = System.Math.Min(offset, halfVerticalSpace);
						// Offset the selected item to get it into view
						sel.offsetTopAndBottom(offset);
					}
					// Fill in views above and below
					fillAboveAndBelow(sel, selectedPosition);
				}
				else
				{
					int oldTop = oldSel.getTop();
					sel = makeAndAddView(selectedPosition, oldTop, true, mListPadding.left, true);
					// We're staying still...
					if (oldTop < childrenTop)
					{
						// ... but the top of the old selection was off screen.
						// (This can happen if the data changes size out from under us)
						int newBottom = sel.getBottom();
						if (newBottom < childrenTop + 20)
						{
							// Not enough visible -- bring it onscreen
							sel.offsetTopAndBottom(childrenTop - sel.getTop());
						}
					}
					// Fill in views above and below
					fillAboveAndBelow(sel, selectedPosition);
				}
			}
			return sel;
		}

		private class FocusSelector : java.lang.Runnable
		{
			internal int mPosition;

			internal int mPositionTop;

			public virtual android.widget.ListView.FocusSelector setup(int position, int top)
			{
				this.mPosition = position;
				this.mPositionTop = top;
				return this;
			}

			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public virtual void run()
			{
				this._enclosing.setSelectionFromTop(this.mPosition, this.mPositionTop);
			}

			internal FocusSelector(ListView _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly ListView _enclosing;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onSizeChanged(int w, int h, int oldw, int oldh)
		{
			if (getChildCount() > 0)
			{
				android.view.View focusedChild = getFocusedChild();
				if (focusedChild != null)
				{
					int childPosition = mFirstPosition + indexOfChild(focusedChild);
					int childBottom = focusedChild.getBottom();
					int offset = System.Math.Max(0, childBottom - (h - mPaddingTop));
					int top = focusedChild.getTop() - offset;
					if (mFocusSelector == null)
					{
						mFocusSelector = new android.widget.ListView.FocusSelector(this);
					}
					post(mFocusSelector.setup(childPosition, top));
				}
			}
			base.onSizeChanged(w, h, oldw, oldh);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onMeasure(int widthMeasureSpec, int heightMeasureSpec
			)
		{
			// Sets up mListPadding
			base.onMeasure(widthMeasureSpec, heightMeasureSpec);
			int widthMode = android.view.View.MeasureSpec.getMode(widthMeasureSpec);
			int heightMode = android.view.View.MeasureSpec.getMode(heightMeasureSpec);
			int widthSize = android.view.View.MeasureSpec.getSize(widthMeasureSpec);
			int heightSize = android.view.View.MeasureSpec.getSize(heightMeasureSpec);
			int childWidth = 0;
			int childHeight = 0;
			int childState = 0;
			mItemCount = mAdapter == null ? 0 : mAdapter.getCount();
			if (mItemCount > 0 && (widthMode == android.view.View.MeasureSpec.UNSPECIFIED || 
				heightMode == android.view.View.MeasureSpec.UNSPECIFIED))
			{
				android.view.View child = obtainView(0, mIsScrap);
				measureScrapChild(child, 0, widthMeasureSpec);
				childWidth = child.getMeasuredWidth();
				childHeight = child.getMeasuredHeight();
				childState = combineMeasuredStates(childState, child.getMeasuredState());
				if (recycleOnMeasure() && mRecycler.shouldRecycleViewType(((android.widget.AbsListView
					.LayoutParams)child.getLayoutParams()).viewType))
				{
					mRecycler.addScrapView(child, -1);
				}
			}
			if (widthMode == android.view.View.MeasureSpec.UNSPECIFIED)
			{
				widthSize = mListPadding.left + mListPadding.right + childWidth + getVerticalScrollbarWidth
					();
			}
			else
			{
				widthSize |= (childState & MEASURED_STATE_MASK);
			}
			if (heightMode == android.view.View.MeasureSpec.UNSPECIFIED)
			{
				heightSize = mListPadding.top + mListPadding.bottom + childHeight + getVerticalFadingEdgeLength
					() * 2;
			}
			if (heightMode == android.view.View.MeasureSpec.AT_MOST)
			{
				// TODO: after first layout we should maybe start at the first visible position, not 0
				heightSize = measureHeightOfChildren(widthMeasureSpec, 0, NO_POSITION, heightSize
					, -1);
			}
			setMeasuredDimension(widthSize, heightSize);
			mWidthMeasureSpec = widthMeasureSpec;
		}

		private void measureScrapChild(android.view.View child, int position, int widthMeasureSpec
			)
		{
			android.widget.AbsListView.LayoutParams p = (android.widget.AbsListView.LayoutParams
				)child.getLayoutParams();
			if (p == null)
			{
				p = new android.widget.AbsListView.LayoutParams(android.view.ViewGroup.LayoutParams
					.MATCH_PARENT, android.view.ViewGroup.LayoutParams.WRAP_CONTENT, 0);
				child.setLayoutParams(p);
			}
			p.viewType = mAdapter.getItemViewType(position);
			p.forceAdd = true;
			int childWidthSpec = android.view.ViewGroup.getChildMeasureSpec(widthMeasureSpec, 
				mListPadding.left + mListPadding.right, p.width);
			int lpHeight = p.height;
			int childHeightSpec;
			if (lpHeight > 0)
			{
				childHeightSpec = android.view.View.MeasureSpec.makeMeasureSpec(lpHeight, android.view.View
					.MeasureSpec.EXACTLY);
			}
			else
			{
				childHeightSpec = android.view.View.MeasureSpec.makeMeasureSpec(0, android.view.View
					.MeasureSpec.UNSPECIFIED);
			}
			child.measure(childWidthSpec, childHeightSpec);
		}

		/// <returns>
		/// True to recycle the views used to measure this ListView in
		/// UNSPECIFIED/AT_MOST modes, false otherwise.
		/// </returns>
		/// <hide></hide>
		protected internal virtual bool recycleOnMeasure()
		{
			return true;
		}

		/// <summary>
		/// Measures the height of the given range of children (inclusive) and
		/// returns the height with this ListView's padding and divider heights
		/// included.
		/// </summary>
		/// <remarks>
		/// Measures the height of the given range of children (inclusive) and
		/// returns the height with this ListView's padding and divider heights
		/// included. If maxHeight is provided, the measuring will stop when the
		/// current height reaches maxHeight.
		/// </remarks>
		/// <param name="widthMeasureSpec">
		/// The width measure spec to be given to a child's
		/// <see cref="android.view.View.measure(int, int)">android.view.View.measure(int, int)
		/// 	</see>
		/// .
		/// </param>
		/// <param name="startPosition">The position of the first child to be shown.</param>
		/// <param name="endPosition">
		/// The (inclusive) position of the last child to be
		/// shown. Specify
		/// <see cref="NO_POSITION">NO_POSITION</see>
		/// if the last child should be
		/// the last available child from the adapter.
		/// </param>
		/// <param name="maxHeight">
		/// The maximum height that will be returned (if all the
		/// children don't fit in this value, this value will be
		/// returned).
		/// </param>
		/// <param name="disallowPartialChildPosition">
		/// In general, whether the returned
		/// height should only contain entire children. This is more
		/// powerful--it is the first inclusive position at which partial
		/// children will not be allowed. Example: it looks nice to have
		/// at least 3 completely visible children, and in portrait this
		/// will most likely fit; but in landscape there could be times
		/// when even 2 children can not be completely shown, so a value
		/// of 2 (remember, inclusive) would be good (assuming
		/// startPosition is 0).
		/// </param>
		/// <returns>The height of this ListView with the given children.</returns>
		internal int measureHeightOfChildren(int widthMeasureSpec, int startPosition, int
			 endPosition, int maxHeight, int disallowPartialChildPosition)
		{
			android.widget.ListAdapter adapter = mAdapter;
			if (adapter == null)
			{
				return mListPadding.top + mListPadding.bottom;
			}
			// Include the padding of the list
			int returnedHeight = mListPadding.top + mListPadding.bottom;
			int dividerHeight = ((mDividerHeight > 0) && mDivider != null) ? mDividerHeight : 
				0;
			// The previous height value that was less than maxHeight and contained
			// no partial children
			int prevHeightWithoutPartialChild = 0;
			int i;
			android.view.View child;
			// mItemCount - 1 since endPosition parameter is inclusive
			endPosition = (endPosition == NO_POSITION) ? adapter.getCount() - 1 : endPosition;
			android.widget.AbsListView.RecycleBin recycleBin = mRecycler;
			bool recyle = recycleOnMeasure();
			bool[] isScrap = mIsScrap;
			for (i = startPosition; i <= endPosition; ++i)
			{
				child = obtainView(i, isScrap);
				measureScrapChild(child, i, widthMeasureSpec);
				if (i > 0)
				{
					// Count the divider for all but one child
					returnedHeight += dividerHeight;
				}
				// Recycle the view before we possibly return from the method
				if (recyle && recycleBin.shouldRecycleViewType(((android.widget.AbsListView.LayoutParams
					)child.getLayoutParams()).viewType))
				{
					recycleBin.addScrapView(child, -1);
				}
				returnedHeight += child.getMeasuredHeight();
				if (returnedHeight >= maxHeight)
				{
					// We went over, figure out which height to return.  If returnedHeight > maxHeight,
					// then the i'th position did not fit completely.
					return (disallowPartialChildPosition >= 0) && (i > disallowPartialChildPosition) 
						&& (prevHeightWithoutPartialChild > 0) && (returnedHeight != maxHeight) ? prevHeightWithoutPartialChild
						 : maxHeight;
				}
				// Disallowing is enabled (> -1)
				// We've past the min pos
				// We have a prev height
				// i'th child did not fit completely
				if ((disallowPartialChildPosition >= 0) && (i >= disallowPartialChildPosition))
				{
					prevHeightWithoutPartialChild = returnedHeight;
				}
			}
			// At this point, we went through the range of children, and they each
			// completely fit, so return the returnedHeight
			return returnedHeight;
		}

		[Sharpen.OverridesMethod(@"android.widget.AbsListView")]
		internal override int findMotionRow(int y)
		{
			int childCount = getChildCount();
			if (childCount > 0)
			{
				if (!mStackFromBottom)
				{
					{
						for (int i = 0; i < childCount; i++)
						{
							android.view.View v = getChildAt(i);
							if (y <= v.getBottom())
							{
								return mFirstPosition + i;
							}
						}
					}
				}
				else
				{
					{
						for (int i = childCount - 1; i >= 0; i--)
						{
							android.view.View v = getChildAt(i);
							if (y >= v.getTop())
							{
								return mFirstPosition + i;
							}
						}
					}
				}
			}
			return android.widget.AdapterView.INVALID_POSITION;
		}

		/// <summary>
		/// Put a specific item at a specific location on the screen and then build
		/// up and down from there.
		/// </summary>
		/// <remarks>
		/// Put a specific item at a specific location on the screen and then build
		/// up and down from there.
		/// </remarks>
		/// <param name="position">The reference view to use as the starting point</param>
		/// <param name="top">
		/// Pixel offset from the top of this view to the top of the
		/// reference view.
		/// </param>
		/// <returns>
		/// The selected view, or null if the selected view is outside the
		/// visible area.
		/// </returns>
		private android.view.View fillSpecific(int position, int top)
		{
			bool tempIsSelected = position == mSelectedPosition;
			android.view.View temp = makeAndAddView(position, top, true, mListPadding.left, tempIsSelected
				);
			// Possibly changed again in fillUp if we add rows above this one.
			mFirstPosition = position;
			android.view.View above;
			android.view.View below;
			int dividerHeight = mDividerHeight;
			if (!mStackFromBottom)
			{
				above = fillUp(position - 1, temp.getTop() - dividerHeight);
				// This will correct for the top of the first view not touching the top of the list
				adjustViewsUpOrDown();
				below = fillDown(position + 1, temp.getBottom() + dividerHeight);
				int childCount = getChildCount();
				if (childCount > 0)
				{
					correctTooHigh(childCount);
				}
			}
			else
			{
				below = fillDown(position + 1, temp.getBottom() + dividerHeight);
				// This will correct for the bottom of the last view not touching the bottom of the list
				adjustViewsUpOrDown();
				above = fillUp(position - 1, temp.getTop() - dividerHeight);
				int childCount = getChildCount();
				if (childCount > 0)
				{
					correctTooLow(childCount);
				}
			}
			if (tempIsSelected)
			{
				return temp;
			}
			else
			{
				if (above != null)
				{
					return above;
				}
				else
				{
					return below;
				}
			}
		}

		/// <summary>
		/// Check if we have dragged the bottom of the list too high (we have pushed the
		/// top element off the top of the screen when we did not need to).
		/// </summary>
		/// <remarks>
		/// Check if we have dragged the bottom of the list too high (we have pushed the
		/// top element off the top of the screen when we did not need to). Correct by sliding
		/// everything back down.
		/// </remarks>
		/// <param name="childCount">Number of children</param>
		private void correctTooHigh(int childCount)
		{
			// First see if the last item is visible. If it is not, it is OK for the
			// top of the list to be pushed up.
			int lastPosition = mFirstPosition + childCount - 1;
			if (lastPosition == mItemCount - 1 && childCount > 0)
			{
				// Get the last child ...
				android.view.View lastChild = getChildAt(childCount - 1);
				// ... and its bottom edge
				int lastBottom = lastChild.getBottom();
				// This is bottom of our drawable area
				int end = (mBottom - mTop) - mListPadding.bottom;
				// This is how far the bottom edge of the last view is from the bottom of the
				// drawable area
				int bottomOffset = end - lastBottom;
				android.view.View firstChild = getChildAt(0);
				int firstTop = firstChild.getTop();
				// Make sure we are 1) Too high, and 2) Either there are more rows above the
				// first row or the first row is scrolled off the top of the drawable area
				if (bottomOffset > 0 && (mFirstPosition > 0 || firstTop < mListPadding.top))
				{
					if (mFirstPosition == 0)
					{
						// Don't pull the top too far down
						bottomOffset = System.Math.Min(bottomOffset, mListPadding.top - firstTop);
					}
					// Move everything down
					offsetChildrenTopAndBottom(bottomOffset);
					if (mFirstPosition > 0)
					{
						// Fill the gap that was opened above mFirstPosition with more rows, if
						// possible
						fillUp(mFirstPosition - 1, firstChild.getTop() - mDividerHeight);
						// Close up the remaining gap
						adjustViewsUpOrDown();
					}
				}
			}
		}

		/// <summary>
		/// Check if we have dragged the bottom of the list too low (we have pushed the
		/// bottom element off the bottom of the screen when we did not need to).
		/// </summary>
		/// <remarks>
		/// Check if we have dragged the bottom of the list too low (we have pushed the
		/// bottom element off the bottom of the screen when we did not need to). Correct by sliding
		/// everything back up.
		/// </remarks>
		/// <param name="childCount">Number of children</param>
		private void correctTooLow(int childCount)
		{
			// First see if the first item is visible. If it is not, it is OK for the
			// bottom of the list to be pushed down.
			if (mFirstPosition == 0 && childCount > 0)
			{
				// Get the first child ...
				android.view.View firstChild = getChildAt(0);
				// ... and its top edge
				int firstTop = firstChild.getTop();
				// This is top of our drawable area
				int start = mListPadding.top;
				// This is bottom of our drawable area
				int end = (mBottom - mTop) - mListPadding.bottom;
				// This is how far the top edge of the first view is from the top of the
				// drawable area
				int topOffset = firstTop - start;
				android.view.View lastChild = getChildAt(childCount - 1);
				int lastBottom = lastChild.getBottom();
				int lastPosition = mFirstPosition + childCount - 1;
				// Make sure we are 1) Too low, and 2) Either there are more rows below the
				// last row or the last row is scrolled off the bottom of the drawable area
				if (topOffset > 0)
				{
					if (lastPosition < mItemCount - 1 || lastBottom > end)
					{
						if (lastPosition == mItemCount - 1)
						{
							// Don't pull the bottom too far up
							topOffset = System.Math.Min(topOffset, lastBottom - end);
						}
						// Move everything up
						offsetChildrenTopAndBottom(-topOffset);
						if (lastPosition < mItemCount - 1)
						{
							// Fill the gap that was opened below the last position with more rows, if
							// possible
							fillDown(lastPosition + 1, lastChild.getBottom() + mDividerHeight);
							// Close up the remaining gap
							adjustViewsUpOrDown();
						}
					}
					else
					{
						if (lastPosition == mItemCount - 1)
						{
							adjustViewsUpOrDown();
						}
					}
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.widget.AbsListView")]
		protected internal override void layoutChildren()
		{
			bool blockLayoutRequests = mBlockLayoutRequests;
			if (!blockLayoutRequests)
			{
				mBlockLayoutRequests = true;
			}
			else
			{
				return;
			}
			try
			{
				base.layoutChildren();
				invalidate();
				if (mAdapter == null)
				{
					resetList();
					invokeOnItemScrollListener();
					return;
				}
				int childrenTop = mListPadding.top;
				int childrenBottom = mBottom - mTop - mListPadding.bottom;
				int childCount = getChildCount();
				int index = 0;
				int delta = 0;
				android.view.View sel;
				android.view.View oldSel = null;
				android.view.View oldFirst = null;
				android.view.View newSel = null;
				android.view.View focusLayoutRestoreView = null;
				switch (mLayoutMode)
				{
					case LAYOUT_SET_SELECTION:
					{
						// Remember stuff we will need down below
						index = mNextSelectedPosition - mFirstPosition;
						if (index >= 0 && index < childCount)
						{
							newSel = getChildAt(index);
						}
						break;
					}

					case LAYOUT_FORCE_TOP:
					case LAYOUT_FORCE_BOTTOM:
					case LAYOUT_SPECIFIC:
					case LAYOUT_SYNC:
					{
						break;
					}

					case LAYOUT_MOVE_SELECTION:
					default:
					{
						// Remember the previously selected view
						index = mSelectedPosition - mFirstPosition;
						if (index >= 0 && index < childCount)
						{
							oldSel = getChildAt(index);
						}
						// Remember the previous first child
						oldFirst = getChildAt(0);
						if (mNextSelectedPosition >= 0)
						{
							delta = mNextSelectedPosition - mSelectedPosition;
						}
						// Caution: newSel might be null
						newSel = getChildAt(index + delta);
						break;
					}
				}
				bool dataChanged = mDataChanged;
				if (dataChanged)
				{
					handleDataChanged();
				}
				// Handle the empty set by removing all views that are visible
				// and calling it a day
				if (mItemCount == 0)
				{
					resetList();
					invokeOnItemScrollListener();
					return;
				}
				else
				{
					if (mItemCount != mAdapter.getCount())
					{
						throw new System.InvalidOperationException("The content of the adapter has changed but "
							 + "ListView did not receive a notification. Make sure the content of " + "your adapter is not modified from a background thread, but only "
							 + "from the UI thread. [in ListView(" + getId() + ", " + GetType() + ") with Adapter("
							 + mAdapter.GetType() + ")]");
					}
				}
				setSelectedPositionInt(mNextSelectedPosition);
				// Pull all children into the RecycleBin.
				// These views will be reused if possible
				int firstPosition = mFirstPosition;
				android.widget.AbsListView.RecycleBin recycleBin = mRecycler;
				// reset the focus restoration
				android.view.View focusLayoutRestoreDirectChild = null;
				// Don't put header or footer views into the Recycler. Those are
				// already cached in mHeaderViews;
				if (dataChanged)
				{
					{
						for (int i = 0; i < childCount; i++)
						{
							recycleBin.addScrapView(getChildAt(i), firstPosition + i);
						}
					}
				}
				else
				{
					recycleBin.fillActiveViews(childCount, firstPosition);
				}
				// take focus back to us temporarily to avoid the eventual
				// call to clear focus when removing the focused child below
				// from messing things up when ViewAncestor assigns focus back
				// to someone else
				android.view.View focusedChild = getFocusedChild();
				if (focusedChild != null)
				{
					// TODO: in some cases focusedChild.getParent() == null
					// we can remember the focused view to restore after relayout if the
					// data hasn't changed, or if the focused position is a header or footer
					if (!dataChanged || isDirectChildHeaderOrFooter(focusedChild))
					{
						focusLayoutRestoreDirectChild = focusedChild;
						// remember the specific view that had focus
						focusLayoutRestoreView = findFocus();
						if (focusLayoutRestoreView != null)
						{
							// tell it we are going to mess with it
							focusLayoutRestoreView.onStartTemporaryDetach();
						}
					}
					requestFocus();
				}
				// Clear out old views
				detachAllViewsFromParent();
				switch (mLayoutMode)
				{
					case LAYOUT_SET_SELECTION:
					{
						if (newSel != null)
						{
							sel = fillFromSelection(newSel.getTop(), childrenTop, childrenBottom);
						}
						else
						{
							sel = fillFromMiddle(childrenTop, childrenBottom);
						}
						break;
					}

					case LAYOUT_SYNC:
					{
						sel = fillSpecific(mSyncPosition, mSpecificTop);
						break;
					}

					case LAYOUT_FORCE_BOTTOM:
					{
						sel = fillUp(mItemCount - 1, childrenBottom);
						adjustViewsUpOrDown();
						break;
					}

					case LAYOUT_FORCE_TOP:
					{
						mFirstPosition = 0;
						sel = fillFromTop(childrenTop);
						adjustViewsUpOrDown();
						break;
					}

					case LAYOUT_SPECIFIC:
					{
						sel = fillSpecific(reconcileSelectedPosition(), mSpecificTop);
						break;
					}

					case LAYOUT_MOVE_SELECTION:
					{
						sel = moveSelection(oldSel, newSel, delta, childrenTop, childrenBottom);
						break;
					}

					default:
					{
						if (childCount == 0)
						{
							if (!mStackFromBottom)
							{
								int position = lookForSelectablePosition(0, true);
								setSelectedPositionInt(position);
								sel = fillFromTop(childrenTop);
							}
							else
							{
								int position = lookForSelectablePosition(mItemCount - 1, false);
								setSelectedPositionInt(position);
								sel = fillUp(mItemCount - 1, childrenBottom);
							}
						}
						else
						{
							if (mSelectedPosition >= 0 && mSelectedPosition < mItemCount)
							{
								sel = fillSpecific(mSelectedPosition, oldSel == null ? childrenTop : oldSel.getTop
									());
							}
							else
							{
								if (mFirstPosition < mItemCount)
								{
									sel = fillSpecific(mFirstPosition, oldFirst == null ? childrenTop : oldFirst.getTop
										());
								}
								else
								{
									sel = fillSpecific(0, childrenTop);
								}
							}
						}
						break;
					}
				}
				// Flush any cached views that did not get reused above
				recycleBin.scrapActiveViews();
				if (sel != null)
				{
					// the current selected item should get focus if items
					// are focusable
					if (mItemsCanFocus && hasFocus() && !sel.hasFocus())
					{
						bool focusWasTaken = (sel == focusLayoutRestoreDirectChild && focusLayoutRestoreView
							.requestFocus()) || sel.requestFocus();
						if (!focusWasTaken)
						{
							// selected item didn't take focus, fine, but still want
							// to make sure something else outside of the selected view
							// has focus
							android.view.View focused = getFocusedChild();
							if (focused != null)
							{
								focused.clearFocus();
							}
							positionSelector(android.widget.AdapterView.INVALID_POSITION, sel);
						}
						else
						{
							sel.setSelected(false);
							mSelectorRect.setEmpty();
						}
					}
					else
					{
						positionSelector(android.widget.AdapterView.INVALID_POSITION, sel);
					}
					mSelectedTop = sel.getTop();
				}
				else
				{
					if (mTouchMode > TOUCH_MODE_DOWN && mTouchMode < TOUCH_MODE_SCROLL)
					{
						android.view.View child = getChildAt(mMotionPosition - mFirstPosition);
						if (child != null)
						{
							positionSelector(mMotionPosition, child);
						}
					}
					else
					{
						mSelectedTop = 0;
						mSelectorRect.setEmpty();
					}
					// even if there is not selected position, we may need to restore
					// focus (i.e. something focusable in touch mode)
					if (hasFocus() && focusLayoutRestoreView != null)
					{
						focusLayoutRestoreView.requestFocus();
					}
				}
				// tell focus view we are done mucking with it, if it is still in
				// our view hierarchy.
				if (focusLayoutRestoreView != null && focusLayoutRestoreView.getWindowToken() != 
					null)
				{
					focusLayoutRestoreView.onFinishTemporaryDetach();
				}
				mLayoutMode = LAYOUT_NORMAL;
				mDataChanged = false;
				mNeedSync = false;
				setNextSelectedPositionInt(mSelectedPosition);
				updateScrollIndicators();
				if (mItemCount > 0)
				{
					checkSelectionChanged();
				}
				invokeOnItemScrollListener();
			}
			finally
			{
				if (!blockLayoutRequests)
				{
					mBlockLayoutRequests = false;
				}
			}
		}

		/// <param name="child">a direct child of this list.</param>
		/// <returns>Whether child is a header or footer view.</returns>
		private bool isDirectChildHeaderOrFooter(android.view.View child)
		{
			java.util.ArrayList<android.widget.ListView.FixedViewInfo> headers = mHeaderViewInfos;
			int numHeaders = headers.size();
			{
				for (int i = 0; i < numHeaders; i++)
				{
					if (child == headers.get(i).view)
					{
						return true;
					}
				}
			}
			java.util.ArrayList<android.widget.ListView.FixedViewInfo> footers = mFooterViewInfos;
			int numFooters = footers.size();
			{
				for (int i_1 = 0; i_1 < numFooters; i_1++)
				{
					if (child == footers.get(i_1).view)
					{
						return true;
					}
				}
			}
			return false;
		}

		/// <summary>Obtain the view and add it to our list of children.</summary>
		/// <remarks>
		/// Obtain the view and add it to our list of children. The view can be made
		/// fresh, converted from an unused view, or used as is if it was in the
		/// recycle bin.
		/// </remarks>
		/// <param name="position">Logical position in the list</param>
		/// <param name="y">Top or bottom edge of the view to add</param>
		/// <param name="flow">
		/// If flow is true, align top edge to y. If false, align bottom
		/// edge to y.
		/// </param>
		/// <param name="childrenLeft">Left edge where children should be positioned</param>
		/// <param name="selected">Is this position selected?</param>
		/// <returns>View that was added</returns>
		private android.view.View makeAndAddView(int position, int y, bool flow, int childrenLeft
			, bool selected)
		{
			android.view.View child;
			if (!mDataChanged)
			{
				// Try to use an existing view for this position
				child = mRecycler.getActiveView(position);
				if (child != null)
				{
					// Found it -- we're using an existing child
					// This just needs to be positioned
					setupChild(child, position, y, flow, childrenLeft, selected, true);
					return child;
				}
			}
			// Make a new view for this position, or convert an unused view if possible
			child = obtainView(position, mIsScrap);
			// This needs to be positioned and measured
			setupChild(child, position, y, flow, childrenLeft, selected, mIsScrap[0]);
			return child;
		}

		/// <summary>
		/// Add a view as a child and make sure it is measured (if necessary) and
		/// positioned properly.
		/// </summary>
		/// <remarks>
		/// Add a view as a child and make sure it is measured (if necessary) and
		/// positioned properly.
		/// </remarks>
		/// <param name="child">The view to add</param>
		/// <param name="position">The position of this child</param>
		/// <param name="y">The y position relative to which this view will be positioned</param>
		/// <param name="flowDown">
		/// If true, align top edge to y. If false, align bottom
		/// edge to y.
		/// </param>
		/// <param name="childrenLeft">Left edge where children should be positioned</param>
		/// <param name="selected">Is this position selected?</param>
		/// <param name="recycled">
		/// Has this view been pulled from the recycle bin? If so it
		/// does not need to be remeasured.
		/// </param>
		private void setupChild(android.view.View child, int position, int y, bool flowDown
			, int childrenLeft, bool selected, bool recycled)
		{
			bool isSelected_1 = selected && shouldShowSelector();
			bool updateChildSelected = isSelected_1 != child.isSelected();
			int mode = mTouchMode;
			bool isPressed_1 = mode > TOUCH_MODE_DOWN && mode < TOUCH_MODE_SCROLL && mMotionPosition
				 == position;
			bool updateChildPressed = isPressed_1 != child.isPressed();
			bool needToMeasure = !recycled || updateChildSelected || child.isLayoutRequested(
				);
			// Respect layout params that are already in the view. Otherwise make some up...
			// noinspection unchecked
			android.widget.AbsListView.LayoutParams p = (android.widget.AbsListView.LayoutParams
				)child.getLayoutParams();
			if (p == null)
			{
				p = new android.widget.AbsListView.LayoutParams(android.view.ViewGroup.LayoutParams
					.MATCH_PARENT, android.view.ViewGroup.LayoutParams.WRAP_CONTENT, 0);
			}
			p.viewType = mAdapter.getItemViewType(position);
			if ((recycled && !p.forceAdd) || (p.recycledHeaderFooter && p.viewType == android.widget.AdapterView.ITEM_VIEW_TYPE_HEADER_OR_FOOTER
				))
			{
				attachViewToParent(child, flowDown ? -1 : 0, p);
			}
			else
			{
				p.forceAdd = false;
				if (p.viewType == android.widget.AdapterView.ITEM_VIEW_TYPE_HEADER_OR_FOOTER)
				{
					p.recycledHeaderFooter = true;
				}
				addViewInLayout(child, flowDown ? -1 : 0, p, true);
			}
			if (updateChildSelected)
			{
				child.setSelected(isSelected_1);
			}
			if (updateChildPressed)
			{
				child.setPressed(isPressed_1);
			}
			if (mChoiceMode != CHOICE_MODE_NONE && mCheckStates != null)
			{
				if (child is android.widget.Checkable)
				{
					((android.widget.Checkable)child).setChecked(mCheckStates.get(position));
				}
				else
				{
					if (getContext().getApplicationInfo().targetSdkVersion >= android.os.Build.VERSION_CODES
						.HONEYCOMB)
					{
						child.setActivated(mCheckStates.get(position));
					}
				}
			}
			if (needToMeasure)
			{
				int childWidthSpec = android.view.ViewGroup.getChildMeasureSpec(mWidthMeasureSpec
					, mListPadding.left + mListPadding.right, p.width);
				int lpHeight = p.height;
				int childHeightSpec;
				if (lpHeight > 0)
				{
					childHeightSpec = android.view.View.MeasureSpec.makeMeasureSpec(lpHeight, android.view.View
						.MeasureSpec.EXACTLY);
				}
				else
				{
					childHeightSpec = android.view.View.MeasureSpec.makeMeasureSpec(0, android.view.View
						.MeasureSpec.UNSPECIFIED);
				}
				child.measure(childWidthSpec, childHeightSpec);
			}
			else
			{
				cleanupLayoutState(child);
			}
			int w = child.getMeasuredWidth();
			int h = child.getMeasuredHeight();
			int childTop = flowDown ? y : y - h;
			if (needToMeasure)
			{
				int childRight = childrenLeft + w;
				int childBottom = childTop + h;
				child.layout(childrenLeft, childTop, childRight, childBottom);
			}
			else
			{
				child.offsetLeftAndRight(childrenLeft - child.getLeft());
				child.offsetTopAndBottom(childTop - child.getTop());
			}
			if (mCachingStarted && !child.isDrawingCacheEnabled())
			{
				child.setDrawingCacheEnabled(true);
			}
			if (recycled && (((android.widget.AbsListView.LayoutParams)child.getLayoutParams(
				)).scrappedFromPosition) != position)
			{
				child.jumpDrawablesToCurrentState();
			}
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		protected internal override bool canAnimate()
		{
			return base.canAnimate() && mItemCount > 0;
		}

		/// <summary>Sets the currently selected item.</summary>
		/// <remarks>
		/// Sets the currently selected item. If in touch mode, the item will not be selected
		/// but it will still be positioned appropriately. If the specified selection position
		/// is less than 0, then the item at position 0 will be selected.
		/// </remarks>
		/// <param name="position">Index (starting at 0) of the data item to be selected.</param>
		[Sharpen.OverridesMethod(@"android.widget.AdapterView")]
		public override void setSelection(int position)
		{
			setSelectionFromTop(position, 0);
		}

		/// <summary>
		/// Sets the selected item and positions the selection y pixels from the top edge
		/// of the ListView.
		/// </summary>
		/// <remarks>
		/// Sets the selected item and positions the selection y pixels from the top edge
		/// of the ListView. (If in touch mode, the item will not be selected but it will
		/// still be positioned appropriately.)
		/// </remarks>
		/// <param name="position">Index (starting at 0) of the data item to be selected.</param>
		/// <param name="y">
		/// The distance from the top edge of the ListView (plus padding) that the
		/// item will be positioned.
		/// </param>
		public virtual void setSelectionFromTop(int position, int y)
		{
			if (mAdapter == null)
			{
				return;
			}
			if (!isInTouchMode())
			{
				position = lookForSelectablePosition(position, true);
				if (position >= 0)
				{
					setNextSelectedPositionInt(position);
				}
			}
			else
			{
				mResurrectToPosition = position;
			}
			if (position >= 0)
			{
				mLayoutMode = LAYOUT_SPECIFIC;
				mSpecificTop = mListPadding.top + y;
				if (mNeedSync)
				{
					mSyncPosition = position;
					mSyncRowId = mAdapter.getItemId(position);
				}
				requestLayout();
			}
		}

		/// <summary>Makes the item at the supplied position selected.</summary>
		/// <remarks>Makes the item at the supplied position selected.</remarks>
		/// <param name="position">the position of the item to select</param>
		[Sharpen.OverridesMethod(@"android.widget.AbsListView")]
		internal override void setSelectionInt(int position)
		{
			setNextSelectedPositionInt(position);
			bool awakeScrollbars = false;
			int selectedPosition = mSelectedPosition;
			if (selectedPosition >= 0)
			{
				if (position == selectedPosition - 1)
				{
					awakeScrollbars = true;
				}
				else
				{
					if (position == selectedPosition + 1)
					{
						awakeScrollbars = true;
					}
				}
			}
			layoutChildren();
			if (awakeScrollbars)
			{
				awakenScrollBars();
			}
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
		[Sharpen.OverridesMethod(@"android.widget.AdapterView")]
		internal override int lookForSelectablePosition(int position, bool lookDown)
		{
			android.widget.ListAdapter adapter = mAdapter;
			if (adapter == null || isInTouchMode())
			{
				return android.widget.AdapterView.INVALID_POSITION;
			}
			int count = adapter.getCount();
			if (!mAreAllItemsSelectable)
			{
				if (lookDown)
				{
					position = System.Math.Max(0, position);
					while (position < count && !adapter.isEnabled(position))
					{
						position++;
					}
				}
				else
				{
					position = System.Math.Min(position, count - 1);
					while (position >= 0 && !adapter.isEnabled(position))
					{
						position--;
					}
				}
				if (position < 0 || position >= count)
				{
					return android.widget.AdapterView.INVALID_POSITION;
				}
				return position;
			}
			else
			{
				if (position < 0 || position >= count)
				{
					return android.widget.AdapterView.INVALID_POSITION;
				}
				return position;
			}
		}

		/// <summary>
		/// setSelectionAfterHeaderView set the selection to be the first list item
		/// after the header views.
		/// </summary>
		/// <remarks>
		/// setSelectionAfterHeaderView set the selection to be the first list item
		/// after the header views.
		/// </remarks>
		public virtual void setSelectionAfterHeaderView()
		{
			int count = mHeaderViewInfos.size();
			if (count > 0)
			{
				mNextSelectedPosition = 0;
				return;
			}
			if (mAdapter != null)
			{
				setSelection(count);
			}
			else
			{
				mNextSelectedPosition = count;
				mLayoutMode = LAYOUT_SET_SELECTION;
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool dispatchKeyEvent(android.view.KeyEvent @event)
		{
			// Dispatch in the normal way
			bool handled = base.dispatchKeyEvent(@event);
			if (!handled)
			{
				// If we didn't handle it...
				android.view.View focused = getFocusedChild();
				if (focused != null && @event.getAction() == android.view.KeyEvent.ACTION_DOWN)
				{
					// ... and our focused child didn't handle it
					// ... give it to ourselves so we can scroll if necessary
					handled = onKeyDown(@event.getKeyCode(), @event);
				}
			}
			return handled;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool onKeyDown(int keyCode, android.view.KeyEvent @event)
		{
			return commonKey(keyCode, 1, @event);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool onKeyMultiple(int keyCode, int repeatCount, android.view.KeyEvent
			 @event)
		{
			return commonKey(keyCode, repeatCount, @event);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool onKeyUp(int keyCode, android.view.KeyEvent @event)
		{
			return commonKey(keyCode, 1, @event);
		}

		private bool commonKey(int keyCode, int count, android.view.KeyEvent @event)
		{
			if (mAdapter == null || !mIsAttached)
			{
				return false;
			}
			if (mDataChanged)
			{
				layoutChildren();
			}
			bool handled = false;
			int action = @event.getAction();
			if (action != android.view.KeyEvent.ACTION_UP)
			{
				switch (keyCode)
				{
					case android.view.KeyEvent.KEYCODE_DPAD_UP:
					{
						if (@event.hasNoModifiers())
						{
							handled = resurrectSelectionIfNeeded();
							if (!handled)
							{
								while (count-- > 0)
								{
									if (arrowScroll(FOCUS_UP))
									{
										handled = true;
									}
									else
									{
										break;
									}
								}
							}
						}
						else
						{
							if (@event.hasModifiers(android.view.KeyEvent.META_ALT_ON))
							{
								handled = resurrectSelectionIfNeeded() || fullScroll(FOCUS_UP);
							}
						}
						break;
					}

					case android.view.KeyEvent.KEYCODE_DPAD_DOWN:
					{
						if (@event.hasNoModifiers())
						{
							handled = resurrectSelectionIfNeeded();
							if (!handled)
							{
								while (count-- > 0)
								{
									if (arrowScroll(FOCUS_DOWN))
									{
										handled = true;
									}
									else
									{
										break;
									}
								}
							}
						}
						else
						{
							if (@event.hasModifiers(android.view.KeyEvent.META_ALT_ON))
							{
								handled = resurrectSelectionIfNeeded() || fullScroll(FOCUS_DOWN);
							}
						}
						break;
					}

					case android.view.KeyEvent.KEYCODE_DPAD_LEFT:
					{
						if (@event.hasNoModifiers())
						{
							handled = handleHorizontalFocusWithinListItem(android.view.View.FOCUS_LEFT);
						}
						break;
					}

					case android.view.KeyEvent.KEYCODE_DPAD_RIGHT:
					{
						if (@event.hasNoModifiers())
						{
							handled = handleHorizontalFocusWithinListItem(android.view.View.FOCUS_RIGHT);
						}
						break;
					}

					case android.view.KeyEvent.KEYCODE_DPAD_CENTER:
					case android.view.KeyEvent.KEYCODE_ENTER:
					{
						if (@event.hasNoModifiers())
						{
							handled = resurrectSelectionIfNeeded();
							if (!handled && @event.getRepeatCount() == 0 && getChildCount() > 0)
							{
								keyPressed();
								handled = true;
							}
						}
						break;
					}

					case android.view.KeyEvent.KEYCODE_SPACE:
					{
						if (mPopup == null || !mPopup.isShowing())
						{
							if (@event.hasNoModifiers())
							{
								handled = resurrectSelectionIfNeeded() || pageScroll(FOCUS_DOWN);
							}
							else
							{
								if (@event.hasModifiers(android.view.KeyEvent.META_SHIFT_ON))
								{
									handled = resurrectSelectionIfNeeded() || pageScroll(FOCUS_UP);
								}
							}
							handled = true;
						}
						break;
					}

					case android.view.KeyEvent.KEYCODE_PAGE_UP:
					{
						if (@event.hasNoModifiers())
						{
							handled = resurrectSelectionIfNeeded() || pageScroll(FOCUS_UP);
						}
						else
						{
							if (@event.hasModifiers(android.view.KeyEvent.META_ALT_ON))
							{
								handled = resurrectSelectionIfNeeded() || fullScroll(FOCUS_UP);
							}
						}
						break;
					}

					case android.view.KeyEvent.KEYCODE_PAGE_DOWN:
					{
						if (@event.hasNoModifiers())
						{
							handled = resurrectSelectionIfNeeded() || pageScroll(FOCUS_DOWN);
						}
						else
						{
							if (@event.hasModifiers(android.view.KeyEvent.META_ALT_ON))
							{
								handled = resurrectSelectionIfNeeded() || fullScroll(FOCUS_DOWN);
							}
						}
						break;
					}

					case android.view.KeyEvent.KEYCODE_MOVE_HOME:
					{
						if (@event.hasNoModifiers())
						{
							handled = resurrectSelectionIfNeeded() || fullScroll(FOCUS_UP);
						}
						break;
					}

					case android.view.KeyEvent.KEYCODE_MOVE_END:
					{
						if (@event.hasNoModifiers())
						{
							handled = resurrectSelectionIfNeeded() || fullScroll(FOCUS_DOWN);
						}
						break;
					}

					case android.view.KeyEvent.KEYCODE_TAB:
					{
						// XXX Sometimes it is useful to be able to TAB through the items in
						//     a ListView sequentially.  Unfortunately this can create an
						//     asymmetry in TAB navigation order unless the list selection
						//     always reverts to the top or bottom when receiving TAB focus from
						//     another widget.  Leaving this behavior disabled for now but
						//     perhaps it should be configurable (and more comprehensive).
						if (false)
						{
							if (@event.hasNoModifiers())
							{
								handled = resurrectSelectionIfNeeded() || arrowScroll(FOCUS_DOWN);
							}
							else
							{
								if (@event.hasModifiers(android.view.KeyEvent.META_SHIFT_ON))
								{
									handled = resurrectSelectionIfNeeded() || arrowScroll(FOCUS_UP);
								}
							}
						}
						break;
					}
				}
			}
			if (handled)
			{
				return true;
			}
			if (sendToTextFilter(keyCode, count, @event))
			{
				return true;
			}
			switch (action)
			{
				case android.view.KeyEvent.ACTION_DOWN:
				{
					return base.onKeyDown(keyCode, @event);
				}

				case android.view.KeyEvent.ACTION_UP:
				{
					return base.onKeyUp(keyCode, @event);
				}

				case android.view.KeyEvent.ACTION_MULTIPLE:
				{
					return base.onKeyMultiple(keyCode, count, @event);
				}

				default:
				{
					// shouldn't happen
					return false;
				}
			}
		}

		/// <summary>Scrolls up or down by the number of items currently present on screen.</summary>
		/// <remarks>Scrolls up or down by the number of items currently present on screen.</remarks>
		/// <param name="direction">
		/// either
		/// <see cref="android.view.View.FOCUS_UP">android.view.View.FOCUS_UP</see>
		/// or
		/// <see cref="android.view.View.FOCUS_DOWN">android.view.View.FOCUS_DOWN</see>
		/// </param>
		/// <returns>whether selection was moved</returns>
		internal virtual bool pageScroll(int direction)
		{
			int nextPage = -1;
			bool down = false;
			if (direction == FOCUS_UP)
			{
				nextPage = System.Math.Max(0, mSelectedPosition - getChildCount() - 1);
			}
			else
			{
				if (direction == FOCUS_DOWN)
				{
					nextPage = System.Math.Min(mItemCount - 1, mSelectedPosition + getChildCount() - 
						1);
					down = true;
				}
			}
			if (nextPage >= 0)
			{
				int position = lookForSelectablePosition(nextPage, down);
				if (position >= 0)
				{
					mLayoutMode = LAYOUT_SPECIFIC;
					mSpecificTop = mPaddingTop + getVerticalFadingEdgeLength();
					if (down && position > mItemCount - getChildCount())
					{
						mLayoutMode = LAYOUT_FORCE_BOTTOM;
					}
					if (!down && position < getChildCount())
					{
						mLayoutMode = LAYOUT_FORCE_TOP;
					}
					setSelectionInt(position);
					invokeOnItemScrollListener();
					if (!awakenScrollBars())
					{
						invalidate();
					}
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Go to the last or first item if possible (not worrying about panning across or navigating
		/// within the internal focus of the currently selected item.)
		/// </summary>
		/// <param name="direction">
		/// either
		/// <see cref="android.view.View.FOCUS_UP">android.view.View.FOCUS_UP</see>
		/// or
		/// <see cref="android.view.View.FOCUS_DOWN">android.view.View.FOCUS_DOWN</see>
		/// </param>
		/// <returns>whether selection was moved</returns>
		internal virtual bool fullScroll(int direction)
		{
			bool moved = false;
			if (direction == FOCUS_UP)
			{
				if (mSelectedPosition != 0)
				{
					int position = lookForSelectablePosition(0, true);
					if (position >= 0)
					{
						mLayoutMode = LAYOUT_FORCE_TOP;
						setSelectionInt(position);
						invokeOnItemScrollListener();
					}
					moved = true;
				}
			}
			else
			{
				if (direction == FOCUS_DOWN)
				{
					if (mSelectedPosition < mItemCount - 1)
					{
						int position = lookForSelectablePosition(mItemCount - 1, true);
						if (position >= 0)
						{
							mLayoutMode = LAYOUT_FORCE_BOTTOM;
							setSelectionInt(position);
							invokeOnItemScrollListener();
						}
						moved = true;
					}
				}
			}
			if (moved && !awakenScrollBars())
			{
				awakenScrollBars();
				invalidate();
			}
			return moved;
		}

		/// <summary>
		/// To avoid horizontal focus searches changing the selected item, we
		/// manually focus search within the selected item (as applicable), and
		/// prevent focus from jumping to something within another item.
		/// </summary>
		/// <remarks>
		/// To avoid horizontal focus searches changing the selected item, we
		/// manually focus search within the selected item (as applicable), and
		/// prevent focus from jumping to something within another item.
		/// </remarks>
		/// <param name="direction">one of {View.FOCUS_LEFT, View.FOCUS_RIGHT}</param>
		/// <returns>Whether this consumes the key event.</returns>
		private bool handleHorizontalFocusWithinListItem(int direction)
		{
			if (direction != android.view.View.FOCUS_LEFT && direction != android.view.View.FOCUS_RIGHT)
			{
				throw new System.ArgumentException("direction must be one of" + " {View.FOCUS_LEFT, View.FOCUS_RIGHT}"
					);
			}
			int numChildren = getChildCount();
			if (mItemsCanFocus && numChildren > 0 && mSelectedPosition != android.widget.AdapterView.INVALID_POSITION)
			{
				android.view.View selectedView = getSelectedView();
				if (selectedView != null && selectedView.hasFocus() && selectedView is android.view.ViewGroup)
				{
					android.view.View currentFocus = selectedView.findFocus();
					android.view.View nextFocus = android.view.FocusFinder.getInstance().findNextFocus
						((android.view.ViewGroup)selectedView, currentFocus, direction);
					if (nextFocus != null)
					{
						// do the math to get interesting rect in next focus' coordinates
						currentFocus.getFocusedRect(mTempRect);
						offsetDescendantRectToMyCoords(currentFocus, mTempRect);
						offsetRectIntoDescendantCoords(nextFocus, mTempRect);
						if (nextFocus.requestFocus(direction, mTempRect))
						{
							return true;
						}
					}
					// we are blocking the key from being handled (by returning true)
					// if the global result is going to be some other view within this
					// list.  this is to acheive the overall goal of having
					// horizontal d-pad navigation remain in the current item.
					android.view.View globalNextFocus = android.view.FocusFinder.getInstance().findNextFocus
						((android.view.ViewGroup)getRootView(), currentFocus, direction);
					if (globalNextFocus != null)
					{
						return isViewAncestorOf(globalNextFocus, this);
					}
				}
			}
			return false;
		}

		/// <summary>Scrolls to the next or previous item if possible.</summary>
		/// <remarks>Scrolls to the next or previous item if possible.</remarks>
		/// <param name="direction">
		/// either
		/// <see cref="android.view.View.FOCUS_UP">android.view.View.FOCUS_UP</see>
		/// or
		/// <see cref="android.view.View.FOCUS_DOWN">android.view.View.FOCUS_DOWN</see>
		/// </param>
		/// <returns>whether selection was moved</returns>
		internal virtual bool arrowScroll(int direction)
		{
			try
			{
				mInLayout = true;
				bool handled = arrowScrollImpl(direction);
				if (handled)
				{
					playSoundEffect(android.view.SoundEffectConstants.getContantForFocusDirection(direction
						));
				}
				return handled;
			}
			finally
			{
				mInLayout = false;
			}
		}

		/// <summary>Handle an arrow scroll going up or down.</summary>
		/// <remarks>
		/// Handle an arrow scroll going up or down.  Take into account whether items are selectable,
		/// whether there are focusable items etc.
		/// </remarks>
		/// <param name="direction">
		/// Either
		/// <see cref="android.view.View.FOCUS_UP">android.view.View.FOCUS_UP</see>
		/// or
		/// <see cref="android.view.View.FOCUS_DOWN">android.view.View.FOCUS_DOWN</see>
		/// .
		/// </param>
		/// <returns>Whether any scrolling, selection or focus change occured.</returns>
		private bool arrowScrollImpl(int direction)
		{
			if (getChildCount() <= 0)
			{
				return false;
			}
			android.view.View selectedView = getSelectedView();
			int selectedPos = mSelectedPosition;
			int nextSelectedPosition = lookForSelectablePositionOnScreen(direction);
			int amountToScroll_1 = amountToScroll(direction, nextSelectedPosition);
			// if we are moving focus, we may OVERRIDE the default behavior
			android.widget.ListView.ArrowScrollFocusResult focusResult = mItemsCanFocus ? arrowScrollFocused
				(direction) : null;
			if (focusResult != null)
			{
				nextSelectedPosition = focusResult.getSelectedPosition();
				amountToScroll_1 = focusResult.getAmountToScroll();
			}
			bool needToRedraw = focusResult != null;
			if (nextSelectedPosition != android.widget.AdapterView.INVALID_POSITION)
			{
				handleNewSelectionChange(selectedView, direction, nextSelectedPosition, focusResult
					 != null);
				setSelectedPositionInt(nextSelectedPosition);
				setNextSelectedPositionInt(nextSelectedPosition);
				selectedView = getSelectedView();
				selectedPos = nextSelectedPosition;
				if (mItemsCanFocus && focusResult == null)
				{
					// there was no new view found to take focus, make sure we
					// don't leave focus with the old selection
					android.view.View focused = getFocusedChild();
					if (focused != null)
					{
						focused.clearFocus();
					}
				}
				needToRedraw = true;
				checkSelectionChanged();
			}
			if (amountToScroll_1 > 0)
			{
				scrollListItemsBy((direction == android.view.View.FOCUS_UP) ? amountToScroll_1 : 
					-amountToScroll_1);
				needToRedraw = true;
			}
			// if we didn't find a new focusable, make sure any existing focused
			// item that was panned off screen gives up focus.
			if (mItemsCanFocus && (focusResult == null) && selectedView != null && selectedView
				.hasFocus())
			{
				android.view.View focused = selectedView.findFocus();
				if (!isViewAncestorOf(focused, this) || distanceToView(focused) > 0)
				{
					focused.clearFocus();
				}
			}
			// if  the current selection is panned off, we need to remove the selection
			if (nextSelectedPosition == android.widget.AdapterView.INVALID_POSITION && selectedView
				 != null && !isViewAncestorOf(selectedView, this))
			{
				selectedView = null;
				hideSelector();
				// but we don't want to set the ressurect position (that would make subsequent
				// unhandled key events bring back the item we just scrolled off!)
				mResurrectToPosition = android.widget.AdapterView.INVALID_POSITION;
			}
			if (needToRedraw)
			{
				if (selectedView != null)
				{
					positionSelector(selectedPos, selectedView);
					mSelectedTop = selectedView.getTop();
				}
				if (!awakenScrollBars())
				{
					invalidate();
				}
				invokeOnItemScrollListener();
				return true;
			}
			return false;
		}

		/// <summary>
		/// When selection changes, it is possible that the previously selected or the
		/// next selected item will change its size.
		/// </summary>
		/// <remarks>
		/// When selection changes, it is possible that the previously selected or the
		/// next selected item will change its size.  If so, we need to offset some folks,
		/// and re-layout the items as appropriate.
		/// </remarks>
		/// <param name="selectedView">
		/// The currently selected view (before changing selection).
		/// should be <code>null</code> if there was no previous selection.
		/// </param>
		/// <param name="direction">
		/// Either
		/// <see cref="android.view.View.FOCUS_UP">android.view.View.FOCUS_UP</see>
		/// or
		/// <see cref="android.view.View.FOCUS_DOWN">android.view.View.FOCUS_DOWN</see>
		/// .
		/// </param>
		/// <param name="newSelectedPosition">The position of the next selection.</param>
		/// <param name="newFocusAssigned">
		/// whether new focus was assigned.  This matters because
		/// when something has focus, we don't want to show selection (ugh).
		/// </param>
		private void handleNewSelectionChange(android.view.View selectedView, int direction
			, int newSelectedPosition, bool newFocusAssigned)
		{
			if (newSelectedPosition == android.widget.AdapterView.INVALID_POSITION)
			{
				throw new System.ArgumentException("newSelectedPosition needs to be valid");
			}
			// whether or not we are moving down or up, we want to preserve the
			// top of whatever view is on top:
			// - moving down: the view that had selection
			// - moving up: the view that is getting selection
			android.view.View topView;
			android.view.View bottomView;
			int topViewIndex;
			int bottomViewIndex;
			bool topSelected = false;
			int selectedIndex = mSelectedPosition - mFirstPosition;
			int nextSelectedIndex = newSelectedPosition - mFirstPosition;
			if (direction == android.view.View.FOCUS_UP)
			{
				topViewIndex = nextSelectedIndex;
				bottomViewIndex = selectedIndex;
				topView = getChildAt(topViewIndex);
				bottomView = selectedView;
				topSelected = true;
			}
			else
			{
				topViewIndex = selectedIndex;
				bottomViewIndex = nextSelectedIndex;
				topView = selectedView;
				bottomView = getChildAt(bottomViewIndex);
			}
			int numChildren = getChildCount();
			// start with top view: is it changing size?
			if (topView != null)
			{
				topView.setSelected(!newFocusAssigned && topSelected);
				measureAndAdjustDown(topView, topViewIndex, numChildren);
			}
			// is the bottom view changing size?
			if (bottomView != null)
			{
				bottomView.setSelected(!newFocusAssigned && !topSelected);
				measureAndAdjustDown(bottomView, bottomViewIndex, numChildren);
			}
		}

		/// <summary>
		/// Re-measure a child, and if its height changes, lay it out preserving its
		/// top, and adjust the children below it appropriately.
		/// </summary>
		/// <remarks>
		/// Re-measure a child, and if its height changes, lay it out preserving its
		/// top, and adjust the children below it appropriately.
		/// </remarks>
		/// <param name="child">The child</param>
		/// <param name="childIndex">The view group index of the child.</param>
		/// <param name="numChildren">The number of children in the view group.</param>
		private void measureAndAdjustDown(android.view.View child, int childIndex, int numChildren
			)
		{
			int oldHeight = child.getHeight();
			measureItem(child);
			if (child.getMeasuredHeight() != oldHeight)
			{
				// lay out the view, preserving its top
				relayoutMeasuredItem(child);
				// adjust views below appropriately
				int heightDelta = child.getMeasuredHeight() - oldHeight;
				{
					for (int i = childIndex + 1; i < numChildren; i++)
					{
						getChildAt(i).offsetTopAndBottom(heightDelta);
					}
				}
			}
		}

		/// <summary>Measure a particular list child.</summary>
		/// <remarks>
		/// Measure a particular list child.
		/// TODO: unify with setUpChild.
		/// </remarks>
		/// <param name="child">The child.</param>
		private void measureItem(android.view.View child)
		{
			android.view.ViewGroup.LayoutParams p = child.getLayoutParams();
			if (p == null)
			{
				p = new android.view.ViewGroup.LayoutParams(android.view.ViewGroup.LayoutParams.MATCH_PARENT
					, android.view.ViewGroup.LayoutParams.WRAP_CONTENT);
			}
			int childWidthSpec = android.view.ViewGroup.getChildMeasureSpec(mWidthMeasureSpec
				, mListPadding.left + mListPadding.right, p.width);
			int lpHeight = p.height;
			int childHeightSpec;
			if (lpHeight > 0)
			{
				childHeightSpec = android.view.View.MeasureSpec.makeMeasureSpec(lpHeight, android.view.View
					.MeasureSpec.EXACTLY);
			}
			else
			{
				childHeightSpec = android.view.View.MeasureSpec.makeMeasureSpec(0, android.view.View
					.MeasureSpec.UNSPECIFIED);
			}
			child.measure(childWidthSpec, childHeightSpec);
		}

		/// <summary>Layout a child that has been measured, preserving its top position.</summary>
		/// <remarks>
		/// Layout a child that has been measured, preserving its top position.
		/// TODO: unify with setUpChild.
		/// </remarks>
		/// <param name="child">The child.</param>
		private void relayoutMeasuredItem(android.view.View child)
		{
			int w = child.getMeasuredWidth();
			int h = child.getMeasuredHeight();
			int childLeft = mListPadding.left;
			int childRight = childLeft + w;
			int childTop = child.getTop();
			int childBottom = childTop + h;
			child.layout(childLeft, childTop, childRight, childBottom);
		}

		/// <returns>The amount to preview next items when arrow srolling.</returns>
		private int getArrowScrollPreviewLength()
		{
			return System.Math.Max(MIN_SCROLL_PREVIEW_PIXELS, getVerticalFadingEdgeLength());
		}

		/// <summary>
		/// Determine how much we need to scroll in order to get the next selected view
		/// visible, with a fading edge showing below as applicable.
		/// </summary>
		/// <remarks>
		/// Determine how much we need to scroll in order to get the next selected view
		/// visible, with a fading edge showing below as applicable.  The amount is
		/// capped at
		/// <see cref="getMaxScrollAmount()">getMaxScrollAmount()</see>
		/// .
		/// </remarks>
		/// <param name="direction">
		/// either
		/// <see cref="android.view.View.FOCUS_UP">android.view.View.FOCUS_UP</see>
		/// or
		/// <see cref="android.view.View.FOCUS_DOWN">android.view.View.FOCUS_DOWN</see>
		/// .
		/// </param>
		/// <param name="nextSelectedPosition">
		/// The position of the next selection, or
		/// <see cref="android.widget.AdapterView.INVALID_POSITION">android.widget.AdapterView.INVALID_POSITION
		/// 	</see>
		/// if there is no next selectable position
		/// </param>
		/// <returns>
		/// The amount to scroll. Note: this is always positive!  Direction
		/// needs to be taken into account when actually scrolling.
		/// </returns>
		private int amountToScroll(int direction, int nextSelectedPosition)
		{
			int listBottom = getHeight() - mListPadding.bottom;
			int listTop = mListPadding.top;
			int numChildren = getChildCount();
			if (direction == android.view.View.FOCUS_DOWN)
			{
				int indexToMakeVisible = numChildren - 1;
				if (nextSelectedPosition != android.widget.AdapterView.INVALID_POSITION)
				{
					indexToMakeVisible = nextSelectedPosition - mFirstPosition;
				}
				int positionToMakeVisible = mFirstPosition + indexToMakeVisible;
				android.view.View viewToMakeVisible = getChildAt(indexToMakeVisible);
				int goalBottom = listBottom;
				if (positionToMakeVisible < mItemCount - 1)
				{
					goalBottom -= getArrowScrollPreviewLength();
				}
				if (viewToMakeVisible.getBottom() <= goalBottom)
				{
					// item is fully visible.
					return 0;
				}
				if (nextSelectedPosition != android.widget.AdapterView.INVALID_POSITION && (goalBottom
					 - viewToMakeVisible.getTop()) >= getMaxScrollAmount())
				{
					// item already has enough of it visible, changing selection is good enough
					return 0;
				}
				int amountToScroll_1 = (viewToMakeVisible.getBottom() - goalBottom);
				if ((mFirstPosition + numChildren) == mItemCount)
				{
					// last is last in list -> make sure we don't scroll past it
					int max = getChildAt(numChildren - 1).getBottom() - listBottom;
					amountToScroll_1 = System.Math.Min(amountToScroll_1, max);
				}
				return System.Math.Min(amountToScroll_1, getMaxScrollAmount());
			}
			else
			{
				int indexToMakeVisible = 0;
				if (nextSelectedPosition != android.widget.AdapterView.INVALID_POSITION)
				{
					indexToMakeVisible = nextSelectedPosition - mFirstPosition;
				}
				int positionToMakeVisible = mFirstPosition + indexToMakeVisible;
				android.view.View viewToMakeVisible = getChildAt(indexToMakeVisible);
				int goalTop = listTop;
				if (positionToMakeVisible > 0)
				{
					goalTop += getArrowScrollPreviewLength();
				}
				if (viewToMakeVisible.getTop() >= goalTop)
				{
					// item is fully visible.
					return 0;
				}
				if (nextSelectedPosition != android.widget.AdapterView.INVALID_POSITION && (viewToMakeVisible
					.getBottom() - goalTop) >= getMaxScrollAmount())
				{
					// item already has enough of it visible, changing selection is good enough
					return 0;
				}
				int amountToScroll_1 = (goalTop - viewToMakeVisible.getTop());
				if (mFirstPosition == 0)
				{
					// first is first in list -> make sure we don't scroll past it
					int max = listTop - getChildAt(0).getTop();
					amountToScroll_1 = System.Math.Min(amountToScroll_1, max);
				}
				return System.Math.Min(amountToScroll_1, getMaxScrollAmount());
			}
		}

		/// <summary>Holds results of focus aware arrow scrolling.</summary>
		/// <remarks>Holds results of focus aware arrow scrolling.</remarks>
		private class ArrowScrollFocusResult
		{
			internal int mSelectedPosition;

			internal int mAmountToScroll;

			/// <summary>
			/// How
			/// <see cref="ListView.arrowScrollFocused(int)">ListView.arrowScrollFocused(int)</see>
			/// returns its values.
			/// </summary>
			internal virtual void populate(int selectedPosition, int amountToScroll)
			{
				mSelectedPosition = selectedPosition;
				mAmountToScroll = amountToScroll;
			}

			public virtual int getSelectedPosition()
			{
				return mSelectedPosition;
			}

			public virtual int getAmountToScroll()
			{
				return mAmountToScroll;
			}
		}

		/// <param name="direction">
		/// either
		/// <see cref="android.view.View.FOCUS_UP">android.view.View.FOCUS_UP</see>
		/// or
		/// <see cref="android.view.View.FOCUS_DOWN">android.view.View.FOCUS_DOWN</see>
		/// .
		/// </param>
		/// <returns>
		/// The position of the next selectable position of the views that
		/// are currently visible, taking into account the fact that there might
		/// be no selection.  Returns
		/// <see cref="android.widget.AdapterView.INVALID_POSITION">android.widget.AdapterView.INVALID_POSITION
		/// 	</see>
		/// if there is no
		/// selectable view on screen in the given direction.
		/// </returns>
		private int lookForSelectablePositionOnScreen(int direction)
		{
			int firstPosition = mFirstPosition;
			if (direction == android.view.View.FOCUS_DOWN)
			{
				int startPos = (mSelectedPosition != android.widget.AdapterView.INVALID_POSITION)
					 ? mSelectedPosition + 1 : firstPosition;
				if (startPos >= mAdapter.getCount())
				{
					return android.widget.AdapterView.INVALID_POSITION;
				}
				if (startPos < firstPosition)
				{
					startPos = firstPosition;
				}
				int lastVisiblePos = getLastVisiblePosition();
				android.widget.ListAdapter adapter = getAdapter();
				{
					for (int pos = startPos; pos <= lastVisiblePos; pos++)
					{
						if (adapter.isEnabled(pos) && getChildAt(pos - firstPosition).getVisibility() == 
							android.view.View.VISIBLE)
						{
							return pos;
						}
					}
				}
			}
			else
			{
				int last = firstPosition + getChildCount() - 1;
				int startPos = (mSelectedPosition != android.widget.AdapterView.INVALID_POSITION)
					 ? mSelectedPosition - 1 : firstPosition + getChildCount() - 1;
				if (startPos < 0 || startPos >= mAdapter.getCount())
				{
					return android.widget.AdapterView.INVALID_POSITION;
				}
				if (startPos > last)
				{
					startPos = last;
				}
				android.widget.ListAdapter adapter = getAdapter();
				{
					for (int pos = startPos; pos >= firstPosition; pos--)
					{
						if (adapter.isEnabled(pos) && getChildAt(pos - firstPosition).getVisibility() == 
							android.view.View.VISIBLE)
						{
							return pos;
						}
					}
				}
			}
			return android.widget.AdapterView.INVALID_POSITION;
		}

		/// <summary>Do an arrow scroll based on focus searching.</summary>
		/// <remarks>
		/// Do an arrow scroll based on focus searching.  If a new view is
		/// given focus, return the selection delta and amount to scroll via
		/// an
		/// <see cref="ArrowScrollFocusResult">ArrowScrollFocusResult</see>
		/// , otherwise, return null.
		/// </remarks>
		/// <param name="direction">
		/// either
		/// <see cref="android.view.View.FOCUS_UP">android.view.View.FOCUS_UP</see>
		/// or
		/// <see cref="android.view.View.FOCUS_DOWN">android.view.View.FOCUS_DOWN</see>
		/// .
		/// </param>
		/// <returns>The result if focus has changed, or <code>null</code>.</returns>
		private android.widget.ListView.ArrowScrollFocusResult arrowScrollFocused(int direction
			)
		{
			android.view.View selectedView = getSelectedView();
			android.view.View newFocus;
			if (selectedView != null && selectedView.hasFocus())
			{
				android.view.View oldFocus = selectedView.findFocus();
				newFocus = android.view.FocusFinder.getInstance().findNextFocus(this, oldFocus, direction
					);
			}
			else
			{
				if (direction == android.view.View.FOCUS_DOWN)
				{
					bool topFadingEdgeShowing = (mFirstPosition > 0);
					int listTop = mListPadding.top + (topFadingEdgeShowing ? getArrowScrollPreviewLength
						() : 0);
					int ySearchPoint = (selectedView != null && selectedView.getTop() > listTop) ? selectedView
						.getTop() : listTop;
					mTempRect.set(0, ySearchPoint, 0, ySearchPoint);
				}
				else
				{
					bool bottomFadingEdgeShowing = (mFirstPosition + getChildCount() - 1) < mItemCount;
					int listBottom = getHeight() - mListPadding.bottom - (bottomFadingEdgeShowing ? getArrowScrollPreviewLength
						() : 0);
					int ySearchPoint = (selectedView != null && selectedView.getBottom() < listBottom
						) ? selectedView.getBottom() : listBottom;
					mTempRect.set(0, ySearchPoint, 0, ySearchPoint);
				}
				newFocus = android.view.FocusFinder.getInstance().findNextFocusFromRect(this, mTempRect
					, direction);
			}
			if (newFocus != null)
			{
				int positionOfNewFocus_1 = positionOfNewFocus(newFocus);
				// if the focus change is in a different new position, make sure
				// we aren't jumping over another selectable position
				if (mSelectedPosition != android.widget.AdapterView.INVALID_POSITION && positionOfNewFocus_1
					 != mSelectedPosition)
				{
					int selectablePosition = lookForSelectablePositionOnScreen(direction);
					if (selectablePosition != android.widget.AdapterView.INVALID_POSITION && ((direction
						 == android.view.View.FOCUS_DOWN && selectablePosition < positionOfNewFocus_1) ||
						 (direction == android.view.View.FOCUS_UP && selectablePosition > positionOfNewFocus_1
						)))
					{
						return null;
					}
				}
				int focusScroll = amountToScrollToNewFocus(direction, newFocus, positionOfNewFocus_1
					);
				int maxScrollAmount = getMaxScrollAmount();
				if (focusScroll < maxScrollAmount)
				{
					// not moving too far, safe to give next view focus
					newFocus.requestFocus(direction);
					mArrowScrollFocusResult.populate(positionOfNewFocus_1, focusScroll);
					return mArrowScrollFocusResult;
				}
				else
				{
					if (distanceToView(newFocus) < maxScrollAmount)
					{
						// Case to consider:
						// too far to get entire next focusable on screen, but by going
						// max scroll amount, we are getting it at least partially in view,
						// so give it focus and scroll the max ammount.
						newFocus.requestFocus(direction);
						mArrowScrollFocusResult.populate(positionOfNewFocus_1, maxScrollAmount);
						return mArrowScrollFocusResult;
					}
				}
			}
			return null;
		}

		/// <param name="newFocus">The view that would have focus.</param>
		/// <returns>the position that contains newFocus</returns>
		private int positionOfNewFocus(android.view.View newFocus)
		{
			int numChildren = getChildCount();
			{
				for (int i = 0; i < numChildren; i++)
				{
					android.view.View child = getChildAt(i);
					if (isViewAncestorOf(newFocus, child))
					{
						return mFirstPosition + i;
					}
				}
			}
			throw new System.ArgumentException("newFocus is not a child of any of the" + " children of the list!"
				);
		}

		/// <summary>Return true if child is an ancestor of parent, (or equal to the parent).
		/// 	</summary>
		/// <remarks>Return true if child is an ancestor of parent, (or equal to the parent).
		/// 	</remarks>
		private bool isViewAncestorOf(android.view.View child, android.view.View parent)
		{
			if (child == parent)
			{
				return true;
			}
			android.view.ViewParent theParent = child.getParent();
			return (theParent is android.view.ViewGroup) && isViewAncestorOf((android.view.View
				)theParent, parent);
		}

		/// <summary>Determine how much we need to scroll in order to get newFocus in view.</summary>
		/// <remarks>Determine how much we need to scroll in order to get newFocus in view.</remarks>
		/// <param name="direction">
		/// either
		/// <see cref="android.view.View.FOCUS_UP">android.view.View.FOCUS_UP</see>
		/// or
		/// <see cref="android.view.View.FOCUS_DOWN">android.view.View.FOCUS_DOWN</see>
		/// .
		/// </param>
		/// <param name="newFocus">The view that would take focus.</param>
		/// <param name="positionOfNewFocus">The position of the list item containing newFocus
		/// 	</param>
		/// <returns>
		/// The amount to scroll.  Note: this is always positive!  Direction
		/// needs to be taken into account when actually scrolling.
		/// </returns>
		private int amountToScrollToNewFocus(int direction, android.view.View newFocus, int
			 positionOfNewFocus_1)
		{
			int amountToScroll_1 = 0;
			newFocus.getDrawingRect(mTempRect);
			offsetDescendantRectToMyCoords(newFocus, mTempRect);
			if (direction == android.view.View.FOCUS_UP)
			{
				if (mTempRect.top < mListPadding.top)
				{
					amountToScroll_1 = mListPadding.top - mTempRect.top;
					if (positionOfNewFocus_1 > 0)
					{
						amountToScroll_1 += getArrowScrollPreviewLength();
					}
				}
			}
			else
			{
				int listBottom = getHeight() - mListPadding.bottom;
				if (mTempRect.bottom > listBottom)
				{
					amountToScroll_1 = mTempRect.bottom - listBottom;
					if (positionOfNewFocus_1 < mItemCount - 1)
					{
						amountToScroll_1 += getArrowScrollPreviewLength();
					}
				}
			}
			return amountToScroll_1;
		}

		/// <summary>
		/// Determine the distance to the nearest edge of a view in a particular
		/// direction.
		/// </summary>
		/// <remarks>
		/// Determine the distance to the nearest edge of a view in a particular
		/// direction.
		/// </remarks>
		/// <param name="descendant">A descendant of this list.</param>
		/// <returns>The distance, or 0 if the nearest edge is already on screen.</returns>
		private int distanceToView(android.view.View descendant)
		{
			int distance = 0;
			descendant.getDrawingRect(mTempRect);
			offsetDescendantRectToMyCoords(descendant, mTempRect);
			int listBottom = mBottom - mTop - mListPadding.bottom;
			if (mTempRect.bottom < mListPadding.top)
			{
				distance = mListPadding.top - mTempRect.bottom;
			}
			else
			{
				if (mTempRect.top > listBottom)
				{
					distance = mTempRect.top - listBottom;
				}
			}
			return distance;
		}

		/// <summary>
		/// Scroll the children by amount, adding a view at the end and removing
		/// views that fall off as necessary.
		/// </summary>
		/// <remarks>
		/// Scroll the children by amount, adding a view at the end and removing
		/// views that fall off as necessary.
		/// </remarks>
		/// <param name="amount">The amount (positive or negative) to scroll.</param>
		private void scrollListItemsBy(int amount)
		{
			offsetChildrenTopAndBottom(amount);
			int listBottom = getHeight() - mListPadding.bottom;
			int listTop = mListPadding.top;
			android.widget.AbsListView.RecycleBin recycleBin = mRecycler;
			if (amount < 0)
			{
				// shifted items up
				// may need to pan views into the bottom space
				int numChildren = getChildCount();
				android.view.View last = getChildAt(numChildren - 1);
				while (last.getBottom() < listBottom)
				{
					int lastVisiblePosition = mFirstPosition + numChildren - 1;
					if (lastVisiblePosition < mItemCount - 1)
					{
						last = addViewBelow(last, lastVisiblePosition);
						numChildren++;
					}
					else
					{
						break;
					}
				}
				// may have brought in the last child of the list that is skinnier
				// than the fading edge, thereby leaving space at the end.  need
				// to shift back
				if (last.getBottom() < listBottom)
				{
					offsetChildrenTopAndBottom(listBottom - last.getBottom());
				}
				// top views may be panned off screen
				android.view.View first = getChildAt(0);
				while (first.getBottom() < listTop)
				{
					android.widget.AbsListView.LayoutParams layoutParams = (android.widget.AbsListView
						.LayoutParams)first.getLayoutParams();
					if (recycleBin.shouldRecycleViewType(layoutParams.viewType))
					{
						detachViewFromParent(first);
						recycleBin.addScrapView(first, mFirstPosition);
					}
					else
					{
						removeViewInLayout(first);
					}
					first = getChildAt(0);
					mFirstPosition++;
				}
			}
			else
			{
				// shifted items down
				android.view.View first = getChildAt(0);
				// may need to pan views into top
				while ((first.getTop() > listTop) && (mFirstPosition > 0))
				{
					first = addViewAbove(first, mFirstPosition);
					mFirstPosition--;
				}
				// may have brought the very first child of the list in too far and
				// need to shift it back
				if (first.getTop() > listTop)
				{
					offsetChildrenTopAndBottom(listTop - first.getTop());
				}
				int lastIndex = getChildCount() - 1;
				android.view.View last = getChildAt(lastIndex);
				// bottom view may be panned off screen
				while (last.getTop() > listBottom)
				{
					android.widget.AbsListView.LayoutParams layoutParams = (android.widget.AbsListView
						.LayoutParams)last.getLayoutParams();
					if (recycleBin.shouldRecycleViewType(layoutParams.viewType))
					{
						detachViewFromParent(last);
						recycleBin.addScrapView(last, mFirstPosition + lastIndex);
					}
					else
					{
						removeViewInLayout(last);
					}
					last = getChildAt(--lastIndex);
				}
			}
		}

		private android.view.View addViewAbove(android.view.View theView, int position)
		{
			int abovePosition = position - 1;
			android.view.View view = obtainView(abovePosition, mIsScrap);
			int edgeOfNewChild = theView.getTop() - mDividerHeight;
			setupChild(view, abovePosition, edgeOfNewChild, false, mListPadding.left, false, 
				mIsScrap[0]);
			return view;
		}

		private android.view.View addViewBelow(android.view.View theView, int position)
		{
			int belowPosition = position + 1;
			android.view.View view = obtainView(belowPosition, mIsScrap);
			int edgeOfNewChild = theView.getBottom() + mDividerHeight;
			setupChild(view, belowPosition, edgeOfNewChild, true, mListPadding.left, false, mIsScrap
				[0]);
			return view;
		}

		/// <summary>
		/// Indicates that the views created by the ListAdapter can contain focusable
		/// items.
		/// </summary>
		/// <remarks>
		/// Indicates that the views created by the ListAdapter can contain focusable
		/// items.
		/// </remarks>
		/// <param name="itemsCanFocus">true if items can get focus, false otherwise</param>
		public virtual void setItemsCanFocus(bool itemsCanFocus)
		{
			mItemsCanFocus = itemsCanFocus;
			if (!itemsCanFocus)
			{
				setDescendantFocusability(android.view.ViewGroup.FOCUS_BLOCK_DESCENDANTS);
			}
		}

		/// <returns>
		/// Whether the views created by the ListAdapter can contain focusable
		/// items.
		/// </returns>
		public virtual bool getItemsCanFocus()
		{
			return mItemsCanFocus;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool isOpaque()
		{
			bool retValue = (mCachingActive && mIsCacheColorOpaque && mDividerIsOpaque && hasOpaqueScrollbars
				()) || base.isOpaque();
			if (retValue)
			{
				// only return true if the list items cover the entire area of the view
				int listTop = mListPadding != null ? mListPadding.top : mPaddingTop;
				android.view.View first = getChildAt(0);
				if (first == null || first.getTop() > listTop)
				{
					return false;
				}
				int listBottom = getHeight() - (mListPadding != null ? mListPadding.bottom : mPaddingBottom
					);
				android.view.View last = getChildAt(getChildCount() - 1);
				if (last == null || last.getBottom() < listBottom)
				{
					return false;
				}
			}
			return retValue;
		}

		[Sharpen.OverridesMethod(@"android.widget.AbsListView")]
		public override void setCacheColorHint(int color)
		{
			bool opaque = ((int)(((uint)color) >> 24)) == unchecked((int)(0xFF));
			mIsCacheColorOpaque = opaque;
			if (opaque)
			{
				if (mDividerPaint == null)
				{
					mDividerPaint = new android.graphics.Paint();
				}
				mDividerPaint.setColor(color);
			}
			base.setCacheColorHint(color);
		}

		internal virtual void drawOverscrollHeader(android.graphics.Canvas canvas, android.graphics.drawable.Drawable
			 drawable, android.graphics.Rect bounds)
		{
			int height = drawable.getMinimumHeight();
			canvas.save();
			canvas.clipRect(bounds);
			int span = bounds.bottom - bounds.top;
			if (span < height)
			{
				bounds.top = bounds.bottom - height;
			}
			drawable.setBounds(bounds);
			drawable.draw(canvas);
			canvas.restore();
		}

		internal virtual void drawOverscrollFooter(android.graphics.Canvas canvas, android.graphics.drawable.Drawable
			 drawable, android.graphics.Rect bounds)
		{
			int height = drawable.getMinimumHeight();
			canvas.save();
			canvas.clipRect(bounds);
			int span = bounds.bottom - bounds.top;
			if (span < height)
			{
				bounds.bottom = bounds.top + height;
			}
			drawable.setBounds(bounds);
			drawable.draw(canvas);
			canvas.restore();
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void dispatchDraw(android.graphics.Canvas canvas)
		{
			if (mCachingStarted)
			{
				mCachingActive = true;
			}
			// Draw the dividers
			int dividerHeight = mDividerHeight;
			android.graphics.drawable.Drawable overscrollHeader = mOverScrollHeader;
			android.graphics.drawable.Drawable overscrollFooter = mOverScrollFooter;
			bool drawOverscrollHeader_1 = overscrollHeader != null;
			bool drawOverscrollFooter_1 = overscrollFooter != null;
			bool drawDividers = dividerHeight > 0 && mDivider != null;
			if (drawDividers || drawOverscrollHeader_1 || drawOverscrollFooter_1)
			{
				// Only modify the top and bottom in the loop, we set the left and right here
				android.graphics.Rect bounds = mTempRect;
				bounds.left = mPaddingLeft;
				bounds.right = mRight - mLeft - mPaddingRight;
				int count = getChildCount();
				int headerCount = mHeaderViewInfos.size();
				int itemCount = mItemCount;
				int footerLimit = itemCount - mFooterViewInfos.size() - 1;
				bool headerDividers = mHeaderDividersEnabled;
				bool footerDividers = mFooterDividersEnabled;
				int first = mFirstPosition;
				bool areAllItemsSelectable = mAreAllItemsSelectable;
				android.widget.ListAdapter adapter = mAdapter;
				// If the list is opaque *and* the background is not, we want to
				// fill a rect where the dividers would be for non-selectable items
				// If the list is opaque and the background is also opaque, we don't
				// need to draw anything since the background will do it for us
				bool fillForMissingDividers = isOpaque() && !base.isOpaque();
				if (fillForMissingDividers && mDividerPaint == null && mIsCacheColorOpaque)
				{
					mDividerPaint = new android.graphics.Paint();
					mDividerPaint.setColor(getCacheColorHint());
				}
				android.graphics.Paint paint = mDividerPaint;
				int effectivePaddingTop = 0;
				int effectivePaddingBottom = 0;
				if ((mGroupFlags & CLIP_TO_PADDING_MASK) == CLIP_TO_PADDING_MASK)
				{
					effectivePaddingTop = mListPadding.top;
					effectivePaddingBottom = mListPadding.bottom;
				}
				int listBottom = mBottom - mTop - effectivePaddingBottom + mScrollY;
				if (!mStackFromBottom)
				{
					int bottom = 0;
					// Draw top divider or header for overscroll
					int scrollY = mScrollY;
					if (count > 0 && scrollY < 0)
					{
						if (drawOverscrollHeader_1)
						{
							bounds.bottom = 0;
							bounds.top = scrollY;
							drawOverscrollHeader(canvas, overscrollHeader, bounds);
						}
						else
						{
							if (drawDividers)
							{
								bounds.bottom = 0;
								bounds.top = -dividerHeight;
								drawDivider(canvas, bounds, -1);
							}
						}
					}
					{
						for (int i = 0; i < count; i++)
						{
							if ((headerDividers || first + i >= headerCount) && (footerDividers || first + i 
								< footerLimit))
							{
								android.view.View child = getChildAt(i);
								bottom = child.getBottom();
								// Don't draw dividers next to items that are not enabled
								if (drawDividers && (bottom < listBottom && !(drawOverscrollFooter_1 && i == count
									 - 1)))
								{
									if ((areAllItemsSelectable || (adapter.isEnabled(first + i) && (i == count - 1 ||
										 adapter.isEnabled(first + i + 1)))))
									{
										bounds.top = bottom;
										bounds.bottom = bottom + dividerHeight;
										drawDivider(canvas, bounds, i);
									}
									else
									{
										if (fillForMissingDividers)
										{
											bounds.top = bottom;
											bounds.bottom = bottom + dividerHeight;
											canvas.drawRect(bounds, paint);
										}
									}
								}
							}
						}
					}
					int overFooterBottom = mBottom + mScrollY;
					if (drawOverscrollFooter_1 && first + count == itemCount && overFooterBottom > bottom)
					{
						bounds.top = bottom;
						bounds.bottom = overFooterBottom;
						drawOverscrollFooter(canvas, overscrollFooter, bounds);
					}
				}
				else
				{
					int top;
					int scrollY = mScrollY;
					if (count > 0 && drawOverscrollHeader_1)
					{
						bounds.top = scrollY;
						bounds.bottom = getChildAt(0).getTop();
						drawOverscrollHeader(canvas, overscrollHeader, bounds);
					}
					int start = drawOverscrollHeader_1 ? 1 : 0;
					{
						for (int i = start; i < count; i++)
						{
							if ((headerDividers || first + i >= headerCount) && (footerDividers || first + i 
								< footerLimit))
							{
								android.view.View child = getChildAt(i);
								top = child.getTop();
								// Don't draw dividers next to items that are not enabled
								if (top > effectivePaddingTop)
								{
									if ((areAllItemsSelectable || (adapter.isEnabled(first + i) && (i == count - 1 ||
										 adapter.isEnabled(first + i + 1)))))
									{
										bounds.top = top - dividerHeight;
										bounds.bottom = top;
										// Give the method the child ABOVE the divider, so we
										// subtract one from our child
										// position. Give -1 when there is no child above the
										// divider.
										drawDivider(canvas, bounds, i - 1);
									}
									else
									{
										if (fillForMissingDividers)
										{
											bounds.top = top - dividerHeight;
											bounds.bottom = top;
											canvas.drawRect(bounds, paint);
										}
									}
								}
							}
						}
					}
					if (count > 0 && scrollY > 0)
					{
						if (drawOverscrollFooter_1)
						{
							int absListBottom = mBottom;
							bounds.top = absListBottom;
							bounds.bottom = absListBottom + scrollY;
							drawOverscrollFooter(canvas, overscrollFooter, bounds);
						}
						else
						{
							if (drawDividers)
							{
								bounds.top = listBottom;
								bounds.bottom = listBottom + dividerHeight;
								drawDivider(canvas, bounds, -1);
							}
						}
					}
				}
			}
			// Draw the indicators (these should be drawn above the dividers) and children
			base.dispatchDraw(canvas);
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		protected internal override bool drawChild(android.graphics.Canvas canvas, android.view.View
			 child, long drawingTime)
		{
			bool more = base.drawChild(canvas, child, drawingTime);
			if (mCachingActive && child.mCachingFailed)
			{
				mCachingActive = false;
			}
			return more;
		}

		/// <summary>Draws a divider for the given child in the given bounds.</summary>
		/// <remarks>Draws a divider for the given child in the given bounds.</remarks>
		/// <param name="canvas">The canvas to draw to.</param>
		/// <param name="bounds">The bounds of the divider.</param>
		/// <param name="childIndex">
		/// The index of child (of the View) above the divider.
		/// This will be -1 if there is no child above the divider to be
		/// drawn.
		/// </param>
		internal virtual void drawDivider(android.graphics.Canvas canvas, android.graphics.Rect
			 bounds, int childIndex)
		{
			// This widget draws the same divider for all children
			android.graphics.drawable.Drawable divider = mDivider;
			divider.setBounds(bounds);
			divider.draw(canvas);
		}

		/// <summary>Returns the drawable that will be drawn between each item in the list.</summary>
		/// <remarks>Returns the drawable that will be drawn between each item in the list.</remarks>
		/// <returns>the current drawable drawn between list elements</returns>
		public virtual android.graphics.drawable.Drawable getDivider()
		{
			return mDivider;
		}

		/// <summary>Sets the drawable that will be drawn between each item in the list.</summary>
		/// <remarks>
		/// Sets the drawable that will be drawn between each item in the list. If the drawable does
		/// not have an intrinsic height, you should also call
		/// <see cref="setDividerHeight(int)">setDividerHeight(int)</see>
		/// </remarks>
		/// <param name="divider">The drawable to use.</param>
		public virtual void setDivider(android.graphics.drawable.Drawable divider)
		{
			if (divider != null)
			{
				mDividerHeight = divider.getIntrinsicHeight();
			}
			else
			{
				mDividerHeight = 0;
			}
			mDivider = divider;
			mDividerIsOpaque = divider == null || divider.getOpacity() == android.graphics.PixelFormat
				.OPAQUE;
			requestLayout();
			invalidate();
		}

		/// <returns>Returns the height of the divider that will be drawn between each item in the list.
		/// 	</returns>
		public virtual int getDividerHeight()
		{
			return mDividerHeight;
		}

		/// <summary>Sets the height of the divider that will be drawn between each item in the list.
		/// 	</summary>
		/// <remarks>
		/// Sets the height of the divider that will be drawn between each item in the list. Calling
		/// this will override the intrinsic height as set by
		/// <see cref="setDivider(android.graphics.drawable.Drawable)">setDivider(android.graphics.drawable.Drawable)
		/// 	</see>
		/// </remarks>
		/// <param name="height">The new height of the divider in pixels.</param>
		public virtual void setDividerHeight(int height)
		{
			mDividerHeight = height;
			requestLayout();
			invalidate();
		}

		/// <summary>Enables or disables the drawing of the divider for header views.</summary>
		/// <remarks>Enables or disables the drawing of the divider for header views.</remarks>
		/// <param name="headerDividersEnabled">True to draw the headers, false otherwise.</param>
		/// <seealso cref="setFooterDividersEnabled(bool)">setFooterDividersEnabled(bool)</seealso>
		/// <seealso cref="addHeaderView(android.view.View)">addHeaderView(android.view.View)
		/// 	</seealso>
		public virtual void setHeaderDividersEnabled(bool headerDividersEnabled)
		{
			mHeaderDividersEnabled = headerDividersEnabled;
			invalidate();
		}

		/// <summary>Enables or disables the drawing of the divider for footer views.</summary>
		/// <remarks>Enables or disables the drawing of the divider for footer views.</remarks>
		/// <param name="footerDividersEnabled">True to draw the footers, false otherwise.</param>
		/// <seealso cref="setHeaderDividersEnabled(bool)">setHeaderDividersEnabled(bool)</seealso>
		/// <seealso cref="addFooterView(android.view.View)">addFooterView(android.view.View)
		/// 	</seealso>
		public virtual void setFooterDividersEnabled(bool footerDividersEnabled)
		{
			mFooterDividersEnabled = footerDividersEnabled;
			invalidate();
		}

		/// <summary>Sets the drawable that will be drawn above all other list content.</summary>
		/// <remarks>
		/// Sets the drawable that will be drawn above all other list content.
		/// This area can become visible when the user overscrolls the list.
		/// </remarks>
		/// <param name="header">The drawable to use</param>
		public virtual void setOverscrollHeader(android.graphics.drawable.Drawable header
			)
		{
			mOverScrollHeader = header;
			if (mScrollY < 0)
			{
				invalidate();
			}
		}

		/// <returns>The drawable that will be drawn above all other list content</returns>
		public virtual android.graphics.drawable.Drawable getOverscrollHeader()
		{
			return mOverScrollHeader;
		}

		/// <summary>Sets the drawable that will be drawn below all other list content.</summary>
		/// <remarks>
		/// Sets the drawable that will be drawn below all other list content.
		/// This area can become visible when the user overscrolls the list,
		/// or when the list's content does not fully fill the container area.
		/// </remarks>
		/// <param name="footer">The drawable to use</param>
		public virtual void setOverscrollFooter(android.graphics.drawable.Drawable footer
			)
		{
			mOverScrollFooter = footer;
			invalidate();
		}

		/// <returns>The drawable that will be drawn below all other list content</returns>
		public virtual android.graphics.drawable.Drawable getOverscrollFooter()
		{
			return mOverScrollFooter;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onFocusChanged(bool gainFocus, int direction, android.graphics.Rect
			 previouslyFocusedRect)
		{
			base.onFocusChanged(gainFocus, direction, previouslyFocusedRect);
			android.widget.ListAdapter adapter = mAdapter;
			int closetChildIndex = -1;
			if (adapter != null && gainFocus && previouslyFocusedRect != null)
			{
				previouslyFocusedRect.offset(mScrollX, mScrollY);
				// Don't cache the result of getChildCount or mFirstPosition here,
				// it could change in layoutChildren.
				if (adapter.getCount() < getChildCount() + mFirstPosition)
				{
					mLayoutMode = LAYOUT_NORMAL;
					layoutChildren();
				}
				// figure out which item should be selected based on previously
				// focused rect
				android.graphics.Rect otherRect = mTempRect;
				int minDistance = int.MaxValue;
				int childCount = getChildCount();
				int firstPosition = mFirstPosition;
				{
					for (int i = 0; i < childCount; i++)
					{
						// only consider selectable views
						if (!adapter.isEnabled(firstPosition + i))
						{
							continue;
						}
						android.view.View other = getChildAt(i);
						other.getDrawingRect(otherRect);
						offsetDescendantRectToMyCoords(other, otherRect);
						int distance = getDistance(previouslyFocusedRect, otherRect, direction);
						if (distance < minDistance)
						{
							minDistance = distance;
							closetChildIndex = i;
						}
					}
				}
			}
			if (closetChildIndex >= 0)
			{
				setSelection(closetChildIndex + mFirstPosition);
			}
			else
			{
				requestLayout();
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onFinishInflate()
		{
			base.onFinishInflate();
			int count = getChildCount();
			if (count > 0)
			{
				{
					for (int i = 0; i < count; ++i)
					{
						addHeaderView(getChildAt(i));
					}
				}
				removeAllViews();
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override android.view.View findViewTraversal(int id)
		{
			android.view.View v;
			v = base.findViewTraversal(id);
			if (v == null)
			{
				v = findViewInHeadersOrFooters(mHeaderViewInfos, id);
				if (v != null)
				{
					return v;
				}
				v = findViewInHeadersOrFooters(mFooterViewInfos, id);
				if (v != null)
				{
					return v;
				}
			}
			return v;
		}

		internal virtual android.view.View findViewInHeadersOrFooters(java.util.ArrayList
			<android.widget.ListView.FixedViewInfo> where, int id)
		{
			if (where != null)
			{
				int len = where.size();
				android.view.View v;
				{
					for (int i = 0; i < len; i++)
					{
						v = where.get(i).view;
						if (!v.isRootNamespace())
						{
							v = v.findViewById(id);
							if (v != null)
							{
								return v;
							}
						}
					}
				}
			}
			return null;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override android.view.View findViewWithTagTraversal(object tag
			)
		{
			android.view.View v;
			v = base.findViewWithTagTraversal(tag);
			if (v == null)
			{
				v = findViewWithTagInHeadersOrFooters(mHeaderViewInfos, tag);
				if (v != null)
				{
					return v;
				}
				v = findViewWithTagInHeadersOrFooters(mFooterViewInfos, tag);
				if (v != null)
				{
					return v;
				}
			}
			return v;
		}

		internal virtual android.view.View findViewWithTagInHeadersOrFooters(java.util.ArrayList
			<android.widget.ListView.FixedViewInfo> where, object tag)
		{
			if (where != null)
			{
				int len = where.size();
				android.view.View v;
				{
					for (int i = 0; i < len; i++)
					{
						v = where.get(i).view;
						if (!v.isRootNamespace())
						{
							v = v.findViewWithTag(tag);
							if (v != null)
							{
								return v;
							}
						}
					}
				}
			}
			return null;
		}

		/// <hide></hide>
		/// <seealso cref="android.view.View.findViewByPredicate(android.util.@internal.Predicate{T})
		/// 	">First look in our children, then in any header and footer views that may be scrolled off.
		/// 	</seealso>
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override android.view.View findViewByPredicateTraversal(android.util.@internal.Predicate
			<android.view.View> predicate, android.view.View childToSkip)
		{
			android.view.View v;
			v = base.findViewByPredicateTraversal(predicate, childToSkip);
			if (v == null)
			{
				v = findViewByPredicateInHeadersOrFooters(mHeaderViewInfos, predicate, childToSkip
					);
				if (v != null)
				{
					return v;
				}
				v = findViewByPredicateInHeadersOrFooters(mFooterViewInfos, predicate, childToSkip
					);
				if (v != null)
				{
					return v;
				}
			}
			return v;
		}

		internal virtual android.view.View findViewByPredicateInHeadersOrFooters(java.util.ArrayList
			<android.widget.ListView.FixedViewInfo> where, android.util.@internal.Predicate<
			android.view.View> predicate, android.view.View childToSkip)
		{
			if (where != null)
			{
				int len = where.size();
				android.view.View v;
				{
					for (int i = 0; i < len; i++)
					{
						v = where.get(i).view;
						if (v != childToSkip && !v.isRootNamespace())
						{
							v = v.findViewByPredicate(predicate);
							if (v != null)
							{
								return v;
							}
						}
					}
				}
			}
			return null;
		}

		/// <summary>Returns the set of checked items ids.</summary>
		/// <remarks>
		/// Returns the set of checked items ids. The result is only valid if the
		/// choice mode has not been set to
		/// <see cref="AbsListView.CHOICE_MODE_NONE">AbsListView.CHOICE_MODE_NONE</see>
		/// .
		/// </remarks>
		/// <returns>
		/// A new array which contains the id of each checked item in the
		/// list.
		/// </returns>
		[System.ObsoleteAttribute(@"Use AbsListView.getCheckedItemIds() instead.")]
		public virtual long[] getCheckItemIds()
		{
			// Use new behavior that correctly handles stable ID mapping.
			if (mAdapter != null && mAdapter.hasStableIds())
			{
				return getCheckedItemIds();
			}
			// Old behavior was buggy, but would sort of work for adapters without stable IDs.
			// Fall back to it to support legacy apps.
			if (mChoiceMode != CHOICE_MODE_NONE && mCheckStates != null && mAdapter != null)
			{
				android.util.SparseBooleanArray states = mCheckStates;
				int count = states.size();
				long[] ids = new long[count];
				android.widget.ListAdapter adapter = mAdapter;
				int checkedCount = 0;
				{
					for (int i = 0; i < count; i++)
					{
						if (states.valueAt(i))
						{
							ids[checkedCount++] = adapter.getItemId(states.keyAt(i));
						}
					}
				}
				// Trim array if needed. mCheckStates may contain false values
				// resulting in checkedCount being smaller than count.
				if (checkedCount == count)
				{
					return ids;
				}
				else
				{
					long[] result = new long[checkedCount];
					System.Array.Copy(ids, 0, result, 0, checkedCount);
					return result;
				}
			}
			return new long[0];
		}
	}
}

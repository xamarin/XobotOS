using Sharpen;

namespace android.widget
{
	/// <summary>A view that shows items in two-dimensional scrolling grid.</summary>
	/// <remarks>
	/// A view that shows items in two-dimensional scrolling grid. The items in the
	/// grid come from the
	/// <see cref="ListAdapter">ListAdapter</see>
	/// associated with this view.
	/// <p>See the &lt;a href="
	/// <docRoot></docRoot>
	/// resources/tutorials/views/hello-gridview.html"&gt;Grid
	/// View tutorial</a>.</p>
	/// </remarks>
	/// <attr>ref android.R.styleable#GridView_horizontalSpacing</attr>
	/// <attr>ref android.R.styleable#GridView_verticalSpacing</attr>
	/// <attr>ref android.R.styleable#GridView_stretchMode</attr>
	/// <attr>ref android.R.styleable#GridView_columnWidth</attr>
	/// <attr>ref android.R.styleable#GridView_numColumns</attr>
	/// <attr>ref android.R.styleable#GridView_gravity</attr>
	[Sharpen.Sharpened]
	public class GridView : android.widget.AbsListView
	{
		/// <summary>Disables stretching.</summary>
		/// <remarks>Disables stretching.</remarks>
		/// <seealso cref="setStretchMode(int)"></seealso>
		public const int NO_STRETCH = 0;

		/// <summary>Stretches the spacing between columns.</summary>
		/// <remarks>Stretches the spacing between columns.</remarks>
		/// <seealso cref="setStretchMode(int)"></seealso>
		public const int STRETCH_SPACING = 1;

		/// <summary>Stretches columns.</summary>
		/// <remarks>Stretches columns.</remarks>
		/// <seealso cref="setStretchMode(int)"></seealso>
		public const int STRETCH_COLUMN_WIDTH = 2;

		/// <summary>Stretches the spacing between columns.</summary>
		/// <remarks>Stretches the spacing between columns. The spacing is uniform.</remarks>
		/// <seealso cref="setStretchMode(int)"></seealso>
		public const int STRETCH_SPACING_UNIFORM = 3;

		/// <summary>Creates as many columns as can fit on screen.</summary>
		/// <remarks>Creates as many columns as can fit on screen.</remarks>
		/// <seealso cref="setNumColumns(int)"></seealso>
		public const int AUTO_FIT = -1;

		private int mNumColumns = AUTO_FIT;

		private int mHorizontalSpacing = 0;

		private int mRequestedHorizontalSpacing;

		private int mVerticalSpacing = 0;

		private int mStretchMode = STRETCH_COLUMN_WIDTH;

		private int mColumnWidth;

		private int mRequestedColumnWidth;

		private int mRequestedNumColumns;

		private android.view.View mReferenceView = null;

		private android.view.View mReferenceViewInSelectedRow = null;

		private int mGravity = android.view.Gravity.LEFT;

		private readonly android.graphics.Rect mTempRect = new android.graphics.Rect();

		public GridView(android.content.Context context) : base(context)
		{
		}

		public GridView(android.content.Context context, android.util.AttributeSet attrs)
			 : this(context, attrs, android.@internal.R.attr.gridViewStyle)
		{
		}

		public GridView(android.content.Context context, android.util.AttributeSet attrs, 
			int defStyle) : base(context, attrs, defStyle)
		{
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.GridView, defStyle, 0);
			int hSpacing = a.getDimensionPixelOffset(android.@internal.R.styleable.GridView_horizontalSpacing
				, 0);
			setHorizontalSpacing(hSpacing);
			int vSpacing = a.getDimensionPixelOffset(android.@internal.R.styleable.GridView_verticalSpacing
				, 0);
			setVerticalSpacing(vSpacing);
			int index = a.getInt(android.@internal.R.styleable.GridView_stretchMode, STRETCH_COLUMN_WIDTH
				);
			if (index >= 0)
			{
				setStretchMode(index);
			}
			int columnWidth = a.getDimensionPixelOffset(android.@internal.R.styleable.GridView_columnWidth
				, -1);
			if (columnWidth > 0)
			{
				setColumnWidth(columnWidth);
			}
			int numColumns = a.getInt(android.@internal.R.styleable.GridView_numColumns, 1);
			setNumColumns(numColumns);
			index = a.getInt(android.@internal.R.styleable.GridView_gravity, -1);
			if (index >= 0)
			{
				setGravity(index);
			}
			a.recycle();
		}

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

		/// <summary>Sets the data behind this GridView.</summary>
		/// <remarks>Sets the data behind this GridView.</remarks>
		/// <param name="adapter">the adapter providing the grid's data</param>
		[Sharpen.OverridesMethod(@"android.widget.AdapterView")]
		public override void setAdapter(android.widget.ListAdapter adapter)
		{
			if (mAdapter != null && mDataSetObserver != null)
			{
				mAdapter.unregisterDataSetObserver(mDataSetObserver);
			}
			resetList();
			mRecycler.clear();
			mAdapter = adapter;
			mOldSelectedPosition = android.widget.AdapterView.INVALID_POSITION;
			mOldSelectedRowId = android.widget.AdapterView.INVALID_ROW_ID;
			// AbsListView#setAdapter will update choice mode states.
			base.setAdapter(adapter);
			if (mAdapter != null)
			{
				mOldItemCount = mItemCount;
				mItemCount = mAdapter.getCount();
				mDataChanged = true;
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
				checkSelectionChanged();
			}
			else
			{
				checkFocus();
				// Nothing selected
				checkSelectionChanged();
			}
			requestLayout();
		}

		[Sharpen.OverridesMethod(@"android.widget.AdapterView")]
		internal override int lookForSelectablePosition(int position, bool lookDown)
		{
			android.widget.ListAdapter adapter = mAdapter;
			if (adapter == null || isInTouchMode())
			{
				return android.widget.AdapterView.INVALID_POSITION;
			}
			if (position < 0 || position >= mItemCount)
			{
				return android.widget.AdapterView.INVALID_POSITION;
			}
			return position;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.widget.AbsListView")]
		internal override void fillGap(bool down)
		{
			int numColumns = mNumColumns;
			int verticalSpacing = mVerticalSpacing;
			int count = getChildCount();
			if (down)
			{
				int paddingTop = 0;
				if ((mGroupFlags & CLIP_TO_PADDING_MASK) == CLIP_TO_PADDING_MASK)
				{
					paddingTop = getListPaddingTop();
				}
				int startOffset = count > 0 ? getChildAt(count - 1).getBottom() + verticalSpacing
					 : paddingTop;
				int position = mFirstPosition + count;
				if (mStackFromBottom)
				{
					position += numColumns - 1;
				}
				fillDown(position, startOffset);
				correctTooHigh(numColumns, verticalSpacing, getChildCount());
			}
			else
			{
				int paddingBottom = 0;
				if ((mGroupFlags & CLIP_TO_PADDING_MASK) == CLIP_TO_PADDING_MASK)
				{
					paddingBottom = getListPaddingBottom();
				}
				int startOffset = count > 0 ? getChildAt(0).getTop() - verticalSpacing : getHeight
					() - paddingBottom;
				int position = mFirstPosition;
				if (!mStackFromBottom)
				{
					position -= numColumns;
				}
				else
				{
					position--;
				}
				fillUp(position, startOffset);
				correctTooLow(numColumns, verticalSpacing, getChildCount());
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
				android.view.View temp = makeRow(pos, nextTop, true);
				if (temp != null)
				{
					selectedView = temp;
				}
				// mReferenceView will change with each call to makeRow()
				// do not cache in a local variable outside of this loop
				nextTop = mReferenceView.getBottom() + mVerticalSpacing;
				pos += mNumColumns;
			}
			return selectedView;
		}

		private android.view.View makeRow(int startPos, int y, bool flow)
		{
			int columnWidth = mColumnWidth;
			int horizontalSpacing = mHorizontalSpacing;
			int last;
			int nextLeft = mListPadding.left + ((mStretchMode == STRETCH_SPACING_UNIFORM) ? horizontalSpacing
				 : 0);
			if (!mStackFromBottom)
			{
				last = System.Math.Min(startPos + mNumColumns, mItemCount);
			}
			else
			{
				last = startPos + 1;
				startPos = System.Math.Max(0, startPos - mNumColumns + 1);
				if (last - startPos < mNumColumns)
				{
					nextLeft += (mNumColumns - (last - startPos)) * (columnWidth + horizontalSpacing);
				}
			}
			android.view.View selectedView = null;
			bool hasFocus_1 = shouldShowSelector();
			bool inClick = touchModeDrawsInPressedState();
			int selectedPosition = mSelectedPosition;
			android.view.View child = null;
			{
				for (int pos = startPos; pos < last; pos++)
				{
					// is this the selected item?
					bool selected = pos == selectedPosition;
					// does the list view have focus or contain focus
					int where = flow ? -1 : pos - startPos;
					child = makeAndAddView(pos, y, flow, nextLeft, selected, where);
					nextLeft += columnWidth;
					if (pos < last - 1)
					{
						nextLeft += horizontalSpacing;
					}
					if (selected && (hasFocus_1 || inClick))
					{
						selectedView = child;
					}
				}
			}
			mReferenceView = child;
			if (selectedView != null)
			{
				mReferenceViewInSelectedRow = mReferenceView;
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
				android.view.View temp = makeRow(pos, nextBottom, false);
				if (temp != null)
				{
					selectedView = temp;
				}
				nextBottom = mReferenceView.getTop() - mVerticalSpacing;
				mFirstPosition = pos;
				pos -= mNumColumns;
			}
			if (mStackFromBottom)
			{
				mFirstPosition = System.Math.Max(0, pos + 1);
			}
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
			mFirstPosition -= mFirstPosition % mNumColumns;
			return fillDown(mFirstPosition, nextTop);
		}

		private android.view.View fillFromBottom(int lastPosition, int nextBottom)
		{
			lastPosition = System.Math.Max(lastPosition, mSelectedPosition);
			lastPosition = System.Math.Min(lastPosition, mItemCount - 1);
			int invertedPosition = mItemCount - 1 - lastPosition;
			lastPosition = mItemCount - 1 - (invertedPosition - (invertedPosition % mNumColumns
				));
			return fillUp(lastPosition, nextBottom);
		}

		private android.view.View fillSelection(int childrenTop, int childrenBottom)
		{
			int selectedPosition = reconcileSelectedPosition();
			int numColumns = mNumColumns;
			int verticalSpacing = mVerticalSpacing;
			int rowStart;
			int rowEnd = -1;
			if (!mStackFromBottom)
			{
				rowStart = selectedPosition - (selectedPosition % numColumns);
			}
			else
			{
				int invertedSelection = mItemCount - 1 - selectedPosition;
				rowEnd = mItemCount - 1 - (invertedSelection - (invertedSelection % numColumns));
				rowStart = System.Math.Max(0, rowEnd - numColumns + 1);
			}
			int fadingEdgeLength = getVerticalFadingEdgeLength();
			int topSelectionPixel = getTopSelectionPixel(childrenTop, fadingEdgeLength, rowStart
				);
			android.view.View sel = makeRow(mStackFromBottom ? rowEnd : rowStart, topSelectionPixel
				, true);
			mFirstPosition = rowStart;
			android.view.View referenceView = mReferenceView;
			if (!mStackFromBottom)
			{
				fillDown(rowStart + numColumns, referenceView.getBottom() + verticalSpacing);
				pinToBottom(childrenBottom);
				fillUp(rowStart - numColumns, referenceView.getTop() - verticalSpacing);
				adjustViewsUpOrDown();
			}
			else
			{
				int bottomSelectionPixel = getBottomSelectionPixel(childrenBottom, fadingEdgeLength
					, numColumns, rowStart);
				int offset = bottomSelectionPixel - referenceView.getBottom();
				offsetChildrenTopAndBottom(offset);
				fillUp(rowStart - 1, referenceView.getTop() - verticalSpacing);
				pinToTop(childrenTop);
				fillDown(rowEnd + numColumns, referenceView.getBottom() + verticalSpacing);
				adjustViewsUpOrDown();
			}
			return sel;
		}

		private void pinToTop(int childrenTop)
		{
			if (mFirstPosition == 0)
			{
				int top = getChildAt(0).getTop();
				int offset = childrenTop - top;
				if (offset < 0)
				{
					offsetChildrenTopAndBottom(offset);
				}
			}
		}

		private void pinToBottom(int childrenBottom)
		{
			int count = getChildCount();
			if (mFirstPosition + count == mItemCount)
			{
				int bottom = getChildAt(count - 1).getBottom();
				int offset = childrenBottom - bottom;
				if (offset > 0)
				{
					offsetChildrenTopAndBottom(offset);
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.widget.AbsListView")]
		internal override int findMotionRow(int y)
		{
			int childCount = getChildCount();
			if (childCount > 0)
			{
				int numColumns = mNumColumns;
				if (!mStackFromBottom)
				{
					{
						for (int i = 0; i < childCount; i += numColumns)
						{
							if (y <= getChildAt(i).getBottom())
							{
								return mFirstPosition + i;
							}
						}
					}
				}
				else
				{
					{
						for (int i = childCount - 1; i >= 0; i -= numColumns)
						{
							if (y >= getChildAt(i).getTop())
							{
								return mFirstPosition + i;
							}
						}
					}
				}
			}
			return android.widget.AdapterView.INVALID_POSITION;
		}

		/// <summary>Layout during a scroll that results from tracking motion events.</summary>
		/// <remarks>
		/// Layout during a scroll that results from tracking motion events. Places
		/// the mMotionPosition view at the offset specified by mMotionViewTop, and
		/// then build surrounding views from there.
		/// </remarks>
		/// <param name="position">the position at which to start filling</param>
		/// <param name="top">the top of the view at that position</param>
		/// <returns>
		/// The selected view, or null if the selected view is outside the
		/// visible area.
		/// </returns>
		private android.view.View fillSpecific(int position, int top)
		{
			int numColumns = mNumColumns;
			int motionRowStart;
			int motionRowEnd = -1;
			if (!mStackFromBottom)
			{
				motionRowStart = position - (position % numColumns);
			}
			else
			{
				int invertedSelection = mItemCount - 1 - position;
				motionRowEnd = mItemCount - 1 - (invertedSelection - (invertedSelection % numColumns
					));
				motionRowStart = System.Math.Max(0, motionRowEnd - numColumns + 1);
			}
			android.view.View temp = makeRow(mStackFromBottom ? motionRowEnd : motionRowStart
				, top, true);
			// Possibly changed again in fillUp if we add rows above this one.
			mFirstPosition = motionRowStart;
			android.view.View referenceView = mReferenceView;
			// We didn't have anything to layout, bail out
			if (referenceView == null)
			{
				return null;
			}
			int verticalSpacing = mVerticalSpacing;
			android.view.View above;
			android.view.View below;
			if (!mStackFromBottom)
			{
				above = fillUp(motionRowStart - numColumns, referenceView.getTop() - verticalSpacing
					);
				adjustViewsUpOrDown();
				below = fillDown(motionRowStart + numColumns, referenceView.getBottom() + verticalSpacing
					);
				// Check if we have dragged the bottom of the grid too high
				int childCount = getChildCount();
				if (childCount > 0)
				{
					correctTooHigh(numColumns, verticalSpacing, childCount);
				}
			}
			else
			{
				below = fillDown(motionRowEnd + numColumns, referenceView.getBottom() + verticalSpacing
					);
				adjustViewsUpOrDown();
				above = fillUp(motionRowStart - 1, referenceView.getTop() - verticalSpacing);
				// Check if we have dragged the bottom of the grid too high
				int childCount = getChildCount();
				if (childCount > 0)
				{
					correctTooLow(numColumns, verticalSpacing, childCount);
				}
			}
			if (temp != null)
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

		private void correctTooHigh(int numColumns, int verticalSpacing, int childCount)
		{
			// First see if the last item is visible
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
						fillUp(mFirstPosition - (mStackFromBottom ? 1 : numColumns), firstChild.getTop() 
							- verticalSpacing);
						// Close up the remaining gap
						adjustViewsUpOrDown();
					}
				}
			}
		}

		private void correctTooLow(int numColumns, int verticalSpacing, int childCount)
		{
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
				if (topOffset > 0 && (lastPosition < mItemCount - 1 || lastBottom > end))
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
						fillDown(lastPosition + (!mStackFromBottom ? 1 : numColumns), lastChild.getBottom
							() + verticalSpacing);
						// Close up the remaining gap
						adjustViewsUpOrDown();
					}
				}
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
			int numColumns = mNumColumns;
			int verticalSpacing = mVerticalSpacing;
			int rowStart;
			int rowEnd = -1;
			if (!mStackFromBottom)
			{
				rowStart = selectedPosition - (selectedPosition % numColumns);
			}
			else
			{
				int invertedSelection = mItemCount - 1 - selectedPosition;
				rowEnd = mItemCount - 1 - (invertedSelection - (invertedSelection % numColumns));
				rowStart = System.Math.Max(0, rowEnd - numColumns + 1);
			}
			android.view.View sel;
			android.view.View referenceView;
			int topSelectionPixel = getTopSelectionPixel(childrenTop, fadingEdgeLength, rowStart
				);
			int bottomSelectionPixel = getBottomSelectionPixel(childrenBottom, fadingEdgeLength
				, numColumns, rowStart);
			sel = makeRow(mStackFromBottom ? rowEnd : rowStart, selectedTop, true);
			// Possibly changed again in fillUp if we add rows above this one.
			mFirstPosition = rowStart;
			referenceView = mReferenceView;
			adjustForTopFadingEdge(referenceView, topSelectionPixel, bottomSelectionPixel);
			adjustForBottomFadingEdge(referenceView, topSelectionPixel, bottomSelectionPixel);
			if (!mStackFromBottom)
			{
				fillUp(rowStart - numColumns, referenceView.getTop() - verticalSpacing);
				adjustViewsUpOrDown();
				fillDown(rowStart + numColumns, referenceView.getBottom() + verticalSpacing);
			}
			else
			{
				fillDown(rowEnd + numColumns, referenceView.getBottom() + verticalSpacing);
				adjustViewsUpOrDown();
				fillUp(rowStart - 1, referenceView.getTop() - verticalSpacing);
			}
			return sel;
		}

		/// <summary>Calculate the bottom-most pixel we can draw the selection into</summary>
		/// <param name="childrenBottom">Bottom pixel were children can be drawn</param>
		/// <param name="fadingEdgeLength">Length of the fading edge in pixels, if present</param>
		/// <param name="numColumns">Number of columns in the grid</param>
		/// <param name="rowStart">The start of the row that will contain the selection</param>
		/// <returns>The bottom-most pixel we can draw the selection into</returns>
		private int getBottomSelectionPixel(int childrenBottom, int fadingEdgeLength, int
			 numColumns, int rowStart)
		{
			// Last pixel we can draw the selection into
			int bottomSelectionPixel = childrenBottom;
			if (rowStart + numColumns - 1 < mItemCount - 1)
			{
				bottomSelectionPixel -= fadingEdgeLength;
			}
			return bottomSelectionPixel;
		}

		/// <summary>Calculate the top-most pixel we can draw the selection into</summary>
		/// <param name="childrenTop">Top pixel were children can be drawn</param>
		/// <param name="fadingEdgeLength">Length of the fading edge in pixels, if present</param>
		/// <param name="rowStart">The start of the row that will contain the selection</param>
		/// <returns>The top-most pixel we can draw the selection into</returns>
		private int getTopSelectionPixel(int childrenTop, int fadingEdgeLength, int rowStart
			)
		{
			// first pixel we can draw the selection into
			int topSelectionPixel = childrenTop;
			if (rowStart > 0)
			{
				topSelectionPixel += fadingEdgeLength;
			}
			return topSelectionPixel;
		}

		/// <summary>
		/// Move all views upwards so the selected row does not interesect the bottom
		/// fading edge (if necessary).
		/// </summary>
		/// <remarks>
		/// Move all views upwards so the selected row does not interesect the bottom
		/// fading edge (if necessary).
		/// </remarks>
		/// <param name="childInSelectedRow">A child in the row that contains the selection</param>
		/// <param name="topSelectionPixel">The topmost pixel we can draw the selection into</param>
		/// <param name="bottomSelectionPixel">
		/// The bottommost pixel we can draw the
		/// selection into
		/// </param>
		private void adjustForBottomFadingEdge(android.view.View childInSelectedRow, int 
			topSelectionPixel, int bottomSelectionPixel)
		{
			// Some of the newly selected item extends below the bottom of the
			// list
			if (childInSelectedRow.getBottom() > bottomSelectionPixel)
			{
				// Find space available above the selection into which we can
				// scroll upwards
				int spaceAbove = childInSelectedRow.getTop() - topSelectionPixel;
				// Find space required to bring the bottom of the selected item
				// fully into view
				int spaceBelow = childInSelectedRow.getBottom() - bottomSelectionPixel;
				int offset = System.Math.Min(spaceAbove, spaceBelow);
				// Now offset the selected item to get it into view
				offsetChildrenTopAndBottom(-offset);
			}
		}

		/// <summary>
		/// Move all views upwards so the selected row does not interesect the top
		/// fading edge (if necessary).
		/// </summary>
		/// <remarks>
		/// Move all views upwards so the selected row does not interesect the top
		/// fading edge (if necessary).
		/// </remarks>
		/// <param name="childInSelectedRow">A child in the row that contains the selection</param>
		/// <param name="topSelectionPixel">The topmost pixel we can draw the selection into</param>
		/// <param name="bottomSelectionPixel">
		/// The bottommost pixel we can draw the
		/// selection into
		/// </param>
		private void adjustForTopFadingEdge(android.view.View childInSelectedRow, int topSelectionPixel
			, int bottomSelectionPixel)
		{
			// Some of the newly selected item extends above the top of the list
			if (childInSelectedRow.getTop() < topSelectionPixel)
			{
				// Find space required to bring the top of the selected item
				// fully into view
				int spaceAbove = topSelectionPixel - childInSelectedRow.getTop();
				// Find space available below the selection into which we can
				// scroll downwards
				int spaceBelow = bottomSelectionPixel - childInSelectedRow.getBottom();
				int offset = System.Math.Min(spaceAbove, spaceBelow);
				// Now offset the selected item to get it into view
				offsetChildrenTopAndBottom(offset);
			}
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
		/// Fills the grid based on positioning the new selection relative to the old
		/// selection.
		/// </summary>
		/// <remarks>
		/// Fills the grid based on positioning the new selection relative to the old
		/// selection. The new selection will be placed at, above, or below the
		/// location of the new selection depending on how the selection is moving.
		/// The selection will then be pinned to the visible part of the screen,
		/// excluding the edges that are faded. The grid is then filled upwards and
		/// downwards from there.
		/// </remarks>
		/// <param name="delta">Which way we are moving</param>
		/// <param name="childrenTop">Where to start drawing children</param>
		/// <param name="childrenBottom">Last pixel where children can be drawn</param>
		/// <returns>The view that currently has selection</returns>
		private android.view.View moveSelection(int delta, int childrenTop, int childrenBottom
			)
		{
			int fadingEdgeLength = getVerticalFadingEdgeLength();
			int selectedPosition = mSelectedPosition;
			int numColumns = mNumColumns;
			int verticalSpacing = mVerticalSpacing;
			int oldRowStart;
			int rowStart;
			int rowEnd = -1;
			if (!mStackFromBottom)
			{
				oldRowStart = (selectedPosition - delta) - ((selectedPosition - delta) % numColumns
					);
				rowStart = selectedPosition - (selectedPosition % numColumns);
			}
			else
			{
				int invertedSelection = mItemCount - 1 - selectedPosition;
				rowEnd = mItemCount - 1 - (invertedSelection - (invertedSelection % numColumns));
				rowStart = System.Math.Max(0, rowEnd - numColumns + 1);
				invertedSelection = mItemCount - 1 - (selectedPosition - delta);
				oldRowStart = mItemCount - 1 - (invertedSelection - (invertedSelection % numColumns
					));
				oldRowStart = System.Math.Max(0, oldRowStart - numColumns + 1);
			}
			int rowDelta = rowStart - oldRowStart;
			int topSelectionPixel = getTopSelectionPixel(childrenTop, fadingEdgeLength, rowStart
				);
			int bottomSelectionPixel = getBottomSelectionPixel(childrenBottom, fadingEdgeLength
				, numColumns, rowStart);
			// Possibly changed again in fillUp if we add rows above this one.
			mFirstPosition = rowStart;
			android.view.View sel;
			android.view.View referenceView;
			if (rowDelta > 0)
			{
				int oldBottom = mReferenceViewInSelectedRow == null ? 0 : mReferenceViewInSelectedRow
					.getBottom();
				sel = makeRow(mStackFromBottom ? rowEnd : rowStart, oldBottom + verticalSpacing, 
					true);
				referenceView = mReferenceView;
				adjustForBottomFadingEdge(referenceView, topSelectionPixel, bottomSelectionPixel);
			}
			else
			{
				if (rowDelta < 0)
				{
					int oldTop = mReferenceViewInSelectedRow == null ? 0 : mReferenceViewInSelectedRow
						.getTop();
					sel = makeRow(mStackFromBottom ? rowEnd : rowStart, oldTop - verticalSpacing, false
						);
					referenceView = mReferenceView;
					adjustForTopFadingEdge(referenceView, topSelectionPixel, bottomSelectionPixel);
				}
				else
				{
					int oldTop = mReferenceViewInSelectedRow == null ? 0 : mReferenceViewInSelectedRow
						.getTop();
					sel = makeRow(mStackFromBottom ? rowEnd : rowStart, oldTop, true);
					referenceView = mReferenceView;
				}
			}
			if (!mStackFromBottom)
			{
				fillUp(rowStart - numColumns, referenceView.getTop() - verticalSpacing);
				adjustViewsUpOrDown();
				fillDown(rowStart + numColumns, referenceView.getBottom() + verticalSpacing);
			}
			else
			{
				fillDown(rowEnd + numColumns, referenceView.getBottom() + verticalSpacing);
				adjustViewsUpOrDown();
				fillUp(rowStart - 1, referenceView.getTop() - verticalSpacing);
			}
			return sel;
		}

		private bool determineColumns(int availableSpace)
		{
			int requestedHorizontalSpacing = mRequestedHorizontalSpacing;
			int stretchMode = mStretchMode;
			int requestedColumnWidth = mRequestedColumnWidth;
			bool didNotInitiallyFit = false;
			if (mRequestedNumColumns == AUTO_FIT)
			{
				if (requestedColumnWidth > 0)
				{
					// Client told us to pick the number of columns
					mNumColumns = (availableSpace + requestedHorizontalSpacing) / (requestedColumnWidth
						 + requestedHorizontalSpacing);
				}
				else
				{
					// Just make up a number if we don't have enough info
					mNumColumns = 2;
				}
			}
			else
			{
				// We picked the columns
				mNumColumns = mRequestedNumColumns;
			}
			if (mNumColumns <= 0)
			{
				mNumColumns = 1;
			}
			switch (stretchMode)
			{
				case NO_STRETCH:
				{
					// Nobody stretches
					mColumnWidth = requestedColumnWidth;
					mHorizontalSpacing = requestedHorizontalSpacing;
					break;
				}

				default:
				{
					int spaceLeftOver = availableSpace - (mNumColumns * requestedColumnWidth) - ((mNumColumns
						 - 1) * requestedHorizontalSpacing);
					if (spaceLeftOver < 0)
					{
						didNotInitiallyFit = true;
					}
					switch (stretchMode)
					{
						case STRETCH_COLUMN_WIDTH:
						{
							// Stretch the columns
							mColumnWidth = requestedColumnWidth + spaceLeftOver / mNumColumns;
							mHorizontalSpacing = requestedHorizontalSpacing;
							break;
						}

						case STRETCH_SPACING:
						{
							// Stretch the spacing between columns
							mColumnWidth = requestedColumnWidth;
							if (mNumColumns > 1)
							{
								mHorizontalSpacing = requestedHorizontalSpacing + spaceLeftOver / (mNumColumns - 
									1);
							}
							else
							{
								mHorizontalSpacing = requestedHorizontalSpacing + spaceLeftOver;
							}
							break;
						}

						case STRETCH_SPACING_UNIFORM:
						{
							// Stretch the spacing between columns
							mColumnWidth = requestedColumnWidth;
							if (mNumColumns > 1)
							{
								mHorizontalSpacing = requestedHorizontalSpacing + spaceLeftOver / (mNumColumns + 
									1);
							}
							else
							{
								mHorizontalSpacing = requestedHorizontalSpacing + spaceLeftOver;
							}
							break;
						}
					}
					break;
				}
			}
			return didNotInitiallyFit;
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
			if (widthMode == android.view.View.MeasureSpec.UNSPECIFIED)
			{
				if (mColumnWidth > 0)
				{
					widthSize = mColumnWidth + mListPadding.left + mListPadding.right;
				}
				else
				{
					widthSize = mListPadding.left + mListPadding.right;
				}
				widthSize += getVerticalScrollbarWidth();
			}
			int childWidth = widthSize - mListPadding.left - mListPadding.right;
			bool didNotInitiallyFit = determineColumns(childWidth);
			int childHeight = 0;
			int childState = 0;
			mItemCount = mAdapter == null ? 0 : mAdapter.getCount();
			int count = mItemCount;
			if (count > 0)
			{
				android.view.View child = obtainView(0, mIsScrap);
				android.widget.AbsListView.LayoutParams p = (android.widget.AbsListView.LayoutParams
					)child.getLayoutParams();
				if (p == null)
				{
					p = new android.widget.AbsListView.LayoutParams(android.view.ViewGroup.LayoutParams
						.MATCH_PARENT, android.view.ViewGroup.LayoutParams.WRAP_CONTENT, 0);
					child.setLayoutParams(p);
				}
				p.viewType = mAdapter.getItemViewType(0);
				p.forceAdd = true;
				int childHeightSpec = getChildMeasureSpec(android.view.View.MeasureSpec.makeMeasureSpec
					(0, android.view.View.MeasureSpec.UNSPECIFIED), 0, p.height);
				int childWidthSpec = getChildMeasureSpec(android.view.View.MeasureSpec.makeMeasureSpec
					(mColumnWidth, android.view.View.MeasureSpec.EXACTLY), 0, p.width);
				child.measure(childWidthSpec, childHeightSpec);
				childHeight = child.getMeasuredHeight();
				childState = combineMeasuredStates(childState, child.getMeasuredState());
				if (mRecycler.shouldRecycleViewType(p.viewType))
				{
					mRecycler.addScrapView(child, -1);
				}
			}
			if (heightMode == android.view.View.MeasureSpec.UNSPECIFIED)
			{
				heightSize = mListPadding.top + mListPadding.bottom + childHeight + getVerticalFadingEdgeLength
					() * 2;
			}
			if (heightMode == android.view.View.MeasureSpec.AT_MOST)
			{
				int ourSize = mListPadding.top + mListPadding.bottom;
				int numColumns = mNumColumns;
				{
					for (int i = 0; i < count; i += numColumns)
					{
						ourSize += childHeight;
						if (i + numColumns < count)
						{
							ourSize += mVerticalSpacing;
						}
						if (ourSize >= heightSize)
						{
							ourSize = heightSize;
							break;
						}
					}
				}
				heightSize = ourSize;
			}
			if (widthMode == android.view.View.MeasureSpec.AT_MOST && mRequestedNumColumns !=
				 AUTO_FIT)
			{
				int ourSize = (mRequestedNumColumns * mColumnWidth) + ((mRequestedNumColumns - 1)
					 * mHorizontalSpacing) + mListPadding.left + mListPadding.right;
				if (ourSize > widthSize || didNotInitiallyFit)
				{
					widthSize |= MEASURED_STATE_TOO_SMALL;
				}
			}
			setMeasuredDimension(widthSize, heightSize);
			mWidthMeasureSpec = widthMeasureSpec;
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		protected internal override void attachLayoutAnimationParameters(android.view.View
			 child, android.view.ViewGroup.LayoutParams @params, int index, int count)
		{
			android.view.animation.GridLayoutAnimationController.AnimationParameters animationParams
				 = (android.view.animation.GridLayoutAnimationController.AnimationParameters)@params
				.layoutAnimationParameters;
			if (animationParams == null)
			{
				animationParams = new android.view.animation.GridLayoutAnimationController.AnimationParameters
					();
				@params.layoutAnimationParameters = animationParams;
			}
			animationParams.count = count;
			animationParams.index = index;
			animationParams.columnsCount = mNumColumns;
			animationParams.rowsCount = count / mNumColumns;
			if (!mStackFromBottom)
			{
				animationParams.column = index % mNumColumns;
				animationParams.row = index / mNumColumns;
			}
			else
			{
				int invertedIndex = count - 1 - index;
				animationParams.column = mNumColumns - 1 - (invertedIndex % mNumColumns);
				animationParams.row = animationParams.rowsCount - 1 - invertedIndex / mNumColumns;
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
				int index;
				int delta = 0;
				android.view.View sel;
				android.view.View oldSel = null;
				android.view.View oldFirst = null;
				android.view.View newSel = null;
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
					{
						if (mNextSelectedPosition >= 0)
						{
							delta = mNextSelectedPosition - mSelectedPosition;
						}
						break;
					}

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
				setSelectedPositionInt(mNextSelectedPosition);
				// Pull all children into the RecycleBin.
				// These views will be reused if possible
				int firstPosition = mFirstPosition;
				android.widget.AbsListView.RecycleBin recycleBin = mRecycler;
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
				// Clear out old views
				//removeAllViewsInLayout();
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
							sel = fillSelection(childrenTop, childrenBottom);
						}
						break;
					}

					case LAYOUT_FORCE_TOP:
					{
						mFirstPosition = 0;
						sel = fillFromTop(childrenTop);
						adjustViewsUpOrDown();
						break;
					}

					case LAYOUT_FORCE_BOTTOM:
					{
						sel = fillUp(mItemCount - 1, childrenBottom);
						adjustViewsUpOrDown();
						break;
					}

					case LAYOUT_SPECIFIC:
					{
						sel = fillSpecific(mSelectedPosition, mSpecificTop);
						break;
					}

					case LAYOUT_SYNC:
					{
						sel = fillSpecific(mSyncPosition, mSpecificTop);
						break;
					}

					case LAYOUT_MOVE_SELECTION:
					{
						// Move the selection relative to its old position
						sel = moveSelection(delta, childrenTop, childrenBottom);
						break;
					}

					default:
					{
						if (childCount == 0)
						{
							if (!mStackFromBottom)
							{
								setSelectedPositionInt(mAdapter == null || isInTouchMode() ? android.widget.AdapterView.INVALID_POSITION
									 : 0);
								sel = fillFromTop(childrenTop);
							}
							else
							{
								int last = mItemCount - 1;
								setSelectedPositionInt(mAdapter == null || isInTouchMode() ? android.widget.AdapterView.INVALID_POSITION
									 : last);
								sel = fillFromBottom(last, childrenBottom);
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
					positionSelector(android.widget.AdapterView.INVALID_POSITION, sel);
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

		/// <summary>Obtain the view and add it to our list of children.</summary>
		/// <remarks>
		/// Obtain the view and add it to our list of children. The view can be made
		/// fresh, converted from an unused view, or used as is if it was in the
		/// recycle bin.
		/// </remarks>
		/// <param name="position">Logical position in the list</param>
		/// <param name="y">Top or bottom edge of the view to add</param>
		/// <param name="flow">
		/// if true, align top edge to y. If false, align bottom edge to
		/// y.
		/// </param>
		/// <param name="childrenLeft">Left edge where children should be positioned</param>
		/// <param name="selected">Is this position selected?</param>
		/// <param name="where">to add new item in the list</param>
		/// <returns>View that was added</returns>
		private android.view.View makeAndAddView(int position, int y, bool flow, int childrenLeft
			, bool selected, int where)
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
					setupChild(child, position, y, flow, childrenLeft, selected, true, where);
					return child;
				}
			}
			// Make a new view for this position, or convert an unused view if
			// possible
			child = obtainView(position, mIsScrap);
			// This needs to be positioned and measured
			setupChild(child, position, y, flow, childrenLeft, selected, mIsScrap[0], where);
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
		/// <param name="position">The position of the view</param>
		/// <param name="y">The y position relative to which this view will be positioned</param>
		/// <param name="flow">
		/// if true, align top edge to y. If false, align bottom edge
		/// to y.
		/// </param>
		/// <param name="childrenLeft">Left edge where children should be positioned</param>
		/// <param name="selected">Is this position selected?</param>
		/// <param name="recycled">
		/// Has this view been pulled from the recycle bin? If so it
		/// does not need to be remeasured.
		/// </param>
		/// <param name="where">Where to add the item in the list</param>
		private void setupChild(android.view.View child, int position, int y, bool flow, 
			int childrenLeft, bool selected, bool recycled, int where)
		{
			bool isSelected_1 = selected && shouldShowSelector();
			bool updateChildSelected = isSelected_1 != child.isSelected();
			int mode = mTouchMode;
			bool isPressed_1 = mode > TOUCH_MODE_DOWN && mode < TOUCH_MODE_SCROLL && mMotionPosition
				 == position;
			bool updateChildPressed = isPressed_1 != child.isPressed();
			bool needToMeasure = !recycled || updateChildSelected || child.isLayoutRequested(
				);
			// Respect layout params that are already in the view. Otherwise make
			// some up...
			android.widget.AbsListView.LayoutParams p = (android.widget.AbsListView.LayoutParams
				)child.getLayoutParams();
			if (p == null)
			{
				p = new android.widget.AbsListView.LayoutParams(android.view.ViewGroup.LayoutParams
					.MATCH_PARENT, android.view.ViewGroup.LayoutParams.WRAP_CONTENT, 0);
			}
			p.viewType = mAdapter.getItemViewType(position);
			if (recycled && !p.forceAdd)
			{
				attachViewToParent(child, where, p);
			}
			else
			{
				p.forceAdd = false;
				addViewInLayout(child, where, p, true);
			}
			if (updateChildSelected)
			{
				child.setSelected(isSelected_1);
				if (isSelected_1)
				{
					requestFocus();
				}
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
				int childHeightSpec = android.view.ViewGroup.getChildMeasureSpec(android.view.View
					.MeasureSpec.makeMeasureSpec(0, android.view.View.MeasureSpec.UNSPECIFIED), 0, p
					.height);
				int childWidthSpec = android.view.ViewGroup.getChildMeasureSpec(android.view.View
					.MeasureSpec.makeMeasureSpec(mColumnWidth, android.view.View.MeasureSpec.EXACTLY
					), 0, p.width);
				child.measure(childWidthSpec, childHeightSpec);
			}
			else
			{
				cleanupLayoutState(child);
			}
			int w = child.getMeasuredWidth();
			int h = child.getMeasuredHeight();
			int childLeft;
			int childTop = flow ? y : y - h;
			int layoutDirection = getResolvedLayoutDirection();
			int absoluteGravity = android.view.Gravity.getAbsoluteGravity(mGravity, layoutDirection
				);
			switch (absoluteGravity & android.view.Gravity.HORIZONTAL_GRAVITY_MASK)
			{
				case android.view.Gravity.LEFT:
				{
					childLeft = childrenLeft;
					break;
				}

				case android.view.Gravity.CENTER_HORIZONTAL:
				{
					childLeft = childrenLeft + ((mColumnWidth - w) / 2);
					break;
				}

				case android.view.Gravity.RIGHT:
				{
					childLeft = childrenLeft + mColumnWidth - w;
					break;
				}

				default:
				{
					childLeft = childrenLeft;
					break;
				}
			}
			if (needToMeasure)
			{
				int childRight = childLeft + w;
				int childBottom = childTop + h;
				child.layout(childLeft, childTop, childRight, childBottom);
			}
			else
			{
				child.offsetLeftAndRight(childLeft - child.getLeft());
				child.offsetTopAndBottom(childTop - child.getTop());
			}
			if (mCachingStarted)
			{
				child.setDrawingCacheEnabled(true);
			}
			if (recycled && (((android.widget.AbsListView.LayoutParams)child.getLayoutParams(
				)).scrappedFromPosition) != position)
			{
				child.jumpDrawablesToCurrentState();
			}
		}

		/// <summary>Sets the currently selected item</summary>
		/// <param name="position">
		/// Index (starting at 0) of the data item to be selected.
		/// If in touch mode, the item will not be selected but it will still be positioned
		/// appropriately.
		/// </param>
		[Sharpen.OverridesMethod(@"android.widget.AdapterView")]
		public override void setSelection(int position)
		{
			if (!isInTouchMode())
			{
				setNextSelectedPositionInt(position);
			}
			else
			{
				mResurrectToPosition = position;
			}
			mLayoutMode = LAYOUT_SET_SELECTION;
			requestLayout();
		}

		/// <summary>Makes the item at the supplied position selected.</summary>
		/// <remarks>Makes the item at the supplied position selected.</remarks>
		/// <param name="position">the position of the new selection</param>
		[Sharpen.OverridesMethod(@"android.widget.AbsListView")]
		internal override void setSelectionInt(int position)
		{
			int previousSelectedPosition = mNextSelectedPosition;
			setNextSelectedPositionInt(position);
			layoutChildren();
			int next = mStackFromBottom ? mItemCount - 1 - mNextSelectedPosition : mNextSelectedPosition;
			int previous = mStackFromBottom ? mItemCount - 1 - previousSelectedPosition : previousSelectedPosition;
			int nextRow = next / mNumColumns;
			int previousRow = previous / mNumColumns;
			if (nextRow != previousRow)
			{
				awakenScrollBars();
			}
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
			if (mAdapter == null)
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
					case android.view.KeyEvent.KEYCODE_DPAD_LEFT:
					{
						if (@event.hasNoModifiers())
						{
							handled = resurrectSelectionIfNeeded() || arrowScroll(FOCUS_LEFT);
						}
						break;
					}

					case android.view.KeyEvent.KEYCODE_DPAD_RIGHT:
					{
						if (@event.hasNoModifiers())
						{
							handled = resurrectSelectionIfNeeded() || arrowScroll(FOCUS_RIGHT);
						}
						break;
					}

					case android.view.KeyEvent.KEYCODE_DPAD_UP:
					{
						if (@event.hasNoModifiers())
						{
							handled = resurrectSelectionIfNeeded() || arrowScroll(FOCUS_UP);
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
							handled = resurrectSelectionIfNeeded() || arrowScroll(FOCUS_DOWN);
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
						//     a GridView sequentially.  Unfortunately this can create an
						//     asymmetry in TAB navigation order unless the list selection
						//     always reverts to the top or bottom when receiving TAB focus from
						//     another widget.  Leaving this behavior disabled for now but
						//     perhaps it should be configurable (and more comprehensive).
						if (false)
						{
							if (@event.hasNoModifiers())
							{
								handled = resurrectSelectionIfNeeded() || sequenceScroll(FOCUS_FORWARD);
							}
							else
							{
								if (@event.hasModifiers(android.view.KeyEvent.META_SHIFT_ON))
								{
									handled = resurrectSelectionIfNeeded() || sequenceScroll(FOCUS_BACKWARD);
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
			if (direction == FOCUS_UP)
			{
				nextPage = System.Math.Max(0, mSelectedPosition - getChildCount());
			}
			else
			{
				if (direction == FOCUS_DOWN)
				{
					nextPage = System.Math.Min(mItemCount - 1, mSelectedPosition + getChildCount());
				}
			}
			if (nextPage >= 0)
			{
				setSelectionInt(nextPage);
				invokeOnItemScrollListener();
				awakenScrollBars();
				return true;
			}
			return false;
		}

		/// <summary>Go to the last or first item if possible.</summary>
		/// <remarks>Go to the last or first item if possible.</remarks>
		/// <param name="direction">
		/// either
		/// <see cref="android.view.View.FOCUS_UP">android.view.View.FOCUS_UP</see>
		/// or
		/// <see cref="android.view.View.FOCUS_DOWN">android.view.View.FOCUS_DOWN</see>
		/// .
		/// </param>
		/// <returns>Whether selection was moved.</returns>
		internal virtual bool fullScroll(int direction)
		{
			bool moved = false;
			if (direction == FOCUS_UP)
			{
				mLayoutMode = LAYOUT_SET_SELECTION;
				setSelectionInt(0);
				invokeOnItemScrollListener();
				moved = true;
			}
			else
			{
				if (direction == FOCUS_DOWN)
				{
					mLayoutMode = LAYOUT_SET_SELECTION;
					setSelectionInt(mItemCount - 1);
					invokeOnItemScrollListener();
					moved = true;
				}
			}
			if (moved)
			{
				awakenScrollBars();
			}
			return moved;
		}

		/// <summary>Scrolls to the next or previous item, horizontally or vertically.</summary>
		/// <remarks>Scrolls to the next or previous item, horizontally or vertically.</remarks>
		/// <param name="direction">
		/// either
		/// <see cref="android.view.View.FOCUS_LEFT">android.view.View.FOCUS_LEFT</see>
		/// ,
		/// <see cref="android.view.View.FOCUS_RIGHT">android.view.View.FOCUS_RIGHT</see>
		/// ,
		/// <see cref="android.view.View.FOCUS_UP">android.view.View.FOCUS_UP</see>
		/// or
		/// <see cref="android.view.View.FOCUS_DOWN">android.view.View.FOCUS_DOWN</see>
		/// </param>
		/// <returns>whether selection was moved</returns>
		internal virtual bool arrowScroll(int direction)
		{
			int selectedPosition = mSelectedPosition;
			int numColumns = mNumColumns;
			int startOfRowPos;
			int endOfRowPos;
			bool moved = false;
			if (!mStackFromBottom)
			{
				startOfRowPos = (selectedPosition / numColumns) * numColumns;
				endOfRowPos = System.Math.Min(startOfRowPos + numColumns - 1, mItemCount - 1);
			}
			else
			{
				int invertedSelection = mItemCount - 1 - selectedPosition;
				endOfRowPos = mItemCount - 1 - (invertedSelection / numColumns) * numColumns;
				startOfRowPos = System.Math.Max(0, endOfRowPos - numColumns + 1);
			}
			switch (direction)
			{
				case FOCUS_UP:
				{
					if (startOfRowPos > 0)
					{
						mLayoutMode = LAYOUT_MOVE_SELECTION;
						setSelectionInt(System.Math.Max(0, selectedPosition - numColumns));
						moved = true;
					}
					break;
				}

				case FOCUS_DOWN:
				{
					if (endOfRowPos < mItemCount - 1)
					{
						mLayoutMode = LAYOUT_MOVE_SELECTION;
						setSelectionInt(System.Math.Min(selectedPosition + numColumns, mItemCount - 1));
						moved = true;
					}
					break;
				}

				case FOCUS_LEFT:
				{
					if (selectedPosition > startOfRowPos)
					{
						mLayoutMode = LAYOUT_MOVE_SELECTION;
						setSelectionInt(System.Math.Max(0, selectedPosition - 1));
						moved = true;
					}
					break;
				}

				case FOCUS_RIGHT:
				{
					if (selectedPosition < endOfRowPos)
					{
						mLayoutMode = LAYOUT_MOVE_SELECTION;
						setSelectionInt(System.Math.Min(selectedPosition + 1, mItemCount - 1));
						moved = true;
					}
					break;
				}
			}
			if (moved)
			{
				playSoundEffect(android.view.SoundEffectConstants.getContantForFocusDirection(direction
					));
				invokeOnItemScrollListener();
			}
			if (moved)
			{
				awakenScrollBars();
			}
			return moved;
		}

		/// <summary>
		/// Goes to the next or previous item according to the order set by the
		/// adapter.
		/// </summary>
		/// <remarks>
		/// Goes to the next or previous item according to the order set by the
		/// adapter.
		/// </remarks>
		internal virtual bool sequenceScroll(int direction)
		{
			int selectedPosition = mSelectedPosition;
			int numColumns = mNumColumns;
			int count = mItemCount;
			int startOfRow;
			int endOfRow;
			if (!mStackFromBottom)
			{
				startOfRow = (selectedPosition / numColumns) * numColumns;
				endOfRow = System.Math.Min(startOfRow + numColumns - 1, count - 1);
			}
			else
			{
				int invertedSelection = count - 1 - selectedPosition;
				endOfRow = count - 1 - (invertedSelection / numColumns) * numColumns;
				startOfRow = System.Math.Max(0, endOfRow - numColumns + 1);
			}
			bool moved = false;
			bool showScroll = false;
			switch (direction)
			{
				case FOCUS_FORWARD:
				{
					if (selectedPosition < count - 1)
					{
						// Move to the next item.
						mLayoutMode = LAYOUT_MOVE_SELECTION;
						setSelectionInt(selectedPosition + 1);
						moved = true;
						// Show the scrollbar only if changing rows.
						showScroll = selectedPosition == endOfRow;
					}
					break;
				}

				case FOCUS_BACKWARD:
				{
					if (selectedPosition > 0)
					{
						// Move to the previous item.
						mLayoutMode = LAYOUT_MOVE_SELECTION;
						setSelectionInt(selectedPosition - 1);
						moved = true;
						// Show the scrollbar only if changing rows.
						showScroll = selectedPosition == startOfRow;
					}
					break;
				}
			}
			if (moved)
			{
				playSoundEffect(android.view.SoundEffectConstants.getContantForFocusDirection(direction
					));
				invokeOnItemScrollListener();
			}
			if (showScroll)
			{
				awakenScrollBars();
			}
			return moved;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onFocusChanged(bool gainFocus, int direction, android.graphics.Rect
			 previouslyFocusedRect)
		{
			base.onFocusChanged(gainFocus, direction, previouslyFocusedRect);
			int closestChildIndex = -1;
			if (gainFocus && previouslyFocusedRect != null)
			{
				previouslyFocusedRect.offset(mScrollX, mScrollY);
				// figure out which item should be selected based on previously
				// focused rect
				android.graphics.Rect otherRect = mTempRect;
				int minDistance = int.MaxValue;
				int childCount = getChildCount();
				{
					for (int i = 0; i < childCount; i++)
					{
						// only consider view's on appropriate edge of grid
						if (!isCandidateSelection(i, direction))
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
							closestChildIndex = i;
						}
					}
				}
			}
			if (closestChildIndex >= 0)
			{
				setSelection(closestChildIndex + mFirstPosition);
			}
			else
			{
				requestLayout();
			}
		}

		/// <summary>
		/// Is childIndex a candidate for next focus given the direction the focus
		/// change is coming from?
		/// </summary>
		/// <param name="childIndex">The index to check.</param>
		/// <param name="direction">
		/// The direction, one of
		/// {FOCUS_UP, FOCUS_DOWN, FOCUS_LEFT, FOCUS_RIGHT, FOCUS_FORWARD, FOCUS_BACKWARD}
		/// </param>
		/// <returns>Whether childIndex is a candidate.</returns>
		private bool isCandidateSelection(int childIndex, int direction)
		{
			int count = getChildCount();
			int invertedIndex = count - 1 - childIndex;
			int rowStart;
			int rowEnd;
			if (!mStackFromBottom)
			{
				rowStart = childIndex - (childIndex % mNumColumns);
				rowEnd = System.Math.Max(rowStart + mNumColumns - 1, count);
			}
			else
			{
				rowEnd = count - 1 - (invertedIndex - (invertedIndex % mNumColumns));
				rowStart = System.Math.Max(0, rowEnd - mNumColumns + 1);
			}
			switch (direction)
			{
				case android.view.View.FOCUS_RIGHT:
				{
					// coming from left, selection is only valid if it is on left
					// edge
					return childIndex == rowStart;
				}

				case android.view.View.FOCUS_DOWN:
				{
					// coming from top; only valid if in top row
					return rowStart == 0;
				}

				case android.view.View.FOCUS_LEFT:
				{
					// coming from right, must be on right edge
					return childIndex == rowEnd;
				}

				case android.view.View.FOCUS_UP:
				{
					// coming from bottom, need to be in last row
					return rowEnd == count - 1;
				}

				case android.view.View.FOCUS_FORWARD:
				{
					// coming from top-left, need to be first in top row
					return childIndex == rowStart && rowStart == 0;
				}

				case android.view.View.FOCUS_BACKWARD:
				{
					// coming from bottom-right, need to be last in bottom row
					return childIndex == rowEnd && rowEnd == count - 1;
				}

				default:
				{
					throw new System.ArgumentException("direction must be one of " + "{FOCUS_UP, FOCUS_DOWN, FOCUS_LEFT, FOCUS_RIGHT, "
						 + "FOCUS_FORWARD, FOCUS_BACKWARD}.");
				}
			}
		}

		/// <summary>Describes how the child views are horizontally aligned.</summary>
		/// <remarks>Describes how the child views are horizontally aligned. Defaults to Gravity.LEFT
		/// 	</remarks>
		/// <param name="gravity">the gravity to apply to this grid's children</param>
		/// <attr>ref android.R.styleable#GridView_gravity</attr>
		public virtual void setGravity(int gravity)
		{
			if (mGravity != gravity)
			{
				mGravity = gravity;
				requestLayoutIfNecessary();
			}
		}

		/// <summary>
		/// Set the amount of horizontal (x) spacing to place between each item
		/// in the grid.
		/// </summary>
		/// <remarks>
		/// Set the amount of horizontal (x) spacing to place between each item
		/// in the grid.
		/// </remarks>
		/// <param name="horizontalSpacing">
		/// The amount of horizontal space between items,
		/// in pixels.
		/// </param>
		/// <attr>ref android.R.styleable#GridView_horizontalSpacing</attr>
		public virtual void setHorizontalSpacing(int horizontalSpacing)
		{
			if (horizontalSpacing != mRequestedHorizontalSpacing)
			{
				mRequestedHorizontalSpacing = horizontalSpacing;
				requestLayoutIfNecessary();
			}
		}

		/// <summary>
		/// Set the amount of vertical (y) spacing to place between each item
		/// in the grid.
		/// </summary>
		/// <remarks>
		/// Set the amount of vertical (y) spacing to place between each item
		/// in the grid.
		/// </remarks>
		/// <param name="verticalSpacing">
		/// The amount of vertical space between items,
		/// in pixels.
		/// </param>
		/// <attr>ref android.R.styleable#GridView_verticalSpacing</attr>
		public virtual void setVerticalSpacing(int verticalSpacing)
		{
			if (verticalSpacing != mVerticalSpacing)
			{
				mVerticalSpacing = verticalSpacing;
				requestLayoutIfNecessary();
			}
		}

		/// <summary>Control how items are stretched to fill their space.</summary>
		/// <remarks>Control how items are stretched to fill their space.</remarks>
		/// <param name="stretchMode">
		/// Either
		/// <see cref="NO_STRETCH">NO_STRETCH</see>
		/// ,
		/// <see cref="STRETCH_SPACING">STRETCH_SPACING</see>
		/// ,
		/// <see cref="STRETCH_SPACING_UNIFORM">STRETCH_SPACING_UNIFORM</see>
		/// , or
		/// <see cref="STRETCH_COLUMN_WIDTH">STRETCH_COLUMN_WIDTH</see>
		/// .
		/// </param>
		/// <attr>ref android.R.styleable#GridView_stretchMode</attr>
		public virtual void setStretchMode(int stretchMode)
		{
			if (stretchMode != mStretchMode)
			{
				mStretchMode = stretchMode;
				requestLayoutIfNecessary();
			}
		}

		public virtual int getStretchMode()
		{
			return mStretchMode;
		}

		/// <summary>Set the width of columns in the grid.</summary>
		/// <remarks>Set the width of columns in the grid.</remarks>
		/// <param name="columnWidth">The column width, in pixels.</param>
		/// <attr>ref android.R.styleable#GridView_columnWidth</attr>
		public virtual void setColumnWidth(int columnWidth)
		{
			if (columnWidth != mRequestedColumnWidth)
			{
				mRequestedColumnWidth = columnWidth;
				requestLayoutIfNecessary();
			}
		}

		/// <summary>Set the number of columns in the grid</summary>
		/// <param name="numColumns">The desired number of columns.</param>
		/// <attr>ref android.R.styleable#GridView_numColumns</attr>
		public virtual void setNumColumns(int numColumns)
		{
			if (numColumns != mRequestedNumColumns)
			{
				mRequestedNumColumns = numColumns;
				requestLayoutIfNecessary();
			}
		}

		/// <summary>Get the number of columns in the grid.</summary>
		/// <remarks>
		/// Get the number of columns in the grid.
		/// Returns
		/// <see cref="AUTO_FIT">AUTO_FIT</see>
		/// if the Grid has never been laid out.
		/// </remarks>
		/// <attr>ref android.R.styleable#GridView_numColumns</attr>
		/// <seealso cref="setNumColumns(int)">setNumColumns(int)</seealso>
		[android.view.ViewDebug.ExportedProperty]
		public virtual int getNumColumns()
		{
			return mNumColumns;
		}

		/// <summary>
		/// Make sure views are touching the top or bottom edge, as appropriate for
		/// our gravity
		/// </summary>
		private void adjustViewsUpOrDown()
		{
			int childCount = getChildCount();
			if (childCount > 0)
			{
				int delta;
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
						delta -= mVerticalSpacing;
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
						delta += mVerticalSpacing;
					}
					if (delta > 0)
					{
						// We only are looking to see if we are too high, not too low
						delta = 0;
					}
				}
				if (delta != 0)
				{
					offsetChildrenTopAndBottom(-delta);
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override int computeVerticalScrollExtent()
		{
			int count = getChildCount();
			if (count > 0)
			{
				int numColumns = mNumColumns;
				int rowCount = (count + numColumns - 1) / numColumns;
				int extent = rowCount * 100;
				android.view.View view = getChildAt(0);
				int top = view.getTop();
				int height = view.getHeight();
				if (height > 0)
				{
					extent += (top * 100) / height;
				}
				view = getChildAt(count - 1);
				int bottom = view.getBottom();
				height = view.getHeight();
				if (height > 0)
				{
					extent -= ((bottom - getHeight()) * 100) / height;
				}
				return extent;
			}
			return 0;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override int computeVerticalScrollOffset()
		{
			if (mFirstPosition >= 0 && getChildCount() > 0)
			{
				android.view.View view = getChildAt(0);
				int top = view.getTop();
				int height = view.getHeight();
				if (height > 0)
				{
					int numColumns = mNumColumns;
					int whichRow = mFirstPosition / numColumns;
					int rowCount = (mItemCount + numColumns - 1) / numColumns;
					return System.Math.Max(whichRow * 100 - (top * 100) / height + (int)((float)mScrollY
						 / getHeight() * rowCount * 100), 0);
				}
			}
			return 0;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override int computeVerticalScrollRange()
		{
			// TODO: Account for vertical spacing too
			int numColumns = mNumColumns;
			int rowCount = (mItemCount + numColumns - 1) / numColumns;
			int result = System.Math.Max(rowCount * 100, 0);
			if (mScrollY != 0)
			{
				// Compensate for overscroll
				result += System.Math.Abs((int)((float)mScrollY / getHeight() * rowCount * 100));
			}
			return result;
		}
	}
}

using Sharpen;

namespace android.widget
{
	/// <summary>A view that shows items in a vertically scrolling two-level list.</summary>
	/// <remarks>
	/// A view that shows items in a vertically scrolling two-level list. This
	/// differs from the
	/// <see cref="ListView">ListView</see>
	/// by allowing two levels: groups which can
	/// individually be expanded to show its children. The items come from the
	/// <see cref="ExpandableListAdapter">ExpandableListAdapter</see>
	/// associated with this view.
	/// <p>
	/// Expandable lists are able to show an indicator beside each item to display
	/// the item's current state (the states are usually one of expanded group,
	/// collapsed group, child, or last child). Use
	/// <see cref="setChildIndicator(android.graphics.drawable.Drawable)">setChildIndicator(android.graphics.drawable.Drawable)
	/// 	</see>
	/// or
	/// <see cref="setGroupIndicator(android.graphics.drawable.Drawable)">setGroupIndicator(android.graphics.drawable.Drawable)
	/// 	</see>
	/// (or the corresponding XML attributes) to set these indicators (see the docs
	/// for each method to see additional state that each Drawable can have). The
	/// default style for an
	/// <see cref="ExpandableListView">ExpandableListView</see>
	/// provides indicators which
	/// will be shown next to Views given to the
	/// <see cref="ExpandableListView">ExpandableListView</see>
	/// . The
	/// layouts android.R.layout.simple_expandable_list_item_1 and
	/// android.R.layout.simple_expandable_list_item_2 (which should be used with
	/// <see cref="SimpleCursorTreeAdapter">SimpleCursorTreeAdapter</see>
	/// ) contain the preferred position information
	/// for indicators.
	/// <p>
	/// The context menu information set by an
	/// <see cref="ExpandableListView">ExpandableListView</see>
	/// will be a
	/// <see cref="ExpandableListContextMenuInfo">ExpandableListContextMenuInfo</see>
	/// object with
	/// <see cref="ExpandableListContextMenuInfo.packedPosition">ExpandableListContextMenuInfo.packedPosition
	/// 	</see>
	/// being a packed position
	/// that can be used with
	/// <see cref="getPackedPositionType(long)">getPackedPositionType(long)</see>
	/// and the other
	/// similar methods.
	/// <p>
	/// <em><b>Note:</b></em> You cannot use the value <code>wrap_content</code>
	/// for the <code>android:layout_height</code> attribute of a
	/// ExpandableListView in XML if the parent's size is also not strictly specified
	/// (for example, if the parent were ScrollView you could not specify
	/// wrap_content since it also can be any length. However, you can use
	/// wrap_content if the ExpandableListView parent has a specific size, such as
	/// 100 pixels.
	/// </remarks>
	/// <attr>ref android.R.styleable#ExpandableListView_groupIndicator</attr>
	/// <attr>ref android.R.styleable#ExpandableListView_indicatorLeft</attr>
	/// <attr>ref android.R.styleable#ExpandableListView_indicatorRight</attr>
	/// <attr>ref android.R.styleable#ExpandableListView_childIndicator</attr>
	/// <attr>ref android.R.styleable#ExpandableListView_childIndicatorLeft</attr>
	/// <attr>ref android.R.styleable#ExpandableListView_childIndicatorRight</attr>
	/// <attr>ref android.R.styleable#ExpandableListView_childDivider</attr>
	[Sharpen.Sharpened]
	public class ExpandableListView : android.widget.ListView
	{
		/// <summary>The packed position represents a group.</summary>
		/// <remarks>The packed position represents a group.</remarks>
		public const int PACKED_POSITION_TYPE_GROUP = 0;

		/// <summary>The packed position represents a child.</summary>
		/// <remarks>The packed position represents a child.</remarks>
		public const int PACKED_POSITION_TYPE_CHILD = 1;

		/// <summary>The packed position represents a neither/null/no preference.</summary>
		/// <remarks>The packed position represents a neither/null/no preference.</remarks>
		public const int PACKED_POSITION_TYPE_NULL = 2;

		/// <summary>
		/// The value for a packed position that represents neither/null/no
		/// preference.
		/// </summary>
		/// <remarks>
		/// The value for a packed position that represents neither/null/no
		/// preference. This value is not otherwise possible since a group type
		/// (first bit 0) should not have a child position filled.
		/// </remarks>
		public const long PACKED_POSITION_VALUE_NULL = unchecked((long)(0x00000000FFFFFFFFL
			));

		/// <summary>The mask (in packed position representation) for the child</summary>
		internal const long PACKED_POSITION_MASK_CHILD = unchecked((long)(0x00000000FFFFFFFFL
			));

		/// <summary>The mask (in packed position representation) for the group</summary>
		internal const long PACKED_POSITION_MASK_GROUP = unchecked((long)(0x7FFFFFFF00000000L
			));

		/// <summary>The mask (in packed position representation) for the type</summary>
		internal const long PACKED_POSITION_MASK_TYPE = unchecked((long)(0x8000000000000000L
			));

		/// <summary>The shift amount (in packed position representation) for the group</summary>
		internal const long PACKED_POSITION_SHIFT_GROUP = 32;

		/// <summary>The shift amount (in packed position representation) for the type</summary>
		internal const long PACKED_POSITION_SHIFT_TYPE = 63;

		/// <summary>The mask (in integer child position representation) for the child</summary>
		internal const long PACKED_POSITION_INT_MASK_CHILD = unchecked((int)(0xFFFFFFFF));

		/// <summary>The mask (in integer group position representation) for the group</summary>
		internal const long PACKED_POSITION_INT_MASK_GROUP = unchecked((int)(0x7FFFFFFF));

		/// <summary>Serves as the glue/translator between a ListView and an ExpandableListView
		/// 	</summary>
		private android.widget.ExpandableListConnector mConnector;

		/// <summary>Gives us Views through group+child positions</summary>
		private android.widget.ExpandableListAdapter mAdapter;

		/// <summary>Left bound for drawing the indicator.</summary>
		/// <remarks>Left bound for drawing the indicator.</remarks>
		private int mIndicatorLeft;

		/// <summary>Right bound for drawing the indicator.</summary>
		/// <remarks>Right bound for drawing the indicator.</remarks>
		private int mIndicatorRight;

		/// <summary>Left bound for drawing the indicator of a child.</summary>
		/// <remarks>
		/// Left bound for drawing the indicator of a child. Value of
		/// <see cref="CHILD_INDICATOR_INHERIT">CHILD_INDICATOR_INHERIT</see>
		/// means use mIndicatorLeft.
		/// </remarks>
		private int mChildIndicatorLeft;

		/// <summary>Right bound for drawing the indicator of a child.</summary>
		/// <remarks>
		/// Right bound for drawing the indicator of a child. Value of
		/// <see cref="CHILD_INDICATOR_INHERIT">CHILD_INDICATOR_INHERIT</see>
		/// means use mIndicatorRight.
		/// </remarks>
		private int mChildIndicatorRight;

		/// <summary>
		/// Denotes when a child indicator should inherit this bound from the generic
		/// indicator bounds
		/// </summary>
		public const int CHILD_INDICATOR_INHERIT = -1;

		/// <summary>The indicator drawn next to a group.</summary>
		/// <remarks>The indicator drawn next to a group.</remarks>
		private android.graphics.drawable.Drawable mGroupIndicator;

		/// <summary>The indicator drawn next to a child.</summary>
		/// <remarks>The indicator drawn next to a child.</remarks>
		private android.graphics.drawable.Drawable mChildIndicator;

		private static readonly int[] EMPTY_STATE_SET = new int[] {  };

		/// <summary>State indicating the group is expanded.</summary>
		/// <remarks>State indicating the group is expanded.</remarks>
		private static readonly int[] GROUP_EXPANDED_STATE_SET = new int[] { android.@internal.R
			.attr.state_expanded };

		/// <summary>State indicating the group is empty (has no children).</summary>
		/// <remarks>State indicating the group is empty (has no children).</remarks>
		private static readonly int[] GROUP_EMPTY_STATE_SET = new int[] { android.@internal.R
			.attr.state_empty };

		/// <summary>State indicating the group is expanded and empty (has no children).</summary>
		/// <remarks>State indicating the group is expanded and empty (has no children).</remarks>
		private static readonly int[] GROUP_EXPANDED_EMPTY_STATE_SET = new int[] { android.@internal.R
			.attr.state_expanded, android.@internal.R.attr.state_empty };

		/// <summary>States for the group where the 0th bit is expanded and 1st bit is empty.
		/// 	</summary>
		/// <remarks>States for the group where the 0th bit is expanded and 1st bit is empty.
		/// 	</remarks>
		private static readonly int[][] GROUP_STATE_SETS = new int[][] { EMPTY_STATE_SET, 
			GROUP_EXPANDED_STATE_SET, GROUP_EMPTY_STATE_SET, GROUP_EXPANDED_EMPTY_STATE_SET };

		/// <summary>State indicating the child is the last within its group.</summary>
		/// <remarks>State indicating the child is the last within its group.</remarks>
		private static readonly int[] CHILD_LAST_STATE_SET = new int[] { android.@internal.R
			.attr.state_last };

		/// <summary>Drawable to be used as a divider when it is adjacent to any children</summary>
		private android.graphics.drawable.Drawable mChildDivider;

		private readonly android.graphics.Rect mIndicatorRect = new android.graphics.Rect
			();

		public ExpandableListView(android.content.Context context) : this(context, null)
		{
		}

		public ExpandableListView(android.content.Context context, android.util.AttributeSet
			 attrs) : this(context, attrs, android.@internal.R.attr.expandableListViewStyle)
		{
		}

		public ExpandableListView(android.content.Context context, android.util.AttributeSet
			 attrs, int defStyle) : base(context, attrs, defStyle)
		{
			// 00
			// 01
			// 10
			// 11
			// Bounds of the indicator to be drawn
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.ExpandableListView, defStyle, 0);
			mGroupIndicator = a.getDrawable(android.@internal.R.styleable.ExpandableListView_groupIndicator
				);
			mChildIndicator = a.getDrawable(android.@internal.R.styleable.ExpandableListView_childIndicator
				);
			mIndicatorLeft = a.getDimensionPixelSize(android.@internal.R.styleable.ExpandableListView_indicatorLeft
				, 0);
			mIndicatorRight = a.getDimensionPixelSize(android.@internal.R.styleable.ExpandableListView_indicatorRight
				, 0);
			if (mIndicatorRight == 0 && mGroupIndicator != null)
			{
				mIndicatorRight = mIndicatorLeft + mGroupIndicator.getIntrinsicWidth();
			}
			mChildIndicatorLeft = a.getDimensionPixelSize(android.@internal.R.styleable.ExpandableListView_childIndicatorLeft
				, CHILD_INDICATOR_INHERIT);
			mChildIndicatorRight = a.getDimensionPixelSize(android.@internal.R.styleable.ExpandableListView_childIndicatorRight
				, CHILD_INDICATOR_INHERIT);
			mChildDivider = a.getDrawable(android.@internal.R.styleable.ExpandableListView_childDivider
				);
			a.recycle();
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void dispatchDraw(android.graphics.Canvas canvas)
		{
			// Draw children, etc.
			base.dispatchDraw(canvas);
			// If we have any indicators to draw, we do it here
			if ((mChildIndicator == null) && (mGroupIndicator == null))
			{
				return;
			}
			int saveCount = 0;
			bool clipToPadding = (mGroupFlags & CLIP_TO_PADDING_MASK) == CLIP_TO_PADDING_MASK;
			if (clipToPadding)
			{
				saveCount = canvas.save();
				int scrollX = mScrollX;
				int scrollY = mScrollY;
				canvas.clipRect(scrollX + mPaddingLeft, scrollY + mPaddingTop, scrollX + mRight -
					 mLeft - mPaddingRight, scrollY + mBottom - mTop - mPaddingBottom);
			}
			int headerViewsCount = getHeaderViewsCount();
			int lastChildFlPos = mItemCount - getFooterViewsCount() - headerViewsCount - 1;
			int myB = mBottom;
			android.widget.ExpandableListConnector.PositionMetadata pos;
			android.view.View item;
			android.graphics.drawable.Drawable indicator;
			int t;
			int b;
			// Start at a value that is neither child nor group
			int lastItemType = ~(android.widget.ExpandableListPosition.CHILD | android.widget.ExpandableListPosition
				.GROUP);
			android.graphics.Rect indicatorRect = mIndicatorRect;
			// The "child" mentioned in the following two lines is this
			// View's child, not referring to an expandable list's
			// notion of a child (as opposed to a group)
			int childCount = getChildCount();
			{
				int i = 0;
				int childFlPos = mFirstPosition - headerViewsCount;
				for (; i < childCount; i++, childFlPos++)
				{
					if (childFlPos < 0)
					{
						// This child is header
						continue;
					}
					else
					{
						if (childFlPos > lastChildFlPos)
						{
							// This child is footer, so are all subsequent children
							break;
						}
					}
					item = getChildAt(i);
					t = item.getTop();
					b = item.getBottom();
					// This item isn't on the screen
					if ((b < 0) || (t > myB))
					{
						continue;
					}
					// Get more expandable list-related info for this item
					pos = mConnector.getUnflattenedPos(childFlPos);
					// If this item type and the previous item type are different, then we need to change
					// the left & right bounds
					if (pos.position.type != lastItemType)
					{
						if (pos.position.type == android.widget.ExpandableListPosition.CHILD)
						{
							indicatorRect.left = (mChildIndicatorLeft == CHILD_INDICATOR_INHERIT) ? mIndicatorLeft
								 : mChildIndicatorLeft;
							indicatorRect.right = (mChildIndicatorRight == CHILD_INDICATOR_INHERIT) ? mIndicatorRight
								 : mChildIndicatorRight;
						}
						else
						{
							indicatorRect.left = mIndicatorLeft;
							indicatorRect.right = mIndicatorRight;
						}
						indicatorRect.left += mPaddingLeft;
						indicatorRect.right += mPaddingLeft;
						lastItemType = pos.position.type;
					}
					if (indicatorRect.left != indicatorRect.right)
					{
						// Use item's full height + the divider height
						if (mStackFromBottom)
						{
							// See ListView#dispatchDraw
							indicatorRect.top = t;
							// - mDividerHeight;
							indicatorRect.bottom = b;
						}
						else
						{
							indicatorRect.top = t;
							indicatorRect.bottom = b;
						}
						// + mDividerHeight;
						// Get the indicator (with its state set to the item's state)
						indicator = getIndicator(pos);
						if (indicator != null)
						{
							// Draw the indicator
							indicator.setBounds(indicatorRect);
							indicator.draw(canvas);
						}
					}
					pos.recycle();
				}
			}
			if (clipToPadding)
			{
				canvas.restoreToCount(saveCount);
			}
		}

		/// <summary>Gets the indicator for the item at the given position.</summary>
		/// <remarks>
		/// Gets the indicator for the item at the given position. If the indicator
		/// is stateful, the state will be given to the indicator.
		/// </remarks>
		/// <param name="pos">
		/// The flat list position of the item whose indicator
		/// should be returned.
		/// </param>
		/// <returns>The indicator in the proper state.</returns>
		private android.graphics.drawable.Drawable getIndicator(android.widget.ExpandableListConnector
			.PositionMetadata pos)
		{
			android.graphics.drawable.Drawable indicator;
			if (pos.position.type == android.widget.ExpandableListPosition.GROUP)
			{
				indicator = mGroupIndicator;
				if (indicator != null && indicator.isStateful())
				{
					// Empty check based on availability of data.  If the groupMetadata isn't null,
					// we do a check on it. Otherwise, the group is collapsed so we consider it
					// empty for performance reasons.
					bool isEmpty = (pos.groupMetadata == null) || (pos.groupMetadata.lastChildFlPos ==
						 pos.groupMetadata.flPos);
					int stateSetIndex = (pos.isExpanded() ? 1 : 0) | (isEmpty ? 2 : 0);
					// Expanded?
					// Empty?
					indicator.setState(GROUP_STATE_SETS[stateSetIndex]);
				}
			}
			else
			{
				indicator = mChildIndicator;
				if (indicator != null && indicator.isStateful())
				{
					// No need for a state sets array for the child since it only has two states
					int[] stateSet = pos.position.flatListPos == pos.groupMetadata.lastChildFlPos ? CHILD_LAST_STATE_SET
						 : EMPTY_STATE_SET;
					indicator.setState(stateSet);
				}
			}
			return indicator;
		}

		/// <summary>Sets the drawable that will be drawn adjacent to every child in the list.
		/// 	</summary>
		/// <remarks>
		/// Sets the drawable that will be drawn adjacent to every child in the list. This will
		/// be drawn using the same height as the normal divider (
		/// <see cref="ListView.setDivider(android.graphics.drawable.Drawable)">ListView.setDivider(android.graphics.drawable.Drawable)
		/// 	</see>
		/// ) or
		/// if it does not have an intrinsic height, the height set by
		/// <see cref="ListView.setDividerHeight(int)">ListView.setDividerHeight(int)</see>
		/// .
		/// </remarks>
		/// <param name="childDivider">The drawable to use.</param>
		public virtual void setChildDivider(android.graphics.drawable.Drawable childDivider
			)
		{
			mChildDivider = childDivider;
		}

		[Sharpen.OverridesMethod(@"android.widget.ListView")]
		internal override void drawDivider(android.graphics.Canvas canvas, android.graphics.Rect
			 bounds, int childIndex)
		{
			int flatListPosition = childIndex + mFirstPosition;
			// Only proceed as possible child if the divider isn't above all items (if it is above
			// all items, then the item below it has to be a group)
			if (flatListPosition >= 0)
			{
				int adjustedPosition = getFlatPositionForConnector(flatListPosition);
				android.widget.ExpandableListConnector.PositionMetadata pos = mConnector.getUnflattenedPos
					(adjustedPosition);
				// If this item is a child, or it is a non-empty group that is expanded
				if ((pos.position.type == android.widget.ExpandableListPosition.CHILD) || (pos.isExpanded
					() && pos.groupMetadata.lastChildFlPos != pos.groupMetadata.flPos))
				{
					// These are the cases where we draw the child divider
					android.graphics.drawable.Drawable divider = mChildDivider;
					divider.setBounds(bounds);
					divider.draw(canvas);
					pos.recycle();
					return;
				}
				pos.recycle();
			}
			// Otherwise draw the default divider
			base.drawDivider(canvas, bounds, flatListPosition);
		}

		/// <summary>
		/// This overloaded method should not be used, instead use
		/// <see cref="setAdapter(ExpandableListAdapter)">setAdapter(ExpandableListAdapter)</see>
		/// .
		/// <p>
		/// <inheritDoc></inheritDoc>
		/// </summary>
		[Sharpen.OverridesMethod(@"android.widget.AdapterView")]
		public override void setAdapter(android.widget.ListAdapter adapter)
		{
			throw new java.lang.RuntimeException("For ExpandableListView, use setAdapter(ExpandableListAdapter) instead of "
				 + "setAdapter(ListAdapter)");
		}

		/// <summary>
		/// This method should not be used, use
		/// <see cref="getExpandableListAdapter()">getExpandableListAdapter()</see>
		/// .
		/// </summary>
		[Sharpen.OverridesMethod(@"android.widget.AdapterView")]
		public override android.widget.ListAdapter getAdapter()
		{
			return base.getAdapter();
		}

		/// <summary>
		/// Register a callback to be invoked when an item has been clicked and the
		/// caller prefers to receive a ListView-style position instead of a group
		/// and/or child position.
		/// </summary>
		/// <remarks>
		/// Register a callback to be invoked when an item has been clicked and the
		/// caller prefers to receive a ListView-style position instead of a group
		/// and/or child position. In most cases, the caller should use
		/// <see cref="setOnGroupClickListener(OnGroupClickListener)">setOnGroupClickListener(OnGroupClickListener)
		/// 	</see>
		/// and/or
		/// <see cref="setOnChildClickListener(OnChildClickListener)">setOnChildClickListener(OnChildClickListener)
		/// 	</see>
		/// .
		/// <p />
		/// <inheritDoc></inheritDoc>
		/// </remarks>
		[Sharpen.OverridesMethod(@"android.widget.AdapterView")]
		public override void setOnItemClickListener(android.widget.AdapterView.OnItemClickListener
			 l)
		{
			base.setOnItemClickListener(l);
		}

		/// <summary>Sets the adapter that provides data to this view.</summary>
		/// <remarks>Sets the adapter that provides data to this view.</remarks>
		/// <param name="adapter">The adapter that provides data to this view.</param>
		public virtual void setAdapter(android.widget.ExpandableListAdapter adapter)
		{
			// Set member variable
			mAdapter = adapter;
			if (adapter != null)
			{
				// Create the connector
				mConnector = new android.widget.ExpandableListConnector(adapter);
			}
			else
			{
				mConnector = null;
			}
			// Link the ListView (superclass) to the expandable list data through the connector
			base.setAdapter(mConnector);
		}

		/// <summary>Gets the adapter that provides data to this view.</summary>
		/// <remarks>Gets the adapter that provides data to this view.</remarks>
		/// <returns>The adapter that provides data to this view.</returns>
		public virtual android.widget.ExpandableListAdapter getExpandableListAdapter()
		{
			return mAdapter;
		}

		/// <param name="position">An absolute (including header and footer) flat list position.
		/// 	</param>
		/// <returns>true if the position corresponds to a header or a footer item.</returns>
		private bool isHeaderOrFooterPosition(int position)
		{
			int footerViewsStart = mItemCount - getFooterViewsCount();
			return (position < getHeaderViewsCount() || position >= footerViewsStart);
		}

		/// <summary>
		/// Converts an absolute item flat position into a group/child flat position, shifting according
		/// to the number of header items.
		/// </summary>
		/// <remarks>
		/// Converts an absolute item flat position into a group/child flat position, shifting according
		/// to the number of header items.
		/// </remarks>
		/// <param name="flatListPosition">The absolute flat position</param>
		/// <returns>A group/child flat position as expected by the connector.</returns>
		private int getFlatPositionForConnector(int flatListPosition)
		{
			return flatListPosition - getHeaderViewsCount();
		}

		/// <summary>
		/// Converts a group/child flat position into an absolute flat position, that takes into account
		/// the possible headers.
		/// </summary>
		/// <remarks>
		/// Converts a group/child flat position into an absolute flat position, that takes into account
		/// the possible headers.
		/// </remarks>
		/// <param name="flatListPosition">The child/group flat position</param>
		/// <returns>An absolute flat position.</returns>
		private int getAbsoluteFlatPosition(int flatListPosition)
		{
			return flatListPosition + getHeaderViewsCount();
		}

		[Sharpen.OverridesMethod(@"android.widget.AdapterView")]
		public override bool performItemClick(android.view.View v, int position, long id)
		{
			// Ignore clicks in header/footers
			if (isHeaderOrFooterPosition(position))
			{
				// Clicked on a header/footer, so ignore pass it on to super
				return base.performItemClick(v, position, id);
			}
			// Internally handle the item click
			int adjustedPosition = getFlatPositionForConnector(position);
			return handleItemClick(v, adjustedPosition, id);
		}

		/// <summary>
		/// This will either expand/collapse groups (if a group was clicked) or pass
		/// on the click to the proper child (if a child was clicked)
		/// </summary>
		/// <param name="position">
		/// The flat list position. This has already been factored to
		/// remove the header/footer.
		/// </param>
		/// <param name="id">The ListAdapter ID, not the group or child ID.</param>
		internal virtual bool handleItemClick(android.view.View v, int position, long id)
		{
			android.widget.ExpandableListConnector.PositionMetadata posMetadata = mConnector.
				getUnflattenedPos(position);
			id = getChildOrGroupId(posMetadata.position);
			bool returnValue;
			if (posMetadata.position.type == android.widget.ExpandableListPosition.GROUP)
			{
				if (mOnGroupClickListener != null)
				{
					if (mOnGroupClickListener.onGroupClick(this, v, posMetadata.position.groupPos, id
						))
					{
						posMetadata.recycle();
						return true;
					}
				}
				if (posMetadata.isExpanded())
				{
					mConnector.collapseGroup(posMetadata);
					playSoundEffect(android.view.SoundEffectConstants.CLICK);
					if (mOnGroupCollapseListener != null)
					{
						mOnGroupCollapseListener.onGroupCollapse(posMetadata.position.groupPos);
					}
				}
				else
				{
					mConnector.expandGroup(posMetadata);
					playSoundEffect(android.view.SoundEffectConstants.CLICK);
					if (mOnGroupExpandListener != null)
					{
						mOnGroupExpandListener.onGroupExpand(posMetadata.position.groupPos);
					}
					int groupPos = posMetadata.position.groupPos;
					int groupFlatPos = posMetadata.position.flatListPos;
					int shiftedGroupPosition = groupFlatPos + getHeaderViewsCount();
					smoothScrollToPosition(shiftedGroupPosition + mAdapter.getChildrenCount(groupPos)
						, shiftedGroupPosition);
				}
				returnValue = true;
			}
			else
			{
				if (mOnChildClickListener != null)
				{
					playSoundEffect(android.view.SoundEffectConstants.CLICK);
					return mOnChildClickListener.onChildClick(this, v, posMetadata.position.groupPos, 
						posMetadata.position.childPos, id);
				}
				returnValue = false;
			}
			posMetadata.recycle();
			return returnValue;
		}

		/// <summary>Expand a group in the grouped list view</summary>
		/// <param name="groupPos">the group to be expanded</param>
		/// <returns>
		/// True if the group was expanded, false otherwise (if the group
		/// was already expanded, this will return false)
		/// </returns>
		public virtual bool expandGroup(int groupPos)
		{
			return expandGroup(groupPos, false);
		}

		/// <summary>Expand a group in the grouped list view</summary>
		/// <param name="groupPos">the group to be expanded</param>
		/// <param name="animate">true if the expanding group should be animated in</param>
		/// <returns>
		/// True if the group was expanded, false otherwise (if the group
		/// was already expanded, this will return false)
		/// </returns>
		public virtual bool expandGroup(int groupPos, bool animate_1)
		{
			android.widget.ExpandableListConnector.PositionMetadata pm = mConnector.getFlattenedPos
				(android.widget.ExpandableListPosition.obtain(android.widget.ExpandableListPosition
				.GROUP, groupPos, -1, -1));
			bool retValue = mConnector.expandGroup(pm);
			if (mOnGroupExpandListener != null)
			{
				mOnGroupExpandListener.onGroupExpand(groupPos);
			}
			if (animate_1)
			{
				int groupFlatPos = pm.position.flatListPos;
				int shiftedGroupPosition = groupFlatPos + getHeaderViewsCount();
				smoothScrollToPosition(shiftedGroupPosition + mAdapter.getChildrenCount(groupPos)
					, shiftedGroupPosition);
			}
			pm.recycle();
			return retValue;
		}

		/// <summary>Collapse a group in the grouped list view</summary>
		/// <param name="groupPos">position of the group to collapse</param>
		/// <returns>
		/// True if the group was collapsed, false otherwise (if the group
		/// was already collapsed, this will return false)
		/// </returns>
		public virtual bool collapseGroup(int groupPos)
		{
			bool retValue = mConnector.collapseGroup(groupPos);
			if (mOnGroupCollapseListener != null)
			{
				mOnGroupCollapseListener.onGroupCollapse(groupPos);
			}
			return retValue;
		}

		/// <summary>Used for being notified when a group is collapsed</summary>
		public interface OnGroupCollapseListener
		{
			/// <summary>
			/// Callback method to be invoked when a group in this expandable list has
			/// been collapsed.
			/// </summary>
			/// <remarks>
			/// Callback method to be invoked when a group in this expandable list has
			/// been collapsed.
			/// </remarks>
			/// <param name="groupPosition">The group position that was collapsed</param>
			void onGroupCollapse(int groupPosition);
		}

		private android.widget.ExpandableListView.OnGroupCollapseListener mOnGroupCollapseListener;

		public virtual void setOnGroupCollapseListener(android.widget.ExpandableListView.
			OnGroupCollapseListener onGroupCollapseListener)
		{
			mOnGroupCollapseListener = onGroupCollapseListener;
		}

		/// <summary>Used for being notified when a group is expanded</summary>
		public interface OnGroupExpandListener
		{
			/// <summary>
			/// Callback method to be invoked when a group in this expandable list has
			/// been expanded.
			/// </summary>
			/// <remarks>
			/// Callback method to be invoked when a group in this expandable list has
			/// been expanded.
			/// </remarks>
			/// <param name="groupPosition">The group position that was expanded</param>
			void onGroupExpand(int groupPosition);
		}

		private android.widget.ExpandableListView.OnGroupExpandListener mOnGroupExpandListener;

		public virtual void setOnGroupExpandListener(android.widget.ExpandableListView.OnGroupExpandListener
			 onGroupExpandListener)
		{
			mOnGroupExpandListener = onGroupExpandListener;
		}

		/// <summary>
		/// Interface definition for a callback to be invoked when a group in this
		/// expandable list has been clicked.
		/// </summary>
		/// <remarks>
		/// Interface definition for a callback to be invoked when a group in this
		/// expandable list has been clicked.
		/// </remarks>
		public interface OnGroupClickListener
		{
			/// <summary>
			/// Callback method to be invoked when a group in this expandable list has
			/// been clicked.
			/// </summary>
			/// <remarks>
			/// Callback method to be invoked when a group in this expandable list has
			/// been clicked.
			/// </remarks>
			/// <param name="parent">The ExpandableListConnector where the click happened</param>
			/// <param name="v">The view within the expandable list/ListView that was clicked</param>
			/// <param name="groupPosition">The group position that was clicked</param>
			/// <param name="id">The row id of the group that was clicked</param>
			/// <returns>True if the click was handled</returns>
			bool onGroupClick(android.widget.ExpandableListView parent, android.view.View v, 
				int groupPosition, long id);
		}

		private android.widget.ExpandableListView.OnGroupClickListener mOnGroupClickListener;

		public virtual void setOnGroupClickListener(android.widget.ExpandableListView.OnGroupClickListener
			 onGroupClickListener)
		{
			mOnGroupClickListener = onGroupClickListener;
		}

		/// <summary>
		/// Interface definition for a callback to be invoked when a child in this
		/// expandable list has been clicked.
		/// </summary>
		/// <remarks>
		/// Interface definition for a callback to be invoked when a child in this
		/// expandable list has been clicked.
		/// </remarks>
		public interface OnChildClickListener
		{
			/// <summary>
			/// Callback method to be invoked when a child in this expandable list has
			/// been clicked.
			/// </summary>
			/// <remarks>
			/// Callback method to be invoked when a child in this expandable list has
			/// been clicked.
			/// </remarks>
			/// <param name="parent">The ExpandableListView where the click happened</param>
			/// <param name="v">The view within the expandable list/ListView that was clicked</param>
			/// <param name="groupPosition">
			/// The group position that contains the child that
			/// was clicked
			/// </param>
			/// <param name="childPosition">The child position within the group</param>
			/// <param name="id">The row id of the child that was clicked</param>
			/// <returns>True if the click was handled</returns>
			bool onChildClick(android.widget.ExpandableListView parent, android.view.View v, 
				int groupPosition, int childPosition, long id);
		}

		private android.widget.ExpandableListView.OnChildClickListener mOnChildClickListener;

		public virtual void setOnChildClickListener(android.widget.ExpandableListView.OnChildClickListener
			 onChildClickListener)
		{
			mOnChildClickListener = onChildClickListener;
		}

		/// <summary>
		/// Converts a flat list position (the raw position of an item (child or group)
		/// in the list) to an group and/or child position (represented in a
		/// packed position).
		/// </summary>
		/// <remarks>
		/// Converts a flat list position (the raw position of an item (child or group)
		/// in the list) to an group and/or child position (represented in a
		/// packed position). This is useful in situations where the caller needs to
		/// use the underlying
		/// <see cref="ListView">ListView</see>
		/// 's methods. Use
		/// <see cref="getPackedPositionType(long)">getPackedPositionType(long)</see>
		/// ,
		/// <see cref="getPackedPositionChild(long)">getPackedPositionChild(long)</see>
		/// ,
		/// <see cref="getPackedPositionGroup(long)">getPackedPositionGroup(long)</see>
		/// to unpack.
		/// </remarks>
		/// <param name="flatListPosition">The flat list position to be converted.</param>
		/// <returns>
		/// The group and/or child position for the given flat list position
		/// in packed position representation. #PACKED_POSITION_VALUE_NULL if
		/// the position corresponds to a header or a footer item.
		/// </returns>
		public virtual long getExpandableListPosition(int flatListPosition)
		{
			if (isHeaderOrFooterPosition(flatListPosition))
			{
				return PACKED_POSITION_VALUE_NULL;
			}
			int adjustedPosition = getFlatPositionForConnector(flatListPosition);
			android.widget.ExpandableListConnector.PositionMetadata pm = mConnector.getUnflattenedPos
				(adjustedPosition);
			long packedPos = pm.position.getPackedPosition();
			pm.recycle();
			return packedPos;
		}

		/// <summary>Converts a group and/or child position to a flat list position.</summary>
		/// <remarks>
		/// Converts a group and/or child position to a flat list position. This is
		/// useful in situations where the caller needs to use the underlying
		/// <see cref="ListView">ListView</see>
		/// 's methods.
		/// </remarks>
		/// <param name="packedPosition">
		/// The group and/or child positions to be converted in
		/// packed position representation. Use
		/// <see cref="getPackedPositionForChild(int, int)">getPackedPositionForChild(int, int)
		/// 	</see>
		/// or
		/// <see cref="getPackedPositionForGroup(int)">getPackedPositionForGroup(int)</see>
		/// .
		/// </param>
		/// <returns>The flat list position for the given child or group.</returns>
		public virtual int getFlatListPosition(long packedPosition)
		{
			android.widget.ExpandableListConnector.PositionMetadata pm = mConnector.getFlattenedPos
				(android.widget.ExpandableListPosition.obtainPosition(packedPosition));
			int flatListPosition = pm.position.flatListPos;
			pm.recycle();
			return getAbsoluteFlatPosition(flatListPosition);
		}

		/// <summary>
		/// Gets the position of the currently selected group or child (along with
		/// its type).
		/// </summary>
		/// <remarks>
		/// Gets the position of the currently selected group or child (along with
		/// its type). Can return
		/// <see cref="PACKED_POSITION_VALUE_NULL">PACKED_POSITION_VALUE_NULL</see>
		/// if no selection.
		/// </remarks>
		/// <returns>
		/// A packed position containing the currently selected group or
		/// child's position and type. #PACKED_POSITION_VALUE_NULL if no selection
		/// or if selection is on a header or a footer item.
		/// </returns>
		public virtual long getSelectedPosition()
		{
			int selectedPos = getSelectedItemPosition();
			// The case where there is no selection (selectedPos == -1) is also handled here.
			return getExpandableListPosition(selectedPos);
		}

		/// <summary>Gets the ID of the currently selected group or child.</summary>
		/// <remarks>
		/// Gets the ID of the currently selected group or child. Can return -1 if no
		/// selection.
		/// </remarks>
		/// <returns>
		/// The ID of the currently selected group or child. -1 if no
		/// selection.
		/// </returns>
		public virtual long getSelectedId()
		{
			long packedPos = getSelectedPosition();
			if (packedPos == PACKED_POSITION_VALUE_NULL)
			{
				return -1;
			}
			int groupPos = getPackedPositionGroup(packedPos);
			if (getPackedPositionType(packedPos) == PACKED_POSITION_TYPE_GROUP)
			{
				// It's a group
				return mAdapter.getGroupId(groupPos);
			}
			else
			{
				// It's a child
				return mAdapter.getChildId(groupPos, getPackedPositionChild(packedPos));
			}
		}

		/// <summary>Sets the selection to the specified group.</summary>
		/// <remarks>Sets the selection to the specified group.</remarks>
		/// <param name="groupPosition">The position of the group that should be selected.</param>
		public virtual void setSelectedGroup(int groupPosition)
		{
			android.widget.ExpandableListPosition elGroupPos = android.widget.ExpandableListPosition
				.obtainGroupPosition(groupPosition);
			android.widget.ExpandableListConnector.PositionMetadata pm = mConnector.getFlattenedPos
				(elGroupPos);
			elGroupPos.recycle();
			int absoluteFlatPosition = getAbsoluteFlatPosition(pm.position.flatListPos);
			base.setSelection(absoluteFlatPosition);
			pm.recycle();
		}

		/// <summary>Sets the selection to the specified child.</summary>
		/// <remarks>
		/// Sets the selection to the specified child. If the child is in a collapsed
		/// group, the group will only be expanded and child subsequently selected if
		/// shouldExpandGroup is set to true, otherwise the method will return false.
		/// </remarks>
		/// <param name="groupPosition">The position of the group that contains the child.</param>
		/// <param name="childPosition">The position of the child within the group.</param>
		/// <param name="shouldExpandGroup">
		/// Whether the child's group should be expanded if
		/// it is collapsed.
		/// </param>
		/// <returns>Whether the selection was successfully set on the child.</returns>
		public virtual bool setSelectedChild(int groupPosition, int childPosition, bool shouldExpandGroup
			)
		{
			android.widget.ExpandableListPosition elChildPos = android.widget.ExpandableListPosition
				.obtainChildPosition(groupPosition, childPosition);
			android.widget.ExpandableListConnector.PositionMetadata flatChildPos = mConnector
				.getFlattenedPos(elChildPos);
			if (flatChildPos == null)
			{
				// The child's group isn't expanded
				// Shouldn't expand the group, so return false for we didn't set the selection
				if (!shouldExpandGroup)
				{
					return false;
				}
				expandGroup(groupPosition);
				flatChildPos = mConnector.getFlattenedPos(elChildPos);
				// Sanity check
				if (flatChildPos == null)
				{
					throw new System.InvalidOperationException("Could not find child");
				}
			}
			int absoluteFlatPosition = getAbsoluteFlatPosition(flatChildPos.position.flatListPos
				);
			base.setSelection(absoluteFlatPosition);
			elChildPos.recycle();
			flatChildPos.recycle();
			return true;
		}

		/// <summary>Whether the given group is currently expanded.</summary>
		/// <remarks>Whether the given group is currently expanded.</remarks>
		/// <param name="groupPosition">The group to check.</param>
		/// <returns>Whether the group is currently expanded.</returns>
		public virtual bool isGroupExpanded(int groupPosition)
		{
			return mConnector.isGroupExpanded(groupPosition);
		}

		/// <summary>Gets the type of a packed position.</summary>
		/// <remarks>
		/// Gets the type of a packed position. See
		/// <see cref="getPackedPositionForChild(int, int)">getPackedPositionForChild(int, int)
		/// 	</see>
		/// .
		/// </remarks>
		/// <param name="packedPosition">The packed position for which to return the type.</param>
		/// <returns>
		/// The type of the position contained within the packed position,
		/// either
		/// <see cref="PACKED_POSITION_TYPE_CHILD">PACKED_POSITION_TYPE_CHILD</see>
		/// ,
		/// <see cref="PACKED_POSITION_TYPE_GROUP">PACKED_POSITION_TYPE_GROUP</see>
		/// , or
		/// <see cref="PACKED_POSITION_TYPE_NULL">PACKED_POSITION_TYPE_NULL</see>
		/// .
		/// </returns>
		public static int getPackedPositionType(long packedPosition)
		{
			if (packedPosition == PACKED_POSITION_VALUE_NULL)
			{
				return PACKED_POSITION_TYPE_NULL;
			}
			return (packedPosition & PACKED_POSITION_MASK_TYPE) == PACKED_POSITION_MASK_TYPE ? 
				PACKED_POSITION_TYPE_CHILD : PACKED_POSITION_TYPE_GROUP;
		}

		/// <summary>Gets the group position from a packed position.</summary>
		/// <remarks>
		/// Gets the group position from a packed position. See
		/// <see cref="getPackedPositionForChild(int, int)">getPackedPositionForChild(int, int)
		/// 	</see>
		/// .
		/// </remarks>
		/// <param name="packedPosition">
		/// The packed position from which the group position
		/// will be returned.
		/// </param>
		/// <returns>
		/// The group position portion of the packed position. If this does
		/// not contain a group, returns -1.
		/// </returns>
		public static int getPackedPositionGroup(long packedPosition)
		{
			// Null
			if (packedPosition == PACKED_POSITION_VALUE_NULL)
			{
				return -1;
			}
			return (int)((packedPosition & PACKED_POSITION_MASK_GROUP) >> (int)PACKED_POSITION_SHIFT_GROUP
				);
		}

		/// <summary>
		/// Gets the child position from a packed position that is of
		/// <see cref="PACKED_POSITION_TYPE_CHILD">PACKED_POSITION_TYPE_CHILD</see>
		/// type (use
		/// <see cref="getPackedPositionType(long)">getPackedPositionType(long)</see>
		/// ).
		/// To get the group that this child belongs to, use
		/// <see cref="getPackedPositionGroup(long)">getPackedPositionGroup(long)</see>
		/// . See
		/// <see cref="getPackedPositionForChild(int, int)">getPackedPositionForChild(int, int)
		/// 	</see>
		/// .
		/// </summary>
		/// <param name="packedPosition">
		/// The packed position from which the child position
		/// will be returned.
		/// </param>
		/// <returns>
		/// The child position portion of the packed position. If this does
		/// not contain a child, returns -1.
		/// </returns>
		public static int getPackedPositionChild(long packedPosition)
		{
			// Null
			if (packedPosition == PACKED_POSITION_VALUE_NULL)
			{
				return -1;
			}
			// Group since a group type clears this bit
			if ((packedPosition & PACKED_POSITION_MASK_TYPE) != PACKED_POSITION_MASK_TYPE)
			{
				return -1;
			}
			return (int)(packedPosition & PACKED_POSITION_MASK_CHILD);
		}

		/// <summary>Returns the packed position representation of a child's position.</summary>
		/// <remarks>
		/// Returns the packed position representation of a child's position.
		/// <p>
		/// In general, a packed position should be used in
		/// situations where the position given to/returned from an
		/// <see cref="ExpandableListAdapter">ExpandableListAdapter</see>
		/// or
		/// <see cref="ExpandableListView">ExpandableListView</see>
		/// method can
		/// either be a child or group. The two positions are packed into a single
		/// long which can be unpacked using
		/// <see cref="getPackedPositionChild(long)">getPackedPositionChild(long)</see>
		/// ,
		/// <see cref="getPackedPositionGroup(long)">getPackedPositionGroup(long)</see>
		/// , and
		/// <see cref="getPackedPositionType(long)">getPackedPositionType(long)</see>
		/// .
		/// </remarks>
		/// <param name="groupPosition">The child's parent group's position.</param>
		/// <param name="childPosition">The child position within the group.</param>
		/// <returns>The packed position representation of the child (and parent group).</returns>
		public static long getPackedPositionForChild(int groupPosition, int childPosition
			)
		{
			return (((long)PACKED_POSITION_TYPE_CHILD) << (int)PACKED_POSITION_SHIFT_TYPE) | 
				((((long)groupPosition) & PACKED_POSITION_INT_MASK_GROUP) << (int)PACKED_POSITION_SHIFT_GROUP
				) | (childPosition & PACKED_POSITION_INT_MASK_CHILD);
		}

		/// <summary>Returns the packed position representation of a group's position.</summary>
		/// <remarks>
		/// Returns the packed position representation of a group's position. See
		/// <see cref="getPackedPositionForChild(int, int)">getPackedPositionForChild(int, int)
		/// 	</see>
		/// .
		/// </remarks>
		/// <param name="groupPosition">The child's parent group's position.</param>
		/// <returns>The packed position representation of the group.</returns>
		public static long getPackedPositionForGroup(int groupPosition)
		{
			// No need to OR a type in because PACKED_POSITION_GROUP == 0
			return ((((long)groupPosition) & PACKED_POSITION_INT_MASK_GROUP) << (int)PACKED_POSITION_SHIFT_GROUP
				);
		}

		[Sharpen.OverridesMethod(@"android.widget.AbsListView")]
		internal override android.view.ContextMenuClass.ContextMenuInfo createContextMenuInfo
			(android.view.View view, int flatListPosition, long id)
		{
			if (isHeaderOrFooterPosition(flatListPosition))
			{
				// Return normal info for header/footer view context menus
				return new android.widget.AdapterView.AdapterContextMenuInfo(view, flatListPosition
					, id);
			}
			int adjustedPosition = getFlatPositionForConnector(flatListPosition);
			android.widget.ExpandableListConnector.PositionMetadata pm = mConnector.getUnflattenedPos
				(adjustedPosition);
			android.widget.ExpandableListPosition pos = pm.position;
			pm.recycle();
			id = getChildOrGroupId(pos);
			long packedPosition = pos.getPackedPosition();
			pos.recycle();
			return new android.widget.ExpandableListView.ExpandableListContextMenuInfo(view, 
				packedPosition, id);
		}

		/// <summary>Gets the ID of the group or child at the given <code>position</code>.</summary>
		/// <remarks>
		/// Gets the ID of the group or child at the given <code>position</code>.
		/// This is useful since there is no ListAdapter ID -&gt; ExpandableListAdapter
		/// ID conversion mechanism (in some cases, it isn't possible).
		/// </remarks>
		/// <param name="position">
		/// The position of the child or group whose ID should be
		/// returned.
		/// </param>
		internal long getChildOrGroupId(android.widget.ExpandableListPosition position)
		{
			if (position.type == android.widget.ExpandableListPosition.CHILD)
			{
				return mAdapter.getChildId(position.groupPos, position.childPos);
			}
			else
			{
				return mAdapter.getGroupId(position.groupPos);
			}
		}

		/// <summary>Sets the indicator to be drawn next to a child.</summary>
		/// <remarks>Sets the indicator to be drawn next to a child.</remarks>
		/// <param name="childIndicator">
		/// The drawable to be used as an indicator. If the
		/// child is the last child for a group, the state
		/// <see cref="android.R.attr.state_last">android.R.attr.state_last</see>
		/// will be set.
		/// </param>
		public virtual void setChildIndicator(android.graphics.drawable.Drawable childIndicator
			)
		{
			mChildIndicator = childIndicator;
		}

		/// <summary>Sets the drawing bounds for the child indicator.</summary>
		/// <remarks>
		/// Sets the drawing bounds for the child indicator. For either, you can
		/// specify
		/// <see cref="CHILD_INDICATOR_INHERIT">CHILD_INDICATOR_INHERIT</see>
		/// to use inherit from the general
		/// indicator's bounds.
		/// </remarks>
		/// <seealso cref="setIndicatorBounds(int, int)">setIndicatorBounds(int, int)</seealso>
		/// <param name="left">
		/// The left position (relative to the left bounds of this View)
		/// to start drawing the indicator.
		/// </param>
		/// <param name="right">
		/// The right position (relative to the left bounds of this
		/// View) to end the drawing of the indicator.
		/// </param>
		public virtual void setChildIndicatorBounds(int left, int right)
		{
			mChildIndicatorLeft = left;
			mChildIndicatorRight = right;
		}

		/// <summary>Sets the indicator to be drawn next to a group.</summary>
		/// <remarks>Sets the indicator to be drawn next to a group.</remarks>
		/// <param name="groupIndicator">
		/// The drawable to be used as an indicator. If the
		/// group is empty, the state
		/// <see cref="android.R.attr.state_empty">android.R.attr.state_empty</see>
		/// will be
		/// set. If the group is expanded, the state
		/// <see cref="android.R.attr.state_expanded">android.R.attr.state_expanded</see>
		/// will be set.
		/// </param>
		public virtual void setGroupIndicator(android.graphics.drawable.Drawable groupIndicator
			)
		{
			mGroupIndicator = groupIndicator;
			if (mIndicatorRight == 0 && mGroupIndicator != null)
			{
				mIndicatorRight = mIndicatorLeft + mGroupIndicator.getIntrinsicWidth();
			}
		}

		/// <summary>
		/// Sets the drawing bounds for the indicators (at minimum, the group indicator
		/// is affected by this; the child indicator is affected by this if the
		/// child indicator bounds are set to inherit).
		/// </summary>
		/// <remarks>
		/// Sets the drawing bounds for the indicators (at minimum, the group indicator
		/// is affected by this; the child indicator is affected by this if the
		/// child indicator bounds are set to inherit).
		/// </remarks>
		/// <seealso cref="setChildIndicatorBounds(int, int)"></seealso>
		/// <param name="left">
		/// The left position (relative to the left bounds of this View)
		/// to start drawing the indicator.
		/// </param>
		/// <param name="right">
		/// The right position (relative to the left bounds of this
		/// View) to end the drawing of the indicator.
		/// </param>
		public virtual void setIndicatorBounds(int left, int right)
		{
			mIndicatorLeft = left;
			mIndicatorRight = right;
		}

		/// <summary>
		/// Extra menu information specific to an
		/// <see cref="ExpandableListView">ExpandableListView</see>
		/// provided
		/// to the
		/// <see cref="android.view.View.OnCreateContextMenuListener.onCreateContextMenu(android.view.ContextMenu, android.view.View, android.view.ContextMenuClass.ContextMenuInfo)
		/// 	"></see>
		/// callback when a context menu is brought up for this AdapterView.
		/// </summary>
		public class ExpandableListContextMenuInfo : android.view.ContextMenuClass.ContextMenuInfo
		{
			public ExpandableListContextMenuInfo(android.view.View targetView, long packedPosition
				, long id)
			{
				this.targetView = targetView;
				this.packedPosition = packedPosition;
				this.id = id;
			}

			/// <summary>The view for which the context menu is being displayed.</summary>
			/// <remarks>
			/// The view for which the context menu is being displayed. This
			/// will be one of the children Views of this
			/// <see cref="ExpandableListView">ExpandableListView</see>
			/// .
			/// </remarks>
			public android.view.View targetView;

			/// <summary>
			/// The packed position in the list represented by the adapter for which
			/// the context menu is being displayed.
			/// </summary>
			/// <remarks>
			/// The packed position in the list represented by the adapter for which
			/// the context menu is being displayed. Use the methods
			/// <see cref="ExpandableListView.getPackedPositionType(long)">ExpandableListView.getPackedPositionType(long)
			/// 	</see>
			/// ,
			/// <see cref="ExpandableListView.getPackedPositionChild(long)">ExpandableListView.getPackedPositionChild(long)
			/// 	</see>
			/// , and
			/// <see cref="ExpandableListView.getPackedPositionGroup(long)">ExpandableListView.getPackedPositionGroup(long)
			/// 	</see>
			/// to unpack this.
			/// </remarks>
			public long packedPosition;

			/// <summary>
			/// The ID of the item (group or child) for which the context menu is
			/// being displayed.
			/// </summary>
			/// <remarks>
			/// The ID of the item (group or child) for which the context menu is
			/// being displayed.
			/// </remarks>
			public long id;
		}

		[Sharpen.Stub]
		internal class SavedState : android.view.View.BaseSavedState
		{
			internal java.util.ArrayList<android.widget.ExpandableListConnector.GroupMetadata
				> expandedGroupMetadataList;

			[Sharpen.Stub]
			internal SavedState(android.os.Parcelable superState, java.util.ArrayList<android.widget.ExpandableListConnector
				.GroupMetadata> expandedGroupMetadataList) : base(superState)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			private SavedState(android.os.Parcel @in) : base(@in)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.view.AbsSavedState")]
			public override void writeToParcel(android.os.Parcel @out, int flags)
			{
				throw new System.NotImplementedException();
			}

			private sealed class _Creator_1137 : android.os.ParcelableClass.Creator<android.widget.ExpandableListView
				.SavedState>
			{
				public _Creator_1137()
				{
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.widget.ExpandableListView.SavedState createFromParcel(android.os.Parcel
					 @in)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.widget.ExpandableListView.SavedState[] newArray(int size)
				{
					throw new System.NotImplementedException();
				}
			}

			internal static readonly android.os.ParcelableClass.Creator<android.widget.ExpandableListView
				.SavedState> CREATOR = new _Creator_1137();
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override android.os.Parcelable onSaveInstanceState()
		{
			android.os.Parcelable superState = base.onSaveInstanceState();
			return new android.widget.ExpandableListView.SavedState(superState, mConnector !=
				 null ? mConnector.getExpandedGroupMetadataList() : null);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onRestoreInstanceState(android.os.Parcelable state
			)
		{
			if (!(state is android.widget.ExpandableListView.SavedState))
			{
				base.onRestoreInstanceState(state);
				return;
			}
			android.widget.ExpandableListView.SavedState ss = (android.widget.ExpandableListView
				.SavedState)state;
			base.onRestoreInstanceState(ss.getSuperState());
			if (mConnector != null && ss.expandedGroupMetadataList != null)
			{
				mConnector.setExpandedGroupMetadataList(ss.expandedGroupMetadataList);
			}
		}
	}
}

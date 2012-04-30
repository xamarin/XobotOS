using Sharpen;

namespace android.view.@internal.menu
{
	/// <hide></hide>
	[Sharpen.Sharpened]
	public class ActionMenuView : android.widget.LinearLayout, android.view.@internal.menu.MenuBuilder
		.ItemInvoker, android.view.@internal.menu.MenuView
	{
		internal const string TAG = "ActionMenuView";

		internal const int MIN_CELL_SIZE = 56;

		internal const int GENERATED_ITEM_PADDING = 4;

		private android.view.@internal.menu.MenuBuilder mMenu;

		private bool mReserveOverflow;

		private android.view.@internal.menu.ActionMenuPresenter mPresenter;

		private bool mFormatItems;

		private int mFormatItemsWidth;

		private int mMinCellSize;

		private int mGeneratedItemPadding;

		private int mMeasuredExtraWidth;

		public ActionMenuView(android.content.Context context) : this(context, null)
		{
		}

		public ActionMenuView(android.content.Context context, android.util.AttributeSet 
			attrs) : base(context, attrs)
		{
			// dips
			// dips
			setBaselineAligned(false);
			float density = context.getResources().getDisplayMetrics().density;
			mMinCellSize = (int)(MIN_CELL_SIZE * density);
			mGeneratedItemPadding = (int)(GENERATED_ITEM_PADDING * density);
		}

		public virtual void setPresenter(android.view.@internal.menu.ActionMenuPresenter 
			presenter)
		{
			mPresenter = presenter;
		}

		public virtual bool isExpandedFormat()
		{
			return mFormatItems;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onConfigurationChanged(android.content.res.Configuration
			 newConfig)
		{
			base.onConfigurationChanged(newConfig);
			mPresenter.updateMenuView(false);
			if (mPresenter != null && mPresenter.isOverflowMenuShowing())
			{
				mPresenter.hideOverflowMenu();
				mPresenter.showOverflowMenu();
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onMeasure(int widthMeasureSpec, int heightMeasureSpec
			)
		{
			// If we've been given an exact size to match, apply special formatting during layout.
			bool wasFormatted = mFormatItems;
			mFormatItems = android.view.View.MeasureSpec.getMode(widthMeasureSpec) == android.view.View
				.MeasureSpec.EXACTLY;
			if (wasFormatted != mFormatItems)
			{
				mFormatItemsWidth = 0;
			}
			// Reset this when switching modes
			// Special formatting can change whether items can fit as action buttons.
			// Kick the menu and update presenters when this changes.
			int widthSize = android.view.View.MeasureSpec.getMode(widthMeasureSpec);
			if (mFormatItems && mMenu != null && widthSize != mFormatItemsWidth)
			{
				mFormatItemsWidth = widthSize;
				mMenu.onItemsChanged(true);
			}
			if (mFormatItems)
			{
				onMeasureExactFormat(widthMeasureSpec, heightMeasureSpec);
			}
			else
			{
				base.onMeasure(widthMeasureSpec, heightMeasureSpec);
			}
		}

		private void onMeasureExactFormat(int widthMeasureSpec, int heightMeasureSpec)
		{
			// We already know the width mode is EXACTLY if we're here.
			int heightMode = android.view.View.MeasureSpec.getMode(heightMeasureSpec);
			int widthSize = android.view.View.MeasureSpec.getSize(widthMeasureSpec);
			int heightSize = android.view.View.MeasureSpec.getSize(heightMeasureSpec);
			int widthPadding = getPaddingLeft() + getPaddingRight();
			int heightPadding = getPaddingTop() + getPaddingBottom();
			widthSize -= widthPadding;
			// Divide the view into cells.
			int cellCount = widthSize / mMinCellSize;
			int cellSizeRemaining = widthSize % mMinCellSize;
			if (cellCount == 0)
			{
				// Give up, nothing fits.
				setMeasuredDimension(widthSize, 0);
				return;
			}
			int cellSize = mMinCellSize + cellSizeRemaining / cellCount;
			int cellsRemaining = cellCount;
			int maxChildHeight = 0;
			int maxCellsUsed = 0;
			int expandableItemCount = 0;
			int visibleItemCount = 0;
			bool hasOverflow = false;
			// This is used as a bitfield to locate the smallest items present. Assumes childCount < 64.
			long smallestItemsAt = 0;
			int childCount = getChildCount();
			{
				for (int i = 0; i < childCount; i++)
				{
					android.view.View child = getChildAt(i);
					if (child.getVisibility() == GONE)
					{
						continue;
					}
					bool isGeneratedItem = child is android.view.@internal.menu.ActionMenuItemView;
					visibleItemCount++;
					if (isGeneratedItem)
					{
						// Reset padding for generated menu item views; it may change below
						// and views are recycled.
						child.setPadding(mGeneratedItemPadding, 0, mGeneratedItemPadding, 0);
					}
					android.view.@internal.menu.ActionMenuView.LayoutParams lp = (android.view.@internal.menu.ActionMenuView
						.LayoutParams)child.getLayoutParams();
					lp.expanded = false;
					lp.extraPixels = 0;
					lp.cellsUsed = 0;
					lp.expandable = false;
					lp.leftMargin = 0;
					lp.rightMargin = 0;
					lp.preventEdgeOffset = isGeneratedItem && ((android.view.@internal.menu.ActionMenuItemView
						)child).hasText();
					// Overflow always gets 1 cell. No more, no less.
					int cellsAvailable = lp.isOverflowButton ? 1 : cellsRemaining;
					int cellsUsed = measureChildForCells(child, cellSize, cellsAvailable, heightMeasureSpec
						, heightPadding);
					maxCellsUsed = System.Math.Max(maxCellsUsed, cellsUsed);
					if (lp.expandable)
					{
						expandableItemCount++;
					}
					if (lp.isOverflowButton)
					{
						hasOverflow = true;
					}
					cellsRemaining -= cellsUsed;
					maxChildHeight = System.Math.Max(maxChildHeight, child.getMeasuredHeight());
					if (cellsUsed == 1)
					{
						smallestItemsAt |= (1 << i);
					}
				}
			}
			// When we have overflow and a single expanded (text) item, we want to try centering it
			// visually in the available space even though overflow consumes some of it.
			bool centerSingleExpandedItem = hasOverflow && visibleItemCount == 2;
			// Divide space for remaining cells if we have items that can expand.
			// Try distributing whole leftover cells to smaller items first.
			bool needsExpansion = false;
			while (expandableItemCount > 0 && cellsRemaining > 0)
			{
				int minCells = int.MaxValue;
				long minCellsAt = 0;
				// Bit locations are indices of relevant child views
				int minCellsItemCount = 0;
				{
					for (int i_1 = 0; i_1 < childCount; i_1++)
					{
						android.view.View child = getChildAt(i_1);
						android.view.@internal.menu.ActionMenuView.LayoutParams lp = (android.view.@internal.menu.ActionMenuView
							.LayoutParams)child.getLayoutParams();
						// Don't try to expand items that shouldn't.
						if (!lp.expandable)
						{
							continue;
						}
						// Mark indices of children that can receive an extra cell.
						if (lp.cellsUsed < minCells)
						{
							minCells = lp.cellsUsed;
							minCellsAt = 1 << i_1;
							minCellsItemCount = 1;
						}
						else
						{
							if (lp.cellsUsed == minCells)
							{
								minCellsAt |= 1 << i_1;
								minCellsItemCount++;
							}
						}
					}
				}
				// Items that get expanded will always be in the set of smallest items when we're done.
				smallestItemsAt |= minCellsAt;
				if (minCellsItemCount > cellsRemaining)
				{
					break;
				}
				// Couldn't expand anything evenly. Stop.
				// We have enough cells, all minimum size items will be incremented.
				minCells++;
				{
					for (int i_2 = 0; i_2 < childCount; i_2++)
					{
						android.view.View child = getChildAt(i_2);
						android.view.@internal.menu.ActionMenuView.LayoutParams lp = (android.view.@internal.menu.ActionMenuView
							.LayoutParams)child.getLayoutParams();
						if ((minCellsAt & (1 << i_2)) == 0)
						{
							// If this item is already at our small item count, mark it for later.
							if (lp.cellsUsed == minCells)
							{
								smallestItemsAt |= 1 << i_2;
							}
							continue;
						}
						if (centerSingleExpandedItem && lp.preventEdgeOffset && cellsRemaining == 1)
						{
							// Add padding to this item such that it centers.
							child.setPadding(mGeneratedItemPadding + cellSize, 0, mGeneratedItemPadding, 0);
						}
						lp.cellsUsed++;
						lp.expanded = true;
						cellsRemaining--;
					}
				}
				needsExpansion = true;
			}
			// Divide any space left that wouldn't divide along cell boundaries
			// evenly among the smallest items
			bool singleItem = !hasOverflow && visibleItemCount == 1;
			if (cellsRemaining > 0 && smallestItemsAt != 0 && (cellsRemaining < visibleItemCount
				 - 1 || singleItem || maxCellsUsed > 1))
			{
				float expandCount = Sharpen.Util.Long_GetBitCount(smallestItemsAt);
				if (!singleItem)
				{
					// The items at the far edges may only expand by half in order to pin to either side.
					if ((smallestItemsAt & 1) != 0)
					{
						android.view.@internal.menu.ActionMenuView.LayoutParams lp = (android.view.@internal.menu.ActionMenuView
							.LayoutParams)getChildAt(0).getLayoutParams();
						if (!lp.preventEdgeOffset)
						{
							expandCount -= 0.5f;
						}
					}
					if ((smallestItemsAt & (1 << (childCount - 1))) != 0)
					{
						android.view.@internal.menu.ActionMenuView.LayoutParams lp = ((android.view.@internal.menu.ActionMenuView
							.LayoutParams)getChildAt(childCount - 1).getLayoutParams());
						if (!lp.preventEdgeOffset)
						{
							expandCount -= 0.5f;
						}
					}
				}
				int extraPixels = expandCount > 0 ? (int)(cellsRemaining * cellSize / expandCount
					) : 0;
				{
					for (int i_1 = 0; i_1 < childCount; i_1++)
					{
						if ((smallestItemsAt & (1 << i_1)) == 0)
						{
							continue;
						}
						android.view.View child = getChildAt(i_1);
						android.view.@internal.menu.ActionMenuView.LayoutParams lp = (android.view.@internal.menu.ActionMenuView
							.LayoutParams)child.getLayoutParams();
						if (child is android.view.@internal.menu.ActionMenuItemView)
						{
							// If this is one of our views, expand and measure at the larger size.
							lp.extraPixels = extraPixels;
							lp.expanded = true;
							if (i_1 == 0 && !lp.preventEdgeOffset)
							{
								// First item gets part of its new padding pushed out of sight.
								// The last item will get this implicitly from layout.
								lp.leftMargin = -extraPixels / 2;
							}
							needsExpansion = true;
						}
						else
						{
							if (lp.isOverflowButton)
							{
								lp.extraPixels = extraPixels;
								lp.expanded = true;
								lp.rightMargin = -extraPixels / 2;
								needsExpansion = true;
							}
							else
							{
								// If we don't know what it is, give it some margins instead
								// and let it center within its space. We still want to pin
								// against the edges.
								if (i_1 != 0)
								{
									lp.leftMargin = extraPixels / 2;
								}
								if (i_1 != childCount - 1)
								{
									lp.rightMargin = extraPixels / 2;
								}
							}
						}
					}
				}
				cellsRemaining = 0;
			}
			// Remeasure any items that have had extra space allocated to them.
			if (needsExpansion)
			{
				int heightSpec = android.view.View.MeasureSpec.makeMeasureSpec(heightSize - heightPadding
					, heightMode);
				{
					for (int i_1 = 0; i_1 < childCount; i_1++)
					{
						android.view.View child = getChildAt(i_1);
						android.view.@internal.menu.ActionMenuView.LayoutParams lp = (android.view.@internal.menu.ActionMenuView
							.LayoutParams)child.getLayoutParams();
						if (!lp.expanded)
						{
							continue;
						}
						int width = lp.cellsUsed * cellSize + lp.extraPixels;
						child.measure(android.view.View.MeasureSpec.makeMeasureSpec(width, android.view.View
							.MeasureSpec.EXACTLY), heightSpec);
					}
				}
			}
			if (heightMode != android.view.View.MeasureSpec.EXACTLY)
			{
				heightSize = maxChildHeight;
			}
			setMeasuredDimension(widthSize, heightSize);
			mMeasuredExtraWidth = cellsRemaining * cellSize;
		}

		/// <summary>Measure a child view to fit within cell-based formatting.</summary>
		/// <remarks>
		/// Measure a child view to fit within cell-based formatting. The child's width
		/// will be measured to a whole multiple of cellSize.
		/// <p>Sets the expandable and cellsUsed fields of LayoutParams.
		/// </remarks>
		/// <param name="child">Child to measure</param>
		/// <param name="cellSize">Size of one cell</param>
		/// <param name="cellsRemaining">Number of cells remaining that this view can expand to fill
		/// 	</param>
		/// <param name="parentHeightMeasureSpec">MeasureSpec used by the parent view</param>
		/// <param name="parentHeightPadding">Padding present in the parent view</param>
		/// <returns>Number of cells this child was measured to occupy</returns>
		internal static int measureChildForCells(android.view.View child, int cellSize, int
			 cellsRemaining, int parentHeightMeasureSpec, int parentHeightPadding)
		{
			android.view.@internal.menu.ActionMenuView.LayoutParams lp = (android.view.@internal.menu.ActionMenuView
				.LayoutParams)child.getLayoutParams();
			int childHeightSize = android.view.View.MeasureSpec.getSize(parentHeightMeasureSpec
				) - parentHeightPadding;
			int childHeightMode = android.view.View.MeasureSpec.getMode(parentHeightMeasureSpec
				);
			int childHeightSpec = android.view.View.MeasureSpec.makeMeasureSpec(childHeightSize
				, childHeightMode);
			int cellsUsed = 0;
			if (cellsRemaining > 0)
			{
				int childWidthSpec = android.view.View.MeasureSpec.makeMeasureSpec(cellSize * cellsRemaining
					, android.view.View.MeasureSpec.AT_MOST);
				child.measure(childWidthSpec, childHeightSpec);
				int measuredWidth = child.getMeasuredWidth();
				cellsUsed = measuredWidth / cellSize;
				if (measuredWidth % cellSize != 0)
				{
					cellsUsed++;
				}
			}
			android.view.@internal.menu.ActionMenuItemView itemView = child is android.view.@internal.menu.ActionMenuItemView
				 ? (android.view.@internal.menu.ActionMenuItemView)child : null;
			bool expandable = !lp.isOverflowButton && itemView != null && itemView.hasText();
			lp.expandable = expandable;
			lp.cellsUsed = cellsUsed;
			int targetWidth = cellsUsed * cellSize;
			child.measure(android.view.View.MeasureSpec.makeMeasureSpec(targetWidth, android.view.View
				.MeasureSpec.EXACTLY), childHeightSpec);
			return cellsUsed;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onLayout(bool changed, int left, int top, int right
			, int bottom)
		{
			if (!mFormatItems)
			{
				base.onLayout(changed, left, top, right, bottom);
				return;
			}
			int childCount = getChildCount();
			int midVertical = (top + bottom) / 2;
			int dividerWidth = getDividerWidth();
			int overflowWidth = 0;
			int nonOverflowWidth = 0;
			int nonOverflowCount = 0;
			int widthRemaining = right - left - getPaddingRight() - getPaddingLeft();
			bool hasOverflow = false;
			{
				for (int i = 0; i < childCount; i++)
				{
					android.view.View v = getChildAt(i);
					if (v.getVisibility() == GONE)
					{
						continue;
					}
					android.view.@internal.menu.ActionMenuView.LayoutParams p = (android.view.@internal.menu.ActionMenuView
						.LayoutParams)v.getLayoutParams();
					if (p.isOverflowButton)
					{
						overflowWidth = v.getMeasuredWidth();
						if (hasDividerBeforeChildAt(i))
						{
							overflowWidth += dividerWidth;
						}
						int height = v.getMeasuredHeight();
						int r = getWidth() - getPaddingRight() - p.rightMargin;
						int l = r - overflowWidth;
						int t = midVertical - (height / 2);
						int b = t + height;
						v.layout(l, t, r, b);
						widthRemaining -= overflowWidth;
						hasOverflow = true;
					}
					else
					{
						int size = v.getMeasuredWidth() + p.leftMargin + p.rightMargin;
						nonOverflowWidth += size;
						widthRemaining -= size;
						if (hasDividerBeforeChildAt(i))
						{
							nonOverflowWidth += dividerWidth;
						}
						nonOverflowCount++;
					}
				}
			}
			if (childCount == 1 && !hasOverflow)
			{
				// Center a single child
				android.view.View v = getChildAt(0);
				int width = v.getMeasuredWidth();
				int height = v.getMeasuredHeight();
				int midHorizontal = (right - left) / 2;
				int l = midHorizontal - width / 2;
				int t = midVertical - height / 2;
				v.layout(l, t, l + width, t + height);
				return;
			}
			int spacerCount = nonOverflowCount - (hasOverflow ? 0 : 1);
			int spacerSize = System.Math.Max(0, spacerCount > 0 ? widthRemaining / spacerCount
				 : 0);
			int startLeft = getPaddingLeft();
			{
				for (int i_1 = 0; i_1 < childCount; i_1++)
				{
					android.view.View v = getChildAt(i_1);
					android.view.@internal.menu.ActionMenuView.LayoutParams lp = (android.view.@internal.menu.ActionMenuView
						.LayoutParams)v.getLayoutParams();
					if (v.getVisibility() == GONE || lp.isOverflowButton)
					{
						continue;
					}
					startLeft += lp.leftMargin;
					int width = v.getMeasuredWidth();
					int height = v.getMeasuredHeight();
					int t = midVertical - height / 2;
					v.layout(startLeft, t, startLeft + width, t + height);
					startLeft += width + lp.rightMargin + spacerSize;
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onDetachedFromWindow()
		{
			base.onDetachedFromWindow();
			mPresenter.dismissPopupMenus();
		}

		public virtual bool isOverflowReserved()
		{
			return mReserveOverflow;
		}

		public virtual void setOverflowReserved(bool reserveOverflow)
		{
			mReserveOverflow = reserveOverflow;
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		protected internal override android.view.ViewGroup.LayoutParams generateDefaultLayoutParams
			()
		{
			android.view.@internal.menu.ActionMenuView.LayoutParams @params = new android.view.@internal.menu.ActionMenuView
				.LayoutParams(android.view.ViewGroup.LayoutParams.WRAP_CONTENT, android.view.ViewGroup
				.LayoutParams.WRAP_CONTENT);
			@params.gravity = android.view.Gravity.CENTER_VERTICAL;
			return @params;
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override android.view.ViewGroup.LayoutParams generateLayoutParams(android.util.AttributeSet
			 attrs)
		{
			return new android.view.@internal.menu.ActionMenuView.LayoutParams(getContext(), 
				attrs);
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		protected internal override android.view.ViewGroup.LayoutParams generateLayoutParams
			(android.view.ViewGroup.LayoutParams p)
		{
			if (p is android.view.@internal.menu.ActionMenuView.LayoutParams)
			{
				android.view.@internal.menu.ActionMenuView.LayoutParams result = new android.view.@internal.menu.ActionMenuView
					.LayoutParams((android.view.@internal.menu.ActionMenuView.LayoutParams)p);
				if (result.gravity <= android.view.Gravity.NO_GRAVITY)
				{
					result.gravity = android.view.Gravity.CENTER_VERTICAL;
				}
				return result;
			}
			return ((android.view.@internal.menu.ActionMenuView.LayoutParams)generateDefaultLayoutParams
				());
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		protected internal override bool checkLayoutParams(android.view.ViewGroup.LayoutParams
			 p)
		{
			return p != null && p is android.view.@internal.menu.ActionMenuView.LayoutParams;
		}

		public virtual android.view.@internal.menu.ActionMenuView.LayoutParams generateOverflowButtonLayoutParams
			()
		{
			android.view.@internal.menu.ActionMenuView.LayoutParams result = ((android.view.@internal.menu.ActionMenuView
				.LayoutParams)generateDefaultLayoutParams());
			result.isOverflowButton = true;
			return result;
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuBuilder.ItemInvoker"
			)]
		public virtual bool invokeItem(android.view.@internal.menu.MenuItemImpl item)
		{
			return mMenu.performItemAction(item, 0);
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuView")]
		public virtual int getWindowAnimations()
		{
			return 0;
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuView")]
		public virtual void initialize(android.view.@internal.menu.MenuBuilder menu)
		{
			mMenu = menu;
		}

		[Sharpen.OverridesMethod(@"android.widget.LinearLayout")]
		protected internal override bool hasDividerBeforeChildAt(int childIndex)
		{
			android.view.View childBefore = getChildAt(childIndex - 1);
			android.view.View child = getChildAt(childIndex);
			bool result = false;
			if (childIndex < getChildCount() && childBefore is android.view.@internal.menu.ActionMenuView
				.ActionMenuChildView)
			{
				result |= ((android.view.@internal.menu.ActionMenuView.ActionMenuChildView)childBefore
					).needsDividerAfter();
			}
			if (childIndex > 0 && child is android.view.@internal.menu.ActionMenuView.ActionMenuChildView)
			{
				result |= ((android.view.@internal.menu.ActionMenuView.ActionMenuChildView)child)
					.needsDividerBefore();
			}
			return result;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool dispatchPopulateAccessibilityEvent(android.view.accessibility.AccessibilityEvent
			 @event)
		{
			return false;
		}

		public interface ActionMenuChildView
		{
			bool needsDividerBefore();

			bool needsDividerAfter();
		}

		public class LayoutParams : android.widget.LinearLayout.LayoutParams
		{
			public bool isOverflowButton;

			public int cellsUsed;

			public int extraPixels;

			public bool expandable;

			public bool preventEdgeOffset;

			public bool expanded;

			public LayoutParams(android.content.Context c, android.util.AttributeSet attrs) : 
				base(c, attrs)
			{
			}

			public LayoutParams(android.view.@internal.menu.ActionMenuView.LayoutParams other
				) : base((android.widget.LinearLayout.LayoutParams)other)
			{
				isOverflowButton = other.isOverflowButton;
			}

			public LayoutParams(int width, int height) : base(width, height)
			{
				isOverflowButton = false;
			}

			public LayoutParams(int width, int height, bool isOverflowButton) : base(width, height
				)
			{
				this.isOverflowButton = isOverflowButton;
			}
		}
	}
}

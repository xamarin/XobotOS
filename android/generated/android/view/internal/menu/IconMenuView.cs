using Sharpen;

namespace android.view.@internal.menu
{
	/// <summary>The icon menu view is an icon-based menu usually with a subset of all the menu items.
	/// 	</summary>
	/// <remarks>
	/// The icon menu view is an icon-based menu usually with a subset of all the menu items.
	/// It is opened as the default menu, and shows either the first five or all six of the menu items
	/// with text and icon.  In the situation of there being more than six items, the first five items
	/// will be accompanied with a 'More' button that opens an
	/// <see cref="ExpandedMenuView">ExpandedMenuView</see>
	/// which lists
	/// all the menu items.
	/// </remarks>
	/// <attr>ref android.R.styleable#IconMenuView_rowHeight</attr>
	/// <attr>ref android.R.styleable#IconMenuView_maxRows</attr>
	/// <attr>ref android.R.styleable#IconMenuView_maxItemsPerRow</attr>
	/// <hide></hide>
	[Sharpen.Sharpened]
	public sealed class IconMenuView : android.view.ViewGroup, android.view.@internal.menu.MenuBuilder
		.ItemInvoker, android.view.@internal.menu.MenuView, java.lang.Runnable
	{
		internal const int ITEM_CAPTION_CYCLE_DELAY = 1000;

		private android.view.@internal.menu.MenuBuilder mMenu;

		/// <summary>Height of each row</summary>
		private int mRowHeight;

		/// <summary>Maximum number of rows to be shown</summary>
		private int mMaxRows;

		/// <summary>Maximum number of items to show in the icon menu.</summary>
		/// <remarks>Maximum number of items to show in the icon menu.</remarks>
		private int mMaxItems;

		/// <summary>Maximum number of items per row</summary>
		private int mMaxItemsPerRow;

		/// <summary>Actual number of items (the 'More' view does not count as an item) shown
		/// 	</summary>
		private int mNumActualItemsShown;

		/// <summary>Divider that is drawn between all rows</summary>
		private android.graphics.drawable.Drawable mHorizontalDivider;

		/// <summary>Height of the horizontal divider</summary>
		private int mHorizontalDividerHeight;

		/// <summary>Set of horizontal divider positions where the horizontal divider will be drawn
		/// 	</summary>
		private java.util.ArrayList<android.graphics.Rect> mHorizontalDividerRects;

		/// <summary>Divider that is drawn between all columns</summary>
		private android.graphics.drawable.Drawable mVerticalDivider;

		/// <summary>Width of the vertical divider</summary>
		private int mVerticalDividerWidth;

		/// <summary>Set of vertical divider positions where the vertical divider will be drawn
		/// 	</summary>
		private java.util.ArrayList<android.graphics.Rect> mVerticalDividerRects;

		/// <summary>Icon for the 'More' button</summary>
		private android.graphics.drawable.Drawable mMoreIcon;

		/// <summary>Background of each item (should contain the selected and focused states)
		/// 	</summary>
		private android.graphics.drawable.Drawable mItemBackground;

		/// <summary>Default animations for this menu</summary>
		private int mAnimations;

		/// <summary>Whether this IconMenuView has stale children and needs to update them.</summary>
		/// <remarks>
		/// Whether this IconMenuView has stale children and needs to update them.
		/// Set true by
		/// <see cref="markStaleChildren()">markStaleChildren()</see>
		/// and reset to false by
		/// <see cref="onMeasure(int, int)">onMeasure(int, int)</see>
		/// </remarks>
		private bool mHasStaleChildren;

		/// <summary>
		/// Longpress on MENU (while this is shown) switches to shortcut caption
		/// mode.
		/// </summary>
		/// <remarks>
		/// Longpress on MENU (while this is shown) switches to shortcut caption
		/// mode. When the user releases the longpress, we do not want to pass the
		/// key-up event up since that will dismiss the menu.
		/// </remarks>
		private bool mMenuBeingLongpressed = false;

		/// <summary>
		/// While
		/// <see cref="mMenuBeingLongpressed">mMenuBeingLongpressed</see>
		/// , we toggle the children's caption
		/// mode between each's title and its shortcut. This is the last caption mode
		/// we broadcasted to children.
		/// </summary>
		private bool mLastChildrenCaptionMode;

		/// <summary>The layout to use for menu items.</summary>
		/// <remarks>
		/// The layout to use for menu items. Each index is the row number (0 is the
		/// top-most). Each value contains the number of items in that row.
		/// <p>
		/// The length of this array should not be used to get the number of rows in
		/// the current layout, instead use
		/// <see cref="mLayoutNumRows">mLayoutNumRows</see>
		/// .
		/// </remarks>
		private int[] mLayout;

		/// <summary>The number of rows in the current layout.</summary>
		/// <remarks>The number of rows in the current layout.</remarks>
		private int mLayoutNumRows;

		/// <summary>Instantiates the IconMenuView that is linked with the provided MenuBuilder.
		/// 	</summary>
		/// <remarks>Instantiates the IconMenuView that is linked with the provided MenuBuilder.
		/// 	</remarks>
		public IconMenuView(android.content.Context context, android.util.AttributeSet attrs
			) : base(context, attrs)
		{
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.IconMenuView, 0, 0);
			mRowHeight = a.getDimensionPixelSize(android.@internal.R.styleable.IconMenuView_rowHeight
				, 64);
			mMaxRows = a.getInt(android.@internal.R.styleable.IconMenuView_maxRows, 2);
			mMaxItems = a.getInt(android.@internal.R.styleable.IconMenuView_maxItems, 6);
			mMaxItemsPerRow = a.getInt(android.@internal.R.styleable.IconMenuView_maxItemsPerRow
				, 3);
			mMoreIcon = a.getDrawable(android.@internal.R.styleable.IconMenuView_moreIcon);
			a.recycle();
			a = context.obtainStyledAttributes(attrs, android.@internal.R.styleable.MenuView, 
				0, 0);
			mItemBackground = a.getDrawable(android.@internal.R.styleable.MenuView_itemBackground
				);
			mHorizontalDivider = a.getDrawable(android.@internal.R.styleable.MenuView_horizontalDivider
				);
			mHorizontalDividerRects = new java.util.ArrayList<android.graphics.Rect>();
			mVerticalDivider = a.getDrawable(android.@internal.R.styleable.MenuView_verticalDivider
				);
			mVerticalDividerRects = new java.util.ArrayList<android.graphics.Rect>();
			mAnimations = a.getResourceId(android.@internal.R.styleable.MenuView_windowAnimationStyle
				, 0);
			a.recycle();
			if (mHorizontalDivider != null)
			{
				mHorizontalDividerHeight = mHorizontalDivider.getIntrinsicHeight();
				// Make sure to have some height for the divider
				if (mHorizontalDividerHeight == -1)
				{
					mHorizontalDividerHeight = 1;
				}
			}
			if (mVerticalDivider != null)
			{
				mVerticalDividerWidth = mVerticalDivider.getIntrinsicWidth();
				// Make sure to have some width for the divider
				if (mVerticalDividerWidth == -1)
				{
					mVerticalDividerWidth = 1;
				}
			}
			mLayout = new int[mMaxRows];
			// This view will be drawing the dividers        
			setWillNotDraw(false);
			// This is so we'll receive the MENU key in touch mode
			setFocusableInTouchMode(true);
			// This is so our children can still be arrow-key focused
			setDescendantFocusability(FOCUS_AFTER_DESCENDANTS);
		}

		internal int getMaxItems()
		{
			return mMaxItems;
		}

		/// <summary>Figures out the layout for the menu items.</summary>
		/// <remarks>Figures out the layout for the menu items.</remarks>
		/// <param name="width">The available width for the icon menu.</param>
		private void layoutItems(int width)
		{
			int numItems = getChildCount();
			if (numItems == 0)
			{
				mLayoutNumRows = 0;
				return;
			}
			// Start with the least possible number of rows
			int curNumRows = System.Math.Min((int)System.Math.Ceiling(numItems / (float)mMaxItemsPerRow
				), mMaxRows);
			for (; curNumRows <= mMaxRows; curNumRows++)
			{
				layoutItemsUsingGravity(curNumRows, numItems);
				if (curNumRows >= numItems)
				{
					// Can't have more rows than items
					break;
				}
				if (doItemsFit())
				{
					// All the items fit, so this is a good configuration
					break;
				}
			}
		}

		/// <summary>
		/// Figures out the layout for the menu items by equally distributing, and
		/// adding any excess items equally to lower rows.
		/// </summary>
		/// <remarks>
		/// Figures out the layout for the menu items by equally distributing, and
		/// adding any excess items equally to lower rows.
		/// </remarks>
		/// <param name="numRows">The total number of rows for the menu view</param>
		/// <param name="numItems">
		/// The total number of items (across all rows) contained in
		/// the menu view
		/// </param>
		/// <returns>int[] Where the value of index i contains the number of items for row i</returns>
		private void layoutItemsUsingGravity(int numRows, int numItems)
		{
			int numBaseItemsPerRow = numItems / numRows;
			int numLeftoverItems = numItems % numRows;
			int rowsThatGetALeftoverItem = numRows - numLeftoverItems;
			int[] layout_1 = mLayout;
			{
				for (int i = 0; i < numRows; i++)
				{
					layout_1[i] = numBaseItemsPerRow;
					// Fill the bottom rows with a leftover item each
					if (i >= rowsThatGetALeftoverItem)
					{
						layout_1[i]++;
					}
				}
			}
			mLayoutNumRows = numRows;
		}

		/// <summary>
		/// Checks whether each item's title is fully visible using the current
		/// layout.
		/// </summary>
		/// <remarks>
		/// Checks whether each item's title is fully visible using the current
		/// layout.
		/// </remarks>
		/// <returns>
		/// True if the items fit (each item's text is fully visible), false
		/// otherwise.
		/// </returns>
		private bool doItemsFit()
		{
			int itemPos = 0;
			int[] layout_1 = mLayout;
			int numRows = mLayoutNumRows;
			{
				for (int row = 0; row < numRows; row++)
				{
					int numItemsOnRow = layout_1[row];
					if (numItemsOnRow == 1)
					{
						itemPos++;
						continue;
					}
					{
						for (int itemsOnRowCounter = numItemsOnRow; itemsOnRowCounter > 0; itemsOnRowCounter
							--)
						{
							android.view.View child = getChildAt(itemPos++);
							android.view.@internal.menu.IconMenuView.LayoutParams lp = (android.view.@internal.menu.IconMenuView
								.LayoutParams)child.getLayoutParams();
							if (lp.maxNumItemsOnRow < numItemsOnRow)
							{
								return false;
							}
						}
					}
				}
			}
			return true;
		}

		internal android.graphics.drawable.Drawable getItemBackgroundDrawable()
		{
			return mItemBackground.getConstantState().newDrawable(getContext().getResources()
				);
		}

		private sealed class _OnClickListener_303 : android.view.View.OnClickListener
		{
			public _OnClickListener_303(IconMenuView _enclosing)
			{
				this._enclosing = _enclosing;
			}

			// Set up a click listener on the view since there will be no invocation sequence
			// due to the lack of a MenuItemData this view
			[Sharpen.ImplementsInterface(@"android.view.View.OnClickListener")]
			public void onClick(android.view.View v)
			{
				// Switches the menu to expanded mode. Requires support from
				// the menu's active callback.
				this._enclosing.mMenu.changeMenuMode();
			}

			private readonly IconMenuView _enclosing;
		}

		/// <summary>
		/// Creates the item view for the 'More' button which is used to switch to
		/// the expanded menu view.
		/// </summary>
		/// <remarks>
		/// Creates the item view for the 'More' button which is used to switch to
		/// the expanded menu view. This button is a special case since it does not
		/// have a MenuItemData backing it.
		/// </remarks>
		/// <returns>The IconMenuItemView for the 'More' button</returns>
		internal android.view.@internal.menu.IconMenuItemView createMoreItemView()
		{
			android.content.Context context = getContext();
			android.view.LayoutInflater inflater = android.view.LayoutInflater.from(context);
			android.view.@internal.menu.IconMenuItemView itemView = (android.view.@internal.menu.IconMenuItemView
				)inflater.inflate(android.@internal.R.layout.icon_menu_item_layout, null);
			android.content.res.Resources r = context.getResources();
			itemView.initialize(r.getText(android.@internal.R.@string.more_item_label), mMoreIcon
				);
			itemView.setOnClickListener(new _OnClickListener_303(this));
			return itemView;
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuView")]
		public void initialize(android.view.@internal.menu.MenuBuilder menu)
		{
			mMenu = menu;
		}

		/// <summary>The positioning algorithm that gets called from onMeasure.</summary>
		/// <remarks>
		/// The positioning algorithm that gets called from onMeasure.  It
		/// just computes positions for each child, and then stores them in the child's layout params.
		/// </remarks>
		/// <param name="menuWidth">The width of this menu to assume for positioning</param>
		/// <param name="menuHeight">The height of this menu to assume for positioning</param>
		private void positionChildren(int menuWidth, int menuHeight)
		{
			// Clear the containers for the positions where the dividers should be drawn
			if (mHorizontalDivider != null)
			{
				mHorizontalDividerRects.clear();
			}
			if (mVerticalDivider != null)
			{
				mVerticalDividerRects.clear();
			}
			// Get the minimum number of rows needed
			int numRows = mLayoutNumRows;
			int numRowsMinus1 = numRows - 1;
			int[] numItemsForRow = mLayout;
			// The item position across all rows
			int itemPos = 0;
			android.view.View child;
			android.view.@internal.menu.IconMenuView.LayoutParams childLayoutParams = null;
			// Use float for this to get precise positions (uniform item widths
			// instead of last one taking any slack), and then convert to ints at last opportunity
			float itemLeft;
			float itemTop = 0;
			// Since each row can have a different number of items, this will be computed per row
			float itemWidth;
			// Subtract the space needed for the horizontal dividers
			float itemHeight = (menuHeight - mHorizontalDividerHeight * (numRows - 1)) / (float
				)numRows;
			{
				for (int row = 0; row < numRows; row++)
				{
					// Start at the left
					itemLeft = 0;
					// Subtract the space needed for the vertical dividers, and divide by the number of items
					itemWidth = (menuWidth - mVerticalDividerWidth * (numItemsForRow[row] - 1)) / (float
						)numItemsForRow[row];
					{
						for (int itemPosOnRow = 0; itemPosOnRow < numItemsForRow[row]; itemPosOnRow++)
						{
							// Tell the child to be exactly this size
							child = getChildAt(itemPos);
							child.measure(android.view.View.MeasureSpec.makeMeasureSpec((int)itemWidth, android.view.View
								.MeasureSpec.EXACTLY), android.view.View.MeasureSpec.makeMeasureSpec((int)itemHeight
								, android.view.View.MeasureSpec.EXACTLY));
							// Remember the child's position for layout
							childLayoutParams = (android.view.@internal.menu.IconMenuView.LayoutParams)child.
								getLayoutParams();
							childLayoutParams.left = (int)itemLeft;
							childLayoutParams.right = (int)(itemLeft + itemWidth);
							childLayoutParams.top = (int)itemTop;
							childLayoutParams.bottom = (int)(itemTop + itemHeight);
							// Increment by item width
							itemLeft += itemWidth;
							itemPos++;
							// Add a vertical divider to draw
							if (mVerticalDivider != null)
							{
								mVerticalDividerRects.add(new android.graphics.Rect((int)itemLeft, (int)itemTop, 
									(int)(itemLeft + mVerticalDividerWidth), (int)(itemTop + itemHeight)));
							}
							// Increment by divider width (even if we're not computing
							// dividers, since we need to leave room for them when
							// calculating item positions)
							itemLeft += mVerticalDividerWidth;
						}
					}
					// Last child on each row should extend to very right edge
					if (childLayoutParams != null)
					{
						childLayoutParams.right = menuWidth;
					}
					itemTop += itemHeight;
					// Add a horizontal divider to draw
					if ((mHorizontalDivider != null) && (row < numRowsMinus1))
					{
						mHorizontalDividerRects.add(new android.graphics.Rect(0, (int)itemTop, menuWidth, 
							(int)(itemTop + mHorizontalDividerHeight)));
						itemTop += mHorizontalDividerHeight;
					}
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onMeasure(int widthMeasureSpec, int heightMeasureSpec
			)
		{
			int measuredWidth = resolveSize(int.MaxValue, widthMeasureSpec);
			calculateItemFittingMetadata(measuredWidth);
			layoutItems(measuredWidth);
			// Get the desired height of the icon menu view (last row of items does
			// not have a divider below)
			int layoutNumRows = mLayoutNumRows;
			int desiredHeight = (mRowHeight + mHorizontalDividerHeight) * layoutNumRows - mHorizontalDividerHeight;
			// Maximum possible width and desired height
			setMeasuredDimension(measuredWidth, resolveSize(desiredHeight, heightMeasureSpec)
				);
			// Position the children
			if (layoutNumRows > 0)
			{
				positionChildren(getMeasuredWidth(), getMeasuredHeight());
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onLayout(bool changed, int l, int t, int r, int 
			b)
		{
			android.view.View child;
			android.view.@internal.menu.IconMenuView.LayoutParams childLayoutParams;
			{
				for (int i = getChildCount() - 1; i >= 0; i--)
				{
					child = getChildAt(i);
					childLayoutParams = (android.view.@internal.menu.IconMenuView.LayoutParams)child.
						getLayoutParams();
					// Layout children according to positions set during the measure
					child.layout(childLayoutParams.left, childLayoutParams.top, childLayoutParams.right
						, childLayoutParams.bottom);
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onDraw(android.graphics.Canvas canvas)
		{
			android.graphics.drawable.Drawable drawable = mHorizontalDivider;
			if (drawable != null)
			{
				// If we have a horizontal divider to draw, draw it at the remembered positions
				java.util.ArrayList<android.graphics.Rect> rects = mHorizontalDividerRects;
				{
					for (int i = rects.size() - 1; i >= 0; i--)
					{
						drawable.setBounds(rects.get(i));
						drawable.draw(canvas);
					}
				}
			}
			drawable = mVerticalDivider;
			if (drawable != null)
			{
				// If we have a vertical divider to draw, draw it at the remembered positions
				java.util.ArrayList<android.graphics.Rect> rects = mVerticalDividerRects;
				{
					for (int i = rects.size() - 1; i >= 0; i--)
					{
						drawable.setBounds(rects.get(i));
						drawable.draw(canvas);
					}
				}
			}
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuBuilder.ItemInvoker"
			)]
		public bool invokeItem(android.view.@internal.menu.MenuItemImpl item)
		{
			return mMenu.performItemAction(item, 0);
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override android.view.ViewGroup.LayoutParams generateLayoutParams(android.util.AttributeSet
			 attrs)
		{
			return new android.view.@internal.menu.IconMenuView.LayoutParams(getContext(), attrs
				);
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		protected internal override bool checkLayoutParams(android.view.ViewGroup.LayoutParams
			 p)
		{
			// Override to allow type-checking of LayoutParams. 
			return p is android.view.@internal.menu.IconMenuView.LayoutParams;
		}

		/// <summary>Marks as having stale children.</summary>
		/// <remarks>Marks as having stale children.</remarks>
		internal void markStaleChildren()
		{
			if (!mHasStaleChildren)
			{
				mHasStaleChildren = true;
				requestLayout();
			}
		}

		/// <returns>
		/// The number of actual items shown (those that are backed by an
		/// <see cref="ItemView">ItemView</see>
		/// implementation--eg: excludes More
		/// item).
		/// </returns>
		internal int getNumActualItemsShown()
		{
			return mNumActualItemsShown;
		}

		internal void setNumActualItemsShown(int count)
		{
			mNumActualItemsShown = count;
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuView")]
		public int getWindowAnimations()
		{
			return mAnimations;
		}

		/// <summary>Returns the number of items per row.</summary>
		/// <remarks>
		/// Returns the number of items per row.
		/// <p>
		/// This should only be used for testing.
		/// </remarks>
		/// <returns>
		/// The length of the array is the number of rows. A value at a
		/// position is the number of items in that row.
		/// </returns>
		/// <hide></hide>
		public int[] getLayout()
		{
			return mLayout;
		}

		/// <summary>Returns the number of rows in the layout.</summary>
		/// <remarks>
		/// Returns the number of rows in the layout.
		/// <p>
		/// This should only be used for testing.
		/// </remarks>
		/// <returns>
		/// The length of the array is the number of rows. A value at a
		/// position is the number of items in that row.
		/// </returns>
		/// <hide></hide>
		public int getLayoutNumRows()
		{
			return mLayoutNumRows;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool dispatchKeyEvent(android.view.KeyEvent @event)
		{
			if (@event.getKeyCode() == android.view.KeyEvent.KEYCODE_MENU)
			{
				if (@event.getAction() == android.view.KeyEvent.ACTION_DOWN && @event.getRepeatCount
					() == 0)
				{
					removeCallbacks(this);
					postDelayed(this, android.view.ViewConfiguration.getLongPressTimeout());
				}
				else
				{
					if (@event.getAction() == android.view.KeyEvent.ACTION_UP)
					{
						if (mMenuBeingLongpressed)
						{
							// It was in cycle mode, so reset it (will also remove us
							// from being called back)
							setCycleShortcutCaptionMode(false);
							return true;
						}
						else
						{
							// Just remove us from being called back
							removeCallbacks(this);
						}
					}
				}
			}
			// Fall through to normal processing too
			return base.dispatchKeyEvent(@event);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onAttachedToWindow()
		{
			base.onAttachedToWindow();
			requestFocus();
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onDetachedFromWindow()
		{
			setCycleShortcutCaptionMode(false);
			base.onDetachedFromWindow();
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void onWindowFocusChanged(bool hasWindowFocus_1)
		{
			if (!hasWindowFocus_1)
			{
				setCycleShortcutCaptionMode(false);
			}
			base.onWindowFocusChanged(hasWindowFocus_1);
		}

		/// <summary>Sets the shortcut caption mode for IconMenuView.</summary>
		/// <remarks>
		/// Sets the shortcut caption mode for IconMenuView. This mode will
		/// continuously cycle between a child's shortcut and its title.
		/// </remarks>
		/// <param name="cycleShortcutAndNormal">
		/// Whether to go into cycling shortcut mode,
		/// or to go back to normal.
		/// </param>
		private void setCycleShortcutCaptionMode(bool cycleShortcutAndNormal)
		{
			if (!cycleShortcutAndNormal)
			{
				removeCallbacks(this);
				setChildrenCaptionMode(false);
				mMenuBeingLongpressed = false;
			}
			else
			{
				// Set it the first time (the cycle will be started in run()).
				setChildrenCaptionMode(true);
			}
		}

		/// <summary>
		/// When this method is invoked if the menu is currently not being
		/// longpressed, it means that the longpress has just been reached (so we set
		/// longpress flag, and start cycling).
		/// </summary>
		/// <remarks>
		/// When this method is invoked if the menu is currently not being
		/// longpressed, it means that the longpress has just been reached (so we set
		/// longpress flag, and start cycling). If it is being longpressed, we cycle
		/// to the next mode.
		/// </remarks>
		[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
		public void run()
		{
			if (mMenuBeingLongpressed)
			{
				// Cycle to other caption mode on the children
				setChildrenCaptionMode(!mLastChildrenCaptionMode);
			}
			else
			{
				// Switch ourselves to continuously cycle the items captions
				mMenuBeingLongpressed = true;
				setCycleShortcutCaptionMode(true);
			}
			// We should run again soon to cycle to the other caption mode
			postDelayed(this, ITEM_CAPTION_CYCLE_DELAY);
		}

		/// <summary>Iterates children and sets the desired shortcut mode.</summary>
		/// <remarks>
		/// Iterates children and sets the desired shortcut mode. Only
		/// <see cref="setCycleShortcutCaptionMode(bool)">setCycleShortcutCaptionMode(bool)</see>
		/// and
		/// <see cref="run()">run()</see>
		/// should call
		/// this.
		/// </remarks>
		/// <param name="shortcut">Whether to show shortcut or the title.</param>
		private void setChildrenCaptionMode(bool shortcut)
		{
			// Set the last caption mode pushed to children
			mLastChildrenCaptionMode = shortcut;
			{
				for (int i = getChildCount() - 1; i >= 0; i--)
				{
					((android.view.@internal.menu.IconMenuItemView)getChildAt(i)).setCaptionMode(shortcut
						);
				}
			}
		}

		/// <summary>
		/// For each item, calculates the most dense row that fully shows the item's
		/// title.
		/// </summary>
		/// <remarks>
		/// For each item, calculates the most dense row that fully shows the item's
		/// title.
		/// </remarks>
		/// <param name="width">The available width of the icon menu.</param>
		private void calculateItemFittingMetadata(int width)
		{
			int maxNumItemsPerRow = mMaxItemsPerRow;
			int numItems = getChildCount();
			{
				for (int i = 0; i < numItems; i++)
				{
					android.view.@internal.menu.IconMenuView.LayoutParams lp = (android.view.@internal.menu.IconMenuView
						.LayoutParams)getChildAt(i).getLayoutParams();
					// Start with 1, since that case does not get covered in the loop below
					lp.maxNumItemsOnRow = 1;
					{
						for (int curNumItemsPerRow = maxNumItemsPerRow; curNumItemsPerRow > 0; curNumItemsPerRow
							--)
						{
							// Check whether this item can fit into a row containing curNumItemsPerRow
							if (lp.desiredWidth < width / curNumItemsPerRow)
							{
								// It can, mark this value as the most dense row it can fit into
								lp.maxNumItemsOnRow = curNumItemsPerRow;
								break;
							}
						}
					}
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override android.os.Parcelable onSaveInstanceState()
		{
			android.os.Parcelable superState = base.onSaveInstanceState();
			android.view.View focusedView = getFocusedChild();
			{
				for (int i = getChildCount() - 1; i >= 0; i--)
				{
					if (getChildAt(i) == focusedView)
					{
						return new android.view.@internal.menu.IconMenuView.SavedState(superState, i);
					}
				}
			}
			return new android.view.@internal.menu.IconMenuView.SavedState(superState, -1);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onRestoreInstanceState(android.os.Parcelable state
			)
		{
			android.view.@internal.menu.IconMenuView.SavedState ss = (android.view.@internal.menu.IconMenuView
				.SavedState)state;
			base.onRestoreInstanceState(ss.getSuperState());
			if (ss.focusedPosition >= getChildCount())
			{
				return;
			}
			android.view.View v = getChildAt(ss.focusedPosition);
			if (v != null)
			{
				v.requestFocus();
			}
		}

		private class SavedState : android.view.View.BaseSavedState
		{
			internal int focusedPosition;

			/// <summary>
			/// Constructor called from
			/// <see cref="IconMenuView.onSaveInstanceState()">IconMenuView.onSaveInstanceState()
			/// 	</see>
			/// </summary>
			public SavedState(android.os.Parcelable superState, int focusedPosition) : base(superState
				)
			{
				this.focusedPosition = focusedPosition;
			}

			/// <summary>
			/// Constructor called from
			/// <see cref="CREATOR">CREATOR</see>
			/// </summary>
			internal SavedState(android.os.Parcel @in) : base(@in)
			{
				focusedPosition = @in.readInt();
			}

			[Sharpen.OverridesMethod(@"android.view.AbsSavedState")]
			public override void writeToParcel(android.os.Parcel dest, int flags)
			{
				base.writeToParcel(dest, flags);
				dest.writeInt(focusedPosition);
			}

			internal sealed class _Creator_731 : android.os.ParcelableClass.Creator<android.view.@internal.menu.IconMenuView
				.SavedState>
			{
				public _Creator_731()
				{
				}

				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.view.@internal.menu.IconMenuView.SavedState createFromParcel(android.os.Parcel
					 @in)
				{
					return new android.view.@internal.menu.IconMenuView.SavedState(@in);
				}

				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.view.@internal.menu.IconMenuView.SavedState[] newArray(int size)
				{
					return new android.view.@internal.menu.IconMenuView.SavedState[size];
				}
			}

			internal static readonly android.os.ParcelableClass.Creator<android.view.@internal.menu.IconMenuView
				.SavedState> CREATOR = new _Creator_731();
		}

		/// <summary>
		/// Layout parameters specific to IconMenuView (stores the left, top, right, bottom from the
		/// measure pass).
		/// </summary>
		/// <remarks>
		/// Layout parameters specific to IconMenuView (stores the left, top, right, bottom from the
		/// measure pass).
		/// </remarks>
		public class LayoutParams : android.view.ViewGroup.MarginLayoutParams
		{
			internal int left;

			internal int top;

			internal int right;

			internal int bottom;

			internal int desiredWidth;

			internal int maxNumItemsOnRow;

			public LayoutParams(android.content.Context c, android.util.AttributeSet attrs) : 
				base(c, attrs)
			{
			}

			public LayoutParams(int width, int height) : base(width, height)
			{
			}
		}
	}
}

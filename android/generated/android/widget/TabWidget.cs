using Sharpen;

namespace android.widget
{
	/// <summary>
	/// Displays a list of tab labels representing each page in the parent's tab
	/// collection.
	/// </summary>
	/// <remarks>
	/// Displays a list of tab labels representing each page in the parent's tab
	/// collection. The container object for this widget is
	/// <see cref="TabHost">TabHost</see>
	/// . When the user selects a tab, this
	/// object sends a message to the parent container, TabHost, to tell it to switch
	/// the displayed page. You typically won't use many methods directly on this
	/// object. The container TabHost is used to add labels, add the callback
	/// handler, and manage callbacks. You might call this object to iterate the list
	/// of tabs, or to tweak the layout of the tab list, but most methods should be
	/// called on the containing TabHost object.
	/// <p>See the &lt;a href="
	/// <docRoot></docRoot>
	/// resources/tutorials/views/hello-tabwidget.html"&gt;Tab Layout
	/// tutorial</a>.</p>
	/// </remarks>
	/// <attr>ref android.R.styleable#TabWidget_divider</attr>
	/// <attr>ref android.R.styleable#TabWidget_tabStripEnabled</attr>
	/// <attr>ref android.R.styleable#TabWidget_tabStripLeft</attr>
	/// <attr>ref android.R.styleable#TabWidget_tabStripRight</attr>
	[Sharpen.Sharpened]
	public class TabWidget : android.widget.LinearLayout, android.view.View.OnFocusChangeListener
	{
		private android.widget.TabWidget.OnTabSelectionChanged mSelectionChangedListener;

		private int mSelectedTab = -1;

		private android.graphics.drawable.Drawable mLeftStrip;

		private android.graphics.drawable.Drawable mRightStrip;

		private bool mDrawBottomStrips = true;

		private bool mStripMoved;

		private readonly android.graphics.Rect mBounds = new android.graphics.Rect();

		private int mImposedTabsHeight = -1;

		private int[] mImposedTabWidths;

		public TabWidget(android.content.Context context) : this(context, null)
		{
		}

		public TabWidget(android.content.Context context, android.util.AttributeSet attrs
			) : this(context, attrs, android.@internal.R.attr.tabWidgetStyle)
		{
		}

		public TabWidget(android.content.Context context, android.util.AttributeSet attrs
			, int defStyle) : base(context, attrs, defStyle)
		{
			// This value will be set to 0 as soon as the first tab is added to TabHost.
			// When positive, the widths and heights of tabs will be imposed so that they fit in parent
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.TabWidget, defStyle, 0);
			setStripEnabled(a.getBoolean(android.R.styleable.TabWidget_tabStripEnabled, true)
				);
			setLeftStripDrawable(a.getDrawable(android.R.styleable.TabWidget_tabStripLeft));
			setRightStripDrawable(a.getDrawable(android.R.styleable.TabWidget_tabStripRight));
			a.recycle();
			initTabWidget();
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onSizeChanged(int w, int h, int oldw, int oldh)
		{
			mStripMoved = true;
			base.onSizeChanged(w, h, oldw, oldh);
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		protected internal override int getChildDrawingOrder(int childCount, int i)
		{
			if (mSelectedTab == -1)
			{
				return i;
			}
			else
			{
				// Always draw the selected tab last, so that drop shadows are drawn
				// in the correct z-order.
				if (i == childCount - 1)
				{
					return mSelectedTab;
				}
				else
				{
					if (i >= mSelectedTab)
					{
						return i + 1;
					}
					else
					{
						return i;
					}
				}
			}
		}

		private void initTabWidget()
		{
			setChildrenDrawingOrderEnabled(true);
			android.content.Context context = mContext;
			android.content.res.Resources resources = context.getResources();
			// Tests the target Sdk version, as set in the Manifest. Could not be set using styles.xml
			// in a values-v? directory which targets the current platform Sdk version instead.
			if (context.getApplicationInfo().targetSdkVersion <= android.os.Build.VERSION_CODES
				.DONUT)
			{
				// Donut apps get old color scheme
				if (mLeftStrip == null)
				{
					mLeftStrip = resources.getDrawable(android.@internal.R.drawable.tab_bottom_left_v4
						);
				}
				if (mRightStrip == null)
				{
					mRightStrip = resources.getDrawable(android.@internal.R.drawable.tab_bottom_right_v4
						);
				}
			}
			else
			{
				// Use modern color scheme for Eclair and beyond
				if (mLeftStrip == null)
				{
					mLeftStrip = resources.getDrawable(android.@internal.R.drawable.tab_bottom_left);
				}
				if (mRightStrip == null)
				{
					mRightStrip = resources.getDrawable(android.@internal.R.drawable.tab_bottom_right
						);
				}
			}
			// Deal with focus, as we don't want the focus to go by default
			// to a tab other than the current tab
			setFocusable(true);
			setOnFocusChangeListener(this);
		}

		[Sharpen.OverridesMethod(@"android.widget.LinearLayout")]
		internal override void measureChildBeforeLayout(android.view.View child, int childIndex
			, int widthMeasureSpec, int totalWidth, int heightMeasureSpec, int totalHeight)
		{
			if (!isMeasureWithLargestChildEnabled() && mImposedTabsHeight >= 0)
			{
				widthMeasureSpec = android.view.View.MeasureSpec.makeMeasureSpec(totalWidth + mImposedTabWidths
					[childIndex], android.view.View.MeasureSpec.EXACTLY);
				heightMeasureSpec = android.view.View.MeasureSpec.makeMeasureSpec(mImposedTabsHeight
					, android.view.View.MeasureSpec.EXACTLY);
			}
			base.measureChildBeforeLayout(child, childIndex, widthMeasureSpec, totalWidth, heightMeasureSpec
				, totalHeight);
		}

		[Sharpen.OverridesMethod(@"android.widget.LinearLayout")]
		internal override void measureHorizontal(int widthMeasureSpec, int heightMeasureSpec
			)
		{
			if (android.view.View.MeasureSpec.getMode(widthMeasureSpec) == android.view.View.
				MeasureSpec.UNSPECIFIED)
			{
				base.measureHorizontal(widthMeasureSpec, heightMeasureSpec);
				return;
			}
			// First, measure with no constraint
			int unspecifiedWidth = android.view.View.MeasureSpec.makeMeasureSpec(0, android.view.View
				.MeasureSpec.UNSPECIFIED);
			mImposedTabsHeight = -1;
			base.measureHorizontal(unspecifiedWidth, heightMeasureSpec);
			int extraWidth = getMeasuredWidth() - android.view.View.MeasureSpec.getSize(widthMeasureSpec
				);
			if (extraWidth > 0)
			{
				int count = getChildCount();
				int childCount = 0;
				{
					for (int i = 0; i < count; i++)
					{
						android.view.View child = getChildAt(i);
						if (child.getVisibility() == GONE)
						{
							continue;
						}
						childCount++;
					}
				}
				if (childCount > 0)
				{
					if (mImposedTabWidths == null || mImposedTabWidths.Length != count)
					{
						mImposedTabWidths = new int[count];
					}
					{
						for (int i_1 = 0; i_1 < count; i_1++)
						{
							android.view.View child = getChildAt(i_1);
							if (child.getVisibility() == GONE)
							{
								continue;
							}
							int childWidth = child.getMeasuredWidth();
							int delta = extraWidth / childCount;
							int newWidth = System.Math.Max(0, childWidth - delta);
							mImposedTabWidths[i_1] = newWidth;
							// Make sure the extra width is evenly distributed, no int division remainder
							extraWidth -= childWidth - newWidth;
							// delta may have been clamped
							childCount--;
							mImposedTabsHeight = System.Math.Max(mImposedTabsHeight, child.getMeasuredHeight(
								));
						}
					}
				}
			}
			// Measure again, this time with imposed tab widths and respecting initial spec request
			base.measureHorizontal(widthMeasureSpec, heightMeasureSpec);
		}

		/// <summary>Returns the tab indicator view at the given index.</summary>
		/// <remarks>Returns the tab indicator view at the given index.</remarks>
		/// <param name="index">the zero-based index of the tab indicator view to return</param>
		/// <returns>the tab indicator view at the given index</returns>
		public virtual android.view.View getChildTabViewAt(int index)
		{
			return getChildAt(index);
		}

		/// <summary>Returns the number of tab indicator views.</summary>
		/// <remarks>Returns the number of tab indicator views.</remarks>
		/// <returns>the number of tab indicator views.</returns>
		public virtual int getTabCount()
		{
			return getChildCount();
		}

		/// <summary>Sets the drawable to use as a divider between the tab indicators.</summary>
		/// <remarks>Sets the drawable to use as a divider between the tab indicators.</remarks>
		/// <param name="drawable">the divider drawable</param>
		[Sharpen.OverridesMethod(@"android.widget.LinearLayout")]
		public override void setDividerDrawable(android.graphics.drawable.Drawable drawable
			)
		{
			base.setDividerDrawable(drawable);
		}

		/// <summary>Sets the drawable to use as a divider between the tab indicators.</summary>
		/// <remarks>Sets the drawable to use as a divider between the tab indicators.</remarks>
		/// <param name="resId">
		/// the resource identifier of the drawable to use as a
		/// divider.
		/// </param>
		public virtual void setDividerDrawable(int resId)
		{
			setDividerDrawable(getResources().getDrawable(resId));
		}

		/// <summary>
		/// Sets the drawable to use as the left part of the strip below the
		/// tab indicators.
		/// </summary>
		/// <remarks>
		/// Sets the drawable to use as the left part of the strip below the
		/// tab indicators.
		/// </remarks>
		/// <param name="drawable">the left strip drawable</param>
		public virtual void setLeftStripDrawable(android.graphics.drawable.Drawable drawable
			)
		{
			mLeftStrip = drawable;
			requestLayout();
			invalidate();
		}

		/// <summary>
		/// Sets the drawable to use as the left part of the strip below the
		/// tab indicators.
		/// </summary>
		/// <remarks>
		/// Sets the drawable to use as the left part of the strip below the
		/// tab indicators.
		/// </remarks>
		/// <param name="resId">
		/// the resource identifier of the drawable to use as the
		/// left strip drawable
		/// </param>
		public virtual void setLeftStripDrawable(int resId)
		{
			setLeftStripDrawable(getResources().getDrawable(resId));
		}

		/// <summary>
		/// Sets the drawable to use as the right part of the strip below the
		/// tab indicators.
		/// </summary>
		/// <remarks>
		/// Sets the drawable to use as the right part of the strip below the
		/// tab indicators.
		/// </remarks>
		/// <param name="drawable">the right strip drawable</param>
		public virtual void setRightStripDrawable(android.graphics.drawable.Drawable drawable
			)
		{
			mRightStrip = drawable;
			requestLayout();
			invalidate();
		}

		/// <summary>
		/// Sets the drawable to use as the right part of the strip below the
		/// tab indicators.
		/// </summary>
		/// <remarks>
		/// Sets the drawable to use as the right part of the strip below the
		/// tab indicators.
		/// </remarks>
		/// <param name="resId">
		/// the resource identifier of the drawable to use as the
		/// right strip drawable
		/// </param>
		public virtual void setRightStripDrawable(int resId)
		{
			setRightStripDrawable(getResources().getDrawable(resId));
		}

		/// <summary>
		/// Controls whether the bottom strips on the tab indicators are drawn or
		/// not.
		/// </summary>
		/// <remarks>
		/// Controls whether the bottom strips on the tab indicators are drawn or
		/// not.  The default is to draw them.  If the user specifies a custom
		/// view for the tab indicators, then the TabHost class calls this method
		/// to disable drawing of the bottom strips.
		/// </remarks>
		/// <param name="stripEnabled">true if the bottom strips should be drawn.</param>
		public virtual void setStripEnabled(bool stripEnabled)
		{
			mDrawBottomStrips = stripEnabled;
			invalidate();
		}

		/// <summary>
		/// Indicates whether the bottom strips on the tab indicators are drawn
		/// or not.
		/// </summary>
		/// <remarks>
		/// Indicates whether the bottom strips on the tab indicators are drawn
		/// or not.
		/// </remarks>
		public virtual bool isStripEnabled()
		{
			return mDrawBottomStrips;
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override void childDrawableStateChanged(android.view.View child)
		{
			if (getTabCount() > 0 && child == getChildTabViewAt(mSelectedTab))
			{
				// To make sure that the bottom strip is redrawn
				invalidate();
			}
			base.childDrawableStateChanged(child);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void dispatchDraw(android.graphics.Canvas canvas)
		{
			base.dispatchDraw(canvas);
			// Do nothing if there are no tabs.
			if (getTabCount() == 0)
			{
				return;
			}
			// If the user specified a custom view for the tab indicators, then
			// do not draw the bottom strips.
			if (!mDrawBottomStrips)
			{
				// Skip drawing the bottom strips.
				return;
			}
			android.view.View selectedChild = getChildTabViewAt(mSelectedTab);
			android.graphics.drawable.Drawable leftStrip = mLeftStrip;
			android.graphics.drawable.Drawable rightStrip = mRightStrip;
			leftStrip.setState(selectedChild.getDrawableState());
			rightStrip.setState(selectedChild.getDrawableState());
			if (mStripMoved)
			{
				android.graphics.Rect bounds = mBounds;
				bounds.left = selectedChild.getLeft();
				bounds.right = selectedChild.getRight();
				int myHeight = getHeight();
				leftStrip.setBounds(System.Math.Min(0, bounds.left - leftStrip.getIntrinsicWidth(
					)), myHeight - leftStrip.getIntrinsicHeight(), bounds.left, myHeight);
				rightStrip.setBounds(bounds.right, myHeight - rightStrip.getIntrinsicHeight(), System.Math.Max
					(getWidth(), bounds.right + rightStrip.getIntrinsicWidth()), myHeight);
				mStripMoved = false;
			}
			leftStrip.draw(canvas);
			rightStrip.draw(canvas);
		}

		/// <summary>Sets the current tab.</summary>
		/// <remarks>
		/// Sets the current tab.
		/// This method is used to bring a tab to the front of the Widget,
		/// and is used to post to the rest of the UI that a different tab
		/// has been brought to the foreground.
		/// Note, this is separate from the traditional "focus" that is
		/// employed from the view logic.
		/// For instance, if we have a list in a tabbed view, a user may be
		/// navigating up and down the list, moving the UI focus (orange
		/// highlighting) through the list items.  The cursor movement does
		/// not effect the "selected" tab though, because what is being
		/// scrolled through is all on the same tab.  The selected tab only
		/// changes when we navigate between tabs (moving from the list view
		/// to the next tabbed view, in this example).
		/// To move both the focus AND the selected tab at once, please use
		/// <see cref="setCurrentTab(int)">setCurrentTab(int)</see>
		/// . Normally, the view logic takes care of
		/// adjusting the focus, so unless you're circumventing the UI,
		/// you'll probably just focus your interest here.
		/// </remarks>
		/// <param name="index">
		/// The tab that you want to indicate as the selected
		/// tab (tab brought to the front of the widget)
		/// </param>
		/// <seealso cref="focusCurrentTab(int)">focusCurrentTab(int)</seealso>
		public virtual void setCurrentTab(int index)
		{
			if (index < 0 || index >= getTabCount() || index == mSelectedTab)
			{
				return;
			}
			if (mSelectedTab != -1)
			{
				getChildTabViewAt(mSelectedTab).setSelected(false);
			}
			mSelectedTab = index;
			getChildTabViewAt(mSelectedTab).setSelected(true);
			mStripMoved = true;
			if (isShown())
			{
				sendAccessibilityEvent(android.view.accessibility.AccessibilityEvent.TYPE_VIEW_SELECTED
					);
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool dispatchPopulateAccessibilityEvent(android.view.accessibility.AccessibilityEvent
			 @event)
		{
			onPopulateAccessibilityEvent(@event);
			// Dispatch only to the selected tab.
			if (mSelectedTab != -1)
			{
				android.view.View tabView = getChildTabViewAt(mSelectedTab);
				if (tabView != null && tabView.getVisibility() == VISIBLE)
				{
					return tabView.dispatchPopulateAccessibilityEvent(@event);
				}
			}
			return false;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void onInitializeAccessibilityEvent(android.view.accessibility.AccessibilityEvent
			 @event)
		{
			base.onInitializeAccessibilityEvent(@event);
			@event.setItemCount(getTabCount());
			@event.setCurrentItemIndex(mSelectedTab);
		}

		/// <summary>Sets the current tab and focuses the UI on it.</summary>
		/// <remarks>
		/// Sets the current tab and focuses the UI on it.
		/// This method makes sure that the focused tab matches the selected
		/// tab, normally at
		/// <see cref="setCurrentTab(int)">setCurrentTab(int)</see>
		/// .  Normally this would not
		/// be an issue if we go through the UI, since the UI is responsible
		/// for calling TabWidget.onFocusChanged(), but in the case where we
		/// are selecting the tab programmatically, we'll need to make sure
		/// focus keeps up.
		/// </remarks>
		/// <param name="index">
		/// The tab that you want focused (highlighted in orange)
		/// and selected (tab brought to the front of the widget)
		/// </param>
		/// <seealso cref="setCurrentTab(int)">setCurrentTab(int)</seealso>
		public virtual void focusCurrentTab(int index)
		{
			int oldTab = mSelectedTab;
			// set the tab
			setCurrentTab(index);
			// change the focus if applicable.
			if (oldTab != index)
			{
				getChildTabViewAt(index).requestFocus();
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void setEnabled(bool enabled)
		{
			base.setEnabled(enabled);
			int count = getTabCount();
			{
				for (int i = 0; i < count; i++)
				{
					android.view.View child = getChildTabViewAt(i);
					child.setEnabled(enabled);
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override void addView(android.view.View child)
		{
			if (child.getLayoutParams() == null)
			{
				android.widget.LinearLayout.LayoutParams lp = new android.widget.LinearLayout.LayoutParams
					(0, android.view.ViewGroup.LayoutParams.MATCH_PARENT, 1.0f);
				lp.setMargins(0, 0, 0, 0);
				child.setLayoutParams(lp);
			}
			// Ensure you can navigate to the tab with the keyboard, and you can touch it
			child.setFocusable(true);
			child.setClickable(true);
			base.addView(child);
			// TODO: detect this via geometry with a tabwidget listener rather
			// than potentially interfere with the view's listener
			child.setOnClickListener(new android.widget.TabWidget.TabClickListener(this, getTabCount
				() - 1));
			child.setOnFocusChangeListener(this);
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override void removeAllViews()
		{
			base.removeAllViews();
			mSelectedTab = -1;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void sendAccessibilityEventUnchecked(android.view.accessibility.AccessibilityEvent
			 @event)
		{
			// this class fires events only when tabs are focused or selected
			if (@event.getEventType() == android.view.accessibility.AccessibilityEvent.TYPE_VIEW_FOCUSED
				 && isFocused())
			{
				@event.recycle();
				return;
			}
			base.sendAccessibilityEventUnchecked(@event);
		}

		/// <summary>
		/// Provides a way for
		/// <see cref="TabHost">TabHost</see>
		/// to be notified that the user clicked on a tab indicator.
		/// </summary>
		internal virtual void setTabSelectionListener(android.widget.TabWidget.OnTabSelectionChanged
			 listener)
		{
			mSelectionChangedListener = listener;
		}

		/// <summary>
		/// <inheritDoc></inheritDoc>
		/// 
		/// </summary>
		[Sharpen.ImplementsInterface(@"android.view.View.OnFocusChangeListener")]
		public virtual void onFocusChange(android.view.View v, bool hasFocus_1)
		{
			if (v == this && hasFocus_1 && getTabCount() > 0)
			{
				getChildTabViewAt(mSelectedTab).requestFocus();
				return;
			}
			if (hasFocus_1)
			{
				int i = 0;
				int numTabs = getTabCount();
				while (i < numTabs)
				{
					if (getChildTabViewAt(i) == v)
					{
						setCurrentTab(i);
						mSelectionChangedListener.onTabSelectionChanged(i, false);
						if (isShown())
						{
							// a tab is focused so send an event to announce the tab widget state
							sendAccessibilityEvent(android.view.accessibility.AccessibilityEvent.TYPE_VIEW_FOCUSED
								);
						}
						break;
					}
					i++;
				}
			}
		}

		private class TabClickListener : android.view.View.OnClickListener
		{
			internal readonly int mTabIndex;

			internal TabClickListener(TabWidget _enclosing, int tabIndex)
			{
				this._enclosing = _enclosing;
				// registered with each tab indicator so we can notify tab host
				this.mTabIndex = tabIndex;
			}

			[Sharpen.ImplementsInterface(@"android.view.View.OnClickListener")]
			public virtual void onClick(android.view.View v)
			{
				this._enclosing.mSelectionChangedListener.onTabSelectionChanged(this.mTabIndex, true
					);
			}

			private readonly TabWidget _enclosing;
		}

		/// <summary>
		/// Let
		/// <see cref="TabHost">TabHost</see>
		/// know that the user clicked on a tab indicator.
		/// </summary>
		internal interface OnTabSelectionChanged
		{
			/// <summary>Informs the TabHost which tab was selected.</summary>
			/// <remarks>
			/// Informs the TabHost which tab was selected. It also indicates
			/// if the tab was clicked/pressed or just focused into.
			/// </remarks>
			/// <param name="tabIndex">index of the tab that was selected</param>
			/// <param name="clicked">
			/// whether the selection changed due to a touch/click
			/// or due to focus entering the tab through navigation. Pass true
			/// if it was due to a press/click and false otherwise.
			/// </param>
			void onTabSelectionChanged(int tabIndex, bool clicked);
		}
	}
}

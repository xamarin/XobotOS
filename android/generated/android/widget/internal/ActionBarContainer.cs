using Sharpen;

namespace android.widget.@internal
{
	/// <summary>This class acts as a container for the action bar view and action mode context views.
	/// 	</summary>
	/// <remarks>
	/// This class acts as a container for the action bar view and action mode context views.
	/// It applies special styles as needed to help handle animated transitions between them.
	/// </remarks>
	/// <hide></hide>
	[Sharpen.Sharpened]
	public class ActionBarContainer : android.widget.FrameLayout
	{
		private bool mIsTransitioning;

		private android.view.View mTabContainer;

		private android.widget.@internal.ActionBarView mActionBarView;

		private android.graphics.drawable.Drawable mBackground;

		private android.graphics.drawable.Drawable mStackedBackground;

		private android.graphics.drawable.Drawable mSplitBackground;

		private bool mIsSplit;

		private bool mIsStacked;

		public ActionBarContainer(android.content.Context context) : this(context, null)
		{
		}

		public ActionBarContainer(android.content.Context context, android.util.AttributeSet
			 attrs) : base(context, attrs)
		{
			setBackgroundDrawable(null);
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.ActionBar);
			mBackground = a.getDrawable(android.@internal.R.styleable.ActionBar_background);
			mStackedBackground = a.getDrawable(android.@internal.R.styleable.ActionBar_backgroundStacked
				);
			if (getId() == android.@internal.R.id.split_action_bar)
			{
				mIsSplit = true;
				mSplitBackground = a.getDrawable(android.@internal.R.styleable.ActionBar_backgroundSplit
					);
			}
			a.recycle();
			setWillNotDraw(mIsSplit ? mSplitBackground == null : mBackground == null && mStackedBackground
				 == null);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onFinishInflate()
		{
			base.onFinishInflate();
			mActionBarView = (android.widget.@internal.ActionBarView)findViewById(android.@internal.R
				.id.action_bar);
		}

		public virtual void setPrimaryBackground(android.graphics.drawable.Drawable bg)
		{
			mBackground = bg;
			invalidate();
		}

		public virtual void setStackedBackground(android.graphics.drawable.Drawable bg)
		{
			mStackedBackground = bg;
			invalidate();
		}

		public virtual void setSplitBackground(android.graphics.drawable.Drawable bg)
		{
			mSplitBackground = bg;
			invalidate();
		}

		/// <summary>Set the action bar into a "transitioning" state.</summary>
		/// <remarks>
		/// Set the action bar into a "transitioning" state. While transitioning
		/// the bar will block focus and touch from all of its descendants. This
		/// prevents the user from interacting with the bar while it is animating
		/// in or out.
		/// </remarks>
		/// <param name="isTransitioning">true if the bar is currently transitioning, false otherwise.
		/// 	</param>
		public virtual void setTransitioning(bool isTransitioning)
		{
			mIsTransitioning = isTransitioning;
			setDescendantFocusability(isTransitioning ? FOCUS_BLOCK_DESCENDANTS : FOCUS_AFTER_DESCENDANTS
				);
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override bool onInterceptTouchEvent(android.view.MotionEvent ev)
		{
			return mIsTransitioning || base.onInterceptTouchEvent(ev);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool onTouchEvent(android.view.MotionEvent ev)
		{
			base.onTouchEvent(ev);
			// An action bar always eats touch events.
			return true;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool onHoverEvent(android.view.MotionEvent ev)
		{
			base.onHoverEvent(ev);
			// An action bar always eats hover events.
			return true;
		}

		public virtual void setTabContainer(android.widget.@internal.ScrollingTabContainerView
			 tabView)
		{
			if (mTabContainer != null)
			{
				removeView(mTabContainer);
			}
			mTabContainer = tabView;
			if (tabView != null)
			{
				addView(tabView);
				android.view.ViewGroup.LayoutParams lp = tabView.getLayoutParams();
				lp.width = android.view.ViewGroup.LayoutParams.MATCH_PARENT;
				lp.height = android.view.ViewGroup.LayoutParams.WRAP_CONTENT;
				tabView.setAllowCollapse(false);
			}
		}

		public virtual android.view.View getTabContainer()
		{
			return mTabContainer;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onDraw(android.graphics.Canvas canvas)
		{
			if (getWidth() == 0 || getHeight() == 0)
			{
				return;
			}
			if (mIsSplit)
			{
				if (mSplitBackground != null)
				{
					mSplitBackground.draw(canvas);
				}
			}
			else
			{
				if (mBackground != null)
				{
					mBackground.draw(canvas);
				}
				if (mStackedBackground != null && mIsStacked)
				{
					mStackedBackground.draw(canvas);
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override android.view.ActionMode startActionModeForChild(android.view.View
			 child, android.view.ActionMode.Callback callback)
		{
			// No starting an action mode for an action bar child! (Where would it go?)
			return null;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onMeasure(int widthMeasureSpec, int heightMeasureSpec
			)
		{
			base.onMeasure(widthMeasureSpec, heightMeasureSpec);
			if (mActionBarView == null)
			{
				return;
			}
			android.widget.FrameLayout.LayoutParams lp = (android.widget.FrameLayout.LayoutParams
				)mActionBarView.getLayoutParams();
			int actionBarViewHeight = mActionBarView.isCollapsed() ? 0 : mActionBarView.getMeasuredHeight
				() + lp.topMargin + lp.bottomMargin;
			if (mTabContainer != null && mTabContainer.getVisibility() != GONE)
			{
				int mode = android.view.View.MeasureSpec.getMode(heightMeasureSpec);
				if (mode == android.view.View.MeasureSpec.AT_MOST)
				{
					int maxHeight = android.view.View.MeasureSpec.getSize(heightMeasureSpec);
					setMeasuredDimension(getMeasuredWidth(), System.Math.Min(actionBarViewHeight + mTabContainer
						.getMeasuredHeight(), maxHeight));
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onLayout(bool changed, int l, int t, int r, int 
			b)
		{
			base.onLayout(changed, l, t, r, b);
			bool hasTabs = mTabContainer != null && mTabContainer.getVisibility() != GONE;
			if (mTabContainer != null && mTabContainer.getVisibility() != GONE)
			{
				int containerHeight = getMeasuredHeight();
				int tabHeight = mTabContainer.getMeasuredHeight();
				if ((mActionBarView.getDisplayOptions() & android.app.ActionBar.DISPLAY_SHOW_HOME
					) == 0)
				{
					// Not showing home, put tabs on top.
					int count = getChildCount();
					{
						for (int i = 0; i < count; i++)
						{
							android.view.View child = getChildAt(i);
							if (child == mTabContainer)
							{
								continue;
							}
							if (!mActionBarView.isCollapsed())
							{
								child.offsetTopAndBottom(tabHeight);
							}
						}
					}
					mTabContainer.layout(l, 0, r, tabHeight);
				}
				else
				{
					mTabContainer.layout(l, containerHeight - tabHeight, r, containerHeight);
				}
			}
			bool needsInvalidate = false;
			if (mIsSplit)
			{
				if (mSplitBackground != null)
				{
					mSplitBackground.setBounds(0, 0, getMeasuredWidth(), getMeasuredHeight());
					needsInvalidate = true;
				}
			}
			else
			{
				if (mBackground != null)
				{
					mBackground.setBounds(mActionBarView.getLeft(), mActionBarView.getTop(), mActionBarView
						.getRight(), mActionBarView.getBottom());
					needsInvalidate = true;
				}
				if ((mIsStacked = hasTabs && mStackedBackground != null))
				{
					mStackedBackground.setBounds(mTabContainer.getLeft(), mTabContainer.getTop(), mTabContainer
						.getRight(), mTabContainer.getBottom());
					needsInvalidate = true;
				}
			}
			if (needsInvalidate)
			{
				invalidate();
			}
		}
	}
}

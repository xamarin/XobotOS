using Sharpen;

namespace android.widget.@internal
{
	/// <summary>
	/// This widget implements the dynamic action bar tab behavior that can change
	/// across different configurations or circumstances.
	/// </summary>
	/// <remarks>
	/// This widget implements the dynamic action bar tab behavior that can change
	/// across different configurations or circumstances.
	/// </remarks>
	[Sharpen.Sharpened]
	public class ScrollingTabContainerView : android.widget.HorizontalScrollView, android.widget.AdapterView
		.OnItemSelectedListener
	{
		internal const string TAG = "ScrollingTabContainerView";

		internal java.lang.Runnable mTabSelector;

		private android.widget.@internal.ScrollingTabContainerView.TabClickListener mTabClickListener;

		private android.widget.LinearLayout mTabLayout;

		private android.widget.Spinner mTabSpinner;

		private bool mAllowCollapse;

		internal int mMaxTabWidth;

		private int mContentHeight;

		private int mSelectedTabIndex;

		protected internal android.animation.Animator mVisibilityAnim;

		protected internal readonly android.widget.@internal.ScrollingTabContainerView.VisibilityAnimListener
			 mVisAnimListener;

		private static readonly android.animation.TimeInterpolator sAlphaInterpolator = new 
			android.view.animation.DecelerateInterpolator();

		internal const int FADE_DURATION = 200;

		public ScrollingTabContainerView(android.content.Context context) : base(context)
		{
			mVisAnimListener = new android.widget.@internal.ScrollingTabContainerView.VisibilityAnimListener
				(this);
			setHorizontalScrollBarEnabled(false);
			android.content.res.TypedArray a = getContext().obtainStyledAttributes(null, android.@internal.R
				.styleable.ActionBar, android.@internal.R.attr.actionBarStyle, 0);
			setContentHeight(a.getLayoutDimension(android.@internal.R.styleable.ActionBar_height
				, 0));
			a.recycle();
			mTabLayout = createTabLayout();
			addView(mTabLayout, new android.view.ViewGroup.LayoutParams(android.view.ViewGroup
				.LayoutParams.WRAP_CONTENT, android.view.ViewGroup.LayoutParams.MATCH_PARENT));
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onMeasure(int widthMeasureSpec, int heightMeasureSpec
			)
		{
			int widthMode = android.view.View.MeasureSpec.getMode(widthMeasureSpec);
			bool lockedExpanded = widthMode == android.view.View.MeasureSpec.EXACTLY;
			setFillViewport(lockedExpanded);
			int childCount = mTabLayout.getChildCount();
			if (childCount > 1 && (widthMode == android.view.View.MeasureSpec.EXACTLY || widthMode
				 == android.view.View.MeasureSpec.AT_MOST))
			{
				if (childCount > 2)
				{
					mMaxTabWidth = (int)(android.view.View.MeasureSpec.getSize(widthMeasureSpec) * 0.4f
						);
				}
				else
				{
					mMaxTabWidth = android.view.View.MeasureSpec.getSize(widthMeasureSpec) / 2;
				}
			}
			else
			{
				mMaxTabWidth = -1;
			}
			heightMeasureSpec = android.view.View.MeasureSpec.makeMeasureSpec(mContentHeight, 
				android.view.View.MeasureSpec.EXACTLY);
			bool canCollapse = !lockedExpanded && mAllowCollapse;
			if (canCollapse)
			{
				// See if we should expand
				mTabLayout.measure(android.view.View.MeasureSpec.UNSPECIFIED, heightMeasureSpec);
				if (mTabLayout.getMeasuredWidth() > android.view.View.MeasureSpec.getSize(widthMeasureSpec
					))
				{
					performCollapse();
				}
				else
				{
					performExpand();
				}
			}
			else
			{
				performExpand();
			}
			int oldWidth = getMeasuredWidth();
			base.onMeasure(widthMeasureSpec, heightMeasureSpec);
			int newWidth = getMeasuredWidth();
			if (lockedExpanded && oldWidth != newWidth)
			{
				// Recenter the tab display if we're at a new (scrollable) size.
				setTabSelected(mSelectedTabIndex);
			}
		}

		/// <summary>
		/// Indicates whether this view is collapsed into a dropdown menu instead
		/// of traditional tabs.
		/// </summary>
		/// <remarks>
		/// Indicates whether this view is collapsed into a dropdown menu instead
		/// of traditional tabs.
		/// </remarks>
		/// <returns>true if showing as a spinner</returns>
		private bool isCollapsed()
		{
			return mTabSpinner != null && mTabSpinner.getParent() == this;
		}

		public virtual void setAllowCollapse(bool allowCollapse)
		{
			mAllowCollapse = allowCollapse;
		}

		private void performCollapse()
		{
			if (isCollapsed())
			{
				return;
			}
			if (mTabSpinner == null)
			{
				mTabSpinner = createSpinner();
			}
			removeView(mTabLayout);
			addView(mTabSpinner, new android.view.ViewGroup.LayoutParams(android.view.ViewGroup
				.LayoutParams.WRAP_CONTENT, android.view.ViewGroup.LayoutParams.MATCH_PARENT));
			if (mTabSpinner.getAdapter() == null)
			{
				mTabSpinner.setAdapter(new android.widget.@internal.ScrollingTabContainerView.TabAdapter
					(this));
			}
			if (mTabSelector != null)
			{
				removeCallbacks(mTabSelector);
				mTabSelector = null;
			}
			mTabSpinner.setSelection(mSelectedTabIndex);
		}

		private bool performExpand()
		{
			if (!isCollapsed())
			{
				return false;
			}
			removeView(mTabSpinner);
			addView(mTabLayout, new android.view.ViewGroup.LayoutParams(android.view.ViewGroup
				.LayoutParams.WRAP_CONTENT, android.view.ViewGroup.LayoutParams.MATCH_PARENT));
			setTabSelected(mTabSpinner.getSelectedItemPosition());
			return false;
		}

		public virtual void setTabSelected(int position)
		{
			mSelectedTabIndex = position;
			int tabCount = mTabLayout.getChildCount();
			{
				for (int i = 0; i < tabCount; i++)
				{
					android.view.View child = mTabLayout.getChildAt(i);
					bool isSelected_1 = i == position;
					child.setSelected(isSelected_1);
					if (isSelected_1)
					{
						animateToTab(position);
					}
				}
			}
		}

		public virtual void setContentHeight(int contentHeight)
		{
			mContentHeight = contentHeight;
			requestLayout();
		}

		private android.widget.LinearLayout createTabLayout()
		{
			android.widget.LinearLayout tabLayout = new android.widget.LinearLayout(getContext
				(), null, android.@internal.R.attr.actionBarTabBarStyle);
			tabLayout.setMeasureWithLargestChildEnabled(true);
			tabLayout.setLayoutParams(new android.widget.LinearLayout.LayoutParams(android.view.ViewGroup
				.LayoutParams.WRAP_CONTENT, android.view.ViewGroup.LayoutParams.MATCH_PARENT));
			return tabLayout;
		}

		private android.widget.Spinner createSpinner()
		{
			android.widget.Spinner spinner = new android.widget.Spinner(getContext(), null, android.@internal.R
				.attr.actionDropDownStyle);
			spinner.setLayoutParams(new android.widget.LinearLayout.LayoutParams(android.view.ViewGroup
				.LayoutParams.WRAP_CONTENT, android.view.ViewGroup.LayoutParams.MATCH_PARENT));
			spinner.setOnItemSelectedListener(this);
			return spinner;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onConfigurationChanged(android.content.res.Configuration
			 newConfig)
		{
			base.onConfigurationChanged(newConfig);
			// Action bar can change size on configuration changes.
			// Reread the desired height from the theme-specified style.
			android.content.res.TypedArray a = getContext().obtainStyledAttributes(null, android.@internal.R
				.styleable.ActionBar, android.@internal.R.attr.actionBarStyle, 0);
			setContentHeight(a.getLayoutDimension(android.@internal.R.styleable.ActionBar_height
				, 0));
			a.recycle();
		}

		public virtual void animateToVisibility(int visibility)
		{
			if (mVisibilityAnim != null)
			{
				mVisibilityAnim.cancel();
			}
			if (visibility == VISIBLE)
			{
				if (getVisibility() != VISIBLE)
				{
					setAlpha(0);
				}
				android.animation.ObjectAnimator anim = android.animation.ObjectAnimator.ofFloat(
					this, "alpha", 1);
				anim.setDuration(FADE_DURATION);
				anim.setInterpolator(sAlphaInterpolator);
				anim.addListener(mVisAnimListener.withFinalVisibility(visibility));
				anim.start();
			}
			else
			{
				android.animation.ObjectAnimator anim = android.animation.ObjectAnimator.ofFloat(
					this, "alpha", 0);
				anim.setDuration(FADE_DURATION);
				anim.setInterpolator(sAlphaInterpolator);
				anim.addListener(mVisAnimListener.withFinalVisibility(visibility));
				anim.start();
			}
		}

		private sealed class _Runnable_244 : java.lang.Runnable
		{
			public _Runnable_244(ScrollingTabContainerView _enclosing, android.view.View tabView
				)
			{
				this._enclosing = _enclosing;
				this.tabView = tabView;
			}

			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public void run()
			{
				int scrollPos = tabView.getLeft() - (this._enclosing.getWidth() - tabView.getWidth
					()) / 2;
				this._enclosing.smoothScrollTo(scrollPos, 0);
				this._enclosing.mTabSelector = null;
			}

			private readonly ScrollingTabContainerView _enclosing;

			private readonly android.view.View tabView;
		}

		public virtual void animateToTab(int position)
		{
			android.view.View tabView = mTabLayout.getChildAt(position);
			if (mTabSelector != null)
			{
				removeCallbacks(mTabSelector);
			}
			mTabSelector = new _Runnable_244(this, tabView);
			post(mTabSelector);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onAttachedToWindow()
		{
			base.onAttachedToWindow();
			if (mTabSelector != null)
			{
				// Re-post the selector we saved
				post(mTabSelector);
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onDetachedFromWindow()
		{
			base.onDetachedFromWindow();
			if (mTabSelector != null)
			{
				removeCallbacks(mTabSelector);
			}
		}

		private android.widget.@internal.ScrollingTabContainerView.TabView createTabView(
			android.app.ActionBar.Tab tab, bool forAdapter)
		{
			android.widget.@internal.ScrollingTabContainerView.TabView tabView = new android.widget.@internal.ScrollingTabContainerView
				.TabView(this, getContext(), tab, forAdapter);
			if (forAdapter)
			{
				tabView.setBackgroundDrawable(null);
				tabView.setLayoutParams(new android.widget.AbsListView.LayoutParams(android.view.ViewGroup
					.LayoutParams.MATCH_PARENT, mContentHeight));
			}
			else
			{
				tabView.setFocusable(true);
				if (mTabClickListener == null)
				{
					mTabClickListener = new android.widget.@internal.ScrollingTabContainerView.TabClickListener
						(this);
				}
				tabView.setOnClickListener(mTabClickListener);
			}
			return tabView;
		}

		public virtual void addTab(android.app.ActionBar.Tab tab, bool setSelected_1)
		{
			android.widget.@internal.ScrollingTabContainerView.TabView tabView = createTabView
				(tab, false);
			mTabLayout.addView(tabView, new android.widget.LinearLayout.LayoutParams(0, android.view.ViewGroup
				.LayoutParams.MATCH_PARENT, 1));
			if (mTabSpinner != null)
			{
				((android.widget.@internal.ScrollingTabContainerView.TabAdapter)mTabSpinner.getAdapter
					()).notifyDataSetChanged();
			}
			if (setSelected_1)
			{
				tabView.setSelected(true);
			}
			if (mAllowCollapse)
			{
				requestLayout();
			}
		}

		public virtual void addTab(android.app.ActionBar.Tab tab, int position, bool setSelected_1
			)
		{
			android.widget.@internal.ScrollingTabContainerView.TabView tabView = createTabView
				(tab, false);
			mTabLayout.addView(tabView, position, new android.widget.LinearLayout.LayoutParams
				(0, android.view.ViewGroup.LayoutParams.MATCH_PARENT, 1));
			if (mTabSpinner != null)
			{
				((android.widget.@internal.ScrollingTabContainerView.TabAdapter)mTabSpinner.getAdapter
					()).notifyDataSetChanged();
			}
			if (setSelected_1)
			{
				tabView.setSelected(true);
			}
			if (mAllowCollapse)
			{
				requestLayout();
			}
		}

		public virtual void updateTab(int position)
		{
			((android.widget.@internal.ScrollingTabContainerView.TabView)mTabLayout.getChildAt
				(position)).update();
			if (mTabSpinner != null)
			{
				((android.widget.@internal.ScrollingTabContainerView.TabAdapter)mTabSpinner.getAdapter
					()).notifyDataSetChanged();
			}
			if (mAllowCollapse)
			{
				requestLayout();
			}
		}

		public virtual void removeTabAt(int position)
		{
			mTabLayout.removeViewAt(position);
			if (mTabSpinner != null)
			{
				((android.widget.@internal.ScrollingTabContainerView.TabAdapter)mTabSpinner.getAdapter
					()).notifyDataSetChanged();
			}
			if (mAllowCollapse)
			{
				requestLayout();
			}
		}

		public virtual void removeAllTabs()
		{
			mTabLayout.removeAllViews();
			if (mTabSpinner != null)
			{
				((android.widget.@internal.ScrollingTabContainerView.TabAdapter)mTabSpinner.getAdapter
					()).notifyDataSetChanged();
			}
			if (mAllowCollapse)
			{
				requestLayout();
			}
		}

		[Sharpen.ImplementsInterface(@"android.widget.AdapterView.OnItemSelectedListener"
			)]
		public virtual void onItemSelected(object parent, android.view.View view, int position
			, long id)
		{
			android.widget.@internal.ScrollingTabContainerView.TabView tabView = (android.widget.@internal.ScrollingTabContainerView
				.TabView)view;
			tabView.getTab().select();
		}

		[Sharpen.ImplementsInterface(@"android.widget.AdapterView.OnItemSelectedListener"
			)]
		public virtual void onNothingSelected(object parent)
		{
		}

		private class TabView : android.widget.LinearLayout
		{
			internal android.app.ActionBar.Tab mTab;

			internal android.widget.TextView mTextView;

			internal android.widget.ImageView mIconView;

			internal android.view.View mCustomView;

			public TabView(ScrollingTabContainerView _enclosing, android.content.Context context
				, android.app.ActionBar.Tab tab, bool forList) : base(context, null, android.@internal.R
				.attr.actionBarTabStyle)
			{
				this._enclosing = _enclosing;
				this.mTab = tab;
				if (forList)
				{
					this.setGravity(android.view.Gravity.LEFT | android.view.Gravity.CENTER_VERTICAL);
				}
				this.update();
			}

			public virtual void bindTab(android.app.ActionBar.Tab tab)
			{
				this.mTab = tab;
				this.update();
			}

			[Sharpen.OverridesMethod(@"android.view.View")]
			protected internal override void onMeasure(int widthMeasureSpec, int heightMeasureSpec
				)
			{
				base.onMeasure(widthMeasureSpec, heightMeasureSpec);
				// Re-measure if we went beyond our maximum size.
				if (this._enclosing.mMaxTabWidth > 0 && this.getMeasuredWidth() > this._enclosing
					.mMaxTabWidth)
				{
					base.onMeasure(android.view.View.MeasureSpec.makeMeasureSpec(this._enclosing.mMaxTabWidth
						, android.view.View.MeasureSpec.EXACTLY), heightMeasureSpec);
				}
			}

			public virtual void update()
			{
				android.app.ActionBar.Tab tab = this.mTab;
				android.view.View custom = tab.getCustomView();
				if (custom != null)
				{
					this.addView(custom);
					this.mCustomView = custom;
					if (this.mTextView != null)
					{
						this.mTextView.setVisibility(android.view.View.GONE);
					}
					if (this.mIconView != null)
					{
						this.mIconView.setVisibility(android.view.View.GONE);
						this.mIconView.setImageDrawable(null);
					}
				}
				else
				{
					if (this.mCustomView != null)
					{
						this.removeView(this.mCustomView);
						this.mCustomView = null;
					}
					android.graphics.drawable.Drawable icon = tab.getIcon();
					java.lang.CharSequence text = tab.getText();
					if (icon != null)
					{
						if (this.mIconView == null)
						{
							android.widget.ImageView iconView = new android.widget.ImageView(this.getContext(
								));
							android.widget.LinearLayout.LayoutParams lp = new android.widget.LinearLayout.LayoutParams
								(android.view.ViewGroup.LayoutParams.WRAP_CONTENT, android.view.ViewGroup.LayoutParams
								.WRAP_CONTENT);
							lp.gravity = android.view.Gravity.CENTER_VERTICAL;
							iconView.setLayoutParams(lp);
							this.addView(iconView, 0);
							this.mIconView = iconView;
						}
						this.mIconView.setImageDrawable(icon);
						this.mIconView.setVisibility(android.view.View.VISIBLE);
					}
					else
					{
						if (this.mIconView != null)
						{
							this.mIconView.setVisibility(android.view.View.GONE);
							this.mIconView.setImageDrawable(null);
						}
					}
					if (text != null)
					{
						if (this.mTextView == null)
						{
							android.widget.TextView textView = new android.widget.TextView(this.getContext(), 
								null, android.@internal.R.attr.actionBarTabTextStyle);
							textView.setEllipsize(android.text.TextUtils.TruncateAt.END);
							android.widget.LinearLayout.LayoutParams lp = new android.widget.LinearLayout.LayoutParams
								(android.view.ViewGroup.LayoutParams.WRAP_CONTENT, android.view.ViewGroup.LayoutParams
								.WRAP_CONTENT);
							lp.gravity = android.view.Gravity.CENTER_VERTICAL;
							textView.setLayoutParams(lp);
							this.addView(textView);
							this.mTextView = textView;
						}
						this.mTextView.setText(text);
						this.mTextView.setVisibility(android.view.View.VISIBLE);
					}
					else
					{
						if (this.mTextView != null)
						{
							this.mTextView.setVisibility(android.view.View.GONE);
							this.mTextView.setText(null);
						}
					}
					if (this.mIconView != null)
					{
						this.mIconView.setContentDescription(tab.getContentDescription());
					}
				}
			}

			public virtual android.app.ActionBar.Tab getTab()
			{
				return this.mTab;
			}

			private readonly ScrollingTabContainerView _enclosing;
		}

		private class TabAdapter : android.widget.BaseAdapter
		{
			[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
			public override int getCount()
			{
				return this._enclosing.mTabLayout.getChildCount();
			}

			[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
			public override object getItem(int position)
			{
				return ((android.widget.@internal.ScrollingTabContainerView.TabView)this._enclosing
					.mTabLayout.getChildAt(position)).getTab();
			}

			[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
			public override long getItemId(int position)
			{
				return position;
			}

			[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
			public override android.view.View getView(int position, android.view.View convertView
				, android.view.ViewGroup parent)
			{
				if (convertView == null)
				{
					convertView = this._enclosing.createTabView((android.app.ActionBar.Tab)this.getItem
						(position), true);
				}
				else
				{
					((android.widget.@internal.ScrollingTabContainerView.TabView)convertView).bindTab
						((android.app.ActionBar.Tab)this.getItem(position));
				}
				return convertView;
			}

			internal TabAdapter(ScrollingTabContainerView _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly ScrollingTabContainerView _enclosing;
		}

		private class TabClickListener : android.view.View.OnClickListener
		{
			[Sharpen.ImplementsInterface(@"android.view.View.OnClickListener")]
			public virtual void onClick(android.view.View view)
			{
				android.widget.@internal.ScrollingTabContainerView.TabView tabView = (android.widget.@internal.ScrollingTabContainerView
					.TabView)view;
				tabView.getTab().select();
				int tabCount = this._enclosing.mTabLayout.getChildCount();
				{
					for (int i = 0; i < tabCount; i++)
					{
						android.view.View child = this._enclosing.mTabLayout.getChildAt(i);
						child.setSelected(child == view);
					}
				}
			}

			internal TabClickListener(ScrollingTabContainerView _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly ScrollingTabContainerView _enclosing;
		}

		protected internal class VisibilityAnimListener : android.animation.Animator.AnimatorListener
		{
			private bool mCanceled;

			private int mFinalVisibility;

			internal virtual android.widget.@internal.ScrollingTabContainerView.VisibilityAnimListener
				 withFinalVisibility(int visibility)
			{
				this.mFinalVisibility = visibility;
				return this;
			}

			[Sharpen.ImplementsInterface(@"android.animation.Animator.AnimatorListener")]
			public virtual void onAnimationStart(android.animation.Animator animation)
			{
				this._enclosing.setVisibility(android.view.View.VISIBLE);
				this._enclosing.mVisibilityAnim = animation;
				this.mCanceled = false;
			}

			[Sharpen.ImplementsInterface(@"android.animation.Animator.AnimatorListener")]
			public virtual void onAnimationEnd(android.animation.Animator animation)
			{
				if (this.mCanceled)
				{
					return;
				}
				this._enclosing.mVisibilityAnim = null;
				this._enclosing.setVisibility(this.mFinalVisibility);
			}

			[Sharpen.ImplementsInterface(@"android.animation.Animator.AnimatorListener")]
			public virtual void onAnimationCancel(android.animation.Animator animation)
			{
				this.mCanceled = true;
			}

			[Sharpen.ImplementsInterface(@"android.animation.Animator.AnimatorListener")]
			public virtual void onAnimationRepeat(android.animation.Animator animation)
			{
			}

			public VisibilityAnimListener(ScrollingTabContainerView _enclosing)
			{
				this._enclosing = _enclosing;
				mCanceled = false;
			}

			private readonly ScrollingTabContainerView _enclosing;
		}
	}
}

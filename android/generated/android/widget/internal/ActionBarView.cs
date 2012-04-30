using Sharpen;

namespace android.widget.@internal
{
	/// <hide></hide>
	[Sharpen.Sharpened]
	public class ActionBarView : android.widget.@internal.AbsActionBarView
	{
		internal const string TAG = "ActionBarView";

		/// <summary>Display options applied by default</summary>
		public const int DISPLAY_DEFAULT = 0;

		/// <summary>Display options that require re-layout as opposed to a simple invalidate
		/// 	</summary>
		internal const int DISPLAY_RELAYOUT_MASK = android.app.ActionBar.DISPLAY_SHOW_HOME
			 | android.app.ActionBar.DISPLAY_USE_LOGO | android.app.ActionBar.DISPLAY_HOME_AS_UP
			 | android.app.ActionBar.DISPLAY_SHOW_CUSTOM | android.app.ActionBar.DISPLAY_SHOW_TITLE;

		internal const int DEFAULT_CUSTOM_GRAVITY = android.view.Gravity.LEFT | android.view.Gravity
			.CENTER_VERTICAL;

		private int mNavigationMode;

		private int mDisplayOptions = -1;

		private java.lang.CharSequence mTitle;

		private java.lang.CharSequence mSubtitle;

		private android.graphics.drawable.Drawable mIcon;

		private android.graphics.drawable.Drawable mLogo;

		private android.widget.@internal.ActionBarView.HomeView mHomeLayout;

		private android.widget.@internal.ActionBarView.HomeView mExpandedHomeLayout;

		private android.widget.LinearLayout mTitleLayout;

		private android.widget.TextView mTitleView;

		private android.widget.TextView mSubtitleView;

		private android.view.View mTitleUpView;

		private android.widget.Spinner mSpinner;

		private android.widget.LinearLayout mListNavLayout;

		private android.widget.@internal.ScrollingTabContainerView mTabScrollView;

		private android.view.View mCustomNavView;

		private android.widget.ProgressBar mProgressView;

		private android.widget.ProgressBar mIndeterminateProgressView;

		private int mProgressBarPadding;

		private int mItemPadding;

		private int mTitleStyleRes;

		private int mSubtitleStyleRes;

		private int mProgressStyle;

		private int mIndeterminateProgressStyle;

		private bool mUserTitle;

		private bool mIncludeTabs;

		private bool mIsCollapsable;

		private bool mIsCollapsed;

		private android.view.@internal.menu.MenuBuilder mOptionsMenu;

		private android.widget.@internal.ActionBarContextView mContextView;

		private android.view.@internal.menu.ActionMenuItem mLogoNavItem;

		private android.widget.SpinnerAdapter mSpinnerAdapter;

		private android.app.ActionBar.OnNavigationListener mCallback;

		private java.lang.Runnable mTabSelector;

		private android.widget.@internal.ActionBarView.ExpandedActionViewMenuPresenter mExpandedMenuPresenter;

		internal android.view.View mExpandedActionView;

		internal android.view.Window.Callback mWindowCallback;

		private sealed class _OnItemSelectedListener_138 : android.widget.AdapterView.OnItemSelectedListener
		{
			public _OnItemSelectedListener_138(ActionBarView _enclosing)
			{
				this._enclosing = _enclosing;
			}

			[Sharpen.ImplementsInterface(@"android.widget.AdapterView.OnItemSelectedListener"
				)]
			public void onItemSelected(object parent, android.view.View view, int position, long
				 id)
			{
				if (this._enclosing.mCallback != null)
				{
					this._enclosing.mCallback.onNavigationItemSelected(position, id);
				}
			}

			[Sharpen.ImplementsInterface(@"android.widget.AdapterView.OnItemSelectedListener"
				)]
			public void onNothingSelected(object parent)
			{
			}

			private readonly ActionBarView _enclosing;
		}

		private readonly android.widget.AdapterView.OnItemSelectedListener mNavItemSelectedListener;

		private sealed class _OnClickListener_149 : android.view.View.OnClickListener
		{
			public _OnClickListener_149(ActionBarView _enclosing)
			{
				this._enclosing = _enclosing;
			}

			// Do nothing
			[Sharpen.ImplementsInterface(@"android.view.View.OnClickListener")]
			public void onClick(android.view.View v)
			{
				android.view.@internal.menu.MenuItemImpl item = this._enclosing.mExpandedMenuPresenter
					.mCurrentExpandedItem;
				if (item != null)
				{
					item.collapseActionView();
				}
			}

			private readonly ActionBarView _enclosing;
		}

		private readonly android.view.View.OnClickListener mExpandedActionViewUpListener;

		private sealed class _OnClickListener_159 : android.view.View.OnClickListener
		{
			public _OnClickListener_159(ActionBarView _enclosing)
			{
				this._enclosing = _enclosing;
			}

			[Sharpen.ImplementsInterface(@"android.view.View.OnClickListener")]
			public void onClick(android.view.View v)
			{
				this._enclosing.mWindowCallback.onMenuItemSelected(android.view.Window.FEATURE_OPTIONS_PANEL
					, this._enclosing.mLogoNavItem);
			}

			private readonly ActionBarView _enclosing;
		}

		private readonly android.view.View.OnClickListener mUpClickListener;

		public ActionBarView(android.content.Context context, android.util.AttributeSet attrs
			) : base(context, attrs)
		{
			mNavItemSelectedListener = new _OnItemSelectedListener_138(this);
			mExpandedActionViewUpListener = new _OnClickListener_149(this);
			mUpClickListener = new _OnClickListener_159(this);
			// Background is always provided by the container.
			setBackgroundResource(0);
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.ActionBar, android.@internal.R.attr.actionBarStyle, 0);
			android.content.pm.ApplicationInfo appInfo = context.getApplicationInfo();
			android.content.pm.PackageManager pm = context.getPackageManager();
			mNavigationMode = a.getInt(android.@internal.R.styleable.ActionBar_navigationMode
				, android.app.ActionBar.NAVIGATION_MODE_STANDARD);
			mTitle = a.getText(android.@internal.R.styleable.ActionBar_title);
			mSubtitle = a.getText(android.@internal.R.styleable.ActionBar_subtitle);
			mLogo = a.getDrawable(android.@internal.R.styleable.ActionBar_logo);
			if (mLogo == null)
			{
				if (context is android.app.Activity)
				{
					try
					{
						mLogo = pm.getActivityLogo(((android.app.Activity)context).getComponentName());
					}
					catch (android.content.pm.PackageManager.NameNotFoundException e)
					{
						android.util.Log.e(TAG, "Activity component name not found!", e);
					}
				}
				if (mLogo == null)
				{
					mLogo = appInfo.loadLogo(pm);
				}
			}
			mIcon = a.getDrawable(android.@internal.R.styleable.ActionBar_icon);
			if (mIcon == null)
			{
				if (context is android.app.Activity)
				{
					try
					{
						mIcon = pm.getActivityIcon(((android.app.Activity)context).getComponentName());
					}
					catch (android.content.pm.PackageManager.NameNotFoundException e)
					{
						android.util.Log.e(TAG, "Activity component name not found!", e);
					}
				}
				if (mIcon == null)
				{
					mIcon = appInfo.loadIcon(pm);
				}
			}
			android.view.LayoutInflater inflater = android.view.LayoutInflater.from(context);
			int homeResId = a.getResourceId(android.@internal.R.styleable.ActionBar_homeLayout
				, android.@internal.R.layout.action_bar_home);
			mHomeLayout = (android.widget.@internal.ActionBarView.HomeView)inflater.inflate(homeResId
				, this, false);
			mExpandedHomeLayout = (android.widget.@internal.ActionBarView.HomeView)inflater.inflate
				(homeResId, this, false);
			mExpandedHomeLayout.setUp(true);
			mExpandedHomeLayout.setOnClickListener(mExpandedActionViewUpListener);
			mExpandedHomeLayout.setContentDescription(getResources().getText(android.@internal.R
				.@string.action_bar_up_description));
			mTitleStyleRes = a.getResourceId(android.@internal.R.styleable.ActionBar_titleTextStyle
				, 0);
			mSubtitleStyleRes = a.getResourceId(android.@internal.R.styleable.ActionBar_subtitleTextStyle
				, 0);
			mProgressStyle = a.getResourceId(android.@internal.R.styleable.ActionBar_progressBarStyle
				, 0);
			mIndeterminateProgressStyle = a.getResourceId(android.@internal.R.styleable.ActionBar_indeterminateProgressStyle
				, 0);
			mProgressBarPadding = a.getDimensionPixelOffset(android.@internal.R.styleable.ActionBar_progressBarPadding
				, 0);
			mItemPadding = a.getDimensionPixelOffset(android.@internal.R.styleable.ActionBar_itemPadding
				, 0);
			setDisplayOptions(a.getInt(android.@internal.R.styleable.ActionBar_displayOptions
				, DISPLAY_DEFAULT));
			int customNavId = a.getResourceId(android.@internal.R.styleable.ActionBar_customNavigationLayout
				, 0);
			if (customNavId != 0)
			{
				mCustomNavView = (android.view.View)inflater.inflate(customNavId, this, false);
				mNavigationMode = android.app.ActionBar.NAVIGATION_MODE_STANDARD;
				setDisplayOptions(mDisplayOptions | android.app.ActionBar.DISPLAY_SHOW_CUSTOM);
			}
			mContentHeight = a.getLayoutDimension(android.@internal.R.styleable.ActionBar_height
				, 0);
			a.recycle();
			mLogoNavItem = new android.view.@internal.menu.ActionMenuItem(context, 0, android.R
				.id.home, 0, 0, mTitle);
			mHomeLayout.setOnClickListener(mUpClickListener);
			mHomeLayout.setClickable(true);
			mHomeLayout.setFocusable(true);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onConfigurationChanged(android.content.res.Configuration
			 newConfig)
		{
			base.onConfigurationChanged(newConfig);
			mTitleView = null;
			mSubtitleView = null;
			mTitleUpView = null;
			if (mTitleLayout != null && mTitleLayout.getParent() == this)
			{
				removeView(mTitleLayout);
			}
			mTitleLayout = null;
			if ((mDisplayOptions & android.app.ActionBar.DISPLAY_SHOW_TITLE) != 0)
			{
				initTitle();
			}
			if (mTabScrollView != null && mIncludeTabs)
			{
				android.view.ViewGroup.LayoutParams lp = mTabScrollView.getLayoutParams();
				if (lp != null)
				{
					lp.width = android.view.ViewGroup.LayoutParams.WRAP_CONTENT;
					lp.height = android.view.ViewGroup.LayoutParams.MATCH_PARENT;
				}
				mTabScrollView.setAllowCollapse(true);
			}
		}

		/// <summary>Set the window callback used to invoke menu items; used for dispatching home button presses.
		/// 	</summary>
		/// <remarks>Set the window callback used to invoke menu items; used for dispatching home button presses.
		/// 	</remarks>
		/// <param name="cb">Window callback to dispatch to</param>
		public virtual void setWindowCallback(android.view.Window.Callback cb)
		{
			mWindowCallback = cb;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onDetachedFromWindow()
		{
			base.onDetachedFromWindow();
			removeCallbacks(mTabSelector);
			if (mActionMenuPresenter != null)
			{
				mActionMenuPresenter.hideOverflowMenu();
				mActionMenuPresenter.hideSubMenus();
			}
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override bool shouldDelayChildPressedState()
		{
			return false;
		}

		public virtual void initProgress()
		{
			mProgressView = new android.widget.ProgressBar(mContext, null, 0, mProgressStyle);
			mProgressView.setId(android.@internal.R.id.progress_horizontal);
			mProgressView.setMax(10000);
			addView(mProgressView);
		}

		public virtual void initIndeterminateProgress()
		{
			mIndeterminateProgressView = new android.widget.ProgressBar(mContext, null, 0, mIndeterminateProgressStyle
				);
			mIndeterminateProgressView.setId(android.@internal.R.id.progress_circular);
			addView(mIndeterminateProgressView);
		}

		[Sharpen.OverridesMethod(@"com.android.internal.widget.AbsActionBarView")]
		public override void setSplitActionBar(bool splitActionBar)
		{
			if (mSplitActionBar != splitActionBar)
			{
				if (mMenuView != null)
				{
					android.view.ViewGroup oldParent = (android.view.ViewGroup)mMenuView.getParent();
					if (oldParent != null)
					{
						oldParent.removeView(mMenuView);
					}
					if (splitActionBar)
					{
						if (mSplitView != null)
						{
							mSplitView.addView(mMenuView);
						}
					}
					else
					{
						addView(mMenuView);
					}
				}
				if (mSplitView != null)
				{
					mSplitView.setVisibility(splitActionBar ? VISIBLE : GONE);
				}
				base.setSplitActionBar(splitActionBar);
			}
		}

		public virtual bool isSplitActionBar()
		{
			return mSplitActionBar;
		}

		public virtual bool hasEmbeddedTabs()
		{
			return mIncludeTabs;
		}

		public virtual void setEmbeddedTabView(android.widget.@internal.ScrollingTabContainerView
			 tabs)
		{
			if (mTabScrollView != null)
			{
				removeView(mTabScrollView);
			}
			mTabScrollView = tabs;
			mIncludeTabs = tabs != null;
			if (mIncludeTabs && mNavigationMode == android.app.ActionBar.NAVIGATION_MODE_TABS)
			{
				addView(mTabScrollView);
				android.view.ViewGroup.LayoutParams lp = mTabScrollView.getLayoutParams();
				lp.width = android.view.ViewGroup.LayoutParams.WRAP_CONTENT;
				lp.height = android.view.ViewGroup.LayoutParams.MATCH_PARENT;
				tabs.setAllowCollapse(true);
			}
		}

		public virtual void setCallback(android.app.ActionBar.OnNavigationListener callback
			)
		{
			mCallback = callback;
		}

		public virtual void setMenu(android.view.Menu menu, android.view.@internal.menu.MenuPresenterClass
			.Callback cb)
		{
			if (menu == mOptionsMenu)
			{
				return;
			}
			if (mOptionsMenu != null)
			{
				mOptionsMenu.removeMenuPresenter(mActionMenuPresenter);
				mOptionsMenu.removeMenuPresenter(mExpandedMenuPresenter);
			}
			android.view.@internal.menu.MenuBuilder builder = (android.view.@internal.menu.MenuBuilder
				)menu;
			mOptionsMenu = builder;
			if (mMenuView != null)
			{
				android.view.ViewGroup oldParent = (android.view.ViewGroup)mMenuView.getParent();
				if (oldParent != null)
				{
					oldParent.removeView(mMenuView);
				}
			}
			if (mActionMenuPresenter == null)
			{
				mActionMenuPresenter = new android.view.@internal.menu.ActionMenuPresenter(mContext
					);
				mActionMenuPresenter.setCallback(cb);
				mActionMenuPresenter.setId(android.@internal.R.id.action_menu_presenter);
				mExpandedMenuPresenter = new android.widget.@internal.ActionBarView.ExpandedActionViewMenuPresenter
					(this);
			}
			android.view.@internal.menu.ActionMenuView menuView;
			android.view.ViewGroup.LayoutParams layoutParams = new android.view.ViewGroup.LayoutParams
				(android.view.ViewGroup.LayoutParams.WRAP_CONTENT, android.view.ViewGroup.LayoutParams
				.MATCH_PARENT);
			if (!mSplitActionBar)
			{
				mActionMenuPresenter.setExpandedActionViewsExclusive(getResources().getBoolean(android.@internal.R
					.@bool.action_bar_expanded_action_views_exclusive));
				configPresenters(builder);
				menuView = (android.view.@internal.menu.ActionMenuView)mActionMenuPresenter.getMenuView
					(this);
				android.view.ViewGroup oldParent = (android.view.ViewGroup)menuView.getParent();
				if (oldParent != null && oldParent != this)
				{
					oldParent.removeView(menuView);
				}
				addView(menuView, layoutParams);
			}
			else
			{
				mActionMenuPresenter.setExpandedActionViewsExclusive(false);
				// Allow full screen width in split mode.
				mActionMenuPresenter.setWidthLimit(getContext().getResources().getDisplayMetrics(
					).widthPixels, true);
				// No limit to the item count; use whatever will fit.
				mActionMenuPresenter.setItemLimit(int.MaxValue);
				// Span the whole width
				layoutParams.width = android.view.ViewGroup.LayoutParams.MATCH_PARENT;
				configPresenters(builder);
				menuView = (android.view.@internal.menu.ActionMenuView)mActionMenuPresenter.getMenuView
					(this);
				if (mSplitView != null)
				{
					android.view.ViewGroup oldParent = (android.view.ViewGroup)menuView.getParent();
					if (oldParent != null && oldParent != mSplitView)
					{
						oldParent.removeView(menuView);
					}
					menuView.setVisibility(getAnimatedVisibility());
					mSplitView.addView(menuView, layoutParams);
				}
				else
				{
					// We'll add this later if we missed it this time.
					menuView.setLayoutParams(layoutParams);
				}
			}
			mMenuView = menuView;
		}

		private void configPresenters(android.view.@internal.menu.MenuBuilder builder)
		{
			if (builder != null)
			{
				builder.addMenuPresenter(mActionMenuPresenter);
				builder.addMenuPresenter(mExpandedMenuPresenter);
			}
			else
			{
				mActionMenuPresenter.initForMenu(mContext, null);
				mExpandedMenuPresenter.initForMenu(mContext, null);
				mActionMenuPresenter.updateMenuView(true);
				mExpandedMenuPresenter.updateMenuView(true);
			}
		}

		public virtual bool hasExpandedActionView()
		{
			return mExpandedMenuPresenter != null && mExpandedMenuPresenter.mCurrentExpandedItem
				 != null;
		}

		public virtual void collapseActionView()
		{
			android.view.@internal.menu.MenuItemImpl item = mExpandedMenuPresenter == null ? 
				null : mExpandedMenuPresenter.mCurrentExpandedItem;
			if (item != null)
			{
				item.collapseActionView();
			}
		}

		public virtual void setCustomNavigationView(android.view.View view)
		{
			bool showCustom = (mDisplayOptions & android.app.ActionBar.DISPLAY_SHOW_CUSTOM) !=
				 0;
			if (mCustomNavView != null && showCustom)
			{
				removeView(mCustomNavView);
			}
			mCustomNavView = view;
			if (mCustomNavView != null && showCustom)
			{
				addView(mCustomNavView);
			}
		}

		public virtual java.lang.CharSequence getTitle()
		{
			return mTitle;
		}

		/// <summary>Set the action bar title.</summary>
		/// <remarks>Set the action bar title. This will always replace or override window titles.
		/// 	</remarks>
		/// <param name="title">Title to set</param>
		/// <seealso cref="setWindowTitle(java.lang.CharSequence)">setWindowTitle(java.lang.CharSequence)
		/// 	</seealso>
		public virtual void setTitle(java.lang.CharSequence title)
		{
			mUserTitle = true;
			setTitleImpl(title);
		}

		/// <summary>Set the window title.</summary>
		/// <remarks>Set the window title. A window title will always be replaced or overridden by a user title.
		/// 	</remarks>
		/// <param name="title">Title to set</param>
		/// <seealso cref="setTitle(java.lang.CharSequence)">setTitle(java.lang.CharSequence)
		/// 	</seealso>
		public virtual void setWindowTitle(java.lang.CharSequence title)
		{
			if (!mUserTitle)
			{
				setTitleImpl(title);
			}
		}

		private void setTitleImpl(java.lang.CharSequence title)
		{
			mTitle = title;
			if (mTitleView != null)
			{
				mTitleView.setText(title);
				bool visible = mExpandedActionView == null && (mDisplayOptions & android.app.ActionBar
					.DISPLAY_SHOW_TITLE) != 0 && (!android.text.TextUtils.isEmpty(mTitle) || !android.text.TextUtils
					.isEmpty(mSubtitle));
				mTitleLayout.setVisibility(visible ? VISIBLE : GONE);
			}
			if (mLogoNavItem != null)
			{
				mLogoNavItem.setTitle(title);
			}
		}

		public virtual java.lang.CharSequence getSubtitle()
		{
			return mSubtitle;
		}

		public virtual void setSubtitle(java.lang.CharSequence subtitle)
		{
			mSubtitle = subtitle;
			if (mSubtitleView != null)
			{
				mSubtitleView.setText(subtitle);
				mSubtitleView.setVisibility(subtitle != null ? VISIBLE : GONE);
				bool visible = mExpandedActionView == null && (mDisplayOptions & android.app.ActionBar
					.DISPLAY_SHOW_TITLE) != 0 && (!android.text.TextUtils.isEmpty(mTitle) || !android.text.TextUtils
					.isEmpty(mSubtitle));
				mTitleLayout.setVisibility(visible ? VISIBLE : GONE);
			}
		}

		public virtual void setHomeButtonEnabled(bool enable)
		{
			mHomeLayout.setEnabled(enable);
			// Make sure the home button has an accurate content description for accessibility.
			if (!enable)
			{
				mHomeLayout.setContentDescription(null);
			}
			else
			{
				if ((mDisplayOptions & android.app.ActionBar.DISPLAY_HOME_AS_UP) != 0)
				{
					mHomeLayout.setContentDescription(mContext.getResources().getText(android.@internal.R
						.@string.action_bar_up_description));
				}
				else
				{
					mHomeLayout.setContentDescription(mContext.getResources().getText(android.@internal.R
						.@string.action_bar_home_description));
				}
			}
		}

		public virtual void setDisplayOptions(int options)
		{
			int flagsChanged = mDisplayOptions == -1 ? -1 : options ^ mDisplayOptions;
			mDisplayOptions = options;
			if ((flagsChanged & DISPLAY_RELAYOUT_MASK) != 0)
			{
				bool showHome = (options & android.app.ActionBar.DISPLAY_SHOW_HOME) != 0;
				int vis = showHome ? VISIBLE : GONE;
				mHomeLayout.setVisibility(vis);
				if ((flagsChanged & android.app.ActionBar.DISPLAY_HOME_AS_UP) != 0)
				{
					bool setUp = (options & android.app.ActionBar.DISPLAY_HOME_AS_UP) != 0;
					mHomeLayout.setUp(setUp);
					// Showing home as up implicitly enables interaction with it.
					// In honeycomb it was always enabled, so make this transition
					// a bit easier for developers in the common case.
					// (It would be silly to show it as up without responding to it.)
					if (setUp)
					{
						setHomeButtonEnabled(true);
					}
				}
				if ((flagsChanged & android.app.ActionBar.DISPLAY_USE_LOGO) != 0)
				{
					bool logoVis = mLogo != null && (options & android.app.ActionBar.DISPLAY_USE_LOGO
						) != 0;
					mHomeLayout.setIcon(logoVis ? mLogo : mIcon);
				}
				if ((flagsChanged & android.app.ActionBar.DISPLAY_SHOW_TITLE) != 0)
				{
					if ((options & android.app.ActionBar.DISPLAY_SHOW_TITLE) != 0)
					{
						initTitle();
					}
					else
					{
						removeView(mTitleLayout);
					}
				}
				if (mTitleLayout != null && (flagsChanged & (android.app.ActionBar.DISPLAY_HOME_AS_UP
					 | android.app.ActionBar.DISPLAY_SHOW_HOME)) != 0)
				{
					bool homeAsUp = (mDisplayOptions & android.app.ActionBar.DISPLAY_HOME_AS_UP) != 0;
					mTitleUpView.setVisibility(!showHome ? (homeAsUp ? VISIBLE : INVISIBLE) : GONE);
					mTitleLayout.setEnabled(!showHome && homeAsUp);
				}
				if ((flagsChanged & android.app.ActionBar.DISPLAY_SHOW_CUSTOM) != 0 && mCustomNavView
					 != null)
				{
					if ((options & android.app.ActionBar.DISPLAY_SHOW_CUSTOM) != 0)
					{
						addView(mCustomNavView);
					}
					else
					{
						removeView(mCustomNavView);
					}
				}
				requestLayout();
			}
			else
			{
				invalidate();
			}
			// Make sure the home button has an accurate content description for accessibility.
			if (!mHomeLayout.isEnabled())
			{
				mHomeLayout.setContentDescription(null);
			}
			else
			{
				if ((options & android.app.ActionBar.DISPLAY_HOME_AS_UP) != 0)
				{
					mHomeLayout.setContentDescription(mContext.getResources().getText(android.@internal.R
						.@string.action_bar_up_description));
				}
				else
				{
					mHomeLayout.setContentDescription(mContext.getResources().getText(android.@internal.R
						.@string.action_bar_home_description));
				}
			}
		}

		public virtual void setIcon(android.graphics.drawable.Drawable icon)
		{
			mIcon = icon;
			if (icon != null && ((mDisplayOptions & android.app.ActionBar.DISPLAY_USE_LOGO) ==
				 0 || mLogo == null))
			{
				mHomeLayout.setIcon(icon);
			}
		}

		public virtual void setIcon(int resId)
		{
			setIcon(mContext.getResources().getDrawable(resId));
		}

		public virtual void setLogo(android.graphics.drawable.Drawable logo)
		{
			mLogo = logo;
			if (logo != null && (mDisplayOptions & android.app.ActionBar.DISPLAY_USE_LOGO) !=
				 0)
			{
				mHomeLayout.setIcon(logo);
			}
		}

		public virtual void setLogo(int resId)
		{
			setLogo(mContext.getResources().getDrawable(resId));
		}

		public virtual void setNavigationMode(int mode)
		{
			int oldMode = mNavigationMode;
			if (mode != oldMode)
			{
				switch (oldMode)
				{
					case android.app.ActionBar.NAVIGATION_MODE_LIST:
					{
						if (mListNavLayout != null)
						{
							removeView(mListNavLayout);
						}
						break;
					}

					case android.app.ActionBar.NAVIGATION_MODE_TABS:
					{
						if (mTabScrollView != null && mIncludeTabs)
						{
							removeView(mTabScrollView);
						}
						break;
					}
				}
				switch (mode)
				{
					case android.app.ActionBar.NAVIGATION_MODE_LIST:
					{
						if (mSpinner == null)
						{
							mSpinner = new android.widget.Spinner(mContext, null, android.@internal.R.attr.actionDropDownStyle
								);
							mListNavLayout = new android.widget.LinearLayout(mContext, null, android.@internal.R
								.attr.actionBarTabBarStyle);
							android.widget.LinearLayout.LayoutParams @params = new android.widget.LinearLayout
								.LayoutParams(android.view.ViewGroup.LayoutParams.WRAP_CONTENT, android.view.ViewGroup
								.LayoutParams.MATCH_PARENT);
							@params.gravity = android.view.Gravity.CENTER;
							mListNavLayout.addView(mSpinner, @params);
						}
						if (mSpinner.getAdapter() != mSpinnerAdapter)
						{
							mSpinner.setAdapter(mSpinnerAdapter);
						}
						mSpinner.setOnItemSelectedListener(mNavItemSelectedListener);
						addView(mListNavLayout);
						break;
					}

					case android.app.ActionBar.NAVIGATION_MODE_TABS:
					{
						if (mTabScrollView != null && mIncludeTabs)
						{
							addView(mTabScrollView);
						}
						break;
					}
				}
				mNavigationMode = mode;
				requestLayout();
			}
		}

		public virtual void setDropdownAdapter(android.widget.SpinnerAdapter adapter)
		{
			mSpinnerAdapter = adapter;
			if (mSpinner != null)
			{
				mSpinner.setAdapter(adapter);
			}
		}

		public virtual android.widget.SpinnerAdapter getDropdownAdapter()
		{
			return mSpinnerAdapter;
		}

		public virtual void setDropdownSelectedPosition(int position)
		{
			mSpinner.setSelection(position);
		}

		public virtual int getDropdownSelectedPosition()
		{
			return mSpinner.getSelectedItemPosition();
		}

		public virtual android.view.View getCustomNavigationView()
		{
			return mCustomNavView;
		}

		public virtual int getNavigationMode()
		{
			return mNavigationMode;
		}

		public virtual int getDisplayOptions()
		{
			return mDisplayOptions;
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		protected internal override android.view.ViewGroup.LayoutParams generateDefaultLayoutParams
			()
		{
			// Used by custom nav views if they don't supply layout params. Everything else
			// added to an ActionBarView should have them already.
			return new android.app.ActionBar.LayoutParams(DEFAULT_CUSTOM_GRAVITY);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onFinishInflate()
		{
			base.onFinishInflate();
			addView(mHomeLayout);
			if (mCustomNavView != null && (mDisplayOptions & android.app.ActionBar.DISPLAY_SHOW_CUSTOM
				) != 0)
			{
				android.view.ViewParent parent = mCustomNavView.getParent();
				if (parent != this)
				{
					if (parent is android.view.ViewGroup)
					{
						((android.view.ViewGroup)parent).removeView(mCustomNavView);
					}
					addView(mCustomNavView);
				}
			}
		}

		private void initTitle()
		{
			if (mTitleLayout == null)
			{
				android.view.LayoutInflater inflater = android.view.LayoutInflater.from(getContext
					());
				mTitleLayout = (android.widget.LinearLayout)inflater.inflate(android.@internal.R.
					layout.action_bar_title_item, this, false);
				mTitleView = (android.widget.TextView)mTitleLayout.findViewById(android.@internal.R
					.id.action_bar_title);
				mSubtitleView = (android.widget.TextView)mTitleLayout.findViewById(android.@internal.R
					.id.action_bar_subtitle);
				mTitleUpView = (android.view.View)mTitleLayout.findViewById(android.@internal.R.id
					.up);
				mTitleLayout.setOnClickListener(mUpClickListener);
				if (mTitleStyleRes != 0)
				{
					mTitleView.setTextAppearance(mContext, mTitleStyleRes);
				}
				if (mTitle != null)
				{
					mTitleView.setText(mTitle);
				}
				if (mSubtitleStyleRes != 0)
				{
					mSubtitleView.setTextAppearance(mContext, mSubtitleStyleRes);
				}
				if (mSubtitle != null)
				{
					mSubtitleView.setText(mSubtitle);
					mSubtitleView.setVisibility(VISIBLE);
				}
				bool homeAsUp = (mDisplayOptions & android.app.ActionBar.DISPLAY_HOME_AS_UP) != 0;
				bool showHome = (mDisplayOptions & android.app.ActionBar.DISPLAY_SHOW_HOME) != 0;
				mTitleUpView.setVisibility(!showHome ? (homeAsUp ? VISIBLE : INVISIBLE) : GONE);
				mTitleLayout.setEnabled(homeAsUp && !showHome);
			}
			addView(mTitleLayout);
			if (mExpandedActionView != null || (android.text.TextUtils.isEmpty(mTitle) && android.text.TextUtils
				.isEmpty(mSubtitle)))
			{
				// Don't show while in expanded mode or with empty text
				mTitleLayout.setVisibility(GONE);
			}
		}

		public virtual void setContextView(android.widget.@internal.ActionBarContextView 
			view)
		{
			mContextView = view;
		}

		public virtual void setCollapsable(bool collapsable)
		{
			mIsCollapsable = collapsable;
		}

		public virtual bool isCollapsed()
		{
			return mIsCollapsed;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onMeasure(int widthMeasureSpec, int heightMeasureSpec
			)
		{
			int childCount = getChildCount();
			if (mIsCollapsable)
			{
				int visibleChildren = 0;
				{
					for (int i = 0; i < childCount; i++)
					{
						android.view.View child = getChildAt(i);
						if (child.getVisibility() != GONE && !(child == mMenuView && mMenuView.getChildCount
							() == 0))
						{
							visibleChildren++;
						}
					}
				}
				if (visibleChildren == 0)
				{
					// No size for an empty action bar when collapsable.
					setMeasuredDimension(0, 0);
					mIsCollapsed = true;
					return;
				}
			}
			mIsCollapsed = false;
			int widthMode = android.view.View.MeasureSpec.getMode(widthMeasureSpec);
			if (widthMode != android.view.View.MeasureSpec.EXACTLY)
			{
				throw new System.InvalidOperationException(GetType().Name + " can only be used " 
					+ "with android:layout_width=\"match_parent\" (or fill_parent)");
			}
			int heightMode = android.view.View.MeasureSpec.getMode(heightMeasureSpec);
			if (heightMode != android.view.View.MeasureSpec.AT_MOST)
			{
				throw new System.InvalidOperationException(GetType().Name + " can only be used " 
					+ "with android:layout_height=\"wrap_content\"");
			}
			int contentWidth = android.view.View.MeasureSpec.getSize(widthMeasureSpec);
			int maxHeight = mContentHeight > 0 ? mContentHeight : android.view.View.MeasureSpec
				.getSize(heightMeasureSpec);
			int verticalPadding = getPaddingTop() + getPaddingBottom();
			int paddingLeft = getPaddingLeft();
			int paddingRight = getPaddingRight();
			int height = maxHeight - verticalPadding;
			int childSpecHeight = android.view.View.MeasureSpec.makeMeasureSpec(height, android.view.View
				.MeasureSpec.AT_MOST);
			int availableWidth = contentWidth - paddingLeft - paddingRight;
			int leftOfCenter = availableWidth / 2;
			int rightOfCenter = leftOfCenter;
			android.widget.@internal.ActionBarView.HomeView homeLayout = mExpandedActionView 
				!= null ? mExpandedHomeLayout : mHomeLayout;
			if (homeLayout.getVisibility() != GONE)
			{
				android.view.ViewGroup.LayoutParams lp = homeLayout.getLayoutParams();
				int homeWidthSpec;
				if (lp.width < 0)
				{
					homeWidthSpec = android.view.View.MeasureSpec.makeMeasureSpec(availableWidth, android.view.View
						.MeasureSpec.AT_MOST);
				}
				else
				{
					homeWidthSpec = android.view.View.MeasureSpec.makeMeasureSpec(lp.width, android.view.View
						.MeasureSpec.EXACTLY);
				}
				homeLayout.measure(homeWidthSpec, android.view.View.MeasureSpec.makeMeasureSpec(height
					, android.view.View.MeasureSpec.EXACTLY));
				int homeWidth = homeLayout.getMeasuredWidth() + homeLayout.getLeftOffset();
				availableWidth = System.Math.Max(0, availableWidth - homeWidth);
				leftOfCenter = System.Math.Max(0, availableWidth - homeWidth);
			}
			if (mMenuView != null && mMenuView.getParent() == this)
			{
				availableWidth = measureChildView(mMenuView, availableWidth, childSpecHeight, 0);
				rightOfCenter = System.Math.Max(0, rightOfCenter - mMenuView.getMeasuredWidth());
			}
			if (mIndeterminateProgressView != null && mIndeterminateProgressView.getVisibility
				() != GONE)
			{
				availableWidth = measureChildView(mIndeterminateProgressView, availableWidth, childSpecHeight
					, 0);
				rightOfCenter = System.Math.Max(0, rightOfCenter - mIndeterminateProgressView.getMeasuredWidth
					());
			}
			bool showTitle = mTitleLayout != null && mTitleLayout.getVisibility() != GONE && 
				(mDisplayOptions & android.app.ActionBar.DISPLAY_SHOW_TITLE) != 0;
			if (mExpandedActionView == null)
			{
				switch (mNavigationMode)
				{
					case android.app.ActionBar.NAVIGATION_MODE_LIST:
					{
						if (mListNavLayout != null)
						{
							int itemPaddingSize = showTitle ? mItemPadding * 2 : mItemPadding;
							availableWidth = System.Math.Max(0, availableWidth - itemPaddingSize);
							leftOfCenter = System.Math.Max(0, leftOfCenter - itemPaddingSize);
							mListNavLayout.measure(android.view.View.MeasureSpec.makeMeasureSpec(availableWidth
								, android.view.View.MeasureSpec.AT_MOST), android.view.View.MeasureSpec.makeMeasureSpec
								(height, android.view.View.MeasureSpec.EXACTLY));
							int listNavWidth = mListNavLayout.getMeasuredWidth();
							availableWidth = System.Math.Max(0, availableWidth - listNavWidth);
							leftOfCenter = System.Math.Max(0, leftOfCenter - listNavWidth);
						}
						break;
					}

					case android.app.ActionBar.NAVIGATION_MODE_TABS:
					{
						if (mTabScrollView != null)
						{
							int itemPaddingSize = showTitle ? mItemPadding * 2 : mItemPadding;
							availableWidth = System.Math.Max(0, availableWidth - itemPaddingSize);
							leftOfCenter = System.Math.Max(0, leftOfCenter - itemPaddingSize);
							mTabScrollView.measure(android.view.View.MeasureSpec.makeMeasureSpec(availableWidth
								, android.view.View.MeasureSpec.AT_MOST), android.view.View.MeasureSpec.makeMeasureSpec
								(height, android.view.View.MeasureSpec.EXACTLY));
							int tabWidth = mTabScrollView.getMeasuredWidth();
							availableWidth = System.Math.Max(0, availableWidth - tabWidth);
							leftOfCenter = System.Math.Max(0, leftOfCenter - tabWidth);
						}
						break;
					}
				}
			}
			android.view.View customView = null;
			if (mExpandedActionView != null)
			{
				customView = mExpandedActionView;
			}
			else
			{
				if ((mDisplayOptions & android.app.ActionBar.DISPLAY_SHOW_CUSTOM) != 0 && mCustomNavView
					 != null)
				{
					customView = mCustomNavView;
				}
			}
			if (customView != null)
			{
				android.view.ViewGroup.LayoutParams lp = generateLayoutParams(customView.getLayoutParams
					());
				android.app.ActionBar.LayoutParams ablp = lp is android.app.ActionBar.LayoutParams
					 ? (android.app.ActionBar.LayoutParams)lp : null;
				int horizontalMargin = 0;
				int verticalMargin = 0;
				if (ablp != null)
				{
					horizontalMargin = ablp.leftMargin + ablp.rightMargin;
					verticalMargin = ablp.topMargin + ablp.bottomMargin;
				}
				// If the action bar is wrapping to its content height, don't allow a custom
				// view to MATCH_PARENT.
				int customNavHeightMode;
				if (mContentHeight <= 0)
				{
					customNavHeightMode = android.view.View.MeasureSpec.AT_MOST;
				}
				else
				{
					customNavHeightMode = lp.height != android.view.ViewGroup.LayoutParams.WRAP_CONTENT
						 ? android.view.View.MeasureSpec.EXACTLY : android.view.View.MeasureSpec.AT_MOST;
				}
				int customNavHeight = System.Math.Max(0, (lp.height >= 0 ? System.Math.Min(lp.height
					, height) : height) - verticalMargin);
				int customNavWidthMode = lp.width != android.view.ViewGroup.LayoutParams.WRAP_CONTENT
					 ? android.view.View.MeasureSpec.EXACTLY : android.view.View.MeasureSpec.AT_MOST;
				int customNavWidth = System.Math.Max(0, (lp.width >= 0 ? System.Math.Min(lp.width
					, availableWidth) : availableWidth) - horizontalMargin);
				int hgrav = (ablp != null ? ablp.gravity : DEFAULT_CUSTOM_GRAVITY) & android.view.Gravity
					.HORIZONTAL_GRAVITY_MASK;
				// Centering a custom view is treated specially; we try to center within the whole
				// action bar rather than in the available space.
				if (hgrav == android.view.Gravity.CENTER_HORIZONTAL && lp.width == android.view.ViewGroup
					.LayoutParams.MATCH_PARENT)
				{
					customNavWidth = System.Math.Min(leftOfCenter, rightOfCenter) * 2;
				}
				customView.measure(android.view.View.MeasureSpec.makeMeasureSpec(customNavWidth, 
					customNavWidthMode), android.view.View.MeasureSpec.makeMeasureSpec(customNavHeight
					, customNavHeightMode));
				availableWidth -= horizontalMargin + customView.getMeasuredWidth();
			}
			if (mExpandedActionView == null && showTitle)
			{
				availableWidth = measureChildView(mTitleLayout, availableWidth, android.view.View
					.MeasureSpec.makeMeasureSpec(mContentHeight, android.view.View.MeasureSpec.EXACTLY
					), 0);
				leftOfCenter = System.Math.Max(0, leftOfCenter - mTitleLayout.getMeasuredWidth());
			}
			if (mContentHeight <= 0)
			{
				int measuredHeight = 0;
				{
					for (int i = 0; i < childCount; i++)
					{
						android.view.View v = getChildAt(i);
						int paddedViewHeight = v.getMeasuredHeight() + verticalPadding;
						if (paddedViewHeight > measuredHeight)
						{
							measuredHeight = paddedViewHeight;
						}
					}
				}
				setMeasuredDimension(contentWidth, measuredHeight);
			}
			else
			{
				setMeasuredDimension(contentWidth, maxHeight);
			}
			if (mContextView != null)
			{
				mContextView.setContentHeight(getMeasuredHeight());
			}
			if (mProgressView != null && mProgressView.getVisibility() != GONE)
			{
				mProgressView.measure(android.view.View.MeasureSpec.makeMeasureSpec(contentWidth 
					- mProgressBarPadding * 2, android.view.View.MeasureSpec.EXACTLY), android.view.View
					.MeasureSpec.makeMeasureSpec(getMeasuredHeight(), android.view.View.MeasureSpec.
					AT_MOST));
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onLayout(bool changed, int l, int t, int r, int 
			b)
		{
			int x = getPaddingLeft();
			int y = getPaddingTop();
			int contentHeight = b - t - getPaddingTop() - getPaddingBottom();
			if (contentHeight <= 0)
			{
				// Nothing to do if we can't see anything.
				return;
			}
			android.widget.@internal.ActionBarView.HomeView homeLayout = mExpandedActionView 
				!= null ? mExpandedHomeLayout : mHomeLayout;
			if (homeLayout.getVisibility() != GONE)
			{
				int leftOffset = homeLayout.getLeftOffset();
				x += positionChild(homeLayout, x + leftOffset, y, contentHeight) + leftOffset;
			}
			if (mExpandedActionView == null)
			{
				bool showTitle = mTitleLayout != null && mTitleLayout.getVisibility() != GONE && 
					(mDisplayOptions & android.app.ActionBar.DISPLAY_SHOW_TITLE) != 0;
				if (showTitle)
				{
					x += positionChild(mTitleLayout, x, y, contentHeight);
				}
				switch (mNavigationMode)
				{
					case android.app.ActionBar.NAVIGATION_MODE_STANDARD:
					{
						break;
					}

					case android.app.ActionBar.NAVIGATION_MODE_LIST:
					{
						if (mListNavLayout != null)
						{
							if (showTitle)
							{
								x += mItemPadding;
							}
							x += positionChild(mListNavLayout, x, y, contentHeight) + mItemPadding;
						}
						break;
					}

					case android.app.ActionBar.NAVIGATION_MODE_TABS:
					{
						if (mTabScrollView != null)
						{
							if (showTitle)
							{
								x += mItemPadding;
							}
							x += positionChild(mTabScrollView, x, y, contentHeight) + mItemPadding;
						}
						break;
					}
				}
			}
			int menuLeft = r - l - getPaddingRight();
			if (mMenuView != null && mMenuView.getParent() == this)
			{
				positionChildInverse(mMenuView, menuLeft, y, contentHeight);
				menuLeft -= mMenuView.getMeasuredWidth();
			}
			if (mIndeterminateProgressView != null && mIndeterminateProgressView.getVisibility
				() != GONE)
			{
				positionChildInverse(mIndeterminateProgressView, menuLeft, y, contentHeight);
				menuLeft -= mIndeterminateProgressView.getMeasuredWidth();
			}
			android.view.View customView = null;
			if (mExpandedActionView != null)
			{
				customView = mExpandedActionView;
			}
			else
			{
				if ((mDisplayOptions & android.app.ActionBar.DISPLAY_SHOW_CUSTOM) != 0 && mCustomNavView
					 != null)
				{
					customView = mCustomNavView;
				}
			}
			if (customView != null)
			{
				android.view.ViewGroup.LayoutParams lp = customView.getLayoutParams();
				android.app.ActionBar.LayoutParams ablp = lp is android.app.ActionBar.LayoutParams
					 ? (android.app.ActionBar.LayoutParams)lp : null;
				int gravity = ablp != null ? ablp.gravity : DEFAULT_CUSTOM_GRAVITY;
				int navWidth = customView.getMeasuredWidth();
				int topMargin = 0;
				int bottomMargin = 0;
				if (ablp != null)
				{
					x += ablp.leftMargin;
					menuLeft -= ablp.rightMargin;
					topMargin = ablp.topMargin;
					bottomMargin = ablp.bottomMargin;
				}
				int hgravity = gravity & android.view.Gravity.HORIZONTAL_GRAVITY_MASK;
				// See if we actually have room to truly center; if not push against left or right.
				if (hgravity == android.view.Gravity.CENTER_HORIZONTAL)
				{
					int centeredLeft = ((mRight - mLeft) - navWidth) / 2;
					if (centeredLeft < x)
					{
						hgravity = android.view.Gravity.LEFT;
					}
					else
					{
						if (centeredLeft + navWidth > menuLeft)
						{
							hgravity = android.view.Gravity.RIGHT;
						}
					}
				}
				else
				{
					if (gravity == -1)
					{
						hgravity = android.view.Gravity.LEFT;
					}
				}
				int xpos = 0;
				switch (hgravity)
				{
					case android.view.Gravity.CENTER_HORIZONTAL:
					{
						xpos = ((mRight - mLeft) - navWidth) / 2;
						break;
					}

					case android.view.Gravity.LEFT:
					{
						xpos = x;
						break;
					}

					case android.view.Gravity.RIGHT:
					{
						xpos = menuLeft - navWidth;
						break;
					}
				}
				int vgravity = gravity & android.view.Gravity.VERTICAL_GRAVITY_MASK;
				if (gravity == -1)
				{
					vgravity = android.view.Gravity.CENTER_VERTICAL;
				}
				int ypos = 0;
				switch (vgravity)
				{
					case android.view.Gravity.CENTER_VERTICAL:
					{
						int paddedTop = getPaddingTop();
						int paddedBottom = mBottom - mTop - getPaddingBottom();
						ypos = ((paddedBottom - paddedTop) - customView.getMeasuredHeight()) / 2;
						break;
					}

					case android.view.Gravity.TOP:
					{
						ypos = getPaddingTop() + topMargin;
						break;
					}

					case android.view.Gravity.BOTTOM:
					{
						ypos = getHeight() - getPaddingBottom() - customView.getMeasuredHeight() - bottomMargin;
						break;
					}
				}
				int customWidth = customView.getMeasuredWidth();
				customView.layout(xpos, ypos, xpos + customWidth, ypos + customView.getMeasuredHeight
					());
				x += customWidth;
			}
			if (mProgressView != null)
			{
				mProgressView.bringToFront();
				int halfProgressHeight = mProgressView.getMeasuredHeight() / 2;
				mProgressView.layout(mProgressBarPadding, -halfProgressHeight, mProgressBarPadding
					 + mProgressView.getMeasuredWidth(), halfProgressHeight);
			}
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override android.view.ViewGroup.LayoutParams generateLayoutParams(android.util.AttributeSet
			 attrs)
		{
			return new android.app.ActionBar.LayoutParams(getContext(), attrs);
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		protected internal override android.view.ViewGroup.LayoutParams generateLayoutParams
			(android.view.ViewGroup.LayoutParams lp)
		{
			if (lp == null)
			{
				lp = generateDefaultLayoutParams();
			}
			return lp;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override android.os.Parcelable onSaveInstanceState()
		{
			android.os.Parcelable superState = base.onSaveInstanceState();
			android.widget.@internal.ActionBarView.SavedState state = new android.widget.@internal.ActionBarView
				.SavedState(superState);
			if (mExpandedMenuPresenter != null && mExpandedMenuPresenter.mCurrentExpandedItem
				 != null)
			{
				state.expandedMenuItemId = mExpandedMenuPresenter.mCurrentExpandedItem.getItemId(
					);
			}
			state.isOverflowOpen = isOverflowMenuShowing();
			return state;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onRestoreInstanceState(android.os.Parcelable p)
		{
			android.widget.@internal.ActionBarView.SavedState state = (android.widget.@internal.ActionBarView
				.SavedState)p;
			base.onRestoreInstanceState(state.getSuperState());
			if (state.expandedMenuItemId != 0 && mExpandedMenuPresenter != null && mOptionsMenu
				 != null)
			{
				android.view.MenuItem item = mOptionsMenu.findItem(state.expandedMenuItemId);
				if (item != null)
				{
					item.expandActionView();
				}
			}
			if (state.isOverflowOpen)
			{
				postShowOverflowMenu();
			}
		}

		internal class SavedState : android.view.View.BaseSavedState
		{
			internal int expandedMenuItemId;

			internal bool isOverflowOpen;

			internal SavedState(android.os.Parcelable superState) : base(superState)
			{
			}

			private SavedState(android.os.Parcel @in) : base(@in)
			{
				expandedMenuItemId = @in.readInt();
				isOverflowOpen = @in.readInt() != 0;
			}

			[Sharpen.OverridesMethod(@"android.view.AbsSavedState")]
			public override void writeToParcel(android.os.Parcel @out, int flags)
			{
				base.writeToParcel(@out, flags);
				@out.writeInt(expandedMenuItemId);
				@out.writeInt(isOverflowOpen ? 1 : 0);
			}

			private sealed class _Creator_1178 : android.os.ParcelableClass.Creator<android.widget.@internal.ActionBarView
				.SavedState>
			{
				public _Creator_1178()
				{
				}

				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.widget.@internal.ActionBarView.SavedState createFromParcel(android.os.Parcel
					 @in)
				{
					return new android.widget.@internal.ActionBarView.SavedState(@in);
				}

				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.widget.@internal.ActionBarView.SavedState[] newArray(int size)
				{
					return new android.widget.@internal.ActionBarView.SavedState[size];
				}
			}

			internal static readonly android.os.ParcelableClass.Creator<android.widget.@internal.ActionBarView
				.SavedState> CREATOR = new _Creator_1178();
		}

		private class HomeView : android.widget.FrameLayout
		{
			internal android.view.View mUpView;

			internal android.widget.ImageView mIconView;

			internal int mUpWidth;

			public HomeView(android.content.Context context) : this(context, null)
			{
			}

			public HomeView(android.content.Context context, android.util.AttributeSet attrs)
				 : base(context, attrs)
			{
			}

			public virtual void setUp(bool isUp)
			{
				mUpView.setVisibility(isUp ? VISIBLE : GONE);
			}

			public virtual void setIcon(android.graphics.drawable.Drawable icon)
			{
				mIconView.setImageDrawable(icon);
			}

			[Sharpen.OverridesMethod(@"android.view.View")]
			public override bool dispatchPopulateAccessibilityEvent(android.view.accessibility.AccessibilityEvent
				 @event)
			{
				onPopulateAccessibilityEvent(@event);
				return true;
			}

			[Sharpen.OverridesMethod(@"android.view.View")]
			public override void onPopulateAccessibilityEvent(android.view.accessibility.AccessibilityEvent
				 @event)
			{
				base.onPopulateAccessibilityEvent(@event);
				java.lang.CharSequence cdesc = getContentDescription();
				if (!android.text.TextUtils.isEmpty(cdesc))
				{
					@event.getText().add(cdesc);
				}
			}

			[Sharpen.OverridesMethod(@"android.view.View")]
			protected internal override bool dispatchHoverEvent(android.view.MotionEvent @event
				)
			{
				// Don't allow children to hover; we want this to be treated as a single component.
				return onHoverEvent(@event);
			}

			[Sharpen.OverridesMethod(@"android.view.View")]
			protected internal override void onFinishInflate()
			{
				mUpView = findViewById(android.@internal.R.id.up);
				mIconView = (android.widget.ImageView)findViewById(android.@internal.R.id.home);
			}

			public virtual int getLeftOffset()
			{
				return mUpView.getVisibility() == GONE ? mUpWidth : 0;
			}

			[Sharpen.OverridesMethod(@"android.view.View")]
			protected internal override void onMeasure(int widthMeasureSpec, int heightMeasureSpec
				)
			{
				measureChildWithMargins(mUpView, widthMeasureSpec, 0, heightMeasureSpec, 0);
				android.widget.FrameLayout.LayoutParams upLp = (android.widget.FrameLayout.LayoutParams
					)mUpView.getLayoutParams();
				mUpWidth = upLp.leftMargin + mUpView.getMeasuredWidth() + upLp.rightMargin;
				int width = mUpView.getVisibility() == GONE ? 0 : mUpWidth;
				int height = upLp.topMargin + mUpView.getMeasuredHeight() + upLp.bottomMargin;
				measureChildWithMargins(mIconView, widthMeasureSpec, width, heightMeasureSpec, 0);
				android.widget.FrameLayout.LayoutParams iconLp = (android.widget.FrameLayout.LayoutParams
					)mIconView.getLayoutParams();
				width += iconLp.leftMargin + mIconView.getMeasuredWidth() + iconLp.rightMargin;
				height = System.Math.Max(height, iconLp.topMargin + mIconView.getMeasuredHeight()
					 + iconLp.bottomMargin);
				int widthMode = android.view.View.MeasureSpec.getMode(widthMeasureSpec);
				int heightMode = android.view.View.MeasureSpec.getMode(heightMeasureSpec);
				int widthSize = android.view.View.MeasureSpec.getSize(widthMeasureSpec);
				int heightSize = android.view.View.MeasureSpec.getSize(heightMeasureSpec);
				switch (widthMode)
				{
					case android.view.View.MeasureSpec.AT_MOST:
					{
						width = System.Math.Min(width, widthSize);
						break;
					}

					case android.view.View.MeasureSpec.EXACTLY:
					{
						width = widthSize;
						break;
					}

					case android.view.View.MeasureSpec.UNSPECIFIED:
					default:
					{
						break;
					}
				}
				switch (heightMode)
				{
					case android.view.View.MeasureSpec.AT_MOST:
					{
						height = System.Math.Min(height, heightSize);
						break;
					}

					case android.view.View.MeasureSpec.EXACTLY:
					{
						height = heightSize;
						break;
					}

					case android.view.View.MeasureSpec.UNSPECIFIED:
					default:
					{
						break;
					}
				}
				setMeasuredDimension(width, height);
			}

			[Sharpen.OverridesMethod(@"android.view.View")]
			protected internal override void onLayout(bool changed, int l, int t, int r, int 
				b)
			{
				int vCenter = (b - t) / 2;
				int width = r - l;
				int upOffset = 0;
				if (mUpView.getVisibility() != GONE)
				{
					android.widget.FrameLayout.LayoutParams upLp = (android.widget.FrameLayout.LayoutParams
						)mUpView.getLayoutParams();
					int upHeight = mUpView.getMeasuredHeight();
					int upWidth = mUpView.getMeasuredWidth();
					int upTop = vCenter - upHeight / 2;
					mUpView.layout(0, upTop, upWidth, upTop + upHeight);
					upOffset = upLp.leftMargin + upWidth + upLp.rightMargin;
					width -= upOffset;
					l += upOffset;
				}
				android.widget.FrameLayout.LayoutParams iconLp = (android.widget.FrameLayout.LayoutParams
					)mIconView.getLayoutParams();
				int iconHeight = mIconView.getMeasuredHeight();
				int iconWidth = mIconView.getMeasuredWidth();
				int hCenter = (r - l) / 2;
				int iconLeft = upOffset + System.Math.Max(iconLp.leftMargin, hCenter - iconWidth 
					/ 2);
				int iconTop = System.Math.Max(iconLp.topMargin, vCenter - iconHeight / 2);
				mIconView.layout(iconLeft, iconTop, iconLeft + iconWidth, iconTop + iconHeight);
			}
		}

		private class ExpandedActionViewMenuPresenter : android.view.@internal.menu.MenuPresenter
		{
			internal android.view.@internal.menu.MenuBuilder mMenu;

			internal android.view.@internal.menu.MenuItemImpl mCurrentExpandedItem;

			[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuPresenter")]
			public virtual void initForMenu(android.content.Context context, android.view.@internal.menu.MenuBuilder
				 menu)
			{
				// Clear the expanded action view when menus change.
				if (this.mMenu != null && this.mCurrentExpandedItem != null)
				{
					this.mMenu.collapseItemActionView(this.mCurrentExpandedItem);
				}
				this.mMenu = menu;
			}

			[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuPresenter")]
			public virtual android.view.@internal.menu.MenuView getMenuView(android.view.ViewGroup
				 root)
			{
				return null;
			}

			[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuPresenter")]
			public virtual void updateMenuView(bool cleared)
			{
				// Make sure the expanded item we have is still there.
				if (this.mCurrentExpandedItem != null)
				{
					bool found = false;
					if (this.mMenu != null)
					{
						int count = this.mMenu.size();
						{
							for (int i = 0; i < count; i++)
							{
								android.view.MenuItem item = this.mMenu.getItem(i);
								if (item == this.mCurrentExpandedItem)
								{
									found = true;
									break;
								}
							}
						}
					}
					if (!found)
					{
						// The item we had expanded disappeared. Collapse.
						this.collapseItemActionView(this.mMenu, this.mCurrentExpandedItem);
					}
				}
			}

			[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuPresenter")]
			public virtual void setCallback(android.view.@internal.menu.MenuPresenterClass.Callback
				 cb)
			{
			}

			[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuPresenter")]
			public virtual bool onSubMenuSelected(android.view.@internal.menu.SubMenuBuilder 
				subMenu)
			{
				return false;
			}

			[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuPresenter")]
			public virtual void onCloseMenu(android.view.@internal.menu.MenuBuilder menu, bool
				 allMenusAreClosing)
			{
			}

			[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuPresenter")]
			public virtual bool flagActionItems()
			{
				return false;
			}

			[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuPresenter")]
			public virtual bool expandItemActionView(android.view.@internal.menu.MenuBuilder 
				menu, android.view.@internal.menu.MenuItemImpl item)
			{
				this._enclosing.mExpandedActionView = item.getActionView();
				this._enclosing.mExpandedHomeLayout.setIcon(this._enclosing.mIcon.getConstantState
					().newDrawable(this._enclosing.getResources()));
				this.mCurrentExpandedItem = item;
				if (this._enclosing.mExpandedActionView.getParent() != this._enclosing)
				{
					this._enclosing.addView(this._enclosing.mExpandedActionView);
				}
				if (this._enclosing.mExpandedHomeLayout.getParent() != this._enclosing)
				{
					this._enclosing.addView(this._enclosing.mExpandedHomeLayout);
				}
				this._enclosing.mHomeLayout.setVisibility(android.view.View.GONE);
				if (this._enclosing.mTitleLayout != null)
				{
					this._enclosing.mTitleLayout.setVisibility(android.view.View.GONE);
				}
				if (this._enclosing.mTabScrollView != null)
				{
					this._enclosing.mTabScrollView.setVisibility(android.view.View.GONE);
				}
				if (this._enclosing.mSpinner != null)
				{
					this._enclosing.mSpinner.setVisibility(android.view.View.GONE);
				}
				if (this._enclosing.mCustomNavView != null)
				{
					this._enclosing.mCustomNavView.setVisibility(android.view.View.GONE);
				}
				this._enclosing.requestLayout();
				item.setActionViewExpanded(true);
				if (this._enclosing.mExpandedActionView is android.view.CollapsibleActionView)
				{
					((android.view.CollapsibleActionView)this._enclosing.mExpandedActionView).onActionViewExpanded
						();
				}
				return true;
			}

			[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuPresenter")]
			public virtual bool collapseItemActionView(android.view.@internal.menu.MenuBuilder
				 menu, android.view.@internal.menu.MenuItemImpl item)
			{
				// Do this before detaching the actionview from the hierarchy, in case
				// it needs to dismiss the soft keyboard, etc.
				if (this._enclosing.mExpandedActionView is android.view.CollapsibleActionView)
				{
					((android.view.CollapsibleActionView)this._enclosing.mExpandedActionView).onActionViewCollapsed
						();
				}
				this._enclosing.removeView(this._enclosing.mExpandedActionView);
				this._enclosing.removeView(this._enclosing.mExpandedHomeLayout);
				this._enclosing.mExpandedActionView = null;
				if ((this._enclosing.mDisplayOptions & android.app.ActionBar.DISPLAY_SHOW_HOME) !=
					 0)
				{
					this._enclosing.mHomeLayout.setVisibility(android.view.View.VISIBLE);
				}
				if ((this._enclosing.mDisplayOptions & android.app.ActionBar.DISPLAY_SHOW_TITLE) 
					!= 0)
				{
					if (this._enclosing.mTitleLayout == null)
					{
						this._enclosing.initTitle();
					}
					else
					{
						this._enclosing.mTitleLayout.setVisibility(android.view.View.VISIBLE);
					}
				}
				if (this._enclosing.mTabScrollView != null && this._enclosing.mNavigationMode == 
					android.app.ActionBar.NAVIGATION_MODE_TABS)
				{
					this._enclosing.mTabScrollView.setVisibility(android.view.View.VISIBLE);
				}
				if (this._enclosing.mSpinner != null && this._enclosing.mNavigationMode == android.app.ActionBar
					.NAVIGATION_MODE_LIST)
				{
					this._enclosing.mSpinner.setVisibility(android.view.View.VISIBLE);
				}
				if (this._enclosing.mCustomNavView != null && (this._enclosing.mDisplayOptions & 
					android.app.ActionBar.DISPLAY_SHOW_CUSTOM) != 0)
				{
					this._enclosing.mCustomNavView.setVisibility(android.view.View.VISIBLE);
				}
				this._enclosing.mExpandedHomeLayout.setIcon(null);
				this.mCurrentExpandedItem = null;
				this._enclosing.requestLayout();
				item.setActionViewExpanded(false);
				return true;
			}

			[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuPresenter")]
			public virtual int getId()
			{
				return 0;
			}

			[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuPresenter")]
			public virtual android.os.Parcelable onSaveInstanceState()
			{
				return null;
			}

			[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuPresenter")]
			public virtual void onRestoreInstanceState(android.os.Parcelable state)
			{
			}

			internal ExpandedActionViewMenuPresenter(ActionBarView _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly ActionBarView _enclosing;
		}
	}
}

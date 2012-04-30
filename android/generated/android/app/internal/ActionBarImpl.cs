using Sharpen;

namespace android.app.@internal
{
	/// <summary>
	/// ActionBarImpl is the ActionBar implementation used
	/// by devices of all screen sizes.
	/// </summary>
	/// <remarks>
	/// ActionBarImpl is the ActionBar implementation used
	/// by devices of all screen sizes. If it detects a compatible decor,
	/// it will split contextual modes across both the ActionBarView at
	/// the top of the screen and a horizontal LinearLayout at the bottom
	/// which is normally hidden.
	/// </remarks>
	[Sharpen.Sharpened]
	public class ActionBarImpl : android.app.ActionBar
	{
		internal const string TAG = "ActionBarImpl";

		private android.content.Context mContext;

		private android.content.Context mThemedContext;

		private android.app.Activity mActivity;

		private android.app.Dialog mDialog;

		private android.widget.@internal.ActionBarContainer mContainerView;

		private android.widget.@internal.ActionBarView mActionView;

		private android.widget.@internal.ActionBarContextView mContextView;

		private android.widget.@internal.ActionBarContainer mSplitView;

		private android.view.View mContentView;

		private android.widget.@internal.ScrollingTabContainerView mTabScrollView;

		private java.util.ArrayList<android.app.@internal.ActionBarImpl.TabImpl> mTabs = 
			new java.util.ArrayList<android.app.@internal.ActionBarImpl.TabImpl>();

		private android.app.@internal.ActionBarImpl.TabImpl mSelectedTab;

		private int mSavedTabPosition = INVALID_POSITION;

		internal android.app.@internal.ActionBarImpl.ActionModeImpl mActionMode;

		internal android.view.ActionMode mDeferredDestroyActionMode;

		internal android.view.ActionMode.Callback mDeferredModeDestroyCallback;

		private bool mLastMenuVisibility;

		private java.util.ArrayList<android.app.ActionBar.OnMenuVisibilityListener> mMenuVisibilityListeners
			 = new java.util.ArrayList<android.app.ActionBar.OnMenuVisibilityListener>();

		internal const int CONTEXT_DISPLAY_NORMAL = 0;

		internal const int CONTEXT_DISPLAY_SPLIT = 1;

		internal const int INVALID_POSITION = -1;

		private int mContextDisplayMode;

		private bool mHasEmbeddedTabs;

		internal readonly android.os.Handler mHandler = new android.os.Handler();

		internal java.lang.Runnable mTabSelector;

		private android.animation.Animator mCurrentShowAnim;

		private android.animation.Animator mCurrentModeAnim;

		private bool mShowHideAnimationEnabled;

		internal bool mWasHiddenBeforeMode;

		private sealed class _AnimatorListenerAdapter_108 : android.animation.AnimatorListenerAdapter
		{
			public _AnimatorListenerAdapter_108(ActionBarImpl _enclosing)
			{
				this._enclosing = _enclosing;
			}

			[Sharpen.OverridesMethod(@"android.animation.AnimatorListenerAdapter")]
			public override void onAnimationEnd(android.animation.Animator animation)
			{
				if (this._enclosing.mContentView != null)
				{
					this._enclosing.mContentView.setTranslationY(0);
					this._enclosing.mContainerView.setTranslationY(0);
				}
				if (this._enclosing.mSplitView != null && this._enclosing.mContextDisplayMode == 
					android.app.@internal.ActionBarImpl.CONTEXT_DISPLAY_SPLIT)
				{
					this._enclosing.mSplitView.setVisibility(android.view.View.GONE);
				}
				this._enclosing.mContainerView.setVisibility(android.view.View.GONE);
				this._enclosing.mContainerView.setTransitioning(false);
				this._enclosing.mCurrentShowAnim = null;
				this._enclosing.completeDeferredDestroyActionMode();
			}

			private readonly ActionBarImpl _enclosing;
		}

		internal readonly android.animation.Animator.AnimatorListener mHideListener;

		private sealed class _AnimatorListenerAdapter_125 : android.animation.AnimatorListenerAdapter
		{
			public _AnimatorListenerAdapter_125(ActionBarImpl _enclosing)
			{
				this._enclosing = _enclosing;
			}

			[Sharpen.OverridesMethod(@"android.animation.AnimatorListenerAdapter")]
			public override void onAnimationEnd(android.animation.Animator animation)
			{
				this._enclosing.mCurrentShowAnim = null;
				this._enclosing.mContainerView.requestLayout();
			}

			private readonly ActionBarImpl _enclosing;
		}

		internal readonly android.animation.Animator.AnimatorListener mShowListener;

		public ActionBarImpl(android.app.Activity activity)
		{
			mHideListener = new _AnimatorListenerAdapter_108(this);
			mShowListener = new _AnimatorListenerAdapter_125(this);
			mActivity = activity;
			android.view.Window window = activity.getWindow();
			android.view.View decor = window.getDecorView();
			init(decor);
			if (!mActivity.getWindow().hasFeature(android.view.Window.FEATURE_ACTION_BAR_OVERLAY
				))
			{
				mContentView = decor.findViewById(android.R.id.content);
			}
		}

		public ActionBarImpl(android.app.Dialog dialog)
		{
			mHideListener = new _AnimatorListenerAdapter_108(this);
			mShowListener = new _AnimatorListenerAdapter_125(this);
			mDialog = dialog;
			init(dialog.getWindow().getDecorView());
		}

		private void init(android.view.View decor)
		{
			mContext = decor.getContext();
			mActionView = (android.widget.@internal.ActionBarView)decor.findViewById(android.@internal.R
				.id.action_bar);
			mContextView = (android.widget.@internal.ActionBarContextView)decor.findViewById(
				android.@internal.R.id.action_context_bar);
			mContainerView = (android.widget.@internal.ActionBarContainer)decor.findViewById(
				android.@internal.R.id.action_bar_container);
			mSplitView = (android.widget.@internal.ActionBarContainer)decor.findViewById(android.@internal.R
				.id.split_action_bar);
			if (mActionView == null || mContextView == null || mContainerView == null)
			{
				throw new System.InvalidOperationException(GetType().Name + " can only be used " 
					+ "with a compatible window decor layout");
			}
			mActionView.setContextView(mContextView);
			mContextDisplayMode = mActionView.isSplitActionBar() ? CONTEXT_DISPLAY_SPLIT : CONTEXT_DISPLAY_NORMAL;
			// Older apps get the home button interaction enabled by default.
			// Newer apps need to enable it explicitly.
			setHomeButtonEnabled(mContext.getApplicationInfo().targetSdkVersion < android.os.Build
				.VERSION_CODES.ICE_CREAM_SANDWICH);
			setHasEmbeddedTabs(mContext.getResources().getBoolean(android.@internal.R.@bool.action_bar_embed_tabs
				));
		}

		public virtual void onConfigurationChanged(android.content.res.Configuration newConfig
			)
		{
			setHasEmbeddedTabs(mContext.getResources().getBoolean(android.@internal.R.@bool.action_bar_embed_tabs
				));
		}

		private void setHasEmbeddedTabs(bool hasEmbeddedTabs)
		{
			mHasEmbeddedTabs = hasEmbeddedTabs;
			// Switch tab layout configuration if needed
			if (!mHasEmbeddedTabs)
			{
				mActionView.setEmbeddedTabView(null);
				mContainerView.setTabContainer(mTabScrollView);
			}
			else
			{
				mContainerView.setTabContainer(null);
				mActionView.setEmbeddedTabView(mTabScrollView);
			}
			bool isInTabMode = getNavigationMode() == NAVIGATION_MODE_TABS;
			if (mTabScrollView != null)
			{
				mTabScrollView.setVisibility(isInTabMode ? android.view.View.VISIBLE : android.view.View
					.GONE);
			}
			mActionView.setCollapsable(!mHasEmbeddedTabs && isInTabMode);
		}

		private void ensureTabsExist()
		{
			if (mTabScrollView != null)
			{
				return;
			}
			android.widget.@internal.ScrollingTabContainerView tabScroller = new android.widget.@internal.ScrollingTabContainerView
				(mContext);
			if (mHasEmbeddedTabs)
			{
				tabScroller.setVisibility(android.view.View.VISIBLE);
				mActionView.setEmbeddedTabView(tabScroller);
			}
			else
			{
				tabScroller.setVisibility(getNavigationMode() == NAVIGATION_MODE_TABS ? android.view.View
					.VISIBLE : android.view.View.GONE);
				mContainerView.setTabContainer(tabScroller);
			}
			mTabScrollView = tabScroller;
		}

		internal virtual void completeDeferredDestroyActionMode()
		{
			if (mDeferredModeDestroyCallback != null)
			{
				mDeferredModeDestroyCallback.onDestroyActionMode(mDeferredDestroyActionMode);
				mDeferredDestroyActionMode = null;
				mDeferredModeDestroyCallback = null;
			}
		}

		/// <summary>Enables or disables animation between show/hide states.</summary>
		/// <remarks>
		/// Enables or disables animation between show/hide states.
		/// If animation is disabled using this method, animations in progress
		/// will be finished.
		/// </remarks>
		/// <param name="enabled">true to animate, false to not animate.</param>
		public virtual void setShowHideAnimationEnabled(bool enabled)
		{
			mShowHideAnimationEnabled = enabled;
			if (!enabled && mCurrentShowAnim != null)
			{
				mCurrentShowAnim.end();
			}
		}

		[Sharpen.OverridesMethod(@"android.app.ActionBar")]
		public override void addOnMenuVisibilityListener(android.app.ActionBar.OnMenuVisibilityListener
			 listener)
		{
			mMenuVisibilityListeners.add(listener);
		}

		[Sharpen.OverridesMethod(@"android.app.ActionBar")]
		public override void removeOnMenuVisibilityListener(android.app.ActionBar.OnMenuVisibilityListener
			 listener)
		{
			mMenuVisibilityListeners.remove(listener);
		}

		public virtual void dispatchMenuVisibilityChanged(bool isVisible)
		{
			if (isVisible == mLastMenuVisibility)
			{
				return;
			}
			mLastMenuVisibility = isVisible;
			int count = mMenuVisibilityListeners.size();
			{
				for (int i = 0; i < count; i++)
				{
					mMenuVisibilityListeners.get(i).onMenuVisibilityChanged(isVisible);
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.app.ActionBar")]
		public override void setCustomView(int resId)
		{
			setCustomView(android.view.LayoutInflater.from(getThemedContext()).inflate(resId, 
				mActionView, false));
		}

		[Sharpen.OverridesMethod(@"android.app.ActionBar")]
		public override void setDisplayUseLogoEnabled(bool useLogo)
		{
			setDisplayOptions(useLogo ? DISPLAY_USE_LOGO : 0, DISPLAY_USE_LOGO);
		}

		[Sharpen.OverridesMethod(@"android.app.ActionBar")]
		public override void setDisplayShowHomeEnabled(bool showHome)
		{
			setDisplayOptions(showHome ? DISPLAY_SHOW_HOME : 0, DISPLAY_SHOW_HOME);
		}

		[Sharpen.OverridesMethod(@"android.app.ActionBar")]
		public override void setDisplayHomeAsUpEnabled(bool showHomeAsUp)
		{
			setDisplayOptions(showHomeAsUp ? DISPLAY_HOME_AS_UP : 0, DISPLAY_HOME_AS_UP);
		}

		[Sharpen.OverridesMethod(@"android.app.ActionBar")]
		public override void setDisplayShowTitleEnabled(bool showTitle)
		{
			setDisplayOptions(showTitle ? DISPLAY_SHOW_TITLE : 0, DISPLAY_SHOW_TITLE);
		}

		[Sharpen.OverridesMethod(@"android.app.ActionBar")]
		public override void setDisplayShowCustomEnabled(bool showCustom)
		{
			setDisplayOptions(showCustom ? DISPLAY_SHOW_CUSTOM : 0, DISPLAY_SHOW_CUSTOM);
		}

		[Sharpen.OverridesMethod(@"android.app.ActionBar")]
		public override void setHomeButtonEnabled(bool enable)
		{
			mActionView.setHomeButtonEnabled(enable);
		}

		[Sharpen.OverridesMethod(@"android.app.ActionBar")]
		public override void setTitle(int resId)
		{
			setTitle(java.lang.CharSequenceProxy.Wrap(mContext.getString(resId)));
		}

		[Sharpen.OverridesMethod(@"android.app.ActionBar")]
		public override void setSubtitle(int resId)
		{
			setSubtitle(java.lang.CharSequenceProxy.Wrap(mContext.getString(resId)));
		}

		[Sharpen.OverridesMethod(@"android.app.ActionBar")]
		public override void setSelectedNavigationItem(int position)
		{
			switch (mActionView.getNavigationMode())
			{
				case NAVIGATION_MODE_TABS:
				{
					selectTab(mTabs.get(position));
					break;
				}

				case NAVIGATION_MODE_LIST:
				{
					mActionView.setDropdownSelectedPosition(position);
					break;
				}

				default:
				{
					throw new System.InvalidOperationException("setSelectedNavigationIndex not valid for current navigation mode"
						);
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.app.ActionBar")]
		public override void removeAllTabs()
		{
			cleanupTabs();
		}

		private void cleanupTabs()
		{
			if (mSelectedTab != null)
			{
				selectTab(null);
			}
			mTabs.clear();
			if (mTabScrollView != null)
			{
				mTabScrollView.removeAllTabs();
			}
			mSavedTabPosition = INVALID_POSITION;
		}

		[Sharpen.OverridesMethod(@"android.app.ActionBar")]
		public override void setTitle(java.lang.CharSequence title)
		{
			mActionView.setTitle(title);
		}

		[Sharpen.OverridesMethod(@"android.app.ActionBar")]
		public override void setSubtitle(java.lang.CharSequence subtitle)
		{
			mActionView.setSubtitle(subtitle);
		}

		[Sharpen.OverridesMethod(@"android.app.ActionBar")]
		public override void setDisplayOptions(int options)
		{
			mActionView.setDisplayOptions(options);
		}

		[Sharpen.OverridesMethod(@"android.app.ActionBar")]
		public override void setDisplayOptions(int options, int mask)
		{
			int current = mActionView.getDisplayOptions();
			mActionView.setDisplayOptions((options & mask) | (current & ~mask));
		}

		[Sharpen.OverridesMethod(@"android.app.ActionBar")]
		public override void setBackgroundDrawable(android.graphics.drawable.Drawable d)
		{
			mContainerView.setPrimaryBackground(d);
		}

		[Sharpen.OverridesMethod(@"android.app.ActionBar")]
		public override void setStackedBackgroundDrawable(android.graphics.drawable.Drawable
			 d)
		{
			mContainerView.setStackedBackground(d);
		}

		[Sharpen.OverridesMethod(@"android.app.ActionBar")]
		public override void setSplitBackgroundDrawable(android.graphics.drawable.Drawable
			 d)
		{
			if (mSplitView != null)
			{
				mSplitView.setSplitBackground(d);
			}
		}

		[Sharpen.OverridesMethod(@"android.app.ActionBar")]
		public override android.view.View getCustomView()
		{
			return mActionView.getCustomNavigationView();
		}

		[Sharpen.OverridesMethod(@"android.app.ActionBar")]
		public override java.lang.CharSequence getTitle()
		{
			return mActionView.getTitle();
		}

		[Sharpen.OverridesMethod(@"android.app.ActionBar")]
		public override java.lang.CharSequence getSubtitle()
		{
			return mActionView.getSubtitle();
		}

		[Sharpen.OverridesMethod(@"android.app.ActionBar")]
		public override int getNavigationMode()
		{
			return mActionView.getNavigationMode();
		}

		[Sharpen.OverridesMethod(@"android.app.ActionBar")]
		public override int getDisplayOptions()
		{
			return mActionView.getDisplayOptions();
		}

		public virtual android.view.ActionMode startActionMode(android.view.ActionMode.Callback
			 callback)
		{
			bool wasHidden = false;
			if (mActionMode != null)
			{
				wasHidden = mWasHiddenBeforeMode;
				mActionMode.finish();
			}
			mContextView.killMode();
			android.app.@internal.ActionBarImpl.ActionModeImpl mode = new android.app.@internal.ActionBarImpl
				.ActionModeImpl(this, callback);
			if (mode.dispatchOnCreate())
			{
				mWasHiddenBeforeMode = !isShowing() || wasHidden;
				mode.invalidate();
				mContextView.initForMode(mode);
				animateToMode(true);
				if (mSplitView != null && mContextDisplayMode == CONTEXT_DISPLAY_SPLIT)
				{
					// TODO animate this
					mSplitView.setVisibility(android.view.View.VISIBLE);
				}
				mContextView.sendAccessibilityEvent(android.view.accessibility.AccessibilityEvent
					.TYPE_WINDOW_STATE_CHANGED);
				mActionMode = mode;
				return mode;
			}
			return null;
		}

		private void configureTab(android.app.ActionBar.Tab tab, int position)
		{
			android.app.@internal.ActionBarImpl.TabImpl tabi = (android.app.@internal.ActionBarImpl
				.TabImpl)tab;
			android.app.ActionBar.TabListener callback = tabi.getCallback();
			if (callback == null)
			{
				throw new System.InvalidOperationException("Action Bar Tab must have a Callback");
			}
			tabi.setPosition(position);
			mTabs.add(position, tabi);
			int count = mTabs.size();
			{
				for (int i = position + 1; i < count; i++)
				{
					mTabs.get(i).setPosition(i);
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.app.ActionBar")]
		public override void addTab(android.app.ActionBar.Tab tab)
		{
			addTab(tab, mTabs.isEmpty());
		}

		[Sharpen.OverridesMethod(@"android.app.ActionBar")]
		public override void addTab(android.app.ActionBar.Tab tab, int position)
		{
			addTab(tab, position, mTabs.isEmpty());
		}

		[Sharpen.OverridesMethod(@"android.app.ActionBar")]
		public override void addTab(android.app.ActionBar.Tab tab, bool setSelected)
		{
			ensureTabsExist();
			mTabScrollView.addTab(tab, setSelected);
			configureTab(tab, mTabs.size());
			if (setSelected)
			{
				selectTab(tab);
			}
		}

		[Sharpen.OverridesMethod(@"android.app.ActionBar")]
		public override void addTab(android.app.ActionBar.Tab tab, int position, bool setSelected
			)
		{
			ensureTabsExist();
			mTabScrollView.addTab(tab, position, setSelected);
			configureTab(tab, position);
			if (setSelected)
			{
				selectTab(tab);
			}
		}

		[Sharpen.OverridesMethod(@"android.app.ActionBar")]
		public override android.app.ActionBar.Tab newTab()
		{
			return new android.app.@internal.ActionBarImpl.TabImpl(this);
		}

		[Sharpen.OverridesMethod(@"android.app.ActionBar")]
		public override void removeTab(android.app.ActionBar.Tab tab)
		{
			removeTabAt(tab.getPosition());
		}

		[Sharpen.OverridesMethod(@"android.app.ActionBar")]
		public override void removeTabAt(int position)
		{
			if (mTabScrollView == null)
			{
				// No tabs around to remove
				return;
			}
			int selectedTabPosition = mSelectedTab != null ? mSelectedTab.getPosition() : mSavedTabPosition;
			mTabScrollView.removeTabAt(position);
			android.app.@internal.ActionBarImpl.TabImpl removedTab = mTabs.remove(position);
			if (removedTab != null)
			{
				removedTab.setPosition(-1);
			}
			int newTabCount = mTabs.size();
			{
				for (int i = position; i < newTabCount; i++)
				{
					mTabs.get(i).setPosition(i);
				}
			}
			if (selectedTabPosition == position)
			{
				selectTab(mTabs.isEmpty() ? null : mTabs.get(System.Math.Max(0, position - 1)));
			}
		}

		[Sharpen.OverridesMethod(@"android.app.ActionBar")]
		public override void selectTab(android.app.ActionBar.Tab tab)
		{
			if (getNavigationMode() != NAVIGATION_MODE_TABS)
			{
				mSavedTabPosition = tab != null ? tab.getPosition() : INVALID_POSITION;
				return;
			}
			android.app.FragmentTransaction trans = mActivity.getFragmentManager().beginTransaction
				().disallowAddToBackStack();
			if (mSelectedTab == tab)
			{
				if (mSelectedTab != null)
				{
					mSelectedTab.getCallback().onTabReselected(mSelectedTab, trans);
					mTabScrollView.animateToTab(tab.getPosition());
				}
			}
			else
			{
				mTabScrollView.setTabSelected(tab != null ? tab.getPosition() : android.app.ActionBar
					.Tab.INVALID_POSITION);
				if (mSelectedTab != null)
				{
					mSelectedTab.getCallback().onTabUnselected(mSelectedTab, trans);
				}
				mSelectedTab = (android.app.@internal.ActionBarImpl.TabImpl)tab;
				if (mSelectedTab != null)
				{
					mSelectedTab.getCallback().onTabSelected(mSelectedTab, trans);
				}
			}
			if (!trans.isEmpty())
			{
				trans.commit();
			}
		}

		[Sharpen.OverridesMethod(@"android.app.ActionBar")]
		public override android.app.ActionBar.Tab getSelectedTab()
		{
			return mSelectedTab;
		}

		[Sharpen.OverridesMethod(@"android.app.ActionBar")]
		public override int getHeight()
		{
			return mContainerView.getHeight();
		}

		[Sharpen.OverridesMethod(@"android.app.ActionBar")]
		public override void show()
		{
			show(true);
		}

		internal virtual void show(bool markHiddenBeforeMode)
		{
			if (mCurrentShowAnim != null)
			{
				mCurrentShowAnim.end();
			}
			if (mContainerView.getVisibility() == android.view.View.VISIBLE)
			{
				if (markHiddenBeforeMode)
				{
					mWasHiddenBeforeMode = false;
				}
				return;
			}
			mContainerView.setVisibility(android.view.View.VISIBLE);
			if (mShowHideAnimationEnabled)
			{
				mContainerView.setAlpha(0);
				android.animation.AnimatorSet anim = new android.animation.AnimatorSet();
				android.animation.AnimatorSet.Builder b = anim.play(android.animation.ObjectAnimator
					.ofFloat(mContainerView, "alpha", 1));
				if (mContentView != null)
				{
					b.with(android.animation.ObjectAnimator.ofFloat(mContentView, "translationY", -mContainerView
						.getHeight(), 0));
					mContainerView.setTranslationY(-mContainerView.getHeight());
					b.with(android.animation.ObjectAnimator.ofFloat(mContainerView, "translationY", 0
						));
				}
				if (mSplitView != null && mContextDisplayMode == CONTEXT_DISPLAY_SPLIT)
				{
					mSplitView.setAlpha(0);
					mSplitView.setVisibility(android.view.View.VISIBLE);
					b.with(android.animation.ObjectAnimator.ofFloat(mSplitView, "alpha", 1));
				}
				anim.addListener(mShowListener);
				mCurrentShowAnim = anim;
				anim.start();
			}
			else
			{
				mContainerView.setAlpha(1);
				mContainerView.setTranslationY(0);
				mShowListener.onAnimationEnd(null);
			}
		}

		[Sharpen.OverridesMethod(@"android.app.ActionBar")]
		public override void hide()
		{
			if (mCurrentShowAnim != null)
			{
				mCurrentShowAnim.end();
			}
			if (mContainerView.getVisibility() == android.view.View.GONE)
			{
				return;
			}
			if (mShowHideAnimationEnabled)
			{
				mContainerView.setAlpha(1);
				mContainerView.setTransitioning(true);
				android.animation.AnimatorSet anim = new android.animation.AnimatorSet();
				android.animation.AnimatorSet.Builder b = anim.play(android.animation.ObjectAnimator
					.ofFloat(mContainerView, "alpha", 0));
				if (mContentView != null)
				{
					b.with(android.animation.ObjectAnimator.ofFloat(mContentView, "translationY", 0, 
						-mContainerView.getHeight()));
					b.with(android.animation.ObjectAnimator.ofFloat(mContainerView, "translationY", -
						mContainerView.getHeight()));
				}
				if (mSplitView != null && mSplitView.getVisibility() == android.view.View.VISIBLE)
				{
					mSplitView.setAlpha(1);
					b.with(android.animation.ObjectAnimator.ofFloat(mSplitView, "alpha", 0));
				}
				anim.addListener(mHideListener);
				mCurrentShowAnim = anim;
				anim.start();
			}
			else
			{
				mHideListener.onAnimationEnd(null);
			}
		}

		[Sharpen.OverridesMethod(@"android.app.ActionBar")]
		public override bool isShowing()
		{
			return mContainerView.getVisibility() == android.view.View.VISIBLE;
		}

		internal virtual void animateToMode(bool toActionMode)
		{
			if (toActionMode)
			{
				show(false);
			}
			if (mCurrentModeAnim != null)
			{
				mCurrentModeAnim.end();
			}
			mActionView.animateToVisibility(toActionMode ? android.view.View.GONE : android.view.View
				.VISIBLE);
			mContextView.animateToVisibility(toActionMode ? android.view.View.VISIBLE : android.view.View
				.GONE);
			if (mTabScrollView != null && !mActionView.hasEmbeddedTabs() && mActionView.isCollapsed
				())
			{
				mTabScrollView.animateToVisibility(toActionMode ? android.view.View.GONE : android.view.View
					.VISIBLE);
			}
		}

		[Sharpen.OverridesMethod(@"android.app.ActionBar")]
		public override android.content.Context getThemedContext()
		{
			if (mThemedContext == null)
			{
				android.util.TypedValue outValue = new android.util.TypedValue();
				android.content.res.Resources.Theme currentTheme = mContext.getTheme();
				currentTheme.resolveAttribute(android.@internal.R.attr.actionBarWidgetTheme, outValue
					, true);
				int targetThemeRes = outValue.resourceId;
				if (targetThemeRes != 0 && mContext.getThemeResId() != targetThemeRes)
				{
					mThemedContext = new android.view.ContextThemeWrapper(mContext, targetThemeRes);
				}
				else
				{
					mThemedContext = mContext;
				}
			}
			return mThemedContext;
		}

		/// <hide></hide>
		public class ActionModeImpl : android.view.ActionMode, android.view.@internal.menu.MenuBuilder
			.Callback
		{
			private android.view.ActionMode.Callback mCallback;

			private android.view.@internal.menu.MenuBuilder mMenu;

			private java.lang.@ref.WeakReference<android.view.View> mCustomView;

			public ActionModeImpl(ActionBarImpl _enclosing, android.view.ActionMode.Callback 
				callback)
			{
				this._enclosing = _enclosing;
				this.mCallback = callback;
				this.mMenu = new android.view.@internal.menu.MenuBuilder(this._enclosing.getThemedContext
					()).setDefaultShowAsAction(android.view.MenuItemClass.SHOW_AS_ACTION_IF_ROOM);
				this.mMenu.setCallback(this);
			}

			[Sharpen.OverridesMethod(@"android.view.ActionMode")]
			public override android.view.MenuInflater getMenuInflater()
			{
				return new android.view.MenuInflater(this._enclosing.getThemedContext());
			}

			[Sharpen.OverridesMethod(@"android.view.ActionMode")]
			public override android.view.Menu getMenu()
			{
				return this.mMenu;
			}

			[Sharpen.OverridesMethod(@"android.view.ActionMode")]
			public override void finish()
			{
				if (this._enclosing.mActionMode != this)
				{
					// Not the active action mode - no-op
					return;
				}
				// If we were hidden before the mode was shown, defer the onDestroy
				// callback until the animation is finished and associated relayout
				// is about to happen. This lets apps better anticipate visibility
				// and layout behavior.
				if (this._enclosing.mWasHiddenBeforeMode)
				{
					this._enclosing.mDeferredDestroyActionMode = this;
					this._enclosing.mDeferredModeDestroyCallback = this.mCallback;
				}
				else
				{
					this.mCallback.onDestroyActionMode(this);
				}
				this.mCallback = null;
				this._enclosing.animateToMode(false);
				// Clear out the context mode views after the animation finishes
				this._enclosing.mContextView.closeMode();
				this._enclosing.mActionView.sendAccessibilityEvent(android.view.accessibility.AccessibilityEvent
					.TYPE_WINDOW_STATE_CHANGED);
				this._enclosing.mActionMode = null;
				if (this._enclosing.mWasHiddenBeforeMode)
				{
					this._enclosing.hide();
				}
			}

			[Sharpen.OverridesMethod(@"android.view.ActionMode")]
			public override void invalidate()
			{
				this.mMenu.stopDispatchingItemsChanged();
				try
				{
					this.mCallback.onPrepareActionMode(this, this.mMenu);
				}
				finally
				{
					this.mMenu.startDispatchingItemsChanged();
				}
			}

			public virtual bool dispatchOnCreate()
			{
				this.mMenu.stopDispatchingItemsChanged();
				try
				{
					return this.mCallback.onCreateActionMode(this, this.mMenu);
				}
				finally
				{
					this.mMenu.startDispatchingItemsChanged();
				}
			}

			[Sharpen.OverridesMethod(@"android.view.ActionMode")]
			public override void setCustomView(android.view.View view)
			{
				this._enclosing.mContextView.setCustomView(view);
				this.mCustomView = new java.lang.@ref.WeakReference<android.view.View>(view);
			}

			[Sharpen.OverridesMethod(@"android.view.ActionMode")]
			public override void setSubtitle(java.lang.CharSequence subtitle)
			{
				this._enclosing.mContextView.setSubtitle(subtitle);
			}

			[Sharpen.OverridesMethod(@"android.view.ActionMode")]
			public override void setTitle(java.lang.CharSequence title)
			{
				this._enclosing.mContextView.setTitle(title);
			}

			[Sharpen.OverridesMethod(@"android.view.ActionMode")]
			public override void setTitle(int resId)
			{
				this.setTitle(java.lang.CharSequenceProxy.Wrap(this._enclosing.mContext.getResources
					().getString(resId)));
			}

			[Sharpen.OverridesMethod(@"android.view.ActionMode")]
			public override void setSubtitle(int resId)
			{
				this.setSubtitle(java.lang.CharSequenceProxy.Wrap(this._enclosing.mContext.getResources
					().getString(resId)));
			}

			[Sharpen.OverridesMethod(@"android.view.ActionMode")]
			public override java.lang.CharSequence getTitle()
			{
				return this._enclosing.mContextView.getTitle();
			}

			[Sharpen.OverridesMethod(@"android.view.ActionMode")]
			public override java.lang.CharSequence getSubtitle()
			{
				return this._enclosing.mContextView.getSubtitle();
			}

			[Sharpen.OverridesMethod(@"android.view.ActionMode")]
			public override android.view.View getCustomView()
			{
				return this.mCustomView != null ? this.mCustomView.get() : null;
			}

			[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuBuilder.Callback"
				)]
			public virtual bool onMenuItemSelected(android.view.@internal.menu.MenuBuilder menu
				, android.view.MenuItem item)
			{
				if (this.mCallback != null)
				{
					return this.mCallback.onActionItemClicked(this, item);
				}
				else
				{
					return false;
				}
			}

			public virtual void onCloseMenu(android.view.@internal.menu.MenuBuilder menu, bool
				 allMenusAreClosing)
			{
			}

			public virtual bool onSubMenuSelected(android.view.@internal.menu.SubMenuBuilder 
				subMenu)
			{
				if (this.mCallback == null)
				{
					return false;
				}
				if (!subMenu.hasVisibleItems())
				{
					return true;
				}
				new android.view.@internal.menu.MenuPopupHelper(this._enclosing.getThemedContext(
					), subMenu).show();
				return true;
			}

			public virtual void onCloseSubMenu(android.view.@internal.menu.SubMenuBuilder menu
				)
			{
			}

			[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuBuilder.Callback"
				)]
			public virtual void onMenuModeChange(android.view.@internal.menu.MenuBuilder menu
				)
			{
				if (this.mCallback == null)
				{
					return;
				}
				this.invalidate();
				this._enclosing.mContextView.showOverflowMenu();
			}

			private readonly ActionBarImpl _enclosing;
		}

		/// <hide></hide>
		public class TabImpl : android.app.ActionBar.Tab
		{
			private android.app.ActionBar.TabListener mCallback;

			private object mTag;

			private android.graphics.drawable.Drawable mIcon;

			private java.lang.CharSequence mText;

			private java.lang.CharSequence mContentDesc;

			private int mPosition;

			private android.view.View mCustomView;

			[Sharpen.OverridesMethod(@"android.app.ActionBar.Tab")]
			public override object getTag()
			{
				return this.mTag;
			}

			[Sharpen.OverridesMethod(@"android.app.ActionBar.Tab")]
			public override android.app.ActionBar.Tab setTag(object tag)
			{
				this.mTag = tag;
				return this;
			}

			public virtual android.app.ActionBar.TabListener getCallback()
			{
				return this.mCallback;
			}

			[Sharpen.OverridesMethod(@"android.app.ActionBar.Tab")]
			public override android.app.ActionBar.Tab setTabListener(android.app.ActionBar.TabListener
				 callback)
			{
				this.mCallback = callback;
				return this;
			}

			[Sharpen.OverridesMethod(@"android.app.ActionBar.Tab")]
			public override android.view.View getCustomView()
			{
				return this.mCustomView;
			}

			[Sharpen.OverridesMethod(@"android.app.ActionBar.Tab")]
			public override android.app.ActionBar.Tab setCustomView(android.view.View view)
			{
				this.mCustomView = view;
				if (this.mPosition >= 0)
				{
					this._enclosing.mTabScrollView.updateTab(this.mPosition);
				}
				return this;
			}

			[Sharpen.OverridesMethod(@"android.app.ActionBar.Tab")]
			public override android.app.ActionBar.Tab setCustomView(int layoutResId)
			{
				return this.setCustomView(android.view.LayoutInflater.from(this._enclosing.getThemedContext
					()).inflate(layoutResId, null));
			}

			[Sharpen.OverridesMethod(@"android.app.ActionBar.Tab")]
			public override android.graphics.drawable.Drawable getIcon()
			{
				return this.mIcon;
			}

			[Sharpen.OverridesMethod(@"android.app.ActionBar.Tab")]
			public override int getPosition()
			{
				return this.mPosition;
			}

			public virtual void setPosition(int position)
			{
				this.mPosition = position;
			}

			[Sharpen.OverridesMethod(@"android.app.ActionBar.Tab")]
			public override java.lang.CharSequence getText()
			{
				return this.mText;
			}

			[Sharpen.OverridesMethod(@"android.app.ActionBar.Tab")]
			public override android.app.ActionBar.Tab setIcon(android.graphics.drawable.Drawable
				 icon)
			{
				this.mIcon = icon;
				if (this.mPosition >= 0)
				{
					this._enclosing.mTabScrollView.updateTab(this.mPosition);
				}
				return this;
			}

			[Sharpen.OverridesMethod(@"android.app.ActionBar.Tab")]
			public override android.app.ActionBar.Tab setIcon(int resId)
			{
				return this.setIcon(this._enclosing.mContext.getResources().getDrawable(resId));
			}

			[Sharpen.OverridesMethod(@"android.app.ActionBar.Tab")]
			public override android.app.ActionBar.Tab setText(java.lang.CharSequence text)
			{
				this.mText = text;
				if (this.mPosition >= 0)
				{
					this._enclosing.mTabScrollView.updateTab(this.mPosition);
				}
				return this;
			}

			[Sharpen.OverridesMethod(@"android.app.ActionBar.Tab")]
			public override android.app.ActionBar.Tab setText(int resId)
			{
				return this.setText(this._enclosing.mContext.getResources().getText(resId));
			}

			[Sharpen.OverridesMethod(@"android.app.ActionBar.Tab")]
			public override void select()
			{
				this._enclosing.selectTab(this);
			}

			[Sharpen.OverridesMethod(@"android.app.ActionBar.Tab")]
			public override android.app.ActionBar.Tab setContentDescription(int resId)
			{
				return this.setContentDescription(this._enclosing.mContext.getResources().getText
					(resId));
			}

			[Sharpen.OverridesMethod(@"android.app.ActionBar.Tab")]
			public override android.app.ActionBar.Tab setContentDescription(java.lang.CharSequence
				 contentDesc)
			{
				this.mContentDesc = contentDesc;
				if (this.mPosition >= 0)
				{
					this._enclosing.mTabScrollView.updateTab(this.mPosition);
				}
				return this;
			}

			[Sharpen.OverridesMethod(@"android.app.ActionBar.Tab")]
			public override java.lang.CharSequence getContentDescription()
			{
				return this.mContentDesc;
			}

			public TabImpl(ActionBarImpl _enclosing)
			{
				this._enclosing = _enclosing;
				mPosition = -1;
			}

			private readonly ActionBarImpl _enclosing;
		}

		[Sharpen.OverridesMethod(@"android.app.ActionBar")]
		public override void setCustomView(android.view.View view)
		{
			mActionView.setCustomNavigationView(view);
		}

		[Sharpen.OverridesMethod(@"android.app.ActionBar")]
		public override void setCustomView(android.view.View view, android.app.ActionBar.
			LayoutParams layoutParams)
		{
			view.setLayoutParams(layoutParams);
			mActionView.setCustomNavigationView(view);
		}

		[Sharpen.OverridesMethod(@"android.app.ActionBar")]
		public override void setListNavigationCallbacks(android.widget.SpinnerAdapter adapter
			, android.app.ActionBar.OnNavigationListener callback)
		{
			mActionView.setDropdownAdapter(adapter);
			mActionView.setCallback(callback);
		}

		[Sharpen.OverridesMethod(@"android.app.ActionBar")]
		public override int getSelectedNavigationIndex()
		{
			switch (mActionView.getNavigationMode())
			{
				case NAVIGATION_MODE_TABS:
				{
					return mSelectedTab != null ? mSelectedTab.getPosition() : -1;
				}

				case NAVIGATION_MODE_LIST:
				{
					return mActionView.getDropdownSelectedPosition();
				}

				default:
				{
					return -1;
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.app.ActionBar")]
		public override int getNavigationItemCount()
		{
			switch (mActionView.getNavigationMode())
			{
				case NAVIGATION_MODE_TABS:
				{
					return mTabs.size();
				}

				case NAVIGATION_MODE_LIST:
				{
					android.widget.SpinnerAdapter adapter = mActionView.getDropdownAdapter();
					return adapter != null ? adapter.getCount() : 0;
				}

				default:
				{
					return 0;
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.app.ActionBar")]
		public override int getTabCount()
		{
			return mTabs.size();
		}

		[Sharpen.OverridesMethod(@"android.app.ActionBar")]
		public override void setNavigationMode(int mode)
		{
			int oldMode = mActionView.getNavigationMode();
			switch (oldMode)
			{
				case NAVIGATION_MODE_TABS:
				{
					mSavedTabPosition = getSelectedNavigationIndex();
					selectTab(null);
					mTabScrollView.setVisibility(android.view.View.GONE);
					break;
				}
			}
			mActionView.setNavigationMode(mode);
			switch (mode)
			{
				case NAVIGATION_MODE_TABS:
				{
					ensureTabsExist();
					mTabScrollView.setVisibility(android.view.View.VISIBLE);
					if (mSavedTabPosition != INVALID_POSITION)
					{
						setSelectedNavigationItem(mSavedTabPosition);
						mSavedTabPosition = INVALID_POSITION;
					}
					break;
				}
			}
			mActionView.setCollapsable(mode == NAVIGATION_MODE_TABS && !mHasEmbeddedTabs);
		}

		[Sharpen.OverridesMethod(@"android.app.ActionBar")]
		public override android.app.ActionBar.Tab getTabAt(int index)
		{
			return mTabs.get(index);
		}

		[Sharpen.OverridesMethod(@"android.app.ActionBar")]
		public override void setIcon(int resId)
		{
			mActionView.setIcon(resId);
		}

		[Sharpen.OverridesMethod(@"android.app.ActionBar")]
		public override void setIcon(android.graphics.drawable.Drawable icon)
		{
			mActionView.setIcon(icon);
		}

		[Sharpen.OverridesMethod(@"android.app.ActionBar")]
		public override void setLogo(int resId)
		{
			mActionView.setLogo(resId);
		}

		[Sharpen.OverridesMethod(@"android.app.ActionBar")]
		public override void setLogo(android.graphics.drawable.Drawable logo)
		{
			mActionView.setLogo(logo);
		}
	}
}

using Sharpen;

namespace android.widget
{
	/// <summary>Container for a tabbed window view.</summary>
	/// <remarks>
	/// Container for a tabbed window view. This object holds two children: a set of tab labels that the
	/// user clicks to select a specific tab, and a FrameLayout object that displays the contents of that
	/// page. The individual elements are typically controlled using this container object, rather than
	/// setting values on the child elements themselves.
	/// <p>See the &lt;a href="
	/// <docRoot></docRoot>
	/// resources/tutorials/views/hello-tabwidget.html"&gt;Tab Layout
	/// tutorial</a>.</p>
	/// </remarks>
	[Sharpen.Sharpened]
	public class TabHost : android.widget.FrameLayout, android.view.ViewTreeObserver.
		OnTouchModeChangeListener
	{
		private android.widget.TabWidget mTabWidget;

		private android.widget.FrameLayout mTabContent;

		private java.util.List<android.widget.TabHost.TabSpec> mTabSpecs = new java.util.ArrayList
			<android.widget.TabHost.TabSpec>(2);

		/// <summary>This field should be made private, so it is hidden from the SDK.</summary>
		/// <remarks>
		/// This field should be made private, so it is hidden from the SDK.
		/// <hide></hide>
		/// </remarks>
		protected internal int mCurrentTab = -1;

		private android.view.View mCurrentView = null;

		/// <summary>This field should be made private, so it is hidden from the SDK.</summary>
		/// <remarks>
		/// This field should be made private, so it is hidden from the SDK.
		/// <hide></hide>
		/// </remarks>
		protected internal android.app.LocalActivityManager mLocalActivityManager = null;

		private android.widget.TabHost.OnTabChangeListener mOnTabChangeListener;

		private android.view.View.OnKeyListener mTabKeyListener;

		private int mTabLayoutId;

		public TabHost(android.content.Context context) : base(context)
		{
			initTabHost();
		}

		public TabHost(android.content.Context context, android.util.AttributeSet attrs) : 
			base(context, attrs)
		{
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.TabWidget, android.@internal.R.attr.tabWidgetStyle, 0);
			mTabLayoutId = a.getResourceId(android.@internal.R.styleable.TabWidget_tabLayout, 
				0);
			a.recycle();
			if (mTabLayoutId == 0)
			{
				// In case the tabWidgetStyle does not inherit from Widget.TabWidget and tabLayout is
				// not defined.
				mTabLayoutId = android.@internal.R.layout.tab_indicator_holo;
			}
			initTabHost();
		}

		private void initTabHost()
		{
			setFocusableInTouchMode(true);
			setDescendantFocusability(FOCUS_AFTER_DESCENDANTS);
			mCurrentTab = -1;
			mCurrentView = null;
		}

		/// <summary>
		/// Get a new
		/// <see cref="TabSpec">TabSpec</see>
		/// associated with this tab host.
		/// </summary>
		/// <param name="tag">required tag of tab.</param>
		public virtual android.widget.TabHost.TabSpec newTabSpec(string tag)
		{
			return new android.widget.TabHost.TabSpec(this, tag);
		}

		private sealed class _OnKeyListener_130 : android.view.View.OnKeyListener
		{
			public _OnKeyListener_130(TabHost _enclosing)
			{
				this._enclosing = _enclosing;
			}

			// KeyListener to attach to all tabs. Detects non-navigation keys
			// and relays them to the tab content.
			[Sharpen.ImplementsInterface(@"android.view.View.OnKeyListener")]
			public bool onKey(android.view.View v, int keyCode, android.view.KeyEvent @event)
			{
				switch (keyCode)
				{
					case android.view.KeyEvent.KEYCODE_DPAD_CENTER:
					case android.view.KeyEvent.KEYCODE_DPAD_LEFT:
					case android.view.KeyEvent.KEYCODE_DPAD_RIGHT:
					case android.view.KeyEvent.KEYCODE_DPAD_UP:
					case android.view.KeyEvent.KEYCODE_DPAD_DOWN:
					case android.view.KeyEvent.KEYCODE_ENTER:
					{
						return false;
					}
				}
				this._enclosing.mTabContent.requestFocus(android.view.View.FOCUS_FORWARD);
				return this._enclosing.mTabContent.dispatchKeyEvent(@event);
			}

			private readonly TabHost _enclosing;
		}

		private sealed class _OnTabSelectionChanged_148 : android.widget.TabWidget.OnTabSelectionChanged
		{
			public _OnTabSelectionChanged_148(TabHost _enclosing)
			{
				this._enclosing = _enclosing;
			}

			[Sharpen.ImplementsInterface(@"android.widget.TabWidget.OnTabSelectionChanged")]
			public void onTabSelectionChanged(int tabIndex, bool clicked)
			{
				this._enclosing.setCurrentTab(tabIndex);
				if (clicked)
				{
					this._enclosing.mTabContent.requestFocus(android.view.View.FOCUS_FORWARD);
				}
			}

			private readonly TabHost _enclosing;
		}

		/// <summary><p>Call setup() before adding tabs if loading TabHost using findViewById().
		/// 	</summary>
		/// <remarks>
		/// <p>Call setup() before adding tabs if loading TabHost using findViewById().
		/// <i><b>However</i></b>: You do not need to call setup() after getTabHost()
		/// in
		/// <see cref="android.app.TabActivity">TabActivity</see>
		/// .
		/// Example:</p>
		/// <pre>mTabHost = (TabHost)findViewById(R.id.tabhost);
		/// mTabHost.setup();
		/// mTabHost.addTab(TAB_TAG_1, "Hello, world!", "Tab 1");
		/// </remarks>
		public virtual void setup()
		{
			mTabWidget = (android.widget.TabWidget)findViewById(android.@internal.R.id.tabs);
			if (mTabWidget == null)
			{
				throw new java.lang.RuntimeException("Your TabHost must have a TabWidget whose id attribute is 'android.R.id.tabs'"
					);
			}
			mTabKeyListener = new _OnKeyListener_130(this);
			mTabWidget.setTabSelectionListener(new _OnTabSelectionChanged_148(this));
			mTabContent = (android.widget.FrameLayout)findViewById(android.@internal.R.id.tabcontent
				);
			if (mTabContent == null)
			{
				throw new java.lang.RuntimeException("Your TabHost must have a FrameLayout whose id attribute is "
					 + "'android.R.id.tabcontent'");
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void sendAccessibilityEvent(int eventType)
		{
		}

		/// <summary>
		/// If you are using
		/// <see cref="TabSpec.setContent(android.content.Intent)">TabSpec.setContent(android.content.Intent)
		/// 	</see>
		/// , this
		/// must be called since the activityGroup is needed to launch the local activity.
		/// This is done for you if you extend
		/// <see cref="android.app.TabActivity">android.app.TabActivity</see>
		/// .
		/// </summary>
		/// <param name="activityGroup">Used to launch activities for tab content.</param>
		public virtual void setup(android.app.LocalActivityManager activityGroup)
		{
			setup();
			mLocalActivityManager = activityGroup;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onAttachedToWindow()
		{
			base.onAttachedToWindow();
			android.view.ViewTreeObserver treeObserver = getViewTreeObserver();
			treeObserver.addOnTouchModeChangeListener(this);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onDetachedFromWindow()
		{
			base.onDetachedFromWindow();
			android.view.ViewTreeObserver treeObserver = getViewTreeObserver();
			treeObserver.removeOnTouchModeChangeListener(this);
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.ImplementsInterface(@"android.view.ViewTreeObserver.OnTouchModeChangeListener"
			)]
		public virtual void onTouchModeChanged(bool isInTouchMode_1)
		{
			if (!isInTouchMode_1)
			{
				// leaving touch mode.. if nothing has focus, let's give it to
				// the indicator of the current tab
				if (mCurrentView != null && (!mCurrentView.hasFocus() || mCurrentView.isFocused()
					))
				{
					mTabWidget.getChildTabViewAt(mCurrentTab).requestFocus();
				}
			}
		}

		/// <summary>Add a tab.</summary>
		/// <remarks>Add a tab.</remarks>
		/// <param name="tabSpec">Specifies how to create the indicator and content.</param>
		public virtual void addTab(android.widget.TabHost.TabSpec tabSpec)
		{
			if (tabSpec.mIndicatorStrategy == null)
			{
				throw new System.ArgumentException("you must specify a way to create the tab indicator."
					);
			}
			if (tabSpec.mContentStrategy == null)
			{
				throw new System.ArgumentException("you must specify a way to create the tab content"
					);
			}
			android.view.View tabIndicator = tabSpec.mIndicatorStrategy.createIndicatorView();
			tabIndicator.setOnKeyListener(mTabKeyListener);
			// If this is a custom view, then do not draw the bottom strips for
			// the tab indicators.
			if (tabSpec.mIndicatorStrategy is android.widget.TabHost.ViewIndicatorStrategy)
			{
				mTabWidget.setStripEnabled(false);
			}
			mTabWidget.addView(tabIndicator);
			mTabSpecs.add(tabSpec);
			if (mCurrentTab == -1)
			{
				setCurrentTab(0);
			}
		}

		/// <summary>Removes all tabs from the tab widget associated with this tab host.</summary>
		/// <remarks>Removes all tabs from the tab widget associated with this tab host.</remarks>
		public virtual void clearAllTabs()
		{
			mTabWidget.removeAllViews();
			initTabHost();
			mTabContent.removeAllViews();
			mTabSpecs.clear();
			requestLayout();
			invalidate();
		}

		public virtual android.widget.TabWidget getTabWidget()
		{
			return mTabWidget;
		}

		public virtual int getCurrentTab()
		{
			return mCurrentTab;
		}

		public virtual string getCurrentTabTag()
		{
			if (mCurrentTab >= 0 && mCurrentTab < mTabSpecs.size())
			{
				return mTabSpecs.get(mCurrentTab).getTag();
			}
			return null;
		}

		public virtual android.view.View getCurrentTabView()
		{
			if (mCurrentTab >= 0 && mCurrentTab < mTabSpecs.size())
			{
				return mTabWidget.getChildTabViewAt(mCurrentTab);
			}
			return null;
		}

		public virtual android.view.View getCurrentView()
		{
			return mCurrentView;
		}

		public virtual void setCurrentTabByTag(string tag)
		{
			int i;
			for (i = 0; i < mTabSpecs.size(); i++)
			{
				if (mTabSpecs.get(i).getTag().Equals(tag))
				{
					setCurrentTab(i);
					break;
				}
			}
		}

		/// <summary>Get the FrameLayout which holds tab content</summary>
		public virtual android.widget.FrameLayout getTabContentView()
		{
			return mTabContent;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool dispatchKeyEvent(android.view.KeyEvent @event)
		{
			bool handled = base.dispatchKeyEvent(@event);
			// unhandled key ups change focus to tab indicator for embedded activities
			// when there is nothing that will take focus from default focus searching
			if (!handled && (@event.getAction() == android.view.KeyEvent.ACTION_DOWN) && (@event
				.getKeyCode() == android.view.KeyEvent.KEYCODE_DPAD_UP) && (mCurrentView != null
				) && (mCurrentView.isRootNamespace()) && (mCurrentView.hasFocus()) && (mCurrentView
				.findFocus().focusSearch(android.view.View.FOCUS_UP) == null))
			{
				mTabWidget.getChildTabViewAt(mCurrentTab).requestFocus();
				playSoundEffect(android.view.SoundEffectConstants.NAVIGATION_UP);
				return true;
			}
			return handled;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void dispatchWindowFocusChanged(bool hasFocus_1)
		{
			if (mCurrentView != null)
			{
				mCurrentView.dispatchWindowFocusChanged(hasFocus_1);
			}
		}

		public virtual void setCurrentTab(int index)
		{
			if (index < 0 || index >= mTabSpecs.size())
			{
				return;
			}
			if (index == mCurrentTab)
			{
				return;
			}
			// notify old tab content
			if (mCurrentTab != -1)
			{
				mTabSpecs.get(mCurrentTab).mContentStrategy.tabClosed();
			}
			mCurrentTab = index;
			android.widget.TabHost.TabSpec spec = mTabSpecs.get(index);
			// Call the tab widget's focusCurrentTab(), instead of just
			// selecting the tab.
			mTabWidget.focusCurrentTab(mCurrentTab);
			// tab content
			mCurrentView = spec.mContentStrategy.getContentView();
			if (mCurrentView.getParent() == null)
			{
				mTabContent.addView(mCurrentView, new android.view.ViewGroup.LayoutParams(android.view.ViewGroup
					.LayoutParams.MATCH_PARENT, android.view.ViewGroup.LayoutParams.MATCH_PARENT));
			}
			if (!mTabWidget.hasFocus())
			{
				// if the tab widget didn't take focus (likely because we're in touch mode)
				// give the current tab content view a shot
				mCurrentView.requestFocus();
			}
			//mTabContent.requestFocus(View.FOCUS_FORWARD);
			invokeOnTabChangeListener();
		}

		/// <summary>
		/// Register a callback to be invoked when the selected state of any of the items
		/// in this list changes
		/// </summary>
		/// <param name="l">The callback that will run</param>
		public virtual void setOnTabChangedListener(android.widget.TabHost.OnTabChangeListener
			 l)
		{
			mOnTabChangeListener = l;
		}

		private void invokeOnTabChangeListener()
		{
			if (mOnTabChangeListener != null)
			{
				mOnTabChangeListener.onTabChanged(getCurrentTabTag());
			}
		}

		/// <summary>Interface definition for a callback to be invoked when tab changed</summary>
		public interface OnTabChangeListener
		{
			void onTabChanged(string tabId);
		}

		/// <summary>Makes the content of a tab when it is selected.</summary>
		/// <remarks>
		/// Makes the content of a tab when it is selected. Use this if your tab
		/// content needs to be created on demand, i.e. you are not showing an
		/// existing view or starting an activity.
		/// </remarks>
		public interface TabContentFactory
		{
			/// <summary>Callback to make the tab contents</summary>
			/// <param name="tag">Which tab was selected.</param>
			/// <returns>The view to display the contents of the selected tab.</returns>
			android.view.View createTabContent(string tag);
		}

		/// <summary>
		/// A tab has a tab indicator, content, and a tag that is used to keep
		/// track of it.
		/// </summary>
		/// <remarks>
		/// A tab has a tab indicator, content, and a tag that is used to keep
		/// track of it.  This builder helps choose among these options.
		/// For the tab indicator, your choices are:
		/// 1) set a label
		/// 2) set a label and an icon
		/// For the tab content, your choices are:
		/// 1) the id of a
		/// <see cref="android.view.View">android.view.View</see>
		/// 2) a
		/// <see cref="TabContentFactory">TabContentFactory</see>
		/// that creates the
		/// <see cref="android.view.View">android.view.View</see>
		/// content.
		/// 3) an
		/// <see cref="android.content.Intent">android.content.Intent</see>
		/// that launches an
		/// <see cref="android.app.Activity">android.app.Activity</see>
		/// .
		/// </remarks>
		public class TabSpec
		{
			internal string mTag;

			internal android.widget.TabHost.IndicatorStrategy mIndicatorStrategy;

			internal android.widget.TabHost.ContentStrategy mContentStrategy;

			internal TabSpec(TabHost _enclosing, string tag)
			{
				this._enclosing = _enclosing;
				this.mTag = tag;
			}

			/// <summary>Specify a label as the tab indicator.</summary>
			/// <remarks>Specify a label as the tab indicator.</remarks>
			public virtual android.widget.TabHost.TabSpec setIndicator(java.lang.CharSequence
				 label)
			{
				this.mIndicatorStrategy = new android.widget.TabHost.LabelIndicatorStrategy(this.
					_enclosing, label);
				return this;
			}

			/// <summary>Specify a label and icon as the tab indicator.</summary>
			/// <remarks>Specify a label and icon as the tab indicator.</remarks>
			public virtual android.widget.TabHost.TabSpec setIndicator(java.lang.CharSequence
				 label, android.graphics.drawable.Drawable icon)
			{
				this.mIndicatorStrategy = new android.widget.TabHost.LabelAndIconIndicatorStrategy
					(this._enclosing, label, icon);
				return this;
			}

			/// <summary>Specify a view as the tab indicator.</summary>
			/// <remarks>Specify a view as the tab indicator.</remarks>
			public virtual android.widget.TabHost.TabSpec setIndicator(android.view.View view
				)
			{
				this.mIndicatorStrategy = new android.widget.TabHost.ViewIndicatorStrategy(this._enclosing
					, view);
				return this;
			}

			/// <summary>
			/// Specify the id of the view that should be used as the content
			/// of the tab.
			/// </summary>
			/// <remarks>
			/// Specify the id of the view that should be used as the content
			/// of the tab.
			/// </remarks>
			public virtual android.widget.TabHost.TabSpec setContent(int viewId)
			{
				this.mContentStrategy = new android.widget.TabHost.ViewIdContentStrategy(this._enclosing
					, viewId);
				return this;
			}

			/// <summary>
			/// Specify a
			/// <see cref="TabContentFactory">TabContentFactory</see>
			/// to use to
			/// create the content of the tab.
			/// </summary>
			public virtual android.widget.TabHost.TabSpec setContent(android.widget.TabHost.TabContentFactory
				 contentFactory)
			{
				this.mContentStrategy = new android.widget.TabHost.FactoryContentStrategy(this._enclosing
					, java.lang.CharSequenceProxy.Wrap(this.mTag), contentFactory);
				return this;
			}

			/// <summary>Specify an intent to use to launch an activity as the tab content.</summary>
			/// <remarks>Specify an intent to use to launch an activity as the tab content.</remarks>
			public virtual android.widget.TabHost.TabSpec setContent(android.content.Intent intent
				)
			{
				this.mContentStrategy = new android.widget.TabHost.IntentContentStrategy(this._enclosing
					, this.mTag, intent);
				return this;
			}

			public virtual string getTag()
			{
				return this.mTag;
			}

			private readonly TabHost _enclosing;
		}

		/// <summary>Specifies what you do to create a tab indicator.</summary>
		/// <remarks>Specifies what you do to create a tab indicator.</remarks>
		internal interface IndicatorStrategy
		{
			/// <summary>Return the view for the indicator.</summary>
			/// <remarks>Return the view for the indicator.</remarks>
			android.view.View createIndicatorView();
		}

		/// <summary>Specifies what you do to manage the tab content.</summary>
		/// <remarks>Specifies what you do to manage the tab content.</remarks>
		internal interface ContentStrategy
		{
			/// <summary>Return the content view.</summary>
			/// <remarks>Return the content view.  The view should may be cached locally.</remarks>
			android.view.View getContentView();

			/// <summary>
			/// Perhaps do something when the tab associated with this content has
			/// been closed (i.e make it invisible, or remove it).
			/// </summary>
			/// <remarks>
			/// Perhaps do something when the tab associated with this content has
			/// been closed (i.e make it invisible, or remove it).
			/// </remarks>
			void tabClosed();
		}

		/// <summary>How to create a tab indicator that just has a label.</summary>
		/// <remarks>How to create a tab indicator that just has a label.</remarks>
		private class LabelIndicatorStrategy : android.widget.TabHost.IndicatorStrategy
		{
			internal readonly java.lang.CharSequence mLabel;

			internal LabelIndicatorStrategy(TabHost _enclosing, java.lang.CharSequence label)
			{
				this._enclosing = _enclosing;
				this.mLabel = label;
			}

			[Sharpen.ImplementsInterface(@"android.widget.TabHost.IndicatorStrategy")]
			public virtual android.view.View createIndicatorView()
			{
				android.content.Context context = this._enclosing.getContext();
				android.view.LayoutInflater inflater = (android.view.LayoutInflater)context.getSystemService
					(android.content.Context.LAYOUT_INFLATER_SERVICE);
				android.view.View tabIndicator = inflater.inflate(this._enclosing.mTabLayoutId, this
					._enclosing.mTabWidget, false);
				// tab widget is the parent
				// no inflate params
				android.widget.TextView tv = (android.widget.TextView)tabIndicator.findViewById(android.@internal.R
					.id.title);
				tv.setText(this.mLabel);
				if (context.getApplicationInfo().targetSdkVersion <= android.os.Build.VERSION_CODES
					.DONUT)
				{
					// Donut apps get old color scheme
					tabIndicator.setBackgroundResource(android.@internal.R.drawable.tab_indicator_v4);
					tv.setTextColor(context.getResources().getColorStateList(android.@internal.R.color
						.tab_indicator_text_v4));
				}
				return tabIndicator;
			}

			private readonly TabHost _enclosing;
		}

		/// <summary>How we create a tab indicator that has a label and an icon</summary>
		private class LabelAndIconIndicatorStrategy : android.widget.TabHost.IndicatorStrategy
		{
			internal readonly java.lang.CharSequence mLabel;

			internal readonly android.graphics.drawable.Drawable mIcon;

			internal LabelAndIconIndicatorStrategy(TabHost _enclosing, java.lang.CharSequence
				 label, android.graphics.drawable.Drawable icon)
			{
				this._enclosing = _enclosing;
				this.mLabel = label;
				this.mIcon = icon;
			}

			[Sharpen.ImplementsInterface(@"android.widget.TabHost.IndicatorStrategy")]
			public virtual android.view.View createIndicatorView()
			{
				android.content.Context context = this._enclosing.getContext();
				android.view.LayoutInflater inflater = (android.view.LayoutInflater)context.getSystemService
					(android.content.Context.LAYOUT_INFLATER_SERVICE);
				android.view.View tabIndicator = inflater.inflate(this._enclosing.mTabLayoutId, this
					._enclosing.mTabWidget, false);
				// tab widget is the parent
				// no inflate params
				android.widget.TextView tv = (android.widget.TextView)tabIndicator.findViewById(android.@internal.R
					.id.title);
				android.widget.ImageView iconView = (android.widget.ImageView)tabIndicator.findViewById
					(android.@internal.R.id.icon);
				// when icon is gone by default, we're in exclusive mode
				bool exclusive = iconView.getVisibility() == android.view.View.GONE;
				bool bindIcon = !exclusive || android.text.TextUtils.isEmpty(this.mLabel);
				tv.setText(this.mLabel);
				if (bindIcon && this.mIcon != null)
				{
					iconView.setImageDrawable(this.mIcon);
					iconView.setVisibility(android.view.View.VISIBLE);
				}
				if (context.getApplicationInfo().targetSdkVersion <= android.os.Build.VERSION_CODES
					.DONUT)
				{
					// Donut apps get old color scheme
					tabIndicator.setBackgroundResource(android.@internal.R.drawable.tab_indicator_v4);
					tv.setTextColor(context.getResources().getColorStateList(android.@internal.R.color
						.tab_indicator_text_v4));
				}
				return tabIndicator;
			}

			private readonly TabHost _enclosing;
		}

		/// <summary>How to create a tab indicator by specifying a view.</summary>
		/// <remarks>How to create a tab indicator by specifying a view.</remarks>
		private class ViewIndicatorStrategy : android.widget.TabHost.IndicatorStrategy
		{
			internal readonly android.view.View mView;

			internal ViewIndicatorStrategy(TabHost _enclosing, android.view.View view)
			{
				this._enclosing = _enclosing;
				this.mView = view;
			}

			[Sharpen.ImplementsInterface(@"android.widget.TabHost.IndicatorStrategy")]
			public virtual android.view.View createIndicatorView()
			{
				return this.mView;
			}

			private readonly TabHost _enclosing;
		}

		/// <summary>How to create the tab content via a view id.</summary>
		/// <remarks>How to create the tab content via a view id.</remarks>
		private class ViewIdContentStrategy : android.widget.TabHost.ContentStrategy
		{
			internal readonly android.view.View mView;

			internal ViewIdContentStrategy(TabHost _enclosing, int viewId)
			{
				this._enclosing = _enclosing;
				this.mView = this._enclosing.mTabContent.findViewById(viewId);
				if (this.mView != null)
				{
					this.mView.setVisibility(android.view.View.GONE);
				}
				else
				{
					throw new java.lang.RuntimeException("Could not create tab content because " + "could not find view with id "
						 + viewId);
				}
			}

			[Sharpen.ImplementsInterface(@"android.widget.TabHost.ContentStrategy")]
			public virtual android.view.View getContentView()
			{
				this.mView.setVisibility(android.view.View.VISIBLE);
				return this.mView;
			}

			[Sharpen.ImplementsInterface(@"android.widget.TabHost.ContentStrategy")]
			public virtual void tabClosed()
			{
				this.mView.setVisibility(android.view.View.GONE);
			}

			private readonly TabHost _enclosing;
		}

		/// <summary>
		/// How tab content is managed using
		/// <see cref="TabContentFactory">TabContentFactory</see>
		/// .
		/// </summary>
		private class FactoryContentStrategy : android.widget.TabHost.ContentStrategy
		{
			internal android.view.View mTabContent;

			internal readonly java.lang.CharSequence mTag;

			internal android.widget.TabHost.TabContentFactory mFactory;

			public FactoryContentStrategy(TabHost _enclosing, java.lang.CharSequence tag, android.widget.TabHost
				.TabContentFactory factory)
			{
				this._enclosing = _enclosing;
				this.mTag = tag;
				this.mFactory = factory;
			}

			[Sharpen.ImplementsInterface(@"android.widget.TabHost.ContentStrategy")]
			public virtual android.view.View getContentView()
			{
				if (this.mTabContent == null)
				{
					this.mTabContent = this.mFactory.createTabContent(this.mTag.ToString());
				}
				this.mTabContent.setVisibility(android.view.View.VISIBLE);
				return this.mTabContent;
			}

			[Sharpen.ImplementsInterface(@"android.widget.TabHost.ContentStrategy")]
			public virtual void tabClosed()
			{
				this.mTabContent.setVisibility(android.view.View.GONE);
			}

			private readonly TabHost _enclosing;
		}

		/// <summary>
		/// How tab content is managed via an
		/// <see cref="android.content.Intent">android.content.Intent</see>
		/// : the content view is the
		/// decorview of the launched activity.
		/// </summary>
		private class IntentContentStrategy : android.widget.TabHost.ContentStrategy
		{
			internal readonly string mTag;

			internal readonly android.content.Intent mIntent;

			internal android.view.View mLaunchedView;

			internal IntentContentStrategy(TabHost _enclosing, string tag, android.content.Intent
				 intent)
			{
				this._enclosing = _enclosing;
				this.mTag = tag;
				this.mIntent = intent;
			}

			[Sharpen.ImplementsInterface(@"android.widget.TabHost.ContentStrategy")]
			public virtual android.view.View getContentView()
			{
				if (this._enclosing.mLocalActivityManager == null)
				{
					throw new System.InvalidOperationException("Did you forget to call 'public void setup(LocalActivityManager activityGroup)'?"
						);
				}
				android.view.Window w = this._enclosing.mLocalActivityManager.startActivity(this.
					mTag, this.mIntent);
				android.view.View wd = w != null ? w.getDecorView() : null;
				if (this.mLaunchedView != wd && this.mLaunchedView != null)
				{
					if (this.mLaunchedView.getParent() != null)
					{
						this._enclosing.mTabContent.removeView(this.mLaunchedView);
					}
				}
				this.mLaunchedView = wd;
				// XXX Set FOCUS_AFTER_DESCENDANTS on embedded activities for now so they can get
				// focus if none of their children have it. They need focus to be able to
				// display menu items.
				//
				// Replace this with something better when Bug 628886 is fixed...
				//
				if (this.mLaunchedView != null)
				{
					this.mLaunchedView.setVisibility(android.view.View.VISIBLE);
					this.mLaunchedView.setFocusableInTouchMode(true);
					((android.view.ViewGroup)this.mLaunchedView).setDescendantFocusability(android.view.ViewGroup
						.FOCUS_AFTER_DESCENDANTS);
				}
				return this.mLaunchedView;
			}

			[Sharpen.ImplementsInterface(@"android.widget.TabHost.ContentStrategy")]
			public virtual void tabClosed()
			{
				if (this.mLaunchedView != null)
				{
					this.mLaunchedView.setVisibility(android.view.View.GONE);
				}
			}

			private readonly TabHost _enclosing;
		}
	}
}

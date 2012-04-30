using Sharpen;

namespace android.view
{
	/// <summary>Abstract base class for a top-level window look and behavior policy.</summary>
	/// <remarks>
	/// Abstract base class for a top-level window look and behavior policy.  An
	/// instance of this class should be used as the top-level view added to the
	/// window manager. It provides standard UI policies such as a background, title
	/// area, default key processing, etc.
	/// <p>The only existing implementation of this abstract class is
	/// android.policy.PhoneWindow, which you should instantiate when needing a
	/// Window.  Eventually that class will be refactored and a factory method
	/// added for creating Window instances without knowing about a particular
	/// implementation.
	/// </remarks>
	[Sharpen.Sharpened]
	public abstract class Window
	{
		/// <summary>Flag for the "options panel" feature.</summary>
		/// <remarks>Flag for the "options panel" feature.  This is enabled by default.</remarks>
		public const int FEATURE_OPTIONS_PANEL = 0;

		/// <summary>
		/// Flag for the "no title" feature, turning off the title at the top
		/// of the screen.
		/// </summary>
		/// <remarks>
		/// Flag for the "no title" feature, turning off the title at the top
		/// of the screen.
		/// </remarks>
		public const int FEATURE_NO_TITLE = 1;

		/// <summary>Flag for the progress indicator feature</summary>
		public const int FEATURE_PROGRESS = 2;

		/// <summary>Flag for having an icon on the left side of the title bar</summary>
		public const int FEATURE_LEFT_ICON = 3;

		/// <summary>Flag for having an icon on the right side of the title bar</summary>
		public const int FEATURE_RIGHT_ICON = 4;

		/// <summary>Flag for indeterminate progress</summary>
		public const int FEATURE_INDETERMINATE_PROGRESS = 5;

		/// <summary>Flag for the context menu.</summary>
		/// <remarks>Flag for the context menu.  This is enabled by default.</remarks>
		public const int FEATURE_CONTEXT_MENU = 6;

		/// <summary>Flag for custom title.</summary>
		/// <remarks>Flag for custom title. You cannot combine this feature with other title features.
		/// 	</remarks>
		public const int FEATURE_CUSTOM_TITLE = 7;

		/// <summary>Flag for enabling the Action Bar.</summary>
		/// <remarks>
		/// Flag for enabling the Action Bar.
		/// This is enabled by default for some devices. The Action Bar
		/// replaces the title bar and provides an alternate location
		/// for an on-screen menu button on some devices.
		/// </remarks>
		public const int FEATURE_ACTION_BAR = 8;

		/// <summary>Flag for requesting an Action Bar that overlays window content.</summary>
		/// <remarks>
		/// Flag for requesting an Action Bar that overlays window content.
		/// Normally an Action Bar will sit in the space above window content, but if this
		/// feature is requested along with
		/// <see cref="FEATURE_ACTION_BAR">FEATURE_ACTION_BAR</see>
		/// it will be layered over
		/// the window content itself. This is useful if you would like your app to have more control
		/// over how the Action Bar is displayed, such as letting application content scroll beneath
		/// an Action Bar with a transparent background or otherwise displaying a transparent/translucent
		/// Action Bar over application content.
		/// </remarks>
		public const int FEATURE_ACTION_BAR_OVERLAY = 9;

		/// <summary>Flag for specifying the behavior of action modes when an Action Bar is not present.
		/// 	</summary>
		/// <remarks>
		/// Flag for specifying the behavior of action modes when an Action Bar is not present.
		/// If overlay is enabled, the action mode UI will be allowed to cover existing window content.
		/// </remarks>
		public const int FEATURE_ACTION_MODE_OVERLAY = 10;

		/// <summary>Flag for setting the progress bar's visibility to VISIBLE</summary>
		public const int PROGRESS_VISIBILITY_ON = -1;

		/// <summary>Flag for setting the progress bar's visibility to GONE</summary>
		public const int PROGRESS_VISIBILITY_OFF = -2;

		/// <summary>Flag for setting the progress bar's indeterminate mode on</summary>
		public const int PROGRESS_INDETERMINATE_ON = -3;

		/// <summary>Flag for setting the progress bar's indeterminate mode off</summary>
		public const int PROGRESS_INDETERMINATE_OFF = -4;

		/// <summary>Starting value for the (primary) progress</summary>
		public const int PROGRESS_START = 0;

		/// <summary>Ending value for the (primary) progress</summary>
		public const int PROGRESS_END = 10000;

		/// <summary>Lowest possible value for the secondary progress</summary>
		public const int PROGRESS_SECONDARY_START = 20000;

		/// <summary>Highest possible value for the secondary progress</summary>
		public const int PROGRESS_SECONDARY_END = 30000;

		/// <summary>The default features enabled</summary>
		internal const int DEFAULT_FEATURES = (1 << FEATURE_OPTIONS_PANEL) | (1 << FEATURE_CONTEXT_MENU
			);

		/// <summary>The ID that the main layout in the XML layout file should have.</summary>
		/// <remarks>The ID that the main layout in the XML layout file should have.</remarks>
		public const int ID_ANDROID_CONTENT = android.@internal.R.id.content;

		private readonly android.content.Context mContext;

		private android.content.res.TypedArray mWindowStyle;

		private android.view.Window.Callback mCallback;

		private android.view.WindowManager mWindowManager;

		private android.os.IBinder mAppToken;

		private string mAppName;

		private android.view.Window mContainer;

		private android.view.Window mActiveChild;

		private bool mIsActive = false;

		private bool mHasChildren = false;

		private bool mCloseOnTouchOutside = false;

		private bool mSetCloseOnTouchOutside = false;

		private int mForcedWindowFlags = 0;

		private int mFeatures = DEFAULT_FEATURES;

		private int mLocalFeatures = DEFAULT_FEATURES;

		private bool mHaveWindowFormat = false;

		private bool mHaveDimAmount = false;

		private int mDefaultWindowFormat = android.graphics.PixelFormat.OPAQUE;

		private bool mHasSoftInputMode = false;

		private bool mDestroyed;

		private readonly android.view.WindowManagerClass.LayoutParams mWindowAttributes = 
			new android.view.WindowManagerClass.LayoutParams();

		/// <summary>API from a Window back to its caller.</summary>
		/// <remarks>
		/// API from a Window back to its caller.  This allows the client to
		/// intercept key dispatching, panels and menus, etc.
		/// </remarks>
		public interface Callback
		{
			// The current window attributes.
			/// <summary>Called to process key events.</summary>
			/// <remarks>
			/// Called to process key events.  At the very least your
			/// implementation must call
			/// <see cref="Window.superDispatchKeyEvent(KeyEvent)">Window.superDispatchKeyEvent(KeyEvent)
			/// 	</see>
			/// to do the
			/// standard key processing.
			/// </remarks>
			/// <param name="event">The key event.</param>
			/// <returns>boolean Return true if this event was consumed.</returns>
			bool dispatchKeyEvent(android.view.KeyEvent @event);

			/// <summary>Called to process a key shortcut event.</summary>
			/// <remarks>
			/// Called to process a key shortcut event.
			/// At the very least your implementation must call
			/// <see cref="Window.superDispatchKeyShortcutEvent(KeyEvent)">Window.superDispatchKeyShortcutEvent(KeyEvent)
			/// 	</see>
			/// to do the
			/// standard key shortcut processing.
			/// </remarks>
			/// <param name="event">The key shortcut event.</param>
			/// <returns>True if this event was consumed.</returns>
			bool dispatchKeyShortcutEvent(android.view.KeyEvent @event);

			/// <summary>Called to process touch screen events.</summary>
			/// <remarks>
			/// Called to process touch screen events.  At the very least your
			/// implementation must call
			/// <see cref="Window.superDispatchTouchEvent(MotionEvent)">Window.superDispatchTouchEvent(MotionEvent)
			/// 	</see>
			/// to do the
			/// standard touch screen processing.
			/// </remarks>
			/// <param name="event">The touch screen event.</param>
			/// <returns>boolean Return true if this event was consumed.</returns>
			bool dispatchTouchEvent(android.view.MotionEvent @event);

			/// <summary>Called to process trackball events.</summary>
			/// <remarks>
			/// Called to process trackball events.  At the very least your
			/// implementation must call
			/// <see cref="Window.superDispatchTrackballEvent(MotionEvent)">Window.superDispatchTrackballEvent(MotionEvent)
			/// 	</see>
			/// to do the
			/// standard trackball processing.
			/// </remarks>
			/// <param name="event">The trackball event.</param>
			/// <returns>boolean Return true if this event was consumed.</returns>
			bool dispatchTrackballEvent(android.view.MotionEvent @event);

			/// <summary>Called to process generic motion events.</summary>
			/// <remarks>
			/// Called to process generic motion events.  At the very least your
			/// implementation must call
			/// <see cref="Window.superDispatchGenericMotionEvent(MotionEvent)">Window.superDispatchGenericMotionEvent(MotionEvent)
			/// 	</see>
			/// to do the
			/// standard processing.
			/// </remarks>
			/// <param name="event">The generic motion event.</param>
			/// <returns>boolean Return true if this event was consumed.</returns>
			bool dispatchGenericMotionEvent(android.view.MotionEvent @event);

			/// <summary>
			/// Called to process population of
			/// <see cref="android.view.accessibility.AccessibilityEvent">android.view.accessibility.AccessibilityEvent
			/// 	</see>
			/// s.
			/// </summary>
			/// <param name="event">The event.</param>
			/// <returns>boolean Return true if event population was completed.</returns>
			bool dispatchPopulateAccessibilityEvent(android.view.accessibility.AccessibilityEvent
				 @event);

			/// <summary>Instantiate the view to display in the panel for 'featureId'.</summary>
			/// <remarks>
			/// Instantiate the view to display in the panel for 'featureId'.
			/// You can return null, in which case the default content (typically
			/// a menu) will be created for you.
			/// </remarks>
			/// <param name="featureId">Which panel is being created.</param>
			/// <returns>view The top-level view to place in the panel.</returns>
			/// <seealso cref="onPreparePanel(int, View, Menu)">onPreparePanel(int, View, Menu)</seealso>
			android.view.View onCreatePanelView(int featureId);

			/// <summary>Initialize the contents of the menu for panel 'featureId'.</summary>
			/// <remarks>
			/// Initialize the contents of the menu for panel 'featureId'.  This is
			/// called if onCreatePanelView() returns null, giving you a standard
			/// menu in which you can place your items.  It is only called once for
			/// the panel, the first time it is shown.
			/// <p>You can safely hold on to <var>menu</var> (and any items created
			/// from it), making modifications to it as desired, until the next
			/// time onCreatePanelMenu() is called for this feature.
			/// </remarks>
			/// <param name="featureId">The panel being created.</param>
			/// <param name="menu">The menu inside the panel.</param>
			/// <returns>
			/// boolean You must return true for the panel to be displayed;
			/// if you return false it will not be shown.
			/// </returns>
			bool onCreatePanelMenu(int featureId, android.view.Menu menu);

			/// <summary>Prepare a panel to be displayed.</summary>
			/// <remarks>
			/// Prepare a panel to be displayed.  This is called right before the
			/// panel window is shown, every time it is shown.
			/// </remarks>
			/// <param name="featureId">The panel that is being displayed.</param>
			/// <param name="view">The View that was returned by onCreatePanelView().</param>
			/// <param name="menu">
			/// If onCreatePanelView() returned null, this is the Menu
			/// being displayed in the panel.
			/// </param>
			/// <returns>
			/// boolean You must return true for the panel to be displayed;
			/// if you return false it will not be shown.
			/// </returns>
			/// <seealso cref="onCreatePanelView(int)">onCreatePanelView(int)</seealso>
			bool onPreparePanel(int featureId, android.view.View view, android.view.Menu menu
				);

			/// <summary>Called when a panel's menu is opened by the user.</summary>
			/// <remarks>
			/// Called when a panel's menu is opened by the user. This may also be
			/// called when the menu is changing from one type to another (for
			/// example, from the icon menu to the expanded menu).
			/// </remarks>
			/// <param name="featureId">The panel that the menu is in.</param>
			/// <param name="menu">The menu that is opened.</param>
			/// <returns>
			/// Return true to allow the menu to open, or false to prevent
			/// the menu from opening.
			/// </returns>
			bool onMenuOpened(int featureId, android.view.Menu menu);

			/// <summary>Called when a panel's menu item has been selected by the user.</summary>
			/// <remarks>Called when a panel's menu item has been selected by the user.</remarks>
			/// <param name="featureId">The panel that the menu is in.</param>
			/// <param name="item">The menu item that was selected.</param>
			/// <returns>
			/// boolean Return true to finish processing of selection, or
			/// false to perform the normal menu handling (calling its
			/// Runnable or sending a Message to its target Handler).
			/// </returns>
			bool onMenuItemSelected(int featureId, android.view.MenuItem item);

			/// <summary>This is called whenever the current window attributes change.</summary>
			/// <remarks>This is called whenever the current window attributes change.</remarks>
			void onWindowAttributesChanged(android.view.WindowManagerClass.LayoutParams attrs
				);

			/// <summary>
			/// This hook is called whenever the content view of the screen changes
			/// (due to a call to
			/// <see cref="Window.setContentView(View, LayoutParams)">Window.setContentView</see>
			/// or
			/// <see cref="Window.addContentView(View, LayoutParams)">Window.addContentView</see>
			/// ).
			/// </summary>
			void onContentChanged();

			/// <summary>This hook is called whenever the window focus changes.</summary>
			/// <remarks>
			/// This hook is called whenever the window focus changes.  See
			/// <see cref="View.onWindowFocusChanged(bool)">View.onWindowFocusChanged(boolean)</see>
			/// for more information.
			/// </remarks>
			/// <param name="hasFocus">Whether the window now has focus.</param>
			void onWindowFocusChanged(bool hasFocus);

			/// <summary>Called when the window has been attached to the window manager.</summary>
			/// <remarks>
			/// Called when the window has been attached to the window manager.
			/// See
			/// <see cref="View.onAttachedToWindow()">View.onAttachedToWindow()</see>
			/// for more information.
			/// </remarks>
			void onAttachedToWindow();

			/// <summary>Called when the window has been attached to the window manager.</summary>
			/// <remarks>
			/// Called when the window has been attached to the window manager.
			/// See
			/// <see cref="View.onDetachedFromWindow()">View.onDetachedFromWindow()</see>
			/// for more information.
			/// </remarks>
			void onDetachedFromWindow();

			/// <summary>Called when a panel is being closed.</summary>
			/// <remarks>
			/// Called when a panel is being closed.  If another logical subsequent
			/// panel is being opened (and this panel is being closed to make room for the subsequent
			/// panel), this method will NOT be called.
			/// </remarks>
			/// <param name="featureId">The panel that is being displayed.</param>
			/// <param name="menu">
			/// If onCreatePanelView() returned null, this is the Menu
			/// being displayed in the panel.
			/// </param>
			void onPanelClosed(int featureId, android.view.Menu menu);

			/// <summary>Called when the user signals the desire to start a search.</summary>
			/// <remarks>Called when the user signals the desire to start a search.</remarks>
			/// <returns>true if search launched, false if activity refuses (blocks)</returns>
			/// <seealso cref="android.app.Activity.onSearchRequested()"></seealso>
			bool onSearchRequested();

			/// <summary>Called when an action mode is being started for this window.</summary>
			/// <remarks>
			/// Called when an action mode is being started for this window. Gives the
			/// callback an opportunity to handle the action mode in its own unique and
			/// beautiful way. If this method returns null the system can choose a way
			/// to present the mode or choose not to start the mode at all.
			/// </remarks>
			/// <param name="callback">Callback to control the lifecycle of this action mode</param>
			/// <returns>The ActionMode that was started, or null if the system should present it
			/// 	</returns>
			android.view.ActionMode onWindowStartingActionMode(android.view.ActionMode.Callback
				 callback);

			/// <summary>Called when an action mode has been started.</summary>
			/// <remarks>
			/// Called when an action mode has been started. The appropriate mode callback
			/// method will have already been invoked.
			/// </remarks>
			/// <param name="mode">The new mode that has just been started.</param>
			void onActionModeStarted(android.view.ActionMode mode);

			/// <summary>Called when an action mode has been finished.</summary>
			/// <remarks>
			/// Called when an action mode has been finished. The appropriate mode callback
			/// method will have already been invoked.
			/// </remarks>
			/// <param name="mode">The mode that was just finished.</param>
			void onActionModeFinished(android.view.ActionMode mode);
		}

		public Window(android.content.Context context)
		{
			mContext = context;
		}

		/// <summary>
		/// Return the Context this window policy is running in, for retrieving
		/// resources and other information.
		/// </summary>
		/// <remarks>
		/// Return the Context this window policy is running in, for retrieving
		/// resources and other information.
		/// </remarks>
		/// <returns>Context The Context that was supplied to the constructor.</returns>
		public android.content.Context getContext()
		{
			return mContext;
		}

		/// <summary>
		/// Return the
		/// <see cref="android.R.styleable.Window">android.R.styleable.Window</see>
		/// attributes from this
		/// window's theme.
		/// </summary>
		public android.content.res.TypedArray getWindowStyle()
		{
			lock (this)
			{
				if (mWindowStyle == null)
				{
					mWindowStyle = mContext.obtainStyledAttributes(android.@internal.R.styleable.Window
						);
				}
				return mWindowStyle;
			}
		}

		/// <summary>Set the container for this window.</summary>
		/// <remarks>
		/// Set the container for this window.  If not set, the DecorWindow
		/// operates as a top-level window; otherwise, it negotiates with the
		/// container to display itself appropriately.
		/// </remarks>
		/// <param name="container">The desired containing Window.</param>
		public virtual void setContainer(android.view.Window container)
		{
			mContainer = container;
			if (container != null)
			{
				// Embedded screens never have a title.
				mFeatures |= 1 << FEATURE_NO_TITLE;
				mLocalFeatures |= 1 << FEATURE_NO_TITLE;
				container.mHasChildren = true;
			}
		}

		/// <summary>Return the container for this Window.</summary>
		/// <remarks>Return the container for this Window.</remarks>
		/// <returns>
		/// Window The containing window, or null if this is a
		/// top-level window.
		/// </returns>
		public android.view.Window getContainer()
		{
			return mContainer;
		}

		public bool hasChildren()
		{
			return mHasChildren;
		}

		/// <hide></hide>
		public void destroy()
		{
			mDestroyed = true;
		}

		/// <hide></hide>
		public bool isDestroyed()
		{
			return mDestroyed;
		}

		/// <summary>
		/// Set the window manager for use by this Window to, for example,
		/// display panels.
		/// </summary>
		/// <remarks>
		/// Set the window manager for use by this Window to, for example,
		/// display panels.  This is <em>not</em> used for displaying the
		/// Window itself -- that must be done by the client.
		/// </remarks>
		/// <param name="wm">The ViewManager for adding new windows.</param>
		public virtual void setWindowManager(android.view.WindowManager wm, android.os.IBinder
			 appToken, string appName)
		{
			setWindowManager(wm, appToken, appName, false);
		}

		/// <summary>
		/// Set the window manager for use by this Window to, for example,
		/// display panels.
		/// </summary>
		/// <remarks>
		/// Set the window manager for use by this Window to, for example,
		/// display panels.  This is <em>not</em> used for displaying the
		/// Window itself -- that must be done by the client.
		/// </remarks>
		/// <param name="wm">The ViewManager for adding new windows.</param>
		public virtual void setWindowManager(android.view.WindowManager wm, android.os.IBinder
			 appToken, string appName, bool hardwareAccelerated)
		{
			mAppToken = appToken;
			mAppName = appName;
			if (wm == null)
			{
				wm = android.view.WindowManagerImpl.getDefault();
			}
			mWindowManager = new android.view.Window.LocalWindowManager(this, wm, hardwareAccelerated
				);
		}

		internal static android.view.CompatibilityInfoHolder getCompatInfo(android.content.Context
			 context)
		{
			android.app.Application app = (android.app.Application)context.getApplicationContext
				();
			return app != null ? app.mLoadedApk.mCompatibilityInfo : new android.view.CompatibilityInfoHolder
				();
		}

		private class LocalWindowManager : android.view.WindowManagerImpl.CompatModeWrapper
		{
			internal const string PROPERTY_HARDWARE_UI = "persist.sys.ui.hw";

			internal readonly bool mHardwareAccelerated;

			internal LocalWindowManager(Window _enclosing, android.view.WindowManager wm, bool
				 hardwareAccelerated) : base(wm, android.view.Window.getCompatInfo(_enclosing.mContext
				))
			{
				this._enclosing = _enclosing;
				this.mHardwareAccelerated = hardwareAccelerated || android.os.SystemProperties.getBoolean
					(PROPERTY_HARDWARE_UI, false);
			}

			[Sharpen.OverridesMethod(@"android.view.WindowManagerImpl.CompatModeWrapper")]
			public override bool isHardwareAccelerated()
			{
				return this.mHardwareAccelerated;
			}

			[Sharpen.OverridesMethod(@"android.view.WindowManagerImpl.CompatModeWrapper")]
			public sealed override void addView(android.view.View view, android.view.ViewGroup
				.LayoutParams @params)
			{
				// Let this throw an exception on a bad params.
				android.view.WindowManagerClass.LayoutParams wp = (android.view.WindowManagerClass
					.LayoutParams)@params;
				java.lang.CharSequence curTitle = wp.getTitle();
				if (wp.type >= android.view.WindowManagerClass.LayoutParams.FIRST_SUB_WINDOW && wp
					.type <= android.view.WindowManagerClass.LayoutParams.LAST_SUB_WINDOW)
				{
					if (wp.token == null)
					{
						android.view.View decor = this._enclosing.peekDecorView();
						if (decor != null)
						{
							wp.token = decor.getWindowToken();
						}
					}
					if (curTitle == null || curTitle.Length == 0)
					{
						string title;
						if (wp.type == android.view.WindowManagerClass.LayoutParams.TYPE_APPLICATION_MEDIA)
						{
							title = "Media";
						}
						else
						{
							if (wp.type == android.view.WindowManagerClass.LayoutParams.TYPE_APPLICATION_MEDIA_OVERLAY)
							{
								title = "MediaOvr";
							}
							else
							{
								if (wp.type == android.view.WindowManagerClass.LayoutParams.TYPE_APPLICATION_PANEL)
								{
									title = "Panel";
								}
								else
								{
									if (wp.type == android.view.WindowManagerClass.LayoutParams.TYPE_APPLICATION_SUB_PANEL)
									{
										title = "SubPanel";
									}
									else
									{
										if (wp.type == android.view.WindowManagerClass.LayoutParams.TYPE_APPLICATION_ATTACHED_DIALOG)
										{
											title = "AtchDlg";
										}
										else
										{
											title = System.Convert.ToString(wp.type);
										}
									}
								}
							}
						}
						if (this._enclosing.mAppName != null)
						{
							title += ":" + this._enclosing.mAppName;
						}
						wp.setTitle(java.lang.CharSequenceProxy.Wrap(title));
					}
				}
				else
				{
					if (wp.token == null)
					{
						wp.token = this._enclosing.mContainer == null ? this._enclosing.mAppToken : this.
							_enclosing.mContainer.mAppToken;
					}
					if ((curTitle == null || curTitle.Length == 0) && this._enclosing.mAppName != null)
					{
						wp.setTitle(java.lang.CharSequenceProxy.Wrap(this._enclosing.mAppName));
					}
				}
				if (wp.packageName == null)
				{
					wp.packageName = this._enclosing.mContext.getPackageName();
				}
				if (this.mHardwareAccelerated)
				{
					wp.flags |= android.view.WindowManagerClass.LayoutParams.FLAG_HARDWARE_ACCELERATED;
				}
				base.addView(view, @params);
			}

			private readonly Window _enclosing;
		}

		/// <summary>
		/// Return the window manager allowing this Window to display its own
		/// windows.
		/// </summary>
		/// <remarks>
		/// Return the window manager allowing this Window to display its own
		/// windows.
		/// </remarks>
		/// <returns>WindowManager The ViewManager.</returns>
		public virtual android.view.WindowManager getWindowManager()
		{
			return mWindowManager;
		}

		/// <summary>
		/// Set the Callback interface for this window, used to intercept key
		/// events and other dynamic operations in the window.
		/// </summary>
		/// <remarks>
		/// Set the Callback interface for this window, used to intercept key
		/// events and other dynamic operations in the window.
		/// </remarks>
		/// <param name="callback">The desired Callback interface.</param>
		public virtual void setCallback(android.view.Window.Callback callback)
		{
			mCallback = callback;
		}

		/// <summary>Return the current Callback interface for this window.</summary>
		/// <remarks>Return the current Callback interface for this window.</remarks>
		public android.view.Window.Callback getCallback()
		{
			return mCallback;
		}

		/// <summary>Take ownership of this window's surface.</summary>
		/// <remarks>
		/// Take ownership of this window's surface.  The window's view hierarchy
		/// will no longer draw into the surface, though it will otherwise continue
		/// to operate (such as for receiving input events).  The given SurfaceHolder
		/// callback will be used to tell you about state changes to the surface.
		/// </remarks>
		public abstract void takeSurface(android.view.SurfaceHolderClass.Callback2 callback
			);

		/// <summary>Take ownership of this window's InputQueue.</summary>
		/// <remarks>
		/// Take ownership of this window's InputQueue.  The window will no
		/// longer read and dispatch input events from the queue; it is your
		/// responsibility to do so.
		/// </remarks>
		public abstract void takeInputQueue(android.view.InputQueue.Callback callback);

		/// <summary>
		/// Return whether this window is being displayed with a floating style
		/// (based on the
		/// <see cref="android.R.attr.windowIsFloating">android.R.attr.windowIsFloating</see>
		/// attribute in
		/// the style/theme).
		/// </summary>
		/// <returns>
		/// Returns true if the window is configured to be displayed floating
		/// on top of whatever is behind it.
		/// </returns>
		public abstract bool isFloating();

		/// <summary>Set the width and height layout parameters of the window.</summary>
		/// <remarks>
		/// Set the width and height layout parameters of the window.  The default
		/// for both of these is MATCH_PARENT; you can change them to WRAP_CONTENT
		/// or an absolute value to make a window that is not full-screen.
		/// </remarks>
		/// <param name="width">The desired layout width of the window.</param>
		/// <param name="height">The desired layout height of the window.</param>
		/// <seealso cref="LayoutParams.height">LayoutParams.height</seealso>
		/// <seealso cref="LayoutParams.width">LayoutParams.width</seealso>
		public virtual void setLayout(int width, int height)
		{
			android.view.WindowManagerClass.LayoutParams attrs = getAttributes();
			attrs.width = width;
			attrs.height = height;
			if (mCallback != null)
			{
				mCallback.onWindowAttributesChanged(attrs);
			}
		}

		/// <summary>Set the gravity of the window, as per the Gravity constants.</summary>
		/// <remarks>
		/// Set the gravity of the window, as per the Gravity constants.  This
		/// controls how the window manager is positioned in the overall window; it
		/// is only useful when using WRAP_CONTENT for the layout width or height.
		/// </remarks>
		/// <param name="gravity">The desired gravity constant.</param>
		/// <seealso cref="Gravity">Gravity</seealso>
		/// <seealso cref="setLayout(int, int)">setLayout(int, int)</seealso>
		public virtual void setGravity(int gravity)
		{
			android.view.WindowManagerClass.LayoutParams attrs = getAttributes();
			attrs.gravity = gravity;
			if (mCallback != null)
			{
				mCallback.onWindowAttributesChanged(attrs);
			}
		}

		/// <summary>
		/// Set the type of the window, as per the WindowManager.LayoutParams
		/// types.
		/// </summary>
		/// <remarks>
		/// Set the type of the window, as per the WindowManager.LayoutParams
		/// types.
		/// </remarks>
		/// <param name="type">The new window type (see WindowManager.LayoutParams).</param>
		public virtual void setType(int type)
		{
			android.view.WindowManagerClass.LayoutParams attrs = getAttributes();
			attrs.type = type;
			if (mCallback != null)
			{
				mCallback.onWindowAttributesChanged(attrs);
			}
		}

		/// <summary>Set the format of window, as per the PixelFormat types.</summary>
		/// <remarks>
		/// Set the format of window, as per the PixelFormat types.  This overrides
		/// the default format that is selected by the Window based on its
		/// window decorations.
		/// </remarks>
		/// <param name="format">
		/// The new window format (see PixelFormat).  Use
		/// PixelFormat.UNKNOWN to allow the Window to select
		/// the format.
		/// </param>
		/// <seealso cref="android.graphics.PixelFormat">android.graphics.PixelFormat</seealso>
		public virtual void setFormat(int format)
		{
			android.view.WindowManagerClass.LayoutParams attrs = getAttributes();
			if (format != android.graphics.PixelFormat.UNKNOWN)
			{
				attrs.format = format;
				mHaveWindowFormat = true;
			}
			else
			{
				attrs.format = mDefaultWindowFormat;
				mHaveWindowFormat = false;
			}
			if (mCallback != null)
			{
				mCallback.onWindowAttributesChanged(attrs);
			}
		}

		/// <summary>
		/// Specify custom animations to use for the window, as per
		/// <see cref="LayoutParams.windowAnimations">WindowManager.LayoutParams.windowAnimations
		/// 	</see>
		/// .  Providing anything besides
		/// 0 here will override the animations the window would
		/// normally retrieve from its theme.
		/// </summary>
		public virtual void setWindowAnimations(int resId)
		{
			android.view.WindowManagerClass.LayoutParams attrs = getAttributes();
			attrs.windowAnimations = resId;
			if (mCallback != null)
			{
				mCallback.onWindowAttributesChanged(attrs);
			}
		}

		/// <summary>
		/// Specify an explicit soft input mode to use for the window, as per
		/// <see cref="LayoutParams.softInputMode">WindowManager.LayoutParams.softInputMode</see>
		/// .  Providing anything besides
		/// "unspecified" here will override the input mode the window would
		/// normally retrieve from its theme.
		/// </summary>
		public virtual void setSoftInputMode(int mode)
		{
			android.view.WindowManagerClass.LayoutParams attrs = getAttributes();
			if (mode != android.view.WindowManagerClass.LayoutParams.SOFT_INPUT_STATE_UNSPECIFIED)
			{
				attrs.softInputMode = mode;
				mHasSoftInputMode = true;
			}
			else
			{
				mHasSoftInputMode = false;
			}
			if (mCallback != null)
			{
				mCallback.onWindowAttributesChanged(attrs);
			}
		}

		/// <summary>
		/// Convenience function to set the flag bits as specified in flags, as
		/// per
		/// <see cref="setFlags(int, int)">setFlags(int, int)</see>
		/// .
		/// </summary>
		/// <param name="flags">The flag bits to be set.</param>
		/// <seealso cref="setFlags(int, int)">setFlags(int, int)</seealso>
		public virtual void addFlags(int flags)
		{
			setFlags(flags, flags);
		}

		/// <summary>
		/// Convenience function to clear the flag bits as specified in flags, as
		/// per
		/// <see cref="setFlags(int, int)">setFlags(int, int)</see>
		/// .
		/// </summary>
		/// <param name="flags">The flag bits to be cleared.</param>
		/// <seealso cref="setFlags(int, int)">setFlags(int, int)</seealso>
		public virtual void clearFlags(int flags)
		{
			setFlags(0, flags);
		}

		/// <summary>
		/// Set the flags of the window, as per the
		/// <see cref="LayoutParams">LayoutParams</see>
		/// flags.
		/// <p>Note that some flags must be set before the window decoration is
		/// created (by the first call to
		/// <see cref="setContentView(View, LayoutParams)">setContentView(View, LayoutParams)
		/// 	</see>
		/// or
		/// <see cref="getDecorView()">getDecorView()</see>
		/// :
		/// <see cref="LayoutParams.FLAG_LAYOUT_IN_SCREEN">LayoutParams.FLAG_LAYOUT_IN_SCREEN
		/// 	</see>
		/// and
		/// <see cref="LayoutParams.FLAG_LAYOUT_INSET_DECOR">LayoutParams.FLAG_LAYOUT_INSET_DECOR
		/// 	</see>
		/// .  These
		/// will be set for you based on the
		/// <see cref="android.R.attr.windowIsFloating">android.R.attr.windowIsFloating</see>
		/// attribute.
		/// </summary>
		/// <param name="flags">The new window flags (see WindowManager.LayoutParams).</param>
		/// <param name="mask">Which of the window flag bits to modify.</param>
		public virtual void setFlags(int flags, int mask)
		{
			android.view.WindowManagerClass.LayoutParams attrs = getAttributes();
			attrs.flags = (attrs.flags & ~mask) | (flags & mask);
			mForcedWindowFlags |= mask;
			if (mCallback != null)
			{
				mCallback.onWindowAttributesChanged(attrs);
			}
		}

		/// <summary>
		/// Set the amount of dim behind the window when using
		/// <see cref="LayoutParams.FLAG_DIM_BEHIND">LayoutParams.FLAG_DIM_BEHIND</see>
		/// .  This overrides
		/// the default dim amount of that is selected by the Window based on
		/// its theme.
		/// </summary>
		/// <param name="amount">The new dim amount, from 0 for no dim to 1 for full dim.</param>
		public virtual void setDimAmount(float amount)
		{
			android.view.WindowManagerClass.LayoutParams attrs = getAttributes();
			attrs.dimAmount = amount;
			mHaveDimAmount = true;
			if (mCallback != null)
			{
				mCallback.onWindowAttributesChanged(attrs);
			}
		}

		/// <summary>Specify custom window attributes.</summary>
		/// <remarks>
		/// Specify custom window attributes.  <strong>PLEASE NOTE:</strong> the
		/// layout params you give here should generally be from values previously
		/// retrieved with
		/// <see cref="getAttributes()">getAttributes()</see>
		/// ; you probably do not want to
		/// blindly create and apply your own, since this will blow away any values
		/// set by the framework that you are not interested in.
		/// </remarks>
		/// <param name="a">
		/// The new window attributes, which will completely override any
		/// current values.
		/// </param>
		public virtual void setAttributes(android.view.WindowManagerClass.LayoutParams a)
		{
			mWindowAttributes.copyFrom(a);
			if (mCallback != null)
			{
				mCallback.onWindowAttributesChanged(mWindowAttributes);
			}
		}

		/// <summary>Retrieve the current window attributes associated with this panel.</summary>
		/// <remarks>Retrieve the current window attributes associated with this panel.</remarks>
		/// <returns>
		/// WindowManager.LayoutParams Either the existing window
		/// attributes object, or a freshly created one if there is none.
		/// </returns>
		public android.view.WindowManagerClass.LayoutParams getAttributes()
		{
			return mWindowAttributes;
		}

		/// <summary>
		/// Return the window flags that have been explicitly set by the client,
		/// so will not be modified by
		/// <see cref="getDecorView()">getDecorView()</see>
		/// .
		/// </summary>
		protected internal int getForcedWindowFlags()
		{
			return mForcedWindowFlags;
		}

		/// <summary>Has the app specified their own soft input mode?</summary>
		protected internal bool hasSoftInputMode()
		{
			return mHasSoftInputMode;
		}

		/// <hide></hide>
		public virtual void setCloseOnTouchOutside(bool close)
		{
			mCloseOnTouchOutside = close;
			mSetCloseOnTouchOutside = true;
		}

		/// <hide></hide>
		public virtual void setCloseOnTouchOutsideIfNotSet(bool close)
		{
			if (!mSetCloseOnTouchOutside)
			{
				mCloseOnTouchOutside = close;
				mSetCloseOnTouchOutside = true;
			}
		}

		/// <hide></hide>
		public abstract void alwaysReadCloseOnTouchAttr();

		/// <hide></hide>
		public virtual bool shouldCloseOnTouch(android.content.Context context, android.view.MotionEvent
			 @event)
		{
			if (mCloseOnTouchOutside && @event.getAction() == android.view.MotionEvent.ACTION_DOWN
				 && isOutOfBounds(context, @event) && peekDecorView() != null)
			{
				return true;
			}
			return false;
		}

		private bool isOutOfBounds(android.content.Context context, android.view.MotionEvent
			 @event)
		{
			int x = (int)@event.getX();
			int y = (int)@event.getY();
			int slop = android.view.ViewConfiguration.get(context).getScaledWindowTouchSlop();
			android.view.View decorView = getDecorView();
			return (x < -slop) || (y < -slop) || (x > (decorView.getWidth() + slop)) || (y > 
				(decorView.getHeight() + slop));
		}

		/// <summary>Enable extended screen features.</summary>
		/// <remarks>
		/// Enable extended screen features.  This must be called before
		/// setContentView().  May be called as many times as desired as long as it
		/// is before setContentView().  If not called, no extended features
		/// will be available.  You can not turn off a feature once it is requested.
		/// You canot use other title features with
		/// <see cref="FEATURE_CUSTOM_TITLE">FEATURE_CUSTOM_TITLE</see>
		/// .
		/// </remarks>
		/// <param name="featureId">The desired features, defined as constants by Window.</param>
		/// <returns>The features that are now set.</returns>
		public virtual bool requestFeature(int featureId)
		{
			int flag = 1 << featureId;
			mFeatures |= flag;
			mLocalFeatures |= mContainer != null ? (flag & ~mContainer.mFeatures) : flag;
			return (mFeatures & flag) != 0;
		}

		/// <hide>Used internally to help resolve conflicting features.</hide>
		protected internal virtual void removeFeature(int featureId)
		{
			int flag = 1 << featureId;
			mFeatures &= ~flag;
			mLocalFeatures &= ~(mContainer != null ? (flag & ~mContainer.mFeatures) : flag);
		}

		public void makeActive()
		{
			if (mContainer != null)
			{
				if (mContainer.mActiveChild != null)
				{
					mContainer.mActiveChild.mIsActive = false;
				}
				mContainer.mActiveChild = this;
			}
			mIsActive = true;
			onActive();
		}

		public bool isActive()
		{
			return mIsActive;
		}

		/// <summary>
		/// Finds a view that was identified by the id attribute from the XML that
		/// was processed in
		/// <see cref="android.app.Activity.onCreate(android.os.Bundle)">android.app.Activity.onCreate(android.os.Bundle)
		/// 	</see>
		/// .  This will
		/// implicitly call
		/// <see cref="getDecorView()">getDecorView()</see>
		/// for you, with all of the
		/// associated side-effects.
		/// </summary>
		/// <returns>The view if found or null otherwise.</returns>
		public virtual android.view.View findViewById(int id)
		{
			return getDecorView().findViewById(id);
		}

		/// <summary>
		/// Convenience for
		/// <see cref="setContentView(View, LayoutParams)">setContentView(View, LayoutParams)
		/// 	</see>
		/// to set the screen content from a layout resource.  The resource will be
		/// inflated, adding all top-level views to the screen.
		/// </summary>
		/// <param name="layoutResID">Resource ID to be inflated.</param>
		/// <seealso cref="setContentView(View, LayoutParams)">setContentView(View, LayoutParams)
		/// 	</seealso>
		public abstract void setContentView(int layoutResID);

		/// <summary>
		/// Convenience for
		/// <see cref="setContentView(View, LayoutParams)">setContentView(View, LayoutParams)
		/// 	</see>
		/// set the screen content to an explicit view.  This view is placed
		/// directly into the screen's view hierarchy.  It can itself be a complex
		/// view hierarhcy.
		/// </summary>
		/// <param name="view">The desired content to display.</param>
		/// <seealso cref="setContentView(View, LayoutParams)">setContentView(View, LayoutParams)
		/// 	</seealso>
		public abstract void setContentView(android.view.View view);

		/// <summary>Set the screen content to an explicit view.</summary>
		/// <remarks>
		/// Set the screen content to an explicit view.  This view is placed
		/// directly into the screen's view hierarchy.  It can itself be a complex
		/// view hierarchy.
		/// <p>Note that calling this function "locks in" various characteristics
		/// of the window that can not, from this point forward, be changed: the
		/// features that have been requested with
		/// <see cref="requestFeature(int)">requestFeature(int)</see>
		/// ,
		/// and certain window flags as described in
		/// <see cref="setFlags(int, int)">setFlags(int, int)</see>
		/// .
		/// </remarks>
		/// <param name="view">The desired content to display.</param>
		/// <param name="params">Layout parameters for the view.</param>
		public abstract void setContentView(android.view.View view, android.view.ViewGroup
			.LayoutParams @params);

		/// <summary>
		/// Variation on
		/// <see cref="setContentView(View, LayoutParams)">setContentView(View, LayoutParams)
		/// 	</see>
		/// to add an additional content view to the screen.  Added after any existing
		/// ones in the screen -- existing views are NOT removed.
		/// </summary>
		/// <param name="view">The desired content to display.</param>
		/// <param name="params">Layout parameters for the view.</param>
		public abstract void addContentView(android.view.View view, android.view.ViewGroup
			.LayoutParams @params);

		/// <summary>
		/// Return the view in this Window that currently has focus, or null if
		/// there are none.
		/// </summary>
		/// <remarks>
		/// Return the view in this Window that currently has focus, or null if
		/// there are none.  Note that this does not look in any containing
		/// Window.
		/// </remarks>
		/// <returns>View The current View with focus or null.</returns>
		public abstract android.view.View getCurrentFocus();

		/// <summary>
		/// Quick access to the
		/// <see cref="LayoutInflater">LayoutInflater</see>
		/// instance that this Window
		/// retrieved from its Context.
		/// </summary>
		/// <returns>LayoutInflater The shared LayoutInflater.</returns>
		public abstract android.view.LayoutInflater getLayoutInflater();

		public abstract void setTitle(java.lang.CharSequence title);

		public abstract void setTitleColor(int textColor);

		public abstract void openPanel(int featureId, android.view.KeyEvent @event);

		public abstract void closePanel(int featureId);

		public abstract void togglePanel(int featureId, android.view.KeyEvent @event);

		public abstract void invalidatePanelMenu(int featureId);

		public abstract bool performPanelShortcut(int featureId, int keyCode, android.view.KeyEvent
			 @event, int flags);

		public abstract bool performPanelIdentifierAction(int featureId, int id, int flags
			);

		public abstract void closeAllPanels();

		public abstract bool performContextMenuIdentifierAction(int id, int flags);

		/// <summary>Should be called when the configuration is changed.</summary>
		/// <remarks>Should be called when the configuration is changed.</remarks>
		/// <param name="newConfig">The new configuration.</param>
		public abstract void onConfigurationChanged(android.content.res.Configuration newConfig
			);

		/// <summary>Change the background of this window to a Drawable resource.</summary>
		/// <remarks>
		/// Change the background of this window to a Drawable resource. Setting the
		/// background to null will make the window be opaque. To make the window
		/// transparent, you can use an empty drawable (for instance a ColorDrawable
		/// with the color 0 or the system drawable android:drawable/empty.)
		/// </remarks>
		/// <param name="resid">
		/// The resource identifier of a drawable resource which will be
		/// installed as the new background.
		/// </param>
		public virtual void setBackgroundDrawableResource(int resid)
		{
			setBackgroundDrawable(mContext.getResources().getDrawable(resid));
		}

		/// <summary>Change the background of this window to a custom Drawable.</summary>
		/// <remarks>
		/// Change the background of this window to a custom Drawable. Setting the
		/// background to null will make the window be opaque. To make the window
		/// transparent, you can use an empty drawable (for instance a ColorDrawable
		/// with the color 0 or the system drawable android:drawable/empty.)
		/// </remarks>
		/// <param name="drawable">The new Drawable to use for this window's background.</param>
		public abstract void setBackgroundDrawable(android.graphics.drawable.Drawable drawable
			);

		/// <summary>
		/// Set the value for a drawable feature of this window, from a resource
		/// identifier.
		/// </summary>
		/// <remarks>
		/// Set the value for a drawable feature of this window, from a resource
		/// identifier.  You must have called requestFeauture(featureId) before
		/// calling this function.
		/// </remarks>
		/// <seealso cref="android.content.res.Resources.getDrawable(int)">android.content.res.Resources.getDrawable(int)
		/// 	</seealso>
		/// <param name="featureId">
		/// The desired drawable feature to change, defined as a
		/// constant by Window.
		/// </param>
		/// <param name="resId">Resource identifier of the desired image.</param>
		public abstract void setFeatureDrawableResource(int featureId, int resId);

		/// <summary>Set the value for a drawable feature of this window, from a URI.</summary>
		/// <remarks>
		/// Set the value for a drawable feature of this window, from a URI. You
		/// must have called requestFeature(featureId) before calling this
		/// function.
		/// <p>The only URI currently supported is "content:", specifying an image
		/// in a content provider.
		/// </remarks>
		/// <seealso cref="android.widget.ImageView.setImageURI(System.Uri)">android.widget.ImageView.setImageURI(System.Uri)
		/// 	</seealso>
		/// <param name="featureId">
		/// The desired drawable feature to change. Features are
		/// constants defined by Window.
		/// </param>
		/// <param name="uri">The desired URI.</param>
		public abstract void setFeatureDrawableUri(int featureId, System.Uri uri);

		/// <summary>Set an explicit Drawable value for feature of this window.</summary>
		/// <remarks>
		/// Set an explicit Drawable value for feature of this window. You must
		/// have called requestFeature(featureId) before calling this function.
		/// </remarks>
		/// <param name="featureId">
		/// The desired drawable feature to change.
		/// Features are constants defined by Window.
		/// </param>
		/// <param name="drawable">A Drawable object to display.</param>
		public abstract void setFeatureDrawable(int featureId, android.graphics.drawable.Drawable
			 drawable);

		/// <summary>
		/// Set a custom alpha value for the given drawale feature, controlling how
		/// much the background is visible through it.
		/// </summary>
		/// <remarks>
		/// Set a custom alpha value for the given drawale feature, controlling how
		/// much the background is visible through it.
		/// </remarks>
		/// <param name="featureId">
		/// The desired drawable feature to change.
		/// Features are constants defined by Window.
		/// </param>
		/// <param name="alpha">
		/// The alpha amount, 0 is completely transparent and 255 is
		/// completely opaque.
		/// </param>
		public abstract void setFeatureDrawableAlpha(int featureId, int alpha);

		/// <summary>Set the integer value for a feature.</summary>
		/// <remarks>
		/// Set the integer value for a feature.  The range of the value depends on
		/// the feature being set.  For FEATURE_PROGRESSS, it should go from 0 to
		/// 10000. At 10000 the progress is complete and the indicator hidden.
		/// </remarks>
		/// <param name="featureId">
		/// The desired feature to change.
		/// Features are constants defined by Window.
		/// </param>
		/// <param name="value">
		/// The value for the feature.  The interpretation of this
		/// value is feature-specific.
		/// </param>
		public abstract void setFeatureInt(int featureId, int value);

		/// <summary>Request that key events come to this activity.</summary>
		/// <remarks>
		/// Request that key events come to this activity. Use this if your
		/// activity has no views with focus, but the activity still wants
		/// a chance to process key events.
		/// </remarks>
		public abstract void takeKeyEvents(bool get);

		/// <summary>
		/// Used by custom windows, such as Dialog, to pass the key press event
		/// further down the view hierarchy.
		/// </summary>
		/// <remarks>
		/// Used by custom windows, such as Dialog, to pass the key press event
		/// further down the view hierarchy. Application developers should
		/// not need to implement or call this.
		/// </remarks>
		public abstract bool superDispatchKeyEvent(android.view.KeyEvent @event);

		/// <summary>
		/// Used by custom windows, such as Dialog, to pass the key shortcut press event
		/// further down the view hierarchy.
		/// </summary>
		/// <remarks>
		/// Used by custom windows, such as Dialog, to pass the key shortcut press event
		/// further down the view hierarchy. Application developers should
		/// not need to implement or call this.
		/// </remarks>
		public abstract bool superDispatchKeyShortcutEvent(android.view.KeyEvent @event);

		/// <summary>
		/// Used by custom windows, such as Dialog, to pass the touch screen event
		/// further down the view hierarchy.
		/// </summary>
		/// <remarks>
		/// Used by custom windows, such as Dialog, to pass the touch screen event
		/// further down the view hierarchy. Application developers should
		/// not need to implement or call this.
		/// </remarks>
		public abstract bool superDispatchTouchEvent(android.view.MotionEvent @event);

		/// <summary>
		/// Used by custom windows, such as Dialog, to pass the trackball event
		/// further down the view hierarchy.
		/// </summary>
		/// <remarks>
		/// Used by custom windows, such as Dialog, to pass the trackball event
		/// further down the view hierarchy. Application developers should
		/// not need to implement or call this.
		/// </remarks>
		public abstract bool superDispatchTrackballEvent(android.view.MotionEvent @event);

		/// <summary>
		/// Used by custom windows, such as Dialog, to pass the generic motion event
		/// further down the view hierarchy.
		/// </summary>
		/// <remarks>
		/// Used by custom windows, such as Dialog, to pass the generic motion event
		/// further down the view hierarchy. Application developers should
		/// not need to implement or call this.
		/// </remarks>
		public abstract bool superDispatchGenericMotionEvent(android.view.MotionEvent @event
			);

		/// <summary>
		/// Retrieve the top-level window decor view (containing the standard
		/// window frame/decorations and the client's content inside of that), which
		/// can be added as a window to the window manager.
		/// </summary>
		/// <remarks>
		/// Retrieve the top-level window decor view (containing the standard
		/// window frame/decorations and the client's content inside of that), which
		/// can be added as a window to the window manager.
		/// <p><em>Note that calling this function for the first time "locks in"
		/// various window characteristics as described in
		/// <see cref="setContentView(View, LayoutParams)">setContentView(View, LayoutParams)
		/// 	</see>
		/// .</em></p>
		/// </remarks>
		/// <returns>Returns the top-level window decor view.</returns>
		public abstract android.view.View getDecorView();

		/// <summary>
		/// Retrieve the current decor view, but only if it has already been created;
		/// otherwise returns null.
		/// </summary>
		/// <remarks>
		/// Retrieve the current decor view, but only if it has already been created;
		/// otherwise returns null.
		/// </remarks>
		/// <returns>Returns the top-level window decor or null.</returns>
		/// <seealso cref="getDecorView()">getDecorView()</seealso>
		public abstract android.view.View peekDecorView();

		public abstract android.os.Bundle saveHierarchyState();

		public abstract void restoreHierarchyState(android.os.Bundle savedInstanceState);

		protected internal abstract void onActive();

		/// <summary>Return the feature bits that are enabled.</summary>
		/// <remarks>
		/// Return the feature bits that are enabled.  This is the set of features
		/// that were given to requestFeature(), and are being handled by this
		/// Window itself or its container.  That is, it is the set of
		/// requested features that you can actually use.
		/// <p>To do: add a public version of this API that allows you to check for
		/// features by their feature ID.
		/// </remarks>
		/// <returns>int The feature bits.</returns>
		protected internal int getFeatures()
		{
			return mFeatures;
		}

		/// <summary>Query for the availability of a certain feature.</summary>
		/// <remarks>Query for the availability of a certain feature.</remarks>
		/// <param name="feature">The feature ID to check</param>
		/// <returns>true if the feature is enabled, false otherwise.</returns>
		public virtual bool hasFeature(int feature)
		{
			return (getFeatures() & (1 << feature)) != 0;
		}

		/// <summary>Return the feature bits that are being implemented by this Window.</summary>
		/// <remarks>
		/// Return the feature bits that are being implemented by this Window.
		/// This is the set of features that were given to requestFeature(), and are
		/// being handled by only this Window itself, not by its containers.
		/// </remarks>
		/// <returns>int The feature bits.</returns>
		protected internal int getLocalFeatures()
		{
			return mLocalFeatures;
		}

		/// <summary>Set the default format of window, as per the PixelFormat types.</summary>
		/// <remarks>
		/// Set the default format of window, as per the PixelFormat types.  This
		/// is the format that will be used unless the client specifies in explicit
		/// format with setFormat();
		/// </remarks>
		/// <param name="format">The new window format (see PixelFormat).</param>
		/// <seealso cref="setFormat(int)">setFormat(int)</seealso>
		/// <seealso cref="android.graphics.PixelFormat">android.graphics.PixelFormat</seealso>
		protected internal virtual void setDefaultWindowFormat(int format)
		{
			mDefaultWindowFormat = format;
			if (!mHaveWindowFormat)
			{
				android.view.WindowManagerClass.LayoutParams attrs = getAttributes();
				attrs.format = format;
				if (mCallback != null)
				{
					mCallback.onWindowAttributesChanged(attrs);
				}
			}
		}

		/// <hide></hide>
		protected internal virtual bool haveDimAmount()
		{
			return mHaveDimAmount;
		}

		public abstract void setChildDrawable(int featureId, android.graphics.drawable.Drawable
			 drawable);

		public abstract void setChildInt(int featureId, int value);

		/// <summary>Is a keypress one of the defined shortcut keys for this window.</summary>
		/// <remarks>Is a keypress one of the defined shortcut keys for this window.</remarks>
		/// <param name="keyCode">
		/// the key code from
		/// <see cref="KeyEvent">KeyEvent</see>
		/// to check.
		/// </param>
		/// <param name="event">
		/// the
		/// <see cref="KeyEvent">KeyEvent</see>
		/// to use to help check.
		/// </param>
		public abstract bool isShortcutKey(int keyCode, android.view.KeyEvent @event);

		/// <seealso cref="android.app.Activity.setVolumeControlStream(int)"></seealso>
		public abstract void setVolumeControlStream(int streamType);

		/// <seealso cref="android.app.Activity.getVolumeControlStream()">android.app.Activity.getVolumeControlStream()
		/// 	</seealso>
		public abstract int getVolumeControlStream();

		/// <summary>Set extra options that will influence the UI for this window.</summary>
		/// <remarks>Set extra options that will influence the UI for this window.</remarks>
		/// <param name="uiOptions">Flags specifying extra options for this window.</param>
		public virtual void setUiOptions(int uiOptions)
		{
		}

		/// <summary>Set extra options that will influence the UI for this window.</summary>
		/// <remarks>
		/// Set extra options that will influence the UI for this window.
		/// Only the bits filtered by mask will be modified.
		/// </remarks>
		/// <param name="uiOptions">Flags specifying extra options for this window.</param>
		/// <param name="mask">Flags specifying which options should be modified. Others will remain unchanged.
		/// 	</param>
		public virtual void setUiOptions(int uiOptions, int mask)
		{
		}
	}
}

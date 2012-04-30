using Sharpen;

namespace android.view
{
	/// <summary>This interface supplies all UI-specific behavior of the window manager.</summary>
	/// <remarks>
	/// This interface supplies all UI-specific behavior of the window manager.  An
	/// instance of it is created by the window manager when it starts up, and allows
	/// customization of window layering, special window types, key dispatching, and
	/// layout.
	/// <p>Because this provides deep interaction with the system window manager,
	/// specific methods on this interface can be called from a variety of contexts
	/// with various restrictions on what they can do.  These are encoded through
	/// a suffixes at the end of a method encoding the thread the method is called
	/// from and any locks that are held when it is being called; if no suffix
	/// is attached to a method, then it is not called with any locks and may be
	/// called from the main window manager thread or another thread calling into
	/// the window manager.
	/// <p>The current suffixes are:
	/// <dl>
	/// <dt> Ti <dd> Called from the input thread.  This is the thread that
	/// collects pending input events and dispatches them to the appropriate window.
	/// It may block waiting for events to be processed, so that the input stream is
	/// properly serialized.
	/// <dt> Tq <dd> Called from the low-level input queue thread.  This is the
	/// thread that reads events out of the raw input devices and places them
	/// into the global input queue that is read by the <var>Ti</var> thread.
	/// This thread should not block for a long period of time on anything but the
	/// key driver.
	/// <dt> Lw <dd> Called with the main window manager lock held.  Because the
	/// window manager is a very low-level system service, there are few other
	/// system services you can call with this lock held.  It is explicitly okay to
	/// make calls into the package manager and power manager; it is explicitly not
	/// okay to make calls into the activity manager or most other services.  Note that
	/// <see cref="android.content.Context.checkPermission(string, int, int)">android.content.Context.checkPermission(string, int, int)
	/// 	</see>
	/// and
	/// variations require calling into the activity manager.
	/// <dt> Li <dd> Called with the input thread lock held.  This lock can be
	/// acquired by the window manager while it holds the window lock, so this is
	/// even more restrictive than <var>Lw</var>.
	/// </dl>
	/// </remarks>
	/// <hide></hide>
	[Sharpen.Sharpened]
	public interface WindowManagerPolicy
	{
		// Policy flags.  These flags are also defined in frameworks/base/include/ui/Input.h.
		// NOTE: screen off reasons are in order of significance, with more
		// important ones lower than less important ones.
		/// <summary>Perform initialization of the policy.</summary>
		/// <remarks>Perform initialization of the policy.</remarks>
		/// <param name="context">The system context we are running in.</param>
		/// <param name="powerManager"></param>
		void init(android.content.Context context, android.view.IWindowManager windowManager
			, android.view.WindowManagerPolicyClass.WindowManagerFuncs windowManagerFuncs, android.os.LocalPowerManager
			 powerManager);

		/// <summary>
		/// Called by window manager once it has the initial, default native
		/// display dimensions.
		/// </summary>
		/// <remarks>
		/// Called by window manager once it has the initial, default native
		/// display dimensions.
		/// </remarks>
		void setInitialDisplaySize(int width, int height);

		/// <summary>Check permissions when adding a window.</summary>
		/// <remarks>Check permissions when adding a window.</remarks>
		/// <param name="attrs">The window's LayoutParams.</param>
		/// <returns>
		/// 
		/// <see cref="WindowManagerImpl.ADD_OKAY">WindowManagerImpl.ADD_OKAY</see>
		/// if the add can proceed;
		/// else an error code, usually
		/// <see cref="WindowManagerImpl.ADD_PERMISSION_DENIED">WindowManagerImpl.ADD_PERMISSION_DENIED
		/// 	</see>
		/// , to abort the add.
		/// </returns>
		int checkAddPermission(android.view.WindowManagerClass.LayoutParams attrs);

		/// <summary>Sanitize the layout parameters coming from a client.</summary>
		/// <remarks>
		/// Sanitize the layout parameters coming from a client.  Allows the policy
		/// to do things like ensure that windows of a specific type can't take
		/// input focus.
		/// </remarks>
		/// <param name="attrs">
		/// The window layout parameters to be modified.  These values
		/// are modified in-place.
		/// </param>
		void adjustWindowParamsLw(android.view.WindowManagerClass.LayoutParams attrs);

		/// <summary>
		/// After the window manager has computed the current configuration based
		/// on its knowledge of the display and input devices, it gives the policy
		/// a chance to adjust the information contained in it.
		/// </summary>
		/// <remarks>
		/// After the window manager has computed the current configuration based
		/// on its knowledge of the display and input devices, it gives the policy
		/// a chance to adjust the information contained in it.  If you want to
		/// leave it as-is, simply do nothing.
		/// <p>This method may be called by any thread in the window manager, but
		/// no internal locks in the window manager will be held.
		/// </remarks>
		/// <param name="config">
		/// The Configuration being computed, for you to change as
		/// desired.
		/// </param>
		void adjustConfigurationLw(android.content.res.Configuration config);

		/// <summary>Assign a window type to a layer.</summary>
		/// <remarks>
		/// Assign a window type to a layer.  Allows you to control how different
		/// kinds of windows are ordered on-screen.
		/// </remarks>
		/// <param name="type">The type of window being assigned.</param>
		/// <returns>
		/// int An arbitrary integer used to order windows, with lower
		/// numbers below higher ones.
		/// </returns>
		int windowTypeToLayerLw(int type);

		/// <summary>
		/// Return how to Z-order sub-windows in relation to the window they are
		/// attached to.
		/// </summary>
		/// <remarks>
		/// Return how to Z-order sub-windows in relation to the window they are
		/// attached to.  Return positive to have them ordered in front, negative for
		/// behind.
		/// </remarks>
		/// <param name="type">The sub-window type code.</param>
		/// <returns>
		/// int Layer in relation to the attached window, where positive is
		/// above and negative is below.
		/// </returns>
		int subWindowTypeToLayerLw(int type);

		/// <summary>
		/// Get the highest layer (actually one more than) that the wallpaper is
		/// allowed to be in.
		/// </summary>
		/// <remarks>
		/// Get the highest layer (actually one more than) that the wallpaper is
		/// allowed to be in.
		/// </remarks>
		int getMaxWallpaperLayer();

		/// <summary>Return true if the policy allows the status bar to hide.</summary>
		/// <remarks>
		/// Return true if the policy allows the status bar to hide.  Otherwise,
		/// it is a tablet-style system bar.
		/// </remarks>
		bool canStatusBarHide();

		/// <summary>
		/// Return the display width available after excluding any screen
		/// decorations that can never be removed.
		/// </summary>
		/// <remarks>
		/// Return the display width available after excluding any screen
		/// decorations that can never be removed.  That is, system bar or
		/// button bar.
		/// </remarks>
		int getNonDecorDisplayWidth(int fullWidth, int fullHeight, int rotation);

		/// <summary>
		/// Return the display height available after excluding any screen
		/// decorations that can never be removed.
		/// </summary>
		/// <remarks>
		/// Return the display height available after excluding any screen
		/// decorations that can never be removed.  That is, system bar or
		/// button bar.
		/// </remarks>
		int getNonDecorDisplayHeight(int fullWidth, int fullHeight, int rotation);

		/// <summary>
		/// Return the available screen width that we should report for the
		/// configuration.
		/// </summary>
		/// <remarks>
		/// Return the available screen width that we should report for the
		/// configuration.  This must be no larger than
		/// <see cref="getNonDecorDisplayWidth(int, int, int)">getNonDecorDisplayWidth(int, int, int)
		/// 	</see>
		/// ; it may be smaller than
		/// that to account for more transient decoration like a status bar.
		/// </remarks>
		int getConfigDisplayWidth(int fullWidth, int fullHeight, int rotation);

		/// <summary>
		/// Return the available screen height that we should report for the
		/// configuration.
		/// </summary>
		/// <remarks>
		/// Return the available screen height that we should report for the
		/// configuration.  This must be no larger than
		/// <see cref="getNonDecorDisplayHeight(int, int, int)">getNonDecorDisplayHeight(int, int, int)
		/// 	</see>
		/// ; it may be smaller than
		/// that to account for more transient decoration like a status bar.
		/// </remarks>
		int getConfigDisplayHeight(int fullWidth, int fullHeight, int rotation);

		/// <summary>
		/// Return whether the given window should forcibly hide everything
		/// behind it.
		/// </summary>
		/// <remarks>
		/// Return whether the given window should forcibly hide everything
		/// behind it.  Typically returns true for the keyguard.
		/// </remarks>
		bool doesForceHide(android.view.WindowManagerPolicyClass.WindowState win, android.view.WindowManagerClass
			.LayoutParams attrs);

		/// <summary>
		/// Determine if a window that is behind one that is force hiding
		/// (as determined by
		/// <see cref="doesForceHide(WindowState, LayoutParams)">doesForceHide(WindowState, LayoutParams)
		/// 	</see>
		/// ) should actually be hidden.
		/// For example, typically returns false for the status bar.  Be careful
		/// to return false for any window that you may hide yourself, since this
		/// will conflict with what you set.
		/// </summary>
		bool canBeForceHidden(android.view.WindowManagerPolicyClass.WindowState win, android.view.WindowManagerClass
			.LayoutParams attrs);

		/// <summary>
		/// Called when the system would like to show a UI to indicate that an
		/// application is starting.
		/// </summary>
		/// <remarks>
		/// Called when the system would like to show a UI to indicate that an
		/// application is starting.  You can use this to add a
		/// APPLICATION_STARTING_TYPE window with the given appToken to the window
		/// manager (using the normal window manager APIs) that will be shown until
		/// the application displays its own window.  This is called without the
		/// window manager locked so that you can call back into it.
		/// </remarks>
		/// <param name="appToken">Token of the application being started.</param>
		/// <param name="packageName">The name of the application package being started.</param>
		/// <param name="theme">Resource defining the application's overall visual theme.</param>
		/// <param name="nonLocalizedLabel">
		/// The default title label of the application if
		/// no data is found in the resource.
		/// </param>
		/// <param name="labelRes">The resource ID the application would like to use as its name.
		/// 	</param>
		/// <param name="icon">The resource ID the application would like to use as its icon.
		/// 	</param>
		/// <param name="windowFlags">Window layout flags.</param>
		/// <returns>
		/// Optionally you can return the View that was used to create the
		/// window, for easy removal in removeStartingWindow.
		/// </returns>
		/// <seealso cref="removeStartingWindow(android.os.IBinder, View)">removeStartingWindow(android.os.IBinder, View)
		/// 	</seealso>
		android.view.View addStartingWindow(android.os.IBinder appToken, string packageName
			, int theme, android.content.res.CompatibilityInfo compatInfo, java.lang.CharSequence
			 nonLocalizedLabel, int labelRes, int icon, int windowFlags);

		/// <summary>
		/// Called when the first window of an application has been displayed, while
		/// <see cref="addStartingWindow(android.os.IBinder, string, int, android.content.res.CompatibilityInfo, java.lang.CharSequence, int, int, int)
		/// 	">addStartingWindow(android.os.IBinder, string, int, android.content.res.CompatibilityInfo, java.lang.CharSequence, int, int, int)
		/// 	</see>
		/// has created a temporary initial window for
		/// that application.  You should at this point remove the window from the
		/// window manager.  This is called without the window manager locked so
		/// that you can call back into it.
		/// <p>Note: due to the nature of these functions not being called with the
		/// window manager locked, you must be prepared for this function to be
		/// called multiple times and/or an initial time with a null View window
		/// even if you previously returned one.
		/// </summary>
		/// <param name="appToken">Token of the application that has started.</param>
		/// <param name="window">Window View that was returned by createStartingWindow.</param>
		/// <seealso cref="addStartingWindow(android.os.IBinder, string, int, android.content.res.CompatibilityInfo, java.lang.CharSequence, int, int, int)
		/// 	">addStartingWindow(android.os.IBinder, string, int, android.content.res.CompatibilityInfo, java.lang.CharSequence, int, int, int)
		/// 	</seealso>
		void removeStartingWindow(android.os.IBinder appToken, android.view.View window);

		/// <summary>Prepare for a window being added to the window manager.</summary>
		/// <remarks>
		/// Prepare for a window being added to the window manager.  You can throw an
		/// exception here to prevent the window being added, or do whatever setup
		/// you need to keep track of the window.
		/// </remarks>
		/// <param name="win">The window being added.</param>
		/// <param name="attrs">The window's LayoutParams.</param>
		/// <returns>
		/// 
		/// <see cref="WindowManagerImpl.ADD_OKAY">WindowManagerImpl.ADD_OKAY</see>
		/// if the add can proceed, else an
		/// error code to abort the add.
		/// </returns>
		int prepareAddWindowLw(android.view.WindowManagerPolicyClass.WindowState win, android.view.WindowManagerClass
			.LayoutParams attrs);

		/// <summary>Called when a window is being removed from a window manager.</summary>
		/// <remarks>
		/// Called when a window is being removed from a window manager.  Must not
		/// throw an exception -- clean up as much as possible.
		/// </remarks>
		/// <param name="win">The window being removed.</param>
		void removeWindowLw(android.view.WindowManagerPolicyClass.WindowState win);

		/// <summary>Control the animation to run when a window's state changes.</summary>
		/// <remarks>
		/// Control the animation to run when a window's state changes.  Return a
		/// non-0 number to force the animation to a specific resource ID, or 0
		/// to use the default animation.
		/// </remarks>
		/// <param name="win">The window that is changing.</param>
		/// <param name="transit">
		/// What is happening to the window:
		/// <see cref="android.view.WindowManagerPolicyClass.TRANSIT_ENTER">android.view.WindowManagerPolicyClass.TRANSIT_ENTER
		/// 	</see>
		/// ,
		/// <see cref="android.view.WindowManagerPolicyClass.TRANSIT_EXIT">android.view.WindowManagerPolicyClass.TRANSIT_EXIT
		/// 	</see>
		/// ,
		/// <see cref="android.view.WindowManagerPolicyClass.TRANSIT_SHOW">android.view.WindowManagerPolicyClass.TRANSIT_SHOW
		/// 	</see>
		/// , or
		/// <see cref="android.view.WindowManagerPolicyClass.TRANSIT_HIDE">android.view.WindowManagerPolicyClass.TRANSIT_HIDE
		/// 	</see>
		/// .
		/// </param>
		/// <returns>Resource ID of the actual animation to use, or 0 for none.</returns>
		int selectAnimationLw(android.view.WindowManagerPolicyClass.WindowState win, int 
			transit);

		/// <summary>Create and return an animation to re-display a force hidden window.</summary>
		/// <remarks>Create and return an animation to re-display a force hidden window.</remarks>
		android.view.animation.Animation createForceHideEnterAnimation();

		/// <summary>Called from the input reader thread before a key is enqueued.</summary>
		/// <remarks>
		/// Called from the input reader thread before a key is enqueued.
		/// <p>There are some actions that need to be handled here because they
		/// affect the power state of the device, for example, the power keys.
		/// Generally, it's best to keep as little as possible in the queue thread
		/// because it's the most fragile.
		/// </remarks>
		/// <param name="event">The key event.</param>
		/// <param name="policyFlags">The policy flags associated with the key.</param>
		/// <param name="isScreenOn">True if the screen is already on</param>
		/// <returns>
		/// The bitwise or of the
		/// <see cref="android.view.WindowManagerPolicyClass.ACTION_PASS_TO_USER">android.view.WindowManagerPolicyClass.ACTION_PASS_TO_USER
		/// 	</see>
		/// ,
		/// <see cref="android.view.WindowManagerPolicyClass.ACTION_POKE_USER_ACTIVITY">android.view.WindowManagerPolicyClass.ACTION_POKE_USER_ACTIVITY
		/// 	</see>
		/// and
		/// <see cref="android.view.WindowManagerPolicyClass.ACTION_GO_TO_SLEEP">android.view.WindowManagerPolicyClass.ACTION_GO_TO_SLEEP
		/// 	</see>
		/// flags.
		/// </returns>
		int interceptKeyBeforeQueueing(android.view.KeyEvent @event, int policyFlags, bool
			 isScreenOn);

		/// <summary>Called from the input reader thread before a motion is enqueued when the screen is off.
		/// 	</summary>
		/// <remarks>
		/// Called from the input reader thread before a motion is enqueued when the screen is off.
		/// <p>There are some actions that need to be handled here because they
		/// affect the power state of the device, for example, waking on motions.
		/// Generally, it's best to keep as little as possible in the queue thread
		/// because it's the most fragile.
		/// </remarks>
		/// <param name="policyFlags">The policy flags associated with the motion.</param>
		/// <returns>
		/// The bitwise or of the
		/// <see cref="android.view.WindowManagerPolicyClass.ACTION_PASS_TO_USER">android.view.WindowManagerPolicyClass.ACTION_PASS_TO_USER
		/// 	</see>
		/// ,
		/// <see cref="android.view.WindowManagerPolicyClass.ACTION_POKE_USER_ACTIVITY">android.view.WindowManagerPolicyClass.ACTION_POKE_USER_ACTIVITY
		/// 	</see>
		/// and
		/// <see cref="android.view.WindowManagerPolicyClass.ACTION_GO_TO_SLEEP">android.view.WindowManagerPolicyClass.ACTION_GO_TO_SLEEP
		/// 	</see>
		/// flags.
		/// </returns>
		int interceptMotionBeforeQueueingWhenScreenOff(int policyFlags);

		/// <summary>Called from the input dispatcher thread before a key is dispatched to a window.
		/// 	</summary>
		/// <remarks>
		/// Called from the input dispatcher thread before a key is dispatched to a window.
		/// <p>Allows you to define
		/// behavior for keys that can not be overridden by applications.
		/// This method is called from the input thread, with no locks held.
		/// </remarks>
		/// <param name="win">
		/// The window that currently has focus.  This is where the key
		/// event will normally go.
		/// </param>
		/// <param name="event">The key event.</param>
		/// <param name="policyFlags">The policy flags associated with the key.</param>
		/// <returns>
		/// 0 if the key should be dispatched immediately, -1 if the key should
		/// not be dispatched ever, or a positive value indicating the number of
		/// milliseconds by which the key dispatch should be delayed before trying
		/// again.
		/// </returns>
		long interceptKeyBeforeDispatching(android.view.WindowManagerPolicyClass.WindowState
			 win, android.view.KeyEvent @event, int policyFlags);

		/// <summary>
		/// Called from the input dispatcher thread when an application did not handle
		/// a key that was dispatched to it.
		/// </summary>
		/// <remarks>
		/// Called from the input dispatcher thread when an application did not handle
		/// a key that was dispatched to it.
		/// <p>Allows you to define default global behavior for keys that were not handled
		/// by applications.  This method is called from the input thread, with no locks held.
		/// </remarks>
		/// <param name="win">
		/// The window that currently has focus.  This is where the key
		/// event will normally go.
		/// </param>
		/// <param name="event">The key event.</param>
		/// <param name="policyFlags">The policy flags associated with the key.</param>
		/// <returns>
		/// Returns an alternate key event to redispatch as a fallback, or null to give up.
		/// The caller is responsible for recycling the key event.
		/// </returns>
		android.view.KeyEvent dispatchUnhandledKey(android.view.WindowManagerPolicyClass.
			WindowState win, android.view.KeyEvent @event, int policyFlags);

		/// <summary>Called when layout of the windows is about to start.</summary>
		/// <remarks>Called when layout of the windows is about to start.</remarks>
		/// <param name="displayWidth">The current full width of the screen.</param>
		/// <param name="displayHeight">The current full height of the screen.</param>
		/// <param name="displayRotation">
		/// The current rotation being applied to the base
		/// window.
		/// </param>
		void beginLayoutLw(int displayWidth, int displayHeight, int displayRotation);

		/// <summary>
		/// Called for each window attached to the window manager as layout is
		/// proceeding.
		/// </summary>
		/// <remarks>
		/// Called for each window attached to the window manager as layout is
		/// proceeding.  The implementation of this function must take care of
		/// setting the window's frame, either here or in finishLayout().
		/// </remarks>
		/// <param name="win">The window being positioned.</param>
		/// <param name="attrs">The LayoutParams of the window.</param>
		/// <param name="attached">
		/// For sub-windows, the window it is attached to; this
		/// window will already have had layoutWindow() called on it
		/// so you can use its Rect.  Otherwise null.
		/// </param>
		void layoutWindowLw(android.view.WindowManagerPolicyClass.WindowState win, android.view.WindowManagerClass
			.LayoutParams attrs, android.view.WindowManagerPolicyClass.WindowState attached);

		/// <summary>Return the insets for the areas covered by system windows.</summary>
		/// <remarks>
		/// Return the insets for the areas covered by system windows. These values
		/// are computed on the most recent layout, so they are not guaranteed to
		/// be correct.
		/// </remarks>
		/// <param name="attrs">The LayoutParams of the window.</param>
		/// <param name="contentInset">The areas covered by system windows, expressed as positive insets
		/// 	</param>
		void getContentInsetHintLw(android.view.WindowManagerClass.LayoutParams attrs, android.graphics.Rect
			 contentInset);

		/// <summary>Called when layout of the windows is finished.</summary>
		/// <remarks>
		/// Called when layout of the windows is finished.  After this function has
		/// returned, all windows given to layoutWindow() <em>must</em> have had a
		/// frame assigned.
		/// </remarks>
		/// <returns>
		/// Return any bit set of
		/// <see cref="android.view.WindowManagerPolicyClass.FINISH_LAYOUT_REDO_LAYOUT">android.view.WindowManagerPolicyClass.FINISH_LAYOUT_REDO_LAYOUT
		/// 	</see>
		/// ,
		/// <see cref="android.view.WindowManagerPolicyClass.FINISH_LAYOUT_REDO_CONFIG">android.view.WindowManagerPolicyClass.FINISH_LAYOUT_REDO_CONFIG
		/// 	</see>
		/// ,
		/// <see cref="android.view.WindowManagerPolicyClass.FINISH_LAYOUT_REDO_WALLPAPER">android.view.WindowManagerPolicyClass.FINISH_LAYOUT_REDO_WALLPAPER
		/// 	</see>
		/// ,
		/// or
		/// <see cref="android.view.WindowManagerPolicyClass.FINISH_LAYOUT_REDO_ANIM">android.view.WindowManagerPolicyClass.FINISH_LAYOUT_REDO_ANIM
		/// 	</see>
		/// .
		/// </returns>
		int finishLayoutLw();

		/// <summary>Called when animation of the windows is about to start.</summary>
		/// <remarks>Called when animation of the windows is about to start.</remarks>
		/// <param name="displayWidth">The current full width of the screen.</param>
		/// <param name="displayHeight">The current full height of the screen.</param>
		void beginAnimationLw(int displayWidth, int displayHeight);

		/// <summary>Called each time a window is animating.</summary>
		/// <remarks>Called each time a window is animating.</remarks>
		/// <param name="win">The window being positioned.</param>
		/// <param name="attrs">The LayoutParams of the window.</param>
		void animatingWindowLw(android.view.WindowManagerPolicyClass.WindowState win, android.view.WindowManagerClass
			.LayoutParams attrs);

		/// <summary>Called when animation of the windows is finished.</summary>
		/// <remarks>
		/// Called when animation of the windows is finished.  If in this function you do
		/// something that may have modified the animation state of another window,
		/// be sure to return true in order to perform another animation frame.
		/// </remarks>
		/// <returns>
		/// Return any bit set of
		/// <see cref="android.view.WindowManagerPolicyClass.FINISH_LAYOUT_REDO_LAYOUT">android.view.WindowManagerPolicyClass.FINISH_LAYOUT_REDO_LAYOUT
		/// 	</see>
		/// ,
		/// <see cref="android.view.WindowManagerPolicyClass.FINISH_LAYOUT_REDO_CONFIG">android.view.WindowManagerPolicyClass.FINISH_LAYOUT_REDO_CONFIG
		/// 	</see>
		/// ,
		/// <see cref="android.view.WindowManagerPolicyClass.FINISH_LAYOUT_REDO_WALLPAPER">android.view.WindowManagerPolicyClass.FINISH_LAYOUT_REDO_WALLPAPER
		/// 	</see>
		/// ,
		/// or
		/// <see cref="android.view.WindowManagerPolicyClass.FINISH_LAYOUT_REDO_ANIM">android.view.WindowManagerPolicyClass.FINISH_LAYOUT_REDO_ANIM
		/// 	</see>
		/// .
		/// </returns>
		int finishAnimationLw();

		/// <summary>
		/// Return true if it is okay to perform animations for an app transition
		/// that is about to occur.
		/// </summary>
		/// <remarks>
		/// Return true if it is okay to perform animations for an app transition
		/// that is about to occur.  You may return false for this if, for example,
		/// the lock screen is currently displayed so the switch should happen
		/// immediately.
		/// </remarks>
		bool allowAppAnimationsLw();

		/// <summary>A new window has been focused.</summary>
		/// <remarks>A new window has been focused.</remarks>
		int focusChangedLw(android.view.WindowManagerPolicyClass.WindowState lastFocus, android.view.WindowManagerPolicyClass
			.WindowState newFocus);

		/// <summary>Called after the screen turns off.</summary>
		/// <remarks>Called after the screen turns off.</remarks>
		/// <param name="why">
		/// 
		/// <see cref="android.view.WindowManagerPolicyClass.OFF_BECAUSE_OF_USER">android.view.WindowManagerPolicyClass.OFF_BECAUSE_OF_USER
		/// 	</see>
		/// or
		/// <see cref="android.view.WindowManagerPolicyClass.OFF_BECAUSE_OF_TIMEOUT">android.view.WindowManagerPolicyClass.OFF_BECAUSE_OF_TIMEOUT
		/// 	</see>
		/// .
		/// </param>
		void screenTurnedOff(int why);

		/// <summary>Called when the power manager would like to turn the screen on.</summary>
		/// <remarks>
		/// Called when the power manager would like to turn the screen on.
		/// Must call back on the listener to tell it when the higher-level system
		/// is ready for the screen to go on (i.e. the lock screen is shown).
		/// </remarks>
		void screenTurningOn(android.view.WindowManagerPolicyClass.ScreenOnListener screenOnListener
			);

		/// <summary>Return whether the screen is about to turn on or is currently on.</summary>
		/// <remarks>Return whether the screen is about to turn on or is currently on.</remarks>
		bool isScreenOnEarly();

		/// <summary>Return whether the screen is fully turned on.</summary>
		/// <remarks>Return whether the screen is fully turned on.</remarks>
		bool isScreenOnFully();

		/// <summary>Tell the policy that the lid switch has changed state.</summary>
		/// <remarks>Tell the policy that the lid switch has changed state.</remarks>
		/// <param name="whenNanos">The time when the change occurred in uptime nanoseconds.</param>
		/// <param name="lidOpen">True if the lid is now open.</param>
		void notifyLidSwitchChanged(long whenNanos, bool lidOpen);

		/// <summary>Tell the policy if anyone is requesting that keyguard not come on.</summary>
		/// <remarks>Tell the policy if anyone is requesting that keyguard not come on.</remarks>
		/// <param name="enabled">
		/// Whether keyguard can be on or not.  does not actually
		/// turn it on, unless it was previously disabled with this function.
		/// </param>
		/// <seealso cref="android.app.KeyguardManager.KeyguardLock.disableKeyguard()">android.app.KeyguardManager.KeyguardLock.disableKeyguard()
		/// 	</seealso>
		/// <seealso cref="android.app.KeyguardManager.KeyguardLock.reenableKeyguard()">android.app.KeyguardManager.KeyguardLock.reenableKeyguard()
		/// 	</seealso>
		void enableKeyguard(bool enabled);

		/// <summary>
		/// Tell the policy if anyone is requesting the keyguard to exit securely
		/// (this would be called after the keyguard was disabled)
		/// </summary>
		/// <param name="callback">Callback to send the result back.</param>
		/// <seealso cref="android.app.KeyguardManager.exitKeyguardSecurely(android.app.KeyguardManager.OnKeyguardExitResult)
		/// 	">android.app.KeyguardManager.exitKeyguardSecurely(android.app.KeyguardManager.OnKeyguardExitResult)
		/// 	</seealso>
		void exitKeyguardSecurely(android.view.WindowManagerPolicyClass.OnKeyguardExitResult
			 callback);

		/// <summary>
		/// isKeyguardLocked
		/// Return whether the keyguard is currently locked.
		/// </summary>
		/// <remarks>
		/// isKeyguardLocked
		/// Return whether the keyguard is currently locked.
		/// </remarks>
		/// <returns>true if in keyguard is locked.</returns>
		bool isKeyguardLocked();

		/// <summary>
		/// isKeyguardSecure
		/// Return whether the keyguard requires a password to unlock.
		/// </summary>
		/// <remarks>
		/// isKeyguardSecure
		/// Return whether the keyguard requires a password to unlock.
		/// </remarks>
		/// <returns>true if in keyguard is secure.</returns>
		bool isKeyguardSecure();

		/// <summary>
		/// inKeyguardRestrictedKeyInputMode
		/// if keyguard screen is showing or in restricted key input mode (i.e.
		/// </summary>
		/// <remarks>
		/// inKeyguardRestrictedKeyInputMode
		/// if keyguard screen is showing or in restricted key input mode (i.e. in
		/// keyguard password emergency screen). When in such mode, certain keys,
		/// such as the Home key and the right soft keys, don't work.
		/// </remarks>
		/// <returns>true if in keyguard restricted input mode.</returns>
		bool inKeyguardRestrictedKeyInputMode();

		/// <summary>Ask the policy to dismiss the keyguard, if it is currently shown.</summary>
		/// <remarks>Ask the policy to dismiss the keyguard, if it is currently shown.</remarks>
		void dismissKeyguardLw();

		/// <summary>
		/// Given an orientation constant, returns the appropriate surface rotation,
		/// taking into account sensors, docking mode, rotation lock, and other factors.
		/// </summary>
		/// <remarks>
		/// Given an orientation constant, returns the appropriate surface rotation,
		/// taking into account sensors, docking mode, rotation lock, and other factors.
		/// </remarks>
		/// <param name="orientation">
		/// An orientation constant, such as
		/// <see cref="android.content.pm.ActivityInfo.SCREEN_ORIENTATION_LANDSCAPE">android.content.pm.ActivityInfo.SCREEN_ORIENTATION_LANDSCAPE
		/// 	</see>
		/// .
		/// </param>
		/// <param name="lastRotation">The most recently used rotation.</param>
		/// <returns>The surface rotation to use.</returns>
		int rotationForOrientationLw(int orientation, int lastRotation);

		/// <summary>
		/// Given an orientation constant and a rotation, returns true if the rotation
		/// has compatible metrics to the requested orientation.
		/// </summary>
		/// <remarks>
		/// Given an orientation constant and a rotation, returns true if the rotation
		/// has compatible metrics to the requested orientation.  For example, if
		/// the application requested landscape and got seascape, then the rotation
		/// has compatible metrics; if the application requested portrait and got landscape,
		/// then the rotation has incompatible metrics; if the application did not specify
		/// a preference, then anything goes.
		/// </remarks>
		/// <param name="orientation">
		/// An orientation constant, such as
		/// <see cref="android.content.pm.ActivityInfo.SCREEN_ORIENTATION_LANDSCAPE">android.content.pm.ActivityInfo.SCREEN_ORIENTATION_LANDSCAPE
		/// 	</see>
		/// .
		/// </param>
		/// <param name="rotation">The rotation to check.</param>
		/// <returns>True if the rotation is compatible with the requested orientation.</returns>
		bool rotationHasCompatibleMetricsLw(int orientation, int rotation);

		/// <summary>Called by the window manager when the rotation changes.</summary>
		/// <remarks>Called by the window manager when the rotation changes.</remarks>
		/// <param name="rotation">The new rotation.</param>
		void setRotationLw(int rotation);

		/// <summary>
		/// Called when the system is mostly done booting to determine whether
		/// the system should go into safe mode.
		/// </summary>
		/// <remarks>
		/// Called when the system is mostly done booting to determine whether
		/// the system should go into safe mode.
		/// </remarks>
		bool detectSafeMode();

		/// <summary>Called when the system is mostly done booting.</summary>
		/// <remarks>Called when the system is mostly done booting.</remarks>
		void systemReady();

		/// <summary>
		/// Called when the system is done booting to the point where the
		/// user can start interacting with it.
		/// </summary>
		/// <remarks>
		/// Called when the system is done booting to the point where the
		/// user can start interacting with it.
		/// </remarks>
		void systemBooted();

		/// <summary>Show boot time message to the user.</summary>
		/// <remarks>Show boot time message to the user.</remarks>
		void showBootMessage(java.lang.CharSequence msg, bool always);

		/// <summary>Hide the UI for showing boot messages, never to be displayed again.</summary>
		/// <remarks>Hide the UI for showing boot messages, never to be displayed again.</remarks>
		void hideBootMessages();

		/// <summary>Called when userActivity is signalled in the power manager.</summary>
		/// <remarks>
		/// Called when userActivity is signalled in the power manager.
		/// This is safe to call from any thread, with any window manager locks held or not.
		/// </remarks>
		void userActivity();

		/// <summary>
		/// Called when we have finished booting and can now display the home
		/// screen to the user.
		/// </summary>
		/// <remarks>
		/// Called when we have finished booting and can now display the home
		/// screen to the user.  This wilWl happen after systemReady(), and at
		/// this point the display is active.
		/// </remarks>
		void enableScreenAfterBoot();

		void setCurrentOrientationLw(int newOrientation);

		/// <summary>Call from application to perform haptic feedback on its window.</summary>
		/// <remarks>Call from application to perform haptic feedback on its window.</remarks>
		bool performHapticFeedbackLw(android.view.WindowManagerPolicyClass.WindowState win
			, int effectId, bool always);

		/// <summary>
		/// Called when we have started keeping the screen on because a window
		/// requesting this has become visible.
		/// </summary>
		/// <remarks>
		/// Called when we have started keeping the screen on because a window
		/// requesting this has become visible.
		/// </remarks>
		void screenOnStartedLw();

		/// <summary>
		/// Called when we have stopped keeping the screen on because the last window
		/// requesting this is no longer visible.
		/// </summary>
		/// <remarks>
		/// Called when we have stopped keeping the screen on because the last window
		/// requesting this is no longer visible.
		/// </remarks>
		void screenOnStoppedLw();

		/// <summary>Return false to disable key repeat events from being generated.</summary>
		/// <remarks>Return false to disable key repeat events from being generated.</remarks>
		bool allowKeyRepeat();

		/// <summary>Inform the policy that the user has chosen a preferred orientation ("rotation lock").
		/// 	</summary>
		/// <remarks>Inform the policy that the user has chosen a preferred orientation ("rotation lock").
		/// 	</remarks>
		/// <param name="mode">
		/// One of
		/// <see cref="android.view.WindowManagerPolicyClass.USER_ROTATION_LOCKED">android.view.WindowManagerPolicyClass.USER_ROTATION_LOCKED
		/// 	</see>
		/// or
		/// <see>* WindowManagerPolicy#USER_ROTATION_FREE</see>
		/// .
		/// </param>
		/// <param name="rotation">
		/// One of
		/// <see cref="Surface.ROTATION_0">Surface.ROTATION_0</see>
		/// ,
		/// <see cref="Surface.ROTATION_90">Surface.ROTATION_90</see>
		/// ,
		/// <see cref="Surface.ROTATION_180">Surface.ROTATION_180</see>
		/// ,
		/// <see cref="Surface.ROTATION_270">Surface.ROTATION_270</see>
		/// .
		/// </param>
		void setUserRotationMode(int mode, int rotation);

		/// <summary>
		/// Called when a new system UI visibility is being reported, allowing
		/// the policy to adjust what is actually reported.
		/// </summary>
		/// <remarks>
		/// Called when a new system UI visibility is being reported, allowing
		/// the policy to adjust what is actually reported.
		/// </remarks>
		/// <param name="visibility">The raw visiblity reported by the status bar.</param>
		/// <returns>The new desired visibility.</returns>
		int adjustSystemUiVisibilityLw(int visibility);

		/// <summary>Specifies whether there is an on-screen navigation bar separate from the status bar.
		/// 	</summary>
		/// <remarks>Specifies whether there is an on-screen navigation bar separate from the status bar.
		/// 	</remarks>
		bool hasNavigationBar();

		/// <summary>Print the WindowManagerPolicy's state into the given stream.</summary>
		/// <remarks>Print the WindowManagerPolicy's state into the given stream.</remarks>
		/// <param name="prefix">Text to print at the front of each line.</param>
		/// <param name="fd">The raw file descriptor that the dump is being sent to.</param>
		/// <param name="writer">
		/// The PrintWriter to which you should dump your state.  This will be
		/// closed for you after you return.
		/// </param>
		/// <param name="args">additional arguments to the dump request.</param>
		void dump(string prefix, java.io.FileDescriptor fd, java.io.PrintWriter writer, string
			[] args);
	}

	/// <summary>This interface supplies all UI-specific behavior of the window manager.</summary>
	/// <remarks>
	/// This interface supplies all UI-specific behavior of the window manager.  An
	/// instance of it is created by the window manager when it starts up, and allows
	/// customization of window layering, special window types, key dispatching, and
	/// layout.
	/// <p>Because this provides deep interaction with the system window manager,
	/// specific methods on this interface can be called from a variety of contexts
	/// with various restrictions on what they can do.  These are encoded through
	/// a suffixes at the end of a method encoding the thread the method is called
	/// from and any locks that are held when it is being called; if no suffix
	/// is attached to a method, then it is not called with any locks and may be
	/// called from the main window manager thread or another thread calling into
	/// the window manager.
	/// <p>The current suffixes are:
	/// <dl>
	/// <dt> Ti <dd> Called from the input thread.  This is the thread that
	/// collects pending input events and dispatches them to the appropriate window.
	/// It may block waiting for events to be processed, so that the input stream is
	/// properly serialized.
	/// <dt> Tq <dd> Called from the low-level input queue thread.  This is the
	/// thread that reads events out of the raw input devices and places them
	/// into the global input queue that is read by the <var>Ti</var> thread.
	/// This thread should not block for a long period of time on anything but the
	/// key driver.
	/// <dt> Lw <dd> Called with the main window manager lock held.  Because the
	/// window manager is a very low-level system service, there are few other
	/// system services you can call with this lock held.  It is explicitly okay to
	/// make calls into the package manager and power manager; it is explicitly not
	/// okay to make calls into the activity manager or most other services.  Note that
	/// <see cref="android.content.Context.checkPermission(string, int, int)">android.content.Context.checkPermission(string, int, int)
	/// 	</see>
	/// and
	/// variations require calling into the activity manager.
	/// <dt> Li <dd> Called with the input thread lock held.  This lock can be
	/// acquired by the window manager while it holds the window lock, so this is
	/// even more restrictive than <var>Lw</var>.
	/// </dl>
	/// </remarks>
	/// <hide></hide>
	[Sharpen.Sharpened]
	public static class WindowManagerPolicyClass
	{
		public const int FLAG_WAKE = unchecked((int)(0x00000001));

		public const int FLAG_WAKE_DROPPED = unchecked((int)(0x00000002));

		public const int FLAG_SHIFT = unchecked((int)(0x00000004));

		public const int FLAG_CAPS_LOCK = unchecked((int)(0x00000008));

		public const int FLAG_ALT = unchecked((int)(0x00000010));

		public const int FLAG_ALT_GR = unchecked((int)(0x00000020));

		public const int FLAG_MENU = unchecked((int)(0x00000040));

		public const int FLAG_LAUNCHER = unchecked((int)(0x00000080));

		public const int FLAG_VIRTUAL = unchecked((int)(0x00000100));

		public const int FLAG_INJECTED = unchecked((int)(0x01000000));

		public const int FLAG_TRUSTED = unchecked((int)(0x02000000));

		public const int FLAG_FILTERED = unchecked((int)(0x04000000));

		public const int FLAG_DISABLE_KEY_REPEAT = unchecked((int)(0x08000000));

		public const int FLAG_WOKE_HERE = unchecked((int)(0x10000000));

		public const int FLAG_BRIGHT_HERE = unchecked((int)(0x20000000));

		public const int FLAG_PASS_TO_USER = unchecked((int)(0x40000000));

		public const bool WATCH_POINTER = false;

		/// <summary>Sticky broadcast of the current HDMI plugged state.</summary>
		/// <remarks>Sticky broadcast of the current HDMI plugged state.</remarks>
		public const string ACTION_HDMI_PLUGGED = "android.intent.action.HDMI_PLUGGED";

		/// <summary>
		/// Extra in
		/// <see cref="android.view.WindowManagerPolicyClass.ACTION_HDMI_PLUGGED">android.view.WindowManagerPolicyClass.ACTION_HDMI_PLUGGED
		/// 	</see>
		/// indicating the state: true if
		/// plugged in to HDMI, false if not.
		/// </summary>
		public const string EXTRA_HDMI_PLUGGED_STATE = "state";

		/// <summary>Pass this event to the user / app.</summary>
		/// <remarks>
		/// Pass this event to the user / app.  To be returned from
		/// <see cref="interceptKeyBeforeQueueing(KeyEvent, int, bool)">interceptKeyBeforeQueueing(KeyEvent, int, bool)
		/// 	</see>
		/// .
		/// </remarks>
		public const int ACTION_PASS_TO_USER = unchecked((int)(0x00000001));

		/// <summary>This key event should extend the user activity timeout and turn the lights on.
		/// 	</summary>
		/// <remarks>
		/// This key event should extend the user activity timeout and turn the lights on.
		/// To be returned from
		/// <see cref="interceptKeyBeforeQueueing(KeyEvent, int, bool)">interceptKeyBeforeQueueing(KeyEvent, int, bool)
		/// 	</see>
		/// .
		/// Do not return this and
		/// <see cref="android.view.WindowManagerPolicyClass.ACTION_GO_TO_SLEEP">android.view.WindowManagerPolicyClass.ACTION_GO_TO_SLEEP
		/// 	</see>
		/// or
		/// <see cref="android.view.WindowManagerPolicyClass.ACTION_PASS_TO_USER">android.view.WindowManagerPolicyClass.ACTION_PASS_TO_USER
		/// 	</see>
		/// .
		/// </remarks>
		public const int ACTION_POKE_USER_ACTIVITY = unchecked((int)(0x00000002));

		/// <summary>
		/// This key event should put the device to sleep (and engage keyguard if necessary)
		/// To be returned from
		/// <see cref="interceptKeyBeforeQueueing(KeyEvent, int, bool)">interceptKeyBeforeQueueing(KeyEvent, int, bool)
		/// 	</see>
		/// .
		/// Do not return this and
		/// <see cref="android.view.WindowManagerPolicyClass.ACTION_POKE_USER_ACTIVITY">android.view.WindowManagerPolicyClass.ACTION_POKE_USER_ACTIVITY
		/// 	</see>
		/// or
		/// <see cref="android.view.WindowManagerPolicyClass.ACTION_PASS_TO_USER">android.view.WindowManagerPolicyClass.ACTION_PASS_TO_USER
		/// 	</see>
		/// .
		/// </summary>
		public const int ACTION_GO_TO_SLEEP = unchecked((int)(0x00000004));

		/// <summary>
		/// Interface to the Window Manager state associated with a particular
		/// window.
		/// </summary>
		/// <remarks>
		/// Interface to the Window Manager state associated with a particular
		/// window.  You can hold on to an instance of this interface from the call
		/// to prepareAddWindow() until removeWindow().
		/// </remarks>
		public interface WindowState
		{
			/// <summary>Perform standard frame computation.</summary>
			/// <remarks>
			/// Perform standard frame computation.  The result can be obtained with
			/// getFrame() if so desired.  Must be called with the window manager
			/// lock held.
			/// </remarks>
			/// <param name="parentFrame">
			/// The frame of the parent container this window
			/// is in, used for computing its basic position.
			/// </param>
			/// <param name="displayFrame">
			/// The frame of the overall display in which this
			/// window can appear, used for constraining the overall dimensions
			/// of the window.
			/// </param>
			/// <param name="contentFrame">
			/// The frame within the display in which we would
			/// like active content to appear.  This will cause windows behind to
			/// be resized to match the given content frame.
			/// </param>
			/// <param name="visibleFrame">
			/// The frame within the display that the window
			/// is actually visible, used for computing its visible insets to be
			/// given to windows behind.
			/// This can be used as a hint for scrolling (avoiding resizing)
			/// the window to make certain that parts of its content
			/// are visible.
			/// </param>
			void computeFrameLw(android.graphics.Rect parentFrame, android.graphics.Rect displayFrame
				, android.graphics.Rect contentFrame, android.graphics.Rect visibleFrame);

			/// <summary>
			/// Retrieve the current frame of the window that has been assigned by
			/// the window manager.
			/// </summary>
			/// <remarks>
			/// Retrieve the current frame of the window that has been assigned by
			/// the window manager.  Must be called with the window manager lock held.
			/// </remarks>
			/// <returns>Rect The rectangle holding the window frame.</returns>
			android.graphics.Rect getFrameLw();

			/// <summary>Retrieve the current frame of the window that is actually shown.</summary>
			/// <remarks>
			/// Retrieve the current frame of the window that is actually shown.
			/// Must be called with the window manager lock held.
			/// </remarks>
			/// <returns>Rect The rectangle holding the shown window frame.</returns>
			android.graphics.RectF getShownFrameLw();

			/// <summary>
			/// Retrieve the frame of the display that this window was last
			/// laid out in.
			/// </summary>
			/// <remarks>
			/// Retrieve the frame of the display that this window was last
			/// laid out in.  Must be called with the
			/// window manager lock held.
			/// </remarks>
			/// <returns>Rect The rectangle holding the display frame.</returns>
			android.graphics.Rect getDisplayFrameLw();

			/// <summary>
			/// Retrieve the frame of the content area that this window was last
			/// laid out in.
			/// </summary>
			/// <remarks>
			/// Retrieve the frame of the content area that this window was last
			/// laid out in.  This is the area in which the content of the window
			/// should be placed.  It will be smaller than the display frame to
			/// account for screen decorations such as a status bar or soft
			/// keyboard.  Must be called with the
			/// window manager lock held.
			/// </remarks>
			/// <returns>Rect The rectangle holding the content frame.</returns>
			android.graphics.Rect getContentFrameLw();

			/// <summary>
			/// Retrieve the frame of the visible area that this window was last
			/// laid out in.
			/// </summary>
			/// <remarks>
			/// Retrieve the frame of the visible area that this window was last
			/// laid out in.  This is the area of the screen in which the window
			/// will actually be fully visible.  It will be smaller than the
			/// content frame to account for transient UI elements blocking it
			/// such as an input method's candidates UI.  Must be called with the
			/// window manager lock held.
			/// </remarks>
			/// <returns>Rect The rectangle holding the visible frame.</returns>
			android.graphics.Rect getVisibleFrameLw();

			/// <summary>
			/// Returns true if this window is waiting to receive its given
			/// internal insets from the client app, and so should not impact the
			/// layout of other windows.
			/// </summary>
			/// <remarks>
			/// Returns true if this window is waiting to receive its given
			/// internal insets from the client app, and so should not impact the
			/// layout of other windows.
			/// </remarks>
			bool getGivenInsetsPendingLw();

			/// <summary>
			/// Retrieve the insets given by this window's client for the content
			/// area of windows behind it.
			/// </summary>
			/// <remarks>
			/// Retrieve the insets given by this window's client for the content
			/// area of windows behind it.  Must be called with the
			/// window manager lock held.
			/// </remarks>
			/// <returns>
			/// Rect The left, top, right, and bottom insets, relative
			/// to the window's frame, of the actual contents.
			/// </returns>
			android.graphics.Rect getGivenContentInsetsLw();

			/// <summary>
			/// Retrieve the insets given by this window's client for the visible
			/// area of windows behind it.
			/// </summary>
			/// <remarks>
			/// Retrieve the insets given by this window's client for the visible
			/// area of windows behind it.  Must be called with the
			/// window manager lock held.
			/// </remarks>
			/// <returns>
			/// Rect The left, top, right, and bottom insets, relative
			/// to the window's frame, of the actual visible area.
			/// </returns>
			android.graphics.Rect getGivenVisibleInsetsLw();

			/// <summary>Retrieve the current LayoutParams of the window.</summary>
			/// <remarks>Retrieve the current LayoutParams of the window.</remarks>
			/// <returns>
			/// WindowManager.LayoutParams The window's internal LayoutParams
			/// instance.
			/// </returns>
			android.view.WindowManagerClass.LayoutParams getAttrs();

			/// <summary>
			/// Retrieve the current system UI visibility flags associated with
			/// this window.
			/// </summary>
			/// <remarks>
			/// Retrieve the current system UI visibility flags associated with
			/// this window.
			/// </remarks>
			int getSystemUiVisibility();

			/// <summary>Get the layer at which this window's surface will be Z-ordered.</summary>
			/// <remarks>Get the layer at which this window's surface will be Z-ordered.</remarks>
			int getSurfaceLayer();

			/// <summary>
			/// Return the token for the application (actually activity) that owns
			/// this window.
			/// </summary>
			/// <remarks>
			/// Return the token for the application (actually activity) that owns
			/// this window.  May return null for system windows.
			/// </remarks>
			/// <returns>An IApplicationToken identifying the owning activity.</returns>
			android.view.IApplicationToken getAppToken();

			/// <summary>
			/// Return true if, at any point, the application token associated with
			/// this window has actually displayed any windows.
			/// </summary>
			/// <remarks>
			/// Return true if, at any point, the application token associated with
			/// this window has actually displayed any windows.  This is most useful
			/// with the "starting up" window to determine if any windows were
			/// displayed when it is closed.
			/// </remarks>
			/// <returns>
			/// Returns true if one or more windows have been displayed,
			/// else false.
			/// </returns>
			bool hasAppShownWindows();

			/// <summary>
			/// Is this window visible?  It is not visible if there is no
			/// surface, or we are in the process of running an exit animation
			/// that will remove the surface.
			/// </summary>
			/// <remarks>
			/// Is this window visible?  It is not visible if there is no
			/// surface, or we are in the process of running an exit animation
			/// that will remove the surface.
			/// </remarks>
			bool isVisibleLw();

			/// <summary>
			/// Like
			/// <see cref="isVisibleLw()">isVisibleLw()</see>
			/// , but also counts a window that is currently
			/// "hidden" behind the keyguard as visible.  This allows us to apply
			/// things like window flags that impact the keyguard.
			/// </summary>
			bool isVisibleOrBehindKeyguardLw();

			/// <summary>
			/// Is this window currently visible to the user on-screen?  It is
			/// displayed either if it is visible or it is currently running an
			/// animation before no longer being visible.
			/// </summary>
			/// <remarks>
			/// Is this window currently visible to the user on-screen?  It is
			/// displayed either if it is visible or it is currently running an
			/// animation before no longer being visible.  Must be called with the
			/// window manager lock held.
			/// </remarks>
			bool isDisplayedLw();

			/// <summary>
			/// Returns true if this window has been shown on screen at some time in
			/// the past.
			/// </summary>
			/// <remarks>
			/// Returns true if this window has been shown on screen at some time in
			/// the past.  Must be called with the window manager lock held.
			/// </remarks>
			/// <returns>boolean</returns>
			bool hasDrawnLw();

			/// <summary>
			/// Can be called by the policy to force a window to be hidden,
			/// regardless of whether the client or window manager would like
			/// it shown.
			/// </summary>
			/// <remarks>
			/// Can be called by the policy to force a window to be hidden,
			/// regardless of whether the client or window manager would like
			/// it shown.  Must be called with the window manager lock held.
			/// Returns true if
			/// <see cref="showLw(bool)">showLw(bool)</see>
			/// was last called for the window.
			/// </remarks>
			bool hideLw(bool doAnimation);

			/// <summary>
			/// Can be called to undo the effect of
			/// <see cref="hideLw(bool)">hideLw(bool)</see>
			/// , allowing a
			/// window to be shown as long as the window manager and client would
			/// also like it to be shown.  Must be called with the window manager
			/// lock held.
			/// Returns true if
			/// <see cref="hideLw(bool)">hideLw(bool)</see>
			/// was last called for the window.
			/// </summary>
			bool showLw(bool doAnimation);
		}

		/// <summary>
		/// Representation of a "fake window" that the policy has added to the
		/// window manager to consume events.
		/// </summary>
		/// <remarks>
		/// Representation of a "fake window" that the policy has added to the
		/// window manager to consume events.
		/// </remarks>
		public interface FakeWindow
		{
			/// <summary>Remove the fake window from the window manager.</summary>
			/// <remarks>Remove the fake window from the window manager.</remarks>
			void dismiss();
		}

		/// <summary>
		/// Interface for calling back in to the window manager that is private
		/// between it and the policy.
		/// </summary>
		/// <remarks>
		/// Interface for calling back in to the window manager that is private
		/// between it and the policy.
		/// </remarks>
		public interface WindowManagerFuncs
		{
			/// <summary>Ask the window manager to re-evaluate the system UI flags.</summary>
			/// <remarks>Ask the window manager to re-evaluate the system UI flags.</remarks>
			void reevaluateStatusBarVisibility();

			/// <summary>Add a fake window to the window manager.</summary>
			/// <remarks>
			/// Add a fake window to the window manager.  This window sits
			/// at the top of the other windows and consumes events.
			/// </remarks>
			android.view.WindowManagerPolicyClass.FakeWindow addFakeWindow(android.os.Looper 
				looper, android.view.InputHandler inputHandler, string name, int windowType, int
				 layoutParamsFlags, bool canReceiveKeys, bool hasFocus, bool touchFullscreen);
		}

		/// <summary>Bit mask that is set for all enter transition.</summary>
		/// <remarks>Bit mask that is set for all enter transition.</remarks>
		public const int TRANSIT_ENTER_MASK = unchecked((int)(0x1000));

		/// <summary>Bit mask that is set for all exit transitions.</summary>
		/// <remarks>Bit mask that is set for all exit transitions.</remarks>
		public const int TRANSIT_EXIT_MASK = unchecked((int)(0x2000));

		/// <summary>Not set up for a transition.</summary>
		/// <remarks>Not set up for a transition.</remarks>
		public const int TRANSIT_UNSET = -1;

		/// <summary>No animation for transition.</summary>
		/// <remarks>No animation for transition.</remarks>
		public const int TRANSIT_NONE = 0;

		/// <summary>Window has been added to the screen.</summary>
		/// <remarks>Window has been added to the screen.</remarks>
		public const int TRANSIT_ENTER = 1 | android.view.WindowManagerPolicyClass.TRANSIT_ENTER_MASK;

		/// <summary>Window has been removed from the screen.</summary>
		/// <remarks>Window has been removed from the screen.</remarks>
		public const int TRANSIT_EXIT = 2 | android.view.WindowManagerPolicyClass.TRANSIT_EXIT_MASK;

		/// <summary>Window has been made visible.</summary>
		/// <remarks>Window has been made visible.</remarks>
		public const int TRANSIT_SHOW = 3 | android.view.WindowManagerPolicyClass.TRANSIT_ENTER_MASK;

		/// <summary>Window has been made invisible.</summary>
		/// <remarks>Window has been made invisible.</remarks>
		public const int TRANSIT_HIDE = 4 | android.view.WindowManagerPolicyClass.TRANSIT_EXIT_MASK;

		/// <summary>
		/// The "application starting" preview window is no longer needed, and will
		/// animate away to show the real window.
		/// </summary>
		/// <remarks>
		/// The "application starting" preview window is no longer needed, and will
		/// animate away to show the real window.
		/// </remarks>
		public const int TRANSIT_PREVIEW_DONE = 5;

		/// <summary>
		/// A window in a new activity is being opened on top of an existing one
		/// in the same task.
		/// </summary>
		/// <remarks>
		/// A window in a new activity is being opened on top of an existing one
		/// in the same task.
		/// </remarks>
		public const int TRANSIT_ACTIVITY_OPEN = 6 | android.view.WindowManagerPolicyClass.TRANSIT_ENTER_MASK;

		/// <summary>
		/// The window in the top-most activity is being closed to reveal the
		/// previous activity in the same task.
		/// </summary>
		/// <remarks>
		/// The window in the top-most activity is being closed to reveal the
		/// previous activity in the same task.
		/// </remarks>
		public const int TRANSIT_ACTIVITY_CLOSE = 7 | android.view.WindowManagerPolicyClass.TRANSIT_EXIT_MASK;

		/// <summary>
		/// A window in a new task is being opened on top of an existing one
		/// in another activity's task.
		/// </summary>
		/// <remarks>
		/// A window in a new task is being opened on top of an existing one
		/// in another activity's task.
		/// </remarks>
		public const int TRANSIT_TASK_OPEN = 8 | android.view.WindowManagerPolicyClass.TRANSIT_ENTER_MASK;

		/// <summary>
		/// A window in the top-most activity is being closed to reveal the
		/// previous activity in a different task.
		/// </summary>
		/// <remarks>
		/// A window in the top-most activity is being closed to reveal the
		/// previous activity in a different task.
		/// </remarks>
		public const int TRANSIT_TASK_CLOSE = 9 | android.view.WindowManagerPolicyClass.TRANSIT_EXIT_MASK;

		/// <summary>
		/// A window in an existing task is being displayed on top of an existing one
		/// in another activity's task.
		/// </summary>
		/// <remarks>
		/// A window in an existing task is being displayed on top of an existing one
		/// in another activity's task.
		/// </remarks>
		public const int TRANSIT_TASK_TO_FRONT = 10 | android.view.WindowManagerPolicyClass.TRANSIT_ENTER_MASK;

		/// <summary>A window in an existing task is being put below all other tasks.</summary>
		/// <remarks>A window in an existing task is being put below all other tasks.</remarks>
		public const int TRANSIT_TASK_TO_BACK = 11 | android.view.WindowManagerPolicyClass.TRANSIT_EXIT_MASK;

		/// <summary>
		/// A window in a new activity that doesn't have a wallpaper is being
		/// opened on top of one that does, effectively closing the wallpaper.
		/// </summary>
		/// <remarks>
		/// A window in a new activity that doesn't have a wallpaper is being
		/// opened on top of one that does, effectively closing the wallpaper.
		/// </remarks>
		public const int TRANSIT_WALLPAPER_CLOSE = 12 | android.view.WindowManagerPolicyClass.TRANSIT_EXIT_MASK;

		/// <summary>
		/// A window in a new activity that does have a wallpaper is being
		/// opened on one that didn't, effectively opening the wallpaper.
		/// </summary>
		/// <remarks>
		/// A window in a new activity that does have a wallpaper is being
		/// opened on one that didn't, effectively opening the wallpaper.
		/// </remarks>
		public const int TRANSIT_WALLPAPER_OPEN = 13 | android.view.WindowManagerPolicyClass.TRANSIT_ENTER_MASK;

		/// <summary>
		/// A window in a new activity is being opened on top of an existing one,
		/// and both are on top of the wallpaper.
		/// </summary>
		/// <remarks>
		/// A window in a new activity is being opened on top of an existing one,
		/// and both are on top of the wallpaper.
		/// </remarks>
		public const int TRANSIT_WALLPAPER_INTRA_OPEN = 14 | android.view.WindowManagerPolicyClass.TRANSIT_ENTER_MASK;

		/// <summary>
		/// The window in the top-most activity is being closed to reveal the
		/// previous activity, and both are on top of he wallpaper.
		/// </summary>
		/// <remarks>
		/// The window in the top-most activity is being closed to reveal the
		/// previous activity, and both are on top of he wallpaper.
		/// </remarks>
		public const int TRANSIT_WALLPAPER_INTRA_CLOSE = 15 | android.view.WindowManagerPolicyClass.TRANSIT_EXIT_MASK;

		/// <summary>Screen turned off because of a device admin</summary>
		public const int OFF_BECAUSE_OF_ADMIN = 1;

		/// <summary>Screen turned off because of power button</summary>
		public const int OFF_BECAUSE_OF_USER = 2;

		/// <summary>Screen turned off because of timeout</summary>
		public const int OFF_BECAUSE_OF_TIMEOUT = 3;

		/// <summary>Screen turned off because of proximity sensor</summary>
		public const int OFF_BECAUSE_OF_PROX_SENSOR = 4;

		/// <summary>
		/// When not otherwise specified by the activity's screenOrientation, rotation should be
		/// determined by the system (that is, using sensors).
		/// </summary>
		/// <remarks>
		/// When not otherwise specified by the activity's screenOrientation, rotation should be
		/// determined by the system (that is, using sensors).
		/// </remarks>
		public const int USER_ROTATION_FREE = 0;

		/// <summary>
		/// When not otherwise specified by the activity's screenOrientation, rotation is set by
		/// the user.
		/// </summary>
		/// <remarks>
		/// When not otherwise specified by the activity's screenOrientation, rotation is set by
		/// the user.
		/// </remarks>
		public const int USER_ROTATION_LOCKED = 1;

		/// <summary>Layout state may have changed (so another layout will be performed)</summary>
		public const int FINISH_LAYOUT_REDO_LAYOUT = unchecked((int)(0x0001));

		/// <summary>Configuration state may have changed</summary>
		public const int FINISH_LAYOUT_REDO_CONFIG = unchecked((int)(0x0002));

		/// <summary>Wallpaper may need to move</summary>
		public const int FINISH_LAYOUT_REDO_WALLPAPER = unchecked((int)(0x0004));

		/// <summary>Need to recompute animations</summary>
		public const int FINISH_LAYOUT_REDO_ANIM = unchecked((int)(0x0008));

		public interface ScreenOnListener
		{
			void onScreenOn();
		}

		/// <summary>
		/// Callback used by
		/// <see cref="WindowManagerPolicy.exitKeyguardSecurely(OnKeyguardExitResult)">WindowManagerPolicy.exitKeyguardSecurely(OnKeyguardExitResult)
		/// 	</see>
		/// </summary>
		public interface OnKeyguardExitResult
		{
			void onKeyguardExitResult(bool success);
		}
	}
}

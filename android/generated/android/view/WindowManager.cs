using Sharpen;

namespace android.view
{
	/// <summary>The interface that apps use to talk to the window manager.</summary>
	/// <remarks>
	/// The interface that apps use to talk to the window manager.
	/// <p>
	/// Use <code>Context.getSystemService(Context.WINDOW_SERVICE)</code> to get one of these.
	/// </remarks>
	/// <seealso cref="android.content.Context.getSystemService(string)">android.content.Context.getSystemService(string)
	/// 	</seealso>
	/// <seealso cref="android.content.Context.WINDOW_SERVICE">android.content.Context.WINDOW_SERVICE
	/// 	</seealso>
	[Sharpen.Sharpened]
	public interface WindowManager : android.view.ViewManager
	{
		/// <summary>Use this method to get the default Display object.</summary>
		/// <remarks>Use this method to get the default Display object.</remarks>
		/// <returns>default Display object</returns>
		android.view.Display getDefaultDisplay();

		/// <summary>
		/// Special variation of
		/// <see cref="ViewManager.removeView(View)">ViewManager.removeView(View)</see>
		/// that immediately invokes
		/// the given view hierarchy's
		/// <see cref="View.onDetachedFromWindow()">View.onDetachedFromWindow()</see>
		/// methods before returning.  This is not
		/// for normal applications; using it correctly requires great care.
		/// </summary>
		/// <param name="view">The view to be removed.</param>
		void removeViewImmediate(android.view.View view);

		/// <summary>
		/// Return true if this window manager is configured to request hardware
		/// accelerated windows.
		/// </summary>
		/// <remarks>
		/// Return true if this window manager is configured to request hardware
		/// accelerated windows.  This does <em>not</em> guarantee that they will
		/// actually be accelerated, since that depends on the device supporting them.
		/// </remarks>
		/// <hide></hide>
		bool isHardwareAccelerated();
		// ----- HIDDEN FLAGS.
		// These start at the high bit and go down.
		// internal buffer to backup/restore parameters under compatibility mode.
		// NOTE: token only copied if the recipient doesn't
		// already have one.
		// NOTE: packageName only copied if the recipient doesn't
		// already have one.
		// we backup 4 elements, x, y, width, height
	}

	/// <summary>The interface that apps use to talk to the window manager.</summary>
	/// <remarks>
	/// The interface that apps use to talk to the window manager.
	/// <p>
	/// Use <code>Context.getSystemService(Context.WINDOW_SERVICE)</code> to get one of these.
	/// </remarks>
	/// <seealso cref="android.content.Context.getSystemService(string)">android.content.Context.getSystemService(string)
	/// 	</seealso>
	/// <seealso cref="android.content.Context.WINDOW_SERVICE">android.content.Context.WINDOW_SERVICE
	/// 	</seealso>
	[Sharpen.Sharpened]
	public static class WindowManagerClass
	{
		/// <summary>
		/// Exception that is thrown when trying to add view whose
		/// <see cref="LayoutParams">LayoutParams</see>
		/// 
		/// <see cref="LayoutParams.token">LayoutParams.token</see>
		/// is invalid.
		/// </summary>
		[System.Serializable]
		public class BadTokenException : java.lang.RuntimeException
		{
			public BadTokenException()
			{
			}

			public BadTokenException(string name) : base(name)
			{
			}
		}

		public class LayoutParams : android.view.ViewGroup.LayoutParams, android.os.Parcelable
		{
			/// <summary>X position for this window.</summary>
			/// <remarks>
			/// X position for this window.  With the default gravity it is ignored.
			/// When using
			/// <see cref="Gravity.LEFT">Gravity.LEFT</see>
			/// or
			/// <see cref="Gravity.START">Gravity.START</see>
			/// or
			/// <see cref="Gravity.RIGHT">Gravity.RIGHT</see>
			/// or
			/// <see cref="Gravity.END">Gravity.END</see>
			/// it provides an offset from the given edge.
			/// </remarks>
			[android.view.ViewDebug.ExportedProperty]
			public int x;

			/// <summary>Y position for this window.</summary>
			/// <remarks>
			/// Y position for this window.  With the default gravity it is ignored.
			/// When using
			/// <see cref="Gravity.TOP">Gravity.TOP</see>
			/// or
			/// <see cref="Gravity.BOTTOM">Gravity.BOTTOM</see>
			/// it provides
			/// an offset from the given edge.
			/// </remarks>
			[android.view.ViewDebug.ExportedProperty]
			public int y;

			/// <summary>
			/// Indicates how much of the extra space will be allocated horizontally
			/// to the view associated with these LayoutParams.
			/// </summary>
			/// <remarks>
			/// Indicates how much of the extra space will be allocated horizontally
			/// to the view associated with these LayoutParams. Specify 0 if the view
			/// should not be stretched. Otherwise the extra pixels will be pro-rated
			/// among all views whose weight is greater than 0.
			/// </remarks>
			[android.view.ViewDebug.ExportedProperty]
			public float horizontalWeight;

			/// <summary>
			/// Indicates how much of the extra space will be allocated vertically
			/// to the view associated with these LayoutParams.
			/// </summary>
			/// <remarks>
			/// Indicates how much of the extra space will be allocated vertically
			/// to the view associated with these LayoutParams. Specify 0 if the view
			/// should not be stretched. Otherwise the extra pixels will be pro-rated
			/// among all views whose weight is greater than 0.
			/// </remarks>
			[android.view.ViewDebug.ExportedProperty]
			public float verticalWeight;

			/// <summary>The general type of window.</summary>
			/// <remarks>
			/// The general type of window.  There are three main classes of
			/// window types:
			/// <ul>
			/// <li> <strong>Application windows</strong> (ranging from
			/// <see cref="FIRST_APPLICATION_WINDOW">FIRST_APPLICATION_WINDOW</see>
			/// to
			/// <see cref="LAST_APPLICATION_WINDOW">LAST_APPLICATION_WINDOW</see>
			/// ) are normal top-level application
			/// windows.  For these types of windows, the
			/// <see cref="token">token</see>
			/// must be
			/// set to the token of the activity they are a part of (this will
			/// normally be done for you if
			/// <see cref="token">token</see>
			/// is null).
			/// <li> <strong>Sub-windows</strong> (ranging from
			/// <see cref="FIRST_SUB_WINDOW">FIRST_SUB_WINDOW</see>
			/// to
			/// <see cref="LAST_SUB_WINDOW">LAST_SUB_WINDOW</see>
			/// ) are associated with another top-level
			/// window.  For these types of windows, the
			/// <see cref="token">token</see>
			/// must be
			/// the token of the window it is attached to.
			/// <li> <strong>System windows</strong> (ranging from
			/// <see cref="FIRST_SYSTEM_WINDOW">FIRST_SYSTEM_WINDOW</see>
			/// to
			/// <see cref="LAST_SYSTEM_WINDOW">LAST_SYSTEM_WINDOW</see>
			/// ) are special types of windows for
			/// use by the system for specific purposes.  They should not normally
			/// be used by applications, and a special permission is required
			/// to use them.
			/// </ul>
			/// </remarks>
			/// <seealso cref="TYPE_BASE_APPLICATION">TYPE_BASE_APPLICATION</seealso>
			/// <seealso cref="TYPE_APPLICATION">TYPE_APPLICATION</seealso>
			/// <seealso cref="TYPE_APPLICATION_STARTING">TYPE_APPLICATION_STARTING</seealso>
			/// <seealso cref="TYPE_APPLICATION_PANEL">TYPE_APPLICATION_PANEL</seealso>
			/// <seealso cref="TYPE_APPLICATION_MEDIA">TYPE_APPLICATION_MEDIA</seealso>
			/// <seealso cref="TYPE_APPLICATION_SUB_PANEL">TYPE_APPLICATION_SUB_PANEL</seealso>
			/// <seealso cref="TYPE_APPLICATION_ATTACHED_DIALOG">TYPE_APPLICATION_ATTACHED_DIALOG
			/// 	</seealso>
			/// <seealso cref="TYPE_STATUS_BAR">TYPE_STATUS_BAR</seealso>
			/// <seealso cref="TYPE_SEARCH_BAR">TYPE_SEARCH_BAR</seealso>
			/// <seealso cref="TYPE_PHONE">TYPE_PHONE</seealso>
			/// <seealso cref="TYPE_SYSTEM_ALERT">TYPE_SYSTEM_ALERT</seealso>
			/// <seealso cref="TYPE_KEYGUARD">TYPE_KEYGUARD</seealso>
			/// <seealso cref="TYPE_TOAST">TYPE_TOAST</seealso>
			/// <seealso cref="TYPE_SYSTEM_OVERLAY">TYPE_SYSTEM_OVERLAY</seealso>
			/// <seealso cref="TYPE_PRIORITY_PHONE">TYPE_PRIORITY_PHONE</seealso>
			/// <seealso cref="TYPE_STATUS_BAR_PANEL">TYPE_STATUS_BAR_PANEL</seealso>
			/// <seealso cref="TYPE_SYSTEM_DIALOG">TYPE_SYSTEM_DIALOG</seealso>
			/// <seealso cref="TYPE_KEYGUARD_DIALOG">TYPE_KEYGUARD_DIALOG</seealso>
			/// <seealso cref="TYPE_SYSTEM_ERROR">TYPE_SYSTEM_ERROR</seealso>
			/// <seealso cref="TYPE_INPUT_METHOD">TYPE_INPUT_METHOD</seealso>
			/// <seealso cref="TYPE_INPUT_METHOD_DIALOG">TYPE_INPUT_METHOD_DIALOG</seealso>
			public int type;

			/// <summary>Start of window types that represent normal application windows.</summary>
			/// <remarks>Start of window types that represent normal application windows.</remarks>
			public const int FIRST_APPLICATION_WINDOW = 1;

			/// <summary>
			/// Window type: an application window that serves as the "base" window
			/// of the overall application; all other application windows will
			/// appear on top of it.
			/// </summary>
			/// <remarks>
			/// Window type: an application window that serves as the "base" window
			/// of the overall application; all other application windows will
			/// appear on top of it.
			/// </remarks>
			public const int TYPE_BASE_APPLICATION = 1;

			/// <summary>Window type: a normal application window.</summary>
			/// <remarks>
			/// Window type: a normal application window.  The
			/// <see cref="token">token</see>
			/// must be
			/// an Activity token identifying who the window belongs to.
			/// </remarks>
			public const int TYPE_APPLICATION = 2;

			/// <summary>
			/// Window type: special application window that is displayed while the
			/// application is starting.
			/// </summary>
			/// <remarks>
			/// Window type: special application window that is displayed while the
			/// application is starting.  Not for use by applications themselves;
			/// this is used by the system to display something until the
			/// application can show its own windows.
			/// </remarks>
			public const int TYPE_APPLICATION_STARTING = 3;

			/// <summary>End of types of application windows.</summary>
			/// <remarks>End of types of application windows.</remarks>
			public const int LAST_APPLICATION_WINDOW = 99;

			/// <summary>Start of types of sub-windows.</summary>
			/// <remarks>
			/// Start of types of sub-windows.  The
			/// <see cref="token">token</see>
			/// of these windows
			/// must be set to the window they are attached to.  These types of
			/// windows are kept next to their attached window in Z-order, and their
			/// coordinate space is relative to their attached window.
			/// </remarks>
			public const int FIRST_SUB_WINDOW = 1000;

			/// <summary>Window type: a panel on top of an application window.</summary>
			/// <remarks>
			/// Window type: a panel on top of an application window.  These windows
			/// appear on top of their attached window.
			/// </remarks>
			public const int TYPE_APPLICATION_PANEL = FIRST_SUB_WINDOW;

			/// <summary>Window type: window for showing media (e.g.</summary>
			/// <remarks>
			/// Window type: window for showing media (e.g. video).  These windows
			/// are displayed behind their attached window.
			/// </remarks>
			public const int TYPE_APPLICATION_MEDIA = FIRST_SUB_WINDOW + 1;

			/// <summary>Window type: a sub-panel on top of an application window.</summary>
			/// <remarks>
			/// Window type: a sub-panel on top of an application window.  These
			/// windows are displayed on top their attached window and any
			/// <see cref="TYPE_APPLICATION_PANEL">TYPE_APPLICATION_PANEL</see>
			/// panels.
			/// </remarks>
			public const int TYPE_APPLICATION_SUB_PANEL = FIRST_SUB_WINDOW + 2;

			/// <summary>
			/// Window type: like
			/// <see cref="TYPE_APPLICATION_PANEL">TYPE_APPLICATION_PANEL</see>
			/// , but layout
			/// of the window happens as that of a top-level window, <em>not</em>
			/// as a child of its container.
			/// </summary>
			public const int TYPE_APPLICATION_ATTACHED_DIALOG = FIRST_SUB_WINDOW + 3;

			/// <summary>Window type: window for showing overlays on top of media windows.</summary>
			/// <remarks>
			/// Window type: window for showing overlays on top of media windows.
			/// These windows are displayed between TYPE_APPLICATION_MEDIA and the
			/// application window.  They should be translucent to be useful.  This
			/// is a big ugly hack so:
			/// </remarks>
			/// <hide></hide>
			public const int TYPE_APPLICATION_MEDIA_OVERLAY = FIRST_SUB_WINDOW + 4;

			/// <summary>End of types of sub-windows.</summary>
			/// <remarks>End of types of sub-windows.</remarks>
			public const int LAST_SUB_WINDOW = 1999;

			/// <summary>Start of system-specific window types.</summary>
			/// <remarks>
			/// Start of system-specific window types.  These are not normally
			/// created by applications.
			/// </remarks>
			public const int FIRST_SYSTEM_WINDOW = 2000;

			/// <summary>Window type: the status bar.</summary>
			/// <remarks>
			/// Window type: the status bar.  There can be only one status bar
			/// window; it is placed at the top of the screen, and all other
			/// windows are shifted down so they are below it.
			/// </remarks>
			public const int TYPE_STATUS_BAR = FIRST_SYSTEM_WINDOW;

			/// <summary>Window type: the search bar.</summary>
			/// <remarks>
			/// Window type: the search bar.  There can be only one search bar
			/// window; it is placed at the top of the screen.
			/// </remarks>
			public const int TYPE_SEARCH_BAR = FIRST_SYSTEM_WINDOW + 1;

			/// <summary>Window type: phone.</summary>
			/// <remarks>
			/// Window type: phone.  These are non-application windows providing
			/// user interaction with the phone (in particular incoming calls).
			/// These windows are normally placed above all applications, but behind
			/// the status bar.
			/// </remarks>
			public const int TYPE_PHONE = FIRST_SYSTEM_WINDOW + 2;

			/// <summary>Window type: system window, such as low power alert.</summary>
			/// <remarks>
			/// Window type: system window, such as low power alert. These windows
			/// are always on top of application windows.
			/// </remarks>
			public const int TYPE_SYSTEM_ALERT = FIRST_SYSTEM_WINDOW + 3;

			/// <summary>Window type: keyguard window.</summary>
			/// <remarks>Window type: keyguard window.</remarks>
			public const int TYPE_KEYGUARD = FIRST_SYSTEM_WINDOW + 4;

			/// <summary>Window type: transient notifications.</summary>
			/// <remarks>Window type: transient notifications.</remarks>
			public const int TYPE_TOAST = FIRST_SYSTEM_WINDOW + 5;

			/// <summary>
			/// Window type: system overlay windows, which need to be displayed
			/// on top of everything else.
			/// </summary>
			/// <remarks>
			/// Window type: system overlay windows, which need to be displayed
			/// on top of everything else.  These windows must not take input
			/// focus, or they will interfere with the keyguard.
			/// </remarks>
			public const int TYPE_SYSTEM_OVERLAY = FIRST_SYSTEM_WINDOW + 6;

			/// <summary>
			/// Window type: priority phone UI, which needs to be displayed even if
			/// the keyguard is active.
			/// </summary>
			/// <remarks>
			/// Window type: priority phone UI, which needs to be displayed even if
			/// the keyguard is active.  These windows must not take input
			/// focus, or they will interfere with the keyguard.
			/// </remarks>
			public const int TYPE_PRIORITY_PHONE = FIRST_SYSTEM_WINDOW + 7;

			/// <summary>Window type: panel that slides out from the status bar</summary>
			public const int TYPE_SYSTEM_DIALOG = FIRST_SYSTEM_WINDOW + 8;

			/// <summary>Window type: dialogs that the keyguard shows</summary>
			public const int TYPE_KEYGUARD_DIALOG = FIRST_SYSTEM_WINDOW + 9;

			/// <summary>
			/// Window type: internal system error windows, appear on top of
			/// everything they can.
			/// </summary>
			/// <remarks>
			/// Window type: internal system error windows, appear on top of
			/// everything they can.
			/// </remarks>
			public const int TYPE_SYSTEM_ERROR = FIRST_SYSTEM_WINDOW + 10;

			/// <summary>
			/// Window type: internal input methods windows, which appear above
			/// the normal UI.
			/// </summary>
			/// <remarks>
			/// Window type: internal input methods windows, which appear above
			/// the normal UI.  Application windows may be resized or panned to keep
			/// the input focus visible while this window is displayed.
			/// </remarks>
			public const int TYPE_INPUT_METHOD = FIRST_SYSTEM_WINDOW + 11;

			/// <summary>
			/// Window type: internal input methods dialog windows, which appear above
			/// the current input method window.
			/// </summary>
			/// <remarks>
			/// Window type: internal input methods dialog windows, which appear above
			/// the current input method window.
			/// </remarks>
			public const int TYPE_INPUT_METHOD_DIALOG = FIRST_SYSTEM_WINDOW + 12;

			/// <summary>
			/// Window type: wallpaper window, placed behind any window that wants
			/// to sit on top of the wallpaper.
			/// </summary>
			/// <remarks>
			/// Window type: wallpaper window, placed behind any window that wants
			/// to sit on top of the wallpaper.
			/// </remarks>
			public const int TYPE_WALLPAPER = FIRST_SYSTEM_WINDOW + 13;

			/// <summary>Window type: panel that slides out from over the status bar</summary>
			public const int TYPE_STATUS_BAR_PANEL = FIRST_SYSTEM_WINDOW + 14;

			/// <summary>
			/// Window type: secure system overlay windows, which need to be displayed
			/// on top of everything else.
			/// </summary>
			/// <remarks>
			/// Window type: secure system overlay windows, which need to be displayed
			/// on top of everything else.  These windows must not take input
			/// focus, or they will interfere with the keyguard.
			/// This is exactly like
			/// <see cref="TYPE_SYSTEM_OVERLAY">TYPE_SYSTEM_OVERLAY</see>
			/// except that only the
			/// system itself is allowed to create these overlays.  Applications cannot
			/// obtain permission to create secure system overlays.
			/// </remarks>
			/// <hide></hide>
			public const int TYPE_SECURE_SYSTEM_OVERLAY = FIRST_SYSTEM_WINDOW + 15;

			/// <summary>Window type: the drag-and-drop pseudowindow.</summary>
			/// <remarks>
			/// Window type: the drag-and-drop pseudowindow.  There is only one
			/// drag layer (at most), and it is placed on top of all other windows.
			/// </remarks>
			/// <hide></hide>
			public const int TYPE_DRAG = FIRST_SYSTEM_WINDOW + 16;

			/// <summary>Window type: panel that slides out from under the status bar</summary>
			/// <hide></hide>
			public const int TYPE_STATUS_BAR_SUB_PANEL = FIRST_SYSTEM_WINDOW + 17;

			/// <summary>Window type: (mouse) pointer</summary>
			/// <hide></hide>
			public const int TYPE_POINTER = FIRST_SYSTEM_WINDOW + 18;

			/// <summary>Window type: Navigation bar (when distinct from status bar)</summary>
			/// <hide></hide>
			public const int TYPE_NAVIGATION_BAR = FIRST_SYSTEM_WINDOW + 19;

			/// <summary>
			/// Window type: The volume level overlay/dialog shown when the user
			/// changes the system volume.
			/// </summary>
			/// <remarks>
			/// Window type: The volume level overlay/dialog shown when the user
			/// changes the system volume.
			/// </remarks>
			/// <hide></hide>
			public const int TYPE_VOLUME_OVERLAY = FIRST_SYSTEM_WINDOW + 20;

			/// <summary>
			/// Window type: The boot progress dialog, goes on top of everything
			/// in the world.
			/// </summary>
			/// <remarks>
			/// Window type: The boot progress dialog, goes on top of everything
			/// in the world.
			/// </remarks>
			/// <hide></hide>
			public const int TYPE_BOOT_PROGRESS = FIRST_SYSTEM_WINDOW + 21;

			/// <summary>
			/// Window type: Fake window to consume touch events when the navigation
			/// bar is hidden.
			/// </summary>
			/// <remarks>
			/// Window type: Fake window to consume touch events when the navigation
			/// bar is hidden.
			/// </remarks>
			/// <hide></hide>
			public const int TYPE_HIDDEN_NAV_CONSUMER = FIRST_SYSTEM_WINDOW + 22;

			/// <summary>End of types of system windows.</summary>
			/// <remarks>End of types of system windows.</remarks>
			public const int LAST_SYSTEM_WINDOW = 2999;

			[System.ObsoleteAttribute(@"this is ignored, this value is set automatically when needed."
				)]
			public const int MEMORY_TYPE_NORMAL = 0;

			[System.ObsoleteAttribute(@"this is ignored, this value is set automatically when needed."
				)]
			public const int MEMORY_TYPE_HARDWARE = 1;

			[System.ObsoleteAttribute(@"this is ignored, this value is set automatically when needed."
				)]
			public const int MEMORY_TYPE_GPU = 2;

			[System.ObsoleteAttribute(@"this is ignored, this value is set automatically when needed."
				)]
			public const int MEMORY_TYPE_PUSH_BUFFERS = 3;

			[System.ObsoleteAttribute(@"this is ignored")]
			public int memoryType;

			/// <summary>
			/// Window flag: as long as this window is visible to the user, allow
			/// the lock screen to activate while the screen is on.
			/// </summary>
			/// <remarks>
			/// Window flag: as long as this window is visible to the user, allow
			/// the lock screen to activate while the screen is on.
			/// This can be used independently, or in combination with
			/// <see cref="FLAG_KEEP_SCREEN_ON">FLAG_KEEP_SCREEN_ON</see>
			/// and/or
			/// <see cref="FLAG_SHOW_WHEN_LOCKED">FLAG_SHOW_WHEN_LOCKED</see>
			/// 
			/// </remarks>
			public const int FLAG_ALLOW_LOCK_WHILE_SCREEN_ON = unchecked((int)(0x00000001));

			/// <summary>Window flag: everything behind this window will be dimmed.</summary>
			/// <remarks>
			/// Window flag: everything behind this window will be dimmed.
			/// Use
			/// <see cref="dimAmount">dimAmount</see>
			/// to control the amount of dim.
			/// </remarks>
			public const int FLAG_DIM_BEHIND = unchecked((int)(0x00000002));

			/// <summary>Window flag: blur everything behind this window.</summary>
			/// <remarks>Window flag: blur everything behind this window.</remarks>
			[System.ObsoleteAttribute(@"Blurring is no longer supported.")]
			public const int FLAG_BLUR_BEHIND = unchecked((int)(0x00000004));

			/// <summary>
			/// Window flag: this window won't ever get key input focus, so the
			/// user can not send key or other button events to it.
			/// </summary>
			/// <remarks>
			/// Window flag: this window won't ever get key input focus, so the
			/// user can not send key or other button events to it.  Those will
			/// instead go to whatever focusable window is behind it.  This flag
			/// will also enable
			/// <see cref="FLAG_NOT_TOUCH_MODAL">FLAG_NOT_TOUCH_MODAL</see>
			/// whether or not that
			/// is explicitly set.
			/// <p>Setting this flag also implies that the window will not need to
			/// interact with
			/// a soft input method, so it will be Z-ordered and positioned
			/// independently of any active input method (typically this means it
			/// gets Z-ordered on top of the input method, so it can use the full
			/// screen for its content and cover the input method if needed.  You
			/// can use
			/// <see cref="FLAG_ALT_FOCUSABLE_IM">FLAG_ALT_FOCUSABLE_IM</see>
			/// to modify this behavior.
			/// </remarks>
			public const int FLAG_NOT_FOCUSABLE = unchecked((int)(0x00000008));

			/// <summary>Window flag: this window can never receive touch events.</summary>
			/// <remarks>Window flag: this window can never receive touch events.</remarks>
			public const int FLAG_NOT_TOUCHABLE = unchecked((int)(0x00000010));

			/// <summary>
			/// Window flag: Even when this window is focusable (its
			/// <see cref="FLAG_NOT_FOCUSABLE">
			/// is not set), allow any pointer events
			/// outside of the window to be sent to the windows behind it.  Otherwise
			/// it will consume all pointer events itself, regardless of whether they
			/// are inside of the window.
			/// </see>
			/// </summary>
			public const int FLAG_NOT_TOUCH_MODAL = unchecked((int)(0x00000020));

			/// <summary>
			/// Window flag: When set, if the device is asleep when the touch
			/// screen is pressed, you will receive this first touch event.
			/// </summary>
			/// <remarks>
			/// Window flag: When set, if the device is asleep when the touch
			/// screen is pressed, you will receive this first touch event.  Usually
			/// the first touch event is consumed by the system since the user can
			/// not see what they are pressing on.
			/// </remarks>
			public const int FLAG_TOUCHABLE_WHEN_WAKING = unchecked((int)(0x00000040));

			/// <summary>
			/// Window flag: as long as this window is visible to the user, keep
			/// the device's screen turned on and bright.
			/// </summary>
			/// <remarks>
			/// Window flag: as long as this window is visible to the user, keep
			/// the device's screen turned on and bright.
			/// </remarks>
			public const int FLAG_KEEP_SCREEN_ON = unchecked((int)(0x00000080));

			/// <summary>
			/// Window flag: place the window within the entire screen, ignoring
			/// decorations around the border (a.k.a.
			/// </summary>
			/// <remarks>
			/// Window flag: place the window within the entire screen, ignoring
			/// decorations around the border (a.k.a. the status bar).  The
			/// window must correctly position its contents to take the screen
			/// decoration into account.  This flag is normally set for you
			/// by Window as described in
			/// <see cref="Window.setFlags(int, int)">Window.setFlags(int, int)</see>
			/// .
			/// </remarks>
			public const int FLAG_LAYOUT_IN_SCREEN = unchecked((int)(0x00000100));

			/// <summary>Window flag: allow window to extend outside of the screen.</summary>
			/// <remarks>Window flag: allow window to extend outside of the screen.</remarks>
			public const int FLAG_LAYOUT_NO_LIMITS = unchecked((int)(0x00000200));

			/// <summary>Window flag: Hide all screen decorations (e.g.</summary>
			/// <remarks>
			/// Window flag: Hide all screen decorations (e.g. status bar) while
			/// this window is displayed.  This allows the window to use the entire
			/// display space for itself -- the status bar will be hidden when
			/// an app window with this flag set is on the top layer.
			/// </remarks>
			public const int FLAG_FULLSCREEN = unchecked((int)(0x00000400));

			/// <summary>
			/// Window flag: Override
			/// <see cref="FLAG_FULLSCREEN">
			/// and force the
			/// screen decorations (such as status bar) to be shown.
			/// </see>
			/// </summary>
			public const int FLAG_FORCE_NOT_FULLSCREEN = unchecked((int)(0x00000800));

			/// <summary>
			/// Window flag: turn on dithering when compositing this window to
			/// the screen.
			/// </summary>
			/// <remarks>
			/// Window flag: turn on dithering when compositing this window to
			/// the screen.
			/// </remarks>
			public const int FLAG_DITHER = unchecked((int)(0x00001000));

			/// <summary>
			/// Window flag: don't allow screen shots while this window is
			/// displayed.
			/// </summary>
			/// <remarks>
			/// Window flag: don't allow screen shots while this window is
			/// displayed. Maps to Surface.SECURE.
			/// </remarks>
			public const int FLAG_SECURE = unchecked((int)(0x00002000));

			/// <summary>
			/// Window flag: a special mode where the layout parameters are used
			/// to perform scaling of the surface when it is composited to the
			/// screen.
			/// </summary>
			/// <remarks>
			/// Window flag: a special mode where the layout parameters are used
			/// to perform scaling of the surface when it is composited to the
			/// screen.
			/// </remarks>
			public const int FLAG_SCALED = unchecked((int)(0x00004000));

			/// <summary>
			/// Window flag: intended for windows that will often be used when the user is
			/// holding the screen against their face, it will aggressively filter the event
			/// stream to prevent unintended presses in this situation that may not be
			/// desired for a particular window, when such an event stream is detected, the
			/// application will receive a CANCEL motion event to indicate this so applications
			/// can handle this accordingly by taking no action on the event
			/// until the finger is released.
			/// </summary>
			/// <remarks>
			/// Window flag: intended for windows that will often be used when the user is
			/// holding the screen against their face, it will aggressively filter the event
			/// stream to prevent unintended presses in this situation that may not be
			/// desired for a particular window, when such an event stream is detected, the
			/// application will receive a CANCEL motion event to indicate this so applications
			/// can handle this accordingly by taking no action on the event
			/// until the finger is released.
			/// </remarks>
			public const int FLAG_IGNORE_CHEEK_PRESSES = unchecked((int)(0x00008000));

			/// <summary>
			/// Window flag: a special option only for use in combination with
			/// <see cref="FLAG_LAYOUT_IN_SCREEN">FLAG_LAYOUT_IN_SCREEN</see>
			/// .  When requesting layout in the
			/// screen your window may appear on top of or behind screen decorations
			/// such as the status bar.  By also including this flag, the window
			/// manager will report the inset rectangle needed to ensure your
			/// content is not covered by screen decorations.  This flag is normally
			/// set for you by Window as described in
			/// <see cref="Window.setFlags(int, int)">Window.setFlags(int, int)</see>
			/// .
			/// </summary>
			public const int FLAG_LAYOUT_INSET_DECOR = unchecked((int)(0x00010000));

			/// <summary>
			/// Window flag: invert the state of
			/// <see cref="FLAG_NOT_FOCUSABLE">FLAG_NOT_FOCUSABLE</see>
			/// with
			/// respect to how this window interacts with the current method.  That
			/// is, if FLAG_NOT_FOCUSABLE is set and this flag is set, then the
			/// window will behave as if it needs to interact with the input method
			/// and thus be placed behind/away from it; if FLAG_NOT_FOCUSABLE is
			/// not set and this flag is set, then the window will behave as if it
			/// doesn't need to interact with the input method and can be placed
			/// to use more space and cover the input method.
			/// </summary>
			public const int FLAG_ALT_FOCUSABLE_IM = unchecked((int)(0x00020000));

			/// <summary>
			/// Window flag: if you have set
			/// <see cref="FLAG_NOT_TOUCH_MODAL">FLAG_NOT_TOUCH_MODAL</see>
			/// , you
			/// can set this flag to receive a single special MotionEvent with
			/// the action
			/// <see cref="MotionEvent.ACTION_OUTSIDE">MotionEvent.ACTION_OUTSIDE</see>
			/// for
			/// touches that occur outside of your window.  Note that you will not
			/// receive the full down/move/up gesture, only the location of the
			/// first down as an ACTION_OUTSIDE.
			/// </summary>
			public const int FLAG_WATCH_OUTSIDE_TOUCH = unchecked((int)(0x00040000));

			/// <summary>
			/// Window flag: special flag to let windows be shown when the screen
			/// is locked.
			/// </summary>
			/// <remarks>
			/// Window flag: special flag to let windows be shown when the screen
			/// is locked. This will let application windows take precedence over
			/// key guard or any other lock screens. Can be used with
			/// <see cref="FLAG_KEEP_SCREEN_ON">FLAG_KEEP_SCREEN_ON</see>
			/// to turn screen on and display windows
			/// directly before showing the key guard window.  Can be used with
			/// <see cref="FLAG_DISMISS_KEYGUARD">FLAG_DISMISS_KEYGUARD</see>
			/// to automatically fully dismisss
			/// non-secure keyguards.  This flag only applies to the top-most
			/// full-screen window.
			/// </remarks>
			public const int FLAG_SHOW_WHEN_LOCKED = unchecked((int)(0x00080000));

			/// <summary>
			/// Window flag: ask that the system wallpaper be shown behind
			/// your window.
			/// </summary>
			/// <remarks>
			/// Window flag: ask that the system wallpaper be shown behind
			/// your window.  The window surface must be translucent to be able
			/// to actually see the wallpaper behind it; this flag just ensures
			/// that the wallpaper surface will be there if this window actually
			/// has translucent regions.
			/// </remarks>
			public const int FLAG_SHOW_WALLPAPER = unchecked((int)(0x00100000));

			/// <summary>
			/// Window flag: when set as a window is being added or made
			/// visible, once the window has been shown then the system will
			/// poke the power manager's user activity (as if the user had woken
			/// up the device) to turn the screen on.
			/// </summary>
			/// <remarks>
			/// Window flag: when set as a window is being added or made
			/// visible, once the window has been shown then the system will
			/// poke the power manager's user activity (as if the user had woken
			/// up the device) to turn the screen on.
			/// </remarks>
			public const int FLAG_TURN_SCREEN_ON = unchecked((int)(0x00200000));

			/// <summary>
			/// Window flag: when set the window will cause the keyguard to
			/// be dismissed, only if it is not a secure lock keyguard.
			/// </summary>
			/// <remarks>
			/// Window flag: when set the window will cause the keyguard to
			/// be dismissed, only if it is not a secure lock keyguard.  Because such
			/// a keyguard is not needed for security, it will never re-appear if
			/// the user navigates to another window (in contrast to
			/// <see cref="FLAG_SHOW_WHEN_LOCKED">FLAG_SHOW_WHEN_LOCKED</see>
			/// , which will only temporarily
			/// hide both secure and non-secure keyguards but ensure they reappear
			/// when the user moves to another UI that doesn't hide them).
			/// If the keyguard is currently active and is secure (requires an
			/// unlock pattern) than the user will still need to confirm it before
			/// seeing this window, unless
			/// <see cref="FLAG_SHOW_WHEN_LOCKED">FLAG_SHOW_WHEN_LOCKED</see>
			/// has
			/// also been set.
			/// </remarks>
			public const int FLAG_DISMISS_KEYGUARD = unchecked((int)(0x00400000));

			/// <summary>
			/// Window flag: when set the window will accept for touch events
			/// outside of its bounds to be sent to other windows that also
			/// support split touch.
			/// </summary>
			/// <remarks>
			/// Window flag: when set the window will accept for touch events
			/// outside of its bounds to be sent to other windows that also
			/// support split touch.  When this flag is not set, the first pointer
			/// that goes down determines the window to which all subsequent touches
			/// go until all pointers go up.  When this flag is set, each pointer
			/// (not necessarily the first) that goes down determines the window
			/// to which all subsequent touches of that pointer will go until that
			/// pointer goes up thereby enabling touches with multiple pointers
			/// to be split across multiple windows.
			/// </remarks>
			public const int FLAG_SPLIT_TOUCH = unchecked((int)(0x00800000));

			/// <summary><p>Indicates whether this window should be hardware accelerated.</summary>
			/// <remarks>
			/// <p>Indicates whether this window should be hardware accelerated.
			/// Requesting hardware acceleration does not guarantee it will happen.</p>
			/// <p>This flag can be controlled programmatically <em>only</em> to enable
			/// hardware acceleration. To enable hardware acceleration for a given
			/// window programmatically, do the following:</p>
			/// <pre>
			/// Window w = activity.getWindow(); // in Activity's onCreate() for instance
			/// w.setFlags(WindowManager.LayoutParams.FLAG_HARDWARE_ACCELERATED,
			/// WindowManager.LayoutParams.FLAG_HARDWARE_ACCELERATED);
			/// </pre>
			/// <p>It is important to remember that this flag <strong>must</strong>
			/// be set before setting the content view of your activity or dialog.</p>
			/// <p>This flag cannot be used to disable hardware acceleration after it
			/// was enabled in your manifest using
			/// <see cref="android.R.attr.hardwareAccelerated">android.R.attr.hardwareAccelerated
			/// 	</see>
			/// . If you need to selectively
			/// and programmatically disable hardware acceleration (for automated testing
			/// for instance), make sure it is turned off in your manifest and enable it
			/// on your activity or dialog when you need it instead, using the method
			/// described above.</p>
			/// <p>This flag is automatically set by the system if the
			/// <see cref="android.R.attr.hardwareAccelerated">android:hardwareAccelerated</see>
			/// XML attribute is set to true on an activity or on the application.</p>
			/// </remarks>
			public const int FLAG_HARDWARE_ACCELERATED = unchecked((int)(0x01000000));

			/// <summary>
			/// Window flag: Enable touches to slide out of a window into neighboring
			/// windows in mid-gesture instead of being captured for the duration of
			/// the gesture.
			/// </summary>
			/// <remarks>
			/// Window flag: Enable touches to slide out of a window into neighboring
			/// windows in mid-gesture instead of being captured for the duration of
			/// the gesture.
			/// This flag changes the behavior of touch focus for this window only.
			/// Touches can slide out of the window but they cannot necessarily slide
			/// back in (unless the other window with touch focus permits it).
			/// <hide></hide>
			/// </remarks>
			public const int FLAG_SLIPPERY = unchecked((int)(0x04000000));

			/// <summary>
			/// Flag for a window belonging to an activity that responds to
			/// <see cref="KeyEvent.KEYCODE_MENU">KeyEvent.KEYCODE_MENU</see>
			/// and therefore needs a Menu key. For devices where Menu is a physical button this flag is
			/// ignored, but on devices where the Menu key is drawn in software it may be hidden unless
			/// this flag is set.
			/// (Note that Action Bars, when available, are the preferred way to offer additional
			/// functions otherwise accessed via an options menu.)
			/// <hide></hide>
			/// </summary>
			public const int FLAG_NEEDS_MENU_KEY = unchecked((int)(0x08000000));

			/// <summary>
			/// Window flag: *sigh* The lock screen wants to continue running its
			/// animation while it is fading.
			/// </summary>
			/// <remarks>
			/// Window flag: *sigh* The lock screen wants to continue running its
			/// animation while it is fading.  A kind-of hack to allow this.  Maybe
			/// in the future we just make this the default behavior.
			/// <hide></hide>
			/// 
			/// </remarks>
			public const int FLAG_KEEP_SURFACE_WHILE_ANIMATING = unchecked((int)(0x10000000));

			/// <summary>
			/// Window flag: special flag to limit the size of the window to be
			/// original size ([320x480] x density).
			/// </summary>
			/// <remarks>
			/// Window flag: special flag to limit the size of the window to be
			/// original size ([320x480] x density). Used to create window for applications
			/// running under compatibility mode.
			/// <hide></hide>
			/// 
			/// </remarks>
			public const int FLAG_COMPATIBLE_WINDOW = unchecked((int)(0x20000000));

			/// <summary>Window flag: a special option intended for system dialogs.</summary>
			/// <remarks>
			/// Window flag: a special option intended for system dialogs.  When
			/// this flag is set, the window will demand focus unconditionally when
			/// it is created.
			/// <hide></hide>
			/// 
			/// </remarks>
			public const int FLAG_SYSTEM_ERROR = unchecked((int)(0x40000000));

			/// <summary>Various behavioral options/flags.</summary>
			/// <remarks>Various behavioral options/flags.  Default is none.</remarks>
			/// <seealso cref="FLAG_ALLOW_LOCK_WHILE_SCREEN_ON">FLAG_ALLOW_LOCK_WHILE_SCREEN_ON</seealso>
			/// <seealso cref="FLAG_DIM_BEHIND">FLAG_DIM_BEHIND</seealso>
			/// <seealso cref="FLAG_NOT_FOCUSABLE">FLAG_NOT_FOCUSABLE</seealso>
			/// <seealso cref="FLAG_NOT_TOUCHABLE">FLAG_NOT_TOUCHABLE</seealso>
			/// <seealso cref="FLAG_NOT_TOUCH_MODAL">FLAG_NOT_TOUCH_MODAL</seealso>
			/// <seealso cref="FLAG_TOUCHABLE_WHEN_WAKING">FLAG_TOUCHABLE_WHEN_WAKING</seealso>
			/// <seealso cref="FLAG_KEEP_SCREEN_ON">FLAG_KEEP_SCREEN_ON</seealso>
			/// <seealso cref="FLAG_LAYOUT_IN_SCREEN">FLAG_LAYOUT_IN_SCREEN</seealso>
			/// <seealso cref="FLAG_LAYOUT_NO_LIMITS">FLAG_LAYOUT_NO_LIMITS</seealso>
			/// <seealso cref="FLAG_FULLSCREEN">FLAG_FULLSCREEN</seealso>
			/// <seealso cref="FLAG_FORCE_NOT_FULLSCREEN">FLAG_FORCE_NOT_FULLSCREEN</seealso>
			/// <seealso cref="FLAG_DITHER">FLAG_DITHER</seealso>
			/// <seealso cref="FLAG_SECURE">FLAG_SECURE</seealso>
			/// <seealso cref="FLAG_SCALED">FLAG_SCALED</seealso>
			/// <seealso cref="FLAG_IGNORE_CHEEK_PRESSES">FLAG_IGNORE_CHEEK_PRESSES</seealso>
			/// <seealso cref="FLAG_LAYOUT_INSET_DECOR">FLAG_LAYOUT_INSET_DECOR</seealso>
			/// <seealso cref="FLAG_ALT_FOCUSABLE_IM">FLAG_ALT_FOCUSABLE_IM</seealso>
			/// <seealso cref="FLAG_WATCH_OUTSIDE_TOUCH">FLAG_WATCH_OUTSIDE_TOUCH</seealso>
			/// <seealso cref="FLAG_SHOW_WHEN_LOCKED">FLAG_SHOW_WHEN_LOCKED</seealso>
			/// <seealso cref="FLAG_SHOW_WALLPAPER">FLAG_SHOW_WALLPAPER</seealso>
			/// <seealso cref="FLAG_TURN_SCREEN_ON">FLAG_TURN_SCREEN_ON</seealso>
			/// <seealso cref="FLAG_DISMISS_KEYGUARD">FLAG_DISMISS_KEYGUARD</seealso>
			/// <seealso cref="FLAG_SPLIT_TOUCH">FLAG_SPLIT_TOUCH</seealso>
			/// <seealso cref="FLAG_HARDWARE_ACCELERATED">FLAG_HARDWARE_ACCELERATED</seealso>
			public int flags;

			/// <summary>
			/// If the window has requested hardware acceleration, but this is not
			/// allowed in the process it is in, then still render it as if it is
			/// hardware accelerated.
			/// </summary>
			/// <remarks>
			/// If the window has requested hardware acceleration, but this is not
			/// allowed in the process it is in, then still render it as if it is
			/// hardware accelerated.  This is used for the starting preview windows
			/// in the system process, which don't need to have the overhead of
			/// hardware acceleration (they are just a static rendering), but should
			/// be rendered as much to match the actual window of the app even if it
			/// is hardware accelerated.
			/// Even if the window isn't hardware accelerated, still do its rendering
			/// as if it is.
			/// Like
			/// <see cref="FLAG_HARDWARE_ACCELERATED">FLAG_HARDWARE_ACCELERATED</see>
			/// except for trusted system windows
			/// that need hardware acceleration (e.g. LockScreen), where hardware acceleration
			/// is generally disabled. This flag must be specified in addition to
			/// <see cref="FLAG_HARDWARE_ACCELERATED">FLAG_HARDWARE_ACCELERATED</see>
			/// to enable hardware acceleration for system
			/// windows.
			/// </remarks>
			/// <hide></hide>
			public const int PRIVATE_FLAG_FAKE_HARDWARE_ACCELERATED = unchecked((int)(0x00000001
				));

			/// <summary>
			/// In the system process, we globally do not use hardware acceleration
			/// because there are many threads doing UI there and they an conflict.
			/// </summary>
			/// <remarks>
			/// In the system process, we globally do not use hardware acceleration
			/// because there are many threads doing UI there and they an conflict.
			/// If certain parts of the UI that really do want to use hardware
			/// acceleration, this flag can be set to force it.  This is basically
			/// for the lock screen.  Anyone else using it, you are probably wrong.
			/// </remarks>
			/// <hide></hide>
			public const int PRIVATE_FLAG_FORCE_HARDWARE_ACCELERATED = unchecked((int)(0x00000002
				));

			/// <summary>Control flags that are private to the platform.</summary>
			/// <remarks>Control flags that are private to the platform.</remarks>
			/// <hide></hide>
			public int privateFlags;

			/// <summary>
			/// Given a particular set of window manager flags, determine whether
			/// such a window may be a target for an input method when it has
			/// focus.
			/// </summary>
			/// <remarks>
			/// Given a particular set of window manager flags, determine whether
			/// such a window may be a target for an input method when it has
			/// focus.  In particular, this checks the
			/// <see cref="FLAG_NOT_FOCUSABLE">FLAG_NOT_FOCUSABLE</see>
			/// and
			/// <see cref="FLAG_ALT_FOCUSABLE_IM">FLAG_ALT_FOCUSABLE_IM</see>
			/// flags and returns true if the combination of the two corresponds
			/// to a window that needs to be behind the input method so that the
			/// user can type into it.
			/// </remarks>
			/// <param name="flags">The current window manager flags.</param>
			/// <returns>
			/// Returns true if such a window should be behind/interact
			/// with an input method, false if not.
			/// </returns>
			public static bool mayUseInputMethod(int flags)
			{
				switch (flags & (FLAG_NOT_FOCUSABLE | FLAG_ALT_FOCUSABLE_IM))
				{
					case 0:
					case FLAG_NOT_FOCUSABLE | FLAG_ALT_FOCUSABLE_IM:
					{
						return true;
					}
				}
				return false;
			}

			/// <summary>
			/// Mask for
			/// <see cref="softInputMode">softInputMode</see>
			/// of the bits that determine the
			/// desired visibility state of the soft input area for this window.
			/// </summary>
			public const int SOFT_INPUT_MASK_STATE = unchecked((int)(0x0f));

			/// <summary>
			/// Visibility state for
			/// <see cref="softInputMode">softInputMode</see>
			/// : no state has been specified.
			/// </summary>
			public const int SOFT_INPUT_STATE_UNSPECIFIED = 0;

			/// <summary>
			/// Visibility state for
			/// <see cref="softInputMode">softInputMode</see>
			/// : please don't change the state of
			/// the soft input area.
			/// </summary>
			public const int SOFT_INPUT_STATE_UNCHANGED = 1;

			/// <summary>
			/// Visibility state for
			/// <see cref="softInputMode">softInputMode</see>
			/// : please hide any soft input
			/// area when normally appropriate (when the user is navigating
			/// forward to your window).
			/// </summary>
			public const int SOFT_INPUT_STATE_HIDDEN = 2;

			/// <summary>
			/// Visibility state for
			/// <see cref="softInputMode">softInputMode</see>
			/// : please always hide any
			/// soft input area when this window receives focus.
			/// </summary>
			public const int SOFT_INPUT_STATE_ALWAYS_HIDDEN = 3;

			/// <summary>
			/// Visibility state for
			/// <see cref="softInputMode">softInputMode</see>
			/// : please show the soft
			/// input area when normally appropriate (when the user is navigating
			/// forward to your window).
			/// </summary>
			public const int SOFT_INPUT_STATE_VISIBLE = 4;

			/// <summary>
			/// Visibility state for
			/// <see cref="softInputMode">softInputMode</see>
			/// : please always make the
			/// soft input area visible when this window receives input focus.
			/// </summary>
			public const int SOFT_INPUT_STATE_ALWAYS_VISIBLE = 5;

			/// <summary>
			/// Mask for
			/// <see cref="softInputMode">softInputMode</see>
			/// of the bits that determine the
			/// way that the window should be adjusted to accommodate the soft
			/// input window.
			/// </summary>
			public const int SOFT_INPUT_MASK_ADJUST = unchecked((int)(0xf0));

			/// <summary>
			/// Adjustment option for
			/// <see cref="softInputMode">softInputMode</see>
			/// : nothing specified.
			/// The system will try to pick one or
			/// the other depending on the contents of the window.
			/// </summary>
			public const int SOFT_INPUT_ADJUST_UNSPECIFIED = unchecked((int)(0x00));

			/// <summary>
			/// Adjustment option for
			/// <see cref="softInputMode">softInputMode</see>
			/// : set to allow the
			/// window to be resized when an input
			/// method is shown, so that its contents are not covered by the input
			/// method.  This can <em>not</em> be combined with
			/// <see cref="SOFT_INPUT_ADJUST_PAN">SOFT_INPUT_ADJUST_PAN</see>
			/// ; if
			/// neither of these are set, then the system will try to pick one or
			/// the other depending on the contents of the window.
			/// </summary>
			public const int SOFT_INPUT_ADJUST_RESIZE = unchecked((int)(0x10));

			/// <summary>
			/// Adjustment option for
			/// <see cref="softInputMode">softInputMode</see>
			/// : set to have a window
			/// pan when an input method is
			/// shown, so it doesn't need to deal with resizing but just panned
			/// by the framework to ensure the current input focus is visible.  This
			/// can <em>not</em> be combined with
			/// <see cref="SOFT_INPUT_ADJUST_RESIZE">SOFT_INPUT_ADJUST_RESIZE</see>
			/// ; if
			/// neither of these are set, then the system will try to pick one or
			/// the other depending on the contents of the window.
			/// </summary>
			public const int SOFT_INPUT_ADJUST_PAN = unchecked((int)(0x20));

			/// <summary>
			/// Adjustment option for
			/// <see cref="softInputMode">softInputMode</see>
			/// : set to have a window
			/// not adjust for a shown input method.  The window will not be resized,
			/// and it will not be panned to make its focus visible.
			/// </summary>
			public const int SOFT_INPUT_ADJUST_NOTHING = unchecked((int)(0x30));

			/// <summary>
			/// Bit for
			/// <see cref="softInputMode">softInputMode</see>
			/// : set when the user has navigated
			/// forward to the window.  This is normally set automatically for
			/// you by the system, though you may want to set it in certain cases
			/// when you are displaying a window yourself.  This flag will always
			/// be cleared automatically after the window is displayed.
			/// </summary>
			public const int SOFT_INPUT_IS_FORWARD_NAVIGATION = unchecked((int)(0x100));

			/// <summary>Desired operating mode for any soft input area.</summary>
			/// <remarks>
			/// Desired operating mode for any soft input area.  May be any combination
			/// of:
			/// <ul>
			/// <li> One of the visibility states
			/// <see cref="SOFT_INPUT_STATE_UNSPECIFIED">SOFT_INPUT_STATE_UNSPECIFIED</see>
			/// ,
			/// <see cref="SOFT_INPUT_STATE_UNCHANGED">SOFT_INPUT_STATE_UNCHANGED</see>
			/// ,
			/// <see cref="SOFT_INPUT_STATE_HIDDEN">SOFT_INPUT_STATE_HIDDEN</see>
			/// ,
			/// <see cref="SOFT_INPUT_STATE_ALWAYS_VISIBLE">SOFT_INPUT_STATE_ALWAYS_VISIBLE</see>
			/// , or
			/// <see cref="SOFT_INPUT_STATE_VISIBLE">SOFT_INPUT_STATE_VISIBLE</see>
			/// .
			/// <li> One of the adjustment options
			/// <see cref="SOFT_INPUT_ADJUST_UNSPECIFIED">SOFT_INPUT_ADJUST_UNSPECIFIED</see>
			/// ,
			/// <see cref="SOFT_INPUT_ADJUST_RESIZE">SOFT_INPUT_ADJUST_RESIZE</see>
			/// , or
			/// <see cref="SOFT_INPUT_ADJUST_PAN">SOFT_INPUT_ADJUST_PAN</see>
			/// .
			/// </remarks>
			public int softInputMode;

			/// <summary>
			/// Placement of window within the screen as per
			/// <see cref="Gravity">Gravity</see>
			/// .  Both
			/// <see cref="Gravity.apply(int, int, int, android.graphics.Rect, int, int, android.graphics.Rect)
			/// 	">Gravity.apply</see>
			/// and
			/// <see cref="Gravity.applyDisplay(int, android.graphics.Rect, android.graphics.Rect)
			/// 	">Gravity.applyDisplay</see>
			/// are used during window layout, with this value
			/// given as the desired gravity.  For example you can specify
			/// <see cref="Gravity.DISPLAY_CLIP_HORIZONTAL">Gravity.DISPLAY_CLIP_HORIZONTAL</see>
			/// and
			/// <see cref="Gravity.DISPLAY_CLIP_VERTICAL">Gravity.DISPLAY_CLIP_VERTICAL</see>
			/// here
			/// to control the behavior of
			/// <see cref="Gravity.applyDisplay(int, android.graphics.Rect, android.graphics.Rect)
			/// 	">Gravity.applyDisplay</see>
			/// .
			/// </summary>
			/// <seealso cref="Gravity">Gravity</seealso>
			public int gravity;

			/// <summary>
			/// The horizontal margin, as a percentage of the container's width,
			/// between the container and the widget.
			/// </summary>
			/// <remarks>
			/// The horizontal margin, as a percentage of the container's width,
			/// between the container and the widget.  See
			/// <see cref="Gravity.apply(int, int, int, android.graphics.Rect, int, int, android.graphics.Rect)
			/// 	">Gravity.apply</see>
			/// for how this is used.  This
			/// field is added with
			/// <see cref="x">x</see>
			/// to supply the <var>xAdj</var> parameter.
			/// </remarks>
			public float horizontalMargin;

			/// <summary>
			/// The vertical margin, as a percentage of the container's height,
			/// between the container and the widget.
			/// </summary>
			/// <remarks>
			/// The vertical margin, as a percentage of the container's height,
			/// between the container and the widget.  See
			/// <see cref="Gravity.apply(int, int, int, android.graphics.Rect, int, int, android.graphics.Rect)
			/// 	">Gravity.apply</see>
			/// for how this is used.  This
			/// field is added with
			/// <see cref="y">y</see>
			/// to supply the <var>yAdj</var> parameter.
			/// </remarks>
			public float verticalMargin;

			/// <summary>The desired bitmap format.</summary>
			/// <remarks>
			/// The desired bitmap format.  May be one of the constants in
			/// <see cref="android.graphics.PixelFormat">android.graphics.PixelFormat</see>
			/// .  Default is OPAQUE.
			/// </remarks>
			public int format;

			/// <summary>A style resource defining the animations to use for this window.</summary>
			/// <remarks>
			/// A style resource defining the animations to use for this window.
			/// This must be a system resource; it can not be an application resource
			/// because the window manager does not have access to applications.
			/// </remarks>
			public int windowAnimations;

			/// <summary>An alpha value to apply to this entire window.</summary>
			/// <remarks>
			/// An alpha value to apply to this entire window.
			/// An alpha of 1.0 means fully opaque and 0.0 means fully transparent
			/// </remarks>
			public float alpha = 1.0f;

			/// <summary>
			/// When
			/// <see cref="FLAG_DIM_BEHIND">FLAG_DIM_BEHIND</see>
			/// is set, this is the amount of dimming
			/// to apply.  Range is from 1.0 for completely opaque to 0.0 for no
			/// dim.
			/// </summary>
			public float dimAmount = 1.0f;

			/// <summary>
			/// Default value for
			/// <see cref="screenBrightness">screenBrightness</see>
			/// and
			/// <see cref="buttonBrightness">buttonBrightness</see>
			/// indicating that the brightness value is not overridden for this window
			/// and normal brightness policy should be used.
			/// </summary>
			public const float BRIGHTNESS_OVERRIDE_NONE = -1.0f;

			/// <summary>
			/// Value for
			/// <see cref="screenBrightness">screenBrightness</see>
			/// and
			/// <see cref="buttonBrightness">buttonBrightness</see>
			/// indicating that the screen or button backlight brightness should be set
			/// to the lowest value when this window is in front.
			/// </summary>
			public const float BRIGHTNESS_OVERRIDE_OFF = 0.0f;

			/// <summary>
			/// Value for
			/// <see cref="screenBrightness">screenBrightness</see>
			/// and
			/// <see cref="buttonBrightness">buttonBrightness</see>
			/// indicating that the screen or button backlight brightness should be set
			/// to the hightest value when this window is in front.
			/// </summary>
			public const float BRIGHTNESS_OVERRIDE_FULL = 1.0f;

			/// <summary>
			/// This can be used to override the user's preferred brightness of
			/// the screen.
			/// </summary>
			/// <remarks>
			/// This can be used to override the user's preferred brightness of
			/// the screen.  A value of less than 0, the default, means to use the
			/// preferred screen brightness.  0 to 1 adjusts the brightness from
			/// dark to full bright.
			/// </remarks>
			public float screenBrightness = BRIGHTNESS_OVERRIDE_NONE;

			/// <summary>
			/// This can be used to override the standard behavior of the button and
			/// keyboard backlights.
			/// </summary>
			/// <remarks>
			/// This can be used to override the standard behavior of the button and
			/// keyboard backlights.  A value of less than 0, the default, means to
			/// use the standard backlight behavior.  0 to 1 adjusts the brightness
			/// from dark to full bright.
			/// </remarks>
			public float buttonBrightness = BRIGHTNESS_OVERRIDE_NONE;

			/// <summary>Identifier for this window.</summary>
			/// <remarks>
			/// Identifier for this window.  This will usually be filled in for
			/// you.
			/// </remarks>
			public android.os.IBinder token = null;

			/// <summary>Name of the package owning this window.</summary>
			/// <remarks>Name of the package owning this window.</remarks>
			public string packageName = null;

			/// <summary>Specific orientation value for a window.</summary>
			/// <remarks>
			/// Specific orientation value for a window.
			/// May be any of the same values allowed
			/// for
			/// <see cref="android.content.pm.ActivityInfo.screenOrientation">android.content.pm.ActivityInfo.screenOrientation
			/// 	</see>
			/// .
			/// If not set, a default value of
			/// <see cref="android.content.pm.ActivityInfo.SCREEN_ORIENTATION_UNSPECIFIED">android.content.pm.ActivityInfo.SCREEN_ORIENTATION_UNSPECIFIED
			/// 	</see>
			/// 
			/// will be used.
			/// </remarks>
			public int screenOrientation = android.content.pm.ActivityInfo.SCREEN_ORIENTATION_UNSPECIFIED;

			/// <summary>Control the visibility of the status bar.</summary>
			/// <remarks>Control the visibility of the status bar.</remarks>
			/// <seealso cref="View.STATUS_BAR_VISIBLE">View.STATUS_BAR_VISIBLE</seealso>
			/// <seealso cref="View.STATUS_BAR_HIDDEN">View.STATUS_BAR_HIDDEN</seealso>
			public int systemUiVisibility;

			/// <hide>
			/// The ui visibility as requested by the views in this hierarchy.
			/// the combined value should be systemUiVisibility | subtreeSystemUiVisibility.
			/// </hide>
			public int subtreeSystemUiVisibility;

			/// <summary>Get callbacks about the system ui visibility changing.</summary>
			/// <remarks>
			/// Get callbacks about the system ui visibility changing.
			/// TODO: Maybe there should be a bitfield of optional callbacks that we need.
			/// </remarks>
			/// <hide></hide>
			public bool hasSystemUiListeners;

			/// <summary>When this window has focus, disable touch pad pointer gesture processing.
			/// 	</summary>
			/// <remarks>
			/// When this window has focus, disable touch pad pointer gesture processing.
			/// The window will receive raw position updates from the touch pad instead
			/// of pointer movements and synthetic touch events.
			/// </remarks>
			/// <hide></hide>
			public const int INPUT_FEATURE_DISABLE_POINTER_GESTURES = unchecked((int)(0x00000001
				));

			/// <summary>Does not construct an input channel for this window.</summary>
			/// <remarks>
			/// Does not construct an input channel for this window.  The channel will therefore
			/// be incapable of receiving input.
			/// </remarks>
			/// <hide></hide>
			public const int INPUT_FEATURE_NO_INPUT_CHANNEL = unchecked((int)(0x00000002));

			/// <summary>Control special features of the input subsystem.</summary>
			/// <remarks>Control special features of the input subsystem.</remarks>
			/// <seealso cref="#INPUT_FEATURE_DISABLE_TOUCH_PAD_GESTURES">#INPUT_FEATURE_DISABLE_TOUCH_PAD_GESTURES
			/// 	</seealso>
			/// <seealso cref="INPUT_FEATURE_NO_INPUT_CHANNEL">INPUT_FEATURE_NO_INPUT_CHANNEL</seealso>
			/// <hide></hide>
			public int inputFeatures;

			internal LayoutParams() : base(android.view.ViewGroup.LayoutParams.MATCH_PARENT, 
				android.view.ViewGroup.LayoutParams.MATCH_PARENT)
			{
				type = TYPE_APPLICATION;
				format = android.graphics.PixelFormat.OPAQUE;
			}

			public LayoutParams(int _type) : base(android.view.ViewGroup.LayoutParams.MATCH_PARENT
				, android.view.ViewGroup.LayoutParams.MATCH_PARENT)
			{
				type = _type;
				format = android.graphics.PixelFormat.OPAQUE;
			}

			public LayoutParams(int _type, int _flags) : base(android.view.ViewGroup.LayoutParams
				.MATCH_PARENT, android.view.ViewGroup.LayoutParams.MATCH_PARENT)
			{
				type = _type;
				flags = _flags;
				format = android.graphics.PixelFormat.OPAQUE;
			}

			public LayoutParams(int _type, int _flags, int _format) : base(android.view.ViewGroup
				.LayoutParams.MATCH_PARENT, android.view.ViewGroup.LayoutParams.MATCH_PARENT)
			{
				type = _type;
				flags = _flags;
				format = _format;
			}

			public LayoutParams(int w, int h, int _type, int _flags, int _format) : base(w, h
				)
			{
				type = _type;
				flags = _flags;
				format = _format;
			}

			public LayoutParams(int w, int h, int xpos, int ypos, int _type, int _flags, int 
				_format) : base(w, h)
			{
				x = xpos;
				y = ypos;
				type = _type;
				flags = _flags;
				format = _format;
			}

			public void setTitle(java.lang.CharSequence title)
			{
				if (null == title)
				{
					title = java.lang.CharSequenceProxy.Wrap(string.Empty);
				}
				mTitle = android.text.TextUtils.stringOrSpannedString(title);
			}

			public java.lang.CharSequence getTitle()
			{
				return mTitle;
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
			public virtual int describeContents()
			{
				return 0;
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
			public virtual void writeToParcel(android.os.Parcel @out, int parcelableFlags)
			{
				@out.writeInt(width);
				@out.writeInt(height);
				@out.writeInt(x);
				@out.writeInt(y);
				@out.writeInt(type);
				@out.writeInt(flags);
				@out.writeInt(privateFlags);
				@out.writeInt(softInputMode);
				@out.writeInt(gravity);
				@out.writeFloat(horizontalMargin);
				@out.writeFloat(verticalMargin);
				@out.writeInt(format);
				@out.writeInt(windowAnimations);
				@out.writeFloat(alpha);
				@out.writeFloat(dimAmount);
				@out.writeFloat(screenBrightness);
				@out.writeFloat(buttonBrightness);
				@out.writeStrongBinder(token);
				@out.writeString(packageName);
				android.text.TextUtils.writeToParcel(mTitle, @out, parcelableFlags);
				@out.writeInt(screenOrientation);
				@out.writeInt(systemUiVisibility);
				@out.writeInt(subtreeSystemUiVisibility);
				@out.writeInt(hasSystemUiListeners ? 1 : 0);
				@out.writeInt(inputFeatures);
			}

			private sealed class _Creator_1207 : android.os.ParcelableClass.Creator<android.view.WindowManagerClass
				.LayoutParams>
			{
				public _Creator_1207()
				{
				}

				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.view.WindowManagerClass.LayoutParams createFromParcel(android.os.Parcel
					 @in)
				{
					return new android.view.WindowManagerClass.LayoutParams(@in);
				}

				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.view.WindowManagerClass.LayoutParams[] newArray(int size)
				{
					return new android.view.WindowManagerClass.LayoutParams[size];
				}
			}

			public static readonly android.os.ParcelableClass.Creator<android.view.WindowManagerClass
				.LayoutParams> CREATOR = new _Creator_1207();

			public LayoutParams(android.os.Parcel @in)
			{
				width = @in.readInt();
				height = @in.readInt();
				x = @in.readInt();
				y = @in.readInt();
				type = @in.readInt();
				flags = @in.readInt();
				privateFlags = @in.readInt();
				softInputMode = @in.readInt();
				gravity = @in.readInt();
				horizontalMargin = @in.readFloat();
				verticalMargin = @in.readFloat();
				format = @in.readInt();
				windowAnimations = @in.readInt();
				alpha = @in.readFloat();
				dimAmount = @in.readFloat();
				screenBrightness = @in.readFloat();
				buttonBrightness = @in.readFloat();
				token = @in.readStrongBinder();
				packageName = @in.readString();
				mTitle = android.text.TextUtils.CHAR_SEQUENCE_CREATOR.createFromParcel(@in);
				screenOrientation = @in.readInt();
				systemUiVisibility = @in.readInt();
				subtreeSystemUiVisibility = @in.readInt();
				hasSystemUiListeners = @in.readInt() != 0;
				inputFeatures = @in.readInt();
			}

			public const int LAYOUT_CHANGED = 1 << 0;

			public const int TYPE_CHANGED = 1 << 1;

			public const int FLAGS_CHANGED = 1 << 2;

			public const int FORMAT_CHANGED = 1 << 3;

			public const int ANIMATION_CHANGED = 1 << 4;

			public const int DIM_AMOUNT_CHANGED = 1 << 5;

			public const int TITLE_CHANGED = 1 << 6;

			public const int ALPHA_CHANGED = 1 << 7;

			public const int MEMORY_TYPE_CHANGED = 1 << 8;

			public const int SOFT_INPUT_MODE_CHANGED = 1 << 9;

			public const int SCREEN_ORIENTATION_CHANGED = 1 << 10;

			public const int SCREEN_BRIGHTNESS_CHANGED = 1 << 11;

			/// <summary>
			/// <hide></hide>
			/// 
			/// </summary>
			public const int BUTTON_BRIGHTNESS_CHANGED = 1 << 12;

			/// <summary>
			/// <hide></hide>
			/// 
			/// </summary>
			public const int SYSTEM_UI_VISIBILITY_CHANGED = 1 << 13;

			/// <summary>
			/// <hide></hide>
			/// 
			/// </summary>
			public const int SYSTEM_UI_LISTENER_CHANGED = 1 << 14;

			/// <summary>
			/// <hide></hide>
			/// 
			/// </summary>
			public const int INPUT_FEATURES_CHANGED = 1 << 15;

			/// <summary>
			/// <hide></hide>
			/// 
			/// </summary>
			public const int PRIVATE_FLAGS_CHANGED = 1 << 16;

			/// <summary>
			/// <hide></hide>
			/// 
			/// </summary>
			public const int EVERYTHING_CHANGED = unchecked((int)(0xffffffff));

			private int[] mCompatibilityParamsBackup = null;

			public int copyFrom(android.view.WindowManagerClass.LayoutParams o)
			{
				int changes = 0;
				if (width != o.width)
				{
					width = o.width;
					changes |= LAYOUT_CHANGED;
				}
				if (height != o.height)
				{
					height = o.height;
					changes |= LAYOUT_CHANGED;
				}
				if (x != o.x)
				{
					x = o.x;
					changes |= LAYOUT_CHANGED;
				}
				if (y != o.y)
				{
					y = o.y;
					changes |= LAYOUT_CHANGED;
				}
				if (horizontalWeight != o.horizontalWeight)
				{
					horizontalWeight = o.horizontalWeight;
					changes |= LAYOUT_CHANGED;
				}
				if (verticalWeight != o.verticalWeight)
				{
					verticalWeight = o.verticalWeight;
					changes |= LAYOUT_CHANGED;
				}
				if (horizontalMargin != o.horizontalMargin)
				{
					horizontalMargin = o.horizontalMargin;
					changes |= LAYOUT_CHANGED;
				}
				if (verticalMargin != o.verticalMargin)
				{
					verticalMargin = o.verticalMargin;
					changes |= LAYOUT_CHANGED;
				}
				if (type != o.type)
				{
					type = o.type;
					changes |= TYPE_CHANGED;
				}
				if (flags != o.flags)
				{
					flags = o.flags;
					changes |= FLAGS_CHANGED;
				}
				if (privateFlags != o.privateFlags)
				{
					privateFlags = o.privateFlags;
					changes |= PRIVATE_FLAGS_CHANGED;
				}
				if (softInputMode != o.softInputMode)
				{
					softInputMode = o.softInputMode;
					changes |= SOFT_INPUT_MODE_CHANGED;
				}
				if (gravity != o.gravity)
				{
					gravity = o.gravity;
					changes |= LAYOUT_CHANGED;
				}
				if (format != o.format)
				{
					format = o.format;
					changes |= FORMAT_CHANGED;
				}
				if (windowAnimations != o.windowAnimations)
				{
					windowAnimations = o.windowAnimations;
					changes |= ANIMATION_CHANGED;
				}
				if (token == null)
				{
					token = o.token;
				}
				if (packageName == null)
				{
					packageName = o.packageName;
				}
				if (!mTitle.Equals(o.mTitle))
				{
					mTitle = o.mTitle;
					changes |= TITLE_CHANGED;
				}
				if (alpha != o.alpha)
				{
					alpha = o.alpha;
					changes |= ALPHA_CHANGED;
				}
				if (dimAmount != o.dimAmount)
				{
					dimAmount = o.dimAmount;
					changes |= DIM_AMOUNT_CHANGED;
				}
				if (screenBrightness != o.screenBrightness)
				{
					screenBrightness = o.screenBrightness;
					changes |= SCREEN_BRIGHTNESS_CHANGED;
				}
				if (buttonBrightness != o.buttonBrightness)
				{
					buttonBrightness = o.buttonBrightness;
					changes |= BUTTON_BRIGHTNESS_CHANGED;
				}
				if (screenOrientation != o.screenOrientation)
				{
					screenOrientation = o.screenOrientation;
					changes |= SCREEN_ORIENTATION_CHANGED;
				}
				if (systemUiVisibility != o.systemUiVisibility || subtreeSystemUiVisibility != o.
					subtreeSystemUiVisibility)
				{
					systemUiVisibility = o.systemUiVisibility;
					subtreeSystemUiVisibility = o.subtreeSystemUiVisibility;
					changes |= SYSTEM_UI_VISIBILITY_CHANGED;
				}
				if (hasSystemUiListeners != o.hasSystemUiListeners)
				{
					hasSystemUiListeners = o.hasSystemUiListeners;
					changes |= SYSTEM_UI_LISTENER_CHANGED;
				}
				if (inputFeatures != o.inputFeatures)
				{
					inputFeatures = o.inputFeatures;
					changes |= INPUT_FEATURES_CHANGED;
				}
				return changes;
			}

			[Sharpen.OverridesMethod(@"android.view.ViewGroup.LayoutParams")]
			public override string debug(string output)
			{
				output += "Contents of " + this + ":";
				android.util.Log.d("Debug", output);
				output = base.debug(string.Empty);
				android.util.Log.d("Debug", output);
				android.util.Log.d("Debug", string.Empty);
				android.util.Log.d("Debug", "WindowManager.LayoutParams={title=" + mTitle + "}");
				return string.Empty;
			}

			/// <summary>Scale the layout params' coordinates and size.</summary>
			/// <remarks>Scale the layout params' coordinates and size.</remarks>
			/// <hide></hide>
			public virtual void scale(float scale_1)
			{
				x = (int)(x * scale_1 + 0.5f);
				y = (int)(y * scale_1 + 0.5f);
				if (width > 0)
				{
					width = (int)(width * scale_1 + 0.5f);
				}
				if (height > 0)
				{
					height = (int)(height * scale_1 + 0.5f);
				}
			}

			/// <summary>Backup the layout parameters used in compatibility mode.</summary>
			/// <remarks>Backup the layout parameters used in compatibility mode.</remarks>
			/// <seealso cref="restore()">restore()</seealso>
			internal virtual void backup()
			{
				int[] backup_1 = mCompatibilityParamsBackup;
				if (backup_1 == null)
				{
					backup_1 = mCompatibilityParamsBackup = new int[4];
				}
				backup_1[0] = x;
				backup_1[1] = y;
				backup_1[2] = width;
				backup_1[3] = height;
			}

			/// <summary>Restore the layout params' coordinates, size and gravity</summary>
			/// <seealso cref="backup()">backup()</seealso>
			internal virtual void restore()
			{
				int[] backup_1 = mCompatibilityParamsBackup;
				if (backup_1 != null)
				{
					x = backup_1[0];
					y = backup_1[1];
					width = backup_1[2];
					height = backup_1[3];
				}
			}

			private java.lang.CharSequence mTitle = java.lang.CharSequenceProxy.Wrap(string.Empty
				);
		}
	}
}

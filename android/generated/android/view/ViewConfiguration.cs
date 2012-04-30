using Sharpen;

namespace android.view
{
	/// <summary>Contains methods to standard constants used in the UI for timeouts, sizes, and distances.
	/// 	</summary>
	/// <remarks>Contains methods to standard constants used in the UI for timeouts, sizes, and distances.
	/// 	</remarks>
	[Sharpen.Sharpened]
	public partial class ViewConfiguration
	{
		/// <summary>Expected bit depth of the display panel.</summary>
		/// <remarks>Expected bit depth of the display panel.</remarks>
		/// <hide></hide>
		public const float PANEL_BIT_DEPTH = 24;

		/// <summary>Minimum alpha required for a view to draw.</summary>
		/// <remarks>Minimum alpha required for a view to draw.</remarks>
		/// <hide></hide>
		public const float ALPHA_THRESHOLD = 0.5f / PANEL_BIT_DEPTH;

		/// <hide></hide>
		public const float ALPHA_THRESHOLD_INT = unchecked((int)(0x7f)) / PANEL_BIT_DEPTH;

		/// <summary>
		/// Defines the width of the horizontal scrollbar and the height of the vertical scrollbar in
		/// pixels
		/// </summary>
		internal const int SCROLL_BAR_SIZE = 10;

		/// <summary>Duration of the fade when scrollbars fade away in milliseconds</summary>
		internal const int SCROLL_BAR_FADE_DURATION = 250;

		/// <summary>Default delay before the scrollbars fade in milliseconds</summary>
		internal const int SCROLL_BAR_DEFAULT_DELAY = 300;

		/// <summary>Defines the length of the fading edges in pixels</summary>
		internal const int FADING_EDGE_LENGTH = 12;

		/// <summary>
		/// Defines the duration in milliseconds of the pressed state in child
		/// components.
		/// </summary>
		/// <remarks>
		/// Defines the duration in milliseconds of the pressed state in child
		/// components.
		/// </remarks>
		internal const int PRESSED_STATE_DURATION = 125;

		/// <summary>
		/// Defines the default duration in milliseconds before a press turns into
		/// a long press
		/// </summary>
		internal const int DEFAULT_LONG_PRESS_TIMEOUT = 500;

		/// <summary>Defines the time between successive key repeats in milliseconds.</summary>
		/// <remarks>Defines the time between successive key repeats in milliseconds.</remarks>
		internal const int KEY_REPEAT_DELAY = 50;

		/// <summary>
		/// Defines the duration in milliseconds a user needs to hold down the
		/// appropriate button to bring up the global actions dialog (power off,
		/// lock screen, etc).
		/// </summary>
		/// <remarks>
		/// Defines the duration in milliseconds a user needs to hold down the
		/// appropriate button to bring up the global actions dialog (power off,
		/// lock screen, etc).
		/// </remarks>
		internal const int GLOBAL_ACTIONS_KEY_TIMEOUT = 500;

		/// <summary>
		/// Defines the duration in milliseconds we will wait to see if a touch event
		/// is a tap or a scroll.
		/// </summary>
		/// <remarks>
		/// Defines the duration in milliseconds we will wait to see if a touch event
		/// is a tap or a scroll. If the user does not move within this interval, it is
		/// considered to be a tap.
		/// </remarks>
		internal const int TAP_TIMEOUT = 180;

		/// <summary>
		/// Defines the duration in milliseconds we will wait to see if a touch event
		/// is a jump tap.
		/// </summary>
		/// <remarks>
		/// Defines the duration in milliseconds we will wait to see if a touch event
		/// is a jump tap. If the user does not complete the jump tap within this interval, it is
		/// considered to be a tap.
		/// </remarks>
		internal const int JUMP_TAP_TIMEOUT = 500;

		/// <summary>
		/// Defines the duration in milliseconds between the first tap's up event and
		/// the second tap's down event for an interaction to be considered a
		/// double-tap.
		/// </summary>
		/// <remarks>
		/// Defines the duration in milliseconds between the first tap's up event and
		/// the second tap's down event for an interaction to be considered a
		/// double-tap.
		/// </remarks>
		internal const int DOUBLE_TAP_TIMEOUT = 300;

		/// <summary>
		/// Defines the maximum duration in milliseconds between a touch pad
		/// touch and release for a given touch to be considered a tap (click) as
		/// opposed to a hover movement gesture.
		/// </summary>
		/// <remarks>
		/// Defines the maximum duration in milliseconds between a touch pad
		/// touch and release for a given touch to be considered a tap (click) as
		/// opposed to a hover movement gesture.
		/// </remarks>
		internal const int HOVER_TAP_TIMEOUT = 150;

		/// <summary>
		/// Defines the maximum distance in pixels that a touch pad touch can move
		/// before being released for it to be considered a tap (click) as opposed
		/// to a hover movement gesture.
		/// </summary>
		/// <remarks>
		/// Defines the maximum distance in pixels that a touch pad touch can move
		/// before being released for it to be considered a tap (click) as opposed
		/// to a hover movement gesture.
		/// </remarks>
		internal const int HOVER_TAP_SLOP = 20;

		/// <summary>
		/// Defines the duration in milliseconds we want to display zoom controls in response
		/// to a user panning within an application.
		/// </summary>
		/// <remarks>
		/// Defines the duration in milliseconds we want to display zoom controls in response
		/// to a user panning within an application.
		/// </remarks>
		internal const int ZOOM_CONTROLS_TIMEOUT = 3000;

		/// <summary>Inset in pixels to look for touchable content when the user touches the edge of the screen
		/// 	</summary>
		internal const int EDGE_SLOP = 12;

		/// <summary>Distance a touch can wander before we think the user is scrolling in pixels
		/// 	</summary>
		internal const int TOUCH_SLOP = 16;

		/// <summary>
		/// Distance a touch can wander before we think the user is attempting a paged scroll
		/// (in dips)
		/// </summary>
		internal const int PAGING_TOUCH_SLOP = TOUCH_SLOP * 2;

		/// <summary>Distance between the first touch and second touch to still be considered a double tap
		/// 	</summary>
		internal const int DOUBLE_TAP_SLOP = 100;

		/// <summary>
		/// Distance a touch needs to be outside of a window's bounds for it to
		/// count as outside for purposes of dismissing the window.
		/// </summary>
		/// <remarks>
		/// Distance a touch needs to be outside of a window's bounds for it to
		/// count as outside for purposes of dismissing the window.
		/// </remarks>
		internal const int WINDOW_TOUCH_SLOP = 16;

		/// <summary>Minimum velocity to initiate a fling, as measured in pixels per second</summary>
		internal const int MINIMUM_FLING_VELOCITY = 50;

		/// <summary>Maximum velocity to initiate a fling, as measured in pixels per second</summary>
		internal const int MAXIMUM_FLING_VELOCITY = 8000;

		/// <summary>
		/// Distance between a touch up event denoting the end of a touch exploration
		/// gesture and the touch up event of a subsequent tap for the latter tap to be
		/// considered as a tap i.e.
		/// </summary>
		/// <remarks>
		/// Distance between a touch up event denoting the end of a touch exploration
		/// gesture and the touch up event of a subsequent tap for the latter tap to be
		/// considered as a tap i.e. to perform a click.
		/// </remarks>
		internal const int TOUCH_EXPLORATION_TAP_SLOP = 80;

		/// <summary>Delay before dispatching a recurring accessibility event in milliseconds.
		/// 	</summary>
		/// <remarks>
		/// Delay before dispatching a recurring accessibility event in milliseconds.
		/// This delay guarantees that a recurring event will be send at most once
		/// during the
		/// <see cref="SEND_RECURRING_ACCESSIBILITY_EVENTS_INTERVAL_MILLIS">SEND_RECURRING_ACCESSIBILITY_EVENTS_INTERVAL_MILLIS
		/// 	</see>
		/// time
		/// frame.
		/// </remarks>
		internal const long SEND_RECURRING_ACCESSIBILITY_EVENTS_INTERVAL_MILLIS = 400;

		/// <summary>The maximum size of View's drawing cache, expressed in bytes.</summary>
		/// <remarks>
		/// The maximum size of View's drawing cache, expressed in bytes. This size
		/// should be at least equal to the size of the screen in ARGB888 format.
		/// </remarks>
		[System.Obsolete]
		internal const int MAXIMUM_DRAWING_CACHE_SIZE = 480 * 800 * 4;

		/// <summary>The coefficient of friction applied to flings/scrolls.</summary>
		/// <remarks>The coefficient of friction applied to flings/scrolls.</remarks>
		internal const float SCROLL_FRICTION = 0.015f;

		/// <summary>Max distance to overscroll for edge effects</summary>
		internal const int OVERSCROLL_DISTANCE = 0;

		/// <summary>Max distance to overfling for edge effects</summary>
		internal const int OVERFLING_DISTANCE = 6;

		private readonly int mEdgeSlop;

		private readonly int mFadingEdgeLength;

		private readonly int mMinimumFlingVelocity;

		private readonly int mMaximumFlingVelocity;

		private readonly int mScrollbarSize;

		private readonly int mTouchSlop;

		private readonly int mPagingTouchSlop;

		private readonly int mDoubleTapSlop;

		private readonly int mScaledTouchExplorationTapSlop;

		private readonly int mWindowTouchSlop;

		private readonly int mMaximumDrawingCacheSize;

		private readonly int mOverscrollDistance;

		private readonly int mOverflingDistance;

		private readonly bool mFadingMarqueeEnabled;

		private bool sHasPermanentMenuKey;

		private bool sHasPermanentMenuKeySet;

		internal static readonly android.util.SparseArray<android.view.ViewConfiguration>
			 sConfigurations = new android.util.SparseArray<android.view.ViewConfiguration>(
			2);

		[System.ObsoleteAttribute(@"Use get(android.content.Context) instead.")]
		public ViewConfiguration()
		{
			// ARGB8888
			mEdgeSlop = EDGE_SLOP;
			mFadingEdgeLength = FADING_EDGE_LENGTH;
			mMinimumFlingVelocity = MINIMUM_FLING_VELOCITY;
			mMaximumFlingVelocity = MAXIMUM_FLING_VELOCITY;
			mScrollbarSize = SCROLL_BAR_SIZE;
			mTouchSlop = TOUCH_SLOP;
			mPagingTouchSlop = PAGING_TOUCH_SLOP;
			mDoubleTapSlop = DOUBLE_TAP_SLOP;
			mScaledTouchExplorationTapSlop = TOUCH_EXPLORATION_TAP_SLOP;
			mWindowTouchSlop = WINDOW_TOUCH_SLOP;
			//noinspection deprecation
			mMaximumDrawingCacheSize = MAXIMUM_DRAWING_CACHE_SIZE;
			mOverscrollDistance = OVERSCROLL_DISTANCE;
			mOverflingDistance = OVERFLING_DISTANCE;
			mFadingMarqueeEnabled = true;
		}

		// Size of the screen in bytes, in ARGB_8888 format
		/// <summary>Returns a configuration for the specified context.</summary>
		/// <remarks>
		/// Returns a configuration for the specified context. The configuration depends on
		/// various parameters of the context, like the dimension of the display or the
		/// density of the display.
		/// </remarks>
		/// <param name="context">The application context used to initialize the view configuration.
		/// 	</param>
		public static android.view.ViewConfiguration get(android.content.Context context)
		{
			android.util.DisplayMetrics metrics = context.getResources().getDisplayMetrics();
			int density = (int)(100.0f * metrics.density);
			android.view.ViewConfiguration configuration = sConfigurations.get(density);
			if (configuration == null)
			{
				configuration = new android.view.ViewConfiguration(context);
				sConfigurations.put(density, configuration);
			}
			return configuration;
		}

		/// <returns>
		/// The width of the horizontal scrollbar and the height of the vertical
		/// scrollbar in pixels
		/// </returns>
		[System.ObsoleteAttribute(@"Use getScaledScrollBarSize() instead.")]
		public static int getScrollBarSize()
		{
			return SCROLL_BAR_SIZE;
		}

		/// <returns>
		/// The width of the horizontal scrollbar and the height of the vertical
		/// scrollbar in pixels
		/// </returns>
		public virtual int getScaledScrollBarSize()
		{
			return mScrollbarSize;
		}

		/// <returns>Duration of the fade when scrollbars fade away in milliseconds</returns>
		public static int getScrollBarFadeDuration()
		{
			return SCROLL_BAR_FADE_DURATION;
		}

		/// <returns>Default delay before the scrollbars fade in milliseconds</returns>
		public static int getScrollDefaultDelay()
		{
			return SCROLL_BAR_DEFAULT_DELAY;
		}

		/// <returns>the length of the fading edges in pixels</returns>
		[System.ObsoleteAttribute(@"Use getScaledFadingEdgeLength() instead.")]
		public static int getFadingEdgeLength()
		{
			return FADING_EDGE_LENGTH;
		}

		/// <returns>the length of the fading edges in pixels</returns>
		public virtual int getScaledFadingEdgeLength()
		{
			return mFadingEdgeLength;
		}

		/// <returns>
		/// the duration in milliseconds of the pressed state in child
		/// components.
		/// </returns>
		public static int getPressedStateDuration()
		{
			return PRESSED_STATE_DURATION;
		}

		/// <returns>
		/// the duration in milliseconds before a press turns into
		/// a long press
		/// </returns>
		public static int getLongPressTimeout()
		{
			return android.app.AppGlobals.getIntCoreSetting(android.provider.Settings.Secure.
				LONG_PRESS_TIMEOUT, DEFAULT_LONG_PRESS_TIMEOUT);
		}

		/// <returns>the time before the first key repeat in milliseconds.</returns>
		public static int getKeyRepeatTimeout()
		{
			return getLongPressTimeout();
		}

		/// <returns>the time between successive key repeats in milliseconds.</returns>
		public static int getKeyRepeatDelay()
		{
			return KEY_REPEAT_DELAY;
		}

		/// <returns>
		/// the duration in milliseconds we will wait to see if a touch event
		/// is a tap or a scroll. If the user does not move within this interval, it is
		/// considered to be a tap.
		/// </returns>
		public static int getTapTimeout()
		{
			return TAP_TIMEOUT;
		}

		/// <returns>
		/// the duration in milliseconds we will wait to see if a touch event
		/// is a jump tap. If the user does not move within this interval, it is
		/// considered to be a tap.
		/// </returns>
		public static int getJumpTapTimeout()
		{
			return JUMP_TAP_TIMEOUT;
		}

		/// <returns>
		/// the duration in milliseconds between the first tap's up event and
		/// the second tap's down event for an interaction to be considered a
		/// double-tap.
		/// </returns>
		public static int getDoubleTapTimeout()
		{
			return DOUBLE_TAP_TIMEOUT;
		}

		/// <returns>
		/// the maximum duration in milliseconds between a touch pad
		/// touch and release for a given touch to be considered a tap (click) as
		/// opposed to a hover movement gesture.
		/// </returns>
		/// <hide></hide>
		public static int getHoverTapTimeout()
		{
			return HOVER_TAP_TIMEOUT;
		}

		/// <returns>
		/// the maximum distance in pixels that a touch pad touch can move
		/// before being released for it to be considered a tap (click) as opposed
		/// to a hover movement gesture.
		/// </returns>
		/// <hide></hide>
		public static int getHoverTapSlop()
		{
			return HOVER_TAP_SLOP;
		}

		/// <returns>
		/// Inset in pixels to look for touchable content when the user touches the edge of the
		/// screen
		/// </returns>
		[System.ObsoleteAttribute(@"Use getScaledEdgeSlop() instead.")]
		public static int getEdgeSlop()
		{
			return EDGE_SLOP;
		}

		/// <returns>
		/// Inset in pixels to look for touchable content when the user touches the edge of the
		/// screen
		/// </returns>
		public virtual int getScaledEdgeSlop()
		{
			return mEdgeSlop;
		}

		/// <returns>Distance a touch can wander before we think the user is scrolling in pixels
		/// 	</returns>
		[System.ObsoleteAttribute(@"Use getScaledTouchSlop() instead.")]
		public static int getTouchSlop()
		{
			return TOUCH_SLOP;
		}

		/// <returns>Distance a touch can wander before we think the user is scrolling in pixels
		/// 	</returns>
		public virtual int getScaledTouchSlop()
		{
			return mTouchSlop;
		}

		/// <returns>
		/// Distance a touch can wander before we think the user is scrolling a full page
		/// in dips
		/// </returns>
		public virtual int getScaledPagingTouchSlop()
		{
			return mPagingTouchSlop;
		}

		/// <returns>
		/// Distance between the first touch and second touch to still be
		/// considered a double tap
		/// </returns>
		/// <hide>
		/// The only client of this should be GestureDetector, which needs this
		/// for clients that still use its deprecated constructor.
		/// </hide>
		[System.ObsoleteAttribute(@"Use getScaledDoubleTapSlop() instead.")]
		public static int getDoubleTapSlop()
		{
			return DOUBLE_TAP_SLOP;
		}

		/// <returns>
		/// Distance between the first touch and second touch to still be
		/// considered a double tap
		/// </returns>
		public virtual int getScaledDoubleTapSlop()
		{
			return mDoubleTapSlop;
		}

		/// <returns>
		/// Distance between a touch up event denoting the end of a touch exploration
		/// gesture and the touch up event of a subsequent tap for the latter tap to be
		/// considered as a tap i.e. to perform a click.
		/// </returns>
		/// <hide></hide>
		public virtual int getScaledTouchExplorationTapSlop()
		{
			return mScaledTouchExplorationTapSlop;
		}

		/// <summary>Interval for dispatching a recurring accessibility event in milliseconds.
		/// 	</summary>
		/// <remarks>
		/// Interval for dispatching a recurring accessibility event in milliseconds.
		/// This interval guarantees that a recurring event will be send at most once
		/// during the
		/// <see cref="getSendRecurringAccessibilityEventsInterval()">getSendRecurringAccessibilityEventsInterval()
		/// 	</see>
		/// time frame.
		/// </remarks>
		/// <returns>The delay in milliseconds.</returns>
		/// <hide></hide>
		public static long getSendRecurringAccessibilityEventsInterval()
		{
			return SEND_RECURRING_ACCESSIBILITY_EVENTS_INTERVAL_MILLIS;
		}

		/// <returns>
		/// Distance a touch must be outside the bounds of a window for it
		/// to be counted as outside the window for purposes of dismissing that
		/// window.
		/// </returns>
		[System.ObsoleteAttribute(@"Use getScaledWindowTouchSlop() instead.")]
		public static int getWindowTouchSlop()
		{
			return WINDOW_TOUCH_SLOP;
		}

		/// <returns>
		/// Distance a touch must be outside the bounds of a window for it
		/// to be counted as outside the window for purposes of dismissing that
		/// window.
		/// </returns>
		public virtual int getScaledWindowTouchSlop()
		{
			return mWindowTouchSlop;
		}

		/// <returns>Minimum velocity to initiate a fling, as measured in pixels per second.</returns>
		[System.ObsoleteAttribute(@"Use getScaledMinimumFlingVelocity() instead.")]
		public static int getMinimumFlingVelocity()
		{
			return MINIMUM_FLING_VELOCITY;
		}

		/// <returns>Minimum velocity to initiate a fling, as measured in pixels per second.</returns>
		public virtual int getScaledMinimumFlingVelocity()
		{
			return mMinimumFlingVelocity;
		}

		/// <returns>Maximum velocity to initiate a fling, as measured in pixels per second.</returns>
		[System.ObsoleteAttribute(@"Use getScaledMaximumFlingVelocity() instead.")]
		public static int getMaximumFlingVelocity()
		{
			return MAXIMUM_FLING_VELOCITY;
		}

		/// <returns>Maximum velocity to initiate a fling, as measured in pixels per second.</returns>
		public virtual int getScaledMaximumFlingVelocity()
		{
			return mMaximumFlingVelocity;
		}

		/// <summary>The maximum drawing cache size expressed in bytes.</summary>
		/// <remarks>The maximum drawing cache size expressed in bytes.</remarks>
		/// <returns>the maximum size of View's drawing cache expressed in bytes</returns>
		[System.ObsoleteAttribute(@"Use getScaledMaximumDrawingCacheSize() instead.")]
		public static int getMaximumDrawingCacheSize()
		{
			//noinspection deprecation
			return MAXIMUM_DRAWING_CACHE_SIZE;
		}

		/// <summary>The maximum drawing cache size expressed in bytes.</summary>
		/// <remarks>The maximum drawing cache size expressed in bytes.</remarks>
		/// <returns>the maximum size of View's drawing cache expressed in bytes</returns>
		public virtual int getScaledMaximumDrawingCacheSize()
		{
			return mMaximumDrawingCacheSize;
		}

		/// <returns>The maximum distance a View should overscroll by when showing edge effects.
		/// 	</returns>
		public virtual int getScaledOverscrollDistance()
		{
			return mOverscrollDistance;
		}

		/// <returns>The maximum distance a View should overfling by when showing edge effects.
		/// 	</returns>
		public virtual int getScaledOverflingDistance()
		{
			return mOverflingDistance;
		}

		/// <summary>
		/// The amount of time that the zoom controls should be
		/// displayed on the screen expressed in milliseconds.
		/// </summary>
		/// <remarks>
		/// The amount of time that the zoom controls should be
		/// displayed on the screen expressed in milliseconds.
		/// </remarks>
		/// <returns>
		/// the time the zoom controls should be visible expressed
		/// in milliseconds.
		/// </returns>
		public static long getZoomControlsTimeout()
		{
			return ZOOM_CONTROLS_TIMEOUT;
		}

		/// <summary>
		/// The amount of time a user needs to press the relevant key to bring up
		/// the global actions dialog.
		/// </summary>
		/// <remarks>
		/// The amount of time a user needs to press the relevant key to bring up
		/// the global actions dialog.
		/// </remarks>
		/// <returns>
		/// how long a user needs to press the relevant key to bring up
		/// the global actions dialog.
		/// </returns>
		public static long getGlobalActionKeyTimeout()
		{
			return GLOBAL_ACTIONS_KEY_TIMEOUT;
		}

		/// <summary>The amount of friction applied to scrolls and flings.</summary>
		/// <remarks>The amount of friction applied to scrolls and flings.</remarks>
		/// <returns>
		/// A scalar dimensionless value representing the coefficient of
		/// friction.
		/// </returns>
		public static float getScrollFriction()
		{
			return SCROLL_FRICTION;
		}

		/// <summary>Report if the device has a permanent menu key available to the user.</summary>
		/// <remarks>
		/// Report if the device has a permanent menu key available to the user.
		/// <p>As of Android 3.0, devices may not have a permanent menu key available.
		/// Apps should use the action bar to present menu options to users.
		/// However, there are some apps where the action bar is inappropriate
		/// or undesirable. This method may be used to detect if a menu key is present.
		/// If not, applications should provide another on-screen affordance to access
		/// functionality.
		/// </remarks>
		/// <returns>true if a permanent menu key is present, false otherwise.</returns>
		public virtual bool hasPermanentMenuKey()
		{
			return sHasPermanentMenuKey;
		}

		/// <hide></hide>
		/// <returns>Whether or not marquee should use fading edges.</returns>
		public virtual bool isFadingMarqueeEnabled()
		{
			return mFadingMarqueeEnabled;
		}
	}
}

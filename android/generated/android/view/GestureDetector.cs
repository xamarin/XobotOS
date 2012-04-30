using Sharpen;

namespace android.view
{
	/// <summary>
	/// Detects various gestures and events using the supplied
	/// <see cref="MotionEvent">MotionEvent</see>
	/// s.
	/// The
	/// <see cref="OnGestureListener">OnGestureListener</see>
	/// callback will notify users when a particular
	/// motion event has occurred. This class should only be used with
	/// <see cref="MotionEvent">MotionEvent</see>
	/// s
	/// reported via touch (don't use for trackball events).
	/// To use this class:
	/// <ul>
	/// <li>Create an instance of the
	/// <code>GestureDetector</code>
	/// for your
	/// <see cref="View">View</see>
	/// <li>In the
	/// <see cref="View.onTouchEvent(MotionEvent)">View.onTouchEvent(MotionEvent)</see>
	/// method ensure you call
	/// <see cref="onTouchEvent(MotionEvent)">onTouchEvent(MotionEvent)</see>
	/// . The methods defined in your callback
	/// will be executed when the events occur.
	/// </ul>
	/// </summary>
	[Sharpen.Sharpened]
	public class GestureDetector
	{
		/// <summary>The listener that is used to notify when gestures occur.</summary>
		/// <remarks>
		/// The listener that is used to notify when gestures occur.
		/// If you want to listen for all the different gestures then implement
		/// this interface. If you only want to listen for a subset it might
		/// be easier to extend
		/// <see cref="SimpleOnGestureListener">SimpleOnGestureListener</see>
		/// .
		/// </remarks>
		public interface OnGestureListener
		{
			/// <summary>
			/// Notified when a tap occurs with the down
			/// <see cref="MotionEvent">MotionEvent</see>
			/// that triggered it. This will be triggered immediately for
			/// every down event. All other events should be preceded by this.
			/// </summary>
			/// <param name="e">The down motion event.</param>
			bool onDown(android.view.MotionEvent e);

			/// <summary>
			/// The user has performed a down
			/// <see cref="MotionEvent">MotionEvent</see>
			/// and not performed
			/// a move or up yet. This event is commonly used to provide visual
			/// feedback to the user to let them know that their action has been
			/// recognized i.e. highlight an element.
			/// </summary>
			/// <param name="e">The down motion event</param>
			void onShowPress(android.view.MotionEvent e);

			/// <summary>
			/// Notified when a tap occurs with the up
			/// <see cref="MotionEvent">MotionEvent</see>
			/// that triggered it.
			/// </summary>
			/// <param name="e">The up motion event that completed the first tap</param>
			/// <returns>true if the event is consumed, else false</returns>
			bool onSingleTapUp(android.view.MotionEvent e);

			/// <summary>
			/// Notified when a scroll occurs with the initial on down
			/// <see cref="MotionEvent">MotionEvent</see>
			/// and the
			/// current move
			/// <see cref="MotionEvent">MotionEvent</see>
			/// . The distance in x and y is also supplied for
			/// convenience.
			/// </summary>
			/// <param name="e1">The first down motion event that started the scrolling.</param>
			/// <param name="e2">The move motion event that triggered the current onScroll.</param>
			/// <param name="distanceX">
			/// The distance along the X axis that has been scrolled since the last
			/// call to onScroll. This is NOT the distance between
			/// <code>e1</code>
			/// and
			/// <code>e2</code>
			/// .
			/// </param>
			/// <param name="distanceY">
			/// The distance along the Y axis that has been scrolled since the last
			/// call to onScroll. This is NOT the distance between
			/// <code>e1</code>
			/// and
			/// <code>e2</code>
			/// .
			/// </param>
			/// <returns>true if the event is consumed, else false</returns>
			bool onScroll(android.view.MotionEvent e1, android.view.MotionEvent e2, float distanceX
				, float distanceY);

			/// <summary>
			/// Notified when a long press occurs with the initial on down
			/// <see cref="MotionEvent">MotionEvent</see>
			/// that trigged it.
			/// </summary>
			/// <param name="e">The initial on down motion event that started the longpress.</param>
			void onLongPress(android.view.MotionEvent e);

			/// <summary>
			/// Notified of a fling event when it occurs with the initial on down
			/// <see cref="MotionEvent">MotionEvent</see>
			/// and the matching up
			/// <see cref="MotionEvent">MotionEvent</see>
			/// . The calculated velocity is supplied along
			/// the x and y axis in pixels per second.
			/// </summary>
			/// <param name="e1">The first down motion event that started the fling.</param>
			/// <param name="e2">The move motion event that triggered the current onFling.</param>
			/// <param name="velocityX">
			/// The velocity of this fling measured in pixels per second
			/// along the x axis.
			/// </param>
			/// <param name="velocityY">
			/// The velocity of this fling measured in pixels per second
			/// along the y axis.
			/// </param>
			/// <returns>true if the event is consumed, else false</returns>
			bool onFling(android.view.MotionEvent e1, android.view.MotionEvent e2, float velocityX
				, float velocityY);
		}

		/// <summary>
		/// The listener that is used to notify when a double-tap or a confirmed
		/// single-tap occur.
		/// </summary>
		/// <remarks>
		/// The listener that is used to notify when a double-tap or a confirmed
		/// single-tap occur.
		/// </remarks>
		public interface OnDoubleTapListener
		{
			/// <summary>Notified when a single-tap occurs.</summary>
			/// <remarks>
			/// Notified when a single-tap occurs.
			/// <p>
			/// Unlike
			/// <see cref="OnGestureListener.onSingleTapUp(MotionEvent)">OnGestureListener.onSingleTapUp(MotionEvent)
			/// 	</see>
			/// , this
			/// will only be called after the detector is confident that the user's
			/// first tap is not followed by a second tap leading to a double-tap
			/// gesture.
			/// </remarks>
			/// <param name="e">The down motion event of the single-tap.</param>
			/// <returns>true if the event is consumed, else false</returns>
			bool onSingleTapConfirmed(android.view.MotionEvent e);

			/// <summary>Notified when a double-tap occurs.</summary>
			/// <remarks>Notified when a double-tap occurs.</remarks>
			/// <param name="e">The down motion event of the first tap of the double-tap.</param>
			/// <returns>true if the event is consumed, else false</returns>
			bool onDoubleTap(android.view.MotionEvent e);

			/// <summary>
			/// Notified when an event within a double-tap gesture occurs, including
			/// the down, move, and up events.
			/// </summary>
			/// <remarks>
			/// Notified when an event within a double-tap gesture occurs, including
			/// the down, move, and up events.
			/// </remarks>
			/// <param name="e">The motion event that occurred during the double-tap gesture.</param>
			/// <returns>true if the event is consumed, else false</returns>
			bool onDoubleTapEvent(android.view.MotionEvent e);
		}

		/// <summary>
		/// A convenience class to extend when you only want to listen for a subset
		/// of all the gestures.
		/// </summary>
		/// <remarks>
		/// A convenience class to extend when you only want to listen for a subset
		/// of all the gestures. This implements all methods in the
		/// <see cref="OnGestureListener">OnGestureListener</see>
		/// and
		/// <see cref="OnDoubleTapListener">OnDoubleTapListener</see>
		/// but does
		/// nothing and return
		/// <code>false</code>
		/// for all applicable methods.
		/// </remarks>
		public class SimpleOnGestureListener : android.view.GestureDetector.OnGestureListener
			, android.view.GestureDetector.OnDoubleTapListener
		{
			[Sharpen.ImplementsInterface(@"android.view.GestureDetector.OnGestureListener")]
			public virtual bool onSingleTapUp(android.view.MotionEvent e)
			{
				return false;
			}

			[Sharpen.ImplementsInterface(@"android.view.GestureDetector.OnGestureListener")]
			public virtual void onLongPress(android.view.MotionEvent e)
			{
			}

			[Sharpen.ImplementsInterface(@"android.view.GestureDetector.OnGestureListener")]
			public virtual bool onScroll(android.view.MotionEvent e1, android.view.MotionEvent
				 e2, float distanceX, float distanceY)
			{
				return false;
			}

			[Sharpen.ImplementsInterface(@"android.view.GestureDetector.OnGestureListener")]
			public virtual bool onFling(android.view.MotionEvent e1, android.view.MotionEvent
				 e2, float velocityX, float velocityY)
			{
				return false;
			}

			[Sharpen.ImplementsInterface(@"android.view.GestureDetector.OnGestureListener")]
			public virtual void onShowPress(android.view.MotionEvent e)
			{
			}

			[Sharpen.ImplementsInterface(@"android.view.GestureDetector.OnGestureListener")]
			public virtual bool onDown(android.view.MotionEvent e)
			{
				return false;
			}

			[Sharpen.ImplementsInterface(@"android.view.GestureDetector.OnDoubleTapListener")]
			public virtual bool onDoubleTap(android.view.MotionEvent e)
			{
				return false;
			}

			[Sharpen.ImplementsInterface(@"android.view.GestureDetector.OnDoubleTapListener")]
			public virtual bool onDoubleTapEvent(android.view.MotionEvent e)
			{
				return false;
			}

			[Sharpen.ImplementsInterface(@"android.view.GestureDetector.OnDoubleTapListener")]
			public virtual bool onSingleTapConfirmed(android.view.MotionEvent e)
			{
				return false;
			}
		}

		private int mBiggerTouchSlopSquare = 20 * 20;

		private int mTouchSlopSquare;

		private int mDoubleTapSlopSquare;

		private int mMinimumFlingVelocity;

		private int mMaximumFlingVelocity;

		private static readonly int LONGPRESS_TIMEOUT = android.view.ViewConfiguration.getLongPressTimeout
			();

		private static readonly int TAP_TIMEOUT = android.view.ViewConfiguration.getTapTimeout
			();

		private static readonly int DOUBLE_TAP_TIMEOUT = android.view.ViewConfiguration.getDoubleTapTimeout
			();

		internal const int SHOW_PRESS = 1;

		internal const int LONG_PRESS = 2;

		internal const int TAP = 3;

		private readonly android.os.Handler mHandler;

		private readonly android.view.GestureDetector.OnGestureListener mListener;

		private android.view.GestureDetector.OnDoubleTapListener mDoubleTapListener;

		private bool mStillDown;

		private bool mInLongPress;

		private bool mAlwaysInTapRegion;

		private bool mAlwaysInBiggerTapRegion;

		private android.view.MotionEvent mCurrentDownEvent;

		private android.view.MotionEvent mPreviousUpEvent;

		/// <summary>
		/// True when the user is still touching for the second tap (down, move, and
		/// up events).
		/// </summary>
		/// <remarks>
		/// True when the user is still touching for the second tap (down, move, and
		/// up events). Can only be true if there is a double tap listener attached.
		/// </remarks>
		private bool mIsDoubleTapping;

		private float mLastMotionY;

		private float mLastMotionX;

		private bool mIsLongpressEnabled;

		/// <summary>
		/// True if we are at a target API level of &gt;= Froyo or the developer can
		/// explicitly set it.
		/// </summary>
		/// <remarks>
		/// True if we are at a target API level of &gt;= Froyo or the developer can
		/// explicitly set it. If true, input events with &gt; 1 pointer will be ignored
		/// so we can work side by side with multitouch gesture detectors.
		/// </remarks>
		private bool mIgnoreMultitouch;

		/// <summary>Determines speed during touch scrolling</summary>
		private android.view.VelocityTracker mVelocityTracker;

		/// <summary>Consistency verifier for debugging purposes.</summary>
		/// <remarks>Consistency verifier for debugging purposes.</remarks>
		private readonly android.view.InputEventConsistencyVerifier mInputEventConsistencyVerifier;

		private class GestureHandler : android.os.Handler
		{
			internal GestureHandler(GestureDetector _enclosing) : base()
			{
				this._enclosing = _enclosing;
			}

			internal GestureHandler(GestureDetector _enclosing, android.os.Handler handler) : 
				base(handler.getLooper())
			{
				this._enclosing = _enclosing;
			}

			// TODO: ViewConfiguration
			// constants for Message.what used by GestureHandler below
			[Sharpen.OverridesMethod(@"android.os.Handler")]
			public override void handleMessage(android.os.Message msg)
			{
				switch (msg.what)
				{
					case android.view.GestureDetector.SHOW_PRESS:
					{
						this._enclosing.mListener.onShowPress(this._enclosing.mCurrentDownEvent);
						break;
					}

					case android.view.GestureDetector.LONG_PRESS:
					{
						this._enclosing.dispatchLongPress();
						break;
					}

					case android.view.GestureDetector.TAP:
					{
						// If the user's finger is still down, do not count it as a tap
						if (this._enclosing.mDoubleTapListener != null && !this._enclosing.mStillDown)
						{
							this._enclosing.mDoubleTapListener.onSingleTapConfirmed(this._enclosing.mCurrentDownEvent
								);
						}
						break;
					}

					default:
					{
						throw new java.lang.RuntimeException("Unknown message " + msg);
					}
				}
			}

			private readonly GestureDetector _enclosing;
			//never
		}

		/// <summary>Creates a GestureDetector with the supplied listener.</summary>
		/// <remarks>
		/// Creates a GestureDetector with the supplied listener.
		/// This variant of the constructor should be used from a non-UI thread
		/// (as it allows specifying the Handler).
		/// </remarks>
		/// <param name="listener">
		/// the listener invoked for all the callbacks, this must
		/// not be null.
		/// </param>
		/// <param name="handler">the handler to use</param>
		/// <exception cref="System.ArgumentNullException">
		/// if either
		/// <code>listener</code>
		/// or
		/// <code>handler</code>
		/// is null.
		/// </exception>
		[System.ObsoleteAttribute(@"Use GestureDetector(android.content.Context, OnGestureListener, android.os.Handler) instead."
			)]
		public GestureDetector(android.view.GestureDetector.OnGestureListener listener, android.os.Handler
			 handler) : this(null, listener, handler)
		{
			mInputEventConsistencyVerifier = android.view.InputEventConsistencyVerifier.isInstrumentationEnabled
				() ? new android.view.InputEventConsistencyVerifier(this, 0) : null;
		}

		/// <summary>Creates a GestureDetector with the supplied listener.</summary>
		/// <remarks>
		/// Creates a GestureDetector with the supplied listener.
		/// You may only use this constructor from a UI thread (this is the usual situation).
		/// </remarks>
		/// <seealso cref="android.os.Handler.Handler()">android.os.Handler.Handler()</seealso>
		/// <param name="listener">
		/// the listener invoked for all the callbacks, this must
		/// not be null.
		/// </param>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>listener</code>
		/// is null.
		/// </exception>
		[System.ObsoleteAttribute(@"Use GestureDetector(android.content.Context, OnGestureListener) instead."
			)]
		public GestureDetector(android.view.GestureDetector.OnGestureListener listener) : 
			this(null, listener, null)
		{
			mInputEventConsistencyVerifier = android.view.InputEventConsistencyVerifier.isInstrumentationEnabled
				() ? new android.view.InputEventConsistencyVerifier(this, 0) : null;
		}

		/// <summary>Creates a GestureDetector with the supplied listener.</summary>
		/// <remarks>
		/// Creates a GestureDetector with the supplied listener.
		/// You may only use this constructor from a UI thread (this is the usual situation).
		/// </remarks>
		/// <seealso cref="android.os.Handler.Handler()">android.os.Handler.Handler()</seealso>
		/// <param name="context">the application's context</param>
		/// <param name="listener">
		/// the listener invoked for all the callbacks, this must
		/// not be null.
		/// </param>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>listener</code>
		/// is null.
		/// </exception>
		public GestureDetector(android.content.Context context, android.view.GestureDetector
			.OnGestureListener listener) : this(context, listener, null)
		{
			mInputEventConsistencyVerifier = android.view.InputEventConsistencyVerifier.isInstrumentationEnabled
				() ? new android.view.InputEventConsistencyVerifier(this, 0) : null;
		}

		/// <summary>Creates a GestureDetector with the supplied listener.</summary>
		/// <remarks>
		/// Creates a GestureDetector with the supplied listener.
		/// You may only use this constructor from a UI thread (this is the usual situation).
		/// </remarks>
		/// <seealso cref="android.os.Handler.Handler()">android.os.Handler.Handler()</seealso>
		/// <param name="context">the application's context</param>
		/// <param name="listener">
		/// the listener invoked for all the callbacks, this must
		/// not be null.
		/// </param>
		/// <param name="handler">the handler to use</param>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>listener</code>
		/// is null.
		/// </exception>
		public GestureDetector(android.content.Context context, android.view.GestureDetector
			.OnGestureListener listener, android.os.Handler handler) : this(context, listener
			, handler, context != null && context.getApplicationInfo().targetSdkVersion >= android.os.Build
			.VERSION_CODES.FROYO)
		{
			mInputEventConsistencyVerifier = android.view.InputEventConsistencyVerifier.isInstrumentationEnabled
				() ? new android.view.InputEventConsistencyVerifier(this, 0) : null;
		}

		/// <summary>Creates a GestureDetector with the supplied listener.</summary>
		/// <remarks>
		/// Creates a GestureDetector with the supplied listener.
		/// You may only use this constructor from a UI thread (this is the usual situation).
		/// </remarks>
		/// <seealso cref="android.os.Handler.Handler()">android.os.Handler.Handler()</seealso>
		/// <param name="context">the application's context</param>
		/// <param name="listener">
		/// the listener invoked for all the callbacks, this must
		/// not be null.
		/// </param>
		/// <param name="handler">the handler to use</param>
		/// <param name="ignoreMultitouch">
		/// whether events involving more than one pointer should
		/// be ignored.
		/// </param>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>listener</code>
		/// is null.
		/// </exception>
		public GestureDetector(android.content.Context context, android.view.GestureDetector
			.OnGestureListener listener, android.os.Handler handler, bool ignoreMultitouch)
		{
			mInputEventConsistencyVerifier = android.view.InputEventConsistencyVerifier.isInstrumentationEnabled
				() ? new android.view.InputEventConsistencyVerifier(this, 0) : null;
			if (handler != null)
			{
				mHandler = new android.view.GestureDetector.GestureHandler(this, handler);
			}
			else
			{
				mHandler = new android.view.GestureDetector.GestureHandler(this);
			}
			mListener = listener;
			if (listener is android.view.GestureDetector.OnDoubleTapListener)
			{
				setOnDoubleTapListener((android.view.GestureDetector.OnDoubleTapListener)listener
					);
			}
			init(context, ignoreMultitouch);
		}

		private void init(android.content.Context context, bool ignoreMultitouch)
		{
			if (mListener == null)
			{
				throw new System.ArgumentNullException("OnGestureListener must not be null");
			}
			mIsLongpressEnabled = true;
			mIgnoreMultitouch = ignoreMultitouch;
			// Fallback to support pre-donuts releases
			int touchSlop;
			int doubleTapSlop;
			if (context == null)
			{
				//noinspection deprecation
				touchSlop = android.view.ViewConfiguration.getTouchSlop();
				doubleTapSlop = android.view.ViewConfiguration.getDoubleTapSlop();
				//noinspection deprecation
				mMinimumFlingVelocity = android.view.ViewConfiguration.getMinimumFlingVelocity();
				mMaximumFlingVelocity = android.view.ViewConfiguration.getMaximumFlingVelocity();
			}
			else
			{
				android.view.ViewConfiguration configuration = android.view.ViewConfiguration.get
					(context);
				touchSlop = configuration.getScaledTouchSlop();
				doubleTapSlop = configuration.getScaledDoubleTapSlop();
				mMinimumFlingVelocity = configuration.getScaledMinimumFlingVelocity();
				mMaximumFlingVelocity = configuration.getScaledMaximumFlingVelocity();
			}
			mTouchSlopSquare = touchSlop * touchSlop;
			mDoubleTapSlopSquare = doubleTapSlop * doubleTapSlop;
		}

		/// <summary>
		/// Sets the listener which will be called for double-tap and related
		/// gestures.
		/// </summary>
		/// <remarks>
		/// Sets the listener which will be called for double-tap and related
		/// gestures.
		/// </remarks>
		/// <param name="onDoubleTapListener">
		/// the listener invoked for all the callbacks, or
		/// null to stop listening for double-tap gestures.
		/// </param>
		public virtual void setOnDoubleTapListener(android.view.GestureDetector.OnDoubleTapListener
			 onDoubleTapListener)
		{
			mDoubleTapListener = onDoubleTapListener;
		}

		/// <summary>
		/// Set whether longpress is enabled, if this is enabled when a user
		/// presses and holds down you get a longpress event and nothing further.
		/// </summary>
		/// <remarks>
		/// Set whether longpress is enabled, if this is enabled when a user
		/// presses and holds down you get a longpress event and nothing further.
		/// If it's disabled the user can press and hold down and then later
		/// moved their finger and you will get scroll events. By default
		/// longpress is enabled.
		/// </remarks>
		/// <param name="isLongpressEnabled">whether longpress should be enabled.</param>
		public virtual void setIsLongpressEnabled(bool isLongpressEnabled_1)
		{
			mIsLongpressEnabled = isLongpressEnabled_1;
		}

		/// <returns>true if longpress is enabled, else false.</returns>
		public virtual bool isLongpressEnabled()
		{
			return mIsLongpressEnabled;
		}

		/// <summary>
		/// Analyzes the given motion event and if applicable triggers the
		/// appropriate callbacks on the
		/// <see cref="OnGestureListener">OnGestureListener</see>
		/// supplied.
		/// </summary>
		/// <param name="ev">The current motion event.</param>
		/// <returns>
		/// true if the
		/// <see cref="OnGestureListener">OnGestureListener</see>
		/// consumed the event,
		/// else false.
		/// </returns>
		public virtual bool onTouchEvent(android.view.MotionEvent ev)
		{
			if (mInputEventConsistencyVerifier != null)
			{
				mInputEventConsistencyVerifier.onTouchEvent(ev, 0);
			}
			int action = ev.getAction();
			float y = ev.getY();
			float x = ev.getX();
			if (mVelocityTracker == null)
			{
				mVelocityTracker = android.view.VelocityTracker.obtain();
			}
			mVelocityTracker.addMovement(ev);
			bool handled = false;
			switch (action & android.view.MotionEvent.ACTION_MASK)
			{
				case android.view.MotionEvent.ACTION_POINTER_DOWN:
				{
					if (mIgnoreMultitouch)
					{
						// Multitouch event - abort.
						cancel();
					}
					break;
				}

				case android.view.MotionEvent.ACTION_POINTER_UP:
				{
					// Ending a multitouch gesture and going back to 1 finger
					if (mIgnoreMultitouch && ev.getPointerCount() == 2)
					{
						int index = (((action & android.view.MotionEvent.ACTION_POINTER_INDEX_MASK) >> android.view.MotionEvent
							.ACTION_POINTER_INDEX_SHIFT) == 0) ? 1 : 0;
						mLastMotionX = ev.getX(index);
						mLastMotionY = ev.getY(index);
						mVelocityTracker.recycle();
						mVelocityTracker = android.view.VelocityTracker.obtain();
					}
					break;
				}

				case android.view.MotionEvent.ACTION_DOWN:
				{
					if (mDoubleTapListener != null)
					{
						bool hadTapMessage = mHandler.hasMessages(TAP);
						if (hadTapMessage)
						{
							mHandler.removeMessages(TAP);
						}
						if ((mCurrentDownEvent != null) && (mPreviousUpEvent != null) && hadTapMessage &&
							 isConsideredDoubleTap(mCurrentDownEvent, mPreviousUpEvent, ev))
						{
							// This is a second tap
							mIsDoubleTapping = true;
							// Give a callback with the first tap of the double-tap
							handled |= mDoubleTapListener.onDoubleTap(mCurrentDownEvent);
							// Give a callback with down event of the double-tap
							handled |= mDoubleTapListener.onDoubleTapEvent(ev);
						}
						else
						{
							// This is a first tap
							mHandler.sendEmptyMessageDelayed(TAP, DOUBLE_TAP_TIMEOUT);
						}
					}
					mLastMotionX = x;
					mLastMotionY = y;
					if (mCurrentDownEvent != null)
					{
						mCurrentDownEvent.recycle();
					}
					mCurrentDownEvent = android.view.MotionEvent.obtain(ev);
					mAlwaysInTapRegion = true;
					mAlwaysInBiggerTapRegion = true;
					mStillDown = true;
					mInLongPress = false;
					if (mIsLongpressEnabled)
					{
						mHandler.removeMessages(LONG_PRESS);
						mHandler.sendEmptyMessageAtTime(LONG_PRESS, mCurrentDownEvent.getDownTime() + TAP_TIMEOUT
							 + LONGPRESS_TIMEOUT);
					}
					mHandler.sendEmptyMessageAtTime(SHOW_PRESS, mCurrentDownEvent.getDownTime() + TAP_TIMEOUT
						);
					handled |= mListener.onDown(ev);
					break;
				}

				case android.view.MotionEvent.ACTION_MOVE:
				{
					if (mInLongPress || (mIgnoreMultitouch && ev.getPointerCount() > 1))
					{
						break;
					}
					float scrollX = mLastMotionX - x;
					float scrollY = mLastMotionY - y;
					if (mIsDoubleTapping)
					{
						// Give the move events of the double-tap
						handled |= mDoubleTapListener.onDoubleTapEvent(ev);
					}
					else
					{
						if (mAlwaysInTapRegion)
						{
							int deltaX = (int)(x - mCurrentDownEvent.getX());
							int deltaY = (int)(y - mCurrentDownEvent.getY());
							int distance = (deltaX * deltaX) + (deltaY * deltaY);
							if (distance > mTouchSlopSquare)
							{
								handled = mListener.onScroll(mCurrentDownEvent, ev, scrollX, scrollY);
								mLastMotionX = x;
								mLastMotionY = y;
								mAlwaysInTapRegion = false;
								mHandler.removeMessages(TAP);
								mHandler.removeMessages(SHOW_PRESS);
								mHandler.removeMessages(LONG_PRESS);
							}
							if (distance > mBiggerTouchSlopSquare)
							{
								mAlwaysInBiggerTapRegion = false;
							}
						}
						else
						{
							if ((System.Math.Abs(scrollX) >= 1) || (System.Math.Abs(scrollY) >= 1))
							{
								handled = mListener.onScroll(mCurrentDownEvent, ev, scrollX, scrollY);
								mLastMotionX = x;
								mLastMotionY = y;
							}
						}
					}
					break;
				}

				case android.view.MotionEvent.ACTION_UP:
				{
					mStillDown = false;
					android.view.MotionEvent currentUpEvent = android.view.MotionEvent.obtain(ev);
					if (mIsDoubleTapping)
					{
						// Finally, give the up event of the double-tap
						handled |= mDoubleTapListener.onDoubleTapEvent(ev);
					}
					else
					{
						if (mInLongPress)
						{
							mHandler.removeMessages(TAP);
							mInLongPress = false;
						}
						else
						{
							if (mAlwaysInTapRegion)
							{
								handled = mListener.onSingleTapUp(ev);
							}
							else
							{
								// A fling must travel the minimum tap distance
								android.view.VelocityTracker velocityTracker = mVelocityTracker;
								velocityTracker.computeCurrentVelocity(1000, mMaximumFlingVelocity);
								float velocityY = velocityTracker.getYVelocity();
								float velocityX = velocityTracker.getXVelocity();
								if ((System.Math.Abs(velocityY) > mMinimumFlingVelocity) || (System.Math.Abs(velocityX
									) > mMinimumFlingVelocity))
								{
									handled = mListener.onFling(mCurrentDownEvent, ev, velocityX, velocityY);
								}
							}
						}
					}
					if (mPreviousUpEvent != null)
					{
						mPreviousUpEvent.recycle();
					}
					// Hold the event we obtained above - listeners may have changed the original.
					mPreviousUpEvent = currentUpEvent;
					mVelocityTracker.recycle();
					mVelocityTracker = null;
					mIsDoubleTapping = false;
					mHandler.removeMessages(SHOW_PRESS);
					mHandler.removeMessages(LONG_PRESS);
					break;
				}

				case android.view.MotionEvent.ACTION_CANCEL:
				{
					cancel();
					break;
				}
			}
			if (!handled && mInputEventConsistencyVerifier != null)
			{
				mInputEventConsistencyVerifier.onUnhandledEvent(ev, 0);
			}
			return handled;
		}

		private void cancel()
		{
			mHandler.removeMessages(SHOW_PRESS);
			mHandler.removeMessages(LONG_PRESS);
			mHandler.removeMessages(TAP);
			mVelocityTracker.recycle();
			mVelocityTracker = null;
			mIsDoubleTapping = false;
			mStillDown = false;
			mAlwaysInTapRegion = false;
			mAlwaysInBiggerTapRegion = false;
			if (mInLongPress)
			{
				mInLongPress = false;
			}
		}

		private bool isConsideredDoubleTap(android.view.MotionEvent firstDown, android.view.MotionEvent
			 firstUp, android.view.MotionEvent secondDown)
		{
			if (!mAlwaysInBiggerTapRegion)
			{
				return false;
			}
			if (secondDown.getEventTime() - firstUp.getEventTime() > DOUBLE_TAP_TIMEOUT)
			{
				return false;
			}
			int deltaX = (int)firstDown.getX() - (int)secondDown.getX();
			int deltaY = (int)firstDown.getY() - (int)secondDown.getY();
			return (deltaX * deltaX + deltaY * deltaY < mDoubleTapSlopSquare);
		}

		private void dispatchLongPress()
		{
			mHandler.removeMessages(TAP);
			mInLongPress = true;
			mListener.onLongPress(mCurrentDownEvent);
		}
	}
}

using Sharpen;

namespace android.widget
{
	/// <summary>
	/// The
	/// <see cref="ZoomButtonsController">ZoomButtonsController</see>
	/// handles showing and hiding the zoom
	/// controls and positioning it relative to an owner view. It also gives the
	/// client access to the zoom controls container, allowing for additional
	/// accessory buttons to be shown in the zoom controls window.
	/// <p>
	/// Typically, clients should call
	/// <see cref="setVisible(bool)">setVisible(true)</see>
	/// on a touch down or move (no need to call
	/// <see cref="setVisible(bool)">setVisible(false)</see>
	/// since it will time out on its own). Also, whenever the
	/// owner cannot be zoomed further, the client should update
	/// <see cref="setZoomInEnabled(bool)">setZoomInEnabled(bool)</see>
	/// and
	/// <see cref="setZoomOutEnabled(bool)">setZoomOutEnabled(bool)</see>
	/// .
	/// <p>
	/// If you are using this with a custom View, please call
	/// <see cref="setVisible(bool)">setVisible(false)</see>
	/// from
	/// <see cref="android.view.View.onDetachedFromWindow()">android.view.View.onDetachedFromWindow()
	/// 	</see>
	/// and from
	/// <see cref="android.view.View.onVisibilityChanged(android.view.View, int)">android.view.View.onVisibilityChanged(android.view.View, int)
	/// 	</see>
	/// when <code>visibility != View.VISIBLE</code>.
	/// </summary>
	[Sharpen.Sharpened]
	public class ZoomButtonsController : android.view.View.OnTouchListener
	{
		internal const string TAG = "ZoomButtonsController";

		private static readonly int ZOOM_CONTROLS_TIMEOUT = (int)android.view.ViewConfiguration
			.getZoomControlsTimeout();

		internal const int ZOOM_CONTROLS_TOUCH_PADDING = 20;

		private int mTouchPaddingScaledSq;

		private readonly android.content.Context mContext;

		private readonly android.view.WindowManager mWindowManager;

		private bool mAutoDismissControls = true;

		/// <summary>The view that is being zoomed by this zoom controller.</summary>
		/// <remarks>The view that is being zoomed by this zoom controller.</remarks>
		private readonly android.view.View mOwnerView;

		/// <summary>The location of the owner view on the screen.</summary>
		/// <remarks>
		/// The location of the owner view on the screen. This is recalculated
		/// each time the zoom controller is shown.
		/// </remarks>
		private readonly int[] mOwnerViewRawLocation = new int[2];

		/// <summary>The container that is added as a window.</summary>
		/// <remarks>The container that is added as a window.</remarks>
		private readonly android.widget.FrameLayout mContainer;

		private android.view.WindowManagerClass.LayoutParams mContainerLayoutParams;

		private readonly int[] mContainerRawLocation = new int[2];

		private android.widget.ZoomControls mControls;

		/// <summary>The view (or null) that should receive touch events.</summary>
		/// <remarks>
		/// The view (or null) that should receive touch events. This will get set if
		/// the touch down hits the container. It will be reset on the touch up.
		/// </remarks>
		private android.view.View mTouchTargetView;

		/// <summary>
		/// The
		/// <see cref="mTouchTargetView">mTouchTargetView</see>
		/// 's location in window, set on touch down.
		/// </summary>
		private readonly int[] mTouchTargetWindowLocation = new int[2];

		/// <summary>
		/// If the zoom controller is dismissed but the user is still in a touch
		/// interaction, we set this to true.
		/// </summary>
		/// <remarks>
		/// If the zoom controller is dismissed but the user is still in a touch
		/// interaction, we set this to true. This will ignore all touch events until
		/// up/cancel, and then set the owner's touch listener to null.
		/// <p>
		/// Otherwise, the owner view would get mismatched events (i.e., touch move
		/// even though it never got the touch down.)
		/// </remarks>
		private bool mReleaseTouchListenerOnUp;

		/// <summary>Whether the container has been added to the window manager.</summary>
		/// <remarks>Whether the container has been added to the window manager.</remarks>
		private bool mIsVisible;

		private readonly android.graphics.Rect mTempRect = new android.graphics.Rect();

		private readonly int[] mTempIntArray = new int[2];

		private android.widget.ZoomButtonsController.OnZoomListener mCallback;

		/// <summary>When showing the zoom, we add the view as a new window.</summary>
		/// <remarks>
		/// When showing the zoom, we add the view as a new window. However, there is
		/// logic that needs to know the size of the zoom which is determined after
		/// it's laid out. Therefore, we must post this logic onto the UI thread so
		/// it will be exceuted AFTER the layout. This is the logic.
		/// </remarks>
		private java.lang.Runnable mPostedVisibleInitializer;

		private readonly android.content.IntentFilter mConfigurationChangedFilter = new android.content.IntentFilter
			(android.content.Intent.ACTION_CONFIGURATION_CHANGED);

		private sealed class _BroadcastReceiver_150 : android.content.BroadcastReceiver
		{
			public _BroadcastReceiver_150(ZoomButtonsController _enclosing)
			{
				this._enclosing = _enclosing;
			}

			[Sharpen.OverridesMethod(@"android.content.BroadcastReceiver")]
			public override void onReceive(android.content.Context context, android.content.Intent
				 intent)
			{
				if (!this._enclosing.mIsVisible)
				{
					return;
				}
				this._enclosing.mHandler.removeMessages(android.widget.ZoomButtonsController.MSG_POST_CONFIGURATION_CHANGED
					);
				this._enclosing.mHandler.sendEmptyMessage(android.widget.ZoomButtonsController.MSG_POST_CONFIGURATION_CHANGED
					);
			}

			private readonly ZoomButtonsController _enclosing;
		}

		/// <summary>Needed to reposition the zoom controls after configuration changes.</summary>
		/// <remarks>Needed to reposition the zoom controls after configuration changes.</remarks>
		private readonly android.content.BroadcastReceiver mConfigurationChangedReceiver;

		/// <summary>When configuration changes, this is called after the UI thread is idle.</summary>
		/// <remarks>When configuration changes, this is called after the UI thread is idle.</remarks>
		internal const int MSG_POST_CONFIGURATION_CHANGED = 2;

		/// <summary>Used to delay the zoom controller dismissal.</summary>
		/// <remarks>Used to delay the zoom controller dismissal.</remarks>
		internal const int MSG_DISMISS_ZOOM_CONTROLS = 3;

		/// <summary>
		/// If setVisible(true) is called and the owner view's window token is null,
		/// we delay the setVisible(true) call until it is not null.
		/// </summary>
		/// <remarks>
		/// If setVisible(true) is called and the owner view's window token is null,
		/// we delay the setVisible(true) call until it is not null.
		/// </remarks>
		internal const int MSG_POST_SET_VISIBLE = 4;

		private sealed class _Handler_170 : android.os.Handler
		{
			public _Handler_170(ZoomButtonsController _enclosing)
			{
				this._enclosing = _enclosing;
			}

			[Sharpen.OverridesMethod(@"android.os.Handler")]
			public override void handleMessage(android.os.Message msg)
			{
				switch (msg.what)
				{
					case android.widget.ZoomButtonsController.MSG_POST_CONFIGURATION_CHANGED:
					{
						this._enclosing.onPostConfigurationChanged();
						break;
					}

					case android.widget.ZoomButtonsController.MSG_DISMISS_ZOOM_CONTROLS:
					{
						this._enclosing.setVisible(false);
						break;
					}

					case android.widget.ZoomButtonsController.MSG_POST_SET_VISIBLE:
					{
						if (this._enclosing.mOwnerView.getWindowToken() == null)
						{
							// Doh, it is still null, just ignore the set visible call
							android.util.Log.e(android.widget.ZoomButtonsController.TAG, "Cannot make the zoom controller visible if the owner view is "
								 + "not attached to a window.");
						}
						else
						{
							this._enclosing.setVisible(true);
						}
						break;
					}
				}
			}

			private readonly ZoomButtonsController _enclosing;
		}

		private readonly android.os.Handler mHandler;

		/// <summary>
		/// Constructor for the
		/// <see cref="ZoomButtonsController">ZoomButtonsController</see>
		/// .
		/// </summary>
		/// <param name="ownerView">
		/// The view that is being zoomed by the zoom controls. The
		/// zoom controls will be displayed aligned with this view.
		/// </param>
		public ZoomButtonsController(android.view.View ownerView)
		{
			mConfigurationChangedReceiver = new _BroadcastReceiver_150(this);
			mHandler = new _Handler_170(this);
			mContext = ownerView.getContext();
			mWindowManager = (android.view.WindowManager)mContext.getSystemService(android.content.Context
				.WINDOW_SERVICE);
			mOwnerView = ownerView;
			mTouchPaddingScaledSq = (int)(ZOOM_CONTROLS_TOUCH_PADDING * mContext.getResources
				().getDisplayMetrics().density);
			mTouchPaddingScaledSq *= mTouchPaddingScaledSq;
			mContainer = createContainer();
		}

		/// <summary>Whether to enable the zoom in control.</summary>
		/// <remarks>Whether to enable the zoom in control.</remarks>
		/// <param name="enabled">Whether to enable the zoom in control.</param>
		public virtual void setZoomInEnabled(bool enabled)
		{
			mControls.setIsZoomInEnabled(enabled);
		}

		/// <summary>Whether to enable the zoom out control.</summary>
		/// <remarks>Whether to enable the zoom out control.</remarks>
		/// <param name="enabled">Whether to enable the zoom out control.</param>
		public virtual void setZoomOutEnabled(bool enabled)
		{
			mControls.setIsZoomOutEnabled(enabled);
		}

		/// <summary>Sets the delay between zoom callbacks as the user holds a zoom button.</summary>
		/// <remarks>Sets the delay between zoom callbacks as the user holds a zoom button.</remarks>
		/// <param name="speed">The delay in milliseconds between zoom callbacks.</param>
		public virtual void setZoomSpeed(long speed)
		{
			mControls.setZoomSpeed(speed);
		}

		private sealed class _OnClickListener_266 : android.view.View.OnClickListener
		{
			public _OnClickListener_266(ZoomButtonsController _enclosing)
			{
				this._enclosing = _enclosing;
			}

			// Controls are positioned BOTTOM | CENTER with respect to the owner view.
			[Sharpen.ImplementsInterface(@"android.view.View.OnClickListener")]
			public void onClick(android.view.View v)
			{
				this._enclosing.dismissControlsDelayed(android.widget.ZoomButtonsController.ZOOM_CONTROLS_TIMEOUT
					);
				if (this._enclosing.mCallback != null)
				{
					this._enclosing.mCallback.onZoom(true);
				}
			}

			private readonly ZoomButtonsController _enclosing;
		}

		private sealed class _OnClickListener_272 : android.view.View.OnClickListener
		{
			public _OnClickListener_272(ZoomButtonsController _enclosing)
			{
				this._enclosing = _enclosing;
			}

			[Sharpen.ImplementsInterface(@"android.view.View.OnClickListener")]
			public void onClick(android.view.View v)
			{
				this._enclosing.dismissControlsDelayed(android.widget.ZoomButtonsController.ZOOM_CONTROLS_TIMEOUT
					);
				if (this._enclosing.mCallback != null)
				{
					this._enclosing.mCallback.onZoom(false);
				}
			}

			private readonly ZoomButtonsController _enclosing;
		}

		private android.widget.FrameLayout createContainer()
		{
			android.view.WindowManagerClass.LayoutParams lp = new android.view.WindowManagerClass
				.LayoutParams(android.view.ViewGroup.LayoutParams.WRAP_CONTENT, android.view.ViewGroup
				.LayoutParams.WRAP_CONTENT);
			lp.gravity = android.view.Gravity.TOP | android.view.Gravity.LEFT;
			lp.flags = android.view.WindowManagerClass.LayoutParams.FLAG_NOT_TOUCHABLE | android.view.WindowManagerClass
				.LayoutParams.FLAG_NOT_FOCUSABLE | android.view.WindowManagerClass.LayoutParams.
				FLAG_LAYOUT_NO_LIMITS | android.view.WindowManagerClass.LayoutParams.FLAG_ALT_FOCUSABLE_IM;
			lp.height = android.view.ViewGroup.LayoutParams.WRAP_CONTENT;
			lp.width = android.view.ViewGroup.LayoutParams.MATCH_PARENT;
			lp.type = android.view.WindowManagerClass.LayoutParams.TYPE_APPLICATION_PANEL;
			lp.format = android.graphics.PixelFormat.TRANSLUCENT;
			lp.windowAnimations = android.@internal.R.style.Animation_ZoomButtons;
			mContainerLayoutParams = lp;
			android.widget.FrameLayout container = new android.widget.ZoomButtonsController.Container
				(this, mContext);
			container.setLayoutParams(lp);
			container.setMeasureAllChildren(true);
			android.view.LayoutInflater inflater = (android.view.LayoutInflater)mContext.getSystemService
				(android.content.Context.LAYOUT_INFLATER_SERVICE);
			inflater.inflate(android.@internal.R.layout.zoom_container, container);
			mControls = (android.widget.ZoomControls)container.findViewById(android.@internal.R
				.id.zoomControls);
			mControls.setOnZoomInClickListener(new _OnClickListener_266(this));
			mControls.setOnZoomOutClickListener(new _OnClickListener_272(this));
			return container;
		}

		/// <summary>
		/// Sets the
		/// <see cref="OnZoomListener">OnZoomListener</see>
		/// listener that receives callbacks to zoom.
		/// </summary>
		/// <param name="listener">The listener that will be told to zoom.</param>
		public virtual void setOnZoomListener(android.widget.ZoomButtonsController.OnZoomListener
			 listener)
		{
			mCallback = listener;
		}

		/// <summary>Sets whether the zoom controls should be focusable.</summary>
		/// <remarks>
		/// Sets whether the zoom controls should be focusable. If the controls are
		/// focusable, then trackball and arrow key interactions are possible.
		/// Otherwise, only touch interactions are possible.
		/// </remarks>
		/// <param name="focusable">Whether the zoom controls should be focusable.</param>
		public virtual void setFocusable(bool focusable)
		{
			int oldFlags = mContainerLayoutParams.flags;
			if (focusable)
			{
				mContainerLayoutParams.flags &= ~android.view.WindowManagerClass.LayoutParams.FLAG_NOT_FOCUSABLE;
			}
			else
			{
				mContainerLayoutParams.flags |= android.view.WindowManagerClass.LayoutParams.FLAG_NOT_FOCUSABLE;
			}
			if ((mContainerLayoutParams.flags != oldFlags) && mIsVisible)
			{
				mWindowManager.updateViewLayout(mContainer, mContainerLayoutParams);
			}
		}

		/// <summary>Whether the zoom controls will be automatically dismissed after showing.
		/// 	</summary>
		/// <remarks>Whether the zoom controls will be automatically dismissed after showing.
		/// 	</remarks>
		/// <returns>Whether the zoom controls will be auto dismissed after showing.</returns>
		public virtual bool isAutoDismissed()
		{
			return mAutoDismissControls;
		}

		/// <summary>
		/// Sets whether the zoom controls will be automatically dismissed after
		/// showing.
		/// </summary>
		/// <remarks>
		/// Sets whether the zoom controls will be automatically dismissed after
		/// showing.
		/// </remarks>
		public virtual void setAutoDismissed(bool autoDismiss)
		{
			if (mAutoDismissControls == autoDismiss)
			{
				return;
			}
			mAutoDismissControls = autoDismiss;
		}

		/// <summary>Whether the zoom controls are visible to the user.</summary>
		/// <remarks>Whether the zoom controls are visible to the user.</remarks>
		/// <returns>Whether the zoom controls are visible to the user.</returns>
		public virtual bool isVisible()
		{
			return mIsVisible;
		}

		private sealed class _Runnable_374 : java.lang.Runnable
		{
			public _Runnable_374(ZoomButtonsController _enclosing)
			{
				this._enclosing = _enclosing;
			}

			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public void run()
			{
				this._enclosing.refreshPositioningVariables();
				if (this._enclosing.mCallback != null)
				{
					this._enclosing.mCallback.onVisibilityChanged(true);
				}
			}

			private readonly ZoomButtonsController _enclosing;
		}

		/// <summary>Sets whether the zoom controls should be visible to the user.</summary>
		/// <remarks>Sets whether the zoom controls should be visible to the user.</remarks>
		/// <param name="visible">Whether the zoom controls should be visible to the user.</param>
		public virtual void setVisible(bool visible)
		{
			if (visible)
			{
				if (mOwnerView.getWindowToken() == null)
				{
					if (!mHandler.hasMessages(MSG_POST_SET_VISIBLE))
					{
						mHandler.sendEmptyMessage(MSG_POST_SET_VISIBLE);
					}
					return;
				}
				dismissControlsDelayed(ZOOM_CONTROLS_TIMEOUT);
			}
			if (mIsVisible == visible)
			{
				return;
			}
			mIsVisible = visible;
			if (visible)
			{
				if (mContainerLayoutParams.token == null)
				{
					mContainerLayoutParams.token = mOwnerView.getWindowToken();
				}
				mWindowManager.addView(mContainer, mContainerLayoutParams);
				if (mPostedVisibleInitializer == null)
				{
					mPostedVisibleInitializer = new _Runnable_374(this);
				}
				mHandler.post(mPostedVisibleInitializer);
				// Handle configuration changes when visible
				mContext.registerReceiver(mConfigurationChangedReceiver, mConfigurationChangedFilter
					);
				// Steal touches events from the owner
				mOwnerView.setOnTouchListener(this);
				mReleaseTouchListenerOnUp = false;
			}
			else
			{
				// Don't want to steal any more touches
				if (mTouchTargetView != null)
				{
					// We are still stealing the touch events for this touch
					// sequence, so release the touch listener later
					mReleaseTouchListenerOnUp = true;
				}
				else
				{
					mOwnerView.setOnTouchListener(null);
				}
				// No longer care about configuration changes
				mContext.unregisterReceiver(mConfigurationChangedReceiver);
				mWindowManager.removeView(mContainer);
				mHandler.removeCallbacks(mPostedVisibleInitializer);
				if (mCallback != null)
				{
					mCallback.onVisibilityChanged(false);
				}
			}
		}

		/// <summary>Gets the container that is the parent of the zoom controls.</summary>
		/// <remarks>
		/// Gets the container that is the parent of the zoom controls.
		/// <p>
		/// The client can add other views to this container to link them with the
		/// zoom controls.
		/// </remarks>
		/// <returns>
		/// The container of the zoom controls. It will be a layout that
		/// respects the gravity of a child's layout parameters.
		/// </returns>
		public virtual android.view.ViewGroup getContainer()
		{
			return mContainer;
		}

		/// <summary>Gets the view for the zoom controls.</summary>
		/// <remarks>Gets the view for the zoom controls.</remarks>
		/// <returns>The zoom controls view.</returns>
		public virtual android.view.View getZoomControls()
		{
			return mControls;
		}

		private void dismissControlsDelayed(int delay)
		{
			if (mAutoDismissControls)
			{
				mHandler.removeMessages(MSG_DISMISS_ZOOM_CONTROLS);
				mHandler.sendEmptyMessageDelayed(MSG_DISMISS_ZOOM_CONTROLS, delay);
			}
		}

		private void refreshPositioningVariables()
		{
			// if the mOwnerView is detached from window then skip.
			if (mOwnerView.getWindowToken() == null)
			{
				return;
			}
			// Position the zoom controls on the bottom of the owner view.
			int ownerHeight = mOwnerView.getHeight();
			int ownerWidth = mOwnerView.getWidth();
			// The gap between the top of the owner and the top of the container
			int containerOwnerYOffset = ownerHeight - mContainer.getHeight();
			// Calculate the owner view's bounds
			mOwnerView.getLocationOnScreen(mOwnerViewRawLocation);
			mContainerRawLocation[0] = mOwnerViewRawLocation[0];
			mContainerRawLocation[1] = mOwnerViewRawLocation[1] + containerOwnerYOffset;
			int[] ownerViewWindowLoc = mTempIntArray;
			mOwnerView.getLocationInWindow(ownerViewWindowLoc);
			// lp.x and lp.y should be relative to the owner's window top-left
			mContainerLayoutParams.x = ownerViewWindowLoc[0];
			mContainerLayoutParams.width = ownerWidth;
			mContainerLayoutParams.y = ownerViewWindowLoc[1] + containerOwnerYOffset;
			if (mIsVisible)
			{
				mWindowManager.updateViewLayout(mContainer, mContainerLayoutParams);
			}
		}

		private bool onContainerKey(android.view.KeyEvent @event)
		{
			int keyCode = @event.getKeyCode();
			if (isInterestingKey(keyCode))
			{
				if (keyCode == android.view.KeyEvent.KEYCODE_BACK)
				{
					if (@event.getAction() == android.view.KeyEvent.ACTION_DOWN && @event.getRepeatCount
						() == 0)
					{
						if (mOwnerView != null)
						{
							android.view.KeyEvent.DispatcherState ds = mOwnerView.getKeyDispatcherState();
							if (ds != null)
							{
								ds.startTracking(@event, this);
							}
						}
						return true;
					}
					else
					{
						if (@event.getAction() == android.view.KeyEvent.ACTION_UP && @event.isTracking() 
							&& !@event.isCanceled())
						{
							setVisible(false);
							return true;
						}
					}
				}
				else
				{
					dismissControlsDelayed(ZOOM_CONTROLS_TIMEOUT);
				}
				// Let the container handle the key
				return false;
			}
			else
			{
				android.view.ViewRootImpl viewRoot = getOwnerViewRootImpl();
				if (viewRoot != null)
				{
					viewRoot.dispatchKey(@event);
				}
				// We gave the key to the owner, don't let the container handle this key
				return true;
			}
		}

		private bool isInterestingKey(int keyCode)
		{
			switch (keyCode)
			{
				case android.view.KeyEvent.KEYCODE_DPAD_CENTER:
				case android.view.KeyEvent.KEYCODE_DPAD_UP:
				case android.view.KeyEvent.KEYCODE_DPAD_DOWN:
				case android.view.KeyEvent.KEYCODE_DPAD_LEFT:
				case android.view.KeyEvent.KEYCODE_DPAD_RIGHT:
				case android.view.KeyEvent.KEYCODE_ENTER:
				case android.view.KeyEvent.KEYCODE_BACK:
				{
					return true;
				}

				default:
				{
					return false;
				}
			}
		}

		private android.view.ViewRootImpl getOwnerViewRootImpl()
		{
			android.view.View rootViewOfOwner = mOwnerView.getRootView();
			if (rootViewOfOwner == null)
			{
				return null;
			}
			android.view.ViewParent parentOfRootView = rootViewOfOwner.getParent();
			if (parentOfRootView is android.view.ViewRootImpl)
			{
				return (android.view.ViewRootImpl)parentOfRootView;
			}
			else
			{
				return null;
			}
		}

		/// <hide>
		/// The ZoomButtonsController implements the OnTouchListener, but this
		/// does not need to be shown in its public API.
		/// </hide>
		[Sharpen.ImplementsInterface(@"android.view.View.OnTouchListener")]
		public virtual bool onTouch(android.view.View v, android.view.MotionEvent @event)
		{
			int action = @event.getAction();
			if (@event.getPointerCount() > 1)
			{
				// ZoomButtonsController doesn't handle mutitouch. Give up control.
				return false;
			}
			if (mReleaseTouchListenerOnUp)
			{
				// The controls were dismissed but we need to throw away all events until the up
				if (action == android.view.MotionEvent.ACTION_UP || action == android.view.MotionEvent
					.ACTION_CANCEL)
				{
					mOwnerView.setOnTouchListener(null);
					setTouchTargetView(null);
					mReleaseTouchListenerOnUp = false;
				}
				// Eat this event
				return true;
			}
			dismissControlsDelayed(ZOOM_CONTROLS_TIMEOUT);
			android.view.View targetView = mTouchTargetView;
			switch (action)
			{
				case android.view.MotionEvent.ACTION_DOWN:
				{
					targetView = findViewForTouch((int)@event.getRawX(), (int)@event.getRawY());
					setTouchTargetView(targetView);
					break;
				}

				case android.view.MotionEvent.ACTION_UP:
				case android.view.MotionEvent.ACTION_CANCEL:
				{
					setTouchTargetView(null);
					break;
				}
			}
			if (targetView != null)
			{
				// The upperleft corner of the target view in raw coordinates
				int targetViewRawX = mContainerRawLocation[0] + mTouchTargetWindowLocation[0];
				int targetViewRawY = mContainerRawLocation[1] + mTouchTargetWindowLocation[1];
				android.view.MotionEvent containerEvent = android.view.MotionEvent.obtain(@event);
				// Convert the motion event into the target view's coordinates (from
				// owner view's coordinates)
				containerEvent.offsetLocation(mOwnerViewRawLocation[0] - targetViewRawX, mOwnerViewRawLocation
					[1] - targetViewRawY);
				// These are floats because we need to potentially offset away this exact amount
				float containerX = containerEvent.getX();
				float containerY = containerEvent.getY();
				if (containerX < 0 && containerX > -ZOOM_CONTROLS_TOUCH_PADDING)
				{
					containerEvent.offsetLocation(-containerX, 0);
				}
				if (containerY < 0 && containerY > -ZOOM_CONTROLS_TOUCH_PADDING)
				{
					containerEvent.offsetLocation(0, -containerY);
				}
				bool retValue = targetView.dispatchTouchEvent(containerEvent);
				containerEvent.recycle();
				return retValue;
			}
			else
			{
				return false;
			}
		}

		private void setTouchTargetView(android.view.View view)
		{
			mTouchTargetView = view;
			if (view != null)
			{
				view.getLocationInWindow(mTouchTargetWindowLocation);
			}
		}

		/// <summary>Returns the View that should receive a touch at the given coordinates.</summary>
		/// <remarks>Returns the View that should receive a touch at the given coordinates.</remarks>
		/// <param name="rawX">The raw X.</param>
		/// <param name="rawY">The raw Y.</param>
		/// <returns>The view that should receive the touches, or null if there is not one.</returns>
		private android.view.View findViewForTouch(int rawX, int rawY)
		{
			// Reverse order so the child drawn on top gets first dibs.
			int containerCoordsX = rawX - mContainerRawLocation[0];
			int containerCoordsY = rawY - mContainerRawLocation[1];
			android.graphics.Rect frame = mTempRect;
			android.view.View closestChild = null;
			int closestChildDistanceSq = int.MaxValue;
			{
				for (int i = mContainer.getChildCount() - 1; i >= 0; i--)
				{
					android.view.View child = mContainer.getChildAt(i);
					if (child.getVisibility() != android.view.View.VISIBLE)
					{
						continue;
					}
					child.getHitRect(frame);
					if (frame.contains(containerCoordsX, containerCoordsY))
					{
						return child;
					}
					int distanceX;
					if (containerCoordsX >= frame.left && containerCoordsX <= frame.right)
					{
						distanceX = 0;
					}
					else
					{
						distanceX = System.Math.Min(System.Math.Abs(frame.left - containerCoordsX), System.Math.Abs
							(containerCoordsX - frame.right));
					}
					int distanceY;
					if (containerCoordsY >= frame.top && containerCoordsY <= frame.bottom)
					{
						distanceY = 0;
					}
					else
					{
						distanceY = System.Math.Min(System.Math.Abs(frame.top - containerCoordsY), System.Math.Abs
							(containerCoordsY - frame.bottom));
					}
					int distanceSq = distanceX * distanceX + distanceY * distanceY;
					if ((distanceSq < mTouchPaddingScaledSq) && (distanceSq < closestChildDistanceSq))
					{
						closestChild = child;
						closestChildDistanceSq = distanceSq;
					}
				}
			}
			return closestChild;
		}

		private void onPostConfigurationChanged()
		{
			dismissControlsDelayed(ZOOM_CONTROLS_TIMEOUT);
			refreshPositioningVariables();
		}

		/// <summary>
		/// Interface that will be called when the user performs an interaction that
		/// triggers some action, for example zooming.
		/// </summary>
		/// <remarks>
		/// Interface that will be called when the user performs an interaction that
		/// triggers some action, for example zooming.
		/// </remarks>
		public interface OnZoomListener
		{
			/// <summary>Called when the zoom controls' visibility changes.</summary>
			/// <remarks>Called when the zoom controls' visibility changes.</remarks>
			/// <param name="visible">Whether the zoom controls are visible.</param>
			void onVisibilityChanged(bool visible);

			/// <summary>Called when the owner view needs to be zoomed.</summary>
			/// <remarks>Called when the owner view needs to be zoomed.</remarks>
			/// <param name="zoomIn">The direction of the zoom: true to zoom in, false to zoom out.
			/// 	</param>
			void onZoom(bool zoomIn);
		}

		private class Container : android.widget.FrameLayout
		{
			public Container(ZoomButtonsController _enclosing, android.content.Context context
				) : base(context)
			{
				this._enclosing = _enclosing;
			}

			[Sharpen.OverridesMethod(@"android.view.View")]
			public override bool dispatchKeyEvent(android.view.KeyEvent @event)
			{
				return this._enclosing.onContainerKey(@event) ? true : base.dispatchKeyEvent(@event
					);
			}

			private readonly ZoomButtonsController _enclosing;
		}
	}
}

using Sharpen;

namespace android.view
{
	/// <summary>Provides a dedicated drawing surface embedded inside of a view hierarchy.
	/// 	</summary>
	/// <remarks>
	/// Provides a dedicated drawing surface embedded inside of a view hierarchy.
	/// You can control the format of this surface and, if you like, its size; the
	/// SurfaceView takes care of placing the surface at the correct location on the
	/// screen
	/// <p>The surface is Z ordered so that it is behind the window holding its
	/// SurfaceView; the SurfaceView punches a hole in its window to allow its
	/// surface to be displayed.  The view hierarchy will take care of correctly
	/// compositing with the Surface any siblings of the SurfaceView that would
	/// normally appear on top of it.  This can be used to place overlays such as
	/// buttons on top of the Surface, though note however that it can have an
	/// impact on performance since a full alpha-blended composite will be performed
	/// each time the Surface changes.
	/// <p>Access to the underlying surface is provided via the SurfaceHolder interface,
	/// which can be retrieved by calling
	/// <see cref="getHolder()">getHolder()</see>
	/// .
	/// <p>The Surface will be created for you while the SurfaceView's window is
	/// visible; you should implement
	/// <see cref="Callback.surfaceCreated(SurfaceHolder)">Callback.surfaceCreated(SurfaceHolder)
	/// 	</see>
	/// and
	/// <see cref="Callback.surfaceDestroyed(SurfaceHolder)">Callback.surfaceDestroyed(SurfaceHolder)
	/// 	</see>
	/// to discover when the
	/// Surface is created and destroyed as the window is shown and hidden.
	/// <p>One of the purposes of this class is to provide a surface in which a
	/// secondary thread can render into the screen.  If you are going to use it
	/// this way, you need to be aware of some threading semantics:
	/// <ul>
	/// <li> All SurfaceView and
	/// <see cref="Callback">Callback</see>
	/// methods will be called
	/// from the thread running the SurfaceView's window (typically the main thread
	/// of the application).  They thus need to correctly synchronize with any
	/// state that is also touched by the drawing thread.
	/// <li> You must ensure that the drawing thread only touches the underlying
	/// Surface while it is valid -- between
	/// <see cref="Callback.surfaceCreated(SurfaceHolder)">SurfaceHolder.Callback.surfaceCreated()
	/// 	</see>
	/// and
	/// <see cref="Callback.surfaceDestroyed(SurfaceHolder)">SurfaceHolder.Callback.surfaceDestroyed()
	/// 	</see>
	/// .
	/// </ul>
	/// </remarks>
	[Sharpen.Sharpened]
	public class SurfaceView : android.view.View
	{
		internal const string TAG = "SurfaceView";

		internal const bool DEBUG = false;

		internal const bool localLOGV = DEBUG ? true : false;

		internal readonly java.util.ArrayList<android.view.SurfaceHolderClass.Callback> mCallbacks
			 = new java.util.ArrayList<android.view.SurfaceHolderClass.Callback>();

		internal readonly int[] mLocation = new int[2];

		internal readonly java.util.concurrent.locks.ReentrantLock mSurfaceLock = new java.util.concurrent.locks.ReentrantLock
			();

		internal readonly android.view.Surface mSurface = new android.view.Surface();

		internal bool mDrawingStopped = true;

		internal readonly android.view.WindowManagerClass.LayoutParams mLayout = new android.view.WindowManagerClass
			.LayoutParams();

		internal android.view.IWindowSession mSession;

		private android.view.SurfaceView.MyWindow mWindow;

		internal readonly android.graphics.Rect mVisibleInsets = new android.graphics.Rect
			();

		internal readonly android.graphics.Rect mWinFrame = new android.graphics.Rect();

		internal readonly android.graphics.Rect mContentInsets = new android.graphics.Rect
			();

		internal readonly android.content.res.Configuration mConfiguration = new android.content.res.Configuration
			();

		internal const int KEEP_SCREEN_ON_MSG = 1;

		internal const int GET_NEW_SURFACE_MSG = 2;

		internal const int UPDATE_WINDOW_MSG = 3;

		internal int mWindowType = android.view.WindowManagerClass.LayoutParams.TYPE_APPLICATION_MEDIA;

		internal bool mIsCreating = false;

		private sealed class _Handler_113 : android.os.Handler
		{
			public _Handler_113(SurfaceView _enclosing)
			{
				this._enclosing = _enclosing;
			}

			[Sharpen.OverridesMethod(@"android.os.Handler")]
			public override void handleMessage(android.os.Message msg)
			{
				switch (msg.what)
				{
					case android.view.SurfaceView.KEEP_SCREEN_ON_MSG:
					{
						this._enclosing.setKeepScreenOn(msg.arg1 != 0);
						break;
					}

					case android.view.SurfaceView.GET_NEW_SURFACE_MSG:
					{
						this._enclosing.handleGetNewSurface();
						break;
					}

					case android.view.SurfaceView.UPDATE_WINDOW_MSG:
					{
						this._enclosing.updateWindow(false, false);
						break;
					}
				}
			}

			private readonly SurfaceView _enclosing;
		}

		internal readonly android.os.Handler mHandler;

		private sealed class _OnScrollChangedListener_131 : android.view.ViewTreeObserver
			.OnScrollChangedListener
		{
			public _OnScrollChangedListener_131(SurfaceView _enclosing)
			{
				this._enclosing = _enclosing;
			}

			[Sharpen.ImplementsInterface(@"android.view.ViewTreeObserver.OnScrollChangedListener"
				)]
			public void onScrollChanged()
			{
				this._enclosing.updateWindow(false, false);
			}

			private readonly SurfaceView _enclosing;
		}

		internal readonly android.view.ViewTreeObserver.OnScrollChangedListener mScrollChangedListener;

		internal bool mRequestedVisible = false;

		internal bool mWindowVisibility = false;

		internal bool mViewVisibility = false;

		internal int mRequestedWidth = -1;

		internal int mRequestedHeight = -1;

		internal int mRequestedFormat = android.graphics.PixelFormat.RGB_565;

		internal bool mHaveFrame = false;

		internal bool mDestroyReportNeeded = false;

		internal bool mNewSurfaceNeeded = false;

		internal long mLastLockTime = 0;

		internal bool mVisible = false;

		internal int mLeft = -1;

		internal int mTop = -1;

		internal int mWidth = -1;

		internal int mHeight = -1;

		internal int mFormat = -1;

		internal readonly android.graphics.Rect mSurfaceFrame = new android.graphics.Rect
			();

		internal android.graphics.Rect mTmpDirty;

		internal int mLastSurfaceWidth = -1;

		internal int mLastSurfaceHeight = -1;

		internal bool mUpdateWindowNeeded;

		internal bool mReportDrawNeeded;

		private android.content.res.CompatibilityInfo.Translator mTranslator;

		private sealed class _OnPreDrawListener_166 : android.view.ViewTreeObserver.OnPreDrawListener
		{
			public _OnPreDrawListener_166(SurfaceView _enclosing)
			{
				this._enclosing = _enclosing;
			}

			[Sharpen.ImplementsInterface(@"android.view.ViewTreeObserver.OnPreDrawListener")]
			public bool onPreDraw()
			{
				// reposition ourselves where the surface is 
				this._enclosing.mHaveFrame = this._enclosing.getWidth() > 0 && this._enclosing.getHeight
					() > 0;
				this._enclosing.updateWindow(false, false);
				return true;
			}

			private readonly SurfaceView _enclosing;
		}

		private readonly android.view.ViewTreeObserver.OnPreDrawListener mDrawListener;

		private bool mGlobalListenersAdded;

		public SurfaceView(android.content.Context context) : base(context)
		{
			mHandler = new _Handler_113(this);
			mScrollChangedListener = new _OnScrollChangedListener_131(this);
			mDrawListener = new _OnPreDrawListener_166(this);
			mSurfaceHolder = new _SurfaceHolder_682(this);
			init();
		}

		public SurfaceView(android.content.Context context, android.util.AttributeSet attrs
			) : base(context, attrs)
		{
			mHandler = new _Handler_113(this);
			mScrollChangedListener = new _OnScrollChangedListener_131(this);
			mDrawListener = new _OnPreDrawListener_166(this);
			mSurfaceHolder = new _SurfaceHolder_682(this);
			init();
		}

		public SurfaceView(android.content.Context context, android.util.AttributeSet attrs
			, int defStyle) : base(context, attrs, defStyle)
		{
			mHandler = new _Handler_113(this);
			mScrollChangedListener = new _OnScrollChangedListener_131(this);
			mDrawListener = new _OnPreDrawListener_166(this);
			mSurfaceHolder = new _SurfaceHolder_682(this);
			init();
		}

		private void init()
		{
			setWillNotDraw(true);
		}

		/// <summary>
		/// Return the SurfaceHolder providing access and control over this
		/// SurfaceView's underlying surface.
		/// </summary>
		/// <remarks>
		/// Return the SurfaceHolder providing access and control over this
		/// SurfaceView's underlying surface.
		/// </remarks>
		/// <returns>SurfaceHolder The holder of the surface.</returns>
		public virtual android.view.SurfaceHolder getHolder()
		{
			return mSurfaceHolder;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onAttachedToWindow()
		{
			base.onAttachedToWindow();
			mParent.requestTransparentRegion(this);
			mSession = getWindowSession();
			mLayout.token = getWindowToken();
			mLayout.setTitle(java.lang.CharSequenceProxy.Wrap("SurfaceView"));
			mViewVisibility = getVisibility() == VISIBLE;
			if (!mGlobalListenersAdded)
			{
				android.view.ViewTreeObserver observer = getViewTreeObserver();
				observer.addOnScrollChangedListener(mScrollChangedListener);
				observer.addOnPreDrawListener(mDrawListener);
				mGlobalListenersAdded = true;
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onWindowVisibilityChanged(int visibility)
		{
			base.onWindowVisibilityChanged(visibility);
			mWindowVisibility = visibility == VISIBLE;
			mRequestedVisible = mWindowVisibility && mViewVisibility;
			updateWindow(false, false);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void setVisibility(int visibility)
		{
			base.setVisibility(visibility);
			mViewVisibility = visibility == VISIBLE;
			mRequestedVisible = mWindowVisibility && mViewVisibility;
			updateWindow(false, false);
		}

		/// <summary>This method is not intended for general use.</summary>
		/// <remarks>
		/// This method is not intended for general use. It was created
		/// temporarily to improve performance of 3D layers in Launcher
		/// and should be removed and fixed properly.
		/// Do not call this method. Ever.
		/// </remarks>
		/// <hide></hide>
		protected internal virtual void showSurface()
		{
			if (mSession != null)
			{
				updateWindow(true, false);
			}
		}

		/// <summary>This method is not intended for general use.</summary>
		/// <remarks>
		/// This method is not intended for general use. It was created
		/// temporarily to improve performance of 3D layers in Launcher
		/// and should be removed and fixed properly.
		/// Do not call this method. Ever.
		/// </remarks>
		/// <hide></hide>
		protected internal virtual void hideSurface()
		{
			if (mSession != null && mWindow != null)
			{
				mSurfaceLock.@lock();
				try
				{
					android.util.DisplayMetrics metrics = getResources().getDisplayMetrics();
					mLayout.x = metrics.widthPixels * 3;
					mSession.relayout(mWindow, mWindow.mSeq, mLayout, mWidth, mHeight, VISIBLE, false
						, mWinFrame, mContentInsets, mVisibleInsets, mConfiguration, mSurface);
				}
				catch (android.os.RemoteException)
				{
				}
				finally
				{
					// Ignore
					mSurfaceLock.unlock();
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onDetachedFromWindow()
		{
			if (mGlobalListenersAdded)
			{
				android.view.ViewTreeObserver observer = getViewTreeObserver();
				observer.removeOnScrollChangedListener(mScrollChangedListener);
				observer.removeOnPreDrawListener(mDrawListener);
				mGlobalListenersAdded = false;
			}
			mRequestedVisible = false;
			updateWindow(false, false);
			mHaveFrame = false;
			if (mWindow != null)
			{
				try
				{
					mSession.remove(mWindow);
				}
				catch (android.os.RemoteException)
				{
				}
				// Not much we can do here...
				mWindow = null;
			}
			mSession = null;
			mLayout.token = null;
			base.onDetachedFromWindow();
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onMeasure(int widthMeasureSpec, int heightMeasureSpec
			)
		{
			int width = mRequestedWidth >= 0 ? resolveSizeAndState(mRequestedWidth, widthMeasureSpec
				, 0) : getDefaultSize(0, widthMeasureSpec);
			int height = mRequestedHeight >= 0 ? resolveSizeAndState(mRequestedHeight, heightMeasureSpec
				, 0) : getDefaultSize(0, heightMeasureSpec);
			setMeasuredDimension(width, height);
		}

		/// <hide></hide>
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override bool setFrame(int left, int top, int right, int bottom
			)
		{
			bool result = base.setFrame(left, top, right, bottom);
			updateWindow(false, false);
			return result;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool gatherTransparentRegion(android.graphics.Region region)
		{
			if (mWindowType == android.view.WindowManagerClass.LayoutParams.TYPE_APPLICATION_PANEL)
			{
				return base.gatherTransparentRegion(region);
			}
			bool opaque = true;
			if ((mPrivateFlags & SKIP_DRAW) == 0)
			{
				// this view draws, remove it from the transparent region
				opaque = base.gatherTransparentRegion(region);
			}
			else
			{
				if (region != null)
				{
					int w = getWidth();
					int h = getHeight();
					if (w > 0 && h > 0)
					{
						getLocationInWindow(mLocation);
						// otherwise, punch a hole in the whole hierarchy
						int l = mLocation[0];
						int t = mLocation[1];
						region.op(l, t, l + w, t + h, android.graphics.Region.Op.UNION);
					}
				}
			}
			if (android.graphics.PixelFormat.formatHasAlpha(mRequestedFormat))
			{
				opaque = false;
			}
			return opaque;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void draw(android.graphics.Canvas canvas)
		{
			if (mWindowType != android.view.WindowManagerClass.LayoutParams.TYPE_APPLICATION_PANEL)
			{
				// draw() is not called when SKIP_DRAW is set
				if ((mPrivateFlags & SKIP_DRAW) == 0)
				{
					// punch a whole in the view-hierarchy below us
					canvas.drawColor(0, android.graphics.PorterDuff.Mode.CLEAR);
				}
			}
			base.draw(canvas);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void dispatchDraw(android.graphics.Canvas canvas)
		{
			if (mWindowType != android.view.WindowManagerClass.LayoutParams.TYPE_APPLICATION_PANEL)
			{
				// if SKIP_DRAW is cleared, draw() has already punched a hole
				if ((mPrivateFlags & SKIP_DRAW) == SKIP_DRAW)
				{
					// punch a whole in the view-hierarchy below us
					canvas.drawColor(0, android.graphics.PorterDuff.Mode.CLEAR);
				}
			}
			base.dispatchDraw(canvas);
		}

		/// <summary>
		/// Control whether the surface view's surface is placed on top of another
		/// regular surface view in the window (but still behind the window itself).
		/// </summary>
		/// <remarks>
		/// Control whether the surface view's surface is placed on top of another
		/// regular surface view in the window (but still behind the window itself).
		/// This is typically used to place overlays on top of an underlying media
		/// surface view.
		/// <p>Note that this must be set before the surface view's containing
		/// window is attached to the window manager.
		/// <p>Calling this overrides any previous call to
		/// <see cref="setZOrderOnTop(bool)">setZOrderOnTop(bool)</see>
		/// .
		/// </remarks>
		public virtual void setZOrderMediaOverlay(bool isMediaOverlay)
		{
			mWindowType = isMediaOverlay ? android.view.WindowManagerClass.LayoutParams.TYPE_APPLICATION_MEDIA_OVERLAY
				 : android.view.WindowManagerClass.LayoutParams.TYPE_APPLICATION_MEDIA;
		}

		/// <summary>
		/// Control whether the surface view's surface is placed on top of its
		/// window.
		/// </summary>
		/// <remarks>
		/// Control whether the surface view's surface is placed on top of its
		/// window.  Normally it is placed behind the window, to allow it to
		/// (for the most part) appear to composite with the views in the
		/// hierarchy.  By setting this, you cause it to be placed above the
		/// window.  This means that none of the contents of the window this
		/// SurfaceView is in will be visible on top of its surface.
		/// <p>Note that this must be set before the surface view's containing
		/// window is attached to the window manager.
		/// <p>Calling this overrides any previous call to
		/// <see cref="setZOrderMediaOverlay(bool)">setZOrderMediaOverlay(bool)</see>
		/// .
		/// </remarks>
		public virtual void setZOrderOnTop(bool onTop)
		{
			if (onTop)
			{
				mWindowType = android.view.WindowManagerClass.LayoutParams.TYPE_APPLICATION_PANEL;
				// ensures the surface is placed below the IME
				mLayout.flags |= android.view.WindowManagerClass.LayoutParams.FLAG_ALT_FOCUSABLE_IM;
			}
			else
			{
				mWindowType = android.view.WindowManagerClass.LayoutParams.TYPE_APPLICATION_MEDIA;
				mLayout.flags &= ~android.view.WindowManagerClass.LayoutParams.FLAG_ALT_FOCUSABLE_IM;
			}
		}

		/// <summary>Hack to allow special layering of windows.</summary>
		/// <remarks>
		/// Hack to allow special layering of windows.  The type is one of the
		/// types in WindowManager.LayoutParams.  This is a hack so:
		/// </remarks>
		/// <hide></hide>
		public virtual void setWindowType(int type)
		{
			mWindowType = type;
		}

		private void updateWindow(bool force, bool redrawNeeded)
		{
			if (!mHaveFrame)
			{
				return;
			}
			android.view.ViewRootImpl viewRoot = (android.view.ViewRootImpl)getRootView().getParent
				();
			if (viewRoot != null)
			{
				mTranslator = viewRoot.mTranslator;
			}
			if (mTranslator != null)
			{
				mSurface.setCompatibilityTranslator(mTranslator);
			}
			int myWidth = mRequestedWidth;
			if (myWidth <= 0)
			{
				myWidth = getWidth();
			}
			int myHeight = mRequestedHeight;
			if (myHeight <= 0)
			{
				myHeight = getHeight();
			}
			getLocationInWindow(mLocation);
			bool creating = mWindow == null;
			bool formatChanged = mFormat != mRequestedFormat;
			bool sizeChanged = mWidth != myWidth || mHeight != myHeight;
			bool visibleChanged = mVisible != mRequestedVisible || mNewSurfaceNeeded;
			if (force || creating || formatChanged || sizeChanged || visibleChanged || mLeft 
				!= mLocation[0] || mTop != mLocation[1] || mUpdateWindowNeeded || mReportDrawNeeded
				 || redrawNeeded)
			{
				try
				{
					bool visible = mVisible = mRequestedVisible;
					mLeft = mLocation[0];
					mTop = mLocation[1];
					mWidth = myWidth;
					mHeight = myHeight;
					mFormat = mRequestedFormat;
					// Scaling/Translate window's layout here because mLayout is not used elsewhere.
					// Places the window relative
					mLayout.x = mLeft;
					mLayout.y = mTop;
					mLayout.width = getWidth();
					mLayout.height = getHeight();
					if (mTranslator != null)
					{
						mTranslator.translateLayoutParamsInAppWindowToScreen(mLayout);
					}
					mLayout.format = mRequestedFormat;
					mLayout.flags |= android.view.WindowManagerClass.LayoutParams.FLAG_NOT_TOUCHABLE 
						| android.view.WindowManagerClass.LayoutParams.FLAG_NOT_FOCUSABLE | android.view.WindowManagerClass
						.LayoutParams.FLAG_LAYOUT_NO_LIMITS | android.view.WindowManagerClass.LayoutParams
						.FLAG_SCALED | android.view.WindowManagerClass.LayoutParams.FLAG_NOT_FOCUSABLE |
						 android.view.WindowManagerClass.LayoutParams.FLAG_NOT_TOUCHABLE;
					if (!getContext().getResources().getCompatibilityInfo().supportsScreen())
					{
						mLayout.flags |= android.view.WindowManagerClass.LayoutParams.FLAG_COMPATIBLE_WINDOW;
					}
					if (mWindow == null)
					{
						mWindow = new android.view.SurfaceView.MyWindow(this);
						mLayout.type = mWindowType;
						mLayout.gravity = android.view.Gravity.LEFT | android.view.Gravity.TOP;
						mSession.addWithoutInputChannel(mWindow, mWindow.mSeq, mLayout, mVisible ? VISIBLE
							 : GONE, mContentInsets);
					}
					if (visibleChanged && (!visible || mNewSurfaceNeeded))
					{
						reportSurfaceDestroyed();
					}
					mNewSurfaceNeeded = false;
					bool realSizeChanged;
					bool reportDrawNeeded;
					mSurfaceLock.@lock();
					try
					{
						mUpdateWindowNeeded = false;
						reportDrawNeeded = mReportDrawNeeded;
						mReportDrawNeeded = false;
						mDrawingStopped = !visible;
						int relayoutResult = mSession.relayout(mWindow, mWindow.mSeq, mLayout, mWidth, mHeight
							, visible ? VISIBLE : GONE, false, mWinFrame, mContentInsets, mVisibleInsets, mConfiguration
							, mSurface);
						if ((relayoutResult & android.view.WindowManagerImpl.RELAYOUT_FIRST_TIME) != 0)
						{
							mReportDrawNeeded = true;
						}
						mSurfaceFrame.left = 0;
						mSurfaceFrame.top = 0;
						if (mTranslator == null)
						{
							mSurfaceFrame.right = mWinFrame.width();
							mSurfaceFrame.bottom = mWinFrame.height();
						}
						else
						{
							float appInvertedScale = mTranslator.applicationInvertedScale;
							mSurfaceFrame.right = (int)(mWinFrame.width() * appInvertedScale + 0.5f);
							mSurfaceFrame.bottom = (int)(mWinFrame.height() * appInvertedScale + 0.5f);
						}
						int surfaceWidth = mSurfaceFrame.right;
						int surfaceHeight = mSurfaceFrame.bottom;
						realSizeChanged = mLastSurfaceWidth != surfaceWidth || mLastSurfaceHeight != surfaceHeight;
						mLastSurfaceWidth = surfaceWidth;
						mLastSurfaceHeight = surfaceHeight;
					}
					finally
					{
						mSurfaceLock.unlock();
					}
					try
					{
						redrawNeeded |= creating | reportDrawNeeded;
						if (visible)
						{
							mDestroyReportNeeded = true;
							android.view.SurfaceHolderClass.Callback[] callbacks;
							lock (mCallbacks)
							{
								callbacks = new android.view.SurfaceHolderClass.Callback[mCallbacks.size()];
								mCallbacks.toArray(callbacks);
							}
							if (visibleChanged)
							{
								mIsCreating = true;
								foreach (android.view.SurfaceHolderClass.Callback c in callbacks)
								{
									c.surfaceCreated(mSurfaceHolder);
								}
							}
							if (creating || formatChanged || sizeChanged || visibleChanged || realSizeChanged)
							{
								foreach (android.view.SurfaceHolderClass.Callback c in callbacks)
								{
									c.surfaceChanged(mSurfaceHolder, mFormat, myWidth, myHeight);
								}
							}
							if (redrawNeeded)
							{
								foreach (android.view.SurfaceHolderClass.Callback c in callbacks)
								{
									if (c is android.view.SurfaceHolderClass.Callback2)
									{
										((android.view.SurfaceHolderClass.Callback2)c).surfaceRedrawNeeded(mSurfaceHolder
											);
									}
								}
							}
						}
						else
						{
							mSurface.release();
						}
					}
					finally
					{
						mIsCreating = false;
						if (redrawNeeded)
						{
							mSession.finishDrawing(mWindow);
						}
					}
				}
				catch (android.os.RemoteException)
				{
				}
			}
		}

		private void reportSurfaceDestroyed()
		{
			if (mDestroyReportNeeded)
			{
				mDestroyReportNeeded = false;
				android.view.SurfaceHolderClass.Callback[] callbacks;
				lock (mCallbacks)
				{
					callbacks = new android.view.SurfaceHolderClass.Callback[mCallbacks.size()];
					mCallbacks.toArray(callbacks);
				}
				foreach (android.view.SurfaceHolderClass.Callback c in callbacks)
				{
					c.surfaceDestroyed(mSurfaceHolder);
				}
			}
			base.onDetachedFromWindow();
		}

		internal virtual void handleGetNewSurface()
		{
			mNewSurfaceNeeded = true;
			updateWindow(false, false);
		}

		/// <summary>
		/// Check to see if the surface has fixed size dimensions or if the surface's
		/// dimensions are dimensions are dependent on its current layout.
		/// </summary>
		/// <remarks>
		/// Check to see if the surface has fixed size dimensions or if the surface's
		/// dimensions are dimensions are dependent on its current layout.
		/// </remarks>
		/// <returns>true if the surface has dimensions that are fixed in size</returns>
		/// <hide></hide>
		public virtual bool isFixedSize()
		{
			return (mRequestedWidth != -1 || mRequestedHeight != -1);
		}

		private class MyWindow : android.view.@internal.BaseIWindow
		{
			internal readonly java.lang.@ref.WeakReference<android.view.SurfaceView> mSurfaceView;

			public MyWindow(android.view.SurfaceView surfaceView)
			{
				mSurfaceView = new java.lang.@ref.WeakReference<android.view.SurfaceView>(surfaceView
					);
			}

			[Sharpen.ImplementsInterface(@"android.view.IWindow")]
			public override void resized(int w, int h, android.graphics.Rect coveredInsets, android.graphics.Rect
				 visibleInsets, bool reportDraw, android.content.res.Configuration newConfig)
			{
				android.view.SurfaceView surfaceView = mSurfaceView.get();
				if (surfaceView != null)
				{
					surfaceView.mSurfaceLock.@lock();
					try
					{
						if (reportDraw)
						{
							surfaceView.mUpdateWindowNeeded = true;
							surfaceView.mReportDrawNeeded = true;
							surfaceView.mHandler.sendEmptyMessage(UPDATE_WINDOW_MSG);
						}
						else
						{
							if (surfaceView.mWinFrame.width() != w || surfaceView.mWinFrame.height() != h)
							{
								surfaceView.mUpdateWindowNeeded = true;
								surfaceView.mHandler.sendEmptyMessage(UPDATE_WINDOW_MSG);
							}
						}
					}
					finally
					{
						surfaceView.mSurfaceLock.unlock();
					}
				}
			}

			[Sharpen.ImplementsInterface(@"android.view.IWindow")]
			public override void dispatchAppVisibility(bool visible)
			{
			}

			// The point of SurfaceView is to let the app control the surface.
			[Sharpen.ImplementsInterface(@"android.view.IWindow")]
			public override void dispatchGetNewSurface()
			{
				android.view.SurfaceView surfaceView = mSurfaceView.get();
				if (surfaceView != null)
				{
					android.os.Message msg = surfaceView.mHandler.obtainMessage(GET_NEW_SURFACE_MSG);
					surfaceView.mHandler.sendMessage(msg);
				}
			}

			[Sharpen.ImplementsInterface(@"android.view.IWindow")]
			public override void windowFocusChanged(bool hasFocus, bool touchEnabled)
			{
				android.util.Log.w("SurfaceView", "Unexpected focus in surface: focus=" + hasFocus
					 + ", touchEnabled=" + touchEnabled);
			}

			[Sharpen.ImplementsInterface(@"android.view.IWindow")]
			public override void executeCommand(string command, string parameters, android.os.ParcelFileDescriptor
				 @out)
			{
			}

			internal int mCurWidth = -1;

			internal int mCurHeight = -1;
		}

		private sealed class _SurfaceHolder_682 : android.view.SurfaceHolder
		{
			public _SurfaceHolder_682(SurfaceView _enclosing)
			{
				this._enclosing = _enclosing;
			}

			internal const string LOG_TAG = "SurfaceHolder";

			[Sharpen.ImplementsInterface(@"android.view.SurfaceHolder")]
			public bool isCreating()
			{
				return this._enclosing.mIsCreating;
			}

			[Sharpen.ImplementsInterface(@"android.view.SurfaceHolder")]
			public void addCallback(android.view.SurfaceHolderClass.Callback callback)
			{
				lock (this._enclosing.mCallbacks)
				{
					// This is a linear search, but in practice we'll 
					// have only a couple callbacks, so it doesn't matter.
					if (this._enclosing.mCallbacks.contains(callback) == false)
					{
						this._enclosing.mCallbacks.add(callback);
					}
				}
			}

			[Sharpen.ImplementsInterface(@"android.view.SurfaceHolder")]
			public void removeCallback(android.view.SurfaceHolderClass.Callback callback)
			{
				lock (this._enclosing.mCallbacks)
				{
					this._enclosing.mCallbacks.remove(callback);
				}
			}

			[Sharpen.ImplementsInterface(@"android.view.SurfaceHolder")]
			public void setFixedSize(int width, int height)
			{
				if (this._enclosing.mRequestedWidth != width || this._enclosing.mRequestedHeight 
					!= height)
				{
					this._enclosing.mRequestedWidth = width;
					this._enclosing.mRequestedHeight = height;
					this._enclosing.requestLayout();
				}
			}

			[Sharpen.ImplementsInterface(@"android.view.SurfaceHolder")]
			public void setSizeFromLayout()
			{
				if (this._enclosing.mRequestedWidth != -1 || this._enclosing.mRequestedHeight != 
					-1)
				{
					this._enclosing.mRequestedWidth = this._enclosing.mRequestedHeight = -1;
					this._enclosing.requestLayout();
				}
			}

			[Sharpen.ImplementsInterface(@"android.view.SurfaceHolder")]
			public void setFormat(int format)
			{
				// for backward compatibility reason, OPAQUE always
				// means 565 for SurfaceView
				if (format == android.graphics.PixelFormat.OPAQUE)
				{
					format = android.graphics.PixelFormat.RGB_565;
				}
				this._enclosing.mRequestedFormat = format;
				if (this._enclosing.mWindow != null)
				{
					this._enclosing.updateWindow(false, false);
				}
			}

			[System.ObsoleteAttribute(@"setType is now ignored.")]
			[Sharpen.ImplementsInterface(@"android.view.SurfaceHolder")]
			public void setType(int type)
			{
			}

			[Sharpen.ImplementsInterface(@"android.view.SurfaceHolder")]
			public void setKeepScreenOn(bool screenOn)
			{
				android.os.Message msg = this._enclosing.mHandler.obtainMessage(android.view.SurfaceView
					.KEEP_SCREEN_ON_MSG);
				msg.arg1 = screenOn ? 1 : 0;
				this._enclosing.mHandler.sendMessage(msg);
			}

			[Sharpen.ImplementsInterface(@"android.view.SurfaceHolder")]
			public android.graphics.Canvas lockCanvas()
			{
				return this.internalLockCanvas(null);
			}

			[Sharpen.ImplementsInterface(@"android.view.SurfaceHolder")]
			public android.graphics.Canvas lockCanvas(android.graphics.Rect dirty)
			{
				return this.internalLockCanvas(dirty);
			}

			private android.graphics.Canvas internalLockCanvas(android.graphics.Rect dirty)
			{
				this._enclosing.mSurfaceLock.@lock();
				android.graphics.Canvas c = null;
				if (!this._enclosing.mDrawingStopped && this._enclosing.mWindow != null)
				{
					if (dirty == null)
					{
						if (this._enclosing.mTmpDirty == null)
						{
							this._enclosing.mTmpDirty = new android.graphics.Rect();
						}
						this._enclosing.mTmpDirty.set(this._enclosing.mSurfaceFrame);
						dirty = this._enclosing.mTmpDirty;
					}
					try
					{
						c = this._enclosing.mSurface.lockCanvas(dirty);
					}
					catch (System.Exception e)
					{
						android.util.Log.e(LOG_TAG, "Exception locking surface", e);
					}
				}
				if (c != null)
				{
					this._enclosing.mLastLockTime = android.os.SystemClock.uptimeMillis();
					return c;
				}
				// If the Surface is not ready to be drawn, then return null,
				// but throttle calls to this function so it isn't called more
				// than every 100ms.
				long now = android.os.SystemClock.uptimeMillis();
				long nextTime = this._enclosing.mLastLockTime + 100;
				if (nextTime > now)
				{
					try
					{
						java.lang.Thread.sleep(nextTime - now);
					}
					catch (System.Exception)
					{
					}
					now = android.os.SystemClock.uptimeMillis();
				}
				this._enclosing.mLastLockTime = now;
				this._enclosing.mSurfaceLock.unlock();
				return null;
			}

			[Sharpen.ImplementsInterface(@"android.view.SurfaceHolder")]
			public void unlockCanvasAndPost(android.graphics.Canvas canvas)
			{
				this._enclosing.mSurface.unlockCanvasAndPost(canvas);
				this._enclosing.mSurfaceLock.unlock();
			}

			[Sharpen.ImplementsInterface(@"android.view.SurfaceHolder")]
			public android.view.Surface getSurface()
			{
				return this._enclosing.mSurface;
			}

			[Sharpen.ImplementsInterface(@"android.view.SurfaceHolder")]
			public android.graphics.Rect getSurfaceFrame()
			{
				return this._enclosing.mSurfaceFrame;
			}

			private readonly SurfaceView _enclosing;
		}

		private android.view.SurfaceHolder mSurfaceHolder;
	}
}

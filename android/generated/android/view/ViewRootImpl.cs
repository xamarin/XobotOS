using Sharpen;

namespace android.view
{
	/// <summary>
	/// The top of a view hierarchy, implementing the needed protocol between View
	/// and the WindowManager.
	/// </summary>
	/// <remarks>
	/// The top of a view hierarchy, implementing the needed protocol between View
	/// and the WindowManager.  This is for the most part an internal implementation
	/// detail of
	/// <see cref="WindowManagerImpl">WindowManagerImpl</see>
	/// .
	/// <hide></hide>
	/// </remarks>
	[Sharpen.Sharpened]
	public sealed partial class ViewRootImpl : android.os.Handler, android.view.ViewParent
		, android.view.View.AttachInfo.Callbacks, android.view.HardwareRenderer.HardwareDrawCallbacks
	{
		internal const string TAG = "ViewRootImpl";

		internal const bool DBG = false;

		internal const bool LOCAL_LOGV = false;

		/// <noinspection>PointlessBooleanExpression</noinspection>
		internal const bool DEBUG_DRAW = false || LOCAL_LOGV;

		internal const bool DEBUG_LAYOUT = false || LOCAL_LOGV;

		internal const bool DEBUG_DIALOG = false || LOCAL_LOGV;

		internal const bool DEBUG_INPUT_RESIZE = false || LOCAL_LOGV;

		internal const bool DEBUG_ORIENTATION = false || LOCAL_LOGV;

		internal const bool DEBUG_TRACKBALL = false || LOCAL_LOGV;

		internal const bool DEBUG_IMF = false || LOCAL_LOGV;

		internal const bool DEBUG_CONFIGURATION = false || LOCAL_LOGV;

		internal const bool DEBUG_FPS = false;

		internal const bool WATCH_POINTER = false;

		/// <summary>
		/// Set this system property to true to force the view hierarchy to render
		/// at 60 Hz.
		/// </summary>
		/// <remarks>
		/// Set this system property to true to force the view hierarchy to render
		/// at 60 Hz. This can be used to measure the potential framerate.
		/// </remarks>
		internal const string PROPERTY_PROFILE_RENDERING = "viewancestor.profile_rendering";

		internal const bool MEASURE_LATENCY = false;

		private static android.os.LatencyTimer lt;

		/// <summary>
		/// Maximum time we allow the user to roll the trackball enough to generate
		/// a key event, before resetting the counters.
		/// </summary>
		/// <remarks>
		/// Maximum time we allow the user to roll the trackball enough to generate
		/// a key event, before resetting the counters.
		/// </remarks>
		internal const int MAX_TRACKBALL_DELAY = 250;

		internal static android.view.IWindowSession sWindowSession;

		internal static readonly object mStaticInit = new object();

		internal static bool mInitialized = false;

		internal static readonly java.lang.ThreadLocal<android.view.ViewRootImpl.RunQueue
			> sRunQueues = new java.lang.ThreadLocal<android.view.ViewRootImpl.RunQueue>();

		internal static readonly java.util.ArrayList<java.lang.Runnable> sFirstDrawHandlers
			 = new java.util.ArrayList<java.lang.Runnable>();

		internal static bool sFirstDrawComplete = false;

		internal static readonly java.util.ArrayList<android.content.ComponentCallbacks> 
			sConfigCallbacks = new java.util.ArrayList<android.content.ComponentCallbacks>();

		internal long mLastTrackballTime = 0;

		internal readonly android.view.ViewRootImpl.TrackballAxis mTrackballAxisX = new android.view.ViewRootImpl
			.TrackballAxis();

		internal readonly android.view.ViewRootImpl.TrackballAxis mTrackballAxisY = new android.view.ViewRootImpl
			.TrackballAxis();

		internal int mLastJoystickXDirection;

		internal int mLastJoystickYDirection;

		internal int mLastJoystickXKeyCode;

		internal int mLastJoystickYKeyCode;

		internal readonly int[] mTmpLocation = new int[2];

		internal readonly android.util.TypedValue mTmpValue = new android.util.TypedValue
			();

		internal readonly android.view.ViewRootImpl.InputMethodCallback mInputMethodCallback;

		internal readonly android.util.SparseArray<object> mPendingEvents = new android.util.SparseArray
			<object>();

		internal int mPendingEventSeq = 0;

		internal readonly java.lang.Thread mThread;

		internal readonly android.view.WindowLeaked mLocation;

		internal readonly android.view.WindowManagerClass.LayoutParams mWindowAttributes = 
			new android.view.WindowManagerClass.LayoutParams();

		internal readonly android.view.ViewRootImpl.W mWindow;

		internal readonly int mTargetSdkVersion;

		internal int mSeq;

		internal android.view.View mView;

		internal android.view.View mFocusedView;

		internal android.view.View mRealFocusedView;

		internal int mViewVisibility;

		internal bool mAppVisible = true;

		internal int mOrigWindowType = -1;

		internal bool mStopped = false;

		internal bool mLastInCompatMode = false;

		internal android.view.SurfaceHolderClass.Callback2 mSurfaceHolderCallback;

		internal android.view.@internal.BaseSurfaceHolder mSurfaceHolder;

		internal bool mIsCreating;

		internal bool mDrawingAllowed;

		internal readonly android.graphics.Region mTransparentRegion;

		internal readonly android.graphics.Region mPreviousTransparentRegion;

		internal int mWidth;

		internal int mHeight;

		internal android.graphics.Rect mDirty;

		internal readonly android.graphics.Rect mCurrentDirty = new android.graphics.Rect
			();

		internal readonly android.graphics.Rect mPreviousDirty = new android.graphics.Rect
			();

		internal bool mIsAnimating;

		internal android.content.res.CompatibilityInfo.Translator mTranslator;

		internal readonly android.view.View.AttachInfo mAttachInfo;

		internal android.view.InputChannel mInputChannel;

		internal android.view.InputQueue.Callback mInputQueueCallback;

		internal android.view.InputQueue mInputQueue;

		internal android.view.FallbackEventHandler mFallbackEventHandler;

		internal readonly android.graphics.Rect mTempRect;

		internal readonly android.graphics.Rect mVisRect;

		internal bool mTraversalScheduled;

		internal long mLastTraversalFinishedTimeNanos;

		internal long mLastDrawDurationNanos;

		internal bool mWillDrawSoon;

		internal bool mLayoutRequested;

		internal bool mFirst;

		internal bool mReportNextDraw;

		internal bool mFullRedrawNeeded;

		internal bool mNewSurfaceNeeded;

		internal bool mHasHadWindowFocus;

		internal bool mLastWasImTarget;

		internal bool mWindowAttributesChanged = false;

		internal int mWindowAttributesChangesFlag = 0;

		private readonly android.view.Surface mSurface;

		internal bool mAdded;

		internal bool mAddedTouchMode;

		internal android.view.CompatibilityInfoHolder mCompatibilityInfo;

		internal int mAddNesting;

		internal readonly android.graphics.Rect mWinFrame;

		internal readonly android.graphics.Rect mPendingVisibleInsets = new android.graphics.Rect
			();

		internal readonly android.graphics.Rect mPendingContentInsets = new android.graphics.Rect
			();

		internal readonly android.view.ViewTreeObserver.InternalInsetsInfo mLastGivenInsets
			 = new android.view.ViewTreeObserver.InternalInsetsInfo();

		internal readonly android.content.res.Configuration mLastConfiguration = new android.content.res.Configuration
			();

		internal readonly android.content.res.Configuration mPendingConfiguration = new android.content.res.Configuration
			();

		[Sharpen.Stub]
		internal class ResizedInfo
		{
			internal android.graphics.Rect coveredInsets;

			internal android.graphics.Rect visibleInsets;

			internal android.content.res.Configuration newConfig;

			internal ResizedInfo(ViewRootImpl _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly ViewRootImpl _enclosing;
		}

		internal bool mScrollMayChange;

		internal int mSoftInputMode;

		internal android.view.View mLastScrolledFocus;

		internal int mScrollY;

		internal int mCurScrollY;

		internal android.widget.Scroller mScroller;

		internal android.view.HardwareLayer mResizeBuffer;

		internal long mResizeBufferStartTime;

		internal int mResizeBufferDuration;

		internal static readonly android.view.animation.Interpolator mResizeInterpolator;

		private java.util.ArrayList<android.animation.LayoutTransition> mPendingTransitions;

		internal readonly android.view.ViewConfiguration mViewConfiguration;

		internal android.content.ClipDescription mDragDescription;

		internal android.view.View mCurrentDragView;

		internal volatile object mLocalDragState;

		internal readonly android.graphics.PointF mDragPoint = new android.graphics.PointF
			();

		internal readonly android.graphics.PointF mLastTouchPoint = new android.graphics.PointF
			();

		private bool mProfileRendering;

		private java.lang.Thread mRenderProfiler;

		private volatile bool mRenderProfilingEnabled;

		private long mFpsStartTime = -1;

		private long mFpsPrevTime = -1;

		private int mFpsNumFrames;

		/// <summary>
		/// see
		/// <see cref="playSoundEffect(int)">playSoundEffect(int)</see>
		/// </summary>
		internal android.media.AudioManager mAudioManager;

		internal readonly android.view.accessibility.AccessibilityManager mAccessibilityManager;

		internal android.view.ViewRootImpl.AccessibilityInteractionController mAccessibilityInteractionContrtoller;

		internal android.view.ViewRootImpl.AccessibilityInteractionConnectionManager mAccessibilityInteractionConnectionManager;

		private android.view.ViewRootImpl.SendWindowContentChangedAccessibilityEvent mSendWindowContentChangedAccessibilityEvent;

		private readonly int mDensity;

		/// <summary>Consistency verifier for debugging purposes.</summary>
		/// <remarks>Consistency verifier for debugging purposes.</remarks>
		protected internal readonly android.view.InputEventConsistencyVerifier mInputEventConsistencyVerifier;

		[Sharpen.Stub]
		public static android.view.IWindowSession getWindowSession(android.os.Looper mainLooper
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal sealed class SystemUiVisibilityInfo
		{
			internal int seq;

			internal int globalVisibility;

			internal int localValue;

			internal int localChanges;
		}

		[Sharpen.Stub]
		public ViewRootImpl(android.content.Context context) : base()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void addFirstDrawHandler(java.lang.Runnable callback)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void addConfigCallback(android.content.ComponentCallbacks callback)
		{
			throw new System.NotImplementedException();
		}

		private bool mProfile = false;

		[Sharpen.Stub]
		public void profile()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void setView(android.view.View view, android.view.WindowManagerClass.LayoutParams
			 attrs, android.view.View panelParentView)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void destroyHardwareResources()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal void destroyHardwareLayers()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void enableHardwareAcceleration(android.view.WindowManagerClass.LayoutParams
			 attrs)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.view.View getView()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal android.view.WindowLeaked getLocation()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal void setLayoutParams(android.view.WindowManagerClass.LayoutParams attrs, 
			bool newView)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal void handleAppVisibility(bool visible)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal void handleGetNewSurface()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.ViewParent")]
		public void requestLayout()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.ViewParent")]
		public bool isLayoutRequested()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.ViewParent")]
		public void invalidateChild(android.view.View child, android.graphics.Rect dirty)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal void invalidate()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal void setStopped(bool stopped)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.ViewParent")]
		public android.view.ViewParent getParent()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.ViewParent")]
		public android.view.ViewParent invalidateChildInParent(int[] location, android.graphics.Rect
			 dirty)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.ViewParent")]
		public bool getChildVisibleRect(android.view.View child, android.graphics.Rect r, 
			android.graphics.Point offset)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.ViewParent")]
		public void bringChildToFront(android.view.View child)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void scheduleTraversals()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void unscheduleTraversals()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal int getHostVisibility()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal void disposeResizeBuffer()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void requestTransitionStart(android.animation.LayoutTransition transition)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void performTraversals()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.ViewParent")]
		public void requestTransparentRegion(android.view.View child)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private int getRootMeasureSpec(int windowSize, int rootDimension)
		{
			throw new System.NotImplementedException();
		}

		internal int mHardwareYOffset;

		internal int mResizeAlpha;

		internal readonly android.graphics.Paint mResizePaint = new android.graphics.Paint
			();

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.HardwareRenderer.HardwareDrawCallbacks"
			)]
		public void onHardwarePreDraw(android.view.HardwareCanvas canvas)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.HardwareRenderer.HardwareDrawCallbacks"
			)]
		public void onHardwarePostDraw(android.view.HardwareCanvas canvas)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal void outputDisplayList(android.view.View view)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void profileRendering(bool enabled)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void trackFPS()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void draw(bool fullRedrawNeeded)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal bool scrollToRectOrFocus(android.graphics.Rect rectangle, bool immediate
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.ViewParent")]
		public void requestChildFocus(android.view.View child, android.view.View focused)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.ViewParent")]
		public void clearChildFocus(android.view.View child)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.ViewParent")]
		public void focusableViewAvailable(android.view.View v)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.ViewParent")]
		public void recomputeViewAttributes(android.view.View child)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal void dispatchDetachedFromWindow()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal void updateConfiguration(android.content.res.Configuration config, bool 
			force)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static bool isViewDescendantOf(android.view.View child, android.view.View
			 parent)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void forceLayout(android.view.View view)
		{
			throw new System.NotImplementedException();
		}

		public const int DO_TRAVERSAL = 1000;

		public const int DIE = 1001;

		public const int RESIZED = 1002;

		public const int RESIZED_REPORT = 1003;

		public const int WINDOW_FOCUS_CHANGED = 1004;

		public const int DISPATCH_KEY = 1005;

		public const int DISPATCH_POINTER = 1006;

		public const int DISPATCH_TRACKBALL = 1007;

		public const int DISPATCH_APP_VISIBILITY = 1008;

		public const int DISPATCH_GET_NEW_SURFACE = 1009;

		public const int FINISHED_EVENT = 1010;

		public const int DISPATCH_KEY_FROM_IME = 1011;

		public const int FINISH_INPUT_CONNECTION = 1012;

		public const int CHECK_FOCUS = 1013;

		public const int CLOSE_SYSTEM_DIALOGS = 1014;

		public const int DISPATCH_DRAG_EVENT = 1015;

		public const int DISPATCH_DRAG_LOCATION_EVENT = 1016;

		public const int DISPATCH_SYSTEM_UI_VISIBILITY = 1017;

		public const int DISPATCH_GENERIC_MOTION = 1018;

		public const int UPDATE_CONFIGURATION = 1019;

		public const int DO_PERFORM_ACCESSIBILITY_ACTION = 1020;

		public const int DO_FIND_ACCESSIBLITY_NODE_INFO_BY_ACCESSIBILITY_ID = 1021;

		public const int DO_FIND_ACCESSIBLITY_NODE_INFO_BY_VIEW_ID = 1022;

		public const int DO_FIND_ACCESSIBLITY_NODE_INFO_BY_VIEW_TEXT = 1023;

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.os.Handler")]
		public override string getMessageName(android.os.Message message)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.os.Handler")]
		public override void handleMessage(android.os.Message msg)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void startInputEvent(android.view.InputQueue.FinishedCallback finishedCallback
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void finishInputEvent(android.view.InputEvent @event, bool handled)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal bool ensureTouchMode(bool inTouchMode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private bool ensureTouchModeLocally(bool inTouchMode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private bool enterTouchMode()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private android.view.ViewGroup findAncestorToTakeFocusInTouchMode(android.view.View
			 focused)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private bool leaveTouchMode()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void deliverPointerEvent(android.view.MotionEvent @event, bool sendDone)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void finishMotionEvent(android.view.MotionEvent @event, bool sendDone, bool
			 handled)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void deliverTrackballEvent(android.view.MotionEvent @event, bool sendDone
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void deliverGenericMotionEvent(android.view.MotionEvent @event, bool sendDone
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void updateJoystickDirection(android.view.MotionEvent @event, bool synthesizeNewKeys
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static int joystickAxisValueToDirection(float value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static bool isNavigationKey(android.view.KeyEvent keyEvent)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static bool isTypingKey(android.view.KeyEvent keyEvent)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private bool checkForLeavingTouchModeAndConsume(android.view.KeyEvent @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal int enqueuePendingEvent(object @event, bool sendDone)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal object retrievePendingEvent(int seq)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void deliverKeyEvent(android.view.KeyEvent @event, bool sendDone)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void handleFinishedEvent(int seq, bool handled)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void deliverKeyEventPostIme(android.view.KeyEvent @event, bool sendDone)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void finishKeyEvent(android.view.KeyEvent @event, bool sendDone, bool handled
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal void setLocalDragState(object obj)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void handleDragEvent(android.view.DragEvent @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal void handleDispatchSystemUiVisibilityChanged(android.view.ViewRootImpl.SystemUiVisibilityInfo
			 args)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void getLastTouchPoint(android.graphics.Point outLocation)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void setDragFocus(android.view.View newDragTarget)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private android.media.AudioManager getAudioManager()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal android.view.ViewRootImpl.AccessibilityInteractionController getAccessibilityInteractionController
			()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private int relayoutWindow(android.view.WindowManagerClass.LayoutParams @params, 
			int viewVisibility, bool insetsPending)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.View.AttachInfo.Callbacks")]
		public void playSoundEffect(int effectId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.View.AttachInfo.Callbacks")]
		public bool performHapticFeedback(int effectId, bool always)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.ViewParent")]
		public android.view.View focusSearch(android.view.View focused, int direction)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void debug()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void dumpGfxInfo(java.io.PrintWriter pw, int[] info)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void getGfxInfo(android.view.View view, int[] info)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void die(bool immediate)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal void doDie()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void requestUpdateConfiguration(android.content.res.Configuration config)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void destroyHardwareRenderer()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void dispatchFinishedEvent(int seq, bool handled)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void dispatchResized(int w, int h, android.graphics.Rect coveredInsets, android.graphics.Rect
			 visibleInsets, bool reportDraw, android.content.res.Configuration newConfig)
		{
			throw new System.NotImplementedException();
		}

		private long mInputEventReceiveTimeNanos;

		private long mInputEventDeliverTimeNanos;

		private long mInputEventDeliverPostImeTimeNanos;

		private android.view.InputQueue.FinishedCallback mFinishedCallback;

		private sealed class _InputHandler_3753 : android.view.InputHandler
		{
			public _InputHandler_3753(ViewRootImpl _enclosing)
			{
				this._enclosing = _enclosing;
			}

			// this is not set to null in touch mode
			// Set to true if the owner of this window is in the stopped state,
			// so the window should no longer be active.
			// used in the transaction to not thrash the heap.
			// used to retrieve visible rect of focused view.
			// These can be accessed by any thread, must be protected with a lock.
			// Surface can never be reassigned or cleared (use Surface.clear()).
			// These are accessed by multiple threads.
			// frame given by window manager.
			// Variables to track frames per second, enabled via DEBUG_FPS flag
			// Initialize the statics when this class is first instantiated. This is
			// done here instead of in the static block because Zygote does not
			// allow the spawning of threads.
			// true for the first time the view is added
			// FIXME for perf testing only
			// If the application owns the surface, don't enable hardware acceleration
			// Schedule the first layout -before- adding to the window
			// manager, to make sure we do the relayout before receiving
			// any other events from the system.
			// Silently ignore -- we would have just removed it
			// right away, anyway.
			// Try to enable hardware acceleration if requested
			// Persistent processes (including the system) should not do
			// accelerated rendering on low-end devices.  In that case,
			// sRendererDisabled will be set.  In addition, the system process
			// itself should never do accelerated rendering.  In that case, both
			// sRendererDisabled and sSystemRendererDisabled are set.  When
			// sSystemRendererDisabled is set, PRIVATE_FLAG_FORCE_HARDWARE_ACCELERATED
			// can be used by code on the system process to escape that and enable
			// HW accelerated drawing.  (This is basically for the lock screen.)
			// Don't enable hardware acceleration when we're not on the main thread
			// The window had wanted to use hardware acceleration, but this
			// is not allowed in its process.  By setting this flag, it can
			// still render as if it was accelerated.  This is basically for
			// the preview windows the window manager shows for launching
			// applications, so they will look more like the app being launched.
			// preserve compatible window flag if exists.
			// Don't lose the mode we last auto-computed.
			// Fast invalidation for GL-enabled applications; GL must redraw everything
			// Note: don't apply scroll offset, because we want to know its
			// visibility in the virtual canvas being given to the view hierarchy.
			//noinspection ConstantConditions
			// cache mView since it is used so much below...
			// NOTE -- system code, won't try to do compat mode.
			// For the very first time, tell the view hierarchy that it
			// is attached to the window.  Note that at this point the surface
			// object is not initialized to its backing store, but soon it
			// will be (assuming the window is visible).
			// We used to use the following condition to choose 32 bits drawing caches:
			// PixelFormat.hasAlpha(lp.format) || lp.format == PixelFormat.RGBX_8888
			// However, windows are now always 32 bits by default, so choose 32 bits
			//Log.i(TAG, "Screen on initialized: " + attachInfo.mKeepScreenOn);
			// After making a window gone, we will count it as being
			// shown for the first time the next time it gets focus.
			// Execute enqueued actions on every layout in case a view that was detached
			// enqueued an action after being detached
			// make sure touch mode code executes by setting cached value
			// to opposite of the added touch mode.
			// NOTE -- system code, won't try to do compat mode.
			// Ask host how big it wants to be
			// On large screens, we don't want to allow dialogs to just
			// stretch to fill the entire width of the screen to display
			// one line of text.  First try doing the layout at a smaller
			// size to see if it will fit.
			// Didn't fit in that size... try expanding a bit.
			//Log.i(TAG, "Computing view hierarchy attributes!");
			// If we are in auto resize mode, then we need to determine
			// what mode to use now.
			// If this window is giving internal insets to the window
			// manager, and it is being added or changing its visibility,
			// then we want to first give the window manager "fake"
			// insets to cause it to effectively ignore the content of
			// the window during layout.  This avoids it briefly causing
			// other windows to resize/move based on the raw frame of the
			// window, waiting until we can finish laying out this window
			// and get back to the window manager with the ultimately
			// computed insets.
			// If we are creating a new surface, then we need to
			// completely redraw it.  Also, when we get to the
			// point of drawing it we will hold off and schedule
			// a new traversal instead.  This is so we can tell the
			// window manager about all of the windows being displayed
			// before actually drawing them, so it can display then
			// all at once.
			// ask wm for a new surface next time.
			// If the surface has been removed, then reset the scroll
			// positions.
			// Our surface is gone
			// ask wm for a new surface next time.
			// !!FIXME!! This next section handles the case where we did not get the
			// window size we asked for. We should avoid this by getting a maximum size from
			// the window session beforehand.
			// The app owns the surface; tell it about what is going on.
			// XXX .copyFrom() doesn't work!
			//mSurfaceHolder.mSurface.copyFrom(mSurface);
			// Ask host how big it wants to be
			// Implementation of weights from WindowManager.LayoutParams
			// We just grow the dimensions as needed and re-measure if
			// needs be
			// By this point all views have been sized and positionned
			// We can compute the transparent area
			// start out transparent
			// TODO: AVOID THAT CALL BY CACHING THE RESULT?
			// reconfigure window manager
			// Clear the original insets.
			// Compute new insets in place.
			// Tell the window manager.
			// Translate insets to screen coordinates if needed.
			// handle first focus request
			// End any pending transitions on this non-visible window
			// We were supposed to report when we are done drawing. Since we canceled the
			// draw, remember it here.
			// Try again
			// the test below should not fail unless someone is messing with us
			// Need to make sure we re-evaluate the window attributes next
			// time around, to ensure the window has the correct format.
			// Window can't resize. Force root view to be windowSize.
			// Window can resize. Set max size for root view.
			// Window wants to be an exact size. Force root view to be that size.
			// TODO: This should use vsync when we get an API
			// Tracks frames per second drawn. First value in a series of draws may be bogus
			// because it down not account for the intervening idle time
			// The app owns the surface, we won't draw.
			// TODO: Do this in native
			// ask wm for a new surface next time.
			// Don't assume this is due to out of memory, it could be
			// something else, and if it is something else then we could
			// kill stuff (or ourself) for no reason.
			// ask wm for a new surface next time.
			//canvas.drawARGB(255, 255, 0, 0);
			// If this bitmap's format includes an alpha channel, we
			// need to clear it before drawing so that the child will
			// properly re-composite its drawing on a transparent
			// background. This automatically respects the clip/dirty region
			// or
			// If we are applying an offset, we need to clear the area
			// where the offset doesn't appear to avoid having garbage
			// left in the blank areas.
			// Only clear the flag if it was not set during the mView.draw() call
			// We'll assume that we aren't going to change the scroll
			// offset, since we want to avoid that unless it is actually
			// going to make the focus visible...  otherwise we scroll
			// all over the place.
			// We can be called for two different situations: during a draw,
			// to update the scroll position if the focus has changed (in which
			// case 'rectangle' is null), or in response to a
			// requestChildRectangleOnScreen() call (in which case 'rectangle'
			// is non-null and we just want to scroll to whatever that
			// rectangle is).
			// When in touch mode, focus points to the previously focused view,
			// which may have been removed from the view hierarchy. The following
			// line checks whether the view is still in our hierarchy.
			// If the focus has changed, then ignore any requests to scroll
			// to a rectangle; first we want to make sure the entire focus
			// view is visible.
			// Optimization: if the focus hasn't changed since last
			// time, and no layout has happened, then just leave things
			// as they are.
			// We need to determine if the currently focused view is
			// within the visible part of the window and, if not, apply
			// a pan so it can be seen.
			// Try to find the rectangle from the focus view.
			// If the focus simply is not going to fit, then
			// best is probably just to leave things as-is.
			// If a view gets the focus, the listener will be invoked from requestChildFocus()
			// the one case where will transfer focus away from the current one
			// is if the current view is a view group that prefers to give focus
			// to its children first AND the view is a descendant of it.
			// If a view gets the focus, the listener will be invoked from requestChildFocus()
			// Dispose the input channel after removing the window so the Window Manager
			// doesn't interpret the input channel being closed as an abnormal termination.
			// At this point the resources have been updated to
			// have the most recent config, whatever that is.  Use
			// the on in them which may be newer.
			// fall through...
			// Retry in a bit.
			// Note: must be done after the focus change callbacks,
			// so all of the view state is set up correctly.
			// Clear the forward bit.  We can just do this directly, since
			// the window manager doesn't care about it.
			// The IME is trying to say this event is from the
			// system!  Bad bad bad!
			//noinspection UnusedAssignment
			// only present when this app called startDrag()
			// tell the window manager
			// handle the change
			// note: not relying on mFocusedView here because this could
			// be when the window is first being added, and mFocused isn't
			// set yet.
			// there is an ancestor that wants focus after its descendants that
			// is focusable in touch mode.. give it focus
			// nothing appropriate to have focus in touch mode, clear it out
			// i learned the hard way to not trust mFocusedView :)
			// some view has focus, let it keep it
			// some view group has focus, and doesn't prefer its children
			// over itself for focus, so let them keep it.
			// find the best view to give focus to in this brave new non-touch-mode
			// world
			// If there is no view, then the event will not be handled.
			// Translate the pointer event for compatibility, if needed.
			// Enter touch mode on down or scroll.
			// Offset the scroll position.
			// Remember the touch position for possible drag-initiation.
			// Dispatch touch to view hierarchy.
			// Pointer event was unhandled.
			//noinspection ConstantConditions
			// If there is no view, then the event will not be handled.
			// Deliver the trackball event to the view.
			// If we reach this, we delivered a trackball event to mView and
			// mView consumed it. Because we will not translate the trackball
			// event into a key event, touch mode will not exit, so we exit
			// touch mode here.
			// Translate the trackball event into DPAD keys and try to deliver those.
			// It has been too long since the last movement,
			// so restart at the beginning.
			// Generate DPAD events based on the trackball movement.
			// We pick the axis that has moved the most as the direction of
			// the DPAD.  When we generate DPAD events for one axis, then the
			// other axis is reset -- we don't want to perform DPAD jumps due
			// to slight movements in the trackball when making major movements
			// along the other axis.
			// Unfortunately we can't tell whether the application consumed the keys, so
			// we always consider the trackball event handled.
			// If there is no view, then the event will not be handled.
			// Deliver the event to the view.
			// Translate the joystick event into DPAD keys and try to deliver those.
			// Only relevant in touch mode.
			// Only consider leaving touch mode on DOWN or MULTIPLE actions, never on UP.
			// Don't leave touch mode if the IME told us not to.
			// If the key can be used for keyboard navigation then leave touch mode
			// and select a focused view if needed (in ensureTouchMode).
			// When a new focused view is selected, we consume the navigation key because
			// navigation doesn't make much sense unless a view already has focus so
			// the key's purpose is to set focus.
			// If the key can be used for typing then leave touch mode
			// and select a focused view if needed (in ensureTouchMode).
			// Always allow the view to process the typing key.
			// If there is no view, then the event will not be handled.
			// Perform predispatching before the IME.
			// Dispatch to the IME before propagating down the view hierarchy.
			// The IME will eventually call back into handleFinishedEvent.
			// Not dispatching to IME, continue with post IME actions.
			// If the view went away, then the event will not be handled.
			// If the key's purpose is to exit touch mode then we consume it and consider it handled.
			// Make sure the fallback event policy sees all keys that will be delivered to the
			// view hierarchy.
			// Deliver the key to the view hierarchy.
			// If the Control modifier is held, try to interpret the key as a shortcut.
			// Apply the fallback event policy.
			// Handle automatic focus changes.
			// do the math the get the interesting rect
			// of previous focused into the coord system of
			// newly focused view
			// Give the focused view a last chance to handle the dpad key.
			// Key was unhandled.
			// From the root, only drag start/end/location are dispatched.  entered/exited
			// are determined and dispatched by the viewgroup hierarchy, who then report
			// that back here for ultimate reporting back to the framework.
			// A direct EXITED event means that the window manager knows we've just crossed
			// a window boundary, so the current drag target within this one must have
			// just been exited.  Send it the usual notifications and then we're done
			// for now.
			// Cache the drag description when the operation starts, then fill it in
			// on subsequent calls as a convenience
			// Start the current-recipient tracking
			// For events with a [screen] location, translate into window coordinates
			// Remember who the current drag target is pre-dispatch
			// Now dispatch the drag/drop event
			// If we changed apparent drag target, tell the OS about it
			// Report the drop result when we're done
			// When the drag operation ends, release any local state object
			// that may have been in use
			// The sequence has changed, so we need to update our value and make
			// sure to do a traversal afterward so the window manager is given our
			// most recent data.
			//Log.d(TAG, ">>>>>> CALLING relayout");
			// For compatibility with old apps, don't crash here.
			//Log.d(TAG, "<<<<<< BACK FROM relayout");
			// Exception thrown by getAudioManager() when mView is null
			// If layout params have been changed, first give them
			// to the window manager to make sure it has the correct
			// animation info.
			[Sharpen.ImplementsInterface(@"android.view.InputHandler")]
			public void handleKey(android.view.KeyEvent @event, android.view.InputQueue.FinishedCallback
				 finishedCallback)
			{
				this._enclosing.startInputEvent(finishedCallback);
				this._enclosing.dispatchKey(@event, true);
			}

			[Sharpen.ImplementsInterface(@"android.view.InputHandler")]
			public void handleMotion(android.view.MotionEvent @event, android.view.InputQueue
				.FinishedCallback finishedCallback)
			{
				this._enclosing.startInputEvent(finishedCallback);
				this._enclosing.dispatchMotion(@event, true);
			}

			private readonly ViewRootImpl _enclosing;
		}

		private readonly android.view.InputHandler mInputHandler;

		[Sharpen.Stub]
		public void dispatchKey(android.view.KeyEvent @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void dispatchKey(android.view.KeyEvent @event, bool sendDone)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void dispatchMotion(android.view.MotionEvent @event, bool sendDone)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void dispatchPointer(android.view.MotionEvent @event, bool sendDone)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void dispatchTrackball(android.view.MotionEvent @event, bool sendDone)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void dispatchGenericMotion(android.view.MotionEvent @event, bool sendDone
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void dispatchAppVisibility(bool visible)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void dispatchGetNewSurface()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void windowFocusChanged(bool hasFocus, bool inTouchMode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void dispatchCloseSystemDialogs(string reason)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void dispatchDragEvent(android.view.DragEvent @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void dispatchSystemUiVisibilityChanged(int seq, int globalVisibility, int 
			localValue, int localChanges)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void sendAccessibilityEvents()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void postSendWindowContentChangedCallback()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void removeSendWindowContentChangedCallback()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.ViewParent")]
		public bool showContextMenuForChild(android.view.View originalView)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.ViewParent")]
		public android.view.ActionMode startActionModeForChild(android.view.View originalView
			, android.view.ActionMode.Callback callback)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.ViewParent")]
		public void createContextMenu(android.view.ContextMenu menu)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.ViewParent")]
		public void childDrawableStateChanged(android.view.View child)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.ViewParent")]
		public bool requestSendAccessibilityEvent(android.view.View child, android.view.accessibility.AccessibilityEvent
			 @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal void checkThread()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.ViewParent")]
		public void requestDisallowInterceptTouchEvent(bool disallowIntercept)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.ViewParent")]
		public bool requestChildRectangleOnScreen(android.view.View child, android.graphics.Rect
			 rectangle, bool immediate)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal class TakenSurfaceHolder : android.view.@internal.BaseSurfaceHolder
		{
			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"com.android.internal.view.BaseSurfaceHolder")]
			public override bool onAllowLockCanvas()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"com.android.internal.view.BaseSurfaceHolder")]
			public override void onRelayoutContainer()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"com.android.internal.view.BaseSurfaceHolder")]
			public override void setFormat(int format)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"com.android.internal.view.BaseSurfaceHolder")]
			public override void setType(int type)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"com.android.internal.view.BaseSurfaceHolder")]
			public override void onUpdateSurface()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.SurfaceHolder")]
			public override bool isCreating()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"com.android.internal.view.BaseSurfaceHolder")]
			public override void setFixedSize(int width, int height)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.SurfaceHolder")]
			public override void setKeepScreenOn(bool screenOn)
			{
				throw new System.NotImplementedException();
			}

			internal TakenSurfaceHolder(ViewRootImpl _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly ViewRootImpl _enclosing;
		}

		[Sharpen.Stub]
		internal class InputMethodCallback : android.view.@internal.IInputMethodCallbackClass
			.Stub
		{
			private java.lang.@ref.WeakReference<android.view.ViewRootImpl> mViewAncestor;

			[Sharpen.Stub]
			public InputMethodCallback(android.view.ViewRootImpl viewAncestor)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodCallback")]
			public override void finishedEvent(int seq, bool handled)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodCallback")]
			public override void sessionCreated(android.view.@internal.IInputMethodSession session
				)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		internal class W : android.view.IWindowClass.Stub
		{
			private readonly java.lang.@ref.WeakReference<android.view.ViewRootImpl> mViewAncestor;

			[Sharpen.Stub]
			internal W(android.view.ViewRootImpl viewAncestor)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.IWindow")]
			public override void resized(int w, int h, android.graphics.Rect coveredInsets, android.graphics.Rect
				 visibleInsets, bool reportDraw, android.content.res.Configuration newConfig)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.IWindow")]
			public override void dispatchAppVisibility(bool visible)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.IWindow")]
			public override void dispatchGetNewSurface()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.IWindow")]
			public override void windowFocusChanged(bool hasFocus, bool inTouchMode)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			private static int checkCallingPermission(string permission)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.IWindow")]
			public override void executeCommand(string command, string parameters, android.os.ParcelFileDescriptor
				 @out)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.IWindow")]
			public override void closeSystemDialogs(string reason)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.IWindow")]
			public override void dispatchWallpaperOffsets(float x, float y, float xStep, float
				 yStep, bool sync)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.IWindow")]
			public override void dispatchWallpaperCommand(string action, int x, int y, int z, 
				android.os.Bundle extras, bool sync)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.IWindow")]
			public override void dispatchDragEvent(android.view.DragEvent @event)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.IWindow")]
			public override void dispatchSystemUiVisibilityChanged(int seq, int globalVisibility
				, int localValue, int localChanges)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		internal sealed class TrackballAxis
		{
			internal const float MAX_ACCELERATION = 20;

			internal const long FAST_MOVE_TIME = 150;

			internal const float ACCEL_MOVE_SCALING_FACTOR = (1.0f / 40);

			internal float position;

			internal float absPosition;

			internal float acceleration = 1;

			internal long lastMoveTime = 0;

			internal int step;

			internal int dir;

			internal int nonAccelMovement;

			[Sharpen.Stub]
			internal void reset(int _step)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal float collect(float off, long time, string axis)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal int generate(float precision)
			{
				throw new System.NotImplementedException();
			}
		}

		[System.Serializable]
		[Sharpen.Stub]
		public sealed class CalledFromWrongThreadException : android.util.AndroidRuntimeException
		{
			[Sharpen.Stub]
			public CalledFromWrongThreadException(string msg) : base(msg)
			{
				throw new System.NotImplementedException();
			}
		}

		private sealed class _SurfaceHolder_4310 : android.view.SurfaceHolder
		{
			public _SurfaceHolder_4310(ViewRootImpl _enclosing)
			{
				this._enclosing = _enclosing;
			}

			//noinspection ConstantConditions
			// ViewAncestor never intercepts touch event, so this can be a no-op
			// Not currently interesting -- from changing between fixed and layout size.
			// We take care of format and type changes on our own.
			// Stub -- not for use in the client.
			// The number of milliseconds between each movement that is
			// considered "normal" and will not result in any acceleration
			// or deceleration, scaled by the offset we have here.
			// The user is scrolling rapidly, so increase acceleration.
			// The user is scrolling slowly, so decrease acceleration.
			// If we are going to execute the first step, then we want
			// to do this as soon as possible instead of waiting for
			// a full movement, in order to make things look responsive.
			// If we have generated the first movement, then we need
			// to wait for the second complete trackball motion before
			// generating the second discrete movement.
			// After the first two, we generate discrete movements
			// consistently with the trackball, applying an acceleration
			// if the trackball is moving quickly.  This is a simple
			// acceleration on top of what we already compute based
			// on how quickly the wheel is being turned, to apply
			// a longer increasing acceleration to continuous movement
			// in one direction.
			// we only need a SurfaceHolder for opengl. it would be nice
			// to implement everything else though, especially the callback
			// support (opengl doesn't make use of it right now, but eventually
			// will).
			[Sharpen.ImplementsInterface(@"android.view.SurfaceHolder")]
			public android.view.Surface getSurface()
			{
				return this._enclosing.mSurface;
			}

			[Sharpen.ImplementsInterface(@"android.view.SurfaceHolder")]
			public bool isCreating()
			{
				return false;
			}

			[Sharpen.ImplementsInterface(@"android.view.SurfaceHolder")]
			public void addCallback(android.view.SurfaceHolderClass.Callback callback)
			{
			}

			[Sharpen.ImplementsInterface(@"android.view.SurfaceHolder")]
			public void removeCallback(android.view.SurfaceHolderClass.Callback callback)
			{
			}

			[Sharpen.ImplementsInterface(@"android.view.SurfaceHolder")]
			public void setFixedSize(int width, int height)
			{
			}

			[Sharpen.ImplementsInterface(@"android.view.SurfaceHolder")]
			public void setSizeFromLayout()
			{
			}

			[Sharpen.ImplementsInterface(@"android.view.SurfaceHolder")]
			public void setFormat(int format)
			{
			}

			[Sharpen.ImplementsInterface(@"android.view.SurfaceHolder")]
			public void setType(int type)
			{
			}

			[Sharpen.ImplementsInterface(@"android.view.SurfaceHolder")]
			public void setKeepScreenOn(bool screenOn)
			{
			}

			[Sharpen.ImplementsInterface(@"android.view.SurfaceHolder")]
			public android.graphics.Canvas lockCanvas()
			{
				return null;
			}

			[Sharpen.ImplementsInterface(@"android.view.SurfaceHolder")]
			public android.graphics.Canvas lockCanvas(android.graphics.Rect dirty)
			{
				return null;
			}

			[Sharpen.ImplementsInterface(@"android.view.SurfaceHolder")]
			public void unlockCanvasAndPost(android.graphics.Canvas canvas)
			{
			}

			[Sharpen.ImplementsInterface(@"android.view.SurfaceHolder")]
			public android.graphics.Rect getSurfaceFrame()
			{
				return null;
			}

			private readonly ViewRootImpl _enclosing;
		}

		private android.view.SurfaceHolder mHolder;

		internal static android.view.ViewRootImpl.RunQueue getRunQueue()
		{
			android.view.ViewRootImpl.RunQueue rq = sRunQueues.get();
			if (rq != null)
			{
				return rq;
			}
			rq = new android.view.ViewRootImpl.RunQueue();
			sRunQueues.set(rq);
			return rq;
		}

		/// <hide></hide>
		internal sealed class RunQueue
		{
			private readonly java.util.ArrayList<android.view.ViewRootImpl.RunQueue.HandlerAction
				> mActions = new java.util.ArrayList<android.view.ViewRootImpl.RunQueue.HandlerAction
				>();

			internal void post(java.lang.Runnable action)
			{
				postDelayed(action, 0);
			}

			internal void postDelayed(java.lang.Runnable action, long delayMillis)
			{
				android.view.ViewRootImpl.RunQueue.HandlerAction handlerAction = new android.view.ViewRootImpl.RunQueue
					.HandlerAction();
				handlerAction.action = action;
				handlerAction.delay = delayMillis;
				lock (mActions)
				{
					mActions.add(handlerAction);
				}
			}

			internal void removeCallbacks(java.lang.Runnable action)
			{
				android.view.ViewRootImpl.RunQueue.HandlerAction handlerAction = new android.view.ViewRootImpl.RunQueue
					.HandlerAction();
				handlerAction.action = action;
				lock (mActions)
				{
					java.util.ArrayList<android.view.ViewRootImpl.RunQueue.HandlerAction> actions = mActions;
					while (actions.remove(handlerAction))
					{
					}
				}
			}

			// Keep going
			internal void executeActions(android.os.Handler handler)
			{
				lock (mActions)
				{
					java.util.ArrayList<android.view.ViewRootImpl.RunQueue.HandlerAction> actions = mActions;
					int count = actions.size();
					{
						for (int i = 0; i < count; i++)
						{
							android.view.ViewRootImpl.RunQueue.HandlerAction handlerAction = actions.get(i);
							handler.postDelayed(handlerAction.action, handlerAction.delay);
						}
					}
					actions.clear();
				}
			}

			private class HandlerAction
			{
				internal java.lang.Runnable action;

				internal long delay;

				[Sharpen.OverridesMethod(@"java.lang.Object")]
				public override bool Equals(object o)
				{
					if (this == o)
					{
						return true;
					}
					if (o == null || GetType() != o.GetType())
					{
						return false;
					}
					android.view.ViewRootImpl.RunQueue.HandlerAction that = (android.view.ViewRootImpl.RunQueue
						.HandlerAction)o;
					return !(action != null ? !action.Equals(that.action) : that.action != null);
				}

				[Sharpen.OverridesMethod(@"java.lang.Object")]
				public override int GetHashCode()
				{
					int result = action != null ? action.GetHashCode() : 0;
					result = 31 * result + (int)(delay ^ ((long)(((ulong)delay) >> 32)));
					return result;
				}
			}
		}

		[Sharpen.Stub]
		internal sealed class AccessibilityInteractionConnectionManager : android.view.accessibility.AccessibilityManager
			.AccessibilityStateChangeListener
		{
			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.accessibility.AccessibilityManager.AccessibilityStateChangeListener"
				)]
			public void onAccessibilityStateChanged(bool enabled)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public void ensureConnection()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public void ensureNoConnection()
			{
				throw new System.NotImplementedException();
			}

			internal AccessibilityInteractionConnectionManager(ViewRootImpl _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly ViewRootImpl _enclosing;
		}

		[Sharpen.Stub]
		internal sealed class AccessibilityInteractionConnection : android.view.accessibility.IAccessibilityInteractionConnectionClass
			.Stub
		{
			private readonly java.lang.@ref.WeakReference<android.view.ViewRootImpl> mViewAncestor;

			[Sharpen.Stub]
			internal AccessibilityInteractionConnection(ViewRootImpl _enclosing, android.view.ViewRootImpl
				 viewAncestor)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.accessibility.IAccessibilityInteractionConnection"
				)]
			public override void findAccessibilityNodeInfoByAccessibilityId(int accessibilityId
				, int interactionId, android.view.accessibility.IAccessibilityInteractionConnectionCallback
				 callback, int interrogatingPid, long interrogatingTid)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.accessibility.IAccessibilityInteractionConnection"
				)]
			public override void performAccessibilityAction(int accessibilityId, int action, 
				int interactionId, android.view.accessibility.IAccessibilityInteractionConnectionCallback
				 callback, int interogatingPid, long interrogatingTid)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.accessibility.IAccessibilityInteractionConnection"
				)]
			public override void findAccessibilityNodeInfoByViewId(int viewId, int interactionId
				, android.view.accessibility.IAccessibilityInteractionConnectionCallback callback
				, int interrogatingPid, long interrogatingTid)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.accessibility.IAccessibilityInteractionConnection"
				)]
			public override void findAccessibilityNodeInfosByViewText(string text, int accessibilityId
				, int interactionId, android.view.accessibility.IAccessibilityInteractionConnectionCallback
				 callback, int interrogatingPid, long interrogatingTid)
			{
				throw new System.NotImplementedException();
			}

			private readonly ViewRootImpl _enclosing;
		}

		[Sharpen.Stub]
		internal sealed class AccessibilityInteractionController
		{
			internal const int POOL_SIZE = 5;

			private java.util.ArrayList<android.view.accessibility.AccessibilityNodeInfo> mTempAccessibilityNodeInfoList;

			private sealed class _PoolableManager_4542 : android.util.PoolableManager<android.view.ViewRootImpl
				.AccessibilityInteractionController.SomeArgs>
			{
				public _PoolableManager_4542()
				{
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.util.PoolableManager")]
				public android.view.ViewRootImpl.AccessibilityInteractionController.SomeArgs newInstance
					()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.util.PoolableManager")]
				public void onAcquired(android.view.ViewRootImpl.AccessibilityInteractionController
					.SomeArgs info)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.util.PoolableManager")]
				public void onReleased(android.view.ViewRootImpl.AccessibilityInteractionController
					.SomeArgs info)
				{
					throw new System.NotImplementedException();
				}
			}

			private readonly android.util.Pool<android.view.ViewRootImpl.AccessibilityInteractionController
				.SomeArgs> mPool;

			[Sharpen.Stub]
			public class SomeArgs : android.util.Poolable<android.view.ViewRootImpl.AccessibilityInteractionController
				.SomeArgs>
			{
				private android.view.ViewRootImpl.AccessibilityInteractionController.SomeArgs mNext;

				private bool mIsPooled;

				public object arg1;

				public object arg2;

				public int argi1;

				public int argi2;

				public int argi3;

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.util.Poolable")]
				public virtual android.view.ViewRootImpl.AccessibilityInteractionController.SomeArgs
					 getNextPoolable()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.util.Poolable")]
				public virtual bool isPooled()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.util.Poolable")]
				public virtual void setNextPoolable(android.view.ViewRootImpl.AccessibilityInteractionController
					.SomeArgs args)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.util.Poolable")]
				public virtual void setPooled(bool isPooled_1)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				private void clear()
				{
					throw new System.NotImplementedException();
				}

				internal SomeArgs(AccessibilityInteractionController _enclosing)
				{
					this._enclosing = _enclosing;
				}

				private readonly AccessibilityInteractionController _enclosing;
			}

			[Sharpen.Stub]
			public void findAccessibilityNodeInfoByAccessibilityIdClientThread(int accessibilityId
				, int interactionId, android.view.accessibility.IAccessibilityInteractionConnectionCallback
				 callback, int interrogatingPid, long interrogatingTid)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public void findAccessibilityNodeInfoByAccessibilityIdUiThread(android.os.Message
				 message)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public void findAccessibilityNodeInfoByViewIdClientThread(int viewId, int interactionId
				, android.view.accessibility.IAccessibilityInteractionConnectionCallback callback
				, int interrogatingPid, long interrogatingTid)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public void findAccessibilityNodeInfoByViewIdUiThread(android.os.Message message)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public void findAccessibilityNodeInfosByViewTextClientThread(string text, int accessibilityViewId
				, int interactionId, android.view.accessibility.IAccessibilityInteractionConnectionCallback
				 callback, int interrogatingPid, long interrogatingTid)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public void findAccessibilityNodeInfosByViewTextUiThread(android.os.Message message
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public void performAccessibilityActionClientThread(int accessibilityId, int action
				, int interactionId, android.view.accessibility.IAccessibilityInteractionConnectionCallback
				 callback, int interogatingPid, long interrogatingTid)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public void perfromAccessibilityActionUiThread(android.os.Message message)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			private bool performActionFocus(int accessibilityId)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			private bool performActionClearFocus(int accessibilityId)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			private bool performActionSelect(int accessibilityId)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			private bool performActionClearSelection(int accessibilityId)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			private android.view.View findViewByAccessibilityId(int accessibilityId)
			{
				throw new System.NotImplementedException();
			}

			public AccessibilityInteractionController(ViewRootImpl _enclosing)
			{
				this._enclosing = _enclosing;
				mTempAccessibilityNodeInfoList = new java.util.ArrayList<android.view.accessibility.AccessibilityNodeInfo
					>();
				mPool = null;
			}

			private readonly ViewRootImpl _enclosing;
		}

		[Sharpen.Stub]
		private class SendWindowContentChangedAccessibilityEvent : java.lang.Runnable
		{
			public volatile bool mIsPending;

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public virtual void run()
			{
				throw new System.NotImplementedException();
			}

			internal SendWindowContentChangedAccessibilityEvent(ViewRootImpl _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly ViewRootImpl _enclosing;
		}
		// Reusable poolable arguments for interacting with the view hierarchy
		// to fit more arguments than Message and to avoid sharing objects between
		// two messages since several threads can send messages concurrently.
		// If the interrogation is performed by the same thread as the main UI
		// thread in this process, set the message as a static reference so
		// after this call completes the same thread but in the interrogating
		// client can handle the message to generate the result.
		// If the interrogation is performed by the same thread as the main UI
		// thread in this process, set the message as a static reference so
		// after this call completes the same thread but in the interrogating
		// client can handle the message to generate the result.
		// If the interrogation is performed by the same thread as the main UI
		// thread in this process, set the message as a static reference so
		// after this call completes the same thread but in the interrogating
		// client can handle the message to generate the result.
		// If the interrogation is performed by the same thread as the main UI
		// thread in this process, set the message as a static reference so
		// after this call completes the same thread but in the interrogating
		// client can handle the message to generate the result.
		// Get out of touch mode since accessibility wants to move focus around.
	}
}

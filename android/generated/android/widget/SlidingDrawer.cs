using Sharpen;

namespace android.widget
{
	[Sharpen.Stub]
	public class SlidingDrawer : android.view.ViewGroup
	{
		public const int ORIENTATION_HORIZONTAL = 0;

		public const int ORIENTATION_VERTICAL = 1;

		internal const int TAP_THRESHOLD = 6;

		internal const float MAXIMUM_TAP_VELOCITY = 100.0f;

		internal const float MAXIMUM_MINOR_VELOCITY = 150.0f;

		internal const float MAXIMUM_MAJOR_VELOCITY = 200.0f;

		internal const float MAXIMUM_ACCELERATION = 2000.0f;

		internal const int VELOCITY_UNITS = 1000;

		internal const int MSG_ANIMATE = 1000;

		internal const int ANIMATION_FRAME_DURATION = 1000 / 60;

		internal const int EXPANDED_FULL_OPEN = -10001;

		internal const int COLLAPSED_FULL_CLOSED = -10002;

		private readonly int mHandleId;

		private readonly int mContentId;

		private android.view.View mHandle;

		private android.view.View mContent;

		private readonly android.graphics.Rect mFrame = new android.graphics.Rect();

		private readonly android.graphics.Rect mInvalidate = new android.graphics.Rect();

		private bool mTracking;

		private bool mLocked;

		private android.view.VelocityTracker mVelocityTracker;

		private bool mVertical;

		private bool mExpanded;

		private int mBottomOffset;

		private int mTopOffset;

		private int mHandleHeight;

		private int mHandleWidth;

		private android.widget.SlidingDrawer.OnDrawerOpenListener mOnDrawerOpenListener;

		private android.widget.SlidingDrawer.OnDrawerCloseListener mOnDrawerCloseListener;

		private android.widget.SlidingDrawer.OnDrawerScrollListener mOnDrawerScrollListener;

		private readonly android.os.Handler mHandler;

		private float mAnimatedAcceleration;

		private float mAnimatedVelocity;

		private float mAnimationPosition;

		private long mAnimationLastTime;

		private long mCurrentAnimationTime;

		private int mTouchDelta;

		private bool mAnimating;

		private bool mAllowSingleTap;

		private bool mAnimateOnClick;

		private readonly int mTapThreshold;

		private readonly int mMaximumTapVelocity;

		private readonly int mMaximumMinorVelocity;

		private readonly int mMaximumMajorVelocity;

		private readonly int mMaximumAcceleration;

		private readonly int mVelocityUnits;

		[Sharpen.Stub]
		public interface OnDrawerOpenListener
		{
			[Sharpen.Stub]
			void onDrawerOpened();
		}

		[Sharpen.Stub]
		public interface OnDrawerCloseListener
		{
			[Sharpen.Stub]
			void onDrawerClosed();
		}

		[Sharpen.Stub]
		public interface OnDrawerScrollListener
		{
			[Sharpen.Stub]
			void onScrollStarted();

			[Sharpen.Stub]
			void onScrollEnded();
		}

		[Sharpen.Stub]
		public SlidingDrawer(android.content.Context context, android.util.AttributeSet attrs
			) : this(context, attrs, 0)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public SlidingDrawer(android.content.Context context, android.util.AttributeSet attrs
			, int defStyle) : base(context, attrs, defStyle)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onFinishInflate()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onMeasure(int widthMeasureSpec, int heightMeasureSpec
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void dispatchDraw(android.graphics.Canvas canvas)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onLayout(bool changed, int l, int t, int r, int 
			b)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override bool onInterceptTouchEvent(android.view.MotionEvent @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool onTouchEvent(android.view.MotionEvent @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void animateClose(int position)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void animateOpen(int position)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void performFling(int position, float velocity, bool always)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void prepareTracking(int position)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void moveHandle(int position)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void prepareContent()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void stopTracking()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void doAnimation()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void incrementAnimation()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void toggle()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void animateToggle()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void open()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void close()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void animateClose()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void animateOpen()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void closeDrawer()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void openDrawer()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setOnDrawerOpenListener(android.widget.SlidingDrawer.OnDrawerOpenListener
			 onDrawerOpenListener)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setOnDrawerCloseListener(android.widget.SlidingDrawer.OnDrawerCloseListener
			 onDrawerCloseListener)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setOnDrawerScrollListener(android.widget.SlidingDrawer.OnDrawerScrollListener
			 onDrawerScrollListener)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.view.View getHandle()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.view.View getContent()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void unlock()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void @lock()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isOpened()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isMoving()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private class DrawerToggler : android.view.View.OnClickListener
		{
			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.View.OnClickListener")]
			public virtual void onClick(android.view.View v)
			{
				throw new System.NotImplementedException();
			}

			internal DrawerToggler(SlidingDrawer _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly SlidingDrawer _enclosing;
		}

		[Sharpen.Stub]
		private class SlidingHandler : android.os.Handler
		{
			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.os.Handler")]
			public override void handleMessage(android.os.Message m)
			{
				throw new System.NotImplementedException();
			}

			internal SlidingHandler(SlidingDrawer _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly SlidingDrawer _enclosing;
		}
	}
}

using Sharpen;

namespace android.widget.@internal
{
	[Sharpen.Stub]
	public class RotarySelector : android.view.View
	{
		public const int HORIZONTAL = 0;

		public const int VERTICAL = 1;

		internal const string LOG_TAG = "RotarySelector";

		internal const bool DBG = false;

		internal const bool VISUAL_DEBUG = false;

		private android.widget.@internal.RotarySelector.OnDialTriggerListener mOnDialTriggerListener;

		private float mDensity;

		private android.graphics.Bitmap mBackground;

		private android.graphics.Bitmap mDimple;

		private android.graphics.Bitmap mDimpleDim;

		private android.graphics.Bitmap mLeftHandleIcon;

		private android.graphics.Bitmap mRightHandleIcon;

		private android.graphics.Bitmap mArrowShortLeftAndRight;

		private android.graphics.Bitmap mArrowLongLeft;

		private android.graphics.Bitmap mArrowLongRight;

		private int mLeftHandleX;

		private int mRightHandleX;

		private int mRotaryOffsetX = 0;

		private bool mAnimating = false;

		private long mAnimationStartTime;

		private long mAnimationDuration;

		private int mAnimatingDeltaXStart;

		private int mAnimatingDeltaXEnd;

		private android.view.animation.DecelerateInterpolator mInterpolator;

		private android.graphics.Paint mPaint = new android.graphics.Paint();

		internal readonly android.graphics.Matrix mBgMatrix = new android.graphics.Matrix
			();

		internal readonly android.graphics.Matrix mArrowMatrix = new android.graphics.Matrix
			();

		private int mGrabbedState = NOTHING_GRABBED;

		public const int NOTHING_GRABBED = 0;

		public const int LEFT_HANDLE_GRABBED = 1;

		public const int RIGHT_HANDLE_GRABBED = 2;

		private bool mTriggered = false;

		private android.os.Vibrator mVibrator;

		internal const long VIBRATE_SHORT = 20;

		internal const long VIBRATE_LONG = 20;

		internal const int ARROW_SCRUNCH_DIP = 6;

		internal const int EDGE_PADDING_DIP = 9;

		internal const int EDGE_TRIGGER_DIP = 100;

		internal const int OUTER_ROTARY_RADIUS_DIP = 390;

		internal const int ROTARY_STROKE_WIDTH_DIP = 83;

		internal const int SNAP_BACK_ANIMATION_DURATION_MILLIS = 300;

		internal const int SPIN_ANIMATION_DURATION_MILLIS = 800;

		private int mEdgeTriggerThresh;

		private int mDimpleWidth;

		private int mBackgroundWidth;

		private int mBackgroundHeight;

		private readonly int mOuterRadius;

		private readonly int mInnerRadius;

		private int mDimpleSpacing;

		private android.view.VelocityTracker mVelocityTracker;

		private int mMinimumVelocity;

		private int mMaximumVelocity;

		private int mDimplesOfFling = 0;

		private int mOrientation;

		[Sharpen.Stub]
		public RotarySelector(android.content.Context context) : this(context, null)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public RotarySelector(android.content.Context context, android.util.AttributeSet 
			attrs) : base(context, attrs)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private android.graphics.Bitmap getBitmapFor(int resId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onSizeChanged(int w, int h, int oldw, int oldh)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private bool isHoriz()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setLeftHandleResource(int resId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setRightHandleResource(int resId)
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
		protected internal override void onDraw(android.graphics.Canvas canvas)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private int getYOnArc(int backgroundWidth, int innerRadius, int outerRadius, int 
			x)
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
		private void startAnimation(int startX, int endX, int duration)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void startAnimationWithVelocity(int startX, int endX, int pixelsPerSecond
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void updateAnimation()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void reset()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void vibrate(long duration)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void drawCentered(android.graphics.Bitmap d, android.graphics.Canvas c, int
			 x, int y)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setOnDialTriggerListener(android.widget.@internal.RotarySelector
			.OnDialTriggerListener l)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void dispatchTriggerEvent(int whichHandle)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void setGrabbedState(int newState)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public interface OnDialTriggerListener
		{
			[Sharpen.Stub]
			void onDialTrigger(android.view.View v, int whichHandle);

			[Sharpen.Stub]
			void onGrabbedStateChange(android.view.View v, int grabbedState);
		}

		[Sharpen.Stub]
		public static class OnDialTriggerListenerClass
		{
			public const int LEFT_HANDLE = 1;

			public const int RIGHT_HANDLE = 2;
		}

		[Sharpen.Stub]
		private void log(string msg)
		{
			throw new System.NotImplementedException();
		}
	}
}

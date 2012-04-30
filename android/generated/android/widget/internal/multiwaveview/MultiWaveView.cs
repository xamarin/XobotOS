using Sharpen;

namespace android.widget.@internal.multiwaveview
{
	[Sharpen.Stub]
	public class MultiWaveView : android.view.View
	{
		internal const string TAG = "MultiWaveView";

		internal const bool DEBUG = false;

		internal const int STATE_IDLE = 0;

		internal const int STATE_FIRST_TOUCH = 1;

		internal const int STATE_TRACKING = 2;

		internal const int STATE_SNAP = 3;

		internal const int STATE_FINISH = 4;

		internal const float SNAP_MARGIN_DEFAULT = 20.0f;

		[Sharpen.Stub]
		public interface OnTriggerListener
		{
			[Sharpen.Stub]
			void onGrabbed(android.view.View v, int handle);

			[Sharpen.Stub]
			void onReleased(android.view.View v, int handle);

			[Sharpen.Stub]
			void onTrigger(android.view.View v, int target);

			[Sharpen.Stub]
			void onGrabbedStateChange(android.view.View v, int handle);
		}

		[Sharpen.Stub]
		public static class OnTriggerListenerClass
		{
			public const int NO_HANDLE = 0;

			public const int CENTER_HANDLE = 1;
		}

		internal const int CHEVRON_INCREMENTAL_DELAY = 160;

		internal const int CHEVRON_ANIMATION_DURATION = 850;

		internal const int RETURN_TO_HOME_DELAY = 1200;

		internal const int RETURN_TO_HOME_DURATION = 300;

		internal const int HIDE_ANIMATION_DELAY = 200;

		internal const int HIDE_ANIMATION_DURATION = RETURN_TO_HOME_DELAY;

		internal const int SHOW_ANIMATION_DURATION = 0;

		internal const int SHOW_ANIMATION_DELAY = 0;

		internal const float TAP_RADIUS_SCALE_ACCESSIBILITY_ENABLED = 1.3f;

		private android.animation.TimeInterpolator mChevronAnimationInterpolator = android.widget.@internal.multiwaveview.Ease
			.Quad.easeOut;

		private java.util.ArrayList<android.widget.@internal.multiwaveview.TargetDrawable
			> mTargetDrawables = new java.util.ArrayList<android.widget.@internal.multiwaveview.TargetDrawable
			>();

		private java.util.ArrayList<android.widget.@internal.multiwaveview.TargetDrawable
			> mChevronDrawables = new java.util.ArrayList<android.widget.@internal.multiwaveview.TargetDrawable
			>();

		private java.util.ArrayList<android.widget.@internal.multiwaveview.Tweener> mChevronAnimations
			 = new java.util.ArrayList<android.widget.@internal.multiwaveview.Tweener>();

		private java.util.ArrayList<android.widget.@internal.multiwaveview.Tweener> mTargetAnimations
			 = new java.util.ArrayList<android.widget.@internal.multiwaveview.Tweener>();

		private java.util.ArrayList<string> mTargetDescriptions;

		private java.util.ArrayList<string> mDirectionDescriptions;

		private android.widget.@internal.multiwaveview.Tweener mHandleAnimation;

		private android.widget.@internal.multiwaveview.MultiWaveView.OnTriggerListener mOnTriggerListener;

		private android.widget.@internal.multiwaveview.TargetDrawable mHandleDrawable;

		private android.widget.@internal.multiwaveview.TargetDrawable mOuterRing;

		private android.os.Vibrator mVibrator;

		private int mFeedbackCount = 3;

		private int mVibrationDuration = 0;

		private int mGrabbedState;

		private int mActiveTarget = -1;

		private float mTapRadius;

		private float mWaveCenterX;

		private float mWaveCenterY;

		private float mVerticalOffset;

		private float mHorizontalOffset;

		private float mOuterRadius = 0.0f;

		private float mHitRadius = 0.0f;

		private float mSnapMargin = 0.0f;

		private bool mDragging;

		private int mNewTargetResources;

		private sealed class _AnimatorListenerAdapter_111 : android.animation.AnimatorListenerAdapter
		{
			public _AnimatorListenerAdapter_111()
			{
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.animation.AnimatorListenerAdapter")]
			public override void onAnimationEnd(android.animation.Animator animator)
			{
				throw new System.NotImplementedException();
			}
		}

		private android.animation.Animator.AnimatorListener mResetListener = new _AnimatorListenerAdapter_111
			();

		private sealed class _AnimatorListenerAdapter_117 : android.animation.AnimatorListenerAdapter
		{
			public _AnimatorListenerAdapter_117()
			{
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.animation.AnimatorListenerAdapter")]
			public override void onAnimationEnd(android.animation.Animator animator)
			{
				throw new System.NotImplementedException();
			}
		}

		private android.animation.Animator.AnimatorListener mResetListenerWithPing = new 
			_AnimatorListenerAdapter_117();

		private sealed class _AnimatorUpdateListener_124 : android.animation.ValueAnimator
			.AnimatorUpdateListener
		{
			public _AnimatorUpdateListener_124()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.animation.ValueAnimator.AnimatorUpdateListener"
				)]
			public void onAnimationUpdate(android.animation.ValueAnimator animation)
			{
				throw new System.NotImplementedException();
			}
		}

		private android.animation.ValueAnimator.AnimatorUpdateListener mUpdateListener = 
			new _AnimatorUpdateListener_124();

		private bool mAnimatingTargets;

		private sealed class _AnimatorListenerAdapter_132 : android.animation.AnimatorListenerAdapter
		{
			public _AnimatorListenerAdapter_132()
			{
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.animation.AnimatorListenerAdapter")]
			public override void onAnimationEnd(android.animation.Animator animator)
			{
				throw new System.NotImplementedException();
			}
		}

		private android.animation.Animator.AnimatorListener mTargetUpdateListener = new _AnimatorListenerAdapter_132
			();

		private int mTargetResourceId;

		private int mTargetDescriptionsResourceId;

		private int mDirectionDescriptionsResourceId;

		[Sharpen.Stub]
		public MultiWaveView(android.content.Context context) : this(context, null)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public MultiWaveView(android.content.Context context, android.util.AttributeSet attrs
			) : base(context, attrs)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void dump()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override int getSuggestedMinimumWidth()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override int getSuggestedMinimumHeight()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private int resolveMeasured(int measureSpec, int desired)
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
		private void switchToState(int state, float x, float y)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void startChevronAnimation()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void stopChevronAnimation()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void stopHandleAnimation()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void deactivateTargets()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void invalidateGlobalRegion(android.widget.@internal.multiwaveview.TargetDrawable
			 drawable)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void dispatchTriggerEvent(int whichHandle)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void dispatchGrabbedEvent(int whichHandler)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void doFinish()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void hideUnselected(int active)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void hideTargets(bool animate_1)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void showTargets(bool animate_1)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void stopTargetAnimation()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void vibrate()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void internalSetTargetResources(int resourceId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setTargetResources(int resourceId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getTargetResourceId()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setTargetDescriptionsResourceId(int resourceId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getTargetDescriptionsResourceId()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setDirectionDescriptionsResourceId(int resourceId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getDirectionDescriptionsResourceId()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setVibrateEnabled(bool enabled)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void ping()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void reset(bool animate_1)
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
		private void moveHandleTo(float x, float y, bool animate_1)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void handleDown(android.view.MotionEvent @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void handleUp(android.view.MotionEvent @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void handleMove(android.view.MotionEvent @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool onHoverEvent(android.view.MotionEvent @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void setGrabbedState(int newState)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private bool trySwitchToFirstTouchState(android.view.MotionEvent @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void performInitialLayout(float centerX, float centerY)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onLayout(bool changed, int left, int top, int right
			, int bottom)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void updateTargetPositions()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void hideChevrons()
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
		public virtual void setOnTriggerListener(android.widget.@internal.multiwaveview.MultiWaveView
			.OnTriggerListener listener)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private float square(float d)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private float dist2(float dx, float dy)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private float getScaledTapRadiusSquared()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void announceTargets()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void announceText(string text)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private string getTargetDescription(int index)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private string getDirectionDescription(int index)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private java.util.ArrayList<string> loadDescriptions(int resourceId)
		{
			throw new System.NotImplementedException();
		}
	}
}

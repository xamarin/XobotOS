using Sharpen;

namespace android.widget.@internal
{
	[Sharpen.Stub]
	public class SlidingTab : android.view.ViewGroup
	{
		internal const string LOG_TAG = "SlidingTab";

		internal const bool DBG = false;

		internal const int HORIZONTAL = 0;

		internal const int VERTICAL = 1;

		internal const float THRESHOLD = 2.0f / 3.0f;

		internal const long VIBRATE_SHORT = 30;

		internal const long VIBRATE_LONG = 40;

		internal const int TRACKING_MARGIN = 50;

		internal const int ANIM_DURATION = 250;

		internal const int ANIM_TARGET_TIME = 500;

		private bool mHoldLeftOnTransition = true;

		private bool mHoldRightOnTransition = true;

		private android.widget.@internal.SlidingTab.OnTriggerListener mOnTriggerListener;

		private int mGrabbedState = android.widget.@internal.SlidingTab.OnTriggerListenerClass.NO_HANDLE;

		private bool mTriggered = false;

		private android.os.Vibrator mVibrator;

		private readonly float mDensity;

		private readonly int mOrientation;

		private readonly android.widget.@internal.SlidingTab.Slider mLeftSlider;

		private readonly android.widget.@internal.SlidingTab.Slider mRightSlider;

		private android.widget.@internal.SlidingTab.Slider mCurrentSlider;

		private bool mTracking;

		private float mThreshold;

		private android.widget.@internal.SlidingTab.Slider mOtherSlider;

		private bool mAnimating;

		private readonly android.graphics.Rect mTmpRect;

		private sealed class _AnimationListener_90 : android.view.animation.Animation.AnimationListener
		{
			public _AnimationListener_90()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.animation.Animation.AnimationListener"
				)]
			public void onAnimationStart(android.view.animation.Animation animation)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.animation.Animation.AnimationListener"
				)]
			public void onAnimationRepeat(android.view.animation.Animation animation)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.animation.Animation.AnimationListener"
				)]
			public void onAnimationEnd(android.view.animation.Animation animation)
			{
				throw new System.NotImplementedException();
			}
		}

		private readonly android.view.animation.Animation.AnimationListener mAnimationDoneListener
			 = new _AnimationListener_90();

		[Sharpen.Stub]
		public interface OnTriggerListener
		{
			[Sharpen.Stub]
			void onTrigger(android.view.View v, int whichHandle);

			[Sharpen.Stub]
			void onGrabbedStateChange(android.view.View v, int grabbedState);
		}

		[Sharpen.Stub]
		public static class OnTriggerListenerClass
		{
			public const int NO_HANDLE = 0;

			public const int LEFT_HANDLE = 1;

			public const int RIGHT_HANDLE = 2;
		}

		[Sharpen.Stub]
		private class Slider
		{
			public const int ALIGN_LEFT = 0;

			public const int ALIGN_RIGHT = 1;

			public const int ALIGN_TOP = 2;

			public const int ALIGN_BOTTOM = 3;

			public const int ALIGN_UNKNOWN = 4;

			internal const int STATE_NORMAL = 0;

			internal const int STATE_PRESSED = 1;

			internal const int STATE_ACTIVE = 2;

			internal readonly android.widget.ImageView tab;

			internal readonly android.widget.TextView text;

			internal readonly android.widget.ImageView target;

			internal int currentState = STATE_NORMAL;

			internal int alignment = ALIGN_UNKNOWN;

			internal int alignment_value;

			[Sharpen.Stub]
			internal Slider(android.view.ViewGroup parent, int tabId, int barId, int targetId
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal virtual void setIcon(int iconId)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal virtual void setTabBackgroundResource(int tabId)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal virtual void setBarBackgroundResource(int barId)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal virtual void setHintText(int resId)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal virtual void hide()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal virtual void show(bool animate)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal virtual void setState(int state)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal virtual void showTarget()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal virtual void reset(bool animate)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal virtual void setTarget(int targetId)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal virtual void layout(int l, int t, int r, int b, int alignment)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void updateDrawableStates()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void measure()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual int getTabWidth()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual int getTabHeight()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void startAnimation(android.view.animation.Animation anim1, android.view.animation.Animation
				 anim2)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void hideTarget()
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public SlidingTab(android.content.Context context) : this(context, null)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public SlidingTab(android.content.Context context, android.util.AttributeSet attrs
			) : base(context, attrs)
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
		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override bool onInterceptTouchEvent(android.view.MotionEvent @event)
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
		public override void setVisibility(int visibility)
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
		private void cancelGrab()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void startAnimating(bool holdAfter)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void onAnimationDone()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private bool withinView(float x, float y, android.view.View view)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private bool isHorizontal()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void resetView()
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
		private void moveHandle(float x, float y)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setLeftTabResources(int iconId, int targetId, int barId, int 
			tabId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setLeftHintText(int resId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setRightTabResources(int iconId, int targetId, int barId, int
			 tabId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setRightHintText(int resId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setHoldAfterTrigger(bool holdLeft, bool holdRight)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void vibrate(long duration)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setOnTriggerListener(android.widget.@internal.SlidingTab.OnTriggerListener
			 listener)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void dispatchTriggerEvent(int whichHandle)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onVisibilityChanged(android.view.View changedView
			, int visibility)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void setGrabbedState(int newState)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void log(string msg)
		{
			throw new System.NotImplementedException();
		}
	}
}

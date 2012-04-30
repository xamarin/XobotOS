using Sharpen;

namespace android.widget.@internal
{
	[Sharpen.Stub]
	public class WaveView : android.view.View, android.animation.ValueAnimator.AnimatorUpdateListener
	{
		internal const string TAG = "WaveView";

		internal const bool DBG = false;

		internal const int WAVE_COUNT = 20;

		internal const long VIBRATE_SHORT = 20;

		internal const long VIBRATE_LONG = 20;

		internal const int STATE_RESET_LOCK = 0;

		internal const int STATE_READY = 1;

		internal const int STATE_START_ATTEMPT = 2;

		internal const int STATE_ATTEMPTING = 3;

		internal const int STATE_UNLOCK_ATTEMPT = 4;

		internal const int STATE_UNLOCK_SUCCESS = 5;

		internal const long DURATION = 300;

		internal const long FINAL_DURATION = 200;

		internal const long RING_DELAY = 1300;

		internal const long FINAL_DELAY = 200;

		internal const long SHORT_DELAY = 100;

		internal const long WAVE_DURATION = 2000;

		internal const long RESET_TIMEOUT = 3000;

		internal const long DELAY_INCREMENT = 15;

		internal const long DELAY_INCREMENT2 = 12;

		internal const long WAVE_DELAY = WAVE_DURATION / WAVE_COUNT;

		private android.os.Vibrator mVibrator;

		private android.widget.@internal.WaveView.OnTriggerListener mOnTriggerListener;

		private java.util.ArrayList<android.widget.@internal.DrawableHolder> mDrawables = 
			new java.util.ArrayList<android.widget.@internal.DrawableHolder>(3);

		private java.util.ArrayList<android.widget.@internal.DrawableHolder> mLightWaves = 
			new java.util.ArrayList<android.widget.@internal.DrawableHolder>(WAVE_COUNT);

		private bool mFingerDown = false;

		private float mRingRadius = 182.0f;

		private int mSnapRadius = 136;

		private int mWaveCount = WAVE_COUNT;

		private long mWaveTimerDelay = WAVE_DELAY;

		private int mCurrentWave = 0;

		private float mLockCenterX;

		private float mLockCenterY;

		private float mMouseX;

		private float mMouseY;

		private android.widget.@internal.DrawableHolder mUnlockRing;

		private android.widget.@internal.DrawableHolder mUnlockDefault;

		private android.widget.@internal.DrawableHolder mUnlockHalo;

		private int mLockState = STATE_RESET_LOCK;

		private int mGrabbedState = android.widget.@internal.WaveView.OnTriggerListenerClass.NO_HANDLE;

		private bool mWavesRunning;

		private bool mFinishWaves;

		[Sharpen.Stub]
		public WaveView(android.content.Context context) : this(context, null)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public WaveView(android.content.Context context, android.util.AttributeSet attrs)
			 : base(context, attrs)
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
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onMeasure(int widthMeasureSpec, int heightMeasureSpec
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void initDrawables()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void waveUpdateFrame(float mouseX, float mouseY, bool fingerDown)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual android.graphics.drawable.BitmapDrawable createDrawable(int resId
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

		private sealed class _Runnable_397 : java.lang.Runnable
		{
			public _Runnable_397()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public void run()
			{
				throw new System.NotImplementedException();
			}
		}

		private readonly java.lang.Runnable mLockTimerActions = new _Runnable_397();

		private sealed class _Runnable_414 : java.lang.Runnable
		{
			public _Runnable_414()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public void run()
			{
				throw new System.NotImplementedException();
			}
		}

		private readonly java.lang.Runnable mAddWaveAction = new _Runnable_414();

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool onTouchEvent(android.view.MotionEvent @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void vibrate(long duration)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setOnTriggerListener(android.widget.@internal.WaveView.OnTriggerListener
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
		private void setGrabbedState(int newState)
		{
			throw new System.NotImplementedException();
		}

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

			public const int CENTER_HANDLE = 10;
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.animation.ValueAnimator.AnimatorUpdateListener"
			)]
		public virtual void onAnimationUpdate(android.animation.ValueAnimator animation)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void reset()
		{
			throw new System.NotImplementedException();
		}
	}
}

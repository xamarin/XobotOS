using Sharpen;

namespace android.animation
{
	[Sharpen.Stub]
	public class ValueAnimator : android.animation.Animator
	{
		internal const long DEFAULT_FRAME_DELAY = 10;

		internal const int ANIMATION_START = 0;

		internal const int ANIMATION_FRAME = 1;

		internal const int STOPPED = 0;

		internal const int RUNNING = 1;

		internal const int SEEKED = 2;

		internal long mStartTime;

		internal long mSeekTime = -1;

		private static java.lang.ThreadLocal<android.animation.ValueAnimator.AnimationHandler
			> sAnimationHandler = new java.lang.ThreadLocal<android.animation.ValueAnimator.
			AnimationHandler>();

		private sealed class _ThreadLocal_98 : java.lang.ThreadLocal<java.util.ArrayList<
			android.animation.ValueAnimator>>
		{
			public _ThreadLocal_98()
			{
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"java.lang.ThreadLocal")]
			protected internal override java.util.ArrayList<android.animation.ValueAnimator> 
				initialValue()
			{
				throw new System.NotImplementedException();
			}
		}

		private static readonly java.lang.ThreadLocal<java.util.ArrayList<android.animation.ValueAnimator
			>> sAnimations = new _ThreadLocal_98();

		private sealed class _ThreadLocal_107 : java.lang.ThreadLocal<java.util.ArrayList
			<android.animation.ValueAnimator>>
		{
			public _ThreadLocal_107()
			{
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"java.lang.ThreadLocal")]
			protected internal override java.util.ArrayList<android.animation.ValueAnimator> 
				initialValue()
			{
				throw new System.NotImplementedException();
			}
		}

		private static readonly java.lang.ThreadLocal<java.util.ArrayList<android.animation.ValueAnimator
			>> sPendingAnimations = new _ThreadLocal_107();

		private sealed class _ThreadLocal_119 : java.lang.ThreadLocal<java.util.ArrayList
			<android.animation.ValueAnimator>>
		{
			public _ThreadLocal_119()
			{
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"java.lang.ThreadLocal")]
			protected internal override java.util.ArrayList<android.animation.ValueAnimator> 
				initialValue()
			{
				throw new System.NotImplementedException();
			}
		}

		private static readonly java.lang.ThreadLocal<java.util.ArrayList<android.animation.ValueAnimator
			>> sDelayedAnims = new _ThreadLocal_119();

		private sealed class _ThreadLocal_127 : java.lang.ThreadLocal<java.util.ArrayList
			<android.animation.ValueAnimator>>
		{
			public _ThreadLocal_127()
			{
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"java.lang.ThreadLocal")]
			protected internal override java.util.ArrayList<android.animation.ValueAnimator> 
				initialValue()
			{
				throw new System.NotImplementedException();
			}
		}

		private static readonly java.lang.ThreadLocal<java.util.ArrayList<android.animation.ValueAnimator
			>> sEndingAnims = new _ThreadLocal_127();

		private sealed class _ThreadLocal_135 : java.lang.ThreadLocal<java.util.ArrayList
			<android.animation.ValueAnimator>>
		{
			public _ThreadLocal_135()
			{
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"java.lang.ThreadLocal")]
			protected internal override java.util.ArrayList<android.animation.ValueAnimator> 
				initialValue()
			{
				throw new System.NotImplementedException();
			}
		}

		private static readonly java.lang.ThreadLocal<java.util.ArrayList<android.animation.ValueAnimator
			>> sReadyAnims = new _ThreadLocal_135();

		private static readonly android.animation.TimeInterpolator sDefaultInterpolator = 
			new android.view.animation.AccelerateDecelerateInterpolator();

		private static readonly android.animation.TypeEvaluator<object> sIntEvaluator;

		private static readonly android.animation.TypeEvaluator<object> sFloatEvaluator;

		private bool mPlayingBackwards = false;

		private int mCurrentIteration = 0;

		private float mCurrentFraction = 0f;

		private bool mStartedDelay = false;

		private long mDelayStartTime;

		internal int mPlayingState = STOPPED;

		private bool mRunning = false;

		private bool mStarted = false;

		internal bool mInitialized = false;

		private long mDuration = 300;

		private long mStartDelay = 0;

		private static long sFrameDelay = DEFAULT_FRAME_DELAY;

		private int mRepeatCount = 0;

		private int mRepeatMode = RESTART;

		private android.animation.TimeInterpolator mInterpolator = sDefaultInterpolator;

		private java.util.ArrayList<android.animation.ValueAnimator.AnimatorUpdateListener
			> mUpdateListeners = null;

		internal android.animation.PropertyValuesHolder[] mValues;

		internal java.util.HashMap<string, android.animation.PropertyValuesHolder> mValuesMap;

		public const int RESTART = 1;

		public const int REVERSE = 2;

		public const int INFINITE = -1;

		[Sharpen.Stub]
		public ValueAnimator()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.animation.ValueAnimator ofInt(params int[] values)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.animation.ValueAnimator ofFloat(params float[] values)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.animation.ValueAnimator ofPropertyValuesHolder(params android.animation.PropertyValuesHolder
			[] values)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.animation.ValueAnimator ofObject(android.animation.TypeEvaluator
			<object> evaluator, params object[] values)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setIntValues(params int[] values)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setFloatValues(params float[] values)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setObjectValues(params object[] values)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setValues(params android.animation.PropertyValuesHolder[] values
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.animation.PropertyValuesHolder[] getValues()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void initAnimation()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.animation.Animator")]
		public override android.animation.Animator setDuration(long duration)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.animation.Animator")]
		public override long getDuration()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setCurrentPlayTime(long playTime)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual long getCurrentPlayTime()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private class AnimationHandler : android.os.Handler
		{
			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.os.Handler")]
			public override void handleMessage(android.os.Message msg)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.animation.Animator")]
		public override long getStartDelay()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.animation.Animator")]
		public override void setStartDelay(long startDelay)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static long getFrameDelay()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void setFrameDelay(long frameDelay)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual object getAnimatedValue()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual object getAnimatedValue(string propertyName)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setRepeatCount(int value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getRepeatCount()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setRepeatMode(int value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getRepeatMode()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void addUpdateListener(android.animation.ValueAnimator.AnimatorUpdateListener
			 listener)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void removeAllUpdateListeners()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void removeUpdateListener(android.animation.ValueAnimator.AnimatorUpdateListener
			 listener)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.animation.Animator")]
		public override void setInterpolator(android.animation.TimeInterpolator value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.animation.TimeInterpolator getInterpolator()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setEvaluator(android.animation.TypeEvaluator<object> value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void start(bool playBackwards)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.animation.Animator")]
		public override void start()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.animation.Animator")]
		public override void cancel()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.animation.Animator")]
		public override void end()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.animation.Animator")]
		public override bool isRunning()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.animation.Animator")]
		public override bool isStarted()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void reverse()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void endAnimation()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void startAnimation()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private bool delayedAnimationFrame(long currentTime)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual bool animationFrame(long currentTime)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual float getAnimatedFraction()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void animateValue(float fraction)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.animation.Animator")]
		public override android.animation.Animator clone()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public interface AnimatorUpdateListener
		{
			[Sharpen.Stub]
			void onAnimationUpdate(android.animation.ValueAnimator animation);
		}

		[Sharpen.Stub]
		public static int getCurrentAnimationsCount()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void clearAllAnimations()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			throw new System.NotImplementedException();
		}
	}
}

using Sharpen;

namespace android.view
{
	[Sharpen.Stub]
	public class ViewPropertyAnimator
	{
		private readonly android.view.View mView;

		private long mDuration;

		private bool mDurationSet = false;

		private long mStartDelay = 0;

		private bool mStartDelaySet = false;

		private android.animation.TimeInterpolator mInterpolator;

		private bool mInterpolatorSet = false;

		private android.animation.Animator.AnimatorListener mListener = null;

		private android.view.ViewPropertyAnimator.AnimatorEventListener mAnimatorEventListener;

		private java.util.ArrayList<android.view.ViewPropertyAnimator.NameValuesHolder> mPendingAnimations
			 = new java.util.ArrayList<android.view.ViewPropertyAnimator.NameValuesHolder>();

		internal const int NONE = unchecked((int)(0x0000));

		internal const int TRANSLATION_X = unchecked((int)(0x0001));

		internal const int TRANSLATION_Y = unchecked((int)(0x0002));

		internal const int SCALE_X = unchecked((int)(0x0004));

		internal const int SCALE_Y = unchecked((int)(0x0008));

		internal const int ROTATION = unchecked((int)(0x0010));

		internal const int ROTATION_X = unchecked((int)(0x0020));

		internal const int ROTATION_Y = unchecked((int)(0x0040));

		internal const int X = unchecked((int)(0x0080));

		internal const int Y = unchecked((int)(0x0100));

		internal const int ALPHA = unchecked((int)(0x0200));

		internal const int TRANSFORM_MASK = TRANSLATION_X | TRANSLATION_Y | SCALE_X | SCALE_Y
			 | ROTATION | ROTATION_X | ROTATION_Y | X | Y;

		private sealed class _Runnable_144 : java.lang.Runnable
		{
			public _Runnable_144()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public void run()
			{
				throw new System.NotImplementedException();
			}
		}

		private java.lang.Runnable mAnimationStarter = new _Runnable_144();

		[Sharpen.Stub]
		private class PropertyBundle
		{
			internal int mPropertyMask;

			internal java.util.ArrayList<android.view.ViewPropertyAnimator.NameValuesHolder> 
				mNameValuesHolder;

			[Sharpen.Stub]
			internal PropertyBundle(int propertyMask, java.util.ArrayList<android.view.ViewPropertyAnimator
				.NameValuesHolder> nameValuesHolder)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal virtual bool cancel(int propertyConstant)
			{
				throw new System.NotImplementedException();
			}
		}

		private java.util.HashMap<android.animation.Animator, android.view.ViewPropertyAnimator
			.PropertyBundle> mAnimatorMap = new java.util.HashMap<android.animation.Animator
			, android.view.ViewPropertyAnimator.PropertyBundle>();

		[Sharpen.Stub]
		private class NameValuesHolder
		{
			internal int mNameConstant;

			internal float mFromValue;

			internal float mDeltaValue;

			[Sharpen.Stub]
			internal NameValuesHolder(int nameConstant, float fromValue, float deltaValue)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		internal ViewPropertyAnimator(android.view.View view)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.view.ViewPropertyAnimator setDuration(long duration)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual long getDuration()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual long getStartDelay()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.view.ViewPropertyAnimator setStartDelay(long startDelay)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.view.ViewPropertyAnimator setInterpolator(android.animation.TimeInterpolator
			 interpolator)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.view.ViewPropertyAnimator setListener(android.animation.Animator
			.AnimatorListener listener)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void start()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void cancel()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.view.ViewPropertyAnimator x(float value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.view.ViewPropertyAnimator xBy(float value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.view.ViewPropertyAnimator y(float value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.view.ViewPropertyAnimator yBy(float value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.view.ViewPropertyAnimator rotation(float value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.view.ViewPropertyAnimator rotationBy(float value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.view.ViewPropertyAnimator rotationX(float value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.view.ViewPropertyAnimator rotationXBy(float value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.view.ViewPropertyAnimator rotationY(float value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.view.ViewPropertyAnimator rotationYBy(float value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.view.ViewPropertyAnimator translationX(float value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.view.ViewPropertyAnimator translationXBy(float value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.view.ViewPropertyAnimator translationY(float value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.view.ViewPropertyAnimator translationYBy(float value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.view.ViewPropertyAnimator scaleX(float value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.view.ViewPropertyAnimator scaleXBy(float value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.view.ViewPropertyAnimator scaleY(float value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.view.ViewPropertyAnimator scaleYBy(float value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.view.ViewPropertyAnimator alpha(float value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.view.ViewPropertyAnimator alphaBy(float value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void startAnimation()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void animateProperty(int constantName, float toValue)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void animatePropertyBy(int constantName, float byValue)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void animatePropertyBy(int constantName, float startValue, float byValue)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void setValue(int propertyConstant, float value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private float getValue(int propertyConstant)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private class AnimatorEventListener : android.animation.Animator.AnimatorListener
			, android.animation.ValueAnimator.AnimatorUpdateListener
		{
			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.animation.Animator.AnimatorListener")]
			public virtual void onAnimationStart(android.animation.Animator animation)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.animation.Animator.AnimatorListener")]
			public virtual void onAnimationCancel(android.animation.Animator animation)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.animation.Animator.AnimatorListener")]
			public virtual void onAnimationRepeat(android.animation.Animator animation)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.animation.Animator.AnimatorListener")]
			public virtual void onAnimationEnd(android.animation.Animator animation)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.animation.ValueAnimator.AnimatorUpdateListener"
				)]
			public virtual void onAnimationUpdate(android.animation.ValueAnimator animation)
			{
				throw new System.NotImplementedException();
			}

			internal AnimatorEventListener(ViewPropertyAnimator _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly ViewPropertyAnimator _enclosing;
		}
	}
}

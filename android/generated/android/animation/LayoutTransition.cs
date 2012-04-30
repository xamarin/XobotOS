using Sharpen;

namespace android.animation
{
	[Sharpen.Stub]
	public class LayoutTransition
	{
		public const int CHANGE_APPEARING = 0;

		public const int CHANGE_DISAPPEARING = 1;

		public const int APPEARING = 2;

		public const int DISAPPEARING = 3;

		private android.animation.Animator mDisappearingAnim = null;

		private android.animation.Animator mAppearingAnim = null;

		private android.animation.Animator mChangingAppearingAnim = null;

		private android.animation.Animator mChangingDisappearingAnim = null;

		private static android.animation.ObjectAnimator defaultChangeIn;

		private static android.animation.ObjectAnimator defaultChangeOut;

		private static android.animation.ObjectAnimator defaultFadeIn;

		private static android.animation.ObjectAnimator defaultFadeOut;

		private static long DEFAULT_DURATION = 300;

		private long mChangingAppearingDuration = DEFAULT_DURATION;

		private long mChangingDisappearingDuration = DEFAULT_DURATION;

		private long mAppearingDuration = DEFAULT_DURATION;

		private long mDisappearingDuration = DEFAULT_DURATION;

		private long mAppearingDelay = DEFAULT_DURATION;

		private long mDisappearingDelay = 0;

		private long mChangingAppearingDelay = 0;

		private long mChangingDisappearingDelay = DEFAULT_DURATION;

		private long mChangingAppearingStagger = 0;

		private long mChangingDisappearingStagger = 0;

		private android.animation.TimeInterpolator mAppearingInterpolator = new android.view.animation.AccelerateDecelerateInterpolator
			();

		private android.animation.TimeInterpolator mDisappearingInterpolator = new android.view.animation.AccelerateDecelerateInterpolator
			();

		private android.animation.TimeInterpolator mChangingAppearingInterpolator = new android.view.animation.DecelerateInterpolator
			();

		private android.animation.TimeInterpolator mChangingDisappearingInterpolator = new 
			android.view.animation.DecelerateInterpolator();

		private readonly java.util.HashMap<android.view.View, android.animation.Animator>
			 pendingAnimations = new java.util.HashMap<android.view.View, android.animation.Animator
			>();

		private readonly java.util.LinkedHashMap<android.view.View, android.animation.Animator
			> currentChangingAnimations = new java.util.LinkedHashMap<android.view.View, android.animation.Animator
			>();

		private readonly java.util.LinkedHashMap<android.view.View, android.animation.Animator
			> currentAppearingAnimations = new java.util.LinkedHashMap<android.view.View, android.animation.Animator
			>();

		private readonly java.util.LinkedHashMap<android.view.View, android.animation.Animator
			> currentDisappearingAnimations = new java.util.LinkedHashMap<android.view.View, 
			android.animation.Animator>();

		private readonly java.util.HashMap<android.view.View, android.view.View.OnLayoutChangeListener
			> layoutChangeListenerMap = new java.util.HashMap<android.view.View, android.view.View
			.OnLayoutChangeListener>();

		private long staggerDelay;

		private java.util.ArrayList<android.animation.LayoutTransition.TransitionListener
			> mListeners;

		private bool mAnimateParentHierarchy = true;

		[Sharpen.Stub]
		public LayoutTransition()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setDuration(long duration)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setStartDelay(int transitionType, long delay)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual long getStartDelay(int transitionType)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setDuration(int transitionType, long duration)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual long getDuration(int transitionType)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setStagger(int transitionType, long duration)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual long getStagger(int transitionType)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setInterpolator(int transitionType, android.animation.TimeInterpolator
			 interpolator)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.animation.TimeInterpolator getInterpolator(int transitionType
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setAnimator(int transitionType, android.animation.Animator animator
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.animation.Animator getAnimator(int transitionType)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void runChangeTransition(android.view.ViewGroup parent, android.view.View
			 newView, int changeReason)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setAnimateParentHierarchy(bool animateParentHierarchy)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void setupChangeAnimation(android.view.ViewGroup parent, int changeReason
			, android.animation.Animator baseAnimator, long duration, android.view.View child
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void startChangingAnimations()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void endChangingAnimations()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isChangingLayout()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isRunning()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void cancel()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void cancel(int transitionType)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void runAppearingTransition(android.view.ViewGroup parent, android.view.View
			 child)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void runDisappearingTransition(android.view.ViewGroup parent, android.view.View
			 child)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void addChild(android.view.ViewGroup parent, android.view.View child
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void showChild(android.view.ViewGroup parent, android.view.View child
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void removeChild(android.view.ViewGroup parent, android.view.View 
			child)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void hideChild(android.view.ViewGroup parent, android.view.View child
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void addTransitionListener(android.animation.LayoutTransition.TransitionListener
			 listener)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void removeTransitionListener(android.animation.LayoutTransition.TransitionListener
			 listener)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual java.util.List<android.animation.LayoutTransition.TransitionListener
			> getTransitionListeners()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public interface TransitionListener
		{
			[Sharpen.Stub]
			void startTransition(android.animation.LayoutTransition transition, android.view.ViewGroup
				 container, android.view.View view, int transitionType);

			[Sharpen.Stub]
			void endTransition(android.animation.LayoutTransition transition, android.view.ViewGroup
				 container, android.view.View view, int transitionType);
		}
	}
}

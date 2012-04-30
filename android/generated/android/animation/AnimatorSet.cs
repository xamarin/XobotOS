using Sharpen;

namespace android.animation
{
	[Sharpen.Stub]
	public sealed class AnimatorSet : android.animation.Animator
	{
		private java.util.ArrayList<android.animation.Animator> mPlayingSet = new java.util.ArrayList
			<android.animation.Animator>();

		private java.util.HashMap<android.animation.Animator, android.animation.AnimatorSet
			.Node> mNodeMap = new java.util.HashMap<android.animation.Animator, android.animation.AnimatorSet
			.Node>();

		private java.util.ArrayList<android.animation.AnimatorSet.Node> mNodes = new java.util.ArrayList
			<android.animation.AnimatorSet.Node>();

		private java.util.ArrayList<android.animation.AnimatorSet.Node> mSortedNodes = new 
			java.util.ArrayList<android.animation.AnimatorSet.Node>();

		private bool mNeedsSort = true;

		private android.animation.AnimatorSet.AnimatorSetListener mSetListener = null;

		internal bool mTerminated = false;

		private bool mStarted = false;

		private long mStartDelay = 0;

		private android.animation.ValueAnimator mDelayAnim = null;

		private long mDuration = -1;

		[Sharpen.Stub]
		public void playTogether(params android.animation.Animator[] items)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void playTogether(java.util.Collection<android.animation.Animator> items)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void playSequentially(params android.animation.Animator[] items)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void playSequentially(java.util.List<android.animation.Animator> items)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public java.util.ArrayList<android.animation.Animator> getChildAnimations()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.animation.Animator")]
		public override void setTarget(object target)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.animation.Animator")]
		public override void setInterpolator(android.animation.TimeInterpolator interpolator
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.animation.AnimatorSet.Builder play(android.animation.Animator anim
			)
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
		[Sharpen.OverridesMethod(@"android.animation.Animator")]
		public override long getDuration()
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
		public override void setupStartValues()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.animation.Animator")]
		public override void setupEndValues()
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
		public override android.animation.Animator clone()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private class DependencyListener : android.animation.Animator.AnimatorListener
		{
			internal android.animation.AnimatorSet mAnimatorSet;

			internal android.animation.AnimatorSet.Node mNode;

			internal int mRule;

			[Sharpen.Stub]
			public DependencyListener(android.animation.AnimatorSet animatorSet, android.animation.AnimatorSet
				.Node node, int rule)
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
			public virtual void onAnimationEnd(android.animation.Animator animation)
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
			public virtual void onAnimationStart(android.animation.Animator animation)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal void startIfReady(android.animation.Animator dependencyAnimation)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		private class AnimatorSetListener : android.animation.Animator.AnimatorListener
		{
			internal android.animation.AnimatorSet mAnimatorSet;

			[Sharpen.Stub]
			internal AnimatorSetListener(AnimatorSet _enclosing, android.animation.AnimatorSet
				 animatorSet)
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
			public virtual void onAnimationEnd(android.animation.Animator animation)
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
			public virtual void onAnimationStart(android.animation.Animator animation)
			{
				throw new System.NotImplementedException();
			}

			private readonly AnimatorSet _enclosing;
		}

		[Sharpen.Stub]
		private void sortNodes()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private class Dependency
		{
			internal const int WITH = 0;

			internal const int AFTER = 1;

			internal android.animation.AnimatorSet.Node node;

			public int rule;

			[Sharpen.Stub]
			public Dependency(android.animation.AnimatorSet.Node node, int rule)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		private class Node : System.ICloneable
		{
			public android.animation.Animator animation;

			internal java.util.ArrayList<android.animation.AnimatorSet.Dependency> dependencies
				 = null;

			internal java.util.ArrayList<android.animation.AnimatorSet.Dependency> tmpDependencies
				 = null;

			internal java.util.ArrayList<android.animation.AnimatorSet.Node> nodeDependencies
				 = null;

			internal java.util.ArrayList<android.animation.AnimatorSet.Node> nodeDependents = 
				null;

			public bool done = false;

			[Sharpen.Stub]
			public Node(android.animation.Animator animation)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void addDependency(android.animation.AnimatorSet.Dependency dependency
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.animation.AnimatorSet.Node clone()
			{
				throw new System.NotImplementedException();
			}

			object System.ICloneable.Clone()
			{
				return MemberwiseClone();
			}
		}

		[Sharpen.Stub]
		public class Builder
		{
			private android.animation.AnimatorSet.Node mCurrentNode;

			[Sharpen.Stub]
			internal Builder(AnimatorSet _enclosing, android.animation.Animator anim)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.animation.AnimatorSet.Builder with(android.animation.Animator
				 anim)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.animation.AnimatorSet.Builder before(android.animation.Animator
				 anim)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.animation.AnimatorSet.Builder after(android.animation.Animator
				 anim)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.animation.AnimatorSet.Builder after(long delay)
			{
				throw new System.NotImplementedException();
			}

			private readonly AnimatorSet _enclosing;
		}
	}
}

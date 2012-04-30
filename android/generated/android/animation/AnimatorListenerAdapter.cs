using Sharpen;

namespace android.animation
{
	/// <summary>
	/// This adapter class provides empty implementations of the methods from
	/// <see cref="AnimatorListener">AnimatorListener</see>
	/// .
	/// Any custom listener that cares only about a subset of the methods of this listener can
	/// simply subclass this adapter class instead of implementing the interface directly.
	/// </summary>
	[Sharpen.Sharpened]
	public abstract class AnimatorListenerAdapter : android.animation.Animator.AnimatorListener
	{
		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.ImplementsInterface(@"android.animation.Animator.AnimatorListener")]
		public virtual void onAnimationCancel(android.animation.Animator animation)
		{
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.ImplementsInterface(@"android.animation.Animator.AnimatorListener")]
		public virtual void onAnimationEnd(android.animation.Animator animation)
		{
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.ImplementsInterface(@"android.animation.Animator.AnimatorListener")]
		public virtual void onAnimationRepeat(android.animation.Animator animation)
		{
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.ImplementsInterface(@"android.animation.Animator.AnimatorListener")]
		public virtual void onAnimationStart(android.animation.Animator animation)
		{
		}
	}
}

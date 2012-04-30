using Sharpen;

namespace android.animation
{
	[Sharpen.Stub]
	public class TimeAnimator : android.animation.ValueAnimator
	{
		private android.animation.TimeAnimator.TimeListener mListener;

		private long mPreviousTime = -1;

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.animation.ValueAnimator")]
		internal override bool animationFrame(long currentTime)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setTimeListener(android.animation.TimeAnimator.TimeListener listener
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.animation.ValueAnimator")]
		internal override void animateValue(float fraction)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.animation.ValueAnimator")]
		internal override void initAnimation()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public interface TimeListener
		{
			[Sharpen.Stub]
			void onTimeUpdate(android.animation.TimeAnimator animation, long totalTime, long 
				deltaTime);
		}
	}
}

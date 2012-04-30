using Sharpen;

namespace android.view.animation
{
	/// <summary>An interpolator where the rate of change is constant</summary>
	[Sharpen.Sharpened]
	public class LinearInterpolator : android.view.animation.Interpolator
	{
		public LinearInterpolator()
		{
		}

		public LinearInterpolator(android.content.Context context, android.util.AttributeSet
			 attrs)
		{
		}

		[Sharpen.ImplementsInterface(@"android.animation.TimeInterpolator")]
		public virtual float getInterpolation(float input)
		{
			return input;
		}
	}
}

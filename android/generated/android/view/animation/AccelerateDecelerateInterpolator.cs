using Sharpen;

namespace android.view.animation
{
	/// <summary>
	/// An interpolator where the rate of change starts and ends slowly but
	/// accelerates through the middle.
	/// </summary>
	/// <remarks>
	/// An interpolator where the rate of change starts and ends slowly but
	/// accelerates through the middle.
	/// </remarks>
	[Sharpen.Sharpened]
	public class AccelerateDecelerateInterpolator : android.view.animation.Interpolator
	{
		public AccelerateDecelerateInterpolator()
		{
		}

		public AccelerateDecelerateInterpolator(android.content.Context context, android.util.AttributeSet
			 attrs)
		{
		}

		[Sharpen.ImplementsInterface(@"android.animation.TimeInterpolator")]
		public virtual float getInterpolation(float input)
		{
			return (float)(System.Math.Cos((input + 1) * System.Math.PI) / 2.0f) + 0.5f;
		}
	}
}

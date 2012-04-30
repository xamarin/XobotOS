using Sharpen;

namespace android.view.animation
{
	/// <summary>Repeats the animation for a specified number of cycles.</summary>
	/// <remarks>
	/// Repeats the animation for a specified number of cycles. The
	/// rate of change follows a sinusoidal pattern.
	/// </remarks>
	[Sharpen.Sharpened]
	public class CycleInterpolator : android.view.animation.Interpolator
	{
		public CycleInterpolator(float cycles)
		{
			mCycles = cycles;
		}

		public CycleInterpolator(android.content.Context context, android.util.AttributeSet
			 attrs)
		{
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.CycleInterpolator);
			mCycles = a.getFloat(android.@internal.R.styleable.CycleInterpolator_cycles, 1.0f
				);
			a.recycle();
		}

		[Sharpen.ImplementsInterface(@"android.animation.TimeInterpolator")]
		public virtual float getInterpolation(float input)
		{
			return (float)(System.Math.Sin(2 * mCycles * System.Math.PI * input));
		}

		private float mCycles;
	}
}

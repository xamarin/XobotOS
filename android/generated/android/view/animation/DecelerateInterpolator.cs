using Sharpen;

namespace android.view.animation
{
	/// <summary>
	/// An interpolator where the rate of change starts out quickly and
	/// and then decelerates.
	/// </summary>
	/// <remarks>
	/// An interpolator where the rate of change starts out quickly and
	/// and then decelerates.
	/// </remarks>
	[Sharpen.Sharpened]
	public class DecelerateInterpolator : android.view.animation.Interpolator
	{
		public DecelerateInterpolator()
		{
		}

		/// <summary>Constructor</summary>
		/// <param name="factor">
		/// Degree to which the animation should be eased. Setting factor to 1.0f produces
		/// an upside-down y=x^2 parabola. Increasing factor above 1.0f makes exaggerates the
		/// ease-out effect (i.e., it starts even faster and ends evens slower)
		/// </param>
		public DecelerateInterpolator(float factor)
		{
			mFactor = factor;
		}

		public DecelerateInterpolator(android.content.Context context, android.util.AttributeSet
			 attrs)
		{
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.DecelerateInterpolator);
			mFactor = a.getFloat(android.@internal.R.styleable.DecelerateInterpolator_factor, 
				1.0f);
			a.recycle();
		}

		[Sharpen.ImplementsInterface(@"android.animation.TimeInterpolator")]
		public virtual float getInterpolation(float input)
		{
			float result;
			if (mFactor == 1.0f)
			{
				result = (float)(1.0f - (1.0f - input) * (1.0f - input));
			}
			else
			{
				result = (float)(1.0f - System.Math.Pow((1.0f - input), 2 * mFactor));
			}
			return result;
		}

		private float mFactor = 1.0f;
	}
}

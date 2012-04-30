using Sharpen;

namespace android.view.animation
{
	/// <summary>
	/// An interpolator where the rate of change starts out slowly and
	/// and then accelerates.
	/// </summary>
	/// <remarks>
	/// An interpolator where the rate of change starts out slowly and
	/// and then accelerates.
	/// </remarks>
	[Sharpen.Sharpened]
	public class AccelerateInterpolator : android.view.animation.Interpolator
	{
		private readonly float mFactor;

		private readonly double mDoubleFactor;

		public AccelerateInterpolator()
		{
			mFactor = 1.0f;
			mDoubleFactor = 2.0;
		}

		/// <summary>Constructor</summary>
		/// <param name="factor">
		/// Degree to which the animation should be eased. Seting
		/// factor to 1.0f produces a y=x^2 parabola. Increasing factor above
		/// 1.0f  exaggerates the ease-in effect (i.e., it starts even
		/// slower and ends evens faster)
		/// </param>
		public AccelerateInterpolator(float factor)
		{
			mFactor = factor;
			mDoubleFactor = 2 * mFactor;
		}

		public AccelerateInterpolator(android.content.Context context, android.util.AttributeSet
			 attrs)
		{
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.AccelerateInterpolator);
			mFactor = a.getFloat(android.@internal.R.styleable.AccelerateInterpolator_factor, 
				1.0f);
			mDoubleFactor = 2 * mFactor;
			a.recycle();
		}

		[Sharpen.ImplementsInterface(@"android.animation.TimeInterpolator")]
		public virtual float getInterpolation(float input)
		{
			if (mFactor == 1.0f)
			{
				return input * input;
			}
			else
			{
				return (float)System.Math.Pow(input, mDoubleFactor);
			}
		}
	}
}

using Sharpen;

namespace android.view.animation
{
	/// <summary>
	/// An interpolator where the change starts backward then flings forward and overshoots
	/// the target value and finally goes back to the final value.
	/// </summary>
	/// <remarks>
	/// An interpolator where the change starts backward then flings forward and overshoots
	/// the target value and finally goes back to the final value.
	/// </remarks>
	[Sharpen.Sharpened]
	public class AnticipateOvershootInterpolator : android.view.animation.Interpolator
	{
		private readonly float mTension;

		public AnticipateOvershootInterpolator()
		{
			mTension = 2.0f * 1.5f;
		}

		/// <param name="tension">
		/// Amount of anticipation/overshoot. When tension equals 0.0f,
		/// there is no anticipation/overshoot and the interpolator becomes
		/// a simple acceleration/deceleration interpolator.
		/// </param>
		public AnticipateOvershootInterpolator(float tension)
		{
			mTension = tension * 1.5f;
		}

		/// <param name="tension">
		/// Amount of anticipation/overshoot. When tension equals 0.0f,
		/// there is no anticipation/overshoot and the interpolator becomes
		/// a simple acceleration/deceleration interpolator.
		/// </param>
		/// <param name="extraTension">
		/// Amount by which to multiply the tension. For instance,
		/// to get the same overshoot as an OvershootInterpolator with
		/// a tension of 2.0f, you would use an extraTension of 1.5f.
		/// </param>
		public AnticipateOvershootInterpolator(float tension, float extraTension)
		{
			mTension = tension * extraTension;
		}

		public AnticipateOvershootInterpolator(android.content.Context context, android.util.AttributeSet
			 attrs)
		{
			android.content.res.TypedArray a_1 = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.AnticipateOvershootInterpolator);
			mTension = a_1.getFloat(android.@internal.R.styleable.AnticipateOvershootInterpolator_tension
				, 2.0f) * a_1.getFloat(android.@internal.R.styleable.AnticipateOvershootInterpolator_extraTension
				, 1.5f);
			a_1.recycle();
		}

		private static float a(float t, float s)
		{
			return t * t * ((s + 1) * t - s);
		}

		private static float o(float t, float s)
		{
			return t * t * ((s + 1) * t + s);
		}

		[Sharpen.ImplementsInterface(@"android.animation.TimeInterpolator")]
		public virtual float getInterpolation(float t)
		{
			// a(t, s) = t * t * ((s + 1) * t - s)
			// o(t, s) = t * t * ((s + 1) * t + s)
			// f(t) = 0.5 * a(t * 2, tension * extraTension), when t < 0.5
			// f(t) = 0.5 * (o(t * 2 - 2, tension * extraTension) + 2), when t <= 1.0
			if (t < 0.5f)
			{
				return 0.5f * a(t * 2.0f, mTension);
			}
			else
			{
				return 0.5f * (o(t * 2.0f - 2.0f, mTension) + 2.0f);
			}
		}
	}
}

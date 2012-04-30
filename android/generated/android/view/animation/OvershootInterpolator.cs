using Sharpen;

namespace android.view.animation
{
	/// <summary>
	/// An interpolator where the change flings forward and overshoots the last value
	/// then comes back.
	/// </summary>
	/// <remarks>
	/// An interpolator where the change flings forward and overshoots the last value
	/// then comes back.
	/// </remarks>
	[Sharpen.Sharpened]
	public class OvershootInterpolator : android.view.animation.Interpolator
	{
		private readonly float mTension;

		public OvershootInterpolator()
		{
			mTension = 2.0f;
		}

		/// <param name="tension">
		/// Amount of overshoot. When tension equals 0.0f, there is
		/// no overshoot and the interpolator becomes a simple
		/// deceleration interpolator.
		/// </param>
		public OvershootInterpolator(float tension)
		{
			mTension = tension;
		}

		public OvershootInterpolator(android.content.Context context, android.util.AttributeSet
			 attrs)
		{
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.OvershootInterpolator);
			mTension = a.getFloat(android.@internal.R.styleable.OvershootInterpolator_tension
				, 2.0f);
			a.recycle();
		}

		[Sharpen.ImplementsInterface(@"android.animation.TimeInterpolator")]
		public virtual float getInterpolation(float t)
		{
			// _o(t) = t * t * ((tension + 1) * t + tension)
			// o(t) = _o(t - 1) + 1
			t -= 1.0f;
			return t * t * ((mTension + 1) * t + mTension) + 1.0f;
		}
	}
}

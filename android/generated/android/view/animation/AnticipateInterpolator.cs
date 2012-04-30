using Sharpen;

namespace android.view.animation
{
	/// <summary>An interpolator where the change starts backward then flings forward.</summary>
	/// <remarks>An interpolator where the change starts backward then flings forward.</remarks>
	[Sharpen.Sharpened]
	public class AnticipateInterpolator : android.view.animation.Interpolator
	{
		private readonly float mTension;

		public AnticipateInterpolator()
		{
			mTension = 2.0f;
		}

		/// <param name="tension">
		/// Amount of anticipation. When tension equals 0.0f, there is
		/// no anticipation and the interpolator becomes a simple
		/// acceleration interpolator.
		/// </param>
		public AnticipateInterpolator(float tension)
		{
			mTension = tension;
		}

		public AnticipateInterpolator(android.content.Context context, android.util.AttributeSet
			 attrs)
		{
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.AnticipateInterpolator);
			mTension = a.getFloat(android.@internal.R.styleable.AnticipateInterpolator_tension
				, 2.0f);
			a.recycle();
		}

		[Sharpen.ImplementsInterface(@"android.animation.TimeInterpolator")]
		public virtual float getInterpolation(float t)
		{
			// a(t) = t * t * ((tension + 1) * t - tension)
			return t * t * ((mTension + 1) * t - mTension);
		}
	}
}

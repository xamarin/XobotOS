using Sharpen;

namespace android.view.animation
{
	/// <summary>An interpolator where the change bounces at the end.</summary>
	/// <remarks>An interpolator where the change bounces at the end.</remarks>
	[Sharpen.Sharpened]
	public class BounceInterpolator : android.view.animation.Interpolator
	{
		public BounceInterpolator()
		{
		}

		public BounceInterpolator(android.content.Context context, android.util.AttributeSet
			 attrs)
		{
		}

		private static float bounce(float t)
		{
			return t * t * 8.0f;
		}

		[Sharpen.ImplementsInterface(@"android.animation.TimeInterpolator")]
		public virtual float getInterpolation(float t)
		{
			// _b(t) = t * t * 8
			// bs(t) = _b(t) for t < 0.3535
			// bs(t) = _b(t - 0.54719) + 0.7 for t < 0.7408
			// bs(t) = _b(t - 0.8526) + 0.9 for t < 0.9644
			// bs(t) = _b(t - 1.0435) + 0.95 for t <= 1.0
			// b(t) = bs(t * 1.1226)
			t *= 1.1226f;
			if (t < 0.3535f)
			{
				return bounce(t);
			}
			else
			{
				if (t < 0.7408f)
				{
					return bounce(t - 0.54719f) + 0.7f;
				}
				else
				{
					if (t < 0.9644f)
					{
						return bounce(t - 0.8526f) + 0.9f;
					}
					else
					{
						return bounce(t - 1.0435f) + 0.95f;
					}
				}
			}
		}
	}
}

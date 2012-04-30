using Sharpen;

namespace android.view.animation
{
	/// <summary>An interpolator defines the rate of change of an animation.</summary>
	/// <remarks>
	/// An interpolator defines the rate of change of an animation. This allows
	/// the basic animation effects (alpha, scale, translate, rotate) to be
	/// accelerated, decelerated, repeated, etc.
	/// </remarks>
	[Sharpen.Sharpened]
	public interface Interpolator : android.animation.TimeInterpolator
	{
		// A new interface, TimeInterpolator, was introduced for the new android.animation
		// package. This older Interpolator interface extends TimeInterpolator so that users of
		// the new Animator-based animations can use either the old Interpolator implementations or
		// new classes that implement TimeInterpolator directly.
	}
}

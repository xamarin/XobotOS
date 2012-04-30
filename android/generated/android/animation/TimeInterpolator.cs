using Sharpen;

namespace android.animation
{
	/// <summary>A time interpolator defines the rate of change of an animation.</summary>
	/// <remarks>
	/// A time interpolator defines the rate of change of an animation. This allows animations
	/// to have non-linear motion, such as acceleration and deceleration.
	/// </remarks>
	[Sharpen.Sharpened]
	public interface TimeInterpolator
	{
		/// <summary>
		/// Maps a value representing the elapsed fraction of an animation to a value that represents
		/// the interpolated fraction.
		/// </summary>
		/// <remarks>
		/// Maps a value representing the elapsed fraction of an animation to a value that represents
		/// the interpolated fraction. This interpolated value is then multiplied by the change in
		/// value of an animation to derive the animated value at the current elapsed animation time.
		/// </remarks>
		/// <param name="input">
		/// A value between 0 and 1.0 indicating our current point
		/// in the animation where 0 represents the start and 1.0 represents
		/// the end
		/// </param>
		/// <returns>
		/// The interpolation value. This value can be more than 1.0 for
		/// interpolators which overshoot their targets, or less than 0 for
		/// interpolators that undershoot their targets.
		/// </returns>
		float getInterpolation(float input);
	}
}

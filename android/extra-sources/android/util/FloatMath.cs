using System;
using Sharpen;

namespace android.util
{
	/// <summary>
	/// Math routines similar to those found in
	/// <see cref="System.Math">System.Math</see>
	/// . Performs
	/// computations on
	/// <code>float</code>
	/// values directly without incurring the overhead
	/// of conversions to and from
	/// <code>double</code>
	/// .
	/// <p>On one platform,
	/// <code>FloatMath.sqrt(100)</code>
	/// executes in one third of the
	/// time required by
	/// <code>java.lang.Math.sqrt(100)</code>
	/// .</p>
	/// </summary>
	[Sharpen.Sharpened]
	public static class FloatMath
	{
		/// <summary>Returns the float conversion of the most positive (i.e.</summary>
		/// <remarks>
		/// Returns the float conversion of the most positive (i.e. closest to
		/// positive infinity) integer value which is less than the argument.
		/// </remarks>
		/// <param name="value">to be converted</param>
		/// <returns>the floor of value</returns>
		public static float floor (float value)
		{
			return (float)Math.Floor (value);
		}

		/// <summary>Returns the float conversion of the most negative (i.e.</summary>
		/// <remarks>
		/// Returns the float conversion of the most negative (i.e. closest to
		/// negative infinity) integer value which is greater than the argument.
		/// </remarks>
		/// <param name="value">to be converted</param>
		/// <returns>the ceiling of value</returns>
		public static float ceil (float value)
		{
			return (float)Math.Ceiling (value);
		}

		/// <summary>Returns the closest float approximation of the sine of the argument.</summary>
		/// <remarks>Returns the closest float approximation of the sine of the argument.</remarks>
		/// <param name="angle">to compute the cosine of, in radians</param>
		/// <returns>the sine of angle</returns>
		public static float sin (float angle)
		{
			return (float)Math.Sin (angle);
		}

		/// <summary>Returns the closest float approximation of the cosine of the argument.</summary>
		/// <remarks>Returns the closest float approximation of the cosine of the argument.</remarks>
		/// <param name="angle">to compute the cosine of, in radians</param>
		/// <returns>the cosine of angle</returns>
		public static float cos (float angle)
		{
			return (float)Math.Cos (angle);
		}

		/// <summary>
		/// Returns the closest float approximation of the square root of the
		/// argument.
		/// </summary>
		/// <remarks>
		/// Returns the closest float approximation of the square root of the
		/// argument.
		/// </remarks>
		/// <param name="value">to compute sqrt of</param>
		/// <returns>the square root of value</returns>
		public static float sqrt (float value)
		{
			return (float)Math.Sqrt (value);
		}
	}
}

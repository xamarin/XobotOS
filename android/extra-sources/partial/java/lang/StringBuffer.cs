using System;

namespace java.lang
{
	partial class StringBuffer
	{
		/// <summary>
		/// Adds the string representation of the specified integer to the end of
		/// this StringBuffer.
		/// </summary>
		/// <remarks>
		/// Adds the string representation of the specified integer to the end of
		/// this StringBuffer.
		/// </remarks>
		/// <param name="i">the integer to append.</param>
		/// <returns>this StringBuffer.</returns>
		/// <seealso cref="string.ToString(int)">string.ToString(int)</seealso>
		public java.lang.StringBuffer append (int i)
		{
			append (i.ToString ());
			return this;
		}

		/// <summary>
		/// Adds the string representation of the specified long to the end of this
		/// StringBuffer.
		/// </summary>
		/// <remarks>
		/// Adds the string representation of the specified long to the end of this
		/// StringBuffer.
		/// </remarks>
		/// <param name="l">the long to append.</param>
		/// <returns>this StringBuffer.</returns>
		/// <seealso cref="string.ToString(long)">string.ToString(long)</seealso>
		public java.lang.StringBuffer append (long l)
		{
			append (l.ToString ());
			return this;
		}

		/// <summary>
		/// Adds the string representation of the specified double to the end of this
		/// StringBuffer.
		/// </summary>
		/// <remarks>
		/// Adds the string representation of the specified double to the end of this
		/// StringBuffer.
		/// </remarks>
		/// <param name="d">the double to append.</param>
		/// <returns>this StringBuffer.</returns>
		/// <seealso cref="string.ToString(double)">string.ToString(double)</seealso>
		public java.lang.StringBuffer append (double d)
		{
			append (d.ToString ());
			return this;
		}

		/// <summary>
		/// Adds the string representation of the specified float to the end of this
		/// StringBuffer.
		/// </summary>
		/// <remarks>
		/// Adds the string representation of the specified float to the end of this
		/// StringBuffer.
		/// </remarks>
		/// <param name="f">the float to append.</param>
		/// <returns>this StringBuffer.</returns>
		/// <seealso cref="string.ToString(float)">string.ToString(float)</seealso>
		public java.lang.StringBuffer append (float f)
		{
			append (f.ToString ());
			return this;
		}

	}
}


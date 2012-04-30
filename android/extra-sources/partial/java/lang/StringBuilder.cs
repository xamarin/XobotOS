using System;

namespace java.lang
{
	partial class StringBuilder
	{
		/// <summary>
		/// Appends the string representation of the specified
		/// <code>int</code>
		/// value. The
		/// <code>int</code>
		/// value is converted to a string according to the rule defined
		/// by
		/// <see cref="string.ToString(int)">string.ToString(int)</see>
		/// .
		/// </summary>
		/// <param name="i">
		/// the
		/// <code>int</code>
		/// value to append.
		/// </param>
		/// <returns>this builder.</returns>
		/// <seealso cref="string.ToString(int)">string.ToString(int)</seealso>
		public java.lang.StringBuilder append (int i)
		{
			append (i.ToString ());
			return this;
		}

		/// <summary>
		/// Appends the string representation of the specified
		/// <code>long</code>
		/// value.
		/// The
		/// <code>long</code>
		/// value is converted to a string according to the rule
		/// defined by
		/// <see cref="string.ToString(long)">string.ToString(long)</see>
		/// .
		/// </summary>
		/// <param name="l">
		/// the
		/// <code>long</code>
		/// value.
		/// </param>
		/// <returns>this builder.</returns>
		/// <seealso cref="string.ToString(long)">string.ToString(long)</seealso>
		public java.lang.StringBuilder append (long l)
		{
			append (l.ToString ());
			return this;
		}

		/// <summary>
		/// Appends the string representation of the specified
		/// <code>float</code>
		/// value.
		/// The
		/// <code>float</code>
		/// value is converted to a string according to the rule
		/// defined by
		/// <see cref="string.ToString(float)">string.ToString(float)</see>
		/// .
		/// </summary>
		/// <param name="f">
		/// the
		/// <code>float</code>
		/// value to append.
		/// </param>
		/// <returns>this builder.</returns>
		/// <seealso cref="string.ToString(float)">string.ToString(float)</seealso>
		public java.lang.StringBuilder append (float f)
		{
			append (f.ToString ());
			return this;
		}

		/// <summary>
		/// Appends the string representation of the specified
		/// <code>double</code>
		/// value.
		/// The
		/// <code>double</code>
		/// value is converted to a string according to the rule
		/// defined by
		/// <see cref="string.ToString(double)">string.ToString(double)</see>
		/// .
		/// </summary>
		/// <param name="d">
		/// the
		/// <code>double</code>
		/// value to append.
		/// </param>
		/// <returns>this builder.</returns>
		/// <seealso cref="string.ToString(double)">string.ToString(double)</seealso>
		public java.lang.StringBuilder append (double d)
		{
			append (d.ToString ());
			return this;
		}

	}
}


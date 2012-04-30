using Sharpen;

namespace java.util
{
	/// <summary>
	/// A
	/// <code>FormatFlagsConversionMismatchException</code>
	/// will be thrown if a
	/// conversion and the flags are incompatible.
	/// </summary>
	/// <seealso cref="java.lang.RuntimeException">java.lang.RuntimeException</seealso>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class FormatFlagsConversionMismatchException : java.util.IllegalFormatException
	{
		internal const long serialVersionUID = 19120414L;

		private readonly string f;

		private readonly char c;

		/// <summary>
		/// Constructs a new
		/// <code>FormatFlagsConversionMismatchException</code>
		/// with the
		/// flags and conversion specified.
		/// </summary>
		/// <param name="f">the flags.</param>
		/// <param name="c">the conversion.</param>
		public FormatFlagsConversionMismatchException(string f, char c)
		{
			if (f == null)
			{
				throw new System.ArgumentNullException();
			}
			this.f = f;
			this.c = c;
		}

		/// <summary>Returns the incompatible format flag.</summary>
		/// <remarks>Returns the incompatible format flag.</remarks>
		/// <returns>the incompatible format flag.</returns>
		public virtual string getFlags()
		{
			return f;
		}

		/// <summary>Returns the incompatible conversion.</summary>
		/// <remarks>Returns the incompatible conversion.</remarks>
		/// <returns>the incompatible conversion.</returns>
		public virtual char getConversion()
		{
			return c;
		}

		public override string Message
		{
			get
			{
				return "%" + c + " does not support '" + f + "'";
			}
		}
	}
}

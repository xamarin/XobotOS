using Sharpen;

namespace java.util
{
	/// <summary>
	/// An
	/// <code>IllegalFormatConversionException</code>
	/// will be thrown when the parameter
	/// is incompatible with the corresponding format specifier.
	/// </summary>
	/// <seealso cref="java.lang.RuntimeException">java.lang.RuntimeException</seealso>
	/// <since>1.5</since>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class IllegalFormatConversionException : java.util.IllegalFormatException
	{
		internal const long serialVersionUID = 17000126L;

		private readonly char c;

		private readonly System.Type arg;

		/// <summary>
		/// Constructs a new
		/// <code>IllegalFormatConversionException</code>
		/// with the class
		/// of the mismatched conversion and corresponding parameter.
		/// </summary>
		/// <param name="c">the class of the mismatched conversion.</param>
		/// <param name="arg">the corresponding parameter.</param>
		public IllegalFormatConversionException(char c, System.Type arg)
		{
			this.c = c;
			if (arg == null)
			{
				throw new System.ArgumentNullException();
			}
			this.arg = arg;
		}

		/// <summary>Returns the class of the mismatched parameter.</summary>
		/// <remarks>Returns the class of the mismatched parameter.</remarks>
		/// <returns>the class of the mismatched parameter.</returns>
		public virtual System.Type getArgumentClass()
		{
			return arg;
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
				return "%" + c + " can't format " + arg.FullName + " arguments";
			}
		}
	}
}

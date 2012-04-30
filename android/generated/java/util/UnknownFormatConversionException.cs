using Sharpen;

namespace java.util
{
	/// <summary>
	/// An
	/// <code>UnknownFormatConversionException</code>
	/// will be thrown if the format
	/// conversion is unknown.
	/// </summary>
	/// <seealso cref="java.lang.RuntimeException">java.lang.RuntimeException</seealso>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class UnknownFormatConversionException : java.util.IllegalFormatException
	{
		internal const long serialVersionUID = 19060418L;

		private readonly string s;

		/// <summary>
		/// Constructs an
		/// <code>UnknownFormatConversionException</code>
		/// with the unknown
		/// format conversion.
		/// </summary>
		/// <param name="s">the unknown format conversion.</param>
		public UnknownFormatConversionException(string s)
		{
			if (s == null)
			{
				throw new System.ArgumentNullException();
			}
			this.s = s;
		}

		/// <summary>Returns the conversion associated with the exception.</summary>
		/// <remarks>Returns the conversion associated with the exception.</remarks>
		/// <returns>the conversion associated with the exception.</returns>
		public virtual string getConversion()
		{
			return s;
		}

		public override string Message
		{
			get
			{
				return "Conversion: " + s;
			}
		}
	}
}

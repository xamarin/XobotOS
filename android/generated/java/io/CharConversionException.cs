using Sharpen;

namespace java.io
{
	/// <summary>The top level class for character conversion exceptions.</summary>
	/// <remarks>The top level class for character conversion exceptions.</remarks>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class CharConversionException : System.IO.IOException
	{
		internal const long serialVersionUID = -8680016352018427031L;

		/// <summary>
		/// Constructs a new
		/// <code>CharConversionException</code>
		/// with its stack trace
		/// filled in.
		/// </summary>
		public CharConversionException()
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>CharConversionException</code>
		/// with its stack trace and
		/// detail message filled in.
		/// </summary>
		/// <param name="detailMessage">the detail message for this exception.</param>
		public CharConversionException(string detailMessage) : base(detailMessage)
		{
		}
	}
}

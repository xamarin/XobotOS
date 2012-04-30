using Sharpen;

namespace java.util
{
	/// <summary>
	/// FormattableFlags are used as a parameter to
	/// <see cref="Formattable.formatTo(Formatter, int, int, int)">Formattable.formatTo(Formatter, int, int, int)
	/// 	</see>
	/// and change the output
	/// format in
	/// <code>Formattable</code>
	/// s. The validation and interpretation of the
	/// flags must be done by the implementations.
	/// </summary>
	/// <seealso cref="Formattable">Formattable</seealso>
	[Sharpen.Sharpened]
	public class FormattableFlags
	{
		private FormattableFlags()
		{
		}

		/// <summary>Denotes the output is to be left-justified.</summary>
		/// <remarks>
		/// Denotes the output is to be left-justified. In order to fill the minimum
		/// width requirement, spaces('\u0020') will be appended at the end of the
		/// specified output element. If no such flag is set, the output is
		/// right-justified.
		/// The flag corresponds to '-' ('\u002d') in the format specifier.
		/// </remarks>
		public const int LEFT_JUSTIFY = 1;

		/// <summary>
		/// Denotes the output is to be converted to upper case in the way the locale
		/// parameter of Formatter.formatTo() requires.
		/// </summary>
		/// <remarks>
		/// Denotes the output is to be converted to upper case in the way the locale
		/// parameter of Formatter.formatTo() requires. The output has the same
		/// effect as
		/// <code>String.toUpperCase(java.util.Locale)</code>
		/// .
		/// This flag corresponds to
		/// <code>'^' ('\u005e')</code>
		/// in the format specifier.
		/// </remarks>
		public const int UPPERCASE = 2;

		/// <summary>Denotes the output is to be formatted in an alternate form.</summary>
		/// <remarks>
		/// Denotes the output is to be formatted in an alternate form. The definition
		/// of the alternate form is determined by the
		/// <code>Formattable</code>
		/// .
		/// This flag corresponds to
		/// <code>'#' ('\u0023')</code>
		/// in the format specifier.
		/// </remarks>
		public const int ALTERNATE = 4;
		//prevent this class from being instantiated
	}
}

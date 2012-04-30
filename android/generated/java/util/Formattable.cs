using Sharpen;

namespace java.util
{
	/// <summary>
	/// Classes that handle custom formatting for the 's' specifier of
	/// <code>Formatter</code>
	/// should implement the
	/// <code>Formattable</code>
	/// interface. It gives basic control over
	/// formatting objects.
	/// </summary>
	/// <seealso cref="Formatter">Formatter</seealso>
	[Sharpen.Sharpened]
	public interface Formattable
	{
		/// <summary>
		/// Formats the object using the specified
		/// <code>Formatter</code>
		/// .
		/// </summary>
		/// <param name="formatter">
		/// the
		/// <code>Formatter</code>
		/// to use.
		/// </param>
		/// <param name="flags">
		/// the flags applied to the output format, which is a bitmask
		/// that is any combination of
		/// <code>FormattableFlags.LEFT_JUSTIFY</code>
		/// ,
		/// <code>FormattableFlags.UPPERCASE</code>
		/// , and
		/// <code>FormattableFlags.ALTERNATE</code>
		/// . If
		/// no such flag is set, the output is formatted by the default
		/// formatting of the implementation.
		/// </param>
		/// <param name="width">
		/// the minimum number of characters that should be written to the
		/// output. If the length of the converted value is less than
		/// <code>width</code>
		/// Additional space characters (' ') are added to the output if the
		/// as needed to make up the difference. These spaces are added at the
		/// beginning by default unless the flag
		/// FormattableFlags.LEFT_JUSTIFY is set, which denotes that
		/// padding should be added at the end. If width is -1, then
		/// minimum length is not enforced.
		/// </param>
		/// <param name="precision">
		/// the maximum number of characters that can be written to the
		/// output. The length of the output is trimmed down to this size
		/// before the width padding is applied. If the precision
		/// is -1, then maximum length is not enforced.
		/// </param>
		/// <exception cref="IllegalFormatException">if any of the parameters is not supported.
		/// 	</exception>
		/// <exception cref="java.util.IllegalFormatException"></exception>
		void formatTo(java.util.Formatter formatter, int flags, int width, int precision);
	}
}

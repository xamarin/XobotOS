using Sharpen;

namespace java.util
{
	/// <summary>
	/// Formats arguments according to a format string (like
	/// <code>printf</code>
	/// in C).
	/// <p>
	/// It's relatively rare to use a
	/// <code>Formatter</code>
	/// directly. A variety of classes offer convenience
	/// methods for accessing formatter functionality.
	/// Of these,
	/// <see cref="string.Format(string, object[])">string.Format(string, object[])</see>
	/// is generally the most useful.
	/// <see cref="java.io.PrintStream">java.io.PrintStream</see>
	/// and
	/// <see cref="java.io.PrintWriter">java.io.PrintWriter</see>
	/// both offer
	/// <code>format</code>
	/// and
	/// <code>printf</code>
	/// methods.
	/// <p>
	/// <i>Format strings</i> consist of plain text interspersed with format specifiers, such
	/// as
	/// <code>"name: %s weight: %03dkg\n"</code>
	/// . Being a Java string, the usual Java string literal
	/// backslash escapes are of course available.
	/// <p>
	/// <i>Format specifiers</i> (such as
	/// <code>"%s"</code>
	/// or
	/// <code>"%03d"</code>
	/// in the example) start with a
	/// <code>%</code>
	/// and describe how to format their corresponding argument. It includes an optional
	/// argument index, optional flags, an optional width, an optional precision, and a mandatory
	/// conversion type.
	/// In the example,
	/// <code>"%s"</code>
	/// has no flags, no width, and no precision, while
	/// <code>"%03d"</code>
	/// has the flag
	/// <code>0</code>
	/// , the width 3, and no precision.
	/// <p>
	/// Not all combinations of argument index, flags, width, precision, and conversion type
	/// are valid.
	/// <p>
	/// <i>Argument index</i>. Normally, each format specifier consumes the next argument to
	/// <code>format</code>
	/// .
	/// For convenient localization, it's possible to reorder arguments so that they appear in a
	/// different order in the output than the order in which they were supplied.
	/// For example,
	/// <code>"%4$s"</code>
	/// formats the fourth argument (
	/// <code>4$</code>
	/// ) as a string (
	/// <code>s</code>
	/// ).
	/// It's also possible to reuse an argument with
	/// <code>&lt;</code>
	/// . For example,
	/// <code>format("%o %&lt;d %&lt;x", 64)</code>
	/// results in
	/// <code>"100 64 40"</code>
	/// .
	/// <p>
	/// <i>Flags</i>. The available flags are:
	/// <p>
	/// <table BORDER="1" WIDTH="100%" CELLPADDING="3" CELLSPACING="0" SUMMARY="">
	/// <tr BGCOLOR="#CCCCFF" CLASS="TableHeadingColor"> <TD COLSPAN=4> <B>Flags</B> </TD> </tr>
	/// <tr>
	/// <td width="5%">
	/// <code>,</code>
	/// </td>
	/// <td width="25%">Use grouping separators for large numbers. (Decimal only.)</td>
	/// <td width="30%">
	/// <code>format("%,d", 1024);</code>
	/// </td>
	/// <td width="30%">
	/// <code>1,234</code>
	/// </td>
	/// </tr>
	/// <tr>
	/// <td width="5%">
	/// <code>+</code>
	/// </td>
	/// <td width="25%">Always show sign. (Decimal only.)</td>
	/// <td width="30%">
	/// <code>format("%+d, %+4d", 5, 5);</code>
	/// </td>
	/// <td width="30%"><pre>+5,   +5</pre></td>
	/// </tr>
	/// <tr>
	/// <td width="5%">
	/// <code></code>
	/// </td>
	/// <td width="25%">A space indicates that non-negative numbers
	/// should have a leading space. (Decimal only.)</td>
	/// <td width="30%">
	/// <code>format("x% d% 5d", 4, 4);</code>
	/// </td>
	/// <td width="30%"><pre>x 4    4</pre></td>
	/// </tr>
	/// <tr>
	/// <td width="5%">
	/// <code>(</code>
	/// </td>
	/// <td width="25%">Put parentheses around negative numbers. (Decimal only.)</td>
	/// <td width="30%">
	/// <code>format("%(d, %(d, %(6d", 12, -12, -12);</code>
	/// </td>
	/// <td width="30%"><pre>12, (12),   (12)</pre></td>
	/// </tr>
	/// <tr>
	/// <td width="5%">
	/// <code>-</code>
	/// </td>
	/// <td width="25%">Left-justify. (Requires width.)</td>
	/// <td width="30%">
	/// <code>format("%-6dx", 5);</code>
	/// <br/>
	/// <code>format("%-3C, %3C", 'd', 0x65);</code>
	/// </td>
	/// <td width="30%"><pre>5      x</pre><br/><pre>D  ,   E</pre></td>
	/// </tr>
	/// <tr>
	/// <td width="5%">
	/// <code>0</code>
	/// </td>
	/// <td width="25%">Pad the number with leading zeros. (Requires width.)</td>
	/// <td width="30%">
	/// <code>format("%07d, %03d", 4, 5555);</code>
	/// </td>
	/// <td width="30%">
	/// <code>0000004, 5555</code>
	/// </td>
	/// </tr>
	/// <tr>
	/// <td width="5%">
	/// <code>#</code>
	/// </td>
	/// <td width="25%">Alternate form. (Octal and hex only.) </td>
	/// <td width="30%">
	/// <code>format("%o %#o", 010, 010);</code>
	/// <br/>
	/// <code>format("%x %#x", 0x12, 0x12);</code>
	/// </td>
	/// <td width="30%">
	/// <code>10 010</code>
	/// <br/>
	/// <code>12 0x12</code>
	/// </td>
	/// </tr>
	/// </table>
	/// <p>
	/// <i>Width</i>. The width is a decimal integer specifying the minimum number of characters to be
	/// used to represent the argument. If the result would otherwise be shorter than the width, padding
	/// will be added (the exact details of which depend on the flags). Note that you can't use width to
	/// truncate a field, only to make it wider: see precision for control over the maximum width.
	/// <p>
	/// <i>Precision</i>. The precision is a
	/// <code>.</code>
	/// followed by a decimal integer, giving the minimum
	/// number of digits for
	/// <code>d</code>
	/// ,
	/// <code>o</code>
	/// ,
	/// <code>x</code>
	/// , or
	/// <code>X</code>
	/// ; the minimum number of digits
	/// after the decimal point for
	/// <code>a</code>
	/// ,
	/// <code>A</code>
	/// ,
	/// <code>e</code>
	/// ,
	/// <code>E</code>
	/// ,
	/// <code>f</code>
	/// , or
	/// <code>F</code>
	/// ;
	/// the maximum number of significant digits for
	/// <code>g</code>
	/// or
	/// <code>G</code>
	/// ; or the maximum number of
	/// characters for
	/// <code>s</code>
	/// or
	/// <code>S</code>
	/// .
	/// <p>
	/// <i>Conversion type</i>. One or two characters describing how to interpret the argument. Most
	/// conversions are a single character, but date/time conversions all start with
	/// <code>t</code>
	/// and
	/// have a single extra character describing the desired output.
	/// <p>
	/// Many conversion types have a corresponding uppercase variant that converts its result to
	/// uppercase using the rules of the relevant locale (either the default or the locale set for
	/// this formatter).
	/// <p>
	/// This table shows the available single-character (non-date/time) conversion types:
	/// <table BORDER="1" WIDTH="100%" CELLPADDING="3" CELLSPACING="0" SUMMARY="">
	/// <tr BGCOLOR="#CCCCFF" CLASS="TableHeadingColor">
	/// <TD COLSPAN=4>
	/// <B>String conversions</B>
	/// <br />
	/// All types are acceptable arguments. Values of type
	/// <see cref="Formattable">Formattable</see>
	/// have their
	/// <code>formatTo</code>
	/// method invoked; all other types use
	/// <code>toString</code>
	/// .
	/// </TD>
	/// </tr>
	/// <tr>
	/// <td width="5%">
	/// <code>s</code>
	/// </td>
	/// <td width="25%">String.</td>
	/// <td width="30%">
	/// <code>format("%s %s", "hello", "Hello");</code>
	/// </td>
	/// <td width="30%">
	/// <code>hello Hello</code>
	/// </td>
	/// </tr>
	/// <tr>
	/// <td width="5%">
	/// <code>S</code>
	/// </td>
	/// <td width="25%">Uppercase string.</td>
	/// <td width="30%">
	/// <code>format("%S %S", "hello", "Hello");</code>
	/// </td>
	/// <td width="30%">
	/// <code>HELLO HELLO</code>
	/// </td>
	/// </tr>
	/// <tr BGCOLOR="#CCCCFF" CLASS="TableHeadingColor">
	/// <TD COLSPAN=4>
	/// <B>Character conversions</B>
	/// <br />
	/// Byte, Character, Short, and Integer (and primitives that box to those types) are all acceptable
	/// as character arguments. Any other type is an error.
	/// </TD>
	/// </tr>
	/// <tr>
	/// <td width="5%">
	/// <code>c</code>
	/// </td>
	/// <td width="25%">Character.</td>
	/// <td width="30%">
	/// <code>format("%c %c", 'd', 'E');</code>
	/// </td>
	/// <td width="30%">
	/// <code>d E</code>
	/// </td>
	/// </tr>
	/// <tr>
	/// <td width="5%">
	/// <code>C</code>
	/// </td>
	/// <td width="25%">Uppercase character.</td>
	/// <td width="30%">
	/// <code>format("%C %C", 'd', 'E');</code>
	/// </td>
	/// <td width="30%">
	/// <code>D E</code>
	/// </td>
	/// </tr>
	/// <tr BGCOLOR="#CCCCFF" CLASS="TableHeadingColor">
	/// <TD COLSPAN=4>
	/// <B>Integer conversions</B>
	/// <br />
	/// Byte, Short, Integer, Long, and BigInteger (and primitives that box to those types) are all
	/// acceptable as integer arguments. Any other type is an error.
	/// </TD>
	/// </tr>
	/// <tr>
	/// <td width="5%">
	/// <code>d</code>
	/// </td>
	/// <td width="25%">Decimal.</td>
	/// <td width="30%">
	/// <code>format("%d", 26);</code>
	/// </td>
	/// <td width="30%">
	/// <code>26</code>
	/// </td>
	/// </tr>
	/// <tr>
	/// <td width="5%">
	/// <code>o</code>
	/// </td>
	/// <td width="25%">Octal.</td>
	/// <td width="30%">
	/// <code>format("%o", 032);</code>
	/// </td>
	/// <td width="30%">
	/// <code>32</code>
	/// </td>
	/// </tr>
	/// <tr>
	/// <td width="5%">
	/// <code>x</code>
	/// ,
	/// <code>X</code>
	/// </td>
	/// <td width="25%">Hexadecimal.</td>
	/// <td width="30%">
	/// <code>format("%x %X", 0x1a, 0x1a);</code>
	/// </td>
	/// <td width="30%">
	/// <code>1a 1A</code>
	/// </td>
	/// </tr>
	/// <tr BGCOLOR="#CCCCFF" CLASS="TableHeadingColor">
	/// <TD COLSPAN=4><B>Floating-point conversions</B>
	/// <br />
	/// Float, Double, and BigDecimal (and primitives that box to those types) are all acceptable as
	/// floating-point arguments. Any other type is an error.
	/// </TD>
	/// </tr>
	/// <tr>
	/// <td width="5%">
	/// <code>f</code>
	/// </td>
	/// <td width="25%">Decimal floating point.</td>
	/// <td width="30%"><pre>
	/// format("%f", 123.456f);
	/// format("%.1f", 123.456f);
	/// format("%1.5f", 123.456f);
	/// format("%10f", 123.456f);
	/// format("%6.0f", 123.456f);</td>
	/// <td width="30%" valign="top"><pre>
	/// 123.456001
	/// 123.5
	/// 123.45600
	/// 123.456001
	/// &nbsp;&nbsp;&nbsp;123</pre></td>
	/// </tr>
	/// <tr>
	/// <td width="5%">
	/// <code>e</code>
	/// ,
	/// <code>E</code>
	/// </td>
	/// <td width="25%">Engineering/exponential floating point.</td>
	/// <td width="30%"><pre>
	/// format("%e", 123.456f);
	/// format("%.1e", 123.456f);
	/// format("%1.5E", 123.456f);
	/// format("%10E", 123.456f);
	/// format("%6.0E", 123.456f);</td>
	/// <td width="30%" valign="top"><pre>
	/// 1.234560e+02
	/// 1.2e+02
	/// 1.23456E+02
	/// 1.234560E+02
	/// &nbsp;1E+02</pre></td>
	/// </tr>
	/// <tr>
	/// <td width="5%" valign="top">
	/// <code>g</code>
	/// ,
	/// <code>G</code>
	/// </td>
	/// <td width="25%" valign="top">Decimal or engineering, depending on the magnitude of the value.</td>
	/// <td width="30%" valign="top">
	/// <code>format("%g %g", 0.123, 0.0000123);</code>
	/// </td>
	/// <td width="30%" valign="top">
	/// <code>0.123000 1.23000e-05</code>
	/// </td>
	/// </tr>
	/// <tr>
	/// <td width="5%">
	/// <code>a</code>
	/// ,
	/// <code>A</code>
	/// </td>
	/// <td width="25%">Hexadecimal floating point.</td>
	/// <td width="30%">
	/// <code>format("%a", 123.456f);</code>
	/// </td>
	/// <td width="30%">
	/// <code>0x1.edd2f2p6</code>
	/// </td>
	/// </tr>
	/// <tr BGCOLOR="#CCCCFF" CLASS="TableHeadingColor">
	/// <TD COLSPAN=4>
	/// <B>Boolean conversion</B>
	/// <br />
	/// Accepts Boolean values.
	/// <code>null</code>
	/// is considered false, and instances of all other
	/// types are considered true.
	/// </TD>
	/// </tr>
	/// <tr>
	/// <td width="5%">
	/// <code>b</code>
	/// ,
	/// <code>B</code>
	/// </td>
	/// <td width="25%">Boolean.</td>
	/// <td width="30%">
	/// <code>format("%b %b", true, false);</code>
	/// <br />
	/// <code>format("%B %B", true, false);</code>
	/// <br />
	/// <code>format("%b", null);</code>
	/// <br />
	/// <code>format("%b", "hello");</code>
	/// </td>
	/// <td width="30%">
	/// <code>true false</code>
	/// <br />
	/// <code>TRUE FALSE</code>
	/// <br />
	/// <code>false</code>
	/// <br />
	/// <code>true</code>
	/// </td>
	/// </tr>
	/// <tr BGCOLOR="#CCCCFF" CLASS="TableHeadingColor">
	/// <TD COLSPAN=4>
	/// <B>Hash code conversion</B>
	/// <br />
	/// Invokes
	/// <code>hashCode</code>
	/// on its argument, which may be of any type.
	/// </TD>
	/// </tr>
	/// <tr>
	/// <td width="5%">
	/// <code>h</code>
	/// ,
	/// <code>H</code>
	/// </td>
	/// <td width="25%">Hexadecimal hash code.</td>
	/// <td width="30%">
	/// <code>format("%h", this);</code>
	/// <br />
	/// <code>format("%H", this);</code>
	/// <br />
	/// <code>format("%h", null);</code>
	/// </td>
	/// <td width="30%">
	/// <code>190d11</code>
	/// <br />
	/// <code>190D11</code>
	/// <br />
	/// <code>null</code>
	/// </td>
	/// </tr>
	/// <tr BGCOLOR="#CCCCFF" CLASS="TableHeadingColor">
	/// <TD COLSPAN=4>
	/// <B>Zero-argument conversions</B></TD>
	/// </tr>
	/// <tr>
	/// <td width="5%">
	/// <code>%</code>
	/// </td>
	/// <td width="25%">A literal % character.</td>
	/// <td width="30%">
	/// <code>format("%d%%", 50);</code>
	/// </td>
	/// <td width="30%">
	/// <code>50%</code>
	/// </td>
	/// </tr>
	/// <tr>
	/// <td width="5%">
	/// <code>n</code>
	/// </td>
	/// <td width="25%">Newline. (The value of the "line.separator" system property}.)</td>
	/// <td width="30%">
	/// <code>format("first%nsecond");</code>
	/// </td>
	/// <td width="30%">
	/// <code>first\nsecond</code>
	/// </td>
	/// </tr>
	/// </table>
	/// <p>
	/// It's also possible to format dates and times with
	/// <code>Formatter</code>
	/// , though you should seriously
	/// consider using
	/// <see cref="java.text.SimpleDateFormat">java.text.SimpleDateFormat</see>
	/// via the factory methods in
	/// <see cref="java.text.DateFormat">java.text.DateFormat</see>
	/// instead.
	/// The facilities offered by
	/// <code>Formatter</code>
	/// are low-level and place the burden of localization
	/// on the developer. Using
	/// <see cref="java.text.DateFormat.getDateInstance()">java.text.DateFormat.getDateInstance()
	/// 	</see>
	/// ,
	/// <see cref="java.text.DateFormat.getTimeInstance()">java.text.DateFormat.getTimeInstance()
	/// 	</see>
	/// , and
	/// <see cref="java.text.DateFormat.getDateTimeInstance()">java.text.DateFormat.getDateTimeInstance()
	/// 	</see>
	/// is preferable for dates and times that will be
	/// presented to a human. Those methods will select the best format strings for the user's locale.
	/// <p>
	/// The best non-localized form is <a href="http://en.wikipedia.org/wiki/ISO_8601">ISO 8601</a>,
	/// which you can get with
	/// <code>"%tF"</code>
	/// (2010-01-22),
	/// <code>"%tF %tR"</code>
	/// (2010-01-22 13:39),
	/// <code>"%tF %tT"</code>
	/// (2010-01-22 13:39:15), or
	/// <code>"%tF %tT%z"</code>
	/// (2010-01-22 13:39:15-0800).
	/// <p>
	/// As with the other conversions, date/time conversion has an uppercase format. Replacing
	/// <code>%t</code>
	/// with
	/// <code>%T</code>
	/// will uppercase the field according to the rules of the formatter's
	/// locale.
	/// <p>
	/// This table shows the date/time conversions:
	/// <table BORDER="1" WIDTH="100%" CELLPADDING="3" CELLSPACING="0" SUMMARY="">
	/// <tr BGCOLOR="#CCCCFF" CLASS="TableHeadingColor">
	/// <TD COLSPAN=4><B>Date/time conversions</B>
	/// <br />
	/// Calendar, Date, and Long (representing milliseconds past the epoch) are all acceptable
	/// as date/time arguments. Any other type is an error. The epoch is 1970-01-01 00:00:00 UTC.
	/// </TD>
	/// </tr>
	/// <tr>
	/// <td width="5%">
	/// <code>ta</code>
	/// </td>
	/// <td width="25%">Localized weekday name (abbreviated).</td>
	/// <td width="30%">
	/// <code>format("%ta", cal, cal);</code>
	/// </td>
	/// <td width="30%">
	/// <code>Tue</code>
	/// </td>
	/// </tr>
	/// <tr>
	/// <td width="5%">
	/// <code>tA</code>
	/// </td>
	/// <td width="25%">Localized weekday name (full).</td>
	/// <td width="30%">
	/// <code>format("%tA", cal, cal);</code>
	/// </td>
	/// <td width="30%">
	/// <code>Tuesday</code>
	/// </td>
	/// </tr>
	/// <tr>
	/// <td width="5%">
	/// <code>tb</code>
	/// </td>
	/// <td width="25%">Localized month name (abbreviated).</td>
	/// <td width="30%">
	/// <code>format("%tb", cal);</code>
	/// </td>
	/// <td width="30%">
	/// <code>Apr</code>
	/// </td>
	/// </tr>
	/// <tr>
	/// <td width="5%">
	/// <code>tB</code>
	/// </td>
	/// <td width="25%">Localized month name (full).</td>
	/// <td width="30%">
	/// <code>format("%tB", cal);</code>
	/// </td>
	/// <td width="30%">
	/// <code>April</code>
	/// </td>
	/// </tr>
	/// <tr>
	/// <td width="5%">
	/// <code>tc</code>
	/// </td>
	/// <td width="25%">Locale-preferred date and time representation. (See
	/// <see cref="java.text.DateFormat">java.text.DateFormat</see>
	/// for more variations.)</td>
	/// <td width="30%">
	/// <code>format("%tc", cal);</code>
	/// </td>
	/// <td width="30%">
	/// <code>Tue Apr 01 16:19:17 CEST 2008</code>
	/// </td>
	/// </tr>
	/// <tr>
	/// <td width="5%">
	/// <code>tC</code>
	/// </td>
	/// <td width="25%">2-digit century.</td>
	/// <td width="30%">
	/// <code>format("%tC", cal);</code>
	/// </td>
	/// <td width="30%">
	/// <code>20</code>
	/// </td>
	/// </tr>
	/// <tr>
	/// <td width="5%">
	/// <code>td</code>
	/// </td>
	/// <td width="25%">2-digit day of month (01-31).</td>
	/// <td width="30%">
	/// <code>format("%td", cal);</code>
	/// </td>
	/// <td width="30%">
	/// <code>01</code>
	/// </td>
	/// </tr>
	/// <tr>
	/// <td width="5%">
	/// <code>tD</code>
	/// </td>
	/// <td width="25%">Ambiguous US date format (MM/DD/YY). Do not use.</td>
	/// <td width="30%">
	/// <code>format("%tD", cal);</code>
	/// </td>
	/// <td width="30%">
	/// <code>04/01/08</code>
	/// </td>
	/// </tr>
	/// <tr>
	/// <td width="5%">
	/// <code>te</code>
	/// </td>
	/// <td width="25%">Day of month (1-31).</td>
	/// <td width="30%">
	/// <code>format("%te", cal);</code>
	/// </td>
	/// <td width="30%">
	/// <code>1</code>
	/// </td>
	/// </tr>
	/// <tr>
	/// <td width="5%">
	/// <code>tF</code>
	/// </td>
	/// <td width="25%">Full date in ISO 8601 format (YYYY-MM-DD).</td>
	/// <td width="30%">
	/// <code>format("%tF", cal);</code>
	/// </td>
	/// <td width="30%">
	/// <code>2008-04-01</code>
	/// </td>
	/// </tr>
	/// <tr>
	/// <td width="5%">
	/// <code>th</code>
	/// </td>
	/// <td width="25%">Synonym for
	/// <code>%tb</code>
	/// .</td>
	/// <td width="30%"></td>
	/// <td width="30%"></td>
	/// </tr>
	/// <tr>
	/// <td width="5%">
	/// <code>tH</code>
	/// </td>
	/// <td width="25%">24-hour hour of day (00-23).</td>
	/// <td width="30%">
	/// <code>format("%tH", cal);</code>
	/// </td>
	/// <td width="30%">
	/// <code>16</code>
	/// </td>
	/// </tr>
	/// <tr>
	/// <td width="5%">
	/// <code>tI</code>
	/// </td>
	/// <td width="25%">12-hour hour of day (01-12).</td>
	/// <td width="30%">
	/// <code>format("%tH", cal);</code>
	/// </td>
	/// <td width="30%">
	/// <code>04</code>
	/// </td>
	/// </tr>
	/// <tr>
	/// <td width="5%">
	/// <code>tj</code>
	/// </td>
	/// <td width="25%">3-digit day of year (001-366).</td>
	/// <td width="30%">
	/// <code>format("%tj", cal);</code>
	/// </td>
	/// <td width="30%">
	/// <code>092</code>
	/// </td>
	/// </tr>
	/// <tr>
	/// <td width="5%">
	/// <code>tk</code>
	/// </td>
	/// <td width="25%">24-hour hour of day (0-23).</td>
	/// <td width="30%">
	/// <code>format("%tH", cal);</code>
	/// </td>
	/// <td width="30%">
	/// <code>16</code>
	/// </td>
	/// </tr>
	/// <tr>
	/// <td width="5%">
	/// <code>tl</code>
	/// </td>
	/// <td width="25%">12-hour hour of day (1-12).</td>
	/// <td width="30%">
	/// <code>format("%tH", cal);</code>
	/// </td>
	/// <td width="30%">
	/// <code>4</code>
	/// </td>
	/// </tr>
	/// <tr>
	/// <td width="5%">
	/// <code>tL</code>
	/// </td>
	/// <td width="25%">Milliseconds.</td>
	/// <td width="30%">
	/// <code>format("%tL", cal);</code>
	/// </td>
	/// <td width="30%">
	/// <code>359</code>
	/// </td>
	/// </tr>
	/// <tr>
	/// <td width="5%">
	/// <code>tm</code>
	/// </td>
	/// <td width="25%">2-digit month of year (01-12).</td>
	/// <td width="30%">
	/// <code>format("%tm", cal);</code>
	/// </td>
	/// <td width="30%">
	/// <code>04</code>
	/// </td>
	/// </tr>
	/// <tr>
	/// <td width="5%">
	/// <code>tM</code>
	/// </td>
	/// <td width="25%">2-digit minute.</td>
	/// <td width="30%">
	/// <code>format("%tM", cal);</code>
	/// </td>
	/// <td width="30%">
	/// <code>08</code>
	/// </td>
	/// </tr>
	/// <tr>
	/// <td width="5%">
	/// <code>tN</code>
	/// </td>
	/// <td width="25%">Nanoseconds.</td>
	/// <td width="30%">
	/// <code>format("%tN", cal);</code>
	/// </td>
	/// <td width="30%">
	/// <code>359000000</code>
	/// </td>
	/// </tr>
	/// <tr>
	/// <td width="5%">
	/// <code>tp</code>
	/// </td>
	/// <td width="25%">a.m. or p.m.</td>
	/// <td width="30%">
	/// <code>format("%tp %Tp", cal, cal);</code>
	/// </td>
	/// <td width="30%">
	/// <code>pm PM</code>
	/// </td>
	/// </tr>
	/// <tr>
	/// <td width="5%">
	/// <code>tQ</code>
	/// </td>
	/// <td width="25%">Milliseconds since the epoch.</td>
	/// <td width="30%">
	/// <code>format("%tQ", cal);</code>
	/// </td>
	/// <td width="30%">
	/// <code>1207059412656</code>
	/// </td>
	/// </tr>
	/// <tr>
	/// <td width="5%">
	/// <code>tr</code>
	/// </td>
	/// <td width="25%">Full 12-hour time (
	/// <code>%tI:%tM:%tS %Tp</code>
	/// ).</td>
	/// <td width="30%">
	/// <code>format("%tr", cal);</code>
	/// </td>
	/// <td width="30%">
	/// <code>04:15:32 PM</code>
	/// </td>
	/// </tr>
	/// <tr>
	/// <td width="5%">
	/// <code>tR</code>
	/// </td>
	/// <td width="25%">Short 24-hour time (
	/// <code>%tH:%tM</code>
	/// ).</td>
	/// <td width="30%">
	/// <code>format("%tR", cal);</code>
	/// </td>
	/// <td width="30%">
	/// <code>16:15</code>
	/// </td>
	/// </tr>
	/// <tr>
	/// <td width="5%">
	/// <code>ts</code>
	/// </td>
	/// <td width="25%">Seconds since the epoch.</td>
	/// <td width="30%">
	/// <code>format("%ts", cal);</code>
	/// </td>
	/// <td width="30%">
	/// <code>1207059412</code>
	/// </td>
	/// </tr>
	/// <tr>
	/// <td width="5%">
	/// <code>tS</code>
	/// </td>
	/// <td width="25%">2-digit seconds (00-60).</td>
	/// <td width="30%">
	/// <code>format("%tS", cal);</code>
	/// </td>
	/// <td width="30%">
	/// <code>17</code>
	/// </td>
	/// </tr>
	/// <tr>
	/// <td width="5%">
	/// <code>tT</code>
	/// </td>
	/// <td width="25%">Full 24-hour time (
	/// <code>%tH:%tM:%tS</code>
	/// ).</td>
	/// <td width="30%">
	/// <code>format("%tT", cal);</code>
	/// </td>
	/// <td width="30%">
	/// <code>16:15:32</code>
	/// </td>
	/// </tr>
	/// <tr>
	/// <td width="5%">
	/// <code>ty</code>
	/// </td>
	/// <td width="25%">2-digit year (00-99).</td>
	/// <td width="30%">
	/// <code>format("%ty", cal);</code>
	/// </td>
	/// <td width="30%">
	/// <code>08</code>
	/// </td>
	/// </tr>
	/// <tr>
	/// <td width="5%">
	/// <code>tY</code>
	/// </td>
	/// <td width="25%">4-digit year.</td>
	/// <td width="30%">
	/// <code>format("%tY", cal);</code>
	/// </td>
	/// <td width="30%">
	/// <code>2008</code>
	/// </td>
	/// </tr>
	/// <tr>
	/// <td width="5%">
	/// <code>tz</code>
	/// </td>
	/// <td width="25%">Time zone GMT offset.</td>
	/// <td width="30%">
	/// <code>format("%tz", cal);</code>
	/// </td>
	/// <td width="30%">
	/// <code>+0100</code>
	/// </td>
	/// </tr>
	/// <tr>
	/// <td width="5%">
	/// <code>tZ</code>
	/// </td>
	/// <td width="25%">Localized time zone abbreviation.</td>
	/// <td width="30%">
	/// <code>format("%tZ", cal);</code>
	/// </td>
	/// <td width="30%">
	/// <code>CEST</code>
	/// </td>
	/// </tr>
	/// </table>
	/// <p><i>Number localization</i>. Some conversions use localized decimal digits rather than the
	/// usual ASCII digits. So formatting
	/// <code>123</code>
	/// with
	/// <code>%d</code>
	/// will give 123 in English locales
	/// but &#x0661;&#x0662;&#x0663; in appropriate Arabic locales, for example. This number localization
	/// occurs for the decimal integer conversion
	/// <code>%d</code>
	/// , the floating point conversions
	/// <code>%e</code>
	/// ,
	/// <code>%f</code>
	/// , and
	/// <code>%g</code>
	/// , and all date/time
	/// <code>%t</code>
	/// or
	/// <code>%T</code>
	/// conversions, but no other
	/// conversions.
	/// <p><i>Thread safety</i>. Formatter is not thread-safe.
	/// </summary>
	/// <since>1.5</since>
	/// <seealso cref="java.text.DateFormat">java.text.DateFormat</seealso>
	/// <seealso cref="Formattable">Formattable</seealso>
	/// <seealso cref="java.text.SimpleDateFormat">java.text.SimpleDateFormat</seealso>
	[Sharpen.Sharpened]
	public sealed partial class Formatter : java.io.Closeable, java.io.Flushable
	{
		private static readonly char[] ZEROS = new char[] { '0', '0', '0', '0', '0', '0', 
			'0', '0', '0' };

		/// <summary>
		/// The enumeration giving the available styles for formatting very large
		/// decimal numbers.
		/// </summary>
		/// <remarks>
		/// The enumeration giving the available styles for formatting very large
		/// decimal numbers.
		/// </remarks>
		public enum BigDecimalLayoutForm
		{
			/// <summary>Use scientific style for BigDecimals.</summary>
			/// <remarks>Use scientific style for BigDecimals.</remarks>
			SCIENTIFIC,
			/// <summary>Use normal decimal/float style for BigDecimals.</summary>
			/// <remarks>Use normal decimal/float style for BigDecimals.</remarks>
			DECIMAL_FLOAT
		}

		private java.lang.Appendable _out;

		private System.Globalization.CultureInfo _locale;

		private object arg;

		private bool closed = false;

		private java.util.Formatter.FormatToken formatToken;

		private System.IO.IOException lastIOException;

		private Sharpen.Util.LocaleData localeData;

		/// <summary>
		/// Constructs a
		/// <code>Formatter</code>
		/// .
		/// <p>The output is written to a
		/// <code>StringBuilder</code>
		/// which can be acquired by invoking
		/// <see cref="@out()">@out()</see>
		/// and whose content can be obtained by calling
		/// <code>toString</code>
		/// .
		/// <p>The
		/// <code>Locale</code>
		/// used is the user's default locale.
		/// See "<a href="../util/Locale.html#default_locale">Be wary of the default locale</a>".
		/// </summary>
		public Formatter() : this(new java.lang.StringBuilder(), System.Globalization.CultureInfo.CurrentCulture
			)
		{
		}

		/// <summary>
		/// Constructs a
		/// <code>Formatter</code>
		/// whose output will be written to the
		/// specified
		/// <code>Appendable</code>
		/// .
		/// <p>The
		/// <code>Locale</code>
		/// used is the user's default locale.
		/// See "<a href="../util/Locale.html#default_locale">Be wary of the default locale</a>".
		/// </summary>
		/// <param name="a">
		/// the output destination of the
		/// <code>Formatter</code>
		/// . If
		/// <code>a</code>
		/// is
		/// <code>null</code>
		/// ,
		/// then a
		/// <code>StringBuilder</code>
		/// will be used.
		/// </param>
		public Formatter(java.lang.Appendable a) : this(a, System.Globalization.CultureInfo.CurrentCulture
			)
		{
		}

		/// <summary>
		/// Constructs a
		/// <code>Formatter</code>
		/// with the specified
		/// <code>Locale</code>
		/// .
		/// <p>The output is written to a
		/// <code>StringBuilder</code>
		/// which can be acquired by invoking
		/// <see cref="@out()">@out()</see>
		/// and whose content can be obtained by calling
		/// <code>toString</code>
		/// .
		/// </summary>
		/// <param name="l">
		/// the
		/// <code>Locale</code>
		/// of the
		/// <code>Formatter</code>
		/// . If
		/// <code>l</code>
		/// is
		/// <code>null</code>
		/// ,
		/// then no localization will be used.
		/// </param>
		public Formatter(System.Globalization.CultureInfo l) : this(new java.lang.StringBuilder
			(), l)
		{
		}

		/// <summary>
		/// Constructs a
		/// <code>Formatter</code>
		/// with the specified
		/// <code>Locale</code>
		/// and whose output will be written to the
		/// specified
		/// <code>Appendable</code>
		/// .
		/// </summary>
		/// <param name="a">
		/// the output destination of the
		/// <code>Formatter</code>
		/// . If
		/// <code>a</code>
		/// is
		/// <code>null</code>
		/// ,
		/// then a
		/// <code>StringBuilder</code>
		/// will be used.
		/// </param>
		/// <param name="l">
		/// the
		/// <code>Locale</code>
		/// of the
		/// <code>Formatter</code>
		/// . If
		/// <code>l</code>
		/// is
		/// <code>null</code>
		/// ,
		/// then no localization will be used.
		/// </param>
		public Formatter(java.lang.Appendable a, System.Globalization.CultureInfo l)
		{
			// User-settable parameters.
			// Implementation details.
			if (a == null)
			{
				_out = new java.lang.StringBuilder();
			}
			else
			{
				_out = a;
			}
			_locale = l;
		}

		/// <summary>
		/// Constructs a
		/// <code>Formatter</code>
		/// whose output is written to the specified file.
		/// <p>The charset of the
		/// <code>Formatter</code>
		/// is the default charset.
		/// <p>The
		/// <code>Locale</code>
		/// used is the user's default locale.
		/// See "<a href="../util/Locale.html#default_locale">Be wary of the default locale</a>".
		/// </summary>
		/// <param name="fileName">
		/// the filename of the file that is used as the output
		/// destination for the
		/// <code>Formatter</code>
		/// . The file will be truncated to
		/// zero size if the file exists, or else a new file will be
		/// created. The output of the
		/// <code>Formatter</code>
		/// is buffered.
		/// </param>
		/// <exception cref="java.io.FileNotFoundException">
		/// if the filename does not denote a normal and writable file,
		/// or if a new file cannot be created, or if any error arises when
		/// opening or creating the file.
		/// </exception>
		public Formatter(string fileName) : this(new java.io.File(fileName))
		{
		}

		/// <summary>
		/// Constructs a
		/// <code>Formatter</code>
		/// whose output is written to the specified file.
		/// <p>The
		/// <code>Locale</code>
		/// used is the user's default locale.
		/// See "<a href="../util/Locale.html#default_locale">Be wary of the default locale</a>".
		/// </summary>
		/// <param name="fileName">
		/// the filename of the file that is used as the output
		/// destination for the
		/// <code>Formatter</code>
		/// . The file will be truncated to
		/// zero size if the file exists, or else a new file will be
		/// created. The output of the
		/// <code>Formatter</code>
		/// is buffered.
		/// </param>
		/// <param name="csn">
		/// the name of the charset for the
		/// <code>Formatter</code>
		/// .
		/// </param>
		/// <exception cref="java.io.FileNotFoundException">
		/// if the filename does not denote a normal and writable file,
		/// or if a new file cannot be created, or if any error arises when
		/// opening or creating the file.
		/// </exception>
		/// <exception cref="java.io.UnsupportedEncodingException">if the charset with the specified name is not supported.
		/// 	</exception>
		public Formatter(string fileName, string csn) : this(new java.io.File(fileName), 
			csn)
		{
		}

		/// <summary>
		/// Constructs a
		/// <code>Formatter</code>
		/// with the given
		/// <code>Locale</code>
		/// and charset,
		/// and whose output is written to the specified file.
		/// </summary>
		/// <param name="fileName">
		/// the filename of the file that is used as the output
		/// destination for the
		/// <code>Formatter</code>
		/// . The file will be truncated to
		/// zero size if the file exists, or else a new file will be
		/// created. The output of the
		/// <code>Formatter</code>
		/// is buffered.
		/// </param>
		/// <param name="csn">
		/// the name of the charset for the
		/// <code>Formatter</code>
		/// .
		/// </param>
		/// <param name="l">
		/// the
		/// <code>Locale</code>
		/// of the
		/// <code>Formatter</code>
		/// . If
		/// <code>l</code>
		/// is
		/// <code>null</code>
		/// ,
		/// then no localization will be used.
		/// </param>
		/// <exception cref="java.io.FileNotFoundException">
		/// if the filename does not denote a normal and writable file,
		/// or if a new file cannot be created, or if any error arises when
		/// opening or creating the file.
		/// </exception>
		/// <exception cref="java.io.UnsupportedEncodingException">if the charset with the specified name is not supported.
		/// 	</exception>
		public Formatter(string fileName, string csn, System.Globalization.CultureInfo l)
			 : this(new java.io.File(fileName), csn, l)
		{
		}

		/// <summary>
		/// Constructs a
		/// <code>Formatter</code>
		/// whose output is written to the specified
		/// <code>File</code>
		/// .
		/// The charset of the
		/// <code>Formatter</code>
		/// is the default charset.
		/// <p>The
		/// <code>Locale</code>
		/// used is the user's default locale.
		/// See "<a href="../util/Locale.html#default_locale">Be wary of the default locale</a>".
		/// </summary>
		/// <param name="file">
		/// the
		/// <code>File</code>
		/// that is used as the output destination for the
		/// <code>Formatter</code>
		/// . The
		/// <code>File</code>
		/// will be truncated to zero size if the
		/// <code>File</code>
		/// exists, or else a new
		/// <code>File</code>
		/// will be created. The output of the
		/// <code>Formatter</code>
		/// is buffered.
		/// </param>
		/// <exception cref="java.io.FileNotFoundException">
		/// if the
		/// <code>File</code>
		/// is not a normal and writable
		/// <code>File</code>
		/// , or if a
		/// new
		/// <code>File</code>
		/// cannot be created, or if any error rises when opening or
		/// creating the
		/// <code>File</code>
		/// .
		/// </exception>
		public Formatter(java.io.File file) : this(new java.io.FileOutputStream(file))
		{
		}

		/// <summary>
		/// Constructs a
		/// <code>Formatter</code>
		/// with the given charset,
		/// and whose output is written to the specified
		/// <code>File</code>
		/// .
		/// <p>The
		/// <code>Locale</code>
		/// used is the user's default locale.
		/// See "<a href="../util/Locale.html#default_locale">Be wary of the default locale</a>".
		/// </summary>
		/// <param name="file">
		/// the
		/// <code>File</code>
		/// that is used as the output destination for the
		/// <code>Formatter</code>
		/// . The
		/// <code>File</code>
		/// will be truncated to zero size if the
		/// <code>File</code>
		/// exists, or else a new
		/// <code>File</code>
		/// will be created. The output of the
		/// <code>Formatter</code>
		/// is buffered.
		/// </param>
		/// <param name="csn">
		/// the name of the charset for the
		/// <code>Formatter</code>
		/// .
		/// </param>
		/// <exception cref="java.io.FileNotFoundException">
		/// if the
		/// <code>File</code>
		/// is not a normal and writable
		/// <code>File</code>
		/// , or if a
		/// new
		/// <code>File</code>
		/// cannot be created, or if any error rises when opening or
		/// creating the
		/// <code>File</code>
		/// .
		/// </exception>
		/// <exception cref="java.io.UnsupportedEncodingException">if the charset with the specified name is not supported.
		/// 	</exception>
		public Formatter(java.io.File file, string csn) : this(file, csn, System.Globalization.CultureInfo.CurrentCulture
			)
		{
		}

		[Sharpen.Stub]
		public Formatter(java.io.File file, string csn, System.Globalization.CultureInfo 
			l)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>
		/// Constructs a
		/// <code>Formatter</code>
		/// whose output is written to the specified
		/// <code>OutputStream</code>
		/// .
		/// <p>The charset of the
		/// <code>Formatter</code>
		/// is the default charset.
		/// <p>The
		/// <code>Locale</code>
		/// used is the user's default locale.
		/// See "<a href="../util/Locale.html#default_locale">Be wary of the default locale</a>".
		/// </summary>
		/// <param name="os">
		/// the stream to be used as the destination of the
		/// <code>Formatter</code>
		/// .
		/// </param>
		public Formatter(java.io.OutputStream os)
		{
			_out = new java.io.BufferedWriter(new java.io.OutputStreamWriter(os, java.nio.charset.Charset
				.defaultCharset()));
			_locale = System.Globalization.CultureInfo.CurrentCulture;
		}

		/// <summary>
		/// Constructs a
		/// <code>Formatter</code>
		/// with the given charset,
		/// and whose output is written to the specified
		/// <code>OutputStream</code>
		/// .
		/// <p>The
		/// <code>Locale</code>
		/// used is the user's default locale.
		/// See "<a href="../util/Locale.html#default_locale">Be wary of the default locale</a>".
		/// </summary>
		/// <param name="os">
		/// the stream to be used as the destination of the
		/// <code>Formatter</code>
		/// .
		/// </param>
		/// <param name="csn">
		/// the name of the charset for the
		/// <code>Formatter</code>
		/// .
		/// </param>
		/// <exception cref="java.io.UnsupportedEncodingException">if the charset with the specified name is not supported.
		/// 	</exception>
		public Formatter(java.io.OutputStream os, string csn) : this(os, csn, System.Globalization.CultureInfo.CurrentCulture
			)
		{
		}

		/// <summary>
		/// Constructs a
		/// <code>Formatter</code>
		/// with the given
		/// <code>Locale</code>
		/// and charset,
		/// and whose output is written to the specified
		/// <code>OutputStream</code>
		/// .
		/// </summary>
		/// <param name="os">
		/// the stream to be used as the destination of the
		/// <code>Formatter</code>
		/// .
		/// </param>
		/// <param name="csn">
		/// the name of the charset for the
		/// <code>Formatter</code>
		/// .
		/// </param>
		/// <param name="l">
		/// the
		/// <code>Locale</code>
		/// of the
		/// <code>Formatter</code>
		/// . If
		/// <code>l</code>
		/// is
		/// <code>null</code>
		/// ,
		/// then no localization will be used.
		/// </param>
		/// <exception cref="java.io.UnsupportedEncodingException">if the charset with the specified name is not supported.
		/// 	</exception>
		public Formatter(java.io.OutputStream os, string csn, System.Globalization.CultureInfo
			 l)
		{
			_out = new java.io.BufferedWriter(new java.io.OutputStreamWriter(os, csn));
			_locale = l;
		}

		/// <summary>
		/// Constructs a
		/// <code>Formatter</code>
		/// whose output is written to the specified
		/// <code>PrintStream</code>
		/// .
		/// <p>The charset of the
		/// <code>Formatter</code>
		/// is the default charset.
		/// <p>The
		/// <code>Locale</code>
		/// used is the user's default locale.
		/// See "<a href="../util/Locale.html#default_locale">Be wary of the default locale</a>".
		/// </summary>
		/// <param name="ps">
		/// the
		/// <code>PrintStream</code>
		/// used as destination of the
		/// <code>Formatter</code>
		/// . If
		/// <code>ps</code>
		/// is
		/// <code>null</code>
		/// , then a
		/// <code>NullPointerException</code>
		/// will
		/// be raised.
		/// </param>
		public Formatter(java.io.PrintStream ps)
		{
			if (ps == null)
			{
				throw new System.ArgumentNullException();
			}
			_out = ps;
			_locale = System.Globalization.CultureInfo.CurrentCulture;
		}

		private void checkNotClosed()
		{
			if (closed)
			{
				throw new java.util.FormatterClosedException();
			}
		}

		/// <summary>
		/// Returns the
		/// <code>Locale</code>
		/// of the
		/// <code>Formatter</code>
		/// .
		/// </summary>
		/// <returns>
		/// the
		/// <code>Locale</code>
		/// for the
		/// <code>Formatter</code>
		/// or
		/// <code>null</code>
		/// for no
		/// <code>Locale</code>
		/// .
		/// </returns>
		/// <exception cref="FormatterClosedException">
		/// if the
		/// <code>Formatter</code>
		/// has been closed.
		/// </exception>
		public System.Globalization.CultureInfo locale()
		{
			checkNotClosed();
			return _locale;
		}

		/// <summary>
		/// Returns the output destination of the
		/// <code>Formatter</code>
		/// .
		/// </summary>
		/// <returns>
		/// the output destination of the
		/// <code>Formatter</code>
		/// .
		/// </returns>
		/// <exception cref="FormatterClosedException">
		/// if the
		/// <code>Formatter</code>
		/// has been closed.
		/// </exception>
		public java.lang.Appendable @out()
		{
			checkNotClosed();
			return _out;
		}

		/// <summary>
		/// Returns the content by calling the
		/// <code>toString()</code>
		/// method of the output
		/// destination.
		/// </summary>
		/// <returns>
		/// the content by calling the
		/// <code>toString()</code>
		/// method of the output
		/// destination.
		/// </returns>
		/// <exception cref="FormatterClosedException">
		/// if the
		/// <code>Formatter</code>
		/// has been closed.
		/// </exception>
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			checkNotClosed();
			return _out.ToString();
		}

		/// <summary>
		/// Flushes the
		/// <code>Formatter</code>
		/// . If the output destination is
		/// <see cref="java.io.Flushable">java.io.Flushable</see>
		/// ,
		/// then the method
		/// <code>flush()</code>
		/// will be called on that destination.
		/// </summary>
		/// <exception cref="FormatterClosedException">
		/// if the
		/// <code>Formatter</code>
		/// has been closed.
		/// </exception>
		[Sharpen.ImplementsInterface(@"java.io.Flushable")]
		public void flush()
		{
			checkNotClosed();
			if (_out is java.io.Flushable)
			{
				try
				{
					((java.io.Flushable)_out).flush();
				}
				catch (System.IO.IOException e)
				{
					lastIOException = e;
				}
			}
		}

		/// <summary>
		/// Closes the
		/// <code>Formatter</code>
		/// . If the output destination is
		/// <see cref="java.io.Closeable">java.io.Closeable</see>
		/// ,
		/// then the method
		/// <code>close()</code>
		/// will be called on that destination.
		/// If the
		/// <code>Formatter</code>
		/// has been closed, then calling the this method will have no
		/// effect.
		/// Any method but the
		/// <see cref="ioException()">ioException()</see>
		/// that is called after the
		/// <code>Formatter</code>
		/// has been closed will raise a
		/// <code>FormatterClosedException</code>
		/// .
		/// </summary>
		[Sharpen.ImplementsInterface(@"java.lang.AutoCloseable")]
		public void close()
		{
			if (!closed)
			{
				closed = true;
				try
				{
					if (_out is java.io.Closeable)
					{
						((java.io.Closeable)_out).close();
					}
				}
				catch (System.IO.IOException e)
				{
					lastIOException = e;
				}
			}
		}

		/// <summary>
		/// Returns the last
		/// <code>IOException</code>
		/// thrown by the
		/// <code>Formatter</code>
		/// 's output
		/// destination. If the
		/// <code>append()</code>
		/// method of the destination does not throw
		/// <code>IOException</code>
		/// s, the
		/// <code>ioException()</code>
		/// method will always return
		/// <code>null</code>
		/// .
		/// </summary>
		/// <returns>
		/// the last
		/// <code>IOException</code>
		/// thrown by the
		/// <code>Formatter</code>
		/// 's output
		/// destination.
		/// </returns>
		public System.IO.IOException ioException()
		{
			return lastIOException;
		}

		/// <summary>
		/// Writes a formatted string to the output destination of the
		/// <code>Formatter</code>
		/// .
		/// </summary>
		/// <param name="format">a format string.</param>
		/// <param name="args">
		/// the arguments list used in the
		/// <code>format()</code>
		/// method. If there are
		/// more arguments than those specified by the format string, then
		/// the additional arguments are ignored.
		/// </param>
		/// <returns>
		/// this
		/// <code>Formatter</code>
		/// .
		/// </returns>
		/// <exception cref="IllegalFormatException">
		/// if the format string is illegal or incompatible with the
		/// arguments, or if fewer arguments are sent than those required by
		/// the format string, or any other illegal situation.
		/// </exception>
		/// <exception cref="FormatterClosedException">
		/// if the
		/// <code>Formatter</code>
		/// has been closed.
		/// </exception>
		public java.util.Formatter format(string format_1, params object[] args)
		{
			return format(this._locale, format_1, args);
		}

		/// <summary>
		/// Writes a formatted string to the output destination of the
		/// <code>Formatter</code>
		/// .
		/// </summary>
		/// <param name="l">
		/// the
		/// <code>Locale</code>
		/// used in the method. If
		/// <code>locale</code>
		/// is
		/// <code>null</code>
		/// , then no localization will be applied. This
		/// parameter does not change this Formatter's default
		/// <code>Locale</code>
		/// as specified during construction, and only applies for the
		/// duration of this call.
		/// </param>
		/// <param name="format">a format string.</param>
		/// <param name="args">
		/// the arguments list used in the
		/// <code>format()</code>
		/// method. If there are
		/// more arguments than those specified by the format string, then
		/// the additional arguments are ignored.
		/// </param>
		/// <returns>
		/// this
		/// <code>Formatter</code>
		/// .
		/// </returns>
		/// <exception cref="IllegalFormatException">
		/// if the format string is illegal or incompatible with the
		/// arguments, or if fewer arguments are sent than those required by
		/// the format string, or any other illegal situation.
		/// </exception>
		/// <exception cref="FormatterClosedException">
		/// if the
		/// <code>Formatter</code>
		/// has been closed.
		/// </exception>
		public java.util.Formatter format(System.Globalization.CultureInfo l, string format_1
			, params object[] args)
		{
			System.Globalization.CultureInfo originalLocale = _locale;
			try
			{
				this._locale = (l == null ? System.Globalization.CultureInfo.InvariantCulture : l
					);
				this.localeData = Sharpen.Util.GetLocaleData(_locale);
				doFormat(format_1, args);
			}
			finally
			{
				this._locale = originalLocale;
			}
			return this;
		}

		private void doFormat(string format_1, params object[] args)
		{
			checkNotClosed();
			java.util.Formatter.FormatSpecifierParser fsp = new java.util.Formatter.FormatSpecifierParser
				(format_1);
			int currentObjectIndex = 0;
			object lastArgument = null;
			bool hasLastArgumentSet = false;
			int length = format_1.Length;
			int i = 0;
			while (i < length)
			{
				// Find the maximal plain-text sequence...
				int plainTextStart = i;
				int nextPercent = format_1.IndexOf('%', i);
				int plainTextEnd = (nextPercent == -1) ? length : nextPercent;
				// ...and output it.
				if (plainTextEnd > plainTextStart)
				{
					outputCharSequence(java.lang.CharSequenceProxy.Wrap(format_1), plainTextStart, plainTextEnd
						);
				}
				i = plainTextEnd;
				// Do we have a format specifier?
				if (i < length)
				{
					java.util.Formatter.FormatToken token = fsp.parseFormatToken(i + 1);
					object argument = null;
					if (token.requireArgument())
					{
						int index = token.getArgIndex() == java.util.Formatter.FormatToken.UNSET ? currentObjectIndex
							++ : token.getArgIndex();
						argument = getArgument(args, index, fsp, lastArgument, hasLastArgumentSet);
						lastArgument = argument;
						hasLastArgumentSet = true;
					}
					java.lang.CharSequence substitution = transform(token, argument);
					// The substitution is null if we called Formattable.formatTo.
					if (substitution != null)
					{
						outputCharSequence(substitution, 0, substitution.Length);
					}
					i = fsp.i;
				}
			}
		}

		// Fixes http://code.google.com/p/android/issues/detail?id=1767.
		private void outputCharSequence(java.lang.CharSequence cs, int start, int end)
		{
			try
			{
				_out.append(cs, start, end);
			}
			catch (System.IO.IOException e)
			{
				lastIOException = e;
			}
		}

		private object getArgument(object[] args, int index, java.util.Formatter.FormatSpecifierParser
			 fsp, object lastArgument, bool hasLastArgumentSet)
		{
			if (index == java.util.Formatter.FormatToken.LAST_ARGUMENT_INDEX && !hasLastArgumentSet)
			{
				throw new java.util.MissingFormatArgumentException("<");
			}
			if (args == null)
			{
				return null;
			}
			if (index >= args.Length)
			{
				throw new java.util.MissingFormatArgumentException(fsp.getFormatSpecifierText());
			}
			if (index == java.util.Formatter.FormatToken.LAST_ARGUMENT_INDEX)
			{
				return lastArgument;
			}
			return args[index];
		}

		private class FormatToken
		{
			internal const int LAST_ARGUMENT_INDEX = -2;

			internal const int UNSET = -1;

			internal const int FLAGS_UNSET = 0;

			internal const int DEFAULT_PRECISION = 6;

			internal const int FLAG_ZERO = 1 << 4;

			internal int argIndex = UNSET;

			internal bool flagComma;

			internal bool flagMinus;

			internal bool flagParenthesis;

			internal bool flagPlus;

			internal bool flagSharp;

			internal bool flagSpace;

			internal bool flagZero;

			internal char conversionType = unchecked((char)UNSET);

			internal char dateSuffix;

			internal int precision = UNSET;

			internal int width = UNSET;

			internal java.lang.StringBuilder strFlags;

			// These have package access for performance. They used to be represented by an int bitmask
			// and accessed via methods, but Android's JIT doesn't yet do a good job of such code.
			// Direct field access, on the other hand, is fast.
			// Tests whether there were no flags, no width, and no precision specified.
			internal virtual bool isDefault()
			{
				return !flagComma && !flagMinus && !flagParenthesis && !flagPlus && !flagSharp &&
					 !flagSpace && !flagZero && width == UNSET && precision == UNSET;
			}

			internal virtual bool isPrecisionSet()
			{
				return precision != UNSET;
			}

			internal virtual int getArgIndex()
			{
				return argIndex;
			}

			internal virtual void setArgIndex(int index)
			{
				argIndex = index;
			}

			internal virtual int getWidth()
			{
				return width;
			}

			internal virtual void setWidth(int width)
			{
				this.width = width;
			}

			internal virtual int getPrecision()
			{
				return precision;
			}

			internal virtual void setPrecision(int precise)
			{
				this.precision = precise;
			}

			internal virtual string getStrFlags()
			{
				return (strFlags != null) ? strFlags.ToString() : string.Empty;
			}

			internal virtual bool setFlag(int ch)
			{
				bool dupe = false;
				switch (ch)
				{
					case ',':
					{
						dupe = flagComma;
						flagComma = true;
						break;
					}

					case '-':
					{
						dupe = flagMinus;
						flagMinus = true;
						break;
					}

					case '(':
					{
						dupe = flagParenthesis;
						flagParenthesis = true;
						break;
					}

					case '+':
					{
						dupe = flagPlus;
						flagPlus = true;
						break;
					}

					case '#':
					{
						dupe = flagSharp;
						flagSharp = true;
						break;
					}

					case ' ':
					{
						dupe = flagSpace;
						flagSpace = true;
						break;
					}

					case '0':
					{
						dupe = flagZero;
						flagZero = true;
						break;
					}

					default:
					{
						return false;
					}
				}
				if (dupe)
				{
					// The RI documentation implies we're supposed to report all the flags, not just
					// the first duplicate, but the RI behaves the same as we do.
					throw new java.util.DuplicateFormatFlagsException(ch.ToString());
				}
				if (strFlags == null)
				{
					strFlags = new java.lang.StringBuilder(7);
				}
				// There are seven possible flags.
				strFlags.append((char)ch);
				return true;
			}

			internal virtual char getConversionType()
			{
				return conversionType;
			}

			internal virtual void setConversionType(char c)
			{
				conversionType = c;
			}

			internal virtual char getDateSuffix()
			{
				return dateSuffix;
			}

			internal virtual void setDateSuffix(char c)
			{
				dateSuffix = c;
			}

			internal virtual bool requireArgument()
			{
				return conversionType != '%' && conversionType != 'n';
			}

			internal virtual void checkFlags(object arg)
			{
				// Work out which flags are allowed.
				bool allowComma = false;
				bool allowMinus = true;
				bool allowParenthesis = false;
				bool allowPlus = false;
				bool allowSharp = false;
				bool allowSpace = false;
				bool allowZero = false;
				// Precision and width?
				bool allowPrecision = true;
				bool allowWidth = true;
				// Argument?
				bool allowArgument = true;
				switch (conversionType)
				{
					case 'c':
					case 'C':
					case 't':
					case 'T':
					{
						// Character and date/time.
						// Only '-' is allowed.
						allowPrecision = false;
						break;
					}

					case 's':
					case 'S':
					{
						// String.
						if (arg is java.util.Formattable)
						{
							allowSharp = true;
						}
						break;
					}

					case 'g':
					case 'G':
					{
						// Floating point.
						allowComma = allowParenthesis = allowPlus = allowSpace = allowZero = true;
						break;
					}

					case 'f':
					{
						allowComma = allowParenthesis = allowPlus = allowSharp = allowSpace = allowZero =
							 true;
						break;
					}

					case 'e':
					case 'E':
					{
						allowParenthesis = allowPlus = allowSharp = allowSpace = allowZero = true;
						break;
					}

					case 'a':
					case 'A':
					{
						allowPlus = allowSharp = allowSpace = allowZero = true;
						break;
					}

					case 'd':
					{
						// Integral.
						allowComma = allowParenthesis = allowPlus = allowSpace = allowZero = true;
						allowPrecision = false;
						break;
					}

					case 'o':
					case 'x':
					case 'X':
					{
						allowSharp = allowZero = true;
						if (arg == null || arg is java.math.BigInteger)
						{
							allowParenthesis = allowPlus = allowSpace = true;
						}
						allowPrecision = false;
						break;
					}

					case 'n':
					{
						// Special.
						// Nothing is allowed.
						allowMinus = false;
						allowArgument = allowPrecision = allowWidth = false;
						break;
					}

					case '%':
					{
						// The only flag allowed is '-', and no argument or precision is allowed.
						allowArgument = false;
						allowPrecision = false;
						break;
					}

					case 'b':
					case 'B':
					case 'h':
					case 'H':
					{
						// Booleans and hash codes.
						break;
					}

					default:
					{
						throw unknownFormatConversionException();
					}
				}
				// Check for disallowed flags.
				string mismatch = null;
				if (!allowComma && flagComma)
				{
					mismatch = ",";
				}
				else
				{
					if (!allowMinus && flagMinus)
					{
						mismatch = "-";
					}
					else
					{
						if (!allowParenthesis && flagParenthesis)
						{
							mismatch = "(";
						}
						else
						{
							if (!allowPlus && flagPlus)
							{
								mismatch = "+";
							}
							else
							{
								if (!allowSharp && flagSharp)
								{
									mismatch = "#";
								}
								else
								{
									if (!allowSpace && flagSpace)
									{
										mismatch = " ";
									}
									else
									{
										if (!allowZero && flagZero)
										{
											mismatch = "0";
										}
									}
								}
							}
						}
					}
				}
				if (mismatch != null)
				{
					if (conversionType == 'n')
					{
						// For no good reason, %n is a special case...
						throw new java.util.IllegalFormatFlagsException(mismatch);
					}
					else
					{
						throw new java.util.FormatFlagsConversionMismatchException(mismatch, conversionType
							);
					}
				}
				// Check for a missing width with flags that require a width.
				if ((flagMinus || flagZero) && width == UNSET)
				{
					throw new java.util.MissingFormatWidthException("-" + conversionType);
				}
				// Check that no-argument conversion types don't have an argument.
				// Note: the RI doesn't enforce this.
				if (!allowArgument && argIndex != UNSET)
				{
					throw new java.util.IllegalFormatFlagsException("%" + conversionType + " doesn't take an argument"
						);
				}
				// Check that we don't have a precision or width where they're not allowed.
				if (!allowPrecision && precision != UNSET)
				{
					throw new java.util.IllegalFormatPrecisionException(precision);
				}
				if (!allowWidth && width != UNSET)
				{
					throw new java.util.IllegalFormatWidthException(width);
				}
				// Some combinations make no sense...
				if (flagPlus && flagSpace)
				{
					throw new java.util.IllegalFormatFlagsException("the '+' and ' ' flags are incompatible"
						);
				}
				if (flagMinus && flagZero)
				{
					throw new java.util.IllegalFormatFlagsException("the '-' and '0' flags are incompatible"
						);
				}
			}

			public virtual java.util.UnknownFormatConversionException unknownFormatConversionException
				()
			{
				if (conversionType == 't' || conversionType == 'T')
				{
					throw new java.util.UnknownFormatConversionException(string.Format("%c%c", conversionType
						, dateSuffix));
				}
				throw new java.util.UnknownFormatConversionException(conversionType.ToString());
			}
		}

		// There are only two format specifiers that matter: "%d" and "%s".
		// Nothing else is common in the wild. We fast-path these two to
		// avoid the heavyweight machinery needed to cope with flags, width,
		// and precision.
		private java.util.IllegalFormatConversionException badArgumentType()
		{
			throw new java.util.IllegalFormatConversionException(formatToken.getConversionType
				(), arg.GetType());
		}

		/// <summary>
		/// Returns a CharSequence corresponding to
		/// <code>s</code>
		/// with all the ASCII digits replaced
		/// by digits appropriate to this formatter's locale. Other characters remain unchanged.
		/// </summary>
		private java.lang.CharSequence localizeDigits(java.lang.CharSequence s)
		{
			int length = s.Length;
			int offsetToLocalizedDigits = localeData.zeroDigit - '0';
			java.lang.StringBuilder result = new java.lang.StringBuilder(length);
			{
				for (int i = 0; i < length; ++i)
				{
					char ch = s[i];
					if (ch >= '0' && ch <= '9')
					{
						ch += (char)offsetToLocalizedDigits;
					}
					result.append(ch);
				}
			}
			return result;
		}

		/// <summary>Inserts the grouping separator every 3 digits.</summary>
		/// <remarks>
		/// Inserts the grouping separator every 3 digits. DecimalFormat lets you configure grouping
		/// size, but you can't access that from Formatter, and the default is every 3 digits.
		/// </remarks>
		private java.lang.CharSequence insertGrouping(java.lang.CharSequence s)
		{
			java.lang.StringBuilder result = new java.lang.StringBuilder(s.Length + s.Length 
				/ 3);
			// A leading '-' doesn't want to be included in the grouping.
			int digitsLength = s.Length;
			int i = 0;
			if (s[0] == '-')
			{
				--digitsLength;
				++i;
				result.append('-');
			}
			// Append the digits that come before the first separator.
			int headLength = digitsLength % 3;
			if (headLength == 0)
			{
				headLength = 3;
			}
			result.append(s, i, i + headLength);
			i += headLength;
			// Append the remaining groups.
			for (; i < s.Length; i += 3)
			{
				result.append(localeData.groupingSeparator);
				result.append(s, i, i + 3);
			}
			return result;
		}

		private java.lang.CharSequence transformFromBoolean()
		{
			java.lang.CharSequence result;
			if (arg is bool)
			{
				result = java.lang.CharSequenceProxy.Wrap(arg.ToString());
			}
			else
			{
				if (arg == null)
				{
					result = java.lang.CharSequenceProxy.Wrap("false");
				}
				else
				{
					result = java.lang.CharSequenceProxy.Wrap("true");
				}
			}
			return padding(result, 0);
		}

		private java.lang.CharSequence transformFromHashCode()
		{
			java.lang.CharSequence result;
			if (arg == null)
			{
				result = java.lang.CharSequenceProxy.Wrap("null");
			}
			else
			{
				result = java.lang.CharSequenceProxy.Wrap(Sharpen.Util.IntToHexString(arg.GetHashCode
					()));
			}
			return padding(result, 0);
		}

		private java.lang.CharSequence transformFromString()
		{
			if (arg is java.util.Formattable)
			{
				int flags = 0;
				if (formatToken.flagMinus)
				{
					flags |= java.util.FormattableFlags.LEFT_JUSTIFY;
				}
				if (formatToken.flagSharp)
				{
					flags |= java.util.FormattableFlags.ALTERNATE;
				}
				if (System.Char.IsUpper(formatToken.getConversionType()))
				{
					flags |= java.util.FormattableFlags.UPPERCASE;
				}
				((java.util.Formattable)arg).formatTo(this, flags, formatToken.getWidth(), formatToken
					.getPrecision());
				// all actions have been taken out in the
				// Formattable.formatTo, thus there is nothing to do, just
				// returns null, which tells the Parser to add nothing to the
				// output.
				return null;
			}
			java.lang.CharSequence result = java.lang.CharSequenceProxy.Wrap(arg != null ? arg
				.ToString() : "null");
			return padding(result, 0);
		}

		private java.lang.CharSequence transformFromPercent()
		{
			return padding(java.lang.CharSequenceProxy.Wrap("%"), 0);
		}

		private java.lang.CharSequence padding(java.lang.CharSequence source, int startIndex
			)
		{
			int start = startIndex;
			int width = formatToken.getWidth();
			int precision = formatToken.getPrecision();
			int length = source.Length;
			if (precision >= 0)
			{
				length = System.Math.Min(length, precision);
				if (source is java.lang.StringBuilder)
				{
					((java.lang.StringBuilder)source).setLength(length);
				}
				else
				{
					source = source.SubSequence(0, length);
				}
			}
			if (width > 0)
			{
				width = System.Math.Max(source.Length, width);
			}
			if (length >= width)
			{
				return source;
			}
			char paddingChar = '\u0020';
			// space as padding char.
			if (formatToken.flagZero)
			{
				if (formatToken.getConversionType() == 'd')
				{
					paddingChar = localeData.zeroDigit;
				}
				else
				{
					paddingChar = '0';
				}
			}
			else
			{
				// No localized digits for bases other than decimal.
				// if padding char is space, always pad from the start.
				start = 0;
			}
			char[] paddingChars = new char[width - length];
			java.util.Arrays.fill(paddingChars, paddingChar);
			bool paddingRight = formatToken.flagMinus;
			java.lang.StringBuilder result = toStringBuilder(source);
			if (paddingRight)
			{
				result.append(paddingChars);
			}
			else
			{
				result.insert(start, paddingChars);
			}
			return result;
		}

		private java.lang.StringBuilder toStringBuilder(java.lang.CharSequence cs)
		{
			return cs is java.lang.StringBuilder ? (java.lang.StringBuilder)cs : new java.lang.StringBuilder
				(cs);
		}

		private java.lang.StringBuilder wrapParentheses(java.lang.StringBuilder result)
		{
			result.setCharAt(0, '(');
			// Replace the '-'.
			if (formatToken.flagZero)
			{
				formatToken.setWidth(formatToken.getWidth() - 1);
				result = (java.lang.StringBuilder)padding(result, 1);
				result.append(')');
			}
			else
			{
				result.append(')');
				result = (java.lang.StringBuilder)padding(result, 0);
			}
			return result;
		}

		// Undo sign-extension, since we'll be using Long.to(Octal|Hex)String.
		private java.lang.CharSequence transformFromNull()
		{
			formatToken.flagZero = false;
			return padding(java.lang.CharSequenceProxy.Wrap("null"), 0);
		}

		// convert BigInteger to a string presentation using radix 8
		// convert BigInteger to a string presentation using radix 16
		// Calendar.JANUARY is 0; humans want January represented as 1.
		private int to12Hour(int hour)
		{
			return hour == 0 ? 12 : hour;
		}

		private void appendLocalized(java.lang.StringBuilder result, long value, int width
			)
		{
			int paddingIndex = result.Length;
			char zeroDigit = localeData.zeroDigit;
			if (zeroDigit == '0')
			{
				result.append(value);
			}
			else
			{
				result.append(localizeDigits(java.lang.CharSequenceProxy.Wrap(System.Convert.ToString
					(value))));
			}
			int zeroCount = width - (result.Length - paddingIndex);
			if (zeroCount <= 0)
			{
				return;
			}
			if (zeroDigit == '0')
			{
				result.insert(paddingIndex, ZEROS, 0, zeroCount);
			}
			else
			{
				{
					for (int i = 0; i < zeroCount; ++i)
					{
						result.insert(paddingIndex, zeroDigit);
					}
				}
			}
		}

		private java.lang.CharSequence transformFromSpecialNumber(double d)
		{
			string source = null;
			if (double.IsNaN(d))
			{
				source = "NaN";
			}
			else
			{
				if (d == double.PositiveInfinity)
				{
					if (formatToken.flagPlus)
					{
						source = "+Infinity";
					}
					else
					{
						if (formatToken.flagSpace)
						{
							source = " Infinity";
						}
						else
						{
							source = "Infinity";
						}
					}
				}
				else
				{
					if (d == double.NegativeInfinity)
					{
						if (formatToken.flagParenthesis)
						{
							source = "(Infinity)";
						}
						else
						{
							source = "-Infinity";
						}
					}
					else
					{
						return null;
					}
				}
			}
			formatToken.setPrecision(java.util.Formatter.FormatToken.UNSET);
			formatToken.flagZero = false;
			return padding(java.lang.CharSequenceProxy.Wrap(source), 0);
		}

		private class FormatSpecifierParser
		{
			internal string format;

			internal int length;

			internal int startIndex;

			internal int i;

			/// <summary>Constructs a new parser for the given format string.</summary>
			/// <remarks>Constructs a new parser for the given format string.</remarks>
			internal FormatSpecifierParser(string format)
			{
				// BigDecimal can't represent NaN or infinities, but its doubleValue method will return
				// infinities if the BigDecimal is too big for a double.
				// All zeros in this method are *pattern* characters, so no localization.
				// Unlike %f, %e uses 'e' (regardless of what the DecimalFormatSymbols would have us use).
				// The # flag requires that we always output a decimal separator.
				// All zeros in this method are *pattern* characters, so no localization.
				// The # flag requires that we always output a decimal separator.
				// %a shouldn't be localized.
				this.format = format;
				this.length = format.Length;
			}

			/// <summary>Returns a FormatToken representing the format specifier starting at 'offset'.
			/// 	</summary>
			/// <remarks>Returns a FormatToken representing the format specifier starting at 'offset'.
			/// 	</remarks>
			/// <param name="offset">the first character after the '%'</param>
			internal virtual java.util.Formatter.FormatToken parseFormatToken(int offset)
			{
				this.startIndex = offset;
				this.i = offset;
				return parseArgumentIndexAndFlags(new java.util.Formatter.FormatToken());
			}

			/// <summary>Returns a string corresponding to the last format specifier that was parsed.
			/// 	</summary>
			/// <remarks>
			/// Returns a string corresponding to the last format specifier that was parsed.
			/// Used to construct error messages.
			/// </remarks>
			internal virtual string getFormatSpecifierText()
			{
				return Sharpen.StringHelper.Substring(format, startIndex, i);
			}

			internal int peek()
			{
				return (i < length) ? format[i] : -1;
			}

			internal char advance()
			{
				if (i >= length)
				{
					throw unknownFormatConversionException();
				}
				return format[i++];
			}

			internal java.util.UnknownFormatConversionException unknownFormatConversionException
				()
			{
				throw new java.util.UnknownFormatConversionException(getFormatSpecifierText());
			}

			internal java.util.Formatter.FormatToken parseArgumentIndexAndFlags(java.util.Formatter
				.FormatToken token)
			{
				// Parse the argument index, if there is one.
				int position = i;
				int ch = peek();
				if (Sharpen.CharHelper.IsDigit(ch))
				{
					int number = nextInt();
					if (peek() == '$')
					{
						// The number was an argument index.
						advance();
						// Swallow the '$'.
						if (number == java.util.Formatter.FormatToken.UNSET)
						{
							throw new java.util.MissingFormatArgumentException(getFormatSpecifierText());
						}
						// k$ stands for the argument whose index is k-1 except that
						// 0$ and 1$ both stand for the first element.
						token.setArgIndex(System.Math.Max(0, number - 1));
					}
					else
					{
						if (ch == '0')
						{
							// The digit zero is a format flag, so reparse it as such.
							i = position;
						}
						else
						{
							// The number was a width. This means there are no flags to parse.
							return parseWidth(token, number);
						}
					}
				}
				else
				{
					if (ch == '<')
					{
						token.setArgIndex(java.util.Formatter.FormatToken.LAST_ARGUMENT_INDEX);
						advance();
					}
				}
				// Parse the flags.
				while (token.setFlag(peek()))
				{
					advance();
				}
				// What comes next?
				ch = peek();
				if (Sharpen.CharHelper.IsDigit(ch))
				{
					return parseWidth(token, nextInt());
				}
				else
				{
					if (ch == '.')
					{
						return parsePrecision(token);
					}
					else
					{
						return parseConversionType(token);
					}
				}
			}

			// We pass the width in because in some cases we've already parsed it.
			// (Because of the ambiguity between argument indexes and widths.)
			internal java.util.Formatter.FormatToken parseWidth(java.util.Formatter.FormatToken
				 token, int width)
			{
				token.setWidth(width);
				int ch = peek();
				if (ch == '.')
				{
					return parsePrecision(token);
				}
				else
				{
					return parseConversionType(token);
				}
			}

			internal java.util.Formatter.FormatToken parsePrecision(java.util.Formatter.FormatToken
				 token)
			{
				advance();
				// Swallow the '.'.
				int ch = peek();
				if (Sharpen.CharHelper.IsDigit(ch))
				{
					token.setPrecision(nextInt());
					return parseConversionType(token);
				}
				else
				{
					// The precision is required but not given by the format string.
					throw unknownFormatConversionException();
				}
			}

			internal java.util.Formatter.FormatToken parseConversionType(java.util.Formatter.
				FormatToken token)
			{
				char conversionType = advance();
				// A conversion type is mandatory.
				token.setConversionType(conversionType);
				if (conversionType == 't' || conversionType == 'T')
				{
					char dateSuffix = advance();
					// A date suffix is mandatory for 't' or 'T'.
					token.setDateSuffix(dateSuffix);
				}
				return token;
			}

			// Parses an integer (of arbitrary length, but typically just one digit).
			internal int nextInt()
			{
				long value = 0;
				while (i < length && System.Char.IsDigit(format[i]))
				{
					value = 10 * value + (format[i++] - '0');
					if (value > int.MaxValue)
					{
						return failNextInt();
					}
				}
				return (int)value;
			}

			// Swallow remaining digits to resync our attempted parse, but return failure.
			internal int failNextInt()
			{
				while (Sharpen.CharHelper.IsDigit(peek()))
				{
					advance();
				}
				return java.util.Formatter.FormatToken.UNSET;
			}
		}
	}
}

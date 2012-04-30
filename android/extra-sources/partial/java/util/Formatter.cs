using System;
using System.Globalization;
using java.lang;

namespace java.util
{
	partial class Formatter
	{
		private CharSequence transform (FormatToken token, object argument)
		{
			this.formatToken = token;
			this.arg = argument;
			// There are only two format specifiers that matter: "%d" and "%s".
			// Nothing else is common in the wild. We fast-path these two to
			// avoid the heavyweight machinery needed to cope with flags, width,
			// and precision.
			if (token.isDefault ()) {
				switch (token.getConversionType ()) {
				case 's':
					{
						if (arg == null) {
							return CharSequenceProxy.Wrap ("null");
						} else {
							if (!(arg is java.util.Formattable)) {
								return CharSequenceProxy.Wrap (arg.ToString ());
							}
						}
						break;
					}

				case 'd':
					{
						if (_out is StringBuilder) {
							if ((arg is int) || (arg is short) || (arg is byte) || (arg is long)) {
								((StringBuilder)_out).append (arg.ToString ());
								return null;
							}
						}
						if (arg is int || arg is long || arg is short || arg is byte) {
							return CharSequenceProxy.Wrap (arg.ToString ());
						}
					}
					break;
				}
			}
			formatToken.checkFlags (arg);
			CharSequence result_1;
			switch (token.getConversionType ()) {
			case 'B':
			case 'b':
				{
					result_1 = transformFromBoolean ();
					break;
				}

			case 'H':
			case 'h':
				{
					result_1 = transformFromHashCode ();
					break;
				}

			case 'S':
			case 's':
				{
					result_1 = transformFromString ();
					break;
				}

			case 'C':
			case 'c':
				{
					result_1 = transformFromCharacter ();
					break;
				}

			case 'd':
			case 'o':
			case 'x':
			case 'X':
				{
					result_1 = transformFromInteger ();
					break;
				}

			case 'A':
			case 'a':
			case 'E':
			case 'e':
			case 'f':
			case 'G':
			case 'g':
				{
					result_1 = transformFromFloat ();
					break;
				}

			case '%':
				{
					result_1 = transformFromPercent ();
					break;
				}

			case 'n':
				{
					result_1 = CharSequenceProxy.Wrap (Environment.NewLine);
					break;
				}

			case 't':
			case 'T':
				{
					result_1 = transformFromDateTime ();
					break;
				}

			default:
				{
					throw token.unknownFormatConversionException ();
				}
			}
			if (System.Char.IsUpper (token.getConversionType ())) {
				if (result_1 != null) {
					result_1 = CharSequenceProxy.Wrap (result_1.ToString ().ToUpper (_locale));
				}
			}
			return result_1;
		}

		private CharSequence transformFromCharacter ()
		{
			if (arg == null) {
				return padding (CharSequenceProxy.Wrap ("null"), 0);
			}
			if (arg is char) {
				return padding (CharSequenceProxy.Wrap (Sharpen.StringHelper.GetValueOf (arg)), 0);
			} else {
				throw badArgumentType ();
			}
		}

		private CharSequence transformFromInteger ()
		{
			int startIndex = 0;
			StringBuilder result = new StringBuilder ();
			char currentConversionType = formatToken.getConversionType ();
			long value;
			if (arg is long) {
				value = ((long)arg);
			} else {
				if (arg is int) {
					value = (int)arg;
				} else {
					if (arg is short) {
						value = (short)arg;
					} else {
						if (arg is byte) {
							value = (byte)arg;
						} else {
							throw badArgumentType ();
						}
					}
				}
			}
			if (formatToken.flagSharp) {
				if (currentConversionType == 'o') {
					result.append ("0");
					startIndex += 1;
				} else {
					result.append ("0x");
					startIndex += 2;
				}
			}
			if (currentConversionType == 'd') {
				CharSequence digits = CharSequenceProxy.Wrap (System.Convert.ToString
					(value));
				if (formatToken.flagComma) {
					digits = insertGrouping (digits);
				}
				if (localeData.zeroDigit != '0') {
					digits = localizeDigits (digits);
				}
				result.append (digits);
				if (value < 0) {
					if (formatToken.flagParenthesis) {
						return wrapParentheses (result);
					} else {
						if (formatToken.flagZero) {
							startIndex++;
						}
					}
				} else {
					if (formatToken.flagPlus) {
						result.insert (0, '+');
						startIndex += 1;
					} else {
						if (formatToken.flagSpace) {
							result.insert (0, ' ');
							startIndex += 1;
						}
					}
				}
			} else {
				// Undo sign-extension, since we'll be using Long.to(Octal|Hex)String.
				if (arg is byte) {
					value &= unchecked((long)(0xffL));
				} else {
					if (arg is short) {
						value &= unchecked((long)(0xffffL));
					} else {
						if (arg is int) {
							value &= unchecked((long)(0xffffffffL));
						}
					}
				}
				if (currentConversionType == 'o') {
					result.append (Convert.ToString (value, 10));
				} else {
					result.append (Convert.ToString (value, 16));
				}
			}
			return padding (result, startIndex);
		}

		private CharSequence transformFromFloat ()
		{
			if (arg == null) {
				return transformFromNull ();
			} else {
				if (arg is float) {
					float f = (float)arg;
					if (f != f || f == float.PositiveInfinity || f == float.NegativeInfinity)
						return transformFromSpecialNumber ((double)f);
				} else if (arg is double) {
					double d = (double)arg;
					if (d != d || d == double.PositiveInfinity || d == double.NegativeInfinity)
						return transformFromSpecialNumber (d);
				} else {
					if (arg is decimal) {
					} else {
						// BigDecimal can't represent NaN or infinities, but its doubleValue method will return
						// infinities if the BigDecimal is too big for a double.
						throw badArgumentType ();
					}
				}
			}
			char conversionType = formatToken.getConversionType ();
			if (conversionType != 'a' && conversionType != 'A' && !formatToken.isPrecisionSet
				()) {
				formatToken.setPrecision (java.util.Formatter.FormatToken.DEFAULT_PRECISION);
			}
			StringBuilder result = new StringBuilder ();
			switch (conversionType) {
			case 'a':
			case 'A':
				{
					transformA (result);
					break;
				}

			case 'e':
			case 'E':
				{
					transformE (result);
					break;
				}

			case 'f':
				{
					transformF (result);
					break;
				}

			case 'g':
			case 'G':
				{
					transformG (result);
					break;
				}

			default:
				{
					throw formatToken.unknownFormatConversionException ();
				}
			}
			formatToken.setPrecision (java.util.Formatter.FormatToken.UNSET);
			int startIndex = 0;
			if (result [0] == localeData.minusSign) {
				if (formatToken.flagParenthesis) {
					return wrapParentheses (result);
				}
			} else {
				if (formatToken.flagSpace) {
					result.insert (0, ' ');
					startIndex++;
				}
				if (formatToken.flagPlus) {
					result.insert (0, '+');
					startIndex++;
				}
			}
			char firstChar = result [0];
			if (formatToken.flagZero && (firstChar == '+' || firstChar == localeData.minusSign
				)) {
				startIndex = 1;
			}
			if (conversionType == 'a' || conversionType == 'A') {
				startIndex += 2;
			}
			return padding (result, startIndex);
		}

		private CharSequence transformFromDateTime ()
		{
			if (arg == null) {
				return transformFromNull ();
			}
			DateTime date;
			if (arg is DateTime) {
				date = (DateTime)arg;
			} else if (arg is long) {
				date = new DateTime ((long)arg);
			} else {
				throw badArgumentType ();
			}
			StringBuilder result = new StringBuilder ();
			if (!appendT (result, formatToken.getDateSuffix (), date)) {
				throw formatToken.unknownFormatConversionException ();
			}
			return padding (result, 0);
		}

		private bool appendT (StringBuilder result, char conversion, DateTime date)
		{
			DateTimeFormatInfo info = localeData.Culture.DateTimeFormat;
			switch (conversion) {
			case 'A':
				{
					result.append (info.DayNames [(int)date.DayOfWeek]);
					return true;
				}

			case 'a':
				{
					result.append (info.AbbreviatedDayNames [(int)date.DayOfWeek]);
					return true;
				}

			case 'B':
				{
					result.append (info.MonthNames [date.Day]);
					return true;
				}

			case 'b':
			case 'h':
				{
					result.append (info.AbbreviatedMonthNames [date.Day]);
					return true;
				}

			case 'C':
				{
					appendLocalized (result, date.Year / 100, 2);
					return true;
				}

			case 'D':
				{
					appendT (result, 'm', date);
					result.append ('/');
					appendT (result, 'd', date);
					result.append ('/');
					appendT (result, 'y', date);
					return true;
				}

			case 'F':
				{
					appendT (result, 'Y', date);
					result.append ('-');
					appendT (result, 'm', date);
					result.append ('-');
					appendT (result, 'd', date);
					return true;
				}

			case 'H':
				{
					appendLocalized (result, date.Hour, 2);
					return true;
				}

			case 'I':
				{
					appendLocalized (result, to12Hour (date.Hour), 2);
					return true;
				}

			case 'L':
				{
					appendLocalized (result, date.Millisecond, 3);
					return true;
				}

			case 'M':
				{
					appendLocalized (result, date.Minute, 2);
					return true;
				}

			case 'N':
				{
					appendLocalized (result, date.Millisecond * 1000000L, 9);
					return true;
				}

			case 'Q':
				{
					appendLocalized (result, date.Ticks, 0);
					return true;
				}

			case 'R':
				{
					appendT (result, 'H', date);
					result.append (':');
					appendT (result, 'M', date);
					return true;
				}

			case 'S':
				{
					appendLocalized (result, date.Second, 2);
					return true;
				}

			case 'T':
				{
					appendT (result, 'H', date);
					result.append (':');
					appendT (result, 'M', date);
					result.append (':');
					appendT (result, 'S', date);
					return true;
				}

			case 'Y':
				{
					appendLocalized (result, date.Year, 4);
					return true;
				}

			case 'Z':
				{
					result.append (System.TimeZone.CurrentTimeZone.StandardName);
					return true;
				}

			case 'c':
				{
					appendT (result, 'a', date);
					result.append (' ');
					appendT (result, 'b', date);
					result.append (' ');
					appendT (result, 'd', date);
					result.append (' ');
					appendT (result, 'T', date);
					result.append (' ');
					appendT (result, 'Z', date);
					result.append (' ');
					appendT (result, 'Y', date);
					return true;
				}

			case 'd':
				{
					appendLocalized (result, date.Day, 2);
					return true;
				}

			case 'e':
				{
					appendLocalized (result, date.Day, 0);
					return true;
				}

			case 'j':
				{
					appendLocalized (result, date.DayOfYear, 3);
					return true;
				}

			case 'k':
				{
					appendLocalized (result, date.Hour, 0);
					return true;
				}

			case 'l':
				{
					appendLocalized (result, to12Hour (date.Hour), 0);
					return true;
				}

			case 'm':
				{
					// Calendar.JANUARY is 0; humans want January represented as 1.
					appendLocalized (result, date.Month + 1, 2);
					return true;
				}

			case 'p':
				{
					result.append (date.Hour < 12 ? info.AMDesignator : info.PMDesignator);
					return true;
				}

			case 'r':
				{
					appendT (result, 'I', date);
					result.append (':');
					appendT (result, 'M', date);
					result.append (':');
					appendT (result, 'S', date);
					result.append (' ');
					result.append (date.Hour < 12 ? info.AMDesignator : info.PMDesignator);
					return true;
				}

			case 's':
				{
					appendLocalized (result, date.Ticks / 1000, 0);
					return true;
				}

			case 'y':
				{
					appendLocalized (result, date.Year % 100, 2);
					return true;
				}

			case 'z':
				{
					long offset = System.TimeZone.CurrentTimeZone.GetUtcOffset (date).Ticks;
					char sign = '+';
					if (offset < 0) {
						sign = '-';
						offset = -offset;
					}
					result.append (sign);
					appendLocalized (result, offset / 3600000, 2);
					appendLocalized (result, (offset % 3600000) / 60000, 2);
					return true;
				}
			}
			return false;
		}

		// BigDecimal can't represent NaN or infinities, but its doubleValue method will return
		// infinities if the BigDecimal is too big for a double.
		private void transformE (StringBuilder result)
		{
			// All zeros in this method are *pattern* characters, so no localization.
			int precision = formatToken.getPrecision ();
			string pattern = "0E+00";
			if (precision > 0) {
				StringBuilder sb = new StringBuilder ("0.");
				char[] zeros = new char[precision];
				java.util.Arrays.fill (zeros, '0');
				sb.append (zeros);
				sb.append ("E+00");
				pattern = sb.ToString ();
			}
			result.append (arg.ToString ().Replace ('E', 'e'));
			// The # flag requires that we always output a decimal separator.
			if (formatToken.flagSharp && precision == 0) {
				int indexOfE = result.indexOf ("e");
				result.insert (indexOfE, localeData.decimalSeparator);
			}
		}

		private void transformG (StringBuilder result)
		{
			int precision = formatToken.getPrecision ();
			if (precision == 0) {
				precision = 1;
			}
			formatToken.setPrecision (precision);
			double d = (double)arg;
			if (d == 0.0) {
				precision--;
				formatToken.setPrecision (precision);
				transformF (result);
				return;
			}
			bool requireScientificRepresentation = true;
			d = Math.Abs (d);
			if (double.IsInfinity (d)) {
				precision = formatToken.getPrecision ();
				precision--;
				formatToken.setPrecision (precision);
				transformE (result);
				return;
			}
			decimal b = new decimal (d);
			long l = (long)d;
			if (d >= 1 && d < Math.Pow (10, precision)) {
				if (l < Math.Pow (10, precision)) {
					requireScientificRepresentation = false;
					precision -= l.ToString ().Length;
					precision = precision < 0 ? 0 : precision;
					l = (long)Math.Round (d * Math.Pow (10, precision + 1));
					if (l.ToString ().Length <= formatToken.getPrecision ()) {
						precision++;
					}
					formatToken.setPrecision (precision);
				}
			} else {
				l = (long)(b / 10000);
				if (d >= Math.Pow (10, -4) && d < 1) {
					requireScientificRepresentation = false;
					precision += 4 - l.ToString ().Length;
					l = (long)decimal.Multiply (b, (decimal)Math.Pow (10, precision + 1));
					if (l.ToString ().Length <= formatToken.getPrecision ()) {
						precision++;
					}
					l = (long)decimal.Multiply (b, (decimal)Math.Pow (10, precision));
					if (l >= Math.Pow (10, precision - 4)) {
						formatToken.setPrecision (precision);
					}
				}
			}
			if (requireScientificRepresentation) {
				precision = formatToken.getPrecision ();
				precision--;
				formatToken.setPrecision (precision);
				transformE (result);
			} else {
				transformF (result);
			}
		}

		private void transformF (StringBuilder result)
		{
			// All zeros in this method are *pattern* characters, so no localization.
			string pattern = "0.000000";
			int precision = formatToken.getPrecision ();
			if (formatToken.flagComma || precision != FormatToken.DEFAULT_PRECISION) {
				StringBuilder patternBuilder = new StringBuilder ();
				if (formatToken.flagComma) {
					patternBuilder.append (',');
					int groupingSize = 3;
					char[] sharps = new char[groupingSize - 1];
					java.util.Arrays.fill (sharps, '#');
					patternBuilder.append (sharps);
				}
				patternBuilder.append ('0');
				if (precision > 0) {
					patternBuilder.append ('.');
					{
						for (int i = 0; i < precision; ++i) {
							patternBuilder.append ('0');
						}
					}
				}
				pattern = patternBuilder.ToString ();
			}
			result.append (arg.ToString ());
			// The # flag requires that we always output a decimal separator.
			if (formatToken.flagSharp && precision == 0) {
				result.append (localeData.decimalSeparator);
			}
		}

		private void transformA (StringBuilder result)
		{
			if ((arg is float) || (arg is double)) {
				result.append (String.Format ("{0:x}", arg));
			} else {
				throw badArgumentType ();
			}
			if (!formatToken.isPrecisionSet ()) {
				return;
			}
			int precision = formatToken.getPrecision ();
			if (precision == 0) {
				precision = 1;
			}
			int indexOfFirstFractionalDigit = result.indexOf (".") + 1;
			int indexOfP = result.indexOf ("p");
			int fractionalLength = indexOfP - indexOfFirstFractionalDigit;
			if (fractionalLength == precision) {
				return;
			}
			if (fractionalLength < precision) {
				char[] zeros = new char[precision - fractionalLength];
				java.util.Arrays.fill (zeros, '0');
				// %a shouldn't be localized.
				result.insert (indexOfP, zeros);
				return;
			}
			result.delete (indexOfFirstFractionalDigit + precision, indexOfP);
		}

	}
}


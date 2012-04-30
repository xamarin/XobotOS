using System;

namespace Sharpen
{
	public static class CharHelper
	{
		public static int GetType (char c)
		{
			throw new NotImplementedException ();
		}

		public static int GetType (int cp)
		{
			throw new NotImplementedException ();
		}

		public static int CodePointAt (char[] a, int index)
		{
			throw new NotImplementedException ();
		}

		public static int CodePointAt (char[] a, int index, int count)
		{
			throw new NotImplementedException ();
		}

		public static int CodePointAt (string str, int index)
		{
			throw new NotImplementedException ();
		}

		public static int CodePointBefore (char[] a, int index)
		{
			throw new NotImplementedException ();
		}

		public static int CodePointBefore (string str, int index)
		{
			throw new NotImplementedException ();
		}

		public static int CodePointCount (char[] a, int index, int count)
		{
			throw new NotImplementedException ();
		}

		public static int OffsetByCodePoints (char[] a, int start, int count, int index, int offset)
		{
			throw new NotImplementedException ();
		}

		public static byte GetDirectionality (char c)
		{
			return DIRECTIONALITY_UNDEFINED;
		}

		public static bool IsDigit (int cp)
		{
			if ((cp >= '0') && (cp <= '9'))
				return true;
			return false;
		}

		public static bool IsUpper (int cp)
		{
			if ((cp >= 'A') && (cp <= 'Z'))
				return true;
			if (cp < 128)
				return false;
			throw new NotSupportedException ();
		}

		public static bool IsLower (int cp)
		{
			if ((cp >= 'a') && (cp <= 'z'))
				return true;
			if (cp < 128)
				return false;
			throw new NotSupportedException ();
		}

		public static bool IsLetterOrDigit (int cp)
		{
			throw new NotImplementedException ();
		}

		public static int GetNumericValue (char c)
		{
			throw new NotImplementedException ();
		}

		public static char ToUpper (int cp)
		{
			if (cp < 181)
				return ToUpper ((char)cp);
			throw new NotSupportedException ();
		}

		public static char ToLower (int cp)
		{
			if (cp < 181)
				return ToLower ((char)cp);
			throw new NotSupportedException ();
		}

		public static int Digit (char c, int radix)
		{
			return Digit ((int)c, radix);
		}

		public static int Digit (int codePoint, int radix)
		{
			if (radix < MIN_RADIX || radix > MAX_RADIX)
				return -1;

			if (codePoint < 128) {
				// Optimized for ASCII
				int result = -1;
				if ('0' <= codePoint && codePoint <= '9') {
					result = codePoint - '0';
				} else if ('a' <= codePoint && codePoint <= 'z') {
					result = 10 + (codePoint - 'a');
				} else if ('A' <= codePoint && codePoint <= 'Z') {
					result = 10 + (codePoint - 'A');
				}
				return result < radix ? result : -1;
			}
			throw new NotSupportedException ();
		}

		public static bool IsISOControl (char c)
		{
			return IsISOControl ((int)c);
		}

		public static bool IsISOControl (int c)
		{
			return (c >= 0 && c <= 0x1f) || (c >= 0x7f && c <= 0x9f);
		}

		public const char MIN_VALUE = '\u0000';
		public const char MAX_VALUE = '\uffff';
		public const int MIN_RADIX = 2;
		public const int MAX_RADIX = 36;
		public const byte UNASSIGNED = 0;
		public const byte UPPERCASE_LETTER = 1;
		public const byte LOWERCASE_LETTER = 2;
		public const byte TITLECASE_LETTER = 3;
		public const byte MODIFIER_LETTER = 4;
		public const byte OTHER_LETTER = 5;
		public const byte NON_SPACING_MARK = 6;
		public const byte ENCLOSING_MARK = 7;
		public const byte COMBINING_SPACING_MARK = 8;
		public const byte DECIMAL_DIGIT_NUMBER = 9;
		public const byte LETTER_NUMBER = 10;
		public const byte OTHER_NUMBER = 11;
		public const byte SPACE_SEPARATOR = 12;
		public const byte LINE_SEPARATOR = 13;
		public const byte PARAGRAPH_SEPARATOR = 14;
		public const byte CONTROL = 15;
		public const byte FORMAT = 16;
		public const byte PRIVATE_USE = 18;
		public const byte SURROGATE = 19;
		public const byte DASH_PUNCTUATION = 20;
		public const byte START_PUNCTUATION = 21;
		public const byte END_PUNCTUATION = 22;
		public const byte CONNECTOR_PUNCTUATION = 23;
		public const byte OTHER_PUNCTUATION = 24;
		public const byte MATH_SYMBOL = 25;
		public const byte CURRENCY_SYMBOL = 26;
		public const byte MODIFIER_SYMBOL = 27;
		public const byte OTHER_SYMBOL = 28;
		public const byte INITIAL_QUOTE_PUNCTUATION = 29;
		public const byte FINAL_QUOTE_PUNCTUATION = 30;
		public const byte DIRECTIONALITY_UNDEFINED = unchecked((byte)-1);
		public const byte DIRECTIONALITY_LEFT_TO_RIGHT = 0;
		public const byte DIRECTIONALITY_RIGHT_TO_LEFT = 1;
		public const byte DIRECTIONALITY_RIGHT_TO_LEFT_ARABIC = 2;
		public const byte DIRECTIONALITY_EUROPEAN_NUMBER = 3;
		public const byte DIRECTIONALITY_EUROPEAN_NUMBER_SEPARATOR = 4;
		public const byte DIRECTIONALITY_EUROPEAN_NUMBER_TERMINATOR = 5;
		public const byte DIRECTIONALITY_ARABIC_NUMBER = 6;
		public const byte DIRECTIONALITY_COMMON_NUMBER_SEPARATOR = 7;
		public const byte DIRECTIONALITY_NONSPACING_MARK = 8;
		public const byte DIRECTIONALITY_BOUNDARY_NEUTRAL = 9;
		public const byte DIRECTIONALITY_PARAGRAPH_SEPARATOR = 10;
		public const byte DIRECTIONALITY_SEGMENT_SEPARATOR = 11;
		public const byte DIRECTIONALITY_WHITESPACE = 12;
		public const byte DIRECTIONALITY_OTHER_NEUTRALS = 13;
		public const byte DIRECTIONALITY_LEFT_TO_RIGHT_EMBEDDING = 14;
		public const byte DIRECTIONALITY_LEFT_TO_RIGHT_OVERRIDE = 15;
		public const byte DIRECTIONALITY_RIGHT_TO_LEFT_EMBEDDING = 16;
		public const byte DIRECTIONALITY_RIGHT_TO_LEFT_OVERRIDE = 17;
		public const byte DIRECTIONALITY_POP_DIRECTIONAL_FORMAT = 18;
		public const char MIN_HIGH_SURROGATE = '\uD800';
		public const char MAX_HIGH_SURROGATE = '\uDBFF';
		public const char MIN_LOW_SURROGATE = '\uDC00';
		public const char MAX_LOW_SURROGATE = '\uDFFF';
		public const char MIN_SURROGATE = '\uD800';
		public const char MAX_SURROGATE = '\uDFFF';
		public const int MIN_SUPPLEMENTARY_CODE_POINT = 0x10000;
		public const int MIN_CODE_POINT = 0x000000;
		public const int MAX_CODE_POINT = 0x10FFFF;
		public const int SIZE = 16;
	}
}


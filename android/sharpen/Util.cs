using System;
using System.Text;
using System.Threading;
using System.Globalization;

namespace Sharpen
{
	public static class Util
	{
		#region Misc

		public static Uri AppendUri (Uri uri, string path)
		{
			return new Uri (uri, path);
		}
		
		public static Uri ParseUri (string path)
		{
			return new Uri (path);
		}

		public static string ToSafeString (Uri uri)
		{
			// FIXME:
			// Check whether this is actually safe.
			string scheme = uri.Scheme.ToLower ();
			string ssp = uri.PathAndQuery;
			StringBuilder builder = new StringBuilder (64);
			if (scheme != null) {
				if (scheme.Equals ("tel") || scheme.Equals ("sip")
						|| scheme.Equals ("sms") || scheme.Equals ("smsto")
						|| scheme.Equals ("mailto")) {
					builder.Append (scheme);
					builder.Append (':');
					if (ssp != null) {
						for (int i=0; i<ssp.Length; i++) {
							char c = ssp [i];
							if (c == '-' || c == '@' || c == '.') {
								builder.Append (c);
							} else {
								builder.Append ('x');
							}
						}
					}
					return builder.ToString ();
				}
			}
			// Not a sensitive scheme, but let's still be conservative about
			// the data we include -- only the ssp, not the query params or
			// fragment, because those can often have sensitive info.
			if (scheme != null) {
				builder.Append (scheme);
				builder.Append (':');
			}
			if (ssp != null) {
				builder.Append (ssp);
			}
			return builder.ToString ();

		}

		public static string EncodeUri (string s)
		{
			return EncodeUri (s);
		}

		/* Encodes characters in the given string as '%'-escaped octets
		 * using the UTF-8 scheme. Leaves letters ("A-Z", "a-z"), numbers
		 * ("0-9"), and unreserved characters ("_-!.~'()*") intact. Encodes
		 * all other characters with the exception of those specified in the
		 * allow argument.
		 *
		 * @param s string to encode
		 * @param allow set of additional characters to allow in the encoded form,
		 *  null if no characters should be skipped
		 * @return an encoded version of s suitable for use as a URI component,
		 *  or null if s is null
		*/
		public static string EncodeUri (string s, string allow)
		{
			if (s == null) {
				return null;
			}

			// Lazily-initialized buffers.
			StringBuilder encoded = null;

			int oldLength = s.Length;

			// This loop alternates between copying over allowed characters and
			// encoding in chunks. This results in fewer method calls and
			// allocations than encoding one character at a time.
			int current = 0;
			while (current < oldLength) {
				// Start in "copying" mode where we copy over allowed chars.

				// Find the next character which needs to be encoded.
				int nextToEncode = current;
				while (nextToEncode < oldLength && isAllowed(s [nextToEncode], allow)) {
					nextToEncode++;
				}

				// If there's nothing more to encode...
				if (nextToEncode == oldLength) {
					if (current == 0) {
						// We didn't need to encode anything!
						return s;
					} else {
						// Presumably, we've already done some encoding.
						encoded.Append (s, current, oldLength);
						return encoded.ToString ();
					}
				}

				if (encoded == null) {
					encoded = new StringBuilder ();
				}

				if (nextToEncode > current) {
					// Append allowed characters leading up to this point.
					encoded.Append (s, current, nextToEncode);
				} else {
					// assert nextToEncode == current
				}

				// Switch to "encoding" mode.

				// Find the next allowed character.
				current = nextToEncode;
				int nextAllowed = current + 1;
				while (nextAllowed < oldLength && !isAllowed(s [nextAllowed], allow)) {
					nextAllowed++;
				}

				// Convert the substring to bytes and encode the bytes as
				// '%'-escaped octets.
				string toEncode = s.Substring (current, nextAllowed - current);
				byte[] bytes = new UTF8Encoding ().GetBytes (toEncode);
				int bytesLength = bytes.Length;
				for (int i = 0; i < bytesLength; i++) {
					encoded.Append ('%');
					encoded.Append (HEX_DIGITS [(bytes [i] & 0xf0) >> 4]);
					encoded.Append (HEX_DIGITS [bytes [i] & 0xf]);
				}

				current = nextAllowed;
			}

			// Encoded could still be null at this point if s is empty.
			return encoded == null ? s : encoded.ToString ();
		}

		private static readonly char[] HEX_DIGITS = "0123456789ABCDEF".ToCharArray ();

		private static bool isAllowed (char c, string allow)
		{
			return (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') ||
				(c >= '0' && c <= '9') || "_-!.~'()*".IndexOf (c) != -1 ||
				(allow != null && allow.IndexOf (c) != -1);
		}

		public static string IntToHexString (int i)
		{
			return i.ToString ("x");
		}

		public static string ByteToHexString (byte b, bool upperCase)
		{
			string str = b.ToString ("x");
			return upperCase ? str.ToUpper () : str;
		}

		public static float Random_NextFloat (Random random)
		{
			return (float)random.NextDouble ();
		}

		public static int Random_NextInt (Random random, int n)
		{
			return random.Next (n);
		}

		public static void Random_SetSeed (Random random, long seed)
		{
			; // do nothing
		}

		public static bool Equals<T> (T t, object o)
		{
			if (o == null)
				return (object)t == null;
			return o.Equals (t);
		}

		public static long CurrentTimeMillis {
			get { return DateTime.Now.Ticks; }
		}

		#endregion

		#region Bits

		public static int IdentityHashCode (object obj)
		{
			return obj.GetHashCode ();
		}
		
		public static int IntGetBitCount (int i)
		{
			// Hacker's Delight, Figure 5-2
			i -= (i >> 1) & 0x55555555;
			i = (i & 0x33333333) + ((i >> 2) & 0x33333333);
			i = ((i >> 4) + i) & 0x0F0F0F0F;
			i += i >> 8;
			i += i >> 16;
			return i & 0x0000003F;
		}

		public static int IntValueOf (int par1)
		{
			return par1;
		}

		public static bool IsLittleEndian ()
		{
			return BitConverter.IsLittleEndian;
		}

		public static int FloatToIntBits (float f)
		{
			byte[] bytes = BitConverter.GetBytes (f);
			return BitConverter.ToInt32 (bytes, 0);
		}

		public static int FloatToRawIntBits (float f)
		{
			return FloatToIntBits (f);
		}

		public static float IntBitsToFloat (int i)
		{
			byte[] bytes = BitConverter.GetBytes (i);
			return BitConverter.ToSingle (bytes, 0);
		}

		public static double LongBitsToDouble (long l)
		{
			return BitConverter.Int64BitsToDouble (l);
		}

		public static long DoubleToLongBits (double d)
		{
			return BitConverter.DoubleToInt64Bits (d);
		}

		public static long DoubleToRawLongBits (double d)
		{
			return DoubleToRawLongBits (d);
		}

		public static long ParseLong (String text, int radix)
		{
			if (radix == 10)
				return Int64.Parse (text);
			else if (radix == 16)
				return Int64.Parse (text, System.Globalization.NumberStyles.HexNumber);
			else
				throw new ArgumentException ();
		}

		public static int Long_GetBitCount (long v)
		{
			// Combines techniques from several sources
			ulong u = unchecked((ulong)v);
			u -= (u >> 1) & 0x5555555555555555uL;
			u = (u & 0x3333333333333333L) + ((u >> 2) & 0x3333333333333333uL);
			uint i = ((uint)(u >> 32)) + (uint)u;
			i = (i & 0x0F0F0F0F) + ((i >> 4) & 0x0F0F0F0F);
			i += i >> 8;
			i += i >> 16;
			return unchecked((int)(i & 0x0000007F));
		}

		#endregion

		#region Math

		public static int Round (float f)
		{
			return (int)Math.Round (f);
		}

		public static double Floor (double d)
		{
			return Math.Floor (d);
		}

		public static int Compare (float a, float b)
		{
			return a.CompareTo (b);
		}

		public static bool Compare (double a, double b)
		{
			return a.Equals (b);
		}

		#endregion

		#region Locales

		public static void SetCurrentCulture (CultureInfo culture)
		{
			Thread.CurrentThread.CurrentCulture = culture;
		}

		public static LocaleData GetLocaleData (CultureInfo culture)
		{
			return new LocaleData (culture);
		}

		public sealed class LocaleData
		{
			public CultureInfo Culture {
				get;
				private set;
			}

			public char zeroDigit {
				get { return '0'; }
			}

			public string groupingSeparator {
				get { return Culture.NumberFormat.NumberGroupSeparator; }
			}

			public char minusSign {
				get { return Culture.NumberFormat.NegativeSign [0]; }
			}

			public string decimalSeparator {
				get { return Culture.NumberFormat.NumberDecimalSeparator; }
			}

			internal LocaleData (CultureInfo culture)
			{
				this.Culture = culture;
			}
		}

		public static string GetLanguage (CultureInfo culture)
		{
			// FIXME
			return "english";
		}

		public static string GetCountry (CultureInfo culture)
		{
			// FIXME
			return "Planet Earth";
		}

		public static string GetVariant (CultureInfo culture)
		{
			// FIXME
			return "";
		}

		#endregion

		#region Exceptions

		public static void Throw (Exception e)
		{
			throw e;
		}

		public static Exception IndexOutOfRangeCtor (int index)
		{
			string msg = String.Format ("index={0}", index);
			return new IndexOutOfRangeException (msg);
		}

		public static Exception IndexOutOfRangeCtor (int length, int index)
		{
			string msg = String.Format ("length={0}; index={1}", length, index);
			return new IndexOutOfRangeException (msg);
		}

		public static Exception IndexOutOfRangeCtor (int length, int index, int count)
		{
			string msg = String.Format ("length={0}; index={1}; count={2}", length, index, count);
			return new IndexOutOfRangeException (msg);
		}

		#endregion
	}
}


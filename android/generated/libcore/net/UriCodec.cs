using Sharpen;

namespace libcore.net
{
	/// <summary>
	/// Encodes and decodes
	/// <code>application/x-www-form-urlencoded</code>
	/// content.
	/// Subclasses define exactly which characters are legal.
	/// <p>By default, UTF-8 is used to encode escaped characters. A single input
	/// character like "\u0080" may be encoded to multiple octets like %C2%80.
	/// </summary>
	[Sharpen.Sharpened]
	public abstract class UriCodec
	{
		/// <summary>
		/// Returns true if
		/// <code>c</code>
		/// does not need to be escaped.
		/// </summary>
		protected internal abstract bool isRetained(char c);

		/// <summary>
		/// Throws if
		/// <code>s</code>
		/// is invalid according to this encoder.
		/// </summary>
		/// <exception cref="java.net.URISyntaxException"></exception>
		public string validate(string uri, int start, int end, string name)
		{
			{
				for (int i = start; i < end; )
				{
					char ch = uri[i];
					if ((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z') || (ch >= '0' && ch <= '9'
						) || isRetained(ch))
					{
						i++;
					}
					else
					{
						if (ch == '%')
						{
							if (i + 2 >= end)
							{
								throw new java.net.URISyntaxException(uri, "Incomplete % sequence in " + name, i);
							}
							int d1 = hexToInt(uri[i + 1]);
							int d2 = hexToInt(uri[i + 2]);
							if (d1 == -1 || d2 == -1)
							{
								throw new java.net.URISyntaxException(uri, "Invalid % sequence: " + Sharpen.StringHelper.Substring
									(uri, i, i + 3) + " in " + name, i);
							}
							i += 3;
						}
						else
						{
							throw new java.net.URISyntaxException(uri, "Illegal character in " + name, i);
						}
					}
				}
			}
			return Sharpen.StringHelper.Substring(uri, start, end);
		}

		/// <summary>
		/// Throws if
		/// <code>s</code>
		/// contains characters that are not letters, digits or
		/// in
		/// <code>legal</code>
		/// .
		/// </summary>
		/// <exception cref="java.net.URISyntaxException"></exception>
		public static void validateSimple(string s, string legal)
		{
			{
				for (int i = 0; i < s.Length; i++)
				{
					char ch = s[i];
					if (!((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z') || (ch >= '0' && ch <=
						 '9') || legal.IndexOf(ch) > -1))
					{
						throw new java.net.URISyntaxException(s, "Illegal character", i);
					}
				}
			}
		}

		/// <summary>
		/// Encodes
		/// <code>s</code>
		/// and appends the result to
		/// <code>builder</code>
		/// .
		/// </summary>
		/// <param name="isPartiallyEncoded">
		/// true to fix input that has already been
		/// partially or fully encoded. For example, input of "hello%20world" is
		/// unchanged with isPartiallyEncoded=true but would be double-escaped to
		/// "hello%2520world" otherwise.
		/// </param>
		private void appendEncoded(java.lang.StringBuilder builder, string s, java.nio.charset.Charset
			 charset, bool isPartiallyEncoded)
		{
			if (s == null)
			{
				throw new System.ArgumentNullException();
			}
			int escapeStart = -1;
			{
				for (int i = 0; i < s.Length; i++)
				{
					char c = s[i];
					if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9') ||
						 isRetained(c) || (c == '%' && isPartiallyEncoded))
					{
						if (escapeStart != -1)
						{
							appendHex(builder, Sharpen.StringHelper.Substring(s, escapeStart, i), charset);
							escapeStart = -1;
						}
						if (c == '%' && isPartiallyEncoded)
						{
							// this is an encoded 3-character sequence like "%20"
							builder.append(java.lang.CharSequenceProxy.Wrap(s), i, i + 3);
							i += 2;
						}
						else
						{
							if (c == ' ')
							{
								builder.append('+');
							}
							else
							{
								builder.append(c);
							}
						}
					}
					else
					{
						if (escapeStart == -1)
						{
							escapeStart = i;
						}
					}
				}
			}
			if (escapeStart != -1)
			{
				appendHex(builder, Sharpen.StringHelper.Substring(s, escapeStart, s.Length), charset
					);
			}
		}

		public string encode(string s, java.nio.charset.Charset charset)
		{
			// Guess a bit larger for encoded form
			java.lang.StringBuilder builder = new java.lang.StringBuilder(s.Length + 16);
			appendEncoded(builder, s, charset, false);
			return builder.ToString();
		}

		public void appendEncoded(java.lang.StringBuilder builder, string s)
		{
			appendEncoded(builder, s, java.nio.charset.Charsets.UTF_8, false);
		}

		public void appendPartiallyEncoded(java.lang.StringBuilder builder, string s)
		{
			appendEncoded(builder, s, java.nio.charset.Charsets.UTF_8, true);
		}

		/// <param name="convertPlus">true to convert '+' to ' '.</param>
		public static string decode(string s, bool convertPlus, java.nio.charset.Charset 
			charset)
		{
			if (s.IndexOf('%') == -1 && (!convertPlus || s.IndexOf('+') == -1))
			{
				return s;
			}
			java.lang.StringBuilder result = new java.lang.StringBuilder(s.Length);
			java.io.ByteArrayOutputStream @out = new java.io.ByteArrayOutputStream();
			{
				for (int i = 0; i < s.Length; )
				{
					char c = s[i];
					if (c == '%')
					{
						do
						{
							if (i + 2 >= s.Length)
							{
								throw new System.ArgumentException("Incomplete % sequence at: " + i);
							}
							int d1 = hexToInt(s[i + 1]);
							int d2 = hexToInt(s[i + 2]);
							if (d1 == -1 || d2 == -1)
							{
								throw new System.ArgumentException("Invalid % sequence " + Sharpen.StringHelper.Substring
									(s, i, i + 3) + " at " + i);
							}
							@out.write(unchecked((byte)((d1 << 4) + d2)));
							i += 3;
						}
						while (i < s.Length && s[i] == '%');
						result.append(XobotOS.Runtime.Util.GetStringForBytes(@out.toByteArray(), charset)
							);
						@out.reset();
					}
					else
					{
						if (convertPlus && c == '+')
						{
							c = ' ';
						}
						result.append(c);
						i++;
					}
				}
			}
			return result.ToString();
		}

		/// <summary>
		/// Like
		/// <see cref="Sharpen.CharHelper.Digit(char, int)">Sharpen.CharHelper.Digit(char, int)
		/// 	</see>
		/// , but without support for non-ASCII
		/// characters.
		/// </summary>
		private static int hexToInt(char c)
		{
			if ('0' <= c && c <= '9')
			{
				return c - '0';
			}
			else
			{
				if ('a' <= c && c <= 'f')
				{
					return 10 + (c - 'a');
				}
				else
				{
					if ('A' <= c && c <= 'F')
					{
						return 10 + (c - 'A');
					}
					else
					{
						return -1;
					}
				}
			}
		}

		public static string decode(string s)
		{
			return decode(s, false, java.nio.charset.Charsets.UTF_8);
		}

		private static void appendHex(java.lang.StringBuilder builder, string s, java.nio.charset.Charset
			 charset)
		{
			foreach (byte b in XobotOS.Runtime.Util.GetBytesForString(s, charset))
			{
				appendHex(builder, b);
			}
		}

		private static void appendHex(java.lang.StringBuilder sb, byte b)
		{
			sb.append('%');
			sb.append(Sharpen.Util.ByteToHexString(b, true));
		}
	}
}

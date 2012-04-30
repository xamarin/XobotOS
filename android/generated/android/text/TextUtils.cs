using Sharpen;

namespace android.text
{
	[Sharpen.Sharpened]
	public partial class TextUtils
	{
		private TextUtils()
		{
		}

		public static void getChars(java.lang.CharSequence s, int start, int end, char[] 
			dest, int destoff)
		{
			System.Type c = s.GetType();
			if (c == typeof(string))
			{
				Sharpen.StringHelper.GetCharsForString((java.lang.CharSequenceProxy.UnWrap(s)), start
					, end, dest, destoff);
			}
			else
			{
				if (c == typeof(java.lang.StringBuffer))
				{
					((java.lang.StringBuffer)s).getChars(start, end, dest, destoff);
				}
				else
				{
					if (c == typeof(java.lang.StringBuilder))
					{
						((java.lang.StringBuilder)s).getChars(start, end, dest, destoff);
					}
					else
					{
						if (s is android.text.GetChars)
						{
							((android.text.GetChars)s).getChars(start, end, dest, destoff);
						}
						else
						{
							{
								for (int i = start; i < end; i++)
								{
									dest[destoff++] = s[i];
								}
							}
						}
					}
				}
			}
		}

		public static int indexOf(java.lang.CharSequence s, char ch)
		{
			return indexOf(s, ch, 0);
		}

		public static int indexOf(java.lang.CharSequence s, char ch, int start)
		{
			System.Type c = s.GetType();
			if (c == typeof(string))
			{
				return (java.lang.CharSequenceProxy.UnWrap(s)).IndexOf(ch, start);
			}
			return indexOf(s, ch, start, s.Length);
		}

		public static int indexOf(java.lang.CharSequence s, char ch, int start, int end)
		{
			System.Type c = s.GetType();
			if (s is android.text.GetChars || c == typeof(java.lang.StringBuffer) || c == typeof(
				java.lang.StringBuilder) || c == typeof(string))
			{
				int INDEX_INCREMENT = 500;
				char[] temp = obtain(INDEX_INCREMENT);
				while (start < end)
				{
					int segend = start + INDEX_INCREMENT;
					if (segend > end)
					{
						segend = end;
					}
					getChars(s, start, segend, temp, 0);
					int count = segend - start;
					{
						for (int i = 0; i < count; i++)
						{
							if (temp[i] == ch)
							{
								recycle(temp);
								return i + start;
							}
						}
					}
					start = segend;
				}
				recycle(temp);
				return -1;
			}
			{
				for (int i_1 = start; i_1 < end; i_1++)
				{
					if (s[i_1] == ch)
					{
						return i_1;
					}
				}
			}
			return -1;
		}

		public static int lastIndexOf(java.lang.CharSequence s, char ch)
		{
			return lastIndexOf(s, ch, s.Length - 1);
		}

		public static int lastIndexOf(java.lang.CharSequence s, char ch, int last)
		{
			System.Type c = s.GetType();
			if (c == typeof(string))
			{
				return (java.lang.CharSequenceProxy.UnWrap(s)).LastIndexOf(ch, last);
			}
			return lastIndexOf(s, ch, 0, last);
		}

		public static int lastIndexOf(java.lang.CharSequence s, char ch, int start, int last
			)
		{
			if (last < 0)
			{
				return -1;
			}
			if (last >= s.Length)
			{
				last = s.Length - 1;
			}
			int end = last + 1;
			System.Type c = s.GetType();
			if (s is android.text.GetChars || c == typeof(java.lang.StringBuffer) || c == typeof(
				java.lang.StringBuilder) || c == typeof(string))
			{
				int INDEX_INCREMENT = 500;
				char[] temp = obtain(INDEX_INCREMENT);
				while (start < end)
				{
					int segstart = end - INDEX_INCREMENT;
					if (segstart < start)
					{
						segstart = start;
					}
					getChars(s, segstart, end, temp, 0);
					int count = end - segstart;
					{
						for (int i = count - 1; i >= 0; i--)
						{
							if (temp[i] == ch)
							{
								recycle(temp);
								return i + segstart;
							}
						}
					}
					end = segstart;
				}
				recycle(temp);
				return -1;
			}
			{
				for (int i_1 = end - 1; i_1 >= start; i_1--)
				{
					if (s[i_1] == ch)
					{
						return i_1;
					}
				}
			}
			return -1;
		}

		public static int indexOf(java.lang.CharSequence s, java.lang.CharSequence needle
			)
		{
			return indexOf(s, needle, 0, s.Length);
		}

		public static int indexOf(java.lang.CharSequence s, java.lang.CharSequence needle
			, int start)
		{
			return indexOf(s, needle, start, s.Length);
		}

		public static int indexOf(java.lang.CharSequence s, java.lang.CharSequence needle
			, int start, int end)
		{
			int nlen = needle.Length;
			if (nlen == 0)
			{
				return start;
			}
			char c = needle[0];
			for (; ; )
			{
				start = indexOf(s, c, start);
				if (start > end - nlen)
				{
					break;
				}
				if (start < 0)
				{
					return -1;
				}
				if (regionMatches(s, start, needle, 0, nlen))
				{
					return start;
				}
				start++;
			}
			return -1;
		}

		public static bool regionMatches(java.lang.CharSequence one, int toffset, java.lang.CharSequence
			 two, int ooffset, int len)
		{
			char[] temp = obtain(2 * len);
			getChars(one, toffset, toffset + len, temp, 0);
			getChars(two, ooffset, ooffset + len, temp, len);
			bool match = true;
			{
				for (int i = 0; i < len; i++)
				{
					if (temp[i] != temp[i + len])
					{
						match = false;
						break;
					}
				}
			}
			recycle(temp);
			return match;
		}

		/// <summary>
		/// Create a new String object containing the given range of characters
		/// from the source string.
		/// </summary>
		/// <remarks>
		/// Create a new String object containing the given range of characters
		/// from the source string.  This is different than simply calling
		/// <see cref="java.lang.CharSequence.SubSequence(int, int)">CharSequence.subSequence
		/// 	</see>
		/// in that it does not preserve any style runs in the source sequence,
		/// allowing a more efficient implementation.
		/// </remarks>
		public static string substring(java.lang.CharSequence source, int start, int end)
		{
			if (java.lang.CharSequenceProxy.IsStringProxy(source))
			{
				return Sharpen.StringHelper.Substring((java.lang.CharSequenceProxy.UnWrap(source)
					), start, end);
			}
			if (source is java.lang.StringBuilder)
			{
				return ((java.lang.StringBuilder)source).substring(start, end);
			}
			if (source is java.lang.StringBuffer)
			{
				return ((java.lang.StringBuffer)source).substring(start, end);
			}
			char[] temp = obtain(end - start);
			getChars(source, start, end, temp, 0);
			string ret = new string(temp, 0, end - start);
			recycle(temp);
			return ret;
		}

		/// <summary>
		/// Returns list of multiple
		/// <see cref="java.lang.CharSequence">java.lang.CharSequence</see>
		/// joined into a single
		/// <see cref="java.lang.CharSequence">java.lang.CharSequence</see>
		/// separated by localized delimiter such as ", ".
		/// </summary>
		/// <hide></hide>
		public static java.lang.CharSequence join(java.lang.Iterable<java.lang.CharSequence
			> list)
		{
			java.lang.CharSequence delimiter = android.content.res.Resources.getSystem().getText
				(android.@internal.R.@string.list_delimeter);
			return java.lang.CharSequenceProxy.Wrap(join(delimiter, list));
		}

		/// <summary>Returns a string containing the tokens joined by delimiters.</summary>
		/// <remarks>Returns a string containing the tokens joined by delimiters.</remarks>
		/// <param name="tokens">
		/// an array objects to be joined. Strings will be formed from
		/// the objects by calling object.toString().
		/// </param>
		public static string join(java.lang.CharSequence delimiter, object[] tokens)
		{
			java.lang.StringBuilder sb = new java.lang.StringBuilder();
			bool firstTime = true;
			foreach (object token in tokens)
			{
				if (firstTime)
				{
					firstTime = false;
				}
				else
				{
					sb.append(delimiter);
				}
				sb.append(token);
			}
			return sb.ToString();
		}

		/// <summary>Returns a string containing the tokens joined by delimiters.</summary>
		/// <remarks>Returns a string containing the tokens joined by delimiters.</remarks>
		/// <param name="tokens">
		/// an array objects to be joined. Strings will be formed from
		/// the objects by calling object.toString().
		/// </param>
		public static string join(java.lang.CharSequence delimiter, java.lang.Iterable<object
			> tokens)
		{
			java.lang.StringBuilder sb = new java.lang.StringBuilder();
			bool firstTime = true;
			foreach (object token in Sharpen.IterableProxy.Create(tokens))
			{
				if (firstTime)
				{
					firstTime = false;
				}
				else
				{
					sb.append(delimiter);
				}
				sb.append(token);
			}
			return sb.ToString();
		}

		/// <summary>String.split() returns [''] when the string to be split is empty.</summary>
		/// <remarks>
		/// String.split() returns [''] when the string to be split is empty. This returns []. This does
		/// not remove any empty strings from the result. For example split("a,", ","  ) returns {"a", ""}.
		/// </remarks>
		/// <param name="text">the string to split</param>
		/// <param name="expression">the regular expression to match</param>
		/// <returns>an array of strings. The array will be empty if text is empty</returns>
		/// <exception cref="System.ArgumentNullException">if expression or text is null</exception>
		public static string[] split(string text, string expression)
		{
			if (text.Length == 0)
			{
				return EMPTY_STRING_ARRAY;
			}
			else
			{
				return XobotOS.Runtime.Util.SplitStringRegex(text, expression, -1);
			}
		}

		/// <summary>Splits a string on a pattern.</summary>
		/// <remarks>
		/// Splits a string on a pattern. String.split() returns [''] when the string to be
		/// split is empty. This returns []. This does not remove any empty strings from the result.
		/// </remarks>
		/// <param name="text">the string to split</param>
		/// <param name="pattern">the regular expression to match</param>
		/// <returns>an array of strings. The array will be empty if text is empty</returns>
		/// <exception cref="System.ArgumentNullException">if expression or text is null</exception>
		public static string[] split(string text, java.util.regex.Pattern pattern)
		{
			if (text.Length == 0)
			{
				return EMPTY_STRING_ARRAY;
			}
			else
			{
				return pattern.split(java.lang.CharSequenceProxy.Wrap(text), -1);
			}
		}

		/// <summary>
		/// An interface for splitting strings according to rules that are opaque to the user of this
		/// interface.
		/// </summary>
		/// <remarks>
		/// An interface for splitting strings according to rules that are opaque to the user of this
		/// interface. This also has less overhead than split, which uses regular expressions and
		/// allocates an array to hold the results.
		/// <p>The most efficient way to use this class is:
		/// <pre>
		/// // Once
		/// TextUtils.StringSplitter splitter = new TextUtils.SimpleStringSplitter(delimiter);
		/// // Once per string to split
		/// splitter.setString(string);
		/// for (String s : splitter) {
		/// ...
		/// }
		/// </pre>
		/// </remarks>
		public interface StringSplitter : java.lang.Iterable<string>
		{
			void setString(string @string);
		}

		/// <summary>A simple string splitter.</summary>
		/// <remarks>
		/// A simple string splitter.
		/// <p>If the final character in the string to split is the delimiter then no empty string will
		/// be returned for the empty string after that delimeter. That is, splitting <tt>"a,b,"</tt> on
		/// comma will return <tt>"a", "b"</tt>, not <tt>"a", "b", ""</tt>.
		/// </remarks>
		public class SimpleStringSplitter : android.text.TextUtils.StringSplitter, java.util.Iterator
			<string>
		{
			private string mString;

			private char mDelimiter;

			private int mPosition;

			private int mLength;

			/// <summary>Initializes the splitter.</summary>
			/// <remarks>Initializes the splitter. setString may be called later.</remarks>
			/// <param name="delimiter">the delimeter on which to split</param>
			public SimpleStringSplitter(char delimiter)
			{
				mDelimiter = delimiter;
			}

			/// <summary>Sets the string to split</summary>
			/// <param name="string">the string to split</param>
			[Sharpen.ImplementsInterface(@"android.text.TextUtils.StringSplitter")]
			public virtual void setString(string @string)
			{
				mString = @string;
				mPosition = 0;
				mLength = mString.Length;
			}

			[Sharpen.ImplementsInterface(@"java.lang.Iterable")]
			public virtual java.util.Iterator<string> iterator()
			{
				return this;
			}

			[Sharpen.ImplementsInterface(@"java.util.Iterator")]
			public virtual bool hasNext()
			{
				return mPosition < mLength;
			}

			[Sharpen.ImplementsInterface(@"java.util.Iterator")]
			public virtual string next()
			{
				int end = mString.IndexOf(mDelimiter, mPosition);
				if (end == -1)
				{
					end = mLength;
				}
				string nextString = Sharpen.StringHelper.Substring(mString, mPosition, end);
				mPosition = end + 1;
				// Skip the delimiter.
				return nextString;
			}

			[Sharpen.ImplementsInterface(@"java.util.Iterator")]
			public virtual void remove()
			{
				throw new System.NotSupportedException();
			}
		}

		public static java.lang.CharSequence stringOrSpannedString(java.lang.CharSequence
			 source)
		{
			if (source == null)
			{
				return null;
			}
			if (source is android.text.SpannedString)
			{
				return source;
			}
			if (source is android.text.Spanned)
			{
				return new android.text.SpannedString(source);
			}
			return java.lang.CharSequenceProxy.Wrap(source.ToString());
		}

		/// <summary>Returns true if the string is null or 0-length.</summary>
		/// <remarks>Returns true if the string is null or 0-length.</remarks>
		/// <param name="str">the string to be examined</param>
		/// <returns>true if str is null or zero length</returns>
		public static bool isEmpty(java.lang.CharSequence str)
		{
			if (str == null || str.Length == 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// Returns the length that the specified CharSequence would have if
		/// spaces and control characters were trimmed from the start and end,
		/// as by
		/// <see cref="string.Trim()">string.Trim()</see>
		/// .
		/// </summary>
		public static int getTrimmedLength(java.lang.CharSequence s)
		{
			int len = s.Length;
			int start = 0;
			while (start < len && s[start] <= ' ')
			{
				start++;
			}
			int end = len;
			while (end > start && s[end - 1] <= ' ')
			{
				end--;
			}
			return end - start;
		}

		/// <summary>Returns true if a and b are equal, including if they are both null.</summary>
		/// <remarks>
		/// Returns true if a and b are equal, including if they are both null.
		/// <p><i>Note: In platform versions 1.1 and earlier, this method only worked well if
		/// both the arguments were instances of String.</i></p>
		/// </remarks>
		/// <param name="a">first CharSequence to check</param>
		/// <param name="b">second CharSequence to check</param>
		/// <returns>true if a and b are equal</returns>
		public static bool equals(java.lang.CharSequence a, java.lang.CharSequence b)
		{
			if (a == b)
			{
				return true;
			}
			int length;
			if (a != null && b != null && (length = a.Length) == b.Length)
			{
				if (java.lang.CharSequenceProxy.IsStringProxy(a) && java.lang.CharSequenceProxy.IsStringProxy
					(b))
				{
					return a.Equals(b);
				}
				else
				{
					{
						for (int i = 0; i < length; i++)
						{
							if (a[i] != b[i])
							{
								return false;
							}
						}
					}
					return true;
				}
			}
			return false;
		}

		// XXX currently this only reverses chars, not spans
		public static java.lang.CharSequence getReverse(java.lang.CharSequence source, int
			 start, int end)
		{
			return new android.text.TextUtils.Reverser(source, start, end);
		}

		private class Reverser : java.lang.CharSequence, android.text.GetChars
		{
			public Reverser(java.lang.CharSequence source, int start, int end)
			{
				mSource = source;
				mStart = start;
				mEnd = end;
			}

			public virtual int Length
			{
				get
				{
					return mEnd - mStart;
				}
			}

			[Sharpen.ImplementsInterface(@"java.lang.CharSequence")]
			public virtual java.lang.CharSequence SubSequence(int start, int end)
			{
				char[] buf = new char[end - start];
				getChars(start, end, buf, 0);
				return java.lang.CharSequenceProxy.Wrap(new string(buf));
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override string ToString()
			{
				return SubSequence(0, Length).ToString();
			}

			public virtual char this[int off]
			{
				get
				{
					return android.text.AndroidCharacter.getMirror(mSource[mEnd - 1 - off]);
				}
			}

			[Sharpen.ImplementsInterface(@"android.text.GetChars")]
			public virtual void getChars(int start, int end, char[] dest, int destoff)
			{
				android.text.TextUtils.getChars(mSource, start + mStart, end + mStart, dest, destoff
					);
				android.text.AndroidCharacter.mirror(dest, 0, end - start);
				int len = end - start;
				int n = (end - start) / 2;
				{
					for (int i = 0; i < n; i++)
					{
						char tmp = dest[destoff + i];
						dest[destoff + i] = dest[destoff + len - i - 1];
						dest[destoff + len - i - 1] = tmp;
					}
				}
			}

			internal java.lang.CharSequence mSource;

			internal int mStart;

			internal int mEnd;
		}

		/// <hide></hide>
		public const int ALIGNMENT_SPAN = 1;

		/// <hide></hide>
		public const int FOREGROUND_COLOR_SPAN = 2;

		/// <hide></hide>
		public const int RELATIVE_SIZE_SPAN = 3;

		/// <hide></hide>
		public const int SCALE_X_SPAN = 4;

		/// <hide></hide>
		public const int STRIKETHROUGH_SPAN = 5;

		/// <hide></hide>
		public const int UNDERLINE_SPAN = 6;

		/// <hide></hide>
		public const int STYLE_SPAN = 7;

		/// <hide></hide>
		public const int BULLET_SPAN = 8;

		/// <hide></hide>
		public const int QUOTE_SPAN = 9;

		/// <hide></hide>
		public const int LEADING_MARGIN_SPAN = 10;

		/// <hide></hide>
		public const int URL_SPAN = 11;

		/// <hide></hide>
		public const int BACKGROUND_COLOR_SPAN = 12;

		/// <hide></hide>
		public const int TYPEFACE_SPAN = 13;

		/// <hide></hide>
		public const int SUPERSCRIPT_SPAN = 14;

		/// <hide></hide>
		public const int SUBSCRIPT_SPAN = 15;

		/// <hide></hide>
		public const int ABSOLUTE_SIZE_SPAN = 16;

		/// <hide></hide>
		public const int TEXT_APPEARANCE_SPAN = 17;

		/// <hide></hide>
		public const int ANNOTATION = 18;

		/// <hide></hide>
		public const int SUGGESTION_SPAN = 19;

		/// <hide></hide>
		public const int SPELL_CHECK_SPAN = 20;

		/// <hide></hide>
		public const int SUGGESTION_RANGE_SPAN = 21;

		/// <hide></hide>
		public const int EASY_EDIT_SPAN = 22;

		/// <summary>
		/// Flatten a CharSequence and whatever styles can be copied across processes
		/// into the parcel.
		/// </summary>
		/// <remarks>
		/// Flatten a CharSequence and whatever styles can be copied across processes
		/// into the parcel.
		/// </remarks>
		public static void writeToParcel(java.lang.CharSequence cs, android.os.Parcel p, 
			int parcelableFlags)
		{
			if (cs is android.text.Spanned)
			{
				p.writeInt(0);
				p.writeString(cs.ToString());
				android.text.Spanned sp = (android.text.Spanned)cs;
				object[] os = sp.getSpans<object>(0, cs.Length);
				{
					// note to people adding to this: check more specific types
					// before more generic types.  also notice that it uses
					// "if" instead of "else if" where there are interfaces
					// so one object can be several.
					for (int i = 0; i < os.Length; i++)
					{
						object o = os[i];
						object prop = os[i];
						if (prop is android.text.style.CharacterStyle)
						{
							prop = ((android.text.style.CharacterStyle)prop).getUnderlying();
						}
						if (prop is android.text.ParcelableSpan)
						{
							android.text.ParcelableSpan ps = (android.text.ParcelableSpan)prop;
							p.writeInt(ps.getSpanTypeId());
							ps.writeToParcel(p, parcelableFlags);
							writeWhere(p, sp, o);
						}
					}
				}
				p.writeInt(0);
			}
			else
			{
				p.writeInt(1);
				if (cs != null)
				{
					p.writeString(cs.ToString());
				}
				else
				{
					p.writeString(null);
				}
			}
		}

		private static void writeWhere(android.os.Parcel p, android.text.Spanned sp, object
			 o)
		{
			p.writeInt(sp.getSpanStart(o));
			p.writeInt(sp.getSpanEnd(o));
			p.writeInt(sp.getSpanFlags(o));
		}

		private sealed class _Creator_643 : android.os.ParcelableClass.Creator<java.lang.CharSequence
			>
		{
			public _Creator_643()
			{
			}

			/// <summary>
			/// Read and return a new CharSequence, possibly with styles,
			/// from the parcel.
			/// </summary>
			/// <remarks>
			/// Read and return a new CharSequence, possibly with styles,
			/// from the parcel.
			/// </remarks>
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public java.lang.CharSequence createFromParcel(android.os.Parcel p)
			{
				int kind = p.readInt();
				string @string = p.readString();
				if (@string == null)
				{
					return null;
				}
				if (kind == 1)
				{
					return java.lang.CharSequenceProxy.Wrap(@string);
				}
				android.text.SpannableString sp = new android.text.SpannableString(java.lang.CharSequenceProxy.Wrap
					(@string));
				while (true)
				{
					kind = p.readInt();
					if (kind == 0)
					{
						break;
					}
					switch (kind)
					{
						case android.text.TextUtils.ALIGNMENT_SPAN:
						{
							android.text.TextUtils.readSpan(p, sp, new android.text.style.AlignmentSpanClass.
								Standard(p));
							break;
						}

						case android.text.TextUtils.FOREGROUND_COLOR_SPAN:
						{
							android.text.TextUtils.readSpan(p, sp, new android.text.style.ForegroundColorSpan
								(p));
							break;
						}

						case android.text.TextUtils.RELATIVE_SIZE_SPAN:
						{
							android.text.TextUtils.readSpan(p, sp, new android.text.style.RelativeSizeSpan(p)
								);
							break;
						}

						case android.text.TextUtils.SCALE_X_SPAN:
						{
							android.text.TextUtils.readSpan(p, sp, new android.text.style.ScaleXSpan(p));
							break;
						}

						case android.text.TextUtils.STRIKETHROUGH_SPAN:
						{
							android.text.TextUtils.readSpan(p, sp, new android.text.style.StrikethroughSpan(p
								));
							break;
						}

						case android.text.TextUtils.UNDERLINE_SPAN:
						{
							android.text.TextUtils.readSpan(p, sp, new android.text.style.UnderlineSpan(p));
							break;
						}

						case android.text.TextUtils.STYLE_SPAN:
						{
							android.text.TextUtils.readSpan(p, sp, new android.text.style.StyleSpan(p));
							break;
						}

						case android.text.TextUtils.BULLET_SPAN:
						{
							android.text.TextUtils.readSpan(p, sp, new android.text.style.BulletSpan(p));
							break;
						}

						case android.text.TextUtils.QUOTE_SPAN:
						{
							android.text.TextUtils.readSpan(p, sp, new android.text.style.QuoteSpan(p));
							break;
						}

						case android.text.TextUtils.LEADING_MARGIN_SPAN:
						{
							android.text.TextUtils.readSpan(p, sp, new android.text.style.LeadingMarginSpanClass
								.Standard(p));
							break;
						}

						case android.text.TextUtils.URL_SPAN:
						{
							android.text.TextUtils.readSpan(p, sp, new android.text.style.URLSpan(p));
							break;
						}

						case android.text.TextUtils.BACKGROUND_COLOR_SPAN:
						{
							android.text.TextUtils.readSpan(p, sp, new android.text.style.BackgroundColorSpan
								(p));
							break;
						}

						case android.text.TextUtils.TYPEFACE_SPAN:
						{
							android.text.TextUtils.readSpan(p, sp, new android.text.style.TypefaceSpan(p));
							break;
						}

						case android.text.TextUtils.SUPERSCRIPT_SPAN:
						{
							android.text.TextUtils.readSpan(p, sp, new android.text.style.SuperscriptSpan(p));
							break;
						}

						case android.text.TextUtils.SUBSCRIPT_SPAN:
						{
							android.text.TextUtils.readSpan(p, sp, new android.text.style.SubscriptSpan(p));
							break;
						}

						case android.text.TextUtils.ABSOLUTE_SIZE_SPAN:
						{
							android.text.TextUtils.readSpan(p, sp, new android.text.style.AbsoluteSizeSpan(p)
								);
							break;
						}

						case android.text.TextUtils.TEXT_APPEARANCE_SPAN:
						{
							android.text.TextUtils.readSpan(p, sp, new android.text.style.TextAppearanceSpan(
								p));
							break;
						}

						case android.text.TextUtils.ANNOTATION:
						{
							android.text.TextUtils.readSpan(p, sp, new android.text.Annotation(p));
							break;
						}

						case android.text.TextUtils.SUGGESTION_SPAN:
						{
							android.text.TextUtils.readSpan(p, sp, new android.text.style.SuggestionSpan(p));
							break;
						}

						case android.text.TextUtils.SPELL_CHECK_SPAN:
						{
							android.text.TextUtils.readSpan(p, sp, new android.text.style.SpellCheckSpan(p));
							break;
						}

						case android.text.TextUtils.SUGGESTION_RANGE_SPAN:
						{
							android.text.TextUtils.readSpan(p, sp, new android.text.style.SuggestionRangeSpan
								(p));
							break;
						}

						case android.text.TextUtils.EASY_EDIT_SPAN:
						{
							android.text.TextUtils.readSpan(p, sp, new android.text.style.EasyEditSpan());
							break;
						}

						default:
						{
							throw new java.lang.RuntimeException("bogus span encoding " + kind);
						}
					}
				}
				return sp;
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public java.lang.CharSequence[] newArray(int size)
			{
				return new java.lang.CharSequence[size];
			}
		}

		public static readonly android.os.ParcelableClass.Creator<java.lang.CharSequence>
			 CHAR_SEQUENCE_CREATOR = new _Creator_643();

		/// <summary>Debugging tool to print the spans in a CharSequence.</summary>
		/// <remarks>
		/// Debugging tool to print the spans in a CharSequence.  The output will
		/// be printed one span per line.  If the CharSequence is not a Spanned,
		/// then the entire string will be printed on a single line.
		/// </remarks>
		public static void dumpSpans(java.lang.CharSequence cs, android.util.Printer printer
			, string prefix)
		{
			if (cs is android.text.Spanned)
			{
				android.text.Spanned sp = (android.text.Spanned)cs;
				object[] os = sp.getSpans<object>(0, cs.Length);
				{
					for (int i = 0; i < os.Length; i++)
					{
						object o = os[i];
						printer.println(prefix + cs.SubSequence(sp.getSpanStart(o), sp.getSpanEnd(o)) + ": "
							 + Sharpen.Util.IntToHexString(Sharpen.Util.IdentityHashCode(o)) + " " + XobotOS.Runtime.Reflection.GetCanonicalName
							(o.GetType()) + " (" + sp.getSpanStart(o) + "-" + sp.getSpanEnd(o) + ") fl=#" + 
							sp.getSpanFlags(o));
					}
				}
			}
			else
			{
				printer.println(prefix + cs + ": (no spans)");
			}
		}

		/// <summary>
		/// Return a new CharSequence in which each of the source strings is
		/// replaced by the corresponding element of the destinations.
		/// </summary>
		/// <remarks>
		/// Return a new CharSequence in which each of the source strings is
		/// replaced by the corresponding element of the destinations.
		/// </remarks>
		public static java.lang.CharSequence replace(java.lang.CharSequence template, string
			[] sources, java.lang.CharSequence[] destinations)
		{
			android.text.SpannableStringBuilder tb = new android.text.SpannableStringBuilder(
				template);
			{
				for (int i = 0; i < sources.Length; i++)
				{
					int where = indexOf(tb, java.lang.CharSequenceProxy.Wrap(sources[i]));
					if (where >= 0)
					{
						tb.setSpan(sources[i], where, where + sources[i].Length, android.text.SpannedClass.SPAN_EXCLUSIVE_EXCLUSIVE
							);
					}
				}
			}
			{
				for (int i_1 = 0; i_1 < sources.Length; i_1++)
				{
					int start = tb.getSpanStart(sources[i_1]);
					int end = tb.getSpanEnd(sources[i_1]);
					if (start >= 0)
					{
						tb.replace(start, end, destinations[i_1]);
					}
				}
			}
			return tb;
		}

		/// <summary>Replace instances of "^1", "^2", etc.</summary>
		/// <remarks>
		/// Replace instances of "^1", "^2", etc. in the
		/// <code>template</code> CharSequence with the corresponding
		/// <code>values</code>.  "^^" is used to produce a single caret in
		/// the output.  Only up to 9 replacement values are supported,
		/// "^10" will be produce the first replacement value followed by a
		/// '0'.
		/// </remarks>
		/// <param name="template">
		/// the input text containing "^1"-style
		/// placeholder values.  This object is not modified; a copy is
		/// returned.
		/// </param>
		/// <param name="values">
		/// CharSequences substituted into the template.  The
		/// first is substituted for "^1", the second for "^2", and so on.
		/// </param>
		/// <returns>the new CharSequence produced by doing the replacement</returns>
		/// <exception cref="System.ArgumentException">
		/// if the template requests a
		/// value that was not provided, or if more than 9 values are
		/// provided.
		/// </exception>
		public static java.lang.CharSequence expandTemplate(java.lang.CharSequence template
			, params java.lang.CharSequence[] values)
		{
			if (values.Length > 9)
			{
				throw new System.ArgumentException("max of 9 values are supported");
			}
			android.text.SpannableStringBuilder ssb = new android.text.SpannableStringBuilder
				(template);
			try
			{
				int i = 0;
				while (i < ssb.Length)
				{
					if (ssb[i] == '^')
					{
						char next = ssb[i + 1];
						if (next == '^')
						{
							ssb.delete(i + 1, i + 2);
							++i;
							continue;
						}
						else
						{
							if (System.Char.IsDigit(next))
							{
								int which = Sharpen.CharHelper.GetNumericValue(next) - 1;
								if (which < 0)
								{
									throw new System.ArgumentException("template requests value ^" + (which + 1));
								}
								if (which >= values.Length)
								{
									throw new System.ArgumentException("template requests value ^" + (which + 1) + "; only "
										 + values.Length + " provided");
								}
								ssb.replace(i, i + 2, values[which]);
								i += values[which].Length;
								continue;
							}
						}
					}
					++i;
				}
			}
			catch (System.IndexOutOfRangeException)
			{
			}
			// happens when ^ is the last character in the string.
			return ssb;
		}

		public static int getOffsetBefore(java.lang.CharSequence text, int offset)
		{
			if (offset == 0)
			{
				return 0;
			}
			if (offset == 1)
			{
				return 0;
			}
			char c = text[offset - 1];
			if (c >= '\uDC00' && c <= '\uDFFF')
			{
				char c1 = text[offset - 2];
				if (c1 >= '\uD800' && c1 <= '\uDBFF')
				{
					offset -= 2;
				}
				else
				{
					offset -= 1;
				}
			}
			else
			{
				offset -= 1;
			}
			if (text is android.text.Spanned)
			{
				android.text.style.ReplacementSpan[] spans = ((android.text.Spanned)text).getSpans
					<android.text.style.ReplacementSpan>(offset, offset);
				{
					for (int i = 0; i < spans.Length; i++)
					{
						int start = ((android.text.Spanned)text).getSpanStart(spans[i]);
						int end = ((android.text.Spanned)text).getSpanEnd(spans[i]);
						if (start < offset && end > offset)
						{
							offset = start;
						}
					}
				}
			}
			return offset;
		}

		public static int getOffsetAfter(java.lang.CharSequence text, int offset)
		{
			int len = text.Length;
			if (offset == len)
			{
				return len;
			}
			if (offset == len - 1)
			{
				return len;
			}
			char c = text[offset];
			if (c >= '\uD800' && c <= '\uDBFF')
			{
				char c1 = text[offset + 1];
				if (c1 >= '\uDC00' && c1 <= '\uDFFF')
				{
					offset += 2;
				}
				else
				{
					offset += 1;
				}
			}
			else
			{
				offset += 1;
			}
			if (text is android.text.Spanned)
			{
				android.text.style.ReplacementSpan[] spans = ((android.text.Spanned)text).getSpans
					<android.text.style.ReplacementSpan>(offset, offset);
				{
					for (int i = 0; i < spans.Length; i++)
					{
						int start = ((android.text.Spanned)text).getSpanStart(spans[i]);
						int end = ((android.text.Spanned)text).getSpanEnd(spans[i]);
						if (start < offset && end > offset)
						{
							offset = end;
						}
					}
				}
			}
			return offset;
		}

		private static void readSpan(android.os.Parcel p, android.text.Spannable sp, object
			 o)
		{
			sp.setSpan(o, p.readInt(), p.readInt(), p.readInt());
		}

		[Sharpen.Stub]
		[Sharpen.Comment(@"FIXME: android.text.Spanned.getSpans()")]
		public static void copySpansFrom(android.text.Spanned source, int start, int end, 
			System.Type kind, android.text.Spannable dest, int destoff)
		{
			throw new System.NotImplementedException();
		}

		public enum TruncateAt
		{
			START,
			MIDDLE,
			END,
			MARQUEE,
			/// <hide></hide>
			END_SMALL
		}

		public interface EllipsizeCallback
		{
			/// <summary>
			/// This method is called to report that the specified region of
			/// text was ellipsized away by a call to
			/// <see cref="#ellipsize">#ellipsize</see>
			/// .
			/// </summary>
			void ellipsized(int start, int end);
		}

		/// <summary>
		/// Returns the original text if it fits in the specified width
		/// given the properties of the specified Paint,
		/// or, if it does not fit, a truncated
		/// copy with ellipsis character added at the specified edge or center.
		/// </summary>
		/// <remarks>
		/// Returns the original text if it fits in the specified width
		/// given the properties of the specified Paint,
		/// or, if it does not fit, a truncated
		/// copy with ellipsis character added at the specified edge or center.
		/// </remarks>
		public static java.lang.CharSequence ellipsize(java.lang.CharSequence text, android.text.TextPaint
			 p, float avail, android.text.TextUtils.TruncateAt? where)
		{
			return ellipsize(text, p, avail, where, false, null);
		}

		/// <summary>
		/// Returns the original text if it fits in the specified width
		/// given the properties of the specified Paint,
		/// or, if it does not fit, a copy with ellipsis character added
		/// at the specified edge or center.
		/// </summary>
		/// <remarks>
		/// Returns the original text if it fits in the specified width
		/// given the properties of the specified Paint,
		/// or, if it does not fit, a copy with ellipsis character added
		/// at the specified edge or center.
		/// If <code>preserveLength</code> is specified, the returned copy
		/// will be padded with zero-width spaces to preserve the original
		/// length and offsets instead of truncating.
		/// If <code>callback</code> is non-null, it will be called to
		/// report the start and end of the ellipsized range.  TextDirection
		/// is determined by the first strong directional character.
		/// </remarks>
		public static java.lang.CharSequence ellipsize(java.lang.CharSequence text, android.text.TextPaint
			 paint, float avail, android.text.TextUtils.TruncateAt? where, bool preserveLength
			, android.text.TextUtils.EllipsizeCallback callback)
		{
			return ellipsize(text, paint, avail, where, preserveLength, callback, android.text.TextDirectionHeuristics
				.FIRSTSTRONG_LTR, (where == android.text.TextUtils.TruncateAt.END_SMALL) ? ELLIPSIS_TWO_DOTS
				 : ELLIPSIS_NORMAL);
		}

		/// <summary>
		/// Returns the original text if it fits in the specified width
		/// given the properties of the specified Paint,
		/// or, if it does not fit, a copy with ellipsis character added
		/// at the specified edge or center.
		/// </summary>
		/// <remarks>
		/// Returns the original text if it fits in the specified width
		/// given the properties of the specified Paint,
		/// or, if it does not fit, a copy with ellipsis character added
		/// at the specified edge or center.
		/// If <code>preserveLength</code> is specified, the returned copy
		/// will be padded with zero-width spaces to preserve the original
		/// length and offsets instead of truncating.
		/// If <code>callback</code> is non-null, it will be called to
		/// report the start and end of the ellipsized range.
		/// </remarks>
		/// <hide></hide>
		public static java.lang.CharSequence ellipsize(java.lang.CharSequence text, android.text.TextPaint
			 paint, float avail, android.text.TextUtils.TruncateAt? where, bool preserveLength
			, android.text.TextUtils.EllipsizeCallback callback, android.text.TextDirectionHeuristic
			 textDir, string ellipsis)
		{
			int len = text.Length;
			android.text.MeasuredText mt = android.text.MeasuredText.obtain();
			try
			{
				float width = setPara(mt, paint, text, 0, text.Length, textDir);
				if (width <= avail)
				{
					if (callback != null)
					{
						callback.ellipsized(0, 0);
					}
					return text;
				}
				// XXX assumes ellipsis string does not require shaping and
				// is unaffected by style
				float ellipsiswid = paint.measureText(ellipsis);
				avail -= ellipsiswid;
				int left = 0;
				int right = len;
				if (avail < 0)
				{
				}
				else
				{
					// it all goes
					if (where == android.text.TextUtils.TruncateAt.START)
					{
						right = len - mt.breakText(0, len, false, avail);
					}
					else
					{
						if (where == android.text.TextUtils.TruncateAt.END || where == android.text.TextUtils.TruncateAt
							.END_SMALL)
						{
							left = mt.breakText(0, len, true, avail);
						}
						else
						{
							right = len - mt.breakText(0, len, false, avail / 2);
							avail -= mt.measure(right, len);
							left = mt.breakText(0, right, true, avail);
						}
					}
				}
				if (callback != null)
				{
					callback.ellipsized(left, right);
				}
				char[] buf = mt.mChars;
				android.text.Spanned sp = text is android.text.Spanned ? (android.text.Spanned)text
					 : null;
				int remaining = len - (right - left);
				if (preserveLength)
				{
					if (remaining > 0)
					{
						// else eliminate the ellipsis too
						buf[left++] = ellipsis[0];
					}
					{
						for (int i = left; i < right; i++)
						{
							buf[i] = ZWNBS_CHAR;
						}
					}
					string s = new string(buf, 0, len);
					if (sp == null)
					{
						return java.lang.CharSequenceProxy.Wrap(s);
					}
					android.text.SpannableString ss = new android.text.SpannableString(java.lang.CharSequenceProxy.Wrap
						(s));
					copySpansFrom(sp, 0, len, typeof(object), ss, 0);
					return ss;
				}
				if (remaining == 0)
				{
					return java.lang.CharSequenceProxy.Wrap(string.Empty);
				}
				if (sp == null)
				{
					java.lang.StringBuilder sb = new java.lang.StringBuilder(remaining + ellipsis.Length
						);
					sb.append(buf, 0, left);
					sb.append(ellipsis);
					sb.append(buf, right, len - right);
					return java.lang.CharSequenceProxy.Wrap(sb.ToString());
				}
				android.text.SpannableStringBuilder ssb = new android.text.SpannableStringBuilder
					();
				ssb.append(text, 0, left);
				ssb.append(java.lang.CharSequenceProxy.Wrap(ellipsis));
				ssb.append(text, right, len);
				return ssb;
			}
			finally
			{
				android.text.MeasuredText.recycle(mt);
			}
		}

		[Sharpen.Stub]
		[Sharpen.Comment(@"FIXME: Implicit conversion from float to int")]
		public static java.lang.CharSequence commaEllipsize(java.lang.CharSequence text, 
			android.text.TextPaint p, float avail, string oneMore, string more)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.Comment(@"FIXME: Implicit conversion from float to int")]
		public static java.lang.CharSequence commaEllipsize(java.lang.CharSequence text, 
			android.text.TextPaint p, float avail, string oneMore, string more, android.text.TextDirectionHeuristic
			 textDir)
		{
			throw new System.NotImplementedException();
		}

		// XXX should not insert spaces, should be part of string
		// XXX should use plural rules and not assume English plurals
		// XXX this is probably ok, but need to look at it more
		internal static float setPara(android.text.MeasuredText mt, android.text.TextPaint
			 paint, java.lang.CharSequence text, int start, int end, android.text.TextDirectionHeuristic
			 textDir)
		{
			mt.setPara(text, start, end, textDir);
			float width;
			android.text.Spanned sp = text is android.text.Spanned ? (android.text.Spanned)text
				 : null;
			int len = end - start;
			if (sp == null)
			{
				width = mt.addStyleRun(paint, len, null);
			}
			else
			{
				width = 0;
				int spanEnd;
				{
					for (int spanStart = 0; spanStart < len; spanStart = spanEnd)
					{
						spanEnd = sp.nextSpanTransition(spanStart, len, typeof(android.text.style.MetricAffectingSpan
							));
						android.text.style.MetricAffectingSpan[] spans = sp.getSpans<android.text.style.MetricAffectingSpan
							>(spanStart, spanEnd);
						spans = android.text.TextUtils.removeEmptySpans<android.text.style.MetricAffectingSpan
							>(spans, sp);
						width += mt.addStyleRun(paint, spans, spanEnd - spanStart, null);
					}
				}
			}
			return width;
		}

		internal const char FIRST_RIGHT_TO_LEFT = '\u0590';

		internal static bool doesNotNeedBidi(java.lang.CharSequence s, int start, int end
			)
		{
			{
				for (int i = start; i < end; i++)
				{
					if (s[i] >= FIRST_RIGHT_TO_LEFT)
					{
						return false;
					}
				}
			}
			return true;
		}

		internal static bool doesNotNeedBidi(char[] text, int start, int len)
		{
			{
				int i = start;
				int e = i + len;
				for (; i < e; i++)
				{
					if (text[i] >= FIRST_RIGHT_TO_LEFT)
					{
						return false;
					}
				}
			}
			return true;
		}

		internal static char[] obtain(int len)
		{
			char[] buf;
			lock (sLock)
			{
				buf = sTemp;
				sTemp = null;
			}
			if (buf == null || buf.Length < len)
			{
				buf = new char[android.util.@internal.ArrayUtils.idealCharArraySize(len)];
			}
			return buf;
		}

		internal static void recycle(char[] temp)
		{
			if (temp.Length > 1000)
			{
				return;
			}
			lock (sLock)
			{
				sTemp = temp;
			}
		}

		/// <summary>Html-encode the string.</summary>
		/// <remarks>Html-encode the string.</remarks>
		/// <param name="s">the string to be encoded</param>
		/// <returns>the encoded string</returns>
		public static string htmlEncode(string s)
		{
			java.lang.StringBuilder sb = new java.lang.StringBuilder();
			char c;
			{
				for (int i = 0; i < s.Length; i++)
				{
					c = s[i];
					switch (c)
					{
						case '<':
						{
							sb.append("&lt;");
							//$NON-NLS-1$
							break;
						}

						case '>':
						{
							sb.append("&gt;");
							//$NON-NLS-1$
							break;
						}

						case '&':
						{
							sb.append("&amp;");
							//$NON-NLS-1$
							break;
						}

						case '\'':
						{
							sb.append("&apos;");
							//$NON-NLS-1$
							break;
						}

						case '"':
						{
							sb.append("&quot;");
							//$NON-NLS-1$
							break;
						}

						default:
						{
							sb.append(c);
							break;
						}
					}
				}
			}
			return sb.ToString();
		}

		/// <summary>
		/// Returns a CharSequence concatenating the specified CharSequences,
		/// retaining their spans if any.
		/// </summary>
		/// <remarks>
		/// Returns a CharSequence concatenating the specified CharSequences,
		/// retaining their spans if any.
		/// </remarks>
		public static java.lang.CharSequence concat(params java.lang.CharSequence[] text)
		{
			if (text.Length == 0)
			{
				return java.lang.CharSequenceProxy.Wrap(string.Empty);
			}
			if (text.Length == 1)
			{
				return text[0];
			}
			bool spanned = false;
			{
				for (int i = 0; i < text.Length; i++)
				{
					if (text[i] is android.text.Spanned)
					{
						spanned = true;
						break;
					}
				}
			}
			java.lang.StringBuilder sb = new java.lang.StringBuilder();
			{
				for (int i_1 = 0; i_1 < text.Length; i_1++)
				{
					sb.append(text[i_1]);
				}
			}
			if (!spanned)
			{
				return java.lang.CharSequenceProxy.Wrap(sb.ToString());
			}
			android.text.SpannableString ss = new android.text.SpannableString(sb);
			int off = 0;
			{
				for (int i_2 = 0; i_2 < text.Length; i_2++)
				{
					int len = text[i_2].Length;
					if (text[i_2] is android.text.Spanned)
					{
						copySpansFrom((android.text.Spanned)text[i_2], 0, len, typeof(object), ss, off);
					}
					off += len;
				}
			}
			return new android.text.SpannedString(ss);
		}

		/// <summary>Returns whether the given CharSequence contains any printable characters.
		/// 	</summary>
		/// <remarks>Returns whether the given CharSequence contains any printable characters.
		/// 	</remarks>
		public static bool isGraphic(java.lang.CharSequence str)
		{
			int len = str.Length;
			{
				for (int i = 0; i < len; i++)
				{
					int gc = Sharpen.CharHelper.GetType(str[i]);
					if (gc != Sharpen.CharHelper.CONTROL && gc != Sharpen.CharHelper.FORMAT && gc != 
						Sharpen.CharHelper.SURROGATE && gc != Sharpen.CharHelper.UNASSIGNED && gc != Sharpen.CharHelper.LINE_SEPARATOR
						 && gc != Sharpen.CharHelper.PARAGRAPH_SEPARATOR && gc != Sharpen.CharHelper.SPACE_SEPARATOR)
					{
						return true;
					}
				}
			}
			return false;
		}

		/// <summary>Returns whether this character is a printable character.</summary>
		/// <remarks>Returns whether this character is a printable character.</remarks>
		public static bool isGraphic(char c)
		{
			int gc = Sharpen.CharHelper.GetType(c);
			return gc != Sharpen.CharHelper.CONTROL && gc != Sharpen.CharHelper.FORMAT && gc 
				!= Sharpen.CharHelper.SURROGATE && gc != Sharpen.CharHelper.UNASSIGNED && gc != 
				Sharpen.CharHelper.LINE_SEPARATOR && gc != Sharpen.CharHelper.PARAGRAPH_SEPARATOR
				 && gc != Sharpen.CharHelper.SPACE_SEPARATOR;
		}

		/// <summary>Returns whether the given CharSequence contains only digits.</summary>
		/// <remarks>Returns whether the given CharSequence contains only digits.</remarks>
		public static bool isDigitsOnly(java.lang.CharSequence str)
		{
			int len = str.Length;
			{
				for (int i = 0; i < len; i++)
				{
					if (!System.Char.IsDigit(str[i]))
					{
						return false;
					}
				}
			}
			return true;
		}

		/// <hide></hide>
		public static bool isPrintableAscii(char c)
		{
			int asciiFirst = unchecked((int)(0x20));
			int asciiLast = unchecked((int)(0x7E));
			// included
			return (asciiFirst <= c && c <= asciiLast) || c == '\r' || c == '\n';
		}

		/// <hide></hide>
		public static bool isPrintableAsciiOnly(java.lang.CharSequence str)
		{
			int len = str.Length;
			{
				for (int i = 0; i < len; i++)
				{
					if (!isPrintableAscii(str[i]))
					{
						return false;
					}
				}
			}
			return true;
		}

		/// <summary>
		/// Capitalization mode for
		/// <see cref="getCapsMode(java.lang.CharSequence, int, int)">getCapsMode(java.lang.CharSequence, int, int)
		/// 	</see>
		/// : capitalize all
		/// characters.  This value is explicitly defined to be the same as
		/// <see cref="android.text.InputTypeClass.TYPE_TEXT_FLAG_CAP_CHARACTERS">android.text.InputTypeClass.TYPE_TEXT_FLAG_CAP_CHARACTERS
		/// 	</see>
		/// .
		/// </summary>
		public const int CAP_MODE_CHARACTERS = android.text.InputTypeClass.TYPE_TEXT_FLAG_CAP_CHARACTERS;

		/// <summary>
		/// Capitalization mode for
		/// <see cref="getCapsMode(java.lang.CharSequence, int, int)">getCapsMode(java.lang.CharSequence, int, int)
		/// 	</see>
		/// : capitalize the first
		/// character of all words.  This value is explicitly defined to be the same as
		/// <see cref="android.text.InputTypeClass.TYPE_TEXT_FLAG_CAP_WORDS">android.text.InputTypeClass.TYPE_TEXT_FLAG_CAP_WORDS
		/// 	</see>
		/// .
		/// </summary>
		public const int CAP_MODE_WORDS = android.text.InputTypeClass.TYPE_TEXT_FLAG_CAP_WORDS;

		/// <summary>
		/// Capitalization mode for
		/// <see cref="getCapsMode(java.lang.CharSequence, int, int)">getCapsMode(java.lang.CharSequence, int, int)
		/// 	</see>
		/// : capitalize the first
		/// character of each sentence.  This value is explicitly defined to be the same as
		/// <see cref="android.text.InputTypeClass.TYPE_TEXT_FLAG_CAP_SENTENCES">android.text.InputTypeClass.TYPE_TEXT_FLAG_CAP_SENTENCES
		/// 	</see>
		/// .
		/// </summary>
		public const int CAP_MODE_SENTENCES = android.text.InputTypeClass.TYPE_TEXT_FLAG_CAP_SENTENCES;

		/// <summary>
		/// Determine what caps mode should be in effect at the current offset in
		/// the text.
		/// </summary>
		/// <remarks>
		/// Determine what caps mode should be in effect at the current offset in
		/// the text.  Only the mode bits set in <var>reqModes</var> will be
		/// checked.  Note that the caps mode flags here are explicitly defined
		/// to match those in
		/// <see cref="InputType">InputType</see>
		/// .
		/// </remarks>
		/// <param name="cs">The text that should be checked for caps modes.</param>
		/// <param name="off">Location in the text at which to check.</param>
		/// <param name="reqModes">
		/// The modes to be checked: may be any combination of
		/// <see cref="CAP_MODE_CHARACTERS">CAP_MODE_CHARACTERS</see>
		/// ,
		/// <see cref="CAP_MODE_WORDS">CAP_MODE_WORDS</see>
		/// , and
		/// <see cref="CAP_MODE_SENTENCES">CAP_MODE_SENTENCES</see>
		/// .
		/// </param>
		/// <returns>
		/// Returns the actual capitalization modes that can be in effect
		/// at the current position, which is any combination of
		/// <see cref="CAP_MODE_CHARACTERS">CAP_MODE_CHARACTERS</see>
		/// ,
		/// <see cref="CAP_MODE_WORDS">CAP_MODE_WORDS</see>
		/// , and
		/// <see cref="CAP_MODE_SENTENCES">CAP_MODE_SENTENCES</see>
		/// .
		/// </returns>
		public static int getCapsMode(java.lang.CharSequence cs, int off, int reqModes)
		{
			if (off < 0)
			{
				return 0;
			}
			int i;
			char c;
			int mode = 0;
			if ((reqModes & CAP_MODE_CHARACTERS) != 0)
			{
				mode |= CAP_MODE_CHARACTERS;
			}
			if ((reqModes & (CAP_MODE_WORDS | CAP_MODE_SENTENCES)) == 0)
			{
				return mode;
			}
			// Back over allowed opening punctuation.
			for (i = off; i > 0; i--)
			{
				c = cs[i - 1];
				if (c != '"' && c != '\'' && Sharpen.CharHelper.GetType(c) != Sharpen.CharHelper.START_PUNCTUATION)
				{
					break;
				}
			}
			// Start of paragraph, with optional whitespace.
			int j = i;
			while (j > 0 && ((c = cs[j - 1]) == ' ' || c == '\t'))
			{
				j--;
			}
			if (j == 0 || cs[j - 1] == '\n')
			{
				return mode | CAP_MODE_WORDS;
			}
			// Or start of word if we are that style.
			if ((reqModes & CAP_MODE_SENTENCES) == 0)
			{
				if (i != j)
				{
					mode |= CAP_MODE_WORDS;
				}
				return mode;
			}
			// There must be a space if not the start of paragraph.
			if (i == j)
			{
				return mode;
			}
			// Back over allowed closing punctuation.
			for (; j > 0; j--)
			{
				c = cs[j - 1];
				if (c != '"' && c != '\'' && Sharpen.CharHelper.GetType(c) != Sharpen.CharHelper.END_PUNCTUATION)
				{
					break;
				}
			}
			if (j > 0)
			{
				c = cs[j - 1];
				if (c == '.' || c == '?' || c == '!')
				{
					// Do not capitalize if the word ends with a period but
					// also contains a period, in which case it is an abbreviation.
					if (c == '.')
					{
						{
							for (int k = j - 2; k >= 0; k--)
							{
								c = cs[k];
								if (c == '.')
								{
									return mode;
								}
								if (!System.Char.IsLetter(c))
								{
									break;
								}
							}
						}
					}
					return mode | CAP_MODE_SENTENCES;
				}
			}
			return mode;
		}

		/// <summary>
		/// Does a comma-delimited list 'delimitedString' contain a certain item?
		/// (without allocating memory)
		/// </summary>
		/// <hide></hide>
		public static bool delimitedStringContains(string delimitedString, char delimiter
			, string item)
		{
			if (isEmpty(java.lang.CharSequenceProxy.Wrap(delimitedString)) || isEmpty(java.lang.CharSequenceProxy.Wrap
				(item)))
			{
				return false;
			}
			int pos = -1;
			int length = delimitedString.Length;
			while ((pos = delimitedString.IndexOf(item, pos + 1)) != -1)
			{
				if (pos > 0 && delimitedString[pos - 1] != delimiter)
				{
					continue;
				}
				int expectedDelimiterPos = pos + item.Length;
				if (expectedDelimiterPos == length)
				{
					// Match at end of string.
					return true;
				}
				if (delimitedString[expectedDelimiterPos] == delimiter)
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>Removes empty spans from the <code>spans</code> array.</summary>
		/// <remarks>
		/// Removes empty spans from the <code>spans</code> array.
		/// When parsing a Spanned using
		/// <see cref="Spanned.nextSpanTransition(int, int, System.Type{T})">Spanned.nextSpanTransition(int, int, System.Type&lt;T&gt;)
		/// 	</see>
		/// , empty spans
		/// will (correctly) create span transitions, and calling getSpans on a slice of text bounded by
		/// one of these transitions will (correctly) include the empty overlapping span.
		/// However, these empty spans should not be taken into account when layouting or rendering the
		/// string and this method provides a way to filter getSpans' results accordingly.
		/// </remarks>
		/// <param name="spans">
		/// A list of spans retrieved using
		/// <see cref="Spanned.getSpans{T}(int, int, System.Type{T})">Spanned.getSpans&lt;T&gt;(int, int, System.Type&lt;T&gt;)
		/// 	</see>
		/// from
		/// the <code>spanned</code>
		/// </param>
		/// <param name="spanned">The Spanned from which spans were extracted</param>
		/// <returns>
		/// A subset of spans where empty spans (
		/// <see cref="Spanned.getSpanStart(object)">Spanned.getSpanStart(object)</see>
		/// ==
		/// <see cref="Spanned.getSpanEnd(object)">Spanned.getSpanEnd(object)</see>
		/// have been removed. The initial order is preserved
		/// </returns>
		/// <hide></hide>
		public static T[] removeEmptySpans<T>(T[] spans, android.text.Spanned spanned)
		{
			System.Type klass = typeof(T);
			T[] copy = null;
			int count = 0;
			{
				for (int i = 0; i < spans.Length; i++)
				{
					T span = spans[i];
					int start = spanned.getSpanStart(span);
					int end = spanned.getSpanEnd(span);
					if (start == end)
					{
						if (copy == null)
						{
							copy = (T[])System.Array.CreateInstance(klass, spans.Length - 1);
							System.Array.Copy(spans, 0, copy, 0, i);
							count = i;
						}
					}
					else
					{
						if (copy != null)
						{
							copy[count] = span;
							count++;
						}
					}
				}
			}
			if (copy != null)
			{
				T[] result = (T[])System.Array.CreateInstance(klass, count);
				System.Array.Copy(copy, 0, result, 0, count);
				return result;
			}
			else
			{
				return spans;
			}
		}

		private static object sLock = new object();

		private static char[] sTemp = null;

		private static string[] EMPTY_STRING_ARRAY = new string[] {  };

		internal const char ZWNBS_CHAR = '\uFEFF';

		private static readonly string ELLIPSIS_NORMAL = "...";

		private static readonly string ELLIPSIS_TWO_DOTS = "..";
	}
}

using System.Runtime.InteropServices;
using Sharpen;

namespace java.util.regex
{
	/// <summary>
	/// The result of applying a
	/// <code>Pattern</code>
	/// to a given input. See
	/// <see cref="Pattern">Pattern</see>
	/// for
	/// example uses.
	/// </summary>
	[Sharpen.Sharpened]
	public sealed class Matcher : java.util.regex.MatchResult, System.IDisposable
	{
		/// <summary>Holds the pattern, that is, the compiled regular expression.</summary>
		/// <remarks>Holds the pattern, that is, the compiled regular expression.</remarks>
		private java.util.regex.Pattern _pattern;

		/// <summary>Holds the handle for the native version of the pattern.</summary>
		/// <remarks>Holds the handle for the native version of the pattern.</remarks>
		internal java.util.regex.Matcher.NativeRegexMatcher address;

		/// <summary>Holds the input text.</summary>
		/// <remarks>Holds the input text.</remarks>
		private string input;

		/// <summary>
		/// Holds the start of the region, or 0 if the matching should start at the
		/// beginning of the text.
		/// </summary>
		/// <remarks>
		/// Holds the start of the region, or 0 if the matching should start at the
		/// beginning of the text.
		/// </remarks>
		private int _regionStart;

		/// <summary>
		/// Holds the end of the region, or input.length() if the matching should
		/// go until the end of the input.
		/// </summary>
		/// <remarks>
		/// Holds the end of the region, or input.length() if the matching should
		/// go until the end of the input.
		/// </remarks>
		private int _regionEnd;

		/// <summary>Holds the position where the next find operation will take place.</summary>
		/// <remarks>Holds the position where the next find operation will take place.</remarks>
		private int findPos;

		/// <summary>Holds the position where the next append operation will take place.</summary>
		/// <remarks>Holds the position where the next append operation will take place.</remarks>
		private int appendPos;

		/// <summary>
		/// Reflects whether a match has been found during the most recent find
		/// operation.
		/// </summary>
		/// <remarks>
		/// Reflects whether a match has been found during the most recent find
		/// operation.
		/// </remarks>
		private bool matchFound;

		/// <summary>Holds the offsets for the most recent match.</summary>
		/// <remarks>Holds the offsets for the most recent match.</remarks>
		private int[] matchOffsets;

		/// <summary>Reflects whether the bounds of the region are anchoring.</summary>
		/// <remarks>Reflects whether the bounds of the region are anchoring.</remarks>
		private bool anchoringBounds = true;

		/// <summary>Reflects whether the bounds of the region are transparent.</summary>
		/// <remarks>Reflects whether the bounds of the region are transparent.</remarks>
		private bool transparentBounds;

		/// <summary>Creates a matcher for a given combination of pattern and input.</summary>
		/// <remarks>
		/// Creates a matcher for a given combination of pattern and input. Both
		/// elements can be changed later on.
		/// </remarks>
		/// <param name="pattern">the pattern to use.</param>
		/// <param name="input">the input to use.</param>
		internal Matcher(java.util.regex.Pattern pattern_1, java.lang.CharSequence input)
		{
			usePattern(pattern_1);
			reset(input);
		}

		/// <summary>
		/// Appends a literal part of the input plus a replacement for the current
		/// match to a given
		/// <see cref="java.lang.StringBuffer">java.lang.StringBuffer</see>
		/// . The literal part is exactly the
		/// part of the input between the previous match and the current match. The
		/// method can be used in conjunction with
		/// <see cref="find()">find()</see>
		/// and
		/// <see cref="appendTail(java.lang.StringBuffer)">appendTail(java.lang.StringBuffer)
		/// 	</see>
		/// to walk through the input and replace
		/// all occurrences of the
		/// <code>Pattern</code>
		/// with something else.
		/// </summary>
		/// <param name="buffer">
		/// the
		/// <code>StringBuffer</code>
		/// to append to.
		/// </param>
		/// <param name="replacement">the replacement text.</param>
		/// <returns>
		/// the
		/// <code>Matcher</code>
		/// itself.
		/// </returns>
		/// <exception cref="System.InvalidOperationException">if no successful match has been made.
		/// 	</exception>
		public java.util.regex.Matcher appendReplacement(java.lang.StringBuffer buffer, string
			 replacement)
		{
			buffer.append(Sharpen.StringHelper.Substring(input, appendPos, start()));
			appendEvaluated(buffer, replacement);
			appendPos = end();
			return this;
		}

		/// <summary>Internal helper method to append a given string to a given string buffer.
		/// 	</summary>
		/// <remarks>
		/// Internal helper method to append a given string to a given string buffer.
		/// If the string contains any references to groups, these are replaced by
		/// the corresponding group's contents.
		/// </remarks>
		/// <param name="buffer">the string buffer.</param>
		/// <param name="s">the string to append.</param>
		private void appendEvaluated(java.lang.StringBuffer buffer, string s)
		{
			bool escape = false;
			bool dollar = false;
			{
				for (int i = 0; i < s.Length; i++)
				{
					char c = s[i];
					if (c == '\\' && !escape)
					{
						escape = true;
					}
					else
					{
						if (c == '$' && !escape)
						{
							dollar = true;
						}
						else
						{
							if (c >= '0' && c <= '9' && dollar)
							{
								buffer.append(group(c - '0'));
								dollar = false;
							}
							else
							{
								buffer.append(c);
								dollar = false;
								escape = false;
							}
						}
					}
				}
			}
			// This seemingly stupid piece of code reproduces a JDK bug.
			if (escape)
			{
				throw Sharpen.Util.IndexOutOfRangeCtor(s.Length);
			}
		}

		/// <summary>
		/// Resets the
		/// <code>Matcher</code>
		/// . This results in the region being set to the
		/// whole input. Results of a previous find get lost. The next attempt to
		/// find an occurrence of the
		/// <see cref="Pattern">Pattern</see>
		/// in the string will start at the
		/// beginning of the input.
		/// </summary>
		/// <returns>
		/// the
		/// <code>Matcher</code>
		/// itself.
		/// </returns>
		public java.util.regex.Matcher reset()
		{
			return reset(java.lang.CharSequenceProxy.Wrap(input), 0, input.Length);
		}

		/// <summary>
		/// Provides a new input and resets the
		/// <code>Matcher</code>
		/// . This results in the
		/// region being set to the whole input. Results of a previous find get lost.
		/// The next attempt to find an occurrence of the
		/// <see cref="Pattern">Pattern</see>
		/// in the
		/// string will start at the beginning of the input.
		/// </summary>
		/// <param name="input">the new input sequence.</param>
		/// <returns>
		/// the
		/// <code>Matcher</code>
		/// itself.
		/// </returns>
		public java.util.regex.Matcher reset(java.lang.CharSequence input)
		{
			return reset(input, 0, input.Length);
		}

		/// <summary>Resets the Matcher.</summary>
		/// <remarks>
		/// Resets the Matcher. A new input sequence and a new region can be
		/// specified. Results of a previous find get lost. The next attempt to find
		/// an occurrence of the Pattern in the string will start at the beginning of
		/// the region. This is the internal version of reset() to which the several
		/// public versions delegate.
		/// </remarks>
		/// <param name="input">the input sequence.</param>
		/// <param name="start">the start of the region.</param>
		/// <param name="end">the end of the region.</param>
		/// <returns>the matcher itself.</returns>
		private java.util.regex.Matcher reset(java.lang.CharSequence input, int start_1, 
			int end_1)
		{
			if (input == null)
			{
				throw new System.ArgumentException();
			}
			if (start_1 < 0 || end_1 < 0 || start_1 > input.Length || end_1 > input.Length ||
				 start_1 > end_1)
			{
				throw new System.IndexOutOfRangeException();
			}
			this.input = input.ToString();
			this._regionStart = start_1;
			this._regionEnd = end_1;
			resetForInput();
			matchFound = false;
			findPos = _regionStart;
			appendPos = 0;
			return this;
		}

		/// <summary>
		/// Sets a new pattern for the
		/// <code>Matcher</code>
		/// . Results of a previous find
		/// get lost. The next attempt to find an occurrence of the
		/// <see cref="Pattern">Pattern</see>
		/// in the string will start at the beginning of the input.
		/// </summary>
		/// <param name="pattern">
		/// the new
		/// <code>Pattern</code>
		/// .
		/// </param>
		/// <returns>
		/// the
		/// <code>Matcher</code>
		/// itself.
		/// </returns>
		public java.util.regex.Matcher usePattern(java.util.regex.Pattern pattern_1)
		{
			if (pattern_1 == null)
			{
				throw new System.ArgumentException();
			}
			this._pattern = pattern_1;
			if (address != null)
			{
				closeImpl(address);
				address = null;
			}
			address = openImpl(pattern_1.address);
			if (input != null)
			{
				resetForInput();
			}
			matchOffsets = new int[(groupCount() + 1) * 2];
			matchFound = false;
			return this;
		}

		private void resetForInput()
		{
			setInputImpl(address, input, _regionStart, _regionEnd);
			useAnchoringBoundsImpl(address, anchoringBounds);
			useTransparentBoundsImpl(address, transparentBounds);
		}

		/// <summary>Resets this matcher and sets a region.</summary>
		/// <remarks>
		/// Resets this matcher and sets a region. Only characters inside the region
		/// are considered for a match.
		/// </remarks>
		/// <param name="start">the first character of the region.</param>
		/// <param name="end">the first character after the end of the region.</param>
		/// <returns>
		/// the
		/// <code>Matcher</code>
		/// itself.
		/// </returns>
		public java.util.regex.Matcher region(int start_1, int end_1)
		{
			return reset(java.lang.CharSequenceProxy.Wrap(input), start_1, end_1);
		}

		/// <summary>
		/// Appends the (unmatched) remainder of the input to the given
		/// <see cref="java.lang.StringBuffer">java.lang.StringBuffer</see>
		/// . The method can be used in conjunction with
		/// <see cref="find()">find()</see>
		/// and
		/// <see cref="appendReplacement(java.lang.StringBuffer, string)">appendReplacement(java.lang.StringBuffer, string)
		/// 	</see>
		/// to
		/// walk through the input and replace all matches of the
		/// <code>Pattern</code>
		/// with something else.
		/// </summary>
		/// <param name="buffer">
		/// the
		/// <code>StringBuffer</code>
		/// to append to.
		/// </param>
		/// <returns>
		/// the
		/// <code>StringBuffer</code>
		/// .
		/// </returns>
		/// <exception cref="System.InvalidOperationException">if no successful match has been made.
		/// 	</exception>
		public java.lang.StringBuffer appendTail(java.lang.StringBuffer buffer)
		{
			if (appendPos < _regionEnd)
			{
				buffer.append(Sharpen.StringHelper.Substring(input, appendPos, _regionEnd));
			}
			return buffer;
		}

		/// <summary>
		/// Replaces the first occurrence of this matcher's pattern in the input with
		/// a given string.
		/// </summary>
		/// <remarks>
		/// Replaces the first occurrence of this matcher's pattern in the input with
		/// a given string.
		/// </remarks>
		/// <param name="replacement">the replacement text.</param>
		/// <returns>the modified input string.</returns>
		public string replaceFirst(string replacement)
		{
			reset();
			java.lang.StringBuffer buffer = new java.lang.StringBuffer(input.Length);
			if (find())
			{
				appendReplacement(buffer, replacement);
			}
			return appendTail(buffer).ToString();
		}

		/// <summary>
		/// Replaces all occurrences of this matcher's pattern in the input with a
		/// given string.
		/// </summary>
		/// <remarks>
		/// Replaces all occurrences of this matcher's pattern in the input with a
		/// given string.
		/// </remarks>
		/// <param name="replacement">the replacement text.</param>
		/// <returns>the modified input string.</returns>
		public string replaceAll(string replacement)
		{
			reset();
			java.lang.StringBuffer buffer = new java.lang.StringBuffer(input.Length);
			while (find())
			{
				appendReplacement(buffer, replacement);
			}
			return appendTail(buffer).ToString();
		}

		/// <summary>
		/// Returns the
		/// <see cref="Pattern">Pattern</see>
		/// instance used inside this matcher.
		/// </summary>
		/// <returns>
		/// the
		/// <code>Pattern</code>
		/// instance.
		/// </returns>
		public java.util.regex.Pattern pattern()
		{
			return _pattern;
		}

		/// <summary>Returns the text that matched a given group of the regular expression.</summary>
		/// <remarks>
		/// Returns the text that matched a given group of the regular expression.
		/// Explicit capturing groups in the pattern are numbered left to right in order
		/// of their <i>opening</i> parenthesis, starting at 1.
		/// The special group 0 represents the entire match (as if the entire pattern is surrounded
		/// by an implicit capturing group).
		/// For example, "a((b)c)" matching "abc" would give the following groups:
		/// <pre>
		/// 0 "abc"
		/// 1 "bc"
		/// 2 "b"
		/// </pre>
		/// <p>An optional capturing group that failed to match as part of an overall
		/// successful match (for example, "a(b)?c" matching "ac") returns null.
		/// A capturing group that matched the empty string (for example, "a(b?)c" matching "ac")
		/// returns the empty string.
		/// </remarks>
		/// <exception cref="System.InvalidOperationException">if no successful match has been made.
		/// 	</exception>
		[Sharpen.ImplementsInterface(@"java.util.regex.MatchResult")]
		public string group(int group_1)
		{
			ensureMatch();
			int from = matchOffsets[group_1 * 2];
			int to = matchOffsets[(group_1 * 2) + 1];
			if (from == -1 || to == -1)
			{
				return null;
			}
			else
			{
				return Sharpen.StringHelper.Substring(input, from, to);
			}
		}

		/// <summary>Returns the text that matched the whole regular expression.</summary>
		/// <remarks>Returns the text that matched the whole regular expression.</remarks>
		/// <returns>the text.</returns>
		/// <exception cref="System.InvalidOperationException">if no successful match has been made.
		/// 	</exception>
		[Sharpen.ImplementsInterface(@"java.util.regex.MatchResult")]
		public string group()
		{
			return group(0);
		}

		/// <summary>
		/// Returns the next occurrence of the
		/// <see cref="Pattern">Pattern</see>
		/// in the input. The
		/// method starts the search from the given character in the input.
		/// </summary>
		/// <param name="start">
		/// The index in the input at which the find operation is to
		/// begin. If this is less than the start of the region, it is
		/// automatically adjusted to that value. If it is beyond the end
		/// of the region, the method will fail.
		/// </param>
		/// <returns>true if (and only if) a match has been found.</returns>
		public bool find(int start_1)
		{
			findPos = start_1;
			if (findPos < _regionStart)
			{
				findPos = _regionStart;
			}
			else
			{
				if (findPos >= _regionEnd)
				{
					matchFound = false;
					return false;
				}
			}
			matchFound = findImpl(address, input, findPos, matchOffsets);
			if (matchFound)
			{
				findPos = matchOffsets[1];
			}
			return matchFound;
		}

		/// <summary>
		/// Returns the next occurrence of the
		/// <see cref="Pattern">Pattern</see>
		/// in the input. If a
		/// previous match was successful, the method continues the search from the
		/// first character following that match in the input. Otherwise it searches
		/// either from the region start (if one has been set), or from position 0.
		/// </summary>
		/// <returns>true if (and only if) a match has been found.</returns>
		public bool find()
		{
			matchFound = findNextImpl(address, input, matchOffsets);
			if (matchFound)
			{
				findPos = matchOffsets[1];
			}
			return matchFound;
		}

		/// <summary>
		/// Tries to match the
		/// <see cref="Pattern">Pattern</see>
		/// , starting from the beginning of the
		/// region (or the beginning of the input, if no region has been set).
		/// Doesn't require the
		/// <code>Pattern</code>
		/// to match against the whole region.
		/// </summary>
		/// <returns>
		/// true if (and only if) the
		/// <code>Pattern</code>
		/// matches.
		/// </returns>
		public bool lookingAt()
		{
			matchFound = lookingAtImpl(address, input, matchOffsets);
			if (matchFound)
			{
				findPos = matchOffsets[1];
			}
			return matchFound;
		}

		/// <summary>
		/// Tries to match the
		/// <see cref="Pattern">Pattern</see>
		/// against the entire region (or the
		/// entire input, if no region has been set).
		/// </summary>
		/// <returns>
		/// true if (and only if) the
		/// <code>Pattern</code>
		/// matches the entire
		/// region.
		/// </returns>
		public bool matches()
		{
			matchFound = matchesImpl(address, input, matchOffsets);
			if (matchFound)
			{
				findPos = matchOffsets[1];
			}
			return matchFound;
		}

		/// <summary>
		/// Returns the index of the first character of the text that matched a given
		/// group.
		/// </summary>
		/// <remarks>
		/// Returns the index of the first character of the text that matched a given
		/// group.
		/// </remarks>
		/// <param name="group">
		/// the group, ranging from 0 to groupCount() - 1, with 0
		/// representing the whole pattern.
		/// </param>
		/// <returns>the character index.</returns>
		/// <exception cref="System.InvalidOperationException">if no successful match has been made.
		/// 	</exception>
		[Sharpen.ImplementsInterface(@"java.util.regex.MatchResult")]
		public int start(int group_1)
		{
			ensureMatch();
			return matchOffsets[group_1 * 2];
		}

		/// <summary>
		/// Returns the index of the first character following the text that matched
		/// a given group.
		/// </summary>
		/// <remarks>
		/// Returns the index of the first character following the text that matched
		/// a given group.
		/// </remarks>
		/// <param name="group">
		/// the group, ranging from 0 to groupCount() - 1, with 0
		/// representing the whole pattern.
		/// </param>
		/// <returns>the character index.</returns>
		/// <exception cref="System.InvalidOperationException">if no successful match has been made.
		/// 	</exception>
		[Sharpen.ImplementsInterface(@"java.util.regex.MatchResult")]
		public int end(int group_1)
		{
			ensureMatch();
			return matchOffsets[(group_1 * 2) + 1];
		}

		/// <summary>
		/// Returns a replacement string for the given one that has all backslashes
		/// and dollar signs escaped.
		/// </summary>
		/// <remarks>
		/// Returns a replacement string for the given one that has all backslashes
		/// and dollar signs escaped.
		/// </remarks>
		/// <param name="s">the input string.</param>
		/// <returns>
		/// the input string, with all backslashes and dollar signs having
		/// been escaped.
		/// </returns>
		public static string quoteReplacement(string s)
		{
			java.lang.StringBuilder result = new java.lang.StringBuilder(s.Length);
			{
				for (int i = 0; i < s.Length; i++)
				{
					char c = s[i];
					if (c == '\\' || c == '$')
					{
						result.append('\\');
					}
					result.append(c);
				}
			}
			return result.ToString();
		}

		/// <summary>
		/// Returns the index of the first character of the text that matched the
		/// whole regular expression.
		/// </summary>
		/// <remarks>
		/// Returns the index of the first character of the text that matched the
		/// whole regular expression.
		/// </remarks>
		/// <returns>the character index.</returns>
		/// <exception cref="System.InvalidOperationException">if no successful match has been made.
		/// 	</exception>
		[Sharpen.ImplementsInterface(@"java.util.regex.MatchResult")]
		public int start()
		{
			return start(0);
		}

		/// <summary>
		/// Returns the number of groups in the results, which is always equal to
		/// the number of groups in the original regular expression.
		/// </summary>
		/// <remarks>
		/// Returns the number of groups in the results, which is always equal to
		/// the number of groups in the original regular expression.
		/// </remarks>
		/// <returns>the number of groups.</returns>
		[Sharpen.ImplementsInterface(@"java.util.regex.MatchResult")]
		public int groupCount()
		{
			return groupCountImpl(address);
		}

		/// <summary>
		/// Returns the index of the first character following the text that matched
		/// the whole regular expression.
		/// </summary>
		/// <remarks>
		/// Returns the index of the first character following the text that matched
		/// the whole regular expression.
		/// </remarks>
		/// <returns>the character index.</returns>
		/// <exception cref="System.InvalidOperationException">if no successful match has been made.
		/// 	</exception>
		[Sharpen.ImplementsInterface(@"java.util.regex.MatchResult")]
		public int end()
		{
			return end(0);
		}

		/// <summary>
		/// Converts the current match into a separate
		/// <see cref="MatchResult">MatchResult</see>
		/// instance
		/// that is independent from this matcher. The new object is unaffected when
		/// the state of this matcher changes.
		/// </summary>
		/// <returns>
		/// the new
		/// <code>MatchResult</code>
		/// .
		/// </returns>
		/// <exception cref="System.InvalidOperationException">if no successful match has been made.
		/// 	</exception>
		public java.util.regex.MatchResult toMatchResult()
		{
			ensureMatch();
			return new java.util.regex.MatchResultImpl(input, matchOffsets);
		}

		/// <summary>Determines whether this matcher has anchoring bounds enabled or not.</summary>
		/// <remarks>
		/// Determines whether this matcher has anchoring bounds enabled or not. When
		/// anchoring bounds are enabled, the start and end of the input match the
		/// '^' and '$' meta-characters, otherwise not. Anchoring bounds are enabled
		/// by default.
		/// </remarks>
		/// <param name="value">the new value for anchoring bounds.</param>
		/// <returns>
		/// the
		/// <code>Matcher</code>
		/// itself.
		/// </returns>
		public java.util.regex.Matcher useAnchoringBounds(bool value)
		{
			anchoringBounds = value;
			useAnchoringBoundsImpl(address, value);
			return this;
		}

		/// <summary>Indicates whether this matcher has anchoring bounds enabled.</summary>
		/// <remarks>
		/// Indicates whether this matcher has anchoring bounds enabled. When
		/// anchoring bounds are enabled, the start and end of the input match the
		/// '^' and '$' meta-characters, otherwise not. Anchoring bounds are enabled
		/// by default.
		/// </remarks>
		/// <returns>
		/// true if (and only if) the
		/// <code>Matcher</code>
		/// uses anchoring bounds.
		/// </returns>
		public bool hasAnchoringBounds()
		{
			return anchoringBounds;
		}

		/// <summary>Determines whether this matcher has transparent bounds enabled or not.</summary>
		/// <remarks>
		/// Determines whether this matcher has transparent bounds enabled or not.
		/// When transparent bounds are enabled, the parts of the input outside the
		/// region are subject to lookahead and lookbehind, otherwise they are not.
		/// Transparent bounds are disabled by default.
		/// </remarks>
		/// <param name="value">the new value for transparent bounds.</param>
		/// <returns>
		/// the
		/// <code>Matcher</code>
		/// itself.
		/// </returns>
		public java.util.regex.Matcher useTransparentBounds(bool value)
		{
			transparentBounds = value;
			useTransparentBoundsImpl(address, value);
			return this;
		}

		/// <summary>Makes sure that a successful match has been made.</summary>
		/// <remarks>
		/// Makes sure that a successful match has been made. Is invoked internally
		/// from various places in the class.
		/// </remarks>
		/// <exception cref="System.InvalidOperationException">if no successful match has been made.
		/// 	</exception>
		private void ensureMatch()
		{
			if (!matchFound)
			{
				throw new System.InvalidOperationException("No successful match so far");
			}
		}

		/// <summary>Indicates whether this matcher has transparent bounds enabled.</summary>
		/// <remarks>
		/// Indicates whether this matcher has transparent bounds enabled. When
		/// transparent bounds are enabled, the parts of the input outside the region
		/// are subject to lookahead and lookbehind, otherwise they are not.
		/// Transparent bounds are disabled by default.
		/// </remarks>
		/// <returns>
		/// true if (and only if) the
		/// <code>Matcher</code>
		/// uses anchoring bounds.
		/// </returns>
		public bool hasTransparentBounds()
		{
			return transparentBounds;
		}

		/// <summary>
		/// Returns this matcher's region start, that is, the first character that is
		/// considered for a match.
		/// </summary>
		/// <remarks>
		/// Returns this matcher's region start, that is, the first character that is
		/// considered for a match.
		/// </remarks>
		/// <returns>the start of the region.</returns>
		public int regionStart()
		{
			return _regionStart;
		}

		/// <summary>
		/// Returns this matcher's region end, that is, the first character that is
		/// not considered for a match.
		/// </summary>
		/// <remarks>
		/// Returns this matcher's region end, that is, the first character that is
		/// not considered for a match.
		/// </remarks>
		/// <returns>the end of the region.</returns>
		public int regionEnd()
		{
			return _regionEnd;
		}

		/// <summary>
		/// Indicates whether more input might change a successful match into an
		/// unsuccessful one.
		/// </summary>
		/// <remarks>
		/// Indicates whether more input might change a successful match into an
		/// unsuccessful one.
		/// </remarks>
		/// <returns>
		/// true if (and only if) more input might change a successful match
		/// into an unsuccessful one.
		/// </returns>
		public bool requireEnd()
		{
			return requireEndImpl(address);
		}

		/// <summary>Indicates whether the last match hit the end of the input.</summary>
		/// <remarks>Indicates whether the last match hit the end of the input.</remarks>
		/// <returns>true if (and only if) the last match hit the end of the input.</returns>
		public bool hitEnd()
		{
			return hitEndImpl(address);
		}

		~Matcher()
		{
			try
			{
				closeImpl(address);
			}
			finally
			{
				;
			}
		}

		private static void closeImpl(java.util.regex.Matcher.NativeRegexMatcher addr)
		{
			addr.Dispose();
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Matcher_find(java.util.regex.Matcher.NativeRegexMatcher
			 addr, System.IntPtr s, int startIndex, System.IntPtr offsets);

		private static bool findImpl(java.util.regex.Matcher.NativeRegexMatcher addr, string
			 s, int startIndex, int[] offsets)
		{
			System.IntPtr s_ptr = System.IntPtr.Zero;
			Sharpen.INativeHandle offsets_handle = null;
			try
			{
				s_ptr = XobotOS.Runtime.MarshalGlue.String_Helper.ManagedToNative(s);
				offsets_handle = XobotOS.Runtime.MarshalGlue.Array_int_Helper.GetPinnedPtr(offsets
					);
				return libxobotos_Matcher_find(addr, s_ptr, startIndex, offsets_handle != null ? 
					offsets_handle.Address : System.IntPtr.Zero);
			}
			finally
			{
				XobotOS.Runtime.MarshalGlue.String_Helper.FreeManagedPtr(s_ptr);
				if (offsets_handle != null)
				{
					offsets_handle.Free();
				}
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Matcher_findNext(java.util.regex.Matcher.NativeRegexMatcher
			 addr, System.IntPtr s, System.IntPtr offsets);

		private static bool findNextImpl(java.util.regex.Matcher.NativeRegexMatcher addr, 
			string s, int[] offsets)
		{
			System.IntPtr s_ptr = System.IntPtr.Zero;
			Sharpen.INativeHandle offsets_handle = null;
			try
			{
				s_ptr = XobotOS.Runtime.MarshalGlue.String_Helper.ManagedToNative(s);
				offsets_handle = XobotOS.Runtime.MarshalGlue.Array_int_Helper.GetPinnedPtr(offsets
					);
				return libxobotos_Matcher_findNext(addr, s_ptr, offsets_handle != null ? offsets_handle
					.Address : System.IntPtr.Zero);
			}
			finally
			{
				XobotOS.Runtime.MarshalGlue.String_Helper.FreeManagedPtr(s_ptr);
				if (offsets_handle != null)
				{
					offsets_handle.Free();
				}
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_Matcher_groupCount(java.util.regex.Matcher.NativeRegexMatcher
			 addr);

		private static int groupCountImpl(java.util.regex.Matcher.NativeRegexMatcher addr
			)
		{
			return libxobotos_Matcher_groupCount(addr);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Matcher_hitEnd(java.util.regex.Matcher.NativeRegexMatcher
			 addr);

		private static bool hitEndImpl(java.util.regex.Matcher.NativeRegexMatcher addr)
		{
			return libxobotos_Matcher_hitEnd(addr);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Matcher_lookingAt(java.util.regex.Matcher.NativeRegexMatcher
			 addr, System.IntPtr s, System.IntPtr offsets);

		private static bool lookingAtImpl(java.util.regex.Matcher.NativeRegexMatcher addr
			, string s, int[] offsets)
		{
			System.IntPtr s_ptr = System.IntPtr.Zero;
			Sharpen.INativeHandle offsets_handle = null;
			try
			{
				s_ptr = XobotOS.Runtime.MarshalGlue.String_Helper.ManagedToNative(s);
				offsets_handle = XobotOS.Runtime.MarshalGlue.Array_int_Helper.GetPinnedPtr(offsets
					);
				return libxobotos_Matcher_lookingAt(addr, s_ptr, offsets_handle != null ? offsets_handle
					.Address : System.IntPtr.Zero);
			}
			finally
			{
				XobotOS.Runtime.MarshalGlue.String_Helper.FreeManagedPtr(s_ptr);
				if (offsets_handle != null)
				{
					offsets_handle.Free();
				}
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Matcher_matches(java.util.regex.Matcher.NativeRegexMatcher
			 addr, System.IntPtr s, System.IntPtr offsets);

		private static bool matchesImpl(java.util.regex.Matcher.NativeRegexMatcher addr, 
			string s, int[] offsets)
		{
			System.IntPtr s_ptr = System.IntPtr.Zero;
			Sharpen.INativeHandle offsets_handle = null;
			try
			{
				s_ptr = XobotOS.Runtime.MarshalGlue.String_Helper.ManagedToNative(s);
				offsets_handle = XobotOS.Runtime.MarshalGlue.Array_int_Helper.GetPinnedPtr(offsets
					);
				return libxobotos_Matcher_matches(addr, s_ptr, offsets_handle != null ? offsets_handle
					.Address : System.IntPtr.Zero);
			}
			finally
			{
				XobotOS.Runtime.MarshalGlue.String_Helper.FreeManagedPtr(s_ptr);
				if (offsets_handle != null)
				{
					offsets_handle.Free();
				}
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern java.util.regex.Matcher.NativeRegexMatcher libxobotos_Matcher_open
			(java.util.regex.Pattern.NativeRegexPattern patternAddr);

		private static java.util.regex.Matcher.NativeRegexMatcher openImpl(java.util.regex.Pattern.NativeRegexPattern
			 patternAddr)
		{
			return libxobotos_Matcher_open(patternAddr);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Matcher_requireEnd(java.util.regex.Matcher.NativeRegexMatcher
			 addr);

		private static bool requireEndImpl(java.util.regex.Matcher.NativeRegexMatcher addr
			)
		{
			return libxobotos_Matcher_requireEnd(addr);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Matcher_setInput(java.util.regex.Matcher.NativeRegexMatcher
			 addr, System.IntPtr s, int start_1, int end_1);

		private static void setInputImpl(java.util.regex.Matcher.NativeRegexMatcher addr, 
			string s, int start_1, int end_1)
		{
			System.IntPtr s_ptr = System.IntPtr.Zero;
			try
			{
				s_ptr = XobotOS.Runtime.MarshalGlue.String_Helper.ManagedToNative(s);
				libxobotos_Matcher_setInput(addr, s_ptr, start_1, end_1);
			}
			finally
			{
				XobotOS.Runtime.MarshalGlue.String_Helper.FreeManagedPtr(s_ptr);
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Matcher_useAnchoringBounds(java.util.regex.Matcher.NativeRegexMatcher
			 addr, bool value);

		private static void useAnchoringBoundsImpl(java.util.regex.Matcher.NativeRegexMatcher
			 addr, bool value)
		{
			libxobotos_Matcher_useAnchoringBounds(addr, value);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Matcher_useTransparentBounds(java.util.regex.Matcher.NativeRegexMatcher
			 addr, bool value);

		private static void useTransparentBoundsImpl(java.util.regex.Matcher.NativeRegexMatcher
			 addr, bool value)
		{
			libxobotos_Matcher_useTransparentBounds(addr, value);
		}

		public void Dispose()
		{
			address.Dispose();
		}

		internal class NativeRegexMatcher : System.Runtime.InteropServices.SafeHandle
		{
			internal NativeRegexMatcher() : base(System.IntPtr.Zero, true)
			{
			}

			internal NativeRegexMatcher(System.IntPtr handle) : base(System.IntPtr.Zero, true
				)
			{
				this.handle = handle;
			}

			[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
				Unicode)]
			private static extern void libxobotos_java_util_regex_Matcher_destructor(System.IntPtr
				 handle);

			internal System.IntPtr Handle
			{
				get
				{
					return handle;
				}
			}

			public static readonly NativeRegexMatcher Zero = new NativeRegexMatcher();

			protected override bool ReleaseHandle()
			{
				if (handle != System.IntPtr.Zero)
				{
					libxobotos_java_util_regex_Matcher_destructor(handle);
				}
				handle = System.IntPtr.Zero;
				return true;
			}

			public override bool IsInvalid
			{
				get
				{
					return handle == System.IntPtr.Zero;
				}
			}
		}
	}
}

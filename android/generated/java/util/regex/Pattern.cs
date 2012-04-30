using System.Runtime.InteropServices;
using Sharpen;

namespace java.util.regex
{
	/// <summary>Patterns are compiled regular expressions.</summary>
	/// <remarks>
	/// Patterns are compiled regular expressions. In many cases, convenience methods such as
	/// <see cref="string.matches(string)">String.matches</see>
	/// ,
	/// <see cref="string.replaceAll(string, string)">String.replaceAll</see>
	/// and
	/// <see cref="XobotOS.Runtime.Util.SplitStringRegex(string)">String.split</see>
	/// will be preferable, but if you need to do a lot of work
	/// with the same regular expression, it may be more efficient to compile it once and reuse it.
	/// The
	/// <code>Pattern</code>
	/// class and its companion,
	/// <see cref="Matcher">Matcher</see>
	/// , also offer more functionality
	/// than the small amount exposed by
	/// <code>String</code>
	/// .
	/// <pre>
	/// // String convenience methods:
	/// boolean sawFailures = s.matches("Failures: \\d+");
	/// String farewell = s.replaceAll("Hello, (\\S+)", "Goodbye, $1");
	/// String[] fields = s.split(":");
	/// // Direct use of Pattern:
	/// Pattern p = Pattern.compile("Hello, (\\S+)");
	/// Matcher m = p.matcher(inputString);
	/// while (m.find()) { // Find each match in turn; String can't do this.
	/// String name = m.group(1); // Access a submatch group; String can't do this.
	/// }
	/// </pre>
	/// <h3>Regular expression syntax</h3>
	/// <span class="datatable">
	/// <style type="text/css">
	/// .datatable td { padding-right: 20px; }
	/// </style>
	/// <p>Java supports a subset of Perl 5 regular expression syntax. An important gotcha is that Java
	/// has no regular expression literals, and uses plain old string literals instead. This means that
	/// you need an extra level of escaping. For example, the regular expression
	/// <code>\s+</code>
	/// has to
	/// be represented as the string
	/// <code>"\\s+"</code>
	/// .
	/// <h3>Escape sequences</h3>
	/// <p><table>
	/// <tr> <td> \ </td> <td>Quote the following metacharacter (so
	/// <code>\.</code>
	/// matches a literal
	/// <code>.</code>
	/// ).</td> </tr>
	/// <tr> <td> \Q </td> <td>Quote all following metacharacters until
	/// <code>\E</code>
	/// .</td> </tr>
	/// <tr> <td> \E </td> <td>Stop quoting metacharacters (started by
	/// <code>\Q</code>
	/// ).</td> </tr>
	/// <tr> <td> \\ </td> <td>A literal backslash.</td> </tr>
	/// <tr> <td> &#x005c;u<i>hhhh</i> </td> <td>The Unicode character U+hhhh (in hex).</td> </tr>
	/// <tr> <td> &#x005c;x<i>hh</i> </td> <td>The Unicode character U+00hh (in hex).</td> </tr>
	/// <tr> <td> \c<i>x</i> </td> <td>The ASCII control character ^x (so
	/// <code>\cH</code>
	/// would be ^H, U+0008).</td> </tr>
	/// <tr> <td> \a </td> <td>The ASCII bell character (U+0007).</td> </tr>
	/// <tr> <td> \e </td> <td>The ASCII ESC character (U+001b).</td> </tr>
	/// <tr> <td> \f </td> <td>The ASCII form feed character (U+000c).</td> </tr>
	/// <tr> <td> \n </td> <td>The ASCII newline character (U+000a).</td> </tr>
	/// <tr> <td> \r </td> <td>The ASCII carriage return character (U+000d).</td> </tr>
	/// <tr> <td> \t </td> <td>The ASCII tab character (U+0009).</td> </tr>
	/// </table>
	/// <h3>Character classes</h3>
	/// <p>It's possible to construct arbitrary character classes using set operations:
	/// <table>
	/// <tr> <td> [abc] </td> <td>Any one of
	/// <code>a</code>
	/// ,
	/// <code>b</code>
	/// , or
	/// <code>c</code>
	/// . (Enumeration.)</td> </tr>
	/// <tr> <td> [a-c] </td> <td>Any one of
	/// <code>a</code>
	/// ,
	/// <code>b</code>
	/// , or
	/// <code>c</code>
	/// . (Range.)</td> </tr>
	/// <tr> <td> [^abc] </td> <td>Any character <i>except</i>
	/// <code>a</code>
	/// ,
	/// <code>b</code>
	/// , or
	/// <code>c</code>
	/// . (Negation.)</td> </tr>
	/// <tr> <td> [[a-f][0-9]] </td> <td>Any character in either range. (Union.)</td> </tr>
	/// <tr> <td> [[a-z]&&[jkl]] </td> <td>Any character in both ranges. (Intersection.)</td> </tr>
	/// </table>
	/// <p>Most of the time, the built-in character classes are more useful:
	/// <table>
	/// <tr> <td> \d </td> <td>Any digit character.</td> </tr>
	/// <tr> <td> \D </td> <td>Any non-digit character.</td> </tr>
	/// <tr> <td> \s </td> <td>Any whitespace character.</td> </tr>
	/// <tr> <td> \S </td> <td>Any non-whitespace character.</td> </tr>
	/// <tr> <td> \w </td> <td>Any word character.</td> </tr>
	/// <tr> <td> \W </td> <td>Any non-word character.</td> </tr>
	/// <tr> <td> \p{<i>NAME</i>} </td> <td> Any character in the class with the given <i>NAME</i>. </td> </tr>
	/// <tr> <td> \P{<i>NAME</i>} </td> <td> Any character <i>not</i> in the named class. </td> </tr>
	/// </table>
	/// <p>There are a variety of named classes:
	/// <ul>
	/// <li><a href="../../lang/Character.html#unicode_categories">Unicode category names</a>,
	/// prefixed by
	/// <code>Is</code>
	/// . For example
	/// <code></code>
	/// \p
	/// IsLu}} for all uppercase letters.
	/// <li>POSIX class names. These are 'Alnum', 'Alpha', 'ASCII', 'Blank', 'Cntrl', 'Digit',
	/// 'Graph', 'Lower', 'Print', 'Punct', 'Upper', 'XDigit'.
	/// <li>Unicode block names, as used by
	/// <see cref="java.lang.Character.UnicodeBlock.forName(string)">java.lang.Character.UnicodeBlock.forName(string)
	/// 	</see>
	/// prefixed
	/// by
	/// <code>In</code>
	/// . For example
	/// <code></code>
	/// \p
	/// InHebrew}} for all characters in the Hebrew block.
	/// <li>Character method names. These are all non-deprecated methods from
	/// <see cref="char">char</see>
	/// whose name starts with
	/// <code>is</code>
	/// , but with the
	/// <code>is</code>
	/// replaced by
	/// <code>java</code>
	/// .
	/// For example,
	/// <code></code>
	/// \p
	/// javaLowerCase}}.
	/// </ul>
	/// <h3>Quantifiers</h3>
	/// <p>Quantifiers match some number of instances of the preceding regular expression.
	/// <table>
	/// <tr> <td> * </td> <td>Zero or more.</td> </tr>
	/// <tr> <td> ? </td> <td>Zero or one.</td> </tr>
	/// <tr> <td> + </td> <td>One or more.</td> </tr>
	/// <tr> <td> {<i>n</i>} </td> <td>Exactly <i>n</i>.</td> </tr>
	/// <tr> <td> {<i>n,</i>} </td> <td>At least <i>n</i>.</td> </tr>
	/// <tr> <td> {<i>n</i>,<i>m</i>} </td> <td>At least <i>n</i> but not more than <i>m</i>.</td> </tr>
	/// </table>
	/// <p>Quantifiers are "greedy" by default, meaning that they will match the longest possible input
	/// sequence. There are also non-greedy quantifiers that match the shortest possible input sequence.
	/// They're same as the greedy ones but with a trailing
	/// <code>?</code>
	/// :
	/// <table>
	/// <tr> <td> *? </td> <td>Zero or more (non-greedy).</td> </tr>
	/// <tr> <td> ?? </td> <td>Zero or one (non-greedy).</td> </tr>
	/// <tr> <td> +? </td> <td>One or more (non-greedy).</td> </tr>
	/// <tr> <td> {<i>n</i>}? </td> <td>Exactly <i>n</i> (non-greedy).</td> </tr>
	/// <tr> <td> {<i>n,</i>}? </td> <td>At least <i>n</i> (non-greedy).</td> </tr>
	/// <tr> <td> {<i>n</i>,<i>m</i>}? </td> <td>At least <i>n</i> but not more than <i>m</i> (non-greedy).</td> </tr>
	/// </table>
	/// <p>Quantifiers allow backtracking by default. There are also possessive quantifiers to prevent
	/// backtracking. They're same as the greedy ones but with a trailing
	/// <code>+</code>
	/// :
	/// <table>
	/// <tr> <td> *+ </td> <td>Zero or more (possessive).</td> </tr>
	/// <tr> <td> ?+ </td> <td>Zero or one (possessive).</td> </tr>
	/// <tr> <td> ++ </td> <td>One or more (possessive).</td> </tr>
	/// <tr> <td> {<i>n</i>}+ </td> <td>Exactly <i>n</i> (possessive).</td> </tr>
	/// <tr> <td> {<i>n,</i>}+ </td> <td>At least <i>n</i> (possessive).</td> </tr>
	/// <tr> <td> {<i>n</i>,<i>m</i>}+ </td> <td>At least <i>n</i> but not more than <i>m</i> (possessive).</td> </tr>
	/// </table>
	/// <h3>Zero-width assertions</h3>
	/// <p><table>
	/// <tr> <td> ^ </td> <td>At beginning of line.</td> </tr>
	/// <tr> <td> $ </td> <td>At end of line.</td> </tr>
	/// <tr> <td> \A </td> <td>At beginning of input.</td> </tr>
	/// <tr> <td> \b </td> <td>At word boundary.</td> </tr>
	/// <tr> <td> \B </td> <td>At non-word boundary.</td> </tr>
	/// <tr> <td> \G </td> <td>At end of previous match.</td> </tr>
	/// <tr> <td> \z </td> <td>At end of input.</td> </tr>
	/// <tr> <td> \Z </td> <td>At end of input, or before newline at end.</td> </tr>
	/// </table>
	/// <h3>Look-around assertions</h3>
	/// <p>Look-around assertions assert that the subpattern does (positive) or doesn't (negative) match
	/// after (look-ahead) or before (look-behind) the current position, without including the matched
	/// text in the containing match. The maximum length of possible matches for look-behind patterns
	/// must not be unbounded.
	/// <p><table>
	/// <tr> <td> (?=<i>a</i>) </td> <td>Zero-width positive look-ahead.</td> </tr>
	/// <tr> <td> (?!<i>a</i>) </td> <td>Zero-width negative look-ahead.</td> </tr>
	/// <tr> <td> (?&lt;=<i>a</i>) </td> <td>Zero-width positive look-behind.</td> </tr>
	/// <tr> <td> (?&lt;!<i>a</i>) </td> <td>Zero-width negative look-behind.</td> </tr>
	/// </table>
	/// <h3>Groups</h3>
	/// <p><table>
	/// <tr> <td> (<i>a</i>) </td> <td>A capturing group.</td> </tr>
	/// <tr> <td> (?:<i>a</i>) </td> <td>A non-capturing group.</td> </tr>
	/// <tr> <td> (?&gt;<i>a</i>) </td> <td>An independent non-capturing group. (The first match of the subgroup is the only match tried.)</td> </tr>
	/// <tr> <td> \<i>n</i> </td> <td>The text already matched by capturing group <i>n</i>.</td> </tr>
	/// </table>
	/// <p>See
	/// <see cref="Matcher.group()">Matcher.group()</see>
	/// for details of how capturing groups are numbered and accessed.
	/// <h3>Operators</h3>
	/// <p><table>
	/// <tr> <td> <i>ab</i> </td> <td>Expression <i>a</i> followed by expression <i>b</i>.</td> </tr>
	/// <tr> <td> <i>a</i>|<i>b</i> </td> <td>Either expression <i>a</i> or expression <i>b</i>.</td> </tr>
	/// </table>
	/// <a name="flags"><h3>Flags</h3></a>
	/// <p><table>
	/// <tr> <td> (?dimsux-dimsux:<i>a</i>) </td> <td>Evaluates the expression <i>a</i> with the given flags enabled/disabled.</td> </tr>
	/// <tr> <td> (?dimsux-dimsux) </td> <td>Evaluates the rest of the pattern with the given flags enabled/disabled.</td> </tr>
	/// </table>
	/// <p>The flags are:
	/// <table>
	/// <tr><td>
	/// <code>i</code>
	/// </td> <td>
	/// <see cref="CASE_INSENSITIVE">CASE_INSENSITIVE</see>
	/// </td> <td>case insensitive matching</td></tr>
	/// <tr><td>
	/// <code>d</code>
	/// </td> <td>
	/// <see cref="UNIX_LINES">UNIX_LINES</see>
	/// </td>       <td>only accept
	/// <code>'\n'</code>
	/// as a line terminator</td></tr>
	/// <tr><td>
	/// <code>m</code>
	/// </td> <td>
	/// <see cref="MULTILINE">MULTILINE</see>
	/// </td>        <td>allow
	/// <code>^</code>
	/// and
	/// <code>$</code>
	/// to match beginning/end of any line</td></tr>
	/// <tr><td>
	/// <code>s</code>
	/// </td> <td>
	/// <see cref="DOTALL">DOTALL</see>
	/// </td>           <td>allow
	/// <code>.</code>
	/// to match
	/// <code>'\n'</code>
	/// ("s" for "single line")</td></tr>
	/// <tr><td>
	/// <code>u</code>
	/// </td> <td>
	/// <see cref="UNICODE_CASE">UNICODE_CASE</see>
	/// </td>     <td>enable Unicode case folding</td></tr>
	/// <tr><td>
	/// <code>x</code>
	/// </td> <td>
	/// <see cref="COMMENTS">COMMENTS</see>
	/// </td>         <td>allow whitespace and comments</td></tr>
	/// </table>
	/// <p>Either set of flags may be empty. For example,
	/// <code>(?i-m)</code>
	/// would turn on case-insensitivity
	/// and turn off multiline mode,
	/// <code>(?i)</code>
	/// would just turn on case-insensitivity,
	/// and
	/// <code>(?-m)</code>
	/// would just turn off multiline mode.
	/// <p>Note that on Android,
	/// <code>UNICODE_CASE</code>
	/// is always on: case-insensitive matching will
	/// always be Unicode-aware.
	/// <p>There are two other flags not settable via this mechanism:
	/// <see cref="CANON_EQ">CANON_EQ</see>
	/// and
	/// <see cref="LITERAL">LITERAL</see>
	/// . Attempts to use
	/// <see cref="CANON_EQ">CANON_EQ</see>
	/// on Android will throw an exception.
	/// </span>
	/// <h3>Implementation notes</h3>
	/// <p>The regular expression implementation used in Android is provided by
	/// <a href="http://www.icu-project.org">ICU</a>. The notation for the regular
	/// expressions is mostly a superset of those used in other Java language
	/// implementations. This means that existing applications will normally work as
	/// expected, but in rare cases Android may accept a regular expression that is
	/// not accepted by other implementations.
	/// <p>In some cases, Android will recognize that a regular expression is a simple
	/// special case that can be handled more efficiently. This is true of both the convenience methods
	/// in
	/// <code>String</code>
	/// and the methods in
	/// <code>Pattern</code>
	/// .
	/// </remarks>
	/// <seealso cref="Matcher">Matcher</seealso>
	[System.Serializable]
	[Sharpen.Sharpened]
	public sealed class Pattern : System.IDisposable
	{
		internal const long serialVersionUID = 5073258162644648461L;

		/// <summary>
		/// This constant specifies that a pattern matches Unix line endings ('\n')
		/// only against the '.', '^', and '$' meta characters.
		/// </summary>
		/// <remarks>
		/// This constant specifies that a pattern matches Unix line endings ('\n')
		/// only against the '.', '^', and '$' meta characters. Corresponds to
		/// <code>(?d)</code>
		/// .
		/// </remarks>
		public const int UNIX_LINES = unchecked((int)(0x01));

		/// <summary>
		/// This constant specifies that a
		/// <code>Pattern</code>
		/// is matched
		/// case-insensitively. That is, the patterns "a+" and "A+" would both match
		/// the string "aAaAaA". See
		/// <see cref="UNICODE_CASE">UNICODE_CASE</see>
		/// . Corresponds to
		/// <code>(?i)</code>
		/// .
		/// </summary>
		public const int CASE_INSENSITIVE = unchecked((int)(0x02));

		/// <summary>
		/// This constant specifies that a
		/// <code>Pattern</code>
		/// may contain whitespace or
		/// comments. Otherwise comments and whitespace are taken as literal
		/// characters. Corresponds to
		/// <code>(?x)</code>
		/// .
		/// </summary>
		public const int COMMENTS = unchecked((int)(0x04));

		/// <summary>
		/// This constant specifies that the meta characters '^' and '$' match only
		/// the beginning and end of an input line, respectively.
		/// </summary>
		/// <remarks>
		/// This constant specifies that the meta characters '^' and '$' match only
		/// the beginning and end of an input line, respectively. Normally, they
		/// match the beginning and the end of the complete input. Corresponds to
		/// <code>(?m)</code>
		/// .
		/// </remarks>
		public const int MULTILINE = unchecked((int)(0x08));

		/// <summary>
		/// This constant specifies that the whole
		/// <code>Pattern</code>
		/// is to be taken
		/// literally, that is, all meta characters lose their meanings.
		/// </summary>
		public const int LITERAL = unchecked((int)(0x10));

		/// <summary>
		/// This constant specifies that the '.' meta character matches arbitrary
		/// characters, including line endings, which is normally not the case.
		/// </summary>
		/// <remarks>
		/// This constant specifies that the '.' meta character matches arbitrary
		/// characters, including line endings, which is normally not the case.
		/// Corresponds to
		/// <code>(?s)</code>
		/// .
		/// </remarks>
		public const int DOTALL = unchecked((int)(0x20));

		/// <summary>
		/// This constant specifies that a
		/// <code>Pattern</code>
		/// that uses case-insensitive matching
		/// will use Unicode case folding. On Android,
		/// <code>UNICODE_CASE</code>
		/// is always on:
		/// case-insensitive matching will always be Unicode-aware. If your code is intended to
		/// be portable and uses case-insensitive matching on non-ASCII characters, you should
		/// use this flag. Corresponds to
		/// <code>(?u)</code>
		/// .
		/// </summary>
		public const int UNICODE_CASE = unchecked((int)(0x40));

		/// <summary>
		/// This constant specifies that a character in a
		/// <code>Pattern</code>
		/// and a
		/// character in the input string only match if they are canonically
		/// equivalent. It is (currently) not supported in Android.
		/// </summary>
		public const int CANON_EQ = unchecked((int)(0x80));

		private readonly string _pattern;

		private readonly int _flags;

		[System.NonSerialized]
		internal java.util.regex.Pattern.NativeRegexPattern address;

		/// <summary>
		/// Returns a
		/// <see cref="Matcher">Matcher</see>
		/// for this pattern applied to the given
		/// <code>input</code>
		/// .
		/// The
		/// <code>Matcher</code>
		/// can be used to match the
		/// <code>Pattern</code>
		/// against the
		/// whole input, find occurrences of the
		/// <code>Pattern</code>
		/// in the input, or
		/// replace parts of the input.
		/// </summary>
		public java.util.regex.Matcher matcher(java.lang.CharSequence input)
		{
			return new java.util.regex.Matcher(this, input);
		}

		/// <summary>
		/// Splits the given
		/// <code>input</code>
		/// at occurrences of this pattern.
		/// <p>If this pattern does not occur in the input, the result is an
		/// array containing the input (converted from a
		/// <code>CharSequence</code>
		/// to
		/// a
		/// <code>String</code>
		/// ).
		/// <p>Otherwise, the
		/// <code>limit</code>
		/// parameter controls the contents of the
		/// returned array as described below.
		/// </summary>
		/// <param name="limit">
		/// Determines the maximum number of entries in the resulting
		/// array, and the treatment of trailing empty strings.
		/// <ul>
		/// <li>For n &gt; 0, the resulting array contains at most n
		/// entries. If this is fewer than the number of matches, the
		/// final entry will contain all remaining input.
		/// <li>For n &lt; 0, the length of the resulting array is
		/// exactly the number of occurrences of the
		/// <code>Pattern</code>
		/// plus one for the text after the final separator.
		/// All entries are included.
		/// <li>For n == 0, the result is as for n &lt; 0, except
		/// trailing empty strings will not be returned. (Note that
		/// the case where the input is itself an empty string is
		/// special, as described above, and the limit parameter does
		/// not apply there.)
		/// </ul>
		/// </param>
		public string[] split(java.lang.CharSequence input, int limit)
		{
			return java.util.regex.Splitter.split(this, _pattern, input.ToString(), limit);
		}

		/// <summary>
		/// Equivalent to
		/// <code>split(input, 0)</code>
		/// .
		/// </summary>
		public string[] split(java.lang.CharSequence input)
		{
			return split(input, 0);
		}

		/// <summary>
		/// Returns the regular expression supplied to
		/// <code>compile</code>
		/// .
		/// </summary>
		public string pattern()
		{
			return _pattern;
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			return _pattern;
		}

		/// <summary>
		/// Returns the flags supplied to
		/// <code>compile</code>
		/// .
		/// </summary>
		public int flags()
		{
			return _flags;
		}

		/// <summary>
		/// Returns a compiled form of the given
		/// <code>regularExpression</code>
		/// , as modified by the
		/// given
		/// <code>flags</code>
		/// . See the <a href="#flags">flags overview</a> for more on flags.
		/// </summary>
		/// <exception cref="PatternSyntaxException">if the regular expression is syntactically incorrect.
		/// 	</exception>
		/// <seealso cref="CANON_EQ">CANON_EQ</seealso>
		/// <seealso cref="CASE_INSENSITIVE">CASE_INSENSITIVE</seealso>
		/// <seealso cref="COMMENTS">COMMENTS</seealso>
		/// <seealso cref="DOTALL">DOTALL</seealso>
		/// <seealso cref="LITERAL">LITERAL</seealso>
		/// <seealso cref="MULTILINE">MULTILINE</seealso>
		/// <seealso cref="UNICODE_CASE">UNICODE_CASE</seealso>
		/// <seealso cref="UNIX_LINES">UNIX_LINES</seealso>
		/// <exception cref="java.util.regex.PatternSyntaxException"></exception>
		public static java.util.regex.Pattern compile(string regularExpression, int flags_1
			)
		{
			return new java.util.regex.Pattern(regularExpression, flags_1);
		}

		/// <summary>
		/// Equivalent to
		/// <code>Pattern.compile(pattern, 0)</code>
		/// .
		/// </summary>
		public static java.util.regex.Pattern compile(string pattern_1)
		{
			return new java.util.regex.Pattern(pattern_1, 0);
		}

		/// <exception cref="java.util.regex.PatternSyntaxException"></exception>
		private Pattern(string pattern_1, int flags_1)
		{
			if ((flags_1 & CANON_EQ) != 0)
			{
				throw new System.NotSupportedException("CANON_EQ flag not supported");
			}
			this._pattern = pattern_1;
			this._flags = flags_1;
			compile();
		}

		/// <exception cref="java.util.regex.PatternSyntaxException"></exception>
		private void compile()
		{
			if (_pattern == null)
			{
				throw new System.ArgumentNullException("pattern == null");
			}
			string icuPattern = _pattern;
			if ((_flags & LITERAL) != 0)
			{
				icuPattern = quote(_pattern);
			}
			// These are the flags natively supported by ICU.
			// They even have the same value in native code.
			int icuFlags = _flags & (CASE_INSENSITIVE | COMMENTS | MULTILINE | DOTALL | UNIX_LINES
				);
			address = compileImpl(icuPattern, icuFlags);
		}

		/// <summary>
		/// Tests whether the given
		/// <code>regularExpression</code>
		/// matches the given
		/// <code>input</code>
		/// .
		/// Equivalent to
		/// <code>Pattern.compile(regularExpression).matcher(input).matches()</code>
		/// .
		/// If the same regular expression is to be used for multiple operations, it may be more
		/// efficient to reuse a compiled
		/// <code>Pattern</code>
		/// .
		/// </summary>
		/// <seealso cref="compile(string, int)">compile(string, int)</seealso>
		/// <seealso cref="Matcher.matches()">Matcher.matches()</seealso>
		public static bool matches(string regularExpression, java.lang.CharSequence input
			)
		{
			return new java.util.regex.Matcher(new java.util.regex.Pattern(regularExpression, 
				0), input).matches();
		}

		/// <summary>
		/// Quotes the given
		/// <code>string</code>
		/// using "\Q" and "\E", so that all
		/// meta-characters lose their special meaning. This method correctly
		/// escapes embedded instances of "\Q" or "\E". If the entire result
		/// is to be passed verbatim to
		/// <see cref="compile()">compile()</see>
		/// , it's usually clearer
		/// to use the
		/// <see cref="LITERAL">LITERAL</see>
		/// flag instead.
		/// </summary>
		public static string quote(string @string)
		{
			java.lang.StringBuilder sb = new java.lang.StringBuilder();
			sb.append("\\Q");
			int apos = 0;
			int k;
			while ((k = @string.IndexOf("\\E", apos)) >= 0)
			{
				sb.append(Sharpen.StringHelper.Substring(@string, apos, k + 2)).append("\\\\E\\Q"
					);
				apos = k + 2;
			}
			return sb.append(Sharpen.StringHelper.Substring(@string, apos)).append("\\E").ToString
				();
		}

		~Pattern()
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

		/// <exception cref="System.IO.IOException"></exception>
		/// <exception cref="java.lang.ClassNotFoundException"></exception>
		private void readObject(java.io.ObjectInputStream s)
		{
			s.defaultReadObject();
			compile();
		}

		private static void closeImpl(java.util.regex.Pattern.NativeRegexPattern addr)
		{
			addr.Dispose();
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern java.util.regex.Pattern.NativeRegexPattern libxobotos_Pattern_compile
			(System.IntPtr regex, int flags_1);

		private static java.util.regex.Pattern.NativeRegexPattern compileImpl(string regex
			, int flags_1)
		{
			System.IntPtr regex_ptr = System.IntPtr.Zero;
			try
			{
				regex_ptr = XobotOS.Runtime.MarshalGlue.String_Helper.ManagedToNative(regex);
				return libxobotos_Pattern_compile(regex_ptr, flags_1);
			}
			finally
			{
				XobotOS.Runtime.MarshalGlue.String_Helper.FreeManagedPtr(regex_ptr);
			}
		}

		public void Dispose()
		{
			address.Dispose();
		}

		internal class NativeRegexPattern : System.Runtime.InteropServices.SafeHandle
		{
			internal NativeRegexPattern() : base(System.IntPtr.Zero, true)
			{
			}

			internal NativeRegexPattern(System.IntPtr handle) : base(System.IntPtr.Zero, true
				)
			{
				this.handle = handle;
			}

			[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
				Unicode)]
			private static extern void libxobotos_java_util_regex_Pattern_destructor(System.IntPtr
				 handle);

			internal System.IntPtr Handle
			{
				get
				{
					return handle;
				}
			}

			public static readonly NativeRegexPattern Zero = new NativeRegexPattern();

			protected override bool ReleaseHandle()
			{
				if (handle != System.IntPtr.Zero)
				{
					libxobotos_java_util_regex_Pattern_destructor(handle);
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

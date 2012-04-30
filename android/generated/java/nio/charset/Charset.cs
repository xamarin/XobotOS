using Sharpen;

namespace java.nio.charset
{
	/// <summary>A charset is a named mapping between Unicode characters and byte sequences.
	/// 	</summary>
	/// <remarks>
	/// A charset is a named mapping between Unicode characters and byte sequences. Every
	/// <code>Charset</code>
	/// can <i>decode</i>, converting a byte sequence into a sequence of characters,
	/// and some can also <i>encode</i>, converting a sequence of characters into a byte sequence.
	/// Use the method
	/// <see cref="canEncode()">canEncode()</see>
	/// to find out whether a charset supports both.
	/// <h4>Characters</h4>
	/// <p>In the context of this class, <i>character</i> always refers to a Java character: a Unicode
	/// code point in the range U+0000 to U+FFFF. (Java represents supplementary characters using surrogates.)
	/// Not all byte sequences will represent a character, and not
	/// all characters can necessarily be represented by a given charset. The method
	/// <see cref="contains(Charset)">contains(Charset)</see>
	/// can be used to determine whether every character representable by one charset can also be
	/// represented by another (meaning that a lossless transformation is possible from the contained
	/// to the container).
	/// <h4>Encodings</h4>
	/// <p>There are many possible ways to represent Unicode characters as byte sequences.
	/// See <a href="http://www.unicode.org/reports/tr17/">UTR#17: Unicode Character Encoding Model</a>
	/// for detailed discussion.
	/// <p>The most important mappings capable of representing every character are the Unicode
	/// Transformation Format (UTF) charsets. Of those, UTF-8 and the UTF-16 family are the most
	/// common. UTF-8 (described in <a href="http://www.ietf.org/rfc/rfc3629.txt">RFC 3629</a>)
	/// encodes a character using 1 to 4 bytes. UTF-16 uses exactly 2 bytes per character (potentially
	/// wasting space, but allowing efficient random access into BMP text), and UTF-32 uses
	/// exactly 4 bytes per character (trading off even more space for efficient random access into text
	/// that includes supplementary characters).
	/// <p>UTF-16 and UTF-32 encode characters directly, using their code point as a two- or four-byte
	/// integer. This means that any given UTF-16 or UTF-32 byte sequence is either big- or
	/// little-endian. To assist decoders, Unicode includes a special <i>byte order mark</i> (BOM)
	/// character U+FEFF used to determine the endianness of a sequence. The corresponding byte-swapped
	/// code point U+FFFE is guaranteed never to be assigned. If a UTF-16 decoder sees
	/// <code>0xfe, 0xff</code>
	/// , for example, it knows it's reading a big-endian byte sequence, while
	/// <code>0xff, 0xfe</code>
	/// , would indicate a little-endian byte sequence.
	/// <p>UTF-8 can contain a BOM, but since the UTF-8 encoding of a character always uses the same
	/// byte sequence, there is no information about endianness to convey. Seeing the bytes
	/// corresponding to the UTF-8 encoding of U+FEFF (
	/// <code>0xef, 0xbb, 0xbf</code>
	/// ) would only serve to
	/// suggest that you're reading UTF-8. Note that BOMs are decoded as the U+FEFF character, and
	/// will appear in the output character sequence. This means that a disadvantage to including a BOM
	/// in UTF-8 is that most applications that use UTF-8 do not expect to see a BOM. (This is also a
	/// reason to prefer UTF-8: it's one less complication to worry about.)
	/// <p>Because a BOM indicates how the data that follows should be interpreted, a BOM should occur
	/// as the first character in a character sequence.
	/// <p>See the <a href="http://unicode.org/faq/utf_bom.html#BOM">Byte Order Mark (BOM) FAQ</a> for
	/// more about dealing with BOMs.
	/// <h4>Endianness and BOM behavior</h4>
	/// <p>The following tables show the endianness and BOM behavior of the UTF-16 variants.
	/// <p>This table shows what the encoder writes. "BE" means that the byte sequence is big-endian,
	/// "LE" means little-endian. "BE BOM" means a big-endian BOM (that is,
	/// <code>0xfe, 0xff</code>
	/// ).
	/// <p><table width="100%">
	/// <tr> <th>Charset</th>  <th>Encoder writes</th>  </tr>
	/// <tr> <td>UTF-16BE</td> <td>BE, no BOM</td>      </tr>
	/// <tr> <td>UTF-16LE</td> <td>LE, no BOM</td>      </tr>
	/// <tr> <td>UTF-16</td>   <td>BE, with BE BOM</td> </tr>
	/// </table>
	/// <p>The next table shows how each variant's decoder behaves when reading a byte sequence.
	/// The exact meaning of "failure" in the table is dependent on the
	/// <see cref="CodingErrorAction">CodingErrorAction</see>
	/// supplied to
	/// <see cref="CharsetDecoder.malformedInputAction()">CharsetDecoder.malformedInputAction()
	/// 	</see>
	/// , so
	/// "BE, failure" means "the byte sequence is treated as big-endian, and a little-endian BOM
	/// triggers the malformedInputAction".
	/// <p>The phrase "includes BOM" means that the output includes the U+FEFF byte order mark character.
	/// <p><table width="100%">
	/// <tr> <th>Charset</th>  <th>BE BOM</th>           <th>LE BOM</th>           <th>No BOM</th> </tr>
	/// <tr> <td>UTF-16BE</td> <td>BE, includes BOM</td> <td>BE, failure</td>      <td>BE</td>     </tr>
	/// <tr> <td>UTF-16LE</td> <td>LE, failure</td>      <td>LE, includes BOM</td> <td>LE</td>     </tr>
	/// <tr> <td>UTF-16</td>   <td>BE</td>               <td>LE</td>               <td>BE</td>     </tr>
	/// </table>
	/// <h4>Charset names</h4>
	/// <p>A charset has a canonical name, returned by
	/// <see cref="name()">name()</see>
	/// . Most charsets will
	/// also have one or more aliases, returned by
	/// <see cref="aliases()">aliases()</see>
	/// . A charset can be looked up
	/// by canonical name or any of its aliases using
	/// <see cref="forName(string)">forName(string)</see>
	/// .
	/// <h4>Guaranteed-available charsets</h4>
	/// <p>The following charsets are available on every Java implementation:
	/// <ul>
	/// <li>ISO-8859-1
	/// <li>US-ASCII
	/// <li>UTF-16
	/// <li>UTF-16BE
	/// <li>UTF-16LE
	/// <li>UTF-8
	/// </ul>
	/// <p>All of these charsets support both decoding and encoding. The charsets whose names begin
	/// "UTF" can represent all characters, as mentioned above. The "ISO-8859-1" and "US-ASCII" charsets
	/// can only represent small subsets of these characters. Except when required to do otherwise for
	/// compatibility, new code should use one of the UTF charsets listed above. The platform's default
	/// charset is UTF-8. (This is in contrast to some older implementations, where the default charset
	/// depended on the user's locale.)
	/// <p>Most implementations will support hundreds of charsets. Use
	/// <see cref="availableCharsets()">availableCharsets()</see>
	/// or
	/// <see cref="isSupported(string)">isSupported(string)</see>
	/// to see what's available. If you intend to use the charset if it's
	/// available, just call
	/// <see cref="forName(string)">forName(string)</see>
	/// and catch the exceptions it throws if the charset isn't
	/// available.
	/// <p>Additional charsets can be made available by configuring one or more charset
	/// providers through provider configuration files. Such files are always named
	/// as "java.nio.charset.spi.CharsetProvider" and located in the
	/// "META-INF/services" directory of one or more classpaths. The files should be
	/// encoded in "UTF-8". Each line of their content specifies the class name of a
	/// charset provider which extends
	/// <see cref="java.nio.charset.spi.CharsetProvider">java.nio.charset.spi.CharsetProvider
	/// 	</see>
	/// .
	/// A line should end with '\r', '\n' or '\r\n'. Leading and trailing whitespace
	/// is trimmed. Blank lines, and lines (after trimming) starting with "#" which are
	/// regarded as comments, are both ignored. Duplicates of names already found are also
	/// ignored. Both the configuration files and the provider classes will be loaded
	/// using the thread context class loader.
	/// <p>Although class is thread-safe, the
	/// <see cref="CharsetDecoder">CharsetDecoder</see>
	/// and
	/// <see cref="CharsetEncoder">CharsetEncoder</see>
	/// instances
	/// it returns are inherently stateful.
	/// </remarks>
	[Sharpen.Sharpened]
	public abstract partial class Charset : java.lang.Comparable<java.nio.charset.Charset
		>
	{
		private static readonly java.nio.charset.Charset DEFAULT_CHARSET = getDefaultCharset
			();

		private readonly string canonicalName;

		// check whether the given canonical name is legal
		// check each alias and put into a set
		private static void checkCharsetName(string name_1)
		{
			if (string.IsNullOrEmpty(name_1))
			{
				throw new java.nio.charset.IllegalCharsetNameException(name_1);
			}
			int length = name_1.Length;
			{
				for (int i = 0; i < length; ++i)
				{
					if (!isValidCharsetNameCharacter(name_1[i]))
					{
						throw new java.nio.charset.IllegalCharsetNameException(name_1);
					}
				}
			}
		}

		private static bool isValidCharsetNameCharacter(char c)
		{
			return (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || (c >= '0' && c <= '9')
				 || c == '-' || c == '.' || c == ':' || c == '_';
		}

		// Start with a copy of the built-in charsets...
		// Add all charsets provided by all charset providers...
		// A CharsetProvider can't override a built-in Charset.
		// Get the canonical name for this charset, and the canonical instance from the table.
		// Cache the charset by its canonical name...
		// And the name the user used... (Section 1.4 of http://unicode.org/reports/tr22/ means
		// that many non-alias, non-canonical names are valid. For example, "utf8" isn't an
		// alias of the canonical name "UTF-8", but we shouldn't penalize consistent users of
		// such names unduly.)
		// And all its aliases...
		// Is this charset in our cache?
		// Is this a built-in charset supported by ICU?
		// Does a configured CharsetProvider have this charset?
		/// <summary>Determines whether this charset is a superset of the given charset.</summary>
		/// <remarks>
		/// Determines whether this charset is a superset of the given charset. A charset C1 contains
		/// charset C2 if every character representable by C2 is also representable by C1. This means
		/// that lossless conversion is possible from C2 to C1 (but not necessarily the other way
		/// round). It does <i>not</i> imply that the two charsets use the same byte sequences for the
		/// characters they share.
		/// <p>Note that this method is allowed to be conservative, and some implementations may return
		/// false when this charset does contain the other charset. Android's implementation is precise,
		/// and will always return true in such cases.
		/// </remarks>
		/// <param name="charset">a given charset.</param>
		/// <returns>
		/// true if this charset is a super set of the given charset,
		/// false if it's unknown or this charset is not a superset of
		/// the given charset.
		/// </returns>
		public abstract bool contains(java.nio.charset.Charset charset);

		/// <summary>Gets a new instance of an encoder for this charset.</summary>
		/// <remarks>Gets a new instance of an encoder for this charset.</remarks>
		/// <returns>a new instance of an encoder for this charset.</returns>
		public abstract java.nio.charset.CharsetEncoder newEncoder();

		/// <summary>Gets a new instance of a decoder for this charset.</summary>
		/// <remarks>Gets a new instance of a decoder for this charset.</remarks>
		/// <returns>a new instance of a decoder for this charset.</returns>
		public abstract java.nio.charset.CharsetDecoder newDecoder();

		/// <summary>Gets the canonical name of this charset.</summary>
		/// <remarks>Gets the canonical name of this charset.</remarks>
		/// <returns>this charset's name in canonical form.</returns>
		public string name()
		{
			return this.canonicalName;
		}

		[Sharpen.Stub]
		public java.util.Set<string> aliases()
		{
			throw new System.NotImplementedException();
		}

		/// <summary>Gets the name of this charset for the default locale.</summary>
		/// <remarks>
		/// Gets the name of this charset for the default locale.
		/// <p>The default implementation returns the canonical name of this charset.
		/// Subclasses may return a localized display name.
		/// </remarks>
		/// <returns>the name of this charset for the default locale.</returns>
		public virtual string displayName()
		{
			return this.canonicalName;
		}

		/// <summary>Gets the name of this charset for the specified locale.</summary>
		/// <remarks>
		/// Gets the name of this charset for the specified locale.
		/// <p>The default implementation returns the canonical name of this charset.
		/// Subclasses may return a localized display name.
		/// </remarks>
		/// <param name="l">a certain locale</param>
		/// <returns>the name of this charset for the specified locale</returns>
		public virtual string displayName(System.Globalization.CultureInfo l)
		{
			return this.canonicalName;
		}

		/// <summary>
		/// Indicates whether this charset is known to be registered in the IANA
		/// Charset Registry.
		/// </summary>
		/// <remarks>
		/// Indicates whether this charset is known to be registered in the IANA
		/// Charset Registry.
		/// </remarks>
		/// <returns>
		/// true if the charset is known to be registered, otherwise returns
		/// false.
		/// </returns>
		public bool isRegistered()
		{
			return !canonicalName.StartsWith("x-") && !canonicalName.StartsWith("X-");
		}

		/// <summary>Returns true if this charset supports encoding, false otherwise.</summary>
		/// <remarks>Returns true if this charset supports encoding, false otherwise.</remarks>
		/// <returns>true if this charset supports encoding, false otherwise.</returns>
		public virtual bool canEncode()
		{
			return true;
		}

		/// <summary>
		/// Returns a new
		/// <code>ByteBuffer</code>
		/// containing the bytes encoding the characters from
		/// <code>buffer</code>
		/// .
		/// This method uses
		/// <code>CodingErrorAction.REPLACE</code>
		/// .
		/// <p>Applications should generally create a
		/// <see cref="CharsetEncoder">CharsetEncoder</see>
		/// using
		/// <see cref="newEncoder()">newEncoder()</see>
		/// for performance.
		/// </summary>
		/// <param name="buffer">the character buffer containing the content to be encoded.</param>
		/// <returns>the result of the encoding.</returns>
		public java.nio.ByteBuffer encode(java.nio.CharBuffer buffer)
		{
			try
			{
				return newEncoder().onMalformedInput(java.nio.charset.CodingErrorAction.REPLACE).
					onUnmappableCharacter(java.nio.charset.CodingErrorAction.REPLACE).encode(buffer);
			}
			catch (java.nio.charset.CharacterCodingException ex)
			{
				throw new System.Exception(ex.Message, ex);
			}
		}

		/// <summary>
		/// Returns a new
		/// <code>ByteBuffer</code>
		/// containing the bytes encoding the characters from
		/// <code>s</code>
		/// .
		/// This method uses
		/// <code>CodingErrorAction.REPLACE</code>
		/// .
		/// <p>Applications should generally create a
		/// <see cref="CharsetEncoder">CharsetEncoder</see>
		/// using
		/// <see cref="newEncoder()">newEncoder()</see>
		/// for performance.
		/// </summary>
		/// <param name="s">the string to be encoded.</param>
		/// <returns>the result of the encoding.</returns>
		public java.nio.ByteBuffer encode(string s)
		{
			return encode(java.nio.CharBuffer.wrap(java.lang.CharSequenceProxy.Wrap(s)));
		}

		/// <summary>
		/// Returns a new
		/// <code>CharBuffer</code>
		/// containing the characters decoded from
		/// <code>buffer</code>
		/// .
		/// This method uses
		/// <code>CodingErrorAction.REPLACE</code>
		/// .
		/// <p>Applications should generally create a
		/// <see cref="CharsetDecoder">CharsetDecoder</see>
		/// using
		/// <see cref="newDecoder()">newDecoder()</see>
		/// for performance.
		/// </summary>
		/// <param name="buffer">the byte buffer containing the content to be decoded.</param>
		/// <returns>a character buffer containing the output of the decoding.</returns>
		public java.nio.CharBuffer decode(java.nio.ByteBuffer buffer)
		{
			try
			{
				return newDecoder().onMalformedInput(java.nio.charset.CodingErrorAction.REPLACE).
					onUnmappableCharacter(java.nio.charset.CodingErrorAction.REPLACE).decode(buffer);
			}
			catch (java.nio.charset.CharacterCodingException ex)
			{
				throw new System.Exception(ex.Message, ex);
			}
		}

		/// <summary>Determines whether this charset equals to the given object.</summary>
		/// <remarks>
		/// Determines whether this charset equals to the given object. They are
		/// considered to be equal if they have the same canonical name.
		/// </remarks>
		/// <param name="obj">the given object to be compared with.</param>
		/// <returns>true if they have the same canonical name, otherwise false.</returns>
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public sealed override bool Equals(object obj)
		{
			if (obj is java.nio.charset.Charset)
			{
				java.nio.charset.Charset that = (java.nio.charset.Charset)obj;
				return this.canonicalName.Equals(that.canonicalName);
			}
			return false;
		}

		/// <summary>Gets the hash code of this charset.</summary>
		/// <remarks>Gets the hash code of this charset.</remarks>
		/// <returns>the hash code of this charset.</returns>
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public sealed override int GetHashCode()
		{
			return this.canonicalName.GetHashCode();
		}

		/// <summary>Gets a string representation of this charset.</summary>
		/// <remarks>
		/// Gets a string representation of this charset. Usually this contains the
		/// canonical name of the charset.
		/// </remarks>
		/// <returns>a string representation of this charset.</returns>
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public sealed override string ToString()
		{
			return GetType().FullName + "[" + this.canonicalName + "]";
		}

		/// <summary>Returns the system's default charset.</summary>
		/// <remarks>
		/// Returns the system's default charset. This is determined during VM startup, and will not
		/// change thereafter. On Android, the default charset is UTF-8.
		/// </remarks>
		public static java.nio.charset.Charset defaultCharset()
		{
			return DEFAULT_CHARSET;
		}
	}
}

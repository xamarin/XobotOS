using System;
using System.Text;
using System.Collections.Generic;
using XobotOS.IO;

namespace java.nio.charset
{
	partial class Charset
	{
		static readonly MonoCharset utf8 = new MonoCharset (Encoding.UTF8);
		static readonly MonoCharset ascii = new MonoCharset (Encoding.ASCII);

		/// <summary>Constructs a <code>Charset</code> object.</summary>
		/// <remarks>
		/// Constructs a <code>Charset</code> object. Duplicated aliases are
		/// ignored.
		/// </remarks>
		/// <param name="canonicalName">the canonical name of the charset.</param>
		/// <param name="aliases">an array containing all aliases of the charset. May be null.
		/// 	</param>
		/// <exception cref="IllegalCharsetNameException">
		/// on an illegal value being supplied for either
		/// <code>canonicalName</code> or for any element of
		/// <code>aliases</code>.
		/// </exception>
		protected internal Charset (string canonicalName, string[] aliases)
		{
			// check whether the given canonical name is legal
			checkCharsetName (canonicalName);
			this.canonicalName = canonicalName;
		}

		/// <summary>
		/// Returns an immutable case-insensitive map from canonical names to
		/// <code>Charset</code>
		/// instances.
		/// If multiple charsets have the same canonical name, it is unspecified which is returned in
		/// the map. This method may be slow. If you know which charset you're looking for, use
		/// <see cref="forName(string)">forName(string)</see>
		/// .
		/// </summary>
		/// <returns>
		/// an immutable case-insensitive map from canonical names to
		/// <code>Charset</code>
		/// instances
		/// </returns>
		public static SortedDictionary<string, Charset> availableCharsets ()
		{
			SortedDictionary<string, Charset> charsets = new SortedDictionary<string, Charset> ();
			charsets.Add (utf8.Name, utf8);
			charsets.Add (ascii.Name, ascii);
			return charsets;
		}

		/// <summary>
		/// Returns a
		/// <code>Charset</code>
		/// instance for the named charset.
		/// </summary>
		/// <param name="charsetName">a charset name (either canonical or an alias)</param>
		/// <exception cref="IllegalCharsetNameException">if the specified charset name is illegal.
		/// 	</exception>
		/// <exception cref="UnsupportedCharsetException">if the desired charset is not supported by this runtime.
		/// 	</exception>
		public static Charset forName (string charsetName)
		{
			if (charsetName == null) {
				throw new IllegalCharsetNameException (null);
			}
			if (charsetName.Equals (utf8.Name, StringComparison.InvariantCultureIgnoreCase))
				return utf8;
			if (charsetName.Equals (ascii.Name, StringComparison.InvariantCultureIgnoreCase))
				return ascii;
			throw new UnsupportedCharsetException (charsetName);
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
		/// <summary>
		/// Equivalent to
		/// <code>forName</code>
		/// but only throws
		/// <code>UnsupportedEncodingException</code>
		/// ,
		/// which is all pre-nio code claims to throw.
		/// </summary>
		/// <hide>internal use only</hide>
		/// <exception cref="java.io.UnsupportedEncodingException"></exception>
		public static Charset forNameUEE (string charsetName)
		{
			try {
				return forName (charsetName);
			} catch (Exception cause) {
				throw new java.io.UnsupportedEncodingException (charsetName, cause);
			}
		}

		/// <summary>Determines whether the specified charset is supported by this runtime.</summary>
		/// <remarks>Determines whether the specified charset is supported by this runtime.</remarks>
		/// <param name="charsetName">the name of the charset.</param>
		/// <returns>true if the specified charset is supported, otherwise false.</returns>
		/// <exception cref="IllegalCharsetNameException">if the specified charset name is illegal.
		/// 	</exception>
		public static bool isSupported (string charsetName)
		{
			try {
				forName (charsetName);
				return true;
			} catch (UnsupportedCharsetException) {
				return false;
			}
		}

		public static Charset getDefaultCharset ()
		{
			return utf8;
		}

		/// <summary>Compares this charset with the given charset.</summary>
		/// <remarks>
		/// Compares this charset with the given charset. This comparison is
		/// based on the case insensitive canonical names of the charsets.
		/// </remarks>
		/// <param name="charset">the given object to be compared with.</param>
		/// <returns>
		/// a negative integer if less than the given object, a positive
		/// integer if larger than it, or 0 if equal to it.
		/// </returns>
		[Sharpen.ImplementsInterface(@"java.lang.Comparable")]
		public virtual int compareTo (Charset charset)
		{
			return this.canonicalName.CompareTo (charset.canonicalName);
		}


	}
}


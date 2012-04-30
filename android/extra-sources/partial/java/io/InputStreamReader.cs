using System;

namespace java.io
{
	partial class InputStreamReader
	{
		/// <summary>
		/// Constructs a new InputStreamReader on the InputStream
		/// <code>in</code>
		/// . The
		/// character converter that is used to decode bytes into characters is
		/// identified by name by
		/// <code>enc</code>
		/// . If the encoding cannot be found, an
		/// UnsupportedEncodingException error is thrown.
		/// </summary>
		/// <param name="in">the InputStream from which to read characters.</param>
		/// <param name="enc">identifies the character converter to use.</param>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>enc</code>
		/// is
		/// <code>null</code>
		/// .
		/// </exception>
		/// <exception cref="UnsupportedEncodingException">
		/// if the encoding specified by
		/// <code>enc</code>
		/// cannot be found.
		/// </exception>
		/// <exception cref="java.io.UnsupportedEncodingException"></exception>
		public InputStreamReader (java.io.InputStream @in, string enc) : base(@in)
		{
			if (enc == null) {
				throw new System.ArgumentNullException ();
			}
			this.@in = @in;
			try {
				decoder = java.nio.charset.Charset.forName (enc).newDecoder ().onMalformedInput (java.nio.charset.CodingErrorAction
					.REPLACE).onUnmappableCharacter (java.nio.charset.CodingErrorAction.REPLACE);
			} catch (System.ArgumentException e) {
				throw new java.io.UnsupportedEncodingException (enc, e);
			}
			bytes.limit (0);
		}
	}
}


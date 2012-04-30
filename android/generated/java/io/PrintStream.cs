using Sharpen;

namespace java.io
{
	/// <summary>
	/// Wraps an existing
	/// <see cref="OutputStream">OutputStream</see>
	/// and provides convenience methods for
	/// writing common data types in a human readable format. This is not to be
	/// confused with DataOutputStream which is used for encoding common data types
	/// so that they can be read back in. No
	/// <code>IOException</code>
	/// is thrown by this
	/// class. Instead, callers should use
	/// <see cref="checkError()">checkError()</see>
	/// to see if a problem
	/// has occurred in this stream.
	/// </summary>
	[Sharpen.Sharpened]
	public class PrintStream : java.io.FilterOutputStream, java.lang.Appendable, java.io.Closeable
	{
		/// <summary>indicates whether or not this PrintStream has incurred an error.</summary>
		/// <remarks>indicates whether or not this PrintStream has incurred an error.</remarks>
		private bool ioError;

		/// <summary>
		/// indicates whether or not this PrintStream should flush its contents after
		/// printing a new line.
		/// </summary>
		/// <remarks>
		/// indicates whether or not this PrintStream should flush its contents after
		/// printing a new line.
		/// </remarks>
		private bool autoFlush;

		private string encoding;

		/// <summary>
		/// Constructs a new
		/// <code>PrintStream</code>
		/// with
		/// <code>out</code>
		/// as its target
		/// stream. By default, the new print stream does not automatically flush its
		/// contents to the target stream when a newline is encountered.
		/// </summary>
		/// <param name="out">the target output stream.</param>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>out</code>
		/// is
		/// <code>null</code>
		/// .
		/// </exception>
		public PrintStream(java.io.OutputStream @out) : base(@out)
		{
			if (@out == null)
			{
				throw new System.ArgumentNullException();
			}
		}

		/// <summary>
		/// Constructs a new
		/// <code>PrintStream</code>
		/// with
		/// <code>out</code>
		/// as its target
		/// stream. The parameter
		/// <code>autoFlush</code>
		/// determines if the print stream
		/// automatically flushes its contents to the target stream when a newline is
		/// encountered.
		/// </summary>
		/// <param name="out">the target output stream.</param>
		/// <param name="autoFlush">
		/// indicates whether to flush contents upon encountering a
		/// newline sequence.
		/// </param>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>out</code>
		/// is
		/// <code>null</code>
		/// .
		/// </exception>
		public PrintStream(java.io.OutputStream @out, bool autoFlush) : base(@out)
		{
			if (@out == null)
			{
				throw new System.ArgumentNullException();
			}
			this.autoFlush = autoFlush;
		}

		/// <summary>
		/// Constructs a new
		/// <code>PrintStream</code>
		/// with
		/// <code>out</code>
		/// as its target
		/// stream and using the character encoding
		/// <code>enc</code>
		/// while writing. The
		/// parameter
		/// <code>autoFlush</code>
		/// determines if the print stream automatically
		/// flushes its contents to the target stream when a newline is encountered.
		/// </summary>
		/// <param name="out">the target output stream.</param>
		/// <param name="autoFlush">
		/// indicates whether or not to flush contents upon encountering a
		/// newline sequence.
		/// </param>
		/// <param name="enc">the non-null string describing the desired character encoding.</param>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>out</code>
		/// or
		/// <code>enc</code>
		/// are
		/// <code>null</code>
		/// .
		/// </exception>
		/// <exception cref="UnsupportedEncodingException">
		/// if the encoding specified by
		/// <code>enc</code>
		/// is not supported.
		/// </exception>
		/// <exception cref="java.io.UnsupportedEncodingException"></exception>
		public PrintStream(java.io.OutputStream @out, bool autoFlush, string enc) : base(
			@out)
		{
			if (@out == null || enc == null)
			{
				throw new System.ArgumentNullException();
			}
			this.autoFlush = autoFlush;
			try
			{
				if (!java.nio.charset.Charset.isSupported(enc))
				{
					throw new java.io.UnsupportedEncodingException(enc);
				}
			}
			catch (java.nio.charset.IllegalCharsetNameException)
			{
				throw new java.io.UnsupportedEncodingException(enc);
			}
			encoding = enc;
		}

		/// <summary>
		/// Constructs a new
		/// <code>PrintStream</code>
		/// with
		/// <code>file</code>
		/// as its target. The
		/// VM's default character set is used for character encoding.
		/// </summary>
		/// <param name="file">
		/// the target file. If the file already exists, its contents are
		/// removed, otherwise a new file is created.
		/// </param>
		/// <exception cref="FileNotFoundException">if an error occurs while opening or creating the target file.
		/// 	</exception>
		/// <exception cref="java.io.FileNotFoundException"></exception>
		public PrintStream(java.io.File file) : base(new java.io.FileOutputStream(file))
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>PrintStream</code>
		/// with
		/// <code>file</code>
		/// as its target. The
		/// character set named
		/// <code>csn</code>
		/// is used for character encoding.
		/// </summary>
		/// <param name="file">
		/// the target file. If the file already exists, its contents are
		/// removed, otherwise a new file is created.
		/// </param>
		/// <param name="csn">the name of the character set used for character encoding.</param>
		/// <exception cref="FileNotFoundException">if an error occurs while opening or creating the target file.
		/// 	</exception>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>csn</code>
		/// is
		/// <code>null</code>
		/// .
		/// </exception>
		/// <exception cref="UnsupportedEncodingException">
		/// if the encoding specified by
		/// <code>csn</code>
		/// is not supported.
		/// </exception>
		/// <exception cref="java.io.FileNotFoundException"></exception>
		/// <exception cref="java.io.UnsupportedEncodingException"></exception>
		public PrintStream(java.io.File file, string csn) : base(new java.io.FileOutputStream
			(file))
		{
			if (csn == null)
			{
				throw new System.ArgumentNullException();
			}
			if (!java.nio.charset.Charset.isSupported(csn))
			{
				throw new java.io.UnsupportedEncodingException(csn);
			}
			encoding = csn;
		}

		/// <summary>
		/// Constructs a new
		/// <code>PrintStream</code>
		/// with the file identified by
		/// <code>fileName</code>
		/// as its target. The VM's default character
		/// set is used for character encoding.
		/// </summary>
		/// <param name="fileName">
		/// the target file's name. If the file already exists, its
		/// contents are removed, otherwise a new file is created.
		/// </param>
		/// <exception cref="FileNotFoundException">if an error occurs while opening or creating the target file.
		/// 	</exception>
		/// <exception cref="java.io.FileNotFoundException"></exception>
		public PrintStream(string fileName) : this(new java.io.File(fileName))
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>PrintStream</code>
		/// with the file identified by
		/// <code>fileName</code>
		/// as its target. The character set named
		/// <code>csn</code>
		/// is
		/// used for character encoding.
		/// </summary>
		/// <param name="fileName">
		/// the target file's name. If the file already exists, its
		/// contents are removed, otherwise a new file is created.
		/// </param>
		/// <param name="csn">the name of the character set used for character encoding.</param>
		/// <exception cref="FileNotFoundException">if an error occurs while opening or creating the target file.
		/// 	</exception>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>csn</code>
		/// is
		/// <code>null</code>
		/// .
		/// </exception>
		/// <exception cref="UnsupportedEncodingException">
		/// if the encoding specified by
		/// <code>csn</code>
		/// is not supported.
		/// </exception>
		/// <exception cref="java.io.FileNotFoundException"></exception>
		/// <exception cref="java.io.UnsupportedEncodingException"></exception>
		public PrintStream(string fileName, string csn) : this(new java.io.File(fileName)
			, csn)
		{
		}

		/// <summary>Flushes this stream and returns the value of the error flag.</summary>
		/// <remarks>Flushes this stream and returns the value of the error flag.</remarks>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if either an
		/// <code>IOException</code>
		/// has been thrown
		/// previously or if
		/// <code>setError()</code>
		/// has been called;
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		/// <seealso cref="setError()">setError()</seealso>
		[Sharpen.OverridesMethod(@"java.io.OutputStream")]
		internal override bool checkError()
		{
			java.io.OutputStream @delegate = @out;
			if (@delegate == null)
			{
				return ioError;
			}
			flush();
			return ioError || @delegate.checkError();
		}

		/// <summary>Sets the error state of the stream to false.</summary>
		/// <remarks>Sets the error state of the stream to false.</remarks>
		/// <since>1.6</since>
		protected internal virtual void clearError()
		{
			ioError = false;
		}

		/// <summary>Closes this print stream.</summary>
		/// <remarks>
		/// Closes this print stream. Flushes this stream and then closes the target
		/// stream. If an I/O error occurs, this stream's error state is set to
		/// <code>true</code>
		/// .
		/// </remarks>
		[Sharpen.OverridesMethod(@"java.io.OutputStream")]
		public override void close()
		{
			lock (this)
			{
				flush();
				if (@out != null)
				{
					try
					{
						@out.close();
						@out = null;
					}
					catch (System.IO.IOException)
					{
						setError();
					}
				}
			}
		}

		/// <summary>Ensures that all pending data is sent out to the target stream.</summary>
		/// <remarks>
		/// Ensures that all pending data is sent out to the target stream. It also
		/// flushes the target stream. If an I/O error occurs, this stream's error
		/// state is set to
		/// <code>true</code>
		/// .
		/// </remarks>
		[Sharpen.OverridesMethod(@"java.io.OutputStream")]
		public override void flush()
		{
			lock (this)
			{
				if (@out != null)
				{
					try
					{
						@out.flush();
						return;
					}
					catch (System.IO.IOException)
					{
					}
				}
				// Ignored, fall through to setError
				setError();
			}
		}

		/// <summary>
		/// Formats
		/// <code>args</code>
		/// according to the format string
		/// <code>format</code>
		/// , and writes the result
		/// to this stream. This method uses the user's default locale.
		/// See "<a href="../util/Locale.html#default_locale">Be wary of the default locale</a>".
		/// </summary>
		/// <param name="format">
		/// the format string (see
		/// <see cref="java.util.Formatter.format(string, object[])">java.util.Formatter.format(string, object[])
		/// 	</see>
		/// )
		/// </param>
		/// <param name="args">
		/// the list of arguments passed to the formatter. If there are
		/// more arguments than required by
		/// <code>format</code>
		/// ,
		/// additional arguments are ignored.
		/// </param>
		/// <returns>this stream.</returns>
		/// <exception cref="java.util.IllegalFormatException">
		/// if the format string is illegal or incompatible with the
		/// arguments, if there are not enough arguments or if any other
		/// error regarding the format string or arguments is detected.
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>format == null</code>
		/// </exception>
		public virtual java.io.PrintStream format(string format_1, params object[] args)
		{
			return format(System.Globalization.CultureInfo.CurrentCulture, format_1, args);
		}

		/// <summary>
		/// Writes a string formatted by an intermediate
		/// <see cref="java.util.Formatter">java.util.Formatter</see>
		/// to this
		/// stream using the specified locale, format string and arguments.
		/// </summary>
		/// <param name="l">
		/// the locale used in the method. No localization will be applied
		/// if
		/// <code>l</code>
		/// is
		/// <code>null</code>
		/// .
		/// </param>
		/// <param name="format">
		/// the format string (see
		/// <see cref="java.util.Formatter.format(string, object[])">java.util.Formatter.format(string, object[])
		/// 	</see>
		/// )
		/// </param>
		/// <param name="args">
		/// the list of arguments passed to the formatter. If there are
		/// more arguments than required by
		/// <code>format</code>
		/// ,
		/// additional arguments are ignored.
		/// </param>
		/// <returns>this stream.</returns>
		/// <exception cref="java.util.IllegalFormatException">
		/// if the format string is illegal or incompatible with the
		/// arguments, if there are not enough arguments or if any other
		/// error regarding the format string or arguments is detected.
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>format == null</code>
		/// </exception>
		public virtual java.io.PrintStream format(System.Globalization.CultureInfo l, string
			 format_1, params object[] args)
		{
			if (format_1 == null)
			{
				throw new System.ArgumentNullException("format == null");
			}
			new java.util.Formatter(this, l).format(format_1, args);
			return this;
		}

		/// <summary>Prints a formatted string.</summary>
		/// <remarks>
		/// Prints a formatted string. The behavior of this method is the same as
		/// this stream's
		/// <code>#format(String, Object...)</code>
		/// method.
		/// <p>The
		/// <code>Locale</code>
		/// used is the user's default locale.
		/// See "<a href="../util/Locale.html#default_locale">Be wary of the default locale</a>".
		/// </remarks>
		/// <param name="format">
		/// the format string (see
		/// <see cref="java.util.Formatter.format(string, object[])">java.util.Formatter.format(string, object[])
		/// 	</see>
		/// )
		/// </param>
		/// <param name="args">
		/// the list of arguments passed to the formatter. If there are
		/// more arguments than required by
		/// <code>format</code>
		/// ,
		/// additional arguments are ignored.
		/// </param>
		/// <returns>this stream.</returns>
		/// <exception cref="java.util.IllegalFormatException">
		/// if the format string is illegal or incompatible with the
		/// arguments, if there are not enough arguments or if any other
		/// error regarding the format string or arguments is detected.
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>format == null</code>
		/// </exception>
		public virtual java.io.PrintStream printf(string format_1, params object[] args)
		{
			return format(format_1, args);
		}

		/// <summary>Prints a formatted string.</summary>
		/// <remarks>
		/// Prints a formatted string. The behavior of this method is the same as
		/// this stream's
		/// <code>#format(Locale, String, Object...)</code>
		/// method.
		/// </remarks>
		/// <param name="l">
		/// the locale used in the method. No localization will be applied
		/// if
		/// <code>l</code>
		/// is
		/// <code>null</code>
		/// .
		/// </param>
		/// <param name="format">
		/// the format string (see
		/// <see cref="java.util.Formatter.format(string, object[])">java.util.Formatter.format(string, object[])
		/// 	</see>
		/// )
		/// </param>
		/// <param name="args">
		/// the list of arguments passed to the formatter. If there are
		/// more arguments than required by
		/// <code>format</code>
		/// ,
		/// additional arguments are ignored.
		/// </param>
		/// <returns>this stream.</returns>
		/// <exception cref="java.util.IllegalFormatException">
		/// if the format string is illegal or incompatible with the
		/// arguments, if there are not enough arguments or if any other
		/// error regarding the format string or arguments is detected.
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>format == null</code>
		/// .
		/// </exception>
		public virtual java.io.PrintStream printf(System.Globalization.CultureInfo l, string
			 format_1, params object[] args)
		{
			return format(l, format_1, args);
		}

		/// <summary>Put the line separator String onto the print stream.</summary>
		/// <remarks>Put the line separator String onto the print stream.</remarks>
		private void newline()
		{
			print(System.Environment.NewLine);
		}

		/// <summary>
		/// Prints the string representation of the character array
		/// <code>chars</code>
		/// .
		/// </summary>
		public virtual void print(char[] chars)
		{
			print(new string(chars, 0, chars.Length));
		}

		/// <summary>
		/// Prints the string representation of the char
		/// <code>c</code>
		/// .
		/// </summary>
		public virtual void print(char c)
		{
			print(c.ToString());
		}

		/// <summary>
		/// Prints the string representation of the double
		/// <code>d</code>
		/// .
		/// </summary>
		public virtual void print(double d)
		{
			print(d.ToString());
		}

		/// <summary>
		/// Prints the string representation of the float
		/// <code>f</code>
		/// .
		/// </summary>
		public virtual void print(float f)
		{
			print(f.ToString());
		}

		/// <summary>
		/// Prints the string representation of the int
		/// <code>i</code>
		/// .
		/// </summary>
		public virtual void print(int i)
		{
			print(i.ToString());
		}

		/// <summary>
		/// Prints the string representation of the long
		/// <code>l</code>
		/// .
		/// </summary>
		public virtual void print(long l)
		{
			print(l.ToString());
		}

		/// <summary>
		/// Prints the string representation of the Object
		/// <code>o</code>
		/// , or
		/// <code>"null"</code>
		/// .
		/// </summary>
		public virtual void print(object o)
		{
			print(Sharpen.StringHelper.GetValueOf(o));
		}

		/// <summary>Prints a string to the target stream.</summary>
		/// <remarks>
		/// Prints a string to the target stream. The string is converted to an array
		/// of bytes using the encoding chosen during the construction of this
		/// stream. The bytes are then written to the target stream with
		/// <code>write(int)</code>
		/// .
		/// <p>If an I/O error occurs, this stream's error state is set to
		/// <code>true</code>
		/// .
		/// </remarks>
		/// <param name="str">the string to print to the target stream.</param>
		/// <seealso cref="write(int)">write(int)</seealso>
		public virtual void print(string str)
		{
			lock (this)
			{
				if (@out == null)
				{
					setError();
					return;
				}
				if (str == null)
				{
					print("null");
					return;
				}
				try
				{
					if (encoding == null)
					{
						write(Sharpen.StringHelper.GetBytesForString(str));
					}
					else
					{
						write(Sharpen.StringHelper.GetBytesForString(str, encoding));
					}
				}
				catch (System.IO.IOException)
				{
					setError();
				}
			}
		}

		/// <summary>
		/// Prints the string representation of the boolean
		/// <code>b</code>
		/// .
		/// </summary>
		public virtual void print(bool b)
		{
			print(b.ToString());
		}

		/// <summary>Prints a newline.</summary>
		/// <remarks>Prints a newline.</remarks>
		public virtual void println()
		{
			newline();
		}

		/// <summary>
		/// Prints the string representation of the character array
		/// <code>chars</code>
		/// followed by a newline.
		/// </summary>
		public virtual void println(char[] chars)
		{
			println(new string(chars, 0, chars.Length));
		}

		/// <summary>
		/// Prints the string representation of the char
		/// <code>c</code>
		/// followed by a newline.
		/// </summary>
		public virtual void println(char c)
		{
			println(c.ToString());
		}

		/// <summary>
		/// Prints the string representation of the double
		/// <code>d</code>
		/// followed by a newline.
		/// </summary>
		public virtual void println(double d)
		{
			println(d.ToString());
		}

		/// <summary>
		/// Prints the string representation of the float
		/// <code>f</code>
		/// followed by a newline.
		/// </summary>
		public virtual void println(float f)
		{
			println(f.ToString());
		}

		/// <summary>
		/// Prints the string representation of the int
		/// <code>i</code>
		/// followed by a newline.
		/// </summary>
		public virtual void println(int i)
		{
			println(i.ToString());
		}

		/// <summary>
		/// Prints the string representation of the long
		/// <code>l</code>
		/// followed by a newline.
		/// </summary>
		public virtual void println(long l)
		{
			println(l.ToString());
		}

		/// <summary>
		/// Prints the string representation of the Object
		/// <code>o</code>
		/// , or
		/// <code>"null"</code>
		/// ,
		/// followed by a newline.
		/// </summary>
		public virtual void println(object o)
		{
			println(Sharpen.StringHelper.GetValueOf(o));
		}

		/// <summary>Prints a string followed by a newline.</summary>
		/// <remarks>
		/// Prints a string followed by a newline. The string is converted to an array of bytes using
		/// the encoding chosen during the construction of this stream. The bytes are
		/// then written to the target stream with
		/// <code>write(int)</code>
		/// .
		/// <p>If an I/O error occurs, this stream's error state is set to
		/// <code>true</code>
		/// .
		/// </remarks>
		/// <param name="str">the string to print to the target stream.</param>
		/// <seealso cref="write(int)">write(int)</seealso>
		public virtual void println(string str)
		{
			lock (this)
			{
				print(str);
				newline();
			}
		}

		/// <summary>
		/// Prints the string representation of the boolean
		/// <code>b</code>
		/// followed by a newline.
		/// </summary>
		public virtual void println(bool b)
		{
			println(b.ToString());
		}

		/// <summary>Sets the error flag of this print stream to true.</summary>
		/// <remarks>Sets the error flag of this print stream to true.</remarks>
		protected internal virtual void setError()
		{
			ioError = true;
		}

		/// <summary>
		/// Writes
		/// <code>count</code>
		/// bytes from
		/// <code>buffer</code>
		/// starting at
		/// <code>offset</code>
		/// to the target stream. If autoFlush is set, this stream gets flushed after
		/// writing the buffer.
		/// <p>This stream's error flag is set to
		/// <code>true</code>
		/// if this stream is closed
		/// or an I/O error occurs.
		/// </summary>
		/// <param name="buffer">the buffer to be written.</param>
		/// <param name="offset">
		/// the index of the first byte in
		/// <code>buffer</code>
		/// to write.
		/// </param>
		/// <param name="length">
		/// the number of bytes in
		/// <code>buffer</code>
		/// to write.
		/// </param>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>offset &lt; 0</code>
		/// or
		/// <code>count &lt; 0</code>
		/// , or if
		/// <code>offset + count</code>
		/// is bigger than the length of
		/// <code>buffer</code>
		/// .
		/// </exception>
		/// <seealso cref="flush()">flush()</seealso>
		[Sharpen.OverridesMethod(@"java.io.OutputStream")]
		public override void write(byte[] buffer, int offset, int length)
		{
			java.util.Arrays.checkOffsetAndCount(buffer.Length, offset, length);
			lock (this)
			{
				if (@out == null)
				{
					setError();
					return;
				}
				try
				{
					@out.write(buffer, offset, length);
					if (autoFlush)
					{
						flush();
					}
				}
				catch (System.IO.IOException)
				{
					setError();
				}
			}
		}

		/// <summary>Writes one byte to the target stream.</summary>
		/// <remarks>
		/// Writes one byte to the target stream. Only the least significant byte of
		/// the integer
		/// <code>oneByte</code>
		/// is written. This stream is flushed if
		/// <code>oneByte</code>
		/// is equal to the character
		/// <code>'\n'</code>
		/// and this stream is
		/// set to autoFlush.
		/// <p>
		/// This stream's error flag is set to
		/// <code>true</code>
		/// if it is closed or an I/O
		/// error occurs.
		/// </remarks>
		/// <param name="oneByte">the byte to be written</param>
		[Sharpen.OverridesMethod(@"java.io.OutputStream")]
		public override void write(int oneByte)
		{
			lock (this)
			{
				if (@out == null)
				{
					setError();
					return;
				}
				try
				{
					@out.write(oneByte);
					int b = oneByte & unchecked((int)(0xFF));
					// 0x0A is ASCII newline, 0x15 is EBCDIC newline.
					bool isNewline = b == unchecked((int)(0x0A)) || b == unchecked((int)(0x15));
					if (autoFlush && isNewline)
					{
						flush();
					}
				}
				catch (System.IO.IOException)
				{
					setError();
				}
			}
		}

		[Sharpen.Proxy]
		java.lang.Appendable java.lang.Appendable.append(char c)
		{
			return append(c);
		}

		/// <summary>
		/// Appends the char
		/// <code>c</code>
		/// .
		/// </summary>
		/// <returns>this stream.</returns>
		[Sharpen.ImplementsInterface(@"java.lang.Appendable")]
		public virtual java.io.PrintStream append(char c)
		{
			print(c);
			return this;
		}

		[Sharpen.Proxy]
		java.lang.Appendable java.lang.Appendable.append(java.lang.CharSequence charSequence
			)
		{
			return append(charSequence);
		}

		/// <summary>
		/// Appends the CharSequence
		/// <code>charSequence</code>
		/// , or
		/// <code>"null"</code>
		/// .
		/// </summary>
		/// <returns>this stream.</returns>
		[Sharpen.ImplementsInterface(@"java.lang.Appendable")]
		public virtual java.io.PrintStream append(java.lang.CharSequence charSequence)
		{
			if (charSequence == null)
			{
				print("null");
			}
			else
			{
				print(charSequence.ToString());
			}
			return this;
		}

		[Sharpen.Proxy]
		java.lang.Appendable java.lang.Appendable.append(java.lang.CharSequence charSequence
			, int start, int end)
		{
			return append(charSequence, start, end);
		}

		/// <summary>
		/// Appends a subsequence of CharSequence
		/// <code>charSequence</code>
		/// , or
		/// <code>"null"</code>
		/// .
		/// </summary>
		/// <param name="charSequence">the character sequence appended to the target stream.</param>
		/// <param name="start">
		/// the index of the first char in the character sequence appended
		/// to the target stream.
		/// </param>
		/// <param name="end">
		/// the index of the character following the last character of the
		/// subsequence appended to the target stream.
		/// </param>
		/// <returns>this stream.</returns>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>start &gt; end</code>
		/// ,
		/// <code>start &lt; 0</code>
		/// ,
		/// <code>end &lt; 0</code>
		/// or
		/// either
		/// <code>start</code>
		/// or
		/// <code>end</code>
		/// are greater or equal than
		/// the length of
		/// <code>charSequence</code>
		/// .
		/// </exception>
		[Sharpen.ImplementsInterface(@"java.lang.Appendable")]
		public virtual java.io.PrintStream append(java.lang.CharSequence charSequence, int
			 start, int end)
		{
			if (charSequence == null)
			{
				charSequence = java.lang.CharSequenceProxy.Wrap("null");
			}
			print(charSequence.SubSequence(start, end).ToString());
			return this;
		}
	}
}

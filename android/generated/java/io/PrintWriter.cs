using Sharpen;

namespace java.io
{
	/// <summary>
	/// Wraps either an existing
	/// <see cref="OutputStream">OutputStream</see>
	/// or an existing
	/// <see cref="Writer">Writer</see>
	/// and provides convenience methods for printing common data types in a human
	/// readable format. No
	/// <code>IOException</code>
	/// is thrown by this class. Instead,
	/// callers should use
	/// <see cref="checkError()">checkError()</see>
	/// to see if a problem has occurred in
	/// this writer.
	/// </summary>
	[Sharpen.Sharpened]
	public class PrintWriter : java.io.Writer
	{
		/// <summary>The writer to print data to.</summary>
		/// <remarks>The writer to print data to.</remarks>
		protected internal java.io.Writer @out;

		/// <summary>Indicates whether this PrintWriter is in an error state.</summary>
		/// <remarks>Indicates whether this PrintWriter is in an error state.</remarks>
		private bool ioError;

		/// <summary>
		/// Indicates whether or not this PrintWriter should flush its contents after
		/// printing a new line.
		/// </summary>
		/// <remarks>
		/// Indicates whether or not this PrintWriter should flush its contents after
		/// printing a new line.
		/// </remarks>
		private bool autoFlush;

		/// <summary>
		/// Constructs a new
		/// <code>PrintWriter</code>
		/// with
		/// <code>out</code>
		/// as its target
		/// stream. By default, the new print writer does not automatically flush its
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
		public PrintWriter(java.io.OutputStream @out) : this(new java.io.OutputStreamWriter
			(@out), false)
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>PrintWriter</code>
		/// with
		/// <code>out</code>
		/// as its target
		/// stream. The parameter
		/// <code>autoFlush</code>
		/// determines if the print writer
		/// automatically flushes its contents to the target stream when a newline is
		/// encountered.
		/// </summary>
		/// <param name="out">the target output stream.</param>
		/// <param name="autoFlush">
		/// indicates whether contents are flushed upon encountering a
		/// newline sequence.
		/// </param>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>out</code>
		/// is
		/// <code>null</code>
		/// .
		/// </exception>
		public PrintWriter(java.io.OutputStream @out, bool autoFlush) : this(new java.io.OutputStreamWriter
			(@out), autoFlush)
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>PrintWriter</code>
		/// with
		/// <code>wr</code>
		/// as its target
		/// writer. By default, the new print writer does not automatically flush its
		/// contents to the target writer when a newline is encountered.
		/// </summary>
		/// <param name="wr">the target writer.</param>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>wr</code>
		/// is
		/// <code>null</code>
		/// .
		/// </exception>
		public PrintWriter(java.io.Writer wr) : this(wr, false)
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>PrintWriter</code>
		/// with
		/// <code>out</code>
		/// as its target
		/// writer. The parameter
		/// <code>autoFlush</code>
		/// determines if the print writer
		/// automatically flushes its contents to the target writer when a newline is
		/// encountered.
		/// </summary>
		/// <param name="wr">the target writer.</param>
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
		public PrintWriter(java.io.Writer wr, bool autoFlush) : base(wr)
		{
			this.autoFlush = autoFlush;
			@out = wr;
		}

		/// <summary>
		/// Constructs a new
		/// <code>PrintWriter</code>
		/// with
		/// <code>file</code>
		/// as its target. The
		/// VM's default character set is used for character encoding.
		/// The print writer does not automatically flush its contents to the target
		/// file when a newline is encountered. The output to the file is buffered.
		/// </summary>
		/// <param name="file">
		/// the target file. If the file already exists, its contents are
		/// removed, otherwise a new file is created.
		/// </param>
		/// <exception cref="FileNotFoundException">if an error occurs while opening or creating the target file.
		/// 	</exception>
		/// <exception cref="java.io.FileNotFoundException"></exception>
		public PrintWriter(java.io.File file) : this(new java.io.OutputStreamWriter(new java.io.BufferedOutputStream
			(new java.io.FileOutputStream(file))), false)
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>PrintWriter</code>
		/// with
		/// <code>file</code>
		/// as its target. The
		/// character set named
		/// <code>csn</code>
		/// is used for character encoding.
		/// The print writer does not automatically flush its contents to the target
		/// file when a newline is encountered. The output to the file is buffered.
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
		public PrintWriter(java.io.File file, string csn) : this(new java.io.OutputStreamWriter
			(new java.io.BufferedOutputStream(new java.io.FileOutputStream(file)), csn), false
			)
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>PrintWriter</code>
		/// with the file identified by
		/// <code>fileName</code>
		/// as its target. The VM's default character set is
		/// used for character encoding. The print writer does not automatically
		/// flush its contents to the target file when a newline is encountered. The
		/// output to the file is buffered.
		/// </summary>
		/// <param name="fileName">
		/// the target file's name. If the file already exists, its
		/// contents are removed, otherwise a new file is created.
		/// </param>
		/// <exception cref="FileNotFoundException">if an error occurs while opening or creating the target file.
		/// 	</exception>
		/// <exception cref="java.io.FileNotFoundException"></exception>
		public PrintWriter(string fileName) : this(new java.io.OutputStreamWriter(new java.io.BufferedOutputStream
			(new java.io.FileOutputStream(fileName))), false)
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>PrintWriter</code>
		/// with the file identified by
		/// <code>fileName</code>
		/// as its target. The character set named
		/// <code>csn</code>
		/// is used for
		/// character encoding. The print writer does not automatically flush its
		/// contents to the target file when a newline is encountered. The output to
		/// the file is buffered.
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
		public PrintWriter(string fileName, string csn) : this(new java.io.OutputStreamWriter
			(new java.io.BufferedOutputStream(new java.io.FileOutputStream(fileName)), csn), 
			false)
		{
		}

		/// <summary>Flushes this writer and returns the value of the error flag.</summary>
		/// <remarks>Flushes this writer and returns the value of the error flag.</remarks>
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
		[Sharpen.OverridesMethod(@"java.io.Writer")]
		internal override bool checkError()
		{
			java.io.Writer @delegate = @out;
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
			lock (@lock)
			{
				ioError = false;
			}
		}

		/// <summary>Closes this print writer.</summary>
		/// <remarks>
		/// Closes this print writer. Flushes this writer and then closes the target.
		/// If an I/O error occurs, this writer's error flag is set to
		/// <code>true</code>
		/// .
		/// </remarks>
		[Sharpen.OverridesMethod(@"java.io.Writer")]
		public override void close()
		{
			lock (@lock)
			{
				if (@out != null)
				{
					try
					{
						@out.close();
					}
					catch (System.IO.IOException)
					{
						setError();
					}
					@out = null;
				}
			}
		}

		/// <summary>Ensures that all pending data is sent out to the target.</summary>
		/// <remarks>
		/// Ensures that all pending data is sent out to the target. It also
		/// flushes the target. If an I/O error occurs, this writer's error
		/// state is set to
		/// <code>true</code>
		/// .
		/// </remarks>
		[Sharpen.OverridesMethod(@"java.io.Writer")]
		public override void flush()
		{
			lock (@lock)
			{
				if (@out != null)
				{
					try
					{
						@out.flush();
					}
					catch (System.IO.IOException)
					{
						setError();
					}
				}
				else
				{
					setError();
				}
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
		/// If automatic flushing is enabled then the buffer is flushed as well.
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
		/// <returns>this writer.</returns>
		/// <exception cref="java.util.IllegalFormatException">
		/// if the format string is illegal or incompatible with the
		/// arguments, if there are not enough arguments or if any other
		/// error regarding the format string or arguments is detected.
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>format == null</code>
		/// </exception>
		public virtual java.io.PrintWriter format(string format_1, params object[] args)
		{
			return format(System.Globalization.CultureInfo.CurrentCulture, format_1, args);
		}

		/// <summary>
		/// Writes a string formatted by an intermediate
		/// <code>Formatter</code>
		/// to the
		/// target using the specified locale, format string and arguments. If
		/// automatic flushing is enabled then this writer is flushed.
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
		/// <returns>this writer.</returns>
		/// <exception cref="java.util.IllegalFormatException">
		/// if the format string is illegal or incompatible with the
		/// arguments, if there are not enough arguments or if any other
		/// error regarding the format string or arguments is detected.
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>format == null</code>
		/// </exception>
		public virtual java.io.PrintWriter format(System.Globalization.CultureInfo l, string
			 format_1, params object[] args)
		{
			if (format_1 == null)
			{
				throw new System.ArgumentNullException("format == null");
			}
			new java.util.Formatter(this, l).format(format_1, args);
			if (autoFlush)
			{
				flush();
			}
			return this;
		}

		/// <summary>Prints a formatted string.</summary>
		/// <remarks>
		/// Prints a formatted string. The behavior of this method is the same as
		/// this writer's
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
		/// <returns>this writer.</returns>
		/// <exception cref="java.util.IllegalFormatException">
		/// if the format string is illegal or incompatible with the
		/// arguments, if there are not enough arguments or if any other
		/// error regarding the format string or arguments is detected.
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>format == null</code>
		/// </exception>
		public virtual java.io.PrintWriter printf(string format_1, params object[] args)
		{
			return format(format_1, args);
		}

		/// <summary>Prints a formatted string.</summary>
		/// <remarks>
		/// Prints a formatted string. The behavior of this method is the same as
		/// this writer's
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
		/// <returns>this writer.</returns>
		/// <exception cref="java.util.IllegalFormatException">
		/// if the format string is illegal or incompatible with the
		/// arguments, if there are not enough arguments or if any other
		/// error regarding the format string or arguments is detected.
		/// </exception>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>format == null</code>
		/// </exception>
		public virtual java.io.PrintWriter printf(System.Globalization.CultureInfo l, string
			 format_1, params object[] args)
		{
			return format(l, format_1, args);
		}

		/// <summary>
		/// Prints the string representation of the specified character array
		/// to the target.
		/// </summary>
		/// <remarks>
		/// Prints the string representation of the specified character array
		/// to the target.
		/// </remarks>
		/// <param name="charArray">the character array to print to the target.</param>
		/// <seealso cref="print(string)">print(string)</seealso>
		public virtual void print(char[] charArray)
		{
			print(new string(charArray, 0, charArray.Length));
		}

		/// <summary>
		/// Prints the string representation of the specified character to the
		/// target.
		/// </summary>
		/// <remarks>
		/// Prints the string representation of the specified character to the
		/// target.
		/// </remarks>
		/// <param name="ch">the character to print to the target.</param>
		/// <seealso cref="print(string)">print(string)</seealso>
		public virtual void print(char ch)
		{
			print(ch.ToString());
		}

		/// <summary>Prints the string representation of the specified double to the target.</summary>
		/// <remarks>Prints the string representation of the specified double to the target.</remarks>
		/// <param name="dnum">the double value to print to the target.</param>
		/// <seealso cref="print(string)">print(string)</seealso>
		public virtual void print(double dnum)
		{
			print(dnum.ToString());
		}

		/// <summary>Prints the string representation of the specified float to the target.</summary>
		/// <remarks>Prints the string representation of the specified float to the target.</remarks>
		/// <param name="fnum">the float value to print to the target.</param>
		/// <seealso cref="print(string)">print(string)</seealso>
		public virtual void print(float fnum)
		{
			print(fnum.ToString());
		}

		/// <summary>Prints the string representation of the specified integer to the target.
		/// 	</summary>
		/// <remarks>Prints the string representation of the specified integer to the target.
		/// 	</remarks>
		/// <param name="inum">the integer value to print to the target.</param>
		/// <seealso cref="print(string)">print(string)</seealso>
		public virtual void print(int inum)
		{
			print(inum.ToString());
		}

		/// <summary>Prints the string representation of the specified long to the target.</summary>
		/// <remarks>Prints the string representation of the specified long to the target.</remarks>
		/// <param name="lnum">the long value to print to the target.</param>
		/// <seealso cref="print(string)">print(string)</seealso>
		public virtual void print(long lnum)
		{
			print(lnum.ToString());
		}

		/// <summary>Prints the string representation of the specified object to the target.</summary>
		/// <remarks>Prints the string representation of the specified object to the target.</remarks>
		/// <param name="obj">the object to print to the target.</param>
		/// <seealso cref="print(string)">print(string)</seealso>
		public virtual void print(object obj)
		{
			print(Sharpen.StringHelper.GetValueOf(obj));
		}

		/// <summary>Prints a string to the target.</summary>
		/// <remarks>
		/// Prints a string to the target. The string is converted to an array of
		/// bytes using the encoding chosen during the construction of this writer.
		/// The bytes are then written to the target with
		/// <code>write(int)</code>
		/// .
		/// <p>
		/// If an I/O error occurs, this writer's error flag is set to
		/// <code>true</code>
		/// .
		/// </remarks>
		/// <param name="str">the string to print to the target.</param>
		/// <seealso cref="write(int)">write(int)</seealso>
		public virtual void print(string str)
		{
			write(str != null ? str : Sharpen.StringHelper.GetValueOf((object)null));
		}

		/// <summary>Prints the string representation of the specified boolean to the target.
		/// 	</summary>
		/// <remarks>Prints the string representation of the specified boolean to the target.
		/// 	</remarks>
		/// <param name="bool">the boolean value to print the target.</param>
		/// <seealso cref="print(string)">print(string)</seealso>
		public virtual void print(bool @bool)
		{
			print(@bool.ToString());
		}

		/// <summary>Prints a newline.</summary>
		/// <remarks>
		/// Prints a newline. Flushes this writer if the autoFlush flag is set to
		/// <code>true</code>
		/// .
		/// </remarks>
		public virtual void println()
		{
			lock (@lock)
			{
				print(System.Environment.NewLine);
				if (autoFlush)
				{
					flush();
				}
			}
		}

		/// <summary>
		/// Prints the string representation of the character array
		/// <code>chars</code>
		/// followed by a newline.
		/// Flushes this writer if the autoFlush flag is set to
		/// <code>true</code>
		/// .
		/// </summary>
		public virtual void println(char[] chars)
		{
			println(new string(chars, 0, chars.Length));
		}

		/// <summary>
		/// Prints the string representation of the char
		/// <code>c</code>
		/// followed by a newline.
		/// Flushes this writer if the autoFlush flag is set to
		/// <code>true</code>
		/// .
		/// </summary>
		public virtual void println(char c)
		{
			println(c.ToString());
		}

		/// <summary>
		/// Prints the string representation of the double
		/// <code>d</code>
		/// followed by a newline.
		/// Flushes this writer if the autoFlush flag is set to
		/// <code>true</code>
		/// .
		/// </summary>
		public virtual void println(double d)
		{
			println(d.ToString());
		}

		/// <summary>
		/// Prints the string representation of the float
		/// <code>f</code>
		/// followed by a newline.
		/// Flushes this writer if the autoFlush flag is set to
		/// <code>true</code>
		/// .
		/// </summary>
		public virtual void println(float f)
		{
			println(f.ToString());
		}

		/// <summary>
		/// Prints the string representation of the int
		/// <code>i</code>
		/// followed by a newline.
		/// Flushes this writer if the autoFlush flag is set to
		/// <code>true</code>
		/// .
		/// </summary>
		public virtual void println(int i)
		{
			println(i.ToString());
		}

		/// <summary>
		/// Prints the string representation of the long
		/// <code>l</code>
		/// followed by a newline.
		/// Flushes this writer if the autoFlush flag is set to
		/// <code>true</code>
		/// .
		/// </summary>
		public virtual void println(long l)
		{
			println(l.ToString());
		}

		/// <summary>
		/// Prints the string representation of the object
		/// <code>o</code>
		/// , or
		/// <code>"null</code>
		/// ,
		/// followed by a newline.
		/// Flushes this writer if the autoFlush flag is set to
		/// <code>true</code>
		/// .
		/// </summary>
		public virtual void println(object obj)
		{
			println(Sharpen.StringHelper.GetValueOf(obj));
		}

		/// <summary>
		/// Prints the string representation of the string
		/// <code>s</code>
		/// followed by a newline.
		/// Flushes this writer if the autoFlush flag is set to
		/// <code>true</code>
		/// .
		/// <p>The string is converted to an array of bytes using the
		/// encoding chosen during the construction of this writer. The bytes are
		/// then written to the target with
		/// <code>write(int)</code>
		/// . Finally, this writer
		/// is flushed if the autoFlush flag is set to
		/// <code>true</code>
		/// .
		/// <p>If an I/O error occurs, this writer's error flag is set to
		/// <code>true</code>
		/// .
		/// </summary>
		public virtual void println(string str)
		{
			lock (@lock)
			{
				print(str);
				println();
			}
		}

		/// <summary>
		/// Prints the string representation of the boolean
		/// <code>b</code>
		/// followed by a newline.
		/// Flushes this writer if the autoFlush flag is set to
		/// <code>true</code>
		/// .
		/// </summary>
		public virtual void println(bool b)
		{
			println(b.ToString());
		}

		/// <summary>Sets the error flag of this writer to true.</summary>
		/// <remarks>Sets the error flag of this writer to true.</remarks>
		protected internal virtual void setError()
		{
			lock (@lock)
			{
				ioError = true;
			}
		}

		/// <summary>
		/// Writes the character buffer
		/// <code>buf</code>
		/// to the target.
		/// </summary>
		/// <param name="buf">the non-null array containing characters to write.</param>
		[Sharpen.OverridesMethod(@"java.io.Writer")]
		public override void write(char[] buf)
		{
			write(buf, 0, buf.Length);
		}

		/// <summary>
		/// Writes
		/// <code>count</code>
		/// characters from
		/// <code>buffer</code>
		/// starting at
		/// <code>offset</code>
		/// to the target.
		/// <p>
		/// This writer's error flag is set to
		/// <code>true</code>
		/// if this writer is closed
		/// or an I/O error occurs.
		/// </summary>
		/// <param name="buf">the buffer to write to the target.</param>
		/// <param name="offset">
		/// the index of the first character in
		/// <code>buffer</code>
		/// to write.
		/// </param>
		/// <param name="count">
		/// the number of characters in
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
		/// is greater than the length of
		/// <code>buf</code>
		/// .
		/// </exception>
		[Sharpen.OverridesMethod(@"java.io.Writer")]
		public override void write(char[] buf, int offset, int count)
		{
			doWrite(buf, offset, count);
		}

		/// <summary>Writes one character to the target.</summary>
		/// <remarks>
		/// Writes one character to the target. Only the two least significant bytes
		/// of the integer
		/// <code>oneChar</code>
		/// are written.
		/// <p>
		/// This writer's error flag is set to
		/// <code>true</code>
		/// if this writer is closed
		/// or an I/O error occurs.
		/// </remarks>
		/// <param name="oneChar">the character to write to the target.</param>
		[Sharpen.OverridesMethod(@"java.io.Writer")]
		public override void write(int oneChar)
		{
			doWrite(new char[] { (char)oneChar }, 0, 1);
		}

		private void doWrite(char[] buf, int offset, int count)
		{
			lock (@lock)
			{
				if (@out != null)
				{
					try
					{
						@out.write(buf, offset, count);
					}
					catch (System.IO.IOException)
					{
						setError();
					}
				}
				else
				{
					setError();
				}
			}
		}

		/// <summary>Writes the characters from the specified string to the target.</summary>
		/// <remarks>Writes the characters from the specified string to the target.</remarks>
		/// <param name="str">the non-null string containing the characters to write.</param>
		[Sharpen.OverridesMethod(@"java.io.Writer")]
		public override void write(string str)
		{
			write(str.ToCharArray());
		}

		/// <summary>
		/// Writes
		/// <code>count</code>
		/// characters from
		/// <code>str</code>
		/// starting at
		/// <code>offset</code>
		/// to the target.
		/// </summary>
		/// <param name="str">the non-null string containing the characters to write.</param>
		/// <param name="offset">
		/// the index of the first character in
		/// <code>str</code>
		/// to write.
		/// </param>
		/// <param name="count">
		/// the number of characters from
		/// <code>str</code>
		/// to write.
		/// </param>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>offset &lt; 0</code>
		/// or
		/// <code>count &lt; 0</code>
		/// , or if
		/// <code>offset + count</code>
		/// is greater than the length of
		/// <code>str</code>
		/// .
		/// </exception>
		[Sharpen.OverridesMethod(@"java.io.Writer")]
		public override void write(string str, int offset, int count)
		{
			write(Sharpen.StringHelper.Substring(str, offset, offset + count).ToCharArray());
		}

		/// <summary>
		/// Appends the character
		/// <code>c</code>
		/// to the target.
		/// </summary>
		/// <param name="c">the character to append to the target.</param>
		/// <returns>this writer.</returns>
		[Sharpen.OverridesMethod(@"java.io.Writer")]
		public override java.io.Writer append(char c)
		{
			write(c);
			return this;
		}

		/// <summary>
		/// Appends the character sequence
		/// <code>csq</code>
		/// to the target. This
		/// method works the same way as
		/// <code>PrintWriter.print(csq.toString())</code>
		/// .
		/// If
		/// <code>csq</code>
		/// is
		/// <code>null</code>
		/// , then the string "null" is written
		/// to the target.
		/// </summary>
		/// <param name="csq">the character sequence appended to the target.</param>
		/// <returns>this writer.</returns>
		[Sharpen.OverridesMethod(@"java.io.Writer")]
		public override java.io.Writer append(java.lang.CharSequence csq)
		{
			if (csq == null)
			{
				csq = java.lang.CharSequenceProxy.Wrap("null");
			}
			append(csq, 0, csq.Length);
			return this;
		}

		/// <summary>
		/// Appends a subsequence of the character sequence
		/// <code>csq</code>
		/// to the
		/// target. This method works the same way as
		/// <code>PrintWriter.print(csq.subsequence(start, end).toString())</code>
		/// . If
		/// <code>csq</code>
		/// is
		/// <code>null</code>
		/// , then the specified subsequence of the string "null"
		/// will be written to the target.
		/// </summary>
		/// <param name="csq">the character sequence appended to the target.</param>
		/// <param name="start">
		/// the index of the first char in the character sequence appended
		/// to the target.
		/// </param>
		/// <param name="end">
		/// the index of the character following the last character of the
		/// subsequence appended to the target.
		/// </param>
		/// <returns>this writer.</returns>
		/// <exception cref="java.lang.StringIndexOutOfBoundsException">
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
		/// <code>csq</code>
		/// .
		/// </exception>
		[Sharpen.OverridesMethod(@"java.io.Writer")]
		public override java.io.Writer append(java.lang.CharSequence csq, int start, int 
			end)
		{
			if (csq == null)
			{
				csq = java.lang.CharSequenceProxy.Wrap("null");
			}
			string output = csq.SubSequence(start, end).ToString();
			write(output, 0, output.Length);
			return this;
		}
	}
}

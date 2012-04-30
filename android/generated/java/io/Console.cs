using Sharpen;

namespace java.io
{
	/// <summary>Provides access to the console, if available.</summary>
	/// <remarks>
	/// Provides access to the console, if available. The system-wide instance can
	/// be accessed via
	/// <see cref="java.lang.System.console()">java.lang.System.console()</see>
	/// .
	/// </remarks>
	/// <since>1.6</since>
	[Sharpen.Sharpened]
	public sealed partial class Console : java.io.Flushable
	{
		private static readonly object CONSOLE_LOCK = new object();

		private readonly java.io.Console.ConsoleReader _reader;

		private readonly java.io.PrintWriter _writer;

		/// <summary>
		/// Secret accessor for
		/// <code>System.console</code>
		/// .
		/// </summary>
		/// <hide></hide>
		public static java.io.Console getConsole()
		{
			return console;
		}

		/// <exception cref="System.IO.IOException"></exception>
		private Console(java.io.InputStream @in, java.io.OutputStream @out)
		{
			// We don't care about stderr, because this class only uses stdin and stdout.
			this._reader = new java.io.Console.ConsoleReader(@in);
			this._writer = new java.io.Console.ConsoleWriter(@out);
		}

		[Sharpen.ImplementsInterface(@"java.io.Flushable")]
		public void flush()
		{
			_writer.flush();
		}

		/// <summary>
		/// Writes a formatted string to the console using
		/// the specified format string and arguments.
		/// </summary>
		/// <remarks>
		/// Writes a formatted string to the console using
		/// the specified format string and arguments.
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
		/// <returns>the console instance.</returns>
		public java.io.Console format(string format_1, params object[] args)
		{
			java.util.Formatter f = new java.util.Formatter(_writer);
			f.format(format_1, args);
			f.flush();
			return this;
		}

		/// <summary>
		/// Equivalent to
		/// <code>format(format, args)</code>
		/// .
		/// </summary>
		public java.io.Console printf(string format_1, params object[] args)
		{
			return format(format_1, args);
		}

		/// <summary>
		/// Returns the
		/// <see cref="Reader">Reader</see>
		/// associated with this console.
		/// </summary>
		public java.io.Reader reader()
		{
			return _reader;
		}

		/// <summary>Reads a line from the console.</summary>
		/// <remarks>Reads a line from the console.</remarks>
		/// <returns>the line, or null at EOF.</returns>
		public string readLine()
		{
			try
			{
				return _reader.readLine();
			}
			catch (System.IO.IOException e)
			{
				throw new java.io.IOError(e);
			}
		}

		/// <summary>Reads a line from this console, using the specified prompt.</summary>
		/// <remarks>
		/// Reads a line from this console, using the specified prompt.
		/// The prompt is given as a format string and optional arguments.
		/// Note that this can be a source of errors: if it is possible that your
		/// prompt contains
		/// <code>%</code>
		/// characters, you must use the format string
		/// <code>"%s"</code>
		/// and pass the actual prompt as a parameter.
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
		/// <returns>the line, or null at EOF.</returns>
		public string readLine(string format_1, params object[] args)
		{
			lock (CONSOLE_LOCK)
			{
				format(format_1, args);
				return readLine();
			}
		}

		[Sharpen.Stub]
		public char[] readPassword()
		{
			throw new System.NotImplementedException();
		}

		// We won't have echoed the user's newline.
		/// <summary>Reads a password from the console.</summary>
		/// <remarks>
		/// Reads a password from the console. The password will not be echoed to the display.
		/// A formatted prompt is also displayed.
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
		/// <returns>a character array containing the password, or null at EOF.</returns>
		public char[] readPassword(string format_1, params object[] args)
		{
			lock (CONSOLE_LOCK)
			{
				format(format_1, args);
				return readPassword();
			}
		}

		/// <summary>
		/// Returns the
		/// <see cref="Writer">Writer</see>
		/// associated with this console.
		/// </summary>
		public java.io.PrintWriter writer()
		{
			return _writer;
		}

		private partial class ConsoleReader : java.io.BufferedReader
		{
			[Sharpen.OverridesMethod(@"java.io.Reader")]
			public override void close()
			{
			}
			// Console.reader cannot be closed.
		}

		private class ConsoleWriter : java.io.PrintWriter
		{
			public ConsoleWriter(java.io.OutputStream @out) : base(@out, true)
			{
				@lock = CONSOLE_LOCK;
			}

			[Sharpen.OverridesMethod(@"java.io.Writer")]
			public override void close()
			{
				// Console.writer cannot be closed.
				flush();
			}
		}
	}
}

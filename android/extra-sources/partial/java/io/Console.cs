using System;
using XobotOS.IO;

namespace java.io
{
	partial class Console
	{
		static readonly StreamInputStream @in;
		static readonly StreamOutputStream @out;
		static readonly StreamOutputStream @err;
		static readonly PrintStream @out_ps;
		static readonly PrintStream @err_ps;

		static readonly java.io.Console console;

		static Console ()
		{
			@in = new StreamInputStream (System.Console.OpenStandardInput ());
			@out = new StreamOutputStream (System.Console.OpenStandardOutput ());
			@err = new StreamOutputStream (System.Console.OpenStandardError ());
			@out_ps = new ConsolePrintStream (@out);
			@err_ps = new ConsolePrintStream (@err);

			console = new Console (@in, @out);
		}

		public static InputStream In {
			get { return @in; }
		}

		public static PrintStream Out {
			get { return @out_ps; }
		}

		public static PrintStream Error {
			get { return @err_ps; }
		}

		partial class ConsoleReader
		{
			/// <exception cref="System.IO.IOException"></exception>
			public ConsoleReader (InputStream @in) :
				base (new InputStreamReader (@in), 256)
			{
				@lock = CONSOLE_LOCK;
			}
		}

		private class ConsolePrintStream : PrintStream
		{
			public ConsolePrintStream (StreamOutputStream stream)
				: base (stream, true)
			{ }

			public override void close ()
			{
				// Console cannot be closed
				flush ();
			}
		}
	}
}


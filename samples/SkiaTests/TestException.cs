using System;

namespace XobotOS.Samples.SkiaTests
{
	public class TestException : Exception
	{
		public TestException (string message, params object[] args)
			: base(String.Format(message, args))
		{ }
	}
}


using Sharpen;

namespace libcore.util
{
	[Sharpen.Sharpened]
	public sealed class EmptyArray
	{
		private EmptyArray()
		{
		}

		public static readonly bool[] BOOLEAN = new bool[0];

		public static readonly byte[] BYTE = new byte[0];

		public static readonly char[] CHAR = new char[0];

		public static readonly double[] DOUBLE = new double[0];

		public static readonly int[] INT = new int[0];

		public static readonly System.Type[] CLASS = new System.Type[0];

		public static readonly object[] OBJECT = new object[0];

		public static readonly string[] STRING = new string[0];

		public static readonly System.Exception[] THROWABLE = new System.Exception[0];

		public static readonly java.lang.StackTraceElement[] STACK_TRACE_ELEMENT = new java.lang.StackTraceElement
			[0];
	}
}

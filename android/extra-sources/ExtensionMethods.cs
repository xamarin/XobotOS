using System;
using java.lang;

namespace Sharpen
{
	public static class ExtensionMethods
	{
		public static CharSequence SubSequence (this string str, int start, int length) {
			return CharSequenceProxy.Wrap (str.Substring (start, length));
		}
	}
}


using Sharpen;

namespace android.graphics
{
	/// <hide></hide>
	[Sharpen.Sharpened]
	public class TemporaryBuffer
	{
		public static char[] obtain(int len)
		{
			char[] buf;
			lock (typeof(android.graphics.TemporaryBuffer))
			{
				buf = sTemp;
				sTemp = null;
			}
			if (buf == null || buf.Length < len)
			{
				buf = new char[android.util.@internal.ArrayUtils.idealCharArraySize(len)];
			}
			return buf;
		}

		public static void recycle(char[] temp)
		{
			if (temp.Length > 1000)
			{
				return;
			}
			lock (typeof(android.graphics.TemporaryBuffer))
			{
				sTemp = temp;
			}
		}

		private static char[] sTemp = null;
	}
}

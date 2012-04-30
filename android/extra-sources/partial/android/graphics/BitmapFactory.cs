using System;
using System.IO;

namespace android.graphics
{
	partial class BitmapFactory
	{
		public static Bitmap decodeFile(string pathName, Options opts)
		{
			using (FileStream stream = File.OpenRead(pathName)) {
				byte[] contents = new byte[stream.Length];
				if (stream.Read (contents, 0, contents.Length) != contents.Length)
					throw new IOException("Failed to read bitmap.");
				return decodeByteArray(contents, 0, contents.Length, opts);
			}
		}

		public static Bitmap decodeFile(string pathName)
		{
			return decodeFile(pathName, null);
		}
	}
}


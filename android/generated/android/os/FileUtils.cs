using Sharpen;

namespace android.os
{
	[Sharpen.Stub]
	public class FileUtils
	{
		public const int S_IRWXU = 0x1c0;

		public const int S_IRUSR = 0x100;

		public const int S_IWUSR = 0x80;

		public const int S_IXUSR = 0x40;

		public const int S_IRWXG = 0x38;

		public const int S_IRGRP = 0x20;

		public const int S_IWGRP = 0x10;

		public const int S_IXGRP = 0x8;

		public const int S_IRWXO = 0x7;

		public const int S_IROTH = 0x4;

		public const int S_IWOTH = 0x2;

		public const int S_IXOTH = 0x1;

		[Sharpen.Stub]
		public sealed class FileStatus
		{
			public int dev;

			public int ino;

			public int mode;

			public int nlink;

			public int uid;

			public int gid;

			public int rdev;

			public long size;

			public int blksize;

			public long blocks;

			public long atime;

			public long mtime;

			public long ctime;
		}

		[Sharpen.Stub]
		public static bool getFileStatus(string path, android.os.FileUtils.FileStatus status
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static bool getFileStatusNative(string path, android.os.FileUtils.FileStatus
			 status)
		{
			throw new System.NotImplementedException();
		}

		private static readonly java.util.regex.Pattern SAFE_FILENAME_PATTERN = java.util.regex.Pattern
			.compile("[\\w%+,./=_-]+");

		[Sharpen.Stub]
		public static int setPermissions(string file, int mode, int uid, int gid)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int getPermissions(string file, int[] outPermissions)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int setUMask(int mask)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int getFatVolumeId(string mountPoint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static bool sync(java.io.FileOutputStream stream)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static bool copyFile(java.io.File srcFile, java.io.File destFile)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static bool copyToFile(java.io.InputStream inputStream, java.io.File destFile
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static bool isFilenameSafe(java.io.File file)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static string readTextFile(java.io.File file, int max, string ellipsis)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void stringToFile(string filename, string @string)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static long checksumCrc32(java.io.File file)
		{
			throw new System.NotImplementedException();
		}
	}
}

using Sharpen;

namespace android.os
{
	[Sharpen.Stub]
	public class Environment
	{
		internal const string TAG = "Environment";

		private static readonly java.io.File ROOT_DIRECTORY = getDirectory("ANDROID_ROOT"
			, "/system");

		internal const string SYSTEM_PROPERTY_EFS_ENABLED = "persist.security.efs.enabled";

		private static readonly object mLock = new object();

		private static volatile android.os.storage.StorageVolume mPrimaryVolume = null;

		[Sharpen.Stub]
		private static android.os.storage.StorageVolume getPrimaryVolume()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.io.File getRootDirectory()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.io.File getSystemSecureDirectory()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.io.File getSecureDataDirectory()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static bool isEncryptedFilesystemEnabled()
		{
			throw new System.NotImplementedException();
		}

		private static readonly java.io.File DATA_DIRECTORY = getDirectory("ANDROID_DATA"
			, "/data");

		private static readonly java.io.File SECURE_DATA_DIRECTORY = getDirectory("ANDROID_SECURE_DATA"
			, "/data/secure");

		private static readonly java.io.File EXTERNAL_STORAGE_DIRECTORY = getDirectory("EXTERNAL_STORAGE"
			, "/mnt/sdcard");

		private static readonly java.io.File EXTERNAL_STORAGE_ANDROID_DATA_DIRECTORY = new 
			java.io.File(new java.io.File(getDirectory("EXTERNAL_STORAGE", "/mnt/sdcard"), "Android"
			), "data");

		private static readonly java.io.File EXTERNAL_STORAGE_ANDROID_MEDIA_DIRECTORY = new 
			java.io.File(new java.io.File(getDirectory("EXTERNAL_STORAGE", "/mnt/sdcard"), "Android"
			), "media");

		private static readonly java.io.File EXTERNAL_STORAGE_ANDROID_OBB_DIRECTORY = new 
			java.io.File(new java.io.File(getDirectory("EXTERNAL_STORAGE", "/mnt/sdcard"), "Android"
			), "obb");

		private static readonly java.io.File DOWNLOAD_CACHE_DIRECTORY = getDirectory("DOWNLOAD_CACHE"
			, "/cache");

		[Sharpen.Stub]
		public static java.io.File getDataDirectory()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.io.File getExternalStorageDirectory()
		{
			throw new System.NotImplementedException();
		}

		public static string DIRECTORY_MUSIC = "Music";

		public static string DIRECTORY_PODCASTS = "Podcasts";

		public static string DIRECTORY_RINGTONES = "Ringtones";

		public static string DIRECTORY_ALARMS = "Alarms";

		public static string DIRECTORY_NOTIFICATIONS = "Notifications";

		public static string DIRECTORY_PICTURES = "Pictures";

		public static string DIRECTORY_MOVIES = "Movies";

		public static string DIRECTORY_DOWNLOADS = "Download";

		public static string DIRECTORY_DCIM = "DCIM";

		[Sharpen.Stub]
		public static java.io.File getExternalStoragePublicDirectory(string type)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.io.File getExternalStorageAndroidDataDir()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.io.File getExternalStorageAppDataDirectory(string packageName)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.io.File getExternalStorageAppMediaDirectory(string packageName
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.io.File getExternalStorageAppObbDirectory(string packageName)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.io.File getExternalStorageAppFilesDirectory(string packageName
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.io.File getExternalStorageAppCacheDirectory(string packageName
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.io.File getDownloadCacheDirectory()
		{
			throw new System.NotImplementedException();
		}

		public const string MEDIA_REMOVED = "removed";

		public const string MEDIA_UNMOUNTED = "unmounted";

		public const string MEDIA_CHECKING = "checking";

		public const string MEDIA_NOFS = "nofs";

		public const string MEDIA_MOUNTED = "mounted";

		public const string MEDIA_MOUNTED_READ_ONLY = "mounted_ro";

		public const string MEDIA_SHARED = "shared";

		public const string MEDIA_BAD_REMOVAL = "bad_removal";

		public const string MEDIA_UNMOUNTABLE = "unmountable";

		[Sharpen.Stub]
		public static string getExternalStorageState()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static bool isExternalStorageRemovable()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static bool isExternalStorageEmulated()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal static java.io.File getDirectory(string variableName, string defaultPath
			)
		{
			throw new System.NotImplementedException();
		}
	}
}

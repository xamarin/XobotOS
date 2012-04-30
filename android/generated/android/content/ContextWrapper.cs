using Sharpen;

namespace android.content
{
	/// <summary>
	/// Proxying implementation of Context that simply delegates all of its calls to
	/// another Context.
	/// </summary>
	/// <remarks>
	/// Proxying implementation of Context that simply delegates all of its calls to
	/// another Context.  Can be subclassed to modify behavior without changing
	/// the original Context.
	/// </remarks>
	[Sharpen.Sharpened]
	public class ContextWrapper : android.content.Context
	{
		internal android.content.Context mBase;

		public ContextWrapper(android.content.Context @base)
		{
			mBase = @base;
		}

		/// <summary>Set the base context for this ContextWrapper.</summary>
		/// <remarks>
		/// Set the base context for this ContextWrapper.  All calls will then be
		/// delegated to the base context.  Throws
		/// IllegalStateException if a base context has already been set.
		/// </remarks>
		/// <param name="base">The new base context for this wrapper.</param>
		protected internal virtual void attachBaseContext(android.content.Context @base)
		{
			if (mBase != null)
			{
				throw new System.InvalidOperationException("Base context already set");
			}
			mBase = @base;
		}

		/// <returns>the base context as set by the constructor or setBaseContext</returns>
		public virtual android.content.Context getBaseContext()
		{
			return mBase;
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override android.content.res.AssetManager getAssets()
		{
			return mBase.getAssets();
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override android.content.res.Resources getResources()
		{
			return mBase.getResources();
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override android.content.pm.PackageManager getPackageManager()
		{
			return mBase.getPackageManager();
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override android.content.ContentResolver getContentResolver()
		{
			return mBase.getContentResolver();
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override android.os.Looper getMainLooper()
		{
			return mBase.getMainLooper();
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override android.content.Context getApplicationContext()
		{
			return mBase.getApplicationContext();
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void setTheme(int resid)
		{
			mBase.setTheme(resid);
		}

		/// <hide></hide>
		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override int getThemeResId()
		{
			return mBase.getThemeResId();
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override android.content.res.Resources.Theme getTheme()
		{
			return mBase.getTheme();
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override java.lang.ClassLoader getClassLoader()
		{
			return mBase.getClassLoader();
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override string getPackageName()
		{
			return mBase.getPackageName();
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override android.content.pm.ApplicationInfo getApplicationInfo()
		{
			return mBase.getApplicationInfo();
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override string getPackageResourcePath()
		{
			return mBase.getPackageResourcePath();
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override string getPackageCodePath()
		{
			return mBase.getPackageCodePath();
		}

		/// <hide></hide>
		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override java.io.File getSharedPrefsFile(string name)
		{
			return mBase.getSharedPrefsFile(name);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override android.content.SharedPreferences getSharedPreferences(string name
			, int mode)
		{
			return mBase.getSharedPreferences(name, mode);
		}

		/// <exception cref="java.io.FileNotFoundException"></exception>
		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override java.io.FileInputStream openFileInput(string name)
		{
			return mBase.openFileInput(name);
		}

		/// <exception cref="java.io.FileNotFoundException"></exception>
		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override java.io.FileOutputStream openFileOutput(string name, int mode)
		{
			return mBase.openFileOutput(name, mode);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override bool deleteFile(string name)
		{
			return mBase.deleteFile(name);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override java.io.File getFileStreamPath(string name)
		{
			return mBase.getFileStreamPath(name);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override string[] fileList()
		{
			return mBase.fileList();
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override java.io.File getFilesDir()
		{
			return mBase.getFilesDir();
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override java.io.File getExternalFilesDir(string type)
		{
			return mBase.getExternalFilesDir(type);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override java.io.File getObbDir()
		{
			return mBase.getObbDir();
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override java.io.File getCacheDir()
		{
			return mBase.getCacheDir();
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override java.io.File getExternalCacheDir()
		{
			return mBase.getExternalCacheDir();
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override java.io.File getDir(string name, int mode)
		{
			return mBase.getDir(name, mode);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override android.database.sqlite.SQLiteDatabase openOrCreateDatabase(string
			 name, int mode, android.database.sqlite.SQLiteDatabase.CursorFactory factory)
		{
			return mBase.openOrCreateDatabase(name, mode, factory);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override android.database.sqlite.SQLiteDatabase openOrCreateDatabase(string
			 name, int mode, android.database.sqlite.SQLiteDatabase.CursorFactory factory, android.database.DatabaseErrorHandler
			 errorHandler)
		{
			return mBase.openOrCreateDatabase(name, mode, factory, errorHandler);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override bool deleteDatabase(string name)
		{
			return mBase.deleteDatabase(name);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override java.io.File getDatabasePath(string name)
		{
			return mBase.getDatabasePath(name);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override string[] databaseList()
		{
			return mBase.databaseList();
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override android.graphics.drawable.Drawable getWallpaper()
		{
			return mBase.getWallpaper();
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override android.graphics.drawable.Drawable peekWallpaper()
		{
			return mBase.peekWallpaper();
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override int getWallpaperDesiredMinimumWidth()
		{
			return mBase.getWallpaperDesiredMinimumWidth();
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override int getWallpaperDesiredMinimumHeight()
		{
			return mBase.getWallpaperDesiredMinimumHeight();
		}

		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void setWallpaper(android.graphics.Bitmap bitmap)
		{
			mBase.setWallpaper(bitmap);
		}

		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void setWallpaper(java.io.InputStream data)
		{
			mBase.setWallpaper(data);
		}

		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void clearWallpaper()
		{
			mBase.clearWallpaper();
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void startActivity(android.content.Intent intent)
		{
			mBase.startActivity(intent);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void startActivities(android.content.Intent[] intents)
		{
			mBase.startActivities(intents);
		}

		/// <exception cref="android.content.IntentSender.SendIntentException"></exception>
		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void startIntentSender(android.content.IntentSender intent, android.content.Intent
			 fillInIntent, int flagsMask, int flagsValues, int extraFlags)
		{
			mBase.startIntentSender(intent, fillInIntent, flagsMask, flagsValues, extraFlags);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void sendBroadcast(android.content.Intent intent)
		{
			mBase.sendBroadcast(intent);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void sendBroadcast(android.content.Intent intent, string receiverPermission
			)
		{
			mBase.sendBroadcast(intent, receiverPermission);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void sendOrderedBroadcast(android.content.Intent intent, string receiverPermission
			)
		{
			mBase.sendOrderedBroadcast(intent, receiverPermission);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void sendOrderedBroadcast(android.content.Intent intent, string receiverPermission
			, android.content.BroadcastReceiver resultReceiver, android.os.Handler scheduler
			, int initialCode, string initialData, android.os.Bundle initialExtras)
		{
			mBase.sendOrderedBroadcast(intent, receiverPermission, resultReceiver, scheduler, 
				initialCode, initialData, initialExtras);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void sendStickyBroadcast(android.content.Intent intent)
		{
			mBase.sendStickyBroadcast(intent);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void sendStickyOrderedBroadcast(android.content.Intent intent, android.content.BroadcastReceiver
			 resultReceiver, android.os.Handler scheduler, int initialCode, string initialData
			, android.os.Bundle initialExtras)
		{
			mBase.sendStickyOrderedBroadcast(intent, resultReceiver, scheduler, initialCode, 
				initialData, initialExtras);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void removeStickyBroadcast(android.content.Intent intent)
		{
			mBase.removeStickyBroadcast(intent);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override android.content.Intent registerReceiver(android.content.BroadcastReceiver
			 receiver, android.content.IntentFilter filter)
		{
			return mBase.registerReceiver(receiver, filter);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override android.content.Intent registerReceiver(android.content.BroadcastReceiver
			 receiver, android.content.IntentFilter filter, string broadcastPermission, android.os.Handler
			 scheduler)
		{
			return mBase.registerReceiver(receiver, filter, broadcastPermission, scheduler);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void unregisterReceiver(android.content.BroadcastReceiver receiver
			)
		{
			mBase.unregisterReceiver(receiver);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override android.content.ComponentName startService(android.content.Intent
			 service)
		{
			return mBase.startService(service);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override bool stopService(android.content.Intent name)
		{
			return mBase.stopService(name);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override bool bindService(android.content.Intent service, android.content.ServiceConnection
			 conn, int flags)
		{
			return mBase.bindService(service, conn, flags);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void unbindService(android.content.ServiceConnection conn)
		{
			mBase.unbindService(conn);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override bool startInstrumentation(android.content.ComponentName className
			, string profileFile, android.os.Bundle arguments)
		{
			return mBase.startInstrumentation(className, profileFile, arguments);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override object getSystemService(string name)
		{
			return mBase.getSystemService(name);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override int checkPermission(string permission, int pid, int uid)
		{
			return mBase.checkPermission(permission, pid, uid);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override int checkCallingPermission(string permission)
		{
			return mBase.checkCallingPermission(permission);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override int checkCallingOrSelfPermission(string permission)
		{
			return mBase.checkCallingOrSelfPermission(permission);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void enforcePermission(string permission, int pid, int uid, string
			 message)
		{
			mBase.enforcePermission(permission, pid, uid, message);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void enforceCallingPermission(string permission, string message)
		{
			mBase.enforceCallingPermission(permission, message);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void enforceCallingOrSelfPermission(string permission, string message
			)
		{
			mBase.enforceCallingOrSelfPermission(permission, message);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void grantUriPermission(string toPackage, System.Uri uri, int modeFlags
			)
		{
			mBase.grantUriPermission(toPackage, uri, modeFlags);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void revokeUriPermission(System.Uri uri, int modeFlags)
		{
			mBase.revokeUriPermission(uri, modeFlags);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override int checkUriPermission(System.Uri uri, int pid, int uid, int modeFlags
			)
		{
			return mBase.checkUriPermission(uri, pid, uid, modeFlags);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override int checkCallingUriPermission(System.Uri uri, int modeFlags)
		{
			return mBase.checkCallingUriPermission(uri, modeFlags);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override int checkCallingOrSelfUriPermission(System.Uri uri, int modeFlags
			)
		{
			return mBase.checkCallingOrSelfUriPermission(uri, modeFlags);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override int checkUriPermission(System.Uri uri, string readPermission, string
			 writePermission, int pid, int uid, int modeFlags)
		{
			return mBase.checkUriPermission(uri, readPermission, writePermission, pid, uid, modeFlags
				);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void enforceUriPermission(System.Uri uri, int pid, int uid, int modeFlags
			, string message)
		{
			mBase.enforceUriPermission(uri, pid, uid, modeFlags, message);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void enforceCallingUriPermission(System.Uri uri, int modeFlags, string
			 message)
		{
			mBase.enforceCallingUriPermission(uri, modeFlags, message);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void enforceCallingOrSelfUriPermission(System.Uri uri, int modeFlags
			, string message)
		{
			mBase.enforceCallingOrSelfUriPermission(uri, modeFlags, message);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void enforceUriPermission(System.Uri uri, string readPermission, 
			string writePermission, int pid, int uid, int modeFlags, string message)
		{
			mBase.enforceUriPermission(uri, readPermission, writePermission, pid, uid, modeFlags
				, message);
		}

		/// <exception cref="android.content.pm.PackageManager.NameNotFoundException"></exception>
		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override android.content.Context createPackageContext(string packageName, 
			int flags)
		{
			return mBase.createPackageContext(packageName, flags);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override bool isRestricted()
		{
			return mBase.isRestricted();
		}
	}
}

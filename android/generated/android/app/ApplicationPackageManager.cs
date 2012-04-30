using Sharpen;

namespace android.app
{
	[Sharpen.Sharpened]
	internal sealed partial class ApplicationPackageManager : android.content.pm.PackageManager
	{
		internal const string TAG = "ApplicationPackageManager";

		internal const bool DEBUG = false;

		internal const bool DEBUG_ICONS = false;

		/// <exception cref="android.content.pm.PackageManager.NameNotFoundException"></exception>
		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override android.content.pm.PackageInfo getPackageInfo(string packageName, 
			int flags)
		{
			try
			{
				android.content.pm.PackageInfo pi = mPM.getPackageInfo(packageName, flags);
				if (pi != null)
				{
					return pi;
				}
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("Package manager has died", e);
			}
			throw new android.content.pm.PackageManager.NameNotFoundException(packageName);
		}

		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override string[] currentToCanonicalPackageNames(string[] names)
		{
			try
			{
				return mPM.currentToCanonicalPackageNames(names);
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("Package manager has died", e);
			}
		}

		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override string[] canonicalToCurrentPackageNames(string[] names)
		{
			try
			{
				return mPM.canonicalToCurrentPackageNames(names);
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("Package manager has died", e);
			}
		}

		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override android.content.Intent getLaunchIntentForPackage(string packageName
			)
		{
			// First see if the package has an INFO activity; the existence of
			// such an activity is implied to be the desired front-door for the
			// overall package (such as if it has multiple launcher entries).
			android.content.Intent intentToResolve = new android.content.Intent(android.content.Intent
				.ACTION_MAIN);
			intentToResolve.addCategory(android.content.Intent.CATEGORY_INFO);
			intentToResolve.setPackage(packageName);
			java.util.List<android.content.pm.ResolveInfo> ris = queryIntentActivities(intentToResolve
				, 0);
			// Otherwise, try to find a main launcher activity.
			if (ris == null || ris.size() <= 0)
			{
				// reuse the intent instance
				intentToResolve.removeCategory(android.content.Intent.CATEGORY_INFO);
				intentToResolve.addCategory(android.content.Intent.CATEGORY_LAUNCHER);
				intentToResolve.setPackage(packageName);
				ris = queryIntentActivities(intentToResolve, 0);
			}
			if (ris == null || ris.size() <= 0)
			{
				return null;
			}
			android.content.Intent intent = new android.content.Intent(intentToResolve);
			intent.setFlags(android.content.Intent.FLAG_ACTIVITY_NEW_TASK);
			intent.setClassName(ris.get(0).activityInfo.packageName, ris.get(0).activityInfo.
				name);
			return intent;
		}

		/// <exception cref="android.content.pm.PackageManager.NameNotFoundException"></exception>
		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override int[] getPackageGids(string packageName)
		{
			try
			{
				int[] gids = mPM.getPackageGids(packageName);
				if (gids == null || gids.Length > 0)
				{
					return gids;
				}
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("Package manager has died", e);
			}
			throw new android.content.pm.PackageManager.NameNotFoundException(packageName);
		}

		/// <exception cref="android.content.pm.PackageManager.NameNotFoundException"></exception>
		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override android.content.pm.PermissionInfo getPermissionInfo(string name, 
			int flags)
		{
			try
			{
				android.content.pm.PermissionInfo pi = mPM.getPermissionInfo(name, flags);
				if (pi != null)
				{
					return pi;
				}
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("Package manager has died", e);
			}
			throw new android.content.pm.PackageManager.NameNotFoundException(name);
		}

		/// <exception cref="android.content.pm.PackageManager.NameNotFoundException"></exception>
		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override java.util.List<android.content.pm.PermissionInfo> queryPermissionsByGroup
			(string group, int flags)
		{
			try
			{
				java.util.List<android.content.pm.PermissionInfo> pi = mPM.queryPermissionsByGroup
					(group, flags);
				if (pi != null)
				{
					return pi;
				}
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("Package manager has died", e);
			}
			throw new android.content.pm.PackageManager.NameNotFoundException(group);
		}

		/// <exception cref="android.content.pm.PackageManager.NameNotFoundException"></exception>
		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override android.content.pm.PermissionGroupInfo getPermissionGroupInfo(string
			 name, int flags)
		{
			try
			{
				android.content.pm.PermissionGroupInfo pgi = mPM.getPermissionGroupInfo(name, flags
					);
				if (pgi != null)
				{
					return pgi;
				}
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("Package manager has died", e);
			}
			throw new android.content.pm.PackageManager.NameNotFoundException(name);
		}

		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override java.util.List<android.content.pm.PermissionGroupInfo> getAllPermissionGroups
			(int flags)
		{
			try
			{
				return mPM.getAllPermissionGroups(flags);
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("Package manager has died", e);
			}
		}

		/// <exception cref="android.content.pm.PackageManager.NameNotFoundException"></exception>
		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override android.content.pm.ApplicationInfo getApplicationInfo(string packageName
			, int flags)
		{
			try
			{
				android.content.pm.ApplicationInfo ai = mPM.getApplicationInfo(packageName, flags
					);
				if (ai != null)
				{
					return ai;
				}
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("Package manager has died", e);
			}
			throw new android.content.pm.PackageManager.NameNotFoundException(packageName);
		}

		/// <exception cref="android.content.pm.PackageManager.NameNotFoundException"></exception>
		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override android.content.pm.ActivityInfo getActivityInfo(android.content.ComponentName
			 className, int flags)
		{
			try
			{
				android.content.pm.ActivityInfo ai = mPM.getActivityInfo(className, flags);
				if (ai != null)
				{
					return ai;
				}
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("Package manager has died", e);
			}
			throw new android.content.pm.PackageManager.NameNotFoundException(className.ToString
				());
		}

		/// <exception cref="android.content.pm.PackageManager.NameNotFoundException"></exception>
		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override android.content.pm.ActivityInfo getReceiverInfo(android.content.ComponentName
			 className, int flags)
		{
			try
			{
				android.content.pm.ActivityInfo ai = mPM.getReceiverInfo(className, flags);
				if (ai != null)
				{
					return ai;
				}
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("Package manager has died", e);
			}
			throw new android.content.pm.PackageManager.NameNotFoundException(className.ToString
				());
		}

		/// <exception cref="android.content.pm.PackageManager.NameNotFoundException"></exception>
		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override android.content.pm.ServiceInfo getServiceInfo(android.content.ComponentName
			 className, int flags)
		{
			try
			{
				android.content.pm.ServiceInfo si = mPM.getServiceInfo(className, flags);
				if (si != null)
				{
					return si;
				}
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("Package manager has died", e);
			}
			throw new android.content.pm.PackageManager.NameNotFoundException(className.ToString
				());
		}

		/// <exception cref="android.content.pm.PackageManager.NameNotFoundException"></exception>
		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override android.content.pm.ProviderInfo getProviderInfo(android.content.ComponentName
			 className, int flags)
		{
			try
			{
				android.content.pm.ProviderInfo pi = mPM.getProviderInfo(className, flags);
				if (pi != null)
				{
					return pi;
				}
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("Package manager has died", e);
			}
			throw new android.content.pm.PackageManager.NameNotFoundException(className.ToString
				());
		}

		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override string[] getSystemSharedLibraryNames()
		{
			try
			{
				return mPM.getSystemSharedLibraryNames();
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("Package manager has died", e);
			}
		}

		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override android.content.pm.FeatureInfo[] getSystemAvailableFeatures()
		{
			try
			{
				return mPM.getSystemAvailableFeatures();
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("Package manager has died", e);
			}
		}

		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override bool hasSystemFeature(string name)
		{
			try
			{
				return mPM.hasSystemFeature(name);
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("Package manager has died", e);
			}
		}

		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override int checkPermission(string permName, string pkgName)
		{
			try
			{
				return mPM.checkPermission(permName, pkgName);
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("Package manager has died", e);
			}
		}

		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override bool addPermission(android.content.pm.PermissionInfo info)
		{
			try
			{
				return mPM.addPermission(info);
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("Package manager has died", e);
			}
		}

		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override bool addPermissionAsync(android.content.pm.PermissionInfo info)
		{
			try
			{
				return mPM.addPermissionAsync(info);
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("Package manager has died", e);
			}
		}

		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override void removePermission(string name)
		{
			try
			{
				mPM.removePermission(name);
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("Package manager has died", e);
			}
		}

		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override int checkSignatures(string pkg1, string pkg2)
		{
			try
			{
				return mPM.checkSignatures(pkg1, pkg2);
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("Package manager has died", e);
			}
		}

		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override int checkSignatures(int uid1, int uid2)
		{
			try
			{
				return mPM.checkUidSignatures(uid1, uid2);
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("Package manager has died", e);
			}
		}

		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override string[] getPackagesForUid(int uid)
		{
			try
			{
				return mPM.getPackagesForUid(uid);
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("Package manager has died", e);
			}
		}

		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override string getNameForUid(int uid)
		{
			try
			{
				return mPM.getNameForUid(uid);
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("Package manager has died", e);
			}
		}

		/// <exception cref="android.content.pm.PackageManager.NameNotFoundException"></exception>
		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override int getUidForSharedUser(string sharedUserName)
		{
			try
			{
				int uid = mPM.getUidForSharedUser(sharedUserName);
				if (uid != -1)
				{
					return uid;
				}
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("Package manager has died", e);
			}
			throw new android.content.pm.PackageManager.NameNotFoundException("No shared userid for user:"
				 + sharedUserName);
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override java.util.List<android.content.pm.PackageInfo> getInstalledPackages
			(int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override java.util.List<android.content.pm.ApplicationInfo> getInstalledApplications
			(int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override android.content.pm.ResolveInfo resolveActivity(android.content.Intent
			 intent, int flags)
		{
			try
			{
				return mPM.resolveIntent(intent, intent.resolveTypeIfNeeded(mContext.getContentResolver
					()), flags);
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("Package manager has died", e);
			}
		}

		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override java.util.List<android.content.pm.ResolveInfo> queryIntentActivities
			(android.content.Intent intent, int flags)
		{
			try
			{
				return mPM.queryIntentActivities(intent, intent.resolveTypeIfNeeded(mContext.getContentResolver
					()), flags);
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("Package manager has died", e);
			}
		}

		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override java.util.List<android.content.pm.ResolveInfo> queryIntentActivityOptions
			(android.content.ComponentName caller, android.content.Intent[] specifics, android.content.Intent
			 intent, int flags)
		{
			android.content.ContentResolver resolver = mContext.getContentResolver();
			string[] specificTypes = null;
			if (specifics != null)
			{
				int N = specifics.Length;
				{
					for (int i = 0; i < N; i++)
					{
						android.content.Intent sp = specifics[i];
						if (sp != null)
						{
							string t = sp.resolveTypeIfNeeded(resolver);
							if (t != null)
							{
								if (specificTypes == null)
								{
									specificTypes = new string[N];
								}
								specificTypes[i] = t;
							}
						}
					}
				}
			}
			try
			{
				return mPM.queryIntentActivityOptions(caller, specifics, specificTypes, intent, intent
					.resolveTypeIfNeeded(resolver), flags);
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("Package manager has died", e);
			}
		}

		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override java.util.List<android.content.pm.ResolveInfo> queryBroadcastReceivers
			(android.content.Intent intent, int flags)
		{
			try
			{
				return mPM.queryIntentReceivers(intent, intent.resolveTypeIfNeeded(mContext.getContentResolver
					()), flags);
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("Package manager has died", e);
			}
		}

		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override android.content.pm.ResolveInfo resolveService(android.content.Intent
			 intent, int flags)
		{
			try
			{
				return mPM.resolveService(intent, intent.resolveTypeIfNeeded(mContext.getContentResolver
					()), flags);
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("Package manager has died", e);
			}
		}

		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override java.util.List<android.content.pm.ResolveInfo> queryIntentServices
			(android.content.Intent intent, int flags)
		{
			try
			{
				return mPM.queryIntentServices(intent, intent.resolveTypeIfNeeded(mContext.getContentResolver
					()), flags);
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("Package manager has died", e);
			}
		}

		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override android.content.pm.ProviderInfo resolveContentProvider(string name
			, int flags)
		{
			try
			{
				return mPM.resolveContentProvider(name, flags);
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("Package manager has died", e);
			}
		}

		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override java.util.List<android.content.pm.ProviderInfo> queryContentProviders
			(string processName, int uid, int flags)
		{
			try
			{
				return mPM.queryContentProviders(processName, uid, flags);
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("Package manager has died", e);
			}
		}

		/// <exception cref="android.content.pm.PackageManager.NameNotFoundException"></exception>
		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override android.content.pm.InstrumentationInfo getInstrumentationInfo(android.content.ComponentName
			 className, int flags)
		{
			try
			{
				android.content.pm.InstrumentationInfo ii = mPM.getInstrumentationInfo(className, 
					flags);
				if (ii != null)
				{
					return ii;
				}
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("Package manager has died", e);
			}
			throw new android.content.pm.PackageManager.NameNotFoundException(className.ToString
				());
		}

		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override java.util.List<android.content.pm.InstrumentationInfo> queryInstrumentation
			(string targetPackage, int flags)
		{
			try
			{
				return mPM.queryInstrumentation(targetPackage, flags);
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("Package manager has died", e);
			}
		}

		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override android.graphics.drawable.Drawable getDrawable(string packageName
			, int resid, android.content.pm.ApplicationInfo appInfo)
		{
			android.app.ApplicationPackageManager.ResourceName name = new android.app.ApplicationPackageManager
				.ResourceName(packageName, resid);
			android.graphics.drawable.Drawable dr = getCachedIcon(name);
			if (dr != null)
			{
				return dr;
			}
			if (appInfo == null)
			{
				try
				{
					appInfo = getApplicationInfo(packageName, 0);
				}
				catch (android.content.pm.PackageManager.NameNotFoundException)
				{
					return null;
				}
			}
			try
			{
				android.content.res.Resources r = getResourcesForApplication(appInfo);
				dr = r.getDrawable(resid);
				if (false)
				{
					java.lang.RuntimeException e = new java.lang.RuntimeException("here");
					XobotOS.Runtime.Util.FillInStackTrace(e);
					android.util.Log.w(TAG, "Getting drawable 0x" + Sharpen.Util.IntToHexString(resid
						) + " from package " + packageName + ": app scale=" + r.getCompatibilityInfo().applicationScale
						 + ", caller scale=" + mContext.getResources().getCompatibilityInfo().applicationScale
						, e);
				}
				putCachedIcon(name, dr);
				return dr;
			}
			catch (android.content.pm.PackageManager.NameNotFoundException)
			{
				android.util.Log.w("PackageManager", "Failure retrieving resources for" + appInfo
					.packageName);
			}
			catch (android.content.res.Resources.NotFoundException e)
			{
				android.util.Log.w("PackageManager", "Failure retrieving resources for" + appInfo
					.packageName + ": " + e.Message);
			}
			catch (java.lang.RuntimeException e)
			{
				// If an exception was thrown, fall through to return
				// default icon.
				android.util.Log.w("PackageManager", "Failure retrieving icon 0x" + Sharpen.Util.IntToHexString
					(resid) + " in package " + packageName, e);
			}
			return null;
		}

		/// <exception cref="android.content.pm.PackageManager.NameNotFoundException"></exception>
		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override android.graphics.drawable.Drawable getActivityIcon(android.content.ComponentName
			 activityName)
		{
			return getActivityInfo(activityName, 0).loadIcon(this);
		}

		/// <exception cref="android.content.pm.PackageManager.NameNotFoundException"></exception>
		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override android.graphics.drawable.Drawable getActivityIcon(android.content.Intent
			 intent)
		{
			if (intent.getComponent() != null)
			{
				return getActivityIcon(intent.getComponent());
			}
			android.content.pm.ResolveInfo info = resolveActivity(intent, android.content.pm.PackageManager
				.MATCH_DEFAULT_ONLY);
			if (info != null)
			{
				return info.activityInfo.loadIcon(this);
			}
			throw new android.content.pm.PackageManager.NameNotFoundException(intent.toURI());
		}

		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override android.graphics.drawable.Drawable getDefaultActivityIcon()
		{
			return android.content.res.Resources.getSystem().getDrawable(android.@internal.R.
				drawable.sym_def_app_icon);
		}

		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override android.graphics.drawable.Drawable getApplicationIcon(android.content.pm.ApplicationInfo
			 info)
		{
			return info.loadIcon(this);
		}

		/// <exception cref="android.content.pm.PackageManager.NameNotFoundException"></exception>
		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override android.graphics.drawable.Drawable getApplicationIcon(string packageName
			)
		{
			return getApplicationIcon(getApplicationInfo(packageName, 0));
		}

		/// <exception cref="android.content.pm.PackageManager.NameNotFoundException"></exception>
		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override android.graphics.drawable.Drawable getActivityLogo(android.content.ComponentName
			 activityName)
		{
			return getActivityInfo(activityName, 0).loadLogo(this);
		}

		/// <exception cref="android.content.pm.PackageManager.NameNotFoundException"></exception>
		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override android.graphics.drawable.Drawable getActivityLogo(android.content.Intent
			 intent)
		{
			if (intent.getComponent() != null)
			{
				return getActivityLogo(intent.getComponent());
			}
			android.content.pm.ResolveInfo info = resolveActivity(intent, android.content.pm.PackageManager
				.MATCH_DEFAULT_ONLY);
			if (info != null)
			{
				return info.activityInfo.loadLogo(this);
			}
			throw new android.content.pm.PackageManager.NameNotFoundException(intent.toUri(0)
				);
		}

		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override android.graphics.drawable.Drawable getApplicationLogo(android.content.pm.ApplicationInfo
			 info)
		{
			return info.loadLogo(this);
		}

		/// <exception cref="android.content.pm.PackageManager.NameNotFoundException"></exception>
		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override android.graphics.drawable.Drawable getApplicationLogo(string packageName
			)
		{
			return getApplicationLogo(getApplicationInfo(packageName, 0));
		}

		/// <exception cref="android.content.pm.PackageManager.NameNotFoundException"></exception>
		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override android.content.res.Resources getResourcesForActivity(android.content.ComponentName
			 activityName)
		{
			return getResourcesForApplication(getActivityInfo(activityName, 0).applicationInfo
				);
		}

		/// <exception cref="android.content.pm.PackageManager.NameNotFoundException"></exception>
		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override android.content.res.Resources getResourcesForApplication(string appPackageName
			)
		{
			return getResourcesForApplication(getApplicationInfo(appPackageName, 0));
		}

		internal int mCachedSafeMode = -1;

		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override bool isSafeMode()
		{
			try
			{
				if (mCachedSafeMode < 0)
				{
					mCachedSafeMode = mPM.isSafeMode() ? 1 : 0;
				}
				return mCachedSafeMode != 0;
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException("Package manager has died", e);
			}
		}

		internal static void configurationChanged()
		{
			lock (sSync)
			{
				sIconCache.clear();
				sStringCache.clear();
			}
		}

		internal ApplicationPackageManager(android.app.ContextImpl context, android.content.pm.IPackageManager
			 pm)
		{
			mContext = context;
			mPM = pm;
		}

		private android.graphics.drawable.Drawable getCachedIcon(android.app.ApplicationPackageManager
			.ResourceName name)
		{
			lock (sSync)
			{
				java.lang.@ref.WeakReference<android.graphics.drawable.Drawable> wr = sIconCache.
					get(name);
				if (wr != null)
				{
					// we have the activity
					android.graphics.drawable.Drawable dr = wr.get();
					if (dr != null)
					{
						return dr;
					}
					// our entry has been purged
					sIconCache.remove(name);
				}
			}
			return null;
		}

		private void putCachedIcon(android.app.ApplicationPackageManager.ResourceName name
			, android.graphics.drawable.Drawable dr)
		{
			lock (sSync)
			{
				sIconCache.put(name, new java.lang.@ref.WeakReference<android.graphics.drawable.Drawable
					>(dr));
			}
		}

		[Sharpen.Stub]
		internal static void handlePackageBroadcast(int cmd, string[] pkgList, bool hasPkgInfo
			)
		{
			throw new System.NotImplementedException();
		}

		private sealed class ResourceName
		{
			internal readonly string packageName;

			internal readonly int iconId;

			internal ResourceName(string _packageName, int _iconId)
			{
				//Log.i(TAG, "Removing cached drawable for " + nm);
				//Log.i(TAG, "Removing cached string for " + nm);
				// Schedule an immediate gc.
				packageName = _packageName;
				iconId = _iconId;
			}

			internal ResourceName(android.content.pm.ApplicationInfo aInfo, int _iconId) : this
				(aInfo.packageName, _iconId)
			{
			}

			internal ResourceName(android.content.pm.ComponentInfo cInfo, int _iconId) : this
				(cInfo.applicationInfo.packageName, _iconId)
			{
			}

			internal ResourceName(android.content.pm.ResolveInfo rInfo, int _iconId) : this(rInfo
				.activityInfo.applicationInfo.packageName, _iconId)
			{
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override bool Equals(object o)
			{
				if (this == o)
				{
					return true;
				}
				if (o == null || GetType() != o.GetType())
				{
					return false;
				}
				android.app.ApplicationPackageManager.ResourceName that = (android.app.ApplicationPackageManager
					.ResourceName)o;
				if (iconId != that.iconId)
				{
					return false;
				}
				return !(packageName != null ? !packageName.Equals(that.packageName) : that.packageName
					 != null);
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override int GetHashCode()
			{
				int result;
				result = packageName.GetHashCode();
				result = 31 * result + iconId;
				return result;
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override string ToString()
			{
				return "{ResourceName " + packageName + " / " + iconId + "}";
			}
		}

		private java.lang.CharSequence getCachedString(android.app.ApplicationPackageManager
			.ResourceName name)
		{
			lock (sSync)
			{
				java.lang.@ref.WeakReference<java.lang.CharSequence> wr = sStringCache.get(name);
				if (wr != null)
				{
					// we have the activity
					java.lang.CharSequence cs = wr.get();
					if (cs != null)
					{
						return cs;
					}
					// our entry has been purged
					sStringCache.remove(name);
				}
			}
			return null;
		}

		private void putCachedString(android.app.ApplicationPackageManager.ResourceName name
			, java.lang.CharSequence cs)
		{
			lock (sSync)
			{
				sStringCache.put(name, new java.lang.@ref.WeakReference<java.lang.CharSequence>(cs
					));
			}
		}

		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override java.lang.CharSequence getText(string packageName, int resid, android.content.pm.ApplicationInfo
			 appInfo)
		{
			android.app.ApplicationPackageManager.ResourceName name = new android.app.ApplicationPackageManager
				.ResourceName(packageName, resid);
			java.lang.CharSequence text = getCachedString(name);
			if (text != null)
			{
				return text;
			}
			if (appInfo == null)
			{
				try
				{
					appInfo = getApplicationInfo(packageName, 0);
				}
				catch (android.content.pm.PackageManager.NameNotFoundException)
				{
					return null;
				}
			}
			try
			{
				android.content.res.Resources r = getResourcesForApplication(appInfo);
				text = r.getText(resid);
				putCachedString(name, text);
				return text;
			}
			catch (android.content.pm.PackageManager.NameNotFoundException)
			{
				android.util.Log.w("PackageManager", "Failure retrieving resources for" + appInfo
					.packageName);
			}
			catch (java.lang.RuntimeException e)
			{
				// If an exception was thrown, fall through to return
				// default icon.
				android.util.Log.w("PackageManager", "Failure retrieving text 0x" + Sharpen.Util.IntToHexString
					(resid) + " in package " + packageName, e);
			}
			return null;
		}

		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override android.content.res.XmlResourceParser getXml(string packageName, 
			int resid, android.content.pm.ApplicationInfo appInfo)
		{
			if (appInfo == null)
			{
				try
				{
					appInfo = getApplicationInfo(packageName, 0);
				}
				catch (android.content.pm.PackageManager.NameNotFoundException)
				{
					return null;
				}
			}
			try
			{
				android.content.res.Resources r = getResourcesForApplication(appInfo);
				return r.getXml(resid);
			}
			catch (java.lang.RuntimeException e)
			{
				// If an exception was thrown, fall through to return
				// default icon.
				android.util.Log.w("PackageManager", "Failure retrieving xml 0x" + Sharpen.Util.IntToHexString
					(resid) + " in package " + packageName, e);
			}
			catch (android.content.pm.PackageManager.NameNotFoundException)
			{
				android.util.Log.w("PackageManager", "Failure retrieving resources for " + appInfo
					.packageName);
			}
			return null;
		}

		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override java.lang.CharSequence getApplicationLabel(android.content.pm.ApplicationInfo
			 info)
		{
			return info.loadLabel(this);
		}

		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override void installPackage(System.Uri packageURI, android.content.pm.IPackageInstallObserver
			 observer, int flags, string installerPackageName)
		{
			try
			{
				mPM.installPackage(packageURI, observer, flags, installerPackageName);
			}
			catch (android.os.RemoteException)
			{
			}
		}

		// Should never happen!
		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override void installPackageWithVerification(System.Uri packageURI, android.content.pm.IPackageInstallObserver
			 observer, int flags, string installerPackageName, System.Uri verificationURI, android.content.pm.ManifestDigest
			 manifestDigest)
		{
			try
			{
				mPM.installPackageWithVerification(packageURI, observer, flags, installerPackageName
					, verificationURI, manifestDigest);
			}
			catch (android.os.RemoteException)
			{
			}
		}

		// Should never happen!
		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override void verifyPendingInstall(int id, int response)
		{
			try
			{
				mPM.verifyPendingInstall(id, response);
			}
			catch (android.os.RemoteException)
			{
			}
		}

		// Should never happen!
		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override void setInstallerPackageName(string targetPackage, string installerPackageName
			)
		{
			try
			{
				mPM.setInstallerPackageName(targetPackage, installerPackageName);
			}
			catch (android.os.RemoteException)
			{
			}
		}

		// Should never happen!
		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override void movePackage(string packageName, android.content.pm.IPackageMoveObserver
			 observer, int flags)
		{
			try
			{
				mPM.movePackage(packageName, observer, flags);
			}
			catch (android.os.RemoteException)
			{
			}
		}

		// Should never happen!
		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override string getInstallerPackageName(string packageName)
		{
			try
			{
				return mPM.getInstallerPackageName(packageName);
			}
			catch (android.os.RemoteException)
			{
			}
			// Should never happen!
			return null;
		}

		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override void deletePackage(string packageName, android.content.pm.IPackageDeleteObserver
			 observer, int flags)
		{
			try
			{
				mPM.deletePackage(packageName, observer, flags);
			}
			catch (android.os.RemoteException)
			{
			}
		}

		// Should never happen!
		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override void clearApplicationUserData(string packageName, android.content.pm.IPackageDataObserver
			 observer)
		{
			try
			{
				mPM.clearApplicationUserData(packageName, observer);
			}
			catch (android.os.RemoteException)
			{
			}
		}

		// Should never happen!
		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override void deleteApplicationCacheFiles(string packageName, android.content.pm.IPackageDataObserver
			 observer)
		{
			try
			{
				mPM.deleteApplicationCacheFiles(packageName, observer);
			}
			catch (android.os.RemoteException)
			{
			}
		}

		// Should never happen!
		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override void freeStorageAndNotify(long idealStorageSize, android.content.pm.IPackageDataObserver
			 observer)
		{
			try
			{
				mPM.freeStorageAndNotify(idealStorageSize, observer);
			}
			catch (android.os.RemoteException)
			{
			}
		}

		// Should never happen!
		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override void freeStorage(long freeStorageSize, android.content.IntentSender
			 pi)
		{
			try
			{
				mPM.freeStorage(freeStorageSize, pi);
			}
			catch (android.os.RemoteException)
			{
			}
		}

		// Should never happen!
		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override void getPackageSizeInfo(string packageName, android.content.pm.IPackageStatsObserver
			 observer)
		{
			try
			{
				mPM.getPackageSizeInfo(packageName, observer);
			}
			catch (android.os.RemoteException)
			{
			}
		}

		// Should never happen!
		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override void addPackageToPreferred(string packageName)
		{
			try
			{
				mPM.addPackageToPreferred(packageName);
			}
			catch (android.os.RemoteException)
			{
			}
		}

		// Should never happen!
		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override void removePackageFromPreferred(string packageName)
		{
			try
			{
				mPM.removePackageFromPreferred(packageName);
			}
			catch (android.os.RemoteException)
			{
			}
		}

		// Should never happen!
		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override java.util.List<android.content.pm.PackageInfo> getPreferredPackages
			(int flags)
		{
			try
			{
				return mPM.getPreferredPackages(flags);
			}
			catch (android.os.RemoteException)
			{
			}
			// Should never happen!
			return new java.util.ArrayList<android.content.pm.PackageInfo>();
		}

		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override void addPreferredActivity(android.content.IntentFilter filter, int
			 match, android.content.ComponentName[] set, android.content.ComponentName activity
			)
		{
			try
			{
				mPM.addPreferredActivity(filter, match, set, activity);
			}
			catch (android.os.RemoteException)
			{
			}
		}

		// Should never happen!
		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override void replacePreferredActivity(android.content.IntentFilter filter
			, int match, android.content.ComponentName[] set, android.content.ComponentName 
			activity)
		{
			try
			{
				mPM.replacePreferredActivity(filter, match, set, activity);
			}
			catch (android.os.RemoteException)
			{
			}
		}

		// Should never happen!
		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override void clearPackagePreferredActivities(string packageName)
		{
			try
			{
				mPM.clearPackagePreferredActivities(packageName);
			}
			catch (android.os.RemoteException)
			{
			}
		}

		// Should never happen!
		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override int getPreferredActivities(java.util.List<android.content.IntentFilter
			> outFilters, java.util.List<android.content.ComponentName> outActivities, string
			 packageName)
		{
			try
			{
				return mPM.getPreferredActivities(outFilters, outActivities, packageName);
			}
			catch (android.os.RemoteException)
			{
			}
			// Should never happen!
			return 0;
		}

		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override void setComponentEnabledSetting(android.content.ComponentName componentName
			, int newState, int flags)
		{
			try
			{
				mPM.setComponentEnabledSetting(componentName, newState, flags);
			}
			catch (android.os.RemoteException)
			{
			}
		}

		// Should never happen!
		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override int getComponentEnabledSetting(android.content.ComponentName componentName
			)
		{
			try
			{
				return mPM.getComponentEnabledSetting(componentName);
			}
			catch (android.os.RemoteException)
			{
			}
			// Should never happen!
			return android.content.pm.PackageManager.COMPONENT_ENABLED_STATE_DEFAULT;
		}

		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override void setApplicationEnabledSetting(string packageName, int newState
			, int flags)
		{
			try
			{
				mPM.setApplicationEnabledSetting(packageName, newState, flags);
			}
			catch (android.os.RemoteException)
			{
			}
		}

		// Should never happen!
		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override int getApplicationEnabledSetting(string packageName)
		{
			try
			{
				return mPM.getApplicationEnabledSetting(packageName);
			}
			catch (android.os.RemoteException)
			{
			}
			// Should never happen!
			return android.content.pm.PackageManager.COMPONENT_ENABLED_STATE_DEFAULT;
		}

		// Multi-user support
		/// <hide></hide>
		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override android.content.pm.UserInfo createUser(string name, int flags)
		{
			try
			{
				return mPM.createUser(name, flags);
			}
			catch (android.os.RemoteException)
			{
			}
			// Should never happen!
			return null;
		}

		/// <hide></hide>
		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override java.util.List<android.content.pm.UserInfo> getUsers()
		{
			// TODO:
			// Dummy code, always returns just the primary user
			java.util.ArrayList<android.content.pm.UserInfo> users = new java.util.ArrayList<
				android.content.pm.UserInfo>();
			android.content.pm.UserInfo primary = new android.content.pm.UserInfo(0, "Root!", 
				android.content.pm.UserInfo.FLAG_ADMIN | android.content.pm.UserInfo.FLAG_PRIMARY
				);
			users.add(primary);
			return users;
		}

		/// <hide></hide>
		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override bool removeUser(int id)
		{
			try
			{
				return mPM.removeUser(id);
			}
			catch (android.os.RemoteException)
			{
				return false;
			}
		}

		/// <hide></hide>
		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override void updateUserName(int id, string name)
		{
		}

		// TODO:
		/// <hide></hide>
		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override void updateUserFlags(int id, int flags)
		{
		}

		// TODO:
		/// <hide></hide>
		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override android.content.pm.VerifierDeviceIdentity getVerifierDeviceIdentity
			()
		{
			try
			{
				return mPM.getVerifierDeviceIdentity();
			}
			catch (android.os.RemoteException)
			{
			}
			// Should never happen!
			return null;
		}

		private readonly android.app.ContextImpl mContext;

		private readonly android.content.pm.IPackageManager mPM;

		private static readonly object sSync = new object();

		private static java.util.HashMap<android.app.ApplicationPackageManager.ResourceName
			, java.lang.@ref.WeakReference<android.graphics.drawable.Drawable>> sIconCache = 
			new java.util.HashMap<android.app.ApplicationPackageManager.ResourceName, java.lang.@ref.WeakReference
			<android.graphics.drawable.Drawable>>();

		private static java.util.HashMap<android.app.ApplicationPackageManager.ResourceName
			, java.lang.@ref.WeakReference<java.lang.CharSequence>> sStringCache = new java.util.HashMap
			<android.app.ApplicationPackageManager.ResourceName, java.lang.@ref.WeakReference
			<java.lang.CharSequence>>();
	}
}

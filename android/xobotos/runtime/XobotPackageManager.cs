using System;
using System.IO;
using System.Reflection;
using SCG = System.Collections.Generic;
using java.util;
using android.app;
using android.content;
using android.content.pm;
using android.content.res;
using android.graphics.drawable;
using android.util;

namespace XobotOS.Runtime
{
	internal class XobotPackageManager : PackageManager
	{
		readonly ContextImpl context;
		readonly SCG.Dictionary<string,XobotPackageInfo> loaded_packages;

		internal XobotPackageManager (ContextImpl context)
		{
			this.context = context;
			loaded_packages = new SCG.Dictionary<string, XobotPackageInfo> ();
		}

		private class XobotPackageInfo
		{
			public Assembly Assembly {
				get;
				private set;
			}

			public PackageInfo Info {
				get;
				private set;
			}

			public XobotPackageInfo (Assembly asm, PackageInfo info)
			{
				this.Assembly = asm;
				this.Info = info;
			}
		}

		internal PackageInfo LoadPackage (Assembly asm)
		{
			var path = asm.Location;

			int flags = GET_ACTIVITIES | GET_CONFIGURATIONS | GET_SERVICES;
			PackageInfo pkg = getPackageArchiveInfo (path, flags);
			if (pkg == null)
				throw new RuntimeException ("Failed to read package '{0}'", path);

			pkg.applicationInfo.sourceDir = path;

			XobotPackageInfo info = new XobotPackageInfo (asm, pkg);
			loaded_packages.Add (pkg.packageName, info);
			return pkg;
		}

		internal Assembly GetAssembly (string packageName)
		{
			return loaded_packages [packageName].Assembly;
		}

		public override Intent getLaunchIntentForPackage (string packageName)
		{
			if (!loaded_packages.ContainsKey (packageName))
				return null;

			XobotPackageInfo info = loaded_packages [packageName];

			if (info.Info.applicationInfo == null)
				throw new RuntimeException ("Cannot get ApplicationInfo from package.");
			if (info.Info.activities.Length < 1)
				throw new RuntimeException ("Package does not contain any Activity.");

			ActivityInfo ai = info.Info.activities [0];
			ai.applicationInfo.uid = android.os.Process.SYSTEM_UID;

			Intent intent = new Intent (Intent.ACTION_MAIN);
			intent.setFlags (Intent.FLAG_ACTIVITY_NEW_TASK);
			intent.setPackage (packageName);
			intent.setClassName (info.Info.packageName, ai.name);

			return intent;
		}

		public override PackageInfo getPackageInfo (string packageName, int flags)
		{
			return loaded_packages [packageName].Info;
		}

		public override ActivityInfo getActivityInfo (ComponentName component, int flags)
		{
			var package = loaded_packages [component.getPackageName ()];
			if (package == null)
				return null;

			foreach (ActivityInfo info in package.Info.activities) {
				if (info.name.Equals (component.getClassName ()))
				    return info;
			}

			return null;
		}

		#region implemented abstract members of PackageManager
		public override string[] currentToCanonicalPackageNames (string[] names)
		{
			throw new NotImplementedException ();
		}

		public override string[] canonicalToCurrentPackageNames (string[] names)
		{
			throw new NotImplementedException ();
		}

		public override int[] getPackageGids (string packageName)
		{
			throw new NotImplementedException ();
		}

		public override PermissionInfo getPermissionInfo (string name, int flags)
		{
			throw new NotImplementedException ();
		}

		public override List<PermissionInfo> queryPermissionsByGroup (string group, int flags)
		{
			throw new NotImplementedException ();
		}

		public override PermissionGroupInfo getPermissionGroupInfo (string name, int flags)
		{
			throw new NotImplementedException ();
		}

		public override List<PermissionGroupInfo> getAllPermissionGroups (int flags)
		{
			throw new NotImplementedException ();
		}

		public override ApplicationInfo getApplicationInfo (string packageName, int flags)
		{
			throw new NotImplementedException ();
		}

		public override ActivityInfo getReceiverInfo (ComponentName component, int flags)
		{
			throw new NotImplementedException ();
		}

		public override ServiceInfo getServiceInfo (ComponentName component, int flags)
		{
			throw new NotImplementedException ();
		}

		public override ProviderInfo getProviderInfo (ComponentName component, int flags)
		{
			throw new NotImplementedException ();
		}

		public override List<PackageInfo> getInstalledPackages (int flags)
		{
			throw new NotImplementedException ();
		}

		public override int checkPermission (string permName, string pkgName)
		{
			throw new NotImplementedException ();
		}

		public override bool addPermission (PermissionInfo info)
		{
			throw new NotImplementedException ();
		}

		public override bool addPermissionAsync (PermissionInfo info)
		{
			throw new NotImplementedException ();
		}

		public override void removePermission (string name)
		{
			throw new NotImplementedException ();
		}

		public override int checkSignatures (string pkg1, string pkg2)
		{
			throw new NotImplementedException ();
		}

		public override int checkSignatures (int uid1, int uid2)
		{
			throw new NotImplementedException ();
		}

		public override string[] getPackagesForUid (int uid)
		{
			throw new NotImplementedException ();
		}

		public override string getNameForUid (int uid)
		{
			throw new NotImplementedException ();
		}

		public override int getUidForSharedUser (string sharedUserName)
		{
			throw new NotImplementedException ();
		}

		public override List<ApplicationInfo> getInstalledApplications (int flags)
		{
			throw new NotImplementedException ();
		}

		public override string[] getSystemSharedLibraryNames ()
		{
			throw new NotImplementedException ();
		}

		public override FeatureInfo[] getSystemAvailableFeatures ()
		{
			throw new NotImplementedException ();
		}

		public override bool hasSystemFeature (string name)
		{
			throw new NotImplementedException ();
		}

		public override List<ResolveInfo> queryIntentActivities (Intent intent, int flags)
		{
			throw new NotImplementedException ();
		}

		public override List<ResolveInfo> queryIntentActivityOptions (ComponentName caller, Intent[] specifics, Intent intent, int flags)
		{
			throw new NotImplementedException ();
		}

		public override List<ResolveInfo> queryBroadcastReceivers (Intent intent, int flags)
		{
			throw new NotImplementedException ();
		}

		public override ResolveInfo resolveActivity (Intent intent, int flags)
		{
			throw new NotImplementedException ();
		}

		public override ResolveInfo resolveService (Intent intent, int flags)
		{
			throw new NotImplementedException ();
		}

		public override List<ResolveInfo> queryIntentServices (Intent intent, int flags)
		{
			throw new NotImplementedException ();
		}

		public override ProviderInfo resolveContentProvider (string name, int flags)
		{
			throw new NotImplementedException ();
		}

		public override List<ProviderInfo> queryContentProviders (string processName, int uid, int flags)
		{
			throw new NotImplementedException ();
		}

		public override InstrumentationInfo getInstrumentationInfo (ComponentName className, int flags)
		{
			throw new NotImplementedException ();
		}

		public override List<InstrumentationInfo> queryInstrumentation (string targetPackage, int flags)
		{
			throw new NotImplementedException ();
		}

		public override Drawable getDrawable (string packageName, int resid, ApplicationInfo appInfo)
		{
			throw new NotImplementedException ();
		}

		public override Drawable getActivityIcon (ComponentName activityName)
		{
			throw new NotImplementedException ();
		}

		public override Drawable getActivityIcon (Intent intent)
		{
			throw new NotImplementedException ();
		}

		public override Drawable getDefaultActivityIcon ()
		{
			throw new NotImplementedException ();
		}

		public override Drawable getApplicationIcon (ApplicationInfo info)
		{
			throw new NotImplementedException ();
		}

		public override Drawable getApplicationIcon (string packageName)
		{
			throw new NotImplementedException ();
		}

		public override Drawable getActivityLogo (ComponentName activityName)
		{
			throw new NotImplementedException ();
		}

		public override Drawable getActivityLogo (Intent intent)
		{
			throw new NotImplementedException ();
		}

		public override Drawable getApplicationLogo (ApplicationInfo info)
		{
			throw new NotImplementedException ();
		}

		public override Drawable getApplicationLogo (string packageName)
		{
			throw new NotImplementedException ();
		}

		public override java.lang.CharSequence getText (string packageName, int resid, ApplicationInfo appInfo)
		{
			throw new NotImplementedException ();
		}

		public override XmlResourceParser getXml (string packageName, int resid, ApplicationInfo appInfo)
		{
			throw new NotImplementedException ();
		}

		public override java.lang.CharSequence getApplicationLabel (ApplicationInfo info)
		{
			throw new NotImplementedException ();
		}

		public override Resources getResourcesForActivity (ComponentName activityName)
		{
			throw new NotImplementedException ();
		}

		public override Resources getResourcesForApplication (ApplicationInfo app)
		{
			throw new NotImplementedException ();
		}

		public override Resources getResourcesForApplication (string appPackageName)
		{
			throw new NotImplementedException ();
		}

		public override void installPackage (System.Uri packageURI, IPackageInstallObserver observer, int flags, string installerPackageName)
		{
			throw new NotImplementedException ();
		}

		public override void installPackageWithVerification (System.Uri packageURI, IPackageInstallObserver observer, int flags, string installerPackageName, System.Uri verificationURI, ManifestDigest manifestDigest)
		{
			throw new NotImplementedException ();
		}

		public override void verifyPendingInstall (int id, int verificationCode)
		{
			throw new NotImplementedException ();
		}

		public override void setInstallerPackageName (string targetPackage, string installerPackageName)
		{
			throw new NotImplementedException ();
		}

		public override void deletePackage (string packageName, IPackageDeleteObserver observer, int flags)
		{
			throw new NotImplementedException ();
		}

		public override string getInstallerPackageName (string packageName)
		{
			throw new NotImplementedException ();
		}

		public override void clearApplicationUserData (string packageName, IPackageDataObserver observer)
		{
			throw new NotImplementedException ();
		}

		public override void deleteApplicationCacheFiles (string packageName, IPackageDataObserver observer)
		{
			throw new NotImplementedException ();
		}

		public override void freeStorageAndNotify (long freeStorageSize, IPackageDataObserver observer)
		{
			throw new NotImplementedException ();
		}

		public override void freeStorage (long freeStorageSize, IntentSender pi)
		{
			throw new NotImplementedException ();
		}

		public override void getPackageSizeInfo (string packageName, IPackageStatsObserver observer)
		{
			throw new NotImplementedException ();
		}

		public override void addPackageToPreferred (string packageName)
		{
			throw new NotImplementedException ();
		}

		public override void removePackageFromPreferred (string packageName)
		{
			throw new NotImplementedException ();
		}

		public override List<PackageInfo> getPreferredPackages (int flags)
		{
			throw new NotImplementedException ();
		}

		public override void addPreferredActivity (IntentFilter filter, int match, ComponentName[] set, ComponentName activity)
		{
			throw new NotImplementedException ();
		}

		public override void replacePreferredActivity (IntentFilter filter, int match, ComponentName[] set, ComponentName activity)
		{
			throw new NotImplementedException ();
		}

		public override void clearPackagePreferredActivities (string packageName)
		{
			throw new NotImplementedException ();
		}

		public override int getPreferredActivities (List<IntentFilter> outFilters, List<ComponentName> outActivities, string packageName)
		{
			throw new NotImplementedException ();
		}

		public override void setComponentEnabledSetting (ComponentName componentName, int newState, int flags)
		{
			throw new NotImplementedException ();
		}

		public override int getComponentEnabledSetting (ComponentName componentName)
		{
			throw new NotImplementedException ();
		}

		public override void setApplicationEnabledSetting (string packageName, int newState, int flags)
		{
			throw new NotImplementedException ();
		}

		public override int getApplicationEnabledSetting (string packageName)
		{
			throw new NotImplementedException ();
		}

		public override bool isSafeMode ()
		{
			throw new NotImplementedException ();
		}

		public override void movePackage (string packageName, IPackageMoveObserver observer, int flags)
		{
			throw new NotImplementedException ();
		}

		public override UserInfo createUser (string name, int flags)
		{
			throw new NotImplementedException ();
		}

		public override List<UserInfo> getUsers ()
		{
			throw new NotImplementedException ();
		}

		public override bool removeUser (int id)
		{
			throw new NotImplementedException ();
		}

		public override void updateUserName (int id, string name)
		{
			throw new NotImplementedException ();
		}

		public override void updateUserFlags (int id, int flags)
		{
			throw new NotImplementedException ();
		}

		public override VerifierDeviceIdentity getVerifierDeviceIdentity ()
		{
			throw new NotImplementedException ();
		}
		#endregion
	}
}


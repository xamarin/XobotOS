using Sharpen;

namespace android.content.pm
{
	[Sharpen.Stub]
	public interface IPackageManager : android.os.IInterface
	{
		[Sharpen.Stub]
		android.content.pm.PackageInfo getPackageInfo(string packageName, int flags);

		[Sharpen.Stub]
		int getPackageUid(string packageName);

		[Sharpen.Stub]
		int[] getPackageGids(string packageName);

		[Sharpen.Stub]
		string[] currentToCanonicalPackageNames(string[] names);

		[Sharpen.Stub]
		string[] canonicalToCurrentPackageNames(string[] names);

		[Sharpen.Stub]
		android.content.pm.PermissionInfo getPermissionInfo(string name, int flags);

		[Sharpen.Stub]
		java.util.List<android.content.pm.PermissionInfo> queryPermissionsByGroup(string 
			group, int flags);

		[Sharpen.Stub]
		android.content.pm.PermissionGroupInfo getPermissionGroupInfo(string name, int flags
			);

		[Sharpen.Stub]
		java.util.List<android.content.pm.PermissionGroupInfo> getAllPermissionGroups(int
			 flags);

		[Sharpen.Stub]
		android.content.pm.ApplicationInfo getApplicationInfo(string packageName, int flags
			);

		[Sharpen.Stub]
		android.content.pm.ActivityInfo getActivityInfo(android.content.ComponentName className
			, int flags);

		[Sharpen.Stub]
		android.content.pm.ActivityInfo getReceiverInfo(android.content.ComponentName className
			, int flags);

		[Sharpen.Stub]
		android.content.pm.ServiceInfo getServiceInfo(android.content.ComponentName className
			, int flags);

		[Sharpen.Stub]
		android.content.pm.ProviderInfo getProviderInfo(android.content.ComponentName className
			, int flags);

		[Sharpen.Stub]
		int checkPermission(string permName, string pkgName);

		[Sharpen.Stub]
		int checkUidPermission(string permName, int uid);

		[Sharpen.Stub]
		bool addPermission(android.content.pm.PermissionInfo info);

		[Sharpen.Stub]
		void removePermission(string name);

		[Sharpen.Stub]
		bool isProtectedBroadcast(string actionName);

		[Sharpen.Stub]
		int checkSignatures(string pkg1, string pkg2);

		[Sharpen.Stub]
		int checkUidSignatures(int uid1, int uid2);

		[Sharpen.Stub]
		string[] getPackagesForUid(int uid);

		[Sharpen.Stub]
		string getNameForUid(int uid);

		[Sharpen.Stub]
		int getUidForSharedUser(string sharedUserName);

		[Sharpen.Stub]
		android.content.pm.ResolveInfo resolveIntent(android.content.Intent intent, string
			 resolvedType, int flags);

		[Sharpen.Stub]
		java.util.List<android.content.pm.ResolveInfo> queryIntentActivities(android.content.Intent
			 intent, string resolvedType, int flags);

		[Sharpen.Stub]
		java.util.List<android.content.pm.ResolveInfo> queryIntentActivityOptions(android.content.ComponentName
			 caller, android.content.Intent[] specifics, string[] specificTypes, android.content.Intent
			 intent, string resolvedType, int flags);

		[Sharpen.Stub]
		java.util.List<android.content.pm.ResolveInfo> queryIntentReceivers(android.content.Intent
			 intent, string resolvedType, int flags);

		[Sharpen.Stub]
		android.content.pm.ResolveInfo resolveService(android.content.Intent intent, string
			 resolvedType, int flags);

		[Sharpen.Stub]
		java.util.List<android.content.pm.ResolveInfo> queryIntentServices(android.content.Intent
			 intent, string resolvedType, int flags);

		[Sharpen.Stub]
		android.content.pm.ParceledListSlice<android.os.Parcelable> getInstalledPackages(
			int flags, string lastRead);

		[Sharpen.Stub]
		android.content.pm.ParceledListSlice<android.os.Parcelable> getInstalledApplications
			(int flags, string lastRead);

		[Sharpen.Stub]
		java.util.List<android.content.pm.ApplicationInfo> getPersistentApplications(int 
			flags);

		[Sharpen.Stub]
		android.content.pm.ProviderInfo resolveContentProvider(string name, int flags);

		[Sharpen.Stub]
		void querySyncProviders(java.util.List<string> outNames, java.util.List<android.content.pm.ProviderInfo
			> outInfo);

		[Sharpen.Stub]
		java.util.List<android.content.pm.ProviderInfo> queryContentProviders(string processName
			, int uid, int flags);

		[Sharpen.Stub]
		android.content.pm.InstrumentationInfo getInstrumentationInfo(android.content.ComponentName
			 className, int flags);

		[Sharpen.Stub]
		java.util.List<android.content.pm.InstrumentationInfo> queryInstrumentation(string
			 targetPackage, int flags);

		[Sharpen.Stub]
		void installPackage(System.Uri packageURI, android.content.pm.IPackageInstallObserver
			 observer, int flags, string installerPackageName);

		[Sharpen.Stub]
		void finishPackageInstall(int token);

		[Sharpen.Stub]
		void setInstallerPackageName(string targetPackage, string installerPackageName);

		[Sharpen.Stub]
		void deletePackage(string packageName, android.content.pm.IPackageDeleteObserver 
			observer, int flags);

		[Sharpen.Stub]
		string getInstallerPackageName(string packageName);

		[Sharpen.Stub]
		void addPackageToPreferred(string packageName);

		[Sharpen.Stub]
		void removePackageFromPreferred(string packageName);

		[Sharpen.Stub]
		java.util.List<android.content.pm.PackageInfo> getPreferredPackages(int flags);

		[Sharpen.Stub]
		void addPreferredActivity(android.content.IntentFilter filter, int match, android.content.ComponentName
			[] set, android.content.ComponentName activity);

		[Sharpen.Stub]
		void replacePreferredActivity(android.content.IntentFilter filter, int match, android.content.ComponentName
			[] set, android.content.ComponentName activity);

		[Sharpen.Stub]
		void clearPackagePreferredActivities(string packageName);

		[Sharpen.Stub]
		int getPreferredActivities(java.util.List<android.content.IntentFilter> outFilters
			, java.util.List<android.content.ComponentName> outActivities, string packageName
			);

		[Sharpen.Stub]
		void setComponentEnabledSetting(android.content.ComponentName componentName, int 
			newState, int flags);

		[Sharpen.Stub]
		int getComponentEnabledSetting(android.content.ComponentName componentName);

		[Sharpen.Stub]
		void setApplicationEnabledSetting(string packageName, int newState, int flags);

		[Sharpen.Stub]
		int getApplicationEnabledSetting(string packageName);

		[Sharpen.Stub]
		void setPackageStoppedState(string packageName, bool stopped);

		[Sharpen.Stub]
		void freeStorageAndNotify(long freeStorageSize, android.content.pm.IPackageDataObserver
			 observer);

		[Sharpen.Stub]
		void freeStorage(long freeStorageSize, android.content.IntentSender pi);

		[Sharpen.Stub]
		void deleteApplicationCacheFiles(string packageName, android.content.pm.IPackageDataObserver
			 observer);

		[Sharpen.Stub]
		void clearApplicationUserData(string packageName, android.content.pm.IPackageDataObserver
			 observer);

		[Sharpen.Stub]
		void getPackageSizeInfo(string packageName, android.content.pm.IPackageStatsObserver
			 observer);

		[Sharpen.Stub]
		string[] getSystemSharedLibraryNames();

		[Sharpen.Stub]
		android.content.pm.FeatureInfo[] getSystemAvailableFeatures();

		[Sharpen.Stub]
		bool hasSystemFeature(string name);

		[Sharpen.Stub]
		void enterSafeMode();

		[Sharpen.Stub]
		bool isSafeMode();

		[Sharpen.Stub]
		void systemReady();

		[Sharpen.Stub]
		bool hasSystemUidErrors();

		[Sharpen.Stub]
		void performBootDexOpt();

		[Sharpen.Stub]
		bool performDexOpt(string packageName);

		[Sharpen.Stub]
		void updateExternalMediaStatus(bool mounted, bool reportStatus);

		[Sharpen.Stub]
		string nextPackageToClean(string lastPackage);

		[Sharpen.Stub]
		void movePackage(string packageName, android.content.pm.IPackageMoveObserver observer
			, int flags);

		[Sharpen.Stub]
		bool addPermissionAsync(android.content.pm.PermissionInfo info);

		[Sharpen.Stub]
		bool setInstallLocation(int loc);

		[Sharpen.Stub]
		int getInstallLocation();

		[Sharpen.Stub]
		android.content.pm.UserInfo createUser(string name, int flags);

		[Sharpen.Stub]
		bool removeUser(int userId);

		[Sharpen.Stub]
		void installPackageWithVerification(System.Uri packageURI, android.content.pm.IPackageInstallObserver
			 observer, int flags, string installerPackageName, System.Uri verificationURI, android.content.pm.ManifestDigest
			 manifestDigest);

		[Sharpen.Stub]
		void verifyPendingInstall(int id, int verificationCode);

		[Sharpen.Stub]
		android.content.pm.VerifierDeviceIdentity getVerifierDeviceIdentity();

		[Sharpen.Stub]
		bool isFirstBoot();
	}

	[Sharpen.Stub]
	public static class IPackageManagerClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.content.pm.IPackageManager
		{
			internal const string DESCRIPTOR = "android.content.pm.IPackageManager";

			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.content.pm.IPackageManager asInterface(android.os.IBinder obj
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.IInterface")]
			public virtual android.os.IBinder asBinder()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.os.Binder")]
			protected internal override bool onTransact(int code, android.os.Parcel data, android.os.Parcel
				 reply, int flags)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			private class Proxy : android.content.pm.IPackageManager
			{
				internal android.os.IBinder mRemote;

				[Sharpen.Stub]
				internal Proxy(android.os.IBinder remote)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.os.IInterface")]
				public virtual android.os.IBinder asBinder()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				public virtual string getInterfaceDescriptor()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual android.content.pm.PackageInfo getPackageInfo(string packageName, 
					int flags)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual int getPackageUid(string packageName)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual int[] getPackageGids(string packageName)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual string[] currentToCanonicalPackageNames(string[] names)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual string[] canonicalToCurrentPackageNames(string[] names)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual android.content.pm.PermissionInfo getPermissionInfo(string name, int
					 flags)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual java.util.List<android.content.pm.PermissionInfo> queryPermissionsByGroup
					(string group, int flags)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual android.content.pm.PermissionGroupInfo getPermissionGroupInfo(string
					 name, int flags)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual java.util.List<android.content.pm.PermissionGroupInfo> getAllPermissionGroups
					(int flags)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual android.content.pm.ApplicationInfo getApplicationInfo(string packageName
					, int flags)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual android.content.pm.ActivityInfo getActivityInfo(android.content.ComponentName
					 className, int flags)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual android.content.pm.ActivityInfo getReceiverInfo(android.content.ComponentName
					 className, int flags)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual android.content.pm.ServiceInfo getServiceInfo(android.content.ComponentName
					 className, int flags)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual android.content.pm.ProviderInfo getProviderInfo(android.content.ComponentName
					 className, int flags)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual int checkPermission(string permName, string pkgName)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual int checkUidPermission(string permName, int uid)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual bool addPermission(android.content.pm.PermissionInfo info)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual void removePermission(string name)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual bool isProtectedBroadcast(string actionName)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual int checkSignatures(string pkg1, string pkg2)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual int checkUidSignatures(int uid1, int uid2)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual string[] getPackagesForUid(int uid)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual string getNameForUid(int uid)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual int getUidForSharedUser(string sharedUserName)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual android.content.pm.ResolveInfo resolveIntent(android.content.Intent
					 intent, string resolvedType, int flags)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual java.util.List<android.content.pm.ResolveInfo> queryIntentActivities
					(android.content.Intent intent, string resolvedType, int flags)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual java.util.List<android.content.pm.ResolveInfo> queryIntentActivityOptions
					(android.content.ComponentName caller, android.content.Intent[] specifics, string
					[] specificTypes, android.content.Intent intent, string resolvedType, int flags)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual java.util.List<android.content.pm.ResolveInfo> queryIntentReceivers
					(android.content.Intent intent, string resolvedType, int flags)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual android.content.pm.ResolveInfo resolveService(android.content.Intent
					 intent, string resolvedType, int flags)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual java.util.List<android.content.pm.ResolveInfo> queryIntentServices
					(android.content.Intent intent, string resolvedType, int flags)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual android.content.pm.ParceledListSlice<android.os.Parcelable> getInstalledPackages
					(int flags, string lastRead)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual android.content.pm.ParceledListSlice<android.os.Parcelable> getInstalledApplications
					(int flags, string lastRead)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual java.util.List<android.content.pm.ApplicationInfo> getPersistentApplications
					(int flags)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual android.content.pm.ProviderInfo resolveContentProvider(string name
					, int flags)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual void querySyncProviders(java.util.List<string> outNames, java.util.List
					<android.content.pm.ProviderInfo> outInfo)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual java.util.List<android.content.pm.ProviderInfo> queryContentProviders
					(string processName, int uid, int flags)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual android.content.pm.InstrumentationInfo getInstrumentationInfo(android.content.ComponentName
					 className, int flags)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual java.util.List<android.content.pm.InstrumentationInfo> queryInstrumentation
					(string targetPackage, int flags)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual void installPackage(System.Uri packageURI, android.content.pm.IPackageInstallObserver
					 observer, int flags, string installerPackageName)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual void finishPackageInstall(int token)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual void setInstallerPackageName(string targetPackage, string installerPackageName
					)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual void deletePackage(string packageName, android.content.pm.IPackageDeleteObserver
					 observer, int flags)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual string getInstallerPackageName(string packageName)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual void addPackageToPreferred(string packageName)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual void removePackageFromPreferred(string packageName)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual java.util.List<android.content.pm.PackageInfo> getPreferredPackages
					(int flags)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual void addPreferredActivity(android.content.IntentFilter filter, int
					 match, android.content.ComponentName[] set, android.content.ComponentName activity
					)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual void replacePreferredActivity(android.content.IntentFilter filter, 
					int match, android.content.ComponentName[] set, android.content.ComponentName activity
					)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual void clearPackagePreferredActivities(string packageName)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual int getPreferredActivities(java.util.List<android.content.IntentFilter
					> outFilters, java.util.List<android.content.ComponentName> outActivities, string
					 packageName)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual void setComponentEnabledSetting(android.content.ComponentName componentName
					, int newState, int flags)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual int getComponentEnabledSetting(android.content.ComponentName componentName
					)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual void setApplicationEnabledSetting(string packageName, int newState
					, int flags)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual int getApplicationEnabledSetting(string packageName)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual void setPackageStoppedState(string packageName, bool stopped)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual void freeStorageAndNotify(long freeStorageSize, android.content.pm.IPackageDataObserver
					 observer)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual void freeStorage(long freeStorageSize, android.content.IntentSender
					 pi)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual void deleteApplicationCacheFiles(string packageName, android.content.pm.IPackageDataObserver
					 observer)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual void clearApplicationUserData(string packageName, android.content.pm.IPackageDataObserver
					 observer)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual void getPackageSizeInfo(string packageName, android.content.pm.IPackageStatsObserver
					 observer)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual string[] getSystemSharedLibraryNames()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual android.content.pm.FeatureInfo[] getSystemAvailableFeatures()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual bool hasSystemFeature(string name)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual void enterSafeMode()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual bool isSafeMode()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual void systemReady()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual bool hasSystemUidErrors()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual void performBootDexOpt()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual bool performDexOpt(string packageName)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual void updateExternalMediaStatus(bool mounted, bool reportStatus)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual string nextPackageToClean(string lastPackage)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual void movePackage(string packageName, android.content.pm.IPackageMoveObserver
					 observer, int flags)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual bool addPermissionAsync(android.content.pm.PermissionInfo info)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual bool setInstallLocation(int loc)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual int getInstallLocation()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual android.content.pm.UserInfo createUser(string name, int flags)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual bool removeUser(int userId)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual void installPackageWithVerification(System.Uri packageURI, android.content.pm.IPackageInstallObserver
					 observer, int flags, string installerPackageName, System.Uri verificationURI, android.content.pm.ManifestDigest
					 manifestDigest)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual void verifyPendingInstall(int id, int verificationCode)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual android.content.pm.VerifierDeviceIdentity getVerifierDeviceIdentity
					()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageManager")]
				public virtual bool isFirstBoot()
				{
					throw new System.NotImplementedException();
				}
			}

			internal const int TRANSACTION_getPackageInfo = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			internal const int TRANSACTION_getPackageUid = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 1);

			internal const int TRANSACTION_getPackageGids = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 2);

			internal const int TRANSACTION_currentToCanonicalPackageNames = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 3);

			internal const int TRANSACTION_canonicalToCurrentPackageNames = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 4);

			internal const int TRANSACTION_getPermissionInfo = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 5);

			internal const int TRANSACTION_queryPermissionsByGroup = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 6);

			internal const int TRANSACTION_getPermissionGroupInfo = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 7);

			internal const int TRANSACTION_getAllPermissionGroups = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 8);

			internal const int TRANSACTION_getApplicationInfo = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 9);

			internal const int TRANSACTION_getActivityInfo = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 10);

			internal const int TRANSACTION_getReceiverInfo = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 11);

			internal const int TRANSACTION_getServiceInfo = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 12);

			internal const int TRANSACTION_getProviderInfo = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 13);

			internal const int TRANSACTION_checkPermission = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 14);

			internal const int TRANSACTION_checkUidPermission = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 15);

			internal const int TRANSACTION_addPermission = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 16);

			internal const int TRANSACTION_removePermission = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 17);

			internal const int TRANSACTION_isProtectedBroadcast = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 18);

			internal const int TRANSACTION_checkSignatures = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 19);

			internal const int TRANSACTION_checkUidSignatures = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 20);

			internal const int TRANSACTION_getPackagesForUid = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 21);

			internal const int TRANSACTION_getNameForUid = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 22);

			internal const int TRANSACTION_getUidForSharedUser = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 23);

			internal const int TRANSACTION_resolveIntent = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 24);

			internal const int TRANSACTION_queryIntentActivities = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 25);

			internal const int TRANSACTION_queryIntentActivityOptions = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 26);

			internal const int TRANSACTION_queryIntentReceivers = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 27);

			internal const int TRANSACTION_resolveService = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 28);

			internal const int TRANSACTION_queryIntentServices = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 29);

			internal const int TRANSACTION_getInstalledPackages = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 30);

			internal const int TRANSACTION_getInstalledApplications = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 31);

			internal const int TRANSACTION_getPersistentApplications = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 32);

			internal const int TRANSACTION_resolveContentProvider = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 33);

			internal const int TRANSACTION_querySyncProviders = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 34);

			internal const int TRANSACTION_queryContentProviders = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 35);

			internal const int TRANSACTION_getInstrumentationInfo = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 36);

			internal const int TRANSACTION_queryInstrumentation = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 37);

			internal const int TRANSACTION_installPackage = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 38);

			internal const int TRANSACTION_finishPackageInstall = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 39);

			internal const int TRANSACTION_setInstallerPackageName = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 40);

			internal const int TRANSACTION_deletePackage = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 41);

			internal const int TRANSACTION_getInstallerPackageName = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 42);

			internal const int TRANSACTION_addPackageToPreferred = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 43);

			internal const int TRANSACTION_removePackageFromPreferred = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 44);

			internal const int TRANSACTION_getPreferredPackages = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 45);

			internal const int TRANSACTION_addPreferredActivity = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 46);

			internal const int TRANSACTION_replacePreferredActivity = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 47);

			internal const int TRANSACTION_clearPackagePreferredActivities = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 48);

			internal const int TRANSACTION_getPreferredActivities = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 49);

			internal const int TRANSACTION_setComponentEnabledSetting = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 50);

			internal const int TRANSACTION_getComponentEnabledSetting = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 51);

			internal const int TRANSACTION_setApplicationEnabledSetting = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 52);

			internal const int TRANSACTION_getApplicationEnabledSetting = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 53);

			internal const int TRANSACTION_setPackageStoppedState = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 54);

			internal const int TRANSACTION_freeStorageAndNotify = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 55);

			internal const int TRANSACTION_freeStorage = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 56);

			internal const int TRANSACTION_deleteApplicationCacheFiles = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 57);

			internal const int TRANSACTION_clearApplicationUserData = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 58);

			internal const int TRANSACTION_getPackageSizeInfo = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 59);

			internal const int TRANSACTION_getSystemSharedLibraryNames = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 60);

			internal const int TRANSACTION_getSystemAvailableFeatures = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 61);

			internal const int TRANSACTION_hasSystemFeature = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 62);

			internal const int TRANSACTION_enterSafeMode = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 63);

			internal const int TRANSACTION_isSafeMode = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 64);

			internal const int TRANSACTION_systemReady = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 65);

			internal const int TRANSACTION_hasSystemUidErrors = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 66);

			internal const int TRANSACTION_performBootDexOpt = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 67);

			internal const int TRANSACTION_performDexOpt = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 68);

			internal const int TRANSACTION_updateExternalMediaStatus = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 69);

			internal const int TRANSACTION_nextPackageToClean = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 70);

			internal const int TRANSACTION_movePackage = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 71);

			internal const int TRANSACTION_addPermissionAsync = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 72);

			internal const int TRANSACTION_setInstallLocation = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 73);

			internal const int TRANSACTION_getInstallLocation = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 74);

			internal const int TRANSACTION_createUser = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 75);

			internal const int TRANSACTION_removeUser = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 76);

			internal const int TRANSACTION_installPackageWithVerification = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 77);

			internal const int TRANSACTION_verifyPendingInstall = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 78);

			internal const int TRANSACTION_getVerifierDeviceIdentity = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 79);

			internal const int TRANSACTION_isFirstBoot = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 80);

			public abstract void addPackageToPreferred(string arg1);

			public abstract bool addPermission(android.content.pm.PermissionInfo arg1);

			public abstract bool addPermissionAsync(android.content.pm.PermissionInfo arg1);

			public abstract void addPreferredActivity(android.content.IntentFilter arg1, int 
				arg2, android.content.ComponentName[] arg3, android.content.ComponentName arg4);

			public abstract string[] canonicalToCurrentPackageNames(string[] arg1);

			public abstract int checkPermission(string arg1, string arg2);

			public abstract int checkSignatures(string arg1, string arg2);

			public abstract int checkUidPermission(string arg1, int arg2);

			public abstract int checkUidSignatures(int arg1, int arg2);

			public abstract void clearApplicationUserData(string arg1, android.content.pm.IPackageDataObserver
				 arg2);

			public abstract void clearPackagePreferredActivities(string arg1);

			public abstract android.content.pm.UserInfo createUser(string arg1, int arg2);

			public abstract string[] currentToCanonicalPackageNames(string[] arg1);

			public abstract void deleteApplicationCacheFiles(string arg1, android.content.pm.IPackageDataObserver
				 arg2);

			public abstract void deletePackage(string arg1, android.content.pm.IPackageDeleteObserver
				 arg2, int arg3);

			public abstract void enterSafeMode();

			public abstract void finishPackageInstall(int arg1);

			public abstract void freeStorage(long arg1, android.content.IntentSender arg2);

			public abstract void freeStorageAndNotify(long arg1, android.content.pm.IPackageDataObserver
				 arg2);

			public abstract android.content.pm.ActivityInfo getActivityInfo(android.content.ComponentName
				 arg1, int arg2);

			public abstract java.util.List<android.content.pm.PermissionGroupInfo> getAllPermissionGroups
				(int arg1);

			public abstract int getApplicationEnabledSetting(string arg1);

			public abstract android.content.pm.ApplicationInfo getApplicationInfo(string arg1
				, int arg2);

			public abstract int getComponentEnabledSetting(android.content.ComponentName arg1
				);

			public abstract int getInstallLocation();

			public abstract android.content.pm.ParceledListSlice<android.os.Parcelable> getInstalledApplications
				(int arg1, string arg2);

			public abstract android.content.pm.ParceledListSlice<android.os.Parcelable> getInstalledPackages
				(int arg1, string arg2);

			public abstract string getInstallerPackageName(string arg1);

			public abstract android.content.pm.InstrumentationInfo getInstrumentationInfo(android.content.ComponentName
				 arg1, int arg2);

			public abstract string getNameForUid(int arg1);

			public abstract int[] getPackageGids(string arg1);

			public abstract android.content.pm.PackageInfo getPackageInfo(string arg1, int arg2
				);

			public abstract void getPackageSizeInfo(string arg1, android.content.pm.IPackageStatsObserver
				 arg2);

			public abstract int getPackageUid(string arg1);

			public abstract string[] getPackagesForUid(int arg1);

			public abstract android.content.pm.PermissionGroupInfo getPermissionGroupInfo(string
				 arg1, int arg2);

			public abstract android.content.pm.PermissionInfo getPermissionInfo(string arg1, 
				int arg2);

			public abstract java.util.List<android.content.pm.ApplicationInfo> getPersistentApplications
				(int arg1);

			public abstract int getPreferredActivities(java.util.List<android.content.IntentFilter
				> arg1, java.util.List<android.content.ComponentName> arg2, string arg3);

			public abstract java.util.List<android.content.pm.PackageInfo> getPreferredPackages
				(int arg1);

			public abstract android.content.pm.ProviderInfo getProviderInfo(android.content.ComponentName
				 arg1, int arg2);

			public abstract android.content.pm.ActivityInfo getReceiverInfo(android.content.ComponentName
				 arg1, int arg2);

			public abstract android.content.pm.ServiceInfo getServiceInfo(android.content.ComponentName
				 arg1, int arg2);

			public abstract android.content.pm.FeatureInfo[] getSystemAvailableFeatures();

			public abstract string[] getSystemSharedLibraryNames();

			public abstract int getUidForSharedUser(string arg1);

			public abstract android.content.pm.VerifierDeviceIdentity getVerifierDeviceIdentity
				();

			public abstract bool hasSystemFeature(string arg1);

			public abstract bool hasSystemUidErrors();

			public abstract void installPackage(System.Uri arg1, android.content.pm.IPackageInstallObserver
				 arg2, int arg3, string arg4);

			public abstract void installPackageWithVerification(System.Uri arg1, android.content.pm.IPackageInstallObserver
				 arg2, int arg3, string arg4, System.Uri arg5, android.content.pm.ManifestDigest
				 arg6);

			public abstract bool isFirstBoot();

			public abstract bool isProtectedBroadcast(string arg1);

			public abstract bool isSafeMode();

			public abstract void movePackage(string arg1, android.content.pm.IPackageMoveObserver
				 arg2, int arg3);

			public abstract string nextPackageToClean(string arg1);

			public abstract void performBootDexOpt();

			public abstract bool performDexOpt(string arg1);

			public abstract java.util.List<android.content.pm.ProviderInfo> queryContentProviders
				(string arg1, int arg2, int arg3);

			public abstract java.util.List<android.content.pm.InstrumentationInfo> queryInstrumentation
				(string arg1, int arg2);

			public abstract java.util.List<android.content.pm.ResolveInfo> queryIntentActivities
				(android.content.Intent arg1, string arg2, int arg3);

			public abstract java.util.List<android.content.pm.ResolveInfo> queryIntentActivityOptions
				(android.content.ComponentName arg1, android.content.Intent[] arg2, string[] arg3
				, android.content.Intent arg4, string arg5, int arg6);

			public abstract java.util.List<android.content.pm.ResolveInfo> queryIntentReceivers
				(android.content.Intent arg1, string arg2, int arg3);

			public abstract java.util.List<android.content.pm.ResolveInfo> queryIntentServices
				(android.content.Intent arg1, string arg2, int arg3);

			public abstract java.util.List<android.content.pm.PermissionInfo> queryPermissionsByGroup
				(string arg1, int arg2);

			public abstract void querySyncProviders(java.util.List<string> arg1, java.util.List
				<android.content.pm.ProviderInfo> arg2);

			public abstract void removePackageFromPreferred(string arg1);

			public abstract void removePermission(string arg1);

			public abstract bool removeUser(int arg1);

			public abstract void replacePreferredActivity(android.content.IntentFilter arg1, 
				int arg2, android.content.ComponentName[] arg3, android.content.ComponentName arg4
				);

			public abstract android.content.pm.ProviderInfo resolveContentProvider(string arg1
				, int arg2);

			public abstract android.content.pm.ResolveInfo resolveIntent(android.content.Intent
				 arg1, string arg2, int arg3);

			public abstract android.content.pm.ResolveInfo resolveService(android.content.Intent
				 arg1, string arg2, int arg3);

			public abstract void setApplicationEnabledSetting(string arg1, int arg2, int arg3
				);

			public abstract void setComponentEnabledSetting(android.content.ComponentName arg1
				, int arg2, int arg3);

			public abstract bool setInstallLocation(int arg1);

			public abstract void setInstallerPackageName(string arg1, string arg2);

			public abstract void setPackageStoppedState(string arg1, bool arg2);

			public abstract void systemReady();

			public abstract void updateExternalMediaStatus(bool arg1, bool arg2);

			public abstract void verifyPendingInstall(int arg1, int arg2);
		}
	}
}

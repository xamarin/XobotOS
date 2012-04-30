using Sharpen;

namespace android.content.@internal
{
	[Sharpen.Stub]
	public abstract class PackageMonitor : android.content.BroadcastReceiver
	{
		internal static readonly android.content.IntentFilter sPackageFilt = new android.content.IntentFilter
			();

		internal static readonly android.content.IntentFilter sNonDataFilt = new android.content.IntentFilter
			();

		internal static readonly android.content.IntentFilter sExternalFilt = new android.content.IntentFilter
			();

		static PackageMonitor()
		{
			throw new System.NotImplementedException();
		}

		internal readonly java.util.HashSet<string> mUpdatingPackages = new java.util.HashSet
			<string>();

		internal android.content.Context mRegisteredContext;

		internal string[] mDisappearingPackages;

		internal string[] mAppearingPackages;

		internal string[] mModifiedPackages;

		internal int mChangeType;

		internal bool mSomePackagesChanged;

		internal string[] mTempArray = new string[1];

		[Sharpen.Stub]
		public virtual void register(android.content.Context context, bool externalStorage
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void unregister()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual bool isPackageUpdating(string packageName)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onBeginPackageChanges()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onPackageAdded(string packageName, int uid)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onPackageRemoved(string packageName, int uid)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onPackageUpdateStarted(string packageName, int uid)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onPackageUpdateFinished(string packageName, int uid)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onPackageChanged(string packageName, int uid, string[] components
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool onHandleForceStop(android.content.Intent intent, string[] packages
			, int uid, bool doit)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onUidRemoved(int uid)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onPackagesAvailable(string[] packages)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onPackagesUnavailable(string[] packages)
		{
			throw new System.NotImplementedException();
		}

		public const int PACKAGE_UNCHANGED = 0;

		public const int PACKAGE_UPDATING = 1;

		public const int PACKAGE_TEMPORARY_CHANGE = 2;

		public const int PACKAGE_PERMANENT_CHANGE = 3;

		[Sharpen.Stub]
		public virtual void onPackageDisappeared(string packageName, int reason)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onPackageAppeared(string packageName, int reason)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onPackageModified(string packageName)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool didSomePackagesChange()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int isPackageAppearing(string packageName)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool anyPackagesAppearing()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int isPackageDisappearing(string packageName)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool anyPackagesDisappearing()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isPackageModified(string packageName)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onSomePackagesChanged()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onFinishPackageChanges()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual string getPackageName(android.content.Intent intent)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.content.BroadcastReceiver")]
		public override void onReceive(android.content.Context context, android.content.Intent
			 intent)
		{
			throw new System.NotImplementedException();
		}
	}
}

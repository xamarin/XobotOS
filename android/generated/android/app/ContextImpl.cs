using Sharpen;

namespace android.app
{
	[Sharpen.Sharpened]
	internal class ReceiverRestrictedContext : android.content.ContextWrapper
	{
		internal ReceiverRestrictedContext(android.content.Context @base) : base(@base)
		{
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override android.content.Intent registerReceiver(android.content.BroadcastReceiver
			 receiver, android.content.IntentFilter filter)
		{
			return registerReceiver(receiver, filter, null, null);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override android.content.Intent registerReceiver(android.content.BroadcastReceiver
			 receiver, android.content.IntentFilter filter, string broadcastPermission, android.os.Handler
			 scheduler)
		{
			throw new android.content.ReceiverCallNotAllowedException("IntentReceiver components are not allowed to register to receive intents"
				);
		}

		//ex.fillInStackTrace();
		//Log.e("IntentReceiver", ex.getMessage(), ex);
		//return mContext.registerReceiver(receiver, filter, broadcastPermission,
		//        scheduler);
		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override bool bindService(android.content.Intent service, android.content.ServiceConnection
			 conn, int flags)
		{
			throw new android.content.ReceiverCallNotAllowedException("IntentReceiver components are not allowed to bind to services"
				);
		}
		//ex.fillInStackTrace();
		//Log.e("IntentReceiver", ex.getMessage(), ex);
		//return mContext.bindService(service, interfaceName, conn, flags);
	}

	/// <summary>
	/// Common implementation of Context API, which provides the base
	/// context object for Activity and other application components.
	/// </summary>
	/// <remarks>
	/// Common implementation of Context API, which provides the base
	/// context object for Activity and other application components.
	/// </remarks>
	[Sharpen.Sharpened]
	internal partial class ContextImpl : android.content.Context
	{
		internal const string TAG = "ApplicationContext";

		internal const bool DEBUG = false;

		private static readonly java.util.HashMap<string, android.app.SharedPreferencesImpl
			> sSharedPrefs = new java.util.HashMap<string, android.app.SharedPreferencesImpl
			>();

		internal android.app.LoadedApk mPackageInfo;

		private string mBasePackageName;

		private android.content.res.Resources mResources;

		internal android.app.ActivityThread mMainThread;

		private android.content.Context mOuterContext;

		private android.os.IBinder mActivityToken = null;

		private android.app.ContextImpl.ApplicationContentResolver mContentResolver;

		private int mThemeResource = 0;

		private android.content.res.Resources.Theme mTheme = null;

		private android.content.pm.PackageManager mPackageManager;

		private android.content.Context mReceiverRestrictedContext = null;

		private bool mRestricted;

		private readonly object mSync = new object();

		private java.io.File mDatabasesDir;

		private java.io.File mPreferencesDir;

		private java.io.File mFilesDir;

		private java.io.File mCacheDir;

		private java.io.File mObbDir;

		private java.io.File mExternalFilesDir;

		private java.io.File mExternalCacheDir;

		private static readonly string[] EMPTY_FILE_LIST = new string[] {  };

		/// <summary>
		/// Override this class when the system service constructor needs a
		/// ContextImpl.
		/// </summary>
		/// <remarks>
		/// Override this class when the system service constructor needs a
		/// ContextImpl.  Else, use StaticServiceFetcher below.
		/// </remarks>
		internal class ServiceFetcher
		{
			internal int mContextCacheIndex = -1;

			/// <summary>Main entrypoint; only override if you don't need caching.</summary>
			/// <remarks>Main entrypoint; only override if you don't need caching.</remarks>
			internal virtual object getService(android.app.ContextImpl ctx)
			{
				java.util.ArrayList<object> cache = ctx.mServiceCache;
				object service;
				lock (cache)
				{
					if (cache.size() == 0)
					{
						{
							// Initialize the cache vector on first access.
							// At this point sNextPerContextServiceCacheIndex
							// is the number of potential services that are
							// cached per-Context.
							for (int i = 0; i < sNextPerContextServiceCacheIndex; i++)
							{
								cache.add(null);
							}
						}
					}
					else
					{
						service = cache.get(mContextCacheIndex);
						if (service != null)
						{
							return service;
						}
					}
					service = createService(ctx);
					cache.set(mContextCacheIndex, service);
					return service;
				}
			}

			/// <summary>
			/// Override this to create a new per-Context instance of the
			/// service.
			/// </summary>
			/// <remarks>
			/// Override this to create a new per-Context instance of the
			/// service.  getService() will handle locking and caching.
			/// </remarks>
			internal virtual object createService(android.app.ContextImpl ctx)
			{
				throw new java.lang.RuntimeException("Not implemented");
			}
		}

		/// <summary>Override this class for services to be cached process-wide.</summary>
		/// <remarks>Override this class for services to be cached process-wide.</remarks>
		internal abstract class StaticServiceFetcher : android.app.ContextImpl.ServiceFetcher
		{
			private object mCachedInstance;

			[Sharpen.OverridesMethod(@"android.app.ContextImpl.ServiceFetcher")]
			internal sealed override object getService(android.app.ContextImpl unused)
			{
				lock (this)
				{
					object service = mCachedInstance;
					if (service != null)
					{
						return service;
					}
					return mCachedInstance = createStaticService();
				}
			}

			public abstract object createStaticService();
		}

		private static readonly java.util.HashMap<string, android.app.ContextImpl.ServiceFetcher
			> SYSTEM_SERVICE_MAP = new java.util.HashMap<string, android.app.ContextImpl.ServiceFetcher
			>();

		private static int sNextPerContextServiceCacheIndex = 0;

		internal static void registerService(string serviceName, android.app.ContextImpl.
			ServiceFetcher fetcher)
		{
			if (!(fetcher is android.app.ContextImpl.StaticServiceFetcher))
			{
				fetcher.mContextCacheIndex = sNextPerContextServiceCacheIndex++;
			}
			SYSTEM_SERVICE_MAP.put(serviceName, fetcher);
		}

		private sealed class _ServiceFetcher_247 : android.app.ContextImpl.ServiceFetcher
		{
			public _ServiceFetcher_247()
			{
			}

			// This one's defined separately and given a variable name so it
			// can be re-used by getWallpaperManager(), avoiding a HashMap
			// lookup.
			[Sharpen.OverridesMethod(@"android.app.ContextImpl.ServiceFetcher")]
			internal override object createService(android.app.ContextImpl ctx)
			{
				return new android.app.WallpaperManager(ctx.getOuterContext(), ctx.mMainThread.getHandler
					());
			}
		}

		private static android.app.ContextImpl.ServiceFetcher WALLPAPER_FETCHER = new _ServiceFetcher_247
			();

		static ContextImpl()
		{
			registerService(ACCESSIBILITY_SERVICE, new _ServiceFetcher_254());
			registerService(ACCOUNT_SERVICE, new _ServiceFetcher_259());
			registerService(ACTIVITY_SERVICE, new _ServiceFetcher_266());
			registerService(ALARM_SERVICE, new _StaticServiceFetcher_271());
			registerService(AUDIO_SERVICE, new _ServiceFetcher_278());
			registerService(CLIPBOARD_SERVICE, new _ServiceFetcher_283());
			registerService(CONNECTIVITY_SERVICE, new _StaticServiceFetcher_289());
			registerService(COUNTRY_DETECTOR, new _StaticServiceFetcher_295());
			registerService(DEVICE_POLICY_SERVICE, new _ServiceFetcher_301());
			registerService(DOWNLOAD_SERVICE, new _ServiceFetcher_306());
			registerService(NFC_SERVICE, new _ServiceFetcher_311());
			registerService(DROPBOX_SERVICE, new _StaticServiceFetcher_316());
			registerService(INPUT_METHOD_SERVICE, new _ServiceFetcher_321());
			registerService(TEXT_SERVICES_MANAGER_SERVICE, new _ServiceFetcher_326());
			registerService(KEYGUARD_SERVICE, new _ServiceFetcher_331());
			// TODO: why isn't this caching it?  It wasn't
			// before, so I'm preserving the old behavior and
			// using getService(), instead of createService()
			// which would do the caching.
			registerService(LAYOUT_INFLATER_SERVICE, new _ServiceFetcher_340());
			registerService(LOCATION_SERVICE, new _StaticServiceFetcher_345());
			registerService(NETWORK_POLICY_SERVICE, new _ServiceFetcher_351());
			registerService(NOTIFICATION_SERVICE, new _ServiceFetcher_359());
			// Note: this was previously cached in a static variable, but
			// constructed using mMainThread.getHandler(), so converting
			// it to be a regular Context-cached service...
			registerService(POWER_SERVICE, new _ServiceFetcher_375());
			registerService(SEARCH_SERVICE, new _ServiceFetcher_382());
			registerService(SENSOR_SERVICE, new _ServiceFetcher_388());
			registerService(STATUS_BAR_SERVICE, new _ServiceFetcher_393());
			registerService(STORAGE_SERVICE, new _ServiceFetcher_398());
			registerService(TELEPHONY_SERVICE, new _ServiceFetcher_408());
			registerService(THROTTLE_SERVICE, new _StaticServiceFetcher_413());
			registerService(UI_MODE_SERVICE, new _ServiceFetcher_419());
			registerService(USB_SERVICE, new _ServiceFetcher_424());
			registerService(VIBRATOR_SERVICE, new _ServiceFetcher_430());
			registerService(WALLPAPER_SERVICE, WALLPAPER_FETCHER);
			registerService(WIFI_SERVICE, new _ServiceFetcher_437());
			registerService(WIFI_P2P_SERVICE, new _ServiceFetcher_444());
			registerService(WINDOW_SERVICE, new _ServiceFetcher_451());
		}

		private sealed class _ServiceFetcher_254 : android.app.ContextImpl.ServiceFetcher
		{
			public _ServiceFetcher_254()
			{
			}

			[Sharpen.OverridesMethod(@"android.app.ContextImpl.ServiceFetcher")]
			internal override object getService(android.app.ContextImpl ctx)
			{
				return android.view.accessibility.AccessibilityManager.getInstance(ctx);
			}
		}

		private sealed class _ServiceFetcher_259 : android.app.ContextImpl.ServiceFetcher
		{
			public _ServiceFetcher_259()
			{
			}

			[Sharpen.OverridesMethod(@"android.app.ContextImpl.ServiceFetcher")]
			internal override object createService(android.app.ContextImpl ctx)
			{
				android.os.IBinder b = android.os.ServiceManager.getService(android.content.Context
					.ACCOUNT_SERVICE);
				android.accounts.IAccountManager service = android.accounts.IAccountManagerClass.
					Stub.asInterface(b);
				return new android.accounts.AccountManager(ctx, service);
			}
		}

		private sealed class _ServiceFetcher_266 : android.app.ContextImpl.ServiceFetcher
		{
			public _ServiceFetcher_266()
			{
			}

			[Sharpen.OverridesMethod(@"android.app.ContextImpl.ServiceFetcher")]
			internal override object createService(android.app.ContextImpl ctx)
			{
				return new android.app.ActivityManager(ctx.getOuterContext(), ctx.mMainThread.getHandler
					());
			}
		}

		private sealed class _StaticServiceFetcher_271 : android.app.ContextImpl.StaticServiceFetcher
		{
			public _StaticServiceFetcher_271()
			{
			}

			[Sharpen.OverridesMethod(@"android.app.ContextImpl.StaticServiceFetcher")]
			public override object createStaticService()
			{
				android.os.IBinder b = android.os.ServiceManager.getService(android.content.Context
					.ALARM_SERVICE);
				android.app.IAlarmManager service = android.app.IAlarmManagerClass.Stub.asInterface
					(b);
				return new android.app.AlarmManager(service);
			}
		}

		private sealed class _ServiceFetcher_278 : android.app.ContextImpl.ServiceFetcher
		{
			public _ServiceFetcher_278()
			{
			}

			[Sharpen.OverridesMethod(@"android.app.ContextImpl.ServiceFetcher")]
			internal override object createService(android.app.ContextImpl ctx)
			{
				return new android.media.AudioManager(ctx);
			}
		}

		private sealed class _ServiceFetcher_283 : android.app.ContextImpl.ServiceFetcher
		{
			public _ServiceFetcher_283()
			{
			}

			[Sharpen.OverridesMethod(@"android.app.ContextImpl.ServiceFetcher")]
			internal override object createService(android.app.ContextImpl ctx)
			{
				return new android.content.ClipboardManager(ctx.getOuterContext(), ctx.mMainThread
					.getHandler());
			}
		}

		private sealed class _StaticServiceFetcher_289 : android.app.ContextImpl.StaticServiceFetcher
		{
			public _StaticServiceFetcher_289()
			{
			}

			[Sharpen.OverridesMethod(@"android.app.ContextImpl.StaticServiceFetcher")]
			public override object createStaticService()
			{
				android.os.IBinder b = android.os.ServiceManager.getService(android.content.Context
					.CONNECTIVITY_SERVICE);
				return new android.net.ConnectivityManager(android.net.IConnectivityManagerClass.
					Stub.asInterface(b));
			}
		}

		private sealed class _StaticServiceFetcher_295 : android.app.ContextImpl.StaticServiceFetcher
		{
			public _StaticServiceFetcher_295()
			{
			}

			[Sharpen.OverridesMethod(@"android.app.ContextImpl.StaticServiceFetcher")]
			public override object createStaticService()
			{
				android.os.IBinder b = android.os.ServiceManager.getService(android.content.Context
					.COUNTRY_DETECTOR);
				return new android.location.CountryDetector(android.location.ICountryDetectorClass
					.Stub.asInterface(b));
			}
		}

		private sealed class _ServiceFetcher_301 : android.app.ContextImpl.ServiceFetcher
		{
			public _ServiceFetcher_301()
			{
			}

			[Sharpen.OverridesMethod(@"android.app.ContextImpl.ServiceFetcher")]
			internal override object createService(android.app.ContextImpl ctx)
			{
				return android.app.admin.DevicePolicyManager.create(ctx, ctx.mMainThread.getHandler
					());
			}
		}

		private sealed class _ServiceFetcher_306 : android.app.ContextImpl.ServiceFetcher
		{
			public _ServiceFetcher_306()
			{
			}

			[Sharpen.OverridesMethod(@"android.app.ContextImpl.ServiceFetcher")]
			internal override object createService(android.app.ContextImpl ctx)
			{
				return new android.app.DownloadManager(ctx.getContentResolver(), ctx.getPackageName
					());
			}
		}

		private sealed class _ServiceFetcher_311 : android.app.ContextImpl.ServiceFetcher
		{
			public _ServiceFetcher_311()
			{
			}

			[Sharpen.OverridesMethod(@"android.app.ContextImpl.ServiceFetcher")]
			internal override object createService(android.app.ContextImpl ctx)
			{
				return new android.nfc.NfcManager(ctx);
			}
		}

		private sealed class _StaticServiceFetcher_316 : android.app.ContextImpl.StaticServiceFetcher
		{
			public _StaticServiceFetcher_316()
			{
			}

			[Sharpen.OverridesMethod(@"android.app.ContextImpl.StaticServiceFetcher")]
			public override object createStaticService()
			{
				return android.app.ContextImpl.createDropBoxManager();
			}
		}

		private sealed class _ServiceFetcher_321 : android.app.ContextImpl.ServiceFetcher
		{
			public _ServiceFetcher_321()
			{
			}

			[Sharpen.OverridesMethod(@"android.app.ContextImpl.ServiceFetcher")]
			internal override object createService(android.app.ContextImpl ctx)
			{
				return android.view.inputmethod.InputMethodManager.getInstance(ctx);
			}
		}

		private sealed class _ServiceFetcher_326 : android.app.ContextImpl.ServiceFetcher
		{
			public _ServiceFetcher_326()
			{
			}

			[Sharpen.OverridesMethod(@"android.app.ContextImpl.ServiceFetcher")]
			internal override object createService(android.app.ContextImpl ctx)
			{
				return android.view.textservice.TextServicesManager.getInstance();
			}
		}

		private sealed class _ServiceFetcher_331 : android.app.ContextImpl.ServiceFetcher
		{
			public _ServiceFetcher_331()
			{
			}

			[Sharpen.OverridesMethod(@"android.app.ContextImpl.ServiceFetcher")]
			internal override object getService(android.app.ContextImpl ctx)
			{
				return new android.app.KeyguardManager();
			}
		}

		private sealed class _ServiceFetcher_340 : android.app.ContextImpl.ServiceFetcher
		{
			public _ServiceFetcher_340()
			{
			}

			[Sharpen.OverridesMethod(@"android.app.ContextImpl.ServiceFetcher")]
			internal override object createService(android.app.ContextImpl ctx)
			{
				return android.policy.@internal.PolicyManager.makeNewLayoutInflater(ctx.getOuterContext
					());
			}
		}

		private sealed class _StaticServiceFetcher_345 : android.app.ContextImpl.StaticServiceFetcher
		{
			public _StaticServiceFetcher_345()
			{
			}

			[Sharpen.OverridesMethod(@"android.app.ContextImpl.StaticServiceFetcher")]
			public override object createStaticService()
			{
				android.os.IBinder b = android.os.ServiceManager.getService(android.content.Context
					.LOCATION_SERVICE);
				return new android.location.LocationManager(android.location.ILocationManagerClass
					.Stub.asInterface(b));
			}
		}

		private sealed class _ServiceFetcher_351 : android.app.ContextImpl.ServiceFetcher
		{
			public _ServiceFetcher_351()
			{
			}

			[Sharpen.OverridesMethod(@"android.app.ContextImpl.ServiceFetcher")]
			internal override object createService(android.app.ContextImpl ctx)
			{
				return new android.net.NetworkPolicyManager(android.net.INetworkPolicyManagerClass
					.Stub.asInterface(android.os.ServiceManager.getService(android.content.Context.NETWORK_POLICY_SERVICE
					)));
			}
		}

		private sealed class _ServiceFetcher_359 : android.app.ContextImpl.ServiceFetcher
		{
			public _ServiceFetcher_359()
			{
			}

			[Sharpen.OverridesMethod(@"android.app.ContextImpl.ServiceFetcher")]
			internal override object createService(android.app.ContextImpl ctx)
			{
				android.content.Context outerContext = ctx.getOuterContext();
				return new android.app.NotificationManager(new android.view.ContextThemeWrapper(outerContext
					, android.content.res.Resources.selectSystemTheme(0, outerContext.getApplicationInfo
					().targetSdkVersion, android.@internal.R.style.Theme_Dialog, android.@internal.R
					.style.Theme_Holo_Dialog, android.@internal.R.style.Theme_DeviceDefault_Dialog))
					, ctx.mMainThread.getHandler());
			}
		}

		private sealed class _ServiceFetcher_375 : android.app.ContextImpl.ServiceFetcher
		{
			public _ServiceFetcher_375()
			{
			}

			[Sharpen.OverridesMethod(@"android.app.ContextImpl.ServiceFetcher")]
			internal override object createService(android.app.ContextImpl ctx)
			{
				android.os.IBinder b = android.os.ServiceManager.getService(android.content.Context
					.POWER_SERVICE);
				android.os.IPowerManager service = android.os.IPowerManagerClass.Stub.asInterface
					(b);
				return new android.os.PowerManager(service, ctx.mMainThread.getHandler());
			}
		}

		private sealed class _ServiceFetcher_382 : android.app.ContextImpl.ServiceFetcher
		{
			public _ServiceFetcher_382()
			{
			}

			[Sharpen.OverridesMethod(@"android.app.ContextImpl.ServiceFetcher")]
			internal override object createService(android.app.ContextImpl ctx)
			{
				return new android.app.SearchManager(ctx.getOuterContext(), ctx.mMainThread.getHandler
					());
			}
		}

		private sealed class _ServiceFetcher_388 : android.app.ContextImpl.ServiceFetcher
		{
			public _ServiceFetcher_388()
			{
			}

			[Sharpen.OverridesMethod(@"android.app.ContextImpl.ServiceFetcher")]
			internal override object createService(android.app.ContextImpl ctx)
			{
				return new android.hardware.SensorManager(ctx.mMainThread.getHandler().getLooper(
					));
			}
		}

		private sealed class _ServiceFetcher_393 : android.app.ContextImpl.ServiceFetcher
		{
			public _ServiceFetcher_393()
			{
			}

			[Sharpen.OverridesMethod(@"android.app.ContextImpl.ServiceFetcher")]
			internal override object createService(android.app.ContextImpl ctx)
			{
				return new android.app.StatusBarManager(ctx.getOuterContext());
			}
		}

		private sealed class _ServiceFetcher_398 : android.app.ContextImpl.ServiceFetcher
		{
			public _ServiceFetcher_398()
			{
			}

			[Sharpen.OverridesMethod(@"android.app.ContextImpl.ServiceFetcher")]
			internal override object createService(android.app.ContextImpl ctx)
			{
				try
				{
					return new android.os.storage.StorageManager(ctx.mMainThread.getHandler().getLooper
						());
				}
				catch (android.os.RemoteException rex)
				{
					android.util.Log.e(android.app.ContextImpl.TAG, "Failed to create StorageManager"
						, rex);
					return null;
				}
			}
		}

		private sealed class _ServiceFetcher_408 : android.app.ContextImpl.ServiceFetcher
		{
			public _ServiceFetcher_408()
			{
			}

			[Sharpen.OverridesMethod(@"android.app.ContextImpl.ServiceFetcher")]
			internal override object createService(android.app.ContextImpl ctx)
			{
				return new android.telephony.TelephonyManager(ctx.getOuterContext());
			}
		}

		private sealed class _StaticServiceFetcher_413 : android.app.ContextImpl.StaticServiceFetcher
		{
			public _StaticServiceFetcher_413()
			{
			}

			[Sharpen.OverridesMethod(@"android.app.ContextImpl.StaticServiceFetcher")]
			public override object createStaticService()
			{
				android.os.IBinder b = android.os.ServiceManager.getService(android.content.Context
					.THROTTLE_SERVICE);
				return new android.net.ThrottleManager(android.net.IThrottleManagerClass.Stub.asInterface
					(b));
			}
		}

		private sealed class _ServiceFetcher_419 : android.app.ContextImpl.ServiceFetcher
		{
			public _ServiceFetcher_419()
			{
			}

			[Sharpen.OverridesMethod(@"android.app.ContextImpl.ServiceFetcher")]
			internal override object createService(android.app.ContextImpl ctx)
			{
				return new android.app.UiModeManager();
			}
		}

		private sealed class _ServiceFetcher_424 : android.app.ContextImpl.ServiceFetcher
		{
			public _ServiceFetcher_424()
			{
			}

			[Sharpen.OverridesMethod(@"android.app.ContextImpl.ServiceFetcher")]
			internal override object createService(android.app.ContextImpl ctx)
			{
				android.os.IBinder b = android.os.ServiceManager.getService(android.content.Context
					.USB_SERVICE);
				return new android.hardware.usb.UsbManager(ctx, android.hardware.usb.IUsbManagerClass
					.Stub.asInterface(b));
			}
		}

		private sealed class _ServiceFetcher_430 : android.app.ContextImpl.ServiceFetcher
		{
			public _ServiceFetcher_430()
			{
			}

			[Sharpen.OverridesMethod(@"android.app.ContextImpl.ServiceFetcher")]
			internal override object createService(android.app.ContextImpl ctx)
			{
				return new android.os.Vibrator();
			}
		}

		private sealed class _ServiceFetcher_437 : android.app.ContextImpl.ServiceFetcher
		{
			public _ServiceFetcher_437()
			{
			}

			[Sharpen.OverridesMethod(@"android.app.ContextImpl.ServiceFetcher")]
			internal override object createService(android.app.ContextImpl ctx)
			{
				android.os.IBinder b = android.os.ServiceManager.getService(android.content.Context
					.WIFI_SERVICE);
				android.net.wifi.IWifiManager service = android.net.wifi.IWifiManagerClass.Stub.asInterface
					(b);
				return new android.net.wifi.WifiManager(service, ctx.mMainThread.getHandler());
			}
		}

		private sealed class _ServiceFetcher_444 : android.app.ContextImpl.ServiceFetcher
		{
			public _ServiceFetcher_444()
			{
			}

			[Sharpen.OverridesMethod(@"android.app.ContextImpl.ServiceFetcher")]
			internal override object createService(android.app.ContextImpl ctx)
			{
				android.os.IBinder b = android.os.ServiceManager.getService(android.content.Context
					.WIFI_P2P_SERVICE);
				android.net.wifi.p2p.IWifiP2pManager service = android.net.wifi.p2p.IWifiP2pManagerClass
					.Stub.asInterface(b);
				return new android.net.wifi.p2p.WifiP2pManager(service);
			}
		}

		private sealed class _ServiceFetcher_451 : android.app.ContextImpl.ServiceFetcher
		{
			public _ServiceFetcher_451()
			{
			}

			[Sharpen.OverridesMethod(@"android.app.ContextImpl.ServiceFetcher")]
			internal override object getService(android.app.ContextImpl ctx)
			{
				return android.view.WindowManagerImpl.getDefault(ctx.mPackageInfo.mCompatibilityInfo
					);
			}
		}

		internal static android.app.ContextImpl getImpl(android.content.Context context)
		{
			android.content.Context nextContext;
			while ((context is android.content.ContextWrapper) && (nextContext = ((android.content.ContextWrapper
				)context).getBaseContext()) != null)
			{
				context = nextContext;
			}
			return (android.app.ContextImpl)context;
		}

		internal readonly java.util.ArrayList<object> mServiceCache = new java.util.ArrayList
			<object>();

		// The system service cache for the system services that are
		// cached per-ContextImpl.  Package-scoped to avoid accessor
		// methods.
		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override android.content.res.AssetManager getAssets()
		{
			return mResources.getAssets();
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override android.content.res.Resources getResources()
		{
			return mResources;
		}

		// Doesn't matter if we make more than one instance.
		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override android.content.ContentResolver getContentResolver()
		{
			return mContentResolver;
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override android.os.Looper getMainLooper()
		{
			return mMainThread.getLooper();
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override android.content.Context getApplicationContext()
		{
			return (mPackageInfo != null) ? mPackageInfo.getApplication() : mMainThread.getApplication
				();
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void setTheme(int resid)
		{
			mThemeResource = resid;
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override int getThemeResId()
		{
			return mThemeResource;
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override android.content.res.Resources.Theme getTheme()
		{
			if (mTheme == null)
			{
				mThemeResource = android.content.res.Resources.selectDefaultTheme(mThemeResource, 
					getOuterContext().getApplicationInfo().targetSdkVersion);
				mTheme = mResources.newTheme();
				mTheme.applyStyle(mThemeResource, true);
			}
			return mTheme;
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override java.lang.ClassLoader getClassLoader()
		{
			return mPackageInfo != null ? mPackageInfo.getClassLoader() : java.lang.ClassLoader
				.getSystemClassLoader();
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override string getPackageName()
		{
			if (mPackageInfo != null)
			{
				return mPackageInfo.getPackageName();
			}
			throw new java.lang.RuntimeException("Not supported in system context");
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override android.content.pm.ApplicationInfo getApplicationInfo()
		{
			if (mPackageInfo != null)
			{
				return mPackageInfo.getApplicationInfo();
			}
			throw new java.lang.RuntimeException("Not supported in system context");
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override string getPackageResourcePath()
		{
			if (mPackageInfo != null)
			{
				return mPackageInfo.getResDir();
			}
			throw new java.lang.RuntimeException("Not supported in system context");
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override string getPackageCodePath()
		{
			if (mPackageInfo != null)
			{
				return mPackageInfo.getAppDir();
			}
			throw new java.lang.RuntimeException("Not supported in system context");
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override java.io.File getSharedPrefsFile(string name)
		{
			return makeFilename(getPreferencesDir(), name + ".xml");
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override android.content.SharedPreferences getSharedPreferences(string name
			, int mode)
		{
			android.app.SharedPreferencesImpl sp;
			lock (sSharedPrefs)
			{
				sp = sSharedPrefs.get(name);
				if (sp == null)
				{
					java.io.File prefsFile = getSharedPrefsFile(name);
					sp = new android.app.SharedPreferencesImpl(prefsFile, mode);
					sSharedPrefs.put(name, sp);
					return sp;
				}
			}
			if ((mode & android.content.Context.MODE_MULTI_PROCESS) != 0 || getApplicationInfo
				().targetSdkVersion < android.os.Build.VERSION_CODES.HONEYCOMB)
			{
				// If somebody else (some other process) changed the prefs
				// file behind our back, we reload it.  This has been the
				// historical (if undocumented) behavior.
				sp.startReloadIfChangedUnexpectedly();
			}
			return sp;
		}

		private java.io.File getPreferencesDir()
		{
			lock (mSync)
			{
				if (mPreferencesDir == null)
				{
					mPreferencesDir = new java.io.File(getDataDirFile(), "shared_prefs");
				}
				return mPreferencesDir;
			}
		}

		/// <exception cref="java.io.FileNotFoundException"></exception>
		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override java.io.FileInputStream openFileInput(string name)
		{
			java.io.File f = makeFilename(getFilesDir(), name);
			return new java.io.FileInputStream(f);
		}

		/// <exception cref="java.io.FileNotFoundException"></exception>
		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override java.io.FileOutputStream openFileOutput(string name, int mode)
		{
			bool append = (mode & MODE_APPEND) != 0;
			java.io.File f = makeFilename(getFilesDir(), name);
			try
			{
				java.io.FileOutputStream fos = new java.io.FileOutputStream(f, append);
				setFilePermissionsFromMode(f.getPath(), mode, 0);
				return fos;
			}
			catch (java.io.FileNotFoundException)
			{
			}
			java.io.File parent = f.getParentFile();
			parent.mkdir();
			android.os.FileUtils.setPermissions(parent.getPath(), android.os.FileUtils.S_IRWXU
				 | android.os.FileUtils.S_IRWXG | android.os.FileUtils.S_IXOTH, -1, -1);
			java.io.FileOutputStream fos_1 = new java.io.FileOutputStream(f, append);
			setFilePermissionsFromMode(f.getPath(), mode, 0);
			return fos_1;
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override bool deleteFile(string name)
		{
			java.io.File f = makeFilename(getFilesDir(), name);
			return f.delete();
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override java.io.File getFilesDir()
		{
			lock (mSync)
			{
				if (mFilesDir == null)
				{
					mFilesDir = new java.io.File(getDataDirFile(), "files");
				}
				if (!mFilesDir.exists())
				{
					if (!mFilesDir.mkdirs())
					{
						android.util.Log.w(TAG, "Unable to create files directory " + mFilesDir.getPath()
							);
						return null;
					}
					android.os.FileUtils.setPermissions(mFilesDir.getPath(), android.os.FileUtils.S_IRWXU
						 | android.os.FileUtils.S_IRWXG | android.os.FileUtils.S_IXOTH, -1, -1);
				}
				return mFilesDir;
			}
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override java.io.File getExternalFilesDir(string type)
		{
			lock (mSync)
			{
				if (mExternalFilesDir == null)
				{
					mExternalFilesDir = android.os.Environment.getExternalStorageAppFilesDirectory(getPackageName
						());
				}
				if (!mExternalFilesDir.exists())
				{
					try
					{
						(new java.io.File(android.os.Environment.getExternalStorageAndroidDataDir(), ".nomedia"
							)).createNewFile();
					}
					catch (System.IO.IOException)
					{
					}
					if (!mExternalFilesDir.mkdirs())
					{
						android.util.Log.w(TAG, "Unable to create external files directory");
						return null;
					}
				}
				if (type == null)
				{
					return mExternalFilesDir;
				}
				java.io.File dir = new java.io.File(mExternalFilesDir, type);
				if (!dir.exists())
				{
					if (!dir.mkdirs())
					{
						android.util.Log.w(TAG, "Unable to create external media directory " + dir);
						return null;
					}
				}
				return dir;
			}
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override java.io.File getObbDir()
		{
			lock (mSync)
			{
				if (mObbDir == null)
				{
					mObbDir = android.os.Environment.getExternalStorageAppObbDirectory(getPackageName
						());
				}
				return mObbDir;
			}
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override java.io.File getCacheDir()
		{
			lock (mSync)
			{
				if (mCacheDir == null)
				{
					mCacheDir = new java.io.File(getDataDirFile(), "cache");
				}
				if (!mCacheDir.exists())
				{
					if (!mCacheDir.mkdirs())
					{
						android.util.Log.w(TAG, "Unable to create cache directory");
						return null;
					}
					android.os.FileUtils.setPermissions(mCacheDir.getPath(), android.os.FileUtils.S_IRWXU
						 | android.os.FileUtils.S_IRWXG | android.os.FileUtils.S_IXOTH, -1, -1);
				}
			}
			return mCacheDir;
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override java.io.File getExternalCacheDir()
		{
			lock (mSync)
			{
				if (mExternalCacheDir == null)
				{
					mExternalCacheDir = android.os.Environment.getExternalStorageAppCacheDirectory(getPackageName
						());
				}
				if (!mExternalCacheDir.exists())
				{
					try
					{
						(new java.io.File(android.os.Environment.getExternalStorageAndroidDataDir(), ".nomedia"
							)).createNewFile();
					}
					catch (System.IO.IOException)
					{
					}
					if (!mExternalCacheDir.mkdirs())
					{
						android.util.Log.w(TAG, "Unable to create external cache directory");
						return null;
					}
				}
				return mExternalCacheDir;
			}
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override java.io.File getFileStreamPath(string name)
		{
			return makeFilename(getFilesDir(), name);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override string[] fileList()
		{
			string[] list = getFilesDir().list();
			return (list != null) ? list : EMPTY_FILE_LIST;
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override android.database.sqlite.SQLiteDatabase openOrCreateDatabase(string
			 name, int mode, android.database.sqlite.SQLiteDatabase.CursorFactory factory)
		{
			java.io.File f = validateFilePath(name, true);
			android.database.sqlite.SQLiteDatabase db = android.database.sqlite.SQLiteDatabase
				.openOrCreateDatabase(f, factory);
			setFilePermissionsFromMode(f.getPath(), mode, 0);
			return db;
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override android.database.sqlite.SQLiteDatabase openOrCreateDatabase(string
			 name, int mode, android.database.sqlite.SQLiteDatabase.CursorFactory factory, android.database.DatabaseErrorHandler
			 errorHandler)
		{
			java.io.File f = validateFilePath(name, true);
			android.database.sqlite.SQLiteDatabase db = android.database.sqlite.SQLiteDatabase
				.openOrCreateDatabase(f.getPath(), factory, errorHandler);
			setFilePermissionsFromMode(f.getPath(), mode, 0);
			return db;
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override bool deleteDatabase(string name)
		{
			try
			{
				java.io.File f = validateFilePath(name, false);
				return f.delete();
			}
			catch (System.Exception)
			{
			}
			return false;
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override java.io.File getDatabasePath(string name)
		{
			return validateFilePath(name, false);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override string[] databaseList()
		{
			string[] list = getDatabasesDir().list();
			return (list != null) ? list : EMPTY_FILE_LIST;
		}

		private java.io.File getDatabasesDir()
		{
			lock (mSync)
			{
				if (mDatabasesDir == null)
				{
					mDatabasesDir = new java.io.File(getDataDirFile(), "databases");
				}
				if (mDatabasesDir.getPath().Equals("databases"))
				{
					mDatabasesDir = new java.io.File("/data/system");
				}
				return mDatabasesDir;
			}
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override android.graphics.drawable.Drawable getWallpaper()
		{
			return getWallpaperManager().getDrawable();
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override android.graphics.drawable.Drawable peekWallpaper()
		{
			return getWallpaperManager().peekDrawable();
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override int getWallpaperDesiredMinimumWidth()
		{
			return getWallpaperManager().getDesiredMinimumWidth();
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override int getWallpaperDesiredMinimumHeight()
		{
			return getWallpaperManager().getDesiredMinimumHeight();
		}

		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void setWallpaper(android.graphics.Bitmap bitmap)
		{
			getWallpaperManager().setBitmap(bitmap);
		}

		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void setWallpaper(java.io.InputStream data)
		{
			getWallpaperManager().setStream(data);
		}

		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void clearWallpaper()
		{
			getWallpaperManager().clear();
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void startActivity(android.content.Intent intent)
		{
			if ((intent.getFlags() & android.content.Intent.FLAG_ACTIVITY_NEW_TASK) == 0)
			{
				throw new android.util.AndroidRuntimeException("Calling startActivity() from outside of an Activity "
					 + " context requires the FLAG_ACTIVITY_NEW_TASK flag." + " Is this really what you want?"
					);
			}
			mMainThread.getInstrumentation().execStartActivity(getOuterContext(), mMainThread
				.getApplicationThread(), null, (android.app.Activity)null, intent, -1);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void startActivities(android.content.Intent[] intents)
		{
			if ((intents[0].getFlags() & android.content.Intent.FLAG_ACTIVITY_NEW_TASK) == 0)
			{
				throw new android.util.AndroidRuntimeException("Calling startActivities() from outside of an Activity "
					 + " context requires the FLAG_ACTIVITY_NEW_TASK flag on first Intent." + " Is this really what you want?"
					);
			}
			mMainThread.getInstrumentation().execStartActivities(getOuterContext(), mMainThread
				.getApplicationThread(), null, (android.app.Activity)null, intents);
		}

		/// <exception cref="android.content.IntentSender.SendIntentException"></exception>
		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void startIntentSender(android.content.IntentSender intent, android.content.Intent
			 fillInIntent, int flagsMask, int flagsValues, int extraFlags)
		{
			try
			{
				string resolvedType = null;
				if (fillInIntent != null)
				{
					fillInIntent.setAllowFds(false);
					resolvedType = fillInIntent.resolveTypeIfNeeded(getContentResolver());
				}
				int result = android.app.ActivityManagerNative.getDefault().startActivityIntentSender
					(mMainThread.getApplicationThread(), intent, fillInIntent, resolvedType, null, null
					, 0, flagsMask, flagsValues);
				if (result == android.app.IActivityManagerClass.START_CANCELED)
				{
					throw new android.content.IntentSender.SendIntentException();
				}
				android.app.Instrumentation.checkStartActivityResult(result, null);
			}
			catch (android.os.RemoteException)
			{
			}
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void sendBroadcast(android.content.Intent intent)
		{
			string resolvedType = intent.resolveTypeIfNeeded(getContentResolver());
			try
			{
				intent.setAllowFds(false);
				android.app.ActivityManagerNative.getDefault().broadcastIntent(mMainThread.getApplicationThread
					(), intent, resolvedType, null, android.app.Activity.RESULT_OK, null, null, null
					, false, false);
			}
			catch (android.os.RemoteException)
			{
			}
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void sendBroadcast(android.content.Intent intent, string receiverPermission
			)
		{
			string resolvedType = intent.resolveTypeIfNeeded(getContentResolver());
			try
			{
				intent.setAllowFds(false);
				android.app.ActivityManagerNative.getDefault().broadcastIntent(mMainThread.getApplicationThread
					(), intent, resolvedType, null, android.app.Activity.RESULT_OK, null, null, receiverPermission
					, false, false);
			}
			catch (android.os.RemoteException)
			{
			}
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void sendOrderedBroadcast(android.content.Intent intent, string receiverPermission
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void sendOrderedBroadcast(android.content.Intent intent, string receiverPermission
			, android.content.BroadcastReceiver resultReceiver, android.os.Handler scheduler
			, int initialCode, string initialData, android.os.Bundle initialExtras)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void sendStickyBroadcast(android.content.Intent intent)
		{
			string resolvedType = intent.resolveTypeIfNeeded(getContentResolver());
			try
			{
				intent.setAllowFds(false);
				android.app.ActivityManagerNative.getDefault().broadcastIntent(mMainThread.getApplicationThread
					(), intent, resolvedType, null, android.app.Activity.RESULT_OK, null, null, null
					, false, true);
			}
			catch (android.os.RemoteException)
			{
			}
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void sendStickyOrderedBroadcast(android.content.Intent intent, android.content.BroadcastReceiver
			 resultReceiver, android.os.Handler scheduler, int initialCode, string initialData
			, android.os.Bundle initialExtras)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void removeStickyBroadcast(android.content.Intent intent)
		{
			string resolvedType = intent.resolveTypeIfNeeded(getContentResolver());
			if (resolvedType != null)
			{
				intent = new android.content.Intent(intent);
				intent.setDataAndType(intent.getData(), resolvedType);
			}
			try
			{
				intent.setAllowFds(false);
				android.app.ActivityManagerNative.getDefault().unbroadcastIntent(mMainThread.getApplicationThread
					(), intent);
			}
			catch (android.os.RemoteException)
			{
			}
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override android.content.Intent registerReceiver(android.content.BroadcastReceiver
			 receiver, android.content.IntentFilter filter)
		{
			return registerReceiver(receiver, filter, null, null);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override android.content.Intent registerReceiver(android.content.BroadcastReceiver
			 receiver, android.content.IntentFilter filter, string broadcastPermission, android.os.Handler
			 scheduler)
		{
			return registerReceiverInternal(receiver, filter, broadcastPermission, scheduler, 
				getOuterContext());
		}

		[Sharpen.Stub]
		private android.content.Intent registerReceiverInternal(android.content.BroadcastReceiver
			 receiver, android.content.IntentFilter filter, string broadcastPermission, android.os.Handler
			 scheduler, android.content.Context context)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void unregisterReceiver(android.content.BroadcastReceiver receiver
			)
		{
			if (mPackageInfo != null)
			{
				android.content.IIntentReceiver rd = mPackageInfo.forgetReceiverDispatcher(getOuterContext
					(), receiver);
				try
				{
					android.app.ActivityManagerNative.getDefault().unregisterReceiver(rd);
				}
				catch (android.os.RemoteException)
				{
				}
			}
			else
			{
				throw new java.lang.RuntimeException("Not supported in system context");
			}
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override android.content.ComponentName startService(android.content.Intent
			 service)
		{
			try
			{
				service.setAllowFds(false);
				android.content.ComponentName cn = android.app.ActivityManagerNative.getDefault()
					.startService(mMainThread.getApplicationThread(), service, service.resolveTypeIfNeeded
					(getContentResolver()));
				if (cn != null && cn.getPackageName().Equals("!"))
				{
					throw new System.Security.SecurityException("Not allowed to start service " + service
						 + " without permission " + cn.getClassName());
				}
				return cn;
			}
			catch (android.os.RemoteException)
			{
				return null;
			}
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override bool stopService(android.content.Intent service)
		{
			try
			{
				service.setAllowFds(false);
				int res = android.app.ActivityManagerNative.getDefault().stopService(mMainThread.
					getApplicationThread(), service, service.resolveTypeIfNeeded(getContentResolver(
					)));
				if (res < 0)
				{
					throw new System.Security.SecurityException("Not allowed to stop service " + service
						);
				}
				return res != 0;
			}
			catch (android.os.RemoteException)
			{
				return false;
			}
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override bool bindService(android.content.Intent service, android.content.ServiceConnection
			 conn, int flags)
		{
			android.app.IServiceConnection sd;
			if (mPackageInfo != null)
			{
				sd = mPackageInfo.getServiceDispatcher(conn, getOuterContext(), mMainThread.getHandler
					(), flags);
			}
			else
			{
				throw new java.lang.RuntimeException("Not supported in system context");
			}
			try
			{
				android.os.IBinder token = getActivityToken();
				if (token == null && (flags & BIND_AUTO_CREATE) == 0 && mPackageInfo != null && mPackageInfo
					.getApplicationInfo().targetSdkVersion < android.os.Build.VERSION_CODES.ICE_CREAM_SANDWICH)
				{
					flags |= BIND_WAIVE_PRIORITY;
				}
				service.setAllowFds(false);
				int res = android.app.ActivityManagerNative.getDefault().bindService(mMainThread.
					getApplicationThread(), getActivityToken(), service, service.resolveTypeIfNeeded
					(getContentResolver()), sd, flags);
				if (res < 0)
				{
					throw new System.Security.SecurityException("Not allowed to bind to service " + service
						);
				}
				return res != 0;
			}
			catch (android.os.RemoteException)
			{
				return false;
			}
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void unbindService(android.content.ServiceConnection conn)
		{
			if (mPackageInfo != null)
			{
				android.app.IServiceConnection sd = mPackageInfo.forgetServiceDispatcher(getOuterContext
					(), conn);
				try
				{
					android.app.ActivityManagerNative.getDefault().unbindService(sd);
				}
				catch (android.os.RemoteException)
				{
				}
			}
			else
			{
				throw new java.lang.RuntimeException("Not supported in system context");
			}
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override bool startInstrumentation(android.content.ComponentName className
			, string profileFile, android.os.Bundle arguments)
		{
			try
			{
				if (arguments != null)
				{
					arguments.setAllowFds(false);
				}
				return android.app.ActivityManagerNative.getDefault().startInstrumentation(className
					, profileFile, 0, arguments, null);
			}
			catch (android.os.RemoteException)
			{
			}
			// System has crashed, nothing we can do.
			return false;
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override object getSystemService(string name)
		{
			android.app.ContextImpl.ServiceFetcher fetcher = SYSTEM_SERVICE_MAP.get(name);
			return fetcher == null ? null : fetcher.getService(this);
		}

		private android.app.WallpaperManager getWallpaperManager()
		{
			return (android.app.WallpaperManager)WALLPAPER_FETCHER.getService(this);
		}

		[Sharpen.Stub]
		internal static android.os.DropBoxManager createDropBoxManager()
		{
			throw new System.NotImplementedException();
		}

		// Don't return a DropBoxManager that will NPE upon use.
		// This also avoids caching a broken DropBoxManager in
		// getDropBoxManager during early boot, before the
		// DROPBOX_SERVICE is registered.
		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override int checkPermission(string permission, int pid, int uid)
		{
			if (permission == null)
			{
				throw new System.ArgumentException("permission is null");
			}
			try
			{
				return android.app.ActivityManagerNative.getDefault().checkPermission(permission, 
					pid, uid);
			}
			catch (android.os.RemoteException)
			{
				return android.content.pm.PackageManager.PERMISSION_DENIED;
			}
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override int checkCallingPermission(string permission)
		{
			if (permission == null)
			{
				throw new System.ArgumentException("permission is null");
			}
			int pid = android.os.Binder.getCallingPid();
			if (pid != android.os.Process.myPid())
			{
				return checkPermission(permission, pid, android.os.Binder.getCallingUid());
			}
			return android.content.pm.PackageManager.PERMISSION_DENIED;
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override int checkCallingOrSelfPermission(string permission)
		{
			if (permission == null)
			{
				throw new System.ArgumentException("permission is null");
			}
			return checkPermission(permission, android.os.Binder.getCallingPid(), android.os.Binder
				.getCallingUid());
		}

		private void enforce(string permission, int resultOfCheck, bool selfToo, int uid, 
			string message)
		{
			if (resultOfCheck != android.content.pm.PackageManager.PERMISSION_GRANTED)
			{
				throw new System.Security.SecurityException((message != null ? (message + ": ") : 
					string.Empty) + (selfToo ? "Neither user " + uid + " nor current process has " : 
					"User " + uid + " does not have ") + permission + ".");
			}
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void enforcePermission(string permission, int pid, int uid, string
			 message)
		{
			enforce(permission, checkPermission(permission, pid, uid), false, uid, message);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void enforceCallingPermission(string permission, string message)
		{
			enforce(permission, checkCallingPermission(permission), false, android.os.Binder.
				getCallingUid(), message);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void enforceCallingOrSelfPermission(string permission, string message
			)
		{
			enforce(permission, checkCallingOrSelfPermission(permission), true, android.os.Binder
				.getCallingUid(), message);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void grantUriPermission(string toPackage, System.Uri uri, int modeFlags
			)
		{
			try
			{
				android.app.ActivityManagerNative.getDefault().grantUriPermission(mMainThread.getApplicationThread
					(), toPackage, uri, modeFlags);
			}
			catch (android.os.RemoteException)
			{
			}
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void revokeUriPermission(System.Uri uri, int modeFlags)
		{
			try
			{
				android.app.ActivityManagerNative.getDefault().revokeUriPermission(mMainThread.getApplicationThread
					(), uri, modeFlags);
			}
			catch (android.os.RemoteException)
			{
			}
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override int checkUriPermission(System.Uri uri, int pid, int uid, int modeFlags
			)
		{
			try
			{
				return android.app.ActivityManagerNative.getDefault().checkUriPermission(uri, pid
					, uid, modeFlags);
			}
			catch (android.os.RemoteException)
			{
				return android.content.pm.PackageManager.PERMISSION_DENIED;
			}
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override int checkCallingUriPermission(System.Uri uri, int modeFlags)
		{
			int pid = android.os.Binder.getCallingPid();
			if (pid != android.os.Process.myPid())
			{
				return checkUriPermission(uri, pid, android.os.Binder.getCallingUid(), modeFlags);
			}
			return android.content.pm.PackageManager.PERMISSION_DENIED;
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override int checkCallingOrSelfUriPermission(System.Uri uri, int modeFlags
			)
		{
			return checkUriPermission(uri, android.os.Binder.getCallingPid(), android.os.Binder
				.getCallingUid(), modeFlags);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override int checkUriPermission(System.Uri uri, string readPermission, string
			 writePermission, int pid, int uid, int modeFlags)
		{
			if ((modeFlags & android.content.Intent.FLAG_GRANT_READ_URI_PERMISSION) != 0)
			{
				if (readPermission == null || checkPermission(readPermission, pid, uid) == android.content.pm.PackageManager
					.PERMISSION_GRANTED)
				{
					return android.content.pm.PackageManager.PERMISSION_GRANTED;
				}
			}
			if ((modeFlags & android.content.Intent.FLAG_GRANT_WRITE_URI_PERMISSION) != 0)
			{
				if (writePermission == null || checkPermission(writePermission, pid, uid) == android.content.pm.PackageManager
					.PERMISSION_GRANTED)
				{
					return android.content.pm.PackageManager.PERMISSION_GRANTED;
				}
			}
			return uri != null ? checkUriPermission(uri, pid, uid, modeFlags) : android.content.pm.PackageManager
				.PERMISSION_DENIED;
		}

		private string uriModeFlagToString(int uriModeFlags)
		{
			switch (uriModeFlags)
			{
				case android.content.Intent.FLAG_GRANT_READ_URI_PERMISSION | android.content.Intent
					.FLAG_GRANT_WRITE_URI_PERMISSION:
				{
					return "read and write";
				}

				case android.content.Intent.FLAG_GRANT_READ_URI_PERMISSION:
				{
					return "read";
				}

				case android.content.Intent.FLAG_GRANT_WRITE_URI_PERMISSION:
				{
					return "write";
				}
			}
			throw new System.ArgumentException("Unknown permission mode flags: " + uriModeFlags
				);
		}

		private void enforceForUri(int modeFlags, int resultOfCheck, bool selfToo, int uid
			, System.Uri uri, string message)
		{
			if (resultOfCheck != android.content.pm.PackageManager.PERMISSION_GRANTED)
			{
				throw new System.Security.SecurityException((message != null ? (message + ": ") : 
					string.Empty) + (selfToo ? "Neither user " + uid + " nor current process has " : 
					"User " + uid + " does not have ") + uriModeFlagToString(modeFlags) + " permission on "
					 + uri + ".");
			}
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void enforceUriPermission(System.Uri uri, int pid, int uid, int modeFlags
			, string message)
		{
			enforceForUri(modeFlags, checkUriPermission(uri, pid, uid, modeFlags), false, uid
				, uri, message);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void enforceCallingUriPermission(System.Uri uri, int modeFlags, string
			 message)
		{
			enforceForUri(modeFlags, checkCallingUriPermission(uri, modeFlags), false, android.os.Binder
				.getCallingUid(), uri, message);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void enforceCallingOrSelfUriPermission(System.Uri uri, int modeFlags
			, string message)
		{
			enforceForUri(modeFlags, checkCallingOrSelfUriPermission(uri, modeFlags), true, android.os.Binder
				.getCallingUid(), uri, message);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void enforceUriPermission(System.Uri uri, string readPermission, 
			string writePermission, int pid, int uid, int modeFlags, string message)
		{
			enforceForUri(modeFlags, checkUriPermission(uri, readPermission, writePermission, 
				pid, uid, modeFlags), false, uid, uri, message);
		}

		/// <exception cref="android.content.pm.PackageManager.NameNotFoundException"></exception>
		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override android.content.Context createPackageContext(string packageName, 
			int flags)
		{
			if (packageName.Equals("system") || packageName.Equals("android"))
			{
				return new android.app.ContextImpl(mMainThread.getSystemContext());
			}
			android.app.LoadedApk pi = mMainThread.getPackageInfo(packageName, mResources.getCompatibilityInfo
				(), flags);
			if (pi != null)
			{
				android.app.ContextImpl c = new android.app.ContextImpl();
				c.mRestricted = (flags & CONTEXT_RESTRICTED) == CONTEXT_RESTRICTED;
				c.init(pi, null, mMainThread, mResources, mBasePackageName);
				if (c.mResources != null)
				{
					return c;
				}
			}
			// Should be a better exception.
			throw new android.content.pm.PackageManager.NameNotFoundException("Application package "
				 + packageName + " not found");
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override bool isRestricted()
		{
			return mRestricted;
		}

		private java.io.File getDataDirFile()
		{
			if (mPackageInfo != null)
			{
				return mPackageInfo.getDataDirFile();
			}
			throw new java.lang.RuntimeException("Not supported in system context");
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override java.io.File getDir(string name, int mode)
		{
			name = "app_" + name;
			java.io.File file = makeFilename(getDataDirFile(), name);
			if (!file.exists())
			{
				file.mkdir();
				setFilePermissionsFromMode(file.getPath(), mode, android.os.FileUtils.S_IRWXU | android.os.FileUtils
					.S_IRWXG | android.os.FileUtils.S_IXOTH);
			}
			return file;
		}

		internal static android.app.ContextImpl createSystemContext(android.app.ActivityThread
			 mainThread)
		{
			android.app.ContextImpl context = new android.app.ContextImpl();
			context.init(android.content.res.Resources.getSystem(), mainThread);
			return context;
		}

		internal ContextImpl()
		{
			mOuterContext = this;
		}

		/// <summary>Create a new ApplicationContext from an existing one.</summary>
		/// <remarks>
		/// Create a new ApplicationContext from an existing one.  The new one
		/// works and operates the same as the one it is copying.
		/// </remarks>
		/// <param name="context">Existing application context.</param>
		internal ContextImpl(android.app.ContextImpl context)
		{
			mPackageInfo = context.mPackageInfo;
			mBasePackageName = context.mBasePackageName;
			mResources = context.mResources;
			mMainThread = context.mMainThread;
			mContentResolver = context.mContentResolver;
			mOuterContext = this;
		}

		internal void init(android.app.LoadedApk packageInfo, android.os.IBinder activityToken
			, android.app.ActivityThread mainThread)
		{
			init(packageInfo, activityToken, mainThread, null, null);
		}

		internal void init(android.app.LoadedApk packageInfo, android.os.IBinder activityToken
			, android.app.ActivityThread mainThread, android.content.res.Resources container
			, string basePackageName)
		{
			mPackageInfo = packageInfo;
			mBasePackageName = basePackageName != null ? basePackageName : packageInfo.mPackageName;
			mResources = mPackageInfo.getResources(mainThread);
			if (mResources != null && container != null && container.getCompatibilityInfo().applicationScale
				 != mResources.getCompatibilityInfo().applicationScale)
			{
				mResources = mainThread.getTopLevelResources(mPackageInfo.getResDir(), container.
					getCompatibilityInfo());
			}
			mMainThread = mainThread;
			mContentResolver = new android.app.ContextImpl.ApplicationContentResolver(this, mainThread
				);
			setActivityToken(activityToken);
		}

		internal void init(android.content.res.Resources resources, android.app.ActivityThread
			 mainThread)
		{
			mPackageInfo = null;
			mBasePackageName = null;
			mResources = resources;
			mMainThread = mainThread;
			mContentResolver = new android.app.ContextImpl.ApplicationContentResolver(this, mainThread
				);
		}

		internal void scheduleFinalCleanup(string who, string what)
		{
			mMainThread.scheduleContextCleanup(this, who, what);
		}

		internal void performFinalCleanup(string who, string what)
		{
			//Log.i(TAG, "Cleanup up context: " + this);
			mPackageInfo.removeContextRegistrations(getOuterContext(), who, what);
		}

		internal android.content.Context getReceiverRestrictedContext()
		{
			if (mReceiverRestrictedContext != null)
			{
				return mReceiverRestrictedContext;
			}
			return mReceiverRestrictedContext = new android.app.ReceiverRestrictedContext(getOuterContext
				());
		}

		internal void setActivityToken(android.os.IBinder token)
		{
			mActivityToken = token;
		}

		internal void setOuterContext(android.content.Context context)
		{
			mOuterContext = context;
		}

		internal android.content.Context getOuterContext()
		{
			return mOuterContext;
		}

		internal android.os.IBinder getActivityToken()
		{
			return mActivityToken;
		}

		internal static void setFilePermissionsFromMode(string name, int mode, int extraPermissions
			)
		{
			int perms = android.os.FileUtils.S_IRUSR | android.os.FileUtils.S_IWUSR | android.os.FileUtils
				.S_IRGRP | android.os.FileUtils.S_IWGRP | extraPermissions;
			if ((mode & MODE_WORLD_READABLE) != 0)
			{
				perms |= android.os.FileUtils.S_IROTH;
			}
			if ((mode & MODE_WORLD_WRITEABLE) != 0)
			{
				perms |= android.os.FileUtils.S_IWOTH;
			}
			android.os.FileUtils.setPermissions(name, perms, -1, -1);
		}

		private java.io.File validateFilePath(string name, bool createDirectory)
		{
			java.io.File dir;
			java.io.File f;
			if (name[0] == java.io.File.separatorChar)
			{
				string dirPath = Sharpen.StringHelper.Substring(name, 0, name.LastIndexOf(java.io.File
					.separatorChar));
				dir = new java.io.File(dirPath);
				name = Sharpen.StringHelper.Substring(name, name.LastIndexOf(java.io.File.separatorChar
					));
				f = new java.io.File(dir, name);
			}
			else
			{
				dir = getDatabasesDir();
				f = makeFilename(dir, name);
			}
			if (createDirectory && !dir.isDirectory() && dir.mkdir())
			{
				android.os.FileUtils.setPermissions(dir.getPath(), android.os.FileUtils.S_IRWXU |
					 android.os.FileUtils.S_IRWXG | android.os.FileUtils.S_IXOTH, -1, -1);
			}
			return f;
		}

		private java.io.File makeFilename(java.io.File @base, string name)
		{
			if (name.IndexOf(java.io.File.separatorChar) < 0)
			{
				return new java.io.File(@base, name);
			}
			throw new System.ArgumentException("File " + name + " contains a path separator");
		}

		private sealed class ApplicationContentResolver : android.content.ContentResolver
		{
			public ApplicationContentResolver(android.content.Context context, android.app.ActivityThread
				 mainThread) : base(context)
			{
				// ----------------------------------------------------------------------
				// ----------------------------------------------------------------------
				// ----------------------------------------------------------------------
				mMainThread = mainThread;
			}

			[Sharpen.OverridesMethod(@"android.content.ContentResolver")]
			protected internal override android.content.IContentProvider acquireProvider(android.content.Context
				 context, string name)
			{
				return mMainThread.acquireProvider(context, name);
			}

			[Sharpen.OverridesMethod(@"android.content.ContentResolver")]
			protected internal override android.content.IContentProvider acquireExistingProvider
				(android.content.Context context, string name)
			{
				return mMainThread.acquireExistingProvider(context, name);
			}

			[Sharpen.OverridesMethod(@"android.content.ContentResolver")]
			public override bool releaseProvider(android.content.IContentProvider provider)
			{
				return mMainThread.releaseProvider(provider);
			}

			internal readonly android.app.ActivityThread mMainThread;
		}
	}
}

using Sharpen;

namespace android.app
{
	[System.Serializable]
	[Sharpen.Sharpened]
	internal sealed class IntentReceiverLeaked : android.util.AndroidRuntimeException
	{
		public IntentReceiverLeaked(string msg) : base(msg)
		{
		}
	}

	[System.Serializable]
	[Sharpen.Sharpened]
	internal sealed class ServiceConnectionLeaked : android.util.AndroidRuntimeException
	{
		public ServiceConnectionLeaked(string msg) : base(msg)
		{
		}
	}

	/// <summary>Local state maintained about a currently loaded .apk.</summary>
	/// <remarks>Local state maintained about a currently loaded .apk.</remarks>
	/// <hide></hide>
	[Sharpen.Sharpened]
	public sealed partial class LoadedApk
	{
		private readonly android.app.ActivityThread mActivityThread;

		private readonly android.content.pm.ApplicationInfo mApplicationInfo;

		internal readonly string mPackageName;

		private readonly string mAppDir;

		private readonly string mResDir;

		private readonly string[] mSharedLibraries;

		private readonly string mDataDir;

		private readonly string mLibDir;

		private readonly java.io.File mDataDirFile;

		private readonly java.lang.ClassLoader mBaseClassLoader;

		private readonly bool mSecurityViolation;

		private readonly bool mIncludeCode;

		public readonly android.view.CompatibilityInfoHolder mCompatibilityInfo = new android.view.CompatibilityInfoHolder
			();

		internal android.content.res.Resources mResources;

		private java.lang.ClassLoader mClassLoader;

		private android.app.Application mApplication;

		private readonly java.util.HashMap<android.content.Context, java.util.HashMap<android.content.BroadcastReceiver
			, android.app.LoadedApk.ReceiverDispatcher>> mReceivers = new java.util.HashMap<
			android.content.Context, java.util.HashMap<android.content.BroadcastReceiver, android.app.LoadedApk
			.ReceiverDispatcher>>();

		private readonly java.util.HashMap<android.content.Context, java.util.HashMap<android.content.BroadcastReceiver
			, android.app.LoadedApk.ReceiverDispatcher>> mUnregisteredReceivers = new java.util.HashMap
			<android.content.Context, java.util.HashMap<android.content.BroadcastReceiver, android.app.LoadedApk
			.ReceiverDispatcher>>();

		private readonly java.util.HashMap<android.content.Context, java.util.HashMap<android.content.ServiceConnection
			, android.app.LoadedApk.ServiceDispatcher>> mServices = new java.util.HashMap<android.content.Context
			, java.util.HashMap<android.content.ServiceConnection, android.app.LoadedApk.ServiceDispatcher
			>>();

		private readonly java.util.HashMap<android.content.Context, java.util.HashMap<android.content.ServiceConnection
			, android.app.LoadedApk.ServiceDispatcher>> mUnboundServices = new java.util.HashMap
			<android.content.Context, java.util.HashMap<android.content.ServiceConnection, android.app.LoadedApk
			.ServiceDispatcher>>();

		internal int mClientCount = 0;

		internal android.app.Application getApplication()
		{
			return mApplication;
		}

		/// <summary>
		/// Create information about a new .apk
		/// NOTE: This constructor is called with ActivityThread's lock held,
		/// so MUST NOT call back out to the activity manager.
		/// </summary>
		/// <remarks>
		/// Create information about a new .apk
		/// NOTE: This constructor is called with ActivityThread's lock held,
		/// so MUST NOT call back out to the activity manager.
		/// </remarks>
		public LoadedApk(android.app.ActivityThread activityThread, android.content.pm.ApplicationInfo
			 aInfo, android.content.res.CompatibilityInfo compatInfo, android.app.ActivityThread
			 mainThread, java.lang.ClassLoader baseLoader, bool securityViolation, bool includeCode
			)
		{
			mActivityThread = activityThread;
			mApplicationInfo = aInfo;
			mPackageName = aInfo.packageName;
			mAppDir = aInfo.sourceDir;
			mResDir = aInfo.uid == android.os.Process.myUid() ? aInfo.sourceDir : aInfo.publicSourceDir;
			mSharedLibraries = aInfo.sharedLibraryFiles;
			mDataDir = aInfo.dataDir;
			mDataDirFile = mDataDir != null ? new java.io.File(mDataDir) : null;
			mLibDir = aInfo.nativeLibraryDir;
			mBaseClassLoader = baseLoader;
			mSecurityViolation = securityViolation;
			mIncludeCode = includeCode;
			mCompatibilityInfo.set(compatInfo);
			if (mAppDir == null)
			{
				if (android.app.ActivityThread.mSystemContext == null)
				{
					android.app.ActivityThread.mSystemContext = android.app.ContextImpl.createSystemContext
						(mainThread);
					android.app.ActivityThread.mSystemContext.getResources().updateConfiguration(mainThread
						.getConfiguration(), mainThread.getDisplayMetricsLocked(compatInfo, false), compatInfo
						);
				}
				//Slog.i(TAG, "Created system resources "
				//        + mSystemContext.getResources() + ": "
				//        + mSystemContext.getResources().getConfiguration());
				mClassLoader = android.app.ActivityThread.mSystemContext.getClassLoader();
				mResources = android.app.ActivityThread.mSystemContext.getResources();
			}
		}

		public LoadedApk(android.app.ActivityThread activityThread, string name, android.content.Context
			 systemContext, android.content.pm.ApplicationInfo info, android.content.res.CompatibilityInfo
			 compatInfo)
		{
			mActivityThread = activityThread;
			mApplicationInfo = info != null ? info : new android.content.pm.ApplicationInfo();
			mApplicationInfo.packageName = name;
			mPackageName = name;
			mAppDir = null;
			mResDir = null;
			mSharedLibraries = null;
			mDataDir = null;
			mDataDirFile = null;
			mLibDir = null;
			mBaseClassLoader = null;
			mSecurityViolation = false;
			mIncludeCode = true;
			mClassLoader = systemContext.getClassLoader();
			mResources = systemContext.getResources();
			mCompatibilityInfo.set(compatInfo);
		}

		public string getPackageName()
		{
			return mPackageName;
		}

		public android.content.pm.ApplicationInfo getApplicationInfo()
		{
			return mApplicationInfo;
		}

		public bool isSecurityViolation()
		{
			return mSecurityViolation;
		}

		/// <summary>
		/// Gets the array of shared libraries that are listed as
		/// used by the given package.
		/// </summary>
		/// <remarks>
		/// Gets the array of shared libraries that are listed as
		/// used by the given package.
		/// </remarks>
		/// <param name="packageName">
		/// the name of the package (note: not its
		/// file name)
		/// </param>
		/// <returns>
		/// null-ok; the array of shared libraries, each one
		/// a fully-qualified path
		/// </returns>
		private static string[] getLibrariesFor(string packageName)
		{
			android.content.pm.ApplicationInfo ai = null;
			try
			{
				ai = android.app.ActivityThread.getPackageManager().getApplicationInfo(packageName
					, android.content.pm.PackageManager.GET_SHARED_LIBRARY_FILES);
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.AssertionError(e);
			}
			if (ai == null)
			{
				return null;
			}
			return ai.sharedLibraryFiles;
		}

		/// <summary>
		/// Combines two arrays (of library names) such that they are
		/// concatenated in order but are devoid of duplicates.
		/// </summary>
		/// <remarks>
		/// Combines two arrays (of library names) such that they are
		/// concatenated in order but are devoid of duplicates. The
		/// result is a single string with the names of the libraries
		/// separated by colons, or <code>null</code> if both lists
		/// were <code>null</code> or empty.
		/// </remarks>
		/// <param name="list1">null-ok; the first list</param>
		/// <param name="list2">null-ok; the second list</param>
		/// <returns>null-ok; the combination</returns>
		private static string combineLibs(string[] list1, string[] list2)
		{
			java.lang.StringBuilder result = new java.lang.StringBuilder(300);
			bool first = true;
			if (list1 != null)
			{
				foreach (string s in list1)
				{
					if (first)
					{
						first = false;
					}
					else
					{
						result.append(':');
					}
					result.append(s);
				}
			}
			// Only need to check for duplicates if list1 was non-empty.
			bool dupCheck = !first;
			if (list2 != null)
			{
				foreach (string s in list2)
				{
					if (dupCheck && android.util.@internal.ArrayUtils.contains(list1, s))
					{
						continue;
					}
					if (first)
					{
						first = false;
					}
					else
					{
						result.append(':');
					}
					result.append(s);
				}
			}
			return result.ToString();
		}

		[Sharpen.Stub]
		private void initializeJavaContextClassLoader()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.NakedStub]
		public class WarningContextClassLoader
		{
		}

		// Temporarily disable logging of disk reads on the Looper thread
		// as this is early and necessary.
		public string getAppDir()
		{
			return mAppDir;
		}

		public string getResDir()
		{
			return mResDir;
		}

		public string getDataDir()
		{
			return mDataDir;
		}

		public java.io.File getDataDirFile()
		{
			return mDataDirFile;
		}

		public android.content.res.AssetManager getAssets(android.app.ActivityThread mainThread
			)
		{
			return getResources(mainThread).getAssets();
		}

		public android.content.res.Resources getResources(android.app.ActivityThread mainThread
			)
		{
			if (mResources == null)
			{
				mResources = mainThread.getTopLevelResources(mResDir, this);
			}
			return mResources;
		}

		public android.app.Application makeApplication(bool forceDefaultAppClass, android.app.Instrumentation
			 instrumentation)
		{
			if (mApplication != null)
			{
				return mApplication;
			}
			android.app.Application app = null;
			string appClass = mApplicationInfo.className;
			if (forceDefaultAppClass || (appClass == null))
			{
				appClass = "android.app.Application";
			}
			try
			{
				java.lang.ClassLoader cl = getClassLoader();
				android.app.ContextImpl appContext = new android.app.ContextImpl();
				appContext.init(this, null, mActivityThread);
				app = mActivityThread.mInstrumentation.newApplication(cl, appClass, appContext);
				appContext.setOuterContext(app);
			}
			catch (System.Exception e)
			{
				if (!mActivityThread.mInstrumentation.onException(app, e))
				{
					throw new java.lang.RuntimeException("Unable to instantiate application " + appClass
						 + ": " + e.ToString(), e);
				}
			}
			mActivityThread.mAllApplications.add(app);
			mApplication = app;
			if (instrumentation != null)
			{
				try
				{
					instrumentation.callApplicationOnCreate(app);
				}
				catch (System.Exception e)
				{
					if (!instrumentation.onException(app, e))
					{
						throw new java.lang.RuntimeException("Unable to create application " + app.GetType
							().FullName + ": " + e.ToString(), e);
					}
				}
			}
			return app;
		}

		[Sharpen.Stub]
		public void removeContextRegistrations(android.content.Context context, string who
			, string what)
		{
			throw new System.NotImplementedException();
		}

		// system crashed, nothing we can do
		//Slog.i(TAG, "Receiver registrations: " + mReceivers);
		// system crashed, nothing we can do
		//Slog.i(TAG, "Service registrations: " + mServices);
		public android.content.IIntentReceiver getReceiverDispatcher(android.content.BroadcastReceiver
			 r, android.content.Context context, android.os.Handler handler, android.app.Instrumentation
			 instrumentation, bool registered)
		{
			lock (mReceivers)
			{
				android.app.LoadedApk.ReceiverDispatcher rd = null;
				java.util.HashMap<android.content.BroadcastReceiver, android.app.LoadedApk.ReceiverDispatcher
					> map = null;
				if (registered)
				{
					map = mReceivers.get(context);
					if (map != null)
					{
						rd = map.get(r);
					}
				}
				if (rd == null)
				{
					rd = new android.app.LoadedApk.ReceiverDispatcher(r, context, handler, instrumentation
						, registered);
					if (registered)
					{
						if (map == null)
						{
							map = new java.util.HashMap<android.content.BroadcastReceiver, android.app.LoadedApk
								.ReceiverDispatcher>();
							mReceivers.put(context, map);
						}
						map.put(r, rd);
					}
				}
				else
				{
					rd.validate(context, handler);
				}
				rd.mForgotten = false;
				return rd.getIIntentReceiver();
			}
		}

		[Sharpen.Stub]
		public android.content.IIntentReceiver forgetReceiverDispatcher(android.content.Context
			 context, android.content.BroadcastReceiver r)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal sealed class ReceiverDispatcher
		{
			[Sharpen.Stub]
			internal sealed class InnerReceiver : android.content.IIntentReceiverClass.Stub
			{
				internal readonly java.lang.@ref.WeakReference<android.app.LoadedApk.ReceiverDispatcher
					> mDispatcher;

				internal readonly android.app.LoadedApk.ReceiverDispatcher mStrongRef;

				[Sharpen.Stub]
				internal InnerReceiver(android.app.LoadedApk.ReceiverDispatcher rd, bool strong)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.IIntentReceiver")]
				public override void performReceive(android.content.Intent intent, int resultCode
					, string data, android.os.Bundle extras, bool ordered, bool sticky)
				{
					throw new System.NotImplementedException();
				}
			}

			internal readonly android.content.IIntentReceiverClass.Stub mIIntentReceiver;

			internal readonly android.content.BroadcastReceiver mReceiver;

			internal readonly android.content.Context mContext;

			internal readonly android.os.Handler mActivityThread;

			internal readonly android.app.Instrumentation mInstrumentation;

			internal readonly bool mRegistered;

			internal readonly android.app.IntentReceiverLeaked mLocation;

			internal java.lang.RuntimeException mUnregisterLocation;

			internal bool mForgotten;

			[Sharpen.Stub]
			internal ReceiverDispatcher(android.content.BroadcastReceiver receiver, android.content.Context
				 context, android.os.Handler activityThread, android.app.Instrumentation instrumentation
				, bool registered)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal void validate(android.content.Context context, android.os.Handler activityThread
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal android.app.IntentReceiverLeaked getLocation()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal android.content.BroadcastReceiver getIntentReceiver()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal android.content.IIntentReceiver getIIntentReceiver()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal void setUnregisterLocation(java.lang.RuntimeException ex)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal java.lang.RuntimeException getUnregisterLocation()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public void performReceive(android.content.Intent intent, int resultCode, string 
				data, android.os.Bundle extras, bool ordered, bool sticky)
			{
				throw new System.NotImplementedException();
			}
		}

		// The activity manager dispatched a broadcast to a registered
		// receiver in this process, but before it could be delivered the
		// receiver was unregistered.  Acknowledge the broadcast on its
		// behalf so that the system's broadcast sequence can continue.
		public android.app.IServiceConnection getServiceDispatcher(android.content.ServiceConnection
			 c, android.content.Context context, android.os.Handler handler, int flags)
		{
			lock (mServices)
			{
				android.app.LoadedApk.ServiceDispatcher sd = null;
				java.util.HashMap<android.content.ServiceConnection, android.app.LoadedApk.ServiceDispatcher
					> map = mServices.get(context);
				if (map != null)
				{
					sd = map.get(c);
				}
				if (sd == null)
				{
					sd = new android.app.LoadedApk.ServiceDispatcher(c, context, handler, flags);
					if (map == null)
					{
						map = new java.util.HashMap<android.content.ServiceConnection, android.app.LoadedApk
							.ServiceDispatcher>();
						mServices.put(context, map);
					}
					map.put(c, sd);
				}
				else
				{
					sd.validate(context, handler);
				}
				return sd.getIServiceConnection();
			}
		}

		[Sharpen.Stub]
		public android.app.IServiceConnection forgetServiceDispatcher(android.content.Context
			 context, android.content.ServiceConnection c)
		{
			throw new System.NotImplementedException();
		}

		internal sealed class ServiceDispatcher
		{
			private readonly android.app.LoadedApk.ServiceDispatcher.InnerConnection mIServiceConnection;

			private readonly android.content.ServiceConnection mConnection;

			private readonly android.content.Context mContext;

			private readonly android.os.Handler mActivityThread;

			private readonly android.app.ServiceConnectionLeaked mLocation;

			private readonly int mFlags;

			private java.lang.RuntimeException mUnbindLocation;

			private bool mDied;

			private class ConnectionInfo
			{
				internal android.os.IBinder binder;

				internal android.os.IBinderClass.DeathRecipient deathMonitor;
			}

			private class InnerConnection : android.app.IServiceConnectionClass.Stub
			{
				internal readonly java.lang.@ref.WeakReference<android.app.LoadedApk.ServiceDispatcher
					> mDispatcher;

				internal InnerConnection(android.app.LoadedApk.ServiceDispatcher sd)
				{
					mDispatcher = new java.lang.@ref.WeakReference<android.app.LoadedApk.ServiceDispatcher
						>(sd);
				}

				/// <exception cref="android.os.RemoteException"></exception>
				[Sharpen.ImplementsInterface(@"android.app.IServiceConnection")]
				public override void connected(android.content.ComponentName name, android.os.IBinder
					 service)
				{
					android.app.LoadedApk.ServiceDispatcher sd = mDispatcher.get();
					if (sd != null)
					{
						sd.connected(name, service);
					}
				}
			}

			private readonly java.util.HashMap<android.content.ComponentName, android.app.LoadedApk.ServiceDispatcher
				.ConnectionInfo> mActiveConnections = new java.util.HashMap<android.content.ComponentName
				, android.app.LoadedApk.ServiceDispatcher.ConnectionInfo>();

			internal ServiceDispatcher(android.content.ServiceConnection conn, android.content.Context
				 context, android.os.Handler activityThread, int flags)
			{
				mIServiceConnection = new android.app.LoadedApk.ServiceDispatcher.InnerConnection
					(this);
				mConnection = conn;
				mContext = context;
				mActivityThread = activityThread;
				mLocation = new android.app.ServiceConnectionLeaked(null);
				XobotOS.Runtime.Util.FillInStackTrace(mLocation);
				mFlags = flags;
			}

			internal void validate(android.content.Context context, android.os.Handler activityThread
				)
			{
				if (mContext != context)
				{
					throw new java.lang.RuntimeException("ServiceConnection " + mConnection + " registered with differing Context (was "
						 + mContext + " now " + context + ")");
				}
				if (mActivityThread != activityThread)
				{
					throw new java.lang.RuntimeException("ServiceConnection " + mConnection + " registered with differing handler (was "
						 + mActivityThread + " now " + activityThread + ")");
				}
			}

			internal void doForget()
			{
				lock (this)
				{
					java.util.Iterator<android.app.LoadedApk.ServiceDispatcher.ConnectionInfo> it = mActiveConnections
						.values().iterator();
					while (it.hasNext())
					{
						android.app.LoadedApk.ServiceDispatcher.ConnectionInfo ci = it.next();
						ci.binder.unlinkToDeath(ci.deathMonitor, 0);
					}
					mActiveConnections.clear();
				}
			}

			internal android.app.ServiceConnectionLeaked getLocation()
			{
				return mLocation;
			}

			internal android.content.ServiceConnection getServiceConnection()
			{
				return mConnection;
			}

			internal android.app.IServiceConnection getIServiceConnection()
			{
				return mIServiceConnection;
			}

			internal int getFlags()
			{
				return mFlags;
			}

			internal void setUnbindLocation(java.lang.RuntimeException ex)
			{
				mUnbindLocation = ex;
			}

			internal java.lang.RuntimeException getUnbindLocation()
			{
				return mUnbindLocation;
			}

			public void connected(android.content.ComponentName name, android.os.IBinder service
				)
			{
				if (mActivityThread != null)
				{
					mActivityThread.post(new android.app.LoadedApk.ServiceDispatcher.RunConnection(this
						, name, service, 0));
				}
				else
				{
					doConnected(name, service);
				}
			}

			public void death(android.content.ComponentName name, android.os.IBinder service)
			{
				android.app.LoadedApk.ServiceDispatcher.ConnectionInfo old;
				lock (this)
				{
					mDied = true;
					old = mActiveConnections.remove(name);
					if (old == null || old.binder != service)
					{
						// Death for someone different than who we last
						// reported...  just ignore it.
						return;
					}
					old.binder.unlinkToDeath(old.deathMonitor, 0);
				}
				if (mActivityThread != null)
				{
					mActivityThread.post(new android.app.LoadedApk.ServiceDispatcher.RunConnection(this
						, name, service, 1));
				}
				else
				{
					doDeath(name, service);
				}
			}

			public void doConnected(android.content.ComponentName name, android.os.IBinder service
				)
			{
				android.app.LoadedApk.ServiceDispatcher.ConnectionInfo old;
				android.app.LoadedApk.ServiceDispatcher.ConnectionInfo info;
				lock (this)
				{
					old = mActiveConnections.get(name);
					if (old != null && old.binder == service)
					{
						// Huh, already have this one.  Oh well!
						return;
					}
					if (service != null)
					{
						// A new service is being connected... set it all up.
						mDied = false;
						info = new android.app.LoadedApk.ServiceDispatcher.ConnectionInfo();
						info.binder = service;
						info.deathMonitor = new android.app.LoadedApk.ServiceDispatcher.DeathMonitor(this
							, name, service);
						try
						{
							service.linkToDeath(info.deathMonitor, 0);
							mActiveConnections.put(name, info);
						}
						catch (android.os.RemoteException)
						{
							// This service was dead before we got it...  just
							// don't do anything with it.
							mActiveConnections.remove(name);
							return;
						}
					}
					else
					{
						// The named service is being disconnected... clean up.
						mActiveConnections.remove(name);
					}
					if (old != null)
					{
						old.binder.unlinkToDeath(old.deathMonitor, 0);
					}
				}
				// If there was an old service, it is not disconnected.
				if (old != null)
				{
					mConnection.onServiceDisconnected(name);
				}
				// If there is a new service, it is now connected.
				if (service != null)
				{
					mConnection.onServiceConnected(name, service);
				}
			}

			public void doDeath(android.content.ComponentName name, android.os.IBinder service
				)
			{
				mConnection.onServiceDisconnected(name);
			}

			private sealed class RunConnection : java.lang.Runnable
			{
				internal RunConnection(ServiceDispatcher _enclosing, android.content.ComponentName
					 name, android.os.IBinder service, int command)
				{
					this._enclosing = _enclosing;
					this.mName = name;
					this.mService = service;
					this.mCommand = command;
				}

				[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
				public void run()
				{
					if (this.mCommand == 0)
					{
						this._enclosing.doConnected(this.mName, this.mService);
					}
					else
					{
						if (this.mCommand == 1)
						{
							this._enclosing.doDeath(this.mName, this.mService);
						}
					}
				}

				internal readonly android.content.ComponentName mName;

				internal readonly android.os.IBinder mService;

				internal readonly int mCommand;

				private readonly ServiceDispatcher _enclosing;
			}

			private sealed class DeathMonitor : android.os.IBinderClass.DeathRecipient
			{
				internal DeathMonitor(ServiceDispatcher _enclosing, android.content.ComponentName
					 name, android.os.IBinder service)
				{
					this._enclosing = _enclosing;
					this.mName = name;
					this.mService = service;
				}

				[Sharpen.ImplementsInterface(@"android.os.IBinder.DeathRecipient")]
				public void binderDied()
				{
					this._enclosing.death(this.mName, this.mService);
				}

				internal readonly android.content.ComponentName mName;

				internal readonly android.os.IBinder mService;

				private readonly ServiceDispatcher _enclosing;
			}
		}
	}
}

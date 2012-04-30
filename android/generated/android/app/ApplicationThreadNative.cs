using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	public abstract class ApplicationThreadNative : android.os.Binder, android.app.IApplicationThread
	{
		[Sharpen.Stub]
		public static android.app.IApplicationThread asInterface(android.os.IBinder obj)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public ApplicationThreadNative()
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
		[Sharpen.ImplementsInterface(@"android.os.IInterface")]
		public virtual android.os.IBinder asBinder()
		{
			throw new System.NotImplementedException();
		}

		public abstract void bindApplication(string arg1, android.content.pm.ApplicationInfo
			 arg2, java.util.List<android.content.pm.ProviderInfo> arg3, android.content.ComponentName
			 arg4, string arg5, android.os.ParcelFileDescriptor arg6, bool arg7, android.os.Bundle
			 arg8, android.app.IInstrumentationWatcher arg9, int arg10, bool arg11, bool arg12
			, android.content.res.Configuration arg13, android.content.res.CompatibilityInfo
			 arg14, java.util.Map<string, android.os.IBinder> arg15, android.os.Bundle arg16
			);

		public abstract void clearDnsCache();

		public abstract void dispatchPackageBroadcast(int arg1, string[] arg2);

		public abstract void dumpActivity(java.io.FileDescriptor arg1, android.os.IBinder
			 arg2, string arg3, string[] arg4);

		public abstract void dumpGfxInfo(java.io.FileDescriptor arg1, string[] arg2);

		public abstract void dumpHeap(bool arg1, string arg2, android.os.ParcelFileDescriptor
			 arg3);

		public abstract android.os.Debug.MemoryInfo dumpMemInfo(java.io.FileDescriptor arg1
			, bool arg2, bool arg3, string[] arg4);

		public abstract void dumpService(java.io.FileDescriptor arg1, android.os.IBinder 
			arg2, string[] arg3);

		public abstract void getMemoryInfo(android.os.Debug.MemoryInfo arg1);

		public abstract void processInBackground();

		public abstract void profilerControl(bool arg1, string arg2, android.os.ParcelFileDescriptor
			 arg3, int arg4);

		public abstract void requestThumbnail(android.os.IBinder arg1);

		public abstract void scheduleActivityConfigurationChanged(android.os.IBinder arg1
			);

		public abstract void scheduleBindService(android.os.IBinder arg1, android.content.Intent
			 arg2, bool arg3);

		public abstract void scheduleConfigurationChanged(android.content.res.Configuration
			 arg1);

		public abstract void scheduleCrash(string arg1);

		public abstract void scheduleCreateBackupAgent(android.content.pm.ApplicationInfo
			 arg1, android.content.res.CompatibilityInfo arg2, int arg3);

		public abstract void scheduleCreateService(android.os.IBinder arg1, android.content.pm.ServiceInfo
			 arg2, android.content.res.CompatibilityInfo arg3);

		public abstract void scheduleDestroyActivity(android.os.IBinder arg1, bool arg2, 
			int arg3);

		public abstract void scheduleDestroyBackupAgent(android.content.pm.ApplicationInfo
			 arg1, android.content.res.CompatibilityInfo arg2);

		public abstract void scheduleExit();

		public abstract void scheduleLaunchActivity(android.content.Intent arg1, android.os.IBinder
			 arg2, int arg3, android.content.pm.ActivityInfo arg4, android.content.res.Configuration
			 arg5, android.content.res.CompatibilityInfo arg6, android.os.Bundle arg7, java.util.List
			<android.app.ResultInfo> arg8, java.util.List<android.content.Intent> arg9, bool
			 arg10, bool arg11, string arg12, android.os.ParcelFileDescriptor arg13, bool arg14
			);

		public abstract void scheduleLowMemory();

		public abstract void scheduleNewIntent(java.util.List<android.content.Intent> arg1
			, android.os.IBinder arg2);

		public abstract void schedulePauseActivity(android.os.IBinder arg1, bool arg2, bool
			 arg3, int arg4);

		public abstract void scheduleReceiver(android.content.Intent arg1, android.content.pm.ActivityInfo
			 arg2, android.content.res.CompatibilityInfo arg3, int arg4, string arg5, android.os.Bundle
			 arg6, bool arg7);

		public abstract void scheduleRegisteredReceiver(android.content.IIntentReceiver arg1
			, android.content.Intent arg2, int arg3, string arg4, android.os.Bundle arg5, bool
			 arg6, bool arg7);

		public abstract void scheduleRelaunchActivity(android.os.IBinder arg1, java.util.List
			<android.app.ResultInfo> arg2, java.util.List<android.content.Intent> arg3, int 
			arg4, bool arg5, android.content.res.Configuration arg6);

		public abstract void scheduleResumeActivity(android.os.IBinder arg1, bool arg2);

		public abstract void scheduleSendResult(android.os.IBinder arg1, java.util.List<android.app.ResultInfo
			> arg2);

		public abstract void scheduleServiceArgs(android.os.IBinder arg1, bool arg2, int 
			arg3, int arg4, android.content.Intent arg5);

		public abstract void scheduleSleeping(android.os.IBinder arg1, bool arg2);

		public abstract void scheduleStopActivity(android.os.IBinder arg1, bool arg2, int
			 arg3);

		public abstract void scheduleStopService(android.os.IBinder arg1);

		public abstract void scheduleSuicide();

		public abstract void scheduleTrimMemory(int arg1);

		public abstract void scheduleUnbindService(android.os.IBinder arg1, android.content.Intent
			 arg2);

		public abstract void scheduleWindowVisibility(android.os.IBinder arg1, bool arg2);

		public abstract void setCoreSettings(android.os.Bundle arg1);

		public abstract void setHttpProxy(string arg1, string arg2, string arg3);

		public abstract void setSchedulingGroup(int arg1);

		public abstract void updatePackageCompatibilityInfo(string arg1, android.content.res.CompatibilityInfo
			 arg2);

		public abstract void updateTimeZone();
	}

	[Sharpen.Stub]
	internal class ApplicationThreadProxy : android.app.IApplicationThread
	{
		private readonly android.os.IBinder mRemote;

		[Sharpen.Stub]
		public ApplicationThreadProxy(android.os.IBinder remote)
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
		[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
		public virtual void schedulePauseActivity(android.os.IBinder token, bool finished
			, bool userLeaving, int configChanges)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
		public virtual void scheduleStopActivity(android.os.IBinder token, bool showWindow
			, int configChanges)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
		public virtual void scheduleWindowVisibility(android.os.IBinder token, bool showWindow
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
		public virtual void scheduleSleeping(android.os.IBinder token, bool sleeping)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
		public virtual void scheduleResumeActivity(android.os.IBinder token, bool isForward
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
		public virtual void scheduleSendResult(android.os.IBinder token, java.util.List<android.app.ResultInfo
			> results)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
		public virtual void scheduleLaunchActivity(android.content.Intent intent, android.os.IBinder
			 token, int ident, android.content.pm.ActivityInfo info, android.content.res.Configuration
			 curConfig, android.content.res.CompatibilityInfo compatInfo, android.os.Bundle 
			state, java.util.List<android.app.ResultInfo> pendingResults, java.util.List<android.content.Intent
			> pendingNewIntents, bool notResumed, bool isForward, string profileName, android.os.ParcelFileDescriptor
			 profileFd, bool autoStopProfiler)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
		public virtual void scheduleRelaunchActivity(android.os.IBinder token, java.util.List
			<android.app.ResultInfo> pendingResults, java.util.List<android.content.Intent> 
			pendingNewIntents, int configChanges, bool notResumed, android.content.res.Configuration
			 config)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
		public virtual void scheduleNewIntent(java.util.List<android.content.Intent> intents
			, android.os.IBinder token)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
		public virtual void scheduleDestroyActivity(android.os.IBinder token, bool finishing
			, int configChanges)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
		public virtual void scheduleReceiver(android.content.Intent intent, android.content.pm.ActivityInfo
			 info, android.content.res.CompatibilityInfo compatInfo, int resultCode, string 
			resultData, android.os.Bundle map, bool sync)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
		public virtual void scheduleCreateBackupAgent(android.content.pm.ApplicationInfo 
			app, android.content.res.CompatibilityInfo compatInfo, int backupMode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
		public virtual void scheduleDestroyBackupAgent(android.content.pm.ApplicationInfo
			 app, android.content.res.CompatibilityInfo compatInfo)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
		public virtual void scheduleCreateService(android.os.IBinder token, android.content.pm.ServiceInfo
			 info, android.content.res.CompatibilityInfo compatInfo)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
		public virtual void scheduleBindService(android.os.IBinder token, android.content.Intent
			 intent, bool rebind)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
		public virtual void scheduleUnbindService(android.os.IBinder token, android.content.Intent
			 intent)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
		public virtual void scheduleServiceArgs(android.os.IBinder token, bool taskRemoved
			, int startId, int flags, android.content.Intent args)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
		public virtual void scheduleStopService(android.os.IBinder token)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
		public virtual void bindApplication(string packageName, android.content.pm.ApplicationInfo
			 info, java.util.List<android.content.pm.ProviderInfo> providers, android.content.ComponentName
			 testName, string profileName, android.os.ParcelFileDescriptor profileFd, bool autoStopProfiler
			, android.os.Bundle testArgs, android.app.IInstrumentationWatcher testWatcher, int
			 debugMode, bool restrictedBackupMode, bool persistent, android.content.res.Configuration
			 config, android.content.res.CompatibilityInfo compatInfo, java.util.Map<string, 
			android.os.IBinder> services, android.os.Bundle coreSettings)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
		public virtual void scheduleExit()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
		public virtual void scheduleSuicide()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
		public virtual void requestThumbnail(android.os.IBinder token)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
		public virtual void scheduleConfigurationChanged(android.content.res.Configuration
			 config)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
		public virtual void updateTimeZone()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
		public virtual void clearDnsCache()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
		public virtual void setHttpProxy(string proxy, string port, string exclList)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
		public virtual void processInBackground()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
		public virtual void dumpService(java.io.FileDescriptor fd, android.os.IBinder token
			, string[] args)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
		public virtual void scheduleRegisteredReceiver(android.content.IIntentReceiver receiver
			, android.content.Intent intent, int resultCode, string dataStr, android.os.Bundle
			 extras, bool ordered, bool sticky)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
		public virtual void scheduleLowMemory()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
		public virtual void scheduleActivityConfigurationChanged(android.os.IBinder token
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
		public virtual void profilerControl(bool start, string path, android.os.ParcelFileDescriptor
			 fd, int profileType)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
		public virtual void setSchedulingGroup(int group)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
		public virtual void getMemoryInfo(android.os.Debug.MemoryInfo outInfo)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
		public virtual void dispatchPackageBroadcast(int cmd, string[] packages)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
		public virtual void scheduleCrash(string msg)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
		public virtual void dumpHeap(bool managed, string path, android.os.ParcelFileDescriptor
			 fd)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
		public virtual void dumpActivity(java.io.FileDescriptor fd, android.os.IBinder token
			, string prefix, string[] args)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
		public virtual void setCoreSettings(android.os.Bundle coreSettings)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
		public virtual void updatePackageCompatibilityInfo(string pkg, android.content.res.CompatibilityInfo
			 info)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
		public virtual void scheduleTrimMemory(int level)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
		public virtual android.os.Debug.MemoryInfo dumpMemInfo(java.io.FileDescriptor fd, 
			bool checkin, bool all, string[] args)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.IApplicationThread")]
		public virtual void dumpGfxInfo(java.io.FileDescriptor fd, string[] args)
		{
			throw new System.NotImplementedException();
		}
	}
}

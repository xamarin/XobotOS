using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	public abstract class Service : android.content.ContextWrapper, android.content.ComponentCallbacks2
	{
		internal const string TAG = "Service";

		[Sharpen.Stub]
		public Service() : base(null)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.app.Application getApplication()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onCreate()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"Implement onStartCommand(android.content.Intent, int, int) instead."
			)]
		public virtual void onStart(android.content.Intent intent, int startId)
		{
			throw new System.NotImplementedException();
		}

		public const int START_CONTINUATION_MASK = unchecked((int)(0xf));

		public const int START_STICKY_COMPATIBILITY = 0;

		public const int START_STICKY = 1;

		public const int START_NOT_STICKY = 2;

		public const int START_REDELIVER_INTENT = 3;

		public const int START_TASK_REMOVED_COMPLETE = 1000;

		public const int START_FLAG_REDELIVERY = unchecked((int)(0x0001));

		public const int START_FLAG_RETRY = unchecked((int)(0x0002));

		[Sharpen.Stub]
		public virtual int onStartCommand(android.content.Intent intent, int flags, int startId
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onDestroy()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.ComponentCallbacks")]
		public virtual void onConfigurationChanged(android.content.res.Configuration newConfig
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.ComponentCallbacks")]
		public virtual void onLowMemory()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.ComponentCallbacks2")]
		public virtual void onTrimMemory(int level)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public abstract android.os.IBinder onBind(android.content.Intent intent);

		[Sharpen.Stub]
		public virtual bool onUnbind(android.content.Intent intent)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onRebind(android.content.Intent intent)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onTaskRemoved(android.content.Intent rootIntent)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void stopSelf()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void stopSelf(int startId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool stopSelfResult(int startId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"This is a now a no-op, usestartForeground(int, Notification) instead.  This method has been turned into a no-op rather than simply being deprecated because analysis of numerous poorly behaving devices has shown that increasingly often the trouble is being caused in part by applications that are abusing it.  Thus, given a choice between introducing problems in existing applications using this API (by allowing them to be killed when they would like to avoid it), vs allowing the performance of the entire system to be decreased, this method was deemed less important."
			)]
		public void setForeground(bool isForeground)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void startForeground(int id, android.app.Notification notification)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void stopForeground(bool removeNotification)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual void dump(java.io.FileDescriptor fd, java.io.PrintWriter
			 writer, string[] args)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void attach(android.content.Context context, android.app.ActivityThread thread
			, string className, android.os.IBinder token, android.app.Application application
			, object activityManager)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal string getClassName()
		{
			throw new System.NotImplementedException();
		}

		private android.app.ActivityThread mThread = null;

		private string mClassName = null;

		private android.os.IBinder mToken = null;

		private android.app.Application mApplication = null;

		private android.app.IActivityManager mActivityManager = null;

		private bool mStartCompatibility = false;
	}
}

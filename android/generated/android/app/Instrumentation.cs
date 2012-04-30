using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	public partial class Instrumentation
	{
		public const string REPORT_KEY_IDENTIFIER = "id";

		public const string REPORT_KEY_STREAMRESULT = "stream";

		internal const string TAG = "Instrumentation";

		private readonly object mSync = new object();

		private android.app.ActivityThread mThread = null;

		private android.os.MessageQueue mMessageQueue = null;

		private android.content.Context mInstrContext;

		private android.content.Context mAppContext;

		private android.content.ComponentName mComponent;

		private java.lang.Thread mRunner;

		private java.util.List<android.app.Instrumentation.ActivityWaiter> mWaitingActivities;

		private java.util.List<android.app.Instrumentation.ActivityMonitor> mActivityMonitors;

		private android.app.IInstrumentationWatcher mWatcher;

		private bool mAutomaticPerformanceSnapshots = false;

		private android.os.PerformanceCollector mPerformanceCollector;

		private android.os.Bundle mPerfMetrics;

		public Instrumentation()
		{
		}

		[Sharpen.Stub]
		public virtual void onCreate(android.os.Bundle arguments)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void start()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onStart()
		{
			throw new System.NotImplementedException();
		}

		/// <summary>
		/// This is called whenever the system captures an unhandled exception that
		/// was thrown by the application.
		/// </summary>
		/// <remarks>
		/// This is called whenever the system captures an unhandled exception that
		/// was thrown by the application.  The default implementation simply
		/// returns false, allowing normal system handling of the exception to take
		/// place.
		/// </remarks>
		/// <param name="obj">
		/// The client object that generated the exception.  May be an
		/// Application, Activity, BroadcastReceiver, Service, or null.
		/// </param>
		/// <param name="e">The exception that was thrown.</param>
		/// <returns>
		/// To allow normal system exception process to occur, return false.
		/// If true is returned, the system will proceed as if the exception
		/// didn't happen.
		/// </returns>
		public virtual bool onException(object obj, System.Exception e)
		{
			return false;
		}

		[Sharpen.Stub]
		public virtual void sendStatus(int resultCode, android.os.Bundle results)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void finish(int resultCode, android.os.Bundle results)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setAutomaticPerformanceSnapshots()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void startPerformanceSnapshot()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void endPerformanceSnapshot()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onDestroy()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.content.Context getContext()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.content.ComponentName getComponentName()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.content.Context getTargetContext()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isProfiling()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void startProfiling()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void stopProfiling()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setInTouchMode(bool inTouch)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void waitForIdle(java.lang.Runnable recipient)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void waitForIdleSync()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void runOnMainSync(java.lang.Runnable runner)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.app.Activity startActivitySync(android.content.Intent intent
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public class ActivityMonitor
		{
			private readonly android.content.IntentFilter mWhich;

			private readonly string mClass;

			private readonly android.app.Instrumentation.ActivityResult mResult;

			private readonly bool mBlock;

			internal int mHits = 0;

			internal android.app.Activity mLastActivity = null;

			[Sharpen.Stub]
			public ActivityMonitor(android.content.IntentFilter which, android.app.Instrumentation
				.ActivityResult result, bool block)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public ActivityMonitor(string cls, android.app.Instrumentation.ActivityResult result
				, bool block)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public android.content.IntentFilter getFilter()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public android.app.Instrumentation.ActivityResult getResult()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public bool isBlocking()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public int getHits()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public android.app.Activity getLastActivity()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public android.app.Activity waitForActivity()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public android.app.Activity waitForActivityWithTimeout(long timeOut)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal bool match(android.content.Context who, android.app.Activity activity, android.content.Intent
				 intent)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public virtual void addMonitor(android.app.Instrumentation.ActivityMonitor monitor
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.app.Instrumentation.ActivityMonitor addMonitor(android.content.IntentFilter
			 filter, android.app.Instrumentation.ActivityResult result, bool block)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.app.Instrumentation.ActivityMonitor addMonitor(string cls, 
			android.app.Instrumentation.ActivityResult result, bool block)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool checkMonitorHit(android.app.Instrumentation.ActivityMonitor monitor
			, int minHits)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.app.Activity waitForMonitor(android.app.Instrumentation.ActivityMonitor
			 monitor)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.app.Activity waitForMonitorWithTimeout(android.app.Instrumentation
			.ActivityMonitor monitor, long timeOut)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void removeMonitor(android.app.Instrumentation.ActivityMonitor monitor
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool invokeMenuActionSync(android.app.Activity targetActivity, int
			 id, int flag)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool invokeContextMenuAction(android.app.Activity targetActivity, 
			int id, int flag)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void sendStringSync(string text)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void sendKeySync(android.view.KeyEvent @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void sendKeyDownUpSync(int key)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void sendCharacterSync(int keyCode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void sendPointerSync(android.view.MotionEvent @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void sendTrackballEventSync(android.view.MotionEvent @event)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>
		/// Perform calling of the application's
		/// <see cref="Application.onCreate()">Application.onCreate()</see>
		/// method.  The default implementation simply calls through to that method.
		/// </summary>
		/// <param name="app">The application being created.</param>
		public virtual void callApplicationOnCreate(android.app.Application app)
		{
			app.onCreate();
		}

		/// <summary>
		/// Perform instantiation of an
		/// <see cref="Activity">Activity</see>
		/// object.  This method is intended for use with
		/// unit tests, such as android.test.ActivityUnitTestCase.  The activity will be useable
		/// locally but will be missing some of the linkages necessary for use within the sytem.
		/// </summary>
		/// <param name="clazz">The Class of the desired Activity</param>
		/// <param name="context">The base context for the activity to use</param>
		/// <param name="token">The token for this activity to communicate with</param>
		/// <param name="application">The application object (if any)</param>
		/// <param name="intent">The intent that started this Activity</param>
		/// <param name="info">ActivityInfo from the manifest</param>
		/// <param name="title">The title, typically retrieved from the ActivityInfo record</param>
		/// <param name="parent">The parent Activity (if any)</param>
		/// <param name="id">The embedded Id (if any)</param>
		/// <param name="lastNonConfigurationInstance">
		/// Arbitrary object that will be
		/// available via
		/// <see cref="Activity.getLastNonConfigurationInstance()">Activity.getLastNonConfigurationInstance()
		/// 	</see>
		/// .
		/// </param>
		/// <returns>Returns the instantiated activity</returns>
		/// <exception cref="java.lang.InstantiationException">java.lang.InstantiationException
		/// 	</exception>
		/// <exception cref="System.MemberAccessException">System.MemberAccessException</exception>
		public virtual android.app.Activity newActivity<_T0>(android.content.Context context
			, android.os.IBinder token, android.app.Application application, android.content.Intent
			 intent, android.content.pm.ActivityInfo info, java.lang.CharSequence title, android.app.Activity
			 parent, string id, object lastNonConfigurationInstance)
		{
			System.Type clazz = typeof(_T0);
			android.app.Activity activity = (android.app.Activity)System.Activator.CreateInstance
				(clazz);
			android.app.ActivityThread aThread = null;
			activity.attach(context, aThread, this, token, application, intent, info, title, 
				parent, id, (android.app.Activity.NonConfigurationInstances)lastNonConfigurationInstance
				, new android.content.res.Configuration());
			return activity;
		}

		/// <summary>
		/// Perform instantiation of the process's
		/// <see cref="Activity">Activity</see>
		/// object.  The
		/// default implementation provides the normal system behavior.
		/// </summary>
		/// <param name="cl">The ClassLoader with which to instantiate the object.</param>
		/// <param name="className">
		/// The name of the class implementing the Activity
		/// object.
		/// </param>
		/// <param name="intent">
		/// The Intent object that specified the activity class being
		/// instantiated.
		/// </param>
		/// <returns>The newly instantiated Activity object.</returns>
		/// <exception cref="java.lang.InstantiationException"></exception>
		/// <exception cref="System.MemberAccessException"></exception>
		/// <exception cref="java.lang.ClassNotFoundException"></exception>
		public virtual android.app.Activity newActivity(java.lang.ClassLoader cl, string 
			className, android.content.Intent intent)
		{
			return (android.app.Activity)System.Activator.CreateInstance(cl.loadClass(className
				));
		}

		[Sharpen.Stub]
		public virtual void callActivityOnDestroy(android.app.Activity activity)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void callActivityOnRestoreInstanceState(android.app.Activity activity
			, android.os.Bundle savedInstanceState)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void callActivityOnNewIntent(android.app.Activity activity, android.content.Intent
			 intent)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>
		/// Perform calling of an activity's
		/// <see cref="Activity.onStart()">Activity.onStart()</see>
		/// method.  The default implementation simply calls through to that method.
		/// </summary>
		/// <param name="activity">The activity being started.</param>
		public virtual void callActivityOnStart(android.app.Activity activity)
		{
			activity.onStart();
		}

		[Sharpen.Stub]
		public virtual void callActivityOnRestart(android.app.Activity activity)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void callActivityOnResume(android.app.Activity activity)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void callActivityOnStop(android.app.Activity activity)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void callActivityOnSaveInstanceState(android.app.Activity activity
			, android.os.Bundle outState)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void callActivityOnPause(android.app.Activity activity)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void callActivityOnUserLeaving(android.app.Activity activity)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void startAllocCounting()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void stopAllocCounting()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void addValue(string key, int value, android.os.Bundle results)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.os.Bundle getAllocCounts()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.os.Bundle getBinderCounts()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public sealed class ActivityResult
		{
			[Sharpen.Stub]
			public ActivityResult(int resultCode, android.content.Intent resultData)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public int getResultCode()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public android.content.Intent getResultData()
			{
				throw new System.NotImplementedException();
			}

			private readonly int mResultCode;

			private readonly android.content.Intent mResultData;
		}

		[Sharpen.Stub]
		public virtual void execStartActivities(android.content.Context who, android.os.IBinder
			 contextThread, android.os.IBinder token, android.app.Activity target, android.content.Intent
			[] intents)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal void init(android.app.ActivityThread thread, android.content.Context instrContext
			, android.content.Context appContext, android.content.ComponentName component, android.app.IInstrumentationWatcher
			 watcher)
		{
			throw new System.NotImplementedException();
		}

		internal static void checkStartActivityResult(int res, object intent)
		{
			if (res >= android.app.IActivityManagerClass.START_SUCCESS)
			{
				return;
			}
			switch (res)
			{
				case android.app.IActivityManagerClass.START_INTENT_NOT_RESOLVED:
				case android.app.IActivityManagerClass.START_CLASS_NOT_FOUND:
				{
					if (intent is android.content.Intent && ((android.content.Intent)intent).getComponent
						() != null)
					{
						throw new android.content.ActivityNotFoundException("Unable to find explicit activity class "
							 + ((android.content.Intent)intent).getComponent().toShortString() + "; have you declared this activity in your AndroidManifest.xml?"
							);
					}
					throw new android.content.ActivityNotFoundException("No Activity found to handle "
						 + intent);
				}

				case android.app.IActivityManagerClass.START_PERMISSION_DENIED:
				{
					throw new System.Security.SecurityException("Not allowed to start activity " + intent
						);
				}

				case android.app.IActivityManagerClass.START_FORWARD_AND_REQUEST_CONFLICT:
				{
					throw new android.util.AndroidRuntimeException("FORWARD_RESULT_FLAG used while also requesting a result"
						);
				}

				case android.app.IActivityManagerClass.START_NOT_ACTIVITY:
				{
					throw new System.ArgumentException("PendingIntent is not an activity");
				}

				default:
				{
					throw new android.util.AndroidRuntimeException("Unknown error code " + res + " when starting "
						 + intent);
				}
			}
		}

		[Sharpen.Stub]
		private void validateNotAppThread()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private sealed class InstrumentationThread : java.lang.Thread
		{
			[Sharpen.Stub]
			public InstrumentationThread(Instrumentation _enclosing, string name) : base(name
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"java.lang.Thread")]
			public override void run()
			{
				throw new System.NotImplementedException();
			}

			private readonly Instrumentation _enclosing;
		}

		[Sharpen.Stub]
		private sealed class EmptyRunnable : java.lang.Runnable
		{
			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public void run()
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		private sealed class SyncRunnable : java.lang.Runnable
		{
			internal readonly java.lang.Runnable mTarget;

			internal bool mComplete;

			[Sharpen.Stub]
			public SyncRunnable(java.lang.Runnable target)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public void run()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public void waitForComplete()
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		private sealed class ActivityWaiter
		{
			public readonly android.content.Intent intent;

			public android.app.Activity activity;

			[Sharpen.Stub]
			public ActivityWaiter(android.content.Intent _intent)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		private sealed class ActivityGoing : android.os.MessageQueue.IdleHandler
		{
			internal readonly android.app.Instrumentation.ActivityWaiter mWaiter;

			[Sharpen.Stub]
			public ActivityGoing(Instrumentation _enclosing, android.app.Instrumentation.ActivityWaiter
				 waiter)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.MessageQueue.IdleHandler")]
			public bool queueIdle()
			{
				throw new System.NotImplementedException();
			}

			private readonly Instrumentation _enclosing;
		}

		[Sharpen.Stub]
		private sealed class Idler : android.os.MessageQueue.IdleHandler
		{
			internal readonly java.lang.Runnable mCallback;

			internal bool mIdle;

			[Sharpen.Stub]
			public Idler(java.lang.Runnable callback)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.MessageQueue.IdleHandler")]
			public bool queueIdle()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public void waitForIdle()
			{
				throw new System.NotImplementedException();
			}
		}
	}
}

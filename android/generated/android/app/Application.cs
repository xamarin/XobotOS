using Sharpen;

namespace android.app
{
	/// <summary>Base class for those who need to maintain global application state.</summary>
	/// <remarks>
	/// Base class for those who need to maintain global application state. You can
	/// provide your own implementation by specifying its name in your
	/// AndroidManifest.xml's &lt;application&gt; tag, which will cause that class
	/// to be instantiated for you when the process for your application/package is
	/// created.
	/// <p class="note">There is normally no need to subclass Application.  In
	/// most situation, static singletons can provide the same functionality in a
	/// more modular way.  If your singleton needs a global context (for example
	/// to register broadcast receivers), the function to retrieve it can be
	/// given a
	/// <see cref="android.content.Context">android.content.Context</see>
	/// which internally uses
	/// <see cref="android.content.Context.getApplicationContext()">Context.getApplicationContext()
	/// 	</see>
	/// when first constructing the singleton.</p>
	/// </remarks>
	[Sharpen.Sharpened]
	public class Application : android.content.ContextWrapper, android.content.ComponentCallbacks2
	{
		private java.util.ArrayList<android.content.ComponentCallbacks> mComponentCallbacks
			 = new java.util.ArrayList<android.content.ComponentCallbacks>();

		private java.util.ArrayList<android.app.Application.ActivityLifecycleCallbacks> mActivityLifecycleCallbacks
			 = new java.util.ArrayList<android.app.Application.ActivityLifecycleCallbacks>();

		/// <hide></hide>
		public android.app.LoadedApk mLoadedApk;

		public interface ActivityLifecycleCallbacks
		{
			void onActivityCreated(android.app.Activity activity, android.os.Bundle savedInstanceState
				);

			void onActivityStarted(android.app.Activity activity);

			void onActivityResumed(android.app.Activity activity);

			void onActivityPaused(android.app.Activity activity);

			void onActivityStopped(android.app.Activity activity);

			void onActivitySaveInstanceState(android.app.Activity activity, android.os.Bundle
				 outState);

			void onActivityDestroyed(android.app.Activity activity);
		}

		public Application() : base(null)
		{
		}

		/// <summary>
		/// Called when the application is starting, before any other application
		/// objects have been created.
		/// </summary>
		/// <remarks>
		/// Called when the application is starting, before any other application
		/// objects have been created.  Implementations should be as quick as
		/// possible (for example using lazy initialization of state) since the time
		/// spent in this function directly impacts the performance of starting the
		/// first activity, service, or receiver in a process.
		/// If you override this method, be sure to call super.onCreate().
		/// </remarks>
		public virtual void onCreate()
		{
		}

		/// <summary>This method is for use in emulated process environments.</summary>
		/// <remarks>
		/// This method is for use in emulated process environments.  It will
		/// never be called on a production Android device, where processes are
		/// removed by simply killing them; no user code (including this callback)
		/// is executed when doing so.
		/// </remarks>
		public virtual void onTerminate()
		{
		}

		[Sharpen.ImplementsInterface(@"android.content.ComponentCallbacks")]
		public virtual void onConfigurationChanged(android.content.res.Configuration newConfig
			)
		{
			object[] callbacks = collectComponentCallbacks();
			if (callbacks != null)
			{
				{
					for (int i = 0; i < callbacks.Length; i++)
					{
						((android.content.ComponentCallbacks)callbacks[i]).onConfigurationChanged(newConfig
							);
					}
				}
			}
		}

		[Sharpen.ImplementsInterface(@"android.content.ComponentCallbacks")]
		public virtual void onLowMemory()
		{
			object[] callbacks = collectComponentCallbacks();
			if (callbacks != null)
			{
				{
					for (int i = 0; i < callbacks.Length; i++)
					{
						((android.content.ComponentCallbacks)callbacks[i]).onLowMemory();
					}
				}
			}
		}

		[Sharpen.ImplementsInterface(@"android.content.ComponentCallbacks2")]
		public virtual void onTrimMemory(int level)
		{
			object[] callbacks = collectComponentCallbacks();
			if (callbacks != null)
			{
				{
					for (int i = 0; i < callbacks.Length; i++)
					{
						object c = callbacks[i];
						if (c is android.content.ComponentCallbacks2)
						{
							((android.content.ComponentCallbacks2)c).onTrimMemory(level);
						}
					}
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void registerComponentCallbacks(android.content.ComponentCallbacks
			 callback)
		{
			lock (mComponentCallbacks)
			{
				mComponentCallbacks.add(callback);
			}
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void unregisterComponentCallbacks(android.content.ComponentCallbacks
			 callback)
		{
			lock (mComponentCallbacks)
			{
				mComponentCallbacks.remove(callback);
			}
		}

		public virtual void registerActivityLifecycleCallbacks(android.app.Application.ActivityLifecycleCallbacks
			 callback)
		{
			lock (mActivityLifecycleCallbacks)
			{
				mActivityLifecycleCallbacks.add(callback);
			}
		}

		public virtual void unregisterActivityLifecycleCallbacks(android.app.Application.
			ActivityLifecycleCallbacks callback)
		{
			lock (mActivityLifecycleCallbacks)
			{
				mActivityLifecycleCallbacks.remove(callback);
			}
		}

		// ------------------ Internal API ------------------
		/// <hide></hide>
		internal void attach(android.content.Context context)
		{
			attachBaseContext(context);
			mLoadedApk = android.app.ContextImpl.getImpl(context).mPackageInfo;
		}

		internal virtual void dispatchActivityCreated(android.app.Activity activity, android.os.Bundle
			 savedInstanceState)
		{
			object[] callbacks = collectActivityLifecycleCallbacks();
			if (callbacks != null)
			{
				{
					for (int i = 0; i < callbacks.Length; i++)
					{
						((android.app.Application.ActivityLifecycleCallbacks)callbacks[i]).onActivityCreated
							(activity, savedInstanceState);
					}
				}
			}
		}

		internal virtual void dispatchActivityStarted(android.app.Activity activity)
		{
			object[] callbacks = collectActivityLifecycleCallbacks();
			if (callbacks != null)
			{
				{
					for (int i = 0; i < callbacks.Length; i++)
					{
						((android.app.Application.ActivityLifecycleCallbacks)callbacks[i]).onActivityStarted
							(activity);
					}
				}
			}
		}

		internal virtual void dispatchActivityResumed(android.app.Activity activity)
		{
			object[] callbacks = collectActivityLifecycleCallbacks();
			if (callbacks != null)
			{
				{
					for (int i = 0; i < callbacks.Length; i++)
					{
						((android.app.Application.ActivityLifecycleCallbacks)callbacks[i]).onActivityResumed
							(activity);
					}
				}
			}
		}

		internal virtual void dispatchActivityPaused(android.app.Activity activity)
		{
			object[] callbacks = collectActivityLifecycleCallbacks();
			if (callbacks != null)
			{
				{
					for (int i = 0; i < callbacks.Length; i++)
					{
						((android.app.Application.ActivityLifecycleCallbacks)callbacks[i]).onActivityPaused
							(activity);
					}
				}
			}
		}

		internal virtual void dispatchActivityStopped(android.app.Activity activity)
		{
			object[] callbacks = collectActivityLifecycleCallbacks();
			if (callbacks != null)
			{
				{
					for (int i = 0; i < callbacks.Length; i++)
					{
						((android.app.Application.ActivityLifecycleCallbacks)callbacks[i]).onActivityStopped
							(activity);
					}
				}
			}
		}

		internal virtual void dispatchActivitySaveInstanceState(android.app.Activity activity
			, android.os.Bundle outState)
		{
			object[] callbacks = collectActivityLifecycleCallbacks();
			if (callbacks != null)
			{
				{
					for (int i = 0; i < callbacks.Length; i++)
					{
						((android.app.Application.ActivityLifecycleCallbacks)callbacks[i]).onActivitySaveInstanceState
							(activity, outState);
					}
				}
			}
		}

		internal virtual void dispatchActivityDestroyed(android.app.Activity activity)
		{
			object[] callbacks = collectActivityLifecycleCallbacks();
			if (callbacks != null)
			{
				{
					for (int i = 0; i < callbacks.Length; i++)
					{
						((android.app.Application.ActivityLifecycleCallbacks)callbacks[i]).onActivityDestroyed
							(activity);
					}
				}
			}
		}

		private object[] collectComponentCallbacks()
		{
			object[] callbacks = null;
			lock (mComponentCallbacks)
			{
				if (mComponentCallbacks.size() > 0)
				{
					callbacks = mComponentCallbacks.toArray();
				}
			}
			return callbacks;
		}

		private object[] collectActivityLifecycleCallbacks()
		{
			object[] callbacks = null;
			lock (mActivityLifecycleCallbacks)
			{
				if (mActivityLifecycleCallbacks.size() > 0)
				{
					callbacks = mActivityLifecycleCallbacks.toArray();
				}
			}
			return callbacks;
		}
	}
}

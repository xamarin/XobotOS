using System;
using XobotOS.Runtime;
using java.lang;
using android.os;
using android.content;

namespace android.app
{
	partial class Instrumentation
	{
		/// <summary>
		/// Perform instantiation of the process's
		/// <see cref="Application">Application</see>
		/// object.  The
		/// default implementation provides the normal system behavior.
		/// </summary>
		/// <param name="cl">The ClassLoader with which to instantiate the object.</param>
		/// <param name="className">
		/// The name of the class implementing the Application
		/// object.
		/// </param>
		/// <param name="context">The context to initialize the application with</param>
		/// <returns>The newly instantiated Application object.</returns>
		/// <exception cref="java.lang.InstantiationException"></exception>
		/// <exception cref="System.MemberAccessException"></exception>
		/// <exception cref="System.TypeLoadException"></exception>
		public virtual Application newApplication (ClassLoader cl, string klass, Context context)
		{
			return newApplication (cl.loadClass (klass), context);
		}

		/// <summary>
		/// Perform instantiation of the process's
		/// <see cref="Application">Application</see>
		/// object.  The
		/// default implementation provides the normal system behavior.
		/// </summary>
		/// <param name="clazz">The class used to create an Application object from.</param>
		/// <param name="context">The context to initialize the application with</param>
		/// <returns>The newly instantiated Application object.</returns>
		/// <exception cref="java.lang.InstantiationException"></exception>
		/// <exception cref="System.MemberAccessException"></exception>
		/// <exception cref="System.TypeLoadException"></exception>
		internal static Application newApplication (Type klass, Context context)
		{
			Application app = (Application)Activator.CreateInstance (klass);
			app.attach (context);
			return app;
		}

		/// <summary>
		/// Perform calling of an activity's
		/// <see cref="Activity.onCreate(android.os.Bundle)">Activity.onCreate(android.os.Bundle)
		/// 	</see>
		/// method.  The default implementation simply calls through to that method.
		/// </summary>
		/// <param name="activity">The activity being created.</param>
		/// <param name="icicle">
		/// The previously frozen state (or null) to pass through to
		/// onCreate().
		/// </param>
		public virtual void callActivityOnCreate (Activity activity, Bundle icicle)
		{
			activity.performCreate (icicle);
		}

		/// <summary>
		/// Perform calling of an activity's
		/// <see cref="Activity.onPostCreate(android.os.Bundle)">Activity.onPostCreate(android.os.Bundle)
		/// 	</see>
		/// method.
		/// The default implementation simply calls through to that method.
		/// </summary>
		/// <param name="activity">The activity being created.</param>
		/// <param name="icicle">
		/// The previously frozen state (or null) to pass through to
		/// onPostCreate().
		/// </param>
		public virtual void callActivityOnPostCreate (Activity activity, Bundle icicle)
		{
			activity.onPostCreate (icicle);
		}

		/// <summary>Execute a startActivity call made by the application.</summary>
		/// <remarks>
		/// Execute a startActivity call made by the application.  The default
		/// implementation takes care of updating any active
		/// <see cref="ActivityMonitor">ActivityMonitor</see>
		/// objects and dispatches this call to the system activity manager; you can
		/// override this to watch for the application to start an activity, and
		/// modify what happens when it does.
		/// <p>This method returns an
		/// <see cref="ActivityResult">ActivityResult</see>
		/// object, which you can
		/// use when intercepting application calls to avoid performing the start
		/// activity action but still return the result the application is
		/// expecting.  To do this, override this method to catch the call to start
		/// activity so that it returns a new ActivityResult containing the results
		/// you would like the application to see, and don't call up to the super
		/// class.  Note that an application is only expecting a result if
		/// <var>requestCode</var> is &gt;= 0.
		/// <p>This method throws
		/// <see cref="android.content.ActivityNotFoundException">android.content.ActivityNotFoundException
		/// 	</see>
		/// if there was no Activity found to run the given Intent.
		/// </remarks>
		/// <param name="who">The Context from which the activity is being started.</param>
		/// <param name="contextThread">
		/// The main thread of the Context from which the activity
		/// is being started.
		/// </param>
		/// <param name="token">
		/// Internal token identifying to the system who is starting
		/// the activity; may be null.
		/// </param>
		/// <param name="target">
		/// Which activity is performing the start (and thus receiving
		/// any result); may be null if this call is not being made
		/// from an activity.
		/// </param>
		/// <param name="intent">The actual Intent to start.</param>
		/// <param name="requestCode">
		/// Identifier for this request's result; less than zero
		/// if the caller is not expecting a result.
		/// </param>
		/// <returns>
		/// To force the return of a particular result, return an
		/// ActivityResult object containing the desired data; otherwise
		/// return null.  The default implementation always returns null.
		/// </returns>
		/// <exception cref="android.content.ActivityNotFoundException">android.content.ActivityNotFoundException
		/// 	</exception>
		/// <seealso cref="Activity.startActivity(android.content.Intent)">Activity.startActivity(android.content.Intent)
		/// 	</seealso>
		/// <seealso cref="Activity.startActivityForResult(android.content.Intent, int)">Activity.startActivityForResult(android.content.Intent, int)
		/// 	</seealso>
		/// <seealso cref="Activity.startActivityFromChild(Activity, android.content.Intent, int)
		/// 	"><hide></hide></seealso>
		public virtual ActivityResult execStartActivity (Context who, IBinder contextThread, IBinder token, Activity target, Intent intent, int requestCode)
		{
			IApplicationThread whoThread = (IApplicationThread)contextThread;
			if (mActivityMonitors != null) {
				lock (mSync) {
					int N = mActivityMonitors.size ();
					{
						for (int i = 0; i < N; i++) {
							ActivityMonitor am = mActivityMonitors.get (i);
							if (am.match (who, null, intent)) {
								am.mHits++;
								if (am.isBlocking ()) {
									return requestCode >= 0 ? am.getResult () : null;
								}
								break;
							}
						}
					}
				}
			}

			try {
				intent.setAllowFds (false);
				int result = XobotActivityManager.StartActivity (
					whoThread, intent, intent.resolveTypeIfNeeded (who.getContentResolver ()), target,
					requestCode);
				checkStartActivityResult (result, intent);
			} catch (RemoteException) {
			}
			return null;
		}

		[Sharpen.Stub]
		public virtual ActivityResult execStartActivity(Context who, IBinder contextThread, IBinder token,
		                                                Fragment target, Intent intent, int requestCode)
		{
			throw new System.NotImplementedException();
		}
	}
}

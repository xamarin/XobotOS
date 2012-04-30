using System;
using XobotOS.Runtime;
using android.content.res;

namespace android.app
{
	partial class ActivityThread
	{
		internal ActivityThread ()
		{
			sThreadLocal.set (this);
			mSystemThread = true;

			mInstrumentation = new Instrumentation ();

			ContextImpl context = new ContextImpl ();
			context.init (getSystemContext ().mPackageInfo, null, this);

			var res = context.getResources ();
			mConfiguration = res.getConfiguration ();
			XobotActivityManager.DeviceConfig.updateConfig (mConfiguration);
			res.updateConfiguration (mConfiguration, res.getDisplayMetrics ());
			applyConfigurationToResourcesLocked (mConfiguration, mResCompatibilityInfo);
			applyCompatConfiguration ();

			Application app = new Application ();
			app.attach (context);
			mAllApplications.add (app);
			mInitialApplication = app;
			app.onCreate ();
		}

		internal static ActivityThread systemMain ()
		{
			return new ActivityThread ();
		}
	}
}


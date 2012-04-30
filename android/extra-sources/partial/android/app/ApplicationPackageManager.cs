using System;
using XobotOS.Runtime;
using android.content.pm;
using android.content.res;

namespace android.app
{
	partial class ApplicationPackageManager
	{
		/// <exception cref="android.content.pm.PackageManager.NameNotFoundException"></exception>
		[Sharpen.OverridesMethod(@"android.content.pm.PackageManager")]
		public override Resources getResourcesForApplication (ApplicationInfo app)
		{
			if (app.packageName.Equals ("system")) {
				return mContext.mMainThread.getSystemContext ().getResources ();
			}
			Resources r = mContext.mMainThread.getTopLevelResources (
				app.publicSourceDir, mContext.mPackageInfo);
			if (r != null) {
				return r;
			}
			throw new NameNotFoundException ("Unable to open " + app.publicSourceDir);
		}
	}
}


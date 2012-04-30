using System;
using XobotOS.Runtime;
using android.content.pm;

namespace android.app
{
	partial class ContextImpl
	{
		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override PackageManager getPackageManager ()
		{
			if (mPackageManager != null)
				return mPackageManager;

			mPackageManager = new XobotPackageManager (this);
			return mPackageManager;
		}

	}
}


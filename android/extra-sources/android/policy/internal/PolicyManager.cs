using System;
using XobotOS.Runtime;
using android.content;
using android.view;

namespace android.policy.@internal
{
	[Sharpen.Sharpened]
	public static class PolicyManager
	{
		public static Window makeNewWindow (Context context)
		{
			return XobotActivityManager.CreateMainWindow (context);
		}

		public static LayoutInflater makeNewLayoutInflater(Context context)
		{
			return new XobotLayoutInflater (context);
		}

		[Sharpen.Stub]
		public static WindowManagerPolicy makeNewWindowManager()
		{
			throw new NotImplementedException ();
		}

		[Sharpen.Stub]
		public static FallbackEventHandler makeNewFallbackEventHandler(Context context)
		{
			throw new NotImplementedException ();
		}
	}
}

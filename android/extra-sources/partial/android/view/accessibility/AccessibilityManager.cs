using System;
using android.content;

namespace android.view.accessibility
{
	partial class AccessibilityManager
	{
		/// <summary>Get an AccessibilityManager instance (create one if necessary).</summary>
		/// <remarks>Get an AccessibilityManager instance (create one if necessary).</remarks>
		/// <hide></hide>
		public static AccessibilityManager getInstance (Context context)
		{
			lock (sInstanceSync) {
				if (sInstance == null) {
					sInstance = new AccessibilityManager (context);
				}
			}
			return sInstance;
		}

		private AccessibilityManager (Context context)
		{
		}

		/// <summary>Returns if the accessibility in the system is enabled.</summary>
		/// <remarks>Returns if the accessibility in the system is enabled.</remarks>
		/// <returns>True if accessibility is enabled, false otherwise.</returns>
		public bool isEnabled()
		{
			return false;
		}
	}
}


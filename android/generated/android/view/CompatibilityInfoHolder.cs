using Sharpen;

namespace android.view
{
	/// <hide></hide>
	[Sharpen.Sharpened]
	public class CompatibilityInfoHolder
	{
		private volatile android.content.res.CompatibilityInfo mCompatInfo = android.content.res.CompatibilityInfo
			.DEFAULT_COMPATIBILITY_INFO;

		public virtual void set(android.content.res.CompatibilityInfo compatInfo)
		{
			if (compatInfo != null && (compatInfo.isScalingRequired() || !compatInfo.supportsScreen
				()))
			{
				mCompatInfo = compatInfo;
			}
			else
			{
				mCompatInfo = android.content.res.CompatibilityInfo.DEFAULT_COMPATIBILITY_INFO;
			}
		}

		public virtual android.content.res.CompatibilityInfo get()
		{
			return mCompatInfo;
		}

		public virtual android.content.res.CompatibilityInfo getIfNeeded()
		{
			android.content.res.CompatibilityInfo ci = mCompatInfo;
			if (ci == null || ci == android.content.res.CompatibilityInfo.DEFAULT_COMPATIBILITY_INFO)
			{
				return null;
			}
			return ci;
		}
	}
}

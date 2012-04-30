using Sharpen;

namespace android.util
{
	[Sharpen.Stub]
	[System.ObsoleteAttribute(@"This class is not useful, it just returns the same value for all constants, and has always done this.  Do not use it."
		)]
	public sealed class Config
	{
		[Sharpen.Stub]
		public Config()
		{
			throw new System.NotImplementedException();
		}

		[System.ObsoleteAttribute(@"Always false.")]
		public const bool DEBUG = false;

		[System.ObsoleteAttribute(@"Always true.")]
		public const bool RELEASE = true;

		[System.ObsoleteAttribute(@"Always false.")]
		public const bool PROFILE = false;

		[System.ObsoleteAttribute(@"Always false.")]
		public const bool LOGV = false;

		[System.ObsoleteAttribute(@"Always true.")]
		public const bool LOGD = true;
	}
}

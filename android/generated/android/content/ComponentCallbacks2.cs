using Sharpen;

namespace android.content
{
	[Sharpen.Stub]
	public interface ComponentCallbacks2 : android.content.ComponentCallbacks
	{
		[Sharpen.Stub]
		void onTrimMemory(int level);
	}

	[Sharpen.Stub]
	public static class ComponentCallbacks2Class
	{
		public const int TRIM_MEMORY_COMPLETE = 80;

		public const int TRIM_MEMORY_MODERATE = 60;

		public const int TRIM_MEMORY_BACKGROUND = 40;

		public const int TRIM_MEMORY_UI_HIDDEN = 20;
	}
}

using Sharpen;

namespace android.policy.@internal
{
	/// <summary><hide></hide></summary>
	[Sharpen.Sharpened]
	public interface IPolicy
	{
		android.view.Window makeNewWindow(android.content.Context context);

		android.view.LayoutInflater makeNewLayoutInflater(android.content.Context context
			);

		android.view.WindowManagerPolicy makeNewWindowManager();

		android.view.FallbackEventHandler makeNewFallbackEventHandler(android.content.Context
			 context);
	}
}

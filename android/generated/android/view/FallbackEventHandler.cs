using Sharpen;

namespace android.view
{
	/// <hide></hide>
	[Sharpen.Sharpened]
	public interface FallbackEventHandler
	{
		void setView(android.view.View v);

		void preDispatchKeyEvent(android.view.KeyEvent @event);

		bool dispatchKeyEvent(android.view.KeyEvent @event);
	}
}

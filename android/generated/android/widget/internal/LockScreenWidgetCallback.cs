using Sharpen;

namespace android.widget.@internal
{
	/// <summary>An interface used by LockScreenWidgets to send messages to lock screen.</summary>
	/// <remarks>An interface used by LockScreenWidgets to send messages to lock screen.</remarks>
	[Sharpen.Sharpened]
	public interface LockScreenWidgetCallback
	{
		// Sends a message to lock screen requesting the given view be shown.  May be ignored, depending
		// on lock screen state. View must be the top-level lock screen widget or it will be ignored.
		void requestShow(android.view.View self);

		// Sends a message to lock screen requesting the view to be hidden.
		void requestHide(android.view.View self);

		// Whether or not this view is currently visible on LockScreen
		bool isVisible(android.view.View self);

		// Sends a message to lock screen that user has interacted with widget. This should be used
		// exclusively in response to user activity, i.e. user hits a button in the view.
		void userActivity(android.view.View self);
	}
}

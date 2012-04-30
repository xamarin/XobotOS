using Sharpen;

namespace android.view.accessibility
{
	[Sharpen.Stub]
	public interface AccessibilityEventSource
	{
		[Sharpen.Stub]
		void sendAccessibilityEvent(int eventType);

		[Sharpen.Stub]
		void sendAccessibilityEventUnchecked(android.view.accessibility.AccessibilityEvent
			 @event);
	}
}

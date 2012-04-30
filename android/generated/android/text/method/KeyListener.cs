using Sharpen;

namespace android.text.method
{
	[Sharpen.Stub]
	public interface KeyListener
	{
		[Sharpen.Stub]
		int getInputType();

		[Sharpen.Stub]
		bool onKeyDown(android.view.View view, android.text.Editable text, int keyCode, android.view.KeyEvent
			 @event);

		[Sharpen.Stub]
		bool onKeyUp(android.view.View view, android.text.Editable text, int keyCode, android.view.KeyEvent
			 @event);

		[Sharpen.Stub]
		bool onKeyOther(android.view.View view, android.text.Editable text, android.view.KeyEvent
			 @event);

		[Sharpen.Stub]
		void clearMetaKeyState(android.view.View view, android.text.Editable content, int
			 states);
	}
}

using Sharpen;

namespace android.view.inputmethod
{
	[Sharpen.Stub]
	public interface InputMethodSession
	{
		[Sharpen.Stub]
		void finishInput();

		[Sharpen.Stub]
		void updateSelection(int oldSelStart, int oldSelEnd, int newSelStart, int newSelEnd
			, int candidatesStart, int candidatesEnd);

		[Sharpen.Stub]
		void viewClicked(bool focusChanged);

		[Sharpen.Stub]
		void updateCursor(android.graphics.Rect newCursor);

		[Sharpen.Stub]
		void displayCompletions(android.view.inputmethod.CompletionInfo[] completions);

		[Sharpen.Stub]
		void updateExtractedText(int token, android.view.inputmethod.ExtractedText text);

		[Sharpen.Stub]
		void dispatchKeyEvent(int seq, android.view.KeyEvent @event, android.view.inputmethod.InputMethodSessionClass
			.EventCallback callback);

		[Sharpen.Stub]
		void dispatchTrackballEvent(int seq, android.view.MotionEvent @event, android.view.inputmethod.InputMethodSessionClass
			.EventCallback callback);

		[Sharpen.Stub]
		void appPrivateCommand(string action, android.os.Bundle data);

		[Sharpen.Stub]
		void toggleSoftInput(int showFlags, int hideFlags);
	}

	[Sharpen.Stub]
	public static class InputMethodSessionClass
	{
		[Sharpen.Stub]
		public interface EventCallback
		{
			[Sharpen.Stub]
			void finishedEvent(int seq, bool handled);
		}
	}
}

using Sharpen;

namespace android.view.inputmethod
{
	[Sharpen.Stub]
	public interface InputConnection
	{
		[Sharpen.Stub]
		java.lang.CharSequence getTextBeforeCursor(int n, int flags);

		[Sharpen.Stub]
		java.lang.CharSequence getTextAfterCursor(int n, int flags);

		[Sharpen.Stub]
		java.lang.CharSequence getSelectedText(int flags);

		[Sharpen.Stub]
		int getCursorCapsMode(int reqModes);

		[Sharpen.Stub]
		android.view.inputmethod.ExtractedText getExtractedText(android.view.inputmethod.ExtractedTextRequest
			 request, int flags);

		[Sharpen.Stub]
		bool deleteSurroundingText(int leftLength, int rightLength);

		[Sharpen.Stub]
		bool setComposingText(java.lang.CharSequence text, int newCursorPosition);

		[Sharpen.Stub]
		bool setComposingRegion(int start, int end);

		[Sharpen.Stub]
		bool finishComposingText();

		[Sharpen.Stub]
		bool commitText(java.lang.CharSequence text, int newCursorPosition);

		[Sharpen.Stub]
		bool commitCompletion(android.view.inputmethod.CompletionInfo text);

		[Sharpen.Stub]
		bool commitCorrection(android.view.inputmethod.CorrectionInfo correctionInfo);

		[Sharpen.Stub]
		bool setSelection(int start, int end);

		[Sharpen.Stub]
		bool performEditorAction(int editorAction);

		[Sharpen.Stub]
		bool performContextMenuAction(int id);

		[Sharpen.Stub]
		bool beginBatchEdit();

		[Sharpen.Stub]
		bool endBatchEdit();

		[Sharpen.Stub]
		bool sendKeyEvent(android.view.KeyEvent @event);

		[Sharpen.Stub]
		bool clearMetaKeyStates(int states);

		[Sharpen.Stub]
		bool reportFullscreenMode(bool enabled);

		[Sharpen.Stub]
		bool performPrivateCommand(string action, android.os.Bundle data);
	}

	[Sharpen.Stub]
	public static class InputConnectionClass
	{
		public const int GET_TEXT_WITH_STYLES = unchecked((int)(0x0001));

		public const int GET_EXTRACTED_TEXT_MONITOR = unchecked((int)(0x0001));
	}
}

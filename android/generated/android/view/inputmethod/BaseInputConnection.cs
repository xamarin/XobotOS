using Sharpen;

namespace android.view.inputmethod
{
	[Sharpen.Stub]
	internal class ComposingText : android.text.NoCopySpan
	{
	}

	[Sharpen.Stub]
	public class BaseInputConnection : android.view.inputmethod.InputConnection
	{
		internal const bool DEBUG = false;

		internal const string TAG = "BaseInputConnection";

		internal static readonly object COMPOSING = new android.view.inputmethod.ComposingText
			();

		protected internal readonly android.view.inputmethod.InputMethodManager mIMM;

		internal readonly android.view.View mTargetView;

		internal readonly bool mDummyMode;

		private object[] mDefaultComposingSpans;

		internal android.text.Editable mEditable;

		internal android.view.KeyCharacterMap mKeyCharacterMap;

		[Sharpen.Stub]
		internal BaseInputConnection(android.view.inputmethod.InputMethodManager mgr, bool
			 fullEditor)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public BaseInputConnection(android.view.View targetView, bool fullEditor)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void removeComposingSpans(android.text.Spannable text)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void setComposingSpans(android.text.Spannable text)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void setComposingSpans(android.text.Spannable text, int start, int 
			end)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int getComposingSpanStart(android.text.Spannable text)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int getComposingSpanEnd(android.text.Spannable text)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.text.Editable getEditable()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.inputmethod.InputConnection")]
		public virtual bool beginBatchEdit()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.inputmethod.InputConnection")]
		public virtual bool endBatchEdit()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.inputmethod.InputConnection")]
		public virtual bool clearMetaKeyStates(int states)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.inputmethod.InputConnection")]
		public virtual bool commitCompletion(android.view.inputmethod.CompletionInfo text
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.inputmethod.InputConnection")]
		public virtual bool commitCorrection(android.view.inputmethod.CorrectionInfo correctionInfo
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.inputmethod.InputConnection")]
		public virtual bool commitText(java.lang.CharSequence text, int newCursorPosition
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.inputmethod.InputConnection")]
		public virtual bool deleteSurroundingText(int leftLength, int rightLength)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.inputmethod.InputConnection")]
		public virtual bool finishComposingText()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.inputmethod.InputConnection")]
		public virtual int getCursorCapsMode(int reqModes)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.inputmethod.InputConnection")]
		public virtual android.view.inputmethod.ExtractedText getExtractedText(android.view.inputmethod.ExtractedTextRequest
			 request, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.inputmethod.InputConnection")]
		public virtual java.lang.CharSequence getTextBeforeCursor(int length, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.inputmethod.InputConnection")]
		public virtual java.lang.CharSequence getSelectedText(int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.inputmethod.InputConnection")]
		public virtual java.lang.CharSequence getTextAfterCursor(int length, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.inputmethod.InputConnection")]
		public virtual bool performEditorAction(int actionCode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.inputmethod.InputConnection")]
		public virtual bool performContextMenuAction(int id)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.inputmethod.InputConnection")]
		public virtual bool performPrivateCommand(string action, android.os.Bundle data)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.inputmethod.InputConnection")]
		public virtual bool setComposingText(java.lang.CharSequence text, int newCursorPosition
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.inputmethod.InputConnection")]
		public virtual bool setComposingRegion(int start, int end)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.inputmethod.InputConnection")]
		public virtual bool setSelection(int start, int end)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.inputmethod.InputConnection")]
		public virtual bool sendKeyEvent(android.view.KeyEvent @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.inputmethod.InputConnection")]
		public virtual bool reportFullscreenMode(bool enabled)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void sendCurrentText()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void ensureDefaultComposingSpans()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void replaceText(java.lang.CharSequence text, int newCursorPosition, bool
			 composing)
		{
			throw new System.NotImplementedException();
		}
	}
}

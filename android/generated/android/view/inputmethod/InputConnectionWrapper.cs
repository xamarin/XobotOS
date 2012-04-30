using Sharpen;

namespace android.view.inputmethod
{
	[Sharpen.Stub]
	public class InputConnectionWrapper : android.view.inputmethod.InputConnection
	{
		private android.view.inputmethod.InputConnection mTarget;

		internal readonly bool mMutable;

		[Sharpen.Stub]
		public InputConnectionWrapper(android.view.inputmethod.InputConnection target, bool
			 mutable)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setTarget(android.view.inputmethod.InputConnection target)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.inputmethod.InputConnection")]
		public virtual java.lang.CharSequence getTextBeforeCursor(int n, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.inputmethod.InputConnection")]
		public virtual java.lang.CharSequence getTextAfterCursor(int n, int flags)
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
		public virtual bool deleteSurroundingText(int leftLength, int rightLength)
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
		public virtual bool finishComposingText()
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
		public virtual bool setSelection(int start, int end)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.inputmethod.InputConnection")]
		public virtual bool performEditorAction(int editorAction)
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
		public virtual bool sendKeyEvent(android.view.KeyEvent @event)
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
		public virtual bool reportFullscreenMode(bool enabled)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.inputmethod.InputConnection")]
		public virtual bool performPrivateCommand(string action, android.os.Bundle data)
		{
			throw new System.NotImplementedException();
		}
	}
}

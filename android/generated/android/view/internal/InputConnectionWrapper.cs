using Sharpen;

namespace android.view.@internal
{
	[Sharpen.Stub]
	public class InputConnectionWrapper : android.view.inputmethod.InputConnection
	{
		internal const int MAX_WAIT_TIME_MILLIS = 2000;

		private readonly android.view.@internal.IInputContext mIInputContext;

		[Sharpen.Stub]
		internal class InputContextCallback : android.view.@internal.IInputContextCallbackClass
			.Stub
		{
			internal const string TAG = "InputConnectionWrapper.ICC";

			public int mSeq;

			public bool mHaveValue;

			public java.lang.CharSequence mTextBeforeCursor;

			public java.lang.CharSequence mTextAfterCursor;

			public java.lang.CharSequence mSelectedText;

			public android.view.inputmethod.ExtractedText mExtractedText;

			public int mCursorCapsMode;

			private static android.view.@internal.InputConnectionWrapper.InputContextCallback
				 sInstance = new android.view.@internal.InputConnectionWrapper.InputContextCallback
				();

			private static int sSequenceNumber = 1;

			[Sharpen.Stub]
			internal static android.view.@internal.InputConnectionWrapper.InputContextCallback
				 getInstance()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			private void dispose()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputContextCallback")]
			public override void setTextBeforeCursor(java.lang.CharSequence textBeforeCursor, 
				int seq)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputContextCallback")]
			public override void setTextAfterCursor(java.lang.CharSequence textAfterCursor, int
				 seq)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputContextCallback")]
			public override void setSelectedText(java.lang.CharSequence selectedText, int seq
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputContextCallback")]
			public override void setCursorCapsMode(int capsMode, int seq)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputContextCallback")]
			public override void setExtractedText(android.view.inputmethod.ExtractedText extractedText
				, int seq)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal virtual void waitForResultLocked()
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public InputConnectionWrapper(android.view.@internal.IInputContext inputContext)
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
		public virtual bool setComposingRegion(int start, int end)
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
		public virtual bool finishComposingText()
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
		public virtual bool deleteSurroundingText(int leftLength, int rightLength)
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

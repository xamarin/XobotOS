using Sharpen;

namespace android.view.@internal
{
	[Sharpen.Stub]
	public class IInputConnectionWrapper : android.view.@internal.IInputContextClass.
		Stub
	{
		internal const string TAG = "IInputConnectionWrapper";

		internal const int DO_GET_TEXT_AFTER_CURSOR = 10;

		internal const int DO_GET_TEXT_BEFORE_CURSOR = 20;

		internal const int DO_GET_SELECTED_TEXT = 25;

		internal const int DO_GET_CURSOR_CAPS_MODE = 30;

		internal const int DO_GET_EXTRACTED_TEXT = 40;

		internal const int DO_COMMIT_TEXT = 50;

		internal const int DO_COMMIT_COMPLETION = 55;

		internal const int DO_COMMIT_CORRECTION = 56;

		internal const int DO_SET_SELECTION = 57;

		internal const int DO_PERFORM_EDITOR_ACTION = 58;

		internal const int DO_PERFORM_CONTEXT_MENU_ACTION = 59;

		internal const int DO_SET_COMPOSING_TEXT = 60;

		internal const int DO_SET_COMPOSING_REGION = 63;

		internal const int DO_FINISH_COMPOSING_TEXT = 65;

		internal const int DO_SEND_KEY_EVENT = 70;

		internal const int DO_DELETE_SURROUNDING_TEXT = 80;

		internal const int DO_BEGIN_BATCH_EDIT = 90;

		internal const int DO_END_BATCH_EDIT = 95;

		internal const int DO_REPORT_FULLSCREEN_MODE = 100;

		internal const int DO_PERFORM_PRIVATE_COMMAND = 120;

		internal const int DO_CLEAR_META_KEY_STATES = 130;

		private java.lang.@ref.WeakReference<android.view.inputmethod.InputConnection> mInputConnection;

		private android.os.Looper mMainLooper;

		private android.os.Handler mH;

		[Sharpen.Stub]
		internal class SomeArgs
		{
			internal object arg1;

			internal object arg2;

			internal android.view.@internal.IInputContextCallback callback;

			internal int seq;
		}

		[Sharpen.Stub]
		internal class MyHandler : android.os.Handler
		{
			[Sharpen.Stub]
			internal MyHandler(IInputConnectionWrapper _enclosing, android.os.Looper looper) : 
				base(looper)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.os.Handler")]
			public override void handleMessage(android.os.Message msg)
			{
				throw new System.NotImplementedException();
			}

			private readonly IInputConnectionWrapper _enclosing;
		}

		[Sharpen.Stub]
		public IInputConnectionWrapper(android.os.Looper mainLooper, android.view.inputmethod.InputConnection
			 conn)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isActive()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputContext")]
		public override void getTextAfterCursor(int length, int flags, int seq, android.view.@internal.IInputContextCallback
			 callback)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputContext")]
		public override void getTextBeforeCursor(int length, int flags, int seq, android.view.@internal.IInputContextCallback
			 callback)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputContext")]
		public override void getSelectedText(int flags, int seq, android.view.@internal.IInputContextCallback
			 callback)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputContext")]
		public override void getCursorCapsMode(int reqModes, int seq, android.view.@internal.IInputContextCallback
			 callback)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputContext")]
		public override void getExtractedText(android.view.inputmethod.ExtractedTextRequest
			 request, int flags, int seq, android.view.@internal.IInputContextCallback callback
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputContext")]
		public override void commitText(java.lang.CharSequence text, int newCursorPosition
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputContext")]
		public override void commitCompletion(android.view.inputmethod.CompletionInfo text
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputContext")]
		public override void commitCorrection(android.view.inputmethod.CorrectionInfo info
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputContext")]
		public override void setSelection(int start, int end)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputContext")]
		public override void performEditorAction(int id)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputContext")]
		public override void performContextMenuAction(int id)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputContext")]
		public override void setComposingRegion(int start, int end)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputContext")]
		public override void setComposingText(java.lang.CharSequence text, int newCursorPosition
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputContext")]
		public override void finishComposingText()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputContext")]
		public override void sendKeyEvent(android.view.KeyEvent @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputContext")]
		public override void clearMetaKeyStates(int states)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputContext")]
		public override void deleteSurroundingText(int leftLength, int rightLength)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputContext")]
		public override void beginBatchEdit()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputContext")]
		public override void endBatchEdit()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputContext")]
		public override void reportFullscreenMode(bool enabled)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputContext")]
		public override void performPrivateCommand(string action, android.os.Bundle data)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void dispatchMessage(android.os.Message msg)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void executeMessage(android.os.Message msg)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual android.os.Message obtainMessage(int what)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual android.os.Message obtainMessageII(int what, int arg1, int arg2)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual android.os.Message obtainMessageO(int what, object arg1)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual android.os.Message obtainMessageISC(int what, int arg1, int seq, 
			android.view.@internal.IInputContextCallback callback)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual android.os.Message obtainMessageIISC(int what, int arg1, int arg2
			, int seq, android.view.@internal.IInputContextCallback callback)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual android.os.Message obtainMessageIOSC(int what, int arg1, object 
			arg2, int seq, android.view.@internal.IInputContextCallback callback)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual android.os.Message obtainMessageIO(int what, int arg1, object arg2
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual android.os.Message obtainMessageOO(int what, object arg1, object
			 arg2)
		{
			throw new System.NotImplementedException();
		}
	}
}

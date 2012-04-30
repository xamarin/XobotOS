using Sharpen;

namespace android.inputmethodservice
{
	[Sharpen.Stub]
	internal class IInputMethodSessionWrapper : android.view.@internal.IInputMethodSessionClass
		.Stub, android.os.@internal.HandlerCaller.Callback
	{
		internal const string TAG = "InputMethodWrapper";

		internal const bool DEBUG = false;

		internal const int DO_FINISH_INPUT = 60;

		internal const int DO_DISPLAY_COMPLETIONS = 65;

		internal const int DO_UPDATE_EXTRACTED_TEXT = 67;

		internal const int DO_DISPATCH_KEY_EVENT = 70;

		internal const int DO_DISPATCH_TRACKBALL_EVENT = 80;

		internal const int DO_UPDATE_SELECTION = 90;

		internal const int DO_UPDATE_CURSOR = 95;

		internal const int DO_APP_PRIVATE_COMMAND = 100;

		internal const int DO_TOGGLE_SOFT_INPUT = 105;

		internal const int DO_FINISH_SESSION = 110;

		internal const int DO_VIEW_CLICKED = 115;

		internal android.os.@internal.HandlerCaller mCaller;

		internal android.view.inputmethod.InputMethodSession mInputMethodSession;

		[Sharpen.Stub]
		internal class InputMethodEventCallbackWrapper : android.view.inputmethod.InputMethodSessionClass
			.EventCallback
		{
			internal readonly android.view.@internal.IInputMethodCallback mCb;

			[Sharpen.Stub]
			internal InputMethodEventCallbackWrapper(android.view.@internal.IInputMethodCallback
				 cb)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.inputmethod.InputMethodSession.EventCallback"
				)]
			public virtual void finishedEvent(int seq, bool handled)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public IInputMethodSessionWrapper(android.content.Context context, android.view.inputmethod.InputMethodSession
			 inputMethodSession)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.view.inputmethod.InputMethodSession getInternalInputMethodSession
			()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"com.android.internal.os.HandlerCaller.Callback")]
		public virtual void executeMessage(android.os.Message msg)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodSession")]
		public override void finishInput()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodSession")]
		public override void displayCompletions(android.view.inputmethod.CompletionInfo[]
			 completions)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodSession")]
		public override void updateExtractedText(int token, android.view.inputmethod.ExtractedText
			 text)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodSession")]
		public override void dispatchKeyEvent(int seq, android.view.KeyEvent @event, android.view.@internal.IInputMethodCallback
			 callback)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodSession")]
		public override void dispatchTrackballEvent(int seq, android.view.MotionEvent @event
			, android.view.@internal.IInputMethodCallback callback)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodSession")]
		public override void updateSelection(int oldSelStart, int oldSelEnd, int newSelStart
			, int newSelEnd, int candidatesStart, int candidatesEnd)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodSession")]
		public override void viewClicked(bool focusChanged)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodSession")]
		public override void updateCursor(android.graphics.Rect newCursor)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodSession")]
		public override void appPrivateCommand(string action, android.os.Bundle data)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodSession")]
		public override void toggleSoftInput(int showFlags, int hideFlags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodSession")]
		public override void finishSession()
		{
			throw new System.NotImplementedException();
		}
	}
}

using Sharpen;

namespace android.inputmethodservice
{
	[Sharpen.Stub]
	public abstract class AbstractInputMethodService : android.app.Service, android.view.KeyEvent
		.Callback
	{
		private android.view.inputmethod.InputMethod mInputMethod;

		internal readonly android.view.KeyEvent.DispatcherState mDispatcherState = new android.view.KeyEvent
			.DispatcherState();

		[Sharpen.Stub]
		public abstract class AbstractInputMethodImpl : android.view.inputmethod.InputMethod
		{
			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.inputmethod.InputMethod")]
			public virtual void createSession(android.view.inputmethod.InputMethodClass.SessionCallback
				 callback)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.inputmethod.InputMethod")]
			public virtual void setSessionEnabled(android.view.inputmethod.InputMethodSession
				 session, bool enabled)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.inputmethod.InputMethod")]
			public virtual void revokeSession(android.view.inputmethod.InputMethodSession session
				)
			{
				throw new System.NotImplementedException();
			}

			public abstract void attachToken(android.os.IBinder arg1);

			public abstract void bindInput(android.view.inputmethod.InputBinding arg1);

			public abstract void changeInputMethodSubtype(android.view.inputmethod.InputMethodSubtype
				 arg1);

			public abstract void hideSoftInput(int arg1, android.os.ResultReceiver arg2);

			public abstract void restartInput(android.view.inputmethod.InputConnection arg1, 
				android.view.inputmethod.EditorInfo arg2);

			public abstract void showSoftInput(int arg1, android.os.ResultReceiver arg2);

			public abstract void startInput(android.view.inputmethod.InputConnection arg1, android.view.inputmethod.EditorInfo
				 arg2);

			public abstract void unbindInput();

			internal AbstractInputMethodImpl(AbstractInputMethodService _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly AbstractInputMethodService _enclosing;
		}

		[Sharpen.Stub]
		public abstract class AbstractInputMethodSessionImpl : android.view.inputmethod.InputMethodSession
		{
			internal bool mEnabled;

			internal bool mRevoked;

			[Sharpen.Stub]
			public virtual bool isEnabled()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual bool isRevoked()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void setEnabled(bool enabled)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void revokeSelf()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.inputmethod.InputMethodSession")]
			public virtual void dispatchKeyEvent(int seq, android.view.KeyEvent @event, android.view.inputmethod.InputMethodSessionClass
				.EventCallback callback)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.inputmethod.InputMethodSession")]
			public virtual void dispatchTrackballEvent(int seq, android.view.MotionEvent @event
				, android.view.inputmethod.InputMethodSessionClass.EventCallback callback)
			{
				throw new System.NotImplementedException();
			}

			public abstract void appPrivateCommand(string arg1, android.os.Bundle arg2);

			public abstract void displayCompletions(android.view.inputmethod.CompletionInfo[]
				 arg1);

			public abstract void finishInput();

			public abstract void toggleSoftInput(int arg1, int arg2);

			public abstract void updateCursor(android.graphics.Rect arg1);

			public abstract void updateExtractedText(int arg1, android.view.inputmethod.ExtractedText
				 arg2);

			public abstract void updateSelection(int arg1, int arg2, int arg3, int arg4, int 
				arg5, int arg6);

			public abstract void viewClicked(bool arg1);

			public AbstractInputMethodSessionImpl(AbstractInputMethodService _enclosing)
			{
				this._enclosing = _enclosing;
				mEnabled = true;
			}

			private readonly AbstractInputMethodService _enclosing;
		}

		[Sharpen.Stub]
		public virtual android.view.KeyEvent.DispatcherState getKeyDispatcherState()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public abstract android.inputmethodservice.AbstractInputMethodService.AbstractInputMethodImpl
			 onCreateInputMethodInterface();

		[Sharpen.Stub]
		public abstract android.inputmethodservice.AbstractInputMethodService.AbstractInputMethodSessionImpl
			 onCreateInputMethodSessionInterface();

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Service")]
		protected internal override void dump(java.io.FileDescriptor fd, java.io.PrintWriter
			 fout, string[] args)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Service")]
		public sealed override android.os.IBinder onBind(android.content.Intent intent)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool onTrackballEvent(android.view.MotionEvent @event)
		{
			throw new System.NotImplementedException();
		}

		public abstract bool onKeyDown(int arg1, android.view.KeyEvent arg2);

		public abstract bool onKeyLongPress(int arg1, android.view.KeyEvent arg2);

		public abstract bool onKeyMultiple(int arg1, int arg2, android.view.KeyEvent arg3
			);

		public abstract bool onKeyUp(int arg1, android.view.KeyEvent arg2);
	}
}

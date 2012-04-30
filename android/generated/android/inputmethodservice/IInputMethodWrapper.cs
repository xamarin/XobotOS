using Sharpen;

namespace android.inputmethodservice
{
	[Sharpen.Stub]
	internal class IInputMethodWrapper : android.view.@internal.IInputMethodClass.Stub
		, android.os.@internal.HandlerCaller.Callback
	{
		internal const string TAG = "InputMethodWrapper";

		internal const bool DEBUG = false;

		internal const int DO_DUMP = 1;

		internal const int DO_ATTACH_TOKEN = 10;

		internal const int DO_SET_INPUT_CONTEXT = 20;

		internal const int DO_UNSET_INPUT_CONTEXT = 30;

		internal const int DO_START_INPUT = 32;

		internal const int DO_RESTART_INPUT = 34;

		internal const int DO_CREATE_SESSION = 40;

		internal const int DO_SET_SESSION_ENABLED = 45;

		internal const int DO_REVOKE_SESSION = 50;

		internal const int DO_SHOW_SOFT_INPUT = 60;

		internal const int DO_HIDE_SOFT_INPUT = 70;

		internal const int DO_CHANGE_INPUTMETHOD_SUBTYPE = 80;

		internal readonly java.lang.@ref.WeakReference<android.inputmethodservice.AbstractInputMethodService
			> mTarget;

		internal readonly android.os.@internal.HandlerCaller mCaller;

		internal readonly java.lang.@ref.WeakReference<android.view.inputmethod.InputMethod
			> mInputMethod;

		internal readonly int mTargetSdkVersion;

		[Sharpen.Stub]
		internal class Notifier
		{
			internal bool notified;
		}

		[Sharpen.Stub]
		internal class InputMethodSessionCallbackWrapper : android.view.inputmethod.InputMethodClass
			.SessionCallback
		{
			internal readonly android.content.Context mContext;

			internal readonly android.view.@internal.IInputMethodCallback mCb;

			[Sharpen.Stub]
			internal InputMethodSessionCallbackWrapper(android.content.Context context, android.view.@internal.IInputMethodCallback
				 cb)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.inputmethod.InputMethod.SessionCallback"
				)]
			public virtual void sessionCreated(android.view.inputmethod.InputMethodSession session
				)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public IInputMethodWrapper(android.inputmethodservice.AbstractInputMethodService 
			context, android.view.inputmethod.InputMethod inputMethod)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.view.inputmethod.InputMethod getInternalInputMethod()
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
		[Sharpen.OverridesMethod(@"android.os.Binder")]
		protected internal override void dump(java.io.FileDescriptor fd, java.io.PrintWriter
			 fout, string[] args)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethod")]
		public override void attachToken(android.os.IBinder token)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethod")]
		public override void bindInput(android.view.inputmethod.InputBinding binding)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethod")]
		public override void unbindInput()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethod")]
		public override void startInput(android.view.@internal.IInputContext inputContext
			, android.view.inputmethod.EditorInfo attribute)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethod")]
		public override void restartInput(android.view.@internal.IInputContext inputContext
			, android.view.inputmethod.EditorInfo attribute)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethod")]
		public override void createSession(android.view.@internal.IInputMethodCallback callback
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethod")]
		public override void setSessionEnabled(android.view.@internal.IInputMethodSession
			 session, bool enabled)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethod")]
		public override void revokeSession(android.view.@internal.IInputMethodSession session
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethod")]
		public override void showSoftInput(int flags, android.os.ResultReceiver resultReceiver
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethod")]
		public override void hideSoftInput(int flags, android.os.ResultReceiver resultReceiver
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethod")]
		public override void changeInputMethodSubtype(android.view.inputmethod.InputMethodSubtype
			 subtype)
		{
			throw new System.NotImplementedException();
		}
	}
}

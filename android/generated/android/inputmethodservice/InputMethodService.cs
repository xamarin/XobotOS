using Sharpen;

namespace android.inputmethodservice
{
	[Sharpen.Stub]
	public class InputMethodService : android.inputmethodservice.AbstractInputMethodService
	{
		internal const string TAG = "InputMethodService";

		internal const bool DEBUG = false;

		public const int BACK_DISPOSITION_DEFAULT = 0;

		public const int BACK_DISPOSITION_WILL_NOT_DISMISS = 1;

		public const int BACK_DISPOSITION_WILL_DISMISS = 2;

		public const int IME_ACTIVE = unchecked((int)(0x1));

		public const int IME_VISIBLE = unchecked((int)(0x2));

		internal android.view.inputmethod.InputMethodManager mImm;

		internal int mTheme = 0;

		internal android.view.LayoutInflater mInflater;

		internal android.content.res.TypedArray mThemeAttrs;

		internal android.view.View mRootView;

		internal android.inputmethodservice.SoftInputWindow mWindow;

		internal bool mInitialized;

		internal bool mWindowCreated;

		internal bool mWindowAdded;

		internal bool mWindowVisible;

		internal bool mWindowWasVisible;

		internal bool mInShowWindow;

		internal android.view.ViewGroup mFullscreenArea;

		internal android.widget.FrameLayout mExtractFrame;

		internal android.widget.FrameLayout mCandidatesFrame;

		internal android.widget.FrameLayout mInputFrame;

		internal android.os.IBinder mToken;

		internal android.view.inputmethod.InputBinding mInputBinding;

		internal android.view.inputmethod.InputConnection mInputConnection;

		internal bool mInputStarted;

		internal bool mInputViewStarted;

		internal bool mCandidatesViewStarted;

		internal android.view.inputmethod.InputConnection mStartedInputConnection;

		internal android.view.inputmethod.EditorInfo mInputEditorInfo;

		internal int mShowInputFlags;

		internal bool mShowInputRequested;

		internal bool mLastShowInputRequested;

		internal int mCandidatesVisibility;

		internal android.view.inputmethod.CompletionInfo[] mCurCompletions;

		internal bool mShowInputForced;

		internal bool mFullscreenApplied;

		internal bool mIsFullscreen;

		internal android.view.View mExtractView;

		internal bool mExtractViewHidden;

		internal android.inputmethodservice.ExtractEditText mExtractEditText;

		internal android.view.ViewGroup mExtractAccessories;

		internal android.widget.Button mExtractAction;

		internal android.view.inputmethod.ExtractedText mExtractedText;

		internal int mExtractedToken;

		internal android.view.View mInputView;

		internal bool mIsInputViewShown;

		internal int mStatusIcon;

		internal int mBackDisposition;

		internal readonly android.inputmethodservice.InputMethodService.Insets mTmpInsets
			 = new android.inputmethodservice.InputMethodService.Insets();

		internal readonly int[] mTmpLocation = new int[2];

		private sealed class _OnComputeInternalInsetsListener_307 : android.view.ViewTreeObserver
			.OnComputeInternalInsetsListener
		{
			public _OnComputeInternalInsetsListener_307()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.ViewTreeObserver.OnComputeInternalInsetsListener"
				)]
			public void onComputeInternalInsets(android.view.ViewTreeObserver.InternalInsetsInfo
				 info)
			{
				throw new System.NotImplementedException();
			}
		}

		internal readonly android.view.ViewTreeObserver.OnComputeInternalInsetsListener mInsetsComputer
			 = new _OnComputeInternalInsetsListener_307();

		private sealed class _OnClickListener_327 : android.view.View.OnClickListener
		{
			public _OnClickListener_327()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.View.OnClickListener")]
			public void onClick(android.view.View v)
			{
				throw new System.NotImplementedException();
			}
		}

		internal readonly android.view.View.OnClickListener mActionClickListener = new _OnClickListener_327
			();

		[Sharpen.Stub]
		public class InputMethodImpl : android.inputmethodservice.AbstractInputMethodService
			.AbstractInputMethodImpl
		{
			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.inputmethod.InputMethod")]
			public override void attachToken(android.os.IBinder token)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.inputmethod.InputMethod")]
			public override void bindInput(android.view.inputmethod.InputBinding binding)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.inputmethod.InputMethod")]
			public override void unbindInput()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.inputmethod.InputMethod")]
			public override void startInput(android.view.inputmethod.InputConnection ic, android.view.inputmethod.EditorInfo
				 attribute)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.inputmethod.InputMethod")]
			public override void restartInput(android.view.inputmethod.InputConnection ic, android.view.inputmethod.EditorInfo
				 attribute)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.inputmethod.InputMethod")]
			public override void hideSoftInput(int flags, android.os.ResultReceiver resultReceiver
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.inputmethod.InputMethod")]
			public override void showSoftInput(int flags, android.os.ResultReceiver resultReceiver
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.inputmethod.InputMethod")]
			public override void changeInputMethodSubtype(android.view.inputmethod.InputMethodSubtype
				 subtype)
			{
				throw new System.NotImplementedException();
			}

			internal InputMethodImpl(InputMethodService _enclosing) : base(_enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly InputMethodService _enclosing;
		}

		[Sharpen.Stub]
		public class InputMethodSessionImpl : android.inputmethodservice.AbstractInputMethodService
			.AbstractInputMethodSessionImpl
		{
			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.inputmethod.InputMethodSession")]
			public override void finishInput()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.inputmethod.InputMethodSession")]
			public override void displayCompletions(android.view.inputmethod.CompletionInfo[]
				 completions)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.inputmethod.InputMethodSession")]
			public override void updateExtractedText(int token, android.view.inputmethod.ExtractedText
				 text)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.inputmethod.InputMethodSession")]
			public override void updateSelection(int oldSelStart, int oldSelEnd, int newSelStart
				, int newSelEnd, int candidatesStart, int candidatesEnd)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.inputmethod.InputMethodSession")]
			public override void viewClicked(bool focusChanged)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.inputmethod.InputMethodSession")]
			public override void updateCursor(android.graphics.Rect newCursor)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.inputmethod.InputMethodSession")]
			public override void appPrivateCommand(string action, android.os.Bundle data)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.inputmethod.InputMethodSession")]
			public override void toggleSoftInput(int showFlags, int hideFlags)
			{
				throw new System.NotImplementedException();
			}

			internal InputMethodSessionImpl(InputMethodService _enclosing) : base(_enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly InputMethodService _enclosing;
		}

		[Sharpen.Stub]
		public sealed class Insets
		{
			public int contentTopInsets;

			public int visibleTopInsets;

			public readonly android.graphics.Region touchableRegion = new android.graphics.Region
				();

			public const int TOUCHABLE_INSETS_FRAME = android.view.ViewTreeObserver.InternalInsetsInfo
				.TOUCHABLE_INSETS_FRAME;

			public const int TOUCHABLE_INSETS_CONTENT = android.view.ViewTreeObserver.InternalInsetsInfo
				.TOUCHABLE_INSETS_CONTENT;

			public const int TOUCHABLE_INSETS_VISIBLE = android.view.ViewTreeObserver.InternalInsetsInfo
				.TOUCHABLE_INSETS_VISIBLE;

			public const int TOUCHABLE_INSETS_REGION = android.view.ViewTreeObserver.InternalInsetsInfo
				.TOUCHABLE_INSETS_REGION;

			public int touchableInsets;
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void setTheme(int theme)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Service")]
		public override void onCreate()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onInitializeInterface()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void initialize()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void initViews()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Service")]
		public override void onDestroy()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Service")]
		public override void onConfigurationChanged(android.content.res.Configuration newConfig
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.inputmethodservice.AbstractInputMethodService"
			)]
		public override android.inputmethodservice.AbstractInputMethodService.AbstractInputMethodImpl
			 onCreateInputMethodInterface()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.inputmethodservice.AbstractInputMethodService"
			)]
		public override android.inputmethodservice.AbstractInputMethodService.AbstractInputMethodSessionImpl
			 onCreateInputMethodSessionInterface()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.view.LayoutInflater getLayoutInflater()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.app.Dialog getWindow()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setBackDisposition(int disposition)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getBackDisposition()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getMaxWidth()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.view.inputmethod.InputBinding getCurrentInputBinding()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.view.inputmethod.InputConnection getCurrentInputConnection
			()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool getCurrentInputStarted()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.view.inputmethod.EditorInfo getCurrentInputEditorInfo()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void updateFullscreenMode()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onConfigureWindow(android.view.Window win, bool isFullscreen, 
			bool isCandidatesOnly)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isFullscreenMode()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool onEvaluateFullscreenMode()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setExtractViewShown(bool shown)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isExtractViewShown()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void updateExtractFrameVisibility()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onComputeInsets(android.inputmethodservice.InputMethodService
			.Insets outInsets)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void updateInputViewShown()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isShowInputRequested()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isInputViewShown()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool onEvaluateInputViewShown()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setCandidatesViewShown(bool shown)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void updateCandidatesVisibility(bool shown)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getCandidatesHiddenVisibility()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void showStatusIcon(int iconResId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void hideStatusIcon()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void switchInputMethod(string id)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setExtractView(android.view.View view)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setCandidatesView(android.view.View view)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setInputView(android.view.View view)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.view.View onCreateExtractTextView()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.view.View onCreateCandidatesView()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.view.View onCreateInputView()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onStartInputView(android.view.inputmethod.EditorInfo info, bool
			 restarting)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onFinishInputView(bool finishingInput)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onStartCandidatesView(android.view.inputmethod.EditorInfo info
			, bool restarting)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onFinishCandidatesView(bool finishingInput)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool onShowInputRequested(int flags, bool configChange)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void showWindow(bool showInput)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void showWindowInner(bool showInput)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void finishViews()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void hideWindow()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onWindowShown()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onWindowHidden()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onBindInput()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onUnbindInput()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onStartInput(android.view.inputmethod.EditorInfo attribute, bool
			 restarting)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void doFinishInput()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void doStartInput(android.view.inputmethod.InputConnection ic, android.view.inputmethod.EditorInfo
			 attribute, bool restarting)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onFinishInput()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onDisplayCompletions(android.view.inputmethod.CompletionInfo[]
			 completions)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onUpdateExtractedText(int token, android.view.inputmethod.ExtractedText
			 text)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onUpdateSelection(int oldSelStart, int oldSelEnd, int newSelStart
			, int newSelEnd, int candidatesStart, int candidatesEnd)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onViewClicked(bool focusChanged)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onUpdateCursor(android.graphics.Rect newCursor)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void requestHideSelf(int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void requestShowSelf(int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private bool handleBack(bool doIt)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.KeyEvent.Callback")]
		public override bool onKeyDown(int keyCode, android.view.KeyEvent @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.KeyEvent.Callback")]
		public override bool onKeyLongPress(int keyCode, android.view.KeyEvent @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.KeyEvent.Callback")]
		public override bool onKeyMultiple(int keyCode, int count, android.view.KeyEvent 
			@event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.KeyEvent.Callback")]
		public override bool onKeyUp(int keyCode, android.view.KeyEvent @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.inputmethodservice.AbstractInputMethodService"
			)]
		public override bool onTrackballEvent(android.view.MotionEvent @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onAppPrivateCommand(string action, android.os.Bundle data)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void onToggleSoftInput(int showFlags, int hideFlags)
		{
			throw new System.NotImplementedException();
		}

		internal const int MOVEMENT_DOWN = -1;

		internal const int MOVEMENT_UP = -2;

		[Sharpen.Stub]
		internal virtual void reportExtractedMovement(int keyCode, int count)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual bool doMovementKey(int keyCode, android.view.KeyEvent @event, int
			 count)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void sendDownUpKeyEvents(int keyEventCode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool sendDefaultEditorAction(bool fromEnterKey)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void sendKeyChar(char charCode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onExtractedSelectionChanged(int start, int end)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onExtractedTextClicked()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onExtractedCursorMovement(int dx, int dy)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool onExtractTextContextMenuItem(int id)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual java.lang.CharSequence getTextForImeAction(int imeOptions)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onUpdateExtractingVisibility(android.view.inputmethod.EditorInfo
			 ei)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onUpdateExtractingViews(android.view.inputmethod.EditorInfo ei
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onExtractingInputChanged(android.view.inputmethod.EditorInfo 
			ei)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void startExtractingText(bool inputChanged)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual void onCurrentInputMethodSubtypeChanged(android.view.inputmethod.InputMethodSubtype
			 newSubtype)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Service")]
		protected internal override void dump(java.io.FileDescriptor fd, java.io.PrintWriter
			 fout, string[] args)
		{
			throw new System.NotImplementedException();
		}
	}
}

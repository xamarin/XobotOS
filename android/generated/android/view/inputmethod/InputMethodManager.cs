using Sharpen;

namespace android.view.inputmethod
{
	/// <summary>
	/// Central system API to the overall input method framework (IMF) architecture,
	/// which arbitrates interaction between applications and the current input method.
	/// </summary>
	/// <remarks>
	/// Central system API to the overall input method framework (IMF) architecture,
	/// which arbitrates interaction between applications and the current input method.
	/// You can retrieve an instance of this interface with
	/// <see cref="android.content.Context.getSystemService(string)">Context.getSystemService()
	/// 	</see>
	/// .
	/// <p>Topics covered here:
	/// <ol>
	/// <li><a href="#ArchitectureOverview">Architecture Overview</a>
	/// </ol>
	/// <a name="ArchitectureOverview"></a>
	/// <h3>Architecture Overview</h3>
	/// <p>There are three primary parties involved in the input method
	/// framework (IMF) architecture:</p>
	/// <ul>
	/// <li> The <strong>input method manager</strong> as expressed by this class
	/// is the central point of the system that manages interaction between all
	/// other parts.  It is expressed as the client-side API here which exists
	/// in each application context and communicates with a global system service
	/// that manages the interaction across all processes.
	/// <li> An <strong>input method (IME)</strong> implements a particular
	/// interaction model allowing the user to generate text.  The system binds
	/// to the current input method that is use, causing it to be created and run,
	/// and tells it when to hide and show its UI.  Only one IME is running at a time.
	/// <li> Multiple <strong>client applications</strong> arbitrate with the input
	/// method manager for input focus and control over the state of the IME.  Only
	/// one such client is ever active (working with the IME) at a time.
	/// </ul>
	/// <a name="Applications"></a>
	/// <h3>Applications</h3>
	/// <p>In most cases, applications that are using the standard
	/// <see cref="android.widget.TextView">android.widget.TextView</see>
	/// or its subclasses will have little they need
	/// to do to work well with soft input methods.  The main things you need to
	/// be aware of are:</p>
	/// <ul>
	/// <li> Properly set the
	/// <see cref="android.R.attr.inputType">android.R.attr.inputType</see>
	/// in your editable
	/// text views, so that the input method will have enough context to help the
	/// user in entering text into them.
	/// <li> Deal well with losing screen space when the input method is
	/// displayed.  Ideally an application should handle its window being resized
	/// smaller, but it can rely on the system performing panning of the window
	/// if needed.  You should set the
	/// <see cref="android.R.attr.windowSoftInputMode">android.R.attr.windowSoftInputMode
	/// 	</see>
	/// attribute on your activity or the corresponding values on windows you
	/// create to help the system determine whether to pan or resize (it will
	/// try to determine this automatically but may get it wrong).
	/// <li> You can also control the preferred soft input state (open, closed, etc)
	/// for your window using the same
	/// <see cref="android.R.attr.windowSoftInputMode">android.R.attr.windowSoftInputMode
	/// 	</see>
	/// attribute.
	/// </ul>
	/// <p>More finer-grained control is available through the APIs here to directly
	/// interact with the IMF and its IME -- either showing or hiding the input
	/// area, letting the user pick an input method, etc.</p>
	/// <p>For the rare people amongst us writing their own text editors, you
	/// will need to implement
	/// <see cref="android.view.View.onCreateInputConnection(EditorInfo)">android.view.View.onCreateInputConnection(EditorInfo)
	/// 	</see>
	/// to return a new instance of your own
	/// <see cref="InputConnection">InputConnection</see>
	/// interface
	/// allowing the IME to interact with your editor.</p>
	/// <a name="InputMethods"></a>
	/// <h3>Input Methods</h3>
	/// <p>An input method (IME) is implemented
	/// as a
	/// <see cref="android.app.Service">android.app.Service</see>
	/// , typically deriving from
	/// <see cref="android.inputmethodservice.InputMethodService">android.inputmethodservice.InputMethodService
	/// 	</see>
	/// .  It must provide
	/// the core
	/// <see cref="InputMethod">InputMethod</see>
	/// interface, though this is normally handled by
	/// <see cref="android.inputmethodservice.InputMethodService">android.inputmethodservice.InputMethodService
	/// 	</see>
	/// and implementors will
	/// only need to deal with the higher-level API there.</p>
	/// See the
	/// <see cref="android.inputmethodservice.InputMethodService">android.inputmethodservice.InputMethodService
	/// 	</see>
	/// class for
	/// more information on implementing IMEs.
	/// <a name="Security"></a>
	/// <h3>Security</h3>
	/// <p>There are a lot of security issues associated with input methods,
	/// since they essentially have freedom to completely drive the UI and monitor
	/// everything the user enters.  The Android input method framework also allows
	/// arbitrary third party IMEs, so care must be taken to restrict their
	/// selection and interactions.</p>
	/// <p>Here are some key points about the security architecture behind the
	/// IMF:</p>
	/// <ul>
	/// <li> <p>Only the system is allowed to directly access an IME's
	/// <see cref="InputMethod">InputMethod</see>
	/// interface, via the
	/// <see cref="android.Manifest.permission.BIND_INPUT_METHOD">android.Manifest.permission.BIND_INPUT_METHOD
	/// 	</see>
	/// permission.  This is
	/// enforced in the system by not binding to an input method service that does
	/// not require this permission, so the system can guarantee no other untrusted
	/// clients are accessing the current input method outside of its control.</p>
	/// <li> <p>There may be many client processes of the IMF, but only one may
	/// be active at a time.  The inactive clients can not interact with key
	/// parts of the IMF through the mechanisms described below.</p>
	/// <li> <p>Clients of an input method are only given access to its
	/// <see cref="InputMethodSession">InputMethodSession</see>
	/// interface.  One instance of this interface is
	/// created for each client, and only calls from the session associated with
	/// the active client will be processed by the current IME.  This is enforced
	/// by
	/// <see cref="android.inputmethodservice.AbstractInputMethodService">android.inputmethodservice.AbstractInputMethodService
	/// 	</see>
	/// for normal
	/// IMEs, but must be explicitly handled by an IME that is customizing the
	/// raw
	/// <see cref="InputMethodSession">InputMethodSession</see>
	/// implementation.</p>
	/// <li> <p>Only the active client's
	/// <see cref="InputConnection">InputConnection</see>
	/// will accept
	/// operations.  The IMF tells each client process whether it is active, and
	/// the framework enforces that in inactive processes calls on to the current
	/// InputConnection will be ignored.  This ensures that the current IME can
	/// only deliver events and text edits to the UI that the user sees as
	/// being in focus.</p>
	/// <li> <p>An IME can never interact with an
	/// <see cref="InputConnection">InputConnection</see>
	/// while
	/// the screen is off.  This is enforced by making all clients inactive while
	/// the screen is off, and prevents bad IMEs from driving the UI when the user
	/// can not be aware of its behavior.</p>
	/// <li> <p>A client application can ask that the system let the user pick a
	/// new IME, but can not programmatically switch to one itself.  This avoids
	/// malicious applications from switching the user to their own IME, which
	/// remains running when the user navigates away to another application.  An
	/// IME, on the other hand, <em>is</em> allowed to programmatically switch
	/// the system to another IME, since it already has full control of user
	/// input.</p>
	/// <li> <p>The user must explicitly enable a new IME in settings before
	/// they can switch to it, to confirm with the system that they know about it
	/// and want to make it available for use.</p>
	/// </ul>
	/// </remarks>
	[Sharpen.Sharpened]
	public sealed class InputMethodManager
	{
		internal const bool DEBUG = false;

		internal const string TAG = "InputMethodManager";

		internal static readonly object mInstanceSync = new object();

		internal static android.view.inputmethod.InputMethodManager mInstance;

		internal readonly android.view.@internal.IInputMethodManager mService;

		internal readonly android.os.Looper mMainLooper;

		internal readonly android.view.inputmethod.InputMethodManager.H mH;

		internal readonly android.view.@internal.IInputContext mIInputContext;

		/// <summary>True if this input method client is active, initially false.</summary>
		/// <remarks>True if this input method client is active, initially false.</remarks>
		internal bool mActive = false;

		/// <summary>
		/// Set whenever this client becomes inactive, to know we need to reset
		/// state with the IME then next time we receive focus.
		/// </summary>
		/// <remarks>
		/// Set whenever this client becomes inactive, to know we need to reset
		/// state with the IME then next time we receive focus.
		/// </remarks>
		internal bool mHasBeenInactive = true;

		/// <summary>As reported by IME through InputConnection.</summary>
		/// <remarks>As reported by IME through InputConnection.</remarks>
		internal bool mFullscreenMode;

		/// <summary>
		/// This is the root view of the overall window that currently has input
		/// method focus.
		/// </summary>
		/// <remarks>
		/// This is the root view of the overall window that currently has input
		/// method focus.
		/// </remarks>
		internal android.view.View mCurRootView;

		/// <summary>
		/// This is the view that should currently be served by an input method,
		/// regardless of the state of setting that up.
		/// </summary>
		/// <remarks>
		/// This is the view that should currently be served by an input method,
		/// regardless of the state of setting that up.
		/// </remarks>
		internal android.view.View mServedView;

		/// <summary>
		/// This is then next view that will be served by the input method, when
		/// we get around to updating things.
		/// </summary>
		/// <remarks>
		/// This is then next view that will be served by the input method, when
		/// we get around to updating things.
		/// </remarks>
		internal android.view.View mNextServedView;

		/// <summary>
		/// True if we should restart input in the next served view, even if the
		/// view hasn't actually changed from the current serve view.
		/// </summary>
		/// <remarks>
		/// True if we should restart input in the next served view, even if the
		/// view hasn't actually changed from the current serve view.
		/// </remarks>
		internal bool mNextServedNeedsStart;

		/// <summary>
		/// This is set when we are in the process of connecting, to determine
		/// when we have actually finished.
		/// </summary>
		/// <remarks>
		/// This is set when we are in the process of connecting, to determine
		/// when we have actually finished.
		/// </remarks>
		internal bool mServedConnecting;

		/// <summary>
		/// This is non-null when we have connected the served view; it holds
		/// the attributes that were last retrieved from the served view and given
		/// to the input connection.
		/// </summary>
		/// <remarks>
		/// This is non-null when we have connected the served view; it holds
		/// the attributes that were last retrieved from the served view and given
		/// to the input connection.
		/// </remarks>
		internal android.view.inputmethod.EditorInfo mCurrentTextBoxAttribute;

		/// <summary>The InputConnection that was last retrieved from the served view.</summary>
		/// <remarks>The InputConnection that was last retrieved from the served view.</remarks>
		internal android.view.inputmethod.InputConnection mServedInputConnection;

		/// <summary>The completions that were last provided by the served view.</summary>
		/// <remarks>The completions that were last provided by the served view.</remarks>
		internal android.view.inputmethod.CompletionInfo[] mCompletions;

		internal android.graphics.Rect mTmpCursorRect = new android.graphics.Rect();

		internal android.graphics.Rect mCursorRect = new android.graphics.Rect();

		internal int mCursorSelStart;

		internal int mCursorSelEnd;

		internal int mCursorCandStart;

		internal int mCursorCandEnd;

		/// <summary>Sequence number of this binding, as returned by the server.</summary>
		/// <remarks>Sequence number of this binding, as returned by the server.</remarks>
		internal int mBindSequence = -1;

		/// <summary>ID of the method we are bound to.</summary>
		/// <remarks>ID of the method we are bound to.</remarks>
		internal string mCurId;

		/// <summary>The actual instance of the method to make calls on it.</summary>
		/// <remarks>The actual instance of the method to make calls on it.</remarks>
		internal android.view.@internal.IInputMethodSession mCurMethod;

		internal const int MSG_DUMP = 1;

		internal const int MSG_BIND = 2;

		internal const int MSG_UNBIND = 3;

		internal const int MSG_SET_ACTIVE = 4;

		[Sharpen.Stub]
		internal class H : android.os.Handler
		{
			[Sharpen.Stub]
			internal H(InputMethodManager _enclosing, android.os.Looper looper) : base(looper
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.os.Handler")]
			public override void handleMessage(android.os.Message msg)
			{
				throw new System.NotImplementedException();
			}

			private readonly InputMethodManager _enclosing;
		}

		[Sharpen.Stub]
		internal class ControlledInputConnectionWrapper : android.view.@internal.IInputConnectionWrapper
		{
			[Sharpen.Stub]
			public ControlledInputConnectionWrapper(InputMethodManager _enclosing, android.os.Looper
				 mainLooper, android.view.inputmethod.InputConnection conn) : base(mainLooper, conn
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"com.android.internal.view.IInputConnectionWrapper")]
			public override bool isActive()
			{
				throw new System.NotImplementedException();
			}

			private readonly InputMethodManager _enclosing;
		}

		private sealed class _Stub_398 : android.view.@internal.IInputMethodClientClass.Stub
		{
			public _Stub_398()
			{
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.os.Binder")]
			protected internal override void dump(java.io.FileDescriptor fd, java.io.PrintWriter
				 fout, string[] args)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodClient")]
			public override void setUsingInputMethod(bool state)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodClient")]
			public override void onBindMethod(android.view.@internal.InputBindResult res)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodClient")]
			public override void onUnbindMethod(int sequence)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodClient")]
			public override void setActive(bool active)
			{
				throw new System.NotImplementedException();
			}
		}

		internal readonly android.view.@internal.IInputMethodClientClass.Stub mClient;

		internal readonly android.view.inputmethod.InputConnection mDummyInputConnection;

		internal InputMethodManager(android.view.@internal.IInputMethodManager service, android.os.Looper
			 looper)
		{
			mDummyInputConnection = new android.view.inputmethod.BaseInputConnection(this, false
				);
			// For scheduling work on the main thread.  This also serves as our
			// global lock.
			// Our generic input connection if the current target does not have its own.
			// -----------------------------------------------------------
			// Cursor position on the screen.
			// -----------------------------------------------------------
			// -----------------------------------------------------------
			// XXX the server has already unbound!
			// If we were actively using the last input method, then
			// we would like to re-connect to the next input method.
			// Some other client has starting using the IME, so note
			// that this happened and make sure our own editor's
			// state is reset.
			// Note that finishComposingText() is allowed to run
			// even when we are not active.
			// No need to check for dump permission, since we only give this
			// interface to the system.
			mService = service;
			mMainLooper = looper;
			mH = new android.view.inputmethod.InputMethodManager.H(this, looper);
			mIInputContext = new android.view.inputmethod.InputMethodManager.ControlledInputConnectionWrapper
				(this, looper, mDummyInputConnection);
			if (mInstance == null)
			{
				mInstance = this;
			}
		}

		/// <summary>
		/// Retrieve the global InputMethodManager instance, creating it if it
		/// doesn't already exist.
		/// </summary>
		/// <remarks>
		/// Retrieve the global InputMethodManager instance, creating it if it
		/// doesn't already exist.
		/// </remarks>
		/// <hide></hide>
		public static android.view.inputmethod.InputMethodManager getInstance(android.content.Context
			 context)
		{
			return getInstance(context.getMainLooper());
		}

		/// <summary>
		/// Internally, the input method manager can't be context-dependent, so
		/// we have this here for the places that need it.
		/// </summary>
		/// <remarks>
		/// Internally, the input method manager can't be context-dependent, so
		/// we have this here for the places that need it.
		/// </remarks>
		/// <hide></hide>
		public static android.view.inputmethod.InputMethodManager getInstance(android.os.Looper
			 mainLooper)
		{
			lock (mInstanceSync)
			{
				if (mInstance != null)
				{
					return mInstance;
				}
				android.os.IBinder b = android.os.ServiceManager.getService(android.content.Context
					.INPUT_METHOD_SERVICE);
				android.view.@internal.IInputMethodManager service = android.view.@internal.IInputMethodManagerClass
					.Stub.asInterface(b);
				mInstance = new android.view.inputmethod.InputMethodManager(service, mainLooper);
			}
			return mInstance;
		}

		/// <summary>
		/// Private optimization: retrieve the global InputMethodManager instance,
		/// if it exists.
		/// </summary>
		/// <remarks>
		/// Private optimization: retrieve the global InputMethodManager instance,
		/// if it exists.
		/// </remarks>
		/// <hide></hide>
		public static android.view.inputmethod.InputMethodManager peekInstance()
		{
			return mInstance;
		}

		/// <hide></hide>
		public android.view.@internal.IInputMethodClient getClient()
		{
			return mClient;
		}

		/// <hide></hide>
		public android.view.@internal.IInputContext getInputContext()
		{
			return mIInputContext;
		}

		public java.util.List<android.view.inputmethod.InputMethodInfo> getInputMethodList
			()
		{
			try
			{
				return mService.getInputMethodList();
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException(e);
			}
		}

		public java.util.List<android.view.inputmethod.InputMethodInfo> getEnabledInputMethodList
			()
		{
			try
			{
				return mService.getEnabledInputMethodList();
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException(e);
			}
		}

		/// <summary>Returns a list of enabled input method subtypes for the specified input method info.
		/// 	</summary>
		/// <remarks>Returns a list of enabled input method subtypes for the specified input method info.
		/// 	</remarks>
		/// <param name="imi">An input method info whose subtypes list will be returned.</param>
		/// <param name="allowsImplicitlySelectedSubtypes">
		/// A boolean flag to allow to return the implicitly
		/// selected subtypes. If an input method info doesn't have enabled subtypes, the framework
		/// will implicitly enable subtypes according to the current system language.
		/// </param>
		public java.util.List<android.view.inputmethod.InputMethodSubtype> getEnabledInputMethodSubtypeList
			(android.view.inputmethod.InputMethodInfo imi, bool allowsImplicitlySelectedSubtypes
			)
		{
			try
			{
				return mService.getEnabledInputMethodSubtypeList(imi, allowsImplicitlySelectedSubtypes
					);
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException(e);
			}
		}

		public void showStatusIcon(android.os.IBinder imeToken, string packageName, int iconId
			)
		{
			try
			{
				mService.updateStatusIcon(imeToken, packageName, iconId);
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException(e);
			}
		}

		public void hideStatusIcon(android.os.IBinder imeToken)
		{
			try
			{
				mService.updateStatusIcon(imeToken, null, 0);
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException(e);
			}
		}

		/// <hide></hide>
		public void setImeWindowStatus(android.os.IBinder imeToken, int vis, int backDisposition
			)
		{
			try
			{
				mService.setImeWindowStatus(imeToken, vis, backDisposition);
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException(e);
			}
		}

		/// <hide></hide>
		public void setFullscreenMode(bool fullScreen)
		{
			mFullscreenMode = fullScreen;
		}

		/// <hide></hide>
		public void registerSuggestionSpansForNotification(android.text.style.SuggestionSpan
			[] spans)
		{
			try
			{
				mService.registerSuggestionSpansForNotification(spans);
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException(e);
			}
		}

		/// <hide></hide>
		public void notifySuggestionPicked(android.text.style.SuggestionSpan span, string
			 originalString, int index)
		{
			try
			{
				mService.notifySuggestionPicked(span, originalString, index);
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException(e);
			}
		}

		/// <summary>
		/// Allows you to discover whether the attached input method is running
		/// in fullscreen mode.
		/// </summary>
		/// <remarks>
		/// Allows you to discover whether the attached input method is running
		/// in fullscreen mode.  Return true if it is fullscreen, entirely covering
		/// your UI, else returns false.
		/// </remarks>
		public bool isFullscreenMode()
		{
			return mFullscreenMode;
		}

		/// <summary>
		/// Return true if the given view is the currently active view for the
		/// input method.
		/// </summary>
		/// <remarks>
		/// Return true if the given view is the currently active view for the
		/// input method.
		/// </remarks>
		public bool isActive(android.view.View view)
		{
			checkFocus();
			lock (mH)
			{
				return (mServedView == view || (mServedView != null && mServedView.checkInputConnectionProxy
					(view))) && mCurrentTextBoxAttribute != null;
			}
		}

		/// <summary>Return true if any view is currently active in the input method.</summary>
		/// <remarks>Return true if any view is currently active in the input method.</remarks>
		public bool isActive()
		{
			checkFocus();
			lock (mH)
			{
				return mServedView != null && mCurrentTextBoxAttribute != null;
			}
		}

		/// <summary>Return true if the currently served view is accepting full text edits.</summary>
		/// <remarks>
		/// Return true if the currently served view is accepting full text edits.
		/// If false, it has no input connection, so can only handle raw key events.
		/// </remarks>
		public bool isAcceptingText()
		{
			checkFocus();
			return mServedInputConnection != null;
		}

		/// <summary>Reset all of the state associated with being bound to an input method.</summary>
		/// <remarks>Reset all of the state associated with being bound to an input method.</remarks>
		internal void clearBindingLocked()
		{
			clearConnectionLocked();
			mBindSequence = -1;
			mCurId = null;
			mCurMethod = null;
		}

		/// <summary>
		/// Reset all of the state associated with a served view being connected
		/// to an input method
		/// </summary>
		internal void clearConnectionLocked()
		{
			mCurrentTextBoxAttribute = null;
			mServedInputConnection = null;
		}

		/// <summary>Disconnect any existing input connection, clearing the served view.</summary>
		/// <remarks>Disconnect any existing input connection, clearing the served view.</remarks>
		internal void finishInputLocked()
		{
			mNextServedView = null;
			if (mServedView != null)
			{
				if (mCurrentTextBoxAttribute != null)
				{
					try
					{
						mService.finishInput(mClient);
					}
					catch (android.os.RemoteException)
					{
					}
				}
				if (mServedInputConnection != null)
				{
					// We need to tell the previously served view that it is no
					// longer the input target, so it can reset its state.  Schedule
					// this call on its window's Handler so it will be on the correct
					// thread and outside of our lock.
					android.os.Handler vh = mServedView.getHandler();
					if (vh != null)
					{
						// This will result in a call to reportFinishInputConnection()
						// below.
						vh.sendMessage(vh.obtainMessage(android.view.ViewRootImpl.FINISH_INPUT_CONNECTION
							, mServedInputConnection));
					}
				}
				mServedView = null;
				mCompletions = null;
				mServedConnecting = false;
				clearConnectionLocked();
			}
		}

		/// <summary>Called from the FINISH_INPUT_CONNECTION message above.</summary>
		/// <remarks>Called from the FINISH_INPUT_CONNECTION message above.</remarks>
		/// <hide></hide>
		public void reportFinishInputConnection(android.view.inputmethod.InputConnection 
			ic)
		{
			if (mServedInputConnection != ic)
			{
				ic.finishComposingText();
			}
		}

		public void displayCompletions(android.view.View view, android.view.inputmethod.CompletionInfo
			[] completions)
		{
			checkFocus();
			lock (mH)
			{
				if (mServedView != view && (mServedView == null || !mServedView.checkInputConnectionProxy
					(view)))
				{
					return;
				}
				mCompletions = completions;
				if (mCurMethod != null)
				{
					try
					{
						mCurMethod.displayCompletions(mCompletions);
					}
					catch (android.os.RemoteException)
					{
					}
				}
			}
		}

		public void updateExtractedText(android.view.View view, int token, android.view.inputmethod.ExtractedText
			 text)
		{
			checkFocus();
			lock (mH)
			{
				if (mServedView != view && (mServedView == null || !mServedView.checkInputConnectionProxy
					(view)))
				{
					return;
				}
				if (mCurMethod != null)
				{
					try
					{
						mCurMethod.updateExtractedText(token, text);
					}
					catch (android.os.RemoteException)
					{
					}
				}
			}
		}

		/// <summary>
		/// Flag for
		/// <see cref="showSoftInput(android.view.View, int)">showSoftInput(android.view.View, int)
		/// 	</see>
		/// to indicate that this is an implicit
		/// request to show the input window, not as the result of a direct request
		/// by the user.  The window may not be shown in this case.
		/// </summary>
		public const int SHOW_IMPLICIT = unchecked((int)(0x0001));

		/// <summary>
		/// Flag for
		/// <see cref="showSoftInput(android.view.View, int)">showSoftInput(android.view.View, int)
		/// 	</see>
		/// to indicate that the user has forced
		/// the input method open (such as by long-pressing menu) so it should
		/// not be closed until they explicitly do so.
		/// </summary>
		public const int SHOW_FORCED = unchecked((int)(0x0002));

		/// <summary>
		/// Synonym for
		/// <see cref="showSoftInput(android.view.View, int, android.os.ResultReceiver)">showSoftInput(android.view.View, int, android.os.ResultReceiver)
		/// 	</see>
		/// without
		/// a result receiver: explicitly request that the current input method's
		/// soft input area be shown to the user, if needed.
		/// </summary>
		/// <param name="view">
		/// The currently focused view, which would like to receive
		/// soft keyboard input.
		/// </param>
		/// <param name="flags">
		/// Provides additional operating flags.  Currently may be
		/// 0 or have the
		/// <see cref="SHOW_IMPLICIT">SHOW_IMPLICIT</see>
		/// bit set.
		/// </param>
		public bool showSoftInput(android.view.View view, int flags)
		{
			return showSoftInput(view, flags, null);
		}

		/// <summary>
		/// Flag for the
		/// <see cref="android.os.ResultReceiver">android.os.ResultReceiver</see>
		/// result code from
		/// <see cref="showSoftInput(android.view.View, int, android.os.ResultReceiver)">showSoftInput(android.view.View, int, android.os.ResultReceiver)
		/// 	</see>
		/// and
		/// <see cref="hideSoftInputFromWindow(android.os.IBinder, int, android.os.ResultReceiver)
		/// 	">hideSoftInputFromWindow(android.os.IBinder, int, android.os.ResultReceiver)</see>
		/// : the
		/// state of the soft input window was unchanged and remains shown.
		/// </summary>
		public const int RESULT_UNCHANGED_SHOWN = 0;

		/// <summary>
		/// Flag for the
		/// <see cref="android.os.ResultReceiver">android.os.ResultReceiver</see>
		/// result code from
		/// <see cref="showSoftInput(android.view.View, int, android.os.ResultReceiver)">showSoftInput(android.view.View, int, android.os.ResultReceiver)
		/// 	</see>
		/// and
		/// <see cref="hideSoftInputFromWindow(android.os.IBinder, int, android.os.ResultReceiver)
		/// 	">hideSoftInputFromWindow(android.os.IBinder, int, android.os.ResultReceiver)</see>
		/// : the
		/// state of the soft input window was unchanged and remains hidden.
		/// </summary>
		public const int RESULT_UNCHANGED_HIDDEN = 1;

		/// <summary>
		/// Flag for the
		/// <see cref="android.os.ResultReceiver">android.os.ResultReceiver</see>
		/// result code from
		/// <see cref="showSoftInput(android.view.View, int, android.os.ResultReceiver)">showSoftInput(android.view.View, int, android.os.ResultReceiver)
		/// 	</see>
		/// and
		/// <see cref="hideSoftInputFromWindow(android.os.IBinder, int, android.os.ResultReceiver)
		/// 	">hideSoftInputFromWindow(android.os.IBinder, int, android.os.ResultReceiver)</see>
		/// : the
		/// state of the soft input window changed from hidden to shown.
		/// </summary>
		public const int RESULT_SHOWN = 2;

		/// <summary>
		/// Flag for the
		/// <see cref="android.os.ResultReceiver">android.os.ResultReceiver</see>
		/// result code from
		/// <see cref="showSoftInput(android.view.View, int, android.os.ResultReceiver)">showSoftInput(android.view.View, int, android.os.ResultReceiver)
		/// 	</see>
		/// and
		/// <see cref="hideSoftInputFromWindow(android.os.IBinder, int, android.os.ResultReceiver)
		/// 	">hideSoftInputFromWindow(android.os.IBinder, int, android.os.ResultReceiver)</see>
		/// : the
		/// state of the soft input window changed from shown to hidden.
		/// </summary>
		public const int RESULT_HIDDEN = 3;

		/// <summary>
		/// Explicitly request that the current input method's soft input area be
		/// shown to the user, if needed.
		/// </summary>
		/// <remarks>
		/// Explicitly request that the current input method's soft input area be
		/// shown to the user, if needed.  Call this if the user interacts with
		/// your view in such a way that they have expressed they would like to
		/// start performing input into it.
		/// </remarks>
		/// <param name="view">
		/// The currently focused view, which would like to receive
		/// soft keyboard input.
		/// </param>
		/// <param name="flags">
		/// Provides additional operating flags.  Currently may be
		/// 0 or have the
		/// <see cref="SHOW_IMPLICIT">SHOW_IMPLICIT</see>
		/// bit set.
		/// </param>
		/// <param name="resultReceiver">
		/// If non-null, this will be called by the IME when
		/// it has processed your request to tell you what it has done.  The result
		/// code you receive may be either
		/// <see cref="RESULT_UNCHANGED_SHOWN">RESULT_UNCHANGED_SHOWN</see>
		/// ,
		/// <see cref="RESULT_UNCHANGED_HIDDEN">RESULT_UNCHANGED_HIDDEN</see>
		/// ,
		/// <see cref="RESULT_SHOWN">RESULT_SHOWN</see>
		/// , or
		/// <see cref="RESULT_HIDDEN">RESULT_HIDDEN</see>
		/// .
		/// </param>
		public bool showSoftInput(android.view.View view, int flags, android.os.ResultReceiver
			 resultReceiver)
		{
			checkFocus();
			lock (mH)
			{
				if (mServedView != view && (mServedView == null || !mServedView.checkInputConnectionProxy
					(view)))
				{
					return false;
				}
				try
				{
					return mService.showSoftInput(mClient, flags, resultReceiver);
				}
				catch (android.os.RemoteException)
				{
				}
				return false;
			}
		}

		/// <hide></hide>
		public void showSoftInputUnchecked(int flags, android.os.ResultReceiver resultReceiver
			)
		{
			try
			{
				mService.showSoftInput(mClient, flags, resultReceiver);
			}
			catch (android.os.RemoteException)
			{
			}
		}

		/// <summary>
		/// Flag for
		/// <see cref="hideSoftInputFromWindow(android.os.IBinder, int)">hideSoftInputFromWindow(android.os.IBinder, int)
		/// 	</see>
		/// to indicate that the soft
		/// input window should only be hidden if it was not explicitly shown
		/// by the user.
		/// </summary>
		public const int HIDE_IMPLICIT_ONLY = unchecked((int)(0x0001));

		/// <summary>
		/// Flag for
		/// <see cref="hideSoftInputFromWindow(android.os.IBinder, int)">hideSoftInputFromWindow(android.os.IBinder, int)
		/// 	</see>
		/// to indicate that the soft
		/// input window should normally be hidden, unless it was originally
		/// shown with
		/// <see cref="SHOW_FORCED">SHOW_FORCED</see>
		/// .
		/// </summary>
		public const int HIDE_NOT_ALWAYS = unchecked((int)(0x0002));

		/// <summary>
		/// Synonym for
		/// <see cref="hideSoftInputFromWindow(android.os.IBinder, int, android.os.ResultReceiver)
		/// 	">hideSoftInputFromWindow(android.os.IBinder, int, android.os.ResultReceiver)</see>
		/// without a result: request to hide the soft input window from the
		/// context of the window that is currently accepting input.
		/// </summary>
		/// <param name="windowToken">
		/// The token of the window that is making the request,
		/// as returned by
		/// <see cref="android.view.View.getWindowToken()">View.getWindowToken()</see>
		/// .
		/// </param>
		/// <param name="flags">
		/// Provides additional operating flags.  Currently may be
		/// 0 or have the
		/// <see cref="HIDE_IMPLICIT_ONLY">HIDE_IMPLICIT_ONLY</see>
		/// bit set.
		/// </param>
		public bool hideSoftInputFromWindow(android.os.IBinder windowToken, int flags)
		{
			return hideSoftInputFromWindow(windowToken, flags, null);
		}

		/// <summary>
		/// Request to hide the soft input window from the context of the window
		/// that is currently accepting input.
		/// </summary>
		/// <remarks>
		/// Request to hide the soft input window from the context of the window
		/// that is currently accepting input.  This should be called as a result
		/// of the user doing some actually than fairly explicitly requests to
		/// have the input window hidden.
		/// </remarks>
		/// <param name="windowToken">
		/// The token of the window that is making the request,
		/// as returned by
		/// <see cref="android.view.View.getWindowToken()">View.getWindowToken()</see>
		/// .
		/// </param>
		/// <param name="flags">
		/// Provides additional operating flags.  Currently may be
		/// 0 or have the
		/// <see cref="HIDE_IMPLICIT_ONLY">HIDE_IMPLICIT_ONLY</see>
		/// bit set.
		/// </param>
		/// <param name="resultReceiver">
		/// If non-null, this will be called by the IME when
		/// it has processed your request to tell you what it has done.  The result
		/// code you receive may be either
		/// <see cref="RESULT_UNCHANGED_SHOWN">RESULT_UNCHANGED_SHOWN</see>
		/// ,
		/// <see cref="RESULT_UNCHANGED_HIDDEN">RESULT_UNCHANGED_HIDDEN</see>
		/// ,
		/// <see cref="RESULT_SHOWN">RESULT_SHOWN</see>
		/// , or
		/// <see cref="RESULT_HIDDEN">RESULT_HIDDEN</see>
		/// .
		/// </param>
		public bool hideSoftInputFromWindow(android.os.IBinder windowToken, int flags, android.os.ResultReceiver
			 resultReceiver)
		{
			checkFocus();
			lock (mH)
			{
				if (mServedView == null || mServedView.getWindowToken() != windowToken)
				{
					return false;
				}
				try
				{
					return mService.hideSoftInput(mClient, flags, resultReceiver);
				}
				catch (android.os.RemoteException)
				{
				}
				return false;
			}
		}

		/// <summary>This method toggles the input method window display.</summary>
		/// <remarks>
		/// This method toggles the input method window display.
		/// If the input window is already displayed, it gets hidden.
		/// If not the input window will be displayed.
		/// </remarks>
		/// <param name="windowToken">
		/// The token of the window that is making the request,
		/// as returned by
		/// <see cref="android.view.View.getWindowToken()">View.getWindowToken()</see>
		/// .
		/// </param>
		/// <param name="showFlags">
		/// Provides additional operating flags.  May be
		/// 0 or have the
		/// <see cref="SHOW_IMPLICIT">SHOW_IMPLICIT</see>
		/// ,
		/// <see cref="SHOW_FORCED">SHOW_FORCED</see>
		/// bit set.
		/// </param>
		/// <param name="hideFlags">
		/// Provides additional operating flags.  May be
		/// 0 or have the
		/// <see cref="HIDE_IMPLICIT_ONLY">HIDE_IMPLICIT_ONLY</see>
		/// ,
		/// <see cref="HIDE_NOT_ALWAYS">HIDE_NOT_ALWAYS</see>
		/// bit set.
		/// </param>
		public void toggleSoftInputFromWindow(android.os.IBinder windowToken, int showFlags
			, int hideFlags)
		{
			lock (mH)
			{
				if (mServedView == null || mServedView.getWindowToken() != windowToken)
				{
					return;
				}
				if (mCurMethod != null)
				{
					try
					{
						mCurMethod.toggleSoftInput(showFlags, hideFlags);
					}
					catch (android.os.RemoteException)
					{
					}
				}
			}
		}

		public void toggleSoftInput(int showFlags, int hideFlags)
		{
			if (mCurMethod != null)
			{
				try
				{
					mCurMethod.toggleSoftInput(showFlags, hideFlags);
				}
				catch (android.os.RemoteException)
				{
				}
			}
		}

		/// <summary>
		/// If the input method is currently connected to the given view,
		/// restart it with its new contents.
		/// </summary>
		/// <remarks>
		/// If the input method is currently connected to the given view,
		/// restart it with its new contents.  You should call this when the text
		/// within your view changes outside of the normal input method or key
		/// input flow, such as when an application calls TextView.setText().
		/// </remarks>
		/// <param name="view">The view whose text has changed.</param>
		public void restartInput(android.view.View view)
		{
			checkFocus();
			lock (mH)
			{
				if (mServedView != view && (mServedView == null || !mServedView.checkInputConnectionProxy
					(view)))
				{
					return;
				}
				mServedConnecting = true;
			}
			startInputInner();
		}

		private sealed class _Runnable_976 : java.lang.Runnable
		{
			public _Runnable_976()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public void run()
			{
				throw new System.NotImplementedException();
			}
		}

		internal void startInputInner()
		{
			android.view.View view;
			lock (mH)
			{
				view = mServedView;
				// Make sure we have a window token for the served view.
				if (view == null)
				{
					return;
				}
			}
			// Now we need to get an input connection from the served view.
			// This is complicated in a couple ways: we can't be holding our lock
			// when calling out to the view, and we need to make sure we call into
			// the view on the same thread that is driving its view hierarchy.
			android.os.Handler vh = view.getHandler();
			if (vh == null)
			{
				// If the view doesn't have a handler, something has changed out
				// from under us, so just bail.
				return;
			}
			if (vh.getLooper() != android.os.Looper.myLooper())
			{
				// The view is running on a different thread than our own, so
				// we need to reschedule our work for over there.
				vh.post(new _Runnable_976());
				return;
			}
			// Okay we are now ready to call into the served view and have it
			// do its stuff.
			// Life is good: let's hook everything up!
			android.view.inputmethod.EditorInfo tba = new android.view.inputmethod.EditorInfo
				();
			tba.packageName = view.getContext().getPackageName();
			tba.fieldId = view.getId();
			android.view.inputmethod.InputConnection ic = view.onCreateInputConnection(tba);
			lock (mH)
			{
				// Now that we are locked again, validate that our state hasn't
				// changed.
				if (mServedView != view || !mServedConnecting)
				{
					// Something else happened, so abort.
					return;
				}
				// If we already have a text box, then this view is already
				// connected so we want to restart it.
				bool initial = mCurrentTextBoxAttribute == null;
				// Hook 'em up and let 'er rip.
				mCurrentTextBoxAttribute = tba;
				mServedConnecting = false;
				mServedInputConnection = ic;
				android.view.@internal.IInputContext servedContext;
				if (ic != null)
				{
					mCursorSelStart = tba.initialSelStart;
					mCursorSelEnd = tba.initialSelEnd;
					mCursorCandStart = -1;
					mCursorCandEnd = -1;
					mCursorRect.setEmpty();
					servedContext = new android.view.inputmethod.InputMethodManager.ControlledInputConnectionWrapper
						(this, vh.getLooper(), ic);
				}
				else
				{
					servedContext = null;
				}
				try
				{
					android.view.@internal.InputBindResult res = mService.startInput(mClient, servedContext
						, tba, initial, true);
					if (res != null)
					{
						if (res.id != null)
						{
							mBindSequence = res.sequence;
							mCurMethod = res.method;
						}
						else
						{
							if (mCurMethod == null)
							{
								// This means there is no input method available.
								return;
							}
						}
					}
					if (mCurMethod != null && mCompletions != null)
					{
						try
						{
							mCurMethod.displayCompletions(mCompletions);
						}
						catch (android.os.RemoteException)
						{
						}
					}
				}
				catch (android.os.RemoteException e)
				{
					android.util.Log.w(TAG, "IME died: " + mCurId, e);
				}
			}
		}

		/// <summary>
		/// When the focused window is dismissed, this method is called to finish the
		/// input method started before.
		/// </summary>
		/// <remarks>
		/// When the focused window is dismissed, this method is called to finish the
		/// input method started before.
		/// </remarks>
		/// <hide></hide>
		public void windowDismissed(android.os.IBinder appWindowToken)
		{
			checkFocus();
			lock (mH)
			{
				if (mServedView != null && mServedView.getWindowToken() == appWindowToken)
				{
					finishInputLocked();
				}
			}
		}

		/// <summary>Call this when a view receives focus.</summary>
		/// <remarks>Call this when a view receives focus.</remarks>
		/// <hide></hide>
		public void focusIn(android.view.View view)
		{
			lock (mH)
			{
				focusInLocked(view);
			}
		}

		internal void focusInLocked(android.view.View view)
		{
			if (mCurRootView != view.getRootView())
			{
				// This is a request from a window that isn't in the window with
				// IME focus, so ignore it.
				return;
			}
			mNextServedView = view;
			scheduleCheckFocusLocked(view);
		}

		/// <summary>Call this when a view loses focus.</summary>
		/// <remarks>Call this when a view loses focus.</remarks>
		/// <hide></hide>
		public void focusOut(android.view.View view)
		{
			lock (mH)
			{
				if (mServedView != view)
				{
					// The following code would auto-hide the IME if we end up
					// with no more views with focus.  This can happen, however,
					// whenever we go into touch mode, so it ends up hiding
					// at times when we don't really want it to.  For now it
					// seems better to just turn it all off.
					if (false && view.hasWindowFocus())
					{
						mNextServedView = null;
						scheduleCheckFocusLocked(view);
					}
				}
			}
		}

		internal void scheduleCheckFocusLocked(android.view.View view)
		{
			android.os.Handler vh = view.getHandler();
			if (vh != null && !vh.hasMessages(android.view.ViewRootImpl.CHECK_FOCUS))
			{
				// This will result in a call to checkFocus() below.
				vh.sendMessage(vh.obtainMessage(android.view.ViewRootImpl.CHECK_FOCUS));
			}
		}

		/// <hide></hide>
		public void checkFocus()
		{
			// This is called a lot, so short-circuit before locking.
			if (mServedView == mNextServedView && !mNextServedNeedsStart)
			{
				return;
			}
			android.view.inputmethod.InputConnection ic = null;
			lock (mH)
			{
				if (mServedView == mNextServedView && !mNextServedNeedsStart)
				{
					return;
				}
				mNextServedNeedsStart = false;
				if (mNextServedView == null)
				{
					finishInputLocked();
					// In this case, we used to have a focused view on the window,
					// but no longer do.  We should make sure the input method is
					// no longer shown, since it serves no purpose.
					closeCurrentInput();
					return;
				}
				ic = mServedInputConnection;
				mServedView = mNextServedView;
				mCurrentTextBoxAttribute = null;
				mCompletions = null;
				mServedConnecting = true;
			}
			if (ic != null)
			{
				ic.finishComposingText();
			}
			startInputInner();
		}

		internal void closeCurrentInput()
		{
			try
			{
				mService.hideSoftInput(mClient, HIDE_NOT_ALWAYS, null);
			}
			catch (android.os.RemoteException)
			{
			}
		}

		/// <summary>Called by ViewAncestor when its window gets input focus.</summary>
		/// <remarks>Called by ViewAncestor when its window gets input focus.</remarks>
		/// <hide></hide>
		public void onWindowFocus(android.view.View rootView, android.view.View focusedView
			, int softInputMode, bool first, int windowFlags)
		{
			lock (mH)
			{
				if (mHasBeenInactive)
				{
					mHasBeenInactive = false;
					mNextServedNeedsStart = true;
				}
				focusInLocked(focusedView != null ? focusedView : rootView);
			}
			checkFocus();
			lock (mH)
			{
				try
				{
					bool isTextEditor = focusedView != null && focusedView.onCheckIsTextEditor();
					mService.windowGainedFocus(mClient, rootView.getWindowToken(), focusedView != null
						, isTextEditor, softInputMode, first, windowFlags);
				}
				catch (android.os.RemoteException)
				{
				}
			}
		}

		/// <hide></hide>
		public void startGettingWindowFocus(android.view.View rootView)
		{
			lock (mH)
			{
				mCurRootView = rootView;
			}
		}

		/// <summary>Report the current selection range.</summary>
		/// <remarks>Report the current selection range.</remarks>
		public void updateSelection(android.view.View view, int selStart, int selEnd, int
			 candidatesStart, int candidatesEnd)
		{
			checkFocus();
			lock (mH)
			{
				if ((mServedView != view && (mServedView == null || !mServedView.checkInputConnectionProxy
					(view))) || mCurrentTextBoxAttribute == null || mCurMethod == null)
				{
					return;
				}
				if (mCursorSelStart != selStart || mCursorSelEnd != selEnd || mCursorCandStart !=
					 candidatesStart || mCursorCandEnd != candidatesEnd)
				{
					try
					{
						mCurMethod.updateSelection(mCursorSelStart, mCursorSelEnd, selStart, selEnd, candidatesStart
							, candidatesEnd);
						mCursorSelStart = selStart;
						mCursorSelEnd = selEnd;
						mCursorCandStart = candidatesStart;
						mCursorCandEnd = candidatesEnd;
					}
					catch (android.os.RemoteException e)
					{
						android.util.Log.w(TAG, "IME died: " + mCurId, e);
					}
				}
			}
		}

		/// <summary>Notify the event when the user tapped or clicked the text view.</summary>
		/// <remarks>Notify the event when the user tapped or clicked the text view.</remarks>
		public void viewClicked(android.view.View view)
		{
			bool focusChanged = mServedView != mNextServedView;
			checkFocus();
			lock (mH)
			{
				if ((mServedView != view && (mServedView == null || !mServedView.checkInputConnectionProxy
					(view))) || mCurrentTextBoxAttribute == null || mCurMethod == null)
				{
					return;
				}
				try
				{
					mCurMethod.viewClicked(focusChanged);
				}
				catch (android.os.RemoteException e)
				{
					android.util.Log.w(TAG, "IME died: " + mCurId, e);
				}
			}
		}

		/// <summary>
		/// Returns true if the current input method wants to watch the location
		/// of the input editor's cursor in its window.
		/// </summary>
		/// <remarks>
		/// Returns true if the current input method wants to watch the location
		/// of the input editor's cursor in its window.
		/// </remarks>
		public bool isWatchingCursor(android.view.View view)
		{
			return false;
		}

		/// <summary>Report the current cursor location in its window.</summary>
		/// <remarks>Report the current cursor location in its window.</remarks>
		public void updateCursor(android.view.View view, int left, int top, int right, int
			 bottom)
		{
			checkFocus();
			lock (mH)
			{
				if ((mServedView != view && (mServedView == null || !mServedView.checkInputConnectionProxy
					(view))) || mCurrentTextBoxAttribute == null || mCurMethod == null)
				{
					return;
				}
				mTmpCursorRect.set(left, top, right, bottom);
				if (!mCursorRect.Equals(mTmpCursorRect))
				{
					try
					{
						mCurMethod.updateCursor(mTmpCursorRect);
						mCursorRect.set(mTmpCursorRect);
					}
					catch (android.os.RemoteException e)
					{
						android.util.Log.w(TAG, "IME died: " + mCurId, e);
					}
				}
			}
		}

		/// <summary>
		/// Call
		/// <see cref="InputMethodSession.appPrivateCommand(string, android.os.Bundle)">InputMethodSession.appPrivateCommand()
		/// 	</see>
		/// on the current Input Method.
		/// </summary>
		/// <param name="view">
		/// Optional View that is sending the command, or null if
		/// you want to send the command regardless of the view that is attached
		/// to the input method.
		/// </param>
		/// <param name="action">
		/// Name of the command to be performed.  This <em>must</em>
		/// be a scoped name, i.e. prefixed with a package name you own, so that
		/// different developers will not create conflicting commands.
		/// </param>
		/// <param name="data">Any data to include with the command.</param>
		public void sendAppPrivateCommand(android.view.View view, string action, android.os.Bundle
			 data)
		{
			checkFocus();
			lock (mH)
			{
				if ((mServedView != view && (mServedView == null || !mServedView.checkInputConnectionProxy
					(view))) || mCurrentTextBoxAttribute == null || mCurMethod == null)
				{
					return;
				}
				try
				{
					mCurMethod.appPrivateCommand(action, data);
				}
				catch (android.os.RemoteException e)
				{
					android.util.Log.w(TAG, "IME died: " + mCurId, e);
				}
			}
		}

		/// <summary>Force switch to a new input method component.</summary>
		/// <remarks>
		/// Force switch to a new input method component. This can only be called
		/// from an application or a service which has a token of the currently active input method.
		/// </remarks>
		/// <param name="token">
		/// Supplies the identifying token given to an input method
		/// when it was started, which allows it to perform this operation on
		/// itself.
		/// </param>
		/// <param name="id">The unique identifier for the new input method to be switched to.
		/// 	</param>
		public void setInputMethod(android.os.IBinder token, string id)
		{
			try
			{
				mService.setInputMethod(token, id);
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException(e);
			}
		}

		/// <summary>Force switch to a new input method and subtype.</summary>
		/// <remarks>
		/// Force switch to a new input method and subtype. This can only be called
		/// from an application or a service which has a token of the currently active input method.
		/// </remarks>
		/// <param name="token">
		/// Supplies the identifying token given to an input method
		/// when it was started, which allows it to perform this operation on
		/// itself.
		/// </param>
		/// <param name="id">The unique identifier for the new input method to be switched to.
		/// 	</param>
		/// <param name="subtype">The new subtype of the new input method to be switched to.</param>
		public void setInputMethodAndSubtype(android.os.IBinder token, string id, android.view.inputmethod.InputMethodSubtype
			 subtype)
		{
			try
			{
				mService.setInputMethodAndSubtype(token, id, subtype);
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException(e);
			}
		}

		/// <summary>
		/// Close/hide the input method's soft input area, so the user no longer
		/// sees it or can interact with it.
		/// </summary>
		/// <remarks>
		/// Close/hide the input method's soft input area, so the user no longer
		/// sees it or can interact with it.  This can only be called
		/// from the currently active input method, as validated by the given token.
		/// </remarks>
		/// <param name="token">
		/// Supplies the identifying token given to an input method
		/// when it was started, which allows it to perform this operation on
		/// itself.
		/// </param>
		/// <param name="flags">
		/// Provides additional operating flags.  Currently may be
		/// 0 or have the
		/// <see cref="HIDE_IMPLICIT_ONLY">HIDE_IMPLICIT_ONLY</see>
		/// ,
		/// <see cref="HIDE_NOT_ALWAYS">HIDE_NOT_ALWAYS</see>
		/// bit set.
		/// </param>
		public void hideSoftInputFromInputMethod(android.os.IBinder token, int flags)
		{
			try
			{
				mService.hideMySoftInput(token, flags);
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException(e);
			}
		}

		/// <summary>
		/// Show the input method's soft input area, so the user
		/// sees the input method window and can interact with it.
		/// </summary>
		/// <remarks>
		/// Show the input method's soft input area, so the user
		/// sees the input method window and can interact with it.
		/// This can only be called from the currently active input method,
		/// as validated by the given token.
		/// </remarks>
		/// <param name="token">
		/// Supplies the identifying token given to an input method
		/// when it was started, which allows it to perform this operation on
		/// itself.
		/// </param>
		/// <param name="flags">
		/// Provides additional operating flags.  Currently may be
		/// 0 or have the
		/// <see cref="SHOW_IMPLICIT">SHOW_IMPLICIT</see>
		/// or
		/// <see cref="SHOW_FORCED">SHOW_FORCED</see>
		/// bit set.
		/// </param>
		public void showSoftInputFromInputMethod(android.os.IBinder token, int flags)
		{
			try
			{
				mService.showMySoftInput(token, flags);
			}
			catch (android.os.RemoteException e)
			{
				throw new java.lang.RuntimeException(e);
			}
		}

		/// <hide></hide>
		public void dispatchKeyEvent(android.content.Context context, int seq, android.view.KeyEvent
			 key, android.view.@internal.IInputMethodCallback callback)
		{
			lock (mH)
			{
				if (mCurMethod == null)
				{
					try
					{
						callback.finishedEvent(seq, false);
					}
					catch (android.os.RemoteException)
					{
					}
					return;
				}
				if (key.getAction() == android.view.KeyEvent.ACTION_DOWN && key.getKeyCode() == android.view.KeyEvent
					.KEYCODE_SYM)
				{
					showInputMethodPicker();
					try
					{
						callback.finishedEvent(seq, true);
					}
					catch (android.os.RemoteException)
					{
					}
					return;
				}
				try
				{
					mCurMethod.dispatchKeyEvent(seq, key, callback);
				}
				catch (android.os.RemoteException e)
				{
					android.util.Log.w(TAG, "IME died: " + mCurId + " dropping: " + key, e);
					try
					{
						callback.finishedEvent(seq, false);
					}
					catch (android.os.RemoteException)
					{
					}
				}
			}
		}

		/// <hide></hide>
		internal void dispatchTrackballEvent(android.content.Context context, int seq, android.view.MotionEvent
			 motion, android.view.@internal.IInputMethodCallback callback)
		{
			lock (mH)
			{
				if (mCurMethod == null || mCurrentTextBoxAttribute == null)
				{
					try
					{
						callback.finishedEvent(seq, false);
					}
					catch (android.os.RemoteException)
					{
					}
					return;
				}
				try
				{
					mCurMethod.dispatchTrackballEvent(seq, motion, callback);
				}
				catch (android.os.RemoteException e)
				{
					android.util.Log.w(TAG, "IME died: " + mCurId + " dropping trackball: " + motion, 
						e);
					try
					{
						callback.finishedEvent(seq, false);
					}
					catch (android.os.RemoteException)
					{
					}
				}
			}
		}

		public void showInputMethodPicker()
		{
			lock (mH)
			{
				try
				{
					mService.showInputMethodPickerFromClient(mClient);
				}
				catch (android.os.RemoteException e)
				{
					android.util.Log.w(TAG, "IME died: " + mCurId, e);
				}
			}
		}

		/// <summary>Show the settings for enabling subtypes of the specified input method.</summary>
		/// <remarks>Show the settings for enabling subtypes of the specified input method.</remarks>
		/// <param name="imiId">
		/// An input method, whose subtypes settings will be shown. If imiId is null,
		/// subtypes of all input methods will be shown.
		/// </param>
		public void showInputMethodAndSubtypeEnabler(string imiId)
		{
			lock (mH)
			{
				try
				{
					mService.showInputMethodAndSubtypeEnablerFromClient(mClient, imiId);
				}
				catch (android.os.RemoteException e)
				{
					android.util.Log.w(TAG, "IME died: " + mCurId, e);
				}
			}
		}

		/// <summary>Returns the current input method subtype.</summary>
		/// <remarks>
		/// Returns the current input method subtype. This subtype is one of the subtypes in
		/// the current input method. This method returns null when the current input method doesn't
		/// have any input method subtype.
		/// </remarks>
		public android.view.inputmethod.InputMethodSubtype getCurrentInputMethodSubtype()
		{
			lock (mH)
			{
				try
				{
					return mService.getCurrentInputMethodSubtype();
				}
				catch (android.os.RemoteException e)
				{
					android.util.Log.w(TAG, "IME died: " + mCurId, e);
					return null;
				}
			}
		}

		/// <summary>Switch to a new input method subtype of the current input method.</summary>
		/// <remarks>Switch to a new input method subtype of the current input method.</remarks>
		/// <param name="subtype">A new input method subtype to switch.</param>
		/// <returns>
		/// true if the current subtype was successfully switched. When the specified subtype is
		/// null, this method returns false.
		/// </returns>
		public bool setCurrentInputMethodSubtype(android.view.inputmethod.InputMethodSubtype
			 subtype)
		{
			lock (mH)
			{
				try
				{
					return mService.setCurrentInputMethodSubtype(subtype);
				}
				catch (android.os.RemoteException e)
				{
					android.util.Log.w(TAG, "IME died: " + mCurId, e);
					return false;
				}
			}
		}

		[Sharpen.Stub]
		public java.util.Map<android.view.inputmethod.InputMethodInfo, java.util.List<android.view.inputmethod.InputMethodSubtype
			>> getShortcutInputMethodsAndSubtypes()
		{
			throw new System.NotImplementedException();
		}

		// TODO: We should change the return type from List<Object> to List<Parcelable>
		// "info" has imi1, subtype1, subtype2, imi2, subtype2, imi3, subtype3..in the list
		/// <summary>Force switch to the last used input method and subtype.</summary>
		/// <remarks>
		/// Force switch to the last used input method and subtype. If the last input method didn't have
		/// any subtypes, the framework will simply switch to the last input method with no subtype
		/// specified.
		/// </remarks>
		/// <param name="imeToken">
		/// Supplies the identifying token given to an input method when it was started,
		/// which allows it to perform this operation on itself.
		/// </param>
		/// <returns>
		/// true if the current input method and subtype was successfully switched to the last
		/// used input method and subtype.
		/// </returns>
		public bool switchToLastInputMethod(android.os.IBinder imeToken)
		{
			lock (mH)
			{
				try
				{
					return mService.switchToLastInputMethod(imeToken);
				}
				catch (android.os.RemoteException e)
				{
					android.util.Log.w(TAG, "IME died: " + mCurId, e);
					return false;
				}
			}
		}

		/// <summary>Set additional input method subtypes.</summary>
		/// <remarks>
		/// Set additional input method subtypes. Only a process which shares the same uid with the IME
		/// can add additional input method subtypes to the IME.
		/// Please note that a subtype's status is stored in the system.
		/// For example, enabled subtypes are remembered by the framework even after they are removed
		/// by using this method. If you re-add the same subtypes again,
		/// they will just get enabled. If you want to avoid such conflicts, for instance, you may
		/// want to create a "different" new subtype even with the same locale and mode,
		/// by changing its extra value. The different subtype won't get affected by the stored past
		/// status. (You may want to take a look at
		/// <see cref="InputMethodSubtype.GetHashCode()">InputMethodSubtype.GetHashCode()</see>
		/// to refer
		/// to the current implementation.)
		/// </remarks>
		/// <param name="imiId">Id of InputMethodInfo which additional input method subtypes will be added to.
		/// 	</param>
		/// <param name="subtypes">subtypes will be added as additional subtypes of the current input method.
		/// 	</param>
		public void setAdditionalInputMethodSubtypes(string imiId, android.view.inputmethod.InputMethodSubtype
			[] subtypes)
		{
			lock (mH)
			{
				try
				{
					mService.setAdditionalInputMethodSubtypes(imiId, subtypes);
				}
				catch (android.os.RemoteException e)
				{
					android.util.Log.w(TAG, "IME died: " + mCurId, e);
				}
			}
		}

		public android.view.inputmethod.InputMethodSubtype getLastInputMethodSubtype()
		{
			lock (mH)
			{
				try
				{
					return mService.getLastInputMethodSubtype();
				}
				catch (android.os.RemoteException e)
				{
					android.util.Log.w(TAG, "IME died: " + mCurId, e);
					return null;
				}
			}
		}

		[Sharpen.Stub]
		internal void doDump(java.io.FileDescriptor fd, java.io.PrintWriter fout, string[]
			 args)
		{
			throw new System.NotImplementedException();
		}
	}
}

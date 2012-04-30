using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	public class Dialog : android.content.DialogInterface, android.view.Window.Callback
		, android.view.KeyEvent.Callback, android.view.View.OnCreateContextMenuListener
	{
		private android.app.Activity mOwnerActivity;

		internal readonly android.content.Context mContext;

		internal readonly android.view.WindowManager mWindowManager;

		internal android.view.Window mWindow;

		internal android.view.View mDecor;

		private android.app.@internal.ActionBarImpl mActionBar;

		protected internal bool mCancelable = true;

		private string mCancelAndDismissTaken;

		private android.os.Message mCancelMessage;

		private android.os.Message mDismissMessage;

		private android.os.Message mShowMessage;

		private android.content.DialogInterfaceClass.OnKeyListener mOnKeyListener;

		private bool mCreated = false;

		private bool mShowing = false;

		private bool mCanceled = false;

		private readonly java.lang.Thread mUiThread;

		private readonly android.os.Handler mHandler = new android.os.Handler();

		internal const int DISMISS = unchecked((int)(0x43));

		internal const int CANCEL = unchecked((int)(0x44));

		internal const int SHOW = unchecked((int)(0x45));

		private android.os.Handler mListenersHandler;

		private sealed class _Runnable_113 : java.lang.Runnable
		{
			public _Runnable_113()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public void run()
			{
				throw new System.NotImplementedException();
			}
		}

		private readonly java.lang.Runnable mDismissAction = new _Runnable_113();

		[Sharpen.Stub]
		public Dialog(android.content.Context context) : this(context, 0, true)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public Dialog(android.content.Context context, int theme) : this(context, theme, 
			true)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal Dialog(android.content.Context context, int theme, bool createContextWrapper
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute]
		protected internal Dialog(android.content.Context context, bool cancelable, android.os.Message
			 cancelCallback) : this(context)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal Dialog(android.content.Context context, bool cancelable, android.content.DialogInterfaceClass
			.OnCancelListener cancelListener) : this(context)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.content.Context getContext()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.app.ActionBar getActionBar()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void setOwnerActivity(android.app.Activity activity)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.app.Activity getOwnerActivity()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isShowing()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void show()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void hide()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.DialogInterface")]
		public virtual void dismiss()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void dismissDialog()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void sendDismissMessage()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void sendShowMessage()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void dispatchOnCreate(android.os.Bundle savedInstanceState)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual void onCreate(android.os.Bundle savedInstanceState)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual void onStart()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual void onStop()
		{
			throw new System.NotImplementedException();
		}

		internal const string DIALOG_SHOWING_TAG = "android:dialogShowing";

		internal const string DIALOG_HIERARCHY_TAG = "android:dialogHierarchy";

		[Sharpen.Stub]
		public virtual android.os.Bundle onSaveInstanceState()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onRestoreInstanceState(android.os.Bundle savedInstanceState)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.view.Window getWindow()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.view.View getCurrentFocus()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.view.View findViewById(int id)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setContentView(int layoutResID)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setContentView(android.view.View view)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setContentView(android.view.View view, android.view.ViewGroup
			.LayoutParams @params)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void addContentView(android.view.View view, android.view.ViewGroup
			.LayoutParams @params)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setTitle(java.lang.CharSequence title)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setTitle(int titleId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.KeyEvent.Callback")]
		public virtual bool onKeyDown(int keyCode, android.view.KeyEvent @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.KeyEvent.Callback")]
		public virtual bool onKeyLongPress(int keyCode, android.view.KeyEvent @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.KeyEvent.Callback")]
		public virtual bool onKeyUp(int keyCode, android.view.KeyEvent @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.KeyEvent.Callback")]
		public virtual bool onKeyMultiple(int keyCode, int repeatCount, android.view.KeyEvent
			 @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onBackPressed()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool onKeyShortcut(int keyCode, android.view.KeyEvent @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool onTouchEvent(android.view.MotionEvent @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool onTrackballEvent(android.view.MotionEvent @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool onGenericMotionEvent(android.view.MotionEvent @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.Window.Callback")]
		public virtual void onWindowAttributesChanged(android.view.WindowManagerClass.LayoutParams
			 @params)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.Window.Callback")]
		public virtual void onContentChanged()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.Window.Callback")]
		public virtual void onWindowFocusChanged(bool hasFocus)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.Window.Callback")]
		public virtual void onAttachedToWindow()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.Window.Callback")]
		public virtual void onDetachedFromWindow()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.Window.Callback")]
		public virtual bool dispatchKeyEvent(android.view.KeyEvent @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.Window.Callback")]
		public virtual bool dispatchKeyShortcutEvent(android.view.KeyEvent @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.Window.Callback")]
		public virtual bool dispatchTouchEvent(android.view.MotionEvent ev)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.Window.Callback")]
		public virtual bool dispatchTrackballEvent(android.view.MotionEvent ev)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.Window.Callback")]
		public virtual bool dispatchGenericMotionEvent(android.view.MotionEvent ev)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.Window.Callback")]
		public virtual bool dispatchPopulateAccessibilityEvent(android.view.accessibility.AccessibilityEvent
			 @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.Window.Callback")]
		public virtual android.view.View onCreatePanelView(int featureId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.Window.Callback")]
		public virtual bool onCreatePanelMenu(int featureId, android.view.Menu menu)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.Window.Callback")]
		public virtual bool onPreparePanel(int featureId, android.view.View view, android.view.Menu
			 menu)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.Window.Callback")]
		public virtual bool onMenuOpened(int featureId, android.view.Menu menu)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.Window.Callback")]
		public virtual bool onMenuItemSelected(int featureId, android.view.MenuItem item)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.Window.Callback")]
		public virtual void onPanelClosed(int featureId, android.view.Menu menu)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool onCreateOptionsMenu(android.view.Menu menu)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool onPrepareOptionsMenu(android.view.Menu menu)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool onOptionsItemSelected(android.view.MenuItem item)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onOptionsMenuClosed(android.view.Menu menu)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void openOptionsMenu()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void closeOptionsMenu()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void invalidateOptionsMenu()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.View.OnCreateContextMenuListener")]
		public virtual void onCreateContextMenu(android.view.ContextMenu menu, android.view.View
			 v, android.view.ContextMenuClass.ContextMenuInfo menuInfo)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void registerForContextMenu(android.view.View view)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void unregisterForContextMenu(android.view.View view)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void openContextMenu(android.view.View view)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool onContextItemSelected(android.view.MenuItem item)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onContextMenuClosed(android.view.Menu menu)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.Window.Callback")]
		public virtual bool onSearchRequested()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.Window.Callback")]
		public virtual android.view.ActionMode onWindowStartingActionMode(android.view.ActionMode
			.Callback callback)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.Window.Callback")]
		public virtual void onActionModeStarted(android.view.ActionMode mode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.Window.Callback")]
		public virtual void onActionModeFinished(android.view.ActionMode mode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private android.content.ComponentName getAssociatedActivity()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void takeKeyEvents(bool get)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool requestWindowFeature(int featureId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void setFeatureDrawableResource(int featureId, int resId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void setFeatureDrawableUri(int featureId, System.Uri uri)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void setFeatureDrawable(int featureId, android.graphics.drawable.Drawable 
			drawable)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void setFeatureDrawableAlpha(int featureId, int alpha)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.view.LayoutInflater getLayoutInflater()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setCancelable(bool flag)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setCanceledOnTouchOutside(bool cancel_1)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.DialogInterface")]
		public virtual void cancel()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setOnCancelListener(android.content.DialogInterfaceClass.OnCancelListener
			 listener)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setCancelMessage(android.os.Message msg)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setOnDismissListener(android.content.DialogInterfaceClass.OnDismissListener
			 listener)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setOnShowListener(android.content.DialogInterfaceClass.OnShowListener
			 listener)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setDismissMessage(android.os.Message msg)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool takeCancelAndDismissListeners(string msg, android.content.DialogInterfaceClass
			.OnCancelListener cancel_1, android.content.DialogInterfaceClass.OnDismissListener
			 dismiss_1)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void setVolumeControlStream(int streamType)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int getVolumeControlStream()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setOnKeyListener(android.content.DialogInterfaceClass.OnKeyListener
			 onKeyListener)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private sealed class ListenersHandler : android.os.Handler
		{
			internal java.lang.@ref.WeakReference<android.content.DialogInterface> mDialog;

			[Sharpen.Stub]
			public ListenersHandler(android.app.Dialog dialog)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.os.Handler")]
			public override void handleMessage(android.os.Message msg)
			{
				throw new System.NotImplementedException();
			}
		}
	}
}

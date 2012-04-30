using Sharpen;

namespace android.app
{
	[Sharpen.Sharpened]
	public partial class Activity : android.view.ContextThemeWrapper, android.view.LayoutInflater
		.Factory2, android.view.Window.Callback, android.view.KeyEvent.Callback, android.view.View
		.OnCreateContextMenuListener, android.content.ComponentCallbacks2
	{
		internal const string TAG = "Activity";

		public const int RESULT_CANCELED = 0;

		public const int RESULT_OK = -1;

		public const int RESULT_FIRST_USER = 1;

		internal const string WINDOW_HIERARCHY_TAG = "android:viewHierarchyState";

		internal const string FRAGMENTS_TAG = "android:fragments";

		internal const string SAVED_DIALOG_IDS_KEY = "android:savedDialogIds";

		internal const string SAVED_DIALOGS_TAG = "android:savedDialogs";

		internal const string SAVED_DIALOG_KEY_PREFIX = "android:dialog_";

		internal const string SAVED_DIALOG_ARGS_KEY_PREFIX = "android:dialog_args_";

		private class ManagedDialog
		{
			internal android.app.Dialog mDialog;

			internal android.os.Bundle mArgs;
		}

		private android.util.SparseArray<android.app.Activity.ManagedDialog> mManagedDialogs;

		private android.app.Instrumentation mInstrumentation;

		private android.os.IBinder mToken;

		private int mIdent;

		internal string mEmbeddedID;

		private android.app.Application mApplication;

		internal android.content.Intent mIntent;

		private android.content.ComponentName mComponent;

		internal android.content.pm.ActivityInfo mActivityInfo;

		internal android.app.ActivityThread mMainThread;

		internal android.app.Activity mParent;

		internal bool mCalled;

		internal bool mCheckedForLoaderManager;

		internal bool mLoadersStarted;

		internal bool mResumed;

		private bool mStopped;

		internal bool mFinished;

		internal bool mStartedActivity;

		internal bool mTemporaryPause = false;

		internal bool mChangingConfigurations = false;

		internal int mConfigChangeFlags;

		internal android.content.res.Configuration mCurrentConfig;

		private android.app.SearchManager mSearchManager;

		private android.view.MenuInflater mMenuInflater;

		internal sealed class NonConfigurationInstances
		{
			internal object activity;

			internal java.util.HashMap<string, object> children;

			internal java.util.ArrayList<android.app.Fragment> fragments;

			internal android.util.SparseArray<android.app.LoaderManagerImpl> loaders;
		}

		internal android.app.Activity.NonConfigurationInstances mLastNonConfigurationInstances;

		private android.view.Window mWindow;

		private android.view.WindowManager mWindowManager;

		internal android.view.View mDecor = null;

		internal bool mWindowAdded = false;

		internal bool mVisibleFromServer = false;

		internal bool mVisibleFromClient = true;

		internal android.app.@internal.ActionBarImpl mActionBar = null;

		private java.lang.CharSequence mTitle;

		private int mTitleColor = 0;

		internal readonly android.app.FragmentManagerImpl mFragments = new android.app.FragmentManagerImpl
			();

		internal android.util.SparseArray<android.app.LoaderManagerImpl> mAllLoaderManagers;

		internal android.app.LoaderManagerImpl mLoaderManager;

		private sealed class ManagedCursor
		{
			internal ManagedCursor(android.database.Cursor cursor)
			{
				mCursor = cursor;
				mReleased = false;
				mUpdated = false;
			}

			internal readonly android.database.Cursor mCursor;

			internal bool mReleased;

			internal bool mUpdated;
		}

		private readonly java.util.ArrayList<android.app.Activity.ManagedCursor> mManagedCursors
			 = new java.util.ArrayList<android.app.Activity.ManagedCursor>();

		internal int mResultCode = RESULT_CANCELED;

		internal android.content.Intent mResultData = null;

		private bool mTitleReady = false;

		private int mDefaultKeyMode = DEFAULT_KEYS_DISABLE;

		private android.text.SpannableStringBuilder mDefaultKeySsb = null;

		protected internal static readonly int[] FOCUSED_STATE_SET = new int[] { android.@internal.R
			.attr.state_focused };

		private readonly object mInstanceTracker;

		private java.lang.Thread mUiThread;

		internal readonly android.os.Handler mHandler;

		public virtual android.content.Intent getIntent()
		{
			return mIntent;
		}

		public virtual void setIntent(android.content.Intent newIntent)
		{
			mIntent = newIntent;
		}

		public android.app.Application getApplication()
		{
			return mApplication;
		}

		public bool isChild()
		{
			return mParent != null;
		}

		public android.app.Activity getParent()
		{
			return mParent;
		}

		public virtual android.view.WindowManager getWindowManager()
		{
			return mWindowManager;
		}

		public virtual android.view.Window getWindow()
		{
			return mWindow;
		}

		public virtual android.app.LoaderManager getLoaderManager()
		{
			if (mLoaderManager != null)
			{
				return mLoaderManager;
			}
			mCheckedForLoaderManager = true;
			mLoaderManager = getLoaderManager(-1, mLoadersStarted, true);
			return mLoaderManager;
		}

		internal virtual android.app.LoaderManagerImpl getLoaderManager(int index, bool started
			, bool create)
		{
			if (mAllLoaderManagers == null)
			{
				mAllLoaderManagers = new android.util.SparseArray<android.app.LoaderManagerImpl>(
					);
			}
			android.app.LoaderManagerImpl lm = mAllLoaderManagers.get(index);
			if (lm == null)
			{
				if (create)
				{
					lm = new android.app.LoaderManagerImpl(this, started);
					mAllLoaderManagers.put(index, lm);
				}
			}
			else
			{
				lm.updateActivity(this);
			}
			return lm;
		}

		public virtual android.view.View getCurrentFocus()
		{
			return mWindow != null ? mWindow.getCurrentFocus() : null;
		}

		protected internal virtual void onCreate(android.os.Bundle savedInstanceState)
		{
			if (mLastNonConfigurationInstances != null)
			{
				mAllLoaderManagers = mLastNonConfigurationInstances.loaders;
			}
			if (savedInstanceState != null)
			{
				android.os.Parcelable p = savedInstanceState.getParcelable(FRAGMENTS_TAG);
				mFragments.restoreAllState(p, mLastNonConfigurationInstances != null ? mLastNonConfigurationInstances
					.fragments : null);
			}
			mFragments.dispatchCreate();
			getApplication().dispatchActivityCreated(this, savedInstanceState);
			mCalled = true;
		}

		internal void performRestoreInstanceState(android.os.Bundle savedInstanceState)
		{
			onRestoreInstanceState(savedInstanceState);
			restoreManagedDialogs(savedInstanceState);
		}

		protected internal virtual void onRestoreInstanceState(android.os.Bundle savedInstanceState
			)
		{
			if (mWindow != null)
			{
				android.os.Bundle windowState = savedInstanceState.getBundle(WINDOW_HIERARCHY_TAG
					);
				if (windowState != null)
				{
					mWindow.restoreHierarchyState(windowState);
				}
			}
		}

		private void restoreManagedDialogs(android.os.Bundle savedInstanceState)
		{
			android.os.Bundle b = savedInstanceState.getBundle(SAVED_DIALOGS_TAG);
			if (b == null)
			{
				return;
			}
			int[] ids = b.getIntArray(SAVED_DIALOG_IDS_KEY);
			int numDialogs = ids.Length;
			mManagedDialogs = new android.util.SparseArray<android.app.Activity.ManagedDialog
				>(numDialogs);
			{
				for (int i = 0; i < numDialogs; i++)
				{
					int dialogId = ids[i];
					android.os.Bundle dialogState = b.getBundle(savedDialogKeyFor(dialogId));
					if (dialogState != null)
					{
						android.app.Activity.ManagedDialog md = new android.app.Activity.ManagedDialog();
						md.mArgs = b.getBundle(savedDialogArgsKeyFor(dialogId));
						md.mDialog = createDialog(dialogId, dialogState, md.mArgs);
						if (md.mDialog != null)
						{
							mManagedDialogs.put(dialogId, md);
							onPrepareDialog(dialogId, md.mDialog, md.mArgs);
							md.mDialog.onRestoreInstanceState(dialogState);
						}
					}
				}
			}
		}

		private android.app.Dialog createDialog(int dialogId, android.os.Bundle state, android.os.Bundle
			 args)
		{
			android.app.Dialog dialog = onCreateDialog(dialogId, args);
			if (dialog == null)
			{
				return null;
			}
			dialog.dispatchOnCreate(state);
			return dialog;
		}

		private static string savedDialogKeyFor(int key)
		{
			return SAVED_DIALOG_KEY_PREFIX + key;
		}

		private static string savedDialogArgsKeyFor(int key)
		{
			return SAVED_DIALOG_ARGS_KEY_PREFIX + key;
		}

		protected internal virtual void onPostCreate(android.os.Bundle savedInstanceState
			)
		{
			if (!isChild())
			{
				mTitleReady = true;
				onTitleChanged(getTitle(), getTitleColor());
			}
			mCalled = true;
		}

		protected internal virtual void onStart()
		{
			mCalled = true;
			if (!mLoadersStarted)
			{
				mLoadersStarted = true;
				if (mLoaderManager != null)
				{
					mLoaderManager.doStart();
				}
				else
				{
					if (!mCheckedForLoaderManager)
					{
						mLoaderManager = getLoaderManager(-1, mLoadersStarted, false);
					}
				}
				mCheckedForLoaderManager = true;
			}
			getApplication().dispatchActivityStarted(this);
		}

		protected internal virtual void onRestart()
		{
			mCalled = true;
		}

		protected internal virtual void onResume()
		{
			getApplication().dispatchActivityResumed(this);
			mCalled = true;
		}

		protected internal virtual void onPostResume()
		{
			android.view.Window win = getWindow();
			if (win != null)
			{
				win.makeActive();
			}
			if (mActionBar != null)
			{
				mActionBar.setShowHideAnimationEnabled(true);
			}
			mCalled = true;
		}

		protected internal virtual void onNewIntent(android.content.Intent intent)
		{
		}

		internal void performSaveInstanceState(android.os.Bundle outState)
		{
			onSaveInstanceState(outState);
			saveManagedDialogs(outState);
		}

		protected internal virtual void onSaveInstanceState(android.os.Bundle outState)
		{
			outState.putBundle(WINDOW_HIERARCHY_TAG, mWindow.saveHierarchyState());
			android.os.Parcelable p = mFragments.saveAllState();
			if (p != null)
			{
				outState.putParcelable(FRAGMENTS_TAG, p);
			}
			getApplication().dispatchActivitySaveInstanceState(this, outState);
		}

		private void saveManagedDialogs(android.os.Bundle outState)
		{
			if (mManagedDialogs == null)
			{
				return;
			}
			int numDialogs = mManagedDialogs.size();
			if (numDialogs == 0)
			{
				return;
			}
			android.os.Bundle dialogState = new android.os.Bundle();
			int[] ids = new int[mManagedDialogs.size()];
			{
				for (int i = 0; i < numDialogs; i++)
				{
					int key = mManagedDialogs.keyAt(i);
					ids[i] = key;
					android.app.Activity.ManagedDialog md = mManagedDialogs.valueAt(i);
					dialogState.putBundle(savedDialogKeyFor(key), md.mDialog.onSaveInstanceState());
					if (md.mArgs != null)
					{
						dialogState.putBundle(savedDialogArgsKeyFor(key), md.mArgs);
					}
				}
			}
			dialogState.putIntArray(SAVED_DIALOG_IDS_KEY, ids);
			outState.putBundle(SAVED_DIALOGS_TAG, dialogState);
		}

		protected internal virtual void onPause()
		{
			getApplication().dispatchActivityPaused(this);
			mCalled = true;
		}

		protected internal virtual void onUserLeaveHint()
		{
		}

		public virtual bool onCreateThumbnail(android.graphics.Bitmap outBitmap, android.graphics.Canvas
			 canvas)
		{
			return false;
		}

		public virtual java.lang.CharSequence onCreateDescription()
		{
			return null;
		}

		protected internal virtual void onStop()
		{
			if (mActionBar != null)
			{
				mActionBar.setShowHideAnimationEnabled(false);
			}
			getApplication().dispatchActivityStopped(this);
			mCalled = true;
		}

		protected internal virtual void onDestroy()
		{
			mCalled = true;
			if (mManagedDialogs != null)
			{
				int numDialogs = mManagedDialogs.size();
				{
					for (int i = 0; i < numDialogs; i++)
					{
						android.app.Activity.ManagedDialog md = mManagedDialogs.valueAt(i);
						if (md.mDialog.isShowing())
						{
							md.mDialog.dismiss();
						}
					}
				}
				mManagedDialogs = null;
			}
			lock (mManagedCursors)
			{
				int numCursors = mManagedCursors.size();
				{
					for (int i = 0; i < numCursors; i++)
					{
						android.app.Activity.ManagedCursor c = mManagedCursors.get(i);
						if (c != null)
						{
							c.mCursor.close();
						}
					}
				}
				mManagedCursors.clear();
			}
			if (mSearchManager != null)
			{
				mSearchManager.stopSearch();
			}
			getApplication().dispatchActivityDestroyed(this);
		}

		[Sharpen.ImplementsInterface(@"android.content.ComponentCallbacks")]
		public virtual void onConfigurationChanged(android.content.res.Configuration newConfig
			)
		{
			mCalled = true;
			mFragments.dispatchConfigurationChanged(newConfig);
			if (mWindow != null)
			{
				mWindow.onConfigurationChanged(newConfig);
			}
			if (mActionBar != null)
			{
				mActionBar.onConfigurationChanged(newConfig);
			}
		}

		public virtual int getChangingConfigurations()
		{
			return mConfigChangeFlags;
		}

		[System.ObsoleteAttribute(@"Use the new Fragment APIFragment.setRetainInstance(bool) instead; this is also available on older platforms through the Android compatibility package."
			)]
		public virtual object getLastNonConfigurationInstance()
		{
			return mLastNonConfigurationInstances != null ? mLastNonConfigurationInstances.activity
				 : null;
		}

		[System.ObsoleteAttribute(@"Use the new Fragment APIFragment.setRetainInstance(bool) instead; this is also available on older platforms through the Android compatibility package."
			)]
		public virtual object onRetainNonConfigurationInstance()
		{
			return null;
		}

		internal virtual java.util.HashMap<string, object> getLastNonConfigurationChildInstances
			()
		{
			return mLastNonConfigurationInstances != null ? mLastNonConfigurationInstances.children
				 : null;
		}

		internal virtual java.util.HashMap<string, object> onRetainNonConfigurationChildInstances
			()
		{
			return null;
		}

		internal virtual android.app.Activity.NonConfigurationInstances retainNonConfigurationInstances
			()
		{
			object activity = onRetainNonConfigurationInstance();
			java.util.HashMap<string, object> children = onRetainNonConfigurationChildInstances
				();
			java.util.ArrayList<android.app.Fragment> fragments = mFragments.retainNonConfig(
				);
			bool retainLoaders = false;
			if (mAllLoaderManagers != null)
			{
				{
					for (int i = mAllLoaderManagers.size() - 1; i >= 0; i--)
					{
						android.app.LoaderManagerImpl lm = mAllLoaderManagers.valueAt(i);
						if (lm.mRetaining)
						{
							retainLoaders = true;
						}
						else
						{
							lm.doDestroy();
							mAllLoaderManagers.removeAt(i);
						}
					}
				}
			}
			if (activity == null && children == null && fragments == null && !retainLoaders)
			{
				return null;
			}
			android.app.Activity.NonConfigurationInstances nci = new android.app.Activity.NonConfigurationInstances
				();
			nci.activity = activity;
			nci.children = children;
			nci.fragments = fragments;
			nci.loaders = mAllLoaderManagers;
			return nci;
		}

		[Sharpen.ImplementsInterface(@"android.content.ComponentCallbacks")]
		public virtual void onLowMemory()
		{
			mCalled = true;
			mFragments.dispatchLowMemory();
		}

		[Sharpen.ImplementsInterface(@"android.content.ComponentCallbacks2")]
		public virtual void onTrimMemory(int level)
		{
			mCalled = true;
			mFragments.dispatchTrimMemory(level);
		}

		public virtual android.app.FragmentManager getFragmentManager()
		{
			return mFragments;
		}

		internal virtual void invalidateFragmentIndex(int index)
		{
			if (mAllLoaderManagers != null)
			{
				android.app.LoaderManagerImpl lm = mAllLoaderManagers.get(index);
				if (lm != null && !lm.mRetaining)
				{
					lm.doDestroy();
					mAllLoaderManagers.remove(index);
				}
			}
		}

		public virtual void onAttachFragment(android.app.Fragment fragment)
		{
		}

		[System.ObsoleteAttribute(@"Use android.content.CursorLoader instead.")]
		public android.database.Cursor managedQuery(System.Uri uri, string[] projection, 
			string selection, string sortOrder)
		{
			android.database.Cursor c = getContentResolver().query(uri, projection, selection
				, null, sortOrder);
			if (c != null)
			{
				startManagingCursor(c);
			}
			return c;
		}

		[System.ObsoleteAttribute(@"Use android.content.CursorLoader instead.")]
		public android.database.Cursor managedQuery(System.Uri uri, string[] projection, 
			string selection, string[] selectionArgs, string sortOrder)
		{
			android.database.Cursor c = getContentResolver().query(uri, projection, selection
				, selectionArgs, sortOrder);
			if (c != null)
			{
				startManagingCursor(c);
			}
			return c;
		}

		[System.ObsoleteAttribute(@"Use the new android.content.CursorLoader class withLoaderManager instead; this is also available on older platforms through the Android compatibility package."
			)]
		public virtual void startManagingCursor(android.database.Cursor c)
		{
			lock (mManagedCursors)
			{
				mManagedCursors.add(new android.app.Activity.ManagedCursor(c));
			}
		}

		[System.ObsoleteAttribute(@"Use the new android.content.CursorLoader class withLoaderManager instead; this is also available on older platforms through the Android compatibility package."
			)]
		public virtual void stopManagingCursor(android.database.Cursor c)
		{
			lock (mManagedCursors)
			{
				int N = mManagedCursors.size();
				{
					for (int i = 0; i < N; i++)
					{
						android.app.Activity.ManagedCursor mc = mManagedCursors.get(i);
						if (mc.mCursor == c)
						{
							mManagedCursors.remove(i);
							break;
						}
					}
				}
			}
		}

		[System.ObsoleteAttribute(@"As of android.os.Build.VERSION_CODES.GINGERBREAD this is a no-op."
			)]
		public virtual void setPersistent(bool isPersistent)
		{
		}

		public virtual android.view.View findViewById(int id)
		{
			return getWindow().findViewById(id);
		}

		public virtual android.app.ActionBar getActionBar()
		{
			initActionBar();
			return mActionBar;
		}

		private void initActionBar()
		{
			android.view.Window window = getWindow();
			window.getDecorView();
			if (isChild() || !window.hasFeature(android.view.Window.FEATURE_ACTION_BAR) || mActionBar
				 != null)
			{
				return;
			}
			mActionBar = new android.app.@internal.ActionBarImpl(this);
		}

		public virtual void setContentView(int layoutResID)
		{
			getWindow().setContentView(layoutResID);
			initActionBar();
		}

		public virtual void setContentView(android.view.View view)
		{
			getWindow().setContentView(view);
			initActionBar();
		}

		public virtual void setContentView(android.view.View view, android.view.ViewGroup
			.LayoutParams @params)
		{
			getWindow().setContentView(view, @params);
			initActionBar();
		}

		public virtual void addContentView(android.view.View view, android.view.ViewGroup
			.LayoutParams @params)
		{
			getWindow().addContentView(view, @params);
			initActionBar();
		}

		public virtual void setFinishOnTouchOutside(bool finish_1)
		{
			mWindow.setCloseOnTouchOutside(finish_1);
		}

		public const int DEFAULT_KEYS_DISABLE = 0;

		public const int DEFAULT_KEYS_DIALER = 1;

		public const int DEFAULT_KEYS_SHORTCUT = 2;

		public const int DEFAULT_KEYS_SEARCH_LOCAL = 3;

		public const int DEFAULT_KEYS_SEARCH_GLOBAL = 4;

		public void setDefaultKeyMode(int mode)
		{
			mDefaultKeyMode = mode;
			switch (mode)
			{
				case DEFAULT_KEYS_DISABLE:
				case DEFAULT_KEYS_SHORTCUT:
				{
					mDefaultKeySsb = null;
					break;
				}

				case DEFAULT_KEYS_DIALER:
				case DEFAULT_KEYS_SEARCH_LOCAL:
				case DEFAULT_KEYS_SEARCH_GLOBAL:
				{
					mDefaultKeySsb = new android.text.SpannableStringBuilder();
					android.text.Selection.setSelection(mDefaultKeySsb, 0);
					break;
				}

				default:
				{
					throw new System.ArgumentException();
				}
			}
		}

		[Sharpen.ImplementsInterface(@"android.view.KeyEvent.Callback")]
		public virtual bool onKeyDown(int keyCode, android.view.KeyEvent @event)
		{
			if (keyCode == android.view.KeyEvent.KEYCODE_BACK)
			{
				if (getApplicationInfo().targetSdkVersion >= android.os.Build.VERSION_CODES.ECLAIR)
				{
					@event.startTracking();
				}
				else
				{
					onBackPressed();
				}
				return true;
			}
			if (mDefaultKeyMode == DEFAULT_KEYS_DISABLE)
			{
				return false;
			}
			else
			{
				if (mDefaultKeyMode == DEFAULT_KEYS_SHORTCUT)
				{
					if (getWindow().performPanelShortcut(android.view.Window.FEATURE_OPTIONS_PANEL, keyCode
						, @event, android.view.MenuClass.FLAG_ALWAYS_PERFORM_CLOSE))
					{
						return true;
					}
					return false;
				}
				else
				{
					bool clearSpannable = false;
					bool handled;
					if ((@event.getRepeatCount() != 0) || @event.isSystem())
					{
						clearSpannable = true;
						handled = false;
					}
					else
					{
						handled = android.text.method.TextKeyListener.getInstance().onKeyDown(null, mDefaultKeySsb
							, keyCode, @event);
						if (handled && mDefaultKeySsb.Length > 0)
						{
							string str = mDefaultKeySsb.ToString();
							clearSpannable = true;
							switch (mDefaultKeyMode)
							{
								case DEFAULT_KEYS_DIALER:
								{
									android.content.Intent intent = new android.content.Intent(android.content.Intent
										.ACTION_DIAL, Sharpen.Util.ParseUri("tel:" + str));
									intent.addFlags(android.content.Intent.FLAG_ACTIVITY_NEW_TASK);
									startActivity(intent);
									break;
								}

								case DEFAULT_KEYS_SEARCH_LOCAL:
								{
									startSearch(str, false, null, false);
									break;
								}

								case DEFAULT_KEYS_SEARCH_GLOBAL:
								{
									startSearch(str, false, null, true);
									break;
								}
							}
						}
					}
					if (clearSpannable)
					{
						mDefaultKeySsb.clear();
						mDefaultKeySsb.clearSpans();
						android.text.Selection.setSelection(mDefaultKeySsb, 0);
					}
					return handled;
				}
			}
		}

		[Sharpen.ImplementsInterface(@"android.view.KeyEvent.Callback")]
		public virtual bool onKeyLongPress(int keyCode, android.view.KeyEvent @event)
		{
			return false;
		}

		[Sharpen.ImplementsInterface(@"android.view.KeyEvent.Callback")]
		public virtual bool onKeyUp(int keyCode, android.view.KeyEvent @event)
		{
			if (getApplicationInfo().targetSdkVersion >= android.os.Build.VERSION_CODES.ECLAIR)
			{
				if (keyCode == android.view.KeyEvent.KEYCODE_BACK && @event.isTracking() && !@event
					.isCanceled())
				{
					onBackPressed();
					return true;
				}
			}
			return false;
		}

		[Sharpen.ImplementsInterface(@"android.view.KeyEvent.Callback")]
		public virtual bool onKeyMultiple(int keyCode, int repeatCount, android.view.KeyEvent
			 @event)
		{
			return false;
		}

		public virtual void onBackPressed()
		{
			if (!mFragments.popBackStackImmediate())
			{
				finish();
			}
		}

		public virtual bool onKeyShortcut(int keyCode, android.view.KeyEvent @event)
		{
			return false;
		}

		public virtual bool onTouchEvent(android.view.MotionEvent @event)
		{
			if (mWindow.shouldCloseOnTouch(this, @event))
			{
				finish();
				return true;
			}
			return false;
		}

		public virtual bool onTrackballEvent(android.view.MotionEvent @event)
		{
			return false;
		}

		public virtual bool onGenericMotionEvent(android.view.MotionEvent @event)
		{
			return false;
		}

		public virtual void onUserInteraction()
		{
		}

		[Sharpen.ImplementsInterface(@"android.view.Window.Callback")]
		public virtual void onWindowAttributesChanged(android.view.WindowManagerClass.LayoutParams
			 @params)
		{
			if (mParent == null)
			{
				android.view.View decor = mDecor;
				if (decor != null && decor.getParent() != null)
				{
					getWindowManager().updateViewLayout(decor, @params);
				}
			}
		}

		[Sharpen.ImplementsInterface(@"android.view.Window.Callback")]
		public virtual void onContentChanged()
		{
		}

		[Sharpen.ImplementsInterface(@"android.view.Window.Callback")]
		public virtual void onWindowFocusChanged(bool hasFocus)
		{
		}

		[Sharpen.ImplementsInterface(@"android.view.Window.Callback")]
		public virtual void onAttachedToWindow()
		{
		}

		[Sharpen.ImplementsInterface(@"android.view.Window.Callback")]
		public virtual void onDetachedFromWindow()
		{
		}

		public virtual bool hasWindowFocus()
		{
			android.view.Window w = getWindow();
			if (w != null)
			{
				android.view.View d = w.getDecorView();
				if (d != null)
				{
					return d.hasWindowFocus();
				}
			}
			return false;
		}

		[Sharpen.ImplementsInterface(@"android.view.Window.Callback")]
		public virtual bool dispatchKeyEvent(android.view.KeyEvent @event)
		{
			onUserInteraction();
			android.view.Window win = getWindow();
			if (win.superDispatchKeyEvent(@event))
			{
				return true;
			}
			android.view.View decor = mDecor;
			if (decor == null)
			{
				decor = win.getDecorView();
			}
			return @event.dispatch(this, decor != null ? decor.getKeyDispatcherState() : null
				, this);
		}

		[Sharpen.ImplementsInterface(@"android.view.Window.Callback")]
		public virtual bool dispatchKeyShortcutEvent(android.view.KeyEvent @event)
		{
			onUserInteraction();
			if (getWindow().superDispatchKeyShortcutEvent(@event))
			{
				return true;
			}
			return onKeyShortcut(@event.getKeyCode(), @event);
		}

		[Sharpen.ImplementsInterface(@"android.view.Window.Callback")]
		public virtual bool dispatchTouchEvent(android.view.MotionEvent ev)
		{
			if (ev.getAction() == android.view.MotionEvent.ACTION_DOWN)
			{
				onUserInteraction();
			}
			if (getWindow().superDispatchTouchEvent(ev))
			{
				return true;
			}
			return onTouchEvent(ev);
		}

		[Sharpen.ImplementsInterface(@"android.view.Window.Callback")]
		public virtual bool dispatchTrackballEvent(android.view.MotionEvent ev)
		{
			onUserInteraction();
			if (getWindow().superDispatchTrackballEvent(ev))
			{
				return true;
			}
			return onTrackballEvent(ev);
		}

		[Sharpen.ImplementsInterface(@"android.view.Window.Callback")]
		public virtual bool dispatchGenericMotionEvent(android.view.MotionEvent ev)
		{
			onUserInteraction();
			if (getWindow().superDispatchGenericMotionEvent(ev))
			{
				return true;
			}
			return onGenericMotionEvent(ev);
		}

		[Sharpen.ImplementsInterface(@"android.view.Window.Callback")]
		public virtual bool dispatchPopulateAccessibilityEvent(android.view.accessibility.AccessibilityEvent
			 @event)
		{
			@event.setClassName(java.lang.CharSequenceProxy.Wrap(GetType().FullName));
			@event.setPackageName(java.lang.CharSequenceProxy.Wrap(getPackageName()));
			android.view.ViewGroup.LayoutParams @params = getWindow().getAttributes();
			bool isFullScreen = (@params.width == android.view.ViewGroup.LayoutParams.MATCH_PARENT
				) && (@params.height == android.view.ViewGroup.LayoutParams.MATCH_PARENT);
			@event.setFullScreen(isFullScreen);
			java.lang.CharSequence title = getTitle();
			if (!android.text.TextUtils.isEmpty(title))
			{
				@event.getText().add(title);
			}
			return true;
		}

		[Sharpen.ImplementsInterface(@"android.view.Window.Callback")]
		public virtual android.view.View onCreatePanelView(int featureId)
		{
			return null;
		}

		[Sharpen.ImplementsInterface(@"android.view.Window.Callback")]
		public virtual bool onCreatePanelMenu(int featureId, android.view.Menu menu)
		{
			if (featureId == android.view.Window.FEATURE_OPTIONS_PANEL)
			{
				bool show = onCreateOptionsMenu(menu);
				show |= mFragments.dispatchCreateOptionsMenu(menu, getMenuInflater());
				return show;
			}
			return false;
		}

		[Sharpen.ImplementsInterface(@"android.view.Window.Callback")]
		public virtual bool onPreparePanel(int featureId, android.view.View view, android.view.Menu
			 menu)
		{
			if (featureId == android.view.Window.FEATURE_OPTIONS_PANEL && menu != null)
			{
				bool goforit = onPrepareOptionsMenu(menu);
				goforit |= mFragments.dispatchPrepareOptionsMenu(menu);
				return goforit && menu.hasVisibleItems();
			}
			return true;
		}

		[Sharpen.ImplementsInterface(@"android.view.Window.Callback")]
		public virtual bool onMenuOpened(int featureId, android.view.Menu menu)
		{
			if (featureId == android.view.Window.FEATURE_ACTION_BAR)
			{
				initActionBar();
				if (mActionBar != null)
				{
					mActionBar.dispatchMenuVisibilityChanged(true);
				}
				else
				{
					android.util.Log.e(TAG, "Tried to open action bar menu with no action bar");
				}
			}
			return true;
		}

		[Sharpen.ImplementsInterface(@"android.view.Window.Callback")]
		public virtual bool onMenuItemSelected(int featureId, android.view.MenuItem item)
		{
			switch (featureId)
			{
				case android.view.Window.FEATURE_OPTIONS_PANEL:
				{
					android.util.EventLog.writeEvent(50000, 0, item.getTitleCondensed());
					if (onOptionsItemSelected(item))
					{
						return true;
					}
					return mFragments.dispatchOptionsItemSelected(item);
				}

				case android.view.Window.FEATURE_CONTEXT_MENU:
				{
					android.util.EventLog.writeEvent(50000, 1, item.getTitleCondensed());
					if (onContextItemSelected(item))
					{
						return true;
					}
					return mFragments.dispatchContextItemSelected(item);
				}

				default:
				{
					return false;
				}
			}
		}

		[Sharpen.ImplementsInterface(@"android.view.Window.Callback")]
		public virtual void onPanelClosed(int featureId, android.view.Menu menu)
		{
			switch (featureId)
			{
				case android.view.Window.FEATURE_OPTIONS_PANEL:
				{
					mFragments.dispatchOptionsMenuClosed(menu);
					onOptionsMenuClosed(menu);
					break;
				}

				case android.view.Window.FEATURE_CONTEXT_MENU:
				{
					onContextMenuClosed(menu);
					break;
				}

				case android.view.Window.FEATURE_ACTION_BAR:
				{
					initActionBar();
					mActionBar.dispatchMenuVisibilityChanged(false);
					break;
				}
			}
		}

		public virtual void invalidateOptionsMenu()
		{
			mWindow.invalidatePanelMenu(android.view.Window.FEATURE_OPTIONS_PANEL);
		}

		public virtual bool onCreateOptionsMenu(android.view.Menu menu)
		{
			if (mParent != null)
			{
				return mParent.onCreateOptionsMenu(menu);
			}
			return true;
		}

		public virtual bool onPrepareOptionsMenu(android.view.Menu menu)
		{
			if (mParent != null)
			{
				return mParent.onPrepareOptionsMenu(menu);
			}
			return true;
		}

		public virtual bool onOptionsItemSelected(android.view.MenuItem item)
		{
			if (mParent != null)
			{
				return mParent.onOptionsItemSelected(item);
			}
			return false;
		}

		public virtual void onOptionsMenuClosed(android.view.Menu menu)
		{
			if (mParent != null)
			{
				mParent.onOptionsMenuClosed(menu);
			}
		}

		public virtual void openOptionsMenu()
		{
			mWindow.openPanel(android.view.Window.FEATURE_OPTIONS_PANEL, null);
		}

		public virtual void closeOptionsMenu()
		{
			mWindow.closePanel(android.view.Window.FEATURE_OPTIONS_PANEL);
		}

		[Sharpen.ImplementsInterface(@"android.view.View.OnCreateContextMenuListener")]
		public virtual void onCreateContextMenu(android.view.ContextMenu menu, android.view.View
			 v, android.view.ContextMenuClass.ContextMenuInfo menuInfo)
		{
		}

		public virtual void registerForContextMenu(android.view.View view)
		{
			view.setOnCreateContextMenuListener(this);
		}

		public virtual void unregisterForContextMenu(android.view.View view)
		{
			view.setOnCreateContextMenuListener(null);
		}

		public virtual void openContextMenu(android.view.View view)
		{
			view.showContextMenu();
		}

		public virtual void closeContextMenu()
		{
			mWindow.closePanel(android.view.Window.FEATURE_CONTEXT_MENU);
		}

		public virtual bool onContextItemSelected(android.view.MenuItem item)
		{
			if (mParent != null)
			{
				return mParent.onContextItemSelected(item);
			}
			return false;
		}

		public virtual void onContextMenuClosed(android.view.Menu menu)
		{
			if (mParent != null)
			{
				mParent.onContextMenuClosed(menu);
			}
		}

		[System.ObsoleteAttribute(@"Old no-arguments version of onCreateDialog(int, android.os.Bundle) ."
			)]
		protected internal virtual android.app.Dialog onCreateDialog(int id)
		{
			return null;
		}

		[System.ObsoleteAttribute(@"Use the new DialogFragment class withFragmentManager instead; this is also available on older platforms through the Android compatibility package."
			)]
		protected internal virtual android.app.Dialog onCreateDialog(int id, android.os.Bundle
			 args)
		{
			return onCreateDialog(id);
		}

		[System.ObsoleteAttribute(@"Old no-arguments version ofonPrepareDialog(int, Dialog, android.os.Bundle) ."
			)]
		protected internal virtual void onPrepareDialog(int id, android.app.Dialog dialog
			)
		{
			dialog.setOwnerActivity(this);
		}

		[System.ObsoleteAttribute(@"Use the new DialogFragment class withFragmentManager instead; this is also available on older platforms through the Android compatibility package."
			)]
		protected internal virtual void onPrepareDialog(int id, android.app.Dialog dialog
			, android.os.Bundle args)
		{
			onPrepareDialog(id, dialog);
		}

		[System.ObsoleteAttribute(@"Use the new DialogFragment class withFragmentManager instead; this is also available on older platforms through the Android compatibility package."
			)]
		public void showDialog(int id)
		{
			showDialog(id, null);
		}

		[System.ObsoleteAttribute(@"Use the new DialogFragment class withFragmentManager instead; this is also available on older platforms through the Android compatibility package."
			)]
		public bool showDialog(int id, android.os.Bundle args)
		{
			if (mManagedDialogs == null)
			{
				mManagedDialogs = new android.util.SparseArray<android.app.Activity.ManagedDialog
					>();
			}
			android.app.Activity.ManagedDialog md = mManagedDialogs.get(id);
			if (md == null)
			{
				md = new android.app.Activity.ManagedDialog();
				md.mDialog = createDialog(id, null, args);
				if (md.mDialog == null)
				{
					return false;
				}
				mManagedDialogs.put(id, md);
			}
			md.mArgs = args;
			onPrepareDialog(id, md.mDialog, args);
			md.mDialog.show();
			return true;
		}

		[System.ObsoleteAttribute(@"Use the new DialogFragment class withFragmentManager instead; this is also available on older platforms through the Android compatibility package."
			)]
		public void dismissDialog(int id)
		{
			if (mManagedDialogs == null)
			{
				throw missingDialog(id);
			}
			android.app.Activity.ManagedDialog md = mManagedDialogs.get(id);
			if (md == null)
			{
				throw missingDialog(id);
			}
			md.mDialog.dismiss();
		}

		private System.ArgumentException missingDialog(int id)
		{
			return new System.ArgumentException("no dialog with id " + id + " was ever " + "shown via Activity#showDialog"
				);
		}

		[System.ObsoleteAttribute(@"Use the new DialogFragment class withFragmentManager instead; this is also available on older platforms through the Android compatibility package."
			)]
		public void removeDialog(int id)
		{
			if (mManagedDialogs != null)
			{
				android.app.Activity.ManagedDialog md = mManagedDialogs.get(id);
				if (md != null)
				{
					md.mDialog.dismiss();
					mManagedDialogs.remove(id);
				}
			}
		}

		[Sharpen.ImplementsInterface(@"android.view.Window.Callback")]
		public virtual bool onSearchRequested()
		{
			startSearch(null, false, null, false);
			return true;
		}

		public virtual void startSearch(string initialQuery, bool selectInitialQuery, android.os.Bundle
			 appSearchData, bool globalSearch)
		{
			ensureSearchManager();
			mSearchManager.startSearch(initialQuery, selectInitialQuery, getComponentName(), 
				appSearchData, globalSearch);
		}

		public virtual void triggerSearch(string query, android.os.Bundle appSearchData)
		{
			ensureSearchManager();
			mSearchManager.triggerSearch(query, getComponentName(), appSearchData);
		}

		public virtual void takeKeyEvents(bool get)
		{
			getWindow().takeKeyEvents(get);
		}

		public bool requestWindowFeature(int featureId)
		{
			return getWindow().requestFeature(featureId);
		}

		public void setFeatureDrawableResource(int featureId, int resId)
		{
			getWindow().setFeatureDrawableResource(featureId, resId);
		}

		public void setFeatureDrawableUri(int featureId, System.Uri uri)
		{
			getWindow().setFeatureDrawableUri(featureId, uri);
		}

		public void setFeatureDrawable(int featureId, android.graphics.drawable.Drawable 
			drawable)
		{
			getWindow().setFeatureDrawable(featureId, drawable);
		}

		public void setFeatureDrawableAlpha(int featureId, int alpha)
		{
			getWindow().setFeatureDrawableAlpha(featureId, alpha);
		}

		public virtual android.view.LayoutInflater getLayoutInflater()
		{
			return getWindow().getLayoutInflater();
		}

		public virtual android.view.MenuInflater getMenuInflater()
		{
			if (mMenuInflater == null)
			{
				initActionBar();
				if (mActionBar != null)
				{
					mMenuInflater = new android.view.MenuInflater(mActionBar.getThemedContext());
				}
				else
				{
					mMenuInflater = new android.view.MenuInflater(this);
				}
			}
			return mMenuInflater;
		}

		[Sharpen.OverridesMethod(@"android.view.ContextThemeWrapper")]
		protected internal override void onApplyThemeResource(android.content.res.Resources
			.Theme theme, int resid, bool first)
		{
			if (mParent == null)
			{
				base.onApplyThemeResource(theme, resid, first);
			}
			else
			{
				try
				{
					theme.setTo(mParent.getTheme());
				}
				catch (System.Exception)
				{
				}
				theme.applyStyle(resid, false);
			}
		}

		public virtual void startActivityForResult(android.content.Intent intent, int requestCode
			)
		{
			if (mParent == null)
			{
				android.app.Instrumentation.ActivityResult ar = mInstrumentation.execStartActivity
					(this, mMainThread.getApplicationThread(), mToken, this, intent, requestCode);
				if (ar != null)
				{
					mMainThread.sendActivityResult(mToken, mEmbeddedID, requestCode, ar.getResultCode
						(), ar.getResultData());
				}
				if (requestCode >= 0)
				{
					mStartedActivity = true;
				}
			}
			else
			{
				mParent.startActivityFromChild(this, intent, requestCode);
			}
		}

		public virtual void startIntentSenderForResult(android.content.IntentSender intent
			, int requestCode, android.content.Intent fillInIntent, int flagsMask, int flagsValues
			, int extraFlags)
		{
			if (mParent == null)
			{
				startIntentSenderForResultInner(intent, requestCode, fillInIntent, flagsMask, flagsValues
					, this);
			}
			else
			{
				mParent.startIntentSenderFromChild(this, intent, requestCode, fillInIntent, flagsMask
					, flagsValues, extraFlags);
			}
		}

		private void startIntentSenderForResultInner(android.content.IntentSender intent, 
			int requestCode, android.content.Intent fillInIntent, int flagsMask, int flagsValues
			, android.app.Activity activity)
		{
			try
			{
				string resolvedType = null;
				if (fillInIntent != null)
				{
					fillInIntent.setAllowFds(false);
					resolvedType = fillInIntent.resolveTypeIfNeeded(getContentResolver());
				}
				int result = android.app.ActivityManagerNative.getDefault().startActivityIntentSender
					(mMainThread.getApplicationThread(), intent, fillInIntent, resolvedType, mToken, 
					activity.mEmbeddedID, requestCode, flagsMask, flagsValues);
				if (result == android.app.IActivityManagerClass.START_CANCELED)
				{
					throw new android.content.IntentSender.SendIntentException();
				}
				android.app.Instrumentation.checkStartActivityResult(result, null);
			}
			catch (android.os.RemoteException)
			{
			}
			if (requestCode >= 0)
			{
				mStartedActivity = true;
			}
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void startActivity(android.content.Intent intent)
		{
			startActivityForResult(intent, -1);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void startActivities(android.content.Intent[] intents)
		{
			mInstrumentation.execStartActivities(this, mMainThread.getApplicationThread(), mToken
				, this, intents);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void startIntentSender(android.content.IntentSender intent, android.content.Intent
			 fillInIntent, int flagsMask, int flagsValues, int extraFlags)
		{
			startIntentSenderForResult(intent, -1, fillInIntent, flagsMask, flagsValues, extraFlags
				);
		}

		public virtual bool startActivityIfNeeded(android.content.Intent intent, int requestCode
			)
		{
			if (mParent == null)
			{
				int result = android.app.IActivityManagerClass.START_RETURN_INTENT_TO_CALLER;
				try
				{
					intent.setAllowFds(false);
					result = android.app.ActivityManagerNative.getDefault().startActivity(mMainThread
						.getApplicationThread(), intent, intent.resolveTypeIfNeeded(getContentResolver()
						), null, 0, mToken, mEmbeddedID, requestCode, true, false, null, null, false);
				}
				catch (android.os.RemoteException)
				{
				}
				android.app.Instrumentation.checkStartActivityResult(result, intent);
				if (requestCode >= 0)
				{
					mStartedActivity = true;
				}
				return result != android.app.IActivityManagerClass.START_RETURN_INTENT_TO_CALLER;
			}
			throw new System.NotSupportedException("startActivityIfNeeded can only be called from a top-level activity"
				);
		}

		public virtual bool startNextMatchingActivity(android.content.Intent intent)
		{
			if (mParent == null)
			{
				try
				{
					intent.setAllowFds(false);
					return android.app.ActivityManagerNative.getDefault().startNextMatchingActivity(mToken
						, intent);
				}
				catch (android.os.RemoteException)
				{
				}
				return false;
			}
			throw new System.NotSupportedException("startNextMatchingActivity can only be called from a top-level activity"
				);
		}

		public virtual void startActivityFromChild(android.app.Activity child, android.content.Intent
			 intent, int requestCode)
		{
			android.app.Instrumentation.ActivityResult ar = mInstrumentation.execStartActivity
				(this, mMainThread.getApplicationThread(), mToken, child, intent, requestCode);
			if (ar != null)
			{
				mMainThread.sendActivityResult(mToken, child.mEmbeddedID, requestCode, ar.getResultCode
					(), ar.getResultData());
			}
		}

		public virtual void startActivityFromFragment(android.app.Fragment fragment, android.content.Intent
			 intent, int requestCode)
		{
			android.app.Instrumentation.ActivityResult ar = mInstrumentation.execStartActivity
				(this, mMainThread.getApplicationThread(), mToken, fragment, intent, requestCode
				);
			if (ar != null)
			{
				mMainThread.sendActivityResult(mToken, fragment.mWho, requestCode, ar.getResultCode
					(), ar.getResultData());
			}
		}

		public virtual void startIntentSenderFromChild(android.app.Activity child, android.content.IntentSender
			 intent, int requestCode, android.content.Intent fillInIntent, int flagsMask, int
			 flagsValues, int extraFlags)
		{
			startIntentSenderForResultInner(intent, requestCode, fillInIntent, flagsMask, flagsValues
				, child);
		}

		public virtual void overridePendingTransition(int enterAnim, int exitAnim)
		{
			try
			{
				android.app.ActivityManagerNative.getDefault().overridePendingTransition(mToken, 
					getPackageName(), enterAnim, exitAnim);
			}
			catch (android.os.RemoteException)
			{
			}
		}

		public void setResult(int resultCode)
		{
			lock (this)
			{
				mResultCode = resultCode;
				mResultData = null;
			}
		}

		public void setResult(int resultCode, android.content.Intent data)
		{
			lock (this)
			{
				mResultCode = resultCode;
				mResultData = data;
			}
		}

		public virtual string getCallingPackage()
		{
			try
			{
				return android.app.ActivityManagerNative.getDefault().getCallingPackage(mToken);
			}
			catch (android.os.RemoteException)
			{
				return null;
			}
		}

		public virtual android.content.ComponentName getCallingActivity()
		{
			try
			{
				return android.app.ActivityManagerNative.getDefault().getCallingActivity(mToken);
			}
			catch (android.os.RemoteException)
			{
				return null;
			}
		}

		public virtual void setVisible(bool visible)
		{
			if (mVisibleFromClient != visible)
			{
				mVisibleFromClient = visible;
				if (mVisibleFromServer)
				{
					if (visible)
					{
						makeVisible();
					}
					else
					{
						mDecor.setVisibility(android.view.View.INVISIBLE);
					}
				}
			}
		}

		internal virtual void makeVisible()
		{
			if (!mWindowAdded)
			{
				android.view.ViewManager wm = getWindowManager();
				wm.addView(mDecor, getWindow().getAttributes());
				mWindowAdded = true;
			}
			mDecor.setVisibility(android.view.View.VISIBLE);
		}

		public virtual bool isFinishing()
		{
			return mFinished;
		}

		public virtual bool isChangingConfigurations()
		{
			return mChangingConfigurations;
		}

		public virtual void recreate()
		{
			if (mParent != null)
			{
				throw new System.InvalidOperationException("Can only be called on top-level activity"
					);
			}
			if (android.os.Looper.myLooper() != mMainThread.getLooper())
			{
				throw new System.InvalidOperationException("Must be called from main thread");
			}
			mMainThread.requestRelaunchActivity(mToken, null, null, 0, false, null, false);
		}

		public virtual void finishFromChild(android.app.Activity child)
		{
			finish();
		}

		public virtual void finishActivity(int requestCode)
		{
			if (mParent == null)
			{
				try
				{
					android.app.ActivityManagerNative.getDefault().finishSubActivity(mToken, mEmbeddedID
						, requestCode);
				}
				catch (android.os.RemoteException)
				{
				}
			}
			else
			{
				mParent.finishActivityFromChild(this, requestCode);
			}
		}

		public virtual void finishActivityFromChild(android.app.Activity child, int requestCode
			)
		{
			try
			{
				android.app.ActivityManagerNative.getDefault().finishSubActivity(mToken, child.mEmbeddedID
					, requestCode);
			}
			catch (android.os.RemoteException)
			{
			}
		}

		protected internal virtual void onActivityResult(int requestCode, int resultCode, 
			android.content.Intent data)
		{
		}

		public virtual android.app.PendingIntent createPendingResult(int requestCode, android.content.Intent
			 data, int flags)
		{
			string packageName = getPackageName();
			try
			{
				data.setAllowFds(false);
				android.content.IIntentSender target = android.app.ActivityManagerNative.getDefault
					().getIntentSender(android.app.IActivityManagerClass.INTENT_SENDER_ACTIVITY_RESULT
					, packageName, mParent == null ? mToken : mParent.mToken, mEmbeddedID, requestCode
					, new android.content.Intent[] { data }, null, flags);
				return target != null ? new android.app.PendingIntent(target) : null;
			}
			catch (android.os.RemoteException)
			{
			}
			return null;
		}

		public virtual void setRequestedOrientation(int requestedOrientation)
		{
			if (mParent == null)
			{
				try
				{
					android.app.ActivityManagerNative.getDefault().setRequestedOrientation(mToken, requestedOrientation
						);
				}
				catch (android.os.RemoteException)
				{
				}
			}
			else
			{
				mParent.setRequestedOrientation(requestedOrientation);
			}
		}

		public virtual int getRequestedOrientation()
		{
			if (mParent == null)
			{
				try
				{
					return android.app.ActivityManagerNative.getDefault().getRequestedOrientation(mToken
						);
				}
				catch (android.os.RemoteException)
				{
				}
			}
			else
			{
				return mParent.getRequestedOrientation();
			}
			return android.content.pm.ActivityInfo.SCREEN_ORIENTATION_UNSPECIFIED;
		}

		public virtual int getTaskId()
		{
			try
			{
				return android.app.ActivityManagerNative.getDefault().getTaskForActivity(mToken, 
					false);
			}
			catch (android.os.RemoteException)
			{
				return -1;
			}
		}

		public virtual bool isTaskRoot()
		{
			try
			{
				return android.app.ActivityManagerNative.getDefault().getTaskForActivity(mToken, 
					true) >= 0;
			}
			catch (android.os.RemoteException)
			{
				return false;
			}
		}

		public virtual bool moveTaskToBack(bool nonRoot)
		{
			try
			{
				return android.app.ActivityManagerNative.getDefault().moveActivityTaskToBack(mToken
					, nonRoot);
			}
			catch (android.os.RemoteException)
			{
			}
			return false;
		}

		public virtual string getLocalClassName()
		{
			string pkg = getPackageName();
			string cls = mComponent.getClassName();
			int packageLen = pkg.Length;
			if (!cls.StartsWith(pkg) || cls.Length <= packageLen || cls[packageLen] != '.')
			{
				return cls;
			}
			return Sharpen.StringHelper.Substring(cls, packageLen + 1);
		}

		public virtual android.content.ComponentName getComponentName()
		{
			return mComponent;
		}

		public virtual android.content.SharedPreferences getPreferences(int mode)
		{
			return getSharedPreferences(getLocalClassName(), mode);
		}

		private void ensureSearchManager()
		{
			if (mSearchManager != null)
			{
				return;
			}
			mSearchManager = new android.app.SearchManager(this, null);
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override object getSystemService(string name)
		{
			if (getBaseContext() == null)
			{
				throw new System.InvalidOperationException("System services not available to Activities before onCreate()"
					);
			}
			if (WINDOW_SERVICE.Equals(name))
			{
				return mWindowManager;
			}
			else
			{
				if (SEARCH_SERVICE.Equals(name))
				{
					ensureSearchManager();
					return mSearchManager;
				}
			}
			return base.getSystemService(name);
		}

		public virtual void setTitle(java.lang.CharSequence title)
		{
			mTitle = title;
			onTitleChanged(title, mTitleColor);
			if (mParent != null)
			{
				mParent.onChildTitleChanged(this, title);
			}
		}

		public virtual void setTitle(int titleId)
		{
			setTitle(getText(titleId));
		}

		public virtual void setTitleColor(int textColor)
		{
			mTitleColor = textColor;
			onTitleChanged(mTitle, textColor);
		}

		public java.lang.CharSequence getTitle()
		{
			return mTitle;
		}

		public int getTitleColor()
		{
			return mTitleColor;
		}

		protected internal virtual void onTitleChanged(java.lang.CharSequence title, int 
			color)
		{
			if (mTitleReady)
			{
				android.view.Window win = getWindow();
				if (win != null)
				{
					win.setTitle(title);
					if (color != 0)
					{
						win.setTitleColor(color);
					}
				}
			}
		}

		protected internal virtual void onChildTitleChanged(android.app.Activity childActivity
			, java.lang.CharSequence title)
		{
		}

		public void setProgressBarVisibility(bool visible)
		{
			getWindow().setFeatureInt(android.view.Window.FEATURE_PROGRESS, visible ? android.view.Window
				.PROGRESS_VISIBILITY_ON : android.view.Window.PROGRESS_VISIBILITY_OFF);
		}

		public void setProgressBarIndeterminateVisibility(bool visible)
		{
			getWindow().setFeatureInt(android.view.Window.FEATURE_INDETERMINATE_PROGRESS, visible
				 ? android.view.Window.PROGRESS_VISIBILITY_ON : android.view.Window.PROGRESS_VISIBILITY_OFF
				);
		}

		public void setProgressBarIndeterminate(bool indeterminate)
		{
			getWindow().setFeatureInt(android.view.Window.FEATURE_PROGRESS, indeterminate ? android.view.Window
				.PROGRESS_INDETERMINATE_ON : android.view.Window.PROGRESS_INDETERMINATE_OFF);
		}

		public void setProgress(int progress)
		{
			getWindow().setFeatureInt(android.view.Window.FEATURE_PROGRESS, progress + android.view.Window
				.PROGRESS_START);
		}

		public void setSecondaryProgress(int secondaryProgress)
		{
			getWindow().setFeatureInt(android.view.Window.FEATURE_PROGRESS, secondaryProgress
				 + android.view.Window.PROGRESS_SECONDARY_START);
		}

		public void setVolumeControlStream(int streamType)
		{
			getWindow().setVolumeControlStream(streamType);
		}

		public int getVolumeControlStream()
		{
			return getWindow().getVolumeControlStream();
		}

		public void runOnUiThread(java.lang.Runnable action)
		{
			if (java.lang.Thread.currentThread() != mUiThread)
			{
				mHandler.post(action);
			}
			else
			{
				action.run();
			}
		}

		[Sharpen.ImplementsInterface(@"android.view.LayoutInflater.Factory")]
		public virtual android.view.View onCreateView(string name, android.content.Context
			 context, android.util.AttributeSet attrs)
		{
			return null;
		}

		[Sharpen.ImplementsInterface(@"android.view.LayoutInflater.Factory2")]
		public virtual android.view.View onCreateView(android.view.View parent, string name
			, android.content.Context context, android.util.AttributeSet attrs)
		{
			if (!"fragment".Equals(name))
			{
				return onCreateView(name, context, attrs);
			}
			string fname = attrs.getAttributeValue(null, "class");
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.Fragment);
			if (fname == null)
			{
				fname = a.getString(android.@internal.R.styleable.Fragment_name);
			}
			int id = a.getResourceId(android.@internal.R.styleable.Fragment_id, android.view.View
				.NO_ID);
			string tag = a.getString(android.@internal.R.styleable.Fragment_tag);
			a.recycle();
			int containerId = parent != null ? parent.getId() : 0;
			if (containerId == android.view.View.NO_ID && id == android.view.View.NO_ID && tag
				 == null)
			{
				throw new System.ArgumentException(attrs.getPositionDescription() + ": Must specify unique android:id, android:tag, or have a parent with an id for "
					 + fname);
			}
			android.app.Fragment fragment = id != android.view.View.NO_ID ? mFragments.findFragmentById
				(id) : null;
			if (fragment == null && tag != null)
			{
				fragment = mFragments.findFragmentByTag(tag);
			}
			if (fragment == null && containerId != android.view.View.NO_ID)
			{
				fragment = mFragments.findFragmentById(containerId);
			}
			if (android.app.FragmentManagerImpl.DEBUG)
			{
				android.util.Log.v(TAG, "onCreateView: id=0x" + Sharpen.Util.IntToHexString(id) +
					 " fname=" + fname + " existing=" + fragment);
			}
			if (fragment == null)
			{
				fragment = android.app.Fragment.instantiate(this, fname);
				fragment.mFromLayout = true;
				fragment.mFragmentId = id != 0 ? id : containerId;
				fragment.mContainerId = containerId;
				fragment.mTag = tag;
				fragment.mInLayout = true;
				fragment.mFragmentManager = mFragments;
				fragment.onInflate(this, attrs, fragment.mSavedFragmentState);
				mFragments.addFragment(fragment, true);
			}
			else
			{
				if (fragment.mInLayout)
				{
					throw new System.ArgumentException(attrs.getPositionDescription() + ": Duplicate id 0x"
						 + Sharpen.Util.IntToHexString(id) + ", tag " + tag + ", or parent id 0x" + Sharpen.Util.IntToHexString
						(containerId) + " with another fragment for " + fname);
				}
				else
				{
					fragment.mInLayout = true;
					if (!fragment.mRetaining)
					{
						fragment.onInflate(this, attrs, fragment.mSavedFragmentState);
					}
					mFragments.moveToState(fragment);
				}
			}
			if (fragment.mView == null)
			{
				throw new System.InvalidOperationException("Fragment " + fname + " did not create a view."
					);
			}
			if (id != 0)
			{
				fragment.mView.setId(id);
			}
			if (fragment.mView.getTag() == null)
			{
				fragment.mView.setTag(tag);
			}
			return fragment.mView;
		}

		public virtual void dump(string prefix, java.io.FileDescriptor fd, java.io.PrintWriter
			 writer, string[] args)
		{
			writer.print(prefix);
			writer.print("Local Activity ");
			writer.print(Sharpen.Util.IntToHexString(Sharpen.Util.IdentityHashCode(this)));
			writer.println(" State:");
			string innerPrefix = prefix + "  ";
			writer.print(innerPrefix);
			writer.print("mResumed=");
			writer.print(mResumed);
			writer.print(" mStopped=");
			writer.print(mStopped);
			writer.print(" mFinished=");
			writer.println(mFinished);
			writer.print(innerPrefix);
			writer.print("mLoadersStarted=");
			writer.println(mLoadersStarted);
			writer.print(innerPrefix);
			writer.print("mChangingConfigurations=");
			writer.println(mChangingConfigurations);
			writer.print(innerPrefix);
			writer.print("mCurrentConfig=");
			writer.println(mCurrentConfig);
			if (mLoaderManager != null)
			{
				writer.print(prefix);
				writer.print("Loader Manager ");
				writer.print(Sharpen.Util.IntToHexString(Sharpen.Util.IdentityHashCode(mLoaderManager
					)));
				writer.println(":");
				mLoaderManager.dump(prefix + "  ", fd, writer, args);
			}
			mFragments.dump(prefix, fd, writer, args);
		}

		public virtual bool isImmersive()
		{
			try
			{
				return android.app.ActivityManagerNative.getDefault().isImmersive(mToken);
			}
			catch (android.os.RemoteException)
			{
				return false;
			}
		}

		public virtual void setImmersive(bool i)
		{
			try
			{
				android.app.ActivityManagerNative.getDefault().setImmersive(mToken, i);
			}
			catch (android.os.RemoteException)
			{
			}
		}

		public virtual android.view.ActionMode startActionMode(android.view.ActionMode.Callback
			 callback)
		{
			return mWindow.getDecorView().startActionMode(callback);
		}

		[Sharpen.ImplementsInterface(@"android.view.Window.Callback")]
		public virtual android.view.ActionMode onWindowStartingActionMode(android.view.ActionMode
			.Callback callback)
		{
			initActionBar();
			if (mActionBar != null)
			{
				return mActionBar.startActionMode(callback);
			}
			return null;
		}

		[Sharpen.ImplementsInterface(@"android.view.Window.Callback")]
		public virtual void onActionModeStarted(android.view.ActionMode mode)
		{
		}

		[Sharpen.ImplementsInterface(@"android.view.Window.Callback")]
		public virtual void onActionModeFinished(android.view.ActionMode mode)
		{
		}

		internal void setParent(android.app.Activity parent)
		{
			mParent = parent;
		}

		internal void attach(android.content.Context context, android.app.ActivityThread 
			aThread, android.app.Instrumentation instr, android.os.IBinder token, android.app.Application
			 application, android.content.Intent intent, android.content.pm.ActivityInfo info
			, java.lang.CharSequence title, android.app.Activity parent, string id, android.app.Activity
			.NonConfigurationInstances lastNonConfigurationInstances, android.content.res.Configuration
			 config)
		{
			attach(context, aThread, instr, token, 0, application, intent, info, title, parent
				, id, lastNonConfigurationInstances, config);
		}

		internal void attach(android.content.Context context, android.app.ActivityThread 
			aThread, android.app.Instrumentation instr, android.os.IBinder token, int ident, 
			android.app.Application application, android.content.Intent intent, android.content.pm.ActivityInfo
			 info, java.lang.CharSequence title, android.app.Activity parent, string id, android.app.Activity
			.NonConfigurationInstances lastNonConfigurationInstances, android.content.res.Configuration
			 config)
		{
			attachBaseContext(context);
			mFragments.attachActivity(this);
			mWindow = android.policy.@internal.PolicyManager.makeNewWindow(this);
			mWindow.setCallback(this);
			mWindow.getLayoutInflater().setPrivateFactory(this);
			if (info.softInputMode != android.view.WindowManagerClass.LayoutParams.SOFT_INPUT_STATE_UNSPECIFIED)
			{
				mWindow.setSoftInputMode(info.softInputMode);
			}
			if (info.uiOptions != 0)
			{
				mWindow.setUiOptions(info.uiOptions);
			}
			mUiThread = java.lang.Thread.currentThread();
			mMainThread = aThread;
			mInstrumentation = instr;
			mToken = token;
			mIdent = ident;
			mApplication = application;
			mIntent = intent;
			mComponent = intent.getComponent();
			mActivityInfo = info;
			mTitle = title;
			mParent = parent;
			mEmbeddedID = id;
			mLastNonConfigurationInstances = lastNonConfigurationInstances;
			mWindow.setWindowManager(null, mToken, mComponent.flattenToString(), (info.flags 
				& android.content.pm.ActivityInfo.FLAG_HARDWARE_ACCELERATED) != 0);
			if (mParent != null)
			{
				mWindow.setContainer(mParent.getWindow());
			}
			mWindowManager = mWindow.getWindowManager();
			mCurrentConfig = config;
		}

		internal android.os.IBinder getActivityToken()
		{
			return mParent != null ? mParent.getActivityToken() : mToken;
		}

		internal void performCreate(android.os.Bundle icicle)
		{
			onCreate(icicle);
			mVisibleFromClient = !mWindow.getWindowStyle().getBoolean(android.@internal.R.styleable
				.Window_windowNoDisplay, false);
			mFragments.dispatchActivityCreated();
		}

		internal void performStart()
		{
			mFragments.noteStateNotSaved();
			mCalled = false;
			mFragments.execPendingActions();
			mInstrumentation.callActivityOnStart(this);
			if (!mCalled)
			{
				throw new android.app.SuperNotCalledException("Activity " + mComponent.toShortString
					() + " did not call through to super.onStart()");
			}
			mFragments.dispatchStart();
			if (mAllLoaderManagers != null)
			{
				{
					for (int i = mAllLoaderManagers.size() - 1; i >= 0; i--)
					{
						android.app.LoaderManagerImpl lm = mAllLoaderManagers.valueAt(i);
						lm.finishRetain();
						lm.doReportStart();
					}
				}
			}
		}

		internal void performRestart()
		{
			mFragments.noteStateNotSaved();
			if (mStopped)
			{
				mStopped = false;
				if (mToken != null && mParent == null)
				{
					android.view.WindowManagerImpl.getDefault().setStoppedState(mToken, false);
				}
				lock (mManagedCursors)
				{
					int N = mManagedCursors.size();
					{
						for (int i = 0; i < N; i++)
						{
							android.app.Activity.ManagedCursor mc = mManagedCursors.get(i);
							if (mc.mReleased || mc.mUpdated)
							{
								if (!mc.mCursor.requery())
								{
									if (getApplicationInfo().targetSdkVersion >= android.os.Build.VERSION_CODES.ICE_CREAM_SANDWICH)
									{
										throw new System.InvalidOperationException("trying to requery an already closed cursor  "
											 + mc.mCursor);
									}
								}
								mc.mReleased = false;
								mc.mUpdated = false;
							}
						}
					}
				}
				mCalled = false;
				mInstrumentation.callActivityOnRestart(this);
				if (!mCalled)
				{
					throw new android.app.SuperNotCalledException("Activity " + mComponent.toShortString
						() + " did not call through to super.onRestart()");
				}
				performStart();
			}
		}

		internal void performResume()
		{
			performRestart();
			mFragments.execPendingActions();
			mLastNonConfigurationInstances = null;
			mCalled = false;
			mInstrumentation.callActivityOnResume(this);
			if (!mCalled)
			{
				throw new android.app.SuperNotCalledException("Activity " + mComponent.toShortString
					() + " did not call through to super.onResume()");
			}
			mCalled = false;
			mFragments.dispatchResume();
			mFragments.execPendingActions();
			onPostResume();
			if (!mCalled)
			{
				throw new android.app.SuperNotCalledException("Activity " + mComponent.toShortString
					() + " did not call through to super.onPostResume()");
			}
		}

		internal void performPause()
		{
			mFragments.dispatchPause();
			mCalled = false;
			onPause();
			mResumed = false;
			if (!mCalled && getApplicationInfo().targetSdkVersion >= android.os.Build.VERSION_CODES
				.GINGERBREAD)
			{
				throw new android.app.SuperNotCalledException("Activity " + mComponent.toShortString
					() + " did not call through to super.onPause()");
			}
			mResumed = false;
		}

		internal void performUserLeaving()
		{
			onUserInteraction();
			onUserLeaveHint();
		}

		internal void performStop()
		{
			if (mLoadersStarted)
			{
				mLoadersStarted = false;
				if (mLoaderManager != null)
				{
					if (!mChangingConfigurations)
					{
						mLoaderManager.doStop();
					}
					else
					{
						mLoaderManager.doRetain();
					}
				}
			}
			if (!mStopped)
			{
				if (mWindow != null)
				{
					mWindow.closeAllPanels();
				}
				if (mToken != null && mParent == null)
				{
					android.view.WindowManagerImpl.getDefault().setStoppedState(mToken, true);
				}
				mFragments.dispatchStop();
				mCalled = false;
				mInstrumentation.callActivityOnStop(this);
				if (!mCalled)
				{
					throw new android.app.SuperNotCalledException("Activity " + mComponent.toShortString
						() + " did not call through to super.onStop()");
				}
				lock (mManagedCursors)
				{
					int N = mManagedCursors.size();
					{
						for (int i = 0; i < N; i++)
						{
							android.app.Activity.ManagedCursor mc = mManagedCursors.get(i);
							if (!mc.mReleased)
							{
								mc.mCursor.deactivate();
								mc.mReleased = true;
							}
						}
					}
				}
				mStopped = true;
			}
			mResumed = false;
		}

		internal void performDestroy()
		{
			mWindow.destroy();
			mFragments.dispatchDestroy();
			onDestroy();
			if (mLoaderManager != null)
			{
				mLoaderManager.doDestroy();
			}
		}

		public bool isResumed()
		{
			return mResumed;
		}

		internal virtual void dispatchActivityResult(string who, int requestCode, int resultCode
			, android.content.Intent data)
		{
			if (false)
			{
				android.util.Log.v(TAG, "Dispatching result: who=" + who + ", reqCode=" + requestCode
					 + ", resCode=" + resultCode + ", data=" + data);
			}
			mFragments.noteStateNotSaved();
			if (who == null)
			{
				onActivityResult(requestCode, resultCode, data);
			}
			else
			{
				android.app.Fragment frag = mFragments.findFragmentByWho(who);
				if (frag != null)
				{
					frag.onActivityResult(requestCode, resultCode, data);
				}
			}
		}
	}
}

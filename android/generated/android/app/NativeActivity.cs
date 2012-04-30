using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	public class NativeActivity : android.app.Activity, android.view.SurfaceHolderClass
		.Callback2, android.view.InputQueue.Callback, android.view.ViewTreeObserver.OnGlobalLayoutListener
	{
		public const string META_DATA_LIB_NAME = "android.app.lib_name";

		public const string META_DATA_FUNC_NAME = "android.app.func_name";

		internal const string KEY_NATIVE_SAVED_STATE = "android:native_state";

		private android.app.NativeActivity.NativeContentView mNativeContentView;

		private android.view.inputmethod.InputMethodManager mIMM;

		private android.app.NativeActivity.InputMethodCallback mInputMethodCallback;

		private int mNativeHandle;

		private android.view.InputQueue mCurInputQueue;

		private android.view.SurfaceHolder mCurSurfaceHolder;

		internal readonly int[] mLocation = new int[2];

		internal int mLastContentX;

		internal int mLastContentY;

		internal int mLastContentWidth;

		internal int mLastContentHeight;

		private bool mDispatchingUnhandledKey;

		private bool mDestroyed;

		[Sharpen.Stub]
		private int loadNativeCode(string path, string funcname, android.os.MessageQueue 
			queue, string internalDataPath, string obbPath, string externalDataPath, int sdkVersion
			, android.content.res.AssetManager assetMgr, byte[] savedState)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void unloadNativeCode(int handle)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void onStartNative(int handle)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void onResumeNative(int handle)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private byte[] onSaveInstanceStateNative(int handle)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void onPauseNative(int handle)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void onStopNative(int handle)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void onConfigurationChangedNative(int handle)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void onLowMemoryNative(int handle)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void onWindowFocusChangedNative(int handle, bool focused)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void onSurfaceCreatedNative(int handle, android.view.Surface surface)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void onSurfaceChangedNative(int handle, android.view.Surface surface, int
			 format, int width, int height)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void onSurfaceRedrawNeededNative(int handle, android.view.Surface surface
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void onSurfaceDestroyedNative(int handle)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void onInputChannelCreatedNative(int handle, android.view.InputChannel channel
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void onInputChannelDestroyedNative(int handle, android.view.InputChannel 
			channel)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void onContentRectChangedNative(int handle, int x, int y, int w, int h)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void dispatchKeyEventNative(int handle, android.view.KeyEvent @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void finishPreDispatchKeyEventNative(int handle, int seq, bool handled)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal class NativeContentView : android.view.View
		{
			internal android.app.NativeActivity mActivity;

			[Sharpen.Stub]
			public NativeContentView(android.content.Context context) : base(context)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public NativeContentView(android.content.Context context, android.util.AttributeSet
				 attrs) : base(context, attrs)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		internal class InputMethodCallback : android.view.@internal.IInputMethodCallbackClass
			.Stub
		{
			internal java.lang.@ref.WeakReference<android.app.NativeActivity> mNa;

			[Sharpen.Stub]
			internal InputMethodCallback(android.app.NativeActivity na)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodCallback")]
			public override void finishedEvent(int seq, bool handled)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodCallback")]
			public override void sessionCreated(android.view.@internal.IInputMethodSession session
				)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Activity")]
		protected internal override void onCreate(android.os.Bundle savedInstanceState)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Activity")]
		protected internal override void onDestroy()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Activity")]
		protected internal override void onPause()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Activity")]
		protected internal override void onResume()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Activity")]
		protected internal override void onSaveInstanceState(android.os.Bundle outState)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Activity")]
		protected internal override void onStart()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Activity")]
		protected internal override void onStop()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Activity")]
		public override void onConfigurationChanged(android.content.res.Configuration newConfig
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Activity")]
		public override void onLowMemory()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Activity")]
		public override void onWindowFocusChanged(bool hasFocus)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Activity")]
		public override bool dispatchKeyEvent(android.view.KeyEvent @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.SurfaceHolder.Callback")]
		public virtual void surfaceCreated(android.view.SurfaceHolder holder)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.SurfaceHolder.Callback")]
		public virtual void surfaceChanged(android.view.SurfaceHolder holder, int format, 
			int width, int height)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.SurfaceHolder.Callback2")]
		public virtual void surfaceRedrawNeeded(android.view.SurfaceHolder holder)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.SurfaceHolder.Callback")]
		public virtual void surfaceDestroyed(android.view.SurfaceHolder holder)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.InputQueue.Callback")]
		public virtual void onInputQueueCreated(android.view.InputQueue queue)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.InputQueue.Callback")]
		public virtual void onInputQueueDestroyed(android.view.InputQueue queue)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.ViewTreeObserver.OnGlobalLayoutListener"
			)]
		public virtual void onGlobalLayout()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual bool dispatchUnhandledKeyEvent(android.view.KeyEvent @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void preDispatchKeyEvent(android.view.KeyEvent @event, int seq)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void setWindowFlags(int flags, int mask)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void setWindowFormat(int format)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void showIme(int mode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void hideIme(int mode)
		{
			throw new System.NotImplementedException();
		}
	}
}

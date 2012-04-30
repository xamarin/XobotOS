using Sharpen;

namespace android.inputmethodservice
{
	[Sharpen.Stub]
	internal class SoftInputWindow : android.app.Dialog
	{
		internal readonly android.view.KeyEvent.DispatcherState mDispatcherState;

		private readonly android.graphics.Rect mBounds = new android.graphics.Rect();

		[Sharpen.Stub]
		public virtual void setToken(android.os.IBinder token)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public SoftInputWindow(android.content.Context context, int theme, android.view.KeyEvent
			.DispatcherState dispatcherState) : base(context, theme)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Dialog")]
		public override void onWindowFocusChanged(bool hasFocus)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Dialog")]
		public override bool dispatchTouchEvent(android.view.MotionEvent ev)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getSize()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setSize(int size)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setGravity(int gravity)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void initDockWindow()
		{
			throw new System.NotImplementedException();
		}
	}
}

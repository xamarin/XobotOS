using Sharpen;

namespace android.text.method
{
	[Sharpen.Stub]
	public class LinkMovementMethod : android.text.method.ScrollingMovementMethod
	{
		internal const int CLICK = 1;

		internal const int UP = 2;

		internal const int DOWN = 3;

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.text.method.BaseMovementMethod")]
		protected internal override bool handleMovementKey(android.widget.TextView widget
			, android.text.Spannable buffer, int keyCode, int movementMetaState, android.view.KeyEvent
			 @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.text.method.BaseMovementMethod")]
		protected internal override bool up(android.widget.TextView widget, android.text.Spannable
			 buffer)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.text.method.BaseMovementMethod")]
		protected internal override bool down(android.widget.TextView widget, android.text.Spannable
			 buffer)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.text.method.BaseMovementMethod")]
		protected internal override bool left(android.widget.TextView widget, android.text.Spannable
			 buffer)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.text.method.BaseMovementMethod")]
		protected internal override bool right(android.widget.TextView widget, android.text.Spannable
			 buffer)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private bool action(int what, android.widget.TextView widget, android.text.Spannable
			 buffer)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.text.method.BaseMovementMethod")]
		public override bool onTouchEvent(android.widget.TextView widget, android.text.Spannable
			 buffer, android.view.MotionEvent @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.text.method.BaseMovementMethod")]
		public override void initialize(android.widget.TextView widget, android.text.Spannable
			 text)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.text.method.BaseMovementMethod")]
		public override void onTakeFocus(android.widget.TextView view, android.text.Spannable
			 text, int dir)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		new public static android.text.method.MovementMethod getInstance()
		{
			throw new System.NotImplementedException();
		}

		private static android.text.method.LinkMovementMethod sInstance;

		private static object FROM_BELOW = new android.text.NoCopySpanClass.Concrete();
	}
}

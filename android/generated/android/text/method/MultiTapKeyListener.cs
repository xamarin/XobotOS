using Sharpen;

namespace android.text.method
{
	[Sharpen.Stub]
	public class MultiTapKeyListener : android.text.method.BaseKeyListener, android.text.SpanWatcher
	{
		private static android.text.method.MultiTapKeyListener[] sInstance = new android.text.method.MultiTapKeyListener
			[System.Enum.GetValues(typeof(android.text.method.TextKeyListener.Capitalize)).Length
			 * 2];

		private static readonly android.util.SparseArray<string> sRecs = new android.util.SparseArray
			<string>();

		private android.text.method.TextKeyListener.Capitalize mCapitalize;

		private bool mAutoText;

		static MultiTapKeyListener()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public MultiTapKeyListener(android.text.method.TextKeyListener.Capitalize cap, bool
			 autotext)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.text.method.MultiTapKeyListener getInstance(bool autotext, 
			android.text.method.TextKeyListener.Capitalize cap)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.text.method.KeyListener")]
		public override int getInputType()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.text.method.MetaKeyKeyListener")]
		public override bool onKeyDown(android.view.View view, android.text.Editable content
			, int keyCode, android.view.KeyEvent @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.text.SpanWatcher")]
		public virtual void onSpanChanged(android.text.Spannable buf, object what, int s, 
			int e, int start, int stop)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void removeTimeouts(android.text.Spannable buf)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private class Timeout : android.os.Handler, java.lang.Runnable
		{
			[Sharpen.Stub]
			public Timeout(MultiTapKeyListener _enclosing, android.text.Editable buffer)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public virtual void run()
			{
				throw new System.NotImplementedException();
			}

			internal android.text.Editable mBuffer;

			private readonly MultiTapKeyListener _enclosing;
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.text.SpanWatcher")]
		public virtual void onSpanAdded(android.text.Spannable s, object what, int start, 
			int end)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.text.SpanWatcher")]
		public virtual void onSpanRemoved(android.text.Spannable s, object what, int start
			, int end)
		{
			throw new System.NotImplementedException();
		}
	}
}

using Sharpen;

namespace android.widget
{
	[Sharpen.Stub]
	public class DigitalClock : android.widget.TextView
	{
		internal java.util.Calendar mCalendar;

		internal const string m12 = "h:mm:ss aa";

		internal const string m24 = "k:mm:ss";

		private android.widget.DigitalClock.FormatChangeObserver mFormatChangeObserver;

		private java.lang.Runnable mTicker;

		private android.os.Handler mHandler;

		private bool mTickerStopped = false;

		internal string mFormat;

		[Sharpen.Stub]
		public DigitalClock(android.content.Context context) : base(context)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public DigitalClock(android.content.Context context, android.util.AttributeSet attrs
			) : base(context, attrs)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void initClock(android.content.Context context)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onAttachedToWindow()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onDetachedFromWindow()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private bool get24HourMode()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void setFormat()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private class FormatChangeObserver : android.database.ContentObserver
		{
			[Sharpen.Stub]
			public FormatChangeObserver(DigitalClock _enclosing) : base(new android.os.Handler
				())
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.database.ContentObserver")]
			public override void onChange(bool selfChange)
			{
				throw new System.NotImplementedException();
			}

			private readonly DigitalClock _enclosing;
		}
	}
}

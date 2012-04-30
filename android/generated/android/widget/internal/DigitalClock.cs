using Sharpen;

namespace android.widget.@internal
{
	[Sharpen.Stub]
	public class DigitalClock : android.widget.RelativeLayout
	{
		internal const string SYSTEM = "/system/fonts/";

		private static readonly string SYSTEM_FONT_TIME_BACKGROUND = SYSTEM + "AndroidClock.ttf";

		private static readonly string SYSTEM_FONT_TIME_FOREGROUND = SYSTEM + "AndroidClock_Highlight.ttf";

		internal const string M12 = "h:mm";

		internal const string M24 = "kk:mm";

		private java.util.Calendar mCalendar;

		private string mFormat;

		private android.widget.TextView mTimeDisplayBackground;

		private android.widget.TextView mTimeDisplayForeground;

		private android.widget.@internal.DigitalClock.AmPm mAmPm;

		private android.database.ContentObserver mFormatChangeObserver;

		private int mAttached = 0;

		private readonly android.os.Handler mHandler = new android.os.Handler();

		private android.content.BroadcastReceiver mIntentReceiver;

		private static readonly android.graphics.Typeface sBackgroundFont;

		private static readonly android.graphics.Typeface sForegroundFont;

		static DigitalClock()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private class TimeChangedReceiver : android.content.BroadcastReceiver
		{
			internal java.lang.@ref.WeakReference<android.widget.@internal.DigitalClock> mClock;

			internal android.content.Context mContext;

			[Sharpen.Stub]
			public TimeChangedReceiver(android.widget.@internal.DigitalClock clock)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.content.BroadcastReceiver")]
			public override void onReceive(android.content.Context context, android.content.Intent
				 intent)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		internal class AmPm
		{
			private android.widget.TextView mAmPmTextView;

			private string mAmString;

			private string mPmString;

			[Sharpen.Stub]
			internal AmPm(android.view.View parent, android.graphics.Typeface tf)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal virtual void setShowAmPm(bool show)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal virtual void setIsMorning(bool isMorning)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		private class FormatChangeObserver : android.database.ContentObserver
		{
			internal java.lang.@ref.WeakReference<android.widget.@internal.DigitalClock> mClock;

			internal android.content.Context mContext;

			[Sharpen.Stub]
			public FormatChangeObserver(android.widget.@internal.DigitalClock clock) : base(new 
				android.os.Handler())
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.database.ContentObserver")]
			public override void onChange(bool selfChange)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public DigitalClock(android.content.Context context) : this(context, null)
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
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onFinishInflate()
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
		internal virtual void updateTime(java.util.Calendar c)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void updateTime()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void setDateFormat()
		{
			throw new System.NotImplementedException();
		}
	}
}

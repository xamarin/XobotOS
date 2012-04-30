using Sharpen;

namespace android.widget
{
	[Sharpen.Stub]
	public class DateTimeView : android.widget.TextView
	{
		internal const string TAG = "DateTimeView";

		internal const long TWELVE_HOURS_IN_MINUTES = 12 * 60;

		internal const long TWENTY_FOUR_HOURS_IN_MILLIS = 24 * 60 * 60 * 1000;

		internal const int SHOW_TIME = 0;

		internal const int SHOW_MONTH_DAY_YEAR = 1;

		internal System.DateTime mTime;

		internal long mTimeMillis;

		internal int mLastDisplay = -1;

		internal java.text.DateFormat mLastFormat;

		private bool mAttachedToWindow;

		private long mUpdateTimeMillis;

		[Sharpen.Stub]
		public DateTimeView(android.content.Context context) : base(context)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public DateTimeView(android.content.Context context, android.util.AttributeSet attrs
			) : base(context, attrs)
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

		[android.view.RemotableViewMethod]
		[Sharpen.Stub]
		public virtual void setTime(long time)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void update()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private java.text.DateFormat getTimeFormat()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private java.text.DateFormat getDateFormat()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void registerReceivers()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void unregisterReceivers()
		{
			throw new System.NotImplementedException();
		}

		private sealed class _BroadcastReceiver_238 : android.content.BroadcastReceiver
		{
			public _BroadcastReceiver_238()
			{
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.content.BroadcastReceiver")]
			public override void onReceive(android.content.Context context, android.content.Intent
				 intent)
			{
				throw new System.NotImplementedException();
			}
		}

		private android.content.BroadcastReceiver mBroadcastReceiver = new _BroadcastReceiver_238
			();

		private sealed class _ContentObserver_256 : android.database.ContentObserver
		{
			public _ContentObserver_256(android.os.Handler baseArg1) : base(baseArg1)
			{
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.database.ContentObserver")]
			public override void onChange(bool selfChange)
			{
				throw new System.NotImplementedException();
			}
		}

		private android.database.ContentObserver mContentObserver = new _ContentObserver_256
			(new android.os.Handler());
	}
}

using Sharpen;

namespace android.widget
{
	/// <summary>
	/// This widget display an analogic clock with two hands for hours and
	/// minutes.
	/// </summary>
	/// <remarks>
	/// This widget display an analogic clock with two hands for hours and
	/// minutes.
	/// </remarks>
	[Sharpen.Sharpened]
	public class AnalogClock : android.view.View
	{
		private android.text.format.Time mCalendar;

		private android.graphics.drawable.Drawable mHourHand;

		private android.graphics.drawable.Drawable mMinuteHand;

		private android.graphics.drawable.Drawable mDial;

		private int mDialWidth;

		private int mDialHeight;

		private bool mAttached;

		private readonly android.os.Handler mHandler = new android.os.Handler();

		private float mMinutes;

		private float mHour;

		private bool mChanged;

		public AnalogClock(android.content.Context context) : this(context, null)
		{
			mIntentReceiver = new _BroadcastReceiver_236(this);
		}

		public AnalogClock(android.content.Context context, android.util.AttributeSet attrs
			) : this(context, attrs, 0)
		{
			mIntentReceiver = new _BroadcastReceiver_236(this);
		}

		public AnalogClock(android.content.Context context, android.util.AttributeSet attrs
			, int defStyle) : base(context, attrs, defStyle)
		{
			mIntentReceiver = new _BroadcastReceiver_236(this);
			android.content.res.Resources r = mContext.getResources();
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.AnalogClock, defStyle, 0);
			mDial = a.getDrawable(android.@internal.R.styleable.AnalogClock_dial);
			if (mDial == null)
			{
				mDial = r.getDrawable(android.@internal.R.drawable.clock_dial);
			}
			mHourHand = a.getDrawable(android.@internal.R.styleable.AnalogClock_hand_hour);
			if (mHourHand == null)
			{
				mHourHand = r.getDrawable(android.@internal.R.drawable.clock_hand_hour);
			}
			mMinuteHand = a.getDrawable(android.@internal.R.styleable.AnalogClock_hand_minute
				);
			if (mMinuteHand == null)
			{
				mMinuteHand = r.getDrawable(android.@internal.R.drawable.clock_hand_minute);
			}
			mCalendar = new android.text.format.Time();
			mDialWidth = mDial.getIntrinsicWidth();
			mDialHeight = mDial.getIntrinsicHeight();
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onAttachedToWindow()
		{
			base.onAttachedToWindow();
			if (!mAttached)
			{
				mAttached = true;
				android.content.IntentFilter filter = new android.content.IntentFilter();
				filter.addAction(android.content.Intent.ACTION_TIME_TICK);
				filter.addAction(android.content.Intent.ACTION_TIME_CHANGED);
				filter.addAction(android.content.Intent.ACTION_TIMEZONE_CHANGED);
				getContext().registerReceiver(mIntentReceiver, filter, null, mHandler);
			}
			// NOTE: It's safe to do these after registering the receiver since the receiver always runs
			// in the main thread, therefore the receiver can't run before this method returns.
			// The time zone may have changed while the receiver wasn't registered, so update the Time
			mCalendar = new android.text.format.Time();
			// Make sure we update to the current time
			onTimeChanged();
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onDetachedFromWindow()
		{
			base.onDetachedFromWindow();
			if (mAttached)
			{
				getContext().unregisterReceiver(mIntentReceiver);
				mAttached = false;
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onMeasure(int widthMeasureSpec, int heightMeasureSpec
			)
		{
			int widthMode = android.view.View.MeasureSpec.getMode(widthMeasureSpec);
			int widthSize = android.view.View.MeasureSpec.getSize(widthMeasureSpec);
			int heightMode = android.view.View.MeasureSpec.getMode(heightMeasureSpec);
			int heightSize = android.view.View.MeasureSpec.getSize(heightMeasureSpec);
			float hScale = 1.0f;
			float vScale = 1.0f;
			if (widthMode != android.view.View.MeasureSpec.UNSPECIFIED && widthSize < mDialWidth)
			{
				hScale = (float)widthSize / (float)mDialWidth;
			}
			if (heightMode != android.view.View.MeasureSpec.UNSPECIFIED && heightSize < mDialHeight)
			{
				vScale = (float)heightSize / (float)mDialHeight;
			}
			float scale = System.Math.Min(hScale, vScale);
			setMeasuredDimension(resolveSizeAndState((int)(mDialWidth * scale), widthMeasureSpec
				, 0), resolveSizeAndState((int)(mDialHeight * scale), heightMeasureSpec, 0));
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onSizeChanged(int w, int h, int oldw, int oldh)
		{
			base.onSizeChanged(w, h, oldw, oldh);
			mChanged = true;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onDraw(android.graphics.Canvas canvas)
		{
			base.onDraw(canvas);
			bool changed = mChanged;
			if (changed)
			{
				mChanged = false;
			}
			int availableWidth = mRight - mLeft;
			int availableHeight = mBottom - mTop;
			int x = availableWidth / 2;
			int y = availableHeight / 2;
			android.graphics.drawable.Drawable dial = mDial;
			int w = dial.getIntrinsicWidth();
			int h = dial.getIntrinsicHeight();
			bool scaled = false;
			if (availableWidth < w || availableHeight < h)
			{
				scaled = true;
				float scale = System.Math.Min((float)availableWidth / (float)w, (float)availableHeight
					 / (float)h);
				canvas.save();
				canvas.scale(scale, scale, x, y);
			}
			if (changed)
			{
				dial.setBounds(x - (w / 2), y - (h / 2), x + (w / 2), y + (h / 2));
			}
			dial.draw(canvas);
			canvas.save();
			canvas.rotate(mHour / 12.0f * 360.0f, x, y);
			android.graphics.drawable.Drawable hourHand = mHourHand;
			if (changed)
			{
				w = hourHand.getIntrinsicWidth();
				h = hourHand.getIntrinsicHeight();
				hourHand.setBounds(x - (w / 2), y - (h / 2), x + (w / 2), y + (h / 2));
			}
			hourHand.draw(canvas);
			canvas.restore();
			canvas.save();
			canvas.rotate(mMinutes / 60.0f * 360.0f, x, y);
			android.graphics.drawable.Drawable minuteHand = mMinuteHand;
			if (changed)
			{
				w = minuteHand.getIntrinsicWidth();
				h = minuteHand.getIntrinsicHeight();
				minuteHand.setBounds(x - (w / 2), y - (h / 2), x + (w / 2), y + (h / 2));
			}
			minuteHand.draw(canvas);
			canvas.restore();
			if (scaled)
			{
				canvas.restore();
			}
		}

		private void onTimeChanged()
		{
			mCalendar.setToNow();
			int hour = mCalendar.hour;
			int minute = mCalendar.minute;
			int second = mCalendar.second;
			mMinutes = minute + second / 60.0f;
			mHour = hour + mMinutes / 60.0f;
			mChanged = true;
			updateContentDescription(mCalendar);
		}

		private sealed class _BroadcastReceiver_236 : android.content.BroadcastReceiver
		{
			public _BroadcastReceiver_236(AnalogClock _enclosing)
			{
				this._enclosing = _enclosing;
			}

			[Sharpen.OverridesMethod(@"android.content.BroadcastReceiver")]
			public override void onReceive(android.content.Context context, android.content.Intent
				 intent)
			{
				if (intent.getAction().Equals(android.content.Intent.ACTION_TIMEZONE_CHANGED))
				{
					string tz = intent.getStringExtra("time-zone");
					this._enclosing.mCalendar = new android.text.format.Time(java.util.TimeZone.getTimeZone
						(tz).getID());
				}
				this._enclosing.onTimeChanged();
				this._enclosing.invalidate();
			}

			private readonly AnalogClock _enclosing;
		}

		private readonly android.content.BroadcastReceiver mIntentReceiver;

		private void updateContentDescription(android.text.format.Time time)
		{
			int flags = android.text.format.DateUtils.FORMAT_SHOW_TIME | android.text.format.DateUtils
				.FORMAT_24HOUR;
			string contentDescription = android.text.format.DateUtils.formatDateTime(mContext
				, time.toMillis(false), flags);
			setContentDescription(java.lang.CharSequenceProxy.Wrap(contentDescription));
		}
	}
}

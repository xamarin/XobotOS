using Sharpen;

namespace android.widget
{
	/// <summary>Class that implements a simple timer.</summary>
	/// <remarks>
	/// Class that implements a simple timer.
	/// <p>
	/// You can give it a start time in the
	/// <see cref="android.os.SystemClock.elapsedRealtime()">android.os.SystemClock.elapsedRealtime()
	/// 	</see>
	/// timebase,
	/// and it counts up from that, or if you don't give it a base time, it will use the
	/// time at which you call
	/// <see cref="start()">start()</see>
	/// .  By default it will display the current
	/// timer value in the form "MM:SS" or "H:MM:SS", or you can use
	/// <see cref="setFormat(string)">setFormat(string)</see>
	/// to format the timer value into an arbitrary string.
	/// </remarks>
	/// <attr>ref android.R.styleable#Chronometer_format</attr>
	[Sharpen.Sharpened]
	public class Chronometer : android.widget.TextView
	{
		internal const string TAG = "Chronometer";

		/// <summary>A callback that notifies when the chronometer has incremented on its own.
		/// 	</summary>
		/// <remarks>A callback that notifies when the chronometer has incremented on its own.
		/// 	</remarks>
		public interface OnChronometerTickListener
		{
			/// <summary>Notification that the chronometer has changed.</summary>
			/// <remarks>Notification that the chronometer has changed.</remarks>
			void onChronometerTick(android.widget.Chronometer chronometer);
		}

		private long mBase;

		private bool mVisible;

		private bool mStarted;

		private bool mRunning;

		private bool mLogged;

		private string mFormat;

		private java.util.Formatter mFormatter;

		private System.Globalization.CultureInfo mFormatterLocale;

		private object[] mFormatterArgs = new object[1];

		private java.lang.StringBuilder mFormatBuilder;

		private android.widget.Chronometer.OnChronometerTickListener mOnChronometerTickListener;

		private java.lang.StringBuilder mRecycle = new java.lang.StringBuilder(8);

		internal const int TICK_WHAT = 2;

		/// <summary>Initialize this Chronometer object.</summary>
		/// <remarks>
		/// Initialize this Chronometer object.
		/// Sets the base to the current time.
		/// </remarks>
		public Chronometer(android.content.Context context) : this(context, null, 0)
		{
			mHandler = new _Handler_264(this);
		}

		/// <summary>Initialize with standard view layout information.</summary>
		/// <remarks>
		/// Initialize with standard view layout information.
		/// Sets the base to the current time.
		/// </remarks>
		public Chronometer(android.content.Context context, android.util.AttributeSet attrs
			) : this(context, attrs, 0)
		{
			mHandler = new _Handler_264(this);
		}

		/// <summary>Initialize with standard view layout information and style.</summary>
		/// <remarks>
		/// Initialize with standard view layout information and style.
		/// Sets the base to the current time.
		/// </remarks>
		public Chronometer(android.content.Context context, android.util.AttributeSet attrs
			, int defStyle) : base(context, attrs, defStyle)
		{
			mHandler = new _Handler_264(this);
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.Chronometer, defStyle, 0);
			setFormat(a.getString(android.@internal.R.styleable.Chronometer_format));
			a.recycle();
			init();
		}

		private void init()
		{
			mBase = android.os.SystemClock.elapsedRealtime();
			updateText(mBase);
		}

		/// <summary>Set the time that the count-up timer is in reference to.</summary>
		/// <remarks>Set the time that the count-up timer is in reference to.</remarks>
		/// <param name="base">
		/// Use the
		/// <see cref="android.os.SystemClock.elapsedRealtime()">android.os.SystemClock.elapsedRealtime()
		/// 	</see>
		/// time base.
		/// </param>
		[android.view.RemotableViewMethod]
		public virtual void setBase(long @base)
		{
			mBase = @base;
			dispatchChronometerTick();
			updateText(android.os.SystemClock.elapsedRealtime());
		}

		/// <summary>
		/// Return the base time as set through
		/// <see cref="setBase(long)">setBase(long)</see>
		/// .
		/// </summary>
		public virtual long getBase()
		{
			return mBase;
		}

		/// <summary>Sets the format string used for display.</summary>
		/// <remarks>
		/// Sets the format string used for display.  The Chronometer will display
		/// this string, with the first "%s" replaced by the current timer value in
		/// "MM:SS" or "H:MM:SS" form.
		/// If the format string is null, or if you never call setFormat(), the
		/// Chronometer will simply display the timer value in "MM:SS" or "H:MM:SS"
		/// form.
		/// </remarks>
		/// <param name="format">the format string.</param>
		[android.view.RemotableViewMethod]
		public virtual void setFormat(string format)
		{
			mFormat = format;
			if (format != null && mFormatBuilder == null)
			{
				mFormatBuilder = new java.lang.StringBuilder(format.Length * 2);
			}
		}

		/// <summary>
		/// Returns the current format string as set through
		/// <see cref="setFormat(string)">setFormat(string)</see>
		/// .
		/// </summary>
		public virtual string getFormat()
		{
			return mFormat;
		}

		/// <summary>Sets the listener to be called when the chronometer changes.</summary>
		/// <remarks>Sets the listener to be called when the chronometer changes.</remarks>
		/// <param name="listener">The listener.</param>
		public virtual void setOnChronometerTickListener(android.widget.Chronometer.OnChronometerTickListener
			 listener)
		{
			mOnChronometerTickListener = listener;
		}

		/// <returns>
		/// The listener (may be null) that is listening for chronometer change
		/// events.
		/// </returns>
		public virtual android.widget.Chronometer.OnChronometerTickListener getOnChronometerTickListener
			()
		{
			return mOnChronometerTickListener;
		}

		/// <summary>Start counting up.</summary>
		/// <remarks>
		/// Start counting up.  This does not affect the base as set from
		/// <see cref="setBase(long)">setBase(long)</see>
		/// , just
		/// the view display.
		/// Chronometer works by regularly scheduling messages to the handler, even when the
		/// Widget is not visible.  To make sure resource leaks do not occur, the user should
		/// make sure that each start() call has a reciprocal call to
		/// <see cref="stop()">stop()</see>
		/// .
		/// </remarks>
		public virtual void start()
		{
			mStarted = true;
			updateRunning();
		}

		/// <summary>Stop counting up.</summary>
		/// <remarks>
		/// Stop counting up.  This does not affect the base as set from
		/// <see cref="setBase(long)">setBase(long)</see>
		/// , just
		/// the view display.
		/// This stops the messages to the handler, effectively releasing resources that would
		/// be held as the chronometer is running, via
		/// <see cref="start()">start()</see>
		/// .
		/// </remarks>
		public virtual void stop()
		{
			mStarted = false;
			updateRunning();
		}

		/// <summary>
		/// The same as calling
		/// <see cref="start()">start()</see>
		/// or
		/// <see cref="stop()">stop()</see>
		/// .
		/// </summary>
		/// <hide>pending API council approval</hide>
		[android.view.RemotableViewMethod]
		public virtual void setStarted(bool started)
		{
			mStarted = started;
			updateRunning();
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onDetachedFromWindow()
		{
			base.onDetachedFromWindow();
			mVisible = false;
			updateRunning();
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onWindowVisibilityChanged(int visibility)
		{
			base.onWindowVisibilityChanged(visibility);
			mVisible = visibility == VISIBLE;
			updateRunning();
		}

		private void updateText(long now)
		{
			lock (this)
			{
				long seconds = now - mBase;
				seconds /= 1000;
				string text = android.text.format.DateUtils.formatElapsedTime(mRecycle, seconds);
				if (mFormat != null)
				{
					System.Globalization.CultureInfo loc = System.Globalization.CultureInfo.CurrentCulture;
					if (mFormatter == null || !loc.Equals(mFormatterLocale))
					{
						mFormatterLocale = loc;
						mFormatter = new java.util.Formatter(mFormatBuilder, loc);
					}
					mFormatBuilder.setLength(0);
					mFormatterArgs[0] = text;
					try
					{
						mFormatter.format(mFormat, mFormatterArgs);
						text = mFormatBuilder.ToString();
					}
					catch (java.util.IllegalFormatException)
					{
						if (!mLogged)
						{
							android.util.Log.w(TAG, "Illegal format string: " + mFormat);
							mLogged = true;
						}
					}
				}
				setText(java.lang.CharSequenceProxy.Wrap(text));
			}
		}

		private void updateRunning()
		{
			bool running = mVisible && mStarted;
			if (running != mRunning)
			{
				if (running)
				{
					updateText(android.os.SystemClock.elapsedRealtime());
					dispatchChronometerTick();
					mHandler.sendMessageDelayed(android.os.Message.obtain(mHandler, TICK_WHAT), 1000);
				}
				else
				{
					mHandler.removeMessages(TICK_WHAT);
				}
				mRunning = running;
			}
		}

		private sealed class _Handler_264 : android.os.Handler
		{
			public _Handler_264(Chronometer _enclosing)
			{
				this._enclosing = _enclosing;
			}

			[Sharpen.OverridesMethod(@"android.os.Handler")]
			public override void handleMessage(android.os.Message m)
			{
				if (this._enclosing.mRunning)
				{
					this._enclosing.updateText(android.os.SystemClock.elapsedRealtime());
					this._enclosing.dispatchChronometerTick();
					this.sendMessageDelayed(android.os.Message.obtain(this, android.widget.Chronometer
						.TICK_WHAT), 1000);
				}
			}

			private readonly Chronometer _enclosing;
		}

		private android.os.Handler mHandler;

		internal virtual void dispatchChronometerTick()
		{
			if (mOnChronometerTickListener != null)
			{
				mOnChronometerTickListener.onChronometerTick(this);
			}
		}
	}
}

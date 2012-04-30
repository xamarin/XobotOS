using Sharpen;

namespace android.widget
{
	/// <summary>
	/// Simple
	/// <see cref="ViewAnimator">ViewAnimator</see>
	/// that will animate between two or more views
	/// that have been added to it.  Only one child is shown at a time.  If
	/// requested, can automatically flip between each child at a regular interval.
	/// </summary>
	/// <attr>ref android.R.styleable#AdapterViewFlipper_flipInterval</attr>
	/// <attr>ref android.R.styleable#AdapterViewFlipper_autoStart</attr>
	[Sharpen.Sharpened]
	public class AdapterViewFlipper : android.widget.AdapterViewAnimator
	{
		internal const string TAG = "ViewFlipper";

		internal const bool LOGD = false;

		internal const int DEFAULT_INTERVAL = 10000;

		private int mFlipInterval = DEFAULT_INTERVAL;

		private bool mAutoStart = false;

		private bool mRunning = false;

		private bool mStarted = false;

		private bool mVisible = false;

		private bool mUserPresent = true;

		private bool mAdvancedByHost = false;

		public AdapterViewFlipper(android.content.Context context) : base(context)
		{
			mReceiver = new _BroadcastReceiver_77(this);
			mHandler = new _Handler_249(this);
		}

		public AdapterViewFlipper(android.content.Context context, android.util.AttributeSet
			 attrs) : base(context, attrs)
		{
			mReceiver = new _BroadcastReceiver_77(this);
			mHandler = new _Handler_249(this);
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.AdapterViewFlipper);
			mFlipInterval = a.getInt(android.@internal.R.styleable.AdapterViewFlipper_flipInterval
				, DEFAULT_INTERVAL);
			mAutoStart = a.getBoolean(android.@internal.R.styleable.AdapterViewFlipper_autoStart
				, false);
			// A view flipper should cycle through the views
			mLoopViews = true;
			a.recycle();
		}

		private sealed class _BroadcastReceiver_77 : android.content.BroadcastReceiver
		{
			public _BroadcastReceiver_77(AdapterViewFlipper _enclosing)
			{
				this._enclosing = _enclosing;
			}

			[Sharpen.OverridesMethod(@"android.content.BroadcastReceiver")]
			public override void onReceive(android.content.Context context, android.content.Intent
				 intent)
			{
				string action = intent.getAction();
				if (android.content.Intent.ACTION_SCREEN_OFF.Equals(action))
				{
					this._enclosing.mUserPresent = false;
					this._enclosing.updateRunning();
				}
				else
				{
					if (android.content.Intent.ACTION_USER_PRESENT.Equals(action))
					{
						this._enclosing.mUserPresent = true;
						this._enclosing.updateRunning(false);
					}
				}
			}

			private readonly AdapterViewFlipper _enclosing;
		}

		private readonly android.content.BroadcastReceiver mReceiver;

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onAttachedToWindow()
		{
			base.onAttachedToWindow();
			// Listen for broadcasts related to user-presence
			android.content.IntentFilter filter = new android.content.IntentFilter();
			filter.addAction(android.content.Intent.ACTION_SCREEN_OFF);
			filter.addAction(android.content.Intent.ACTION_USER_PRESENT);
			getContext().registerReceiver(mReceiver, filter);
			if (mAutoStart)
			{
				// Automatically start when requested
				startFlipping();
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onDetachedFromWindow()
		{
			base.onDetachedFromWindow();
			mVisible = false;
			getContext().unregisterReceiver(mReceiver);
			updateRunning();
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onWindowVisibilityChanged(int visibility)
		{
			base.onWindowVisibilityChanged(visibility);
			mVisible = (visibility == VISIBLE);
			updateRunning(false);
		}

		[Sharpen.OverridesMethod(@"android.widget.AdapterView")]
		public override void setAdapter(android.widget.Adapter adapter)
		{
			base.setAdapter(adapter);
			updateRunning();
		}

		/// <summary>How long to wait before flipping to the next view</summary>
		/// <param name="milliseconds">time in milliseconds</param>
		public virtual void setFlipInterval(int milliseconds)
		{
			mFlipInterval = milliseconds;
		}

		/// <summary>Start a timer to cycle through child views</summary>
		public virtual void startFlipping()
		{
			mStarted = true;
			updateRunning();
		}

		/// <summary>No more flips</summary>
		public virtual void stopFlipping()
		{
			mStarted = false;
			updateRunning();
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[android.view.RemotableViewMethod]
		[Sharpen.OverridesMethod(@"android.widget.AdapterViewAnimator")]
		public override void showNext()
		{
			// if the flipper is currently flipping automatically, and showNext() is called
			// we should we should make sure to reset the timer
			if (mRunning)
			{
				mHandler.removeMessages(FLIP_MSG);
				android.os.Message msg = mHandler.obtainMessage(FLIP_MSG);
				mHandler.sendMessageDelayed(msg, mFlipInterval);
			}
			base.showNext();
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[android.view.RemotableViewMethod]
		[Sharpen.OverridesMethod(@"android.widget.AdapterViewAnimator")]
		public override void showPrevious()
		{
			// if the flipper is currently flipping automatically, and showPrevious() is called
			// we should we should make sure to reset the timer
			if (mRunning)
			{
				mHandler.removeMessages(FLIP_MSG);
				android.os.Message msg = mHandler.obtainMessage(FLIP_MSG);
				mHandler.sendMessageDelayed(msg, mFlipInterval);
			}
			base.showPrevious();
		}

		/// <summary>
		/// Internal method to start or stop dispatching flip
		/// <see cref="android.os.Message">android.os.Message</see>
		/// based
		/// on
		/// <see cref="mRunning">mRunning</see>
		/// and
		/// <see cref="mVisible">mVisible</see>
		/// state.
		/// </summary>
		private void updateRunning()
		{
			// by default when we update running, we want the
			// current view to animate in
			updateRunning(true);
		}

		/// <summary>
		/// Internal method to start or stop dispatching flip
		/// <see cref="android.os.Message">android.os.Message</see>
		/// based
		/// on
		/// <see cref="mRunning">mRunning</see>
		/// and
		/// <see cref="mVisible">mVisible</see>
		/// state.
		/// </summary>
		/// <param name="flipNow">
		/// Determines whether or not to execute the animation now, in
		/// addition to queuing future flips. If omitted, defaults to
		/// true.
		/// </param>
		private void updateRunning(bool flipNow)
		{
			bool running = !mAdvancedByHost && mVisible && mStarted && mUserPresent && mAdapter
				 != null;
			if (running != mRunning)
			{
				if (running)
				{
					showOnly(mWhichChild, flipNow);
					android.os.Message msg = mHandler.obtainMessage(FLIP_MSG);
					mHandler.sendMessageDelayed(msg, mFlipInterval);
				}
				else
				{
					mHandler.removeMessages(FLIP_MSG);
				}
				mRunning = running;
			}
		}

		/// <summary>Returns true if the child views are flipping.</summary>
		/// <remarks>Returns true if the child views are flipping.</remarks>
		public virtual bool isFlipping()
		{
			return mStarted;
		}

		/// <summary>
		/// Set if this view automatically calls
		/// <see cref="startFlipping()">startFlipping()</see>
		/// when it
		/// becomes attached to a window.
		/// </summary>
		public virtual void setAutoStart(bool autoStart)
		{
			mAutoStart = autoStart;
		}

		/// <summary>
		/// Returns true if this view automatically calls
		/// <see cref="startFlipping()">startFlipping()</see>
		/// when it becomes attached to a window.
		/// </summary>
		public virtual bool isAutoStart()
		{
			return mAutoStart;
		}

		private readonly int FLIP_MSG = 1;

		private sealed class _Handler_249 : android.os.Handler
		{
			public _Handler_249(AdapterViewFlipper _enclosing)
			{
				this._enclosing = _enclosing;
			}

			[Sharpen.OverridesMethod(@"android.os.Handler")]
			public override void handleMessage(android.os.Message msg)
			{
				if (msg.what == this._enclosing.FLIP_MSG)
				{
					if (this._enclosing.mRunning)
					{
						this._enclosing.showNext();
					}
				}
			}

			private readonly AdapterViewFlipper _enclosing;
		}

		private readonly android.os.Handler mHandler;

		/// <summary>
		/// Called by an
		/// <see cref="android.appwidget.AppWidgetHost">android.appwidget.AppWidgetHost</see>
		/// to indicate that it will be
		/// automatically advancing the views of this
		/// <see cref="AdapterViewFlipper">AdapterViewFlipper</see>
		/// by calling
		/// <see cref="AdapterViewAnimator.advance()">AdapterViewAnimator.advance()</see>
		/// at some point in the future. This allows
		/// <see cref="AdapterViewFlipper">AdapterViewFlipper</see>
		/// to prepare by no longer Advancing its children.
		/// </summary>
		[Sharpen.OverridesMethod(@"android.widget.AdapterViewAnimator")]
		public override void fyiWillBeAdvancedByHostKThx()
		{
			mAdvancedByHost = true;
			updateRunning(false);
		}
	}
}

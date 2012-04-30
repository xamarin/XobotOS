using Sharpen;

namespace android.widget
{
	[Sharpen.Sharpened]
	public class ZoomButton : android.widget.ImageButton, android.view.View.OnLongClickListener
	{
		private readonly android.os.Handler mHandler;

		private sealed class _Runnable_30 : java.lang.Runnable
		{
			public _Runnable_30(ZoomButton _enclosing)
			{
				this._enclosing = _enclosing;
			}

			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public void run()
			{
				if ((this._enclosing.mOnClickListener != null) && this._enclosing.mIsInLongpress 
					&& this._enclosing.isEnabled())
				{
					this._enclosing.mOnClickListener.onClick(this._enclosing);
					this._enclosing.mHandler.postDelayed(this, this._enclosing.mZoomSpeed);
				}
			}

			private readonly ZoomButton _enclosing;
		}

		private readonly java.lang.Runnable mRunnable;

		private long mZoomSpeed = 1000;

		private bool mIsInLongpress;

		public ZoomButton(android.content.Context context) : this(context, null)
		{
			mRunnable = new _Runnable_30(this);
		}

		public ZoomButton(android.content.Context context, android.util.AttributeSet attrs
			) : this(context, attrs, 0)
		{
			mRunnable = new _Runnable_30(this);
		}

		public ZoomButton(android.content.Context context, android.util.AttributeSet attrs
			, int defStyle) : base(context, attrs, defStyle)
		{
			mRunnable = new _Runnable_30(this);
			mHandler = new android.os.Handler();
			setOnLongClickListener(this);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool onTouchEvent(android.view.MotionEvent @event)
		{
			if ((@event.getAction() == android.view.MotionEvent.ACTION_CANCEL) || (@event.getAction
				() == android.view.MotionEvent.ACTION_UP))
			{
				mIsInLongpress = false;
			}
			return base.onTouchEvent(@event);
		}

		public virtual void setZoomSpeed(long speed)
		{
			mZoomSpeed = speed;
		}

		[Sharpen.ImplementsInterface(@"android.view.View.OnLongClickListener")]
		public virtual bool onLongClick(android.view.View v)
		{
			mIsInLongpress = true;
			mHandler.post(mRunnable);
			return true;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool onKeyUp(int keyCode, android.view.KeyEvent @event)
		{
			mIsInLongpress = false;
			return base.onKeyUp(keyCode, @event);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void setEnabled(bool enabled)
		{
			if (!enabled)
			{
				setPressed(false);
			}
			base.setEnabled(enabled);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool dispatchUnhandledMove(android.view.View focused, int direction
			)
		{
			clearFocus();
			return base.dispatchUnhandledMove(focused, direction);
		}
	}
}

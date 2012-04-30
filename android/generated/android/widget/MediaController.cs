using Sharpen;

namespace android.widget
{
	[Sharpen.Stub]
	public class MediaController : android.widget.FrameLayout
	{
		private android.widget.MediaController.MediaPlayerControl mPlayer;

		private android.content.Context mContext;

		private android.view.View mAnchor;

		private android.view.View mRoot;

		private android.view.WindowManager mWindowManager;

		private android.view.Window mWindow;

		private android.view.View mDecor;

		private android.view.WindowManagerClass.LayoutParams mDecorLayoutParams;

		private android.widget.ProgressBar mProgress;

		private android.widget.TextView mEndTime;

		private android.widget.TextView mCurrentTime;

		private bool mShowing;

		private bool mDragging;

		internal const int sDefaultTimeout = 3000;

		internal const int FADE_OUT = 1;

		internal const int SHOW_PROGRESS = 2;

		private bool mUseFastForward;

		private bool mFromXml;

		private bool mListenersSet;

		private android.view.View.OnClickListener mNextListener;

		private android.view.View.OnClickListener mPrevListener;

		internal java.lang.StringBuilder mFormatBuilder;

		internal java.util.Formatter mFormatter;

		private android.widget.ImageButton mPauseButton;

		private android.widget.ImageButton mFfwdButton;

		private android.widget.ImageButton mRewButton;

		private android.widget.ImageButton mNextButton;

		private android.widget.ImageButton mPrevButton;

		[Sharpen.Stub]
		public MediaController(android.content.Context context, android.util.AttributeSet
			 attrs) : base(context, attrs)
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
		public MediaController(android.content.Context context, bool useFastForward) : base
			(context)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public MediaController(android.content.Context context) : this(context, true)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void initFloatingWindow()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void initFloatingWindowLayout()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void updateFloatingWindowLayout()
		{
			throw new System.NotImplementedException();
		}

		private sealed class _OnLayoutChangeListener_175 : android.view.View.OnLayoutChangeListener
		{
			public _OnLayoutChangeListener_175()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.View.OnLayoutChangeListener")]
			public void onLayoutChange(android.view.View v, int left, int top, int right, int
				 bottom, int oldLeft, int oldTop, int oldRight, int oldBottom)
			{
				throw new System.NotImplementedException();
			}
		}

		private android.view.View.OnLayoutChangeListener mLayoutChangeListener = new _OnLayoutChangeListener_175
			();

		private sealed class _OnTouchListener_186 : android.view.View.OnTouchListener
		{
			public _OnTouchListener_186()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.View.OnTouchListener")]
			public bool onTouch(android.view.View v, android.view.MotionEvent @event)
			{
				throw new System.NotImplementedException();
			}
		}

		private android.view.View.OnTouchListener mTouchListener = new _OnTouchListener_186
			();

		[Sharpen.Stub]
		public virtual void setMediaPlayer(android.widget.MediaController.MediaPlayerControl
			 player)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setAnchorView(android.view.View view)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual android.view.View makeControllerView()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void initControllerView(android.view.View v)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void show()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void disableUnsupportedButtons()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void show(int timeout)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isShowing()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void hide()
		{
			throw new System.NotImplementedException();
		}

		private sealed class _Handler_375 : android.os.Handler
		{
			public _Handler_375()
			{
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.os.Handler")]
			public override void handleMessage(android.os.Message msg)
			{
				throw new System.NotImplementedException();
			}
		}

		private android.os.Handler mHandler = new _Handler_375();

		[Sharpen.Stub]
		private string stringForTime(int timeMs)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private int setProgress()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool onTouchEvent(android.view.MotionEvent @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool onTrackballEvent(android.view.MotionEvent ev)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool dispatchKeyEvent(android.view.KeyEvent @event)
		{
			throw new System.NotImplementedException();
		}

		private sealed class _OnClickListener_492 : android.view.View.OnClickListener
		{
			public _OnClickListener_492()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.View.OnClickListener")]
			public void onClick(android.view.View v)
			{
				throw new System.NotImplementedException();
			}
		}

		private android.view.View.OnClickListener mPauseListener = new _OnClickListener_492
			();

		[Sharpen.Stub]
		private void updatePausePlay()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void doPauseResume()
		{
			throw new System.NotImplementedException();
		}

		private sealed class _OnSeekBarChangeListener_530 : android.widget.SeekBar.OnSeekBarChangeListener
		{
			public _OnSeekBarChangeListener_530()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.widget.SeekBar.OnSeekBarChangeListener")]
			public void onStartTrackingTouch(android.widget.SeekBar bar)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.widget.SeekBar.OnSeekBarChangeListener")]
			public void onProgressChanged(android.widget.SeekBar bar, int progress, bool fromuser
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.widget.SeekBar.OnSeekBarChangeListener")]
			public void onStopTrackingTouch(android.widget.SeekBar bar)
			{
				throw new System.NotImplementedException();
			}
		}

		private android.widget.SeekBar.OnSeekBarChangeListener mSeekListener = new _OnSeekBarChangeListener_530
			();

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void setEnabled(bool enabled)
		{
			throw new System.NotImplementedException();
		}

		private sealed class _OnClickListener_595 : android.view.View.OnClickListener
		{
			public _OnClickListener_595()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.View.OnClickListener")]
			public void onClick(android.view.View v)
			{
				throw new System.NotImplementedException();
			}
		}

		private android.view.View.OnClickListener mRewListener = new _OnClickListener_595
			();

		private sealed class _OnClickListener_606 : android.view.View.OnClickListener
		{
			public _OnClickListener_606()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.View.OnClickListener")]
			public void onClick(android.view.View v)
			{
				throw new System.NotImplementedException();
			}
		}

		private android.view.View.OnClickListener mFfwdListener = new _OnClickListener_606
			();

		[Sharpen.Stub]
		private void installPrevNextListeners()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setPrevNextListeners(android.view.View.OnClickListener next, 
			android.view.View.OnClickListener prev)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public interface MediaPlayerControl
		{
			[Sharpen.Stub]
			void start();

			[Sharpen.Stub]
			void pause();

			[Sharpen.Stub]
			int getDuration();

			[Sharpen.Stub]
			int getCurrentPosition();

			[Sharpen.Stub]
			void seekTo(int pos);

			[Sharpen.Stub]
			bool isPlaying();

			[Sharpen.Stub]
			int getBufferPercentage();

			[Sharpen.Stub]
			bool canPause();

			[Sharpen.Stub]
			bool canSeekBackward();

			[Sharpen.Stub]
			bool canSeekForward();
		}
	}
}

using Sharpen;

namespace android.widget
{
	[Sharpen.Stub]
	public class VideoView : android.view.SurfaceView, android.widget.MediaController
		.MediaPlayerControl
	{
		private string TAG = "VideoView";

		private System.Uri mUri;

		private java.util.Map<string, string> mHeaders;

		private int mDuration;

		internal const int STATE_ERROR = -1;

		internal const int STATE_IDLE = 0;

		internal const int STATE_PREPARING = 1;

		internal const int STATE_PREPARED = 2;

		internal const int STATE_PLAYING = 3;

		internal const int STATE_PAUSED = 4;

		internal const int STATE_PLAYBACK_COMPLETED = 5;

		private int mCurrentState = STATE_IDLE;

		private int mTargetState = STATE_IDLE;

		private android.view.SurfaceHolder mSurfaceHolder = null;

		private android.media.MediaPlayer mMediaPlayer = null;

		private int mVideoWidth;

		private int mVideoHeight;

		private int mSurfaceWidth;

		private int mSurfaceHeight;

		private android.widget.MediaController mMediaController;

		private android.media.MediaPlayer.OnCompletionListener mOnCompletionListener;

		private android.media.MediaPlayer.OnPreparedListener mOnPreparedListener;

		private int mCurrentBufferPercentage;

		private android.media.MediaPlayer.OnErrorListener mOnErrorListener;

		private int mSeekWhenPrepared;

		private bool mCanPause;

		private bool mCanSeekBack;

		private bool mCanSeekForward;

		[Sharpen.Stub]
		public VideoView(android.content.Context context) : base(context)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public VideoView(android.content.Context context, android.util.AttributeSet attrs
			) : this(context, attrs, 0)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public VideoView(android.content.Context context, android.util.AttributeSet attrs
			, int defStyle) : base(context, attrs, defStyle)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onMeasure(int widthMeasureSpec, int heightMeasureSpec
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int resolveAdjustedSize(int desiredSize, int measureSpec)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void initVideoView()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setVideoPath(string path)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setVideoURI(System.Uri uri)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setVideoURI(System.Uri uri, java.util.Map<string, string> headers
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void stopPlayback()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void openVideo()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setMediaController(android.widget.MediaController controller)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void attachMediaController()
		{
			throw new System.NotImplementedException();
		}

		private sealed class _OnVideoSizeChangedListener_264 : android.media.MediaPlayer.
			OnVideoSizeChangedListener
		{
			public _OnVideoSizeChangedListener_264()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.media.MediaPlayer.OnVideoSizeChangedListener"
				)]
			public void onVideoSizeChanged(android.media.MediaPlayer mp, int width, int height
				)
			{
				throw new System.NotImplementedException();
			}
		}

		internal android.media.MediaPlayer.OnVideoSizeChangedListener mSizeChangedListener
			 = new _OnVideoSizeChangedListener_264();

		private sealed class _OnPreparedListener_274 : android.media.MediaPlayer.OnPreparedListener
		{
			public _OnPreparedListener_274()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.media.MediaPlayer.OnPreparedListener")]
			public void onPrepared(android.media.MediaPlayer mp)
			{
				throw new System.NotImplementedException();
			}
		}

		internal android.media.MediaPlayer.OnPreparedListener mPreparedListener = new _OnPreparedListener_274
			();

		private sealed class _OnCompletionListener_337 : android.media.MediaPlayer.OnCompletionListener
		{
			public _OnCompletionListener_337()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.media.MediaPlayer.OnCompletionListener")]
			public void onCompletion(android.media.MediaPlayer mp)
			{
				throw new System.NotImplementedException();
			}
		}

		private android.media.MediaPlayer.OnCompletionListener mCompletionListener = new 
			_OnCompletionListener_337();

		private sealed class _OnErrorListener_351 : android.media.MediaPlayer.OnErrorListener
		{
			public _OnErrorListener_351()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.media.MediaPlayer.OnErrorListener")]
			public bool onError(android.media.MediaPlayer mp, int framework_err, int impl_err
				)
			{
				throw new System.NotImplementedException();
			}
		}

		private android.media.MediaPlayer.OnErrorListener mErrorListener = new _OnErrorListener_351
			();

		private sealed class _OnBufferingUpdateListener_404 : android.media.MediaPlayer.OnBufferingUpdateListener
		{
			public _OnBufferingUpdateListener_404()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.media.MediaPlayer.OnBufferingUpdateListener"
				)]
			public void onBufferingUpdate(android.media.MediaPlayer mp, int percent)
			{
				throw new System.NotImplementedException();
			}
		}

		private android.media.MediaPlayer.OnBufferingUpdateListener mBufferingUpdateListener
			 = new _OnBufferingUpdateListener_404();

		[Sharpen.Stub]
		public virtual void setOnPreparedListener(android.media.MediaPlayer.OnPreparedListener
			 l)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setOnCompletionListener(android.media.MediaPlayer.OnCompletionListener
			 l)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setOnErrorListener(android.media.MediaPlayer.OnErrorListener 
			l)
		{
			throw new System.NotImplementedException();
		}

		private sealed class _Callback_446 : android.view.SurfaceHolderClass.Callback
		{
			public _Callback_446()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.SurfaceHolder.Callback")]
			public void surfaceChanged(android.view.SurfaceHolder holder, int format, int w, 
				int h)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.SurfaceHolder.Callback")]
			public void surfaceCreated(android.view.SurfaceHolder holder)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.SurfaceHolder.Callback")]
			public void surfaceDestroyed(android.view.SurfaceHolder holder)
			{
				throw new System.NotImplementedException();
			}
		}

		internal android.view.SurfaceHolderClass.Callback mSHCallback = new _Callback_446
			();

		[Sharpen.Stub]
		private void release(bool cleartargetstate)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool onTouchEvent(android.view.MotionEvent ev)
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
		public override bool onKeyDown(int keyCode, android.view.KeyEvent @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void toggleMediaControlsVisiblity()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.widget.MediaController.MediaPlayerControl"
			)]
		public virtual void start()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.widget.MediaController.MediaPlayerControl"
			)]
		public virtual void pause()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void suspend()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void resume()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.widget.MediaController.MediaPlayerControl"
			)]
		public virtual int getDuration()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.widget.MediaController.MediaPlayerControl"
			)]
		public virtual int getCurrentPosition()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.widget.MediaController.MediaPlayerControl"
			)]
		public virtual void seekTo(int msec)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.widget.MediaController.MediaPlayerControl"
			)]
		public virtual bool isPlaying()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.widget.MediaController.MediaPlayerControl"
			)]
		public virtual int getBufferPercentage()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private bool isInPlaybackState()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.widget.MediaController.MediaPlayerControl"
			)]
		public virtual bool canPause()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.widget.MediaController.MediaPlayerControl"
			)]
		public virtual bool canSeekBackward()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.widget.MediaController.MediaPlayerControl"
			)]
		public virtual bool canSeekForward()
		{
			throw new System.NotImplementedException();
		}
	}
}

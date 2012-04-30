using Sharpen;

namespace android.widget.@internal
{
	[Sharpen.Stub]
	public class TransportControlView : android.widget.FrameLayout, android.view.View
		.OnClickListener, android.widget.@internal.LockScreenWidgetInterface
	{
		internal const int MSG_UPDATE_STATE = 100;

		internal const int MSG_SET_METADATA = 101;

		internal const int MSG_SET_TRANSPORT_CONTROLS = 102;

		internal const int MSG_SET_ARTWORK = 103;

		internal const int MSG_SET_GENERATION_ID = 104;

		internal const int MAXDIM = 512;

		internal const int DISPLAY_TIMEOUT_MS = 5000;

		internal const bool DEBUG = false;

		internal const string TAG = "TransportControlView";

		private android.widget.ImageView mAlbumArt;

		private android.widget.TextView mTrackTitle;

		private android.widget.ImageView mBtnPrev;

		private android.widget.ImageView mBtnPlay;

		private android.widget.ImageView mBtnNext;

		private int mClientGeneration;

		private android.widget.@internal.TransportControlView.Metadata mMetadata;

		private bool mAttached;

		private android.app.PendingIntent mClientIntent;

		private int mTransportControlFlags;

		private int mCurrentPlayState;

		private android.media.AudioManager mAudioManager;

		private android.widget.@internal.LockScreenWidgetCallback mWidgetCallbacks;

		private android.widget.@internal.TransportControlView.IRemoteControlDisplayWeak mIRCD;

		private android.os.Bundle mPopulateMetadataWhenAttached = null;

		private sealed class _Handler_91 : android.os.Handler
		{
			public _Handler_91()
			{
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.os.Handler")]
			public override void handleMessage(android.os.Message msg)
			{
				throw new System.NotImplementedException();
			}
		}

		private android.os.Handler mHandler = new _Handler_91();

		[Sharpen.Stub]
		private class IRemoteControlDisplayWeak : android.media.IRemoteControlDisplayClass
			.Stub
		{
			internal java.lang.@ref.WeakReference<android.os.Handler> mLocalHandler;

			[Sharpen.Stub]
			internal IRemoteControlDisplayWeak(android.os.Handler handler)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.media.IRemoteControlDisplay")]
			public override void setPlaybackState(int generationId, int state, long stateChangeTimeMs
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.media.IRemoteControlDisplay")]
			public override void setMetadata(int generationId, android.os.Bundle metadata)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.media.IRemoteControlDisplay")]
			public override void setTransportControlFlags(int generationId, int flags)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.media.IRemoteControlDisplay")]
			public override void setArtwork(int generationId, android.graphics.Bitmap bitmap)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.media.IRemoteControlDisplay")]
			public override void setAllMetadata(int generationId, android.os.Bundle metadata, 
				android.graphics.Bitmap bitmap)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.media.IRemoteControlDisplay")]
			public override void setCurrentClientId(int clientGeneration, android.app.PendingIntent
				 mediaIntent, bool clearing)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public TransportControlView(android.content.Context context, android.util.AttributeSet
			 attrs) : base(context, attrs)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void updateTransportControls(int transportControlFlags)
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
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onMeasure(int widthMeasureSpec, int heightMeasureSpec
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal class Metadata
		{
			private string artist;

			private string trackTitle;

			private string albumTitle;

			private android.graphics.Bitmap bitmap;

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override string ToString()
			{
				throw new System.NotImplementedException();
			}

			internal Metadata(TransportControlView _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly TransportControlView _enclosing;
		}

		[Sharpen.Stub]
		private string getMdString(android.os.Bundle data, int id)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void updateMetadata(android.os.Bundle data)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void populateMetadata()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void setVisibilityBasedOnFlag(android.view.View view, int flags, int
			 flag)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void updatePlayPauseState(int state)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal class SavedState : android.view.View.BaseSavedState
		{
			internal bool wasShowing;

			[Sharpen.Stub]
			internal SavedState(android.os.Parcelable superState) : base(superState)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			private SavedState(android.os.Parcel @in) : base(@in)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.view.AbsSavedState")]
			public override void writeToParcel(android.os.Parcel @out, int flags)
			{
				throw new System.NotImplementedException();
			}

			private sealed class _Creator_397 : android.os.ParcelableClass.Creator<android.widget.@internal.TransportControlView
				.SavedState>
			{
				public _Creator_397()
				{
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.widget.@internal.TransportControlView.SavedState createFromParcel(
					android.os.Parcel @in)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.widget.@internal.TransportControlView.SavedState[] newArray(int size
					)
				{
					throw new System.NotImplementedException();
				}
			}

			internal static readonly android.os.ParcelableClass.Creator<android.widget.@internal.TransportControlView
				.SavedState> CREATOR = new _Creator_397();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override android.os.Parcelable onSaveInstanceState()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onRestoreInstanceState(android.os.Parcelable state
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.View.OnClickListener")]
		public virtual void onClick(android.view.View v)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void sendMediaButtonClick(int keyCode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"com.android.internal.widget.LockScreenWidgetInterface"
			)]
		public virtual void setCallback(android.widget.@internal.LockScreenWidgetCallback
			 callback)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"com.android.internal.widget.LockScreenWidgetInterface"
			)]
		public virtual bool providesClock()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private bool wasPlayingRecently(int state, long stateChangeTimeMs)
		{
			throw new System.NotImplementedException();
		}
	}
}

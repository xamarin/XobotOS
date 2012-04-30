using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	public class Notification : android.os.Parcelable
	{
		public const int DEFAULT_ALL = ~0;

		public const int DEFAULT_SOUND = 1;

		public const int DEFAULT_VIBRATE = 2;

		public const int DEFAULT_LIGHTS = 4;

		public long when;

		public int icon;

		public int iconLevel;

		public int number;

		public android.app.PendingIntent contentIntent;

		public android.app.PendingIntent deleteIntent;

		public android.app.PendingIntent fullScreenIntent;

		public java.lang.CharSequence tickerText;

		public android.widget.RemoteViews tickerView;

		public android.widget.RemoteViews contentView;

		public android.graphics.Bitmap largeIcon;

		public System.Uri sound;

		public const int STREAM_DEFAULT = -1;

		public int audioStreamType = STREAM_DEFAULT;

		public long[] vibrate;

		public int ledARGB;

		public int ledOnMS;

		public int ledOffMS;

		public int defaults;

		public const int FLAG_SHOW_LIGHTS = unchecked((int)(0x00000001));

		public const int FLAG_ONGOING_EVENT = unchecked((int)(0x00000002));

		public const int FLAG_INSISTENT = unchecked((int)(0x00000004));

		public const int FLAG_ONLY_ALERT_ONCE = unchecked((int)(0x00000008));

		public const int FLAG_AUTO_CANCEL = unchecked((int)(0x00000010));

		public const int FLAG_NO_CLEAR = unchecked((int)(0x00000020));

		public const int FLAG_FOREGROUND_SERVICE = unchecked((int)(0x00000040));

		public const int FLAG_HIGH_PRIORITY = unchecked((int)(0x00000080));

		public int flags;

		[Sharpen.Stub]
		public Notification()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public Notification(android.content.Context context, int icon, java.lang.CharSequence
			 tickerText, long when, java.lang.CharSequence contentTitle, java.lang.CharSequence
			 contentText, android.content.Intent contentIntent)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"Use Builder instead.")]
		public Notification(int icon, java.lang.CharSequence tickerText, long when)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public Notification(android.os.Parcel parcel)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.app.Notification clone()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual int describeContents()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual void writeToParcel(android.os.Parcel parcel, int flags)
		{
			throw new System.NotImplementedException();
		}

		private sealed class _Creator_524 : android.os.ParcelableClass.Creator<android.app.Notification
			>
		{
			public _Creator_524()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.app.Notification createFromParcel(android.os.Parcel parcel)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.app.Notification[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.app.Notification
			> CREATOR = new _Creator_524();

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"Use Builder instead.")]
		public virtual void setLatestEventInfo(android.content.Context context, java.lang.CharSequence
			 contentTitle, java.lang.CharSequence contentText, android.app.PendingIntent contentIntent
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public class Builder
		{
			private android.content.Context mContext;

			private long mWhen;

			private int mSmallIcon;

			private int mSmallIconLevel;

			private int mNumber;

			private java.lang.CharSequence mContentTitle;

			private java.lang.CharSequence mContentText;

			private java.lang.CharSequence mContentInfo;

			private android.app.PendingIntent mContentIntent;

			private android.widget.RemoteViews mContentView;

			private android.app.PendingIntent mDeleteIntent;

			private android.app.PendingIntent mFullScreenIntent;

			private java.lang.CharSequence mTickerText;

			private android.widget.RemoteViews mTickerView;

			private android.graphics.Bitmap mLargeIcon;

			private System.Uri mSound;

			private int mAudioStreamType;

			private long[] mVibrate;

			private int mLedArgb;

			private int mLedOnMs;

			private int mLedOffMs;

			private int mDefaults;

			private int mFlags;

			private int mProgressMax;

			private int mProgress;

			private bool mProgressIndeterminate;

			[Sharpen.Stub]
			public Builder(android.content.Context context)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.Notification.Builder setWhen(long when)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.Notification.Builder setSmallIcon(int icon)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.Notification.Builder setSmallIcon(int icon, int level)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.Notification.Builder setContentTitle(java.lang.CharSequence
				 title)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.Notification.Builder setContentText(java.lang.CharSequence
				 text)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.Notification.Builder setNumber(int number)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.Notification.Builder setContentInfo(java.lang.CharSequence
				 info)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.Notification.Builder setProgress(int max, int progress
				, bool indeterminate)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.Notification.Builder setContent(android.widget.RemoteViews
				 views)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.Notification.Builder setContentIntent(android.app.PendingIntent
				 intent)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.Notification.Builder setDeleteIntent(android.app.PendingIntent
				 intent)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.Notification.Builder setFullScreenIntent(android.app.PendingIntent
				 intent, bool highPriority)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.Notification.Builder setTicker(java.lang.CharSequence 
				tickerText)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.Notification.Builder setTicker(java.lang.CharSequence 
				tickerText, android.widget.RemoteViews views)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.Notification.Builder setLargeIcon(android.graphics.Bitmap
				 icon)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.Notification.Builder setSound(System.Uri sound)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.Notification.Builder setSound(System.Uri sound, int streamType
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.Notification.Builder setVibrate(long[] pattern)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.Notification.Builder setLights(int argb, int onMs, int
				 offMs)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.Notification.Builder setOngoing(bool ongoing)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.Notification.Builder setOnlyAlertOnce(bool onlyAlertOnce
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.Notification.Builder setAutoCancel(bool autoCancel)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.Notification.Builder setDefaults(int defaults)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			private void setFlag(int mask, bool value)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			private android.widget.RemoteViews makeRemoteViews(int resId)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			private android.widget.RemoteViews makeContentView()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			private android.widget.RemoteViews makeTickerView()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.Notification getNotification()
			{
				throw new System.NotImplementedException();
			}
		}
	}
}

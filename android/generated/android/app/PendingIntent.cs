using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	public sealed class PendingIntent : android.os.Parcelable
	{
		private readonly android.content.IIntentSender mTarget;

		public const int FLAG_ONE_SHOT = 1 << 30;

		public const int FLAG_NO_CREATE = 1 << 29;

		public const int FLAG_CANCEL_CURRENT = 1 << 28;

		public const int FLAG_UPDATE_CURRENT = 1 << 27;

		[System.Serializable]
		[Sharpen.Stub]
		public class CanceledException : android.util.AndroidException
		{
			[Sharpen.Stub]
			public CanceledException()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public CanceledException(string name) : base(name)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public CanceledException(System.Exception cause) : base(cause)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public interface OnFinished
		{
			[Sharpen.Stub]
			void onSendFinished(android.app.PendingIntent pendingIntent, android.content.Intent
				 intent, int resultCode, string resultData, android.os.Bundle resultExtras);
		}

		[Sharpen.Stub]
		private class FinishedDispatcher : android.content.IIntentReceiverClass.Stub, java.lang.Runnable
		{
			internal readonly android.app.PendingIntent mPendingIntent;

			internal readonly android.app.PendingIntent.OnFinished mWho;

			internal readonly android.os.Handler mHandler;

			internal android.content.Intent mIntent;

			internal int mResultCode;

			internal string mResultData;

			internal android.os.Bundle mResultExtras;

			[Sharpen.Stub]
			internal FinishedDispatcher(android.app.PendingIntent pi, android.app.PendingIntent
				.OnFinished who, android.os.Handler handler)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.content.IIntentReceiver")]
			public override void performReceive(android.content.Intent intent, int resultCode
				, string data, android.os.Bundle extras, bool serialized, bool sticky)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public virtual void run()
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public static android.app.PendingIntent getActivity(android.content.Context context
			, int requestCode, android.content.Intent intent, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.app.PendingIntent getActivities(android.content.Context context
			, int requestCode, android.content.Intent[] intents, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.app.PendingIntent getBroadcast(android.content.Context context
			, int requestCode, android.content.Intent intent, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.app.PendingIntent getService(android.content.Context context
			, int requestCode, android.content.Intent intent, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.content.IntentSender getIntentSender()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void cancel()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void send()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void send(int code)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void send(android.content.Context context, int code, android.content.Intent
			 intent)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void send(int code, android.app.PendingIntent.OnFinished onFinished, android.os.Handler
			 handler)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void send(android.content.Context context, int code, android.content.Intent
			 intent, android.app.PendingIntent.OnFinished onFinished, android.os.Handler handler
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void send(android.content.Context context, int code, android.content.Intent
			 intent, android.app.PendingIntent.OnFinished onFinished, android.os.Handler handler
			, string requiredPermission)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public string getTargetPackage()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool isTargetedToPackage()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override bool Equals(object otherObj)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override int GetHashCode()
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
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public int describeContents()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public void writeToParcel(android.os.Parcel @out, int flags)
		{
			throw new System.NotImplementedException();
		}

		private sealed class _Creator_598 : android.os.ParcelableClass.Creator<android.app.PendingIntent
			>
		{
			public _Creator_598()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.app.PendingIntent createFromParcel(android.os.Parcel @in)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.app.PendingIntent[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.app.PendingIntent
			> CREATOR = new _Creator_598();

		[Sharpen.Stub]
		public static void writePendingIntentOrNullToParcel(android.app.PendingIntent sender
			, android.os.Parcel @out)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.app.PendingIntent readPendingIntentOrNullFromParcel(android.os.Parcel
			 @in)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal PendingIntent(android.content.IIntentSender target)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal PendingIntent(android.os.IBinder target)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.content.IIntentSender getTarget()
		{
			throw new System.NotImplementedException();
		}
	}
}

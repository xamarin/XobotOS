using Sharpen;

namespace android.content
{
	[Sharpen.Stub]
	public class IntentSender : android.os.Parcelable
	{
		private readonly android.content.IIntentSender mTarget;

		[System.Serializable]
		[Sharpen.Stub]
		public class SendIntentException : android.util.AndroidException
		{
			[Sharpen.Stub]
			public SendIntentException()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public SendIntentException(string name) : base(name)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public SendIntentException(System.Exception cause) : base(cause)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public interface OnFinished
		{
			[Sharpen.Stub]
			void onSendFinished(android.content.IntentSender IntentSender, android.content.Intent
				 intent, int resultCode, string resultData, android.os.Bundle resultExtras);
		}

		[Sharpen.Stub]
		private class FinishedDispatcher : android.content.IIntentReceiverClass.Stub, java.lang.Runnable
		{
			internal readonly android.content.IntentSender mIntentSender;

			internal readonly android.content.IntentSender.OnFinished mWho;

			internal readonly android.os.Handler mHandler;

			internal android.content.Intent mIntent;

			internal int mResultCode;

			internal string mResultData;

			internal android.os.Bundle mResultExtras;

			[Sharpen.Stub]
			internal FinishedDispatcher(android.content.IntentSender pi, android.content.IntentSender
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
		public virtual void sendIntent(android.content.Context context, int code, android.content.Intent
			 intent, android.content.IntentSender.OnFinished onFinished, android.os.Handler 
			handler)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void sendIntent(android.content.Context context, int code, android.content.Intent
			 intent, android.content.IntentSender.OnFinished onFinished, android.os.Handler 
			handler, string requiredPermission)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string getTargetPackage()
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
		public virtual int describeContents()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual void writeToParcel(android.os.Parcel @out, int flags)
		{
			throw new System.NotImplementedException();
		}

		private sealed class _Creator_264 : android.os.ParcelableClass.Creator<android.content.IntentSender
			>
		{
			public _Creator_264()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.IntentSender createFromParcel(android.os.Parcel @in)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.IntentSender[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.content.IntentSender
			> CREATOR = new _Creator_264();

		[Sharpen.Stub]
		public static void writeIntentSenderOrNullToParcel(android.content.IntentSender sender
			, android.os.Parcel @out)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.content.IntentSender readIntentSenderOrNullFromParcel(android.os.Parcel
			 @in)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.content.IIntentSender getTarget()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public IntentSender(android.content.IIntentSender target)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public IntentSender(android.os.IBinder target)
		{
			throw new System.NotImplementedException();
		}
	}
}

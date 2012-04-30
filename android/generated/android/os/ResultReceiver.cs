using Sharpen;

namespace android.os
{
	[Sharpen.Stub]
	public class ResultReceiver : android.os.Parcelable
	{
		internal readonly bool mLocal;

		internal readonly android.os.Handler mHandler;

		internal android.os.@internal.IResultReceiver mReceiver;

		[Sharpen.Stub]
		internal class MyRunnable : java.lang.Runnable
		{
			internal readonly int mResultCode;

			internal readonly android.os.Bundle mResultData;

			[Sharpen.Stub]
			internal MyRunnable(ResultReceiver _enclosing, int resultCode, android.os.Bundle 
				resultData)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public virtual void run()
			{
				throw new System.NotImplementedException();
			}

			private readonly ResultReceiver _enclosing;
		}

		[Sharpen.Stub]
		internal class MyResultReceiver : android.os.@internal.IResultReceiverClass.Stub
		{
			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"com.android.internal.os.IResultReceiver")]
			public override void send(int resultCode, android.os.Bundle resultData)
			{
				throw new System.NotImplementedException();
			}

			internal MyResultReceiver(ResultReceiver _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly ResultReceiver _enclosing;
		}

		[Sharpen.Stub]
		public ResultReceiver(android.os.Handler handler)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void send(int resultCode, android.os.Bundle resultData)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual void onReceiveResult(int resultCode, android.os.Bundle
			 resultData)
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

		[Sharpen.Stub]
		internal ResultReceiver(android.os.Parcel @in)
		{
			throw new System.NotImplementedException();
		}

		private sealed class _Creator_122 : android.os.ParcelableClass.Creator<android.os.ResultReceiver
			>
		{
			public _Creator_122()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.os.ResultReceiver createFromParcel(android.os.Parcel @in)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.os.ResultReceiver[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.os.ResultReceiver
			> CREATOR = new _Creator_122();
	}
}

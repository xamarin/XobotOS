using Sharpen;

namespace android.view.inputmethod
{
	[Sharpen.Stub]
	public sealed class InputBinding : android.os.Parcelable
	{
		internal const string TAG = "InputBinding";

		internal readonly android.view.inputmethod.InputConnection mConnection;

		internal readonly android.os.IBinder mConnectionToken;

		internal readonly int mUid;

		internal readonly int mPid;

		[Sharpen.Stub]
		public InputBinding(android.view.inputmethod.InputConnection conn, android.os.IBinder
			 connToken, int uid, int pid)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public InputBinding(android.view.inputmethod.InputConnection conn, android.view.inputmethod.InputBinding
			 binding)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal InputBinding(android.os.Parcel source)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.view.inputmethod.InputConnection getConnection()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.os.IBinder getConnectionToken()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int getUid()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int getPid()
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
		public void writeToParcel(android.os.Parcel dest, int flags)
		{
			throw new System.NotImplementedException();
		}

		private sealed class _Creator_139 : android.os.ParcelableClass.Creator<android.view.inputmethod.InputBinding
			>
		{
			public _Creator_139()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.view.inputmethod.InputBinding createFromParcel(android.os.Parcel source
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.view.inputmethod.InputBinding[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.view.inputmethod.InputBinding
			> CREATOR = new _Creator_139();

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public int describeContents()
		{
			throw new System.NotImplementedException();
		}
	}
}

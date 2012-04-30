using Sharpen;

namespace android.view
{
	[Sharpen.Stub]
	public sealed class InputChannel : android.os.Parcelable
	{
		internal const string TAG = "InputChannel";

		internal const bool DEBUG = false;

		private sealed class _Creator_36 : android.os.ParcelableClass.Creator<android.view.InputChannel
			>
		{
			public _Creator_36()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.view.InputChannel createFromParcel(android.os.Parcel source)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.view.InputChannel[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.view.InputChannel
			> CREATOR = new _Creator_36();

		private int mPtr;

		[Sharpen.Stub]
		private static android.view.InputChannel[] nativeOpenInputChannelPair(string name
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void nativeDispose(bool finalized)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void nativeTransferTo(android.view.InputChannel other)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void nativeReadFromParcel(android.os.Parcel parcel)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void nativeWriteToParcel(android.os.Parcel parcel)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private string nativeGetName()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public InputChannel()
		{
			throw new System.NotImplementedException();
		}

		~InputChannel()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.view.InputChannel[] openInputChannelPair(string name)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public string getName()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void dispose()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void transferTo(android.view.InputChannel outParameter)
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
		public void readFromParcel(android.os.Parcel @in)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public void writeToParcel(android.os.Parcel @out, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			throw new System.NotImplementedException();
		}
	}
}

using Sharpen;

namespace android.content.pm
{
	public class ParceledListSlice : ParceledListSlice<android.os.Parcelable>
	{ }

	[Sharpen.Stub]
	public class ParceledListSlice<T> : android.os.Parcelable where T:android.os.Parcelable
	{
		private const int MAX_IPC_SIZE = 256 * 1024;

		private android.os.Parcel mParcel;

		private int mNumItems;

		private bool mIsLastSlice;

		public ParceledListSlice()
		{
			throw new System.NotImplementedException();
		}

		private ParceledListSlice(android.os.Parcel p, int numItems, bool lastSlice)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual int describeContents()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual void writeToParcel(android.os.Parcel dest, int flags)
		{
			throw new System.NotImplementedException();
		}

		public virtual bool append(T item)
		{
			throw new System.NotImplementedException();
		}

		public virtual T populateList(System.Collections.Generic.IList<T> list, android.os.ParcelableClass
			.Creator<T> creator)
		{
			throw new System.NotImplementedException();
		}

		public virtual void setLastSlice(bool lastSlice)
		{
			throw new System.NotImplementedException();
		}

		public virtual bool isLastSlice()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private sealed class _Creator_143 : android.os.ParcelableClass.Creator<android.content.pm.ParceledListSlice<T>>
		{
			public _Creator_143()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.pm.ParceledListSlice<T> createFromParcel(android.os.Parcel @in)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.pm.ParceledListSlice<T>[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.content.pm.ParceledListSlice
			<T>> CREATOR = new _Creator_143();
	}
}

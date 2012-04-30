using Sharpen;

namespace android.os
{
	[Sharpen.Stub]
	public interface Parcelable
	{
		[Sharpen.Stub]
		int describeContents();

		[Sharpen.Stub]
		void writeToParcel(android.os.Parcel dest, int flags);
	}

	[Sharpen.Stub]
	public static class ParcelableClass
	{
		public const int PARCELABLE_WRITE_RETURN_VALUE = unchecked((int)(0x0001));

		public const int CONTENTS_FILE_DESCRIPTOR = unchecked((int)(0x0001));

		[Sharpen.Stub]
		public interface Creator<T>
		{
			[Sharpen.Stub]
			T createFromParcel(android.os.Parcel source);

			[Sharpen.Stub]
			T[] newArray(int size);
		}

		[Sharpen.Stub]
		public interface ClassLoaderCreator<T> : android.os.ParcelableClass.Creator<T>
		{
			[Sharpen.Stub]
			T createFromParcel(android.os.Parcel source, java.lang.ClassLoader loader);
		}
	}
}

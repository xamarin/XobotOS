using Sharpen;

namespace android.text
{
	/// <summary>
	/// Annotations are simple key-value pairs that are preserved across
	/// TextView save/restore cycles and can be used to keep application-specific
	/// data that needs to be maintained for regions of text.
	/// </summary>
	/// <remarks>
	/// Annotations are simple key-value pairs that are preserved across
	/// TextView save/restore cycles and can be used to keep application-specific
	/// data that needs to be maintained for regions of text.
	/// </remarks>
	[Sharpen.Sharpened]
	public class Annotation : android.text.ParcelableSpan
	{
		private readonly string mKey;

		private readonly string mValue;

		public Annotation(string key, string value)
		{
			mKey = key;
			mValue = value;
		}

		public Annotation(android.os.Parcel src)
		{
			mKey = src.readString();
			mValue = src.readString();
		}

		[Sharpen.ImplementsInterface(@"android.text.ParcelableSpan")]
		public virtual int getSpanTypeId()
		{
			return android.text.TextUtils.ANNOTATION;
		}

		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual int describeContents()
		{
			return 0;
		}

		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual void writeToParcel(android.os.Parcel dest, int flags)
		{
			dest.writeString(mKey);
			dest.writeString(mValue);
		}

		public virtual string getKey()
		{
			return mKey;
		}

		public virtual string getValue()
		{
			return mValue;
		}
	}
}

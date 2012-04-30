using Sharpen;

namespace android.content
{
	[Sharpen.Stub]
	public class ClipDescription : android.os.Parcelable
	{
		public const string MIMETYPE_TEXT_PLAIN = "text/plain";

		public const string MIMETYPE_TEXT_URILIST = "text/uri-list";

		public const string MIMETYPE_TEXT_INTENT = "text/vnd.android.intent";

		internal readonly java.lang.CharSequence mLabel;

		internal readonly string[] mMimeTypes;

		[Sharpen.Stub]
		public ClipDescription(java.lang.CharSequence label, string[] mimeTypes)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public ClipDescription(android.content.ClipDescription o)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static bool compareMimeTypes(string concreteType, string desiredType)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual java.lang.CharSequence getLabel()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool hasMimeType(string mimeType)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string[] filterMimeTypes(string mimeType)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getMimeTypeCount()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string getMimeType(int index)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void validate()
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
		public virtual void writeToParcel(android.os.Parcel dest, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal ClipDescription(android.os.Parcel @in)
		{
			throw new System.NotImplementedException();
		}

		private sealed class _Creator_196 : android.os.ParcelableClass.Creator<android.content.ClipDescription
			>
		{
			public _Creator_196()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.ClipDescription createFromParcel(android.os.Parcel source)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.ClipDescription[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.content.ClipDescription
			> CREATOR = new _Creator_196();
	}
}

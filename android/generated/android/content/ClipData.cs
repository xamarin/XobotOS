using Sharpen;

namespace android.content
{
	[Sharpen.Stub]
	public class ClipData : android.os.Parcelable
	{
		internal static readonly string[] MIMETYPES_TEXT_PLAIN = new string[] { android.content.ClipDescription
			.MIMETYPE_TEXT_PLAIN };

		internal static readonly string[] MIMETYPES_TEXT_URILIST = new string[] { android.content.ClipDescription
			.MIMETYPE_TEXT_URILIST };

		internal static readonly string[] MIMETYPES_TEXT_INTENT = new string[] { android.content.ClipDescription
			.MIMETYPE_TEXT_INTENT };

		internal readonly android.content.ClipDescription mClipDescription;

		internal readonly android.graphics.Bitmap mIcon;

		internal readonly java.util.ArrayList<android.content.ClipData.Item> mItems = new 
			java.util.ArrayList<android.content.ClipData.Item>();

		[Sharpen.Stub]
		public class Item
		{
			internal readonly java.lang.CharSequence mText;

			internal readonly android.content.Intent mIntent;

			internal readonly System.Uri mUri;

			[Sharpen.Stub]
			public Item(java.lang.CharSequence text)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public Item(android.content.Intent intent)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public Item(System.Uri uri)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public Item(java.lang.CharSequence text, android.content.Intent intent, System.Uri
				 uri)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual java.lang.CharSequence getText()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.content.Intent getIntent()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual System.Uri getUri()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual java.lang.CharSequence coerceToText(android.content.Context context
				)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public ClipData(java.lang.CharSequence label, string[] mimeTypes, android.content.ClipData
			.Item item)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public ClipData(android.content.ClipDescription description, android.content.ClipData
			.Item item)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.content.ClipData newPlainText(java.lang.CharSequence label, 
			java.lang.CharSequence text)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.content.ClipData newIntent(java.lang.CharSequence label, android.content.Intent
			 intent)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.content.ClipData newUri(android.content.ContentResolver resolver
			, java.lang.CharSequence label, System.Uri uri)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.content.ClipData newRawUri(java.lang.CharSequence label, System.Uri
			 uri)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.content.ClipDescription getDescription()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void addItem(android.content.ClipData.Item item)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.graphics.Bitmap getIcon()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getItemCount()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.content.ClipData.Item getItemAt(int index)
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
		internal ClipData(android.os.Parcel @in)
		{
			throw new System.NotImplementedException();
		}

		private sealed class _Creator_521 : android.os.ParcelableClass.Creator<android.content.ClipData
			>
		{
			public _Creator_521()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.ClipData createFromParcel(android.os.Parcel source)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.ClipData[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.content.ClipData
			> CREATOR = new _Creator_521();
	}
}

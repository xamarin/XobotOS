using Sharpen;

namespace android.content
{
	[Sharpen.Stub]
	public class ContentProviderOperation : android.os.Parcelable
	{
		public const int TYPE_INSERT = 1;

		public const int TYPE_UPDATE = 2;

		public const int TYPE_DELETE = 3;

		public const int TYPE_ASSERT = 4;

		private readonly int mType;

		private readonly System.Uri mUri;

		private readonly string mSelection;

		private readonly string[] mSelectionArgs;

		private readonly android.content.ContentValues mValues;

		private readonly int mExpectedCount;

		private readonly android.content.ContentValues mValuesBackReferences;

		private readonly java.util.Map<int, int> mSelectionArgsBackReferences;

		private readonly bool mYieldAllowed;

		internal const string TAG = "ContentProviderOperation";

		[Sharpen.Stub]
		private ContentProviderOperation(android.content.ContentProviderOperation.Builder
			 builder)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private ContentProviderOperation(android.os.Parcel source)
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
		public static android.content.ContentProviderOperation.Builder newInsert(System.Uri
			 uri)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.content.ContentProviderOperation.Builder newUpdate(System.Uri
			 uri)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.content.ContentProviderOperation.Builder newDelete(System.Uri
			 uri)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.content.ContentProviderOperation.Builder newAssertQuery(System.Uri
			 uri)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual System.Uri getUri()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isYieldAllowed()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getType()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isWriteOperation()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isReadOperation()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.content.ContentProviderResult apply(android.content.ContentProvider
			 provider, android.content.ContentProviderResult[] backRefs, int numBackRefs)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.content.ContentValues resolveValueBackReferences(android.content.ContentProviderResult
			[] backRefs, int numBackRefs)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string[] resolveSelectionArgsBackReferences(android.content.ContentProviderResult
			[] backRefs, int numBackRefs)
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
		private long backRefToValue(android.content.ContentProviderResult[] backRefs, int
			 numBackRefs, int backRefIndex)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual int describeContents()
		{
			throw new System.NotImplementedException();
		}

		private sealed class _Creator_380 : android.os.ParcelableClass.Creator<android.content.ContentProviderOperation
			>
		{
			public _Creator_380()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.ContentProviderOperation createFromParcel(android.os.Parcel
				 source)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.ContentProviderOperation[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.content.ContentProviderOperation
			> CREATOR = new _Creator_380();

		[Sharpen.Stub]
		public class Builder
		{
			private readonly int mType;

			private readonly System.Uri mUri;

			private string mSelection;

			private string[] mSelectionArgs;

			private android.content.ContentValues mValues;

			private int mExpectedCount;

			private android.content.ContentValues mValuesBackReferences;

			private java.util.Map<int, int> mSelectionArgsBackReferences;

			private bool mYieldAllowed;

			[Sharpen.Stub]
			private Builder(int type, System.Uri uri)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.content.ContentProviderOperation build()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.content.ContentProviderOperation.Builder withValueBackReferences
				(android.content.ContentValues backReferences)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.content.ContentProviderOperation.Builder withValueBackReference
				(string key, int previousResult)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.content.ContentProviderOperation.Builder withSelectionBackReference
				(int selectionArgIndex, int previousResult)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.content.ContentProviderOperation.Builder withValues(android.content.ContentValues
				 values)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.content.ContentProviderOperation.Builder withValue(string 
				key, object value)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.content.ContentProviderOperation.Builder withSelection(string
				 selection, string[] selectionArgs)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.content.ContentProviderOperation.Builder withExpectedCount
				(int count)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.content.ContentProviderOperation.Builder withYieldAllowed(
				bool yieldAllowed)
			{
				throw new System.NotImplementedException();
			}
		}
	}
}

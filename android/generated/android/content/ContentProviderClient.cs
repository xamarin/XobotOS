using Sharpen;

namespace android.content
{
	[Sharpen.Stub]
	public class ContentProviderClient
	{
		private readonly android.content.IContentProvider mContentProvider;

		private readonly android.content.ContentResolver mContentResolver;

		[Sharpen.Stub]
		internal ContentProviderClient(android.content.ContentResolver contentResolver, android.content.IContentProvider
			 contentProvider)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.database.Cursor query(System.Uri url, string[] projection, 
			string selection, string[] selectionArgs, string sortOrder)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string getType(System.Uri url)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string[] getStreamTypes(System.Uri url, string mimeTypeFilter)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual System.Uri insert(System.Uri url, android.content.ContentValues initialValues
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int bulkInsert(System.Uri url, android.content.ContentValues[] initialValues
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int delete(System.Uri url, string selection, string[] selectionArgs
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int update(System.Uri url, android.content.ContentValues values, string
			 selection, string[] selectionArgs)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.os.ParcelFileDescriptor openFile(System.Uri url, string mode
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.content.res.AssetFileDescriptor openAssetFile(System.Uri url
			, string mode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.content.res.AssetFileDescriptor openTypedAssetFileDescriptor(System.Uri
			 uri, string mimeType, android.os.Bundle opts)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.content.ContentProviderResult[] applyBatch(java.util.ArrayList
			<android.content.ContentProviderOperation> operations)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool release()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.content.ContentProvider getLocalContentProvider()
		{
			throw new System.NotImplementedException();
		}
	}
}

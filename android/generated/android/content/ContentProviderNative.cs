using Sharpen;

namespace android.content
{
	[Sharpen.Stub]
	public abstract class ContentProviderNative : android.os.Binder, android.content.IContentProvider
	{
		internal const string TAG = "ContentProvider";

		[Sharpen.Stub]
		public ContentProviderNative()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.content.IContentProvider asInterface(android.os.IBinder obj
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public abstract string getProviderName();

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.os.Binder")]
		protected internal override bool onTransact(int code, android.os.Parcel data, android.os.Parcel
			 reply, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.IInterface")]
		public virtual android.os.IBinder asBinder()
		{
			throw new System.NotImplementedException();
		}

		public abstract android.content.ContentProviderResult[] applyBatch(java.util.ArrayList
			<android.content.ContentProviderOperation> arg1);

		public abstract int bulkInsert(System.Uri arg1, android.content.ContentValues[] arg2
			);

		public abstract android.os.Bundle call(string arg1, string arg2, android.os.Bundle
			 arg3);

		public abstract int delete(System.Uri arg1, string arg2, string[] arg3);

		public abstract string[] getStreamTypes(System.Uri arg1, string arg2);

		public abstract string getType(System.Uri arg1);

		public abstract System.Uri insert(System.Uri arg1, android.content.ContentValues 
			arg2);

		public abstract android.content.res.AssetFileDescriptor openAssetFile(System.Uri 
			arg1, string arg2);

		public abstract android.os.ParcelFileDescriptor openFile(System.Uri arg1, string 
			arg2);

		public abstract android.content.res.AssetFileDescriptor openTypedAssetFile(System.Uri
			 arg1, string arg2, android.os.Bundle arg3);

		public abstract android.database.Cursor query(System.Uri arg1, string[] arg2, string
			 arg3, string[] arg4, string arg5);

		public abstract int update(System.Uri arg1, android.content.ContentValues arg2, string
			 arg3, string[] arg4);
	}

	[Sharpen.Stub]
	internal sealed class ContentProviderProxy : android.content.IContentProvider
	{
		[Sharpen.Stub]
		public ContentProviderProxy(android.os.IBinder remote)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.IInterface")]
		public android.os.IBinder asBinder()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.IContentProvider")]
		public android.database.Cursor query(System.Uri url, string[] projection, string 
			selection, string[] selectionArgs, string sortOrder)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.IContentProvider")]
		public string getType(System.Uri url)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.IContentProvider")]
		public System.Uri insert(System.Uri url, android.content.ContentValues values)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.IContentProvider")]
		public int bulkInsert(System.Uri url, android.content.ContentValues[] values)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.IContentProvider")]
		public android.content.ContentProviderResult[] applyBatch(java.util.ArrayList<android.content.ContentProviderOperation
			> operations)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.IContentProvider")]
		public int delete(System.Uri url, string selection, string[] selectionArgs)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.IContentProvider")]
		public int update(System.Uri url, android.content.ContentValues values, string selection
			, string[] selectionArgs)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.IContentProvider")]
		public android.os.ParcelFileDescriptor openFile(System.Uri url, string mode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.IContentProvider")]
		public android.content.res.AssetFileDescriptor openAssetFile(System.Uri url, string
			 mode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.IContentProvider")]
		public android.os.Bundle call(string method, string request, android.os.Bundle args
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.IContentProvider")]
		public string[] getStreamTypes(System.Uri url, string mimeTypeFilter)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.IContentProvider")]
		public android.content.res.AssetFileDescriptor openTypedAssetFile(System.Uri url, 
			string mimeType, android.os.Bundle opts)
		{
			throw new System.NotImplementedException();
		}

		private android.os.IBinder mRemote;
	}
}

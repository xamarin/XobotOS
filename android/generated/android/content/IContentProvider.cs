using Sharpen;

namespace android.content
{
	[Sharpen.Stub]
	public interface IContentProvider : android.os.IInterface
	{
		[Sharpen.Stub]
		android.database.Cursor query(System.Uri url, string[] projection, string selection
			, string[] selectionArgs, string sortOrder);

		[Sharpen.Stub]
		string getType(System.Uri url);

		[Sharpen.Stub]
		System.Uri insert(System.Uri url, android.content.ContentValues initialValues);

		[Sharpen.Stub]
		int bulkInsert(System.Uri url, android.content.ContentValues[] initialValues);

		[Sharpen.Stub]
		int delete(System.Uri url, string selection, string[] selectionArgs);

		[Sharpen.Stub]
		int update(System.Uri url, android.content.ContentValues values, string selection
			, string[] selectionArgs);

		[Sharpen.Stub]
		android.os.ParcelFileDescriptor openFile(System.Uri url, string mode);

		[Sharpen.Stub]
		android.content.res.AssetFileDescriptor openAssetFile(System.Uri url, string mode
			);

		[Sharpen.Stub]
		android.content.ContentProviderResult[] applyBatch(java.util.ArrayList<android.content.ContentProviderOperation
			> operations);

		[Sharpen.Stub]
		android.os.Bundle call(string method, string arg, android.os.Bundle extras);

		[Sharpen.Stub]
		string[] getStreamTypes(System.Uri url, string mimeTypeFilter);

		[Sharpen.Stub]
		android.content.res.AssetFileDescriptor openTypedAssetFile(System.Uri url, string
			 mimeType, android.os.Bundle opts);
	}

	[Sharpen.Stub]
	public static class IContentProviderClass
	{
		public const string descriptor = "android.content.IContentProvider";

		public const int QUERY_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION;

		public const int GET_TYPE_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 1;

		public const int INSERT_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 2;

		public const int DELETE_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 3;

		public const int UPDATE_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 9;

		public const int BULK_INSERT_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 12;

		public const int OPEN_FILE_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 13;

		public const int OPEN_ASSET_FILE_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 14;

		public const int APPLY_BATCH_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 19;

		public const int CALL_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 20;

		public const int GET_STREAM_TYPES_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 21;

		public const int OPEN_TYPED_ASSET_FILE_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 22;
	}
}

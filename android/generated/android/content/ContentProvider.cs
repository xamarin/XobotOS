using Sharpen;

namespace android.content
{
	[Sharpen.Stub]
	public abstract class ContentProvider : android.content.ComponentCallbacks2
	{
		internal const string TAG = "ContentProvider";

		private android.content.Context mContext = null;

		private int mMyUid;

		private string mReadPermission;

		private string mWritePermission;

		private android.content.pm.PathPermission[] mPathPermissions;

		private bool mExported;

		private android.content.ContentProvider.Transport mTransport;

		[Sharpen.Stub]
		public ContentProvider()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public ContentProvider(android.content.Context context, string readPermission, string
			 writePermission, android.content.pm.PathPermission[] pathPermissions)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.content.ContentProvider coerceToLocalContentProvider(android.content.IContentProvider
			 abstractInterface)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal class Transport : android.content.ContentProviderNative
		{
			[Sharpen.Stub]
			internal virtual android.content.ContentProvider getContentProvider()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.content.ContentProviderNative")]
			public override string getProviderName()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.content.IContentProvider")]
			public override android.database.Cursor query(System.Uri uri, string[] projection
				, string selection, string[] selectionArgs, string sortOrder)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.content.IContentProvider")]
			public override string getType(System.Uri uri)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.content.IContentProvider")]
			public override System.Uri insert(System.Uri uri, android.content.ContentValues initialValues
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.content.IContentProvider")]
			public override int bulkInsert(System.Uri uri, android.content.ContentValues[] initialValues
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.content.IContentProvider")]
			public override android.content.ContentProviderResult[] applyBatch(java.util.ArrayList
				<android.content.ContentProviderOperation> operations)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.content.IContentProvider")]
			public override int delete(System.Uri uri, string selection, string[] selectionArgs
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.content.IContentProvider")]
			public override int update(System.Uri uri, android.content.ContentValues values, 
				string selection, string[] selectionArgs)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.content.IContentProvider")]
			public override android.os.ParcelFileDescriptor openFile(System.Uri uri, string mode
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.content.IContentProvider")]
			public override android.content.res.AssetFileDescriptor openAssetFile(System.Uri 
				uri, string mode)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.content.IContentProvider")]
			public override android.os.Bundle call(string method, string arg, android.os.Bundle
				 extras)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.content.IContentProvider")]
			public override string[] getStreamTypes(System.Uri uri, string mimeTypeFilter)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.content.IContentProvider")]
			public override android.content.res.AssetFileDescriptor openTypedAssetFile(System.Uri
				 uri, string mimeType, android.os.Bundle opts)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			private void enforceReadPermission(System.Uri uri)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			private bool hasWritePermission(System.Uri uri)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			private void enforceWritePermission(System.Uri uri)
			{
				throw new System.NotImplementedException();
			}

			internal Transport(ContentProvider _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly ContentProvider _enclosing;
		}

		[Sharpen.Stub]
		public android.content.Context getContext()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal void setReadPermission(string permission)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public string getReadPermission()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal void setWritePermission(string permission)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public string getWritePermission()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal void setPathPermissions(android.content.pm.PathPermission[] permissions
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.content.pm.PathPermission[] getPathPermissions()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public abstract bool onCreate();

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.ComponentCallbacks")]
		public virtual void onConfigurationChanged(android.content.res.Configuration newConfig
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.ComponentCallbacks")]
		public virtual void onLowMemory()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.ComponentCallbacks2")]
		public virtual void onTrimMemory(int level)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public abstract android.database.Cursor query(System.Uri uri, string[] projection
			, string selection, string[] selectionArgs, string sortOrder);

		[Sharpen.Stub]
		public abstract string getType(System.Uri uri);

		[Sharpen.Stub]
		public abstract System.Uri insert(System.Uri uri, android.content.ContentValues values
			);

		[Sharpen.Stub]
		public virtual int bulkInsert(System.Uri uri, android.content.ContentValues[] values
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public abstract int delete(System.Uri uri, string selection, string[] selectionArgs
			);

		[Sharpen.Stub]
		public abstract int update(System.Uri uri, android.content.ContentValues values, 
			string selection, string[] selectionArgs);

		[Sharpen.Stub]
		public virtual android.os.ParcelFileDescriptor openFile(System.Uri uri, string mode
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.content.res.AssetFileDescriptor openAssetFile(System.Uri uri
			, string mode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal android.os.ParcelFileDescriptor openFileHelper(System.Uri uri, 
			string mode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string[] getStreamTypes(System.Uri uri, string mimeTypeFilter)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.content.res.AssetFileDescriptor openTypedAssetFile(System.Uri
			 uri, string mimeTypeFilter, android.os.Bundle opts)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public interface PipeDataWriter<T>
		{
			[Sharpen.Stub]
			void writeDataToPipe(android.os.ParcelFileDescriptor output, System.Uri uri, string
				 mimeType, android.os.Bundle opts, T args);
		}

		[Sharpen.Stub]
		public virtual android.os.ParcelFileDescriptor openPipeHelper<T>(System.Uri uri, 
			string mimeType, android.os.Bundle opts, T args, android.content.ContentProvider.PipeDataWriter
			<T> func)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual bool isTemporary()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.content.IContentProvider getIContentProvider()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void attachInfo(android.content.Context context, android.content.pm.ProviderInfo
			 info)
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
		public virtual android.os.Bundle call(string method, string arg, android.os.Bundle
			 extras)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void shutdown()
		{
			throw new System.NotImplementedException();
		}
	}
}

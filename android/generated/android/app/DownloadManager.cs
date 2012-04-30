using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	public class DownloadManager
	{
		[Sharpen.Stub]
		public class Request
		{
			[Sharpen.Stub]
			public Request(System.Uri uri)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal Request(string uriString)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.DownloadManager.Request setDestinationUri(System.Uri uri
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.DownloadManager.Request setDestinationToSystemCache()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.DownloadManager.Request setDestinationInExternalFilesDir
				(android.content.Context context, string dirType, string subPath)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.DownloadManager.Request setDestinationInExternalPublicDir
				(string dirType, string subPath)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void allowScanningByMediaScanner()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.DownloadManager.Request addRequestHeader(string header
				, string value)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.DownloadManager.Request setTitle(java.lang.CharSequence
				 title)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.DownloadManager.Request setDescription(java.lang.CharSequence
				 description)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.DownloadManager.Request setMimeType(string mimeType)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[System.ObsoleteAttribute(@"use setNotificationVisibility(int)")]
			public virtual android.app.DownloadManager.Request setShowRunningNotification(bool
				 show)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.DownloadManager.Request setNotificationVisibility(int 
				visibility)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.DownloadManager.Request setAllowedNetworkTypes(int flags
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.DownloadManager.Request setAllowedOverRoaming(bool allowed
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.DownloadManager.Request setVisibleInDownloadsUi(bool isVisible
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal virtual android.content.ContentValues toContentValues(string packageName
				)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public class Query
		{
			[Sharpen.Stub]
			public virtual android.app.DownloadManager.Query setFilterById(params long[] ids)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.DownloadManager.Query setFilterByStatus(int flags)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.DownloadManager.Query setOnlyIncludeVisibleInDownloadsUi
				(bool value)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.DownloadManager.Query orderBy(string column, int direction
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal virtual android.database.Cursor runQuery(android.content.ContentResolver
				 resolver, string[] projection, System.Uri baseUri)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public DownloadManager(android.content.ContentResolver resolver, string packageName
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setAccessAllDownloads(bool accessAllDownloads)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual long enqueue(android.app.DownloadManager.Request request)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int markRowDeleted(params long[] ids)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int remove(params long[] ids)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.database.Cursor query(android.app.DownloadManager.Query query_1
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.os.ParcelFileDescriptor openDownloadedFile(long id)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual System.Uri getUriForDownloadedFile(long id)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string getMimeTypeForDownloadedFile(long id)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void restartDownload(params long[] ids)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static long getMaxBytesOverMobile(android.content.Context context)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static long getRecommendedMaxBytesOverMobile(android.content.Context context
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual long addCompletedDownload(string title, string description, bool isMediaScannerScannable
			, string mimeType, string path, long length, bool showNotification)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual System.Uri getDownloadUri(long id)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal static string getWhereClauseForIds(long[] ids)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal static string[] getWhereArgsForIds(long[] ids)
		{
			throw new System.NotImplementedException();
		}
	}
}

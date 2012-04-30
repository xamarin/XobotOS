using Sharpen;

namespace android.content
{
	[Sharpen.Stub]
	public abstract class AsyncQueryHandler : android.os.Handler
	{
		internal const string TAG = "AsyncQuery";

		internal const bool localLOGV = false;

		internal const int EVENT_ARG_QUERY = 1;

		internal const int EVENT_ARG_INSERT = 2;

		internal const int EVENT_ARG_UPDATE = 3;

		internal const int EVENT_ARG_DELETE = 4;

		internal readonly java.lang.@ref.WeakReference<android.content.ContentResolver> mResolver;

		private static android.os.Looper sLooper = null;

		private android.os.Handler mWorkerThreadHandler;

		[Sharpen.Stub]
		protected internal sealed class WorkerArgs
		{
			public System.Uri uri;

			public android.os.Handler handler;

			public string[] projection;

			public string selection;

			public string[] selectionArgs;

			public string orderBy;

			public object result;

			public object cookie;

			public android.content.ContentValues values;
		}

		[Sharpen.Stub]
		protected internal class WorkerHandler : android.os.Handler
		{
			[Sharpen.Stub]
			public WorkerHandler(AsyncQueryHandler _enclosing, android.os.Looper looper) : base
				(looper)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.os.Handler")]
			public override void handleMessage(android.os.Message msg)
			{
				throw new System.NotImplementedException();
			}

			private readonly AsyncQueryHandler _enclosing;
		}

		[Sharpen.Stub]
		public AsyncQueryHandler(android.content.ContentResolver cr) : base()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual android.os.Handler createHandler(android.os.Looper looper
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void startQuery(int token, object cookie, System.Uri uri, string[]
			 projection, string selection, string[] selectionArgs, string orderBy)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void cancelOperation(int token)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void startInsert(int token, object cookie, System.Uri uri, android.content.ContentValues
			 initialValues)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void startUpdate(int token, object cookie, System.Uri uri, android.content.ContentValues
			 values, string selection, string[] selectionArgs)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void startDelete(int token, object cookie, System.Uri uri, string selection
			, string[] selectionArgs)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual void onQueryComplete(int token, object cookie, android.database.Cursor
			 cursor)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual void onInsertComplete(int token, object cookie, System.Uri
			 uri)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual void onUpdateComplete(int token, object cookie, int result
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual void onDeleteComplete(int token, object cookie, int result
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.os.Handler")]
		public override void handleMessage(android.os.Message msg)
		{
			throw new System.NotImplementedException();
		}
	}
}

using Sharpen;

namespace android.content
{
	[Sharpen.Stub]
	public class CursorLoader : android.content.AsyncTaskLoader<android.database.Cursor
		>
	{
		internal readonly android.content.Loader<android.database.Cursor>.ForceLoadContentObserver
			 mObserver;

		internal System.Uri mUri;

		internal string[] mProjection;

		internal string mSelection;

		internal string[] mSelectionArgs;

		internal string mSortOrder;

		internal android.database.Cursor mCursor;

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.content.AsyncTaskLoader")]
		public override android.database.Cursor loadInBackground()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void registerContentObserver(android.database.Cursor cursor, android.database.ContentObserver
			 observer)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.content.Loader")]
		public override void deliverResult(android.database.Cursor cursor)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public CursorLoader(android.content.Context context) : base(context)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public CursorLoader(android.content.Context context, System.Uri uri, string[] projection
			, string selection, string[] selectionArgs, string sortOrder) : base(context)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.content.Loader")]
		protected internal override void onStartLoading()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.content.Loader")]
		protected internal override void onStopLoading()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.content.AsyncTaskLoader")]
		public override void onCanceled(android.database.Cursor cursor)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.content.Loader")]
		protected internal override void onReset()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual System.Uri getUri()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setUri(System.Uri uri)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string[] getProjection()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setProjection(string[] projection)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string getSelection()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setSelection(string selection)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string[] getSelectionArgs()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setSelectionArgs(string[] selectionArgs)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string getSortOrder()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setSortOrder(string sortOrder)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.content.Loader")]
		public override void dump(string prefix, java.io.FileDescriptor fd, java.io.PrintWriter
			 writer, string[] args)
		{
			throw new System.NotImplementedException();
		}
	}
}

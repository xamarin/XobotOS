using Sharpen;

namespace android.content
{
	[Sharpen.Stub]
	public class ContentQueryMap : java.util.Observable
	{
		private volatile android.database.Cursor mCursor;

		private string[] mColumnNames;

		private int mKeyColumn;

		private android.os.Handler mHandlerForUpdateNotifications = null;

		private bool mKeepUpdated = false;

		private java.util.Map<string, android.content.ContentValues> mValues = null;

		private android.database.ContentObserver mContentObserver;

		private bool mDirty = false;

		[Sharpen.Stub]
		public ContentQueryMap(android.database.Cursor cursor, string columnNameOfKey, bool
			 keepUpdated, android.os.Handler handlerForUpdateNotifications)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setKeepUpdated(bool keepUpdated)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.content.ContentValues getValues(string rowName)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void requery()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void readCursorIntoCache(android.database.Cursor cursor)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual java.util.Map<string, android.content.ContentValues> getRows()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void close()
		{
			throw new System.NotImplementedException();
		}

		~ContentQueryMap()
		{
			throw new System.NotImplementedException();
		}
	}
}

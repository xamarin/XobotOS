using Sharpen;

namespace android.database
{
	[Sharpen.Stub]
	public abstract class AbstractCursor : android.database.CrossProcessCursor
	{
		internal const string TAG = "Cursor";

		internal android.database.DataSetObservable mDataSetObservable = new android.database.DataSetObservable
			();

		internal android.database.ContentObservable mContentObservable = new android.database.ContentObservable
			();

		internal android.os.Bundle mExtras = android.os.Bundle.EMPTY;

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.Cursor")]
		public abstract int getCount();

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.Cursor")]
		public abstract string[] getColumnNames();

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.Cursor")]
		public abstract string getString(int column);

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.Cursor")]
		public abstract short getShort(int column);

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.Cursor")]
		public abstract int getInt(int column);

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.Cursor")]
		public abstract long getLong(int column);

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.Cursor")]
		public abstract float getFloat(int column);

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.Cursor")]
		public abstract double getDouble(int column);

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.Cursor")]
		public abstract bool isNull(int column);

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.Cursor")]
		public virtual int getType(int column)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.Cursor")]
		public virtual byte[] getBlob(int column)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.CrossProcessCursor")]
		public virtual android.database.CursorWindow getWindow()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.Cursor")]
		public virtual int getColumnCount()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.Cursor")]
		public virtual void deactivate()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual void onDeactivateOrClose()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.Cursor")]
		public virtual bool requery()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.Cursor")]
		public virtual bool isClosed()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.Cursor")]
		public virtual void close()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.CrossProcessCursor")]
		public virtual bool onMove(int oldPosition, int newPosition)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.Cursor")]
		public virtual void copyStringToBuffer(int columnIndex, android.database.CharArrayBuffer
			 buffer)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public AbstractCursor()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.Cursor")]
		public virtual int getPosition()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.Cursor")]
		public virtual bool moveToPosition(int position)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.CrossProcessCursor")]
		public virtual void fillWindow(int position, android.database.CursorWindow window
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.Cursor")]
		public virtual bool move(int offset)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.Cursor")]
		public virtual bool moveToFirst()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.Cursor")]
		public virtual bool moveToLast()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.Cursor")]
		public virtual bool moveToNext()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.Cursor")]
		public virtual bool moveToPrevious()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.Cursor")]
		public virtual bool isFirst()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.Cursor")]
		public virtual bool isLast()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.Cursor")]
		public virtual bool isBeforeFirst()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.Cursor")]
		public virtual bool isAfterLast()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.Cursor")]
		public virtual int getColumnIndex(string columnName)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.Cursor")]
		public virtual int getColumnIndexOrThrow(string columnName)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.Cursor")]
		public virtual string getColumnName(int columnIndex)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.Cursor")]
		public virtual void registerContentObserver(android.database.ContentObserver observer
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.Cursor")]
		public virtual void unregisterContentObserver(android.database.ContentObserver observer
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual void notifyDataSetChange()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual android.database.DataSetObservable getDataSetObservable
			()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.Cursor")]
		public virtual void registerDataSetObserver(android.database.DataSetObserver observer
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.Cursor")]
		public virtual void unregisterDataSetObserver(android.database.DataSetObserver observer
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual void onChange(bool selfChange)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.Cursor")]
		public virtual void setNotificationUri(android.content.ContentResolver cr, System.Uri
			 notifyUri)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual System.Uri getNotificationUri()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.Cursor")]
		public virtual bool getWantsAllOnMoveCalls()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setExtras(android.os.Bundle extras)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.Cursor")]
		public virtual android.os.Bundle getExtras()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.Cursor")]
		public virtual android.os.Bundle respond(android.os.Bundle extras)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"Always returns false since Cursors do not support updating rows"
			)]
		protected internal virtual bool isFieldUpdated(int columnIndex)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"Always returns null since Cursors do not support updating rows"
			)]
		protected internal virtual object getUpdatedField(int columnIndex)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual void checkPosition()
		{
			throw new System.NotImplementedException();
		}

		~AbstractCursor()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal class SelfContentObserver : android.database.ContentObserver
		{
			internal java.lang.@ref.WeakReference<android.database.AbstractCursor> mCursor;

			[Sharpen.Stub]
			public SelfContentObserver(android.database.AbstractCursor cursor) : base(null)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.database.ContentObserver")]
			public override bool deliverSelfNotifications()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.database.ContentObserver")]
			public override void onChange(bool selfChange)
			{
				throw new System.NotImplementedException();
			}
		}

		[System.ObsoleteAttribute(@"This is never updated by this class and should not be used"
			)]
		protected internal java.util.HashMap<long, java.util.Map<string, object>> mUpdatedRows;

		protected internal int mRowIdColumnIndex;

		protected internal int mPos;

		protected internal long mCurrentRowID;

		protected internal android.content.ContentResolver mContentResolver;

		protected internal bool mClosed = false;

		private System.Uri mNotifyUri;

		private android.database.ContentObserver mSelfObserver;

		private readonly object mSelfObserverLock = new object();

		private bool mSelfObserverRegistered;
	}
}

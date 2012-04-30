using Sharpen;

namespace android.database.@internal
{
	[Sharpen.Stub]
	public class SortCursor : android.database.AbstractCursor
	{
		internal const string TAG = "SortCursor";

		private android.database.Cursor mCursor;

		private android.database.Cursor[] mCursors;

		private int[] mSortColumns;

		private readonly int ROWCACHESIZE = 64;

		private int[] mRowNumCache;

		private int[] mCursorCache;

		private int[][] mCurRowNumCache;

		private int mLastCacheHit = -1;

		private sealed class _DataSetObserver_40 : android.database.DataSetObserver
		{
			public _DataSetObserver_40()
			{
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.database.DataSetObserver")]
			public override void onChanged()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.database.DataSetObserver")]
			public override void onInvalidated()
			{
				throw new System.NotImplementedException();
			}
		}

		private android.database.DataSetObserver mObserver = new _DataSetObserver_40();

		[Sharpen.Stub]
		public SortCursor(android.database.Cursor[] cursors, string sortcolumn)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.AbstractCursor")]
		public override int getCount()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.AbstractCursor")]
		public override bool onMove(int oldPosition, int newPosition)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.AbstractCursor")]
		public override string getString(int column)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.AbstractCursor")]
		public override short getShort(int column)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.AbstractCursor")]
		public override int getInt(int column)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.AbstractCursor")]
		public override long getLong(int column)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.AbstractCursor")]
		public override float getFloat(int column)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.AbstractCursor")]
		public override double getDouble(int column)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.AbstractCursor")]
		public override int getType(int column)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.AbstractCursor")]
		public override bool isNull(int column)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.AbstractCursor")]
		public override byte[] getBlob(int column)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.AbstractCursor")]
		public override string[] getColumnNames()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.AbstractCursor")]
		public override void deactivate()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.AbstractCursor")]
		public override void close()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.AbstractCursor")]
		public override void registerDataSetObserver(android.database.DataSetObserver observer
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.AbstractCursor")]
		public override void unregisterDataSetObserver(android.database.DataSetObserver observer
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.AbstractCursor")]
		public override bool requery()
		{
			throw new System.NotImplementedException();
		}
	}
}

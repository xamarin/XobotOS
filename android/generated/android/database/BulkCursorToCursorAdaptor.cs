using Sharpen;

namespace android.database
{
	[Sharpen.Stub]
	public sealed class BulkCursorToCursorAdaptor : android.database.AbstractWindowedCursor
	{
		internal const string TAG = "BulkCursor";

		private android.database.AbstractCursor.SelfContentObserver mObserverBridge;

		private android.database.IBulkCursor mBulkCursor;

		private int mCount;

		private string[] mColumns;

		private bool mWantsAllOnMoveCalls;

		[Sharpen.Stub]
		public void initialize(android.database.IBulkCursor bulkCursor, int count, int idIndex
			, bool wantsAllOnMoveCalls)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int findRowIdColumnIndex(string[] columnNames)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.database.IContentObserver getObserver()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void throwIfCursorIsClosed()
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
		public override bool requery()
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
		public override android.os.Bundle getExtras()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.AbstractCursor")]
		public override android.os.Bundle respond(android.os.Bundle extras)
		{
			throw new System.NotImplementedException();
		}

		public BulkCursorToCursorAdaptor()
		{
			mObserverBridge = new android.database.AbstractCursor.SelfContentObserver(this);
		}
	}
}

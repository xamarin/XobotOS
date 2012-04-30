using Sharpen;

namespace android.database
{
	[Sharpen.Stub]
	public abstract class BulkCursorNative : android.os.Binder, android.database.IBulkCursor
	{
		[Sharpen.Stub]
		public BulkCursorNative()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.database.IBulkCursor asInterface(android.os.IBinder obj)
		{
			throw new System.NotImplementedException();
		}

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

		public abstract void close();

		public abstract int count();

		public abstract void deactivate();

		public abstract string[] getColumnNames();

		public abstract android.os.Bundle getExtras();

		public abstract bool getWantsAllOnMoveCalls();

		public abstract android.database.CursorWindow getWindow(int arg1);

		public abstract void onMove(int arg1);

		public abstract int requery(android.database.IContentObserver arg1);

		public abstract android.os.Bundle respond(android.os.Bundle arg1);
	}

	[Sharpen.Stub]
	internal sealed class BulkCursorProxy : android.database.IBulkCursor
	{
		private android.os.IBinder mRemote;

		private android.os.Bundle mExtras;

		[Sharpen.Stub]
		public BulkCursorProxy(android.os.IBinder remote)
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
		[Sharpen.ImplementsInterface(@"android.database.IBulkCursor")]
		public android.database.CursorWindow getWindow(int startPos)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.IBulkCursor")]
		public void onMove(int position)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.IBulkCursor")]
		public int count()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.IBulkCursor")]
		public string[] getColumnNames()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.IBulkCursor")]
		public void deactivate()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.IBulkCursor")]
		public void close()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.IBulkCursor")]
		public int requery(android.database.IContentObserver observer)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.IBulkCursor")]
		public bool getWantsAllOnMoveCalls()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.IBulkCursor")]
		public android.os.Bundle getExtras()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.IBulkCursor")]
		public android.os.Bundle respond(android.os.Bundle extras)
		{
			throw new System.NotImplementedException();
		}
	}
}

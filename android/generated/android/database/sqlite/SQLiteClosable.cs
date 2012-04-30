using Sharpen;

namespace android.database.sqlite
{
	[Sharpen.Stub]
	public abstract class SQLiteClosable
	{
		private int mReferenceCount = 1;

		[Sharpen.Stub]
		protected internal abstract void onAllReferencesReleased();

		[Sharpen.Stub]
		protected internal virtual void onAllReferencesReleasedFromContainer()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void acquireReference()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void releaseReference()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void releaseReferenceFromContainer()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private string getObjInfo()
		{
			throw new System.NotImplementedException();
		}
	}
}

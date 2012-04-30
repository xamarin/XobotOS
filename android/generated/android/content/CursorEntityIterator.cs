using Sharpen;

namespace android.content
{
	[Sharpen.Stub]
	public abstract class CursorEntityIterator : android.content.EntityIterator
	{
		private readonly android.database.Cursor mCursor;

		private bool mIsClosed;

		[Sharpen.Stub]
		public CursorEntityIterator(android.database.Cursor cursor)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public abstract android.content.Entity getEntityAndIncrementCursor(android.database.Cursor
			 cursor);

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.util.Iterator")]
		public virtual bool hasNext()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.util.Iterator")]
		public virtual android.content.Entity next()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.util.Iterator")]
		public virtual void remove()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.EntityIterator")]
		public virtual void reset()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.EntityIterator")]
		public virtual void close()
		{
			throw new System.NotImplementedException();
		}
	}
}

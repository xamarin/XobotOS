using Sharpen;

namespace android.database
{
	[Sharpen.Stub]
	public class ContentObservable : android.database.Observable<android.database.ContentObserver
		>
	{
		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.Observable")]
		public override void registerObserver(android.database.ContentObserver observer)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void dispatchChange(bool selfChange)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void notifyChange(bool selfChange)
		{
			throw new System.NotImplementedException();
		}
	}
}

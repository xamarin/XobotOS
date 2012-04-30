using Sharpen;

namespace android.database.sqlite
{
	[Sharpen.Stub]
	public interface SQLiteTransactionListener
	{
		[Sharpen.Stub]
		void onBegin();

		[Sharpen.Stub]
		void onCommit();

		[Sharpen.Stub]
		void onRollback();
	}
}

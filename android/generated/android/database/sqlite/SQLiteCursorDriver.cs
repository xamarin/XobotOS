using Sharpen;

namespace android.database.sqlite
{
	[Sharpen.Stub]
	public interface SQLiteCursorDriver
	{
		[Sharpen.Stub]
		android.database.Cursor query(android.database.sqlite.SQLiteDatabase.CursorFactory
			 factory, string[] bindArgs);

		[Sharpen.Stub]
		void cursorDeactivated();

		[Sharpen.Stub]
		void cursorRequeried(android.database.Cursor cursor);

		[Sharpen.Stub]
		void cursorClosed();

		[Sharpen.Stub]
		void setBindArguments(string[] bindArgs);
	}
}

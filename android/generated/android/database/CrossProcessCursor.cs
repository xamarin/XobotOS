using Sharpen;

namespace android.database
{
	[Sharpen.Stub]
	public interface CrossProcessCursor : android.database.Cursor
	{
		[Sharpen.Stub]
		android.database.CursorWindow getWindow();

		[Sharpen.Stub]
		void fillWindow(int pos, android.database.CursorWindow winow);

		[Sharpen.Stub]
		bool onMove(int oldPosition, int newPosition);
	}
}

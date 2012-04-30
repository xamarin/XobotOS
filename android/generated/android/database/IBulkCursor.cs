using Sharpen;

namespace android.database
{
	[Sharpen.Stub]
	public interface IBulkCursor : android.os.IInterface
	{
		[Sharpen.Stub]
		android.database.CursorWindow getWindow(int startPos);

		[Sharpen.Stub]
		void onMove(int position);

		[Sharpen.Stub]
		int count();

		[Sharpen.Stub]
		string[] getColumnNames();

		[Sharpen.Stub]
		void deactivate();

		[Sharpen.Stub]
		void close();

		[Sharpen.Stub]
		int requery(android.database.IContentObserver observer);

		[Sharpen.Stub]
		bool getWantsAllOnMoveCalls();

		[Sharpen.Stub]
		android.os.Bundle getExtras();

		[Sharpen.Stub]
		android.os.Bundle respond(android.os.Bundle extras);
	}

	[Sharpen.Stub]
	public static class IBulkCursorClass
	{
		public const string descriptor = "android.content.IBulkCursor";

		public const int GET_CURSOR_WINDOW_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION;

		public const int COUNT_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 1;

		public const int GET_COLUMN_NAMES_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 2;

		public const int DEACTIVATE_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 5;

		public const int REQUERY_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 6;

		public const int ON_MOVE_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 7;

		public const int WANTS_ON_MOVE_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 8;

		public const int GET_EXTRAS_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 9;

		public const int RESPOND_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 10;

		public const int CLOSE_TRANSACTION = android.os.IBinderClass.FIRST_CALL_TRANSACTION
			 + 11;
	}
}

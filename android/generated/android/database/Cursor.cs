using Sharpen;

namespace android.database
{
	[Sharpen.Stub]
	public interface Cursor
	{
		[Sharpen.Stub]
		int getCount();

		[Sharpen.Stub]
		int getPosition();

		[Sharpen.Stub]
		bool move(int offset);

		[Sharpen.Stub]
		bool moveToPosition(int position);

		[Sharpen.Stub]
		bool moveToFirst();

		[Sharpen.Stub]
		bool moveToLast();

		[Sharpen.Stub]
		bool moveToNext();

		[Sharpen.Stub]
		bool moveToPrevious();

		[Sharpen.Stub]
		bool isFirst();

		[Sharpen.Stub]
		bool isLast();

		[Sharpen.Stub]
		bool isBeforeFirst();

		[Sharpen.Stub]
		bool isAfterLast();

		[Sharpen.Stub]
		int getColumnIndex(string columnName);

		[Sharpen.Stub]
		int getColumnIndexOrThrow(string columnName);

		[Sharpen.Stub]
		string getColumnName(int columnIndex);

		[Sharpen.Stub]
		string[] getColumnNames();

		[Sharpen.Stub]
		int getColumnCount();

		[Sharpen.Stub]
		byte[] getBlob(int columnIndex);

		[Sharpen.Stub]
		string getString(int columnIndex);

		[Sharpen.Stub]
		void copyStringToBuffer(int columnIndex, android.database.CharArrayBuffer buffer);

		[Sharpen.Stub]
		short getShort(int columnIndex);

		[Sharpen.Stub]
		int getInt(int columnIndex);

		[Sharpen.Stub]
		long getLong(int columnIndex);

		[Sharpen.Stub]
		float getFloat(int columnIndex);

		[Sharpen.Stub]
		double getDouble(int columnIndex);

		[Sharpen.Stub]
		int getType(int columnIndex);

		[Sharpen.Stub]
		bool isNull(int columnIndex);

		[Sharpen.Stub]
		void deactivate();

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"Don't use this. Just request a new cursor, so you can do this asynchronously and update your list view once the new cursor comes back."
			)]
		bool requery();

		[Sharpen.Stub]
		void close();

		[Sharpen.Stub]
		bool isClosed();

		[Sharpen.Stub]
		void registerContentObserver(android.database.ContentObserver observer);

		[Sharpen.Stub]
		void unregisterContentObserver(android.database.ContentObserver observer);

		[Sharpen.Stub]
		void registerDataSetObserver(android.database.DataSetObserver observer);

		[Sharpen.Stub]
		void unregisterDataSetObserver(android.database.DataSetObserver observer);

		[Sharpen.Stub]
		void setNotificationUri(android.content.ContentResolver cr, System.Uri uri);

		[Sharpen.Stub]
		bool getWantsAllOnMoveCalls();

		[Sharpen.Stub]
		android.os.Bundle getExtras();

		[Sharpen.Stub]
		android.os.Bundle respond(android.os.Bundle extras);
	}

	[Sharpen.Stub]
	public static class CursorClass
	{
		public const int FIELD_TYPE_NULL = 0;

		public const int FIELD_TYPE_INTEGER = 1;

		public const int FIELD_TYPE_FLOAT = 2;

		public const int FIELD_TYPE_STRING = 3;

		public const int FIELD_TYPE_BLOB = 4;
	}
}

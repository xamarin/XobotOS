using Sharpen;

namespace android.database
{
	[Sharpen.Stub]
	public class CursorWindow : android.database.sqlite.SQLiteClosable, android.os.Parcelable
	{
		internal const string STATS_TAG = "CursorWindowStats";

		private static readonly int sCursorWindowSize = android.content.res.Resources.getSystem
			().getInteger(android.@internal.R.integer.config_cursorWindowSize) * 1024;

		public int mWindowPtr;

		private int mStartPos;

		private readonly dalvik.system.CloseGuard mCloseGuard = dalvik.system.CloseGuard.
			get();

		[Sharpen.Stub]
		private static int nativeCreate(string name, int cursorWindowSize, bool localOnly
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static int nativeCreateFromParcel(android.os.Parcel parcel)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void nativeDispose(int windowPtr)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void nativeWriteToParcel(int windowPtr, android.os.Parcel parcel)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void nativeClear(int windowPtr)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static int nativeGetNumRows(int windowPtr)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static bool nativeSetNumColumns(int windowPtr, int columnNum)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static bool nativeAllocRow(int windowPtr)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void nativeFreeLastRow(int windowPtr)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static int nativeGetType(int windowPtr, int row, int column)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static byte[] nativeGetBlob(int windowPtr, int row, int column)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static string nativeGetString(int windowPtr, int row, int column)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static long nativeGetLong(int windowPtr, int row, int column)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static double nativeGetDouble(int windowPtr, int row, int column)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void nativeCopyStringToBuffer(int windowPtr, int row, int column, 
			android.database.CharArrayBuffer buffer)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static bool nativePutBlob(int windowPtr, byte[] value, int row, int column
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static bool nativePutString(int windowPtr, string value, int row, int column
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static bool nativePutLong(int windowPtr, long value, int row, int column)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static bool nativePutDouble(int windowPtr, double value, int row, int column
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static bool nativePutNull(int windowPtr, int row, int column)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public CursorWindow(string name, bool localWindow)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public CursorWindow(bool localWindow) : this(null, localWindow)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private CursorWindow(android.os.Parcel source)
		{
			throw new System.NotImplementedException();
		}

		~CursorWindow()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void dispose()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void close()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void clear()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getStartPosition()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setStartPosition(int pos)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getNumRows()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool setNumColumns(int columnNum)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool allocRow()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void freeLastRow()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"Use getType(int, int) instead.")]
		public virtual bool isNull(int row, int column)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"Use getType(int, int) instead.")]
		public virtual bool isBlob(int row, int column)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"Use getType(int, int) instead.")]
		public virtual bool isLong(int row, int column)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"Use getType(int, int) instead.")]
		public virtual bool isFloat(int row, int column)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"Use getType(int, int) instead.")]
		public virtual bool isString(int row, int column)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getType(int row, int column)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual byte[] getBlob(int row, int column)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string getString(int row, int column)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void copyStringToBuffer(int row, int column, android.database.CharArrayBuffer
			 buffer)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual long getLong(int row, int column)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual double getDouble(int row, int column)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual short getShort(int row, int column)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getInt(int row, int column)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual float getFloat(int row, int column)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool putBlob(byte[] value, int row, int column)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool putString(string value, int row, int column)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool putLong(long value, int row, int column)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool putDouble(double value, int row, int column)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool putNull(int row, int column)
		{
			throw new System.NotImplementedException();
		}

		private sealed class _Creator_694 : android.os.ParcelableClass.Creator<android.database.CursorWindow
			>
		{
			public _Creator_694()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.database.CursorWindow createFromParcel(android.os.Parcel source)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.database.CursorWindow[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.database.CursorWindow
			> CREATOR = new _Creator_694();

		[Sharpen.Stub]
		public static android.database.CursorWindow newFromParcel(android.os.Parcel p)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual int describeContents()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual void writeToParcel(android.os.Parcel dest, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.sqlite.SQLiteClosable")]
		protected internal override void onAllReferencesReleased()
		{
			throw new System.NotImplementedException();
		}

		private static readonly android.util.SparseIntArray sWindowToPidMap = new android.util.SparseIntArray
			();

		[Sharpen.Stub]
		private void recordNewWindow(int pid, int window)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void recordClosingOfWindow(int window)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private string printStats()
		{
			throw new System.NotImplementedException();
		}
	}
}

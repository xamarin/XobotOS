using Sharpen;

namespace android.database
{
	[Sharpen.Stub]
	public class MatrixCursor : android.database.AbstractCursor
	{
		private readonly string[] columnNames;

		private object[] data;

		private int rowCount = 0;

		private readonly int columnCount;

		[Sharpen.Stub]
		public MatrixCursor(string[] columnNames, int initialCapacity)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public MatrixCursor(string[] columnNames) : this(columnNames, 16)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private object get(int column)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.database.MatrixCursor.RowBuilder newRow()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void addRow(object[] columnValues)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void addRow<_T0>(java.lang.Iterable<_T0> columnValues)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void addRow<_T0>(java.util.ArrayList<_T0> columnValues, int start)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void ensureCapacity(int size)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public class RowBuilder
		{
			private int index;

			private readonly int endIndex;

			[Sharpen.Stub]
			internal RowBuilder(MatrixCursor _enclosing, int index, int endIndex)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.database.MatrixCursor.RowBuilder add(object columnValue)
			{
				throw new System.NotImplementedException();
			}

			private readonly MatrixCursor _enclosing;
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.AbstractCursor")]
		public override int getCount()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.AbstractCursor")]
		public override string[] getColumnNames()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.AbstractCursor")]
		public override string getString(int column)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.AbstractCursor")]
		public override short getShort(int column)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.AbstractCursor")]
		public override int getInt(int column)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.AbstractCursor")]
		public override long getLong(int column)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.AbstractCursor")]
		public override float getFloat(int column)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.AbstractCursor")]
		public override double getDouble(int column)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.AbstractCursor")]
		public override byte[] getBlob(int column)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.AbstractCursor")]
		public override int getType(int column)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.AbstractCursor")]
		public override bool isNull(int column)
		{
			throw new System.NotImplementedException();
		}
	}
}

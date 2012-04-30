using Sharpen;

namespace android.text
{
	[Sharpen.Sharpened]
	internal partial class PackedObjectVector<E>
	{
		private int mColumns;

		private int mRows;

		private int mRowGapStart;

		private int mRowGapLength;

		private object[] mValues;

		public PackedObjectVector(int columns)
		{
			mColumns = columns;
			mRows = android.util.@internal.ArrayUtils.idealIntArraySize(0) / mColumns;
			mRowGapStart = 0;
			mRowGapLength = mRows;
			mValues = new object[mRows * mColumns];
		}

		public virtual E getValue(int row, int column)
		{
			if (row >= mRowGapStart)
			{
				row += mRowGapLength;
			}
			object value = mValues[row * mColumns + column];
			return (E)value;
		}

		public virtual void setValue(int row, int column, E value)
		{
			if (row >= mRowGapStart)
			{
				row += mRowGapLength;
			}
			mValues[row * mColumns + column] = value;
		}

		public virtual void deleteAt(int row, int count)
		{
			moveRowGapTo(row + count);
			mRowGapStart -= count;
			mRowGapLength += count;
			if (mRowGapLength > size() * 2)
			{
			}
		}

		// dump();
		// growBuffer();
		public virtual int size()
		{
			return mRows - mRowGapLength;
		}

		public virtual int width()
		{
			return mColumns;
		}

		private void growBuffer()
		{
			int newsize = size() + 1;
			newsize = android.util.@internal.ArrayUtils.idealIntArraySize(newsize * mColumns)
				 / mColumns;
			object[] newvalues = new object[newsize * mColumns];
			int after = mRows - (mRowGapStart + mRowGapLength);
			System.Array.Copy(mValues, 0, newvalues, 0, mColumns * mRowGapStart);
			System.Array.Copy(mValues, (mRows - after) * mColumns, newvalues, (newsize - after
				) * mColumns, after * mColumns);
			mRowGapLength += newsize - mRows;
			mRows = newsize;
			mValues = newvalues;
		}

		private void moveRowGapTo(int where)
		{
			if (where == mRowGapStart)
			{
				return;
			}
			if (where > mRowGapStart)
			{
				int moving = where + mRowGapLength - (mRowGapStart + mRowGapLength);
				{
					for (int i = mRowGapStart + mRowGapLength; i < mRowGapStart + mRowGapLength + moving
						; i++)
					{
						int destrow = i - (mRowGapStart + mRowGapLength) + mRowGapStart;
						{
							for (int j = 0; j < mColumns; j++)
							{
								object val = mValues[i * mColumns + j];
								mValues[destrow * mColumns + j] = val;
							}
						}
					}
				}
			}
			else
			{
				int moving = mRowGapStart - where;
				{
					for (int i = where + moving - 1; i >= where; i--)
					{
						int destrow = i - where + mRowGapStart + mRowGapLength - moving;
						{
							for (int j = 0; j < mColumns; j++)
							{
								object val = mValues[i * mColumns + j];
								mValues[destrow * mColumns + j] = val;
							}
						}
					}
				}
			}
			mRowGapStart = where;
		}

		public virtual void dump()
		{
			{
				// XXX
				for (int i = 0; i < mRows; i++)
				{
					{
						for (int j = 0; j < mColumns; j++)
						{
							object val = mValues[i * mColumns + j];
							if (i < mRowGapStart || i >= mRowGapStart + mRowGapLength)
							{
								java.io.Console.Out.print(val + " ");
							}
							else
							{
								java.io.Console.Out.print("(" + val + ") ");
							}
						}
					}
					java.io.Console.Out.print(" << \n");
				}
			}
			java.io.Console.Out.print("-----\n\n");
		}
	}
}

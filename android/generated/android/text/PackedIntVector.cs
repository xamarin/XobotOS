using Sharpen;

namespace android.text
{
	/// <summary>
	/// PackedIntVector stores a two-dimensional array of integers,
	/// optimized for inserting and deleting rows and for
	/// offsetting the values in segments of a given column.
	/// </summary>
	/// <remarks>
	/// PackedIntVector stores a two-dimensional array of integers,
	/// optimized for inserting and deleting rows and for
	/// offsetting the values in segments of a given column.
	/// </remarks>
	[Sharpen.Sharpened]
	internal class PackedIntVector
	{
		private readonly int mColumns;

		private int mRows;

		private int mRowGapStart;

		private int mRowGapLength;

		private int[] mValues;

		private int[] mValueGap;

		/// <summary>
		/// Creates a new PackedIntVector with the specified width and
		/// a height of 0.
		/// </summary>
		/// <remarks>
		/// Creates a new PackedIntVector with the specified width and
		/// a height of 0.
		/// </remarks>
		/// <param name="columns">the width of the PackedIntVector.</param>
		public PackedIntVector(int columns)
		{
			// starts, followed by lengths
			mColumns = columns;
			mRows = 0;
			mRowGapStart = 0;
			mRowGapLength = mRows;
			mValues = null;
			mValueGap = new int[2 * columns];
		}

		/// <summary>Returns the value at the specified row and column.</summary>
		/// <remarks>Returns the value at the specified row and column.</remarks>
		/// <param name="row">the index of the row to return.</param>
		/// <param name="column">the index of the column to return.</param>
		/// <returns>the value stored at the specified position.</returns>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if the row is out of range
		/// (row &lt; 0 || row &gt;= size()) or the column is out of range
		/// (column &lt; 0 || column &gt;= width()).
		/// </exception>
		public virtual int getValue(int row, int column)
		{
			int columns = mColumns;
			if (((row | column) < 0) || (row >= size()) || (column >= columns))
			{
				throw new System.IndexOutOfRangeException(row + ", " + column);
			}
			if (row >= mRowGapStart)
			{
				row += mRowGapLength;
			}
			int value = mValues[row * columns + column];
			int[] valuegap = mValueGap;
			if (row >= valuegap[column])
			{
				value += valuegap[column + columns];
			}
			return value;
		}

		/// <summary>Sets the value at the specified row and column.</summary>
		/// <remarks>Sets the value at the specified row and column.</remarks>
		/// <param name="row">the index of the row to set.</param>
		/// <param name="column">the index of the column to set.</param>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if the row is out of range
		/// (row &lt; 0 || row &gt;= size()) or the column is out of range
		/// (column &lt; 0 || column &gt;= width()).
		/// </exception>
		public virtual void setValue(int row, int column, int value)
		{
			if (((row | column) < 0) || (row >= size()) || (column >= mColumns))
			{
				throw new System.IndexOutOfRangeException(row + ", " + column);
			}
			if (row >= mRowGapStart)
			{
				row += mRowGapLength;
			}
			int[] valuegap = mValueGap;
			if (row >= valuegap[column])
			{
				value -= valuegap[column + mColumns];
			}
			mValues[row * mColumns + column] = value;
		}

		/// <summary>Sets the value at the specified row and column.</summary>
		/// <remarks>
		/// Sets the value at the specified row and column.
		/// Private internal version: does not check args.
		/// </remarks>
		/// <param name="row">the index of the row to set.</param>
		/// <param name="column">the index of the column to set.</param>
		private void setValueInternal(int row, int column, int value)
		{
			if (row >= mRowGapStart)
			{
				row += mRowGapLength;
			}
			int[] valuegap = mValueGap;
			if (row >= valuegap[column])
			{
				value -= valuegap[column + mColumns];
			}
			mValues[row * mColumns + column] = value;
		}

		/// <summary>
		/// Increments all values in the specified column whose row &gt;= the
		/// specified row by the specified delta.
		/// </summary>
		/// <remarks>
		/// Increments all values in the specified column whose row &gt;= the
		/// specified row by the specified delta.
		/// </remarks>
		/// <param name="startRow">
		/// the row at which to begin incrementing.
		/// This may be == size(), which case there is no effect.
		/// </param>
		/// <param name="column">the index of the column to set.</param>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if the row is out of range
		/// (startRow &lt; 0 || startRow &gt; size()) or the column
		/// is out of range (column &lt; 0 || column &gt;= width()).
		/// </exception>
		public virtual void adjustValuesBelow(int startRow, int column, int delta)
		{
			if (((startRow | column) < 0) || (startRow > size()) || (column >= width()))
			{
				throw new System.IndexOutOfRangeException(startRow + ", " + column);
			}
			if (startRow >= mRowGapStart)
			{
				startRow += mRowGapLength;
			}
			moveValueGapTo(column, startRow);
			mValueGap[column + mColumns] += delta;
		}

		/// <summary>Inserts a new row of values at the specified row offset.</summary>
		/// <remarks>Inserts a new row of values at the specified row offset.</remarks>
		/// <param name="row">
		/// the row above which to insert the new row.
		/// This may be == size(), which case the new row is added
		/// at the end.
		/// </param>
		/// <param name="values">
		/// the new values to be added.  If this is null,
		/// a row of zeroes is added.
		/// </param>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if the row is out of range
		/// (row &lt; 0 || row &gt; size()) or if the length of the
		/// values array is too small (values.length &lt; width()).
		/// </exception>
		public virtual void insertAt(int row, int[] values)
		{
			if ((row < 0) || (row > size()))
			{
				throw new System.IndexOutOfRangeException("row " + row);
			}
			if ((values != null) && (values.Length < width()))
			{
				throw new System.IndexOutOfRangeException("value count " + values.Length);
			}
			moveRowGapTo(row);
			if (mRowGapLength == 0)
			{
				growBuffer();
			}
			mRowGapStart++;
			mRowGapLength--;
			if (values == null)
			{
				{
					for (int i = mColumns - 1; i >= 0; i--)
					{
						setValueInternal(row, i, 0);
					}
				}
			}
			else
			{
				{
					for (int i = mColumns - 1; i >= 0; i--)
					{
						setValueInternal(row, i, values[i]);
					}
				}
			}
		}

		/// <summary>
		/// Deletes the specified number of rows starting with the specified
		/// row.
		/// </summary>
		/// <remarks>
		/// Deletes the specified number of rows starting with the specified
		/// row.
		/// </remarks>
		/// <param name="row">the index of the first row to be deleted.</param>
		/// <param name="count">the number of rows to delete.</param>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if any of the rows to be deleted
		/// are out of range (row &lt; 0 || count &lt; 0 ||
		/// row + count &gt; size()).
		/// </exception>
		public virtual void deleteAt(int row, int count)
		{
			if (((row | count) < 0) || (row + count > size()))
			{
				throw new System.IndexOutOfRangeException(row + ", " + count);
			}
			moveRowGapTo(row + count);
			mRowGapStart -= count;
			mRowGapLength += count;
		}

		// TODO: Reclaim memory when the new height is much smaller
		// than the allocated size.
		/// <summary>Returns the number of rows in the PackedIntVector.</summary>
		/// <remarks>
		/// Returns the number of rows in the PackedIntVector.  This number
		/// will change as rows are inserted and deleted.
		/// </remarks>
		/// <returns>the number of rows.</returns>
		public virtual int size()
		{
			return mRows - mRowGapLength;
		}

		/// <summary>Returns the width of the PackedIntVector.</summary>
		/// <remarks>
		/// Returns the width of the PackedIntVector.  This number is set
		/// at construction and will not change.
		/// </remarks>
		/// <returns>the number of columns.</returns>
		public virtual int width()
		{
			return mColumns;
		}

		/// <summary>
		/// Grows the value and gap arrays to be large enough to store at least
		/// one more than the current number of rows.
		/// </summary>
		/// <remarks>
		/// Grows the value and gap arrays to be large enough to store at least
		/// one more than the current number of rows.
		/// </remarks>
		private void growBuffer()
		{
			int columns = mColumns;
			int newsize = size() + 1;
			newsize = android.util.@internal.ArrayUtils.idealIntArraySize(newsize * columns) 
				/ columns;
			int[] newvalues = new int[newsize * columns];
			int[] valuegap = mValueGap;
			int rowgapstart = mRowGapStart;
			int after = mRows - (rowgapstart + mRowGapLength);
			if (mValues != null)
			{
				System.Array.Copy(mValues, 0, newvalues, 0, columns * rowgapstart);
				System.Array.Copy(mValues, (mRows - after) * columns, newvalues, (newsize - after
					) * columns, after * columns);
			}
			{
				for (int i = 0; i < columns; i++)
				{
					if (valuegap[i] >= rowgapstart)
					{
						valuegap[i] += newsize - mRows;
						if (valuegap[i] < rowgapstart)
						{
							valuegap[i] = rowgapstart;
						}
					}
				}
			}
			mRowGapLength += newsize - mRows;
			mRows = newsize;
			mValues = newvalues;
		}

		/// <summary>
		/// Moves the gap in the values of the specified column to begin at
		/// the specified row.
		/// </summary>
		/// <remarks>
		/// Moves the gap in the values of the specified column to begin at
		/// the specified row.
		/// </remarks>
		private void moveValueGapTo(int column, int where)
		{
			int[] valuegap = mValueGap;
			int[] values = mValues;
			int columns = mColumns;
			if (where == valuegap[column])
			{
				return;
			}
			else
			{
				if (where > valuegap[column])
				{
					{
						for (int i = valuegap[column]; i < where; i++)
						{
							values[i * columns + column] += valuegap[column + columns];
						}
					}
				}
				else
				{
					{
						for (int i = where; i < valuegap[column]; i++)
						{
							values[i * columns + column] -= valuegap[column + columns];
						}
					}
				}
			}
			valuegap[column] = where;
		}

		/// <summary>Moves the gap in the row indices to begin at the specified row.</summary>
		/// <remarks>Moves the gap in the row indices to begin at the specified row.</remarks>
		private void moveRowGapTo(int where)
		{
			if (where == mRowGapStart)
			{
				return;
			}
			else
			{
				if (where > mRowGapStart)
				{
					int moving = where + mRowGapLength - (mRowGapStart + mRowGapLength);
					int columns = mColumns;
					int[] valuegap = mValueGap;
					int[] values = mValues;
					int gapend = mRowGapStart + mRowGapLength;
					{
						for (int i = gapend; i < gapend + moving; i++)
						{
							int destrow = i - gapend + mRowGapStart;
							{
								for (int j = 0; j < columns; j++)
								{
									int val = values[i * columns + j];
									if (i >= valuegap[j])
									{
										val += valuegap[j + columns];
									}
									if (destrow >= valuegap[j])
									{
										val -= valuegap[j + columns];
									}
									values[destrow * columns + j] = val;
								}
							}
						}
					}
				}
				else
				{
					int moving = mRowGapStart - where;
					int columns = mColumns;
					int[] valuegap = mValueGap;
					int[] values = mValues;
					int gapend = mRowGapStart + mRowGapLength;
					{
						for (int i = where + moving - 1; i >= where; i--)
						{
							int destrow = i - where + gapend - moving;
							{
								for (int j = 0; j < columns; j++)
								{
									int val = values[i * columns + j];
									if (i >= valuegap[j])
									{
										val += valuegap[j + columns];
									}
									if (destrow >= valuegap[j])
									{
										val -= valuegap[j + columns];
									}
									values[destrow * columns + j] = val;
								}
							}
						}
					}
				}
			}
			mRowGapStart = where;
		}
	}
}

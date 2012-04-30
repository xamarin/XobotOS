using System;

namespace android.text
{
	partial class PackedObjectVector<E>
	{
		public virtual void insertAt (int row, E[] values)
		{
			moveRowGapTo (row);
			if (mRowGapLength == 0) {
				growBuffer ();
			}
			mRowGapStart++;
			mRowGapLength--;
			if (values == null) {
				for (int i = 0; i < mColumns; i++) {
					setValue (row, i, default(E));
				}
			} else {
				for (int i_1 = 0; i_1 < mColumns; i_1++) {
					setValue (row, i_1, values [i_1]);
				}
			}
		}

	}
}


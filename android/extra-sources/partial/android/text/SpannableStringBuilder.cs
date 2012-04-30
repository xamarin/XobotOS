namespace android.text
{
	partial class SpannableStringBuilder
	{
		/// <summary>
		/// Return an array of the spans of the specified type that overlap
		/// the specified range of the buffer.
		/// </summary>
		/// <remarks>
		/// Return an array of the spans of the specified type that overlap
		/// the specified range of the buffer.  The kind may be Object.class to get
		/// a list of all the spans regardless of type.
		/// </remarks>
		public virtual T[] getSpans<T> (int queryStart, int queryEnd)
		{
			int spanCount = mSpanCount;
			object[] spans = mSpans;
			int[] starts = mSpanStarts;
			int[] ends = mSpanEnds;
			int[] flags = mSpanFlags;
			int gapstart = mGapStart;
			int gaplen = mGapLength;
			int count = 0;
			T[] ret = null;
			T ret1 = default(T);
			for (int i = 0; i < spanCount; i++) {
				int spanStart = starts [i];
				int spanEnd = ends [i];
				if (spanStart > gapstart) {
					spanStart -= gaplen;
				}
				if (spanEnd > gapstart) {
					spanEnd -= gaplen;
				}
				if (spanStart > queryEnd) {
					continue;
				}
				if (spanEnd < queryStart) {
					continue;
				}
				if (spanStart != spanEnd && queryStart != queryEnd) {
					if (spanStart == queryEnd) {
						continue;
					}
					if (spanEnd == queryStart) {
						continue;
					}
				}
				if (!typeof(T).IsInstanceOfType (spans [i])) {
					continue;
				}
				if (count == 0) {
					ret1 = (T)spans [i];
					count++;
				} else {
					if (count == 1) {
						ret = new T [spanCount - i + 1];
						ret [0] = ret1;
					}
					int prio = flags [i] & android.text.SpannedClass.SPAN_PRIORITY;
					if (prio != 0) {
						int j;
						for (j = 0; j < count; j++) {
							int p = getSpanFlags (ret [j]) & android.text.SpannedClass.SPAN_PRIORITY;
							if (prio > p) {
								break;
							}
						}
						System.Array.Copy (ret, j, ret, j + 1, count - j);
						ret [j] = (T)spans [i];
						count++;
					} else {
						ret [count++] = (T)spans [i];
					}
				}
			}
			if (count == 0) {
				return new T[0];
			}
			if (count == 1) {
				ret = new T[1];
				ret [0] = ret1;
				return ret;
			}
			if (count == ret.Length) {
				return ret;
			}
			T[] nret = new T[count];
			System.Array.Copy (ret, 0, nret, 0, count);
			return nret;
		}

		public int length()
		{
			return Length;
		}
	}
}


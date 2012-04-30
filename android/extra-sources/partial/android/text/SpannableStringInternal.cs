namespace android.text
{
	partial class SpannableStringInternal
	{
		public int Length {
			get { return mText.Length; }
		}

		public char this [int i] {
			get { return mText [i]; }
		}

		public virtual T[] getSpans<T> (int queryStart, int queryEnd)
		{
			int count = 0;
			int spanCount = mSpanCount;
			object[] spans = mSpans;
			int[] data = mSpanData;
			T[] ret = null;
			T ret1 = default(T);
			for (int i = 0; i < spanCount; i++) {
				int spanStart = data [i * COLUMNS + START];
				int spanEnd = data [i * COLUMNS + END];
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
					int prio = data [i * COLUMNS + FLAGS] & android.text.SpannedClass.SPAN_PRIORITY;
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
				ret = new T [1];
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
	}
}


using Sharpen;

namespace android.text
{
	[Sharpen.Sharpened]
	internal abstract partial class SpannableStringInternal
	{
		internal SpannableStringInternal(java.lang.CharSequence source, int start, int end
			)
		{
			if (start == 0 && end == source.Length)
			{
				mText = source.ToString();
			}
			else
			{
				mText = Sharpen.StringHelper.Substring(source.ToString(), start, end);
			}
			int initial = android.util.@internal.ArrayUtils.idealIntArraySize(0);
			mSpans = new object[initial];
			mSpanData = new int[initial * 3];
			if (source is android.text.Spanned)
			{
				android.text.Spanned sp = (android.text.Spanned)source;
				object[] spans = sp.getSpans<object>(start, end);
				{
					for (int i = 0; i < spans.Length; i++)
					{
						int st = sp.getSpanStart(spans[i]);
						int en = sp.getSpanEnd(spans[i]);
						int fl = sp.getSpanFlags(spans[i]);
						if (st < start)
						{
							st = start;
						}
						if (en > end)
						{
							en = end;
						}
						setSpan(spans[i], st - start, en - start, fl);
					}
				}
			}
		}

		public int length()
		{
			return mText.Length;
		}

		public char charAt(int i)
		{
			return mText[i];
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public sealed override string ToString()
		{
			return mText;
		}

		public void getChars(int start, int end, char[] dest, int off)
		{
			Sharpen.StringHelper.GetCharsForString(mText, start, end, dest, off);
		}

		public virtual void setSpan(object what, int start, int end, int flags)
		{
			int nstart = start;
			int nend = end;
			checkRange("setSpan", start, end);
			if ((flags & android.text.SpannedClass.SPAN_PARAGRAPH) == android.text.SpannedClass.SPAN_PARAGRAPH)
			{
				if (start != 0 && start != length())
				{
					char c = charAt(start - 1);
					if (c != '\n')
					{
						throw new java.lang.RuntimeException("PARAGRAPH span must start at paragraph boundary"
							 + " (" + start + " follows " + c + ")");
					}
				}
				if (end != 0 && end != length())
				{
					char c = charAt(end - 1);
					if (c != '\n')
					{
						throw new java.lang.RuntimeException("PARAGRAPH span must end at paragraph boundary"
							 + " (" + end + " follows " + c + ")");
					}
				}
			}
			int count = mSpanCount;
			object[] spans = mSpans;
			int[] data = mSpanData;
			{
				for (int i = 0; i < count; i++)
				{
					if (spans[i] == what)
					{
						int ostart = data[i * COLUMNS + START];
						int oend = data[i * COLUMNS + END];
						data[i * COLUMNS + START] = start;
						data[i * COLUMNS + END] = end;
						data[i * COLUMNS + FLAGS] = flags;
						sendSpanChanged(what, ostart, oend, nstart, nend);
						return;
					}
				}
			}
			if (mSpanCount + 1 >= mSpans.Length)
			{
				int newsize = android.util.@internal.ArrayUtils.idealIntArraySize(mSpanCount + 1);
				object[] newtags = new object[newsize];
				int[] newdata = new int[newsize * 3];
				System.Array.Copy(mSpans, 0, newtags, 0, mSpanCount);
				System.Array.Copy(mSpanData, 0, newdata, 0, mSpanCount * 3);
				mSpans = newtags;
				mSpanData = newdata;
			}
			mSpans[mSpanCount] = what;
			mSpanData[mSpanCount * COLUMNS + START] = start;
			mSpanData[mSpanCount * COLUMNS + END] = end;
			mSpanData[mSpanCount * COLUMNS + FLAGS] = flags;
			mSpanCount++;
			if (this is android.text.Spannable)
			{
				sendSpanAdded(what, nstart, nend);
			}
		}

		public virtual void removeSpan(object what)
		{
			int count = mSpanCount;
			object[] spans = mSpans;
			int[] data = mSpanData;
			{
				for (int i = count - 1; i >= 0; i--)
				{
					if (spans[i] == what)
					{
						int ostart = data[i * COLUMNS + START];
						int oend = data[i * COLUMNS + END];
						int c = count - (i + 1);
						System.Array.Copy(spans, i + 1, spans, i, c);
						System.Array.Copy(data, (i + 1) * COLUMNS, data, i * COLUMNS, c * COLUMNS);
						mSpanCount--;
						sendSpanRemoved(what, ostart, oend);
						return;
					}
				}
			}
		}

		public virtual int getSpanStart(object what)
		{
			int count = mSpanCount;
			object[] spans = mSpans;
			int[] data = mSpanData;
			{
				for (int i = count - 1; i >= 0; i--)
				{
					if (spans[i] == what)
					{
						return data[i * COLUMNS + START];
					}
				}
			}
			return -1;
		}

		public virtual int getSpanEnd(object what)
		{
			int count = mSpanCount;
			object[] spans = mSpans;
			int[] data = mSpanData;
			{
				for (int i = count - 1; i >= 0; i--)
				{
					if (spans[i] == what)
					{
						return data[i * COLUMNS + END];
					}
				}
			}
			return -1;
		}

		public virtual int getSpanFlags(object what)
		{
			int count = mSpanCount;
			object[] spans = mSpans;
			int[] data = mSpanData;
			{
				for (int i = count - 1; i >= 0; i--)
				{
					if (spans[i] == what)
					{
						return data[i * COLUMNS + FLAGS];
					}
				}
			}
			return 0;
		}

		public virtual int nextSpanTransition(int start, int limit, System.Type kind)
		{
			int count = mSpanCount;
			object[] spans = mSpans;
			int[] data = mSpanData;
			if (kind == null)
			{
				kind = typeof(object);
			}
			{
				for (int i = 0; i < count; i++)
				{
					int st = data[i * COLUMNS + START];
					int en = data[i * COLUMNS + END];
					if (st > start && st < limit && kind.IsInstanceOfType(spans[i]))
					{
						limit = st;
					}
					if (en > start && en < limit && kind.IsInstanceOfType(spans[i]))
					{
						limit = en;
					}
				}
			}
			return limit;
		}

		private void sendSpanAdded(object what, int start, int end)
		{
			android.text.SpanWatcher[] recip = getSpans<android.text.SpanWatcher>(start, end);
			int n = recip.Length;
			{
				for (int i = 0; i < n; i++)
				{
					recip[i].onSpanAdded((android.text.Spannable)this, what, start, end);
				}
			}
		}

		private void sendSpanRemoved(object what, int start, int end)
		{
			android.text.SpanWatcher[] recip = getSpans<android.text.SpanWatcher>(start, end);
			int n = recip.Length;
			{
				for (int i = 0; i < n; i++)
				{
					recip[i].onSpanRemoved((android.text.Spannable)this, what, start, end);
				}
			}
		}

		private void sendSpanChanged(object what, int s, int e, int st, int en)
		{
			android.text.SpanWatcher[] recip = getSpans<android.text.SpanWatcher>(System.Math.Min
				(s, st), System.Math.Max(e, en));
			int n = recip.Length;
			{
				for (int i = 0; i < n; i++)
				{
					recip[i].onSpanChanged((android.text.Spannable)this, what, s, e, st, en);
				}
			}
		}

		private static string region(int start, int end)
		{
			return "(" + start + " ... " + end + ")";
		}

		private void checkRange(string operation, int start, int end)
		{
			if (end < start)
			{
				throw new System.IndexOutOfRangeException(operation + " " + region(start, end) + 
					" has end before start");
			}
			int len = length();
			if (start > len || end > len)
			{
				throw new System.IndexOutOfRangeException(operation + " " + region(start, end) + 
					" ends beyond length " + len);
			}
			if (start < 0 || end < 0)
			{
				throw new System.IndexOutOfRangeException(operation + " " + region(start, end) + 
					" starts before 0");
			}
		}

		private string mText;

		private object[] mSpans;

		private int[] mSpanData;

		private int mSpanCount;

		internal static readonly object[] EMPTY = new object[0];

		internal const int START = 0;

		internal const int END = 1;

		internal const int FLAGS = 2;

		internal const int COLUMNS = 3;
	}
}

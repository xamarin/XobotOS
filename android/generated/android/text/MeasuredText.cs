using Sharpen;

namespace android.text
{
	/// <hide></hide>
	[Sharpen.Sharpened]
	internal class MeasuredText
	{
		internal const bool localLOGV = false;

		internal java.lang.CharSequence mText;

		internal int mTextStart;

		internal float[] mWidths;

		internal char[] mChars;

		internal byte[] mLevels;

		internal int mDir;

		internal bool mEasy;

		internal int mLen;

		private int mPos;

		private android.text.TextPaint mWorkPaint;

		private MeasuredText()
		{
			mWorkPaint = new android.text.TextPaint();
		}

		private static readonly object[] sLock = new object[0];

		private static android.text.MeasuredText[] sCached = new android.text.MeasuredText
			[3];

		internal static android.text.MeasuredText obtain()
		{
			android.text.MeasuredText mt;
			lock (sLock)
			{
				{
					for (int i = sCached.Length; --i >= 0; )
					{
						if (sCached[i] != null)
						{
							mt = sCached[i];
							sCached[i] = null;
							return mt;
						}
					}
				}
			}
			mt = new android.text.MeasuredText();
			return mt;
		}

		internal static android.text.MeasuredText recycle(android.text.MeasuredText mt)
		{
			mt.mText = null;
			if (mt.mLen < 1000)
			{
				lock (sLock)
				{
					{
						for (int i = 0; i < sCached.Length; ++i)
						{
							if (sCached[i] == null)
							{
								sCached[i] = mt;
								mt.mText = null;
								break;
							}
						}
					}
				}
			}
			return null;
		}

		/// <summary>Analyzes text for bidirectional runs.</summary>
		/// <remarks>Analyzes text for bidirectional runs.  Allocates working buffers.</remarks>
		internal virtual void setPara(java.lang.CharSequence text, int start, int end, android.text.TextDirectionHeuristic
			 textDir)
		{
			mText = text;
			mTextStart = start;
			int len = end - start;
			mLen = len;
			mPos = 0;
			if (mWidths == null || mWidths.Length < len)
			{
				mWidths = new float[android.util.@internal.ArrayUtils.idealFloatArraySize(len)];
			}
			if (mChars == null || mChars.Length < len)
			{
				mChars = new char[android.util.@internal.ArrayUtils.idealCharArraySize(len)];
			}
			android.text.TextUtils.getChars(text, start, end, mChars, 0);
			if (text is android.text.Spanned)
			{
				android.text.Spanned spanned = (android.text.Spanned)text;
				android.text.style.ReplacementSpan[] spans = spanned.getSpans<android.text.style.ReplacementSpan
					>(start, end);
				{
					for (int i = 0; i < spans.Length; i++)
					{
						int startInPara = spanned.getSpanStart(spans[i]) - start;
						int endInPara = spanned.getSpanEnd(spans[i]) - start;
						{
							for (int j = startInPara; j < endInPara; j++)
							{
								mChars[j] = '\uFFFC';
							}
						}
					}
				}
			}
			if ((textDir == android.text.TextDirectionHeuristics.LTR || textDir == android.text.TextDirectionHeuristics
				.FIRSTSTRONG_LTR || textDir == android.text.TextDirectionHeuristics.ANYRTL_LTR) 
				&& android.text.TextUtils.doesNotNeedBidi(mChars, 0, len))
			{
				mDir = android.text.Layout.DIR_LEFT_TO_RIGHT;
				mEasy = true;
			}
			else
			{
				if (mLevels == null || mLevels.Length < len)
				{
					mLevels = new byte[android.util.@internal.ArrayUtils.idealByteArraySize(len)];
				}
				int bidiRequest;
				if (textDir == android.text.TextDirectionHeuristics.LTR)
				{
					bidiRequest = android.text.Layout.DIR_REQUEST_LTR;
				}
				else
				{
					if (textDir == android.text.TextDirectionHeuristics.RTL)
					{
						bidiRequest = android.text.Layout.DIR_REQUEST_RTL;
					}
					else
					{
						if (textDir == android.text.TextDirectionHeuristics.FIRSTSTRONG_LTR)
						{
							bidiRequest = android.text.Layout.DIR_REQUEST_DEFAULT_LTR;
						}
						else
						{
							if (textDir == android.text.TextDirectionHeuristics.FIRSTSTRONG_RTL)
							{
								bidiRequest = android.text.Layout.DIR_REQUEST_DEFAULT_RTL;
							}
							else
							{
								bool isRtl = textDir.isRtl(mChars, 0, len);
								bidiRequest = isRtl ? android.text.Layout.DIR_REQUEST_RTL : android.text.Layout.DIR_REQUEST_LTR;
							}
						}
					}
				}
				mDir = android.text.AndroidBidi.bidi(bidiRequest, mChars, mLevels, len, false);
				mEasy = false;
			}
		}

		internal virtual float addStyleRun(android.text.TextPaint paint, int len, android.graphics.Paint
			.FontMetricsInt fm)
		{
			if (fm != null)
			{
				paint.getFontMetricsInt(fm);
			}
			int p = mPos;
			mPos = p + len;
			if (mEasy)
			{
				int flags = mDir == android.text.Layout.DIR_LEFT_TO_RIGHT ? android.graphics.Canvas
					.DIRECTION_LTR : android.graphics.Canvas.DIRECTION_RTL;
				return paint.getTextRunAdvances(mChars, p, len, p, len, flags, mWidths, p);
			}
			float totalAdvance = 0;
			int level = mLevels[p];
			{
				int q = p;
				int i = p + 1;
				int e = p + len;
				for (; ; ++i)
				{
					if (i == e || mLevels[i] != level)
					{
						int flags = (level & unchecked((int)(0x1))) == 0 ? android.graphics.Canvas.DIRECTION_LTR
							 : android.graphics.Canvas.DIRECTION_RTL;
						totalAdvance += paint.getTextRunAdvances(mChars, q, i - q, q, i - q, flags, mWidths
							, q);
						if (i == e)
						{
							break;
						}
						q = i;
						level = mLevels[i];
					}
				}
			}
			return totalAdvance;
		}

		internal virtual float addStyleRun(android.text.TextPaint paint, android.text.style.MetricAffectingSpan
			[] spans, int len, android.graphics.Paint.FontMetricsInt fm)
		{
			android.text.TextPaint workPaint = mWorkPaint;
			workPaint.set(paint);
			// XXX paint should not have a baseline shift, but...
			workPaint.baselineShift = 0;
			android.text.style.ReplacementSpan replacement = null;
			{
				for (int i = 0; i < spans.Length; i++)
				{
					android.text.style.MetricAffectingSpan span = spans[i];
					if (span is android.text.style.ReplacementSpan)
					{
						replacement = (android.text.style.ReplacementSpan)span;
					}
					else
					{
						span.updateMeasureState(workPaint);
					}
				}
			}
			float wid;
			if (replacement == null)
			{
				wid = addStyleRun(workPaint, len, fm);
			}
			else
			{
				// Use original text.  Shouldn't matter.
				wid = replacement.getSize(workPaint, mText, mTextStart + mPos, mTextStart + mPos 
					+ len, fm);
				float[] w = mWidths;
				w[mPos] = wid;
				{
					int i_1 = mPos + 1;
					int e = mPos + len;
					for (; i_1 < e; i_1++)
					{
						w[i_1] = 0;
					}
				}
				mPos += len;
			}
			if (fm != null)
			{
				if (workPaint.baselineShift < 0)
				{
					fm.ascent += workPaint.baselineShift;
					fm.top += workPaint.baselineShift;
				}
				else
				{
					fm.descent += workPaint.baselineShift;
					fm.bottom += workPaint.baselineShift;
				}
			}
			return wid;
		}

		internal virtual int breakText(int start, int limit, bool forwards, float width)
		{
			float[] w = mWidths;
			if (forwards)
			{
				{
					for (int i = start; i < limit; ++i)
					{
						if ((width -= w[i]) < 0)
						{
							return i - start;
						}
					}
				}
			}
			else
			{
				{
					for (int i = limit; --i >= start; )
					{
						if ((width -= w[i]) < 0)
						{
							return limit - i - 1;
						}
					}
				}
			}
			return limit - start;
		}

		internal virtual float measure(int start, int limit)
		{
			float width = 0;
			float[] w = mWidths;
			{
				for (int i = start; i < limit; ++i)
				{
					width += w[i];
				}
			}
			return width;
		}
	}
}

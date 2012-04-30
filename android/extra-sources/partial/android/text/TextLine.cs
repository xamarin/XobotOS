namespace android.text
{
	partial class TextLine
	{
		partial class SpanSet<E>
		{
			internal SpanSet(android.text.Spanned spanned, int start, int limit)
			{
				E[] allSpans = spanned.getSpans<E>(start, limit);
				int length = allSpans.Length;
				// These arrays may end up being too large because of empty spans
				spans = new E[length];
				spanStarts = new int[length];
				spanEnds = new int[length];
				spanFlags = new int[length];
				int count = 0;
				{
					for (int i = 0; i < length; i++)
					{
						E span = allSpans[i];
						int spanStart = spanned.getSpanStart(span);
						int spanEnd = spanned.getSpanEnd(span);
						if (spanStart == spanEnd)
						{
							continue;
						}
						int spanFlag = spanned.getSpanFlags(span);
						int priority = spanFlag & android.text.SpannedClass.SPAN_PRIORITY;
						if (priority != 0 && count != 0)
						{
							int j;
							for (j = 0; j < count; j++)
							{
								int otherPriority = spanFlags[j] & android.text.SpannedClass.SPAN_PRIORITY;
								if (priority > otherPriority)
								{
									break;
								}
							}
							System.Array.Copy(spans, j, spans, j + 1, count - j);
							System.Array.Copy(spanStarts, j, spanStarts, j + 1, count - j);
							System.Array.Copy(spanEnds, j, spanEnds, j + 1, count - j);
							System.Array.Copy(spanFlags, j, spanFlags, j + 1, count - j);
							spans[j] = span;
							spanStarts[j] = spanStart;
							spanEnds[j] = spanEnd;
							spanFlags[j] = spanFlag;
						}
						else
						{
							spans[i] = span;
							spanStarts[i] = spanStart;
							spanEnds[i] = spanEnd;
							spanFlags[i] = spanFlag;
						}
						count++;
					}
				}
				numberOfSpans = count;
			}
		}

		/// <summary>Utility function for handling a unidirectional run.</summary>
		/// <remarks>
		/// Utility function for handling a unidirectional run.  The run must not
		/// contain tabs or emoji but can contain styles.
		/// </remarks>
		/// <param name="start">the line-relative start of the run</param>
		/// <param name="measureLimit">the offset to measure to, between start and limit inclusive
		/// 	</param>
		/// <param name="limit">the limit of the run</param>
		/// <param name="runIsRtl">true if the run is right-to-left</param>
		/// <param name="c">the canvas, can be null</param>
		/// <param name="x">the end of the run closest to the leading margin</param>
		/// <param name="top">the top of the line</param>
		/// <param name="y">the baseline</param>
		/// <param name="bottom">the bottom of the line</param>
		/// <param name="fmi">receives metrics information, can be null</param>
		/// <param name="needWidth">true if the width is required</param>
		/// <returns>
		/// the signed width of the run based on the run direction; only
		/// valid if needWidth is true
		/// </returns>
		private float handleRun(int start, int measureLimit, int limit, bool runIsRtl, android.graphics.Canvas
			 c, float x, int top, int y, int bottom, android.graphics.Paint.FontMetricsInt fmi
			, bool needWidth)
		{
			// Case of an empty line, make sure we update fmi according to mPaint
			if (start == measureLimit)
			{
				android.text.TextPaint wp = mWorkPaint;
				wp.set(mPaint);
				if (fmi != null)
				{
					expandMetricsFromPaint(fmi, wp);
				}
				return 0f;
			}
			if (mSpanned == null)
			{
				android.text.TextPaint wp = mWorkPaint;
				wp.set(mPaint);
				int mlimit = measureLimit;
				return handleText(wp, start, mlimit, start, limit, runIsRtl, c, x, top, y, bottom
					, fmi, needWidth || mlimit < measureLimit);
			}
			android.text.TextLine.SpanSet<android.text.style.MetricAffectingSpan> metricAffectingSpans
				 = new android.text.TextLine.SpanSet<android.text.style.MetricAffectingSpan>(mSpanned
				, mStart + start, mStart + limit);
			android.text.TextLine.SpanSet<android.text.style.CharacterStyle> characterStyleSpans
				 = new android.text.TextLine.SpanSet<android.text.style.CharacterStyle>(mSpanned
				, mStart + start, mStart + limit);
			// Shaping needs to take into account context up to metric boundaries,
			// but rendering needs to take into account character style boundaries.
			// So we iterate through metric runs to get metric bounds,
			// then within each metric run iterate through character style runs
			// for the run bounds.
			float originalX = x;
			{
				int i = start;
				int inext;
				for (; i < measureLimit; i = inext)
				{
					android.text.TextPaint wp = mWorkPaint;
					wp.set(mPaint);
					inext = metricAffectingSpans.getNextTransition(mStart + i, mStart + limit) - mStart;
					int mlimit = System.Math.Min(inext, measureLimit);
					android.text.style.ReplacementSpan replacement = null;
					{
						for (int j = 0; j < metricAffectingSpans.numberOfSpans; j++)
						{
							// Both intervals [spanStarts..spanEnds] and [mStart + i..mStart + mlimit] are NOT
							// empty by construction. This special case in getSpans() explains the >= & <= tests
							if ((metricAffectingSpans.spanStarts[j] >= mStart + mlimit) || (metricAffectingSpans
								.spanEnds[j] <= mStart + i))
							{
								continue;
							}
							android.text.style.MetricAffectingSpan span = metricAffectingSpans.spans[j];
							if (span is android.text.style.ReplacementSpan)
							{
								replacement = (android.text.style.ReplacementSpan)span;
							}
							else
							{
								// We might have a replacement that uses the draw
								// state, otherwise measure state would suffice.
								span.updateDrawState(wp);
							}
						}
					}
					if (replacement != null)
					{
						x += handleReplacement(replacement, wp, i, mlimit, runIsRtl, c, x, top, y, bottom
							, fmi, needWidth || mlimit < measureLimit);
						continue;
					}
					if (c == null)
					{
						x += handleText(wp, i, mlimit, i, inext, runIsRtl, c, x, top, y, bottom, fmi, needWidth
							 || mlimit < measureLimit);
					}
					else
					{
						{
							int j_1 = i;
							int jnext;
							for (; j_1 < mlimit; j_1 = jnext)
							{
								jnext = characterStyleSpans.getNextTransition(mStart + j_1, mStart + mlimit) - mStart;
								wp.set(mPaint);
								{
									for (int k = 0; k < characterStyleSpans.numberOfSpans; k++)
									{
										// Intentionally using >= and <= as explained above
										if ((characterStyleSpans.spanStarts[k] >= mStart + jnext) || (characterStyleSpans
											.spanEnds[k] <= mStart + j_1))
										{
											continue;
										}
										android.text.style.CharacterStyle span = characterStyleSpans.spans[k];
										span.updateDrawState(wp);
									}
								}
								x += handleText(wp, j_1, jnext, i, inext, runIsRtl, c, x, top, y, bottom, fmi, needWidth
									 || jnext < measureLimit);
							}
						}
					}
				}
			}
			return x - originalX;
		}
	}
}


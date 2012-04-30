using Sharpen;

namespace android.text
{
	/// <summary>
	/// Represents a line of styled text, for measuring in visual order and
	/// for rendering.
	/// </summary>
	/// <remarks>
	/// Represents a line of styled text, for measuring in visual order and
	/// for rendering.
	/// <p>Get a new instance using obtain(), and when finished with it, return it
	/// to the pool using recycle().
	/// <p>Call set to prepare the instance for use, then either draw, measure,
	/// metrics, or caretToLeftRightOf.
	/// </remarks>
	/// <hide></hide>
	[Sharpen.Sharpened]
	internal partial class TextLine
	{
		internal const bool DEBUG = false;

		private android.text.TextPaint mPaint;

		private java.lang.CharSequence mText;

		private int mStart;

		private int mLen;

		private int mDir;

		private android.text.Layout.Directions mDirections;

		private bool mHasTabs;

		private android.text.Layout.TabStops mTabs;

		private char[] mChars;

		private bool mCharsValid;

		private android.text.Spanned mSpanned;

		private readonly android.text.TextPaint mWorkPaint = new android.text.TextPaint();

		private static readonly android.text.TextLine[] sCached = new android.text.TextLine
			[3];

		/// <summary>Returns a new TextLine from the shared pool.</summary>
		/// <remarks>Returns a new TextLine from the shared pool.</remarks>
		/// <returns>an uninitialized TextLine</returns>
		internal static android.text.TextLine obtain()
		{
			android.text.TextLine tl;
			lock (sCached)
			{
				{
					for (int i = sCached.Length; --i >= 0; )
					{
						if (sCached[i] != null)
						{
							tl = sCached[i];
							sCached[i] = null;
							return tl;
						}
					}
				}
			}
			tl = new android.text.TextLine();
			return tl;
		}

		/// <summary>Puts a TextLine back into the shared pool.</summary>
		/// <remarks>
		/// Puts a TextLine back into the shared pool. Do not use this TextLine once
		/// it has been returned.
		/// </remarks>
		/// <param name="tl">the textLine</param>
		/// <returns>
		/// null, as a convenience from clearing references to the provided
		/// TextLine
		/// </returns>
		internal static android.text.TextLine recycle(android.text.TextLine tl)
		{
			tl.mText = null;
			tl.mPaint = null;
			tl.mDirections = null;
			lock (sCached)
			{
				{
					for (int i = 0; i < sCached.Length; ++i)
					{
						if (sCached[i] == null)
						{
							sCached[i] = tl;
							break;
						}
					}
				}
			}
			return null;
		}

		/// <summary>Initializes a TextLine and prepares it for use.</summary>
		/// <remarks>Initializes a TextLine and prepares it for use.</remarks>
		/// <param name="paint">the base paint for the line</param>
		/// <param name="text">the text, can be Styled</param>
		/// <param name="start">the start of the line relative to the text</param>
		/// <param name="limit">the limit of the line relative to the text</param>
		/// <param name="dir">the paragraph direction of this line</param>
		/// <param name="directions">the directions information of this line</param>
		/// <param name="hasTabs">true if the line might contain tabs or emoji</param>
		/// <param name="tabStops">the tabStops. Can be null.</param>
		internal virtual void set(android.text.TextPaint paint, java.lang.CharSequence text
			, int start, int limit, int dir, android.text.Layout.Directions directions, bool
			 hasTabs, android.text.Layout.TabStops tabStops)
		{
			mPaint = paint;
			mText = text;
			mStart = start;
			mLen = limit - start;
			mDir = dir;
			mDirections = directions;
			if (mDirections == null)
			{
				throw new System.ArgumentException("Directions cannot be null");
			}
			mHasTabs = hasTabs;
			mSpanned = null;
			bool hasReplacement = false;
			if (text is android.text.Spanned)
			{
				mSpanned = (android.text.Spanned)text;
				android.text.style.ReplacementSpan[] spans = mSpanned.getSpans<android.text.style.ReplacementSpan
					>(start, limit);
				spans = android.text.TextUtils.removeEmptySpans<android.text.style.ReplacementSpan
					>(spans, mSpanned);
				hasReplacement = spans.Length > 0;
			}
			mCharsValid = hasReplacement || hasTabs || directions != android.text.Layout.DIRS_ALL_LEFT_TO_RIGHT;
			if (mCharsValid)
			{
				if (mChars == null || mChars.Length < mLen)
				{
					mChars = new char[android.util.@internal.ArrayUtils.idealCharArraySize(mLen)];
				}
				android.text.TextUtils.getChars(text, start, limit, mChars, 0);
				if (hasReplacement)
				{
					// Handle these all at once so we don't have to do it as we go.
					// Replace the first character of each replacement run with the
					// object-replacement character and the remainder with zero width
					// non-break space aka BOM.  Cursor movement code skips these
					// zero-width characters.
					char[] chars = mChars;
					{
						int i = start;
						int inext;
						for (; i < limit; i = inext)
						{
							inext = mSpanned.nextSpanTransition(i, limit, typeof(android.text.style.ReplacementSpan
								));
							android.text.style.ReplacementSpan[] spans = mSpanned.getSpans<android.text.style.ReplacementSpan
								>(i, inext);
							spans = android.text.TextUtils.removeEmptySpans<android.text.style.ReplacementSpan
								>(spans, mSpanned);
							if (spans.Length > 0)
							{
								// transition into a span
								chars[i - start] = '\ufffc';
								{
									int j = i - start + 1;
									int e = inext - start;
									for (; j < e; ++j)
									{
										chars[j] = '\ufeff';
									}
								}
							}
						}
					}
				}
			}
			// used as ZWNBS, marks positions to skip
			mTabs = tabStops;
		}

		/// <summary>Renders the TextLine.</summary>
		/// <remarks>Renders the TextLine.</remarks>
		/// <param name="c">the canvas to render on</param>
		/// <param name="x">the leading margin position</param>
		/// <param name="top">the top of the line</param>
		/// <param name="y">the baseline</param>
		/// <param name="bottom">the bottom of the line</param>
		internal virtual void draw(android.graphics.Canvas c, float x, int top, int y, int
			 bottom)
		{
			if (!mHasTabs)
			{
				if (mDirections == android.text.Layout.DIRS_ALL_LEFT_TO_RIGHT)
				{
					drawRun(c, 0, mLen, false, x, top, y, bottom, false);
					return;
				}
				if (mDirections == android.text.Layout.DIRS_ALL_RIGHT_TO_LEFT)
				{
					drawRun(c, 0, mLen, true, x, top, y, bottom, false);
					return;
				}
			}
			float h = 0;
			int[] runs = mDirections.mDirections;
			android.graphics.RectF emojiRect = null;
			int lastRunIndex = runs.Length - 2;
			{
				for (int i = 0; i < runs.Length; i += 2)
				{
					int runStart = runs[i];
					int runLimit = runStart + (runs[i + 1] & android.text.Layout.RUN_LENGTH_MASK);
					if (runLimit > mLen)
					{
						runLimit = mLen;
					}
					bool runIsRtl = (runs[i + 1] & android.text.Layout.RUN_RTL_FLAG) != 0;
					int segstart = runStart;
					{
						for (int j = mHasTabs ? runStart : runLimit; j <= runLimit; j++)
						{
							int codept = 0;
							android.graphics.Bitmap bm = null;
							if (mHasTabs && j < runLimit)
							{
								codept = mChars[j];
								if (codept >= unchecked((int)(0xd800)) && codept < unchecked((int)(0xdc00)) && j 
									+ 1 < runLimit)
								{
									codept = Sharpen.CharHelper.CodePointAt(mChars, j);
									if (codept >= android.text.Layout.MIN_EMOJI && codept <= android.text.Layout.MAX_EMOJI)
									{
										bm = android.text.Layout.EMOJI_FACTORY.getBitmapFromAndroidPua(codept);
									}
									else
									{
										if (codept > unchecked((int)(0xffff)))
										{
											++j;
											continue;
										}
									}
								}
							}
							if (j == runLimit || codept == '\t' || bm != null)
							{
								h += drawRun(c, segstart, j, runIsRtl, x + h, top, y, bottom, i != lastRunIndex ||
									 j != mLen);
								if (codept == '\t')
								{
									h = mDir * nextTab(h * mDir);
								}
								else
								{
									if (bm != null)
									{
										float bmAscent = ascent(j);
										float bitmapHeight = bm.getHeight();
										float scale = -bmAscent / bitmapHeight;
										float width = bm.getWidth() * scale;
										if (emojiRect == null)
										{
											emojiRect = new android.graphics.RectF();
										}
										emojiRect.set(x + h, y + bmAscent, x + h + width, y);
										c.drawBitmap(bm, null, emojiRect, mPaint);
										h += width;
										j++;
									}
								}
								segstart = j + 1;
							}
						}
					}
				}
			}
		}

		/// <summary>Returns metrics information for the entire line.</summary>
		/// <remarks>Returns metrics information for the entire line.</remarks>
		/// <param name="fmi">receives font metrics information, can be null</param>
		/// <returns>the signed width of the line</returns>
		internal virtual float metrics(android.graphics.Paint.FontMetricsInt fmi)
		{
			return measure(mLen, false, fmi);
		}

		/// <summary>Returns information about a position on the line.</summary>
		/// <remarks>Returns information about a position on the line.</remarks>
		/// <param name="offset">
		/// the line-relative character offset, between 0 and the
		/// line length, inclusive
		/// </param>
		/// <param name="trailing">
		/// true to measure the trailing edge of the character
		/// before offset, false to measure the leading edge of the character
		/// at offset.
		/// </param>
		/// <param name="fmi">
		/// receives metrics information about the requested
		/// character, can be null.
		/// </param>
		/// <returns>
		/// the signed offset from the leading margin to the requested
		/// character edge.
		/// </returns>
		internal virtual float measure(int offset, bool trailing, android.graphics.Paint.
			FontMetricsInt fmi)
		{
			int target = trailing ? offset - 1 : offset;
			if (target < 0)
			{
				return 0;
			}
			float h = 0;
			if (!mHasTabs)
			{
				if (mDirections == android.text.Layout.DIRS_ALL_LEFT_TO_RIGHT)
				{
					return measureRun(0, offset, mLen, false, fmi);
				}
				if (mDirections == android.text.Layout.DIRS_ALL_RIGHT_TO_LEFT)
				{
					return measureRun(0, offset, mLen, true, fmi);
				}
			}
			char[] chars = mChars;
			int[] runs = mDirections.mDirections;
			{
				for (int i = 0; i < runs.Length; i += 2)
				{
					int runStart = runs[i];
					int runLimit = runStart + (runs[i + 1] & android.text.Layout.RUN_LENGTH_MASK);
					if (runLimit > mLen)
					{
						runLimit = mLen;
					}
					bool runIsRtl = (runs[i + 1] & android.text.Layout.RUN_RTL_FLAG) != 0;
					int segstart = runStart;
					{
						for (int j = mHasTabs ? runStart : runLimit; j <= runLimit; j++)
						{
							int codept = 0;
							android.graphics.Bitmap bm = null;
							if (mHasTabs && j < runLimit)
							{
								codept = chars[j];
								if (codept >= unchecked((int)(0xd800)) && codept < unchecked((int)(0xdc00)) && j 
									+ 1 < runLimit)
								{
									codept = Sharpen.CharHelper.CodePointAt(chars, j);
									if (codept >= android.text.Layout.MIN_EMOJI && codept <= android.text.Layout.MAX_EMOJI)
									{
										bm = android.text.Layout.EMOJI_FACTORY.getBitmapFromAndroidPua(codept);
									}
									else
									{
										if (codept > unchecked((int)(0xffff)))
										{
											++j;
											continue;
										}
									}
								}
							}
							if (j == runLimit || codept == '\t' || bm != null)
							{
								bool inSegment = target >= segstart && target < j;
								bool advance = (mDir == android.text.Layout.DIR_RIGHT_TO_LEFT) == runIsRtl;
								if (inSegment && advance)
								{
									return h += measureRun(segstart, offset, j, runIsRtl, fmi);
								}
								float w = measureRun(segstart, j, j, runIsRtl, fmi);
								h += advance ? w : -w;
								if (inSegment)
								{
									return h += measureRun(segstart, offset, j, runIsRtl, null);
								}
								if (codept == '\t')
								{
									if (offset == j)
									{
										return h;
									}
									h = mDir * nextTab(h * mDir);
									if (target == j)
									{
										return h;
									}
								}
								if (bm != null)
								{
									float bmAscent = ascent(j);
									float wid = bm.getWidth() * -bmAscent / bm.getHeight();
									h += mDir * wid;
									j++;
								}
								segstart = j + 1;
							}
						}
					}
				}
			}
			return h;
		}

		/// <summary>Draws a unidirectional (but possibly multi-styled) run of text.</summary>
		/// <remarks>Draws a unidirectional (but possibly multi-styled) run of text.</remarks>
		/// <param name="c">the canvas to draw on</param>
		/// <param name="start">the line-relative start</param>
		/// <param name="limit">the line-relative limit</param>
		/// <param name="runIsRtl">true if the run is right-to-left</param>
		/// <param name="x">the position of the run that is closest to the leading margin</param>
		/// <param name="top">the top of the line</param>
		/// <param name="y">the baseline</param>
		/// <param name="bottom">the bottom of the line</param>
		/// <param name="needWidth">true if the width value is required.</param>
		/// <returns>
		/// the signed width of the run, based on the paragraph direction.
		/// Only valid if needWidth is true.
		/// </returns>
		private float drawRun(android.graphics.Canvas c, int start, int limit, bool runIsRtl
			, float x, int top, int y, int bottom, bool needWidth)
		{
			if ((mDir == android.text.Layout.DIR_LEFT_TO_RIGHT) == runIsRtl)
			{
				float w = -measureRun(start, limit, limit, runIsRtl, null);
				handleRun(start, limit, limit, runIsRtl, c, x + w, top, y, bottom, null, false);
				return w;
			}
			return handleRun(start, limit, limit, runIsRtl, c, x, top, y, bottom, null, needWidth
				);
		}

		/// <summary>Measures a unidirectional (but possibly multi-styled) run of text.</summary>
		/// <remarks>Measures a unidirectional (but possibly multi-styled) run of text.</remarks>
		/// <param name="start">the line-relative start of the run</param>
		/// <param name="offset">the offset to measure to, between start and limit inclusive</param>
		/// <param name="limit">the line-relative limit of the run</param>
		/// <param name="runIsRtl">true if the run is right-to-left</param>
		/// <param name="fmi">
		/// receives metrics information about the requested
		/// run, can be null.
		/// </param>
		/// <returns>
		/// the signed width from the start of the run to the leading edge
		/// of the character at offset, based on the run (not paragraph) direction
		/// </returns>
		private float measureRun(int start, int offset, int limit, bool runIsRtl, android.graphics.Paint
			.FontMetricsInt fmi)
		{
			return handleRun(start, offset, limit, runIsRtl, null, 0, 0, 0, 0, fmi, true);
		}

		/// <summary>
		/// Walk the cursor through this line, skipping conjuncts and
		/// zero-width characters.
		/// </summary>
		/// <remarks>
		/// Walk the cursor through this line, skipping conjuncts and
		/// zero-width characters.
		/// <p>This function cannot properly walk the cursor off the ends of the line
		/// since it does not know about any shaping on the previous/following line
		/// that might affect the cursor position. Callers must either avoid these
		/// situations or handle the result specially.
		/// </remarks>
		/// <param name="cursor">
		/// the starting position of the cursor, between 0 and the
		/// length of the line, inclusive
		/// </param>
		/// <param name="toLeft">true if the caret is moving to the left.</param>
		/// <returns>
		/// the new offset.  If it is less than 0 or greater than the length
		/// of the line, the previous/following line should be examined to get the
		/// actual offset.
		/// </returns>
		internal virtual int getOffsetToLeftRightOf(int cursor, bool toLeft)
		{
			// 1) The caret marks the leading edge of a character. The character
			// logically before it might be on a different level, and the active caret
			// position is on the character at the lower level. If that character
			// was the previous character, the caret is on its trailing edge.
			// 2) Take this character/edge and move it in the indicated direction.
			// This gives you a new character and a new edge.
			// 3) This position is between two visually adjacent characters.  One of
			// these might be at a lower level.  The active position is on the
			// character at the lower level.
			// 4) If the active position is on the trailing edge of the character,
			// the new caret position is the following logical character, else it
			// is the character.
			int lineStart = 0;
			int lineEnd = mLen;
			bool paraIsRtl = mDir == -1;
			int[] runs = mDirections.mDirections;
			int runIndex;
			int runLevel = 0;
			int runStart = lineStart;
			int runLimit = lineEnd;
			int newCaret = -1;
			bool trailing = false;
			if (cursor == lineStart)
			{
				runIndex = -2;
			}
			else
			{
				if (cursor == lineEnd)
				{
					runIndex = runs.Length;
				}
				else
				{
					// First, get information about the run containing the character with
					// the active caret.
					for (runIndex = 0; runIndex < runs.Length; runIndex += 2)
					{
						runStart = lineStart + runs[runIndex];
						if (cursor >= runStart)
						{
							runLimit = runStart + (runs[runIndex + 1] & android.text.Layout.RUN_LENGTH_MASK);
							if (runLimit > lineEnd)
							{
								runLimit = lineEnd;
							}
							if (cursor < runLimit)
							{
								runLevel = ((int)(((uint)runs[runIndex + 1]) >> android.text.Layout.RUN_LEVEL_SHIFT
									)) & android.text.Layout.RUN_LEVEL_MASK;
								if (cursor == runStart)
								{
									// The caret is on a run boundary, see if we should
									// use the position on the trailing edge of the previous
									// logical character instead.
									int prevRunIndex;
									int prevRunLevel;
									int prevRunStart;
									int prevRunLimit;
									int pos = cursor - 1;
									for (prevRunIndex = 0; prevRunIndex < runs.Length; prevRunIndex += 2)
									{
										prevRunStart = lineStart + runs[prevRunIndex];
										if (pos >= prevRunStart)
										{
											prevRunLimit = prevRunStart + (runs[prevRunIndex + 1] & android.text.Layout.RUN_LENGTH_MASK
												);
											if (prevRunLimit > lineEnd)
											{
												prevRunLimit = lineEnd;
											}
											if (pos < prevRunLimit)
											{
												prevRunLevel = ((int)(((uint)runs[prevRunIndex + 1]) >> android.text.Layout.RUN_LEVEL_SHIFT
													)) & android.text.Layout.RUN_LEVEL_MASK;
												if (prevRunLevel < runLevel)
												{
													// Start from logically previous character.
													runIndex = prevRunIndex;
													runLevel = prevRunLevel;
													runStart = prevRunStart;
													runLimit = prevRunLimit;
													trailing = true;
													break;
												}
											}
										}
									}
								}
								break;
							}
						}
					}
					// caret might be == lineEnd.  This is generally a space or paragraph
					// separator and has an associated run, but might be the end of
					// text, in which case it doesn't.  If that happens, we ran off the
					// end of the run list, and runIndex == runs.length.  In this case,
					// we are at a run boundary so we skip the below test.
					if (runIndex != runs.Length)
					{
						bool runIsRtl = (runLevel & unchecked((int)(0x1))) != 0;
						bool advance = toLeft == runIsRtl;
						if (cursor != (advance ? runLimit : runStart) || advance != trailing)
						{
							// Moving within or into the run, so we can move logically.
							newCaret = getOffsetBeforeAfter(runIndex, runStart, runLimit, runIsRtl, cursor, advance
								);
							// If the new position is internal to the run, we're at the strong
							// position already so we're finished.
							if (newCaret != (advance ? runLimit : runStart))
							{
								return newCaret;
							}
						}
					}
				}
			}
			// If newCaret is -1, we're starting at a run boundary and crossing
			// into another run. Otherwise we've arrived at a run boundary, and
			// need to figure out which character to attach to.  Note we might
			// need to run this twice, if we cross a run boundary and end up at
			// another run boundary.
			while (true)
			{
				bool advance = toLeft == paraIsRtl;
				int otherRunIndex = runIndex + (advance ? 2 : -2);
				if (otherRunIndex >= 0 && otherRunIndex < runs.Length)
				{
					int otherRunStart = lineStart + runs[otherRunIndex];
					int otherRunLimit = otherRunStart + (runs[otherRunIndex + 1] & android.text.Layout
						.RUN_LENGTH_MASK);
					if (otherRunLimit > lineEnd)
					{
						otherRunLimit = lineEnd;
					}
					int otherRunLevel = ((int)(((uint)runs[otherRunIndex + 1]) >> android.text.Layout
						.RUN_LEVEL_SHIFT)) & android.text.Layout.RUN_LEVEL_MASK;
					bool otherRunIsRtl = (otherRunLevel & 1) != 0;
					advance = toLeft == otherRunIsRtl;
					if (newCaret == -1)
					{
						newCaret = getOffsetBeforeAfter(otherRunIndex, otherRunStart, otherRunLimit, otherRunIsRtl
							, advance ? otherRunStart : otherRunLimit, advance);
						if (newCaret == (advance ? otherRunLimit : otherRunStart))
						{
							// Crossed and ended up at a new boundary,
							// repeat a second and final time.
							runIndex = otherRunIndex;
							runLevel = otherRunLevel;
							continue;
						}
						break;
					}
					// The new caret is at a boundary.
					if (otherRunLevel < runLevel)
					{
						// The strong character is in the other run.
						newCaret = advance ? otherRunStart : otherRunLimit;
					}
					break;
				}
				if (newCaret == -1)
				{
					// We're walking off the end of the line.  The paragraph
					// level is always equal to or lower than any internal level, so
					// the boundaries get the strong caret.
					newCaret = advance ? mLen + 1 : -1;
					break;
				}
				// Else we've arrived at the end of the line.  That's a strong position.
				// We might have arrived here by crossing over a run with no internal
				// breaks and dropping out of the above loop before advancing one final
				// time, so reset the caret.
				// Note, we use '<=' below to handle a situation where the only run
				// on the line is a counter-directional run.  If we're not advancing,
				// we can end up at the 'lineEnd' position but the caret we want is at
				// the lineStart.
				if (newCaret <= lineEnd)
				{
					newCaret = advance ? lineEnd : lineStart;
				}
				break;
			}
			return newCaret;
		}

		/// <summary>
		/// Returns the next valid offset within this directional run, skipping
		/// conjuncts and zero-width characters.
		/// </summary>
		/// <remarks>
		/// Returns the next valid offset within this directional run, skipping
		/// conjuncts and zero-width characters.  This should not be called to walk
		/// off the end of the line, since the returned values might not be valid
		/// on neighboring lines.  If the returned offset is less than zero or
		/// greater than the line length, the offset should be recomputed on the
		/// preceding or following line, respectively.
		/// </remarks>
		/// <param name="runIndex">the run index</param>
		/// <param name="runStart">the start of the run</param>
		/// <param name="runLimit">the limit of the run</param>
		/// <param name="runIsRtl">true if the run is right-to-left</param>
		/// <param name="offset">the offset</param>
		/// <param name="after">
		/// true if the new offset should logically follow the provided
		/// offset
		/// </param>
		/// <returns>the new offset</returns>
		private int getOffsetBeforeAfter(int runIndex, int runStart, int runLimit, bool runIsRtl
			, int offset, bool after)
		{
			if (runIndex < 0 || offset == (after ? mLen : 0))
			{
				// Walking off end of line.  Since we don't know
				// what cursor positions are available on other lines, we can't
				// return accurate values.  These are a guess.
				if (after)
				{
					return android.text.TextUtils.getOffsetAfter(mText, offset + mStart) - mStart;
				}
				return android.text.TextUtils.getOffsetBefore(mText, offset + mStart) - mStart;
			}
			android.text.TextPaint wp = mWorkPaint;
			wp.set(mPaint);
			int spanStart = runStart;
			int spanLimit;
			if (mSpanned == null)
			{
				spanLimit = runLimit;
			}
			else
			{
				int target = after ? offset + 1 : offset;
				int limit = mStart + runLimit;
				while (true)
				{
					spanLimit = mSpanned.nextSpanTransition(mStart + spanStart, limit, typeof(android.text.style.MetricAffectingSpan
						)) - mStart;
					if (spanLimit >= target)
					{
						break;
					}
					spanStart = spanLimit;
				}
				android.text.style.MetricAffectingSpan[] spans = mSpanned.getSpans<android.text.style.MetricAffectingSpan
					>(mStart + spanStart, mStart + spanLimit);
				spans = android.text.TextUtils.removeEmptySpans<android.text.style.MetricAffectingSpan
					>(spans, mSpanned);
				if (spans.Length > 0)
				{
					android.text.style.ReplacementSpan replacement = null;
					{
						for (int j = 0; j < spans.Length; j++)
						{
							android.text.style.MetricAffectingSpan span = spans[j];
							if (span is android.text.style.ReplacementSpan)
							{
								replacement = (android.text.style.ReplacementSpan)span;
							}
							else
							{
								span.updateMeasureState(wp);
							}
						}
					}
					if (replacement != null)
					{
						// If we have a replacement span, we're moving either to
						// the start or end of this span.
						return after ? spanLimit : spanStart;
					}
				}
			}
			int flags = runIsRtl ? android.graphics.Paint.DIRECTION_RTL : android.graphics.Paint
				.DIRECTION_LTR;
			int cursorOpt = after ? android.graphics.Paint.CURSOR_AFTER : android.graphics.Paint
				.CURSOR_BEFORE;
			if (mCharsValid)
			{
				return wp.getTextRunCursor(mChars, spanStart, spanLimit - spanStart, flags, offset
					, cursorOpt);
			}
			else
			{
				return wp.getTextRunCursor(mText, mStart + spanStart, mStart + spanLimit, flags, 
					mStart + offset, cursorOpt) - mStart;
			}
		}

		/// <param name="wp"></param>
		private static void expandMetricsFromPaint(android.graphics.Paint.FontMetricsInt 
			fmi, android.text.TextPaint wp)
		{
			int previousTop = fmi.top;
			int previousAscent = fmi.ascent;
			int previousDescent = fmi.descent;
			int previousBottom = fmi.bottom;
			int previousLeading = fmi.leading;
			wp.getFontMetricsInt(fmi);
			updateMetrics(fmi, previousTop, previousAscent, previousDescent, previousBottom, 
				previousLeading);
		}

		internal static void updateMetrics(android.graphics.Paint.FontMetricsInt fmi, int
			 previousTop, int previousAscent, int previousDescent, int previousBottom, int previousLeading
			)
		{
			fmi.top = System.Math.Min(fmi.top, previousTop);
			fmi.ascent = System.Math.Min(fmi.ascent, previousAscent);
			fmi.descent = System.Math.Max(fmi.descent, previousDescent);
			fmi.bottom = System.Math.Max(fmi.bottom, previousBottom);
			fmi.leading = System.Math.Max(fmi.leading, previousLeading);
		}

		/// <summary>Utility function for measuring and rendering text.</summary>
		/// <remarks>
		/// Utility function for measuring and rendering text.  The text must
		/// not include a tab or emoji.
		/// </remarks>
		/// <param name="wp">the working paint</param>
		/// <param name="start">the start of the text</param>
		/// <param name="end">the end of the text</param>
		/// <param name="runIsRtl">true if the run is right-to-left</param>
		/// <param name="c">the canvas, can be null if rendering is not needed</param>
		/// <param name="x">the edge of the run closest to the leading margin</param>
		/// <param name="top">the top of the line</param>
		/// <param name="y">the baseline</param>
		/// <param name="bottom">the bottom of the line</param>
		/// <param name="fmi">receives metrics information, can be null</param>
		/// <param name="needWidth">true if the width of the run is needed</param>
		/// <returns>
		/// the signed width of the run based on the run direction; only
		/// valid if needWidth is true
		/// </returns>
		private float handleText(android.text.TextPaint wp, int start, int end, int contextStart
			, int contextEnd, bool runIsRtl, android.graphics.Canvas c, float x, int top, int
			 y, int bottom, android.graphics.Paint.FontMetricsInt fmi, bool needWidth)
		{
			// Get metrics first (even for empty strings or "0" width runs)
			if (fmi != null)
			{
				expandMetricsFromPaint(fmi, wp);
			}
			int runLen = end - start;
			// No need to do anything if the run width is "0"
			if (runLen == 0)
			{
				return 0f;
			}
			float ret = 0;
			int contextLen = contextEnd - contextStart;
			if (needWidth || (c != null && (wp.bgColor != 0 || wp.underlineColor != 0 || runIsRtl
				)))
			{
				int flags = runIsRtl ? android.graphics.Paint.DIRECTION_RTL : android.graphics.Paint
					.DIRECTION_LTR;
				if (mCharsValid)
				{
					ret = wp.getTextRunAdvances(mChars, start, runLen, contextStart, contextLen, flags
						, null, 0);
				}
				else
				{
					int delta = mStart;
					ret = wp.getTextRunAdvances(mText, delta + start, delta + end, delta + contextStart
						, delta + contextEnd, flags, null, 0);
				}
			}
			if (c != null)
			{
				if (runIsRtl)
				{
					x -= ret;
				}
				if (wp.bgColor != 0)
				{
					int previousColor = wp.getColor();
					android.graphics.Paint.Style previousStyle = wp.getStyle();
					wp.setColor(wp.bgColor);
					wp.setStyle(android.graphics.Paint.Style.FILL);
					c.drawRect(x, top, x + ret, bottom, wp);
					wp.setStyle(previousStyle);
					wp.setColor(previousColor);
				}
				if (wp.underlineColor != 0)
				{
					// kStdUnderline_Offset = 1/9, defined in SkTextFormatParams.h
					float underlineTop = y + wp.baselineShift + (1.0f / 9.0f) * wp.getTextSize();
					int previousColor = wp.getColor();
					android.graphics.Paint.Style previousStyle = wp.getStyle();
					bool previousAntiAlias = wp.isAntiAlias();
					wp.setStyle(android.graphics.Paint.Style.FILL);
					wp.setAntiAlias(true);
					wp.setColor(wp.underlineColor);
					c.drawRect(x, underlineTop, x + ret, underlineTop + wp.underlineThickness, wp);
					wp.setStyle(previousStyle);
					wp.setColor(previousColor);
					wp.setAntiAlias(previousAntiAlias);
				}
				drawTextRun(c, wp, start, end, contextStart, contextEnd, runIsRtl, x, y + wp.baselineShift
					);
			}
			return runIsRtl ? -ret : ret;
		}

		/// <summary>Utility function for measuring and rendering a replacement.</summary>
		/// <remarks>Utility function for measuring and rendering a replacement.</remarks>
		/// <param name="replacement">the replacement</param>
		/// <param name="wp">the work paint</param>
		/// <param name="start">the start of the run</param>
		/// <param name="limit">the limit of the run</param>
		/// <param name="runIsRtl">true if the run is right-to-left</param>
		/// <param name="c">the canvas, can be null if not rendering</param>
		/// <param name="x">the edge of the replacement closest to the leading margin</param>
		/// <param name="top">the top of the line</param>
		/// <param name="y">the baseline</param>
		/// <param name="bottom">the bottom of the line</param>
		/// <param name="fmi">receives metrics information, can be null</param>
		/// <param name="needWidth">true if the width of the replacement is needed</param>
		/// <returns>
		/// the signed width of the run based on the run direction; only
		/// valid if needWidth is true
		/// </returns>
		private float handleReplacement(android.text.style.ReplacementSpan replacement, android.text.TextPaint
			 wp, int start, int limit, bool runIsRtl, android.graphics.Canvas c, float x, int
			 top, int y, int bottom, android.graphics.Paint.FontMetricsInt fmi, bool needWidth
			)
		{
			float ret = 0;
			int textStart = mStart + start;
			int textLimit = mStart + limit;
			if (needWidth || (c != null && runIsRtl))
			{
				int previousTop = 0;
				int previousAscent = 0;
				int previousDescent = 0;
				int previousBottom = 0;
				int previousLeading = 0;
				bool needUpdateMetrics = (fmi != null);
				if (needUpdateMetrics)
				{
					previousTop = fmi.top;
					previousAscent = fmi.ascent;
					previousDescent = fmi.descent;
					previousBottom = fmi.bottom;
					previousLeading = fmi.leading;
				}
				ret = replacement.getSize(wp, mText, textStart, textLimit, fmi);
				if (needUpdateMetrics)
				{
					updateMetrics(fmi, previousTop, previousAscent, previousDescent, previousBottom, 
						previousLeading);
				}
			}
			if (c != null)
			{
				if (runIsRtl)
				{
					x -= ret;
				}
				replacement.draw(c, mText, textStart, textLimit, x, top, y, bottom, wp);
			}
			return runIsRtl ? -ret : ret;
		}

		private partial class SpanSet<E>
		{
			internal readonly int numberOfSpans;

			internal readonly E[] spans;

			internal readonly int[] spanStarts;

			internal readonly int[] spanEnds;

			internal readonly int[] spanFlags;

			// These arrays may end up being too large because of empty spans
			internal virtual int getNextTransition(int start, int limit)
			{
				{
					for (int i = 0; i < numberOfSpans; i++)
					{
						int spanStart = spanStarts[i];
						int spanEnd = spanEnds[i];
						if (spanStart > start && spanStart < limit)
						{
							limit = spanStart;
						}
						if (spanEnd > start && spanEnd < limit)
						{
							limit = spanEnd;
						}
					}
				}
				return limit;
			}
		}

		// Case of an empty line, make sure we update fmi according to mPaint
		// Shaping needs to take into account context up to metric boundaries,
		// but rendering needs to take into account character style boundaries.
		// So we iterate through metric runs to get metric bounds,
		// then within each metric run iterate through character style runs
		// for the run bounds.
		// Both intervals [spanStarts..spanEnds] and [mStart + i..mStart + mlimit] are NOT
		// empty by construction. This special case in getSpans() explains the >= & <= tests
		// We might have a replacement that uses the draw
		// state, otherwise measure state would suffice.
		// Intentionally using >= and <= as explained above
		/// <summary>Render a text run with the set-up paint.</summary>
		/// <remarks>Render a text run with the set-up paint.</remarks>
		/// <param name="c">the canvas</param>
		/// <param name="wp">the paint used to render the text</param>
		/// <param name="start">the start of the run</param>
		/// <param name="end">the end of the run</param>
		/// <param name="contextStart">the start of context for the run</param>
		/// <param name="contextEnd">the end of the context for the run</param>
		/// <param name="runIsRtl">true if the run is right-to-left</param>
		/// <param name="x">the x position of the left edge of the run</param>
		/// <param name="y">the baseline of the run</param>
		private void drawTextRun(android.graphics.Canvas c, android.text.TextPaint wp, int
			 start, int end, int contextStart, int contextEnd, bool runIsRtl, float x, int y
			)
		{
			int flags = runIsRtl ? android.graphics.Canvas.DIRECTION_RTL : android.graphics.Canvas
				.DIRECTION_LTR;
			if (mCharsValid)
			{
				int count = end - start;
				int contextCount = contextEnd - contextStart;
				c.drawTextRun(mChars, start, count, contextStart, contextCount, x, y, flags, wp);
			}
			else
			{
				int delta = mStart;
				c.drawTextRun(mText, delta + start, delta + end, delta + contextStart, delta + contextEnd
					, x, y, flags, wp);
			}
		}

		/// <summary>Returns the ascent of the text at start.</summary>
		/// <remarks>
		/// Returns the ascent of the text at start.  This is used for scaling
		/// emoji.
		/// </remarks>
		/// <param name="pos">the line-relative position</param>
		/// <returns>the ascent of the text at start</returns>
		internal virtual float ascent(int pos)
		{
			if (mSpanned == null)
			{
				return mPaint.ascent();
			}
			pos += mStart;
			android.text.style.MetricAffectingSpan[] spans = mSpanned.getSpans<android.text.style.MetricAffectingSpan
				>(pos, pos + 1);
			if (spans.Length == 0)
			{
				return mPaint.ascent();
			}
			android.text.TextPaint wp = mWorkPaint;
			wp.set(mPaint);
			foreach (android.text.style.MetricAffectingSpan span in spans)
			{
				span.updateMeasureState(wp);
			}
			return wp.ascent();
		}

		/// <summary>Returns the next tab position.</summary>
		/// <remarks>Returns the next tab position.</remarks>
		/// <param name="h">the (unsigned) offset from the leading margin</param>
		/// <returns>the (unsigned) tab position after this offset</returns>
		internal virtual float nextTab(float h)
		{
			if (mTabs != null)
			{
				return mTabs.nextTab(h);
			}
			return android.text.Layout.TabStops.nextDefaultStop(h, TAB_INCREMENT);
		}

		internal const int TAB_INCREMENT = 20;
	}
}

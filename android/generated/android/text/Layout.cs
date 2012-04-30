using Sharpen;

namespace android.text
{
	/// <summary>
	/// A base class that manages text layout in visual elements on
	/// the screen.
	/// </summary>
	/// <remarks>
	/// A base class that manages text layout in visual elements on
	/// the screen.
	/// <p>For text that will be edited, use a
	/// <see cref="DynamicLayout">DynamicLayout</see>
	/// ,
	/// which will be updated as the text changes.
	/// For text that will not change, use a
	/// <see cref="StaticLayout">StaticLayout</see>
	/// .
	/// </remarks>
	[Sharpen.Sharpened]
	public abstract class Layout
	{
		private static readonly android.text.style.ParagraphStyle[] NO_PARA_SPANS = new android.text.style.ParagraphStyle
			[0];

		internal static readonly android.emoji.EmojiFactory EMOJI_FACTORY;

		internal static readonly int MIN_EMOJI;

		internal static readonly int MAX_EMOJI;

		static Layout()
		{
			if (EMOJI_FACTORY != null)
			{
				MIN_EMOJI = EMOJI_FACTORY.getMinimumAndroidPua();
				MAX_EMOJI = EMOJI_FACTORY.getMaximumAndroidPua();
			}
			else
			{
				MIN_EMOJI = -1;
				MAX_EMOJI = -1;
			}
		}

		/// <summary>
		/// Return how wide a layout must be in order to display the
		/// specified text with one line per paragraph.
		/// </summary>
		/// <remarks>
		/// Return how wide a layout must be in order to display the
		/// specified text with one line per paragraph.
		/// </remarks>
		public static float getDesiredWidth(java.lang.CharSequence source, android.text.TextPaint
			 paint)
		{
			return getDesiredWidth(source, 0, source.Length, paint);
		}

		/// <summary>
		/// Return how wide a layout must be in order to display the
		/// specified text slice with one line per paragraph.
		/// </summary>
		/// <remarks>
		/// Return how wide a layout must be in order to display the
		/// specified text slice with one line per paragraph.
		/// </remarks>
		public static float getDesiredWidth(java.lang.CharSequence source, int start, int
			 end, android.text.TextPaint paint)
		{
			float need = 0;
			android.text.TextPaint workPaint = new android.text.TextPaint();
			int next;
			{
				for (int i = start; i <= end; i = next)
				{
					next = android.text.TextUtils.indexOf(source, '\n', i, end);
					if (next < 0)
					{
						next = end;
					}
					// note, omits trailing paragraph char
					float w = measurePara(paint, workPaint, source, i, next);
					if (w > need)
					{
						need = w;
					}
					next++;
				}
			}
			return need;
		}

		/// <summary>
		/// Subclasses of Layout use this constructor to set the display text,
		/// width, and other standard properties.
		/// </summary>
		/// <remarks>
		/// Subclasses of Layout use this constructor to set the display text,
		/// width, and other standard properties.
		/// </remarks>
		/// <param name="text">the text to render</param>
		/// <param name="paint">
		/// the default paint for the layout.  Styles can override
		/// various attributes of the paint.
		/// </param>
		/// <param name="width">the wrapping width for the text.</param>
		/// <param name="align">
		/// whether to left, right, or center the text.  Styles can
		/// override the alignment.
		/// </param>
		/// <param name="spacingMult">
		/// factor by which to scale the font size to get the
		/// default line spacing
		/// </param>
		/// <param name="spacingAdd">amount to add to the default line spacing</param>
		protected internal Layout(java.lang.CharSequence text, android.text.TextPaint paint
			, int width, android.text.Layout.Alignment? align, float spacingMult, float spacingAdd
			) : this(text, paint, width, align, android.text.TextDirectionHeuristics.FIRSTSTRONG_LTR
			, spacingMult, spacingAdd)
		{
		}

		/// <summary>
		/// Subclasses of Layout use this constructor to set the display text,
		/// width, and other standard properties.
		/// </summary>
		/// <remarks>
		/// Subclasses of Layout use this constructor to set the display text,
		/// width, and other standard properties.
		/// </remarks>
		/// <param name="text">the text to render</param>
		/// <param name="paint">
		/// the default paint for the layout.  Styles can override
		/// various attributes of the paint.
		/// </param>
		/// <param name="width">the wrapping width for the text.</param>
		/// <param name="align">
		/// whether to left, right, or center the text.  Styles can
		/// override the alignment.
		/// </param>
		/// <param name="spacingMult">
		/// factor by which to scale the font size to get the
		/// default line spacing
		/// </param>
		/// <param name="spacingAdd">amount to add to the default line spacing</param>
		/// <hide></hide>
		protected internal Layout(java.lang.CharSequence text, android.text.TextPaint paint
			, int width, android.text.Layout.Alignment? align, android.text.TextDirectionHeuristic
			 textDir, float spacingMult, float spacingAdd)
		{
			if (width < 0)
			{
				throw new System.ArgumentException("Layout: " + width + " < 0");
			}
			// Ensure paint doesn't have baselineShift set.
			// While normally we don't modify the paint the user passed in,
			// we were already doing this in Styled.drawUniformRun with both
			// baselineShift and bgColor.  We probably should reevaluate bgColor.
			if (paint != null)
			{
				paint.bgColor = 0;
				paint.baselineShift = 0;
			}
			mText = text;
			mPaint = paint;
			mWorkPaint = new android.text.TextPaint();
			mWidth = width;
			mAlignment = align;
			mSpacingMult = spacingMult;
			mSpacingAdd = spacingAdd;
			mSpannedText = text is android.text.Spanned;
			mTextDir = textDir;
		}

		/// <summary>Replace constructor properties of this Layout with new ones.</summary>
		/// <remarks>Replace constructor properties of this Layout with new ones.  Be careful.
		/// 	</remarks>
		internal virtual void replaceWith(java.lang.CharSequence text, android.text.TextPaint
			 paint, int width, android.text.Layout.Alignment? align, float spacingmult, float
			 spacingadd)
		{
			if (width < 0)
			{
				throw new System.ArgumentException("Layout: " + width + " < 0");
			}
			mText = text;
			mPaint = paint;
			mWidth = width;
			mAlignment = align;
			mSpacingMult = spacingmult;
			mSpacingAdd = spacingadd;
			mSpannedText = text is android.text.Spanned;
		}

		/// <summary>Draw this Layout on the specified Canvas.</summary>
		/// <remarks>Draw this Layout on the specified Canvas.</remarks>
		public virtual void draw(android.graphics.Canvas c)
		{
			draw(c, null, null, 0);
		}

		/// <summary>
		/// Draw this Layout on the specified canvas, with the highlight path drawn
		/// between the background and the text.
		/// </summary>
		/// <remarks>
		/// Draw this Layout on the specified canvas, with the highlight path drawn
		/// between the background and the text.
		/// </remarks>
		/// <param name="c">the canvas</param>
		/// <param name="highlight">the path of the highlight or cursor; can be null</param>
		/// <param name="highlightPaint">the paint for the highlight</param>
		/// <param name="cursorOffsetVertical">
		/// the amount to temporarily translate the
		/// canvas while rendering the highlight
		/// </param>
		public virtual void draw(android.graphics.Canvas c, android.graphics.Path highlight
			, android.graphics.Paint highlightPaint, int cursorOffsetVertical)
		{
			int dtop;
			int dbottom;
			lock (sTempRect)
			{
				if (!c.getClipBounds(sTempRect))
				{
					return;
				}
				dtop = sTempRect.top;
				dbottom = sTempRect.bottom;
			}
			int top = 0;
			int bottom = getLineTop(getLineCount());
			if (dtop > top)
			{
				top = dtop;
			}
			if (dbottom < bottom)
			{
				bottom = dbottom;
			}
			int first = getLineForVertical(top);
			int last = getLineForVertical(bottom);
			int previousLineBottom = getLineTop(first);
			int previousLineEnd = getLineStart(first);
			android.text.TextPaint paint = mPaint;
			java.lang.CharSequence buf = mText;
			int width = mWidth;
			bool spannedText = mSpannedText;
			android.text.style.ParagraphStyle[] spans = NO_PARA_SPANS;
			int spanEnd = 0;
			int textLength = 0;
			// First, draw LineBackgroundSpans.
			// LineBackgroundSpans know nothing about the alignment, margins, or
			// direction of the layout or line.  XXX: Should they?
			// They are evaluated at each line.
			if (spannedText)
			{
				android.text.Spanned sp = (android.text.Spanned)buf;
				textLength = buf.Length;
				{
					for (int i = first; i <= last; i++)
					{
						int start = previousLineEnd;
						int end = getLineStart(i + 1);
						previousLineEnd = end;
						int ltop = previousLineBottom;
						int lbottom = getLineTop(i + 1);
						previousLineBottom = lbottom;
						int lbaseline = lbottom - getLineDescent(i);
						if (start >= spanEnd)
						{
							// These should be infrequent, so we'll use this so that
							// we don't have to check as often.
							spanEnd = sp.nextSpanTransition(start, textLength, typeof(android.text.style.LineBackgroundSpan
								));
							// All LineBackgroundSpans on a line contribute to its
							// background.
							spans = getParagraphSpans<android.text.style.LineBackgroundSpan>(sp, start, end);
						}
						{
							for (int n = 0; n < spans.Length; n++)
							{
								android.text.style.LineBackgroundSpan back = (android.text.style.LineBackgroundSpan
									)spans[n];
								back.drawBackground(c, paint, 0, width, ltop, lbaseline, lbottom, buf, start, end
									, i);
							}
						}
					}
				}
				// reset to their original values
				spanEnd = 0;
				previousLineBottom = getLineTop(first);
				previousLineEnd = getLineStart(first);
				spans = NO_PARA_SPANS;
			}
			// There can be a highlight even without spans if we are drawing
			// a non-spanned transformation of a spanned editing buffer.
			if (highlight != null)
			{
				if (cursorOffsetVertical != 0)
				{
					c.translate(0, cursorOffsetVertical);
				}
				c.drawPath(highlight, highlightPaint);
				if (cursorOffsetVertical != 0)
				{
					c.translate(0, -cursorOffsetVertical);
				}
			}
			android.text.Layout.Alignment? paraAlign = mAlignment;
			android.text.Layout.TabStops tabStops = null;
			bool tabStopsIsInitialized = false;
			android.text.TextLine tl = android.text.TextLine.obtain();
			{
				// Next draw the lines, one at a time.
				// the baseline is the top of the following line minus the current
				// line's descent.
				for (int i_1 = first; i_1 <= last; i_1++)
				{
					int start = previousLineEnd;
					previousLineEnd = getLineStart(i_1 + 1);
					int end = getLineVisibleEnd(i_1, start, previousLineEnd);
					int ltop = previousLineBottom;
					int lbottom = getLineTop(i_1 + 1);
					previousLineBottom = lbottom;
					int lbaseline = lbottom - getLineDescent(i_1);
					int dir = getParagraphDirection(i_1);
					int left = 0;
					int right = mWidth;
					if (spannedText)
					{
						android.text.Spanned sp = (android.text.Spanned)buf;
						bool isFirstParaLine = (start == 0 || buf[start - 1] == '\n');
						// New batch of paragraph styles, collect into spans array.
						// Compute the alignment, last alignment style wins.
						// Reset tabStops, we'll rebuild if we encounter a line with
						// tabs.
						// We expect paragraph spans to be relatively infrequent, use
						// spanEnd so that we can check less frequently.  Since
						// paragraph styles ought to apply to entire paragraphs, we can
						// just collect the ones present at the start of the paragraph.
						// If spanEnd is before the end of the paragraph, that's not
						// our problem.
						if (start >= spanEnd && (i_1 == first || isFirstParaLine))
						{
							spanEnd = sp.nextSpanTransition(start, textLength, typeof(android.text.style.ParagraphStyle
								));
							spans = getParagraphSpans<android.text.style.ParagraphStyle>(sp, start, spanEnd);
							paraAlign = mAlignment;
							{
								for (int n = spans.Length - 1; n >= 0; n--)
								{
									if (spans[n] is android.text.style.AlignmentSpan)
									{
										paraAlign = ((android.text.style.AlignmentSpan)spans[n]).getAlignment();
										break;
									}
								}
							}
							tabStopsIsInitialized = false;
						}
						// Draw all leading margin spans.  Adjust left or right according
						// to the paragraph direction of the line.
						int length = spans.Length;
						{
							for (int n_1 = 0; n_1 < length; n_1++)
							{
								if (spans[n_1] is android.text.style.LeadingMarginSpan)
								{
									android.text.style.LeadingMarginSpan margin = (android.text.style.LeadingMarginSpan
										)spans[n_1];
									bool useFirstLineMargin = isFirstParaLine;
									if (margin is android.text.style.LeadingMarginSpanClass.LeadingMarginSpan2)
									{
										int count = ((android.text.style.LeadingMarginSpanClass.LeadingMarginSpan2)margin
											).getLeadingMarginLineCount();
										int startLine = getLineForOffset(sp.getSpanStart(margin));
										useFirstLineMargin = i_1 < startLine + count;
									}
									if (dir == DIR_RIGHT_TO_LEFT)
									{
										margin.drawLeadingMargin(c, paint, right, dir, ltop, lbaseline, lbottom, buf, start
											, end, isFirstParaLine, this);
										right -= margin.getLeadingMargin(useFirstLineMargin);
									}
									else
									{
										margin.drawLeadingMargin(c, paint, left, dir, ltop, lbaseline, lbottom, buf, start
											, end, isFirstParaLine, this);
										left += margin.getLeadingMargin(useFirstLineMargin);
									}
								}
							}
						}
					}
					bool hasTabOrEmoji = getLineContainsTab(i_1);
					// Can't tell if we have tabs for sure, currently
					if (hasTabOrEmoji && !tabStopsIsInitialized)
					{
						if (tabStops == null)
						{
							tabStops = new android.text.Layout.TabStops(TAB_INCREMENT, spans);
						}
						else
						{
							tabStops.reset(TAB_INCREMENT, spans);
						}
						tabStopsIsInitialized = true;
					}
					// Determine whether the line aligns to normal, opposite, or center.
					android.text.Layout.Alignment? align = paraAlign;
					if (align == android.text.Layout.Alignment.ALIGN_LEFT)
					{
						align = (dir == DIR_LEFT_TO_RIGHT) ? android.text.Layout.Alignment.ALIGN_NORMAL : 
							android.text.Layout.Alignment.ALIGN_OPPOSITE;
					}
					else
					{
						if (align == android.text.Layout.Alignment.ALIGN_RIGHT)
						{
							align = (dir == DIR_LEFT_TO_RIGHT) ? android.text.Layout.Alignment.ALIGN_OPPOSITE
								 : android.text.Layout.Alignment.ALIGN_NORMAL;
						}
					}
					int x;
					if (align == android.text.Layout.Alignment.ALIGN_NORMAL)
					{
						if (dir == DIR_LEFT_TO_RIGHT)
						{
							x = left;
						}
						else
						{
							x = right;
						}
					}
					else
					{
						int max = (int)getLineExtent(i_1, tabStops, false);
						if (align == android.text.Layout.Alignment.ALIGN_OPPOSITE)
						{
							if (dir == DIR_LEFT_TO_RIGHT)
							{
								x = right - max;
							}
							else
							{
								x = left - max;
							}
						}
						else
						{
							// Alignment.ALIGN_CENTER
							max = max & ~1;
							x = (right + left - max) >> 1;
						}
					}
					android.text.Layout.Directions directions = getLineDirections(i_1);
					if (directions == DIRS_ALL_LEFT_TO_RIGHT && !spannedText && !hasTabOrEmoji)
					{
						// XXX: assumes there's nothing additional to be done
						c.drawText(buf, start, end, x, lbaseline, paint);
					}
					else
					{
						tl.set(paint, buf, start, end, dir, directions, hasTabOrEmoji, tabStops);
						tl.draw(c, x, ltop, lbaseline, lbottom);
					}
				}
			}
			android.text.TextLine.recycle(tl);
		}

		/// <summary>
		/// Return the start position of the line, given the left and right bounds
		/// of the margins.
		/// </summary>
		/// <remarks>
		/// Return the start position of the line, given the left and right bounds
		/// of the margins.
		/// </remarks>
		/// <param name="line">the line index</param>
		/// <param name="left">the left bounds (0, or leading margin if ltr para)</param>
		/// <param name="right">the right bounds (width, minus leading margin if rtl para)</param>
		/// <returns>the start position of the line (to right of line if rtl para)</returns>
		private int getLineStartPos(int line, int left, int right)
		{
			// Adjust the point at which to start rendering depending on the
			// alignment of the paragraph.
			android.text.Layout.Alignment? align = getParagraphAlignment(line);
			int dir = getParagraphDirection(line);
			int x;
			if (align == android.text.Layout.Alignment.ALIGN_LEFT)
			{
				x = left;
			}
			else
			{
				if (align == android.text.Layout.Alignment.ALIGN_NORMAL)
				{
					if (dir == DIR_LEFT_TO_RIGHT)
					{
						x = left;
					}
					else
					{
						x = right;
					}
				}
				else
				{
					android.text.Layout.TabStops tabStops = null;
					if (mSpannedText && getLineContainsTab(line))
					{
						android.text.Spanned spanned = (android.text.Spanned)mText;
						int start = getLineStart(line);
						int spanEnd = spanned.nextSpanTransition(start, spanned.Length, typeof(android.text.style.TabStopSpan
							));
						android.text.style.TabStopSpan[] tabSpans = getParagraphSpans<android.text.style.TabStopSpan
							>(spanned, start, spanEnd);
						if (tabSpans.Length > 0)
						{
							tabStops = new android.text.Layout.TabStops(TAB_INCREMENT, tabSpans);
						}
					}
					int max = (int)getLineExtent(line, tabStops, false);
					if (align == android.text.Layout.Alignment.ALIGN_RIGHT)
					{
						x = right - max;
					}
					else
					{
						if (align == android.text.Layout.Alignment.ALIGN_OPPOSITE)
						{
							if (dir == DIR_LEFT_TO_RIGHT)
							{
								x = right - max;
							}
							else
							{
								x = left - max;
							}
						}
						else
						{
							// Alignment.ALIGN_CENTER
							max = max & ~1;
							x = (left + right - max) >> 1;
						}
					}
				}
			}
			return x;
		}

		/// <summary>Return the text that is displayed by this Layout.</summary>
		/// <remarks>Return the text that is displayed by this Layout.</remarks>
		public java.lang.CharSequence getText()
		{
			return mText;
		}

		/// <summary>Return the base Paint properties for this layout.</summary>
		/// <remarks>
		/// Return the base Paint properties for this layout.
		/// Do NOT change the paint, which may result in funny
		/// drawing for this layout.
		/// </remarks>
		public android.text.TextPaint getPaint()
		{
			return mPaint;
		}

		/// <summary>Return the width of this layout.</summary>
		/// <remarks>Return the width of this layout.</remarks>
		public int getWidth()
		{
			return mWidth;
		}

		/// <summary>
		/// Return the width to which this Layout is ellipsizing, or
		/// <see cref="getWidth()">getWidth()</see>
		/// if it is not doing anything special.
		/// </summary>
		public virtual int getEllipsizedWidth()
		{
			return mWidth;
		}

		/// <summary>Increase the width of this layout to the specified width.</summary>
		/// <remarks>
		/// Increase the width of this layout to the specified width.
		/// Be careful to use this only when you know it is appropriate&mdash;
		/// it does not cause the text to reflow to use the full new width.
		/// </remarks>
		public void increaseWidthTo(int wid)
		{
			if (wid < mWidth)
			{
				throw new java.lang.RuntimeException("attempted to reduce Layout width");
			}
			mWidth = wid;
		}

		/// <summary>Return the total height of this layout.</summary>
		/// <remarks>Return the total height of this layout.</remarks>
		public virtual int getHeight()
		{
			return getLineTop(getLineCount());
		}

		/// <summary>Return the base alignment of this layout.</summary>
		/// <remarks>Return the base alignment of this layout.</remarks>
		public android.text.Layout.Alignment? getAlignment()
		{
			return mAlignment;
		}

		/// <summary>Return what the text height is multiplied by to get the line height.</summary>
		/// <remarks>Return what the text height is multiplied by to get the line height.</remarks>
		public float getSpacingMultiplier()
		{
			return mSpacingMult;
		}

		/// <summary>Return the number of units of leading that are added to each line.</summary>
		/// <remarks>Return the number of units of leading that are added to each line.</remarks>
		public float getSpacingAdd()
		{
			return mSpacingAdd;
		}

		/// <summary>Return the heuristic used to determine paragraph text direction.</summary>
		/// <remarks>Return the heuristic used to determine paragraph text direction.</remarks>
		/// <hide></hide>
		public android.text.TextDirectionHeuristic getTextDirectionHeuristic()
		{
			return mTextDir;
		}

		/// <summary>Return the number of lines of text in this layout.</summary>
		/// <remarks>Return the number of lines of text in this layout.</remarks>
		public abstract int getLineCount();

		/// <summary>
		/// Return the baseline for the specified line (0&hellip;getLineCount() - 1)
		/// If bounds is not null, return the top, left, right, bottom extents
		/// of the specified line in it.
		/// </summary>
		/// <remarks>
		/// Return the baseline for the specified line (0&hellip;getLineCount() - 1)
		/// If bounds is not null, return the top, left, right, bottom extents
		/// of the specified line in it.
		/// </remarks>
		/// <param name="line">which line to examine (0..getLineCount() - 1)</param>
		/// <param name="bounds">Optional. If not null, it returns the extent of the line</param>
		/// <returns>the Y-coordinate of the baseline</returns>
		public virtual int getLineBounds(int line, android.graphics.Rect bounds)
		{
			if (bounds != null)
			{
				bounds.left = 0;
				// ???
				bounds.top = getLineTop(line);
				bounds.right = mWidth;
				// ???
				bounds.bottom = getLineTop(line + 1);
			}
			return getLineBaseline(line);
		}

		/// <summary>
		/// Return the vertical position of the top of the specified line
		/// (0&hellip;getLineCount()).
		/// </summary>
		/// <remarks>
		/// Return the vertical position of the top of the specified line
		/// (0&hellip;getLineCount()).
		/// If the specified line is equal to the line count, returns the
		/// bottom of the last line.
		/// </remarks>
		public abstract int getLineTop(int line);

		/// <summary>Return the descent of the specified line(0&hellip;getLineCount() - 1).</summary>
		/// <remarks>Return the descent of the specified line(0&hellip;getLineCount() - 1).</remarks>
		public abstract int getLineDescent(int line);

		/// <summary>
		/// Return the text offset of the beginning of the specified line (
		/// 0&hellip;getLineCount()).
		/// </summary>
		/// <remarks>
		/// Return the text offset of the beginning of the specified line (
		/// 0&hellip;getLineCount()). If the specified line is equal to the line
		/// count, returns the length of the text.
		/// </remarks>
		public abstract int getLineStart(int line);

		/// <summary>
		/// Returns the primary directionality of the paragraph containing the
		/// specified line, either 1 for left-to-right lines, or -1 for right-to-left
		/// lines (see
		/// <see cref="DIR_LEFT_TO_RIGHT">DIR_LEFT_TO_RIGHT</see>
		/// ,
		/// <see cref="DIR_RIGHT_TO_LEFT">DIR_RIGHT_TO_LEFT</see>
		/// ).
		/// </summary>
		public abstract int getParagraphDirection(int line);

		/// <summary>
		/// Returns whether the specified line contains one or more
		/// characters that need to be handled specially, like tabs
		/// or emoji.
		/// </summary>
		/// <remarks>
		/// Returns whether the specified line contains one or more
		/// characters that need to be handled specially, like tabs
		/// or emoji.
		/// </remarks>
		public abstract bool getLineContainsTab(int line);

		/// <summary>Returns the directional run information for the specified line.</summary>
		/// <remarks>
		/// Returns the directional run information for the specified line.
		/// The array alternates counts of characters in left-to-right
		/// and right-to-left segments of the line.
		/// <p>NOTE: this is inadequate to support bidirectional text, and will change.
		/// </remarks>
		public abstract android.text.Layout.Directions getLineDirections(int line);

		/// <summary>
		/// Returns the (negative) number of extra pixels of ascent padding in the
		/// top line of the Layout.
		/// </summary>
		/// <remarks>
		/// Returns the (negative) number of extra pixels of ascent padding in the
		/// top line of the Layout.
		/// </remarks>
		public abstract int getTopPadding();

		/// <summary>
		/// Returns the number of extra pixels of descent padding in the
		/// bottom line of the Layout.
		/// </summary>
		/// <remarks>
		/// Returns the number of extra pixels of descent padding in the
		/// bottom line of the Layout.
		/// </remarks>
		public abstract int getBottomPadding();

		/// <summary>
		/// Returns true if the character at offset and the preceding character
		/// are at different run levels (and thus there's a split caret).
		/// </summary>
		/// <remarks>
		/// Returns true if the character at offset and the preceding character
		/// are at different run levels (and thus there's a split caret).
		/// </remarks>
		/// <param name="offset">the offset</param>
		/// <returns>true if at a level boundary</returns>
		/// <hide></hide>
		public virtual bool isLevelBoundary(int offset)
		{
			int line = getLineForOffset(offset);
			android.text.Layout.Directions dirs = getLineDirections(line);
			if (dirs == DIRS_ALL_LEFT_TO_RIGHT || dirs == DIRS_ALL_RIGHT_TO_LEFT)
			{
				return false;
			}
			int[] runs = dirs.mDirections;
			int lineStart = getLineStart(line);
			int lineEnd = getLineEnd(line);
			if (offset == lineStart || offset == lineEnd)
			{
				int paraLevel = getParagraphDirection(line) == 1 ? 0 : 1;
				int runIndex = offset == lineStart ? 0 : runs.Length - 2;
				return (((int)(((uint)runs[runIndex + 1]) >> RUN_LEVEL_SHIFT)) & RUN_LEVEL_MASK) 
					!= paraLevel;
			}
			offset -= lineStart;
			{
				for (int i = 0; i < runs.Length; i += 2)
				{
					if (offset == runs[i])
					{
						return true;
					}
				}
			}
			return false;
		}

		/// <summary>Returns true if the character at offset is right to left (RTL).</summary>
		/// <remarks>Returns true if the character at offset is right to left (RTL).</remarks>
		/// <param name="offset">the offset</param>
		/// <returns>true if the character is RTL, false if it is LTR</returns>
		public virtual bool isRtlCharAt(int offset)
		{
			int line = getLineForOffset(offset);
			android.text.Layout.Directions dirs = getLineDirections(line);
			if (dirs == DIRS_ALL_LEFT_TO_RIGHT)
			{
				return false;
			}
			if (dirs == DIRS_ALL_RIGHT_TO_LEFT)
			{
				return true;
			}
			int[] runs = dirs.mDirections;
			int lineStart = getLineStart(line);
			{
				for (int i = 0; i < runs.Length; i += 2)
				{
					int start = lineStart + (runs[i] & RUN_LENGTH_MASK);
					// No need to test the end as an offset after the last run should return the value
					// corresponding of the last run
					if (offset >= start)
					{
						int level = ((int)(((uint)runs[i + 1]) >> RUN_LEVEL_SHIFT)) & RUN_LEVEL_MASK;
						return ((level & 1) != 0);
					}
				}
			}
			// Should happen only if the offset is "out of bounds"
			return false;
		}

		private bool primaryIsTrailingPrevious(int offset)
		{
			int line = getLineForOffset(offset);
			int lineStart = getLineStart(line);
			int lineEnd = getLineEnd(line);
			int[] runs = getLineDirections(line).mDirections;
			int levelAt = -1;
			{
				for (int i = 0; i < runs.Length; i += 2)
				{
					int start = lineStart + runs[i];
					int limit = start + (runs[i + 1] & RUN_LENGTH_MASK);
					if (limit > lineEnd)
					{
						limit = lineEnd;
					}
					if (offset >= start && offset < limit)
					{
						if (offset > start)
						{
							// Previous character is at same level, so don't use trailing.
							return false;
						}
						levelAt = ((int)(((uint)runs[i + 1]) >> RUN_LEVEL_SHIFT)) & RUN_LEVEL_MASK;
						break;
					}
				}
			}
			if (levelAt == -1)
			{
				// Offset was limit of line.
				levelAt = getParagraphDirection(line) == 1 ? 0 : 1;
			}
			// At level boundary, check previous level.
			int levelBefore = -1;
			if (offset == lineStart)
			{
				levelBefore = getParagraphDirection(line) == 1 ? 0 : 1;
			}
			else
			{
				offset -= 1;
				{
					for (int i_1 = 0; i_1 < runs.Length; i_1 += 2)
					{
						int start = lineStart + runs[i_1];
						int limit = start + (runs[i_1 + 1] & RUN_LENGTH_MASK);
						if (limit > lineEnd)
						{
							limit = lineEnd;
						}
						if (offset >= start && offset < limit)
						{
							levelBefore = ((int)(((uint)runs[i_1 + 1]) >> RUN_LEVEL_SHIFT)) & RUN_LEVEL_MASK;
							break;
						}
					}
				}
			}
			return levelBefore < levelAt;
		}

		/// <summary>Get the primary horizontal position for the specified text offset.</summary>
		/// <remarks>
		/// Get the primary horizontal position for the specified text offset.
		/// This is the location where a new character would be inserted in
		/// the paragraph's primary direction.
		/// </remarks>
		public virtual float getPrimaryHorizontal(int offset)
		{
			bool trailing = primaryIsTrailingPrevious(offset);
			return getHorizontal(offset, trailing);
		}

		/// <summary>Get the secondary horizontal position for the specified text offset.</summary>
		/// <remarks>
		/// Get the secondary horizontal position for the specified text offset.
		/// This is the location where a new character would be inserted in
		/// the direction other than the paragraph's primary direction.
		/// </remarks>
		public virtual float getSecondaryHorizontal(int offset)
		{
			bool trailing = primaryIsTrailingPrevious(offset);
			return getHorizontal(offset, !trailing);
		}

		private float getHorizontal(int offset, bool trailing)
		{
			int line = getLineForOffset(offset);
			return getHorizontal(offset, trailing, line);
		}

		private float getHorizontal(int offset, bool trailing, int line)
		{
			int start = getLineStart(line);
			int end = getLineEnd(line);
			int dir = getParagraphDirection(line);
			bool hasTabOrEmoji = getLineContainsTab(line);
			android.text.Layout.Directions directions = getLineDirections(line);
			android.text.Layout.TabStops tabStops = null;
			if (hasTabOrEmoji && mText is android.text.Spanned)
			{
				// Just checking this line should be good enough, tabs should be
				// consistent across all lines in a paragraph.
				android.text.style.TabStopSpan[] tabs = getParagraphSpans<android.text.style.TabStopSpan
					>((android.text.Spanned)mText, start, end);
				if (tabs.Length > 0)
				{
					tabStops = new android.text.Layout.TabStops(TAB_INCREMENT, tabs);
				}
			}
			// XXX should reuse
			android.text.TextLine tl = android.text.TextLine.obtain();
			tl.set(mPaint, mText, start, end, dir, directions, hasTabOrEmoji, tabStops);
			float wid = tl.measure(offset - start, trailing, null);
			android.text.TextLine.recycle(tl);
			int left = getParagraphLeft(line);
			int right = getParagraphRight(line);
			return getLineStartPos(line, left, right) + wid;
		}

		/// <summary>
		/// Get the leftmost position that should be exposed for horizontal
		/// scrolling on the specified line.
		/// </summary>
		/// <remarks>
		/// Get the leftmost position that should be exposed for horizontal
		/// scrolling on the specified line.
		/// </remarks>
		public virtual float getLineLeft(int line)
		{
			int dir = getParagraphDirection(line);
			android.text.Layout.Alignment? align = getParagraphAlignment(line);
			if (align == android.text.Layout.Alignment.ALIGN_LEFT)
			{
				return 0;
			}
			else
			{
				if (align == android.text.Layout.Alignment.ALIGN_NORMAL)
				{
					if (dir == DIR_RIGHT_TO_LEFT)
					{
						return getParagraphRight(line) - getLineMax(line);
					}
					else
					{
						return 0;
					}
				}
				else
				{
					if (align == android.text.Layout.Alignment.ALIGN_RIGHT)
					{
						return mWidth - getLineMax(line);
					}
					else
					{
						if (align == android.text.Layout.Alignment.ALIGN_OPPOSITE)
						{
							if (dir == DIR_RIGHT_TO_LEFT)
							{
								return 0;
							}
							else
							{
								return mWidth - getLineMax(line);
							}
						}
						else
						{
							int left = getParagraphLeft(line);
							int right = getParagraphRight(line);
							int max = ((int)getLineMax(line)) & ~1;
							return left + ((right - left) - max) / 2;
						}
					}
				}
			}
		}

		/// <summary>
		/// Get the rightmost position that should be exposed for horizontal
		/// scrolling on the specified line.
		/// </summary>
		/// <remarks>
		/// Get the rightmost position that should be exposed for horizontal
		/// scrolling on the specified line.
		/// </remarks>
		public virtual float getLineRight(int line)
		{
			int dir = getParagraphDirection(line);
			android.text.Layout.Alignment? align = getParagraphAlignment(line);
			if (align == android.text.Layout.Alignment.ALIGN_LEFT)
			{
				return getParagraphLeft(line) + getLineMax(line);
			}
			else
			{
				if (align == android.text.Layout.Alignment.ALIGN_NORMAL)
				{
					if (dir == DIR_RIGHT_TO_LEFT)
					{
						return mWidth;
					}
					else
					{
						return getParagraphLeft(line) + getLineMax(line);
					}
				}
				else
				{
					if (align == android.text.Layout.Alignment.ALIGN_RIGHT)
					{
						return mWidth;
					}
					else
					{
						if (align == android.text.Layout.Alignment.ALIGN_OPPOSITE)
						{
							if (dir == DIR_RIGHT_TO_LEFT)
							{
								return getLineMax(line);
							}
							else
							{
								return mWidth;
							}
						}
						else
						{
							int left = getParagraphLeft(line);
							int right = getParagraphRight(line);
							int max = ((int)getLineMax(line)) & ~1;
							return right - ((right - left) - max) / 2;
						}
					}
				}
			}
		}

		/// <summary>
		/// Gets the unsigned horizontal extent of the specified line, including
		/// leading margin indent, but excluding trailing whitespace.
		/// </summary>
		/// <remarks>
		/// Gets the unsigned horizontal extent of the specified line, including
		/// leading margin indent, but excluding trailing whitespace.
		/// </remarks>
		public virtual float getLineMax(int line)
		{
			float margin = getParagraphLeadingMargin(line);
			float signedExtent = getLineExtent(line, false);
			return margin + signedExtent >= 0 ? signedExtent : -signedExtent;
		}

		/// <summary>
		/// Gets the unsigned horizontal extent of the specified line, including
		/// leading margin indent and trailing whitespace.
		/// </summary>
		/// <remarks>
		/// Gets the unsigned horizontal extent of the specified line, including
		/// leading margin indent and trailing whitespace.
		/// </remarks>
		public virtual float getLineWidth(int line)
		{
			float margin = getParagraphLeadingMargin(line);
			float signedExtent = getLineExtent(line, true);
			return margin + signedExtent >= 0 ? signedExtent : -signedExtent;
		}

		/// <summary>
		/// Like
		/// <see cref="getLineExtent(int, TabStops, bool)">getLineExtent(int, TabStops, bool)
		/// 	</see>
		/// but determines the
		/// tab stops instead of using the ones passed in.
		/// </summary>
		/// <param name="line">the index of the line</param>
		/// <param name="full">whether to include trailing whitespace</param>
		/// <returns>the extent of the line</returns>
		private float getLineExtent(int line, bool full)
		{
			int start = getLineStart(line);
			int end = full ? getLineEnd(line) : getLineVisibleEnd(line);
			bool hasTabsOrEmoji = getLineContainsTab(line);
			android.text.Layout.TabStops tabStops = null;
			if (hasTabsOrEmoji && mText is android.text.Spanned)
			{
				// Just checking this line should be good enough, tabs should be
				// consistent across all lines in a paragraph.
				android.text.style.TabStopSpan[] tabs = getParagraphSpans<android.text.style.TabStopSpan
					>((android.text.Spanned)mText, start, end);
				if (tabs.Length > 0)
				{
					tabStops = new android.text.Layout.TabStops(TAB_INCREMENT, tabs);
				}
			}
			// XXX should reuse
			android.text.Layout.Directions directions = getLineDirections(line);
			// Returned directions can actually be null
			if (directions == null)
			{
				return 0f;
			}
			int dir = getParagraphDirection(line);
			android.text.TextLine tl = android.text.TextLine.obtain();
			tl.set(mPaint, mText, start, end, dir, directions, hasTabsOrEmoji, tabStops);
			float width = tl.metrics(null);
			android.text.TextLine.recycle(tl);
			return width;
		}

		/// <summary>
		/// Returns the signed horizontal extent of the specified line, excluding
		/// leading margin.
		/// </summary>
		/// <remarks>
		/// Returns the signed horizontal extent of the specified line, excluding
		/// leading margin.  If full is false, excludes trailing whitespace.
		/// </remarks>
		/// <param name="line">the index of the line</param>
		/// <param name="tabStops">the tab stops, can be null if we know they're not used.</param>
		/// <param name="full">whether to include trailing whitespace</param>
		/// <returns>the extent of the text on this line</returns>
		internal float getLineExtent(int line, android.text.Layout.TabStops tabStops, bool
			 full)
		{
			int start = getLineStart(line);
			int end = full ? getLineEnd(line) : getLineVisibleEnd(line);
			bool hasTabsOrEmoji = getLineContainsTab(line);
			android.text.Layout.Directions directions = getLineDirections(line);
			int dir = getParagraphDirection(line);
			android.text.TextLine tl = android.text.TextLine.obtain();
			tl.set(mPaint, mText, start, end, dir, directions, hasTabsOrEmoji, tabStops);
			float width = tl.metrics(null);
			android.text.TextLine.recycle(tl);
			return width;
		}

		/// <summary>Get the line number corresponding to the specified vertical position.</summary>
		/// <remarks>
		/// Get the line number corresponding to the specified vertical position.
		/// If you ask for a position above 0, you get 0; if you ask for a position
		/// below the bottom of the text, you get the last line.
		/// </remarks>
		public virtual int getLineForVertical(int vertical)
		{
			// FIXME: It may be faster to do a linear search for layouts without many lines.
			int high = getLineCount();
			int low = -1;
			int guess;
			while (high - low > 1)
			{
				guess = (high + low) / 2;
				if (getLineTop(guess) > vertical)
				{
					high = guess;
				}
				else
				{
					low = guess;
				}
			}
			if (low < 0)
			{
				return 0;
			}
			else
			{
				return low;
			}
		}

		/// <summary>Get the line number on which the specified text offset appears.</summary>
		/// <remarks>
		/// Get the line number on which the specified text offset appears.
		/// If you ask for a position before 0, you get 0; if you ask for a position
		/// beyond the end of the text, you get the last line.
		/// </remarks>
		public virtual int getLineForOffset(int offset)
		{
			int high = getLineCount();
			int low = -1;
			int guess;
			while (high - low > 1)
			{
				guess = (high + low) / 2;
				if (getLineStart(guess) > offset)
				{
					high = guess;
				}
				else
				{
					low = guess;
				}
			}
			if (low < 0)
			{
				return 0;
			}
			else
			{
				return low;
			}
		}

		/// <summary>
		/// Get the character offset on the specified line whose position is
		/// closest to the specified horizontal position.
		/// </summary>
		/// <remarks>
		/// Get the character offset on the specified line whose position is
		/// closest to the specified horizontal position.
		/// </remarks>
		public virtual int getOffsetForHorizontal(int line, float horiz)
		{
			int max = getLineEnd(line) - 1;
			int min = getLineStart(line);
			android.text.Layout.Directions dirs = getLineDirections(line);
			if (line == getLineCount() - 1)
			{
				max++;
			}
			int best = min;
			float bestdist = System.Math.Abs(getPrimaryHorizontal(best) - horiz);
			{
				for (int i = 0; i < dirs.mDirections.Length; i += 2)
				{
					int here = min + dirs.mDirections[i];
					int there = here + (dirs.mDirections[i + 1] & RUN_LENGTH_MASK);
					int swap = (dirs.mDirections[i + 1] & RUN_RTL_FLAG) != 0 ? -1 : 1;
					if (there > max)
					{
						there = max;
					}
					int high = there - 1 + 1;
					int low = here + 1 - 1;
					int guess;
					while (high - low > 1)
					{
						guess = (high + low) / 2;
						int adguess = getOffsetAtStartOf(guess);
						if (getPrimaryHorizontal(adguess) * swap >= horiz * swap)
						{
							high = guess;
						}
						else
						{
							low = guess;
						}
					}
					if (low < here + 1)
					{
						low = here + 1;
					}
					if (low < there)
					{
						low = getOffsetAtStartOf(low);
						float dist = System.Math.Abs(getPrimaryHorizontal(low) - horiz);
						int aft = android.text.TextUtils.getOffsetAfter(mText, low);
						if (aft < there)
						{
							float other = System.Math.Abs(getPrimaryHorizontal(aft) - horiz);
							if (other < dist)
							{
								dist = other;
								low = aft;
							}
						}
						if (dist < bestdist)
						{
							bestdist = dist;
							best = low;
						}
					}
					float dist_1 = System.Math.Abs(getPrimaryHorizontal(here) - horiz);
					if (dist_1 < bestdist)
					{
						bestdist = dist_1;
						best = here;
					}
				}
			}
			float dist_2 = System.Math.Abs(getPrimaryHorizontal(max) - horiz);
			if (dist_2 < bestdist)
			{
				bestdist = dist_2;
				best = max;
			}
			return best;
		}

		/// <summary>Return the text offset after the last character on the specified line.</summary>
		/// <remarks>Return the text offset after the last character on the specified line.</remarks>
		public int getLineEnd(int line)
		{
			return getLineStart(line + 1);
		}

		/// <summary>
		/// Return the text offset after the last visible character (so whitespace
		/// is not counted) on the specified line.
		/// </summary>
		/// <remarks>
		/// Return the text offset after the last visible character (so whitespace
		/// is not counted) on the specified line.
		/// </remarks>
		public virtual int getLineVisibleEnd(int line)
		{
			return getLineVisibleEnd(line, getLineStart(line), getLineStart(line + 1));
		}

		private int getLineVisibleEnd(int line, int start, int end)
		{
			java.lang.CharSequence text = mText;
			char ch;
			if (line == getLineCount() - 1)
			{
				return end;
			}
			for (; end > start; end--)
			{
				ch = text[end - 1];
				if (ch == '\n')
				{
					return end - 1;
				}
				if (ch != ' ' && ch != '\t')
				{
					break;
				}
			}
			return end;
		}

		/// <summary>Return the vertical position of the bottom of the specified line.</summary>
		/// <remarks>Return the vertical position of the bottom of the specified line.</remarks>
		public int getLineBottom(int line)
		{
			return getLineTop(line + 1);
		}

		/// <summary>Return the vertical position of the baseline of the specified line.</summary>
		/// <remarks>Return the vertical position of the baseline of the specified line.</remarks>
		public int getLineBaseline(int line)
		{
			// getLineTop(line+1) == getLineTop(line)
			return getLineTop(line + 1) - getLineDescent(line);
		}

		/// <summary>Get the ascent of the text on the specified line.</summary>
		/// <remarks>
		/// Get the ascent of the text on the specified line.
		/// The return value is negative to match the Paint.ascent() convention.
		/// </remarks>
		public int getLineAscent(int line)
		{
			// getLineTop(line+1) - getLineDescent(line) == getLineBaseLine(line)
			return getLineTop(line) - (getLineTop(line + 1) - getLineDescent(line));
		}

		public virtual int getOffsetToLeftOf(int offset)
		{
			return getOffsetToLeftRightOf(offset, true);
		}

		public virtual int getOffsetToRightOf(int offset)
		{
			return getOffsetToLeftRightOf(offset, false);
		}

		private int getOffsetToLeftRightOf(int caret, bool toLeft)
		{
			int line = getLineForOffset(caret);
			int lineStart = getLineStart(line);
			int lineEnd = getLineEnd(line);
			int lineDir = getParagraphDirection(line);
			bool lineChanged = false;
			bool advance = toLeft == (lineDir == DIR_RIGHT_TO_LEFT);
			// if walking off line, look at the line we're headed to
			if (advance)
			{
				if (caret == lineEnd)
				{
					if (line < getLineCount() - 1)
					{
						lineChanged = true;
						++line;
					}
					else
					{
						return caret;
					}
				}
			}
			else
			{
				// at very end, don't move
				if (caret == lineStart)
				{
					if (line > 0)
					{
						lineChanged = true;
						--line;
					}
					else
					{
						return caret;
					}
				}
			}
			// at very start, don't move
			if (lineChanged)
			{
				lineStart = getLineStart(line);
				lineEnd = getLineEnd(line);
				int newDir = getParagraphDirection(line);
				if (newDir != lineDir)
				{
					// unusual case.  we want to walk onto the line, but it runs
					// in a different direction than this one, so we fake movement
					// in the opposite direction.
					toLeft = !toLeft;
					lineDir = newDir;
				}
			}
			android.text.Layout.Directions directions = getLineDirections(line);
			android.text.TextLine tl = android.text.TextLine.obtain();
			// XXX: we don't care about tabs
			tl.set(mPaint, mText, lineStart, lineEnd, lineDir, directions, false, null);
			caret = lineStart + tl.getOffsetToLeftRightOf(caret - lineStart, toLeft);
			tl = android.text.TextLine.recycle(tl);
			return caret;
		}

		private int getOffsetAtStartOf(int offset)
		{
			// XXX this probably should skip local reorderings and
			// zero-width characters, look at callers
			if (offset == 0)
			{
				return 0;
			}
			java.lang.CharSequence text = mText;
			char c = text[offset];
			if (c >= '\uDC00' && c <= '\uDFFF')
			{
				char c1 = text[offset - 1];
				if (c1 >= '\uD800' && c1 <= '\uDBFF')
				{
					offset -= 1;
				}
			}
			if (mSpannedText)
			{
				android.text.style.ReplacementSpan[] spans = ((android.text.Spanned)text).getSpans
					<android.text.style.ReplacementSpan>(offset, offset);
				{
					for (int i = 0; i < spans.Length; i++)
					{
						int start = ((android.text.Spanned)text).getSpanStart(spans[i]);
						int end = ((android.text.Spanned)text).getSpanEnd(spans[i]);
						if (start < offset && end > offset)
						{
							offset = start;
						}
					}
				}
			}
			return offset;
		}

		/// <summary>
		/// Fills in the specified Path with a representation of a cursor
		/// at the specified offset.
		/// </summary>
		/// <remarks>
		/// Fills in the specified Path with a representation of a cursor
		/// at the specified offset.  This will often be a vertical line
		/// but can be multiple discontinuous lines in text with multiple
		/// directionalities.
		/// </remarks>
		public virtual void getCursorPath(int point, android.graphics.Path dest, java.lang.CharSequence
			 editingBuffer)
		{
			dest.reset();
			int line = getLineForOffset(point);
			int top = getLineTop(line);
			int bottom = getLineTop(line + 1);
			float h1 = getPrimaryHorizontal(point) - 0.5f;
			float h2 = isLevelBoundary(point) ? getSecondaryHorizontal(point) - 0.5f : h1;
			int caps = android.text.method.TextKeyListener.getMetaState(editingBuffer, android.text.method.MetaKeyKeyListener
				.META_SHIFT_ON) | android.text.method.TextKeyListener.getMetaState(editingBuffer
				, android.text.method.MetaKeyKeyListener.META_SELECTING);
			int fn = android.text.method.TextKeyListener.getMetaState(editingBuffer, android.text.method.MetaKeyKeyListener
				.META_ALT_ON);
			int dist = 0;
			if (caps != 0 || fn != 0)
			{
				dist = (bottom - top) >> 2;
				if (fn != 0)
				{
					top += dist;
				}
				if (caps != 0)
				{
					bottom -= dist;
				}
			}
			if (h1 < 0.5f)
			{
				h1 = 0.5f;
			}
			if (h2 < 0.5f)
			{
				h2 = 0.5f;
			}
			if (h1.CompareTo(h2) == 0)
			{
				dest.moveTo(h1, top);
				dest.lineTo(h1, bottom);
			}
			else
			{
				dest.moveTo(h1, top);
				dest.lineTo(h1, (top + bottom) >> 1);
				dest.moveTo(h2, (top + bottom) >> 1);
				dest.lineTo(h2, bottom);
			}
			if (caps == 2)
			{
				dest.moveTo(h2, bottom);
				dest.lineTo(h2 - dist, bottom + dist);
				dest.lineTo(h2, bottom);
				dest.lineTo(h2 + dist, bottom + dist);
			}
			else
			{
				if (caps == 1)
				{
					dest.moveTo(h2, bottom);
					dest.lineTo(h2 - dist, bottom + dist);
					dest.moveTo(h2 - dist, bottom + dist - 0.5f);
					dest.lineTo(h2 + dist, bottom + dist - 0.5f);
					dest.moveTo(h2 + dist, bottom + dist);
					dest.lineTo(h2, bottom);
				}
			}
			if (fn == 2)
			{
				dest.moveTo(h1, top);
				dest.lineTo(h1 - dist, top - dist);
				dest.lineTo(h1, top);
				dest.lineTo(h1 + dist, top - dist);
			}
			else
			{
				if (fn == 1)
				{
					dest.moveTo(h1, top);
					dest.lineTo(h1 - dist, top - dist);
					dest.moveTo(h1 - dist, top - dist + 0.5f);
					dest.lineTo(h1 + dist, top - dist + 0.5f);
					dest.moveTo(h1 + dist, top - dist);
					dest.lineTo(h1, top);
				}
			}
		}

		private void addSelection(int line, int start, int end, int top, int bottom, android.graphics.Path
			 dest)
		{
			int linestart = getLineStart(line);
			int lineend = getLineEnd(line);
			android.text.Layout.Directions dirs = getLineDirections(line);
			if (lineend > linestart && mText[lineend - 1] == '\n')
			{
				lineend--;
			}
			{
				for (int i = 0; i < dirs.mDirections.Length; i += 2)
				{
					int here = linestart + dirs.mDirections[i];
					int there = here + (dirs.mDirections[i + 1] & RUN_LENGTH_MASK);
					if (there > lineend)
					{
						there = lineend;
					}
					if (start <= there && end >= here)
					{
						int st = System.Math.Max(start, here);
						int en = System.Math.Min(end, there);
						if (st != en)
						{
							float h1 = getHorizontal(st, false, line);
							float h2 = getHorizontal(en, true, line);
							float left = System.Math.Min(h1, h2);
							float right = System.Math.Max(h1, h2);
							dest.addRect(left, top, right, bottom, android.graphics.Path.Direction.CW);
						}
					}
				}
			}
		}

		/// <summary>
		/// Fills in the specified Path with a representation of a highlight
		/// between the specified offsets.
		/// </summary>
		/// <remarks>
		/// Fills in the specified Path with a representation of a highlight
		/// between the specified offsets.  This will often be a rectangle
		/// or a potentially discontinuous set of rectangles.  If the start
		/// and end are the same, the returned path is empty.
		/// </remarks>
		public virtual void getSelectionPath(int start, int end, android.graphics.Path dest
			)
		{
			dest.reset();
			if (start == end)
			{
				return;
			}
			if (end < start)
			{
				int temp = end;
				end = start;
				start = temp;
			}
			int startline = getLineForOffset(start);
			int endline = getLineForOffset(end);
			int top = getLineTop(startline);
			int bottom = getLineBottom(endline);
			if (startline == endline)
			{
				addSelection(startline, start, end, top, bottom, dest);
			}
			else
			{
				float width = mWidth;
				addSelection(startline, start, getLineEnd(startline), top, getLineBottom(startline
					), dest);
				if (getParagraphDirection(startline) == DIR_RIGHT_TO_LEFT)
				{
					dest.addRect(getLineLeft(startline), top, 0, getLineBottom(startline), android.graphics.Path.Direction
						.CW);
				}
				else
				{
					dest.addRect(getLineRight(startline), top, width, getLineBottom(startline), android.graphics.Path.Direction
						.CW);
				}
				{
					for (int i = startline + 1; i < endline; i++)
					{
						top = getLineTop(i);
						bottom = getLineBottom(i);
						dest.addRect(0, top, width, bottom, android.graphics.Path.Direction.CW);
					}
				}
				top = getLineTop(endline);
				bottom = getLineBottom(endline);
				addSelection(endline, getLineStart(endline), end, top, bottom, dest);
				if (getParagraphDirection(endline) == DIR_RIGHT_TO_LEFT)
				{
					dest.addRect(width, top, getLineRight(endline), bottom, android.graphics.Path.Direction
						.CW);
				}
				else
				{
					dest.addRect(0, top, getLineLeft(endline), bottom, android.graphics.Path.Direction
						.CW);
				}
			}
		}

		/// <summary>
		/// Get the alignment of the specified paragraph, taking into account
		/// markup attached to it.
		/// </summary>
		/// <remarks>
		/// Get the alignment of the specified paragraph, taking into account
		/// markup attached to it.
		/// </remarks>
		public android.text.Layout.Alignment? getParagraphAlignment(int line)
		{
			android.text.Layout.Alignment? align = mAlignment;
			if (mSpannedText)
			{
				android.text.Spanned sp = (android.text.Spanned)mText;
				android.text.style.AlignmentSpan[] spans = getParagraphSpans<android.text.style.AlignmentSpan
					>(sp, getLineStart(line), getLineEnd(line));
				int spanLength = spans.Length;
				if (spanLength > 0)
				{
					align = spans[spanLength - 1].getAlignment();
				}
			}
			return align;
		}

		/// <summary>Get the left edge of the specified paragraph, inset by left margins.</summary>
		/// <remarks>Get the left edge of the specified paragraph, inset by left margins.</remarks>
		public int getParagraphLeft(int line)
		{
			int left = 0;
			int dir = getParagraphDirection(line);
			if (dir == DIR_RIGHT_TO_LEFT || !mSpannedText)
			{
				return left;
			}
			// leading margin has no impact, or no styles
			return getParagraphLeadingMargin(line);
		}

		/// <summary>Get the right edge of the specified paragraph, inset by right margins.</summary>
		/// <remarks>Get the right edge of the specified paragraph, inset by right margins.</remarks>
		public int getParagraphRight(int line)
		{
			int right = mWidth;
			int dir = getParagraphDirection(line);
			if (dir == DIR_LEFT_TO_RIGHT || !mSpannedText)
			{
				return right;
			}
			// leading margin has no impact, or no styles
			return right - getParagraphLeadingMargin(line);
		}

		/// <summary>
		/// Returns the effective leading margin (unsigned) for this line,
		/// taking into account LeadingMarginSpan and LeadingMarginSpan2.
		/// </summary>
		/// <remarks>
		/// Returns the effective leading margin (unsigned) for this line,
		/// taking into account LeadingMarginSpan and LeadingMarginSpan2.
		/// </remarks>
		/// <param name="line">the line index</param>
		/// <returns>the leading margin of this line</returns>
		private int getParagraphLeadingMargin(int line)
		{
			if (!mSpannedText)
			{
				return 0;
			}
			android.text.Spanned spanned = (android.text.Spanned)mText;
			int lineStart = getLineStart(line);
			int lineEnd = getLineEnd(line);
			int spanEnd = spanned.nextSpanTransition(lineStart, lineEnd, typeof(android.text.style.LeadingMarginSpan
				));
			android.text.style.LeadingMarginSpan[] spans = getParagraphSpans<android.text.style.LeadingMarginSpan
				>(spanned, lineStart, spanEnd);
			if (spans.Length == 0)
			{
				return 0;
			}
			// no leading margin span;
			int margin = 0;
			bool isFirstParaLine = lineStart == 0 || spanned[lineStart - 1] == '\n';
			{
				for (int i = 0; i < spans.Length; i++)
				{
					android.text.style.LeadingMarginSpan span = spans[i];
					bool useFirstLineMargin = isFirstParaLine;
					if (span is android.text.style.LeadingMarginSpanClass.LeadingMarginSpan2)
					{
						int spStart = spanned.getSpanStart(span);
						int spanLine = getLineForOffset(spStart);
						int count = ((android.text.style.LeadingMarginSpanClass.LeadingMarginSpan2)span).
							getLeadingMarginLineCount();
						useFirstLineMargin = line < spanLine + count;
					}
					margin += span.getLeadingMargin(useFirstLineMargin);
				}
			}
			return margin;
		}

		internal static float measurePara(android.text.TextPaint paint, android.text.TextPaint
			 workPaint, java.lang.CharSequence text, int start, int end)
		{
			android.text.MeasuredText mt = android.text.MeasuredText.obtain();
			android.text.TextLine tl = android.text.TextLine.obtain();
			try
			{
				mt.setPara(text, start, end, android.text.TextDirectionHeuristics.LTR);
				android.text.Layout.Directions directions;
				int dir;
				if (mt.mEasy)
				{
					directions = DIRS_ALL_LEFT_TO_RIGHT;
					dir = android.text.Layout.DIR_LEFT_TO_RIGHT;
				}
				else
				{
					directions = android.text.AndroidBidi.directions(mt.mDir, mt.mLevels, 0, mt.mChars
						, 0, mt.mLen);
					dir = mt.mDir;
				}
				char[] chars = mt.mChars;
				int len = mt.mLen;
				bool hasTabs = false;
				android.text.Layout.TabStops tabStops = null;
				{
					for (int i = 0; i < len; ++i)
					{
						if (chars[i] == '\t')
						{
							hasTabs = true;
							if (text is android.text.Spanned)
							{
								android.text.Spanned spanned = (android.text.Spanned)text;
								int spanEnd = spanned.nextSpanTransition(start, end, typeof(android.text.style.TabStopSpan
									));
								android.text.style.TabStopSpan[] spans = getParagraphSpans<android.text.style.TabStopSpan
									>(spanned, start, spanEnd);
								if (spans.Length > 0)
								{
									tabStops = new android.text.Layout.TabStops(TAB_INCREMENT, spans);
								}
							}
							break;
						}
					}
				}
				tl.set(paint, text, start, end, dir, directions, hasTabs, tabStops);
				return tl.metrics(null);
			}
			finally
			{
				android.text.TextLine.recycle(tl);
				android.text.MeasuredText.recycle(mt);
			}
		}

		/// <hide></hide>
		internal class TabStops
		{
			private int[] mStops;

			private int mNumStops;

			private int mIncrement;

			internal TabStops(int increment, object[] spans)
			{
				reset(increment, spans);
			}

			internal virtual void reset(int increment, object[] spans)
			{
				this.mIncrement = increment;
				int ns = 0;
				if (spans != null)
				{
					int[] stops = this.mStops;
					foreach (object o in spans)
					{
						if (o is android.text.style.TabStopSpan)
						{
							if (stops == null)
							{
								stops = new int[10];
							}
							else
							{
								if (ns == stops.Length)
								{
									int[] nstops = new int[ns * 2];
									{
										for (int i = 0; i < ns; ++i)
										{
											nstops[i] = stops[i];
										}
									}
									stops = nstops;
								}
							}
							stops[ns++] = ((android.text.style.TabStopSpan)o).getTabStop();
						}
					}
					if (ns > 1)
					{
						java.util.Arrays.sort(stops, 0, ns);
					}
					if (stops != this.mStops)
					{
						this.mStops = stops;
					}
				}
				this.mNumStops = ns;
			}

			internal virtual float nextTab(float h)
			{
				int ns = this.mNumStops;
				if (ns > 0)
				{
					int[] stops = this.mStops;
					{
						for (int i = 0; i < ns; ++i)
						{
							int stop = stops[i];
							if (stop > h)
							{
								return stop;
							}
						}
					}
				}
				return nextDefaultStop(h, mIncrement);
			}

			public static float nextDefaultStop(float h, int inc)
			{
				return ((int)((h + inc) / inc)) * inc;
			}
		}

		/// <summary>Returns the position of the next tab stop after h on the line.</summary>
		/// <remarks>Returns the position of the next tab stop after h on the line.</remarks>
		/// <param name="text">the text</param>
		/// <param name="start">start of the line</param>
		/// <param name="end">limit of the line</param>
		/// <param name="h">the current horizontal offset</param>
		/// <param name="tabs">
		/// the tabs, can be null.  If it is null, any tabs in effect
		/// on the line will be used.  If there are no tabs, a default offset
		/// will be used to compute the tab stop.
		/// </param>
		/// <returns>the offset of the next tab stop.</returns>
		internal static float nextTab(java.lang.CharSequence text, int start, int end, float
			 h, object[] tabs)
		{
			float nh = float.MaxValue;
			bool alltabs = false;
			if (text is android.text.Spanned)
			{
				if (tabs == null)
				{
					tabs = getParagraphSpans<android.text.style.TabStopSpan>((android.text.Spanned)text
						, start, end);
					alltabs = true;
				}
				{
					for (int i = 0; i < tabs.Length; i++)
					{
						if (!alltabs)
						{
							if (!(tabs[i] is android.text.style.TabStopSpan))
							{
								continue;
							}
						}
						int where = ((android.text.style.TabStopSpan)tabs[i]).getTabStop();
						if (where < nh && where > h)
						{
							nh = where;
						}
					}
				}
				if (nh != float.MaxValue)
				{
					return nh;
				}
			}
			return ((int)((h + TAB_INCREMENT) / TAB_INCREMENT)) * TAB_INCREMENT;
		}

		protected internal bool isSpanned()
		{
			return mSpannedText;
		}

		/// <summary>
		/// Returns the same as <code>text.getSpans()</code>, except where
		/// <code>start</code> and <code>end</code> are the same and are not
		/// at the very beginning of the text, in which case an empty array
		/// is returned instead.
		/// </summary>
		/// <remarks>
		/// Returns the same as <code>text.getSpans()</code>, except where
		/// <code>start</code> and <code>end</code> are the same and are not
		/// at the very beginning of the text, in which case an empty array
		/// is returned instead.
		/// <p>
		/// This is needed because of the special case that <code>getSpans()</code>
		/// on an empty range returns the spans adjacent to that range, which is
		/// primarily for the sake of <code>TextWatchers</code> so they will get
		/// notifications when text goes from empty to non-empty.  But it also
		/// has the unfortunate side effect that if the text ends with an empty
		/// paragraph, that paragraph accidentally picks up the styles of the
		/// preceding paragraph (even though those styles will not be picked up
		/// by new text that is inserted into the empty paragraph).
		/// <p>
		/// The reason it just checks whether <code>start</code> and <code>end</code>
		/// is the same is that the only time a line can contain 0 characters
		/// is if it is the final paragraph of the Layout; otherwise any line will
		/// contain at least one printing or newline character.  The reason for the
		/// additional check if <code>start</code> is greater than 0 is that
		/// if the empty paragraph is the entire content of the buffer, paragraph
		/// styles that are already applied to the buffer will apply to text that
		/// is inserted into it.
		/// </remarks>
		internal static T[] getParagraphSpans<T>(android.text.Spanned text, int start, int
			 end)
		{
			System.Type type = typeof(T);
			if (start == end && start > 0)
			{
				return (T[])new T[0];
			}
			return text.getSpans<T>(start, end);
		}

		private void ellipsize(int start, int end, int line, char[] dest, int destoff)
		{
			int ellipsisCount = getEllipsisCount(line);
			if (ellipsisCount == 0)
			{
				return;
			}
			int ellipsisStart = getEllipsisStart(line);
			int linestart = getLineStart(line);
			{
				for (int i = ellipsisStart; i < ellipsisStart + ellipsisCount; i++)
				{
					char c;
					if (i == ellipsisStart)
					{
						c = '\u2026';
					}
					else
					{
						// ellipsis
						c = '\uFEFF';
					}
					// 0-width space
					int a = i + linestart;
					if (a >= start && a < end)
					{
						dest[destoff + a - start] = c;
					}
				}
			}
		}

		/// <summary>
		/// Stores information about bidirectional (left-to-right or right-to-left)
		/// text within the layout of a line.
		/// </summary>
		/// <remarks>
		/// Stores information about bidirectional (left-to-right or right-to-left)
		/// text within the layout of a line.
		/// </remarks>
		public class Directions
		{
			internal int[] mDirections;

			internal Directions(int[] dirs)
			{
				// Directions represents directional runs within a line of text.
				// Runs are pairs of ints listed in visual order, starting from the
				// leading margin.  The first int of each pair is the offset from
				// the first character of the line to the start of the run.  The
				// second int represents both the length and level of the run.
				// The length is in the lower bits, accessed by masking with
				// DIR_LENGTH_MASK.  The level is in the higher bits, accessed
				// by shifting by DIR_LEVEL_SHIFT and masking by DIR_LEVEL_MASK.
				// To simply test for an RTL direction, test the bit using
				// DIR_RTL_FLAG, if set then the direction is rtl.
				mDirections = dirs;
			}
		}

		/// <summary>
		/// Return the offset of the first character to be ellipsized away,
		/// relative to the start of the line.
		/// </summary>
		/// <remarks>
		/// Return the offset of the first character to be ellipsized away,
		/// relative to the start of the line.  (So 0 if the beginning of the
		/// line is ellipsized, not getLineStart().)
		/// </remarks>
		public abstract int getEllipsisStart(int line);

		/// <summary>
		/// Returns the number of characters to be ellipsized away, or 0 if
		/// no ellipsis is to take place.
		/// </summary>
		/// <remarks>
		/// Returns the number of characters to be ellipsized away, or 0 if
		/// no ellipsis is to take place.
		/// </remarks>
		public abstract int getEllipsisCount(int line);

		internal class Ellipsizer : java.lang.CharSequence, android.text.GetChars
		{
			internal java.lang.CharSequence mText;

			internal android.text.Layout mLayout;

			internal int mWidth;

			internal android.text.TextUtils.TruncateAt? mMethod;

			public Ellipsizer(java.lang.CharSequence s)
			{
				mText = s;
			}

			public virtual char this[int off]
			{
				get
				{
					char[] buf = android.text.TextUtils.obtain(1);
					getChars(off, off + 1, buf, 0);
					char ret = buf[0];
					android.text.TextUtils.recycle(buf);
					return ret;
				}
			}

			[Sharpen.ImplementsInterface(@"android.text.GetChars")]
			public virtual void getChars(int start, int end, char[] dest, int destoff)
			{
				int line1 = mLayout.getLineForOffset(start);
				int line2 = mLayout.getLineForOffset(end);
				android.text.TextUtils.getChars(mText, start, end, dest, destoff);
				{
					for (int i = line1; i <= line2; i++)
					{
						mLayout.ellipsize(start, end, i, dest, destoff);
					}
				}
			}

			public virtual int Length
			{
				get
				{
					return mText.Length;
				}
			}

			[Sharpen.ImplementsInterface(@"java.lang.CharSequence")]
			public virtual java.lang.CharSequence SubSequence(int start, int end)
			{
				char[] s = new char[end - start];
				getChars(start, end, s, 0);
				return java.lang.CharSequenceProxy.Wrap(new string(s));
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override string ToString()
			{
				char[] s = new char[Length];
				getChars(0, Length, s, 0);
				return new string(s);
			}
		}

		internal class SpannedEllipsizer : android.text.Layout.Ellipsizer, android.text.Spanned
		{
			private android.text.Spanned mSpanned;

			public SpannedEllipsizer(java.lang.CharSequence display) : base(display)
			{
				mSpanned = (android.text.Spanned)display;
			}

			[Sharpen.Proxy]
			T[] android.text.Spanned.getSpans<T>(int start, int end)
			{
				System.Type type = typeof(T);
				return getSpans<T>(start, end);
			}

			[Sharpen.ImplementsInterface(@"android.text.Spanned")]
			public virtual T[] getSpans<T>(int start, int end)
			{
				System.Type type = typeof(T);
				return mSpanned.getSpans<T>(start, end);
			}

			[Sharpen.ImplementsInterface(@"android.text.Spanned")]
			public virtual int getSpanStart(object tag)
			{
				return mSpanned.getSpanStart(tag);
			}

			[Sharpen.ImplementsInterface(@"android.text.Spanned")]
			public virtual int getSpanEnd(object tag)
			{
				return mSpanned.getSpanEnd(tag);
			}

			[Sharpen.ImplementsInterface(@"android.text.Spanned")]
			public virtual int getSpanFlags(object tag)
			{
				return mSpanned.getSpanFlags(tag);
			}

			[Sharpen.ImplementsInterface(@"android.text.Spanned")]
			public virtual int nextSpanTransition(int start, int limit, System.Type type)
			{
				return mSpanned.nextSpanTransition(start, limit, type);
			}

			[Sharpen.OverridesMethod(@"android.text.Layout.Ellipsizer")]
			public override java.lang.CharSequence SubSequence(int start, int end)
			{
				char[] s = new char[end - start];
				getChars(start, end, s, 0);
				android.text.SpannableString ss = new android.text.SpannableString(java.lang.CharSequenceProxy.Wrap
					(new string(s)));
				android.text.TextUtils.copySpansFrom(mSpanned, start, end, typeof(object), ss, 0);
				return ss;
			}
		}

		private java.lang.CharSequence mText;

		private android.text.TextPaint mPaint;

		internal android.text.TextPaint mWorkPaint;

		private int mWidth;

		private android.text.Layout.Alignment? mAlignment = android.text.Layout.Alignment
			.ALIGN_NORMAL;

		private float mSpacingMult;

		private float mSpacingAdd;

		private static readonly android.graphics.Rect sTempRect = new android.graphics.Rect
			();

		private bool mSpannedText;

		private android.text.TextDirectionHeuristic mTextDir;

		public const int DIR_LEFT_TO_RIGHT = 1;

		public const int DIR_RIGHT_TO_LEFT = -1;

		internal const int DIR_REQUEST_LTR = 1;

		internal const int DIR_REQUEST_RTL = -1;

		internal const int DIR_REQUEST_DEFAULT_LTR = 2;

		internal const int DIR_REQUEST_DEFAULT_RTL = -2;

		internal const int RUN_LENGTH_MASK = unchecked((int)(0x03ffffff));

		internal const int RUN_LEVEL_SHIFT = 26;

		internal const int RUN_LEVEL_MASK = unchecked((int)(0x3f));

		internal const int RUN_RTL_FLAG = 1 << RUN_LEVEL_SHIFT;

		public enum Alignment
		{
			ALIGN_NORMAL,
			ALIGN_OPPOSITE,
			ALIGN_CENTER,
			/// <hide></hide>
			ALIGN_LEFT,
			/// <hide></hide>
			ALIGN_RIGHT
		}

		internal const int TAB_INCREMENT = 20;

		internal static readonly android.text.Layout.Directions DIRS_ALL_LEFT_TO_RIGHT = 
			new android.text.Layout.Directions(new int[] { 0, RUN_LENGTH_MASK });

		internal static readonly android.text.Layout.Directions DIRS_ALL_RIGHT_TO_LEFT = 
			new android.text.Layout.Directions(new int[] { 0, RUN_LENGTH_MASK | RUN_RTL_FLAG
			 });
	}
}

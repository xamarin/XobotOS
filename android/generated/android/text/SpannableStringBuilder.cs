using Sharpen;

namespace android.text
{
	/// <summary>This is the class for text whose content and markup can both be changed.
	/// 	</summary>
	/// <remarks>This is the class for text whose content and markup can both be changed.
	/// 	</remarks>
	[Sharpen.Sharpened]
	public partial class SpannableStringBuilder : java.lang.CharSequence, android.text.GetChars
		, android.text.Spannable, android.text.Editable, java.lang.Appendable, android.text.GraphicsOperations
	{
		/// <summary>Create a new SpannableStringBuilder with empty contents</summary>
		public SpannableStringBuilder() : this(java.lang.CharSequenceProxy.Wrap(string.Empty
			))
		{
		}

		/// <summary>
		/// Create a new SpannableStringBuilder containing a copy of the
		/// specified text, including its spans if any.
		/// </summary>
		/// <remarks>
		/// Create a new SpannableStringBuilder containing a copy of the
		/// specified text, including its spans if any.
		/// </remarks>
		public SpannableStringBuilder(java.lang.CharSequence text) : this(text, 0, text.Length
			)
		{
		}

		/// <summary>
		/// Create a new SpannableStringBuilder containing a copy of the
		/// specified slice of the specified text, including its spans if any.
		/// </summary>
		/// <remarks>
		/// Create a new SpannableStringBuilder containing a copy of the
		/// specified slice of the specified text, including its spans if any.
		/// </remarks>
		public SpannableStringBuilder(java.lang.CharSequence text, int start, int end)
		{
			int srclen = end - start;
			int len = android.util.@internal.ArrayUtils.idealCharArraySize(srclen + 1);
			mText = new char[len];
			mGapStart = srclen;
			mGapLength = len - srclen;
			android.text.TextUtils.getChars(text, start, end, mText, 0);
			mSpanCount = 0;
			int alloc = android.util.@internal.ArrayUtils.idealIntArraySize(0);
			mSpans = new object[alloc];
			mSpanStarts = new int[alloc];
			mSpanEnds = new int[alloc];
			mSpanFlags = new int[alloc];
			if (text is android.text.Spanned)
			{
				android.text.Spanned sp = (android.text.Spanned)text;
				object[] spans = sp.getSpans<object>(start, end);
				{
					for (int i = 0; i < spans.Length; i++)
					{
						if (spans[i] is android.text.NoCopySpan)
						{
							continue;
						}
						int st = sp.getSpanStart(spans[i]) - start;
						int en = sp.getSpanEnd(spans[i]) - start;
						int fl = sp.getSpanFlags(spans[i]);
						if (st < 0)
						{
							st = 0;
						}
						if (st > end - start)
						{
							st = end - start;
						}
						if (en < 0)
						{
							en = 0;
						}
						if (en > end - start)
						{
							en = end - start;
						}
						setSpan(spans[i], st, en, fl);
					}
				}
			}
		}

		public static android.text.SpannableStringBuilder valueOf(java.lang.CharSequence 
			source)
		{
			if (source is android.text.SpannableStringBuilder)
			{
				return (android.text.SpannableStringBuilder)source;
			}
			else
			{
				return new android.text.SpannableStringBuilder(source);
			}
		}

		/// <summary>Return the char at the specified offset within the buffer.</summary>
		/// <remarks>Return the char at the specified offset within the buffer.</remarks>
		public virtual char this[int where]
		{
			get
			{
				int len = Length;
				if (where < 0)
				{
					throw new System.IndexOutOfRangeException("charAt: " + where + " < 0");
				}
				else
				{
					if (where >= len)
					{
						throw new System.IndexOutOfRangeException("charAt: " + where + " >= length " + len
							);
					}
				}
				if (where >= mGapStart)
				{
					return mText[where + mGapLength];
				}
				else
				{
					return mText[where];
				}
			}
		}

		/// <summary>Return the number of chars in the buffer.</summary>
		/// <remarks>Return the number of chars in the buffer.</remarks>
		public virtual int Length
		{
			get
			{
				return mText.Length - mGapLength;
			}
		}

		private void resizeFor(int size)
		{
			int newlen = android.util.@internal.ArrayUtils.idealCharArraySize(size + 1);
			char[] newtext = new char[newlen];
			int after = mText.Length - (mGapStart + mGapLength);
			System.Array.Copy(mText, 0, newtext, 0, mGapStart);
			System.Array.Copy(mText, mText.Length - after, newtext, newlen - after, after);
			{
				for (int i = 0; i < mSpanCount; i++)
				{
					if (mSpanStarts[i] > mGapStart)
					{
						mSpanStarts[i] += newlen - mText.Length;
					}
					if (mSpanEnds[i] > mGapStart)
					{
						mSpanEnds[i] += newlen - mText.Length;
					}
				}
			}
			int oldlen = mText.Length;
			mText = newtext;
			mGapLength += mText.Length - oldlen;
			if (mGapLength < 1)
			{
				XobotOS.Runtime.Util.PrintStackTrace(new System.Exception("mGapLength < 1"));
			}
		}

		private void moveGapTo(int where)
		{
			if (where == mGapStart)
			{
				return;
			}
			bool atend = (where == Length);
			if (where < mGapStart)
			{
				int overlap = mGapStart - where;
				System.Array.Copy(mText, where, mText, mGapStart + mGapLength - overlap, overlap);
			}
			else
			{
				int overlap = where - mGapStart;
				System.Array.Copy(mText, where + mGapLength - overlap, mText, mGapStart, overlap);
			}
			{
				// XXX be more clever
				for (int i = 0; i < mSpanCount; i++)
				{
					int start = mSpanStarts[i];
					int end = mSpanEnds[i];
					if (start > mGapStart)
					{
						start -= mGapLength;
					}
					if (start > where)
					{
						start += mGapLength;
					}
					else
					{
						if (start == where)
						{
							int flag = (mSpanFlags[i] & START_MASK) >> START_SHIFT;
							if (flag == POINT || (atend && flag == PARAGRAPH))
							{
								start += mGapLength;
							}
						}
					}
					if (end > mGapStart)
					{
						end -= mGapLength;
					}
					if (end > where)
					{
						end += mGapLength;
					}
					else
					{
						if (end == where)
						{
							int flag = (mSpanFlags[i] & END_MASK);
							if (flag == POINT || (atend && flag == PARAGRAPH))
							{
								end += mGapLength;
							}
						}
					}
					mSpanStarts[i] = start;
					mSpanEnds[i] = end;
				}
			}
			mGapStart = where;
		}

		[Sharpen.Proxy]
		android.text.Editable android.text.Editable.insert(int where, java.lang.CharSequence
			 tb, int start, int end)
		{
			return insert(where, tb, start, end);
		}

		// Documentation from interface
		[Sharpen.ImplementsInterface(@"android.text.Editable")]
		public virtual android.text.SpannableStringBuilder insert(int where, java.lang.CharSequence
			 tb, int start, int end)
		{
			return replace(where, where, tb, start, end);
		}

		[Sharpen.Proxy]
		android.text.Editable android.text.Editable.insert(int where, java.lang.CharSequence
			 tb)
		{
			return insert(where, tb);
		}

		// Documentation from interface
		[Sharpen.ImplementsInterface(@"android.text.Editable")]
		public virtual android.text.SpannableStringBuilder insert(int where, java.lang.CharSequence
			 tb)
		{
			return replace(where, where, tb, 0, tb.Length);
		}

		[Sharpen.Proxy]
		android.text.Editable android.text.Editable.delete(int start, int end)
		{
			return delete(start, end);
		}

		// Documentation from interface
		[Sharpen.ImplementsInterface(@"android.text.Editable")]
		public virtual android.text.SpannableStringBuilder delete(int start, int end)
		{
			android.text.SpannableStringBuilder ret = replace(start, end, java.lang.CharSequenceProxy.Wrap
				(string.Empty), 0, 0);
			if (mGapLength > 2 * Length)
			{
				resizeFor(Length);
			}
			return ret;
		}

		// == this
		// Documentation from interface
		[Sharpen.ImplementsInterface(@"android.text.Editable")]
		public virtual void clear()
		{
			replace(0, Length, java.lang.CharSequenceProxy.Wrap(string.Empty), 0, 0);
		}

		// Documentation from interface
		[Sharpen.ImplementsInterface(@"android.text.Editable")]
		public virtual void clearSpans()
		{
			{
				for (int i = mSpanCount - 1; i >= 0; i--)
				{
					object what = mSpans[i];
					int ostart = mSpanStarts[i];
					int oend = mSpanEnds[i];
					if (ostart > mGapStart)
					{
						ostart -= mGapLength;
					}
					if (oend > mGapStart)
					{
						oend -= mGapLength;
					}
					mSpanCount = i;
					mSpans[i] = null;
					sendSpanRemoved(what, ostart, oend);
				}
			}
		}

		[Sharpen.Proxy]
		java.lang.Appendable java.lang.Appendable.append(java.lang.CharSequence text)
		{
			return append(text);
		}

		[Sharpen.Proxy]
		android.text.Editable android.text.Editable.append(java.lang.CharSequence text)
		{
			return append(text);
		}

		// Documentation from interface
		[Sharpen.ImplementsInterface(@"java.lang.Appendable")]
		public virtual android.text.SpannableStringBuilder append(java.lang.CharSequence 
			text)
		{
			int length_1 = Length;
			return replace(length_1, length_1, text, 0, text.Length);
		}

		[Sharpen.Proxy]
		java.lang.Appendable java.lang.Appendable.append(java.lang.CharSequence text, int
			 start, int end)
		{
			return append(text, start, end);
		}

		[Sharpen.Proxy]
		android.text.Editable android.text.Editable.append(java.lang.CharSequence text, int
			 start, int end)
		{
			return append(text, start, end);
		}

		// Documentation from interface
		[Sharpen.ImplementsInterface(@"java.lang.Appendable")]
		public virtual android.text.SpannableStringBuilder append(java.lang.CharSequence 
			text, int start, int end)
		{
			int length_1 = Length;
			return replace(length_1, length_1, text, start, end);
		}

		[Sharpen.Proxy]
		java.lang.Appendable java.lang.Appendable.append(char text)
		{
			return append(text);
		}

		[Sharpen.Proxy]
		android.text.Editable android.text.Editable.append(char text)
		{
			return append(text);
		}

		// Documentation from interface
		[Sharpen.ImplementsInterface(@"java.lang.Appendable")]
		public virtual android.text.SpannableStringBuilder append(char text)
		{
			return append(java.lang.CharSequenceProxy.Wrap(text.ToString()));
		}

		private int change(int start, int end, java.lang.CharSequence tb, int tbstart, int
			 tbend)
		{
			return change(true, start, end, tb, tbstart, tbend);
		}

		private int change(bool notify_1, int start, int end, java.lang.CharSequence tb, 
			int tbstart, int tbend)
		{
			checkRange("replace", start, end);
			int ret = tbend - tbstart;
			android.text.TextWatcher[] recipients = null;
			if (notify_1)
			{
				recipients = sendTextWillChange(start, end - start, tbend - tbstart);
			}
			{
				for (int i = mSpanCount - 1; i >= 0; i--)
				{
					if ((mSpanFlags[i] & android.text.SpannedClass.SPAN_PARAGRAPH) == android.text.SpannedClass.SPAN_PARAGRAPH)
					{
						int st = mSpanStarts[i];
						if (st > mGapStart)
						{
							st -= mGapLength;
						}
						int en = mSpanEnds[i];
						if (en > mGapStart)
						{
							en -= mGapLength;
						}
						int ost = st;
						int oen = en;
						int clen = Length;
						if (st > start && st <= end)
						{
							for (st = end; st < clen; st++)
							{
								if (st > end && this[st - 1] == '\n')
								{
									break;
								}
							}
						}
						if (en > start && en <= end)
						{
							for (en = end; en < clen; en++)
							{
								if (en > end && this[en - 1] == '\n')
								{
									break;
								}
							}
						}
						if (st != ost || en != oen)
						{
							setSpan(mSpans[i], st, en, mSpanFlags[i]);
						}
					}
				}
			}
			moveGapTo(end);
			// Can be negative
			int nbNewChars = (tbend - tbstart) - (end - start);
			if (nbNewChars >= mGapLength)
			{
				resizeFor(mText.Length + nbNewChars - mGapLength);
			}
			mGapStart += nbNewChars;
			mGapLength -= nbNewChars;
			if (mGapLength < 1)
			{
				XobotOS.Runtime.Util.PrintStackTrace(new System.Exception("mGapLength < 1"));
			}
			android.text.TextUtils.getChars(tb, tbstart, tbend, mText, start);
			if (tb is android.text.Spanned)
			{
				android.text.Spanned sp = (android.text.Spanned)tb;
				object[] spans = sp.getSpans<object>(tbstart, tbend);
				{
					for (int i_1 = 0; i_1 < spans.Length; i_1++)
					{
						int st = sp.getSpanStart(spans[i_1]);
						int en = sp.getSpanEnd(spans[i_1]);
						if (st < tbstart)
						{
							st = tbstart;
						}
						if (en > tbend)
						{
							en = tbend;
						}
						if (getSpanStart(spans[i_1]) < 0)
						{
							setSpan(false, spans[i_1], st - tbstart + start, en - tbstart + start, sp.getSpanFlags
								(spans[i_1]));
						}
					}
				}
			}
			// no need for span fixup on pure insertion
			if (tbend > tbstart && end - start == 0)
			{
				if (notify_1)
				{
					sendTextChange(recipients, start, end - start, tbend - tbstart);
					sendTextHasChanged(recipients);
				}
				return ret;
			}
			bool atend = (mGapStart + mGapLength == mText.Length);
			{
				for (int i_2 = mSpanCount - 1; i_2 >= 0; i_2--)
				{
					if (mSpanStarts[i_2] >= start && mSpanStarts[i_2] < mGapStart + mGapLength)
					{
						int flag = (mSpanFlags[i_2] & START_MASK) >> START_SHIFT;
						if (flag == POINT || (flag == PARAGRAPH && atend))
						{
							mSpanStarts[i_2] = mGapStart + mGapLength;
						}
						else
						{
							mSpanStarts[i_2] = start;
						}
					}
					if (mSpanEnds[i_2] >= start && mSpanEnds[i_2] < mGapStart + mGapLength)
					{
						int flag = (mSpanFlags[i_2] & END_MASK);
						if (flag == POINT || (flag == PARAGRAPH && atend))
						{
							mSpanEnds[i_2] = mGapStart + mGapLength;
						}
						else
						{
							mSpanEnds[i_2] = start;
						}
					}
					// remove 0-length SPAN_EXCLUSIVE_EXCLUSIVE
					if (mSpanEnds[i_2] < mSpanStarts[i_2])
					{
						removeSpan(i_2);
					}
				}
			}
			if (notify_1)
			{
				sendTextChange(recipients, start, end - start, tbend - tbstart);
				sendTextHasChanged(recipients);
			}
			return ret;
		}

		public void removeSpan(int i)
		{
			object @object = mSpans[i];
			int start = mSpanStarts[i];
			int end = mSpanEnds[i];
			if (start > mGapStart)
			{
				start -= mGapLength;
			}
			if (end > mGapStart)
			{
				end -= mGapLength;
			}
			int count = mSpanCount - (i + 1);
			System.Array.Copy(mSpans, i + 1, mSpans, i, count);
			System.Array.Copy(mSpanStarts, i + 1, mSpanStarts, i, count);
			System.Array.Copy(mSpanEnds, i + 1, mSpanEnds, i, count);
			System.Array.Copy(mSpanFlags, i + 1, mSpanFlags, i, count);
			mSpanCount--;
			mSpans[mSpanCount] = null;
			sendSpanRemoved(@object, start, end);
		}

		[Sharpen.Proxy]
		android.text.Editable android.text.Editable.replace(int start, int end, java.lang.CharSequence
			 tb)
		{
			return replace(start, end, tb);
		}

		// Documentation from interface
		[Sharpen.ImplementsInterface(@"android.text.Editable")]
		public virtual android.text.SpannableStringBuilder replace(int start, int end, java.lang.CharSequence
			 tb)
		{
			return replace(start, end, tb, 0, tb.Length);
		}

		[Sharpen.Proxy]
		android.text.Editable android.text.Editable.replace(int start, int end, java.lang.CharSequence
			 tb, int tbstart, int tbend)
		{
			return replace(start, end, tb, tbstart, tbend);
		}

		// Documentation from interface
		[Sharpen.ImplementsInterface(@"android.text.Editable")]
		public virtual android.text.SpannableStringBuilder replace(int start, int end, java.lang.CharSequence
			 tb, int tbstart, int tbend)
		{
			int filtercount = mFilters.Length;
			{
				for (int i = 0; i < filtercount; i++)
				{
					java.lang.CharSequence repl = mFilters[i].filter(tb, tbstart, tbend, this, start, 
						end);
					if (repl != null)
					{
						tb = repl;
						tbstart = 0;
						tbend = repl.Length;
					}
				}
			}
			if (end == start && tbstart == tbend)
			{
				return this;
			}
			if (end == start || tbstart == tbend)
			{
				change(start, end, tb, tbstart, tbend);
			}
			else
			{
				int selstart = android.text.Selection.getSelectionStart(this);
				int selend = android.text.Selection.getSelectionEnd(this);
				// XXX just make the span fixups in change() do the right thing
				// instead of this madness!
				checkRange("replace", start, end);
				moveGapTo(end);
				android.text.TextWatcher[] recipients;
				int origlen = end - start;
				recipients = sendTextWillChange(start, origlen, tbend - tbstart);
				if (mGapLength < 2)
				{
					resizeFor(Length + 1);
				}
				{
					for (int i_1 = mSpanCount - 1; i_1 >= 0; i_1--)
					{
						if (mSpanStarts[i_1] == mGapStart)
						{
							mSpanStarts[i_1]++;
						}
						if (mSpanEnds[i_1] == mGapStart)
						{
							mSpanEnds[i_1]++;
						}
					}
				}
				mText[mGapStart] = ' ';
				mGapStart++;
				mGapLength--;
				if (mGapLength < 1)
				{
					XobotOS.Runtime.Util.PrintStackTrace(new System.Exception("mGapLength < 1"));
				}
				int inserted = change(false, start + 1, start + 1, tb, tbstart, tbend);
				change(false, start, start + 1, java.lang.CharSequenceProxy.Wrap(string.Empty), 0
					, 0);
				change(false, start + inserted, start + inserted + origlen, java.lang.CharSequenceProxy.Wrap
					(string.Empty), 0, 0);
				if (selstart > start && selstart < end)
				{
					long off = selstart - start;
					off = off * inserted / (end - start);
					selstart = (int)off + start;
					setSpan(false, android.text.Selection.SELECTION_START, selstart, selstart, android.text.SpannedClass.SPAN_POINT_POINT
						);
				}
				if (selend > start && selend < end)
				{
					long off = selend - start;
					off = off * inserted / (end - start);
					selend = (int)off + start;
					setSpan(false, android.text.Selection.SELECTION_END, selend, selend, android.text.SpannedClass.SPAN_POINT_POINT
						);
				}
				sendTextChange(recipients, start, origlen, inserted);
				sendTextHasChanged(recipients);
			}
			return this;
		}

		/// <summary>Mark the specified range of text with the specified object.</summary>
		/// <remarks>
		/// Mark the specified range of text with the specified object.
		/// The flags determine how the span will behave when text is
		/// inserted at the start or end of the span's range.
		/// </remarks>
		[Sharpen.ImplementsInterface(@"android.text.Spannable")]
		public virtual void setSpan(object what, int start, int end, int flags)
		{
			setSpan(true, what, start, end, flags);
		}

		public void setSpan(bool send, object what, int start, int end, int flags)
		{
			int nstart = start;
			int nend = end;
			checkRange("setSpan", start, end);
			if ((flags & START_MASK) == (PARAGRAPH << START_SHIFT))
			{
				if (start != 0 && start != Length)
				{
					char c = this[start - 1];
					if (c != '\n')
					{
						throw new java.lang.RuntimeException("PARAGRAPH span must start at paragraph boundary"
							);
					}
				}
			}
			if ((flags & END_MASK) == PARAGRAPH)
			{
				if (end != 0 && end != Length)
				{
					char c = this[end - 1];
					if (c != '\n')
					{
						throw new java.lang.RuntimeException("PARAGRAPH span must end at paragraph boundary"
							);
					}
				}
			}
			if (start > mGapStart)
			{
				start += mGapLength;
			}
			else
			{
				if (start == mGapStart)
				{
					int flag = (flags & START_MASK) >> START_SHIFT;
					if (flag == POINT || (flag == PARAGRAPH && start == Length))
					{
						start += mGapLength;
					}
				}
			}
			if (end > mGapStart)
			{
				end += mGapLength;
			}
			else
			{
				if (end == mGapStart)
				{
					int flag = (flags & END_MASK);
					if (flag == POINT || (flag == PARAGRAPH && end == Length))
					{
						end += mGapLength;
					}
				}
			}
			int count = mSpanCount;
			object[] spans = mSpans;
			{
				for (int i = 0; i < count; i++)
				{
					if (spans[i] == what)
					{
						int ostart = mSpanStarts[i];
						int oend = mSpanEnds[i];
						if (ostart > mGapStart)
						{
							ostart -= mGapLength;
						}
						if (oend > mGapStart)
						{
							oend -= mGapLength;
						}
						mSpanStarts[i] = start;
						mSpanEnds[i] = end;
						mSpanFlags[i] = flags;
						if (send)
						{
							sendSpanChanged(what, ostart, oend, nstart, nend);
						}
						return;
					}
				}
			}
			if (mSpanCount + 1 >= mSpans.Length)
			{
				int newsize = android.util.@internal.ArrayUtils.idealIntArraySize(mSpanCount + 1);
				object[] newspans = new object[newsize];
				int[] newspanstarts = new int[newsize];
				int[] newspanends = new int[newsize];
				int[] newspanflags = new int[newsize];
				System.Array.Copy(mSpans, 0, newspans, 0, mSpanCount);
				System.Array.Copy(mSpanStarts, 0, newspanstarts, 0, mSpanCount);
				System.Array.Copy(mSpanEnds, 0, newspanends, 0, mSpanCount);
				System.Array.Copy(mSpanFlags, 0, newspanflags, 0, mSpanCount);
				mSpans = newspans;
				mSpanStarts = newspanstarts;
				mSpanEnds = newspanends;
				mSpanFlags = newspanflags;
			}
			mSpans[mSpanCount] = what;
			mSpanStarts[mSpanCount] = start;
			mSpanEnds[mSpanCount] = end;
			mSpanFlags[mSpanCount] = flags;
			mSpanCount++;
			if (send)
			{
				sendSpanAdded(what, nstart, nend);
			}
		}

		/// <summary>Remove the specified markup object from the buffer.</summary>
		/// <remarks>Remove the specified markup object from the buffer.</remarks>
		[Sharpen.ImplementsInterface(@"android.text.Spannable")]
		public virtual void removeSpan(object what)
		{
			{
				for (int i = mSpanCount - 1; i >= 0; i--)
				{
					if (mSpans[i] == what)
					{
						removeSpan(i);
						return;
					}
				}
			}
		}

		/// <summary>
		/// Return the buffer offset of the beginning of the specified
		/// markup object, or -1 if it is not attached to this buffer.
		/// </summary>
		/// <remarks>
		/// Return the buffer offset of the beginning of the specified
		/// markup object, or -1 if it is not attached to this buffer.
		/// </remarks>
		[Sharpen.ImplementsInterface(@"android.text.Spanned")]
		public virtual int getSpanStart(object what)
		{
			int count = mSpanCount;
			object[] spans = mSpans;
			{
				for (int i = count - 1; i >= 0; i--)
				{
					if (spans[i] == what)
					{
						int where = mSpanStarts[i];
						if (where > mGapStart)
						{
							where -= mGapLength;
						}
						return where;
					}
				}
			}
			return -1;
		}

		/// <summary>
		/// Return the buffer offset of the end of the specified
		/// markup object, or -1 if it is not attached to this buffer.
		/// </summary>
		/// <remarks>
		/// Return the buffer offset of the end of the specified
		/// markup object, or -1 if it is not attached to this buffer.
		/// </remarks>
		[Sharpen.ImplementsInterface(@"android.text.Spanned")]
		public virtual int getSpanEnd(object what)
		{
			int count = mSpanCount;
			object[] spans = mSpans;
			{
				for (int i = count - 1; i >= 0; i--)
				{
					if (spans[i] == what)
					{
						int where = mSpanEnds[i];
						if (where > mGapStart)
						{
							where -= mGapLength;
						}
						return where;
					}
				}
			}
			return -1;
		}

		/// <summary>
		/// Return the flags of the end of the specified
		/// markup object, or 0 if it is not attached to this buffer.
		/// </summary>
		/// <remarks>
		/// Return the flags of the end of the specified
		/// markup object, or 0 if it is not attached to this buffer.
		/// </remarks>
		[Sharpen.ImplementsInterface(@"android.text.Spanned")]
		public virtual int getSpanFlags(object what)
		{
			int count = mSpanCount;
			object[] spans = mSpans;
			{
				for (int i = count - 1; i >= 0; i--)
				{
					if (spans[i] == what)
					{
						return mSpanFlags[i];
					}
				}
			}
			return 0;
		}

		// Expensive test, should be performed after the previous tests
		// Safe conversion thanks to the isInstance test above
		// Safe conversion, but requires a suppressWarning
		// Safe conversion thanks to the isInstance test above
		// Safe conversion thanks to the isInstance test above
		// Safe conversion, but requires a suppressWarning
		// Safe conversion, but requires a suppressWarning
		/// <summary>
		/// Return the next offset after <code>start</code> but less than or
		/// equal to <code>limit</code> where a span of the specified type
		/// begins or ends.
		/// </summary>
		/// <remarks>
		/// Return the next offset after <code>start</code> but less than or
		/// equal to <code>limit</code> where a span of the specified type
		/// begins or ends.
		/// </remarks>
		[Sharpen.ImplementsInterface(@"android.text.Spanned")]
		public virtual int nextSpanTransition(int start, int limit, System.Type kind)
		{
			int count = mSpanCount;
			object[] spans = mSpans;
			int[] starts = mSpanStarts;
			int[] ends = mSpanEnds;
			int gapstart = mGapStart;
			int gaplen = mGapLength;
			if (kind == null)
			{
				kind = typeof(object);
			}
			{
				for (int i = 0; i < count; i++)
				{
					int st = starts[i];
					int en = ends[i];
					if (st > gapstart)
					{
						st -= gaplen;
					}
					if (en > gapstart)
					{
						en -= gaplen;
					}
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

		/// <summary>
		/// Return a new CharSequence containing a copy of the specified
		/// range of this buffer, including the overlapping spans.
		/// </summary>
		/// <remarks>
		/// Return a new CharSequence containing a copy of the specified
		/// range of this buffer, including the overlapping spans.
		/// </remarks>
		[Sharpen.ImplementsInterface(@"java.lang.CharSequence")]
		public virtual java.lang.CharSequence SubSequence(int start, int end)
		{
			return new android.text.SpannableStringBuilder(this, start, end);
		}

		/// <summary>
		/// Copy the specified range of chars from this buffer into the
		/// specified array, beginning at the specified offset.
		/// </summary>
		/// <remarks>
		/// Copy the specified range of chars from this buffer into the
		/// specified array, beginning at the specified offset.
		/// </remarks>
		[Sharpen.ImplementsInterface(@"android.text.GetChars")]
		public virtual void getChars(int start, int end, char[] dest, int destoff)
		{
			checkRange("getChars", start, end);
			if (end <= mGapStart)
			{
				System.Array.Copy(mText, start, dest, destoff, end - start);
			}
			else
			{
				if (start >= mGapStart)
				{
					System.Array.Copy(mText, start + mGapLength, dest, destoff, end - start);
				}
				else
				{
					System.Array.Copy(mText, start, dest, destoff, mGapStart - start);
					System.Array.Copy(mText, mGapStart + mGapLength, dest, destoff + (mGapStart - start
						), end - mGapStart);
				}
			}
		}

		/// <summary>Return a String containing a copy of the chars in this buffer.</summary>
		/// <remarks>Return a String containing a copy of the chars in this buffer.</remarks>
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			int len = Length;
			char[] buf = new char[len];
			getChars(0, len, buf, 0);
			return new string(buf);
		}

		private android.text.TextWatcher[] sendTextWillChange(int start, int before, int 
			after)
		{
			android.text.TextWatcher[] recip = getSpans<android.text.TextWatcher>(start, start
				 + before);
			int n = recip.Length;
			{
				for (int i = 0; i < n; i++)
				{
					recip[i].beforeTextChanged(this, start, before, after);
				}
			}
			return recip;
		}

		private void sendTextChange(android.text.TextWatcher[] recip, int start, int before
			, int after)
		{
			int n = recip.Length;
			{
				for (int i = 0; i < n; i++)
				{
					recip[i].onTextChanged(this, start, before, after);
				}
			}
		}

		private void sendTextHasChanged(android.text.TextWatcher[] recip)
		{
			int n = recip.Length;
			{
				for (int i = 0; i < n; i++)
				{
					recip[i].afterTextChanged(this);
				}
			}
		}

		private void sendSpanAdded(object what, int start, int end)
		{
			android.text.SpanWatcher[] recip = getSpans<android.text.SpanWatcher>(start, end);
			int n = recip.Length;
			{
				for (int i = 0; i < n; i++)
				{
					recip[i].onSpanAdded(this, what, start, end);
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
					recip[i].onSpanRemoved(this, what, start, end);
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
					recip[i].onSpanChanged(this, what, s, e, st, en);
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
			int len = Length;
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

		/// <summary>Don't call this yourself -- exists for Canvas to use internally.</summary>
		/// <remarks>
		/// Don't call this yourself -- exists for Canvas to use internally.
		/// <hide></hide>
		/// </remarks>
		[Sharpen.ImplementsInterface(@"android.text.GraphicsOperations")]
		public virtual void drawText(android.graphics.Canvas c, int start, int end, float
			 x, float y, android.graphics.Paint p)
		{
			checkRange("drawText", start, end);
			if (end <= mGapStart)
			{
				c.drawText(mText, start, end - start, x, y, p);
			}
			else
			{
				if (start >= mGapStart)
				{
					c.drawText(mText, start + mGapLength, end - start, x, y, p);
				}
				else
				{
					char[] buf = android.text.TextUtils.obtain(end - start);
					getChars(start, end, buf, 0);
					c.drawText(buf, 0, end - start, x, y, p);
					android.text.TextUtils.recycle(buf);
				}
			}
		}

		/// <summary>Don't call this yourself -- exists for Canvas to use internally.</summary>
		/// <remarks>
		/// Don't call this yourself -- exists for Canvas to use internally.
		/// <hide></hide>
		/// </remarks>
		[Sharpen.ImplementsInterface(@"android.text.GraphicsOperations")]
		public virtual void drawTextRun(android.graphics.Canvas c, int start, int end, int
			 contextStart, int contextEnd, float x, float y, int flags, android.graphics.Paint
			 p)
		{
			checkRange("drawTextRun", start, end);
			int contextLen = contextEnd - contextStart;
			int len = end - start;
			if (contextEnd <= mGapStart)
			{
				c.drawTextRun(mText, start, len, contextStart, contextLen, x, y, flags, p);
			}
			else
			{
				if (contextStart >= mGapStart)
				{
					c.drawTextRun(mText, start + mGapLength, len, contextStart + mGapLength, contextLen
						, x, y, flags, p);
				}
				else
				{
					char[] buf = android.text.TextUtils.obtain(contextLen);
					getChars(contextStart, contextEnd, buf, 0);
					c.drawTextRun(buf, start - contextStart, len, 0, contextLen, x, y, flags, p);
					android.text.TextUtils.recycle(buf);
				}
			}
		}

		/// <summary>Don't call this yourself -- exists for Paint to use internally.</summary>
		/// <remarks>
		/// Don't call this yourself -- exists for Paint to use internally.
		/// <hide></hide>
		/// </remarks>
		[Sharpen.ImplementsInterface(@"android.text.GraphicsOperations")]
		public virtual float measureText(int start, int end, android.graphics.Paint p)
		{
			checkRange("measureText", start, end);
			float ret;
			if (end <= mGapStart)
			{
				ret = p.measureText(mText, start, end - start);
			}
			else
			{
				if (start >= mGapStart)
				{
					ret = p.measureText(mText, start + mGapLength, end - start);
				}
				else
				{
					char[] buf = android.text.TextUtils.obtain(end - start);
					getChars(start, end, buf, 0);
					ret = p.measureText(buf, 0, end - start);
					android.text.TextUtils.recycle(buf);
				}
			}
			return ret;
		}

		/// <summary>Don't call this yourself -- exists for Paint to use internally.</summary>
		/// <remarks>
		/// Don't call this yourself -- exists for Paint to use internally.
		/// <hide></hide>
		/// </remarks>
		[Sharpen.ImplementsInterface(@"android.text.GraphicsOperations")]
		public virtual int getTextWidths(int start, int end, float[] widths, android.graphics.Paint
			 p)
		{
			checkRange("getTextWidths", start, end);
			int ret;
			if (end <= mGapStart)
			{
				ret = p.getTextWidths(mText, start, end - start, widths);
			}
			else
			{
				if (start >= mGapStart)
				{
					ret = p.getTextWidths(mText, start + mGapLength, end - start, widths);
				}
				else
				{
					char[] buf = android.text.TextUtils.obtain(end - start);
					getChars(start, end, buf, 0);
					ret = p.getTextWidths(buf, 0, end - start, widths);
					android.text.TextUtils.recycle(buf);
				}
			}
			return ret;
		}

		/// <summary>Don't call this yourself -- exists for Paint to use internally.</summary>
		/// <remarks>
		/// Don't call this yourself -- exists for Paint to use internally.
		/// <hide></hide>
		/// </remarks>
		[Sharpen.ImplementsInterface(@"android.text.GraphicsOperations")]
		public virtual float getTextRunAdvances(int start, int end, int contextStart, int
			 contextEnd, int flags, float[] advances, int advancesPos, android.graphics.Paint
			 p)
		{
			float ret;
			int contextLen = contextEnd - contextStart;
			int len = end - start;
			if (end <= mGapStart)
			{
				ret = p.getTextRunAdvances(mText, start, len, contextStart, contextLen, flags, advances
					, advancesPos);
			}
			else
			{
				if (start >= mGapStart)
				{
					ret = p.getTextRunAdvances(mText, start + mGapLength, len, contextStart + mGapLength
						, contextLen, flags, advances, advancesPos);
				}
				else
				{
					char[] buf = android.text.TextUtils.obtain(contextLen);
					getChars(contextStart, contextEnd, buf, 0);
					ret = p.getTextRunAdvances(buf, start - contextStart, len, 0, contextLen, flags, 
						advances, advancesPos);
					android.text.TextUtils.recycle(buf);
				}
			}
			return ret;
		}

		/// <summary>Don't call this yourself -- exists for Paint to use internally.</summary>
		/// <remarks>
		/// Don't call this yourself -- exists for Paint to use internally.
		/// <hide></hide>
		/// </remarks>
		[Sharpen.ImplementsInterface(@"android.text.GraphicsOperations")]
		public virtual float getTextRunAdvances(int start, int end, int contextStart, int
			 contextEnd, int flags, float[] advances, int advancesPos, android.graphics.Paint
			 p, int reserved)
		{
			float ret;
			int contextLen = contextEnd - contextStart;
			int len = end - start;
			if (end <= mGapStart)
			{
				ret = p.getTextRunAdvances(mText, start, len, contextStart, contextLen, flags, advances
					, advancesPos, reserved);
			}
			else
			{
				if (start >= mGapStart)
				{
					ret = p.getTextRunAdvances(mText, start + mGapLength, len, contextStart + mGapLength
						, contextLen, flags, advances, advancesPos, reserved);
				}
				else
				{
					char[] buf = android.text.TextUtils.obtain(contextLen);
					getChars(contextStart, contextEnd, buf, 0);
					ret = p.getTextRunAdvances(buf, start - contextStart, len, 0, contextLen, flags, 
						advances, advancesPos, reserved);
					android.text.TextUtils.recycle(buf);
				}
			}
			return ret;
		}

		/// <summary>Returns the next cursor position in the run.</summary>
		/// <remarks>
		/// Returns the next cursor position in the run.  This avoids placing the cursor between
		/// surrogates, between characters that form conjuncts, between base characters and combining
		/// marks, or within a reordering cluster.
		/// <p>The context is the shaping context for cursor movement, generally the bounds of the metric
		/// span enclosing the cursor in the direction of movement.
		/// <code>contextStart</code>, <code>contextEnd</code> and <code>offset</code> are relative to
		/// the start of the string.</p>
		/// <p>If cursorOpt is CURSOR_AT and the offset is not a valid cursor position,
		/// this returns -1.  Otherwise this will never return a value before contextStart or after
		/// contextEnd.</p>
		/// </remarks>
		/// <param name="contextStart">the start index of the context</param>
		/// <param name="contextEnd">the (non-inclusive) end index of the context</param>
		/// <param name="flags">either DIRECTION_RTL or DIRECTION_LTR</param>
		/// <param name="offset">the cursor position to move from</param>
		/// <param name="cursorOpt">
		/// how to move the cursor, one of CURSOR_AFTER,
		/// CURSOR_AT_OR_AFTER, CURSOR_BEFORE,
		/// CURSOR_AT_OR_BEFORE, or CURSOR_AT
		/// </param>
		/// <param name="p">the Paint object that is requesting this information</param>
		/// <returns>the offset of the next position, or -1</returns>
		[System.ObsoleteAttribute(@"This is an internal method, refrain from using it in your code"
			)]
		[Sharpen.ImplementsInterface(@"android.text.GraphicsOperations")]
		public virtual int getTextRunCursor(int contextStart, int contextEnd, int flags, 
			int offset, int cursorOpt, android.graphics.Paint p)
		{
			int ret;
			int contextLen = contextEnd - contextStart;
			if (contextEnd <= mGapStart)
			{
				ret = p.getTextRunCursor(mText, contextStart, contextLen, flags, offset, cursorOpt
					);
			}
			else
			{
				if (contextStart >= mGapStart)
				{
					ret = p.getTextRunCursor(mText, contextStart + mGapLength, contextLen, flags, offset
						 + mGapLength, cursorOpt) - mGapLength;
				}
				else
				{
					char[] buf = android.text.TextUtils.obtain(contextLen);
					getChars(contextStart, contextEnd, buf, 0);
					ret = p.getTextRunCursor(buf, 0, contextLen, flags, offset - contextStart, cursorOpt
						) + contextStart;
					android.text.TextUtils.recycle(buf);
				}
			}
			return ret;
		}

		// Documentation from interface
		[Sharpen.ImplementsInterface(@"android.text.Editable")]
		public virtual void setFilters(android.text.InputFilter[] filters)
		{
			if (filters == null)
			{
				throw new System.ArgumentException();
			}
			mFilters = filters;
		}

		// Documentation from interface
		[Sharpen.ImplementsInterface(@"android.text.Editable")]
		public virtual android.text.InputFilter[] getFilters()
		{
			return mFilters;
		}

		private static readonly android.text.InputFilter[] NO_FILTERS = new android.text.InputFilter
			[0];

		private android.text.InputFilter[] mFilters = NO_FILTERS;

		private char[] mText;

		private int mGapStart;

		private int mGapLength;

		private object[] mSpans;

		private int[] mSpanStarts;

		private int[] mSpanEnds;

		private int[] mSpanFlags;

		private int mSpanCount;

		internal const int POINT = 2;

		internal const int PARAGRAPH = 3;

		internal const int START_MASK = unchecked((int)(0xF0));

		internal const int END_MASK = unchecked((int)(0x0F));

		internal const int START_SHIFT = 4;
	}
}

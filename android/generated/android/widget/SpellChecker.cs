using Sharpen;

namespace android.widget
{
	/// <summary>Helper class for TextView.</summary>
	/// <remarks>Helper class for TextView. Bridge between the TextView and the Dictionnary service.
	/// 	</remarks>
	/// <hide></hide>
	[Sharpen.Sharpened]
	public class SpellChecker : android.view.textservice.SpellCheckerSession.SpellCheckerSessionListener
	{
		internal const int MAX_SPELL_BATCH_SIZE = 50;

		private readonly android.widget.TextView mTextView;

		internal readonly android.view.textservice.SpellCheckerSession mSpellCheckerSession;

		internal readonly int mCookie;

		private int[] mIds;

		private android.text.style.SpellCheckSpan[] mSpellCheckSpans;

		private int mLength;

		private android.widget.SpellChecker.SpellParser[] mSpellParsers = new android.widget.SpellChecker
			.SpellParser[0];

		private int mSpanSequenceCounter = 0;

		public SpellChecker(android.widget.TextView textView)
		{
			// Paired arrays for the (id, spellCheckSpan) pair. A negative id means the associated
			// SpellCheckSpan has been recycled and can be-reused.
			// Contains null SpellCheckSpans after index mLength.
			// The mLength first elements of the above arrays have been initialized
			// Parsers on chunck of text, cutting text into words that will be checked
			mTextView = textView;
			android.view.textservice.TextServicesManager textServicesManager = (android.view.textservice.TextServicesManager
				)textView.getContext().getSystemService(android.content.Context.TEXT_SERVICES_MANAGER_SERVICE
				);
			mSpellCheckerSession = textServicesManager.newSpellCheckerSession(null, null, this
				, true);
			mCookie = GetHashCode();
			// Arbitrary: 4 simultaneous spell check spans. Will automatically double size on demand
			int size = android.util.@internal.ArrayUtils.idealObjectArraySize(1);
			mIds = new int[size];
			mSpellCheckSpans = new android.text.style.SpellCheckSpan[size];
			mLength = 0;
		}

		/// <returns>
		/// true if a spell checker session has successfully been created. Returns false if not,
		/// for instance when spell checking has been disabled in settings.
		/// </returns>
		private bool isSessionActive()
		{
			return mSpellCheckerSession != null;
		}

		public virtual void closeSession()
		{
			if (mSpellCheckerSession != null)
			{
				mSpellCheckerSession.close();
			}
			int length = mSpellParsers.Length;
			{
				for (int i = 0; i < length; i++)
				{
					mSpellParsers[i].close();
				}
			}
		}

		private int nextSpellCheckSpanIndex()
		{
			{
				for (int i = 0; i < mLength; i++)
				{
					if (mIds[i] < 0)
					{
						return i;
					}
				}
			}
			if (mLength == mSpellCheckSpans.Length)
			{
				int newSize = mLength * 2;
				int[] newIds = new int[newSize];
				android.text.style.SpellCheckSpan[] newSpellCheckSpans = new android.text.style.SpellCheckSpan
					[newSize];
				System.Array.Copy(mIds, 0, newIds, 0, mLength);
				System.Array.Copy(mSpellCheckSpans, 0, newSpellCheckSpans, 0, mLength);
				mIds = newIds;
				mSpellCheckSpans = newSpellCheckSpans;
			}
			mSpellCheckSpans[mLength] = new android.text.style.SpellCheckSpan();
			mLength++;
			return mLength - 1;
		}

		private void addSpellCheckSpan(android.text.Editable editable, int start, int end
			)
		{
			int index = nextSpellCheckSpanIndex();
			editable.setSpan(mSpellCheckSpans[index], start, end, android.text.SpannedClass.SPAN_EXCLUSIVE_EXCLUSIVE
				);
			mIds[index] = mSpanSequenceCounter++;
		}

		public virtual void removeSpellCheckSpan(android.text.style.SpellCheckSpan spellCheckSpan
			)
		{
			{
				for (int i = 0; i < mLength; i++)
				{
					if (mSpellCheckSpans[i] == spellCheckSpan)
					{
						mSpellCheckSpans[i].setSpellCheckInProgress(false);
						mIds[i] = -1;
						return;
					}
				}
			}
		}

		public virtual void onSelectionChanged()
		{
			spellCheck();
		}

		public virtual void spellCheck(int start, int end)
		{
			if (!isSessionActive())
			{
				return;
			}
			int length = mSpellParsers.Length;
			{
				for (int i = 0; i < length; i++)
				{
					android.widget.SpellChecker.SpellParser spellParser = mSpellParsers[i];
					if (spellParser.isDone())
					{
						spellParser.init(start, end);
						spellParser.parse();
						return;
					}
				}
			}
			// No available parser found in pool, create a new one
			android.widget.SpellChecker.SpellParser[] newSpellParsers = new android.widget.SpellChecker
				.SpellParser[length + 1];
			System.Array.Copy(mSpellParsers, 0, newSpellParsers, 0, length);
			mSpellParsers = newSpellParsers;
			android.widget.SpellChecker.SpellParser spellParser_1 = new android.widget.SpellChecker
				.SpellParser(this);
			mSpellParsers[length] = spellParser_1;
			spellParser_1.init(start, end);
			spellParser_1.parse();
		}

		private void spellCheck()
		{
			if (mSpellCheckerSession == null)
			{
				return;
			}
			android.text.Editable editable = (android.text.Editable)mTextView.getText();
			int selectionStart = android.text.Selection.getSelectionStart(editable);
			int selectionEnd = android.text.Selection.getSelectionEnd(editable);
			android.view.textservice.TextInfo[] textInfos = new android.view.textservice.TextInfo
				[mLength];
			int textInfosCount = 0;
			{
				for (int i = 0; i < mLength; i++)
				{
					android.text.style.SpellCheckSpan spellCheckSpan = mSpellCheckSpans[i];
					if (spellCheckSpan.isSpellCheckInProgress())
					{
						continue;
					}
					int start = editable.getSpanStart(spellCheckSpan);
					int end = editable.getSpanEnd(spellCheckSpan);
					// Do not check this word if the user is currently editing it
					if (start >= 0 && end > start && (selectionEnd < start || selectionStart > end))
					{
						string word = editable.SubSequence(start, end).ToString();
						spellCheckSpan.setSpellCheckInProgress(true);
						textInfos[textInfosCount++] = new android.view.textservice.TextInfo(word, mCookie
							, mIds[i]);
					}
				}
			}
			if (textInfosCount > 0)
			{
				if (textInfosCount < textInfos.Length)
				{
					android.view.textservice.TextInfo[] textInfosCopy = new android.view.textservice.TextInfo
						[textInfosCount];
					System.Array.Copy(textInfos, 0, textInfosCopy, 0, textInfosCount);
					textInfos = textInfosCopy;
				}
				mSpellCheckerSession.getSuggestions(textInfos, android.text.style.SuggestionSpan.
					SUGGESTIONS_MAX_SIZE, false);
			}
		}

		[Sharpen.ImplementsInterface(@"android.view.textservice.SpellCheckerSession.SpellCheckerSessionListener"
			)]
		public virtual void onGetSuggestions(android.view.textservice.SuggestionsInfo[] results
			)
		{
			android.text.Editable editable = (android.text.Editable)mTextView.getText();
			{
				for (int i = 0; i < results.Length; i++)
				{
					android.view.textservice.SuggestionsInfo suggestionsInfo = results[i];
					if (suggestionsInfo.getCookie() != mCookie)
					{
						continue;
					}
					int sequenceNumber = suggestionsInfo.getSequence();
					{
						for (int j = 0; j < mLength; j++)
						{
							if (sequenceNumber == mIds[j])
							{
								int attributes = suggestionsInfo.getSuggestionsAttributes();
								bool isInDictionary = ((attributes & android.view.textservice.SuggestionsInfo.RESULT_ATTR_IN_THE_DICTIONARY
									) > 0);
								bool looksLikeTypo = ((attributes & android.view.textservice.SuggestionsInfo.RESULT_ATTR_LOOKS_LIKE_TYPO
									) > 0);
								android.text.style.SpellCheckSpan spellCheckSpan = mSpellCheckSpans[j];
								if (!isInDictionary && looksLikeTypo)
								{
									createMisspelledSuggestionSpan(editable, suggestionsInfo, spellCheckSpan);
								}
								editable.removeSpan(spellCheckSpan);
								break;
							}
						}
					}
				}
			}
			int length = mSpellParsers.Length;
			{
				for (int i_1 = 0; i_1 < length; i_1++)
				{
					android.widget.SpellChecker.SpellParser spellParser = mSpellParsers[i_1];
					if (!spellParser.isDone())
					{
						spellParser.parse();
					}
				}
			}
		}

		private void createMisspelledSuggestionSpan(android.text.Editable editable, android.view.textservice.SuggestionsInfo
			 suggestionsInfo, android.text.style.SpellCheckSpan spellCheckSpan)
		{
			int start = editable.getSpanStart(spellCheckSpan);
			int end = editable.getSpanEnd(spellCheckSpan);
			// Other suggestion spans may exist on that region, with identical suggestions, filter
			// them out to avoid duplicates. First, filter suggestion spans on that exact region.
			android.text.style.SuggestionSpan[] suggestionSpans = editable.getSpans<android.text.style.SuggestionSpan
				>(start, end);
			int length = suggestionSpans.Length;
			{
				for (int i = 0; i < length; i++)
				{
					int spanStart = editable.getSpanStart(suggestionSpans[i]);
					int spanEnd = editable.getSpanEnd(suggestionSpans[i]);
					if (spanStart != start || spanEnd != end)
					{
						suggestionSpans[i] = null;
						break;
					}
				}
			}
			int suggestionsCount = suggestionsInfo.getSuggestionsCount();
			string[] suggestions;
			if (suggestionsCount <= 0)
			{
				// A negative suggestion count is possible
				suggestions = new string[0];
			}
			else
			{
				int numberOfSuggestions = 0;
				suggestions = new string[suggestionsCount];
				{
					for (int i_1 = 0; i_1 < suggestionsCount; i_1++)
					{
						string spellSuggestion = suggestionsInfo.getSuggestionAt(i_1);
						if (spellSuggestion == null)
						{
							break;
						}
						bool suggestionFound = false;
						{
							for (int j = 0; j < length && !suggestionFound; j++)
							{
								if (suggestionSpans[j] == null)
								{
									break;
								}
								string[] suggests = suggestionSpans[j].getSuggestions();
								{
									for (int k = 0; k < suggests.Length; k++)
									{
										if (spellSuggestion.Equals(suggests[k]))
										{
											// The suggestion is already provided by an other SuggestionSpan
											suggestionFound = true;
											break;
										}
									}
								}
							}
						}
						if (!suggestionFound)
						{
							suggestions[numberOfSuggestions++] = spellSuggestion;
						}
					}
				}
				if (numberOfSuggestions != suggestionsCount)
				{
					string[] newSuggestions = new string[numberOfSuggestions];
					System.Array.Copy(suggestions, 0, newSuggestions, 0, numberOfSuggestions);
					suggestions = newSuggestions;
				}
			}
			android.text.style.SuggestionSpan suggestionSpan = new android.text.style.SuggestionSpan
				(mTextView.getContext(), suggestions, android.text.style.SuggestionSpan.FLAG_EASY_CORRECT
				 | android.text.style.SuggestionSpan.FLAG_MISSPELLED);
			editable.setSpan(suggestionSpan, start, end, android.text.SpannedClass.SPAN_EXCLUSIVE_EXCLUSIVE
				);
			// TODO limit to the word rectangle region
			mTextView.invalidate();
		}

		private class SpellParser
		{
			internal android.text.method.WordIterator mWordIterator;

			internal object mRange;

			public virtual void init(int start, int end)
			{
				((android.text.Editable)this._enclosing.mTextView.getText()).setSpan(this.mRange, 
					start, end, android.text.SpannedClass.SPAN_EXCLUSIVE_EXCLUSIVE);
			}

			public virtual void close()
			{
				((android.text.Editable)this._enclosing.mTextView.getText()).removeSpan(this.mRange
					);
			}

			public virtual bool isDone()
			{
				return ((android.text.Editable)this._enclosing.mTextView.getText()).getSpanStart(
					this.mRange) < 0;
			}

			public virtual void parse()
			{
				android.text.Editable editable = (android.text.Editable)this._enclosing.mTextView
					.getText();
				// Iterate over the newly added text and schedule new SpellCheckSpans
				int start = editable.getSpanStart(this.mRange);
				int end = editable.getSpanEnd(this.mRange);
				this.mWordIterator.setCharSequence(editable, start, end);
				// Move back to the beginning of the current word, if any
				int wordStart = this.mWordIterator.preceding(start);
				int wordEnd;
				if (wordStart == java.text.BreakIterator.DONE)
				{
					wordEnd = this.mWordIterator.following(start);
					if (wordEnd != java.text.BreakIterator.DONE)
					{
						wordStart = this.mWordIterator.getBeginning(wordEnd);
					}
				}
				else
				{
					wordEnd = this.mWordIterator.getEnd(wordStart);
				}
				if (wordEnd == java.text.BreakIterator.DONE)
				{
					editable.removeSpan(this.mRange);
					return;
				}
				// We need to expand by one character because we want to include the spans that
				// end/start at position start/end respectively.
				android.text.style.SpellCheckSpan[] spellCheckSpans = editable.getSpans<android.text.style.SpellCheckSpan
					>(start - 1, end + 1);
				android.text.style.SuggestionSpan[] suggestionSpans = editable.getSpans<android.text.style.SuggestionSpan
					>(start - 1, end + 1);
				int nbWordsChecked = 0;
				bool scheduleOtherSpellCheck = false;
				while (wordStart <= end)
				{
					if (wordEnd >= start && wordEnd > wordStart)
					{
						// A new word has been created across the interval boundaries with this edit.
						// Previous spans (ended on start / started on end) removed, not valid anymore
						if (wordStart < start && wordEnd > start)
						{
							this.removeSpansAt(editable, start, spellCheckSpans);
							this.removeSpansAt(editable, start, suggestionSpans);
						}
						if (wordStart < end && wordEnd > end)
						{
							this.removeSpansAt(editable, end, spellCheckSpans);
							this.removeSpansAt(editable, end, suggestionSpans);
						}
						// Do not create new boundary spans if they already exist
						bool createSpellCheckSpan = true;
						if (wordEnd == start)
						{
							{
								for (int i = 0; i < spellCheckSpans.Length; i++)
								{
									int spanEnd = editable.getSpanEnd(spellCheckSpans[i]);
									if (spanEnd == start)
									{
										createSpellCheckSpan = false;
										break;
									}
								}
							}
						}
						if (wordStart == end)
						{
							{
								for (int i = 0; i < spellCheckSpans.Length; i++)
								{
									int spanStart = editable.getSpanStart(spellCheckSpans[i]);
									if (spanStart == end)
									{
										createSpellCheckSpan = false;
										break;
									}
								}
							}
						}
						if (createSpellCheckSpan)
						{
							if (nbWordsChecked == android.widget.SpellChecker.MAX_SPELL_BATCH_SIZE)
							{
								scheduleOtherSpellCheck = true;
								break;
							}
							this._enclosing.addSpellCheckSpan(editable, wordStart, wordEnd);
							nbWordsChecked++;
						}
					}
					// iterate word by word
					wordEnd = this.mWordIterator.following(wordEnd);
					if (wordEnd == java.text.BreakIterator.DONE)
					{
						break;
					}
					wordStart = this.mWordIterator.getBeginning(wordEnd);
					if (wordStart == java.text.BreakIterator.DONE)
					{
						break;
					}
				}
				if (scheduleOtherSpellCheck)
				{
					editable.setSpan(this.mRange, wordStart, end, android.text.SpannedClass.SPAN_EXCLUSIVE_EXCLUSIVE
						);
				}
				else
				{
					editable.removeSpan(this.mRange);
				}
				this._enclosing.spellCheck();
			}

			internal void removeSpansAt<T>(android.text.Editable editable, int offset, T[] spans
				)
			{
				int length = spans.Length;
				{
					for (int i = 0; i < length; i++)
					{
						T span = spans[i];
						int start = editable.getSpanStart(span);
						if (start > offset)
						{
							continue;
						}
						int end = editable.getSpanEnd(span);
						if (end < offset)
						{
							continue;
						}
						editable.removeSpan(span);
					}
				}
			}

			public SpellParser(SpellChecker _enclosing)
			{
				this._enclosing = _enclosing;
				mWordIterator = new android.text.method.WordIterator();
				mRange = new object();
			}

			private readonly SpellChecker _enclosing;
		}
	}
}

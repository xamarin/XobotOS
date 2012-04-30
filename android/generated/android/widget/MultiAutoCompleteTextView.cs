using Sharpen;

namespace android.widget
{
	/// <summary>
	/// An editable text view, extending
	/// <see cref="AutoCompleteTextView">AutoCompleteTextView</see>
	/// , that
	/// can show completion suggestions for the substring of the text where
	/// the user is typing instead of necessarily for the entire thing.
	/// <p>
	/// You must provide a
	/// <see cref="Tokenizer">Tokenizer</see>
	/// to distinguish the
	/// various substrings.
	/// <p>The following code snippet shows how to create a text view which suggests
	/// various countries names while the user is typing:</p>
	/// <pre class="prettyprint">
	/// public class CountriesActivity extends Activity {
	/// protected void onCreate(Bundle savedInstanceState) {
	/// super.onCreate(savedInstanceState);
	/// setContentView(R.layout.autocomplete_7);
	/// ArrayAdapter&lt;String&gt; adapter = new ArrayAdapter&lt;String&gt;(this,
	/// android.R.layout.simple_dropdown_item_1line, COUNTRIES);
	/// MultiAutoCompleteTextView textView = (MultiAutoCompleteTextView) findViewById(R.id.edit);
	/// textView.setAdapter(adapter);
	/// textView.setTokenizer(new MultiAutoCompleteTextView.CommaTokenizer());
	/// }
	/// private static final String[] COUNTRIES = new String[] {
	/// "Belgium", "France", "Italy", "Germany", "Spain"
	/// };
	/// }</pre>
	/// </summary>
	[Sharpen.Sharpened]
	public class MultiAutoCompleteTextView : android.widget.AutoCompleteTextView
	{
		private android.widget.MultiAutoCompleteTextView.Tokenizer mTokenizer;

		public MultiAutoCompleteTextView(android.content.Context context) : this(context, 
			null)
		{
		}

		public MultiAutoCompleteTextView(android.content.Context context, android.util.AttributeSet
			 attrs) : this(context, attrs, android.@internal.R.attr.autoCompleteTextViewStyle
			)
		{
		}

		public MultiAutoCompleteTextView(android.content.Context context, android.util.AttributeSet
			 attrs, int defStyle) : base(context, attrs, defStyle)
		{
		}

		internal virtual void finishInit()
		{
		}

		/// <summary>
		/// Sets the Tokenizer that will be used to determine the relevant
		/// range of the text where the user is typing.
		/// </summary>
		/// <remarks>
		/// Sets the Tokenizer that will be used to determine the relevant
		/// range of the text where the user is typing.
		/// </remarks>
		public virtual void setTokenizer(android.widget.MultiAutoCompleteTextView.Tokenizer
			 t)
		{
			mTokenizer = t;
		}

		/// <summary>
		/// Instead of filtering on the entire contents of the edit box,
		/// this subclass method filters on the range from
		/// <see cref="Tokenizer.findTokenStart(java.lang.CharSequence, int)">Tokenizer.findTokenStart(java.lang.CharSequence, int)
		/// 	</see>
		/// to
		/// <see cref="TextView.getSelectionEnd()">TextView.getSelectionEnd()</see>
		/// if the length of that range meets or exceeds
		/// <see cref="AutoCompleteTextView.getThreshold()">AutoCompleteTextView.getThreshold()
		/// 	</see>
		/// .
		/// </summary>
		[Sharpen.OverridesMethod(@"android.widget.AutoCompleteTextView")]
		protected internal override void performFiltering(java.lang.CharSequence text, int
			 keyCode)
		{
			if (enoughToFilter())
			{
				int end = getSelectionEnd();
				int start = mTokenizer.findTokenStart(text, end);
				performFiltering(text, start, end, keyCode);
			}
			else
			{
				dismissDropDown();
				android.widget.Filter f = getFilter();
				if (f != null)
				{
					f.filter(null);
				}
			}
		}

		/// <summary>
		/// Instead of filtering whenever the total length of the text
		/// exceeds the threshhold, this subclass filters only when the
		/// length of the range from
		/// <see cref="Tokenizer.findTokenStart(java.lang.CharSequence, int)">Tokenizer.findTokenStart(java.lang.CharSequence, int)
		/// 	</see>
		/// to
		/// <see cref="TextView.getSelectionEnd()">TextView.getSelectionEnd()</see>
		/// meets or exceeds
		/// <see cref="AutoCompleteTextView.getThreshold()">AutoCompleteTextView.getThreshold()
		/// 	</see>
		/// .
		/// </summary>
		[Sharpen.OverridesMethod(@"android.widget.AutoCompleteTextView")]
		public override bool enoughToFilter()
		{
			android.text.Editable text = ((android.text.Editable)getText());
			int end = getSelectionEnd();
			if (end < 0 || mTokenizer == null)
			{
				return false;
			}
			int start = mTokenizer.findTokenStart(text, end);
			if (end - start >= getThreshold())
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// Instead of validating the entire text, this subclass method validates
		/// each token of the text individually.
		/// </summary>
		/// <remarks>
		/// Instead of validating the entire text, this subclass method validates
		/// each token of the text individually.  Empty tokens are removed.
		/// </remarks>
		[Sharpen.OverridesMethod(@"android.widget.AutoCompleteTextView")]
		public override void performValidation()
		{
			android.widget.AutoCompleteTextView.Validator v = getValidator();
			if (v == null || mTokenizer == null)
			{
				return;
			}
			android.text.Editable e = ((android.text.Editable)getText());
			int i = ((android.text.Editable)getText()).Length;
			while (i > 0)
			{
				int start = mTokenizer.findTokenStart(e, i);
				int end = mTokenizer.findTokenEnd(e, start);
				java.lang.CharSequence sub = e.SubSequence(start, end);
				if (android.text.TextUtils.isEmpty(sub))
				{
					e.replace(start, i, java.lang.CharSequenceProxy.Wrap(string.Empty));
				}
				else
				{
					if (!v.isValid(sub))
					{
						e.replace(start, i, mTokenizer.terminateToken(v.fixText(sub)));
					}
				}
				i = start;
			}
		}

		/// <summary><p>Starts filtering the content of the drop down list.</summary>
		/// <remarks>
		/// <p>Starts filtering the content of the drop down list. The filtering
		/// pattern is the specified range of text from the edit box. Subclasses may
		/// override this method to filter with a different pattern, for
		/// instance a smaller substring of <code>text</code>.</p>
		/// </remarks>
		protected internal virtual void performFiltering(java.lang.CharSequence text, int
			 start, int end, int keyCode)
		{
			getFilter().filter(text.SubSequence(start, end), this);
		}

		/// <summary>
		/// <p>Performs the text completion by replacing the range from
		/// <see cref="Tokenizer.findTokenStart(java.lang.CharSequence, int)">Tokenizer.findTokenStart(java.lang.CharSequence, int)
		/// 	</see>
		/// to
		/// <see cref="TextView.getSelectionEnd()">TextView.getSelectionEnd()</see>
		/// by the
		/// the result of passing <code>text</code> through
		/// <see cref="Tokenizer.terminateToken(java.lang.CharSequence)">Tokenizer.terminateToken(java.lang.CharSequence)
		/// 	</see>
		/// .
		/// In addition, the replaced region will be marked as an AutoText
		/// substition so that if the user immediately presses DEL, the
		/// completion will be undone.
		/// Subclasses may override this method to do some different
		/// insertion of the content into the edit box.</p>
		/// </summary>
		/// <param name="text">the selected suggestion in the drop down list</param>
		[Sharpen.OverridesMethod(@"android.widget.AutoCompleteTextView")]
		protected internal override void replaceText(java.lang.CharSequence text)
		{
			clearComposingText();
			int end = getSelectionEnd();
			int start = mTokenizer.findTokenStart(((android.text.Editable)getText()), end);
			android.text.Editable editable = ((android.text.Editable)getText());
			string original = android.text.TextUtils.substring(editable, start, end);
			android.text.method.QwertyKeyListener.markAsReplaced(editable, start, end, original
				);
			editable.replace(start, end, mTokenizer.terminateToken(text));
		}

		public interface Tokenizer
		{
			/// <summary>
			/// Returns the start of the token that ends at offset
			/// <code>cursor</code> within <code>text</code>.
			/// </summary>
			/// <remarks>
			/// Returns the start of the token that ends at offset
			/// <code>cursor</code> within <code>text</code>.
			/// </remarks>
			int findTokenStart(java.lang.CharSequence text, int cursor);

			/// <summary>
			/// Returns the end of the token (minus trailing punctuation)
			/// that begins at offset <code>cursor</code> within <code>text</code>.
			/// </summary>
			/// <remarks>
			/// Returns the end of the token (minus trailing punctuation)
			/// that begins at offset <code>cursor</code> within <code>text</code>.
			/// </remarks>
			int findTokenEnd(java.lang.CharSequence text, int cursor);

			/// <summary>
			/// Returns <code>text</code>, modified, if necessary, to ensure that
			/// it ends with a token terminator (for example a space or comma).
			/// </summary>
			/// <remarks>
			/// Returns <code>text</code>, modified, if necessary, to ensure that
			/// it ends with a token terminator (for example a space or comma).
			/// </remarks>
			java.lang.CharSequence terminateToken(java.lang.CharSequence text);
		}

		/// <summary>
		/// This simple Tokenizer can be used for lists where the items are
		/// separated by a comma and one or more spaces.
		/// </summary>
		/// <remarks>
		/// This simple Tokenizer can be used for lists where the items are
		/// separated by a comma and one or more spaces.
		/// </remarks>
		public class CommaTokenizer : android.widget.MultiAutoCompleteTextView.Tokenizer
		{
			[Sharpen.ImplementsInterface(@"android.widget.MultiAutoCompleteTextView.Tokenizer"
				)]
			public virtual int findTokenStart(java.lang.CharSequence text, int cursor)
			{
				int i = cursor;
				while (i > 0 && text[i - 1] != ',')
				{
					i--;
				}
				while (i < cursor && text[i] == ' ')
				{
					i++;
				}
				return i;
			}

			[Sharpen.ImplementsInterface(@"android.widget.MultiAutoCompleteTextView.Tokenizer"
				)]
			public virtual int findTokenEnd(java.lang.CharSequence text, int cursor)
			{
				int i = cursor;
				int len = text.Length;
				while (i < len)
				{
					if (text[i] == ',')
					{
						return i;
					}
					else
					{
						i++;
					}
				}
				return len;
			}

			[Sharpen.ImplementsInterface(@"android.widget.MultiAutoCompleteTextView.Tokenizer"
				)]
			public virtual java.lang.CharSequence terminateToken(java.lang.CharSequence text)
			{
				int i = text.Length;
				while (i > 0 && text[i - 1] == ' ')
				{
					i--;
				}
				if (i > 0 && text[i - 1] == ',')
				{
					return text;
				}
				else
				{
					if (text is android.text.Spanned)
					{
						android.text.SpannableString sp = new android.text.SpannableString(java.lang.CharSequenceProxy.Wrap
							(text + ", "));
						android.text.TextUtils.copySpansFrom((android.text.Spanned)text, 0, text.Length, 
							typeof(object), sp, 0);
						return sp;
					}
					else
					{
						return java.lang.CharSequenceProxy.Wrap(text + ", ");
					}
				}
			}
		}
	}
}

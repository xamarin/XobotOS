using Sharpen;

namespace android.text
{
	/// <summary>
	/// Bit definitions for an integer defining the basic content type of text
	/// held in an
	/// <see cref="Editable">Editable</see>
	/// object. Supported classes may be combined
	/// with variations and flags to indicate desired behaviors.
	/// <h3>Examples</h3>
	/// <dl>
	/// <dt>A password field with with the password visible to the user:
	/// <dd>inputType = TYPE_CLASS_TEXT |
	/// TYPE_TEXT_VARIATION_VISIBLE_PASSWORD
	/// <dt>A multi-line postal address with automatic capitalization:
	/// <dd>inputType = TYPE_CLASS_TEXT |
	/// TYPE_TEXT_VARIATION_POSTAL_ADDRESS |
	/// TYPE_TEXT_FLAG_MULTI_LINE
	/// <dt>A time field:
	/// <dd>inputType = TYPE_CLASS_DATETIME |
	/// TYPE_DATETIME_VARIATION_TIME
	/// </dl>
	/// </summary>
	[Sharpen.Sharpened]
	public interface InputType
	{
		// ----------------------------------------------------------------------
		// ----------------------------------------------------------------------
		// ----------------------------------------------------------------------
		// ----------------------------------------------------------------------
		// ----------------------------------------------------------------------
		// ----------------------------------------------------------------------
		// ----------------------------------------------------------------------
		// ----------------------------------------------------------------------
		// ----------------------------------------------------------------------
		// ----------------------------------------------------------------------
		// ----------------------------------------------------------------------
		// ----------------------------------------------------------------------
		// ----------------------------------------------------------------------
		// ----------------------------------------------------------------------
	}

	/// <summary>
	/// Bit definitions for an integer defining the basic content type of text
	/// held in an
	/// <see cref="Editable">Editable</see>
	/// object. Supported classes may be combined
	/// with variations and flags to indicate desired behaviors.
	/// <h3>Examples</h3>
	/// <dl>
	/// <dt>A password field with with the password visible to the user:
	/// <dd>inputType = TYPE_CLASS_TEXT |
	/// TYPE_TEXT_VARIATION_VISIBLE_PASSWORD
	/// <dt>A multi-line postal address with automatic capitalization:
	/// <dd>inputType = TYPE_CLASS_TEXT |
	/// TYPE_TEXT_VARIATION_POSTAL_ADDRESS |
	/// TYPE_TEXT_FLAG_MULTI_LINE
	/// <dt>A time field:
	/// <dd>inputType = TYPE_CLASS_DATETIME |
	/// TYPE_DATETIME_VARIATION_TIME
	/// </dl>
	/// </summary>
	[Sharpen.Sharpened]
	public static class InputTypeClass
	{
		/// <summary>
		/// Mask of bits that determine the overall class
		/// of text being given.
		/// </summary>
		/// <remarks>
		/// Mask of bits that determine the overall class
		/// of text being given.  Currently supported classes are:
		/// <see cref="android.text.InputTypeClass.TYPE_CLASS_TEXT">android.text.InputTypeClass.TYPE_CLASS_TEXT
		/// 	</see>
		/// ,
		/// <see cref="android.text.InputTypeClass.TYPE_CLASS_NUMBER">android.text.InputTypeClass.TYPE_CLASS_NUMBER
		/// 	</see>
		/// ,
		/// <see cref="android.text.InputTypeClass.TYPE_CLASS_PHONE">android.text.InputTypeClass.TYPE_CLASS_PHONE
		/// 	</see>
		/// ,
		/// <see cref="android.text.InputTypeClass.TYPE_CLASS_DATETIME">android.text.InputTypeClass.TYPE_CLASS_DATETIME
		/// 	</see>
		/// .
		/// If the class is not one you
		/// understand, assume
		/// <see cref="android.text.InputTypeClass.TYPE_CLASS_TEXT">android.text.InputTypeClass.TYPE_CLASS_TEXT
		/// 	</see>
		/// with NO variation
		/// or flags.
		/// </remarks>
		public const int TYPE_MASK_CLASS = unchecked((int)(0x0000000f));

		/// <summary>
		/// Mask of bits that determine the variation of
		/// the base content class.
		/// </summary>
		/// <remarks>
		/// Mask of bits that determine the variation of
		/// the base content class.
		/// </remarks>
		public const int TYPE_MASK_VARIATION = unchecked((int)(0x00000ff0));

		/// <summary>
		/// Mask of bits that provide addition bit flags
		/// of options.
		/// </summary>
		/// <remarks>
		/// Mask of bits that provide addition bit flags
		/// of options.
		/// </remarks>
		public const int TYPE_MASK_FLAGS = unchecked((int)(0x00fff000));

		/// <summary>Special content type for when no explicit type has been specified.</summary>
		/// <remarks>
		/// Special content type for when no explicit type has been specified.
		/// This should be interpreted to mean that the target input connection
		/// is not rich, it can not process and show things like candidate text nor
		/// retrieve the current text, so the input method will need to run in a
		/// limited "generate key events" mode.
		/// </remarks>
		public const int TYPE_NULL = unchecked((int)(0x00000000));

		/// <summary>Class for normal text.</summary>
		/// <remarks>
		/// Class for normal text.  This class supports the following flags (only
		/// one of which should be set):
		/// <see cref="android.text.InputTypeClass.TYPE_TEXT_FLAG_CAP_CHARACTERS">android.text.InputTypeClass.TYPE_TEXT_FLAG_CAP_CHARACTERS
		/// 	</see>
		/// ,
		/// <see cref="android.text.InputTypeClass.TYPE_TEXT_FLAG_CAP_WORDS">android.text.InputTypeClass.TYPE_TEXT_FLAG_CAP_WORDS
		/// 	</see>
		/// , and.
		/// <see cref="android.text.InputTypeClass.TYPE_TEXT_FLAG_CAP_SENTENCES">android.text.InputTypeClass.TYPE_TEXT_FLAG_CAP_SENTENCES
		/// 	</see>
		/// .  It also supports the
		/// following variations:
		/// <see cref="android.text.InputTypeClass.TYPE_TEXT_VARIATION_NORMAL">android.text.InputTypeClass.TYPE_TEXT_VARIATION_NORMAL
		/// 	</see>
		/// , and
		/// <see cref="android.text.InputTypeClass.TYPE_TEXT_VARIATION_URI">android.text.InputTypeClass.TYPE_TEXT_VARIATION_URI
		/// 	</see>
		/// .  If you do not recognize the
		/// variation, normal should be assumed.
		/// </remarks>
		public const int TYPE_CLASS_TEXT = unchecked((int)(0x00000001));

		/// <summary>
		/// Flag for
		/// <see cref="android.text.InputTypeClass.TYPE_CLASS_TEXT">android.text.InputTypeClass.TYPE_CLASS_TEXT
		/// 	</see>
		/// : capitalize all characters.  Overrides
		/// <see cref="android.text.InputTypeClass.TYPE_TEXT_FLAG_CAP_WORDS">android.text.InputTypeClass.TYPE_TEXT_FLAG_CAP_WORDS
		/// 	</see>
		/// and
		/// <see cref="android.text.InputTypeClass.TYPE_TEXT_FLAG_CAP_SENTENCES">android.text.InputTypeClass.TYPE_TEXT_FLAG_CAP_SENTENCES
		/// 	</see>
		/// .  This value is explicitly defined
		/// to be the same as
		/// <see cref="TextUtils.CAP_MODE_CHARACTERS">TextUtils.CAP_MODE_CHARACTERS</see>
		/// .
		/// </summary>
		public const int TYPE_TEXT_FLAG_CAP_CHARACTERS = unchecked((int)(0x00001000));

		/// <summary>
		/// Flag for
		/// <see cref="android.text.InputTypeClass.TYPE_CLASS_TEXT">android.text.InputTypeClass.TYPE_CLASS_TEXT
		/// 	</see>
		/// : capitalize first character of
		/// all words.  Overrides
		/// <see cref="android.text.InputTypeClass.TYPE_TEXT_FLAG_CAP_SENTENCES">android.text.InputTypeClass.TYPE_TEXT_FLAG_CAP_SENTENCES
		/// 	</see>
		/// .  This
		/// value is explicitly defined
		/// to be the same as
		/// <see cref="TextUtils.CAP_MODE_WORDS">TextUtils.CAP_MODE_WORDS</see>
		/// .
		/// </summary>
		public const int TYPE_TEXT_FLAG_CAP_WORDS = unchecked((int)(0x00002000));

		/// <summary>
		/// Flag for
		/// <see cref="android.text.InputTypeClass.TYPE_CLASS_TEXT">android.text.InputTypeClass.TYPE_CLASS_TEXT
		/// 	</see>
		/// : capitalize first character of
		/// each sentence.  This value is explicitly defined
		/// to be the same as
		/// <see cref="TextUtils.CAP_MODE_SENTENCES">TextUtils.CAP_MODE_SENTENCES</see>
		/// .
		/// </summary>
		public const int TYPE_TEXT_FLAG_CAP_SENTENCES = unchecked((int)(0x00004000));

		/// <summary>
		/// Flag for
		/// <see cref="android.text.InputTypeClass.TYPE_CLASS_TEXT">android.text.InputTypeClass.TYPE_CLASS_TEXT
		/// 	</see>
		/// : the user is entering free-form
		/// text that should have auto-correction applied to it.
		/// </summary>
		public const int TYPE_TEXT_FLAG_AUTO_CORRECT = unchecked((int)(0x00008000));

		/// <summary>
		/// Flag for
		/// <see cref="android.text.InputTypeClass.TYPE_CLASS_TEXT">android.text.InputTypeClass.TYPE_CLASS_TEXT
		/// 	</see>
		/// : the text editor is performing
		/// auto-completion of the text being entered based on its own semantics,
		/// which it will present to the user as they type.  This generally means
		/// that the input method should not be showing candidates itself, but can
		/// expect for the editor to supply its own completions/candidates from
		/// <see cref="android.view.inputmethod.InputMethodSession.displayCompletions(android.view.inputmethod.CompletionInfo[])
		/// 	">InputMethodSession.displayCompletions()</see>
		/// as a result of the editor calling
		/// <see cref="android.view.inputmethod.InputMethodManager.displayCompletions(android.view.View, android.view.inputmethod.CompletionInfo[])
		/// 	">InputMethodManager.displayCompletions()</see>
		/// .
		/// </summary>
		public const int TYPE_TEXT_FLAG_AUTO_COMPLETE = unchecked((int)(0x00010000));

		/// <summary>
		/// Flag for
		/// <see cref="android.text.InputTypeClass.TYPE_CLASS_TEXT">android.text.InputTypeClass.TYPE_CLASS_TEXT
		/// 	</see>
		/// : multiple lines of text can be
		/// entered into the field.  If this flag is not set, the text field
		/// will be constrained to a single line.
		/// </summary>
		public const int TYPE_TEXT_FLAG_MULTI_LINE = unchecked((int)(0x00020000));

		/// <summary>
		/// Flag for
		/// <see cref="android.text.InputTypeClass.TYPE_CLASS_TEXT">android.text.InputTypeClass.TYPE_CLASS_TEXT
		/// 	</see>
		/// : the regular text view associated
		/// with this should not be multi-line, but when a fullscreen input method
		/// is providing text it should use multiple lines if it can.
		/// </summary>
		public const int TYPE_TEXT_FLAG_IME_MULTI_LINE = unchecked((int)(0x00040000));

		/// <summary>
		/// Flag for
		/// <see cref="android.text.InputTypeClass.TYPE_CLASS_TEXT">android.text.InputTypeClass.TYPE_CLASS_TEXT
		/// 	</see>
		/// : the input method does not need to
		/// display any dictionary-based candidates. This is useful for text views that
		/// do not contain words from the language and do not benefit from any
		/// dictionary-based completions or corrections. It overrides the
		/// <see cref="android.text.InputTypeClass.TYPE_TEXT_FLAG_AUTO_CORRECT">android.text.InputTypeClass.TYPE_TEXT_FLAG_AUTO_CORRECT
		/// 	</see>
		/// value when set.
		/// </summary>
		public const int TYPE_TEXT_FLAG_NO_SUGGESTIONS = unchecked((int)(0x00080000));

		/// <summary>
		/// Default variation of
		/// <see cref="android.text.InputTypeClass.TYPE_CLASS_TEXT">android.text.InputTypeClass.TYPE_CLASS_TEXT
		/// 	</see>
		/// : plain old normal text.
		/// </summary>
		public const int TYPE_TEXT_VARIATION_NORMAL = unchecked((int)(0x00000000));

		/// <summary>
		/// Variation of
		/// <see cref="android.text.InputTypeClass.TYPE_CLASS_TEXT">android.text.InputTypeClass.TYPE_CLASS_TEXT
		/// 	</see>
		/// : entering a URI.
		/// </summary>
		public const int TYPE_TEXT_VARIATION_URI = unchecked((int)(0x00000010));

		/// <summary>
		/// Variation of
		/// <see cref="android.text.InputTypeClass.TYPE_CLASS_TEXT">android.text.InputTypeClass.TYPE_CLASS_TEXT
		/// 	</see>
		/// : entering an e-mail address.
		/// </summary>
		public const int TYPE_TEXT_VARIATION_EMAIL_ADDRESS = unchecked((int)(0x00000020));

		/// <summary>
		/// Variation of
		/// <see cref="android.text.InputTypeClass.TYPE_CLASS_TEXT">android.text.InputTypeClass.TYPE_CLASS_TEXT
		/// 	</see>
		/// : entering the subject line of
		/// an e-mail.
		/// </summary>
		public const int TYPE_TEXT_VARIATION_EMAIL_SUBJECT = unchecked((int)(0x00000030));

		/// <summary>
		/// Variation of
		/// <see cref="android.text.InputTypeClass.TYPE_CLASS_TEXT">android.text.InputTypeClass.TYPE_CLASS_TEXT
		/// 	</see>
		/// : entering a short, possibly informal
		/// message such as an instant message or a text message.
		/// </summary>
		public const int TYPE_TEXT_VARIATION_SHORT_MESSAGE = unchecked((int)(0x00000040));

		/// <summary>
		/// Variation of
		/// <see cref="android.text.InputTypeClass.TYPE_CLASS_TEXT">android.text.InputTypeClass.TYPE_CLASS_TEXT
		/// 	</see>
		/// : entering the content of a long, possibly
		/// formal message such as the body of an e-mail.
		/// </summary>
		public const int TYPE_TEXT_VARIATION_LONG_MESSAGE = unchecked((int)(0x00000050));

		/// <summary>
		/// Variation of
		/// <see cref="android.text.InputTypeClass.TYPE_CLASS_TEXT">android.text.InputTypeClass.TYPE_CLASS_TEXT
		/// 	</see>
		/// : entering the name of a person.
		/// </summary>
		public const int TYPE_TEXT_VARIATION_PERSON_NAME = unchecked((int)(0x00000060));

		/// <summary>
		/// Variation of
		/// <see cref="android.text.InputTypeClass.TYPE_CLASS_TEXT">android.text.InputTypeClass.TYPE_CLASS_TEXT
		/// 	</see>
		/// : entering a postal mailing address.
		/// </summary>
		public const int TYPE_TEXT_VARIATION_POSTAL_ADDRESS = unchecked((int)(0x00000070)
			);

		/// <summary>
		/// Variation of
		/// <see cref="android.text.InputTypeClass.TYPE_CLASS_TEXT">android.text.InputTypeClass.TYPE_CLASS_TEXT
		/// 	</see>
		/// : entering a password.
		/// </summary>
		public const int TYPE_TEXT_VARIATION_PASSWORD = unchecked((int)(0x00000080));

		/// <summary>
		/// Variation of
		/// <see cref="android.text.InputTypeClass.TYPE_CLASS_TEXT">android.text.InputTypeClass.TYPE_CLASS_TEXT
		/// 	</see>
		/// : entering a password, which should
		/// be visible to the user.
		/// </summary>
		public const int TYPE_TEXT_VARIATION_VISIBLE_PASSWORD = unchecked((int)(0x00000090
			));

		/// <summary>
		/// Variation of
		/// <see cref="android.text.InputTypeClass.TYPE_CLASS_TEXT">android.text.InputTypeClass.TYPE_CLASS_TEXT
		/// 	</see>
		/// : entering text inside of a web form.
		/// </summary>
		public const int TYPE_TEXT_VARIATION_WEB_EDIT_TEXT = unchecked((int)(0x000000a0));

		/// <summary>
		/// Variation of
		/// <see cref="android.text.InputTypeClass.TYPE_CLASS_TEXT">android.text.InputTypeClass.TYPE_CLASS_TEXT
		/// 	</see>
		/// : entering text to filter contents
		/// of a list etc.
		/// </summary>
		public const int TYPE_TEXT_VARIATION_FILTER = unchecked((int)(0x000000b0));

		/// <summary>
		/// Variation of
		/// <see cref="android.text.InputTypeClass.TYPE_CLASS_TEXT">android.text.InputTypeClass.TYPE_CLASS_TEXT
		/// 	</see>
		/// : entering text for phonetic
		/// pronunciation, such as a phonetic name field in contacts.
		/// </summary>
		public const int TYPE_TEXT_VARIATION_PHONETIC = unchecked((int)(0x000000c0));

		/// <summary>
		/// Variation of
		/// <see cref="android.text.InputTypeClass.TYPE_CLASS_TEXT">android.text.InputTypeClass.TYPE_CLASS_TEXT
		/// 	</see>
		/// : entering e-mail address inside
		/// of a web form.  This was added in
		/// <see cref="android.os.Build.VERSION_CODES.HONEYCOMB">android.os.Build.VERSION_CODES.HONEYCOMB
		/// 	</see>
		/// .  An IME must target
		/// this API version or later to see this input type; if it doesn't, a request
		/// for this type will be seen as
		/// <see cref="android.text.InputTypeClass.TYPE_TEXT_VARIATION_EMAIL_ADDRESS">android.text.InputTypeClass.TYPE_TEXT_VARIATION_EMAIL_ADDRESS
		/// 	</see>
		/// when passed through
		/// <see cref="android.view.inputmethod.EditorInfo.makeCompatible(int)">EditorInfo.makeCompatible(int)
		/// 	</see>
		/// .
		/// </summary>
		public const int TYPE_TEXT_VARIATION_WEB_EMAIL_ADDRESS = unchecked((int)(0x000000d0
			));

		/// <summary>
		/// Variation of
		/// <see cref="android.text.InputTypeClass.TYPE_CLASS_TEXT">android.text.InputTypeClass.TYPE_CLASS_TEXT
		/// 	</see>
		/// : entering password inside
		/// of a web form.  This was added in
		/// <see cref="android.os.Build.VERSION_CODES.HONEYCOMB">android.os.Build.VERSION_CODES.HONEYCOMB
		/// 	</see>
		/// .  An IME must target
		/// this API version or later to see this input type; if it doesn't, a request
		/// for this type will be seen as
		/// <see cref="android.text.InputTypeClass.TYPE_TEXT_VARIATION_PASSWORD">android.text.InputTypeClass.TYPE_TEXT_VARIATION_PASSWORD
		/// 	</see>
		/// when passed through
		/// <see cref="android.view.inputmethod.EditorInfo.makeCompatible(int)">EditorInfo.makeCompatible(int)
		/// 	</see>
		/// .
		/// </summary>
		public const int TYPE_TEXT_VARIATION_WEB_PASSWORD = unchecked((int)(0x000000e0));

		/// <summary>Class for numeric text.</summary>
		/// <remarks>
		/// Class for numeric text.  This class supports the following flag:
		/// <see cref="android.text.InputTypeClass.TYPE_NUMBER_FLAG_SIGNED">android.text.InputTypeClass.TYPE_NUMBER_FLAG_SIGNED
		/// 	</see>
		/// and
		/// <see cref="android.text.InputTypeClass.TYPE_NUMBER_FLAG_DECIMAL">android.text.InputTypeClass.TYPE_NUMBER_FLAG_DECIMAL
		/// 	</see>
		/// .  It also supports the following
		/// variations:
		/// <see cref="android.text.InputTypeClass.TYPE_NUMBER_VARIATION_NORMAL">android.text.InputTypeClass.TYPE_NUMBER_VARIATION_NORMAL
		/// 	</see>
		/// and
		/// <see cref="android.text.InputTypeClass.TYPE_NUMBER_VARIATION_PASSWORD">android.text.InputTypeClass.TYPE_NUMBER_VARIATION_PASSWORD
		/// 	</see>
		/// .  If you do not recognize
		/// the variation, normal should be assumed.
		/// </remarks>
		public const int TYPE_CLASS_NUMBER = unchecked((int)(0x00000002));

		/// <summary>
		/// Flag of
		/// <see cref="android.text.InputTypeClass.TYPE_CLASS_NUMBER">android.text.InputTypeClass.TYPE_CLASS_NUMBER
		/// 	</see>
		/// : the number is signed, allowing
		/// a positive or negative sign at the start.
		/// </summary>
		public const int TYPE_NUMBER_FLAG_SIGNED = unchecked((int)(0x00001000));

		/// <summary>
		/// Flag of
		/// <see cref="android.text.InputTypeClass.TYPE_CLASS_NUMBER">android.text.InputTypeClass.TYPE_CLASS_NUMBER
		/// 	</see>
		/// : the number is decimal, allowing
		/// a decimal point to provide fractional values.
		/// </summary>
		public const int TYPE_NUMBER_FLAG_DECIMAL = unchecked((int)(0x00002000));

		/// <summary>
		/// Default variation of
		/// <see cref="android.text.InputTypeClass.TYPE_CLASS_NUMBER">android.text.InputTypeClass.TYPE_CLASS_NUMBER
		/// 	</see>
		/// : plain normal
		/// numeric text.  This was added in
		/// <see cref="android.os.Build.VERSION_CODES.HONEYCOMB">android.os.Build.VERSION_CODES.HONEYCOMB
		/// 	</see>
		/// .  An IME must target
		/// this API version or later to see this input type; if it doesn't, a request
		/// for this type will be dropped when passed through
		/// <see cref="android.view.inputmethod.EditorInfo.makeCompatible(int)">EditorInfo.makeCompatible(int)
		/// 	</see>
		/// .
		/// </summary>
		public const int TYPE_NUMBER_VARIATION_NORMAL = unchecked((int)(0x00000000));

		/// <summary>
		/// Variation of
		/// <see cref="android.text.InputTypeClass.TYPE_CLASS_NUMBER">android.text.InputTypeClass.TYPE_CLASS_NUMBER
		/// 	</see>
		/// : entering a numeric password.
		/// This was added in
		/// <see cref="android.os.Build.VERSION_CODES.HONEYCOMB">android.os.Build.VERSION_CODES.HONEYCOMB
		/// 	</see>
		/// .  An
		/// IME must target this API version or later to see this input type; if it
		/// doesn't, a request for this type will be dropped when passed
		/// through
		/// <see cref="android.view.inputmethod.EditorInfo.makeCompatible(int)">EditorInfo.makeCompatible(int)
		/// 	</see>
		/// .
		/// </summary>
		public const int TYPE_NUMBER_VARIATION_PASSWORD = unchecked((int)(0x00000010));

		/// <summary>Class for a phone number.</summary>
		/// <remarks>
		/// Class for a phone number.  This class currently supports no variations
		/// or flags.
		/// </remarks>
		public const int TYPE_CLASS_PHONE = unchecked((int)(0x00000003));

		/// <summary>Class for dates and times.</summary>
		/// <remarks>
		/// Class for dates and times.  It supports the
		/// following variations:
		/// <see cref="android.text.InputTypeClass.TYPE_DATETIME_VARIATION_NORMAL">android.text.InputTypeClass.TYPE_DATETIME_VARIATION_NORMAL
		/// 	</see>
		/// <see cref="android.text.InputTypeClass.TYPE_DATETIME_VARIATION_DATE">android.text.InputTypeClass.TYPE_DATETIME_VARIATION_DATE
		/// 	</see>
		/// , and
		/// <see cref="android.text.InputTypeClass.TYPE_DATETIME_VARIATION_TIME">android.text.InputTypeClass.TYPE_DATETIME_VARIATION_TIME
		/// 	</see>
		/// ,.
		/// </remarks>
		public const int TYPE_CLASS_DATETIME = unchecked((int)(0x00000004));

		/// <summary>
		/// Default variation of
		/// <see cref="android.text.InputTypeClass.TYPE_CLASS_DATETIME">android.text.InputTypeClass.TYPE_CLASS_DATETIME
		/// 	</see>
		/// : allows entering
		/// both a date and time.
		/// </summary>
		public const int TYPE_DATETIME_VARIATION_NORMAL = unchecked((int)(0x00000000));

		/// <summary>
		/// Default variation of
		/// <see cref="android.text.InputTypeClass.TYPE_CLASS_DATETIME">android.text.InputTypeClass.TYPE_CLASS_DATETIME
		/// 	</see>
		/// : allows entering
		/// only a date.
		/// </summary>
		public const int TYPE_DATETIME_VARIATION_DATE = unchecked((int)(0x00000010));

		/// <summary>
		/// Default variation of
		/// <see cref="android.text.InputTypeClass.TYPE_CLASS_DATETIME">android.text.InputTypeClass.TYPE_CLASS_DATETIME
		/// 	</see>
		/// : allows entering
		/// only a time.
		/// </summary>
		public const int TYPE_DATETIME_VARIATION_TIME = unchecked((int)(0x00000020));
	}
}

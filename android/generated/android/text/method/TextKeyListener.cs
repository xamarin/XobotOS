using Sharpen;

namespace android.text.method
{
	/// <summary>This is the key listener for typing normal text.</summary>
	/// <remarks>
	/// This is the key listener for typing normal text.  It delegates to
	/// other key listeners appropriate to the current keyboard and language.
	/// </remarks>
	[Sharpen.Sharpened]
	public partial class TextKeyListener : android.text.method.BaseKeyListener, android.text.SpanWatcher
	{
		private static android.text.method.TextKeyListener[] sInstance = new android.text.method.TextKeyListener
			[System.Enum.GetValues(typeof(android.text.method.TextKeyListener.Capitalize)).Length
			 * 2];

		internal static readonly object ACTIVE = new android.text.NoCopySpanClass.Concrete
			();

		internal static readonly object CAPPED = new android.text.NoCopySpanClass.Concrete
			();

		internal static readonly object INHIBIT_REPLACEMENT = new android.text.NoCopySpanClass
			.Concrete();

		internal static readonly object LAST_TYPED = new android.text.NoCopySpanClass.Concrete
			();

		private android.text.method.TextKeyListener.Capitalize mAutoCap;

		private bool mAutoText;

		private int mPrefs;

		private bool mPrefsInited;

		internal const int AUTO_CAP = 1;

		internal const int AUTO_TEXT = 2;

		internal const int AUTO_PERIOD = 4;

		internal const int SHOW_PASSWORD = 8;

		private java.lang.@ref.WeakReference<android.content.ContentResolver> mResolver;

		private android.text.method.TextKeyListener.SettingsObserver mObserver;

		/// <summary>
		/// Creates a new TextKeyListener with the specified capitalization
		/// and correction properties.
		/// </summary>
		/// <remarks>
		/// Creates a new TextKeyListener with the specified capitalization
		/// and correction properties.
		/// </remarks>
		/// <param name="cap">when, if ever, to automatically capitalize.</param>
		/// <param name="autotext">whether to automatically do spelling corrections.</param>
		public TextKeyListener(android.text.method.TextKeyListener.Capitalize cap, bool autotext
			)
		{
			mAutoCap = cap;
			mAutoText = autotext;
		}

		/// <summary>
		/// Returns a new or existing instance with the specified capitalization
		/// and correction properties.
		/// </summary>
		/// <remarks>
		/// Returns a new or existing instance with the specified capitalization
		/// and correction properties.
		/// </remarks>
		/// <param name="cap">when, if ever, to automatically capitalize.</param>
		/// <param name="autotext">whether to automatically do spelling corrections.</param>
		public static android.text.method.TextKeyListener getInstance(bool autotext, android.text.method.TextKeyListener
			.Capitalize cap)
		{
			int off = (int)(cap) * 2 + (autotext ? 1 : 0);
			if (sInstance[off] == null)
			{
				sInstance[off] = new android.text.method.TextKeyListener(cap, autotext);
			}
			return sInstance[off];
		}

		/// <summary>
		/// Returns a new or existing instance with no automatic capitalization
		/// or correction.
		/// </summary>
		/// <remarks>
		/// Returns a new or existing instance with no automatic capitalization
		/// or correction.
		/// </remarks>
		public static android.text.method.TextKeyListener getInstance()
		{
			return getInstance(false, android.text.method.TextKeyListener.Capitalize.NONE);
		}

		/// <summary>
		/// Returns whether it makes sense to automatically capitalize at the
		/// specified position in the specified text, with the specified rules.
		/// </summary>
		/// <remarks>
		/// Returns whether it makes sense to automatically capitalize at the
		/// specified position in the specified text, with the specified rules.
		/// </remarks>
		/// <param name="cap">the capitalization rules to consider.</param>
		/// <param name="cs">the text in which an insertion is being made.</param>
		/// <param name="off">the offset into that text where the insertion is being made.</param>
		/// <returns>whether the character being inserted should be capitalized.</returns>
		public static bool shouldCap(android.text.method.TextKeyListener.Capitalize cap, 
			java.lang.CharSequence cs, int off)
		{
			int i;
			char c;
			if (cap == android.text.method.TextKeyListener.Capitalize.NONE)
			{
				return false;
			}
			if (cap == android.text.method.TextKeyListener.Capitalize.CHARACTERS)
			{
				return true;
			}
			return android.text.TextUtils.getCapsMode(cs, off, cap == android.text.method.TextKeyListener
				.Capitalize.WORDS ? android.text.TextUtils.CAP_MODE_WORDS : android.text.TextUtils
				.CAP_MODE_SENTENCES) != 0;
		}

		[Sharpen.ImplementsInterface(@"android.text.method.KeyListener")]
		public override int getInputType()
		{
			return makeTextContentType(mAutoCap, mAutoText);
		}

		[Sharpen.OverridesMethod(@"android.text.method.MetaKeyKeyListener")]
		public override bool onKeyDown(android.view.View view, android.text.Editable content
			, int keyCode, android.view.KeyEvent @event)
		{
			android.text.method.KeyListener im = getKeyListener(@event);
			return im.onKeyDown(view, content, keyCode, @event);
		}

		[Sharpen.OverridesMethod(@"android.text.method.MetaKeyKeyListener")]
		public override bool onKeyUp(android.view.View view, android.text.Editable content
			, int keyCode, android.view.KeyEvent @event)
		{
			android.text.method.KeyListener im = getKeyListener(@event);
			return im.onKeyUp(view, content, keyCode, @event);
		}

		[Sharpen.OverridesMethod(@"android.text.method.BaseKeyListener")]
		public override bool onKeyOther(android.view.View view, android.text.Editable content
			, android.view.KeyEvent @event)
		{
			android.text.method.KeyListener im = getKeyListener(@event);
			return im.onKeyOther(view, content, @event);
		}

		/// <summary>
		/// Clear all the input state (autotext, autocap, multitap, undo)
		/// from the specified Editable, going beyond Editable.clear(), which
		/// just clears the text but not the input state.
		/// </summary>
		/// <remarks>
		/// Clear all the input state (autotext, autocap, multitap, undo)
		/// from the specified Editable, going beyond Editable.clear(), which
		/// just clears the text but not the input state.
		/// </remarks>
		/// <param name="e">the buffer whose text and state are to be cleared.</param>
		public static void clear(android.text.Editable e)
		{
			e.clear();
			e.removeSpan(ACTIVE);
			e.removeSpan(CAPPED);
			e.removeSpan(INHIBIT_REPLACEMENT);
			e.removeSpan(LAST_TYPED);
			android.text.method.QwertyKeyListener.Replaced[] repl = e.getSpans<android.text.method.QwertyKeyListener
				.Replaced>(0, e.Length);
			int count = repl.Length;
			{
				for (int i = 0; i < count; i++)
				{
					e.removeSpan(repl[i]);
				}
			}
		}

		[Sharpen.ImplementsInterface(@"android.text.SpanWatcher")]
		public virtual void onSpanAdded(android.text.Spannable s, object what, int start, 
			int end)
		{
		}

		[Sharpen.ImplementsInterface(@"android.text.SpanWatcher")]
		public virtual void onSpanRemoved(android.text.Spannable s, object what, int start
			, int end)
		{
		}

		[Sharpen.ImplementsInterface(@"android.text.SpanWatcher")]
		public virtual void onSpanChanged(android.text.Spannable s, object what, int start
			, int end, int st, int en)
		{
			if (what == android.text.Selection.SELECTION_END)
			{
				s.removeSpan(ACTIVE);
			}
		}

		private android.text.method.KeyListener getKeyListener(android.view.KeyEvent @event
			)
		{
			android.view.KeyCharacterMap kmap = @event.getKeyCharacterMap();
			int kind = kmap.getKeyboardType();
			if (kind == android.view.KeyCharacterMap.ALPHA)
			{
				return android.text.method.QwertyKeyListener.getInstance(mAutoText, mAutoCap);
			}
			else
			{
				if (kind == android.view.KeyCharacterMap.NUMERIC)
				{
					return android.text.method.MultiTapKeyListener.getInstance(mAutoText, mAutoCap);
				}
				else
				{
					if (kind == android.view.KeyCharacterMap.FULL || kind == android.view.KeyCharacterMap
						.SPECIAL_FUNCTION)
					{
						// We consider special function keyboards full keyboards as a workaround for
						// devices that do not have built-in keyboards.  Applications may try to inject
						// key events using the built-in keyboard device id which may be configured as
						// a special function keyboard using a default key map.  Ideally, as of Honeycomb,
						// these applications should be modified to use KeyCharacterMap.VIRTUAL_KEYBOARD.
						return android.text.method.QwertyKeyListener.getInstanceForFullKeyboard();
					}
				}
			}
			return android.text.method.TextKeyListener.NullKeyListener.getInstance();
		}

		public enum Capitalize
		{
			NONE,
			SENTENCES,
			WORDS,
			CHARACTERS
		}

		private class NullKeyListener : android.text.method.KeyListener
		{
			[Sharpen.ImplementsInterface(@"android.text.method.KeyListener")]
			public virtual int getInputType()
			{
				return android.text.InputTypeClass.TYPE_NULL;
			}

			[Sharpen.ImplementsInterface(@"android.text.method.KeyListener")]
			public virtual bool onKeyDown(android.view.View view, android.text.Editable content
				, int keyCode, android.view.KeyEvent @event)
			{
				return false;
			}

			[Sharpen.ImplementsInterface(@"android.text.method.KeyListener")]
			public virtual bool onKeyUp(android.view.View view, android.text.Editable content
				, int keyCode, android.view.KeyEvent @event)
			{
				return false;
			}

			[Sharpen.ImplementsInterface(@"android.text.method.KeyListener")]
			public virtual bool onKeyOther(android.view.View view, android.text.Editable content
				, android.view.KeyEvent @event)
			{
				return false;
			}

			[Sharpen.ImplementsInterface(@"android.text.method.KeyListener")]
			public virtual void clearMetaKeyState(android.view.View view, android.text.Editable
				 content, int states)
			{
			}

			public static android.text.method.TextKeyListener.NullKeyListener getInstance()
			{
				if (sInstance != null)
				{
					return sInstance;
				}
				sInstance = new android.text.method.TextKeyListener.NullKeyListener();
				return sInstance;
			}

			internal static android.text.method.TextKeyListener.NullKeyListener sInstance;
		}

		public virtual void release()
		{
			if (mResolver != null)
			{
				android.content.ContentResolver contentResolver = mResolver.get();
				if (contentResolver != null)
				{
					contentResolver.unregisterContentObserver(mObserver);
					mResolver.clear();
				}
				mObserver = null;
				mResolver = null;
				mPrefsInited = false;
			}
		}

		private class SettingsObserver : android.database.ContentObserver
		{
			public SettingsObserver(TextKeyListener _enclosing) : base(new android.os.Handler
				())
			{
				this._enclosing = _enclosing;
			}

			[Sharpen.OverridesMethod(@"android.database.ContentObserver")]
			public override void onChange(bool selfChange)
			{
				if (this._enclosing.mResolver != null)
				{
					android.content.ContentResolver contentResolver = this._enclosing.mResolver.get();
					if (contentResolver == null)
					{
						this._enclosing.mPrefsInited = false;
					}
					else
					{
						this._enclosing.updatePrefs(contentResolver);
					}
				}
				else
				{
					this._enclosing.mPrefsInited = false;
				}
			}

			private readonly TextKeyListener _enclosing;
		}
	}
}

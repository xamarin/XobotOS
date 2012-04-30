using Sharpen;

namespace android.widget
{
	/// <summary>Displays text to the user and optionally allows them to edit it.</summary>
	/// <remarks>
	/// Displays text to the user and optionally allows them to edit it.  A TextView
	/// is a complete text editor, however the basic class is configured to not
	/// allow editing; see
	/// <see cref="EditText">EditText</see>
	/// for a subclass that configures the text
	/// view for editing.
	/// <p>
	/// <b>XML attributes</b>
	/// <p>
	/// See
	/// <see cref="android.R.styleable.TextView">TextView Attributes</see>
	/// ,
	/// <see cref="android.R.styleable.View">View Attributes</see>
	/// </remarks>
	/// <attr>ref android.R.styleable#TextView_text</attr>
	/// <attr>ref android.R.styleable#TextView_bufferType</attr>
	/// <attr>ref android.R.styleable#TextView_hint</attr>
	/// <attr>ref android.R.styleable#TextView_textColor</attr>
	/// <attr>ref android.R.styleable#TextView_textColorHighlight</attr>
	/// <attr>ref android.R.styleable#TextView_textColorHint</attr>
	/// <attr>ref android.R.styleable#TextView_textAppearance</attr>
	/// <attr>ref android.R.styleable#TextView_textColorLink</attr>
	/// <attr>ref android.R.styleable#TextView_textSize</attr>
	/// <attr>ref android.R.styleable#TextView_textScaleX</attr>
	/// <attr>ref android.R.styleable#TextView_typeface</attr>
	/// <attr>ref android.R.styleable#TextView_textStyle</attr>
	/// <attr>ref android.R.styleable#TextView_cursorVisible</attr>
	/// <attr>ref android.R.styleable#TextView_maxLines</attr>
	/// <attr>ref android.R.styleable#TextView_maxHeight</attr>
	/// <attr>ref android.R.styleable#TextView_lines</attr>
	/// <attr>ref android.R.styleable#TextView_height</attr>
	/// <attr>ref android.R.styleable#TextView_minLines</attr>
	/// <attr>ref android.R.styleable#TextView_minHeight</attr>
	/// <attr>ref android.R.styleable#TextView_maxEms</attr>
	/// <attr>ref android.R.styleable#TextView_maxWidth</attr>
	/// <attr>ref android.R.styleable#TextView_ems</attr>
	/// <attr>ref android.R.styleable#TextView_width</attr>
	/// <attr>ref android.R.styleable#TextView_minEms</attr>
	/// <attr>ref android.R.styleable#TextView_minWidth</attr>
	/// <attr>ref android.R.styleable#TextView_gravity</attr>
	/// <attr>ref android.R.styleable#TextView_scrollHorizontally</attr>
	/// <attr>ref android.R.styleable#TextView_password</attr>
	/// <attr>ref android.R.styleable#TextView_singleLine</attr>
	/// <attr>ref android.R.styleable#TextView_selectAllOnFocus</attr>
	/// <attr>ref android.R.styleable#TextView_includeFontPadding</attr>
	/// <attr>ref android.R.styleable#TextView_maxLength</attr>
	/// <attr>ref android.R.styleable#TextView_shadowColor</attr>
	/// <attr>ref android.R.styleable#TextView_shadowDx</attr>
	/// <attr>ref android.R.styleable#TextView_shadowDy</attr>
	/// <attr>ref android.R.styleable#TextView_shadowRadius</attr>
	/// <attr>ref android.R.styleable#TextView_autoLink</attr>
	/// <attr>ref android.R.styleable#TextView_linksClickable</attr>
	/// <attr>ref android.R.styleable#TextView_numeric</attr>
	/// <attr>ref android.R.styleable#TextView_digits</attr>
	/// <attr>ref android.R.styleable#TextView_phoneNumber</attr>
	/// <attr>ref android.R.styleable#TextView_inputMethod</attr>
	/// <attr>ref android.R.styleable#TextView_capitalize</attr>
	/// <attr>ref android.R.styleable#TextView_autoText</attr>
	/// <attr>ref android.R.styleable#TextView_editable</attr>
	/// <attr>ref android.R.styleable#TextView_freezesText</attr>
	/// <attr>ref android.R.styleable#TextView_ellipsize</attr>
	/// <attr>ref android.R.styleable#TextView_drawableTop</attr>
	/// <attr>ref android.R.styleable#TextView_drawableBottom</attr>
	/// <attr>ref android.R.styleable#TextView_drawableRight</attr>
	/// <attr>ref android.R.styleable#TextView_drawableLeft</attr>
	/// <attr>ref android.R.styleable#TextView_drawablePadding</attr>
	/// <attr>ref android.R.styleable#TextView_lineSpacingExtra</attr>
	/// <attr>ref android.R.styleable#TextView_lineSpacingMultiplier</attr>
	/// <attr>ref android.R.styleable#TextView_marqueeRepeatLimit</attr>
	/// <attr>ref android.R.styleable#TextView_inputType</attr>
	/// <attr>ref android.R.styleable#TextView_imeOptions</attr>
	/// <attr>ref android.R.styleable#TextView_privateImeOptions</attr>
	/// <attr>ref android.R.styleable#TextView_imeActionLabel</attr>
	/// <attr>ref android.R.styleable#TextView_imeActionId</attr>
	/// <attr>ref android.R.styleable#TextView_editorExtras</attr>
	[Sharpen.Sharpened]
	public class TextView : android.view.View, android.view.ViewTreeObserver.OnPreDrawListener
	{
		internal const string LOG_TAG = "TextView";

		internal const bool DEBUG_EXTRACT = false;

		internal const int PRIORITY = 100;

		private int mCurrentAlpha = 255;

		internal readonly int[] mTempCoords = new int[2];

		internal android.graphics.Rect mTempRect;

		private android.content.res.ColorStateList mTextColor;

		private int mCurTextColor;

		private android.content.res.ColorStateList mHintTextColor;

		private android.content.res.ColorStateList mLinkTextColor;

		private int mCurHintTextColor;

		private bool mFreezesText;

		private bool mFrozenWithFocus;

		private bool mTemporaryDetach;

		private bool mDispatchTemporaryDetach;

		private bool mDiscardNextActionUp = false;

		private bool mIgnoreActionUpEvent = false;

		private android.text.EditableClass.Factory mEditableFactory = android.text.EditableClass
			.Factory.getInstance();

		private android.text.SpannableClass.Factory mSpannableFactory = android.text.SpannableClass
			.Factory.getInstance();

		private float mShadowRadius;

		private float mShadowDx;

		private float mShadowDy;

		internal const int PREDRAW_NOT_REGISTERED = 0;

		internal const int PREDRAW_PENDING = 1;

		internal const int PREDRAW_DONE = 2;

		private int mPreDrawState = PREDRAW_NOT_REGISTERED;

		private android.text.TextUtils.TruncateAt? mEllipsize = null;

		internal const int SANS = 1;

		internal const int SERIF = 2;

		internal const int MONOSPACE = 3;

		internal const int SIGNED = 2;

		internal const int DECIMAL = 4;

		internal class Drawables
		{
			internal readonly android.graphics.Rect mCompoundRect;

			internal android.graphics.drawable.Drawable mDrawableTop;

			internal android.graphics.drawable.Drawable mDrawableBottom;

			internal android.graphics.drawable.Drawable mDrawableLeft;

			internal android.graphics.drawable.Drawable mDrawableRight;

			internal android.graphics.drawable.Drawable mDrawableStart;

			internal android.graphics.drawable.Drawable mDrawableEnd;

			internal int mDrawableSizeTop;

			internal int mDrawableSizeBottom;

			internal int mDrawableSizeLeft;

			internal int mDrawableSizeRight;

			internal int mDrawableSizeStart;

			internal int mDrawableSizeEnd;

			internal int mDrawableWidthTop;

			internal int mDrawableWidthBottom;

			internal int mDrawableHeightLeft;

			internal int mDrawableHeightRight;

			internal int mDrawableHeightStart;

			internal int mDrawableHeightEnd;

			internal int mDrawablePadding;

			public Drawables(TextView _enclosing)
			{
				this._enclosing = _enclosing;
				mCompoundRect = new android.graphics.Rect();
			}

			private readonly TextView _enclosing;
			// Enum for the "typeface" XML parameter.
			// TODO: How can we get this from the XML instead of hardcoding it here?
			// Bitfield for the "numeric" XML parameter.
			// TODO: How can we get this from the XML instead of hardcoding it here?
		}

		private android.widget.TextView.Drawables mDrawables;

		private java.lang.CharSequence mError;

		private bool mErrorWasChanged;

		private android.widget.TextView.ErrorPopup mPopup;

		/// <summary>
		/// This flag is set if the TextView tries to display an error before it
		/// is attached to the window (so its position is still unknown).
		/// </summary>
		/// <remarks>
		/// This flag is set if the TextView tries to display an error before it
		/// is attached to the window (so its position is still unknown).
		/// It causes the error to be shown later, when onAttachedToWindow()
		/// is called.
		/// </remarks>
		private bool mShowErrorAfterAttach;

		private android.widget.TextView.CharWrapper mCharWrapper = null;

		private bool mSelectionMoved = false;

		private bool mTouchFocusSelected = false;

		private android.widget.TextView.Marquee mMarquee;

		private bool mRestartMarquee;

		private int mMarqueeRepeatLimit = 3;

		internal class InputContentType
		{
			internal int imeOptions;

			internal string privateImeOptions;

			internal java.lang.CharSequence imeActionLabel;

			internal int imeActionId;

			internal android.os.Bundle extras;

			internal android.widget.TextView.OnEditorActionListener onEditorActionListener;

			internal bool enterDown;

			public InputContentType(TextView _enclosing)
			{
				this._enclosing = _enclosing;
				imeOptions = android.view.inputmethod.EditorInfo.IME_NULL;
			}

			private readonly TextView _enclosing;
		}

		internal android.widget.TextView.InputContentType mInputContentType;

		internal class InputMethodState
		{
			internal android.graphics.Rect mCursorRectInWindow;

			internal android.graphics.RectF mTmpRectF;

			internal float[] mTmpOffset;

			internal android.view.inputmethod.ExtractedTextRequest mExtracting;

			internal readonly android.view.inputmethod.ExtractedText mTmpExtracted;

			internal int mBatchEditNesting;

			internal bool mCursorChanged;

			internal bool mSelectionModeChanged;

			internal bool mContentChanged;

			internal int mChangedStart;

			internal int mChangedEnd;

			internal int mChangedDelta;

			public InputMethodState(TextView _enclosing)
			{
				this._enclosing = _enclosing;
				mCursorRectInWindow = new android.graphics.Rect();
				mTmpRectF = new android.graphics.RectF();
				mTmpOffset = new float[2];
				mTmpExtracted = new android.view.inputmethod.ExtractedText();
			}

			private readonly TextView _enclosing;
		}

		internal android.widget.TextView.InputMethodState mInputMethodState;

		private int mTextSelectHandleLeftRes;

		private int mTextSelectHandleRightRes;

		private int mTextSelectHandleRes;

		private int mTextEditSuggestionItemLayout;

		private android.widget.TextView.SuggestionsPopupWindow mSuggestionsPopupWindow;

		private android.text.style.SuggestionRangeSpan mSuggestionRangeSpan;

		private int mCursorDrawableRes;

		private readonly android.graphics.drawable.Drawable[] mCursorDrawable = new android.graphics.drawable.Drawable
			[2];

		private int mCursorCount;

		private android.graphics.drawable.Drawable mSelectHandleLeft;

		private android.graphics.drawable.Drawable mSelectHandleRight;

		private android.graphics.drawable.Drawable mSelectHandleCenter;

		private android.widget.TextView.PositionListener mPositionListener;

		private float mLastDownPositionX;

		private float mLastDownPositionY;

		private android.view.ActionMode.Callback mCustomSelectionActionModeCallback;

		private readonly int mSquaredTouchSlopDistance;

		private bool mCreatedWithASelection = false;

		private android.text.method.WordIterator mWordIterator;

		private android.widget.SpellChecker mSpellChecker;

		private android.text.Layout.Alignment? mLayoutAlignment;

		private android.widget.TextView.TextAlign mTextAlign = android.widget.TextView.TextAlign
			.INHERIT;

		private enum TextAlign
		{
			INHERIT,
			GRAVITY,
			TEXT_START,
			TEXT_END,
			CENTER,
			VIEW_START,
			VIEW_END
		}

		private bool mResolvedDrawables = false;

		/// <summary>
		/// On some devices the fading edges add a performance penalty if used
		/// extensively in the same layout.
		/// </summary>
		/// <remarks>
		/// On some devices the fading edges add a performance penalty if used
		/// extensively in the same layout. This mode indicates how the marquee
		/// is currently being shown, if applicable. (mEllipsize will == MARQUEE)
		/// </remarks>
		private int mMarqueeFadeMode = MARQUEE_FADE_NORMAL;

		/// <summary>
		/// When mMarqueeFadeMode is not MARQUEE_FADE_NORMAL, this stores
		/// the layout that should be used when the mode switches.
		/// </summary>
		/// <remarks>
		/// When mMarqueeFadeMode is not MARQUEE_FADE_NORMAL, this stores
		/// the layout that should be used when the mode switches.
		/// </remarks>
		private android.text.Layout mSavedMarqueeModeLayout;

		/// <summary>Draw marquee text with fading edges as usual</summary>
		internal const int MARQUEE_FADE_NORMAL = 0;

		/// <summary>Draw marquee text as ellipsize end while inactive instead of with the fade.
		/// 	</summary>
		/// <remarks>
		/// Draw marquee text as ellipsize end while inactive instead of with the fade.
		/// (Useful for devices where the fade can be expensive if overdone)
		/// </remarks>
		internal const int MARQUEE_FADE_SWITCH_SHOW_ELLIPSIS = 1;

		/// <summary>Draw marquee text with fading edges because it is currently active/animating.
		/// 	</summary>
		/// <remarks>Draw marquee text with fading edges because it is currently active/animating.
		/// 	</remarks>
		internal const int MARQUEE_FADE_SWITCH_SHOW_FADE = 2;

		static TextView()
		{
			// Actual current number of used mCursorDrawable: 0, 1 or 2
			// Global listener that detects changes in the global position of the TextView
			// Set when this TextView gained focus with some text selected. Will start selection mode.
			// The alignment to pass to Layout, or null if not resolved.
			// The default value for mTextAlign.
			android.graphics.Paint p = new android.graphics.Paint();
			p.setAntiAlias(true);
			// We don't care about the result, just the side-effect of measuring.
			p.measureText("H");
		}

		/// <summary>
		/// Interface definition for a callback to be invoked when an action is
		/// performed on the editor.
		/// </summary>
		/// <remarks>
		/// Interface definition for a callback to be invoked when an action is
		/// performed on the editor.
		/// </remarks>
		public interface OnEditorActionListener
		{
			/// <summary>Called when an action is being performed.</summary>
			/// <remarks>Called when an action is being performed.</remarks>
			/// <param name="v">The view that was clicked.</param>
			/// <param name="actionId">
			/// Identifier of the action.  This will be either the
			/// identifier you supplied, or
			/// <see cref="android.view.inputmethod.EditorInfo.IME_NULL">EditorInfo.IME_NULL</see>
			/// if being called due to the enter key
			/// being pressed.
			/// </param>
			/// <param name="event">
			/// If triggered by an enter key, this is the event;
			/// otherwise, this is null.
			/// </param>
			/// <returns>Return true if you have consumed the action, else false.</returns>
			bool onEditorAction(android.widget.TextView v, int actionId, android.view.KeyEvent
				 @event);
		}

		public TextView(android.content.Context context) : this(context, null)
		{
			mOldMaximum = mMaximum;
			mOldMaxMode = mMaxMode;
		}

		public TextView(android.content.Context context, android.util.AttributeSet attrs)
			 : this(context, attrs, android.@internal.R.attr.textViewStyle)
		{
			mOldMaximum = mMaximum;
			mOldMaxMode = mMaxMode;
		}

		public TextView(android.content.Context context, android.util.AttributeSet attrs, 
			int defStyle) : base(context, attrs, defStyle)
		{
			mOldMaximum = mMaximum;
			mOldMaxMode = mMaxMode;
			mText = java.lang.CharSequenceProxy.Wrap(string.Empty);
			mTextPaint = new android.text.TextPaint(android.graphics.Paint.ANTI_ALIAS_FLAG);
			mTextPaint.density = getResources().getDisplayMetrics().density;
			mTextPaint.setCompatibilityScaling(getResources().getCompatibilityInfo().applicationScale
				);
			// If we get the paint from the skin, we should set it to left, since
			// the layout always wants it to be left.
			// mTextPaint.setTextAlign(Paint.Align.LEFT);
			mHighlightPaint = new android.graphics.Paint(android.graphics.Paint.ANTI_ALIAS_FLAG
				);
			mHighlightPaint.setCompatibilityScaling(getResources().getCompatibilityInfo().applicationScale
				);
			mMovement = getDefaultMovementMethod();
			mTransformation = null;
			int textColorHighlight = 0;
			android.content.res.ColorStateList textColor = null;
			android.content.res.ColorStateList textColorHint = null;
			android.content.res.ColorStateList textColorLink = null;
			int textSize = 15;
			int typefaceIndex = -1;
			int styleIndex = -1;
			bool allCaps = false;
			android.content.res.Resources.Theme theme = context.getTheme();
			android.content.res.TypedArray a = theme.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.TextViewAppearance, defStyle, 0);
			android.content.res.TypedArray appearance = null;
			int ap = a.getResourceId(android.@internal.R.styleable.TextViewAppearance_textAppearance
				, -1);
			a.recycle();
			if (ap != -1)
			{
				appearance = theme.obtainStyledAttributes(ap, android.@internal.R.styleable.TextAppearance
					);
			}
			if (appearance != null)
			{
				int n = appearance.getIndexCount();
				{
					for (int i = 0; i < n; i++)
					{
						int attr = appearance.getIndex(i);
						switch (attr)
						{
							case android.@internal.R.styleable.TextAppearance_textColorHighlight:
							{
								textColorHighlight = appearance.getColor(attr, textColorHighlight);
								break;
							}

							case android.@internal.R.styleable.TextAppearance_textColor:
							{
								textColor = appearance.getColorStateList(attr);
								break;
							}

							case android.@internal.R.styleable.TextAppearance_textColorHint:
							{
								textColorHint = appearance.getColorStateList(attr);
								break;
							}

							case android.@internal.R.styleable.TextAppearance_textColorLink:
							{
								textColorLink = appearance.getColorStateList(attr);
								break;
							}

							case android.@internal.R.styleable.TextAppearance_textSize:
							{
								textSize = appearance.getDimensionPixelSize(attr, textSize);
								break;
							}

							case android.@internal.R.styleable.TextAppearance_typeface:
							{
								typefaceIndex = appearance.getInt(attr, -1);
								break;
							}

							case android.@internal.R.styleable.TextAppearance_textStyle:
							{
								styleIndex = appearance.getInt(attr, -1);
								break;
							}

							case android.@internal.R.styleable.TextAppearance_textAllCaps:
							{
								allCaps = appearance.getBoolean(attr, false);
								break;
							}
						}
					}
				}
				appearance.recycle();
			}
			bool editable = getDefaultEditable();
			java.lang.CharSequence inputMethod = null;
			int numeric = 0;
			java.lang.CharSequence digits = null;
			bool phone = false;
			bool autotext = false;
			int autocap = -1;
			int buffertype = 0;
			bool selectallonfocus = false;
			android.graphics.drawable.Drawable drawableLeft = null;
			android.graphics.drawable.Drawable drawableTop = null;
			android.graphics.drawable.Drawable drawableRight = null;
			android.graphics.drawable.Drawable drawableBottom = null;
			android.graphics.drawable.Drawable drawableStart = null;
			android.graphics.drawable.Drawable drawableEnd = null;
			int drawablePadding = 0;
			int ellipsize = -1;
			bool singleLine = false;
			int maxlength = -1;
			java.lang.CharSequence text = java.lang.CharSequenceProxy.Wrap(string.Empty);
			java.lang.CharSequence hint = null;
			int shadowcolor = 0;
			float dx = 0;
			float dy = 0;
			float r = 0;
			bool password = false;
			int inputType = android.text.InputTypeClass.TYPE_NULL;
			a = theme.obtainStyledAttributes(attrs, android.@internal.R.styleable.TextView, defStyle
				, 0);
			int n_1 = a.getIndexCount();
			{
				for (int i_1 = 0; i_1 < n_1; i_1++)
				{
					int attr = a.getIndex(i_1);
					switch (attr)
					{
						case android.@internal.R.styleable.TextView_editable:
						{
							editable = a.getBoolean(attr, editable);
							break;
						}

						case android.@internal.R.styleable.TextView_inputMethod:
						{
							inputMethod = a.getText(attr);
							break;
						}

						case android.@internal.R.styleable.TextView_numeric:
						{
							numeric = a.getInt(attr, numeric);
							break;
						}

						case android.@internal.R.styleable.TextView_digits:
						{
							digits = a.getText(attr);
							break;
						}

						case android.@internal.R.styleable.TextView_phoneNumber:
						{
							phone = a.getBoolean(attr, phone);
							break;
						}

						case android.@internal.R.styleable.TextView_autoText:
						{
							autotext = a.getBoolean(attr, autotext);
							break;
						}

						case android.@internal.R.styleable.TextView_capitalize:
						{
							autocap = a.getInt(attr, autocap);
							break;
						}

						case android.@internal.R.styleable.TextView_bufferType:
						{
							buffertype = a.getInt(attr, buffertype);
							break;
						}

						case android.@internal.R.styleable.TextView_selectAllOnFocus:
						{
							selectallonfocus = a.getBoolean(attr, selectallonfocus);
							break;
						}

						case android.@internal.R.styleable.TextView_autoLink:
						{
							mAutoLinkMask = a.getInt(attr, 0);
							break;
						}

						case android.@internal.R.styleable.TextView_linksClickable:
						{
							mLinksClickable = a.getBoolean(attr, true);
							break;
						}

						case android.@internal.R.styleable.TextView_drawableLeft:
						{
							drawableLeft = a.getDrawable(attr);
							break;
						}

						case android.@internal.R.styleable.TextView_drawableTop:
						{
							drawableTop = a.getDrawable(attr);
							break;
						}

						case android.@internal.R.styleable.TextView_drawableRight:
						{
							drawableRight = a.getDrawable(attr);
							break;
						}

						case android.@internal.R.styleable.TextView_drawableBottom:
						{
							drawableBottom = a.getDrawable(attr);
							break;
						}

						case android.@internal.R.styleable.TextView_drawableStart:
						{
							drawableStart = a.getDrawable(attr);
							break;
						}

						case android.@internal.R.styleable.TextView_drawableEnd:
						{
							drawableEnd = a.getDrawable(attr);
							break;
						}

						case android.@internal.R.styleable.TextView_drawablePadding:
						{
							drawablePadding = a.getDimensionPixelSize(attr, drawablePadding);
							break;
						}

						case android.@internal.R.styleable.TextView_maxLines:
						{
							setMaxLines(a.getInt(attr, -1));
							break;
						}

						case android.@internal.R.styleable.TextView_maxHeight:
						{
							setMaxHeight(a.getDimensionPixelSize(attr, -1));
							break;
						}

						case android.@internal.R.styleable.TextView_lines:
						{
							setLines(a.getInt(attr, -1));
							break;
						}

						case android.@internal.R.styleable.TextView_height:
						{
							setHeight(a.getDimensionPixelSize(attr, -1));
							break;
						}

						case android.@internal.R.styleable.TextView_minLines:
						{
							setMinLines(a.getInt(attr, -1));
							break;
						}

						case android.@internal.R.styleable.TextView_minHeight:
						{
							setMinHeight(a.getDimensionPixelSize(attr, -1));
							break;
						}

						case android.@internal.R.styleable.TextView_maxEms:
						{
							setMaxEms(a.getInt(attr, -1));
							break;
						}

						case android.@internal.R.styleable.TextView_maxWidth:
						{
							setMaxWidth(a.getDimensionPixelSize(attr, -1));
							break;
						}

						case android.@internal.R.styleable.TextView_ems:
						{
							setEms(a.getInt(attr, -1));
							break;
						}

						case android.@internal.R.styleable.TextView_width:
						{
							setWidth(a.getDimensionPixelSize(attr, -1));
							break;
						}

						case android.@internal.R.styleable.TextView_minEms:
						{
							setMinEms(a.getInt(attr, -1));
							break;
						}

						case android.@internal.R.styleable.TextView_minWidth:
						{
							setMinWidth(a.getDimensionPixelSize(attr, -1));
							break;
						}

						case android.@internal.R.styleable.TextView_gravity:
						{
							setGravity(a.getInt(attr, -1));
							break;
						}

						case android.@internal.R.styleable.TextView_hint:
						{
							hint = a.getText(attr);
							break;
						}

						case android.@internal.R.styleable.TextView_text:
						{
							text = a.getText(attr);
							break;
						}

						case android.@internal.R.styleable.TextView_scrollHorizontally:
						{
							if (a.getBoolean(attr, false))
							{
								setHorizontallyScrolling(true);
							}
							break;
						}

						case android.@internal.R.styleable.TextView_singleLine:
						{
							singleLine = a.getBoolean(attr, singleLine);
							break;
						}

						case android.@internal.R.styleable.TextView_ellipsize:
						{
							ellipsize = a.getInt(attr, ellipsize);
							break;
						}

						case android.@internal.R.styleable.TextView_marqueeRepeatLimit:
						{
							setMarqueeRepeatLimit(a.getInt(attr, mMarqueeRepeatLimit));
							break;
						}

						case android.@internal.R.styleable.TextView_includeFontPadding:
						{
							if (!a.getBoolean(attr, true))
							{
								setIncludeFontPadding(false);
							}
							break;
						}

						case android.@internal.R.styleable.TextView_cursorVisible:
						{
							if (!a.getBoolean(attr, true))
							{
								setCursorVisible(false);
							}
							break;
						}

						case android.@internal.R.styleable.TextView_maxLength:
						{
							maxlength = a.getInt(attr, -1);
							break;
						}

						case android.@internal.R.styleable.TextView_textScaleX:
						{
							setTextScaleX(a.getFloat(attr, 1.0f));
							break;
						}

						case android.@internal.R.styleable.TextView_freezesText:
						{
							mFreezesText = a.getBoolean(attr, false);
							break;
						}

						case android.@internal.R.styleable.TextView_shadowColor:
						{
							shadowcolor = a.getInt(attr, 0);
							break;
						}

						case android.@internal.R.styleable.TextView_shadowDx:
						{
							dx = a.getFloat(attr, 0);
							break;
						}

						case android.@internal.R.styleable.TextView_shadowDy:
						{
							dy = a.getFloat(attr, 0);
							break;
						}

						case android.@internal.R.styleable.TextView_shadowRadius:
						{
							r = a.getFloat(attr, 0);
							break;
						}

						case android.@internal.R.styleable.TextView_enabled:
						{
							setEnabled(a.getBoolean(attr, isEnabled()));
							break;
						}

						case android.@internal.R.styleable.TextView_textColorHighlight:
						{
							textColorHighlight = a.getColor(attr, textColorHighlight);
							break;
						}

						case android.@internal.R.styleable.TextView_textColor:
						{
							textColor = a.getColorStateList(attr);
							break;
						}

						case android.@internal.R.styleable.TextView_textColorHint:
						{
							textColorHint = a.getColorStateList(attr);
							break;
						}

						case android.@internal.R.styleable.TextView_textColorLink:
						{
							textColorLink = a.getColorStateList(attr);
							break;
						}

						case android.@internal.R.styleable.TextView_textSize:
						{
							textSize = a.getDimensionPixelSize(attr, textSize);
							break;
						}

						case android.@internal.R.styleable.TextView_typeface:
						{
							typefaceIndex = a.getInt(attr, typefaceIndex);
							break;
						}

						case android.@internal.R.styleable.TextView_textStyle:
						{
							styleIndex = a.getInt(attr, styleIndex);
							break;
						}

						case android.@internal.R.styleable.TextView_password:
						{
							password = a.getBoolean(attr, password);
							break;
						}

						case android.@internal.R.styleable.TextView_lineSpacingExtra:
						{
							mSpacingAdd = a.getDimensionPixelSize(attr, (int)mSpacingAdd);
							break;
						}

						case android.@internal.R.styleable.TextView_lineSpacingMultiplier:
						{
							mSpacingMult = a.getFloat(attr, mSpacingMult);
							break;
						}

						case android.@internal.R.styleable.TextView_inputType:
						{
							inputType = a.getInt(attr, mInputType);
							break;
						}

						case android.@internal.R.styleable.TextView_imeOptions:
						{
							if (mInputContentType == null)
							{
								mInputContentType = new android.widget.TextView.InputContentType(this);
							}
							mInputContentType.imeOptions = a.getInt(attr, mInputContentType.imeOptions);
							break;
						}

						case android.@internal.R.styleable.TextView_imeActionLabel:
						{
							if (mInputContentType == null)
							{
								mInputContentType = new android.widget.TextView.InputContentType(this);
							}
							mInputContentType.imeActionLabel = a.getText(attr);
							break;
						}

						case android.@internal.R.styleable.TextView_imeActionId:
						{
							if (mInputContentType == null)
							{
								mInputContentType = new android.widget.TextView.InputContentType(this);
							}
							mInputContentType.imeActionId = a.getInt(attr, mInputContentType.imeActionId);
							break;
						}

						case android.@internal.R.styleable.TextView_privateImeOptions:
						{
							setPrivateImeOptions(a.getString(attr));
							break;
						}

						case android.@internal.R.styleable.TextView_editorExtras:
						{
							try
							{
								setInputExtras(a.getResourceId(attr, 0));
							}
							catch (org.xmlpull.v1.XmlPullParserException e)
							{
								android.util.Log.w(LOG_TAG, "Failure reading input extras", e);
							}
							catch (System.IO.IOException e)
							{
								android.util.Log.w(LOG_TAG, "Failure reading input extras", e);
							}
							break;
						}

						case android.@internal.R.styleable.TextView_textCursorDrawable:
						{
							mCursorDrawableRes = a.getResourceId(attr, 0);
							break;
						}

						case android.@internal.R.styleable.TextView_textSelectHandleLeft:
						{
							mTextSelectHandleLeftRes = a.getResourceId(attr, 0);
							break;
						}

						case android.@internal.R.styleable.TextView_textSelectHandleRight:
						{
							mTextSelectHandleRightRes = a.getResourceId(attr, 0);
							break;
						}

						case android.@internal.R.styleable.TextView_textSelectHandle:
						{
							mTextSelectHandleRes = a.getResourceId(attr, 0);
							break;
						}

						case android.@internal.R.styleable.TextView_textEditSuggestionItemLayout:
						{
							mTextEditSuggestionItemLayout = a.getResourceId(attr, 0);
							break;
						}

						case android.@internal.R.styleable.TextView_textIsSelectable:
						{
							mTextIsSelectable = a.getBoolean(attr, false);
							break;
						}

						case android.@internal.R.styleable.TextView_textAllCaps:
						{
							allCaps = a.getBoolean(attr, false);
							break;
						}
					}
				}
			}
			a.recycle();
			android.widget.TextView.BufferType bufferType = android.widget.TextView.BufferType
				.EDITABLE;
			int variation = inputType & (android.text.InputTypeClass.TYPE_MASK_CLASS | android.text.InputTypeClass.TYPE_MASK_VARIATION
				);
			bool passwordInputType = variation == (android.text.InputTypeClass.TYPE_CLASS_TEXT
				 | android.text.InputTypeClass.TYPE_TEXT_VARIATION_PASSWORD);
			bool webPasswordInputType = variation == (android.text.InputTypeClass.TYPE_CLASS_TEXT
				 | android.text.InputTypeClass.TYPE_TEXT_VARIATION_WEB_PASSWORD);
			bool numberPasswordInputType = variation == (android.text.InputTypeClass.TYPE_CLASS_NUMBER
				 | android.text.InputTypeClass.TYPE_NUMBER_VARIATION_PASSWORD);
			if (inputMethod != null)
			{
				System.Type c;
				try
				{
					c = XobotOS.Runtime.Reflection.GetType(inputMethod.ToString());
				}
				catch (java.lang.ClassNotFoundException ex)
				{
					throw new java.lang.RuntimeException(ex);
				}
				try
				{
					mInput = (android.text.method.KeyListener)System.Activator.CreateInstance(c);
				}
				catch (java.lang.InstantiationException ex)
				{
					throw new java.lang.RuntimeException(ex);
				}
				catch (System.MemberAccessException ex)
				{
					throw new java.lang.RuntimeException(ex);
				}
				try
				{
					mInputType = inputType != android.text.InputTypeClass.TYPE_NULL ? inputType : mInput
						.getInputType();
				}
				catch (java.lang.IncompatibleClassChangeError)
				{
					mInputType = android.text.InputTypeClass.TYPE_CLASS_TEXT;
				}
			}
			else
			{
				if (digits != null)
				{
					mInput = android.text.method.DigitsKeyListener.getInstance(digits.ToString());
					// If no input type was specified, we will default to generic
					// text, since we can't tell the IME about the set of digits
					// that was selected.
					mInputType = inputType != android.text.InputTypeClass.TYPE_NULL ? inputType : android.text.InputTypeClass.TYPE_CLASS_TEXT;
				}
				else
				{
					if (inputType != android.text.InputTypeClass.TYPE_NULL)
					{
						setInputType(inputType, true);
						// If set, the input type overrides what was set using the deprecated singleLine flag.
						singleLine = !isMultilineInputType(inputType);
					}
					else
					{
						if (phone)
						{
							mInput = android.text.method.DialerKeyListener.getInstance();
							mInputType = inputType = android.text.InputTypeClass.TYPE_CLASS_PHONE;
						}
						else
						{
							if (numeric != 0)
							{
								mInput = android.text.method.DigitsKeyListener.getInstance((numeric & SIGNED) != 
									0, (numeric & DECIMAL) != 0);
								inputType = android.text.InputTypeClass.TYPE_CLASS_NUMBER;
								if ((numeric & SIGNED) != 0)
								{
									inputType |= android.text.InputTypeClass.TYPE_NUMBER_FLAG_SIGNED;
								}
								if ((numeric & DECIMAL) != 0)
								{
									inputType |= android.text.InputTypeClass.TYPE_NUMBER_FLAG_DECIMAL;
								}
								mInputType = inputType;
							}
							else
							{
								if (autotext || autocap != -1)
								{
									android.text.method.TextKeyListener.Capitalize cap;
									inputType = android.text.InputTypeClass.TYPE_CLASS_TEXT;
									switch (autocap)
									{
										case 1:
										{
											cap = android.text.method.TextKeyListener.Capitalize.SENTENCES;
											inputType |= android.text.InputTypeClass.TYPE_TEXT_FLAG_CAP_SENTENCES;
											break;
										}

										case 2:
										{
											cap = android.text.method.TextKeyListener.Capitalize.WORDS;
											inputType |= android.text.InputTypeClass.TYPE_TEXT_FLAG_CAP_WORDS;
											break;
										}

										case 3:
										{
											cap = android.text.method.TextKeyListener.Capitalize.CHARACTERS;
											inputType |= android.text.InputTypeClass.TYPE_TEXT_FLAG_CAP_CHARACTERS;
											break;
										}

										default:
										{
											cap = android.text.method.TextKeyListener.Capitalize.NONE;
											break;
										}
									}
									mInput = android.text.method.TextKeyListener.getInstance(autotext, cap);
									mInputType = inputType;
								}
								else
								{
									if (mTextIsSelectable)
									{
										// Prevent text changes from keyboard.
										mInputType = android.text.InputTypeClass.TYPE_NULL;
										mInput = null;
										bufferType = android.widget.TextView.BufferType.SPANNABLE;
										// Required to request focus while in touch mode.
										setFocusableInTouchMode(true);
										// So that selection can be changed using arrow keys and touch is handled.
										setMovementMethod(android.text.method.ArrowKeyMovementMethod.getInstance());
									}
									else
									{
										if (editable)
										{
											mInput = android.text.method.TextKeyListener.getInstance();
											mInputType = android.text.InputTypeClass.TYPE_CLASS_TEXT;
										}
										else
										{
											mInput = null;
											switch (buffertype)
											{
												case 0:
												{
													bufferType = android.widget.TextView.BufferType.NORMAL;
													break;
												}

												case 1:
												{
													bufferType = android.widget.TextView.BufferType.SPANNABLE;
													break;
												}

												case 2:
												{
													bufferType = android.widget.TextView.BufferType.EDITABLE;
													break;
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			// mInputType has been set from inputType, possibly modified by mInputMethod.
			// Specialize mInputType to [web]password if we have a text class and the original input
			// type was a password.
			if ((mInputType & android.text.InputTypeClass.TYPE_MASK_CLASS) == android.text.InputTypeClass.TYPE_CLASS_TEXT)
			{
				if (password || passwordInputType)
				{
					mInputType = (mInputType & ~(android.text.InputTypeClass.TYPE_MASK_VARIATION)) | 
						android.text.InputTypeClass.TYPE_TEXT_VARIATION_PASSWORD;
				}
				if (webPasswordInputType)
				{
					mInputType = (mInputType & ~(android.text.InputTypeClass.TYPE_MASK_VARIATION)) | 
						android.text.InputTypeClass.TYPE_TEXT_VARIATION_WEB_PASSWORD;
				}
			}
			else
			{
				if ((mInputType & android.text.InputTypeClass.TYPE_MASK_CLASS) == android.text.InputTypeClass.TYPE_CLASS_NUMBER)
				{
					if (numberPasswordInputType)
					{
						mInputType = (mInputType & ~(android.text.InputTypeClass.TYPE_MASK_VARIATION)) | 
							android.text.InputTypeClass.TYPE_NUMBER_VARIATION_PASSWORD;
					}
				}
			}
			if (selectallonfocus)
			{
				mSelectAllOnFocus = true;
				if (bufferType == android.widget.TextView.BufferType.NORMAL)
				{
					bufferType = android.widget.TextView.BufferType.SPANNABLE;
				}
			}
			setCompoundDrawablesWithIntrinsicBounds(drawableLeft, drawableTop, drawableRight, 
				drawableBottom);
			setRelativeDrawablesIfNeeded(drawableStart, drawableEnd);
			setCompoundDrawablePadding(drawablePadding);
			// Same as setSingleLine(), but make sure the transformation method and the maximum number
			// of lines of height are unchanged for multi-line TextViews.
			setInputTypeSingleLine(singleLine);
			applySingleLine(singleLine, singleLine, singleLine);
			if (singleLine && mInput == null && ellipsize < 0)
			{
				ellipsize = 3;
			}
			switch (ellipsize)
			{
				case 1:
				{
					// END
					setEllipsize(android.text.TextUtils.TruncateAt.START);
					break;
				}

				case 2:
				{
					setEllipsize(android.text.TextUtils.TruncateAt.MIDDLE);
					break;
				}

				case 3:
				{
					setEllipsize(android.text.TextUtils.TruncateAt.END);
					break;
				}

				case 4:
				{
					if (android.view.ViewConfiguration.get(context).isFadingMarqueeEnabled())
					{
						setHorizontalFadingEdgeEnabled(true);
						mMarqueeFadeMode = MARQUEE_FADE_NORMAL;
					}
					else
					{
						setHorizontalFadingEdgeEnabled(false);
						mMarqueeFadeMode = MARQUEE_FADE_SWITCH_SHOW_ELLIPSIS;
					}
					setEllipsize(android.text.TextUtils.TruncateAt.MARQUEE);
					break;
				}
			}
			setTextColor(textColor != null ? textColor : android.content.res.ColorStateList.valueOf
				(unchecked((int)(0xFF000000))));
			setHintTextColor(textColorHint);
			setLinkTextColor(textColorLink);
			if (textColorHighlight != 0)
			{
				setHighlightColor(textColorHighlight);
			}
			setRawTextSize(textSize);
			if (allCaps)
			{
				setTransformationMethod(new android.text.method.AllCapsTransformationMethod(getContext
					()));
			}
			if (password || passwordInputType || webPasswordInputType || numberPasswordInputType)
			{
				setTransformationMethod(android.text.method.PasswordTransformationMethod.getInstance
					());
				typefaceIndex = MONOSPACE;
			}
			else
			{
				if ((mInputType & (android.text.InputTypeClass.TYPE_MASK_CLASS | android.text.InputTypeClass.TYPE_MASK_VARIATION
					)) == (android.text.InputTypeClass.TYPE_CLASS_TEXT | android.text.InputTypeClass.TYPE_TEXT_VARIATION_PASSWORD
					))
				{
					typefaceIndex = MONOSPACE;
				}
			}
			setTypefaceByIndex(typefaceIndex, styleIndex);
			if (shadowcolor != 0)
			{
				setShadowLayer(r, dx, dy, shadowcolor);
			}
			if (maxlength >= 0)
			{
				setFilters(new android.text.InputFilter[] { new android.text.InputFilterClass.LengthFilter
					(maxlength) });
			}
			else
			{
				setFilters(NO_FILTERS);
			}
			setText(text, bufferType);
			if (hint != null)
			{
				setHint(hint);
			}
			a = context.obtainStyledAttributes(attrs, android.@internal.R.styleable.View, defStyle
				, 0);
			bool focusable = mMovement != null || mInput != null;
			bool clickable = focusable;
			bool longClickable = focusable;
			n_1 = a.getIndexCount();
			{
				for (int i_2 = 0; i_2 < n_1; i_2++)
				{
					int attr = a.getIndex(i_2);
					switch (attr)
					{
						case android.@internal.R.styleable.View_focusable:
						{
							focusable = a.getBoolean(attr, focusable);
							break;
						}

						case android.@internal.R.styleable.View_clickable:
						{
							clickable = a.getBoolean(attr, clickable);
							break;
						}

						case android.@internal.R.styleable.View_longClickable:
						{
							longClickable = a.getBoolean(attr, longClickable);
							break;
						}
					}
				}
			}
			a.recycle();
			setFocusable(focusable);
			setClickable(clickable);
			setLongClickable(longClickable);
			prepareCursorControllers();
			android.view.ViewConfiguration viewConfiguration = android.view.ViewConfiguration
				.get(context);
			int touchSlop = viewConfiguration.getScaledTouchSlop();
			mSquaredTouchSlopDistance = touchSlop * touchSlop;
		}

		private void setTypefaceByIndex(int typefaceIndex, int styleIndex)
		{
			android.graphics.Typeface tf = null;
			switch (typefaceIndex)
			{
				case SANS:
				{
					tf = android.graphics.Typeface.SANS_SERIF;
					break;
				}

				case SERIF:
				{
					tf = android.graphics.Typeface.SERIF;
					break;
				}

				case MONOSPACE:
				{
					tf = android.graphics.Typeface.MONOSPACE;
					break;
				}
			}
			setTypeface(tf, styleIndex);
		}

		private void setRelativeDrawablesIfNeeded(android.graphics.drawable.Drawable start
			, android.graphics.drawable.Drawable end)
		{
			bool hasRelativeDrawables = (start != null) || (end != null);
			if (hasRelativeDrawables)
			{
				android.widget.TextView.Drawables dr = mDrawables;
				if (dr == null)
				{
					mDrawables = dr = new android.widget.TextView.Drawables(this);
				}
				android.graphics.Rect compoundRect = dr.mCompoundRect;
				int[] state = getDrawableState();
				if (start != null)
				{
					start.setBounds(0, 0, start.getIntrinsicWidth(), start.getIntrinsicHeight());
					start.setState(state);
					start.copyBounds(compoundRect);
					start.setCallback(this);
					dr.mDrawableStart = start;
					dr.mDrawableSizeStart = compoundRect.width();
					dr.mDrawableHeightStart = compoundRect.height();
				}
				else
				{
					dr.mDrawableSizeStart = dr.mDrawableHeightStart = 0;
				}
				if (end != null)
				{
					end.setBounds(0, 0, end.getIntrinsicWidth(), end.getIntrinsicHeight());
					end.setState(state);
					end.copyBounds(compoundRect);
					end.setCallback(this);
					dr.mDrawableEnd = end;
					dr.mDrawableSizeEnd = compoundRect.width();
					dr.mDrawableHeightEnd = compoundRect.height();
				}
				else
				{
					dr.mDrawableSizeEnd = dr.mDrawableHeightEnd = 0;
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void setEnabled(bool enabled)
		{
			if (enabled == isEnabled())
			{
				return;
			}
			if (!enabled)
			{
				// Hide the soft input if the currently active TextView is disabled
				android.view.inputmethod.InputMethodManager imm = android.view.inputmethod.InputMethodManager
					.peekInstance();
				if (imm != null && imm.isActive(this))
				{
					imm.hideSoftInputFromWindow(getWindowToken(), 0);
				}
			}
			base.setEnabled(enabled);
			prepareCursorControllers();
			if (enabled)
			{
				// Make sure IME is updated with current editor info.
				android.view.inputmethod.InputMethodManager imm = android.view.inputmethod.InputMethodManager
					.peekInstance();
				if (imm != null)
				{
					imm.restartInput(this);
				}
			}
		}

		/// <summary>
		/// Sets the typeface and style in which the text should be displayed,
		/// and turns on the fake bold and italic bits in the Paint if the
		/// Typeface that you provided does not have all the bits in the
		/// style that you specified.
		/// </summary>
		/// <remarks>
		/// Sets the typeface and style in which the text should be displayed,
		/// and turns on the fake bold and italic bits in the Paint if the
		/// Typeface that you provided does not have all the bits in the
		/// style that you specified.
		/// </remarks>
		/// <attr>ref android.R.styleable#TextView_typeface</attr>
		/// <attr>ref android.R.styleable#TextView_textStyle</attr>
		public virtual void setTypeface(android.graphics.Typeface tf, int style)
		{
			if (style > 0)
			{
				if (tf == null)
				{
					tf = android.graphics.Typeface.defaultFromStyle(style);
				}
				else
				{
					tf = android.graphics.Typeface.create(tf, style);
				}
				setTypeface(tf);
				// now compute what (if any) algorithmic styling is needed
				int typefaceStyle = tf != null ? tf.getStyle() : 0;
				int need = style & ~typefaceStyle;
				mTextPaint.setFakeBoldText((need & android.graphics.Typeface.BOLD) != 0);
				mTextPaint.setTextSkewX((need & android.graphics.Typeface.ITALIC) != 0 ? -0.25f : 
					0);
			}
			else
			{
				mTextPaint.setFakeBoldText(false);
				mTextPaint.setTextSkewX(0);
				setTypeface(tf);
			}
		}

		/// <summary>
		/// Subclasses override this to specify that they have a KeyListener
		/// by default even if not specifically called for in the XML options.
		/// </summary>
		/// <remarks>
		/// Subclasses override this to specify that they have a KeyListener
		/// by default even if not specifically called for in the XML options.
		/// </remarks>
		protected internal virtual bool getDefaultEditable()
		{
			return false;
		}

		/// <summary>Subclasses override this to specify a default movement method.</summary>
		/// <remarks>Subclasses override this to specify a default movement method.</remarks>
		protected internal virtual android.text.method.MovementMethod getDefaultMovementMethod
			()
		{
			return null;
		}

		/// <summary>Return the text the TextView is displaying.</summary>
		/// <remarks>
		/// Return the text the TextView is displaying. If setText() was called with
		/// an argument of BufferType.SPANNABLE or BufferType.EDITABLE, you can cast
		/// the return value from this method to Spannable or Editable, respectively.
		/// Note: The content of the return value should not be modified. If you want
		/// a modifiable one, you should make your own copy first.
		/// </remarks>
		[android.view.ViewDebug.CapturedViewProperty]
		public virtual java.lang.CharSequence getText()
		{
			return mText;
		}

		/// <summary>Returns the length, in characters, of the text managed by this TextView</summary>
		public virtual int length()
		{
			return mText.Length;
		}

		/// <summary>Return the text the TextView is displaying as an Editable object.</summary>
		/// <remarks>
		/// Return the text the TextView is displaying as an Editable object.  If
		/// the text is not editable, null is returned.
		/// </remarks>
		/// <seealso cref="getText()">getText()</seealso>
		public virtual android.text.Editable getEditableText()
		{
			return (mText is android.text.Editable) ? (android.text.Editable)mText : null;
		}

		/// <returns>
		/// the height of one standard line in pixels.  Note that markup
		/// within the text can cause individual lines to be taller or shorter
		/// than this height, and the layout may contain additional first-
		/// or last-line padding.
		/// </returns>
		public virtual int getLineHeight()
		{
			return android.util.@internal.FastMath.round(mTextPaint.getFontMetricsInt(null) *
				 mSpacingMult + mSpacingAdd);
		}

		/// <returns>
		/// the Layout that is currently being used to display the text.
		/// This can be null if the text or width has recently changes.
		/// </returns>
		public android.text.Layout getLayout()
		{
			return mLayout;
		}

		/// <returns>
		/// the current key listener for this TextView.
		/// This will frequently be null for non-EditText TextViews.
		/// </returns>
		public android.text.method.KeyListener getKeyListener()
		{
			return mInput;
		}

		/// <summary>Sets the key listener to be used with this TextView.</summary>
		/// <remarks>
		/// Sets the key listener to be used with this TextView.  This can be null
		/// to disallow user input.  Note that this method has significant and
		/// subtle interactions with soft keyboards and other input method:
		/// see
		/// <see cref="android.text.method.KeyListener.getInputType()">KeyListener.getContentType()
		/// 	</see>
		/// for important details.  Calling this method will replace the current
		/// content type of the text view with the content type returned by the
		/// key listener.
		/// <p>
		/// Be warned that if you want a TextView with a key listener or movement
		/// method not to be focusable, or if you want a TextView without a
		/// key listener or movement method to be focusable, you must call
		/// <see cref="android.view.View.setFocusable(bool)">android.view.View.setFocusable(bool)
		/// 	</see>
		/// again after calling this to get the focusability
		/// back the way you want it.
		/// </remarks>
		/// <attr>ref android.R.styleable#TextView_numeric</attr>
		/// <attr>ref android.R.styleable#TextView_digits</attr>
		/// <attr>ref android.R.styleable#TextView_phoneNumber</attr>
		/// <attr>ref android.R.styleable#TextView_inputMethod</attr>
		/// <attr>ref android.R.styleable#TextView_capitalize</attr>
		/// <attr>ref android.R.styleable#TextView_autoText</attr>
		public virtual void setKeyListener(android.text.method.KeyListener input)
		{
			setKeyListenerOnly(input);
			fixFocusableAndClickableSettings();
			if (input != null)
			{
				try
				{
					mInputType = mInput.getInputType();
				}
				catch (java.lang.IncompatibleClassChangeError)
				{
					mInputType = android.text.InputTypeClass.TYPE_CLASS_TEXT;
				}
				// Change inputType, without affecting transformation.
				// No need to applySingleLine since mSingleLine is unchanged.
				setInputTypeSingleLine(mSingleLine);
			}
			else
			{
				mInputType = android.text.InputTypeClass.TYPE_NULL;
			}
			android.view.inputmethod.InputMethodManager imm = android.view.inputmethod.InputMethodManager
				.peekInstance();
			if (imm != null)
			{
				imm.restartInput(this);
			}
		}

		private void setKeyListenerOnly(android.text.method.KeyListener input)
		{
			mInput = input;
			if (mInput != null && !(mText is android.text.Editable))
			{
				setText(mText);
			}
			setFilters((android.text.Editable)mText, mFilters);
		}

		/// <returns>
		/// the movement method being used for this TextView.
		/// This will frequently be null for non-EditText TextViews.
		/// </returns>
		public android.text.method.MovementMethod getMovementMethod()
		{
			return mMovement;
		}

		/// <summary>
		/// Sets the movement method (arrow key handler) to be used for
		/// this TextView.
		/// </summary>
		/// <remarks>
		/// Sets the movement method (arrow key handler) to be used for
		/// this TextView.  This can be null to disallow using the arrow keys
		/// to move the cursor or scroll the view.
		/// <p>
		/// Be warned that if you want a TextView with a key listener or movement
		/// method not to be focusable, or if you want a TextView without a
		/// key listener or movement method to be focusable, you must call
		/// <see cref="android.view.View.setFocusable(bool)">android.view.View.setFocusable(bool)
		/// 	</see>
		/// again after calling this to get the focusability
		/// back the way you want it.
		/// </remarks>
		public void setMovementMethod(android.text.method.MovementMethod movement)
		{
			mMovement = movement;
			if (mMovement != null && !(mText is android.text.Spannable))
			{
				setText(mText);
			}
			fixFocusableAndClickableSettings();
			// SelectionModifierCursorController depends on textCanBeSelected, which depends on mMovement
			prepareCursorControllers();
		}

		private void fixFocusableAndClickableSettings()
		{
			if ((mMovement != null) || mInput != null)
			{
				setFocusable(true);
				setClickable(true);
				setLongClickable(true);
			}
			else
			{
				setFocusable(false);
				setClickable(false);
				setLongClickable(false);
			}
		}

		/// <returns>
		/// the current transformation method for this TextView.
		/// This will frequently be null except for single-line and password
		/// fields.
		/// </returns>
		public android.text.method.TransformationMethod getTransformationMethod()
		{
			return mTransformation;
		}

		/// <summary>
		/// Sets the transformation that is applied to the text that this
		/// TextView is displaying.
		/// </summary>
		/// <remarks>
		/// Sets the transformation that is applied to the text that this
		/// TextView is displaying.
		/// </remarks>
		/// <attr>ref android.R.styleable#TextView_password</attr>
		/// <attr>ref android.R.styleable#TextView_singleLine</attr>
		public void setTransformationMethod(android.text.method.TransformationMethod method
			)
		{
			if (method == mTransformation)
			{
				// Avoid the setText() below if the transformation is
				// the same.
				return;
			}
			if (mTransformation != null)
			{
				if (mText is android.text.Spannable)
				{
					((android.text.Spannable)mText).removeSpan(mTransformation);
				}
			}
			mTransformation = method;
			if (method is android.text.method.TransformationMethod2)
			{
				android.text.method.TransformationMethod2 method2 = (android.text.method.TransformationMethod2
					)method;
				mAllowTransformationLengthChange = !mTextIsSelectable && !(mText is android.text.Editable
					);
				method2.setLengthChangesAllowed(mAllowTransformationLengthChange);
			}
			else
			{
				mAllowTransformationLengthChange = false;
			}
			setText(mText);
		}

		/// <summary>
		/// Returns the top padding of the view, plus space for the top
		/// Drawable if any.
		/// </summary>
		/// <remarks>
		/// Returns the top padding of the view, plus space for the top
		/// Drawable if any.
		/// </remarks>
		public virtual int getCompoundPaddingTop()
		{
			android.widget.TextView.Drawables dr = mDrawables;
			if (dr == null || dr.mDrawableTop == null)
			{
				return mPaddingTop;
			}
			else
			{
				return mPaddingTop + dr.mDrawablePadding + dr.mDrawableSizeTop;
			}
		}

		/// <summary>
		/// Returns the bottom padding of the view, plus space for the bottom
		/// Drawable if any.
		/// </summary>
		/// <remarks>
		/// Returns the bottom padding of the view, plus space for the bottom
		/// Drawable if any.
		/// </remarks>
		public virtual int getCompoundPaddingBottom()
		{
			android.widget.TextView.Drawables dr = mDrawables;
			if (dr == null || dr.mDrawableBottom == null)
			{
				return mPaddingBottom;
			}
			else
			{
				return mPaddingBottom + dr.mDrawablePadding + dr.mDrawableSizeBottom;
			}
		}

		/// <summary>
		/// Returns the left padding of the view, plus space for the left
		/// Drawable if any.
		/// </summary>
		/// <remarks>
		/// Returns the left padding of the view, plus space for the left
		/// Drawable if any.
		/// </remarks>
		public virtual int getCompoundPaddingLeft()
		{
			android.widget.TextView.Drawables dr = mDrawables;
			if (dr == null || dr.mDrawableLeft == null)
			{
				return mPaddingLeft;
			}
			else
			{
				return mPaddingLeft + dr.mDrawablePadding + dr.mDrawableSizeLeft;
			}
		}

		/// <summary>
		/// Returns the right padding of the view, plus space for the right
		/// Drawable if any.
		/// </summary>
		/// <remarks>
		/// Returns the right padding of the view, plus space for the right
		/// Drawable if any.
		/// </remarks>
		public virtual int getCompoundPaddingRight()
		{
			android.widget.TextView.Drawables dr = mDrawables;
			if (dr == null || dr.mDrawableRight == null)
			{
				return mPaddingRight;
			}
			else
			{
				return mPaddingRight + dr.mDrawablePadding + dr.mDrawableSizeRight;
			}
		}

		/// <summary>
		/// Returns the start padding of the view, plus space for the start
		/// Drawable if any.
		/// </summary>
		/// <remarks>
		/// Returns the start padding of the view, plus space for the start
		/// Drawable if any.
		/// </remarks>
		/// <hide></hide>
		public virtual int getCompoundPaddingStart()
		{
			resolveDrawables();
			switch (getResolvedLayoutDirection())
			{
				case LAYOUT_DIRECTION_LTR:
				default:
				{
					return getCompoundPaddingLeft();
				}

				case LAYOUT_DIRECTION_RTL:
				{
					return getCompoundPaddingRight();
				}
			}
		}

		/// <summary>
		/// Returns the end padding of the view, plus space for the end
		/// Drawable if any.
		/// </summary>
		/// <remarks>
		/// Returns the end padding of the view, plus space for the end
		/// Drawable if any.
		/// </remarks>
		/// <hide></hide>
		public virtual int getCompoundPaddingEnd()
		{
			resolveDrawables();
			switch (getResolvedLayoutDirection())
			{
				case LAYOUT_DIRECTION_LTR:
				default:
				{
					return getCompoundPaddingRight();
				}

				case LAYOUT_DIRECTION_RTL:
				{
					return getCompoundPaddingLeft();
				}
			}
		}

		/// <summary>
		/// Returns the extended top padding of the view, including both the
		/// top Drawable if any and any extra space to keep more than maxLines
		/// of text from showing.
		/// </summary>
		/// <remarks>
		/// Returns the extended top padding of the view, including both the
		/// top Drawable if any and any extra space to keep more than maxLines
		/// of text from showing.  It is only valid to call this after measuring.
		/// </remarks>
		public virtual int getExtendedPaddingTop()
		{
			if (mMaxMode != LINES)
			{
				return getCompoundPaddingTop();
			}
			if (mLayout.getLineCount() <= mMaximum)
			{
				return getCompoundPaddingTop();
			}
			int top = getCompoundPaddingTop();
			int bottom = getCompoundPaddingBottom();
			int viewht = getHeight() - top - bottom;
			int layoutht = mLayout.getLineTop(mMaximum);
			if (layoutht >= viewht)
			{
				return top;
			}
			int gravity = mGravity & android.view.Gravity.VERTICAL_GRAVITY_MASK;
			if (gravity == android.view.Gravity.TOP)
			{
				return top;
			}
			else
			{
				if (gravity == android.view.Gravity.BOTTOM)
				{
					return top + viewht - layoutht;
				}
				else
				{
					// (gravity == Gravity.CENTER_VERTICAL)
					return top + (viewht - layoutht) / 2;
				}
			}
		}

		/// <summary>
		/// Returns the extended bottom padding of the view, including both the
		/// bottom Drawable if any and any extra space to keep more than maxLines
		/// of text from showing.
		/// </summary>
		/// <remarks>
		/// Returns the extended bottom padding of the view, including both the
		/// bottom Drawable if any and any extra space to keep more than maxLines
		/// of text from showing.  It is only valid to call this after measuring.
		/// </remarks>
		public virtual int getExtendedPaddingBottom()
		{
			if (mMaxMode != LINES)
			{
				return getCompoundPaddingBottom();
			}
			if (mLayout.getLineCount() <= mMaximum)
			{
				return getCompoundPaddingBottom();
			}
			int top = getCompoundPaddingTop();
			int bottom = getCompoundPaddingBottom();
			int viewht = getHeight() - top - bottom;
			int layoutht = mLayout.getLineTop(mMaximum);
			if (layoutht >= viewht)
			{
				return bottom;
			}
			int gravity = mGravity & android.view.Gravity.VERTICAL_GRAVITY_MASK;
			if (gravity == android.view.Gravity.TOP)
			{
				return bottom + viewht - layoutht;
			}
			else
			{
				if (gravity == android.view.Gravity.BOTTOM)
				{
					return bottom;
				}
				else
				{
					// (gravity == Gravity.CENTER_VERTICAL)
					return bottom + (viewht - layoutht) / 2;
				}
			}
		}

		/// <summary>
		/// Returns the total left padding of the view, including the left
		/// Drawable if any.
		/// </summary>
		/// <remarks>
		/// Returns the total left padding of the view, including the left
		/// Drawable if any.
		/// </remarks>
		public virtual int getTotalPaddingLeft()
		{
			return getCompoundPaddingLeft();
		}

		/// <summary>
		/// Returns the total right padding of the view, including the right
		/// Drawable if any.
		/// </summary>
		/// <remarks>
		/// Returns the total right padding of the view, including the right
		/// Drawable if any.
		/// </remarks>
		public virtual int getTotalPaddingRight()
		{
			return getCompoundPaddingRight();
		}

		/// <summary>
		/// Returns the total start padding of the view, including the start
		/// Drawable if any.
		/// </summary>
		/// <remarks>
		/// Returns the total start padding of the view, including the start
		/// Drawable if any.
		/// </remarks>
		/// <hide></hide>
		public virtual int getTotalPaddingStart()
		{
			return getCompoundPaddingStart();
		}

		/// <summary>
		/// Returns the total end padding of the view, including the end
		/// Drawable if any.
		/// </summary>
		/// <remarks>
		/// Returns the total end padding of the view, including the end
		/// Drawable if any.
		/// </remarks>
		/// <hide></hide>
		public virtual int getTotalPaddingEnd()
		{
			return getCompoundPaddingEnd();
		}

		/// <summary>
		/// Returns the total top padding of the view, including the top
		/// Drawable if any, the extra space to keep more than maxLines
		/// from showing, and the vertical offset for gravity, if any.
		/// </summary>
		/// <remarks>
		/// Returns the total top padding of the view, including the top
		/// Drawable if any, the extra space to keep more than maxLines
		/// from showing, and the vertical offset for gravity, if any.
		/// </remarks>
		public virtual int getTotalPaddingTop()
		{
			return getExtendedPaddingTop() + getVerticalOffset(true);
		}

		/// <summary>
		/// Returns the total bottom padding of the view, including the bottom
		/// Drawable if any, the extra space to keep more than maxLines
		/// from showing, and the vertical offset for gravity, if any.
		/// </summary>
		/// <remarks>
		/// Returns the total bottom padding of the view, including the bottom
		/// Drawable if any, the extra space to keep more than maxLines
		/// from showing, and the vertical offset for gravity, if any.
		/// </remarks>
		public virtual int getTotalPaddingBottom()
		{
			return getExtendedPaddingBottom() + getBottomVerticalOffset(true);
		}

		/// <summary>
		/// Sets the Drawables (if any) to appear to the left of, above,
		/// to the right of, and below the text.
		/// </summary>
		/// <remarks>
		/// Sets the Drawables (if any) to appear to the left of, above,
		/// to the right of, and below the text.  Use null if you do not
		/// want a Drawable there.  The Drawables must already have had
		/// <see cref="android.graphics.drawable.Drawable.setBounds(android.graphics.Rect)">android.graphics.drawable.Drawable.setBounds(android.graphics.Rect)
		/// 	</see>
		/// called.
		/// </remarks>
		/// <attr>ref android.R.styleable#TextView_drawableLeft</attr>
		/// <attr>ref android.R.styleable#TextView_drawableTop</attr>
		/// <attr>ref android.R.styleable#TextView_drawableRight</attr>
		/// <attr>ref android.R.styleable#TextView_drawableBottom</attr>
		public virtual void setCompoundDrawables(android.graphics.drawable.Drawable left, 
			android.graphics.drawable.Drawable top, android.graphics.drawable.Drawable right
			, android.graphics.drawable.Drawable bottom)
		{
			android.widget.TextView.Drawables dr = mDrawables;
			bool drawables = left != null || top != null || right != null || bottom != null;
			if (!drawables)
			{
				// Clearing drawables...  can we free the data structure?
				if (dr != null)
				{
					if (dr.mDrawablePadding == 0)
					{
						mDrawables = null;
					}
					else
					{
						// We need to retain the last set padding, so just clear
						// out all of the fields in the existing structure.
						if (dr.mDrawableLeft != null)
						{
							dr.mDrawableLeft.setCallback(null);
						}
						dr.mDrawableLeft = null;
						if (dr.mDrawableTop != null)
						{
							dr.mDrawableTop.setCallback(null);
						}
						dr.mDrawableTop = null;
						if (dr.mDrawableRight != null)
						{
							dr.mDrawableRight.setCallback(null);
						}
						dr.mDrawableRight = null;
						if (dr.mDrawableBottom != null)
						{
							dr.mDrawableBottom.setCallback(null);
						}
						dr.mDrawableBottom = null;
						dr.mDrawableSizeLeft = dr.mDrawableHeightLeft = 0;
						dr.mDrawableSizeRight = dr.mDrawableHeightRight = 0;
						dr.mDrawableSizeTop = dr.mDrawableWidthTop = 0;
						dr.mDrawableSizeBottom = dr.mDrawableWidthBottom = 0;
					}
				}
			}
			else
			{
				if (dr == null)
				{
					mDrawables = dr = new android.widget.TextView.Drawables(this);
				}
				if (dr.mDrawableLeft != left && dr.mDrawableLeft != null)
				{
					dr.mDrawableLeft.setCallback(null);
				}
				dr.mDrawableLeft = left;
				if (dr.mDrawableTop != top && dr.mDrawableTop != null)
				{
					dr.mDrawableTop.setCallback(null);
				}
				dr.mDrawableTop = top;
				if (dr.mDrawableRight != right && dr.mDrawableRight != null)
				{
					dr.mDrawableRight.setCallback(null);
				}
				dr.mDrawableRight = right;
				if (dr.mDrawableBottom != bottom && dr.mDrawableBottom != null)
				{
					dr.mDrawableBottom.setCallback(null);
				}
				dr.mDrawableBottom = bottom;
				android.graphics.Rect compoundRect = dr.mCompoundRect;
				int[] state;
				state = getDrawableState();
				if (left != null)
				{
					left.setState(state);
					left.copyBounds(compoundRect);
					left.setCallback(this);
					dr.mDrawableSizeLeft = compoundRect.width();
					dr.mDrawableHeightLeft = compoundRect.height();
				}
				else
				{
					dr.mDrawableSizeLeft = dr.mDrawableHeightLeft = 0;
				}
				if (right != null)
				{
					right.setState(state);
					right.copyBounds(compoundRect);
					right.setCallback(this);
					dr.mDrawableSizeRight = compoundRect.width();
					dr.mDrawableHeightRight = compoundRect.height();
				}
				else
				{
					dr.mDrawableSizeRight = dr.mDrawableHeightRight = 0;
				}
				if (top != null)
				{
					top.setState(state);
					top.copyBounds(compoundRect);
					top.setCallback(this);
					dr.mDrawableSizeTop = compoundRect.height();
					dr.mDrawableWidthTop = compoundRect.width();
				}
				else
				{
					dr.mDrawableSizeTop = dr.mDrawableWidthTop = 0;
				}
				if (bottom != null)
				{
					bottom.setState(state);
					bottom.copyBounds(compoundRect);
					bottom.setCallback(this);
					dr.mDrawableSizeBottom = compoundRect.height();
					dr.mDrawableWidthBottom = compoundRect.width();
				}
				else
				{
					dr.mDrawableSizeBottom = dr.mDrawableWidthBottom = 0;
				}
			}
			invalidate();
			requestLayout();
		}

		/// <summary>
		/// Sets the Drawables (if any) to appear to the left of, above,
		/// to the right of, and below the text.
		/// </summary>
		/// <remarks>
		/// Sets the Drawables (if any) to appear to the left of, above,
		/// to the right of, and below the text.  Use 0 if you do not
		/// want a Drawable there. The Drawables' bounds will be set to
		/// their intrinsic bounds.
		/// </remarks>
		/// <param name="left">Resource identifier of the left Drawable.</param>
		/// <param name="top">Resource identifier of the top Drawable.</param>
		/// <param name="right">Resource identifier of the right Drawable.</param>
		/// <param name="bottom">Resource identifier of the bottom Drawable.</param>
		/// <attr>ref android.R.styleable#TextView_drawableLeft</attr>
		/// <attr>ref android.R.styleable#TextView_drawableTop</attr>
		/// <attr>ref android.R.styleable#TextView_drawableRight</attr>
		/// <attr>ref android.R.styleable#TextView_drawableBottom</attr>
		public virtual void setCompoundDrawablesWithIntrinsicBounds(int left, int top, int
			 right, int bottom)
		{
			android.content.res.Resources resources = getContext().getResources();
			setCompoundDrawablesWithIntrinsicBounds(left != 0 ? resources.getDrawable(left) : 
				null, top != 0 ? resources.getDrawable(top) : null, right != 0 ? resources.getDrawable
				(right) : null, bottom != 0 ? resources.getDrawable(bottom) : null);
		}

		/// <summary>
		/// Sets the Drawables (if any) to appear to the left of, above,
		/// to the right of, and below the text.
		/// </summary>
		/// <remarks>
		/// Sets the Drawables (if any) to appear to the left of, above,
		/// to the right of, and below the text.  Use null if you do not
		/// want a Drawable there. The Drawables' bounds will be set to
		/// their intrinsic bounds.
		/// </remarks>
		/// <attr>ref android.R.styleable#TextView_drawableLeft</attr>
		/// <attr>ref android.R.styleable#TextView_drawableTop</attr>
		/// <attr>ref android.R.styleable#TextView_drawableRight</attr>
		/// <attr>ref android.R.styleable#TextView_drawableBottom</attr>
		public virtual void setCompoundDrawablesWithIntrinsicBounds(android.graphics.drawable.Drawable
			 left, android.graphics.drawable.Drawable top, android.graphics.drawable.Drawable
			 right, android.graphics.drawable.Drawable bottom)
		{
			if (left != null)
			{
				left.setBounds(0, 0, left.getIntrinsicWidth(), left.getIntrinsicHeight());
			}
			if (right != null)
			{
				right.setBounds(0, 0, right.getIntrinsicWidth(), right.getIntrinsicHeight());
			}
			if (top != null)
			{
				top.setBounds(0, 0, top.getIntrinsicWidth(), top.getIntrinsicHeight());
			}
			if (bottom != null)
			{
				bottom.setBounds(0, 0, bottom.getIntrinsicWidth(), bottom.getIntrinsicHeight());
			}
			setCompoundDrawables(left, top, right, bottom);
		}

		/// <summary>
		/// Sets the Drawables (if any) to appear to the start of, above,
		/// to the end of, and below the text.
		/// </summary>
		/// <remarks>
		/// Sets the Drawables (if any) to appear to the start of, above,
		/// to the end of, and below the text.  Use null if you do not
		/// want a Drawable there.  The Drawables must already have had
		/// <see cref="android.graphics.drawable.Drawable.setBounds(android.graphics.Rect)">android.graphics.drawable.Drawable.setBounds(android.graphics.Rect)
		/// 	</see>
		/// called.
		/// </remarks>
		/// <attr>ref android.R.styleable#TextView_drawableStart</attr>
		/// <attr>ref android.R.styleable#TextView_drawableTop</attr>
		/// <attr>ref android.R.styleable#TextView_drawableEnd</attr>
		/// <attr>ref android.R.styleable#TextView_drawableBottom</attr>
		/// <hide></hide>
		public virtual void setCompoundDrawablesRelative(android.graphics.drawable.Drawable
			 start, android.graphics.drawable.Drawable top, android.graphics.drawable.Drawable
			 end, android.graphics.drawable.Drawable bottom)
		{
			android.widget.TextView.Drawables dr = mDrawables;
			bool drawables = start != null || top != null || end != null || bottom != null;
			if (!drawables)
			{
				// Clearing drawables...  can we free the data structure?
				if (dr != null)
				{
					if (dr.mDrawablePadding == 0)
					{
						mDrawables = null;
					}
					else
					{
						// We need to retain the last set padding, so just clear
						// out all of the fields in the existing structure.
						if (dr.mDrawableStart != null)
						{
							dr.mDrawableStart.setCallback(null);
						}
						dr.mDrawableStart = null;
						if (dr.mDrawableTop != null)
						{
							dr.mDrawableTop.setCallback(null);
						}
						dr.mDrawableTop = null;
						if (dr.mDrawableEnd != null)
						{
							dr.mDrawableEnd.setCallback(null);
						}
						dr.mDrawableEnd = null;
						if (dr.mDrawableBottom != null)
						{
							dr.mDrawableBottom.setCallback(null);
						}
						dr.mDrawableBottom = null;
						dr.mDrawableSizeStart = dr.mDrawableHeightStart = 0;
						dr.mDrawableSizeEnd = dr.mDrawableHeightEnd = 0;
						dr.mDrawableSizeTop = dr.mDrawableWidthTop = 0;
						dr.mDrawableSizeBottom = dr.mDrawableWidthBottom = 0;
					}
				}
			}
			else
			{
				if (dr == null)
				{
					mDrawables = dr = new android.widget.TextView.Drawables(this);
				}
				if (dr.mDrawableStart != start && dr.mDrawableStart != null)
				{
					dr.mDrawableStart.setCallback(null);
				}
				dr.mDrawableStart = start;
				if (dr.mDrawableTop != top && dr.mDrawableTop != null)
				{
					dr.mDrawableTop.setCallback(null);
				}
				dr.mDrawableTop = top;
				if (dr.mDrawableEnd != end && dr.mDrawableEnd != null)
				{
					dr.mDrawableEnd.setCallback(null);
				}
				dr.mDrawableEnd = end;
				if (dr.mDrawableBottom != bottom && dr.mDrawableBottom != null)
				{
					dr.mDrawableBottom.setCallback(null);
				}
				dr.mDrawableBottom = bottom;
				android.graphics.Rect compoundRect = dr.mCompoundRect;
				int[] state;
				state = getDrawableState();
				if (start != null)
				{
					start.setState(state);
					start.copyBounds(compoundRect);
					start.setCallback(this);
					dr.mDrawableSizeStart = compoundRect.width();
					dr.mDrawableHeightStart = compoundRect.height();
				}
				else
				{
					dr.mDrawableSizeStart = dr.mDrawableHeightStart = 0;
				}
				if (end != null)
				{
					end.setState(state);
					end.copyBounds(compoundRect);
					end.setCallback(this);
					dr.mDrawableSizeEnd = compoundRect.width();
					dr.mDrawableHeightEnd = compoundRect.height();
				}
				else
				{
					dr.mDrawableSizeEnd = dr.mDrawableHeightEnd = 0;
				}
				if (top != null)
				{
					top.setState(state);
					top.copyBounds(compoundRect);
					top.setCallback(this);
					dr.mDrawableSizeTop = compoundRect.height();
					dr.mDrawableWidthTop = compoundRect.width();
				}
				else
				{
					dr.mDrawableSizeTop = dr.mDrawableWidthTop = 0;
				}
				if (bottom != null)
				{
					bottom.setState(state);
					bottom.copyBounds(compoundRect);
					bottom.setCallback(this);
					dr.mDrawableSizeBottom = compoundRect.height();
					dr.mDrawableWidthBottom = compoundRect.width();
				}
				else
				{
					dr.mDrawableSizeBottom = dr.mDrawableWidthBottom = 0;
				}
			}
			resolveDrawables();
			invalidate();
			requestLayout();
		}

		/// <summary>
		/// Sets the Drawables (if any) to appear to the start of, above,
		/// to the end of, and below the text.
		/// </summary>
		/// <remarks>
		/// Sets the Drawables (if any) to appear to the start of, above,
		/// to the end of, and below the text.  Use 0 if you do not
		/// want a Drawable there. The Drawables' bounds will be set to
		/// their intrinsic bounds.
		/// </remarks>
		/// <param name="start">Resource identifier of the start Drawable.</param>
		/// <param name="top">Resource identifier of the top Drawable.</param>
		/// <param name="end">Resource identifier of the end Drawable.</param>
		/// <param name="bottom">Resource identifier of the bottom Drawable.</param>
		/// <attr>ref android.R.styleable#TextView_drawableStart</attr>
		/// <attr>ref android.R.styleable#TextView_drawableTop</attr>
		/// <attr>ref android.R.styleable#TextView_drawableEnd</attr>
		/// <attr>ref android.R.styleable#TextView_drawableBottom</attr>
		/// <hide></hide>
		public virtual void setCompoundDrawablesRelativeWithIntrinsicBounds(int start, int
			 top, int end, int bottom)
		{
			resetResolvedDrawables();
			android.content.res.Resources resources = getContext().getResources();
			setCompoundDrawablesRelativeWithIntrinsicBounds(start != 0 ? resources.getDrawable
				(start) : null, top != 0 ? resources.getDrawable(top) : null, end != 0 ? resources
				.getDrawable(end) : null, bottom != 0 ? resources.getDrawable(bottom) : null);
		}

		/// <summary>
		/// Sets the Drawables (if any) to appear to the start of, above,
		/// to the end of, and below the text.
		/// </summary>
		/// <remarks>
		/// Sets the Drawables (if any) to appear to the start of, above,
		/// to the end of, and below the text.  Use null if you do not
		/// want a Drawable there. The Drawables' bounds will be set to
		/// their intrinsic bounds.
		/// </remarks>
		/// <attr>ref android.R.styleable#TextView_drawableStart</attr>
		/// <attr>ref android.R.styleable#TextView_drawableTop</attr>
		/// <attr>ref android.R.styleable#TextView_drawableEnd</attr>
		/// <attr>ref android.R.styleable#TextView_drawableBottom</attr>
		/// <hide></hide>
		public virtual void setCompoundDrawablesRelativeWithIntrinsicBounds(android.graphics.drawable.Drawable
			 start, android.graphics.drawable.Drawable top, android.graphics.drawable.Drawable
			 end, android.graphics.drawable.Drawable bottom)
		{
			resetResolvedDrawables();
			if (start != null)
			{
				start.setBounds(0, 0, start.getIntrinsicWidth(), start.getIntrinsicHeight());
			}
			if (end != null)
			{
				end.setBounds(0, 0, end.getIntrinsicWidth(), end.getIntrinsicHeight());
			}
			if (top != null)
			{
				top.setBounds(0, 0, top.getIntrinsicWidth(), top.getIntrinsicHeight());
			}
			if (bottom != null)
			{
				bottom.setBounds(0, 0, bottom.getIntrinsicWidth(), bottom.getIntrinsicHeight());
			}
			setCompoundDrawablesRelative(start, top, end, bottom);
		}

		/// <summary>Returns drawables for the left, top, right, and bottom borders.</summary>
		/// <remarks>Returns drawables for the left, top, right, and bottom borders.</remarks>
		public virtual android.graphics.drawable.Drawable[] getCompoundDrawables()
		{
			android.widget.TextView.Drawables dr = mDrawables;
			if (dr != null)
			{
				return new android.graphics.drawable.Drawable[] { dr.mDrawableLeft, dr.mDrawableTop
					, dr.mDrawableRight, dr.mDrawableBottom };
			}
			else
			{
				return new android.graphics.drawable.Drawable[] { null, null, null, null };
			}
		}

		/// <summary>Returns drawables for the start, top, end, and bottom borders.</summary>
		/// <remarks>Returns drawables for the start, top, end, and bottom borders.</remarks>
		/// <hide></hide>
		public virtual android.graphics.drawable.Drawable[] getCompoundDrawablesRelative(
			)
		{
			android.widget.TextView.Drawables dr = mDrawables;
			if (dr != null)
			{
				return new android.graphics.drawable.Drawable[] { dr.mDrawableStart, dr.mDrawableTop
					, dr.mDrawableEnd, dr.mDrawableBottom };
			}
			else
			{
				return new android.graphics.drawable.Drawable[] { null, null, null, null };
			}
		}

		/// <summary>
		/// Sets the size of the padding between the compound drawables and
		/// the text.
		/// </summary>
		/// <remarks>
		/// Sets the size of the padding between the compound drawables and
		/// the text.
		/// </remarks>
		/// <attr>ref android.R.styleable#TextView_drawablePadding</attr>
		public virtual void setCompoundDrawablePadding(int pad)
		{
			android.widget.TextView.Drawables dr = mDrawables;
			if (pad == 0)
			{
				if (dr != null)
				{
					dr.mDrawablePadding = pad;
				}
			}
			else
			{
				if (dr == null)
				{
					mDrawables = dr = new android.widget.TextView.Drawables(this);
				}
				dr.mDrawablePadding = pad;
			}
			invalidate();
			requestLayout();
		}

		/// <summary>Returns the padding between the compound drawables and the text.</summary>
		/// <remarks>Returns the padding between the compound drawables and the text.</remarks>
		public virtual int getCompoundDrawablePadding()
		{
			android.widget.TextView.Drawables dr = mDrawables;
			return dr != null ? dr.mDrawablePadding : 0;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void setPadding(int left, int top, int right, int bottom)
		{
			if (left != mPaddingLeft || right != mPaddingRight || top != mPaddingTop || bottom
				 != mPaddingBottom)
			{
				nullLayouts();
			}
			// the super call will requestLayout()
			base.setPadding(left, top, right, bottom);
			invalidate();
		}

		/// <summary>Gets the autolink mask of the text.</summary>
		/// <remarks>
		/// Gets the autolink mask of the text.  See
		/// <see cref="android.text.util.Linkify.ALL">Linkify.ALL</see>
		/// and peers for
		/// possible values.
		/// </remarks>
		/// <attr>ref android.R.styleable#TextView_autoLink</attr>
		public int getAutoLinkMask()
		{
			return mAutoLinkMask;
		}

		/// <summary>
		/// Sets the text color, size, style, hint color, and highlight color
		/// from the specified TextAppearance resource.
		/// </summary>
		/// <remarks>
		/// Sets the text color, size, style, hint color, and highlight color
		/// from the specified TextAppearance resource.
		/// </remarks>
		public virtual void setTextAppearance(android.content.Context context, int resid)
		{
			android.content.res.TypedArray appearance = context.obtainStyledAttributes(resid, 
				android.@internal.R.styleable.TextAppearance);
			int color;
			android.content.res.ColorStateList colors;
			int ts;
			color = appearance.getColor(android.@internal.R.styleable.TextAppearance_textColorHighlight
				, 0);
			if (color != 0)
			{
				setHighlightColor(color);
			}
			colors = appearance.getColorStateList(android.@internal.R.styleable.TextAppearance_textColor
				);
			if (colors != null)
			{
				setTextColor(colors);
			}
			ts = appearance.getDimensionPixelSize(android.@internal.R.styleable.TextAppearance_textSize
				, 0);
			if (ts != 0)
			{
				setRawTextSize(ts);
			}
			colors = appearance.getColorStateList(android.@internal.R.styleable.TextAppearance_textColorHint
				);
			if (colors != null)
			{
				setHintTextColor(colors);
			}
			colors = appearance.getColorStateList(android.@internal.R.styleable.TextAppearance_textColorLink
				);
			if (colors != null)
			{
				setLinkTextColor(colors);
			}
			int typefaceIndex;
			int styleIndex;
			typefaceIndex = appearance.getInt(android.@internal.R.styleable.TextAppearance_typeface
				, -1);
			styleIndex = appearance.getInt(android.@internal.R.styleable.TextAppearance_textStyle
				, -1);
			setTypefaceByIndex(typefaceIndex, styleIndex);
			if (appearance.getBoolean(android.@internal.R.styleable.TextAppearance_textAllCaps
				, false))
			{
				setTransformationMethod(new android.text.method.AllCapsTransformationMethod(getContext
					()));
			}
			appearance.recycle();
		}

		/// <returns>the size (in pixels) of the default text size in this TextView.</returns>
		public virtual float getTextSize()
		{
			return mTextPaint.getTextSize();
		}

		/// <summary>
		/// Set the default text size to the given value, interpreted as "scaled
		/// pixel" units.
		/// </summary>
		/// <remarks>
		/// Set the default text size to the given value, interpreted as "scaled
		/// pixel" units.  This size is adjusted based on the current density and
		/// user font size preference.
		/// </remarks>
		/// <param name="size">The scaled pixel size.</param>
		/// <attr>ref android.R.styleable#TextView_textSize</attr>
		[android.view.RemotableViewMethod]
		public virtual void setTextSize(float size)
		{
			setTextSize(android.util.TypedValue.COMPLEX_UNIT_SP, size);
		}

		/// <summary>Set the default text size to a given unit and value.</summary>
		/// <remarks>
		/// Set the default text size to a given unit and value.  See
		/// <see cref="android.util.TypedValue">android.util.TypedValue</see>
		/// for the possible dimension units.
		/// </remarks>
		/// <param name="unit">The desired dimension unit.</param>
		/// <param name="size">The desired size in the given units.</param>
		/// <attr>ref android.R.styleable#TextView_textSize</attr>
		public virtual void setTextSize(int unit, float size)
		{
			android.content.Context c = getContext();
			android.content.res.Resources r;
			if (c == null)
			{
				r = android.content.res.Resources.getSystem();
			}
			else
			{
				r = c.getResources();
			}
			setRawTextSize(android.util.TypedValue.applyDimension(unit, size, r.getDisplayMetrics
				()));
		}

		private void setRawTextSize(float size)
		{
			if (size != mTextPaint.getTextSize())
			{
				mTextPaint.setTextSize(size);
				if (mLayout != null)
				{
					nullLayouts();
					requestLayout();
					invalidate();
				}
			}
		}

		/// <returns>
		/// the extent by which text is currently being stretched
		/// horizontally.  This will usually be 1.
		/// </returns>
		public virtual float getTextScaleX()
		{
			return mTextPaint.getTextScaleX();
		}

		/// <summary>Sets the extent by which text should be stretched horizontally.</summary>
		/// <remarks>Sets the extent by which text should be stretched horizontally.</remarks>
		/// <attr>ref android.R.styleable#TextView_textScaleX</attr>
		[android.view.RemotableViewMethod]
		public virtual void setTextScaleX(float size)
		{
			if (size != mTextPaint.getTextScaleX())
			{
				mUserSetTextScaleX = true;
				mTextPaint.setTextScaleX(size);
				if (mLayout != null)
				{
					nullLayouts();
					requestLayout();
					invalidate();
				}
			}
		}

		/// <summary>Sets the typeface and style in which the text should be displayed.</summary>
		/// <remarks>
		/// Sets the typeface and style in which the text should be displayed.
		/// Note that not all Typeface families actually have bold and italic
		/// variants, so you may need to use
		/// <see cref="setTypeface(android.graphics.Typeface, int)">setTypeface(android.graphics.Typeface, int)
		/// 	</see>
		/// to get the appearance
		/// that you actually want.
		/// </remarks>
		/// <attr>ref android.R.styleable#TextView_typeface</attr>
		/// <attr>ref android.R.styleable#TextView_textStyle</attr>
		public virtual void setTypeface(android.graphics.Typeface tf)
		{
			if (mTextPaint.getTypeface() != tf)
			{
				mTextPaint.setTypeface(tf);
				if (mLayout != null)
				{
					nullLayouts();
					requestLayout();
					invalidate();
				}
			}
		}

		/// <returns>
		/// the current typeface and style in which the text is being
		/// displayed.
		/// </returns>
		public virtual android.graphics.Typeface getTypeface()
		{
			return mTextPaint.getTypeface();
		}

		/// <summary>
		/// Sets the text color for all the states (normal, selected,
		/// focused) to be this color.
		/// </summary>
		/// <remarks>
		/// Sets the text color for all the states (normal, selected,
		/// focused) to be this color.
		/// </remarks>
		/// <attr>ref android.R.styleable#TextView_textColor</attr>
		[android.view.RemotableViewMethod]
		public virtual void setTextColor(int color)
		{
			mTextColor = android.content.res.ColorStateList.valueOf(color);
			updateTextColors();
		}

		/// <summary>Sets the text color.</summary>
		/// <remarks>Sets the text color.</remarks>
		/// <attr>ref android.R.styleable#TextView_textColor</attr>
		public virtual void setTextColor(android.content.res.ColorStateList colors)
		{
			if (colors == null)
			{
				throw new System.ArgumentNullException();
			}
			mTextColor = colors;
			updateTextColors();
		}

		/// <summary>Return the set of text colors.</summary>
		/// <remarks>Return the set of text colors.</remarks>
		/// <returns>Returns the set of text colors.</returns>
		public android.content.res.ColorStateList getTextColors()
		{
			return mTextColor;
		}

		/// <summary><p>Return the current color selected for normal text.</p></summary>
		/// <returns>Returns the current text color.</returns>
		public int getCurrentTextColor()
		{
			return mCurTextColor;
		}

		/// <summary>Sets the color used to display the selection highlight.</summary>
		/// <remarks>Sets the color used to display the selection highlight.</remarks>
		/// <attr>ref android.R.styleable#TextView_textColorHighlight</attr>
		[android.view.RemotableViewMethod]
		public virtual void setHighlightColor(int color)
		{
			if (mHighlightColor != color)
			{
				mHighlightColor = color;
				invalidate();
			}
		}

		/// <summary>
		/// Gives the text a shadow of the specified radius and color, the specified
		/// distance from its normal position.
		/// </summary>
		/// <remarks>
		/// Gives the text a shadow of the specified radius and color, the specified
		/// distance from its normal position.
		/// </remarks>
		/// <attr>ref android.R.styleable#TextView_shadowColor</attr>
		/// <attr>ref android.R.styleable#TextView_shadowDx</attr>
		/// <attr>ref android.R.styleable#TextView_shadowDy</attr>
		/// <attr>ref android.R.styleable#TextView_shadowRadius</attr>
		public virtual void setShadowLayer(float radius, float dx, float dy, int color)
		{
			mTextPaint.setShadowLayer(radius, dx, dy, color);
			mShadowRadius = radius;
			mShadowDx = dx;
			mShadowDy = dy;
			invalidate();
		}

		/// <returns>
		/// the base paint used for the text.  Please use this only to
		/// consult the Paint's properties and not to change them.
		/// </returns>
		public virtual android.text.TextPaint getPaint()
		{
			return mTextPaint;
		}

		/// <summary>Sets the autolink mask of the text.</summary>
		/// <remarks>
		/// Sets the autolink mask of the text.  See
		/// <see cref="android.text.util.Linkify.ALL">Linkify.ALL</see>
		/// and peers for
		/// possible values.
		/// </remarks>
		/// <attr>ref android.R.styleable#TextView_autoLink</attr>
		[android.view.RemotableViewMethod]
		public void setAutoLinkMask(int mask)
		{
			mAutoLinkMask = mask;
		}

		/// <summary>
		/// Sets whether the movement method will automatically be set to
		/// <see cref="android.text.method.LinkMovementMethod">android.text.method.LinkMovementMethod
		/// 	</see>
		/// if
		/// <see cref="setAutoLinkMask(int)">setAutoLinkMask(int)</see>
		/// has been
		/// set to nonzero and links are detected in
		/// <see cref="setText(java.lang.CharSequence)">setText(java.lang.CharSequence)</see>
		/// .
		/// The default is true.
		/// </summary>
		/// <attr>ref android.R.styleable#TextView_linksClickable</attr>
		[android.view.RemotableViewMethod]
		public void setLinksClickable(bool whether)
		{
			mLinksClickable = whether;
		}

		/// <summary>
		/// Returns whether the movement method will automatically be set to
		/// <see cref="android.text.method.LinkMovementMethod">android.text.method.LinkMovementMethod
		/// 	</see>
		/// if
		/// <see cref="setAutoLinkMask(int)">setAutoLinkMask(int)</see>
		/// has been
		/// set to nonzero and links are detected in
		/// <see cref="setText(java.lang.CharSequence)">setText(java.lang.CharSequence)</see>
		/// .
		/// The default is true.
		/// </summary>
		/// <attr>ref android.R.styleable#TextView_linksClickable</attr>
		public bool getLinksClickable()
		{
			return mLinksClickable;
		}

		/// <summary>
		/// Returns the list of URLSpans attached to the text
		/// (by
		/// <see cref="android.text.util.Linkify">android.text.util.Linkify</see>
		/// or otherwise) if any.  You can call
		/// <see cref="android.text.style.URLSpan.getURL()">android.text.style.URLSpan.getURL()
		/// 	</see>
		/// on them to find where they link to
		/// or use
		/// <see cref="android.text.Spanned.getSpanStart(object)">android.text.Spanned.getSpanStart(object)
		/// 	</see>
		/// and
		/// <see cref="android.text.Spanned.getSpanEnd(object)">android.text.Spanned.getSpanEnd(object)
		/// 	</see>
		/// to find the region of the text they are attached to.
		/// </summary>
		public virtual android.text.style.URLSpan[] getUrls()
		{
			if (mText is android.text.Spanned)
			{
				return ((android.text.Spanned)mText).getSpans<android.text.style.URLSpan>(0, mText
					.Length);
			}
			else
			{
				return new android.text.style.URLSpan[0];
			}
		}

		/// <summary>Sets the color of the hint text.</summary>
		/// <remarks>Sets the color of the hint text.</remarks>
		/// <attr>ref android.R.styleable#TextView_textColorHint</attr>
		[android.view.RemotableViewMethod]
		public void setHintTextColor(int color)
		{
			mHintTextColor = android.content.res.ColorStateList.valueOf(color);
			updateTextColors();
		}

		/// <summary>Sets the color of the hint text.</summary>
		/// <remarks>Sets the color of the hint text.</remarks>
		/// <attr>ref android.R.styleable#TextView_textColorHint</attr>
		public void setHintTextColor(android.content.res.ColorStateList colors)
		{
			mHintTextColor = colors;
			updateTextColors();
		}

		/// <summary><p>Return the color used to paint the hint text.</p></summary>
		/// <returns>Returns the list of hint text colors.</returns>
		public android.content.res.ColorStateList getHintTextColors()
		{
			return mHintTextColor;
		}

		/// <summary><p>Return the current color selected to paint the hint text.</p></summary>
		/// <returns>Returns the current hint text color.</returns>
		public int getCurrentHintTextColor()
		{
			return mHintTextColor != null ? mCurHintTextColor : mCurTextColor;
		}

		/// <summary>Sets the color of links in the text.</summary>
		/// <remarks>Sets the color of links in the text.</remarks>
		/// <attr>ref android.R.styleable#TextView_textColorLink</attr>
		[android.view.RemotableViewMethod]
		public void setLinkTextColor(int color)
		{
			mLinkTextColor = android.content.res.ColorStateList.valueOf(color);
			updateTextColors();
		}

		/// <summary>Sets the color of links in the text.</summary>
		/// <remarks>Sets the color of links in the text.</remarks>
		/// <attr>ref android.R.styleable#TextView_textColorLink</attr>
		public void setLinkTextColor(android.content.res.ColorStateList colors)
		{
			mLinkTextColor = colors;
			updateTextColors();
		}

		/// <summary><p>Returns the color used to paint links in the text.</p></summary>
		/// <returns>Returns the list of link text colors.</returns>
		public android.content.res.ColorStateList getLinkTextColors()
		{
			return mLinkTextColor;
		}

		/// <summary>
		/// Sets the horizontal alignment of the text and the
		/// vertical gravity that will be used when there is extra space
		/// in the TextView beyond what is required for the text itself.
		/// </summary>
		/// <remarks>
		/// Sets the horizontal alignment of the text and the
		/// vertical gravity that will be used when there is extra space
		/// in the TextView beyond what is required for the text itself.
		/// </remarks>
		/// <seealso cref="android.view.Gravity">android.view.Gravity</seealso>
		/// <attr>ref android.R.styleable#TextView_gravity</attr>
		public virtual void setGravity(int gravity)
		{
			if ((gravity & android.view.Gravity.RELATIVE_HORIZONTAL_GRAVITY_MASK) == 0)
			{
				gravity |= android.view.Gravity.START;
			}
			if ((gravity & android.view.Gravity.VERTICAL_GRAVITY_MASK) == 0)
			{
				gravity |= android.view.Gravity.TOP;
			}
			bool newLayout = false;
			if ((gravity & android.view.Gravity.RELATIVE_HORIZONTAL_GRAVITY_MASK) != (mGravity
				 & android.view.Gravity.RELATIVE_HORIZONTAL_GRAVITY_MASK))
			{
				newLayout = true;
			}
			if (gravity != mGravity)
			{
				invalidate();
				mLayoutAlignment = null;
			}
			mGravity = gravity;
			if (mLayout != null && newLayout)
			{
				// XXX this is heavy-handed because no actual content changes.
				int want = mLayout.getWidth();
				int hintWant = mHintLayout == null ? 0 : mHintLayout.getWidth();
				makeNewLayout(want, hintWant, UNKNOWN_BORING, UNKNOWN_BORING, mRight - mLeft - getCompoundPaddingLeft
					() - getCompoundPaddingRight(), true);
			}
		}

		/// <summary>Returns the horizontal and vertical alignment of this TextView.</summary>
		/// <remarks>Returns the horizontal and vertical alignment of this TextView.</remarks>
		/// <seealso cref="android.view.Gravity">android.view.Gravity</seealso>
		/// <attr>ref android.R.styleable#TextView_gravity</attr>
		public virtual int getGravity()
		{
			return mGravity;
		}

		/// <returns>the flags on the Paint being used to display the text.</returns>
		/// <seealso cref="android.graphics.Paint.getFlags()">android.graphics.Paint.getFlags()
		/// 	</seealso>
		public virtual int getPaintFlags()
		{
			return mTextPaint.getFlags();
		}

		/// <summary>
		/// Sets flags on the Paint being used to display the text and
		/// reflows the text if they are different from the old flags.
		/// </summary>
		/// <remarks>
		/// Sets flags on the Paint being used to display the text and
		/// reflows the text if they are different from the old flags.
		/// </remarks>
		/// <seealso cref="android.graphics.Paint.setFlags(int)">android.graphics.Paint.setFlags(int)
		/// 	</seealso>
		[android.view.RemotableViewMethod]
		public virtual void setPaintFlags(int flags)
		{
			if (mTextPaint.getFlags() != flags)
			{
				mTextPaint.setFlags(flags);
				if (mLayout != null)
				{
					nullLayouts();
					requestLayout();
					invalidate();
				}
			}
		}

		/// <summary>
		/// Sets whether the text should be allowed to be wider than the
		/// View is.
		/// </summary>
		/// <remarks>
		/// Sets whether the text should be allowed to be wider than the
		/// View is.  If false, it will be wrapped to the width of the View.
		/// </remarks>
		/// <attr>ref android.R.styleable#TextView_scrollHorizontally</attr>
		public virtual void setHorizontallyScrolling(bool whether)
		{
			if (mHorizontallyScrolling != whether)
			{
				mHorizontallyScrolling = whether;
				if (mLayout != null)
				{
					nullLayouts();
					requestLayout();
					invalidate();
				}
			}
		}

		/// <summary>Makes the TextView at least this many lines tall.</summary>
		/// <remarks>
		/// Makes the TextView at least this many lines tall.
		/// Setting this value overrides any other (minimum) height setting. A single line TextView will
		/// set this value to 1.
		/// </remarks>
		/// <attr>ref android.R.styleable#TextView_minLines</attr>
		[android.view.RemotableViewMethod]
		public virtual void setMinLines(int minlines)
		{
			mMinimum = minlines;
			mMinMode = LINES;
			requestLayout();
			invalidate();
		}

		/// <summary>Makes the TextView at least this many pixels tall.</summary>
		/// <remarks>
		/// Makes the TextView at least this many pixels tall.
		/// Setting this value overrides any other (minimum) number of lines setting.
		/// </remarks>
		/// <attr>ref android.R.styleable#TextView_minHeight</attr>
		[android.view.RemotableViewMethod]
		public virtual void setMinHeight(int minHeight)
		{
			mMinimum = minHeight;
			mMinMode = PIXELS;
			requestLayout();
			invalidate();
		}

		/// <summary>Makes the TextView at most this many lines tall.</summary>
		/// <remarks>
		/// Makes the TextView at most this many lines tall.
		/// Setting this value overrides any other (maximum) height setting.
		/// </remarks>
		/// <attr>ref android.R.styleable#TextView_maxLines</attr>
		[android.view.RemotableViewMethod]
		public virtual void setMaxLines(int maxlines)
		{
			mMaximum = maxlines;
			mMaxMode = LINES;
			requestLayout();
			invalidate();
		}

		/// <summary>Makes the TextView at most this many pixels tall.</summary>
		/// <remarks>
		/// Makes the TextView at most this many pixels tall.  This option is mutually exclusive with the
		/// <see cref="setMaxLines(int)">setMaxLines(int)</see>
		/// method.
		/// Setting this value overrides any other (maximum) number of lines setting.
		/// </remarks>
		/// <attr>ref android.R.styleable#TextView_maxHeight</attr>
		[android.view.RemotableViewMethod]
		public virtual void setMaxHeight(int maxHeight)
		{
			mMaximum = maxHeight;
			mMaxMode = PIXELS;
			requestLayout();
			invalidate();
		}

		/// <summary>Makes the TextView exactly this many lines tall.</summary>
		/// <remarks>
		/// Makes the TextView exactly this many lines tall.
		/// Note that setting this value overrides any other (minimum / maximum) number of lines or
		/// height setting. A single line TextView will set this value to 1.
		/// </remarks>
		/// <attr>ref android.R.styleable#TextView_lines</attr>
		[android.view.RemotableViewMethod]
		public virtual void setLines(int lines)
		{
			mMaximum = mMinimum = lines;
			mMaxMode = mMinMode = LINES;
			requestLayout();
			invalidate();
		}

		/// <summary>Makes the TextView exactly this many pixels tall.</summary>
		/// <remarks>
		/// Makes the TextView exactly this many pixels tall.
		/// You could do the same thing by specifying this number in the
		/// LayoutParams.
		/// Note that setting this value overrides any other (minimum / maximum) number of lines or
		/// height setting.
		/// </remarks>
		/// <attr>ref android.R.styleable#TextView_height</attr>
		[android.view.RemotableViewMethod]
		public virtual void setHeight(int pixels)
		{
			mMaximum = mMinimum = pixels;
			mMaxMode = mMinMode = PIXELS;
			requestLayout();
			invalidate();
		}

		/// <summary>Makes the TextView at least this many ems wide</summary>
		/// <attr>ref android.R.styleable#TextView_minEms</attr>
		[android.view.RemotableViewMethod]
		public virtual void setMinEms(int minems)
		{
			mMinWidth = minems;
			mMinWidthMode = EMS;
			requestLayout();
			invalidate();
		}

		/// <summary>Makes the TextView at least this many pixels wide</summary>
		/// <attr>ref android.R.styleable#TextView_minWidth</attr>
		[android.view.RemotableViewMethod]
		public virtual void setMinWidth(int minpixels)
		{
			mMinWidth = minpixels;
			mMinWidthMode = PIXELS;
			requestLayout();
			invalidate();
		}

		/// <summary>Makes the TextView at most this many ems wide</summary>
		/// <attr>ref android.R.styleable#TextView_maxEms</attr>
		[android.view.RemotableViewMethod]
		public virtual void setMaxEms(int maxems)
		{
			mMaxWidth = maxems;
			mMaxWidthMode = EMS;
			requestLayout();
			invalidate();
		}

		/// <summary>Makes the TextView at most this many pixels wide</summary>
		/// <attr>ref android.R.styleable#TextView_maxWidth</attr>
		[android.view.RemotableViewMethod]
		public virtual void setMaxWidth(int maxpixels)
		{
			mMaxWidth = maxpixels;
			mMaxWidthMode = PIXELS;
			requestLayout();
			invalidate();
		}

		/// <summary>Makes the TextView exactly this many ems wide</summary>
		/// <attr>ref android.R.styleable#TextView_ems</attr>
		[android.view.RemotableViewMethod]
		public virtual void setEms(int ems)
		{
			mMaxWidth = mMinWidth = ems;
			mMaxWidthMode = mMinWidthMode = EMS;
			requestLayout();
			invalidate();
		}

		/// <summary>Makes the TextView exactly this many pixels wide.</summary>
		/// <remarks>
		/// Makes the TextView exactly this many pixels wide.
		/// You could do the same thing by specifying this number in the
		/// LayoutParams.
		/// </remarks>
		/// <attr>ref android.R.styleable#TextView_width</attr>
		[android.view.RemotableViewMethod]
		public virtual void setWidth(int pixels)
		{
			mMaxWidth = mMinWidth = pixels;
			mMaxWidthMode = mMinWidthMode = PIXELS;
			requestLayout();
			invalidate();
		}

		/// <summary>Sets line spacing for this TextView.</summary>
		/// <remarks>
		/// Sets line spacing for this TextView.  Each line will have its height
		/// multiplied by <code>mult</code> and have <code>add</code> added to it.
		/// </remarks>
		/// <attr>ref android.R.styleable#TextView_lineSpacingExtra</attr>
		/// <attr>ref android.R.styleable#TextView_lineSpacingMultiplier</attr>
		public virtual void setLineSpacing(float add, float mult)
		{
			if (mSpacingAdd != add || mSpacingMult != mult)
			{
				mSpacingAdd = add;
				mSpacingMult = mult;
				if (mLayout != null)
				{
					nullLayouts();
					requestLayout();
					invalidate();
				}
			}
		}

		/// <summary>
		/// Convenience method: Append the specified text to the TextView's
		/// display buffer, upgrading it to BufferType.EDITABLE if it was
		/// not already editable.
		/// </summary>
		/// <remarks>
		/// Convenience method: Append the specified text to the TextView's
		/// display buffer, upgrading it to BufferType.EDITABLE if it was
		/// not already editable.
		/// </remarks>
		public void append(java.lang.CharSequence text)
		{
			append(text, 0, text.Length);
		}

		/// <summary>
		/// Convenience method: Append the specified text slice to the TextView's
		/// display buffer, upgrading it to BufferType.EDITABLE if it was
		/// not already editable.
		/// </summary>
		/// <remarks>
		/// Convenience method: Append the specified text slice to the TextView's
		/// display buffer, upgrading it to BufferType.EDITABLE if it was
		/// not already editable.
		/// </remarks>
		public virtual void append(java.lang.CharSequence text, int start, int end)
		{
			if (!(mText is android.text.Editable))
			{
				setText(mText, android.widget.TextView.BufferType.EDITABLE);
			}
			((android.text.Editable)mText).append(text, start, end);
		}

		private void updateTextColors()
		{
			bool inval = false;
			int color = mTextColor.getColorForState(getDrawableState(), 0);
			if (color != mCurTextColor)
			{
				mCurTextColor = color;
				inval = true;
			}
			if (mLinkTextColor != null)
			{
				color = mLinkTextColor.getColorForState(getDrawableState(), 0);
				if (color != mTextPaint.linkColor)
				{
					mTextPaint.linkColor = color;
					inval = true;
				}
			}
			if (mHintTextColor != null)
			{
				color = mHintTextColor.getColorForState(getDrawableState(), 0);
				if (color != mCurHintTextColor && mText.Length == 0)
				{
					mCurHintTextColor = color;
					inval = true;
				}
			}
			if (inval)
			{
				invalidate();
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void drawableStateChanged()
		{
			base.drawableStateChanged();
			if (mTextColor != null && mTextColor.isStateful() || (mHintTextColor != null && mHintTextColor
				.isStateful()) || (mLinkTextColor != null && mLinkTextColor.isStateful()))
			{
				updateTextColors();
			}
			android.widget.TextView.Drawables dr = mDrawables;
			if (dr != null)
			{
				int[] state = getDrawableState();
				if (dr.mDrawableTop != null && dr.mDrawableTop.isStateful())
				{
					dr.mDrawableTop.setState(state);
				}
				if (dr.mDrawableBottom != null && dr.mDrawableBottom.isStateful())
				{
					dr.mDrawableBottom.setState(state);
				}
				if (dr.mDrawableLeft != null && dr.mDrawableLeft.isStateful())
				{
					dr.mDrawableLeft.setState(state);
				}
				if (dr.mDrawableRight != null && dr.mDrawableRight.isStateful())
				{
					dr.mDrawableRight.setState(state);
				}
				if (dr.mDrawableStart != null && dr.mDrawableStart.isStateful())
				{
					dr.mDrawableStart.setState(state);
				}
				if (dr.mDrawableEnd != null && dr.mDrawableEnd.isStateful())
				{
					dr.mDrawableEnd.setState(state);
				}
			}
		}

		/// <summary>
		/// User interface state that is stored by TextView for implementing
		/// <see cref="android.view.View.onSaveInstanceState()">android.view.View.onSaveInstanceState()
		/// 	</see>
		/// .
		/// </summary>
		public class SavedState : android.view.View.BaseSavedState
		{
			internal int selStart;

			internal int selEnd;

			internal java.lang.CharSequence text;

			internal bool frozenWithFocus;

			internal java.lang.CharSequence error;

			internal SavedState(android.os.Parcelable superState) : base(superState)
			{
			}

			[Sharpen.OverridesMethod(@"android.view.AbsSavedState")]
			public override void writeToParcel(android.os.Parcel @out, int flags)
			{
				base.writeToParcel(@out, flags);
				@out.writeInt(selStart);
				@out.writeInt(selEnd);
				@out.writeInt(frozenWithFocus ? 1 : 0);
				android.text.TextUtils.writeToParcel(text, @out, flags);
				if (error == null)
				{
					@out.writeInt(0);
				}
				else
				{
					@out.writeInt(1);
					android.text.TextUtils.writeToParcel(error, @out, flags);
				}
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override string ToString()
			{
				string str = "TextView.SavedState{" + Sharpen.Util.IntToHexString(Sharpen.Util.IdentityHashCode
					(this)) + " start=" + selStart + " end=" + selEnd;
				if (text != null)
				{
					str += " text=" + text;
				}
				return str + "}";
			}

			private sealed class _Creator_2883 : android.os.ParcelableClass.Creator<android.widget.TextView
				.SavedState>
			{
				public _Creator_2883()
				{
				}

				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.widget.TextView.SavedState createFromParcel(android.os.Parcel @in)
				{
					return new android.widget.TextView.SavedState(@in);
				}

				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.widget.TextView.SavedState[] newArray(int size)
				{
					return new android.widget.TextView.SavedState[size];
				}
			}

			public static readonly android.os.ParcelableClass.Creator<android.widget.TextView
				.SavedState> CREATOR = new _Creator_2883();

			private SavedState(android.os.Parcel @in) : base(@in)
			{
				selStart = @in.readInt();
				selEnd = @in.readInt();
				frozenWithFocus = (@in.readInt() != 0);
				text = android.text.TextUtils.CHAR_SEQUENCE_CREATOR.createFromParcel(@in);
				if (@in.readInt() != 0)
				{
					error = android.text.TextUtils.CHAR_SEQUENCE_CREATOR.createFromParcel(@in);
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override android.os.Parcelable onSaveInstanceState()
		{
			android.os.Parcelable superState = base.onSaveInstanceState();
			// Save state if we are forced to
			bool save = mFreezesText;
			int start = 0;
			int end = 0;
			if (mText != null)
			{
				start = getSelectionStart();
				end = getSelectionEnd();
				if (start >= 0 || end >= 0)
				{
					// Or save state if there is a selection
					save = true;
				}
			}
			if (save)
			{
				android.widget.TextView.SavedState ss = new android.widget.TextView.SavedState(superState
					);
				// XXX Should also save the current scroll position!
				ss.selStart = start;
				ss.selEnd = end;
				if (mText is android.text.Spanned)
				{
					android.text.Spannable sp = new android.text.SpannableString(mText);
					foreach (android.widget.TextView.ChangeWatcher cw in sp.getSpans<android.widget.TextView
						.ChangeWatcher>(0, sp.Length))
					{
						sp.removeSpan(cw);
					}
					android.text.style.SuggestionSpan[] suggestionSpans = sp.getSpans<android.text.style.SuggestionSpan
						>(0, sp.Length);
					{
						for (int i = 0; i < suggestionSpans.Length; i++)
						{
							int flags = suggestionSpans[i].getFlags();
							if ((flags & android.text.style.SuggestionSpan.FLAG_EASY_CORRECT) != 0 && (flags 
								& android.text.style.SuggestionSpan.FLAG_MISSPELLED) != 0)
							{
								sp.removeSpan(suggestionSpans[i]);
							}
						}
					}
					sp.removeSpan(mSuggestionRangeSpan);
					ss.text = sp;
				}
				else
				{
					ss.text = java.lang.CharSequenceProxy.Wrap(mText.ToString());
				}
				if (isFocused() && start >= 0 && end >= 0)
				{
					ss.frozenWithFocus = true;
				}
				ss.error = mError;
				return ss;
			}
			return superState;
		}

		private sealed class _Runnable_3016 : java.lang.Runnable
		{
			public _Runnable_3016(TextView _enclosing, java.lang.CharSequence error)
			{
				this._enclosing = _enclosing;
				this.error = error;
			}

			// XXX restore buffer type too, as well as lots of other stuff
			// Display the error later, after the first layout pass
			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public void run()
			{
				this._enclosing.setError(error);
			}

			private readonly TextView _enclosing;

			private readonly java.lang.CharSequence error;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onRestoreInstanceState(android.os.Parcelable state
			)
		{
			if (!(state is android.widget.TextView.SavedState))
			{
				base.onRestoreInstanceState(state);
				return;
			}
			android.widget.TextView.SavedState ss = (android.widget.TextView.SavedState)state;
			base.onRestoreInstanceState(ss.getSuperState());
			if (ss.text != null)
			{
				setText(ss.text);
			}
			if (ss.selStart >= 0 && ss.selEnd >= 0)
			{
				if (mText is android.text.Spannable)
				{
					int len = mText.Length;
					if (ss.selStart > len || ss.selEnd > len)
					{
						string restored = string.Empty;
						if (ss.text != null)
						{
							restored = "(restored) ";
						}
						android.util.Log.e(LOG_TAG, "Saved cursor position " + ss.selStart + "/" + ss.selEnd
							 + " out of range for " + restored + "text " + mText);
					}
					else
					{
						android.text.Selection.setSelection((android.text.Spannable)mText, ss.selStart, ss
							.selEnd);
						if (ss.frozenWithFocus)
						{
							mFrozenWithFocus = true;
						}
					}
				}
			}
			if (ss.error != null)
			{
				java.lang.CharSequence error = ss.error;
				post(new _Runnable_3016(this, error));
			}
		}

		/// <summary>
		/// Control whether this text view saves its entire text contents when
		/// freezing to an icicle, in addition to dynamic state such as cursor
		/// position.
		/// </summary>
		/// <remarks>
		/// Control whether this text view saves its entire text contents when
		/// freezing to an icicle, in addition to dynamic state such as cursor
		/// position.  By default this is false, not saving the text.  Set to true
		/// if the text in the text view is not being saved somewhere else in
		/// persistent storage (such as in a content provider) so that if the
		/// view is later thawed the user will not lose their data.
		/// </remarks>
		/// <param name="freezesText">
		/// Controls whether a frozen icicle should include the
		/// entire text data: true to include it, false to not.
		/// </param>
		/// <attr>ref android.R.styleable#TextView_freezesText</attr>
		[android.view.RemotableViewMethod]
		public virtual void setFreezesText(bool freezesText)
		{
			mFreezesText = freezesText;
		}

		/// <summary>
		/// Return whether this text view is including its entire text contents
		/// in frozen icicles.
		/// </summary>
		/// <remarks>
		/// Return whether this text view is including its entire text contents
		/// in frozen icicles.
		/// </remarks>
		/// <returns>Returns true if text is included, false if it isn't.</returns>
		/// <seealso cref="setFreezesText(bool)">setFreezesText(bool)</seealso>
		public virtual bool getFreezesText()
		{
			return mFreezesText;
		}

		///////////////////////////////////////////////////////////////////////////
		/// <summary>Sets the Factory used to create new Editables.</summary>
		/// <remarks>Sets the Factory used to create new Editables.</remarks>
		public void setEditableFactory(android.text.EditableClass.Factory factory)
		{
			mEditableFactory = factory;
			setText(mText);
		}

		/// <summary>Sets the Factory used to create new Spannables.</summary>
		/// <remarks>Sets the Factory used to create new Spannables.</remarks>
		public void setSpannableFactory(android.text.SpannableClass.Factory factory)
		{
			mSpannableFactory = factory;
			setText(mText);
		}

		/// <summary>Sets the string value of the TextView.</summary>
		/// <remarks>
		/// Sets the string value of the TextView. TextView <em>does not</em> accept
		/// HTML-like formatting, which you can do with text strings in XML resource files.
		/// To style your strings, attach android.text.style.* objects to a
		/// <see cref="android.text.SpannableString">SpannableString</see>
		/// , or see the
		/// &lt;a href="
		/// <docRoot></docRoot>
		/// guide/topics/resources/available-resources.html#stringresources"&gt;
		/// Available Resource Types</a> documentation for an example of setting
		/// formatted text in the XML resource file.
		/// </remarks>
		/// <attr>ref android.R.styleable#TextView_text</attr>
		[android.view.RemotableViewMethod]
		public void setText(java.lang.CharSequence text)
		{
			setText(text, mBufferType);
		}

		/// <summary>
		/// Like
		/// <see cref="setText(java.lang.CharSequence)">setText(java.lang.CharSequence)</see>
		/// ,
		/// except that the cursor position (if any) is retained in the new text.
		/// </summary>
		/// <param name="text">The new text to place in the text view.</param>
		/// <seealso cref="setText(java.lang.CharSequence)">setText(java.lang.CharSequence)</seealso>
		[android.view.RemotableViewMethod]
		public void setTextKeepState(java.lang.CharSequence text)
		{
			setTextKeepState(text, mBufferType);
		}

		/// <summary>
		/// Sets the text that this TextView is to display (see
		/// <see cref="setText(java.lang.CharSequence)">setText(java.lang.CharSequence)</see>
		/// ) and also sets whether it is stored
		/// in a styleable/spannable buffer and whether it is editable.
		/// </summary>
		/// <attr>ref android.R.styleable#TextView_text</attr>
		/// <attr>ref android.R.styleable#TextView_bufferType</attr>
		public virtual void setText(java.lang.CharSequence text, android.widget.TextView.
			BufferType type)
		{
			setText(text, type, true, 0);
			if (mCharWrapper != null)
			{
				mCharWrapper.mChars = null;
			}
		}

		private void setText(java.lang.CharSequence text, android.widget.TextView.BufferType
			 type, bool notifyBefore, int oldlen)
		{
			if (text == null)
			{
				text = java.lang.CharSequenceProxy.Wrap(string.Empty);
			}
			// If suggestions are not enabled, remove the suggestion spans from the text
			if (!isSuggestionsEnabled())
			{
				text = removeSuggestionSpans(text);
			}
			if (!mUserSetTextScaleX)
			{
				mTextPaint.setTextScaleX(1.0f);
			}
			if (text is android.text.Spanned && ((android.text.Spanned)text).getSpanStart(android.text.TextUtils.TruncateAt
				.MARQUEE) >= 0)
			{
				if (android.view.ViewConfiguration.get(mContext).isFadingMarqueeEnabled())
				{
					setHorizontalFadingEdgeEnabled(true);
					mMarqueeFadeMode = MARQUEE_FADE_NORMAL;
				}
				else
				{
					setHorizontalFadingEdgeEnabled(false);
					mMarqueeFadeMode = MARQUEE_FADE_SWITCH_SHOW_ELLIPSIS;
				}
				setEllipsize(android.text.TextUtils.TruncateAt.MARQUEE);
			}
			int n = mFilters.Length;
			{
				for (int i = 0; i < n; i++)
				{
					java.lang.CharSequence @out = mFilters[i].filter(text, 0, text.Length, EMPTY_SPANNED
						, 0, 0);
					if (@out != null)
					{
						text = @out;
					}
				}
			}
			if (notifyBefore)
			{
				if (mText != null)
				{
					oldlen = mText.Length;
					sendBeforeTextChanged(mText, 0, oldlen, text.Length);
				}
				else
				{
					sendBeforeTextChanged(java.lang.CharSequenceProxy.Wrap(string.Empty), 0, 0, text.
						Length);
				}
			}
			bool needEditableForNotification = false;
			bool startSpellCheck = false;
			if (mListeners != null && mListeners.size() != 0)
			{
				needEditableForNotification = true;
			}
			if (type == android.widget.TextView.BufferType.EDITABLE || mInput != null || needEditableForNotification)
			{
				android.text.Editable t = mEditableFactory.newEditable(text);
				text = t;
				setFilters(t, mFilters);
				android.view.inputmethod.InputMethodManager imm = android.view.inputmethod.InputMethodManager
					.peekInstance();
				if (imm != null)
				{
					imm.restartInput(this);
				}
				startSpellCheck = true;
			}
			else
			{
				if (type == android.widget.TextView.BufferType.SPANNABLE || mMovement != null)
				{
					text = mSpannableFactory.newSpannable(text);
				}
				else
				{
					if (!(text is android.widget.TextView.CharWrapper))
					{
						text = android.text.TextUtils.stringOrSpannedString(text);
					}
				}
			}
			if (mAutoLinkMask != 0)
			{
				android.text.Spannable s2;
				if (type == android.widget.TextView.BufferType.EDITABLE || text is android.text.Spannable)
				{
					s2 = (android.text.Spannable)text;
				}
				else
				{
					s2 = mSpannableFactory.newSpannable(text);
				}
				if (android.text.util.Linkify.addLinks(s2, mAutoLinkMask))
				{
					text = s2;
					type = (type == android.widget.TextView.BufferType.EDITABLE) ? android.widget.TextView
						.BufferType.EDITABLE : android.widget.TextView.BufferType.SPANNABLE;
					mText = text;
					// Do not change the movement method for text that support text selection as it
					// would prevent an arbitrary cursor displacement.
					if (mLinksClickable && !textCanBeSelected())
					{
						setMovementMethod(android.text.method.LinkMovementMethod.getInstance());
					}
				}
			}
			mBufferType = type;
			mText = text;
			if (mTransformation == null)
			{
				mTransformed = text;
			}
			else
			{
				mTransformed = mTransformation.getTransformation(text, this);
			}
			int textLength = text.Length;
			if (text is android.text.Spannable && !mAllowTransformationLengthChange)
			{
				android.text.Spannable sp = (android.text.Spannable)text;
				// Remove any ChangeWatchers that might have come
				// from other TextViews.
				android.widget.TextView.ChangeWatcher[] watchers = sp.getSpans<android.widget.TextView
					.ChangeWatcher>(0, sp.Length);
				int count = watchers.Length;
				{
					for (int i_1 = 0; i_1 < count; i_1++)
					{
						sp.removeSpan(watchers[i_1]);
					}
				}
				if (mChangeWatcher == null)
				{
					mChangeWatcher = new android.widget.TextView.ChangeWatcher(this);
				}
				sp.setSpan(mChangeWatcher, 0, textLength, android.text.SpannedClass.SPAN_INCLUSIVE_INCLUSIVE
					 | (PRIORITY << android.text.SpannedClass.SPAN_PRIORITY_SHIFT));
				if (mInput != null)
				{
					sp.setSpan(mInput, 0, textLength, android.text.SpannedClass.SPAN_INCLUSIVE_INCLUSIVE
						);
				}
				if (mTransformation != null)
				{
					sp.setSpan(mTransformation, 0, textLength, android.text.SpannedClass.SPAN_INCLUSIVE_INCLUSIVE
						);
				}
				if (mMovement != null)
				{
					mMovement.initialize(this, (android.text.Spannable)text);
					mSelectionMoved = false;
				}
			}
			if (mLayout != null)
			{
				checkForRelayout();
			}
			sendOnTextChanged(text, 0, oldlen, textLength);
			onTextChanged(text, 0, oldlen, textLength);
			if (startSpellCheck && mSpellChecker != null)
			{
				// This view has to have been previously attached for mSpellChecker to exist  
				updateSpellCheckSpans(0, textLength);
			}
			if (needEditableForNotification)
			{
				sendAfterTextChanged((android.text.Editable)text);
			}
			// SelectionModifierCursorController depends on textCanBeSelected, which depends on text
			prepareCursorControllers();
		}

		/// <summary>
		/// Sets the TextView to display the specified slice of the specified
		/// char array.
		/// </summary>
		/// <remarks>
		/// Sets the TextView to display the specified slice of the specified
		/// char array.  You must promise that you will not change the contents
		/// of the array except for right before another call to setText(),
		/// since the TextView has no way to know that the text
		/// has changed and that it needs to invalidate and re-layout.
		/// </remarks>
		public void setText(char[] text, int start, int len)
		{
			int oldlen = 0;
			if (start < 0 || len < 0 || start + len > text.Length)
			{
				throw new System.IndexOutOfRangeException(start + ", " + len);
			}
			if (mText != null)
			{
				oldlen = mText.Length;
				sendBeforeTextChanged(mText, 0, oldlen, len);
			}
			else
			{
				sendBeforeTextChanged(java.lang.CharSequenceProxy.Wrap(string.Empty), 0, 0, len);
			}
			if (mCharWrapper == null)
			{
				mCharWrapper = new android.widget.TextView.CharWrapper(text, start, len);
			}
			else
			{
				mCharWrapper.set(text, start, len);
			}
			setText(mCharWrapper, mBufferType, false, oldlen);
		}

		private class CharWrapper : java.lang.CharSequence, android.text.GetChars, android.text.GraphicsOperations
		{
			internal char[] mChars;

			internal int mStart;

			internal int mLength;

			public CharWrapper(char[] chars, int start, int len)
			{
				mChars = chars;
				mStart = start;
				mLength = len;
			}

			internal virtual void set(char[] chars, int start, int len)
			{
				mChars = chars;
				mStart = start;
				mLength = len;
			}

			public virtual int Length
			{
				get
				{
					return mLength;
				}
			}

			public virtual char this[int off]
			{
				get
				{
					return mChars[off + mStart];
				}
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override string ToString()
			{
				return new string(mChars, mStart, mLength);
			}

			[Sharpen.ImplementsInterface(@"java.lang.CharSequence")]
			public virtual java.lang.CharSequence SubSequence(int start, int end)
			{
				if (start < 0 || end < 0 || start > mLength || end > mLength)
				{
					throw new System.IndexOutOfRangeException(start + ", " + end);
				}
				return java.lang.CharSequenceProxy.Wrap(new string(mChars, start + mStart, end - 
					start));
			}

			[Sharpen.ImplementsInterface(@"android.text.GetChars")]
			public virtual void getChars(int start, int end, char[] buf, int off)
			{
				if (start < 0 || end < 0 || start > mLength || end > mLength)
				{
					throw new System.IndexOutOfRangeException(start + ", " + end);
				}
				System.Array.Copy(mChars, start + mStart, buf, off, end - start);
			}

			[Sharpen.ImplementsInterface(@"android.text.GraphicsOperations")]
			public virtual void drawText(android.graphics.Canvas c, int start, int end, float
				 x, float y, android.graphics.Paint p)
			{
				c.drawText(mChars, start + mStart, end - start, x, y, p);
			}

			[Sharpen.ImplementsInterface(@"android.text.GraphicsOperations")]
			public virtual void drawTextRun(android.graphics.Canvas c, int start, int end, int
				 contextStart, int contextEnd, float x, float y, int flags, android.graphics.Paint
				 p)
			{
				int count = end - start;
				int contextCount = contextEnd - contextStart;
				c.drawTextRun(mChars, start + mStart, count, contextStart + mStart, contextCount, 
					x, y, flags, p);
			}

			[Sharpen.ImplementsInterface(@"android.text.GraphicsOperations")]
			public virtual float measureText(int start, int end, android.graphics.Paint p)
			{
				return p.measureText(mChars, start + mStart, end - start);
			}

			[Sharpen.ImplementsInterface(@"android.text.GraphicsOperations")]
			public virtual int getTextWidths(int start, int end, float[] widths, android.graphics.Paint
				 p)
			{
				return p.getTextWidths(mChars, start + mStart, end - start, widths);
			}

			[Sharpen.ImplementsInterface(@"android.text.GraphicsOperations")]
			public virtual float getTextRunAdvances(int start, int end, int contextStart, int
				 contextEnd, int flags, float[] advances, int advancesIndex, android.graphics.Paint
				 p)
			{
				int count = end - start;
				int contextCount = contextEnd - contextStart;
				return p.getTextRunAdvances(mChars, start + mStart, count, contextStart + mStart, 
					contextCount, flags, advances, advancesIndex);
			}

			[Sharpen.ImplementsInterface(@"android.text.GraphicsOperations")]
			public virtual float getTextRunAdvances(int start, int end, int contextStart, int
				 contextEnd, int flags, float[] advances, int advancesIndex, android.graphics.Paint
				 p, int reserved)
			{
				int count = end - start;
				int contextCount = contextEnd - contextStart;
				return p.getTextRunAdvances(mChars, start + mStart, count, contextStart + mStart, 
					contextCount, flags, advances, advancesIndex, reserved);
			}

			[Sharpen.ImplementsInterface(@"android.text.GraphicsOperations")]
			public virtual int getTextRunCursor(int contextStart, int contextEnd, int flags, 
				int offset, int cursorOpt, android.graphics.Paint p)
			{
				int contextCount = contextEnd - contextStart;
				return p.getTextRunCursor(mChars, contextStart + mStart, contextCount, flags, offset
					 + mStart, cursorOpt);
			}
		}

		/// <summary>
		/// Like
		/// <see cref="setText(java.lang.CharSequence, BufferType)">setText(java.lang.CharSequence, BufferType)
		/// 	</see>
		/// ,
		/// except that the cursor position (if any) is retained in the new text.
		/// </summary>
		/// <seealso cref="setText(java.lang.CharSequence, BufferType)">setText(java.lang.CharSequence, BufferType)
		/// 	</seealso>
		public void setTextKeepState(java.lang.CharSequence text, android.widget.TextView
			.BufferType type)
		{
			int start = getSelectionStart();
			int end = getSelectionEnd();
			int len = text.Length;
			setText(text, type);
			if (start >= 0 || end >= 0)
			{
				if (mText is android.text.Spannable)
				{
					android.text.Selection.setSelection((android.text.Spannable)mText, System.Math.Max
						(0, System.Math.Min(start, len)), System.Math.Max(0, System.Math.Min(end, len)));
				}
			}
		}

		[android.view.RemotableViewMethod]
		public void setText(int resid)
		{
			setText(getContext().getResources().getText(resid));
		}

		public void setText(int resid, android.widget.TextView.BufferType type)
		{
			setText(getContext().getResources().getText(resid), type);
		}

		/// <summary>Sets the text to be displayed when the text of the TextView is empty.</summary>
		/// <remarks>
		/// Sets the text to be displayed when the text of the TextView is empty.
		/// Null means to use the normal empty text. The hint does not currently
		/// participate in determining the size of the view.
		/// </remarks>
		/// <attr>ref android.R.styleable#TextView_hint</attr>
		[android.view.RemotableViewMethod]
		public void setHint(java.lang.CharSequence hint)
		{
			mHint = android.text.TextUtils.stringOrSpannedString(hint);
			if (mLayout != null)
			{
				checkForRelayout();
			}
			if (mText.Length == 0)
			{
				invalidate();
			}
		}

		/// <summary>
		/// Sets the text to be displayed when the text of the TextView is empty,
		/// from a resource.
		/// </summary>
		/// <remarks>
		/// Sets the text to be displayed when the text of the TextView is empty,
		/// from a resource.
		/// </remarks>
		/// <attr>ref android.R.styleable#TextView_hint</attr>
		[android.view.RemotableViewMethod]
		public void setHint(int resid)
		{
			setHint(getContext().getResources().getText(resid));
		}

		/// <summary>
		/// Returns the hint that is displayed when the text of the TextView
		/// is empty.
		/// </summary>
		/// <remarks>
		/// Returns the hint that is displayed when the text of the TextView
		/// is empty.
		/// </remarks>
		/// <attr>ref android.R.styleable#TextView_hint</attr>
		[android.view.ViewDebug.CapturedViewProperty]
		public virtual java.lang.CharSequence getHint()
		{
			return mHint;
		}

		private static bool isMultilineInputType(int type)
		{
			return (type & (android.text.InputTypeClass.TYPE_MASK_CLASS | android.text.InputTypeClass.TYPE_TEXT_FLAG_MULTI_LINE
				)) == (android.text.InputTypeClass.TYPE_CLASS_TEXT | android.text.InputTypeClass.TYPE_TEXT_FLAG_MULTI_LINE
				);
		}

		/// <summary>
		/// Set the type of the content with a constant as defined for
		/// <see cref="android.view.inputmethod.EditorInfo.inputType">android.view.inputmethod.EditorInfo.inputType
		/// 	</see>
		/// . This
		/// will take care of changing the key listener, by calling
		/// <see cref="setKeyListener(android.text.method.KeyListener)">setKeyListener(android.text.method.KeyListener)
		/// 	</see>
		/// ,
		/// to match the given content type.  If the given content type is
		/// <see cref="android.text.InputTypeClass.TYPE_NULL">android.text.InputTypeClass.TYPE_NULL
		/// 	</see>
		/// then a soft keyboard will not be displayed for this text view.
		/// Note that the maximum number of displayed lines (see
		/// <see cref="setMaxLines(int)">setMaxLines(int)</see>
		/// ) will be
		/// modified if you change the
		/// <see cref="android.text.InputTypeClass.TYPE_TEXT_FLAG_MULTI_LINE">android.text.InputTypeClass.TYPE_TEXT_FLAG_MULTI_LINE
		/// 	</see>
		/// flag of the input
		/// type.
		/// </summary>
		/// <seealso cref="getInputType()">getInputType()</seealso>
		/// <seealso cref="setRawInputType(int)">setRawInputType(int)</seealso>
		/// <seealso cref="android.text.InputType">android.text.InputType</seealso>
		/// <attr>ref android.R.styleable#TextView_inputType</attr>
		public virtual void setInputType(int type)
		{
			bool wasPassword = isPasswordInputType(mInputType);
			bool wasVisiblePassword = isVisiblePasswordInputType(mInputType);
			setInputType(type, false);
			bool isPassword = isPasswordInputType(type);
			bool isVisiblePassword = isVisiblePasswordInputType(type);
			bool forceUpdate = false;
			if (isPassword)
			{
				setTransformationMethod(android.text.method.PasswordTransformationMethod.getInstance
					());
				setTypefaceByIndex(MONOSPACE, 0);
			}
			else
			{
				if (isVisiblePassword)
				{
					if (mTransformation == android.text.method.PasswordTransformationMethod.getInstance
						())
					{
						forceUpdate = true;
					}
					setTypefaceByIndex(MONOSPACE, 0);
				}
				else
				{
					if (wasPassword || wasVisiblePassword)
					{
						// not in password mode, clean up typeface and transformation
						setTypefaceByIndex(-1, -1);
						if (mTransformation == android.text.method.PasswordTransformationMethod.getInstance
							())
						{
							forceUpdate = true;
						}
					}
				}
			}
			bool singleLine = !isMultilineInputType(type);
			// We need to update the single line mode if it has changed or we
			// were previously in password mode.
			if (mSingleLine != singleLine || forceUpdate)
			{
				// Change single line mode, but only change the transformation if
				// we are not in password mode.
				applySingleLine(singleLine, !isPassword, true);
			}
			if (!isSuggestionsEnabled())
			{
				mText = removeSuggestionSpans(mText);
			}
			android.view.inputmethod.InputMethodManager imm = android.view.inputmethod.InputMethodManager
				.peekInstance();
			if (imm != null)
			{
				imm.restartInput(this);
			}
		}

		/// <summary>It would be better to rely on the input type for everything.</summary>
		/// <remarks>
		/// It would be better to rely on the input type for everything. A password inputType should have
		/// a password transformation. We should hence use isPasswordInputType instead of this method.
		/// We should:
		/// - Call setInputType in setKeyListener instead of changing the input type directly (which
		/// would install the correct transformation).
		/// - Refuse the installation of a non-password transformation in setTransformation if the input
		/// type is password.
		/// However, this is like this for legacy reasons and we cannot break existing apps. This method
		/// is useful since it matches what the user can see (obfuscated text or not).
		/// </remarks>
		/// <returns>true if the current transformation method is of the password type.</returns>
		private bool hasPasswordTransformationMethod()
		{
			return mTransformation is android.text.method.PasswordTransformationMethod;
		}

		private static bool isPasswordInputType(int inputType)
		{
			int variation = inputType & (android.text.InputTypeClass.TYPE_MASK_CLASS | android.text.InputTypeClass.TYPE_MASK_VARIATION
				);
			return variation == (android.text.InputTypeClass.TYPE_CLASS_TEXT | android.text.InputTypeClass.TYPE_TEXT_VARIATION_PASSWORD
				) || variation == (android.text.InputTypeClass.TYPE_CLASS_TEXT | android.text.InputTypeClass.TYPE_TEXT_VARIATION_WEB_PASSWORD
				) || variation == (android.text.InputTypeClass.TYPE_CLASS_NUMBER | android.text.InputTypeClass.TYPE_NUMBER_VARIATION_PASSWORD
				);
		}

		private static bool isVisiblePasswordInputType(int inputType)
		{
			int variation = inputType & (android.text.InputTypeClass.TYPE_MASK_CLASS | android.text.InputTypeClass.TYPE_MASK_VARIATION
				);
			return variation == (android.text.InputTypeClass.TYPE_CLASS_TEXT | android.text.InputTypeClass.TYPE_TEXT_VARIATION_VISIBLE_PASSWORD
				);
		}

		/// <summary>
		/// Directly change the content type integer of the text view, without
		/// modifying any other state.
		/// </summary>
		/// <remarks>
		/// Directly change the content type integer of the text view, without
		/// modifying any other state.
		/// </remarks>
		/// <seealso cref="setInputType(int)">setInputType(int)</seealso>
		/// <seealso cref="android.text.InputType">android.text.InputType</seealso>
		/// <attr>ref android.R.styleable#TextView_inputType</attr>
		public virtual void setRawInputType(int type)
		{
			mInputType = type;
		}

		private void setInputType(int type, bool direct)
		{
			int cls = type & android.text.InputTypeClass.TYPE_MASK_CLASS;
			android.text.method.KeyListener input;
			if (cls == android.text.InputTypeClass.TYPE_CLASS_TEXT)
			{
				bool autotext = (type & android.text.InputTypeClass.TYPE_TEXT_FLAG_AUTO_CORRECT) 
					!= 0;
				android.text.method.TextKeyListener.Capitalize cap;
				if ((type & android.text.InputTypeClass.TYPE_TEXT_FLAG_CAP_CHARACTERS) != 0)
				{
					cap = android.text.method.TextKeyListener.Capitalize.CHARACTERS;
				}
				else
				{
					if ((type & android.text.InputTypeClass.TYPE_TEXT_FLAG_CAP_WORDS) != 0)
					{
						cap = android.text.method.TextKeyListener.Capitalize.WORDS;
					}
					else
					{
						if ((type & android.text.InputTypeClass.TYPE_TEXT_FLAG_CAP_SENTENCES) != 0)
						{
							cap = android.text.method.TextKeyListener.Capitalize.SENTENCES;
						}
						else
						{
							cap = android.text.method.TextKeyListener.Capitalize.NONE;
						}
					}
				}
				input = android.text.method.TextKeyListener.getInstance(autotext, cap);
			}
			else
			{
				if (cls == android.text.InputTypeClass.TYPE_CLASS_NUMBER)
				{
					input = android.text.method.DigitsKeyListener.getInstance((type & android.text.InputTypeClass.TYPE_NUMBER_FLAG_SIGNED
						) != 0, (type & android.text.InputTypeClass.TYPE_NUMBER_FLAG_DECIMAL) != 0);
				}
				else
				{
					if (cls == android.text.InputTypeClass.TYPE_CLASS_DATETIME)
					{
						switch (type & android.text.InputTypeClass.TYPE_MASK_VARIATION)
						{
							case android.text.InputTypeClass.TYPE_DATETIME_VARIATION_DATE:
							{
								input = android.text.method.DateKeyListener.getInstance();
								break;
							}

							case android.text.InputTypeClass.TYPE_DATETIME_VARIATION_TIME:
							{
								input = android.text.method.TimeKeyListener.getInstance();
								break;
							}

							default:
							{
								input = android.text.method.DateTimeKeyListener.getInstance();
								break;
							}
						}
					}
					else
					{
						if (cls == android.text.InputTypeClass.TYPE_CLASS_PHONE)
						{
							input = android.text.method.DialerKeyListener.getInstance();
						}
						else
						{
							input = android.text.method.TextKeyListener.getInstance();
						}
					}
				}
			}
			setRawInputType(type);
			if (direct)
			{
				mInput = input;
			}
			else
			{
				setKeyListenerOnly(input);
			}
		}

		/// <summary>Get the type of the content.</summary>
		/// <remarks>Get the type of the content.</remarks>
		/// <seealso cref="setInputType(int)">setInputType(int)</seealso>
		/// <seealso cref="android.text.InputType">android.text.InputType</seealso>
		public virtual int getInputType()
		{
			return mInputType;
		}

		/// <summary>
		/// Change the editor type integer associated with the text view, which
		/// will be reported to an IME with
		/// <see cref="android.view.inputmethod.EditorInfo.imeOptions">android.view.inputmethod.EditorInfo.imeOptions
		/// 	</see>
		/// when it
		/// has focus.
		/// </summary>
		/// <seealso cref="getImeOptions()">getImeOptions()</seealso>
		/// <seealso cref="android.view.inputmethod.EditorInfo">android.view.inputmethod.EditorInfo
		/// 	</seealso>
		/// <attr>ref android.R.styleable#TextView_imeOptions</attr>
		public virtual void setImeOptions(int imeOptions)
		{
			if (mInputContentType == null)
			{
				mInputContentType = new android.widget.TextView.InputContentType(this);
			}
			mInputContentType.imeOptions = imeOptions;
		}

		/// <summary>Get the type of the IME editor.</summary>
		/// <remarks>Get the type of the IME editor.</remarks>
		/// <seealso cref="setImeOptions(int)">setImeOptions(int)</seealso>
		/// <seealso cref="android.view.inputmethod.EditorInfo">android.view.inputmethod.EditorInfo
		/// 	</seealso>
		public virtual int getImeOptions()
		{
			return mInputContentType != null ? mInputContentType.imeOptions : android.view.inputmethod.EditorInfo
				.IME_NULL;
		}

		/// <summary>
		/// Change the custom IME action associated with the text view, which
		/// will be reported to an IME with
		/// <see cref="android.view.inputmethod.EditorInfo.actionLabel">android.view.inputmethod.EditorInfo.actionLabel
		/// 	</see>
		/// and
		/// <see cref="android.view.inputmethod.EditorInfo.actionId">android.view.inputmethod.EditorInfo.actionId
		/// 	</see>
		/// when it has focus.
		/// </summary>
		/// <seealso cref="getImeActionLabel()">getImeActionLabel()</seealso>
		/// <seealso cref="getImeActionId()">getImeActionId()</seealso>
		/// <seealso cref="android.view.inputmethod.EditorInfo">android.view.inputmethod.EditorInfo
		/// 	</seealso>
		/// <attr>ref android.R.styleable#TextView_imeActionLabel</attr>
		/// <attr>ref android.R.styleable#TextView_imeActionId</attr>
		public virtual void setImeActionLabel(java.lang.CharSequence label, int actionId)
		{
			if (mInputContentType == null)
			{
				mInputContentType = new android.widget.TextView.InputContentType(this);
			}
			mInputContentType.imeActionLabel = label;
			mInputContentType.imeActionId = actionId;
		}

		/// <summary>
		/// Get the IME action label previous set with
		/// <see cref="setImeActionLabel(java.lang.CharSequence, int)">setImeActionLabel(java.lang.CharSequence, int)
		/// 	</see>
		/// .
		/// </summary>
		/// <seealso cref="setImeActionLabel(java.lang.CharSequence, int)">setImeActionLabel(java.lang.CharSequence, int)
		/// 	</seealso>
		/// <seealso cref="android.view.inputmethod.EditorInfo">android.view.inputmethod.EditorInfo
		/// 	</seealso>
		public virtual java.lang.CharSequence getImeActionLabel()
		{
			return mInputContentType != null ? mInputContentType.imeActionLabel : null;
		}

		/// <summary>
		/// Get the IME action ID previous set with
		/// <see cref="setImeActionLabel(java.lang.CharSequence, int)">setImeActionLabel(java.lang.CharSequence, int)
		/// 	</see>
		/// .
		/// </summary>
		/// <seealso cref="setImeActionLabel(java.lang.CharSequence, int)">setImeActionLabel(java.lang.CharSequence, int)
		/// 	</seealso>
		/// <seealso cref="android.view.inputmethod.EditorInfo">android.view.inputmethod.EditorInfo
		/// 	</seealso>
		public virtual int getImeActionId()
		{
			return mInputContentType != null ? mInputContentType.imeActionId : 0;
		}

		/// <summary>
		/// Set a special listener to be called when an action is performed
		/// on the text view.
		/// </summary>
		/// <remarks>
		/// Set a special listener to be called when an action is performed
		/// on the text view.  This will be called when the enter key is pressed,
		/// or when an action supplied to the IME is selected by the user.  Setting
		/// this means that the normal hard key event will not insert a newline
		/// into the text view, even if it is multi-line; holding down the ALT
		/// modifier will, however, allow the user to insert a newline character.
		/// </remarks>
		public virtual void setOnEditorActionListener(android.widget.TextView.OnEditorActionListener
			 l)
		{
			if (mInputContentType == null)
			{
				mInputContentType = new android.widget.TextView.InputContentType(this);
			}
			mInputContentType.onEditorActionListener = l;
		}

		/// <summary>
		/// Called when an attached input method calls
		/// <see cref="android.view.inputmethod.InputConnection.performEditorAction(int)">InputConnection.performEditorAction()
		/// 	</see>
		/// for this text view.  The default implementation will call your action
		/// listener supplied to
		/// <see cref="setOnEditorActionListener(OnEditorActionListener)">setOnEditorActionListener(OnEditorActionListener)
		/// 	</see>
		/// , or perform
		/// a standard operation for
		/// <see cref="android.view.inputmethod.EditorInfo.IME_ACTION_NEXT">EditorInfo.IME_ACTION_NEXT
		/// 	</see>
		/// ,
		/// <see cref="android.view.inputmethod.EditorInfo.IME_ACTION_PREVIOUS">EditorInfo.IME_ACTION_PREVIOUS
		/// 	</see>
		/// , or
		/// <see cref="android.view.inputmethod.EditorInfo.IME_ACTION_DONE">EditorInfo.IME_ACTION_DONE
		/// 	</see>
		/// .
		/// <p>For backwards compatibility, if no IME options have been set and the
		/// text view would not normally advance focus on enter, then
		/// the NEXT and DONE actions received here will be turned into an enter
		/// key down/up pair to go through the normal key handling.
		/// </summary>
		/// <param name="actionCode">The code of the action being performed.</param>
		/// <seealso cref="setOnEditorActionListener(OnEditorActionListener)">setOnEditorActionListener(OnEditorActionListener)
		/// 	</seealso>
		public virtual void onEditorAction(int actionCode)
		{
			android.widget.TextView.InputContentType ict = mInputContentType;
			if (ict != null)
			{
				if (ict.onEditorActionListener != null)
				{
					if (ict.onEditorActionListener.onEditorAction(this, actionCode, null))
					{
						return;
					}
				}
				// This is the handling for some default action.
				// Note that for backwards compatibility we don't do this
				// default handling if explicit ime options have not been given,
				// instead turning this into the normal enter key codes that an
				// app may be expecting.
				if (actionCode == android.view.inputmethod.EditorInfo.IME_ACTION_NEXT)
				{
					android.view.View v = focusSearch(FOCUS_FORWARD);
					if (v != null)
					{
						if (!v.requestFocus(FOCUS_FORWARD))
						{
							throw new System.InvalidOperationException("focus search returned a view " + "that wasn't able to take focus!"
								);
						}
					}
					return;
				}
				else
				{
					if (actionCode == android.view.inputmethod.EditorInfo.IME_ACTION_PREVIOUS)
					{
						android.view.View v = focusSearch(FOCUS_BACKWARD);
						if (v != null)
						{
							if (!v.requestFocus(FOCUS_BACKWARD))
							{
								throw new System.InvalidOperationException("focus search returned a view " + "that wasn't able to take focus!"
									);
							}
						}
						return;
					}
					else
					{
						if (actionCode == android.view.inputmethod.EditorInfo.IME_ACTION_DONE)
						{
							android.view.inputmethod.InputMethodManager imm = android.view.inputmethod.InputMethodManager
								.peekInstance();
							if (imm != null && imm.isActive(this))
							{
								imm.hideSoftInputFromWindow(getWindowToken(), 0);
							}
							clearFocus();
							return;
						}
					}
				}
			}
			android.os.Handler h = getHandler();
			if (h != null)
			{
				long eventTime = android.os.SystemClock.uptimeMillis();
				h.sendMessage(h.obtainMessage(android.view.ViewRootImpl.DISPATCH_KEY_FROM_IME, new 
					android.view.KeyEvent(eventTime, eventTime, android.view.KeyEvent.ACTION_DOWN, android.view.KeyEvent
					.KEYCODE_ENTER, 0, 0, android.view.KeyCharacterMap.VIRTUAL_KEYBOARD, 0, android.view.KeyEvent
					.FLAG_SOFT_KEYBOARD | android.view.KeyEvent.FLAG_KEEP_TOUCH_MODE | android.view.KeyEvent
					.FLAG_EDITOR_ACTION)));
				h.sendMessage(h.obtainMessage(android.view.ViewRootImpl.DISPATCH_KEY_FROM_IME, new 
					android.view.KeyEvent(android.os.SystemClock.uptimeMillis(), eventTime, android.view.KeyEvent
					.ACTION_UP, android.view.KeyEvent.KEYCODE_ENTER, 0, 0, android.view.KeyCharacterMap
					.VIRTUAL_KEYBOARD, 0, android.view.KeyEvent.FLAG_SOFT_KEYBOARD | android.view.KeyEvent
					.FLAG_KEEP_TOUCH_MODE | android.view.KeyEvent.FLAG_EDITOR_ACTION)));
			}
		}

		/// <summary>
		/// Set the private content type of the text, which is the
		/// <see cref="android.view.inputmethod.EditorInfo.privateImeOptions">EditorInfo.privateImeOptions
		/// 	</see>
		/// field that will be filled in when creating an input connection.
		/// </summary>
		/// <seealso cref="getPrivateImeOptions()">getPrivateImeOptions()</seealso>
		/// <seealso cref="android.view.inputmethod.EditorInfo.privateImeOptions">android.view.inputmethod.EditorInfo.privateImeOptions
		/// 	</seealso>
		/// <attr>ref android.R.styleable#TextView_privateImeOptions</attr>
		public virtual void setPrivateImeOptions(string type)
		{
			if (mInputContentType == null)
			{
				mInputContentType = new android.widget.TextView.InputContentType(this);
			}
			mInputContentType.privateImeOptions = type;
		}

		/// <summary>Get the private type of the content.</summary>
		/// <remarks>Get the private type of the content.</remarks>
		/// <seealso cref="setPrivateImeOptions(string)">setPrivateImeOptions(string)</seealso>
		/// <seealso cref="android.view.inputmethod.EditorInfo.privateImeOptions">android.view.inputmethod.EditorInfo.privateImeOptions
		/// 	</seealso>
		public virtual string getPrivateImeOptions()
		{
			return mInputContentType != null ? mInputContentType.privateImeOptions : null;
		}

		/// <summary>
		/// Set the extra input data of the text, which is the
		/// <see cref="android.view.inputmethod.EditorInfo.extras">TextBoxAttribute.extras</see>
		/// Bundle that will be filled in when creating an input connection.  The
		/// given integer is the resource ID of an XML resource holding an
		/// <see cref="android.R.styleable.InputExtras">&lt;input-extras&gt;</see>
		/// XML tree.
		/// </summary>
		/// <seealso cref="getInputExtras(bool)"></seealso>
		/// <seealso cref="android.view.inputmethod.EditorInfo.extras">android.view.inputmethod.EditorInfo.extras
		/// 	</seealso>
		/// <attr>ref android.R.styleable#TextView_editorExtras</attr>
		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		public virtual void setInputExtras(int xmlResId)
		{
			android.content.res.XmlResourceParser parser = getResources().getXml(xmlResId);
			if (mInputContentType == null)
			{
				mInputContentType = new android.widget.TextView.InputContentType(this);
			}
			mInputContentType.extras = new android.os.Bundle();
			getResources().parseBundleExtras(parser, mInputContentType.extras);
		}

		/// <summary>
		/// Retrieve the input extras currently associated with the text view, which
		/// can be viewed as well as modified.
		/// </summary>
		/// <remarks>
		/// Retrieve the input extras currently associated with the text view, which
		/// can be viewed as well as modified.
		/// </remarks>
		/// <param name="create">
		/// If true, the extras will be created if they don't already
		/// exist.  Otherwise, null will be returned if none have been created.
		/// </param>
		/// <seealso cref="setInputExtras(int)">setInputExtras(int)</seealso>
		/// <seealso cref="android.view.inputmethod.EditorInfo.extras">android.view.inputmethod.EditorInfo.extras
		/// 	</seealso>
		/// <attr>ref android.R.styleable#TextView_editorExtras</attr>
		public virtual android.os.Bundle getInputExtras(bool create)
		{
			if (mInputContentType == null)
			{
				if (!create)
				{
					return null;
				}
				mInputContentType = new android.widget.TextView.InputContentType(this);
			}
			if (mInputContentType.extras == null)
			{
				if (!create)
				{
					return null;
				}
				mInputContentType.extras = new android.os.Bundle();
			}
			return mInputContentType.extras;
		}

		/// <summary>
		/// Returns the error message that was set to be displayed with
		/// <see cref="setError(java.lang.CharSequence)">setError(java.lang.CharSequence)</see>
		/// , or <code>null</code> if no error was set
		/// or if it the error was cleared by the widget after user input.
		/// </summary>
		public virtual java.lang.CharSequence getError()
		{
			return mError;
		}

		/// <summary>
		/// Sets the right-hand compound drawable of the TextView to the "error"
		/// icon and sets an error message that will be displayed in a popup when
		/// the TextView has focus.
		/// </summary>
		/// <remarks>
		/// Sets the right-hand compound drawable of the TextView to the "error"
		/// icon and sets an error message that will be displayed in a popup when
		/// the TextView has focus.  The icon and error message will be reset to
		/// null when any key events cause changes to the TextView's text.  If the
		/// <code>error</code> is <code>null</code>, the error message and icon
		/// will be cleared.
		/// </remarks>
		[android.view.RemotableViewMethod]
		public virtual void setError(java.lang.CharSequence error)
		{
			if (error == null)
			{
				setError(null, null);
			}
			else
			{
				android.graphics.drawable.Drawable dr = getContext().getResources().getDrawable(android.@internal.R
					.drawable.indicator_input_error);
				dr.setBounds(0, 0, dr.getIntrinsicWidth(), dr.getIntrinsicHeight());
				setError(error, dr);
			}
		}

		/// <summary>
		/// Sets the right-hand compound drawable of the TextView to the specified
		/// icon and sets an error message that will be displayed in a popup when
		/// the TextView has focus.
		/// </summary>
		/// <remarks>
		/// Sets the right-hand compound drawable of the TextView to the specified
		/// icon and sets an error message that will be displayed in a popup when
		/// the TextView has focus.  The icon and error message will be reset to
		/// null when any key events cause changes to the TextView's text.  The
		/// drawable must already have had
		/// <see cref="android.graphics.drawable.Drawable.setBounds(android.graphics.Rect)">android.graphics.drawable.Drawable.setBounds(android.graphics.Rect)
		/// 	</see>
		/// set on it.
		/// If the <code>error</code> is <code>null</code>, the error message will
		/// be cleared (and you should provide a <code>null</code> icon as well).
		/// </remarks>
		public virtual void setError(java.lang.CharSequence error, android.graphics.drawable.Drawable
			 icon)
		{
			error = android.text.TextUtils.stringOrSpannedString(error);
			mError = error;
			mErrorWasChanged = true;
			android.widget.TextView.Drawables dr = mDrawables;
			if (dr != null)
			{
				switch (getResolvedLayoutDirection())
				{
					case LAYOUT_DIRECTION_LTR:
					default:
					{
						setCompoundDrawables(dr.mDrawableLeft, dr.mDrawableTop, icon, dr.mDrawableBottom);
						break;
					}

					case LAYOUT_DIRECTION_RTL:
					{
						setCompoundDrawables(icon, dr.mDrawableTop, dr.mDrawableRight, dr.mDrawableBottom
							);
						break;
					}
				}
			}
			else
			{
				setCompoundDrawables(null, null, icon, null);
			}
			if (error == null)
			{
				if (mPopup != null)
				{
					if (mPopup.isShowing())
					{
						mPopup.dismiss();
					}
					mPopup = null;
				}
			}
			else
			{
				if (isFocused())
				{
					showError();
				}
			}
		}

		private void showError()
		{
			if (getWindowToken() == null)
			{
				mShowErrorAfterAttach = true;
				return;
			}
			if (mPopup == null)
			{
				android.view.LayoutInflater inflater = android.view.LayoutInflater.from(getContext
					());
				android.widget.TextView err = (android.widget.TextView)inflater.inflate(android.@internal.R
					.layout.textview_hint, null);
				float scale = getResources().getDisplayMetrics().density;
				mPopup = new android.widget.TextView.ErrorPopup(err, (int)(200 * scale + 0.5f), (
					int)(50 * scale + 0.5f));
				mPopup.setFocusable(false);
				// The user is entering text, so the input method is needed.  We
				// don't want the popup to be displayed on top of it.
				mPopup.setInputMethodMode(android.widget.PopupWindow.INPUT_METHOD_NEEDED);
			}
			android.widget.TextView tv = (android.widget.TextView)mPopup.getContentView();
			chooseSize(mPopup, mError, tv);
			tv.setText(mError);
			mPopup.showAsDropDown(this, getErrorX(), getErrorY());
			mPopup.fixDirection(mPopup.isAboveAnchor());
		}

		private class ErrorPopup : android.widget.PopupWindow
		{
			internal bool mAbove = false;

			internal readonly android.widget.TextView mView;

			internal int mPopupInlineErrorBackgroundId = 0;

			internal int mPopupInlineErrorAboveBackgroundId = 0;

			internal ErrorPopup(android.widget.TextView v, int width, int height) : base(v, width
				, height)
			{
				mView = v;
				// Make sure the TextView has a background set as it will be used the first time it is
				// shown and positionned. Initialized with below background, which should have
				// dimensions identical to the above version for this to work (and is more likely).
				mPopupInlineErrorBackgroundId = getResourceId(mPopupInlineErrorBackgroundId, android.@internal.R
					.styleable.Theme_errorMessageBackground);
				mView.setBackgroundResource(mPopupInlineErrorBackgroundId);
			}

			internal virtual void fixDirection(bool above)
			{
				mAbove = above;
				if (above)
				{
					mPopupInlineErrorAboveBackgroundId = getResourceId(mPopupInlineErrorAboveBackgroundId
						, android.@internal.R.styleable.Theme_errorMessageAboveBackground);
				}
				else
				{
					mPopupInlineErrorBackgroundId = getResourceId(mPopupInlineErrorBackgroundId, android.@internal.R
						.styleable.Theme_errorMessageBackground);
				}
				mView.setBackgroundResource(above ? mPopupInlineErrorAboveBackgroundId : mPopupInlineErrorBackgroundId
					);
			}

			internal int getResourceId(int currentId, int index)
			{
				if (currentId == 0)
				{
					android.content.res.TypedArray styledAttributes = mView.getContext().obtainStyledAttributes
						(android.R.styleable.Theme);
					currentId = styledAttributes.getResourceId(index, 0);
					styledAttributes.recycle();
				}
				return currentId;
			}

			[Sharpen.OverridesMethod(@"android.widget.PopupWindow")]
			public override void update(int x, int y, int w, int h, bool force)
			{
				base.update(x, y, w, h, force);
				bool above = isAboveAnchor();
				if (above != mAbove)
				{
					fixDirection(above);
				}
			}
		}

		/// <summary>
		/// Returns the Y offset to make the pointy top of the error point
		/// at the middle of the error icon.
		/// </summary>
		/// <remarks>
		/// Returns the Y offset to make the pointy top of the error point
		/// at the middle of the error icon.
		/// </remarks>
		private int getErrorX()
		{
			float scale = getResources().getDisplayMetrics().density;
			android.widget.TextView.Drawables dr = mDrawables;
			return getWidth() - mPopup.getWidth() - getPaddingRight() - (dr != null ? dr.mDrawableSizeRight
				 : 0) / 2 + (int)(25 * scale + 0.5f);
		}

		/// <summary>
		/// Returns the Y offset to make the pointy top of the error point
		/// at the bottom of the error icon.
		/// </summary>
		/// <remarks>
		/// Returns the Y offset to make the pointy top of the error point
		/// at the bottom of the error icon.
		/// </remarks>
		private int getErrorY()
		{
			int compoundPaddingTop = getCompoundPaddingTop();
			int vspace = mBottom - mTop - getCompoundPaddingBottom() - compoundPaddingTop;
			android.widget.TextView.Drawables dr = mDrawables;
			int icontop = compoundPaddingTop + (vspace - (dr != null ? dr.mDrawableHeightRight
				 : 0)) / 2;
			float scale = getResources().getDisplayMetrics().density;
			return icontop + (dr != null ? dr.mDrawableHeightRight : 0) - getHeight() - (int)
				(2 * scale + 0.5f);
		}

		private void hideError()
		{
			if (mPopup != null)
			{
				if (mPopup.isShowing())
				{
					mPopup.dismiss();
				}
			}
			mShowErrorAfterAttach = false;
		}

		private void chooseSize(android.widget.PopupWindow pop, java.lang.CharSequence text
			, android.widget.TextView tv)
		{
			int wid = tv.getPaddingLeft() + tv.getPaddingRight();
			int ht = tv.getPaddingTop() + tv.getPaddingBottom();
			int defaultWidthInPixels = getResources().getDimensionPixelSize(android.@internal.R
				.dimen.textview_error_popup_default_width);
			android.text.Layout l = new android.text.StaticLayout(text, tv.getPaint(), defaultWidthInPixels
				, android.text.Layout.Alignment.ALIGN_NORMAL, 1, 0, true);
			float max = 0;
			{
				for (int i = 0; i < l.getLineCount(); i++)
				{
					max = System.Math.Max(max, l.getLineWidth(i));
				}
			}
			pop.setWidth(wid + (int)System.Math.Ceiling(max));
			pop.setHeight(ht + l.getHeight());
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override bool setFrame(int l, int t, int r, int b)
		{
			bool result = base.setFrame(l, t, r, b);
			if (mPopup != null)
			{
				android.widget.TextView tv = (android.widget.TextView)mPopup.getContentView();
				chooseSize(mPopup, mError, tv);
				mPopup.update(this, getErrorX(), getErrorY(), mPopup.getWidth(), mPopup.getHeight
					());
			}
			restartMarqueeIfNeeded();
			return result;
		}

		private void restartMarqueeIfNeeded()
		{
			if (mRestartMarquee && mEllipsize == android.text.TextUtils.TruncateAt.MARQUEE)
			{
				mRestartMarquee = false;
				startMarquee();
			}
		}

		/// <summary>
		/// Sets the list of input filters that will be used if the buffer is
		/// Editable.
		/// </summary>
		/// <remarks>
		/// Sets the list of input filters that will be used if the buffer is
		/// Editable.  Has no effect otherwise.
		/// </remarks>
		/// <attr>ref android.R.styleable#TextView_maxLength</attr>
		public virtual void setFilters(android.text.InputFilter[] filters)
		{
			if (filters == null)
			{
				throw new System.ArgumentException();
			}
			mFilters = filters;
			if (mText is android.text.Editable)
			{
				setFilters((android.text.Editable)mText, filters);
			}
		}

		/// <summary>
		/// Sets the list of input filters on the specified Editable,
		/// and includes mInput in the list if it is an InputFilter.
		/// </summary>
		/// <remarks>
		/// Sets the list of input filters on the specified Editable,
		/// and includes mInput in the list if it is an InputFilter.
		/// </remarks>
		private void setFilters(android.text.Editable e, android.text.InputFilter[] filters
			)
		{
			if (mInput is android.text.InputFilter)
			{
				android.text.InputFilter[] nf = new android.text.InputFilter[filters.Length + 1];
				System.Array.Copy(filters, 0, nf, 0, filters.Length);
				nf[filters.Length] = (android.text.InputFilter)mInput;
				e.setFilters(nf);
			}
			else
			{
				e.setFilters(filters);
			}
		}

		/// <summary>Returns the current list of input filters.</summary>
		/// <remarks>Returns the current list of input filters.</remarks>
		public virtual android.text.InputFilter[] getFilters()
		{
			return mFilters;
		}

		/////////////////////////////////////////////////////////////////////////
		private int getVerticalOffset(bool forceNormal)
		{
			int voffset = 0;
			int gravity = mGravity & android.view.Gravity.VERTICAL_GRAVITY_MASK;
			android.text.Layout l = mLayout;
			if (!forceNormal && mText.Length == 0 && mHintLayout != null)
			{
				l = mHintLayout;
			}
			if (gravity != android.view.Gravity.TOP)
			{
				int boxht;
				if (l == mHintLayout)
				{
					boxht = getMeasuredHeight() - getCompoundPaddingTop() - getCompoundPaddingBottom(
						);
				}
				else
				{
					boxht = getMeasuredHeight() - getExtendedPaddingTop() - getExtendedPaddingBottom(
						);
				}
				int textht = l.getHeight();
				if (textht < boxht)
				{
					if (gravity == android.view.Gravity.BOTTOM)
					{
						voffset = boxht - textht;
					}
					else
					{
						// (gravity == Gravity.CENTER_VERTICAL)
						voffset = (boxht - textht) >> 1;
					}
				}
			}
			return voffset;
		}

		private int getBottomVerticalOffset(bool forceNormal)
		{
			int voffset = 0;
			int gravity = mGravity & android.view.Gravity.VERTICAL_GRAVITY_MASK;
			android.text.Layout l = mLayout;
			if (!forceNormal && mText.Length == 0 && mHintLayout != null)
			{
				l = mHintLayout;
			}
			if (gravity != android.view.Gravity.BOTTOM)
			{
				int boxht;
				if (l == mHintLayout)
				{
					boxht = getMeasuredHeight() - getCompoundPaddingTop() - getCompoundPaddingBottom(
						);
				}
				else
				{
					boxht = getMeasuredHeight() - getExtendedPaddingTop() - getExtendedPaddingBottom(
						);
				}
				int textht = l.getHeight();
				if (textht < boxht)
				{
					if (gravity == android.view.Gravity.TOP)
					{
						voffset = boxht - textht;
					}
					else
					{
						// (gravity == Gravity.CENTER_VERTICAL)
						voffset = (boxht - textht) >> 1;
					}
				}
			}
			return voffset;
		}

		private void invalidateCursorPath()
		{
			if (mHighlightPathBogus)
			{
				invalidateCursor();
			}
			else
			{
				int horizontalPadding = getCompoundPaddingLeft();
				int verticalPadding = getExtendedPaddingTop() + getVerticalOffset(true);
				if (mCursorCount == 0)
				{
					lock (sTempRect)
					{
						float thick = android.util.FloatMath.ceil(mTextPaint.getStrokeWidth());
						if (thick < 1.0f)
						{
							thick = 1.0f;
						}
						thick /= 2.0f;
						mHighlightPath.computeBounds(sTempRect, false);
						invalidate((int)android.util.FloatMath.floor(horizontalPadding + sTempRect.left -
							 thick), (int)android.util.FloatMath.floor(verticalPadding + sTempRect.top - thick
							), (int)android.util.FloatMath.ceil(horizontalPadding + sTempRect.right + thick)
							, (int)android.util.FloatMath.ceil(verticalPadding + sTempRect.bottom + thick));
					}
				}
				else
				{
					{
						for (int i = 0; i < mCursorCount; i++)
						{
							android.graphics.Rect bounds = mCursorDrawable[i].getBounds();
							invalidate(bounds.left + horizontalPadding, bounds.top + verticalPadding, bounds.
								right + horizontalPadding, bounds.bottom + verticalPadding);
						}
					}
				}
			}
		}

		private void invalidateCursor()
		{
			int where = getSelectionEnd();
			invalidateCursor(where, where, where);
		}

		private void invalidateCursor(int a, int b, int c)
		{
			if (mLayout == null)
			{
				invalidate();
			}
			else
			{
				if (a >= 0 || b >= 0 || c >= 0)
				{
					int first = System.Math.Min(System.Math.Min(a, b), c);
					int last = System.Math.Max(System.Math.Max(a, b), c);
					int line = mLayout.getLineForOffset(first);
					int top = mLayout.getLineTop(line);
					// This is ridiculous, but the descent from the line above
					// can hang down into the line we really want to redraw,
					// so we have to invalidate part of the line above to make
					// sure everything that needs to be redrawn really is.
					// (But not the whole line above, because that would cause
					// the same problem with the descenders on the line above it!)
					if (line > 0)
					{
						top -= mLayout.getLineDescent(line - 1);
					}
					int line2;
					if (first == last)
					{
						line2 = line;
					}
					else
					{
						line2 = mLayout.getLineForOffset(last);
					}
					int bottom = mLayout.getLineTop(line2 + 1);
					int horizontalPadding = getCompoundPaddingLeft();
					int verticalPadding = getExtendedPaddingTop() + getVerticalOffset(true);
					{
						// If used, the cursor drawables can have an arbitrary dimension that can go beyond
						// the invalidated lines specified above.
						for (int i = 0; i < mCursorCount; i++)
						{
							android.graphics.Rect bounds = mCursorDrawable[i].getBounds();
							top = System.Math.Min(top, bounds.top);
							bottom = System.Math.Max(bottom, bounds.bottom);
						}
					}
					// Horizontal bounds are already full width, no need to update
					invalidate(horizontalPadding + mScrollX, top + verticalPadding, horizontalPadding
						 + mScrollX + getWidth() - getCompoundPaddingLeft() - getCompoundPaddingRight(), 
						bottom + verticalPadding);
				}
			}
		}

		private void registerForPreDraw()
		{
			android.view.ViewTreeObserver observer = getViewTreeObserver();
			if (mPreDrawState == PREDRAW_NOT_REGISTERED)
			{
				observer.addOnPreDrawListener(this);
				mPreDrawState = PREDRAW_PENDING;
			}
			else
			{
				if (mPreDrawState == PREDRAW_DONE)
				{
					mPreDrawState = PREDRAW_PENDING;
				}
			}
		}

		// else state is PREDRAW_PENDING, so keep waiting.
		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.ImplementsInterface(@"android.view.ViewTreeObserver.OnPreDrawListener")]
		public virtual bool onPreDraw()
		{
			if (mPreDrawState != PREDRAW_PENDING)
			{
				return true;
			}
			if (mLayout == null)
			{
				assumeLayout();
			}
			bool changed = false;
			if (mMovement != null)
			{
				int curs = getSelectionEnd();
				// Do not create the controller if it is not already created.
				if (mSelectionModifierCursorController != null && mSelectionModifierCursorController
					.isSelectionStartDragged())
				{
					curs = getSelectionStart();
				}
				if (curs < 0 && (mGravity & android.view.Gravity.VERTICAL_GRAVITY_MASK) == android.view.Gravity
					.BOTTOM)
				{
					curs = mText.Length;
				}
				if (curs >= 0)
				{
					changed = bringPointIntoView(curs);
				}
			}
			else
			{
				changed = bringTextIntoView();
			}
			// This has to be checked here since:
			// - onFocusChanged cannot start it when focus is given to a view with selected text (after
			//   a screen rotation) since layout is not yet initialized at that point.
			if (mCreatedWithASelection)
			{
				startSelectionActionMode();
				mCreatedWithASelection = false;
			}
			// Phone specific code (there is no ExtractEditText on tablets).
			// ExtractEditText does not call onFocus when it is displayed, and mHasSelectionOnFocus can
			// not be set. Do the test here instead.
			if (this is android.inputmethodservice.ExtractEditText && hasSelection())
			{
				startSelectionActionMode();
			}
			mPreDrawState = PREDRAW_DONE;
			return !changed;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onAttachedToWindow()
		{
			base.onAttachedToWindow();
			mTemporaryDetach = false;
			if (mShowErrorAfterAttach)
			{
				showError();
				mShowErrorAfterAttach = false;
			}
			android.view.ViewTreeObserver observer = getViewTreeObserver();
			// No need to create the controller.
			// The get method will add the listener on controller creation.
			if (mInsertionPointCursorController != null)
			{
				observer.addOnTouchModeChangeListener(mInsertionPointCursorController);
			}
			if (mSelectionModifierCursorController != null)
			{
				observer.addOnTouchModeChangeListener(mSelectionModifierCursorController);
			}
			// Resolve drawables as the layout direction has been resolved
			resolveDrawables();
			updateSpellCheckSpans(0, mText.Length);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onDetachedFromWindow()
		{
			base.onDetachedFromWindow();
			android.view.ViewTreeObserver observer = getViewTreeObserver();
			if (mPreDrawState != PREDRAW_NOT_REGISTERED)
			{
				observer.removeOnPreDrawListener(this);
				mPreDrawState = PREDRAW_NOT_REGISTERED;
			}
			if (mError != null)
			{
				hideError();
			}
			if (mBlink != null)
			{
				mBlink.removeCallbacks(mBlink);
			}
			if (mInsertionPointCursorController != null)
			{
				mInsertionPointCursorController.onDetached();
			}
			if (mSelectionModifierCursorController != null)
			{
				mSelectionModifierCursorController.onDetached();
			}
			hideControllers();
			resetResolvedDrawables();
			if (mSpellChecker != null)
			{
				mSpellChecker.closeSession();
				// Forces the creation of a new SpellChecker next time this window is created.
				// Will handle the cases where the settings has been changed in the meantime.
				mSpellChecker = null;
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override bool isPaddingOffsetRequired()
		{
			return mShadowRadius != 0 || mDrawables != null;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override int getLeftPaddingOffset()
		{
			return getCompoundPaddingLeft() - mPaddingLeft + (int)System.Math.Min(0, mShadowDx
				 - mShadowRadius);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override int getTopPaddingOffset()
		{
			return (int)System.Math.Min(0, mShadowDy - mShadowRadius);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override int getBottomPaddingOffset()
		{
			return (int)System.Math.Max(0, mShadowDy + mShadowRadius);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override int getRightPaddingOffset()
		{
			return -(getCompoundPaddingRight() - mPaddingRight) + (int)System.Math.Max(0, mShadowDx
				 + mShadowRadius);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override bool verifyDrawable(android.graphics.drawable.Drawable
			 who)
		{
			bool verified = base.verifyDrawable(who);
			if (!verified && mDrawables != null)
			{
				return who == mDrawables.mDrawableLeft || who == mDrawables.mDrawableTop || who ==
					 mDrawables.mDrawableRight || who == mDrawables.mDrawableBottom || who == mDrawables
					.mDrawableStart || who == mDrawables.mDrawableEnd;
			}
			return verified;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void jumpDrawablesToCurrentState()
		{
			base.jumpDrawablesToCurrentState();
			if (mDrawables != null)
			{
				if (mDrawables.mDrawableLeft != null)
				{
					mDrawables.mDrawableLeft.jumpToCurrentState();
				}
				if (mDrawables.mDrawableTop != null)
				{
					mDrawables.mDrawableTop.jumpToCurrentState();
				}
				if (mDrawables.mDrawableRight != null)
				{
					mDrawables.mDrawableRight.jumpToCurrentState();
				}
				if (mDrawables.mDrawableBottom != null)
				{
					mDrawables.mDrawableBottom.jumpToCurrentState();
				}
				if (mDrawables.mDrawableStart != null)
				{
					mDrawables.mDrawableStart.jumpToCurrentState();
				}
				if (mDrawables.mDrawableEnd != null)
				{
					mDrawables.mDrawableEnd.jumpToCurrentState();
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void invalidateDrawable(android.graphics.drawable.Drawable drawable
			)
		{
			if (verifyDrawable(drawable))
			{
				android.graphics.Rect dirty = drawable.getBounds();
				int scrollX = mScrollX;
				int scrollY = mScrollY;
				// IMPORTANT: The coordinates below are based on the coordinates computed
				// for each compound drawable in onDraw(). Make sure to update each section
				// accordingly.
				android.widget.TextView.Drawables drawables = mDrawables;
				if (drawables != null)
				{
					if (drawable == drawables.mDrawableLeft)
					{
						int compoundPaddingTop = getCompoundPaddingTop();
						int compoundPaddingBottom = getCompoundPaddingBottom();
						int vspace = mBottom - mTop - compoundPaddingBottom - compoundPaddingTop;
						scrollX += mPaddingLeft;
						scrollY += compoundPaddingTop + (vspace - drawables.mDrawableHeightLeft) / 2;
					}
					else
					{
						if (drawable == drawables.mDrawableRight)
						{
							int compoundPaddingTop = getCompoundPaddingTop();
							int compoundPaddingBottom = getCompoundPaddingBottom();
							int vspace = mBottom - mTop - compoundPaddingBottom - compoundPaddingTop;
							scrollX += (mRight - mLeft - mPaddingRight - drawables.mDrawableSizeRight);
							scrollY += compoundPaddingTop + (vspace - drawables.mDrawableHeightRight) / 2;
						}
						else
						{
							if (drawable == drawables.mDrawableTop)
							{
								int compoundPaddingLeft = getCompoundPaddingLeft();
								int compoundPaddingRight = getCompoundPaddingRight();
								int hspace = mRight - mLeft - compoundPaddingRight - compoundPaddingLeft;
								scrollX += compoundPaddingLeft + (hspace - drawables.mDrawableWidthTop) / 2;
								scrollY += mPaddingTop;
							}
							else
							{
								if (drawable == drawables.mDrawableBottom)
								{
									int compoundPaddingLeft = getCompoundPaddingLeft();
									int compoundPaddingRight = getCompoundPaddingRight();
									int hspace = mRight - mLeft - compoundPaddingRight - compoundPaddingLeft;
									scrollX += compoundPaddingLeft + (hspace - drawables.mDrawableWidthBottom) / 2;
									scrollY += (mBottom - mTop - mPaddingBottom - drawables.mDrawableSizeBottom);
								}
							}
						}
					}
				}
				invalidate(dirty.left + scrollX, dirty.top + scrollY, dirty.right + scrollX, dirty
					.bottom + scrollY);
			}
		}

		/// <hide></hide>
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override int getResolvedLayoutDirection(android.graphics.drawable.Drawable
			 who)
		{
			if (who == null)
			{
				return android.view.View.LAYOUT_DIRECTION_LTR;
			}
			if (mDrawables != null)
			{
				android.widget.TextView.Drawables drawables = mDrawables;
				if (who == drawables.mDrawableLeft || who == drawables.mDrawableRight || who == drawables
					.mDrawableTop || who == drawables.mDrawableBottom || who == drawables.mDrawableStart
					 || who == drawables.mDrawableEnd)
				{
					return getResolvedLayoutDirection();
				}
			}
			return base.getResolvedLayoutDirection(who);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override bool onSetAlpha(int alpha)
		{
			// Alpha is supported if and only if the drawing can be done in one pass.
			// TODO text with spans with a background color currently do not respect this alpha.
			if (getBackground() == null)
			{
				mCurrentAlpha = alpha;
				android.widget.TextView.Drawables dr = mDrawables;
				if (dr != null)
				{
					if (dr.mDrawableLeft != null)
					{
						dr.mDrawableLeft.mutate().setAlpha(alpha);
					}
					if (dr.mDrawableTop != null)
					{
						dr.mDrawableTop.mutate().setAlpha(alpha);
					}
					if (dr.mDrawableRight != null)
					{
						dr.mDrawableRight.mutate().setAlpha(alpha);
					}
					if (dr.mDrawableBottom != null)
					{
						dr.mDrawableBottom.mutate().setAlpha(alpha);
					}
					if (dr.mDrawableStart != null)
					{
						dr.mDrawableStart.mutate().setAlpha(alpha);
					}
					if (dr.mDrawableEnd != null)
					{
						dr.mDrawableEnd.mutate().setAlpha(alpha);
					}
				}
				return true;
			}
			mCurrentAlpha = 255;
			return false;
		}

		/// <summary>
		/// When a TextView is used to display a useful piece of information to the user (such as a
		/// contact's address), it should be made selectable, so that the user can select and copy this
		/// content.
		/// </summary>
		/// <remarks>
		/// When a TextView is used to display a useful piece of information to the user (such as a
		/// contact's address), it should be made selectable, so that the user can select and copy this
		/// content.
		/// Use
		/// <see cref="setTextIsSelectable(bool)">setTextIsSelectable(bool)</see>
		/// or the
		/// <see cref="android.R.styleable.TextView_textIsSelectable">android.R.styleable.TextView_textIsSelectable
		/// 	</see>
		/// XML attribute to make this TextView
		/// selectable (text is not selectable by default).
		/// Note that this method simply returns the state of this flag. Although this flag has to be set
		/// in order to select text in non-editable TextView, the content of an
		/// <see cref="EditText">EditText</see>
		/// can
		/// always be selected, independently of the value of this flag.
		/// </remarks>
		/// <returns>True if the text displayed in this TextView can be selected by the user.
		/// 	</returns>
		/// <attr>ref android.R.styleable#TextView_textIsSelectable</attr>
		public virtual bool isTextSelectable()
		{
			return mTextIsSelectable;
		}

		/// <summary>Sets whether or not (default) the content of this view is selectable by the user.
		/// 	</summary>
		/// <remarks>
		/// Sets whether or not (default) the content of this view is selectable by the user.
		/// Note that this methods affect the
		/// <see cref="android.view.View.setFocusable(bool)">android.view.View.setFocusable(bool)
		/// 	</see>
		/// ,
		/// <see cref="android.view.View.setFocusableInTouchMode(bool)">android.view.View.setFocusableInTouchMode(bool)
		/// 	</see>
		/// 
		/// <see cref="android.view.View.setClickable(bool)">android.view.View.setClickable(bool)
		/// 	</see>
		/// and
		/// <see cref="android.view.View.setLongClickable(bool)">android.view.View.setLongClickable(bool)
		/// 	</see>
		/// states and you may want to restore these if they were
		/// customized.
		/// See
		/// <see cref="isTextSelectable()">isTextSelectable()</see>
		/// for details.
		/// </remarks>
		/// <param name="selectable">Whether or not the content of this TextView should be selectable.
		/// 	</param>
		public virtual void setTextIsSelectable(bool selectable)
		{
			if (mTextIsSelectable == selectable)
			{
				return;
			}
			mTextIsSelectable = selectable;
			setFocusableInTouchMode(selectable);
			setFocusable(selectable);
			setClickable(selectable);
			setLongClickable(selectable);
			// mInputType is already EditorInfo.TYPE_NULL and mInput is null;
			setMovementMethod(selectable ? android.text.method.ArrowKeyMovementMethod.getInstance
				() : null);
			setText(getText(), selectable ? android.widget.TextView.BufferType.SPANNABLE : android.widget.TextView
				.BufferType.NORMAL);
			// Called by setText above, but safer in case of future code changes
			prepareCursorControllers();
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override int[] onCreateDrawableState(int extraSpace)
		{
			int[] drawableState;
			if (mSingleLine)
			{
				drawableState = base.onCreateDrawableState(extraSpace);
			}
			else
			{
				drawableState = base.onCreateDrawableState(extraSpace + 1);
				mergeDrawableStates(drawableState, MULTILINE_STATE_SET);
			}
			if (mTextIsSelectable)
			{
				// Disable pressed state, which was introduced when TextView was made clickable.
				// Prevents text color change.
				// setClickable(false) would have a similar effect, but it also disables focus changes
				// and long press actions, which are both needed by text selection.
				int length_1 = drawableState.Length;
				{
					for (int i = 0; i < length_1; i++)
					{
						if (drawableState[i] == android.R.attr.state_pressed)
						{
							int[] nonPressedState = new int[length_1 - 1];
							System.Array.Copy(drawableState, 0, nonPressedState, 0, i);
							System.Array.Copy(drawableState, i + 1, nonPressedState, i, length_1 - i - 1);
							return nonPressedState;
						}
					}
				}
			}
			return drawableState;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onDraw(android.graphics.Canvas canvas)
		{
			if (mPreDrawState == PREDRAW_DONE)
			{
				android.view.ViewTreeObserver observer = getViewTreeObserver();
				observer.removeOnPreDrawListener(this);
				mPreDrawState = PREDRAW_NOT_REGISTERED;
			}
			if (mCurrentAlpha <= android.view.ViewConfiguration.ALPHA_THRESHOLD_INT)
			{
				return;
			}
			restartMarqueeIfNeeded();
			// Draw the background for this view
			base.onDraw(canvas);
			int compoundPaddingLeft = getCompoundPaddingLeft();
			int compoundPaddingTop = getCompoundPaddingTop();
			int compoundPaddingRight = getCompoundPaddingRight();
			int compoundPaddingBottom = getCompoundPaddingBottom();
			int scrollX = mScrollX;
			int scrollY = mScrollY;
			int right = mRight;
			int left = mLeft;
			int bottom = mBottom;
			int top = mTop;
			android.widget.TextView.Drawables dr = mDrawables;
			if (dr != null)
			{
				int vspace = bottom - top - compoundPaddingBottom - compoundPaddingTop;
				int hspace = right - left - compoundPaddingRight - compoundPaddingLeft;
				// IMPORTANT: The coordinates computed are also used in invalidateDrawable()
				// Make sure to update invalidateDrawable() when changing this code.
				if (dr.mDrawableLeft != null)
				{
					canvas.save();
					canvas.translate(scrollX + mPaddingLeft, scrollY + compoundPaddingTop + (vspace -
						 dr.mDrawableHeightLeft) / 2);
					dr.mDrawableLeft.draw(canvas);
					canvas.restore();
				}
				// IMPORTANT: The coordinates computed are also used in invalidateDrawable()
				// Make sure to update invalidateDrawable() when changing this code.
				if (dr.mDrawableRight != null)
				{
					canvas.save();
					canvas.translate(scrollX + right - left - mPaddingRight - dr.mDrawableSizeRight, 
						scrollY + compoundPaddingTop + (vspace - dr.mDrawableHeightRight) / 2);
					dr.mDrawableRight.draw(canvas);
					canvas.restore();
				}
				// IMPORTANT: The coordinates computed are also used in invalidateDrawable()
				// Make sure to update invalidateDrawable() when changing this code.
				if (dr.mDrawableTop != null)
				{
					canvas.save();
					canvas.translate(scrollX + compoundPaddingLeft + (hspace - dr.mDrawableWidthTop) 
						/ 2, scrollY + mPaddingTop);
					dr.mDrawableTop.draw(canvas);
					canvas.restore();
				}
				// IMPORTANT: The coordinates computed are also used in invalidateDrawable()
				// Make sure to update invalidateDrawable() when changing this code.
				if (dr.mDrawableBottom != null)
				{
					canvas.save();
					canvas.translate(scrollX + compoundPaddingLeft + (hspace - dr.mDrawableWidthBottom
						) / 2, scrollY + bottom - top - mPaddingBottom - dr.mDrawableSizeBottom);
					dr.mDrawableBottom.draw(canvas);
					canvas.restore();
				}
			}
			int color = mCurTextColor;
			if (mLayout == null)
			{
				assumeLayout();
			}
			android.text.Layout layout_1 = mLayout;
			int cursorcolor = color;
			if (mHint != null && mText.Length == 0)
			{
				if (mHintTextColor != null)
				{
					color = mCurHintTextColor;
				}
				layout_1 = mHintLayout;
			}
			mTextPaint.setColor(color);
			if (mCurrentAlpha != 255)
			{
				// If set, the alpha will override the color's alpha. Multiply the alphas.
				mTextPaint.setAlpha((mCurrentAlpha * android.graphics.Color.alpha(color)) / 255);
			}
			mTextPaint.drawableState = getDrawableState();
			canvas.save();
			int extendedPaddingTop = getExtendedPaddingTop();
			int extendedPaddingBottom = getExtendedPaddingBottom();
			float clipLeft = compoundPaddingLeft + scrollX;
			float clipTop = extendedPaddingTop + scrollY;
			float clipRight = right - left - compoundPaddingRight + scrollX;
			float clipBottom = bottom - top - extendedPaddingBottom + scrollY;
			if (mShadowRadius != 0)
			{
				clipLeft += System.Math.Min(0, mShadowDx - mShadowRadius);
				clipRight += System.Math.Max(0, mShadowDx + mShadowRadius);
				clipTop += System.Math.Min(0, mShadowDy - mShadowRadius);
				clipBottom += System.Math.Max(0, mShadowDy + mShadowRadius);
			}
			canvas.clipRect(clipLeft, clipTop, clipRight, clipBottom);
			int voffsetText = 0;
			int voffsetCursor = 0;
			{
				// translate in by our padding
				if ((mGravity & android.view.Gravity.VERTICAL_GRAVITY_MASK) != android.view.Gravity
					.TOP)
				{
					voffsetText = getVerticalOffset(false);
					voffsetCursor = getVerticalOffset(true);
				}
				canvas.translate(compoundPaddingLeft, extendedPaddingTop + voffsetText);
			}
			int layoutDirection = getResolvedLayoutDirection();
			int absoluteGravity = android.view.Gravity.getAbsoluteGravity(mGravity, layoutDirection
				);
			if (mEllipsize == android.text.TextUtils.TruncateAt.MARQUEE && mMarqueeFadeMode !=
				 MARQUEE_FADE_SWITCH_SHOW_ELLIPSIS)
			{
				if (!mSingleLine && getLineCount() == 1 && canMarquee() && (absoluteGravity & android.view.Gravity
					.HORIZONTAL_GRAVITY_MASK) != android.view.Gravity.LEFT)
				{
					canvas.translate(mLayout.getLineRight(0) - (mRight - mLeft - getCompoundPaddingLeft
						() - getCompoundPaddingRight()), 0.0f);
				}
				if (mMarquee != null && mMarquee.isRunning())
				{
					canvas.translate(-mMarquee.mScroll, 0.0f);
				}
			}
			android.graphics.Path highlight = null;
			int selStart = -1;
			int selEnd = -1;
			bool drawCursor_1 = false;
			//  If there is no movement method, then there can be no selection.
			//  Check that first and attempt to skip everything having to do with
			//  the cursor.
			//  XXX This is not strictly true -- a program could set the
			//  selection manually if it really wanted to.
			if (mMovement != null && (isFocused() || isPressed()))
			{
				selStart = getSelectionStart();
				selEnd = getSelectionEnd();
				if (selStart >= 0)
				{
					if (mHighlightPath == null)
					{
						mHighlightPath = new android.graphics.Path();
					}
					if (selStart == selEnd)
					{
						if (isCursorVisible() && (android.os.SystemClock.uptimeMillis() - mShowCursor) % 
							(2 * BLINK) < BLINK)
						{
							if (mHighlightPathBogus)
							{
								mHighlightPath.reset();
								mLayout.getCursorPath(selStart, mHighlightPath, mText);
								updateCursorsPositions();
								mHighlightPathBogus = false;
							}
							// XXX should pass to skin instead of drawing directly
							mHighlightPaint.setColor(cursorcolor);
							if (mCurrentAlpha != 255)
							{
								mHighlightPaint.setAlpha((mCurrentAlpha * android.graphics.Color.alpha(cursorcolor
									)) / 255);
							}
							mHighlightPaint.setStyle(android.graphics.Paint.Style.STROKE);
							highlight = mHighlightPath;
							drawCursor_1 = mCursorCount > 0;
						}
					}
					else
					{
						if (textCanBeSelected())
						{
							if (mHighlightPathBogus)
							{
								mHighlightPath.reset();
								mLayout.getSelectionPath(selStart, selEnd, mHighlightPath);
								mHighlightPathBogus = false;
							}
							// XXX should pass to skin instead of drawing directly
							mHighlightPaint.setColor(mHighlightColor);
							if (mCurrentAlpha != 255)
							{
								mHighlightPaint.setAlpha((mCurrentAlpha * android.graphics.Color.alpha(mHighlightColor
									)) / 255);
							}
							mHighlightPaint.setStyle(android.graphics.Paint.Style.FILL);
							highlight = mHighlightPath;
						}
					}
				}
			}
			android.widget.TextView.InputMethodState ims = mInputMethodState;
			int cursorOffsetVertical = voffsetCursor - voffsetText;
			if (ims != null && ims.mBatchEditNesting == 0)
			{
				android.view.inputmethod.InputMethodManager imm = android.view.inputmethod.InputMethodManager
					.peekInstance();
				if (imm != null)
				{
					if (imm.isActive(this))
					{
						bool reported = false;
						if (ims.mContentChanged || ims.mSelectionModeChanged)
						{
							// We are in extract mode and the content has changed
							// in some way... just report complete new text to the
							// input method.
							reported = reportExtractedText();
						}
						if (!reported && highlight != null)
						{
							int candStart = -1;
							int candEnd = -1;
							if (mText is android.text.Spannable)
							{
								android.text.Spannable sp = (android.text.Spannable)mText;
								candStart = android.widget.@internal.EditableInputConnection.getComposingSpanStart
									(sp);
								candEnd = android.widget.@internal.EditableInputConnection.getComposingSpanEnd(sp
									);
							}
							imm.updateSelection(this, selStart, selEnd, candStart, candEnd);
						}
					}
					if (imm.isWatchingCursor(this) && highlight != null)
					{
						highlight.computeBounds(ims.mTmpRectF, true);
						ims.mTmpOffset[0] = ims.mTmpOffset[1] = 0;
						canvas.getMatrix().mapPoints(ims.mTmpOffset);
						ims.mTmpRectF.offset(ims.mTmpOffset[0], ims.mTmpOffset[1]);
						ims.mTmpRectF.offset(0, cursorOffsetVertical);
						ims.mCursorRectInWindow.set((int)(ims.mTmpRectF.left + 0.5), (int)(ims.mTmpRectF.
							top + 0.5), (int)(ims.mTmpRectF.right + 0.5), (int)(ims.mTmpRectF.bottom + 0.5));
						imm.updateCursor(this, ims.mCursorRectInWindow.left, ims.mCursorRectInWindow.top, 
							ims.mCursorRectInWindow.right, ims.mCursorRectInWindow.bottom);
					}
				}
			}
			if (mCorrectionHighlighter != null)
			{
				mCorrectionHighlighter.draw(canvas, cursorOffsetVertical);
			}
			if (drawCursor_1)
			{
				drawCursor(canvas, cursorOffsetVertical);
				// Rely on the drawable entirely, do not draw the cursor line.
				// Has to be done after the IMM related code above which relies on the highlight.
				highlight = null;
			}
			layout_1.draw(canvas, highlight, mHighlightPaint, cursorOffsetVertical);
			if (mMarquee != null && mMarquee.shouldDrawGhost())
			{
				canvas.translate((int)mMarquee.getGhostOffset(), 0.0f);
				layout_1.draw(canvas, highlight, mHighlightPaint, cursorOffsetVertical);
			}
			canvas.restore();
		}

		private void updateCursorsPositions()
		{
			if (mCursorDrawableRes == 0)
			{
				mCursorCount = 0;
				return;
			}
			int offset = getSelectionStart();
			int line = mLayout.getLineForOffset(offset);
			int top = mLayout.getLineTop(line);
			int bottom = mLayout.getLineTop(line + 1);
			mCursorCount = mLayout.isLevelBoundary(offset) ? 2 : 1;
			int middle = bottom;
			if (mCursorCount == 2)
			{
				// Similar to what is done in {@link Layout.#getCursorPath(int, Path, CharSequence)}
				middle = (top + bottom) >> 1;
			}
			updateCursorPosition(0, top, middle, mLayout.getPrimaryHorizontal(offset));
			if (mCursorCount == 2)
			{
				updateCursorPosition(1, middle, bottom, mLayout.getSecondaryHorizontal(offset));
			}
		}

		private void updateCursorPosition(int cursorIndex, int top, int bottom, float horizontal
			)
		{
			if (mCursorDrawable[cursorIndex] == null)
			{
				mCursorDrawable[cursorIndex] = mContext.getResources().getDrawable(mCursorDrawableRes
					);
			}
			if (mTempRect == null)
			{
				mTempRect = new android.graphics.Rect();
			}
			mCursorDrawable[cursorIndex].getPadding(mTempRect);
			int width = mCursorDrawable[cursorIndex].getIntrinsicWidth();
			horizontal = System.Math.Max(0.5f, horizontal - 0.5f);
			int left = (int)(horizontal) - mTempRect.left;
			mCursorDrawable[cursorIndex].setBounds(left, top - mTempRect.top, left + width, bottom
				 + mTempRect.bottom);
		}

		private void drawCursor(android.graphics.Canvas canvas, int cursorOffsetVertical)
		{
			bool translate = cursorOffsetVertical != 0;
			if (translate)
			{
				canvas.translate(0, cursorOffsetVertical);
			}
			{
				for (int i = 0; i < mCursorCount; i++)
				{
					mCursorDrawable[i].draw(canvas);
				}
			}
			if (translate)
			{
				canvas.translate(0, -cursorOffsetVertical);
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void getFocusedRect(android.graphics.Rect r)
		{
			if (mLayout == null)
			{
				base.getFocusedRect(r);
				return;
			}
			int selEnd = getSelectionEnd();
			if (selEnd < 0)
			{
				base.getFocusedRect(r);
				return;
			}
			int selStart = getSelectionStart();
			if (selStart < 0 || selStart >= selEnd)
			{
				int line = mLayout.getLineForOffset(selEnd);
				r.top = mLayout.getLineTop(line);
				r.bottom = mLayout.getLineBottom(line);
				r.left = (int)mLayout.getPrimaryHorizontal(selEnd) - 2;
				r.right = r.left + 4;
			}
			else
			{
				int lineStart = mLayout.getLineForOffset(selStart);
				int lineEnd = mLayout.getLineForOffset(selEnd);
				r.top = mLayout.getLineTop(lineStart);
				r.bottom = mLayout.getLineBottom(lineEnd);
				if (lineStart == lineEnd)
				{
					r.left = (int)mLayout.getPrimaryHorizontal(selStart);
					r.right = (int)mLayout.getPrimaryHorizontal(selEnd);
				}
				else
				{
					// Selection extends across multiple lines -- the focused
					// rect covers the entire width.
					if (mHighlightPath == null)
					{
						mHighlightPath = new android.graphics.Path();
					}
					if (mHighlightPathBogus)
					{
						mHighlightPath.reset();
						mLayout.getSelectionPath(selStart, selEnd, mHighlightPath);
						mHighlightPathBogus = false;
					}
					lock (sTempRect)
					{
						mHighlightPath.computeBounds(sTempRect, true);
						r.left = (int)sTempRect.left - 1;
						r.right = (int)sTempRect.right + 1;
					}
				}
			}
			// Adjust for padding and gravity.
			int paddingLeft = getCompoundPaddingLeft();
			int paddingTop = getExtendedPaddingTop();
			if ((mGravity & android.view.Gravity.VERTICAL_GRAVITY_MASK) != android.view.Gravity
				.TOP)
			{
				paddingTop += getVerticalOffset(false);
			}
			r.offset(paddingLeft, paddingTop);
		}

		/// <summary>
		/// Return the number of lines of text, or 0 if the internal Layout has not
		/// been built.
		/// </summary>
		/// <remarks>
		/// Return the number of lines of text, or 0 if the internal Layout has not
		/// been built.
		/// </remarks>
		public virtual int getLineCount()
		{
			return mLayout != null ? mLayout.getLineCount() : 0;
		}

		/// <summary>
		/// Return the baseline for the specified line (0...getLineCount() - 1)
		/// If bounds is not null, return the top, left, right, bottom extents
		/// of the specified line in it.
		/// </summary>
		/// <remarks>
		/// Return the baseline for the specified line (0...getLineCount() - 1)
		/// If bounds is not null, return the top, left, right, bottom extents
		/// of the specified line in it. If the internal Layout has not been built,
		/// return 0 and set bounds to (0, 0, 0, 0)
		/// </remarks>
		/// <param name="line">which line to examine (0..getLineCount() - 1)</param>
		/// <param name="bounds">Optional. If not null, it returns the extent of the line</param>
		/// <returns>the Y-coordinate of the baseline</returns>
		public virtual int getLineBounds(int line, android.graphics.Rect bounds)
		{
			if (mLayout == null)
			{
				if (bounds != null)
				{
					bounds.set(0, 0, 0, 0);
				}
				return 0;
			}
			else
			{
				int baseline = mLayout.getLineBounds(line, bounds);
				int voffset = getExtendedPaddingTop();
				if ((mGravity & android.view.Gravity.VERTICAL_GRAVITY_MASK) != android.view.Gravity
					.TOP)
				{
					voffset += getVerticalOffset(true);
				}
				if (bounds != null)
				{
					bounds.offset(getCompoundPaddingLeft(), voffset);
				}
				return baseline + voffset;
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override int getBaseline()
		{
			if (mLayout == null)
			{
				return base.getBaseline();
			}
			int voffset = 0;
			if ((mGravity & android.view.Gravity.VERTICAL_GRAVITY_MASK) != android.view.Gravity
				.TOP)
			{
				voffset = getVerticalOffset(true);
			}
			return getExtendedPaddingTop() + voffset + mLayout.getLineBaseline(0);
		}

		/// <hide></hide>
		/// <param name="offsetRequired"></param>
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override int getFadeTop(bool offsetRequired)
		{
			if (mLayout == null)
			{
				return 0;
			}
			int voffset = 0;
			if ((mGravity & android.view.Gravity.VERTICAL_GRAVITY_MASK) != android.view.Gravity
				.TOP)
			{
				voffset = getVerticalOffset(true);
			}
			if (offsetRequired)
			{
				voffset += getTopPaddingOffset();
			}
			return getExtendedPaddingTop() + voffset;
		}

		/// <hide></hide>
		/// <param name="offsetRequired"></param>
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override int getFadeHeight(bool offsetRequired)
		{
			return mLayout != null ? mLayout.getHeight() : 0;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool onKeyPreIme(int keyCode, android.view.KeyEvent @event)
		{
			if (keyCode == android.view.KeyEvent.KEYCODE_BACK)
			{
				bool isInSelectionMode = mSelectionActionMode != null;
				if (isInSelectionMode)
				{
					if (@event.getAction() == android.view.KeyEvent.ACTION_DOWN && @event.getRepeatCount
						() == 0)
					{
						android.view.KeyEvent.DispatcherState state = getKeyDispatcherState();
						if (state != null)
						{
							state.startTracking(@event, this);
						}
						return true;
					}
					else
					{
						if (@event.getAction() == android.view.KeyEvent.ACTION_UP)
						{
							android.view.KeyEvent.DispatcherState state = getKeyDispatcherState();
							if (state != null)
							{
								state.handleUpEvent(@event);
							}
							if (@event.isTracking() && !@event.isCanceled())
							{
								if (isInSelectionMode)
								{
									stopSelectionActionMode();
									return true;
								}
							}
						}
					}
				}
			}
			return base.onKeyPreIme(keyCode, @event);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool onKeyDown(int keyCode, android.view.KeyEvent @event)
		{
			int which = doKeyDown(keyCode, @event, null);
			if (which == 0)
			{
				// Go through default dispatching.
				return base.onKeyDown(keyCode, @event);
			}
			return true;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool onKeyMultiple(int keyCode, int repeatCount, android.view.KeyEvent
			 @event)
		{
			android.view.KeyEvent down = android.view.KeyEvent.changeAction(@event, android.view.KeyEvent
				.ACTION_DOWN);
			int which = doKeyDown(keyCode, down, @event);
			if (which == 0)
			{
				// Go through default dispatching.
				return base.onKeyMultiple(keyCode, repeatCount, @event);
			}
			if (which == -1)
			{
				// Consumed the whole thing.
				return true;
			}
			repeatCount--;
			// We are going to dispatch the remaining events to either the input
			// or movement method.  To do this, we will just send a repeated stream
			// of down and up events until we have done the complete repeatCount.
			// It would be nice if those interfaces had an onKeyMultiple() method,
			// but adding that is a more complicated change.
			android.view.KeyEvent up = android.view.KeyEvent.changeAction(@event, android.view.KeyEvent
				.ACTION_UP);
			if (which == 1)
			{
				mInput.onKeyUp(this, (android.text.Editable)mText, keyCode, up);
				while (--repeatCount > 0)
				{
					mInput.onKeyDown(this, (android.text.Editable)mText, keyCode, down);
					mInput.onKeyUp(this, (android.text.Editable)mText, keyCode, up);
				}
				hideErrorIfUnchanged();
			}
			else
			{
				if (which == 2)
				{
					mMovement.onKeyUp(this, (android.text.Spannable)mText, keyCode, up);
					while (--repeatCount > 0)
					{
						mMovement.onKeyDown(this, (android.text.Spannable)mText, keyCode, down);
						mMovement.onKeyUp(this, (android.text.Spannable)mText, keyCode, up);
					}
				}
			}
			return true;
		}

		/// <summary>
		/// Returns true if pressing ENTER in this field advances focus instead
		/// of inserting the character.
		/// </summary>
		/// <remarks>
		/// Returns true if pressing ENTER in this field advances focus instead
		/// of inserting the character.  This is true mostly in single-line fields,
		/// but also in mail addresses and subjects which will display on multiple
		/// lines but where it doesn't make sense to insert newlines.
		/// </remarks>
		private bool shouldAdvanceFocusOnEnter()
		{
			if (mInput == null)
			{
				return false;
			}
			if (mSingleLine)
			{
				return true;
			}
			if ((mInputType & android.text.InputTypeClass.TYPE_MASK_CLASS) == android.text.InputTypeClass.TYPE_CLASS_TEXT)
			{
				int variation = mInputType & android.text.InputTypeClass.TYPE_MASK_VARIATION;
				if (variation == android.text.InputTypeClass.TYPE_TEXT_VARIATION_EMAIL_ADDRESS ||
					 variation == android.text.InputTypeClass.TYPE_TEXT_VARIATION_EMAIL_SUBJECT)
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Returns true if pressing TAB in this field advances focus instead
		/// of inserting the character.
		/// </summary>
		/// <remarks>
		/// Returns true if pressing TAB in this field advances focus instead
		/// of inserting the character.  Insert tabs only in multi-line editors.
		/// </remarks>
		private bool shouldAdvanceFocusOnTab()
		{
			if (mInput != null && !mSingleLine)
			{
				if ((mInputType & android.text.InputTypeClass.TYPE_MASK_CLASS) == android.text.InputTypeClass.TYPE_CLASS_TEXT)
				{
					int variation = mInputType & android.text.InputTypeClass.TYPE_MASK_VARIATION;
					if (variation == android.text.InputTypeClass.TYPE_TEXT_FLAG_IME_MULTI_LINE || variation
						 == android.text.InputTypeClass.TYPE_TEXT_FLAG_MULTI_LINE)
					{
						return false;
					}
				}
			}
			return true;
		}

		private int doKeyDown(int keyCode, android.view.KeyEvent @event, android.view.KeyEvent
			 otherEvent)
		{
			if (!isEnabled())
			{
				return 0;
			}
			switch (keyCode)
			{
				case android.view.KeyEvent.KEYCODE_ENTER:
				{
					mEnterKeyIsDown = true;
					if (@event.hasNoModifiers())
					{
						// When mInputContentType is set, we know that we are
						// running in a "modern" cupcake environment, so don't need
						// to worry about the application trying to capture
						// enter key events.
						if (mInputContentType != null)
						{
							// If there is an action listener, given them a
							// chance to consume the event.
							if (mInputContentType.onEditorActionListener != null && mInputContentType.onEditorActionListener
								.onEditorAction(this, android.view.inputmethod.EditorInfo.IME_NULL, @event))
							{
								mInputContentType.enterDown = true;
								// We are consuming the enter key for them.
								return -1;
							}
						}
						// If our editor should move focus when enter is pressed, or
						// this is a generated event from an IME action button, then
						// don't let it be inserted into the text.
						if ((@event.getFlags() & android.view.KeyEvent.FLAG_EDITOR_ACTION) != 0 || shouldAdvanceFocusOnEnter
							())
						{
							if (mOnClickListener != null)
							{
								return 0;
							}
							return -1;
						}
					}
					break;
				}

				case android.view.KeyEvent.KEYCODE_DPAD_CENTER:
				{
					mDPadCenterIsDown = true;
					if (@event.hasNoModifiers())
					{
						if (shouldAdvanceFocusOnEnter())
						{
							return 0;
						}
					}
					break;
				}

				case android.view.KeyEvent.KEYCODE_TAB:
				{
					if (@event.hasNoModifiers() || @event.hasModifiers(android.view.KeyEvent.META_SHIFT_ON
						))
					{
						if (shouldAdvanceFocusOnTab())
						{
							return 0;
						}
					}
					break;
				}

				case android.view.KeyEvent.KEYCODE_BACK:
				{
					// Has to be done on key down (and not on key up) to correctly be intercepted.
					if (mSelectionActionMode != null)
					{
						stopSelectionActionMode();
						return -1;
					}
					break;
				}
			}
			if (mInput != null)
			{
				resetErrorChangedFlag();
				bool doDown = true;
				if (otherEvent != null)
				{
					try
					{
						beginBatchEdit();
						bool handled = mInput.onKeyOther(this, (android.text.Editable)mText, otherEvent);
						hideErrorIfUnchanged();
						doDown = false;
						if (handled)
						{
							return -1;
						}
					}
					catch (java.lang.AbstractMethodError)
					{
					}
					finally
					{
						// onKeyOther was added after 1.0, so if it isn't
						// implemented we need to try to dispatch as a regular down.
						endBatchEdit();
					}
				}
				if (doDown)
				{
					beginBatchEdit();
					bool handled = mInput.onKeyDown(this, (android.text.Editable)mText, keyCode, @event
						);
					endBatchEdit();
					hideErrorIfUnchanged();
					if (handled)
					{
						return 1;
					}
				}
			}
			// bug 650865: sometimes we get a key event before a layout.
			// don't try to move around if we don't know the layout.
			if (mMovement != null && mLayout != null)
			{
				bool doDown = true;
				if (otherEvent != null)
				{
					try
					{
						bool handled = mMovement.onKeyOther(this, (android.text.Spannable)mText, otherEvent
							);
						doDown = false;
						if (handled)
						{
							return -1;
						}
					}
					catch (java.lang.AbstractMethodError)
					{
					}
				}
				// onKeyOther was added after 1.0, so if it isn't
				// implemented we need to try to dispatch as a regular down.
				if (doDown)
				{
					if (mMovement.onKeyDown(this, (android.text.Spannable)mText, keyCode, @event))
					{
						return 2;
					}
				}
			}
			return 0;
		}

		/// <summary>
		/// Resets the mErrorWasChanged flag, so that future calls to
		/// <see cref="setError(java.lang.CharSequence)">setError(java.lang.CharSequence)</see>
		/// can be recorded.
		/// </summary>
		/// <hide></hide>
		public virtual void resetErrorChangedFlag()
		{
			mErrorWasChanged = false;
		}

		/// <hide></hide>
		public virtual void hideErrorIfUnchanged()
		{
			if (mError != null && !mErrorWasChanged)
			{
				setError(null, null);
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool onKeyUp(int keyCode, android.view.KeyEvent @event)
		{
			if (!isEnabled())
			{
				return base.onKeyUp(keyCode, @event);
			}
			switch (keyCode)
			{
				case android.view.KeyEvent.KEYCODE_DPAD_CENTER:
				{
					mDPadCenterIsDown = false;
					if (@event.hasNoModifiers())
					{
						if (mOnClickListener == null)
						{
							if (mMovement != null && mText is android.text.Editable && mLayout != null && onCheckIsTextEditor
								())
							{
								android.view.inputmethod.InputMethodManager imm = android.view.inputmethod.InputMethodManager
									.peekInstance();
								viewClicked(imm);
								if (imm != null)
								{
									imm.showSoftInput(this, 0);
								}
							}
						}
					}
					return base.onKeyUp(keyCode, @event);
				}

				case android.view.KeyEvent.KEYCODE_ENTER:
				{
					mEnterKeyIsDown = false;
					if (@event.hasNoModifiers())
					{
						if (mInputContentType != null && mInputContentType.onEditorActionListener != null
							 && mInputContentType.enterDown)
						{
							mInputContentType.enterDown = false;
							if (mInputContentType.onEditorActionListener.onEditorAction(this, android.view.inputmethod.EditorInfo
								.IME_NULL, @event))
							{
								return true;
							}
						}
						if ((@event.getFlags() & android.view.KeyEvent.FLAG_EDITOR_ACTION) != 0 || shouldAdvanceFocusOnEnter
							())
						{
							if (mOnClickListener == null)
							{
								android.view.View v = focusSearch(FOCUS_DOWN);
								if (v != null)
								{
									if (!v.requestFocus(FOCUS_DOWN))
									{
										throw new System.InvalidOperationException("focus search returned a view " + "that wasn't able to take focus!"
											);
									}
									base.onKeyUp(keyCode, @event);
									return true;
								}
								else
								{
									if ((@event.getFlags() & android.view.KeyEvent.FLAG_EDITOR_ACTION) != 0)
									{
										// No target for next focus, but make sure the IME
										// if this came from it.
										android.view.inputmethod.InputMethodManager imm = android.view.inputmethod.InputMethodManager
											.peekInstance();
										if (imm != null && imm.isActive(this))
										{
											imm.hideSoftInputFromWindow(getWindowToken(), 0);
										}
									}
								}
							}
						}
						return base.onKeyUp(keyCode, @event);
					}
					break;
				}
			}
			if (mInput != null)
			{
				if (mInput.onKeyUp(this, (android.text.Editable)mText, keyCode, @event))
				{
					return true;
				}
			}
			if (mMovement != null && mLayout != null)
			{
				if (mMovement.onKeyUp(this, (android.text.Spannable)mText, keyCode, @event))
				{
					return true;
				}
			}
			return base.onKeyUp(keyCode, @event);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool onCheckIsTextEditor()
		{
			return mInputType != android.text.InputTypeClass.TYPE_NULL;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override android.view.inputmethod.InputConnection onCreateInputConnection(
			android.view.inputmethod.EditorInfo outAttrs)
		{
			if (onCheckIsTextEditor() && isEnabled())
			{
				if (mInputMethodState == null)
				{
					mInputMethodState = new android.widget.TextView.InputMethodState(this);
				}
				outAttrs.inputType = mInputType;
				if (mInputContentType != null)
				{
					outAttrs.imeOptions = mInputContentType.imeOptions;
					outAttrs.privateImeOptions = mInputContentType.privateImeOptions;
					outAttrs.actionLabel = mInputContentType.imeActionLabel;
					outAttrs.actionId = mInputContentType.imeActionId;
					outAttrs.extras = mInputContentType.extras;
				}
				else
				{
					outAttrs.imeOptions = android.view.inputmethod.EditorInfo.IME_NULL;
				}
				if (focusSearch(FOCUS_DOWN) != null)
				{
					outAttrs.imeOptions |= android.view.inputmethod.EditorInfo.IME_FLAG_NAVIGATE_NEXT;
				}
				if (focusSearch(FOCUS_UP) != null)
				{
					outAttrs.imeOptions |= android.view.inputmethod.EditorInfo.IME_FLAG_NAVIGATE_PREVIOUS;
				}
				if ((outAttrs.imeOptions & android.view.inputmethod.EditorInfo.IME_MASK_ACTION) ==
					 android.view.inputmethod.EditorInfo.IME_ACTION_UNSPECIFIED)
				{
					if ((outAttrs.imeOptions & android.view.inputmethod.EditorInfo.IME_FLAG_NAVIGATE_NEXT
						) != 0)
					{
						// An action has not been set, but the enter key will move to
						// the next focus, so set the action to that.
						outAttrs.imeOptions |= android.view.inputmethod.EditorInfo.IME_ACTION_NEXT;
					}
					else
					{
						// An action has not been set, and there is no focus to move
						// to, so let's just supply a "done" action.
						outAttrs.imeOptions |= android.view.inputmethod.EditorInfo.IME_ACTION_DONE;
					}
					if (!shouldAdvanceFocusOnEnter())
					{
						outAttrs.imeOptions |= android.view.inputmethod.EditorInfo.IME_FLAG_NO_ENTER_ACTION;
					}
				}
				if (isMultilineInputType(outAttrs.inputType))
				{
					// Multi-line text editors should always show an enter key.
					outAttrs.imeOptions |= android.view.inputmethod.EditorInfo.IME_FLAG_NO_ENTER_ACTION;
				}
				outAttrs.hintText = mHint;
				if (mText is android.text.Editable)
				{
					android.view.inputmethod.InputConnection ic = new android.widget.@internal.EditableInputConnection
						(this);
					outAttrs.initialSelStart = getSelectionStart();
					outAttrs.initialSelEnd = getSelectionEnd();
					outAttrs.initialCapsMode = ic.getCursorCapsMode(mInputType);
					return ic;
				}
			}
			return null;
		}

		/// <summary>
		/// If this TextView contains editable content, extract a portion of it
		/// based on the information in <var>request</var> in to <var>outText</var>.
		/// </summary>
		/// <remarks>
		/// If this TextView contains editable content, extract a portion of it
		/// based on the information in <var>request</var> in to <var>outText</var>.
		/// </remarks>
		/// <returns>Returns true if the text was successfully extracted, else false.</returns>
		public virtual bool extractText(android.view.inputmethod.ExtractedTextRequest request
			, android.view.inputmethod.ExtractedText outText)
		{
			return extractTextInternal(request, EXTRACT_UNKNOWN, EXTRACT_UNKNOWN, EXTRACT_UNKNOWN
				, outText);
		}

		internal const int EXTRACT_NOTHING = -2;

		internal const int EXTRACT_UNKNOWN = -1;

		internal virtual bool extractTextInternal(android.view.inputmethod.ExtractedTextRequest
			 request, int partialStartOffset, int partialEndOffset, int delta, android.view.inputmethod.ExtractedText
			 outText)
		{
			java.lang.CharSequence content = mText;
			if (content != null)
			{
				if (partialStartOffset != EXTRACT_NOTHING)
				{
					int N = content.Length;
					if (partialStartOffset < 0)
					{
						outText.partialStartOffset = outText.partialEndOffset = -1;
						partialStartOffset = 0;
						partialEndOffset = N;
					}
					else
					{
						// Now use the delta to determine the actual amount of text
						// we need.
						partialEndOffset += delta;
						// Adjust offsets to ensure we contain full spans.
						if (content is android.text.Spanned)
						{
							android.text.Spanned spanned = (android.text.Spanned)content;
							object[] spans = spanned.getSpans<android.text.ParcelableSpan>(partialStartOffset
								, partialEndOffset);
							int i = spans.Length;
							while (i > 0)
							{
								i--;
								int j = spanned.getSpanStart(spans[i]);
								if (j < partialStartOffset)
								{
									partialStartOffset = j;
								}
								j = spanned.getSpanEnd(spans[i]);
								if (j > partialEndOffset)
								{
									partialEndOffset = j;
								}
							}
						}
						outText.partialStartOffset = partialStartOffset;
						outText.partialEndOffset = partialEndOffset - delta;
						if (partialStartOffset > N)
						{
							partialStartOffset = N;
						}
						else
						{
							if (partialStartOffset < 0)
							{
								partialStartOffset = 0;
							}
						}
						if (partialEndOffset > N)
						{
							partialEndOffset = N;
						}
						else
						{
							if (partialEndOffset < 0)
							{
								partialEndOffset = 0;
							}
						}
					}
					if ((request.flags & android.view.inputmethod.InputConnectionClass.GET_TEXT_WITH_STYLES
						) != 0)
					{
						outText.text = content.SubSequence(partialStartOffset, partialEndOffset);
					}
					else
					{
						outText.text = java.lang.CharSequenceProxy.Wrap(android.text.TextUtils.substring(
							content, partialStartOffset, partialEndOffset));
					}
				}
				else
				{
					outText.partialStartOffset = 0;
					outText.partialEndOffset = 0;
					outText.text = java.lang.CharSequenceProxy.Wrap(string.Empty);
				}
				outText.flags = 0;
				if (android.text.method.MetaKeyKeyListener.getMetaState(mText, android.text.method.MetaKeyKeyListener
					.META_SELECTING) != 0)
				{
					outText.flags |= android.view.inputmethod.ExtractedText.FLAG_SELECTING;
				}
				if (mSingleLine)
				{
					outText.flags |= android.view.inputmethod.ExtractedText.FLAG_SINGLE_LINE;
				}
				outText.startOffset = 0;
				outText.selectionStart = getSelectionStart();
				outText.selectionEnd = getSelectionEnd();
				return true;
			}
			return false;
		}

		internal virtual bool reportExtractedText()
		{
			android.widget.TextView.InputMethodState ims = mInputMethodState;
			if (ims != null)
			{
				bool contentChanged = ims.mContentChanged;
				if (contentChanged || ims.mSelectionModeChanged)
				{
					ims.mContentChanged = false;
					ims.mSelectionModeChanged = false;
					android.view.inputmethod.ExtractedTextRequest req = mInputMethodState.mExtracting;
					if (req != null)
					{
						android.view.inputmethod.InputMethodManager imm = android.view.inputmethod.InputMethodManager
							.peekInstance();
						if (imm != null)
						{
							if (ims.mChangedStart < 0 && !contentChanged)
							{
								ims.mChangedStart = EXTRACT_NOTHING;
							}
							if (extractTextInternal(req, ims.mChangedStart, ims.mChangedEnd, ims.mChangedDelta
								, ims.mTmpExtracted))
							{
								imm.updateExtractedText(this, req.token, mInputMethodState.mTmpExtracted);
								ims.mChangedStart = EXTRACT_UNKNOWN;
								ims.mChangedEnd = EXTRACT_UNKNOWN;
								ims.mChangedDelta = 0;
								ims.mContentChanged = false;
								return true;
							}
						}
					}
				}
			}
			return false;
		}

		/// <summary>
		/// This is used to remove all style-impacting spans from text before new
		/// extracted text is being replaced into it, so that we don't have any
		/// lingering spans applied during the replace.
		/// </summary>
		/// <remarks>
		/// This is used to remove all style-impacting spans from text before new
		/// extracted text is being replaced into it, so that we don't have any
		/// lingering spans applied during the replace.
		/// </remarks>
		internal static void removeParcelableSpans(android.text.Spannable spannable, int 
			start, int end)
		{
			object[] spans = spannable.getSpans<android.text.ParcelableSpan>(start, end);
			int i = spans.Length;
			while (i > 0)
			{
				i--;
				spannable.removeSpan(spans[i]);
			}
		}

		/// <summary>
		/// Apply to this text view the given extracted text, as previously
		/// returned by
		/// <see cref="extractText(android.view.inputmethod.ExtractedTextRequest, android.view.inputmethod.ExtractedText)
		/// 	">extractText(android.view.inputmethod.ExtractedTextRequest, android.view.inputmethod.ExtractedText)
		/// 	</see>
		/// .
		/// </summary>
		public virtual void setExtractedText(android.view.inputmethod.ExtractedText text)
		{
			android.text.Editable content = getEditableText();
			if (text.text != null)
			{
				if (content == null)
				{
					setText(text.text, android.widget.TextView.BufferType.EDITABLE);
				}
				else
				{
					if (text.partialStartOffset < 0)
					{
						removeParcelableSpans(content, 0, content.Length);
						content.replace(0, content.Length, text.text);
					}
					else
					{
						int N = content.Length;
						int start = text.partialStartOffset;
						if (start > N)
						{
							start = N;
						}
						int end = text.partialEndOffset;
						if (end > N)
						{
							end = N;
						}
						removeParcelableSpans(content, start, end);
						content.replace(start, end, text.text);
					}
				}
			}
			// Now set the selection position...  make sure it is in range, to
			// avoid crashes.  If this is a partial update, it is possible that
			// the underlying text may have changed, causing us problems here.
			// Also we just don't want to trust clients to do the right thing.
			android.text.Spannable sp = (android.text.Spannable)getText();
			int N_1 = sp.Length;
			int start_1 = text.selectionStart;
			if (start_1 < 0)
			{
				start_1 = 0;
			}
			else
			{
				if (start_1 > N_1)
				{
					start_1 = N_1;
				}
			}
			int end_1 = text.selectionEnd;
			if (end_1 < 0)
			{
				end_1 = 0;
			}
			else
			{
				if (end_1 > N_1)
				{
					end_1 = N_1;
				}
			}
			android.text.Selection.setSelection(sp, start_1, end_1);
			// Finally, update the selection mode.
			if ((text.flags & android.view.inputmethod.ExtractedText.FLAG_SELECTING) != 0)
			{
				android.text.method.MetaKeyKeyListener.startSelecting(this, sp);
			}
			else
			{
				android.text.method.MetaKeyKeyListener.stopSelecting(this, sp);
			}
		}

		/// <hide></hide>
		public virtual void setExtracting(android.view.inputmethod.ExtractedTextRequest req
			)
		{
			if (mInputMethodState != null)
			{
				mInputMethodState.mExtracting = req;
			}
			// This would stop a possible selection mode, but no such mode is started in case
			// extracted mode will start. Some text is selected though, and will trigger an action mode
			// in the extracted view.
			hideControllers();
		}

		/// <summary>
		/// Called by the framework in response to a text completion from
		/// the current input method, provided by it calling
		/// <see cref="android.view.inputmethod.InputConnection.commitCompletion(android.view.inputmethod.CompletionInfo)
		/// 	">InputConnection.commitCompletion()</see>
		/// .  The default implementation does
		/// nothing; text views that are supporting auto-completion should override
		/// this to do their desired behavior.
		/// </summary>
		/// <param name="text">The auto complete text the user has selected.</param>
		public virtual void onCommitCompletion(android.view.inputmethod.CompletionInfo text
			)
		{
		}

		// intentionally empty
		/// <summary>
		/// Called by the framework in response to a text auto-correction (such as fixing a typo using a
		/// a dictionnary) from the current input method, provided by it calling
		/// <see cref="android.view.inputmethod.InputConnection.commitCorrection(android.view.inputmethod.CorrectionInfo)
		/// 	">android.view.inputmethod.InputConnection.commitCorrection(android.view.inputmethod.CorrectionInfo)
		/// 	</see>
		/// InputConnection.commitCorrection()}. The default
		/// implementation flashes the background of the corrected word to provide feedback to the user.
		/// </summary>
		/// <param name="info">The auto correct info about the text that was corrected.</param>
		public virtual void onCommitCorrection(android.view.inputmethod.CorrectionInfo info
			)
		{
			if (mCorrectionHighlighter == null)
			{
				mCorrectionHighlighter = new android.widget.TextView.CorrectionHighlighter(this);
			}
			else
			{
				mCorrectionHighlighter.invalidate(false);
			}
			mCorrectionHighlighter.highlight(info);
		}

		private class CorrectionHighlighter
		{
			internal readonly android.graphics.Path mPath;

			internal readonly android.graphics.Paint mPaint;

			internal int mStart;

			internal int mEnd;

			internal long mFadingStartTime;

			internal const int FADE_OUT_DURATION = 400;

			public CorrectionHighlighter(TextView _enclosing)
			{
				this._enclosing = _enclosing;
				mPath = new android.graphics.Path();
				mPaint = new android.graphics.Paint(android.graphics.Paint.ANTI_ALIAS_FLAG);
				this.mPaint.setCompatibilityScaling(this._enclosing.getResources().getCompatibilityInfo
					().applicationScale);
				this.mPaint.setStyle(android.graphics.Paint.Style.FILL);
			}

			public virtual void highlight(android.view.inputmethod.CorrectionInfo info)
			{
				this.mStart = info.getOffset();
				this.mEnd = this.mStart + info.getNewText().Length;
				this.mFadingStartTime = android.os.SystemClock.uptimeMillis();
				if (this.mStart < 0 || this.mEnd < 0)
				{
					this.stopAnimation();
				}
			}

			public virtual void draw(android.graphics.Canvas canvas, int cursorOffsetVertical
				)
			{
				if (this.updatePath() && this.updatePaint())
				{
					if (cursorOffsetVertical != 0)
					{
						canvas.translate(0, cursorOffsetVertical);
					}
					canvas.drawPath(this.mPath, this.mPaint);
					if (cursorOffsetVertical != 0)
					{
						canvas.translate(0, -cursorOffsetVertical);
					}
					this.invalidate(true);
				}
				else
				{
					this.stopAnimation();
					this.invalidate(false);
				}
			}

			internal bool updatePaint()
			{
				long duration = android.os.SystemClock.uptimeMillis() - this.mFadingStartTime;
				if (duration > FADE_OUT_DURATION)
				{
					return false;
				}
				float coef = 1.0f - (float)duration / FADE_OUT_DURATION;
				int highlightColorAlpha = android.graphics.Color.alpha(this._enclosing.mHighlightColor
					);
				int color = (this._enclosing.mHighlightColor & unchecked((int)(0x00FFFFFF))) + ((
					int)(highlightColorAlpha * coef) << 24);
				this.mPaint.setColor(color);
				return true;
			}

			internal bool updatePath()
			{
				android.text.Layout layout = this._enclosing.mLayout;
				if (layout == null)
				{
					return false;
				}
				// Update in case text is edited while the animation is run
				int length = this._enclosing.mText.Length;
				int start = System.Math.Min(length, this.mStart);
				int end = System.Math.Min(length, this.mEnd);
				this.mPath.reset();
				this._enclosing.mLayout.getSelectionPath(start, end, this.mPath);
				return true;
			}

			internal void invalidate(bool delayed)
			{
				if (this._enclosing.mLayout == null)
				{
					return;
				}
				lock (android.widget.TextView.sTempRect)
				{
					this.mPath.computeBounds(android.widget.TextView.sTempRect, false);
					int left = this._enclosing.getCompoundPaddingLeft();
					int top = this._enclosing.getExtendedPaddingTop() + this._enclosing.getVerticalOffset
						(true);
					if (delayed)
					{
						this._enclosing.postInvalidateDelayed(16, left + (int)android.widget.TextView.sTempRect
							.left, top + (int)android.widget.TextView.sTempRect.top, left + (int)android.widget.TextView
							.sTempRect.right, top + (int)android.widget.TextView.sTempRect.bottom);
					}
					else
					{
						// 60 Hz update
						this._enclosing.postInvalidate((int)android.widget.TextView.sTempRect.left, (int)
							android.widget.TextView.sTempRect.top, (int)android.widget.TextView.sTempRect.right
							, (int)android.widget.TextView.sTempRect.bottom);
					}
				}
			}

			internal void stopAnimation()
			{
				this._enclosing.mCorrectionHighlighter = null;
			}

			private readonly TextView _enclosing;
		}

		public virtual void beginBatchEdit()
		{
			mInBatchEditControllers = true;
			android.widget.TextView.InputMethodState ims = mInputMethodState;
			if (ims != null)
			{
				int nesting = ++ims.mBatchEditNesting;
				if (nesting == 1)
				{
					ims.mCursorChanged = false;
					ims.mChangedDelta = 0;
					if (ims.mContentChanged)
					{
						// We already have a pending change from somewhere else,
						// so turn this into a full update.
						ims.mChangedStart = 0;
						ims.mChangedEnd = mText.Length;
					}
					else
					{
						ims.mChangedStart = EXTRACT_UNKNOWN;
						ims.mChangedEnd = EXTRACT_UNKNOWN;
						ims.mContentChanged = false;
					}
					onBeginBatchEdit();
				}
			}
		}

		public virtual void endBatchEdit()
		{
			mInBatchEditControllers = false;
			android.widget.TextView.InputMethodState ims = mInputMethodState;
			if (ims != null)
			{
				int nesting = --ims.mBatchEditNesting;
				if (nesting == 0)
				{
					finishBatchEdit(ims);
				}
			}
		}

		internal virtual void ensureEndedBatchEdit()
		{
			android.widget.TextView.InputMethodState ims = mInputMethodState;
			if (ims != null && ims.mBatchEditNesting != 0)
			{
				ims.mBatchEditNesting = 0;
				finishBatchEdit(ims);
			}
		}

		internal virtual void finishBatchEdit(android.widget.TextView.InputMethodState ims
			)
		{
			onEndBatchEdit();
			if (ims.mContentChanged || ims.mSelectionModeChanged)
			{
				updateAfterEdit();
				reportExtractedText();
			}
			else
			{
				if (ims.mCursorChanged)
				{
					// Cheezy way to get us to report the current cursor location.
					invalidateCursor();
				}
			}
		}

		internal virtual void updateAfterEdit()
		{
			invalidate();
			int curs = getSelectionStart();
			if (curs >= 0 || (mGravity & android.view.Gravity.VERTICAL_GRAVITY_MASK) == android.view.Gravity
				.BOTTOM)
			{
				registerForPreDraw();
			}
			if (curs >= 0)
			{
				mHighlightPathBogus = true;
				makeBlink();
				bringPointIntoView(curs);
			}
			checkForResize();
		}

		/// <summary>
		/// Called by the framework in response to a request to begin a batch
		/// of edit operations through a call to link
		/// <see cref="beginBatchEdit()">beginBatchEdit()</see>
		/// .
		/// </summary>
		public virtual void onBeginBatchEdit()
		{
		}

		// intentionally empty
		/// <summary>
		/// Called by the framework in response to a request to end a batch
		/// of edit operations through a call to link
		/// <see cref="endBatchEdit()">endBatchEdit()</see>
		/// .
		/// </summary>
		public virtual void onEndBatchEdit()
		{
		}

		// intentionally empty
		/// <summary>
		/// Called by the framework in response to a private command from the
		/// current method, provided by it calling
		/// <see cref="android.view.inputmethod.InputConnection.performPrivateCommand(string, android.os.Bundle)
		/// 	">InputConnection.performPrivateCommand()</see>
		/// .
		/// </summary>
		/// <param name="action">The action name of the command.</param>
		/// <param name="data">Any additional data for the command.  This may be null.</param>
		/// <returns>Return true if you handled the command, else false.</returns>
		public virtual bool onPrivateIMECommand(string action, android.os.Bundle data)
		{
			return false;
		}

		private void nullLayouts()
		{
			if (mLayout is android.text.BoringLayout && mSavedLayout == null)
			{
				mSavedLayout = (android.text.BoringLayout)mLayout;
			}
			if (mHintLayout is android.text.BoringLayout && mSavedHintLayout == null)
			{
				mSavedHintLayout = (android.text.BoringLayout)mHintLayout;
			}
			mSavedMarqueeModeLayout = mLayout = mHintLayout = null;
			// Since it depends on the value of mLayout
			prepareCursorControllers();
		}

		/// <summary>
		/// Make a new Layout based on the already-measured size of the view,
		/// on the assumption that it was measured correctly at some point.
		/// </summary>
		/// <remarks>
		/// Make a new Layout based on the already-measured size of the view,
		/// on the assumption that it was measured correctly at some point.
		/// </remarks>
		private void assumeLayout()
		{
			int width = mRight - mLeft - getCompoundPaddingLeft() - getCompoundPaddingRight();
			if (width < 1)
			{
				width = 0;
			}
			int physicalWidth = width;
			if (mHorizontallyScrolling)
			{
				width = VERY_WIDE;
			}
			makeNewLayout(width, physicalWidth, UNKNOWN_BORING, UNKNOWN_BORING, physicalWidth
				, false);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void resetResolvedLayoutDirection()
		{
			base.resetResolvedLayoutDirection();
			if (mLayoutAlignment != null && (mTextAlign == android.widget.TextView.TextAlign.
				VIEW_START || mTextAlign == android.widget.TextView.TextAlign.VIEW_END))
			{
				mLayoutAlignment = null;
			}
		}

		private android.text.Layout.Alignment? getLayoutAlignment()
		{
			if (mLayoutAlignment == null)
			{
				android.text.Layout.Alignment? alignment;
				android.widget.TextView.TextAlign textAlign = mTextAlign;
				switch (textAlign)
				{
					case android.widget.TextView.TextAlign.INHERIT:
					case android.widget.TextView.TextAlign.GRAVITY:
					{
						switch (mGravity & android.view.Gravity.RELATIVE_HORIZONTAL_GRAVITY_MASK)
						{
							case android.view.Gravity.START:
							{
								// fall through to gravity temporarily
								// intention is to inherit value through view hierarchy.
								alignment = android.text.Layout.Alignment.ALIGN_NORMAL;
								break;
							}

							case android.view.Gravity.END:
							{
								alignment = android.text.Layout.Alignment.ALIGN_OPPOSITE;
								break;
							}

							case android.view.Gravity.LEFT:
							{
								alignment = android.text.Layout.Alignment.ALIGN_LEFT;
								break;
							}

							case android.view.Gravity.RIGHT:
							{
								alignment = android.text.Layout.Alignment.ALIGN_RIGHT;
								break;
							}

							case android.view.Gravity.CENTER_HORIZONTAL:
							{
								alignment = android.text.Layout.Alignment.ALIGN_CENTER;
								break;
							}

							default:
							{
								alignment = android.text.Layout.Alignment.ALIGN_NORMAL;
								break;
							}
						}
						break;
					}

					case android.widget.TextView.TextAlign.TEXT_START:
					{
						alignment = android.text.Layout.Alignment.ALIGN_NORMAL;
						break;
					}

					case android.widget.TextView.TextAlign.TEXT_END:
					{
						alignment = android.text.Layout.Alignment.ALIGN_OPPOSITE;
						break;
					}

					case android.widget.TextView.TextAlign.CENTER:
					{
						alignment = android.text.Layout.Alignment.ALIGN_CENTER;
						break;
					}

					case android.widget.TextView.TextAlign.VIEW_START:
					{
						alignment = (getResolvedLayoutDirection() == LAYOUT_DIRECTION_RTL) ? android.text.Layout.Alignment
							.ALIGN_RIGHT : android.text.Layout.Alignment.ALIGN_LEFT;
						break;
					}

					case android.widget.TextView.TextAlign.VIEW_END:
					{
						alignment = (getResolvedLayoutDirection() == LAYOUT_DIRECTION_RTL) ? android.text.Layout.Alignment
							.ALIGN_LEFT : android.text.Layout.Alignment.ALIGN_RIGHT;
						break;
					}

					default:
					{
						alignment = android.text.Layout.Alignment.ALIGN_NORMAL;
						break;
					}
				}
				mLayoutAlignment = alignment;
			}
			return mLayoutAlignment;
		}

		/// <summary>
		/// The width passed in is now the desired layout width,
		/// not the full view width with padding.
		/// </summary>
		/// <remarks>
		/// The width passed in is now the desired layout width,
		/// not the full view width with padding.
		/// <hide></hide>
		/// </remarks>
		protected internal virtual void makeNewLayout(int wantWidth, int hintWidth, android.text.BoringLayout
			.Metrics boring, android.text.BoringLayout.Metrics hintBoring, int ellipsisWidth
			, bool bringIntoView)
		{
			stopMarquee();
			// Update "old" cached values
			mOldMaximum = mMaximum;
			mOldMaxMode = mMaxMode;
			mHighlightPathBogus = true;
			if (wantWidth < 0)
			{
				wantWidth = 0;
			}
			if (hintWidth < 0)
			{
				hintWidth = 0;
			}
			android.text.Layout.Alignment? alignment = getLayoutAlignment();
			bool shouldEllipsize = mEllipsize != null && mInput == null;
			bool switchEllipsize = mEllipsize == android.text.TextUtils.TruncateAt.MARQUEE &&
				 mMarqueeFadeMode != MARQUEE_FADE_NORMAL;
			android.text.TextUtils.TruncateAt? effectiveEllipsize = mEllipsize;
			if (mEllipsize == android.text.TextUtils.TruncateAt.MARQUEE && mMarqueeFadeMode ==
				 MARQUEE_FADE_SWITCH_SHOW_ELLIPSIS)
			{
				effectiveEllipsize = android.text.TextUtils.TruncateAt.END_SMALL;
			}
			if (mTextDir == null)
			{
				resolveTextDirection();
			}
			mLayout = makeSingleLayout(wantWidth, boring, ellipsisWidth, alignment, shouldEllipsize
				, effectiveEllipsize, effectiveEllipsize == mEllipsize);
			if (switchEllipsize)
			{
				android.text.TextUtils.TruncateAt? oppositeEllipsize = effectiveEllipsize == android.text.TextUtils.TruncateAt
					.MARQUEE ? android.text.TextUtils.TruncateAt.END : android.text.TextUtils.TruncateAt
					.MARQUEE;
				mSavedMarqueeModeLayout = makeSingleLayout(wantWidth, boring, ellipsisWidth, alignment
					, shouldEllipsize, oppositeEllipsize, effectiveEllipsize != mEllipsize);
			}
			shouldEllipsize = mEllipsize != null;
			mHintLayout = null;
			if (mHint != null)
			{
				if (shouldEllipsize)
				{
					hintWidth = wantWidth;
				}
				if (hintBoring == UNKNOWN_BORING)
				{
					hintBoring = android.text.BoringLayout.isBoring(mHint, mTextPaint, mTextDir, mHintBoring
						);
					if (hintBoring != null)
					{
						mHintBoring = hintBoring;
					}
				}
				if (hintBoring != null)
				{
					if (hintBoring.width <= hintWidth && (!shouldEllipsize || hintBoring.width <= ellipsisWidth
						))
					{
						if (mSavedHintLayout != null)
						{
							mHintLayout = mSavedHintLayout.replaceOrMake(mHint, mTextPaint, hintWidth, alignment
								, mSpacingMult, mSpacingAdd, hintBoring, mIncludePad);
						}
						else
						{
							mHintLayout = android.text.BoringLayout.make(mHint, mTextPaint, hintWidth, alignment
								, mSpacingMult, mSpacingAdd, hintBoring, mIncludePad);
						}
						mSavedHintLayout = (android.text.BoringLayout)mHintLayout;
					}
					else
					{
						if (shouldEllipsize && hintBoring.width <= hintWidth)
						{
							if (mSavedHintLayout != null)
							{
								mHintLayout = mSavedHintLayout.replaceOrMake(mHint, mTextPaint, hintWidth, alignment
									, mSpacingMult, mSpacingAdd, hintBoring, mIncludePad, mEllipsize, ellipsisWidth);
							}
							else
							{
								mHintLayout = android.text.BoringLayout.make(mHint, mTextPaint, hintWidth, alignment
									, mSpacingMult, mSpacingAdd, hintBoring, mIncludePad, mEllipsize, ellipsisWidth);
							}
						}
						else
						{
							if (shouldEllipsize)
							{
								mHintLayout = new android.text.StaticLayout(mHint, 0, mHint.Length, mTextPaint, hintWidth
									, alignment, mTextDir, mSpacingMult, mSpacingAdd, mIncludePad, mEllipsize, ellipsisWidth
									, mMaxMode == LINES ? mMaximum : int.MaxValue);
							}
							else
							{
								mHintLayout = new android.text.StaticLayout(mHint, mTextPaint, hintWidth, alignment
									, mTextDir, mSpacingMult, mSpacingAdd, mIncludePad);
							}
						}
					}
				}
				else
				{
					if (shouldEllipsize)
					{
						mHintLayout = new android.text.StaticLayout(mHint, 0, mHint.Length, mTextPaint, hintWidth
							, alignment, mTextDir, mSpacingMult, mSpacingAdd, mIncludePad, mEllipsize, ellipsisWidth
							, mMaxMode == LINES ? mMaximum : int.MaxValue);
					}
					else
					{
						mHintLayout = new android.text.StaticLayout(mHint, mTextPaint, hintWidth, alignment
							, mTextDir, mSpacingMult, mSpacingAdd, mIncludePad);
					}
				}
			}
			if (bringIntoView)
			{
				registerForPreDraw();
			}
			if (mEllipsize == android.text.TextUtils.TruncateAt.MARQUEE)
			{
				if (!compressText(ellipsisWidth))
				{
					int height = mLayoutParams.height;
					// If the size of the view does not depend on the size of the text, try to
					// start the marquee immediately
					if (height != android.view.ViewGroup.LayoutParams.WRAP_CONTENT && height != android.view.ViewGroup
						.LayoutParams.MATCH_PARENT)
					{
						startMarquee();
					}
					else
					{
						// Defer the start of the marquee until we know our width (see setFrame())
						mRestartMarquee = true;
					}
				}
			}
			// CursorControllers need a non-null mLayout
			prepareCursorControllers();
		}

		private android.text.Layout makeSingleLayout(int wantWidth, android.text.BoringLayout
			.Metrics boring, int ellipsisWidth, android.text.Layout.Alignment? alignment, bool
			 shouldEllipsize, android.text.TextUtils.TruncateAt? effectiveEllipsize, bool useSaved
			)
		{
			android.text.Layout result = null;
			if (mText is android.text.Spannable)
			{
				result = new android.text.DynamicLayout(mText, mTransformed, mTextPaint, wantWidth
					, alignment, mTextDir, mSpacingMult, mSpacingAdd, mIncludePad, mInput == null ? 
					effectiveEllipsize : null, ellipsisWidth);
			}
			else
			{
				if (boring == UNKNOWN_BORING)
				{
					boring = android.text.BoringLayout.isBoring(mTransformed, mTextPaint, mTextDir, mBoring
						);
					if (boring != null)
					{
						mBoring = boring;
					}
				}
				if (boring != null)
				{
					if (boring.width <= wantWidth && (effectiveEllipsize == null || boring.width <= ellipsisWidth
						))
					{
						if (useSaved && mSavedLayout != null)
						{
							result = mSavedLayout.replaceOrMake(mTransformed, mTextPaint, wantWidth, alignment
								, mSpacingMult, mSpacingAdd, boring, mIncludePad);
						}
						else
						{
							result = android.text.BoringLayout.make(mTransformed, mTextPaint, wantWidth, alignment
								, mSpacingMult, mSpacingAdd, boring, mIncludePad);
						}
						if (useSaved)
						{
							mSavedLayout = (android.text.BoringLayout)result;
						}
					}
					else
					{
						if (shouldEllipsize && boring.width <= wantWidth)
						{
							if (useSaved && mSavedLayout != null)
							{
								result = mSavedLayout.replaceOrMake(mTransformed, mTextPaint, wantWidth, alignment
									, mSpacingMult, mSpacingAdd, boring, mIncludePad, effectiveEllipsize, ellipsisWidth
									);
							}
							else
							{
								result = android.text.BoringLayout.make(mTransformed, mTextPaint, wantWidth, alignment
									, mSpacingMult, mSpacingAdd, boring, mIncludePad, effectiveEllipsize, ellipsisWidth
									);
							}
						}
						else
						{
							if (shouldEllipsize)
							{
								result = new android.text.StaticLayout(mTransformed, 0, mTransformed.Length, mTextPaint
									, wantWidth, alignment, mTextDir, mSpacingMult, mSpacingAdd, mIncludePad, effectiveEllipsize
									, ellipsisWidth, mMaxMode == LINES ? mMaximum : int.MaxValue);
							}
							else
							{
								result = new android.text.StaticLayout(mTransformed, mTextPaint, wantWidth, alignment
									, mTextDir, mSpacingMult, mSpacingAdd, mIncludePad);
							}
						}
					}
				}
				else
				{
					if (shouldEllipsize)
					{
						result = new android.text.StaticLayout(mTransformed, 0, mTransformed.Length, mTextPaint
							, wantWidth, alignment, mTextDir, mSpacingMult, mSpacingAdd, mIncludePad, effectiveEllipsize
							, ellipsisWidth, mMaxMode == LINES ? mMaximum : int.MaxValue);
					}
					else
					{
						result = new android.text.StaticLayout(mTransformed, mTextPaint, wantWidth, alignment
							, mTextDir, mSpacingMult, mSpacingAdd, mIncludePad);
					}
				}
			}
			return result;
		}

		private sealed class _Runnable_6337 : java.lang.Runnable
		{
			public _Runnable_6337(TextView _enclosing)
			{
				this._enclosing = _enclosing;
			}

			// Only compress the text if it hasn't been compressed by the previous pass
			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public void run()
			{
				this._enclosing.requestLayout();
			}

			private readonly TextView _enclosing;
		}

		private bool compressText(float width)
		{
			if (isHardwareAccelerated())
			{
				return false;
			}
			if (width > 0.0f && mLayout != null && getLineCount() == 1 && !mUserSetTextScaleX
				 && mTextPaint.getTextScaleX() == 1.0f)
			{
				float textWidth = mLayout.getLineWidth(0);
				float overflow = (textWidth + 1.0f - width) / width;
				if (overflow > 0.0f && overflow <= android.widget.TextView.Marquee.MARQUEE_DELTA_MAX)
				{
					mTextPaint.setTextScaleX(1.0f - overflow - 0.005f);
					post(new _Runnable_6337(this));
					return true;
				}
			}
			return false;
		}

		private static int desired(android.text.Layout layout_1)
		{
			int n = layout_1.getLineCount();
			java.lang.CharSequence text = layout_1.getText();
			float max = 0;
			{
				// if any line was wrapped, we can't use it.
				// but it's ok for the last line not to have a newline
				for (int i = 0; i < n - 1; i++)
				{
					if (text[layout_1.getLineEnd(i) - 1] != '\n')
					{
						return -1;
					}
				}
			}
			{
				for (int i_1 = 0; i_1 < n; i_1++)
				{
					max = System.Math.Max(max, layout_1.getLineWidth(i_1));
				}
			}
			return (int)android.util.FloatMath.ceil(max);
		}

		/// <summary>
		/// Set whether the TextView includes extra top and bottom padding to make
		/// room for accents that go above the normal ascent and descent.
		/// </summary>
		/// <remarks>
		/// Set whether the TextView includes extra top and bottom padding to make
		/// room for accents that go above the normal ascent and descent.
		/// The default is true.
		/// </remarks>
		/// <attr>ref android.R.styleable#TextView_includeFontPadding</attr>
		public virtual void setIncludeFontPadding(bool includepad)
		{
			if (mIncludePad != includepad)
			{
				mIncludePad = includepad;
				if (mLayout != null)
				{
					nullLayouts();
					requestLayout();
					invalidate();
				}
			}
		}

		private static readonly android.text.BoringLayout.Metrics UNKNOWN_BORING = new android.text.BoringLayout
			.Metrics();

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onMeasure(int widthMeasureSpec, int heightMeasureSpec
			)
		{
			int widthMode = android.view.View.MeasureSpec.getMode(widthMeasureSpec);
			int heightMode = android.view.View.MeasureSpec.getMode(heightMeasureSpec);
			int widthSize = android.view.View.MeasureSpec.getSize(widthMeasureSpec);
			int heightSize = android.view.View.MeasureSpec.getSize(heightMeasureSpec);
			int width;
			int height;
			android.text.BoringLayout.Metrics boring = UNKNOWN_BORING;
			android.text.BoringLayout.Metrics hintBoring = UNKNOWN_BORING;
			if (mTextDir == null)
			{
				resolveTextDirection();
			}
			int des = -1;
			bool fromexisting = false;
			if (widthMode == android.view.View.MeasureSpec.EXACTLY)
			{
				// Parent has told us how big to be. So be it.
				width = widthSize;
			}
			else
			{
				if (mLayout != null && mEllipsize == null)
				{
					des = desired(mLayout);
				}
				if (des < 0)
				{
					boring = android.text.BoringLayout.isBoring(mTransformed, mTextPaint, mTextDir, mBoring
						);
					if (boring != null)
					{
						mBoring = boring;
					}
				}
				else
				{
					fromexisting = true;
				}
				if (boring == null || boring == UNKNOWN_BORING)
				{
					if (des < 0)
					{
						des = (int)android.util.FloatMath.ceil(android.text.Layout.getDesiredWidth(mTransformed
							, mTextPaint));
					}
					width = des;
				}
				else
				{
					width = boring.width;
				}
				android.widget.TextView.Drawables dr = mDrawables;
				if (dr != null)
				{
					width = System.Math.Max(width, dr.mDrawableWidthTop);
					width = System.Math.Max(width, dr.mDrawableWidthBottom);
				}
				if (mHint != null)
				{
					int hintDes = -1;
					int hintWidth;
					if (mHintLayout != null && mEllipsize == null)
					{
						hintDes = desired(mHintLayout);
					}
					if (hintDes < 0)
					{
						hintBoring = android.text.BoringLayout.isBoring(mHint, mTextPaint, mHintBoring);
						if (hintBoring != null)
						{
							mHintBoring = hintBoring;
						}
					}
					if (hintBoring == null || hintBoring == UNKNOWN_BORING)
					{
						if (hintDes < 0)
						{
							hintDes = (int)android.util.FloatMath.ceil(android.text.Layout.getDesiredWidth(mHint
								, mTextPaint));
						}
						hintWidth = hintDes;
					}
					else
					{
						hintWidth = hintBoring.width;
					}
					if (hintWidth > width)
					{
						width = hintWidth;
					}
				}
				width += getCompoundPaddingLeft() + getCompoundPaddingRight();
				if (mMaxWidthMode == EMS)
				{
					width = System.Math.Min(width, mMaxWidth * getLineHeight());
				}
				else
				{
					width = System.Math.Min(width, mMaxWidth);
				}
				if (mMinWidthMode == EMS)
				{
					width = System.Math.Max(width, mMinWidth * getLineHeight());
				}
				else
				{
					width = System.Math.Max(width, mMinWidth);
				}
				// Check against our minimum width
				width = System.Math.Max(width, getSuggestedMinimumWidth());
				if (widthMode == android.view.View.MeasureSpec.AT_MOST)
				{
					width = System.Math.Min(widthSize, width);
				}
			}
			int want = width - getCompoundPaddingLeft() - getCompoundPaddingRight();
			int unpaddedWidth = want;
			if (mHorizontallyScrolling)
			{
				want = VERY_WIDE;
			}
			int hintWant = want;
			int hintWidth_1 = (mHintLayout == null) ? hintWant : mHintLayout.getWidth();
			if (mLayout == null)
			{
				makeNewLayout(want, hintWant, boring, hintBoring, width - getCompoundPaddingLeft(
					) - getCompoundPaddingRight(), false);
			}
			else
			{
				bool layoutChanged = (mLayout.getWidth() != want) || (hintWidth_1 != hintWant) ||
					 (mLayout.getEllipsizedWidth() != width - getCompoundPaddingLeft() - getCompoundPaddingRight
					());
				bool widthChanged = (mHint == null) && (mEllipsize == null) && (want > mLayout.getWidth
					()) && (mLayout is android.text.BoringLayout || (fromexisting && des >= 0 && des
					 <= want));
				bool maximumChanged = (mMaxMode != mOldMaxMode) || (mMaximum != mOldMaximum);
				if (layoutChanged || maximumChanged)
				{
					if (!maximumChanged && widthChanged)
					{
						mLayout.increaseWidthTo(want);
					}
					else
					{
						makeNewLayout(want, hintWant, boring, hintBoring, width - getCompoundPaddingLeft(
							) - getCompoundPaddingRight(), false);
					}
				}
			}
			// Nothing has changed
			if (heightMode == android.view.View.MeasureSpec.EXACTLY)
			{
				// Parent has told us how big to be. So be it.
				height = heightSize;
				mDesiredHeightAtMeasure = -1;
			}
			else
			{
				int desired_1 = getDesiredHeight();
				height = desired_1;
				mDesiredHeightAtMeasure = desired_1;
				if (heightMode == android.view.View.MeasureSpec.AT_MOST)
				{
					height = System.Math.Min(desired_1, heightSize);
				}
			}
			int unpaddedHeight = height - getCompoundPaddingTop() - getCompoundPaddingBottom(
				);
			if (mMaxMode == LINES && mLayout.getLineCount() > mMaximum)
			{
				unpaddedHeight = System.Math.Min(unpaddedHeight, mLayout.getLineTop(mMaximum));
			}
			if (mMovement != null || mLayout.getWidth() > unpaddedWidth || mLayout.getHeight(
				) > unpaddedHeight)
			{
				registerForPreDraw();
			}
			else
			{
				scrollTo(0, 0);
			}
			setMeasuredDimension(width, height);
		}

		private int getDesiredHeight()
		{
			return System.Math.Max(getDesiredHeight(mLayout, true), getDesiredHeight(mHintLayout
				, mEllipsize != null));
		}

		private int getDesiredHeight(android.text.Layout layout_1, bool cap)
		{
			if (layout_1 == null)
			{
				return 0;
			}
			int linecount = layout_1.getLineCount();
			int pad = getCompoundPaddingTop() + getCompoundPaddingBottom();
			int desired_1 = layout_1.getLineTop(linecount);
			android.widget.TextView.Drawables dr = mDrawables;
			if (dr != null)
			{
				desired_1 = System.Math.Max(desired_1, dr.mDrawableHeightLeft);
				desired_1 = System.Math.Max(desired_1, dr.mDrawableHeightRight);
			}
			desired_1 += pad;
			if (mMaxMode == LINES)
			{
				if (cap)
				{
					if (linecount > mMaximum)
					{
						desired_1 = layout_1.getLineTop(mMaximum);
						if (dr != null)
						{
							desired_1 = System.Math.Max(desired_1, dr.mDrawableHeightLeft);
							desired_1 = System.Math.Max(desired_1, dr.mDrawableHeightRight);
						}
						desired_1 += pad;
						linecount = mMaximum;
					}
				}
			}
			else
			{
				desired_1 = System.Math.Min(desired_1, mMaximum);
			}
			if (mMinMode == LINES)
			{
				if (linecount < mMinimum)
				{
					desired_1 += getLineHeight() * (mMinimum - linecount);
				}
			}
			else
			{
				desired_1 = System.Math.Max(desired_1, mMinimum);
			}
			// Check against our minimum height
			desired_1 = System.Math.Max(desired_1, getSuggestedMinimumHeight());
			return desired_1;
		}

		/// <summary>
		/// Check whether a change to the existing text layout requires a
		/// new view layout.
		/// </summary>
		/// <remarks>
		/// Check whether a change to the existing text layout requires a
		/// new view layout.
		/// </remarks>
		private void checkForResize()
		{
			bool sizeChanged = false;
			if (mLayout != null)
			{
				// Check if our width changed
				if (mLayoutParams.width == android.view.ViewGroup.LayoutParams.WRAP_CONTENT)
				{
					sizeChanged = true;
					invalidate();
				}
				// Check if our height changed
				if (mLayoutParams.height == android.view.ViewGroup.LayoutParams.WRAP_CONTENT)
				{
					int desiredHeight = getDesiredHeight();
					if (desiredHeight != this.getHeight())
					{
						sizeChanged = true;
					}
				}
				else
				{
					if (mLayoutParams.height == android.view.ViewGroup.LayoutParams.MATCH_PARENT)
					{
						if (mDesiredHeightAtMeasure >= 0)
						{
							int desiredHeight = getDesiredHeight();
							if (desiredHeight != mDesiredHeightAtMeasure)
							{
								sizeChanged = true;
							}
						}
					}
				}
			}
			if (sizeChanged)
			{
				requestLayout();
			}
		}

		// caller will have already invalidated
		/// <summary>
		/// Check whether entirely new text requires a new view layout
		/// or merely a new text layout.
		/// </summary>
		/// <remarks>
		/// Check whether entirely new text requires a new view layout
		/// or merely a new text layout.
		/// </remarks>
		private void checkForRelayout()
		{
			// If we have a fixed width, we can just swap in a new text layout
			// if the text height stays the same or if the view height is fixed.
			if ((mLayoutParams.width != android.view.ViewGroup.LayoutParams.WRAP_CONTENT || (
				mMaxWidthMode == mMinWidthMode && mMaxWidth == mMinWidth)) && (mHint == null || 
				mHintLayout != null) && (mRight - mLeft - getCompoundPaddingLeft() - getCompoundPaddingRight
				() > 0))
			{
				// Static width, so try making a new text layout.
				int oldht = mLayout.getHeight();
				int want = mLayout.getWidth();
				int hintWant = mHintLayout == null ? 0 : mHintLayout.getWidth();
				makeNewLayout(want, hintWant, UNKNOWN_BORING, UNKNOWN_BORING, mRight - mLeft - getCompoundPaddingLeft
					() - getCompoundPaddingRight(), false);
				if (mEllipsize != android.text.TextUtils.TruncateAt.MARQUEE)
				{
					// In a fixed-height view, so use our new text layout.
					if (mLayoutParams.height != android.view.ViewGroup.LayoutParams.WRAP_CONTENT && mLayoutParams
						.height != android.view.ViewGroup.LayoutParams.MATCH_PARENT)
					{
						invalidate();
						return;
					}
					// Dynamic height, but height has stayed the same,
					// so use our new text layout.
					if (mLayout.getHeight() == oldht && (mHintLayout == null || mHintLayout.getHeight
						() == oldht))
					{
						invalidate();
						return;
					}
				}
				// We lose: the height has changed and we have a dynamic height.
				// Request a new view layout using our new text layout.
				requestLayout();
				invalidate();
			}
			else
			{
				// Dynamic width, so we have no choice but to request a new
				// view layout with a new text layout.
				nullLayouts();
				requestLayout();
				invalidate();
			}
		}

		/// <summary>Returns true if anything changed.</summary>
		/// <remarks>Returns true if anything changed.</remarks>
		private bool bringTextIntoView()
		{
			int line = 0;
			if ((mGravity & android.view.Gravity.VERTICAL_GRAVITY_MASK) == android.view.Gravity
				.BOTTOM)
			{
				line = mLayout.getLineCount() - 1;
			}
			android.text.Layout.Alignment? a = mLayout.getParagraphAlignment(line);
			int dir = mLayout.getParagraphDirection(line);
			int hspace = mRight - mLeft - getCompoundPaddingLeft() - getCompoundPaddingRight(
				);
			int vspace = mBottom - mTop - getExtendedPaddingTop() - getExtendedPaddingBottom(
				);
			int ht = mLayout.getHeight();
			int scrollx;
			int scrolly;
			// Convert to left, center, or right alignment.
			if (a == android.text.Layout.Alignment.ALIGN_NORMAL)
			{
				a = dir == android.text.Layout.DIR_LEFT_TO_RIGHT ? android.text.Layout.Alignment.
					ALIGN_LEFT : android.text.Layout.Alignment.ALIGN_RIGHT;
			}
			else
			{
				if (a == android.text.Layout.Alignment.ALIGN_OPPOSITE)
				{
					a = dir == android.text.Layout.DIR_LEFT_TO_RIGHT ? android.text.Layout.Alignment.
						ALIGN_RIGHT : android.text.Layout.Alignment.ALIGN_LEFT;
				}
			}
			if (a == android.text.Layout.Alignment.ALIGN_CENTER)
			{
				int left = (int)android.util.FloatMath.floor(mLayout.getLineLeft(line));
				int right = (int)android.util.FloatMath.ceil(mLayout.getLineRight(line));
				if (right - left < hspace)
				{
					scrollx = (right + left) / 2 - hspace / 2;
				}
				else
				{
					if (dir < 0)
					{
						scrollx = right - hspace;
					}
					else
					{
						scrollx = left;
					}
				}
			}
			else
			{
				if (a == android.text.Layout.Alignment.ALIGN_RIGHT)
				{
					int right = (int)android.util.FloatMath.ceil(mLayout.getLineRight(line));
					scrollx = right - hspace;
				}
				else
				{
					// a == Layout.Alignment.ALIGN_LEFT (will also be the default)
					scrollx = (int)android.util.FloatMath.floor(mLayout.getLineLeft(line));
				}
			}
			if (ht < vspace)
			{
				scrolly = 0;
			}
			else
			{
				if ((mGravity & android.view.Gravity.VERTICAL_GRAVITY_MASK) == android.view.Gravity
					.BOTTOM)
				{
					scrolly = ht - vspace;
				}
				else
				{
					scrolly = 0;
				}
			}
			if (scrollx != mScrollX || scrolly != mScrollY)
			{
				scrollTo(scrollx, scrolly);
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>Move the point, specified by the offset, into the view if it is needed.</summary>
		/// <remarks>
		/// Move the point, specified by the offset, into the view if it is needed.
		/// This has to be called after layout. Returns true if anything changed.
		/// </remarks>
		public virtual bool bringPointIntoView(int offset)
		{
			bool changed = false;
			if (mLayout == null)
			{
				return changed;
			}
			int line = mLayout.getLineForOffset(offset);
			// FIXME: Is it okay to truncate this, or should we round?
			int x = (int)mLayout.getPrimaryHorizontal(offset);
			int top = mLayout.getLineTop(line);
			int bottom = mLayout.getLineTop(line + 1);
			int left = (int)android.util.FloatMath.floor(mLayout.getLineLeft(line));
			int right = (int)android.util.FloatMath.ceil(mLayout.getLineRight(line));
			int ht = mLayout.getHeight();
			int grav;
			switch (mLayout.getParagraphAlignment(line))
			{
				case android.text.Layout.Alignment.ALIGN_LEFT:
				{
					grav = 1;
					break;
				}

				case android.text.Layout.Alignment.ALIGN_RIGHT:
				{
					grav = -1;
					break;
				}

				case android.text.Layout.Alignment.ALIGN_NORMAL:
				{
					grav = mLayout.getParagraphDirection(line);
					break;
				}

				case android.text.Layout.Alignment.ALIGN_OPPOSITE:
				{
					grav = -mLayout.getParagraphDirection(line);
					break;
				}

				case android.text.Layout.Alignment.ALIGN_CENTER:
				default:
				{
					grav = 0;
					break;
				}
			}
			int hspace = mRight - mLeft - getCompoundPaddingLeft() - getCompoundPaddingRight(
				);
			int vspace = mBottom - mTop - getExtendedPaddingTop() - getExtendedPaddingBottom(
				);
			int hslack = (bottom - top) / 2;
			int vslack = hslack;
			if (vslack > vspace / 4)
			{
				vslack = vspace / 4;
			}
			if (hslack > hspace / 4)
			{
				hslack = hspace / 4;
			}
			int hs = mScrollX;
			int vs = mScrollY;
			if (top - vs < vslack)
			{
				vs = top - vslack;
			}
			if (bottom - vs > vspace - vslack)
			{
				vs = bottom - (vspace - vslack);
			}
			if (ht - vs < vspace)
			{
				vs = ht - vspace;
			}
			if (0 - vs > 0)
			{
				vs = 0;
			}
			if (grav != 0)
			{
				if (x - hs < hslack)
				{
					hs = x - hslack;
				}
				if (x - hs > hspace - hslack)
				{
					hs = x - (hspace - hslack);
				}
			}
			if (grav < 0)
			{
				if (left - hs > 0)
				{
					hs = left;
				}
				if (right - hs < hspace)
				{
					hs = right - hspace;
				}
			}
			else
			{
				if (grav > 0)
				{
					if (right - hs < hspace)
					{
						hs = right - hspace;
					}
					if (left - hs > 0)
					{
						hs = left;
					}
				}
				else
				{
					if (right - left <= hspace)
					{
						hs = left - (hspace - (right - left)) / 2;
					}
					else
					{
						if (x > right - hslack)
						{
							hs = right - hspace;
						}
						else
						{
							if (x < left + hslack)
							{
								hs = left;
							}
							else
							{
								if (left > hs)
								{
									hs = left;
								}
								else
								{
									if (right < hs + hspace)
									{
										hs = right - hspace;
									}
									else
									{
										if (x - hs < hslack)
										{
											hs = x - hslack;
										}
										if (x - hs > hspace - hslack)
										{
											hs = x - (hspace - hslack);
										}
									}
								}
							}
						}
					}
				}
			}
			if (hs != mScrollX || vs != mScrollY)
			{
				if (mScroller == null)
				{
					scrollTo(hs, vs);
				}
				else
				{
					long duration = android.view.animation.AnimationUtils.currentAnimationTimeMillis(
						) - mLastScroll;
					int dx = hs - mScrollX;
					int dy = vs - mScrollY;
					if (duration > ANIMATED_SCROLL_GAP)
					{
						mScroller.startScroll(mScrollX, mScrollY, dx, dy);
						awakenScrollBars(mScroller.getDuration());
						invalidate();
					}
					else
					{
						if (!mScroller.isFinished())
						{
							mScroller.abortAnimation();
						}
						scrollBy(dx, dy);
					}
					mLastScroll = android.view.animation.AnimationUtils.currentAnimationTimeMillis();
				}
				changed = true;
			}
			if (isFocused())
			{
				// This offsets because getInterestingRect() is in terms of viewport coordinates, but
				// requestRectangleOnScreen() is in terms of content coordinates.
				if (mTempRect == null)
				{
					mTempRect = new android.graphics.Rect();
				}
				// The offsets here are to ensure the rectangle we are using is
				// within our view bounds, in case the cursor is on the far left
				// or right.  If it isn't withing the bounds, then this request
				// will be ignored.
				mTempRect.set(x - 2, top, x + 2, bottom);
				getInterestingRect(mTempRect, line);
				mTempRect.offset(mScrollX, mScrollY);
				if (requestRectangleOnScreen(mTempRect))
				{
					changed = true;
				}
			}
			return changed;
		}

		/// <summary>
		/// Move the cursor, if needed, so that it is at an offset that is visible
		/// to the user.
		/// </summary>
		/// <remarks>
		/// Move the cursor, if needed, so that it is at an offset that is visible
		/// to the user.  This will not move the cursor if it represents more than
		/// one character (a selection range).  This will only work if the
		/// TextView contains spannable text; otherwise it will do nothing.
		/// </remarks>
		/// <returns>True if the cursor was actually moved, false otherwise.</returns>
		public virtual bool moveCursorToVisibleOffset()
		{
			if (!(mText is android.text.Spannable))
			{
				return false;
			}
			int start = getSelectionStart();
			int end = getSelectionEnd();
			if (start != end)
			{
				return false;
			}
			// First: make sure the line is visible on screen:
			int line = mLayout.getLineForOffset(start);
			int top = mLayout.getLineTop(line);
			int bottom = mLayout.getLineTop(line + 1);
			int vspace = mBottom - mTop - getExtendedPaddingTop() - getExtendedPaddingBottom(
				);
			int vslack = (bottom - top) / 2;
			if (vslack > vspace / 4)
			{
				vslack = vspace / 4;
			}
			int vs = mScrollY;
			if (top < (vs + vslack))
			{
				line = mLayout.getLineForVertical(vs + vslack + (bottom - top));
			}
			else
			{
				if (bottom > (vspace + vs - vslack))
				{
					line = mLayout.getLineForVertical(vspace + vs - vslack - (bottom - top));
				}
			}
			// Next: make sure the character is visible on screen:
			int hspace = mRight - mLeft - getCompoundPaddingLeft() - getCompoundPaddingRight(
				);
			int hs = mScrollX;
			int leftChar = mLayout.getOffsetForHorizontal(line, hs);
			int rightChar = mLayout.getOffsetForHorizontal(line, hspace + hs);
			// line might contain bidirectional text
			int lowChar = leftChar < rightChar ? leftChar : rightChar;
			int highChar = leftChar > rightChar ? leftChar : rightChar;
			int newStart = start;
			if (newStart < lowChar)
			{
				newStart = lowChar;
			}
			else
			{
				if (newStart > highChar)
				{
					newStart = highChar;
				}
			}
			if (newStart != start)
			{
				android.text.Selection.setSelection((android.text.Spannable)mText, newStart);
				return true;
			}
			return false;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void computeScroll()
		{
			if (mScroller != null)
			{
				if (mScroller.computeScrollOffset())
				{
					mScrollX = mScroller.getCurrX();
					mScrollY = mScroller.getCurrY();
					invalidateParentCaches();
					postInvalidate();
				}
			}
		}

		// So we draw again
		private void getInterestingRect(android.graphics.Rect r, int line)
		{
			convertFromViewportToContentCoordinates(r);
			// Rectangle can can be expanded on first and last line to take
			// padding into account.
			// TODO Take left/right padding into account too?
			if (line == 0)
			{
				r.top -= getExtendedPaddingTop();
			}
			if (line == mLayout.getLineCount() - 1)
			{
				r.bottom += getExtendedPaddingBottom();
			}
		}

		private void convertFromViewportToContentCoordinates(android.graphics.Rect r)
		{
			int horizontalOffset = viewportToContentHorizontalOffset();
			r.left += horizontalOffset;
			r.right += horizontalOffset;
			int verticalOffset = viewportToContentVerticalOffset();
			r.top += verticalOffset;
			r.bottom += verticalOffset;
		}

		private int viewportToContentHorizontalOffset()
		{
			return getCompoundPaddingLeft() - mScrollX;
		}

		private int viewportToContentVerticalOffset()
		{
			int offset = getExtendedPaddingTop() - mScrollY;
			if ((mGravity & android.view.Gravity.VERTICAL_GRAVITY_MASK) != android.view.Gravity
				.TOP)
			{
				offset += getVerticalOffset(false);
			}
			return offset;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void debug(int depth)
		{
			base.debug(depth);
			string output = debugIndent(depth);
			output += "frame={" + mLeft + ", " + mTop + ", " + mRight + ", " + mBottom + "} scroll={"
				 + mScrollX + ", " + mScrollY + "} ";
			if (mText != null)
			{
				output += "mText=\"" + mText + "\" ";
				if (mLayout != null)
				{
					output += "mLayout width=" + mLayout.getWidth() + " height=" + mLayout.getHeight(
						);
				}
			}
			else
			{
				output += "mText=NULL";
			}
			android.util.Log.d(VIEW_LOG_TAG, output);
		}

		/// <summary>
		/// Convenience for
		/// <see cref="android.text.Selection.getSelectionStart(java.lang.CharSequence)">android.text.Selection.getSelectionStart(java.lang.CharSequence)
		/// 	</see>
		/// .
		/// </summary>
		public virtual int getSelectionStart()
		{
			return android.text.Selection.getSelectionStart(getText());
		}

		/// <summary>
		/// Convenience for
		/// <see cref="android.text.Selection.getSelectionEnd(java.lang.CharSequence)">android.text.Selection.getSelectionEnd(java.lang.CharSequence)
		/// 	</see>
		/// .
		/// </summary>
		public virtual int getSelectionEnd()
		{
			return android.text.Selection.getSelectionEnd(getText());
		}

		/// <summary>Return true iff there is a selection inside this text view.</summary>
		/// <remarks>Return true iff there is a selection inside this text view.</remarks>
		public virtual bool hasSelection()
		{
			int selectionStart = getSelectionStart();
			int selectionEnd = getSelectionEnd();
			return selectionStart >= 0 && selectionStart != selectionEnd;
		}

		/// <summary>
		/// Sets the properties of this field (lines, horizontally scrolling,
		/// transformation method) to be for a single-line input.
		/// </summary>
		/// <remarks>
		/// Sets the properties of this field (lines, horizontally scrolling,
		/// transformation method) to be for a single-line input.
		/// </remarks>
		/// <attr>ref android.R.styleable#TextView_singleLine</attr>
		public virtual void setSingleLine()
		{
			setSingleLine(true);
		}

		/// <summary>
		/// Sets the properties of this field to transform input to ALL CAPS
		/// display.
		/// </summary>
		/// <remarks>
		/// Sets the properties of this field to transform input to ALL CAPS
		/// display. This may use a "small caps" formatting if available.
		/// This setting will be ignored if this field is editable or selectable.
		/// This call replaces the current transformation method. Disabling this
		/// will not necessarily restore the previous behavior from before this
		/// was enabled.
		/// </remarks>
		/// <seealso cref="setTransformationMethod(android.text.method.TransformationMethod)"
		/// 	>setTransformationMethod(android.text.method.TransformationMethod)</seealso>
		/// <attr>ref android.R.styleable#TextView_textAllCaps</attr>
		public virtual void setAllCaps(bool allCaps)
		{
			if (allCaps)
			{
				setTransformationMethod(new android.text.method.AllCapsTransformationMethod(getContext
					()));
			}
			else
			{
				setTransformationMethod(null);
			}
		}

		/// <summary>
		/// If true, sets the properties of this field (number of lines, horizontally scrolling,
		/// transformation method) to be for a single-line input; if false, restores these to the default
		/// conditions.
		/// </summary>
		/// <remarks>
		/// If true, sets the properties of this field (number of lines, horizontally scrolling,
		/// transformation method) to be for a single-line input; if false, restores these to the default
		/// conditions.
		/// Note that the default conditions are not necessarily those that were in effect prior this
		/// method, and you may want to reset these properties to your custom values.
		/// </remarks>
		/// <attr>ref android.R.styleable#TextView_singleLine</attr>
		[android.view.RemotableViewMethod]
		public virtual void setSingleLine(bool singleLine)
		{
			// Could be used, but may break backward compatibility.
			// if (mSingleLine == singleLine) return;
			setInputTypeSingleLine(singleLine);
			applySingleLine(singleLine, true, true);
		}

		/// <summary>Adds or remove the EditorInfo.TYPE_TEXT_FLAG_MULTI_LINE on the mInputType.
		/// 	</summary>
		/// <remarks>Adds or remove the EditorInfo.TYPE_TEXT_FLAG_MULTI_LINE on the mInputType.
		/// 	</remarks>
		/// <param name="singleLine"></param>
		private void setInputTypeSingleLine(bool singleLine)
		{
			if ((mInputType & android.text.InputTypeClass.TYPE_MASK_CLASS) == android.text.InputTypeClass.TYPE_CLASS_TEXT)
			{
				if (singleLine)
				{
					mInputType &= ~android.text.InputTypeClass.TYPE_TEXT_FLAG_MULTI_LINE;
				}
				else
				{
					mInputType |= android.text.InputTypeClass.TYPE_TEXT_FLAG_MULTI_LINE;
				}
			}
		}

		private void applySingleLine(bool singleLine, bool applyTransformation, bool changeMaxLines
			)
		{
			mSingleLine = singleLine;
			if (singleLine)
			{
				setLines(1);
				setHorizontallyScrolling(true);
				if (applyTransformation)
				{
					setTransformationMethod(android.text.method.SingleLineTransformationMethod.getInstance
						());
				}
			}
			else
			{
				if (changeMaxLines)
				{
					setMaxLines(int.MaxValue);
				}
				setHorizontallyScrolling(false);
				if (applyTransformation)
				{
					setTransformationMethod(null);
				}
			}
		}

		/// <summary>
		/// Causes words in the text that are longer than the view is wide
		/// to be ellipsized instead of broken in the middle.
		/// </summary>
		/// <remarks>
		/// Causes words in the text that are longer than the view is wide
		/// to be ellipsized instead of broken in the middle.  You may also
		/// want to
		/// <see cref="setSingleLine()">setSingleLine()</see>
		/// or
		/// <see cref="setHorizontallyScrolling(bool)">setHorizontallyScrolling(bool)</see>
		/// to constrain the text to a single line.  Use <code>null</code>
		/// to turn off ellipsizing.
		/// If
		/// <see cref="setMaxLines(int)">setMaxLines(int)</see>
		/// has been used to set two or more lines,
		/// <see cref="android.text.TextUtils.TruncateAt.END">android.text.TextUtils.TruncateAt.END
		/// 	</see>
		/// and
		/// <see cref="android.text.TextUtils.TruncateAt.MARQUEE">android.text.TextUtils.TruncateAt.MARQUEE
		/// 	</see>
		/// * are only supported
		/// (other ellipsizing types will not do anything).
		/// </remarks>
		/// <attr>ref android.R.styleable#TextView_ellipsize</attr>
		public virtual void setEllipsize(android.text.TextUtils.TruncateAt? where)
		{
			// TruncateAt is an enum. != comparison is ok between these singleton objects.
			if (mEllipsize != where)
			{
				mEllipsize = where;
				if (mLayout != null)
				{
					nullLayouts();
					requestLayout();
					invalidate();
				}
			}
		}

		/// <summary>Sets how many times to repeat the marquee animation.</summary>
		/// <remarks>
		/// Sets how many times to repeat the marquee animation. Only applied if the
		/// TextView has marquee enabled. Set to -1 to repeat indefinitely.
		/// </remarks>
		/// <attr>ref android.R.styleable#TextView_marqueeRepeatLimit</attr>
		public virtual void setMarqueeRepeatLimit(int marqueeLimit)
		{
			mMarqueeRepeatLimit = marqueeLimit;
		}

		/// <summary>
		/// Returns where, if anywhere, words that are longer than the view
		/// is wide should be ellipsized.
		/// </summary>
		/// <remarks>
		/// Returns where, if anywhere, words that are longer than the view
		/// is wide should be ellipsized.
		/// </remarks>
		[android.view.ViewDebug.ExportedProperty]
		public virtual android.text.TextUtils.TruncateAt? getEllipsize()
		{
			return mEllipsize;
		}

		/// <summary>
		/// Set the TextView so that when it takes focus, all the text is
		/// selected.
		/// </summary>
		/// <remarks>
		/// Set the TextView so that when it takes focus, all the text is
		/// selected.
		/// </remarks>
		/// <attr>ref android.R.styleable#TextView_selectAllOnFocus</attr>
		[android.view.RemotableViewMethod]
		public virtual void setSelectAllOnFocus(bool selectAllOnFocus)
		{
			mSelectAllOnFocus = selectAllOnFocus;
			if (selectAllOnFocus && !(mText is android.text.Spannable))
			{
				setText(mText, android.widget.TextView.BufferType.SPANNABLE);
			}
		}

		/// <summary>Set whether the cursor is visible.</summary>
		/// <remarks>Set whether the cursor is visible.  The default is true.</remarks>
		/// <attr>ref android.R.styleable#TextView_cursorVisible</attr>
		[android.view.RemotableViewMethod]
		public virtual void setCursorVisible(bool visible)
		{
			if (mCursorVisible != visible)
			{
				mCursorVisible = visible;
				invalidate();
				makeBlink();
				// InsertionPointCursorController depends on mCursorVisible
				prepareCursorControllers();
			}
		}

		private bool isCursorVisible()
		{
			return mCursorVisible && isTextEditable();
		}

		private bool canMarquee()
		{
			int width = (mRight - mLeft - getCompoundPaddingLeft() - getCompoundPaddingRight(
				));
			return width > 0 && (mLayout.getLineWidth(0) > width || (mMarqueeFadeMode != MARQUEE_FADE_NORMAL
				 && mSavedMarqueeModeLayout != null && mSavedMarqueeModeLayout.getLineWidth(0) >
				 width));
		}

		private void startMarquee()
		{
			// Do not ellipsize EditText
			if (mInput != null)
			{
				return;
			}
			if (compressText(getWidth() - getCompoundPaddingLeft() - getCompoundPaddingRight(
				)))
			{
				return;
			}
			if ((mMarquee == null || mMarquee.isStopped()) && (isFocused() || isSelected()) &&
				 getLineCount() == 1 && canMarquee())
			{
				if (mMarqueeFadeMode == MARQUEE_FADE_SWITCH_SHOW_ELLIPSIS)
				{
					mMarqueeFadeMode = MARQUEE_FADE_SWITCH_SHOW_FADE;
					android.text.Layout tmp = mLayout;
					mLayout = mSavedMarqueeModeLayout;
					mSavedMarqueeModeLayout = tmp;
					setHorizontalFadingEdgeEnabled(true);
					requestLayout();
					invalidate();
				}
				if (mMarquee == null)
				{
					mMarquee = new android.widget.TextView.Marquee(this);
				}
				mMarquee.start(mMarqueeRepeatLimit);
			}
		}

		private void stopMarquee()
		{
			if (mMarquee != null && !mMarquee.isStopped())
			{
				mMarquee.stop();
			}
			if (mMarqueeFadeMode == MARQUEE_FADE_SWITCH_SHOW_FADE)
			{
				mMarqueeFadeMode = MARQUEE_FADE_SWITCH_SHOW_ELLIPSIS;
				android.text.Layout tmp = mSavedMarqueeModeLayout;
				mSavedMarqueeModeLayout = mLayout;
				mLayout = tmp;
				setHorizontalFadingEdgeEnabled(false);
				requestLayout();
				invalidate();
			}
		}

		private void startStopMarquee(bool start)
		{
			if (mEllipsize == android.text.TextUtils.TruncateAt.MARQUEE)
			{
				if (start)
				{
					startMarquee();
				}
				else
				{
					stopMarquee();
				}
			}
		}

		private sealed class Marquee : android.os.Handler
		{
			internal const float MARQUEE_DELTA_MAX = 0.07f;

			internal const int MARQUEE_DELAY = 1200;

			internal const int MARQUEE_RESTART_DELAY = 1200;

			internal const int MARQUEE_RESOLUTION = 1000 / 30;

			internal const int MARQUEE_PIXELS_PER_SECOND = 30;

			internal const byte MARQUEE_STOPPED = unchecked((int)(0x0));

			internal const byte MARQUEE_STARTING = unchecked((int)(0x1));

			internal const byte MARQUEE_RUNNING = unchecked((int)(0x2));

			internal const int MESSAGE_START = unchecked((int)(0x1));

			internal const int MESSAGE_TICK = unchecked((int)(0x2));

			internal const int MESSAGE_RESTART = unchecked((int)(0x3));

			internal readonly java.lang.@ref.WeakReference<android.widget.TextView> mView;

			internal byte mStatus = MARQUEE_STOPPED;

			internal readonly float mScrollUnit;

			internal float mMaxScroll;

			internal float mMaxFadeScroll;

			internal float mGhostStart;

			internal float mGhostOffset;

			internal float mFadeStop;

			internal int mRepeatLimit;

			internal float mScroll;

			internal Marquee(android.widget.TextView v)
			{
				// TODO: Add an option to configure this
				float density = v.getContext().getResources().getDisplayMetrics().density;
				mScrollUnit = (MARQUEE_PIXELS_PER_SECOND * density) / MARQUEE_RESOLUTION;
				mView = new java.lang.@ref.WeakReference<android.widget.TextView>(v);
			}

			[Sharpen.OverridesMethod(@"android.os.Handler")]
			public override void handleMessage(android.os.Message msg)
			{
				switch (msg.what)
				{
					case MESSAGE_START:
					{
						mStatus = MARQUEE_RUNNING;
						tick();
						break;
					}

					case MESSAGE_TICK:
					{
						tick();
						break;
					}

					case MESSAGE_RESTART:
					{
						if (mStatus == MARQUEE_RUNNING)
						{
							if (mRepeatLimit >= 0)
							{
								mRepeatLimit--;
							}
							start(mRepeatLimit);
						}
						break;
					}
				}
			}

			internal void tick()
			{
				if (mStatus != MARQUEE_RUNNING)
				{
					return;
				}
				removeMessages(MESSAGE_TICK);
				android.widget.TextView textView = mView.get();
				if (textView != null && (textView.isFocused() || textView.isSelected()))
				{
					mScroll += mScrollUnit;
					if (mScroll > mMaxScroll)
					{
						mScroll = mMaxScroll;
						sendEmptyMessageDelayed(MESSAGE_RESTART, MARQUEE_RESTART_DELAY);
					}
					else
					{
						sendEmptyMessageDelayed(MESSAGE_TICK, MARQUEE_RESOLUTION);
					}
					textView.invalidate();
				}
			}

			internal void stop()
			{
				mStatus = MARQUEE_STOPPED;
				removeMessages(MESSAGE_START);
				removeMessages(MESSAGE_RESTART);
				removeMessages(MESSAGE_TICK);
				resetScroll();
			}

			internal void resetScroll()
			{
				mScroll = 0.0f;
				android.widget.TextView textView = mView.get();
				if (textView != null)
				{
					textView.invalidate();
				}
			}

			internal void start(int repeatLimit)
			{
				if (repeatLimit == 0)
				{
					stop();
					return;
				}
				mRepeatLimit = repeatLimit;
				android.widget.TextView textView = mView.get();
				if (textView != null && textView.mLayout != null)
				{
					mStatus = MARQUEE_STARTING;
					mScroll = 0.0f;
					int textWidth = textView.getWidth() - textView.getCompoundPaddingLeft() - textView
						.getCompoundPaddingRight();
					float lineWidth = textView.mLayout.getLineWidth(0);
					float gap = textWidth / 3.0f;
					mGhostStart = lineWidth - textWidth + gap;
					mMaxScroll = mGhostStart + textWidth;
					mGhostOffset = lineWidth + gap;
					mFadeStop = lineWidth + textWidth / 6.0f;
					mMaxFadeScroll = mGhostStart + lineWidth + lineWidth;
					textView.invalidate();
					sendEmptyMessageDelayed(MESSAGE_START, MARQUEE_DELAY);
				}
			}

			internal float getGhostOffset()
			{
				return mGhostOffset;
			}

			internal bool shouldDrawLeftFade()
			{
				return mScroll <= mFadeStop;
			}

			internal bool shouldDrawGhost()
			{
				return mStatus == MARQUEE_RUNNING && mScroll > mGhostStart;
			}

			internal bool isRunning()
			{
				return mStatus == MARQUEE_RUNNING;
			}

			internal bool isStopped()
			{
				return mStatus == MARQUEE_STOPPED;
			}
		}

		/// <summary>
		/// This method is called when the text is changed, in case any subclasses
		/// would like to know.
		/// </summary>
		/// <remarks>
		/// This method is called when the text is changed, in case any subclasses
		/// would like to know.
		/// Within <code>text</code>, the <code>lengthAfter</code> characters
		/// beginning at <code>start</code> have just replaced old text that had
		/// length <code>lengthBefore</code>. It is an error to attempt to make
		/// changes to <code>text</code> from this callback.
		/// </remarks>
		/// <param name="text">The text the TextView is displaying</param>
		/// <param name="start">
		/// The offset of the start of the range of the text that was
		/// modified
		/// </param>
		/// <param name="lengthBefore">The length of the former text that has been replaced</param>
		/// <param name="lengthAfter">The length of the replacement modified text</param>
		protected internal virtual void onTextChanged(java.lang.CharSequence text, int start
			, int lengthBefore, int lengthAfter)
		{
		}

		// intentionally empty, template pattern method can be overridden by subclasses
		/// <summary>
		/// This method is called when the selection has changed, in case any
		/// subclasses would like to know.
		/// </summary>
		/// <remarks>
		/// This method is called when the selection has changed, in case any
		/// subclasses would like to know.
		/// </remarks>
		/// <param name="selStart">The new selection start location.</param>
		/// <param name="selEnd">The new selection end location.</param>
		protected internal virtual void onSelectionChanged(int selStart, int selEnd)
		{
			sendAccessibilityEvent(android.view.accessibility.AccessibilityEvent.TYPE_VIEW_TEXT_SELECTION_CHANGED
				);
		}

		/// <summary>
		/// Adds a TextWatcher to the list of those whose methods are called
		/// whenever this TextView's text changes.
		/// </summary>
		/// <remarks>
		/// Adds a TextWatcher to the list of those whose methods are called
		/// whenever this TextView's text changes.
		/// <p>
		/// In 1.0, the
		/// <see cref="android.text.TextWatcher.afterTextChanged(android.text.Editable)">android.text.TextWatcher.afterTextChanged(android.text.Editable)
		/// 	</see>
		/// method was erroneously
		/// not called after
		/// <see cref="setText(java.lang.CharSequence)">setText(java.lang.CharSequence)</see>
		/// calls.  Now, doing
		/// <see cref="setText(java.lang.CharSequence)">setText(java.lang.CharSequence)</see>
		/// if there are any text changed listeners forces the buffer type to
		/// Editable if it would not otherwise be and does call this method.
		/// </remarks>
		public virtual void addTextChangedListener(android.text.TextWatcher watcher)
		{
			if (mListeners == null)
			{
				mListeners = new java.util.ArrayList<android.text.TextWatcher>();
			}
			mListeners.add(watcher);
		}

		/// <summary>
		/// Removes the specified TextWatcher from the list of those whose
		/// methods are called
		/// whenever this TextView's text changes.
		/// </summary>
		/// <remarks>
		/// Removes the specified TextWatcher from the list of those whose
		/// methods are called
		/// whenever this TextView's text changes.
		/// </remarks>
		public virtual void removeTextChangedListener(android.text.TextWatcher watcher)
		{
			if (mListeners != null)
			{
				int i = mListeners.indexOf(watcher);
				if (i >= 0)
				{
					mListeners.remove(i);
				}
			}
		}

		private void sendBeforeTextChanged(java.lang.CharSequence text, int start, int before
			, int after)
		{
			if (mListeners != null)
			{
				java.util.ArrayList<android.text.TextWatcher> list = mListeners;
				int count = list.size();
				{
					for (int i = 0; i < count; i++)
					{
						list.get(i).beforeTextChanged(text, start, before, after);
					}
				}
			}
			// The spans that are inside or intersect the modified region no longer make sense
			removeIntersectingSpans<android.text.style.SpellCheckSpan>(start, start + before);
			removeIntersectingSpans<android.text.style.SuggestionSpan>(start, start + before);
		}

		// Removes all spans that are inside or actually overlap the start..end range
		private void removeIntersectingSpans<T>(int start, int end)
		{
			System.Type type = typeof(T);
			if (!(mText is android.text.Editable))
			{
				return;
			}
			android.text.Editable text = (android.text.Editable)mText;
			T[] spans = text.getSpans<T>(start, end);
			int length_1 = spans.Length;
			{
				for (int i = 0; i < length_1; i++)
				{
					int s = text.getSpanStart(spans[i]);
					int e = text.getSpanEnd(spans[i]);
					// Spans that are adjacent to the edited region will be handled in
					// updateSpellCheckSpans. Result depends on what will be added (space or text)
					if (e == start || s == end)
					{
						break;
					}
					text.removeSpan(spans[i]);
				}
			}
		}

		/// <summary>
		/// Not private so it can be called from an inner class without going
		/// through a thunk.
		/// </summary>
		/// <remarks>
		/// Not private so it can be called from an inner class without going
		/// through a thunk.
		/// </remarks>
		internal virtual void sendOnTextChanged(java.lang.CharSequence text, int start, int
			 before, int after)
		{
			if (mListeners != null)
			{
				java.util.ArrayList<android.text.TextWatcher> list = mListeners;
				int count = list.size();
				{
					for (int i = 0; i < count; i++)
					{
						list.get(i).onTextChanged(text, start, before, after);
					}
				}
			}
		}

		/// <summary>
		/// Not private so it can be called from an inner class without going
		/// through a thunk.
		/// </summary>
		/// <remarks>
		/// Not private so it can be called from an inner class without going
		/// through a thunk.
		/// </remarks>
		internal virtual void sendAfterTextChanged(android.text.Editable text)
		{
			if (mListeners != null)
			{
				java.util.ArrayList<android.text.TextWatcher> list = mListeners;
				int count = list.size();
				{
					for (int i = 0; i < count; i++)
					{
						list.get(i).afterTextChanged(text);
					}
				}
			}
		}

		/// <summary>
		/// Not private so it can be called from an inner class without going
		/// through a thunk.
		/// </summary>
		/// <remarks>
		/// Not private so it can be called from an inner class without going
		/// through a thunk.
		/// </remarks>
		internal virtual void handleTextChanged(java.lang.CharSequence buffer, int start, 
			int before, int after)
		{
			android.widget.TextView.InputMethodState ims = mInputMethodState;
			if (ims == null || ims.mBatchEditNesting == 0)
			{
				updateAfterEdit();
			}
			if (ims != null)
			{
				ims.mContentChanged = true;
				if (ims.mChangedStart < 0)
				{
					ims.mChangedStart = start;
					ims.mChangedEnd = start + before;
				}
				else
				{
					ims.mChangedStart = System.Math.Min(ims.mChangedStart, start);
					ims.mChangedEnd = System.Math.Max(ims.mChangedEnd, start + before - ims.mChangedDelta
						);
				}
				ims.mChangedDelta += after - before;
			}
			sendOnTextChanged(buffer, start, before, after);
			onTextChanged(buffer, start, before, after);
			updateSpellCheckSpans(start, start + after);
			// Hide the controllers if the amount of content changed
			if (before != after)
			{
				// We do not hide the span controllers, as they can be added when a new text is
				// inserted into the text view
				hideCursorControllers();
			}
		}

		/// <summary>
		/// Not private so it can be called from an inner class without going
		/// through a thunk.
		/// </summary>
		/// <remarks>
		/// Not private so it can be called from an inner class without going
		/// through a thunk.
		/// </remarks>
		internal virtual void spanChange(android.text.Spanned buf, object what, int oldStart
			, int newStart, int oldEnd, int newEnd)
		{
			// XXX Make the start and end move together if this ends up
			// spending too much time invalidating.
			bool selChanged = false;
			int newSelStart = -1;
			int newSelEnd = -1;
			android.widget.TextView.InputMethodState ims = mInputMethodState;
			if (what == android.text.Selection.SELECTION_END)
			{
				mHighlightPathBogus = true;
				selChanged = true;
				newSelEnd = newStart;
				if (!isFocused())
				{
					mSelectionMoved = true;
				}
				if (oldStart >= 0 || newStart >= 0)
				{
					invalidateCursor(android.text.Selection.getSelectionStart(buf), oldStart, newStart
						);
					registerForPreDraw();
					makeBlink();
				}
			}
			if (what == android.text.Selection.SELECTION_START)
			{
				mHighlightPathBogus = true;
				selChanged = true;
				newSelStart = newStart;
				if (!isFocused())
				{
					mSelectionMoved = true;
				}
				if (oldStart >= 0 || newStart >= 0)
				{
					int end = android.text.Selection.getSelectionEnd(buf);
					invalidateCursor(end, oldStart, newStart);
				}
			}
			if (selChanged)
			{
				if ((buf.getSpanFlags(what) & android.text.SpannedClass.SPAN_INTERMEDIATE) == 0)
				{
					if (newSelStart < 0)
					{
						newSelStart = android.text.Selection.getSelectionStart(buf);
					}
					if (newSelEnd < 0)
					{
						newSelEnd = android.text.Selection.getSelectionEnd(buf);
					}
					onSelectionChanged(newSelStart, newSelEnd);
				}
			}
			if (what is android.text.style.UpdateAppearance || what is android.text.style.ParagraphStyle
				 || (what is android.text.style.SuggestionSpan && (((android.text.style.SuggestionSpan
				)what).getFlags() & android.text.style.SuggestionSpan.FLAG_AUTO_CORRECTION) != 0
				))
			{
				if (ims == null || ims.mBatchEditNesting == 0)
				{
					invalidate();
					mHighlightPathBogus = true;
					checkForResize();
				}
				else
				{
					ims.mContentChanged = true;
				}
			}
			if (android.text.method.MetaKeyKeyListener.isMetaTracker(buf, what))
			{
				mHighlightPathBogus = true;
				if (ims != null && android.text.method.MetaKeyKeyListener.isSelectingMetaTracker(
					buf, what))
				{
					ims.mSelectionModeChanged = true;
				}
				if (android.text.Selection.getSelectionStart(buf) >= 0)
				{
					if (ims == null || ims.mBatchEditNesting == 0)
					{
						invalidateCursor();
					}
					else
					{
						ims.mCursorChanged = true;
					}
				}
			}
			if (what is android.text.ParcelableSpan)
			{
				// If this is a span that can be sent to a remote process,
				// the current extract editor would be interested in it.
				if (ims != null && ims.mExtracting != null)
				{
					if (ims.mBatchEditNesting != 0)
					{
						if (oldStart >= 0)
						{
							if (ims.mChangedStart > oldStart)
							{
								ims.mChangedStart = oldStart;
							}
							if (ims.mChangedStart > oldEnd)
							{
								ims.mChangedStart = oldEnd;
							}
						}
						if (newStart >= 0)
						{
							if (ims.mChangedStart > newStart)
							{
								ims.mChangedStart = newStart;
							}
							if (ims.mChangedStart > newEnd)
							{
								ims.mChangedStart = newEnd;
							}
						}
					}
					else
					{
						ims.mContentChanged = true;
					}
				}
			}
			if (newStart < 0 && what is android.text.style.SpellCheckSpan)
			{
				getSpellChecker().removeSpellCheckSpan((android.text.style.SpellCheckSpan)what);
			}
		}

		/// <summary>Create new SpellCheckSpans on the modified region.</summary>
		/// <remarks>Create new SpellCheckSpans on the modified region.</remarks>
		private void updateSpellCheckSpans(int start, int end)
		{
			if (isTextEditable() && isSuggestionsEnabled())
			{
				getSpellChecker().spellCheck(start, end);
			}
		}

		/// <summary>
		/// Controls the
		/// <see cref="android.text.style.EasyEditSpan">android.text.style.EasyEditSpan</see>
		/// monitoring when it is added, and when the related
		/// pop-up should be displayed.
		/// </summary>
		private class EasyEditSpanController
		{
			internal const int DISPLAY_TIMEOUT_MS = 3000;

			internal android.widget.TextView.EasyEditPopupWindow mPopupWindow;

			internal android.text.style.EasyEditSpan mEasyEditSpan;

			internal java.lang.Runnable mHidePopup;

			// 3 secs
			internal void hide()
			{
				if (this.mPopupWindow != null)
				{
					this.mPopupWindow.hide();
					this._enclosing.removeCallbacks(this.mHidePopup);
				}
				this.removeSpans(this._enclosing.mText);
				this.mEasyEditSpan = null;
			}

			internal sealed class _Runnable_7825 : java.lang.Runnable
			{
				public _Runnable_7825(EasyEditSpanController _enclosing)
				{
					this._enclosing = _enclosing;
				}

				// The window is not visible yet, ignore the text change.
				// The view has not been layout yet, ignore the text change
				// The input is in extract mode. We do not have to handle the easy edit in the
				// original TextView, as the ExtractEditText will do
				// Remove the current easy edit span, as the text changed, and remove the pop-up
				// (if any)
				// Display the new easy edit span (if any).
				[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
				public void run()
				{
					this._enclosing.hide();
				}

				private readonly EasyEditSpanController _enclosing;
			}

			/// <summary>Monitors the changes in the text.</summary>
			/// <remarks>
			/// Monitors the changes in the text.
			/// <p>
			/// <see cref="ChangeWatcher.onSpanAdded(android.text.Spannable, object, int, int)">ChangeWatcher.onSpanAdded(android.text.Spannable, object, int, int)
			/// 	</see>
			/// cannot be used,
			/// as the notifications are not sent when a spannable (with spans) is inserted.
			/// </remarks>
			public virtual void onTextChange(java.lang.CharSequence buffer)
			{
				this.adjustSpans(this._enclosing.mText);
				if (this._enclosing.getWindowVisibility() != android.view.View.VISIBLE)
				{
					return;
				}
				if (this._enclosing.mLayout == null)
				{
					return;
				}
				android.view.inputmethod.InputMethodManager imm = android.view.inputmethod.InputMethodManager
					.peekInstance();
				if (!(this._enclosing is android.inputmethodservice.ExtractEditText) && imm != null
					 && imm.isFullscreenMode())
				{
					return;
				}
				if (this.mEasyEditSpan != null)
				{
					if (this._enclosing.mText is android.text.Spannable)
					{
						((android.text.Spannable)this._enclosing.mText).removeSpan(this.mEasyEditSpan);
					}
					this.mEasyEditSpan = null;
				}
				if (this.mPopupWindow != null && this.mPopupWindow.isShowing())
				{
					this.mPopupWindow.hide();
				}
				if (buffer is android.text.Spanned)
				{
					this.mEasyEditSpan = this.getSpan((android.text.Spanned)buffer);
					if (this.mEasyEditSpan != null)
					{
						if (this.mPopupWindow == null)
						{
							this.mPopupWindow = new android.widget.TextView.EasyEditPopupWindow(this._enclosing
								);
							this.mHidePopup = new _Runnable_7825(this);
						}
						this.mPopupWindow.show(this.mEasyEditSpan);
						this._enclosing.removeCallbacks(this.mHidePopup);
						this._enclosing.postDelayed(this.mHidePopup, DISPLAY_TIMEOUT_MS);
					}
				}
			}

			/// <summary>Adjusts the spans by removing all of them except the last one.</summary>
			/// <remarks>Adjusts the spans by removing all of them except the last one.</remarks>
			internal void adjustSpans(java.lang.CharSequence buffer)
			{
				// This method enforces that only one easy edit span is attached to the text.
				// A better way to enforce this would be to listen for onSpanAdded, but this method
				// cannot be used in this scenario as no notification is triggered when a text with
				// spans is inserted into a text.
				if (buffer is android.text.Spannable)
				{
					android.text.Spannable spannable = (android.text.Spannable)buffer;
					android.text.style.EasyEditSpan[] spans = spannable.getSpans<android.text.style.EasyEditSpan
						>(0, spannable.Length);
					{
						for (int i = 0; i < spans.Length - 1; i++)
						{
							spannable.removeSpan(spans[i]);
						}
					}
				}
			}

			/// <summary>
			/// Removes all the
			/// <see cref="android.text.style.EasyEditSpan">android.text.style.EasyEditSpan</see>
			/// currently attached.
			/// </summary>
			internal void removeSpans(java.lang.CharSequence buffer)
			{
				if (buffer is android.text.Spannable)
				{
					android.text.Spannable spannable = (android.text.Spannable)buffer;
					android.text.style.EasyEditSpan[] spans = spannable.getSpans<android.text.style.EasyEditSpan
						>(0, spannable.Length);
					{
						for (int i = 0; i < spans.Length; i++)
						{
							spannable.removeSpan(spans[i]);
						}
					}
				}
			}

			internal android.text.style.EasyEditSpan getSpan(android.text.Spanned spanned)
			{
				android.text.style.EasyEditSpan[] easyEditSpans = spanned.getSpans<android.text.style.EasyEditSpan
					>(0, spanned.Length);
				if (easyEditSpans.Length == 0)
				{
					return null;
				}
				else
				{
					return easyEditSpans[0];
				}
			}

			internal EasyEditSpanController(TextView _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly TextView _enclosing;
		}

		/// <summary>
		/// Displays the actions associated to an
		/// <see cref="android.text.style.EasyEditSpan">android.text.style.EasyEditSpan</see>
		/// . The pop-up is controlled
		/// by
		/// <see cref="EasyEditSpanController">EasyEditSpanController</see>
		/// .
		/// </summary>
		private class EasyEditPopupWindow : android.widget.TextView.PinnedPopupWindow, android.view.View
			.OnClickListener
		{
			internal const int POPUP_TEXT_LAYOUT = android.@internal.R.layout.text_edit_action_popup_text;

			internal android.widget.TextView mDeleteTextView;

			internal android.text.style.EasyEditSpan mEasyEditSpan;

			[Sharpen.OverridesMethod(@"android.widget.TextView.PinnedPopupWindow")]
			protected internal override void createPopupWindow()
			{
				this.mPopupWindow = new android.widget.PopupWindow(this._enclosing.mContext, null
					, android.@internal.R.attr.textSelectHandleWindowStyle);
				this.mPopupWindow.setInputMethodMode(android.widget.PopupWindow.INPUT_METHOD_NOT_NEEDED
					);
				this.mPopupWindow.setClippingEnabled(true);
			}

			[Sharpen.OverridesMethod(@"android.widget.TextView.PinnedPopupWindow")]
			protected internal override void initContentView()
			{
				android.widget.LinearLayout linearLayout = new android.widget.LinearLayout(this._enclosing
					.getContext());
				linearLayout.setOrientation(android.widget.LinearLayout.HORIZONTAL);
				this.mContentView = linearLayout;
				this.mContentView.setBackgroundResource(android.@internal.R.drawable.text_edit_side_paste_window
					);
				android.view.LayoutInflater inflater = (android.view.LayoutInflater)this._enclosing
					.mContext.getSystemService(android.content.Context.LAYOUT_INFLATER_SERVICE);
				android.view.ViewGroup.LayoutParams wrapContent = new android.view.ViewGroup.LayoutParams
					(android.view.ViewGroup.LayoutParams.WRAP_CONTENT, android.view.ViewGroup.LayoutParams
					.WRAP_CONTENT);
				this.mDeleteTextView = (android.widget.TextView)inflater.inflate(POPUP_TEXT_LAYOUT
					, null);
				this.mDeleteTextView.setLayoutParams(wrapContent);
				this.mDeleteTextView.setText(android.@internal.R.@string.delete);
				this.mDeleteTextView.setOnClickListener(this);
				this.mContentView.addView(this.mDeleteTextView);
			}

			public virtual void show(android.text.style.EasyEditSpan easyEditSpan)
			{
				this.mEasyEditSpan = easyEditSpan;
				base.show();
			}

			[Sharpen.ImplementsInterface(@"android.view.View.OnClickListener")]
			public virtual void onClick(android.view.View view)
			{
				if (view == this.mDeleteTextView)
				{
					this.deleteText();
				}
			}

			internal void deleteText()
			{
				android.text.Editable editable = (android.text.Editable)this._enclosing.mText;
				int start = editable.getSpanStart(this.mEasyEditSpan);
				int end = editable.getSpanEnd(this.mEasyEditSpan);
				if (start >= 0 && end >= 0)
				{
					editable.delete(start, end);
				}
			}

			[Sharpen.OverridesMethod(@"android.widget.TextView.PinnedPopupWindow")]
			protected internal override int getTextOffset()
			{
				// Place the pop-up at the end of the span
				android.text.Editable editable = (android.text.Editable)this._enclosing.mText;
				return editable.getSpanEnd(this.mEasyEditSpan);
			}

			[Sharpen.OverridesMethod(@"android.widget.TextView.PinnedPopupWindow")]
			protected internal override int getVerticalLocalPosition(int line)
			{
				return this._enclosing.mLayout.getLineBottom(line);
			}

			[Sharpen.OverridesMethod(@"android.widget.TextView.PinnedPopupWindow")]
			protected internal override int clipVertically(int positionY)
			{
				// As we display the pop-up below the span, no vertical clipping is required.
				return positionY;
			}

			internal EasyEditPopupWindow(TextView _enclosing) : base(_enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly TextView _enclosing;
		}

		private class ChangeWatcher : android.text.TextWatcher, android.text.SpanWatcher
		{
			internal java.lang.CharSequence mBeforeText;

			internal android.widget.TextView.EasyEditSpanController mEasyEditSpanController;

			internal ChangeWatcher(TextView _enclosing)
			{
				this._enclosing = _enclosing;
				this.mEasyEditSpanController = new android.widget.TextView.EasyEditSpanController
					(this._enclosing);
			}

			[Sharpen.ImplementsInterface(@"android.text.TextWatcher")]
			public virtual void beforeTextChanged(java.lang.CharSequence buffer, int start, int
				 before, int after)
			{
				if (android.view.accessibility.AccessibilityManager.getInstance(this._enclosing.mContext
					).isEnabled() && !android.widget.TextView.isPasswordInputType(this._enclosing.mInputType
					) && !this._enclosing.hasPasswordTransformationMethod())
				{
					this.mBeforeText = java.lang.CharSequenceProxy.Wrap(buffer.ToString());
				}
				this._enclosing.sendBeforeTextChanged(buffer, start, before, after);
			}

			[Sharpen.ImplementsInterface(@"android.text.TextWatcher")]
			public virtual void onTextChanged(java.lang.CharSequence buffer, int start, int before
				, int after)
			{
				this._enclosing.handleTextChanged(buffer, start, before, after);
				this.mEasyEditSpanController.onTextChange(buffer);
				if (android.view.accessibility.AccessibilityManager.getInstance(this._enclosing.mContext
					).isEnabled() && (this._enclosing.isFocused() || this._enclosing.isSelected() &&
					 this._enclosing.isShown()))
				{
					this._enclosing.sendAccessibilityEventTypeViewTextChanged(this.mBeforeText, start
						, before, after);
					this.mBeforeText = null;
				}
			}

			[Sharpen.ImplementsInterface(@"android.text.TextWatcher")]
			public virtual void afterTextChanged(android.text.Editable buffer)
			{
				this._enclosing.sendAfterTextChanged(buffer);
				if (android.text.method.MetaKeyKeyListener.getMetaState(buffer, android.text.method.MetaKeyKeyListener
					.META_SELECTING) != 0)
				{
					android.text.method.MetaKeyKeyListener.stopSelecting(this._enclosing, buffer);
				}
			}

			[Sharpen.ImplementsInterface(@"android.text.SpanWatcher")]
			public virtual void onSpanChanged(android.text.Spannable buf, object what, int s, 
				int e, int st, int en)
			{
				this._enclosing.spanChange(buf, what, s, st, e, en);
			}

			[Sharpen.ImplementsInterface(@"android.text.SpanWatcher")]
			public virtual void onSpanAdded(android.text.Spannable buf, object what, int s, int
				 e)
			{
				this._enclosing.spanChange(buf, what, -1, s, -1, e);
			}

			[Sharpen.ImplementsInterface(@"android.text.SpanWatcher")]
			public virtual void onSpanRemoved(android.text.Spannable buf, object what, int s, 
				int e)
			{
				this._enclosing.spanChange(buf, what, s, -1, e, -1);
			}

			internal void hideControllers()
			{
				this.mEasyEditSpanController.hide();
			}

			private readonly TextView _enclosing;
		}

		/// <hide></hide>
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void dispatchFinishTemporaryDetach()
		{
			mDispatchTemporaryDetach = true;
			base.dispatchFinishTemporaryDetach();
			mDispatchTemporaryDetach = false;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void onStartTemporaryDetach()
		{
			base.onStartTemporaryDetach();
			// Only track when onStartTemporaryDetach() is called directly,
			// usually because this instance is an editable field in a list
			if (!mDispatchTemporaryDetach)
			{
				mTemporaryDetach = true;
			}
			// Because of View recycling in ListView, there is no easy way to know when a TextView with
			// selection becomes visible again. Until a better solution is found, stop text selection
			// mode (if any) as soon as this TextView is recycled.
			hideControllers();
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void onFinishTemporaryDetach()
		{
			base.onFinishTemporaryDetach();
			// Only track when onStartTemporaryDetach() is called directly,
			// usually because this instance is an editable field in a list
			if (!mDispatchTemporaryDetach)
			{
				mTemporaryDetach = false;
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onFocusChanged(bool focused, int direction, android.graphics.Rect
			 previouslyFocusedRect)
		{
			if (mTemporaryDetach)
			{
				// If we are temporarily in the detach state, then do nothing.
				base.onFocusChanged(focused, direction, previouslyFocusedRect);
				return;
			}
			mShowCursor = android.os.SystemClock.uptimeMillis();
			ensureEndedBatchEdit();
			if (focused)
			{
				int selStart = getSelectionStart();
				int selEnd = getSelectionEnd();
				// SelectAllOnFocus fields are highlighted and not selected. Do not start text selection
				// mode for these, unless there was a specific selection already started.
				bool isFocusHighlighted = mSelectAllOnFocus && selStart == 0 && selEnd == mText.Length;
				mCreatedWithASelection = mFrozenWithFocus && hasSelection() && !isFocusHighlighted;
				if (!mFrozenWithFocus || (selStart < 0 || selEnd < 0))
				{
					// If a tap was used to give focus to that view, move cursor at tap position.
					// Has to be done before onTakeFocus, which can be overloaded.
					int lastTapPosition = getLastTapPosition();
					if (lastTapPosition >= 0)
					{
						android.text.Selection.setSelection((android.text.Spannable)mText, lastTapPosition
							);
					}
					if (mMovement != null)
					{
						mMovement.onTakeFocus(this, (android.text.Spannable)mText, direction);
					}
					// The DecorView does not have focus when the 'Done' ExtractEditText button is
					// pressed. Since it is the ViewAncestor's mView, it requests focus before
					// ExtractEditText clears focus, which gives focus to the ExtractEditText.
					// This special case ensure that we keep current selection in that case.
					// It would be better to know why the DecorView does not have focus at that time.
					if (((this is android.inputmethodservice.ExtractEditText) || mSelectionMoved) && 
						selStart >= 0 && selEnd >= 0)
					{
						android.text.Selection.setSelection((android.text.Spannable)mText, selStart, selEnd
							);
					}
					if (mSelectAllOnFocus)
					{
						selectAll();
					}
					mTouchFocusSelected = true;
				}
				mFrozenWithFocus = false;
				mSelectionMoved = false;
				if (mText is android.text.Spannable)
				{
					android.text.Spannable sp = (android.text.Spannable)mText;
					android.text.method.MetaKeyKeyListener.resetMetaState(sp);
				}
				makeBlink();
				if (mError != null)
				{
					showError();
				}
			}
			else
			{
				if (mError != null)
				{
					hideError();
				}
				// Don't leave us in the middle of a batch edit.
				onEndBatchEdit();
				if (this is android.inputmethodservice.ExtractEditText)
				{
					// terminateTextSelectionMode removes selection, which we want to keep when
					// ExtractEditText goes out of focus.
					int selStart = getSelectionStart();
					int selEnd = getSelectionEnd();
					hideControllers();
					android.text.Selection.setSelection((android.text.Spannable)mText, selStart, selEnd
						);
				}
				else
				{
					hideControllers();
					downgradeEasyCorrectionSpans();
				}
				// No need to create the controller
				if (mSelectionModifierCursorController != null)
				{
					mSelectionModifierCursorController.resetTouchOffsets();
				}
			}
			startStopMarquee(focused);
			if (mTransformation != null)
			{
				mTransformation.onFocusChanged(this, mText, focused, direction, previouslyFocusedRect
					);
			}
			base.onFocusChanged(focused, direction, previouslyFocusedRect);
		}

		private int getLastTapPosition()
		{
			// No need to create the controller at that point, no last tap position saved
			if (mSelectionModifierCursorController != null)
			{
				int lastTapPosition = mSelectionModifierCursorController.getMinTouchOffset();
				if (lastTapPosition >= 0)
				{
					// Safety check, should not be possible.
					if (lastTapPosition > mText.Length)
					{
						android.util.Log.e(LOG_TAG, "Invalid tap focus position (" + lastTapPosition + " vs "
							 + mText.Length + ")");
						lastTapPosition = mText.Length;
					}
					return lastTapPosition;
				}
			}
			return -1;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void onWindowFocusChanged(bool hasWindowFocus_1)
		{
			base.onWindowFocusChanged(hasWindowFocus_1);
			if (hasWindowFocus_1)
			{
				if (mBlink != null)
				{
					mBlink.uncancel();
					makeBlink();
				}
			}
			else
			{
				if (mBlink != null)
				{
					mBlink.cancel();
				}
				// Don't leave us in the middle of a batch edit.
				onEndBatchEdit();
				if (mInputContentType != null)
				{
					mInputContentType.enterDown = false;
				}
				hideControllers();
			}
			startStopMarquee(hasWindowFocus_1);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onVisibilityChanged(android.view.View changedView
			, int visibility)
		{
			base.onVisibilityChanged(changedView, visibility);
			if (visibility != VISIBLE)
			{
				hideControllers();
			}
		}

		/// <summary>
		/// Use
		/// <see cref="android.view.inputmethod.BaseInputConnection.removeComposingSpans(android.text.Spannable)
		/// 	">BaseInputConnection.removeComposingSpans()</see>
		/// to remove any IME composing
		/// state from this text view.
		/// </summary>
		public virtual void clearComposingText()
		{
			if (mText is android.text.Spannable)
			{
				android.view.inputmethod.BaseInputConnection.removeComposingSpans((android.text.Spannable
					)mText);
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void setSelected(bool selected)
		{
			bool wasSelected = isSelected();
			base.setSelected(selected);
			if (selected != wasSelected && mEllipsize == android.text.TextUtils.TruncateAt.MARQUEE)
			{
				if (selected)
				{
					startMarquee();
				}
				else
				{
					stopMarquee();
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool onTouchEvent(android.view.MotionEvent @event)
		{
			int action = @event.getActionMasked();
			if (hasSelectionController())
			{
				getSelectionController().onTouchEvent(@event);
			}
			if (action == android.view.MotionEvent.ACTION_DOWN)
			{
				mLastDownPositionX = @event.getX();
				mLastDownPositionY = @event.getY();
				// Reset this state; it will be re-set if super.onTouchEvent
				// causes focus to move to the view.
				mTouchFocusSelected = false;
				mIgnoreActionUpEvent = false;
			}
			bool superResult = base.onTouchEvent(@event);
			if (mDiscardNextActionUp && action == android.view.MotionEvent.ACTION_UP)
			{
				mDiscardNextActionUp = false;
				return superResult;
			}
			bool touchIsFinished = (action == android.view.MotionEvent.ACTION_UP) && !shouldIgnoreActionUpEvent
				() && isFocused();
			if ((mMovement != null || onCheckIsTextEditor()) && isEnabled() && mText is android.text.Spannable
				 && mLayout != null)
			{
				bool handled = false;
				if (mMovement != null)
				{
					handled |= mMovement.onTouchEvent(this, (android.text.Spannable)mText, @event);
				}
				if (touchIsFinished && mLinksClickable && mAutoLinkMask != 0 && mTextIsSelectable)
				{
					// The LinkMovementMethod which should handle taps on links has not been installed
					// on non editable text that support text selection.
					// We reproduce its behavior here to open links for these.
					android.text.style.ClickableSpan[] links = ((android.text.Spannable)mText).getSpans
						<android.text.style.ClickableSpan>(getSelectionStart(), getSelectionEnd());
					if (links.Length != 0)
					{
						links[0].onClick(this);
						handled = true;
					}
				}
				if (touchIsFinished && (isTextEditable() || mTextIsSelectable))
				{
					// Show the IME, except when selecting in read-only text.
					android.view.inputmethod.InputMethodManager imm = android.view.inputmethod.InputMethodManager
						.peekInstance();
					viewClicked(imm);
					if (!mTextIsSelectable)
					{
						handled |= imm != null && imm.showSoftInput(this, 0);
					}
					bool selectAllGotFocus = mSelectAllOnFocus && didTouchFocusSelect();
					hideControllers();
					if (!selectAllGotFocus && mText.Length > 0)
					{
						if (mSpellChecker != null)
						{
							// When the cursor moves, the word that was typed may need spell check
							mSpellChecker.onSelectionChanged();
						}
						if (isCursorInsideEasyCorrectionSpan())
						{
							showSuggestions();
						}
						else
						{
							if (hasInsertionController())
							{
								getInsertionController().show();
							}
						}
					}
					handled = true;
				}
				if (handled)
				{
					return true;
				}
			}
			return superResult;
		}

		/// <returns>
		/// <code>true</code> if the cursor/current selection overlaps a
		/// <see cref="android.text.style.SuggestionSpan">android.text.style.SuggestionSpan</see>
		/// .
		/// </returns>
		private bool isCursorInsideSuggestionSpan()
		{
			if (!(mText is android.text.Spannable))
			{
				return false;
			}
			android.text.style.SuggestionSpan[] suggestionSpans = ((android.text.Spannable)mText
				).getSpans<android.text.style.SuggestionSpan>(getSelectionStart(), getSelectionEnd
				());
			return (suggestionSpans.Length > 0);
		}

		/// <returns>
		/// <code>true</code> if the cursor is inside an
		/// <see cref="android.text.style.SuggestionSpan">android.text.style.SuggestionSpan</see>
		/// with
		/// <see cref="android.text.style.SuggestionSpan.FLAG_EASY_CORRECT">android.text.style.SuggestionSpan.FLAG_EASY_CORRECT
		/// 	</see>
		/// set.
		/// </returns>
		private bool isCursorInsideEasyCorrectionSpan()
		{
			android.text.Spannable spannable = (android.text.Spannable)mText;
			android.text.style.SuggestionSpan[] suggestionSpans = spannable.getSpans<android.text.style.SuggestionSpan
				>(getSelectionStart(), getSelectionEnd());
			{
				for (int i = 0; i < suggestionSpans.Length; i++)
				{
					if ((suggestionSpans[i].getFlags() & android.text.style.SuggestionSpan.FLAG_EASY_CORRECT
						) != 0)
					{
						return true;
					}
				}
			}
			return false;
		}

		/// <summary>
		/// Downgrades to simple suggestions all the easy correction spans that are not a spell check
		/// span.
		/// </summary>
		/// <remarks>
		/// Downgrades to simple suggestions all the easy correction spans that are not a spell check
		/// span.
		/// </remarks>
		private void downgradeEasyCorrectionSpans()
		{
			if (mText is android.text.Spannable)
			{
				android.text.Spannable spannable = (android.text.Spannable)mText;
				android.text.style.SuggestionSpan[] suggestionSpans = spannable.getSpans<android.text.style.SuggestionSpan
					>(0, spannable.Length);
				{
					for (int i = 0; i < suggestionSpans.Length; i++)
					{
						int flags = suggestionSpans[i].getFlags();
						if ((flags & android.text.style.SuggestionSpan.FLAG_EASY_CORRECT) != 0 && (flags 
							& android.text.style.SuggestionSpan.FLAG_MISSPELLED) == 0)
						{
							flags &= ~android.text.style.SuggestionSpan.FLAG_EASY_CORRECT;
							suggestionSpans[i].setFlags(flags);
						}
					}
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool onGenericMotionEvent(android.view.MotionEvent @event)
		{
			if (mMovement != null && mText is android.text.Spannable && mLayout != null)
			{
				try
				{
					if (mMovement.onGenericMotionEvent(this, (android.text.Spannable)mText, @event))
					{
						return true;
					}
				}
				catch (java.lang.AbstractMethodError)
				{
				}
			}
			// onGenericMotionEvent was added to the MovementMethod interface in API 12.
			// Ignore its absence in case third party applications implemented the
			// interface directly.
			return base.onGenericMotionEvent(@event);
		}

		private void prepareCursorControllers()
		{
			bool windowSupportsHandles = false;
			android.view.ViewGroup.LayoutParams @params = getRootView().getLayoutParams();
			if (@params is android.view.WindowManagerClass.LayoutParams)
			{
				android.view.WindowManagerClass.LayoutParams windowParams = (android.view.WindowManagerClass
					.LayoutParams)@params;
				windowSupportsHandles = windowParams.type < android.view.WindowManagerClass.LayoutParams
					.FIRST_SUB_WINDOW || windowParams.type > android.view.WindowManagerClass.LayoutParams
					.LAST_SUB_WINDOW;
			}
			mInsertionControllerEnabled = windowSupportsHandles && isCursorVisible() && mLayout
				 != null;
			mSelectionControllerEnabled = windowSupportsHandles && textCanBeSelected() && mLayout
				 != null;
			if (!mInsertionControllerEnabled)
			{
				hideInsertionPointCursorController();
				if (mInsertionPointCursorController != null)
				{
					mInsertionPointCursorController.onDetached();
					mInsertionPointCursorController = null;
				}
			}
			if (!mSelectionControllerEnabled)
			{
				stopSelectionActionMode();
				if (mSelectionModifierCursorController != null)
				{
					mSelectionModifierCursorController.onDetached();
					mSelectionModifierCursorController = null;
				}
			}
		}

		/// <returns>
		/// True iff this TextView contains a text that can be edited, or if this is
		/// a selectable TextView.
		/// </returns>
		private bool isTextEditable()
		{
			return mText is android.text.Editable && onCheckIsTextEditor() && isEnabled();
		}

		/// <summary>
		/// Returns true, only while processing a touch gesture, if the initial
		/// touch down event caused focus to move to the text view and as a result
		/// its selection changed.
		/// </summary>
		/// <remarks>
		/// Returns true, only while processing a touch gesture, if the initial
		/// touch down event caused focus to move to the text view and as a result
		/// its selection changed.  Only valid while processing the touch gesture
		/// of interest.
		/// </remarks>
		public virtual bool didTouchFocusSelect()
		{
			return mTouchFocusSelected;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void cancelLongPress()
		{
			base.cancelLongPress();
			mIgnoreActionUpEvent = true;
		}

		/// <summary>This method is only valid during a touch event.</summary>
		/// <remarks>This method is only valid during a touch event.</remarks>
		/// <returns>true when the ACTION_UP event should be ignored, false otherwise.</returns>
		/// <hide></hide>
		public virtual bool shouldIgnoreActionUpEvent()
		{
			return mIgnoreActionUpEvent;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool onTrackballEvent(android.view.MotionEvent @event)
		{
			if (mMovement != null && mText is android.text.Spannable && mLayout != null)
			{
				if (mMovement.onTrackballEvent(this, (android.text.Spannable)mText, @event))
				{
					return true;
				}
			}
			return base.onTrackballEvent(@event);
		}

		public virtual void setScroller(android.widget.Scroller s)
		{
			mScroller = s;
		}

		private class Blink : android.os.Handler, java.lang.Runnable
		{
			internal readonly java.lang.@ref.WeakReference<android.widget.TextView> mView;

			internal bool mCancelled;

			public Blink(android.widget.TextView v)
			{
				mView = new java.lang.@ref.WeakReference<android.widget.TextView>(v);
			}

			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public virtual void run()
			{
				if (mCancelled)
				{
					return;
				}
				removeCallbacks(this);
				android.widget.TextView tv = mView.get();
				if (tv != null && tv.shouldBlink())
				{
					if (tv.mLayout != null)
					{
						tv.invalidateCursorPath();
					}
					postAtTime(this, android.os.SystemClock.uptimeMillis() + BLINK);
				}
			}

			internal virtual void cancel()
			{
				if (!mCancelled)
				{
					removeCallbacks(this);
					mCancelled = true;
				}
			}

			internal virtual void uncancel()
			{
				mCancelled = false;
			}
		}

		/// <returns>True when the TextView isFocused and has a valid zero-length selection (cursor).
		/// 	</returns>
		private bool shouldBlink()
		{
			if (!isFocused())
			{
				return false;
			}
			int start = getSelectionStart();
			if (start < 0)
			{
				return false;
			}
			int end = getSelectionEnd();
			if (end < 0)
			{
				return false;
			}
			return start == end;
		}

		private void makeBlink()
		{
			if (isCursorVisible())
			{
				if (shouldBlink())
				{
					mShowCursor = android.os.SystemClock.uptimeMillis();
					if (mBlink == null)
					{
						mBlink = new android.widget.TextView.Blink(this);
					}
					mBlink.removeCallbacks(mBlink);
					mBlink.postAtTime(mBlink, mShowCursor + BLINK);
				}
			}
			else
			{
				if (mBlink != null)
				{
					mBlink.removeCallbacks(mBlink);
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override float getLeftFadingEdgeStrength()
		{
			if (mCurrentAlpha <= android.view.ViewConfiguration.ALPHA_THRESHOLD_INT)
			{
				return 0.0f;
			}
			if (mEllipsize == android.text.TextUtils.TruncateAt.MARQUEE && mMarqueeFadeMode !=
				 MARQUEE_FADE_SWITCH_SHOW_ELLIPSIS)
			{
				if (mMarquee != null && !mMarquee.isStopped())
				{
					android.widget.TextView.Marquee marquee = mMarquee;
					if (marquee.shouldDrawLeftFade())
					{
						return marquee.mScroll / getHorizontalFadingEdgeLength();
					}
					else
					{
						return 0.0f;
					}
				}
				else
				{
					if (getLineCount() == 1)
					{
						int layoutDirection = getResolvedLayoutDirection();
						int absoluteGravity = android.view.Gravity.getAbsoluteGravity(mGravity, layoutDirection
							);
						switch (absoluteGravity & android.view.Gravity.HORIZONTAL_GRAVITY_MASK)
						{
							case android.view.Gravity.LEFT:
							{
								return 0.0f;
							}

							case android.view.Gravity.RIGHT:
							{
								return (mLayout.getLineRight(0) - (mRight - mLeft) - getCompoundPaddingLeft() - getCompoundPaddingRight
									() - mLayout.getLineLeft(0)) / getHorizontalFadingEdgeLength();
							}

							case android.view.Gravity.CENTER_HORIZONTAL:
							{
								return 0.0f;
							}
						}
					}
				}
			}
			return base.getLeftFadingEdgeStrength();
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override float getRightFadingEdgeStrength()
		{
			if (mCurrentAlpha <= android.view.ViewConfiguration.ALPHA_THRESHOLD_INT)
			{
				return 0.0f;
			}
			if (mEllipsize == android.text.TextUtils.TruncateAt.MARQUEE && mMarqueeFadeMode !=
				 MARQUEE_FADE_SWITCH_SHOW_ELLIPSIS)
			{
				if (mMarquee != null && !mMarquee.isStopped())
				{
					android.widget.TextView.Marquee marquee = mMarquee;
					return (marquee.mMaxFadeScroll - marquee.mScroll) / getHorizontalFadingEdgeLength
						();
				}
				else
				{
					if (getLineCount() == 1)
					{
						int layoutDirection = getResolvedLayoutDirection();
						int absoluteGravity = android.view.Gravity.getAbsoluteGravity(mGravity, layoutDirection
							);
						switch (absoluteGravity & android.view.Gravity.HORIZONTAL_GRAVITY_MASK)
						{
							case android.view.Gravity.LEFT:
							{
								int textWidth = (mRight - mLeft) - getCompoundPaddingLeft() - getCompoundPaddingRight
									();
								float lineWidth = mLayout.getLineWidth(0);
								return (lineWidth - textWidth) / getHorizontalFadingEdgeLength();
							}

							case android.view.Gravity.RIGHT:
							{
								return 0.0f;
							}

							case android.view.Gravity.CENTER_HORIZONTAL:
							case android.view.Gravity.FILL_HORIZONTAL:
							{
								return (mLayout.getLineWidth(0) - ((mRight - mLeft) - getCompoundPaddingLeft() - 
									getCompoundPaddingRight())) / getHorizontalFadingEdgeLength();
							}
						}
					}
				}
			}
			return base.getRightFadingEdgeStrength();
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override int computeHorizontalScrollRange()
		{
			if (mLayout != null)
			{
				return mSingleLine && (mGravity & android.view.Gravity.HORIZONTAL_GRAVITY_MASK) ==
					 android.view.Gravity.LEFT ? (int)mLayout.getLineWidth(0) : mLayout.getWidth();
			}
			return base.computeHorizontalScrollRange();
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override int computeVerticalScrollRange()
		{
			if (mLayout != null)
			{
				return mLayout.getHeight();
			}
			return base.computeVerticalScrollRange();
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override int computeVerticalScrollExtent()
		{
			return getHeight() - getCompoundPaddingTop() - getCompoundPaddingBottom();
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void findViewsWithText(java.util.ArrayList<android.view.View> outViews
			, java.lang.CharSequence searched, int flags)
		{
			base.findViewsWithText(outViews, searched, flags);
			if (!outViews.contains(this) && (flags & FIND_VIEWS_WITH_TEXT) != 0 && !android.text.TextUtils
				.isEmpty(searched) && !android.text.TextUtils.isEmpty(mText))
			{
				string searchedLowerCase = searched.ToString().ToLower();
				string textLowerCase = mText.ToString().ToLower();
				if (textLowerCase.Contains(searchedLowerCase))
				{
					outViews.add(this);
				}
			}
		}

		public enum BufferType
		{
			NORMAL,
			SPANNABLE,
			EDITABLE
		}

		/// <summary>
		/// Returns the TextView_textColor attribute from the
		/// Resources.StyledAttributes, if set, or the TextAppearance_textColor
		/// from the TextView_textAppearance attribute, if TextView_textColor
		/// was not set directly.
		/// </summary>
		/// <remarks>
		/// Returns the TextView_textColor attribute from the
		/// Resources.StyledAttributes, if set, or the TextAppearance_textColor
		/// from the TextView_textAppearance attribute, if TextView_textColor
		/// was not set directly.
		/// </remarks>
		public static android.content.res.ColorStateList getTextColors(android.content.Context
			 context, android.content.res.TypedArray attrs)
		{
			android.content.res.ColorStateList colors;
			colors = attrs.getColorStateList(android.@internal.R.styleable.TextView_textColor
				);
			if (colors == null)
			{
				int ap = attrs.getResourceId(android.@internal.R.styleable.TextView_textAppearance
					, -1);
				if (ap != -1)
				{
					android.content.res.TypedArray appearance;
					appearance = context.obtainStyledAttributes(ap, android.@internal.R.styleable.TextAppearance
						);
					colors = appearance.getColorStateList(android.@internal.R.styleable.TextAppearance_textColor
						);
					appearance.recycle();
				}
			}
			return colors;
		}

		/// <summary>
		/// Returns the default color from the TextView_textColor attribute
		/// from the AttributeSet, if set, or the default color from the
		/// TextAppearance_textColor from the TextView_textAppearance attribute,
		/// if TextView_textColor was not set directly.
		/// </summary>
		/// <remarks>
		/// Returns the default color from the TextView_textColor attribute
		/// from the AttributeSet, if set, or the default color from the
		/// TextAppearance_textColor from the TextView_textAppearance attribute,
		/// if TextView_textColor was not set directly.
		/// </remarks>
		public static int getTextColor(android.content.Context context, android.content.res.TypedArray
			 attrs, int def)
		{
			android.content.res.ColorStateList colors = getTextColors(context, attrs);
			if (colors == null)
			{
				return def;
			}
			else
			{
				return colors.getDefaultColor();
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool onKeyShortcut(int keyCode, android.view.KeyEvent @event)
		{
			int filteredMetaState = @event.getMetaState() & ~android.view.KeyEvent.META_CTRL_MASK;
			if (android.view.KeyEvent.metaStateHasNoModifiers(filteredMetaState))
			{
				switch (keyCode)
				{
					case android.view.KeyEvent.KEYCODE_A:
					{
						if (canSelectText())
						{
							return onTextContextMenuItem(ID_SELECT_ALL);
						}
						break;
					}

					case android.view.KeyEvent.KEYCODE_X:
					{
						if (canCut())
						{
							return onTextContextMenuItem(ID_CUT);
						}
						break;
					}

					case android.view.KeyEvent.KEYCODE_C:
					{
						if (canCopy())
						{
							return onTextContextMenuItem(ID_COPY);
						}
						break;
					}

					case android.view.KeyEvent.KEYCODE_V:
					{
						if (canPaste())
						{
							return onTextContextMenuItem(ID_PASTE);
						}
						break;
					}
				}
			}
			return base.onKeyShortcut(keyCode, @event);
		}

		/// <summary>
		/// Unlike
		/// <see cref="textCanBeSelected()">textCanBeSelected()</see>
		/// , this method is based on the <i>current</i> state of the
		/// TextView.
		/// <see cref="textCanBeSelected()">textCanBeSelected()</see>
		/// has to be true (this is one of the conditions to have
		/// a selection controller (see
		/// <see cref="prepareCursorControllers()">prepareCursorControllers()</see>
		/// ), but this is not sufficient.
		/// </summary>
		private bool canSelectText()
		{
			return hasSelectionController() && mText.Length != 0;
		}

		/// <summary>Test based on the <i>intrinsic</i> charateristics of the TextView.</summary>
		/// <remarks>
		/// Test based on the <i>intrinsic</i> charateristics of the TextView.
		/// The text must be spannable and the movement method must allow for arbitary selection.
		/// See also
		/// <see cref="canSelectText()">canSelectText()</see>
		/// .
		/// </remarks>
		private bool textCanBeSelected()
		{
			// prepareCursorController() relies on this method.
			// If you change this condition, make sure prepareCursorController is called anywhere
			// the value of this condition might be changed.
			if (mMovement == null || !mMovement.canSelectArbitrarily())
			{
				return false;
			}
			return isTextEditable() || (mTextIsSelectable && mText is android.text.Spannable 
				&& isEnabled());
		}

		private bool canCut()
		{
			if (hasPasswordTransformationMethod())
			{
				return false;
			}
			if (mText.Length > 0 && hasSelection() && mText is android.text.Editable && mInput
				 != null)
			{
				return true;
			}
			return false;
		}

		private bool canCopy()
		{
			if (hasPasswordTransformationMethod())
			{
				return false;
			}
			if (mText.Length > 0 && hasSelection())
			{
				return true;
			}
			return false;
		}

		private bool canPaste()
		{
			return (mText is android.text.Editable && mInput != null && getSelectionStart() >=
				 0 && getSelectionEnd() >= 0 && ((android.content.ClipboardManager)getContext().
				getSystemService(android.content.Context.CLIPBOARD_SERVICE)).hasPrimaryClip());
		}

		private static long packRangeInLong(int start, int end)
		{
			return (((long)start) << 32) | end;
		}

		private static int extractRangeStartFromLong(long range)
		{
			return (int)((long)(((ulong)range) >> 32));
		}

		private static int extractRangeEndFromLong(long range)
		{
			return (int)(range & unchecked((long)(0x00000000FFFFFFFFL)));
		}

		private bool selectAll()
		{
			int length_1 = mText.Length;
			android.text.Selection.setSelection((android.text.Spannable)mText, 0, length_1);
			return length_1 > 0;
		}

		/// <summary>Adjusts selection to the word under last touch offset.</summary>
		/// <remarks>
		/// Adjusts selection to the word under last touch offset.
		/// Return true if the operation was successfully performed.
		/// </remarks>
		private bool selectCurrentWord()
		{
			if (!canSelectText())
			{
				return false;
			}
			if (hasPasswordTransformationMethod())
			{
				// Always select all on a password field.
				// Cut/copy menu entries are not available for passwords, but being able to select all
				// is however useful to delete or paste to replace the entire content.
				return selectAll();
			}
			int klass = mInputType & android.text.InputTypeClass.TYPE_MASK_CLASS;
			int variation = mInputType & android.text.InputTypeClass.TYPE_MASK_VARIATION;
			// Specific text field types: select the entire text for these
			if (klass == android.text.InputTypeClass.TYPE_CLASS_NUMBER || klass == android.text.InputTypeClass.TYPE_CLASS_PHONE
				 || klass == android.text.InputTypeClass.TYPE_CLASS_DATETIME || variation == android.text.InputTypeClass.TYPE_TEXT_VARIATION_URI
				 || variation == android.text.InputTypeClass.TYPE_TEXT_VARIATION_EMAIL_ADDRESS ||
				 variation == android.text.InputTypeClass.TYPE_TEXT_VARIATION_WEB_EMAIL_ADDRESS 
				|| variation == android.text.InputTypeClass.TYPE_TEXT_VARIATION_FILTER)
			{
				return selectAll();
			}
			long lastTouchOffsets = getLastTouchOffsets();
			int minOffset = extractRangeStartFromLong(lastTouchOffsets);
			int maxOffset = extractRangeEndFromLong(lastTouchOffsets);
			// Safety check in case standard touch event handling has been bypassed
			if (minOffset < 0 || minOffset >= mText.Length)
			{
				return false;
			}
			if (maxOffset < 0 || maxOffset >= mText.Length)
			{
				return false;
			}
			int selectionStart;
			int selectionEnd;
			// If a URLSpan (web address, email, phone...) is found at that position, select it.
			android.text.style.URLSpan[] urlSpans = ((android.text.Spanned)mText).getSpans<android.text.style.URLSpan
				>(minOffset, maxOffset);
			if (urlSpans.Length >= 1)
			{
				android.text.style.URLSpan urlSpan = urlSpans[0];
				selectionStart = ((android.text.Spanned)mText).getSpanStart(urlSpan);
				selectionEnd = ((android.text.Spanned)mText).getSpanEnd(urlSpan);
			}
			else
			{
				if (mWordIterator == null)
				{
					mWordIterator = new android.text.method.WordIterator();
				}
				mWordIterator.setCharSequence(mText, minOffset, maxOffset);
				selectionStart = mWordIterator.getBeginning(minOffset);
				if (selectionStart == java.text.BreakIterator.DONE)
				{
					return false;
				}
				selectionEnd = mWordIterator.getEnd(maxOffset);
				if (selectionEnd == java.text.BreakIterator.DONE)
				{
					return false;
				}
				if (selectionStart == selectionEnd)
				{
					// Possible when the word iterator does not properly handle the text's language
					long range = getCharRange(selectionStart);
					selectionStart = extractRangeStartFromLong(range);
					selectionEnd = extractRangeEndFromLong(range);
				}
			}
			android.text.Selection.setSelection((android.text.Spannable)mText, selectionStart
				, selectionEnd);
			return selectionEnd > selectionStart;
		}

		private long getCharRange(int offset)
		{
			int textLength = mText.Length;
			if (offset + 1 < textLength)
			{
				char currentChar = mText[offset];
				char nextChar = mText[offset + 1];
				if (System.Char.IsSurrogatePair(currentChar, nextChar))
				{
					return packRangeInLong(offset, offset + 2);
				}
			}
			if (offset < textLength)
			{
				return packRangeInLong(offset, offset + 1);
			}
			if (offset - 2 >= 0)
			{
				char previousChar = mText[offset - 1];
				char previousPreviousChar = mText[offset - 2];
				if (System.Char.IsSurrogatePair(previousPreviousChar, previousChar))
				{
					return packRangeInLong(offset - 2, offset);
				}
			}
			if (offset - 1 >= 0)
			{
				return packRangeInLong(offset - 1, offset);
			}
			return packRangeInLong(offset, offset);
		}

		private android.widget.SpellChecker getSpellChecker()
		{
			if (mSpellChecker == null)
			{
				mSpellChecker = new android.widget.SpellChecker(this);
			}
			return mSpellChecker;
		}

		private long getLastTouchOffsets()
		{
			int minOffset;
			int maxOffset;
			if (mContextMenuTriggeredByKey)
			{
				minOffset = getSelectionStart();
				maxOffset = getSelectionEnd();
			}
			else
			{
				android.widget.TextView.SelectionModifierCursorController selectionController = getSelectionController
					();
				minOffset = selectionController.getMinTouchOffset();
				maxOffset = selectionController.getMaxTouchOffset();
			}
			return packRangeInLong(minOffset, maxOffset);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void onPopulateAccessibilityEvent(android.view.accessibility.AccessibilityEvent
			 @event)
		{
			base.onPopulateAccessibilityEvent(@event);
			bool isPassword = hasPasswordTransformationMethod();
			if (!isPassword)
			{
				java.lang.CharSequence text = getTextForAccessibility();
				if (!android.text.TextUtils.isEmpty(text))
				{
					@event.getText().add(text);
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void onInitializeAccessibilityEvent(android.view.accessibility.AccessibilityEvent
			 @event)
		{
			base.onInitializeAccessibilityEvent(@event);
			bool isPassword = hasPasswordTransformationMethod();
			@event.setPassword(isPassword);
			if (@event.getEventType() == android.view.accessibility.AccessibilityEvent.TYPE_VIEW_TEXT_SELECTION_CHANGED)
			{
				@event.setFromIndex(android.text.Selection.getSelectionStart(mText));
				@event.setToIndex(android.text.Selection.getSelectionEnd(mText));
				@event.setItemCount(mText.Length);
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void onInitializeAccessibilityNodeInfo(android.view.accessibility.AccessibilityNodeInfo
			 info)
		{
			base.onInitializeAccessibilityNodeInfo(info);
			bool isPassword = hasPasswordTransformationMethod();
			if (!isPassword)
			{
				info.setText(getTextForAccessibility());
			}
			info.setPassword(isPassword);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void sendAccessibilityEvent(int eventType)
		{
			// Do not send scroll events since first they are not interesting for
			// accessibility and second such events a generated too frequently.
			// For details see the implementation of bringTextIntoView().
			if (eventType == android.view.accessibility.AccessibilityEvent.TYPE_VIEW_SCROLLED)
			{
				return;
			}
			base.sendAccessibilityEvent(eventType);
		}

		/// <summary>Gets the text reported for accessibility purposes.</summary>
		/// <remarks>
		/// Gets the text reported for accessibility purposes. It is the
		/// text if not empty or the hint.
		/// </remarks>
		/// <returns>The accessibility text.</returns>
		private java.lang.CharSequence getTextForAccessibility()
		{
			java.lang.CharSequence text = getText();
			if (android.text.TextUtils.isEmpty(text))
			{
				text = getHint();
			}
			return text;
		}

		internal virtual void sendAccessibilityEventTypeViewTextChanged(java.lang.CharSequence
			 beforeText, int fromIndex, int removedCount, int addedCount)
		{
			android.view.accessibility.AccessibilityEvent @event = android.view.accessibility.AccessibilityEvent
				.obtain(android.view.accessibility.AccessibilityEvent.TYPE_VIEW_TEXT_CHANGED);
			@event.setFromIndex(fromIndex);
			@event.setRemovedCount(removedCount);
			@event.setAddedCount(addedCount);
			@event.setBeforeText(beforeText);
			sendAccessibilityEventUnchecked(@event);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onCreateContextMenu(android.view.ContextMenu menu
			)
		{
			base.onCreateContextMenu(menu);
			bool added = false;
			mContextMenuTriggeredByKey = mDPadCenterIsDown || mEnterKeyIsDown;
			// Problem with context menu on long press: the menu appears while the key in down and when
			// the key is released, the view does not receive the key_up event.
			// We need two layers of flags: mDPadCenterIsDown and mEnterKeyIsDown are set in key down/up
			// events. We cannot simply clear these flags in onTextContextMenuItem since
			// it may not be called (if the user/ discards the context menu with the back key).
			// We clear these flags here and mContextMenuTriggeredByKey saves that state so that it is
			// available in onTextContextMenuItem.
			mDPadCenterIsDown = mEnterKeyIsDown = false;
			android.widget.TextView.MenuHandler handler = new android.widget.TextView.MenuHandler
				(this);
			if (mText is android.text.Spanned && hasSelectionController())
			{
				long lastTouchOffset = getLastTouchOffsets();
				int selStart = extractRangeStartFromLong(lastTouchOffset);
				int selEnd = extractRangeEndFromLong(lastTouchOffset);
				android.text.style.URLSpan[] urls = ((android.text.Spanned)mText).getSpans<android.text.style.URLSpan
					>(selStart, selEnd);
				if (urls.Length > 0)
				{
					menu.add(0, ID_COPY_URL, 0, android.@internal.R.@string.copyUrl).setOnMenuItemClickListener
						(handler);
					added = true;
				}
			}
			// The context menu is not empty, which will prevent the selection mode from starting.
			// Add a entry to start it in the context menu.
			// TODO Does not handle the case where a subclass does not call super.thisMethod or
			// populates the menu AFTER this call.
			if (menu.size() > 0)
			{
				menu.add(0, ID_SELECTION_MODE, 0, android.@internal.R.@string.selectTextMode).setOnMenuItemClickListener
					(handler);
				added = true;
			}
			if (added)
			{
				menu.setHeaderTitle(android.@internal.R.@string.editTextMenuTitle);
			}
		}

		/// <summary>Returns whether this text view is a current input method target.</summary>
		/// <remarks>
		/// Returns whether this text view is a current input method target.  The
		/// default implementation just checks with
		/// <see cref="android.view.inputmethod.InputMethodManager">android.view.inputmethod.InputMethodManager
		/// 	</see>
		/// .
		/// </remarks>
		public virtual bool isInputMethodTarget()
		{
			android.view.inputmethod.InputMethodManager imm = android.view.inputmethod.InputMethodManager
				.peekInstance();
			return imm != null && imm.isActive(this);
		}

		internal const int ID_SELECT_ALL = android.R.id.selectAll;

		internal const int ID_CUT = android.R.id.cut;

		internal const int ID_COPY = android.R.id.copy;

		internal const int ID_PASTE = android.R.id.paste;

		internal const int ID_COPY_URL = android.R.id.copyUrl;

		internal const int ID_SELECTION_MODE = android.R.id.selectTextMode;

		private class MenuHandler : android.view.MenuItemClass.OnMenuItemClickListener
		{
			// Selection context mode
			// Context menu entries
			[Sharpen.ImplementsInterface(@"android.view.MenuItem.OnMenuItemClickListener")]
			public virtual bool onMenuItemClick(android.view.MenuItem item)
			{
				return this._enclosing.onTextContextMenuItem(item.getItemId());
			}

			internal MenuHandler(TextView _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly TextView _enclosing;
		}

		/// <summary>Called when a context menu option for the text view is selected.</summary>
		/// <remarks>
		/// Called when a context menu option for the text view is selected.  Currently
		/// this will be
		/// <see cref="android.R.id.copyUrl">android.R.id.copyUrl</see>
		/// ,
		/// <see cref="android.R.id.selectTextMode">android.R.id.selectTextMode</see>
		/// ,
		/// <see cref="android.R.id.selectAll">android.R.id.selectAll</see>
		/// ,
		/// <see cref="android.R.id.paste">android.R.id.paste</see>
		/// ,
		/// <see cref="android.R.id.cut">android.R.id.cut</see>
		/// or
		/// <see cref="android.R.id.copy">android.R.id.copy</see>
		/// .
		/// </remarks>
		/// <returns>true if the context menu item action was performed.</returns>
		public virtual bool onTextContextMenuItem(int id)
		{
			int min = 0;
			int max = mText.Length;
			if (isFocused())
			{
				int selStart = getSelectionStart();
				int selEnd = getSelectionEnd();
				min = System.Math.Max(0, System.Math.Min(selStart, selEnd));
				max = System.Math.Max(0, System.Math.Max(selStart, selEnd));
			}
			switch (id)
			{
				case ID_COPY_URL:
				{
					android.text.style.URLSpan[] urls = ((android.text.Spanned)mText).getSpans<android.text.style.URLSpan
						>(min, max);
					if (urls.Length >= 1)
					{
						android.content.ClipData clip = null;
						{
							for (int i = 0; i < urls.Length; i++)
							{
								System.Uri uri = Sharpen.Util.ParseUri(urls[0].getURL());
								if (clip == null)
								{
									clip = android.content.ClipData.newRawUri(null, uri);
								}
								else
								{
									clip.addItem(new android.content.ClipData.Item(uri));
								}
							}
						}
						if (clip != null)
						{
							setPrimaryClip(clip);
						}
					}
					stopSelectionActionMode();
					return true;
				}

				case ID_SELECTION_MODE:
				{
					if (mSelectionActionMode != null)
					{
						// Selection mode is already started, simply change selected part.
						selectCurrentWord();
					}
					else
					{
						startSelectionActionMode();
					}
					return true;
				}

				case ID_SELECT_ALL:
				{
					// This does not enter text selection mode. Text is highlighted, so that it can be
					// bulk edited, like selectAllOnFocus does. Returns true even if text is empty.
					selectAll();
					return true;
				}

				case ID_PASTE:
				{
					paste(min, max);
					return true;
				}

				case ID_CUT:
				{
					setPrimaryClip(android.content.ClipData.newPlainText(null, getTransformedText(min
						, max)));
					((android.text.Editable)mText).delete(min, max);
					stopSelectionActionMode();
					return true;
				}

				case ID_COPY:
				{
					setPrimaryClip(android.content.ClipData.newPlainText(null, getTransformedText(min
						, max)));
					stopSelectionActionMode();
					return true;
				}
			}
			return false;
		}

		private java.lang.CharSequence getTransformedText(int start, int end)
		{
			return removeSuggestionSpans(mTransformed.SubSequence(start, end));
		}

		/// <summary>
		/// Prepare text so that there are not zero or two spaces at beginning and end of region defined
		/// by [min, max] when replacing this region by paste.
		/// </summary>
		/// <remarks>
		/// Prepare text so that there are not zero or two spaces at beginning and end of region defined
		/// by [min, max] when replacing this region by paste.
		/// Note that if there were two spaces (or more) at that position before, they are kept. We just
		/// make sure we do not add an extra one from the paste content.
		/// </remarks>
		private long prepareSpacesAroundPaste(int min, int max, java.lang.CharSequence paste_1
			)
		{
			if (paste_1.Length > 0)
			{
				if (min > 0)
				{
					char charBefore = mTransformed[min - 1];
					char charAfter = paste_1[0];
					if (System.Char.IsWhiteSpace(charBefore) && System.Char.IsWhiteSpace(charAfter))
					{
						// Two spaces at beginning of paste: remove one
						int originalLength = mText.Length;
						((android.text.Editable)mText).delete(min - 1, min);
						// Due to filters, there is no guarantee that exactly one character was
						// removed: count instead.
						int delta = mText.Length - originalLength;
						min += delta;
						max += delta;
					}
					else
					{
						if (!System.Char.IsWhiteSpace(charBefore) && charBefore != '\n' && !System.Char.IsWhiteSpace
							(charAfter) && charAfter != '\n')
						{
							// No space at beginning of paste: add one
							int originalLength = mText.Length;
							((android.text.Editable)mText).replace(min, min, java.lang.CharSequenceProxy.Wrap
								(" "));
							// Taking possible filters into account as above.
							int delta = mText.Length - originalLength;
							min += delta;
							max += delta;
						}
					}
				}
				if (max < mText.Length)
				{
					char charBefore = paste_1[paste_1.Length - 1];
					char charAfter = mTransformed[max];
					if (System.Char.IsWhiteSpace(charBefore) && System.Char.IsWhiteSpace(charAfter))
					{
						// Two spaces at end of paste: remove one
						((android.text.Editable)mText).delete(max, max + 1);
					}
					else
					{
						if (!System.Char.IsWhiteSpace(charBefore) && charBefore != '\n' && !System.Char.IsWhiteSpace
							(charAfter) && charAfter != '\n')
						{
							// No space at end of paste: add one
							((android.text.Editable)mText).replace(max, max, java.lang.CharSequenceProxy.Wrap
								(" "));
						}
					}
				}
			}
			return packRangeInLong(min, max);
		}

		private android.view.View.DragShadowBuilder getTextThumbnailBuilder(java.lang.CharSequence
			 text)
		{
			android.widget.TextView shadowView = (android.widget.TextView)inflate(mContext, android.@internal.R
				.layout.text_drag_thumbnail, null);
			if (shadowView == null)
			{
				throw new System.ArgumentException("Unable to inflate text drag thumbnail");
			}
			if (text.Length > DRAG_SHADOW_MAX_TEXT_LENGTH)
			{
				text = text.SubSequence(0, DRAG_SHADOW_MAX_TEXT_LENGTH);
			}
			shadowView.setText(text);
			shadowView.setTextColor(getTextColors());
			shadowView.setTextAppearance(mContext, android.R.styleable.Theme_textAppearanceLarge
				);
			shadowView.setGravity(android.view.Gravity.CENTER);
			shadowView.setLayoutParams(new android.view.ViewGroup.LayoutParams(android.view.ViewGroup
				.LayoutParams.WRAP_CONTENT, android.view.ViewGroup.LayoutParams.WRAP_CONTENT));
			int size = android.view.View.MeasureSpec.makeMeasureSpec(0, android.view.View.MeasureSpec
				.UNSPECIFIED);
			shadowView.measure(size, size);
			shadowView.layout(0, 0, shadowView.getMeasuredWidth(), shadowView.getMeasuredHeight
				());
			shadowView.invalidate();
			return new android.view.View.DragShadowBuilder(shadowView);
		}

		private class DragLocalState
		{
			public android.widget.TextView sourceTextView;

			public int start;

			public int end;

			public DragLocalState(android.widget.TextView sourceTextView, int start, int end)
			{
				this.sourceTextView = sourceTextView;
				this.start = start;
				this.end = end;
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool performLongClick()
		{
			bool handled = false;
			bool vibrate = true;
			if (base.performLongClick())
			{
				mDiscardNextActionUp = true;
				handled = true;
			}
			// Long press in empty space moves cursor and shows the Paste affordance if available.
			if (!handled && !isPositionOnText(mLastDownPositionX, mLastDownPositionY) && mInsertionControllerEnabled)
			{
				int offset = getOffsetForPosition(mLastDownPositionX, mLastDownPositionY);
				stopSelectionActionMode();
				android.text.Selection.setSelection((android.text.Spannable)mText, offset);
				getInsertionController().showWithActionPopup();
				handled = true;
				vibrate = false;
			}
			if (!handled && mSelectionActionMode != null)
			{
				if (touchPositionIsInSelection())
				{
					// Start a drag
					int start = getSelectionStart();
					int end = getSelectionEnd();
					java.lang.CharSequence selectedText = getTransformedText(start, end);
					android.content.ClipData data = android.content.ClipData.newPlainText(null, selectedText
						);
					android.widget.TextView.DragLocalState localState = new android.widget.TextView.DragLocalState
						(this, start, end);
					startDrag(data, getTextThumbnailBuilder(selectedText), localState, 0);
					stopSelectionActionMode();
				}
				else
				{
					getSelectionController().hide();
					selectCurrentWord();
					getSelectionController().show();
				}
				handled = true;
			}
			// Start a new selection
			if (!handled)
			{
				vibrate = handled = startSelectionActionMode();
			}
			if (vibrate)
			{
				performHapticFeedback(android.view.HapticFeedbackConstants.LONG_PRESS);
			}
			if (handled)
			{
				mDiscardNextActionUp = true;
			}
			return handled;
		}

		private bool touchPositionIsInSelection()
		{
			int selectionStart = getSelectionStart();
			int selectionEnd = getSelectionEnd();
			if (selectionStart == selectionEnd)
			{
				return false;
			}
			if (selectionStart > selectionEnd)
			{
				int tmp = selectionStart;
				selectionStart = selectionEnd;
				selectionEnd = tmp;
				android.text.Selection.setSelection((android.text.Spannable)mText, selectionStart
					, selectionEnd);
			}
			android.widget.TextView.SelectionModifierCursorController selectionController = getSelectionController
				();
			int minOffset = selectionController.getMinTouchOffset();
			int maxOffset = selectionController.getMaxTouchOffset();
			return ((minOffset >= selectionStart) && (maxOffset < selectionEnd));
		}

		private android.widget.TextView.PositionListener getPositionListener()
		{
			if (mPositionListener == null)
			{
				mPositionListener = new android.widget.TextView.PositionListener(this);
			}
			return mPositionListener;
		}

		private interface TextViewPositionListener
		{
			void updatePosition(int parentPositionX, int parentPositionY, bool parentPositionChanged
				, bool parentScrolled);
		}

		private class PositionListener : android.view.ViewTreeObserver.OnPreDrawListener
		{
			internal readonly int MAXIMUM_NUMBER_OF_LISTENERS;

			internal android.widget.TextView.TextViewPositionListener[] mPositionListeners;

			internal bool[] mCanMove;

			internal bool mPositionHasChanged;

			internal int mPositionX;

			internal int mPositionY;

			internal int mNumberOfListeners;

			internal bool mScrollHasChanged;

			// 3 handles
			// 3 ActionPopup [replace, suggestion, easyedit] (suggestionsPopup first hides the others)
			// Absolute position of the TextView with respect to its parent window
			public virtual void addSubscriber(android.widget.TextView.TextViewPositionListener
				 positionListener, bool canMove)
			{
				if (this.mNumberOfListeners == 0)
				{
					this.updatePosition();
					android.view.ViewTreeObserver vto = this._enclosing.getViewTreeObserver();
					vto.addOnPreDrawListener(this);
				}
				int emptySlotIndex = -1;
				{
					for (int i = 0; i < this.MAXIMUM_NUMBER_OF_LISTENERS; i++)
					{
						android.widget.TextView.TextViewPositionListener listener = this.mPositionListeners
							[i];
						if (listener == positionListener)
						{
							return;
						}
						else
						{
							if (emptySlotIndex < 0 && listener == null)
							{
								emptySlotIndex = i;
							}
						}
					}
				}
				this.mPositionListeners[emptySlotIndex] = positionListener;
				this.mCanMove[emptySlotIndex] = canMove;
				this.mNumberOfListeners++;
			}

			public virtual void removeSubscriber(android.widget.TextView.TextViewPositionListener
				 positionListener)
			{
				{
					for (int i = 0; i < this.MAXIMUM_NUMBER_OF_LISTENERS; i++)
					{
						if (this.mPositionListeners[i] == positionListener)
						{
							this.mPositionListeners[i] = null;
							this.mNumberOfListeners--;
							break;
						}
					}
				}
				if (this.mNumberOfListeners == 0)
				{
					android.view.ViewTreeObserver vto = this._enclosing.getViewTreeObserver();
					vto.removeOnPreDrawListener(this);
				}
			}

			public virtual int getPositionX()
			{
				return this.mPositionX;
			}

			public virtual int getPositionY()
			{
				return this.mPositionY;
			}

			[Sharpen.ImplementsInterface(@"android.view.ViewTreeObserver.OnPreDrawListener")]
			public virtual bool onPreDraw()
			{
				this.updatePosition();
				{
					for (int i = 0; i < this.MAXIMUM_NUMBER_OF_LISTENERS; i++)
					{
						if (this.mPositionHasChanged || this.mScrollHasChanged || this.mCanMove[i])
						{
							android.widget.TextView.TextViewPositionListener positionListener = this.mPositionListeners
								[i];
							if (positionListener != null)
							{
								positionListener.updatePosition(this.mPositionX, this.mPositionY, this.mPositionHasChanged
									, this.mScrollHasChanged);
							}
						}
					}
				}
				this.mScrollHasChanged = false;
				return true;
			}

			internal void updatePosition()
			{
				this._enclosing.getLocationInWindow(this._enclosing.mTempCoords);
				this.mPositionHasChanged = this._enclosing.mTempCoords[0] != this.mPositionX || this
					._enclosing.mTempCoords[1] != this.mPositionY;
				this.mPositionX = this._enclosing.mTempCoords[0];
				this.mPositionY = this._enclosing.mTempCoords[1];
			}

			public virtual bool isVisible(int positionX, int positionY)
			{
				android.widget.TextView textView = this._enclosing;
				if (this._enclosing.mTempRect == null)
				{
					this._enclosing.mTempRect = new android.graphics.Rect();
				}
				android.graphics.Rect clip = this._enclosing.mTempRect;
				clip.left = this._enclosing.getCompoundPaddingLeft();
				clip.top = this._enclosing.getExtendedPaddingTop();
				clip.right = textView.getWidth() - this._enclosing.getCompoundPaddingRight();
				clip.bottom = textView.getHeight() - this._enclosing.getExtendedPaddingBottom();
				android.view.ViewParent parent = textView.getParent();
				if (parent == null || !parent.getChildVisibleRect(textView, clip, null))
				{
					return false;
				}
				int posX = this.mPositionX + positionX;
				int posY = this.mPositionY + positionY;
				// Offset by 1 to take into account 0.5 and int rounding around getPrimaryHorizontal.
				return posX >= clip.left - 1 && posX <= clip.right + 1 && posY >= clip.top && posY
					 <= clip.bottom;
			}

			public virtual bool isOffsetVisible(int offset)
			{
				int line = this._enclosing.mLayout.getLineForOffset(offset);
				int lineBottom = this._enclosing.mLayout.getLineBottom(line);
				int primaryHorizontal = (int)this._enclosing.mLayout.getPrimaryHorizontal(offset);
				return this.isVisible(primaryHorizontal + this._enclosing.viewportToContentHorizontalOffset
					(), lineBottom + this._enclosing.viewportToContentVerticalOffset());
			}

			public virtual void onScrollChanged()
			{
				this.mScrollHasChanged = true;
			}

			public PositionListener(TextView _enclosing)
			{
				this._enclosing = _enclosing;
				MAXIMUM_NUMBER_OF_LISTENERS = 6;
				mPositionListeners = new android.widget.TextView.TextViewPositionListener[this.MAXIMUM_NUMBER_OF_LISTENERS
					];
				mCanMove = new bool[this.MAXIMUM_NUMBER_OF_LISTENERS];
				mPositionHasChanged = true;
			}

			private readonly TextView _enclosing;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onScrollChanged(int horiz, int vert, int oldHoriz
			, int oldVert)
		{
			base.onScrollChanged(horiz, vert, oldHoriz, oldVert);
			if (mPositionListener != null)
			{
				mPositionListener.onScrollChanged();
			}
		}

		private abstract class PinnedPopupWindow : android.widget.TextView.TextViewPositionListener
		{
			protected internal android.widget.PopupWindow mPopupWindow;

			protected internal android.view.ViewGroup mContentView;

			internal int mPositionX;

			internal int mPositionY;

			protected internal abstract void createPopupWindow();

			protected internal abstract void initContentView();

			protected internal abstract int getTextOffset();

			protected internal abstract int getVerticalLocalPosition(int line);

			protected internal abstract int clipVertically(int positionY);

			public PinnedPopupWindow(TextView _enclosing)
			{
				this._enclosing = _enclosing;
				this.createPopupWindow();
				this.mPopupWindow.setWindowLayoutType(android.view.WindowManagerClass.LayoutParams
					.TYPE_APPLICATION_SUB_PANEL);
				this.mPopupWindow.setWidth(android.view.ViewGroup.LayoutParams.WRAP_CONTENT);
				this.mPopupWindow.setHeight(android.view.ViewGroup.LayoutParams.WRAP_CONTENT);
				this.initContentView();
				android.view.ViewGroup.LayoutParams wrapContent = new android.view.ViewGroup.LayoutParams
					(android.view.ViewGroup.LayoutParams.WRAP_CONTENT, android.view.ViewGroup.LayoutParams
					.WRAP_CONTENT);
				this.mContentView.setLayoutParams(wrapContent);
				this.mPopupWindow.setContentView(this.mContentView);
			}

			public virtual void show()
			{
				this._enclosing.getPositionListener().addSubscriber(this, false);
				this.computeLocalPosition();
				android.widget.TextView.PositionListener positionListener = this._enclosing.getPositionListener
					();
				this.updatePosition(positionListener.getPositionX(), positionListener.getPositionY
					());
			}

			protected internal virtual void measureContent()
			{
				android.util.DisplayMetrics displayMetrics = this._enclosing.mContext.getResources
					().getDisplayMetrics();
				this.mContentView.measure(android.view.View.MeasureSpec.makeMeasureSpec(displayMetrics
					.widthPixels, android.view.View.MeasureSpec.AT_MOST), android.view.View.MeasureSpec
					.makeMeasureSpec(displayMetrics.heightPixels, android.view.View.MeasureSpec.AT_MOST
					));
			}

			internal void computeLocalPosition()
			{
				this.measureContent();
				int width = this.mContentView.getMeasuredWidth();
				int offset = this.getTextOffset();
				this.mPositionX = (int)(this._enclosing.mLayout.getPrimaryHorizontal(offset) - width
					 / 2.0f);
				this.mPositionX += this._enclosing.viewportToContentHorizontalOffset();
				int line = this._enclosing.mLayout.getLineForOffset(offset);
				this.mPositionY = this.getVerticalLocalPosition(line);
				this.mPositionY += this._enclosing.viewportToContentVerticalOffset();
			}

			internal void updatePosition(int parentPositionX, int parentPositionY)
			{
				int positionX = parentPositionX + this.mPositionX;
				int positionY = parentPositionY + this.mPositionY;
				positionY = this.clipVertically(positionY);
				// Horizontal clipping
				android.util.DisplayMetrics displayMetrics = this._enclosing.mContext.getResources
					().getDisplayMetrics();
				int width = this.mContentView.getMeasuredWidth();
				positionX = System.Math.Min(displayMetrics.widthPixels - width, positionX);
				positionX = System.Math.Max(0, positionX);
				if (this.isShowing())
				{
					this.mPopupWindow.update(positionX, positionY, -1, -1);
				}
				else
				{
					this.mPopupWindow.showAtLocation(this._enclosing, android.view.Gravity.NO_GRAVITY
						, positionX, positionY);
				}
			}

			public virtual void hide()
			{
				this.mPopupWindow.dismiss();
				this._enclosing.getPositionListener().removeSubscriber(this);
			}

			[Sharpen.ImplementsInterface(@"android.widget.TextView.TextViewPositionListener")]
			public virtual void updatePosition(int parentPositionX, int parentPositionY, bool
				 parentPositionChanged, bool parentScrolled)
			{
				// Either parentPositionChanged or parentScrolled is true, check if still visible
				if (this.isShowing() && this._enclosing.getPositionListener().isOffsetVisible(this
					.getTextOffset()))
				{
					if (parentScrolled)
					{
						this.computeLocalPosition();
					}
					this.updatePosition(parentPositionX, parentPositionY);
				}
				else
				{
					this.hide();
				}
			}

			public virtual bool isShowing()
			{
				return this.mPopupWindow.isShowing();
			}

			private readonly TextView _enclosing;
		}

		private class SuggestionsPopupWindow : android.widget.TextView.PinnedPopupWindow, 
			android.widget.AdapterView.OnItemClickListener
		{
			internal const int MAX_NUMBER_SUGGESTIONS = android.text.style.SuggestionSpan.SUGGESTIONS_MAX_SIZE;

			internal const int ADD_TO_DICTIONARY = -1;

			internal const int DELETE_TEXT = -2;

			internal android.widget.TextView.SuggestionsPopupWindow.SuggestionInfo[] mSuggestionInfos;

			internal int mNumberOfSuggestions;

			internal bool mCursorWasVisibleBeforeSuggestions;

			internal android.widget.TextView.SuggestionsPopupWindow.SuggestionAdapter mSuggestionsAdapter;

			internal readonly java.util.Comparator<android.text.style.SuggestionSpan> mSuggestionSpanComparator;

			internal readonly java.util.HashMap<android.text.style.SuggestionSpan, int> mSpansLengths;

			internal class CustomPopupWindow : android.widget.PopupWindow
			{
				public CustomPopupWindow(SuggestionsPopupWindow _enclosing, android.content.Context
					 context, int defStyle) : base(context, null, defStyle)
				{
					this._enclosing = _enclosing;
				}

				[Sharpen.OverridesMethod(@"android.widget.PopupWindow")]
				public override void dismiss()
				{
					base.dismiss();
					this._enclosing._enclosing.getPositionListener().removeSubscriber(this._enclosing
						);
					// Safe cast since show() checks that mText is an Editable
					((android.text.Spannable)this._enclosing._enclosing.mText).removeSpan(this._enclosing
						._enclosing.mSuggestionRangeSpan);
					this._enclosing._enclosing.setCursorVisible(this._enclosing.mCursorWasVisibleBeforeSuggestions
						);
					if (this._enclosing._enclosing.hasInsertionController())
					{
						this._enclosing._enclosing.getInsertionController().show();
					}
				}

				private readonly SuggestionsPopupWindow _enclosing;
			}

			public SuggestionsPopupWindow(TextView _enclosing) : base(_enclosing)
			{
				this._enclosing = _enclosing;
				this.mCursorWasVisibleBeforeSuggestions = this._enclosing.mCursorVisible;
				this.mSuggestionSpanComparator = new android.widget.TextView.SuggestionsPopupWindow
					.SuggestionSpanComparator(this);
				this.mSpansLengths = new java.util.HashMap<android.text.style.SuggestionSpan, int
					>();
			}

			[Sharpen.OverridesMethod(@"android.widget.TextView.PinnedPopupWindow")]
			protected internal override void createPopupWindow()
			{
				this.mPopupWindow = new android.widget.TextView.SuggestionsPopupWindow.CustomPopupWindow
					(this, this._enclosing.mContext, android.@internal.R.attr.textSuggestionsWindowStyle
					);
				this.mPopupWindow.setInputMethodMode(android.widget.PopupWindow.INPUT_METHOD_NOT_NEEDED
					);
				this.mPopupWindow.setFocusable(true);
				this.mPopupWindow.setClippingEnabled(false);
			}

			[Sharpen.OverridesMethod(@"android.widget.TextView.PinnedPopupWindow")]
			protected internal override void initContentView()
			{
				android.widget.ListView listView = new android.widget.ListView(this._enclosing.getContext
					());
				this.mSuggestionsAdapter = new android.widget.TextView.SuggestionsPopupWindow.SuggestionAdapter
					(this);
				listView.setAdapter(this.mSuggestionsAdapter);
				listView.setOnItemClickListener(this);
				this.mContentView = listView;
				// Inflate the suggestion items once and for all. + 2 for add to dictionary and delete
				this.mSuggestionInfos = new android.widget.TextView.SuggestionsPopupWindow.SuggestionInfo
					[MAX_NUMBER_SUGGESTIONS + 2];
				{
					for (int i = 0; i < this.mSuggestionInfos.Length; i++)
					{
						this.mSuggestionInfos[i] = new android.widget.TextView.SuggestionsPopupWindow.SuggestionInfo
							(this);
					}
				}
			}

			internal class SuggestionInfo
			{
				internal int suggestionStart;

				internal int suggestionEnd;

				internal android.text.style.SuggestionSpan suggestionSpan;

				internal int suggestionIndex;

				internal android.text.SpannableStringBuilder text;

				internal android.text.style.TextAppearanceSpan highlightSpan;

				// range of actual suggestion within text
				// the SuggestionSpan that this TextView represents
				// the index of this suggestion inside suggestionSpan
				internal virtual void removeMisspelledFlag()
				{
					int suggestionSpanFlags = this.suggestionSpan.getFlags();
					if ((suggestionSpanFlags & android.text.style.SuggestionSpan.FLAG_MISSPELLED) > 0)
					{
						suggestionSpanFlags &= ~android.text.style.SuggestionSpan.FLAG_MISSPELLED;
						suggestionSpanFlags &= ~android.text.style.SuggestionSpan.FLAG_EASY_CORRECT;
						this.suggestionSpan.setFlags(suggestionSpanFlags);
					}
				}

				public SuggestionInfo(SuggestionsPopupWindow _enclosing)
				{
					this._enclosing = _enclosing;
					text = new android.text.SpannableStringBuilder();
					highlightSpan = new android.text.style.TextAppearanceSpan(this._enclosing._enclosing
						.mContext, android.R.style.TextAppearance_SuggestionHighlight);
				}

				private readonly SuggestionsPopupWindow _enclosing;
			}

			internal class SuggestionAdapter : android.widget.BaseAdapter
			{
				internal android.view.LayoutInflater mInflater;

				[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
				public override int getCount()
				{
					return this._enclosing.mNumberOfSuggestions;
				}

				[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
				public override object getItem(int position)
				{
					return this._enclosing.mSuggestionInfos[position];
				}

				[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
				public override long getItemId(int position)
				{
					return position;
				}

				[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
				public override android.view.View getView(int position, android.view.View convertView
					, android.view.ViewGroup parent)
				{
					android.widget.TextView textView = (android.widget.TextView)convertView;
					if (textView == null)
					{
						textView = (android.widget.TextView)this.mInflater.inflate(this._enclosing._enclosing
							.mTextEditSuggestionItemLayout, parent, false);
					}
					android.widget.TextView.SuggestionsPopupWindow.SuggestionInfo suggestionInfo = this
						._enclosing.mSuggestionInfos[position];
					textView.setText(suggestionInfo.text);
					if (suggestionInfo.suggestionIndex == android.widget.TextView.SuggestionsPopupWindow
						.ADD_TO_DICTIONARY)
					{
						textView.setCompoundDrawablesWithIntrinsicBounds(android.@internal.R.drawable.ic_suggestions_add
							, 0, 0, 0);
					}
					else
					{
						if (suggestionInfo.suggestionIndex == android.widget.TextView.SuggestionsPopupWindow
							.DELETE_TEXT)
						{
							textView.setCompoundDrawablesWithIntrinsicBounds(android.@internal.R.drawable.ic_suggestions_delete
								, 0, 0, 0);
						}
						else
						{
							textView.setCompoundDrawables(null, null, null, null);
						}
					}
					return textView;
				}

				public SuggestionAdapter(SuggestionsPopupWindow _enclosing)
				{
					this._enclosing = _enclosing;
					mInflater = (android.view.LayoutInflater)this._enclosing._enclosing.mContext.getSystemService
						(android.content.Context.LAYOUT_INFLATER_SERVICE);
				}

				private readonly SuggestionsPopupWindow _enclosing;
			}

			internal class SuggestionSpanComparator : java.util.Comparator<android.text.style.SuggestionSpan
				>
			{
				[Sharpen.ImplementsInterface(@"java.util.Comparator")]
				public virtual int compare(android.text.style.SuggestionSpan span1, android.text.style.SuggestionSpan
					 span2)
				{
					int flag1 = span1.getFlags();
					int flag2 = span2.getFlags();
					if (flag1 != flag2)
					{
						// The order here should match what is used in updateDrawState
						bool easy1 = (flag1 & android.text.style.SuggestionSpan.FLAG_EASY_CORRECT) != 0;
						bool easy2 = (flag2 & android.text.style.SuggestionSpan.FLAG_EASY_CORRECT) != 0;
						bool misspelled1 = (flag1 & android.text.style.SuggestionSpan.FLAG_MISSPELLED) !=
							 0;
						bool misspelled2 = (flag2 & android.text.style.SuggestionSpan.FLAG_MISSPELLED) !=
							 0;
						if (easy1 && !misspelled1)
						{
							return -1;
						}
						if (easy2 && !misspelled2)
						{
							return 1;
						}
						if (misspelled1)
						{
							return -1;
						}
						if (misspelled2)
						{
							return 1;
						}
					}
					return this._enclosing.mSpansLengths.get(span1) - this._enclosing.mSpansLengths.get
						(span2);
				}

				internal SuggestionSpanComparator(SuggestionsPopupWindow _enclosing)
				{
					this._enclosing = _enclosing;
				}

				private readonly SuggestionsPopupWindow _enclosing;
			}

			/// <summary>Returns the suggestion spans that cover the current cursor position.</summary>
			/// <remarks>
			/// Returns the suggestion spans that cover the current cursor position. The suggestion
			/// spans are sorted according to the length of text that they are attached to.
			/// </remarks>
			internal android.text.style.SuggestionSpan[] getSuggestionSpans()
			{
				int pos = this._enclosing.getSelectionStart();
				android.text.Spannable spannable = (android.text.Spannable)this._enclosing.mText;
				android.text.style.SuggestionSpan[] suggestionSpans = spannable.getSpans<android.text.style.SuggestionSpan
					>(pos, pos);
				this.mSpansLengths.clear();
				foreach (android.text.style.SuggestionSpan suggestionSpan in suggestionSpans)
				{
					int start = spannable.getSpanStart(suggestionSpan);
					int end = spannable.getSpanEnd(suggestionSpan);
					this.mSpansLengths.put(suggestionSpan, Sharpen.Util.IntValueOf(end - start));
				}
				// The suggestions are sorted according to their types (easy correction first, then
				// misspelled) and to the length of the text that they cover (shorter first).
				java.util.Arrays.sort(suggestionSpans, this.mSuggestionSpanComparator);
				return suggestionSpans;
			}

			[Sharpen.OverridesMethod(@"android.widget.TextView.PinnedPopupWindow")]
			public override void show()
			{
				if (!(this._enclosing.mText is android.text.Editable))
				{
					return;
				}
				this.updateSuggestions();
				this.mCursorWasVisibleBeforeSuggestions = this._enclosing.mCursorVisible;
				this._enclosing.setCursorVisible(false);
				base.show();
			}

			[Sharpen.OverridesMethod(@"android.widget.TextView.PinnedPopupWindow")]
			protected internal override void measureContent()
			{
				android.util.DisplayMetrics displayMetrics = this._enclosing.mContext.getResources
					().getDisplayMetrics();
				int horizontalMeasure = android.view.View.MeasureSpec.makeMeasureSpec(displayMetrics
					.widthPixels, android.view.View.MeasureSpec.AT_MOST);
				int verticalMeasure = android.view.View.MeasureSpec.makeMeasureSpec(displayMetrics
					.heightPixels, android.view.View.MeasureSpec.AT_MOST);
				int width = 0;
				android.view.View view = null;
				{
					for (int i = 0; i < this.mNumberOfSuggestions; i++)
					{
						view = this.mSuggestionsAdapter.getView(i, view, this.mContentView);
						view.getLayoutParams().width = android.view.ViewGroup.LayoutParams.WRAP_CONTENT;
						view.measure(horizontalMeasure, verticalMeasure);
						width = System.Math.Max(width, view.getMeasuredWidth());
					}
				}
				// Enforce the width based on actual text widths
				this.mContentView.measure(android.view.View.MeasureSpec.makeMeasureSpec(width, android.view.View
					.MeasureSpec.EXACTLY), verticalMeasure);
				android.graphics.drawable.Drawable popupBackground = this.mPopupWindow.getBackground
					();
				if (popupBackground != null)
				{
					if (this._enclosing.mTempRect == null)
					{
						this._enclosing.mTempRect = new android.graphics.Rect();
					}
					popupBackground.getPadding(this._enclosing.mTempRect);
					width += this._enclosing.mTempRect.left + this._enclosing.mTempRect.right;
				}
				this.mPopupWindow.setWidth(width);
			}

			[Sharpen.OverridesMethod(@"android.widget.TextView.PinnedPopupWindow")]
			protected internal override int getTextOffset()
			{
				return this._enclosing.getSelectionStart();
			}

			[Sharpen.OverridesMethod(@"android.widget.TextView.PinnedPopupWindow")]
			protected internal override int getVerticalLocalPosition(int line)
			{
				return this._enclosing.mLayout.getLineBottom(line);
			}

			[Sharpen.OverridesMethod(@"android.widget.TextView.PinnedPopupWindow")]
			protected internal override int clipVertically(int positionY)
			{
				int height = this.mContentView.getMeasuredHeight();
				android.util.DisplayMetrics displayMetrics = this._enclosing.mContext.getResources
					().getDisplayMetrics();
				return System.Math.Min(positionY, displayMetrics.heightPixels - height);
			}

			[Sharpen.OverridesMethod(@"android.widget.TextView.PinnedPopupWindow")]
			public override void hide()
			{
				base.hide();
			}

			internal void updateSuggestions()
			{
				android.text.Spannable spannable = (android.text.Spannable)this._enclosing.mText;
				android.text.style.SuggestionSpan[] suggestionSpans = this.getSuggestionSpans();
				int nbSpans = suggestionSpans.Length;
				this.mNumberOfSuggestions = 0;
				int spanUnionStart = this._enclosing.mText.Length;
				int spanUnionEnd = 0;
				android.text.style.SuggestionSpan misspelledSpan = null;
				int underlineColor = 0;
				{
					for (int spanIndex = 0; spanIndex < nbSpans; spanIndex++)
					{
						android.text.style.SuggestionSpan suggestionSpan = suggestionSpans[spanIndex];
						int spanStart = spannable.getSpanStart(suggestionSpan);
						int spanEnd = spannable.getSpanEnd(suggestionSpan);
						spanUnionStart = System.Math.Min(spanStart, spanUnionStart);
						spanUnionEnd = System.Math.Max(spanEnd, spanUnionEnd);
						if ((suggestionSpan.getFlags() & android.text.style.SuggestionSpan.FLAG_MISSPELLED
							) != 0)
						{
							misspelledSpan = suggestionSpan;
						}
						// The first span dictates the background color of the highlighted text
						if (spanIndex == 0)
						{
							underlineColor = suggestionSpan.getUnderlineColor();
						}
						string[] suggestions = suggestionSpan.getSuggestions();
						int nbSuggestions = suggestions.Length;
						{
							for (int suggestionIndex = 0; suggestionIndex < nbSuggestions; suggestionIndex++)
							{
								android.widget.TextView.SuggestionsPopupWindow.SuggestionInfo suggestionInfo = this
									.mSuggestionInfos[this.mNumberOfSuggestions];
								suggestionInfo.suggestionSpan = suggestionSpan;
								suggestionInfo.suggestionIndex = suggestionIndex;
								suggestionInfo.text.replace(0, suggestionInfo.text.Length, java.lang.CharSequenceProxy.Wrap
									(suggestions[suggestionIndex]));
								this.mNumberOfSuggestions++;
								if (this.mNumberOfSuggestions == MAX_NUMBER_SUGGESTIONS)
								{
									// Also end outer for loop
									spanIndex = nbSpans;
									break;
								}
							}
						}
					}
				}
				{
					for (int i = 0; i < this.mNumberOfSuggestions; i++)
					{
						this.highlightTextDifferences(this.mSuggestionInfos[i], spanUnionStart, spanUnionEnd
							);
					}
				}
				// Add to dictionary item is there a span with the misspelled flag
				if (misspelledSpan != null)
				{
					int misspelledStart = spannable.getSpanStart(misspelledSpan);
					int misspelledEnd = spannable.getSpanEnd(misspelledSpan);
					if (misspelledStart >= 0 && misspelledEnd > misspelledStart)
					{
						android.widget.TextView.SuggestionsPopupWindow.SuggestionInfo suggestionInfo = this
							.mSuggestionInfos[this.mNumberOfSuggestions];
						suggestionInfo.suggestionSpan = misspelledSpan;
						suggestionInfo.suggestionIndex = ADD_TO_DICTIONARY;
						suggestionInfo.text.replace(0, suggestionInfo.text.Length, java.lang.CharSequenceProxy.Wrap
							(this._enclosing.getContext().getString(android.@internal.R.@string.addToDictionary
							)));
						suggestionInfo.text.setSpan(suggestionInfo.highlightSpan, 0, 0, android.text.SpannedClass.SPAN_EXCLUSIVE_EXCLUSIVE
							);
						this.mNumberOfSuggestions++;
					}
				}
				// Delete item
				android.widget.TextView.SuggestionsPopupWindow.SuggestionInfo suggestionInfo_1 = 
					this.mSuggestionInfos[this.mNumberOfSuggestions];
				suggestionInfo_1.suggestionSpan = null;
				suggestionInfo_1.suggestionIndex = DELETE_TEXT;
				suggestionInfo_1.text.replace(0, suggestionInfo_1.text.Length, java.lang.CharSequenceProxy.Wrap
					(this._enclosing.getContext().getString(android.@internal.R.@string.deleteText))
					);
				suggestionInfo_1.text.setSpan(suggestionInfo_1.highlightSpan, 0, 0, android.text.SpannedClass.SPAN_EXCLUSIVE_EXCLUSIVE
					);
				this.mNumberOfSuggestions++;
				if (this._enclosing.mSuggestionRangeSpan == null)
				{
					this._enclosing.mSuggestionRangeSpan = new android.text.style.SuggestionRangeSpan
						();
				}
				if (underlineColor == 0)
				{
					// Fallback on the default highlight color when the first span does not provide one
					this._enclosing.mSuggestionRangeSpan.setBackgroundColor(this._enclosing.mHighlightColor
						);
				}
				else
				{
					float BACKGROUND_TRANSPARENCY = 0.4f;
					int newAlpha = (int)(android.graphics.Color.alpha(underlineColor) * BACKGROUND_TRANSPARENCY
						);
					this._enclosing.mSuggestionRangeSpan.setBackgroundColor((underlineColor & unchecked(
						(int)(0x00FFFFFF))) + (newAlpha << 24));
				}
				spannable.setSpan(this._enclosing.mSuggestionRangeSpan, spanUnionStart, spanUnionEnd
					, android.text.SpannedClass.SPAN_EXCLUSIVE_EXCLUSIVE);
				this.mSuggestionsAdapter.notifyDataSetChanged();
			}

			internal void highlightTextDifferences(android.widget.TextView.SuggestionsPopupWindow
				.SuggestionInfo suggestionInfo, int unionStart, int unionEnd)
			{
				android.text.Spannable text = (android.text.Spannable)this._enclosing.mText;
				int spanStart = text.getSpanStart(suggestionInfo.suggestionSpan);
				int spanEnd = text.getSpanEnd(suggestionInfo.suggestionSpan);
				// Adjust the start/end of the suggestion span
				suggestionInfo.suggestionStart = spanStart - unionStart;
				suggestionInfo.suggestionEnd = suggestionInfo.suggestionStart + suggestionInfo.text
					.Length;
				suggestionInfo.text.setSpan(suggestionInfo.highlightSpan, 0, suggestionInfo.text.
					Length, android.text.SpannedClass.SPAN_EXCLUSIVE_EXCLUSIVE);
				// Add the text before and after the span.
				suggestionInfo.text.insert(0, java.lang.CharSequenceProxy.Wrap(Sharpen.StringHelper.Substring
					(this._enclosing.mText.ToString(), unionStart, spanStart)));
				suggestionInfo.text.append(java.lang.CharSequenceProxy.Wrap(Sharpen.StringHelper.Substring
					(this._enclosing.mText.ToString(), spanEnd, unionEnd)));
			}

			[Sharpen.ImplementsInterface(@"android.widget.AdapterView.OnItemClickListener")]
			public virtual void onItemClick(object parent, android.view.View view, int position
				, long id)
			{
				android.widget.TextView textView = (android.widget.TextView)view;
				android.text.Editable editable = (android.text.Editable)this._enclosing.mText;
				android.widget.TextView.SuggestionsPopupWindow.SuggestionInfo suggestionInfo = this
					.mSuggestionInfos[position];
				if (suggestionInfo.suggestionIndex == DELETE_TEXT)
				{
					int spanUnionStart = editable.getSpanStart(this._enclosing.mSuggestionRangeSpan);
					int spanUnionEnd = editable.getSpanEnd(this._enclosing.mSuggestionRangeSpan);
					if (spanUnionStart >= 0 && spanUnionEnd > spanUnionStart)
					{
						// Do not leave two adjacent spaces after deletion, or one at beginning of text
						if (spanUnionEnd < editable.Length && System.Char.IsWhiteSpace(editable[spanUnionEnd
							]) && (spanUnionStart == 0 || System.Char.IsWhiteSpace(editable[spanUnionStart -
							 1])))
						{
							spanUnionEnd = spanUnionEnd + 1;
						}
						editable.replace(spanUnionStart, spanUnionEnd, java.lang.CharSequenceProxy.Wrap(string.Empty
							));
					}
					this.hide();
					return;
				}
				int spanStart = editable.getSpanStart(suggestionInfo.suggestionSpan);
				int spanEnd = editable.getSpanEnd(suggestionInfo.suggestionSpan);
				if (spanStart < 0 || spanEnd < 0)
				{
					// Span has been removed
					this.hide();
					return;
				}
				string originalText = Sharpen.StringHelper.Substring(this._enclosing.mText.ToString
					(), spanStart, spanEnd);
				if (suggestionInfo.suggestionIndex == ADD_TO_DICTIONARY)
				{
					android.content.Intent intent = new android.content.Intent(android.provider.Settings
						.ACTION_USER_DICTIONARY_INSERT);
					intent.putExtra("word", originalText);
					intent.setFlags(intent.getFlags() | android.content.Intent.FLAG_ACTIVITY_NEW_TASK
						);
					this._enclosing.getContext().startActivity(intent);
					// There is no way to know if the word was indeed added. Re-check.
					editable.removeSpan(suggestionInfo.suggestionSpan);
					this._enclosing.updateSpellCheckSpans(spanStart, spanEnd);
				}
				else
				{
					// SuggestionSpans are removed by replace: save them before
					android.text.style.SuggestionSpan[] suggestionSpans = editable.getSpans<android.text.style.SuggestionSpan
						>(spanStart, spanEnd);
					int length = suggestionSpans.Length;
					int[] suggestionSpansStarts = new int[length];
					int[] suggestionSpansEnds = new int[length];
					int[] suggestionSpansFlags = new int[length];
					{
						for (int i = 0; i < length; i++)
						{
							android.text.style.SuggestionSpan suggestionSpan = suggestionSpans[i];
							suggestionSpansStarts[i] = editable.getSpanStart(suggestionSpan);
							suggestionSpansEnds[i] = editable.getSpanEnd(suggestionSpan);
							suggestionSpansFlags[i] = editable.getSpanFlags(suggestionSpan);
						}
					}
					int suggestionStart = suggestionInfo.suggestionStart;
					int suggestionEnd = suggestionInfo.suggestionEnd;
					string suggestion = textView.getText().SubSequence(suggestionStart, suggestionEnd
						).ToString();
					editable.replace(spanStart, spanEnd, java.lang.CharSequenceProxy.Wrap(suggestion)
						);
					suggestionInfo.removeMisspelledFlag();
					// Notify source IME of the suggestion pick. Do this before swaping texts.
					if (!android.text.TextUtils.isEmpty(java.lang.CharSequenceProxy.Wrap(suggestionInfo
						.suggestionSpan.getNotificationTargetClassName())))
					{
						android.view.inputmethod.InputMethodManager imm = android.view.inputmethod.InputMethodManager
							.peekInstance();
						if (imm != null)
						{
							imm.notifySuggestionPicked(suggestionInfo.suggestionSpan, originalText, suggestionInfo
								.suggestionIndex);
						}
					}
					// Swap text content between actual text and Suggestion span
					string[] suggestions = suggestionInfo.suggestionSpan.getSuggestions();
					suggestions[suggestionInfo.suggestionIndex] = originalText;
					// Restore previous SuggestionSpans
					int lengthDifference = suggestion.Length - (spanEnd - spanStart);
					{
						for (int i_1 = 0; i_1 < length; i_1++)
						{
							// Only spans that include the modified region make sense after replacement
							// Spans partially included in the replaced region are removed, there is no
							// way to assign them a valid range after replacement
							if (suggestionSpansStarts[i_1] <= spanStart && suggestionSpansEnds[i_1] >= spanEnd)
							{
								editable.setSpan(suggestionSpans[i_1], suggestionSpansStarts[i_1], suggestionSpansEnds
									[i_1] + lengthDifference, suggestionSpansFlags[i_1]);
							}
						}
					}
					// Move cursor at the end of the replaced word
					android.text.Selection.setSelection(editable, spanEnd + lengthDifference);
				}
				this.hide();
			}

			private readonly TextView _enclosing;
		}

		/// <summary>Removes the suggestion spans.</summary>
		/// <remarks>Removes the suggestion spans.</remarks>
		internal virtual java.lang.CharSequence removeSuggestionSpans(java.lang.CharSequence
			 text)
		{
			if (text is android.text.Spanned)
			{
				android.text.Spannable spannable;
				if (text is android.text.Spannable)
				{
					spannable = (android.text.Spannable)text;
				}
				else
				{
					spannable = new android.text.SpannableString(text);
					text = spannable;
				}
				android.text.style.SuggestionSpan[] spans = spannable.getSpans<android.text.style.SuggestionSpan
					>(0, text.Length);
				{
					for (int i = 0; i < spans.Length; i++)
					{
						spannable.removeSpan(spans[i]);
					}
				}
			}
			return text;
		}

		internal virtual void showSuggestions()
		{
			if (mSuggestionsPopupWindow == null)
			{
				mSuggestionsPopupWindow = new android.widget.TextView.SuggestionsPopupWindow(this
					);
			}
			hideControllers();
			mSuggestionsPopupWindow.show();
		}

		internal virtual bool areSuggestionsShown()
		{
			return mSuggestionsPopupWindow != null && mSuggestionsPopupWindow.isShowing();
		}

		/// <summary>Return whether or not suggestions are enabled on this TextView.</summary>
		/// <remarks>
		/// Return whether or not suggestions are enabled on this TextView. The suggestions are generated
		/// by the IME or by the spell checker as the user types. This is done by adding
		/// <see cref="android.text.style.SuggestionSpan">android.text.style.SuggestionSpan</see>
		/// s to the text.
		/// When suggestions are enabled (default), this list of suggestions will be displayed when the
		/// user asks for them on these parts of the text. This value depends on the inputType of this
		/// TextView.
		/// The class of the input type must be
		/// <see cref="android.text.InputTypeClass.TYPE_CLASS_TEXT">android.text.InputTypeClass.TYPE_CLASS_TEXT
		/// 	</see>
		/// .
		/// In addition, the type variation must be one of
		/// <see cref="android.text.InputTypeClass.TYPE_TEXT_VARIATION_NORMAL">android.text.InputTypeClass.TYPE_TEXT_VARIATION_NORMAL
		/// 	</see>
		/// ,
		/// <see cref="android.text.InputTypeClass.TYPE_TEXT_VARIATION_EMAIL_SUBJECT">android.text.InputTypeClass.TYPE_TEXT_VARIATION_EMAIL_SUBJECT
		/// 	</see>
		/// ,
		/// <see cref="android.text.InputTypeClass.TYPE_TEXT_VARIATION_LONG_MESSAGE">android.text.InputTypeClass.TYPE_TEXT_VARIATION_LONG_MESSAGE
		/// 	</see>
		/// ,
		/// <see cref="android.text.InputTypeClass.TYPE_TEXT_VARIATION_SHORT_MESSAGE">android.text.InputTypeClass.TYPE_TEXT_VARIATION_SHORT_MESSAGE
		/// 	</see>
		/// or
		/// <see cref="android.text.InputTypeClass.TYPE_TEXT_VARIATION_WEB_EDIT_TEXT">android.text.InputTypeClass.TYPE_TEXT_VARIATION_WEB_EDIT_TEXT
		/// 	</see>
		/// .
		/// And finally, the
		/// <see cref="android.text.InputTypeClass.TYPE_TEXT_FLAG_NO_SUGGESTIONS">android.text.InputTypeClass.TYPE_TEXT_FLAG_NO_SUGGESTIONS
		/// 	</see>
		/// flag must <i>not</i> be set.
		/// </remarks>
		/// <returns>true if the suggestions popup window is enabled, based on the inputType.
		/// 	</returns>
		public virtual bool isSuggestionsEnabled()
		{
			if ((mInputType & android.text.InputTypeClass.TYPE_MASK_CLASS) != android.text.InputTypeClass.TYPE_CLASS_TEXT)
			{
				return false;
			}
			if ((mInputType & android.text.InputTypeClass.TYPE_TEXT_FLAG_NO_SUGGESTIONS) > 0)
			{
				return false;
			}
			int variation = mInputType & android.text.InputTypeClass.TYPE_MASK_VARIATION;
			return (variation == android.text.InputTypeClass.TYPE_TEXT_VARIATION_NORMAL || variation
				 == android.text.InputTypeClass.TYPE_TEXT_VARIATION_EMAIL_SUBJECT || variation ==
				 android.text.InputTypeClass.TYPE_TEXT_VARIATION_LONG_MESSAGE || variation == android.text.InputTypeClass.TYPE_TEXT_VARIATION_SHORT_MESSAGE
				 || variation == android.text.InputTypeClass.TYPE_TEXT_VARIATION_WEB_EDIT_TEXT);
		}

		/// <summary>
		/// If provided, this ActionMode.Callback will be used to create the ActionMode when text
		/// selection is initiated in this View.
		/// </summary>
		/// <remarks>
		/// If provided, this ActionMode.Callback will be used to create the ActionMode when text
		/// selection is initiated in this View.
		/// The standard implementation populates the menu with a subset of Select All, Cut, Copy and
		/// Paste actions, depending on what this View supports.
		/// A custom implementation can add new entries in the default menu in its
		/// <see cref="android.view.ActionMode.Callback.onPrepareActionMode(android.view.ActionMode, android.view.Menu)
		/// 	">android.view.ActionMode.Callback.onPrepareActionMode(android.view.ActionMode, android.view.Menu)
		/// 	</see>
		/// method. The
		/// default actions can also be removed from the menu using
		/// <see cref="android.view.Menu.removeItem(int)">android.view.Menu.removeItem(int)</see>
		/// and
		/// passing
		/// <see cref="android.R.id.selectAll">android.R.id.selectAll</see>
		/// ,
		/// <see cref="android.R.id.cut">android.R.id.cut</see>
		/// ,
		/// <see cref="android.R.id.copy">android.R.id.copy</see>
		/// or
		/// <see cref="android.R.id.paste">android.R.id.paste</see>
		/// ids as parameters.
		/// Returning false from
		/// <see cref="android.view.ActionMode.Callback.onCreateActionMode(android.view.ActionMode, android.view.Menu)
		/// 	">android.view.ActionMode.Callback.onCreateActionMode(android.view.ActionMode, android.view.Menu)
		/// 	</see>
		/// will prevent
		/// the action mode from being started.
		/// Action click events should be handled by the custom implementation of
		/// <see cref="android.view.ActionMode.Callback.onActionItemClicked(android.view.ActionMode, android.view.MenuItem)
		/// 	">android.view.ActionMode.Callback.onActionItemClicked(android.view.ActionMode, android.view.MenuItem)
		/// 	</see>
		/// .
		/// Note that text selection mode is not started when a TextView receives focus and the
		/// <see cref="android.R.attr.selectAllOnFocus">android.R.attr.selectAllOnFocus</see>
		/// flag has been set. The content is highlighted in
		/// that case, to allow for quick replacement.
		/// </remarks>
		public virtual void setCustomSelectionActionModeCallback(android.view.ActionMode.
			Callback actionModeCallback)
		{
			mCustomSelectionActionModeCallback = actionModeCallback;
		}

		/// <summary>
		/// Retrieves the value set in
		/// <see cref="setCustomSelectionActionModeCallback(android.view.ActionMode.Callback)
		/// 	">setCustomSelectionActionModeCallback(android.view.ActionMode.Callback)</see>
		/// . Default is null.
		/// </summary>
		/// <returns>The current custom selection callback.</returns>
		public virtual android.view.ActionMode.Callback getCustomSelectionActionModeCallback
			()
		{
			return mCustomSelectionActionModeCallback;
		}

		/// <returns>true if the selection mode was actually started.</returns>
		private bool startSelectionActionMode()
		{
			if (mSelectionActionMode != null)
			{
				// Selection action mode is already started
				return false;
			}
			if (!canSelectText() || !requestFocus())
			{
				android.util.Log.w(LOG_TAG, "TextView does not support text selection. Action mode cancelled."
					);
				return false;
			}
			if (!hasSelection())
			{
				// There may already be a selection on device rotation
				if (!selectCurrentWord())
				{
					// No word found under cursor or text selection not permitted.
					return false;
				}
			}
			android.view.inputmethod.InputMethodManager imm = android.view.inputmethod.InputMethodManager
				.peekInstance();
			bool extractedTextModeWillBeStartedFullScreen = !(this is android.inputmethodservice.ExtractEditText
				) && imm != null && imm.isFullscreenMode();
			// Do not start the action mode when extracted text will show up full screen, thus
			// immediately hiding the newly created action bar, which would be visually distracting.
			if (!extractedTextModeWillBeStartedFullScreen)
			{
				android.view.ActionMode.Callback actionModeCallback = new android.widget.TextView
					.SelectionActionModeCallback(this);
				mSelectionActionMode = startActionMode(actionModeCallback);
			}
			bool selectionStarted = mSelectionActionMode != null || extractedTextModeWillBeStartedFullScreen;
			if (selectionStarted && !mTextIsSelectable && imm != null)
			{
				// Show the IME to be able to replace text, except when selecting non editable text.
				imm.showSoftInput(this, 0, null);
			}
			return selectionStarted;
		}

		private void stopSelectionActionMode()
		{
			if (mSelectionActionMode != null)
			{
				// This will hide the mSelectionModifierCursorController
				mSelectionActionMode.finish();
			}
		}

		/// <summary>Paste clipboard content between min and max positions.</summary>
		/// <remarks>Paste clipboard content between min and max positions.</remarks>
		private void paste(int min, int max)
		{
			android.content.ClipboardManager clipboard = (android.content.ClipboardManager)getContext
				().getSystemService(android.content.Context.CLIPBOARD_SERVICE);
			android.content.ClipData clip = clipboard.getPrimaryClip();
			if (clip != null)
			{
				bool didFirst = false;
				{
					for (int i = 0; i < clip.getItemCount(); i++)
					{
						java.lang.CharSequence paste_1 = clip.getItemAt(i).coerceToText(getContext());
						if (paste_1 != null)
						{
							if (!didFirst)
							{
								long minMax = prepareSpacesAroundPaste(min, max, paste_1);
								min = extractRangeStartFromLong(minMax);
								max = extractRangeEndFromLong(minMax);
								android.text.Selection.setSelection((android.text.Spannable)mText, max);
								((android.text.Editable)mText).replace(min, max, paste_1);
								didFirst = true;
							}
							else
							{
								((android.text.Editable)mText).insert(getSelectionEnd(), java.lang.CharSequenceProxy.Wrap
									("\n"));
								((android.text.Editable)mText).insert(getSelectionEnd(), paste_1);
							}
						}
					}
				}
				stopSelectionActionMode();
				sLastCutOrCopyTime = 0;
			}
		}

		private void setPrimaryClip(android.content.ClipData clip)
		{
			android.content.ClipboardManager clipboard = (android.content.ClipboardManager)getContext
				().getSystemService(android.content.Context.CLIPBOARD_SERVICE);
			clipboard.setPrimaryClip(clip);
			sLastCutOrCopyTime = android.os.SystemClock.uptimeMillis();
		}

		/// <summary>An ActionMode Callback class that is used to provide actions while in text selection mode.
		/// 	</summary>
		/// <remarks>
		/// An ActionMode Callback class that is used to provide actions while in text selection mode.
		/// The default callback provides a subset of Select All, Cut, Copy and Paste actions, depending
		/// on which of these this TextView supports.
		/// </remarks>
		private class SelectionActionModeCallback : android.view.ActionMode.Callback
		{
			[Sharpen.ImplementsInterface(@"android.view.ActionMode.Callback")]
			public virtual bool onCreateActionMode(android.view.ActionMode mode, android.view.Menu
				 menu)
			{
				android.content.res.TypedArray styledAttributes = this._enclosing.mContext.obtainStyledAttributes
					(android.@internal.R.styleable.SelectionModeDrawables);
				bool allowText = this._enclosing.getContext().getResources().getBoolean(android.@internal.R
					.@bool.config_allowActionMenuItemTextWithIcon);
				mode.setTitle(java.lang.CharSequenceProxy.Wrap(allowText ? this._enclosing.mContext
					.getString(android.@internal.R.@string.textSelectionCABTitle) : null));
				mode.setSubtitle(null);
				int selectAllIconId = 0;
				// No icon by default
				if (!allowText)
				{
					// Provide an icon, text will not be displayed on smaller screens.
					selectAllIconId = styledAttributes.getResourceId(android.R.styleable.SelectionModeDrawables_actionModeSelectAllDrawable
						, 0);
				}
				menu.add(0, android.widget.TextView.ID_SELECT_ALL, 0, android.@internal.R.@string
					.selectAll).setIcon(selectAllIconId).setAlphabeticShortcut('a').setShowAsAction(
					android.view.MenuItemClass.SHOW_AS_ACTION_ALWAYS | android.view.MenuItemClass.SHOW_AS_ACTION_WITH_TEXT
					);
				if (this._enclosing.canCut())
				{
					menu.add(0, android.widget.TextView.ID_CUT, 0, android.@internal.R.@string.cut).setIcon
						(styledAttributes.getResourceId(android.R.styleable.SelectionModeDrawables_actionModeCutDrawable
						, 0)).setAlphabeticShortcut('x').setShowAsAction(android.view.MenuItemClass.SHOW_AS_ACTION_ALWAYS
						 | android.view.MenuItemClass.SHOW_AS_ACTION_WITH_TEXT);
				}
				if (this._enclosing.canCopy())
				{
					menu.add(0, android.widget.TextView.ID_COPY, 0, android.@internal.R.@string.copy)
						.setIcon(styledAttributes.getResourceId(android.R.styleable.SelectionModeDrawables_actionModeCopyDrawable
						, 0)).setAlphabeticShortcut('c').setShowAsAction(android.view.MenuItemClass.SHOW_AS_ACTION_ALWAYS
						 | android.view.MenuItemClass.SHOW_AS_ACTION_WITH_TEXT);
				}
				if (this._enclosing.canPaste())
				{
					menu.add(0, android.widget.TextView.ID_PASTE, 0, android.@internal.R.@string.paste
						).setIcon(styledAttributes.getResourceId(android.R.styleable.SelectionModeDrawables_actionModePasteDrawable
						, 0)).setAlphabeticShortcut('v').setShowAsAction(android.view.MenuItemClass.SHOW_AS_ACTION_ALWAYS
						 | android.view.MenuItemClass.SHOW_AS_ACTION_WITH_TEXT);
				}
				styledAttributes.recycle();
				if (this._enclosing.mCustomSelectionActionModeCallback != null)
				{
					if (!this._enclosing.mCustomSelectionActionModeCallback.onCreateActionMode(mode, 
						menu))
					{
						// The custom mode can choose to cancel the action mode
						return false;
					}
				}
				if (menu.hasVisibleItems() || mode.getCustomView() != null)
				{
					this._enclosing.getSelectionController().show();
					return true;
				}
				else
				{
					return false;
				}
			}

			[Sharpen.ImplementsInterface(@"android.view.ActionMode.Callback")]
			public virtual bool onPrepareActionMode(android.view.ActionMode mode, android.view.Menu
				 menu)
			{
				if (this._enclosing.mCustomSelectionActionModeCallback != null)
				{
					return this._enclosing.mCustomSelectionActionModeCallback.onPrepareActionMode(mode
						, menu);
				}
				return true;
			}

			[Sharpen.ImplementsInterface(@"android.view.ActionMode.Callback")]
			public virtual bool onActionItemClicked(android.view.ActionMode mode, android.view.MenuItem
				 item)
			{
				if (this._enclosing.mCustomSelectionActionModeCallback != null && this._enclosing
					.mCustomSelectionActionModeCallback.onActionItemClicked(mode, item))
				{
					return true;
				}
				return this._enclosing.onTextContextMenuItem(item.getItemId());
			}

			[Sharpen.ImplementsInterface(@"android.view.ActionMode.Callback")]
			public virtual void onDestroyActionMode(android.view.ActionMode mode)
			{
				if (this._enclosing.mCustomSelectionActionModeCallback != null)
				{
					this._enclosing.mCustomSelectionActionModeCallback.onDestroyActionMode(mode);
				}
				android.text.Selection.setSelection((android.text.Spannable)this._enclosing.mText
					, this._enclosing.getSelectionEnd());
				if (this._enclosing.mSelectionModifierCursorController != null)
				{
					this._enclosing.mSelectionModifierCursorController.hide();
				}
				this._enclosing.mSelectionActionMode = null;
			}

			internal SelectionActionModeCallback(TextView _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly TextView _enclosing;
		}

		private class ActionPopupWindow : android.widget.TextView.PinnedPopupWindow, android.view.View
			.OnClickListener
		{
			internal const int POPUP_TEXT_LAYOUT = android.@internal.R.layout.text_edit_action_popup_text;

			internal android.widget.TextView mPasteTextView;

			internal android.widget.TextView mReplaceTextView;

			[Sharpen.OverridesMethod(@"android.widget.TextView.PinnedPopupWindow")]
			protected internal override void createPopupWindow()
			{
				this.mPopupWindow = new android.widget.PopupWindow(this._enclosing.mContext, null
					, android.@internal.R.attr.textSelectHandleWindowStyle);
				this.mPopupWindow.setClippingEnabled(true);
			}

			[Sharpen.OverridesMethod(@"android.widget.TextView.PinnedPopupWindow")]
			protected internal override void initContentView()
			{
				android.widget.LinearLayout linearLayout = new android.widget.LinearLayout(this._enclosing
					.getContext());
				linearLayout.setOrientation(android.widget.LinearLayout.HORIZONTAL);
				this.mContentView = linearLayout;
				this.mContentView.setBackgroundResource(android.@internal.R.drawable.text_edit_paste_window
					);
				android.view.LayoutInflater inflater = (android.view.LayoutInflater)this._enclosing
					.mContext.getSystemService(android.content.Context.LAYOUT_INFLATER_SERVICE);
				android.view.ViewGroup.LayoutParams wrapContent = new android.view.ViewGroup.LayoutParams
					(android.view.ViewGroup.LayoutParams.WRAP_CONTENT, android.view.ViewGroup.LayoutParams
					.WRAP_CONTENT);
				this.mPasteTextView = (android.widget.TextView)inflater.inflate(POPUP_TEXT_LAYOUT
					, null);
				this.mPasteTextView.setLayoutParams(wrapContent);
				this.mContentView.addView(this.mPasteTextView);
				this.mPasteTextView.setText(android.@internal.R.@string.paste);
				this.mPasteTextView.setOnClickListener(this);
				this.mReplaceTextView = (android.widget.TextView)inflater.inflate(POPUP_TEXT_LAYOUT
					, null);
				this.mReplaceTextView.setLayoutParams(wrapContent);
				this.mContentView.addView(this.mReplaceTextView);
				this.mReplaceTextView.setText(android.@internal.R.@string.replace);
				this.mReplaceTextView.setOnClickListener(this);
			}

			[Sharpen.OverridesMethod(@"android.widget.TextView.PinnedPopupWindow")]
			public override void show()
			{
				bool canPaste = this._enclosing.canPaste();
				bool canSuggest = this._enclosing.isSuggestionsEnabled() && this._enclosing.isCursorInsideSuggestionSpan
					();
				this.mPasteTextView.setVisibility(canPaste ? android.view.View.VISIBLE : android.view.View
					.GONE);
				this.mReplaceTextView.setVisibility(canSuggest ? android.view.View.VISIBLE : android.view.View
					.GONE);
				if (!canPaste && !canSuggest)
				{
					return;
				}
				base.show();
			}

			[Sharpen.ImplementsInterface(@"android.view.View.OnClickListener")]
			public virtual void onClick(android.view.View view)
			{
				if (view == this.mPasteTextView && this._enclosing.canPaste())
				{
					this._enclosing.onTextContextMenuItem(android.widget.TextView.ID_PASTE);
					this.hide();
				}
				else
				{
					if (view == this.mReplaceTextView)
					{
						int middle = (this._enclosing.getSelectionStart() + this._enclosing.getSelectionEnd
							()) / 2;
						this._enclosing.stopSelectionActionMode();
						android.text.Selection.setSelection((android.text.Spannable)this._enclosing.mText
							, middle);
						this._enclosing.showSuggestions();
					}
				}
			}

			[Sharpen.OverridesMethod(@"android.widget.TextView.PinnedPopupWindow")]
			protected internal override int getTextOffset()
			{
				return (this._enclosing.getSelectionStart() + this._enclosing.getSelectionEnd()) 
					/ 2;
			}

			[Sharpen.OverridesMethod(@"android.widget.TextView.PinnedPopupWindow")]
			protected internal override int getVerticalLocalPosition(int line)
			{
				return this._enclosing.mLayout.getLineTop(line) - this.mContentView.getMeasuredHeight
					();
			}

			[Sharpen.OverridesMethod(@"android.widget.TextView.PinnedPopupWindow")]
			protected internal override int clipVertically(int positionY)
			{
				if (positionY < 0)
				{
					int offset = this.getTextOffset();
					int line = this._enclosing.mLayout.getLineForOffset(offset);
					positionY += this._enclosing.mLayout.getLineBottom(line) - this._enclosing.mLayout
						.getLineTop(line);
					positionY += this.mContentView.getMeasuredHeight();
					// Assumes insertion and selection handles share the same height
					android.graphics.drawable.Drawable handle = this._enclosing.mContext.getResources
						().getDrawable(this._enclosing.mTextSelectHandleRes);
					positionY += handle.getIntrinsicHeight();
				}
				return positionY;
			}

			internal ActionPopupWindow(TextView _enclosing) : base(_enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly TextView _enclosing;
		}

		private abstract class HandleView : android.view.View, android.widget.TextView.TextViewPositionListener
		{
			protected internal android.graphics.drawable.Drawable mDrawable;

			protected internal android.graphics.drawable.Drawable mDrawableLtr;

			protected internal android.graphics.drawable.Drawable mDrawableRtl;

			internal readonly android.widget.PopupWindow mContainer;

			internal int mPositionX;

			internal int mPositionY;

			internal bool mIsDragging;

			internal float mTouchToWindowOffsetX;

			internal float mTouchToWindowOffsetY;

			protected internal int mHotspotX;

			internal float mTouchOffsetY;

			internal float mIdealVerticalOffset;

			internal int mLastParentX;

			internal int mLastParentY;

			internal android.widget.TextView.ActionPopupWindow mActionPopupWindow;

			internal int mPreviousOffset;

			internal bool mPositionHasChanged;

			internal java.lang.Runnable mActionPopupShower;

			public HandleView(TextView _enclosing, android.graphics.drawable.Drawable drawableLtr
				, android.graphics.drawable.Drawable drawableRtl) : base(_enclosing.mContext)
			{
				this._enclosing = _enclosing;
				mPreviousOffset = -1;
				mPositionHasChanged = true;
				mPreviousOffsetsTimes = new long[HISTORY_SIZE];
				mPreviousOffsets = new int[HISTORY_SIZE];
				mPreviousOffsetIndex = 0;
				mNumberPreviousOffsets = 0;
				// Position with respect to the parent TextView
				// Offset from touch position to mPosition
				// Offsets the hotspot point up, so that cursor is not hidden by the finger when moving up
				// Where the touch position should be on the handle to ensure a maximum cursor visibility
				// Parent's (TextView) previous position in window
				// Transient action popup window for Paste and Replace actions
				// Previous text character offset
				// Previous text character offset
				// Used to delay the appearance of the action popup window
				this.mContainer = new android.widget.PopupWindow(this._enclosing.mContext, null, 
					android.@internal.R.attr.textSelectHandleWindowStyle);
				this.mContainer.setSplitTouchEnabled(true);
				this.mContainer.setClippingEnabled(false);
				this.mContainer.setWindowLayoutType(android.view.WindowManagerClass.LayoutParams.
					TYPE_APPLICATION_SUB_PANEL);
				this.mContainer.setContentView(this);
				this.mDrawableLtr = drawableLtr;
				this.mDrawableRtl = drawableRtl;
				this.updateDrawable();
				int handleHeight = this.mDrawable.getIntrinsicHeight();
				this.mTouchOffsetY = -0.3f * handleHeight;
				this.mIdealVerticalOffset = 0.7f * handleHeight;
			}

			protected internal virtual void updateDrawable()
			{
				int offset = this.getCurrentCursorOffset();
				bool isRtlCharAtOffset = this._enclosing.mLayout.isRtlCharAt(offset);
				this.mDrawable = isRtlCharAtOffset ? this.mDrawableRtl : this.mDrawableLtr;
				this.mHotspotX = this.getHotspotX(this.mDrawable, isRtlCharAtOffset);
			}

			protected internal abstract int getHotspotX(android.graphics.drawable.Drawable drawable
				, bool isRtlRun);

			internal const int HISTORY_SIZE = 5;

			internal const int TOUCH_UP_FILTER_DELAY_AFTER = 150;

			internal const int TOUCH_UP_FILTER_DELAY_BEFORE = 350;

			internal readonly long[] mPreviousOffsetsTimes;

			internal readonly int[] mPreviousOffsets;

			internal int mPreviousOffsetIndex;

			internal int mNumberPreviousOffsets;

			// Touch-up filter: number of previous positions remembered
			internal void startTouchUpFilter(int offset)
			{
				this.mNumberPreviousOffsets = 0;
				this.addPositionToTouchUpFilter(offset);
			}

			internal void addPositionToTouchUpFilter(int offset)
			{
				this.mPreviousOffsetIndex = (this.mPreviousOffsetIndex + 1) % HISTORY_SIZE;
				this.mPreviousOffsets[this.mPreviousOffsetIndex] = offset;
				this.mPreviousOffsetsTimes[this.mPreviousOffsetIndex] = android.os.SystemClock.uptimeMillis
					();
				this.mNumberPreviousOffsets++;
			}

			internal void filterOnTouchUp()
			{
				long now = android.os.SystemClock.uptimeMillis();
				int i = 0;
				int index = this.mPreviousOffsetIndex;
				int iMax = System.Math.Min(this.mNumberPreviousOffsets, HISTORY_SIZE);
				while (i < iMax && (now - this.mPreviousOffsetsTimes[index]) < TOUCH_UP_FILTER_DELAY_AFTER
					)
				{
					i++;
					index = (this.mPreviousOffsetIndex - i + HISTORY_SIZE) % HISTORY_SIZE;
				}
				if (i > 0 && i < iMax && (now - this.mPreviousOffsetsTimes[index]) > TOUCH_UP_FILTER_DELAY_BEFORE)
				{
					this.positionAtCursorOffset(this.mPreviousOffsets[index], false);
				}
			}

			public virtual bool offsetHasBeenChanged()
			{
				return this.mNumberPreviousOffsets > 1;
			}

			[Sharpen.OverridesMethod(@"android.view.View")]
			protected internal override void onMeasure(int widthMeasureSpec, int heightMeasureSpec
				)
			{
				this.setMeasuredDimension(this.mDrawable.getIntrinsicWidth(), this.mDrawable.getIntrinsicHeight
					());
			}

			public virtual void show()
			{
				if (this.isShowing())
				{
					return;
				}
				this._enclosing.getPositionListener().addSubscriber(this, true);
				// Make sure the offset is always considered new, even when focusing at same position
				this.mPreviousOffset = -1;
				this.positionAtCursorOffset(this.getCurrentCursorOffset(), false);
				this.hideActionPopupWindow();
			}

			protected internal virtual void dismiss()
			{
				this.mIsDragging = false;
				this.mContainer.dismiss();
				this.onDetached();
			}

			public virtual void hide()
			{
				this.dismiss();
				this._enclosing.getPositionListener().removeSubscriber(this);
			}

			internal sealed class _Runnable_10506 : java.lang.Runnable
			{
				public _Runnable_10506(HandleView _enclosing)
				{
					this._enclosing = _enclosing;
				}

				[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
				public void run()
				{
					this._enclosing.mActionPopupWindow.show();
				}

				private readonly HandleView _enclosing;
			}

			internal virtual void showActionPopupWindow(int delay)
			{
				if (this.mActionPopupWindow == null)
				{
					this.mActionPopupWindow = new android.widget.TextView.ActionPopupWindow(this._enclosing
						);
				}
				if (this.mActionPopupShower == null)
				{
					this.mActionPopupShower = new _Runnable_10506(this);
				}
				else
				{
					this._enclosing.removeCallbacks(this.mActionPopupShower);
				}
				this._enclosing.postDelayed(this.mActionPopupShower, delay);
			}

			protected internal virtual void hideActionPopupWindow()
			{
				if (this.mActionPopupShower != null)
				{
					this._enclosing.removeCallbacks(this.mActionPopupShower);
				}
				if (this.mActionPopupWindow != null)
				{
					this.mActionPopupWindow.hide();
				}
			}

			public virtual bool isShowing()
			{
				return this.mContainer.isShowing();
			}

			internal bool isVisible()
			{
				// Always show a dragging handle.
				if (this.mIsDragging)
				{
					return true;
				}
				if (this._enclosing.isInBatchEditMode())
				{
					return false;
				}
				return this._enclosing.getPositionListener().isVisible(this.mPositionX + this.mHotspotX
					, this.mPositionY);
			}

			public abstract int getCurrentCursorOffset();

			protected internal abstract void updateSelection(int offset);

			public abstract void updatePosition(float x, float y);

			protected internal virtual void positionAtCursorOffset(int offset, bool parentScrolled
				)
			{
				// A HandleView relies on the layout, which may be nulled by external methods
				if (this._enclosing.mLayout == null)
				{
					// Will update controllers' state, hiding them and stopping selection mode if needed
					this._enclosing.prepareCursorControllers();
					return;
				}
				if (offset != this.mPreviousOffset || parentScrolled)
				{
					this.updateSelection(offset);
					this.addPositionToTouchUpFilter(offset);
					int line = this._enclosing.mLayout.getLineForOffset(offset);
					this.mPositionX = (int)(this._enclosing.mLayout.getPrimaryHorizontal(offset) - 0.5f
						 - this.mHotspotX);
					this.mPositionY = this._enclosing.mLayout.getLineBottom(line);
					// Take TextView's padding and scroll into account.
					this.mPositionX += this._enclosing.viewportToContentHorizontalOffset();
					this.mPositionY += this._enclosing.viewportToContentVerticalOffset();
					this.mPreviousOffset = offset;
					this.mPositionHasChanged = true;
				}
			}

			[Sharpen.ImplementsInterface(@"android.widget.TextView.TextViewPositionListener")]
			public virtual void updatePosition(int parentPositionX, int parentPositionY, bool
				 parentPositionChanged, bool parentScrolled)
			{
				this.positionAtCursorOffset(this.getCurrentCursorOffset(), parentScrolled);
				if (parentPositionChanged || this.mPositionHasChanged)
				{
					if (this.mIsDragging)
					{
						// Update touchToWindow offset in case of parent scrolling while dragging
						if (parentPositionX != this.mLastParentX || parentPositionY != this.mLastParentY)
						{
							this.mTouchToWindowOffsetX += parentPositionX - this.mLastParentX;
							this.mTouchToWindowOffsetY += parentPositionY - this.mLastParentY;
							this.mLastParentX = parentPositionX;
							this.mLastParentY = parentPositionY;
						}
						this.onHandleMoved();
					}
					if (this.isVisible())
					{
						int positionX = parentPositionX + this.mPositionX;
						int positionY = parentPositionY + this.mPositionY;
						if (this.isShowing())
						{
							this.mContainer.update(positionX, positionY, -1, -1);
						}
						else
						{
							this.mContainer.showAtLocation(this._enclosing, android.view.Gravity.NO_GRAVITY, 
								positionX, positionY);
						}
					}
					else
					{
						if (this.isShowing())
						{
							this.dismiss();
						}
					}
					this.mPositionHasChanged = false;
				}
			}

			[Sharpen.OverridesMethod(@"android.view.View")]
			protected internal override void onDraw(android.graphics.Canvas c)
			{
				this.mDrawable.setBounds(0, 0, this.mRight - this.mLeft, this.mBottom - this.mTop
					);
				this.mDrawable.draw(c);
			}

			[Sharpen.OverridesMethod(@"android.view.View")]
			public override bool onTouchEvent(android.view.MotionEvent ev)
			{
				switch (ev.getActionMasked())
				{
					case android.view.MotionEvent.ACTION_DOWN:
					{
						this.startTouchUpFilter(this.getCurrentCursorOffset());
						this.mTouchToWindowOffsetX = ev.getRawX() - this.mPositionX;
						this.mTouchToWindowOffsetY = ev.getRawY() - this.mPositionY;
						android.widget.TextView.PositionListener positionListener = this._enclosing.getPositionListener
							();
						this.mLastParentX = positionListener.getPositionX();
						this.mLastParentY = positionListener.getPositionY();
						this.mIsDragging = true;
						break;
					}

					case android.view.MotionEvent.ACTION_MOVE:
					{
						float rawX = ev.getRawX();
						float rawY = ev.getRawY();
						// Vertical hysteresis: vertical down movement tends to snap to ideal offset
						float previousVerticalOffset = this.mTouchToWindowOffsetY - this.mLastParentY;
						float currentVerticalOffset = rawY - this.mPositionY - this.mLastParentY;
						float newVerticalOffset;
						if (previousVerticalOffset < this.mIdealVerticalOffset)
						{
							newVerticalOffset = System.Math.Min(currentVerticalOffset, this.mIdealVerticalOffset
								);
							newVerticalOffset = System.Math.Max(newVerticalOffset, previousVerticalOffset);
						}
						else
						{
							newVerticalOffset = System.Math.Max(currentVerticalOffset, this.mIdealVerticalOffset
								);
							newVerticalOffset = System.Math.Min(newVerticalOffset, previousVerticalOffset);
						}
						this.mTouchToWindowOffsetY = newVerticalOffset + this.mLastParentY;
						float newPosX = rawX - this.mTouchToWindowOffsetX + this.mHotspotX;
						float newPosY = rawY - this.mTouchToWindowOffsetY + this.mTouchOffsetY;
						this.updatePosition(newPosX, newPosY);
						break;
					}

					case android.view.MotionEvent.ACTION_UP:
					{
						this.filterOnTouchUp();
						this.mIsDragging = false;
						break;
					}

					case android.view.MotionEvent.ACTION_CANCEL:
					{
						this.mIsDragging = false;
						break;
					}
				}
				return true;
			}

			public virtual bool isDragging()
			{
				return this.mIsDragging;
			}

			internal virtual void onHandleMoved()
			{
				this.hideActionPopupWindow();
			}

			public virtual void onDetached()
			{
				this.hideActionPopupWindow();
			}

			private readonly TextView _enclosing;
		}

		private class InsertionHandleView : android.widget.TextView.HandleView
		{
			internal const int DELAY_BEFORE_HANDLE_FADES_OUT = 4000;

			internal const int RECENT_CUT_COPY_DURATION = 15 * 1000;

			internal float mDownPositionX;

			internal float mDownPositionY;

			internal java.lang.Runnable mHider;

			public InsertionHandleView(TextView _enclosing, android.graphics.drawable.Drawable
				 drawable) : base(_enclosing, drawable, drawable)
			{
				this._enclosing = _enclosing;
			}

			// seconds
			// Used to detect taps on the insertion handle, which will affect the ActionPopupWindow
			[Sharpen.OverridesMethod(@"android.widget.TextView.HandleView")]
			public override void show()
			{
				base.show();
				long durationSinceCutOrCopy = android.os.SystemClock.uptimeMillis() - android.widget.TextView
					.sLastCutOrCopyTime;
				if (durationSinceCutOrCopy < RECENT_CUT_COPY_DURATION)
				{
					this.showActionPopupWindow(0);
				}
				this.hideAfterDelay();
			}

			public virtual void showWithActionPopup()
			{
				this.show();
				this.showActionPopupWindow(0);
			}

			internal sealed class _Runnable_10711 : java.lang.Runnable
			{
				public _Runnable_10711(InsertionHandleView _enclosing)
				{
					this._enclosing = _enclosing;
				}

				[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
				public void run()
				{
					this._enclosing.hide();
				}

				private readonly InsertionHandleView _enclosing;
			}

			internal void hideAfterDelay()
			{
				this.removeHiderCallback();
				if (this.mHider == null)
				{
					this.mHider = new _Runnable_10711(this);
				}
				this._enclosing.postDelayed(this.mHider, DELAY_BEFORE_HANDLE_FADES_OUT);
			}

			internal void removeHiderCallback()
			{
				if (this.mHider != null)
				{
					this._enclosing.removeCallbacks(this.mHider);
				}
			}

			[Sharpen.OverridesMethod(@"android.widget.TextView.HandleView")]
			protected internal override int getHotspotX(android.graphics.drawable.Drawable drawable
				, bool isRtlRun)
			{
				return drawable.getIntrinsicWidth() / 2;
			}

			[Sharpen.OverridesMethod(@"android.view.View")]
			public override bool onTouchEvent(android.view.MotionEvent ev)
			{
				bool result = base.onTouchEvent(ev);
				switch (ev.getActionMasked())
				{
					case android.view.MotionEvent.ACTION_DOWN:
					{
						this.mDownPositionX = ev.getRawX();
						this.mDownPositionY = ev.getRawY();
						break;
					}

					case android.view.MotionEvent.ACTION_UP:
					{
						if (!this.offsetHasBeenChanged())
						{
							float deltaX = this.mDownPositionX - ev.getRawX();
							float deltaY = this.mDownPositionY - ev.getRawY();
							float distanceSquared = deltaX * deltaX + deltaY * deltaY;
							if (distanceSquared < this._enclosing.mSquaredTouchSlopDistance)
							{
								if (this.mActionPopupWindow != null && this.mActionPopupWindow.isShowing())
								{
									// Tapping on the handle dismisses the displayed action popup
									this.mActionPopupWindow.hide();
								}
								else
								{
									this.showWithActionPopup();
								}
							}
						}
						this.hideAfterDelay();
						break;
					}

					case android.view.MotionEvent.ACTION_CANCEL:
					{
						this.hideAfterDelay();
						break;
					}

					default:
					{
						break;
					}
				}
				return result;
			}

			[Sharpen.OverridesMethod(@"android.widget.TextView.HandleView")]
			public override int getCurrentCursorOffset()
			{
				return this._enclosing.getSelectionStart();
			}

			[Sharpen.OverridesMethod(@"android.widget.TextView.HandleView")]
			protected internal override void updateSelection(int offset)
			{
				android.text.Selection.setSelection((android.text.Spannable)this._enclosing.mText
					, offset);
			}

			[Sharpen.OverridesMethod(@"android.widget.TextView.HandleView")]
			public override void updatePosition(float x, float y)
			{
				this.positionAtCursorOffset(this._enclosing.getOffsetForPosition(x, y), false);
			}

			[Sharpen.OverridesMethod(@"android.widget.TextView.HandleView")]
			internal override void onHandleMoved()
			{
				base.onHandleMoved();
				this.removeHiderCallback();
			}

			[Sharpen.OverridesMethod(@"android.widget.TextView.HandleView")]
			public override void onDetached()
			{
				base.onDetached();
				this.removeHiderCallback();
			}

			private readonly TextView _enclosing;
		}

		private class SelectionStartHandleView : android.widget.TextView.HandleView
		{
			public SelectionStartHandleView(TextView _enclosing, android.graphics.drawable.Drawable
				 drawableLtr, android.graphics.drawable.Drawable drawableRtl) : base(_enclosing, 
				drawableLtr, drawableRtl)
			{
				this._enclosing = _enclosing;
			}

			[Sharpen.OverridesMethod(@"android.widget.TextView.HandleView")]
			protected internal override int getHotspotX(android.graphics.drawable.Drawable drawable
				, bool isRtlRun)
			{
				if (isRtlRun)
				{
					return drawable.getIntrinsicWidth() / 4;
				}
				else
				{
					return (drawable.getIntrinsicWidth() * 3) / 4;
				}
			}

			[Sharpen.OverridesMethod(@"android.widget.TextView.HandleView")]
			public override int getCurrentCursorOffset()
			{
				return this._enclosing.getSelectionStart();
			}

			[Sharpen.OverridesMethod(@"android.widget.TextView.HandleView")]
			protected internal override void updateSelection(int offset)
			{
				android.text.Selection.setSelection((android.text.Spannable)this._enclosing.mText
					, offset, this._enclosing.getSelectionEnd());
				this.updateDrawable();
			}

			[Sharpen.OverridesMethod(@"android.widget.TextView.HandleView")]
			public override void updatePosition(float x, float y)
			{
				int offset = this._enclosing.getOffsetForPosition(x, y);
				// Handles can not cross and selection is at least one character
				int selectionEnd = this._enclosing.getSelectionEnd();
				if (offset >= selectionEnd)
				{
					offset = selectionEnd - 1;
				}
				this.positionAtCursorOffset(offset, false);
			}

			public virtual android.widget.TextView.ActionPopupWindow getActionPopupWindow()
			{
				return this.mActionPopupWindow;
			}

			private readonly TextView _enclosing;
		}

		private class SelectionEndHandleView : android.widget.TextView.HandleView
		{
			public SelectionEndHandleView(TextView _enclosing, android.graphics.drawable.Drawable
				 drawableLtr, android.graphics.drawable.Drawable drawableRtl) : base(_enclosing, 
				drawableLtr, drawableRtl)
			{
				this._enclosing = _enclosing;
			}

			[Sharpen.OverridesMethod(@"android.widget.TextView.HandleView")]
			protected internal override int getHotspotX(android.graphics.drawable.Drawable drawable
				, bool isRtlRun)
			{
				if (isRtlRun)
				{
					return (drawable.getIntrinsicWidth() * 3) / 4;
				}
				else
				{
					return drawable.getIntrinsicWidth() / 4;
				}
			}

			[Sharpen.OverridesMethod(@"android.widget.TextView.HandleView")]
			public override int getCurrentCursorOffset()
			{
				return this._enclosing.getSelectionEnd();
			}

			[Sharpen.OverridesMethod(@"android.widget.TextView.HandleView")]
			protected internal override void updateSelection(int offset)
			{
				android.text.Selection.setSelection((android.text.Spannable)this._enclosing.mText
					, this._enclosing.getSelectionStart(), offset);
				this.updateDrawable();
			}

			[Sharpen.OverridesMethod(@"android.widget.TextView.HandleView")]
			public override void updatePosition(float x, float y)
			{
				int offset = this._enclosing.getOffsetForPosition(x, y);
				// Handles can not cross and selection is at least one character
				int selectionStart = this._enclosing.getSelectionStart();
				if (offset <= selectionStart)
				{
					offset = selectionStart + 1;
				}
				this.positionAtCursorOffset(offset, false);
			}

			public virtual void setActionPopupWindow(android.widget.TextView.ActionPopupWindow
				 actionPopupWindow)
			{
				this.mActionPopupWindow = actionPopupWindow;
			}

			private readonly TextView _enclosing;
		}

		/// <summary>A CursorController instance can be used to control a cursor in the text.
		/// 	</summary>
		/// <remarks>
		/// A CursorController instance can be used to control a cursor in the text.
		/// It is not used outside of
		/// <see cref="TextView">TextView</see>
		/// .
		/// </remarks>
		/// <hide></hide>
		private interface CursorController : android.view.ViewTreeObserver.OnTouchModeChangeListener
		{
			/// <summary>Makes the cursor controller visible on screen.</summary>
			/// <remarks>
			/// Makes the cursor controller visible on screen. Will be drawn by
			/// <see cref="android.view.View.draw(android.graphics.Canvas)">android.view.View.draw(android.graphics.Canvas)
			/// 	</see>
			/// .
			/// See also
			/// <see cref="hide()">hide()</see>
			/// .
			/// </remarks>
			void show();

			/// <summary>Hide the cursor controller from screen.</summary>
			/// <remarks>
			/// Hide the cursor controller from screen.
			/// See also
			/// <see cref="show()">show()</see>
			/// .
			/// </remarks>
			void hide();

			/// <summary>Called when the view is detached from window.</summary>
			/// <remarks>
			/// Called when the view is detached from window. Perform house keeping task, such as
			/// stopping Runnable thread that would otherwise keep a reference on the context, thus
			/// preventing the activity from being recycled.
			/// </remarks>
			void onDetached();
		}

		private class InsertionPointCursorController : android.widget.TextView.CursorController
		{
			internal android.widget.TextView.InsertionHandleView mHandle;

			[Sharpen.ImplementsInterface(@"android.widget.TextView.CursorController")]
			public virtual void show()
			{
				this.getHandle().show();
			}

			public virtual void showWithActionPopup()
			{
				this.getHandle().showWithActionPopup();
			}

			[Sharpen.ImplementsInterface(@"android.widget.TextView.CursorController")]
			public virtual void hide()
			{
				if (this.mHandle != null)
				{
					this.mHandle.hide();
				}
			}

			[Sharpen.ImplementsInterface(@"android.view.ViewTreeObserver.OnTouchModeChangeListener"
				)]
			public virtual void onTouchModeChanged(bool isInTouchMode)
			{
				if (!isInTouchMode)
				{
					this.hide();
				}
			}

			internal android.widget.TextView.InsertionHandleView getHandle()
			{
				if (this._enclosing.mSelectHandleCenter == null)
				{
					this._enclosing.mSelectHandleCenter = this._enclosing.mContext.getResources().getDrawable
						(this._enclosing.mTextSelectHandleRes);
				}
				if (this.mHandle == null)
				{
					this.mHandle = new android.widget.TextView.InsertionHandleView(this._enclosing, this
						._enclosing.mSelectHandleCenter);
				}
				return this.mHandle;
			}

			[Sharpen.ImplementsInterface(@"android.widget.TextView.CursorController")]
			public virtual void onDetached()
			{
				android.view.ViewTreeObserver observer = this._enclosing.getViewTreeObserver();
				observer.removeOnTouchModeChangeListener(this);
				if (this.mHandle != null)
				{
					this.mHandle.onDetached();
				}
			}

			internal InsertionPointCursorController(TextView _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly TextView _enclosing;
		}

		private class SelectionModifierCursorController : android.widget.TextView.CursorController
		{
			internal const int DELAY_BEFORE_REPLACE_ACTION = 200;

			internal android.widget.TextView.SelectionStartHandleView mStartHandle;

			internal android.widget.TextView.SelectionEndHandleView mEndHandle;

			internal int mMinTouchOffset;

			internal int mMaxTouchOffset;

			internal long mPreviousTapUpTime;

			internal float mPreviousTapPositionX;

			internal float mPreviousTapPositionY;

			internal SelectionModifierCursorController(TextView _enclosing)
			{
				this._enclosing = _enclosing;
				mPreviousTapUpTime = 0;
				// milliseconds
				// The cursor controller handles, lazily created when shown.
				// The offsets of that last touch down event. Remembered to start selection there.
				// Double tap detection
				this.resetTouchOffsets();
			}

			[Sharpen.ImplementsInterface(@"android.widget.TextView.CursorController")]
			public virtual void show()
			{
				if (this._enclosing.isInBatchEditMode())
				{
					return;
				}
				this.initDrawables();
				this.initHandles();
				this._enclosing.hideInsertionPointCursorController();
			}

			internal void initDrawables()
			{
				if (this._enclosing.mSelectHandleLeft == null)
				{
					this._enclosing.mSelectHandleLeft = this._enclosing.mContext.getResources().getDrawable
						(this._enclosing.mTextSelectHandleLeftRes);
				}
				if (this._enclosing.mSelectHandleRight == null)
				{
					this._enclosing.mSelectHandleRight = this._enclosing.mContext.getResources().getDrawable
						(this._enclosing.mTextSelectHandleRightRes);
				}
			}

			internal void initHandles()
			{
				// Lazy object creation has to be done before updatePosition() is called.
				if (this.mStartHandle == null)
				{
					this.mStartHandle = new android.widget.TextView.SelectionStartHandleView(this._enclosing
						, this._enclosing.mSelectHandleLeft, this._enclosing.mSelectHandleRight);
				}
				if (this.mEndHandle == null)
				{
					this.mEndHandle = new android.widget.TextView.SelectionEndHandleView(this._enclosing
						, this._enclosing.mSelectHandleRight, this._enclosing.mSelectHandleLeft);
				}
				this.mStartHandle.show();
				this.mEndHandle.show();
				// Make sure both left and right handles share the same ActionPopupWindow (so that
				// moving any of the handles hides the action popup).
				this.mStartHandle.showActionPopupWindow(DELAY_BEFORE_REPLACE_ACTION);
				this.mEndHandle.setActionPopupWindow(this.mStartHandle.getActionPopupWindow());
				this._enclosing.hideInsertionPointCursorController();
			}

			[Sharpen.ImplementsInterface(@"android.widget.TextView.CursorController")]
			public virtual void hide()
			{
				if (this.mStartHandle != null)
				{
					this.mStartHandle.hide();
				}
				if (this.mEndHandle != null)
				{
					this.mEndHandle.hide();
				}
			}

			public virtual void onTouchEvent(android.view.MotionEvent @event)
			{
				switch (@event.getActionMasked())
				{
					case android.view.MotionEvent.ACTION_DOWN:
					{
						// This is done even when the View does not have focus, so that long presses can start
						// selection and tap can move cursor from this tap position.
						float x = @event.getX();
						float y = @event.getY();
						// Remember finger down position, to be able to start selection from there
						this.mMinTouchOffset = this.mMaxTouchOffset = this._enclosing.getOffsetForPosition
							(x, y);
						// Double tap detection
						long duration = android.os.SystemClock.uptimeMillis() - this.mPreviousTapUpTime;
						if (duration <= android.view.ViewConfiguration.getDoubleTapTimeout() && this._enclosing
							.isPositionOnText(x, y))
						{
							float deltaX = x - this.mPreviousTapPositionX;
							float deltaY = y - this.mPreviousTapPositionY;
							float distanceSquared = deltaX * deltaX + deltaY * deltaY;
							if (distanceSquared < this._enclosing.mSquaredTouchSlopDistance)
							{
								this._enclosing.startSelectionActionMode();
								this._enclosing.mDiscardNextActionUp = true;
							}
						}
						this.mPreviousTapPositionX = x;
						this.mPreviousTapPositionY = y;
						break;
					}

					case android.view.MotionEvent.ACTION_POINTER_DOWN:
					case android.view.MotionEvent.ACTION_POINTER_UP:
					{
						// Handle multi-point gestures. Keep min and max offset positions.
						// Only activated for devices that correctly handle multi-touch.
						if (this._enclosing.mContext.getPackageManager().hasSystemFeature(android.content.pm.PackageManager
							.FEATURE_TOUCHSCREEN_MULTITOUCH_DISTINCT))
						{
							this.updateMinAndMaxOffsets(@event);
						}
						break;
					}

					case android.view.MotionEvent.ACTION_UP:
					{
						this.mPreviousTapUpTime = android.os.SystemClock.uptimeMillis();
						break;
					}
				}
			}

			/// <param name="event"></param>
			internal void updateMinAndMaxOffsets(android.view.MotionEvent @event)
			{
				int pointerCount = @event.getPointerCount();
				{
					for (int index = 0; index < pointerCount; index++)
					{
						int offset = this._enclosing.getOffsetForPosition(@event.getX(index), @event.getY
							(index));
						if (offset < this.mMinTouchOffset)
						{
							this.mMinTouchOffset = offset;
						}
						if (offset > this.mMaxTouchOffset)
						{
							this.mMaxTouchOffset = offset;
						}
					}
				}
			}

			public virtual int getMinTouchOffset()
			{
				return this.mMinTouchOffset;
			}

			public virtual int getMaxTouchOffset()
			{
				return this.mMaxTouchOffset;
			}

			public virtual void resetTouchOffsets()
			{
				this.mMinTouchOffset = this.mMaxTouchOffset = -1;
			}

			/// <returns>true iff this controller is currently used to move the selection start.</returns>
			public virtual bool isSelectionStartDragged()
			{
				return this.mStartHandle != null && this.mStartHandle.isDragging();
			}

			[Sharpen.ImplementsInterface(@"android.view.ViewTreeObserver.OnTouchModeChangeListener"
				)]
			public virtual void onTouchModeChanged(bool isInTouchMode)
			{
				if (!isInTouchMode)
				{
					this.hide();
				}
			}

			[Sharpen.ImplementsInterface(@"android.widget.TextView.CursorController")]
			public virtual void onDetached()
			{
				android.view.ViewTreeObserver observer = this._enclosing.getViewTreeObserver();
				observer.removeOnTouchModeChangeListener(this);
				if (this.mStartHandle != null)
				{
					this.mStartHandle.onDetached();
				}
				if (this.mEndHandle != null)
				{
					this.mEndHandle.onDetached();
				}
			}

			private readonly TextView _enclosing;
		}

		private void hideInsertionPointCursorController()
		{
			// No need to create the controller to hide it.
			if (mInsertionPointCursorController != null)
			{
				mInsertionPointCursorController.hide();
			}
		}

		/// <summary>Hides the insertion controller and stops text selection mode, hiding the selection controller
		/// 	</summary>
		private void hideControllers()
		{
			hideCursorControllers();
			hideSpanControllers();
		}

		private void hideSpanControllers()
		{
			if (mChangeWatcher != null)
			{
				mChangeWatcher.hideControllers();
			}
		}

		private void hideCursorControllers()
		{
			hideInsertionPointCursorController();
			stopSelectionActionMode();
		}

		/// <summary>Get the character offset closest to the specified absolute position.</summary>
		/// <remarks>
		/// Get the character offset closest to the specified absolute position. A typical use case is to
		/// pass the result of
		/// <see cref="android.view.MotionEvent.getX()">android.view.MotionEvent.getX()</see>
		/// and
		/// <see cref="android.view.MotionEvent.getY()">android.view.MotionEvent.getY()</see>
		/// to this method.
		/// </remarks>
		/// <param name="x">The horizontal absolute position of a point on screen</param>
		/// <param name="y">The vertical absolute position of a point on screen</param>
		/// <returns>
		/// the character offset for the character whose position is closest to the specified
		/// position. Returns -1 if there is no layout.
		/// </returns>
		public virtual int getOffsetForPosition(float x, float y)
		{
			if (getLayout() == null)
			{
				return -1;
			}
			int line = getLineAtCoordinate(y);
			int offset = getOffsetAtCoordinate(line, x);
			return offset;
		}

		private float convertToLocalHorizontalCoordinate(float x)
		{
			x -= getTotalPaddingLeft();
			// Clamp the position to inside of the view.
			x = System.Math.Max(0.0f, x);
			x = System.Math.Min(getWidth() - getTotalPaddingRight() - 1, x);
			x += getScrollX();
			return x;
		}

		private int getLineAtCoordinate(float y)
		{
			y -= getTotalPaddingTop();
			// Clamp the position to inside of the view.
			y = System.Math.Max(0.0f, y);
			y = System.Math.Min(getHeight() - getTotalPaddingBottom() - 1, y);
			y += getScrollY();
			return getLayout().getLineForVertical((int)y);
		}

		private int getOffsetAtCoordinate(int line, float x)
		{
			x = convertToLocalHorizontalCoordinate(x);
			return getLayout().getOffsetForHorizontal(line, x);
		}

		/// <summary>
		/// Returns true if the screen coordinates position (x,y) corresponds to a character displayed
		/// in the view.
		/// </summary>
		/// <remarks>
		/// Returns true if the screen coordinates position (x,y) corresponds to a character displayed
		/// in the view. Returns false when the position is in the empty space of left/right of text.
		/// </remarks>
		private bool isPositionOnText(float x, float y)
		{
			if (getLayout() == null)
			{
				return false;
			}
			int line = getLineAtCoordinate(y);
			x = convertToLocalHorizontalCoordinate(x);
			if (x < getLayout().getLineLeft(line))
			{
				return false;
			}
			if (x > getLayout().getLineRight(line))
			{
				return false;
			}
			return true;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool onDragEvent(android.view.DragEvent @event)
		{
			switch (@event.getAction())
			{
				case android.view.DragEvent.ACTION_DRAG_STARTED:
				{
					return hasInsertionController();
				}

				case android.view.DragEvent.ACTION_DRAG_ENTERED:
				{
					this.requestFocus();
					return true;
				}

				case android.view.DragEvent.ACTION_DRAG_LOCATION:
				{
					int offset = getOffsetForPosition(@event.getX(), @event.getY());
					android.text.Selection.setSelection((android.text.Spannable)mText, offset);
					return true;
				}

				case android.view.DragEvent.ACTION_DROP:
				{
					onDrop(@event);
					return true;
				}

				case android.view.DragEvent.ACTION_DRAG_ENDED:
				case android.view.DragEvent.ACTION_DRAG_EXITED:
				default:
				{
					return true;
				}
			}
		}

		private void onDrop(android.view.DragEvent @event)
		{
			java.lang.StringBuilder content = new java.lang.StringBuilder(string.Empty);
			android.content.ClipData clipData = @event.getClipData();
			int itemCount = clipData.getItemCount();
			{
				for (int i = 0; i < itemCount; i++)
				{
					android.content.ClipData.Item item = clipData.getItemAt(i);
					content.append(item.coerceToText(this.mContext));
				}
			}
			int offset = getOffsetForPosition(@event.getX(), @event.getY());
			object localState = @event.getLocalState();
			android.widget.TextView.DragLocalState dragLocalState = null;
			if (localState is android.widget.TextView.DragLocalState)
			{
				dragLocalState = (android.widget.TextView.DragLocalState)localState;
			}
			bool dragDropIntoItself = dragLocalState != null && dragLocalState.sourceTextView
				 == this;
			if (dragDropIntoItself)
			{
				if (offset >= dragLocalState.start && offset < dragLocalState.end)
				{
					// A drop inside the original selection discards the drop.
					return;
				}
			}
			int originalLength = mText.Length;
			long minMax = prepareSpacesAroundPaste(offset, offset, content);
			int min = extractRangeStartFromLong(minMax);
			int max = extractRangeEndFromLong(minMax);
			android.text.Selection.setSelection((android.text.Spannable)mText, max);
			((android.text.Editable)mText).replace(min, max, content);
			if (dragDropIntoItself)
			{
				int dragSourceStart = dragLocalState.start;
				int dragSourceEnd = dragLocalState.end;
				if (max <= dragSourceStart)
				{
					// Inserting text before selection has shifted positions
					int shift = mText.Length - originalLength;
					dragSourceStart += shift;
					dragSourceEnd += shift;
				}
				// Delete original selection
				((android.text.Editable)mText).delete(dragSourceStart, dragSourceEnd);
				// Make sure we do not leave two adjacent spaces.
				if ((dragSourceStart == 0 || System.Char.IsWhiteSpace(mTransformed[dragSourceStart
					 - 1])) && (dragSourceStart == mText.Length || System.Char.IsWhiteSpace(mTransformed
					[dragSourceStart])))
				{
					int pos = dragSourceStart == mText.Length ? dragSourceStart - 1 : dragSourceStart;
					((android.text.Editable)mText).delete(pos, pos + 1);
				}
			}
		}

		/// <returns>True if this view supports insertion handles.</returns>
		internal virtual bool hasInsertionController()
		{
			return mInsertionControllerEnabled;
		}

		/// <returns>True if this view supports selection handles.</returns>
		internal virtual bool hasSelectionController()
		{
			return mSelectionControllerEnabled;
		}

		private android.widget.TextView.InsertionPointCursorController getInsertionController
			()
		{
			if (!mInsertionControllerEnabled)
			{
				return null;
			}
			if (mInsertionPointCursorController == null)
			{
				mInsertionPointCursorController = new android.widget.TextView.InsertionPointCursorController
					(this);
				android.view.ViewTreeObserver observer = getViewTreeObserver();
				observer.addOnTouchModeChangeListener(mInsertionPointCursorController);
			}
			return mInsertionPointCursorController;
		}

		private android.widget.TextView.SelectionModifierCursorController getSelectionController
			()
		{
			if (!mSelectionControllerEnabled)
			{
				return null;
			}
			if (mSelectionModifierCursorController == null)
			{
				mSelectionModifierCursorController = new android.widget.TextView.SelectionModifierCursorController
					(this);
				android.view.ViewTreeObserver observer = getViewTreeObserver();
				observer.addOnTouchModeChangeListener(mSelectionModifierCursorController);
			}
			return mSelectionModifierCursorController;
		}

		internal virtual bool isInBatchEditMode()
		{
			android.widget.TextView.InputMethodState ims = mInputMethodState;
			if (ims != null)
			{
				return ims.mBatchEditNesting > 0;
			}
			return mInBatchEditControllers;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void resolveTextDirection()
		{
			if (hasPasswordTransformationMethod())
			{
				mTextDir = android.text.TextDirectionHeuristics.LOCALE;
				return;
			}
			// Always need to resolve layout direction first
			bool defaultIsRtl = (getResolvedLayoutDirection() == LAYOUT_DIRECTION_RTL);
			// Then resolve text direction on the parent
			base.resolveTextDirection();
			// Now, we can select the heuristic
			int textDir = getResolvedTextDirection();
			switch (textDir)
			{
				case TEXT_DIRECTION_FIRST_STRONG:
				default:
				{
					mTextDir = (defaultIsRtl ? android.text.TextDirectionHeuristics.FIRSTSTRONG_RTL : 
						android.text.TextDirectionHeuristics.FIRSTSTRONG_LTR);
					break;
				}

				case TEXT_DIRECTION_ANY_RTL:
				{
					mTextDir = android.text.TextDirectionHeuristics.ANYRTL_LTR;
					break;
				}

				case TEXT_DIRECTION_LTR:
				{
					mTextDir = android.text.TextDirectionHeuristics.LTR;
					break;
				}

				case TEXT_DIRECTION_RTL:
				{
					mTextDir = android.text.TextDirectionHeuristics.RTL;
					break;
				}
			}
		}

		/// <summary>
		/// Subclasses will need to override this method to implement their own way of resolving
		/// drawables depending on the layout direction.
		/// </summary>
		/// <remarks>
		/// Subclasses will need to override this method to implement their own way of resolving
		/// drawables depending on the layout direction.
		/// A call to the super method will be required from the subclasses implementation.
		/// </remarks>
		protected internal virtual void resolveDrawables()
		{
			// No need to resolve twice
			if (mResolvedDrawables)
			{
				return;
			}
			// No drawable to resolve
			if (mDrawables == null)
			{
				return;
			}
			// No relative drawable to resolve
			if (mDrawables.mDrawableStart == null && mDrawables.mDrawableEnd == null)
			{
				mResolvedDrawables = true;
				return;
			}
			android.widget.TextView.Drawables dr = mDrawables;
			switch (getResolvedLayoutDirection())
			{
				case LAYOUT_DIRECTION_RTL:
				{
					if (dr.mDrawableStart != null)
					{
						dr.mDrawableRight = dr.mDrawableStart;
						dr.mDrawableSizeRight = dr.mDrawableSizeStart;
						dr.mDrawableHeightRight = dr.mDrawableHeightStart;
					}
					if (dr.mDrawableEnd != null)
					{
						dr.mDrawableLeft = dr.mDrawableEnd;
						dr.mDrawableSizeLeft = dr.mDrawableSizeEnd;
						dr.mDrawableHeightLeft = dr.mDrawableHeightEnd;
					}
					break;
				}

				case LAYOUT_DIRECTION_LTR:
				default:
				{
					if (dr.mDrawableStart != null)
					{
						dr.mDrawableLeft = dr.mDrawableStart;
						dr.mDrawableSizeLeft = dr.mDrawableSizeStart;
						dr.mDrawableHeightLeft = dr.mDrawableHeightStart;
					}
					if (dr.mDrawableEnd != null)
					{
						dr.mDrawableRight = dr.mDrawableEnd;
						dr.mDrawableSizeRight = dr.mDrawableSizeEnd;
						dr.mDrawableHeightRight = dr.mDrawableHeightEnd;
					}
					break;
				}
			}
			mResolvedDrawables = true;
		}

		protected internal virtual void resetResolvedDrawables()
		{
			mResolvedDrawables = false;
		}

		/// <hide></hide>
		protected internal virtual void viewClicked(android.view.inputmethod.InputMethodManager
			 imm)
		{
			if (imm != null)
			{
				imm.viewClicked(this);
			}
		}

		private java.lang.CharSequence mText;

		private java.lang.CharSequence mTransformed;

		private android.widget.TextView.BufferType mBufferType = android.widget.TextView.
			BufferType.NORMAL;

		private int mInputType = android.text.InputTypeClass.TYPE_NULL;

		private java.lang.CharSequence mHint;

		private android.text.Layout mHintLayout;

		private android.text.method.KeyListener mInput;

		private android.text.method.MovementMethod mMovement;

		private android.text.method.TransformationMethod mTransformation;

		private bool mAllowTransformationLengthChange;

		private android.widget.TextView.ChangeWatcher mChangeWatcher;

		private java.util.ArrayList<android.text.TextWatcher> mListeners = null;

		private readonly android.text.TextPaint mTextPaint;

		private bool mUserSetTextScaleX;

		private readonly android.graphics.Paint mHighlightPaint;

		private int mHighlightColor = unchecked((int)(0x6633B5E5));

		/// <summary>This is temporarily visible to fix bug 3085564 in webView.</summary>
		/// <remarks>
		/// This is temporarily visible to fix bug 3085564 in webView. Do not rely on
		/// this field being protected. Will be restored as private when lineHeight
		/// feature request 3215097 is implemented
		/// </remarks>
		/// <hide></hide>
		protected internal android.text.Layout mLayout;

		private long mShowCursor;

		private android.widget.TextView.Blink mBlink;

		private bool mCursorVisible = true;

		private android.widget.TextView.InsertionPointCursorController mInsertionPointCursorController;

		private android.widget.TextView.SelectionModifierCursorController mSelectionModifierCursorController;

		private android.view.ActionMode mSelectionActionMode;

		private bool mInsertionControllerEnabled;

		private bool mSelectionControllerEnabled;

		private bool mInBatchEditControllers;

		private bool mDPadCenterIsDown = false;

		private bool mEnterKeyIsDown = false;

		private bool mContextMenuTriggeredByKey = false;

		private bool mSelectAllOnFocus = false;

		private int mGravity = android.view.Gravity.TOP | android.view.Gravity.START;

		private bool mHorizontallyScrolling;

		private int mAutoLinkMask;

		private bool mLinksClickable = true;

		private float mSpacingMult = 1.0f;

		private float mSpacingAdd = 0.0f;

		private bool mTextIsSelectable = false;

		internal const int LINES = 1;

		internal const int EMS = LINES;

		internal const int PIXELS = 2;

		private int mMaximum = int.MaxValue;

		private int mMaxMode = LINES;

		private int mMinimum = 0;

		private int mMinMode = LINES;

		private int mOldMaximum;

		private int mOldMaxMode;

		private int mMaxWidth = int.MaxValue;

		private int mMaxWidthMode = PIXELS;

		private int mMinWidth = 0;

		private int mMinWidthMode = PIXELS;

		private bool mSingleLine;

		private int mDesiredHeightAtMeasure = -1;

		private bool mIncludePad = true;

		private android.graphics.Path mHighlightPath;

		private bool mHighlightPathBogus = true;

		private static readonly android.graphics.RectF sTempRect = new android.graphics.RectF
			();

		internal const int VERY_WIDE = 1024 * 1024;

		internal const int BLINK = 500;

		internal const int ANIMATED_SCROLL_GAP = 250;

		private long mLastScroll;

		private android.widget.Scroller mScroller = null;

		private android.text.BoringLayout.Metrics mBoring;

		private android.text.BoringLayout.Metrics mHintBoring;

		private android.text.BoringLayout mSavedLayout;

		private android.text.BoringLayout mSavedHintLayout;

		private android.text.TextDirectionHeuristic mTextDir = null;

		private static readonly android.text.InputFilter[] NO_FILTERS = new android.text.InputFilter
			[0];

		private android.text.InputFilter[] mFilters = NO_FILTERS;

		private static readonly android.text.Spanned EMPTY_SPANNED = new android.text.SpannedString
			(java.lang.CharSequenceProxy.Wrap(string.Empty));

		private static int DRAG_SHADOW_MAX_TEXT_LENGTH = 20;

		private static long sLastCutOrCopyTime;

		private android.widget.TextView.CorrectionHighlighter mCorrectionHighlighter;

		private static readonly int[] MULTILINE_STATE_SET = new int[] { android.R.attr.state_multiline
			 };
		// display attributes
		// Cursor Controllers.
		// These are needed to desambiguate a long click. If the long click comes from ones of these, we
		// select from the current cursor position. Otherwise, select from long pressed position.
		// tmp primitives, so we don't alloc them on each draw
		// XXX should be much larger
		// System wide time for last cut or copy action.
		// Used to highlight a word when it is corrected by the IME
		// New state used to change background based on whether this TextView is multiline.
	}
}

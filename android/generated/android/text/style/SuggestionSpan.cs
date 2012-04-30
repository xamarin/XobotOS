using Sharpen;

namespace android.text.style
{
	[Sharpen.Stub]
	public class SuggestionSpan : android.text.style.CharacterStyle, android.text.ParcelableSpan
	{
		public const int FLAG_EASY_CORRECT = unchecked((int)(0x0001));

		public const int FLAG_MISSPELLED = unchecked((int)(0x0002));

		public const int FLAG_AUTO_CORRECTION = unchecked((int)(0x0004));

		public const string ACTION_SUGGESTION_PICKED = "android.text.style.SUGGESTION_PICKED";

		public const string SUGGESTION_SPAN_PICKED_AFTER = "after";

		public const string SUGGESTION_SPAN_PICKED_BEFORE = "before";

		public const string SUGGESTION_SPAN_PICKED_HASHCODE = "hashcode";

		public const int SUGGESTIONS_MAX_SIZE = 5;

		private int mFlags;

		private readonly string[] mSuggestions;

		private readonly string mLocaleString;

		private readonly string mNotificationTargetClassName;

		private readonly int mHashCode;

		private float mEasyCorrectUnderlineThickness;

		private int mEasyCorrectUnderlineColor;

		private float mMisspelledUnderlineThickness;

		private int mMisspelledUnderlineColor;

		private float mAutoCorrectionUnderlineThickness;

		private int mAutoCorrectionUnderlineColor;

		[Sharpen.Stub]
		public SuggestionSpan(android.content.Context context, string[] suggestions, int 
			flags) : this(context, null, suggestions, flags, null)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public SuggestionSpan(System.Globalization.CultureInfo locale, string[] suggestions
			, int flags) : this(null, locale, suggestions, flags, null)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public SuggestionSpan(android.content.Context context, System.Globalization.CultureInfo
			 locale, string[] suggestions, int flags, System.Type notificationTargetClass)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void initStyle(android.content.Context context)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public SuggestionSpan(android.os.Parcel src)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string[] getSuggestions()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string getLocale()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string getNotificationTargetClassName()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getFlags()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setFlags(int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual int describeContents()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual void writeToParcel(android.os.Parcel dest, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.text.ParcelableSpan")]
		public virtual int getSpanTypeId()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override bool Equals(object o)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override int GetHashCode()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static int hashCodeInternal(string[] suggestions, string locale, string notificationTargetClassName
			)
		{
			throw new System.NotImplementedException();
		}

		private sealed class _Creator_270 : android.os.ParcelableClass.Creator<android.text.style.SuggestionSpan
			>
		{
			public _Creator_270()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.text.style.SuggestionSpan createFromParcel(android.os.Parcel source
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.text.style.SuggestionSpan[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.text.style.SuggestionSpan
			> CREATOR = new _Creator_270();

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.text.style.CharacterStyle")]
		public override void updateDrawState(android.text.TextPaint tp)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getUnderlineColor()
		{
			throw new System.NotImplementedException();
		}
	}
}

using Sharpen;

namespace android.view.textservice
{
	[Sharpen.Stub]
	public sealed class SuggestionsInfo : android.os.Parcelable
	{
		private static readonly string[] EMPTY = new string[0];

		public const int RESULT_ATTR_IN_THE_DICTIONARY = unchecked((int)(0x0001));

		public const int RESULT_ATTR_LOOKS_LIKE_TYPO = unchecked((int)(0x0002));

		private readonly int mSuggestionsAttributes;

		private readonly string[] mSuggestions;

		private readonly bool mSuggestionsAvailable;

		private int mCookie;

		private int mSequence;

		[Sharpen.Stub]
		public SuggestionsInfo(int suggestionsAttributes, string[] suggestions)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public SuggestionsInfo(int suggestionsAttributes, string[] suggestions, int cookie
			, int sequence)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public SuggestionsInfo(android.os.Parcel source)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public void writeToParcel(android.os.Parcel dest, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void setCookieAndSequence(int cookie, int sequence)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int getCookie()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int getSequence()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int getSuggestionsAttributes()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int getSuggestionsCount()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public string getSuggestionAt(int i)
		{
			throw new System.NotImplementedException();
		}

		private sealed class _Creator_169 : android.os.ParcelableClass.Creator<android.view.textservice.SuggestionsInfo
			>
		{
			public _Creator_169()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.view.textservice.SuggestionsInfo createFromParcel(android.os.Parcel
				 source)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.view.textservice.SuggestionsInfo[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.view.textservice.SuggestionsInfo
			> CREATOR = new _Creator_169();

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public int describeContents()
		{
			throw new System.NotImplementedException();
		}
	}
}

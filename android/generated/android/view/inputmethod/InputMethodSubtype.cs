using Sharpen;

namespace android.view.inputmethod
{
	[Sharpen.Stub]
	public sealed class InputMethodSubtype : android.os.Parcelable
	{
		private static readonly string TAG = typeof(android.view.inputmethod.InputMethodSubtype
			).Name;

		internal const string EXTRA_VALUE_PAIR_SEPARATOR = ",";

		internal const string EXTRA_VALUE_KEY_VALUE_SEPARATOR = "=";

		private readonly bool mIsAuxiliary;

		private readonly bool mOverridesImplicitlyEnabledSubtype;

		private readonly int mSubtypeHashCode;

		private readonly int mSubtypeIconResId;

		private readonly int mSubtypeNameResId;

		private readonly string mSubtypeLocale;

		private readonly string mSubtypeMode;

		private readonly string mSubtypeExtraValue;

		private java.util.HashMap<string, string> mExtraValueHashMapCache;

		[Sharpen.Stub]
		public InputMethodSubtype(int nameId, int iconId, string locale, string mode, string
			 extraValue, bool isAuxiliary_1) : this(nameId, iconId, locale, mode, extraValue
			, isAuxiliary_1, false)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public InputMethodSubtype(int nameId, int iconId, string locale, string mode, string
			 extraValue, bool isAuxiliary_1, bool overridesImplicitlyEnabledSubtype_1)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal InputMethodSubtype(android.os.Parcel source)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int getNameResId()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int getIconResId()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public string getLocale()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public string getMode()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public string getExtraValue()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool isAuxiliary()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool overridesImplicitlyEnabledSubtype()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public java.lang.CharSequence getDisplayName(android.content.Context context, string
			 packageName, android.content.pm.ApplicationInfo appInfo)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private java.util.HashMap<string, string> getExtraValueHashMap()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool containsExtraValueKey(string key)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public string getExtraValueOf(string key)
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
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override bool Equals(object o)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public int describeContents()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public void writeToParcel(android.os.Parcel dest, int parcelableFlags)
		{
			throw new System.NotImplementedException();
		}

		private sealed class _Creator_272 : android.os.ParcelableClass.Creator<android.view.inputmethod.InputMethodSubtype
			>
		{
			public _Creator_272()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.view.inputmethod.InputMethodSubtype createFromParcel(android.os.Parcel
				 source)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.view.inputmethod.InputMethodSubtype[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.view.inputmethod.InputMethodSubtype
			> CREATOR = new _Creator_272();

		[Sharpen.Stub]
		private static System.Globalization.CultureInfo constructLocaleFromString(string 
			localeStr)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static int hashCodeInternal(string locale, string mode, string extraValue
			, bool isAuxiliary_1, bool overridesImplicitlyEnabledSubtype_1)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.util.List<android.view.inputmethod.InputMethodSubtype> sort(android.content.Context
			 context, int flags, android.view.inputmethod.InputMethodInfo imi, java.util.List
			<android.view.inputmethod.InputMethodSubtype> subtypeList)
		{
			throw new System.NotImplementedException();
		}
	}
}

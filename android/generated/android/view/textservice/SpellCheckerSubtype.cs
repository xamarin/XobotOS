using Sharpen;

namespace android.view.textservice
{
	[Sharpen.Stub]
	public sealed class SpellCheckerSubtype : android.os.Parcelable
	{
		private readonly int mSubtypeHashCode;

		private readonly int mSubtypeNameResId;

		private readonly string mSubtypeLocale;

		private readonly string mSubtypeExtraValue;

		[Sharpen.Stub]
		public SpellCheckerSubtype(int nameId, string locale, string extraValue)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal SpellCheckerSubtype(android.os.Parcel source)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int getNameResId()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public string getLocale()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public string getExtraValue()
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
		private static System.Globalization.CultureInfo constructLocaleFromString(string 
			localeStr)
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

		private sealed class _Creator_158 : android.os.ParcelableClass.Creator<android.view.textservice.SpellCheckerSubtype
			>
		{
			public _Creator_158()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.view.textservice.SpellCheckerSubtype createFromParcel(android.os.Parcel
				 source)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.view.textservice.SpellCheckerSubtype[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.view.textservice.SpellCheckerSubtype
			> CREATOR = new _Creator_158();

		[Sharpen.Stub]
		private static int hashCodeInternal(string locale, string extraValue)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.util.List<android.view.textservice.SpellCheckerSubtype> sort(android.content.Context
			 context, int flags, android.view.textservice.SpellCheckerInfo sci, java.util.List
			<android.view.textservice.SpellCheckerSubtype> subtypeList)
		{
			throw new System.NotImplementedException();
		}
	}
}

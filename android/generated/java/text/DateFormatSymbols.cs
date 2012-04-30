using Sharpen;

namespace java.text
{
	[System.Serializable]
	[Sharpen.Stub]
	public class DateFormatSymbols : System.ICloneable
	{
		internal const long serialVersionUID = -5987973545549424702L;

		private string localPatternChars;

		internal string[] ampms;

		internal string[] eras;

		internal string[] months;

		internal string[] shortMonths;

		internal string[] shortWeekdays;

		internal string[] weekdays;

		[System.NonSerialized]
		internal string[] longStandAloneMonths;

		[System.NonSerialized]
		internal string[] shortStandAloneMonths;

		[System.NonSerialized]
		internal string[] longStandAloneWeekdays;

		[System.NonSerialized]
		internal string[] shortStandAloneWeekdays;

		internal string[][] zoneStrings;

		[System.NonSerialized]
		internal bool customZoneStrings;

		[System.NonSerialized]
		internal readonly System.Globalization.CultureInfo locale;

		[Sharpen.Stub]
		internal virtual string[][] internalZoneStrings()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public DateFormatSymbols() : this(System.Globalization.CultureInfo.CurrentCulture
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public DateFormatSymbols(System.Globalization.CultureInfo locale)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.text.DateFormatSymbols getInstance()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.text.DateFormatSymbols getInstance(System.Globalization.CultureInfo
			 locale)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static System.Globalization.CultureInfo[] getAvailableLocales()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void readObject(java.io.ObjectInputStream ois)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void writeObject(java.io.ObjectOutputStream oos)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual object clone()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override bool Equals(object @object)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static bool timeZoneStringsEqual(java.text.DateFormatSymbols lhs, java.text.DateFormatSymbols
			 rhs)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string[] getAmPmStrings()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string[] getEras()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string getLocalPatternChars()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string[] getMonths()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string[] getShortMonths()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string[] getShortWeekdays()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string[] getWeekdays()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string[][] getZoneStrings()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static string[][] clone2dStringArray(string[][] array)
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
		public virtual void setAmPmStrings(string[] data)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setEras(string[] data)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setLocalPatternChars(string data)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setMonths(string[] data)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setShortMonths(string[] data)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setShortWeekdays(string[] data)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setWeekdays(string[] data)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setZoneStrings(string[][] zoneStrings)
		{
			throw new System.NotImplementedException();
		}

		object System.ICloneable.Clone()
		{
			return MemberwiseClone();
		}
	}
}

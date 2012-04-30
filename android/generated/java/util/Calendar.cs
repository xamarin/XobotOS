using Sharpen;

namespace java.util
{
	[System.Serializable]
	[Sharpen.Stub]
	public abstract class Calendar : System.ICloneable, java.lang.Comparable<java.util.Calendar
		>
	{
		internal const long serialVersionUID = -1807547505821590642L;

		protected internal bool areFieldsSet;

		protected internal int[] fields;

		protected internal bool[] _isSet;

		protected internal bool isTimeSet;

		protected internal long time;

		[System.NonSerialized]
		internal int lastTimeFieldSet;

		[System.NonSerialized]
		internal int lastDateFieldSet;

		private bool lenient;

		private int firstDayOfWeek;

		private int minimalDaysInFirstWeek;

		private java.util.TimeZone zone;

		public const int JANUARY = 0;

		public const int FEBRUARY = 1;

		public const int MARCH = 2;

		public const int APRIL = 3;

		public const int MAY = 4;

		public const int JUNE = 5;

		public const int JULY = 6;

		public const int AUGUST = 7;

		public const int SEPTEMBER = 8;

		public const int OCTOBER = 9;

		public const int NOVEMBER = 10;

		public const int DECEMBER = 11;

		public const int UNDECIMBER = 12;

		public const int SUNDAY = 1;

		public const int MONDAY = 2;

		public const int TUESDAY = 3;

		public const int WEDNESDAY = 4;

		public const int THURSDAY = 5;

		public const int FRIDAY = 6;

		public const int SATURDAY = 7;

		public const int ERA = 0;

		public const int YEAR = 1;

		public const int MONTH = 2;

		public const int WEEK_OF_YEAR = 3;

		public const int WEEK_OF_MONTH = 4;

		public const int DATE = 5;

		public const int DAY_OF_MONTH = 5;

		public const int DAY_OF_YEAR = 6;

		public const int DAY_OF_WEEK = 7;

		public const int DAY_OF_WEEK_IN_MONTH = 8;

		public const int AM_PM = 9;

		public const int HOUR = 10;

		public const int HOUR_OF_DAY = 11;

		public const int MINUTE = 12;

		public const int SECOND = 13;

		public const int MILLISECOND = 14;

		public const int ZONE_OFFSET = 15;

		public const int DST_OFFSET = 16;

		public const int FIELD_COUNT = 17;

		public const int AM = 0;

		public const int PM = 1;

		public const int ALL_STYLES = 0;

		public const int SHORT = 1;

		public const int LONG = 2;

		private static readonly string[] FIELD_NAMES = new string[] { "ERA", "YEAR", "MONTH"
			, "WEEK_OF_YEAR", "WEEK_OF_MONTH", "DAY_OF_MONTH", "DAY_OF_YEAR", "DAY_OF_WEEK", 
			"DAY_OF_WEEK_IN_MONTH", "AM_PM", "HOUR", "HOUR_OF_DAY", "MINUTE", "SECOND", "MILLISECOND"
			, "ZONE_OFFSET", "DST_OFFSET" };

		[Sharpen.Stub]
		protected internal Calendar() : this(java.util.TimeZone.getDefault(), System.Globalization.CultureInfo.CurrentCulture
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal Calendar(java.util.TimeZone timezone)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal Calendar(java.util.TimeZone timezone, System.Globalization.CultureInfo
			 locale) : this(timezone)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public abstract void add(int field, int value);

		[Sharpen.Stub]
		public virtual bool after(object calendar)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool before(object calendar)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void clear()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void clear(int field)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual object clone()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual void complete()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal abstract void computeFields();

		[Sharpen.Stub]
		protected internal abstract void computeTime();

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override bool Equals(object @object)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int get(int field)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getActualMaximum(int field)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getActualMinimum(int field)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static System.Globalization.CultureInfo[] getAvailableLocales()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getFirstDayOfWeek()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public abstract int getGreatestMinimum(int field);

		[Sharpen.Stub]
		public static java.util.Calendar getInstance()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.util.Calendar getInstance(System.Globalization.CultureInfo locale
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.util.Calendar getInstance(java.util.TimeZone timezone)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.util.Calendar getInstance(java.util.TimeZone timezone, System.Globalization.CultureInfo
			 locale)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public abstract int getLeastMaximum(int field);

		[Sharpen.Stub]
		public abstract int getMaximum(int field);

		[Sharpen.Stub]
		public virtual int getMinimalDaysInFirstWeek()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public abstract int getMinimum(int field);

		[Sharpen.Stub]
		public System.DateTime getTime()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual long getTimeInMillis()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual java.util.TimeZone getTimeZone()
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
		protected internal int internalGet(int field)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isLenient()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool isSet(int field)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void roll(int field, int value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public abstract void roll(int field, bool increment);

		[Sharpen.Stub]
		public virtual void set(int field, int value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void set(int year, int month, int day)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void set(int year, int month, int day, int hourOfDay, int minute)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void set(int year, int month, int day, int hourOfDay, int minute, int second
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setFirstDayOfWeek(int value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setLenient(bool value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setMinimalDaysInFirstWeek(int value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void setTime(System.DateTime date)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setTimeInMillis(long milliseconds)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setTimeZone(java.util.TimeZone timezone)
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
		[Sharpen.ImplementsInterface(@"java.lang.Comparable")]
		public virtual int compareTo(java.util.Calendar anotherCalendar)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string getDisplayName(int field, int style, System.Globalization.CultureInfo
			 locale)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private string[] getDisplayNameArray(int field, int style, System.Globalization.CultureInfo
			 locale)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void checkStyle(int style)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual java.util.Map<string, int> getDisplayNames(int field, int style, System.Globalization.CultureInfo
			 locale)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void insertValuesInMap(java.util.Map<string, int> map, string[] values
			)
		{
			throw new System.NotImplementedException();
		}

		private static readonly java.io.ObjectStreamField[] serialPersistentFields = new 
			java.io.ObjectStreamField[] { new java.io.ObjectStreamField("areFieldsSet", typeof(
			bool)), new java.io.ObjectStreamField("fields", typeof(int[])), new java.io.ObjectStreamField
			("firstDayOfWeek", typeof(int)), new java.io.ObjectStreamField("isSet", typeof(bool
			[])), new java.io.ObjectStreamField("isTimeSet", typeof(bool)), new java.io.ObjectStreamField
			("lenient", typeof(bool)), new java.io.ObjectStreamField("minimalDaysInFirstWeek"
			, typeof(int)), new java.io.ObjectStreamField("nextStamp", typeof(int)), new java.io.ObjectStreamField
			("serialVersionOnStream", typeof(int)), new java.io.ObjectStreamField("time", typeof(
			long)), new java.io.ObjectStreamField("zone", typeof(java.util.TimeZone)) };

		[Sharpen.Stub]
		private void writeObject(java.io.ObjectOutputStream stream)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void readObject(java.io.ObjectInputStream stream)
		{
			throw new System.NotImplementedException();
		}

		object System.ICloneable.Clone()
		{
			return MemberwiseClone();
		}
	}
}

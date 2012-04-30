using Sharpen;

namespace android.text.format
{
	[Sharpen.Stub]
	public class Time
	{
		internal const string Y_M_D_T_H_M_S_000 = "%Y-%m-%dT%H:%M:%S.000";

		internal const string Y_M_D_T_H_M_S_000_Z = "%Y-%m-%dT%H:%M:%S.000Z";

		internal const string Y_M_D = "%Y-%m-%d";

		public const string TIMEZONE_UTC = "UTC";

		public const int EPOCH_JULIAN_DAY = 2440588;

		public const int MONDAY_BEFORE_JULIAN_EPOCH = EPOCH_JULIAN_DAY - 3;

		public bool allDay;

		public int second;

		public int minute;

		public int hour;

		public int monthDay;

		public int month;

		public int year;

		public int weekDay;

		public int yearDay;

		public int isDst;

		public long gmtoff;

		public string timezone;

		public const int SECOND = 1;

		public const int MINUTE = 2;

		public const int HOUR = 3;

		public const int MONTH_DAY = 4;

		public const int MONTH = 5;

		public const int YEAR = 6;

		public const int WEEK_DAY = 7;

		public const int YEAR_DAY = 8;

		public const int WEEK_NUM = 9;

		public const int SUNDAY = 0;

		public const int MONDAY = 1;

		public const int TUESDAY = 2;

		public const int WEDNESDAY = 3;

		public const int THURSDAY = 4;

		public const int FRIDAY = 5;

		public const int SATURDAY = 6;

		private static System.Globalization.CultureInfo sLocale;

		private static string[] sShortMonths;

		private static string[] sLongMonths;

		private static string[] sLongStandaloneMonths;

		private static string[] sShortWeekdays;

		private static string[] sLongWeekdays;

		private static string sTimeOnlyFormat;

		private static string sDateOnlyFormat;

		private static string sDateTimeFormat;

		private static string sAm;

		private static string sPm;

		private static string sDateCommand = "%a %b %e %H:%M:%S %Z %Y";

		[Sharpen.Stub]
		public Time(string timezone)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public Time() : this(java.util.TimeZone.getDefault().getID())
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public Time(android.text.format.Time other)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual long normalize(bool ignoreDst)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void switchTimezone(string timezone)
		{
			throw new System.NotImplementedException();
		}

		private static readonly int[] DAYS_PER_MONTH = new int[] { 31, 28, 31, 30, 31, 30
			, 31, 31, 30, 31, 30, 31 };

		[Sharpen.Stub]
		public virtual int getActualMaximum(int field)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void clear(string timezone)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int compare(android.text.format.Time a, android.text.format.Time b)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static int nativeCompare(android.text.format.Time a, android.text.format.Time
			 b)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string format(string format_1)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private string format1(string format_1)
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
		public virtual bool parse(string s)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private bool nativeParse(string s)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool parse3339(string s)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private bool nativeParse3339(string s)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static string getCurrentTimezone()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setToNow()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual long toMillis(bool ignoreDst)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void set(long millis)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string format2445()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void set(android.text.format.Time that)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void set(int second, int minute, int hour, int monthDay, int month
			, int year)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void set(int monthDay, int month, int year)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool before(android.text.format.Time that)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool after(android.text.format.Time that)
		{
			throw new System.NotImplementedException();
		}

		private static readonly int[] sThursdayOffset = new int[] { -3, 3, 2, 1, 0, -1, -
			2 };

		[Sharpen.Stub]
		public virtual int getWeekNumber()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string format3339(bool allDay)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static bool isEpoch(android.text.format.Time time)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int getJulianDay(long millis, long gmtoff)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual long setJulianDay(int julianDay)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int getWeeksSinceEpochFromJulianDay(int julianDay, int firstDayOfWeek
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int getJulianMondayFromWeeksSinceEpoch(int week)
		{
			throw new System.NotImplementedException();
		}
	}
}

using Sharpen;

namespace android.text.format
{
	[Sharpen.Stub]
	public class DateUtils
	{
		private static readonly object sLock = new object();

		private static readonly int[] sDaysLong = new int[] { android.@internal.R.@string
			.day_of_week_long_sunday, android.@internal.R.@string.day_of_week_long_monday, android.@internal.R
			.@string.day_of_week_long_tuesday, android.@internal.R.@string.day_of_week_long_wednesday
			, android.@internal.R.@string.day_of_week_long_thursday, android.@internal.R.@string
			.day_of_week_long_friday, android.@internal.R.@string.day_of_week_long_saturday };

		private static readonly int[] sDaysMedium = new int[] { android.@internal.R.@string
			.day_of_week_medium_sunday, android.@internal.R.@string.day_of_week_medium_monday
			, android.@internal.R.@string.day_of_week_medium_tuesday, android.@internal.R.@string
			.day_of_week_medium_wednesday, android.@internal.R.@string.day_of_week_medium_thursday
			, android.@internal.R.@string.day_of_week_medium_friday, android.@internal.R.@string
			.day_of_week_medium_saturday };

		private static readonly int[] sDaysShort = new int[] { android.@internal.R.@string
			.day_of_week_short_sunday, android.@internal.R.@string.day_of_week_short_monday, 
			android.@internal.R.@string.day_of_week_short_tuesday, android.@internal.R.@string
			.day_of_week_short_wednesday, android.@internal.R.@string.day_of_week_short_thursday
			, android.@internal.R.@string.day_of_week_short_friday, android.@internal.R.@string
			.day_of_week_short_saturday };

		private static readonly int[] sDaysShortest = new int[] { android.@internal.R.@string
			.day_of_week_shortest_sunday, android.@internal.R.@string.day_of_week_shortest_monday
			, android.@internal.R.@string.day_of_week_shortest_tuesday, android.@internal.R.
			@string.day_of_week_shortest_wednesday, android.@internal.R.@string.day_of_week_shortest_thursday
			, android.@internal.R.@string.day_of_week_shortest_friday, android.@internal.R.@string
			.day_of_week_shortest_saturday };

		private static readonly int[] sMonthsStandaloneLong = new int[] { android.@internal.R
			.@string.month_long_standalone_january, android.@internal.R.@string.month_long_standalone_february
			, android.@internal.R.@string.month_long_standalone_march, android.@internal.R.@string
			.month_long_standalone_april, android.@internal.R.@string.month_long_standalone_may
			, android.@internal.R.@string.month_long_standalone_june, android.@internal.R.@string
			.month_long_standalone_july, android.@internal.R.@string.month_long_standalone_august
			, android.@internal.R.@string.month_long_standalone_september, android.@internal.R
			.@string.month_long_standalone_october, android.@internal.R.@string.month_long_standalone_november
			, android.@internal.R.@string.month_long_standalone_december };

		private static readonly int[] sMonthsLong = new int[] { android.@internal.R.@string
			.month_long_january, android.@internal.R.@string.month_long_february, android.@internal.R
			.@string.month_long_march, android.@internal.R.@string.month_long_april, android.@internal.R
			.@string.month_long_may, android.@internal.R.@string.month_long_june, android.@internal.R
			.@string.month_long_july, android.@internal.R.@string.month_long_august, android.@internal.R
			.@string.month_long_september, android.@internal.R.@string.month_long_october, android.@internal.R
			.@string.month_long_november, android.@internal.R.@string.month_long_december };

		private static readonly int[] sMonthsMedium = new int[] { android.@internal.R.@string
			.month_medium_january, android.@internal.R.@string.month_medium_february, android.@internal.R
			.@string.month_medium_march, android.@internal.R.@string.month_medium_april, android.@internal.R
			.@string.month_medium_may, android.@internal.R.@string.month_medium_june, android.@internal.R
			.@string.month_medium_july, android.@internal.R.@string.month_medium_august, android.@internal.R
			.@string.month_medium_september, android.@internal.R.@string.month_medium_october
			, android.@internal.R.@string.month_medium_november, android.@internal.R.@string
			.month_medium_december };

		private static readonly int[] sMonthsShortest = new int[] { android.@internal.R.@string
			.month_shortest_january, android.@internal.R.@string.month_shortest_february, android.@internal.R
			.@string.month_shortest_march, android.@internal.R.@string.month_shortest_april, 
			android.@internal.R.@string.month_shortest_may, android.@internal.R.@string.month_shortest_june
			, android.@internal.R.@string.month_shortest_july, android.@internal.R.@string.month_shortest_august
			, android.@internal.R.@string.month_shortest_september, android.@internal.R.@string
			.month_shortest_october, android.@internal.R.@string.month_shortest_november, android.@internal.R
			.@string.month_shortest_december };

		private static readonly int[] sAmPm = new int[] { android.@internal.R.@string.am, 
			android.@internal.R.@string.pm };

		private static android.content.res.Configuration sLastConfig;

		private static java.text.DateFormat sStatusTimeFormat;

		private static string sElapsedFormatMMSS;

		private static string sElapsedFormatHMMSS;

		internal const string FAST_FORMAT_HMMSS = "%1$d:%2$02d:%3$02d";

		internal const string FAST_FORMAT_MMSS = "%1$02d:%2$02d";

		internal const char TIME_PADDING = '0';

		internal const char TIME_SEPARATOR = ':';

		public const long SECOND_IN_MILLIS = 1000;

		public const long MINUTE_IN_MILLIS = SECOND_IN_MILLIS * 60;

		public const long HOUR_IN_MILLIS = MINUTE_IN_MILLIS * 60;

		public const long DAY_IN_MILLIS = HOUR_IN_MILLIS * 24;

		public const long WEEK_IN_MILLIS = DAY_IN_MILLIS * 7;

		public const long YEAR_IN_MILLIS = WEEK_IN_MILLIS * 52;

		public const int FORMAT_SHOW_TIME = unchecked((int)(0x00001));

		public const int FORMAT_SHOW_WEEKDAY = unchecked((int)(0x00002));

		public const int FORMAT_SHOW_YEAR = unchecked((int)(0x00004));

		public const int FORMAT_NO_YEAR = unchecked((int)(0x00008));

		public const int FORMAT_SHOW_DATE = unchecked((int)(0x00010));

		public const int FORMAT_NO_MONTH_DAY = unchecked((int)(0x00020));

		public const int FORMAT_12HOUR = unchecked((int)(0x00040));

		public const int FORMAT_24HOUR = unchecked((int)(0x00080));

		public const int FORMAT_CAP_AMPM = unchecked((int)(0x00100));

		public const int FORMAT_NO_NOON = unchecked((int)(0x00200));

		public const int FORMAT_CAP_NOON = unchecked((int)(0x00400));

		public const int FORMAT_NO_MIDNIGHT = unchecked((int)(0x00800));

		public const int FORMAT_CAP_MIDNIGHT = unchecked((int)(0x01000));

		[System.ObsoleteAttribute(@"UseformatDateRange(android.content.Context, java.util.Formatter, long, long, int, string) formatDateRange and pass in Time.TIMEZONE_UTC Time.TIMEZONE_UTC for the timeZone instead."
			)]
		public const int FORMAT_UTC = unchecked((int)(0x02000));

		public const int FORMAT_ABBREV_TIME = unchecked((int)(0x04000));

		public const int FORMAT_ABBREV_WEEKDAY = unchecked((int)(0x08000));

		public const int FORMAT_ABBREV_MONTH = unchecked((int)(0x10000));

		public const int FORMAT_NUMERIC_DATE = unchecked((int)(0x20000));

		public const int FORMAT_ABBREV_RELATIVE = unchecked((int)(0x40000));

		public const int FORMAT_ABBREV_ALL = unchecked((int)(0x80000));

		public const int FORMAT_CAP_NOON_MIDNIGHT = (FORMAT_CAP_NOON | FORMAT_CAP_MIDNIGHT
			);

		public const int FORMAT_NO_NOON_MIDNIGHT = (FORMAT_NO_NOON | FORMAT_NO_MIDNIGHT);

		public const string HOUR_MINUTE_24 = "%H:%M";

		public const string MONTH_FORMAT = "%B";

		public const string ABBREV_MONTH_FORMAT = "%b";

		public const string NUMERIC_MONTH_FORMAT = "%m";

		public const string MONTH_DAY_FORMAT = "%-d";

		public const string YEAR_FORMAT = "%Y";

		public const string YEAR_FORMAT_TWO_DIGITS = "%g";

		public const string WEEKDAY_FORMAT = "%A";

		public const string ABBREV_WEEKDAY_FORMAT = "%a";

		public static readonly int[] sameYearTable = new int[] { android.@internal.R.@string
			.same_year_md1_md2, android.@internal.R.@string.same_year_wday1_md1_wday2_md2, android.@internal.R
			.@string.same_year_mdy1_mdy2, android.@internal.R.@string.same_year_wday1_mdy1_wday2_mdy2
			, android.@internal.R.@string.same_year_md1_time1_md2_time2, android.@internal.R
			.@string.same_year_wday1_md1_time1_wday2_md2_time2, android.@internal.R.@string.
			same_year_mdy1_time1_mdy2_time2, android.@internal.R.@string.same_year_wday1_mdy1_time1_wday2_mdy2_time2
			, android.@internal.R.@string.numeric_md1_md2, android.@internal.R.@string.numeric_wday1_md1_wday2_md2
			, android.@internal.R.@string.numeric_mdy1_mdy2, android.@internal.R.@string.numeric_wday1_mdy1_wday2_mdy2
			, android.@internal.R.@string.numeric_md1_time1_md2_time2, android.@internal.R.@string
			.numeric_wday1_md1_time1_wday2_md2_time2, android.@internal.R.@string.numeric_mdy1_time1_mdy2_time2
			, android.@internal.R.@string.numeric_wday1_mdy1_time1_wday2_mdy2_time2 };

		public static readonly int[] sameMonthTable = new int[] { android.@internal.R.@string
			.same_month_md1_md2, android.@internal.R.@string.same_month_wday1_md1_wday2_md2, 
			android.@internal.R.@string.same_month_mdy1_mdy2, android.@internal.R.@string.same_month_wday1_mdy1_wday2_mdy2
			, android.@internal.R.@string.same_month_md1_time1_md2_time2, android.@internal.R
			.@string.same_month_wday1_md1_time1_wday2_md2_time2, android.@internal.R.@string
			.same_month_mdy1_time1_mdy2_time2, android.@internal.R.@string.same_month_wday1_mdy1_time1_wday2_mdy2_time2
			, android.@internal.R.@string.numeric_md1_md2, android.@internal.R.@string.numeric_wday1_md1_wday2_md2
			, android.@internal.R.@string.numeric_mdy1_mdy2, android.@internal.R.@string.numeric_wday1_mdy1_wday2_mdy2
			, android.@internal.R.@string.numeric_md1_time1_md2_time2, android.@internal.R.@string
			.numeric_wday1_md1_time1_wday2_md2_time2, android.@internal.R.@string.numeric_mdy1_time1_mdy2_time2
			, android.@internal.R.@string.numeric_wday1_mdy1_time1_wday2_mdy2_time2 };

		public const int LENGTH_LONG = 10;

		public const int LENGTH_MEDIUM = 20;

		public const int LENGTH_SHORT = 30;

		public const int LENGTH_SHORTER = 40;

		public const int LENGTH_SHORTEST = 50;

		[Sharpen.Stub]
		public static string getDayOfWeekString(int dayOfWeek, int abbrev)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static string getAMPMString(int ampm)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static string getMonthString(int month, int abbrev)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static string getStandaloneMonthString(int month, int abbrev)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.lang.CharSequence getRelativeTimeSpanString(long startTime)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.lang.CharSequence getRelativeTimeSpanString(long time, long now
			, long minResolution)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.lang.CharSequence getRelativeTimeSpanString(long time, long now
			, long minResolution, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static long getNumberOfDaysPassed(long date1, long date2)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.lang.CharSequence getRelativeDateTimeString(android.content.Context
			 c, long time, long minResolution, long transitionResolution, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static string getRelativeDayString(android.content.res.Resources r, long 
			day, long today)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void initFormatStrings()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void initFormatStringsLocked()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"use #getTimeFormat(Context) instead.")]
		public static java.lang.CharSequence timeString(long millis)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static string formatElapsedTime(long elapsedSeconds)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static string formatElapsedTime(java.lang.StringBuilder recycle, long elapsedSeconds
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static string formatElapsedTime(java.lang.StringBuilder recycle, string format
			, long hours, long minutes, long seconds)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static string formatElapsedTime(java.lang.StringBuilder recycle, string format
			, long minutes, long seconds)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static char toDigitChar(long digit)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.lang.CharSequence formatSameDayTime(long then, long now, int dateStyle
			, int timeStyle)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"use Time")]
		public static java.util.Calendar newCalendar(bool zulu)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static bool isToday(long when)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"use Time Return true if this date string is local time"
			)]
		public static bool isUTC(string s)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"use Time")]
		public static string writeDateTime(java.util.Calendar cal)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"use Time")]
		public static string writeDateTime(java.util.Calendar cal, bool zulu)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"use Time")]
		public static string writeDateTime(java.util.Calendar cal, java.lang.StringBuilder
			 sb)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"use Time")]
		public static void assign(java.util.Calendar lval, java.util.Calendar rval)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static string formatDateRange(android.content.Context context, long startMillis
			, long endMillis, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.util.Formatter formatDateRange(android.content.Context context
			, java.util.Formatter formatter, long startMillis, long endMillis, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.util.Formatter formatDateRange(android.content.Context context
			, java.util.Formatter formatter, long startMillis, long endMillis, int flags, string
			 timeZone)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static string formatDateTime(android.content.Context context, long millis, 
			int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.lang.CharSequence getRelativeTimeSpanString(android.content.Context
			 c, long millis, bool withPreposition)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.lang.CharSequence getRelativeTimeSpanString(android.content.Context
			 c, long millis)
		{
			throw new System.NotImplementedException();
		}

		private static android.text.format.Time sNowTime;

		private static android.text.format.Time sThenTime;
	}
}

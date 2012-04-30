using Sharpen;

namespace android.text.format
{
	[Sharpen.Stub]
	public class DateFormat
	{
		public const char QUOTE = '\'';

		public const char AM_PM = 'a';

		public const char CAPITAL_AM_PM = 'A';

		public const char DATE = 'd';

		public const char DAY = 'E';

		public const char HOUR = 'h';

		public const char HOUR_OF_DAY = 'k';

		public const char MINUTE = 'm';

		public const char MONTH = 'M';

		public const char SECONDS = 's';

		public const char TIME_ZONE = 'z';

		public const char YEAR = 'y';

		private static readonly object sLocaleLock = new object();

		private static System.Globalization.CultureInfo sIs24HourLocale;

		private static bool sIs24Hour;

		[Sharpen.Stub]
		public static bool is24HourFormat(android.content.Context context)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.text.DateFormat getTimeFormat(android.content.Context context)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.text.DateFormat getDateFormat(android.content.Context context)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.text.DateFormat getDateFormatForSetting(android.content.Context
			 context, string value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static string getDateFormatStringForSetting(android.content.Context context
			, string value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.text.DateFormat getLongDateFormat(android.content.Context context
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.text.DateFormat getMediumDateFormat(android.content.Context context
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static char[] getDateFormatOrder(android.content.Context context)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static string getDateFormatString(android.content.Context context)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.lang.CharSequence format(java.lang.CharSequence inFormat, long
			 inTimeInMillis)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.lang.CharSequence format(java.lang.CharSequence inFormat, System.DateTime
			 inDate)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.lang.CharSequence format(java.lang.CharSequence inFormat, java.util.Calendar
			 inDate)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static string getMonthString(java.util.Calendar inDate, int count)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static string getTimeZoneString(java.util.Calendar inDate, int count)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static string formatZoneOffset(int offset, int count)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static string getYearString(java.util.Calendar inDate, int count)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static int appendQuotedText(android.text.SpannableStringBuilder s, int i, 
			int len)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static string zeroPad(int inValue, int inMinDigits)
		{
			throw new System.NotImplementedException();
		}
	}
}

using Sharpen;

namespace java.text
{
	[System.Serializable]
	[Sharpen.Stub]
	public abstract class DateFormat : java.text.Format
	{
		internal const long serialVersionUID = 7218322306649953788L;

		protected internal java.util.Calendar calendar;

		protected internal java.text.NumberFormat numberFormat;

		public const int DEFAULT = 2;

		public const int FULL = 0;

		public const int LONG = 1;

		public const int MEDIUM = 2;

		public const int SHORT = 3;

		public const int ERA_FIELD = 0;

		public const int YEAR_FIELD = 1;

		public const int MONTH_FIELD = 2;

		public const int DATE_FIELD = 3;

		public const int HOUR_OF_DAY1_FIELD = 4;

		public const int HOUR_OF_DAY0_FIELD = 5;

		public const int MINUTE_FIELD = 6;

		public const int SECOND_FIELD = 7;

		public const int MILLISECOND_FIELD = 8;

		public const int DAY_OF_WEEK_FIELD = 9;

		public const int DAY_OF_YEAR_FIELD = 10;

		public const int DAY_OF_WEEK_IN_MONTH_FIELD = 11;

		public const int WEEK_OF_YEAR_FIELD = 12;

		public const int WEEK_OF_MONTH_FIELD = 13;

		public const int AM_PM_FIELD = 14;

		public const int HOUR1_FIELD = 15;

		public const int HOUR0_FIELD = 16;

		public const int TIMEZONE_FIELD = 17;

		[Sharpen.Stub]
		protected internal DateFormat()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.text.Format")]
		public override object clone()
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
		[Sharpen.OverridesMethod(@"java.text.Format")]
		public sealed override java.lang.StringBuffer format(object @object, java.lang.StringBuffer
			 buffer, java.text.FieldPosition field)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public string format(System.DateTime date)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public abstract java.lang.StringBuffer format(System.DateTime date, java.lang.StringBuffer
			 buffer, java.text.FieldPosition field);

		[Sharpen.Stub]
		public static System.Globalization.CultureInfo[] getAvailableLocales()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual java.util.Calendar getCalendar()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.text.DateFormat getDateInstance()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.text.DateFormat getDateInstance(int style)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.text.DateFormat getDateInstance(int style, System.Globalization.CultureInfo
			 locale)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.text.DateFormat getDateTimeInstance()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.text.DateFormat getDateTimeInstance(int dateStyle, int timeStyle
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.text.DateFormat getDateTimeInstance(int dateStyle, int timeStyle
			, System.Globalization.CultureInfo locale)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.text.DateFormat getInstance()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual java.text.NumberFormat getNumberFormat()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.text.DateFormat getTimeInstance()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.text.DateFormat getTimeInstance(int style)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.text.DateFormat getTimeInstance(int style, System.Globalization.CultureInfo
			 locale)
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
		public virtual bool isLenient()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual System.DateTime parse(string @string)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public abstract System.DateTime parse(string @string, java.text.ParsePosition position
			);

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.text.Format")]
		public override object parseObject(string @string, java.text.ParsePosition position
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setCalendar(java.util.Calendar cal)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setLenient(bool value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setNumberFormat(java.text.NumberFormat format_1)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setTimeZone(java.util.TimeZone timezone)
		{
			throw new System.NotImplementedException();
		}

		[System.Serializable]
		[Sharpen.Stub]
		public class Field : java.text.Format.Field
		{
			internal const long serialVersionUID = 7441350119349544720L;

			private static java.util.Hashtable<int, java.text.DateFormat.Field> table = new java.util.Hashtable
				<int, java.text.DateFormat.Field>();

			public static readonly java.text.DateFormat.Field ERA = new java.text.DateFormat.
				Field("era", java.util.Calendar.ERA);

			public static readonly java.text.DateFormat.Field YEAR = new java.text.DateFormat
				.Field("year", java.util.Calendar.YEAR);

			public static readonly java.text.DateFormat.Field MONTH = new java.text.DateFormat
				.Field("month", java.util.Calendar.MONTH);

			public static readonly java.text.DateFormat.Field HOUR_OF_DAY0 = new java.text.DateFormat
				.Field("hour of day", java.util.Calendar.HOUR_OF_DAY);

			public static readonly java.text.DateFormat.Field HOUR_OF_DAY1 = new java.text.DateFormat
				.Field("hour of day 1", -1);

			public static readonly java.text.DateFormat.Field MINUTE = new java.text.DateFormat
				.Field("minute", java.util.Calendar.MINUTE);

			public static readonly java.text.DateFormat.Field SECOND = new java.text.DateFormat
				.Field("second", java.util.Calendar.SECOND);

			public static readonly java.text.DateFormat.Field MILLISECOND = new java.text.DateFormat
				.Field("millisecond", java.util.Calendar.MILLISECOND);

			public static readonly java.text.DateFormat.Field DAY_OF_WEEK = new java.text.DateFormat
				.Field("day of week", java.util.Calendar.DAY_OF_WEEK);

			public static readonly java.text.DateFormat.Field DAY_OF_MONTH = new java.text.DateFormat
				.Field("day of month", java.util.Calendar.DAY_OF_MONTH);

			public static readonly java.text.DateFormat.Field DAY_OF_YEAR = new java.text.DateFormat
				.Field("day of year", java.util.Calendar.DAY_OF_YEAR);

			public static readonly java.text.DateFormat.Field DAY_OF_WEEK_IN_MONTH = new java.text.DateFormat
				.Field("day of week in month", java.util.Calendar.DAY_OF_WEEK_IN_MONTH);

			public static readonly java.text.DateFormat.Field WEEK_OF_YEAR = new java.text.DateFormat
				.Field("week of year", java.util.Calendar.WEEK_OF_YEAR);

			public static readonly java.text.DateFormat.Field WEEK_OF_MONTH = new java.text.DateFormat
				.Field("week of month", java.util.Calendar.WEEK_OF_MONTH);

			public static readonly java.text.DateFormat.Field AM_PM = new java.text.DateFormat
				.Field("am pm", java.util.Calendar.AM_PM);

			public static readonly java.text.DateFormat.Field HOUR0 = new java.text.DateFormat
				.Field("hour", java.util.Calendar.HOUR);

			public static readonly java.text.DateFormat.Field HOUR1 = new java.text.DateFormat
				.Field("hour 1", -1);

			public static readonly java.text.DateFormat.Field TIME_ZONE = new java.text.DateFormat
				.Field("time zone", -1);

			private int calendarField = -1;

			[Sharpen.Stub]
			protected internal Field(string fieldName, int calendarField) : base(fieldName)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual int getCalendarField()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static java.text.DateFormat.Field ofCalendarField(int calendarField)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		private static void checkDateStyle(int style)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void checkTimeStyle(int style)
		{
			throw new System.NotImplementedException();
		}
	}
}

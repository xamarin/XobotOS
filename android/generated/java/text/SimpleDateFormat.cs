using Sharpen;

namespace java.text
{
	[System.Serializable]
	[Sharpen.Stub]
	public class SimpleDateFormat : java.text.DateFormat
	{
		internal const long serialVersionUID = 4774881970558875024L;

		internal const string PATTERN_CHARS = "GyMdkHmsSEDFwWahKzZLc";

		internal const int RFC_822_TIMEZONE_FIELD = 18;

		internal const int STAND_ALONE_MONTH_FIELD = 19;

		internal const int STAND_ALONE_DAY_OF_WEEK_FIELD = 20;

		private string pattern;

		private java.text.DateFormatSymbols formatData;

		[System.NonSerialized]
		private int creationYear;

		private System.DateTime defaultCenturyStart;

		[Sharpen.Stub]
		public SimpleDateFormat() : this(System.Globalization.CultureInfo.CurrentCulture)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public SimpleDateFormat(string pattern) : this(pattern, System.Globalization.CultureInfo.CurrentCulture
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void validateFormat(char format_1)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void validatePattern(string template)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public SimpleDateFormat(string template, java.text.DateFormatSymbols value) : this
			(System.Globalization.CultureInfo.CurrentCulture)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public SimpleDateFormat(string template, System.Globalization.CultureInfo locale)
			 : this(locale)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private SimpleDateFormat(System.Globalization.CultureInfo locale)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void applyLocalizedPattern(string template)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void applyPattern(string template)
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
		private static string defaultPattern()
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
		public override java.text.AttributedCharacterIterator formatToCharacterIterator(object
			 @object)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private java.text.AttributedCharacterIterator formatToCharacterIteratorImpl(System.DateTime
			 date)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private java.lang.StringBuffer formatImpl(System.DateTime date, java.lang.StringBuffer
			 buffer, java.text.FieldPosition field, java.util.List<java.text.FieldPosition> 
			fields)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void append(java.lang.StringBuffer buffer, java.text.FieldPosition position
			, java.util.List<java.text.FieldPosition> fields, char format_1, int count)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void appendDayOfWeek(java.lang.StringBuffer buffer, int count, string[] longs
			, string[] shorts)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void appendMonth(java.lang.StringBuffer buffer, int count, string[] longs
			, string[] shorts)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void appendTimeZone(java.lang.StringBuffer buffer, int count, bool generalTimeZone
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void appendNumericTimeZone(java.lang.StringBuffer buffer, bool generalTimeZone
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void appendNumber(java.lang.StringBuffer buffer, int count, int value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private System.DateTime error(java.text.ParsePosition position, int offset, java.util.TimeZone
			 zone)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.text.DateFormat")]
		public override java.lang.StringBuffer format(System.DateTime date, java.lang.StringBuffer
			 buffer, java.text.FieldPosition fieldPos)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual System.DateTime get2DigitYearStart()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual java.text.DateFormatSymbols getDateFormatSymbols()
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
		private int parse(string @string, int offset, char format_1, int count)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private int parseDayOfWeek(string @string, int offset, string[] longs, string[] shorts
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private int parseMonth(string @string, int offset, int count, int absolute, string
			[] longs, string[] shorts)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.text.DateFormat")]
		public override System.DateTime parse(string @string, java.text.ParsePosition position
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private int parseNumber(int max, string @string, int offset, int field, int skew)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private int parseText(string @string, int offset, string[] text, int field)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private int parseTimeZone(string @string, int offset)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void set2DigitYearStart(System.DateTime date)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setDateFormatSymbols(java.text.DateFormatSymbols value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string toLocalizedPattern()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static string convertPattern(string template, string fromChars, string toChars
			, bool check)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string toPattern()
		{
			throw new System.NotImplementedException();
		}

		private static readonly java.io.ObjectStreamField[] serialPersistentFields = new 
			java.io.ObjectStreamField[] { new java.io.ObjectStreamField("defaultCenturyStart"
			, typeof(System.DateTime)), new java.io.ObjectStreamField("formatData", typeof(java.text.DateFormatSymbols
			)), new java.io.ObjectStreamField("pattern", typeof(string)), new java.io.ObjectStreamField
			("serialVersionOnStream", typeof(int)) };

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
	}
}

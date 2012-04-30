using Sharpen;

namespace java.util
{
	[System.Serializable]
	[Sharpen.Stub]
	public abstract class TimeZone : System.ICloneable
	{
		internal const long serialVersionUID = 3581463369166924961L;

		public const int SHORT = 0;

		public const int LONG = 1;

		internal static readonly java.util.TimeZone GMT = new java.util.SimpleTimeZone(0, 
			"GMT");

		private static java.util.TimeZone defaultTimeZone;

		private string ID;

		[Sharpen.Stub]
		public TimeZone()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual object clone()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static string[] getAvailableIDs()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static string[] getAvailableIDs(int offsetMillis)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.util.TimeZone getDefault()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public string getDisplayName()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public string getDisplayName(System.Globalization.CultureInfo locale)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public string getDisplayName(bool daylightTime, int style)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string getDisplayName(bool daylightTime, int style, System.Globalization.CultureInfo
			 locale)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void appendNumber(java.lang.StringBuilder builder, int count, int value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string getID()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getDSTSavings()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getOffset(long time)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public abstract int getOffset(int era, int year, int month, int day, int dayOfWeek
			, int timeOfDayMillis);

		[Sharpen.Stub]
		public abstract int getRawOffset();

		[Sharpen.Stub]
		public static java.util.TimeZone getTimeZone(string id)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static java.util.TimeZone getCustomTimeZone(string id)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static string formatTimeZoneName(string name, int offset)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool hasSameRules(java.util.TimeZone timeZone)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public abstract bool inDaylightTime(System.DateTime time);

		[Sharpen.Stub]
		private static int parseNumber(string @string, int offset, int[] position)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void setDefault(java.util.TimeZone timeZone)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setID(string id)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public abstract void setRawOffset(int offsetMillis);

		[Sharpen.Stub]
		public abstract bool useDaylightTime();

		object System.ICloneable.Clone()
		{
			return MemberwiseClone();
		}
	}
}

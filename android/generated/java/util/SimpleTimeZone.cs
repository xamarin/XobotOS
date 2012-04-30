using Sharpen;

namespace java.util
{
	[System.Serializable]
	[Sharpen.Stub]
	public class SimpleTimeZone : java.util.TimeZone
	{
		internal const long serialVersionUID = -403250971215465050L;

		private int rawOffset;

		private int startYear;

		private int startMonth;

		private int startDay;

		private int startDayOfWeek;

		private int startTime;

		private int endMonth;

		private int endDay;

		private int endDayOfWeek;

		private int endTime;

		private int startMode;

		private int endMode;

		internal const int DOM_MODE = 1;

		internal const int DOW_IN_MONTH_MODE = 2;

		internal const int DOW_GE_DOM_MODE = 3;

		internal const int DOW_LE_DOM_MODE = 4;

		public const int UTC_TIME = 2;

		public const int STANDARD_TIME = 1;

		public const int WALL_TIME = 0;

		private bool useDaylight;

		private int dstSavings = 3600000;

		[Sharpen.Stub]
		public SimpleTimeZone(int offset, string name)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public SimpleTimeZone(int offset, string name, int startMonth, int startDay, int 
			startDayOfWeek, int startTime, int endMonth, int endDay, int endDayOfWeek, int endTime
			) : this(offset, name, startMonth, startDay, startDayOfWeek, startTime, endMonth
			, endDay, endDayOfWeek, endTime, 3600000)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public SimpleTimeZone(int offset, string name, int startMonth, int startDay, int 
			startDayOfWeek, int startTime, int endMonth, int endDay, int endDayOfWeek, int endTime
			, int daylightSavings) : this(offset, name)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public SimpleTimeZone(int offset, string name, int startMonth, int startDay, int 
			startDayOfWeek, int startTime, int startTimeMode, int endMonth, int endDay, int 
			endDayOfWeek, int endTime, int endTimeMode, int daylightSavings) : this(offset, 
			name, startMonth, startDay, startDayOfWeek, startTime, endMonth, endDay, endDayOfWeek
			, endTime, daylightSavings)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.util.TimeZone")]
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
		[Sharpen.OverridesMethod(@"java.util.TimeZone")]
		public override int getDSTSavings()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.util.TimeZone")]
		public override int getOffset(int era, int year, int month, int day, int dayOfWeek
			, int time)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.util.TimeZone")]
		public override int getOffset(long time)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.util.TimeZone")]
		public override int getRawOffset()
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
		[Sharpen.OverridesMethod(@"java.util.TimeZone")]
		public override bool hasSameRules(java.util.TimeZone zone)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.util.TimeZone")]
		public override bool inDaylightTime(System.DateTime time)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private bool isLeapYear(int year)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private int mod7(int num1)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setDSTSavings(int milliseconds)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void checkRange(int month, int dayOfWeek, int time)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void checkDay(int month, int day)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void setEndMode()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setEndRule(int month, int dayOfMonth, int time)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setEndRule(int month, int day, int dayOfWeek, int time)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setEndRule(int month, int day, int dayOfWeek, int time, bool 
			after)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.util.TimeZone")]
		public override void setRawOffset(int offset)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void setStartMode()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setStartRule(int month, int dayOfMonth, int time)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setStartRule(int month, int day, int dayOfWeek, int time)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setStartRule(int month, int day, int dayOfWeek, int time, bool
			 after)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setStartYear(int year)
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
		[Sharpen.OverridesMethod(@"java.util.TimeZone")]
		public override bool useDaylightTime()
		{
			throw new System.NotImplementedException();
		}

		private static readonly java.io.ObjectStreamField[] serialPersistentFields = new 
			java.io.ObjectStreamField[] { new java.io.ObjectStreamField("dstSavings", typeof(
			int)), new java.io.ObjectStreamField("endDay", typeof(int)), new java.io.ObjectStreamField
			("endDayOfWeek", typeof(int)), new java.io.ObjectStreamField("endMode", typeof(int
			)), new java.io.ObjectStreamField("endMonth", typeof(int)), new java.io.ObjectStreamField
			("endTime", typeof(int)), new java.io.ObjectStreamField("monthLength", typeof(byte
			[])), new java.io.ObjectStreamField("rawOffset", typeof(int)), new java.io.ObjectStreamField
			("serialVersionOnStream", typeof(int)), new java.io.ObjectStreamField("startDay"
			, typeof(int)), new java.io.ObjectStreamField("startDayOfWeek", typeof(int)), new 
			java.io.ObjectStreamField("startMode", typeof(int)), new java.io.ObjectStreamField
			("startMonth", typeof(int)), new java.io.ObjectStreamField("startTime", typeof(int
			)), new java.io.ObjectStreamField("startYear", typeof(int)), new java.io.ObjectStreamField
			("useDaylight", typeof(bool)) };

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

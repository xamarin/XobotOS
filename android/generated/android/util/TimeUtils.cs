using Sharpen;

namespace android.util
{
	/// <summary>A class containing utility methods related to time zones.</summary>
	/// <remarks>A class containing utility methods related to time zones.</remarks>
	[Sharpen.Sharpened]
	public class TimeUtils
	{
		/// <hide></hide>
		public TimeUtils()
		{
		}

		internal const string TAG = "TimeUtils";

		[Sharpen.Stub]
		public static java.util.TimeZone getTimeZone(int offset, bool dst, long when, string
			 country)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static string getTimeZoneDatabaseVersion()
		{
			throw new System.NotImplementedException();
		}

		/// <hide>Field length that can hold 999 days of time</hide>
		public const int HUNDRED_DAY_FIELD_LEN = 19;

		internal const int SECONDS_PER_MINUTE = 60;

		internal const int SECONDS_PER_HOUR = 60 * 60;

		internal const int SECONDS_PER_DAY = 24 * 60 * 60;

		private static readonly object sFormatSync = new object();

		private static char[] sFormatStr = new char[HUNDRED_DAY_FIELD_LEN + 5];

		// If the current time zone is from the right country
		// and meets the other known properties, keep it
		// instead of changing to another one.
		// Otherwise, take the first zone from the right
		// country that has the correct current offset and DST.
		// (Keep iterating instead of returning in case we
		// haven't encountered the current time zone yet.)
		private static int accumField(int amt, int suffix, bool always, int zeropad)
		{
			if (amt > 99 || (always && zeropad >= 3))
			{
				return 3 + suffix;
			}
			if (amt > 9 || (always && zeropad >= 2))
			{
				return 2 + suffix;
			}
			if (always || amt > 0)
			{
				return 1 + suffix;
			}
			return 0;
		}

		private static int printField(char[] formatStr, int amt, char suffix, int pos, bool
			 always, int zeropad)
		{
			if (always || amt > 0)
			{
				int startPos = pos;
				if ((always && zeropad >= 3) || amt > 99)
				{
					int dig = amt / 100;
					formatStr[pos] = (char)(dig + '0');
					pos++;
					amt -= (dig * 100);
				}
				if ((always && zeropad >= 2) || amt > 9 || startPos != pos)
				{
					int dig = amt / 10;
					formatStr[pos] = (char)(dig + '0');
					pos++;
					amt -= (dig * 10);
				}
				formatStr[pos] = (char)(amt + '0');
				pos++;
				formatStr[pos] = suffix;
				pos++;
			}
			return pos;
		}

		private static int formatDurationLocked(long duration, int fieldLen)
		{
			if (sFormatStr.Length < fieldLen)
			{
				sFormatStr = new char[fieldLen];
			}
			char[] formatStr = sFormatStr;
			if (duration == 0)
			{
				int pos = 0;
				fieldLen -= 1;
				while (pos < fieldLen)
				{
					formatStr[pos++] = ' ';
				}
				formatStr[pos] = '0';
				return pos + 1;
			}
			char prefix;
			if (duration > 0)
			{
				prefix = '+';
			}
			else
			{
				prefix = '-';
				duration = -duration;
			}
			int millis = (int)(duration % 1000);
			int seconds = (int)Sharpen.Util.Floor(duration / 1000);
			int days = 0;
			int hours = 0;
			int minutes = 0;
			if (seconds > SECONDS_PER_DAY)
			{
				days = seconds / SECONDS_PER_DAY;
				seconds -= days * SECONDS_PER_DAY;
			}
			if (seconds > SECONDS_PER_HOUR)
			{
				hours = seconds / SECONDS_PER_HOUR;
				seconds -= hours * SECONDS_PER_HOUR;
			}
			if (seconds > SECONDS_PER_MINUTE)
			{
				minutes = seconds / SECONDS_PER_MINUTE;
				seconds -= minutes * SECONDS_PER_MINUTE;
			}
			int pos_1 = 0;
			if (fieldLen != 0)
			{
				int myLen = accumField(days, 1, false, 0);
				myLen += accumField(hours, 1, myLen > 0, 2);
				myLen += accumField(minutes, 1, myLen > 0, 2);
				myLen += accumField(seconds, 1, myLen > 0, 2);
				myLen += accumField(millis, 2, true, myLen > 0 ? 3 : 0) + 1;
				while (myLen < fieldLen)
				{
					formatStr[pos_1] = ' ';
					pos_1++;
					myLen++;
				}
			}
			formatStr[pos_1] = prefix;
			pos_1++;
			int start = pos_1;
			bool zeropad = fieldLen != 0;
			pos_1 = printField(formatStr, days, 'd', pos_1, false, 0);
			pos_1 = printField(formatStr, hours, 'h', pos_1, pos_1 != start, zeropad ? 2 : 0);
			pos_1 = printField(formatStr, minutes, 'm', pos_1, pos_1 != start, zeropad ? 2 : 
				0);
			pos_1 = printField(formatStr, seconds, 's', pos_1, pos_1 != start, zeropad ? 2 : 
				0);
			pos_1 = printField(formatStr, millis, 'm', pos_1, true, (zeropad && pos_1 != start
				) ? 3 : 0);
			formatStr[pos_1] = 's';
			return pos_1 + 1;
		}

		/// <hide>Just for debugging; not internationalized.</hide>
		public static void formatDuration(long duration, java.lang.StringBuilder builder)
		{
			lock (sFormatSync)
			{
				int len = formatDurationLocked(duration, 0);
				builder.append(sFormatStr, 0, len);
			}
		}

		/// <hide>Just for debugging; not internationalized.</hide>
		public static void formatDuration(long duration, java.io.PrintWriter pw, int fieldLen
			)
		{
			lock (sFormatSync)
			{
				int len = formatDurationLocked(duration, fieldLen);
				pw.print(new string(sFormatStr, 0, len));
			}
		}

		/// <hide>Just for debugging; not internationalized.</hide>
		public static void formatDuration(long duration, java.io.PrintWriter pw)
		{
			formatDuration(duration, pw, 0);
		}

		/// <hide>Just for debugging; not internationalized.</hide>
		public static void formatDuration(long time, long now, java.io.PrintWriter pw)
		{
			if (time == 0)
			{
				pw.print("--");
				return;
			}
			formatDuration(time - now, pw, 0);
		}
	}
}

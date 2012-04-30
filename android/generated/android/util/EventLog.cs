using Sharpen;

namespace android.util
{
	[Sharpen.Stub]
	public class EventLog
	{
		[Sharpen.Stub]
		public EventLog()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public sealed class Event
		{
			[Sharpen.Stub]
			internal Event(byte[] data)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public int getProcessId()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public int getThreadId()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public long getTimeNanos()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public int getTag()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public object getData()
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public static int writeEvent(int tag, int value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int writeEvent(int tag, long value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int writeEvent(int tag, string str)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int writeEvent(int tag, params object[] list)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void readEvents(int[] tags, java.util.Collection<android.util.EventLog
			.Event> output)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static string getTagName(int tag)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int getTagCode(string name)
		{
			throw new System.NotImplementedException();
		}
	}
}

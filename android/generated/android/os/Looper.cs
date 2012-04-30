using Sharpen;

namespace android.os
{
	[Sharpen.Stub]
	public class Looper
	{
		[Sharpen.Stub]
		public static void prepare()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void prepareMainLooper()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.os.Looper getMainLooper()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void loop()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.os.Looper myLooper()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setMessageLogging(android.util.Printer printer)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.os.MessageQueue myQueue()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void quit()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual java.lang.Thread getThread()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.os.MessageQueue getQueue()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void dump(android.util.Printer pw, string prefix)
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
		public interface Profiler
		{
			[Sharpen.Stub]
			void profile(android.os.Message message, long wallStart, long wallTime, long threadStart
				, long threadTime);
		}
	}
}

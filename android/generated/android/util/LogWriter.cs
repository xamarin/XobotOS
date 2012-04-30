using Sharpen;

namespace android.util
{
	/// <hide></hide>
	[Sharpen.Sharpened]
	public class LogWriter : java.io.Writer
	{
		private readonly int mPriority;

		private readonly string mTag;

		private readonly int mBuffer;

		private java.lang.StringBuilder mBuilder = new java.lang.StringBuilder(128);

		/// <summary>
		/// Create a new Writer that sends to the log with the given priority
		/// and tag.
		/// </summary>
		/// <remarks>
		/// Create a new Writer that sends to the log with the given priority
		/// and tag.
		/// </remarks>
		/// <param name="priority">
		/// The desired log priority:
		/// <see cref="Log.VERBOSE">Log.VERBOSE</see>
		/// ,
		/// <see cref="Log.DEBUG">Log.DEBUG</see>
		/// ,
		/// <see cref="Log.INFO">Log.INFO</see>
		/// ,
		/// <see cref="Log.WARN">Log.WARN</see>
		/// , or
		/// <see cref="Log.ERROR">Log.ERROR</see>
		/// .
		/// </param>
		/// <param name="tag">A string tag to associate with each printed log statement.</param>
		public LogWriter(int priority, string tag)
		{
			mPriority = priority;
			mTag = tag;
			mBuffer = android.util.Log.LOG_ID_MAIN;
		}

		/// <hide>Same as above, but buffer is one of the LOG_ID_ constants from android.util.Log.
		/// 	</hide>
		public LogWriter(int priority, string tag, int buffer)
		{
			mPriority = priority;
			mTag = tag;
			mBuffer = buffer;
		}

		[Sharpen.OverridesMethod(@"java.io.Writer")]
		public override void close()
		{
			flushBuilder();
		}

		[Sharpen.OverridesMethod(@"java.io.Writer")]
		public override void flush()
		{
			flushBuilder();
		}

		[Sharpen.OverridesMethod(@"java.io.Writer")]
		public override void write(char[] buf, int offset, int count)
		{
			{
				for (int i = 0; i < count; i++)
				{
					char c = buf[offset + i];
					if (c == '\n')
					{
						flushBuilder();
					}
					else
					{
						mBuilder.append(c);
					}
				}
			}
		}

		private void flushBuilder()
		{
			if (mBuilder.Length > 0)
			{
				android.util.Log.println_native(mBuffer, mPriority, mTag, mBuilder.ToString());
				mBuilder.delete(0, mBuilder.Length);
			}
		}
	}
}

using Sharpen;

namespace android.content
{
	[Sharpen.Stub]
	public class EventLogTags
	{
		[Sharpen.Stub]
		private EventLogTags()
		{
			throw new System.NotImplementedException();
		}

		public const int CONTENT_QUERY_SAMPLE = 52002;

		public const int CONTENT_UPDATE_SAMPLE = 52003;

		public const int BINDER_SAMPLE = 52004;

		[Sharpen.Stub]
		public static void writeContentQuerySample(string uri, string projection, string 
			selection, string sortorder, int time, string blockingPackage, int samplePercent
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void writeContentUpdateSample(string uri, string operation, string 
			selection, int time, string blockingPackage, int samplePercent)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void writeBinderSample(string descriptor, int methodNum, int time, 
			string blockingPackage, int samplePercent)
		{
			throw new System.NotImplementedException();
		}
	}
}

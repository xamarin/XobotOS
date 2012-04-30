using Sharpen;

namespace android.view
{
	[Sharpen.NakedStub]
	public sealed class ViewDebug
	{
		public const string CONSISTENCY_LOG_TAG = "ViewConsistency";
		public const int CONSISTENCY_LAYOUT = 0x1;
		public const int CONSISTENCY_DRAWING = 0x2;
		public const bool TRACE_HIERARCHY = false;
		public const bool TRACE_RECYCLER = false;
		public const bool TRACE_MOTION_EVENTS = false;
		internal const string SYSTEM_PROPERTY_CAPTURE_VIEW = "debug.captureview";
		internal const string SYSTEM_PROPERTY_CAPTURE_EVENT = "debug.captureevent";
		public static bool profileDrawing = false;
		public static bool profileLayout = false;
		public static bool showFps = false;
		public static bool consistencyCheckEnabled = false;
		
		public static void dumpCapturedView (string tag, object view)
		{
			throw new System.NotImplementedException ();
		}
		
		internal static object resolveId (android.content.Context context, int id)
		{
			throw new System.NotImplementedException ();
		}
		
		public class ExportedProperty : System.Attribute
		{
		}
		
		public class CapturedViewProperty : System.Attribute
		{
		}
	}
}

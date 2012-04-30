using Sharpen;

namespace android.drm
{
	[Sharpen.Stub]
	public class DrmStore
	{
		[Sharpen.Stub]
		public interface ConstraintsColumns
		{
		}

		[Sharpen.Stub]
		public static class ConstraintsColumnsClass
		{
			public const string MAX_REPEAT_COUNT = "max_repeat_count";

			public const string REMAINING_REPEAT_COUNT = "remaining_repeat_count";

			public const string LICENSE_START_TIME = "license_start_time";

			public const string LICENSE_EXPIRY_TIME = "license_expiry_time";

			public const string LICENSE_AVAILABLE_TIME = "license_available_time";

			public const string EXTENDED_METADATA = "extended_metadata";
		}

		[Sharpen.Stub]
		public class DrmObjectType
		{
			public const int UNKNOWN = unchecked((int)(0x00));

			public const int CONTENT = unchecked((int)(0x01));

			public const int RIGHTS_OBJECT = unchecked((int)(0x02));

			public const int TRIGGER_OBJECT = unchecked((int)(0x03));
		}

		[Sharpen.Stub]
		public class Playback
		{
			public const int START = unchecked((int)(0x00));

			public const int STOP = unchecked((int)(0x01));

			public const int PAUSE = unchecked((int)(0x02));

			public const int RESUME = unchecked((int)(0x03));

			[Sharpen.Stub]
			internal static bool isValid(int playbackStatus)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public class Action
		{
			public const int DEFAULT = unchecked((int)(0x00));

			public const int PLAY = unchecked((int)(0x01));

			public const int RINGTONE = unchecked((int)(0x02));

			public const int TRANSFER = unchecked((int)(0x03));

			public const int OUTPUT = unchecked((int)(0x04));

			public const int PREVIEW = unchecked((int)(0x05));

			public const int EXECUTE = unchecked((int)(0x06));

			public const int DISPLAY = unchecked((int)(0x07));

			[Sharpen.Stub]
			internal static bool isValid(int action)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public class RightsStatus
		{
			public const int RIGHTS_VALID = unchecked((int)(0x00));

			public const int RIGHTS_INVALID = unchecked((int)(0x01));

			public const int RIGHTS_EXPIRED = unchecked((int)(0x02));

			public const int RIGHTS_NOT_ACQUIRED = unchecked((int)(0x03));
		}
	}
}

using Sharpen;

namespace android.media
{
	[Sharpen.Stub]
	public class AudioSystem
	{
		public const int STREAM_VOICE_CALL = 0;

		public const int STREAM_SYSTEM = 1;

		public const int STREAM_RING = 2;

		public const int STREAM_MUSIC = 3;

		public const int STREAM_ALARM = 4;

		public const int STREAM_NOTIFICATION = 5;

		public const int STREAM_BLUETOOTH_SCO = 6;

		public const int STREAM_SYSTEM_ENFORCED = 7;

		public const int STREAM_DTMF = 8;

		public const int STREAM_TTS = 9;

		[System.ObsoleteAttribute(@"Use #numStreamTypes() instead")]
		public const int NUM_STREAMS = 5;

		internal const int NUM_STREAM_TYPES = 10;

		[Sharpen.Stub]
		public static int getNumStreamTypes()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int muteMicrophone(bool on)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static bool isMicrophoneMuted()
		{
			throw new System.NotImplementedException();
		}

		public const int MODE_INVALID = -2;

		public const int MODE_CURRENT = -1;

		public const int MODE_NORMAL = 0;

		public const int MODE_RINGTONE = 1;

		public const int MODE_IN_CALL = 2;

		public const int MODE_IN_COMMUNICATION = 3;

		public const int NUM_MODES = 4;

		[System.ObsoleteAttribute(@"")]
		public const int ROUTE_EARPIECE = (1 << 0);

		[System.ObsoleteAttribute(@"")]
		public const int ROUTE_SPEAKER = (1 << 1);

		[System.ObsoleteAttribute(@"use ROUTE_BLUETOOTH_SCO")]
		public const int ROUTE_BLUETOOTH = (1 << 2);

		[System.ObsoleteAttribute(@"")]
		public const int ROUTE_BLUETOOTH_SCO = (1 << 2);

		[System.ObsoleteAttribute(@"")]
		public const int ROUTE_HEADSET = (1 << 3);

		[System.ObsoleteAttribute(@"")]
		public const int ROUTE_BLUETOOTH_A2DP = (1 << 4);

		[System.ObsoleteAttribute(@"")]
		public const int ROUTE_ALL = unchecked((int)(0xFFFFFFFF));

		[Sharpen.Stub]
		public static bool isStreamActive(int stream, int inPastMs)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int setParameters(string keyValuePairs)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static string getParameters(string keys)
		{
			throw new System.NotImplementedException();
		}

		public const int AUDIO_STATUS_OK = 0;

		public const int AUDIO_STATUS_ERROR = 1;

		public const int AUDIO_STATUS_SERVER_DIED = 100;

		private static android.media.AudioSystem.ErrorCallback mErrorCallback;

		[Sharpen.Stub]
		public interface ErrorCallback
		{
			[Sharpen.Stub]
			void onError(int error);
		}

		[Sharpen.Stub]
		public static void setErrorCallback(android.media.AudioSystem.ErrorCallback cb)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void errorCallbackFromNative(int error)
		{
			throw new System.NotImplementedException();
		}

		public const int DEVICE_OUT_EARPIECE = unchecked((int)(0x1));

		public const int DEVICE_OUT_SPEAKER = unchecked((int)(0x2));

		public const int DEVICE_OUT_WIRED_HEADSET = unchecked((int)(0x4));

		public const int DEVICE_OUT_WIRED_HEADPHONE = unchecked((int)(0x8));

		public const int DEVICE_OUT_BLUETOOTH_SCO = unchecked((int)(0x10));

		public const int DEVICE_OUT_BLUETOOTH_SCO_HEADSET = unchecked((int)(0x20));

		public const int DEVICE_OUT_BLUETOOTH_SCO_CARKIT = unchecked((int)(0x40));

		public const int DEVICE_OUT_BLUETOOTH_A2DP = unchecked((int)(0x80));

		public const int DEVICE_OUT_BLUETOOTH_A2DP_HEADPHONES = unchecked((int)(0x100));

		public const int DEVICE_OUT_BLUETOOTH_A2DP_SPEAKER = unchecked((int)(0x200));

		public const int DEVICE_OUT_AUX_DIGITAL = unchecked((int)(0x400));

		public const int DEVICE_OUT_ANLG_DOCK_HEADSET = unchecked((int)(0x800));

		public const int DEVICE_OUT_DGTL_DOCK_HEADSET = unchecked((int)(0x1000));

		public const int DEVICE_OUT_DEFAULT = unchecked((int)(0x8000));

		public const int DEVICE_IN_COMMUNICATION = unchecked((int)(0x10000));

		public const int DEVICE_IN_AMBIENT = unchecked((int)(0x20000));

		public const int DEVICE_IN_BUILTIN_MIC1 = unchecked((int)(0x40000));

		public const int DEVICE_IN_BUILTIN_MIC2 = unchecked((int)(0x80000));

		public const int DEVICE_IN_MIC_ARRAY = unchecked((int)(0x100000));

		public const int DEVICE_IN_BLUETOOTH_SCO_HEADSET = unchecked((int)(0x200000));

		public const int DEVICE_IN_WIRED_HEADSET = unchecked((int)(0x400000));

		public const int DEVICE_IN_AUX_DIGITAL = unchecked((int)(0x800000));

		public const int DEVICE_IN_DEFAULT = unchecked((int)(0x80000000));

		public const int DEVICE_STATE_UNAVAILABLE = 0;

		public const int DEVICE_STATE_AVAILABLE = 1;

		internal const int NUM_DEVICE_STATES = 1;

		public const int PHONE_STATE_OFFCALL = 0;

		public const int PHONE_STATE_RINGING = 1;

		public const int PHONE_STATE_INCALL = 2;

		public const int FORCE_NONE = 0;

		public const int FORCE_SPEAKER = 1;

		public const int FORCE_HEADPHONES = 2;

		public const int FORCE_BT_SCO = 3;

		public const int FORCE_BT_A2DP = 4;

		public const int FORCE_WIRED_ACCESSORY = 5;

		public const int FORCE_BT_CAR_DOCK = 6;

		public const int FORCE_BT_DESK_DOCK = 7;

		public const int FORCE_ANALOG_DOCK = 8;

		public const int FORCE_DIGITAL_DOCK = 9;

		internal const int NUM_FORCE_CONFIG = 10;

		public const int FORCE_DEFAULT = FORCE_NONE;

		public const int FOR_COMMUNICATION = 0;

		public const int FOR_MEDIA = 1;

		public const int FOR_RECORD = 2;

		public const int FOR_DOCK = 3;

		internal const int NUM_FORCE_USE = 4;

		[Sharpen.Stub]
		public static int setDeviceConnectionState(int device, int state, string device_address
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int getDeviceConnectionState(int device, string device_address)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int setPhoneState(int state)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int setRingerMode(int mode, int mask)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int setForceUse(int usage, int config)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int getForceUse(int usage)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int initStreamVolume(int stream, int indexMin, int indexMax)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int setStreamVolumeIndex(int stream, int index)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int getStreamVolumeIndex(int stream)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int getDevicesForStream(int stream)
		{
			throw new System.NotImplementedException();
		}
	}
}

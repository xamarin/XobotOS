using Sharpen;

namespace android.media
{
	[Sharpen.Stub]
	public class AudioManager
	{
		private readonly android.content.Context mContext;

		private readonly android.os.Handler mHandler;

		private long mVolumeKeyUpTime;

		private int mVolumeControlStream = -1;

		private static string TAG = "AudioManager";

		private static bool localLOGV = false;

		public const string ACTION_AUDIO_BECOMING_NOISY = "android.media.AUDIO_BECOMING_NOISY";

		public const string RINGER_MODE_CHANGED_ACTION = "android.media.RINGER_MODE_CHANGED";

		public const string EXTRA_RINGER_MODE = "android.media.EXTRA_RINGER_MODE";

		public const string VIBRATE_SETTING_CHANGED_ACTION = "android.media.VIBRATE_SETTING_CHANGED";

		public const string VOLUME_CHANGED_ACTION = "android.media.VOLUME_CHANGED_ACTION";

		public const string EXTRA_VIBRATE_SETTING = "android.media.EXTRA_VIBRATE_SETTING";

		public const string EXTRA_VIBRATE_TYPE = "android.media.EXTRA_VIBRATE_TYPE";

		public const string EXTRA_VOLUME_STREAM_TYPE = "android.media.EXTRA_VOLUME_STREAM_TYPE";

		public const string EXTRA_VOLUME_STREAM_VALUE = "android.media.EXTRA_VOLUME_STREAM_VALUE";

		public const string EXTRA_PREV_VOLUME_STREAM_VALUE = "android.media.EXTRA_PREV_VOLUME_STREAM_VALUE";

		public const int STREAM_VOICE_CALL = android.media.AudioSystem.STREAM_VOICE_CALL;

		public const int STREAM_SYSTEM = android.media.AudioSystem.STREAM_SYSTEM;

		public const int STREAM_RING = android.media.AudioSystem.STREAM_RING;

		public const int STREAM_MUSIC = android.media.AudioSystem.STREAM_MUSIC;

		public const int STREAM_ALARM = android.media.AudioSystem.STREAM_ALARM;

		public const int STREAM_NOTIFICATION = android.media.AudioSystem.STREAM_NOTIFICATION;

		public const int STREAM_BLUETOOTH_SCO = android.media.AudioSystem.STREAM_BLUETOOTH_SCO;

		public const int STREAM_SYSTEM_ENFORCED = android.media.AudioSystem.STREAM_SYSTEM_ENFORCED;

		public const int STREAM_DTMF = android.media.AudioSystem.STREAM_DTMF;

		public const int STREAM_TTS = android.media.AudioSystem.STREAM_TTS;

		[System.ObsoleteAttribute(@"Use AudioSystem.getNumStreamTypes() instead")]
		public const int NUM_STREAMS = android.media.AudioSystem.NUM_STREAMS;

		public static readonly int[] DEFAULT_STREAM_VOLUME = new int[] { 4, 7, 5, 11, 6, 
			5, 7, 7, 11, 11 };

		public const int ADJUST_RAISE = 1;

		public const int ADJUST_LOWER = -1;

		public const int ADJUST_SAME = 0;

		public const int FLAG_SHOW_UI = 1 << 0;

		public const int FLAG_ALLOW_RINGER_MODES = 1 << 1;

		public const int FLAG_PLAY_SOUND = 1 << 2;

		public const int FLAG_REMOVE_SOUND_AND_VIBRATE = 1 << 3;

		public const int FLAG_VIBRATE = 1 << 4;

		public const int FLAG_FORCE_STREAM = 1 << 5;

		public const int RINGER_MODE_SILENT = 0;

		public const int RINGER_MODE_VIBRATE = 1;

		public const int RINGER_MODE_NORMAL = 2;

		internal const int RINGER_MODE_MAX = RINGER_MODE_NORMAL;

		public const int VIBRATE_TYPE_RINGER = 0;

		public const int VIBRATE_TYPE_NOTIFICATION = 1;

		public const int VIBRATE_SETTING_OFF = 0;

		public const int VIBRATE_SETTING_ON = 1;

		public const int VIBRATE_SETTING_ONLY_SILENT = 2;

		public const int USE_DEFAULT_STREAM_TYPE = int.MinValue;

		private static android.media.IAudioService sService;

		[Sharpen.Stub]
		public AudioManager(android.content.Context context)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static android.media.IAudioService getService()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void preDispatchKeyEvent(int keyCode, int stream)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void handleKeyDown(int keyCode, int stream)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void handleKeyUp(int keyCode, int stream)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void adjustStreamVolume(int streamType, int direction, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void adjustVolume(int direction, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void adjustSuggestedStreamVolume(int direction, int suggestedStreamType
			, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getRingerMode()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static bool isValidRingerMode(int ringerMode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getStreamMaxVolume(int streamType)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getStreamVolume(int streamType)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getLastAudibleStreamVolume(int streamType)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setRingerMode(int ringerMode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setStreamVolume(int streamType, int index, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setStreamSolo(int streamType, bool state)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setStreamMute(int streamType, bool state)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isStreamMute(int streamType)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void forceVolumeControlStream(int streamType)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool shouldVibrate(int vibrateType)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getVibrateSetting(int vibrateType)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setVibrateSetting(int vibrateType, int vibrateSetting)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setSpeakerphoneOn(bool on)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isSpeakerphoneOn()
		{
			throw new System.NotImplementedException();
		}

		[System.ObsoleteAttribute(@"Use  ACTION_SCO_AUDIO_STATE_UPDATED instead")]
		public const string ACTION_SCO_AUDIO_STATE_CHANGED = "android.media.SCO_AUDIO_STATE_CHANGED";

		public const string ACTION_SCO_AUDIO_STATE_UPDATED = "android.media.ACTION_SCO_AUDIO_STATE_UPDATED";

		public const string EXTRA_SCO_AUDIO_STATE = "android.media.extra.SCO_AUDIO_STATE";

		public const string EXTRA_SCO_AUDIO_PREVIOUS_STATE = "android.media.extra.SCO_AUDIO_PREVIOUS_STATE";

		public const int SCO_AUDIO_STATE_DISCONNECTED = 0;

		public const int SCO_AUDIO_STATE_CONNECTED = 1;

		public const int SCO_AUDIO_STATE_CONNECTING = 2;

		public const int SCO_AUDIO_STATE_ERROR = -1;

		[Sharpen.Stub]
		public virtual bool isBluetoothScoAvailableOffCall()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void startBluetoothSco()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void stopBluetoothSco()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setBluetoothScoOn(bool on)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isBluetoothScoOn()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"Do not use.")]
		public virtual void setBluetoothA2dpOn(bool on)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isBluetoothA2dpOn()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"Do not use.")]
		public virtual void setWiredHeadsetOn(bool on)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"Use only to check is a headset is connected or not.")]
		public virtual bool isWiredHeadsetOn()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setMicrophoneMute(bool on)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isMicrophoneMute()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setMode(int mode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getMode()
		{
			throw new System.NotImplementedException();
		}

		public const int MODE_INVALID = android.media.AudioSystem.MODE_INVALID;

		public const int MODE_CURRENT = android.media.AudioSystem.MODE_CURRENT;

		public const int MODE_NORMAL = android.media.AudioSystem.MODE_NORMAL;

		public const int MODE_RINGTONE = android.media.AudioSystem.MODE_RINGTONE;

		public const int MODE_IN_CALL = android.media.AudioSystem.MODE_IN_CALL;

		public const int MODE_IN_COMMUNICATION = android.media.AudioSystem.MODE_IN_COMMUNICATION;

		[System.ObsoleteAttribute(@"Do not set audio routing directly, use setSpeakerphoneOn(), setBluetoothScoOn() methods instead."
			)]
		public const int ROUTE_EARPIECE = android.media.AudioSystem.ROUTE_EARPIECE;

		[System.ObsoleteAttribute(@"Do not set audio routing directly, use setSpeakerphoneOn(), setBluetoothScoOn() methods instead."
			)]
		public const int ROUTE_SPEAKER = android.media.AudioSystem.ROUTE_SPEAKER;

		[System.ObsoleteAttribute(@"Do not set audio routing directly, use setSpeakerphoneOn(), setBluetoothScoOn() methods instead."
			)]
		public const int ROUTE_BLUETOOTH = android.media.AudioSystem.ROUTE_BLUETOOTH_SCO;

		[System.ObsoleteAttribute(@"Do not set audio routing directly, use setSpeakerphoneOn(), setBluetoothScoOn() methods instead."
			)]
		public const int ROUTE_BLUETOOTH_SCO = android.media.AudioSystem.ROUTE_BLUETOOTH_SCO;

		[System.ObsoleteAttribute(@"Do not set audio routing directly, use setSpeakerphoneOn(), setBluetoothScoOn() methods instead."
			)]
		public const int ROUTE_HEADSET = android.media.AudioSystem.ROUTE_HEADSET;

		[System.ObsoleteAttribute(@"Do not set audio routing directly, use setSpeakerphoneOn(), setBluetoothScoOn() methods instead."
			)]
		public const int ROUTE_BLUETOOTH_A2DP = android.media.AudioSystem.ROUTE_BLUETOOTH_A2DP;

		[System.ObsoleteAttribute(@"Do not set audio routing directly, use setSpeakerphoneOn(), setBluetoothScoOn() methods instead."
			)]
		public const int ROUTE_ALL = android.media.AudioSystem.ROUTE_ALL;

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"Do not set audio routing directly, use setSpeakerphoneOn(), setBluetoothScoOn() methods instead."
			)]
		public virtual void setRouting(int mode, int routes, int mask)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"Do not query audio routing directly, use isSpeakerphoneOn(), isBluetoothScoOn(), isBluetoothA2dpOn() and isWiredHeadsetOn() methods instead."
			)]
		public virtual int getRouting(int mode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isMusicActive()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"Use #setPrameters(String) instead")]
		public virtual void setParameter(string key, string value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setParameters(string keyValuePairs)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string getParameters(string keys)
		{
			throw new System.NotImplementedException();
		}

		public const int FX_KEY_CLICK = 0;

		public const int FX_FOCUS_NAVIGATION_UP = 1;

		public const int FX_FOCUS_NAVIGATION_DOWN = 2;

		public const int FX_FOCUS_NAVIGATION_LEFT = 3;

		public const int FX_FOCUS_NAVIGATION_RIGHT = 4;

		public const int FX_KEYPRESS_STANDARD = 5;

		public const int FX_KEYPRESS_SPACEBAR = 6;

		public const int FX_KEYPRESS_DELETE = 7;

		public const int FX_KEYPRESS_RETURN = 8;

		public const int NUM_SOUND_EFFECTS = 9;

		[Sharpen.Stub]
		public virtual void playSoundEffect(int effectType)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void playSoundEffect(int effectType, float volume)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private bool querySoundEffectsEnabled()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void loadSoundEffects()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void unloadSoundEffects()
		{
			throw new System.NotImplementedException();
		}

		public const int AUDIOFOCUS_GAIN = 1;

		public const int AUDIOFOCUS_GAIN_TRANSIENT = 2;

		public const int AUDIOFOCUS_GAIN_TRANSIENT_MAY_DUCK = 3;

		public const int AUDIOFOCUS_LOSS = -1 * AUDIOFOCUS_GAIN;

		public const int AUDIOFOCUS_LOSS_TRANSIENT = -1 * AUDIOFOCUS_GAIN_TRANSIENT;

		public const int AUDIOFOCUS_LOSS_TRANSIENT_CAN_DUCK = -1 * AUDIOFOCUS_GAIN_TRANSIENT_MAY_DUCK;

		[Sharpen.Stub]
		public interface OnAudioFocusChangeListener
		{
			[Sharpen.Stub]
			void onAudioFocusChange(int focusChange);
		}

		private java.util.HashMap<string, android.media.AudioManager.OnAudioFocusChangeListener
			> mAudioFocusIdListenerMap = new java.util.HashMap<string, android.media.AudioManager
			.OnAudioFocusChangeListener>();

		private readonly object mFocusListenerLock = new object();

		[Sharpen.Stub]
		private android.media.AudioManager.OnAudioFocusChangeListener findFocusListener(string
			 id)
		{
			throw new System.NotImplementedException();
		}

		private android.media.AudioManager.FocusEventHandlerDelegate mAudioFocusEventHandlerDelegate;

		[Sharpen.Stub]
		private class FocusEventHandlerDelegate
		{
			internal readonly android.os.Handler mHandler;

			[Sharpen.Stub]
			internal FocusEventHandlerDelegate(AudioManager _enclosing)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal virtual android.os.Handler getHandler()
			{
				throw new System.NotImplementedException();
			}

			private readonly AudioManager _enclosing;
		}

		private sealed class _Stub_1572 : android.media.IAudioFocusDispatcherClass.Stub
		{
			public _Stub_1572()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.media.IAudioFocusDispatcher")]
			public override void dispatchAudioFocusChange(int focusChange, string id)
			{
				throw new System.NotImplementedException();
			}
		}

		private android.media.IAudioFocusDispatcher mAudioFocusDispatcher = new _Stub_1572
			();

		[Sharpen.Stub]
		private string getIdForAudioFocusListener(android.media.AudioManager.OnAudioFocusChangeListener
			 l)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void registerAudioFocusListener(android.media.AudioManager.OnAudioFocusChangeListener
			 l)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void unregisterAudioFocusListener(android.media.AudioManager.OnAudioFocusChangeListener
			 l)
		{
			throw new System.NotImplementedException();
		}

		public const int AUDIOFOCUS_REQUEST_FAILED = 0;

		public const int AUDIOFOCUS_REQUEST_GRANTED = 1;

		[Sharpen.Stub]
		public virtual int requestAudioFocus(android.media.AudioManager.OnAudioFocusChangeListener
			 l, int streamType, int durationHint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int abandonAudioFocus(android.media.AudioManager.OnAudioFocusChangeListener
			 l)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void registerMediaButtonEventReceiver(android.content.ComponentName
			 eventReceiver)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void registerMediaButtonIntent(android.app.PendingIntent pi, android.content.ComponentName
			 eventReceiver)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void unregisterMediaButtonEventReceiver(android.content.ComponentName
			 eventReceiver)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void unregisterMediaButtonIntent(android.app.PendingIntent pi, android.content.ComponentName
			 eventReceiver)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void registerRemoteControlClient(android.media.RemoteControlClient
			 rcClient)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void unregisterRemoteControlClient(android.media.RemoteControlClient
			 rcClient)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void registerRemoteControlDisplay(android.media.IRemoteControlDisplay
			 rcd)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void unregisterRemoteControlDisplay(android.media.IRemoteControlDisplay
			 rcd)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void remoteControlDisplayUsesBitmapSize(android.media.IRemoteControlDisplay
			 rcd, int w, int h)
		{
			throw new System.NotImplementedException();
		}

		public const string REMOTE_CONTROL_CLIENT_CHANGED = "android.media.REMOTE_CONTROL_CLIENT_CHANGED";

		public const string EXTRA_REMOTE_CONTROL_CLIENT_GENERATION = "android.media.EXTRA_REMOTE_CONTROL_CLIENT_GENERATION";

		public const string EXTRA_REMOTE_CONTROL_CLIENT_NAME = "android.media.EXTRA_REMOTE_CONTROL_CLIENT_NAME";

		public const string EXTRA_REMOTE_CONTROL_EVENT_RECEIVER = "android.media.EXTRA_REMOTE_CONTROL_EVENT_RECEIVER";

		public const string EXTRA_REMOTE_CONTROL_CLIENT_INFO_CHANGED = "android.media.EXTRA_REMOTE_CONTROL_CLIENT_INFO_CHANGED";

		[Sharpen.Stub]
		public virtual void reloadAudioSettings()
		{
			throw new System.NotImplementedException();
		}

		private android.os.IBinder mICallBack = new android.os.Binder();

		[Sharpen.Stub]
		public virtual bool isSilentMode()
		{
			throw new System.NotImplementedException();
		}

		public const int DEVICE_OUT_EARPIECE = android.media.AudioSystem.DEVICE_OUT_EARPIECE;

		public const int DEVICE_OUT_SPEAKER = android.media.AudioSystem.DEVICE_OUT_SPEAKER;

		public const int DEVICE_OUT_WIRED_HEADSET = android.media.AudioSystem.DEVICE_OUT_WIRED_HEADSET;

		public const int DEVICE_OUT_WIRED_HEADPHONE = android.media.AudioSystem.DEVICE_OUT_WIRED_HEADPHONE;

		public const int DEVICE_OUT_BLUETOOTH_SCO = android.media.AudioSystem.DEVICE_OUT_BLUETOOTH_SCO;

		public const int DEVICE_OUT_BLUETOOTH_SCO_HEADSET = android.media.AudioSystem.DEVICE_OUT_BLUETOOTH_SCO_HEADSET;

		public const int DEVICE_OUT_BLUETOOTH_SCO_CARKIT = android.media.AudioSystem.DEVICE_OUT_BLUETOOTH_SCO_CARKIT;

		public const int DEVICE_OUT_BLUETOOTH_A2DP = android.media.AudioSystem.DEVICE_OUT_BLUETOOTH_A2DP;

		public const int DEVICE_OUT_BLUETOOTH_A2DP_HEADPHONES = android.media.AudioSystem
			.DEVICE_OUT_BLUETOOTH_A2DP_HEADPHONES;

		public const int DEVICE_OUT_BLUETOOTH_A2DP_SPEAKER = android.media.AudioSystem.DEVICE_OUT_BLUETOOTH_A2DP_SPEAKER;

		public const int DEVICE_OUT_AUX_DIGITAL = android.media.AudioSystem.DEVICE_OUT_AUX_DIGITAL;

		public const int DEVICE_OUT_ANLG_DOCK_HEADSET = android.media.AudioSystem.DEVICE_OUT_ANLG_DOCK_HEADSET;

		public const int DEVICE_OUT_DGTL_DOCK_HEADSET = android.media.AudioSystem.DEVICE_OUT_DGTL_DOCK_HEADSET;

		public const int DEVICE_OUT_DEFAULT = android.media.AudioSystem.DEVICE_OUT_DEFAULT;

		[Sharpen.Stub]
		public virtual int getDevicesForStream(int streamType)
		{
			throw new System.NotImplementedException();
		}
	}
}

using Sharpen;

namespace android.provider
{
	[Sharpen.Stub]
	public sealed class Settings
	{
		public const string ACTION_SETTINGS = "android.settings.SETTINGS";

		public const string ACTION_APN_SETTINGS = "android.settings.APN_SETTINGS";

		public const string ACTION_LOCATION_SOURCE_SETTINGS = "android.settings.LOCATION_SOURCE_SETTINGS";

		public const string ACTION_WIRELESS_SETTINGS = "android.settings.WIRELESS_SETTINGS";

		public const string ACTION_AIRPLANE_MODE_SETTINGS = "android.settings.AIRPLANE_MODE_SETTINGS";

		public const string ACTION_ACCESSIBILITY_SETTINGS = "android.settings.ACCESSIBILITY_SETTINGS";

		public const string ACTION_SECURITY_SETTINGS = "android.settings.SECURITY_SETTINGS";

		public const string ACTION_PRIVACY_SETTINGS = "android.settings.PRIVACY_SETTINGS";

		public const string ACTION_WIFI_SETTINGS = "android.settings.WIFI_SETTINGS";

		public const string ACTION_WIFI_IP_SETTINGS = "android.settings.WIFI_IP_SETTINGS";

		public const string ACTION_BLUETOOTH_SETTINGS = "android.settings.BLUETOOTH_SETTINGS";

		public const string ACTION_DATE_SETTINGS = "android.settings.DATE_SETTINGS";

		public const string ACTION_SOUND_SETTINGS = "android.settings.SOUND_SETTINGS";

		public const string ACTION_DISPLAY_SETTINGS = "android.settings.DISPLAY_SETTINGS";

		public const string ACTION_LOCALE_SETTINGS = "android.settings.LOCALE_SETTINGS";

		public const string ACTION_INPUT_METHOD_SETTINGS = "android.settings.INPUT_METHOD_SETTINGS";

		public const string ACTION_INPUT_METHOD_SUBTYPE_SETTINGS = "android.settings.INPUT_METHOD_SUBTYPE_SETTINGS";

		public const string ACTION_SHOW_INPUT_METHOD_PICKER = "android.settings.SHOW_INPUT_METHOD_PICKER";

		public const string ACTION_USER_DICTIONARY_SETTINGS = "android.settings.USER_DICTIONARY_SETTINGS";

		public const string ACTION_USER_DICTIONARY_INSERT = "com.android.settings.USER_DICTIONARY_INSERT";

		public const string ACTION_APPLICATION_SETTINGS = "android.settings.APPLICATION_SETTINGS";

		public const string ACTION_APPLICATION_DEVELOPMENT_SETTINGS = "android.settings.APPLICATION_DEVELOPMENT_SETTINGS";

		public const string ACTION_QUICK_LAUNCH_SETTINGS = "android.settings.QUICK_LAUNCH_SETTINGS";

		public const string ACTION_MANAGE_APPLICATIONS_SETTINGS = "android.settings.MANAGE_APPLICATIONS_SETTINGS";

		public const string ACTION_MANAGE_ALL_APPLICATIONS_SETTINGS = "android.settings.MANAGE_ALL_APPLICATIONS_SETTINGS";

		public const string ACTION_APPLICATION_DETAILS_SETTINGS = "android.settings.APPLICATION_DETAILS_SETTINGS";

		public const string ACTION_SYSTEM_UPDATE_SETTINGS = "android.settings.SYSTEM_UPDATE_SETTINGS";

		public const string ACTION_SYNC_SETTINGS = "android.settings.SYNC_SETTINGS";

		public const string ACTION_ADD_ACCOUNT = "android.settings.ADD_ACCOUNT_SETTINGS";

		public const string ACTION_NETWORK_OPERATOR_SETTINGS = "android.settings.NETWORK_OPERATOR_SETTINGS";

		public const string ACTION_DATA_ROAMING_SETTINGS = "android.settings.DATA_ROAMING_SETTINGS";

		public const string ACTION_INTERNAL_STORAGE_SETTINGS = "android.settings.INTERNAL_STORAGE_SETTINGS";

		public const string ACTION_MEMORY_CARD_SETTINGS = "android.settings.MEMORY_CARD_SETTINGS";

		public const string ACTION_SEARCH_SETTINGS = "android.search.action.SEARCH_SETTINGS";

		public const string ACTION_DEVICE_INFO_SETTINGS = "android.settings.DEVICE_INFO_SETTINGS";

		public const string ACTION_NFCSHARING_SETTINGS = "android.settings.NFCSHARING_SETTINGS";

		public const string CALL_METHOD_GET_SYSTEM = "GET_system";

		public const string CALL_METHOD_GET_SECURE = "GET_secure";

		public const string EXTRA_AUTHORITIES = "authorities";

		public const string EXTRA_INPUT_METHOD_ID = "input_method_id";

		internal const string JID_RESOURCE_PREFIX = "android";

		public const string AUTHORITY = "settings";

		internal const string TAG = "Settings";

		internal const bool LOCAL_LOGV = false || false;

		[System.Serializable]
		[Sharpen.Stub]
		public class SettingNotFoundException : android.util.AndroidException
		{
			[Sharpen.Stub]
			public SettingNotFoundException(string msg) : base(msg)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public class NameValueTable : android.provider.BaseColumns
		{
			public const string NAME = "name";

			public const string VALUE = "value";

			[Sharpen.Stub]
			protected internal static bool putString(android.content.ContentResolver resolver
				, System.Uri uri, string name, string value)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static System.Uri getUriFor(System.Uri uri, string name)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		private class NameValueCache
		{
			internal readonly string mVersionSystemProperty;

			internal readonly System.Uri mUri;

			internal static readonly string[] SELECT_VALUE = new string[] { android.provider.Settings
				.NameValueTable.VALUE };

			internal const string NAME_EQ_PLACEHOLDER = "name=?";

			internal readonly java.util.HashMap<string, string> mValues = new java.util.HashMap
				<string, string>();

			internal long mValuesVersion = 0;

			internal android.content.IContentProvider mContentProvider = null;

			internal readonly string mCallCommand;

			[Sharpen.Stub]
			public NameValueCache(string versionSystemProperty, System.Uri uri, string callCommand
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual string getString(android.content.ContentResolver cr, string name)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public sealed class Secure : android.provider.Settings.NameValueTable
		{
			public const string SYS_PROP_SETTING_VERSION = "sys.settings_secure_version";

			private static android.provider.Settings.NameValueCache sNameValueCache = null;

			[Sharpen.Stub]
			public static string getString(android.content.ContentResolver resolver, string name
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static bool putString(android.content.ContentResolver resolver, string name
				, string value)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static System.Uri getUriFor(string name)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static int getInt(android.content.ContentResolver cr, string name, int def
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static int getInt(android.content.ContentResolver cr, string name)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static bool putInt(android.content.ContentResolver cr, string name, int value
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static long getLong(android.content.ContentResolver cr, string name, long 
				def)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static long getLong(android.content.ContentResolver cr, string name)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static bool putLong(android.content.ContentResolver cr, string name, long 
				value)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static float getFloat(android.content.ContentResolver cr, string name, float
				 def)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static float getFloat(android.content.ContentResolver cr, string name)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static bool putFloat(android.content.ContentResolver cr, string name, float
				 value)
			{
				throw new System.NotImplementedException();
			}

			public static readonly System.Uri CONTENT_URI = Sharpen.Util.ParseUri("content://"
				 + AUTHORITY + "/secure");

			public const string ADB_ENABLED = "adb_enabled";

			public const string ALLOW_MOCK_LOCATION = "mock_location";

			public const string ANDROID_ID = "android_id";

			public const string BLUETOOTH_ON = "bluetooth_on";

			[Sharpen.Stub]
			public static string getBluetoothHeadsetPriorityKey(string address)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static string getBluetoothA2dpSinkPriorityKey(string address)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static string getBluetoothInputDevicePriorityKey(string address)
			{
				throw new System.NotImplementedException();
			}

			public const string DATA_ROAMING = "data_roaming";

			public const string DEFAULT_INPUT_METHOD = "default_input_method";

			public const string SELECTED_INPUT_METHOD_SUBTYPE = "selected_input_method_subtype";

			public const string INPUT_METHODS_SUBTYPE_HISTORY = "input_methods_subtype_history";

			public const string INPUT_METHOD_SELECTOR_VISIBILITY = "input_method_selector_visibility";

			public const string DEVICE_PROVISIONED = "device_provisioned";

			public const string ENABLED_INPUT_METHODS = "enabled_input_methods";

			public const string DISABLED_SYSTEM_INPUT_METHODS = "disabled_system_input_methods";

			public const string HTTP_PROXY = "http_proxy";

			public const string GLOBAL_HTTP_PROXY_HOST = "global_http_proxy_host";

			public const string GLOBAL_HTTP_PROXY_PORT = "global_http_proxy_port";

			public const string GLOBAL_HTTP_PROXY_EXCLUSION_LIST = "global_http_proxy_exclusion_list";

			public const string SET_GLOBAL_HTTP_PROXY = "set_global_http_proxy";

			public const string DEFAULT_DNS_SERVER = "default_dns_server";

			public const string INSTALL_NON_MARKET_APPS = "install_non_market_apps";

			public const string LOCATION_PROVIDERS_ALLOWED = "location_providers_allowed";

			public const string LOCK_PATTERN_ENABLED = "lock_pattern_autolock";

			public const string LOCK_PATTERN_VISIBLE = "lock_pattern_visible_pattern";

			public const string LOCK_PATTERN_TACTILE_FEEDBACK_ENABLED = "lock_pattern_tactile_feedback_enabled";

			public const string LOCK_SCREEN_LOCK_AFTER_TIMEOUT = "lock_screen_lock_after_timeout";

			public const string LOCK_SCREEN_OWNER_INFO = "lock_screen_owner_info";

			public const string LOCK_SCREEN_OWNER_INFO_ENABLED = "lock_screen_owner_info_enabled";

			public const string DISPLAY_SIZE_FORCED = "display_size_forced";

			public const string ASSISTED_GPS_ENABLED = "assisted_gps_enabled";

			[System.ObsoleteAttribute(@"This identifier is poorly initialized and has many collisions.  It should not be used."
				)]
			public const string LOGGING_ID = "logging_id";

			public const string NETWORK_PREFERENCE = "network_preference";

			public const string TETHER_SUPPORTED = "tether_supported";

			public const string TETHER_DUN_REQUIRED = "tether_dun_required";

			public const string TETHER_DUN_APN = "tether_dun_apn";

			public const string PARENTAL_CONTROL_ENABLED = "parental_control_enabled";

			public const string PARENTAL_CONTROL_LAST_UPDATE = "parental_control_last_update";

			public const string PARENTAL_CONTROL_REDIRECT_URL = "parental_control_redirect_url";

			public const string SAMPLING_PROFILER_MS = "sampling_profiler_ms";

			public const string SETTINGS_CLASSNAME = "settings_classname";

			public const string USB_MASS_STORAGE_ENABLED = "usb_mass_storage_enabled";

			public const string USE_GOOGLE_MAIL = "use_google_mail";

			public const string ACCESSIBILITY_ENABLED = "accessibility_enabled";

			public const string TOUCH_EXPLORATION_ENABLED = "touch_exploration_enabled";

			public const string ENABLED_ACCESSIBILITY_SERVICES = "enabled_accessibility_services";

			public const string ACCESSIBILITY_SCRIPT_INJECTION = "accessibility_script_injection";

			public const string ACCESSIBILITY_WEB_CONTENT_KEY_BINDINGS = "accessibility_web_content_key_bindings";

			public const string LONG_PRESS_TIMEOUT = "long_press_timeout";

			[System.ObsoleteAttribute(@"The value of this setting is no longer respected by the framework text to speech APIs as of the Ice Cream Sandwich release."
				)]
			public const string TTS_USE_DEFAULTS = "tts_use_defaults";

			public const string TTS_DEFAULT_RATE = "tts_default_rate";

			public const string TTS_DEFAULT_PITCH = "tts_default_pitch";

			public const string TTS_DEFAULT_SYNTH = "tts_default_synth";

			[System.ObsoleteAttribute(@"this setting is no longer in use, as of the Ice Cream Sandwich release. Apps should never need to read this setting directly, instead can query the TextToSpeech framework classes for the default locale. android.speech.tts.TextToSpeech.getLanguage() ."
				)]
			public const string TTS_DEFAULT_LANG = "tts_default_lang";

			[System.ObsoleteAttribute(@"this setting is no longer in use, as of the Ice Cream Sandwich release. Apps should never need to read this setting directly, instead can query the TextToSpeech framework classes for the default locale. android.speech.tts.TextToSpeech.getLanguage() ."
				)]
			public const string TTS_DEFAULT_COUNTRY = "tts_default_country";

			[System.ObsoleteAttribute(@"this setting is no longer in use, as of the Ice Cream Sandwich release. Apps should never need to read this setting directly, instead can query the TextToSpeech framework classes for the locale that is in use android.speech.tts.TextToSpeech.getLanguage() ."
				)]
			public const string TTS_DEFAULT_VARIANT = "tts_default_variant";

			public const string TTS_DEFAULT_LOCALE = "tts_default_locale";

			public const string TTS_ENABLED_PLUGINS = "tts_enabled_plugins";

			public const string WIFI_NETWORKS_AVAILABLE_NOTIFICATION_ON = "wifi_networks_available_notification_on";

			public const string WIFI_NETWORKS_AVAILABLE_REPEAT_DELAY = "wifi_networks_available_repeat_delay";

			public const string WIFI_COUNTRY_CODE = "wifi_country_code";

			public const string WIFI_NUM_OPEN_NETWORKS_KEPT = "wifi_num_open_networks_kept";

			public const string WIFI_ON = "wifi_on";

			public const string WIFI_SAVED_STATE = "wifi_saved_state";

			public const string WIFI_AP_SSID = "wifi_ap_ssid";

			public const string WIFI_AP_SECURITY = "wifi_ap_security";

			public const string WIFI_AP_PASSWD = "wifi_ap_passwd";

			[System.Obsolete]
			public const string WIFI_WATCHDOG_ACCEPTABLE_PACKET_LOSS_PERCENTAGE = "wifi_watchdog_acceptable_packet_loss_percentage";

			[System.Obsolete]
			public const string WIFI_WATCHDOG_AP_COUNT = "wifi_watchdog_ap_count";

			[System.Obsolete]
			public const string WIFI_WATCHDOG_BACKGROUND_CHECK_DELAY_MS = "wifi_watchdog_background_check_delay_ms";

			[System.Obsolete]
			public const string WIFI_WATCHDOG_BACKGROUND_CHECK_ENABLED = "wifi_watchdog_background_check_enabled";

			[System.Obsolete]
			public const string WIFI_WATCHDOG_BACKGROUND_CHECK_TIMEOUT_MS = "wifi_watchdog_background_check_timeout_ms";

			[System.Obsolete]
			public const string WIFI_WATCHDOG_INITIAL_IGNORED_PING_COUNT = "wifi_watchdog_initial_ignored_ping_count";

			[System.Obsolete]
			public const string WIFI_WATCHDOG_MAX_AP_CHECKS = "wifi_watchdog_max_ap_checks";

			public const string WIFI_WATCHDOG_ON = "wifi_watchdog_on";

			[System.Obsolete]
			public const string WIFI_WATCHDOG_WATCH_LIST = "wifi_watchdog_watch_list";

			[System.Obsolete]
			public const string WIFI_WATCHDOG_PING_COUNT = "wifi_watchdog_ping_count";

			[System.Obsolete]
			public const string WIFI_WATCHDOG_PING_DELAY_MS = "wifi_watchdog_ping_delay_ms";

			[System.Obsolete]
			public const string WIFI_WATCHDOG_PING_TIMEOUT_MS = "wifi_watchdog_ping_timeout_ms";

			public const string WIFI_WATCHDOG_DNS_CHECK_SHORT_INTERVAL_MS = "wifi_watchdog_dns_check_short_interval_ms";

			public const string WIFI_WATCHDOG_DNS_CHECK_LONG_INTERVAL_MS = "wifi_watchdog_dns_check_long_interval_ms";

			public const string WIFI_WATCHDOG_WALLED_GARDEN_INTERVAL_MS = "wifi_watchdog_walled_garden_interval_ms";

			public const string WIFI_WATCHDOG_MAX_SSID_BLACKLISTS = "wifi_watchdog_max_ssid_blacklists";

			public const string WIFI_WATCHDOG_NUM_DNS_PINGS = "wifi_watchdog_num_dns_pings";

			public const string WIFI_WATCHDOG_MIN_DNS_RESPONSES = "wifi_watchdog_min_dns_responses";

			public const string WIFI_WATCHDOG_DNS_PING_TIMEOUT_MS = "wifi_watchdog_dns_ping_timeout_ms";

			public const string WIFI_WATCHDOG_BLACKLIST_FOLLOWUP_INTERVAL_MS = "wifi_watchdog_blacklist_followup_interval_ms";

			public const string WIFI_WATCHDOG_WALLED_GARDEN_TEST_ENABLED = "wifi_watchdog_walled_garden_test_enabled";

			public const string WIFI_WATCHDOG_WALLED_GARDEN_URL = "wifi_watchdog_walled_garden_url";

			public const string WIFI_WATCHDOG_SHOW_DISABLED_NETWORK_POPUP = "wifi_watchdog_show_disabled_network_popup";

			public const string WIFI_MAX_DHCP_RETRY_COUNT = "wifi_max_dhcp_retry_count";

			public const string WIFI_FREQUENCY_BAND = "wifi_frequency_band";

			public const string WIFI_MOBILE_DATA_TRANSITION_WAKELOCK_TIMEOUT_MS = "wifi_mobile_data_transition_wakelock_timeout_ms";

			[System.Obsolete]
			public const string BACKGROUND_DATA = "background_data";

			public const string ALLOWED_GEOLOCATION_ORIGINS = "allowed_geolocation_origins";

			public const string MOBILE_DATA = "mobile_data";

			public const string CDMA_ROAMING_MODE = "roaming_settings";

			public const string CDMA_SUBSCRIPTION_MODE = "subscription_mode";

			public const string PREFERRED_NETWORK_MODE = "preferred_network_mode";

			public const string PREFERRED_TTY_MODE = "preferred_tty_mode";

			public const string CDMA_CELL_BROADCAST_SMS = "cdma_cell_broadcast_sms";

			public const string PREFERRED_CDMA_SUBSCRIPTION = "preferred_cdma_subscription";

			public const string ENHANCED_VOICE_PRIVACY_ENABLED = "enhanced_voice_privacy_enabled";

			public const string TTY_MODE_ENABLED = "tty_mode_enabled";

			public const string CONNECTIVITY_CHANGE_DELAY = "connectivity_change_delay";

			public const int CONNECTIVITY_CHANGE_DELAY_DEFAULT = 3000;

			public const string BACKUP_ENABLED = "backup_enabled";

			public const string BACKUP_AUTO_RESTORE = "backup_auto_restore";

			public const string BACKUP_PROVISIONED = "backup_provisioned";

			public const string BACKUP_TRANSPORT = "backup_transport";

			public const string LAST_SETUP_SHOWN = "last_setup_shown";

			public const string MEMCHECK_INTERVAL = "memcheck_interval";

			public const string MEMCHECK_LOG_REALTIME_INTERVAL = "memcheck_log_realtime_interval";

			public const string MEMCHECK_SYSTEM_ENABLED = "memcheck_system_enabled";

			public const string MEMCHECK_SYSTEM_SOFT_THRESHOLD = "memcheck_system_soft";

			public const string MEMCHECK_SYSTEM_HARD_THRESHOLD = "memcheck_system_hard";

			public const string MEMCHECK_PHONE_SOFT_THRESHOLD = "memcheck_phone_soft";

			public const string MEMCHECK_PHONE_HARD_THRESHOLD = "memcheck_phone_hard";

			public const string MEMCHECK_PHONE_ENABLED = "memcheck_phone_enabled";

			public const string MEMCHECK_EXEC_START_TIME = "memcheck_exec_start_time";

			public const string MEMCHECK_EXEC_END_TIME = "memcheck_exec_end_time";

			public const string MEMCHECK_MIN_SCREEN_OFF = "memcheck_min_screen_off";

			public const string MEMCHECK_MIN_ALARM = "memcheck_min_alarm";

			public const string MEMCHECK_RECHECK_INTERVAL = "memcheck_recheck_interval";

			public const string REBOOT_INTERVAL = "reboot_interval";

			public const string REBOOT_START_TIME = "reboot_start_time";

			public const string REBOOT_WINDOW = "reboot_window";

			public const string BATTERY_DISCHARGE_DURATION_THRESHOLD = "battery_discharge_duration_threshold";

			public const string BATTERY_DISCHARGE_THRESHOLD = "battery_discharge_threshold";

			public const string SEND_ACTION_APP_ERROR = "send_action_app_error";

			public const string WTF_IS_FATAL = "wtf_is_fatal";

			public const string DROPBOX_AGE_SECONDS = "dropbox_age_seconds";

			public const string DROPBOX_MAX_FILES = "dropbox_max_files";

			public const string DROPBOX_QUOTA_KB = "dropbox_quota_kb";

			public const string DROPBOX_QUOTA_PERCENT = "dropbox_quota_percent";

			public const string DROPBOX_RESERVE_PERCENT = "dropbox_reserve_percent";

			public const string DROPBOX_TAG_PREFIX = "dropbox:";

			public const string ERROR_LOGCAT_PREFIX = "logcat_for_";

			public const string SHORT_KEYLIGHT_DELAY_MS = "short_keylight_delay_ms";

			public const string SYS_FREE_STORAGE_LOG_INTERVAL = "sys_free_storage_log_interval";

			public const string DISK_FREE_CHANGE_REPORTING_THRESHOLD = "disk_free_change_reporting_threshold";

			public const string SYS_STORAGE_THRESHOLD_PERCENTAGE = "sys_storage_threshold_percentage";

			public const string SYS_STORAGE_THRESHOLD_MAX_BYTES = "sys_storage_threshold_max_bytes";

			public const string SYS_STORAGE_FULL_THRESHOLD_BYTES = "sys_storage_full_threshold_bytes";

			public const string WIFI_IDLE_MS = "wifi_idle_ms";

			public const string WIFI_FRAMEWORK_SCAN_INTERVAL_MS = "wifi_framework_scan_interval_ms";

			public const string WIFI_SUPPLICANT_SCAN_INTERVAL_MS = "wifi_supplicant_scan_interval_ms";

			public const string PDP_WATCHDOG_POLL_INTERVAL_MS = "pdp_watchdog_poll_interval_ms";

			public const string PDP_WATCHDOG_LONG_POLL_INTERVAL_MS = "pdp_watchdog_long_poll_interval_ms";

			public const string PDP_WATCHDOG_ERROR_POLL_INTERVAL_MS = "pdp_watchdog_error_poll_interval_ms";

			public const string PDP_WATCHDOG_TRIGGER_PACKET_COUNT = "pdp_watchdog_trigger_packet_count";

			public const string PDP_WATCHDOG_ERROR_POLL_COUNT = "pdp_watchdog_error_poll_count";

			public const string PDP_WATCHDOG_MAX_PDP_RESET_FAIL_COUNT = "pdp_watchdog_max_pdp_reset_fail_count";

			public const string GPRS_REGISTER_CHECK_PERIOD_MS = "gprs_register_check_period_ms";

			public const string NITZ_UPDATE_SPACING = "nitz_update_spacing";

			public const string NITZ_UPDATE_DIFF = "nitz_update_diff";

			public const string SYNC_MAX_RETRY_DELAY_IN_SECONDS = "sync_max_retry_delay_in_seconds";

			public const string SMS_OUTGOING_CHECK_INTERVAL_MS = "sms_outgoing_check_interval_ms";

			public const string SMS_OUTGOING_CHECK_MAX_COUNT = "sms_outgoing_check_max_count";

			public const string SEARCH_GLOBAL_SEARCH_ACTIVITY = "search_global_search_activity";

			public const string SEARCH_NUM_PROMOTED_SOURCES = "search_num_promoted_sources";

			public const string SEARCH_MAX_RESULTS_TO_DISPLAY = "search_max_results_to_display";

			public const string SEARCH_MAX_RESULTS_PER_SOURCE = "search_max_results_per_source";

			public const string SEARCH_WEB_RESULTS_OVERRIDE_LIMIT = "search_web_results_override_limit";

			public const string SEARCH_PROMOTED_SOURCE_DEADLINE_MILLIS = "search_promoted_source_deadline_millis";

			public const string SEARCH_SOURCE_TIMEOUT_MILLIS = "search_source_timeout_millis";

			public const string SEARCH_PREFILL_MILLIS = "search_prefill_millis";

			public const string SEARCH_MAX_STAT_AGE_MILLIS = "search_max_stat_age_millis";

			public const string SEARCH_MAX_SOURCE_EVENT_AGE_MILLIS = "search_max_source_event_age_millis";

			public const string SEARCH_MIN_IMPRESSIONS_FOR_SOURCE_RANKING = "search_min_impressions_for_source_ranking";

			public const string SEARCH_MIN_CLICKS_FOR_SOURCE_RANKING = "search_min_clicks_for_source_ranking";

			public const string SEARCH_MAX_SHORTCUTS_RETURNED = "search_max_shortcuts_returned";

			public const string SEARCH_QUERY_THREAD_CORE_POOL_SIZE = "search_query_thread_core_pool_size";

			public const string SEARCH_QUERY_THREAD_MAX_POOL_SIZE = "search_query_thread_max_pool_size";

			public const string SEARCH_SHORTCUT_REFRESH_CORE_POOL_SIZE = "search_shortcut_refresh_core_pool_size";

			public const string SEARCH_SHORTCUT_REFRESH_MAX_POOL_SIZE = "search_shortcut_refresh_max_pool_size";

			public const string SEARCH_THREAD_KEEPALIVE_SECONDS = "search_thread_keepalive_seconds";

			public const string SEARCH_PER_SOURCE_CONCURRENT_QUERY_LIMIT = "search_per_source_concurrent_query_limit";

			public const string MOUNT_PLAY_NOTIFICATION_SND = "mount_play_not_snd";

			public const string MOUNT_UMS_AUTOSTART = "mount_ums_autostart";

			public const string MOUNT_UMS_PROMPT = "mount_ums_prompt";

			public const string MOUNT_UMS_NOTIFY_ENABLED = "mount_ums_notify_enabled";

			public const string ANR_SHOW_BACKGROUND = "anr_show_background";

			public const string VOICE_RECOGNITION_SERVICE = "voice_recognition_service";

			public const string SELECTED_SPELL_CHECKER = "selected_spell_checker";

			public const string SELECTED_SPELL_CHECKER_SUBTYPE = "selected_spell_checker_subtype";

			public const string SPELL_CHECKER_ENABLED = "spell_checker_enabled";

			public const string INCALL_POWER_BUTTON_BEHAVIOR = "incall_power_button_behavior";

			public const int INCALL_POWER_BUTTON_BEHAVIOR_SCREEN_OFF = unchecked((int)(0x1));

			public const int INCALL_POWER_BUTTON_BEHAVIOR_HANGUP = unchecked((int)(0x2));

			public const int INCALL_POWER_BUTTON_BEHAVIOR_DEFAULT = INCALL_POWER_BUTTON_BEHAVIOR_SCREEN_OFF;

			public const string UI_NIGHT_MODE = "ui_night_mode";

			public const string SET_INSTALL_LOCATION = "set_install_location";

			public const string DEFAULT_INSTALL_LOCATION = "default_install_location";

			public const string THROTTLE_POLLING_SEC = "throttle_polling_sec";

			public const string THROTTLE_THRESHOLD_BYTES = "throttle_threshold_bytes";

			public const string THROTTLE_VALUE_KBITSPS = "throttle_value_kbitsps";

			public const string THROTTLE_RESET_DAY = "throttle_reset_day";

			public const string THROTTLE_NOTIFICATION_TYPE = "throttle_notification_type";

			public const string THROTTLE_HELP_URI = "throttle_help_uri";

			public const string THROTTLE_MAX_NTP_CACHE_AGE_SEC = "throttle_max_ntp_cache_age_sec";

			public const string DOWNLOAD_MAX_BYTES_OVER_MOBILE = "download_manager_max_bytes_over_mobile";

			public const string DOWNLOAD_RECOMMENDED_MAX_BYTES_OVER_MOBILE = "download_manager_recommended_max_bytes_over_mobile";

			public const string INET_CONDITION_DEBOUNCE_UP_DELAY = "inet_condition_debounce_up_delay";

			public const string INET_CONDITION_DEBOUNCE_DOWN_DELAY = "inet_condition_debounce_down_delay";

			public const string SETUP_PREPAID_DATA_SERVICE_URL = "setup_prepaid_data_service_url";

			public const string SETUP_PREPAID_DETECTION_TARGET_URL = "setup_prepaid_detection_target_url";

			public const string SETUP_PREPAID_DETECTION_REDIR_HOST = "setup_prepaid_detection_redir_host";

			public const string DREAM_COMPONENT = "dream_component";

			public const string DREAM_TIMEOUT = "dream_timeout";

			public const string NETSTATS_ENABLED = "netstats_enabled";

			public const string NETSTATS_POLL_INTERVAL = "netstats_poll_interval";

			public const string NETSTATS_PERSIST_THRESHOLD = "netstats_persist_threshold";

			public const string NETSTATS_NETWORK_BUCKET_DURATION = "netstats_network_bucket_duration";

			public const string NETSTATS_NETWORK_MAX_HISTORY = "netstats_network_max_history";

			public const string NETSTATS_UID_BUCKET_DURATION = "netstats_uid_bucket_duration";

			public const string NETSTATS_UID_MAX_HISTORY = "netstats_uid_max_history";

			public const string NETSTATS_TAG_MAX_HISTORY = "netstats_tag_max_history";

			public const string NTP_SERVER = "ntp_server";

			public const string NTP_TIMEOUT = "ntp_timeout";

			public const string WEB_AUTOFILL_QUERY_URL = "web_autofill_query_url";

			public const string PACKAGE_VERIFIER_ENABLE = "verifier_enable";

			public const string PACKAGE_VERIFIER_TIMEOUT = "verifier_timeout";

			public const string CONTACTS_PREAUTH_URI_EXPIRATION = "contacts_preauth_uri_expiration";

			public static readonly string[] SETTINGS_TO_BACKUP = new string[] { ADB_ENABLED, 
				ALLOW_MOCK_LOCATION, PARENTAL_CONTROL_ENABLED, PARENTAL_CONTROL_REDIRECT_URL, USB_MASS_STORAGE_ENABLED
				, ACCESSIBILITY_SCRIPT_INJECTION, BACKUP_AUTO_RESTORE, ENABLED_ACCESSIBILITY_SERVICES
				, TOUCH_EXPLORATION_ENABLED, ACCESSIBILITY_ENABLED, TTS_USE_DEFAULTS, TTS_DEFAULT_RATE
				, TTS_DEFAULT_PITCH, TTS_DEFAULT_SYNTH, TTS_DEFAULT_LANG, TTS_DEFAULT_COUNTRY, TTS_ENABLED_PLUGINS
				, TTS_DEFAULT_LOCALE, WIFI_NETWORKS_AVAILABLE_NOTIFICATION_ON, WIFI_NETWORKS_AVAILABLE_REPEAT_DELAY
				, WIFI_NUM_OPEN_NETWORKS_KEPT, MOUNT_PLAY_NOTIFICATION_SND, MOUNT_UMS_AUTOSTART, 
				MOUNT_UMS_PROMPT, MOUNT_UMS_NOTIFY_ENABLED, UI_NIGHT_MODE, LOCK_SCREEN_OWNER_INFO
				, LOCK_SCREEN_OWNER_INFO_ENABLED };

			[Sharpen.Stub]
			public static bool isLocationProviderEnabled(android.content.ContentResolver cr, 
				string provider)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static void setLocationProviderEnabled(android.content.ContentResolver cr, 
				string provider, bool enabled)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public sealed class Bookmarks : android.provider.BaseColumns
		{
			internal const string TAG = "Bookmarks";

			public static readonly System.Uri CONTENT_URI = Sharpen.Util.ParseUri("content://"
				 + AUTHORITY + "/bookmarks");

			public const string ID = "_id";

			public const string TITLE = "title";

			public const string FOLDER = "folder";

			public const string INTENT = "intent";

			public const string SHORTCUT = "shortcut";

			public const string ORDERING = "ordering";

			private static readonly string[] sIntentProjection = new string[] { INTENT };

			private static readonly string[] sShortcutProjection = new string[] { ID, SHORTCUT
				 };

			private static readonly string sShortcutSelection = SHORTCUT + "=?";

			[Sharpen.Stub]
			public static android.content.Intent getIntentForShortcut(android.content.ContentResolver
				 cr, char shortcut)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static System.Uri add(android.content.ContentResolver cr, android.content.Intent
				 intent, string title, string folder, char shortcut, int ordering)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static java.lang.CharSequence getLabelForFolder(android.content.res.Resources
				 r, string folder)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static java.lang.CharSequence getTitle(android.content.Context context, android.database.Cursor
				 cursor)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public static string getGTalkDeviceId(long androidId)
		{
			throw new System.NotImplementedException();
		}
	}
}

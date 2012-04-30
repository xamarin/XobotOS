using Sharpen;

namespace android.provider
{
	[Sharpen.Stub]
	public sealed class CalendarContract
	{
		internal const string TAG = "Calendar";

		public const string ACTION_EVENT_REMINDER = "android.intent.action.EVENT_REMINDER";

		public const string EXTRA_EVENT_BEGIN_TIME = "beginTime";

		public const string EXTRA_EVENT_END_TIME = "endTime";

		public const string EXTRA_EVENT_ALL_DAY = "allDay";

		public const string AUTHORITY = "com.android.calendar";

		public static readonly System.Uri CONTENT_URI = Sharpen.Util.ParseUri("content://"
			 + AUTHORITY);

		public const string CALLER_IS_SYNCADAPTER = "caller_is_syncadapter";

		public const string ACCOUNT_TYPE_LOCAL = "LOCAL";

		[Sharpen.Stub]
		private CalendarContract()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal interface CalendarSyncColumns
		{
		}

		[Sharpen.Stub]
		protected internal static class CalendarSyncColumnsClass
		{
			public const string CAL_SYNC1 = "cal_sync1";

			public const string CAL_SYNC2 = "cal_sync2";

			public const string CAL_SYNC3 = "cal_sync3";

			public const string CAL_SYNC4 = "cal_sync4";

			public const string CAL_SYNC5 = "cal_sync5";

			public const string CAL_SYNC6 = "cal_sync6";

			public const string CAL_SYNC7 = "cal_sync7";

			public const string CAL_SYNC8 = "cal_sync8";

			public const string CAL_SYNC9 = "cal_sync9";

			public const string CAL_SYNC10 = "cal_sync10";
		}

		[Sharpen.Stub]
		protected internal interface SyncColumns : android.provider.CalendarContract.CalendarSyncColumns
		{
		}

		[Sharpen.Stub]
		protected internal static class SyncColumnsClass
		{
			public const string ACCOUNT_NAME = "account_name";

			public const string ACCOUNT_TYPE = "account_type";

			public const string _SYNC_ID = "_sync_id";

			public const string DIRTY = "dirty";

			public const string DELETED = "deleted";

			public const string CAN_PARTIALLY_UPDATE = "canPartiallyUpdate";
		}

		[Sharpen.Stub]
		protected internal interface CalendarColumns
		{
		}

		[Sharpen.Stub]
		protected internal static class CalendarColumnsClass
		{
			public const string CALENDAR_COLOR = "calendar_color";

			public const string CALENDAR_DISPLAY_NAME = "calendar_displayName";

			public const string CALENDAR_ACCESS_LEVEL = "calendar_access_level";

			public const int CAL_ACCESS_NONE = 0;

			public const int CAL_ACCESS_FREEBUSY = 100;

			public const int CAL_ACCESS_READ = 200;

			public const int CAL_ACCESS_RESPOND = 300;

			public const int CAL_ACCESS_OVERRIDE = 400;

			public const int CAL_ACCESS_CONTRIBUTOR = 500;

			public const int CAL_ACCESS_EDITOR = 600;

			public const int CAL_ACCESS_OWNER = 700;

			public const int CAL_ACCESS_ROOT = 800;

			public const string VISIBLE = "visible";

			public const string CALENDAR_TIME_ZONE = "calendar_timezone";

			public const string SYNC_EVENTS = "sync_events";

			public const string OWNER_ACCOUNT = "ownerAccount";

			public const string CAN_ORGANIZER_RESPOND = "canOrganizerRespond";

			public const string CAN_MODIFY_TIME_ZONE = "canModifyTimeZone";

			public const string MAX_REMINDERS = "maxReminders";

			public const string ALLOWED_REMINDERS = "allowedReminders";
		}

		[Sharpen.Stub]
		public sealed class CalendarEntity : android.provider.BaseColumns, android.provider.CalendarContract
			.SyncColumns, android.provider.CalendarContract.CalendarColumns
		{
			public static readonly System.Uri CONTENT_URI = Sharpen.Util.ParseUri("content://"
				 + AUTHORITY + "/calendar_entities");

			[Sharpen.Stub]
			private CalendarEntity()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.content.EntityIterator newEntityIterator(android.database.Cursor
				 cursor)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			private class EntityIteratorImpl : android.content.CursorEntityIterator
			{
				[Sharpen.Stub]
				public EntityIteratorImpl(android.database.Cursor cursor) : base(cursor)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.OverridesMethod(@"android.content.CursorEntityIterator")]
				public override android.content.Entity getEntityAndIncrementCursor(android.database.Cursor
					 cursor)
				{
					throw new System.NotImplementedException();
				}
			}
		}

		[Sharpen.Stub]
		public sealed class Calendars : android.provider.BaseColumns, android.provider.CalendarContract
			.SyncColumns, android.provider.CalendarContract.CalendarColumns
		{
			[Sharpen.Stub]
			private Calendars()
			{
				throw new System.NotImplementedException();
			}

			public static readonly System.Uri CONTENT_URI = Sharpen.Util.ParseUri("content://"
				 + AUTHORITY + "/calendars");

			public static readonly string DEFAULT_SORT_ORDER = android.provider.CalendarContract.CalendarColumnsClass.CALENDAR_DISPLAY_NAME;

			public const string NAME = "name";

			public const string CALENDAR_LOCATION = "calendar_location";

			public static readonly string[] SYNC_WRITABLE_COLUMNS = new string[] { android.provider.CalendarContract.SyncColumnsClass.ACCOUNT_NAME
				, android.provider.CalendarContract.SyncColumnsClass.ACCOUNT_TYPE, android.provider.CalendarContract.SyncColumnsClass._SYNC_ID
				, android.provider.CalendarContract.SyncColumnsClass.DIRTY, android.provider.CalendarContract.CalendarColumnsClass.OWNER_ACCOUNT
				, android.provider.CalendarContract.CalendarColumnsClass.MAX_REMINDERS, android.provider.CalendarContract.CalendarColumnsClass.ALLOWED_REMINDERS
				, android.provider.CalendarContract.CalendarColumnsClass.CAN_MODIFY_TIME_ZONE, android.provider.CalendarContract.CalendarColumnsClass.CAN_ORGANIZER_RESPOND
				, android.provider.CalendarContract.SyncColumnsClass.CAN_PARTIALLY_UPDATE, CALENDAR_LOCATION
				, android.provider.CalendarContract.CalendarColumnsClass.CALENDAR_TIME_ZONE, android.provider.CalendarContract.CalendarColumnsClass.CALENDAR_ACCESS_LEVEL
				, android.provider.CalendarContract.SyncColumnsClass.DELETED, android.provider.CalendarContract.CalendarSyncColumnsClass.CAL_SYNC1
				, android.provider.CalendarContract.CalendarSyncColumnsClass.CAL_SYNC2, android.provider.CalendarContract.CalendarSyncColumnsClass.CAL_SYNC3
				, android.provider.CalendarContract.CalendarSyncColumnsClass.CAL_SYNC4, android.provider.CalendarContract.CalendarSyncColumnsClass.CAL_SYNC5
				, android.provider.CalendarContract.CalendarSyncColumnsClass.CAL_SYNC6, android.provider.CalendarContract.CalendarSyncColumnsClass.CAL_SYNC7
				, android.provider.CalendarContract.CalendarSyncColumnsClass.CAL_SYNC8, android.provider.CalendarContract.CalendarSyncColumnsClass.CAL_SYNC9
				, android.provider.CalendarContract.CalendarSyncColumnsClass.CAL_SYNC10 };
		}

		[Sharpen.Stub]
		protected internal interface AttendeesColumns
		{
		}

		[Sharpen.Stub]
		protected internal static class AttendeesColumnsClass
		{
			public const string EVENT_ID = "event_id";

			public const string ATTENDEE_NAME = "attendeeName";

			public const string ATTENDEE_EMAIL = "attendeeEmail";

			public const string ATTENDEE_RELATIONSHIP = "attendeeRelationship";

			public const int RELATIONSHIP_NONE = 0;

			public const int RELATIONSHIP_ATTENDEE = 1;

			public const int RELATIONSHIP_ORGANIZER = 2;

			public const int RELATIONSHIP_PERFORMER = 3;

			public const int RELATIONSHIP_SPEAKER = 4;

			public const string ATTENDEE_TYPE = "attendeeType";

			public const int TYPE_NONE = 0;

			public const int TYPE_REQUIRED = 1;

			public const int TYPE_OPTIONAL = 2;

			public const string ATTENDEE_STATUS = "attendeeStatus";

			public const int ATTENDEE_STATUS_NONE = 0;

			public const int ATTENDEE_STATUS_ACCEPTED = 1;

			public const int ATTENDEE_STATUS_DECLINED = 2;

			public const int ATTENDEE_STATUS_INVITED = 3;

			public const int ATTENDEE_STATUS_TENTATIVE = 4;
		}

		[Sharpen.Stub]
		public sealed class Attendees : android.provider.BaseColumns, android.provider.CalendarContract
			.AttendeesColumns, android.provider.CalendarContract.EventsColumns
		{
			public static readonly System.Uri CONTENT_URI = Sharpen.Util.ParseUri("content://"
				 + AUTHORITY + "/attendees");

			private static readonly string ATTENDEES_WHERE = android.provider.CalendarContract.AttendeesColumnsClass.EVENT_ID
				 + "=?";

			[Sharpen.Stub]
			private Attendees()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.database.Cursor query(android.content.ContentResolver cr, long
				 eventId, string[] projection)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		protected internal interface EventsColumns
		{
		}

		[Sharpen.Stub]
		protected internal static class EventsColumnsClass
		{
			public const string CALENDAR_ID = "calendar_id";

			public const string TITLE = "title";

			public const string DESCRIPTION = "description";

			public const string EVENT_LOCATION = "eventLocation";

			public const string EVENT_COLOR = "eventColor";

			public const string STATUS = "eventStatus";

			public const int STATUS_TENTATIVE = 0;

			public const int STATUS_CONFIRMED = 1;

			public const int STATUS_CANCELED = 2;

			public const string SELF_ATTENDEE_STATUS = "selfAttendeeStatus";

			public const string SYNC_DATA1 = "sync_data1";

			public const string SYNC_DATA2 = "sync_data2";

			public const string SYNC_DATA3 = "sync_data3";

			public const string SYNC_DATA4 = "sync_data4";

			public const string SYNC_DATA5 = "sync_data5";

			public const string SYNC_DATA6 = "sync_data6";

			public const string SYNC_DATA7 = "sync_data7";

			public const string SYNC_DATA8 = "sync_data8";

			public const string SYNC_DATA9 = "sync_data9";

			public const string SYNC_DATA10 = "sync_data10";

			public const string LAST_SYNCED = "lastSynced";

			public const string DTSTART = "dtstart";

			public const string DTEND = "dtend";

			public const string DURATION = "duration";

			public const string EVENT_TIMEZONE = "eventTimezone";

			public const string EVENT_END_TIMEZONE = "eventEndTimezone";

			public const string ALL_DAY = "allDay";

			public const string ACCESS_LEVEL = "accessLevel";

			public const int ACCESS_DEFAULT = 0;

			public const int ACCESS_CONFIDENTIAL = 1;

			public const int ACCESS_PRIVATE = 2;

			public const int ACCESS_PUBLIC = 3;

			public const string AVAILABILITY = "availability";

			public const int AVAILABILITY_BUSY = 0;

			public const int AVAILABILITY_FREE = 1;

			public const string HAS_ALARM = "hasAlarm";

			public const string HAS_EXTENDED_PROPERTIES = "hasExtendedProperties";

			public const string RRULE = "rrule";

			public const string RDATE = "rdate";

			public const string EXRULE = "exrule";

			public const string EXDATE = "exdate";

			public const string ORIGINAL_ID = "original_id";

			public const string ORIGINAL_SYNC_ID = "original_sync_id";

			public const string ORIGINAL_INSTANCE_TIME = "originalInstanceTime";

			public const string ORIGINAL_ALL_DAY = "originalAllDay";

			public const string LAST_DATE = "lastDate";

			public const string HAS_ATTENDEE_DATA = "hasAttendeeData";

			public const string GUESTS_CAN_MODIFY = "guestsCanModify";

			public const string GUESTS_CAN_INVITE_OTHERS = "guestsCanInviteOthers";

			public const string GUESTS_CAN_SEE_GUESTS = "guestsCanSeeGuests";

			public const string ORGANIZER = "organizer";

			public const string CAN_INVITE_OTHERS = "canInviteOthers";
		}

		[Sharpen.Stub]
		public sealed class EventsEntity : android.provider.BaseColumns, android.provider.CalendarContract
			.SyncColumns, android.provider.CalendarContract.EventsColumns
		{
			public static readonly System.Uri CONTENT_URI = Sharpen.Util.ParseUri("content://"
				 + AUTHORITY + "/event_entities");

			[Sharpen.Stub]
			private EventsEntity()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.content.EntityIterator newEntityIterator(android.database.Cursor
				 cursor, android.content.ContentResolver resolver)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.content.EntityIterator newEntityIterator(android.database.Cursor
				 cursor, android.content.ContentProviderClient provider)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			private class EntityIteratorImpl : android.content.CursorEntityIterator
			{
				internal readonly android.content.ContentResolver mResolver;

				internal readonly android.content.ContentProviderClient mProvider;

				internal static readonly string[] REMINDERS_PROJECTION = new string[] { android.provider.CalendarContract.RemindersColumnsClass.MINUTES
					, android.provider.CalendarContract.RemindersColumnsClass.METHOD };

				internal const int COLUMN_MINUTES = 0;

				internal const int COLUMN_METHOD = 1;

				internal static readonly string[] ATTENDEES_PROJECTION = new string[] { android.provider.CalendarContract.AttendeesColumnsClass.ATTENDEE_NAME
					, android.provider.CalendarContract.AttendeesColumnsClass.ATTENDEE_EMAIL, android.provider.CalendarContract.AttendeesColumnsClass.ATTENDEE_RELATIONSHIP
					, android.provider.CalendarContract.AttendeesColumnsClass.ATTENDEE_TYPE, android.provider.CalendarContract.AttendeesColumnsClass.ATTENDEE_STATUS
					 };

				internal const int COLUMN_ATTENDEE_NAME = 0;

				internal const int COLUMN_ATTENDEE_EMAIL = 1;

				internal const int COLUMN_ATTENDEE_RELATIONSHIP = 2;

				internal const int COLUMN_ATTENDEE_TYPE = 3;

				internal const int COLUMN_ATTENDEE_STATUS = 4;

				internal static readonly string[] EXTENDED_PROJECTION = new string[] { android.provider.BaseColumnsClass._ID
					, android.provider.CalendarContract.ExtendedPropertiesColumnsClass.NAME, android.provider.CalendarContract.ExtendedPropertiesColumnsClass.VALUE
					 };

				internal const int COLUMN_ID = 0;

				internal const int COLUMN_NAME = 1;

				internal const int COLUMN_VALUE = 2;

				internal const string WHERE_EVENT_ID = "event_id=?";

				[Sharpen.Stub]
				public EntityIteratorImpl(android.database.Cursor cursor, android.content.ContentResolver
					 resolver) : base(cursor)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				public EntityIteratorImpl(android.database.Cursor cursor, android.content.ContentProviderClient
					 provider) : base(cursor)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.OverridesMethod(@"android.content.CursorEntityIterator")]
				public override android.content.Entity getEntityAndIncrementCursor(android.database.Cursor
					 cursor)
				{
					throw new System.NotImplementedException();
				}
			}
		}

		[Sharpen.Stub]
		public sealed class Events : android.provider.BaseColumns, android.provider.CalendarContract
			.SyncColumns, android.provider.CalendarContract.EventsColumns, android.provider.CalendarContract
			.CalendarColumns
		{
			public static readonly System.Uri CONTENT_URI = Sharpen.Util.ParseUri("content://"
				 + AUTHORITY + "/events");

			public static readonly System.Uri CONTENT_EXCEPTION_URI = Sharpen.Util.ParseUri("content://"
				 + AUTHORITY + "/exception");

			[Sharpen.Stub]
			private Events()
			{
				throw new System.NotImplementedException();
			}

			private static readonly string DEFAULT_SORT_ORDER = string.Empty;

			public static string[] PROVIDER_WRITABLE_COLUMNS = new string[] { android.provider.CalendarContract.SyncColumnsClass.ACCOUNT_NAME
				, android.provider.CalendarContract.SyncColumnsClass.ACCOUNT_TYPE, android.provider.CalendarContract.CalendarSyncColumnsClass.CAL_SYNC1
				, android.provider.CalendarContract.CalendarSyncColumnsClass.CAL_SYNC2, android.provider.CalendarContract.CalendarSyncColumnsClass.CAL_SYNC3
				, android.provider.CalendarContract.CalendarSyncColumnsClass.CAL_SYNC4, android.provider.CalendarContract.CalendarSyncColumnsClass.CAL_SYNC5
				, android.provider.CalendarContract.CalendarSyncColumnsClass.CAL_SYNC6, android.provider.CalendarContract.CalendarSyncColumnsClass.CAL_SYNC7
				, android.provider.CalendarContract.CalendarSyncColumnsClass.CAL_SYNC8, android.provider.CalendarContract.CalendarSyncColumnsClass.CAL_SYNC9
				, android.provider.CalendarContract.CalendarSyncColumnsClass.CAL_SYNC10, android.provider.CalendarContract.CalendarColumnsClass.ALLOWED_REMINDERS
				, android.provider.CalendarContract.CalendarColumnsClass.CALENDAR_ACCESS_LEVEL, 
				android.provider.CalendarContract.CalendarColumnsClass.CALENDAR_COLOR, android.provider.CalendarContract.CalendarColumnsClass.CALENDAR_TIME_ZONE
				, android.provider.CalendarContract.CalendarColumnsClass.CAN_MODIFY_TIME_ZONE, android.provider.CalendarContract.CalendarColumnsClass.CAN_ORGANIZER_RESPOND
				, android.provider.CalendarContract.CalendarColumnsClass.CALENDAR_DISPLAY_NAME, 
				android.provider.CalendarContract.SyncColumnsClass.CAN_PARTIALLY_UPDATE, android.provider.CalendarContract.CalendarColumnsClass.SYNC_EVENTS
				, android.provider.CalendarContract.CalendarColumnsClass.VISIBLE };

			public static readonly string[] SYNC_WRITABLE_COLUMNS = new string[] { android.provider.CalendarContract.SyncColumnsClass._SYNC_ID
				, android.provider.CalendarContract.SyncColumnsClass.DIRTY, android.provider.CalendarContract.EventsColumnsClass.SYNC_DATA1
				, android.provider.CalendarContract.EventsColumnsClass.SYNC_DATA2, android.provider.CalendarContract.EventsColumnsClass.SYNC_DATA3
				, android.provider.CalendarContract.EventsColumnsClass.SYNC_DATA4, android.provider.CalendarContract.EventsColumnsClass.SYNC_DATA5
				, android.provider.CalendarContract.EventsColumnsClass.SYNC_DATA6, android.provider.CalendarContract.EventsColumnsClass.SYNC_DATA7
				, android.provider.CalendarContract.EventsColumnsClass.SYNC_DATA8, android.provider.CalendarContract.EventsColumnsClass.SYNC_DATA9
				, android.provider.CalendarContract.EventsColumnsClass.SYNC_DATA10 };
		}

		[Sharpen.Stub]
		public sealed class Instances : android.provider.BaseColumns, android.provider.CalendarContract
			.EventsColumns, android.provider.CalendarContract.CalendarColumns
		{
			private static readonly string WHERE_CALENDARS_SELECTED = android.provider.CalendarContract.CalendarColumnsClass.VISIBLE
				 + "=?";

			private static readonly string[] WHERE_CALENDARS_ARGS = new string[] { "1" };

			[Sharpen.Stub]
			private Instances()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.database.Cursor query(android.content.ContentResolver cr, string
				[] projection, long begin, long end)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.database.Cursor query(android.content.ContentResolver cr, string
				[] projection, long begin, long end, string searchQuery)
			{
				throw new System.NotImplementedException();
			}

			public static readonly System.Uri CONTENT_URI = Sharpen.Util.ParseUri("content://"
				 + AUTHORITY + "/instances/when");

			public static readonly System.Uri CONTENT_BY_DAY_URI = Sharpen.Util.ParseUri("content://"
				 + AUTHORITY + "/instances/whenbyday");

			public static readonly System.Uri CONTENT_SEARCH_URI = Sharpen.Util.ParseUri("content://"
				 + AUTHORITY + "/instances/search");

			public static readonly System.Uri CONTENT_SEARCH_BY_DAY_URI = Sharpen.Util.ParseUri
				("content://" + AUTHORITY + "/instances/searchbyday");

			internal const string DEFAULT_SORT_ORDER = "begin ASC";

			public const string BEGIN = "begin";

			public const string END = "end";

			public const string EVENT_ID = "event_id";

			public const string START_DAY = "startDay";

			public const string END_DAY = "endDay";

			public const string START_MINUTE = "startMinute";

			public const string END_MINUTE = "endMinute";
		}

		[Sharpen.Stub]
		protected internal interface CalendarCacheColumns
		{
		}

		[Sharpen.Stub]
		protected internal static class CalendarCacheColumnsClass
		{
			public const string KEY = "key";

			public const string VALUE = "value";
		}

		[Sharpen.Stub]
		public sealed class CalendarCache : android.provider.CalendarContract.CalendarCacheColumns
		{
			public static readonly System.Uri URI = Sharpen.Util.ParseUri("content://" + AUTHORITY
				 + "/properties");

			[Sharpen.Stub]
			private CalendarCache()
			{
				throw new System.NotImplementedException();
			}

			public const string KEY_TIMEZONE_TYPE = "timezoneType";

			public const string KEY_TIMEZONE_INSTANCES = "timezoneInstances";

			public const string KEY_TIMEZONE_INSTANCES_PREVIOUS = "timezoneInstancesPrevious";

			public const string TIMEZONE_TYPE_AUTO = "auto";

			public const string TIMEZONE_TYPE_HOME = "home";
		}

		[Sharpen.Stub]
		protected internal interface CalendarMetaDataColumns
		{
		}

		[Sharpen.Stub]
		protected internal static class CalendarMetaDataColumnsClass
		{
			public const string LOCAL_TIMEZONE = "localTimezone";

			public const string MIN_INSTANCE = "minInstance";

			public const string MAX_INSTANCE = "maxInstance";

			public const string MIN_EVENTDAYS = "minEventDays";

			public const string MAX_EVENTDAYS = "maxEventDays";
		}

		[Sharpen.Stub]
		public sealed class CalendarMetaData : android.provider.CalendarContract.CalendarMetaDataColumns
			, android.provider.BaseColumns
		{
			[Sharpen.Stub]
			private CalendarMetaData()
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		protected internal interface EventDaysColumns
		{
		}

		[Sharpen.Stub]
		protected internal static class EventDaysColumnsClass
		{
			public const string STARTDAY = "startDay";

			public const string ENDDAY = "endDay";
		}

		[Sharpen.Stub]
		public sealed class EventDays : android.provider.CalendarContract.EventDaysColumns
		{
			public static readonly System.Uri CONTENT_URI = Sharpen.Util.ParseUri("content://"
				 + AUTHORITY + "/instances/groupbyday");

			internal const string SELECTION = "selected=1";

			[Sharpen.Stub]
			private EventDays()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.database.Cursor query(android.content.ContentResolver cr, int
				 startDay, int numDays, string[] projection)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		protected internal interface RemindersColumns
		{
		}

		[Sharpen.Stub]
		protected internal static class RemindersColumnsClass
		{
			public const string EVENT_ID = "event_id";

			public const string MINUTES = "minutes";

			public const int MINUTES_DEFAULT = -1;

			public const string METHOD = "method";

			public const int METHOD_DEFAULT = 0;

			public const int METHOD_ALERT = 1;

			public const int METHOD_EMAIL = 2;

			public const int METHOD_SMS = 3;
		}

		[Sharpen.Stub]
		public sealed class Reminders : android.provider.BaseColumns, android.provider.CalendarContract
			.RemindersColumns, android.provider.CalendarContract.EventsColumns
		{
			private static readonly string REMINDERS_WHERE = android.provider.CalendarContract.RemindersColumnsClass.EVENT_ID
				 + "=?";

			public static readonly System.Uri CONTENT_URI = Sharpen.Util.ParseUri("content://"
				 + AUTHORITY + "/reminders");

			[Sharpen.Stub]
			private Reminders()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.database.Cursor query(android.content.ContentResolver cr, long
				 eventId, string[] projection)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		protected internal interface CalendarAlertsColumns
		{
		}

		[Sharpen.Stub]
		protected internal static class CalendarAlertsColumnsClass
		{
			public const string EVENT_ID = "event_id";

			public const string BEGIN = "begin";

			public const string END = "end";

			public const string ALARM_TIME = "alarmTime";

			public const string CREATION_TIME = "creationTime";

			public const string RECEIVED_TIME = "receivedTime";

			public const string NOTIFY_TIME = "notifyTime";

			public const string STATE = "state";

			public const int STATE_SCHEDULED = 0;

			public const int STATE_FIRED = 1;

			public const int STATE_DISMISSED = 2;

			public const string MINUTES = "minutes";

			public const string DEFAULT_SORT_ORDER = "begin ASC,title ASC";
		}

		[Sharpen.Stub]
		public sealed class CalendarAlerts : android.provider.BaseColumns, android.provider.CalendarContract
			.CalendarAlertsColumns, android.provider.CalendarContract.EventsColumns, android.provider.CalendarContract
			.CalendarColumns
		{
			public const string TABLE_NAME = "CalendarAlerts";

			public static readonly System.Uri CONTENT_URI = Sharpen.Util.ParseUri("content://"
				 + AUTHORITY + "/calendar_alerts");

			[Sharpen.Stub]
			private CalendarAlerts()
			{
				throw new System.NotImplementedException();
			}

			private static readonly string WHERE_ALARM_EXISTS = android.provider.CalendarContract.CalendarAlertsColumnsClass.EVENT_ID
				 + "=?" + " AND " + android.provider.CalendarContract.CalendarAlertsColumnsClass.BEGIN
				 + "=?" + " AND " + android.provider.CalendarContract.CalendarAlertsColumnsClass.ALARM_TIME
				 + "=?";

			private static readonly string WHERE_FINDNEXTALARMTIME = android.provider.CalendarContract.CalendarAlertsColumnsClass.ALARM_TIME
				 + ">=?";

			private static readonly string SORT_ORDER_ALARMTIME_ASC = android.provider.CalendarContract.CalendarAlertsColumnsClass.ALARM_TIME
				 + " ASC";

			private static readonly string WHERE_RESCHEDULE_MISSED_ALARMS = android.provider.CalendarContract.CalendarAlertsColumnsClass.STATE
				 + "=" + android.provider.CalendarContract.CalendarAlertsColumnsClass.STATE_SCHEDULED
				 + " AND " + android.provider.CalendarContract.CalendarAlertsColumnsClass.ALARM_TIME
				 + "<?" + " AND " + android.provider.CalendarContract.CalendarAlertsColumnsClass.ALARM_TIME
				 + ">?" + " AND " + android.provider.CalendarContract.CalendarAlertsColumnsClass.END
				 + ">=?";

			public static readonly System.Uri CONTENT_URI_BY_INSTANCE = Sharpen.Util.ParseUri
				("content://" + AUTHORITY + "/calendar_alerts/by_instance");

			internal const bool DEBUG = false;

			[Sharpen.Stub]
			public static System.Uri insert(android.content.ContentResolver cr, long eventId, 
				long begin, long end, long alarmTime, int minutes)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static long findNextAlarmTime(android.content.ContentResolver cr, long millis
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static void rescheduleMissedAlarms(android.content.ContentResolver cr, android.content.Context
				 context, android.app.AlarmManager manager)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static void scheduleAlarm(android.content.Context context, android.app.AlarmManager
				 manager, long alarmTime)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static bool alarmExists(android.content.ContentResolver cr, long eventId, 
				long begin, long alarmTime)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		protected internal interface ExtendedPropertiesColumns
		{
		}

		[Sharpen.Stub]
		protected internal static class ExtendedPropertiesColumnsClass
		{
			public const string EVENT_ID = "event_id";

			public const string NAME = "name";

			public const string VALUE = "value";
		}

		[Sharpen.Stub]
		public sealed class ExtendedProperties : android.provider.BaseColumns, android.provider.CalendarContract
			.ExtendedPropertiesColumns, android.provider.CalendarContract.EventsColumns
		{
			public static readonly System.Uri CONTENT_URI = Sharpen.Util.ParseUri("content://"
				 + AUTHORITY + "/extendedproperties");

			[Sharpen.Stub]
			private ExtendedProperties()
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public sealed class SyncState : android.provider.SyncStateContract.Columns
		{
			[Sharpen.Stub]
			private SyncState()
			{
				throw new System.NotImplementedException();
			}

			private static readonly string CONTENT_DIRECTORY = android.provider.SyncStateContract
				.Constants.CONTENT_DIRECTORY;

			public static readonly System.Uri CONTENT_URI = Sharpen.Util.AppendUri(android.provider.CalendarContract
				.CONTENT_URI, CONTENT_DIRECTORY);
		}

		[Sharpen.Stub]
		protected internal interface EventsRawTimesColumns
		{
		}

		[Sharpen.Stub]
		protected internal static class EventsRawTimesColumnsClass
		{
			public const string EVENT_ID = "event_id";

			public const string DTSTART_2445 = "dtstart2445";

			public const string DTEND_2445 = "dtend2445";

			public const string ORIGINAL_INSTANCE_TIME_2445 = "originalInstanceTime2445";

			public const string LAST_DATE_2445 = "lastDate2445";
		}

		[Sharpen.Stub]
		public sealed class EventsRawTimes : android.provider.BaseColumns, android.provider.CalendarContract
			.EventsRawTimesColumns
		{
			[Sharpen.Stub]
			private EventsRawTimes()
			{
				throw new System.NotImplementedException();
			}
		}
	}
}

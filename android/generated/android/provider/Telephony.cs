using Sharpen;

namespace android.provider
{
	[Sharpen.Stub]
	public sealed class Telephony
	{
		internal const string TAG = "Telephony";

		internal const bool DEBUG = true;

		internal const bool LOCAL_LOGV = false;

		[Sharpen.Stub]
		public Telephony()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public interface TextBasedSmsColumns
		{
		}

		[Sharpen.Stub]
		public static class TextBasedSmsColumnsClass
		{
			public const string TYPE = "type";

			public const int MESSAGE_TYPE_ALL = 0;

			public const int MESSAGE_TYPE_INBOX = 1;

			public const int MESSAGE_TYPE_SENT = 2;

			public const int MESSAGE_TYPE_DRAFT = 3;

			public const int MESSAGE_TYPE_OUTBOX = 4;

			public const int MESSAGE_TYPE_FAILED = 5;

			public const int MESSAGE_TYPE_QUEUED = 6;

			public const string THREAD_ID = "thread_id";

			public const string ADDRESS = "address";

			public const string PERSON_ID = "person";

			public const string DATE = "date";

			public const string DATE_SENT = "date_sent";

			public const string READ = "read";

			public const string SEEN = "seen";

			public const string STATUS = "status";

			public const int STATUS_NONE = -1;

			public const int STATUS_COMPLETE = 0;

			public const int STATUS_PENDING = 32;

			public const int STATUS_FAILED = 64;

			public const string SUBJECT = "subject";

			public const string BODY = "body";

			public const string PERSON = "person";

			public const string PROTOCOL = "protocol";

			public const string REPLY_PATH_PRESENT = "reply_path_present";

			public const string SERVICE_CENTER = "service_center";

			public const string LOCKED = "locked";

			public const string ERROR_CODE = "error_code";

			public const string META_DATA = "meta_data";
		}

		[Sharpen.Stub]
		public sealed class Sms : android.provider.BaseColumns, android.provider.Telephony
			.TextBasedSmsColumns
		{
			[Sharpen.Stub]
			public static android.database.Cursor query(android.content.ContentResolver cr, string
				[] projection)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.database.Cursor query(android.content.ContentResolver cr, string
				[] projection, string where, string orderBy)
			{
				throw new System.NotImplementedException();
			}

			public static readonly System.Uri CONTENT_URI = Sharpen.Util.ParseUri("content://sms"
				);

			public const string DEFAULT_SORT_ORDER = "date DESC";

			[Sharpen.Stub]
			public static System.Uri addMessageToUri(android.content.ContentResolver resolver
				, System.Uri uri, string address, string body, string subject, long date, bool read
				, bool deliveryReport)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static System.Uri addMessageToUri(android.content.ContentResolver resolver
				, System.Uri uri, string address, string body, string subject, long date, bool read
				, bool deliveryReport, long threadId)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static bool moveMessageToFolder(android.content.Context context, System.Uri
				 uri, int folder, int error)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static bool isOutgoingFolder(int messageType)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public sealed class Inbox : android.provider.BaseColumns, android.provider.Telephony
				.TextBasedSmsColumns
			{
				public static readonly System.Uri CONTENT_URI = Sharpen.Util.ParseUri("content://sms/inbox"
					);

				public const string DEFAULT_SORT_ORDER = "date DESC";

				[Sharpen.Stub]
				public static System.Uri addMessage(android.content.ContentResolver resolver, string
					 address, string body, string subject, long date, bool read)
				{
					throw new System.NotImplementedException();
				}
			}

			[Sharpen.Stub]
			public sealed class Sent : android.provider.BaseColumns, android.provider.Telephony
				.TextBasedSmsColumns
			{
				public static readonly System.Uri CONTENT_URI = Sharpen.Util.ParseUri("content://sms/sent"
					);

				public const string DEFAULT_SORT_ORDER = "date DESC";

				[Sharpen.Stub]
				public static System.Uri addMessage(android.content.ContentResolver resolver, string
					 address, string body, string subject, long date)
				{
					throw new System.NotImplementedException();
				}
			}

			[Sharpen.Stub]
			public sealed class Draft : android.provider.BaseColumns, android.provider.Telephony
				.TextBasedSmsColumns
			{
				public static readonly System.Uri CONTENT_URI = Sharpen.Util.ParseUri("content://sms/draft"
					);

				public const string DEFAULT_SORT_ORDER = "date DESC";

				[Sharpen.Stub]
				public static System.Uri addMessage(android.content.ContentResolver resolver, string
					 address, string body, string subject, long date)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				public static bool saveMessage(android.content.ContentResolver resolver, System.Uri
					 uri, string body)
				{
					throw new System.NotImplementedException();
				}
			}

			[Sharpen.Stub]
			public sealed class Outbox : android.provider.BaseColumns, android.provider.Telephony
				.TextBasedSmsColumns
			{
				public static readonly System.Uri CONTENT_URI = Sharpen.Util.ParseUri("content://sms/outbox"
					);

				public const string DEFAULT_SORT_ORDER = "date DESC";

				[Sharpen.Stub]
				public static System.Uri addMessage(android.content.ContentResolver resolver, string
					 address, string body, string subject, long date, bool deliveryReport, long threadId
					)
				{
					throw new System.NotImplementedException();
				}
			}

			[Sharpen.Stub]
			public sealed class Conversations : android.provider.BaseColumns, android.provider.Telephony
				.TextBasedSmsColumns
			{
				public static readonly System.Uri CONTENT_URI = Sharpen.Util.ParseUri("content://sms/conversations"
					);

				public const string DEFAULT_SORT_ORDER = "date DESC";

				public const string SNIPPET = "snippet";

				public const string MESSAGE_COUNT = "msg_count";
			}

			[Sharpen.Stub]
			public sealed class Intents
			{
				public const int RESULT_SMS_HANDLED = 1;

				public const int RESULT_SMS_GENERIC_ERROR = 2;

				public const int RESULT_SMS_OUT_OF_MEMORY = 3;

				public const int RESULT_SMS_UNSUPPORTED = 4;

				public const string SMS_RECEIVED_ACTION = "android.provider.Telephony.SMS_RECEIVED";

				public const string DATA_SMS_RECEIVED_ACTION = "android.intent.action.DATA_SMS_RECEIVED";

				public const string WAP_PUSH_RECEIVED_ACTION = "android.provider.Telephony.WAP_PUSH_RECEIVED";

				public const string SMS_CB_RECEIVED_ACTION = "android.provider.Telephony.SMS_CB_RECEIVED";

				public const string SMS_EMERGENCY_CB_RECEIVED_ACTION = "android.provider.Telephony.SMS_EMERGENCY_CB_RECEIVED";

				public const string SIM_FULL_ACTION = "android.provider.Telephony.SIM_FULL";

				public const string SMS_REJECTED_ACTION = "android.provider.Telephony.SMS_REJECTED";

				[Sharpen.Stub]
				public static android.telephony.SmsMessage[] getMessagesFromIntent(android.content.Intent
					 intent)
				{
					throw new System.NotImplementedException();
				}
			}
		}

		[Sharpen.Stub]
		public interface BaseMmsColumns : android.provider.BaseColumns
		{
		}

		[Sharpen.Stub]
		public static class BaseMmsColumnsClass
		{
			public const int MESSAGE_BOX_ALL = 0;

			public const int MESSAGE_BOX_INBOX = 1;

			public const int MESSAGE_BOX_SENT = 2;

			public const int MESSAGE_BOX_DRAFTS = 3;

			public const int MESSAGE_BOX_OUTBOX = 4;

			public const string DATE = "date";

			public const string DATE_SENT = "date_sent";

			public const string MESSAGE_BOX = "msg_box";

			public const string READ = "read";

			public const string SEEN = "seen";

			public const string MESSAGE_ID = "m_id";

			public const string SUBJECT = "sub";

			public const string SUBJECT_CHARSET = "sub_cs";

			public const string CONTENT_TYPE = "ct_t";

			public const string CONTENT_LOCATION = "ct_l";

			public const string FROM = "from";

			public const string TO = "to";

			public const string CC = "cc";

			public const string BCC = "bcc";

			public const string EXPIRY = "exp";

			public const string MESSAGE_CLASS = "m_cls";

			public const string MESSAGE_TYPE = "m_type";

			public const string MMS_VERSION = "v";

			public const string MESSAGE_SIZE = "m_size";

			public const string PRIORITY = "pri";

			public const string READ_REPORT = "rr";

			public const string REPORT_ALLOWED = "rpt_a";

			public const string RESPONSE_STATUS = "resp_st";

			public const string STATUS = "st";

			public const string TRANSACTION_ID = "tr_id";

			public const string RETRIEVE_STATUS = "retr_st";

			public const string RETRIEVE_TEXT = "retr_txt";

			public const string RETRIEVE_TEXT_CHARSET = "retr_txt_cs";

			public const string READ_STATUS = "read_status";

			public const string CONTENT_CLASS = "ct_cls";

			public const string DELIVERY_REPORT = "d_rpt";

			public const string DELIVERY_TIME_TOKEN = "d_tm_tok";

			public const string DELIVERY_TIME = "d_tm";

			public const string RESPONSE_TEXT = "resp_txt";

			public const string SENDER_VISIBILITY = "s_vis";

			public const string REPLY_CHARGING = "r_chg";

			public const string REPLY_CHARGING_DEADLINE_TOKEN = "r_chg_dl_tok";

			public const string REPLY_CHARGING_DEADLINE = "r_chg_dl";

			public const string REPLY_CHARGING_ID = "r_chg_id";

			public const string REPLY_CHARGING_SIZE = "r_chg_sz";

			public const string PREVIOUSLY_SENT_BY = "p_s_by";

			public const string PREVIOUSLY_SENT_DATE = "p_s_d";

			public const string STORE = "store";

			public const string MM_STATE = "mm_st";

			public const string MM_FLAGS_TOKEN = "mm_flg_tok";

			public const string MM_FLAGS = "mm_flg";

			public const string STORE_STATUS = "store_st";

			public const string STORE_STATUS_TEXT = "store_st_txt";

			public const string STORED = "stored";

			public const string TOTALS = "totals";

			public const string MBOX_TOTALS = "mb_t";

			public const string MBOX_TOTALS_TOKEN = "mb_t_tok";

			public const string QUOTAS = "qt";

			public const string MBOX_QUOTAS = "mb_qt";

			public const string MBOX_QUOTAS_TOKEN = "mb_qt_tok";

			public const string MESSAGE_COUNT = "m_cnt";

			public const string START = "start";

			public const string DISTRIBUTION_INDICATOR = "d_ind";

			public const string ELEMENT_DESCRIPTOR = "e_des";

			public const string LIMIT = "limit";

			public const string RECOMMENDED_RETRIEVAL_MODE = "r_r_mod";

			public const string RECOMMENDED_RETRIEVAL_MODE_TEXT = "r_r_mod_txt";

			public const string STATUS_TEXT = "st_txt";

			public const string APPLIC_ID = "apl_id";

			public const string REPLY_APPLIC_ID = "r_apl_id";

			public const string AUX_APPLIC_ID = "aux_apl_id";

			public const string DRM_CONTENT = "drm_c";

			public const string ADAPTATION_ALLOWED = "adp_a";

			public const string REPLACE_ID = "repl_id";

			public const string CANCEL_ID = "cl_id";

			public const string CANCEL_STATUS = "cl_st";

			public const string THREAD_ID = "thread_id";

			public const string LOCKED = "locked";

			public const string META_DATA = "meta_data";
		}

		[Sharpen.Stub]
		public interface CanonicalAddressesColumns : android.provider.BaseColumns
		{
		}

		[Sharpen.Stub]
		public static class CanonicalAddressesColumnsClass
		{
			public const string ADDRESS = "address";
		}

		[Sharpen.Stub]
		public interface ThreadsColumns : android.provider.BaseColumns
		{
		}

		[Sharpen.Stub]
		public static class ThreadsColumnsClass
		{
			public const string DATE = "date";

			public const string RECIPIENT_IDS = "recipient_ids";

			public const string MESSAGE_COUNT = "message_count";

			public const string READ = "read";

			public const string SNIPPET = "snippet";

			public const string SNIPPET_CHARSET = "snippet_cs";

			public const string TYPE = "type";

			public const string ERROR = "error";

			public const string HAS_ATTACHMENT = "has_attachment";
		}

		[Sharpen.Stub]
		public sealed class Threads : android.provider.Telephony.ThreadsColumns
		{
			private static readonly string[] ID_PROJECTION = new string[] { android.provider.BaseColumnsClass._ID
				 };

			internal const string STANDARD_ENCODING = "UTF-8";

			private static readonly System.Uri THREAD_ID_CONTENT_URI = Sharpen.Util.ParseUri(
				"content://mms-sms/threadID");

			public static readonly System.Uri CONTENT_URI = Sharpen.Util.AppendUri(android.provider.Telephony
				.MmsSms.CONTENT_URI, "conversations");

			public static readonly System.Uri OBSOLETE_THREADS_URI = Sharpen.Util.AppendUri(CONTENT_URI
				, "obsolete");

			public const int COMMON_THREAD = 0;

			public const int BROADCAST_THREAD = 1;

			[Sharpen.Stub]
			private Threads()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static long getOrCreateThreadId(android.content.Context context, string recipient
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static long getOrCreateThreadId(android.content.Context context, java.util.Set
				<string> recipients)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public sealed class Mms : android.provider.Telephony.BaseMmsColumns
		{
			public static readonly System.Uri CONTENT_URI = Sharpen.Util.ParseUri("content://mms"
				);

			public static readonly System.Uri REPORT_REQUEST_URI = Sharpen.Util.AppendUri(CONTENT_URI
				, "report-request");

			public static readonly System.Uri REPORT_STATUS_URI = Sharpen.Util.AppendUri(CONTENT_URI
				, "report-status");

			public const string DEFAULT_SORT_ORDER = "date DESC";

			public static readonly java.util.regex.Pattern NAME_ADDR_EMAIL_PATTERN = java.util.regex.Pattern
				.compile("\\s*(\"[^\"]*\"|[^<>\"]+)\\s*<([^<>]+)>\\s*");

			public static readonly java.util.regex.Pattern QUOTED_STRING_PATTERN = java.util.regex.Pattern
				.compile("\\s*\"([^\"]*)\"\\s*");

			[Sharpen.Stub]
			public static android.database.Cursor query(android.content.ContentResolver cr, string
				[] projection)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.database.Cursor query(android.content.ContentResolver cr, string
				[] projection, string where, string orderBy)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static string getMessageBoxName(int msgBox)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static string extractAddrSpec(string address)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static bool isEmailAddress(string address)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static bool isPhoneNumber(string number)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public sealed class Inbox : android.provider.Telephony.BaseMmsColumns
			{
				public static readonly System.Uri CONTENT_URI = Sharpen.Util.ParseUri("content://mms/inbox"
					);

				public const string DEFAULT_SORT_ORDER = "date DESC";
			}

			[Sharpen.Stub]
			public sealed class Sent : android.provider.Telephony.BaseMmsColumns
			{
				public static readonly System.Uri CONTENT_URI = Sharpen.Util.ParseUri("content://mms/sent"
					);

				public const string DEFAULT_SORT_ORDER = "date DESC";
			}

			[Sharpen.Stub]
			public sealed class Draft : android.provider.Telephony.BaseMmsColumns
			{
				public static readonly System.Uri CONTENT_URI = Sharpen.Util.ParseUri("content://mms/drafts"
					);

				public const string DEFAULT_SORT_ORDER = "date DESC";
			}

			[Sharpen.Stub]
			public sealed class Outbox : android.provider.Telephony.BaseMmsColumns
			{
				public static readonly System.Uri CONTENT_URI = Sharpen.Util.ParseUri("content://mms/outbox"
					);

				public const string DEFAULT_SORT_ORDER = "date DESC";
			}

			[Sharpen.Stub]
			public sealed class Addr : android.provider.BaseColumns
			{
				public const string MSG_ID = "msg_id";

				public const string CONTACT_ID = "contact_id";

				public const string ADDRESS = "address";

				public const string TYPE = "type";

				public const string CHARSET = "charset";
			}

			[Sharpen.Stub]
			public sealed class Part : android.provider.BaseColumns
			{
				public const string MSG_ID = "mid";

				public const string SEQ = "seq";

				public const string CONTENT_TYPE = "ct";

				public const string NAME = "name";

				public const string CHARSET = "chset";

				public const string FILENAME = "fn";

				public const string CONTENT_DISPOSITION = "cd";

				public const string CONTENT_ID = "cid";

				public const string CONTENT_LOCATION = "cl";

				public const string CT_START = "ctt_s";

				public const string CT_TYPE = "ctt_t";

				public const string _DATA = "_data";

				public const string TEXT = "text";
			}

			[Sharpen.Stub]
			public sealed class Rate
			{
				public static readonly System.Uri CONTENT_URI = Sharpen.Util.AppendUri(android.provider.Telephony
					.Mms.CONTENT_URI, "rate");

				public const string SENT_TIME = "sent_time";
			}

			[Sharpen.Stub]
			public sealed class Intents
			{
				[Sharpen.Stub]
				private Intents()
				{
					throw new System.NotImplementedException();
				}

				public const string EXTRA_CONTENTS = "contents";

				public const string EXTRA_TYPES = "types";

				public const string EXTRA_CC = "cc";

				public const string EXTRA_BCC = "bcc";

				public const string EXTRA_SUBJECT = "subject";

				public const string CONTENT_CHANGED_ACTION = "android.intent.action.CONTENT_CHANGED";

				public const string DELETED_CONTENTS = "deleted_contents";
			}
		}

		[Sharpen.Stub]
		public sealed class MmsSms : android.provider.BaseColumns
		{
			public const string TYPE_DISCRIMINATOR_COLUMN = "transport_type";

			public static readonly System.Uri CONTENT_URI = Sharpen.Util.ParseUri("content://mms-sms/"
				);

			public static readonly System.Uri CONTENT_CONVERSATIONS_URI = Sharpen.Util.ParseUri
				("content://mms-sms/conversations");

			public static readonly System.Uri CONTENT_FILTER_BYPHONE_URI = Sharpen.Util.ParseUri
				("content://mms-sms/messages/byphone");

			public static readonly System.Uri CONTENT_UNDELIVERED_URI = Sharpen.Util.ParseUri
				("content://mms-sms/undelivered");

			public static readonly System.Uri CONTENT_DRAFT_URI = Sharpen.Util.ParseUri("content://mms-sms/draft"
				);

			public static readonly System.Uri CONTENT_LOCKED_URI = Sharpen.Util.ParseUri("content://mms-sms/locked"
				);

			public static readonly System.Uri SEARCH_URI = Sharpen.Util.ParseUri("content://mms-sms/search"
				);

			public const int SMS_PROTO = 0;

			public const int MMS_PROTO = 1;

			public const int NO_ERROR = 0;

			public const int ERR_TYPE_GENERIC = 1;

			public const int ERR_TYPE_SMS_PROTO_TRANSIENT = 2;

			public const int ERR_TYPE_MMS_PROTO_TRANSIENT = 3;

			public const int ERR_TYPE_TRANSPORT_FAILURE = 4;

			public const int ERR_TYPE_GENERIC_PERMANENT = 10;

			public const int ERR_TYPE_SMS_PROTO_PERMANENT = 11;

			public const int ERR_TYPE_MMS_PROTO_PERMANENT = 12;

			[Sharpen.Stub]
			public sealed class PendingMessages : android.provider.BaseColumns
			{
				public static readonly System.Uri CONTENT_URI = Sharpen.Util.AppendUri(android.provider.Telephony
					.MmsSms.CONTENT_URI, "pending");

				public const string PROTO_TYPE = "proto_type";

				public const string MSG_ID = "msg_id";

				public const string MSG_TYPE = "msg_type";

				public const string ERROR_TYPE = "err_type";

				public const string ERROR_CODE = "err_code";

				public const string RETRY_INDEX = "retry_index";

				public const string DUE_TIME = "due_time";

				public const string LAST_TRY = "last_try";
			}

			[Sharpen.Stub]
			public sealed class WordsTable
			{
				public const string ID = "_id";

				public const string SOURCE_ROW_ID = "source_id";

				public const string TABLE_ID = "table_to_use";

				public const string INDEXED_TEXT = "index_text";
			}
		}

		[Sharpen.Stub]
		public sealed class Carriers : android.provider.BaseColumns
		{
			public static readonly System.Uri CONTENT_URI = Sharpen.Util.ParseUri("content://telephony/carriers"
				);

			public const string DEFAULT_SORT_ORDER = "name ASC";

			public const string NAME = "name";

			public const string APN = "apn";

			public const string PROXY = "proxy";

			public const string PORT = "port";

			public const string MMSPROXY = "mmsproxy";

			public const string MMSPORT = "mmsport";

			public const string SERVER = "server";

			public const string USER = "user";

			public const string PASSWORD = "password";

			public const string MMSC = "mmsc";

			public const string MCC = "mcc";

			public const string MNC = "mnc";

			public const string NUMERIC = "numeric";

			public const string AUTH_TYPE = "authtype";

			public const string TYPE = "type";

			public const string INACTIVE_TIMER = "inactivetimer";

			public const string ENABLED = "enabled";

			public const string CLASS = "class";

			public const string PROTOCOL = "protocol";

			public const string ROAMING_PROTOCOL = "roaming_protocol";

			public const string CURRENT = "current";

			public const string CARRIER_ENABLED = "carrier_enabled";

			public const string BEARER = "bearer";
		}

		[Sharpen.Stub]
		public sealed class Intents
		{
			[Sharpen.Stub]
			private Intents()
			{
				throw new System.NotImplementedException();
			}

			public const string SECRET_CODE_ACTION = "android.provider.Telephony.SECRET_CODE";

			public const string SPN_STRINGS_UPDATED_ACTION = "android.provider.Telephony.SPN_STRINGS_UPDATED";

			public const string EXTRA_SHOW_PLMN = "showPlmn";

			public const string EXTRA_PLMN = "plmn";

			public const string EXTRA_SHOW_SPN = "showSpn";

			public const string EXTRA_SPN = "spn";
		}
	}
}

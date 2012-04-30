using Sharpen;

namespace android.provider
{
	[Sharpen.Stub]
	public sealed class ContactsContract
	{
		public const string AUTHORITY = "com.android.contacts";

		public static readonly System.Uri AUTHORITY_URI = Sharpen.Util.ParseUri("content://"
			 + AUTHORITY);

		public const string CALLER_IS_SYNCADAPTER = "caller_is_syncadapter";

		public const string DIRECTORY_PARAM_KEY = "directory";

		public const string LIMIT_PARAM_KEY = "limit";

		public const string PRIMARY_ACCOUNT_NAME = "name_for_primary_account";

		public const string PRIMARY_ACCOUNT_TYPE = "type_for_primary_account";

		public const string STREQUENT_PHONE_ONLY = "strequent_phone_only";

		public const string DEFERRED_SNIPPETING = "deferred_snippeting";

		public const string DEFERRED_SNIPPETING_QUERY = "deferred_snippeting_query";

		[Sharpen.Stub]
		public sealed class Authorization
		{
			public const string AUTHORIZATION_METHOD = "authorize";

			public const string KEY_URI_TO_AUTHORIZE = "uri_to_authorize";

			public const string KEY_AUTHORIZED_URI = "authorized_uri";
		}

		[Sharpen.Stub]
		public sealed class Preferences
		{
			public const string SORT_ORDER = "android.contacts.SORT_ORDER";

			public const int SORT_ORDER_PRIMARY = 1;

			public const int SORT_ORDER_ALTERNATIVE = 2;

			public const string DISPLAY_ORDER = "android.contacts.DISPLAY_ORDER";

			public const int DISPLAY_ORDER_PRIMARY = 1;

			public const int DISPLAY_ORDER_ALTERNATIVE = 2;
		}

		[Sharpen.Stub]
		public sealed class Directory : android.provider.BaseColumns
		{
			[Sharpen.Stub]
			private Directory()
			{
				throw new System.NotImplementedException();
			}

			public static readonly System.Uri CONTENT_URI = Sharpen.Util.AppendUri(AUTHORITY_URI
				, "directories");

			public const string CONTENT_TYPE = "vnd.android.cursor.dir/contact_directories";

			public const string CONTENT_ITEM_TYPE = "vnd.android.cursor.item/contact_directory";

			public const long DEFAULT = 0;

			public const long LOCAL_INVISIBLE = 1;

			public const string PACKAGE_NAME = "packageName";

			public const string TYPE_RESOURCE_ID = "typeResourceId";

			public const string DISPLAY_NAME = "displayName";

			public const string DIRECTORY_AUTHORITY = "authority";

			public const string ACCOUNT_TYPE = "accountType";

			public const string ACCOUNT_NAME = "accountName";

			public const string EXPORT_SUPPORT = "exportSupport";

			public const int EXPORT_SUPPORT_NONE = 0;

			public const int EXPORT_SUPPORT_SAME_ACCOUNT_ONLY = 1;

			public const int EXPORT_SUPPORT_ANY_ACCOUNT = 2;

			public const string SHORTCUT_SUPPORT = "shortcutSupport";

			public const int SHORTCUT_SUPPORT_NONE = 0;

			public const int SHORTCUT_SUPPORT_DATA_ITEMS_ONLY = 1;

			public const int SHORTCUT_SUPPORT_FULL = 2;

			public const string PHOTO_SUPPORT = "photoSupport";

			public const int PHOTO_SUPPORT_NONE = 0;

			public const int PHOTO_SUPPORT_THUMBNAIL_ONLY = 1;

			public const int PHOTO_SUPPORT_FULL_SIZE_ONLY = 2;

			public const int PHOTO_SUPPORT_FULL = 3;

			[Sharpen.Stub]
			public static void notifyDirectoryChange(android.content.ContentResolver resolver
				)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"use SyncState instead")]
		public interface SyncStateColumns : android.provider.SyncStateContract.Columns
		{
		}

		[Sharpen.Stub]
		public sealed class SyncState : android.provider.SyncStateContract.Columns
		{
			[Sharpen.Stub]
			private SyncState()
			{
				throw new System.NotImplementedException();
			}

			public static readonly string CONTENT_DIRECTORY = android.provider.SyncStateContract
				.Constants.CONTENT_DIRECTORY;

			public static readonly System.Uri CONTENT_URI = Sharpen.Util.AppendUri(AUTHORITY_URI
				, CONTENT_DIRECTORY);

			[Sharpen.Stub]
			public static byte[] get(android.content.ContentProviderClient provider, android.accounts.Account
				 account)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.util.Pair<System.Uri, byte[]> getWithUri(android.content.ContentProviderClient
				 provider, android.accounts.Account account)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static void set(android.content.ContentProviderClient provider, android.accounts.Account
				 account, byte[] data)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.content.ContentProviderOperation newSetOperation(android.accounts.Account
				 account, byte[] data)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public sealed class ProfileSyncState : android.provider.SyncStateContract.Columns
		{
			[Sharpen.Stub]
			private ProfileSyncState()
			{
				throw new System.NotImplementedException();
			}

			public static readonly string CONTENT_DIRECTORY = android.provider.SyncStateContract
				.Constants.CONTENT_DIRECTORY;

			public static readonly System.Uri CONTENT_URI = Sharpen.Util.AppendUri(android.provider.ContactsContract
				.Profile.CONTENT_URI, CONTENT_DIRECTORY);

			[Sharpen.Stub]
			public static byte[] get(android.content.ContentProviderClient provider, android.accounts.Account
				 account)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.util.Pair<System.Uri, byte[]> getWithUri(android.content.ContentProviderClient
				 provider, android.accounts.Account account)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static void set(android.content.ContentProviderClient provider, android.accounts.Account
				 account, byte[] data)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.content.ContentProviderOperation newSetOperation(android.accounts.Account
				 account, byte[] data)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		protected internal interface BaseSyncColumns
		{
		}

		[Sharpen.Stub]
		protected internal static class BaseSyncColumnsClass
		{
			public const string SYNC1 = "sync1";

			public const string SYNC2 = "sync2";

			public const string SYNC3 = "sync3";

			public const string SYNC4 = "sync4";
		}

		[Sharpen.Stub]
		protected internal interface SyncColumns : android.provider.ContactsContract.BaseSyncColumns
		{
		}

		[Sharpen.Stub]
		protected internal static class SyncColumnsClass
		{
			public const string ACCOUNT_NAME = "account_name";

			public const string ACCOUNT_TYPE = "account_type";

			public const string SOURCE_ID = "sourceid";

			public const string VERSION = "version";

			public const string DIRTY = "dirty";
		}

		[Sharpen.Stub]
		protected internal interface ContactOptionsColumns
		{
		}

		[Sharpen.Stub]
		protected internal static class ContactOptionsColumnsClass
		{
			public const string TIMES_CONTACTED = "times_contacted";

			public const string LAST_TIME_CONTACTED = "last_time_contacted";

			public const string STARRED = "starred";

			public const string CUSTOM_RINGTONE = "custom_ringtone";

			public const string SEND_TO_VOICEMAIL = "send_to_voicemail";
		}

		[Sharpen.Stub]
		protected internal interface ContactsColumns
		{
		}

		[Sharpen.Stub]
		protected internal static class ContactsColumnsClass
		{
			public static readonly string DISPLAY_NAME = android.provider.ContactsContract.ContactNameColumnsClass.DISPLAY_NAME_PRIMARY;

			public const string NAME_RAW_CONTACT_ID = "name_raw_contact_id";

			public const string PHOTO_ID = "photo_id";

			public const string PHOTO_FILE_ID = "photo_file_id";

			public const string PHOTO_URI = "photo_uri";

			public const string PHOTO_THUMBNAIL_URI = "photo_thumb_uri";

			public const string IN_VISIBLE_GROUP = "in_visible_group";

			public const string IS_USER_PROFILE = "is_user_profile";

			public const string HAS_PHONE_NUMBER = "has_phone_number";

			public const string LOOKUP_KEY = "lookup";
		}

		[Sharpen.Stub]
		protected internal interface ContactStatusColumns
		{
		}

		[Sharpen.Stub]
		protected internal static class ContactStatusColumnsClass
		{
			public const string CONTACT_PRESENCE = "contact_presence";

			public const string CONTACT_CHAT_CAPABILITY = "contact_chat_capability";

			public const string CONTACT_STATUS = "contact_status";

			public const string CONTACT_STATUS_TIMESTAMP = "contact_status_ts";

			public const string CONTACT_STATUS_RES_PACKAGE = "contact_status_res_package";

			public const string CONTACT_STATUS_LABEL = "contact_status_label";

			public const string CONTACT_STATUS_ICON = "contact_status_icon";
		}

		[Sharpen.Stub]
		public interface FullNameStyle
		{
		}

		[Sharpen.Stub]
		public static class FullNameStyleClass
		{
			public const int UNDEFINED = 0;

			public const int WESTERN = 1;

			public const int CJK = 2;

			public const int CHINESE = 3;

			public const int JAPANESE = 4;

			public const int KOREAN = 5;
		}

		[Sharpen.Stub]
		public interface PhoneticNameStyle
		{
		}

		[Sharpen.Stub]
		public static class PhoneticNameStyleClass
		{
			public const int UNDEFINED = 0;

			public const int PINYIN = 3;

			public const int JAPANESE = 4;

			public const int KOREAN = 5;
		}

		[Sharpen.Stub]
		public interface DisplayNameSources
		{
		}

		[Sharpen.Stub]
		public static class DisplayNameSourcesClass
		{
			public const int UNDEFINED = 0;

			public const int EMAIL = 10;

			public const int PHONE = 20;

			public const int ORGANIZATION = 30;

			public const int NICKNAME = 35;

			public const int STRUCTURED_NAME = 40;
		}

		[Sharpen.Stub]
		protected internal interface ContactNameColumns
		{
		}

		[Sharpen.Stub]
		protected internal static class ContactNameColumnsClass
		{
			public const string DISPLAY_NAME_SOURCE = "display_name_source";

			public const string DISPLAY_NAME_PRIMARY = "display_name";

			public const string DISPLAY_NAME_ALTERNATIVE = "display_name_alt";

			public const string PHONETIC_NAME_STYLE = "phonetic_name_style";

			public const string PHONETIC_NAME = "phonetic_name";

			public const string SORT_KEY_PRIMARY = "sort_key";

			public const string SORT_KEY_ALTERNATIVE = "sort_key_alt";
		}

		[Sharpen.Stub]
		public sealed class ContactCounts
		{
			public const string ADDRESS_BOOK_INDEX_EXTRAS = "address_book_index_extras";

			public const string EXTRA_ADDRESS_BOOK_INDEX_TITLES = "address_book_index_titles";

			public const string EXTRA_ADDRESS_BOOK_INDEX_COUNTS = "address_book_index_counts";
		}

		[Sharpen.Stub]
		public class Contacts : android.provider.BaseColumns, android.provider.ContactsContract
			.ContactsColumns, android.provider.ContactsContract.ContactOptionsColumns, android.provider.ContactsContract
			.ContactNameColumns, android.provider.ContactsContract.ContactStatusColumns
		{
			[Sharpen.Stub]
			private Contacts()
			{
				throw new System.NotImplementedException();
			}

			public static readonly System.Uri CONTENT_URI = Sharpen.Util.AppendUri(AUTHORITY_URI
				, "contacts");

			public static readonly System.Uri CONTENT_LOOKUP_URI = Sharpen.Util.AppendUri(CONTENT_URI
				, "lookup");

			public static readonly System.Uri CONTENT_VCARD_URI = Sharpen.Util.AppendUri(CONTENT_URI
				, "as_vcard");

			public const string QUERY_PARAMETER_VCARD_NO_PHOTO = "nophoto";

			public static readonly System.Uri CONTENT_MULTI_VCARD_URI = Sharpen.Util.AppendUri
				(CONTENT_URI, "as_multi_vcard");

			[Sharpen.Stub]
			public static System.Uri getLookupUri(android.content.ContentResolver resolver, System.Uri
				 contactUri)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static System.Uri getLookupUri(long contactId, string lookupKey)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static System.Uri lookupContact(android.content.ContentResolver resolver, 
				System.Uri lookupUri)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static void markAsContacted(android.content.ContentResolver resolver, long
				 contactId)
			{
				throw new System.NotImplementedException();
			}

			public static readonly System.Uri CONTENT_FILTER_URI = Sharpen.Util.AppendUri(CONTENT_URI
				, "filter");

			public static readonly System.Uri CONTENT_STREQUENT_URI = Sharpen.Util.AppendUri(
				CONTENT_URI, "strequent");

			public static readonly System.Uri CONTENT_FREQUENT_URI = Sharpen.Util.AppendUri(CONTENT_URI
				, "frequent");

			public static readonly System.Uri CONTENT_STREQUENT_FILTER_URI = Sharpen.Util.AppendUri
				(CONTENT_STREQUENT_URI, "filter");

			public static readonly System.Uri CONTENT_GROUP_URI = Sharpen.Util.AppendUri(CONTENT_URI
				, "group");

			public const string CONTENT_TYPE = "vnd.android.cursor.dir/contact";

			public const string CONTENT_ITEM_TYPE = "vnd.android.cursor.item/contact";

			public const string CONTENT_VCARD_TYPE = "text/x-vcard";

			[Sharpen.Stub]
			public sealed class Data : android.provider.BaseColumns, android.provider.ContactsContract
				.DataColumns
			{
				[Sharpen.Stub]
				private Data()
				{
					throw new System.NotImplementedException();
				}

				public const string CONTENT_DIRECTORY = "data";
			}

			[Sharpen.Stub]
			public sealed class Entity : android.provider.BaseColumns, android.provider.ContactsContract
				.ContactsColumns, android.provider.ContactsContract.ContactNameColumns, android.provider.ContactsContract
				.RawContactsColumns, android.provider.ContactsContract.BaseSyncColumns, android.provider.ContactsContract
				.SyncColumns, android.provider.ContactsContract.DataColumns, android.provider.ContactsContract
				.StatusColumns, android.provider.ContactsContract.ContactOptionsColumns, android.provider.ContactsContract
				.ContactStatusColumns
			{
				[Sharpen.Stub]
				private Entity()
				{
					throw new System.NotImplementedException();
				}

				public const string CONTENT_DIRECTORY = "entities";

				public const string RAW_CONTACT_ID = "raw_contact_id";

				public const string DATA_ID = "data_id";
			}

			[Sharpen.Stub]
			public sealed class StreamItems : android.provider.ContactsContract.StreamItemsColumns
			{
				[Sharpen.Stub]
				private StreamItems()
				{
					throw new System.NotImplementedException();
				}

				public const string CONTENT_DIRECTORY = "stream_items";
			}

			[Sharpen.Stub]
			public sealed class AggregationSuggestions : android.provider.BaseColumns, android.provider.ContactsContract
				.ContactsColumns, android.provider.ContactsContract.ContactOptionsColumns, android.provider.ContactsContract
				.ContactStatusColumns
			{
				[Sharpen.Stub]
				private AggregationSuggestions()
				{
					throw new System.NotImplementedException();
				}

				public const string CONTENT_DIRECTORY = "suggestions";

				public const string PARAMETER_MATCH_NAME = "name";

				public const string PARAMETER_MATCH_EMAIL = "email";

				public const string PARAMETER_MATCH_PHONE = "phone";

				public const string PARAMETER_MATCH_NICKNAME = "nickname";

				[Sharpen.Stub]
				public sealed class Builder
				{
					private long mContactId;

					private java.util.ArrayList<string> mKinds = new java.util.ArrayList<string>();

					private java.util.ArrayList<string> mValues = new java.util.ArrayList<string>();

					private int mLimit;

					[Sharpen.Stub]
					public android.provider.ContactsContract.Contacts.AggregationSuggestions.Builder 
						setContactId(long contactId)
					{
						throw new System.NotImplementedException();
					}

					[Sharpen.Stub]
					public android.provider.ContactsContract.Contacts.AggregationSuggestions.Builder 
						addParameter(string kind, string value)
					{
						throw new System.NotImplementedException();
					}

					[Sharpen.Stub]
					public android.provider.ContactsContract.Contacts.AggregationSuggestions.Builder 
						setLimit(int limit)
					{
						throw new System.NotImplementedException();
					}

					[Sharpen.Stub]
					public System.Uri build()
					{
						throw new System.NotImplementedException();
					}
				}

				[Sharpen.Stub]
				public static android.provider.ContactsContract.Contacts.AggregationSuggestions.Builder
					 builder()
				{
					throw new System.NotImplementedException();
				}
			}

			[Sharpen.Stub]
			public sealed class Photo : android.provider.BaseColumns, android.provider.ContactsContract
				.DataColumnsWithJoins
			{
				[Sharpen.Stub]
				private Photo()
				{
					throw new System.NotImplementedException();
				}

				public const string CONTENT_DIRECTORY = "photo";

				public const string DISPLAY_PHOTO = "display_photo";

				public static readonly string PHOTO_FILE_ID = android.provider.ContactsContract.DataColumnsClass.DATA14;

				public static readonly string PHOTO = android.provider.ContactsContract.DataColumnsClass.DATA15;
			}

			[Sharpen.Stub]
			public static java.io.InputStream openContactPhotoInputStream(android.content.ContentResolver
				 cr, System.Uri contactUri, bool preferHighres)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static java.io.InputStream openContactPhotoInputStream(android.content.ContentResolver
				 cr, System.Uri contactUri)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public sealed class Profile : android.provider.BaseColumns, android.provider.ContactsContract
			.ContactsColumns, android.provider.ContactsContract.ContactOptionsColumns, android.provider.ContactsContract
			.ContactNameColumns, android.provider.ContactsContract.ContactStatusColumns
		{
			[Sharpen.Stub]
			private Profile()
			{
				throw new System.NotImplementedException();
			}

			public static readonly System.Uri CONTENT_URI = Sharpen.Util.AppendUri(AUTHORITY_URI
				, "profile");

			public static readonly System.Uri CONTENT_VCARD_URI = Sharpen.Util.AppendUri(CONTENT_URI
				, "as_vcard");

			public static readonly System.Uri CONTENT_RAW_CONTACTS_URI = Sharpen.Util.AppendUri
				(CONTENT_URI, "raw_contacts");

			public const long MIN_ID = long.MaxValue - (long)int.MaxValue;
		}

		[Sharpen.Stub]
		public static bool isProfileId(long id)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal interface RawContactsColumns
		{
		}

		[Sharpen.Stub]
		protected internal static class RawContactsColumnsClass
		{
			public const string CONTACT_ID = "contact_id";

			public const string DATA_SET = "data_set";

			public const string ACCOUNT_TYPE_AND_DATA_SET = "account_type_and_data_set";

			public const string AGGREGATION_MODE = "aggregation_mode";

			public const string DELETED = "deleted";

			public const string NAME_VERIFIED = "name_verified";

			public const string RAW_CONTACT_IS_READ_ONLY = "raw_contact_is_read_only";

			public const string RAW_CONTACT_IS_USER_PROFILE = "raw_contact_is_user_profile";
		}

		[Sharpen.Stub]
		public sealed class RawContacts : android.provider.BaseColumns, android.provider.ContactsContract
			.RawContactsColumns, android.provider.ContactsContract.ContactOptionsColumns, android.provider.ContactsContract
			.ContactNameColumns, android.provider.ContactsContract.SyncColumns
		{
			[Sharpen.Stub]
			private RawContacts()
			{
				throw new System.NotImplementedException();
			}

			public static readonly System.Uri CONTENT_URI = Sharpen.Util.AppendUri(AUTHORITY_URI
				, "raw_contacts");

			public const string CONTENT_TYPE = "vnd.android.cursor.dir/raw_contact";

			public const string CONTENT_ITEM_TYPE = "vnd.android.cursor.item/raw_contact";

			public const int AGGREGATION_MODE_DEFAULT = 0;

			[System.ObsoleteAttribute(@"Aggregation is synchronous, this historic value is a no-op"
				)]
			public const int AGGREGATION_MODE_IMMEDIATE = 1;

			public const int AGGREGATION_MODE_SUSPENDED = 2;

			public const int AGGREGATION_MODE_DISABLED = 3;

			[Sharpen.Stub]
			public static System.Uri getContactLookupUri(android.content.ContentResolver resolver
				, System.Uri rawContactUri)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public sealed class Data : android.provider.BaseColumns, android.provider.ContactsContract
				.DataColumns
			{
				[Sharpen.Stub]
				private Data()
				{
					throw new System.NotImplementedException();
				}

				public const string CONTENT_DIRECTORY = "data";
			}

			[Sharpen.Stub]
			public sealed class Entity : android.provider.BaseColumns, android.provider.ContactsContract
				.DataColumns
			{
				[Sharpen.Stub]
				private Entity()
				{
					throw new System.NotImplementedException();
				}

				public const string CONTENT_DIRECTORY = "entity";

				public const string DATA_ID = "data_id";
			}

			[Sharpen.Stub]
			public sealed class StreamItems : android.provider.BaseColumns, android.provider.ContactsContract
				.StreamItemsColumns
			{
				[Sharpen.Stub]
				private StreamItems()
				{
					throw new System.NotImplementedException();
				}

				public const string CONTENT_DIRECTORY = "stream_items";
			}

			[Sharpen.Stub]
			public sealed class DisplayPhoto
			{
				[Sharpen.Stub]
				private DisplayPhoto()
				{
					throw new System.NotImplementedException();
				}

				public const string CONTENT_DIRECTORY = "display_photo";
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
				internal static readonly string[] DATA_KEYS = new string[] { android.provider.ContactsContract.DataColumnsClass.DATA1
					, android.provider.ContactsContract.DataColumnsClass.DATA2, android.provider.ContactsContract.DataColumnsClass.DATA3
					, android.provider.ContactsContract.DataColumnsClass.DATA4, android.provider.ContactsContract.DataColumnsClass.DATA5
					, android.provider.ContactsContract.DataColumnsClass.DATA6, android.provider.ContactsContract.DataColumnsClass.DATA7
					, android.provider.ContactsContract.DataColumnsClass.DATA8, android.provider.ContactsContract.DataColumnsClass.DATA9
					, android.provider.ContactsContract.DataColumnsClass.DATA10, android.provider.ContactsContract.DataColumnsClass.DATA11
					, android.provider.ContactsContract.DataColumnsClass.DATA12, android.provider.ContactsContract.DataColumnsClass.DATA13
					, android.provider.ContactsContract.DataColumnsClass.DATA14, android.provider.ContactsContract.DataColumnsClass.DATA15
					, android.provider.ContactsContract.DataColumnsClass.SYNC1, android.provider.ContactsContract.DataColumnsClass.SYNC2
					, android.provider.ContactsContract.DataColumnsClass.SYNC3, android.provider.ContactsContract.DataColumnsClass.SYNC4
					 };

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
		protected internal interface StatusColumns
		{
		}

		[Sharpen.Stub]
		protected internal static class StatusColumnsClass
		{
			public const string PRESENCE = "mode";

			[System.ObsoleteAttribute(@"use android.provider.ContactsContract.StatusColumnsClass.PRESENCE"
				)]
			public static readonly string PRESENCE_STATUS = android.provider.ContactsContract.StatusColumnsClass.PRESENCE;

			public const int OFFLINE = 0;

			public const int INVISIBLE = 1;

			public const int AWAY = 2;

			public const int IDLE = 3;

			public const int DO_NOT_DISTURB = 4;

			public const int AVAILABLE = 5;

			public const string STATUS = "status";

			[System.ObsoleteAttribute(@"use android.provider.ContactsContract.StatusColumnsClass.STATUS"
				)]
			public static readonly string PRESENCE_CUSTOM_STATUS = android.provider.ContactsContract.StatusColumnsClass.STATUS;

			public const string STATUS_TIMESTAMP = "status_ts";

			public const string STATUS_RES_PACKAGE = "status_res_package";

			public const string STATUS_LABEL = "status_label";

			public const string STATUS_ICON = "status_icon";

			public const string CHAT_CAPABILITY = "chat_capability";

			public const int CAPABILITY_HAS_VOICE = 1;

			public const int CAPABILITY_HAS_VIDEO = 2;

			public const int CAPABILITY_HAS_CAMERA = 4;
		}

		[Sharpen.Stub]
		public sealed class StreamItems : android.provider.BaseColumns, android.provider.ContactsContract
			.StreamItemsColumns
		{
			[Sharpen.Stub]
			private StreamItems()
			{
				throw new System.NotImplementedException();
			}

			public static readonly System.Uri CONTENT_URI = Sharpen.Util.AppendUri(AUTHORITY_URI
				, "stream_items");

			public static readonly System.Uri CONTENT_PHOTO_URI = Sharpen.Util.AppendUri(CONTENT_URI
				, "photo");

			public static readonly System.Uri CONTENT_LIMIT_URI = Sharpen.Util.AppendUri(AUTHORITY_URI
				, "stream_items_limit");

			public const string CONTENT_TYPE = "vnd.android.cursor.dir/stream_item";

			public const string CONTENT_ITEM_TYPE = "vnd.android.cursor.item/stream_item";

			public const string MAX_ITEMS = "max_items";

			[Sharpen.Stub]
			public sealed class StreamItemPhotos : android.provider.BaseColumns, android.provider.ContactsContract
				.StreamItemPhotosColumns
			{
				[Sharpen.Stub]
				private StreamItemPhotos()
				{
					throw new System.NotImplementedException();
				}

				public const string CONTENT_DIRECTORY = "photo";

				public const string CONTENT_TYPE = "vnd.android.cursor.dir/stream_item_photo";

				public const string CONTENT_ITEM_TYPE = "vnd.android.cursor.item/stream_item_photo";
			}
		}

		[Sharpen.Stub]
		protected internal interface StreamItemsColumns
		{
		}

		[Sharpen.Stub]
		protected internal static class StreamItemsColumnsClass
		{
			public const string CONTACT_ID = "contact_id";

			public const string CONTACT_LOOKUP_KEY = "contact_lookup";

			public const string RAW_CONTACT_ID = "raw_contact_id";

			public const string RES_PACKAGE = "res_package";

			public const string ACCOUNT_TYPE = "account_type";

			public const string ACCOUNT_NAME = "account_name";

			public const string DATA_SET = "data_set";

			public const string RAW_CONTACT_SOURCE_ID = "raw_contact_source_id";

			public const string RES_ICON = "icon";

			public const string RES_LABEL = "label";

			public const string TEXT = "text";

			public const string TIMESTAMP = "timestamp";

			public const string COMMENTS = "comments";

			public const string SYNC1 = "stream_item_sync1";

			public const string SYNC2 = "stream_item_sync2";

			public const string SYNC3 = "stream_item_sync3";

			public const string SYNC4 = "stream_item_sync4";
		}

		[Sharpen.Stub]
		public sealed class StreamItemPhotos : android.provider.BaseColumns, android.provider.ContactsContract
			.StreamItemPhotosColumns
		{
			[Sharpen.Stub]
			private StreamItemPhotos()
			{
				throw new System.NotImplementedException();
			}

			public const string PHOTO = "photo";
		}

		[Sharpen.Stub]
		protected internal interface StreamItemPhotosColumns
		{
		}

		[Sharpen.Stub]
		protected internal static class StreamItemPhotosColumnsClass
		{
			public const string STREAM_ITEM_ID = "stream_item_id";

			public const string SORT_INDEX = "sort_index";

			public const string PHOTO_FILE_ID = "photo_file_id";

			public const string PHOTO_URI = "photo_uri";

			public const string SYNC1 = "stream_item_photo_sync1";

			public const string SYNC2 = "stream_item_photo_sync2";

			public const string SYNC3 = "stream_item_photo_sync3";

			public const string SYNC4 = "stream_item_photo_sync4";
		}

		[Sharpen.Stub]
		public sealed class PhotoFiles : android.provider.BaseColumns, android.provider.ContactsContract
			.PhotoFilesColumns
		{
			[Sharpen.Stub]
			private PhotoFiles()
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		protected internal interface PhotoFilesColumns
		{
		}

		[Sharpen.Stub]
		protected internal static class PhotoFilesColumnsClass
		{
			public const string HEIGHT = "height";

			public const string WIDTH = "width";

			public const string FILESIZE = "filesize";
		}

		[Sharpen.Stub]
		protected internal interface DataColumns
		{
		}

		[Sharpen.Stub]
		protected internal static class DataColumnsClass
		{
			public const string RES_PACKAGE = "res_package";

			public const string MIMETYPE = "mimetype";

			public const string RAW_CONTACT_ID = "raw_contact_id";

			public const string IS_PRIMARY = "is_primary";

			public const string IS_SUPER_PRIMARY = "is_super_primary";

			public const string IS_READ_ONLY = "is_read_only";

			public const string DATA_VERSION = "data_version";

			public const string DATA1 = "data1";

			public const string DATA2 = "data2";

			public const string DATA3 = "data3";

			public const string DATA4 = "data4";

			public const string DATA5 = "data5";

			public const string DATA6 = "data6";

			public const string DATA7 = "data7";

			public const string DATA8 = "data8";

			public const string DATA9 = "data9";

			public const string DATA10 = "data10";

			public const string DATA11 = "data11";

			public const string DATA12 = "data12";

			public const string DATA13 = "data13";

			public const string DATA14 = "data14";

			public const string DATA15 = "data15";

			public const string SYNC1 = "data_sync1";

			public const string SYNC2 = "data_sync2";

			public const string SYNC3 = "data_sync3";

			public const string SYNC4 = "data_sync4";
		}

		[Sharpen.Stub]
		protected internal interface DataColumnsWithJoins : android.provider.BaseColumns, 
			android.provider.ContactsContract.DataColumns, android.provider.ContactsContract
			.StatusColumns, android.provider.ContactsContract.RawContactsColumns, android.provider.ContactsContract
			.ContactsColumns, android.provider.ContactsContract.ContactNameColumns, android.provider.ContactsContract
			.ContactOptionsColumns, android.provider.ContactsContract.ContactStatusColumns
		{
		}

		[Sharpen.Stub]
		public sealed class Data : android.provider.ContactsContract.DataColumnsWithJoins
		{
			[Sharpen.Stub]
			private Data()
			{
				throw new System.NotImplementedException();
			}

			public static readonly System.Uri CONTENT_URI = Sharpen.Util.AppendUri(AUTHORITY_URI
				, "data");

			public const string CONTENT_TYPE = "vnd.android.cursor.dir/data";

			[Sharpen.Stub]
			public static System.Uri getContactLookupUri(android.content.ContentResolver resolver
				, System.Uri dataUri)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public sealed class RawContactsEntity : android.provider.BaseColumns, android.provider.ContactsContract
			.DataColumns, android.provider.ContactsContract.RawContactsColumns
		{
			[Sharpen.Stub]
			private RawContactsEntity()
			{
				throw new System.NotImplementedException();
			}

			public static readonly System.Uri CONTENT_URI = Sharpen.Util.AppendUri(AUTHORITY_URI
				, "raw_contact_entities");

			public static readonly System.Uri PROFILE_CONTENT_URI = Sharpen.Util.AppendUri(android.provider.ContactsContract
				.Profile.CONTENT_URI, "raw_contact_entities");

			public const string CONTENT_TYPE = "vnd.android.cursor.dir/raw_contact_entity";

			public const string FOR_EXPORT_ONLY = "for_export_only";

			public const string DATA_ID = "data_id";
		}

		[Sharpen.Stub]
		protected internal interface PhoneLookupColumns
		{
		}

		[Sharpen.Stub]
		protected internal static class PhoneLookupColumnsClass
		{
			public const string NUMBER = "number";

			public const string TYPE = "type";

			public const string LABEL = "label";

			public const string NORMALIZED_NUMBER = "normalized_number";
		}

		[Sharpen.Stub]
		public sealed class PhoneLookup : android.provider.BaseColumns, android.provider.ContactsContract
			.PhoneLookupColumns, android.provider.ContactsContract.ContactsColumns, android.provider.ContactsContract
			.ContactOptionsColumns
		{
			[Sharpen.Stub]
			private PhoneLookup()
			{
				throw new System.NotImplementedException();
			}

			public static readonly System.Uri CONTENT_FILTER_URI = Sharpen.Util.AppendUri(AUTHORITY_URI
				, "phone_lookup");

			public const string CONTENT_TYPE = "vnd.android.cursor.dir/phone_lookup";
		}

		[Sharpen.Stub]
		protected internal interface PresenceColumns
		{
		}

		[Sharpen.Stub]
		protected internal static class PresenceColumnsClass
		{
			public const string DATA_ID = "presence_data_id";

			public const string PROTOCOL = "protocol";

			public const string CUSTOM_PROTOCOL = "custom_protocol";

			public const string IM_HANDLE = "im_handle";

			public const string IM_ACCOUNT = "im_account";
		}

		[Sharpen.Stub]
		public abstract class StatusUpdates : android.provider.ContactsContract.StatusColumns
			, android.provider.ContactsContract.PresenceColumns
		{
			public static readonly System.Uri CONTENT_URI = Sharpen.Util.AppendUri(AUTHORITY_URI
				, "status_updates");

			public static readonly System.Uri PROFILE_CONTENT_URI = Sharpen.Util.AppendUri(android.provider.ContactsContract
				.Profile.CONTENT_URI, "status_updates");

			[Sharpen.Stub]
			public static int getPresenceIconResourceId(int status)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static int getPresencePrecedence(int status)
			{
				throw new System.NotImplementedException();
			}

			public const string CONTENT_TYPE = "vnd.android.cursor.dir/status-update";

			public const string CONTENT_ITEM_TYPE = "vnd.android.cursor.item/status-update";
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"This old name was never meant to be made public. Do not use."
			)]
		public sealed class Presence : android.provider.ContactsContract.StatusUpdates
		{
		}

		[Sharpen.Stub]
		public class SearchSnippetColumns
		{
			public const string SNIPPET = "snippet";

			public const string SNIPPET_ARGS_PARAM_KEY = "snippet_args";

			public const string DEFERRED_SNIPPETING_KEY = "deferred_snippeting";
		}

		[Sharpen.Stub]
		public sealed class CommonDataKinds
		{
			[Sharpen.Stub]
			private CommonDataKinds()
			{
				throw new System.NotImplementedException();
			}

			public const string PACKAGE_COMMON = "common";

			[Sharpen.Stub]
			public interface BaseTypes
			{
			}

			[Sharpen.Stub]
			public static class BaseTypesClass
			{
				public const int TYPE_CUSTOM = 0;
			}

			[Sharpen.Stub]
			protected internal interface CommonColumns : android.provider.ContactsContract.CommonDataKinds
				.BaseTypes
			{
			}

			[Sharpen.Stub]
			protected internal static class CommonColumnsClass
			{
				public static readonly string DATA = android.provider.ContactsContract.DataColumnsClass.DATA1;

				public static readonly string TYPE = android.provider.ContactsContract.DataColumnsClass.DATA2;

				public static readonly string LABEL = android.provider.ContactsContract.DataColumnsClass.DATA3;
			}

			[Sharpen.Stub]
			public sealed class StructuredName : android.provider.ContactsContract.DataColumnsWithJoins
			{
				[Sharpen.Stub]
				private StructuredName()
				{
					throw new System.NotImplementedException();
				}

				public const string CONTENT_ITEM_TYPE = "vnd.android.cursor.item/name";

				public static readonly string DISPLAY_NAME = android.provider.ContactsContract.DataColumnsClass.DATA1;

				public static readonly string GIVEN_NAME = android.provider.ContactsContract.DataColumnsClass.DATA2;

				public static readonly string FAMILY_NAME = android.provider.ContactsContract.DataColumnsClass.DATA3;

				public static readonly string PREFIX = android.provider.ContactsContract.DataColumnsClass.DATA4;

				public static readonly string MIDDLE_NAME = android.provider.ContactsContract.DataColumnsClass.DATA5;

				public static readonly string SUFFIX = android.provider.ContactsContract.DataColumnsClass.DATA6;

				public static readonly string PHONETIC_GIVEN_NAME = android.provider.ContactsContract.DataColumnsClass.DATA7;

				public static readonly string PHONETIC_MIDDLE_NAME = android.provider.ContactsContract.DataColumnsClass.DATA8;

				public static readonly string PHONETIC_FAMILY_NAME = android.provider.ContactsContract.DataColumnsClass.DATA9;

				public static readonly string FULL_NAME_STYLE = android.provider.ContactsContract.DataColumnsClass.DATA10;

				public static readonly string PHONETIC_NAME_STYLE = android.provider.ContactsContract.DataColumnsClass.DATA11;
			}

			[Sharpen.Stub]
			public sealed class Nickname : android.provider.ContactsContract.DataColumnsWithJoins
				, android.provider.ContactsContract.CommonDataKinds.CommonColumns
			{
				[Sharpen.Stub]
				private Nickname()
				{
					throw new System.NotImplementedException();
				}

				public const string CONTENT_ITEM_TYPE = "vnd.android.cursor.item/nickname";

				public const int TYPE_DEFAULT = 1;

				public const int TYPE_OTHER_NAME = 2;

				public const int TYPE_MAIDEN_NAME = 3;

				[System.ObsoleteAttribute(@"Use TYPE_MAIDEN_NAME instead.")]
				public const int TYPE_MAINDEN_NAME = 3;

				public const int TYPE_SHORT_NAME = 4;

				public const int TYPE_INITIALS = 5;

				public static readonly string NAME = android.provider.ContactsContract.CommonDataKinds.CommonColumnsClass.DATA;
			}

			[Sharpen.Stub]
			public sealed class Phone : android.provider.ContactsContract.DataColumnsWithJoins
				, android.provider.ContactsContract.CommonDataKinds.CommonColumns
			{
				[Sharpen.Stub]
				private Phone()
				{
					throw new System.NotImplementedException();
				}

				public const string CONTENT_ITEM_TYPE = "vnd.android.cursor.item/phone_v2";

				public const string CONTENT_TYPE = "vnd.android.cursor.dir/phone_v2";

				public static readonly System.Uri CONTENT_URI = Sharpen.Util.AppendUri(android.provider.ContactsContract
					.Data.CONTENT_URI, "phones");

				public static readonly System.Uri CONTENT_FILTER_URI = Sharpen.Util.AppendUri(CONTENT_URI
					, "filter");

				public const int TYPE_HOME = 1;

				public const int TYPE_MOBILE = 2;

				public const int TYPE_WORK = 3;

				public const int TYPE_FAX_WORK = 4;

				public const int TYPE_FAX_HOME = 5;

				public const int TYPE_PAGER = 6;

				public const int TYPE_OTHER = 7;

				public const int TYPE_CALLBACK = 8;

				public const int TYPE_CAR = 9;

				public const int TYPE_COMPANY_MAIN = 10;

				public const int TYPE_ISDN = 11;

				public const int TYPE_MAIN = 12;

				public const int TYPE_OTHER_FAX = 13;

				public const int TYPE_RADIO = 14;

				public const int TYPE_TELEX = 15;

				public const int TYPE_TTY_TDD = 16;

				public const int TYPE_WORK_MOBILE = 17;

				public const int TYPE_WORK_PAGER = 18;

				public const int TYPE_ASSISTANT = 19;

				public const int TYPE_MMS = 20;

				public static readonly string NUMBER = android.provider.ContactsContract.CommonDataKinds.CommonColumnsClass.DATA;

				public static readonly string NORMALIZED_NUMBER = android.provider.ContactsContract.DataColumnsClass.DATA4;

				[Sharpen.Stub]
				[System.ObsoleteAttribute(@"use getTypeLabel(android.content.res.Resources, int, java.lang.CharSequence) instead."
					)]
				public static java.lang.CharSequence getDisplayLabel(android.content.Context context
					, int type, java.lang.CharSequence label, java.lang.CharSequence[] labelArray)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[System.ObsoleteAttribute(@"use getTypeLabel(android.content.res.Resources, int, java.lang.CharSequence) instead."
					)]
				public static java.lang.CharSequence getDisplayLabel(android.content.Context context
					, int type, java.lang.CharSequence label)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				public static int getTypeLabelResource(int type)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				public static java.lang.CharSequence getTypeLabel(android.content.res.Resources res
					, int type, java.lang.CharSequence label)
				{
					throw new System.NotImplementedException();
				}
			}

			[Sharpen.Stub]
			public sealed class Email : android.provider.ContactsContract.DataColumnsWithJoins
				, android.provider.ContactsContract.CommonDataKinds.CommonColumns
			{
				[Sharpen.Stub]
				private Email()
				{
					throw new System.NotImplementedException();
				}

				public const string CONTENT_ITEM_TYPE = "vnd.android.cursor.item/email_v2";

				public const string CONTENT_TYPE = "vnd.android.cursor.dir/email_v2";

				public static readonly System.Uri CONTENT_URI = Sharpen.Util.AppendUri(android.provider.ContactsContract
					.Data.CONTENT_URI, "emails");

				public static readonly System.Uri CONTENT_LOOKUP_URI = Sharpen.Util.AppendUri(CONTENT_URI
					, "lookup");

				public static readonly System.Uri CONTENT_FILTER_URI = Sharpen.Util.AppendUri(CONTENT_URI
					, "filter");

				public static readonly string ADDRESS = android.provider.ContactsContract.DataColumnsClass.DATA1;

				public const int TYPE_HOME = 1;

				public const int TYPE_WORK = 2;

				public const int TYPE_OTHER = 3;

				public const int TYPE_MOBILE = 4;

				public static readonly string DISPLAY_NAME = android.provider.ContactsContract.DataColumnsClass.DATA4;

				[Sharpen.Stub]
				public static int getTypeLabelResource(int type)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				public static java.lang.CharSequence getTypeLabel(android.content.res.Resources res
					, int type, java.lang.CharSequence label)
				{
					throw new System.NotImplementedException();
				}
			}

			[Sharpen.Stub]
			public sealed class StructuredPostal : android.provider.ContactsContract.DataColumnsWithJoins
				, android.provider.ContactsContract.CommonDataKinds.CommonColumns
			{
				[Sharpen.Stub]
				private StructuredPostal()
				{
					throw new System.NotImplementedException();
				}

				public const string CONTENT_ITEM_TYPE = "vnd.android.cursor.item/postal-address_v2";

				public const string CONTENT_TYPE = "vnd.android.cursor.dir/postal-address_v2";

				public static readonly System.Uri CONTENT_URI = Sharpen.Util.AppendUri(android.provider.ContactsContract
					.Data.CONTENT_URI, "postals");

				public const int TYPE_HOME = 1;

				public const int TYPE_WORK = 2;

				public const int TYPE_OTHER = 3;

				public static readonly string FORMATTED_ADDRESS = android.provider.ContactsContract.CommonDataKinds.CommonColumnsClass.DATA;

				public static readonly string STREET = android.provider.ContactsContract.DataColumnsClass.DATA4;

				public static readonly string POBOX = android.provider.ContactsContract.DataColumnsClass.DATA5;

				public static readonly string NEIGHBORHOOD = android.provider.ContactsContract.DataColumnsClass.DATA6;

				public static readonly string CITY = android.provider.ContactsContract.DataColumnsClass.DATA7;

				public static readonly string REGION = android.provider.ContactsContract.DataColumnsClass.DATA8;

				public static readonly string POSTCODE = android.provider.ContactsContract.DataColumnsClass.DATA9;

				public static readonly string COUNTRY = android.provider.ContactsContract.DataColumnsClass.DATA10;

				[Sharpen.Stub]
				public static int getTypeLabelResource(int type)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				public static java.lang.CharSequence getTypeLabel(android.content.res.Resources res
					, int type, java.lang.CharSequence label)
				{
					throw new System.NotImplementedException();
				}
			}

			[Sharpen.Stub]
			public sealed class Im : android.provider.ContactsContract.DataColumnsWithJoins, 
				android.provider.ContactsContract.CommonDataKinds.CommonColumns
			{
				[Sharpen.Stub]
				private Im()
				{
					throw new System.NotImplementedException();
				}

				public const string CONTENT_ITEM_TYPE = "vnd.android.cursor.item/im";

				public const int TYPE_HOME = 1;

				public const int TYPE_WORK = 2;

				public const int TYPE_OTHER = 3;

				public static readonly string PROTOCOL = android.provider.ContactsContract.DataColumnsClass.DATA5;

				public static readonly string CUSTOM_PROTOCOL = android.provider.ContactsContract.DataColumnsClass.DATA6;

				public const int PROTOCOL_CUSTOM = -1;

				public const int PROTOCOL_AIM = 0;

				public const int PROTOCOL_MSN = 1;

				public const int PROTOCOL_YAHOO = 2;

				public const int PROTOCOL_SKYPE = 3;

				public const int PROTOCOL_QQ = 4;

				public const int PROTOCOL_GOOGLE_TALK = 5;

				public const int PROTOCOL_ICQ = 6;

				public const int PROTOCOL_JABBER = 7;

				public const int PROTOCOL_NETMEETING = 8;

				[Sharpen.Stub]
				public static int getTypeLabelResource(int type)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				public static java.lang.CharSequence getTypeLabel(android.content.res.Resources res
					, int type, java.lang.CharSequence label)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				public static int getProtocolLabelResource(int type)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				public static java.lang.CharSequence getProtocolLabel(android.content.res.Resources
					 res, int type, java.lang.CharSequence label)
				{
					throw new System.NotImplementedException();
				}
			}

			[Sharpen.Stub]
			public sealed class Organization : android.provider.ContactsContract.DataColumnsWithJoins
				, android.provider.ContactsContract.CommonDataKinds.CommonColumns
			{
				[Sharpen.Stub]
				private Organization()
				{
					throw new System.NotImplementedException();
				}

				public const string CONTENT_ITEM_TYPE = "vnd.android.cursor.item/organization";

				public const int TYPE_WORK = 1;

				public const int TYPE_OTHER = 2;

				public static readonly string COMPANY = android.provider.ContactsContract.CommonDataKinds.CommonColumnsClass.DATA;

				public static readonly string TITLE = android.provider.ContactsContract.DataColumnsClass.DATA4;

				public static readonly string DEPARTMENT = android.provider.ContactsContract.DataColumnsClass.DATA5;

				public static readonly string JOB_DESCRIPTION = android.provider.ContactsContract.DataColumnsClass.DATA6;

				public static readonly string SYMBOL = android.provider.ContactsContract.DataColumnsClass.DATA7;

				public static readonly string PHONETIC_NAME = android.provider.ContactsContract.DataColumnsClass.DATA8;

				public static readonly string OFFICE_LOCATION = android.provider.ContactsContract.DataColumnsClass.DATA9;

				public static readonly string PHONETIC_NAME_STYLE = android.provider.ContactsContract.DataColumnsClass.DATA10;

				[Sharpen.Stub]
				public static int getTypeLabelResource(int type)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				public static java.lang.CharSequence getTypeLabel(android.content.res.Resources res
					, int type, java.lang.CharSequence label)
				{
					throw new System.NotImplementedException();
				}
			}

			[Sharpen.Stub]
			public sealed class Relation : android.provider.ContactsContract.DataColumnsWithJoins
				, android.provider.ContactsContract.CommonDataKinds.CommonColumns
			{
				[Sharpen.Stub]
				private Relation()
				{
					throw new System.NotImplementedException();
				}

				public const string CONTENT_ITEM_TYPE = "vnd.android.cursor.item/relation";

				public const int TYPE_ASSISTANT = 1;

				public const int TYPE_BROTHER = 2;

				public const int TYPE_CHILD = 3;

				public const int TYPE_DOMESTIC_PARTNER = 4;

				public const int TYPE_FATHER = 5;

				public const int TYPE_FRIEND = 6;

				public const int TYPE_MANAGER = 7;

				public const int TYPE_MOTHER = 8;

				public const int TYPE_PARENT = 9;

				public const int TYPE_PARTNER = 10;

				public const int TYPE_REFERRED_BY = 11;

				public const int TYPE_RELATIVE = 12;

				public const int TYPE_SISTER = 13;

				public const int TYPE_SPOUSE = 14;

				public static readonly string NAME = android.provider.ContactsContract.CommonDataKinds.CommonColumnsClass.DATA;

				[Sharpen.Stub]
				public static int getTypeLabelResource(int type)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				public static java.lang.CharSequence getTypeLabel(android.content.res.Resources res
					, int type, java.lang.CharSequence label)
				{
					throw new System.NotImplementedException();
				}
			}

			[Sharpen.Stub]
			public sealed class Event : android.provider.ContactsContract.DataColumnsWithJoins
				, android.provider.ContactsContract.CommonDataKinds.CommonColumns
			{
				[Sharpen.Stub]
				private Event()
				{
					throw new System.NotImplementedException();
				}

				public const string CONTENT_ITEM_TYPE = "vnd.android.cursor.item/contact_event";

				public const int TYPE_ANNIVERSARY = 1;

				public const int TYPE_OTHER = 2;

				public const int TYPE_BIRTHDAY = 3;

				public static readonly string START_DATE = android.provider.ContactsContract.CommonDataKinds.CommonColumnsClass.DATA;

				[Sharpen.Stub]
				public static int getTypeResource(int type)
				{
					throw new System.NotImplementedException();
				}
			}

			[Sharpen.Stub]
			public sealed class Photo : android.provider.ContactsContract.DataColumnsWithJoins
			{
				[Sharpen.Stub]
				private Photo()
				{
					throw new System.NotImplementedException();
				}

				public const string CONTENT_ITEM_TYPE = "vnd.android.cursor.item/photo";

				public static readonly string PHOTO_FILE_ID = android.provider.ContactsContract.DataColumnsClass.DATA14;

				public static readonly string PHOTO = android.provider.ContactsContract.DataColumnsClass.DATA15;
			}

			[Sharpen.Stub]
			public sealed class Note : android.provider.ContactsContract.DataColumnsWithJoins
			{
				[Sharpen.Stub]
				private Note()
				{
					throw new System.NotImplementedException();
				}

				public const string CONTENT_ITEM_TYPE = "vnd.android.cursor.item/note";

				public static readonly string NOTE = android.provider.ContactsContract.DataColumnsClass.DATA1;
			}

			[Sharpen.Stub]
			public sealed class GroupMembership : android.provider.ContactsContract.DataColumnsWithJoins
			{
				[Sharpen.Stub]
				private GroupMembership()
				{
					throw new System.NotImplementedException();
				}

				public const string CONTENT_ITEM_TYPE = "vnd.android.cursor.item/group_membership";

				public static readonly string GROUP_ROW_ID = android.provider.ContactsContract.DataColumnsClass.DATA1;

				public const string GROUP_SOURCE_ID = "group_sourceid";
			}

			[Sharpen.Stub]
			public sealed class Website : android.provider.ContactsContract.DataColumnsWithJoins
				, android.provider.ContactsContract.CommonDataKinds.CommonColumns
			{
				[Sharpen.Stub]
				private Website()
				{
					throw new System.NotImplementedException();
				}

				public const string CONTENT_ITEM_TYPE = "vnd.android.cursor.item/website";

				public const int TYPE_HOMEPAGE = 1;

				public const int TYPE_BLOG = 2;

				public const int TYPE_PROFILE = 3;

				public const int TYPE_HOME = 4;

				public const int TYPE_WORK = 5;

				public const int TYPE_FTP = 6;

				public const int TYPE_OTHER = 7;

				public static readonly string URL = android.provider.ContactsContract.CommonDataKinds.CommonColumnsClass.DATA;
			}

			[Sharpen.Stub]
			public sealed class SipAddress : android.provider.ContactsContract.DataColumnsWithJoins
				, android.provider.ContactsContract.CommonDataKinds.CommonColumns
			{
				[Sharpen.Stub]
				private SipAddress()
				{
					throw new System.NotImplementedException();
				}

				public const string CONTENT_ITEM_TYPE = "vnd.android.cursor.item/sip_address";

				public const int TYPE_HOME = 1;

				public const int TYPE_WORK = 2;

				public const int TYPE_OTHER = 3;

				public static readonly string SIP_ADDRESS = android.provider.ContactsContract.DataColumnsClass.DATA1;

				[Sharpen.Stub]
				public static int getTypeLabelResource(int type)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				public static java.lang.CharSequence getTypeLabel(android.content.res.Resources res
					, int type, java.lang.CharSequence label)
				{
					throw new System.NotImplementedException();
				}
			}

			[Sharpen.Stub]
			public sealed class Identity : android.provider.ContactsContract.DataColumnsWithJoins
			{
				[Sharpen.Stub]
				private Identity()
				{
					throw new System.NotImplementedException();
				}

				public const string CONTENT_ITEM_TYPE = "vnd.android.cursor.item/identity";

				public static readonly string IDENTITY = android.provider.ContactsContract.DataColumnsClass.DATA1;

				public static readonly string NAMESPACE = android.provider.ContactsContract.DataColumnsClass.DATA2;
			}
		}

		[Sharpen.Stub]
		protected internal interface GroupsColumns
		{
		}

		[Sharpen.Stub]
		protected internal static class GroupsColumnsClass
		{
			public const string DATA_SET = "data_set";

			public const string ACCOUNT_TYPE_AND_DATA_SET = "account_type_and_data_set";

			public const string TITLE = "title";

			public const string RES_PACKAGE = "res_package";

			public const string TITLE_RES = "title_res";

			public const string NOTES = "notes";

			public const string SYSTEM_ID = "system_id";

			public const string SUMMARY_COUNT = "summ_count";

			public const string PARAM_RETURN_GROUP_COUNT_PER_ACCOUNT = "return_group_count_per_account";

			public const string SUMMARY_GROUP_COUNT_PER_ACCOUNT = "group_count_per_account";

			public const string SUMMARY_WITH_PHONES = "summ_phones";

			public const string GROUP_VISIBLE = "group_visible";

			public const string DELETED = "deleted";

			public const string SHOULD_SYNC = "should_sync";

			public const string AUTO_ADD = "auto_add";

			public const string FAVORITES = "favorites";

			public const string GROUP_IS_READ_ONLY = "group_is_read_only";
		}

		[Sharpen.Stub]
		public sealed class Groups : android.provider.BaseColumns, android.provider.ContactsContract
			.GroupsColumns, android.provider.ContactsContract.SyncColumns
		{
			[Sharpen.Stub]
			private Groups()
			{
				throw new System.NotImplementedException();
			}

			public static readonly System.Uri CONTENT_URI = Sharpen.Util.AppendUri(AUTHORITY_URI
				, "groups");

			public static readonly System.Uri CONTENT_SUMMARY_URI = Sharpen.Util.AppendUri(AUTHORITY_URI
				, "groups_summary");

			public const string CONTENT_TYPE = "vnd.android.cursor.dir/group";

			public const string CONTENT_ITEM_TYPE = "vnd.android.cursor.item/group";

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
		public sealed class AggregationExceptions : android.provider.BaseColumns
		{
			[Sharpen.Stub]
			private AggregationExceptions()
			{
				throw new System.NotImplementedException();
			}

			public static readonly System.Uri CONTENT_URI = Sharpen.Util.AppendUri(AUTHORITY_URI
				, "aggregation_exceptions");

			public const string CONTENT_TYPE = "vnd.android.cursor.dir/aggregation_exception";

			public const string CONTENT_ITEM_TYPE = "vnd.android.cursor.item/aggregation_exception";

			public const string TYPE = "type";

			public const int TYPE_AUTOMATIC = 0;

			public const int TYPE_KEEP_TOGETHER = 1;

			public const int TYPE_KEEP_SEPARATE = 2;

			public const string RAW_CONTACT_ID1 = "raw_contact_id1";

			public const string RAW_CONTACT_ID2 = "raw_contact_id2";
		}

		[Sharpen.Stub]
		protected internal interface SettingsColumns
		{
		}

		[Sharpen.Stub]
		protected internal static class SettingsColumnsClass
		{
			public const string ACCOUNT_NAME = "account_name";

			public const string ACCOUNT_TYPE = "account_type";

			public const string DATA_SET = "data_set";

			public const string SHOULD_SYNC = "should_sync";

			public const string UNGROUPED_VISIBLE = "ungrouped_visible";

			public const string ANY_UNSYNCED = "any_unsynced";

			public const string UNGROUPED_COUNT = "summ_count";

			public const string UNGROUPED_WITH_PHONES = "summ_phones";
		}

		[Sharpen.Stub]
		public sealed class Settings : android.provider.ContactsContract.SettingsColumns
		{
			[Sharpen.Stub]
			private Settings()
			{
				throw new System.NotImplementedException();
			}

			public static readonly System.Uri CONTENT_URI = Sharpen.Util.AppendUri(AUTHORITY_URI
				, "settings");

			public const string CONTENT_TYPE = "vnd.android.cursor.dir/setting";

			public const string CONTENT_ITEM_TYPE = "vnd.android.cursor.item/setting";
		}

		[Sharpen.Stub]
		public sealed class ProviderStatus
		{
			[Sharpen.Stub]
			private ProviderStatus()
			{
				throw new System.NotImplementedException();
			}

			public static readonly System.Uri CONTENT_URI = Sharpen.Util.AppendUri(AUTHORITY_URI
				, "provider_status");

			public const string CONTENT_TYPE = "vnd.android.cursor.dir/provider_status";

			public const string STATUS = "status";

			public const int STATUS_NORMAL = 0;

			public const int STATUS_UPGRADING = 1;

			public const int STATUS_UPGRADE_OUT_OF_MEMORY = 2;

			public const int STATUS_CHANGING_LOCALE = 3;

			public const int STATUS_NO_ACCOUNTS_NO_CONTACTS = 4;

			public const string DATA1 = "data1";
		}

		[Sharpen.Stub]
		public sealed class DataUsageFeedback
		{
			public static readonly System.Uri FEEDBACK_URI = Sharpen.Util.AppendUri(android.provider.ContactsContract
				.Data.CONTENT_URI, "usagefeedback");

			public const string USAGE_TYPE = "type";

			public const string USAGE_TYPE_CALL = "call";

			public const string USAGE_TYPE_LONG_TEXT = "long_text";

			public const string USAGE_TYPE_SHORT_TEXT = "short_text";
		}

		[Sharpen.Stub]
		public sealed class QuickContact
		{
			public const string ACTION_QUICK_CONTACT = "com.android.contacts.action.QUICK_CONTACT";

			[System.ObsoleteAttribute(@"Use android.content.Intent.setSourceBounds(android.graphics.Rect) instead."
				)]
			public const string EXTRA_TARGET_RECT = "target_rect";

			public const string EXTRA_MODE = "mode";

			public const string EXTRA_EXCLUDE_MIMES = "exclude_mimes";

			public const int MODE_SMALL = 1;

			public const int MODE_MEDIUM = 2;

			public const int MODE_LARGE = 3;

			[Sharpen.Stub]
			public static void showQuickContact(android.content.Context context, android.view.View
				 target, System.Uri lookupUri, int mode, string[] excludeMimes)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static void showQuickContact(android.content.Context context, android.graphics.Rect
				 target, System.Uri lookupUri, int mode, string[] excludeMimes)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public sealed class DisplayPhoto
		{
			[Sharpen.Stub]
			private DisplayPhoto()
			{
				throw new System.NotImplementedException();
			}

			public static readonly System.Uri CONTENT_URI = Sharpen.Util.AppendUri(AUTHORITY_URI
				, "display_photo");

			public static readonly System.Uri CONTENT_MAX_DIMENSIONS_URI = Sharpen.Util.AppendUri
				(AUTHORITY_URI, "photo_dimensions");

			public const string DISPLAY_MAX_DIM = "display_max_dim";

			public const string THUMBNAIL_MAX_DIM = "thumbnail_max_dim";
		}

		[Sharpen.Stub]
		public sealed class Intents
		{
			public const string SEARCH_SUGGESTION_CLICKED = "android.provider.Contacts.SEARCH_SUGGESTION_CLICKED";

			public const string SEARCH_SUGGESTION_DIAL_NUMBER_CLICKED = "android.provider.Contacts.SEARCH_SUGGESTION_DIAL_NUMBER_CLICKED";

			public const string SEARCH_SUGGESTION_CREATE_CONTACT_CLICKED = "android.provider.Contacts.SEARCH_SUGGESTION_CREATE_CONTACT_CLICKED";

			public const string ATTACH_IMAGE = "com.android.contacts.action.ATTACH_IMAGE";

			public const string INVITE_CONTACT = "com.android.contacts.action.INVITE_CONTACT";

			public const string SHOW_OR_CREATE_CONTACT = "com.android.contacts.action.SHOW_OR_CREATE_CONTACT";

			public const string ACTION_GET_MULTIPLE_PHONES = "com.android.contacts.action.GET_MULTIPLE_PHONES";

			public const string EXTRA_FORCE_CREATE = "com.android.contacts.action.FORCE_CREATE";

			public const string EXTRA_CREATE_DESCRIPTION = "com.android.contacts.action.CREATE_DESCRIPTION";

			public const string EXTRA_PHONE_URIS = "com.android.contacts.extra.PHONE_URIS";

			[System.Obsolete]
			public const string EXTRA_TARGET_RECT = "target_rect";

			[System.Obsolete]
			public const string EXTRA_MODE = "mode";

			[System.Obsolete]
			public const int MODE_SMALL = 1;

			[System.Obsolete]
			public const int MODE_MEDIUM = 2;

			[System.Obsolete]
			public const int MODE_LARGE = 3;

			[System.Obsolete]
			public const string EXTRA_EXCLUDE_MIMES = "exclude_mimes";

			[Sharpen.Stub]
			public sealed class UI
			{
				public const string LIST_DEFAULT = "com.android.contacts.action.LIST_DEFAULT";

				public const string LIST_GROUP_ACTION = "com.android.contacts.action.LIST_GROUP";

				public const string GROUP_NAME_EXTRA_KEY = "com.android.contacts.extra.GROUP";

				public const string LIST_ALL_CONTACTS_ACTION = "com.android.contacts.action.LIST_ALL_CONTACTS";

				public const string LIST_CONTACTS_WITH_PHONES_ACTION = "com.android.contacts.action.LIST_CONTACTS_WITH_PHONES";

				public const string LIST_STARRED_ACTION = "com.android.contacts.action.LIST_STARRED";

				public const string LIST_FREQUENT_ACTION = "com.android.contacts.action.LIST_FREQUENT";

				public const string LIST_STREQUENT_ACTION = "com.android.contacts.action.LIST_STREQUENT";

				public const string TITLE_EXTRA_KEY = "com.android.contacts.extra.TITLE_EXTRA";

				public const string FILTER_CONTACTS_ACTION = "com.android.contacts.action.FILTER_CONTACTS";

				public const string FILTER_TEXT_EXTRA_KEY = "com.android.contacts.extra.FILTER_TEXT";
			}

			[Sharpen.Stub]
			public sealed class Insert
			{
				public static readonly string ACTION = android.content.Intent.ACTION_INSERT;

				public const string FULL_MODE = "full_mode";

				public const string NAME = "name";

				public const string PHONETIC_NAME = "phonetic_name";

				public const string COMPANY = "company";

				public const string JOB_TITLE = "job_title";

				public const string NOTES = "notes";

				public const string PHONE = "phone";

				public const string PHONE_TYPE = "phone_type";

				public const string PHONE_ISPRIMARY = "phone_isprimary";

				public const string SECONDARY_PHONE = "secondary_phone";

				public const string SECONDARY_PHONE_TYPE = "secondary_phone_type";

				public const string TERTIARY_PHONE = "tertiary_phone";

				public const string TERTIARY_PHONE_TYPE = "tertiary_phone_type";

				public const string EMAIL = "email";

				public const string EMAIL_TYPE = "email_type";

				public const string EMAIL_ISPRIMARY = "email_isprimary";

				public const string SECONDARY_EMAIL = "secondary_email";

				public const string SECONDARY_EMAIL_TYPE = "secondary_email_type";

				public const string TERTIARY_EMAIL = "tertiary_email";

				public const string TERTIARY_EMAIL_TYPE = "tertiary_email_type";

				public const string POSTAL = "postal";

				public const string POSTAL_TYPE = "postal_type";

				public const string POSTAL_ISPRIMARY = "postal_isprimary";

				public const string IM_HANDLE = "im_handle";

				public const string IM_PROTOCOL = "im_protocol";

				public const string IM_ISPRIMARY = "im_isprimary";

				public const string DATA = "data";

				public const string ACCOUNT = "com.android.contacts.extra.ACCOUNT";

				public const string DATA_SET = "com.android.contacts.extra.DATA_SET";
			}
		}

		[Sharpen.Stub]
		public static string snippetize(string content, string displayName, string query, 
			char snippetStartMatch, char snippetEndMatch, string snippetEllipsis, int snippetMaxTokens
			)
		{
			throw new System.NotImplementedException();
		}

		private static java.util.regex.Pattern SPLIT_PATTERN = java.util.regex.Pattern.compile
			("([\\w-\\.]+)@((?:[\\w]+\\.)+)([a-zA-Z]{2,4})|[\\w]+");

		[Sharpen.Stub]
		private static void split(string content, java.util.List<string> tokens, java.util.List
			<int> offsets)
		{
			throw new System.NotImplementedException();
		}
	}
}

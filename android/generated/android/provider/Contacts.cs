using Sharpen;

namespace android.provider
{
	[Sharpen.Stub]
	[System.ObsoleteAttribute(@"The APIs have been superseded by ContactsContract . The newer APIs allow access multiple accounts and support aggregation of similar contacts. These APIs continue to work but will only return data for the first Google account created, which matches the original behavior."
		)]
	public class Contacts
	{
		internal const string TAG = "Contacts";

		[System.ObsoleteAttribute(@"see ContactsContract")]
		public const string AUTHORITY = "contacts";

		[System.ObsoleteAttribute(@"see ContactsContract")]
		public static readonly System.Uri CONTENT_URI = Sharpen.Util.ParseUri("content://"
			 + AUTHORITY);

		[System.ObsoleteAttribute(@"see ContactsContract")]
		public const int KIND_EMAIL = 1;

		[System.ObsoleteAttribute(@"see ContactsContract")]
		public const int KIND_POSTAL = 2;

		[System.ObsoleteAttribute(@"see ContactsContract")]
		public const int KIND_IM = 3;

		[System.ObsoleteAttribute(@"see ContactsContract")]
		public const int KIND_ORGANIZATION = 4;

		[System.ObsoleteAttribute(@"see ContactsContract")]
		public const int KIND_PHONE = 5;

		[Sharpen.Stub]
		private Contacts()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"see ContactsContract")]
		public interface SettingsColumns
		{
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"see ContactsContract")]
		public static class SettingsColumnsClass
		{
			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string _SYNC_ACCOUNT = "_sync_account";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string _SYNC_ACCOUNT_TYPE = "_sync_account_type";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string KEY = "key";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string VALUE = "value";
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"see ContactsContract")]
		public sealed class Settings : android.provider.BaseColumns, android.provider.Contacts
			.SettingsColumns
		{
			[Sharpen.Stub]
			private Settings()
			{
				throw new System.NotImplementedException();
			}

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public static readonly System.Uri CONTENT_URI = Sharpen.Util.ParseUri("content://contacts/settings"
				);

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string CONTENT_DIRECTORY = "settings";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string DEFAULT_SORT_ORDER = "key ASC";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string SYNC_EVERYTHING = "syncEverything";

			[Sharpen.Stub]
			[System.ObsoleteAttribute(@"see ContactsContract")]
			public static string getSetting(android.content.ContentResolver cr, string account
				, string key)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[System.ObsoleteAttribute(@"see ContactsContract")]
			public static void setSetting(android.content.ContentResolver cr, string account, 
				string key, string value)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"see ContactsContract")]
		public interface PeopleColumns
		{
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"see ContactsContract")]
		public static class PeopleColumnsClass
		{
			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string NAME = "name";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string PHONETIC_NAME = "phonetic_name";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string DISPLAY_NAME = "display_name";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string SORT_STRING = "sort_string";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string NOTES = "notes";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string TIMES_CONTACTED = "times_contacted";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string LAST_TIME_CONTACTED = "last_time_contacted";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string CUSTOM_RINGTONE = "custom_ringtone";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string SEND_TO_VOICEMAIL = "send_to_voicemail";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string STARRED = "starred";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string PHOTO_VERSION = "photo_version";
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"see ContactsContract")]
		public sealed class People : android.provider.BaseColumns, android.provider.SyncConstValue
			, android.provider.Contacts.PeopleColumns, android.provider.Contacts.PhonesColumns
			, android.provider.Contacts.PresenceColumns
		{
			[Sharpen.Stub]
			[System.ObsoleteAttribute(@"see ContactsContract")]
			private People()
			{
				throw new System.NotImplementedException();
			}

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public static readonly System.Uri CONTENT_URI = Sharpen.Util.ParseUri("content://contacts/people"
				);

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public static readonly System.Uri CONTENT_FILTER_URI = Sharpen.Util.ParseUri("content://contacts/people/filter"
				);

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public static readonly System.Uri DELETED_CONTENT_URI = Sharpen.Util.ParseUri("content://contacts/deleted_people"
				);

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public static readonly System.Uri WITH_EMAIL_OR_IM_FILTER_URI = Sharpen.Util.ParseUri
				("content://contacts/people/with_email_or_im_filter");

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string CONTENT_TYPE = "vnd.android.cursor.dir/person";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string CONTENT_ITEM_TYPE = "vnd.android.cursor.item/person";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public static readonly string DEFAULT_SORT_ORDER = android.provider.Contacts.PeopleColumnsClass.NAME
				 + " ASC";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string PRIMARY_PHONE_ID = "primary_phone";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string PRIMARY_EMAIL_ID = "primary_email";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string PRIMARY_ORGANIZATION_ID = "primary_organization";

			[Sharpen.Stub]
			[System.ObsoleteAttribute(@"see ContactsContract")]
			public static void markAsContacted(android.content.ContentResolver resolver, long
				 personId)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[System.ObsoleteAttribute(@"see ContactsContract")]
			public static long tryGetMyContactsGroupId(android.content.ContentResolver resolver
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[System.ObsoleteAttribute(@"see ContactsContract")]
			public static System.Uri addToMyContactsGroup(android.content.ContentResolver resolver
				, long personId)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[System.ObsoleteAttribute(@"see ContactsContract")]
			public static System.Uri addToGroup(android.content.ContentResolver resolver, long
				 personId, string groupName)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[System.ObsoleteAttribute(@"see ContactsContract")]
			public static System.Uri addToGroup(android.content.ContentResolver resolver, long
				 personId, long groupId)
			{
				throw new System.NotImplementedException();
			}

			private static readonly string[] GROUPS_PROJECTION = new string[] { android.provider.BaseColumnsClass._ID
				 };

			[Sharpen.Stub]
			[System.ObsoleteAttribute(@"see ContactsContract")]
			public static System.Uri createPersonInMyContactsGroup(android.content.ContentResolver
				 resolver, android.content.ContentValues values)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[System.ObsoleteAttribute(@"see ContactsContract")]
			public static android.database.Cursor queryGroups(android.content.ContentResolver
				 resolver, long person)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[System.ObsoleteAttribute(@"see ContactsContract")]
			public static void setPhotoData(android.content.ContentResolver cr, System.Uri person
				, byte[] data)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[System.ObsoleteAttribute(@"see ContactsContract")]
			public static java.io.InputStream openContactPhotoInputStream(android.content.ContentResolver
				 cr, System.Uri person)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[System.ObsoleteAttribute(@"see ContactsContract")]
			public static android.graphics.Bitmap loadContactPhoto(android.content.Context context
				, System.Uri person, int placeholderImageResource, android.graphics.BitmapFactory
				.Options options)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			private static android.graphics.Bitmap loadPlaceholderPhoto(int placeholderImageResource
				, android.content.Context context, android.graphics.BitmapFactory.Options options
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[System.ObsoleteAttribute(@"see ContactsContract")]
			public sealed class Phones : android.provider.BaseColumns, android.provider.Contacts
				.PhonesColumns, android.provider.Contacts.PeopleColumns
			{
				[Sharpen.Stub]
				private Phones()
				{
					throw new System.NotImplementedException();
				}

				[System.ObsoleteAttribute(@"see ContactsContract")]
				public const string CONTENT_DIRECTORY = "phones";

				[System.ObsoleteAttribute(@"see ContactsContract")]
				public const string DEFAULT_SORT_ORDER = "number ASC";
			}

			[Sharpen.Stub]
			[System.ObsoleteAttribute(@"see ContactsContract")]
			public sealed class ContactMethods : android.provider.BaseColumns, android.provider.Contacts
				.ContactMethodsColumns, android.provider.Contacts.PeopleColumns
			{
				[Sharpen.Stub]
				private ContactMethods()
				{
					throw new System.NotImplementedException();
				}

				[System.ObsoleteAttribute(@"see ContactsContract")]
				public const string CONTENT_DIRECTORY = "contact_methods";

				[System.ObsoleteAttribute(@"see ContactsContract")]
				public const string DEFAULT_SORT_ORDER = "data ASC";
			}

			[Sharpen.Stub]
			[System.ObsoleteAttribute(@"see ContactsContract")]
			public class Extensions : android.provider.BaseColumns, android.provider.Contacts
				.ExtensionsColumns
			{
				[Sharpen.Stub]
				[System.ObsoleteAttribute(@"see ContactsContract")]
				private Extensions()
				{
					throw new System.NotImplementedException();
				}

				[System.ObsoleteAttribute(@"see ContactsContract")]
				public const string CONTENT_DIRECTORY = "extensions";

				[System.ObsoleteAttribute(@"see ContactsContract")]
				public const string DEFAULT_SORT_ORDER = "name ASC";

				[System.ObsoleteAttribute(@"see ContactsContract")]
				public const string PERSON_ID = "person";
			}
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"see ContactsContract")]
		public interface GroupsColumns
		{
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"see ContactsContract")]
		public static class GroupsColumnsClass
		{
			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string NAME = "name";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string NOTES = "notes";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string SHOULD_SYNC = "should_sync";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string SYSTEM_ID = "system_id";
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"see ContactsContract")]
		public sealed class Groups : android.provider.BaseColumns, android.provider.SyncConstValue
			, android.provider.Contacts.GroupsColumns
		{
			[Sharpen.Stub]
			private Groups()
			{
				throw new System.NotImplementedException();
			}

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public static readonly System.Uri CONTENT_URI = Sharpen.Util.ParseUri("content://contacts/groups"
				);

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public static readonly System.Uri DELETED_CONTENT_URI = Sharpen.Util.ParseUri("content://contacts/deleted_groups"
				);

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string CONTENT_TYPE = "vnd.android.cursor.dir/contactsgroup";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string CONTENT_ITEM_TYPE = "vnd.android.cursor.item/contactsgroup";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public static readonly string DEFAULT_SORT_ORDER = android.provider.Contacts.GroupsColumnsClass.NAME
				 + " ASC";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string GROUP_ANDROID_STARRED = "Starred in Android";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string GROUP_MY_CONTACTS = "Contacts";
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"see ContactsContract")]
		public interface PhonesColumns
		{
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"see ContactsContract")]
		public static class PhonesColumnsClass
		{
			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string TYPE = "type";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const int TYPE_CUSTOM = 0;

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const int TYPE_HOME = 1;

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const int TYPE_MOBILE = 2;

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const int TYPE_WORK = 3;

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const int TYPE_FAX_WORK = 4;

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const int TYPE_FAX_HOME = 5;

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const int TYPE_PAGER = 6;

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const int TYPE_OTHER = 7;

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string LABEL = "label";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string NUMBER = "number";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string NUMBER_KEY = "number_key";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string ISPRIMARY = "isprimary";
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"see ContactsContract")]
		public sealed class Phones : android.provider.BaseColumns, android.provider.Contacts
			.PhonesColumns, android.provider.Contacts.PeopleColumns
		{
			[Sharpen.Stub]
			private Phones()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[System.ObsoleteAttribute(@"see ContactsContract")]
			public static java.lang.CharSequence getDisplayLabel(android.content.Context context
				, int type, java.lang.CharSequence label, java.lang.CharSequence[] labelArray)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[System.ObsoleteAttribute(@"see ContactsContract")]
			public static java.lang.CharSequence getDisplayLabel(android.content.Context context
				, int type, java.lang.CharSequence label)
			{
				throw new System.NotImplementedException();
			}

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public static readonly System.Uri CONTENT_URI = Sharpen.Util.ParseUri("content://contacts/phones"
				);

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public static readonly System.Uri CONTENT_FILTER_URL = Sharpen.Util.ParseUri("content://contacts/phones/filter"
				);

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string CONTENT_TYPE = "vnd.android.cursor.dir/phone";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string CONTENT_ITEM_TYPE = "vnd.android.cursor.item/phone";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string DEFAULT_SORT_ORDER = "name ASC";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string PERSON_ID = "person";
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"see ContactsContract")]
		public sealed class GroupMembership : android.provider.BaseColumns, android.provider.Contacts
			.GroupsColumns
		{
			[Sharpen.Stub]
			private GroupMembership()
			{
				throw new System.NotImplementedException();
			}

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public static readonly System.Uri CONTENT_URI = Sharpen.Util.ParseUri("content://contacts/groupmembership"
				);

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public static readonly System.Uri RAW_CONTENT_URI = Sharpen.Util.ParseUri("content://contacts/groupmembershipraw"
				);

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string CONTENT_DIRECTORY = "groupmembership";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string CONTENT_TYPE = "vnd.android.cursor.dir/contactsgroupmembership";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string CONTENT_ITEM_TYPE = "vnd.android.cursor.item/contactsgroupmembership";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string DEFAULT_SORT_ORDER = "group_id ASC";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string GROUP_ID = "group_id";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string GROUP_SYNC_ID = "group_sync_id";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string GROUP_SYNC_ACCOUNT = "group_sync_account";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string GROUP_SYNC_ACCOUNT_TYPE = "group_sync_account_type";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string PERSON_ID = "person";
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"see ContactsContract")]
		public interface ContactMethodsColumns
		{
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"see ContactsContract")]
		public static class ContactMethodsColumnsClass
		{
			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string KIND = "kind";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string TYPE = "type";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const int TYPE_CUSTOM = 0;

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const int TYPE_HOME = 1;

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const int TYPE_WORK = 2;

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const int TYPE_OTHER = 3;

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const int MOBILE_EMAIL_TYPE_INDEX = 2;

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string MOBILE_EMAIL_TYPE_NAME = "_AUTO_CELL";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string LABEL = "label";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string DATA = "data";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string AUX_DATA = "aux_data";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string ISPRIMARY = "isprimary";
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"see ContactsContract")]
		public sealed class ContactMethods : android.provider.BaseColumns, android.provider.Contacts
			.ContactMethodsColumns, android.provider.Contacts.PeopleColumns
		{
			[System.ObsoleteAttribute(@"see ContactsContract")]
			public static readonly string POSTAL_LOCATION_LATITUDE = android.provider.Contacts.ContactMethodsColumnsClass.DATA;

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public static readonly string POSTAL_LOCATION_LONGITUDE = android.provider.Contacts.ContactMethodsColumnsClass.AUX_DATA;

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const int PROTOCOL_AIM = 0;

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const int PROTOCOL_MSN = 1;

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const int PROTOCOL_YAHOO = 2;

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const int PROTOCOL_SKYPE = 3;

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const int PROTOCOL_QQ = 4;

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const int PROTOCOL_GOOGLE_TALK = 5;

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const int PROTOCOL_ICQ = 6;

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const int PROTOCOL_JABBER = 7;

			[Sharpen.Stub]
			[System.ObsoleteAttribute(@"see ContactsContract")]
			public static string encodePredefinedImProtocol(int protocol)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[System.ObsoleteAttribute(@"see ContactsContract")]
			public static string encodeCustomImProtocol(string protocolString)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[System.ObsoleteAttribute(@"see ContactsContract")]
			public static object decodeImProtocol(string encodedString)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal interface ProviderNames
			{
			}

			[Sharpen.Stub]
			internal static class ProviderNamesClass
			{
				public const string YAHOO = "Yahoo";

				public const string GTALK = "GTalk";

				public const string MSN = "MSN";

				public const string ICQ = "ICQ";

				public const string AIM = "AIM";

				public const string XMPP = "XMPP";

				public const string JABBER = "JABBER";

				public const string SKYPE = "SKYPE";

				public const string QQ = "QQ";
			}

			[Sharpen.Stub]
			[System.ObsoleteAttribute(@"see ContactsContract")]
			public static string lookupProviderNameFromId(int protocol)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			private ContactMethods()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[System.ObsoleteAttribute(@"see ContactsContract")]
			public static java.lang.CharSequence getDisplayLabel(android.content.Context context
				, int kind, int type, java.lang.CharSequence label)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[System.ObsoleteAttribute(@"see ContactsContract")]
			public void addPostalLocation(android.content.Context context, long postalId, double
				 latitude, double longitude)
			{
				throw new System.NotImplementedException();
			}

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public static readonly System.Uri CONTENT_URI = Sharpen.Util.ParseUri("content://contacts/contact_methods"
				);

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public static readonly System.Uri CONTENT_EMAIL_URI = Sharpen.Util.ParseUri("content://contacts/contact_methods/email"
				);

			[System.ObsoleteAttribute(@"see ContactsContract phones.")]
			public const string CONTENT_TYPE = "vnd.android.cursor.dir/contact-methods";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string CONTENT_EMAIL_TYPE = "vnd.android.cursor.dir/email";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string CONTENT_POSTAL_TYPE = "vnd.android.cursor.dir/postal-address";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string CONTENT_EMAIL_ITEM_TYPE = "vnd.android.cursor.item/email";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string CONTENT_POSTAL_ITEM_TYPE = "vnd.android.cursor.item/postal-address";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string CONTENT_IM_ITEM_TYPE = "vnd.android.cursor.item/jabber-im";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string DEFAULT_SORT_ORDER = "name ASC";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string PERSON_ID = "person";
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"see ContactsContract")]
		public interface PresenceColumns
		{
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"see ContactsContract")]
		public static class PresenceColumnsClass
		{
			public const string PRIORITY = "priority";

			public static readonly string PRESENCE_STATUS = android.provider.ContactsContract.StatusColumnsClass.PRESENCE;

			public const int OFFLINE = android.provider.ContactsContract.StatusColumnsClass.OFFLINE;

			public const int INVISIBLE = android.provider.ContactsContract.StatusColumnsClass.INVISIBLE;

			public const int AWAY = android.provider.ContactsContract.StatusColumnsClass.AWAY;

			public const int IDLE = android.provider.ContactsContract.StatusColumnsClass.IDLE;

			public const int DO_NOT_DISTURB = android.provider.ContactsContract.StatusColumnsClass.DO_NOT_DISTURB;

			public const int AVAILABLE = android.provider.ContactsContract.StatusColumnsClass.AVAILABLE;

			public static readonly string PRESENCE_CUSTOM_STATUS = android.provider.ContactsContract.StatusColumnsClass.STATUS;

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string IM_PROTOCOL = "im_protocol";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string IM_HANDLE = "im_handle";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string IM_ACCOUNT = "im_account";
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"see ContactsContract")]
		public sealed class Presence : android.provider.BaseColumns, android.provider.Contacts
			.PresenceColumns, android.provider.Contacts.PeopleColumns
		{
			[System.ObsoleteAttribute(@"see ContactsContract")]
			public static readonly System.Uri CONTENT_URI = Sharpen.Util.ParseUri("content://contacts/presence"
				);

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string PERSON_ID = "person";

			[Sharpen.Stub]
			[System.ObsoleteAttribute(@"see ContactsContract")]
			public static int getPresenceIconResourceId(int status)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[System.ObsoleteAttribute(@"see ContactsContract")]
			public static void setPresenceIcon(android.widget.ImageView icon, int serverStatus
				)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"see ContactsContract")]
		public interface OrganizationColumns
		{
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"see ContactsContract")]
		public static class OrganizationColumnsClass
		{
			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string TYPE = "type";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const int TYPE_CUSTOM = 0;

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const int TYPE_WORK = 1;

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const int TYPE_OTHER = 2;

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string LABEL = "label";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string COMPANY = "company";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string TITLE = "title";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string PERSON_ID = "person";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string ISPRIMARY = "isprimary";
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"see ContactsContract")]
		public sealed class Organizations : android.provider.BaseColumns, android.provider.Contacts
			.OrganizationColumns
		{
			[Sharpen.Stub]
			private Organizations()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[System.ObsoleteAttribute(@"see ContactsContract")]
			public static java.lang.CharSequence getDisplayLabel(android.content.Context context
				, int type, java.lang.CharSequence label)
			{
				throw new System.NotImplementedException();
			}

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public static readonly System.Uri CONTENT_URI = Sharpen.Util.ParseUri("content://contacts/organizations"
				);

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string CONTENT_DIRECTORY = "organizations";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string DEFAULT_SORT_ORDER = "company, title, isprimary ASC";
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"see ContactsContract")]
		public interface PhotosColumns
		{
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"see ContactsContract")]
		public static class PhotosColumnsClass
		{
			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string LOCAL_VERSION = "local_version";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string PERSON_ID = "person";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string DOWNLOAD_REQUIRED = "download_required";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string EXISTS_ON_SERVER = "exists_on_server";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string SYNC_ERROR = "sync_error";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string DATA = "data";
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"see ContactsContract")]
		public sealed class Photos : android.provider.BaseColumns, android.provider.Contacts
			.PhotosColumns, android.provider.SyncConstValue
		{
			[Sharpen.Stub]
			private Photos()
			{
				throw new System.NotImplementedException();
			}

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public static readonly System.Uri CONTENT_URI = Sharpen.Util.ParseUri("content://contacts/photos"
				);

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string CONTENT_DIRECTORY = "photo";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string DEFAULT_SORT_ORDER = "person ASC";
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"see ContactsContract")]
		public interface ExtensionsColumns
		{
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"see ContactsContract")]
		public static class ExtensionsColumnsClass
		{
			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string NAME = "name";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string VALUE = "value";
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"see ContactsContract")]
		public sealed class Extensions : android.provider.BaseColumns, android.provider.Contacts
			.ExtensionsColumns
		{
			[Sharpen.Stub]
			private Extensions()
			{
				throw new System.NotImplementedException();
			}

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public static readonly System.Uri CONTENT_URI = Sharpen.Util.ParseUri("content://contacts/extensions"
				);

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string CONTENT_TYPE = "vnd.android.cursor.dir/contact_extensions";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string CONTENT_ITEM_TYPE = "vnd.android.cursor.item/contact_extensions";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string DEFAULT_SORT_ORDER = "person, name ASC";

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public const string PERSON_ID = "person";
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"see ContactsContract")]
		public sealed class Intents
		{
			[Sharpen.Stub]
			[System.ObsoleteAttribute(@"see ContactsContract")]
			public Intents()
			{
				throw new System.NotImplementedException();
			}

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public static readonly string SEARCH_SUGGESTION_CLICKED = android.provider.ContactsContract
				.Intents.SEARCH_SUGGESTION_CLICKED;

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public static readonly string SEARCH_SUGGESTION_DIAL_NUMBER_CLICKED = android.provider.ContactsContract
				.Intents.SEARCH_SUGGESTION_DIAL_NUMBER_CLICKED;

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public static readonly string SEARCH_SUGGESTION_CREATE_CONTACT_CLICKED = android.provider.ContactsContract
				.Intents.SEARCH_SUGGESTION_CREATE_CONTACT_CLICKED;

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public static readonly string ATTACH_IMAGE = android.provider.ContactsContract.Intents
				.ATTACH_IMAGE;

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public static readonly string SHOW_OR_CREATE_CONTACT = android.provider.ContactsContract
				.Intents.SHOW_OR_CREATE_CONTACT;

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public static readonly string EXTRA_FORCE_CREATE = android.provider.ContactsContract
				.Intents.EXTRA_FORCE_CREATE;

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public static readonly string EXTRA_CREATE_DESCRIPTION = android.provider.ContactsContract
				.Intents.EXTRA_CREATE_DESCRIPTION;

			[System.ObsoleteAttribute(@"see ContactsContract")]
			public static readonly string EXTRA_TARGET_RECT = android.provider.ContactsContract
				.Intents.EXTRA_TARGET_RECT;

			[Sharpen.Stub]
			[System.ObsoleteAttribute(@"see ContactsContract")]
			public sealed class UI
			{
				[Sharpen.Stub]
				[System.ObsoleteAttribute(@"see ContactsContract")]
				public UI()
				{
					throw new System.NotImplementedException();
				}

				[System.ObsoleteAttribute(@"see ContactsContract")]
				public static readonly string LIST_DEFAULT = android.provider.ContactsContract.Intents
					.UI.LIST_DEFAULT;

				[System.ObsoleteAttribute(@"see ContactsContract")]
				public static readonly string LIST_GROUP_ACTION = android.provider.ContactsContract.Intents
					.UI.LIST_GROUP_ACTION;

				[System.ObsoleteAttribute(@"see ContactsContract")]
				public static readonly string GROUP_NAME_EXTRA_KEY = android.provider.ContactsContract.Intents
					.UI.GROUP_NAME_EXTRA_KEY;

				[System.ObsoleteAttribute(@"see ContactsContract")]
				public static readonly string LIST_ALL_CONTACTS_ACTION = android.provider.ContactsContract.Intents
					.UI.LIST_ALL_CONTACTS_ACTION;

				[System.ObsoleteAttribute(@"see ContactsContract")]
				public static readonly string LIST_CONTACTS_WITH_PHONES_ACTION = android.provider.ContactsContract.Intents
					.UI.LIST_CONTACTS_WITH_PHONES_ACTION;

				[System.ObsoleteAttribute(@"see ContactsContract")]
				public static readonly string LIST_STARRED_ACTION = android.provider.ContactsContract.Intents
					.UI.LIST_STARRED_ACTION;

				[System.ObsoleteAttribute(@"see ContactsContract")]
				public static readonly string LIST_FREQUENT_ACTION = android.provider.ContactsContract.Intents
					.UI.LIST_FREQUENT_ACTION;

				[System.ObsoleteAttribute(@"see ContactsContract")]
				public static readonly string LIST_STREQUENT_ACTION = android.provider.ContactsContract.Intents
					.UI.LIST_STREQUENT_ACTION;

				[System.ObsoleteAttribute(@"see ContactsContract")]
				public static readonly string TITLE_EXTRA_KEY = android.provider.ContactsContract.Intents
					.UI.TITLE_EXTRA_KEY;

				[System.ObsoleteAttribute(@"see ContactsContract")]
				public static readonly string FILTER_CONTACTS_ACTION = android.provider.ContactsContract.Intents
					.UI.FILTER_CONTACTS_ACTION;

				[System.ObsoleteAttribute(@"see ContactsContract")]
				public static readonly string FILTER_TEXT_EXTRA_KEY = android.provider.ContactsContract.Intents
					.UI.FILTER_TEXT_EXTRA_KEY;
			}

			[Sharpen.Stub]
			[System.ObsoleteAttribute(@"see ContactsContract")]
			public sealed class Insert
			{
				[Sharpen.Stub]
				[System.ObsoleteAttribute(@"see ContactsContract")]
				public Insert()
				{
					throw new System.NotImplementedException();
				}

				[System.ObsoleteAttribute(@"see ContactsContract")]
				public static readonly string ACTION = android.provider.ContactsContract.Intents.
					Insert.ACTION;

				[System.ObsoleteAttribute(@"see ContactsContract")]
				public static readonly string FULL_MODE = android.provider.ContactsContract.Intents
					.Insert.FULL_MODE;

				[System.ObsoleteAttribute(@"see ContactsContract")]
				public static readonly string NAME = android.provider.ContactsContract.Intents.Insert
					.NAME;

				[System.ObsoleteAttribute(@"see ContactsContract")]
				public static readonly string PHONETIC_NAME = android.provider.ContactsContract.Intents
					.Insert.PHONETIC_NAME;

				[System.ObsoleteAttribute(@"see ContactsContract")]
				public static readonly string COMPANY = android.provider.ContactsContract.Intents
					.Insert.COMPANY;

				[System.ObsoleteAttribute(@"see ContactsContract")]
				public static readonly string JOB_TITLE = android.provider.ContactsContract.Intents
					.Insert.JOB_TITLE;

				[System.ObsoleteAttribute(@"see ContactsContract")]
				public static readonly string NOTES = android.provider.ContactsContract.Intents.Insert
					.NOTES;

				[System.ObsoleteAttribute(@"see ContactsContract")]
				public static readonly string PHONE = android.provider.ContactsContract.Intents.Insert
					.PHONE;

				[System.ObsoleteAttribute(@"see ContactsContract")]
				public static readonly string PHONE_TYPE = android.provider.ContactsContract.Intents
					.Insert.PHONE_TYPE;

				[System.ObsoleteAttribute(@"see ContactsContract")]
				public static readonly string PHONE_ISPRIMARY = android.provider.ContactsContract.Intents
					.Insert.PHONE_ISPRIMARY;

				[System.ObsoleteAttribute(@"see ContactsContract")]
				public static readonly string SECONDARY_PHONE = android.provider.ContactsContract.Intents
					.Insert.SECONDARY_PHONE;

				[System.ObsoleteAttribute(@"see ContactsContract")]
				public static readonly string SECONDARY_PHONE_TYPE = android.provider.ContactsContract.Intents
					.Insert.SECONDARY_PHONE_TYPE;

				[System.ObsoleteAttribute(@"see ContactsContract")]
				public static readonly string TERTIARY_PHONE = android.provider.ContactsContract.Intents
					.Insert.TERTIARY_PHONE;

				[System.ObsoleteAttribute(@"see ContactsContract")]
				public static readonly string TERTIARY_PHONE_TYPE = android.provider.ContactsContract.Intents
					.Insert.TERTIARY_PHONE_TYPE;

				[System.ObsoleteAttribute(@"see ContactsContract")]
				public static readonly string EMAIL = android.provider.ContactsContract.Intents.Insert
					.EMAIL;

				[System.ObsoleteAttribute(@"see ContactsContract")]
				public static readonly string EMAIL_TYPE = android.provider.ContactsContract.Intents
					.Insert.EMAIL_TYPE;

				[System.ObsoleteAttribute(@"see ContactsContract")]
				public static readonly string EMAIL_ISPRIMARY = android.provider.ContactsContract.Intents
					.Insert.EMAIL_ISPRIMARY;

				[System.ObsoleteAttribute(@"see ContactsContract")]
				public static readonly string SECONDARY_EMAIL = android.provider.ContactsContract.Intents
					.Insert.SECONDARY_EMAIL;

				[System.ObsoleteAttribute(@"see ContactsContract")]
				public static readonly string SECONDARY_EMAIL_TYPE = android.provider.ContactsContract.Intents
					.Insert.SECONDARY_EMAIL_TYPE;

				[System.ObsoleteAttribute(@"see ContactsContract")]
				public static readonly string TERTIARY_EMAIL = android.provider.ContactsContract.Intents
					.Insert.TERTIARY_EMAIL;

				[System.ObsoleteAttribute(@"see ContactsContract")]
				public static readonly string TERTIARY_EMAIL_TYPE = android.provider.ContactsContract.Intents
					.Insert.TERTIARY_EMAIL_TYPE;

				[System.ObsoleteAttribute(@"see ContactsContract")]
				public static readonly string POSTAL = android.provider.ContactsContract.Intents.
					Insert.POSTAL;

				[System.ObsoleteAttribute(@"see ContactsContract")]
				public static readonly string POSTAL_TYPE = android.provider.ContactsContract.Intents
					.Insert.POSTAL_TYPE;

				[System.ObsoleteAttribute(@"see ContactsContract")]
				public static readonly string POSTAL_ISPRIMARY = android.provider.ContactsContract.Intents
					.Insert.POSTAL_ISPRIMARY;

				[System.ObsoleteAttribute(@"see ContactsContract")]
				public static readonly string IM_HANDLE = android.provider.ContactsContract.Intents
					.Insert.IM_HANDLE;

				[System.ObsoleteAttribute(@"see ContactsContract")]
				public static readonly string IM_PROTOCOL = android.provider.ContactsContract.Intents
					.Insert.IM_PROTOCOL;

				[System.ObsoleteAttribute(@"see ContactsContract")]
				public static readonly string IM_ISPRIMARY = android.provider.ContactsContract.Intents
					.Insert.IM_ISPRIMARY;
			}
		}
	}
}

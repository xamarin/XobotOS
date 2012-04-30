using Sharpen;

namespace android.provider
{
	[Sharpen.Stub]
	public sealed class MediaStore
	{
		internal const string TAG = "MediaStore";

		public const string AUTHORITY = "media";

		private static readonly string CONTENT_AUTHORITY_SLASH = "content://" + AUTHORITY
			 + "/";

		public const string ACTION_MTP_SESSION_END = "android.provider.action.MTP_SESSION_END";

		public const string INTENT_ACTION_MUSIC_PLAYER = "android.intent.action.MUSIC_PLAYER";

		public const string INTENT_ACTION_MEDIA_SEARCH = "android.intent.action.MEDIA_SEARCH";

		public const string INTENT_ACTION_MEDIA_PLAY_FROM_SEARCH = "android.media.action.MEDIA_PLAY_FROM_SEARCH";

		public const string EXTRA_MEDIA_ARTIST = "android.intent.extra.artist";

		public const string EXTRA_MEDIA_ALBUM = "android.intent.extra.album";

		public const string EXTRA_MEDIA_TITLE = "android.intent.extra.title";

		public const string EXTRA_MEDIA_FOCUS = "android.intent.extra.focus";

		public const string EXTRA_SCREEN_ORIENTATION = "android.intent.extra.screenOrientation";

		public const string EXTRA_FULL_SCREEN = "android.intent.extra.fullScreen";

		public const string EXTRA_SHOW_ACTION_ICONS = "android.intent.extra.showActionIcons";

		public const string EXTRA_FINISH_ON_COMPLETION = "android.intent.extra.finishOnCompletion";

		public const string INTENT_ACTION_STILL_IMAGE_CAMERA = "android.media.action.STILL_IMAGE_CAMERA";

		public const string INTENT_ACTION_VIDEO_CAMERA = "android.media.action.VIDEO_CAMERA";

		public const string ACTION_IMAGE_CAPTURE = "android.media.action.IMAGE_CAPTURE";

		public const string ACTION_VIDEO_CAPTURE = "android.media.action.VIDEO_CAPTURE";

		public const string EXTRA_VIDEO_QUALITY = "android.intent.extra.videoQuality";

		public const string EXTRA_SIZE_LIMIT = "android.intent.extra.sizeLimit";

		public const string EXTRA_DURATION_LIMIT = "android.intent.extra.durationLimit";

		public const string EXTRA_OUTPUT = "output";

		public const string UNKNOWN_STRING = "<unknown>";

		[Sharpen.Stub]
		public interface MediaColumns : android.provider.BaseColumns
		{
		}

		[Sharpen.Stub]
		public static class MediaColumnsClass
		{
			public const string DATA = "_data";

			public const string SIZE = "_size";

			public const string DISPLAY_NAME = "_display_name";

			public const string TITLE = "title";

			public const string DATE_ADDED = "date_added";

			public const string DATE_MODIFIED = "date_modified";

			public const string MIME_TYPE = "mime_type";

			public const string MEDIA_SCANNER_NEW_OBJECT_ID = "media_scanner_new_object_id";

			public const string IS_DRM = "is_drm";

			public const string WIDTH = "width";

			public const string HEIGHT = "height";
		}

		[Sharpen.Stub]
		public sealed class Files
		{
			[Sharpen.Stub]
			public static System.Uri getContentUri(string volumeName)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static System.Uri getContentUri(string volumeName, long rowId)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static System.Uri getMtpObjectsUri(string volumeName)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static System.Uri getMtpObjectsUri(string volumeName, long fileId)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static System.Uri getMtpReferencesUri(string volumeName, long fileId)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public interface FileColumns : android.provider.MediaStore.MediaColumns
			{
			}

			[Sharpen.Stub]
			public static class FileColumnsClass
			{
				public const string STORAGE_ID = "storage_id";

				public const string FORMAT = "format";

				public const string PARENT = "parent";

				public const string MIME_TYPE = "mime_type";

				public const string TITLE = "title";

				public const string MEDIA_TYPE = "media_type";

				public const int MEDIA_TYPE_NONE = 0;

				public const int MEDIA_TYPE_IMAGE = 1;

				public const int MEDIA_TYPE_AUDIO = 2;

				public const int MEDIA_TYPE_VIDEO = 3;

				public const int MEDIA_TYPE_PLAYLIST = 4;
			}
		}

		[Sharpen.Stub]
		private class InternalThumbnails : android.provider.BaseColumns
		{
			internal const int MINI_KIND = 1;

			internal const int FULL_SCREEN_KIND = 2;

			internal const int MICRO_KIND = 3;

			internal static readonly string[] PROJECTION = new string[] { android.provider.BaseColumnsClass._ID
				, android.provider.MediaStore.MediaColumnsClass.DATA };

			internal const int DEFAULT_GROUP_ID = 0;

			internal static readonly object sThumbBufLock = new object();

			internal static byte[] sThumbBuf;

			[Sharpen.Stub]
			internal static android.graphics.Bitmap getMiniThumbFromFile(android.database.Cursor
				 c, System.Uri baseUri, android.content.ContentResolver cr, android.graphics.BitmapFactory
				.Options options)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal static void cancelThumbnailRequest(android.content.ContentResolver cr, long
				 origId, System.Uri baseUri, long groupId)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal static android.graphics.Bitmap getThumbnail(android.content.ContentResolver
				 cr, long origId, long groupId, int kind, android.graphics.BitmapFactory.Options
				 options, System.Uri baseUri, bool isVideo)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public sealed class Images
		{
			[Sharpen.Stub]
			public interface ImageColumns : android.provider.MediaStore.MediaColumns
			{
			}

			[Sharpen.Stub]
			public static class ImageColumnsClass
			{
				public const string DESCRIPTION = "description";

				public const string PICASA_ID = "picasa_id";

				public const string IS_PRIVATE = "isprivate";

				public const string LATITUDE = "latitude";

				public const string LONGITUDE = "longitude";

				public const string DATE_TAKEN = "datetaken";

				public const string ORIENTATION = "orientation";

				public const string MINI_THUMB_MAGIC = "mini_thumb_magic";

				public const string BUCKET_ID = "bucket_id";

				public const string BUCKET_DISPLAY_NAME = "bucket_display_name";
			}

			[Sharpen.Stub]
			public sealed class Media : android.provider.MediaStore.Images.ImageColumns
			{
				[Sharpen.Stub]
				public static android.database.Cursor query(android.content.ContentResolver cr, System.Uri
					 uri, string[] projection)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				public static android.database.Cursor query(android.content.ContentResolver cr, System.Uri
					 uri, string[] projection, string where, string orderBy)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				public static android.database.Cursor query(android.content.ContentResolver cr, System.Uri
					 uri, string[] projection, string selection, string[] selectionArgs, string orderBy
					)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				public static android.graphics.Bitmap getBitmap(android.content.ContentResolver cr
					, System.Uri url)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				public static string insertImage(android.content.ContentResolver cr, string imagePath
					, string name, string description)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				private static android.graphics.Bitmap StoreThumbnail(android.content.ContentResolver
					 cr, android.graphics.Bitmap source, long id, float width, float height, int kind
					)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				public static string insertImage(android.content.ContentResolver cr, android.graphics.Bitmap
					 source, string title, string description)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				public static System.Uri getContentUri(string volumeName)
				{
					throw new System.NotImplementedException();
				}

				public static readonly System.Uri INTERNAL_CONTENT_URI = getContentUri("internal"
					);

				public static readonly System.Uri EXTERNAL_CONTENT_URI = getContentUri("external"
					);

				public const string CONTENT_TYPE = "vnd.android.cursor.dir/image";

				public static readonly string DEFAULT_SORT_ORDER = android.provider.MediaStore.Images.ImageColumnsClass.BUCKET_DISPLAY_NAME;
			}

			[Sharpen.Stub]
			public class Thumbnails : android.provider.BaseColumns
			{
				[Sharpen.Stub]
				public static android.database.Cursor query(android.content.ContentResolver cr, System.Uri
					 uri, string[] projection)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				public static android.database.Cursor queryMiniThumbnails(android.content.ContentResolver
					 cr, System.Uri uri, int kind, string[] projection)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				public static android.database.Cursor queryMiniThumbnail(android.content.ContentResolver
					 cr, long origId, int kind, string[] projection)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				public static void cancelThumbnailRequest(android.content.ContentResolver cr, long
					 origId)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				public static android.graphics.Bitmap getThumbnail(android.content.ContentResolver
					 cr, long origId, int kind, android.graphics.BitmapFactory.Options options)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				public static void cancelThumbnailRequest(android.content.ContentResolver cr, long
					 origId, long groupId)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				public static android.graphics.Bitmap getThumbnail(android.content.ContentResolver
					 cr, long origId, long groupId, int kind, android.graphics.BitmapFactory.Options
					 options)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				public static System.Uri getContentUri(string volumeName)
				{
					throw new System.NotImplementedException();
				}

				public static readonly System.Uri INTERNAL_CONTENT_URI = getContentUri("internal"
					);

				public static readonly System.Uri EXTERNAL_CONTENT_URI = getContentUri("external"
					);

				public const string DEFAULT_SORT_ORDER = "image_id ASC";

				public const string DATA = "_data";

				public const string IMAGE_ID = "image_id";

				public const string KIND = "kind";

				public const int MINI_KIND = 1;

				public const int FULL_SCREEN_KIND = 2;

				public const int MICRO_KIND = 3;

				public const string THUMB_DATA = "thumb_data";

				public const string WIDTH = "width";

				public const string HEIGHT = "height";
			}
		}

		[Sharpen.Stub]
		public sealed class Audio
		{
			[Sharpen.Stub]
			public interface AudioColumns : android.provider.MediaStore.MediaColumns
			{
			}

			[Sharpen.Stub]
			public static class AudioColumnsClass
			{
				public const string TITLE_KEY = "title_key";

				public const string DURATION = "duration";

				public const string BOOKMARK = "bookmark";

				public const string ARTIST_ID = "artist_id";

				public const string ARTIST = "artist";

				public const string ALBUM_ARTIST = "album_artist";

				public const string COMPILATION = "compilation";

				public const string ARTIST_KEY = "artist_key";

				public const string COMPOSER = "composer";

				public const string ALBUM_ID = "album_id";

				public const string ALBUM = "album";

				public const string ALBUM_KEY = "album_key";

				public const string TRACK = "track";

				public const string YEAR = "year";

				public const string IS_MUSIC = "is_music";

				public const string IS_PODCAST = "is_podcast";

				public const string IS_RINGTONE = "is_ringtone";

				public const string IS_ALARM = "is_alarm";

				public const string IS_NOTIFICATION = "is_notification";

				public const string GENRE = "genre";
			}

			[Sharpen.Stub]
			public static string keyFor(string name)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public sealed class Media : android.provider.MediaStore.Audio.AudioColumns
			{
				[Sharpen.Stub]
				public static System.Uri getContentUri(string volumeName)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				public static System.Uri getContentUriForPath(string path)
				{
					throw new System.NotImplementedException();
				}

				public static readonly System.Uri INTERNAL_CONTENT_URI = getContentUri("internal"
					);

				public static readonly System.Uri EXTERNAL_CONTENT_URI = getContentUri("external"
					);

				public const string CONTENT_TYPE = "vnd.android.cursor.dir/audio";

				public static readonly string DEFAULT_SORT_ORDER = android.provider.MediaStore.Audio.AudioColumnsClass.TITLE_KEY;

				public const string RECORD_SOUND_ACTION = "android.provider.MediaStore.RECORD_SOUND";

				public const string EXTRA_MAX_BYTES = "android.provider.MediaStore.extra.MAX_BYTES";
			}

			[Sharpen.Stub]
			public interface GenresColumns
			{
			}

			[Sharpen.Stub]
			public static class GenresColumnsClass
			{
				public const string NAME = "name";
			}

			[Sharpen.Stub]
			public sealed class Genres : android.provider.BaseColumns, android.provider.MediaStore.Audio
				.GenresColumns
			{
				[Sharpen.Stub]
				public static System.Uri getContentUri(string volumeName)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				public static System.Uri getContentUriForAudioId(string volumeName, int audioId)
				{
					throw new System.NotImplementedException();
				}

				public static readonly System.Uri INTERNAL_CONTENT_URI = getContentUri("internal"
					);

				public static readonly System.Uri EXTERNAL_CONTENT_URI = getContentUri("external"
					);

				public const string CONTENT_TYPE = "vnd.android.cursor.dir/genre";

				public const string ENTRY_CONTENT_TYPE = "vnd.android.cursor.item/genre";

				public static readonly string DEFAULT_SORT_ORDER = android.provider.MediaStore.Audio.GenresColumnsClass.NAME;

				[Sharpen.Stub]
				public sealed class Members : android.provider.MediaStore.Audio.AudioColumns
				{
					[Sharpen.Stub]
					public static System.Uri getContentUri(string volumeName, long genreId)
					{
						throw new System.NotImplementedException();
					}

					public const string CONTENT_DIRECTORY = "members";

					public static readonly string DEFAULT_SORT_ORDER = android.provider.MediaStore.Audio.AudioColumnsClass.TITLE_KEY;

					public const string AUDIO_ID = "audio_id";

					public const string GENRE_ID = "genre_id";
				}
			}

			[Sharpen.Stub]
			public interface PlaylistsColumns
			{
			}

			[Sharpen.Stub]
			public static class PlaylistsColumnsClass
			{
				public const string NAME = "name";

				public const string DATA = "_data";

				public const string DATE_ADDED = "date_added";

				public const string DATE_MODIFIED = "date_modified";
			}

			[Sharpen.Stub]
			public sealed class Playlists : android.provider.BaseColumns, android.provider.MediaStore.Audio
				.PlaylistsColumns
			{
				[Sharpen.Stub]
				public static System.Uri getContentUri(string volumeName)
				{
					throw new System.NotImplementedException();
				}

				public static readonly System.Uri INTERNAL_CONTENT_URI = getContentUri("internal"
					);

				public static readonly System.Uri EXTERNAL_CONTENT_URI = getContentUri("external"
					);

				public const string CONTENT_TYPE = "vnd.android.cursor.dir/playlist";

				public const string ENTRY_CONTENT_TYPE = "vnd.android.cursor.item/playlist";

				public static readonly string DEFAULT_SORT_ORDER = android.provider.MediaStore.Audio.PlaylistsColumnsClass.NAME;

				[Sharpen.Stub]
				public sealed class Members : android.provider.MediaStore.Audio.AudioColumns
				{
					[Sharpen.Stub]
					public static System.Uri getContentUri(string volumeName, long playlistId)
					{
						throw new System.NotImplementedException();
					}

					[Sharpen.Stub]
					public static bool moveItem(android.content.ContentResolver res, long playlistId, 
						int from, int to)
					{
						throw new System.NotImplementedException();
					}

					public const string _ID = "_id";

					public const string CONTENT_DIRECTORY = "members";

					public const string AUDIO_ID = "audio_id";

					public const string PLAYLIST_ID = "playlist_id";

					public const string PLAY_ORDER = "play_order";

					public static readonly string DEFAULT_SORT_ORDER = PLAY_ORDER;
				}
			}

			[Sharpen.Stub]
			public interface ArtistColumns
			{
			}

			[Sharpen.Stub]
			public static class ArtistColumnsClass
			{
				public const string ARTIST = "artist";

				public const string ARTIST_KEY = "artist_key";

				public const string NUMBER_OF_ALBUMS = "number_of_albums";

				public const string NUMBER_OF_TRACKS = "number_of_tracks";
			}

			[Sharpen.Stub]
			public sealed class Artists : android.provider.BaseColumns, android.provider.MediaStore.Audio
				.ArtistColumns
			{
				[Sharpen.Stub]
				public static System.Uri getContentUri(string volumeName)
				{
					throw new System.NotImplementedException();
				}

				public static readonly System.Uri INTERNAL_CONTENT_URI = getContentUri("internal"
					);

				public static readonly System.Uri EXTERNAL_CONTENT_URI = getContentUri("external"
					);

				public const string CONTENT_TYPE = "vnd.android.cursor.dir/artists";

				public const string ENTRY_CONTENT_TYPE = "vnd.android.cursor.item/artist";

				public static readonly string DEFAULT_SORT_ORDER = android.provider.MediaStore.Audio.ArtistColumnsClass.ARTIST_KEY;

				[Sharpen.Stub]
				public sealed class Albums : android.provider.MediaStore.Audio.AlbumColumns
				{
					[Sharpen.Stub]
					public static System.Uri getContentUri(string volumeName, long artistId)
					{
						throw new System.NotImplementedException();
					}
				}
			}

			[Sharpen.Stub]
			public interface AlbumColumns
			{
			}

			[Sharpen.Stub]
			public static class AlbumColumnsClass
			{
				public const string ALBUM_ID = "album_id";

				public const string ALBUM = "album";

				public const string ARTIST = "artist";

				public const string NUMBER_OF_SONGS = "numsongs";

				public const string NUMBER_OF_SONGS_FOR_ARTIST = "numsongs_by_artist";

				public const string FIRST_YEAR = "minyear";

				public const string LAST_YEAR = "maxyear";

				public const string ALBUM_KEY = "album_key";

				public const string ALBUM_ART = "album_art";
			}

			[Sharpen.Stub]
			public sealed class Albums : android.provider.BaseColumns, android.provider.MediaStore.Audio
				.AlbumColumns
			{
				[Sharpen.Stub]
				public static System.Uri getContentUri(string volumeName)
				{
					throw new System.NotImplementedException();
				}

				public static readonly System.Uri INTERNAL_CONTENT_URI = getContentUri("internal"
					);

				public static readonly System.Uri EXTERNAL_CONTENT_URI = getContentUri("external"
					);

				public const string CONTENT_TYPE = "vnd.android.cursor.dir/albums";

				public const string ENTRY_CONTENT_TYPE = "vnd.android.cursor.item/album";

				public static readonly string DEFAULT_SORT_ORDER = android.provider.MediaStore.Audio.AlbumColumnsClass.ALBUM_KEY;
			}
		}

		[Sharpen.Stub]
		public sealed class Video
		{
			public static readonly string DEFAULT_SORT_ORDER = android.provider.MediaStore.MediaColumnsClass.DISPLAY_NAME;

			[Sharpen.Stub]
			public static android.database.Cursor query(android.content.ContentResolver cr, System.Uri
				 uri, string[] projection)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public interface VideoColumns : android.provider.MediaStore.MediaColumns
			{
			}

			[Sharpen.Stub]
			public static class VideoColumnsClass
			{
				public const string DURATION = "duration";

				public const string ARTIST = "artist";

				public const string ALBUM = "album";

				public const string RESOLUTION = "resolution";

				public const string DESCRIPTION = "description";

				public const string IS_PRIVATE = "isprivate";

				public const string TAGS = "tags";

				public const string CATEGORY = "category";

				public const string LANGUAGE = "language";

				public const string LATITUDE = "latitude";

				public const string LONGITUDE = "longitude";

				public const string DATE_TAKEN = "datetaken";

				public const string MINI_THUMB_MAGIC = "mini_thumb_magic";

				public const string BUCKET_ID = "bucket_id";

				public const string BUCKET_DISPLAY_NAME = "bucket_display_name";

				public const string BOOKMARK = "bookmark";
			}

			[Sharpen.Stub]
			public sealed class Media : android.provider.MediaStore.Video.VideoColumns
			{
				[Sharpen.Stub]
				public static System.Uri getContentUri(string volumeName)
				{
					throw new System.NotImplementedException();
				}

				public static readonly System.Uri INTERNAL_CONTENT_URI = getContentUri("internal"
					);

				public static readonly System.Uri EXTERNAL_CONTENT_URI = getContentUri("external"
					);

				public const string CONTENT_TYPE = "vnd.android.cursor.dir/video";

				public static readonly string DEFAULT_SORT_ORDER = android.provider.MediaStore.MediaColumnsClass.TITLE;
			}

			[Sharpen.Stub]
			public class Thumbnails : android.provider.BaseColumns
			{
				[Sharpen.Stub]
				public static void cancelThumbnailRequest(android.content.ContentResolver cr, long
					 origId)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				public static android.graphics.Bitmap getThumbnail(android.content.ContentResolver
					 cr, long origId, int kind, android.graphics.BitmapFactory.Options options)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				public static android.graphics.Bitmap getThumbnail(android.content.ContentResolver
					 cr, long origId, long groupId, int kind, android.graphics.BitmapFactory.Options
					 options)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				public static void cancelThumbnailRequest(android.content.ContentResolver cr, long
					 origId, long groupId)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				public static System.Uri getContentUri(string volumeName)
				{
					throw new System.NotImplementedException();
				}

				public static readonly System.Uri INTERNAL_CONTENT_URI = getContentUri("internal"
					);

				public static readonly System.Uri EXTERNAL_CONTENT_URI = getContentUri("external"
					);

				public const string DEFAULT_SORT_ORDER = "video_id ASC";

				public const string DATA = "_data";

				public const string VIDEO_ID = "video_id";

				public const string KIND = "kind";

				public const int MINI_KIND = 1;

				public const int FULL_SCREEN_KIND = 2;

				public const int MICRO_KIND = 3;

				public const string WIDTH = "width";

				public const string HEIGHT = "height";
			}
		}

		[Sharpen.Stub]
		public static System.Uri getMediaScannerUri()
		{
			throw new System.NotImplementedException();
		}

		public const string MEDIA_SCANNER_VOLUME = "volume";

		public const string MEDIA_IGNORE_FILENAME = ".nomedia";

		[Sharpen.Stub]
		public static string getVersion(android.content.Context context)
		{
			throw new System.NotImplementedException();
		}
	}
}

using Sharpen;

namespace android.provider
{
	[Sharpen.Stub]
	public sealed class DrmStore
	{
		internal const string TAG = "DrmStore";

		public const string AUTHORITY = "drm";

		internal const string ACCESS_DRM_PERMISSION = "android.permission.ACCESS_DRM";

		[Sharpen.Stub]
		public interface Columns : android.provider.BaseColumns
		{
		}

		[Sharpen.Stub]
		public static class ColumnsClass
		{
			public const string DATA = "_data";

			public const string SIZE = "_size";

			public const string TITLE = "title";

			public const string MIME_TYPE = "mime_type";
		}

		[Sharpen.Stub]
		public interface Images : android.provider.DrmStore.Columns
		{
		}

		[Sharpen.Stub]
		public static class ImagesClass
		{
			public static readonly System.Uri CONTENT_URI = null;
		}

		[Sharpen.Stub]
		public interface Audio : android.provider.DrmStore.Columns
		{
		}

		[Sharpen.Stub]
		public static class AudioClass
		{
			public static readonly System.Uri CONTENT_URI = null;
		}

		[Sharpen.Stub]
		public static android.content.Intent addDrmFile(android.content.ContentResolver cr
			, java.io.File file, string title)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.content.Intent addDrmFile(android.content.ContentResolver cr
			, java.io.FileInputStream fis, string title)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void enforceAccessDrmPermission(android.content.Context context)
		{
			throw new System.NotImplementedException();
		}
	}
}

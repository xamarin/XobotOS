using Sharpen;

namespace android.content
{
	[Sharpen.Stub]
	public class UriMatcher
	{
		public const int NO_MATCH = -1;

		[Sharpen.Stub]
		public UriMatcher(int code)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private UriMatcher()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void addURI(string authority, string path, int code)
		{
			throw new System.NotImplementedException();
		}

		internal static readonly java.util.regex.Pattern PATH_SPLIT_PATTERN = java.util.regex.Pattern
			.compile("/");

		[Sharpen.Stub]
		public virtual int match(System.Uri uri)
		{
			throw new System.NotImplementedException();
		}

		internal const int EXACT = 0;

		internal const int NUMBER = 1;

		internal const int TEXT = 2;

		private int mCode;

		private int mWhich;

		private string mText;

		private java.util.ArrayList<android.content.UriMatcher> mChildren;
	}
}

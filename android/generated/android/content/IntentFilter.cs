using Sharpen;

namespace android.content
{
	[Sharpen.Stub]
	public class IntentFilter : android.os.Parcelable
	{
		internal const string SGLOB_STR = "sglob";

		internal const string PREFIX_STR = "prefix";

		internal const string LITERAL_STR = "literal";

		internal const string PATH_STR = "path";

		internal const string PORT_STR = "port";

		internal const string HOST_STR = "host";

		internal const string AUTH_STR = "auth";

		internal const string SCHEME_STR = "scheme";

		internal const string TYPE_STR = "type";

		internal const string CAT_STR = "cat";

		internal const string NAME_STR = "name";

		internal const string ACTION_STR = "action";

		public const int SYSTEM_HIGH_PRIORITY = 1000;

		public const int SYSTEM_LOW_PRIORITY = -1000;

		public const int MATCH_CATEGORY_MASK = unchecked((int)(0xfff0000));

		public const int MATCH_ADJUSTMENT_MASK = unchecked((int)(0x000ffff));

		public const int MATCH_ADJUSTMENT_NORMAL = unchecked((int)(0x8000));

		public const int MATCH_CATEGORY_EMPTY = unchecked((int)(0x0100000));

		public const int MATCH_CATEGORY_SCHEME = unchecked((int)(0x0200000));

		public const int MATCH_CATEGORY_HOST = unchecked((int)(0x0300000));

		public const int MATCH_CATEGORY_PORT = unchecked((int)(0x0400000));

		public const int MATCH_CATEGORY_PATH = unchecked((int)(0x0500000));

		public const int MATCH_CATEGORY_TYPE = unchecked((int)(0x0600000));

		public const int NO_MATCH_TYPE = -1;

		public const int NO_MATCH_DATA = -2;

		public const int NO_MATCH_ACTION = -3;

		public const int NO_MATCH_CATEGORY = -4;

		private int mPriority;

		private readonly java.util.ArrayList<string> mActions;

		private java.util.ArrayList<string> mCategories = null;

		private java.util.ArrayList<string> mDataSchemes = null;

		private java.util.ArrayList<android.content.IntentFilter.AuthorityEntry> mDataAuthorities
			 = null;

		private java.util.ArrayList<android.os.PatternMatcher> mDataPaths = null;

		private java.util.ArrayList<string> mDataTypes = null;

		private bool mHasPartialTypes = false;

		[Sharpen.Stub]
		private static int findStringInSet(string[] set, string @string, int[] lengths, int
			 lenPos)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static string[] addStringToSet(string[] set, string @string, int[] lengths
			, int lenPos)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static string[] removeStringFromSet(string[] set, string @string, int[] lengths
			, int lenPos)
		{
			throw new System.NotImplementedException();
		}

		[System.Serializable]
		[Sharpen.Stub]
		public class MalformedMimeTypeException : android.util.AndroidException
		{
			[Sharpen.Stub]
			public MalformedMimeTypeException()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public MalformedMimeTypeException(string name) : base(name)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public static android.content.IntentFilter create(string action, string dataType)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public IntentFilter()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public IntentFilter(string action)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public IntentFilter(string action, string dataType)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public IntentFilter(android.content.IntentFilter o)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void setPriority(int priority)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int getPriority()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void addAction(string action)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int countActions()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public string getAction(int index)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool hasAction(string action)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool matchAction(string action)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public java.util.Iterator<string> actionsIterator()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void addDataType(string type)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool hasDataType(string type)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int countDataTypes()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public string getDataType(int index)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public java.util.Iterator<string> typesIterator()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void addDataScheme(string scheme)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int countDataSchemes()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public string getDataScheme(int index)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool hasDataScheme(string scheme)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public java.util.Iterator<string> schemesIterator()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public sealed class AuthorityEntry
		{
			private readonly string mOrigHost;

			private readonly string mHost;

			private readonly bool mWild;

			private readonly int mPort;

			[Sharpen.Stub]
			public AuthorityEntry(string host, string port)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal AuthorityEntry(android.os.Parcel src)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal void writeToParcel(android.os.Parcel dest)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public string getHost()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public int getPort()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public int match(System.Uri data)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public void addDataAuthority(string host, string port)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int countDataAuthorities()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.content.IntentFilter.AuthorityEntry getDataAuthority(int index)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool hasDataAuthority(System.Uri data)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public java.util.Iterator<android.content.IntentFilter.AuthorityEntry> authoritiesIterator
			()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void addDataPath(string path, int type)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int countDataPaths()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.os.PatternMatcher getDataPath(int index)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool hasDataPath(string data)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public java.util.Iterator<android.os.PatternMatcher> pathsIterator()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int matchDataAuthority(System.Uri data)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int matchData(string type, string scheme, System.Uri data)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void addCategory(string category)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int countCategories()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public string getCategory(int index)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool hasCategory(string category)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public java.util.Iterator<string> categoriesIterator()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public string matchCategories(java.util.Set<string> categories)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int match(android.content.ContentResolver resolver, android.content.Intent
			 intent, bool resolve, string logTag)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int match(string action, string type, string scheme, System.Uri data, java.util.Set
			<string> categories, string logTag)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void writeToXml(org.xmlpull.v1.XmlSerializer serializer)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void readFromXml(org.xmlpull.v1.XmlPullParser parser)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void dump(android.util.Printer du, string prefix)
		{
			throw new System.NotImplementedException();
		}

		private sealed class _Creator_1331 : android.os.ParcelableClass.Creator<android.content.IntentFilter
			>
		{
			public _Creator_1331()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.IntentFilter createFromParcel(android.os.Parcel source)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.IntentFilter[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.content.IntentFilter
			> CREATOR = new _Creator_1331();

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual int describeContents()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual void writeToParcel(android.os.Parcel dest, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool debugCheck()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private IntentFilter(android.os.Parcel source)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private bool findMimeType(string type)
		{
			throw new System.NotImplementedException();
		}
	}
}

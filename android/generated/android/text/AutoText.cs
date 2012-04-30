using Sharpen;

namespace android.text
{
	[Sharpen.Stub]
	public class AutoText
	{
		internal const int TRIE_C = 0;

		internal const int TRIE_OFF = 1;

		internal const int TRIE_CHILD = 2;

		internal const int TRIE_NEXT = 3;

		internal const int TRIE_SIZEOF = 4;

		internal const char TRIE_NULL = unchecked ((char)-1);

		internal const int TRIE_ROOT = 0;

		internal const int INCREMENT = 1024;

		internal const int DEFAULT = 14337;

		internal const int RIGHT = 9300;

		private static android.text.AutoText sInstance = new android.text.AutoText(android.content.res.Resources
			.getSystem());

		private static object sLock = new object();

		private char[] mTrie;

		private char mTrieUsed;

		private string mText;

		private System.Globalization.CultureInfo mLocale;

		private int mSize;

		[Sharpen.Stub]
		private AutoText(android.content.res.Resources resources)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static android.text.AutoText getInstance(android.view.View view)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static string get(java.lang.CharSequence src, int start, int end, android.view.View
			 view)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int getSize(android.view.View view)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private int getSize()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private string lookup(java.lang.CharSequence src, int start, int end)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void init(android.content.res.Resources r)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void add(string src, char off)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private char newTrieNode()
		{
			throw new System.NotImplementedException();
		}
	}
}

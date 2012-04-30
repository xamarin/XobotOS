using Sharpen;

namespace android.text.util
{
	[Sharpen.Stub]
	public class Linkify
	{
		public const int WEB_URLS = unchecked((int)(0x01));

		public const int EMAIL_ADDRESSES = unchecked((int)(0x02));

		public const int PHONE_NUMBERS = unchecked((int)(0x04));

		public const int MAP_ADDRESSES = unchecked((int)(0x08));

		public const int ALL = WEB_URLS | EMAIL_ADDRESSES | PHONE_NUMBERS | MAP_ADDRESSES;

		internal const int PHONE_NUMBER_MINIMUM_DIGITS = 5;

		private sealed class _MatchFilter_95 : android.text.util.Linkify.MatchFilter
		{
			public _MatchFilter_95()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.text.util.Linkify.MatchFilter")]
			public bool acceptMatch(java.lang.CharSequence s, int start, int end)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.text.util.Linkify.MatchFilter sUrlMatchFilter = new 
			_MatchFilter_95();

		private sealed class _MatchFilter_113 : android.text.util.Linkify.MatchFilter
		{
			public _MatchFilter_113()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.text.util.Linkify.MatchFilter")]
			public bool acceptMatch(java.lang.CharSequence s, int start, int end)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.text.util.Linkify.MatchFilter sPhoneNumberMatchFilter
			 = new _MatchFilter_113();

		private sealed class _TransformFilter_136 : android.text.util.Linkify.TransformFilter
		{
			public _TransformFilter_136()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.text.util.Linkify.TransformFilter")]
			public string transformUrl(java.util.regex.Matcher match, string url)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.text.util.Linkify.TransformFilter sPhoneNumberTransformFilter
			 = new _TransformFilter_136();

		[Sharpen.Stub]
		public interface MatchFilter
		{
			[Sharpen.Stub]
			bool acceptMatch(java.lang.CharSequence s, int start, int end);
		}

		[Sharpen.Stub]
		public interface TransformFilter
		{
			[Sharpen.Stub]
			string transformUrl(java.util.regex.Matcher match, string url);
		}

		[Sharpen.Stub]
		public static bool addLinks(android.text.Spannable text, int mask)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static bool addLinks(android.widget.TextView text, int mask)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void addLinkMovementMethod(android.widget.TextView t)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void addLinks(android.widget.TextView text, java.util.regex.Pattern
			 pattern, string scheme)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void addLinks(android.widget.TextView text, java.util.regex.Pattern
			 p, string scheme, android.text.util.Linkify.MatchFilter matchFilter, android.text.util.Linkify
			.TransformFilter transformFilter)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static bool addLinks(android.text.Spannable text, java.util.regex.Pattern 
			pattern, string scheme)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static bool addLinks(android.text.Spannable s, java.util.regex.Pattern p, 
			string scheme, android.text.util.Linkify.MatchFilter matchFilter, android.text.util.Linkify
			.TransformFilter transformFilter)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void applyLink(string url, int start, int end, android.text.Spannable
			 text)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static string makeUrl(string url, string[] prefixes, java.util.regex.Matcher
			 m, android.text.util.Linkify.TransformFilter filter)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal static void gatherLinks(java.util.ArrayList<android.text.util.LinkSpec> 
			links, android.text.Spannable s, java.util.regex.Pattern pattern, string[] schemes
			, android.text.util.Linkify.MatchFilter matchFilter, android.text.util.Linkify.TransformFilter
			 transformFilter)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal static void gatherMapLinks(java.util.ArrayList<android.text.util.LinkSpec
			> links, android.text.Spannable s)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal static void pruneOverlaps(java.util.ArrayList<android.text.util.LinkSpec
			> links)
		{
			throw new System.NotImplementedException();
		}
	}

	[Sharpen.Stub]
	internal class LinkSpec
	{
		internal string url;

		internal int start;

		internal int end;
	}
}

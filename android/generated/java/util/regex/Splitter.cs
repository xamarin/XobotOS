using Sharpen;

namespace java.util.regex
{
	/// <summary>
	/// Used to make
	/// <code>String.split</code>
	/// fast (and to help
	/// <code>Pattern.split</code>
	/// too).
	/// </summary>
	/// <hide></hide>
	[Sharpen.Sharpened]
	public class Splitter
	{
		internal const string METACHARACTERS = "\\?*+[](){}^$.|";

		private Splitter()
		{
		}

		// The RI allows regular expressions beginning with ] or }, but that's probably a bug.
		/// <summary>
		/// Returns a result equivalent to
		/// <code>s.split(separator, limit)</code>
		/// if it's able
		/// to compute it more cheaply than ICU, or null if the caller should fall back to
		/// using ICU.
		/// </summary>
		public static string[] fastSplit(string re, string input, int limit)
		{
			// Can we do it cheaply?
			int len = re.Length;
			if (len == 0)
			{
				return null;
			}
			char ch = re[0];
			if (len == 1 && METACHARACTERS.IndexOf(ch) == -1)
			{
			}
			else
			{
				// We're looking for a single non-metacharacter. Easy.
				if (len == 2 && ch == '\\')
				{
					// We're looking for a quoted character.
					// Quoted metacharacters are effectively single non-metacharacters.
					ch = re[1];
					if (METACHARACTERS.IndexOf(ch) == -1)
					{
						return null;
					}
				}
				else
				{
					return null;
				}
			}
			// We can do this cheaply...
			// Unlike Perl, which considers the result of splitting the empty string to be the empty
			// array, Java returns an array containing the empty string.
			if (string.IsNullOrEmpty(input))
			{
				return new string[] { string.Empty };
			}
			// Collect text preceding each occurrence of the separator, while there's enough space.
			java.util.ArrayList<string> list = new java.util.ArrayList<string>();
			int maxSize = limit <= 0 ? int.MaxValue : limit;
			int begin = 0;
			int end;
			while ((end = input.IndexOf(ch, begin)) != -1 && list.size() + 1 < maxSize)
			{
				list.add(Sharpen.StringHelper.Substring(input, begin, end));
				begin = end + 1;
			}
			return finishSplit(list, input, begin, maxSize, limit);
		}

		public static string[] split(java.util.regex.Pattern pattern, string re, string input
			, int limit)
		{
			string[] fastResult = fastSplit(re, input, limit);
			if (fastResult != null)
			{
				return fastResult;
			}
			// Unlike Perl, which considers the result of splitting the empty string to be the empty
			// array, Java returns an array containing the empty string.
			if (string.IsNullOrEmpty(input))
			{
				return new string[] { string.Empty };
			}
			// Collect text preceding each occurrence of the separator, while there's enough space.
			java.util.ArrayList<string> list = new java.util.ArrayList<string>();
			int maxSize = limit <= 0 ? int.MaxValue : limit;
			java.util.regex.Matcher matcher = new java.util.regex.Matcher(pattern, java.lang.CharSequenceProxy.Wrap
				(input));
			int begin = 0;
			while (matcher.find() && list.size() + 1 < maxSize)
			{
				list.add(Sharpen.StringHelper.Substring(input, begin, matcher.start()));
				begin = matcher.end();
			}
			return finishSplit(list, input, begin, maxSize, limit);
		}

		private static string[] finishSplit(java.util.List<string> list, string input, int
			 begin, int maxSize, int limit)
		{
			// Add trailing text.
			if (begin < input.Length)
			{
				list.add(Sharpen.StringHelper.Substring(input, begin));
			}
			else
			{
				if (limit != 0)
				{
					// No point adding the empty string if limit == 0, just to remove it below.
					list.add(string.Empty);
				}
			}
			// Remove all trailing empty matches in the limit == 0 case.
			if (limit == 0)
			{
				int i = list.size() - 1;
				while (i >= 0 && string.IsNullOrEmpty(list.get(i)))
				{
					list.remove(i);
					i--;
				}
			}
			// Convert to an array.
			return list.toArray(new string[list.size()]);
		}
	}
}

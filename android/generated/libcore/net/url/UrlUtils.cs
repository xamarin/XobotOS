using Sharpen;

namespace libcore.net.url
{
	[Sharpen.Sharpened]
	public sealed class UrlUtils
	{
		private UrlUtils()
		{
		}

		/// <summary>Returns the path will relative path segments like ".." and "." resolved.
		/// 	</summary>
		/// <remarks>
		/// Returns the path will relative path segments like ".." and "." resolved.
		/// The returned path will not necessarily start with a "/" character. This
		/// handles ".." and "." segments at both the beginning and end of the path.
		/// </remarks>
		/// <param name="discardRelativePrefix">
		/// true to remove leading ".." segments from
		/// the path. This is appropriate for paths that are known to be
		/// absolute.
		/// </param>
		public static string canonicalizePath(string path, bool discardRelativePrefix)
		{
			// the first character of the current path segment
			int segmentStart = 0;
			// the number of segments seen thus far that can be erased by sequences of '..'.
			int deletableSegments = 0;
			{
				for (int i = 0; i <= path.Length; )
				{
					int nextSegmentStart;
					if (i == path.Length)
					{
						nextSegmentStart = i;
					}
					else
					{
						if (path[i] == '/')
						{
							nextSegmentStart = i + 1;
						}
						else
						{
							i++;
							continue;
						}
					}
					if (i == segmentStart + 1 && Sharpen.StringHelper.RegionMatches(path, segmentStart
						, ".", 0, 1))
					{
						// Given "abc/def/./ghi", remove "./" to get "abc/def/ghi".
						path = Sharpen.StringHelper.Substring(path, 0, segmentStart) + Sharpen.StringHelper.Substring
							(path, nextSegmentStart);
						i = segmentStart;
					}
					else
					{
						if (i == segmentStart + 2 && Sharpen.StringHelper.RegionMatches(path, segmentStart
							, "..", 0, 2))
						{
							if (deletableSegments > 0 || discardRelativePrefix)
							{
								// Given "abc/def/../ghi", remove "def/../" to get "abc/ghi".
								deletableSegments--;
								int prevSegmentStart = path.LastIndexOf('/', segmentStart - 2) + 1;
								path = Sharpen.StringHelper.Substring(path, 0, prevSegmentStart) + Sharpen.StringHelper.Substring
									(path, nextSegmentStart);
								i = segmentStart = prevSegmentStart;
							}
							else
							{
								// There's no segment to delete; this ".." segment must be retained.
								i++;
								segmentStart = i;
							}
						}
						else
						{
							if (i > 0)
							{
								deletableSegments++;
							}
							i++;
							segmentStart = i;
						}
					}
				}
			}
			return path;
		}

		/// <summary>
		/// Returns a path that can be safely concatenated with
		/// <code>authority</code>
		/// . If
		/// the authority is null or empty, this can be any path. Otherwise the paths
		/// run together like
		/// <code>http://android.comindex.html</code>
		/// .
		/// </summary>
		public static string authoritySafePath(string authority, string path)
		{
			if (authority != null && !string.IsNullOrEmpty(authority) && !string.IsNullOrEmpty
				(path) && !path.StartsWith("/"))
			{
				return "/" + path;
			}
			return path;
		}

		/// <summary>
		/// Returns the scheme prefix like "http" from the URL spec, or null if the
		/// spec doesn't start with a scheme.
		/// </summary>
		/// <remarks>
		/// Returns the scheme prefix like "http" from the URL spec, or null if the
		/// spec doesn't start with a scheme. Scheme prefixes match this pattern:
		/// <code>alpha ( alpha | digit | '+' | '-' | '.' )* ':'</code>
		/// </remarks>
		public static string getSchemePrefix(string spec)
		{
			int colon = spec.IndexOf(':');
			if (colon < 1)
			{
				return null;
			}
			{
				for (int i = 0; i < colon; i++)
				{
					char c = spec[i];
					if (!isValidSchemeChar(i, c))
					{
						return null;
					}
				}
			}
			return Sharpen.StringHelper.Substring(spec, 0, colon).ToLower(System.Globalization.CultureInfo.InvariantCulture
				);
		}

		public static bool isValidSchemeChar(int index, char c)
		{
			if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
			{
				return true;
			}
			if (index > 0 && ((c >= '0' && c <= '9') || c == '+' || c == '-' || c == '.'))
			{
				return true;
			}
			return false;
		}

		/// <summary>
		/// Returns the index of the first char of
		/// <code>chars</code>
		/// in
		/// <code>string</code>
		/// bounded between
		/// <code>start</code>
		/// and
		/// <code>end</code>
		/// . This returns
		/// <code>end</code>
		/// if none of the characters exist in the requested range.
		/// </summary>
		public static int findFirstOf(string @string, string chars, int start, int end)
		{
			{
				for (int i = start; i < end; i++)
				{
					char c = @string[i];
					if (chars.IndexOf(c) != -1)
					{
						return i;
					}
				}
			}
			return end;
		}
	}
}

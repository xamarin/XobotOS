using Sharpen;

namespace java.util.regex
{
	/// <summary>
	/// Holds the results of a successful match of a regular expression against a
	/// given string.
	/// </summary>
	/// <remarks>
	/// Holds the results of a successful match of a regular expression against a
	/// given string. Only used internally, thus sparsely documented (though the
	/// defining public interface has full documentation).
	/// </remarks>
	/// <seealso cref="MatchResult">MatchResult</seealso>
	[Sharpen.Sharpened]
	internal class MatchResultImpl : java.util.regex.MatchResult
	{
		/// <summary>Holds the original input text.</summary>
		/// <remarks>Holds the original input text.</remarks>
		private string text;

		/// <summary>Holds the offsets of the groups in the input text.</summary>
		/// <remarks>
		/// Holds the offsets of the groups in the input text. The first two
		/// elements specifiy start and end of the zero group, the next two specify
		/// group 1, and so on.
		/// </remarks>
		private int[] offsets;

		internal MatchResultImpl(string text, int[] offsets)
		{
			this.text = text;
			this.offsets = (int[])offsets.Clone();
		}

		[Sharpen.ImplementsInterface(@"java.util.regex.MatchResult")]
		public virtual int end()
		{
			return end(0);
		}

		[Sharpen.ImplementsInterface(@"java.util.regex.MatchResult")]
		public virtual int end(int group_1)
		{
			return offsets[2 * group_1 + 1];
		}

		[Sharpen.ImplementsInterface(@"java.util.regex.MatchResult")]
		public virtual string group()
		{
			return Sharpen.StringHelper.Substring(text, start(), end());
		}

		[Sharpen.ImplementsInterface(@"java.util.regex.MatchResult")]
		public virtual string group(int group_1)
		{
			int from = offsets[group_1 * 2];
			int to = offsets[(group_1 * 2) + 1];
			if (from == -1 || to == -1)
			{
				return null;
			}
			else
			{
				return Sharpen.StringHelper.Substring(text, from, to);
			}
		}

		[Sharpen.ImplementsInterface(@"java.util.regex.MatchResult")]
		public virtual int groupCount()
		{
			return (offsets.Length / 2) - 1;
		}

		[Sharpen.ImplementsInterface(@"java.util.regex.MatchResult")]
		public virtual int start()
		{
			return start(0);
		}

		[Sharpen.ImplementsInterface(@"java.util.regex.MatchResult")]
		public virtual int start(int group_1)
		{
			return offsets[2 * group_1];
		}
	}
}

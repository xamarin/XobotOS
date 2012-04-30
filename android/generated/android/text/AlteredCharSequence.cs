using Sharpen;

namespace android.text
{
	/// <summary>
	/// An AlteredCharSequence is a CharSequence that is largely mirrored from
	/// another CharSequence, except that a specified range of characters are
	/// mirrored from a different char array instead.
	/// </summary>
	/// <remarks>
	/// An AlteredCharSequence is a CharSequence that is largely mirrored from
	/// another CharSequence, except that a specified range of characters are
	/// mirrored from a different char array instead.
	/// </remarks>
	[Sharpen.Sharpened]
	public class AlteredCharSequence : java.lang.CharSequence, android.text.GetChars
	{
		// XXX should this really be in the public API at all?
		/// <summary>
		/// Create an AlteredCharSequence whose text (and possibly spans)
		/// are mirrored from <code>source</code>, except that the range of
		/// offsets <code>substart</code> inclusive to <code>subend</code> exclusive
		/// are mirrored instead from <code>sub</code>, beginning at offset 0.
		/// </summary>
		/// <remarks>
		/// Create an AlteredCharSequence whose text (and possibly spans)
		/// are mirrored from <code>source</code>, except that the range of
		/// offsets <code>substart</code> inclusive to <code>subend</code> exclusive
		/// are mirrored instead from <code>sub</code>, beginning at offset 0.
		/// </remarks>
		public static android.text.AlteredCharSequence make(java.lang.CharSequence source
			, char[] sub, int substart, int subend)
		{
			if (source is android.text.Spanned)
			{
				return new android.text.AlteredCharSequence.AlteredSpanned(source, sub, substart, 
					subend);
			}
			else
			{
				return new android.text.AlteredCharSequence(source, sub, substart, subend);
			}
		}

		private AlteredCharSequence(java.lang.CharSequence source, char[] sub, int substart
			, int subend)
		{
			mSource = source;
			mChars = sub;
			mStart = substart;
			mEnd = subend;
		}

		internal virtual void update(char[] sub, int substart, int subend)
		{
			mChars = sub;
			mStart = substart;
			mEnd = subend;
		}

		private class AlteredSpanned : android.text.AlteredCharSequence, android.text.Spanned
		{
			internal AlteredSpanned(java.lang.CharSequence source, char[] sub, int substart, 
				int subend) : base(source, sub, substart, subend)
			{
				mSpanned = (android.text.Spanned)source;
			}

			[Sharpen.Proxy]
			T[] android.text.Spanned.getSpans<T>(int start, int end)
			{
				System.Type kind = typeof(T);
				return getSpans<T>(start, end);
			}

			[Sharpen.ImplementsInterface(@"android.text.Spanned")]
			public virtual T[] getSpans<T>(int start, int end)
			{
				System.Type kind = typeof(T);
				return mSpanned.getSpans<T>(start, end);
			}

			[Sharpen.ImplementsInterface(@"android.text.Spanned")]
			public virtual int getSpanStart(object span)
			{
				return mSpanned.getSpanStart(span);
			}

			[Sharpen.ImplementsInterface(@"android.text.Spanned")]
			public virtual int getSpanEnd(object span)
			{
				return mSpanned.getSpanEnd(span);
			}

			[Sharpen.ImplementsInterface(@"android.text.Spanned")]
			public virtual int getSpanFlags(object span)
			{
				return mSpanned.getSpanFlags(span);
			}

			[Sharpen.ImplementsInterface(@"android.text.Spanned")]
			public virtual int nextSpanTransition(int start, int end, System.Type kind)
			{
				return mSpanned.nextSpanTransition(start, end, kind);
			}

			internal android.text.Spanned mSpanned;
		}

		public virtual char this[int off]
		{
			get
			{
				if (off >= mStart && off < mEnd)
				{
					return mChars[off - mStart];
				}
				else
				{
					return mSource[off];
				}
			}
		}

		public virtual int Length
		{
			get
			{
				return mSource.Length;
			}
		}

		[Sharpen.ImplementsInterface(@"java.lang.CharSequence")]
		public virtual java.lang.CharSequence SubSequence(int start, int end)
		{
			return android.text.AlteredCharSequence.make(mSource.SubSequence(start, end), mChars
				, mStart - start, mEnd - start);
		}

		[Sharpen.ImplementsInterface(@"android.text.GetChars")]
		public virtual void getChars(int start, int end, char[] dest, int off)
		{
			android.text.TextUtils.getChars(mSource, start, end, dest, off);
			start = System.Math.Max(mStart, start);
			end = System.Math.Min(mEnd, end);
			if (start > end)
			{
				System.Array.Copy(mChars, start - mStart, dest, off, end - start);
			}
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			int len = Length;
			char[] ret = new char[len];
			getChars(0, len, ret, 0);
			return ret.ToString();
		}

		private int mStart;

		private int mEnd;

		private char[] mChars;

		private java.lang.CharSequence mSource;
	}
}

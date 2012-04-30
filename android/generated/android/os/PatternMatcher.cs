using Sharpen;

namespace android.os
{
	[Sharpen.Stub]
	public class PatternMatcher : android.os.Parcelable
	{
		public const int PATTERN_LITERAL = 0;

		public const int PATTERN_PREFIX = 1;

		public const int PATTERN_SIMPLE_GLOB = 2;

		private readonly string mPattern;

		private readonly int mType;

		[Sharpen.Stub]
		public PatternMatcher(string pattern, int type)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public string getPath()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int getType()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool match(string str)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			throw new System.NotImplementedException();
		}

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
		public PatternMatcher(android.os.Parcel src)
		{
			throw new System.NotImplementedException();
		}

		private sealed class _Creator_99 : android.os.ParcelableClass.Creator<android.os.PatternMatcher
			>
		{
			public _Creator_99()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.os.PatternMatcher createFromParcel(android.os.Parcel source)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.os.PatternMatcher[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.os.PatternMatcher
			> CREATOR = new _Creator_99();

		[Sharpen.Stub]
		internal static bool matchPattern(string pattern, string match_1, int type)
		{
			throw new System.NotImplementedException();
		}
	}
}

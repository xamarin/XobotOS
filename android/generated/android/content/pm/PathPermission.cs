using Sharpen;

namespace android.content.pm
{
	[Sharpen.Stub]
	public class PathPermission : android.os.PatternMatcher
	{
		private readonly string mReadPermission;

		private readonly string mWritePermission;

		[Sharpen.Stub]
		public PathPermission(string pattern, int type, string readPermission, string writePermission
			) : base(pattern, type)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string getReadPermission()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string getWritePermission()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.os.PatternMatcher")]
		public override void writeToParcel(android.os.Parcel dest, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public PathPermission(android.os.Parcel src) : base(src)
		{
			throw new System.NotImplementedException();
		}

		private sealed class _Creator_59 : android.os.ParcelableClass.Creator<android.content.pm.PathPermission
			>
		{
			public _Creator_59()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.pm.PathPermission createFromParcel(android.os.Parcel source
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.pm.PathPermission[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.content.pm.PathPermission
			> CREATOR = new _Creator_59();
	}
}

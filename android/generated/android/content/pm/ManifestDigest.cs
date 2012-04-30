using Sharpen;

namespace android.content.pm
{
	[Sharpen.Stub]
	public class ManifestDigest : android.os.Parcelable
	{
		private readonly byte[] mDigest;

		private static readonly string[] DIGEST_TYPES = new string[] { "SHA1-Digest", "SHA-Digest"
			, "MD5-Digest" };

		internal const string TO_STRING_PREFIX = "ManifestDigest {mDigest=";

		[Sharpen.Stub]
		internal ManifestDigest(byte[] digest)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private ManifestDigest(android.os.Parcel source)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal static android.content.pm.ManifestDigest fromAttributes(java.util.jar.Attributes
			 attributes)
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
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override bool Equals(object o)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override int GetHashCode()
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
		public virtual void writeToParcel(android.os.Parcel dest, int flags)
		{
			throw new System.NotImplementedException();
		}

		private sealed class _Creator_104 : android.os.ParcelableClass.Creator<android.content.pm.ManifestDigest
			>
		{
			public _Creator_104()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.pm.ManifestDigest createFromParcel(android.os.Parcel source
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.pm.ManifestDigest[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.content.pm.ManifestDigest
			> CREATOR = new _Creator_104();
	}
}

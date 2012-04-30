using Sharpen;

namespace android.content.pm
{
	[Sharpen.Stub]
	public class VerifierInfo : android.os.Parcelable
	{
		public readonly string packageName;

		public readonly java.security.PublicKey publicKey;

		[Sharpen.Stub]
		public VerifierInfo(string packageName, java.security.PublicKey publicKey)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private VerifierInfo(android.os.Parcel source)
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

		private sealed class _Creator_74 : android.os.ParcelableClass.Creator<android.content.pm.VerifierInfo
			>
		{
			public _Creator_74()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.pm.VerifierInfo createFromParcel(android.os.Parcel source)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.pm.VerifierInfo[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.content.pm.VerifierInfo
			> CREATOR = new _Creator_74();
	}
}

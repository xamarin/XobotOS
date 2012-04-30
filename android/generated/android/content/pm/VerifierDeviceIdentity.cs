using Sharpen;

namespace android.content.pm
{
	[Sharpen.Stub]
	public class VerifierDeviceIdentity : android.os.Parcelable
	{
		internal const int LONG_SIZE = 13;

		internal const int GROUP_SIZE = 4;

		private readonly long mIdentity;

		private readonly string mIdentityString;

		[Sharpen.Stub]
		public VerifierDeviceIdentity(long identity)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private VerifierDeviceIdentity(android.os.Parcel source)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.content.pm.VerifierDeviceIdentity generate()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal static android.content.pm.VerifierDeviceIdentity generate(System.Random 
			rng)
		{
			throw new System.NotImplementedException();
		}

		private static readonly char[] ENCODE = new char[] { 'A', 'B', 'C', 'D', 'E', 'F'
			, 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V'
			, 'W', 'X', 'Y', 'Z', '2', '3', '4', '5', '6', '7' };

		internal const char SEPARATOR = '-';

		[Sharpen.Stub]
		private static string encodeBase32(long input)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static long decodeBase32(byte[] input)
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
		public override bool Equals(object other)
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
		public static android.content.pm.VerifierDeviceIdentity parse(string deviceIdentity
			)
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

		private sealed class _Creator_231 : android.os.ParcelableClass.Creator<android.content.pm.VerifierDeviceIdentity
			>
		{
			public _Creator_231()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.pm.VerifierDeviceIdentity createFromParcel(android.os.Parcel
				 source)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.pm.VerifierDeviceIdentity[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.content.pm.VerifierDeviceIdentity
			> CREATOR = new _Creator_231();
	}
}

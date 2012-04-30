using Sharpen;

namespace android.content.pm
{
	[Sharpen.Stub]
	public class Signature : android.os.Parcelable
	{
		private readonly byte[] mSignature;

		private int mHashCode;

		private bool mHaveHashCode;

		private java.lang.@ref.SoftReference<string> mStringRef;

		[Sharpen.Stub]
		public Signature(byte[] signature)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static int parseHexDigit(int nibble)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public Signature(string text)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual char[] toChars()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual char[] toChars(char[] existingArray, int[] outLen)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string toCharsString()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual byte[] toByteArray()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual java.security.PublicKey getPublicKey()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override bool Equals(object obj)
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
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual int describeContents()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual void writeToParcel(android.os.Parcel dest, int parcelableFlags)
		{
			throw new System.NotImplementedException();
		}

		private sealed class _Creator_188 : android.os.ParcelableClass.Creator<android.content.pm.Signature
			>
		{
			public _Creator_188()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.pm.Signature createFromParcel(android.os.Parcel source)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.pm.Signature[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.content.pm.Signature
			> CREATOR = new _Creator_188();

		[Sharpen.Stub]
		private Signature(android.os.Parcel source)
		{
			throw new System.NotImplementedException();
		}
	}
}

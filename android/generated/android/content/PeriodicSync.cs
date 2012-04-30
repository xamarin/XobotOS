using Sharpen;

namespace android.content
{
	[Sharpen.Stub]
	public class PeriodicSync : android.os.Parcelable
	{
		public readonly android.accounts.Account account;

		public readonly string authority;

		public readonly android.os.Bundle extras;

		public readonly long period;

		[Sharpen.Stub]
		public PeriodicSync(android.accounts.Account account, string authority, android.os.Bundle
			 extras, long period)
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

		private sealed class _Creator_57 : android.os.ParcelableClass.Creator<android.content.PeriodicSync
			>
		{
			public _Creator_57()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.PeriodicSync createFromParcel(android.os.Parcel source)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.PeriodicSync[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.content.PeriodicSync
			> CREATOR = new _Creator_57();

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override bool Equals(object o)
		{
			throw new System.NotImplementedException();
		}
	}
}

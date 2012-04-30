using Sharpen;

namespace android.accounts
{
	/// <summary>
	/// Value type that represents an Account in the
	/// <see cref="AccountManager">AccountManager</see>
	/// . This object is
	/// <see cref="android.os.Parcelable">android.os.Parcelable</see>
	/// and also overrides
	/// <see cref="Equals(object)">Equals(object)</see>
	/// and
	/// <see cref="GetHashCode()">GetHashCode()</see>
	/// , making it
	/// suitable for use as the key of a
	/// <see cref="java.util.Map{K, V}">java.util.Map&lt;K, V&gt;</see>
	/// </summary>
	[Sharpen.Sharpened]
	public class Account : android.os.Parcelable
	{
		public readonly string name;

		public readonly string type;

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override bool Equals(object o)
		{
			if (o == this)
			{
				return true;
			}
			if (!(o is android.accounts.Account))
			{
				return false;
			}
			android.accounts.Account other = (android.accounts.Account)o;
			return name.Equals(other.name) && type.Equals(other.type);
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override int GetHashCode()
		{
			int result = 17;
			result = 31 * result + name.GetHashCode();
			result = 31 * result + type.GetHashCode();
			return result;
		}

		public Account(string name, string type)
		{
			if (android.text.TextUtils.isEmpty(java.lang.CharSequenceProxy.Wrap(name)))
			{
				throw new System.ArgumentException("the name must not be empty: " + name);
			}
			if (android.text.TextUtils.isEmpty(java.lang.CharSequenceProxy.Wrap(type)))
			{
				throw new System.ArgumentException("the type must not be empty: " + type);
			}
			this.name = name;
			this.type = type;
		}

		public Account(android.os.Parcel @in)
		{
			this.name = @in.readString();
			this.type = @in.readString();
		}

		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual int describeContents()
		{
			return 0;
		}

		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual void writeToParcel(android.os.Parcel dest, int flags)
		{
			dest.writeString(name);
			dest.writeString(type);
		}

		private sealed class _Creator_71 : android.os.ParcelableClass.Creator<android.accounts.Account
			>
		{
			public _Creator_71()
			{
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.accounts.Account createFromParcel(android.os.Parcel source)
			{
				return new android.accounts.Account(source);
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.accounts.Account[] newArray(int size)
			{
				return new android.accounts.Account[size];
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.accounts.Account
			> CREATOR = new _Creator_71();

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			return "Account {name=" + name + ", type=" + type + "}";
		}
	}
}

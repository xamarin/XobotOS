using Sharpen;

namespace android.content.pm
{
	/// <summary>Per-user information.</summary>
	/// <remarks>Per-user information.</remarks>
	/// <hide></hide>
	[Sharpen.Sharpened]
	public class UserInfo : android.os.Parcelable
	{
		/// <summary>Primary user.</summary>
		/// <remarks>
		/// Primary user. Only one user can have this flag set. Meaning of this
		/// flag TBD.
		/// </remarks>
		public const int FLAG_PRIMARY = unchecked((int)(0x00000001));

		/// <summary>User with administrative privileges.</summary>
		/// <remarks>
		/// User with administrative privileges. Such a user can create and
		/// delete users.
		/// </remarks>
		public const int FLAG_ADMIN = unchecked((int)(0x00000002));

		/// <summary>Indicates a guest user that may be transient.</summary>
		/// <remarks>Indicates a guest user that may be transient.</remarks>
		public const int FLAG_GUEST = unchecked((int)(0x00000004));

		public int id;

		public string name;

		public int flags;

		public UserInfo(int id, string name, int flags)
		{
			this.id = id;
			this.name = name;
			this.flags = flags;
		}

		public virtual bool isPrimary()
		{
			return (flags & FLAG_PRIMARY) == FLAG_PRIMARY;
		}

		public virtual bool isAdmin()
		{
			return (flags & FLAG_ADMIN) == FLAG_ADMIN;
		}

		public virtual bool isGuest()
		{
			return (flags & FLAG_GUEST) == FLAG_GUEST;
		}

		public UserInfo()
		{
		}

		public UserInfo(android.content.pm.UserInfo orig)
		{
			name = orig.name;
			id = orig.id;
			flags = orig.flags;
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			return "UserInfo{" + id + ":" + name + ":" + Sharpen.Util.IntToHexString(flags) +
				 "}";
		}

		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual int describeContents()
		{
			return 0;
		}

		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual void writeToParcel(android.os.Parcel dest, int parcelableFlags)
		{
			dest.writeInt(id);
			dest.writeString(name);
			dest.writeInt(flags);
		}

		private sealed class _Creator_91 : android.os.ParcelableClass.Creator<android.content.pm.UserInfo
			>
		{
			public _Creator_91()
			{
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.pm.UserInfo createFromParcel(android.os.Parcel source)
			{
				return new android.content.pm.UserInfo(source);
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.pm.UserInfo[] newArray(int size)
			{
				return new android.content.pm.UserInfo[size];
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.content.pm.UserInfo
			> CREATOR = new _Creator_91();

		private UserInfo(android.os.Parcel source)
		{
			id = source.readInt();
			name = source.readString();
			flags = source.readInt();
		}
	}
}

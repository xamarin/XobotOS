using Sharpen;

namespace android.statusbar.@internal
{
	[Sharpen.Sharpened]
	public class StatusBarIcon : android.os.Parcelable
	{
		public string iconPackage;

		public int iconId;

		public int iconLevel;

		public bool visible = true;

		public int number;

		public java.lang.CharSequence contentDescription;

		public StatusBarIcon(string iconPackage, int iconId, int iconLevel, int number, java.lang.CharSequence
			 contentDescription)
		{
			this.iconPackage = iconPackage;
			this.iconId = iconId;
			this.iconLevel = iconLevel;
			this.number = number;
			this.contentDescription = contentDescription;
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			return "StatusBarIcon(pkg=" + this.iconPackage + " id=0x" + Sharpen.Util.IntToHexString
				(this.iconId) + " level=" + this.iconLevel + " visible=" + visible + " num=" + this
				.number + " )";
		}

		public virtual android.statusbar.@internal.StatusBarIcon clone()
		{
			android.statusbar.@internal.StatusBarIcon that = new android.statusbar.@internal.StatusBarIcon
				(this.iconPackage, this.iconId, this.iconLevel, this.number, this.contentDescription
				);
			that.visible = this.visible;
			return that;
		}

		/// <summary>Unflatten the StatusBarIcon from a parcel.</summary>
		/// <remarks>Unflatten the StatusBarIcon from a parcel.</remarks>
		public StatusBarIcon(android.os.Parcel @in)
		{
			readFromParcel(@in);
		}

		public virtual void readFromParcel(android.os.Parcel @in)
		{
			this.iconPackage = @in.readString();
			this.iconId = @in.readInt();
			this.iconLevel = @in.readInt();
			this.visible = @in.readInt() != 0;
			this.number = @in.readInt();
			this.contentDescription = @in.readCharSequence();
		}

		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual void writeToParcel(android.os.Parcel @out, int flags)
		{
			@out.writeString(this.iconPackage);
			@out.writeInt(this.iconId);
			@out.writeInt(this.iconLevel);
			@out.writeInt(this.visible ? 1 : 0);
			@out.writeInt(this.number);
			@out.writeCharSequence(this.contentDescription);
		}

		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual int describeContents()
		{
			return 0;
		}

		private sealed class _Creator_88 : android.os.ParcelableClass.Creator<android.statusbar.@internal.StatusBarIcon
			>
		{
			public _Creator_88()
			{
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.statusbar.@internal.StatusBarIcon createFromParcel(android.os.Parcel
				 parcel)
			{
				return new android.statusbar.@internal.StatusBarIcon(parcel);
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.statusbar.@internal.StatusBarIcon[] newArray(int size)
			{
				return new android.statusbar.@internal.StatusBarIcon[size];
			}
		}

		/// <summary>Parcelable.Creator that instantiates StatusBarIcon objects</summary>
		public static readonly android.os.ParcelableClass.Creator<android.statusbar.@internal.StatusBarIcon
			> CREATOR = new _Creator_88();
	}
}

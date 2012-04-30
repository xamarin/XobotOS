using Sharpen;

namespace android.content.res
{
	/// <summary>
	/// Basic information about a Opaque Binary Blob (OBB) that reflects the info
	/// from the footer on the OBB file.
	/// </summary>
	/// <remarks>
	/// Basic information about a Opaque Binary Blob (OBB) that reflects the info
	/// from the footer on the OBB file. This information may be manipulated by a
	/// developer with the <code>obbtool</code> program in the Android SDK.
	/// </remarks>
	[Sharpen.Sharpened]
	public class ObbInfo : android.os.Parcelable
	{
		/// <summary>Flag noting that this OBB is an overlay patch for a base OBB.</summary>
		/// <remarks>Flag noting that this OBB is an overlay patch for a base OBB.</remarks>
		public const int OBB_OVERLAY = 1 << 0;

		/// <summary>The canonical filename of the OBB.</summary>
		/// <remarks>The canonical filename of the OBB.</remarks>
		public string filename;

		/// <summary>The name of the package to which the OBB file belongs.</summary>
		/// <remarks>The name of the package to which the OBB file belongs.</remarks>
		public string packageName;

		/// <summary>The version of the package to which the OBB file belongs.</summary>
		/// <remarks>The version of the package to which the OBB file belongs.</remarks>
		public int version;

		/// <summary>The flags relating to the OBB.</summary>
		/// <remarks>The flags relating to the OBB.</remarks>
		public int flags;

		/// <summary>The salt for the encryption algorithm.</summary>
		/// <remarks>The salt for the encryption algorithm.</remarks>
		/// <hide></hide>
		public byte[] salt;

		internal ObbInfo()
		{
		}

		// Only allow things in this package to instantiate.
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			java.lang.StringBuilder sb = new java.lang.StringBuilder();
			sb.append("ObbInfo{");
			sb.append(Sharpen.Util.IntToHexString(Sharpen.Util.IdentityHashCode(this)));
			sb.append(" packageName=");
			sb.append(packageName);
			sb.append(",version=");
			sb.append(version);
			sb.append(",flags=");
			sb.append(flags);
			sb.append('}');
			return sb.ToString();
		}

		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual int describeContents()
		{
			return 0;
		}

		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual void writeToParcel(android.os.Parcel dest, int parcelableFlags)
		{
			dest.writeString(filename);
			dest.writeString(packageName);
			dest.writeInt(version);
			dest.writeInt(flags);
			dest.writeByteArray(salt);
		}

		private sealed class _Creator_89 : android.os.ParcelableClass.Creator<android.content.res.ObbInfo
			>
		{
			public _Creator_89()
			{
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.res.ObbInfo createFromParcel(android.os.Parcel source)
			{
				return new android.content.res.ObbInfo(source);
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.res.ObbInfo[] newArray(int size)
			{
				return new android.content.res.ObbInfo[size];
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.content.res.ObbInfo
			> CREATOR = new _Creator_89();

		private ObbInfo(android.os.Parcel source)
		{
			filename = source.readString();
			packageName = source.readString();
			version = source.readInt();
			flags = source.readInt();
			salt = source.createByteArray();
		}
	}
}

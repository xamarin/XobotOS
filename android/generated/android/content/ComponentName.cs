using Sharpen;

namespace android.content
{
	/// <summary>
	/// Identifier for a specific application component
	/// (
	/// <see cref="android.app.Activity">android.app.Activity</see>
	/// ,
	/// <see cref="android.app.Service">android.app.Service</see>
	/// ,
	/// <see cref="BroadcastReceiver">BroadcastReceiver</see>
	/// , or
	/// <see cref="ContentProvider">ContentProvider</see>
	/// ) that is available.  Two
	/// pieces of information, encapsulated here, are required to identify
	/// a component: the package (a String) it exists in, and the class (a String)
	/// name inside of that package.
	/// </summary>
	[Sharpen.Sharpened]
	public sealed class ComponentName : android.os.Parcelable, System.ICloneable, java.lang.Comparable
		<android.content.ComponentName>
	{
		private readonly string mPackage;

		private readonly string mClass;

		/// <summary>Create a new component identifier.</summary>
		/// <remarks>Create a new component identifier.</remarks>
		/// <param name="pkg">
		/// The name of the package that the component exists in.  Can
		/// not be null.
		/// </param>
		/// <param name="cls">
		/// The name of the class inside of <var>pkg</var> that
		/// implements the component.  Can not be null.
		/// </param>
		public ComponentName(string pkg, string cls)
		{
			if (pkg == null)
			{
				throw new System.ArgumentNullException("package name is null");
			}
			if (cls == null)
			{
				throw new System.ArgumentNullException("class name is null");
			}
			mPackage = pkg;
			mClass = cls;
		}

		/// <summary>Create a new component identifier from a Context and class name.</summary>
		/// <remarks>Create a new component identifier from a Context and class name.</remarks>
		/// <param name="pkg">
		/// A Context for the package implementing the component,
		/// from which the actual package name will be retrieved.
		/// </param>
		/// <param name="cls">
		/// The name of the class inside of <var>pkg</var> that
		/// implements the component.
		/// </param>
		public ComponentName(android.content.Context pkg, string cls)
		{
			if (cls == null)
			{
				throw new System.ArgumentNullException("class name is null");
			}
			mPackage = pkg.getPackageName();
			mClass = cls;
		}

		/// <summary>Create a new component identifier from a Context and Class object.</summary>
		/// <remarks>Create a new component identifier from a Context and Class object.</remarks>
		/// <param name="pkg">
		/// A Context for the package implementing the component, from
		/// which the actual package name will be retrieved.
		/// </param>
		/// <param name="cls">
		/// The Class object of the desired component, from which the
		/// actual class name will be retrieved.
		/// </param>
		public ComponentName(android.content.Context pkg, System.Type cls)
		{
			mPackage = pkg.getPackageName();
			mClass = cls.FullName;
		}

		public android.content.ComponentName clone()
		{
			return new android.content.ComponentName(mPackage, mClass);
		}

		/// <summary>Return the package name of this component.</summary>
		/// <remarks>Return the package name of this component.</remarks>
		public string getPackageName()
		{
			return mPackage;
		}

		/// <summary>Return the class name of this component.</summary>
		/// <remarks>Return the class name of this component.</remarks>
		public string getClassName()
		{
			return mClass;
		}

		/// <summary>
		/// Return the class name, either fully qualified or in a shortened form
		/// (with a leading '.') if it is a suffix of the package.
		/// </summary>
		/// <remarks>
		/// Return the class name, either fully qualified or in a shortened form
		/// (with a leading '.') if it is a suffix of the package.
		/// </remarks>
		public string getShortClassName()
		{
			if (mClass.StartsWith(mPackage))
			{
				int PN = mPackage.Length;
				int CN = mClass.Length;
				if (CN > PN && mClass[PN] == '.')
				{
					return Sharpen.StringHelper.Substring(mClass, PN, CN);
				}
			}
			return mClass;
		}

		/// <summary>
		/// Return a String that unambiguously describes both the package and
		/// class names contained in the ComponentName.
		/// </summary>
		/// <remarks>
		/// Return a String that unambiguously describes both the package and
		/// class names contained in the ComponentName.  You can later recover
		/// the ComponentName from this string through
		/// <see cref="unflattenFromString(string)">unflattenFromString(string)</see>
		/// .
		/// </remarks>
		/// <returns>
		/// Returns a new String holding the package and class names.  This
		/// is represented as the package name, concatenated with a '/' and then the
		/// class name.
		/// </returns>
		/// <seealso cref="unflattenFromString(string)">unflattenFromString(string)</seealso>
		public string flattenToString()
		{
			return mPackage + "/" + mClass;
		}

		/// <summary>
		/// The same as
		/// <see cref="flattenToString()">flattenToString()</see>
		/// , but abbreviates the class
		/// name if it is a suffix of the package.  The result can still be used
		/// with
		/// <see cref="unflattenFromString(string)">unflattenFromString(string)</see>
		/// .
		/// </summary>
		/// <returns>
		/// Returns a new String holding the package and class names.  This
		/// is represented as the package name, concatenated with a '/' and then the
		/// class name.
		/// </returns>
		/// <seealso cref="unflattenFromString(string)">unflattenFromString(string)</seealso>
		public string flattenToShortString()
		{
			return mPackage + "/" + getShortClassName();
		}

		/// <summary>
		/// Recover a ComponentName from a String that was previously created with
		/// <see cref="flattenToString()">flattenToString()</see>
		/// .  It splits the string at the first '/',
		/// taking the part before as the package name and the part after as the
		/// class name.  As a special convenience (to use, for example, when
		/// parsing component names on the command line), if the '/' is immediately
		/// followed by a '.' then the final class name will be the concatenation
		/// of the package name with the string following the '/'.  Thus
		/// "com.foo/.Blah" becomes package="com.foo" class="com.foo.Blah".
		/// </summary>
		/// <param name="str">The String that was returned by flattenToString().</param>
		/// <returns>
		/// Returns a new ComponentName containing the package and class
		/// names that were encoded in <var>str</var>
		/// </returns>
		/// <seealso cref="flattenToString()">flattenToString()</seealso>
		public static android.content.ComponentName unflattenFromString(string str)
		{
			int sep = str.IndexOf('/');
			if (sep < 0 || (sep + 1) >= str.Length)
			{
				return null;
			}
			string pkg = Sharpen.StringHelper.Substring(str, 0, sep);
			string cls = Sharpen.StringHelper.Substring(str, sep + 1);
			if (cls.Length > 0 && cls[0] == '.')
			{
				cls = pkg + cls;
			}
			return new android.content.ComponentName(pkg, cls);
		}

		/// <summary>
		/// Return string representation of this class without the class's name
		/// as a prefix.
		/// </summary>
		/// <remarks>
		/// Return string representation of this class without the class's name
		/// as a prefix.
		/// </remarks>
		public string toShortString()
		{
			return "{" + mPackage + "/" + mClass + "}";
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			return "ComponentInfo{" + mPackage + "/" + mClass + "}";
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override bool Equals(object obj)
		{
			try
			{
				if (obj != null)
				{
					android.content.ComponentName other = (android.content.ComponentName)obj;
					// Note: no null checks, because mPackage and mClass can
					// never be null.
					return mPackage.Equals(other.mPackage) && mClass.Equals(other.mClass);
				}
			}
			catch (System.InvalidCastException)
			{
			}
			return false;
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override int GetHashCode()
		{
			return mPackage.GetHashCode() + mClass.GetHashCode();
		}

		[Sharpen.ImplementsInterface(@"java.lang.Comparable")]
		public int compareTo(android.content.ComponentName that)
		{
			int v;
			v = string.CompareOrdinal(this.mPackage, that.mPackage);
			if (v != 0)
			{
				return v;
			}
			return string.CompareOrdinal(this.mClass, that.mClass);
		}

		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public int describeContents()
		{
			return 0;
		}

		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public void writeToParcel(android.os.Parcel @out, int flags)
		{
			@out.writeString(mPackage);
			@out.writeString(mClass);
		}

		/// <summary>Write a ComponentName to a Parcel, handling null pointers.</summary>
		/// <remarks>
		/// Write a ComponentName to a Parcel, handling null pointers.  Must be
		/// read with
		/// <see cref="readFromParcel(android.os.Parcel)">readFromParcel(android.os.Parcel)</see>
		/// .
		/// </remarks>
		/// <param name="c">The ComponentName to be written.</param>
		/// <param name="out">The Parcel in which the ComponentName will be placed.</param>
		/// <seealso cref="readFromParcel(android.os.Parcel)">readFromParcel(android.os.Parcel)
		/// 	</seealso>
		public static void writeToParcel(android.content.ComponentName c, android.os.Parcel
			 @out)
		{
			if (c != null)
			{
				c.writeToParcel(@out, 0);
			}
			else
			{
				@out.writeString(null);
			}
		}

		/// <summary>
		/// Read a ComponentName from a Parcel that was previously written
		/// with
		/// <see cref="writeToParcel(ComponentName, android.os.Parcel)">writeToParcel(ComponentName, android.os.Parcel)
		/// 	</see>
		/// , returning either
		/// a null or new object as appropriate.
		/// </summary>
		/// <param name="in">The Parcel from which to read the ComponentName</param>
		/// <returns>
		/// Returns a new ComponentName matching the previously written
		/// object, or null if a null had been written.
		/// </returns>
		/// <seealso cref="writeToParcel(ComponentName, android.os.Parcel)">writeToParcel(ComponentName, android.os.Parcel)
		/// 	</seealso>
		public static android.content.ComponentName readFromParcel(android.os.Parcel @in)
		{
			string pkg = @in.readString();
			return pkg != null ? new android.content.ComponentName(pkg, @in) : null;
		}

		private sealed class _Creator_257 : android.os.ParcelableClass.Creator<android.content.ComponentName
			>
		{
			public _Creator_257()
			{
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.ComponentName createFromParcel(android.os.Parcel @in)
			{
				return new android.content.ComponentName(@in);
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.ComponentName[] newArray(int size)
			{
				return new android.content.ComponentName[size];
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.content.ComponentName
			> CREATOR = new _Creator_257();

		/// <summary>
		/// Instantiate a new ComponentName from the data in a Parcel that was
		/// previously written with
		/// <see cref="writeToParcel(android.os.Parcel, int)">writeToParcel(android.os.Parcel, int)
		/// 	</see>
		/// .  Note that you
		/// must not use this with data written by
		/// <see cref="writeToParcel(ComponentName, android.os.Parcel)">writeToParcel(ComponentName, android.os.Parcel)
		/// 	</see>
		/// since it is not possible
		/// to handle a null ComponentObject here.
		/// </summary>
		/// <param name="in">
		/// The Parcel containing the previously written ComponentName,
		/// positioned at the location in the buffer where it was written.
		/// </param>
		public ComponentName(android.os.Parcel @in)
		{
			mPackage = @in.readString();
			if (mPackage == null)
			{
				throw new System.ArgumentNullException("package name is null");
			}
			mClass = @in.readString();
			if (mClass == null)
			{
				throw new System.ArgumentNullException("class name is null");
			}
		}

		private ComponentName(string pkg, android.os.Parcel @in)
		{
			mPackage = pkg;
			mClass = @in.readString();
		}

		object System.ICloneable.Clone()
		{
			return MemberwiseClone();
		}
	}
}

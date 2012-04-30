using Sharpen;

namespace android.view.inputmethod
{
	[Sharpen.Stub]
	public sealed class InputMethodInfo : android.os.Parcelable
	{
		internal const string TAG = "InputMethodInfo";

		internal readonly android.content.pm.ResolveInfo mService;

		internal readonly string mId;

		internal readonly string mSettingsActivityName;

		internal readonly int mIsDefaultResId;

		private readonly java.util.ArrayList<android.view.inputmethod.InputMethodSubtype>
			 mSubtypes = new java.util.ArrayList<android.view.inputmethod.InputMethodSubtype
			>();

		private bool mIsAuxIme;

		[Sharpen.Stub]
		public InputMethodInfo(android.content.Context context, android.content.pm.ResolveInfo
			 service) : this(context, service, null)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public InputMethodInfo(android.content.Context context, android.content.pm.ResolveInfo
			 service, java.util.Map<string, java.util.List<android.view.inputmethod.InputMethodSubtype
			>> additionalSubtypesMap)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal InputMethodInfo(android.os.Parcel source)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public InputMethodInfo(string packageName, string className, java.lang.CharSequence
			 label, string settingsActivity)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public string getId()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public string getPackageName()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public string getServiceName()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.content.pm.ServiceInfo getServiceInfo()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.content.ComponentName getComponent()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public java.lang.CharSequence loadLabel(android.content.pm.PackageManager pm)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.graphics.drawable.Drawable loadIcon(android.content.pm.PackageManager
			 pm)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public string getSettingsActivity()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int getSubtypeCount()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.view.inputmethod.InputMethodSubtype getSubtypeAt(int index)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int getIsDefaultResourceId()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void dump(android.util.Printer pw, string prefix)
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
		public bool isAuxiliaryIme()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public void writeToParcel(android.os.Parcel dest, int flags)
		{
			throw new System.NotImplementedException();
		}

		private sealed class _Creator_402 : android.os.ParcelableClass.Creator<android.view.inputmethod.InputMethodInfo
			>
		{
			public _Creator_402()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.view.inputmethod.InputMethodInfo createFromParcel(android.os.Parcel
				 source)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.view.inputmethod.InputMethodInfo[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.view.inputmethod.InputMethodInfo
			> CREATOR = new _Creator_402();

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public int describeContents()
		{
			throw new System.NotImplementedException();
		}
	}
}

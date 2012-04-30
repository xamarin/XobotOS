using Sharpen;

namespace android.view.textservice
{
	[Sharpen.Stub]
	public sealed class SpellCheckerInfo : android.os.Parcelable
	{
		private static readonly string TAG = typeof(android.view.textservice.SpellCheckerInfo
			).Name;

		private readonly android.content.pm.ResolveInfo mService;

		private readonly string mId;

		private readonly int mLabel;

		private readonly string mSettingsActivityName;

		private readonly java.util.ArrayList<android.view.textservice.SpellCheckerSubtype
			> mSubtypes = new java.util.ArrayList<android.view.textservice.SpellCheckerSubtype
			>();

		[Sharpen.Stub]
		public SpellCheckerInfo(android.content.Context context, android.content.pm.ResolveInfo
			 service)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public SpellCheckerInfo(android.os.Parcel source)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public string getId()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.content.ComponentName getComponent()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public string getPackageName()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public void writeToParcel(android.os.Parcel dest, int flags)
		{
			throw new System.NotImplementedException();
		}

		private sealed class _Creator_191 : android.os.ParcelableClass.Creator<android.view.textservice.SpellCheckerInfo
			>
		{
			public _Creator_191()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.view.textservice.SpellCheckerInfo createFromParcel(android.os.Parcel
				 source)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.view.textservice.SpellCheckerInfo[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.view.textservice.SpellCheckerInfo
			> CREATOR = new _Creator_191();

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
		public android.content.pm.ServiceInfo getServiceInfo()
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
		public android.view.textservice.SpellCheckerSubtype getSubtypeAt(int index)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public int describeContents()
		{
			throw new System.NotImplementedException();
		}
	}
}

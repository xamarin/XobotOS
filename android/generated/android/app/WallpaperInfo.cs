using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	public sealed class WallpaperInfo : android.os.Parcelable
	{
		internal const string TAG = "WallpaperInfo";

		internal readonly android.content.pm.ResolveInfo mService;

		internal readonly string mSettingsActivityName;

		internal readonly int mThumbnailResource;

		internal readonly int mAuthorResource;

		internal readonly int mDescriptionResource;

		[Sharpen.Stub]
		public WallpaperInfo(android.content.Context context, android.content.pm.ResolveInfo
			 service)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal WallpaperInfo(android.os.Parcel source)
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
		public android.graphics.drawable.Drawable loadThumbnail(android.content.pm.PackageManager
			 pm)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public java.lang.CharSequence loadAuthor(android.content.pm.PackageManager pm)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public java.lang.CharSequence loadDescription(android.content.pm.PackageManager pm
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public string getSettingsActivity()
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
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public void writeToParcel(android.os.Parcel dest, int flags)
		{
			throw new System.NotImplementedException();
		}

		private sealed class _Creator_296 : android.os.ParcelableClass.Creator<android.app.WallpaperInfo
			>
		{
			public _Creator_296()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.app.WallpaperInfo createFromParcel(android.os.Parcel source)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.app.WallpaperInfo[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.app.WallpaperInfo
			> CREATOR = new _Creator_296();

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public int describeContents()
		{
			throw new System.NotImplementedException();
		}
	}
}

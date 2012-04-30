using Sharpen;

namespace android.content.pm
{
	[Sharpen.Stub]
	public class ResolveInfo : android.os.Parcelable
	{
		public android.content.pm.ActivityInfo activityInfo;

		public android.content.pm.ServiceInfo serviceInfo;

		public android.content.IntentFilter filter;

		public int priority;

		public int preferredOrder;

		public int match;

		public int specificIndex = -1;

		public bool isDefault;

		public int labelRes;

		public java.lang.CharSequence nonLocalizedLabel;

		public int icon;

		public string resolvePackageName;

		public bool system;

		[Sharpen.Stub]
		public virtual java.lang.CharSequence loadLabel(android.content.pm.PackageManager
			 pm)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.graphics.drawable.Drawable loadIcon(android.content.pm.PackageManager
			 pm)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int getIconResource()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void dump(android.util.Printer pw, string prefix)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public ResolveInfo()
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

		private sealed class _Creator_273 : android.os.ParcelableClass.Creator<android.content.pm.ResolveInfo
			>
		{
			public _Creator_273()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.pm.ResolveInfo createFromParcel(android.os.Parcel source)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.pm.ResolveInfo[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.content.pm.ResolveInfo
			> CREATOR = new _Creator_273();

		[Sharpen.Stub]
		private ResolveInfo(android.os.Parcel source)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public class DisplayNameComparator : java.util.Comparator<android.content.pm.ResolveInfo
			>
		{
			[Sharpen.Stub]
			public DisplayNameComparator(android.content.pm.PackageManager pm)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"java.util.Comparator")]
			public virtual int compare(android.content.pm.ResolveInfo a, android.content.pm.ResolveInfo
				 b)
			{
				throw new System.NotImplementedException();
			}

			private readonly java.text.Collator sCollator = java.text.Collator.getInstance();

			private android.content.pm.PackageManager mPM;
		}
	}
}

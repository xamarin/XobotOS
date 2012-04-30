using Sharpen;

namespace android.app.admin
{
	[Sharpen.Stub]
	public sealed class DeviceAdminInfo : android.os.Parcelable
	{
		internal const string TAG = "DeviceAdminInfo";

		public const int USES_POLICY_LIMIT_PASSWORD = 0;

		public const int USES_POLICY_WATCH_LOGIN = 1;

		public const int USES_POLICY_RESET_PASSWORD = 2;

		public const int USES_POLICY_FORCE_LOCK = 3;

		public const int USES_POLICY_WIPE_DATA = 4;

		public const int USES_POLICY_SETS_GLOBAL_PROXY = 5;

		public const int USES_POLICY_EXPIRE_PASSWORD = 6;

		public const int USES_ENCRYPTED_STORAGE = 7;

		public const int USES_POLICY_DISABLE_CAMERA = 8;

		[Sharpen.Stub]
		public class PolicyInfo
		{
			public readonly int ident;

			public readonly string tag;

			public readonly int label;

			public readonly int description;

			[Sharpen.Stub]
			public PolicyInfo(int identIn, string tagIn, int labelIn, int descriptionIn)
			{
				throw new System.NotImplementedException();
			}
		}

		internal static java.util.ArrayList<android.app.admin.DeviceAdminInfo.PolicyInfo>
			 sPoliciesDisplayOrder = new java.util.ArrayList<android.app.admin.DeviceAdminInfo
			.PolicyInfo>();

		internal static java.util.HashMap<string, int> sKnownPolicies = new java.util.HashMap
			<string, int>();

		internal static android.util.SparseArray<android.app.admin.DeviceAdminInfo.PolicyInfo
			> sRevKnownPolicies = new android.util.SparseArray<android.app.admin.DeviceAdminInfo
			.PolicyInfo>();

		static DeviceAdminInfo()
		{
			throw new System.NotImplementedException();
		}

		internal readonly android.content.pm.ResolveInfo mReceiver;

		internal bool mVisible;

		internal int mUsesPolicies;

		[Sharpen.Stub]
		public DeviceAdminInfo(android.content.Context context, android.content.pm.ResolveInfo
			 receiver)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal DeviceAdminInfo(android.os.Parcel source)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public string getPackageName()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public string getReceiverName()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.content.pm.ActivityInfo getActivityInfo()
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
		public java.lang.CharSequence loadDescription(android.content.pm.PackageManager pm
			)
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
		public bool isVisible()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool usesPolicy(int policyIdent)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public string getTagForPolicy(int policyIdent)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public java.util.ArrayList<android.app.admin.DeviceAdminInfo.PolicyInfo> getUsedPolicies
			()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void writePoliciesToXml(org.xmlpull.v1.XmlSerializer @out)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void readPoliciesFromXml(org.xmlpull.v1.XmlPullParser parser)
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

		private sealed class _Creator_445 : android.os.ParcelableClass.Creator<android.app.admin.DeviceAdminInfo
			>
		{
			public _Creator_445()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.app.admin.DeviceAdminInfo createFromParcel(android.os.Parcel source
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.app.admin.DeviceAdminInfo[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.app.admin.DeviceAdminInfo
			> CREATOR = new _Creator_445();

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public int describeContents()
		{
			throw new System.NotImplementedException();
		}
	}
}

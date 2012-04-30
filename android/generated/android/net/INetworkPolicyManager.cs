using Sharpen;

namespace android.net
{
	[Sharpen.Stub]
	public interface INetworkPolicyManager : android.os.IInterface
	{
		[Sharpen.Stub]
		void setUidPolicy(int uid, int policy);

		[Sharpen.Stub]
		int getUidPolicy(int uid);

		[Sharpen.Stub]
		bool isUidForeground(int uid);

		[Sharpen.Stub]
		void registerListener(android.net.INetworkPolicyListener listener);

		[Sharpen.Stub]
		void unregisterListener(android.net.INetworkPolicyListener listener);

		[Sharpen.Stub]
		void setNetworkPolicies(android.net.NetworkPolicy[] policies);

		[Sharpen.Stub]
		android.net.NetworkPolicy[] getNetworkPolicies();

		[Sharpen.Stub]
		void snoozePolicy(android.net.NetworkTemplate template);

		[Sharpen.Stub]
		void setRestrictBackground(bool restrictBackground);

		[Sharpen.Stub]
		bool getRestrictBackground();

		[Sharpen.Stub]
		android.net.NetworkQuotaInfo getNetworkQuotaInfo(android.net.NetworkState state);
	}

	[Sharpen.Stub]
	public static class INetworkPolicyManagerClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.net.INetworkPolicyManager
		{
			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.net.INetworkPolicyManager asInterface(android.os.IBinder obj
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.IInterface")]
			public virtual android.os.IBinder asBinder()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.os.Binder")]
			protected internal override bool onTransact(int code, android.os.Parcel data, android.os.Parcel
				 reply, int flags)
			{
				throw new System.NotImplementedException();
			}

			public abstract android.net.NetworkPolicy[] getNetworkPolicies();

			public abstract android.net.NetworkQuotaInfo getNetworkQuotaInfo(android.net.NetworkState
				 arg1);

			public abstract bool getRestrictBackground();

			public abstract int getUidPolicy(int arg1);

			public abstract bool isUidForeground(int arg1);

			public abstract void registerListener(android.net.INetworkPolicyListener arg1);

			public abstract void setNetworkPolicies(android.net.NetworkPolicy[] arg1);

			public abstract void setRestrictBackground(bool arg1);

			public abstract void setUidPolicy(int arg1, int arg2);

			public abstract void snoozePolicy(android.net.NetworkTemplate arg1);

			public abstract void unregisterListener(android.net.INetworkPolicyListener arg1);
		}
	}
}

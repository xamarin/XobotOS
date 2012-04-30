using Sharpen;

namespace android.net
{
	[Sharpen.Stub]
	public class NetworkPolicyManager
	{
		[Sharpen.Stub]
		public NetworkPolicyManager(android.net.INetworkPolicyManager service)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.net.NetworkPolicyManager getSystemService(android.content.Context
			 context)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setNetworkPolicies(android.net.NetworkPolicy[] policies)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.net.NetworkPolicy[] getNetworkPolicies()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setUidPolicy(int uid, int policy)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getUidPolicy(int uid)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void registerListener(android.net.INetworkPolicyListener listener)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void unregisterListener(android.net.INetworkPolicyListener listener
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static long computeLastCycleBoundary(long currentTime, android.net.NetworkPolicy
			 policy)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static long computeNextCycleBoundary(long currentTime, android.net.NetworkPolicy
			 policy)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void snapToCycleDay(android.text.format.Time time, int cycleDay)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static bool isUidValidForPolicy(android.content.Context context, int uid)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void dumpPolicy(java.io.PrintWriter fout, int policy)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void dumpRules(java.io.PrintWriter fout, int rules)
		{
			throw new System.NotImplementedException();
		}
	}
}

using Sharpen;

namespace android.net
{
	[Sharpen.Stub]
	public class ConnectivityManager
	{
		[Sharpen.Stub]
		public static bool isNetworkTypeValid(int networkType)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static string getNetworkTypeName(int type)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static bool isNetworkTypeMobile(int networkType)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setNetworkPreference(int preference)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getNetworkPreference()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.net.NetworkInfo getActiveNetworkInfo()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.net.NetworkInfo getActiveNetworkInfoForUid(int uid)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.net.NetworkInfo getNetworkInfo(int networkType)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.net.NetworkInfo[] getAllNetworkInfo()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.net.LinkProperties getActiveLinkProperties()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.net.LinkProperties getLinkProperties(int networkType)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool setRadios(bool turnOn)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool setRadio(int networkType, bool turnOn)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int startUsingNetworkFeature(int networkType, string feature)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int stopUsingNetworkFeature(int networkType, string feature)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool requestRouteToHost(int networkType, int hostAddress)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool requestRouteToHostAddress(int networkType, java.net.InetAddress
			 hostAddress)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"As of android.os.Build.VERSION_CODES.ICE_CREAM_SANDWICH , availability of background data depends on several combined factors, and this method will always return true . Instead, when background data is unavailable,getActiveNetworkInfo() will now appear disconnected."
			)]
		public virtual bool getBackgroundDataSetting()
		{
			throw new System.NotImplementedException();
		}

		[System.Obsolete]
		[Sharpen.Stub]
		public virtual void setBackgroundDataSetting(bool allowBackgroundData)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.net.NetworkQuotaInfo getActiveNetworkQuotaInfo()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool getMobileDataEnabled()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setMobileDataEnabled(bool enabled)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public ConnectivityManager(android.net.IConnectivityManager service)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string[] getTetherableIfaces()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string[] getTetheredIfaces()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string[] getTetheringErroredIfaces()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int tether(string iface)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int untether(string iface)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isTetheringSupported()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string[] getTetherableUsbRegexs()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string[] getTetherableWifiRegexs()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string[] getTetherableBluetoothRegexs()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int setUsbTethering(bool enable)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getLastTetherError(string iface)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool requestNetworkTransitionWakelock(string forWhom)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void reportInetCondition(int networkType, int percentage)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setGlobalProxy(android.net.ProxyProperties p)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.net.ProxyProperties getGlobalProxy()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.net.ProxyProperties getProxy()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setDataDependency(int networkType, bool met)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isNetworkSupported(int networkType)
		{
			throw new System.NotImplementedException();
		}
	}
}

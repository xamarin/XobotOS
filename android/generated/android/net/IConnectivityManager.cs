using Sharpen;

namespace android.net
{
	[Sharpen.Stub]
	public interface IConnectivityManager : android.os.IInterface
	{
		[Sharpen.Stub]
		void setNetworkPreference(int pref);

		[Sharpen.Stub]
		int getNetworkPreference();

		[Sharpen.Stub]
		android.net.NetworkInfo getActiveNetworkInfo();

		[Sharpen.Stub]
		android.net.NetworkInfo getActiveNetworkInfoForUid(int uid);

		[Sharpen.Stub]
		android.net.NetworkInfo getNetworkInfo(int networkType);

		[Sharpen.Stub]
		android.net.NetworkInfo[] getAllNetworkInfo();

		[Sharpen.Stub]
		bool isNetworkSupported(int networkType);

		[Sharpen.Stub]
		android.net.LinkProperties getActiveLinkProperties();

		[Sharpen.Stub]
		android.net.LinkProperties getLinkProperties(int networkType);

		[Sharpen.Stub]
		android.net.NetworkState[] getAllNetworkState();

		[Sharpen.Stub]
		android.net.NetworkQuotaInfo getActiveNetworkQuotaInfo();

		[Sharpen.Stub]
		bool setRadios(bool onOff);

		[Sharpen.Stub]
		bool setRadio(int networkType, bool turnOn);

		[Sharpen.Stub]
		int startUsingNetworkFeature(int networkType, string feature, android.os.IBinder 
			binder);

		[Sharpen.Stub]
		int stopUsingNetworkFeature(int networkType, string feature);

		[Sharpen.Stub]
		bool requestRouteToHost(int networkType, int hostAddress);

		[Sharpen.Stub]
		bool requestRouteToHostAddress(int networkType, byte[] hostAddress);

		[Sharpen.Stub]
		bool getMobileDataEnabled();

		[Sharpen.Stub]
		void setMobileDataEnabled(bool enabled);

		[Sharpen.Stub]
		void setPolicyDataEnable(int networkType, bool enabled);

		[Sharpen.Stub]
		int tether(string iface);

		[Sharpen.Stub]
		int untether(string iface);

		[Sharpen.Stub]
		int getLastTetherError(string iface);

		[Sharpen.Stub]
		bool isTetheringSupported();

		[Sharpen.Stub]
		string[] getTetherableIfaces();

		[Sharpen.Stub]
		string[] getTetheredIfaces();

		[Sharpen.Stub]
		string[] getTetheredIfacePairs();

		[Sharpen.Stub]
		string[] getTetheringErroredIfaces();

		[Sharpen.Stub]
		string[] getTetherableUsbRegexs();

		[Sharpen.Stub]
		string[] getTetherableWifiRegexs();

		[Sharpen.Stub]
		string[] getTetherableBluetoothRegexs();

		[Sharpen.Stub]
		int setUsbTethering(bool enable);

		[Sharpen.Stub]
		void requestNetworkTransitionWakelock(string forWhom);

		[Sharpen.Stub]
		void reportInetCondition(int networkType, int percentage);

		[Sharpen.Stub]
		android.net.ProxyProperties getGlobalProxy();

		[Sharpen.Stub]
		void setGlobalProxy(android.net.ProxyProperties p);

		[Sharpen.Stub]
		android.net.ProxyProperties getProxy();

		[Sharpen.Stub]
		void setDataDependency(int networkType, bool met);

		[Sharpen.Stub]
		bool protectVpn(android.os.ParcelFileDescriptor socket);

		[Sharpen.Stub]
		bool prepareVpn(string oldPackage, string newPackage);

		[Sharpen.Stub]
		android.os.ParcelFileDescriptor establishVpn(android.net.@internal.VpnConfig config
			);

		[Sharpen.Stub]
		void startLegacyVpn(android.net.@internal.VpnConfig config, string[] racoon, string
			[] mtpd);

		[Sharpen.Stub]
		android.net.@internal.LegacyVpnInfo getLegacyVpnInfo();
	}

	[Sharpen.Stub]
	public static class IConnectivityManagerClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.net.IConnectivityManager
		{
			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.net.IConnectivityManager asInterface(android.os.IBinder obj
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

			public abstract android.os.ParcelFileDescriptor establishVpn(android.net.@internal.VpnConfig
				 arg1);

			public abstract android.net.LinkProperties getActiveLinkProperties();

			public abstract android.net.NetworkInfo getActiveNetworkInfo();

			public abstract android.net.NetworkInfo getActiveNetworkInfoForUid(int arg1);

			public abstract android.net.NetworkQuotaInfo getActiveNetworkQuotaInfo();

			public abstract android.net.NetworkInfo[] getAllNetworkInfo();

			public abstract android.net.NetworkState[] getAllNetworkState();

			public abstract android.net.ProxyProperties getGlobalProxy();

			public abstract int getLastTetherError(string arg1);

			public abstract android.net.@internal.LegacyVpnInfo getLegacyVpnInfo();

			public abstract android.net.LinkProperties getLinkProperties(int arg1);

			public abstract bool getMobileDataEnabled();

			public abstract android.net.NetworkInfo getNetworkInfo(int arg1);

			public abstract int getNetworkPreference();

			public abstract android.net.ProxyProperties getProxy();

			public abstract string[] getTetherableBluetoothRegexs();

			public abstract string[] getTetherableIfaces();

			public abstract string[] getTetherableUsbRegexs();

			public abstract string[] getTetherableWifiRegexs();

			public abstract string[] getTetheredIfacePairs();

			public abstract string[] getTetheredIfaces();

			public abstract string[] getTetheringErroredIfaces();

			public abstract bool isNetworkSupported(int arg1);

			public abstract bool isTetheringSupported();

			public abstract bool prepareVpn(string arg1, string arg2);

			public abstract bool protectVpn(android.os.ParcelFileDescriptor arg1);

			public abstract void reportInetCondition(int arg1, int arg2);

			public abstract void requestNetworkTransitionWakelock(string arg1);

			public abstract bool requestRouteToHost(int arg1, int arg2);

			public abstract bool requestRouteToHostAddress(int arg1, byte[] arg2);

			public abstract void setDataDependency(int arg1, bool arg2);

			public abstract void setGlobalProxy(android.net.ProxyProperties arg1);

			public abstract void setMobileDataEnabled(bool arg1);

			public abstract void setNetworkPreference(int arg1);

			public abstract void setPolicyDataEnable(int arg1, bool arg2);

			public abstract bool setRadio(int arg1, bool arg2);

			public abstract bool setRadios(bool arg1);

			public abstract int setUsbTethering(bool arg1);

			public abstract void startLegacyVpn(android.net.@internal.VpnConfig arg1, string[]
				 arg2, string[] arg3);

			public abstract int startUsingNetworkFeature(int arg1, string arg2, android.os.IBinder
				 arg3);

			public abstract int stopUsingNetworkFeature(int arg1, string arg2);

			public abstract int tether(string arg1);

			public abstract int untether(string arg1);
		}
	}
}

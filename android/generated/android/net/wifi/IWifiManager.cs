using Sharpen;

namespace android.net.wifi
{
	[Sharpen.Stub]
	public interface IWifiManager : android.os.IInterface
	{
		[Sharpen.Stub]
		java.util.List<android.net.wifi.WifiConfiguration> getConfiguredNetworks();

		[Sharpen.Stub]
		int addOrUpdateNetwork(android.net.wifi.WifiConfiguration config);

		[Sharpen.Stub]
		bool removeNetwork(int netId);

		[Sharpen.Stub]
		bool enableNetwork(int netId, bool disableOthers);

		[Sharpen.Stub]
		bool disableNetwork(int netId);

		[Sharpen.Stub]
		bool pingSupplicant();

		[Sharpen.Stub]
		void startScan(bool forceActive);

		[Sharpen.Stub]
		java.util.List<android.net.wifi.ScanResult> getScanResults();

		[Sharpen.Stub]
		void disconnect();

		[Sharpen.Stub]
		void reconnect();

		[Sharpen.Stub]
		void reassociate();

		[Sharpen.Stub]
		android.net.wifi.WifiInfo getConnectionInfo();

		[Sharpen.Stub]
		bool setWifiEnabled(bool enable);

		[Sharpen.Stub]
		int getWifiEnabledState();

		[Sharpen.Stub]
		void setCountryCode(string country, bool persist);

		[Sharpen.Stub]
		void setFrequencyBand(int band, bool persist);

		[Sharpen.Stub]
		int getFrequencyBand();

		[Sharpen.Stub]
		bool isDualBandSupported();

		[Sharpen.Stub]
		bool saveConfiguration();

		[Sharpen.Stub]
		android.net.DhcpInfo getDhcpInfo();

		[Sharpen.Stub]
		bool acquireWifiLock(android.os.IBinder @lock, int lockType, string tag, android.os.WorkSource
			 ws);

		[Sharpen.Stub]
		void updateWifiLockWorkSource(android.os.IBinder @lock, android.os.WorkSource ws);

		[Sharpen.Stub]
		bool releaseWifiLock(android.os.IBinder @lock);

		[Sharpen.Stub]
		void initializeMulticastFiltering();

		[Sharpen.Stub]
		bool isMulticastEnabled();

		[Sharpen.Stub]
		void acquireMulticastLock(android.os.IBinder binder, string tag);

		[Sharpen.Stub]
		void releaseMulticastLock();

		[Sharpen.Stub]
		void setWifiApEnabled(android.net.wifi.WifiConfiguration wifiConfig, bool enable);

		[Sharpen.Stub]
		int getWifiApEnabledState();

		[Sharpen.Stub]
		android.net.wifi.WifiConfiguration getWifiApConfiguration();

		[Sharpen.Stub]
		void setWifiApConfiguration(android.net.wifi.WifiConfiguration wifiConfig);

		[Sharpen.Stub]
		void startWifi();

		[Sharpen.Stub]
		void stopWifi();

		[Sharpen.Stub]
		void addToBlacklist(string bssid);

		[Sharpen.Stub]
		void clearBlacklist();

		[Sharpen.Stub]
		android.os.Messenger getMessenger();

		[Sharpen.Stub]
		string getConfigFile();
	}

	[Sharpen.Stub]
	public static class IWifiManagerClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.net.wifi.IWifiManager
		{
			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.net.wifi.IWifiManager asInterface(android.os.IBinder obj)
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

			public abstract void acquireMulticastLock(android.os.IBinder arg1, string arg2);

			public abstract bool acquireWifiLock(android.os.IBinder arg1, int arg2, string arg3
				, android.os.WorkSource arg4);

			public abstract int addOrUpdateNetwork(android.net.wifi.WifiConfiguration arg1);

			public abstract void addToBlacklist(string arg1);

			public abstract void clearBlacklist();

			public abstract bool disableNetwork(int arg1);

			public abstract void disconnect();

			public abstract bool enableNetwork(int arg1, bool arg2);

			public abstract string getConfigFile();

			public abstract java.util.List<android.net.wifi.WifiConfiguration> getConfiguredNetworks
				();

			public abstract android.net.wifi.WifiInfo getConnectionInfo();

			public abstract android.net.DhcpInfo getDhcpInfo();

			public abstract int getFrequencyBand();

			public abstract android.os.Messenger getMessenger();

			public abstract java.util.List<android.net.wifi.ScanResult> getScanResults();

			public abstract android.net.wifi.WifiConfiguration getWifiApConfiguration();

			public abstract int getWifiApEnabledState();

			public abstract int getWifiEnabledState();

			public abstract void initializeMulticastFiltering();

			public abstract bool isDualBandSupported();

			public abstract bool isMulticastEnabled();

			public abstract bool pingSupplicant();

			public abstract void reassociate();

			public abstract void reconnect();

			public abstract void releaseMulticastLock();

			public abstract bool releaseWifiLock(android.os.IBinder arg1);

			public abstract bool removeNetwork(int arg1);

			public abstract bool saveConfiguration();

			public abstract void setCountryCode(string arg1, bool arg2);

			public abstract void setFrequencyBand(int arg1, bool arg2);

			public abstract void setWifiApConfiguration(android.net.wifi.WifiConfiguration arg1
				);

			public abstract void setWifiApEnabled(android.net.wifi.WifiConfiguration arg1, bool
				 arg2);

			public abstract bool setWifiEnabled(bool arg1);

			public abstract void startScan(bool arg1);

			public abstract void startWifi();

			public abstract void stopWifi();

			public abstract void updateWifiLockWorkSource(android.os.IBinder arg1, android.os.WorkSource
				 arg2);
		}
	}
}

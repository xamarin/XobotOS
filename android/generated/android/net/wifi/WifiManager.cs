using Sharpen;

namespace android.net.wifi
{
	[Sharpen.Stub]
	public class WifiManager
	{
		[Sharpen.Stub]
		public WifiManager(android.net.wifi.IWifiManager service, android.os.Handler handler
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual java.util.List<android.net.wifi.WifiConfiguration> getConfiguredNetworks
			()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int addNetwork(android.net.wifi.WifiConfiguration config)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int updateNetwork(android.net.wifi.WifiConfiguration config)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool removeNetwork(int netId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool enableNetwork(int netId, bool disableOthers)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool disableNetwork(int netId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void disableNetwork(int netId, int reason)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool disconnect()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool reconnect()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool reassociate()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool pingSupplicant()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool startScan()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool startScanActive()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.net.wifi.WifiInfo getConnectionInfo()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual java.util.List<android.net.wifi.ScanResult> getScanResults()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool saveConfiguration()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setCountryCode(string country, bool persist)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setFrequencyBand(int band, bool persist)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getFrequencyBand()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isDualBandSupported()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.net.DhcpInfo getDhcpInfo()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool setWifiEnabled(bool enabled)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getWifiState()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isWifiEnabled()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int calculateSignalLevel(int rssi, int numLevels)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int compareSignalLevel(int rssiA, int rssiB)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool setWifiApEnabled(android.net.wifi.WifiConfiguration wifiConfig
			, bool enabled)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getWifiApState()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isWifiApEnabled()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.net.wifi.WifiConfiguration getWifiApConfiguration()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool setWifiApConfiguration(android.net.wifi.WifiConfiguration wifiConfig
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool startWifi()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool stopWifi()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool addToBlacklist(string bssid)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool clearBlacklist()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void asyncConnect(android.content.Context srcContext, android.os.Handler
			 srcHandler)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void connectNetwork(android.net.wifi.WifiConfiguration config)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void connectNetwork(int networkId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void saveNetwork(android.net.wifi.WifiConfiguration config)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void forgetNetwork(int netId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void startWps(android.net.wifi.WpsInfo config)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.os.Messenger getMessenger()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string getConfigFile()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public class WifiLock
		{
			[Sharpen.Stub]
			public virtual void acquire()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void release()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void setReferenceCounted(bool refCounted)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual bool isHeld()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void setWorkSource(android.os.WorkSource ws)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override string ToString()
			{
				throw new System.NotImplementedException();
			}

			~WifiLock()
			{
				throw new System.NotImplementedException();
			}

			internal WifiLock(WifiManager _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly WifiManager _enclosing;
		}

		[Sharpen.Stub]
		public virtual android.net.wifi.WifiManager.WifiLock createWifiLock(int lockType, 
			string tag)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.net.wifi.WifiManager.WifiLock createWifiLock(string tag)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.net.wifi.WifiManager.MulticastLock createMulticastLock(string
			 tag)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public class MulticastLock
		{
			[Sharpen.Stub]
			public virtual void acquire()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void release()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void setReferenceCounted(bool refCounted)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual bool isHeld()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override string ToString()
			{
				throw new System.NotImplementedException();
			}

			~MulticastLock()
			{
				throw new System.NotImplementedException();
			}

			internal MulticastLock(WifiManager _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly WifiManager _enclosing;
		}

		[Sharpen.Stub]
		public virtual bool isMulticastEnabled()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool initializeMulticastFiltering()
		{
			throw new System.NotImplementedException();
		}
	}
}

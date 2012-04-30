using Sharpen;

namespace android.net.wifi.p2p
{
	[Sharpen.Stub]
	public class WifiP2pManager
	{
		[Sharpen.Stub]
		public WifiP2pManager(android.net.wifi.p2p.IWifiP2pManager service)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public interface ChannelListener
		{
			[Sharpen.Stub]
			void onChannelDisconnected();
		}

		[Sharpen.Stub]
		public interface ActionListener
		{
			[Sharpen.Stub]
			void onSuccess();

			[Sharpen.Stub]
			void onFailure(int reason);
		}

		[Sharpen.Stub]
		public interface PeerListListener
		{
			[Sharpen.Stub]
			void onPeersAvailable(android.net.wifi.p2p.WifiP2pDeviceList peers);
		}

		[Sharpen.Stub]
		public interface ConnectionInfoListener
		{
			[Sharpen.Stub]
			void onConnectionInfoAvailable(android.net.wifi.p2p.WifiP2pInfo info);
		}

		[Sharpen.Stub]
		public interface GroupInfoListener
		{
			[Sharpen.Stub]
			void onGroupInfoAvailable(android.net.wifi.p2p.WifiP2pGroup group);
		}

		[Sharpen.Stub]
		public class Channel
		{
			[Sharpen.Stub]
			internal Channel(android.os.Looper looper, android.net.wifi.p2p.WifiP2pManager.ChannelListener
				 l)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal class P2pHandler : android.os.Handler
			{
				[Sharpen.Stub]
				internal P2pHandler(Channel _enclosing, android.os.Looper looper) : base(looper)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.OverridesMethod(@"android.os.Handler")]
				public override void handleMessage(android.os.Message message)
				{
					throw new System.NotImplementedException();
				}

				private readonly Channel _enclosing;
			}

			[Sharpen.Stub]
			internal virtual int putListener(object listener)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal virtual object getListener(int key)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public virtual android.net.wifi.p2p.WifiP2pManager.Channel initialize(android.content.Context
			 srcContext, android.os.Looper srcLooper, android.net.wifi.p2p.WifiP2pManager.ChannelListener
			 listener)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void enableP2p(android.net.wifi.p2p.WifiP2pManager.Channel c)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void disableP2p(android.net.wifi.p2p.WifiP2pManager.Channel c)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void discoverPeers(android.net.wifi.p2p.WifiP2pManager.Channel c, 
			android.net.wifi.p2p.WifiP2pManager.ActionListener listener)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void connect(android.net.wifi.p2p.WifiP2pManager.Channel c, android.net.wifi.p2p.WifiP2pConfig
			 config, android.net.wifi.p2p.WifiP2pManager.ActionListener listener)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void cancelConnect(android.net.wifi.p2p.WifiP2pManager.Channel c, 
			android.net.wifi.p2p.WifiP2pManager.ActionListener listener)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void createGroup(android.net.wifi.p2p.WifiP2pManager.Channel c, android.net.wifi.p2p.WifiP2pManager
			.ActionListener listener)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void removeGroup(android.net.wifi.p2p.WifiP2pManager.Channel c, android.net.wifi.p2p.WifiP2pManager
			.ActionListener listener)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void requestPeers(android.net.wifi.p2p.WifiP2pManager.Channel c, android.net.wifi.p2p.WifiP2pManager
			.PeerListListener listener)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void requestConnectionInfo(android.net.wifi.p2p.WifiP2pManager.Channel
			 c, android.net.wifi.p2p.WifiP2pManager.ConnectionInfoListener listener)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void requestGroupInfo(android.net.wifi.p2p.WifiP2pManager.Channel 
			c, android.net.wifi.p2p.WifiP2pManager.GroupInfoListener listener)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.os.Messenger getMessenger()
		{
			throw new System.NotImplementedException();
		}
	}
}

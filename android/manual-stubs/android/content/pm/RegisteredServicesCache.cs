using Sharpen;

namespace android.content.pm
{
	[Sharpen.Stub]
	public abstract class RegisteredServicesCache<V>
	{
		public RegisteredServicesCache(android.content.Context context, string interfaceName
			, string metaDataName, string attributeName, android.content.pm.XmlSerializerAndParser
			<V> serializerAndParser)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private sealed class _BroadcastReceiver_107 : android.content.BroadcastReceiver
		{
			public _BroadcastReceiver_107(RegisteredServicesCache<V> _enclosing)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.OverridesMethod(@"android.content.BroadcastReceiver")]
			public override void onReceive(android.content.Context context1, android.content.Intent
				 intent)
			{
				throw new System.NotImplementedException();
			}
		}

		public virtual void dump(java.io.FileDescriptor fd, java.io.PrintWriter fout, string
			[] args)
		{
			throw new System.NotImplementedException();
		}

		public virtual android.content.pm.RegisteredServicesCacheListener<V> getListener(
			)
		{
			throw new System.NotImplementedException();
		}

		public virtual void setListener(android.content.pm.RegisteredServicesCacheListener
			<V> listener, android.os.Handler handler)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private sealed class _IRunnable_169 : java.lang.Runnable
		{
			public _IRunnable_169(android.content.pm.RegisteredServicesCacheListener<V> listener2
				, V type, bool removed)
			{
				throw new System.NotImplementedException();
			}

			public void run()
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public class ServiceInfo
		{
			private ServiceInfo(V type, android.content.ComponentName componentName, int uid)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override string ToString()
			{
				throw new System.NotImplementedException();
			}
		}

		public virtual android.content.pm.RegisteredServicesCache<V>.ServiceInfo getServiceInfo
			(V type)
		{
			throw new System.NotImplementedException();
		}

		public virtual System.Collections.Generic.ICollection<android.content.pm.RegisteredServicesCache<V>.ServiceInfo> getAllServices()
		{
			throw new System.NotImplementedException();
		}

		public virtual void close()
		{
			throw new System.NotImplementedException();
		}

		internal virtual void generateServicesMap()
		{
			throw new System.NotImplementedException();
		}

		public abstract V parseServiceAttributes(android.content.res.Resources res, string
			 packageName, android.util.AttributeSet attrs);
	}
}

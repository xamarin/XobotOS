using Sharpen;

namespace android.os.storage
{
	[Sharpen.Stub]
	public class StorageManager
	{
		[Sharpen.Stub]
		public StorageManager(android.os.Looper tgtLooper)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void registerListener(android.os.storage.StorageEventListener listener
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void unregisterListener(android.os.storage.StorageEventListener listener
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void enableUsbMassStorage()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void disableUsbMassStorage()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isUsbMassStorageConnected()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isUsbMassStorageEnabled()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool mountObb(string filename, string key, android.os.storage.OnObbStateChangeListener
			 listener)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool unmountObb(string filename, bool force, android.os.storage.OnObbStateChangeListener
			 listener)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isObbMounted(string filename)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string getMountedObbPath(string filename)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string getVolumeState(string mountPoint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.os.storage.StorageVolume[] getVolumeList()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string[] getVolumePaths()
		{
			throw new System.NotImplementedException();
		}
	}
}

using Sharpen;

namespace android.hardware.usb
{
	[Sharpen.Stub]
	public class UsbManager
	{
		[Sharpen.Stub]
		public UsbManager(android.content.Context context, android.hardware.usb.IUsbManager
			 service)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual java.util.HashMap<string, android.hardware.usb.UsbDevice> getDeviceList
			()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.hardware.usb.UsbDeviceConnection openDevice(android.hardware.usb.UsbDevice
			 device)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.hardware.usb.UsbAccessory[] getAccessoryList()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.os.ParcelFileDescriptor openAccessory(android.hardware.usb.UsbAccessory
			 accessory)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool hasPermission(android.hardware.usb.UsbDevice device)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool hasPermission(android.hardware.usb.UsbAccessory accessory)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void requestPermission(android.hardware.usb.UsbDevice device, android.app.PendingIntent
			 pi)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void requestPermission(android.hardware.usb.UsbAccessory accessory
			, android.app.PendingIntent pi)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isFunctionEnabled(string function)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string getDefaultFunction()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setCurrentFunction(string function, bool makeDefault)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setMassStorageBackingFile(string path)
		{
			throw new System.NotImplementedException();
		}
	}
}

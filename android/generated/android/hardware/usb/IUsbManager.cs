using Sharpen;

namespace android.hardware.usb
{
	[Sharpen.Stub]
	public interface IUsbManager : android.os.IInterface
	{
		[Sharpen.Stub]
		void getDeviceList(android.os.Bundle devices);

		[Sharpen.Stub]
		android.os.ParcelFileDescriptor openDevice(string deviceName);

		[Sharpen.Stub]
		android.hardware.usb.UsbAccessory getCurrentAccessory();

		[Sharpen.Stub]
		android.os.ParcelFileDescriptor openAccessory(android.hardware.usb.UsbAccessory accessory
			);

		[Sharpen.Stub]
		void setDevicePackage(android.hardware.usb.UsbDevice device, string packageName);

		[Sharpen.Stub]
		void setAccessoryPackage(android.hardware.usb.UsbAccessory accessory, string packageName
			);

		[Sharpen.Stub]
		bool hasDevicePermission(android.hardware.usb.UsbDevice device);

		[Sharpen.Stub]
		bool hasAccessoryPermission(android.hardware.usb.UsbAccessory accessory);

		[Sharpen.Stub]
		void requestDevicePermission(android.hardware.usb.UsbDevice device, string packageName
			, android.app.PendingIntent pi);

		[Sharpen.Stub]
		void requestAccessoryPermission(android.hardware.usb.UsbAccessory accessory, string
			 packageName, android.app.PendingIntent pi);

		[Sharpen.Stub]
		void grantDevicePermission(android.hardware.usb.UsbDevice device, int uid);

		[Sharpen.Stub]
		void grantAccessoryPermission(android.hardware.usb.UsbAccessory accessory, int uid
			);

		[Sharpen.Stub]
		bool hasDefaults(string packageName);

		[Sharpen.Stub]
		void clearDefaults(string packageName);

		[Sharpen.Stub]
		void setCurrentFunction(string function, bool makeDefault);

		[Sharpen.Stub]
		void setMassStorageBackingFile(string path);
	}

	[Sharpen.Stub]
	public static class IUsbManagerClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.hardware.usb.IUsbManager
		{
			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.hardware.usb.IUsbManager asInterface(android.os.IBinder obj
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

			public abstract void clearDefaults(string arg1);

			public abstract android.hardware.usb.UsbAccessory getCurrentAccessory();

			public abstract void getDeviceList(android.os.Bundle arg1);

			public abstract void grantAccessoryPermission(android.hardware.usb.UsbAccessory arg1
				, int arg2);

			public abstract void grantDevicePermission(android.hardware.usb.UsbDevice arg1, int
				 arg2);

			public abstract bool hasAccessoryPermission(android.hardware.usb.UsbAccessory arg1
				);

			public abstract bool hasDefaults(string arg1);

			public abstract bool hasDevicePermission(android.hardware.usb.UsbDevice arg1);

			public abstract android.os.ParcelFileDescriptor openAccessory(android.hardware.usb.UsbAccessory
				 arg1);

			public abstract android.os.ParcelFileDescriptor openDevice(string arg1);

			public abstract void requestAccessoryPermission(android.hardware.usb.UsbAccessory
				 arg1, string arg2, android.app.PendingIntent arg3);

			public abstract void requestDevicePermission(android.hardware.usb.UsbDevice arg1, 
				string arg2, android.app.PendingIntent arg3);

			public abstract void setAccessoryPackage(android.hardware.usb.UsbAccessory arg1, 
				string arg2);

			public abstract void setCurrentFunction(string arg1, bool arg2);

			public abstract void setDevicePackage(android.hardware.usb.UsbDevice arg1, string
				 arg2);

			public abstract void setMassStorageBackingFile(string arg1);
		}
	}
}

using Sharpen;

namespace android.location
{
	[Sharpen.Stub]
	public interface ICountryDetector : android.os.IInterface
	{
		[Sharpen.Stub]
		android.location.Country detectCountry();

		[Sharpen.Stub]
		void addCountryListener(android.location.ICountryListener listener);

		[Sharpen.Stub]
		void removeCountryListener(android.location.ICountryListener listener);
	}

	[Sharpen.Stub]
	public static class ICountryDetectorClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.location.ICountryDetector
		{
			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.location.ICountryDetector asInterface(android.os.IBinder obj
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

			public abstract void addCountryListener(android.location.ICountryListener arg1);

			public abstract android.location.Country detectCountry();

			public abstract void removeCountryListener(android.location.ICountryListener arg1
				);
		}
	}
}

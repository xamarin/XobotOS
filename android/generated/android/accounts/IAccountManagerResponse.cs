using Sharpen;

namespace android.accounts
{
	[Sharpen.Stub]
	public interface IAccountManagerResponse : android.os.IInterface
	{
		[Sharpen.Stub]
		void onResult(android.os.Bundle value);

		[Sharpen.Stub]
		void onError(int errorCode, string errorMessage);
	}

	[Sharpen.Stub]
	public static class IAccountManagerResponseClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.accounts.IAccountManagerResponse
		{
			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.accounts.IAccountManagerResponse asInterface(android.os.IBinder
				 obj)
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

			public abstract void onError(int arg1, string arg2);

			public abstract void onResult(android.os.Bundle arg1);
		}
	}
}

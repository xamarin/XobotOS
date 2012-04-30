using Sharpen;

namespace android.os
{
	[Sharpen.Stub]
	public interface IBinder
	{
		[Sharpen.Stub]
		string getInterfaceDescriptor();

		[Sharpen.Stub]
		bool pingBinder();

		[Sharpen.Stub]
		bool isBinderAlive();

		[Sharpen.Stub]
		android.os.IInterface queryLocalInterface(string descriptor);

		[Sharpen.Stub]
		void dump(java.io.FileDescriptor fd, string[] args);

		[Sharpen.Stub]
		void dumpAsync(java.io.FileDescriptor fd, string[] args);

		[Sharpen.Stub]
		bool transact(int code, android.os.Parcel data, android.os.Parcel reply, int flags
			);

		[Sharpen.Stub]
		void linkToDeath(android.os.IBinderClass.DeathRecipient recipient, int flags);

		[Sharpen.Stub]
		bool unlinkToDeath(android.os.IBinderClass.DeathRecipient recipient, int flags);
	}

	[Sharpen.Stub]
	public static class IBinderClass
	{
		public const int FIRST_CALL_TRANSACTION = unchecked((int)(0x00000001));

		public const int LAST_CALL_TRANSACTION = unchecked((int)(0x00ffffff));

		public const int PING_TRANSACTION = ('_' << 24) | ('P' << 16) | ('N' << 8) | 'G';

		public const int DUMP_TRANSACTION = ('_' << 24) | ('D' << 16) | ('M' << 8) | 'P';

		public const int INTERFACE_TRANSACTION = ('_' << 24) | ('N' << 16) | ('T' << 8) |
			 'F';

		public const int TWEET_TRANSACTION = ('_' << 24) | ('T' << 16) | ('W' << 8) | 'T';

		public const int FLAG_ONEWAY = unchecked((int)(0x00000001));

		[Sharpen.Stub]
		public interface DeathRecipient
		{
			[Sharpen.Stub]
			void binderDied();
		}
	}
}

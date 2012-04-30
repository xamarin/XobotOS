using Sharpen;

namespace android.os
{
	[Sharpen.Stub]
	public class Binder : android.os.IBinder
	{
		internal const bool FIND_POTENTIAL_LEAKS = false;

		internal const string TAG = "Binder";

		private int mObject;

		private android.os.IInterface mOwner;

		private string mDescriptor;

		[Sharpen.Stub]
		public static int getCallingPid()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int getCallingUid()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static long clearCallingIdentity()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void restoreCallingIdentity(long token)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void setThreadStrictModePolicy(int policyMask)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int getThreadStrictModePolicy()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void flushPendingCommands()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void joinThreadPool()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public Binder()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void attachInterface(android.os.IInterface owner, string descriptor
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.IBinder")]
		public virtual string getInterfaceDescriptor()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.IBinder")]
		public virtual bool pingBinder()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.IBinder")]
		public virtual bool isBinderAlive()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.IBinder")]
		public virtual android.os.IInterface queryLocalInterface(string descriptor)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual bool onTransact(int code, android.os.Parcel data, android.os.Parcel
			 reply, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.IBinder")]
		public virtual void dump(java.io.FileDescriptor fd, string[] args)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.IBinder")]
		public virtual void dumpAsync(java.io.FileDescriptor fd, string[] args)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual void dump(java.io.FileDescriptor fd, java.io.PrintWriter
			 fout, string[] args)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.IBinder")]
		public virtual bool transact(int code, android.os.Parcel data, android.os.Parcel 
			reply, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.IBinder")]
		public virtual void linkToDeath(android.os.IBinderClass.DeathRecipient recipient, 
			int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.IBinder")]
		public virtual bool unlinkToDeath(android.os.IBinderClass.DeathRecipient recipient
			, int flags)
		{
			throw new System.NotImplementedException();
		}

		~Binder()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void init()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void destroy()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private bool execTransact(int code, int dataObj, int replyObj, int flags)
		{
			throw new System.NotImplementedException();
		}
	}

	[Sharpen.Stub]
	internal sealed class BinderProxy : android.os.IBinder
	{
		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.IBinder")]
		public bool pingBinder()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.IBinder")]
		public bool isBinderAlive()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.IBinder")]
		public android.os.IInterface queryLocalInterface(string descriptor)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.IBinder")]
		public string getInterfaceDescriptor()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.IBinder")]
		public bool transact(int code, android.os.Parcel data, android.os.Parcel reply, int
			 flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.IBinder")]
		public void linkToDeath(android.os.IBinderClass.DeathRecipient recipient, int flags
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.IBinder")]
		public bool unlinkToDeath(android.os.IBinderClass.DeathRecipient recipient, int flags
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.IBinder")]
		public void dump(java.io.FileDescriptor fd, string[] args)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.IBinder")]
		public void dumpAsync(java.io.FileDescriptor fd, string[] args)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal BinderProxy()
		{
			throw new System.NotImplementedException();
		}

		~BinderProxy()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void destroy()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void sendDeathNotice(android.os.IBinderClass.DeathRecipient recipient
			)
		{
			throw new System.NotImplementedException();
		}

		private readonly java.lang.@ref.WeakReference<object> mSelf;

		private int mObject;

		private int mOrgue;
	}
}

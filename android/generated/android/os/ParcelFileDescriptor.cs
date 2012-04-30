using Sharpen;

namespace android.os
{
	[Sharpen.Stub]
	public class ParcelFileDescriptor : android.os.Parcelable
	{
		[Sharpen.Stub]
		public static android.os.ParcelFileDescriptor open(java.io.File file, int mode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.os.ParcelFileDescriptor dup(java.io.FileDescriptor orig)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.os.ParcelFileDescriptor dup()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.os.ParcelFileDescriptor fromFd(int fd)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.os.ParcelFileDescriptor adoptFd(int fd)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.os.ParcelFileDescriptor fromSocket(java.net.Socket socket)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.os.ParcelFileDescriptor fromDatagramSocket(java.net.DatagramSocket
			 datagramSocket)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.os.ParcelFileDescriptor[] createPipe()
		{
			throw new System.NotImplementedException();
		}

		[System.Obsolete]
		[Sharpen.Stub]
		public static android.os.ParcelFileDescriptor fromData(byte[] data, string name)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual java.io.FileDescriptor getFileDescriptor()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual long getStatSize()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual long seekTo(long pos)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getFd()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int detachFd()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void close()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public class AutoCloseInputStream : java.io.FileInputStream
		{
			[Sharpen.Stub]
			public AutoCloseInputStream(android.os.ParcelFileDescriptor fd) : base(fd.getFileDescriptor
				())
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"java.io.InputStream")]
			public override void close()
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public class AutoCloseOutputStream : java.io.FileOutputStream
		{
			[Sharpen.Stub]
			public AutoCloseOutputStream(android.os.ParcelFileDescriptor fd) : base(fd.getFileDescriptor
				())
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"java.io.OutputStream")]
			public override void close()
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			throw new System.NotImplementedException();
		}

		~ParcelFileDescriptor()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public ParcelFileDescriptor(android.os.ParcelFileDescriptor descriptor) : base()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal ParcelFileDescriptor(java.io.FileDescriptor descriptor) : base()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual int describeContents()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual void writeToParcel(android.os.Parcel @out, int flags)
		{
			throw new System.NotImplementedException();
		}
	}
}

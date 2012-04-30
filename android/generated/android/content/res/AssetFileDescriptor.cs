using Sharpen;

namespace android.content.res
{
	[Sharpen.Stub]
	public class AssetFileDescriptor : android.os.Parcelable
	{
		public const long UNKNOWN_LENGTH = -1;

		private readonly android.os.ParcelFileDescriptor mFd;

		private readonly long mStartOffset;

		private readonly long mLength;

		[Sharpen.Stub]
		public AssetFileDescriptor(android.os.ParcelFileDescriptor fd, long startOffset, 
			long length)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.os.ParcelFileDescriptor getParcelFileDescriptor()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual java.io.FileDescriptor getFileDescriptor()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual long getStartOffset()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual long getLength()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual long getDeclaredLength()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void close()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual java.io.FileInputStream createInputStream()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual java.io.FileOutputStream createOutputStream()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public class AutoCloseInputStream : android.os.ParcelFileDescriptor.AutoCloseInputStream
		{
			private long mRemaining;

			[Sharpen.Stub]
			public AutoCloseInputStream(android.content.res.AssetFileDescriptor fd) : base(fd
				.getParcelFileDescriptor())
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"java.io.InputStream")]
			public override int available()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"java.io.InputStream")]
			public override int read()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"java.io.InputStream")]
			public override int read(byte[] buffer, int offset, int count)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"java.io.InputStream")]
			public override int read(byte[] buffer)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"java.io.InputStream")]
			public override long skip(long count)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"java.io.InputStream")]
			public override void mark(int readlimit)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"java.io.InputStream")]
			public override bool markSupported()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"java.io.InputStream")]
			public override void reset()
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public class AutoCloseOutputStream : android.os.ParcelFileDescriptor.AutoCloseOutputStream
		{
			private long mRemaining;

			[Sharpen.Stub]
			public AutoCloseOutputStream(android.content.res.AssetFileDescriptor fd) : base(fd
				.getParcelFileDescriptor())
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"java.io.OutputStream")]
			public override void write(byte[] buffer, int offset, int count)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"java.io.OutputStream")]
			public override void write(byte[] buffer)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"java.io.OutputStream")]
			public override void write(int oneByte)
			{
				throw new System.NotImplementedException();
			}
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

		[Sharpen.Stub]
		internal AssetFileDescriptor(android.os.Parcel src)
		{
			throw new System.NotImplementedException();
		}

		private sealed class _Creator_325 : android.os.ParcelableClass.Creator<android.content.res.AssetFileDescriptor
			>
		{
			public _Creator_325()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.res.AssetFileDescriptor createFromParcel(android.os.Parcel
				 @in)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.res.AssetFileDescriptor[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.content.res.AssetFileDescriptor
			> CREATOR = new _Creator_325();
	}
}

using Sharpen;

namespace java.nio
{
	[Sharpen.Stub]
	internal class MemoryBlock
	{
		[Sharpen.Stub]
		internal static java.nio.MemoryBlock mmap(java.io.FileDescriptor fd, long offset, 
			long size, java.nio.channels.FileChannel.MapMode mapMode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal static java.nio.MemoryBlock allocate(int byteCount)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal static java.nio.MemoryBlock wrapFromJni(int address, long byteCount)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual byte[] array()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void free()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void pokeByte(int offset, byte value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void pokeByteArray(int offset, byte[] src, int srcOffset, int byteCount)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void pokeCharArray(int offset, char[] src, int srcOffset, int charCount, bool
			 swap)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void pokeDoubleArray(int offset, double[] src, int srcOffset, int doubleCount
			, bool swap)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void pokeFloatArray(int offset, float[] src, int srcOffset, int floatCount
			, bool swap)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void pokeIntArray(int offset, int[] src, int srcOffset, int intCount, bool
			 swap)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void pokeLongArray(int offset, long[] src, int srcOffset, int longCount, bool
			 swap)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void pokeShortArray(int offset, short[] src, int srcOffset, int shortCount
			, bool swap)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public byte peekByte(int offset)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void peekByteArray(int offset, byte[] dst, int dstOffset, int byteCount)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void peekCharArray(int offset, char[] dst, int dstOffset, int charCount, bool
			 swap)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void peekDoubleArray(int offset, double[] dst, int dstOffset, int doubleCount
			, bool swap)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void peekFloatArray(int offset, float[] dst, int dstOffset, int floatCount
			, bool swap)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void peekIntArray(int offset, int[] dst, int dstOffset, int intCount, bool
			 swap)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void peekLongArray(int offset, long[] dst, int dstOffset, int longCount, bool
			 swap)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void peekShortArray(int offset, short[] dst, int dstOffset, int shortCount
			, bool swap)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void pokeShort(int offset, short value, java.nio.ByteOrder order)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public short peekShort(int offset, java.nio.ByteOrder order)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void pokeInt(int offset, int value, java.nio.ByteOrder order)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int peekInt(int offset, java.nio.ByteOrder order)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void pokeLong(int offset, long value, java.nio.ByteOrder order)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public long peekLong(int offset, java.nio.ByteOrder order)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int toInt()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public sealed override string ToString()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public long getSize()
		{
			throw new System.NotImplementedException();
		}
	}
}

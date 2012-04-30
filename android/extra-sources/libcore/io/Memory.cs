using Sharpen;
using System;

namespace libcore.io
{
	/// <summary>Unsafe access to memory.</summary>
	/// <remarks>Unsafe access to memory.</remarks>
	[Sharpen.Sharpened]
	public sealed class Memory
	{
		/// <summary>Used to optimize nio heap buffer bulk get operations.</summary>
		/// <remarks>
		/// Used to optimize nio heap buffer bulk get operations. 'dst' must be a primitive array.
		/// 'dstOffset' is measured in units of 'sizeofElements' bytes.
		/// </remarks>
		public static void unsafeBulkGet (object dst, int dstOffset, int byteCount, byte[]
			 src, int srcOffset, int sizeofElements, bool swap)
		{
			Array dstArray = dst as Array;
			if (dstArray == null)
				throw new ArgumentException ();

			if (swap)
				throw new NotImplementedException ();

			Array.Copy (src, srcOffset * sizeofElements, dstArray,
				dstOffset * sizeofElements, byteCount * sizeofElements);
		}

		/// <summary>Used to optimize nio heap buffer bulk put operations.</summary>
		/// <remarks>
		/// Used to optimize nio heap buffer bulk put operations. 'src' must be a primitive array.
		/// 'srcOffset' is measured in units of 'sizeofElements' bytes.
		/// </remarks>
		public static void unsafeBulkPut (byte[] dst, int dstOffset, int byteCount, object
			 src, int srcOffset, int sizeofElements, bool swap)
		{
			Array srcArray = src as Array;
			if (srcArray == null)
				throw new ArgumentException ();

			if (swap)
				throw new NotImplementedException ();

			Array.Copy (srcArray, srcOffset * sizeofElements, dst,
				dstOffset * sizeofElements, byteCount * sizeofElements);
		}

		public static int peekInt (byte[] src, int offset, java.nio.ByteOrder order)
		{
			if (order == java.nio.ByteOrder.BIG_ENDIAN) {
				return (((src [offset++] & unchecked((int)(0xff))) << 24) | ((src [offset++] & unchecked(
					(int)(0xff))) << 16) | ((src [offset++] & unchecked((int)(0xff))) << 8) | ((src [offset
					] & unchecked((int)(0xff))) << 0));
			} else {
				return (((src [offset++] & unchecked((int)(0xff))) << 0) | ((src [offset++] & unchecked(
					(int)(0xff))) << 8) | ((src [offset++] & unchecked((int)(0xff))) << 16) | ((src [offset
					] & unchecked((int)(0xff))) << 24));
			}
		}

		public static long peekLong (byte[] src, int offset, java.nio.ByteOrder order)
		{
			if (order == java.nio.ByteOrder.BIG_ENDIAN) {
				int h = ((src [offset++] & unchecked((int)(0xff))) << 24) | ((src [offset++] & unchecked(
					(int)(0xff))) << 16) | ((src [offset++] & unchecked((int)(0xff))) << 8) | ((src [offset
					++] & unchecked((int)(0xff))) << 0);
				int l = ((src [offset++] & unchecked((int)(0xff))) << 24) | ((src [offset++] & unchecked(
					(int)(0xff))) << 16) | ((src [offset++] & unchecked((int)(0xff))) << 8) | ((src [offset
					] & unchecked((int)(0xff))) << 0);
				return (((long)h) << 32) | ((long)l) & unchecked((long)(0xffffffffL));
			} else {
				int l = ((src [offset++] & unchecked((int)(0xff))) << 0) | ((src [offset++] & unchecked(
					(int)(0xff))) << 8) | ((src [offset++] & unchecked((int)(0xff))) << 16) | ((src [offset
					++] & unchecked((int)(0xff))) << 24);
				int h = ((src [offset++] & unchecked((int)(0xff))) << 0) | ((src [offset++] & unchecked(
					(int)(0xff))) << 8) | ((src [offset++] & unchecked((int)(0xff))) << 16) | ((src [offset
					] & unchecked((int)(0xff))) << 24);
				return (((long)h) << 32) | ((long)l) & unchecked((long)(0xffffffffL));
			}
		}

		public static short peekShort (byte[] src, int offset, java.nio.ByteOrder order)
		{
			if (order == java.nio.ByteOrder.BIG_ENDIAN) {
				return (short)((src [offset] << 8) | (src [offset + 1] & unchecked((int)(0xff))));
			} else {
				return (short)((src [offset + 1] << 8) | (src [offset] & unchecked((int)(0xff))));
			}
		}

		public static void pokeInt (byte[] dst, int offset, int value, java.nio.ByteOrder 
			order)
		{
			if (order == java.nio.ByteOrder.BIG_ENDIAN) {
				dst [offset++] = unchecked((byte)((value >> 24) & unchecked((int)(0xff))));
				dst [offset++] = unchecked((byte)((value >> 16) & unchecked((int)(0xff))));
				dst [offset++] = unchecked((byte)((value >> 8) & unchecked((int)(0xff))));
				dst [offset] = unchecked((byte)((value >> 0) & unchecked((int)(0xff))));
			} else {
				dst [offset++] = unchecked((byte)((value >> 0) & unchecked((int)(0xff))));
				dst [offset++] = unchecked((byte)((value >> 8) & unchecked((int)(0xff))));
				dst [offset++] = unchecked((byte)((value >> 16) & unchecked((int)(0xff))));
				dst [offset] = unchecked((byte)((value >> 24) & unchecked((int)(0xff))));
			}
		}

		public static void pokeLong (byte[] dst, int offset, long value, java.nio.ByteOrder
			 order)
		{
			if (order == java.nio.ByteOrder.BIG_ENDIAN) {
				int i = (int)(value >> 32);
				dst [offset++] = unchecked((byte)((i >> 24) & unchecked((int)(0xff))));
				dst [offset++] = unchecked((byte)((i >> 16) & unchecked((int)(0xff))));
				dst [offset++] = unchecked((byte)((i >> 8) & unchecked((int)(0xff))));
				dst [offset++] = unchecked((byte)((i >> 0) & unchecked((int)(0xff))));
				i = (int)value;
				dst [offset++] = unchecked((byte)((i >> 24) & unchecked((int)(0xff))));
				dst [offset++] = unchecked((byte)((i >> 16) & unchecked((int)(0xff))));
				dst [offset++] = unchecked((byte)((i >> 8) & unchecked((int)(0xff))));
				dst [offset] = unchecked((byte)((i >> 0) & unchecked((int)(0xff))));
			} else {
				int i = (int)value;
				dst [offset++] = unchecked((byte)((i >> 0) & unchecked((int)(0xff))));
				dst [offset++] = unchecked((byte)((i >> 8) & unchecked((int)(0xff))));
				dst [offset++] = unchecked((byte)((i >> 16) & unchecked((int)(0xff))));
				dst [offset++] = unchecked((byte)((i >> 24) & unchecked((int)(0xff))));
				i = (int)(value >> 32);
				dst [offset++] = unchecked((byte)((i >> 0) & unchecked((int)(0xff))));
				dst [offset++] = unchecked((byte)((i >> 8) & unchecked((int)(0xff))));
				dst [offset++] = unchecked((byte)((i >> 16) & unchecked((int)(0xff))));
				dst [offset] = unchecked((byte)((i >> 24) & unchecked((int)(0xff))));
			}
		}

		public static void pokeShort (byte[] dst, int offset, short value, java.nio.ByteOrder
			 order)
		{
			if (order == java.nio.ByteOrder.BIG_ENDIAN) {
				dst [offset++] = unchecked((byte)((value >> 8) & unchecked((int)(0xff))));
				dst [offset] = unchecked((byte)((value >> 0) & unchecked((int)(0xff))));
			} else {
				dst [offset++] = unchecked((byte)((value >> 0) & unchecked((int)(0xff))));
				dst [offset] = unchecked((byte)((value >> 8) & unchecked((int)(0xff))));
			}
		}

#if FIXME
		/// <summary>Copies 'byteCount' bytes from the source to the destination.</summary>
		/// <remarks>
		/// Copies 'byteCount' bytes from the source to the destination. The objects are either
		/// instances of DirectByteBuffer or byte[]. The offsets in the byte[] case must include
		/// the Buffer.arrayOffset if the array came from a Buffer.array call. We could make this
		/// private and provide the four type-safe variants, but then ByteBuffer.put(ByteBuffer)
		/// would need to work out which to call based on whether the source and destination buffers
		/// are direct or not.
		/// </remarks>
		/// <hide>make type-safe before making public?</hide>
		public static void memmove(object dstObject, int dstOffset, object srcObject, int
			 srcOffset, long byteCount)
		{
		}

		public static byte peekByte(int address)
		{
		}

		public static int peekInt(int address, bool swap)
		{
		}

		public static long peekLong(int address, bool swap)
		{
		}

		public static short peekShort(int address, bool swap)
		{
		}

		public static void peekByteArray(int address, byte[] dst, int dstOffset, int byteCount
			)
		{
		}

		public static void peekCharArray(int address, char[] dst, int dstOffset, int charCount
			, bool swap)
		{
		}

		public static void peekDoubleArray(int address, double[] dst, int dstOffset, int 
			doubleCount, bool swap)
		{
		}

		public static void peekFloatArray(int address, float[] dst, int dstOffset, int floatCount
			, bool swap)
		{
		}

		public static void peekIntArray(int address, int[] dst, int dstOffset, int intCount
			, bool swap)
		{
		}

		public static void peekLongArray(int address, long[] dst, int dstOffset, int longCount
			, bool swap)
		{
		}

		public static void peekShortArray(int address, short[] dst, int dstOffset, int shortCount
			, bool swap)
		{
		}

		public static void pokeByte(int address, byte value)
		{
		}

		public static void pokeInt(int address, int value, bool swap)
		{
		}

		public static void pokeLong(int address, long value, bool swap)
		{
		}

		public static void pokeShort(int address, short value, bool swap)
		{
		}

		public static void pokeByteArray(int address, byte[] src, int offset, int count)
		{
		}

		public static void pokeCharArray(int address, char[] src, int offset, int count, 
			bool swap)
		{
		}

		public static void pokeDoubleArray(int address, double[] src, int offset, int count
			, bool swap)
		{
		}

		public static void pokeFloatArray(int address, float[] src, int offset, int count
			, bool swap)
		{
		}

		public static void pokeIntArray(int address, int[] src, int offset, int count, bool
			 swap)
		{
		}

		public static void pokeLongArray(int address, long[] src, int offset, int count, 
			bool swap)
		{
		}

		public static void pokeShortArray(int address, short[] src, int offset, int count
			, bool swap)
		{
		}
#endif
	}
}

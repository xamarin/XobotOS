namespace java.nio
{
	partial class ByteBuffer
	{
		public virtual java.nio.ByteBuffer put(java.nio.ByteBuffer src)
		{
			if (src == this)
			{
				throw new System.ArgumentException("src == this");
			}
			int srcByteCount = src.remaining();
			if (srcByteCount > remaining())
			{
				throw new java.nio.BufferOverflowException();
			}
			if (src.isDirect()) {
				throw new System.InvalidOperationException();
			}
			byte[] srcObject = java.nio.NioUtils.unsafeArray(src);
			int srcOffset = src.position();
			if (!src.isDirect())
			{
				srcOffset += java.nio.NioUtils.unsafeArrayOffset(src);
			}
			java.nio.ByteBuffer dst = this;
			if (dst.isDirect()) {
				throw new System.InvalidOperationException();
			}
			byte[] dstObject = java.nio.NioUtils.unsafeArray(dst);
			int dstOffset = dst.position();
			if (!dst.isDirect())
			{
				dstOffset += java.nio.NioUtils.unsafeArrayOffset(dst);
			}
			System.Array.Copy(srcObject, srcOffset, dstObject, dstOffset, srcByteCount);
			src.position(src.limit());
			dst.position(dst.position() + srcByteCount);
			return this;
		}

		/// <summary>Creates a direct byte buffer based on a newly allocated memory block.</summary>
		/// <remarks>Creates a direct byte buffer based on a newly allocated memory block.</remarks>
		/// <param name="capacity">the capacity of the new buffer</param>
		/// <returns>the created byte buffer.</returns>
		/// <exception cref="System.ArgumentException">
		/// if
		/// <code>capacity &lt; 0</code>
		/// .
		/// </exception>
		public static java.nio.ByteBuffer allocateDirect(int capacity_1)
		{
			if (capacity_1 < 0)
			{
				throw new System.ArgumentException();
			}
			// FIXME: We do not support direct buffers
			return new java.nio.ReadWriteHeapByteBuffer(capacity_1);
		}
	}
}


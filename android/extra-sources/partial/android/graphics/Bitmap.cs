namespace android.graphics
{
	partial class Bitmap
	{
		/// <noinspection>UnusedDeclaration</noinspection>
		internal Bitmap (NativeBitmap nativeBitmap)
		{
			if ((nativeBitmap == null) || nativeBitmap.IsInvalid)
				throw new java.lang.RuntimeException ("internal error: native bitmap is null");
			mNativeBitmap = nativeBitmap;
		}

		/// <summary>
		/// Copy the bitmap's pixels into the specified buffer (allocated by the
		/// caller).
		/// </summary>
		/// <remarks>
		/// Copy the bitmap's pixels into the specified buffer (allocated by the
		/// caller). An exception is thrown if the buffer is not large enough to
		/// hold all of the pixels (taking into account the number of bytes per
		/// pixel) or if the Buffer subclass is not one of the support types
		/// (ByteBuffer, ShortBuffer, IntBuffer).
		/// </remarks>
		public void copyPixelsToBuffer (java.nio.Buffer dst)
		{
			int elements = dst.remaining ();
			int shift;
			if (dst is java.nio.ByteBuffer) {
				shift = 0;
			} else {
				if (dst is java.nio.ShortBuffer) {
					shift = 1;
				} else {
					if (dst is java.nio.IntBuffer) {
						shift = 2;
					} else {
						throw new java.lang.RuntimeException ("unsupported Buffer subclass");
					}
				}
			}
			long bufferSize = (long)elements << shift;
			long pixelSize = getByteCount ();
			if (bufferSize < pixelSize) {
				throw new java.lang.RuntimeException ("Buffer not large enough for pixels");
			}
			// FIXME
			// nativeCopyPixelsToBuffer (mNativeBitmap, dst);
			// now update the buffer's position
			int position = dst.position ();
			// FIXME: Needed to add an explicit cast to int.
			position += (int)(pixelSize >> shift);
			dst.position (position);
		}
	}
}

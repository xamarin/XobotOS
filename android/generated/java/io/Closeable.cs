using Sharpen;

namespace java.io
{
	/// <summary>
	/// An
	/// <code>AutoCloseable</code>
	/// whose close method may throw an
	/// <see cref="IOException">IOException</see>
	/// .
	/// </summary>
	[Sharpen.Sharpened]
	public interface Closeable : java.lang.AutoCloseable
	{
		/// <summary>Closes the object and release any system resources it holds.</summary>
		/// <remarks>
		/// Closes the object and release any system resources it holds.
		/// <p>Although only the first call has any effect, it is safe to call close
		/// multiple times on the same object. This is more lenient than the
		/// overridden
		/// <code>AutoCloseable.close()</code>
		/// , which may be called at most
		/// once.
		/// </remarks>
		/// <exception cref="System.IO.IOException"></exception>
		void close();
	}
}

using Sharpen;

namespace java.io
{
	/// <summary>
	/// Defines an interface for classes that can (or need to) be flushed, typically
	/// before some output processing is considered to be finished and the object
	/// gets closed.
	/// </summary>
	/// <remarks>
	/// Defines an interface for classes that can (or need to) be flushed, typically
	/// before some output processing is considered to be finished and the object
	/// gets closed.
	/// </remarks>
	[Sharpen.Sharpened]
	public interface Flushable
	{
		/// <summary>
		/// Flushes the object by writing out any buffered data to the underlying
		/// output.
		/// </summary>
		/// <remarks>
		/// Flushes the object by writing out any buffered data to the underlying
		/// output.
		/// </remarks>
		/// <exception cref="IOException">if there are any issues writing the data.</exception>
		/// <exception cref="System.IO.IOException"></exception>
		void flush();
	}
}

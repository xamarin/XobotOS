using Sharpen;

namespace java.io
{
	/// <summary>
	/// A specialized
	/// <see cref="Reader">Reader</see>
	/// that reads from a file in the file system.
	/// All read requests made by calling methods in this class are directly
	/// forwarded to the equivalent function of the underlying operating system.
	/// Since this may induce some performance penalty, in particular if many small
	/// read requests are made, a FileReader is often wrapped by a
	/// BufferedReader.
	/// </summary>
	/// <seealso cref="BufferedReader">BufferedReader</seealso>
	/// <seealso cref="FileWriter">FileWriter</seealso>
	[Sharpen.Sharpened]
	public class FileReader : java.io.InputStreamReader
	{
		/// <summary>
		/// Constructs a new FileReader on the given
		/// <code>file</code>
		/// .
		/// </summary>
		/// <param name="file">a File to be opened for reading characters from.</param>
		/// <exception cref="FileNotFoundException">
		/// if
		/// <code>file</code>
		/// does not exist.
		/// </exception>
		/// <exception cref="java.io.FileNotFoundException"></exception>
		public FileReader(java.io.File file) : base(new java.io.FileInputStream(file))
		{
		}

		/// <summary>
		/// Construct a new FileReader on the given FileDescriptor
		/// <code>fd</code>
		/// . Since
		/// a previously opened FileDescriptor is passed as an argument, no
		/// FileNotFoundException can be thrown.
		/// </summary>
		/// <param name="fd">the previously opened file descriptor.</param>
		public FileReader(java.io.FileDescriptor fd) : base(new java.io.FileInputStream(fd
			))
		{
		}

		/// <summary>
		/// Construct a new FileReader on the given file named
		/// <code>filename</code>
		/// .
		/// </summary>
		/// <param name="filename">an absolute or relative path specifying the file to open.</param>
		/// <exception cref="FileNotFoundException">
		/// if there is no file named
		/// <code>filename</code>
		/// .
		/// </exception>
		/// <exception cref="java.io.FileNotFoundException"></exception>
		public FileReader(string filename) : base(new java.io.FileInputStream(filename))
		{
		}
	}
}

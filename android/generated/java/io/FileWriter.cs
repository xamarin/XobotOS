using Sharpen;

namespace java.io
{
	/// <summary>
	/// A specialized
	/// <see cref="Writer">Writer</see>
	/// that writes to a file in the file system.
	/// All write requests made by calling methods in this class are directly
	/// forwarded to the equivalent function of the underlying operating system.
	/// Since this may induce some performance penalty, in particular if many small
	/// write requests are made, a FileWriter is often wrapped by a
	/// BufferedWriter.
	/// </summary>
	/// <seealso cref="BufferedWriter">BufferedWriter</seealso>
	/// <seealso cref="FileReader">FileReader</seealso>
	[Sharpen.Sharpened]
	public class FileWriter : java.io.OutputStreamWriter
	{
		/// <summary>
		/// Creates a FileWriter using the File
		/// <code>file</code>
		/// .
		/// </summary>
		/// <param name="file">the non-null File to write bytes to.</param>
		/// <exception cref="IOException">
		/// if
		/// <code>file</code>
		/// cannot be opened for writing.
		/// </exception>
		/// <exception cref="System.IO.IOException"></exception>
		public FileWriter(java.io.File file) : base(new java.io.FileOutputStream(file))
		{
		}

		/// <summary>
		/// Creates a FileWriter using the File
		/// <code>file</code>
		/// . The parameter
		/// <code>append</code>
		/// determines whether or not the file is opened and appended
		/// to or just opened and overwritten.
		/// </summary>
		/// <param name="file">the non-null File to write bytes to.</param>
		/// <param name="append">indicates whether or not to append to an existing file.</param>
		/// <exception cref="IOException">
		/// if the
		/// <code>file</code>
		/// cannot be opened for writing.
		/// </exception>
		/// <exception cref="System.IO.IOException"></exception>
		public FileWriter(java.io.File file, bool append_1) : base(new java.io.FileOutputStream
			(file, append_1))
		{
		}

		/// <summary>
		/// Creates a FileWriter using the existing FileDescriptor
		/// <code>fd</code>
		/// .
		/// </summary>
		/// <param name="fd">the non-null FileDescriptor to write bytes to.</param>
		public FileWriter(java.io.FileDescriptor fd) : base(new java.io.FileOutputStream(
			fd))
		{
		}

		/// <summary>
		/// Creates a FileWriter using the platform dependent
		/// <code>filename</code>
		/// .
		/// </summary>
		/// <param name="filename">the non-null name of the file to write bytes to.</param>
		/// <exception cref="IOException">if the file cannot be opened for writing.</exception>
		/// <exception cref="System.IO.IOException"></exception>
		public FileWriter(string filename) : base(new java.io.FileOutputStream(new java.io.File
			(filename)))
		{
		}

		/// <summary>
		/// Creates a FileWriter using the platform dependent
		/// <code>filename</code>
		/// . The
		/// parameter
		/// <code>append</code>
		/// determines whether or not the file is opened and
		/// appended to or just opened and overwritten.
		/// </summary>
		/// <param name="filename">the non-null name of the file to write bytes to.</param>
		/// <param name="append">indicates whether or not to append to an existing file.</param>
		/// <exception cref="IOException">
		/// if the
		/// <code>file</code>
		/// cannot be opened for writing.
		/// </exception>
		/// <exception cref="System.IO.IOException"></exception>
		public FileWriter(string filename, bool append_1) : base(new java.io.FileOutputStream
			(filename, append_1))
		{
		}
	}
}

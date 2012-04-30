using Sharpen;

namespace java.io
{
	/// <summary>
	/// An interface for filtering
	/// <see cref="File">File</see>
	/// objects based on their names
	/// or the directory they reside in.
	/// </summary>
	/// <seealso cref="File">File</seealso>
	/// <seealso cref="File.list(FilenameFilter)">File.list(FilenameFilter)</seealso>
	[Sharpen.Sharpened]
	public interface FilenameFilter
	{
		/// <summary>Indicates if a specific filename matches this filter.</summary>
		/// <remarks>Indicates if a specific filename matches this filter.</remarks>
		/// <param name="dir">
		/// the directory in which the
		/// <code>filename</code>
		/// was found.
		/// </param>
		/// <param name="filename">
		/// the name of the file in
		/// <code>dir</code>
		/// to test.
		/// </param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if the filename matches the filter
		/// and can be included in the list,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		bool accept(java.io.File dir, string filename);
	}
}

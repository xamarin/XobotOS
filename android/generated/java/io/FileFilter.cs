using Sharpen;

namespace java.io
{
	/// <summary>
	/// An interface for filtering
	/// <see cref="File">File</see>
	/// objects based on their names
	/// or other information.
	/// </summary>
	/// <seealso cref="File.listFiles(FileFilter)">File.listFiles(FileFilter)</seealso>
	[Sharpen.Sharpened]
	public interface FileFilter
	{
		/// <summary>Indicating whether a specific file should be included in a pathname list.
		/// 	</summary>
		/// <remarks>Indicating whether a specific file should be included in a pathname list.
		/// 	</remarks>
		/// <param name="pathname">the abstract file to check.</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if the file should be included,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		bool accept(java.io.File pathname);
	}
}

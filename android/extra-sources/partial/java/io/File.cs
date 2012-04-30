using System;
using System.IO;

namespace java.io
{
	partial class File
	{
		static File ()
		{
			separatorChar = Path.DirectorySeparatorChar;
			pathSeparatorChar = Path.PathSeparator;
			separator = separatorChar.ToString ();
			pathSeparator = pathSeparatorChar.ToString ();
		}

		/// <summary>Constructs a new file using the specified directory and name.</summary>
		/// <remarks>Constructs a new file using the specified directory and name.</remarks>
		/// <param name="dir">the directory where the file is stored.</param>
		/// <param name="name">the file's name.</param>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>name</code>
		/// is
		/// <code>null</code>
		/// .
		/// </exception>
		public File (java.io.File dir, string name)
			: this(dir == null ? null : dir.getPath(), name)
		{
		}

		/// <summary>Constructs a new file using the specified path.</summary>
		/// <remarks>Constructs a new file using the specified path.</remarks>
		/// <param name="path">the path to be used for the file.</param>
		public File (string path)
		{
			this.path = fixSlashes (path);
			this.info = new FileInfo (path);
		}

		/// <summary>
		/// Constructs a new File using the specified directory path and file name,
		/// placing a path separator between the two.
		/// </summary>
		/// <remarks>
		/// Constructs a new File using the specified directory path and file name,
		/// placing a path separator between the two.
		/// </remarks>
		/// <param name="dirPath">the path to the directory where the file is stored.</param>
		/// <param name="name">the file's name.</param>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>name == null</code>
		/// .
		/// </exception>
		public File (string dirPath, string name)
		{
			if (name == null) {
				throw new System.ArgumentNullException ();
			}
			if (dirPath == null || string.IsNullOrEmpty (dirPath)) {
				this.path = fixSlashes (name);
			} else {
				if (string.IsNullOrEmpty (name)) {
					this.path = fixSlashes (dirPath);
				} else {
					this.path = fixSlashes (join (dirPath, name));
				}
			}

			this.info = new FileInfo (this.path);
		}

		/// <summary>Constructs a new File using the path of the specified URI.</summary>
		/// <remarks>
		/// Constructs a new File using the path of the specified URI.
		/// <code>uri</code>
		/// needs to be an absolute and hierarchical Unified Resource Identifier with
		/// file scheme and non-empty path component, but with undefined authority,
		/// query or fragment components.
		/// </remarks>
		/// <param name="uri">
		/// the Unified Resource Identifier that is used to construct this
		/// file.
		/// </param>
		/// <exception cref="System.ArgumentException">
		/// if
		/// <code>uri</code>
		/// does not comply with the conditions above.
		/// </exception>
		/// <seealso cref="toURI()">toURI()</seealso>
		/// <seealso cref="java.net.URI">java.net.URI</seealso>
		public File (java.net.URI uri)
		{
			// check pre-conditions
			checkURI (uri);
			this.path = fixSlashes (uri.getPath ());
			this.info = new FileInfo (this.path);
		}

		readonly FileInfo info;

		/// <summary>
		/// Returns a boolean indicating whether this file can be found on the
		/// underlying file system.
		/// </summary>
		/// <remarks>
		/// Returns a boolean indicating whether this file can be found on the
		/// underlying file system.
		/// </remarks>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if this file exists,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		public virtual bool exists ()
		{
			return info.Exists;
		}

		/// <summary>Tests whether or not this process is allowed to execute this file.</summary>
		/// <remarks>
		/// Tests whether or not this process is allowed to execute this file.
		/// Note that this is a best-effort result; the only way to be certain is
		/// to actually attempt the operation.
		/// </remarks>
		/// <returns>
		///
		/// <code>true</code>
		/// if this file can be executed,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		/// <since>1.6</since>
		public virtual bool canExecute ()
		{
			return info.Exists;
		}

		/// <summary>Indicates whether the current context is allowed to read from this file.
		/// 	</summary>
		/// <remarks>Indicates whether the current context is allowed to read from this file.
		/// 	</remarks>
		/// <returns>
		///
		/// <code>true</code>
		/// if this file can be read,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		public virtual bool canRead ()
		{
			return info.Exists;
		}

		/// <summary>Indicates whether the current context is allowed to write to this file.</summary>
		/// <remarks>Indicates whether the current context is allowed to write to this file.</remarks>
		/// <returns>
		///
		/// <code>true</code>
		/// if this file can be written,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		public virtual bool canWrite ()
		{
			return info.Exists && !info.IsReadOnly;
		}

		/// <summary>Deletes this file.</summary>
		/// <remarks>
		/// Deletes this file. Directories must be empty before they will be deleted.
		/// <p>Note that this method does <i>not</i> throw
		/// <code>IOException</code>
		/// on failure.
		/// Callers must check the return value.
		/// </remarks>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if this file was deleted,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		public virtual bool delete ()
		{
			try {
				info.Delete ();
				return true;
			} catch {
				return false;
			}
		}
		/// <summary>Returns the absolute path of this file.</summary>
		/// <remarks>
		/// Returns the absolute path of this file. An absolute path is a path that starts at a root
		/// of the file system. On Android, there is only one root:
		/// <code>/</code>
		/// .
		/// <p>A common use for absolute paths is when passing paths to a
		/// <code>Process</code>
		/// as
		/// command-line arguments, to remove the requirement implied by relative paths, that the
		/// child must have the same working directory as its parent.
		/// </remarks>
		public virtual string getAbsolutePath ()
		{
			if (isAbsolute ()) {
				return path;
			}
			string userDir = Environment.GetFolderPath (Environment.SpecialFolder.UserProfile);
			return string.IsNullOrEmpty (path) ? userDir : join (userDir, path);
		}

		/// <summary>
		/// Indicates if this file represents a <em>directory</em> on the
		/// underlying file system.
		/// </summary>
		/// <remarks>
		/// Indicates if this file represents a <em>directory</em> on the
		/// underlying file system.
		/// </remarks>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if this file is a directory,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		public virtual bool isDirectory ()
		{
			return (info.Attributes & FileAttributes.Directory) != 0;
		}

		/// <summary>
		/// Indicates if this file represents a <em>file</em> on the underlying
		/// file system.
		/// </summary>
		/// <remarks>
		/// Indicates if this file represents a <em>file</em> on the underlying
		/// file system.
		/// </remarks>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if this file is a file,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		public virtual bool isFile ()
		{
			return (info.Attributes & FileAttributes.Normal) != 0;
		}

		/// <summary>
		/// Returns the time when this file was last modified, measured in
		/// milliseconds since January 1st, 1970, midnight.
		/// </summary>
		/// <remarks>
		/// Returns the time when this file was last modified, measured in
		/// milliseconds since January 1st, 1970, midnight.
		/// Returns 0 if the file does not exist.
		/// </remarks>
		/// <returns>the time when this file was last modified.</returns>
		public virtual long lastModified ()
		{
			return info.LastWriteTime.Ticks;
		}


		/// <summary>Returns the length of this file in bytes.</summary>
		/// <remarks>
		/// Returns the length of this file in bytes.
		/// Returns 0 if the file does not exist.
		/// The result for a directory is not defined.
		/// </remarks>
		/// <returns>the number of bytes in this file.</returns>
		public virtual long length ()
		{
			return info.Exists ? info.Length : 0;
		}


	}
}


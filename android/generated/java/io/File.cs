using Sharpen;

namespace java.io
{
	/// <summary>
	/// An "abstract" representation of a file system entity identified by a
	/// pathname.
	/// </summary>
	/// <remarks>
	/// An "abstract" representation of a file system entity identified by a
	/// pathname. The pathname may be absolute (relative to the root directory
	/// of the file system) or relative to the current directory in which the program
	/// is running.
	/// <p>The actual file referenced by a
	/// <code>File</code>
	/// may or may not exist. It may
	/// also, despite the name
	/// <code>File</code>
	/// , be a directory or other non-regular
	/// file.
	/// <p>This class provides limited functionality for getting/setting file
	/// permissions, file type, and last modified time.
	/// <p>On Android strings are converted to UTF-8 byte sequences when sending filenames to
	/// the operating system, and byte sequences returned by the operating system (from the
	/// various
	/// <code>list</code>
	/// methods) are converted to strings by decoding them as UTF-8
	/// byte sequences.
	/// </remarks>
	/// <seealso cref="Serializable">Serializable</seealso>
	/// <seealso cref="java.lang.Comparable{T}">java.lang.Comparable&lt;T&gt;</seealso>
	[System.Serializable]
	[Sharpen.Sharpened]
	public sealed partial class File : java.lang.Comparable<java.io.File>
	{
		internal const long serialVersionUID = 301077366599181567L;

		/// <summary>Reusing a Random makes temporary filenames slightly harder to predict.</summary>
		/// <remarks>
		/// Reusing a Random makes temporary filenames slightly harder to predict.
		/// (Random is thread-safe.)
		/// </remarks>
		private static readonly System.Random tempFileRandom = new System.Random();

		/// <summary>The system-dependent character used to separate components in filenames ('/').
		/// 	</summary>
		/// <remarks>
		/// The system-dependent character used to separate components in filenames ('/').
		/// Use of this (rather than hard-coding '/') helps portability to other operating systems.
		/// <p>This field is initialized from the system property "file.separator".
		/// Later changes to that property will have no effect on this field or this class.
		/// </remarks>
		public static readonly char separatorChar;

		/// <summary>The system-dependent string used to separate components in filenames ('/').
		/// 	</summary>
		/// <remarks>
		/// The system-dependent string used to separate components in filenames ('/').
		/// See
		/// <see cref="separatorChar">separatorChar</see>
		/// .
		/// </remarks>
		public static readonly string separator;

		/// <summary>The system-dependent character used to separate components in search paths (':').
		/// 	</summary>
		/// <remarks>
		/// The system-dependent character used to separate components in search paths (':').
		/// This is used to split such things as the PATH environment variable and classpath
		/// system properties into lists of directories to be searched.
		/// <p>This field is initialized from the system property "path.separator".
		/// Later changes to that property will have no effect on this field or this class.
		/// </remarks>
		public static readonly char pathSeparatorChar;

		/// <summary>The system-dependent string used to separate components in search paths (":").
		/// 	</summary>
		/// <remarks>
		/// The system-dependent string used to separate components in search paths (":").
		/// See
		/// <see cref="pathSeparatorChar">pathSeparatorChar</see>
		/// .
		/// </remarks>
		public static readonly string pathSeparator;

		/// <summary>The path we return from getPath.</summary>
		/// <remarks>
		/// The path we return from getPath. This is almost the path we were
		/// given, but without duplicate adjacent slashes and without trailing
		/// slashes (except for the special case of the root directory). This
		/// path may be the empty string.
		/// This can't be final because we override readObject.
		/// </remarks>
		private string path;

		// check pre-conditions
		// Removes duplicate adjacent slashes and any trailing slash.
		private static string fixSlashes(string origPath)
		{
			// Remove duplicate adjacent slashes.
			bool lastWasSlash = false;
			char[] newPath = origPath.ToCharArray();
			int length_1 = newPath.Length;
			int newLength = 0;
			{
				for (int i = 0; i < length_1; ++i)
				{
					char ch = newPath[i];
					if (ch == '/')
					{
						if (!lastWasSlash)
						{
							newPath[newLength++] = separatorChar;
							lastWasSlash = true;
						}
					}
					else
					{
						newPath[newLength++] = ch;
						lastWasSlash = false;
					}
				}
			}
			// Remove any trailing slash (unless this is the root of the file system).
			if (lastWasSlash && newLength > 1)
			{
				newLength--;
			}
			// Reuse the original string if possible.
			return (newLength != length_1) ? new string(newPath, 0, newLength) : origPath;
		}

		// Joins two path components, adding a separator only if necessary.
		private static string join(string prefix, string suffix)
		{
			int prefixLength = prefix.Length;
			bool haveSlash = (prefixLength > 0 && prefix[prefixLength - 1] == separatorChar);
			if (!haveSlash)
			{
				haveSlash = (suffix.Length > 0 && suffix[0] == separatorChar);
			}
			return haveSlash ? (prefix + suffix) : (prefix + separatorChar + suffix);
		}

		private static void checkURI(java.net.URI uri)
		{
			if (!uri.isAbsolute())
			{
				throw new System.ArgumentException("URI is not absolute: " + uri);
			}
			else
			{
				if (!uri.getRawSchemeSpecificPart().StartsWith("/"))
				{
					throw new System.ArgumentException("URI is not hierarchical: " + uri);
				}
			}
			if (!"file".Equals(uri.getScheme()))
			{
				throw new System.ArgumentException("Expected file scheme in URI: " + uri);
			}
			string rawPath = uri.getRawPath();
			if (rawPath == null || string.IsNullOrEmpty(rawPath))
			{
				throw new System.ArgumentException("Expected non-empty path in URI: " + uri);
			}
			if (uri.getRawAuthority() != null)
			{
				throw new System.ArgumentException("Found authority in URI: " + uri);
			}
			if (uri.getRawQuery() != null)
			{
				throw new System.ArgumentException("Found query in URI: " + uri);
			}
			if (uri.getRawFragment() != null)
			{
				throw new System.ArgumentException("Found fragment in URI: " + uri);
			}
		}

		/// <summary>Returns the file system roots.</summary>
		/// <remarks>
		/// Returns the file system roots. On Android and other Unix systems, there is
		/// a single root,
		/// <code>/</code>
		/// .
		/// </remarks>
		public static java.io.File[] listRoots()
		{
			return new java.io.File[] { new java.io.File("/") };
		}

		/// <summary>
		/// Returns the relative sort ordering of the paths for this file and the
		/// file
		/// <code>another</code>
		/// . The ordering is platform dependent.
		/// </summary>
		/// <param name="another">a file to compare this file to</param>
		/// <returns>
		/// an int determined by comparing the two paths. Possible values are
		/// described in the Comparable interface.
		/// </returns>
		/// <seealso cref="java.lang.Comparable{T}">java.lang.Comparable&lt;T&gt;</seealso>
		[Sharpen.ImplementsInterface(@"java.lang.Comparable")]
		public int compareTo(java.io.File another)
		{
			return string.CompareOrdinal(this.getPath(), another.getPath());
		}

		[Sharpen.Stub]
		public void deleteOnExit()
		{
			throw new System.NotImplementedException();
		}

		/// <summary>
		/// Compares
		/// <code>obj</code>
		/// to this file and returns
		/// <code>true</code>
		/// if they
		/// represent the <em>same</em> object using a path specific comparison.
		/// </summary>
		/// <param name="obj">the object to compare this file with.</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if
		/// <code>obj</code>
		/// is the same as this object,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override bool Equals(object obj)
		{
			if (!(obj is java.io.File))
			{
				return false;
			}
			return path.Equals(((java.io.File)obj).getPath());
		}

		/// <summary>Returns a new file constructed using the absolute path of this file.</summary>
		/// <remarks>
		/// Returns a new file constructed using the absolute path of this file.
		/// Equivalent to
		/// <code>new File(this.getAbsolutePath())</code>
		/// .
		/// </remarks>
		public java.io.File getAbsoluteFile()
		{
			return new java.io.File(getAbsolutePath());
		}

		/// <summary>Returns the canonical path of this file.</summary>
		/// <remarks>
		/// Returns the canonical path of this file.
		/// An <i>absolute</i> path is one that begins at the root of the file system.
		/// A <i>canonical</i> path is an absolute path with symbolic links
		/// and references to "." or ".." resolved. If a path element does not exist (or
		/// is not searchable), there is a conflict between interpreting canonicalization
		/// as a textual operation (where "a/../b" is "b" even if "a" does not exist) .
		/// <p>Most callers should use
		/// <see cref="getAbsolutePath()">getAbsolutePath()</see>
		/// instead. A canonical path is
		/// significantly more expensive to compute, and not generally useful. The primary
		/// use for canonical paths is determining whether two paths point to the same file by
		/// comparing the canonicalized paths.
		/// <p>It can be actively harmful to use a canonical path, specifically because
		/// canonicalization removes symbolic links. It's wise to assume that a symbolic link
		/// is present for a reason, and that that reason is because the link may need to change.
		/// Canonicalization removes this layer of indirection. Good code should generally avoid
		/// caching canonical paths.
		/// </remarks>
		/// <returns>the canonical path of this file.</returns>
		/// <exception cref="IOException">if an I/O error occurs.</exception>
		/// <exception cref="System.IO.IOException"></exception>
		public string getCanonicalPath()
		{
			return realpath(getAbsolutePath());
		}

		/// <summary>TODO: move this stuff to libcore.os.</summary>
		/// <remarks>TODO: move this stuff to libcore.os.</remarks>
		/// <hide></hide>
		[Sharpen.NativeStub]
		private static string realpath(string path)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.NativeStub]
		private static string readlink(string path)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>Returns a new file created using the canonical path of this file.</summary>
		/// <remarks>
		/// Returns a new file created using the canonical path of this file.
		/// Equivalent to
		/// <code>new File(this.getCanonicalPath())</code>
		/// .
		/// </remarks>
		/// <returns>the new file constructed from this file's canonical path.</returns>
		/// <exception cref="IOException">if an I/O error occurs.</exception>
		/// <exception cref="System.IO.IOException"></exception>
		public java.io.File getCanonicalFile()
		{
			return new java.io.File(getCanonicalPath());
		}

		/// <summary>Returns the name of the file or directory represented by this file.</summary>
		/// <remarks>Returns the name of the file or directory represented by this file.</remarks>
		/// <returns>
		/// this file's name or an empty string if there is no name part in
		/// the file's path.
		/// </returns>
		public string getName()
		{
			int separatorIndex = path.LastIndexOf(separator);
			return (separatorIndex < 0) ? path : Sharpen.StringHelper.Substring(path, separatorIndex
				 + 1, path.Length);
		}

		/// <summary>Returns the pathname of the parent of this file.</summary>
		/// <remarks>
		/// Returns the pathname of the parent of this file. This is the path up to
		/// but not including the last name.
		/// <code>null</code>
		/// is returned if there is no
		/// parent.
		/// </remarks>
		/// <returns>
		/// this file's parent pathname or
		/// <code>null</code>
		/// .
		/// </returns>
		public string getParent()
		{
			int length_1 = path.Length;
			int firstInPath = 0;
			if (separatorChar == '\\' && length_1 > 2 && path[1] == ':')
			{
				firstInPath = 2;
			}
			int index = path.LastIndexOf(separatorChar);
			if (index == -1 && firstInPath > 0)
			{
				index = 2;
			}
			if (index == -1 || path[length_1 - 1] == separatorChar)
			{
				return null;
			}
			if (path.IndexOf(separatorChar) == index && path[firstInPath] == separatorChar)
			{
				return Sharpen.StringHelper.Substring(path, 0, index + 1);
			}
			return Sharpen.StringHelper.Substring(path, 0, index);
		}

		/// <summary>Returns a new file made from the pathname of the parent of this file.</summary>
		/// <remarks>
		/// Returns a new file made from the pathname of the parent of this file.
		/// This is the path up to but not including the last name.
		/// <code>null</code>
		/// is
		/// returned when there is no parent.
		/// </remarks>
		/// <returns>
		/// a new file representing this file's parent or
		/// <code>null</code>
		/// .
		/// </returns>
		public java.io.File getParentFile()
		{
			string tempParent = getParent();
			if (tempParent == null)
			{
				return null;
			}
			return new java.io.File(tempParent);
		}

		/// <summary>Returns the path of this file.</summary>
		/// <remarks>Returns the path of this file.</remarks>
		/// <returns>this file's path.</returns>
		public string getPath()
		{
			return path;
		}

		/// <summary>Returns an integer hash code for the receiver.</summary>
		/// <remarks>
		/// Returns an integer hash code for the receiver. Any two objects for which
		/// <code>equals</code>
		/// returns
		/// <code>true</code>
		/// must return the same hash code.
		/// </remarks>
		/// <returns>this files's hash value.</returns>
		/// <seealso cref="Equals(object)">Equals(object)</seealso>
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override int GetHashCode()
		{
			return getPath().GetHashCode() ^ 1234321;
		}

		/// <summary>Indicates if this file's pathname is absolute.</summary>
		/// <remarks>
		/// Indicates if this file's pathname is absolute. Whether a pathname is
		/// absolute is platform specific. On Android, absolute paths start with
		/// the character '/'.
		/// </remarks>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if this file's pathname is absolute,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		/// <seealso cref="getPath()">getPath()</seealso>
		public bool isAbsolute()
		{
			return path.Length > 0 && path[0] == separatorChar;
		}

		// The RI returns false on error. (Even for errors like EACCES or ELOOP.)
		// The RI returns false on error. (Even for errors like EACCES or ELOOP.)
		/// <summary>
		/// Returns whether or not this file is a hidden file as defined by the
		/// operating system.
		/// </summary>
		/// <remarks>
		/// Returns whether or not this file is a hidden file as defined by the
		/// operating system. The notion of "hidden" is system-dependent. For Unix
		/// systems a file is considered hidden if its name starts with a ".". For
		/// Windows systems there is an explicit flag in the file system for this
		/// purpose.
		/// </remarks>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if the file is hidden,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		public bool isHidden()
		{
			if (string.IsNullOrEmpty(path))
			{
				return false;
			}
			return getName().StartsWith(".");
		}

		[Sharpen.Stub]
		public bool setLastModified(long time)
		{
			throw new System.NotImplementedException();
		}

		// The RI returns 0 on error. (Even for errors like EACCES or ELOOP.)
		/// <summary>Equivalent to setWritable(false, false).</summary>
		/// <remarks>Equivalent to setWritable(false, false).</remarks>
		/// <seealso cref="setWritable(bool, bool)">setWritable(bool, bool)</seealso>
		public bool setReadOnly()
		{
			return setWritable(false, false);
		}

		[Sharpen.Stub]
		public bool setExecutable(bool executable, bool ownerOnly)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool setExecutable(bool executable)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool setReadable(bool readable, bool ownerOnly)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool setReadable(bool readable)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool setWritable(bool writable, bool ownerOnly)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool setWritable(bool writable)
		{
			throw new System.NotImplementedException();
		}

		// The RI returns 0 on error. (Even for errors like EACCES or ELOOP.)
		/// <summary>
		/// Returns an array of strings with the file names in the directory
		/// represented by this file.
		/// </summary>
		/// <remarks>
		/// Returns an array of strings with the file names in the directory
		/// represented by this file. The result is
		/// <code>null</code>
		/// if this file is not
		/// a directory.
		/// <p>
		/// The entries
		/// <code>.</code>
		/// and
		/// <code>..</code>
		/// representing the current and parent
		/// directory are not returned as part of the list.
		/// </remarks>
		/// <returns>
		/// an array of strings with file names or
		/// <code>null</code>
		/// .
		/// </returns>
		public string[] list()
		{
			return listImpl(path);
		}

		[Sharpen.NativeStub]
		private static string[] listImpl(string path)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>Gets a list of the files in the directory represented by this file.</summary>
		/// <remarks>
		/// Gets a list of the files in the directory represented by this file. This
		/// list is then filtered through a FilenameFilter and the names of files
		/// with matching names are returned as an array of strings. Returns
		/// <code>null</code>
		/// if this file is not a directory. If
		/// <code>filter</code>
		/// is
		/// <code>null</code>
		/// then all filenames match.
		/// <p>
		/// The entries
		/// <code>.</code>
		/// and
		/// <code>..</code>
		/// representing the current and parent
		/// directories are not returned as part of the list.
		/// </remarks>
		/// <param name="filter">
		/// the filter to match names against, may be
		/// <code>null</code>
		/// .
		/// </param>
		/// <returns>
		/// an array of files or
		/// <code>null</code>
		/// .
		/// </returns>
		public string[] list(java.io.FilenameFilter filter)
		{
			string[] filenames = list();
			if (filter == null || filenames == null)
			{
				return filenames;
			}
			java.util.List<string> result = new java.util.ArrayList<string>(filenames.Length);
			foreach (string filename in filenames)
			{
				if (filter.accept(this, filename))
				{
					result.add(filename);
				}
			}
			return result.toArray(new string[result.size()]);
		}

		/// <summary>
		/// Returns an array of files contained in the directory represented by this
		/// file.
		/// </summary>
		/// <remarks>
		/// Returns an array of files contained in the directory represented by this
		/// file. The result is
		/// <code>null</code>
		/// if this file is not a directory. The
		/// paths of the files in the array are absolute if the path of this file is
		/// absolute, they are relative otherwise.
		/// </remarks>
		/// <returns>
		/// an array of files or
		/// <code>null</code>
		/// .
		/// </returns>
		public java.io.File[] listFiles()
		{
			return filenamesToFiles(list());
		}

		/// <summary>Gets a list of the files in the directory represented by this file.</summary>
		/// <remarks>
		/// Gets a list of the files in the directory represented by this file. This
		/// list is then filtered through a FilenameFilter and files with matching
		/// names are returned as an array of files. Returns
		/// <code>null</code>
		/// if this
		/// file is not a directory. If
		/// <code>filter</code>
		/// is
		/// <code>null</code>
		/// then all
		/// filenames match.
		/// <p>
		/// The entries
		/// <code>.</code>
		/// and
		/// <code>..</code>
		/// representing the current and parent
		/// directories are not returned as part of the list.
		/// </remarks>
		/// <param name="filter">
		/// the filter to match names against, may be
		/// <code>null</code>
		/// .
		/// </param>
		/// <returns>
		/// an array of files or
		/// <code>null</code>
		/// .
		/// </returns>
		public java.io.File[] listFiles(java.io.FilenameFilter filter)
		{
			return filenamesToFiles(list(filter));
		}

		/// <summary>Gets a list of the files in the directory represented by this file.</summary>
		/// <remarks>
		/// Gets a list of the files in the directory represented by this file. This
		/// list is then filtered through a FileFilter and matching files are
		/// returned as an array of files. Returns
		/// <code>null</code>
		/// if this file is not a
		/// directory. If
		/// <code>filter</code>
		/// is
		/// <code>null</code>
		/// then all files match.
		/// <p>
		/// The entries
		/// <code>.</code>
		/// and
		/// <code>..</code>
		/// representing the current and parent
		/// directories are not returned as part of the list.
		/// </remarks>
		/// <param name="filter">
		/// the filter to match names against, may be
		/// <code>null</code>
		/// .
		/// </param>
		/// <returns>
		/// an array of files or
		/// <code>null</code>
		/// .
		/// </returns>
		public java.io.File[] listFiles(java.io.FileFilter filter)
		{
			java.io.File[] files = listFiles();
			if (filter == null || files == null)
			{
				return files;
			}
			java.util.List<java.io.File> result = new java.util.ArrayList<java.io.File>(files
				.Length);
			foreach (java.io.File file in files)
			{
				if (filter.accept(file))
				{
					result.add(file);
				}
			}
			return result.toArray(new java.io.File[result.size()]);
		}

		/// <summary>Converts a String[] containing filenames to a File[].</summary>
		/// <remarks>
		/// Converts a String[] containing filenames to a File[].
		/// Note that the filenames must not contain slashes.
		/// This method is to remove duplication in the implementation
		/// of File.list's overloads.
		/// </remarks>
		private java.io.File[] filenamesToFiles(string[] filenames)
		{
			if (filenames == null)
			{
				return null;
			}
			int count = filenames.Length;
			java.io.File[] result = new java.io.File[count];
			{
				for (int i = 0; i < count; ++i)
				{
					result[i] = new java.io.File(this, filenames[i]);
				}
			}
			return result;
		}

		[Sharpen.Stub]
		public bool mkdir()
		{
			throw new System.NotImplementedException();
		}

		// On Android, we don't want default permissions to allow global access.
		/// <summary>
		/// Creates the directory named by the trailing filename of this file,
		/// including the complete directory path required to create this directory.
		/// </summary>
		/// <remarks>
		/// Creates the directory named by the trailing filename of this file,
		/// including the complete directory path required to create this directory.
		/// <p>Note that this method does <i>not</i> throw
		/// <code>IOException</code>
		/// on failure.
		/// Callers must check the return value.
		/// </remarks>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if the necessary directories have been created,
		/// <code>false</code>
		/// if the target directory already exists or one of
		/// the directories can not be created.
		/// </returns>
		/// <seealso cref="mkdir()">mkdir()</seealso>
		public bool mkdirs()
		{
			if (exists())
			{
				return false;
			}
			if (mkdir())
			{
				return true;
			}
			string parentDir = getParent();
			if (parentDir == null)
			{
				return false;
			}
			return (new java.io.File(parentDir).mkdirs() && mkdir());
		}

		[Sharpen.Stub]
		public bool createNewFile()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.io.File createTempFile(string prefix, string suffix)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.io.File createTempFile(string prefix, string suffix, java.io.File
			 directory)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool renameTo(java.io.File newPath)
		{
			throw new System.NotImplementedException();
		}

		// On Android, we don't want default permissions to allow global access.
		// The file already exists.
		// TODO: should we suppress IOExceptions thrown here?
		// Force a prefix null check first
		/// <summary>
		/// Returns a string containing a concise, human-readable description of this
		/// file.
		/// </summary>
		/// <remarks>
		/// Returns a string containing a concise, human-readable description of this
		/// file.
		/// </remarks>
		/// <returns>a printable representation of this file.</returns>
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			return path;
		}

		/// <summary>Returns a Uniform Resource Identifier for this file.</summary>
		/// <remarks>
		/// Returns a Uniform Resource Identifier for this file. The URI is system
		/// dependent and may not be transferable between different operating / file
		/// systems.
		/// </remarks>
		/// <returns>an URI for this file.</returns>
		public java.net.URI toURI()
		{
			string name = getAbsoluteName();
			try
			{
				if (!name.StartsWith("/"))
				{
					// start with sep.
					return new java.net.URI("file", null, "/" + name, null, null);
				}
				else
				{
					if (name.StartsWith("//"))
					{
						return new java.net.URI("file", string.Empty, name, null);
					}
				}
				// UNC path
				return new java.net.URI("file", null, name, null, null);
			}
			catch (java.net.URISyntaxException)
			{
				// this should never happen
				return null;
			}
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"use toURI() and java.net.URI.toURL() to get correct escaping of illegal characters."
			)]
		public java.net.URL toURL()
		{
			throw new System.NotImplementedException();
		}

		// start with sep.
		// UNC path
		// TODO: is this really necessary, or can it be replaced with getAbsolutePath?
		private string getAbsoluteName()
		{
			java.io.File f = getAbsoluteFile();
			string name = f.getPath();
			if (f.isDirectory() && name[name.Length - 1] != separatorChar)
			{
				// Directories must end with a slash
				name = name + "/";
			}
			if (separatorChar != '/')
			{
				// Must convert slashes.
				name = name.Replace(separatorChar, '/');
			}
			return name;
		}

		/// <exception cref="System.IO.IOException"></exception>
		private void writeObject(java.io.ObjectOutputStream stream)
		{
			stream.defaultWriteObject();
			stream.writeChar(separatorChar);
		}

		/// <exception cref="System.IO.IOException"></exception>
		/// <exception cref="java.lang.ClassNotFoundException"></exception>
		private void readObject(java.io.ObjectInputStream stream)
		{
			stream.defaultReadObject();
			char inSeparator = stream.readChar();
			this.path = fixSlashes(path.Replace(inSeparator, separatorChar));
		}

		[Sharpen.Stub]
		public long getTotalSpace()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public long getUsableSpace()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public long getFreeSpace()
		{
			throw new System.NotImplementedException();
		}
		// total block count * block size in bytes.
		// non-root free block count * block size in bytes.
		// free block count * block size in bytes.
	}
}

using Sharpen;

namespace java.lang
{
	/// <summary>Loads classes and resources from a repository.</summary>
	/// <remarks>
	/// Loads classes and resources from a repository. One or more class loaders are
	/// installed at runtime. These are consulted whenever the runtime system needs a
	/// specific class that is not yet available in-memory. Typically, class loaders
	/// are grouped into a tree where child class loaders delegate all requests to
	/// parent class loaders. Only if the parent class loader cannot satisfy the
	/// request, the child class loader itself tries to handle it.
	/// <p>
	/// <code>ClassLoader</code>
	/// is an abstract class that implements the common
	/// infrastructure required by all class loaders. Android provides several
	/// concrete implementations of the class, with
	/// <see cref="dalvik.system.PathClassLoader">dalvik.system.PathClassLoader</see>
	/// being the one typically used. Other
	/// applications may implement subclasses of
	/// <code>ClassLoader</code>
	/// to provide
	/// special ways for loading classes.
	/// </p>
	/// </remarks>
	/// <seealso cref="Type{T}">Type&lt;T&gt;</seealso>
	[Sharpen.Sharpened]
	public abstract partial class ClassLoader
	{
		/// <summary>The parent ClassLoader.</summary>
		/// <remarks>The parent ClassLoader.</remarks>
		private java.lang.ClassLoader parent;

		/// <summary>The packages known to the class loader.</summary>
		/// <remarks>The packages known to the class loader.</remarks>
		private java.util.Map<string, java.lang.Package> packages = new java.util.HashMap
			<string, java.lang.Package>();

		// String[] paths = classPath.split(":");
		// URL[] urls = new URL[paths.length];
		// for (int i = 0; i < paths.length; i++) {
		// try {
		// urls[i] = new URL("file://" + paths[i]);
		// }
		// catch (Exception ex) {
		// ex.printStackTrace();
		// }
		// }
		//
		// return new java.net.URLClassLoader(urls, null);
		// TODO Make this a java.net.URLClassLoader once we have those?
		/// <summary>Returns the system class loader.</summary>
		/// <remarks>
		/// Returns the system class loader. This is the parent for new
		/// <code>ClassLoader</code>
		/// instances and is typically the class loader used to
		/// start the application.
		/// </remarks>
		public static java.lang.ClassLoader getSystemClassLoader()
		{
			return java.lang.ClassLoader.SystemClassLoader.loader;
		}

		/// <summary>Finds the URL of the resource with the specified name.</summary>
		/// <remarks>
		/// Finds the URL of the resource with the specified name. The system class
		/// loader's resource lookup algorithm is used to find the resource.
		/// </remarks>
		/// <returns>
		/// the
		/// <code>URL</code>
		/// object for the requested resource or
		/// <code>null</code>
		/// if the resource can not be found.
		/// </returns>
		/// <param name="resName">the name of the resource to find.</param>
		/// <seealso cref="Type{T}.getResource(string)">Type&lt;T&gt;.getResource(string)</seealso>
		public static java.net.URL getSystemResource(string resName)
		{
			return java.lang.ClassLoader.SystemClassLoader.loader.getResource(resName);
		}

		/// <summary>Returns an enumeration of URLs for the resource with the specified name.
		/// 	</summary>
		/// <remarks>
		/// Returns an enumeration of URLs for the resource with the specified name.
		/// The system class loader's resource lookup algorithm is used to find the
		/// resource.
		/// </remarks>
		/// <returns>
		/// an enumeration of
		/// <code>URL</code>
		/// objects containing the requested
		/// resources.
		/// </returns>
		/// <param name="resName">the name of the resource to find.</param>
		/// <exception cref="System.IO.IOException">if an I/O error occurs.</exception>
		public static java.util.Enumeration<java.net.URL> getSystemResources(string resName
			)
		{
			return java.lang.ClassLoader.SystemClassLoader.loader.getResources(resName);
		}

		/// <summary>Returns a stream for the resource with the specified name.</summary>
		/// <remarks>
		/// Returns a stream for the resource with the specified name. The system
		/// class loader's resource lookup algorithm is used to find the resource.
		/// Basically, the contents of the java.class.path are searched in order,
		/// looking for a path which matches the specified resource.
		/// </remarks>
		/// <returns>
		/// a stream for the resource or
		/// <code>null</code>
		/// .
		/// </returns>
		/// <param name="resName">the name of the resource to find.</param>
		/// <seealso cref="Type{T}.getResourceAsStream(string)">Type&lt;T&gt;.getResourceAsStream(string)
		/// 	</seealso>
		public static java.io.InputStream getSystemResourceAsStream(string resName)
		{
			return java.lang.ClassLoader.SystemClassLoader.loader.getResourceAsStream(resName
				);
		}

		/// <summary>
		/// Constructs a new instance of this class with the system class loader as
		/// its parent.
		/// </summary>
		/// <remarks>
		/// Constructs a new instance of this class with the system class loader as
		/// its parent.
		/// </remarks>
		protected internal ClassLoader() : this(getSystemClassLoader(), false)
		{
		}

		/// <summary>
		/// Constructs a new instance of this class with the specified class loader
		/// as its parent.
		/// </summary>
		/// <remarks>
		/// Constructs a new instance of this class with the specified class loader
		/// as its parent.
		/// </remarks>
		/// <param name="parentLoader">
		/// The
		/// <code>ClassLoader</code>
		/// to use as the new class loader's
		/// parent.
		/// </param>
		protected internal ClassLoader(java.lang.ClassLoader parentLoader) : this(parentLoader
			, false)
		{
		}

		internal ClassLoader(java.lang.ClassLoader parentLoader, bool nullAllowed)
		{
			if (parentLoader == null && !nullAllowed)
			{
				throw new System.ArgumentNullException("Parent ClassLoader may not be null");
			}
			parent = parentLoader;
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"Use defineClass(string, byte[], int, int)")]
		protected internal System.Type defineClass(byte[] classRep, int offset, int length
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal System.Type defineClass(string className, byte[] classRep, int
			 offset, int length)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal System.Type defineClass(string className, byte[] classRep, int
			 offset, int length, java.security.ProtectionDomain protectionDomain)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal System.Type defineClass(string name, java.nio.ByteBuffer b, java.security.ProtectionDomain
			 protectionDomain)
		{
			throw new System.NotImplementedException();
		}

		// TODO Define a default ProtectionDomain on first use
		/// <summary>
		/// Overridden by subclasses, throws a
		/// <code>ClassNotFoundException</code>
		/// by
		/// default. This method is called by
		/// <code>loadClass</code>
		/// after the parent
		/// <code>ClassLoader</code>
		/// has failed to find a loaded class of the same name.
		/// </summary>
		/// <param name="className">the name of the class to look for.</param>
		/// <returns>
		/// the
		/// <code>Class</code>
		/// object that is found.
		/// </returns>
		/// <exception cref="ClassNotFoundException">if the class cannot be found.</exception>
		/// <exception cref="java.lang.ClassNotFoundException"></exception>
		protected internal virtual System.Type findClass(string className)
		{
			throw new java.lang.ClassNotFoundException(className);
		}

		/// <summary>Returns this class loader's parent.</summary>
		/// <remarks>Returns this class loader's parent.</remarks>
		/// <returns>
		/// this class loader's parent or
		/// <code>null</code>
		/// .
		/// </returns>
		public java.lang.ClassLoader getParent()
		{
			return parent;
		}

		/// <summary>Returns the URL of the resource with the specified name.</summary>
		/// <remarks>
		/// Returns the URL of the resource with the specified name. This
		/// implementation first tries to use the parent class loader to find the
		/// resource; if this fails then
		/// <see cref="findResource(string)">findResource(string)</see>
		/// is called to
		/// find the requested resource.
		/// </remarks>
		/// <param name="resName">the name of the resource to find.</param>
		/// <returns>
		/// the
		/// <code>URL</code>
		/// object for the requested resource or
		/// <code>null</code>
		/// if the resource can not be found
		/// </returns>
		/// <seealso cref="Type{T}.getResource(string)">Type&lt;T&gt;.getResource(string)</seealso>
		public virtual java.net.URL getResource(string resName)
		{
			java.net.URL resource = parent.getResource(resName);
			if (resource == null)
			{
				resource = findResource(resName);
			}
			return resource;
		}

		[Sharpen.Stub]
		public virtual java.util.Enumeration<java.net.URL> getResources(string resName)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual java.io.InputStream getResourceAsStream(string resName)
		{
			throw new System.NotImplementedException();
		}

		// Don't want to see the exception.
		/// <summary>Loads the class with the specified name.</summary>
		/// <remarks>
		/// Loads the class with the specified name. Invoking this method is
		/// equivalent to calling
		/// <code>loadClass(className, false)</code>
		/// .
		/// <p>
		/// <strong>Note:</strong> In the Android reference implementation, the
		/// second parameter of
		/// <see cref="loadClass(string, bool)">loadClass(string, bool)</see>
		/// is ignored
		/// anyway.
		/// </p>
		/// </remarks>
		/// <returns>
		/// the
		/// <code>Class</code>
		/// object.
		/// </returns>
		/// <param name="className">the name of the class to look for.</param>
		/// <exception cref="ClassNotFoundException">if the class can not be found.</exception>
		/// <exception cref="java.lang.ClassNotFoundException"></exception>
		public virtual System.Type loadClass(string className)
		{
			return loadClass(className, false);
		}

		/// <summary>
		/// Loads the class with the specified name, optionally linking it after
		/// loading.
		/// </summary>
		/// <remarks>
		/// Loads the class with the specified name, optionally linking it after
		/// loading. The following steps are performed:
		/// <ol>
		/// <li> Call
		/// <see cref="findLoadedClass(string)">findLoadedClass(string)</see>
		/// to determine if the requested
		/// class has already been loaded.</li>
		/// <li>If the class has not yet been loaded: Invoke this method on the
		/// parent class loader.</li>
		/// <li>If the class has still not been loaded: Call
		/// <see cref="findClass(string)">findClass(string)</see>
		/// to find the class.</li>
		/// </ol>
		/// <p>
		/// <strong>Note:</strong> In the Android reference implementation, the
		/// <code>resolve</code>
		/// parameter is ignored; classes are never linked.
		/// </p>
		/// </remarks>
		/// <returns>
		/// the
		/// <code>Class</code>
		/// object.
		/// </returns>
		/// <param name="className">the name of the class to look for.</param>
		/// <param name="resolve">
		/// Indicates if the class should be resolved after loading. This
		/// parameter is ignored on the Android reference implementation;
		/// classes are not resolved.
		/// </param>
		/// <exception cref="ClassNotFoundException">if the class can not be found.</exception>
		/// <exception cref="java.lang.ClassNotFoundException"></exception>
		protected internal virtual System.Type loadClass(string className, bool resolve)
		{
			System.Type clazz = findLoadedClass(className);
			if (clazz == null)
			{
				try
				{
					clazz = parent.loadClass(className, false);
				}
				catch (java.lang.ClassNotFoundException)
				{
				}
				// Don't want to see this.
				if (clazz == null)
				{
					clazz = findClass(className);
				}
			}
			return clazz;
		}

		/// <summary>Forces a class to be linked (initialized).</summary>
		/// <remarks>
		/// Forces a class to be linked (initialized). If the class has already been
		/// linked this operation has no effect.
		/// <p>
		/// <strong>Note:</strong> In the Android reference implementation, this
		/// method has no effect.
		/// </p>
		/// </remarks>
		/// <param name="clazz">the class to link.</param>
		protected internal void resolveClass<_T0>()
		{
			System.Type clazz = typeof(_T0);
		}

		// no-op, doesn't make sense on android.
		/// <summary>Finds the URL of the resource with the specified name.</summary>
		/// <remarks>
		/// Finds the URL of the resource with the specified name. This
		/// implementation just returns
		/// <code>null</code>
		/// ; it should be overridden in
		/// subclasses.
		/// </remarks>
		/// <param name="resName">the name of the resource to find.</param>
		/// <returns>
		/// the
		/// <code>URL</code>
		/// object for the requested resource.
		/// </returns>
		protected internal virtual java.net.URL findResource(string resName)
		{
			return null;
		}

		[Sharpen.Stub]
		protected internal virtual java.util.Enumeration<java.net.URL> findResources(string
			 resName)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>
		/// Returns the absolute path of the native library with the specified name,
		/// or
		/// <code>null</code>
		/// . If this method returns
		/// <code>null</code>
		/// then the virtual
		/// machine searches the directories specified by the system property
		/// "java.library.path".
		/// <p>
		/// This implementation always returns
		/// <code>null</code>
		/// .
		/// </p>
		/// </summary>
		/// <param name="libName">the name of the library to find.</param>
		/// <returns>the absolute path of the library.</returns>
		protected internal virtual string findLibrary(string libName)
		{
			return null;
		}

		[Sharpen.Stub]
		protected internal virtual java.lang.Package getPackage(string name)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual java.lang.Package[] getPackages()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual java.lang.Package definePackage(string name, string specTitle
			, string specVersion, string specVendor, string implTitle, string implVersion, string
			 implVendor, java.net.URL sealBase)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>Sets the signers of the specified class.</summary>
		/// <remarks>
		/// Sets the signers of the specified class. This implementation does
		/// nothing.
		/// </remarks>
		/// <param name="c">
		/// the
		/// <code>Class</code>
		/// object for which to set the signers.
		/// </param>
		/// <param name="signers">
		/// the signers for
		/// <code>c</code>
		/// .
		/// </param>
		protected internal void setSigners<_T0>(object[] signers)
		{
			System.Type c = typeof(_T0);
		}

		/// <summary>Sets the assertion status of the class with the specified name.</summary>
		/// <remarks>
		/// Sets the assertion status of the class with the specified name.
		/// <p>
		/// <strong>Note: </strong>This method does nothing in the Android reference
		/// implementation.
		/// </p>
		/// </remarks>
		/// <param name="cname">the name of the class for which to set the assertion status.</param>
		/// <param name="enable">the new assertion status.</param>
		public virtual void setClassAssertionStatus(string cname, bool enable)
		{
		}

		/// <summary>Sets the assertion status of the package with the specified name.</summary>
		/// <remarks>
		/// Sets the assertion status of the package with the specified name.
		/// <p>
		/// <strong>Note: </strong>This method does nothing in the Android reference
		/// implementation.
		/// </p>
		/// </remarks>
		/// <param name="pname">the name of the package for which to set the assertion status.
		/// 	</param>
		/// <param name="enable">the new assertion status.</param>
		public virtual void setPackageAssertionStatus(string pname, bool enable)
		{
		}

		/// <summary>Sets the default assertion status for this class loader.</summary>
		/// <remarks>
		/// Sets the default assertion status for this class loader.
		/// <p>
		/// <strong>Note: </strong>This method does nothing in the Android reference
		/// implementation.
		/// </p>
		/// </remarks>
		/// <param name="enable">the new assertion status.</param>
		public virtual void setDefaultAssertionStatus(bool enable)
		{
		}

		/// <summary>
		/// Sets the default assertion status for this class loader to
		/// <code>false</code>
		/// and removes any package default and class assertion status settings.
		/// <p>
		/// <strong>Note:</strong> This method does nothing in the Android reference
		/// implementation.
		/// </p>
		/// </summary>
		public virtual void clearAssertionStatus()
		{
		}
	}

	[Sharpen.NakedStub]
	public class TwoEnumerationsInOne
	{
	}

	[Sharpen.NakedStub]
	public class BootClassLoader
	{
	}
}

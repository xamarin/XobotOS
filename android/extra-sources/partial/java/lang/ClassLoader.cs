using System;
using System.Reflection;

namespace java.lang
{
	partial class ClassLoader
	{
		/// <summary>
		/// The 'System' ClassLoader - the one that is responsible for loading
		/// classes from the classpath.
		/// </summary>
		/// <remarks>
		/// The 'System' ClassLoader - the one that is responsible for loading
		/// classes from the classpath. It is not equal to the bootstrap class loader -
		/// that one handles the built-in classes.
		/// Because of a potential class initialization race between ClassLoader and
		/// java.lang.System, reproducible when using JDWP with "suspend=y", we defer
		/// creation of the system class loader until first use. We use a static
		/// inner class to get synchronization at init time without having to sync on
		/// every access.
		/// </remarks>
		/// <seealso cref="ClassLoader.getSystemClassLoader()">ClassLoader.getSystemClassLoader()
		/// 	</seealso>
		private class SystemClassLoader : ClassLoader
		{
			public static readonly ClassLoader loader = new SystemClassLoader ();

			private SystemClassLoader () : base (null, true)
			{
			}

			protected internal override Type loadClass (string className, bool resolve)
			{
				return findClass (className);
			}

			protected internal override Type findClass (string className)
			{
				Type type = Type.GetType (className);
				if (type != null)
					return type;

				type = Assembly.GetCallingAssembly ().GetType (className);
				if (type != null)
					return type;

				string msg = string.Format ("Class '{0}' not found.", className);
				throw new ClassNotFoundException (msg);
			}
		}

		/// <summary>
		/// Returns the class with the specified name if it has already been loaded
		/// by the VM or
		/// <code>null</code>
		/// if it has not yet been loaded.
		/// </summary>
		/// <param name="className">the name of the class to look for.</param>
		/// <returns>
		/// the
		/// <code>Class</code>
		/// object or
		/// <code>null</code>
		/// if the requested class
		/// has not been loaded.
		/// </returns>
		internal Type findLoadedClass (string className)
		{
			return findClass (className);
		}

		/// <summary>
		/// Finds the class with the specified name, loading it using the system
		/// class loader if necessary.
		/// </summary>
		/// <remarks>
		/// Finds the class with the specified name, loading it using the system
		/// class loader if necessary.
		/// </remarks>
		/// <param name="className">the name of the class to look for.</param>
		/// <returns>
		/// the
		/// <code>Class</code>
		/// object with the requested
		/// <code>className</code>
		/// .
		/// </returns>
		/// <exception cref="TypeLoadException">if the class can not be found.</exception>
		/// <exception cref="System.TypeLoadException"></exception>
		internal Type findSystemClass (string className)
		{
			return findLoadedClass (className);
		}

	}
}


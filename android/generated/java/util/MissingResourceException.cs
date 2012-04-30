using Sharpen;

namespace java.util
{
	/// <summary>
	/// A
	/// <code>MissingResourceException</code>
	/// is thrown by ResourceBundle when a
	/// resource bundle cannot be found or a resource is missing from a resource
	/// bundle.
	/// </summary>
	/// <seealso cref="ResourceBundle">ResourceBundle</seealso>
	/// <seealso cref="java.lang.RuntimeException">java.lang.RuntimeException</seealso>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class MissingResourceException : java.lang.RuntimeException
	{
		internal const long serialVersionUID = -4876345176062000401L;

		internal string className;

		internal string key;

		/// <summary>
		/// Constructs a new
		/// <code>MissingResourceException</code>
		/// with the stack trace,
		/// message, the class name of the resource bundle and the name of the
		/// missing resource filled in.
		/// </summary>
		/// <param name="detailMessage">the detail message for the exception.</param>
		/// <param name="className">the class name of the resource bundle.</param>
		/// <param name="resourceName">the name of the missing resource.</param>
		public MissingResourceException(string detailMessage, string className, string resourceName
			) : base(detailMessage)
		{
			this.className = className;
			key = resourceName;
		}

		/// <summary>
		/// Returns the class name of the resource bundle from which a resource could
		/// not be found, or in the case of a missing resource, the name of the
		/// missing resource bundle.
		/// </summary>
		/// <remarks>
		/// Returns the class name of the resource bundle from which a resource could
		/// not be found, or in the case of a missing resource, the name of the
		/// missing resource bundle.
		/// </remarks>
		/// <returns>the class name of the resource bundle.</returns>
		public virtual string getClassName()
		{
			return className;
		}

		/// <summary>
		/// Returns the name of the missing resource, or an empty string if the
		/// resource bundle is missing.
		/// </summary>
		/// <remarks>
		/// Returns the name of the missing resource, or an empty string if the
		/// resource bundle is missing.
		/// </remarks>
		/// <returns>the name of the missing resource.</returns>
		public virtual string getKey()
		{
			return key;
		}
	}
}

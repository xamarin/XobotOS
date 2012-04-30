using Sharpen;
using System;

namespace java.lang
{
	/// <summary>
	/// <code>RuntimeException</code>
	/// is the superclass of all classes that represent
	/// exceptional conditions which occur as a result of executing an application in
	/// the VM. Unlike checked exceptions (exceptions where the type
	/// doesn't extend
	/// <code>RuntimeException</code>
	/// or
	/// <see cref="Exception">Exception</see>
	/// ), the compiler does
	/// not require code to handle runtime exceptions.
	/// </summary>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class RuntimeException : Exception
	{
		private const long serialVersionUID = -7034897190745766939L;

		/// <summary>
		/// Constructs a new
		/// <code>RuntimeException</code>
		/// that includes the current stack
		/// trace.
		/// </summary>
		public RuntimeException()
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>RuntimeException</code>
		/// with the current stack trace
		/// and the specified detail message.
		/// </summary>
		/// <param name="detailMessage">the detail message for this exception.</param>
		public RuntimeException(string detailMessage) : base(detailMessage)
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>RuntimeException</code>
		/// with the current stack trace,
		/// the specified detail message and the specified cause.
		/// </summary>
		/// <param name="detailMessage">the detail message for this exception.</param>
		/// <param name="throwable">the cause of this exception.</param>
		public RuntimeException(string detailMessage, Exception throwable) : base(
			detailMessage, throwable)
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>RuntimeException</code>
		/// with the current stack trace
		/// and the specified cause.
		/// </summary>
		/// <param name="throwable">the cause of this exception.</param>
		public RuntimeException(Exception throwable) : base("Runtime Exception", throwable)
		{
		}

		Exception inner;

		new public Exception InnerException {
			get {
				if (inner != null)
					return inner;
				return base.InnerException;
			}

			internal set {
				inner = value;
			}
		}
	}
}

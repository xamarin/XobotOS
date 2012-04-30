using Sharpen;

namespace java.net
{
	/// <summary>
	/// A
	/// <code>URISyntaxException</code>
	/// will be thrown if some information could not be parsed
	/// while creating a URI.
	/// </summary>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class URISyntaxException : System.Exception
	{
		internal const long serialVersionUID = 2137979680897488891L;

		private string input;

		private int index;

		/// <summary>
		/// Constructs a new
		/// <code>URISyntaxException</code>
		/// instance containing the
		/// string that caused the exception, a description of the problem and the
		/// index at which the error occurred.
		/// </summary>
		/// <param name="input">the string that caused the exception.</param>
		/// <param name="reason">the reason why the exception occurred.</param>
		/// <param name="index">the position where the exception occurred.</param>
		/// <exception cref="System.ArgumentNullException">
		/// if one of the arguments
		/// <code>input</code>
		/// or
		/// <code>reason</code>
		/// is
		/// <code>null</code>
		/// .
		/// </exception>
		/// <exception cref="System.ArgumentException">
		/// if the value for
		/// <code>index</code>
		/// is lesser than
		/// <code>-1</code>
		/// .
		/// </exception>
		public URISyntaxException(string input, string reason, int index) : base(reason)
		{
			if (input == null || reason == null)
			{
				throw new System.ArgumentNullException();
			}
			if (index < -1)
			{
				throw new System.ArgumentException();
			}
			this.input = input;
			this.index = index;
		}

		/// <summary>
		/// Constructs a new
		/// <code>URISyntaxException</code>
		/// instance containing the
		/// string that caused the exception and a description of the problem.
		/// </summary>
		/// <param name="input">the string that caused the exception.</param>
		/// <param name="reason">the reason why the exception occurred.</param>
		/// <exception cref="System.ArgumentNullException">
		/// if one of the arguments
		/// <code>input</code>
		/// or
		/// <code>reason</code>
		/// is
		/// <code>null</code>
		/// .
		/// </exception>
		public URISyntaxException(string input, string reason) : base(reason)
		{
			if (input == null || reason == null)
			{
				throw new System.ArgumentNullException();
			}
			this.input = input;
			index = -1;
		}

		/// <summary>
		/// Gets the index at which the syntax error was found or
		/// <code>-1</code>
		/// if the
		/// index is unknown/unavailable.
		/// </summary>
		/// <returns>the index of the syntax error.</returns>
		public virtual int getIndex()
		{
			return index;
		}

		/// <summary>Gets a description of the syntax error.</summary>
		/// <remarks>Gets a description of the syntax error.</remarks>
		/// <returns>the string describing the syntax error.</returns>
		public virtual string getReason()
		{
			return base.Message;
		}

		/// <summary>Gets the initial string that contains an invalid syntax.</summary>
		/// <remarks>Gets the initial string that contains an invalid syntax.</remarks>
		/// <returns>the string that caused the exception.</returns>
		public virtual string getInput()
		{
			return input;
		}

		/// <summary>
		/// Gets a description of the exception, including the reason, the string
		/// that caused the syntax error and the position of the syntax error if
		/// available.
		/// </summary>
		/// <remarks>
		/// Gets a description of the exception, including the reason, the string
		/// that caused the syntax error and the position of the syntax error if
		/// available.
		/// </remarks>
		/// <returns>a sting containing information about the exception.</returns>
		/// <seealso cref="System.Exception.Message()">System.Exception.Message()</seealso>
		public override string Message
		{
			get
			{
				string reason = base.Message;
				if (index != -1)
				{
					return reason + " at index " + index + ": " + input;
				}
				return reason + ": " + input;
			}
		}
	}
}

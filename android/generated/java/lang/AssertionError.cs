using Sharpen;

namespace java.lang
{
	/// <summary>Thrown when an assertion has failed.</summary>
	/// <remarks>Thrown when an assertion has failed.</remarks>
	/// <since>1.4</since>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class AssertionError : System.Exception
	{
		internal const long serialVersionUID = -5013299493970297370L;

		/// <summary>
		/// Constructs a new
		/// <code>AssertionError</code>
		/// with no message.
		/// </summary>
		public AssertionError()
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>AssertionError</code>
		/// with the given detail message and cause.
		/// </summary>
		/// <since>1.7</since>
		/// <hide>1.7</hide>
		public AssertionError(string detailMessage, System.Exception cause) : base(detailMessage
			, cause)
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>AssertionError</code>
		/// with a message based on calling
		/// <see cref="Sharpen.StringHelper.GetValueOf(object)">Sharpen.StringHelper.GetValueOf(object)
		/// 	</see>
		/// with the specified object. If the object
		/// is an instance of
		/// <see cref="Exception">Exception</see>
		/// , then it also becomes the cause of
		/// this error.
		/// </summary>
		/// <param name="detailMessage">
		/// the object to be converted into the detail message and
		/// optionally the cause.
		/// </param>
		public AssertionError(object detailMessage) : base(Sharpen.StringHelper.GetValueOf
			(detailMessage), (detailMessage is System.Exception ? (System.Exception)detailMessage
			 : null))
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>AssertionError</code>
		/// with a message based on calling
		/// <see cref="string.ToString(bool)">string.ToString(bool)</see>
		/// with the specified boolean value.
		/// </summary>
		/// <param name="detailMessage">the value to be converted into the message.</param>
		public AssertionError(bool detailMessage) : this(detailMessage.ToString())
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>AssertionError</code>
		/// with a message based on calling
		/// <see cref="string.ToString(char)">string.ToString(char)</see>
		/// with the specified character value.
		/// </summary>
		/// <param name="detailMessage">the value to be converted into the message.</param>
		public AssertionError(char detailMessage) : this(detailMessage.ToString())
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>AssertionError</code>
		/// with a message based on calling
		/// <see cref="string.ToString(int)">string.ToString(int)</see>
		/// with the specified integer value.
		/// </summary>
		/// <param name="detailMessage">the value to be converted into the message.</param>
		public AssertionError(int detailMessage) : this(System.Convert.ToString(detailMessage
			))
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>AssertionError</code>
		/// with a message based on calling
		/// <see cref="string.ToString(long)">string.ToString(long)</see>
		/// with the specified long value.
		/// </summary>
		/// <param name="detailMessage">the value to be converted into the message.</param>
		public AssertionError(long detailMessage) : this(System.Convert.ToString(detailMessage
			))
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>AssertionError</code>
		/// with a message based on calling
		/// <see cref="string.ToString(float)">string.ToString(float)</see>
		/// with the specified float value.
		/// </summary>
		/// <param name="detailMessage">the value to be converted into the message.</param>
		public AssertionError(float detailMessage) : this(System.Convert.ToString(detailMessage
			))
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>AssertionError</code>
		/// with a message based on calling
		/// <see cref="string.ToString(double)">string.ToString(double)</see>
		/// with the specified double value.
		/// </summary>
		/// <param name="detailMessage">the value to be converted into the message.</param>
		public AssertionError(double detailMessage) : this(System.Convert.ToString(detailMessage
			))
		{
		}
	}
}

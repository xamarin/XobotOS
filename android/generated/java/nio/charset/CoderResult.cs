using Sharpen;

namespace java.nio.charset
{
	/// <summary>Used to indicate the result of encoding/decoding.</summary>
	/// <remarks>
	/// Used to indicate the result of encoding/decoding. There are four types of
	/// results:
	/// <ol>
	/// <li>UNDERFLOW indicates that all input has been processed but more input is
	/// required. It is represented by the unique object
	/// <code>CoderResult.UNDERFLOW</code>.
	/// <li>OVERFLOW indicates an insufficient output buffer size. It is represented
	/// by the unique object <code>CoderResult.OVERFLOW</code>.
	/// <li>A malformed-input error indicates that an unrecognizable sequence of
	/// input units has been encountered. Get an instance of this type of result by
	/// calling <code>CoderResult.malformedForLength(int)</code> with the length of
	/// the malformed-input.
	/// <li>An unmappable-character error indicates that a sequence of input units
	/// can not be mapped to the output charset. Get an instance of this type of
	/// result by calling <code>CoderResult.unmappableForLength(int)</code> with
	/// the input sequence size indicating the identity of the unmappable character.
	/// </ol>
	/// </remarks>
	[Sharpen.Sharpened]
	public class CoderResult
	{
		internal const int TYPE_UNDERFLOW = 1;

		internal const int TYPE_OVERFLOW = 2;

		internal const int TYPE_MALFORMED_INPUT = 3;

		internal const int TYPE_UNMAPPABLE_CHAR = 4;

		/// <summary>
		/// Result object indicating that there is insufficient data in the
		/// encoding/decoding buffer or that additional data is required.
		/// </summary>
		/// <remarks>
		/// Result object indicating that there is insufficient data in the
		/// encoding/decoding buffer or that additional data is required.
		/// </remarks>
		public static readonly java.nio.charset.CoderResult UNDERFLOW = new java.nio.charset.CoderResult
			(TYPE_UNDERFLOW, 0);

		/// <summary>
		/// Result object used to indicate that the output buffer does not have
		/// enough space available to store the result of the encoding/decoding.
		/// </summary>
		/// <remarks>
		/// Result object used to indicate that the output buffer does not have
		/// enough space available to store the result of the encoding/decoding.
		/// </remarks>
		public static readonly java.nio.charset.CoderResult OVERFLOW = new java.nio.charset.CoderResult
			(TYPE_OVERFLOW, 0);

		private static java.util.WeakHashMap<int, java.nio.charset.CoderResult> _malformedErrors
			 = new java.util.WeakHashMap<int, java.nio.charset.CoderResult>();

		private static java.util.WeakHashMap<int, java.nio.charset.CoderResult> _unmappableErrors
			 = new java.util.WeakHashMap<int, java.nio.charset.CoderResult>();

		private readonly int type;

		private readonly int _length;

		/// <summary>Constructs a <code>CoderResult</code> object with its text description.</summary>
		/// <remarks>Constructs a <code>CoderResult</code> object with its text description.</remarks>
		/// <param name="type">the type of this result</param>
		/// <param name="length">the length of the erroneous input</param>
		private CoderResult(int type, int length_1)
		{
			// indicating underflow error type
			// indicating overflow error type
			// indicating malformed-input error type
			// indicating unmappable character error type
			// the type of this result
			// the length of the erroneous input
			this.type = type;
			this._length = length_1;
		}

		/// <summary>
		/// Gets a <code>CoderResult</code> object indicating a malformed-input
		/// error.
		/// </summary>
		/// <remarks>
		/// Gets a <code>CoderResult</code> object indicating a malformed-input
		/// error.
		/// </remarks>
		/// <param name="length">the length of the malformed-input.</param>
		/// <returns>
		/// a <code>CoderResult</code> object indicating a malformed-input
		/// error.
		/// </returns>
		/// <exception cref="System.ArgumentException">if <code>length</code> is non-positive.
		/// 	</exception>
		public static java.nio.charset.CoderResult malformedForLength(int length_1)
		{
			lock (typeof(CoderResult))
			{
				if (length_1 > 0)
				{
					int key = Sharpen.Util.IntValueOf(length_1);
					lock (_malformedErrors)
					{
						java.nio.charset.CoderResult r = _malformedErrors.get(key);
						if (r == null)
						{
							r = new java.nio.charset.CoderResult(TYPE_MALFORMED_INPUT, length_1);
							_malformedErrors.put(key, r);
						}
						return r;
					}
				}
				throw new System.ArgumentException("Length must be greater than 0; was " + length_1
					);
			}
		}

		/// <summary>
		/// Gets a <code>CoderResult</code> object indicating an unmappable
		/// character error.
		/// </summary>
		/// <remarks>
		/// Gets a <code>CoderResult</code> object indicating an unmappable
		/// character error.
		/// </remarks>
		/// <param name="length">
		/// the length of the input unit sequence denoting the unmappable
		/// character.
		/// </param>
		/// <returns>
		/// a <code>CoderResult</code> object indicating an unmappable
		/// character error.
		/// </returns>
		/// <exception cref="System.ArgumentException">if <code>length</code> is non-positive.
		/// 	</exception>
		public static java.nio.charset.CoderResult unmappableForLength(int length_1)
		{
			lock (typeof(CoderResult))
			{
				if (length_1 > 0)
				{
					int key = Sharpen.Util.IntValueOf(length_1);
					lock (_unmappableErrors)
					{
						java.nio.charset.CoderResult r = _unmappableErrors.get(key);
						if (r == null)
						{
							r = new java.nio.charset.CoderResult(TYPE_UNMAPPABLE_CHAR, length_1);
							_unmappableErrors.put(key, r);
						}
						return r;
					}
				}
				throw new System.ArgumentException("Length must be greater than 0; was " + length_1
					);
			}
		}

		/// <summary>Returns true if this result is an underflow condition.</summary>
		/// <remarks>Returns true if this result is an underflow condition.</remarks>
		/// <returns>true if an underflow, otherwise false.</returns>
		public virtual bool isUnderflow()
		{
			return this.type == TYPE_UNDERFLOW;
		}

		/// <summary>
		/// Returns true if this result represents a malformed-input error or an
		/// unmappable-character error.
		/// </summary>
		/// <remarks>
		/// Returns true if this result represents a malformed-input error or an
		/// unmappable-character error.
		/// </remarks>
		/// <returns>
		/// true if this is a malformed-input error or an
		/// unmappable-character error, otherwise false.
		/// </returns>
		public virtual bool isError()
		{
			return this.type == TYPE_MALFORMED_INPUT || this.type == TYPE_UNMAPPABLE_CHAR;
		}

		/// <summary>Returns true if this result represents a malformed-input error.</summary>
		/// <remarks>Returns true if this result represents a malformed-input error.</remarks>
		/// <returns>true if this is a malformed-input error, otherwise false.</returns>
		public virtual bool isMalformed()
		{
			return this.type == TYPE_MALFORMED_INPUT;
		}

		/// <summary>Returns true if this result is an overflow condition.</summary>
		/// <remarks>Returns true if this result is an overflow condition.</remarks>
		/// <returns>true if this is an overflow, otherwise false.</returns>
		public virtual bool isOverflow()
		{
			return this.type == TYPE_OVERFLOW;
		}

		/// <summary>Returns true if this result represents an unmappable-character error.</summary>
		/// <remarks>Returns true if this result represents an unmappable-character error.</remarks>
		/// <returns>true if this is an unmappable-character error, otherwise false.</returns>
		public virtual bool isUnmappable()
		{
			return this.type == TYPE_UNMAPPABLE_CHAR;
		}

		/// <summary>Gets the length of the erroneous input.</summary>
		/// <remarks>
		/// Gets the length of the erroneous input. The length is only meaningful to
		/// a malformed-input error or an unmappable character error.
		/// </remarks>
		/// <returns>the length, as an integer, of this object's erroneous input.</returns>
		/// <exception cref="System.NotSupportedException">if this result is an overflow or underflow.
		/// 	</exception>
		public virtual int length()
		{
			if (this.type == TYPE_MALFORMED_INPUT || this.type == TYPE_UNMAPPABLE_CHAR)
			{
				return this._length;
			}
			throw new System.NotSupportedException("length meaningless for " + ToString());
		}

		/// <summary>Throws an exception corresponding to this coder result.</summary>
		/// <remarks>Throws an exception corresponding to this coder result.</remarks>
		/// <exception cref="java.nio.BufferUnderflowException">in case this is an underflow.
		/// 	</exception>
		/// <exception cref="java.nio.BufferOverflowException">in case this is an overflow.</exception>
		/// <exception cref="UnmappableCharacterException">in case this is an unmappable-character error.
		/// 	</exception>
		/// <exception cref="MalformedInputException">in case this is a malformed-input error.
		/// 	</exception>
		/// <exception cref="CharacterCodingException">the default exception.</exception>
		/// <exception cref="java.nio.charset.UnmappableCharacterException"></exception>
		/// <exception cref="java.nio.charset.MalformedInputException"></exception>
		/// <exception cref="java.nio.charset.CharacterCodingException"></exception>
		public virtual void throwException()
		{
			switch (this.type)
			{
				case TYPE_UNDERFLOW:
				{
					throw new java.nio.BufferUnderflowException();
				}

				case TYPE_OVERFLOW:
				{
					throw new java.nio.BufferOverflowException();
				}

				case TYPE_UNMAPPABLE_CHAR:
				{
					throw new java.nio.charset.UnmappableCharacterException(this._length);
				}

				case TYPE_MALFORMED_INPUT:
				{
					throw new java.nio.charset.MalformedInputException(this._length);
				}

				default:
				{
					throw new java.nio.charset.CharacterCodingException();
				}
			}
		}

		/// <summary>Returns a text description of this result.</summary>
		/// <remarks>Returns a text description of this result.</remarks>
		/// <returns>a text description of this result.</returns>
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			string dsc = null;
			switch (this.type)
			{
				case TYPE_UNDERFLOW:
				{
					dsc = "UNDERFLOW error";
					break;
				}

				case TYPE_OVERFLOW:
				{
					dsc = "OVERFLOW error";
					break;
				}

				case TYPE_UNMAPPABLE_CHAR:
				{
					dsc = "Unmappable-character error with erroneous input length " + this._length;
					break;
				}

				case TYPE_MALFORMED_INPUT:
				{
					dsc = "Malformed-input error with erroneous input length " + this._length;
					break;
				}

				default:
				{
					dsc = string.Empty;
					break;
				}
			}
			return GetType().FullName + "[" + dsc + "]";
		}
	}
}

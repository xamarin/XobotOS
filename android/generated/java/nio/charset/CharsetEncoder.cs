using Sharpen;

namespace java.nio.charset
{
	/// <summary>Transforms a sequence of 16-bit Java characters to a byte sequence in some encoding.
	/// 	</summary>
	/// <remarks>
	/// Transforms a sequence of 16-bit Java characters to a byte sequence in some encoding.
	/// <p>The input character sequence is a
	/// <see cref="java.nio.CharBuffer">CharBuffer</see>
	/// and the
	/// output byte sequence is a
	/// <see cref="java.nio.ByteBuffer">ByteBuffer</see>
	/// .
	/// <p>Use
	/// <see cref="encode(java.nio.CharBuffer)">encode(java.nio.CharBuffer)</see>
	/// to encode an entire
	/// <code>CharBuffer</code>
	/// to a
	/// new
	/// <code>ByteBuffer</code>
	/// , or
	/// <see cref="encode(java.nio.CharBuffer, java.nio.ByteBuffer, bool)">encode(java.nio.CharBuffer, java.nio.ByteBuffer, bool)
	/// 	</see>
	/// for more
	/// control. When using the latter method, the entire operation proceeds as follows:
	/// <ol>
	/// <li>Invoke
	/// <see cref="reset()">reset()</see>
	/// to reset the encoder if this instance has been used before.</li>
	/// <li>Invoke
	/// <see cref="encode(java.nio.CharBuffer, java.nio.ByteBuffer, bool)">encode</see>
	/// with the
	/// <code>endOfInput</code>
	/// parameter set to false until additional input is not needed (as signaled by the return value).
	/// The input buffer must be filled and the output buffer must be flushed between invocations.
	/// <p>The
	/// <see cref="encode(java.nio.CharBuffer, java.nio.ByteBuffer, bool)">encode</see>
	/// method will
	/// convert as many characters as possible, and the process won't stop until the
	/// input buffer has been exhausted, the output buffer has been filled, or an
	/// error has occurred. A
	/// <see cref="CoderResult">CoderResult</see>
	/// instance will be
	/// returned to indicate the current state. The caller should fill the input buffer, flush
	/// the output buffer, or recovering from an error and try again, accordingly.
	/// </li>
	/// <li>Invoke
	/// <see cref="encode(java.nio.CharBuffer, java.nio.ByteBuffer, bool)">encode</see>
	/// for the last time with
	/// <code>endOfInput</code>
	/// set to true.</li>
	/// <li>Invoke
	/// <see cref="flush(java.nio.ByteBuffer)">flush(java.nio.ByteBuffer)</see>
	/// to flush remaining output.</li>
	/// </ol>
	/// <p>There are two classes of encoding error: <i>malformed input</i>
	/// signifies that the input character sequence is not legal, while <i>unmappable character</i>
	/// signifies that the input is legal but cannot be mapped to a byte sequence (because the charset
	/// cannot represent the character, for example).
	/// <p>Errors can be handled in three ways. The default is to
	/// <see cref="CodingErrorAction.REPORT">report</see>
	/// the error to the caller. The alternatives are to
	/// <see cref="CodingErrorAction.IGNORE">ignore</see>
	/// the error or
	/// <see cref="CodingErrorAction.REPLACE">replace</see>
	/// the problematic input with the byte sequence returned by
	/// <see cref="replacement()">replacement()</see>
	/// . The disposition
	/// for each of the two kinds of error can be set independently using the
	/// <see cref="onMalformedInput(CodingErrorAction)">onMalformedInput(CodingErrorAction)
	/// 	</see>
	/// and
	/// <see cref="onUnmappableCharacter(CodingErrorAction)">onUnmappableCharacter(CodingErrorAction)
	/// 	</see>
	/// methods.
	/// <p>The default replacement bytes depend on the charset but can be overridden using the
	/// <see cref="replaceWith(byte[])">replaceWith(byte[])</see>
	/// method.
	/// <p>This class is abstract and encapsulates many common operations of the
	/// encoding process for all charsets. Encoders for a specific charset should
	/// extend this class and need only to implement the
	/// <see cref="encodeLoop(java.nio.CharBuffer, java.nio.ByteBuffer)">encodeLoop</see>
	/// method for basic
	/// encoding. If a subclass maintains internal state, it should also override the
	/// <see cref="implFlush(java.nio.ByteBuffer)">implFlush</see>
	/// and
	/// <see cref="implReset()">implReset</see>
	/// methods.
	/// <p>This class is not thread-safe.
	/// </remarks>
	/// <seealso cref="Charset">Charset</seealso>
	/// <seealso cref="CharsetDecoder">CharsetDecoder</seealso>
	[Sharpen.Sharpened]
	public abstract class CharsetEncoder
	{
		internal const int READY = 0;

		internal const int ONGOING = 1;

		internal const int END = 2;

		internal const int FLUSH = 3;

		internal const int INIT = 4;

		private readonly java.nio.charset.Charset cs;

		private readonly float _averageBytesPerChar;

		private readonly float _maxBytesPerChar;

		private byte[] replacementBytes;

		private int status;

		private bool finished;

		private java.nio.charset.CodingErrorAction _malformedInputAction;

		private java.nio.charset.CodingErrorAction _unmappableCharacterAction;

		private java.nio.charset.CharsetDecoder decoder;

		/// <summary>
		/// Constructs a new
		/// <code>CharsetEncoder</code>
		/// using the given parameters and
		/// the replacement byte array
		/// <code></code>
		/// 
		/// (byte) '?' }}.
		/// </summary>
		protected internal CharsetEncoder(java.nio.charset.Charset cs, float averageBytesPerChar_1
			, float maxBytesPerChar_1) : this(cs, averageBytesPerChar_1, maxBytesPerChar_1, 
			new byte[] { unchecked((byte)(byte)('?')) })
		{
		}

		/// <summary>
		/// Constructs a new <code>CharsetEncoder</code> using the given
		/// <code>Charset</code>, replacement byte array, average number and
		/// maximum number of bytes created by this encoder for one input character.
		/// </summary>
		/// <remarks>
		/// Constructs a new <code>CharsetEncoder</code> using the given
		/// <code>Charset</code>, replacement byte array, average number and
		/// maximum number of bytes created by this encoder for one input character.
		/// </remarks>
		/// <param name="cs">the <code>Charset</code> to be used by this encoder.</param>
		/// <param name="averageBytesPerChar">
		/// average number of bytes created by this encoder for one single
		/// input character, must be positive.
		/// </param>
		/// <param name="maxBytesPerChar">
		/// maximum number of bytes which can be created by this encoder
		/// for one single input character, must be positive.
		/// </param>
		/// <param name="replacement">
		/// the replacement byte array, cannot be null or empty, its
		/// length cannot be larger than <code>maxBytesPerChar</code>,
		/// and must be a legal replacement, which can be justified by
		/// <see cref="isLegalReplacement(byte[])">isLegalReplacement</see>
		/// .
		/// </param>
		/// <exception cref="System.ArgumentException">if any parameters are invalid.</exception>
		protected internal CharsetEncoder(java.nio.charset.Charset cs, float averageBytesPerChar_1
			, float maxBytesPerChar_1, byte[] replacement_1) : this(cs, averageBytesPerChar_1
			, maxBytesPerChar_1, replacement_1, false)
		{
		}

		internal CharsetEncoder(java.nio.charset.Charset cs, float averageBytesPerChar_1, 
			float maxBytesPerChar_1, byte[] replacement_1, bool trusted)
		{
			// internal status indicates encode(CharBuffer) operation is finished
			// decoder instance for this encoder's charset, used for replacement value checking
			if (averageBytesPerChar_1 <= 0 || maxBytesPerChar_1 <= 0)
			{
				throw new System.ArgumentException("averageBytesPerChar and maxBytesPerChar must both be positive"
					);
			}
			if (averageBytesPerChar_1 > maxBytesPerChar_1)
			{
				throw new System.ArgumentException("averageBytesPerChar is greater than maxBytesPerChar"
					);
			}
			this.cs = cs;
			this._averageBytesPerChar = averageBytesPerChar_1;
			this._maxBytesPerChar = maxBytesPerChar_1;
			status = INIT;
			_malformedInputAction = java.nio.charset.CodingErrorAction.REPORT;
			_unmappableCharacterAction = java.nio.charset.CodingErrorAction.REPORT;
			if (trusted)
			{
				// The RI enforces unnecessary restrictions on the replacement bytes. We trust ICU to
				// know what it's doing. Doing so lets us support ICU's EUC-JP, SCSU, and Shift_JIS.
				this.replacementBytes = replacement_1;
			}
			else
			{
				replaceWith(replacement_1);
			}
		}

		/// <summary>
		/// Returns the average number of bytes created by this encoder for a single
		/// input character.
		/// </summary>
		/// <remarks>
		/// Returns the average number of bytes created by this encoder for a single
		/// input character.
		/// </remarks>
		public float averageBytesPerChar()
		{
			return _averageBytesPerChar;
		}

		/// <summary>Checks if the given character can be encoded by this encoder.</summary>
		/// <remarks>
		/// Checks if the given character can be encoded by this encoder.
		/// <p>
		/// Note that this method can change the internal status of this encoder, so
		/// it should not be called when another encoding process is ongoing,
		/// otherwise it will throw an <code>IllegalStateException</code>.
		/// <p>
		/// This method can be overridden for performance improvement.
		/// </remarks>
		/// <param name="c">the given encoder.</param>
		/// <returns>true if given character can be encoded by this encoder.</returns>
		/// <exception cref="System.InvalidOperationException">
		/// if another encode process is ongoing so that the current
		/// internal status is neither RESET or FLUSH.
		/// </exception>
		public virtual bool canEncode(char c)
		{
			return implCanEncode(java.nio.CharBuffer.wrap(new char[] { c }));
		}

		// implementation of canEncode
		private bool implCanEncode(java.nio.CharBuffer cb)
		{
			if (status == FLUSH || status == INIT)
			{
				status = READY;
			}
			if (status != READY)
			{
				throw new System.InvalidOperationException("encoding already in progress");
			}
			java.nio.charset.CodingErrorAction malformBak = _malformedInputAction;
			java.nio.charset.CodingErrorAction unmapBak = _unmappableCharacterAction;
			onMalformedInput(java.nio.charset.CodingErrorAction.REPORT);
			onUnmappableCharacter(java.nio.charset.CodingErrorAction.REPORT);
			bool result = true;
			try
			{
				this.encode(cb);
			}
			catch (java.nio.charset.CharacterCodingException)
			{
				result = false;
			}
			onMalformedInput(malformBak);
			onUnmappableCharacter(unmapBak);
			reset();
			return result;
		}

		/// <summary>
		/// Checks if a given <code>CharSequence</code> can be encoded by this
		/// encoder.
		/// </summary>
		/// <remarks>
		/// Checks if a given <code>CharSequence</code> can be encoded by this
		/// encoder.
		/// Note that this method can change the internal status of this encoder, so
		/// it should not be called when another encode process is ongoing, otherwise
		/// it will throw an <code>IllegalStateException</code>.
		/// This method can be overridden for performance improvement.
		/// </remarks>
		/// <param name="sequence">the given <code>CharSequence</code>.</param>
		/// <returns>
		/// true if the given <code>CharSequence</code> can be encoded by
		/// this encoder.
		/// </returns>
		/// <exception cref="System.InvalidOperationException">if current internal status is neither RESET or FLUSH.
		/// 	</exception>
		public virtual bool canEncode(java.lang.CharSequence sequence)
		{
			java.nio.CharBuffer cb;
			if (sequence is java.nio.CharBuffer)
			{
				cb = ((java.nio.CharBuffer)sequence).duplicate();
			}
			else
			{
				cb = java.nio.CharBuffer.wrap(sequence);
			}
			return implCanEncode(cb);
		}

		/// <summary>
		/// Returns the
		/// <see cref="Charset">Charset</see>
		/// which this encoder uses.
		/// </summary>
		public java.nio.charset.Charset charset()
		{
			return cs;
		}

		/// <summary>This is a facade method for the encoding operation.</summary>
		/// <remarks>
		/// This is a facade method for the encoding operation.
		/// <p>
		/// This method encodes the remaining character sequence of the given
		/// character buffer into a new byte buffer. This method performs a complete
		/// encoding operation, resets at first, then encodes, and flushes at last.
		/// <p>
		/// This method should not be invoked if another encode operation is ongoing.
		/// </remarks>
		/// <param name="in">the input buffer.</param>
		/// <returns>
		/// a new <code>ByteBuffer</code> containing the bytes produced by
		/// this encoding operation. The buffer's limit will be the position
		/// of the last byte in the buffer, and the position will be zero.
		/// </returns>
		/// <exception cref="System.InvalidOperationException">if another encoding operation is ongoing.
		/// 	</exception>
		/// <exception cref="MalformedInputException">
		/// if an illegal input character sequence for this charset is
		/// encountered, and the action for malformed error is
		/// <see cref="CodingErrorAction.REPORT">CodingErrorAction.REPORT</see>
		/// </exception>
		/// <exception cref="UnmappableCharacterException">
		/// if a legal but unmappable input character sequence for this
		/// charset is encountered, and the action for unmappable
		/// character error is
		/// <see cref="CodingErrorAction.REPORT">CodingErrorAction.REPORT</see>
		/// .
		/// Unmappable means the Unicode character sequence at the input
		/// buffer's current position cannot be mapped to a equivalent
		/// byte sequence.
		/// </exception>
		/// <exception cref="CharacterCodingException">if other exception happened during the encode operation.
		/// 	</exception>
		/// <exception cref="java.nio.charset.CharacterCodingException"></exception>
		public java.nio.ByteBuffer encode(java.nio.CharBuffer @in)
		{
			if (@in.remaining() == 0)
			{
				return java.nio.ByteBuffer.allocate(0);
			}
			reset();
			int length = (int)(@in.remaining() * _averageBytesPerChar);
			java.nio.ByteBuffer output = java.nio.ByteBuffer.allocate(length);
			java.nio.charset.CoderResult result = null;
			while (true)
			{
				result = encode(@in, output, false);
				if (result == java.nio.charset.CoderResult.UNDERFLOW)
				{
					break;
				}
				else
				{
					if (result == java.nio.charset.CoderResult.OVERFLOW)
					{
						output = allocateMore(output);
						continue;
					}
				}
				checkCoderResult(result);
			}
			result = encode(@in, output, true);
			checkCoderResult(result);
			while (true)
			{
				result = flush(output);
				if (result == java.nio.charset.CoderResult.UNDERFLOW)
				{
					output.flip();
					break;
				}
				else
				{
					if (result == java.nio.charset.CoderResult.OVERFLOW)
					{
						output = allocateMore(output);
						continue;
					}
				}
				checkCoderResult(result);
				output.flip();
				if (result.isMalformed())
				{
					throw new java.nio.charset.MalformedInputException(result.length());
				}
				else
				{
					if (result.isUnmappable())
					{
						throw new java.nio.charset.UnmappableCharacterException(result.length());
					}
				}
				break;
			}
			status = READY;
			finished = true;
			return output;
		}

		/// <exception cref="java.nio.charset.CharacterCodingException"></exception>
		private void checkCoderResult(java.nio.charset.CoderResult result)
		{
			if (_malformedInputAction == java.nio.charset.CodingErrorAction.REPORT && result.
				isMalformed())
			{
				throw new java.nio.charset.MalformedInputException(result.length());
			}
			else
			{
				if (_unmappableCharacterAction == java.nio.charset.CodingErrorAction.REPORT && result
					.isUnmappable())
				{
					throw new java.nio.charset.UnmappableCharacterException(result.length());
				}
			}
		}

		// allocate more spaces to the given ByteBuffer
		private java.nio.ByteBuffer allocateMore(java.nio.ByteBuffer output)
		{
			if (output.capacity() == 0)
			{
				return java.nio.ByteBuffer.allocate(1);
			}
			java.nio.ByteBuffer result = java.nio.ByteBuffer.allocate(output.capacity() * 2);
			output.flip();
			result.put(output);
			return result;
		}

		/// <summary>
		/// Encodes characters starting at the current position of the given input
		/// buffer, and writes the equivalent byte sequence into the given output
		/// buffer from its current position.
		/// </summary>
		/// <remarks>
		/// Encodes characters starting at the current position of the given input
		/// buffer, and writes the equivalent byte sequence into the given output
		/// buffer from its current position.
		/// <p>
		/// The buffers' position will be changed with the reading and writing
		/// operation, but their limits and marks will be kept intact.
		/// <p>
		/// A <code>CoderResult</code> instance will be returned according to
		/// following rules:
		/// <ul>
		/// <li>A
		/// <see cref="CoderResult.malformedForLength(int)">malformed input</see>
		/// result
		/// indicates that some malformed input error was encountered, and the
		/// erroneous characters start at the input buffer's position and their
		/// number can be got by result's
		/// <see cref="CoderResult.length()">length</see>
		/// . This
		/// kind of result can be returned only if the malformed action is
		/// <see cref="CodingErrorAction.REPORT">CodingErrorAction.REPORT</see>
		/// .</li>
		/// <li>
		/// <see cref="CoderResult.UNDERFLOW">CoderResult.UNDERFLOW</see>
		/// indicates that
		/// as many characters as possible in the input buffer have been encoded. If
		/// there is no further input and no characters left in the input buffer then
		/// this task is complete. If this is not the case then the client should
		/// call this method again supplying some more input characters.</li>
		/// <li>
		/// <see cref="CoderResult.OVERFLOW">CoderResult.OVERFLOW</see>
		/// indicates that the
		/// output buffer has been filled, while there are still some characters
		/// remaining in the input buffer. This method should be invoked again with a
		/// non-full output buffer.</li>
		/// <li>A
		/// <see cref="CoderResult.unmappableForLength(int)">unmappable character</see>
		/// result indicates that some unmappable character error was encountered,
		/// and the erroneous characters start at the input buffer's position and
		/// their number can be got by result's
		/// <see cref="CoderResult.length()">length</see>
		/// .
		/// This kind of result can be returned only on
		/// <see cref="CodingErrorAction.REPORT">CodingErrorAction.REPORT</see>
		/// .</li>
		/// </ul>
		/// <p>
		/// The <code>endOfInput</code> parameter indicates if the invoker can
		/// provider further input. This parameter is true if and only if the
		/// characters in the current input buffer are all inputs for this encoding
		/// operation. Note that it is common and won't cause an error if the invoker
		/// sets false and then has no more input available, while it may cause an
		/// error if the invoker always sets true in several consecutive invocations.
		/// This would make the remaining input to be treated as malformed input.
		/// input.
		/// <p>
		/// This method invokes the
		/// <see cref="encodeLoop(java.nio.CharBuffer, java.nio.ByteBuffer)">encodeLoop</see>
		/// method to
		/// implement the basic encode logic for a specific charset.
		/// </remarks>
		/// <param name="in">the input buffer.</param>
		/// <param name="out">the output buffer.</param>
		/// <param name="endOfInput">true if all the input characters have been provided.</param>
		/// <returns>a <code>CoderResult</code> instance indicating the result.</returns>
		/// <exception cref="System.InvalidOperationException">
		/// if the encoding operation has already started or no more
		/// input is needed in this encoding process.
		/// </exception>
		/// <exception cref="CoderMalfunctionError">
		/// If the
		/// <see cref="encodeLoop(java.nio.CharBuffer, java.nio.ByteBuffer)">encodeLoop</see>
		/// method threw an <code>BufferUnderflowException</code> or
		/// <code>BufferUnderflowException</code>.
		/// </exception>
		public java.nio.charset.CoderResult encode(java.nio.CharBuffer @in, java.nio.ByteBuffer
			 @out, bool endOfInput)
		{
			// If the previous step is encode(CharBuffer), then no more input is needed
			// thus endOfInput should not be false
			if (status == READY && finished && !endOfInput)
			{
				throw new System.InvalidOperationException();
			}
			if ((status == FLUSH) || (!endOfInput && status == END))
			{
				throw new System.InvalidOperationException();
			}
			java.nio.charset.CoderResult result;
			while (true)
			{
				try
				{
					result = encodeLoop(@in, @out);
				}
				catch (java.nio.BufferOverflowException e)
				{
					throw new java.nio.charset.CoderMalfunctionError(e);
				}
				catch (java.nio.BufferUnderflowException e)
				{
					throw new java.nio.charset.CoderMalfunctionError(e);
				}
				if (result == java.nio.charset.CoderResult.UNDERFLOW)
				{
					status = endOfInput ? END : ONGOING;
					if (endOfInput)
					{
						int remaining = @in.remaining();
						if (remaining > 0)
						{
							result = java.nio.charset.CoderResult.malformedForLength(remaining);
						}
						else
						{
							return result;
						}
					}
					else
					{
						return result;
					}
				}
				else
				{
					if (result == java.nio.charset.CoderResult.OVERFLOW)
					{
						status = endOfInput ? END : ONGOING;
						return result;
					}
				}
				java.nio.charset.CodingErrorAction action = _malformedInputAction;
				if (result.isUnmappable())
				{
					action = _unmappableCharacterAction;
				}
				// If the action is IGNORE or REPLACE, we should continue
				// encoding.
				if (action == java.nio.charset.CodingErrorAction.REPLACE)
				{
					if (@out.remaining() < replacementBytes.Length)
					{
						return java.nio.charset.CoderResult.OVERFLOW;
					}
					@out.put(replacementBytes);
				}
				else
				{
					if (action != java.nio.charset.CodingErrorAction.IGNORE)
					{
						return result;
					}
				}
				@in.position(@in.position() + result.length());
			}
		}

		/// <summary>Encodes characters into bytes.</summary>
		/// <remarks>
		/// Encodes characters into bytes. This method is called by
		/// <see cref="encode(java.nio.CharBuffer, java.nio.ByteBuffer, bool)">encode</see>
		/// .
		/// <p>
		/// This method will implement the essential encoding operation, and it won't
		/// stop encoding until either all the input characters are read, the output
		/// buffer is filled, or some exception is encountered. Then it will
		/// return a <code>CoderResult</code> object indicating the result of the
		/// current encoding operation. The rule to construct the
		/// <code>CoderResult</code> is the same as for
		/// <see cref="encode(java.nio.CharBuffer, java.nio.ByteBuffer, bool)">encode</see>
		/// . When an
		/// exception is encountered in the encoding operation, most implementations
		/// of this method will return a relevant result object to the
		/// <see cref="encode(java.nio.CharBuffer, java.nio.ByteBuffer, bool)">encode</see>
		/// method, and some
		/// performance optimized implementation may handle the exception and
		/// implement the error action itself.
		/// <p>
		/// The buffers are scanned from their current positions, and their positions
		/// will be modified accordingly, while their marks and limits will be
		/// intact. At most
		/// <see cref="java.nio.Buffer.remaining()">in.remaining()</see>
		/// characters
		/// will be read, and
		/// <see cref="java.nio.Buffer.remaining()">out.remaining()</see>
		/// bytes
		/// will be written.
		/// <p>
		/// Note that some implementations may pre-scan the input buffer and return
		/// <code>CoderResult.UNDERFLOW</code> until it receives sufficient input.
		/// <p>
		/// </remarks>
		/// <param name="in">the input buffer.</param>
		/// <param name="out">the output buffer.</param>
		/// <returns>a <code>CoderResult</code> instance indicating the result.</returns>
		protected internal abstract java.nio.charset.CoderResult encodeLoop(java.nio.CharBuffer
			 @in, java.nio.ByteBuffer @out);

		/// <summary>Flushes this encoder.</summary>
		/// <remarks>
		/// Flushes this encoder.
		/// <p>
		/// This method will call
		/// <see cref="implFlush(java.nio.ByteBuffer)">implFlush</see>
		/// . Some
		/// encoders may need to write some bytes to the output buffer when they have
		/// read all input characters, subclasses can overridden
		/// <see cref="implFlush(java.nio.ByteBuffer)">implFlush</see>
		/// to perform writing action.
		/// <p>
		/// The maximum number of written bytes won't larger than
		/// <see cref="java.nio.Buffer.remaining()">out.remaining()</see>
		/// . If some encoder wants to
		/// write more bytes than the output buffer's available remaining space, then
		/// <code>CoderResult.OVERFLOW</code> will be returned, and this method
		/// must be called again with a byte buffer that has free space. Otherwise
		/// this method will return <code>CoderResult.UNDERFLOW</code>, which
		/// means one encoding process has been completed successfully.
		/// <p>
		/// During the flush, the output buffer's position will be changed
		/// accordingly, while its mark and limit will be intact.
		/// </remarks>
		/// <param name="out">the given output buffer.</param>
		/// <returns>
		/// <code>CoderResult.UNDERFLOW</code> or
		/// <code>CoderResult.OVERFLOW</code>.
		/// </returns>
		/// <exception cref="System.InvalidOperationException">
		/// if this encoder hasn't read all input characters during one
		/// encoding process, which means neither after calling
		/// <see cref="encode(java.nio.CharBuffer)">encode(CharBuffer)</see>
		/// nor after
		/// calling
		/// <see cref="encode(java.nio.CharBuffer, java.nio.ByteBuffer, bool)">encode(CharBuffer, ByteBuffer, boolean)
		/// 	</see>
		/// with
		/// <code>true</code>
		/// for the last boolean parameter.
		/// </exception>
		public java.nio.charset.CoderResult flush(java.nio.ByteBuffer @out)
		{
			if (status != END && status != READY)
			{
				throw new System.InvalidOperationException();
			}
			java.nio.charset.CoderResult result = implFlush(@out);
			if (result == java.nio.charset.CoderResult.UNDERFLOW)
			{
				status = FLUSH;
			}
			return result;
		}

		/// <summary>Flushes this encoder.</summary>
		/// <remarks>
		/// Flushes this encoder. The default implementation does nothing and always
		/// returns <code>CoderResult.UNDERFLOW</code>; this method can be
		/// overridden if needed.
		/// </remarks>
		/// <param name="out">the output buffer.</param>
		/// <returns>
		/// <code>CoderResult.UNDERFLOW</code> or
		/// <code>CoderResult.OVERFLOW</code>.
		/// </returns>
		protected internal virtual java.nio.charset.CoderResult implFlush(java.nio.ByteBuffer
			 @out)
		{
			return java.nio.charset.CoderResult.UNDERFLOW;
		}

		/// <summary>
		/// Notifies that this encoder's <code>CodingErrorAction</code> specified
		/// for malformed input error has been changed.
		/// </summary>
		/// <remarks>
		/// Notifies that this encoder's <code>CodingErrorAction</code> specified
		/// for malformed input error has been changed. The default implementation
		/// does nothing; this method can be overridden if needed.
		/// </remarks>
		/// <param name="newAction">the new action.</param>
		protected internal virtual void implOnMalformedInput(java.nio.charset.CodingErrorAction
			 newAction)
		{
		}

		// default implementation is empty
		/// <summary>
		/// Notifies that this encoder's <code>CodingErrorAction</code> specified
		/// for unmappable character error has been changed.
		/// </summary>
		/// <remarks>
		/// Notifies that this encoder's <code>CodingErrorAction</code> specified
		/// for unmappable character error has been changed. The default
		/// implementation does nothing; this method can be overridden if needed.
		/// </remarks>
		/// <param name="newAction">the new action.</param>
		protected internal virtual void implOnUnmappableCharacter(java.nio.charset.CodingErrorAction
			 newAction)
		{
		}

		// default implementation is empty
		/// <summary>Notifies that this encoder's replacement has been changed.</summary>
		/// <remarks>
		/// Notifies that this encoder's replacement has been changed. The default
		/// implementation does nothing; this method can be overridden if needed.
		/// </remarks>
		/// <param name="newReplacement">the new replacement string.</param>
		protected internal virtual void implReplaceWith(byte[] newReplacement)
		{
		}

		// default implementation is empty
		/// <summary>Resets this encoder's charset related state.</summary>
		/// <remarks>
		/// Resets this encoder's charset related state. The default implementation
		/// does nothing; this method can be overridden if needed.
		/// </remarks>
		protected internal virtual void implReset()
		{
		}

		// default implementation is empty
		/// <summary>
		/// Checks if the given argument is legal as this encoder's replacement byte
		/// array.
		/// </summary>
		/// <remarks>
		/// Checks if the given argument is legal as this encoder's replacement byte
		/// array.
		/// The given byte array is legal if and only if it can be decode into
		/// sixteen bits Unicode characters.
		/// This method can be overridden for performance improvement.
		/// </remarks>
		/// <param name="replacement">the given byte array to be checked.</param>
		/// <returns>
		/// true if the the given argument is legal as this encoder's
		/// replacement byte array.
		/// </returns>
		public virtual bool isLegalReplacement(byte[] replacement_1)
		{
			if (decoder == null)
			{
				decoder = cs.newDecoder();
				decoder.onMalformedInput(java.nio.charset.CodingErrorAction.REPORT);
				decoder.onUnmappableCharacter(java.nio.charset.CodingErrorAction.REPORT);
			}
			java.nio.ByteBuffer @in = java.nio.ByteBuffer.wrap(replacement_1);
			java.nio.CharBuffer @out = java.nio.CharBuffer.allocate((int)(replacement_1.Length
				 * decoder.maxCharsPerByte()));
			java.nio.charset.CoderResult result = decoder.decode(@in, @out, true);
			return !result.isError();
		}

		/// <summary>
		/// Returns this encoder's <code>CodingErrorAction</code> when a malformed
		/// input error occurred during the encoding process.
		/// </summary>
		/// <remarks>
		/// Returns this encoder's <code>CodingErrorAction</code> when a malformed
		/// input error occurred during the encoding process.
		/// </remarks>
		public virtual java.nio.charset.CodingErrorAction malformedInputAction()
		{
			return _malformedInputAction;
		}

		/// <summary>
		/// Returns the maximum number of bytes which can be created by this encoder for
		/// one input character, must be positive.
		/// </summary>
		/// <remarks>
		/// Returns the maximum number of bytes which can be created by this encoder for
		/// one input character, must be positive.
		/// </remarks>
		public float maxBytesPerChar()
		{
			return _maxBytesPerChar;
		}

		/// <summary>Sets this encoder's action on malformed input error.</summary>
		/// <remarks>
		/// Sets this encoder's action on malformed input error.
		/// This method will call the
		/// <see cref="implOnMalformedInput(CodingErrorAction)">implOnMalformedInput</see>
		/// method with the given new action as argument.
		/// </remarks>
		/// <param name="newAction">the new action on malformed input error.</param>
		/// <returns>this encoder.</returns>
		/// <exception cref="System.ArgumentException">if the given newAction is null.</exception>
		public java.nio.charset.CharsetEncoder onMalformedInput(java.nio.charset.CodingErrorAction
			 newAction)
		{
			if (newAction == null)
			{
				throw new System.ArgumentException("newAction == null");
			}
			_malformedInputAction = newAction;
			implOnMalformedInput(newAction);
			return this;
		}

		/// <summary>Sets this encoder's action on unmappable character error.</summary>
		/// <remarks>
		/// Sets this encoder's action on unmappable character error.
		/// This method will call the
		/// <see cref="implOnUnmappableCharacter(CodingErrorAction)">implOnUnmappableCharacter
		/// 	</see>
		/// method with the given new action as argument.
		/// </remarks>
		/// <param name="newAction">the new action on unmappable character error.</param>
		/// <returns>this encoder.</returns>
		/// <exception cref="System.ArgumentException">if the given newAction is null.</exception>
		public java.nio.charset.CharsetEncoder onUnmappableCharacter(java.nio.charset.CodingErrorAction
			 newAction)
		{
			if (newAction == null)
			{
				throw new System.ArgumentException("newAction == null");
			}
			_unmappableCharacterAction = newAction;
			implOnUnmappableCharacter(newAction);
			return this;
		}

		/// <summary>Returns the replacement byte array, which is never null or empty.</summary>
		/// <remarks>Returns the replacement byte array, which is never null or empty.</remarks>
		public byte[] replacement()
		{
			return replacementBytes;
		}

		/// <summary>Sets the new replacement value.</summary>
		/// <remarks>
		/// Sets the new replacement value.
		/// This method first checks the given replacement's validity, then changes
		/// the replacement value and finally calls the
		/// <see cref="implReplaceWith(byte[])">implReplaceWith</see>
		/// method with the given
		/// new replacement as argument.
		/// </remarks>
		/// <param name="replacement">
		/// the replacement byte array, cannot be null or empty, its
		/// length cannot be larger than <code>maxBytesPerChar</code>,
		/// and it must be legal replacement, which can be justified by
		/// calling <code>isLegalReplacement(byte[] replacement)</code>.
		/// </param>
		/// <returns>this encoder.</returns>
		/// <exception cref="System.ArgumentException">
		/// if the given replacement cannot satisfy the requirement
		/// mentioned above.
		/// </exception>
		public java.nio.charset.CharsetEncoder replaceWith(byte[] replacement_1)
		{
			if (replacement_1 == null)
			{
				throw new System.ArgumentException("replacement == null");
			}
			if (replacement_1.Length == 0)
			{
				throw new System.ArgumentException("replacement.length == 0");
			}
			if (replacement_1.Length > maxBytesPerChar())
			{
				throw new System.ArgumentException("replacement length > maxBytesPerChar: " + replacement_1
					.Length + " > " + maxBytesPerChar());
			}
			if (!isLegalReplacement(replacement_1))
			{
				throw new System.ArgumentException("bad replacement: " + java.util.Arrays.toString
					(replacement_1));
			}
			// It seems like a bug, but the RI doesn't clone, and we have tests that check we don't.
			this.replacementBytes = replacement_1;
			implReplaceWith(replacementBytes);
			return this;
		}

		/// <summary>Resets this encoder.</summary>
		/// <remarks>
		/// Resets this encoder. This method will reset the internal status and then
		/// calls <code>implReset()</code> to reset any status related to the
		/// specific charset.
		/// </remarks>
		/// <returns>this encoder.</returns>
		public java.nio.charset.CharsetEncoder reset()
		{
			status = INIT;
			implReset();
			return this;
		}

		/// <summary>
		/// Returns this encoder's <code>CodingErrorAction</code> when unmappable
		/// character occurred during encoding process.
		/// </summary>
		/// <remarks>
		/// Returns this encoder's <code>CodingErrorAction</code> when unmappable
		/// character occurred during encoding process.
		/// </remarks>
		public virtual java.nio.charset.CodingErrorAction unmappableCharacterAction()
		{
			return _unmappableCharacterAction;
		}
	}
}

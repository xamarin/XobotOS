using Sharpen;

namespace java.nio.charset
{
	/// <summary>
	/// A converter that can convert a byte sequence from a charset into a 16-bit
	/// Unicode character sequence.
	/// </summary>
	/// <remarks>
	/// A converter that can convert a byte sequence from a charset into a 16-bit
	/// Unicode character sequence.
	/// <p>
	/// The input byte sequence is wrapped by a
	/// <see cref="java.nio.ByteBuffer">ByteBuffer</see>
	/// and the output character sequence is a
	/// <see cref="java.nio.CharBuffer">CharBuffer</see>
	/// . A decoder instance should be used in
	/// the following sequence, which is referred to as a decoding operation:
	/// <ol>
	/// <li>invoking the
	/// <see cref="reset()">reset</see>
	/// method to reset the decoder if the
	/// decoder has been used;</li>
	/// <li>invoking the
	/// <see cref="decode(java.nio.ByteBuffer, java.nio.CharBuffer, bool)">decode</see>
	/// method until the additional input is not needed, the <code>endOfInput</code>
	/// parameter must be set to false, the input buffer must be filled and the
	/// output buffer must be flushed between invocations;</li>
	/// <li>invoking the
	/// <see cref="decode(java.nio.ByteBuffer, java.nio.CharBuffer, bool)">decode</see>
	/// method for the last time, and then the <code>endOfInput</code> parameter
	/// must be set to true;</li>
	/// <li>invoking the
	/// <see cref="flush(java.nio.CharBuffer)">flush</see>
	/// method to flush the
	/// output.</li>
	/// </ol>
	/// <p>
	/// The
	/// <see cref="decode(java.nio.ByteBuffer, java.nio.CharBuffer, bool)">decode</see>
	/// method will
	/// convert as many bytes as possible, and the process won't stop until the input
	/// bytes have run out, the output buffer has been filled or some error has
	/// happened. A
	/// <see cref="CoderResult">CoderResult</see>
	/// instance will be returned to
	/// indicate the stop reason, and the invoker can identify the result and choose
	/// further action, which includes filling the input buffer, flushing the output
	/// buffer or recovering from an error and trying again.
	/// <p>
	/// There are two common decoding errors. One is named malformed and it is
	/// returned when the input byte sequence is illegal for the current specific
	/// charset, the other is named unmappable character and it is returned when a
	/// problem occurs mapping a legal input byte sequence to its Unicode character
	/// equivalent.
	/// <p>
	/// Both errors can be handled in three ways, the default one is to report the
	/// error to the invoker by a
	/// <see cref="CoderResult">CoderResult</see>
	/// instance, and the
	/// alternatives are to ignore it or to replace the erroneous input with the
	/// replacement string. The replacement string is "\uFFFD" by default and can be
	/// changed by invoking
	/// <see cref="replaceWith(string)">replaceWith</see>
	/// method. The
	/// invoker of this decoder can choose one way by specifying a
	/// <see cref="CodingErrorAction">CodingErrorAction</see>
	/// instance for each error type via
	/// <see cref="onMalformedInput(CodingErrorAction)">onMalformedInput</see>
	/// method and
	/// <see cref="onUnmappableCharacter(CodingErrorAction)">onUnmappableCharacter</see>
	/// method.
	/// <p>
	/// This is an abstract class and encapsulates many common operations of the
	/// decoding process for all charsets. Decoders for a specific charset should
	/// extend this class and need only to implement the
	/// <see cref="decodeLoop(java.nio.ByteBuffer, java.nio.CharBuffer)">decodeLoop</see>
	/// method for the basic
	/// decoding. If a subclass maintains an internal state, it should override the
	/// <see cref="implFlush(java.nio.CharBuffer)">implFlush</see>
	/// method and the
	/// <see cref="implReset()">implReset</see>
	/// method in addition.
	/// <p>
	/// This class is not thread-safe.
	/// </remarks>
	/// <seealso cref="Charset">Charset</seealso>
	/// <seealso cref="CharsetEncoder">CharsetEncoder</seealso>
	[Sharpen.Sharpened]
	public abstract class CharsetDecoder
	{
		internal const int INIT = 0;

		internal const int ONGOING = 1;

		internal const int END = 2;

		internal const int FLUSH = 3;

		private readonly float _averageCharsPerByte;

		private readonly float _maxCharsPerByte;

		private readonly java.nio.charset.Charset cs;

		private java.nio.charset.CodingErrorAction _malformedInputAction;

		private java.nio.charset.CodingErrorAction _unmappableCharacterAction;

		private string replacementChars;

		private int status;

		/// <summary>
		/// Constructs a new <code>CharsetDecoder</code> using the given
		/// <code>Charset</code>, average number and maximum number of characters
		/// created by this decoder for one input byte, and the default replacement
		/// string "\uFFFD".
		/// </summary>
		/// <remarks>
		/// Constructs a new <code>CharsetDecoder</code> using the given
		/// <code>Charset</code>, average number and maximum number of characters
		/// created by this decoder for one input byte, and the default replacement
		/// string "\uFFFD".
		/// </remarks>
		/// <param name="charset">the <code>Charset</code> to be used by this decoder.</param>
		/// <param name="averageCharsPerByte">
		/// the average number of characters created by this decoder for
		/// one input byte, must be positive.
		/// </param>
		/// <param name="maxCharsPerByte">
		/// the maximum number of characters created by this decoder for
		/// one input byte, must be positive.
		/// </param>
		/// <exception cref="System.ArgumentException">
		/// if <code>averageCharsPerByte</code> or
		/// <code>maxCharsPerByte</code> is negative.
		/// </exception>
		protected internal CharsetDecoder(java.nio.charset.Charset charset_1, float averageCharsPerByte_1
			, float maxCharsPerByte_1)
		{
			if (averageCharsPerByte_1 <= 0 || maxCharsPerByte_1 <= 0)
			{
				throw new System.ArgumentException("averageCharsPerByte and maxCharsPerByte must be positive"
					);
			}
			if (averageCharsPerByte_1 > maxCharsPerByte_1)
			{
				throw new System.ArgumentException("averageCharsPerByte is greater than maxCharsPerByte"
					);
			}
			this._averageCharsPerByte = averageCharsPerByte_1;
			this._maxCharsPerByte = maxCharsPerByte_1;
			cs = charset_1;
			status = INIT;
			_malformedInputAction = java.nio.charset.CodingErrorAction.REPORT;
			_unmappableCharacterAction = java.nio.charset.CodingErrorAction.REPORT;
			replacementChars = "\ufffd";
		}

		/// <summary>
		/// Returns the average number of characters created by this decoder for a
		/// single input byte.
		/// </summary>
		/// <remarks>
		/// Returns the average number of characters created by this decoder for a
		/// single input byte.
		/// </remarks>
		public float averageCharsPerByte()
		{
			return _averageCharsPerByte;
		}

		/// <summary>
		/// Returns the
		/// <see cref="Charset">Charset</see>
		/// which this decoder uses.
		/// </summary>
		public java.nio.charset.Charset charset()
		{
			return cs;
		}

		/// <summary>This is a facade method for the decoding operation.</summary>
		/// <remarks>
		/// This is a facade method for the decoding operation.
		/// <p>
		/// This method decodes the remaining byte sequence of the given byte buffer
		/// into a new character buffer. This method performs a complete decoding
		/// operation, resets at first, then decodes, and flushes at last.
		/// <p>
		/// This method should not be invoked while another
		/// <code>decode</code>
		/// operation
		/// is ongoing.
		/// </remarks>
		/// <param name="in">the input buffer.</param>
		/// <returns>
		/// a new <code>CharBuffer</code> containing the the characters
		/// produced by this decoding operation. The buffer's limit will be
		/// the position of the last character in the buffer, and the
		/// position will be zero.
		/// </returns>
		/// <exception cref="System.InvalidOperationException">if another decoding operation is ongoing.
		/// 	</exception>
		/// <exception cref="MalformedInputException">
		/// if an illegal input byte sequence for this charset was
		/// encountered, and the action for malformed error is
		/// <see cref="CodingErrorAction.REPORT">CodingErrorAction.REPORT</see>
		/// </exception>
		/// <exception cref="UnmappableCharacterException">
		/// if a legal but unmappable input byte sequence for this
		/// charset was encountered, and the action for unmappable
		/// character error is
		/// <see cref="CodingErrorAction.REPORT">CodingErrorAction.REPORT</see>
		/// .
		/// Unmappable means the byte sequence at the input buffer's
		/// current position cannot be mapped to a Unicode character
		/// sequence.
		/// </exception>
		/// <exception cref="CharacterCodingException">if another exception happened during the decode operation.
		/// 	</exception>
		/// <exception cref="java.nio.charset.CharacterCodingException"></exception>
		public java.nio.CharBuffer decode(java.nio.ByteBuffer @in)
		{
			reset();
			int length = (int)(@in.remaining() * _averageCharsPerByte);
			java.nio.CharBuffer output = java.nio.CharBuffer.allocate(length);
			java.nio.charset.CoderResult result = null;
			while (true)
			{
				result = decode(@in, output, false);
				checkCoderResult(result);
				if (result.isUnderflow())
				{
					break;
				}
				else
				{
					if (result.isOverflow())
					{
						output = allocateMore(output);
					}
				}
			}
			result = decode(@in, output, true);
			checkCoderResult(result);
			while (true)
			{
				result = flush(output);
				checkCoderResult(result);
				if (result.isOverflow())
				{
					output = allocateMore(output);
				}
				else
				{
					break;
				}
			}
			output.flip();
			status = FLUSH;
			return output;
		}

		/// <exception cref="java.nio.charset.CharacterCodingException"></exception>
		private void checkCoderResult(java.nio.charset.CoderResult result)
		{
			if (result.isMalformed() && _malformedInputAction == java.nio.charset.CodingErrorAction
				.REPORT)
			{
				throw new java.nio.charset.MalformedInputException(result.length());
			}
			else
			{
				if (result.isUnmappable() && _unmappableCharacterAction == java.nio.charset.CodingErrorAction
					.REPORT)
				{
					throw new java.nio.charset.UnmappableCharacterException(result.length());
				}
			}
		}

		private java.nio.CharBuffer allocateMore(java.nio.CharBuffer output)
		{
			if (output.capacity() == 0)
			{
				return java.nio.CharBuffer.allocate(1);
			}
			java.nio.CharBuffer result = java.nio.CharBuffer.allocate(output.capacity() * 2);
			output.flip();
			result.put(output);
			return result;
		}

		/// <summary>
		/// Decodes bytes starting at the current position of the given input buffer,
		/// and writes the equivalent character sequence into the given output buffer
		/// from its current position.
		/// </summary>
		/// <remarks>
		/// Decodes bytes starting at the current position of the given input buffer,
		/// and writes the equivalent character sequence into the given output buffer
		/// from its current position.
		/// <p>
		/// The buffers' position will be changed with the reading and writing
		/// operation, but their limits and marks will be kept intact.
		/// <p>
		/// A <code>CoderResult</code> instance will be returned according to
		/// following rules:
		/// <ul>
		/// <li>
		/// <see cref="CoderResult.OVERFLOW">CoderResult.OVERFLOW</see>
		/// indicates that
		/// even though not all of the input has been processed, the buffer the
		/// output is being written to has reached its capacity. In the event of this
		/// code being returned this method should be called once more with an
		/// <code>out</code> argument that has not already been filled.</li>
		/// <li>
		/// <see cref="CoderResult.UNDERFLOW">CoderResult.UNDERFLOW</see>
		/// indicates that
		/// as many bytes as possible in the input buffer have been decoded. If there
		/// is no further input and no remaining bytes in the input buffer then this
		/// operation may be regarded as complete. Otherwise, this method should be
		/// called once more with additional input.</li>
		/// <li>A
		/// <see cref="CoderResult.malformedForLength(int)">malformed input</see>
		/// result
		/// indicates that some malformed input error has been encountered, and the
		/// erroneous bytes start at the input buffer's position and their number can
		/// be got by result's
		/// <see cref="CoderResult.length()">length</see>
		/// . This kind of
		/// result can be returned only if the malformed action is
		/// <see cref="CodingErrorAction.REPORT">CodingErrorAction.REPORT</see>
		/// . </li>
		/// <li>A
		/// <see cref="CoderResult.unmappableForLength(int)">unmappable character</see>
		/// result indicates that some unmappable character error has been
		/// encountered, and the erroneous bytes start at the input buffer's position
		/// and their number can be got by result's
		/// <see cref="CoderResult.length()">length</see>
		/// . This kind of result can be returned
		/// only if the unmappable character action is
		/// <see cref="CodingErrorAction.REPORT">CodingErrorAction.REPORT</see>
		/// . </li>
		/// </ul>
		/// <p>
		/// The <code>endOfInput</code> parameter indicates that the invoker cannot
		/// provide further input. This parameter is true if and only if the bytes in
		/// current input buffer are all inputs for this decoding operation. Note
		/// that it is common and won't cause an error if the invoker sets false and
		/// then can't provide more input, while it may cause an error if the invoker
		/// always sets true in several consecutive invocations. This would make the
		/// remaining input to be treated as malformed input.
		/// <p>
		/// This method invokes the
		/// <see cref="decodeLoop(java.nio.ByteBuffer, java.nio.CharBuffer)">decodeLoop</see>
		/// method to
		/// implement the basic decode logic for a specific charset.
		/// </remarks>
		/// <param name="in">the input buffer.</param>
		/// <param name="out">the output buffer.</param>
		/// <param name="endOfInput">true if all the input characters have been provided.</param>
		/// <returns>
		/// a <code>CoderResult</code> instance which indicates the reason
		/// of termination.
		/// </returns>
		/// <exception cref="System.InvalidOperationException">
		/// if decoding has started or no more input is needed in this
		/// decoding progress.
		/// </exception>
		/// <exception cref="CoderMalfunctionError">
		/// if the
		/// <see cref="decodeLoop(java.nio.ByteBuffer, java.nio.CharBuffer)">decodeLoop</see>
		/// method threw an <code>BufferUnderflowException</code> or
		/// <code>BufferOverflowException</code>.
		/// </exception>
		public java.nio.charset.CoderResult decode(java.nio.ByteBuffer @in, java.nio.CharBuffer
			 @out, bool endOfInput)
		{
			if ((status == FLUSH) || (!endOfInput && status == END))
			{
				throw new System.InvalidOperationException();
			}
			java.nio.charset.CoderResult result = null;
			// begin to decode
			while (true)
			{
				java.nio.charset.CodingErrorAction action = null;
				try
				{
					result = decodeLoop(@in, @out);
				}
				catch (java.nio.BufferOverflowException ex)
				{
					// unexpected exception
					throw new java.nio.charset.CoderMalfunctionError(ex);
				}
				catch (java.nio.BufferUnderflowException ex)
				{
					// unexpected exception
					throw new java.nio.charset.CoderMalfunctionError(ex);
				}
				if (result.isUnderflow())
				{
					int remaining = @in.remaining();
					status = endOfInput ? END : ONGOING;
					if (endOfInput && remaining > 0)
					{
						result = java.nio.charset.CoderResult.malformedForLength(remaining);
					}
					else
					{
						return result;
					}
				}
				if (result.isOverflow())
				{
					return result;
				}
				// set coding error handle action
				action = _malformedInputAction;
				if (result.isUnmappable())
				{
					action = _unmappableCharacterAction;
				}
				// If the action is IGNORE or REPLACE, we should continue decoding.
				if (action == java.nio.charset.CodingErrorAction.REPLACE)
				{
					if (@out.remaining() < replacementChars.Length)
					{
						return java.nio.charset.CoderResult.OVERFLOW;
					}
					@out.put(replacementChars);
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

		/// <summary>Decodes bytes into characters.</summary>
		/// <remarks>
		/// Decodes bytes into characters. This method is called by the
		/// <see cref="decode(java.nio.ByteBuffer, java.nio.CharBuffer, bool)">decode</see>
		/// method.
		/// <p>
		/// This method will implement the essential decoding operation, and it won't
		/// stop decoding until either all the input bytes are read, the output
		/// buffer is filled, or some exception is encountered. Then it will return a
		/// <code>CoderResult</code> object indicating the result of current
		/// decoding operation. The rules to construct the <code>CoderResult</code>
		/// are the same as for
		/// <see cref="decode(java.nio.ByteBuffer, java.nio.CharBuffer, bool)">decode</see>
		/// . When an
		/// exception is encountered in the decoding operation, most implementations
		/// of this method will return a relevant result object to the
		/// <see cref="decode(java.nio.ByteBuffer, java.nio.CharBuffer, bool)">decode</see>
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
		/// Note that some implementations may pre-scan the input buffer and return a
		/// <code>CoderResult.UNDERFLOW</code> until it receives sufficient input.
		/// </remarks>
		/// <param name="in">the input buffer.</param>
		/// <param name="out">the output buffer.</param>
		/// <returns>a <code>CoderResult</code> instance indicating the result.</returns>
		protected internal abstract java.nio.charset.CoderResult decodeLoop(java.nio.ByteBuffer
			 @in, java.nio.CharBuffer @out);

		/// <summary>Gets the charset detected by this decoder; this method is optional.</summary>
		/// <remarks>
		/// Gets the charset detected by this decoder; this method is optional.
		/// <p>
		/// If implementing an auto-detecting charset, then this decoder returns the
		/// detected charset from this method when it is available. The returned
		/// charset will be the same for the rest of the decode operation.
		/// <p>
		/// If insufficient bytes have been read to determine the charset, an
		/// <code>IllegalStateException</code> will be thrown.
		/// <p>
		/// The default implementation always throws
		/// <code>UnsupportedOperationException</code>, so it should be overridden
		/// by a subclass if needed.
		/// </remarks>
		/// <returns>
		/// the charset detected by this decoder, or null if it is not yet
		/// determined.
		/// </returns>
		/// <exception cref="System.NotSupportedException">if this decoder does not implement an auto-detecting charset.
		/// 	</exception>
		/// <exception cref="System.InvalidOperationException">
		/// if insufficient bytes have been read to determine the
		/// charset.
		/// </exception>
		public virtual java.nio.charset.Charset detectedCharset()
		{
			throw new System.NotSupportedException();
		}

		/// <summary>Flushes this decoder.</summary>
		/// <remarks>
		/// Flushes this decoder.
		/// This method will call
		/// <see cref="implFlush(java.nio.CharBuffer)">implFlush</see>
		/// . Some
		/// decoders may need to write some characters to the output buffer when they
		/// have read all input bytes; subclasses can override
		/// <see cref="implFlush(java.nio.CharBuffer)">implFlush</see>
		/// to perform the writing operation.
		/// <p>
		/// The maximum number of written bytes won't be larger than
		/// <see cref="java.nio.Buffer.remaining()">out.remaining()</see>
		/// . If some decoder wants to
		/// write more bytes than an output buffer's remaining space allows, then a
		/// <code>CoderResult.OVERFLOW</code> will be returned, and this method
		/// must be called again with a character buffer that has more remaining
		/// space. Otherwise this method will return
		/// <code>CoderResult.UNDERFLOW</code>, which means one decoding process
		/// has been completed successfully.
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
		/// if this decoder hasn't read all input bytes during one
		/// decoding process, which means neither after calling
		/// <see cref="decode(java.nio.ByteBuffer)">decode(ByteBuffer)</see>
		/// nor after
		/// calling
		/// <see cref="decode(java.nio.ByteBuffer, java.nio.CharBuffer, bool)">decode(ByteBuffer, CharBuffer, boolean)
		/// 	</see>
		/// with true as value
		/// for the last boolean parameter.
		/// </exception>
		public java.nio.charset.CoderResult flush(java.nio.CharBuffer @out)
		{
			if (status != END && status != INIT)
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

		/// <summary>Flushes this decoder.</summary>
		/// <remarks>
		/// Flushes this decoder. The default implementation does nothing and always
		/// returns <code>CoderResult.UNDERFLOW</code>; this method can be
		/// overridden if needed.
		/// </remarks>
		/// <param name="out">the output buffer.</param>
		/// <returns>
		/// <code>CoderResult.UNDERFLOW</code> or
		/// <code>CoderResult.OVERFLOW</code>.
		/// </returns>
		protected internal virtual java.nio.charset.CoderResult implFlush(java.nio.CharBuffer
			 @out)
		{
			return java.nio.charset.CoderResult.UNDERFLOW;
		}

		/// <summary>
		/// Notifies that this decoder's <code>CodingErrorAction</code> specified
		/// for malformed input error has been changed.
		/// </summary>
		/// <remarks>
		/// Notifies that this decoder's <code>CodingErrorAction</code> specified
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
		/// Notifies that this decoder's <code>CodingErrorAction</code> specified
		/// for unmappable character error has been changed.
		/// </summary>
		/// <remarks>
		/// Notifies that this decoder's <code>CodingErrorAction</code> specified
		/// for unmappable character error has been changed. The default
		/// implementation does nothing; this method can be overridden if needed.
		/// </remarks>
		/// <param name="newAction">the new action.</param>
		protected internal virtual void implOnUnmappableCharacter(java.nio.charset.CodingErrorAction
			 newAction)
		{
		}

		// default implementation is empty
		/// <summary>Notifies that this decoder's replacement has been changed.</summary>
		/// <remarks>
		/// Notifies that this decoder's replacement has been changed. The default
		/// implementation does nothing; this method can be overridden if needed.
		/// </remarks>
		/// <param name="newReplacement">the new replacement string.</param>
		protected internal virtual void implReplaceWith(string newReplacement)
		{
		}

		// default implementation is empty
		/// <summary>Reset this decoder's charset related state.</summary>
		/// <remarks>
		/// Reset this decoder's charset related state. The default implementation
		/// does nothing; this method can be overridden if needed.
		/// </remarks>
		protected internal virtual void implReset()
		{
		}

		// default implementation is empty
		/// <summary>Indicates whether this decoder implements an auto-detecting charset.</summary>
		/// <remarks>Indicates whether this decoder implements an auto-detecting charset.</remarks>
		/// <returns>
		/// <code>true</code> if this decoder implements an auto-detecting
		/// charset.
		/// </returns>
		public virtual bool isAutoDetecting()
		{
			return false;
		}

		/// <summary>
		/// Indicates whether this decoder has detected a charset; this method is
		/// optional.
		/// </summary>
		/// <remarks>
		/// Indicates whether this decoder has detected a charset; this method is
		/// optional.
		/// <p>
		/// If this decoder implements an auto-detecting charset, then this method
		/// may start to return true during decoding operation to indicate that a
		/// charset has been detected in the input bytes and that the charset can be
		/// retrieved by invoking the
		/// <see cref="detectedCharset()">detectedCharset</see>
		/// method.
		/// <p>
		/// Note that a decoder that implements an auto-detecting charset may still
		/// succeed in decoding a portion of the given input even when it is unable
		/// to detect the charset. For this reason users should be aware that a
		/// <code>false</code> return value does not indicate that no decoding took
		/// place.
		/// <p>
		/// The default implementation always throws an
		/// <code>UnsupportedOperationException</code>; it should be overridden by
		/// a subclass if needed.
		/// </remarks>
		/// <returns><code>true</code> if this decoder has detected a charset.</returns>
		/// <exception cref="System.NotSupportedException">if this decoder doesn't implement an auto-detecting charset.
		/// 	</exception>
		public virtual bool isCharsetDetected()
		{
			throw new System.NotSupportedException();
		}

		/// <summary>
		/// Returns this decoder's <code>CodingErrorAction</code> when malformed input
		/// occurred during the decoding process.
		/// </summary>
		/// <remarks>
		/// Returns this decoder's <code>CodingErrorAction</code> when malformed input
		/// occurred during the decoding process.
		/// </remarks>
		public virtual java.nio.charset.CodingErrorAction malformedInputAction()
		{
			return _malformedInputAction;
		}

		/// <summary>
		/// Returns the maximum number of characters which can be created by this
		/// decoder for one input byte, must be positive.
		/// </summary>
		/// <remarks>
		/// Returns the maximum number of characters which can be created by this
		/// decoder for one input byte, must be positive.
		/// </remarks>
		public float maxCharsPerByte()
		{
			return _maxCharsPerByte;
		}

		/// <summary>Sets this decoder's action on malformed input errors.</summary>
		/// <remarks>
		/// Sets this decoder's action on malformed input errors.
		/// This method will call the
		/// <see cref="implOnMalformedInput(CodingErrorAction)">implOnMalformedInput</see>
		/// method with the given new action as argument.
		/// </remarks>
		/// <param name="newAction">the new action on malformed input error.</param>
		/// <returns>this decoder.</returns>
		/// <exception cref="System.ArgumentException">
		/// if
		/// <code>newAction</code>
		/// is
		/// <code>null</code>
		/// .
		/// </exception>
		public java.nio.charset.CharsetDecoder onMalformedInput(java.nio.charset.CodingErrorAction
			 newAction)
		{
			if (newAction == null)
			{
				throw new System.ArgumentException();
			}
			_malformedInputAction = newAction;
			implOnMalformedInput(newAction);
			return this;
		}

		/// <summary>Sets this decoder's action on unmappable character errors.</summary>
		/// <remarks>
		/// Sets this decoder's action on unmappable character errors.
		/// This method will call the
		/// <see cref="implOnUnmappableCharacter(CodingErrorAction)">implOnUnmappableCharacter
		/// 	</see>
		/// method with the given new action as argument.
		/// </remarks>
		/// <param name="newAction">the new action on unmappable character error.</param>
		/// <returns>this decoder.</returns>
		/// <exception cref="System.ArgumentException">
		/// if
		/// <code>newAction</code>
		/// is
		/// <code>null</code>
		/// .
		/// </exception>
		public java.nio.charset.CharsetDecoder onUnmappableCharacter(java.nio.charset.CodingErrorAction
			 newAction)
		{
			if (newAction == null)
			{
				throw new System.ArgumentException();
			}
			_unmappableCharacterAction = newAction;
			implOnUnmappableCharacter(newAction);
			return this;
		}

		/// <summary>Returns the replacement string, which is never null or empty.</summary>
		/// <remarks>Returns the replacement string, which is never null or empty.</remarks>
		public string replacement()
		{
			return replacementChars;
		}

		/// <summary>Sets the new replacement string.</summary>
		/// <remarks>
		/// Sets the new replacement string.
		/// This method first checks the given replacement's validity, then changes
		/// the replacement value, and at last calls the
		/// <see cref="implReplaceWith(string)">implReplaceWith</see>
		/// method with the given
		/// new replacement as argument.
		/// </remarks>
		/// <param name="replacement">
		/// the replacement string, cannot be null or empty. Its length
		/// cannot be larger than
		/// <see cref="maxCharsPerByte()">maxCharsPerByte()</see>
		/// .
		/// </param>
		/// <returns>this decoder.</returns>
		/// <exception cref="System.ArgumentException">
		/// if the given replacement cannot satisfy the requirement
		/// mentioned above.
		/// </exception>
		public java.nio.charset.CharsetDecoder replaceWith(string replacement_1)
		{
			if (replacement_1 == null)
			{
				throw new System.ArgumentException("replacement == null");
			}
			if (string.IsNullOrEmpty(replacement_1))
			{
				throw new System.ArgumentException("replacement.isEmpty()");
			}
			if (replacement_1.Length > maxCharsPerByte())
			{
				throw new System.ArgumentException("replacement length > maxCharsPerByte: " + replacement_1
					.Length + " > " + maxCharsPerByte());
			}
			replacementChars = replacement_1;
			implReplaceWith(replacement_1);
			return this;
		}

		/// <summary>Resets this decoder.</summary>
		/// <remarks>
		/// Resets this decoder. This method will reset the internal status, and then
		/// calls <code>implReset()</code> to reset any status related to the
		/// specific charset.
		/// </remarks>
		/// <returns>this decoder.</returns>
		public java.nio.charset.CharsetDecoder reset()
		{
			status = INIT;
			implReset();
			return this;
		}

		/// <summary>
		/// Returns this decoder's <code>CodingErrorAction</code> when an unmappable
		/// character error occurred during the decoding process.
		/// </summary>
		/// <remarks>
		/// Returns this decoder's <code>CodingErrorAction</code> when an unmappable
		/// character error occurred during the decoding process.
		/// </remarks>
		public virtual java.nio.charset.CodingErrorAction unmappableCharacterAction()
		{
			return _unmappableCharacterAction;
		}
	}
}

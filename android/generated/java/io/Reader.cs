using Sharpen;

namespace java.io
{
	/// <summary>The base class for all readers.</summary>
	/// <remarks>
	/// The base class for all readers. A reader is a means of reading data from a
	/// source in a character-wise manner. Some readers also support marking a
	/// position in the input and returning to this position later.
	/// <p>
	/// This abstract class does not provide a fully working implementation, so it
	/// needs to be subclassed, and at least the
	/// <see cref="read(char[], int, int)">read(char[], int, int)</see>
	/// and
	/// <see cref="close()">close()</see>
	/// methods needs to be overridden. Overriding some of the
	/// non-abstract methods is also often advised, since it might result in higher
	/// efficiency.
	/// <p>
	/// Many specialized readers for purposes like reading from a file already exist
	/// in this package.
	/// </remarks>
	/// <seealso cref="Writer">Writer</seealso>
	[Sharpen.Sharpened]
	public abstract class Reader : java.lang.Readable, java.io.Closeable
	{
		/// <summary>The object used to synchronize access to the reader.</summary>
		/// <remarks>The object used to synchronize access to the reader.</remarks>
		protected internal object @lock;

		/// <summary>
		/// Constructs a new
		/// <code>Reader</code>
		/// with
		/// <code>this</code>
		/// as the object used to
		/// synchronize critical sections.
		/// </summary>
		protected internal Reader()
		{
			@lock = this;
		}

		/// <summary>
		/// Constructs a new
		/// <code>Reader</code>
		/// with
		/// <code>lock</code>
		/// used to synchronize
		/// critical sections.
		/// </summary>
		/// <param name="lock">
		/// the
		/// <code>Object</code>
		/// used to synchronize critical sections.
		/// </param>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>lock</code>
		/// is
		/// <code>null</code>
		/// .
		/// </exception>
		protected internal Reader(object @lock)
		{
			if (@lock == null)
			{
				throw new System.ArgumentNullException();
			}
			this.@lock = @lock;
		}

		/// <summary>Closes this reader.</summary>
		/// <remarks>
		/// Closes this reader. Implementations of this method should free any
		/// resources associated with the reader.
		/// </remarks>
		/// <exception cref="IOException">if an error occurs while closing this reader.</exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.ImplementsInterface(@"java.lang.AutoCloseable")]
		public abstract void close();

		/// <summary>Sets a mark position in this reader.</summary>
		/// <remarks>
		/// Sets a mark position in this reader. The parameter
		/// <code>readLimit</code>
		/// indicates how many characters can be read before the mark is invalidated.
		/// Calling
		/// <code>reset()</code>
		/// will reposition the reader back to the marked
		/// position if
		/// <code>readLimit</code>
		/// has not been surpassed.
		/// <p>
		/// This default implementation simply throws an
		/// <code>IOException</code>
		/// ;
		/// subclasses must provide their own implementation.
		/// </remarks>
		/// <param name="readLimit">
		/// the number of characters that can be read before the mark is
		/// invalidated.
		/// </param>
		/// <exception cref="System.ArgumentException">
		/// if
		/// <code>readLimit &lt; 0</code>
		/// .
		/// </exception>
		/// <exception cref="IOException">if an error occurs while setting a mark in this reader.
		/// 	</exception>
		/// <seealso cref="markSupported()">markSupported()</seealso>
		/// <seealso cref="reset()">reset()</seealso>
		/// <exception cref="System.IO.IOException"></exception>
		public virtual void mark(int readLimit)
		{
			throw new System.IO.IOException();
		}

		/// <summary>
		/// Indicates whether this reader supports the
		/// <code>mark()</code>
		/// and
		/// <code>reset()</code>
		/// methods. This default implementation returns
		/// <code>false</code>
		/// .
		/// </summary>
		/// <returns>
		/// always
		/// <code>false</code>
		/// .
		/// </returns>
		public virtual bool markSupported()
		{
			return false;
		}

		/// <summary>
		/// Reads a single character from this reader and returns it as an integer
		/// with the two higher-order bytes set to 0.
		/// </summary>
		/// <remarks>
		/// Reads a single character from this reader and returns it as an integer
		/// with the two higher-order bytes set to 0. Returns -1 if the end of the
		/// reader has been reached.
		/// </remarks>
		/// <returns>
		/// the character read or -1 if the end of the reader has been
		/// reached.
		/// </returns>
		/// <exception cref="IOException">if this reader is closed or some other I/O error occurs.
		/// 	</exception>
		/// <exception cref="System.IO.IOException"></exception>
		public virtual int read()
		{
			lock (@lock)
			{
				char[] charArray = new char[1];
				if (read(charArray, 0, 1) != -1)
				{
					return charArray[0];
				}
				return -1;
			}
		}

		/// <summary>
		/// Reads characters from this reader and stores them in the character array
		/// <code>buf</code>
		/// starting at offset 0. Returns the number of characters
		/// actually read or -1 if the end of the reader has been reached.
		/// </summary>
		/// <param name="buf">character array to store the characters read.</param>
		/// <returns>
		/// the number of characters read or -1 if the end of the reader has
		/// been reached.
		/// </returns>
		/// <exception cref="IOException">if this reader is closed or some other I/O error occurs.
		/// 	</exception>
		/// <exception cref="System.IO.IOException"></exception>
		public virtual int read(char[] buf)
		{
			return read(buf, 0, buf.Length);
		}

		/// <summary>
		/// Reads at most
		/// <code>count</code>
		/// characters from this reader and stores them
		/// at
		/// <code>offset</code>
		/// in the character array
		/// <code>buf</code>
		/// . Returns the number
		/// of characters actually read or -1 if the end of the reader has been
		/// reached.
		/// </summary>
		/// <param name="buf">the character array to store the characters read.</param>
		/// <param name="offset">
		/// the initial position in
		/// <code>buffer</code>
		/// to store the characters
		/// read from this reader.
		/// </param>
		/// <param name="count">the maximum number of characters to read.</param>
		/// <returns>
		/// the number of characters read or -1 if the end of the reader has
		/// been reached.
		/// </returns>
		/// <exception cref="IOException">if this reader is closed or some other I/O error occurs.
		/// 	</exception>
		/// <exception cref="System.IO.IOException"></exception>
		public abstract int read(char[] buf, int offset, int count);

		/// <summary>Indicates whether this reader is ready to be read without blocking.</summary>
		/// <remarks>
		/// Indicates whether this reader is ready to be read without blocking.
		/// Returns
		/// <code>true</code>
		/// if this reader will not block when
		/// <code>read</code>
		/// is
		/// called,
		/// <code>false</code>
		/// if unknown or blocking will occur. This default
		/// implementation always returns
		/// <code>false</code>
		/// .
		/// </remarks>
		/// <returns>
		/// always
		/// <code>false</code>
		/// .
		/// </returns>
		/// <exception cref="IOException">if this reader is closed or some other I/O error occurs.
		/// 	</exception>
		/// <seealso cref="read()">read()</seealso>
		/// <seealso cref="read(char[])">read(char[])</seealso>
		/// <seealso cref="read(char[], int, int)">read(char[], int, int)</seealso>
		/// <exception cref="System.IO.IOException"></exception>
		public virtual bool ready()
		{
			return false;
		}

		/// <summary>
		/// Resets this reader's position to the last
		/// <code>mark()</code>
		/// location.
		/// Invocations of
		/// <code>read()</code>
		/// and
		/// <code>skip()</code>
		/// will occur from this new
		/// location. If this reader has not been marked, the behavior of
		/// <code>reset()</code>
		/// is implementation specific. This default
		/// implementation throws an
		/// <code>IOException</code>
		/// .
		/// </summary>
		/// <exception cref="IOException">always thrown in this default implementation.</exception>
		/// <seealso cref="mark(int)">mark(int)</seealso>
		/// <seealso cref="markSupported()">markSupported()</seealso>
		/// <exception cref="System.IO.IOException"></exception>
		public virtual void reset()
		{
			throw new System.IO.IOException();
		}

		/// <summary>
		/// Skips
		/// <code>charCount</code>
		/// characters in this reader. Subsequent calls of
		/// <code>read</code>
		/// methods will not return these characters unless
		/// <code>reset</code>
		/// is used. This method may perform multiple reads to read
		/// <code>charCount</code>
		/// characters.
		/// </summary>
		/// <returns>the number of characters actually skipped.</returns>
		/// <exception cref="System.ArgumentException">
		/// if
		/// <code>charCount &lt; 0</code>
		/// .
		/// </exception>
		/// <exception cref="IOException">if this reader is closed or some other I/O error occurs.
		/// 	</exception>
		/// <seealso cref="mark(int)">mark(int)</seealso>
		/// <seealso cref="markSupported()">markSupported()</seealso>
		/// <seealso cref="reset()">reset()</seealso>
		/// <exception cref="System.IO.IOException"></exception>
		public virtual long skip(long charCount)
		{
			if (charCount < 0)
			{
				throw new System.ArgumentException("charCount < 0: " + charCount);
			}
			lock (@lock)
			{
				long skipped = 0;
				int toRead = charCount < 512 ? (int)charCount : 512;
				char[] charsSkipped = new char[toRead];
				while (skipped < charCount)
				{
					int read_1 = read(charsSkipped, 0, toRead);
					if (read_1 == -1)
					{
						return skipped;
					}
					skipped += read_1;
					if (read_1 < toRead)
					{
						return skipped;
					}
					if (charCount - skipped < toRead)
					{
						toRead = (int)(charCount - skipped);
					}
				}
				return skipped;
			}
		}

		/// <summary>
		/// Reads characters and puts them into the
		/// <code>target</code>
		/// character buffer.
		/// </summary>
		/// <param name="target">the destination character buffer.</param>
		/// <returns>
		/// the number of characters put into
		/// <code>target</code>
		/// or -1 if the end
		/// of this reader has been reached before a character has been read.
		/// </returns>
		/// <exception cref="IOException">if any I/O error occurs while reading from this reader.
		/// 	</exception>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>target</code>
		/// is
		/// <code>null</code>
		/// .
		/// </exception>
		/// <exception cref="java.nio.ReadOnlyBufferException">
		/// if
		/// <code>target</code>
		/// is read-only.
		/// </exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.ImplementsInterface(@"java.lang.Readable")]
		public virtual int read(java.nio.CharBuffer target)
		{
			int length = target.Length;
			char[] buf = new char[length];
			length = System.Math.Min(length, read(buf));
			if (length > 0)
			{
				target.put(buf, 0, length);
			}
			return length;
		}
	}
}

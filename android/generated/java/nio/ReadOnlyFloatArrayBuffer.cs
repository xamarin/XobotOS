using Sharpen;

namespace java.nio
{
	/// <summary>
	/// FloatArrayBuffer, ReadWriteFloatArrayBuffer and ReadOnlyFloatArrayBuffer
	/// compose the implementation of array based float buffers.
	/// </summary>
	/// <remarks>
	/// FloatArrayBuffer, ReadWriteFloatArrayBuffer and ReadOnlyFloatArrayBuffer
	/// compose the implementation of array based float buffers.
	/// <p>
	/// ReadOnlyFloatArrayBuffer extends FloatArrayBuffer with all the write methods
	/// throwing read only exception.
	/// </p>
	/// <p>
	/// This class is marked final for runtime performance.
	/// </p>
	/// </remarks>
	[Sharpen.Sharpened]
	internal sealed class ReadOnlyFloatArrayBuffer : java.nio.FloatArrayBuffer
	{
		internal static java.nio.ReadOnlyFloatArrayBuffer copy(java.nio.FloatArrayBuffer 
			other, int markOfOther)
		{
			java.nio.ReadOnlyFloatArrayBuffer buf = new java.nio.ReadOnlyFloatArrayBuffer(other
				.capacity(), other.backingArray, other.offset);
			buf._limit = other._limit;
			buf._position = other.position();
			buf._mark = markOfOther;
			return buf;
		}

		internal ReadOnlyFloatArrayBuffer(int capacity_1, float[] backingArray, int arrayOffset_1
			) : base(capacity_1, backingArray, arrayOffset_1)
		{
		}

		[Sharpen.OverridesMethod(@"java.nio.FloatBuffer")]
		public override java.nio.FloatBuffer asReadOnlyBuffer()
		{
			return duplicate();
		}

		[Sharpen.OverridesMethod(@"java.nio.FloatBuffer")]
		public override java.nio.FloatBuffer compact()
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.FloatBuffer")]
		public override java.nio.FloatBuffer duplicate()
		{
			return copy(this, _mark);
		}

		[Sharpen.OverridesMethod(@"java.nio.Buffer")]
		public override bool isReadOnly()
		{
			return true;
		}

		[Sharpen.OverridesMethod(@"java.nio.FloatBuffer")]
		internal override float[] protectedArray()
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.FloatBuffer")]
		internal override int protectedArrayOffset()
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.FloatBuffer")]
		internal override bool protectedHasArray()
		{
			return false;
		}

		[Sharpen.OverridesMethod(@"java.nio.FloatBuffer")]
		public override java.nio.FloatBuffer put(float c)
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.FloatBuffer")]
		public override java.nio.FloatBuffer put(int index, float c)
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.FloatBuffer")]
		public override java.nio.FloatBuffer put(java.nio.FloatBuffer buf)
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.FloatBuffer")]
		public sealed override java.nio.FloatBuffer put(float[] src, int srcOffset, int byteCount
			)
		{
			throw new java.nio.ReadOnlyBufferException();
		}

		[Sharpen.OverridesMethod(@"java.nio.FloatBuffer")]
		public override java.nio.FloatBuffer slice()
		{
			return new java.nio.ReadOnlyFloatArrayBuffer(remaining(), backingArray, offset + 
				_position);
		}
	}
}

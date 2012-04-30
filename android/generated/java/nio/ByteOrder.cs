using Sharpen;

namespace java.nio
{
	/// <summary>Defines byte order constants.</summary>
	/// <remarks>Defines byte order constants.</remarks>
	[Sharpen.Sharpened]
	public sealed class ByteOrder
	{
		private static readonly java.nio.ByteOrder NATIVE_ORDER;

		/// <summary>This constant represents big endian.</summary>
		/// <remarks>This constant represents big endian.</remarks>
		public static readonly java.nio.ByteOrder BIG_ENDIAN;

		/// <summary>This constant represents little endian.</summary>
		/// <remarks>This constant represents little endian.</remarks>
		public static readonly java.nio.ByteOrder LITTLE_ENDIAN;

		static ByteOrder()
		{
			bool isLittleEndian = Sharpen.Util.IsLittleEndian();
			BIG_ENDIAN = new java.nio.ByteOrder("BIG_ENDIAN", isLittleEndian);
			LITTLE_ENDIAN = new java.nio.ByteOrder("LITTLE_ENDIAN", !isLittleEndian);
			NATIVE_ORDER = isLittleEndian ? LITTLE_ENDIAN : BIG_ENDIAN;
		}

		private readonly string name;

		/// <summary>
		/// This is the only thing that ByteOrder is really used for: to know whether we need to swap
		/// bytes to get this order, given bytes in native order.
		/// </summary>
		/// <remarks>
		/// This is the only thing that ByteOrder is really used for: to know whether we need to swap
		/// bytes to get this order, given bytes in native order. (That is, this is the opposite of
		/// the hypothetical "isNativeOrder".)
		/// </remarks>
		/// <hide>- needed in libcore.io too.</hide>
		public readonly bool needsSwap;

		private ByteOrder(string name, bool needsSwap)
		{
			this.name = name;
			this.needsSwap = needsSwap;
		}

		/// <summary>Returns the current platform byte order.</summary>
		/// <remarks>Returns the current platform byte order.</remarks>
		/// <returns>
		/// the byte order object, which is either LITTLE_ENDIAN or
		/// BIG_ENDIAN.
		/// </returns>
		public static java.nio.ByteOrder nativeOrder()
		{
			return NATIVE_ORDER;
		}

		/// <summary>Returns a string that describes this object.</summary>
		/// <remarks>Returns a string that describes this object.</remarks>
		/// <returns>
		/// "BIG_ENDIAN" for
		/// <see cref="BIG_ENDIAN">ByteOrder.BIG_ENDIAN</see>
		/// objects, "LITTLE_ENDIAN" for
		/// <see cref="LITTLE_ENDIAN">ByteOrder.LITTLE_ENDIAN</see>
		/// objects.
		/// </returns>
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			return name;
		}
	}
}

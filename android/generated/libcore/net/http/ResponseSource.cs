using Sharpen;

namespace libcore.net.http
{
	internal enum ResponseSource
	{
		/// <summary>Return the response from the cache immediately.</summary>
		/// <remarks>Return the response from the cache immediately.</remarks>
		CACHE,
		/// <summary>
		/// Make a conditional request to the host, returning the cache response if
		/// the cache is valid and the network response otherwise.
		/// </summary>
		/// <remarks>
		/// Make a conditional request to the host, returning the cache response if
		/// the cache is valid and the network response otherwise.
		/// </remarks>
		CONDITIONAL_CACHE,
		/// <summary>Return the response from the network.</summary>
		/// <remarks>Return the response from the network.</remarks>
		NETWORK
	}
}

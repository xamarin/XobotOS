using Sharpen;

namespace android.util
{
	/// <summary>
	/// Thrown when code requests a
	/// <see cref="Property{T, V}">Property&lt;T, V&gt;</see>
	/// on a class that does
	/// not expose the appropriate method or field.
	/// </summary>
	/// <seealso cref="Property{T, V}.of{T, V}(System.Type{T}, System.Type{T}, string)">Property&lt;T, V&gt;.of&lt;T, V&gt;(System.Type&lt;T&gt;, System.Type&lt;T&gt;, string)
	/// 	</seealso>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class NoSuchPropertyException : java.lang.RuntimeException
	{
		public NoSuchPropertyException(string s) : base(s)
		{
		}
	}
}

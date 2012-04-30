using Sharpen;

namespace android.util
{
	/// <summary>A structure, name or value type in a JSON-encoded string.</summary>
	/// <remarks>A structure, name or value type in a JSON-encoded string.</remarks>
	public enum JsonToken
	{
		/// <summary>The opening of a JSON array.</summary>
		BEGIN_ARRAY,
		/// <summary>The closing of a JSON array.</summary>
		END_ARRAY,
		/// <summary>The opening of a JSON object.</summary>
		BEGIN_OBJECT,
		/// <summary>The closing of a JSON object.</summary>
		END_OBJECT,
		/// <summary>A JSON property name.</summary>
		NAME,
		/// <summary>A JSON string.</summary>
		/// <remarks>A JSON string.</remarks>
		STRING,
		/// <summary>
		/// A JSON number represented in this API by a Java
		/// <code>double</code>
		/// ,
		/// <code>long</code>
		/// , or
		/// <code>int</code>
		/// .
		/// </summary>
		NUMBER,
		/// <summary>
		/// A JSON
		/// <code>true</code>
		/// or
		/// <code>false</code>
		/// .
		/// </summary>
		BOOLEAN,
		/// <summary>
		/// A JSON
		/// <code>null</code>
		/// .
		/// </summary>
		NULL,
		/// <summary>The end of the JSON stream.</summary>
		END_DOCUMENT
	}
}

using Sharpen;

namespace android.util
{
	/// <summary>Lexical scoping elements within a JSON reader or writer.</summary>
	/// <remarks>Lexical scoping elements within a JSON reader or writer.</remarks>
	internal enum JsonScope
	{
		/// <summary>
		/// An array with no elements requires no separators or newlines before
		/// it is closed.
		/// </summary>
		/// <remarks>
		/// An array with no elements requires no separators or newlines before
		/// it is closed.
		/// </remarks>
		EMPTY_ARRAY,
		/// <summary>
		/// A array with at least one value requires a comma and newline before
		/// the next element.
		/// </summary>
		/// <remarks>
		/// A array with at least one value requires a comma and newline before
		/// the next element.
		/// </remarks>
		NONEMPTY_ARRAY,
		/// <summary>
		/// An object with no name/value pairs requires no separators or newlines
		/// before it is closed.
		/// </summary>
		/// <remarks>
		/// An object with no name/value pairs requires no separators or newlines
		/// before it is closed.
		/// </remarks>
		EMPTY_OBJECT,
		/// <summary>An object whose most recent element is a key.</summary>
		/// <remarks>
		/// An object whose most recent element is a key. The next element must
		/// be a value.
		/// </remarks>
		DANGLING_NAME,
		/// <summary>
		/// An object with at least one name/value pair requires a comma and
		/// newline before the next element.
		/// </summary>
		/// <remarks>
		/// An object with at least one name/value pair requires a comma and
		/// newline before the next element.
		/// </remarks>
		NONEMPTY_OBJECT,
		/// <summary>No object or array has been started.</summary>
		/// <remarks>No object or array has been started.</remarks>
		EMPTY_DOCUMENT,
		/// <summary>A document with at an array or object.</summary>
		/// <remarks>A document with at an array or object.</remarks>
		NONEMPTY_DOCUMENT,
		/// <summary>A document that's been closed and cannot be accessed.</summary>
		/// <remarks>A document that's been closed and cannot be accessed.</remarks>
		CLOSED
	}
}

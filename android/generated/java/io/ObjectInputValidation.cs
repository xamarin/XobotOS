using Sharpen;

namespace java.io
{
	/// <summary>A callback interface for post-deserialization checks on objects.</summary>
	/// <remarks>
	/// A callback interface for post-deserialization checks on objects. Allows, for
	/// example, the validation of a whole graph of objects after all of them have
	/// been loaded.
	/// </remarks>
	/// <seealso cref="ObjectInputStream.registerValidation(ObjectInputValidation, int)">ObjectInputStream.registerValidation(ObjectInputValidation, int)
	/// 	</seealso>
	[Sharpen.Sharpened]
	public interface ObjectInputValidation
	{
		/// <summary>Validates this object.</summary>
		/// <remarks>Validates this object.</remarks>
		/// <exception cref="InvalidObjectException">if this object fails to validate itself.
		/// 	</exception>
		/// <exception cref="java.io.InvalidObjectException"></exception>
		void validateObject();
	}
}

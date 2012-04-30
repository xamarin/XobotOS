using Sharpen;

namespace java.io
{
	/// <summary>
	/// Defines an interface for classes that want to be serializable, but have their
	/// own binary representation.
	/// </summary>
	/// <remarks>
	/// Defines an interface for classes that want to be serializable, but have their
	/// own binary representation.
	/// </remarks>
	[Sharpen.Sharpened]
	public interface Externalizable
	{
		/// <summary>Reads the next object from the ObjectInput <code>input</code>.</summary>
		/// <remarks>Reads the next object from the ObjectInput <code>input</code>.</remarks>
		/// <param name="input">the ObjectInput from which the next object is read.</param>
		/// <exception cref="IOException">
		/// if an error occurs attempting to read from
		/// <code>input</code>
		/// .
		/// </exception>
		/// <exception cref="java.lang.ClassNotFoundException">if the class of the instance being loaded cannot be found.
		/// 	</exception>
		/// <exception cref="System.IO.IOException"></exception>
		void readExternal(java.io.ObjectInput input);

		/// <summary>Writes the receiver to the ObjectOutput <code>output</code>.</summary>
		/// <remarks>Writes the receiver to the ObjectOutput <code>output</code>.</remarks>
		/// <param name="output">the ObjectOutput to write the object to.</param>
		/// <exception cref="IOException">
		/// if an error occurs attempting to write to
		/// <code>output</code>
		/// .
		/// </exception>
		/// <exception cref="System.IO.IOException"></exception>
		void writeExternal(java.io.ObjectOutput output);
	}
}

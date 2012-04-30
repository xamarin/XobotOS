using Sharpen;

namespace java.lang
{
	/// <summary>
	/// Thrown if an
	/// <code>enum</code>
	/// constant does not exist for a particular name.
	/// </summary>
	/// <since>1.5</since>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class EnumConstantNotPresentException : java.lang.RuntimeException
	{
		internal const long serialVersionUID = -6046998521960521108L;

		private readonly System.Type _enumType;

		private readonly string _constantName;

		/// <summary>
		/// Constructs a new
		/// <code>EnumConstantNotPresentException</code>
		/// with the current
		/// stack trace and a detail message based on the specified enum type and
		/// missing constant name.
		/// </summary>
		/// <param name="enumType">the enum type.</param>
		/// <param name="constantName">the missing constant name.</param>
		public EnumConstantNotPresentException(System.Type enumType_1, string constantName_1
			) : base("enum constant " + enumType_1.FullName + "." + constantName_1 + " is missing"
			)
		{
			this._enumType = enumType_1;
			this._constantName = constantName_1;
		}

		/// <summary>Gets the enum type for which the constant name is missing.</summary>
		/// <remarks>Gets the enum type for which the constant name is missing.</remarks>
		/// <returns>the enum type for which a constant name has not been found.</returns>
		public virtual System.Type enumType()
		{
			return _enumType;
		}

		/// <summary>Gets the name of the missing constant.</summary>
		/// <remarks>Gets the name of the missing constant.</remarks>
		/// <returns>
		/// the name of the constant that has not been found in the enum
		/// type.
		/// </returns>
		public virtual string constantName()
		{
			return _constantName;
		}
	}
}

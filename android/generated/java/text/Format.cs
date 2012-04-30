using Sharpen;

namespace java.text
{
	[System.Serializable]
	[Sharpen.Stub]
	public abstract class Format : System.ICloneable
	{
		internal const long serialVersionUID = -299282585814624189L;

		[Sharpen.Stub]
		protected internal Format()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual object clone()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public string format(object @object)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public abstract java.lang.StringBuffer format(object @object, java.lang.StringBuffer
			 buffer, java.text.FieldPosition field);

		[Sharpen.Stub]
		public virtual java.text.AttributedCharacterIterator formatToCharacterIterator(object
			 @object)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual object parseObject(string @string)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public abstract object parseObject(string @string, java.text.ParsePosition position
			);

		[Sharpen.Stub]
		internal static bool upTo(string @string, java.text.ParsePosition position, java.lang.StringBuffer
			 buffer, char stop)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal static bool upToWithQuotes(string @string, java.text.ParsePosition position
			, java.lang.StringBuffer buffer, char stop, char start)
		{
			throw new System.NotImplementedException();
		}

		[System.Serializable]
		[Sharpen.Stub]
		public class Field : java.text.AttributedCharacterIteratorClass.Attribute
		{
			internal const long serialVersionUID = 276966692217360283L;

			[Sharpen.Stub]
			protected internal Field(string fieldName) : base(fieldName)
			{
				throw new System.NotImplementedException();
			}
		}

		object System.ICloneable.Clone()
		{
			return MemberwiseClone();
		}
	}
}

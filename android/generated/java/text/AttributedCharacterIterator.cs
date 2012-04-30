using Sharpen;

namespace java.text
{
	[Sharpen.Stub]
	public interface AttributedCharacterIterator : java.text.CharacterIterator
	{
		[Sharpen.Stub]
		java.util.Set<java.text.AttributedCharacterIteratorClass.Attribute> getAllAttributeKeys
			();

		[Sharpen.Stub]
		object getAttribute(java.text.AttributedCharacterIteratorClass.Attribute attribute
			);

		[Sharpen.Stub]
		java.util.Map<java.text.AttributedCharacterIteratorClass.Attribute, object> getAttributes
			();

		[Sharpen.Stub]
		int getRunLimit();

		[Sharpen.Stub]
		int getRunLimit(java.text.AttributedCharacterIteratorClass.Attribute attribute);

		[Sharpen.Stub]
		int getRunLimit<_T0>(java.util.Set<_T0> attributes) where _T0:java.text.AttributedCharacterIteratorClass
			.Attribute;

		[Sharpen.Stub]
		int getRunStart();

		[Sharpen.Stub]
		int getRunStart(java.text.AttributedCharacterIteratorClass.Attribute attribute);

		[Sharpen.Stub]
		int getRunStart<_T0>(java.util.Set<_T0> attributes) where _T0:java.text.AttributedCharacterIteratorClass
			.Attribute;
	}

	[Sharpen.Stub]
	public static class AttributedCharacterIteratorClass
	{
		[System.Serializable]
		[Sharpen.Stub]
		public class Attribute
		{
			internal const long serialVersionUID = -9142742483513960612L;

			public static readonly java.text.AttributedCharacterIteratorClass.Attribute INPUT_METHOD_SEGMENT
				 = new java.text.AttributedCharacterIteratorClass.Attribute("input_method_segment"
				);

			public static readonly java.text.AttributedCharacterIteratorClass.Attribute LANGUAGE
				 = new java.text.AttributedCharacterIteratorClass.Attribute("language");

			public static readonly java.text.AttributedCharacterIteratorClass.Attribute READING
				 = new java.text.AttributedCharacterIteratorClass.Attribute("reading");

			private string name;

			[Sharpen.Stub]
			protected internal Attribute(string name)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public sealed override bool Equals(object @object)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			protected internal virtual string getName()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public sealed override int GetHashCode()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			protected internal virtual object readResolve()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override string ToString()
			{
				throw new System.NotImplementedException();
			}
		}
	}
}

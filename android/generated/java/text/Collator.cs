using Sharpen;

namespace java.text
{
	[Sharpen.Stub]
	public abstract class Collator : java.util.Comparator<object>, System.ICloneable
	{
		public const int NO_DECOMPOSITION = 0;

		public const int CANONICAL_DECOMPOSITION = 1;

		public const int FULL_DECOMPOSITION = 2;

		public const int PRIMARY = 0;

		public const int SECONDARY = 1;

		public const int TERTIARY = 2;

		public const int IDENTICAL = 3;

		internal libcore.icu.RuleBasedCollatorICU icuColl;

		[Sharpen.Stub]
		internal Collator(libcore.icu.RuleBasedCollatorICU icuColl)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal Collator()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual object clone()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.util.Comparator")]
		public virtual int compare(object object1, object object2)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public abstract int compare(string string1, string string2);

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override bool Equals(object @object)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool equals(string string1, string string2)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static System.Globalization.CultureInfo[] getAvailableLocales()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public abstract java.text.CollationKey getCollationKey(string @string);

		[Sharpen.Stub]
		public virtual int getDecomposition()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.text.Collator getInstance()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.text.Collator getInstance(System.Globalization.CultureInfo locale
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getStrength()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public abstract override int GetHashCode();

		[Sharpen.Stub]
		public virtual void setDecomposition(int value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setStrength(int value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private int decompositionMode_Java_ICU(int mode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private int decompositionMode_ICU_Java(int mode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private int strength_Java_ICU(int value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private int strength_ICU_Java(int value)
		{
			throw new System.NotImplementedException();
		}

		object System.ICloneable.Clone()
		{
			return MemberwiseClone();
		}
	}
}

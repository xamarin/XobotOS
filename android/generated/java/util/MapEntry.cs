using Sharpen;

namespace java.util
{
	/// <summary>MapEntry is an internal class which provides an implementation of Map.Entry.
	/// 	</summary>
	/// <remarks>MapEntry is an internal class which provides an implementation of Map.Entry.
	/// 	</remarks>
	[Sharpen.Sharpened]
	internal static class MapEntry
	{
		internal interface Type<RT, KT, VT>
		{
			RT get(java.util.MapEntry<KT, VT> entry);
		}
	}

	/// <summary>MapEntry is an internal class which provides an implementation of Map.Entry.
	/// 	</summary>
	/// <remarks>MapEntry is an internal class which provides an implementation of Map.Entry.
	/// 	</remarks>
	[Sharpen.Sharpened]
	internal class MapEntry<K, V> : java.util.MapClass.Entry<K, V>, System.ICloneable
	{
		internal K key;

		internal V value;

		internal MapEntry(K theKey)
		{
			key = theKey;
		}

		internal MapEntry(K theKey, V theValue)
		{
			key = theKey;
			value = theValue;
		}

		public virtual object clone()
		{
			return base.MemberwiseClone();
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override bool Equals(object @object)
		{
			if (this == @object)
			{
				return true;
			}
			if (@object is java.util.MapClass.Entry<K, V>)
			{
				java.util.MapClass.Entry<object, object> entry = (java.util.MapClass.Entry<object
					, object>)@object;
				return ((object)key == null ? entry.getKey() == null : key.Equals(entry.getKey())
					) && ((object)value == null ? entry.getValue() == null : value.Equals(entry.getValue
					()));
			}
			return false;
		}

		[Sharpen.ImplementsInterface(@"java.util.Map.Entry")]
		public virtual K getKey()
		{
			return key;
		}

		[Sharpen.ImplementsInterface(@"java.util.Map.Entry")]
		public virtual V getValue()
		{
			return value;
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override int GetHashCode()
		{
			return ((object)key == null ? 0 : key.GetHashCode()) ^ ((object)value == null ? 0
				 : value.GetHashCode());
		}

		[Sharpen.ImplementsInterface(@"java.util.Map.Entry")]
		public virtual V setValue(V @object)
		{
			V result = value;
			value = @object;
			return result;
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			return key + "=" + value;
		}

		object System.ICloneable.Clone()
		{
			return MemberwiseClone();
		}
	}
}

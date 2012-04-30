using Sharpen;

namespace java.util
{
	/// <summary>A map whose entries are sorted by their keys.</summary>
	/// <remarks>
	/// A map whose entries are sorted by their keys. All optional operations such as
	/// <see cref="TreeMap{K, V}.put(object, object)">TreeMap&lt;K, V&gt;.put(object, object)
	/// 	</see>
	/// and
	/// <see cref="TreeMap{K, V}.remove(object)">TreeMap&lt;K, V&gt;.remove(object)</see>
	/// are supported.
	/// <p>This map sorts keys using either a user-supplied comparator or the key's
	/// natural order:
	/// <ul>
	/// <li>User supplied comparators must be able to compare any pair of keys in
	/// this map. If a user-supplied comparator is in use, it will be returned
	/// by
	/// <see cref="TreeMap{K, V}._comparator">TreeMap&lt;K, V&gt;._comparator</see>
	/// .
	/// <li>If no user-supplied comparator is supplied, keys will be sorted by
	/// their natural order. Keys must be <i>mutually comparable</i>: they must
	/// implement
	/// <see cref="java.lang.Comparable{T}">java.lang.Comparable&lt;T&gt;</see>
	/// and
	/// <see cref="java.lang.Comparable{T}.compareTo(object)">compareTo()</see>
	/// must be able to compare each key with any other key in
	/// this map. In this case
	/// <see cref="TreeMap{K, V}._comparator">TreeMap&lt;K, V&gt;._comparator</see>
	/// will return null.
	/// </ul>
	/// With either a comparator or a natural ordering, comparisons should be
	/// <i>consistent with equals</i>. An ordering is consistent with equals if for
	/// every pair of keys
	/// <code>a</code>
	/// and
	/// <code>b</code>
	/// ,
	/// <code>a.equals(b)</code>
	/// if and only
	/// if
	/// <code>compare(a, b) == 0</code>
	/// .
	/// <p>When the ordering is not consistent with equals the behavior of this
	/// class is well defined but does not honor the contract specified by
	/// <see cref="Map{K, V}">Map&lt;K, V&gt;</see>
	/// . Consider a tree map of case-insensitive strings, an ordering that is
	/// not consistent with equals: <pre>
	/// <code>
	/// TreeMap<String, String> map = new TreeMap<String, String>(String.CASE_INSENSITIVE_ORDER);
	/// map.put("a", "android");
	/// // The Map API specifies that the next line should print "null" because
	/// // "a".equals("A") is false and there is no mapping for upper case "A".
	/// // But the case insensitive ordering says compare("a", "A") == 0. TreeMap
	/// // uses only comparators/comparable on keys and so this prints "android".
	/// System.out.println(map.get("A"));
	/// </code>
	/// </pre>
	/// </remarks>
	/// <since>1.2</since>
	[Sharpen.Sharpened]
	public static partial class TreeMap
	{
		internal class Relation
		{
			public readonly int ID;

			protected Relation(int ID)
			{
				this.ID = ID;
			}

			public static readonly Relation LOWER = new Relation(LOWER_ID);

			public const int LOWER_ID = 1;

			public static readonly Relation FLOOR = new Relation(FLOOR_ID);

			public const int FLOOR_ID = 2;

			public static readonly Relation EQUAL = new Relation(EQUAL_ID);

			public const int EQUAL_ID = 3;

			public static readonly Relation CREATE = new Relation(CREATE_ID);

			public const int CREATE_ID = 4;

			public static readonly Relation CEILING = new Relation(CEILING_ID);

			public const int CEILING_ID = 5;

			public static readonly Relation HIGHER = new Relation(HIGHER_ID);

			public const int HIGHER_ID = 6;

			// to avoid Comparable<Comparable<Comparable<...>>>
			// unsafe! this assumes K is comparable
			// unsafe! if comparator is null, this assumes K is comparable
			// if copyFrom's keys are comparable this map's keys must be also
			// super.clone() must return the same type
			/// <summary>Returns a possibly-flipped relation for use in descending views.</summary>
			/// <remarks>Returns a possibly-flipped relation for use in descending views.</remarks>
			/// <param name="ascending">false to flip; true to return this.</param>
			internal virtual java.util.TreeMap.Relation forOrder(bool ascending)
			{
				if (ascending)
				{
					return this;
				}
				switch (this.ID)
				{
					case java.util.TreeMap.Relation.LOWER_ID:
					{
						return java.util.TreeMap.Relation.HIGHER;
					}

					case java.util.TreeMap.Relation.FLOOR_ID:
					{
						return java.util.TreeMap.Relation.CEILING;
					}

					case java.util.TreeMap.Relation.EQUAL_ID:
					{
						return java.util.TreeMap.Relation.EQUAL;
					}

					case java.util.TreeMap.Relation.CEILING_ID:
					{
						return java.util.TreeMap.Relation.FLOOR;
					}

					case java.util.TreeMap.Relation.HIGHER_ID:
					{
						return java.util.TreeMap.Relation.LOWER;
					}

					default:
					{
						throw new System.InvalidOperationException();
					}
				}
			}
		}

		internal class Node<K, V> : java.util.MapClass.Entry<K, V>
		{
			internal java.util.TreeMap.Node<K, V> parent;

			internal java.util.TreeMap.Node<K, V> left;

			internal java.util.TreeMap.Node<K, V> right;

			internal readonly K key;

			internal V value;

			internal int height;

			internal Node(java.util.TreeMap.Node<K, V> parent, K key)
			{
				// NullPointerException ok
				// will throw a ClassCastException below if there's trouble
				// nearest.key is higher
				// comparison > 0, nearest.key is lower
				// this method throws ClassCastExceptions!
				// takes care of rebalance and size--
				// AVL right right
				// AVL right left
				// no further rotations will be necessary
				// AVL left left
				// AVL left right
				// no further rotations will be necessary
				// leftHeight == rightHeight
				// the insert caused balance, so rebalancing is done!
				// the height hasn't changed, so rebalancing is done!
				// move the pivot's left child to the root's right
				// move the root to the pivot's left
				// fix heights
				// move the pivot's right child to the root's left
				// move the root to the pivot's right
				// fixup heights
				this.parent = parent;
				this.key = key;
				this.height = 1;
			}

			internal virtual java.util.TreeMap.Node<K, V> copy(java.util.TreeMap.Node<K, V> parent
				)
			{
				java.util.TreeMap.Node<K, V> result = new java.util.TreeMap.Node<K, V>(parent, key
					);
				if (left != null)
				{
					result.left = left.copy(result);
				}
				if (right != null)
				{
					result.right = right.copy(result);
				}
				result.value = value;
				result.height = height;
				return result;
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

			[Sharpen.ImplementsInterface(@"java.util.Map.Entry")]
			public virtual V setValue(V value)
			{
				V oldValue = this.value;
				this.value = value;
				return oldValue;
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override bool Equals(object o)
			{
				if (o is java.util.MapClass.Entry<K, V>)
				{
					java.util.MapClass.Entry<K, V> other = (java.util.MapClass.Entry<K, V>)o;
					return ((object)key == null ? other.getKey() == null : key.Equals(other.getKey())
						) && ((object)value == null ? other.getValue() == null : value.Equals(other.getValue
						()));
				}
				return false;
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override int GetHashCode()
			{
				return ((object)key == null ? 0 : key.GetHashCode()) ^ ((object)value == null ? 0
					 : value.GetHashCode());
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override string ToString()
			{
				return key + "=" + value;
			}

			/// <summary>
			/// Returns the next node in an inorder traversal, or null if this is the
			/// last node in the tree.
			/// </summary>
			/// <remarks>
			/// Returns the next node in an inorder traversal, or null if this is the
			/// last node in the tree.
			/// </remarks>
			internal virtual java.util.TreeMap.Node<K, V> next()
			{
				if (right != null)
				{
					return right.first();
				}
				java.util.TreeMap.Node<K, V> node = this;
				java.util.TreeMap.Node<K, V> parent = node.parent;
				while (parent != null)
				{
					if (parent.left == node)
					{
						return parent;
					}
					node = parent;
					parent = node.parent;
				}
				return null;
			}

			/// <summary>
			/// Returns the previous node in an inorder traversal, or null if this is
			/// the first node in the tree.
			/// </summary>
			/// <remarks>
			/// Returns the previous node in an inorder traversal, or null if this is
			/// the first node in the tree.
			/// </remarks>
			internal virtual java.util.TreeMap.Node<K, V> prev()
			{
				if (left != null)
				{
					return left.last();
				}
				java.util.TreeMap.Node<K, V> node = this;
				java.util.TreeMap.Node<K, V> parent = node.parent;
				while (parent != null)
				{
					if (parent.right == node)
					{
						return parent;
					}
					node = parent;
					parent = node.parent;
				}
				return null;
			}

			/// <summary>Returns the first node in this subtree.</summary>
			/// <remarks>Returns the first node in this subtree.</remarks>
			internal virtual java.util.TreeMap.Node<K, V> first()
			{
				java.util.TreeMap.Node<K, V> node = this;
				java.util.TreeMap.Node<K, V> child = node.left;
				while (child != null)
				{
					node = child;
					child = node.left;
				}
				return node;
			}

			/// <summary>Returns the last node in this subtree.</summary>
			/// <remarks>Returns the last node in this subtree.</remarks>
			internal virtual java.util.TreeMap.Node<K, V> last()
			{
				java.util.TreeMap.Node<K, V> node = this;
				java.util.TreeMap.Node<K, V> child = node.right;
				while (child != null)
				{
					node = child;
					child = node.right;
				}
				return node;
			}
		}

		internal sealed class _Bound_1064 : java.util.TreeMap.Bound
		{
			public _Bound_1064() : base(INCLUSIVE_ID)
			{
			}

			[Sharpen.OverridesMethod(@"java.util.TreeMap.Bound")]
			public override string leftCap(object from)
			{
				return "[" + from;
			}

			[Sharpen.OverridesMethod(@"java.util.TreeMap.Bound")]
			public override string rightCap(object to)
			{
				return to + "]";
			}
		}

		internal sealed class _Bound_1072 : java.util.TreeMap.Bound
		{
			public _Bound_1072() : base(EXCLUSIVE_ID)
			{
			}

			[Sharpen.OverridesMethod(@"java.util.TreeMap.Bound")]
			public override string leftCap(object from)
			{
				return "(" + from;
			}

			[Sharpen.OverridesMethod(@"java.util.TreeMap.Bound")]
			public override string rightCap(object to)
			{
				return to + ")";
			}
		}

		internal sealed class _Bound_1080 : java.util.TreeMap.Bound
		{
			public _Bound_1080() : base(NO_BOUND_ID)
			{
			}

			[Sharpen.OverridesMethod(@"java.util.TreeMap.Bound")]
			public override string leftCap(object from)
			{
				return ".";
			}

			[Sharpen.OverridesMethod(@"java.util.TreeMap.Bound")]
			public override string rightCap(object to)
			{
				return ".";
			}
		}

		internal abstract class Bound
		{
			public readonly int ID;

			protected Bound(int ID)
			{
				this.ID = ID;
			}

			public static readonly Bound INCLUSIVE = new _Bound_1064();

			public const int INCLUSIVE_ID = 1;

			public static readonly Bound EXCLUSIVE = new _Bound_1072();

			public const int EXCLUSIVE_ID = 2;

			public static readonly Bound NO_BOUND = new _Bound_1080();

			public const int NO_BOUND_ID = 3;

			public abstract string leftCap(object from);

			public abstract string rightCap(object to);
		}

		internal const long serialVersionUID = 919286545866124006L;

		internal static class NavigableSubMap
		{
			internal const long serialVersionUID = -2102997345730753016L;
		}

		[System.Serializable]
		internal abstract class NavigableSubMap<K, V> : java.util.AbstractMap<K, V>
		{
			internal java.util.TreeMap<K, V> m;

			internal object lo;

			internal object hi;

			internal bool fromStart;

			internal bool toEnd;

			internal bool loInclusive;

			internal bool hiInclusive;

			internal NavigableSubMap(java.util.TreeMap<K, V> @delegate, K from, java.util.TreeMap
				.Bound fromBound, K to, java.util.TreeMap.Bound toBound)
			{
				// this method throws ClassCastExceptions!
				// less than from
				// less than or equal to from
				// greater than 'to'
				// greater than or equal to 'to'
				// 'to' is too high
				// we already went lower
				// we've already checked the upper bound
				// 'from' is too low
				// we already went higher
				// we've already checked the lower bound
				// we have to trust that keys are Ks and values are Vs
				this.m = @delegate;
				this.lo = from;
				this.hi = to;
				this.fromStart = fromBound == java.util.TreeMap.Bound.NO_BOUND;
				this.toEnd = toBound == java.util.TreeMap.Bound.NO_BOUND;
				this.loInclusive = fromBound == java.util.TreeMap.Bound.INCLUSIVE;
				this.hiInclusive = toBound == java.util.TreeMap.Bound.INCLUSIVE;
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractMap")]
			public override java.util.Set<java.util.MapClass.Entry<K, V>> entrySet()
			{
				throw new System.NotSupportedException();
			}

			/// <exception cref="java.io.ObjectStreamException"></exception>
			protected internal virtual object readResolve()
			{
				// we have to trust that the bounds are Ks
				java.util.TreeMap.Bound fromBound = fromStart ? java.util.TreeMap.Bound.NO_BOUND : 
					(loInclusive ? java.util.TreeMap.Bound.INCLUSIVE : java.util.TreeMap.Bound.EXCLUSIVE
					);
				java.util.TreeMap.Bound toBound = toEnd ? java.util.TreeMap.Bound.NO_BOUND : (hiInclusive
					 ? java.util.TreeMap.Bound.INCLUSIVE : java.util.TreeMap.Bound.EXCLUSIVE);
				bool ascending = !(this is java.util.TreeMap.DescendingSubMap<K, V>);
				return new java.util.TreeMap<K, V>.BoundedMap(m, ascending, (K)lo, fromBound, (K)
					hi, toBound);
			}
		}

		internal static class DescendingSubMap
		{
			internal const long serialVersionUID = 912986545866120460L;
		}

		[System.Serializable]
		internal class DescendingSubMap<K, V> : java.util.TreeMap.NavigableSubMap<K, V>
		{
			internal java.util.Comparator<K> reverseComparator;

			internal DescendingSubMap(java.util.TreeMap<K, V> @delegate, K from, java.util.TreeMap
				.Bound fromBound, K to, java.util.TreeMap.Bound toBound) : base(@delegate, from, 
				fromBound, to, toBound)
			{
			}
		}

		internal static class AscendingSubMap
		{
			internal const long serialVersionUID = 912986545866124060L;
		}

		[System.Serializable]
		internal class AscendingSubMap<K, V> : java.util.TreeMap.NavigableSubMap<K, V>
		{
			internal AscendingSubMap(java.util.TreeMap<K, V> @delegate, K from, java.util.TreeMap
				.Bound fromBound, K to, java.util.TreeMap.Bound toBound) : base(@delegate, from, 
				fromBound, to, toBound)
			{
			}
		}
	}

	/// <summary>A map whose entries are sorted by their keys.</summary>
	/// <remarks>
	/// A map whose entries are sorted by their keys. All optional operations such as
	/// <see cref="TreeMap{K, V}.put(object, object)">TreeMap&lt;K, V&gt;.put(object, object)
	/// 	</see>
	/// and
	/// <see cref="TreeMap{K, V}.remove(object)">TreeMap&lt;K, V&gt;.remove(object)</see>
	/// are supported.
	/// <p>This map sorts keys using either a user-supplied comparator or the key's
	/// natural order:
	/// <ul>
	/// <li>User supplied comparators must be able to compare any pair of keys in
	/// this map. If a user-supplied comparator is in use, it will be returned
	/// by
	/// <see cref="TreeMap{K, V}._comparator">TreeMap&lt;K, V&gt;._comparator</see>
	/// .
	/// <li>If no user-supplied comparator is supplied, keys will be sorted by
	/// their natural order. Keys must be <i>mutually comparable</i>: they must
	/// implement
	/// <see cref="java.lang.Comparable{T}">java.lang.Comparable&lt;T&gt;</see>
	/// and
	/// <see cref="java.lang.Comparable{T}.compareTo(object)">compareTo()</see>
	/// must be able to compare each key with any other key in
	/// this map. In this case
	/// <see cref="TreeMap{K, V}._comparator">TreeMap&lt;K, V&gt;._comparator</see>
	/// will return null.
	/// </ul>
	/// With either a comparator or a natural ordering, comparisons should be
	/// <i>consistent with equals</i>. An ordering is consistent with equals if for
	/// every pair of keys
	/// <code>a</code>
	/// and
	/// <code>b</code>
	/// ,
	/// <code>a.equals(b)</code>
	/// if and only
	/// if
	/// <code>compare(a, b) == 0</code>
	/// .
	/// <p>When the ordering is not consistent with equals the behavior of this
	/// class is well defined but does not honor the contract specified by
	/// <see cref="Map{K, V}">Map&lt;K, V&gt;</see>
	/// . Consider a tree map of case-insensitive strings, an ordering that is
	/// not consistent with equals: <pre>
	/// <code>
	/// TreeMap<String, String> map = new TreeMap<String, String>(String.CASE_INSENSITIVE_ORDER);
	/// map.put("a", "android");
	/// // The Map API specifies that the next line should print "null" because
	/// // "a".equals("A") is false and there is no mapping for upper case "A".
	/// // But the case insensitive ordering says compare("a", "A") == 0. TreeMap
	/// // uses only comparators/comparable on keys and so this prints "android".
	/// System.out.println(map.get("A"));
	/// </code>
	/// </pre>
	/// </remarks>
	/// <since>1.2</since>
	[System.Serializable]
	[Sharpen.Sharpened]
	public partial class TreeMap<K, V> : java.util.AbstractMap<K, V>, java.util.SortedMap
		<K, V>, java.util.NavigableMap<K, V>, System.ICloneable
	{
		private sealed class _Comparator_70 : java.util.Comparator<java.lang.Comparable<object
			>>
		{
			public _Comparator_70()
			{
			}

			[Sharpen.ImplementsInterface(@"java.util.Comparator")]
			public int compare(java.lang.Comparable<object> a, java.lang.Comparable<object> b
				)
			{
				return a.compareTo(b);
			}
		}

		private static readonly java.util.Comparator<java.lang.Comparable<object>> NATURAL_ORDER
			 = new _Comparator_70();

		internal java.util.Comparator<K> _comparator;

		internal java.util.TreeMap.Node<K, V> root;

		internal int _size = 0;

		internal int modCount = 0;

		/// <summary>
		/// Create a natural order, empty tree map whose keys must be mutually
		/// comparable and non-null.
		/// </summary>
		/// <remarks>
		/// Create a natural order, empty tree map whose keys must be mutually
		/// comparable and non-null.
		/// </remarks>
		public TreeMap()
		{
			this._comparator = (java.util.Comparator<K>)NATURAL_ORDER;
		}

		/// <summary>
		/// Create a natural order tree map populated with the key/value pairs of
		/// <code>copyFrom</code>
		/// . This map's keys must be mutually comparable and
		/// non-null.
		/// <p>Even if
		/// <code>copyFrom</code>
		/// is a
		/// <code>SortedMap</code>
		/// , the constructed map
		/// <strong>will not</strong> use
		/// <code>copyFrom</code>
		/// 's ordering. This
		/// constructor always creates a naturally-ordered map. Because the
		/// <code>TreeMap</code>
		/// constructor overloads are ambiguous, prefer to construct a map
		/// and populate it in two steps: <pre>
		/// <code>
		/// TreeMap<String, Integer> customOrderedMap
		/// = new TreeMap<String, Integer>(copyFrom.comparator());
		/// customOrderedMap.putAll(copyFrom);
		/// </code>
		/// </pre>
		/// </summary>
		public TreeMap(java.util.Map<K, V> copyFrom) : this()
		{
			foreach (java.util.MapClass.Entry<K, V> entry in Sharpen.IterableProxy.Create(copyFrom
				.entrySet()))
			{
				putInternal(entry.getKey(), entry.getValue());
			}
		}

		/// <summary>
		/// Create a tree map ordered by
		/// <code>comparator</code>
		/// . This map's keys may only
		/// be null if
		/// <code>comparator</code>
		/// permits.
		/// </summary>
		/// <param name="comparator">
		/// the comparator to order elements with, or
		/// <code>null</code>
		/// to use the natural
		/// ordering.
		/// </param>
		public TreeMap(java.util.Comparator<K> comparator_1)
		{
			if (comparator_1 != null)
			{
				this._comparator = comparator_1;
			}
			else
			{
				this._comparator = (java.util.Comparator<K>)NATURAL_ORDER;
			}
		}

		/// <summary>
		/// Create a tree map with the ordering and key/value pairs of
		/// <code>copyFrom</code>
		/// . This map's keys may only be null if the
		/// <code>copyFrom</code>
		/// 's
		/// ordering permits.
		/// <p>The constructed map <strong>will always use</strong>
		/// <code>copyFrom</code>
		/// 's ordering. Because the
		/// <code>TreeMap</code>
		/// constructor overloads
		/// are ambigous, prefer to construct a map and populate it in two steps:
		/// <pre>
		/// <code>
		/// TreeMap<String, Integer> customOrderedMap
		/// = new TreeMap<String, Integer>(copyFrom.comparator());
		/// customOrderedMap.putAll(copyFrom);
		/// </code>
		/// </pre>
		/// </summary>
		public TreeMap(java.util.SortedMap<K, V> copyFrom)
		{
			java.util.Comparator<K> sourceComparator = copyFrom.comparator();
			if (sourceComparator != null)
			{
				this._comparator = sourceComparator;
			}
			else
			{
				this._comparator = (java.util.Comparator<K>)NATURAL_ORDER;
			}
			foreach (java.util.MapClass.Entry<K, V> entry in Sharpen.IterableProxy.Create(copyFrom
				.entrySet()))
			{
				putInternal(entry.getKey(), entry.getValue());
			}
		}

		[Sharpen.OverridesMethod(@"java.util.AbstractMap")]
		protected internal override object clone()
		{
			java.util.TreeMap<K, V> map = (java.util.TreeMap<K, V>)base.clone();
			map.root = root != null ? root.copy(null) : null;
			map._entrySet = null;
			map._keySet = null;
			return map;
		}

		[Sharpen.OverridesMethod(@"java.util.AbstractMap")]
		public override int size()
		{
			return _size;
		}

		[Sharpen.OverridesMethod(@"java.util.AbstractMap")]
		public override bool isEmpty()
		{
			return _size == 0;
		}

		[Sharpen.OverridesMethod(@"java.util.AbstractMap")]
		public override V get(object key)
		{
			java.util.MapClass.Entry<K, V> entry = findByObject(key);
			return entry != null ? entry.getValue() : default(V);
		}

		[Sharpen.OverridesMethod(@"java.util.AbstractMap")]
		public override bool containsKey(object key)
		{
			return findByObject(key) != null;
		}

		[Sharpen.OverridesMethod(@"java.util.AbstractMap")]
		public override V put(K key, V value)
		{
			return putInternal(key, value);
		}

		[Sharpen.OverridesMethod(@"java.util.AbstractMap")]
		public override void clear()
		{
			root = null;
			_size = 0;
			modCount++;
		}

		[Sharpen.OverridesMethod(@"java.util.AbstractMap")]
		public override V remove(object key)
		{
			java.util.TreeMap.Node<K, V> node = removeInternalByKey(key);
			return node != null ? node.value : default(V);
		}

		internal virtual V putInternal(K key, V value)
		{
			java.util.TreeMap.Node<K, V> created = find(key, java.util.TreeMap.Relation.CREATE
				);
			V result = created.value;
			created.value = value;
			return result;
		}

		/// <summary>Returns the node at or adjacent to the given key, creating it if requested.
		/// 	</summary>
		/// <remarks>Returns the node at or adjacent to the given key, creating it if requested.
		/// 	</remarks>
		/// <exception cref="System.InvalidCastException">
		/// if
		/// <code>key</code>
		/// and the tree's keys aren't mutually comparable.
		/// </exception>
		internal virtual java.util.TreeMap.Node<K, V> find(K key, java.util.TreeMap.Relation
			 relation)
		{
			if (root == null)
			{
				if (_comparator == NATURAL_ORDER && !(key is java.lang.Comparable<object>))
				{
					throw new System.InvalidCastException(key.GetType().FullName + " is not Comparable"
						);
				}
				if (relation == java.util.TreeMap.Relation.CREATE)
				{
					root = new java.util.TreeMap.Node<K, V>(null, key);
					_size = 1;
					modCount++;
					return root;
				}
				else
				{
					return null;
				}
			}
			java.lang.Comparable<object> comparableKey = (_comparator == NATURAL_ORDER) ? (java.lang.Comparable
				<object>)key : null;
			java.util.TreeMap.Node<K, V> nearest = root;
			while (true)
			{
				int comparison = (comparableKey != null) ? comparableKey.compareTo(nearest.key) : 
					_comparator.compare(key, nearest.key);
				if (comparison == 0)
				{
					switch (relation.ID)
					{
						case java.util.TreeMap.Relation.LOWER_ID:
						{
							return nearest.prev();
						}

						case java.util.TreeMap.Relation.FLOOR_ID:
						case java.util.TreeMap.Relation.EQUAL_ID:
						case java.util.TreeMap.Relation.CREATE_ID:
						case java.util.TreeMap.Relation.CEILING_ID:
						{
							return nearest;
						}

						case java.util.TreeMap.Relation.HIGHER_ID:
						{
							return nearest.next();
						}
					}
				}
				java.util.TreeMap.Node<K, V> child = (comparison < 0) ? nearest.left : nearest.right;
				if (child != null)
				{
					nearest = child;
					continue;
				}
				if (comparison < 0)
				{
					switch (relation.ID)
					{
						case java.util.TreeMap.Relation.LOWER_ID:
						case java.util.TreeMap.Relation.FLOOR_ID:
						{
							return nearest.prev();
						}

						case java.util.TreeMap.Relation.CEILING_ID:
						case java.util.TreeMap.Relation.HIGHER_ID:
						{
							return nearest;
						}

						case java.util.TreeMap.Relation.EQUAL_ID:
						{
							return null;
						}

						case java.util.TreeMap.Relation.CREATE_ID:
						{
							java.util.TreeMap.Node<K, V> created = new java.util.TreeMap.Node<K, V>(nearest, 
								key);
							nearest.left = created;
							_size++;
							modCount++;
							rebalance(nearest, true);
							return created;
						}
					}
				}
				else
				{
					switch (relation.ID)
					{
						case java.util.TreeMap.Relation.LOWER_ID:
						case java.util.TreeMap.Relation.FLOOR_ID:
						{
							return nearest;
						}

						case java.util.TreeMap.Relation.CEILING_ID:
						case java.util.TreeMap.Relation.HIGHER_ID:
						{
							return nearest.next();
						}

						case java.util.TreeMap.Relation.EQUAL_ID:
						{
							return null;
						}

						case java.util.TreeMap.Relation.CREATE_ID:
						{
							java.util.TreeMap.Node<K, V> created = new java.util.TreeMap.Node<K, V>(nearest, 
								key);
							nearest.right = created;
							_size++;
							modCount++;
							rebalance(nearest, true);
							return created;
						}
					}
				}
			}
		}

		internal virtual java.util.TreeMap.Node<K, V> findByObject(object key)
		{
			return find((K)key, java.util.TreeMap.Relation.EQUAL);
		}

		/// <summary>
		/// Returns this map's entry that has the same key and value as
		/// <code>entry</code>
		/// , or null if this map has no such entry.
		/// <p>This method uses the comparator for key equality rather than
		/// <code>equals</code>
		/// . If this map's comparator isn't consistent with equals (such as
		/// <code>String.CASE_INSENSITIVE_ORDER</code>
		/// ), then
		/// <code>remove()</code>
		/// and
		/// <code>contains()</code>
		/// will violate the collections API.
		/// </summary>
		internal virtual java.util.TreeMap.Node<K, V> findByEntry<_T0, _T1>(java.util.MapClass.Entry
			<_T0, _T1> entry)
		{
			java.util.TreeMap.Node<K, V> mine = findByObject(entry.getKey());
			bool valuesEqual = mine != null && libcore.util.Objects.equal(mine.value, entry.getValue
				());
			return valuesEqual ? mine : null;
		}

		/// <summary>
		/// Removes
		/// <code>node</code>
		/// from this tree, rearranging the tree's structure as
		/// necessary.
		/// </summary>
		internal virtual void removeInternal(java.util.TreeMap.Node<K, V> node)
		{
			java.util.TreeMap.Node<K, V> left = node.left;
			java.util.TreeMap.Node<K, V> right = node.right;
			java.util.TreeMap.Node<K, V> originalParent = node.parent;
			if (left != null && right != null)
			{
				java.util.TreeMap.Node<K, V> adjacent = (left.height > right.height) ? left.last(
					) : right.first();
				removeInternal(adjacent);
				int leftHeight = 0;
				left = node.left;
				if (left != null)
				{
					leftHeight = left.height;
					adjacent.left = left;
					left.parent = adjacent;
					node.left = null;
				}
				int rightHeight = 0;
				right = node.right;
				if (right != null)
				{
					rightHeight = right.height;
					adjacent.right = right;
					right.parent = adjacent;
					node.right = null;
				}
				adjacent.height = System.Math.Max(leftHeight, rightHeight) + 1;
				replaceInParent(node, adjacent);
				return;
			}
			else
			{
				if (left != null)
				{
					replaceInParent(node, left);
					node.left = null;
				}
				else
				{
					if (right != null)
					{
						replaceInParent(node, right);
						node.right = null;
					}
					else
					{
						replaceInParent(node, null);
					}
				}
			}
			rebalance(originalParent, false);
			_size--;
			modCount++;
		}

		internal virtual java.util.TreeMap.Node<K, V> removeInternalByKey(object key)
		{
			java.util.TreeMap.Node<K, V> node = findByObject(key);
			if (node != null)
			{
				removeInternal(node);
			}
			return node;
		}

		internal void replaceInParent(java.util.TreeMap.Node<K, V> node, java.util.TreeMap.Node
			<K, V> replacement)
		{
			java.util.TreeMap.Node<K, V> parent = node.parent;
			node.parent = null;
			if (replacement != null)
			{
				replacement.parent = parent;
			}
			if (parent != null)
			{
				if (parent.left == node)
				{
					parent.left = replacement;
				}
				else
				{
					parent.right = replacement;
				}
			}
			else
			{
				root = replacement;
			}
		}

		/// <summary>
		/// Rebalances the tree by making any AVL rotations necessary between the
		/// newly-unbalanced node and the tree's root.
		/// </summary>
		/// <remarks>
		/// Rebalances the tree by making any AVL rotations necessary between the
		/// newly-unbalanced node and the tree's root.
		/// </remarks>
		/// <param name="insert">
		/// true if the node was unbalanced by an insert; false if it
		/// was by a removal.
		/// </param>
		internal void rebalance(java.util.TreeMap.Node<K, V> unbalanced, bool insert)
		{
			{
				for (java.util.TreeMap.Node<K, V> node = unbalanced; node != null; node = node.parent)
				{
					java.util.TreeMap.Node<K, V> left = node.left;
					java.util.TreeMap.Node<K, V> right = node.right;
					int leftHeight = left != null ? left.height : 0;
					int rightHeight = right != null ? right.height : 0;
					int delta = leftHeight - rightHeight;
					if (delta == -2)
					{
						java.util.TreeMap.Node<K, V> rightLeft = right.left;
						java.util.TreeMap.Node<K, V> rightRight = right.right;
						int rightRightHeight = rightRight != null ? rightRight.height : 0;
						int rightLeftHeight = rightLeft != null ? rightLeft.height : 0;
						int rightDelta = rightLeftHeight - rightRightHeight;
						if (rightDelta == -1 || (rightDelta == 0 && !insert))
						{
							rotateLeft(node);
						}
						else
						{
							rotateRight(right);
							rotateLeft(node);
						}
						if (insert)
						{
							break;
						}
					}
					else
					{
						if (delta == 2)
						{
							java.util.TreeMap.Node<K, V> leftLeft = left.left;
							java.util.TreeMap.Node<K, V> leftRight = left.right;
							int leftRightHeight = leftRight != null ? leftRight.height : 0;
							int leftLeftHeight = leftLeft != null ? leftLeft.height : 0;
							int leftDelta = leftLeftHeight - leftRightHeight;
							if (leftDelta == 1 || (leftDelta == 0 && !insert))
							{
								rotateRight(node);
							}
							else
							{
								rotateLeft(left);
								rotateRight(node);
							}
							if (insert)
							{
								break;
							}
						}
						else
						{
							if (delta == 0)
							{
								node.height = leftHeight + 1;
								if (insert)
								{
									break;
								}
							}
							else
							{
								node.height = System.Math.Max(leftHeight, rightHeight) + 1;
								if (!insert)
								{
									break;
								}
							}
						}
					}
				}
			}
		}

		/// <summary>Rotates the subtree so that its root's right child is the new root.</summary>
		/// <remarks>Rotates the subtree so that its root's right child is the new root.</remarks>
		internal void rotateLeft(java.util.TreeMap.Node<K, V> root)
		{
			java.util.TreeMap.Node<K, V> left = root.left;
			java.util.TreeMap.Node<K, V> pivot = root.right;
			java.util.TreeMap.Node<K, V> pivotLeft = pivot.left;
			java.util.TreeMap.Node<K, V> pivotRight = pivot.right;
			root.right = pivotLeft;
			if (pivotLeft != null)
			{
				pivotLeft.parent = root;
			}
			replaceInParent(root, pivot);
			pivot.left = root;
			root.parent = pivot;
			root.height = System.Math.Max(left != null ? left.height : 0, pivotLeft != null ? 
				pivotLeft.height : 0) + 1;
			pivot.height = System.Math.Max(root.height, pivotRight != null ? pivotRight.height
				 : 0) + 1;
		}

		/// <summary>Rotates the subtree so that its root's left child is the new root.</summary>
		/// <remarks>Rotates the subtree so that its root's left child is the new root.</remarks>
		internal void rotateRight(java.util.TreeMap.Node<K, V> root)
		{
			java.util.TreeMap.Node<K, V> pivot = root.left;
			java.util.TreeMap.Node<K, V> right = root.right;
			java.util.TreeMap.Node<K, V> pivotLeft = pivot.left;
			java.util.TreeMap.Node<K, V> pivotRight = pivot.right;
			root.left = pivotRight;
			if (pivotRight != null)
			{
				pivotRight.parent = root;
			}
			replaceInParent(root, pivot);
			pivot.right = root;
			root.parent = pivot;
			root.height = System.Math.Max(right != null ? right.height : 0, pivotRight != null
				 ? pivotRight.height : 0) + 1;
			pivot.height = System.Math.Max(root.height, pivotLeft != null ? pivotLeft.height : 
				0) + 1;
		}

		/// <summary>
		/// Returns an immutable version of
		/// <?></?>
		/// . Need this because we allow entry to be null,
		/// in which case we return a null SimpleImmutableEntry.
		/// </summary>
		private java.util.AbstractMap.SimpleImmutableEntry<K, V> immutableCopy(java.util.MapClass.Entry
			<K, V> entry)
		{
			return entry == null ? null : new java.util.AbstractMap.SimpleImmutableEntry<K, V
				>(entry);
		}

		[Sharpen.ImplementsInterface(@"java.util.NavigableMap")]
		public virtual java.util.MapClass.Entry<K, V> firstEntry()
		{
			return immutableCopy(root == null ? null : root.first());
		}

		private java.util.MapClass.Entry<K, V> internalPollFirstEntry()
		{
			if (root == null)
			{
				return null;
			}
			java.util.TreeMap.Node<K, V> result = root.first();
			removeInternal(result);
			return result;
		}

		[Sharpen.ImplementsInterface(@"java.util.NavigableMap")]
		public virtual java.util.MapClass.Entry<K, V> pollFirstEntry()
		{
			return immutableCopy(internalPollFirstEntry());
		}

		[Sharpen.ImplementsInterface(@"java.util.SortedMap")]
		public virtual K firstKey()
		{
			if (root == null)
			{
				throw new java.util.NoSuchElementException();
			}
			return root.first().getKey();
		}

		[Sharpen.ImplementsInterface(@"java.util.NavigableMap")]
		public virtual java.util.MapClass.Entry<K, V> lastEntry()
		{
			return immutableCopy(root == null ? null : root.last());
		}

		private java.util.MapClass.Entry<K, V> internalPollLastEntry()
		{
			if (root == null)
			{
				return null;
			}
			java.util.TreeMap.Node<K, V> result = root.last();
			removeInternal(result);
			return result;
		}

		[Sharpen.ImplementsInterface(@"java.util.NavigableMap")]
		public virtual java.util.MapClass.Entry<K, V> pollLastEntry()
		{
			return immutableCopy(internalPollLastEntry());
		}

		[Sharpen.ImplementsInterface(@"java.util.SortedMap")]
		public virtual K lastKey()
		{
			if (root == null)
			{
				throw new java.util.NoSuchElementException();
			}
			return root.last().getKey();
		}

		[Sharpen.ImplementsInterface(@"java.util.NavigableMap")]
		public virtual java.util.MapClass.Entry<K, V> lowerEntry(K key)
		{
			return immutableCopy(find(key, java.util.TreeMap.Relation.LOWER));
		}

		[Sharpen.ImplementsInterface(@"java.util.NavigableMap")]
		public virtual K lowerKey(K key)
		{
			java.util.MapClass.Entry<K, V> entry = find(key, java.util.TreeMap.Relation.LOWER
				);
			return entry != null ? entry.getKey() : default(K);
		}

		[Sharpen.ImplementsInterface(@"java.util.NavigableMap")]
		public virtual java.util.MapClass.Entry<K, V> floorEntry(K key)
		{
			return immutableCopy(find(key, java.util.TreeMap.Relation.FLOOR));
		}

		[Sharpen.ImplementsInterface(@"java.util.NavigableMap")]
		public virtual K floorKey(K key)
		{
			java.util.MapClass.Entry<K, V> entry = find(key, java.util.TreeMap.Relation.FLOOR
				);
			return entry != null ? entry.getKey() : default(K);
		}

		[Sharpen.ImplementsInterface(@"java.util.NavigableMap")]
		public virtual java.util.MapClass.Entry<K, V> ceilingEntry(K key)
		{
			return immutableCopy(find(key, java.util.TreeMap.Relation.CEILING));
		}

		[Sharpen.ImplementsInterface(@"java.util.NavigableMap")]
		public virtual K ceilingKey(K key)
		{
			java.util.MapClass.Entry<K, V> entry = find(key, java.util.TreeMap.Relation.CEILING
				);
			return entry != null ? entry.getKey() : default(K);
		}

		[Sharpen.ImplementsInterface(@"java.util.NavigableMap")]
		public virtual java.util.MapClass.Entry<K, V> higherEntry(K key)
		{
			return immutableCopy(find(key, java.util.TreeMap.Relation.HIGHER));
		}

		[Sharpen.ImplementsInterface(@"java.util.NavigableMap")]
		public virtual K higherKey(K key)
		{
			java.util.MapClass.Entry<K, V> entry = find(key, java.util.TreeMap.Relation.HIGHER
				);
			return entry != null ? entry.getKey() : default(K);
		}

		[Sharpen.ImplementsInterface(@"java.util.SortedMap")]
		public virtual java.util.Comparator<K> comparator()
		{
			return _comparator != NATURAL_ORDER ? _comparator : null;
		}

		private java.util.TreeMap<K, V>.EntrySet _entrySet;

		private java.util.TreeMap<K, V>.KeySet _keySet;

		[Sharpen.OverridesMethod(@"java.util.AbstractMap")]
		public override java.util.Set<java.util.MapClass.Entry<K, V>> entrySet()
		{
			java.util.TreeMap<K, V>.EntrySet result = _entrySet;
			return result != null ? result : (_entrySet = new java.util.TreeMap<K, V>.EntrySet
				(this));
		}

		[Sharpen.OverridesMethod(@"java.util.AbstractMap")]
		public override java.util.Set<K> keySet()
		{
			java.util.TreeMap<K, V>.KeySet result = _keySet;
			return result != null ? result : (_keySet = new java.util.TreeMap<K, V>.KeySet(this
				));
		}

		[Sharpen.ImplementsInterface(@"java.util.NavigableMap")]
		public virtual java.util.NavigableSet<K> navigableKeySet()
		{
			java.util.TreeMap<K, V>.KeySet result = _keySet;
			return result != null ? result : (_keySet = new java.util.TreeMap<K, V>.KeySet(this
				));
		}

		[Sharpen.ImplementsInterface(@"java.util.NavigableMap")]
		public virtual java.util.NavigableMap<K, V> subMap(K from, bool fromInclusive, K 
			to, bool toInclusive)
		{
			java.util.TreeMap.Bound fromBound = fromInclusive ? java.util.TreeMap.Bound.INCLUSIVE
				 : java.util.TreeMap.Bound.EXCLUSIVE;
			java.util.TreeMap.Bound toBound = toInclusive ? java.util.TreeMap.Bound.INCLUSIVE
				 : java.util.TreeMap.Bound.EXCLUSIVE;
			return new java.util.TreeMap<K, V>.BoundedMap(this, true, from, fromBound, to, toBound
				);
		}

		[Sharpen.ImplementsInterface(@"java.util.SortedMap")]
		public virtual java.util.SortedMap<K, V> subMap(K fromInclusive, K toExclusive)
		{
			return new java.util.TreeMap<K, V>.BoundedMap(this, true, fromInclusive, java.util.TreeMap
				.Bound.INCLUSIVE, toExclusive, java.util.TreeMap.Bound.EXCLUSIVE);
		}

		[Sharpen.ImplementsInterface(@"java.util.NavigableMap")]
		public virtual java.util.NavigableMap<K, V> headMap(K to, bool inclusive)
		{
			java.util.TreeMap.Bound toBound = inclusive ? java.util.TreeMap.Bound.INCLUSIVE : 
				java.util.TreeMap.Bound.EXCLUSIVE;
			return new java.util.TreeMap<K, V>.BoundedMap(this, true, default(K), java.util.TreeMap
				.Bound.NO_BOUND, to, toBound);
		}

		[Sharpen.ImplementsInterface(@"java.util.SortedMap")]
		public virtual java.util.SortedMap<K, V> headMap(K toExclusive)
		{
			return new java.util.TreeMap<K, V>.BoundedMap(this, true, default(K), java.util.TreeMap
				.Bound.NO_BOUND, toExclusive, java.util.TreeMap.Bound.EXCLUSIVE);
		}

		[Sharpen.ImplementsInterface(@"java.util.NavigableMap")]
		public virtual java.util.NavigableMap<K, V> tailMap(K from, bool inclusive)
		{
			java.util.TreeMap.Bound fromBound = inclusive ? java.util.TreeMap.Bound.INCLUSIVE
				 : java.util.TreeMap.Bound.EXCLUSIVE;
			return new java.util.TreeMap<K, V>.BoundedMap(this, true, from, fromBound, default
				(K), java.util.TreeMap.Bound.NO_BOUND);
		}

		[Sharpen.ImplementsInterface(@"java.util.SortedMap")]
		public virtual java.util.SortedMap<K, V> tailMap(K fromInclusive)
		{
			return new java.util.TreeMap<K, V>.BoundedMap(this, true, fromInclusive, java.util.TreeMap
				.Bound.INCLUSIVE, default(K), java.util.TreeMap.Bound.NO_BOUND);
		}

		[Sharpen.ImplementsInterface(@"java.util.NavigableMap")]
		public virtual java.util.NavigableMap<K, V> descendingMap()
		{
			return new java.util.TreeMap<K, V>.BoundedMap(this, false, default(K), java.util.TreeMap
				.Bound.NO_BOUND, default(K), java.util.TreeMap.Bound.NO_BOUND);
		}

		[Sharpen.ImplementsInterface(@"java.util.NavigableMap")]
		public virtual java.util.NavigableSet<K> descendingKeySet()
		{
			return new java.util.TreeMap<K, V>.BoundedMap(this, false, default(K), java.util.TreeMap
				.Bound.NO_BOUND, default(K), java.util.TreeMap.Bound.NO_BOUND).navigableKeySet();
		}

		/// <summary>Walk the nodes of the tree left-to-right or right-to-left.</summary>
		/// <remarks>
		/// Walk the nodes of the tree left-to-right or right-to-left. Note that in
		/// descending iterations,
		/// <code>next</code>
		/// will return the previous node.
		/// </remarks>
		internal abstract class MapIterator<T> : java.util.Iterator<T>
		{
			internal java.util.TreeMap.Node<K, V> _next;

			internal java.util.TreeMap.Node<K, V> last;

			protected internal int expectedModCount;

			internal MapIterator(TreeMap<K, V> _enclosing, java.util.TreeMap.Node<K, V> next_1
				)
			{
				this._enclosing = _enclosing;
				expectedModCount = this._enclosing.modCount;
				this._next = next_1;
			}

			[Sharpen.ImplementsInterface(@"java.util.Iterator")]
			public virtual bool hasNext()
			{
				return this._next != null;
			}

			internal virtual java.util.TreeMap.Node<K, V> stepForward()
			{
				if (this._next == null)
				{
					throw new java.util.NoSuchElementException();
				}
				if (this._enclosing.modCount != this.expectedModCount)
				{
					throw new java.util.ConcurrentModificationException();
				}
				this.last = this._next;
				this._next = this._next.next();
				return this.last;
			}

			internal virtual java.util.TreeMap.Node<K, V> stepBackward()
			{
				if (this._next == null)
				{
					throw new java.util.NoSuchElementException();
				}
				if (this._enclosing.modCount != this.expectedModCount)
				{
					throw new java.util.ConcurrentModificationException();
				}
				this.last = this._next;
				this._next = this._next.prev();
				return this.last;
			}

			[Sharpen.ImplementsInterface(@"java.util.Iterator")]
			public virtual void remove()
			{
				if (this.last == null)
				{
					throw new System.InvalidOperationException();
				}
				this._enclosing.removeInternal(this.last);
				this.expectedModCount = this._enclosing.modCount;
				this.last = null;
			}

			public abstract T next();

			private readonly TreeMap<K, V> _enclosing;
		}

		internal class EntrySet : java.util.AbstractSet<java.util.MapClass.Entry<K, V>>
		{
			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override int size()
			{
				return this._enclosing._size;
			}

			private sealed class _MapIterator_922 : java.util.TreeMap<K, V>.MapIterator<java.util.MapClass
				.Entry<K, V>>
			{
				public _MapIterator_922(EntrySet _enclosing, java.util.TreeMap.Node<K, V> baseArg1
					) : base(_enclosing._enclosing, baseArg1)
				{
					this._enclosing = _enclosing;
				}

				[Sharpen.ImplementsInterface(@"java.util.Iterator")]
				public override java.util.MapClass.Entry<K, V> next()
				{
					return this.stepForward();
				}

				private readonly EntrySet _enclosing;
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override java.util.Iterator<java.util.MapClass.Entry<K, V>> iterator()
			{
				return new _MapIterator_922(this, this._enclosing.root == null ? null : this._enclosing
					.root.first());
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override bool contains(object o)
			{
				return o is java.util.MapClass.Entry<K, V> && this._enclosing.findByEntry((java.util.MapClass
					.Entry<object, object>)o) != null;
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override bool remove(object o)
			{
				if (!(o is java.util.MapClass.Entry<K, V>))
				{
					return false;
				}
				java.util.TreeMap.Node<K, V> node = this._enclosing.findByEntry((java.util.MapClass
					.Entry<object, object>)o);
				if (node == null)
				{
					return false;
				}
				this._enclosing.removeInternal(node);
				return true;
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override void clear()
			{
				this._enclosing.clear();
			}

			internal EntrySet(TreeMap<K, V> _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly TreeMap<K, V> _enclosing;
		}

		internal class KeySet : java.util.AbstractSet<K>, java.util.NavigableSet<K>
		{
			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override int size()
			{
				return this._enclosing._size;
			}

			private sealed class _MapIterator_957 : java.util.TreeMap<K, V>.MapIterator<K>
			{
				public _MapIterator_957(KeySet _enclosing, java.util.TreeMap.Node<K, V> baseArg1)
					 : base(_enclosing._enclosing, baseArg1)
				{
					this._enclosing = _enclosing;
				}

				[Sharpen.ImplementsInterface(@"java.util.Iterator")]
				public override K next()
				{
					return this.stepForward().key;
				}

				private readonly KeySet _enclosing;
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override java.util.Iterator<K> iterator()
			{
				return new _MapIterator_957(this, this._enclosing.root == null ? null : this._enclosing
					.root.first());
			}

			private sealed class _MapIterator_965 : java.util.TreeMap<K, V>.MapIterator<K>
			{
				public _MapIterator_965(KeySet _enclosing, java.util.TreeMap.Node<K, V> baseArg1)
					 : base(_enclosing._enclosing, baseArg1)
				{
					this._enclosing = _enclosing;
				}

				[Sharpen.ImplementsInterface(@"java.util.Iterator")]
				public override K next()
				{
					return this.stepBackward().key;
				}

				private readonly KeySet _enclosing;
			}

			[Sharpen.ImplementsInterface(@"java.util.NavigableSet")]
			public virtual java.util.Iterator<K> descendingIterator()
			{
				return new _MapIterator_965(this, this._enclosing.root == null ? null : this._enclosing
					.root.last());
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override bool contains(object o)
			{
				return this._enclosing.containsKey(o);
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override bool remove(object key)
			{
				return this._enclosing.removeInternalByKey(key) != null;
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
			public override void clear()
			{
				this._enclosing.clear();
			}

			[Sharpen.ImplementsInterface(@"java.util.SortedSet")]
			public virtual java.util.Comparator<K> comparator()
			{
				return this._enclosing.comparator();
			}

			[Sharpen.ImplementsInterface(@"java.util.SortedSet")]
			public virtual K first()
			{
				return this._enclosing.firstKey();
			}

			[Sharpen.ImplementsInterface(@"java.util.SortedSet")]
			public virtual K last()
			{
				return this._enclosing.lastKey();
			}

			[Sharpen.ImplementsInterface(@"java.util.NavigableSet")]
			public virtual K lower(K key)
			{
				return this._enclosing.lowerKey(key);
			}

			[Sharpen.ImplementsInterface(@"java.util.NavigableSet")]
			public virtual K floor(K key)
			{
				return this._enclosing.floorKey(key);
			}

			[Sharpen.ImplementsInterface(@"java.util.NavigableSet")]
			public virtual K ceiling(K key)
			{
				return this._enclosing.ceilingKey(key);
			}

			[Sharpen.ImplementsInterface(@"java.util.NavigableSet")]
			public virtual K higher(K key)
			{
				return this._enclosing.higherKey(key);
			}

			[Sharpen.ImplementsInterface(@"java.util.NavigableSet")]
			public virtual K pollFirst()
			{
				java.util.MapClass.Entry<K, V> entry = this._enclosing.internalPollFirstEntry();
				return entry != null ? entry.getKey() : default(K);
			}

			[Sharpen.ImplementsInterface(@"java.util.NavigableSet")]
			public virtual K pollLast()
			{
				java.util.MapClass.Entry<K, V> entry = this._enclosing.internalPollLastEntry();
				return entry != null ? entry.getKey() : default(K);
			}

			[Sharpen.ImplementsInterface(@"java.util.NavigableSet")]
			public virtual java.util.NavigableSet<K> subSet(K from, bool fromInclusive, K to, 
				bool toInclusive)
			{
				return this._enclosing.subMap(from, fromInclusive, to, toInclusive).navigableKeySet
					();
			}

			[Sharpen.ImplementsInterface(@"java.util.SortedSet")]
			public virtual java.util.SortedSet<K> subSet(K fromInclusive, K toExclusive)
			{
				return this._enclosing.subMap(fromInclusive, true, toExclusive, false).navigableKeySet
					();
			}

			[Sharpen.ImplementsInterface(@"java.util.NavigableSet")]
			public virtual java.util.NavigableSet<K> headSet(K to, bool inclusive)
			{
				return this._enclosing.headMap(to, inclusive).navigableKeySet();
			}

			[Sharpen.ImplementsInterface(@"java.util.SortedSet")]
			public virtual java.util.SortedSet<K> headSet(K toExclusive)
			{
				return this._enclosing.headMap(toExclusive, false).navigableKeySet();
			}

			[Sharpen.ImplementsInterface(@"java.util.NavigableSet")]
			public virtual java.util.NavigableSet<K> tailSet(K from, bool inclusive)
			{
				return this._enclosing.tailMap(from, inclusive).navigableKeySet();
			}

			[Sharpen.ImplementsInterface(@"java.util.SortedSet")]
			public virtual java.util.SortedSet<K> tailSet(K fromInclusive)
			{
				return this._enclosing.tailMap(fromInclusive, true).navigableKeySet();
			}

			[Sharpen.ImplementsInterface(@"java.util.NavigableSet")]
			public virtual java.util.NavigableSet<K> descendingSet()
			{
				return new java.util.TreeMap<K, V>.BoundedMap(this._enclosing, false, default(K), 
					java.util.TreeMap.Bound.NO_BOUND, default(K), java.util.TreeMap.Bound.NO_BOUND).
					navigableKeySet();
			}

			internal KeySet(TreeMap<K, V> _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly TreeMap<K, V> _enclosing;
		}

		/// <summary>A map with optional limits on its range.</summary>
		/// <remarks>A map with optional limits on its range.</remarks>
		[System.Serializable]
		internal sealed partial class BoundedMap : java.util.AbstractMap<K, V>, java.util.NavigableMap
			<K, V>
		{
			[System.NonSerialized]
			private readonly bool ascending;

			[System.NonSerialized]
			private readonly K from;

			[System.NonSerialized]
			private readonly java.util.TreeMap.Bound fromBound;

			[System.NonSerialized]
			private readonly K to;

			[System.NonSerialized]
			private readonly java.util.TreeMap.Bound toBound;

			internal BoundedMap(TreeMap<K, V> _enclosing, bool ascending, K from, java.util.TreeMap
				.Bound fromBound, K to, java.util.TreeMap.Bound toBound)
			{
				this._enclosing = _enclosing;
				if (fromBound != java.util.TreeMap.Bound.NO_BOUND && toBound != java.util.TreeMap
					.Bound.NO_BOUND)
				{
					if (this._enclosing._comparator.compare(from, to) > 0)
					{
						throw new System.ArgumentException(from + " > " + to);
					}
				}
				else
				{
					if (fromBound != java.util.TreeMap.Bound.NO_BOUND)
					{
						this._enclosing._comparator.compare(from, from);
					}
					else
					{
						if (toBound != java.util.TreeMap.Bound.NO_BOUND)
						{
							this._enclosing._comparator.compare(to, to);
						}
					}
				}
				this.ascending = ascending;
				this.from = from;
				this.fromBound = fromBound;
				this.to = to;
				this.toBound = toBound;
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractMap")]
			public override int size()
			{
				return java.util.TreeMap<K, V>.count(this.entrySet().iterator());
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractMap")]
			public override bool isEmpty()
			{
				return this.endpoint(true) == null;
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractMap")]
			public override V get(object key)
			{
				return this.isInBounds(key) ? this._enclosing.get(key) : default(V);
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractMap")]
			public override bool containsKey(object key)
			{
				return this.isInBounds(key) && this._enclosing.containsKey(key);
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractMap")]
			public override V put(K key, V value)
			{
				if (!this.isInBounds(key))
				{
					throw this.outOfBounds(key, this.fromBound, this.toBound);
				}
				return this._enclosing.putInternal(key, value);
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractMap")]
			public override V remove(object key)
			{
				return this.isInBounds(key) ? this._enclosing.remove(key) : default(V);
			}

			/// <summary>Returns true if the key is in bounds.</summary>
			/// <remarks>Returns true if the key is in bounds.</remarks>
			private bool isInBounds(object key)
			{
				return this.isInBounds((K)key, this.fromBound, this.toBound);
			}

			/// <summary>Returns true if the key is in bounds.</summary>
			/// <remarks>
			/// Returns true if the key is in bounds. Use this overload with
			/// NO_BOUND to skip bounds checking on either end.
			/// </remarks>
			internal bool isInBounds(K key, java.util.TreeMap.Bound fromBound, java.util.TreeMap
				.Bound toBound)
			{
				if (fromBound == java.util.TreeMap.Bound.INCLUSIVE)
				{
					if (this._enclosing._comparator.compare(key, this.from) < 0)
					{
						return false;
					}
				}
				else
				{
					if (fromBound == java.util.TreeMap.Bound.EXCLUSIVE)
					{
						if (this._enclosing._comparator.compare(key, this.from) <= 0)
						{
							return false;
						}
					}
				}
				if (toBound == java.util.TreeMap.Bound.INCLUSIVE)
				{
					if (this._enclosing._comparator.compare(key, this.to) > 0)
					{
						return false;
					}
				}
				else
				{
					if (toBound == java.util.TreeMap.Bound.EXCLUSIVE)
					{
						if (this._enclosing._comparator.compare(key, this.to) >= 0)
						{
							return false;
						}
					}
				}
				return true;
			}

			/// <summary>Returns the entry if it is in bounds, or null if it is out of bounds.</summary>
			/// <remarks>Returns the entry if it is in bounds, or null if it is out of bounds.</remarks>
			internal java.util.TreeMap.Node<K, V> bound(java.util.TreeMap.Node<K, V> node, java.util.TreeMap
				.Bound fromBound, java.util.TreeMap.Bound toBound)
			{
				return node != null && this.isInBounds(node.getKey(), fromBound, toBound) ? node : 
					null;
			}

			[Sharpen.ImplementsInterface(@"java.util.NavigableMap")]
			public java.util.MapClass.Entry<K, V> firstEntry()
			{
				return this._enclosing.immutableCopy(this.endpoint(true));
			}

			[Sharpen.ImplementsInterface(@"java.util.NavigableMap")]
			public java.util.MapClass.Entry<K, V> pollFirstEntry()
			{
				java.util.TreeMap.Node<K, V> result = this.endpoint(true);
				if (result != null)
				{
					this._enclosing.removeInternal(result);
				}
				return this._enclosing.immutableCopy(result);
			}

			[Sharpen.ImplementsInterface(@"java.util.SortedMap")]
			public K firstKey()
			{
				java.util.MapClass.Entry<K, V> entry = this.endpoint(true);
				if (entry == null)
				{
					throw new java.util.NoSuchElementException();
				}
				return entry.getKey();
			}

			[Sharpen.ImplementsInterface(@"java.util.NavigableMap")]
			public java.util.MapClass.Entry<K, V> lastEntry()
			{
				return this._enclosing.immutableCopy(this.endpoint(false));
			}

			[Sharpen.ImplementsInterface(@"java.util.NavigableMap")]
			public java.util.MapClass.Entry<K, V> pollLastEntry()
			{
				java.util.TreeMap.Node<K, V> result = this.endpoint(false);
				if (result != null)
				{
					this._enclosing.removeInternal(result);
				}
				return this._enclosing.immutableCopy(result);
			}

			[Sharpen.ImplementsInterface(@"java.util.SortedMap")]
			public K lastKey()
			{
				java.util.MapClass.Entry<K, V> entry = this.endpoint(false);
				if (entry == null)
				{
					throw new java.util.NoSuchElementException();
				}
				return entry.getKey();
			}

			/// <param name="first">true for the first element, false for the last.</param>
			internal java.util.TreeMap.Node<K, V> endpoint(bool first)
			{
				java.util.TreeMap.Node<K, V> node;
				if (this.ascending == first)
				{
					switch (this.fromBound.ID)
					{
						case java.util.TreeMap.Bound.NO_BOUND_ID:
						{
							node = this._enclosing.root == null ? null : this._enclosing.root.first();
							break;
						}

						case java.util.TreeMap.Bound.INCLUSIVE_ID:
						{
							node = this._enclosing.find(this.from, java.util.TreeMap.Relation.CEILING);
							break;
						}

						case java.util.TreeMap.Bound.EXCLUSIVE_ID:
						{
							node = this._enclosing.find(this.from, java.util.TreeMap.Relation.HIGHER);
							break;
						}

						default:
						{
							throw new java.lang.AssertionError();
						}
					}
					return this.bound(node, java.util.TreeMap.Bound.NO_BOUND, this.toBound);
				}
				else
				{
					switch (this.toBound.ID)
					{
						case java.util.TreeMap.Bound.NO_BOUND_ID:
						{
							node = this._enclosing.root == null ? null : this._enclosing.root.last();
							break;
						}

						case java.util.TreeMap.Bound.INCLUSIVE_ID:
						{
							node = this._enclosing.find(this.to, java.util.TreeMap.Relation.FLOOR);
							break;
						}

						case java.util.TreeMap.Bound.EXCLUSIVE_ID:
						{
							node = this._enclosing.find(this.to, java.util.TreeMap.Relation.LOWER);
							break;
						}

						default:
						{
							throw new java.lang.AssertionError();
						}
					}
					return this.bound(node, this.fromBound, java.util.TreeMap.Bound.NO_BOUND);
				}
			}

			/// <summary>
			/// Performs a find on the underlying tree after constraining it to the
			/// bounds of this view.
			/// </summary>
			/// <remarks>
			/// Performs a find on the underlying tree after constraining it to the
			/// bounds of this view. Examples:
			/// bound is (A..C)
			/// findBounded(B, FLOOR) stays source.find(B, FLOOR)
			/// bound is (A..C)
			/// findBounded(C, FLOOR) becomes source.find(C, LOWER)
			/// bound is (A..C)
			/// findBounded(D, LOWER) becomes source.find(C, LOWER)
			/// bound is (A..C]
			/// findBounded(D, FLOOR) becomes source.find(C, FLOOR)
			/// bound is (A..C]
			/// findBounded(D, LOWER) becomes source.find(C, FLOOR)
			/// </remarks>
			internal java.util.MapClass.Entry<K, V> findBounded(K key, java.util.TreeMap.Relation
				 relation)
			{
				relation = relation.forOrder(this.ascending);
				java.util.TreeMap.Bound fromBoundForCheck = this.fromBound;
				java.util.TreeMap.Bound toBoundForCheck = this.toBound;
				if (this.toBound != java.util.TreeMap.Bound.NO_BOUND && (relation == java.util.TreeMap
					.Relation.LOWER || relation == java.util.TreeMap.Relation.FLOOR))
				{
					int comparison = this._enclosing._comparator.compare(this.to, key);
					if (comparison <= 0)
					{
						key = this.to;
						if (this.toBound == java.util.TreeMap.Bound.EXCLUSIVE)
						{
							relation = java.util.TreeMap.Relation.LOWER;
						}
						else
						{
							if (comparison < 0)
							{
								relation = java.util.TreeMap.Relation.FLOOR;
							}
						}
					}
					toBoundForCheck = java.util.TreeMap.Bound.NO_BOUND;
				}
				if (this.fromBound != java.util.TreeMap.Bound.NO_BOUND && (relation == java.util.TreeMap
					.Relation.CEILING || relation == java.util.TreeMap.Relation.HIGHER))
				{
					int comparison = this._enclosing._comparator.compare(this.from, key);
					if (comparison >= 0)
					{
						key = this.from;
						if (this.fromBound == java.util.TreeMap.Bound.EXCLUSIVE)
						{
							relation = java.util.TreeMap.Relation.HIGHER;
						}
						else
						{
							if (comparison > 0)
							{
								relation = java.util.TreeMap.Relation.CEILING;
							}
						}
					}
					fromBoundForCheck = java.util.TreeMap.Bound.NO_BOUND;
				}
				return this.bound(this._enclosing.find(key, relation), fromBoundForCheck, toBoundForCheck
					);
			}

			[Sharpen.ImplementsInterface(@"java.util.NavigableMap")]
			public java.util.MapClass.Entry<K, V> lowerEntry(K key)
			{
				return this._enclosing.immutableCopy(this.findBounded(key, java.util.TreeMap.Relation
					.LOWER));
			}

			[Sharpen.ImplementsInterface(@"java.util.NavigableMap")]
			public K lowerKey(K key)
			{
				java.util.MapClass.Entry<K, V> entry = this.findBounded(key, java.util.TreeMap.Relation
					.LOWER);
				return entry != null ? entry.getKey() : default(K);
			}

			[Sharpen.ImplementsInterface(@"java.util.NavigableMap")]
			public java.util.MapClass.Entry<K, V> floorEntry(K key)
			{
				return this._enclosing.immutableCopy(this.findBounded(key, java.util.TreeMap.Relation
					.FLOOR));
			}

			[Sharpen.ImplementsInterface(@"java.util.NavigableMap")]
			public K floorKey(K key)
			{
				java.util.MapClass.Entry<K, V> entry = this.findBounded(key, java.util.TreeMap.Relation
					.FLOOR);
				return entry != null ? entry.getKey() : default(K);
			}

			[Sharpen.ImplementsInterface(@"java.util.NavigableMap")]
			public java.util.MapClass.Entry<K, V> ceilingEntry(K key)
			{
				return this._enclosing.immutableCopy(this.findBounded(key, java.util.TreeMap.Relation
					.CEILING));
			}

			[Sharpen.ImplementsInterface(@"java.util.NavigableMap")]
			public K ceilingKey(K key)
			{
				java.util.MapClass.Entry<K, V> entry = this.findBounded(key, java.util.TreeMap.Relation
					.CEILING);
				return entry != null ? entry.getKey() : default(K);
			}

			[Sharpen.ImplementsInterface(@"java.util.NavigableMap")]
			public java.util.MapClass.Entry<K, V> higherEntry(K key)
			{
				return this._enclosing.immutableCopy(this.findBounded(key, java.util.TreeMap.Relation
					.HIGHER));
			}

			[Sharpen.ImplementsInterface(@"java.util.NavigableMap")]
			public K higherKey(K key)
			{
				java.util.MapClass.Entry<K, V> entry = this.findBounded(key, java.util.TreeMap.Relation
					.HIGHER);
				return entry != null ? entry.getKey() : default(K);
			}

			[Sharpen.ImplementsInterface(@"java.util.SortedMap")]
			public java.util.Comparator<K> comparator()
			{
				if (this.ascending)
				{
					return this._enclosing.comparator();
				}
				else
				{
					return java.util.Collections.reverseOrder<K>(this._enclosing._comparator);
				}
			}

			[System.NonSerialized]
			private java.util.TreeMap<K, V>.BoundedMap.BoundedEntrySet _entrySet;

			[System.NonSerialized]
			private java.util.TreeMap<K, V>.BoundedMap.BoundedKeySet _keySet;

			[Sharpen.OverridesMethod(@"java.util.AbstractMap")]
			public override java.util.Set<java.util.MapClass.Entry<K, V>> entrySet()
			{
				java.util.TreeMap<K, V>.BoundedMap.BoundedEntrySet result = this._entrySet;
				return result != null ? result : (this._entrySet = new java.util.TreeMap<K, V>.BoundedMap
					.BoundedEntrySet(this));
			}

			[Sharpen.OverridesMethod(@"java.util.AbstractMap")]
			public override java.util.Set<K> keySet()
			{
				return this.navigableKeySet();
			}

			[Sharpen.ImplementsInterface(@"java.util.NavigableMap")]
			public java.util.NavigableSet<K> navigableKeySet()
			{
				java.util.TreeMap<K, V>.BoundedMap.BoundedKeySet result = this._keySet;
				return result != null ? result : (this._keySet = new java.util.TreeMap<K, V>.BoundedMap
					.BoundedKeySet(this));
			}

			[Sharpen.ImplementsInterface(@"java.util.NavigableMap")]
			public java.util.NavigableMap<K, V> descendingMap()
			{
				return new java.util.TreeMap<K, V>.BoundedMap(this._enclosing, !this.ascending, this
					.from, this.fromBound, this.to, this.toBound);
			}

			[Sharpen.ImplementsInterface(@"java.util.NavigableMap")]
			public java.util.NavigableSet<K> descendingKeySet()
			{
				return new java.util.TreeMap<K, V>.BoundedMap(this._enclosing, !this.ascending, this
					.from, this.fromBound, this.to, this.toBound).navigableKeySet();
			}

			[Sharpen.ImplementsInterface(@"java.util.NavigableMap")]
			public java.util.NavigableMap<K, V> subMap(K from, bool fromInclusive, K to, bool
				 toInclusive)
			{
				java.util.TreeMap.Bound fromBound = fromInclusive ? java.util.TreeMap.Bound.INCLUSIVE
					 : java.util.TreeMap.Bound.EXCLUSIVE;
				java.util.TreeMap.Bound toBound = toInclusive ? java.util.TreeMap.Bound.INCLUSIVE
					 : java.util.TreeMap.Bound.EXCLUSIVE;
				return this.subMap(from, fromBound, to, toBound);
			}

			[Sharpen.Proxy]
			java.util.SortedMap<K, V> java.util.SortedMap<K, V>.subMap(K fromInclusive, K toExclusive
				)
			{
				return subMap(fromInclusive, toExclusive);
			}

			[Sharpen.Proxy]
			java.util.SortedMap<K, V> java.util.NavigableMap<K, V>.subMap(K fromInclusive, K 
				toExclusive)
			{
				return subMap(fromInclusive, toExclusive);
			}

			[Sharpen.ImplementsInterface(@"java.util.SortedMap")]
			public java.util.NavigableMap<K, V> subMap(K fromInclusive, K toExclusive)
			{
				return this.subMap(fromInclusive, java.util.TreeMap.Bound.INCLUSIVE, toExclusive, 
					java.util.TreeMap.Bound.EXCLUSIVE);
			}

			[Sharpen.ImplementsInterface(@"java.util.NavigableMap")]
			public java.util.NavigableMap<K, V> headMap(K to, bool inclusive)
			{
				java.util.TreeMap.Bound toBound = inclusive ? java.util.TreeMap.Bound.INCLUSIVE : 
					java.util.TreeMap.Bound.EXCLUSIVE;
				return this.subMap(default(K), java.util.TreeMap.Bound.NO_BOUND, to, toBound);
			}

			[Sharpen.Proxy]
			java.util.SortedMap<K, V> java.util.SortedMap<K, V>.headMap(K toExclusive)
			{
				return headMap(toExclusive);
			}

			[Sharpen.Proxy]
			java.util.SortedMap<K, V> java.util.NavigableMap<K, V>.headMap(K toExclusive)
			{
				return headMap(toExclusive);
			}

			[Sharpen.ImplementsInterface(@"java.util.SortedMap")]
			public java.util.NavigableMap<K, V> headMap(K toExclusive)
			{
				return this.subMap(default(K), java.util.TreeMap.Bound.NO_BOUND, toExclusive, java.util.TreeMap
					.Bound.EXCLUSIVE);
			}

			[Sharpen.ImplementsInterface(@"java.util.NavigableMap")]
			public java.util.NavigableMap<K, V> tailMap(K from, bool inclusive)
			{
				java.util.TreeMap.Bound fromBound = inclusive ? java.util.TreeMap.Bound.INCLUSIVE
					 : java.util.TreeMap.Bound.EXCLUSIVE;
				return this.subMap(from, fromBound, default(K), java.util.TreeMap.Bound.NO_BOUND);
			}

			[Sharpen.Proxy]
			java.util.SortedMap<K, V> java.util.SortedMap<K, V>.tailMap(K fromInclusive)
			{
				return tailMap(fromInclusive);
			}

			[Sharpen.Proxy]
			java.util.SortedMap<K, V> java.util.NavigableMap<K, V>.tailMap(K fromInclusive)
			{
				return tailMap(fromInclusive);
			}

			[Sharpen.ImplementsInterface(@"java.util.SortedMap")]
			public java.util.NavigableMap<K, V> tailMap(K fromInclusive)
			{
				return this.subMap(fromInclusive, java.util.TreeMap.Bound.INCLUSIVE, default(K), 
					java.util.TreeMap.Bound.NO_BOUND);
			}

			internal java.util.NavigableMap<K, V> subMap(K from, java.util.TreeMap.Bound fromBound
				, K to, java.util.TreeMap.Bound toBound)
			{
				if (!this.ascending)
				{
					K fromTmp = from;
					java.util.TreeMap.Bound fromBoundTmp = fromBound;
					from = to;
					fromBound = toBound;
					to = fromTmp;
					toBound = fromBoundTmp;
				}
				if (fromBound == java.util.TreeMap.Bound.NO_BOUND)
				{
					from = this.from;
					fromBound = this.fromBound;
				}
				else
				{
					java.util.TreeMap.Bound fromBoundToCheck = fromBound == this.fromBound ? java.util.TreeMap
						.Bound.INCLUSIVE : this.fromBound;
					if (!this.isInBounds(from, fromBoundToCheck, this.toBound))
					{
						throw this.outOfBounds(to, fromBoundToCheck, this.toBound);
					}
				}
				if (toBound == java.util.TreeMap.Bound.NO_BOUND)
				{
					to = this.to;
					toBound = this.toBound;
				}
				else
				{
					java.util.TreeMap.Bound toBoundToCheck = toBound == this.toBound ? java.util.TreeMap
						.Bound.INCLUSIVE : this.toBound;
					if (!this.isInBounds(to, this.fromBound, toBoundToCheck))
					{
						throw this.outOfBounds(to, this.fromBound, toBoundToCheck);
					}
				}
				return new java.util.TreeMap<K, V>.BoundedMap(this._enclosing, this.ascending, from
					, fromBound, to, toBound);
			}

			internal System.ArgumentException outOfBounds(object value, java.util.TreeMap.Bound
				 fromBound, java.util.TreeMap.Bound toBound)
			{
				return new System.ArgumentException(value + " not in range " + fromBound.leftCap(
					this.from) + ".." + toBound.rightCap(this.to));
			}

			internal abstract class BoundedIterator<T> : java.util.TreeMap<K, V>.MapIterator<
				T>
			{
				internal BoundedIterator(BoundedMap _enclosing, java.util.TreeMap.Node<K, V> next_1
					) : base(_enclosing._enclosing, next_1)
				{
					this._enclosing = _enclosing;
				}

				[Sharpen.OverridesMethod(@"java.util.TreeMap.MapIterator")]
				internal override java.util.TreeMap.Node<K, V> stepForward()
				{
					java.util.TreeMap.Node<K, V> result = base.stepForward();
					if (this._next != null && !this._enclosing.isInBounds(this._next.key, java.util.TreeMap
						.Bound.NO_BOUND, this._enclosing.toBound))
					{
						this._next = null;
					}
					return result;
				}

				[Sharpen.OverridesMethod(@"java.util.TreeMap.MapIterator")]
				internal override java.util.TreeMap.Node<K, V> stepBackward()
				{
					java.util.TreeMap.Node<K, V> result = base.stepBackward();
					if (this._next != null && !this._enclosing.isInBounds(this._next.key, this._enclosing
						.fromBound, java.util.TreeMap.Bound.NO_BOUND))
					{
						this._next = null;
					}
					return result;
				}

				private readonly BoundedMap _enclosing;
			}

			internal sealed class BoundedEntrySet : java.util.AbstractSet<java.util.MapClass.
				Entry<K, V>>
			{
				[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
				public override int size()
				{
					return this._enclosing.size();
				}

				[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
				public override bool isEmpty()
				{
					return this._enclosing.isEmpty();
				}

				private sealed class _BoundedIterator_1510 : java.util.TreeMap<K, V>.BoundedMap.BoundedIterator
					<java.util.MapClass.Entry<K, V>>
				{
					public _BoundedIterator_1510(BoundedEntrySet _enclosing, java.util.TreeMap.Node<K
						, V> baseArg1) : base(_enclosing._enclosing, baseArg1)
					{
						this._enclosing = _enclosing;
					}

					[Sharpen.ImplementsInterface(@"java.util.Iterator")]
					public override java.util.MapClass.Entry<K, V> next()
					{
						return this._enclosing._enclosing.ascending ? this.stepForward() : this.stepBackward
							();
					}

					private readonly BoundedEntrySet _enclosing;
				}

				[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
				public override java.util.Iterator<java.util.MapClass.Entry<K, V>> iterator()
				{
					return new _BoundedIterator_1510(this, this._enclosing.endpoint(true));
				}

				[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
				public override bool contains(object o)
				{
					if (!(o is java.util.MapClass.Entry<K, V>))
					{
						return false;
					}
					java.util.MapClass.Entry<object, object> entry = (java.util.MapClass.Entry<object
						, object>)o;
					return this._enclosing.isInBounds(entry.getKey()) && this._enclosing._enclosing.findByEntry
						(entry) != null;
				}

				[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
				public override bool remove(object o)
				{
					if (!(o is java.util.MapClass.Entry<K, V>))
					{
						return false;
					}
					java.util.MapClass.Entry<object, object> entry = (java.util.MapClass.Entry<object
						, object>)o;
					return this._enclosing.isInBounds(entry.getKey()) && this._enclosing._enclosing.entrySet
						().remove(entry);
				}

				internal BoundedEntrySet(BoundedMap _enclosing)
				{
					this._enclosing = _enclosing;
				}

				private readonly BoundedMap _enclosing;
			}

			internal sealed class BoundedKeySet : java.util.AbstractSet<K>, java.util.NavigableSet
				<K>
			{
				[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
				public override int size()
				{
					return this._enclosing.size();
				}

				[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
				public override bool isEmpty()
				{
					return this._enclosing.isEmpty();
				}

				private sealed class _BoundedIterator_1544 : java.util.TreeMap<K, V>.BoundedMap.BoundedIterator
					<K>
				{
					public _BoundedIterator_1544(BoundedKeySet _enclosing, java.util.TreeMap.Node<K, 
						V> baseArg1) : base(_enclosing._enclosing, baseArg1)
					{
						this._enclosing = _enclosing;
					}

					[Sharpen.ImplementsInterface(@"java.util.Iterator")]
					public override K next()
					{
						return (this._enclosing._enclosing.ascending ? this.stepForward() : this.stepBackward
							()).key;
					}

					private readonly BoundedKeySet _enclosing;
				}

				[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
				public override java.util.Iterator<K> iterator()
				{
					return new _BoundedIterator_1544(this, this._enclosing.endpoint(true));
				}

				private sealed class _BoundedIterator_1552 : java.util.TreeMap<K, V>.BoundedMap.BoundedIterator
					<K>
				{
					public _BoundedIterator_1552(BoundedKeySet _enclosing, java.util.TreeMap.Node<K, 
						V> baseArg1) : base(_enclosing._enclosing, baseArg1)
					{
						this._enclosing = _enclosing;
					}

					[Sharpen.ImplementsInterface(@"java.util.Iterator")]
					public override K next()
					{
						return (this._enclosing._enclosing.ascending ? this.stepBackward() : this.stepForward
							()).key;
					}

					private readonly BoundedKeySet _enclosing;
				}

				[Sharpen.ImplementsInterface(@"java.util.NavigableSet")]
				public java.util.Iterator<K> descendingIterator()
				{
					return new _BoundedIterator_1552(this, this._enclosing.endpoint(false));
				}

				[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
				public override bool contains(object key)
				{
					return this._enclosing.isInBounds(key) && this._enclosing._enclosing.findByObject
						(key) != null;
				}

				[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
				public override bool remove(object key)
				{
					return this._enclosing.isInBounds(key) && this._enclosing._enclosing.removeInternalByKey
						(key) != null;
				}

				[Sharpen.ImplementsInterface(@"java.util.SortedSet")]
				public K first()
				{
					return this._enclosing.firstKey();
				}

				[Sharpen.ImplementsInterface(@"java.util.NavigableSet")]
				public K pollFirst()
				{
					java.util.MapClass.Entry<K, V> entry = this._enclosing.pollFirstEntry();
					return entry != null ? entry.getKey() : default(K);
				}

				[Sharpen.ImplementsInterface(@"java.util.SortedSet")]
				public K last()
				{
					return this._enclosing.lastKey();
				}

				[Sharpen.ImplementsInterface(@"java.util.NavigableSet")]
				public K pollLast()
				{
					java.util.MapClass.Entry<K, V> entry = this._enclosing.pollLastEntry();
					return entry != null ? entry.getKey() : default(K);
				}

				[Sharpen.ImplementsInterface(@"java.util.NavigableSet")]
				public K lower(K key)
				{
					return this._enclosing.lowerKey(key);
				}

				[Sharpen.ImplementsInterface(@"java.util.NavigableSet")]
				public K floor(K key)
				{
					return this._enclosing.floorKey(key);
				}

				[Sharpen.ImplementsInterface(@"java.util.NavigableSet")]
				public K ceiling(K key)
				{
					return this._enclosing.ceilingKey(key);
				}

				[Sharpen.ImplementsInterface(@"java.util.NavigableSet")]
				public K higher(K key)
				{
					return this._enclosing.higherKey(key);
				}

				[Sharpen.ImplementsInterface(@"java.util.SortedSet")]
				public java.util.Comparator<K> comparator()
				{
					return this._enclosing.comparator();
				}

				[Sharpen.ImplementsInterface(@"java.util.NavigableSet")]
				public java.util.NavigableSet<K> subSet(K from, bool fromInclusive, K to, bool toInclusive
					)
				{
					return this._enclosing.subMap(from, fromInclusive, to, toInclusive).navigableKeySet
						();
				}

				[Sharpen.ImplementsInterface(@"java.util.SortedSet")]
				public java.util.SortedSet<K> subSet(K fromInclusive, K toExclusive)
				{
					return this._enclosing.subMap(fromInclusive, toExclusive).navigableKeySet();
				}

				[Sharpen.ImplementsInterface(@"java.util.NavigableSet")]
				public java.util.NavigableSet<K> headSet(K to, bool inclusive)
				{
					return this._enclosing.headMap(to, inclusive).navigableKeySet();
				}

				[Sharpen.ImplementsInterface(@"java.util.SortedSet")]
				public java.util.SortedSet<K> headSet(K toExclusive)
				{
					return this._enclosing.headMap(toExclusive).navigableKeySet();
				}

				[Sharpen.ImplementsInterface(@"java.util.NavigableSet")]
				public java.util.NavigableSet<K> tailSet(K from, bool inclusive)
				{
					return this._enclosing.tailMap(from, inclusive).navigableKeySet();
				}

				[Sharpen.ImplementsInterface(@"java.util.SortedSet")]
				public java.util.SortedSet<K> tailSet(K fromInclusive)
				{
					return this._enclosing.tailMap(fromInclusive).navigableKeySet();
				}

				[Sharpen.ImplementsInterface(@"java.util.NavigableSet")]
				public java.util.NavigableSet<K> descendingSet()
				{
					return new java.util.TreeMap<K, V>.BoundedMap(this._enclosing._enclosing, !this._enclosing
						.ascending, this._enclosing.from, this._enclosing.fromBound, this._enclosing.to, 
						this._enclosing.toBound).navigableKeySet();
				}

				internal BoundedKeySet(BoundedMap _enclosing)
				{
					this._enclosing = _enclosing;
				}

				private readonly BoundedMap _enclosing;
			}

			private readonly TreeMap<K, V> _enclosing;
		}

		/// <summary>Returns the number of elements in the iteration.</summary>
		/// <remarks>Returns the number of elements in the iteration.</remarks>
		internal static int count<_T0>(java.util.Iterator<_T0> iterator)
		{
			int count_1 = 0;
			while (iterator.hasNext())
			{
				iterator.next();
				count_1++;
			}
			return count_1;
		}

		/// <exception cref="System.IO.IOException"></exception>
		private void writeObject(java.io.ObjectOutputStream stream)
		{
			stream.putFields().put("comparator", _comparator != NATURAL_ORDER ? _comparator : 
				null);
			stream.writeFields();
			stream.writeInt(_size);
			foreach (java.util.MapClass.Entry<K, V> entry in Sharpen.IterableProxy.Create(entrySet
				()))
			{
				stream.writeObject(entry.getKey());
				stream.writeObject(entry.getValue());
			}
		}

		/// <exception cref="System.IO.IOException"></exception>
		/// <exception cref="java.lang.ClassNotFoundException"></exception>
		private void readObject(java.io.ObjectInputStream stream)
		{
			java.io.ObjectInputStream.GetField fields = stream.readFields();
			_comparator = (java.util.Comparator<K>)fields.get("comparator", null);
			if (_comparator == null)
			{
				_comparator = (java.util.Comparator<K>)NATURAL_ORDER;
			}
			int size_1 = stream.readInt();
			{
				for (int i = 0; i < size_1; i++)
				{
					putInternal((K)stream.readObject(), (V)stream.readObject());
				}
			}
		}

		[System.Serializable]
		internal class SubMap : java.util.AbstractMap<K, V>
		{
			internal const long serialVersionUID = -6520786458950516097L;

			internal object fromKey;

			internal object toKey;

			internal bool fromStart;

			internal bool toEnd;

			[Sharpen.OverridesMethod(@"java.util.AbstractMap")]
			public override java.util.Set<java.util.MapClass.Entry<K, V>> entrySet()
			{
				throw new System.NotSupportedException();
			}

			/// <exception cref="java.io.ObjectStreamException"></exception>
			protected internal virtual object readResolve()
			{
				// we have to trust that the bounds are Ks
				java.util.TreeMap.Bound fromBound = this.fromStart ? java.util.TreeMap.Bound.NO_BOUND
					 : java.util.TreeMap.Bound.INCLUSIVE;
				java.util.TreeMap.Bound toBound = this.toEnd ? java.util.TreeMap.Bound.NO_BOUND : 
					java.util.TreeMap.Bound.EXCLUSIVE;
				return new java.util.TreeMap<K, V>.BoundedMap(this._enclosing, true, (K)this.fromKey
					, fromBound, (K)this.toKey, toBound);
			}

			internal SubMap(TreeMap<K, V> _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly TreeMap<K, V> _enclosing;
		}

		object System.ICloneable.Clone()
		{
			return MemberwiseClone();
		}
	}
}

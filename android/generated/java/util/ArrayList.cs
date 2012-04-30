using Sharpen;

namespace java.util
{
	/// <summary>
	/// ArrayList is an implementation of
	/// <see cref="List{E}">List&lt;E&gt;</see>
	/// , backed by an array.
	/// All optional operations including adding, removing, and replacing elements are supported.
	/// <p>All elements are permitted, including null.
	/// <p>This class is a good choice as your default
	/// <code>List</code>
	/// implementation.
	/// <see cref="Vector{E}">Vector&lt;E&gt;</see>
	/// synchronizes all operations, but not necessarily in a way that's
	/// meaningful to your application: synchronizing each call to
	/// <code>get</code>
	/// , for example, is not
	/// equivalent to synchronizing the list and iterating over it (which is probably what you intended).
	/// <see cref="java.util.concurrent.CopyOnWriteArrayList{E}">java.util.concurrent.CopyOnWriteArrayList&lt;E&gt;
	/// 	</see>
	/// is intended for the special case of very high
	/// concurrency, frequent traversals, and very rare mutations.
	/// </summary>
	/// <?></?>
	/// <since>1.2</since>
	[Sharpen.Sharpened]
	public static class ArrayList
	{
		/// <summary>The minimum amount by which the capacity of an ArrayList will increase.</summary>
		/// <remarks>
		/// The minimum amount by which the capacity of an ArrayList will increase.
		/// This tuning parameter controls a time-space tradeoff. This value (12)
		/// gives empirically good results and is arguably consistent with the
		/// RI's specified default initial capacity of 10: instead of 10, we start
		/// with 0 (sans allocation) and jump to 12.
		/// </remarks>
		internal const int MIN_CAPACITY_INCREMENT = 12;

		internal const long serialVersionUID = 8683452581122892189L;
	}

	/// <summary>
	/// ArrayList is an implementation of
	/// <see cref="List{E}">List&lt;E&gt;</see>
	/// , backed by an array.
	/// All optional operations including adding, removing, and replacing elements are supported.
	/// <p>All elements are permitted, including null.
	/// <p>This class is a good choice as your default
	/// <code>List</code>
	/// implementation.
	/// <see cref="Vector{E}">Vector&lt;E&gt;</see>
	/// synchronizes all operations, but not necessarily in a way that's
	/// meaningful to your application: synchronizing each call to
	/// <code>get</code>
	/// , for example, is not
	/// equivalent to synchronizing the list and iterating over it (which is probably what you intended).
	/// <see cref="java.util.concurrent.CopyOnWriteArrayList{E}">java.util.concurrent.CopyOnWriteArrayList&lt;E&gt;
	/// 	</see>
	/// is intended for the special case of very high
	/// concurrency, frequent traversals, and very rare mutations.
	/// </summary>
	/// <?></?>
	/// <since>1.2</since>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class ArrayList<E> : java.util.AbstractList<E>, System.ICloneable, java.util.RandomAccess
	{
		/// <summary>The number of elements in this list.</summary>
		/// <remarks>The number of elements in this list.</remarks>
		internal int _size;

		/// <summary>The elements in this list, followed by nulls.</summary>
		/// <remarks>The elements in this list, followed by nulls.</remarks>
		[System.NonSerialized]
		internal object[] array;

		/// <summary>
		/// Constructs a new instance of
		/// <code>ArrayList</code>
		/// with the specified
		/// initial capacity.
		/// </summary>
		/// <param name="capacity">
		/// the initial capacity of this
		/// <code>ArrayList</code>
		/// .
		/// </param>
		public ArrayList(int capacity)
		{
			if (capacity < 0)
			{
				throw new System.ArgumentException();
			}
			array = (capacity == 0 ? libcore.util.EmptyArray.OBJECT : new object[capacity]);
		}

		/// <summary>
		/// Constructs a new
		/// <code>ArrayList</code>
		/// instance with zero initial capacity.
		/// </summary>
		public ArrayList()
		{
			array = libcore.util.EmptyArray.OBJECT;
		}

		/// <summary>
		/// Constructs a new instance of
		/// <code>ArrayList</code>
		/// containing the elements of
		/// the specified collection.
		/// </summary>
		/// <param name="collection">the collection of elements to add.</param>
		public ArrayList(java.util.Collection<E> collection)
		{
			object[] a = collection.toArray();
			if (a.GetType() != typeof(object[]))
			{
				object[] newArray = new object[a.Length];
				System.Array.Copy(a, 0, newArray, 0, a.Length);
				a = newArray;
			}
			array = a;
			_size = a.Length;
		}

		/// <summary>
		/// Adds the specified object at the end of this
		/// <code>ArrayList</code>
		/// .
		/// </summary>
		/// <param name="object">the object to add.</param>
		/// <returns>always true</returns>
		[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
		public override bool add(E @object)
		{
			object[] a = array;
			int s = _size;
			if (s == a.Length)
			{
				object[] newArray = new object[s + (s < (java.util.ArrayList.MIN_CAPACITY_INCREMENT
					 / 2) ? java.util.ArrayList.MIN_CAPACITY_INCREMENT : s >> 1)];
				System.Array.Copy(a, 0, newArray, 0, s);
				array = a = newArray;
			}
			a[s] = @object;
			_size = s + 1;
			modCount++;
			return true;
		}

		/// <summary>
		/// Inserts the specified object into this
		/// <code>ArrayList</code>
		/// at the specified
		/// location. The object is inserted before any previous element at the
		/// specified location. If the location is equal to the size of this
		/// <code>ArrayList</code>
		/// , the object is added at the end.
		/// </summary>
		/// <param name="index">the index at which to insert the object.</param>
		/// <param name="object">the object to add.</param>
		/// <exception cref="System.IndexOutOfRangeException">
		/// when
		/// <code>location &lt; 0 || &gt; size()</code>
		/// </exception>
		[Sharpen.OverridesMethod(@"java.util.AbstractList")]
		public override void add(int index, E @object)
		{
			object[] a = array;
			int s = _size;
			if (index > s || index < 0)
			{
				throwIndexOutOfBoundsException(index, s);
			}
			if (s < a.Length)
			{
				System.Array.Copy(a, index, a, index + 1, s - index);
			}
			else
			{
				// assert s == a.length;
				object[] newArray = new object[newCapacity(s)];
				System.Array.Copy(a, 0, newArray, 0, index);
				System.Array.Copy(a, index, newArray, index + 1, s - index);
				array = a = newArray;
			}
			a[index] = @object;
			_size = s + 1;
			modCount++;
		}

		/// <summary>This method controls the growth of ArrayList capacities.</summary>
		/// <remarks>
		/// This method controls the growth of ArrayList capacities.  It represents
		/// a time-space tradeoff: we don't want to grow lists too frequently
		/// (which wastes time and fragments storage), but we don't want to waste
		/// too much space in unused excess capacity.
		/// NOTE: This method is inlined into
		/// <see cref="ArrayList{E}.add(object)">ArrayList&lt;E&gt;.add(object)</see>
		/// for performance.
		/// If you change the method, change it there too!
		/// </remarks>
		private static int newCapacity(int currentCapacity)
		{
			int increment = (currentCapacity < (java.util.ArrayList.MIN_CAPACITY_INCREMENT / 
				2) ? java.util.ArrayList.MIN_CAPACITY_INCREMENT : currentCapacity >> 1);
			return currentCapacity + increment;
		}

		/// <summary>
		/// Adds the objects in the specified collection to this
		/// <code>ArrayList</code>
		/// .
		/// </summary>
		/// <param name="collection">the collection of objects.</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if this
		/// <code>ArrayList</code>
		/// is modified,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
		public override bool addAll<_T0>(java.util.Collection<_T0> collection)
		{
			object[] newPart = collection.toArray();
			int newPartSize = newPart.Length;
			if (newPartSize == 0)
			{
				return false;
			}
			object[] a = array;
			int s = _size;
			int newSize = s + newPartSize;
			// If add overflows, arraycopy will fail
			if (newSize > a.Length)
			{
				int newCapacity_1 = newCapacity(newSize - 1);
				// ~33% growth room
				object[] newArray = new object[newCapacity_1];
				System.Array.Copy(a, 0, newArray, 0, s);
				array = a = newArray;
			}
			System.Array.Copy(newPart, 0, a, s, newPartSize);
			_size = newSize;
			modCount++;
			return true;
		}

		/// <summary>
		/// Inserts the objects in the specified collection at the specified location
		/// in this List.
		/// </summary>
		/// <remarks>
		/// Inserts the objects in the specified collection at the specified location
		/// in this List. The objects are added in the order they are returned from
		/// the collection's iterator.
		/// </remarks>
		/// <param name="index">the index at which to insert.</param>
		/// <param name="collection">the collection of objects.</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if this
		/// <code>ArrayList</code>
		/// is modified,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		/// <exception cref="System.IndexOutOfRangeException">
		/// when
		/// <code>location &lt; 0 || &gt; size()</code>
		/// </exception>
		[Sharpen.OverridesMethod(@"java.util.AbstractList")]
		public override bool addAll<_T0>(int index, java.util.Collection<_T0> collection)
		{
			int s = _size;
			if (index > s || index < 0)
			{
				throwIndexOutOfBoundsException(index, s);
			}
			object[] newPart = collection.toArray();
			int newPartSize = newPart.Length;
			if (newPartSize == 0)
			{
				return false;
			}
			object[] a = array;
			int newSize = s + newPartSize;
			// If add overflows, arraycopy will fail
			if (newSize <= a.Length)
			{
				System.Array.Copy(a, index, a, index + newPartSize, s - index);
			}
			else
			{
				int newCapacity_1 = newCapacity(newSize - 1);
				// ~33% growth room
				object[] newArray = new object[newCapacity_1];
				System.Array.Copy(a, 0, newArray, 0, index);
				System.Array.Copy(a, index, newArray, index + newPartSize, s - index);
				array = a = newArray;
			}
			System.Array.Copy(newPart, 0, a, index, newPartSize);
			_size = newSize;
			modCount++;
			return true;
		}

		/// <summary>This method was extracted to encourage VM to inline callers.</summary>
		/// <remarks>
		/// This method was extracted to encourage VM to inline callers.
		/// TODO: when we have a VM that can actually inline, move the test in here too!
		/// </remarks>
		internal static System.IndexOutOfRangeException throwIndexOutOfBoundsException(int
			 index, int size_1)
		{
			throw new System.IndexOutOfRangeException("Invalid index " + index + ", size is "
				 + size_1);
		}

		/// <summary>
		/// Removes all elements from this
		/// <code>ArrayList</code>
		/// , leaving it empty.
		/// </summary>
		/// <seealso cref="ArrayList{E}.isEmpty()">ArrayList&lt;E&gt;.isEmpty()</seealso>
		/// <seealso cref="ArrayList{E}._size">ArrayList&lt;E&gt;._size</seealso>
		[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
		public override void clear()
		{
			if (_size != 0)
			{
				java.util.Arrays.fill(array, 0, _size, null);
				_size = 0;
				modCount++;
			}
		}

		/// <summary>
		/// Returns a new
		/// <code>ArrayList</code>
		/// with the same elements, the same size and
		/// the same capacity as this
		/// <code>ArrayList</code>
		/// .
		/// </summary>
		/// <returns>
		/// a shallow copy of this
		/// <code>ArrayList</code>
		/// </returns>
		/// <seealso cref="System.ICloneable">System.ICloneable</seealso>
		public virtual object clone()
		{
			java.util.ArrayList<E> result = (java.util.ArrayList<E>)base.MemberwiseClone();
			result.array = (object[])array.Clone();
			return result;
		}

		/// <summary>
		/// Ensures that after this operation the
		/// <code>ArrayList</code>
		/// can hold the
		/// specified number of elements without further growing.
		/// </summary>
		/// <param name="minimumCapacity">the minimum capacity asked for.</param>
		public virtual void ensureCapacity(int minimumCapacity)
		{
			object[] a = array;
			if (a.Length < minimumCapacity)
			{
				object[] newArray = new object[minimumCapacity];
				System.Array.Copy(a, 0, newArray, 0, _size);
				array = newArray;
				modCount++;
			}
		}

		[Sharpen.OverridesMethod(@"java.util.AbstractList")]
		public override E get(int index)
		{
			if (index >= _size)
			{
				throwIndexOutOfBoundsException(index, _size);
			}
			return (E)array[index];
		}

		/// <summary>
		/// Returns the number of elements in this
		/// <code>ArrayList</code>
		/// .
		/// </summary>
		/// <returns>
		/// the number of elements in this
		/// <code>ArrayList</code>
		/// .
		/// </returns>
		[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
		public override int size()
		{
			return _size;
		}

		[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
		public override bool isEmpty()
		{
			return _size == 0;
		}

		/// <summary>
		/// Searches this
		/// <code>ArrayList</code>
		/// for the specified object.
		/// </summary>
		/// <param name="object">the object to search for.</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if
		/// <code>object</code>
		/// is an element of this
		/// <code>ArrayList</code>
		/// ,
		/// <code>false</code>
		/// otherwise
		/// </returns>
		[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
		public override bool contains(object @object)
		{
			object[] a = array;
			int s = _size;
			if (@object != null)
			{
				{
					for (int i = 0; i < s; i++)
					{
						if (@object.Equals(a[i]))
						{
							return true;
						}
					}
				}
			}
			else
			{
				{
					for (int i = 0; i < s; i++)
					{
						if (a[i] == null)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		[Sharpen.OverridesMethod(@"java.util.AbstractList")]
		public override int indexOf(object @object)
		{
			object[] a = array;
			int s = _size;
			if (@object != null)
			{
				{
					for (int i = 0; i < s; i++)
					{
						if (@object.Equals(a[i]))
						{
							return i;
						}
					}
				}
			}
			else
			{
				{
					for (int i = 0; i < s; i++)
					{
						if (a[i] == null)
						{
							return i;
						}
					}
				}
			}
			return -1;
		}

		[Sharpen.OverridesMethod(@"java.util.AbstractList")]
		public override int lastIndexOf(object @object)
		{
			object[] a = array;
			if (@object != null)
			{
				{
					for (int i = _size - 1; i >= 0; i--)
					{
						if (@object.Equals(a[i]))
						{
							return i;
						}
					}
				}
			}
			else
			{
				{
					for (int i = _size - 1; i >= 0; i--)
					{
						if (a[i] == null)
						{
							return i;
						}
					}
				}
			}
			return -1;
		}

		/// <summary>Removes the object at the specified location from this list.</summary>
		/// <remarks>Removes the object at the specified location from this list.</remarks>
		/// <param name="index">the index of the object to remove.</param>
		/// <returns>the removed object.</returns>
		/// <exception cref="System.IndexOutOfRangeException">
		/// when
		/// <code>location &lt; 0 || &gt;= size()</code>
		/// </exception>
		[Sharpen.OverridesMethod(@"java.util.AbstractList")]
		public override E remove(int index)
		{
			object[] a = array;
			int s = _size;
			if (index >= s)
			{
				throwIndexOutOfBoundsException(index, s);
			}
			E result = (E)a[index];
			System.Array.Copy(a, index + 1, a, index, --s - index);
			a[s] = null;
			// Prevent memory leak
			_size = s;
			modCount++;
			return result;
		}

		[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
		public override bool remove(object @object)
		{
			object[] a = array;
			int s = _size;
			if (@object != null)
			{
				{
					for (int i = 0; i < s; i++)
					{
						if (@object.Equals(a[i]))
						{
							System.Array.Copy(a, i + 1, a, i, --s - i);
							a[s] = null;
							// Prevent memory leak
							_size = s;
							modCount++;
							return true;
						}
					}
				}
			}
			else
			{
				{
					for (int i = 0; i < s; i++)
					{
						if (a[i] == null)
						{
							System.Array.Copy(a, i + 1, a, i, --s - i);
							a[s] = null;
							// Prevent memory leak
							_size = s;
							modCount++;
							return true;
						}
					}
				}
			}
			return false;
		}

		[Sharpen.OverridesMethod(@"java.util.AbstractList")]
		protected internal override void removeRange(int fromIndex, int toIndex)
		{
			if (fromIndex == toIndex)
			{
				return;
			}
			object[] a = array;
			int s = _size;
			if (fromIndex >= s)
			{
				throw new System.IndexOutOfRangeException("fromIndex " + fromIndex + " >= size " 
					+ _size);
			}
			if (toIndex > s)
			{
				throw new System.IndexOutOfRangeException("toIndex " + toIndex + " > size " + _size
					);
			}
			if (fromIndex > toIndex)
			{
				throw new System.IndexOutOfRangeException("fromIndex " + fromIndex + " > toIndex "
					 + toIndex);
			}
			System.Array.Copy(a, toIndex, a, fromIndex, s - toIndex);
			int rangeSize = toIndex - fromIndex;
			java.util.Arrays.fill(a, s - rangeSize, s, null);
			_size = s - rangeSize;
			modCount++;
		}

		/// <summary>
		/// Replaces the element at the specified location in this
		/// <code>ArrayList</code>
		/// with the specified object.
		/// </summary>
		/// <param name="index">the index at which to put the specified object.</param>
		/// <param name="object">the object to add.</param>
		/// <returns>the previous element at the index.</returns>
		/// <exception cref="System.IndexOutOfRangeException">
		/// when
		/// <code>location &lt; 0 || &gt;= size()</code>
		/// </exception>
		[Sharpen.OverridesMethod(@"java.util.AbstractList")]
		public override E set(int index, E @object)
		{
			object[] a = array;
			if (index >= _size)
			{
				throwIndexOutOfBoundsException(index, _size);
			}
			E result = (E)a[index];
			a[index] = @object;
			return result;
		}

		/// <summary>
		/// Returns a new array containing all elements contained in this
		/// <code>ArrayList</code>
		/// .
		/// </summary>
		/// <returns>
		/// an array of the elements from this
		/// <code>ArrayList</code>
		/// </returns>
		[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
		public override object[] toArray()
		{
			int s = _size;
			object[] result = new object[s];
			System.Array.Copy(array, 0, result, 0, s);
			return result;
		}

		/// <summary>
		/// Returns an array containing all elements contained in this
		/// <code>ArrayList</code>
		/// . If the specified array is large enough to hold the
		/// elements, the specified array is used, otherwise an array of the same
		/// type is created. If the specified array is used and is larger than this
		/// <code>ArrayList</code>
		/// , the array element following the collection elements
		/// is set to null.
		/// </summary>
		/// <param name="contents">the array.</param>
		/// <returns>
		/// an array of the elements from this
		/// <code>ArrayList</code>
		/// .
		/// </returns>
		/// <exception cref="java.lang.ArrayStoreException">
		/// when the type of an element in this
		/// <code>ArrayList</code>
		/// cannot
		/// be stored in the type of the specified array.
		/// </exception>
		[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
		public override T[] toArray<T>(T[] contents)
		{
			int s = _size;
			if (contents.Length < s)
			{
				T[] newArray = (T[])System.Array.CreateInstance(contents.GetType().GetElementType
					(), s);
				contents = newArray;
			}
			System.Array.Copy(this.array, 0, contents, 0, s);
			if (contents.Length > s)
			{
				contents[s] = default(T);
			}
			return contents;
		}

		/// <summary>
		/// Sets the capacity of this
		/// <code>ArrayList</code>
		/// to be the same as the current
		/// size.
		/// </summary>
		/// <seealso cref="ArrayList{E}._size">ArrayList&lt;E&gt;._size</seealso>
		public virtual void trimToSize()
		{
			int s = _size;
			if (s == array.Length)
			{
				return;
			}
			if (s == 0)
			{
				array = libcore.util.EmptyArray.OBJECT;
			}
			else
			{
				object[] newArray = new object[s];
				System.Array.Copy(array, 0, newArray, 0, s);
				array = newArray;
			}
			modCount++;
		}

		[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
		public override java.util.Iterator<E> iterator()
		{
			return new java.util.ArrayList<E>.ArrayListIterator(this);
		}

		private class ArrayListIterator : java.util.Iterator<E>
		{
			/// <summary>Number of elements remaining in this iteration</summary>
			internal int remaining;

			/// <summary>Index of element that remove() would remove, or -1 if no such elt</summary>
			internal int removalIndex;

			/// <summary>The expected modCount value</summary>
			internal int expectedModCount;

			[Sharpen.ImplementsInterface(@"java.util.Iterator")]
			public virtual bool hasNext()
			{
				return this.remaining != 0;
			}

			[Sharpen.ImplementsInterface(@"java.util.Iterator")]
			public virtual E next()
			{
				java.util.ArrayList<E> ourList = this._enclosing;
				int rem = this.remaining;
				if (ourList.modCount != this.expectedModCount)
				{
					throw new java.util.ConcurrentModificationException();
				}
				if (rem == 0)
				{
					throw new java.util.NoSuchElementException();
				}
				this.remaining = rem - 1;
				return (E)ourList.array[this.removalIndex = ourList._size - rem];
			}

			[Sharpen.ImplementsInterface(@"java.util.Iterator")]
			public virtual void remove()
			{
				object[] a = this._enclosing.array;
				int removalIdx = this.removalIndex;
				if (this._enclosing.modCount != this.expectedModCount)
				{
					throw new java.util.ConcurrentModificationException();
				}
				if (removalIdx < 0)
				{
					throw new System.InvalidOperationException();
				}
				System.Array.Copy(a, removalIdx + 1, a, removalIdx, this.remaining);
				a[--this._enclosing._size] = null;
				// Prevent memory leak
				this.removalIndex = -1;
				this.expectedModCount = ++this._enclosing.modCount;
			}

			public ArrayListIterator(ArrayList<E> _enclosing)
			{
				this._enclosing = _enclosing;
				remaining = this._enclosing._size;
				removalIndex = -1;
				expectedModCount = this._enclosing.modCount;
			}

			private readonly ArrayList<E> _enclosing;
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override int GetHashCode()
		{
			object[] a = array;
			int hashCode_1 = 1;
			{
				int i = 0;
				int s = _size;
				for (; i < s; i++)
				{
					object e = a[i];
					hashCode_1 = 31 * hashCode_1 + (e == null ? 0 : e.GetHashCode());
				}
			}
			return hashCode_1;
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override bool Equals(object o)
		{
			if (o == this)
			{
				return true;
			}
			if (!(o is java.util.List<E>))
			{
				return false;
			}
			java.util.List<E> that = (java.util.List<E>)o;
			int s = _size;
			if (that.size() != s)
			{
				return false;
			}
			object[] a = array;
			if (that is java.util.RandomAccess)
			{
				{
					for (int i = 0; i < s; i++)
					{
						object eThis = a[i];
						object ethat = that.get(i);
						if (eThis == null ? ethat != null : !eThis.Equals(ethat))
						{
							return false;
						}
					}
				}
			}
			else
			{
				// Argument list is not random access; use its iterator
				java.util.Iterator<E> it = that.iterator();
				{
					for (int i = 0; i < s; i++)
					{
						object eThis = a[i];
						object eThat = it.next();
						if (eThis == null ? eThat != null : !eThis.Equals(eThat))
						{
							return false;
						}
					}
				}
			}
			return true;
		}

		/// <exception cref="System.IO.IOException"></exception>
		private void writeObject(java.io.ObjectOutputStream stream)
		{
			stream.defaultWriteObject();
			stream.writeInt(array.Length);
			{
				for (int i = 0; i < _size; i++)
				{
					stream.writeObject(array[i]);
				}
			}
		}

		/// <exception cref="System.IO.IOException"></exception>
		/// <exception cref="java.lang.ClassNotFoundException"></exception>
		private void readObject(java.io.ObjectInputStream stream)
		{
			stream.defaultReadObject();
			int cap = stream.readInt();
			if (cap < _size)
			{
				throw new java.io.InvalidObjectException("Capacity: " + cap + " < size: " + _size
					);
			}
			array = (cap == 0 ? libcore.util.EmptyArray.OBJECT : new object[cap]);
			{
				for (int i = 0; i < _size; i++)
				{
					array[i] = stream.readObject();
				}
			}
		}

		object System.ICloneable.Clone()
		{
			return MemberwiseClone();
		}
	}
}

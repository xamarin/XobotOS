using Sharpen;

namespace java.util
{
	/// <summary>
	/// Vector is an implementation of
	/// <see cref="List{E}">List&lt;E&gt;</see>
	/// , backed by an array and synchronized.
	/// All optional operations including adding, removing, and replacing elements are supported.
	/// <p>All elements are permitted, including null.
	/// <p>This class is equivalent to
	/// <see cref="ArrayList{E}">ArrayList&lt;E&gt;</see>
	/// with synchronized operations. This has a
	/// performance cost, and the synchronization is not necessarily meaningful to your application:
	/// synchronizing each call to
	/// <code>get</code>
	/// , for example, is not equivalent to synchronizing on the
	/// list and iterating over it (which is probably what you intended). If you do need very highly
	/// concurrent access, you should also consider
	/// <see cref="java.util.concurrent.CopyOnWriteArrayList{E}">java.util.concurrent.CopyOnWriteArrayList&lt;E&gt;
	/// 	</see>
	/// .
	/// </summary>
	/// <?></?>
	[Sharpen.Sharpened]
	public static partial class Vector
	{
		internal const long serialVersionUID = -2767605614048989439L;

		internal const int DEFAULT_SIZE = 10;
	}

	/// <summary>
	/// Vector is an implementation of
	/// <see cref="List{E}">List&lt;E&gt;</see>
	/// , backed by an array and synchronized.
	/// All optional operations including adding, removing, and replacing elements are supported.
	/// <p>All elements are permitted, including null.
	/// <p>This class is equivalent to
	/// <see cref="ArrayList{E}">ArrayList&lt;E&gt;</see>
	/// with synchronized operations. This has a
	/// performance cost, and the synchronization is not necessarily meaningful to your application:
	/// synchronizing each call to
	/// <code>get</code>
	/// , for example, is not equivalent to synchronizing on the
	/// list and iterating over it (which is probably what you intended). If you do need very highly
	/// concurrent access, you should also consider
	/// <see cref="java.util.concurrent.CopyOnWriteArrayList{E}">java.util.concurrent.CopyOnWriteArrayList&lt;E&gt;
	/// 	</see>
	/// .
	/// </summary>
	/// <?></?>
	[System.Serializable]
	[Sharpen.Sharpened]
	public partial class Vector<E> : java.util.AbstractList<E>, java.util.List<E>, java.util.RandomAccess
		, System.ICloneable
	{
		/// <summary>The number of elements or the size of the vector.</summary>
		/// <remarks>The number of elements or the size of the vector.</remarks>
		protected internal int elementCount;

		/// <summary>The elements of the vector.</summary>
		/// <remarks>The elements of the vector.</remarks>
		protected internal object[] elementData;

		/// <summary>
		/// How many elements should be added to the vector when it is detected that
		/// it needs to grow to accommodate extra entries.
		/// </summary>
		/// <remarks>
		/// How many elements should be added to the vector when it is detected that
		/// it needs to grow to accommodate extra entries. If this value is zero or
		/// negative the size will be doubled if an increase is needed.
		/// </remarks>
		protected internal int capacityIncrement;

		/// <summary>Constructs a new vector using the default capacity.</summary>
		/// <remarks>Constructs a new vector using the default capacity.</remarks>
		public Vector() : this(java.util.Vector.DEFAULT_SIZE, 0)
		{
		}

		/// <summary>Constructs a new vector using the specified capacity.</summary>
		/// <remarks>Constructs a new vector using the specified capacity.</remarks>
		/// <param name="capacity">the initial capacity of the new vector.</param>
		/// <exception cref="System.ArgumentException">
		/// if
		/// <code>capacity</code>
		/// is negative.
		/// </exception>
		public Vector(int capacity_1) : this(capacity_1, 0)
		{
		}

		/// <summary>
		/// Constructs a new instance of
		/// <code>Vector</code>
		/// containing the elements in
		/// <code>collection</code>
		/// . The order of the elements in the new
		/// <code>Vector</code>
		/// is dependent on the iteration order of the seed collection.
		/// </summary>
		/// <param name="collection">the collection of elements to add.</param>
		public Vector(java.util.Collection<E> collection) : this(collection.size(), 0)
		{
			java.util.Iterator<E> it = collection.iterator();
			while (it.hasNext())
			{
				elementData[elementCount++] = it.next();
			}
		}

		/// <summary>Adds the specified object into this vector at the specified location.</summary>
		/// <remarks>
		/// Adds the specified object into this vector at the specified location. The
		/// object is inserted before any element with the same or a higher index
		/// increasing their index by 1. If the location is equal to the size of this
		/// vector, the object is added at the end.
		/// </remarks>
		/// <param name="location">the index at which to insert the element.</param>
		/// <param name="object">the object to insert in this vector.</param>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>location &lt; 0 || location &gt; size()</code>
		/// .
		/// </exception>
		/// <seealso cref="Vector{E}.addElement(object)">Vector&lt;E&gt;.addElement(object)</seealso>
		/// <seealso cref="Vector{E}.size()">Vector&lt;E&gt;.size()</seealso>
		[Sharpen.OverridesMethod(@"java.util.AbstractList")]
		public override void add(int location, E @object)
		{
			insertElementAt(@object, location);
		}

		/// <summary>Adds the specified object at the end of this vector.</summary>
		/// <remarks>Adds the specified object at the end of this vector.</remarks>
		/// <param name="object">the object to add to the vector.</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// </returns>
		[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
		public override bool add(E @object)
		{
			lock (this)
			{
				if (elementCount == elementData.Length)
				{
					growByOne();
				}
				elementData[elementCount++] = @object;
				modCount++;
				return true;
			}
		}

		/// <summary>
		/// Inserts the objects in the specified collection at the specified location
		/// in this vector.
		/// </summary>
		/// <remarks>
		/// Inserts the objects in the specified collection at the specified location
		/// in this vector. The objects are inserted in the order in which they are
		/// returned from the Collection iterator. The elements with an index equal
		/// or higher than
		/// <code>location</code>
		/// have their index increased by the size of
		/// the added collection.
		/// </remarks>
		/// <param name="location">the location to insert the objects.</param>
		/// <param name="collection">the collection of objects.</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if this vector is modified,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>location &lt; 0</code>
		/// or
		/// <code>location &gt; size()</code>
		/// .
		/// </exception>
		[Sharpen.OverridesMethod(@"java.util.AbstractList")]
		public override bool addAll<_T0>(int location, java.util.Collection<_T0> collection
			)
		{
			lock (this)
			{
				if (location >= 0 && location <= elementCount)
				{
					int size_1 = collection.size();
					if (size_1 == 0)
					{
						return false;
					}
					int required = size_1 - (elementData.Length - elementCount);
					if (required > 0)
					{
						growBy(required);
					}
					int count = elementCount - location;
					if (count > 0)
					{
						System.Array.Copy(elementData, location, elementData, location + size_1, count);
					}
					java.util.Iterator<_T0> it = collection.iterator();
					while (it.hasNext())
					{
						elementData[location++] = it.next();
					}
					elementCount += size_1;
					modCount++;
					return true;
				}
				throw arrayIndexOutOfBoundsException(location, elementCount);
			}
		}

		/// <summary>Adds the objects in the specified collection to the end of this vector.</summary>
		/// <remarks>Adds the objects in the specified collection to the end of this vector.</remarks>
		/// <param name="collection">the collection of objects.</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if this vector is modified,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
		public override bool addAll<_T0>(java.util.Collection<_T0> collection)
		{
			lock (this)
			{
				return addAll(elementCount, collection);
			}
		}

		/// <summary>Adds the specified object at the end of this vector.</summary>
		/// <remarks>Adds the specified object at the end of this vector.</remarks>
		/// <param name="object">the object to add to the vector.</param>
		public virtual void addElement(E @object)
		{
			lock (this)
			{
				if (elementCount == elementData.Length)
				{
					growByOne();
				}
				elementData[elementCount++] = @object;
				modCount++;
			}
		}

		/// <summary>Returns the number of elements this vector can hold without growing.</summary>
		/// <remarks>Returns the number of elements this vector can hold without growing.</remarks>
		/// <returns>the capacity of this vector.</returns>
		/// <seealso cref="Vector{E}.ensureCapacity(int)">Vector&lt;E&gt;.ensureCapacity(int)
		/// 	</seealso>
		/// <seealso cref="Vector{E}.size()">Vector&lt;E&gt;.size()</seealso>
		public virtual int capacity()
		{
			lock (this)
			{
				return elementData.Length;
			}
		}

		/// <summary>Removes all elements from this vector, leaving it empty.</summary>
		/// <remarks>Removes all elements from this vector, leaving it empty.</remarks>
		/// <seealso cref="Vector{E}.isEmpty()">Vector&lt;E&gt;.isEmpty()</seealso>
		/// <seealso cref="Vector{E}.size()">Vector&lt;E&gt;.size()</seealso>
		[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
		public override void clear()
		{
			removeAllElements();
		}

		/// <summary>
		/// Returns a new vector with the same elements, size, capacity and capacity
		/// increment as this vector.
		/// </summary>
		/// <remarks>
		/// Returns a new vector with the same elements, size, capacity and capacity
		/// increment as this vector.
		/// </remarks>
		/// <returns>a shallow copy of this vector.</returns>
		/// <seealso cref="System.ICloneable">System.ICloneable</seealso>
		public virtual object clone()
		{
			lock (this)
			{
				java.util.Vector<E> vector = (java.util.Vector<E>)base.MemberwiseClone();
				vector.elementData = (object[])elementData.Clone();
				return vector;
			}
		}

		/// <summary>Searches this vector for the specified object.</summary>
		/// <remarks>Searches this vector for the specified object.</remarks>
		/// <param name="object">the object to look for in this vector.</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if object is an element of this vector,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		/// <seealso cref="Vector{E}.indexOf(object)">Vector&lt;E&gt;.indexOf(object)</seealso>
		/// <seealso cref="Vector{E}.indexOf(object, int)">Vector&lt;E&gt;.indexOf(object, int)
		/// 	</seealso>
		/// <seealso cref="object.Equals(object)">object.Equals(object)</seealso>
		[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
		public override bool contains(object @object)
		{
			return indexOf(@object, 0) != -1;
		}

		/// <summary>Searches this vector for all objects in the specified collection.</summary>
		/// <remarks>Searches this vector for all objects in the specified collection.</remarks>
		/// <param name="collection">the collection of objects.</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if all objects in the specified collection are
		/// elements of this vector,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
		public override bool containsAll<_T0>(java.util.Collection<_T0> collection)
		{
			lock (this)
			{
				return base.containsAll(collection);
			}
		}

		/// <summary>
		/// Attempts to copy elements contained by this
		/// <code>Vector</code>
		/// into the
		/// corresponding elements of the supplied
		/// <code>Object</code>
		/// array.
		/// </summary>
		/// <param name="elements">
		/// the
		/// <code>Object</code>
		/// array into which the elements of this
		/// vector are copied.
		/// </param>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>elements</code>
		/// is not big enough.
		/// </exception>
		/// <seealso cref="Vector{E}.clone()">Vector&lt;E&gt;.clone()</seealso>
		public virtual void copyInto(object[] elements_1)
		{
			lock (this)
			{
				System.Array.Copy(elementData, 0, elements_1, 0, elementCount);
			}
		}

		/// <summary>Returns the element at the specified location in this vector.</summary>
		/// <remarks>Returns the element at the specified location in this vector.</remarks>
		/// <param name="location">the index of the element to return in this vector.</param>
		/// <returns>the element at the specified location.</returns>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>location &lt; 0 || location &gt;= size()</code>
		/// .
		/// </exception>
		/// <seealso cref="Vector{E}.size()">Vector&lt;E&gt;.size()</seealso>
		public virtual E elementAt(int location)
		{
			lock (this)
			{
				if (location < elementCount)
				{
					return (E)elementData[location];
				}
				throw arrayIndexOutOfBoundsException(location, elementCount);
			}
		}

		private sealed class _Enumeration_340 : java.util.Enumeration<E>
		{
			public _Enumeration_340(Vector<E> _enclosing)
			{
				this.pos = 0;
				this._enclosing = _enclosing;
			}

			internal int pos;

			[Sharpen.ImplementsInterface(@"java.util.Enumeration")]
			public bool hasMoreElements()
			{
				return this.pos < this._enclosing.elementCount;
			}

			[Sharpen.ImplementsInterface(@"java.util.Enumeration")]
			public E nextElement()
			{
				lock (this._enclosing)
				{
					if (this.pos < this._enclosing.elementCount)
					{
						return (E)this._enclosing.elementData[this.pos++];
					}
				}
				throw new java.util.NoSuchElementException();
			}

			private readonly Vector<E> _enclosing;
		}

		/// <summary>Returns an enumeration on the elements of this vector.</summary>
		/// <remarks>
		/// Returns an enumeration on the elements of this vector. The results of the
		/// enumeration may be affected if the contents of this vector is modified.
		/// </remarks>
		/// <returns>an enumeration of the elements of this vector.</returns>
		/// <seealso cref="Vector{E}.elementAt(int)">Vector&lt;E&gt;.elementAt(int)</seealso>
		/// <seealso cref="Enumeration{E}">Enumeration&lt;E&gt;</seealso>
		public virtual java.util.Enumeration<E> elements()
		{
			return new _Enumeration_340(this);
		}

		/// <summary>
		/// Ensures that this vector can hold the specified number of elements
		/// without growing.
		/// </summary>
		/// <remarks>
		/// Ensures that this vector can hold the specified number of elements
		/// without growing.
		/// </remarks>
		/// <param name="minimumCapacity">
		/// the minimum number of elements that this vector will hold
		/// before growing.
		/// </param>
		/// <seealso cref="Vector{E}.capacity()">Vector&lt;E&gt;.capacity()</seealso>
		public virtual void ensureCapacity(int minimumCapacity)
		{
			lock (this)
			{
				if (elementData.Length < minimumCapacity)
				{
					int next = (capacityIncrement <= 0 ? elementData.Length : capacityIncrement) + elementData
						.Length;
					grow(minimumCapacity > next ? minimumCapacity : next);
				}
			}
		}

		/// <summary>
		/// Compares the specified object to this vector and returns if they are
		/// equal.
		/// </summary>
		/// <remarks>
		/// Compares the specified object to this vector and returns if they are
		/// equal. The object must be a List which contains the same objects in the
		/// same order.
		/// </remarks>
		/// <param name="object">the object to compare with this object</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if the specified object is equal to this vector,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		/// <seealso cref="Vector{E}.GetHashCode()">Vector&lt;E&gt;.GetHashCode()</seealso>
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override bool Equals(object @object)
		{
			lock (this)
			{
				if (this == @object)
				{
					return true;
				}
				if (@object is java.util.List<E>)
				{
					java.util.List<E> list = (java.util.List<E>)@object;
					if (list.size() != elementCount)
					{
						return false;
					}
					int index = 0;
					java.util.Iterator<E> it = list.iterator();
					while (it.hasNext())
					{
						object e1 = elementData[index++];
						object e2 = it.next();
						if (!(e1 == null ? e2 == null : e1.Equals(e2)))
						{
							return false;
						}
					}
					return true;
				}
				return false;
			}
		}

		/// <summary>Returns the first element in this vector.</summary>
		/// <remarks>Returns the first element in this vector.</remarks>
		/// <returns>the element at the first position.</returns>
		/// <exception cref="NoSuchElementException">if this vector is empty.</exception>
		/// <seealso cref="Vector{E}.elementAt(int)">Vector&lt;E&gt;.elementAt(int)</seealso>
		/// <seealso cref="Vector{E}.lastElement()">Vector&lt;E&gt;.lastElement()</seealso>
		/// <seealso cref="Vector{E}.size()">Vector&lt;E&gt;.size()</seealso>
		public virtual E firstElement()
		{
			lock (this)
			{
				if (elementCount > 0)
				{
					return (E)elementData[0];
				}
				throw new java.util.NoSuchElementException();
			}
		}

		/// <summary>Returns the element at the specified location in this vector.</summary>
		/// <remarks>Returns the element at the specified location in this vector.</remarks>
		/// <param name="location">the index of the element to return in this vector.</param>
		/// <returns>the element at the specified location.</returns>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>location &lt; 0 || location &gt;= size()</code>
		/// .
		/// </exception>
		/// <seealso cref="Vector{E}.size()">Vector&lt;E&gt;.size()</seealso>
		[Sharpen.OverridesMethod(@"java.util.AbstractList")]
		public override E get(int location)
		{
			return elementAt(location);
		}

		private void grow(int newCapacity)
		{
			object[] newData = newElementArray(newCapacity);
			// Assumes elementCount is <= newCapacity
			System.Array.Copy(elementData, 0, newData, 0, elementCount);
			elementData = newData;
		}

		/// <summary>JIT optimization</summary>
		private void growByOne()
		{
			int adding = 0;
			if (capacityIncrement <= 0)
			{
				if ((adding = elementData.Length) == 0)
				{
					adding = 1;
				}
			}
			else
			{
				adding = capacityIncrement;
			}
			object[] newData = newElementArray(elementData.Length + adding);
			System.Array.Copy(elementData, 0, newData, 0, elementCount);
			elementData = newData;
		}

		private void growBy(int required)
		{
			int adding = 0;
			if (capacityIncrement <= 0)
			{
				if ((adding = elementData.Length) == 0)
				{
					adding = required;
				}
				while (adding < required)
				{
					adding += adding;
				}
			}
			else
			{
				adding = (required / capacityIncrement) * capacityIncrement;
				if (adding < required)
				{
					adding += capacityIncrement;
				}
			}
			object[] newData = newElementArray(elementData.Length + adding);
			System.Array.Copy(elementData, 0, newData, 0, elementCount);
			elementData = newData;
		}

		/// <summary>Returns an integer hash code for the receiver.</summary>
		/// <remarks>
		/// Returns an integer hash code for the receiver. Objects which are equal
		/// return the same value for this method.
		/// </remarks>
		/// <returns>the receiver's hash.</returns>
		/// <seealso cref="Vector{E}.Equals(object)">Vector&lt;E&gt;.Equals(object)</seealso>
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override int GetHashCode()
		{
			lock (this)
			{
				int result = 1;
				{
					for (int i = 0; i < elementCount; i++)
					{
						result = (31 * result) + (elementData[i] == null ? 0 : elementData[i].GetHashCode
							());
					}
				}
				return result;
			}
		}

		/// <summary>Searches in this vector for the index of the specified object.</summary>
		/// <remarks>
		/// Searches in this vector for the index of the specified object. The search
		/// for the object starts at the beginning and moves towards the end of this
		/// vector.
		/// </remarks>
		/// <param name="object">the object to find in this vector.</param>
		/// <returns>
		/// the index in this vector of the specified element, -1 if the
		/// element isn't found.
		/// </returns>
		/// <seealso cref="Vector{E}.contains(object)">Vector&lt;E&gt;.contains(object)</seealso>
		/// <seealso cref="Vector{E}.lastIndexOf(object)">Vector&lt;E&gt;.lastIndexOf(object)
		/// 	</seealso>
		/// <seealso cref="Vector{E}.lastIndexOf(object, int)">Vector&lt;E&gt;.lastIndexOf(object, int)
		/// 	</seealso>
		[Sharpen.OverridesMethod(@"java.util.AbstractList")]
		public override int indexOf(object @object)
		{
			return indexOf(@object, 0);
		}

		/// <summary>Searches in this vector for the index of the specified object.</summary>
		/// <remarks>
		/// Searches in this vector for the index of the specified object. The search
		/// for the object starts at the specified location and moves towards the end
		/// of this vector.
		/// </remarks>
		/// <param name="object">the object to find in this vector.</param>
		/// <param name="location">the index at which to start searching.</param>
		/// <returns>
		/// the index in this vector of the specified element, -1 if the
		/// element isn't found.
		/// </returns>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>location &lt; 0</code>
		/// .
		/// </exception>
		/// <seealso cref="Vector{E}.contains(object)">Vector&lt;E&gt;.contains(object)</seealso>
		/// <seealso cref="Vector{E}.lastIndexOf(object)">Vector&lt;E&gt;.lastIndexOf(object)
		/// 	</seealso>
		/// <seealso cref="Vector{E}.lastIndexOf(object, int)">Vector&lt;E&gt;.lastIndexOf(object, int)
		/// 	</seealso>
		public virtual int indexOf(object @object, int location)
		{
			lock (this)
			{
				if (@object != null)
				{
					{
						for (int i = location; i < elementCount; i++)
						{
							if (@object.Equals(elementData[i]))
							{
								return i;
							}
						}
					}
				}
				else
				{
					{
						for (int i = location; i < elementCount; i++)
						{
							if (elementData[i] == null)
							{
								return i;
							}
						}
					}
				}
				return -1;
			}
		}

		/// <summary>Inserts the specified object into this vector at the specified location.
		/// 	</summary>
		/// <remarks>
		/// Inserts the specified object into this vector at the specified location.
		/// This object is inserted before any previous element at the specified
		/// location. All elements with an index equal or greater than
		/// <code>location</code>
		/// have their index increased by 1. If the location is
		/// equal to the size of this vector, the object is added at the end.
		/// </remarks>
		/// <param name="object">the object to insert in this vector.</param>
		/// <param name="location">the index at which to insert the element.</param>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>location &lt; 0 || location &gt; size()</code>
		/// .
		/// </exception>
		/// <seealso cref="Vector{E}.addElement(object)">Vector&lt;E&gt;.addElement(object)</seealso>
		/// <seealso cref="Vector{E}.size()">Vector&lt;E&gt;.size()</seealso>
		public virtual void insertElementAt(E @object, int location)
		{
			lock (this)
			{
				if (location >= 0 && location <= elementCount)
				{
					if (elementCount == elementData.Length)
					{
						growByOne();
					}
					int count = elementCount - location;
					if (count > 0)
					{
						System.Array.Copy(elementData, location, elementData, location + 1, count);
					}
					elementData[location] = @object;
					elementCount++;
					modCount++;
				}
				else
				{
					throw arrayIndexOutOfBoundsException(location, elementCount);
				}
			}
		}

		/// <summary>Returns if this vector has no elements, a size of zero.</summary>
		/// <remarks>Returns if this vector has no elements, a size of zero.</remarks>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if this vector has no elements,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		/// <seealso cref="Vector{E}.size()">Vector&lt;E&gt;.size()</seealso>
		[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
		public override bool isEmpty()
		{
			lock (this)
			{
				return elementCount == 0;
			}
		}

		/// <summary>Returns the last element in this vector.</summary>
		/// <remarks>Returns the last element in this vector.</remarks>
		/// <returns>the element at the last position.</returns>
		/// <exception cref="NoSuchElementException">if this vector is empty.</exception>
		/// <seealso cref="Vector{E}.elementAt(int)">Vector&lt;E&gt;.elementAt(int)</seealso>
		/// <seealso cref="Vector{E}.firstElement()">Vector&lt;E&gt;.firstElement()</seealso>
		/// <seealso cref="Vector{E}.size()">Vector&lt;E&gt;.size()</seealso>
		public virtual E lastElement()
		{
			lock (this)
			{
				try
				{
					return (E)elementData[elementCount - 1];
				}
				catch (System.IndexOutOfRangeException)
				{
					throw new java.util.NoSuchElementException();
				}
			}
		}

		/// <summary>Searches in this vector for the index of the specified object.</summary>
		/// <remarks>
		/// Searches in this vector for the index of the specified object. The search
		/// for the object starts at the end and moves towards the start of this
		/// vector.
		/// </remarks>
		/// <param name="object">the object to find in this vector.</param>
		/// <returns>
		/// the index in this vector of the specified element, -1 if the
		/// element isn't found.
		/// </returns>
		/// <seealso cref="Vector{E}.contains(object)">Vector&lt;E&gt;.contains(object)</seealso>
		/// <seealso cref="Vector{E}.indexOf(object)">Vector&lt;E&gt;.indexOf(object)</seealso>
		/// <seealso cref="Vector{E}.indexOf(object, int)">Vector&lt;E&gt;.indexOf(object, int)
		/// 	</seealso>
		[Sharpen.OverridesMethod(@"java.util.AbstractList")]
		public override int lastIndexOf(object @object)
		{
			lock (this)
			{
				return lastIndexOf(@object, elementCount - 1);
			}
		}

		/// <summary>Searches in this vector for the index of the specified object.</summary>
		/// <remarks>
		/// Searches in this vector for the index of the specified object. The search
		/// for the object starts at the specified location and moves towards the
		/// start of this vector.
		/// </remarks>
		/// <param name="object">the object to find in this vector.</param>
		/// <param name="location">the index at which to start searching.</param>
		/// <returns>
		/// the index in this vector of the specified element, -1 if the
		/// element isn't found.
		/// </returns>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>location &gt;= size()</code>
		/// .
		/// </exception>
		/// <seealso cref="Vector{E}.contains(object)">Vector&lt;E&gt;.contains(object)</seealso>
		/// <seealso cref="Vector{E}.indexOf(object)">Vector&lt;E&gt;.indexOf(object)</seealso>
		/// <seealso cref="Vector{E}.indexOf(object, int)">Vector&lt;E&gt;.indexOf(object, int)
		/// 	</seealso>
		public virtual int lastIndexOf(object @object, int location)
		{
			lock (this)
			{
				if (location < elementCount)
				{
					if (@object != null)
					{
						{
							for (int i = location; i >= 0; i--)
							{
								if (@object.Equals(elementData[i]))
								{
									return i;
								}
							}
						}
					}
					else
					{
						{
							for (int i = location; i >= 0; i--)
							{
								if (elementData[i] == null)
								{
									return i;
								}
							}
						}
					}
					return -1;
				}
				throw arrayIndexOutOfBoundsException(location, elementCount);
			}
		}

		/// <summary>Removes the object at the specified location from this vector.</summary>
		/// <remarks>
		/// Removes the object at the specified location from this vector. All
		/// elements with an index bigger than
		/// <code>location</code>
		/// have their index
		/// decreased by 1.
		/// </remarks>
		/// <param name="location">the index of the object to remove.</param>
		/// <returns>the removed object.</returns>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>location &lt; 0 || location &gt;= size()</code>
		/// .
		/// </exception>
		[Sharpen.OverridesMethod(@"java.util.AbstractList")]
		public override E remove(int location)
		{
			lock (this)
			{
				if (location < elementCount)
				{
					E result = (E)elementData[location];
					elementCount--;
					int size_1 = elementCount - location;
					if (size_1 > 0)
					{
						System.Array.Copy(elementData, location + 1, elementData, location, size_1);
					}
					elementData[elementCount] = null;
					modCount++;
					return result;
				}
				throw arrayIndexOutOfBoundsException(location, elementCount);
			}
		}

		/// <summary>
		/// Removes the first occurrence, starting at the beginning and moving
		/// towards the end, of the specified object from this vector.
		/// </summary>
		/// <remarks>
		/// Removes the first occurrence, starting at the beginning and moving
		/// towards the end, of the specified object from this vector. All elements
		/// with an index bigger than the element that gets removed have their index
		/// decreased by 1.
		/// </remarks>
		/// <param name="object">the object to remove from this vector.</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if the specified object was found,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		/// <seealso cref="Vector{E}.removeAllElements()">Vector&lt;E&gt;.removeAllElements()
		/// 	</seealso>
		/// <seealso cref="Vector{E}.removeElementAt(int)">Vector&lt;E&gt;.removeElementAt(int)
		/// 	</seealso>
		/// <seealso cref="Vector{E}.size()">Vector&lt;E&gt;.size()</seealso>
		[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
		public override bool remove(object @object)
		{
			return removeElement(@object);
		}

		/// <summary>
		/// Removes all occurrences in this vector of each object in the specified
		/// Collection.
		/// </summary>
		/// <remarks>
		/// Removes all occurrences in this vector of each object in the specified
		/// Collection.
		/// </remarks>
		/// <param name="collection">the collection of objects to remove.</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if this vector is modified,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		/// <seealso cref="Vector{E}.remove(object)">Vector&lt;E&gt;.remove(object)</seealso>
		/// <seealso cref="Vector{E}.contains(object)">Vector&lt;E&gt;.contains(object)</seealso>
		[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
		public override bool removeAll<_T0>(java.util.Collection<_T0> collection)
		{
			lock (this)
			{
				return base.removeAll(collection);
			}
		}

		/// <summary>
		/// Removes all elements from this vector, leaving the size zero and the
		/// capacity unchanged.
		/// </summary>
		/// <remarks>
		/// Removes all elements from this vector, leaving the size zero and the
		/// capacity unchanged.
		/// </remarks>
		/// <seealso cref="Vector{E}.isEmpty()">Vector&lt;E&gt;.isEmpty()</seealso>
		/// <seealso cref="Vector{E}.size()">Vector&lt;E&gt;.size()</seealso>
		public virtual void removeAllElements()
		{
			lock (this)
			{
				{
					for (int i = 0; i < elementCount; i++)
					{
						elementData[i] = null;
					}
				}
				modCount++;
				elementCount = 0;
			}
		}

		/// <summary>
		/// Removes the first occurrence, starting at the beginning and moving
		/// towards the end, of the specified object from this vector.
		/// </summary>
		/// <remarks>
		/// Removes the first occurrence, starting at the beginning and moving
		/// towards the end, of the specified object from this vector. All elements
		/// with an index bigger than the element that gets removed have their index
		/// decreased by 1.
		/// </remarks>
		/// <param name="object">the object to remove from this vector.</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if the specified object was found,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		/// <seealso cref="Vector{E}.removeAllElements()">Vector&lt;E&gt;.removeAllElements()
		/// 	</seealso>
		/// <seealso cref="Vector{E}.removeElementAt(int)">Vector&lt;E&gt;.removeElementAt(int)
		/// 	</seealso>
		/// <seealso cref="Vector{E}.size()">Vector&lt;E&gt;.size()</seealso>
		public virtual bool removeElement(object @object)
		{
			lock (this)
			{
				int index;
				if ((index = indexOf(@object, 0)) == -1)
				{
					return false;
				}
				removeElementAt(index);
				return true;
			}
		}

		/// <summary>
		/// Removes the element found at index position
		/// <code>location</code>
		/// from
		/// this
		/// <code>Vector</code>
		/// . All elements with an index bigger than
		/// <code>location</code>
		/// have their index decreased by 1.
		/// </summary>
		/// <param name="location">the index of the element to remove.</param>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>location &lt; 0 || location &gt;= size()</code>
		/// .
		/// </exception>
		/// <seealso cref="Vector{E}.removeElement(object)">Vector&lt;E&gt;.removeElement(object)
		/// 	</seealso>
		/// <seealso cref="Vector{E}.removeAllElements()">Vector&lt;E&gt;.removeAllElements()
		/// 	</seealso>
		/// <seealso cref="Vector{E}.size()">Vector&lt;E&gt;.size()</seealso>
		public virtual void removeElementAt(int location)
		{
			lock (this)
			{
				if (location >= 0 && location < elementCount)
				{
					elementCount--;
					int size_1 = elementCount - location;
					if (size_1 > 0)
					{
						System.Array.Copy(elementData, location + 1, elementData, location, size_1);
					}
					elementData[elementCount] = null;
					modCount++;
				}
				else
				{
					throw arrayIndexOutOfBoundsException(location, elementCount);
				}
			}
		}

		/// <summary>
		/// Removes the objects in the specified range from the start to the, but not
		/// including, end index.
		/// </summary>
		/// <remarks>
		/// Removes the objects in the specified range from the start to the, but not
		/// including, end index. All elements with an index bigger than or equal to
		/// <code>end</code>
		/// have their index decreased by
		/// <code>end - start</code>
		/// .
		/// </remarks>
		/// <param name="start">the index at which to start removing.</param>
		/// <param name="end">the index one past the end of the range to remove.</param>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>start &lt; 0, start &gt; end</code>
		/// or
		/// <code>end &gt; size()</code>
		/// .
		/// </exception>
		[Sharpen.OverridesMethod(@"java.util.AbstractList")]
		protected internal override void removeRange(int start, int end)
		{
			if (start >= 0 && start <= end && end <= elementCount)
			{
				if (start == end)
				{
					return;
				}
				if (end != elementCount)
				{
					System.Array.Copy(elementData, end, elementData, start, elementCount - end);
					int newCount = elementCount - (end - start);
					java.util.Arrays.fill(elementData, newCount, elementCount, null);
					elementCount = newCount;
				}
				else
				{
					java.util.Arrays.fill(elementData, start, elementCount, null);
					elementCount = start;
				}
				modCount++;
			}
			else
			{
				throw new System.IndexOutOfRangeException();
			}
		}

		/// <summary>
		/// Removes all objects from this vector that are not contained in the
		/// specified collection.
		/// </summary>
		/// <remarks>
		/// Removes all objects from this vector that are not contained in the
		/// specified collection.
		/// </remarks>
		/// <param name="collection">the collection of objects to retain.</param>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if this vector is modified,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		/// <seealso cref="Vector{E}.remove(object)">Vector&lt;E&gt;.remove(object)</seealso>
		[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
		public override bool retainAll<_T0>(java.util.Collection<_T0> collection)
		{
			lock (this)
			{
				return base.retainAll(collection);
			}
		}

		/// <summary>
		/// Replaces the element at the specified location in this vector with the
		/// specified object.
		/// </summary>
		/// <remarks>
		/// Replaces the element at the specified location in this vector with the
		/// specified object.
		/// </remarks>
		/// <param name="location">the index at which to put the specified object.</param>
		/// <param name="object">the object to add to this vector.</param>
		/// <returns>the previous element at the location.</returns>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>location &lt; 0 || location &gt;= size()</code>
		/// .
		/// </exception>
		/// <seealso cref="Vector{E}.size()">Vector&lt;E&gt;.size()</seealso>
		[Sharpen.OverridesMethod(@"java.util.AbstractList")]
		public override E set(int location, E @object)
		{
			lock (this)
			{
				if (location < elementCount)
				{
					E result = (E)elementData[location];
					elementData[location] = @object;
					return result;
				}
				throw arrayIndexOutOfBoundsException(location, elementCount);
			}
		}

		/// <summary>
		/// Replaces the element at the specified location in this vector with the
		/// specified object.
		/// </summary>
		/// <remarks>
		/// Replaces the element at the specified location in this vector with the
		/// specified object.
		/// </remarks>
		/// <param name="object">the object to add to this vector.</param>
		/// <param name="location">the index at which to put the specified object.</param>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>location &lt; 0 || location &gt;= size()</code>
		/// .
		/// </exception>
		/// <seealso cref="Vector{E}.size()">Vector&lt;E&gt;.size()</seealso>
		public virtual void setElementAt(E @object, int location)
		{
			lock (this)
			{
				if (location < elementCount)
				{
					elementData[location] = @object;
				}
				else
				{
					throw arrayIndexOutOfBoundsException(location, elementCount);
				}
			}
		}

		/// <summary>This method was extracted to encourage VM to inline callers.</summary>
		/// <remarks>
		/// This method was extracted to encourage VM to inline callers.
		/// TODO: when we have a VM that can actually inline, move the test in here too!
		/// </remarks>
		private static System.IndexOutOfRangeException arrayIndexOutOfBoundsException(int
			 index, int size_1)
		{
			throw Sharpen.Util.IndexOutOfRangeCtor(size_1, index);
		}

		/// <summary>Sets the size of this vector to the specified size.</summary>
		/// <remarks>
		/// Sets the size of this vector to the specified size. If there are more
		/// than length elements in this vector, the elements at end are lost. If
		/// there are less than length elements in the vector, the additional
		/// elements contain null.
		/// </remarks>
		/// <param name="length">the new size of this vector.</param>
		/// <seealso cref="Vector{E}.size()">Vector&lt;E&gt;.size()</seealso>
		public virtual void setSize(int length)
		{
			lock (this)
			{
				if (length == elementCount)
				{
					return;
				}
				ensureCapacity(length);
				if (elementCount > length)
				{
					java.util.Arrays.fill(elementData, length, elementCount, null);
				}
				elementCount = length;
				modCount++;
			}
		}

		/// <summary>Returns the number of elements in this vector.</summary>
		/// <remarks>Returns the number of elements in this vector.</remarks>
		/// <returns>the number of elements in this vector.</returns>
		/// <seealso cref="Vector{E}.elementCount">Vector&lt;E&gt;.elementCount</seealso>
		/// <seealso cref="Vector{E}.lastElement()">Vector&lt;E&gt;.lastElement()</seealso>
		[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
		public override int size()
		{
			lock (this)
			{
				return elementCount;
			}
		}

		/// <summary>
		/// Returns a List of the specified portion of this vector from the start
		/// index to one less than the end index.
		/// </summary>
		/// <remarks>
		/// Returns a List of the specified portion of this vector from the start
		/// index to one less than the end index. The returned List is backed by this
		/// vector so changes to one are reflected by the other.
		/// </remarks>
		/// <param name="start">the index at which to start the sublist.</param>
		/// <param name="end">the index one past the end of the sublist.</param>
		/// <returns>a List of a portion of this vector.</returns>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if
		/// <code>start &lt; 0</code>
		/// or
		/// <code>end &gt; size()</code>
		/// .
		/// </exception>
		/// <exception cref="System.ArgumentException">
		/// if
		/// <code>start &gt; end</code>
		/// .
		/// </exception>
		[Sharpen.OverridesMethod(@"java.util.AbstractList")]
		public override java.util.List<E> subList(int start, int end)
		{
			lock (this)
			{
				return new java.util.Collections.SynchronizedRandomAccessList<E>(base.subList(start
					, end), this);
			}
		}

		/// <summary>Returns a new array containing all elements contained in this vector.</summary>
		/// <remarks>Returns a new array containing all elements contained in this vector.</remarks>
		/// <returns>an array of the elements from this vector.</returns>
		[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
		public override object[] toArray()
		{
			lock (this)
			{
				object[] result = new object[elementCount];
				System.Array.Copy(elementData, 0, result, 0, elementCount);
				return result;
			}
		}

		[Sharpen.Proxy]
		T[] java.util.Collection<E>.toArray<T>(T[] contents)
		{
			return toArray<T>(contents);
		}

		[Sharpen.Proxy]
		T[] java.util.List<E>.toArray<T>(T[] contents)
		{
			return toArray<T>(contents);
		}

		/// <summary>Returns an array containing all elements contained in this vector.</summary>
		/// <remarks>
		/// Returns an array containing all elements contained in this vector. If the
		/// specified array is large enough to hold the elements, the specified array
		/// is used, otherwise an array of the same type is created. If the specified
		/// array is used and is larger than this vector, the array element following
		/// the collection elements is set to null.
		/// </remarks>
		/// <param name="contents">the array to fill.</param>
		/// <returns>an array of the elements from this vector.</returns>
		/// <exception cref="java.lang.ArrayStoreException">
		/// if the type of an element in this vector cannot be
		/// stored in the type of the specified array.
		/// </exception>
		[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
		public override T[] toArray<T>(T[] contents)
		{
			lock (this)
			{
				if (elementCount > contents.Length)
				{
					System.Type ct = contents.GetType().GetElementType();
					contents = (T[])System.Array.CreateInstance(ct, elementCount);
				}
				System.Array.Copy(elementData, 0, contents, 0, elementCount);
				if (elementCount < contents.Length)
				{
					contents[elementCount] = default(T);
				}
				return contents;
			}
		}

		/// <summary>Returns the string representation of this vector.</summary>
		/// <remarks>Returns the string representation of this vector.</remarks>
		/// <returns>the string representation of this vector.</returns>
		/// <seealso cref="Vector{E}.elements()">Vector&lt;E&gt;.elements()</seealso>
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			lock (this)
			{
				if (elementCount == 0)
				{
					return "[]";
				}
				int length = elementCount - 1;
				java.lang.StringBuilder buffer = new java.lang.StringBuilder(elementCount * 16);
				buffer.append('[');
				{
					for (int i = 0; i < length; i++)
					{
						if (elementData[i] == this)
						{
							buffer.append("(this Collection)");
						}
						else
						{
							buffer.append(elementData[i]);
						}
						buffer.append(", ");
					}
				}
				if (elementData[length] == this)
				{
					buffer.append("(this Collection)");
				}
				else
				{
					buffer.append(elementData[length]);
				}
				buffer.append(']');
				return buffer.ToString();
			}
		}

		/// <summary>Sets the capacity of this vector to be the same as the size.</summary>
		/// <remarks>Sets the capacity of this vector to be the same as the size.</remarks>
		/// <seealso cref="Vector{E}.capacity()">Vector&lt;E&gt;.capacity()</seealso>
		/// <seealso cref="Vector{E}.ensureCapacity(int)">Vector&lt;E&gt;.ensureCapacity(int)
		/// 	</seealso>
		/// <seealso cref="Vector{E}.size()">Vector&lt;E&gt;.size()</seealso>
		public virtual void trimToSize()
		{
			lock (this)
			{
				if (elementData.Length != elementCount)
				{
					grow(elementCount);
				}
			}
		}

		/// <exception cref="System.IO.IOException"></exception>
		private void writeObject(java.io.ObjectOutputStream stream)
		{
			lock (this)
			{
				stream.defaultWriteObject();
			}
		}

		object System.ICloneable.Clone()
		{
			return MemberwiseClone();
		}
	}
}

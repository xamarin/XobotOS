using System;

namespace java.util.concurrent
{
	partial class CopyOnWriteArrayList<E>
	{
		/// <summary>
		/// Creates a new instance containing the elements of
		/// <code>collection</code>
		/// .
		/// </summary>
		internal CopyOnWriteArrayList (Collection<E> collection)
			: this(collection.toArray(new E[collection.size ()]))
		{
		}

		/// <summary>
		/// Creates a new instance containing the elements of
		/// <code>array</code>
		/// .
		/// </summary>
		public CopyOnWriteArrayList (E[] array)
		{
			this.elements = Arrays.copyOf<object,E> (array, array.Length);
		}

		[Sharpen.ImplementsInterface(@"java.util.Collection")]
		public virtual T[] toArray<T> (T[] contents)
		{
			object[] snapshot = elements;
			if (snapshot.Length > contents.Length) {
				return Arrays.copyOf<T,object> (snapshot, snapshot.Length);
			}
			System.Array.Copy (snapshot, 0, contents, 0, snapshot.Length);
			if (snapshot.Length < contents.Length) {
				contents [snapshot.Length] = default(T);
			}
			return contents;
		}

	}
}


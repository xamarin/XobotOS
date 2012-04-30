using System;
using System.Collections;
using System.Collections.Generic;
using java.lang;
using java.util;

namespace java.lang
{
	public interface Iterable : Iterable<object>
	{
	}
}

namespace Sharpen
{
	public class IterableProxy : IEnumerable, IEnumerator
	{
		private readonly Iterable iterable;

		public IterableProxy (Iterable iterable)
		{
			this.iterable = iterable;
		}

		#region IEnumerable implementation
		public IEnumerator GetEnumerator ()
		{
			return this;
		}
		#endregion

		#region IEnumerator implementation
		public bool MoveNext ()
		{
			throw new NotImplementedException ();
		}

		public void Reset ()
		{
			throw new NotImplementedException ();
		}

		public object Current {
			get {
				throw new NotImplementedException ();
			}
		}
		#endregion

		public static IterableProxy Create (Iterable iterable)
		{
			return new IterableProxy (iterable);
		}

		public static IterableProxy<T> Create<T> (Iterable<T> iterable)
		{
			return new IterableProxy<T> (iterable);
		}
	}

	public class IteratorProxy<T> : IEnumerator<T>
	{
		new private readonly Iterator<T> iterator;
		private T current;

		public IteratorProxy (Iterator<T> iterator)
		{
			this.iterator = iterator;
		}

		#region IEnumerator[T] implementation
		public T Current {
			get {
				return current;
			}
		}
		#endregion

		#region IEnumerator implementation
		public bool MoveNext ()
		{
			if (!iterator.hasNext ())
				return false;

			current = iterator.next ();
			return true;
		}

		public void Reset ()
		{
			throw new System.NotSupportedException ();
		}

		object IEnumerator.Current {
			get {
				return current;
			}
		}
		#endregion

		#region IDisposable implementation
		public void Dispose ()
		{
			;
		}
		#endregion
	}

	public class IterableProxy<T> : IEnumerable<T>
	{
		new private readonly Iterable<T> iterable;

		public IterableProxy (Iterable<T> iterable)
		{
			this.iterable = iterable;
		}

		#region IEnumerable[T] implementation
		public IEnumerator<T> GetEnumerator ()
		{
			return new IteratorProxy<T> (iterable.iterator ());
		}
		#endregion

		#region IEnumerable implementation
		IEnumerator IEnumerable.GetEnumerator ()
		{
			return new IteratorProxy<T> (iterable.iterator ());
		}
		#endregion
	}

	public static class IteratorExtensions
	{
		private class EnumeratorProxy<T> : Iterator<T>
		{
			IEnumerator<T> enumerator;

			internal EnumeratorProxy (IEnumerator<T> enumerator)
			{
				this.enumerator = enumerator;
			}

			#region Iterator[T] implementation
			public bool hasNext ()
			{
				return enumerator.MoveNext ();
			}

			public T next ()
			{
				return enumerator.Current;
			}

			public void remove ()
			{
				throw new System.NotSupportedException ();
			}
			#endregion
		}

		public static Iterator<T> iterator<T> (this ICollection<T> collection)
		{
			return new EnumeratorProxy<T> (collection.GetEnumerator ());
		}
	}
}

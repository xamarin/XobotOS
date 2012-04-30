using Sharpen;

namespace java.util
{
	/// <summary>AbstractSequentialList is an abstract implementation of the List interface.
	/// 	</summary>
	/// <remarks>
	/// AbstractSequentialList is an abstract implementation of the List interface.
	/// This implementation does not support adding. A subclass must implement the
	/// abstract method listIterator().
	/// </remarks>
	/// <since>1.2</since>
	[Sharpen.Sharpened]
	public abstract class AbstractSequentialList<E> : java.util.AbstractList<E>
	{
		/// <summary>Constructs a new instance of this AbstractSequentialList.</summary>
		/// <remarks>Constructs a new instance of this AbstractSequentialList.</remarks>
		protected internal AbstractSequentialList()
		{
		}

		[Sharpen.OverridesMethod(@"java.util.AbstractList")]
		public override void add(int location, E @object)
		{
			listIterator(location).add(@object);
		}

		[Sharpen.OverridesMethod(@"java.util.AbstractList")]
		public override bool addAll<_T0>(int location, java.util.Collection<_T0> collection
			)
		{
			java.util.ListIterator<E> it = listIterator(location);
			java.util.Iterator<_T0> colIt = collection.iterator();
			int next = it.nextIndex();
			while (colIt.hasNext())
			{
				it.add(colIt.next());
			}
			return next != it.nextIndex();
		}

		[Sharpen.OverridesMethod(@"java.util.AbstractList")]
		public override E get(int location)
		{
			try
			{
				return listIterator(location).next();
			}
			catch (java.util.NoSuchElementException)
			{
				throw new System.IndexOutOfRangeException();
			}
		}

		[Sharpen.OverridesMethod(@"java.util.AbstractCollection")]
		public override java.util.Iterator<E> iterator()
		{
			return listIterator(0);
		}

		[Sharpen.OverridesMethod(@"java.util.AbstractList")]
		public abstract override java.util.ListIterator<E> listIterator(int location);

		[Sharpen.OverridesMethod(@"java.util.AbstractList")]
		public override E remove(int location)
		{
			try
			{
				java.util.ListIterator<E> it = listIterator(location);
				E result = it.next();
				it.remove();
				return result;
			}
			catch (java.util.NoSuchElementException)
			{
				throw new System.IndexOutOfRangeException();
			}
		}

		[Sharpen.OverridesMethod(@"java.util.AbstractList")]
		public override E set(int location, E @object)
		{
			java.util.ListIterator<E> it = listIterator(location);
			if (!it.hasNext())
			{
				throw new System.IndexOutOfRangeException();
			}
			E result = it.next();
			it.set(@object);
			return result;
		}
	}
}

namespace java.util.concurrent
{
	public class _CopyOnWriteArrayList<E> : System.Collections.Generic.List<E>
	{
		public void add(E item)
		{
			Add (item);
		}

		public void remove (E item)
		{
			Remove (item);
		}

		public void addAll (System.Collections.Generic.ICollection<E> collection)
		{
			AddRange (collection);
		}

		public int size ()
		{
			return Count;
		}

		public object clone()
		{
			throw new System.NotImplementedException();
		}
	}
}


using Sharpen;

namespace java.lang.@ref
{
	public class ReferenceQueue<T>
	{
		public virtual java.lang.@ref.Reference<T> poll()
		{
			throw new System.NotImplementedException ();
		}

		public virtual java.lang.@ref.Reference<T> remove()
		{
			return remove(0L);
		}

		public virtual java.lang.@ref.Reference<T> remove(long timeout)
		{
			throw new System.NotImplementedException ();
		}
	}
}

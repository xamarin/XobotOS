using Sharpen;

namespace android.database
{
	/// <summary>Provides methods for (un)registering arbitrary observers in an ArrayList.
	/// 	</summary>
	/// <remarks>Provides methods for (un)registering arbitrary observers in an ArrayList.
	/// 	</remarks>
	[Sharpen.Sharpened]
	public abstract class Observable<T>
	{
		/// <summary>The list of observers.</summary>
		/// <remarks>
		/// The list of observers.  An observer can be in the list at most
		/// once and will never be null.
		/// </remarks>
		protected internal readonly java.util.ArrayList<T> mObservers = new java.util.ArrayList
			<T>();

		/// <summary>Adds an observer to the list.</summary>
		/// <remarks>
		/// Adds an observer to the list. The observer cannot be null and it must not already
		/// be registered.
		/// </remarks>
		/// <param name="observer">the observer to register</param>
		/// <exception cref="System.ArgumentException">the observer is null</exception>
		/// <exception cref="System.InvalidOperationException">the observer is already registered
		/// 	</exception>
		public virtual void registerObserver(T observer)
		{
			if ((object)observer == null)
			{
				throw new System.ArgumentException("The observer is null.");
			}
			lock (mObservers)
			{
				if (mObservers.contains(observer))
				{
					throw new System.InvalidOperationException("Observer " + observer + " is already registered."
						);
				}
				mObservers.add(observer);
			}
		}

		/// <summary>Removes a previously registered observer.</summary>
		/// <remarks>
		/// Removes a previously registered observer. The observer must not be null and it
		/// must already have been registered.
		/// </remarks>
		/// <param name="observer">the observer to unregister</param>
		/// <exception cref="System.ArgumentException">the observer is null</exception>
		/// <exception cref="System.InvalidOperationException">the observer is not yet registered
		/// 	</exception>
		public virtual void unregisterObserver(T observer)
		{
			if ((object)observer == null)
			{
				throw new System.ArgumentException("The observer is null.");
			}
			lock (mObservers)
			{
				int index = mObservers.indexOf(observer);
				if (index == -1)
				{
					throw new System.InvalidOperationException("Observer " + observer + " was not registered."
						);
				}
				mObservers.remove(index);
			}
		}

		/// <summary>Remove all registered observer</summary>
		public virtual void unregisterAll()
		{
			lock (mObservers)
			{
				mObservers.clear();
			}
		}
	}
}

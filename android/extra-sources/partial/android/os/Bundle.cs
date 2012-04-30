using System;
using android.util;

namespace android.os
{
	partial class Bundle
	{
		public Parcelable getParcelable (string key)
		{
			return getParcelable<Parcelable> (key);
		}

		[Sharpen.Stub]
		internal void putSparseParcelableArray<T> (string key, SparseArray<T> value)
			where T:class, Parcelable
		{
			throw new NotImplementedException ();
		}

		[Sharpen.Stub]
		public SparseArray<T> getSparseParcelableArray<T> (string key)
			where T:class,Parcelable
		{
			throw new NotImplementedException ();
		}

		/// <summary>
		/// If the underlying data are stored as a Parcel, unparcel them
		/// using the currently assigned class loader.
		/// </summary>
		/// <remarks>
		/// If the underlying data are stored as a Parcel, unparcel them
		/// using the currently assigned class loader.
		/// </remarks>
		internal void unparcel()
		{
			lock (this)
			{
				if (mParcelledData == null)
				{
					return;
				}
				throw new InvalidOperationException ();
			}
		}
	}
}


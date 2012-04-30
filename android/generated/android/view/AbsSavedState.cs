using Sharpen;

namespace android.view
{
	[Sharpen.Stub]
	public abstract class AbsSavedState : android.os.Parcelable
	{
		private sealed class _AbsSavedState_27 : android.view.AbsSavedState
		{
			public _AbsSavedState_27()
			{
			}
		}

		public static readonly android.view.AbsSavedState EMPTY_STATE = new _AbsSavedState_27
			();

		private readonly android.os.Parcelable mSuperState;

		[Sharpen.Stub]
		private AbsSavedState()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal AbsSavedState(android.os.Parcelable superState)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal AbsSavedState(android.os.Parcel source)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.os.Parcelable getSuperState()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual int describeContents()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual void writeToParcel(android.os.Parcel dest, int flags)
		{
			throw new System.NotImplementedException();
		}

		private sealed class _Creator_75 : android.os.ParcelableClass.Creator<android.view.AbsSavedState
			>
		{
			public _Creator_75()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.view.AbsSavedState createFromParcel(android.os.Parcel @in)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.view.AbsSavedState[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.view.AbsSavedState
			> CREATOR = new _Creator_75();
	}
}

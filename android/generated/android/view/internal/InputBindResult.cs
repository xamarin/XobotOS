using Sharpen;

namespace android.view.@internal
{
	[Sharpen.Stub]
	public sealed class InputBindResult : android.os.Parcelable
	{
		internal const string TAG = "InputBindResult";

		public readonly android.view.@internal.IInputMethodSession method;

		public readonly string id;

		public readonly int sequence;

		[Sharpen.Stub]
		public InputBindResult(android.view.@internal.IInputMethodSession _method, string
			 _id, int _sequence)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal InputBindResult(android.os.Parcel source)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public void writeToParcel(android.os.Parcel dest, int flags)
		{
			throw new System.NotImplementedException();
		}

		private sealed class _Creator_78 : android.os.ParcelableClass.Creator<android.view.@internal.InputBindResult
			>
		{
			public _Creator_78()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.view.@internal.InputBindResult createFromParcel(android.os.Parcel 
				source)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.view.@internal.InputBindResult[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.view.@internal.InputBindResult
			> CREATOR = new _Creator_78();

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public int describeContents()
		{
			throw new System.NotImplementedException();
		}
	}
}

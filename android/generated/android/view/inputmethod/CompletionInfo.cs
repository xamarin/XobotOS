using Sharpen;

namespace android.view.inputmethod
{
	[Sharpen.Stub]
	public sealed class CompletionInfo : android.os.Parcelable
	{
		private readonly long mId;

		private readonly int mPosition;

		private readonly java.lang.CharSequence mText;

		private readonly java.lang.CharSequence mLabel;

		[Sharpen.Stub]
		public CompletionInfo(long id, int index, java.lang.CharSequence text)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public CompletionInfo(long id, int index, java.lang.CharSequence text, java.lang.CharSequence
			 label)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private CompletionInfo(android.os.Parcel source)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public long getId()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int getPosition()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public java.lang.CharSequence getText()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public java.lang.CharSequence getLabel()
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

		private sealed class _Creator_116 : android.os.ParcelableClass.Creator<android.view.inputmethod.CompletionInfo
			>
		{
			public _Creator_116()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.view.inputmethod.CompletionInfo createFromParcel(android.os.Parcel
				 source)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.view.inputmethod.CompletionInfo[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.view.inputmethod.CompletionInfo
			> CREATOR = new _Creator_116();

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public int describeContents()
		{
			throw new System.NotImplementedException();
		}
	}
}

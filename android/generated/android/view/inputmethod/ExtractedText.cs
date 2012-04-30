using Sharpen;

namespace android.view.inputmethod
{
	[Sharpen.Stub]
	public class ExtractedText : android.os.Parcelable
	{
		public java.lang.CharSequence text;

		public int startOffset;

		public int partialStartOffset;

		public int partialEndOffset;

		public int selectionStart;

		public int selectionEnd;

		public const int FLAG_SINGLE_LINE = unchecked((int)(0x0001));

		public const int FLAG_SELECTING = unchecked((int)(0x0002));

		public int flags;

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual void writeToParcel(android.os.Parcel dest, int flags)
		{
			throw new System.NotImplementedException();
		}

		private sealed class _Creator_102 : android.os.ParcelableClass.Creator<android.view.inputmethod.ExtractedText
			>
		{
			public _Creator_102()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.view.inputmethod.ExtractedText createFromParcel(android.os.Parcel 
				source)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.view.inputmethod.ExtractedText[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.view.inputmethod.ExtractedText
			> CREATOR = new _Creator_102();

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual int describeContents()
		{
			throw new System.NotImplementedException();
		}
	}
}

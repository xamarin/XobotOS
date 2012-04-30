using Sharpen;

namespace android.view.inputmethod
{
	[Sharpen.Stub]
	public class ExtractedTextRequest : android.os.Parcelable
	{
		public int token;

		public int flags;

		public int hintMaxLines;

		public int hintMaxChars;

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual void writeToParcel(android.os.Parcel dest, int flags)
		{
			throw new System.NotImplementedException();
		}

		private sealed class _Creator_68 : android.os.ParcelableClass.Creator<android.view.inputmethod.ExtractedTextRequest
			>
		{
			public _Creator_68()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.view.inputmethod.ExtractedTextRequest createFromParcel(android.os.Parcel
				 source)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.view.inputmethod.ExtractedTextRequest[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.view.inputmethod.ExtractedTextRequest
			> CREATOR = new _Creator_68();

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual int describeContents()
		{
			throw new System.NotImplementedException();
		}
	}
}

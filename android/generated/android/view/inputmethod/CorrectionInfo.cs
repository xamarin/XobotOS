using Sharpen;

namespace android.view.inputmethod
{
	[Sharpen.Stub]
	public sealed class CorrectionInfo : android.os.Parcelable
	{
		private readonly int mOffset;

		private readonly java.lang.CharSequence mOldText;

		private readonly java.lang.CharSequence mNewText;

		[Sharpen.Stub]
		public CorrectionInfo(int offset, java.lang.CharSequence oldText, java.lang.CharSequence
			 newText)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private CorrectionInfo(android.os.Parcel source)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int getOffset()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public java.lang.CharSequence getOldText()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public java.lang.CharSequence getNewText()
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

		private sealed class _Creator_92 : android.os.ParcelableClass.Creator<android.view.inputmethod.CorrectionInfo
			>
		{
			public _Creator_92()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.view.inputmethod.CorrectionInfo createFromParcel(android.os.Parcel
				 source)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.view.inputmethod.CorrectionInfo[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.view.inputmethod.CorrectionInfo
			> CREATOR = new _Creator_92();

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public int describeContents()
		{
			throw new System.NotImplementedException();
		}
	}
}

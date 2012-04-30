using Sharpen;

namespace android.view.inputmethod
{
	[Sharpen.Stub]
	public class EditorInfo : android.text.InputType, android.os.Parcelable
	{
		public int inputType = android.text.InputTypeClass.TYPE_NULL;

		public const int IME_MASK_ACTION = unchecked((int)(0x000000ff));

		public const int IME_ACTION_UNSPECIFIED = unchecked((int)(0x00000000));

		public const int IME_ACTION_NONE = unchecked((int)(0x00000001));

		public const int IME_ACTION_GO = unchecked((int)(0x00000002));

		public const int IME_ACTION_SEARCH = unchecked((int)(0x00000003));

		public const int IME_ACTION_SEND = unchecked((int)(0x00000004));

		public const int IME_ACTION_NEXT = unchecked((int)(0x00000005));

		public const int IME_ACTION_DONE = unchecked((int)(0x00000006));

		public const int IME_ACTION_PREVIOUS = unchecked((int)(0x00000007));

		public const int IME_FLAG_NO_FULLSCREEN = unchecked((int)(0x2000000));

		public const int IME_FLAG_NAVIGATE_PREVIOUS = unchecked((int)(0x4000000));

		public const int IME_FLAG_NAVIGATE_NEXT = unchecked((int)(0x8000000));

		public const int IME_FLAG_NO_EXTRACT_UI = unchecked((int)(0x10000000));

		public const int IME_FLAG_NO_ACCESSORY_ACTION = unchecked((int)(0x20000000));

		public const int IME_FLAG_NO_ENTER_ACTION = unchecked((int)(0x40000000));

		public const int IME_NULL = unchecked((int)(0x00000000));

		public int imeOptions = IME_NULL;

		public string privateImeOptions = null;

		public java.lang.CharSequence actionLabel = null;

		public int actionId = 0;

		public int initialSelStart = -1;

		public int initialSelEnd = -1;

		public int initialCapsMode = 0;

		public java.lang.CharSequence hintText;

		public java.lang.CharSequence label;

		public string packageName;

		public int fieldId;

		public string fieldName;

		public android.os.Bundle extras;

		[Sharpen.Stub]
		public void makeCompatible(int targetSdkVersion)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void dump(android.util.Printer pw, string prefix)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual void writeToParcel(android.os.Parcel dest, int flags)
		{
			throw new System.NotImplementedException();
		}

		private sealed class _Creator_355 : android.os.ParcelableClass.Creator<android.view.inputmethod.EditorInfo
			>
		{
			public _Creator_355()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.view.inputmethod.EditorInfo createFromParcel(android.os.Parcel source
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.view.inputmethod.EditorInfo[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.view.inputmethod.EditorInfo
			> CREATOR = new _Creator_355();

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual int describeContents()
		{
			throw new System.NotImplementedException();
		}
	}
}

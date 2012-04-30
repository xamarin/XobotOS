using Sharpen;

namespace android.text.style
{
	[Sharpen.Stub]
	public interface AlignmentSpan : android.text.style.ParagraphStyle
	{
		[Sharpen.Stub]
		android.text.Layout.Alignment? getAlignment();
	}

	[Sharpen.Stub]
	public static class AlignmentSpanClass
	{
		[Sharpen.Stub]
		public class Standard : android.text.style.AlignmentSpan, android.text.ParcelableSpan
		{
			[Sharpen.Stub]
			public Standard(android.text.Layout.Alignment? align)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public Standard(android.os.Parcel src)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.text.ParcelableSpan")]
			public virtual int getSpanTypeId()
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

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.text.style.AlignmentSpan")]
			public virtual android.text.Layout.Alignment? getAlignment()
			{
				throw new System.NotImplementedException();
			}

			private readonly android.text.Layout.Alignment? mAlignment;
		}
	}
}

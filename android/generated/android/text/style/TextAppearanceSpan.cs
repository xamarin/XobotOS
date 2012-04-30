using Sharpen;

namespace android.text.style
{
	[Sharpen.Stub]
	public class TextAppearanceSpan : android.text.style.MetricAffectingSpan, android.text.ParcelableSpan
	{
		private readonly string mTypeface;

		private readonly int mStyle;

		private readonly int mTextSize;

		private readonly android.content.res.ColorStateList mTextColor;

		private readonly android.content.res.ColorStateList mTextColorLink;

		[Sharpen.Stub]
		public TextAppearanceSpan(android.content.Context context, int appearance) : this
			(context, appearance, -1)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public TextAppearanceSpan(android.content.Context context, int appearance, int colorList
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public TextAppearanceSpan(string family, int style, int size, android.content.res.ColorStateList
			 color, android.content.res.ColorStateList linkColor)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public TextAppearanceSpan(android.os.Parcel src)
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
		public virtual string getFamily()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.content.res.ColorStateList getTextColor()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.content.res.ColorStateList getLinkTextColor()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getTextSize()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getTextStyle()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.text.style.CharacterStyle")]
		public override void updateDrawState(android.text.TextPaint ds)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.text.style.MetricAffectingSpan")]
		public override void updateMeasureState(android.text.TextPaint ds)
		{
			throw new System.NotImplementedException();
		}
	}
}

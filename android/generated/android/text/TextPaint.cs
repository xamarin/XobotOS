using Sharpen;

namespace android.text
{
	/// <summary>
	/// TextPaint is an extension of Paint that leaves room for some extra
	/// data used during text measuring and drawing.
	/// </summary>
	/// <remarks>
	/// TextPaint is an extension of Paint that leaves room for some extra
	/// data used during text measuring and drawing.
	/// </remarks>
	[Sharpen.Sharpened]
	public class TextPaint : android.graphics.Paint
	{
		public int bgColor;

		public int baselineShift;

		public int linkColor;

		public int[] drawableState;

		public float density = 1.0f;

		/// <summary>Special value 0 means no custom underline</summary>
		/// <hide></hide>
		public int underlineColor = 0;

		/// <summary>Defined as a multiplier of the default underline thickness.</summary>
		/// <remarks>Defined as a multiplier of the default underline thickness. Use 1.0f for default thickness.
		/// 	</remarks>
		/// <hide></hide>
		public float underlineThickness;

		public TextPaint() : base()
		{
		}

		public TextPaint(int flags) : base(flags)
		{
		}

		public TextPaint(android.graphics.Paint p) : base(p)
		{
		}

		// Special value 0 means no background paint
		/// <summary>
		/// Copy the fields from tp into this TextPaint, including the
		/// fields inherited from Paint.
		/// </summary>
		/// <remarks>
		/// Copy the fields from tp into this TextPaint, including the
		/// fields inherited from Paint.
		/// </remarks>
		public virtual void set(android.text.TextPaint tp)
		{
			base.set(tp);
			bgColor = tp.bgColor;
			baselineShift = tp.baselineShift;
			linkColor = tp.linkColor;
			drawableState = tp.drawableState;
			density = tp.density;
			underlineColor = tp.underlineColor;
			underlineThickness = tp.underlineThickness;
		}

		/// <summary>Defines a custom underline for this Paint.</summary>
		/// <remarks>Defines a custom underline for this Paint.</remarks>
		/// <param name="color">underline solid color</param>
		/// <param name="thickness">underline thickness</param>
		/// <hide></hide>
		public virtual void setUnderlineText(int color, float thickness)
		{
			underlineColor = color;
			underlineThickness = thickness;
		}
	}
}

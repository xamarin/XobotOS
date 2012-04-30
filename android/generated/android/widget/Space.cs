using Sharpen;

namespace android.widget
{
	/// <summary>
	/// Space is a lightweight View subclass that may be used to create gaps between components
	/// in general purpose layouts.
	/// </summary>
	/// <remarks>
	/// Space is a lightweight View subclass that may be used to create gaps between components
	/// in general purpose layouts.
	/// </remarks>
	[Sharpen.Sharpened]
	public sealed class Space : android.view.View
	{
		/// <summary><inheritDoc></inheritDoc></summary>
		public Space(android.content.Context context, android.util.AttributeSet attrs, int
			 defStyle) : base(context, attrs, defStyle)
		{
			if (getVisibility() == VISIBLE)
			{
				setVisibility(INVISIBLE);
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public Space(android.content.Context context, android.util.AttributeSet attrs) : 
			this(context, attrs, 0)
		{
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public Space(android.content.Context context) : this(context, null)
		{
		}

		//noinspection NullableProblems
		/// <summary>Draw nothing.</summary>
		/// <remarks>Draw nothing.</remarks>
		/// <param name="canvas">an unused parameter.</param>
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void draw(android.graphics.Canvas canvas)
		{
		}

		/// <summary>
		/// Compare to:
		/// <see cref="android.view.View.getDefaultSize(int, int)">android.view.View.getDefaultSize(int, int)
		/// 	</see>
		/// If mode is AT_MOST, return the child size instead of the parent size
		/// (unless it is too big).
		/// </summary>
		private static int getDefaultSize2(int size, int measureSpec)
		{
			int result = size;
			int specMode = android.view.View.MeasureSpec.getMode(measureSpec);
			int specSize = android.view.View.MeasureSpec.getSize(measureSpec);
			switch (specMode)
			{
				case android.view.View.MeasureSpec.UNSPECIFIED:
				{
					result = size;
					break;
				}

				case android.view.View.MeasureSpec.AT_MOST:
				{
					result = System.Math.Min(size, specSize);
					break;
				}

				case android.view.View.MeasureSpec.EXACTLY:
				{
					result = specSize;
					break;
				}
			}
			return result;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onMeasure(int widthMeasureSpec, int heightMeasureSpec
			)
		{
			setMeasuredDimension(getDefaultSize2(getSuggestedMinimumWidth(), widthMeasureSpec
				), getDefaultSize2(getSuggestedMinimumHeight(), heightMeasureSpec));
		}
	}
}

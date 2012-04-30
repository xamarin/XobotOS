using Sharpen;

namespace android.widget.@internal
{
	/// <summary>
	/// A special layout when measured in AT_MOST will take up a given percentage of
	/// the available space.
	/// </summary>
	/// <remarks>
	/// A special layout when measured in AT_MOST will take up a given percentage of
	/// the available space.
	/// </remarks>
	[Sharpen.Sharpened]
	public class WeightedLinearLayout : android.widget.LinearLayout
	{
		private float mMajorWeightMin;

		private float mMinorWeightMin;

		private float mMajorWeightMax;

		private float mMinorWeightMax;

		public WeightedLinearLayout(android.content.Context context) : base(context)
		{
		}

		public WeightedLinearLayout(android.content.Context context, android.util.AttributeSet
			 attrs) : base(context, attrs)
		{
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.WeightedLinearLayout);
			mMajorWeightMin = a.getFloat(android.@internal.R.styleable.WeightedLinearLayout_majorWeightMin
				, 0.0f);
			mMinorWeightMin = a.getFloat(android.@internal.R.styleable.WeightedLinearLayout_minorWeightMin
				, 0.0f);
			mMajorWeightMax = a.getFloat(android.@internal.R.styleable.WeightedLinearLayout_majorWeightMax
				, 0.0f);
			mMinorWeightMax = a.getFloat(android.@internal.R.styleable.WeightedLinearLayout_minorWeightMax
				, 0.0f);
			a.recycle();
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onMeasure(int widthMeasureSpec, int heightMeasureSpec
			)
		{
			android.util.DisplayMetrics metrics = getContext().getResources().getDisplayMetrics
				();
			int screenWidth = metrics.widthPixels;
			bool isPortrait = screenWidth < metrics.heightPixels;
			int widthMode = android.view.View.MeasureSpec.getMode(widthMeasureSpec);
			base.onMeasure(widthMeasureSpec, heightMeasureSpec);
			int width = getMeasuredWidth();
			bool measure_1 = false;
			widthMeasureSpec = android.view.View.MeasureSpec.makeMeasureSpec(width, android.view.View
				.MeasureSpec.EXACTLY);
			float widthWeightMin = isPortrait ? mMinorWeightMin : mMajorWeightMin;
			float widthWeightMax = isPortrait ? mMinorWeightMax : mMajorWeightMax;
			if (widthMode == android.view.View.MeasureSpec.AT_MOST)
			{
				int weightedMin = (int)(screenWidth * widthWeightMin);
				int weightedMax = (int)(screenWidth * widthWeightMin);
				if (widthWeightMin > 0.0f && width < weightedMin)
				{
					widthMeasureSpec = android.view.View.MeasureSpec.makeMeasureSpec(weightedMin, android.view.View
						.MeasureSpec.EXACTLY);
					measure_1 = true;
				}
				else
				{
					if (widthWeightMax > 0.0f && width > weightedMax)
					{
						widthMeasureSpec = android.view.View.MeasureSpec.makeMeasureSpec(weightedMax, android.view.View
							.MeasureSpec.EXACTLY);
						measure_1 = true;
					}
				}
			}
			// TODO: Support height?
			if (measure_1)
			{
				base.onMeasure(widthMeasureSpec, heightMeasureSpec);
			}
		}
	}
}

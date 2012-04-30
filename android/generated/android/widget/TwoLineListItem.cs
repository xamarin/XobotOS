using Sharpen;

namespace android.widget
{
	/// <summary><p>A view group with two children, intended for use in ListViews.</summary>
	/// <remarks>
	/// <p>A view group with two children, intended for use in ListViews. This item has two
	/// <see cref="TextView">TextViews</see>
	/// elements (or subclasses) with the ID values
	/// <see cref="android.R.id.text1">text1</see>
	/// and
	/// <see cref="android.R.id.text2">text2</see>
	/// . There is an optional third View element with the
	/// ID
	/// <see cref="android.R.id.selectedIcon">selectedIcon</see>
	/// , which can be any View subclass
	/// (though it is typically a graphic View, such as
	/// <see cref="ImageView">ImageView</see>
	/// )
	/// that can be displayed when a TwoLineListItem has focus. Android supplies a
	/// <see cref="android.R.layout.two_line_list_item">standard layout resource for TwoLineListView
	/// 	</see>
	/// 
	/// (which does not include a selected item icon), but you can design your own custom XML
	/// layout for this object.
	/// </remarks>
	/// <attr>ref android.R.styleable#TwoLineListItem_mode</attr>
	[Sharpen.Sharpened]
	public class TwoLineListItem : android.widget.RelativeLayout
	{
		private android.widget.TextView mText1;

		private android.widget.TextView mText2;

		public TwoLineListItem(android.content.Context context) : this(context, null, 0)
		{
		}

		public TwoLineListItem(android.content.Context context, android.util.AttributeSet
			 attrs) : this(context, attrs, 0)
		{
		}

		public TwoLineListItem(android.content.Context context, android.util.AttributeSet
			 attrs, int defStyle) : base(context, attrs, defStyle)
		{
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.TwoLineListItem, defStyle, 0);
			a.recycle();
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onFinishInflate()
		{
			base.onFinishInflate();
			mText1 = (android.widget.TextView)findViewById(android.@internal.R.id.text1);
			mText2 = (android.widget.TextView)findViewById(android.@internal.R.id.text2);
		}

		/// <summary>Returns a handle to the item with ID text1.</summary>
		/// <remarks>Returns a handle to the item with ID text1.</remarks>
		/// <returns>A handle to the item with ID text1.</returns>
		public virtual android.widget.TextView getText1()
		{
			return mText1;
		}

		/// <summary>Returns a handle to the item with ID text2.</summary>
		/// <remarks>Returns a handle to the item with ID text2.</remarks>
		/// <returns>A handle to the item with ID text2.</returns>
		public virtual android.widget.TextView getText2()
		{
			return mText2;
		}
	}
}

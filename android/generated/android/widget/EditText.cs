using Sharpen;

namespace android.widget
{
	/// <summary>
	/// EditText is a thin veneer over TextView that configures itself
	/// to be editable.
	/// </summary>
	/// <remarks>
	/// EditText is a thin veneer over TextView that configures itself
	/// to be editable.
	/// <p>See the &lt;a href="
	/// <docRoot></docRoot>
	/// resources/tutorials/views/hello-formstuff.html"&gt;Form Stuff
	/// tutorial</a>.</p>
	/// <p>
	/// <b>XML attributes</b>
	/// <p>
	/// See
	/// <see cref="android.R.styleable.EditText">EditText Attributes</see>
	/// ,
	/// <see cref="android.R.styleable.TextView">TextView Attributes</see>
	/// ,
	/// <see cref="android.R.styleable.View">View Attributes</see>
	/// </remarks>
	[Sharpen.Sharpened]
	public partial class EditText : android.widget.TextView
	{
		public EditText(android.content.Context context) : this(context, null)
		{
		}

		public EditText(android.content.Context context, android.util.AttributeSet attrs)
			 : this(context, attrs, android.@internal.R.attr.editTextStyle)
		{
		}

		public EditText(android.content.Context context, android.util.AttributeSet attrs, 
			int defStyle) : base(context, attrs, defStyle)
		{
		}

		[Sharpen.OverridesMethod(@"android.widget.TextView")]
		protected internal override bool getDefaultEditable()
		{
			return true;
		}

		[Sharpen.OverridesMethod(@"android.widget.TextView")]
		protected internal override android.text.method.MovementMethod getDefaultMovementMethod
			()
		{
			return android.text.method.ArrowKeyMovementMethod.getInstance();
		}

		[Sharpen.OverridesMethod(@"android.widget.TextView")]
		public override void setText(java.lang.CharSequence text, android.widget.TextView
			.BufferType type)
		{
			base.setText(text, android.widget.TextView.BufferType.EDITABLE);
		}

		/// <summary>
		/// Convenience for
		/// <see cref="android.text.Selection.setSelection(android.text.Spannable, int, int)"
		/// 	>android.text.Selection.setSelection(android.text.Spannable, int, int)</see>
		/// .
		/// </summary>
		public virtual void setSelection(int start, int stop)
		{
			android.text.Selection.setSelection(((android.text.Editable)getText()), start, stop
				);
		}

		/// <summary>
		/// Convenience for
		/// <see cref="android.text.Selection.setSelection(android.text.Spannable, int)">android.text.Selection.setSelection(android.text.Spannable, int)
		/// 	</see>
		/// .
		/// </summary>
		public virtual void setSelection(int index)
		{
			android.text.Selection.setSelection(((android.text.Editable)getText()), index);
		}

		/// <summary>
		/// Convenience for
		/// <see cref="android.text.Selection.extendSelection(android.text.Spannable, int)">android.text.Selection.extendSelection(android.text.Spannable, int)
		/// 	</see>
		/// .
		/// </summary>
		public virtual void extendSelection(int index)
		{
			android.text.Selection.extendSelection(((android.text.Editable)getText()), index);
		}

		[Sharpen.OverridesMethod(@"android.widget.TextView")]
		public override void setEllipsize(android.text.TextUtils.TruncateAt? ellipsis)
		{
			if (ellipsis == android.text.TextUtils.TruncateAt.MARQUEE)
			{
				throw new System.ArgumentException("EditText cannot use the ellipsize mode " + "TextUtils.TruncateAt.MARQUEE"
					);
			}
			base.setEllipsize(ellipsis);
		}
	}
}

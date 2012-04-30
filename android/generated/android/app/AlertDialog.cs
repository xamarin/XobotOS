using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	public class AlertDialog : android.app.Dialog, android.content.DialogInterface
	{
		private android.app.@internal.AlertController mAlert;

		public const int THEME_TRADITIONAL = 1;

		public const int THEME_HOLO_DARK = 2;

		public const int THEME_HOLO_LIGHT = 3;

		public const int THEME_DEVICE_DEFAULT_DARK = 4;

		public const int THEME_DEVICE_DEFAULT_LIGHT = 5;

		[Sharpen.Stub]
		protected internal AlertDialog(android.content.Context context) : this(context, resolveDialogTheme
			(context, 0), true)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal AlertDialog(android.content.Context context, int theme) : this
			(context, theme, true)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal AlertDialog(android.content.Context context, int theme, bool createContextWrapper
			) : base(context, resolveDialogTheme(context, theme), createContextWrapper)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal AlertDialog(android.content.Context context, bool cancelable, 
			android.content.DialogInterfaceClass.OnCancelListener cancelListener) : base(context
			, resolveDialogTheme(context, 0))
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal static int resolveDialogTheme(android.content.Context context, int resid
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.widget.Button getButton(int whichButton)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.widget.ListView getListView()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Dialog")]
		public override void setTitle(java.lang.CharSequence title)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setCustomTitle(android.view.View customTitleView)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setMessage(java.lang.CharSequence message)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setView(android.view.View view)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setView(android.view.View view, int viewSpacingLeft, int viewSpacingTop
			, int viewSpacingRight, int viewSpacingBottom)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setButton(int whichButton, java.lang.CharSequence text, android.os.Message
			 msg)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setButton(int whichButton, java.lang.CharSequence text, android.content.DialogInterfaceClass
			.OnClickListener listener)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"Use setButton(int, java.lang.CharSequence, android.os.Message) withandroid.content.DialogInterfaceClass.BUTTON_POSITIVE ."
			)]
		public virtual void setButton(java.lang.CharSequence text, android.os.Message msg
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"Use setButton(int, java.lang.CharSequence, android.os.Message) withandroid.content.DialogInterfaceClass.BUTTON_NEGATIVE ."
			)]
		public virtual void setButton2(java.lang.CharSequence text, android.os.Message msg
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"Use setButton(int, java.lang.CharSequence, android.os.Message) withandroid.content.DialogInterfaceClass.BUTTON_NEUTRAL ."
			)]
		public virtual void setButton3(java.lang.CharSequence text, android.os.Message msg
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"UsesetButton(int, java.lang.CharSequence, android.content.DialogInterfaceClass.OnClickListener) with android.content.DialogInterfaceClass.BUTTON_POSITIVE"
			)]
		public virtual void setButton(java.lang.CharSequence text, android.content.DialogInterfaceClass
			.OnClickListener listener)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"UsesetButton(int, java.lang.CharSequence, android.content.DialogInterfaceClass.OnClickListener) with android.content.DialogInterfaceClass.BUTTON_NEGATIVE"
			)]
		public virtual void setButton2(java.lang.CharSequence text, android.content.DialogInterfaceClass
			.OnClickListener listener)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"UsesetButton(int, java.lang.CharSequence, android.content.DialogInterfaceClass.OnClickListener) with android.content.DialogInterfaceClass.BUTTON_POSITIVE"
			)]
		public virtual void setButton3(java.lang.CharSequence text, android.content.DialogInterfaceClass
			.OnClickListener listener)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setIcon(int resId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setIcon(android.graphics.drawable.Drawable icon)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setIconAttribute(int attrId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setInverseBackgroundForced(bool forceInverseBackground)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Dialog")]
		protected internal override void onCreate(android.os.Bundle savedInstanceState)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Dialog")]
		public override bool onKeyDown(int keyCode, android.view.KeyEvent @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Dialog")]
		public override bool onKeyUp(int keyCode, android.view.KeyEvent @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public class Builder
		{
			private readonly android.app.@internal.AlertController.AlertParams P;

			private int mTheme;

			[Sharpen.Stub]
			public Builder(android.content.Context context) : this(context, resolveDialogTheme
				(context, 0))
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public Builder(android.content.Context context, int theme)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.content.Context getContext()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.AlertDialog.Builder setTitle(int titleId)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.AlertDialog.Builder setTitle(java.lang.CharSequence title
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.AlertDialog.Builder setCustomTitle(android.view.View customTitleView
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.AlertDialog.Builder setMessage(int messageId)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.AlertDialog.Builder setMessage(java.lang.CharSequence 
				message)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.AlertDialog.Builder setIcon(int iconId)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.AlertDialog.Builder setIcon(android.graphics.drawable.Drawable
				 icon)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.AlertDialog.Builder setIconAttribute(int attrId)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.AlertDialog.Builder setPositiveButton(int textId, android.content.DialogInterfaceClass
				.OnClickListener listener)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.AlertDialog.Builder setPositiveButton(java.lang.CharSequence
				 text, android.content.DialogInterfaceClass.OnClickListener listener)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.AlertDialog.Builder setNegativeButton(int textId, android.content.DialogInterfaceClass
				.OnClickListener listener)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.AlertDialog.Builder setNegativeButton(java.lang.CharSequence
				 text, android.content.DialogInterfaceClass.OnClickListener listener)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.AlertDialog.Builder setNeutralButton(int textId, android.content.DialogInterfaceClass
				.OnClickListener listener)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.AlertDialog.Builder setNeutralButton(java.lang.CharSequence
				 text, android.content.DialogInterfaceClass.OnClickListener listener)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.AlertDialog.Builder setCancelable(bool cancelable)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.AlertDialog.Builder setOnCancelListener(android.content.DialogInterfaceClass
				.OnCancelListener onCancelListener)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.AlertDialog.Builder setOnKeyListener(android.content.DialogInterfaceClass
				.OnKeyListener onKeyListener)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.AlertDialog.Builder setItems(int itemsId, android.content.DialogInterfaceClass
				.OnClickListener listener)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.AlertDialog.Builder setItems(java.lang.CharSequence[] 
				items, android.content.DialogInterfaceClass.OnClickListener listener)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.AlertDialog.Builder setAdapter(android.widget.ListAdapter
				 adapter, android.content.DialogInterfaceClass.OnClickListener listener)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.AlertDialog.Builder setCursor(android.database.Cursor 
				cursor, android.content.DialogInterfaceClass.OnClickListener listener, string labelColumn
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.AlertDialog.Builder setMultiChoiceItems(int itemsId, bool
				[] checkedItems, android.content.DialogInterfaceClass.OnMultiChoiceClickListener
				 listener)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.AlertDialog.Builder setMultiChoiceItems(java.lang.CharSequence
				[] items, bool[] checkedItems, android.content.DialogInterfaceClass.OnMultiChoiceClickListener
				 listener)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.AlertDialog.Builder setMultiChoiceItems(android.database.Cursor
				 cursor, string isCheckedColumn, string labelColumn, android.content.DialogInterfaceClass
				.OnMultiChoiceClickListener listener)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.AlertDialog.Builder setSingleChoiceItems(int itemsId, 
				int checkedItem, android.content.DialogInterfaceClass.OnClickListener listener)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.AlertDialog.Builder setSingleChoiceItems(android.database.Cursor
				 cursor, int checkedItem, string labelColumn, android.content.DialogInterfaceClass
				.OnClickListener listener)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.AlertDialog.Builder setSingleChoiceItems(java.lang.CharSequence
				[] items, int checkedItem, android.content.DialogInterfaceClass.OnClickListener 
				listener)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.AlertDialog.Builder setSingleChoiceItems(android.widget.ListAdapter
				 adapter, int checkedItem, android.content.DialogInterfaceClass.OnClickListener 
				listener)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.AlertDialog.Builder setOnItemSelectedListener(android.widget.AdapterView
				.OnItemSelectedListener listener)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.AlertDialog.Builder setView(android.view.View view)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.AlertDialog.Builder setView(android.view.View view, int
				 viewSpacingLeft, int viewSpacingTop, int viewSpacingRight, int viewSpacingBottom
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.AlertDialog.Builder setInverseBackgroundForced(bool useInverseBackground
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.AlertDialog.Builder setRecycleOnMeasureEnabled(bool enabled
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.AlertDialog create()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.AlertDialog show()
			{
				throw new System.NotImplementedException();
			}
		}
	}
}

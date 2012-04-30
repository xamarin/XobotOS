using Sharpen;

namespace android.text.method
{
	/// <summary>Dialog for choosing accented characters related to a base character.</summary>
	/// <remarks>Dialog for choosing accented characters related to a base character.</remarks>
	[Sharpen.Sharpened]
	public class CharacterPickerDialog : android.app.Dialog, android.widget.AdapterView
		.OnItemClickListener, android.view.View.OnClickListener
	{
		private android.view.View mView;

		private android.text.Editable mText;

		private string mOptions;

		private bool mInsert;

		private android.view.LayoutInflater mInflater;

		private android.widget.Button mCancelButton;

		/// <summary>
		/// Creates a new CharacterPickerDialog that presents the specified
		/// <code>options</code> for insertion or replacement (depending on
		/// the sense of <code>insert</code>) into <code>text</code>.
		/// </summary>
		/// <remarks>
		/// Creates a new CharacterPickerDialog that presents the specified
		/// <code>options</code> for insertion or replacement (depending on
		/// the sense of <code>insert</code>) into <code>text</code>.
		/// </remarks>
		public CharacterPickerDialog(android.content.Context context, android.view.View view
			, android.text.Editable text, string options, bool insert) : base(context, android.@internal.R
			.style.Theme_Panel)
		{
			mView = view;
			mText = text;
			mOptions = options;
			mInsert = insert;
			mInflater = android.view.LayoutInflater.from(context);
		}

		[Sharpen.OverridesMethod(@"android.app.Dialog")]
		protected internal override void onCreate(android.os.Bundle savedInstanceState)
		{
			base.onCreate(savedInstanceState);
			android.view.WindowManagerClass.LayoutParams @params = getWindow().getAttributes(
				);
			@params.token = mView.getApplicationWindowToken();
			@params.type = android.view.WindowManagerClass.LayoutParams.TYPE_APPLICATION_ATTACHED_DIALOG;
			@params.flags = @params.flags | android.view.Window.FEATURE_NO_TITLE;
			setContentView(android.@internal.R.layout.character_picker);
			android.widget.GridView grid = (android.widget.GridView)findViewById(android.@internal.R
				.id.characterPicker);
			grid.setAdapter(new android.text.method.CharacterPickerDialog.OptionsAdapter(this
				, getContext()));
			grid.setOnItemClickListener(this);
			mCancelButton = (android.widget.Button)findViewById(android.@internal.R.id.cancel
				);
			mCancelButton.setOnClickListener(this);
		}

		/// <summary>Handles clicks on the character buttons.</summary>
		/// <remarks>Handles clicks on the character buttons.</remarks>
		[Sharpen.ImplementsInterface(@"android.widget.AdapterView.OnItemClickListener")]
		public virtual void onItemClick(object parent, android.view.View view, int position
			, long id)
		{
			string result = mOptions[position].ToString();
			replaceCharacterAndClose(java.lang.CharSequenceProxy.Wrap(result));
		}

		private void replaceCharacterAndClose(java.lang.CharSequence replace)
		{
			int selEnd = android.text.Selection.getSelectionEnd(mText);
			if (mInsert || selEnd == 0)
			{
				mText.insert(selEnd, replace);
			}
			else
			{
				mText.replace(selEnd - 1, selEnd, replace);
			}
			dismiss();
		}

		/// <summary>Handles clicks on the Cancel button.</summary>
		/// <remarks>Handles clicks on the Cancel button.</remarks>
		[Sharpen.ImplementsInterface(@"android.view.View.OnClickListener")]
		public virtual void onClick(android.view.View v)
		{
			if (v == mCancelButton)
			{
				dismiss();
			}
			else
			{
				if (v is android.widget.Button)
				{
					java.lang.CharSequence result = ((android.widget.Button)v).getText();
					replaceCharacterAndClose(result);
				}
			}
		}

		private class OptionsAdapter : android.widget.BaseAdapter
		{
			public OptionsAdapter(CharacterPickerDialog _enclosing, android.content.Context context
				) : base()
			{
				this._enclosing = _enclosing;
			}

			[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
			public override android.view.View getView(int position, android.view.View convertView
				, android.view.ViewGroup parent)
			{
				android.widget.Button b = (android.widget.Button)this._enclosing.mInflater.inflate
					(android.@internal.R.layout.character_picker_button, null);
				b.setText(java.lang.CharSequenceProxy.Wrap(this._enclosing.mOptions[position].ToString
					()));
				b.setOnClickListener(this._enclosing);
				return b;
			}

			[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
			public override int getCount()
			{
				return this._enclosing.mOptions.Length;
			}

			[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
			public override object getItem(int position)
			{
				return this._enclosing.mOptions[position].ToString();
			}

			[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
			public override long getItemId(int position)
			{
				return position;
			}

			private readonly CharacterPickerDialog _enclosing;
		}
	}
}

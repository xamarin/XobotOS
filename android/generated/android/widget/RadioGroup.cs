using Sharpen;

namespace android.widget
{
	/// <summary>
	/// <p>This class is used to create a multiple-exclusion scope for a set of radio
	/// buttons.
	/// </summary>
	/// <remarks>
	/// <p>This class is used to create a multiple-exclusion scope for a set of radio
	/// buttons. Checking one radio button that belongs to a radio group unchecks
	/// any previously checked radio button within the same group.</p>
	/// <p>Intially, all of the radio buttons are unchecked. While it is not possible
	/// to uncheck a particular radio button, the radio group can be cleared to
	/// remove the checked state.</p>
	/// <p>The selection is identified by the unique id of the radio button as defined
	/// in the XML layout file.</p>
	/// <p><strong>XML Attributes</strong></p>
	/// <p>See
	/// <see cref="android.R.styleable.RadioGroup">RadioGroup Attributes</see>
	/// ,
	/// <see cref="android.R.styleable.LinearLayout">LinearLayout Attributes</see>
	/// ,
	/// <see cref="android.R.styleable.ViewGroup">ViewGroup Attributes</see>
	/// ,
	/// <see cref="android.R.styleable.View">View Attributes</see>
	/// </p>
	/// <p>Also see
	/// <see cref="LayoutParams">LinearLayout.LayoutParams</see>
	/// for layout attributes.</p>
	/// </remarks>
	/// <seealso cref="RadioButton">RadioButton</seealso>
	[Sharpen.Sharpened]
	public class RadioGroup : android.widget.LinearLayout
	{
		private int mCheckedId = -1;

		private android.widget.CompoundButton.OnCheckedChangeListener mChildOnCheckedChangeListener;

		private bool mProtectFromCheckedChange = false;

		private android.widget.RadioGroup.OnCheckedChangeListener mOnCheckedChangeListener;

		private android.widget.RadioGroup.PassThroughHierarchyChangeListener mPassThroughListener;

		/// <summary><inheritDoc></inheritDoc></summary>
		public RadioGroup(android.content.Context context) : base(context)
		{
			// holds the checked id; the selection is empty by default
			// tracks children radio buttons checked state
			// when true, mOnCheckedChangeListener discards events
			setOrientation(VERTICAL);
			init();
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public RadioGroup(android.content.Context context, android.util.AttributeSet attrs
			) : base(context, attrs)
		{
			// retrieve selected radio button as requested by the user in the
			// XML layout file
			android.content.res.TypedArray attributes = context.obtainStyledAttributes(attrs, 
				android.@internal.R.styleable.RadioGroup, android.@internal.R.attr.radioButtonStyle
				, 0);
			int value = attributes.getResourceId(android.@internal.R.styleable.RadioGroup_checkedButton
				, android.view.View.NO_ID);
			if (value != android.view.View.NO_ID)
			{
				mCheckedId = value;
			}
			int index = attributes.getInt(android.@internal.R.styleable.RadioGroup_orientation
				, VERTICAL);
			setOrientation(index);
			attributes.recycle();
			init();
		}

		private void init()
		{
			mChildOnCheckedChangeListener = new android.widget.RadioGroup.CheckedStateTracker
				(this);
			mPassThroughListener = new android.widget.RadioGroup.PassThroughHierarchyChangeListener
				(this);
			base.setOnHierarchyChangeListener(mPassThroughListener);
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override void setOnHierarchyChangeListener(android.view.ViewGroup.OnHierarchyChangeListener
			 listener)
		{
			// the user listener is delegated to our pass-through listener
			mPassThroughListener.mOnHierarchyChangeListener = listener;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onFinishInflate()
		{
			base.onFinishInflate();
			// checks the appropriate radio button as requested in the XML file
			if (mCheckedId != -1)
			{
				mProtectFromCheckedChange = true;
				setCheckedStateForView(mCheckedId, true);
				mProtectFromCheckedChange = false;
				setCheckedId(mCheckedId);
			}
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override void addView(android.view.View child, int index, android.view.ViewGroup
			.LayoutParams @params)
		{
			if (child is android.widget.RadioButton)
			{
				android.widget.RadioButton button = (android.widget.RadioButton)child;
				if (button.isChecked())
				{
					mProtectFromCheckedChange = true;
					if (mCheckedId != -1)
					{
						setCheckedStateForView(mCheckedId, false);
					}
					mProtectFromCheckedChange = false;
					setCheckedId(button.getId());
				}
			}
			base.addView(child, index, @params);
		}

		/// <summary>
		/// <p>Sets the selection to the radio button whose identifier is passed in
		/// parameter.
		/// </summary>
		/// <remarks>
		/// <p>Sets the selection to the radio button whose identifier is passed in
		/// parameter. Using -1 as the selection identifier clears the selection;
		/// such an operation is equivalent to invoking
		/// <see cref="clearCheck()">clearCheck()</see>
		/// .</p>
		/// </remarks>
		/// <param name="id">the unique id of the radio button to select in this group</param>
		/// <seealso cref="getCheckedRadioButtonId()">getCheckedRadioButtonId()</seealso>
		/// <seealso cref="clearCheck()">clearCheck()</seealso>
		public virtual void check(int id)
		{
			// don't even bother
			if (id != -1 && (id == mCheckedId))
			{
				return;
			}
			if (mCheckedId != -1)
			{
				setCheckedStateForView(mCheckedId, false);
			}
			if (id != -1)
			{
				setCheckedStateForView(id, true);
			}
			setCheckedId(id);
		}

		private void setCheckedId(int id)
		{
			mCheckedId = id;
			if (mOnCheckedChangeListener != null)
			{
				mOnCheckedChangeListener.onCheckedChanged(this, mCheckedId);
			}
		}

		private void setCheckedStateForView(int viewId, bool @checked)
		{
			android.view.View checkedView = findViewById(viewId);
			if (checkedView != null && checkedView is android.widget.RadioButton)
			{
				((android.widget.RadioButton)checkedView).setChecked(@checked);
			}
		}

		/// <summary><p>Returns the identifier of the selected radio button in this group.</summary>
		/// <remarks>
		/// <p>Returns the identifier of the selected radio button in this group.
		/// Upon empty selection, the returned value is -1.</p>
		/// </remarks>
		/// <returns>the unique id of the selected radio button in this group</returns>
		/// <seealso cref="check(int)">check(int)</seealso>
		/// <seealso cref="clearCheck()">clearCheck()</seealso>
		public virtual int getCheckedRadioButtonId()
		{
			return mCheckedId;
		}

		/// <summary><p>Clears the selection.</summary>
		/// <remarks>
		/// <p>Clears the selection. When the selection is cleared, no radio button
		/// in this group is selected and
		/// <see cref="getCheckedRadioButtonId()">getCheckedRadioButtonId()</see>
		/// returns
		/// null.</p>
		/// </remarks>
		/// <seealso cref="check(int)">check(int)</seealso>
		/// <seealso cref="getCheckedRadioButtonId()">getCheckedRadioButtonId()</seealso>
		public virtual void clearCheck()
		{
			check(-1);
		}

		/// <summary>
		/// <p>Register a callback to be invoked when the checked radio button
		/// changes in this group.</p>
		/// </summary>
		/// <param name="listener">the callback to call on checked state change</param>
		public virtual void setOnCheckedChangeListener(android.widget.RadioGroup.OnCheckedChangeListener
			 listener)
		{
			mOnCheckedChangeListener = listener;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override android.view.ViewGroup.LayoutParams generateLayoutParams(android.util.AttributeSet
			 attrs)
		{
			return new android.widget.RadioGroup.LayoutParams(getContext(), attrs);
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		protected internal override bool checkLayoutParams(android.view.ViewGroup.LayoutParams
			 p)
		{
			return p is android.widget.RadioGroup.LayoutParams;
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		protected internal override android.view.ViewGroup.LayoutParams generateDefaultLayoutParams
			()
		{
			return new android.widget.RadioGroup.LayoutParams(android.view.ViewGroup.LayoutParams
				.WRAP_CONTENT, android.view.ViewGroup.LayoutParams.WRAP_CONTENT);
		}

		/// <summary>
		/// <p>This set of layout parameters defaults the width and the height of
		/// the children to
		/// <see cref="android.view.ViewGroup.LayoutParams.WRAP_CONTENT">android.view.ViewGroup.LayoutParams.WRAP_CONTENT
		/// 	</see>
		/// when they are not specified in the
		/// XML file. Otherwise, this class ussed the value read from the XML file.</p>
		/// <p>See
		/// <see cref="android.R.styleable.LinearLayout_Layout">LinearLayout Attributes</see>
		/// for a list of all child view attributes that this class supports.</p>
		/// </summary>
		public class LayoutParams : android.widget.LinearLayout.LayoutParams
		{
			/// <summary><inheritDoc></inheritDoc></summary>
			public LayoutParams(android.content.Context c, android.util.AttributeSet attrs) : 
				base(c, attrs)
			{
			}

			/// <summary><inheritDoc></inheritDoc></summary>
			public LayoutParams(int w, int h) : base(w, h)
			{
			}

			/// <summary><inheritDoc></inheritDoc></summary>
			public LayoutParams(int w, int h, float initWeight) : base(w, h, initWeight)
			{
			}

			/// <summary><inheritDoc></inheritDoc></summary>
			public LayoutParams(android.view.ViewGroup.LayoutParams p) : base(p)
			{
			}

			/// <summary><inheritDoc></inheritDoc></summary>
			public LayoutParams(android.view.ViewGroup.MarginLayoutParams source) : base(source
				)
			{
			}

			/// <summary>
			/// <p>Fixes the child's width to
			/// <see cref="android.view.ViewGroup.LayoutParams.WRAP_CONTENT">android.view.ViewGroup.LayoutParams.WRAP_CONTENT
			/// 	</see>
			/// and the child's
			/// height to
			/// <see cref="android.view.ViewGroup.LayoutParams.WRAP_CONTENT">android.view.ViewGroup.LayoutParams.WRAP_CONTENT
			/// 	</see>
			/// when not specified in the XML file.</p>
			/// </summary>
			/// <param name="a">the styled attributes set</param>
			/// <param name="widthAttr">the width attribute to fetch</param>
			/// <param name="heightAttr">the height attribute to fetch</param>
			[Sharpen.OverridesMethod(@"android.view.ViewGroup.LayoutParams")]
			protected internal override void setBaseAttributes(android.content.res.TypedArray
				 a, int widthAttr, int heightAttr)
			{
				if (a.hasValue(widthAttr))
				{
					width = a.getLayoutDimension(widthAttr, "layout_width");
				}
				else
				{
					width = WRAP_CONTENT;
				}
				if (a.hasValue(heightAttr))
				{
					height = a.getLayoutDimension(heightAttr, "layout_height");
				}
				else
				{
					height = WRAP_CONTENT;
				}
			}
		}

		/// <summary>
		/// <p>Interface definition for a callback to be invoked when the checked
		/// radio button changed in this group.</p>
		/// </summary>
		public interface OnCheckedChangeListener
		{
			/// <summary><p>Called when the checked radio button has changed.</summary>
			/// <remarks>
			/// <p>Called when the checked radio button has changed. When the
			/// selection is cleared, checkedId is -1.</p>
			/// </remarks>
			/// <param name="group">the group in which the checked radio button has changed</param>
			/// <param name="checkedId">the unique identifier of the newly checked radio button</param>
			void onCheckedChanged(android.widget.RadioGroup group, int checkedId);
		}

		private class CheckedStateTracker : android.widget.CompoundButton.OnCheckedChangeListener
		{
			[Sharpen.ImplementsInterface(@"android.widget.CompoundButton.OnCheckedChangeListener"
				)]
			public virtual void onCheckedChanged(android.widget.CompoundButton buttonView, bool
				 isChecked)
			{
				// prevents from infinite recursion
				if (this._enclosing.mProtectFromCheckedChange)
				{
					return;
				}
				this._enclosing.mProtectFromCheckedChange = true;
				if (this._enclosing.mCheckedId != -1)
				{
					this._enclosing.setCheckedStateForView(this._enclosing.mCheckedId, false);
				}
				this._enclosing.mProtectFromCheckedChange = false;
				int id = buttonView.getId();
				this._enclosing.setCheckedId(id);
			}

			internal CheckedStateTracker(RadioGroup _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly RadioGroup _enclosing;
		}

		/// <summary>
		/// <p>A pass-through listener acts upon the events and dispatches them
		/// to another listener.
		/// </summary>
		/// <remarks>
		/// <p>A pass-through listener acts upon the events and dispatches them
		/// to another listener. This allows the table layout to set its own internal
		/// hierarchy change listener without preventing the user to setup his.</p>
		/// </remarks>
		private class PassThroughHierarchyChangeListener : android.view.ViewGroup.OnHierarchyChangeListener
		{
			internal android.view.ViewGroup.OnHierarchyChangeListener mOnHierarchyChangeListener;

			/// <summary><inheritDoc></inheritDoc></summary>
			[Sharpen.ImplementsInterface(@"android.view.ViewGroup.OnHierarchyChangeListener")]
			public virtual void onChildViewAdded(android.view.View parent, android.view.View 
				child)
			{
				if (parent == this._enclosing && child is android.widget.RadioButton)
				{
					int id = child.getId();
					// generates an id if it's missing
					if (id == android.view.View.NO_ID)
					{
						id = child.GetHashCode();
						child.setId(id);
					}
					((android.widget.RadioButton)child).setOnCheckedChangeWidgetListener(this._enclosing
						.mChildOnCheckedChangeListener);
				}
				if (this.mOnHierarchyChangeListener != null)
				{
					this.mOnHierarchyChangeListener.onChildViewAdded(parent, child);
				}
			}

			/// <summary><inheritDoc></inheritDoc></summary>
			[Sharpen.ImplementsInterface(@"android.view.ViewGroup.OnHierarchyChangeListener")]
			public virtual void onChildViewRemoved(android.view.View parent, android.view.View
				 child)
			{
				if (parent == this._enclosing && child is android.widget.RadioButton)
				{
					((android.widget.RadioButton)child).setOnCheckedChangeWidgetListener(null);
				}
				if (this.mOnHierarchyChangeListener != null)
				{
					this.mOnHierarchyChangeListener.onChildViewRemoved(parent, child);
				}
			}

			internal PassThroughHierarchyChangeListener(RadioGroup _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly RadioGroup _enclosing;
		}
	}
}

using Sharpen;

namespace android.widget
{
	/// <summary>
	/// <see cref="ViewAnimator">ViewAnimator</see>
	/// that switches between two views, and has a factory
	/// from which these views are created.  You can either use the factory to
	/// create the views, or add them yourself.  A ViewSwitcher can only have two
	/// child views, of which only one is shown at a time.
	/// </summary>
	[Sharpen.Sharpened]
	public class ViewSwitcher : android.widget.ViewAnimator
	{
		/// <summary>The factory used to create the two children.</summary>
		/// <remarks>The factory used to create the two children.</remarks>
		internal android.widget.ViewSwitcher.ViewFactory mFactory;

		/// <summary>Creates a new empty ViewSwitcher.</summary>
		/// <remarks>Creates a new empty ViewSwitcher.</remarks>
		/// <param name="context">the application's environment</param>
		public ViewSwitcher(android.content.Context context) : base(context)
		{
		}

		/// <summary>
		/// Creates a new empty ViewSwitcher for the given context and with the
		/// specified set attributes.
		/// </summary>
		/// <remarks>
		/// Creates a new empty ViewSwitcher for the given context and with the
		/// specified set attributes.
		/// </remarks>
		/// <param name="context">the application environment</param>
		/// <param name="attrs">a collection of attributes</param>
		public ViewSwitcher(android.content.Context context, android.util.AttributeSet attrs
			) : base(context, attrs)
		{
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		/// <exception cref="System.InvalidOperationException">if this switcher already contains two children
		/// 	</exception>
		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override void addView(android.view.View child, int index, android.view.ViewGroup
			.LayoutParams @params)
		{
			if (getChildCount() >= 2)
			{
				throw new System.InvalidOperationException("Can't add more than 2 views to a ViewSwitcher"
					);
			}
			base.addView(child, index, @params);
		}

		/// <summary>Returns the next view to be displayed.</summary>
		/// <remarks>Returns the next view to be displayed.</remarks>
		/// <returns>the view that will be displayed after the next views flip.</returns>
		public virtual android.view.View getNextView()
		{
			int which = mWhichChild == 0 ? 1 : 0;
			return getChildAt(which);
		}

		private android.view.View obtainView()
		{
			android.view.View child = mFactory.makeView();
			android.widget.FrameLayout.LayoutParams lp = (android.widget.FrameLayout.LayoutParams
				)child.getLayoutParams();
			if (lp == null)
			{
				lp = new android.widget.FrameLayout.LayoutParams(android.view.ViewGroup.LayoutParams
					.MATCH_PARENT, android.view.ViewGroup.LayoutParams.WRAP_CONTENT);
			}
			addView(child, lp);
			return child;
		}

		/// <summary>
		/// Sets the factory used to create the two views between which the
		/// ViewSwitcher will flip.
		/// </summary>
		/// <remarks>
		/// Sets the factory used to create the two views between which the
		/// ViewSwitcher will flip. Instead of using a factory, you can call
		/// <see cref="addView(android.view.View, int, android.view.ViewGroup.LayoutParams)">addView(android.view.View, int, android.view.ViewGroup.LayoutParams)
		/// 	</see>
		/// twice.
		/// </remarks>
		/// <param name="factory">the view factory used to generate the switcher's content</param>
		public virtual void setFactory(android.widget.ViewSwitcher.ViewFactory factory)
		{
			mFactory = factory;
			obtainView();
			obtainView();
		}

		/// <summary>
		/// Reset the ViewSwitcher to hide all of the existing views and to make it
		/// think that the first time animation has not yet played.
		/// </summary>
		/// <remarks>
		/// Reset the ViewSwitcher to hide all of the existing views and to make it
		/// think that the first time animation has not yet played.
		/// </remarks>
		public virtual void reset()
		{
			mFirstTime = true;
			android.view.View v;
			v = getChildAt(0);
			if (v != null)
			{
				v.setVisibility(android.view.View.GONE);
			}
			v = getChildAt(1);
			if (v != null)
			{
				v.setVisibility(android.view.View.GONE);
			}
		}

		/// <summary>Creates views in a ViewSwitcher.</summary>
		/// <remarks>Creates views in a ViewSwitcher.</remarks>
		public interface ViewFactory
		{
			/// <summary>
			/// Creates a new
			/// <see cref="android.view.View">android.view.View</see>
			/// to be added in a
			/// <see cref="ViewSwitcher">ViewSwitcher</see>
			/// .
			/// </summary>
			/// <returns>
			/// a
			/// <see cref="android.view.View">android.view.View</see>
			/// </returns>
			android.view.View makeView();
		}
	}
}

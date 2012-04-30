using Sharpen;

namespace android.view
{
	/// <summary>
	/// A ContextWrapper that allows you to modify the theme from what is in the
	/// wrapped context.
	/// </summary>
	/// <remarks>
	/// A ContextWrapper that allows you to modify the theme from what is in the
	/// wrapped context.
	/// </remarks>
	[Sharpen.Sharpened]
	public class ContextThemeWrapper : android.content.ContextWrapper
	{
		private android.content.Context mBase;

		private int mThemeResource;

		private android.content.res.Resources.Theme mTheme;

		private android.view.LayoutInflater mInflater;

		public ContextThemeWrapper() : base(null)
		{
		}

		public ContextThemeWrapper(android.content.Context @base, int themeres) : base(@base
			)
		{
			mBase = @base;
			mThemeResource = themeres;
		}

		[Sharpen.OverridesMethod(@"android.content.ContextWrapper")]
		protected internal override void attachBaseContext(android.content.Context newBase
			)
		{
			base.attachBaseContext(newBase);
			mBase = newBase;
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override void setTheme(int resid)
		{
			mThemeResource = resid;
			initializeTheme();
		}

		/// <hide></hide>
		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override int getThemeResId()
		{
			return mThemeResource;
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override android.content.res.Resources.Theme getTheme()
		{
			if (mTheme != null)
			{
				return mTheme;
			}
			mThemeResource = android.content.res.Resources.selectDefaultTheme(mThemeResource, 
				getApplicationInfo().targetSdkVersion);
			initializeTheme();
			return mTheme;
		}

		[Sharpen.OverridesMethod(@"android.content.Context")]
		public override object getSystemService(string name)
		{
			if (LAYOUT_INFLATER_SERVICE.Equals(name))
			{
				if (mInflater == null)
				{
					mInflater = android.view.LayoutInflater.from(mBase).cloneInContext(this);
				}
				return mInflater;
			}
			return mBase.getSystemService(name);
		}

		/// <summary>
		/// Called by
		/// <see cref="setTheme(int)">setTheme(int)</see>
		/// and
		/// <see cref="getTheme()">getTheme()</see>
		/// to apply a theme
		/// resource to the current Theme object.  Can override to change the
		/// default (simple) behavior.  This method will not be called in multiple
		/// threads simultaneously.
		/// </summary>
		/// <param name="theme">The Theme object being modified.</param>
		/// <param name="resid">The theme style resource being applied to <var>theme</var>.</param>
		/// <param name="first">
		/// Set to true if this is the first time a style is being
		/// applied to <var>theme</var>.
		/// </param>
		protected internal virtual void onApplyThemeResource(android.content.res.Resources
			.Theme theme, int resid, bool first)
		{
			theme.applyStyle(resid, true);
		}

		private void initializeTheme()
		{
			bool first = mTheme == null;
			if (first)
			{
				mTheme = getResources().newTheme();
				android.content.res.Resources.Theme theme = mBase.getTheme();
				if (theme != null)
				{
					mTheme.setTo(theme);
				}
			}
			onApplyThemeResource(mTheme, mThemeResource, first);
		}
	}
}

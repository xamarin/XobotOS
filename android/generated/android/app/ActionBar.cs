using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	public abstract class ActionBar
	{
		public const int NAVIGATION_MODE_STANDARD = 0;

		public const int NAVIGATION_MODE_LIST = 1;

		public const int NAVIGATION_MODE_TABS = 2;

		public const int DISPLAY_USE_LOGO = unchecked((int)(0x1));

		public const int DISPLAY_SHOW_HOME = unchecked((int)(0x2));

		public const int DISPLAY_HOME_AS_UP = unchecked((int)(0x4));

		public const int DISPLAY_SHOW_TITLE = unchecked((int)(0x8));

		public const int DISPLAY_SHOW_CUSTOM = unchecked((int)(0x10));

		[Sharpen.Stub]
		public abstract void setCustomView(android.view.View view);

		[Sharpen.Stub]
		public abstract void setCustomView(android.view.View view, android.app.ActionBar.
			LayoutParams layoutParams);

		[Sharpen.Stub]
		public abstract void setCustomView(int resId);

		[Sharpen.Stub]
		public abstract void setIcon(int resId);

		[Sharpen.Stub]
		public abstract void setIcon(android.graphics.drawable.Drawable icon);

		[Sharpen.Stub]
		public abstract void setLogo(int resId);

		[Sharpen.Stub]
		public abstract void setLogo(android.graphics.drawable.Drawable logo);

		[Sharpen.Stub]
		public abstract void setListNavigationCallbacks(android.widget.SpinnerAdapter adapter
			, android.app.ActionBar.OnNavigationListener callback);

		[Sharpen.Stub]
		public abstract void setSelectedNavigationItem(int position);

		[Sharpen.Stub]
		public abstract int getSelectedNavigationIndex();

		[Sharpen.Stub]
		public abstract int getNavigationItemCount();

		[Sharpen.Stub]
		public abstract void setTitle(java.lang.CharSequence title);

		[Sharpen.Stub]
		public abstract void setTitle(int resId);

		[Sharpen.Stub]
		public abstract void setSubtitle(java.lang.CharSequence subtitle);

		[Sharpen.Stub]
		public abstract void setSubtitle(int resId);

		[Sharpen.Stub]
		public abstract void setDisplayOptions(int options);

		[Sharpen.Stub]
		public abstract void setDisplayOptions(int options, int mask);

		[Sharpen.Stub]
		public abstract void setDisplayUseLogoEnabled(bool useLogo);

		[Sharpen.Stub]
		public abstract void setDisplayShowHomeEnabled(bool showHome);

		[Sharpen.Stub]
		public abstract void setDisplayHomeAsUpEnabled(bool showHomeAsUp);

		[Sharpen.Stub]
		public abstract void setDisplayShowTitleEnabled(bool showTitle);

		[Sharpen.Stub]
		public abstract void setDisplayShowCustomEnabled(bool showCustom);

		[Sharpen.Stub]
		public abstract void setBackgroundDrawable(android.graphics.drawable.Drawable d);

		[Sharpen.Stub]
		public virtual void setStackedBackgroundDrawable(android.graphics.drawable.Drawable
			 d)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setSplitBackgroundDrawable(android.graphics.drawable.Drawable
			 d)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public abstract android.view.View getCustomView();

		[Sharpen.Stub]
		public abstract java.lang.CharSequence getTitle();

		[Sharpen.Stub]
		public abstract java.lang.CharSequence getSubtitle();

		[Sharpen.Stub]
		public abstract int getNavigationMode();

		[Sharpen.Stub]
		public abstract void setNavigationMode(int mode);

		[Sharpen.Stub]
		public abstract int getDisplayOptions();

		[Sharpen.Stub]
		public abstract android.app.ActionBar.Tab newTab();

		[Sharpen.Stub]
		public abstract void addTab(android.app.ActionBar.Tab tab);

		[Sharpen.Stub]
		public abstract void addTab(android.app.ActionBar.Tab tab, bool setSelected);

		[Sharpen.Stub]
		public abstract void addTab(android.app.ActionBar.Tab tab, int position);

		[Sharpen.Stub]
		public abstract void addTab(android.app.ActionBar.Tab tab, int position, bool setSelected
			);

		[Sharpen.Stub]
		public abstract void removeTab(android.app.ActionBar.Tab tab);

		[Sharpen.Stub]
		public abstract void removeTabAt(int position);

		[Sharpen.Stub]
		public abstract void removeAllTabs();

		[Sharpen.Stub]
		public abstract void selectTab(android.app.ActionBar.Tab tab);

		[Sharpen.Stub]
		public abstract android.app.ActionBar.Tab getSelectedTab();

		[Sharpen.Stub]
		public abstract android.app.ActionBar.Tab getTabAt(int index);

		[Sharpen.Stub]
		public abstract int getTabCount();

		[Sharpen.Stub]
		public abstract int getHeight();

		[Sharpen.Stub]
		public abstract void show();

		[Sharpen.Stub]
		public abstract void hide();

		[Sharpen.Stub]
		public abstract bool isShowing();

		[Sharpen.Stub]
		public abstract void addOnMenuVisibilityListener(android.app.ActionBar.OnMenuVisibilityListener
			 listener);

		[Sharpen.Stub]
		public abstract void removeOnMenuVisibilityListener(android.app.ActionBar.OnMenuVisibilityListener
			 listener);

		[Sharpen.Stub]
		public virtual void setHomeButtonEnabled(bool enabled)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.content.Context getThemedContext()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public interface OnNavigationListener
		{
			[Sharpen.Stub]
			bool onNavigationItemSelected(int itemPosition, long itemId);
		}

		[Sharpen.Stub]
		public interface OnMenuVisibilityListener
		{
			[Sharpen.Stub]
			void onMenuVisibilityChanged(bool isVisible);
		}

		[Sharpen.Stub]
		public abstract class Tab
		{
			public const int INVALID_POSITION = -1;

			[Sharpen.Stub]
			public abstract int getPosition();

			[Sharpen.Stub]
			public abstract android.graphics.drawable.Drawable getIcon();

			[Sharpen.Stub]
			public abstract java.lang.CharSequence getText();

			[Sharpen.Stub]
			public abstract android.app.ActionBar.Tab setIcon(android.graphics.drawable.Drawable
				 icon);

			[Sharpen.Stub]
			public abstract android.app.ActionBar.Tab setIcon(int resId);

			[Sharpen.Stub]
			public abstract android.app.ActionBar.Tab setText(java.lang.CharSequence text);

			[Sharpen.Stub]
			public abstract android.app.ActionBar.Tab setText(int resId);

			[Sharpen.Stub]
			public abstract android.app.ActionBar.Tab setCustomView(android.view.View view);

			[Sharpen.Stub]
			public abstract android.app.ActionBar.Tab setCustomView(int layoutResId);

			[Sharpen.Stub]
			public abstract android.view.View getCustomView();

			[Sharpen.Stub]
			public abstract android.app.ActionBar.Tab setTag(object obj);

			[Sharpen.Stub]
			public abstract object getTag();

			[Sharpen.Stub]
			public abstract android.app.ActionBar.Tab setTabListener(android.app.ActionBar.TabListener
				 listener);

			[Sharpen.Stub]
			public abstract void select();

			[Sharpen.Stub]
			public abstract android.app.ActionBar.Tab setContentDescription(int resId);

			[Sharpen.Stub]
			public abstract android.app.ActionBar.Tab setContentDescription(java.lang.CharSequence
				 contentDesc);

			[Sharpen.Stub]
			public abstract java.lang.CharSequence getContentDescription();
		}

		[Sharpen.Stub]
		public interface TabListener
		{
			[Sharpen.Stub]
			void onTabSelected(android.app.ActionBar.Tab tab, android.app.FragmentTransaction
				 ft);

			[Sharpen.Stub]
			void onTabUnselected(android.app.ActionBar.Tab tab, android.app.FragmentTransaction
				 ft);

			[Sharpen.Stub]
			void onTabReselected(android.app.ActionBar.Tab tab, android.app.FragmentTransaction
				 ft);
		}

		[Sharpen.Stub]
		public class LayoutParams : android.view.ViewGroup.MarginLayoutParams
		{
			public int gravity = -1;

			[Sharpen.Stub]
			public LayoutParams(android.content.Context c, android.util.AttributeSet attrs) : 
				base(c, attrs)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public LayoutParams(int width, int height) : base(width, height)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public LayoutParams(int width, int height, int gravity) : base(width, height)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public LayoutParams(int gravity) : this(WRAP_CONTENT, MATCH_PARENT, gravity)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public LayoutParams(android.app.ActionBar.LayoutParams source) : base(source)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public LayoutParams(android.view.ViewGroup.LayoutParams source) : base(source)
			{
				throw new System.NotImplementedException();
			}
		}
	}
}

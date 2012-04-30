using Sharpen;

namespace android.view
{
	[Sharpen.Stub]
	public class MenuInflater
	{
		internal const string LOG_TAG = "MenuInflater";

		internal const string XML_MENU = "menu";

		internal const string XML_GROUP = "group";

		internal const string XML_ITEM = "item";

		internal const int NO_ID = 0;

		private static readonly System.Type[] ACTION_VIEW_CONSTRUCTOR_SIGNATURE = new System.Type
			[] { typeof(android.content.Context) };

		private static readonly System.Type[] ACTION_PROVIDER_CONSTRUCTOR_SIGNATURE = ACTION_VIEW_CONSTRUCTOR_SIGNATURE;

		private readonly object[] mActionViewConstructorArguments;

		private readonly object[] mActionProviderConstructorArguments;

		private android.content.Context mContext;

		[Sharpen.Stub]
		public MenuInflater(android.content.Context context)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void inflate(int menuRes, android.view.Menu menu)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void parseMenu(org.xmlpull.v1.XmlPullParser parser, android.util.AttributeSet
			 attrs, android.view.Menu menu)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private class InflatedOnMenuItemClickListener : android.view.MenuItemClass.OnMenuItemClickListener
		{
			internal static readonly System.Type[] PARAM_TYPES = new System.Type[] { typeof(android.view.MenuItem
				) };

			internal android.content.Context mContext;

			internal System.Reflection.MethodInfo mMethod;

			[Sharpen.Stub]
			public InflatedOnMenuItemClickListener(android.content.Context context, string methodName
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.MenuItem.OnMenuItemClickListener")]
			public virtual bool onMenuItemClick(android.view.MenuItem item)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		private class MenuState
		{
			internal android.view.Menu menu;

			internal int groupId;

			internal int groupCategory;

			internal int groupOrder;

			internal int groupCheckable;

			internal bool groupVisible;

			internal bool groupEnabled;

			internal bool itemAdded;

			internal int itemId;

			internal int itemCategoryOrder;

			internal java.lang.CharSequence itemTitle;

			internal java.lang.CharSequence itemTitleCondensed;

			internal int itemIconResId;

			internal char itemAlphabeticShortcut;

			internal char itemNumericShortcut;

			internal int itemCheckable;

			internal bool itemChecked;

			internal bool itemVisible;

			internal bool itemEnabled;

			internal int itemShowAsAction;

			internal int itemActionViewLayout;

			internal string itemActionViewClassName;

			internal string itemActionProviderClassName;

			internal string itemListenerMethodName;

			internal android.view.ActionProvider itemActionProvider;

			internal const int defaultGroupId = android.view.MenuInflater.NO_ID;

			internal const int defaultItemId = android.view.MenuInflater.NO_ID;

			internal const int defaultItemCategory = 0;

			internal const int defaultItemOrder = 0;

			internal const int defaultItemCheckable = 0;

			internal const bool defaultItemChecked = false;

			internal const bool defaultItemVisible = true;

			internal const bool defaultItemEnabled = true;

			[Sharpen.Stub]
			public MenuState(MenuInflater _enclosing, android.view.Menu menu)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void resetGroup()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void readGroup(android.util.AttributeSet attrs)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void readItem(android.util.AttributeSet attrs)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal char getShortcut(string shortcutString)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal void setItem(android.view.MenuItem item)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void addItem()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.view.SubMenu addSubMenuItem()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual bool hasAddedItem()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal T newInstance<T>(string className, System.Type[] constructorSignature, object
				[] arguments)
			{
				throw new System.NotImplementedException();
			}

			private readonly MenuInflater _enclosing;
		}
	}
}

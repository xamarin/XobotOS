using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	public abstract class LauncherActivity : android.app.ListActivity
	{
		internal android.content.Intent mIntent;

		internal android.content.pm.PackageManager mPackageManager;

		internal android.app.LauncherActivity.IconResizer mIconResizer;

		[Sharpen.Stub]
		public class ListItem
		{
			public android.content.pm.ResolveInfo resolveInfo;

			public java.lang.CharSequence label;

			public android.graphics.drawable.Drawable icon;

			public string packageName;

			public string className;

			public android.os.Bundle extras;

			[Sharpen.Stub]
			internal ListItem(android.content.pm.PackageManager pm, android.content.pm.ResolveInfo
				 resolveInfo, android.app.LauncherActivity.IconResizer resizer)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public ListItem()
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		private class ActivityAdapter : android.widget.BaseAdapter, android.widget.Filterable
		{
			internal readonly object @lock;

			internal java.util.ArrayList<android.app.LauncherActivity.ListItem> mOriginalValues;

			protected internal readonly android.app.LauncherActivity.IconResizer mIconResizer;

			protected internal readonly android.view.LayoutInflater mInflater;

			protected internal java.util.List<android.app.LauncherActivity.ListItem> mActivitiesList;

			internal android.widget.Filter mFilter;

			internal readonly bool mShowIcons;

			[Sharpen.Stub]
			public ActivityAdapter(LauncherActivity _enclosing, android.app.LauncherActivity.
				IconResizer resizer)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.content.Intent intentForPosition(int position)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.app.LauncherActivity.ListItem itemForPosition(int position
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
			public override int getCount()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
			public override object getItem(int position)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
			public override long getItemId(int position)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
			public override android.view.View getView(int position, android.view.View convertView
				, android.view.ViewGroup parent)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal void bindView(android.view.View view, android.app.LauncherActivity.ListItem
				 item)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.widget.Filterable")]
			public virtual android.widget.Filter getFilter()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal class ArrayFilter : android.widget.Filter
			{
				[Sharpen.Stub]
				[Sharpen.OverridesMethod(@"android.widget.Filter")]
				internal override android.widget.Filter.FilterResults performFiltering(java.lang.CharSequence
					 prefix)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.OverridesMethod(@"android.widget.Filter")]
				internal override void publishResults(java.lang.CharSequence constraint, android.widget.Filter
					.FilterResults results)
				{
					throw new System.NotImplementedException();
				}

				internal ArrayFilter(ActivityAdapter _enclosing)
				{
					this._enclosing = _enclosing;
				}

				private readonly ActivityAdapter _enclosing;
			}

			private readonly LauncherActivity _enclosing;
		}

		[Sharpen.Stub]
		public class IconResizer
		{
			private int mIconWidth;

			private int mIconHeight;

			private readonly android.graphics.Rect mOldBounds;

			private android.graphics.Canvas mCanvas;

			[Sharpen.Stub]
			public IconResizer(LauncherActivity _enclosing)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual android.graphics.drawable.Drawable createIconThumbnail(android.graphics.drawable.Drawable
				 icon)
			{
				throw new System.NotImplementedException();
			}

			private readonly LauncherActivity _enclosing;
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Activity")]
		protected internal override void onCreate(android.os.Bundle icicle)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void updateAlertTitle()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void updateButtonText()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Activity")]
		public override void setTitle(java.lang.CharSequence title)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Activity")]
		public override void setTitle(int titleId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual void onSetContentView()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.ListActivity")]
		protected internal override void onListItemClick(android.widget.ListView l, android.view.View
			 v, int position, long id)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual android.content.Intent intentForPosition(int position)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual android.app.LauncherActivity.ListItem itemForPosition(
			int position)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual android.content.Intent getTargetIntent()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual java.util.List<android.content.pm.ResolveInfo> onQueryPackageManager
			(android.content.Intent queryIntent)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual java.util.List<android.app.LauncherActivity.ListItem> makeListItems
			()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual bool onEvaluateShowIcons()
		{
			throw new System.NotImplementedException();
		}
	}
}

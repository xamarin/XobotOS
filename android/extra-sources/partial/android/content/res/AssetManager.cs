using System;
using System.Reflection;

namespace android.content.res
{
	partial class AssetManager
	{
		public AssetManager ()
		{
			lock (this) {
				mObject = init ();
				addAssetPath(Assembly.GetExecutingAssembly ().Location);
				ensureSystemAssets ();
			}
		}

		private AssetManager (bool isSystem)
		{
			mObject = init ();
			addAssetPath(Assembly.GetExecutingAssembly ().Location);
		}

		internal Resources.Theme.NativeTheme createTheme ()
		{
			lock (this) {
				if (!mOpen) {
					throw new java.lang.RuntimeException ("Assetmanager has been closed");
				}
				Resources.Theme.NativeTheme res = newTheme ();
				incRefsLocked ();
				return res;
			}
		}

		private void incRefsLocked ()
		{
			mNumRefs++;
		}

		private void incRefsLocked (int id)
		{
			mNumRefs++;
		}

		private void decRefsLocked (int id)
		{
			mNumRefs--;
		}

		partial class AssetInputStream
		{
			[Sharpen.OverridesMethod(@"java.io.InputStream")]
			public sealed override void close ()
			{
				lock (this._enclosing) {
					if (this.mAsset != null) {
						this.mAsset.Dispose ();
						this.mAsset = null;
						this._enclosing.decRefsLocked (this.GetHashCode ());
					}
				}
			}
		}
	}
}


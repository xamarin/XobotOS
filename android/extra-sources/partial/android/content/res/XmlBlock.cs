using Sharpen;
using System;

namespace android.content.res
{
	partial class XmlBlock
	{
		private void decOpenCountLocked ()
		{
			mOpenCount--;
			if (mOpenCount == 0) {
				mNative.Dispose ();
				if (mAssets != null) {
					mAssets.xmlBlockGone (GetHashCode ());
				}
			}
		}

		partial class Parser
		{
			[Sharpen.ImplementsInterface(@"android.content.res.XmlResourceParser")]
			public void close ()
			{
				lock (this.mBlock) {
					if (this.mParseState != null) {
						this.mParseState.Dispose ();
						this.mParseState = null;
						this.mBlock.decOpenCountLocked ();
					}
				}
			}
		}
	}
}


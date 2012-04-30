using Sharpen;

namespace android.content
{
	[Sharpen.Stub]
	public class ClipboardManager : android.text.ClipboardManager
	{
		private static readonly object sStaticLock = new object();

		private static android.content.IClipboard sService;

		private readonly android.content.Context mContext;

		private readonly java.util.ArrayList<android.content.ClipboardManager.OnPrimaryClipChangedListener
			> mPrimaryClipChangedListeners = new java.util.ArrayList<android.content.ClipboardManager
			.OnPrimaryClipChangedListener>();

		private sealed class _Stub_55 : android.content.IOnPrimaryClipChangedListenerClass
			.Stub
		{
			public _Stub_55()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.content.IOnPrimaryClipChangedListener")]
			public override void dispatchPrimaryClipChanged()
			{
				throw new System.NotImplementedException();
			}
		}

		private readonly android.content.IOnPrimaryClipChangedListenerClass.Stub mPrimaryClipChangedServiceListener
			 = new _Stub_55();

		internal const int MSG_REPORT_PRIMARY_CLIP_CHANGED = 1;

		private sealed class _Handler_63 : android.os.Handler
		{
			public _Handler_63()
			{
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.os.Handler")]
			public override void handleMessage(android.os.Message msg)
			{
				throw new System.NotImplementedException();
			}
		}

		private readonly android.os.Handler mHandler = new _Handler_63();

		[Sharpen.Stub]
		public interface OnPrimaryClipChangedListener
		{
			[Sharpen.Stub]
			void onPrimaryClipChanged();
		}

		[Sharpen.Stub]
		private static android.content.IClipboard getService()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public ClipboardManager(android.content.Context context, android.os.Handler handler
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setPrimaryClip(android.content.ClipData clip)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.content.ClipData getPrimaryClip()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.content.ClipDescription getPrimaryClipDescription()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool hasPrimaryClip()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void addPrimaryClipChangedListener(android.content.ClipboardManager
			.OnPrimaryClipChangedListener what)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void removePrimaryClipChangedListener(android.content.ClipboardManager
			.OnPrimaryClipChangedListener what)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"Use getPrimaryClip() instead.  This retrieves the primary clip and tries to coerce it to a string."
			)]
		[Sharpen.OverridesMethod(@"android.text.ClipboardManager")]
		public override java.lang.CharSequence getText()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"Use setPrimaryClip(ClipData) instead.  This creates a ClippedItem holding the given text and sets it as the primary clip.  It has no label or icon."
			)]
		[Sharpen.OverridesMethod(@"android.text.ClipboardManager")]
		public override void setText(java.lang.CharSequence text)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"Use hasPrimaryClip() instead.")]
		[Sharpen.OverridesMethod(@"android.text.ClipboardManager")]
		public override bool hasText()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void reportPrimaryClipChanged()
		{
			throw new System.NotImplementedException();
		}
	}
}

using System;

namespace android.os
{
	partial class StrictMode
	{
		public static void incrementExpectedActivityCount (Type klass)
		{
			; // Do nothing
		}

		public static void decrementExpectedActivityCount (Type klass)
		{
			; // Do nothing
		}

		/// <summary>Enter a named critical span (e.g.</summary>
		/// <remarks>
		/// Enter a named critical span (e.g. an animation)
		/// <p>The name is an arbitary label (or tag) that will be applied
		/// to any strictmode violation that happens while this span is
		/// active.  You must call finish() on the span when done.
		/// <p>This will never return null, but on devices without debugging
		/// enabled, this may return a dummy object on which the finish()
		/// method is a no-op.
		/// <p>TODO: add CloseGuard to this, verifying callers call finish.
		/// </remarks>
		/// <hide></hide>
		public static Span enterCriticalSpan (string name)
		{
			return NO_OP_SPAN;
		}

		private sealed class _NO_OP_SPAN : Span
		{
			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.os.StrictMode.Span")]
			public override void finish ()
			{
				; // Do nothing
			}
		}

		private static readonly Span NO_OP_SPAN = new _NO_OP_SPAN ();

	}
}
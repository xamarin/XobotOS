using Sharpen;

namespace android.widget.@internal.multiwaveview
{
	[Sharpen.Stub]
	internal class Tweener
	{
		internal const string TAG = "Tweener";

		internal const bool DEBUG = false;

		internal android.animation.ObjectAnimator animator;

		private static java.util.HashMap<object, android.widget.@internal.multiwaveview.Tweener
			> sTweens = new java.util.HashMap<object, android.widget.@internal.multiwaveview.Tweener
			>();

		[Sharpen.Stub]
		public Tweener(android.animation.ObjectAnimator anim)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void remove(android.animation.Animator animator)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal static android.widget.@internal.multiwaveview.Tweener to(object @object, 
			long duration, params object[] vars)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual android.widget.@internal.multiwaveview.Tweener from(object @object
			, long duration, params object[] vars)
		{
			throw new System.NotImplementedException();
		}

		private sealed class _AnimatorListenerAdapter_138 : android.animation.AnimatorListenerAdapter
		{
			public _AnimatorListenerAdapter_138()
			{
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.animation.AnimatorListenerAdapter")]
			public override void onAnimationEnd(android.animation.Animator animation)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.animation.AnimatorListenerAdapter")]
			public override void onAnimationCancel(android.animation.Animator animation)
			{
				throw new System.NotImplementedException();
			}
		}

		private static android.animation.Animator.AnimatorListener mCleanupListener = new 
			_AnimatorListenerAdapter_138();

		[Sharpen.Stub]
		public static void reset()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void replace(java.util.ArrayList<android.animation.PropertyValuesHolder
			> props, params object[] args)
		{
			throw new System.NotImplementedException();
		}
	}
}

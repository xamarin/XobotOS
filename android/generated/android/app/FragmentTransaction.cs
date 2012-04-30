using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	public abstract class FragmentTransaction
	{
		[Sharpen.Stub]
		public abstract android.app.FragmentTransaction add(android.app.Fragment fragment
			, string tag);

		[Sharpen.Stub]
		public abstract android.app.FragmentTransaction add(int containerViewId, android.app.Fragment
			 fragment);

		[Sharpen.Stub]
		public abstract android.app.FragmentTransaction add(int containerViewId, android.app.Fragment
			 fragment, string tag);

		[Sharpen.Stub]
		public abstract android.app.FragmentTransaction replace(int containerViewId, android.app.Fragment
			 fragment);

		[Sharpen.Stub]
		public abstract android.app.FragmentTransaction replace(int containerViewId, android.app.Fragment
			 fragment, string tag);

		[Sharpen.Stub]
		public abstract android.app.FragmentTransaction remove(android.app.Fragment fragment
			);

		[Sharpen.Stub]
		public abstract android.app.FragmentTransaction hide(android.app.Fragment fragment
			);

		[Sharpen.Stub]
		public abstract android.app.FragmentTransaction show(android.app.Fragment fragment
			);

		[Sharpen.Stub]
		public abstract android.app.FragmentTransaction detach(android.app.Fragment fragment
			);

		[Sharpen.Stub]
		public abstract android.app.FragmentTransaction attach(android.app.Fragment fragment
			);

		[Sharpen.Stub]
		public abstract bool isEmpty();

		public const int TRANSIT_ENTER_MASK = unchecked((int)(0x1000));

		public const int TRANSIT_EXIT_MASK = unchecked((int)(0x2000));

		public const int TRANSIT_UNSET = -1;

		public const int TRANSIT_NONE = 0;

		public const int TRANSIT_FRAGMENT_OPEN = 1 | TRANSIT_ENTER_MASK;

		public const int TRANSIT_FRAGMENT_CLOSE = 2 | TRANSIT_EXIT_MASK;

		public const int TRANSIT_FRAGMENT_FADE = 3 | TRANSIT_ENTER_MASK;

		[Sharpen.Stub]
		public abstract android.app.FragmentTransaction setCustomAnimations(int enter, int
			 exit);

		[Sharpen.Stub]
		public abstract android.app.FragmentTransaction setCustomAnimations(int enter, int
			 exit, int popEnter, int popExit);

		[Sharpen.Stub]
		public abstract android.app.FragmentTransaction setTransition(int transit);

		[Sharpen.Stub]
		public abstract android.app.FragmentTransaction setTransitionStyle(int styleRes);

		[Sharpen.Stub]
		public abstract android.app.FragmentTransaction addToBackStack(string name);

		[Sharpen.Stub]
		public abstract bool isAddToBackStackAllowed();

		[Sharpen.Stub]
		public abstract android.app.FragmentTransaction disallowAddToBackStack();

		[Sharpen.Stub]
		public abstract android.app.FragmentTransaction setBreadCrumbTitle(int res);

		[Sharpen.Stub]
		public abstract android.app.FragmentTransaction setBreadCrumbTitle(java.lang.CharSequence
			 text);

		[Sharpen.Stub]
		public abstract android.app.FragmentTransaction setBreadCrumbShortTitle(int res);

		[Sharpen.Stub]
		public abstract android.app.FragmentTransaction setBreadCrumbShortTitle(java.lang.CharSequence
			 text);

		[Sharpen.Stub]
		public abstract int commit();

		[Sharpen.Stub]
		public abstract int commitAllowingStateLoss();
	}
}

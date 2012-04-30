using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	internal sealed class BackStackState : android.os.Parcelable
	{
		internal readonly int[] mOps;

		internal readonly int mTransition;

		internal readonly int mTransitionStyle;

		internal readonly string mName;

		internal readonly int mIndex;

		internal readonly int mBreadCrumbTitleRes;

		internal readonly java.lang.CharSequence mBreadCrumbTitleText;

		internal readonly int mBreadCrumbShortTitleRes;

		internal readonly java.lang.CharSequence mBreadCrumbShortTitleText;

		[Sharpen.Stub]
		internal BackStackState(android.app.FragmentManagerImpl fm, android.app.BackStackRecord
			 bse)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public BackStackState(android.os.Parcel @in)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal android.app.BackStackRecord instantiate(android.app.FragmentManagerImpl 
			fm)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public int describeContents()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public void writeToParcel(android.os.Parcel dest, int flags)
		{
			throw new System.NotImplementedException();
		}

		private sealed class _Creator_150 : android.os.ParcelableClass.Creator<android.app.BackStackState
			>
		{
			public _Creator_150()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.app.BackStackState createFromParcel(android.os.Parcel @in)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.app.BackStackState[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		internal static readonly android.os.ParcelableClass.Creator<android.app.BackStackState
			> CREATOR = new _Creator_150();
	}

	[Sharpen.Stub]
	internal sealed class BackStackRecord : android.app.FragmentTransaction, android.app.FragmentManager
		.BackStackEntry, java.lang.Runnable
	{
		internal const string TAG = "BackStackEntry";

		internal readonly android.app.FragmentManagerImpl mManager;

		internal const int OP_NULL = 0;

		internal const int OP_ADD = 1;

		internal const int OP_REPLACE = 2;

		internal const int OP_REMOVE = 3;

		internal const int OP_HIDE = 4;

		internal const int OP_SHOW = 5;

		internal const int OP_DETACH = 6;

		internal const int OP_ATTACH = 7;

		[Sharpen.Stub]
		internal sealed class Op
		{
			internal android.app.BackStackRecord.Op next;

			internal android.app.BackStackRecord.Op prev;

			internal int cmd;

			internal android.app.Fragment fragment;

			internal int enterAnim;

			internal int exitAnim;

			internal int popEnterAnim;

			internal int popExitAnim;

			internal java.util.ArrayList<android.app.Fragment> removed;
		}

		internal android.app.BackStackRecord.Op mHead;

		internal android.app.BackStackRecord.Op mTail;

		internal int mNumOp;

		internal int mEnterAnim;

		internal int mExitAnim;

		internal int mPopEnterAnim;

		internal int mPopExitAnim;

		internal int mTransition;

		internal int mTransitionStyle;

		internal bool mAddToBackStack;

		internal bool mAllowAddToBackStack = true;

		internal string mName;

		internal bool mCommitted;

		internal int mIndex;

		internal int mBreadCrumbTitleRes;

		internal java.lang.CharSequence mBreadCrumbTitleText;

		internal int mBreadCrumbShortTitleRes;

		internal java.lang.CharSequence mBreadCrumbShortTitleText;

		[Sharpen.Stub]
		public void dump(string prefix, java.io.FileDescriptor fd, java.io.PrintWriter writer
			, string[] args)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal BackStackRecord(android.app.FragmentManagerImpl manager)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.FragmentManager.BackStackEntry")]
		public int getId()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.FragmentManager.BackStackEntry")]
		public int getBreadCrumbTitleRes()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.FragmentManager.BackStackEntry")]
		public int getBreadCrumbShortTitleRes()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.FragmentManager.BackStackEntry")]
		public java.lang.CharSequence getBreadCrumbTitle()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.FragmentManager.BackStackEntry")]
		public java.lang.CharSequence getBreadCrumbShortTitle()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal void addOp(android.app.BackStackRecord.Op op)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.FragmentTransaction")]
		public override android.app.FragmentTransaction add(android.app.Fragment fragment
			, string tag)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.FragmentTransaction")]
		public override android.app.FragmentTransaction add(int containerViewId, android.app.Fragment
			 fragment)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.FragmentTransaction")]
		public override android.app.FragmentTransaction add(int containerViewId, android.app.Fragment
			 fragment, string tag)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void doAddOp(int containerViewId, android.app.Fragment fragment, string tag
			, int opcmd)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.FragmentTransaction")]
		public override android.app.FragmentTransaction replace(int containerViewId, android.app.Fragment
			 fragment)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.FragmentTransaction")]
		public override android.app.FragmentTransaction replace(int containerViewId, android.app.Fragment
			 fragment, string tag)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.FragmentTransaction")]
		public override android.app.FragmentTransaction remove(android.app.Fragment fragment
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.FragmentTransaction")]
		public override android.app.FragmentTransaction hide(android.app.Fragment fragment
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.FragmentTransaction")]
		public override android.app.FragmentTransaction show(android.app.Fragment fragment
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.FragmentTransaction")]
		public override android.app.FragmentTransaction detach(android.app.Fragment fragment
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.FragmentTransaction")]
		public override android.app.FragmentTransaction attach(android.app.Fragment fragment
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.FragmentTransaction")]
		public override android.app.FragmentTransaction setCustomAnimations(int enter, int
			 exit)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.FragmentTransaction")]
		public override android.app.FragmentTransaction setCustomAnimations(int enter, int
			 exit, int popEnter, int popExit)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.FragmentTransaction")]
		public override android.app.FragmentTransaction setTransition(int transition)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.FragmentTransaction")]
		public override android.app.FragmentTransaction setTransitionStyle(int styleRes)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.FragmentTransaction")]
		public override android.app.FragmentTransaction addToBackStack(string name)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.FragmentTransaction")]
		public override bool isAddToBackStackAllowed()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.FragmentTransaction")]
		public override android.app.FragmentTransaction disallowAddToBackStack()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.FragmentTransaction")]
		public override android.app.FragmentTransaction setBreadCrumbTitle(int res)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.FragmentTransaction")]
		public override android.app.FragmentTransaction setBreadCrumbTitle(java.lang.CharSequence
			 text)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.FragmentTransaction")]
		public override android.app.FragmentTransaction setBreadCrumbShortTitle(int res)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.FragmentTransaction")]
		public override android.app.FragmentTransaction setBreadCrumbShortTitle(java.lang.CharSequence
			 text)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal void bumpBackStackNesting(int amt)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.FragmentTransaction")]
		public override int commit()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.FragmentTransaction")]
		public override int commitAllowingStateLoss()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal int commitInternal(bool allowStateLoss)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
		public void run()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void popFromBackStack(bool doStateMove)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.FragmentManager.BackStackEntry")]
		public string getName()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int getTransition()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int getTransitionStyle()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.FragmentTransaction")]
		public override bool isEmpty()
		{
			throw new System.NotImplementedException();
		}
	}
}

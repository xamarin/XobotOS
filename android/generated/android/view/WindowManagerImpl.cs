using Sharpen;

namespace android.view
{
	[System.Serializable]
	[Sharpen.Sharpened]
	internal sealed class WindowLeaked : android.util.AndroidRuntimeException
	{
		public WindowLeaked(string msg) : base(msg)
		{
		}
	}

	/// <summary>Low-level communication with the global system window manager.</summary>
	/// <remarks>
	/// Low-level communication with the global system window manager.  It implements
	/// the ViewManager interface, allowing you to add any View subclass as a
	/// top-level window on the screen. Additional window manager specific layout
	/// parameters are defined for control over how windows are displayed.
	/// It also implemens the WindowManager interface, allowing you to control the
	/// displays attached to the device.
	/// <p>Applications will not normally use WindowManager directly, instead relying
	/// on the higher-level facilities in
	/// <see cref="android.app.Activity">android.app.Activity</see>
	/// and
	/// <see cref="android.app.Dialog">android.app.Dialog</see>
	/// .
	/// <p>Even for low-level window manager access, it is almost never correct to use
	/// this class.  For example,
	/// <see cref="android.app.Activity.getWindowManager()">android.app.Activity.getWindowManager()
	/// 	</see>
	/// provides a ViewManager for adding windows that are associated with that
	/// activity -- the window manager will not normally allow you to add arbitrary
	/// windows that are not associated with an activity.
	/// </remarks>
	/// <hide></hide>
	[Sharpen.Sharpened]
	public class WindowManagerImpl : android.view.WindowManager
	{
		/// <summary>
		/// The user is navigating with keys (not the touch screen), so
		/// navigational focus should be shown.
		/// </summary>
		/// <remarks>
		/// The user is navigating with keys (not the touch screen), so
		/// navigational focus should be shown.
		/// </remarks>
		public const int RELAYOUT_IN_TOUCH_MODE = unchecked((int)(0x1));

		/// <summary>
		/// This is the first time the window is being drawn,
		/// so the client must call drawingFinished() when done
		/// </summary>
		public const int RELAYOUT_FIRST_TIME = unchecked((int)(0x2));

		public const int ADD_FLAG_APP_VISIBLE = unchecked((int)(0x2));

		public const int ADD_FLAG_IN_TOUCH_MODE = RELAYOUT_IN_TOUCH_MODE;

		public const int ADD_OKAY = 0;

		public const int ADD_BAD_APP_TOKEN = -1;

		public const int ADD_BAD_SUBWINDOW_TOKEN = -2;

		public const int ADD_NOT_APP_TOKEN = -3;

		public const int ADD_APP_EXITING = -4;

		public const int ADD_DUPLICATE_ADD = -5;

		public const int ADD_STARTING_NOT_NEEDED = -6;

		public const int ADD_MULTIPLE_SINGLETON = -7;

		public const int ADD_PERMISSION_DENIED = -8;

		private android.view.View[] mViews;

		private android.view.ViewRootImpl[] mRoots;

		private android.view.WindowManagerClass.LayoutParams[] mParams;

		private static readonly object sLock = new object();

		private static readonly android.view.WindowManagerImpl sWindowManager = new android.view.WindowManagerImpl
			();

		private static readonly java.util.HashMap<android.content.res.CompatibilityInfo, 
			android.view.WindowManager> sCompatWindowManagers = new java.util.HashMap<android.content.res.CompatibilityInfo
			, android.view.WindowManager>();

		internal class CompatModeWrapper : android.view.WindowManager
		{
			private readonly android.view.WindowManagerImpl mWindowManager;

			private readonly android.view.Display mDefaultDisplay;

			private readonly android.view.CompatibilityInfoHolder mCompatibilityInfo;

			internal CompatModeWrapper(android.view.WindowManager wm, android.view.CompatibilityInfoHolder
				 ci)
			{
				mWindowManager = wm is android.view.WindowManagerImpl.CompatModeWrapper ? ((android.view.WindowManagerImpl
					.CompatModeWrapper)wm).mWindowManager : (android.view.WindowManagerImpl)wm;
				// Use the original display if there is no compatibility mode
				// to apply, or the underlying window manager is already a
				// compatibility mode wrapper.  (We assume that if it is a
				// wrapper, it is applying the same compatibility mode.)
				if (ci == null)
				{
					mDefaultDisplay = mWindowManager.getDefaultDisplay();
				}
				else
				{
					//mDefaultDisplay = mWindowManager.getDefaultDisplay();
					mDefaultDisplay = android.view.Display.createCompatibleDisplay(mWindowManager.getDefaultDisplay
						().getDisplayId(), ci);
				}
				mCompatibilityInfo = ci;
			}

			[Sharpen.ImplementsInterface(@"android.view.ViewManager")]
			public virtual void addView(android.view.View view, android.view.ViewGroup.LayoutParams
				 @params)
			{
				mWindowManager.addView(view, @params, mCompatibilityInfo);
			}

			[Sharpen.ImplementsInterface(@"android.view.ViewManager")]
			public virtual void updateViewLayout(android.view.View view, android.view.ViewGroup
				.LayoutParams @params)
			{
				mWindowManager.updateViewLayout(view, @params);
			}

			[Sharpen.ImplementsInterface(@"android.view.ViewManager")]
			public virtual void removeView(android.view.View view)
			{
				mWindowManager.removeView(view);
			}

			[Sharpen.ImplementsInterface(@"android.view.WindowManager")]
			public virtual android.view.Display getDefaultDisplay()
			{
				return mDefaultDisplay;
			}

			[Sharpen.ImplementsInterface(@"android.view.WindowManager")]
			public virtual void removeViewImmediate(android.view.View view)
			{
				mWindowManager.removeViewImmediate(view);
			}

			[Sharpen.ImplementsInterface(@"android.view.WindowManager")]
			public virtual bool isHardwareAccelerated()
			{
				return mWindowManager.isHardwareAccelerated();
			}
		}

		public static android.view.WindowManagerImpl getDefault()
		{
			return sWindowManager;
		}

		public static android.view.WindowManager getDefault(android.content.res.CompatibilityInfo
			 compatInfo)
		{
			android.view.CompatibilityInfoHolder cih = new android.view.CompatibilityInfoHolder
				();
			cih.set(compatInfo);
			if (cih.getIfNeeded() == null)
			{
				return sWindowManager;
			}
			lock (sLock)
			{
				// NOTE: It would be cleaner to move the implementation of
				// WindowManagerImpl into a static inner class, and have this
				// public impl just call into that.  Then we can make multiple
				// instances of WindowManagerImpl for compat mode rather than
				// having to make wrappers.
				android.view.WindowManager wm = sCompatWindowManagers.get(compatInfo);
				if (wm == null)
				{
					wm = new android.view.WindowManagerImpl.CompatModeWrapper(sWindowManager, cih);
					sCompatWindowManagers.put(compatInfo, wm);
				}
				return wm;
			}
		}

		public static android.view.WindowManager getDefault(android.view.CompatibilityInfoHolder
			 compatInfo)
		{
			return new android.view.WindowManagerImpl.CompatModeWrapper(sWindowManager, compatInfo
				);
		}

		[Sharpen.ImplementsInterface(@"android.view.WindowManager")]
		public virtual bool isHardwareAccelerated()
		{
			return false;
		}

		public virtual void addView(android.view.View view)
		{
			addView(view, new android.view.WindowManagerClass.LayoutParams(android.view.WindowManagerClass
				.LayoutParams.TYPE_APPLICATION, 0, android.graphics.PixelFormat.OPAQUE));
		}

		[Sharpen.ImplementsInterface(@"android.view.ViewManager")]
		public virtual void addView(android.view.View view, android.view.ViewGroup.LayoutParams
			 @params)
		{
			addView(view, @params, null, false);
		}

		public virtual void addView(android.view.View view, android.view.ViewGroup.LayoutParams
			 @params, android.view.CompatibilityInfoHolder cih)
		{
			addView(view, @params, cih, false);
		}

		private void addView(android.view.View view, android.view.ViewGroup.LayoutParams 
			@params, android.view.CompatibilityInfoHolder cih, bool nest)
		{
			if (false)
			{
				android.util.Log.v("WindowManager", "addView view=" + view);
			}
			if (!(@params is android.view.WindowManagerClass.LayoutParams))
			{
				throw new System.ArgumentException("Params must be WindowManager.LayoutParams");
			}
			android.view.WindowManagerClass.LayoutParams wparams = (android.view.WindowManagerClass
				.LayoutParams)@params;
			android.view.ViewRootImpl root;
			android.view.View panelParentView = null;
			lock (this)
			{
				// Here's an odd/questionable case: if someone tries to add a
				// view multiple times, then we simply bump up a nesting count
				// and they need to remove the view the corresponding number of
				// times to have it actually removed from the window manager.
				// This is useful specifically for the notification manager,
				// which can continually add/remove the same view as a
				// notification gets updated.
				int index = findViewLocked(view, false);
				if (index >= 0)
				{
					if (!nest)
					{
						throw new System.InvalidOperationException("View " + view + " has already been added to the window manager."
							);
					}
					root = mRoots[index];
					root.mAddNesting++;
					// Update layout parameters.
					view.setLayoutParams(wparams);
					root.setLayoutParams(wparams, true);
					return;
				}
				// If this is a panel window, then find the window it is being
				// attached to for future reference.
				if (wparams.type >= android.view.WindowManagerClass.LayoutParams.FIRST_SUB_WINDOW
					 && wparams.type <= android.view.WindowManagerClass.LayoutParams.LAST_SUB_WINDOW)
				{
					int count = mViews != null ? mViews.Length : 0;
					{
						for (int i = 0; i < count; i++)
						{
							if (mRoots[i].mWindow.asBinder() == wparams.token)
							{
								panelParentView = mViews[i];
							}
						}
					}
				}
				root = new android.view.ViewRootImpl(view.getContext());
				root.mAddNesting = 1;
				if (cih == null)
				{
					root.mCompatibilityInfo = new android.view.CompatibilityInfoHolder();
				}
				else
				{
					root.mCompatibilityInfo = cih;
				}
				view.setLayoutParams(wparams);
				if (mViews == null)
				{
					index = 1;
					mViews = new android.view.View[1];
					mRoots = new android.view.ViewRootImpl[1];
					mParams = new android.view.WindowManagerClass.LayoutParams[1];
				}
				else
				{
					index = mViews.Length + 1;
					object[] old = mViews;
					mViews = new android.view.View[index];
					System.Array.Copy(old, 0, mViews, 0, index - 1);
					old = mRoots;
					mRoots = new android.view.ViewRootImpl[index];
					System.Array.Copy(old, 0, mRoots, 0, index - 1);
					old = mParams;
					mParams = new android.view.WindowManagerClass.LayoutParams[index];
					System.Array.Copy(old, 0, mParams, 0, index - 1);
				}
				index--;
				mViews[index] = view;
				mRoots[index] = root;
				mParams[index] = wparams;
			}
			// do this last because it fires off messages to start doing things
			root.setView(view, wparams, panelParentView);
		}

		[Sharpen.ImplementsInterface(@"android.view.ViewManager")]
		public virtual void updateViewLayout(android.view.View view, android.view.ViewGroup
			.LayoutParams @params)
		{
			if (!(@params is android.view.WindowManagerClass.LayoutParams))
			{
				throw new System.ArgumentException("Params must be WindowManager.LayoutParams");
			}
			android.view.WindowManagerClass.LayoutParams wparams = (android.view.WindowManagerClass
				.LayoutParams)@params;
			view.setLayoutParams(wparams);
			lock (this)
			{
				int index = findViewLocked(view, true);
				android.view.ViewRootImpl root = mRoots[index];
				mParams[index] = wparams;
				root.setLayoutParams(wparams, false);
			}
		}

		[Sharpen.ImplementsInterface(@"android.view.ViewManager")]
		public virtual void removeView(android.view.View view)
		{
			lock (this)
			{
				int index = findViewLocked(view, true);
				android.view.View curView = removeViewLocked(index);
				if (curView == view)
				{
					return;
				}
				throw new System.InvalidOperationException("Calling with view " + view + " but the ViewAncestor is attached to "
					 + curView);
			}
		}

		[Sharpen.ImplementsInterface(@"android.view.WindowManager")]
		public virtual void removeViewImmediate(android.view.View view)
		{
			lock (this)
			{
				int index = findViewLocked(view, true);
				android.view.ViewRootImpl root = mRoots[index];
				android.view.View curView = root.getView();
				root.mAddNesting = 0;
				root.die(true);
				finishRemoveViewLocked(curView, index);
				if (curView == view)
				{
					return;
				}
				throw new System.InvalidOperationException("Calling with view " + view + " but the ViewAncestor is attached to "
					 + curView);
			}
		}

		internal virtual android.view.View removeViewLocked(int index)
		{
			android.view.ViewRootImpl root = mRoots[index];
			android.view.View view = root.getView();
			// Don't really remove until we have matched all calls to add().
			root.mAddNesting--;
			if (root.mAddNesting > 0)
			{
				return view;
			}
			if (view != null)
			{
				android.view.inputmethod.InputMethodManager imm = android.view.inputmethod.InputMethodManager
					.getInstance(view.getContext());
				if (imm != null)
				{
					imm.windowDismissed(mViews[index].getWindowToken());
				}
			}
			root.die(false);
			finishRemoveViewLocked(view, index);
			return view;
		}

		internal virtual void finishRemoveViewLocked(android.view.View view, int index)
		{
			int count = mViews.Length;
			// remove it from the list
			android.view.View[] tmpViews = new android.view.View[count - 1];
			removeItem(tmpViews, mViews, index);
			mViews = tmpViews;
			android.view.ViewRootImpl[] tmpRoots = new android.view.ViewRootImpl[count - 1];
			removeItem(tmpRoots, mRoots, index);
			mRoots = tmpRoots;
			android.view.WindowManagerClass.LayoutParams[] tmpParams = new android.view.WindowManagerClass
				.LayoutParams[count - 1];
			removeItem(tmpParams, mParams, index);
			mParams = tmpParams;
			if (view != null)
			{
				view.assignParent(null);
			}
		}

		// func doesn't allow null...  does it matter if we clear them?
		//view.setLayoutParams(null);
		public virtual void closeAll(android.os.IBinder token, string who, string what)
		{
			lock (this)
			{
				if (mViews == null)
				{
					return;
				}
				int count = mViews.Length;
				{
					//Log.i("foo", "Closing all windows of " + token);
					for (int i = 0; i < count; i++)
					{
						//Log.i("foo", "@ " + i + " token " + mParams[i].token
						//        + " view " + mRoots[i].getView());
						if (token == null || mParams[i].token == token)
						{
							android.view.ViewRootImpl root = mRoots[i];
							root.mAddNesting = 1;
							//Log.i("foo", "Force closing " + root);
							if (who != null)
							{
								android.view.WindowLeaked leak = new android.view.WindowLeaked(what + " " + who +
									 " has leaked window " + root.getView() + " that was originally added here");
								XobotOS.Runtime.Util.SetStackTrace(leak, root.getLocation().StackTrace);
								android.util.Log.e("WindowManager", leak.Message, leak);
							}
							removeViewLocked(i);
							i--;
							count--;
						}
					}
				}
			}
		}

		/// <param name="level">
		/// See
		/// <see cref="android.content.ComponentCallbacks">android.content.ComponentCallbacks
		/// 	</see>
		/// </param>
		public virtual void trimMemory(int level)
		{
			if (android.view.HardwareRenderer.isAvailable())
			{
				android.view.HardwareRenderer.trimMemory(level);
			}
		}

		/// <hide></hide>
		public virtual void trimLocalMemory()
		{
			lock (this)
			{
				if (mViews == null)
				{
					return;
				}
				int count = mViews.Length;
				{
					for (int i = 0; i < count; i++)
					{
						mRoots[i].destroyHardwareLayers();
					}
				}
			}
		}

		/// <hide></hide>
		public virtual void dumpGfxInfo(java.io.FileDescriptor fd)
		{
			java.io.FileOutputStream fout = new java.io.FileOutputStream(fd);
			java.io.PrintWriter pw = new java.io.PrintWriter(fout);
			try
			{
				lock (this)
				{
					if (mViews != null)
					{
						pw.println("View hierarchy:");
						int count = mViews.Length;
						int viewsCount = 0;
						int displayListsSize = 0;
						int[] info = new int[2];
						{
							for (int i = 0; i < count; i++)
							{
								android.view.ViewRootImpl root = mRoots[i];
								root.dumpGfxInfo(pw, info);
								string name = root.GetType().FullName + '@' + Sharpen.Util.IntToHexString(GetHashCode
									());
								pw.printf("  %s: %d views, %.2f kB (display lists)\n", name, info[0], info[1] / 1024.0f
									);
								viewsCount += info[0];
								displayListsSize += info[1];
							}
						}
						pw.printf("\nTotal ViewRootImpl: %d\n", count);
						pw.printf("Total Views:        %d\n", viewsCount);
						pw.printf("Total DisplayList:  %.2f kB\n\n", displayListsSize / 1024.0f);
					}
				}
			}
			finally
			{
				pw.flush();
			}
		}

		public virtual void setStoppedState(android.os.IBinder token, bool stopped)
		{
			lock (this)
			{
				if (mViews == null)
				{
					return;
				}
				int count = mViews.Length;
				{
					for (int i = 0; i < count; i++)
					{
						if (token == null || mParams[i].token == token)
						{
							android.view.ViewRootImpl root = mRoots[i];
							root.setStopped(stopped);
						}
					}
				}
			}
		}

		public virtual void reportNewConfiguration(android.content.res.Configuration config
			)
		{
			lock (this)
			{
				int count = mViews.Length;
				config = new android.content.res.Configuration(config);
				{
					for (int i = 0; i < count; i++)
					{
						android.view.ViewRootImpl root = mRoots[i];
						root.requestUpdateConfiguration(config);
					}
				}
			}
		}

		public virtual android.view.WindowManagerClass.LayoutParams getRootViewLayoutParameter
			(android.view.View view)
		{
			android.view.ViewParent vp = view.getParent();
			while (vp != null && !(vp is android.view.ViewRootImpl))
			{
				vp = vp.getParent();
			}
			if (vp == null)
			{
				return null;
			}
			android.view.ViewRootImpl vr = (android.view.ViewRootImpl)vp;
			int N = mRoots.Length;
			{
				for (int i = 0; i < N; ++i)
				{
					if (mRoots[i] == vr)
					{
						return mParams[i];
					}
				}
			}
			return null;
		}

		public virtual void closeAll()
		{
			closeAll(null, null, null);
		}

		[Sharpen.ImplementsInterface(@"android.view.WindowManager")]
		public virtual android.view.Display getDefaultDisplay()
		{
			return new android.view.Display(android.view.Display.DEFAULT_DISPLAY, null);
		}

		private static void removeItem(object[] dst, object[] src, int index)
		{
			if (dst.Length > 0)
			{
				if (index > 0)
				{
					System.Array.Copy(src, 0, dst, 0, index);
				}
				if (index < dst.Length)
				{
					System.Array.Copy(src, index + 1, dst, index, src.Length - index - 1);
				}
			}
		}

		private int findViewLocked(android.view.View view, bool required)
		{
			lock (this)
			{
				int count = mViews != null ? mViews.Length : 0;
				{
					for (int i = 0; i < count; i++)
					{
						if (mViews[i] == view)
						{
							return i;
						}
					}
				}
				if (required)
				{
					throw new System.ArgumentException("View not attached to window manager");
				}
				return -1;
			}
		}
	}
}

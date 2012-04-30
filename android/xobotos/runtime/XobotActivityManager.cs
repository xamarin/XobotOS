using System;
using System.IO;
using System.Drawing;
using SWF = System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Threading;
using android.app;
using android.view;
using android.util;
using android.os;
using android.content;
using android.content.pm;
using android.content.res;

namespace XobotOS.Runtime
{
	public static class XobotActivityManager
	{
		static readonly Thread ui_thread;
		static readonly Mutex mutex;
		static ActivityThread system_thread;
		static XobotPackageManager package_manager;
		static XobotDeviceConfig device_config;
		static XobotControl control;
		static SWF.Form main_form;
		static XobotWindow main_window;
		static Activity main_activity;
		static Stack<Activity> activity_stack;
		static XobotWindow active_window;
		static Activity active_activity;
		static int current_age;

		static XobotActivityManager ()
		{
			ui_thread = Thread.CurrentThread;
			mutex = new Mutex ();
			activity_stack = new Stack<Activity> ();
		}

		static void Initialize ()
		{
			main_form = new SWF.Form ();
			main_form.FormBorderStyle = SWF.FormBorderStyle.FixedSingle;
			main_form.MaximizeBox = false;
			main_form.MinimizeBox = false;
			main_form.ClientSize = device_config.Size;
			main_form.Name = "XobotOS";
			main_form.Text = "XobotOS";

			control = new XobotControl ();

			system_thread = ActivityThread.systemMain ();
			ContextImpl context = system_thread.getSystemContext ();
			package_manager = (XobotPackageManager)context.getPackageManager ();
		}

		internal static void SendMessage (Handler handler, Message msg, long at)
		{
			long now = SystemClock.uptimeMillis ();
			int age = current_age;
			Action dispatch = () => {
				mutex.WaitOne ();
				if (age == current_age)
					handler.dispatchMessage (msg);
				mutex.ReleaseMutex ();
			};
			if (now >= at) {
				ThreadPool.QueueUserWorkItem ((state) => control.Invoke (dispatch));
			} else {
				SWF.Timer timer = new SWF.Timer ();
				timer.Interval = (int)(at - now);
				timer.Tick += (sender, e) => {
					timer.Stop ();
					control.Invoke (dispatch);
				};
				timer.Start ();
			}
		}

		internal static void RequestInvalidate (XobotWindow window)
		{
			control.RequestInvalidate ();
		}

		internal static void RequestLayout (XobotWindow window)
		{
			window.PerformLayout (control.Left, control.Top, control.Right, control.Bottom);
		}

		internal delegate void WindowAction (XobotWindow window);

		internal static void Invoke (WindowAction action)
		{
			mutex.WaitOne ();
			if (activity_stack.Count > 0) {
				XobotWindow window = (XobotWindow)activity_stack.Peek ().getWindow ();
				action (window);
			}
			mutex.ReleaseMutex ();
		}

		internal static XobotWindow CreateMainWindow (Context context)
		{
			XobotWindow window = new XobotWindow (context);
			if (main_activity == null) {
				main_window = window;
			}
			return window;
		}

		internal static bool IsMainThread {
			get {
				return Thread.CurrentThread == ui_thread;
			}
		}

		internal static SWF.Form MainForm {
			get {
				return main_form;
			}
		}

		internal static XobotDeviceConfig DeviceConfig {
			get {
				return device_config;
			}
		}

		static void Run (Assembly assembly)
		{
			PackageInfo info = package_manager.LoadPackage (assembly);

			Intent intent = package_manager.getLaunchIntentForPackage (info.packageName);
			if (intent == null)
				throw new RuntimeException ("Cannot get Launch Intent.");

			main_activity = system_thread.startActivityNow (
				null, info.packageName, intent, info.activities [0], null, null, null);

			if (main_activity == null)
				throw new RuntimeException ("Failed to start Activity.");

			activity_stack.Push (main_activity);

			main_form.Controls.Add (control);
			SWF.Application.Run (main_form);
		}

		[STAThread]
		public static void Main (string[] args)
		{
			if (args.Length == 0) {
				martin.Test.run ();
				return;
			}

			string asm_name;

			if (args [0].StartsWith ("--device=")) {
				if (args.Length != 2)
					throw new RuntimeException ("Device and assembly name expected.");
				device_config = XobotDeviceConfig.getDevice (args [0].Substring (9));
				asm_name = args [1];
			} else {
				if (args.Length != 1)
					throw new RuntimeException ("Assembly name expected.");
				device_config = XobotDeviceConfig.DEFAULT;
				asm_name = args [0];
			}

			var asm = Assembly.LoadFrom (asm_name);
			if (asm == null)
				throw new RuntimeException ("Failed to load assembly");

			Initialize ();
			Run (asm);
		}

		internal static int StartActivity (IApplicationThread whoThread, Intent intent, string type,
		                                   Activity target, int requestCode)
		{
			var component = intent.getComponent ();
			if (component == null)
				return IActivityManagerClass.START_CLASS_NOT_FOUND;

			var info = package_manager.getActivityInfo (component, 0);
			if (info == null)
				return IActivityManagerClass.START_CLASS_NOT_FOUND;

			ActivityThread thread = new ActivityThread ();

			Activity activity = thread.startActivityNow (
				main_activity, null, intent, info, null, null, null);

			if (activity == null)
				return IActivityManagerClass.START_NOT_ACTIVITY;

			ThreadPool.QueueUserWorkItem ((state) => StartActivity (activity));

			return IActivityManagerClass.START_SUCCESS;
		}

		static void StartActivity (Activity activity)
		{
			mutex.WaitOne ();

			activity_stack.Push (activity);
			current_age++;

			ActivateWindow ();

			mutex.ReleaseMutex ();
		}

		static void FinishActivity ()
		{
			mutex.WaitOne ();

			activity_stack.Pop ();
			current_age++;

			if (activity_stack.Count == 0)
				main_form.Close ();
			else {
				ActivateWindow ();
			}

			mutex.ReleaseMutex ();
		}

		static void ActivateWindow ()
		{
			XobotWindow window = (XobotWindow)activity_stack.Peek ().getWindow ();

			window.OnAttachedToWindow ();
			window.OnVisibilityChanged (true);

			main_form.Text = window.Title ?? "XobotOS";
			control.Invalidate ();
		}

		internal static void FinishActivity (Activity activity, int resultCode, Intent resultData)
		{
			ThreadPool.QueueUserWorkItem ((state) => FinishActivity ());
		}
	}
}

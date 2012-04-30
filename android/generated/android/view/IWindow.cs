using Sharpen;

namespace android.view
{
	[Sharpen.Stub]
	public interface IWindow : android.os.IInterface
	{
		[Sharpen.Stub]
		void executeCommand(string command, string parameters, android.os.ParcelFileDescriptor
			 descriptor);

		[Sharpen.Stub]
		void resized(int w, int h, android.graphics.Rect coveredInsets, android.graphics.Rect
			 visibleInsets, bool reportDraw, android.content.res.Configuration newConfig);

		[Sharpen.Stub]
		void dispatchAppVisibility(bool visible);

		[Sharpen.Stub]
		void dispatchGetNewSurface();

		[Sharpen.Stub]
		void windowFocusChanged(bool hasFocus, bool inTouchMode);

		[Sharpen.Stub]
		void closeSystemDialogs(string reason);

		[Sharpen.Stub]
		void dispatchWallpaperOffsets(float x, float y, float xStep, float yStep, bool sync
			);

		[Sharpen.Stub]
		void dispatchWallpaperCommand(string action, int x, int y, int z, android.os.Bundle
			 extras, bool sync);

		[Sharpen.Stub]
		void dispatchDragEvent(android.view.DragEvent @event);

		[Sharpen.Stub]
		void dispatchSystemUiVisibilityChanged(int seq, int globalVisibility, int localValue
			, int localChanges);
	}

	[Sharpen.Stub]
	public static class IWindowClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.view.IWindow
		{
			internal const string DESCRIPTOR = "android.view.IWindow";

			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.view.IWindow asInterface(android.os.IBinder obj)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.IInterface")]
			public virtual android.os.IBinder asBinder()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.os.Binder")]
			protected internal override bool onTransact(int code, android.os.Parcel data, android.os.Parcel
				 reply, int flags)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			private class Proxy : android.view.IWindow
			{
				internal android.os.IBinder mRemote;

				[Sharpen.Stub]
				internal Proxy(android.os.IBinder remote)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.os.IInterface")]
				public virtual android.os.IBinder asBinder()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				public virtual string getInterfaceDescriptor()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindow")]
				public virtual void executeCommand(string command, string parameters, android.os.ParcelFileDescriptor
					 descriptor)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindow")]
				public virtual void resized(int w, int h, android.graphics.Rect coveredInsets, android.graphics.Rect
					 visibleInsets, bool reportDraw, android.content.res.Configuration newConfig)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindow")]
				public virtual void dispatchAppVisibility(bool visible)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindow")]
				public virtual void dispatchGetNewSurface()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindow")]
				public virtual void windowFocusChanged(bool hasFocus, bool inTouchMode)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindow")]
				public virtual void closeSystemDialogs(string reason)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindow")]
				public virtual void dispatchWallpaperOffsets(float x, float y, float xStep, float
					 yStep, bool sync)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindow")]
				public virtual void dispatchWallpaperCommand(string action, int x, int y, int z, 
					android.os.Bundle extras, bool sync)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindow")]
				public virtual void dispatchDragEvent(android.view.DragEvent @event)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindow")]
				public virtual void dispatchSystemUiVisibilityChanged(int seq, int globalVisibility
					, int localValue, int localChanges)
				{
					throw new System.NotImplementedException();
				}
			}

			internal const int TRANSACTION_executeCommand = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			internal const int TRANSACTION_resized = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 1);

			internal const int TRANSACTION_dispatchAppVisibility = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 2);

			internal const int TRANSACTION_dispatchGetNewSurface = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 3);

			internal const int TRANSACTION_windowFocusChanged = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 4);

			internal const int TRANSACTION_closeSystemDialogs = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 5);

			internal const int TRANSACTION_dispatchWallpaperOffsets = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 6);

			internal const int TRANSACTION_dispatchWallpaperCommand = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 7);

			internal const int TRANSACTION_dispatchDragEvent = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 8);

			internal const int TRANSACTION_dispatchSystemUiVisibilityChanged = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 9);

			public abstract void closeSystemDialogs(string arg1);

			public abstract void dispatchAppVisibility(bool arg1);

			public abstract void dispatchDragEvent(android.view.DragEvent arg1);

			public abstract void dispatchGetNewSurface();

			public abstract void dispatchSystemUiVisibilityChanged(int arg1, int arg2, int arg3
				, int arg4);

			public abstract void dispatchWallpaperCommand(string arg1, int arg2, int arg3, int
				 arg4, android.os.Bundle arg5, bool arg6);

			public abstract void dispatchWallpaperOffsets(float arg1, float arg2, float arg3, 
				float arg4, bool arg5);

			public abstract void executeCommand(string arg1, string arg2, android.os.ParcelFileDescriptor
				 arg3);

			public abstract void resized(int arg1, int arg2, android.graphics.Rect arg3, android.graphics.Rect
				 arg4, bool arg5, android.content.res.Configuration arg6);

			public abstract void windowFocusChanged(bool arg1, bool arg2);
		}
	}
}

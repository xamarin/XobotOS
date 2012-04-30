using Sharpen;

namespace android.view
{
	[Sharpen.Stub]
	public interface IWindowSession : android.os.IInterface
	{
		[Sharpen.Stub]
		int add(android.view.IWindow window, int seq, android.view.WindowManagerClass.LayoutParams
			 attrs, int viewVisibility, android.graphics.Rect outContentInsets, android.view.InputChannel
			 outInputChannel);

		[Sharpen.Stub]
		int addWithoutInputChannel(android.view.IWindow window, int seq, android.view.WindowManagerClass
			.LayoutParams attrs, int viewVisibility, android.graphics.Rect outContentInsets);

		[Sharpen.Stub]
		void remove(android.view.IWindow window);

		[Sharpen.Stub]
		int relayout(android.view.IWindow window, int seq, android.view.WindowManagerClass
			.LayoutParams attrs, int requestedWidth, int requestedHeight, int viewVisibility
			, bool insetsPending, android.graphics.Rect outFrame, android.graphics.Rect outContentInsets
			, android.graphics.Rect outVisibleInsets, android.content.res.Configuration outConfig
			, android.view.Surface outSurface);

		[Sharpen.Stub]
		bool outOfMemory(android.view.IWindow window);

		[Sharpen.Stub]
		void setTransparentRegion(android.view.IWindow window, android.graphics.Region region
			);

		[Sharpen.Stub]
		void setInsets(android.view.IWindow window, int touchableInsets, android.graphics.Rect
			 contentInsets, android.graphics.Rect visibleInsets, android.graphics.Region touchableRegion
			);

		[Sharpen.Stub]
		void getDisplayFrame(android.view.IWindow window, android.graphics.Rect outDisplayFrame
			);

		[Sharpen.Stub]
		void finishDrawing(android.view.IWindow window);

		[Sharpen.Stub]
		void setInTouchMode(bool showFocus);

		[Sharpen.Stub]
		bool getInTouchMode();

		[Sharpen.Stub]
		bool performHapticFeedback(android.view.IWindow window, int effectId, bool always
			);

		[Sharpen.Stub]
		android.os.IBinder prepareDrag(android.view.IWindow window, int flags, int thumbnailWidth
			, int thumbnailHeight, android.view.Surface outSurface);

		[Sharpen.Stub]
		bool performDrag(android.view.IWindow window, android.os.IBinder dragToken, float
			 touchX, float touchY, float thumbCenterX, float thumbCenterY, android.content.ClipData
			 data);

		[Sharpen.Stub]
		void reportDropResult(android.view.IWindow window, bool consumed);

		[Sharpen.Stub]
		void dragRecipientEntered(android.view.IWindow window);

		[Sharpen.Stub]
		void dragRecipientExited(android.view.IWindow window);

		[Sharpen.Stub]
		void setWallpaperPosition(android.os.IBinder windowToken, float x, float y, float
			 xstep, float ystep);

		[Sharpen.Stub]
		void wallpaperOffsetsComplete(android.os.IBinder window);

		[Sharpen.Stub]
		android.os.Bundle sendWallpaperCommand(android.os.IBinder window, string action, 
			int x, int y, int z, android.os.Bundle extras, bool sync);

		[Sharpen.Stub]
		void wallpaperCommandComplete(android.os.IBinder window, android.os.Bundle result
			);
	}

	[Sharpen.Stub]
	public static class IWindowSessionClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.view.IWindowSession
		{
			internal const string DESCRIPTOR = "android.view.IWindowSession";

			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.view.IWindowSession asInterface(android.os.IBinder obj)
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
			private class Proxy : android.view.IWindowSession
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
				[Sharpen.ImplementsInterface(@"android.view.IWindowSession")]
				public virtual int add(android.view.IWindow window, int seq, android.view.WindowManagerClass
					.LayoutParams attrs, int viewVisibility, android.graphics.Rect outContentInsets, 
					android.view.InputChannel outInputChannel)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowSession")]
				public virtual int addWithoutInputChannel(android.view.IWindow window, int seq, android.view.WindowManagerClass
					.LayoutParams attrs, int viewVisibility, android.graphics.Rect outContentInsets)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowSession")]
				public virtual void remove(android.view.IWindow window)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowSession")]
				public virtual int relayout(android.view.IWindow window, int seq, android.view.WindowManagerClass
					.LayoutParams attrs, int requestedWidth, int requestedHeight, int viewVisibility
					, bool insetsPending, android.graphics.Rect outFrame, android.graphics.Rect outContentInsets
					, android.graphics.Rect outVisibleInsets, android.content.res.Configuration outConfig
					, android.view.Surface outSurface)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowSession")]
				public virtual bool outOfMemory(android.view.IWindow window)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowSession")]
				public virtual void setTransparentRegion(android.view.IWindow window, android.graphics.Region
					 region)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowSession")]
				public virtual void setInsets(android.view.IWindow window, int touchableInsets, android.graphics.Rect
					 contentInsets, android.graphics.Rect visibleInsets, android.graphics.Region touchableRegion
					)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowSession")]
				public virtual void getDisplayFrame(android.view.IWindow window, android.graphics.Rect
					 outDisplayFrame)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowSession")]
				public virtual void finishDrawing(android.view.IWindow window)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowSession")]
				public virtual void setInTouchMode(bool showFocus)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowSession")]
				public virtual bool getInTouchMode()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowSession")]
				public virtual bool performHapticFeedback(android.view.IWindow window, int effectId
					, bool always)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowSession")]
				public virtual android.os.IBinder prepareDrag(android.view.IWindow window, int flags
					, int thumbnailWidth, int thumbnailHeight, android.view.Surface outSurface)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowSession")]
				public virtual bool performDrag(android.view.IWindow window, android.os.IBinder dragToken
					, float touchX, float touchY, float thumbCenterX, float thumbCenterY, android.content.ClipData
					 data)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowSession")]
				public virtual void reportDropResult(android.view.IWindow window, bool consumed)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowSession")]
				public virtual void dragRecipientEntered(android.view.IWindow window)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowSession")]
				public virtual void dragRecipientExited(android.view.IWindow window)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowSession")]
				public virtual void setWallpaperPosition(android.os.IBinder windowToken, float x, 
					float y, float xstep, float ystep)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowSession")]
				public virtual void wallpaperOffsetsComplete(android.os.IBinder window)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowSession")]
				public virtual android.os.Bundle sendWallpaperCommand(android.os.IBinder window, 
					string action, int x, int y, int z, android.os.Bundle extras, bool sync)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowSession")]
				public virtual void wallpaperCommandComplete(android.os.IBinder window, android.os.Bundle
					 result)
				{
					throw new System.NotImplementedException();
				}
			}

			internal const int TRANSACTION_add = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			internal const int TRANSACTION_addWithoutInputChannel = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 1);

			internal const int TRANSACTION_remove = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 2);

			internal const int TRANSACTION_relayout = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 3);

			internal const int TRANSACTION_outOfMemory = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 4);

			internal const int TRANSACTION_setTransparentRegion = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 5);

			internal const int TRANSACTION_setInsets = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 6);

			internal const int TRANSACTION_getDisplayFrame = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 7);

			internal const int TRANSACTION_finishDrawing = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 8);

			internal const int TRANSACTION_setInTouchMode = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 9);

			internal const int TRANSACTION_getInTouchMode = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 10);

			internal const int TRANSACTION_performHapticFeedback = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 11);

			internal const int TRANSACTION_prepareDrag = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 12);

			internal const int TRANSACTION_performDrag = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 13);

			internal const int TRANSACTION_reportDropResult = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 14);

			internal const int TRANSACTION_dragRecipientEntered = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 15);

			internal const int TRANSACTION_dragRecipientExited = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 16);

			internal const int TRANSACTION_setWallpaperPosition = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 17);

			internal const int TRANSACTION_wallpaperOffsetsComplete = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 18);

			internal const int TRANSACTION_sendWallpaperCommand = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 19);

			internal const int TRANSACTION_wallpaperCommandComplete = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 20);

			public abstract int add(android.view.IWindow arg1, int arg2, android.view.WindowManagerClass
				.LayoutParams arg3, int arg4, android.graphics.Rect arg5, android.view.InputChannel
				 arg6);

			public abstract int addWithoutInputChannel(android.view.IWindow arg1, int arg2, android.view.WindowManagerClass
				.LayoutParams arg3, int arg4, android.graphics.Rect arg5);

			public abstract void dragRecipientEntered(android.view.IWindow arg1);

			public abstract void dragRecipientExited(android.view.IWindow arg1);

			public abstract void finishDrawing(android.view.IWindow arg1);

			public abstract void getDisplayFrame(android.view.IWindow arg1, android.graphics.Rect
				 arg2);

			public abstract bool getInTouchMode();

			public abstract bool outOfMemory(android.view.IWindow arg1);

			public abstract bool performDrag(android.view.IWindow arg1, android.os.IBinder arg2
				, float arg3, float arg4, float arg5, float arg6, android.content.ClipData arg7);

			public abstract bool performHapticFeedback(android.view.IWindow arg1, int arg2, bool
				 arg3);

			public abstract android.os.IBinder prepareDrag(android.view.IWindow arg1, int arg2
				, int arg3, int arg4, android.view.Surface arg5);

			public abstract int relayout(android.view.IWindow arg1, int arg2, android.view.WindowManagerClass
				.LayoutParams arg3, int arg4, int arg5, int arg6, bool arg7, android.graphics.Rect
				 arg8, android.graphics.Rect arg9, android.graphics.Rect arg10, android.content.res.Configuration
				 arg11, android.view.Surface arg12);

			public abstract void remove(android.view.IWindow arg1);

			public abstract void reportDropResult(android.view.IWindow arg1, bool arg2);

			public abstract android.os.Bundle sendWallpaperCommand(android.os.IBinder arg1, string
				 arg2, int arg3, int arg4, int arg5, android.os.Bundle arg6, bool arg7);

			public abstract void setInTouchMode(bool arg1);

			public abstract void setInsets(android.view.IWindow arg1, int arg2, android.graphics.Rect
				 arg3, android.graphics.Rect arg4, android.graphics.Region arg5);

			public abstract void setTransparentRegion(android.view.IWindow arg1, android.graphics.Region
				 arg2);

			public abstract void setWallpaperPosition(android.os.IBinder arg1, float arg2, float
				 arg3, float arg4, float arg5);

			public abstract void wallpaperCommandComplete(android.os.IBinder arg1, android.os.Bundle
				 arg2);

			public abstract void wallpaperOffsetsComplete(android.os.IBinder arg1);
		}
	}
}

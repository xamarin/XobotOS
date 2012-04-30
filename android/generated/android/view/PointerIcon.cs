using Sharpen;

namespace android.view
{
	[Sharpen.Stub]
	public sealed class PointerIcon : android.os.Parcelable
	{
		internal const string TAG = "PointerIcon";

		public const int STYLE_CUSTOM = -1;

		public const int STYLE_NULL = 0;

		public const int STYLE_ARROW = 1000;

		public const int STYLE_SPOT_HOVER = 2000;

		public const int STYLE_SPOT_TOUCH = 2001;

		public const int STYLE_SPOT_ANCHOR = 2002;

		internal const int STYLE_OEM_FIRST = 10000;

		internal const int STYLE_DEFAULT = STYLE_ARROW;

		private static readonly android.view.PointerIcon gNullIcon = new android.view.PointerIcon
			(STYLE_NULL);

		private readonly int mStyle;

		private int mSystemIconResourceId;

		private android.graphics.Bitmap mBitmap;

		private float mHotSpotX;

		private float mHotSpotY;

		[Sharpen.Stub]
		private PointerIcon(int style)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.view.PointerIcon getNullIcon()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.view.PointerIcon getDefaultIcon(android.content.Context context
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.view.PointerIcon getSystemIcon(android.content.Context context
			, int style)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.view.PointerIcon createCustomIcon(android.graphics.Bitmap bitmap
			, float hotSpotX, float hotSpotY)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.view.PointerIcon loadCustomIcon(android.content.res.Resources
			 resources, int resourceId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.view.PointerIcon load(android.content.Context context)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool isNullIcon()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool isLoaded()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int getStyle()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.graphics.Bitmap getBitmap()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public float getHotSpotX()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public float getHotSpotY()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void throwIfIconIsNotLoaded()
		{
			throw new System.NotImplementedException();
		}

		private sealed class _Creator_309 : android.os.ParcelableClass.Creator<android.view.PointerIcon
			>
		{
			public _Creator_309()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.view.PointerIcon createFromParcel(android.os.Parcel @in)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.view.PointerIcon[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.view.PointerIcon
			> CREATOR = new _Creator_309();

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public int describeContents()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public void writeToParcel(android.os.Parcel @out, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override bool Equals(object other)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void loadResource(android.content.res.Resources resources, int resourceId
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void validateHotSpot(android.graphics.Bitmap bitmap, float hotSpotX
			, float hotSpotY)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static int getSystemIconStyleIndex(int style)
		{
			throw new System.NotImplementedException();
		}
	}
}

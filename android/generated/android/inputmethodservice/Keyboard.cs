using Sharpen;

namespace android.inputmethodservice
{
	[Sharpen.Stub]
	public class Keyboard
	{
		internal const string TAG = "Keyboard";

		internal const string TAG_KEYBOARD = "Keyboard";

		internal const string TAG_ROW = "Row";

		internal const string TAG_KEY = "Key";

		public const int EDGE_LEFT = unchecked((int)(0x01));

		public const int EDGE_RIGHT = unchecked((int)(0x02));

		public const int EDGE_TOP = unchecked((int)(0x04));

		public const int EDGE_BOTTOM = unchecked((int)(0x08));

		public const int KEYCODE_SHIFT = -1;

		public const int KEYCODE_MODE_CHANGE = -2;

		public const int KEYCODE_CANCEL = -3;

		public const int KEYCODE_DONE = -4;

		public const int KEYCODE_DELETE = -5;

		public const int KEYCODE_ALT = -6;

		private java.lang.CharSequence mLabel;

		private int mDefaultHorizontalGap;

		private int mDefaultWidth;

		private int mDefaultHeight;

		private int mDefaultVerticalGap;

		private bool mShifted;

		private android.inputmethodservice.Keyboard.Key[] mShiftKeys = new android.inputmethodservice.Keyboard
			.Key[] { null, null };

		private int[] mShiftKeyIndices = new int[] { -1, -1 };

		private int mKeyWidth;

		private int mKeyHeight;

		private int mTotalHeight;

		private int mTotalWidth;

		private java.util.List<android.inputmethodservice.Keyboard.Key> mKeys;

		private java.util.List<android.inputmethodservice.Keyboard.Key> mModifierKeys;

		private int mDisplayWidth;

		private int mDisplayHeight;

		private int mKeyboardMode;

		internal const int GRID_WIDTH = 10;

		internal const int GRID_HEIGHT = 5;

		internal const int GRID_SIZE = GRID_WIDTH * GRID_HEIGHT;

		private int mCellWidth;

		private int mCellHeight;

		private int[][] mGridNeighbors;

		private int mProximityThreshold;

		private static float SEARCH_DISTANCE = 1.8f;

		private java.util.ArrayList<android.inputmethodservice.Keyboard.Row> rows = new java.util.ArrayList
			<android.inputmethodservice.Keyboard.Row>();

		[Sharpen.Stub]
		public class Row
		{
			public int defaultWidth;

			public int defaultHeight;

			public int defaultHorizontalGap;

			public int verticalGap;

			internal java.util.ArrayList<android.inputmethodservice.Keyboard.Key> mKeys = new 
				java.util.ArrayList<android.inputmethodservice.Keyboard.Key>();

			public int rowEdgeFlags;

			public int mode;

			private android.inputmethodservice.Keyboard parent;

			[Sharpen.Stub]
			public Row(android.inputmethodservice.Keyboard parent)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public Row(android.content.res.Resources res, android.inputmethodservice.Keyboard
				 parent, android.content.res.XmlResourceParser parser)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public class Key
		{
			public int[] codes;

			public java.lang.CharSequence label;

			public android.graphics.drawable.Drawable icon;

			public android.graphics.drawable.Drawable iconPreview;

			public int width;

			public int height;

			public int gap;

			public bool sticky;

			public int x;

			public int y;

			public bool pressed;

			public bool on;

			public java.lang.CharSequence text;

			public java.lang.CharSequence popupCharacters;

			public int edgeFlags;

			public bool modifier;

			private android.inputmethodservice.Keyboard keyboard;

			public int popupResId;

			public bool repeatable;

			private static readonly int[] KEY_STATE_NORMAL_ON = new int[] { android.R.attr.state_checkable
				, android.R.attr.state_checked };

			private static readonly int[] KEY_STATE_PRESSED_ON = new int[] { android.R.attr.state_pressed
				, android.R.attr.state_checkable, android.R.attr.state_checked };

			private static readonly int[] KEY_STATE_NORMAL_OFF = new int[] { android.R.attr.state_checkable
				 };

			private static readonly int[] KEY_STATE_PRESSED_OFF = new int[] { android.R.attr.
				state_pressed, android.R.attr.state_checkable };

			private static readonly int[] KEY_STATE_NORMAL = new int[] {  };

			private static readonly int[] KEY_STATE_PRESSED = new int[] { android.R.attr.state_pressed
				 };

			[Sharpen.Stub]
			public Key(android.inputmethodservice.Keyboard.Row parent)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public Key(android.content.res.Resources res, android.inputmethodservice.Keyboard
				.Row parent, int x, int y, android.content.res.XmlResourceParser parser) : this(
				parent)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void onPressed()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void onReleased(bool inside)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal virtual int[] parseCSV(string value)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual bool isInside(int x, int y)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual int squaredDistanceFrom(int x, int y)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual int[] getCurrentDrawableState()
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public Keyboard(android.content.Context context, int xmlLayoutResId) : this(context
			, xmlLayoutResId, 0)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public Keyboard(android.content.Context context, int xmlLayoutResId, int modeId, 
			int width, int height)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public Keyboard(android.content.Context context, int xmlLayoutResId, int modeId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public Keyboard(android.content.Context context, int layoutTemplateResId, java.lang.CharSequence
			 characters, int columns, int horizontalPadding) : this(context, layoutTemplateResId
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal void resize(int newWidth, int newHeight)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual java.util.List<android.inputmethodservice.Keyboard.Key> getKeys()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual java.util.List<android.inputmethodservice.Keyboard.Key> getModifierKeys
			()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual int getHorizontalGap()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual void setHorizontalGap(int gap)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual int getVerticalGap()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual void setVerticalGap(int gap)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual int getKeyHeight()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual void setKeyHeight(int height)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual int getKeyWidth()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual void setKeyWidth(int width)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getHeight()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getMinWidth()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool setShifted(bool shiftState)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isShifted()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int[] getShiftKeyIndices()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getShiftKeyIndex()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void computeNearestNeighbors()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int[] getNearestKeys(int x, int y)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual android.inputmethodservice.Keyboard.Row createRowFromXml
			(android.content.res.Resources res, android.content.res.XmlResourceParser parser
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual android.inputmethodservice.Keyboard.Key createKeyFromXml
			(android.content.res.Resources res, android.inputmethodservice.Keyboard.Row parent
			, int x, int y, android.content.res.XmlResourceParser parser)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void loadKeyboard(android.content.Context context, android.content.res.XmlResourceParser
			 parser)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void skipToEndOfRow(android.content.res.XmlResourceParser parser)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void parseKeyboardAttributes(android.content.res.Resources res, android.content.res.XmlResourceParser
			 parser)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal static int getDimensionOrFraction(android.content.res.TypedArray a, int 
			index, int @base, int defValue)
		{
			throw new System.NotImplementedException();
		}
	}
}

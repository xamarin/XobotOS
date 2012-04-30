using Sharpen;

namespace android.database
{
	[Sharpen.Stub]
	public abstract class AbstractWindowedCursor : android.database.AbstractCursor
	{
		protected internal android.database.CursorWindow mWindow;

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.AbstractCursor")]
		public override byte[] getBlob(int columnIndex)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.AbstractCursor")]
		public override string getString(int columnIndex)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.AbstractCursor")]
		public override void copyStringToBuffer(int columnIndex, android.database.CharArrayBuffer
			 buffer)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.AbstractCursor")]
		public override short getShort(int columnIndex)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.AbstractCursor")]
		public override int getInt(int columnIndex)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.AbstractCursor")]
		public override long getLong(int columnIndex)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.AbstractCursor")]
		public override float getFloat(int columnIndex)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.AbstractCursor")]
		public override double getDouble(int columnIndex)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.AbstractCursor")]
		public override bool isNull(int columnIndex)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"Use getType(int)")]
		public virtual bool isBlob(int columnIndex)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"Use getType(int)")]
		public virtual bool isString(int columnIndex)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"Use getType(int)")]
		public virtual bool isLong(int columnIndex)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"Use getType(int)")]
		public virtual bool isFloat(int columnIndex)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.AbstractCursor")]
		public override int getType(int columnIndex)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.AbstractCursor")]
		protected internal override void checkPosition()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.AbstractCursor")]
		public override android.database.CursorWindow getWindow()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setWindow(android.database.CursorWindow window)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool hasWindow()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual void closeWindow()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual void clearOrCreateLocalWindow(string name)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.AbstractCursor")]
		protected internal override void onDeactivateOrClose()
		{
			throw new System.NotImplementedException();
		}
	}
}

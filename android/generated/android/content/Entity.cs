using Sharpen;

namespace android.content
{
	[Sharpen.Stub]
	public sealed class Entity
	{
		private readonly android.content.ContentValues mValues;

		private readonly java.util.ArrayList<android.content.Entity.NamedContentValues> mSubValues;

		[Sharpen.Stub]
		public Entity(android.content.ContentValues values)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.content.ContentValues getEntityValues()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public java.util.ArrayList<android.content.Entity.NamedContentValues> getSubValues
			()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void addSubValue(System.Uri uri, android.content.ContentValues values)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public class NamedContentValues
		{
			public readonly System.Uri uri;

			public readonly android.content.ContentValues values;

			[Sharpen.Stub]
			public NamedContentValues(System.Uri uri, android.content.ContentValues values)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			throw new System.NotImplementedException();
		}
	}
}

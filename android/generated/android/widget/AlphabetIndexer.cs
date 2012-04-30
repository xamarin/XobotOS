using Sharpen;

namespace android.widget
{
	[Sharpen.Stub]
	public class AlphabetIndexer : android.database.DataSetObserver, android.widget.SectionIndexer
	{
		protected internal android.database.Cursor mDataCursor;

		protected internal int mColumnIndex;

		protected internal java.lang.CharSequence mAlphabet;

		private int mAlphabetLength;

		private android.util.SparseIntArray mAlphaMap;

		private java.text.Collator mCollator;

		private string[] mAlphabetArray;

		[Sharpen.Stub]
		public AlphabetIndexer(android.database.Cursor cursor, int sortedColumnIndex, java.lang.CharSequence
			 alphabet)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.widget.SectionIndexer")]
		public virtual object[] getSections()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setCursor(android.database.Cursor cursor)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual int compare(string word, string letter)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.widget.SectionIndexer")]
		public virtual int getPositionForSection(int sectionIndex)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.widget.SectionIndexer")]
		public virtual int getSectionForPosition(int position)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.DataSetObserver")]
		public override void onChanged()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.DataSetObserver")]
		public override void onInvalidated()
		{
			throw new System.NotImplementedException();
		}
	}
}

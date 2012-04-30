using Sharpen;

namespace android.content.pm
{
	[Sharpen.Stub]
	public class LabeledIntent : android.content.Intent
	{
		private string mSourcePackage;

		private int mLabelRes;

		private java.lang.CharSequence mNonLocalizedLabel;

		private int mIcon;

		[Sharpen.Stub]
		public LabeledIntent(android.content.Intent origIntent, string sourcePackage, int
			 labelRes, int icon) : base(origIntent)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public LabeledIntent(android.content.Intent origIntent, string sourcePackage, java.lang.CharSequence
			 nonLocalizedLabel, int icon) : base(origIntent)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public LabeledIntent(string sourcePackage, int labelRes, int icon)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public LabeledIntent(string sourcePackage, java.lang.CharSequence nonLocalizedLabel
			, int icon)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string getSourcePackage()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getLabelResource()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual java.lang.CharSequence getNonLocalizedLabel()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getIconResource()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual java.lang.CharSequence loadLabel(android.content.pm.PackageManager
			 pm)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.graphics.drawable.Drawable loadIcon(android.content.pm.PackageManager
			 pm)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.content.Intent")]
		public override void writeToParcel(android.os.Parcel dest, int parcelableFlags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal LabeledIntent(android.os.Parcel @in)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.content.Intent")]
		public override void readFromParcel(android.os.Parcel @in)
		{
			throw new System.NotImplementedException();
		}

		private sealed class _Creator_184 : android.os.ParcelableClass.Creator<android.content.pm.LabeledIntent
			>
		{
			public _Creator_184()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.pm.LabeledIntent createFromParcel(android.os.Parcel source
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.pm.LabeledIntent[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.content.pm.LabeledIntent
			> CREATOR = new _Creator_184();
	}
}

using Sharpen;

namespace android.widget
{
	[Sharpen.Stub]
	public class QuickContactBadge : android.widget.ImageView, android.view.View.OnClickListener
	{
		private System.Uri mContactUri;

		private string mContactEmail;

		private string mContactPhone;

		private android.graphics.drawable.Drawable mOverlay;

		private android.widget.QuickContactBadge.QueryHandler mQueryHandler;

		private android.graphics.drawable.Drawable mDefaultAvatar;

		protected internal string[] mExcludeMimes = null;

		internal const int TOKEN_EMAIL_LOOKUP = 0;

		internal const int TOKEN_PHONE_LOOKUP = 1;

		internal const int TOKEN_EMAIL_LOOKUP_AND_TRIGGER = 2;

		internal const int TOKEN_PHONE_LOOKUP_AND_TRIGGER = 3;

		internal static readonly string[] EMAIL_LOOKUP_PROJECTION = new string[] { android.provider.ContactsContract.RawContactsColumnsClass.CONTACT_ID
			, android.provider.ContactsContract.ContactsColumnsClass.LOOKUP_KEY };

		internal const int EMAIL_ID_COLUMN_INDEX = 0;

		internal const int EMAIL_LOOKUP_STRING_COLUMN_INDEX = 1;

		internal static readonly string[] PHONE_LOOKUP_PROJECTION = new string[] { android.provider.BaseColumnsClass._ID
			, android.provider.ContactsContract.ContactsColumnsClass.LOOKUP_KEY };

		internal const int PHONE_ID_COLUMN_INDEX = 0;

		internal const int PHONE_LOOKUP_STRING_COLUMN_INDEX = 1;

		[Sharpen.Stub]
		public QuickContactBadge(android.content.Context context) : this(context, null)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public QuickContactBadge(android.content.Context context, android.util.AttributeSet
			 attrs) : this(context, attrs, 0)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public QuickContactBadge(android.content.Context context, android.util.AttributeSet
			 attrs, int defStyle) : base(context, attrs, defStyle)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void drawableStateChanged()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setMode(int size)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onDraw(android.graphics.Canvas canvas)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private bool isAssigned()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setImageToDefault()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void assignContactUri(System.Uri contactUri)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void assignContactFromEmail(string emailAddress, bool lazyLookup)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void assignContactFromPhone(string phoneNumber, bool lazyLookup)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void onContactUriChanged()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.View.OnClickListener")]
		public virtual void onClick(android.view.View v)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setExcludeMimes(string[] excludeMimes)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private class QueryHandler : android.content.AsyncQueryHandler
		{
			[Sharpen.Stub]
			public QueryHandler(QuickContactBadge _enclosing, android.content.ContentResolver
				 cr) : base(cr)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.content.AsyncQueryHandler")]
			protected internal override void onQueryComplete(int token, object cookie, android.database.Cursor
				 cursor)
			{
				throw new System.NotImplementedException();
			}

			private readonly QuickContactBadge _enclosing;
		}
	}
}

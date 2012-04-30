using Sharpen;

namespace android.content
{
	[Sharpen.Stub]
	internal class SyncAdaptersCache : android.content.pm.RegisteredServicesCache<android.content.SyncAdapterType
		>
	{
		internal const string TAG = "Account";

		internal const string SERVICE_INTERFACE = "android.content.SyncAdapter";

		internal const string SERVICE_META_DATA = "android.content.SyncAdapter";

		internal const string ATTRIBUTES_NAME = "sync-adapter";

		private static readonly android.content.SyncAdaptersCache.MySerializer sSerializer
			 = new android.content.SyncAdaptersCache.MySerializer();

		[Sharpen.Stub]
		internal SyncAdaptersCache(android.content.Context context) : base(context, SERVICE_INTERFACE
			, SERVICE_META_DATA, ATTRIBUTES_NAME, sSerializer)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.content.pm.RegisteredServicesCache")]
		public override android.content.SyncAdapterType parseServiceAttributes(android.content.res.Resources
			 res, string packageName, android.util.AttributeSet attrs)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal class MySerializer : android.content.pm.XmlSerializerAndParser<android.content.SyncAdapterType
			>
		{
			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.content.pm.XmlSerializerAndParser")]
			public virtual void writeAsXml(android.content.SyncAdapterType item, org.xmlpull.v1.XmlSerializer
				 @out)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.content.pm.XmlSerializerAndParser")]
			public virtual android.content.SyncAdapterType createFromXml(org.xmlpull.v1.XmlPullParser
				 parser)
			{
				throw new System.NotImplementedException();
			}
		}
	}
}

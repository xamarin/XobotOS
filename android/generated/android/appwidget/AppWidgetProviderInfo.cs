using Sharpen;

namespace android.appwidget
{
	/// <summary>Describes the meta data for an installed AppWidget provider.</summary>
	/// <remarks>
	/// Describes the meta data for an installed AppWidget provider.  The fields in this class
	/// correspond to the fields in the <code>&lt;appwidget-provider&gt;</code> xml tag.
	/// </remarks>
	[Sharpen.Sharpened]
	public class AppWidgetProviderInfo : android.os.Parcelable
	{
		/// <summary>Widget is not resizable.</summary>
		/// <remarks>Widget is not resizable.</remarks>
		public const int RESIZE_NONE = 0;

		/// <summary>Widget is resizable in the horizontal axis only.</summary>
		/// <remarks>Widget is resizable in the horizontal axis only.</remarks>
		public const int RESIZE_HORIZONTAL = 1;

		/// <summary>Widget is resizable in the vertical axis only.</summary>
		/// <remarks>Widget is resizable in the vertical axis only.</remarks>
		public const int RESIZE_VERTICAL = 2;

		/// <summary>Widget is resizable in both the horizontal and vertical axes.</summary>
		/// <remarks>Widget is resizable in both the horizontal and vertical axes.</remarks>
		public const int RESIZE_BOTH = RESIZE_HORIZONTAL | RESIZE_VERTICAL;

		/// <summary>Identity of this AppWidget component.</summary>
		/// <remarks>
		/// Identity of this AppWidget component.  This component should be a
		/// <see cref="android.content.BroadcastReceiver">android.content.BroadcastReceiver</see>
		/// , and it will be sent the AppWidget intents
		/// <see cref="android.appwidget">as described in the AppWidget package documentation
		/// 	</see>
		/// .
		/// <p>This field corresponds to the <code>android:name</code> attribute in
		/// the <code>&lt;receiver&gt;</code> element in the AndroidManifest.xml file.
		/// </remarks>
		public android.content.ComponentName provider;

		/// <summary>The default height of the widget when added to a host, in dp.</summary>
		/// <remarks>
		/// The default height of the widget when added to a host, in dp. The widget will get
		/// at least this width, and will often be given more, depending on the host.
		/// <p>This field corresponds to the <code>android:minWidth</code> attribute in
		/// the AppWidget meta-data file.
		/// </remarks>
		public int minWidth;

		/// <summary>The default height of the widget when added to a host, in dp.</summary>
		/// <remarks>
		/// The default height of the widget when added to a host, in dp. The widget will get
		/// at least this height, and will often be given more, depending on the host.
		/// <p>This field corresponds to the <code>android:minHeight</code> attribute in
		/// the AppWidget meta-data file.
		/// </remarks>
		public int minHeight;

		/// <summary>Minimum width (in dp) which the widget can be resized to.</summary>
		/// <remarks>
		/// Minimum width (in dp) which the widget can be resized to. This field has no effect if it
		/// is greater than minWidth or if horizontal resizing isn't enabled (see
		/// <see cref="resizeMode">resizeMode</see>
		/// ).
		/// <p>This field corresponds to the <code>android:minResizeWidth</code> attribute in
		/// the AppWidget meta-data file.
		/// </remarks>
		public int minResizeWidth;

		/// <summary>Minimum height (in dp) which the widget can be resized to.</summary>
		/// <remarks>
		/// Minimum height (in dp) which the widget can be resized to. This field has no effect if it
		/// is greater than minHeight or if vertical resizing isn't enabled (see
		/// <see cref="resizeMode">resizeMode</see>
		/// ).
		/// <p>This field corresponds to the <code>android:minResizeHeight</code> attribute in
		/// the AppWidget meta-data file.
		/// </remarks>
		public int minResizeHeight;

		/// <summary>How often, in milliseconds, that this AppWidget wants to be updated.</summary>
		/// <remarks>
		/// How often, in milliseconds, that this AppWidget wants to be updated.
		/// The AppWidget manager may place a limit on how often a AppWidget is updated.
		/// <p>This field corresponds to the <code>android:updatePeriodMillis</code> attribute in
		/// the AppWidget meta-data file.
		/// <p class="note"><b>Note:</b> Updates requested with <code>updatePeriodMillis</code>
		/// will not be delivered more than once every 30 minutes.</p>
		/// </remarks>
		public int updatePeriodMillis;

		/// <summary>The resource id of the initial layout for this AppWidget.</summary>
		/// <remarks>
		/// The resource id of the initial layout for this AppWidget.  This should be
		/// displayed until the RemoteViews for the AppWidget is available.
		/// <p>This field corresponds to the <code>android:initialLayout</code> attribute in
		/// the AppWidget meta-data file.
		/// </remarks>
		public int initialLayout;

		/// <summary>The activity to launch that will configure the AppWidget.</summary>
		/// <remarks>
		/// The activity to launch that will configure the AppWidget.
		/// <p>This class name of field corresponds to the <code>android:configure</code> attribute in
		/// the AppWidget meta-data file.  The package name always corresponds to the package containing
		/// the AppWidget provider.
		/// </remarks>
		public android.content.ComponentName configure;

		/// <summary>The label to display to the user in the AppWidget picker.</summary>
		/// <remarks>
		/// The label to display to the user in the AppWidget picker.  If not supplied in the
		/// xml, the application label will be used.
		/// <p>This field corresponds to the <code>android:label</code> attribute in
		/// the <code>&lt;receiver&gt;</code> element in the AndroidManifest.xml file.
		/// </remarks>
		public string label;

		/// <summary>The icon to display for this AppWidget in the AppWidget picker.</summary>
		/// <remarks>
		/// The icon to display for this AppWidget in the AppWidget picker.  If not supplied in the
		/// xml, the application icon will be used.
		/// <p>This field corresponds to the <code>android:icon</code> attribute in
		/// the <code>&lt;receiver&gt;</code> element in the AndroidManifest.xml file.
		/// </remarks>
		public int icon;

		/// <summary>The view id of the AppWidget subview which should be auto-advanced by the widget's host.
		/// 	</summary>
		/// <remarks>
		/// The view id of the AppWidget subview which should be auto-advanced by the widget's host.
		/// <p>This field corresponds to the <code>android:autoAdvanceViewId</code> attribute in
		/// the AppWidget meta-data file.
		/// </remarks>
		public int autoAdvanceViewId;

		/// <summary>A preview of what the AppWidget will look like after it's configured.</summary>
		/// <remarks>
		/// A preview of what the AppWidget will look like after it's configured.
		/// If not supplied, the AppWidget's icon will be used.
		/// <p>This field corresponds to the <code>android:previewImage</code> attribute in
		/// the <code>&lt;receiver&gt;</code> element in the AndroidManifest.xml file.
		/// </remarks>
		public int previewImage;

		/// <summary>The rules by which a widget can be resized.</summary>
		/// <remarks>
		/// The rules by which a widget can be resized. See
		/// <see cref="RESIZE_NONE">RESIZE_NONE</see>
		/// ,
		/// <see cref="RESIZE_NONE">RESIZE_NONE</see>
		/// ,
		/// <see cref="RESIZE_HORIZONTAL">RESIZE_HORIZONTAL</see>
		/// ,
		/// <see cref="RESIZE_VERTICAL">RESIZE_VERTICAL</see>
		/// ,
		/// <see cref="RESIZE_BOTH">RESIZE_BOTH</see>
		/// .
		/// <p>This field corresponds to the <code>android:resizeMode</code> attribute in
		/// the AppWidget meta-data file.
		/// </remarks>
		public int resizeMode;

		public AppWidgetProviderInfo()
		{
		}

		/// <summary>Unflatten the AppWidgetProviderInfo from a parcel.</summary>
		/// <remarks>Unflatten the AppWidgetProviderInfo from a parcel.</remarks>
		public AppWidgetProviderInfo(android.os.Parcel @in)
		{
			if (0 != @in.readInt())
			{
				this.provider = new android.content.ComponentName(@in);
			}
			this.minWidth = @in.readInt();
			this.minHeight = @in.readInt();
			this.minResizeWidth = @in.readInt();
			this.minResizeHeight = @in.readInt();
			this.updatePeriodMillis = @in.readInt();
			this.initialLayout = @in.readInt();
			if (0 != @in.readInt())
			{
				this.configure = new android.content.ComponentName(@in);
			}
			this.label = @in.readString();
			this.icon = @in.readInt();
			this.previewImage = @in.readInt();
			this.autoAdvanceViewId = @in.readInt();
			this.resizeMode = @in.readInt();
		}

		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual void writeToParcel(android.os.Parcel @out, int flags)
		{
			if (this.provider != null)
			{
				@out.writeInt(1);
				this.provider.writeToParcel(@out, flags);
			}
			else
			{
				@out.writeInt(0);
			}
			@out.writeInt(this.minWidth);
			@out.writeInt(this.minHeight);
			@out.writeInt(this.minResizeWidth);
			@out.writeInt(this.minResizeHeight);
			@out.writeInt(this.updatePeriodMillis);
			@out.writeInt(this.initialLayout);
			if (this.configure != null)
			{
				@out.writeInt(1);
				this.configure.writeToParcel(@out, flags);
			}
			else
			{
				@out.writeInt(0);
			}
			@out.writeString(this.label);
			@out.writeInt(this.icon);
			@out.writeInt(this.previewImage);
			@out.writeInt(this.autoAdvanceViewId);
			@out.writeInt(this.resizeMode);
		}

		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual int describeContents()
		{
			return 0;
		}

		private sealed class _Creator_228 : android.os.ParcelableClass.Creator<android.appwidget.AppWidgetProviderInfo
			>
		{
			public _Creator_228()
			{
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.appwidget.AppWidgetProviderInfo createFromParcel(android.os.Parcel
				 parcel)
			{
				return new android.appwidget.AppWidgetProviderInfo(parcel);
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.appwidget.AppWidgetProviderInfo[] newArray(int size)
			{
				return new android.appwidget.AppWidgetProviderInfo[size];
			}
		}

		/// <summary>Parcelable.Creator that instantiates AppWidgetProviderInfo objects</summary>
		public static readonly android.os.ParcelableClass.Creator<android.appwidget.AppWidgetProviderInfo
			> CREATOR = new _Creator_228();

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			return "AppWidgetProviderInfo(provider=" + this.provider + ")";
		}
	}
}

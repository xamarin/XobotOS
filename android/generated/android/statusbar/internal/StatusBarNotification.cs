using Sharpen;

namespace android.statusbar.@internal
{
	[Sharpen.Sharpened]
	public class StatusBarNotification : android.os.Parcelable
	{
		public static int PRIORITY_JIFFY_EXPRESS = -100;

		public static int PRIORITY_NORMAL = 0;

		public static int PRIORITY_ONGOING = 100;

		public static int PRIORITY_SYSTEM = 200;

		public string pkg;

		public int id;

		public string tag;

		public int uid;

		public int initialPid;

		public android.app.Notification notification;

		public int priority = PRIORITY_NORMAL;

		public StatusBarNotification()
		{
		}

		public StatusBarNotification(string pkg, int id, string tag, int uid, int initialPid
			, android.app.Notification notification)
		{
			if (pkg == null)
			{
				throw new System.ArgumentNullException();
			}
			if (notification == null)
			{
				throw new System.ArgumentNullException();
			}
			this.pkg = pkg;
			this.id = id;
			this.tag = tag;
			this.uid = uid;
			this.initialPid = initialPid;
			this.notification = notification;
			this.priority = PRIORITY_NORMAL;
		}

		public StatusBarNotification(android.os.Parcel @in)
		{
			readFromParcel(@in);
		}

		public virtual void readFromParcel(android.os.Parcel @in)
		{
			this.pkg = @in.readString();
			this.id = @in.readInt();
			if (@in.readInt() != 0)
			{
				this.tag = @in.readString();
			}
			else
			{
				this.tag = null;
			}
			this.uid = @in.readInt();
			this.initialPid = @in.readInt();
			this.priority = @in.readInt();
			this.notification = new android.app.Notification(@in);
		}

		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual void writeToParcel(android.os.Parcel @out, int flags)
		{
			@out.writeString(this.pkg);
			@out.writeInt(this.id);
			if (this.tag != null)
			{
				@out.writeInt(1);
				@out.writeString(this.tag);
			}
			else
			{
				@out.writeInt(0);
			}
			@out.writeInt(this.uid);
			@out.writeInt(this.initialPid);
			@out.writeInt(this.priority);
			this.notification.writeToParcel(@out, flags);
		}

		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual int describeContents()
		{
			return 0;
		}

		private sealed class _Creator_108 : android.os.ParcelableClass.Creator<android.statusbar.@internal.StatusBarNotification
			>
		{
			public _Creator_108()
			{
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.statusbar.@internal.StatusBarNotification createFromParcel(android.os.Parcel
				 parcel)
			{
				return new android.statusbar.@internal.StatusBarNotification(parcel);
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.statusbar.@internal.StatusBarNotification[] newArray(int size)
			{
				return new android.statusbar.@internal.StatusBarNotification[size];
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.statusbar.@internal.StatusBarNotification
			> CREATOR = new _Creator_108();

		public virtual android.statusbar.@internal.StatusBarNotification clone()
		{
			return new android.statusbar.@internal.StatusBarNotification(this.pkg, this.id, this
				.tag, this.uid, this.initialPid, this.notification.clone());
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			return "StatusBarNotification(package=" + pkg + " id=" + id + " tag=" + tag + " notification="
				 + notification + " priority=" + priority + ")";
		}

		public virtual bool isOngoing()
		{
			return (notification.flags & android.app.Notification.FLAG_ONGOING_EVENT) != 0;
		}

		public virtual bool isClearable()
		{
			return ((notification.flags & android.app.Notification.FLAG_ONGOING_EVENT) == 0) 
				&& ((notification.flags & android.app.Notification.FLAG_NO_CLEAR) == 0);
		}
	}
}

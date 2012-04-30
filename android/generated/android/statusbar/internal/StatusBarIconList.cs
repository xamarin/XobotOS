using Sharpen;

namespace android.statusbar.@internal
{
	[Sharpen.Sharpened]
	public class StatusBarIconList : android.os.Parcelable
	{
		private string[] mSlots;

		private android.statusbar.@internal.StatusBarIcon[] mIcons;

		public StatusBarIconList()
		{
		}

		public StatusBarIconList(android.os.Parcel @in)
		{
			readFromParcel(@in);
		}

		public virtual void readFromParcel(android.os.Parcel @in)
		{
			this.mSlots = @in.readStringArray();
			int N = @in.readInt();
			if (N < 0)
			{
				mIcons = null;
			}
			else
			{
				mIcons = new android.statusbar.@internal.StatusBarIcon[N];
				{
					for (int i = 0; i < N; i++)
					{
						if (@in.readInt() != 0)
						{
							mIcons[i] = new android.statusbar.@internal.StatusBarIcon(@in);
						}
					}
				}
			}
		}

		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual void writeToParcel(android.os.Parcel @out, int flags)
		{
			@out.writeStringArray(mSlots);
			if (mIcons == null)
			{
				@out.writeInt(-1);
			}
			else
			{
				int N = mIcons.Length;
				@out.writeInt(N);
				{
					for (int i = 0; i < N; i++)
					{
						android.statusbar.@internal.StatusBarIcon ic = mIcons[i];
						if (ic == null)
						{
							@out.writeInt(0);
						}
						else
						{
							@out.writeInt(1);
							ic.writeToParcel(@out, flags);
						}
					}
				}
			}
		}

		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual int describeContents()
		{
			return 0;
		}

		private sealed class _Creator_78 : android.os.ParcelableClass.Creator<android.statusbar.@internal.StatusBarIconList
			>
		{
			public _Creator_78()
			{
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.statusbar.@internal.StatusBarIconList createFromParcel(android.os.Parcel
				 parcel)
			{
				return new android.statusbar.@internal.StatusBarIconList(parcel);
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.statusbar.@internal.StatusBarIconList[] newArray(int size)
			{
				return new android.statusbar.@internal.StatusBarIconList[size];
			}
		}

		/// <summary>Parcelable.Creator that instantiates StatusBarIconList objects</summary>
		public static readonly android.os.ParcelableClass.Creator<android.statusbar.@internal.StatusBarIconList
			> CREATOR = new _Creator_78();

		public virtual void defineSlots(string[] slots)
		{
			int N = slots.Length;
			string[] s = mSlots = new string[N];
			{
				for (int i = 0; i < N; i++)
				{
					s[i] = slots[i];
				}
			}
			mIcons = new android.statusbar.@internal.StatusBarIcon[N];
		}

		public virtual int getSlotIndex(string slot)
		{
			int N = mSlots.Length;
			{
				for (int i = 0; i < N; i++)
				{
					if (slot.Equals(mSlots[i]))
					{
						return i;
					}
				}
			}
			return -1;
		}

		public virtual int size()
		{
			return mSlots.Length;
		}

		public virtual void setIcon(int index, android.statusbar.@internal.StatusBarIcon 
			icon)
		{
			mIcons[index] = icon.clone();
		}

		public virtual void removeIcon(int index)
		{
			mIcons[index] = null;
		}

		public virtual string getSlot(int index)
		{
			return mSlots[index];
		}

		public virtual android.statusbar.@internal.StatusBarIcon getIcon(int index)
		{
			return mIcons[index];
		}

		public virtual int getViewIndex(int index)
		{
			int count = 0;
			{
				for (int i = 0; i < index; i++)
				{
					if (mIcons[i] != null)
					{
						count++;
					}
				}
			}
			return count;
		}

		public virtual void copyFrom(android.statusbar.@internal.StatusBarIconList that)
		{
			if (that.mSlots == null)
			{
				this.mSlots = null;
				this.mIcons = null;
			}
			else
			{
				int N = that.mSlots.Length;
				this.mSlots = new string[N];
				this.mIcons = new android.statusbar.@internal.StatusBarIcon[N];
				{
					for (int i = 0; i < N; i++)
					{
						this.mSlots[i] = that.mSlots[i];
						this.mIcons[i] = that.mIcons[i] != null ? that.mIcons[i].clone() : null;
					}
				}
			}
		}

		public virtual void dump(java.io.PrintWriter pw)
		{
			int N = mSlots.Length;
			pw.println("Icon list:");
			{
				for (int i = 0; i < N; i++)
				{
					pw.printf("  %2d: (%s) %s\n", i, mSlots[i], mIcons[i]);
				}
			}
		}
	}
}

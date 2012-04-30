using Sharpen;

namespace android.os
{
	/// <summary>
	/// Defines a message containing a description and arbitrary data object that can be
	/// sent to a
	/// <see cref="Handler">Handler</see>
	/// .  This object contains two extra int fields and an
	/// extra object field that allow you to not do allocations in many cases.
	/// <p class="note">While the constructor of Message is public, the best way to get
	/// one of these is to call
	/// <see cref="obtain()">Message.obtain()</see>
	/// or one of the
	/// <see cref="Handler.obtainMessage()">Handler.obtainMessage()</see>
	/// methods, which will pull
	/// them from a pool of recycled objects.</p>
	/// </summary>
	[Sharpen.Sharpened]
	public sealed class Message : android.os.Parcelable
	{
		/// <summary>
		/// User-defined message code so that the recipient can identify
		/// what this message is about.
		/// </summary>
		/// <remarks>
		/// User-defined message code so that the recipient can identify
		/// what this message is about. Each
		/// <see cref="Handler">Handler</see>
		/// has its own name-space
		/// for message codes, so you do not need to worry about yours conflicting
		/// with other handlers.
		/// </remarks>
		public int what;

		/// <summary>
		/// arg1 and arg2 are lower-cost alternatives to using
		/// <see cref="setData(Bundle)">setData()</see>
		/// if you only need to store a
		/// few integer values.
		/// </summary>
		public int arg1;

		/// <summary>
		/// arg1 and arg2 are lower-cost alternatives to using
		/// <see cref="setData(Bundle)">setData()</see>
		/// if you only need to store a
		/// few integer values.
		/// </summary>
		public int arg2;

		/// <summary>An arbitrary object to send to the recipient.</summary>
		/// <remarks>
		/// An arbitrary object to send to the recipient.  When using
		/// <see cref="Messenger">Messenger</see>
		/// to send the message across processes this can only
		/// be non-null if it contains a Parcelable of a framework class (not one
		/// implemented by the application).   For other data transfer use
		/// <see cref="setData(Bundle)">setData(Bundle)</see>
		/// .
		/// <p>Note that Parcelable objects here are not supported prior to
		/// the
		/// <see cref="VERSION_CODES.FROYO">VERSION_CODES.FROYO</see>
		/// release.
		/// </remarks>
		public object obj;

		/// <summary>Optional Messenger where replies to this message can be sent.</summary>
		/// <remarks>
		/// Optional Messenger where replies to this message can be sent.  The
		/// semantics of exactly how this is used are up to the sender and
		/// receiver.
		/// </remarks>
		public android.os.Messenger replyTo;

		/// <summary>If set message is in use</summary>
		internal const int FLAG_IN_USE = 1;

		/// <summary>Flags reserved for future use (All are reserved for now)</summary>
		internal const int FLAGS_RESERVED = ~FLAG_IN_USE;

		/// <summary>Flags to clear in the copyFrom method</summary>
		internal const int FLAGS_TO_CLEAR_ON_COPY_FROM = FLAGS_RESERVED | FLAG_IN_USE;

		internal int flags;

		internal long when;

		internal android.os.Bundle data;

		internal android.os.Handler target;

		internal java.lang.Runnable callback;

		internal android.os.Message next;

		private static readonly object sPoolSync = new object();

		private static android.os.Message sPool;

		private static int sPoolSize = 0;

		internal const int MAX_POOL_SIZE = 10;

		// sometimes we store linked lists of these things
		/// <summary>Return a new Message instance from the global pool.</summary>
		/// <remarks>
		/// Return a new Message instance from the global pool. Allows us to
		/// avoid allocating new objects in many cases.
		/// </remarks>
		public static android.os.Message obtain()
		{
			lock (sPoolSync)
			{
				if (sPool != null)
				{
					android.os.Message m = sPool;
					sPool = m.next;
					m.next = null;
					sPoolSize--;
					return m;
				}
			}
			return new android.os.Message();
		}

		/// <summary>
		/// Same as
		/// <see cref="obtain()">obtain()</see>
		/// , but copies the values of an existing
		/// message (including its target) into the new one.
		/// </summary>
		/// <param name="orig">Original message to copy.</param>
		/// <returns>A Message object from the global pool.</returns>
		public static android.os.Message obtain(android.os.Message orig)
		{
			android.os.Message m = obtain();
			m.what = orig.what;
			m.arg1 = orig.arg1;
			m.arg2 = orig.arg2;
			m.obj = orig.obj;
			m.replyTo = orig.replyTo;
			if (orig.data != null)
			{
				m.data = new android.os.Bundle(orig.data);
			}
			m.target = orig.target;
			m.callback = orig.callback;
			return m;
		}

		/// <summary>
		/// Same as
		/// <see cref="obtain()">obtain()</see>
		/// , but sets the value for the <em>target</em> member on the Message returned.
		/// </summary>
		/// <param name="h">Handler to assign to the returned Message object's <em>target</em> member.
		/// 	</param>
		/// <returns>A Message object from the global pool.</returns>
		public static android.os.Message obtain(android.os.Handler h)
		{
			android.os.Message m = obtain();
			m.target = h;
			return m;
		}

		/// <summary>
		/// Same as
		/// <see cref="obtain(Handler)">obtain(Handler)</see>
		/// , but assigns a callback Runnable on
		/// the Message that is returned.
		/// </summary>
		/// <param name="h">Handler to assign to the returned Message object's <em>target</em> member.
		/// 	</param>
		/// <param name="callback">Runnable that will execute when the message is handled.</param>
		/// <returns>A Message object from the global pool.</returns>
		public static android.os.Message obtain(android.os.Handler h, java.lang.Runnable 
			callback)
		{
			android.os.Message m = obtain();
			m.target = h;
			m.callback = callback;
			return m;
		}

		/// <summary>
		/// Same as
		/// <see cref="obtain()">obtain()</see>
		/// , but sets the values for both <em>target</em> and
		/// <em>what</em> members on the Message.
		/// </summary>
		/// <param name="h">Value to assign to the <em>target</em> member.</param>
		/// <param name="what">Value to assign to the <em>what</em> member.</param>
		/// <returns>A Message object from the global pool.</returns>
		public static android.os.Message obtain(android.os.Handler h, int what)
		{
			android.os.Message m = obtain();
			m.target = h;
			m.what = what;
			return m;
		}

		/// <summary>
		/// Same as
		/// <see cref="obtain()">obtain()</see>
		/// , but sets the values of the <em>target</em>, <em>what</em>, and <em>obj</em>
		/// members.
		/// </summary>
		/// <param name="h">The <em>target</em> value to set.</param>
		/// <param name="what">The <em>what</em> value to set.</param>
		/// <param name="obj">The <em>object</em> method to set.</param>
		/// <returns>A Message object from the global pool.</returns>
		public static android.os.Message obtain(android.os.Handler h, int what, object obj
			)
		{
			android.os.Message m = obtain();
			m.target = h;
			m.what = what;
			m.obj = obj;
			return m;
		}

		/// <summary>
		/// Same as
		/// <see cref="obtain()">obtain()</see>
		/// , but sets the values of the <em>target</em>, <em>what</em>,
		/// <em>arg1</em>, and <em>arg2</em> members.
		/// </summary>
		/// <param name="h">The <em>target</em> value to set.</param>
		/// <param name="what">The <em>what</em> value to set.</param>
		/// <param name="arg1">The <em>arg1</em> value to set.</param>
		/// <param name="arg2">The <em>arg2</em> value to set.</param>
		/// <returns>A Message object from the global pool.</returns>
		public static android.os.Message obtain(android.os.Handler h, int what, int arg1, 
			int arg2)
		{
			android.os.Message m = obtain();
			m.target = h;
			m.what = what;
			m.arg1 = arg1;
			m.arg2 = arg2;
			return m;
		}

		/// <summary>
		/// Same as
		/// <see cref="obtain()">obtain()</see>
		/// , but sets the values of the <em>target</em>, <em>what</em>,
		/// <em>arg1</em>, <em>arg2</em>, and <em>obj</em> members.
		/// </summary>
		/// <param name="h">The <em>target</em> value to set.</param>
		/// <param name="what">The <em>what</em> value to set.</param>
		/// <param name="arg1">The <em>arg1</em> value to set.</param>
		/// <param name="arg2">The <em>arg2</em> value to set.</param>
		/// <param name="obj">The <em>obj</em> value to set.</param>
		/// <returns>A Message object from the global pool.</returns>
		public static android.os.Message obtain(android.os.Handler h, int what, int arg1, 
			int arg2, object obj)
		{
			android.os.Message m = obtain();
			m.target = h;
			m.what = what;
			m.arg1 = arg1;
			m.arg2 = arg2;
			m.obj = obj;
			return m;
		}

		/// <summary>Return a Message instance to the global pool.</summary>
		/// <remarks>
		/// Return a Message instance to the global pool.  You MUST NOT touch
		/// the Message after calling this function -- it has effectively been
		/// freed.
		/// </remarks>
		public void recycle()
		{
			clearForRecycle();
			lock (sPoolSync)
			{
				if (sPoolSize < MAX_POOL_SIZE)
				{
					next = sPool;
					sPool = this;
					sPoolSize++;
				}
			}
		}

		/// <summary>Make this message like o.</summary>
		/// <remarks>
		/// Make this message like o.  Performs a shallow copy of the data field.
		/// Does not copy the linked list fields, nor the timestamp or
		/// target/callback of the original message.
		/// </remarks>
		public void copyFrom(android.os.Message o)
		{
			this.flags = o.flags & ~FLAGS_TO_CLEAR_ON_COPY_FROM;
			this.what = o.what;
			this.arg1 = o.arg1;
			this.arg2 = o.arg2;
			this.obj = o.obj;
			this.replyTo = o.replyTo;
			if (o.data != null)
			{
				this.data = (android.os.Bundle)o.data.clone();
			}
			else
			{
				this.data = null;
			}
		}

		/// <summary>Return the targeted delivery time of this message, in milliseconds.</summary>
		/// <remarks>Return the targeted delivery time of this message, in milliseconds.</remarks>
		public long getWhen()
		{
			return when;
		}

		public void setTarget(android.os.Handler target)
		{
			this.target = target;
		}

		/// <summary>
		/// Retrieve the a
		/// <see cref="Handler">Handler</see>
		/// implementation that
		/// will receive this message. The object must implement
		/// <see cref="Handler.handleMessage(Message)">Handler.handleMessage()</see>
		/// . Each Handler has its own name-space for
		/// message codes, so you do not need to
		/// worry about yours conflicting with other handlers.
		/// </summary>
		public android.os.Handler getTarget()
		{
			return target;
		}

		/// <summary>Retrieve callback object that will execute when this message is handled.
		/// 	</summary>
		/// <remarks>
		/// Retrieve callback object that will execute when this message is handled.
		/// This object must implement Runnable. This is called by
		/// the <em>target</em>
		/// <see cref="Handler">Handler</see>
		/// that is receiving this Message to
		/// dispatch it.  If
		/// not set, the message will be dispatched to the receiving Handler's
		/// <see>Handler#handleMessage(Message Handler.handleMessage())</see>
		/// .
		/// </remarks>
		public java.lang.Runnable getCallback()
		{
			return callback;
		}

		/// <summary>
		/// Obtains a Bundle of arbitrary data associated with this
		/// event, lazily creating it if necessary.
		/// </summary>
		/// <remarks>
		/// Obtains a Bundle of arbitrary data associated with this
		/// event, lazily creating it if necessary. Set this value by calling
		/// <see cref="setData(Bundle)">setData(Bundle)</see>
		/// .  Note that when transferring data across
		/// processes via
		/// <see cref="Messenger">Messenger</see>
		/// , you will need to set your ClassLoader
		/// on the Bundle via
		/// <see cref="Bundle.setClassLoader(java.lang.ClassLoader)">Bundle.setClassLoader()</see>
		/// so that it can instantiate your objects when
		/// you retrieve them.
		/// </remarks>
		/// <seealso cref="peekData()">peekData()</seealso>
		/// <seealso cref="setData(Bundle)">setData(Bundle)</seealso>
		public android.os.Bundle getData()
		{
			if (data == null)
			{
				data = new android.os.Bundle();
			}
			return data;
		}

		/// <summary>Like getData(), but does not lazily create the Bundle.</summary>
		/// <remarks>
		/// Like getData(), but does not lazily create the Bundle.  A null
		/// is returned if the Bundle does not already exist.  See
		/// <see cref="getData()">getData()</see>
		/// for further information on this.
		/// </remarks>
		/// <seealso cref="getData()">getData()</seealso>
		/// <seealso cref="setData(Bundle)">setData(Bundle)</seealso>
		public android.os.Bundle peekData()
		{
			return data;
		}

		/// <summary>Sets a Bundle of arbitrary data values.</summary>
		/// <remarks>
		/// Sets a Bundle of arbitrary data values. Use arg1 and arg1 members
		/// as a lower cost way to send a few simple integer values, if you can.
		/// </remarks>
		/// <seealso cref="getData()"></seealso>
		/// <seealso cref="peekData()">peekData()</seealso>
		public void setData(android.os.Bundle data)
		{
			this.data = data;
		}

		/// <summary>
		/// Sends this Message to the Handler specified by
		/// <see cref="getTarget()">getTarget()</see>
		/// .
		/// Throws a null pointer exception if this field has not been set.
		/// </summary>
		public void sendToTarget()
		{
			target.sendMessage(this);
		}

		internal void clearForRecycle()
		{
			flags = 0;
			what = 0;
			arg1 = 0;
			arg2 = 0;
			obj = null;
			replyTo = null;
			when = 0;
			target = null;
			callback = null;
			data = null;
		}

		internal bool isInUse()
		{
			return ((flags & FLAG_IN_USE) == FLAG_IN_USE);
		}

		internal void markInUse()
		{
			flags |= FLAG_IN_USE;
		}

		/// <summary>
		/// Constructor (but the preferred way to get a Message is to call
		/// <see cref="obtain()">Message.obtain()</see>
		/// ).
		/// </summary>
		public Message()
		{
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			return toString(android.os.SystemClock.uptimeMillis());
		}

		internal string toString(long now)
		{
			java.lang.StringBuilder b = new java.lang.StringBuilder();
			b.append("{ what=");
			b.append(what);
			b.append(" when=");
			android.util.TimeUtils.formatDuration(when - now, b);
			if (arg1 != 0)
			{
				b.append(" arg1=");
				b.append(arg1);
			}
			if (arg2 != 0)
			{
				b.append(" arg2=");
				b.append(arg2);
			}
			if (obj != null)
			{
				b.append(" obj=");
				b.append(obj);
			}
			b.append(" }");
			return b.ToString();
		}

		private sealed class _Creator_426 : android.os.ParcelableClass.Creator<android.os.Message
			>
		{
			public _Creator_426()
			{
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.os.Message createFromParcel(android.os.Parcel source)
			{
				android.os.Message msg = android.os.Message.obtain();
				msg.readFromParcel(source);
				return msg;
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.os.Message[] newArray(int size)
			{
				return new android.os.Message[size];
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.os.Message> CREATOR
			 = new _Creator_426();

		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public int describeContents()
		{
			return 0;
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public void writeToParcel(android.os.Parcel dest, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void readFromParcel(android.os.Parcel source)
		{
			throw new System.NotImplementedException();
		}
	}
}

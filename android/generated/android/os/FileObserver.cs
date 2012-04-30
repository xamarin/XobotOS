using Sharpen;

namespace android.os
{
	[Sharpen.Stub]
	public abstract class FileObserver
	{
		public const int ACCESS = unchecked((int)(0x00000001));

		public const int MODIFY = unchecked((int)(0x00000002));

		public const int ATTRIB = unchecked((int)(0x00000004));

		public const int CLOSE_WRITE = unchecked((int)(0x00000008));

		public const int CLOSE_NOWRITE = unchecked((int)(0x00000010));

		public const int OPEN = unchecked((int)(0x00000020));

		public const int MOVED_FROM = unchecked((int)(0x00000040));

		public const int MOVED_TO = unchecked((int)(0x00000080));

		public const int CREATE = unchecked((int)(0x00000100));

		public const int DELETE = unchecked((int)(0x00000200));

		public const int DELETE_SELF = unchecked((int)(0x00000400));

		public const int MOVE_SELF = unchecked((int)(0x00000800));

		public const int ALL_EVENTS = ACCESS | MODIFY | ATTRIB | CLOSE_WRITE | CLOSE_NOWRITE
			 | OPEN | MOVED_FROM | MOVED_TO | DELETE | CREATE | DELETE_SELF | MOVE_SELF;

		internal const string LOG_TAG = "FileObserver";

		[Sharpen.Stub]
		private class ObserverThread : java.lang.Thread
		{
			internal java.util.HashMap<int, java.lang.@ref.WeakReference<object>> m_observers
				 = new java.util.HashMap<int, java.lang.@ref.WeakReference<object>>();

			internal int m_fd;

			[Sharpen.Stub]
			public ObserverThread() : base("FileObserver")
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"java.lang.Thread")]
			public override void run()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual int startWatching(string path, int mask, android.os.FileObserver observer
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void stopWatching(int descriptor)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void onEvent(int wfd, int mask, string path)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal int init()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal void observe(int fd)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal int startWatching(int fd, string path, int mask)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal void stopWatching(int fd, int wfd)
			{
				throw new System.NotImplementedException();
			}
		}

		private static android.os.FileObserver.ObserverThread s_observerThread;

		static FileObserver()
		{
			throw new System.NotImplementedException();
		}

		private string m_path;

		private int m_descriptor;

		private int m_mask;

		[Sharpen.Stub]
		public FileObserver(string path) : this(path, ALL_EVENTS)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public FileObserver(string path, int mask)
		{
			throw new System.NotImplementedException();
		}

		~FileObserver()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void startWatching()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void stopWatching()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public abstract void onEvent(int @event, string path);
	}
}

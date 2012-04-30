using Sharpen;

namespace android.graphics
{
	[Sharpen.Stub]
	public class Movie
	{
		private readonly int mNativeMovie;

		[Sharpen.Stub]
		private Movie(int nativeMovie)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int width()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int height()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isOpaque()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int duration()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool setTime(int relativeMilliseconds)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void draw(android.graphics.Canvas canvas, float x, float y, android.graphics.Paint
			 paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void draw(android.graphics.Canvas canvas, float x, float y)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.graphics.Movie decodeStream(java.io.InputStream @is)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.graphics.Movie decodeByteArray(byte[] data, int offset, int
			 length)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void nativeDestructor(int nativeMovie)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.graphics.Movie decodeFile(string pathName)
		{
			throw new System.NotImplementedException();
		}

		~Movie()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static android.graphics.Movie decodeTempStream(java.io.InputStream @is)
		{
			throw new System.NotImplementedException();
		}
	}
}

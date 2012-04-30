using Sharpen;

namespace android.view
{
	/// <summary>
	/// An instance of this class represents a connection to the surface
	/// flinger, in which you can create one or more Surface instances that will
	/// be composited to the screen.
	/// </summary>
	/// <remarks>
	/// An instance of this class represents a connection to the surface
	/// flinger, in which you can create one or more Surface instances that will
	/// be composited to the screen.
	/// <hide></hide>
	/// </remarks>
	[Sharpen.Sharpened]
	public class SurfaceSession
	{
		/// <summary>Create a new connection with the surface flinger.</summary>
		/// <remarks>Create a new connection with the surface flinger.</remarks>
		public SurfaceSession()
		{
			init();
		}

		/// <summary>Forcibly detach native resources associated with this object.</summary>
		/// <remarks>
		/// Forcibly detach native resources associated with this object.
		/// Unlike destroy(), after this call any surfaces that were created
		/// from the session will no longer work. The session itself is destroyed.
		/// </remarks>
		[Sharpen.NativeStub]
		public virtual void kill()
		{
			throw new System.NotImplementedException();
		}

		~SurfaceSession()
		{
			destroy();
		}

		[Sharpen.NativeStub]
		private void init()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.NativeStub]
		private void destroy()
		{
			throw new System.NotImplementedException();
		}

		private int mClient;
	}
}

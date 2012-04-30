using System.Runtime.InteropServices;
using Sharpen;

namespace android.graphics
{
	[Sharpen.Stub]
	public class Camera
	{
		[Sharpen.Stub]
		public Camera()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void save()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void restore()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void translate(float x, float y, float z)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void rotateX(float deg)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void rotateY(float deg)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void rotateZ(float deg)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void rotate(float x, float y, float z)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setLocation(float x, float y, float z)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void getMatrix(android.graphics.Matrix matrix)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void applyToCanvas(android.graphics.Canvas canvas)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual float dotWithNormal(float dx, float dy, float dz)
		{
			throw new System.NotImplementedException();
		}

		~Camera()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void nativeConstructor()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void nativeDestructor()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void nativeGetMatrix(int native_matrix)
		{
			throw new System.NotImplementedException();
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Camera_nativeApplyToCanvas(android.graphics.Canvas.NativeCanvas
			 native_canvas);

		private void nativeApplyToCanvas(android.graphics.Canvas.NativeCanvas native_canvas
			)
		{
			libxobotos_Camera_nativeApplyToCanvas(native_canvas);
		}

		internal int native_instance;
	}
}

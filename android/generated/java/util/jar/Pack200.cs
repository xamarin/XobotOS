using Sharpen;

namespace java.util.jar
{
	[Sharpen.Stub]
	public abstract class Pack200
	{
		[Sharpen.Stub]
		public static java.util.jar.Pack200.Packer newPacker()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static java.util.jar.Pack200.Unpacker newUnpacker()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public interface Packer
		{
			[Sharpen.Stub]
			java.util.SortedMap<string, string> properties();

			[Sharpen.Stub]
			void pack(java.util.jar.JarFile @in, java.io.OutputStream @out);

			[Sharpen.Stub]
			void pack(java.util.jar.JarInputStream @in, java.io.OutputStream @out);

			[Sharpen.Stub]
			void addPropertyChangeListener(java.beans.PropertyChangeListener listener);

			[Sharpen.Stub]
			void removePropertyChangeListener(java.beans.PropertyChangeListener listener);
		}

		[Sharpen.Stub]
		public static class PackerClass
		{
		}

		[Sharpen.Stub]
		public interface Unpacker
		{
			[Sharpen.Stub]
			java.util.SortedMap<string, string> properties();

			[Sharpen.Stub]
			void unpack(java.io.InputStream @in, java.util.jar.JarOutputStream @out);

			[Sharpen.Stub]
			void unpack(java.io.File @in, java.util.jar.JarOutputStream @out);

			[Sharpen.Stub]
			void addPropertyChangeListener(java.beans.PropertyChangeListener listener);

			[Sharpen.Stub]
			void removePropertyChangeListener(java.beans.PropertyChangeListener listener);
		}

		[Sharpen.Stub]
		public static class UnpackerClass
		{
		}
	}
}

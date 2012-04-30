using Sharpen;

namespace java.io
{
	[Sharpen.Stub]
	public interface DataOutput
	{
		[Sharpen.Stub]
		void write(byte[] buffer);

		[Sharpen.Stub]
		void write(byte[] buffer, int offset, int count);

		[Sharpen.Stub]
		void write(int oneByte);

		[Sharpen.Stub]
		void writeBoolean(bool val);

		[Sharpen.Stub]
		void writeByte(int val);

		[Sharpen.Stub]
		void writeBytes(string str);

		[Sharpen.Stub]
		void writeChar(int val);

		[Sharpen.Stub]
		void writeChars(string str);

		[Sharpen.Stub]
		void writeDouble(double val);

		[Sharpen.Stub]
		void writeFloat(float val);

		[Sharpen.Stub]
		void writeInt(int val);

		[Sharpen.Stub]
		void writeLong(long val);

		[Sharpen.Stub]
		void writeShort(int val);

		[Sharpen.Stub]
		void writeUTF(string str);
	}
}

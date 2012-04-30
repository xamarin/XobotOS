using Sharpen;

namespace java.io
{
	[Sharpen.Stub]
	public interface DataInput
	{
		[Sharpen.Stub]
		bool readBoolean();

		[Sharpen.Stub]
		byte readByte();

		[Sharpen.Stub]
		char readChar();

		[Sharpen.Stub]
		double readDouble();

		[Sharpen.Stub]
		float readFloat();

		[Sharpen.Stub]
		void readFully(byte[] dst);

		[Sharpen.Stub]
		void readFully(byte[] dst, int offset, int byteCount);

		[Sharpen.Stub]
		int readInt();

		[Sharpen.Stub]
		string readLine();

		[Sharpen.Stub]
		long readLong();

		[Sharpen.Stub]
		short readShort();

		[Sharpen.Stub]
		int readUnsignedByte();

		[Sharpen.Stub]
		int readUnsignedShort();

		[Sharpen.Stub]
		string readUTF();

		[Sharpen.Stub]
		int skipBytes(int count);
	}
}

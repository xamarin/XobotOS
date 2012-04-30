using System;

namespace Sharpen
{
	public interface INativeHandle
	{
		void Free ();

		IntPtr Address { get; }
	}
}

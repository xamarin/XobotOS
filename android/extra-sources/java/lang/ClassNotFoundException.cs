using Sharpen;
using System;

namespace java.lang
{
	/// <summary>Thrown when a class loader is unable to find a class.</summary>
	/// <remarks>Thrown when a class loader is unable to find a class.</remarks>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class ClassNotFoundException : Exception
	{
		private const long serialVersionUID = 9176873029745254542L;

		public ClassNotFoundException ()
		{
		}

		public ClassNotFoundException (string detailMessage) : base(detailMessage, null)
		{
		}

		public ClassNotFoundException (string detailMessage, Exception exception)
			: base(detailMessage, exception)
		{
		}
	}
}

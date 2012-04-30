using Sharpen;

namespace org.xmlpull.v1
{
	/// <summary>This exception is thrown to signal XML Pull Parser related faults.</summary>
	/// <remarks>This exception is thrown to signal XML Pull Parser related faults.</remarks>
	/// <author><a href="http://www.extreme.indiana.edu/~aslom/">Aleksander Slominski</a>
	/// 	</author>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class XmlPullParserException : System.Exception
	{
		protected internal System.Exception detail;

		protected internal int row = -1;

		protected internal int column = -1;

		public XmlPullParserException(string s) : base(s)
		{
		}

		public XmlPullParserException(string msg, org.xmlpull.v1.XmlPullParser parser, System.Exception
			 chain) : base((msg == null ? string.Empty : msg + " ") + (parser == null ? string.Empty
			 : "(position:" + parser.getPositionDescription() + ") ") + (chain == null ? string.Empty
			 : "caused by: " + chain))
		{
			// for license please see accompanying LICENSE.txt file (available also at http://www.xmlpull.org/)
			if (parser != null)
			{
				this.row = parser.getLineNumber();
				this.column = parser.getColumnNumber();
			}
			this.detail = chain;
		}

		public virtual System.Exception getDetail()
		{
			return detail;
		}

		//    public void setDetail(Throwable cause) { this.detail = cause; }
		public virtual int getLineNumber()
		{
			return row;
		}

		public virtual int getColumnNumber()
		{
			return column;
		}
		//NOTE: code that prints this and detail is difficult in J2ME
	}
}

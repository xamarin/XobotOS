using System;

namespace java.lang
{
	public class CharSequenceProxy : CharSequence
	{
		private readonly CharSequence _proxy;

		public CharSequenceProxy (CharSequence proxy)
		{
			this._proxy = proxy;
		}
		
		public CharSequenceProxy (string str)
		{
			this._proxy = new StringProxy (str);
		}

		#region CharSequence implementation
		public int Length {
			get { return _proxy.Length; }
		}

		public char this [int index] {
			get { return _proxy [index]; }
		}

		public CharSequence SubSequence (int start, int end)
		{
			return _proxy.SubSequence (start, end);
		}
		#endregion
		
		[System.Obsolete("Use the Length property.", true)]
		public int length ()
		{
			return _proxy.Length;
		}
		
		[System.Obsolete("Use the indexer.", true)]
		public char charAt (int index)
		{
			return _proxy [index];
		}
		
		public CharSequence Proxy {
			get { return _proxy; }
		}
		
		public static CharSequenceProxy Wrap (string str)
		{
			return str != null ? new CharSequenceProxy (new StringProxy (str)) : null;
		}

		public static implicit operator CharSequenceProxy (string str)
		{
			return Wrap (str);
		}
		
		public static bool IsStringProxy (CharSequence csq)
		{
			return csq is StringProxy;
		}
		
		public static string UnWrap (CharSequence csq)
		{
			if (csq == null)
				throw new ArgumentException ();
			if (csq is CharSequenceProxy) {
				CharSequenceProxy proxy = (CharSequenceProxy)csq;
				StringProxy sp = proxy.Proxy as StringProxy;
				if (sp == null)
					throw new ArgumentException ();
				return sp.ToString ();
			} else if (csq is StringProxy) {
				StringProxy sp = (StringProxy)csq;
				return sp.ToString ();
			} else {
				throw new ArgumentException ();
			}
		}

		public override string ToString ()
		{
			return _proxy.ToString ();
		}
		
		private class StringProxy : CharSequence
		{
			private readonly string _str;
			
			public StringProxy (string str)
			{
				this._str = str;
			}

			#region CharSequence implementation
			public int Length {
				get { return _str.Length; }
			}

			public char this [int index] {
				get { return _str [index]; }
			}

			public CharSequence SubSequence (int start, int end)
			{
				return CharSequenceProxy.Wrap (_str.Substring (start, end - start));
			}
			#endregion
			
			public override string ToString ()
			{
				return _str;
			}
		}
	}
}


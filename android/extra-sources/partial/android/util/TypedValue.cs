using System;

namespace android.util
{
	partial class TypedValue
	{
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString ()
		{
			java.lang.StringBuilder sb = new java.lang.StringBuilder ();
			sb.append ("TypedValue{t=0x").append (Sharpen.Util.IntToHexString (type));
			sb.append ("/d=0x").append (Sharpen.Util.IntToHexString (data));
			if (type == TYPE_STRING) {
				java.lang.CharSequence strseq = @string != null ? @string :
					java.lang.CharSequenceProxy.Wrap ("<null>");
				sb.append (" \"").append (strseq).append ("\"");
			}
			if (assetCookie != 0) {
				sb.append (" a=").append (assetCookie);
			}
			if (resourceId != 0) {
				sb.append (" r=0x").append (Sharpen.Util.IntToHexString (resourceId));
			}
			sb.append ("}");
			return sb.ToString ();
		}
	}
}

